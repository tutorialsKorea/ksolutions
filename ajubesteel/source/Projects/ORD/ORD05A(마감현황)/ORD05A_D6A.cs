using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;
using BizManager;
using DevExpress.XtraEditors.Popup;

namespace ORD
{
    public sealed partial class ORD05A_D6A : BaseMenuDialog
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

        private DataTable editedBom = null;
        private DataTable editedDelBom = null;

        private DataTable tempEditBom = null;

        private string _OldProdCode = string.Empty;


        public ORD05A_D6A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;


        }


        public override void DialogInit()
        {



            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



            acLayoutControl1.KeyColumns = new string[] { "PROD_CODE" };
            

            //DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD02A_MODEL","RQSTDT", "RSLTDT_T,RSLTDT_M");


            //모델구분
            //(acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt.Tables["RSLTDT_T"]);

            //(acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "MODEL_CODE", dsRslt.Tables["RSLTDT_M"]);

            //우선순위
            (acLayoutControl1.GetEditor("PROD_PRIORITY").Editor as acLookupEdit).SetCode("P028");
            //수주상태
            (acLayoutControl1.GetEditor("PROD_KIND").Editor as acLookupEdit).SetCode("C011");
            //수주상태
            (acLayoutControl1.GetEditor("PROD_STATE").Editor as acLookupEdit).SetCode("P012");
            //공정구분
            (acLayoutControl1.GetEditor("PROC_TYPE").Editor as acLookupEdit).SetCode("P017");
            //공정명
            (acLayoutControl1.GetEditor("PROC_FLAG").Editor as acLookupEdit).SetCode("P005");
            //유형
            (acLayoutControl1.GetEditor("PROD_FLAG").Editor as acLookupEdit).SetCode("P006");
            //성적서
            (acLayoutControl1.GetEditor("INS_YN").Editor as acLookupEdit).SetCode("P007");
            //소켓측정
            //(acLayoutControl1.GetEditor("SOCKET_YN").Editor as acLookupEdit).SetCode("P007");
            //제품분류
            (acLayoutControl1.GetEditor("PROD_TYPE").Editor as acLookupEdit).SetCode("P010");
            //제품유형
            //(acLayoutControl1.GetEditor("PROD_CATEGORY").Editor as acCheckedComboBoxEdit).AddItem("P009", 0, 1, CheckState.Unchecked);
            (acLayoutControl1.GetEditor("PROD_CATEGORY").Editor as acLookupEdit).SetCode("P009");

            //발주구분
            (acLayoutControl1.GetEditor("BALJU_TYPE").Editor as acLookupEdit).SetCode("P029");

            //액츄에이터유무
            (acLayoutControl1.GetEditor("ACTUATOR_YN").Editor as acLookupEdit).SetCode("S101");
            //프로브인
            //(acLayoutControl1.GetEditor("PROBE_PIN").Editor as acCheckedComboBoxEdit).AddItem("P011",0,1, CheckState.Unchecked);
            (acLayoutControl1.GetEditor("PIN_TYPE").Editor as acLookupEdit).SetCode("P011");

            //통화
            (acLayoutControl1.GetEditor("CURR_UNIT").Editor as acLookupEdit).SetCode("P008");
            //거레명세
            (acLayoutControl1.GetEditor("TRADE_YN").Editor as acLookupEdit).SetCode("P007");
            //세금
            (acLayoutControl1.GetEditor("TAX_YN").Editor as acLookupEdit).SetCode("P007");
            //수금
            (acLayoutControl1.GetEditor("BILL_YN").Editor as acLookupEdit).SetCode("P007");

            //모듈타입
            (acLayoutControl1.GetEditor("MODULE_TYPE").Editor as acLookupEdit).SetCode("P018");
            //핀타입
            //(acLayoutControl1.GetEditor("PIN_TYPE").Editor as acLookupEdit).SetCode("P019");
            //화상타입
            (acLayoutControl1.GetEditor("VISION_TYPE").Editor as acLookupEdit).SetCode("P020");
            //화상방향
            (acLayoutControl1.GetEditor("VISION_DIRECTION").Editor as acLookupEdit).SetCode("S102");
            //(acLayoutControl1.GetEditor("VISION_DIRECTION").Editor as acCheckedComboBoxEdit).AddItem("S102", 0, 1, CheckState.Unchecked);            
            //(acLayoutControl1.GetEditor("CLAMP_DIRECTION").Editor as acCheckedComboBoxEdit).AddItem("S102", 0, 1, CheckState.Unchecked);
            //(acLayoutControl1.GetEditor("CONNECTOR_DIRECTION").Editor as acCheckedComboBoxEdit).AddItem("S102", 0, 1, CheckState.Unchecked);
            //(acLayoutControl1.GetEditor("OPEN_DIRECTION").Editor as acCheckedComboBoxEdit).AddItem("S102", 0, 1, CheckState.Unchecked);
            //GND_PIN
            (acLayoutControl1.GetEditor("GND_PIN").Editor as acLookupEdit).SetCode("S100");
            //FIDUCIAL_MARK
            (acLayoutControl1.GetEditor("FIDUCIAL_MARK").Editor as acLookupEdit).SetCode("S100");
            //십자
            (acLayoutControl1.GetEditor("CROSS_MARKING").Editor as acLookupEdit).SetCode("S100");
            //vacuum
            (acLayoutControl1.GetEditor("VACUUM").Editor as acLookupEdit).SetCode("S100");
            //모듈 안착 타입
            (acLayoutControl1.GetEditor("MODULE_IN_TYPE").Editor as acLookupEdit).SetCode("P021");
            //모듈 안착 타입
            (acLayoutControl1.GetEditor("IF_PIN_BLOCK").Editor as acLookupEdit).SetCode("S100");
            //SOCKET_OPEN_DIRECTION
            (acLayoutControl1.GetEditor("SOCKET_OPEN_DIRECTION").Editor as acLookupEdit).SetCode("P022");

            //(acLayoutControl1.GetEditor("MSOP_DFM").Editor as acLookupEdit).SetCode("P023");
            //(acLayoutControl1.GetEditor("MSOP_DFM").Editor as acCheckedComboBoxEdit).AddItem("P023", 0, 1, CheckState.Unchecked);
            (acLayoutControl1.GetEditor("MSOP_YN").Editor as acLookupEdit).SetCode("S105");
            (acLayoutControl1.GetEditor("DFM_YN").Editor as acLookupEdit).SetCode("S105");




            //도면 타입
            //(acLayoutControl1.GetEditor("DRAW_TYPE").Editor as acLookupEdit).SetCode("P024");
            (acLayoutControl1.GetEditor("DRAW_TYPE").Editor as acCheckedComboBoxEdit).AddItem("P024", 0, 1, CheckState.Unchecked);

            //(acLayoutControl1.GetEditor("PART_CODE").Editor as acPart).Filter = "Actuator";
            (acLayoutControl1.GetEditor("PART_CODE").Editor as acPart).MAT_LTYPE = "22";
            (acLayoutControl1.GetEditor("PART_CODE").Editor as acPart).MAT_MTYPE = "21";

            (acLayoutControl1.GetEditor("ITEM_FLAG").Editor as acLookupEdit).SetCode("P027");

            acLayoutControl1.GetEditor("MNG_EMP1").Value = acInfo.UserID;

            (acLayoutControl1.GetEditor("CVND_CODE").Editor as acLookupEdit).SetData("VEN_NAME", "VEN_CODE", "ORD02A_SER6");

            (acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).KeyDown += MODEL_TYPE_KeyDown;

            (acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).KeyDown += MODEL_CODE_KeyDown;

            (acLayoutControl1.GetEditor("CVND_CODE").Editor as acLookupEdit).KeyDown += CVND_CODE_KeyDown;

            acCheckEdit1.Checked = true;


            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.GetEditor("PROD_TYPE").Editor.TextChanged += Editor_TextChanged;
            // 원래 OnvalueChanged 이벤트에서 처리했으나, 복사할 수주 선택 이후 다시 바인딩하는 과정에서 이벤트가 먹지 않아 text_changed로 처리

            acMemoEdit2.Properties.MaxLength = 120;

            base.DialogInit();

        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            acLookupEdit acLookup = sender as acLookupEdit;

            if (acLayoutControl1.GetEditor("PROD_FLAG").Value.isNullOrEmpty()) { return; }

            string prodFlag = acLayoutControl1.GetEditor("PROD_FLAG").Value.ToString();

            //if (prodFlag == "RE" &&  acLookup.Value.toInt() > 0 && acLookup.Value.toInt() < 9)
            //if (prodFlag == "RE" && acLookup.Value.toInt() < 9)
            //{
            //    btnBom.Enabled = true;
            //}
            //else
            //{
            //    btnBom.Enabled = false;
            //}
        }

        private void MODEL_TYPE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LookUpEdit edit = sender as LookUpEdit;
                PopupLookUpEditForm popup = edit.GetPopupEditForm();

                if (popup == null) return;

                if (popup.Filter.RowCount == 1)
                {
                    edit.ItemIndex = 0;
                    var value = edit.GetColumnValue(edit.Properties.ValueMember);
                    edit.ClosePopup();
                    edit.EditValue = value;
                }
                else if(popup.SelectedIndex < 0)
                {
                    string text = edit.Text;
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                    ORD02A_D4A frm = new ORD02A_D4A(layoutRow, ORD02A_D4A.GridType.Model, text);

                    frm.ParentControl = this;
                    frm.Text = "대분류";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = (DataRow)frm.OutputData;

                        acLayoutControl1.GetEditor("MODEL_TYPE").Value = frmRow["SCODE"].ToString();
                    }
                }
            }
        }

        private void MODEL_CODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LookUpEdit edit = sender as LookUpEdit;
                PopupLookUpEditForm popup = edit.GetPopupEditForm();

                if (popup == null) return;

                if (popup.Filter.RowCount == 1)
                {
                    edit.ItemIndex = 0;
                    var value = edit.GetColumnValue(edit.Properties.ValueMember);
                    edit.ClosePopup();
                    edit.EditValue = value;
                }
                else if (popup.SelectedIndex < 0)
                {
                    string text = edit.Text;
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                    ORD02A_D4A frm = new ORD02A_D4A(layoutRow, ORD02A_D4A.GridType.DetailModel, text);

                    frm.ParentControl = this;
                    frm.Text = "중분류";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = (DataRow)frm.OutputData;

                        acLayoutControl1.GetEditor("MODEL_CODE").Value = frmRow["SCODE"].ToString();
                    }
                }
            }
        }

        private void CVND_CODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LookUpEdit edit = sender as LookUpEdit;
                PopupLookUpEditForm popup = edit.GetPopupEditForm();

                if (popup == null) return;

                if (popup.Filter.RowCount == 1)
                {
                    edit.ItemIndex = 0;
                    var value = edit.GetColumnValue(edit.Properties.ValueMember);
                    edit.ClosePopup();
                    edit.EditValue = value;
                }
                else if (popup.SelectedIndex < 0)
                {
                    string text = edit.Text;
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                    ORD02A_D4A frm = new ORD02A_D4A(layoutRow, ORD02A_D4A.GridType.Vendor, text);

                    frm.ParentControl = this;
                    frm.Text = "발주처";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = (DataRow)frm.OutputData;

                        acLayoutControl1.GetEditor("CVND_CODE").Value = frmRow["VEN_CODE"].ToString();
                    }
                }
            }
        }

        int _ven_charge_id = 0;

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "PROD_QTY":

                    if (layout.GetEditor("AUTO_CAL").Value.toBoolean() == true)
                    {
                        if (layout.GetEditor("PROD_AMT").Value.toDecimal() == 0 || newValue.toDecimal() == 0)
                        {
                            layout.GetEditor("PROD_COST").Value = 0;
                            return;
                        }

                        layout.GetEditor("PROD_COST").Value = layout.GetEditor("PROD_AMT").Value.toDecimal() / newValue.toDecimal();
                    }
                    else
                    {
                        decimal cost = layout.GetEditor("PROD_COST").Value.toDecimal();

                        layout.GetEditor("PROD_AMT").Value = cost * newValue.toDecimal();
                    }

                    break;

                case "PROD_COST":

                    decimal qty = layout.GetEditor("PROD_QTY").Value.toDecimal();

                    layout.GetEditor("PROD_AMT").Value = qty * newValue.toDecimal();

                    break;

                case "PROD_AMT":

                    if (layout.GetEditor("AUTO_CAL").Value.toBoolean() == true)
                    {
                        if (newValue.toDecimal() == 0 || layout.GetEditor("PROD_QTY").Value.toDecimal() == 0) 
                        {
                            layout.GetEditor("PROD_COST").Value = 0;
                            return; 
                        }
                        layout.GetEditor("PROD_COST").Value = newValue.toDecimal() / layout.GetEditor("PROD_QTY").Value.toDecimal();
                    }
                    break;

                case "PROD_FLAG":

                    if (newValue == null) return;

                    DataRow linkRow = _LinkData as DataRow;

                    if (newValue.Equals("RE") && this.DialogMode == emDialogMode.NEW)
                    {

                        if (acMessageBox.Show(this, "수주를 선택 후 복사하시겠습니까?", "", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                        {
                            acLayoutControl1.GetEditor("PROD_FLAG").Value = "NE";

                            #region 필수정보 읽기전용해제
                            acLayoutControl1.GetEditor("CVND_CODE").isReadyOnly = false;
                            acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = false;
                            acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROD_KIND").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROD_FLAG").isReadyOnly = false;
                            #endregion

                            return;
                        }

                        ORD02A_D3A frm = new ORD02A_D3A();

                        frm.ParentControl = this;

                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            DataRow outputRow = frm.OutputData as DataRow;

                            outputRow["PROD_STATE"] = "6";
                            outputRow["PROD_FLAG"] = "RE";

                            this.acLayoutControl1.OnValueChanged -= new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

                            #region 다이얼로그 대분류, 중분류 설정
                            DataTable dtScode = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                                      , ExtensionMethods.GetCubizParam("VEN_CODE:" + outputRow["CVND_CODE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                            string scode2 = "0";
                            if (dtScode.Rows.Count > 0) { scode2 = dtScode.Rows[0]["SCODE"].ToString(); }

                            DataTable dtType = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                               , ExtensionMethods.GetCubizParam("P_SCODE:" + scode2), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                            (acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dtType);


                            DataTable dsRslt2 = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                                       , ExtensionMethods.GetCubizParam("P_SCODE:" + outputRow["MODEL_TYPE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                            (acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt2);

                            #endregion

                            //outputRow["PROD_QTY"] = DBNull.Value;

                            acLayoutControl1.DataBind(outputRow, true);

                            acLayoutControl1.GetEditor("PROD_QTY").Value = DBNull.Value;

                            // 영업담당자
                            DataTable dtChargeRslt = BizRun.QBizRun.ExecuteService(this, "ORD02A_VEN_CHARGE"
                                , ExtensionMethods.GetCubizParam("VEN_CODE:" + layout.GetEditor("CVND_CODE").Value.ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                            DataTable dtVenCharge = dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").CopyToDataTable() : null;
                            DataTable dtVenDesign = dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").CopyToDataTable() : null;

                            (layout.GetEditor("CUSTOMER_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenCharge);
                            (layout.GetEditor("CUSTDESIGN_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenDesign);

                            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

                            acLayoutControl1.GetEditor("PROD_CODE").Value = null;

                            _OldProdCode = outputRow["PROD_CODE"].ToString();

                            #region 필수정보 읽기전용으로 설정
                            //acLayoutControl1.GetEditor("CVND_CODE").isReadyOnly = true;
                            //acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = true;
                            //acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = true;
                            //acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = true;
                            acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = true;
                            acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = true;
                            acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = true;
                            acLayoutControl1.GetEditor("PROD_KIND").isReadyOnly = false;
                            acLayoutControl1.GetEditor("PROD_FLAG").isReadyOnly = true;
                            #endregion

                            //(acLayoutControl1.GetEditor("PROD_KIND").Editor as acLookupEdit).SetCode("C011", new string[] { "IE", "SK" });
                        }
                    }
                    else if (newValue.Equals("RE") && this.DialogMode == emDialogMode.OPEN)
                    {       
                        //등록 상태일때만 가능하게
                        //확정일때? 확인필요
                        if (linkRow["BOM_FLAG"].ToString() != "1" 
                            && (linkRow["PROD_STATE"].ToString() == "6"
                                || linkRow["PROD_STATE"].ToString() == "7"))
                        {
                            ORD02A_D3A frm = new ORD02A_D3A();

                            frm.ParentControl = this;

                            if (frm.ShowDialog(this) == DialogResult.OK)
                            {
                                DataRow outputRow = frm.OutputData as DataRow;

                                _OldProdCode = outputRow["PROD_CODE"].ToString();
                                //(acLayoutControl1.GetEditor("PROD_KIND").Editor as acLookupEdit).SetCode("C011", new string[] { "IE", "SK" });
                            }
                        }
                    }
                    else
                    {
                        #region 필수정보 읽기전용해제
                        acLayoutControl1.GetEditor("CVND_CODE").isReadyOnly = false;
                        acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = false;
                        acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROD_KIND").isReadyOnly = false;
                        acLayoutControl1.GetEditor("PROD_FLAG").isReadyOnly = false;
                        #endregion

                        // 유형이 Repeat이 아닌 경우 BOM 관리버튼 비활성화
                        //btnBom.Enabled = false;

                    }

                    if (!newValue.Equals("RE") && layout.GetEditor("PROD_CODE").Value.toStringEmpty() == "")
                    {
                        btnBom.Enabled = false;
                    }
                    else
                    {
                        btnBom.Enabled = true;
                    }

                    if (linkRow != null)
                    {
                        if (!newValue.Equals("RE") && linkRow["BOM_FLAG"].ToString() != "1")
                        {
                            _OldProdCode = String.Empty;
                            tempEditBom = null;
                            editedBom = null;
                            editedDelBom = null;
                        }
                    }

                    break;


                case "MODEL_TYPE":

                    //(layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", new DataTable());
                    //(layout.GetEditor("PROD_NAME").Editor as acTextEdit).Text = "";

                    (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Value = null;
                    (layout.GetEditor("PROD_NAME").Editor as acTextEdit).Value = null;

                    string value = (string)newValue;

                    if (value.isNullOrEmpty()) { value = "EMPTY"; } // newValue가 Null인 경우 전체조회하는 문제로 추가.
                  

                    DataTable dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                        , ExtensionMethods.GetCubizParam("P_SCODE:" + value), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt);

                    //DataSet dsParam = ExtensionMethods.GetCubizParam(string.Format("P_SCODE:{0}",newValue));
                    //DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_MODEL", dsParam,"RQSTDT", "RSLTDT_T,RSLTDT_M");
                    //(acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt.Tables["RSLTDT_M"]);

                    break;

                case "MODEL_CODE":
                  
                    if ((layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text != "")
                    {
                        layout.GetEditor("PROD_NAME").Value = (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).Text + "-" + (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text + "-";
                        //layout.GetEditor("PROD_NAME").Value = (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).Text + "-" + (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text + "-" + layout.GetEditor("PROD_VERSION").Value.toStringEmpty();
                    }
                  
                    break;

                //case "PROD_VERSION":

                //    if ((layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text != "")
                //    {
                //        //layout.GetEditor("PROD_NAME").Value = (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).Text + "-" + (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text + "-";
                //        layout.GetEditor("PROD_NAME").Value = (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).Text + "-" + (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Text + "-" + layout.GetEditor("PROD_VERSION").Value.toStringEmpty();
                //    }

                //    break;

                case "CURR_UNIT":
                    if(!this._IsOpen)
                        layout.GetEditor("ORD_VAT").Value = "0";

                    if(layout.GetEditor("CURR_UNIT").Value.ToString() == "1")
                    {
                        (layout.GetEditor("PROD_COST") as acTextEdit).MaskType = acTextEdit.emMaskType.F2;
                        (layout.GetEditor("PROD_AMT") as acTextEdit).MaskType = acTextEdit.emMaskType.F2;

                        (layout.GetEditor("PROD_COST") as acTextEdit).Refresh();
                        (layout.GetEditor("PROD_AMT") as acTextEdit).Refresh();

                    }
                    else
                    {
                        (layout.GetEditor("PROD_COST") as acTextEdit).MaskType = acTextEdit.emMaskType.MONEY;
                        (layout.GetEditor("PROD_AMT") as acTextEdit).MaskType = acTextEdit.emMaskType.MONEY;

                        layout.GetEditor("PROD_COST").Value = Math.Truncate(layout.GetEditor("PROD_COST").Value.toDecimal());
                        layout.GetEditor("PROD_AMT").Value = Math.Truncate(layout.GetEditor("PROD_AMT").Value.toDecimal());

                        (layout.GetEditor("PROD_COST") as acTextEdit).Refresh();
                        (layout.GetEditor("PROD_AMT") as acTextEdit).Refresh();
                    }

                    break;

                case "ACTUATOR_YN":
                    if (!newValue.isNullOrEmpty() && ((string)newValue == "1" || (string)newValue == "3"))
                    {
                        layout.GetEditor("PART_CODE").isReadyOnly = false;
                    }
                    else
                    {
                        layout.GetEditor("PART_CODE").isReadyOnly = true;
                        layout.GetEditor("PART_CODE").Value = null;
                    }
                    break;

                case "CVND_CODE":

                    // 거래처 선택 or 변경 시 (중분류,모델명 초기화)

                    //(layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", new DataTable());
                    //(layout.GetEditor("PROD_NAME").Editor as acTextEdit).Text = "";

                    (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).Value = null;
                    (layout.GetEditor("MODEL_CODE").Editor as acLookupEdit).Value = null;
                    (layout.GetEditor("PROD_NAME").Editor as acTextEdit).Value = null;


                    DataTable dtRsltScode = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                        , ExtensionMethods.GetCubizParam("VEN_CODE:" + (string)newValue), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    string scode = "0";
                    if (dtRsltScode.Rows.Count > 0) { scode = dtRsltScode.Rows[0]["SCODE"].ToString(); }

                    DataTable dtRsltType = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                       , ExtensionMethods.GetCubizParam("P_SCODE:" + scode), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    (layout.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dtRsltType);


                    // 영업담당자
                    DataTable dtRslt = BizRun.QBizRun.ExecuteService(this,"ORD02A_VEN_CHARGE"
                        , ExtensionMethods.GetCubizParam("VEN_CODE:"+(string)newValue), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    //DataTable dtCharge = dtRslt.Select("CHARGE_GUBUN = 'CHG'").Length > 0 ? dtRslt.Select("CHARGE_GUBUN = 'CHG'").CopyToDataTable() : null;
                    //DataTable dtDesign = dtRslt.Select("CHARGE_GUBUN = 'DES'").Length > 0 ? dtRslt.Select("CHARGE_GUBUN = 'DES'").CopyToDataTable() : null;

                    DataTable dtCharge = dtRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").Length > 0 ? dtRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").CopyToDataTable() : null;
                    DataTable dtDesign = dtRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").Length > 0 ? dtRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").CopyToDataTable() : null;

                    (layout.GetEditor("CUSTOMER_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtCharge );
                    (layout.GetEditor("CUSTDESIGN_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtDesign);

                    //(layout.GetEditor("CUSTOMER_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtRslt.Select("CHARGE_GUBUN = 'CHG'").CopyToDataTable());
                    //(layout.GetEditor("CUSTDESIGN_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtRslt.Select("CHARGE_GUBUN = 'DES'").CopyToDataTable());

                    break;

                //case "CUSTOMER_EMP":
                //    if(!this._IsOpen)
                //        layout.GetEditor("CUSTDESIGN_EMP").Value = newValue;

                //    break;

                case "PROC_TYPE":
                    if (newValue.Equals("A"))
                    {
                        layout.GetEditor("VISION_TYPE").Value = "0";
                        //layout.GetEditor("VISION_DIRECTION").Value = "6";
                    }
                    else if(newValue.Equals("M"))
                    {
                        layout.GetEditor("VISION_TYPE").Value = "1";
                        //layout.GetEditor("VISION_DIRECTION").Value = "6";
                    }
                    break;


                case "PROD_TYPE":

                    if (layout.GetEditor("PROD_FLAG").Value.isNullOrEmpty()) { return; }

                    //if (newValue.toInt() > 0 && newValue.toInt() < 9)
                    //{
                    //    if (layout.GetEditor("PROD_FLAG").Value.ToString() == "RE" && !editedBom.isNullOrEmpty())
                    //    {
                    //        if(editedBom.Rows.Count > 0)
                    //        {
                    //            if (acMessageBox.Show(this, "제품분류 변경시 기존에 편집된 BOM 정보는 초기화 됩니다.\n편집된 BOM을 그대로 유지하시겠습니까?", "", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    //            {
                    //                editedBom.Rows.Clear();
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    if (layout.GetEditor("PROD_FLAG").Value.ToString() == "RE" && !editedBom.isNullOrEmpty())
                    //    {
                    //        if (editedBom.Rows.Count > 0)
                    //        {
                    //            if (acMessageBox.Show(this, "제품분류를 Socket으로 변경하는 경우 기존에 편집된 BOM 정보는 유효하지 않습니다.", "", true, acMessageBox.emMessageBoxType.CONFIRM) == DialogResult.OK)
                    //            {
                    //                editedBom.Rows.Clear();
                    //            }
                    //        }
                    //    }
                    //}
                    break;

                case "AUTO_CAL":
                    if (newValue.Equals(true))
                    {
                        // 수량,총금액 이외 비활성화
                        layout.GetEditor("PROD_QTY").isReadyOnly = false; 
                        layout.GetEditor("PROD_COST").isReadyOnly = true;
                        layout.GetEditor("PROD_AMT").isReadyOnly = false;
                        layout.Refresh();
                    }
                    else
                    {
                        layout.GetEditor("PROD_QTY").isReadyOnly = false;
                        layout.GetEditor("PROD_COST").isReadyOnly = false;
                        layout.GetEditor("PROD_AMT").isReadyOnly = true;
                        layout.Refresh();
                    }
                        
                    break;


                case "PROD_KIND":

                    if (layout.GetEditor("PROD_KIND").Value.ToString() == "IE") // 제품인 경우
                    {
                        layout.GetEditor("MODEL_TYPE").isReadyOnly = true;
                        layout.GetEditor("MODEL_CODE").isReadyOnly = true;
                        layout.GetEditor("PROD_NAME").isReadyOnly = false;
                        layout.GetEditor("PROC_TYPE").isReadyOnly = true;
                        layout.GetEditor("PROC_FLAG").isReadyOnly = true;
                        layout.GetEditor("PROD_VERSION").isReadyOnly = true;

                        layout.GetEditor("MODEL_TYPE").isRequired = false;
                        layout.GetEditor("MODEL_CODE").isRequired = false;
                        layout.GetEditor("PROD_NAME").isRequired = true;
                        layout.GetEditor("PROC_TYPE").isRequired = false;
                        layout.GetEditor("PROC_FLAG").isRequired = false;

                        layout.Refresh();
                    }
                    else
                    {
                        layout.GetEditor("MODEL_TYPE").isReadyOnly = false;
                        layout.GetEditor("MODEL_CODE").isReadyOnly = false;
                        layout.GetEditor("PROD_NAME").isReadyOnly = false;
                        layout.GetEditor("PROC_TYPE").isReadyOnly = false;
                        layout.GetEditor("PROC_FLAG").isReadyOnly = false;
                        layout.GetEditor("PROD_VERSION").isReadyOnly = false;

                        layout.GetEditor("MODEL_TYPE").isRequired = true;
                        layout.GetEditor("MODEL_CODE").isRequired = true;
                        layout.GetEditor("PROD_NAME").isRequired = true;
                        layout.GetEditor("PROC_TYPE").isRequired = true;
                        layout.GetEditor("PROC_FLAG").isRequired = true;

                        layout.Refresh();
                    }
                    
                    break;

                case "EST_COST":

                    layout.GetEditor("PROD_COST").Value = newValue;

                    break;
            }

            //if (info.ColumnName == "ORD_DATE")
            //{
            //    layout.GetEditor("SALECONFM_DATE").Value = newValue;
            //}
            //else if (info.ColumnName == "CVND_CODE")
            //{

            //    if (acLayoutControl1.GetEditor("CVND_CODE").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("CVND_CODE").Editor as acVendor).SelectedRow;

            //        layout.GetEditor("ITEM_AUTO_CODE").Value = row["ITEM_AUTO_CODE"];

            //        if (acLayoutControl1.GetEditor("ITEM_CODE").Value == null)
            //            acLayoutControl1.DataBind(row, false);

            //    }


            //}
            //else if (info.ColumnName == "CHARGE_EMP")
            //{
            //    if (acLayoutControl1.GetEditor("CHARGE_EMP").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("CHARGE_EMP").Editor as acVendorCharge).SelectedRow;

            //        acLayoutControl1.DataBind(row, false);


            //        _ven_charge_id = row["VEN_CHARGE_ID"].toInt();

            //    }
            //    else
            //    {
            //        layout.GetEditor("CHARGE_DEPT").Value = "";
            //        layout.GetEditor("CHARGE_TEL").Value = "";
            //        layout.GetEditor("CHARGE_HP").Value = "";
            //        layout.GetEditor("CHARGE_EMAIL").Value = "";
            //        layout.GetEditor("CHARGE_SCOMMENT").Value = "";

            //        _ven_charge_id = 0;
            //    }
            //}
            //else if (info.ColumnName == "BUSINESS_EMP")
            //{
            //    if (acLayoutControl1.GetEditor("BUSINESS_EMP").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("BUSINESS_EMP").Editor as acEmp).SelectedRow;

            //        acLayoutControl1.DataBind(row, false);
            //    }
            //    else
            //    {
            //        acLayoutControl1.GetEditor("MOBILE_PHONE").Value = "";
            //     }
            //}

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            //acLayoutControl1.GetEditor("SALECONFM_DATE").Value = acDateEdit.GetNowDateFromServer();
            acLayoutControl1.GetEditor("ORD_DATE").Value = acDateEdit.GetNowDateFromServer();
            //acLayoutControl1.GetEditor("DUE_DATE").Value = acDateEdit.GetNowDateFromServer().AddMonths(1);

            acLayoutControl1.GetEditor("BUSINESS_EMP").Value = acInfo.UserID;

            acLayoutControl1.GetEditor("PROD_STATE").Value = "6";

            acLayoutControl1.GetEditor("PROD_KIND").Value = "PD";

            acLayoutControl1.GetEditor("CURR_UNIT").Value = "0";

            acLayoutControl1.GetEditor("ORD_VAT").Value = "1";

            acLayoutControl1.GetEditor("DRAW_TYPE").Value = "1";

            acLayoutControl1.GetEditor("ITEM_FLAG").Value = "1";

            acLayoutControl1.GetEditor("PROD_PRIORITY").Value = "1";

            acLayoutControl1.GetEditor("MSOP_YN").Value = "N";

            acLayoutControl1.GetEditor("DFM_YN").Value = "N";

        }

        private bool _IsOpen = false;
        private bool _Locked = true;

        public override void DialogOpen()
        {
            //열기

            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;
            this._IsOpen = true;

            if (linkRow != null)
            {
                if (linkRow["LOCK_EMP"].ToString() == acInfo.UserID)
                {
                    _Locked = true;
                }

                if (linkRow["LOCK_EMP"].ToString() != acInfo.UserID)
                {
                    if (linkRow["MNG_EMP1"].ToString() == acInfo.UserID ||
                        linkRow["MNG_EMP2"].ToString() == acInfo.UserID)
                    {
                        _Locked = true;
                    }
                }
                
                if (linkRow["LOCK_FLAG"].ToString() == "0"
                    || linkRow["LOCK_FLAG"].ToString() == "")
                {
                    _Locked = false;
                }

                
            }
          

            this.acLayoutControl1.OnValueChanged -= new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            #region 다이얼로그 오픈시 대분류, 중분류 설정
            DataTable dtRsltScode = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                      , ExtensionMethods.GetCubizParam("VEN_CODE:" + linkRow["CVND_CODE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            string scode = "0";
            if (dtRsltScode.Rows.Count > 0) { scode = dtRsltScode.Rows[0]["SCODE"].ToString(); }

            DataTable dtRsltType = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
               , ExtensionMethods.GetCubizParam("P_SCODE:" + scode), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            (acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dtRsltType);

           
            DataTable dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                       , ExtensionMethods.GetCubizParam("P_SCODE:" + linkRow["MODEL_TYPE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            (acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt);

            
            #endregion

            acLayoutControl1.DataBind(linkRow, true);

            if (!linkRow["ACTUATOR_YN"].isNullOrEmpty() && ((string)linkRow["ACTUATOR_YN"] == "1" || (string)linkRow["ACTUATOR_YN"] == "3"))
            {
                acLayoutControl1.GetEditor("PART_CODE").isReadyOnly = false;
            }

            if (acLayoutControl1.GetEditor("PROD_KIND").Value.ToString() == "IE") // 제품인 경우
            {
                acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = true;
                acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = true;

                acLayoutControl1.GetEditor("MODEL_TYPE").isRequired = false;
                acLayoutControl1.GetEditor("MODEL_CODE").isRequired = false;
                acLayoutControl1.GetEditor("PROD_NAME").isRequired = true;
                acLayoutControl1.GetEditor("PROC_TYPE").isRequired = false;
                acLayoutControl1.GetEditor("PROC_FLAG").isRequired = false;

                acLayoutControl1.Refresh();
            }
            else
            {
                acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = false;
                acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = false;

                acLayoutControl1.GetEditor("MODEL_TYPE").isRequired = true;
                acLayoutControl1.GetEditor("MODEL_CODE").isRequired = true;
                acLayoutControl1.GetEditor("PROD_NAME").isRequired = true;
                acLayoutControl1.GetEditor("PROC_TYPE").isRequired = true;
                acLayoutControl1.GetEditor("PROC_FLAG").isRequired = true;

                acLayoutControl1.Refresh();
            }

         
            // 영업담당자
            DataTable dtChargeRslt = BizRun.QBizRun.ExecuteService(this, "ORD02A_VEN_CHARGE"
                , ExtensionMethods.GetCubizParam("VEN_CODE:" + acLayoutControl1.GetEditor("CVND_CODE").Value.ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            //DataTable dtVenCharge = dtChargeRslt.Select("CHARGE_GUBUN = 'CHG'").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN = 'CHG'").CopyToDataTable() : null;
            //DataTable dtVenDesign = dtChargeRslt.Select("CHARGE_GUBUN = 'DES'").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN = 'DES'").CopyToDataTable() : null;

            DataTable dtVenCharge = dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").CopyToDataTable() : null;
            DataTable dtVenDesign = dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").CopyToDataTable() : null;

            (acLayoutControl1.GetEditor("CUSTOMER_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenCharge);
            (acLayoutControl1.GetEditor("CUSTDESIGN_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenDesign);

            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            //수주상태 변경금지
            if (acInfo.UserID != "active")
            {
                if ((!acLayoutControl1.GetEditor("PROD_CODE").Value.isNullOrEmpty()) && acLayoutControl1.GetEditor("PROD_STATE").Value.ToString() != "0")
                {
                    acLayoutControlItem31.Enabled = false;
                }
            }


            if (_Locked)
            {
                barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                acLayoutControl1.SetAllReadOnly(true);
                //acLayoutControlGroup3

                foreach (object obj2 in (acLayoutControlGroup4.Items))
                {
                    if (obj2 is acLayoutControlItem)
                    {
                        acLayoutControlItem item = obj2 as acLayoutControlItem;

                        if (item.Control is IBaseEditControl)
                        {
                            IBaseEditControl control = item.Control as IBaseEditControl;

                            control.isReadyOnly = true;
                        }
                    }
                }
                foreach (object obj2 in (acLayoutControlGroup5.Items))
                {
                    if (obj2 is acLayoutControlItem)
                    {
                        acLayoutControlItem item = obj2 as acLayoutControlItem;

                        if (item.Control is IBaseEditControl)
                        {
                            IBaseEditControl control = item.Control as IBaseEditControl;

                            control.isReadyOnly = true;
                        }
                    }
                }

            }
                

            this._IsOpen = false;
        }        

        public override void DialogUser()
        {
            //복사

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;

            this.acLayoutControl1.OnValueChanged -= new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            #region 다이얼로그 오픈시 대분류, 중분류 설정
            DataTable dtRsltScode = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                      , ExtensionMethods.GetCubizParam("VEN_CODE:" + linkRow["CVND_CODE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            string scode = "0";
            if (dtRsltScode.Rows.Count > 0) { scode = dtRsltScode.Rows[0]["SCODE"].ToString(); }

            DataTable dtRsltType = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
               , ExtensionMethods.GetCubizParam("P_SCODE:" + scode), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            (acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dtRsltType);


            DataTable dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                       , ExtensionMethods.GetCubizParam("P_SCODE:" + linkRow["MODEL_TYPE"].ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            (acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt);

            #endregion

            //linkRow["PROD_QTY"] = DBNull.Value;
            string prodFlag = linkRow["PROD_FLAG"].ToString();
            linkRow["PROD_FLAG"] = "RE";

            acLayoutControl1.DataBind(linkRow, true);

            linkRow["PROD_FLAG"] = prodFlag; 

            acLayoutControl1.GetEditor("PROD_QTY").Value = DBNull.Value;

            // 영업담당자
            DataTable dtChargeRslt = BizRun.QBizRun.ExecuteService(this, "ORD02A_VEN_CHARGE"
                , ExtensionMethods.GetCubizParam("VEN_CODE:" + acLayoutControl1.GetEditor("CVND_CODE").Value.ToString()), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

            //DataTable dtVenCharge = dtChargeRslt.Select("CHARGE_GUBUN = 'CHG'").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN = 'CHG'").CopyToDataTable() : null;
            //DataTable dtVenDesign = dtChargeRslt.Select("CHARGE_GUBUN = 'DES'").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN = 'DES'").CopyToDataTable() : null;

            DataTable dtVenCharge = dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('CHG', 'COM')").CopyToDataTable() : null;
            DataTable dtVenDesign = dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").Length > 0 ? dtChargeRslt.Select("CHARGE_GUBUN IN ('DES', 'COM')").CopyToDataTable() : null;

            (acLayoutControl1.GetEditor("CUSTOMER_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenCharge);
            (acLayoutControl1.GetEditor("CUSTDESIGN_EMP").Editor as acLookupEdit).SetData("CHARGE_EMP", "CHARGE_EMP", dtVenDesign);

            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.GetEditor("PROD_STATE").Value = "6"; // 수주상태: 등록

            //수주상태 변경금지
            if (acInfo.UserID != "active")
            {
                if ((!acLayoutControl1.GetEditor("PROD_CODE").Value.isNullOrEmpty()) && acLayoutControl1.GetEditor("PROD_STATE").Value.ToString() != "0")
                {
                    acLayoutControlItem31.Enabled = false;
                }
            }

            acLayoutControl1.GetEditor("ORD_DATE").Value = acDateEdit.GetNowDateFromServer();
            //acLayoutControl1.GetEditor("DUE_DATE").Value = acDateEdit.GetNowDateFromServer().AddMonths(1);

            acLayoutControl1.GetEditor("BUSINESS_EMP").Value = acInfo.UserID;

            acLayoutControl1.GetEditor("PROD_CODE").Value = null;

            acLayoutControl1.GetEditor("PROD_FLAG").Value = "RE"; // 수주유형: Repeat

            

            _OldProdCode = linkRow["PROD_CODE"].ToString();

            //(acLayoutControl1.GetEditor("PROD_KIND").Editor as acLookupEdit).SetCode("C011", new string[] {"IE","SK" });

            #region 필수정보 읽기전용으로 설정
            //acLayoutControl1.GetEditor("CVND_CODE").isReadyOnly = true;
            //acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = true;
            //acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = true;
            //acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = true;
            //acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = true;
            //acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = true;
            //acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = true;
            //acLayoutControl1.GetEditor("PROD_KIND").isReadyOnly = false;
            //acLayoutControl1.GetEditor("PROD_FLAG").isReadyOnly = true;

            if (acLayoutControl1.GetEditor("PROD_KIND").Value.ToString() == "IE") // 제품인 경우
            {
                acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = true;
                acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = true;
                acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = true;

                acLayoutControl1.GetEditor("MODEL_TYPE").isRequired = false;
                acLayoutControl1.GetEditor("MODEL_CODE").isRequired = false;
                acLayoutControl1.GetEditor("PROD_NAME").isRequired = true;
                acLayoutControl1.GetEditor("PROC_TYPE").isRequired = false;
                acLayoutControl1.GetEditor("PROC_FLAG").isRequired = false;

                acLayoutControl1.Refresh();
            }
            else
            {
                acLayoutControl1.GetEditor("MODEL_TYPE").isReadyOnly = false;
                acLayoutControl1.GetEditor("MODEL_CODE").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROD_NAME").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_TYPE").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROC_FLAG").isReadyOnly = false;
                acLayoutControl1.GetEditor("PROD_VERSION").isReadyOnly = false;

                acLayoutControl1.GetEditor("MODEL_TYPE").isRequired = true;
                acLayoutControl1.GetEditor("MODEL_CODE").isRequired = true;
                acLayoutControl1.GetEditor("PROD_NAME").isRequired = true;
                acLayoutControl1.GetEditor("PROC_TYPE").isRequired = true;
                acLayoutControl1.GetEditor("PROC_FLAG").isRequired = true;

                acLayoutControl1.Refresh();
            }
            #endregion

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

                if (acLayoutControl1.GetEditor("PROD_QTY").Value.toInt() < 1)
                {
                    acAlert.Show(this, "제작수량이 0보다 커야합니다.", acAlertForm.enmType.Info);
                    return;
                }

                if (_Locked)
                {
                    this.Close();
                    return;
                }

                if (acMessageBox.Show("수주 및 사양 이력관리를 하시겠습니까?", "수주 편집기", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //                
                    paramTable.Columns.Add("PROD_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];

                    paramTable.Rows.Add(paramRow);
                    DataSet dtSet = new DataSet();
                    dtSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, "ORD13A_INS",dtSet,"RQSTDT", "RSLTDT");
                  
                }
               


                DataSet paramSet = GetSaveData("1");

                if (paramSet != null)
                {
                    barItemSave.Enabled = false;
                    barItemSaveClose.Enabled = false;
                    barItemRefresh.Enabled = false;
                    barItemDel.Enabled = false;
                    barItemClose.Enabled = false;

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD05A_INS6", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
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
                    this._LinkView.UpdateMapingRow(row, false);
                }

                _LinkView.RaiseFocusedRowChanged();

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {



            if (ex.ErrNumber == BizManager.BizException.OVERWRITE ||
                ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
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

            }
            else if (ex.ErrNumber == 200200)
            {
                acMessageBox.Show("대기 상태인 수주만 수정 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }
        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                paramTable.Columns.Add("ITEM_CODE", typeof(String)); //

                DataRow linkRow = (DataRow)_LinkData;

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = linkRow["ITEM_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD02A_DEL", paramSet, "RQSTDT", "",
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

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();


                acLayoutControl1.GetEditor("ITEM_CODE").FocusEdit();
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

                if (acLayoutControl1.GetEditor("PROD_QTY").Value.toInt() < 1)
                {
                    acAlert.Show(this, "제작수량이 0보다 커야합니다.", acAlertForm.enmType.Info);
                    return;
                }


                DataSet paramSet = GetSaveData("0");

                if (paramSet != null)
                {

                    barItemSave.Enabled = false;
                    barItemSaveClose.Enabled = false;
                    barItemRefresh.Enabled = false;
                    barItemDel.Enabled = false;
                    barItemClose.Enabled = false;

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.NEW,
                    "ORD05A_INS6", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }

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


        DataSet GetSaveData(string overwrite)
        {
            try
            {

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                //기본정보
                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //                
                paramTable1.Columns.Add("PROD_CODE", typeof(String));
                paramTable1.Columns.Add("OLD_PROD_CODE", typeof(String));
                paramTable1.Columns.Add("PROD_NAME", typeof(String));
                paramTable1.Columns.Add("PROD_STATE", typeof(String));
                paramTable1.Columns.Add("PROD_VERSION", typeof(String));
                paramTable1.Columns.Add("PROC_TYPE", typeof(String));
                paramTable1.Columns.Add("PROC_FLAG", typeof(String));
                paramTable1.Columns.Add("PROD_FLAG", typeof(String));
                paramTable1.Columns.Add("PROD_KIND", typeof(String));
                paramTable1.Columns.Add("INS_YN", typeof(String));
                //paramTable1.Columns.Add("SOCKET_YN", typeof(String));
                paramTable1.Columns.Add("PROD_TYPE", typeof(String));
                paramTable1.Columns.Add("PROD_CATEGORY", typeof(String));
                paramTable1.Columns.Add("BUSINESS_EMP", typeof(String));
                paramTable1.Columns.Add("CUSTOMER_EMP", typeof(String));
                paramTable1.Columns.Add("CUSTDESIGN_EMP", typeof(String));
                paramTable1.Columns.Add("ACTUATOR_YN", typeof(String));
                paramTable1.Columns.Add("CVND_CODE", typeof(String));
                paramTable1.Columns.Add("TVND_CODE", typeof(String));
                //paramTable1.Columns.Add("PROBE_PIN", typeof(String));
                paramTable1.Columns.Add("PIN_TYPE", typeof(String));
                paramTable1.Columns.Add("CURR_UNIT", typeof(String));
                paramTable1.Columns.Add("ORD_DATE", typeof(String));
                paramTable1.Columns.Add("DUE_DATE", typeof(String));
                paramTable1.Columns.Add("CHG_DUE_DATE", typeof(String));
                //paramTable1.Columns.Add("DELIVERY_DATE", typeof(String));
                paramTable1.Columns.Add("PROD_QTY", typeof(int));
                paramTable1.Columns.Add("ORD_VAT", typeof(String));
                paramTable1.Columns.Add("PROD_COST", typeof(decimal));
                paramTable1.Columns.Add("PROD_AMT", typeof(decimal));
                paramTable1.Columns.Add("TRADE_YN", typeof(String));
                paramTable1.Columns.Add("TAX_YN", typeof(String));
                paramTable1.Columns.Add("BILL_YN", typeof(String));
                paramTable1.Columns.Add("SCOMMENT", typeof(String));
        

                paramTable1.Columns.Add("MODULE_TYPE", typeof(String));
                //paramTable1.Columns.Add("PIN_TYPE", typeof(String));
                paramTable1.Columns.Add("VISION_TYPE", typeof(String));
                paramTable1.Columns.Add("VISION_DIRECTION", typeof(String));
                paramTable1.Columns.Add("GND_PIN", typeof(String));
                paramTable1.Columns.Add("FIDUCIAL_MARK", typeof(String));
                paramTable1.Columns.Add("CROSS_MARKING", typeof(String));
                paramTable1.Columns.Add("VACUUM", typeof(String));
                paramTable1.Columns.Add("SOCKET_MARKING", typeof(String));
                paramTable1.Columns.Add("MODULE_IN_TYPE", typeof(String));
                paramTable1.Columns.Add("IF_PIN_BLOCK", typeof(String));
                paramTable1.Columns.Add("SOCKET_OPEN_DIRECTION", typeof(String));
                paramTable1.Columns.Add("DFM_YN", typeof(String));
                paramTable1.Columns.Add("MSOP_YN", typeof(String));
                paramTable1.Columns.Add("DFM_DATE", typeof(String));
                paramTable1.Columns.Add("MSOP_DATE", typeof(String));
                paramTable1.Columns.Add("DRAW_DATE", typeof(String));
                paramTable1.Columns.Add("DRAW_TYPE", typeof(String));
                paramTable1.Columns.Add("PO_NO", typeof(String));
                paramTable1.Columns.Add("MODEL_TYPE", typeof(String));
                paramTable1.Columns.Add("MODEL_CODE", typeof(String));
                paramTable1.Columns.Add("PART_CODE", typeof(String));

                paramTable1.Columns.Add("ITEM_FLAG", typeof(String));

                paramTable1.Columns.Add("BALJU_TYPE", typeof(String));

                paramTable1.Columns.Add("PROD_PRIORITY", typeof(String));

                paramTable1.Columns.Add("REG_EMP", typeof(String)); //

                paramTable1.Columns.Add("MNG_EMP1", typeof(String)); //
                paramTable1.Columns.Add("MNG_EMP2", typeof(String)); //

                paramTable1.Columns.Add("EST_COST", typeof(decimal));

                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = layoutRow["PROD_CODE"];
                paramRow1["OLD_PROD_CODE"] = _OldProdCode;
                paramRow1["PROD_NAME"] = layoutRow["PROD_NAME"];
                paramRow1["PROD_STATE"] = layoutRow["PROD_STATE"];
                paramRow1["PROD_VERSION"] = layoutRow["PROD_VERSION"];
                paramRow1["PROC_TYPE"] = layoutRow["PROC_TYPE"];
                paramRow1["PROC_FLAG"] = layoutRow["PROC_FLAG"];
                paramRow1["PROD_FLAG"] = layoutRow["PROD_FLAG"];
                paramRow1["PROD_KIND"] = layoutRow["PROD_KIND"];
                paramRow1["INS_YN"] = layoutRow["INS_YN"];
                //paramRow1["SOCKET_YN"] = layoutRow["SOCKET_YN"];
                paramRow1["PROD_TYPE"] = layoutRow["PROD_TYPE"];
                paramRow1["PROD_CATEGORY"] = layoutRow["PROD_CATEGORY"];
                paramRow1["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow1["CUSTOMER_EMP"] = layoutRow["CUSTOMER_EMP"];
                paramRow1["CUSTDESIGN_EMP"] = layoutRow["CUSTDESIGN_EMP"];
                paramRow1["ACTUATOR_YN"] = layoutRow["ACTUATOR_YN"];
                paramRow1["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow1["TVND_CODE"] = layoutRow["TVND_CODE"];
                paramRow1["PIN_TYPE"] = layoutRow["PIN_TYPE"];
                paramRow1["CURR_UNIT"] = layoutRow["CURR_UNIT"];
                paramRow1["ORD_DATE"] = layoutRow["ORD_DATE"];
                paramRow1["DUE_DATE"] = layoutRow["DUE_DATE"];
                paramRow1["CHG_DUE_DATE"] = layoutRow["CHG_DUE_DATE"];
                //paramRow1["DELIVERY_DATE"] = layoutRow["DELIVERY_DATE"];
                paramRow1["PROD_QTY"] = layoutRow["PROD_QTY"];
                paramRow1["ORD_VAT"] = layoutRow["ORD_VAT"];
                paramRow1["PROD_COST"] = layoutRow["PROD_COST"];
                paramRow1["PROD_AMT"] = layoutRow["PROD_AMT"];
                paramRow1["TRADE_YN"] = layoutRow["TRADE_YN"];
                paramRow1["TAX_YN"] = layoutRow["TAX_YN"];
                paramRow1["BILL_YN"] = layoutRow["BILL_YN"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
              

                paramRow1["MODULE_TYPE"] = layoutRow["MODULE_TYPE"];
                //paramRow1["PIN_TYPE"] = layoutRow["PIN_TYPE"];
                paramRow1["VISION_TYPE"] = layoutRow["VISION_TYPE"];
                paramRow1["VISION_DIRECTION"] = layoutRow["VISION_DIRECTION"];   
                paramRow1["GND_PIN"] = layoutRow["GND_PIN"];
                paramRow1["FIDUCIAL_MARK"] = layoutRow["FIDUCIAL_MARK"];
                paramRow1["CROSS_MARKING"] = layoutRow["CROSS_MARKING"];
                paramRow1["VACUUM"] = layoutRow["VACUUM"];
                paramRow1["SOCKET_MARKING"] = layoutRow["SOCKET_MARKING"];
                paramRow1["MODULE_IN_TYPE"] = layoutRow["MODULE_IN_TYPE"];
                paramRow1["IF_PIN_BLOCK"] = layoutRow["IF_PIN_BLOCK"];
                paramRow1["SOCKET_OPEN_DIRECTION"] = layoutRow["SOCKET_OPEN_DIRECTION"];
                paramRow1["DFM_YN"] = layoutRow["DFM_YN"];
                paramRow1["DFM_DATE"] = layoutRow["DFM_DATE"];
                paramRow1["MSOP_YN"] = layoutRow["MSOP_YN"];
                paramRow1["MSOP_DATE"] = layoutRow["MSOP_DATE"];
                paramRow1["DRAW_DATE"] = layoutRow["DRAW_DATE"];
                paramRow1["DRAW_TYPE"] = layoutRow["DRAW_TYPE"];
                paramRow1["PO_NO"] = layoutRow["PO_NO"];
                paramRow1["MODEL_TYPE"] = layoutRow["MODEL_TYPE"];
                paramRow1["MODEL_CODE"] = layoutRow["MODEL_CODE"];

                paramRow1["PART_CODE"] = layoutRow["PART_CODE"];

                paramRow1["BALJU_TYPE"] = layoutRow["BALJU_TYPE"];

                paramRow1["ITEM_FLAG"] = layoutRow["ITEM_FLAG"];

                paramRow1["PROD_PRIORITY"] = layoutRow["PROD_PRIORITY"];

                paramRow1["MNG_EMP1"] = layoutRow["MNG_EMP1"];
                paramRow1["MNG_EMP2"] = layoutRow["MNG_EMP2"];
                paramRow1["REG_EMP"] = acInfo.UserID;

                paramRow1["EST_COST"] = layoutRow["EST_COST"];

                paramRow1["OVERWRITE"] = overwrite;

                paramTable1.Rows.Add(paramRow1);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);

                //if (!editedBom.isNullOrEmpty()) 
                if (editedBom != null)
                {
                    if (editedBom.Rows.Count > 0)
                    {
                        // 기존 수주건의 PART_QTY를 지우고 새로 편집한 수량을 PART_QTY로 지정
                        // editedBom.Columns.Remove("PART_QTY");
                        // editedBom.Columns["BOM_QTY"].ColumnName = "PART_QTY";

                        editedBom.TableName = "RQSTDT_BOM";
                        paramSet.Tables.Add(editedBom);
                    }
                }

                if (editedDelBom != null)
                {
                    if (editedDelBom.Rows.Count > 0)
                    {
                        editedDelBom.TableName = "RQSTDT_DEL_BOM";
                        paramSet.Tables.Add(editedDelBom);
                    }
                }


                return paramSet;
            }
            catch(Exception ex)
            {

                acMessageBox.Show(this,ex);
                return null;
            }

        }


        private void barItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnBom_Click(object sender, EventArgs e)
        {
            // BOM 관리 버튼
            try
            {

                //if (_OldProdCode.isNullOrEmpty()) { return; }

                if (_OldProdCode.isNullOrEmpty()) 
                {
                    DataRow layOutRow = acLayoutControl1.CreateParameterRow();

                    if (!base.ChildFormContains("NEW_BOM"))
                    {
                        if (layOutRow["PROD_CODE"].ToString() == "")
                        {
                            return;
                        }

                        if (layOutRow["PROD_QTY"].toInt() == 0)
                        {
                            acAlert.Show(this, "제작수량이 없습니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        if (layOutRow["PROD_TYPE"].toStringEmpty() == "")
                        {
                            acAlert.Show(this, "제품분류가 없습니다.", acAlertForm.enmType.Info);
                            return;
                        }


                        ORD02A_D5A frm = new ORD02A_D5A(layOutRow["PROD_CODE"].ToString(), tempEditBom, true, layOutRow);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW_BOM", frm);

                        //frm.Show(this);

                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            tempEditBom = (DataTable)frm.OutputData; //임시저장용

                            // 편집된 BOM 저장
                            if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").Length != 0)
                            {
                                editedBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").CopyToDataTable();

                                if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").Length != 0)
                                {
                                    editedDelBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").CopyToDataTable();
                                }
                                else
                                {
                                    editedDelBom = null;
                                }

                            }
                            else
                            {
                                editedBom = null;
                                editedDelBom = null;
                            }
                        }
                    }
                    else
                    {
                        base.ChildFormFocus("NEW_BOM");
                    }
                }
                else
                {
                    if (!base.ChildFormContains("NEW_BOM"))
                    {
                        DataRow layOutRow = acLayoutControl1.CreateParameterRow();

                        if (layOutRow["PROD_QTY"].toInt() == 0)
                        {
                            acAlert.Show(this, "제작수량이 없습니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        if (layOutRow["PROD_TYPE"].toStringEmpty() == "")
                        {
                            acAlert.Show(this, "제품분류가 없습니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        ORD02A_D5A frm = new ORD02A_D5A(_OldProdCode, tempEditBom, false, layOutRow);

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW_BOM", frm);

                        //frm.Show(this);

                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            tempEditBom = (DataTable)frm.OutputData; //임시저장용

                            // 편집된 BOM 저장
                            if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").Length != 0)
                            {
                                editedBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '1'").CopyToDataTable();

                                if (((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").Length != 0)
                                {
                                    editedDelBom = ((DataTable)frm.OutputData).Select("[CHK_FLAG] = '0'").CopyToDataTable();
                                }
                                else
                                {
                                    editedDelBom = null;
                                }

                            }
                            else
                            {
                                editedBom = null;
                                editedDelBom = null;
                            }
                        }

                    }
                    else
                    {
                        base.ChildFormFocus("NEW_BOM");
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 모델정보 불러오기

            try
            {
                // 대분류 갱신

                if(!acLayoutControl1.GetEditor("CVND_CODE").Value.isNullOrEmpty())
                {
                    string ven_code = acLayoutControl1.GetEditor("CVND_CODE").Value.ToString();

                    DataTable dtRsltScode = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                        , ExtensionMethods.GetCubizParam("VEN_CODE:" + ven_code), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    string scode = "0";

                    if (dtRsltScode.Rows.Count > 0) { scode = dtRsltScode.Rows[0]["SCODE"].ToString(); }

                    DataTable dtRsltType = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                       , ExtensionMethods.GetCubizParam("P_SCODE:" + scode), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    (acLayoutControl1.GetEditor("MODEL_TYPE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dtRsltType);
                }

                
                // 중분류 갱신
                if(!acLayoutControl1.GetEditor("MODEL_TYPE").Value.isNullOrEmpty())
                {
                    string model_type = acLayoutControl1.GetEditor("MODEL_TYPE").Value.ToString();

                    DataTable dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD07A_SER"
                       , ExtensionMethods.GetCubizParam("P_SCODE:" + model_type), "RQSTDT", "RQSTDT").Tables["RSLTDT"];

                    (acLayoutControl1.GetEditor("MODEL_CODE").Editor as acLookupEdit).SetData("MODEL_NAME", "SCODE", dsRslt);
                }
            
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}