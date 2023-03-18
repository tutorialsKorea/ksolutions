using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS18A_D0A : BaseMenuDialog
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

        public SYS18A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;

        }

        public override void DialogInit()
        {

            (acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).SetCode("S095");
            (acLayoutControl1.GetEditor("DLOG_TYPE") as acLookupEdit).SetCode("S096");
            (acLayoutControl1.GetEditor("DLOG_PERIOD") as acLookupEdit).SetCode("S097");
            //(acLayoutControl1.GetEditor("DLOG_PLAN") as acLookupEdit).SetCode("S098");
            (acLayoutControl1.GetEditor("RELATED_PROD") as acLookupEdit).SetCode("S099"); 
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).Value = "P";
            (acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).isReadyOnly = true;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();

        }


      


        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                acLayoutControl layout = sender as acLayoutControl;

                switch (info.ColumnName)
                {
                    case "DLOG_PERIOD":

                        (layout.GetEditor("DLOG_PLAN").Editor as acLookupEdit).SetCode("S098", newValue);

                        break;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("APPLY_START_DATE").Value = DateTime.Now;
            acLayoutControl1.GetEditor("APPLY_END_DATE").Value = new DateTime(DateTime.Now.Year, 12, 31);

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData, true);

            if(((DataRow)_LinkData)["APPLY_FLAG"].ToString() == "1")
            {
                acCheckEdit1.CheckState = CheckState.Checked;
            }
        }


        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                //layout.GetEditor("APPLY_SDATE").Value = DateTime.Now;
                //layout.GetEditor("APPLY_EDATE").Value = new DateTime(DateTime.Now.Year, 12, 31);
            }

            base.ChildContainerInit(sender);
        }





        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

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
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("RELATED_EMP", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                paramTable.Columns.Add("DLOG_CAT", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("DLOG_PERIOD", typeof(String)); //
                paramTable.Columns.Add("DLOG_PLAN", typeof(String)); //
                paramTable.Columns.Add("DLOG_TIME", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                paramTable.Columns.Add("APPLY_START_DATE", typeof(String)); //
                paramTable.Columns.Add("APPLY_END_DATE", typeof(String)); //
                paramTable.Columns.Add("APPLY_FLAG", typeof(byte)); //



                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = "";
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["RELATED_EMP"] = layoutRow["RELATED_EMP"];
                paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramRow["DLOG_CAT"] = layoutRow["DLOG_CAT"];
                paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                paramRow["DLOG_PERIOD"] = layoutRow["DLOG_PERIOD"];
                paramRow["DLOG_PLAN"] = layoutRow["DLOG_PLAN"];
                paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["OVERWRITE"] = "0";

                paramRow["APPLY_START_DATE"] = layoutRow["APPLY_START_DATE"];
                paramRow["APPLY_END_DATE"] = layoutRow["APPLY_END_DATE"];
                paramRow["APPLY_FLAG"] = layoutRow["APPLY_FLAG"];


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "SYS18A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                    this._LinkView.UpdateMapingRow(row, true);
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
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("RELATED_EMP", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                paramTable.Columns.Add("DLOG_CAT", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("DLOG_PERIOD", typeof(String)); //
                paramTable.Columns.Add("DLOG_PLAN", typeof(String)); //
                paramTable.Columns.Add("DLOG_TIME", typeof(decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                paramTable.Columns.Add("APPLY_START_DATE", typeof(String)); //
                paramTable.Columns.Add("APPLY_END_DATE", typeof(String)); //
                paramTable.Columns.Add("APPLY_FLAG", typeof(byte)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = linkRow["DLOG_ID"];
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["RELATED_EMP"] = layoutRow["RELATED_EMP"];
                paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramRow["DLOG_CAT"] = layoutRow["DLOG_CAT"];
                paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                paramRow["DLOG_PERIOD"] = layoutRow["DLOG_PERIOD"];
                paramRow["DLOG_PLAN"] = layoutRow["DLOG_PLAN"];
                paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["OVERWRITE"] = "1";

                paramRow["APPLY_START_DATE"] = layoutRow["APPLY_START_DATE"];
                paramRow["APPLY_END_DATE"] = layoutRow["APPLY_END_DATE"];
                paramRow["APPLY_FLAG"] = layoutRow["APPLY_FLAG"];


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS18A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                    this._LinkView.UpdateMapingRow(row, true);
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
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = linkRow["DLOG_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS18A_DEL", paramSet, "RQSTDT", "",
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

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);


        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
    }
}