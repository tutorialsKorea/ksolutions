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

namespace PLN
{
    public sealed partial class PLN18A_D0A : BaseMenuDialog
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


        public PLN18A_D0A(acGridView linkView, object linkData)
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

            (acLayoutControl1.GetEditor("PRJ_STATE") as acLookupEdit).SetCode("P013");
            (acLayoutControl1.GetEditor("DEV_GROUP") as acLookupEdit).SetCode("P014");
            (acLayoutControl1.GetEditor("IS_CONFIRM") as acLookupEdit).SetCode("P015");
        


            acEmp2.Value = acInfo.UserID;

            //acLookupEdit1.Value = 0;
            //acLookupEdit2.Value = 1;
            //acLookupEdit3.Value = 'X';

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
                if (acMessageBox.Show(this, "초기화 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("PRJ_STATE").FocusEdit();

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
                paramTable.Columns.Add("PRJ_CODE", typeof(String)); //
                paramTable.Columns.Add("PRJ_STATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_NAME", typeof(String)); //
                paramTable.Columns.Add("REQ_DATE", typeof(String)); //
                paramTable.Columns.Add("CVND_CODE", typeof(String)); //
                paramTable.Columns.Add("CHARGE_EMP", typeof(String)); //
                paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //
                paramTable.Columns.Add("DESIGN_EMP", typeof(String)); //
                paramTable.Columns.Add("DEV_GROUP", typeof(String)); //
                paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_START_DATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_END_DATE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("PROGRESS", typeof(decimal)); //
                paramTable.Columns.Add("IS_CONFIRM", typeof(string)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRJ_CODE"] = "";
                paramRow["PRJ_STATE"] = layoutRow["PRJ_STATE"];
                paramRow["PRJ_NAME"] = layoutRow["PRJ_NAME"];
                paramRow["REQ_DATE"] = layoutRow["REQ_DATE"].toDateString("yyyyMMdd");
                paramRow["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow["CHARGE_EMP"] = layoutRow["CHARGE_EMP"];
                paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow["DESIGN_EMP"] = layoutRow["DESIGN_EMP"];
                paramRow["DEV_GROUP"] = layoutRow["DEV_GROUP"];
                paramRow["PLN_END_DATE"] = layoutRow["PLN_END_DATE"].toDateString("yyyyMMdd");
                paramRow["PRJ_START_DATE"] = layoutRow["PRJ_START_DATE"].toDateString("yyyyMMdd");
                paramRow["PRJ_END_DATE"] = layoutRow["PRJ_END_DATE"].toDateString("yyyyMMdd");
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["PROGRESS"] = layoutRow["PROGRESS"];
                paramRow["IS_CONFIRM"] = layoutRow["IS_CONFIRM"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "PLN18A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRJ_CODE", typeof(String)); //
                paramTable.Columns.Add("PRJ_STATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_NAME", typeof(String)); //
                paramTable.Columns.Add("REQ_DATE", typeof(String)); //
                paramTable.Columns.Add("CVND_CODE", typeof(String)); //
                paramTable.Columns.Add("CHARGE_EMP", typeof(String)); //
                paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //
                paramTable.Columns.Add("DESIGN_EMP", typeof(String)); //
                paramTable.Columns.Add("DEV_GROUP", typeof(String)); //
                paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_START_DATE", typeof(String)); //
                paramTable.Columns.Add("PRJ_END_DATE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("PROGRESS", typeof(decimal)); //
                paramTable.Columns.Add("IS_CONFIRM", typeof(string)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRJ_CODE"] = layoutRow["PRJ_CODE"];
                paramRow["PRJ_STATE"] = layoutRow["PRJ_STATE"];
                paramRow["PRJ_NAME"] = layoutRow["PRJ_NAME"];
                paramRow["REQ_DATE"] = layoutRow["REQ_DATE"].toDateString("yyyyMMdd");
                paramRow["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow["CHARGE_EMP"] = layoutRow["CHARGE_EMP"];
                paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow["DESIGN_EMP"] = layoutRow["DESIGN_EMP"];
                paramRow["DEV_GROUP"] = layoutRow["DEV_GROUP"];
                paramRow["PLN_END_DATE"] = layoutRow["PLN_END_DATE"].toDateString("yyyyMMdd");
                paramRow["PRJ_START_DATE"] = layoutRow["PRJ_START_DATE"].toDateString("yyyyMMdd");
                paramRow["PRJ_END_DATE"] = layoutRow["PRJ_END_DATE"].toDateString("yyyyMMdd");
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["PROGRESS"] = layoutRow["PROGRESS"];
                paramRow["IS_CONFIRM"] = layoutRow["IS_CONFIRM"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "PLN18A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                "PLN18A_DEL", paramSet, "RQSTDT", "",
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


        //고객사 변경시
        private void acVendor1_EditValueChanged(object sender, EventArgs e)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_CODE"] = acVendor1.Value;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            (acLayoutControl1.GetEditor("CHARGE_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", "STD05A_SER4", paramSet, "RQSTDT", "RSLTDT");
        }
    }
}