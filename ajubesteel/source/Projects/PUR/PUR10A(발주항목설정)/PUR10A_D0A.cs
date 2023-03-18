using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using BizManager;

namespace PUR
{
    public sealed partial class PUR10A_D0A : BaseMenuDialog
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



        public PUR10A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;

            #region 이벤트 설정


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            #endregion
        }

        void acLayoutControl1_OnValueChanged(object sender , IBaseEditControl info, object newValue)
        {

            switch (info.ColumnName)
            {
                case "INCL_VAT":
                    if (info.Value.ToString() == "1")
                        acLayoutControl1.GetEditor("EXP_VAT").Editor.EditValue = "0";
                    break;
                case "EXP_VAT":
                    if (info.Value.ToString() == "1")
                        acLayoutControl1.GetEditor("INCL_VAT").Editor.EditValue = "0";
                    break;
                case "CHKBOX_ADD1":
                    if (info.Value.ToString() == "1")
                        acLayoutControl1.GetEditor("CHK_ADD1").Editor.Enabled = true;
                    else
                        acLayoutControl1.GetEditor("CHK_ADD1").Editor.Enabled = false;
                    break;

                case "CHKBOX_ADD2":
                    if (info.Value.ToString() == "1")
                        acLayoutControl1.GetEditor("CHK_ADD2").Editor.Enabled = true;
                    else
                        acLayoutControl1.GetEditor("CHK_ADD2").Editor.Enabled = false;
                    break;

                case "CHKBOX_ADD3":
                    if (info.Value.ToString() == "1")
                        acLayoutControl1.GetEditor("CHK_ADD3").Editor.Enabled = true;
                    else
                        acLayoutControl1.GetEditor("CHK_ADD3").Editor.Enabled = false;
                    break;

            }
        }


        public override void DialogInit()
        {
            //요청일

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE");
            
            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramTable.Rows.Add(paramRow);

            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_MYVENDOR", paramSet, "RQSTDT", "RSLTDT");
            
            //if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            //{
            //    DataRow drVendpr = resultSet.Tables["RSLTDT"].Rows[0];
            //    acLayoutControl1.GetEditor("VEN_NAME").Value = drVendpr["VEN_NAME"];
            //    acLayoutControl1.GetEditor("VEN_BIZ_NO").Value = drVendpr["VEN_BIZ_NO"];
            //    acLayoutControl1.GetEditor("VEN_CEO").Value = drVendpr["VEN_CEO"];
            //    acLayoutControl1.GetEditor("VEN_TEL").Value = drVendpr["VEN_TEL"];
            //    acLayoutControl1.GetEditor("VEN_FAX").Value = drVendpr["VEN_FAX"];
            //    acLayoutControl1.GetEditor("VEN_CONDITIONS").Value = acInfo.StdCodes.GetNameByCode("C017", drVendpr["VEN_CONDITIONS"].ToString());
            //    acLayoutControl1.GetEditor("VEN_PRODUCTS").Value = drVendpr["VEN_PRODUCTS"];
            //}

            //acLayoutControl1.GetEditor("EMP_NAME").Value = acInfo.UserName;
            //acLayoutControl1.GetEditor("MOBILE_PHONE").Value = acInfo.UserPhone;
            //acLayoutControl1.GetEditor("EMAIL").Value = acInfo.EmailAddr;

            acLayoutControl1.GetEditor("CHK_ADD1").Editor.Enabled = false;
            acLayoutControl1.GetEditor("CHK_ADD2").Editor.Enabled = false;
            acLayoutControl1.GetEditor("CHK_ADD3").Editor.Enabled = false;

            acLayoutControl1.GetEditor("SET_EMP").Value = acInfo.UserID;

            //승인자그룹 정보
            DataTable dtparam = new DataTable("RQSTDT");
            dtparam.Columns.Add("PLT_CODE", typeof(string));
            dtparam.Columns.Add("APP_TYPE", typeof(string));

            DataRow drparam = dtparam.NewRow();
            drparam["PLT_CODE"] = acInfo.PLT_CODE;
            drparam["APP_TYPE"] = "PUR";
            dtparam.Rows.Add(drparam);

            DataSet paramset = new DataSet();
            paramset.Tables.Add(dtparam);
            DataSet appResult = BizRun.QBizRun.ExecuteService(this, "ORD06A_SER3", paramset, "RQSTDT", "RSLTDT");
            DataTable data = appResult.Tables["RSLTDT"];
            leAppOrg.SetData("ORG_NAME", "ORG_CODE", data);


            base.DialogInit();
        }

        public override void DialogNew()
        {
            base.DialogNew();

            acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        
        public override void DialogOpen()
        {
            //열기

            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;

            acLayoutControl1.DataBind(linkRow, true);

            if (linkRow["INCL_VAT"].ToString() == "0")
            {
                acLayoutControl1.GetEditor("EXP_VAT").Value = "1";
            }

        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //저장 후 닫기


                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow output = acLayoutControl1.CreateParameterRow();

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(string));
                dtParam.Columns.Add("SET_ID", typeof(string));
                dtParam.Columns.Add("SET_EMP", typeof(string));
                dtParam.Columns.Add("INCL_VAT", typeof(string));
                dtParam.Columns.Add("SPLIT", typeof(string));
                dtParam.Columns.Add("DELIVERY_LOCATION", typeof(string));
                dtParam.Columns.Add("PAY_CONDITION", typeof(string));
                dtParam.Columns.Add("YPGO_CHARGE", typeof(string));
                dtParam.Columns.Add("CHK_MEASURE", typeof(string));
                dtParam.Columns.Add("CHK_PERFORM", typeof(string));
                dtParam.Columns.Add("CHK_ATTEND", typeof(string));
                dtParam.Columns.Add("CHK_TEST", typeof(string));
                dtParam.Columns.Add("CHK_MEEL", typeof(string));
                dtParam.Columns.Add("CHK_ADD1", typeof(string));
                dtParam.Columns.Add("CHK_ADD2", typeof(string));
                dtParam.Columns.Add("CHK_ADD3", typeof(string));
                dtParam.Columns.Add("CHARGE_EMP", typeof(string));
                dtParam.Columns.Add("CHARGE_PHONE", typeof(string));
                dtParam.Columns.Add("CHARGE_EMAIL", typeof(string));
                dtParam.Columns.Add("SCOMMENT", typeof(string));
                dtParam.Columns.Add("APP_ORG", typeof(string));

                dtParam.Columns.Add("CHK_RD", typeof(string));

                DataRow drParam = dtParam.NewRow();

                if (output["INCL_VAT"].ToString() == "0")
                {
                    drParam["INCL_VAT"] = "0";
                }
                else
                {
                    drParam["INCL_VAT"] = "1";
                }

                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["SET_ID"] = output["SET_ID"];
                drParam["SET_EMP"] = output["SET_EMP"];
                drParam["SPLIT"] = output["SPLIT"];
                drParam["DELIVERY_LOCATION"] = output["DELIVERY_LOCATION"];
                drParam["PAY_CONDITION"] = output["PAY_CONDITION"];
                drParam["YPGO_CHARGE"] = output["YPGO_CHARGE"];
                drParam["CHK_MEASURE"] = output["CHK_MEASURE"];
                drParam["CHK_PERFORM"] = output["CHK_PERFORM"];
                drParam["CHK_ATTEND"] = output["CHK_ATTEND"];
                drParam["CHK_TEST"] = output["CHK_TEST"];
                drParam["CHK_MEEL"] = output["CHK_MEEL"];
                drParam["CHK_ADD1"] = output["CHK_ADD1"];
                drParam["CHK_ADD2"] = output["CHK_ADD2"];
                drParam["CHK_ADD3"] = output["CHK_ADD3"];
                //drParam["CHARGE_EMP"] = output["EMP_NAME"];
                //drParam["CHARGE_PHONE"] = output["MOBILE_PHONE"];
                //drParam["CHARGE_EMAIL"] = output["EMAIL"];
                drParam["SCOMMENT"] = output["SCOMMENT"];
                drParam["APP_ORG"] = output["APP_ORG"];

                drParam["CHK_RD"] = output["CHK_RD"];

                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "PUR10A_INS", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz qBi, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();


                acLayoutControl1.GetEditor("SET_EMP").Value = acInfo.UserID;


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

            this.DialogResult = DialogResult.Cancel;
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //삭제
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("SET_ID", typeof(String)); //

                DataRow linkRow = (DataRow)_LinkData;

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["SET_ID"] = linkRow["SET_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "PUR10A_DEL", paramSet, "RQSTDT", "",
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

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);
            
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }


            DataRow output = acLayoutControl1.CreateParameterRow();

            DataTable dtParam = new DataTable("RQSTDT");
            dtParam.Columns.Add("PLT_CODE", typeof(string));
            dtParam.Columns.Add("SET_ID", typeof(string));
            dtParam.Columns.Add("SET_EMP", typeof(string));
            dtParam.Columns.Add("INCL_VAT", typeof(string));
            dtParam.Columns.Add("SPLIT", typeof(string));
            dtParam.Columns.Add("DELIVERY_LOCATION", typeof(string));
            dtParam.Columns.Add("PAY_CONDITION", typeof(string));
            dtParam.Columns.Add("YPGO_CHARGE", typeof(string));
            dtParam.Columns.Add("CHK_MEASURE", typeof(string));
            dtParam.Columns.Add("CHK_PERFORM", typeof(string));
            dtParam.Columns.Add("CHK_ATTEND", typeof(string));
            dtParam.Columns.Add("CHK_TEST", typeof(string));
            dtParam.Columns.Add("CHK_MEEL", typeof(string));
            dtParam.Columns.Add("CHK_ADD1", typeof(string));
            dtParam.Columns.Add("CHK_ADD2", typeof(string));
            dtParam.Columns.Add("CHK_ADD3", typeof(string));
            dtParam.Columns.Add("CHARGE_EMP", typeof(string));
            dtParam.Columns.Add("CHARGE_PHONE", typeof(string));
            dtParam.Columns.Add("CHARGE_EMAIL", typeof(string));
            dtParam.Columns.Add("SCOMMENT", typeof(string));


            DataRow drParam = dtParam.NewRow();

            if (output["INCL_VAT"].ToString() == "0")
            {
                drParam["INCL_VAT"] = "0";
            }
            else
            {
                drParam["INCL_VAT"] = "1";
            }

            drParam["PLT_CODE"] = acInfo.PLT_CODE;
            drParam["SET_ID"] = output["SET_ID"];
            drParam["SET_EMP"] = output["SET_EMP"];
            drParam["SPLIT"] = output["SPLIT"];
            drParam["DELIVERY_LOCATION"] = output["DELIVERY_LOCATION"];
            drParam["PAY_CONDITION"] = output["PAY_CONDITION"];
            drParam["YPGO_CHARGE"] = output["YPGO_CHARGE"];
            drParam["CHK_MEASURE"] = output["CHK_MEASURE"];
            drParam["CHK_PERFORM"] = output["CHK_PERFORM"];
            drParam["CHK_ATTEND"] = output["CHK_ATTEND"];
            drParam["CHK_TEST"] = output["CHK_TEST"];
            drParam["CHK_MEEL"] = output["CHK_MEEL"];
            drParam["CHK_ADD1"] = output["CHK_ADD1"];
            drParam["CHK_ADD2"] = output["CHK_ADD2"];
            drParam["CHK_ADD3"] = output["CHK_ADD3"];
            //drParam["CHARGE_EMP"] = output["EMP_NAME"];
            //drParam["CHARGE_PHONE"] = output["MOBILE_PHONE"];
            //drParam["CHARGE_EMAIL"] = output["EMAIL"];
            drParam["SCOMMENT"] = output["SCOMMENT"];
            dtParam.Rows.Add(drParam);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(dtParam);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "PUR10A_INS", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
        }


        void QuickSave2(object sender, QBiz qBi, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
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
    }
}

