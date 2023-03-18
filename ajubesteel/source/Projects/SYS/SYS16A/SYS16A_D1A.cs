﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS16A_D1A : BaseMenuDialog
    {

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override void BarCodeScanInput(string barcode)
        {


        }


        private TileView _LinkView = null;



        private object _LinkData = null;
        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        private string[] _KeyColumn = new string[] { };
        public string[] KeyColumn
        {
            get { return _KeyColumn; }
            set { _KeyColumn = value; }
        }



        public SYS16A_D1A(TileView linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;


        }



        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            KeyColumn = new string[] { "UPD_ID" };

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData, true);


        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("TITLE").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow datarow = _LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UPD_TITLE", typeof(String)); //
                paramTable.Columns.Add("UPD_CONT", typeof(String)); //
                paramTable.Columns.Add("UPD_VER", typeof(String)); //
                paramTable.Columns.Add("UPD_ID", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPD_TITLE"] = layoutRow["UPD_TITLE"];
                paramRow["UPD_CONT"] = layoutRow["UPD_CONT"];
                paramRow["UPD_VER"] = layoutRow["UPD_VER"];
                if (datarow != null)
                    paramRow["UPD_ID"] = datarow["UPD_ID"];
                
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "SYS13A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.UpdateMappingRow(_LinkView, row, _KeyColumn);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UPD_TITLE", typeof(String)); //
                paramTable.Columns.Add("UPD_CONT", typeof(String)); //
                paramTable.Columns.Add("UPD_VER", typeof(String)); //
                paramTable.Columns.Add("UPD_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPD_TITLE"] = layoutRow["UPD_TITLE"];
                paramRow["UPD_CONT"] = layoutRow["UPD_CONT"];
                paramRow["UPD_VER"] = layoutRow["UPD_VER"];
                paramRow["UPD_ID"] = linkRow["UPD_ID"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS13A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSaveClose,
                            QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.UpdateMappingRow(_LinkView, row, _KeyColumn);
                }

                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = (DataRow)_LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UPD_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPD_ID"] = linkRow["UPD_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS13A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.DeleteMappingRow(_LinkView, row, _KeyColumn);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);


        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }



        void UpdateMappingRow(TileView tw, DataRow row, string[] _KeyColumns)
        {
            try
            {
                DataTable dt = tw.GridControl.DataSource as DataTable;
                if (dt == null) { return; }

                bool isFindRow = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    foreach (string keyColumn in _KeyColumns)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {

                            if (dt.Rows[i][keyColumn].ToString() == row[keyColumn].ToString())
                            {
                                //일치시 행 업데이트
                                dt.Rows[i]["UPD_TITLE"] = row["UPD_TITLE"];
                                dt.Rows[i]["UPD_VER"] = row["UPD_VER"];
                                dt.Rows[i]["UPD_CONT"] = row["UPD_CONT"];

                                isFindRow = true;

                            }
                        }
                    }
                }
                if (isFindRow == false)
                {
                    // 일치하는 Row가 없을 시 신규추가 
                    dt.ImportRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void DeleteMappingRow(TileView tw, DataRow row, string[] _KeyColumns)
        {
            try
            {
                DataTable dt = tw.GridControl.DataSource as DataTable;
                if (dt == null) { return; }

                bool isFindRow = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    foreach (string keyColumn in _KeyColumns)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {

                            if (dt.Rows[i][keyColumn].ToString() == row[keyColumn].ToString())
                            {
                                //키컬럼 일치시 제거

                                dt.Rows.RemoveAt(i);

                                isFindRow = true;

                            }
                        }
                    }
                }
                if (isFindRow == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}