using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS01A_D1A : BaseMenuDialog
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

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }
        private acGridView _LinkView = null;


        public SYS01A_D1A(acGridView linkView, object linkData)
        {


            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;


        }


        public override void DialogInit()
        {


            try
            {


                barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                acLayoutControl1.KeyColumns = new string[] { "RPT_CLASS" };


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            acLayoutControl1.DataBind((DataRow)_LinkData, true);

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acTextEdit1.Focus();
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





                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("LANG", typeof(String)); //
                paramTable.Columns.Add("RPT_CATEGORY_ID", typeof(String)); //
                paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable.Columns.Add("RPT_CLASS", typeof(String)); //
                paramTable.Columns.Add("RPT_NAME", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("IS_USE", typeof(Byte)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LANG"] = acInfo.Lang;
                paramRow["RPT_CLASS"] = layoutRow["RPT_CLASS"];
                paramRow["MENU_CODE"] = layoutRow["MENU_CODE"];
                paramRow["RPT_CATEGORY_ID"] = layoutRow["RPT_CATEGORY_ID"];
                paramRow["RPT_NAME"] = layoutRow["RPT_NAME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["IS_USE"] = layoutRow["IS_USE"];
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "SYS01A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {


                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }


                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {


            //중복됨 덮어쓰기 여부 물어본다.

            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

                return;
            }


            acMessageBox.Show(this, ex);



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

                DataRow linkRow = (DataRow)this._LinkData;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("LANG", typeof(String)); //
                paramTable.Columns.Add("RPT_CLASS", typeof(String)); //
                paramTable.Columns.Add("RPT_CATEGORY_ID", typeof(String)); //
                paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable.Columns.Add("RPT_NAME", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("IS_USE", typeof(Byte)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LANG"] = acInfo.Lang;
                paramRow["RPT_CLASS"] = layoutRow["RPT_CLASS"];
                paramRow["RPT_CATEGORY_ID"] = layoutRow["RPT_CATEGORY_ID"];
                paramRow["MENU_CODE"] = layoutRow["MENU_CODE"];
                paramRow["RPT_NAME"] = layoutRow["RPT_NAME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["IS_USE"] = layoutRow["IS_USE"];
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);



                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "SYS01A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }
        }

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataRow linkRow = (DataRow)this._LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RPT_CLASS", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["RPT_CLASS"] = linkRow["RPT_CLASS"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS01A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


    }
}