using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;
using System.Linq;
using BizManager;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace REP
{
    public sealed partial class REP04A_M0A : BaseMenu
    {

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override void MenuLink(object data)
        {
            try
            {
                DataRow linkRow = data as DataRow;

                acTabControl1.SelectedTabPage = acTabPage2;

                DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("PLT_CODE", typeof(String));
                paramTable2.Columns.Add("EMP_CODE", typeof(String));
                paramTable2.Columns.Add("IS_DEV", typeof(String));

                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["EMP_CODE"] = linkRow["EMP_CODE"];
                paramRow2["IS_DEV"] = "1";

                paramTable2.Rows.Add(paramRow2);
                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_EMP_SEARCH", paramSet2, "RQSTDT", "RSLTDT",
                   QuickSearch3,
                   QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void BarCodeScanInput(string barcode)
        {


        }

        public REP04A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.LIST;
            acGridView1.AddTextEdit("TYPE", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.GridType = acGridView.emGridType.LIST;
            acGridView2.AddTextEdit("TYPE", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView3.GridType = acGridView.emGridType.LIST;
            acGridView3.AddTextEdit("TYPE", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView4.GridType = acGridView.emGridType.LIST;
            acGridView4.AddTextEdit("WORK_LOC_NAME", "근무처", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("EMP_CODE", "개발자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("EMP_NAME", "개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("TYPE", "유  형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView5.GridType = acGridView.emGridType.AUTO_COL;

            acGridView5.AddLookUpEdit("WORK_LOC", "근무처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E001");

            acGridView5.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView5.AddDateEdit("HIRE_DATE", "입사일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            acGridView5.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView5.Columns["EMP_NAME"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            acGridView5.AddHidden("EMP_CODE", typeof(String));

            acGridView5.AddHidden("ORG_CODE", typeof(String));

            acGridView1.OptionsView.AllowCellMerge = true;
            acGridView2.OptionsView.AllowCellMerge = true;
            acGridView3.OptionsView.AllowCellMerge = true;
            acGridView4.OptionsView.AllowCellMerge = true;

            acGridView4.Columns["WORK_LOC_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView4.Columns["EMP_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView4.Columns["EMP_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView4.CellMerge += acGridView4_CellMerge;

            acGridView4.CustomDrawCell += acGridView4_CustomDrawCell;
            acGridView4.Appearance.Row.Font = new Font(acGridView4.Appearance.Row.Font.Name, acGridView4.Appearance.Row.Font.Size, FontStyle.Bold);

            acGridControl4.Paint += acGridControl4_Paint;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            acSplitContainerControl6.SplitterPosition = 215;
            acSplitContainerControl7.SplitterPosition = 210;
            acSplitContainerControl8.SplitterPosition = 210;

            acDateEdit3.Properties.EditMask = "yyyy";
            acDateEdit5.Properties.EditMask = "yyyy";

            acGroupControl2.AppearanceCaption.BorderColor = Color.Thistle;
            acGroupControl3.AppearanceCaption.BorderColor = Color.PowderBlue;
            acGroupControl4.AppearanceCaption.BorderColor = Color.LightGreen;

            (acLayoutControl2.GetEditor("WORK_LOC") as acLookupEdit).SetCode("E001");

            acEmp1.isDev = 1;

            acGridView5.FocusedRowChanged += acGridView5_FocusedRowChanged;

            base.MenuInit();
        }

        private void acGridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                DataRow focusRow = acGridView5.GetFocusedDataRow();

                if (focusRow != null)
                {
                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String));
                    paramTable2.Columns.Add("YEAR", typeof(String));
                    //paramTable2.Columns.Add("WORK_LOC", typeof(String));
                    paramTable2.Columns.Add("EMP_CODE", typeof(String));


                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["YEAR"] = layoutRow2["YEAR"];
                    //paramRow2["WORK_LOC"] = layoutRow2["WORK_LOC"];
                    paramRow2["EMP_CODE"] = focusRow["EMP_CODE"];

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "REP04A_SER2", paramSet2, "RQSTDT", "RSLTDT, RSLTDT2. RSLTDT3",
                       QuickSearch2,
                       QuickException);
                }
                else
                {
                    acGridView4.ClearRow();
                }

                
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void MenuInitComplete()
        {
            acGroupControl2.AppearanceCaption.BorderColor = Color.Thistle;
            acGroupControl3.AppearanceCaption.BorderColor = Color.PowderBlue;
            acGroupControl4.AppearanceCaption.BorderColor = Color.LightGreen;
            base.MenuInitComplete();
        }

        private void acGridControl4_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            string prev2 = string.Empty;
            for (int i = 0; i < acGridView4.RowCount; i++)
            {
                if (acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["EMP_NAME"]) != prev)
                {
                    GridViewInfo info = (GridViewInfo)acGridView4.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView4.Columns["EMP_NAME"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(info.GetGridCellInfo(i, acGridView4.Columns["WORK_LOC_NAME"]).Bounds.Left, cell.Bounds.Top), new Point(info.GetGridCellInfo(i, acGridView4.Columns["WORK_SUM"]).Bounds.Right, cell.Bounds.Top));
                        prev = acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["EMP_NAME"]);
                        prev2 = acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["TYPE"]).ToString().Substring(0, 3);
                    }
                }

                else if (acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["TYPE"]).ToString().Substring(0,3) != prev2)
                {
                    GridViewInfo info = (GridViewInfo)acGridView4.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView4.Columns["TYPE"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.CadetBlue, 2), new Point(info.GetGridCellInfo(i, acGridView4.Columns["TYPE"]).Bounds.Left, cell.Bounds.Top), new Point(info.GetGridCellInfo(i, acGridView4.Columns["WORK_SUM"]).Bounds.Right, cell.Bounds.Top));
                        prev2 = acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["TYPE"]).ToString().Substring(0, 3);
                    }
                }
            }
        }

        private void acGridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                if ((e.Column.FieldName == "TYPE"
                    || e.Column.FieldName.StartsWith("WORK"))
                    && e.Column.FieldName != "WORK_LOC_NAME")
                {


                    acGridView view = (sender as acGridView);
                    DataRow row = view.GetDataRow(e.RowHandle);


                    if (row["TYPE"].ToString().StartsWith("Socket"))
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                    }
                    else if (row["TYPE"].ToString().StartsWith("Pin"))
                    {
                        e.Appearance.BackColor = Color.LemonChiffon;
                    }
                    else if (row["TYPE"].ToString().StartsWith("Jig"))
                    {
                        e.Appearance.BackColor = Color.Honeydew;
                    }
                    else if (row["TYPE"].ToString().StartsWith("Part"))
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }

            }
            catch { }
        }

        private void acGridView4_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName.Equals("EMP_CODE")
                || e.Column.FieldName.Equals("EMP_NAME")
                || e.Column.FieldName.Equals("WORK_LOC_NAME"))

            {
                string cEmp1 = acGridView4.GetRowCellValue(e.RowHandle1, "EMP_CODE").ToString();
                string cEmp2 = acGridView4.GetRowCellValue(e.RowHandle2, "EMP_CODE").ToString();

                if (cEmp1 == cEmp2)
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }

            e.Handled = true;
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }

            base.ChildContainerInit(sender);
        }






        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);

        }

        void Search()
        {
            switch(acTabControl1.GetSelectedContainerName())
            {
                case "TOTAL":

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("YEAR", typeof(String));


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["YEAR"] = layoutRow["YEAR"];

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP04A_SER", paramSet, "RQSTDT", "RSLTDT, RSLTDT2. RSLTDT3",
                       QuickSearch,
                       QuickException);

                    break;

                case "EMP":

                    DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String));
                    paramTable2.Columns.Add("EMP_CODE", typeof(String));
                    paramTable2.Columns.Add("WORK_LOC", typeof(String));
                    paramTable2.Columns.Add("IS_DEV", typeof(String));
                    paramTable2.Columns.Add("IS_RETIRE", typeof(String));

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["EMP_CODE"] = layoutRow2["EMP_CODE"];
                    paramRow2["WORK_LOC"] = layoutRow2["WORK_LOC"];
                    paramRow2["IS_DEV"] = "1";

                    paramRow2["IS_RETIRE"] = layoutRow2["IS_RETIRE"];

                    if (acCheckEdit1.Checked)
                    {
                        paramRow2["IS_RETIRE"] = null;
                    }

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_EMP_SEARCH", paramSet2, "RQSTDT", "RSLTDT",
                       QuickSearch3,
                       QuickException);

                    break;
            }
        }

        void QuickSearch3(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl1.ClearSeries();
                acChartControl1.ClearSeriesPoint();

                acChartControl1.chartControl.PaletteName = "Metro";//Metro

                acChartControl1.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl1.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl1.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl1.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (!acChartControl1.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl1.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl1.SeriesDic[row["TYPE"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView1.BestFitColumns();
                acGridView1.Columns[0].Width = 10;

                acChartControl2.ClearSeries();
                acChartControl2.ClearSeriesPoint();

                acChartControl2.chartControl.PaletteName = "Metro";//Metro

                acChartControl2.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl2.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl2.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram2 = acChartControl2.chartControl.Diagram as XYDiagram;
                if (diagram2 != null)
                {
                    diagram2.AxisY.Label.TextPattern = "{V:N0}";
                    diagram2.AxisX.Label.Visible = true;
                    //diagram2.AxisX.Label.Angle = -30;
                    diagram2.AxisY.Interlaced = true;
                    diagram2.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT2"].Rows)
                {
                    if (!acChartControl2.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl2.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl2.SeriesDic[row["TYPE"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl2.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl2.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView2.BestFitColumns();


                acChartControl3.ClearSeries();
                acChartControl3.ClearSeriesPoint();

                acChartControl3.chartControl.PaletteName = "Metro";//Metro

                acChartControl3.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl3.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl3.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram3 = acChartControl3.chartControl.Diagram as XYDiagram;
                if (diagram3 != null)
                {
                    diagram3.AxisY.Label.TextPattern = "{V:N0}";
                    diagram3.AxisX.Label.Visible = true;
                    //diagram3.AxisX.Label.Angle = -30;
                    diagram3.AxisY.Interlaced = true;
                    diagram3.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT3"].Rows)
                {
                    if (!acChartControl3.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl3.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl3.SeriesDic[row["TYPE"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl3.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT3"];
                acGridView3.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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
    }
}
