using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace MAT
{
    public partial class MAT02A_M0A : BaseMenu
    {
        //DataTable _dtPTList = null;

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public MAT02A_M0A()
        {
            InitializeComponent();
        }
        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("PROD_CODE", "내부관리번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                //acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView1.AddLookUpEdit("MAT_TYPE", "자재 형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                acGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddTextEdit("OUT_REQ_QTY", "기존 요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("O_PART_QTY", "세트수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("PROD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("QTY", "요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddLookUpEdit("WO_FLAG", "조립 작업상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                acGridView1.AddTextEdit("SUPP_VND", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SUPP_VND_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "PT_ID", "PART_CODE" };



                acGridView6.GridType = acGridView.emGridType.SEARCH;
                acGridView6.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView6.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

                acGridView6.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView6.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView6.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView6.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView6.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView6.AddLookUpEdit("MAT_TYPE", "자재 형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                acGridView6.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView6.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView6.AddTextEdit("SAFE_STK_QTY", "안전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView6.AddTextEdit("SUPP_VND", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView6.AddTextEdit("SUPP_VND_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView6.KeyColumn = new string[] {"PART_CODE" };


                acGridView4.GridType = acGridView.emGridType.SEARCH;
                acGridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView4.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView4.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("O_PART_QTY", "세트수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("PROD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("QTY", "요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.Columns["SCOMMENT"].MinWidth = 100;
                acGridView4.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddTextEdit("SAFE_STK_QTY", "안전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView4.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView4.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView4.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView4.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpEdit("MAT_TYPE", "자재 형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                acGridView4.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                //acGridView4.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);

                acGridView4.AddLookUpEdit("WO_FLAG", "조립 작업상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S032");

                acGridView4.AddTextEdit("SUPP_VND", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("SUPP_VND_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView4.KeyColumn = new string[] { "PT_ID", "PART_CODE" };

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddTextEdit("QTY", "요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, true, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.Columns["SCOMMENT"].MinWidth = 100;

                acGridView2.KeyColumn = new string[] { "PART_CODE" };

                acGridView2.Columns["QTY"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0}");

                acGridView2.OptionsView.ShowFooter = true;

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView3.OptionsView.ShowIndicator = true;

                acGridView3.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView3.AddTextEdit("OUT_REQ_ID", "불출요청ID", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView3.AddTextEdit("STOCK_NAME", "불출창고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("OUT_REQ_DATE", "불출요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("OUT_REQ_EMP", "불출요청인", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("OUT_REQ_QTY", "요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);
                //acGridView3.AddDateEdit("OUT_DATE", "불출입고일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, "M001");
                acGridView3.AddLookUpEdit("OUT_REQ_STAT", "요청 상태", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S043");
                acGridView3.AddLookUpEdit("OUT_REQ_LOC", "사용처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M017");

                acGridView3.AddLookUpEdit("WO_FLAG", "조립 작업상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.KeyColumn = new string[] { "OUT_REQ_ID" };


                acGridView5.GridType = acGridView.emGridType.SEARCH;
                acGridView5.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView5.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView5.AddTextEdit("PT_ID", "부품ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView5.AddTextEdit("PROD_CODE", "내부관리번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView5.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                //acGridView5.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView5.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView5.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView5.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView5.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView5.AddLookUpEdit("MAT_TYPE", "자재 형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                acGridView5.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView5.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView5.AddLookUpPart("MAT_CODE", "소재", DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView5.AddTextEdit("OUT_REQ_QTY", "기존 요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView5.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView5.AddTextEdit("STOCK_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView5.AddTextEdit("SAFE_STK_QTY", "안전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView5.KeyColumn = new string[] { "PT_ID", "PART_CODE" };


                acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
                acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;
                acGridView4.ShowGridMenuEx += AcGridView4_ShowGridMenuEx;//
                acGridView5.ShowGridMenuEx += AcGridView5_ShowGridMenuEx;

                acGridView6.ShowGridMenuEx += acGridView6_ShowGridMenuEx;

                acGridView1.SelectionChanged += acGridView1_SelectionChanged;

                acGridView1.MouseDown += AcGridView1_MouseDown;
                acGridView2.MouseDown += AcGridView2_MouseDown;
                acGridView4.MouseDown += AcGridView4_MouseDown;
                acGridView6.MouseDown += AcGridView6_MouseDown;

                acGridView4.CellValueChanged += AcGridView4_CellValueChanged;

                acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

                acLayoutControl1.OnValueKeyDown += acLayoutControl_OnValueKeyDown;
                acLayoutControl2.OnValueKeyDown += acLayoutControl_OnValueKeyDown;

                acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
                acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;

                (acLayoutControl1.GetEditor("MAT_TYPE") as acLookupEdit).SetCode("S016");
                (acLayoutControl2.GetEditor("MAT_TYPE") as acLookupEdit).SetCode("S016");

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");
                (acLayoutControl2.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

                (acLayoutControl2.GetEditor("STOCK_CODE") as acLookupEdit).SetCode("M005");

                acTabControl2.SelectedPageChanged += AcTabControl2_SelectedPageChanged;

                acCheckedComboBoxEdit2.AddItem("불출 요청일", false, "", "OUT_REQ_DATE", true, false, CheckState.Checked);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acGridView2.ClearRow();
            acGridView4.ClearRow();

            if (acTabControl2.GetSelectedContainerName() == "B")
            {
                acGridView4.Columns["PROD_CODE"].OptionsColumn.AllowEdit = false;
            }
            else if (acTabControl2.GetSelectedContainerName() == "P")
            {
                acGridView4.Columns["PROD_CODE"].OptionsColumn.AllowEdit = true;
            }


        }

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    if (newValue == null)
                    {
                        layout.GetEditor("MAT_MTYPE").Value = null;
                    }

                    (layout.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015", newValue);

                    break;

                case "MAT_MTYPE":

                    if (newValue == null)
                    {
                        layout.GetEditor("MAT_STYPE").Value = null;
                    }

                    (layout.GetEditor("MAT_STYPE") as acLookupEdit).SetCode("M016", newValue);

                    break;
            }
        }

        private void AcLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":
                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.
                    if (newValue.EqualsEx(string.Empty))
                    {
                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;
                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

                case "MAT_LTYPE":

                    if (newValue == null)
                    {
                        layout.GetEditor("MAT_MTYPE").Value = null;
                    }

                    (layout.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015", newValue);

                    break;

                case "MAT_MTYPE":

                    if (newValue == null)
                    {
                        layout.GetEditor("MAT_STYPE").Value = null;
                    }

                    (layout.GetEditor("MAT_STYPE") as acLookupEdit).SetCode("M016", newValue);

                    break;
            }
        }
      
        public override void ChildContainerInit(Control sender)
        {
            acLayoutControl layout = sender as acLayoutControl;

            if (sender == acLayoutControl1)
            {
                layout.GetEditor("IS_MAIN").Value = "1";
            }
            else if (sender == acLayoutControl2)
            {
                layout.GetEditor("DATE").Value = "OUT_REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();

            }

            //acLayoutControl1.GetEditor("MAT_LTYPE").Value = "22";

            base.ChildContainerInit(sender);
        }
        private void AcGridView4_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;
                if (view == null) return;

                DataRow row = view.GetDataRow(e.RowHandle);

                switch (e.Column.FieldName)
                {
                    case "QTY":
                        {
                            //decimal sumQty = view.GetDataSourceView("PART_CODE = '" + row["PART_CODE"] + "'").ToTable().SUM("QTY");
                            //DataRow partRow = acGridView2.GetDataRow("PART_CODE = '" + row["PART_CODE"] + "'");
                            //partRow["QTY"] = sumQty;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView4_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnUnselectPart.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnUnselectPart.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                btnUnselectPart.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView5_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu4.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView6_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    PTSelect2(true);
                }
            }
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    PartUnSelect(true);
                }
            }
        }

        private void AcGridView4_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    if (acTabControl2.GetSelectedContainerName() == "B")
                    {
                        PTUnSelect(true);
                    }
                    else
                    {
                        PTUnSelect2(true);
                    }
                }
            }
        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    PTSelect(true);
                }
            }
        }

        void acGridView6_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu5.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if(e.MenuType == GridMenuType.User)
            {
                btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnUnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnUnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }
            else if (e.MenuType == GridMenuType.User)
            {
                btnUnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                int[] SelectionIdx = acGridView1.GetSelectedRows();

                if (SelectionIdx.Length != 1)
                {

                    foreach (DataRow row in acGridView1.GetSelectedDataRows())
                    {
                        row["SEL"] = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (acTabControl1.SelectedTabPage == acTabPage1)
                {
                    btnPartReq.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnModify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnPartReq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnModify.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        void Search()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "B":
                        {
                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("PROD_LIKE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("MAT_TYPE", typeof(String));
                            dtSearch.Columns.Add("MAT_LTYPE", typeof(String));
                            dtSearch.Columns.Add("MAT_MTYPE", typeof(String));
                            dtSearch.Columns.Add("MAT_STYPE", typeof(String));
                            dtSearch.Columns.Add("IS_QTY_ZERO", typeof(String));
                            dtSearch.Columns.Add("OUT_DEL_FLAG", typeof(byte));
                            dtSearch.Columns.Add("REQ_TYPE", typeof(String));
                            dtSearch.Columns.Add("IS_MAIN", typeof(String)); // 

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];
                            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                            paramRow["OUT_DEL_FLAG"] = 0;

                            if (layoutRow["IS_QTY_ZERO"].toInt() == 0)
                            {
                                paramRow["IS_QTY_ZERO"] = layoutRow["IS_QTY_ZERO"];
                            }
                            paramRow["REQ_TYPE"] = acTabControl2.GetSelectedContainerName();

                            if (layoutRow["IS_MAIN"].ToString() == "1")
                            {
                                paramRow["IS_MAIN"] = "1";
                            }

                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT02A_SER", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch,
                                        QuickException);
                            break;
                        }
                    case "BL":
                        {
                            if (acLayoutControl2.ValidCheck() == false)
                            {
                                return;
                            }

                            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("STOCK_CODE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("S_DATE", typeof(String));
                            dtSearch.Columns.Add("E_DATE", typeof(String));

                            dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("MAT_TYPE", typeof(String));
                            dtSearch.Columns.Add("PART_PROD_LIKE", typeof(String));
                            dtSearch.Columns.Add("SCOMMENT_LIKE", typeof(String));

                            dtSearch.Columns.Add("PROD_LIKE", typeof(String));
                            dtSearch.Columns.Add("MAT_LTYPE", typeof(String));
                            dtSearch.Columns.Add("MAT_MTYPE", typeof(String));
                            dtSearch.Columns.Add("MAT_STYPE", typeof(String));

                            dtSearch.Columns.Add("IS_OUT", typeof(String));


                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["STOCK_CODE"] = layoutRow["STOCK_CODE"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                            {
                                switch (key)
                                {
                                    case "OUT_REQ_DATE":
                                        paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                                        paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                                        break;

                                }
                            }

                            paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];
                            paramRow["PART_PROD_LIKE"] = layoutRow["PART_PROD_LIKE"];
                            paramRow["IS_OUT"] = layoutRow["IS_OUT"];

                            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];

                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT02A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch2,
                                        QuickException);
                            break;
                        }
                    case "BC":
                        {
                            DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("OUT_DEL_FLAG", typeof(byte));
                            dtSearch.Columns.Add("REQ_TYPE", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["OUT_DEL_FLAG"] = 1;
                            paramRow["REQ_TYPE"] = "B";

                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT02A_SER", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch3,
                                        QuickException);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dtPT = acGridView4.GridControl.DataSource as DataTable;

                if (dtPT != null)
                {
                    for (int i = 0; i < dtPT.Rows.Count; i++)
                    {
                        string filter = string.Format("PT_ID = '{0}' AND PART_CODE = '{1}'", dtPT.Rows[i]["PT_ID"], dtPT.Rows[i]["PART_CODE"]);
                        DataRow[] serRows = e.result.Tables["RSLTDT"].Select(filter);
                        if (serRows.Length > 0)
                        {
                            foreach (DataRow row in serRows)
                            {
                                e.result.Tables["RSLTDT"].Rows.Remove(row);
                            }
                        }
                    }
                }

                if (e.result.Tables["RQSTDT"].Rows[0]["REQ_TYPE"].ToString() == "B")
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }
                else if (e.result.Tables["RQSTDT"].Rows[0]["REQ_TYPE"].ToString() == "P")
                {
                    acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT"];
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnPartReq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();
                acGridView4.EndEditor();

                acGridView view = acGridView4;

                if (view.GetDataSourceView("QTY=0").Count >0)
                {
                    acMessageBox.Show(this, "요청 수량은 최소 1이상 이어야합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (view.GetSelectedDataRows().Length == 0)
                {
                    acAlert.Show(this, "불출 요청 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                if (view.ValidCheck() == false) return;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PART_CODE_IN", typeof(string));

                DataTable dtPartSource = view.GetDataView().ToTable();

                string partCodeIn = "";

                foreach (DataRow dr in dtPartSource.Select())
                {
                    partCodeIn += dr["PART_CODE"].ToString() + ",";
                }

                DataSet resultSet = new DataSet();

                if (partCodeIn.Length > 0)
                {
                    partCodeIn = partCodeIn.Substring(0, partCodeIn.Length - 1);

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE_IN"] = partCodeIn;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    resultSet = BizRun.QBizRun.ExecuteService(this, "MAT02A_SER3", paramSet, "RQSTDT", "RSLTDT");
                }

                bool isStockFree = false;

                if (resultSet.Tables.Count > 0)
                {
                    if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        //비교 팝업
                        MAT02A_D1A frm = new MAT02A_D1A(resultSet.Tables["RSLTDT"]);
                        frm.ParentControl = this;
                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            isStockFree = true;
                        }
                        else
                        {
                            isStockFree = false;
                        }

                    }
                    else
                    {
                        isStockFree = true;
                    }
                }
                else
                {
                    isStockFree = true;
                }

                if (isStockFree)
                {
                    //불출요청
                    matOutReq();
                }    
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void matOutReq()
        {
            acGridView view = acGridView4;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            MAT02A_D0A frm = new MAT02A_D0A(layoutRow);

            frm.ParentControl = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = (DataRow)frm.OutputData;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                dtParam.Columns.Add("PT_ID", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("STOCK_CODE", typeof(String));
                dtParam.Columns.Add("OUT_REQ_DATE", typeof(String));
                dtParam.Columns.Add("OUT_REQ_EMP", typeof(String));
                dtParam.Columns.Add("OUT_REQ_QTY", typeof(int));
                dtParam.Columns.Add("OUT_REQ_STAT", typeof(String));
                dtParam.Columns.Add("SCOMMENT", typeof(String));
                dtParam.Columns.Add("PART_NAME", typeof(String));
                dtParam.Columns.Add("REG_EMP", typeof(String));
                dtParam.Columns.Add("PUR_ORG", typeof(String));
                dtParam.Columns.Add("REQ_ORG_NAME", typeof(String));

                dtParam.Columns.Add("PROD_CODE", typeof(String));

                DataTable dtSource = view.GetDataView().ToTable();

                foreach (DataRow dr in dtSource.Select())
                {
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["PART_CODE"] = dr["PART_CODE"];
                    drParam["PT_ID"] = dr["PT_ID"];
                    //drParam["STOCK_CODE"] = frmRow["STOCK_CODE"];
                    drParam["OUT_REQ_DATE"] = frmRow["OUT_REQ_DATE"];
                    drParam["OUT_REQ_EMP"] = frmRow["OUT_REQ_EMP"];
                    drParam["OUT_REQ_QTY"] = dr["QTY"];
                    drParam["OUT_REQ_STAT"] = "50";
                    drParam["SCOMMENT"] = dr["SCOMMENT"];
                    drParam["REG_EMP"] = acInfo.UserID;
                    drParam["REQ_ORG_NAME"] = frmRow["ORG_NAME"];
                    drParam["PROD_CODE"] = dr["PROD_CODE"];
                    dtParam.Rows.Add(drParam);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT02A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);
            }
        }

        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PTSelect(false);
        }
        void PTSelect(bool isDoubleClick)
        {
            try
            {
                acGridView1.EndEditor();

                //다중선택
                DataTable dtOrigin = acGridView2.GridControl.DataSource as DataTable;
                if(dtOrigin == null)
                {
                    acGridView2.GridControl.DataSource = acGridView2.DefaultTable;
                    dtOrigin = acGridView2.DefaultTable;
                }
                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0 || isDoubleClick== true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();
                    if (focusRow == null) return;

                    string partCode = focusRow["PART_CODE"].toStringEmpty();
                    DataRow[] rows = dtOrigin.Select(string.Format("PART_CODE = '{0}'", focusRow["PART_CODE"].ToString()));

                    if (rows.Length > 0)
                    {
                        rows[0]["QTY"] = rows[0]["QTY"].toInt() + focusRow["PART_QTY"].toInt();
                        acGridView2.UpdateMapingRow(rows[0], false);
                    }
                    else
                    {
                        DataRow newrow = dtOrigin.NewRow();
                        newrow["PART_CODE"] = focusRow["PART_CODE"];
                        newrow["PART_NAME"] = focusRow["PART_NAME"];
                        newrow["QTY"] = focusRow["PART_QTY"];
                        newrow["STOCK_QTY"] = focusRow["STOCK_QTY"];
                        acGridView2.UpdateMapingRow(newrow, true);
                    }

                    //DataRow delRow = acgridview4.NewRow();
                    //delRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //delRow["PT_ID"] = focusRow["PT_ID"];
                    //delRow["PART_CODE"] = focusRow["PART_CODE"];
                    //_dtPTList.Rows.Add(delRow);
                    DataRow copyFocusRow = focusRow.NewCopy();
                    copyFocusRow["SEL"] = "0";
                    acGridView4.UpdateMapingRow(copyFocusRow, true);

                    if (focusRow["PT_ID"].ToString() != "")
                        acGridView1.DeleteMappingRow(focusRow);

                    //acAlert.Show(this,"["+partCode + "] 요청 목록에 추가", acAlertForm.enmType.Info);
                }
                else
                {
                    int cnt = selectedView.Count;

                    foreach (DataRowView drv in selectedView)
                    {

                        DataRow[] rows = dtOrigin.Select(string.Format("PART_CODE = '{0}'", drv["PART_CODE"].ToString()));

                        if (rows.Length > 0)
                        {
                            rows[0]["QTY"] = rows[0]["QTY"].toInt() + drv["PART_QTY"].toInt();
                            acGridView2.UpdateMapingRow(rows[0], false);
                        }
                        else
                        {
                            DataRow newrow = dtOrigin.NewRow();
                            newrow["PART_CODE"] = drv["PART_CODE"];
                            newrow["PART_NAME"] = drv["PART_NAME"];
                            newrow["QTY"] = drv["PART_QTY"];
                            newrow["STOCK_QTY"] = drv["STOCK_QTY"];
                            acGridView2.UpdateMapingRow(newrow, true);
                        }
                    }

                    DataTable dtSelected = acGridView1.GridControl.DataSource as DataTable;

                    DataRow[] drSelected = dtSelected.Select("SEL = '1'");

                    foreach (DataRow dr in drSelected)
                    {
                        
                        DataRow copyFocusRow = dr.NewCopy();
                        copyFocusRow["SEL"] = "0";
                        acGridView4.UpdateMapingRow(copyFocusRow, true);

                        if (dr["PT_ID"].ToString() != "")
                            acGridView1.DeleteMappingRow(dr);
                    }

                    //acAlert.Show(this, cnt + "개 요청 목록에 추가", acAlertForm.enmType.Info);

                }
                acGridView2.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnUnselect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PartUnSelect(false);
        }


        void PartUnSelect(bool isDoubleClick)
        {
            try
            {
                acGridView2.EndEditor();

                DataView selectedView = acGridView2.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0 || isDoubleClick == true)
                {
                    //단일선택

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (focusRow != null)
                    {

                        DataRow row = focusRow.NewCopy();

                        row["SEL"] = "0";

                        acGridView2.DeleteMappingRow(row);

                        DataView partView = acGridView4.GetDataSourceView("PART_CODE = '" + row["PART_CODE"] + "'");
                        int cnt = partView.Count;
                        foreach (DataRowView delRow in partView)
                        {
                            delRow.Delete();
                        }

                        //acAlert.Show(this, cnt + "개 요청 목록에서 제거", acAlertForm.enmType.Info);
                    }
                }
                else
                {
                    //다중선택

                    int cnt = selectedView.Count;
                    int totCnt = 0;
                    for (int i = 0; i < cnt; i++)
                    {

                        DataRow row = selectedView[0].Row.NewCopy();

                        row["SEL"] = "0";

                        acGridView2.DeleteMappingRow(row);

                        DataView partView = acGridView4.GetDataSourceView("PART_CODE = '" + row["PART_CODE"] + "'");
                        totCnt += partView.Count;

                        foreach (DataRowView delRow in partView)
                        {
                            delRow.Delete();
                        }
                    }
                    //acAlert.Show(this, totCnt + "개 요청 목록에서 제거", acAlertForm.enmType.Info);
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
                acGridView2.ClearRow();
                acGridView4.ClearRow();

                //foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    acGridView1.UpdateMapingRow(row, true);
                //}

                acAlert.Show(this, "불출요청 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                

                acGridView3.EndEditor();

                if (acGridView3.GetSelectedDataRows().Length == 0)
                {
                    acAlert.Show(this, "불출 요청 취소 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                if (acMessageBox.Show("선택한 불출 요청을 취소하시겠습니까?", "불출 요청 취소", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                dtParam.Columns.Add("PT_ID", typeof(String));
                dtParam.Columns.Add("OUT_REQ_LOC", typeof(String));
                dtParam.Columns.Add("PROD_CODE", typeof(String));
                dtParam.Columns.Add("DEL_EMP", typeof(String));

                DataTable dtSource = acGridView3.GetDataView("SEL = '1'").ToTable();

                foreach (DataRow dr in dtSource.Select())
                {
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["OUT_REQ_ID"] = dr["OUT_REQ_ID"];
                    drParam["PT_ID"] = dr["PT_ID"];
                    drParam["OUT_REQ_LOC"] = dr["OUT_REQ_LOC"];
                    drParam["PROD_CODE"] = dr["PROD_CODE"];
                    drParam["DEL_EMP"] = acInfo.UserID;

                    dtParam.Rows.Add(drParam);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT02A_DEL", paramSet, "RQSTDT", "RSLTDT",
                            QuickDel,
                            QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }
                acAlert.Show(this, "불출 취소 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show("선택한 불출 요청 내역을 수정하시겠습니까?", "불출 요청 수정", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    return;

                acGridView3.EndEditor();

                DataTable dtSource = acGridView3.GetDataView("SEL = '1'").ToTable();

                if (dtSource.Rows.Count <= 0) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                dtParam.Columns.Add("OUT_REQ_QTY", typeof(int));
                dtParam.Columns.Add("SCOMMENT", typeof(String));
                dtParam.Columns.Add("MDFY_EMP", typeof(String));


                foreach (DataRow dr in dtSource.Select())
                {
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["OUT_REQ_ID"] = dr["OUT_REQ_ID"];
                    drParam["OUT_REQ_QTY"] = dr["OUT_REQ_QTY"];
                    drParam["SCOMMENT"] = dr["SCOMMENT"];
                    drParam["MDFY_EMP"] = acInfo.UserID;

                    dtParam.Rows.Add(drParam);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT02A_UPD", paramSet, "RQSTDT", "RSLTDT",
                            QuickUpdate,
                            QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUpdate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.UpdateMapingRow(row, false);
                }

                acAlert.Show(this, "내역 수정 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnUnselectPart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acTabControl2.GetSelectedContainerName() == "B")
            {
                PTUnSelect(false);
            }
            else
            {
                PTUnSelect2(false);
            }
            
        }

        void PTUnSelect(bool isDoubleClick)
        {
            try
            {
                acGridView4.EndEditor();

                DataView selectedView = acGridView4.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0 || isDoubleClick == true)
                {
                    DataRow focusRow = acGridView4.GetFocusedDataRow();
                    if (focusRow == null) return;
                    string partCode = focusRow["PART_CODE"].toStringEmpty();
                    DataView partView = acGridView2.GetDataSourceView(string.Format("PART_CODE = '{0}'", focusRow["PART_CODE"].ToString()));

                    if (partView.Count > 0)
                    {
                        foreach(DataRowView partRow in partView)
                        {
                            if(partRow["QTY"].toInt() == focusRow["QTY"].toInt())
                            {
                                partRow.Delete();
                            }
                            else
                            {
                                partRow["QTY"] = partRow["QTY"].toDecimal() - focusRow["QTY"].toDecimal();
                            }
                        }
                    }
                    acGridView1.UpdateMapingRow(focusRow, true);
                    acGridView4.DeleteMappingRow(focusRow);

                    //acAlert.Show(this, "[" + partCode + "] 요청 목록에서 제거", acAlertForm.enmType.Info);
                }
                else
                {
                    int cnt = selectedView.Count;

                    acGridView1.UpdateMapingRowLinq(selectedView.ToTable(), true);
                    foreach (DataRowView drv in selectedView)
                    {
                        DataView partView = acGridView2.GetDataSourceView(string.Format("PART_CODE = '{0}'", drv["PART_CODE"].ToString()));

                        if (partView.Count > 0)
                        {
                            foreach (DataRowView partRow in partView)
                            {
                                if (partRow["QTY"].toInt() == drv["QTY"].toInt())
                                {
                                    partRow.Delete();
                                }
                                else
                                {
                                    partRow["QTY"] = partRow["QTY"].toDecimal() - drv["QTY"].toDecimal();
                                }
                            }
                        }

                        drv.Delete();
                    }
                    //acAlert.Show(this, cnt +"개 요청 목록에서 제거", acAlertForm.enmType.Info);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            DataRow focusRow = acGridView1.GetFocusedDataRow();
            if (focusRow == null) return;

            DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("PART_CODE", typeof(string));
            paramTable.Columns.Add("OUT_DEL_FLAG", typeof(byte));

            if (selectedView.Count == 0)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = focusRow["PT_ID"];
                paramRow["PART_CODE"] = focusRow["PART_CODE"];
                paramRow["OUT_DEL_FLAG"] = 1;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                    paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                    paramRow["OUT_DEL_FLAG"] = 1;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT02A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickFlag,
                QuickException);
        }

        void QuickFlag(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제취소
            DataRow focusRow = acGridView5.GetFocusedDataRow();
            if (focusRow == null) return;

            DataView selectedView = acGridView5.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("PART_CODE", typeof(string));
            paramTable.Columns.Add("OUT_DEL_FLAG", typeof(byte));

            if (selectedView.Count == 0)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = focusRow["PT_ID"];
                paramRow["PART_CODE"] = focusRow["PART_CODE"];
                paramRow["OUT_DEL_FLAG"] = 0;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                    paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                    paramRow["OUT_DEL_FLAG"] = 0;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT02A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickFlag2,
                QuickException);
        }

        void QuickFlag2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView5.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //요청목록에 넣기
            PTSelect2(false);
        }

        void PTSelect2(bool isDoubleClick)
        {
            try
            {
                acGridView6.EndEditor();

                //다중선택
                DataTable dtOrigin = acGridView2.GridControl.DataSource as DataTable;
                if (dtOrigin == null)
                {
                    acGridView2.GridControl.DataSource = acGridView2.DefaultTable;
                    dtOrigin = acGridView2.DefaultTable;
                }
                DataView selectedView = acGridView6.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0 || isDoubleClick == true)
                {
                    DataRow focusRow = acGridView6.GetFocusedDataRow();

                    DataRow copyFocusRow = focusRow.NewCopy();
                    copyFocusRow["SEL"] = "0";
                    acGridView4.UpdateMapingRow(copyFocusRow, true);

                    if (focusRow["PART_CODE"].ToString() != "")
                        acGridView6.DeleteMappingRow(focusRow);
                }
                else
                {

                    DataTable dtSelected = acGridView6.GridControl.DataSource as DataTable;

                    DataRow[] drSelected = dtSelected.Select("SEL = '1'");

                    foreach (DataRow dr in drSelected)
                    {

                        DataRow copyFocusRow = dr.NewCopy();
                        copyFocusRow["SEL"] = "0";
                        acGridView4.UpdateMapingRow(copyFocusRow, true);

                        if (dr["PART_CODE"].ToString() != "")
                            acGridView6.DeleteMappingRow(dr);
                    }

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void PTUnSelect2(bool isDoubleClick)
        {
            try
            {
                acGridView4.EndEditor();

                DataView selectedView = acGridView4.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0 || isDoubleClick == true)
                {
                    DataRow focusRow = acGridView4.GetFocusedDataRow();
                    if (focusRow == null) return;
                    string partCode = focusRow["PART_CODE"].toStringEmpty();

                    acGridView6.UpdateMapingRow(focusRow, true);
                    acGridView4.DeleteMappingRow(focusRow);

                }
                else
                {
                    int cnt = selectedView.Count;

                    acGridView6.UpdateMapingRowLinq(selectedView.ToTable(), true);
                    foreach (DataRowView drv in selectedView)
                    {
                        drv.Delete();
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}