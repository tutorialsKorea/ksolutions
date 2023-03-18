using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using BizManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace SYS
{
    public sealed partial class SYS03A_D1A : BaseMenuDialog
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



        private string[] _KeyColumn = new string[] { };

        public string[] KeyColumn
        {
            get { return _KeyColumn; }
            set { _KeyColumn = value; }
        }


        private TileView _LinkView = null;
       

        public SYS03A_D1A(TileView linkView, object linkData)
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

            acTextEdit2.Enabled = false;
            acSimpleButton1.Enabled = false;

            (acLayoutControl1.GetEditor("ACC_LEVEL").Editor as acLookupEdit).SetCode("S010");

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            KeyColumn = new string[] {"NOTICE_ID"};

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


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "ACC_LEVEL":

                    if(newValue == null)
                    {
                       
                        acTextEdit2.Enabled = false;
                        acSimpleButton1.Enabled = false;

                        break;
                    }

                    if (newValue.ToString() == "O")
                    {
                        acTextEdit2.Enabled = true;
                        acTextEdit2.isRequired = true;
                        acSimpleButton1.Enabled = true;

                    }
                    else
                    {
                        
                        acSimpleButton1.Enabled = false;
                        acTextEdit2.isRequired = false;
                        acTextEdit2.Enabled = false;
                        
                        
                        layout.GetEditor("ORG_CODES").Clear();
                    }

                    break;
            }
        }



        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("ACC_LEVEL").FocusEdit();
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
                paramTable.Columns.Add("NOTICE_ID", typeof(String)); //
                paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NOTICE_ID"] = null;
                paramRow["ACC_LEVEL"] = layoutRow["ACC_LEVEL"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (layoutRow["ACC_LEVEL"].EqualsEx("O") && dsOrg != null)
                {
                    paramTable.Columns.Add("ORG_CODES", typeof(String));
                    paramRow["ORG_CODES"] = dsOrg.Tables["RQSTDT"].Rows[0]["RECEIVER"];
                  
                }
              

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "SYS03A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                    this.UpdateMapingRow(_LinkView, row, _KeyColumn);
                }
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
                paramTable.Columns.Add("NOTICE_ID", typeof(String)); //
                paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NOTICE_ID"] = linkRow["NOTICE_ID"];
                paramRow["ACC_LEVEL"] = layoutRow["ACC_LEVEL"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                if (layoutRow["ACC_LEVEL"].EqualsEx("O") && dsOrg != null)
                {
                    paramTable.Columns.Add("ORG_CODES", typeof(String));
                    paramRow["ORG_CODES"] = dsOrg.Tables["RQSTDT"].Rows[0]["RECEIVER"];

                }
                else
                {
                    paramTable.Columns.Add("ORG_CODES", typeof(String));
                    paramRow["ORG_CODES"] = layoutRow["ORG_CODES"];
                }


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS03A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                    this.UpdateMapingRow(_LinkView, row, _KeyColumn);

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
                paramTable.Columns.Add("NOTICE_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NOTICE_ID"] = linkRow["NOTICE_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS03A_DEL", paramSet, "RQSTDT", "",
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

                   this.DeleteMapingRow(_LinkView, row, _KeyColumn);

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



        void UpdateMapingRow(TileView tw, DataRow row, string[] _KeyColumns)
        {
            try
            {
                DataTable dt = tw.GridControl.DataSource as DataTable;
                if (dt == null) { return; }

                bool isFindRow = false;

                for (int i=0; i < dt.Rows.Count; i++)
                {
                
                    foreach (string keyColumn in _KeyColumns)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {
                            
                            if(dt.Rows[i][keyColumn].ToString() == row[keyColumn].ToString())
                            {
                                //일치시 행 업데이트
                                dt.Rows[i]["ACC_LEVEL"] = row["ACC_LEVEL"];
                                dt.Rows[i]["TITLE"] = row["TITLE"];
                                dt.Rows[i]["ORG_CODES"] = row["ORG_CODES"];
                                dt.Rows[i]["CONTENTS"] = row["CONTENTS"];

                                isFindRow = true;

                            }
                        }
                    }
                }
                if(isFindRow == false)
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

        void DeleteMapingRow(TileView tw, DataRow row, string[] _KeyColumns)
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


        private DataSet dsOrg = null;

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            // 부서추가

            if (!base.ChildFormContains("NEW"))
            {

                SYS03A_D2A frm = new SYS03A_D2A(_LinkData, dsOrg);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("RECEIVER_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsOrg = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("ORG_CODES").Value = dsOrg.Tables["RQSTDT"].Rows[0]["RECEIVER"];
                }

            }
            else
            {

                base.ChildFormFocus("NEW");

            }

        }
    }
}