using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using System.IO;

namespace QCT
{
    public partial class QCT01A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override bool MenuDestory(object sender)
        {

            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }


        public QCT01A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acLayoutControl2.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl2.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acLayoutControl3.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl3.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
            acGridView1.MouseDown += acGridView1_MouseDown;
            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;
            acGridView2.MouseDown += acGridView2_MouseDown;
            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;
        }

        private void AcTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch(acTabControl1.GetSelectedContainerName())
            {
                case "IN_NG":
                    {
                        btnProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    break;
                case "DES_C":
                    {
                        btnProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    break;
                case "OUT_NG":
                    {
                        btnProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    break;
            }
        }

        public override void MenuInit()
        {
            #region 사내불량
            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddHidden("NG_ID", typeof(string));
            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("LINK_KEY", "실적번호", "ZU7TGN7X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "작업자 코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "작업자", "40545", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BUSINESS_EMP_NAME", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DEV_EMP", "개발담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DEV_EMP_NAME", "개발담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("NG_DATE", "불량발생일", "F1HO50M4", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEdit("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C400");
            acGridView1.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C401");
            acGridView1.AddLookUpEdit("NG_CAT", "분류", "MQ60JVR0", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q005");
            acGridView1.AddCheckedComboBoxEdit("NG_OCCUR", "발생처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "Q007");
            acGridView1.AddTextEdit("NG_MEASURE_EMP", "불량처리자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("NG_MEASURE_EMP_NAME", "불량처리자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("NG_MAT_COST", "소재비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NG_OUT_COST", "외주비용", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NG_PROC_COST", "사내비용", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NG_LAB_COST", "재작업비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NG_DIST_COST", "대책비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NG_COST", "비용 합계", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("QUANTITY", "발생 불량수량", "UGW32N5B", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WK_NG_QTY", "확정 불량수량", "UGW32N5B", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("NG_STATE", "불량상태", "587SOBFY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q003");
            acGridView1.AddLookUpEdit("NG_TYPE", "불량형태", "C1VMAHMU", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, "Q004");
            acGridView1.AddMemoEdit("NG_CONTENTS", "불량내용", "IGBK9DTD", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);
            acGridView1.AddMemoEdit("NG_CAUSE", "불량 및 특채 원인", "J0Q7135N", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);
            acGridView1.AddMemoEdit("NG_MEASURE", "불량대책", "30PLWWE1", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);
            //acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("OVND_CODE", "외주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("OVND_NAME", "외주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("LINK_KEY", typeof(string));
            acGridView1.KeyColumn = new string[] { "NG_ID" };

            #endregion

            #region 수입검사 불량
            acGridView2.AddHidden("NG_ID", typeof(string));
            acGridView2.AddTextEdit("BALJU_NUM", "발주번호", "40203", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_SEQ", "발주순번", "42597", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("BALJU_DATE", "발주일", "40206", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("INS_DATE", "검사일", "40206", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView2.AddTextEdit("NG_STATE", "재작업 처리", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpVendor("VND_CODE", "거래처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView2.AddLookUpEmp("BAL_EMP", "발주자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            //acGridView2.AddTextEdit("VEN_CODE", "거래처코드", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("VEN_NAME", "거래처명", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("EMP_CODE", "발주자코드", "N089BVX6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("EMP_NAME", "발주자명", "HEP4DK2T", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView2.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView2.AddLookUpEdit("MASTER_CAUSE", "불량주원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C402");
            //acGridView2.AddLookUpEdit("DETAIL_CAUSE", "불량상세원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C402");
            acGridView2.AddTextEdit("NG_CONTENTS", "불량내용", "40239", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("NG_CAUSE", "불량 및 특채 원인", "40239", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("NG_MEASURE", "불량대책", "40239", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("NG_STATE", "불량상태", "587SOBFY", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q003");
            //acGridView2.AddLookUpEdit("NG_TYPE", "불량형태", "C1VMAHMU", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, "Q004");

            //acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BAL_QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            //acGridView2.AddLookUpEmp("MDFY_EMP", "최근 수정자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView2.KeyColumn = new string[] { "NG_ID" };
            #endregion

            //acGridView3.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PROD_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("PART_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PRC_PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView3.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView3.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            cboDate.AddItem("불량발생일", false, "F1HO50M4", "NG_DATE", true, false);
            cboDate.AddItem("출하예정일", false, "", "DUE_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("수입검사일", false, "F1HO50M4", "INS_DATE", true, false);

            acCheckedComboBoxEdit2.AddItem("불량발생일", false, "F1HO50M4", "NG_DATE", true, false);
            acCheckedComboBoxEdit2.AddItem("출하예정일", false, "", "DUE_DATE", true, false);

            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "NG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }

            if (sender == acLayoutControl2)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "INS_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }

            if (sender == acLayoutControl3)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "NG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }
            base.ChildContainerInit(sender);
        }

        private void btnIns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 사내불량 편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    QCT01A_D0A frm = new QCT01A_D0A(this, acGridView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 사내불량 편집기
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["NG_ID"]))
                {


                    QCT01A_D0A frm = new QCT01A_D0A(this, acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["NG_ID"], frm);

                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus(focusRow["NG_ID"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetLinkDataIn();
        }

        void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetLinkDataOut();
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    ModifyNg();
                }

            }
        }

        private void ModifyNg()
        {
            //열기 사내불량 편집기
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();
                if (!base.ChildFormContains(focusRow["NG_ID"]))
                {
                    QCT01A_D3A frm = new QCT01A_D3A(this, focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["NG_ID"], frm);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataSet paramSet = new DataSet();

                        DataRow frmRow = (DataRow)frm.OutputData;
                        DataTable ngTable = paramSet.Tables.Add("RQSTDT");
                        ngTable.Columns.Add("PLT_CODE", typeof(String));
                        //ngTable.Columns.Add("TYP_ID", typeof(String));
                        ngTable.Columns.Add("NG_ID", typeof(String));
                        ngTable.Columns.Add("MASTER_CAUSE", typeof(String));
                        ngTable.Columns.Add("DETAIL_CAUSE", typeof(String));
                        ngTable.Columns.Add("NG_TYPE", typeof(String));
                        ngTable.Columns.Add("NG_STATE", typeof(String));

                        ngTable.Columns.Add("NG_CONTENTS", typeof(String));
                        ngTable.Columns.Add("NG_CAUSE", typeof(String));
                        ngTable.Columns.Add("NG_MEASURE", typeof(String));
                        ngTable.Columns.Add("NG_MAT_COST", typeof(Decimal));
                       
                        DataRow ngRow = ngTable.NewRow();
                        ngRow["PLT_CODE"] = acInfo.PLT_CODE;
                        //ngRow["TYP_ID"] = focusRow["TYP_ID"];
                        ngRow["NG_ID"] = focusRow["NG_ID"];
                        ngRow["MASTER_CAUSE"] = frmRow["MASTER_CAUSE"];
                        ngRow["DETAIL_CAUSE"] = frmRow["DETAIL_CAUSE"];

                        ngRow["NG_STATE"] = "A";
                        ngRow["NG_CONTENTS"] = frmRow["NG_CONTENTS"];
                        ngRow["NG_CAUSE"] = frmRow["NG_CAUSE"];
                        ngRow["NG_MEASURE"] = frmRow["NG_MEASURE"];

                        ngRow["NG_MAT_COST"] = frmRow["NG_MAT_COST"];
                        ngTable.Rows.Add(ngRow);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_INS7", paramSet, "RQSTDT", "RSLTDT",
                           QuickSave,
                           QuickException);
                    }
                }
                else
                {
                    base.ChildFormFocus(focusRow["NG_ID"]);
                }

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
                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;
            //if (e.MenuType == GridMenuType.User)
            //{
            //    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            //else if (e.MenuType == GridMenuType.Row)
            //{
            //    if (e.HitInfo.RowHandle >= 0)
            //    {

            //        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //    }
            //    else
            //    {

            //        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //    }

            //}
            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            if (sender is acLayoutControl layoutCon)
            {
                switch (info.ColumnName)
                {
                    case "DATE":

                        //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                        if (newValue.EqualsEx(string.Empty))
                        {
                            layoutCon.GetEditor("S_DATE").isRequired = false;
                            layoutCon.GetEditor("E_DATE").isRequired = false;

                        }
                        else
                        {
                            layoutCon.GetEditor("S_DATE").isRequired = true;
                            layoutCon.GetEditor("E_DATE").isRequired = true;
                        }

                        break;

                }
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void GetLinkDataIn()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                this.acAttachFileControl1.LinkKey = focusRow["NG_ID"];
                this.acAttachFileControl1.ShowKey = new object[] { focusRow["NG_ID"] };

            }
            else
            {
                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;
            }
        }

        void GetLinkDataOut()
        {
            if (acGridView2.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                this.acAttachFileControl2.LinkKey = focusRow["NG_ID"];
                this.acAttachFileControl2.ShowKey = new object[] { focusRow["NG_ID"] };

            }
            else
            {
                this.acAttachFileControl2.LinkKey = null;
                this.acAttachFileControl2.ShowKey = null;
            }
        }

        public override void DataRefresh(object data)
        {
            switch(data)
            {
                case "IN":
                    {
                        if (base.IsData("READ_IN"))
                        {
                            DataSet refresh = base.GetData("READ_IN") as DataSet;

                            refresh.Tables.Remove("RSLTDT");

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01B_SER", refresh, "RQSTDT", "RSLTDT",
                                    QuickSearch,
                                    QuickException);

                        }
                    }
                    break;
                case "OUT":
                    {
                        if (base.IsData("READ_OUT"))
                        {
                            DataSet refresh = base.GetData("READ_OUT") as DataSet;

                            refresh.Tables.Remove("RSLTDT");

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER2", refresh, "RQSTDT", "RSLTDT",
                                    QuickSearchOut,
                                    QuickException);

                        }
                    }
                    break;
            }
        }

        void Search()
        {
            switch (acTabControl1.GetSelectedContainerName())
            {
                case "IN_NG":
                    {
                        btnProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("PART_LIKE", typeof(String)); //
                        paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

                        foreach (string key in cboDate.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "NG_DATE":

                                    //불량발생일

                                    paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];

                                    break;

                                case "DUE_DATE":

                                    //출하예정일
                                    paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                                    break;
                            }
                        }

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER", paramSet, "RQSTDT", "RSLTDT",
                                    QuickSearch,
                                    QuickException);
                    }
                    break;

                case "DES_C":
                    {
                        DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("PROD_LIKE", typeof(String)); //
                        paramTable.Columns.Add("S_NG_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_NG_DATE", typeof(String)); //
                        paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //


                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];

                        foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "NG_DATE":

                                    //불량발생일

                                    paramRow["S_NG_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_NG_DATE"] = layoutRow["E_DATE"];

                                    break;

                                case "DUE_DATE":

                                    //출하예정일
                                    paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                                    break;
                            }
                        }

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER4", paramSet, "RQSTDT", "RSLTDT",
                                    QuickSearchDes,
                                    QuickException);
                    }
                    break;

                case "OUT_NG":
                    {
                        btnProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("PART_LIKE", typeof(String)); //
                        paramTable.Columns.Add("S_INS_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_INS_DATE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "INS_DATE":

                                    //수입검사일
                                    paramRow["S_INS_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_INS_DATE"] = layoutRow["E_DATE"];

                                    break;
                            }
                        }

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                    QuickSearchOut,
                                    QuickException);
                    }
                    break;
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);
                //데이터 갱신
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "IN_NG":
                        this.DataRefresh("IN");
                        break;
                    case "OUT_NG":
                        this.DataRefresh("OUT");
                        break;
                }

            }
            else if (ex.ErrNumber == BizManager.BizException.CANNOT_DELETE)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), "불량 삭제", acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                base.SetData("READ_IN", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        void QuickSearchDes(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView3.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearchOut(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                base.SetData("READ_OUT", e.result);

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView2.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //불량조치대책 완료처리
            try
            {

                if (acMessageBox.Show("불량 처리 완료하시겠습니까?", "불량처리 완료", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "IN_NG":

                        acGridView1.EndEditor();


                        if (acGridView1.ValidFocusRowHandle() == false) return;

                        DataView selectedVIew = acGridView1.GetDataSourceView("SEL = '1'");

                        if (selectedVIew.Count == 0)
                        {
                            DataRow focusRow = acGridView1.GetFocusedDataRow();

                            if (focusRow["NG_STATE"].ToString() == "C")
                            {
                                acMessageBox.Show("이미 대책 완료 처리되었습니다.", "불량 처리", acMessageBox.emMessageBoxType.CONFIRM);
                                return;
                            }
                            QCT01A_D1A frm = new QCT01A_D1A(acGridView1, focusRow);

                            frm.ParentControl = this;

                            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                            base.ChildFormAdd(focusRow["NG_ID"], frm);

                            frm.Show(this);
                        }
                        else
                        {
                            DataTable paramTable2 = new DataTable("RQSTDT");

                            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable2.Columns.Add("WO_NO", typeof(String)); //
                            paramTable2.Columns.Add("WK_NG_QTY", typeof(Int32));
                            paramTable2.Columns.Add("NG_ID", typeof(String));
                            paramTable2.Columns.Add("REG_EMP", typeof(String));
                            paramTable2.Columns.Add("PROD_CODE", typeof(String));
                            paramTable2.Columns.Add("PART_CODE", typeof(String));
                            paramTable2.Columns.Add("NG_MEASURE_EMP", typeof(String));

                            for (int i = 0; i < selectedVIew.Count; i++)
                            {
                                DataRow paramRow2 = paramTable2.NewRow();
                                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow2["WO_NO"] = selectedVIew[i]["WO_NO"];
                                paramRow2["WK_NG_QTY"] = selectedVIew[i]["QUANTITY"];
                                paramRow2["NG_ID"] = selectedVIew[i]["NG_ID"];
                                paramRow2["REG_EMP"] = acInfo.UserID;
                                paramRow2["PROD_CODE"] = selectedVIew[i]["PROD_CODE"];
                                paramRow2["PART_CODE"] = selectedVIew[i]["PART_CODE"];
                                paramRow2["NG_MEASURE_EMP"] = selectedVIew[i]["NG_MEASURE_EMP"];
                                paramTable2.Rows.Add(paramRow2);
                            }

                            DataSet paramSet2 = new DataSet();
                            paramSet2.Tables.Add(paramTable2);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_INS2", paramSet2, "RQSTDT", "RSLTDT",
                                    QuickSave2,
                                    QuickException);
                        }
                        
                        break;

                    case "OUT_NG":

                        acGridView2.EndEditor();

                        if (acGridView2.ValidFocusRowHandle() == false) return;

                        DataRow focusRow2 = acGridView2.GetFocusedDataRow();

                        if (focusRow2["NG_STATE"].ToString() == "C")
                        {
                            acMessageBox.Show("이미 대책 완료 처리되었습니다.", "불량 처리", acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }

                        DataTable paramTable = new DataTable("RQSTDT");

                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("NG_ID", typeof(String)); //
                        paramTable.Columns.Add("NG_STATE", typeof(String));
                        
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["NG_ID"] = focusRow2["NG_ID"];
                        paramRow["NG_STATE"] = "C";
                        paramTable.Rows.Add(paramRow);

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_INS8", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);
                        break;
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickProcess(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickDelete(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickDelete2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show("등록된 불량 내역을 삭제하시겠습니까?", "불량 현황", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("NG_ID", typeof(String));
                dtParam.Columns.Add("WO_NO", typeof(String));
                dtParam.Columns.Add("QUANTITY", typeof(int));

                if (selectedView.Count == 0)
                {
                    DataRow drParam = dtParam.NewRow();
                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["NG_ID"] = focusRow["NG_ID"];
                    drParam["WO_NO"] = focusRow["WO_NO"];
                    drParam["QUANTITY"] = focusRow["QUANTITY"];

                    dtParam.Rows.Add(drParam);
                }
                else
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow drParam = dtParam.NewRow();
                        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                        drParam["NG_ID"] = selectedView[i]["NG_ID"];
                        drParam["WO_NO"] = selectedView[i]["WO_NO"];
                        drParam["QUANTITY"] = selectedView[i]["QUANTITY"];

                        dtParam.Rows.Add(drParam);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01B_INS3", paramSet, "RQSTDT", "RSLTDT",
                        QuickDelete,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //확정 불량 수량 변경 처리
            try
            {
                acGridView1.EndEditor();

                if (acGridView1.ValidFocusRowHandle() == false) return;

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                //if (focusRow["WK_NG_QTY"].toInt() == 0)
                //{
                //    acMessageBox.Show("확정 불량 수량이 0입니다. 불량 처리를 먼저 하세요.", e.Item.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}
                if (focusRow["NG_STATE"].ToString() != "C")
                {
                    acMessageBox.Show("대책 완료 처리를 먼저 하세요.", "불량 처리", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                QCT01A_D2A frm = new QCT01A_D2A(acGridView1, focusRow);

                frm.ParentControl = this;

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd(focusRow["NG_ID"], frm);

                frm.Show(this);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnNgReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string saveDir = fbd.SelectedPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    if (Directory.Exists(saveDir) == false)
                    {
                        Directory.CreateDirectory(saveDir);
                    }

                    switch (acTabControl1.GetSelectedContainerName())
                    {
                        case "IN_NG":
                            {
                                DataView selView = acGridView1.GetDataSourceView("SEL='1'");

                                if (selView.Count == 0)
                                {
                                    DataRow focusRow = acGridView1.GetFocusedDataRow();
                                    this.saveInNgReport(focusRow, saveDir);
                                }
                                else
                                {
                                    foreach (DataRowView rowView in selView)
                                    {
                                        this.saveInNgReport(rowView.Row, saveDir);
                                    }
                                }
                            }
                            break;
                        case "OUT_NG":
                            {
                                DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                                if (selView.Count == 0)
                                {
                                    DataRow focusRow = acGridView2.GetFocusedDataRow();
                                    this.saveOutNgReport(focusRow, saveDir);
                                }
                                else
                                {
                                    foreach (DataRowView rowView in selView)
                                    {
                                        this.saveOutNgReport(rowView.Row, saveDir);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void saveInNgReport(DataRow row, string savePath)
        {
            try
            {
                using (SpreadsheetControl spreadCon = new SpreadsheetControl())
                {
                    spreadCon.LoadDocument(Resources.IN_NG_, DevExpress.Spreadsheet.DocumentFormat.Xls);

                    using (IWorkbook workbook = spreadCon.Document)
                    {
                        //부적합 보고서
                        Worksheet gabReport = workbook.Worksheets[0];


                        //부적합구분
                        foreach (DataRow gubunRow in acStdCodes.GetCatTableByServer("Q005").Rows)
                        {
                            if (gubunRow["CD_CODE"].ToString().Equals(row["NG_CAT"]))
                            {
                                gabReport.Columns["F"][4].Value += " ■ " + gubunRow["CD_NAME"] + " ";
                            }
                            else
                            {
                                gabReport.Columns["F"][4].Value += " □ " + gubunRow["CD_NAME"] + " ";
                            }
                        }

                        //수주코드
                        gabReport.Columns["F"][7].Value = row["ITEM_CODE"].toStringEmpty();
                        //수주처명
                        gabReport.Columns["F"][8].Value = row["CVND_NAME"].toStringEmpty();
                        //발생처
                        gabReport.Columns["V"][7].Value = row["NG_OCCUR"].toStringEmpty();
                        //발생일자
                        gabReport.Columns["AK"][7].Value = row["WORK_DATE"].toDateString("yyyy-MM-dd");
                        //품목명
                        gabReport.Columns["F"][9].Value = row["PART_NAME"].toStringEmpty();
                        //발생 공정
                        gabReport.Columns["V"][9].Value = row["PROC_NAME"].toStringEmpty();
                        //관리자
                        gabReport.Columns["AK"][9].Value = row["EMP_NAME"].toStringEmpty();
                        //품목코드
                        gabReport.Columns["F"][11].Value = row["PART_CODE"].toStringEmpty();
                        //불량수량
                        gabReport.Columns["V"][11].Value = row["QUANTITY"].toStringEmpty();//분자
                        gabReport.Columns["AB"][11].Value = row["PART_QTY"].toStringEmpty();//분모
                        //작업자
                        gabReport.Columns["AK"][11].Value = row["NG_MEASURE_EMP_NAME"].toStringEmpty();
                        //불량 내용
                        gabReport.Columns["C"][16].Value = row["NG_CONTENTS"].toStringEmpty();
                        //불량 원인
                        gabReport.Columns["C"][28].Value = row["NG_CAUSE"].toStringEmpty();
                        //약도 - 작업자
                        gabReport.Columns["AA"][15].Value = row["NG_MEASURE_EMP_NAME"].toStringEmpty();
                        //약도 - 기계
                        gabReport.Columns["AA"][17].Value = row["MC_NAME"].toStringEmpty();
                        //처리
                        foreach (DataRow gubunRow in acStdCodes.GetCatTableByServer("Q004").Rows)
                        {
                            if (gubunRow["CD_CODE"].ToString().Equals(row["NG_TYPE"]))
                            {
                                gabReport.Columns["C"][41].Value += " ■ " + gubunRow["CD_NAME"] + " ";
                            }
                            else
                            {
                                gabReport.Columns["C"][41].Value += " □ " + gubunRow["CD_NAME"] + " ";
                            }
                        }
                        //불량대책
                        gabReport.Columns["G"][45].Value = row["NG_MEASURE"].toStringEmpty();
                        //확인결과
                        //gabReport.Columns["AH"][53].Value = row["FEMP_NAME"].toStringEmpty();
                        //확인자
                        //gabReport.Columns["AH"][56].Value = row["FEMP_NAME"].toStringEmpty();
                        //확인일자
                        //gabReport.Columns["AH"][59].Value = row["FEMP_NAME"].toStringEmpty();
                        //소재비
                        gabReport.Columns["C"][62].Value = row["NG_MAT_COST"].toStringEmpty();
                        //인건비 => 재작업비용 이름 변경
                        gabReport.Columns["AE"][62].Value = row["NG_LAB_COST"].toStringEmpty();
                        //물류비 => 대책비용 이름 변경
                        gabReport.Columns["AJ"][62].Value = row["NG_DIST_COST"].toStringEmpty();
                        //사내비용
                        gabReport.Columns["Y"][62].Value = row["NG_PROC_COST"].toStringEmpty();
                        //외주비용
                        gabReport.Columns["S"][64].Value = row["NG_OUT_COST"].toStringEmpty();
                        //비용합계
                        gabReport.Columns["AN"][62].Value = row["NG_COST"].toStringEmpty();

                        workbook.SaveDocument(savePath + "\\" + row["LINK_KEY"] + ".xlsx");
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void saveOutNgReport(DataRow row, string savePath)
        {
            try
            {
                using (SpreadsheetControl spreadCon = new SpreadsheetControl())
                {
                    spreadCon.LoadDocument(Resources.OUT_NG, DevExpress.Spreadsheet.DocumentFormat.Xls);
                    //부적합 보고서
                    using (IWorkbook workbook = spreadCon.Document)
                    {
                        Worksheet gabReport = workbook.Worksheets[0];


                        //부적합구분
                        foreach (DataRow gubunRow in acStdCodes.GetCatTableByServer("Q005").Rows)
                        {
                            // if (gubunRow["CD_CODE"].ToString().Equals(row["NG_CAT"]))
                            if (gubunRow["CD_NAME"].ToString().Equals("외주"))
                            {
                                gabReport.Columns["F"][4].Value += " ■ " + gubunRow["CD_NAME"] + " ";
                            }
                            else
                            {
                                gabReport.Columns["F"][4].Value += " □ " + gubunRow["CD_NAME"] + " ";
                            }
                        }

                        //수주코드
                        gabReport.Columns["F"][7].Value = row["ITEM_CODE"].toStringEmpty();
                        //수주처명
                        gabReport.Columns["F"][8].Value = row["CVND_NAME"].toStringEmpty();
                        //발생처
                        gabReport.Columns["V"][7].Value = row["VEN_NAME"].toStringEmpty();
                        //발생일자
                        gabReport.Columns["AK"][7].Value = row["INS_DATE"].toDateString("yyyy-MM-dd");
                        //품목명
                        gabReport.Columns["F"][9].Value = row["PART_NAME"].toStringEmpty();
                        //발생 공정
                        gabReport.Columns["V"][9].Value = row["PROC_NAME"].toStringEmpty();
                        //관리자
                        gabReport.Columns["AK"][9].Value = row["EMP_NAME"].toStringEmpty();
                        //품목코드
                        gabReport.Columns["F"][11].Value = row["PART_CODE"].toStringEmpty();
                        //불량수량
                        gabReport.Columns["V"][11].Value = row["NG_QTY"].toStringEmpty();//분자
                        gabReport.Columns["AB"][11].Value = row["PART_QTY"].toStringEmpty();//분모
                        //작업자
                        //gabReport.Columns["AK"][11].Value = row["NG_MEASURE_EMP_NAME"].toStringEmpty();
                        //불량 내용
                        gabReport.Columns["C"][16].Value = row["NG_CONTENTS"].toStringEmpty();
                        //불량 원인
                        gabReport.Columns["C"][28].Value = row["NG_CAUSE"].toStringEmpty();
                        //약도 - 작업자
                        //gabReport.Columns["AA"][15].Value = row["NG_MEASURE_EMP_NAME"].toStringEmpty();
                        //약도 - 기계
                        //gabReport.Columns["AA"][17].Value = row["MC_NAME"].toStringEmpty();
                        //처리
                        foreach (DataRow gubunRow in acStdCodes.GetCatTableByServer("Q006").Rows)
                        {
                            if (gubunRow["CD_CODE"].ToString().Equals(row["NG_TYPE"]))
                            {
                                gabReport.Columns["C"][41].Value += " ■ " + gubunRow["CD_NAME"] + " ";
                            }
                            else
                            {
                                gabReport.Columns["C"][41].Value += " □ " + gubunRow["CD_NAME"] + " ";
                            }
                        }
                        //불량대책
                        gabReport.Columns["G"][45].Value = row["NG_MEASURE"].toStringEmpty();
                        //확인결과
                        //gabReport.Columns["AH"][53].Value = row["FEMP_NAME"].toStringEmpty();
                        //확인자
                        //gabReport.Columns["AH"][56].Value = row["FEMP_NAME"].toStringEmpty();
                        //확인일자
                        //gabReport.Columns["AH"][59].Value = row["FEMP_NAME"].toStringEmpty();
                        //소재비
                        //gabReport.Columns["C"][62].Value = row["NG_MAT_COST"].toStringEmpty();
                        //인건비 => 재작업비용 이름 변경
                        //gabReport.Columns["AE"][62].Value = row["NG_LAB_COST"].toStringEmpty();
                        //물류비 => 대책비용 이름 변경
                        //gabReport.Columns["AJ"][62].Value = row["NG_DIST_COST"].toStringEmpty();
                        //사내비용
                        //gabReport.Columns["Y"][62].Value = row["NG_PROC_COST"].toStringEmpty();
                        //외주비용
                        gabReport.Columns["S"][64].Value = row["NG_COST"].toStringEmpty();
                        //비용합계
                        gabReport.Columns["AN"][62].Value = row["NG_COST"].toStringEmpty();

                        workbook.SaveDocument(savePath + "\\" + row["TYP_ID"] + ".xlsx");
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show("등록된 불량 내역을 삭제하시겠습니까?", "불량 현황", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("NG_ID", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["NG_ID"] = focusRow["NG_ID"];

                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01B_INS5", paramSet, "RQSTDT", "RSLTDT",
                        QuickDelete2,
                        QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public void Menu_Link(DataRow focusRow, string sMenu)
        {
            Main.MoveLinkMenu(sMenu, focusRow);
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModifyNg();
        }
    }
}
