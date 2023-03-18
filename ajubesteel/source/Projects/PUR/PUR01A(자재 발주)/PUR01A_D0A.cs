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
    public sealed partial class PUR01A_D0A : BaseMenuDialog
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

        private DataView _dv = null;
        private acGridView _linkView = null;
        private string _type = null;

        public PUR01A_D0A(DataView dv, acGridView linkView, string type)
        {
            InitializeComponent();

            _dv = dv;
            _linkView = linkView;
            _type = type;

            if (_type == "OS")
            {
                DataTable vndTable = _dv.ToTable(true, new string[] { "MAIN_VND" });

                if (vndTable.Rows.Count > 1)
                {
                    acAttachFileControl21.IsPurAttach = true;
                }
            }
            else
            {
                DataTable vndTable = _dv.ToTable(true, new string[] { "SUPP_VND" });

                if (vndTable.Rows.Count > 1)
                {
                    acAttachFileControl21.IsPurAttach = true;
                }
            }

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

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_MYVENDOR", paramSet, "RQSTDT", "RSLTDT");
            
            if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                DataRow drVendpr = resultSet.Tables["RSLTDT"].Rows[0];
                acLayoutControl1.GetEditor("VEN_NAME").Value = drVendpr["VEN_NAME"];
                acLayoutControl1.GetEditor("VEN_BIZ_NO").Value = drVendpr["VEN_BIZ_NO"];
                acLayoutControl1.GetEditor("VEN_CEO").Value = drVendpr["VEN_CEO"];
                acLayoutControl1.GetEditor("VEN_TEL").Value = drVendpr["VEN_TEL"];
                acLayoutControl1.GetEditor("VEN_FAX").Value = drVendpr["VEN_FAX"];
                acLayoutControl1.GetEditor("VEN_CONDITIONS").Value = acInfo.StdCodes.GetNameByCode("C017", drVendpr["VEN_CONDITIONS"].ToString());
                acLayoutControl1.GetEditor("VEN_PRODUCTS").Value = drVendpr["VEN_PRODUCTS"];
            }

            acLayoutControl1.GetEditor("EMP_NAME").Value = acInfo.UserName;
            acLayoutControl1.GetEditor("MOBILE_PHONE").Value = acInfo.UserPhone;
            acLayoutControl1.GetEditor("EMAIL").Value = acInfo.EmailAddr;

            acLayoutControl1.GetEditor("CHK_ADD1").Editor.Enabled = false;
            acLayoutControl1.GetEditor("CHK_ADD2").Editor.Enabled = false;
            acLayoutControl1.GetEditor("CHK_ADD3").Editor.Enabled = false;

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


            //발주 설정 정보 가져오기
            DataTable paramT = new DataTable("RQSTDT");
            paramT.Columns.Add("PLT_CODE", typeof(String));
            paramT.Columns.Add("SET_EMP", typeof(String));

            DataRow paramR = paramT.NewRow();
            paramR["PLT_CODE"] = acInfo.PLT_CODE;
            paramR["SET_EMP"] = acInfo.UserID;

            paramT.Rows.Add(paramR);
            DataSet paramSet2 = new DataSet();
            paramSet2.Tables.Add(paramT);

            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR10A_SER", paramSet2, "RQSTDT", "RSLTDT");

            if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
            {
                if (dsResult.Tables["RSLTDT"].Rows.Count == 1)
                {
                    acLayoutControl1.DataBind(dsResult.Tables["RSLTDT"].Rows[0], false);

                    if (dsResult.Tables["RSLTDT"].Rows[0]["INCL_VAT"].ToString() == "0")
                    {
                        acLayoutControl1.GetEditor("EXP_VAT").Value = "1";
                    }
                }
                else
                {

                    acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "자재 발주 정보", "자재 발주 정보가 여러 건 있습니다. 아래 중 선택하세요.", "", false, "자재 발주 정보",
                            dsResult.Tables["RSLTDT"]);

                    frm.View.GridType = acGridView.emGridType.FIXED;

                    frm.View.AddLookUpEmp("SET_EMP", "사용자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                    frm.View.AddTextEdit("SET_ID", "SETID", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddCheckEdit("INCL_VAT", "부가세포함", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddCheckEdit("SPLIT", "분할납품", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddTextEdit("PAY_CONDITION", "결제조건", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddTextEdit("DELIVERY_LOCATION", "납품장소", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddTextEdit("YPGO_CHARGE", "입고담당", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddCheckEdit("CHK_MEASURE", "치수검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddCheckEdit("CHK_PERFORM", "성능검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddCheckEdit("CHK_ATTEND", "입회검사", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddCheckEdit("CHK_TEST", "검사성적서", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                    frm.View.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);

                    frm.View.AddTextEdit("CHK_ADD1", "기타1", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddTextEdit("CHK_ADD2", "기타2", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddTextEdit("CHK_ADD3", "기타3", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                    frm.View.AddTextEdit("SCOMMENT", "특기사항", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        
                        DataRow selectedRow = frm.OutData as DataRow;
                        acLayoutControl1.DataBind(selectedRow, true);

                        if (selectedRow["INCL_VAT"].ToString() == "0")
                        {
                            acLayoutControl1.GetEditor("EXP_VAT").Value = "1";
                        }

                        if (selectedRow["CHK_ADD1"].ToString() != "")
                        {
                            acLayoutControl1.GetEditor("CHKBOX_ADD1").Value = "1";
                            acLayoutControl1.GetEditor("CHK_ADD1").Editor.Enabled = true;
                        }

                        if (selectedRow["CHK_ADD2"].ToString() != "")
                        {
                            acLayoutControl1.GetEditor("CHKBOX_ADD2").Value = "1";
                            acLayoutControl1.GetEditor("CHK_ADD2").Editor.Enabled = true;
                        }

                        if (selectedRow["CHK_ADD3"].ToString() != "")
                        {
                            acLayoutControl1.GetEditor("CHKBOX_ADD3").Value = "1";
                            acLayoutControl1.GetEditor("CHK_ADD3").Editor.Enabled = true;
                        }

                    }

                }
            }

            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                switch (_type)
                {
                    case "MAT":
                        {
                            DataTable vndTable = _dv.ToTable(true, new string[] { "SUPP_VND" });
                            vndTable.Columns.Add("PLT_CODE", typeof(string));
                            vndTable.Columns.Add("INCL_VAT", typeof(string));
                            vndTable.Columns.Add("SPLIT", typeof(string));
                            vndTable.Columns.Add("DELIVERY_LOCATION", typeof(string));
                            vndTable.Columns.Add("PAY_CONDITION", typeof(string));
                            vndTable.Columns.Add("YPGO_CHARGE", typeof(string));
                            vndTable.Columns.Add("CHK_MEASURE", typeof(string));
                            vndTable.Columns.Add("CHK_PERFORM", typeof(string));
                            vndTable.Columns.Add("CHK_ATTEND", typeof(string));
                            vndTable.Columns.Add("CHK_TEST", typeof(string));
                            vndTable.Columns.Add("CHK_MEEL", typeof(string));
                            vndTable.Columns.Add("CHK_ADD1", typeof(string));
                            vndTable.Columns.Add("CHK_ADD2", typeof(string));
                            vndTable.Columns.Add("CHK_ADD3", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMP", typeof(string));
                            vndTable.Columns.Add("CHARGE_PHONE", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMAIL", typeof(string));
                            vndTable.Columns.Add("SCOMMENT", typeof(string));
                            vndTable.Columns.Add("APP_ORG", typeof(string));
                            vndTable.Columns.Add("CHK_RD", typeof(string));

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(string));
                            paramTable.Columns.Add("PART_CODE", typeof(string));
                            paramTable.Columns.Add("DUE_DATE", typeof(string));
                            paramTable.Columns.Add("QTY", typeof(Int32));
                            paramTable.Columns.Add("UNIT_COST", typeof(decimal));
                            paramTable.Columns.Add("AMT", typeof(decimal));
                            paramTable.Columns.Add("SCOMMENT", typeof(string));
                            paramTable.Columns.Add("MVND_CODE", typeof(string));
                            paramTable.Columns.Add("BALJU_DATE", typeof(string));
                            paramTable.Columns.Add("INS_FLAG", typeof(string));
                            paramTable.Columns.Add("BAL_UNIT", typeof(string));
                            paramTable.Columns.Add("REAL_AMT", typeof(decimal));
                            paramTable.Columns.Add("BANK", typeof(string));
                            paramTable.Columns.Add("BANK_NO", typeof(string));

                            paramTable.Columns.Add("PUR_VEN_ACCOUNT", typeof(string));

                            foreach (DataRow dr in vndTable.Rows)
                            {

                                if (layoutRow["INCL_VAT"].ToString() == "0")
                                {
                                    dr["INCL_VAT"] = "0";
                                }
                                else
                                {
                                    dr["INCL_VAT"] = "1";
                                }

                                dr["PLT_CODE"] = acInfo.PLT_CODE;
                                dr["SPLIT"] = layoutRow["SPLIT"];
                                dr["DELIVERY_LOCATION"] = layoutRow["DELIVERY_LOCATION"];
                                dr["PAY_CONDITION"] = layoutRow["PAY_CONDITION"];
                                dr["YPGO_CHARGE"] = layoutRow["YPGO_CHARGE"];
                                dr["CHK_MEASURE"] = layoutRow["CHK_MEASURE"];
                                dr["CHK_PERFORM"] = layoutRow["CHK_PERFORM"];
                                dr["CHK_ATTEND"] = layoutRow["CHK_ATTEND"];
                                dr["CHK_TEST"] = layoutRow["CHK_TEST"];
                                dr["CHK_MEEL"] = layoutRow["CHK_MEEL"];
                                dr["CHK_ADD1"] = layoutRow["CHK_ADD1"];
                                dr["CHK_ADD2"] = layoutRow["CHK_ADD2"];
                                dr["CHK_ADD3"] = layoutRow["CHK_ADD3"];
                                dr["CHARGE_EMP"] = layoutRow["EMP_NAME"];
                                dr["CHARGE_PHONE"] = layoutRow["MOBILE_PHONE"];
                                dr["CHARGE_EMAIL"] = layoutRow["EMAIL"];
                                dr["SCOMMENT"] = layoutRow["SCOMMENT"];
                                dr["APP_ORG"] = layoutRow["APP_ORG"];
                                dr["CHK_RD"] = layoutRow["CHK_RD"];
                            }

                            foreach (DataRowView drv in _dv)
                            {
                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["PART_CODE"] = drv["PART_CODE"];
                                paramRow["DUE_DATE"] = drv["DUE_DATE"].toDateString("yyyyMMdd");
                                paramRow["QTY"] = drv["BAL_QTY"];
                                paramRow["UNIT_COST"] = drv["MAT_COST"];
                                paramRow["AMT"] = drv["MAT_AMT"];
                                paramRow["SCOMMENT"] = drv["BAL_SCOMMENT"];
                                paramRow["MVND_CODE"] = drv["SUPP_VND"];
                                paramRow["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                                paramRow["INS_FLAG"] = drv["INS_FLAG"];
                                paramRow["BAL_UNIT"] = drv["BAL_UNIT"];
                                paramRow["REAL_AMT"] = drv["REAL_AMT"];
                                paramRow["BANK"] = drv["BANK"];
                                paramRow["BANK_NO"] = drv["BANK_NO"];
                                paramRow["PUR_VEN_ACCOUNT"] = drv["VEN_ACCOUNT"];

                                paramTable.Rows.Add(paramRow);
                            }
                            vndTable.TableName = "RQSTDT_V";

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);
                            paramSet.Tables.Add(vndTable);

                            BizRun.QBizRun.ExecuteService(
                                    this, QBiz.emExecuteType.SAVE, "PUR01A_INS", paramSet, "RQSTDT_V,RQSTDT", "RSLTDT",
                                    QuickBalju,
                                    QuickException);
                        }
                        break;

                    case "PUR":
                        {
                            DataTable vndTable = _dv.ToTable(true, new string[] { "SUPP_VND" });

                            vndTable.Columns.Add("INCL_VAT", typeof(string));
                            vndTable.Columns.Add("SPLIT", typeof(string));
                            vndTable.Columns.Add("DELIVERY_LOCATION", typeof(string));
                            vndTable.Columns.Add("PAY_CONDITION", typeof(string));
                            vndTable.Columns.Add("YPGO_CHARGE", typeof(string));
                            vndTable.Columns.Add("CHK_MEASURE", typeof(string));
                            vndTable.Columns.Add("CHK_PERFORM", typeof(string));
                            vndTable.Columns.Add("CHK_ATTEND", typeof(string));
                            vndTable.Columns.Add("CHK_TEST", typeof(string));
                            vndTable.Columns.Add("CHK_MEEL", typeof(string));
                            vndTable.Columns.Add("CHK_ADD1", typeof(string));
                            vndTable.Columns.Add("CHK_ADD2", typeof(string));
                            vndTable.Columns.Add("CHK_ADD3", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMP", typeof(string));
                            vndTable.Columns.Add("CHARGE_PHONE", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMAIL", typeof(string));
                            vndTable.Columns.Add("SCOMMENT", typeof(string));
                            vndTable.Columns.Add("APP_ORG", typeof(string));
                            vndTable.Columns.Add("CHK_RD", typeof(string));

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(string));
                            paramTable.Columns.Add("PART_CODE", typeof(string));
                            paramTable.Columns.Add("DUE_DATE", typeof(string));
                            paramTable.Columns.Add("QTY", typeof(Int32));
                            paramTable.Columns.Add("UNIT_COST", typeof(decimal));
                            paramTable.Columns.Add("AMT", typeof(decimal));
                            paramTable.Columns.Add("SCOMMENT", typeof(string));
                            paramTable.Columns.Add("MVND_CODE", typeof(string));
                            paramTable.Columns.Add("BALJU_DATE", typeof(string));
                            paramTable.Columns.Add("BAL_UNIT", typeof(string));
                            paramTable.Columns.Add("REAL_AMT", typeof(decimal));
                            paramTable.Columns.Add("BANK", typeof(string));
                            paramTable.Columns.Add("BANK_NO", typeof(string));
                            paramTable.Columns.Add("DETAIL_PART_NAME", typeof(string));

                            paramTable.Columns.Add("PUR_VEN_ACCOUNT", typeof(string));

                            foreach (DataRow dr in vndTable.Rows)
                            {

                                if (layoutRow["INCL_VAT"].ToString() == "0")
                                {
                                    dr["INCL_VAT"] = "0";
                                }
                                else
                                {
                                    dr["INCL_VAT"] = "1";
                                }


                                dr["SPLIT"] = layoutRow["SPLIT"];
                                dr["DELIVERY_LOCATION"] = layoutRow["DELIVERY_LOCATION"];
                                dr["PAY_CONDITION"] = layoutRow["PAY_CONDITION"];
                                dr["YPGO_CHARGE"] = layoutRow["YPGO_CHARGE"];
                                dr["CHK_MEASURE"] = layoutRow["CHK_MEASURE"];
                                dr["CHK_PERFORM"] = layoutRow["CHK_PERFORM"];
                                dr["CHK_ATTEND"] = layoutRow["CHK_ATTEND"];
                                dr["CHK_TEST"] = layoutRow["CHK_TEST"];
                                dr["CHK_MEEL"] = layoutRow["CHK_MEEL"];
                                dr["CHK_ADD1"] = layoutRow["CHK_ADD1"];
                                dr["CHK_ADD2"] = layoutRow["CHK_ADD2"];
                                dr["CHK_ADD3"] = layoutRow["CHK_ADD3"];
                                dr["CHARGE_EMP"] = layoutRow["EMP_NAME"];
                                dr["CHARGE_PHONE"] = layoutRow["MOBILE_PHONE"];
                                dr["CHARGE_EMAIL"] = layoutRow["EMAIL"];
                                dr["SCOMMENT"] = layoutRow["SCOMMENT"];
                                dr["APP_ORG"] = layoutRow["APP_ORG"];
                                dr["CHK_RD"] = layoutRow["CHK_RD"];

                            }

                            foreach (DataRowView drv in _dv)
                            {
                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["PART_CODE"] = drv["PART_CODE"];
                                paramRow["DUE_DATE"] = drv["DUE_DATE"].toDateString("yyyyMMdd");
                                paramRow["QTY"] = drv["BAL_QTY"];
                                paramRow["UNIT_COST"] = drv["MAT_COST"];
                                paramRow["AMT"] = drv["MAT_AMT"];
                                paramRow["SCOMMENT"] = drv["BAL_SCOMMENT"];
                                paramRow["MVND_CODE"] = drv["SUPP_VND"];
                                paramRow["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                                paramRow["BAL_UNIT"] = drv["BAL_UNIT"];
                                paramRow["REAL_AMT"] = drv["REAL_AMT"];
                                paramRow["BANK"] = drv["BANK"];
                                paramRow["BANK_NO"] = drv["BANK_NO"];
                                paramRow["DETAIL_PART_NAME"] = drv["DETAIL_PART_NAME"];
                                paramRow["PUR_VEN_ACCOUNT"] = drv["VEN_ACCOUNT"];

                                paramTable.Rows.Add(paramRow);
                            }
                            vndTable.TableName = "RQSTDT_V";

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);
                            paramSet.Tables.Add(vndTable);

                            BizRun.QBizRun.ExecuteService(
                                    this, QBiz.emExecuteType.SAVE, "PUR02A_INS", paramSet, "RQSTDT_V,RQSTDT", "RSLTDT",
                                    QuickBalju2,
                                    QuickException);
                        }
                        break;

                    case "OS":
                        {
                            DataTable vndTable = _dv.ToTable(true, new string[] { "PLT_CODE", "MAIN_VND" });
                            vndTable.Columns.Add("INCL_VAT", typeof(string));
                            vndTable.Columns.Add("SPLIT", typeof(string));
                            vndTable.Columns.Add("DELIVERY_LOCATION", typeof(string));
                            vndTable.Columns.Add("PAY_CONDITION", typeof(string));
                            vndTable.Columns.Add("YPGO_CHARGE", typeof(string));
                            vndTable.Columns.Add("CHK_MEASURE", typeof(string));
                            vndTable.Columns.Add("CHK_PERFORM", typeof(string));
                            vndTable.Columns.Add("CHK_ATTEND", typeof(string));
                            vndTable.Columns.Add("CHK_TEST", typeof(string));
                            vndTable.Columns.Add("CHK_MEEL", typeof(string));
                            vndTable.Columns.Add("CHK_ADD1", typeof(string));
                            vndTable.Columns.Add("CHK_ADD2", typeof(string));
                            vndTable.Columns.Add("CHK_ADD3", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMP", typeof(string));
                            vndTable.Columns.Add("CHARGE_PHONE", typeof(string));
                            vndTable.Columns.Add("CHARGE_EMAIL", typeof(string));
                            vndTable.Columns.Add("SCOMMENT", typeof(string));
                            vndTable.Columns.Add("APP_ORG", typeof(string));
                            vndTable.Columns.Add("CHK_RD", typeof(string));


                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(string));
                            paramTable.Columns.Add("WO_NO", typeof(string));
                            paramTable.Columns.Add("DUE_DATE", typeof(string));
                            paramTable.Columns.Add("QTY", typeof(Int32));
                            paramTable.Columns.Add("UNIT_COST", typeof(decimal));
                            paramTable.Columns.Add("AMT", typeof(decimal));
                            paramTable.Columns.Add("SCOMMENT", typeof(string));
                            paramTable.Columns.Add("OVND_CODE", typeof(string));
                            paramTable.Columns.Add("BALJU_DATE", typeof(string));
                            paramTable.Columns.Add("INS_FLAG", typeof(string));
                            paramTable.Columns.Add("BAL_UNIT", typeof(string));
                            paramTable.Columns.Add("REAL_AMT", typeof(decimal));
                            paramTable.Columns.Add("BANK", typeof(string));
                            paramTable.Columns.Add("BANK_NO", typeof(string));

                            foreach (DataRow dr in vndTable.Rows)
                            {

                                if (layoutRow["INCL_VAT"].ToString() == "0")
                                {
                                    dr["INCL_VAT"] = "0";
                                }
                                else
                                {
                                    dr["INCL_VAT"] = "1";
                                }


                                dr["SPLIT"] = layoutRow["SPLIT"];
                                dr["DELIVERY_LOCATION"] = layoutRow["DELIVERY_LOCATION"];
                                dr["PAY_CONDITION"] = layoutRow["PAY_CONDITION"];
                                dr["YPGO_CHARGE"] = layoutRow["YPGO_CHARGE"];
                                dr["CHK_MEASURE"] = layoutRow["CHK_MEASURE"];
                                dr["CHK_PERFORM"] = layoutRow["CHK_PERFORM"];
                                dr["CHK_ATTEND"] = layoutRow["CHK_ATTEND"];
                                dr["CHK_TEST"] = layoutRow["CHK_TEST"];
                                dr["CHK_MEEL"] = layoutRow["CHK_MEEL"];
                                dr["CHK_ADD1"] = layoutRow["CHK_ADD1"];
                                dr["CHK_ADD2"] = layoutRow["CHK_ADD2"];
                                dr["CHK_ADD3"] = layoutRow["CHK_ADD3"];
                                dr["CHARGE_EMP"] = layoutRow["EMP_NAME"];
                                dr["CHARGE_PHONE"] = layoutRow["MOBILE_PHONE"];
                                dr["CHARGE_EMAIL"] = layoutRow["EMAIL"];
                                dr["SCOMMENT"] = layoutRow["SCOMMENT"];
                                dr["APP_ORG"] = layoutRow["APP_ORG"];
                                dr["CHK_RD"] = layoutRow["CHK_RD"];
                            }


                            foreach (DataRowView drv in _dv)
                            {
                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["WO_NO"] = drv["WO_NO"];
                                paramRow["DUE_DATE"] = drv["DUE_DATE"].toDateString("yyyyMMdd");
                                paramRow["QTY"] = drv["PART_QTY"];
                                paramRow["UNIT_COST"] = drv["PROC_COST"];
                                paramRow["AMT"] = drv["PROC_AMT"];
                                paramRow["SCOMMENT"] = drv["SCOMMENT"];
                                paramRow["OVND_CODE"] = drv["MAIN_VND"];
                                paramRow["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                                paramRow["INS_FLAG"] = drv["INS_FLAG"];
                                paramRow["BAL_UNIT"] = drv["BAL_UNIT"];
                                paramRow["REAL_AMT"] = drv["REAL_AMT"];
                                paramRow["BANK"] = drv["BANK"];
                                paramRow["BANK_NO"] = drv["BANK_NO"];

                                paramTable.Rows.Add(paramRow);
                            }

                            vndTable.TableName = "RQSTDT_V";

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);
                            paramSet.Tables.Add(vndTable);

                            BizRun.QBizRun.ExecuteService(
                                    this, QBiz.emExecuteType.SAVE, "PUR03A_INS", paramSet, "RQSTDT_V,RQSTDT", "RSLTDT",
                                    QuickBalju3,
                                    QuickException);
                        }
                        break;
                }

                //base.OutputData = acLayoutControl1.CreateParameterRow();

                //this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickBalju(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 후
            try
            {
                if (!acAttachFileControl21.IsPurAttach)
                {
                    acAttachFileControl21.LinkKey = e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR" };
                    acAttachFileControl21.UploadFile();

                    this.ControlBox = false;
                    acBarButtonItem1.Enabled = false;
                    System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                    closeTh.Start();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }

                _linkView.ClearRow();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickBalju2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 후
            try
            {
                if (!acAttachFileControl21.IsPurAttach)
                {
                    acAttachFileControl21.LinkKey = e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR" };
                    acAttachFileControl21.UploadFile();

                    this.ControlBox = false;
                    acBarButtonItem1.Enabled = false;
                    System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                    closeTh.Start();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }

                _linkView.ClearRow();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickBalju3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            //자재발주 후
            try
            {
                if (!acAttachFileControl21.IsPurAttach)
                {
                    acAttachFileControl21.LinkKey = e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR";
                    acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RQSTDT_BALJU"].Rows[0]["BALJU_NUM"].ToString() + "_PUR" };
                    acAttachFileControl21.UploadFile();

                    this.ControlBox = false;
                    acBarButtonItem1.Enabled = false;
                    System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                    closeTh.Start();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }

                _linkView.ClearRow();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void formClose()
        {
            while (true)
            {
                if (acAttachFileControl21.isComplete == true)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }

            if (acAttachFileControl21.isComplete == true)
            {
                this.Invoke(new MethodInvoker(end));
            }
        }

        void end()
        {
            this.DialogResult = DialogResult.OK;
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acLayoutControl1.ClearValue(false);

            acLayoutControl1.GetEditor("EMP_NAME").Value = acInfo.UserName;
            acLayoutControl1.GetEditor("MOBILE_PHONE").Value = acInfo.UserPhone;
            acLayoutControl1.GetEditor("EMAIL").Value = acInfo.EmailAddr;

        }
    }
}

