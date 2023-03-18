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

namespace STD
{
    public sealed partial class STD45A_D0A : BaseMenuDialog
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

        


        public STD45A_D0A(acGridView linkView, object linkData)
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


            acRadioGroup1.AddRadioItem("IP 주소", false, "", false, "", "0");
            acRadioGroup1.AddRadioItem("MAC 주소", false, "", false, "", "1");
            acRadioGroup1.AddRadioItem("컴퓨터 이름", false, "", false, "", "2");

            acRadioGroup1.Properties.Columns = 3;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            (acLayoutControl1.GetEditor("MC_GROUP").Editor as acLookupEdit).SetCode("C020");

            acRadioGroup1.Value = "0";

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            (acLayoutControl1.GetEditor("MC_GROUP").Editor as acLookupEdit).SetCode("C020");

            acLayoutControl1.DataBind((DataRow)_LinkData,true);

        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PANEL_CODE"] = layoutRow["PANEL_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "STD45A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkView.DeleteMappingRow(row);
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
            //저장 후 닫기

            try
            {
                DataSet paramSet = GetData("1");

                if (paramSet == null)
                    return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "STD45A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

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

                acLayoutControl1.GetEditor("MC_GROUP").FocusEdit();
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
                DataSet paramSet = GetData("0");

                if (paramSet == null)
                    return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                    "STD45A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        private DataSet GetData(string overwrite)
        {

            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return null;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable.Columns.Add("PANEL_NAME", typeof(String)); //
                //paramTable.Columns.Add("CONN_TYPE", typeof(String)); //
                //paramTable.Columns.Add("CONN_INFO", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //
                paramTable.Columns.Add("PANEL_SEQ", typeof(int)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //                
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //                
                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PANEL_CODE"] = layoutRow["PANEL_CODE"];
                paramRow["PANEL_NAME"] = layoutRow["PANEL_NAME"];
                //paramRow["CONN_TYPE"] = layoutRow["CONN_TYPE"];
                //paramRow["CONN_INFO"] = layoutRow["CONN_INFO"];
                paramRow["MC_GROUP"] = layoutRow["MC_GROUP"];
                paramRow["PANEL_SEQ"] = layoutRow["PANEL_SEQ"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["OVERWRITE"] = overwrite;
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                return paramSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);

        } 
    }
}