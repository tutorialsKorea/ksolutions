using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Repository;

namespace MAT
{
    public partial class MAT03A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }
        public MAT03A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {

                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddTextEdit("OUT_REQ_ID", "불출요청 번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_CODE_GROUP", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("CVND_CODE", "발주처 코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView1.AddLookUpEdit("MAT_TYPE", "구매 분류", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                //acGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddLookUpEdit("OUT_REQ_LOC", "사용처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M017");
                //acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("OUT_REQ_DATE", "불출요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);

                //acGridView1.AddTextEdit("STOCK_NAME", "불출 창고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpOrg("OUT_REQ_ORG", "불출요청 부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
                acGridView1.AddLookUpEmp("OUT_REQ_EMP", "불출요청인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                acGridView1.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("O_PART_QTY", "세트수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("PROD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("OUT_REQ_QTY", "불출 요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("O_OUT_QTY", "기 불출수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("REMAIN_QTY", "불출 잔여 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView1.AddTextEdit("LIMIT_QTY", "불출 가능 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("OUT_QTY", "불출 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("TOT_QTY", "총 재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView1.AddLookUpEdit("STOCK_CODE", "불출 창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "M005");
                //acGridView1.AddGridLookUpEdit("STK_LOCATION", "자재창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true,"자재창고","창고코드",null);

                acGridView1.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("WO_FLAG", "조립 작업상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                acGridView1.AddTextEdit("ORD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("OUT_ID", "불출 번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("OUT_REQ_ID", "불출요청 번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEmp("OUT_REQ_EMP", "불출요청인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                //acGridView2.AddLookUpEdit("MAT_LTYPE", "품목구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
                acGridView2.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROD_CODE_GROUP", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView2.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("CVND_CODE", "발주처 코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView2.AddLookUpEdit("MAT_TYPE", "구매 분류", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                //acGridView2.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");
                acGridView2.AddLookUpEdit("OUT_REQ_LOC", "사용처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M017");
                acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView2.AddDateEdit("OUT_DATE", "불출일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);

                acGridView2.AddLookUpOrg("OUT_ORG", "불출 부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
                acGridView2.AddLookUpEmp("OUT_EMP", "불출인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                //acGridView2.AddTextEdit("STOCK_NAME", "불출 창고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_QTY", "BOM 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("O_PART_QTY", "세트수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("PROD_QTY", "영업수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("OUT_QTY", "불출 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("REQ_SCOMMENT", "불출요청 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("DRAW_EMP", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                //acGridView2.AddLookUpEdit("RET_STATUS", "반납상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S044");
                acGridView2.AddTextEdit("RET_QTY", "최근 반납 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("RET_STAT", "반납 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("RET_SCOMMENT", "반납 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("WO_FLAG", "조립 작업상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                acGridView2.AddTextEdit("ORD_SCOMMENT", "영업 전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


                acGridView2.KeyColumn = new string[] { "OUT_ID" };

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView3.AddTextEdit("OC_ID", "이력 번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("OUT_ID", "불출 번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("YPGO_ID", "입고 번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                //acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("YPGO_DATE", "입고일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                //acGridView3.AddLookUpEdit("YPGO_LOC", "창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView3.AddTextEdit("QTY", "출고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("COST", "출고단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("AMT", "출고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                acGridView1.OptionsSelection.MultiSelect = true;

                //acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
                acGridView1.SelectionChanged += acGridView1_SelectionChanged;
                acGridView1.CellValueChanged += acGridView1_CellValueChanged;
                //acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;

                acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;
                acGridView2.MouseDown += AcGridView2_MouseDown;

                //acGridView1.CustomRowCellEdit += AcGridView1_CustomRowCellEdit;

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl2.OnValueKeyDown += acLayoutControl2_OnValueKeyDown;
                acLayoutControl1.OnValueChanged += AcLayoutControl_OnValueChanged;
                acLayoutControl2.OnValueChanged += AcLayoutControl_OnValueChanged;

                acCheckedComboBoxEdit1.AddItem("불출 요청일", false, "", "OUT_REQ_DATE", true, false, CheckState.Checked);
                acCheckedComboBoxEdit2.AddItem("불출 처리일", false, "", "OUT_DATE", true, false, CheckState.Checked);

                (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");
                (acLayoutControl2.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

                acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

                btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void AcGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;
                if (view == null) return;

                switch(e.Column.FieldName)
                {
                    case "STK_LOCATION":
                    {
                            DataRow row = view.GetDataRow(e.RowHandle);
                            if (row == null) return;

                            DataSet paramSet = new DataSet();
                            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("PART_CODE", typeof(String));

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_CODE"] = row["PART_CODE"];
                            paramTable.Rows.Add(paramRow);

                            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAT03A_SER4", paramSet, "RQSTDT", "RSLTDT");

                            RepositoryItemGridLookUpEdit gridLookupEdit = e.RepositoryItem as RepositoryItemGridLookUpEdit;
                            gridLookupEdit.DataSource = resultSet.Tables["RSLTDT"];
                    }
                        break;

                }
            }
            catch(Exception ex)
            {
            
            }
        }

        private void AcLayoutControl_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        private void AcGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                DataRow row = acGridView1.GetDataRow(e.RowHandle);

                switch (e.Column.FieldName)
                {
                    case "REMAIN_QTY":
                        if (e.CellValue.toInt() > 0 && row["O_OUT_QTY"].toInt() > 0)
                        {
                            e.Appearance.BackColor = Color.Orange;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    DataRow focusedRow = acGridView2.GetFocusedDataRow();

                    if (focusedRow == null) return;

                    DataTable dtSearch = new DataTable("RQSTDT");
                    dtSearch.Columns.Add("PLT_CODE", typeof(String));
                    dtSearch.Columns.Add("OUT_REQ_ID", typeof(String));

                    DataRow paramRow = dtSearch.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["OUT_REQ_ID"] = focusedRow["OUT_REQ_ID"];

                    dtSearch.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtSearch);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAT09B_SER4", paramSet, "RQSTDT", "RSLTDT");

                    if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        MAT03A_D1A frm = new MAT03A_D1A(resultSet.Tables["RSLTDT"]);
                        frm.ParentControl = this;

                        frm.ShowDialog();

                    }

                }


            }
            catch { }
        }

        public override void MenuNotify(object data)
        {
            if (data == null) return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            paramTable.Columns.Add("S_DATE", typeof(String));
            paramTable.Columns.Add("E_DATE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;


            paramRow["S_DATE"] = DateTime.Now.AddDays(-7).toDateString("yyyyMMdd");
            paramRow["E_DATE"] = DateTime.Now.toDateString("yyyyMMdd");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAT03A_SER", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];


            base.MenuNotify(data);
        }

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "O":

                        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    case "Q":

                        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acGridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                GetDetail();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        void acGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "OUT_QTY":

                    DataRow row = acGridView1.GetDataRow(e.RowHandle);
                    row["SEL"] = "1";

                    break;
                case "STK_LOCATION":
                    break;

            }
        }


        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "OUT_REQ_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

                //layout.GetEditor("MAT_LTYPE").Value = "22";
                layout.GetEditor("IS_MAIN").Value = "1";

            }

            if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "OUT_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

                //layout.GetEditor("MAT_LTYPE").Value = "22";
            }

           

            base.ChildContainerInit(sender);
        }


        void acGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
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

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            //if (e.MenuType == GridMenuType.User)
            //{
            //    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //}
            //else if (e.MenuType == GridMenuType.Row)
            //{
            //    if (e.HitInfo.RowHandle >= 0)
            //    {
            //        btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }
            //    else
            //    {
            //        btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        //acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }

            //}


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        DataTable _dtSearch;

        void Search()
        {
            switch (acTabControl1.GetSelectedContainerName())
            {
                case "O":
                    reqSearch();
                    break;

                case "Q":
                    outSearch();
                    break;
            }
        }
        void reqSearch()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                _dtSearch = new DataTable("RQSTDT");
                _dtSearch.Columns.Add("PLT_CODE", typeof(String));
                _dtSearch.Columns.Add("OUT_REQ_ID", typeof(String));
                _dtSearch.Columns.Add("PART_LIKE", typeof(String));
                _dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                _dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                _dtSearch.Columns.Add("PART_PRODTYPE", typeof(String));
                _dtSearch.Columns.Add("S_DATE", typeof(String));
                _dtSearch.Columns.Add("E_DATE", typeof(String));
                _dtSearch.Columns.Add("PROD_LIKE", typeof(String));
                _dtSearch.Columns.Add("MAT_LTYPE", typeof(String));
                _dtSearch.Columns.Add("MAT_MTYPE", typeof(String));
                _dtSearch.Columns.Add("MAT_STYPE", typeof(String));
                _dtSearch.Columns.Add("IS_MAIN", typeof(String)); // 

                DataRow paramRow = _dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["OUT_REQ_ID"] = layoutRow["OUT_REQ_ID"];
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "OUT_REQ_DATE":

                            paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                            paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                            break;
                    }
                }

                if (layoutRow["IS_MAIN"].ToString() == "1")
                {
                    paramRow["IS_MAIN"] = "1";
                }


                _dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(_dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT03A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void outSearch()
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("PART_LIKE", typeof(String));
                dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                dtSearch.Columns.Add("PART_PRODTYPE", typeof(String));
                dtSearch.Columns.Add("S_DATE", typeof(String));
                dtSearch.Columns.Add("E_DATE", typeof(String));
                dtSearch.Columns.Add("OUT_REQ_NAME", typeof(String));
                dtSearch.Columns.Add("PROD_LIKE", typeof(String));
                dtSearch.Columns.Add("MAT_LTYPE", typeof(String));
                dtSearch.Columns.Add("MAT_MTYPE", typeof(String));
                dtSearch.Columns.Add("MAT_STYPE", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                paramRow["OUT_REQ_NAME"] = layoutRow["OUT_REQ_NAME"];
                paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];

                foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "OUT_DATE":

                            paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                            paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                            break;
                    }
                }


                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT03A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
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
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "O":

                        if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                        {
                            if (chkPinOrActuator.Checked)
                            {
                                //Actuator나 PROBE PIN 자동선택
                                foreach (DataRow row in e.result.Tables["RSLTDT"].Select("MAT_MTYPE IN ('21','23')"))
                                {
                                    row["SEL"] = "1";
                                }
                            }
                            //sbQuery.Append(" 	, 0 AS LIMIT_QTY         ");//불출가능 수량 체크하기위한 컬럼
                            //e.result.Tables["RSLTDT"].Columns.Add("LIMIT_QTY", typeof(String));

                            foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                            {
                                row["TOT_QTY"] = e.result.Tables["RSLTDT_STOCK"].Select("PART_CODE='" + row["PART_CODE"] + "'")
                                                                                .GroupBy(g => new { PLT_CODE = g["PLT_CODE"], STK_ID = g["STK_ID"] })
                                                                                .Select(r => new
                                                                                {
                                                                                    PLT_CODE = r.Key.PLT_CODE,
                                                                                    STK_ID = r.Key.STK_ID,
                                                                                    PART_QTY = r.Max(m => m["PART_QTY"].toDecimal())
                                                                                })
                                                                                .Sum(s => s.PART_QTY.toDecimal());
                            }

                            acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"].AsEnumerable().OrderByDescending(o => o["SEL"].toStringEmpty()).CopyToDataTable();
                            acGridView1.SetOldFocusRowHandle(true);

                            acGridView1.ExpandAllGroups();
                        }
                        else
                        {
                            acGridView1.GridControl.DataSource = null;
                        }
                        break;

                    case "Q":
                        acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        break;
                }


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    if (chkPinOrActuator.Checked)
                    {
                        //Actuator나 PROBE PIN 자동선택
                        foreach (DataRow row in e.result.Tables["RSLTDT"].Select("MAT_MTYPE IN ('21','23')"))
                        {
                            row["SEL"] = "1";
                        }
                    }

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        row["TOT_QTY"] = e.result.Tables["RSLTDT_STOCK"].Select("PART_CODE='" + row["PART_CODE"] + "'")
                                                                         .GroupBy(g => new { PLT_CODE = g["PLT_CODE"], STK_ID = g["STK_ID"] })
                                                                         .Select(r => new
                                                                         {
                                                                             PLT_CODE = r.Key.PLT_CODE,
                                                                             STK_ID = r.Key.STK_ID,
                                                                             PART_QTY = r.Max(m => m["PART_QTY"].toDecimal())
                                                                         })
                                                                         .Sum(s => s.PART_QTY.toDecimal());
                    }

                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"].AsEnumerable().OrderByDescending(o => o["SEL"].toStringEmpty()).CopyToDataTable();
                    //acGridView1.SetOldFocusRowHandle(true);
                }
                else
                {
                    acGridView1.GridControl.DataSource = null;
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

                acAlert.Show(this, "불출 완료", acAlertForm.enmType.Success);
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

        /// <summary>
        /// 불출 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataView view = acGridView1.GetDataSourceView("SEL = '1'");

                if (view.Count == 0)
                {
                    acAlert.Show(this, "불출 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                DataTable selectedRows = null;

                if(view.Count > 0)
                {
                    if (!acGridView1.ValidCheck("SEL = '1'")) return;

                    selectedRows = view.ToTable();
                }
                else
                {
                    if (!acGridView1.ValidFocusRowHandle()) return;

                    selectedRows = acGridView1.GetFocusedDataRow().NewTable();
                }

                //if ((acGridView1.GridControl.DataSource as DataTable).Select("SEL = '1'").Length > 0)
                //{
                //    selectedRows = (acGridView1.GridControl.DataSource as DataTable).Select("SEL = '1'").CopyToDataTable();
                //}
                //else
                //{
                //    acMessageBox.Show(this, "불출 등록하실 품목이 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                string isShipFlag = "0";
                foreach (DataRow row in selectedRows.Rows)
                {
                    if (row["OUT_REQ_LOC"].ToString() == "ORD")
                    {
                        isShipFlag = "1";
                        break;
                    }
                }

                MAT03A_D0A frm = new MAT03A_D0A(isShipFlag);

                frm.ParentControl = this;

                //if (selectedRows.GroupCnt(new string[] { "OUT_REQ_ORG"}) == 1)
                //{
                //    frm.Parameter = selectedRows.Rows[0];
                //}

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("OUT_ID", typeof(String));
                    dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                    dtParam.Columns.Add("PART_CODE", typeof(String));
                    dtParam.Columns.Add("PART_NAME", typeof(String));
                    dtParam.Columns.Add("OUT_DATE", typeof(String));
                    dtParam.Columns.Add("OUT_EMP", typeof(String));
                    dtParam.Columns.Add("OUT_QTY", typeof(Int32));
                    dtParam.Columns.Add("OUT_ORG", typeof(String));
                    dtParam.Columns.Add("SCOMMENT", typeof(String));
                    dtParam.Columns.Add("OUT_REQ_QTY", typeof(Int32));
                    dtParam.Columns.Add("O_OUT_QTY", typeof(Int32));
                    dtParam.Columns.Add("OUT_LOC", typeof(String));
                    dtParam.Columns.Add("OUT_REQ_EMP", typeof(String));
                    dtParam.Columns.Add("REG_EMP", typeof(String));
                    dtParam.Columns.Add("IS_SHIP", typeof(String));
                    dtParam.Columns.Add("PROD_CODE", typeof(String));

                    DataRow selectedRow = (DataRow)frm.OutputData;

                    foreach (DataRow dr in selectedRows.Rows)
                    {
                        if (dr["OUT_QTY"].toInt() > dr["TOT_QTY"].toInt())
                        {
                            acAlert.Show(this, "재고수량이 부족합니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow drParam = dtParam.NewRow();

                        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                        drParam["OUT_REQ_ID"] = dr["OUT_REQ_ID"];
                        drParam["PART_CODE"] = dr["PART_CODE"];
                        drParam["PART_NAME"] = dr["PART_NAME"];
                        drParam["OUT_DATE"] = selectedRow["OUT_DATE"];
                        drParam["OUT_EMP"] = selectedRow["OUT_EMP"];
                        drParam["OUT_QTY"] = dr["OUT_QTY"];
                        drParam["OUT_ORG"] = selectedRow["OUT_ORG"];
                        drParam["SCOMMENT"] = selectedRow["SCOMMENT"];
                        drParam["OUT_REQ_QTY"] = dr["OUT_REQ_QTY"];
                        drParam["O_OUT_QTY"] = dr["O_OUT_QTY"];
                        //drParam["OUT_LOC"] = dr["STOCK_CODE"];  //불출창고
                        drParam["OUT_REQ_EMP"] = dr["OUT_REQ_EMP"];
                        drParam["REG_EMP"] = acInfo.UserID; ;
                        drParam["IS_SHIP"] = selectedRow["IS_SHIP"];
                        drParam["PROD_CODE"] = dr["PROD_CODE"];

                        dtParam.Rows.Add(drParam);

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtParam);

                    if (_dtSearch == null)
                    {
                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        _dtSearch = new DataTable("RQSTDT");
                        _dtSearch.Columns.Add("PLT_CODE", typeof(String));
                        _dtSearch.Columns.Add("OUT_REQ_ID", typeof(String));
                        _dtSearch.Columns.Add("PART_LIKE", typeof(String));
                        _dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                        _dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                        _dtSearch.Columns.Add("S_DATE", typeof(String));
                        _dtSearch.Columns.Add("E_DATE", typeof(String));

                        DataRow paramRow = _dtSearch.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["OUT_REQ_ID"] = layoutRow["OUT_REQ_ID"];
                        paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                        paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                        paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];

                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "OUT_REQ_DATE":

                                    paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                                    paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                                    break;
                            }
                        }


                        _dtSearch.Rows.Add(paramRow);
                    }

                    DataTable dtSer = _dtSearch.Copy();
                    dtSer.TableName = "RQSTDT_SER";
                    paramSet.Tables.Add(dtSer);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW, "MAT03A_INS", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);

                }



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void GetDetail()
        {
            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("OUT_ID", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["OUT_ID"] = focusRow["OUT_ID"];

                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "MAT03A_SER3", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearchDetail,
                            QuickException);
            }
            else
            {
                acGridView3.ClearRow();
            }
        }

        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //불출취소
                acGridView2.EndEditor();

                DataView selectedView = acGridView2.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    acAlert.Show(this, "불출 취소 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                if (acMessageBox.Show(this, "불출 취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("OUT_ID", typeof(String)); //
                paramTable.Columns.Add("OUT_REQ_ID", typeof(String)); //

                foreach (DataRowView row in selectedView)
                {
                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["OUT_ID"] = row["OUT_ID"];
                    paramRow["OUT_REQ_ID"] = row["OUT_REQ_ID"];
                    paramTable.Rows.Add(paramRow);
                }
               
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                 "MAT03A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickCancel,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                    acGridView2.RaiseFocusedRowChanged();
                }

                acAlert.Show(this, "불출 취소 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count > 0)
                {
                    MAT03A_D2A frm = new MAT03A_D2A();

                    frm.Text = e.Item.Caption;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        DataRow frmRow = (DataRow)frm.OutputData;

                        foreach (DataRowView drv in selectedView)
                        {
                            drv["STK_LOCATION"] = frmRow["STK_LOCATION"];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        IWorkbook WriteExcel()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                spreadsheetControl1.LoadDocument(Resource.OUT_REQ_LIST5, DocumentFormat.Xlsx);

                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable dtData = acGridView1.GetDataView().ToTable();

                if (selectedView.Count > 0)
                {
                    dtData = selectedView.ToTable();
                }
                

                IWorkbook workbook = spreadsheetControl1.Document;
                Worksheet worksheet = workbook.Worksheets["Sheet1"];

                int rowIdx = 4;

                foreach (DataRow dr in dtData.Rows)
                {
                    worksheet.Columns["C"][rowIdx].Value = dr["PROD_CODE"].ToString();
                    worksheet.Columns["D"][rowIdx].Value = dr["CVND_NAME"].ToString();
                    worksheet.Columns["E"][rowIdx].Value = dr["PART_NAME"].ToString();

                    worksheet.Columns["F"][rowIdx].Value = dr["PART_QTY"].toInt();
                    worksheet.Columns["F"][rowIdx].NumberFormat = "#,#";

                    worksheet.Columns["G"][rowIdx].Value = dr["O_PART_QTY"].toInt();
                    worksheet.Columns["G"][rowIdx].NumberFormat = "#,#";

                    worksheet.Columns["H"][rowIdx].Value = dr["OUT_REQ_QTY"].toInt();
                    worksheet.Columns["H"][rowIdx].NumberFormat = "#,#";
                    worksheet.Columns["I"][rowIdx].Value = dr["OUT_QTY"].toInt();
                    worksheet.Columns["I"][rowIdx].NumberFormat = "#,#";
                    worksheet.Columns["J"][rowIdx].Value = dr["REMAIN_QTY"].toInt();
                    worksheet.Columns["J"][rowIdx].NumberFormat = "#,#";
                    worksheet.Columns["K"][rowIdx].Value = dr["DUE_DATE"].toDateString("yyyy-MM-dd");
                    worksheet.Columns["L"][rowIdx].Value = dr["DRAW_EMP"].ToString();
                    worksheet.Columns["M"][rowIdx].Value = dr["PART_CODE"].ToString();

                    rowIdx++;
                }


                //set border
                CellRange range = worksheet.Range["C4:M" + rowIdx.ToString()];
                range.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
                return workbook;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return null;
            }
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                WriteExcel();
                spreadsheetControl1.ShowPrintPreview();
            }
            catch { }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //출하지시

            acGridView gridView = null;
            if (acTabControl1.GetSelectedContainerName() == "O")
            {
                gridView = acGridView1;
            }
            else if (acTabControl1.GetSelectedContainerName() == "Q")
            {
                gridView = acGridView2;
            }

            gridView.EndEditor();

            DataRow dr = gridView.GetFocusedDataRow();
            DataView selectedView = gridView.GetDataSourceView("SEL = '1'");

            if (dr == null) return;

            if (acMessageBox.Show(this, "출하지시 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
            {
                return;
            }

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //

            if (selectedView.Count == 0)
            {
                if (dr["OUT_REQ_LOC"].ToString() == "ORD")
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["PROD_CODE"] = dr["PROD_CODE"];

                    paramTable1.Rows.Add(paramRow1);
                }
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    if (selectedView[i]["OUT_REQ_LOC"].ToString() == "ORD")
                    {
                        DataRow paramRow1 = paramTable1.NewRow();
                        paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow1["PROD_CODE"] = selectedView[i]["PROD_CODE"];

                        paramTable1.Rows.Add(paramRow1);
                    }
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "MAT03A_UPD2", paramSet, "RQSTDT", "RSLTDT",
            QuickSaveShip,
            QuickException);
        }

        void QuickSaveShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acAlert.Show(this, "완료 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //불출내역 - 비고 저장
            try
            {
                acGridView2.EndEditor();

                //DataRow dr = acGridView2.GetFocusedDataRow();
                //DataView selectedView = acGridView2.GetDataSourceView("SEL = '1'");


                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("OUT_ID", typeof(String)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //

                DataTable mdfyTable = acGridView2.GetAddModifyRows();

                foreach (DataRow row in mdfyTable.Rows)
                {
                    DataRow newRow = paramTable1.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["OUT_ID"] = row["OUT_ID"];
                    newRow["SCOMMENT"] = row["SCOMMENT"];
                    paramTable1.Rows.Add(newRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "MAT03A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveScomment,
                QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveScomment(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acAlert.Show(this, "수정 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //불출 - 비고 저장
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("OUT_REQ_ID", typeof(String)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //

                if (selectedView.Count > 0)
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow newRow = paramTable1.NewRow();
                        newRow["PLT_CODE"] = acInfo.PLT_CODE;
                        newRow["OUT_REQ_ID"] = selectedView[i]["OUT_REQ_ID"];
                        newRow["SCOMMENT"] = selectedView[i]["SCOMMENT"];
                        paramTable1.Rows.Add(newRow);
                    }
                }
                else
                {
                    acAlert.Show(this, "선택된 항목이 없습니다.", acAlertForm.enmType.Info);
                    return;
                }
                
                //DataTable mdfyTable = acGridView1.GetAddModifyRows();

                //foreach (DataRow row in mdfyTable.Rows)
                //{
                //    DataRow newRow = paramTable1.NewRow();
                //    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    newRow["OUT_ID"] = row["OUT_ID"];
                //    newRow["SCOMMENT"] = row["SCOMMENT"];
                //    paramTable1.Rows.Add(newRow);
                //}

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "MAT03A_UPD4", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveScomment,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
