using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ControlManager;
using BizManager;
using DevExpress.XtraCharts;

namespace REP
{
    public partial class REP17A_M0A : BaseMenu
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

        public REP17A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.GetEditor("SYEAR").Value = DateTime.Now;

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
        }

        public override void MenuInit()
        {
            base.MenuInit();


            acGridView1.AddTextEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("DEC", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("NOV", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("AVG", "평균", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);


            acChartControl1.AddLineSeries("NG_QTY", "확정불량 PPM", "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Bar);
            acChartControl1.AddLineSeries("GOAL", "목표 PPM", "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

            acChartControl1.chartControl.CustomDrawSeriesPoint += ChartControl_CustomDrawSeriesPoint;
        }

        private void ChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            try
            {
                if (e.SeriesPoint.Argument.Equals("[평균]"))
                {
                    e.SeriesDrawOptions.Color = Color.Aqua;
                }
                else
                {
                    e.SeriesDrawOptions.Color = Color.LightGreen;
                }
            }
            catch
            {

            }
        }

        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }

        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
                return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["SYEAR"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP17A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl1.ClearSeriesPoint();

                DataTable rsltDt = e.result.Tables["RSLTDT"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    OK_QTY = r.Sum(s => s["OK_QTY"].toDecimal()),
                                    QUANTITY = r.Sum(s => s["QUANTITY"].toDecimal()),
                                    NG_QTY = r.Sum(s => s["NG_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable rsltDt1YAgo = e.result.Tables["RSLTDT_1Y_AGO"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    OK_QTY = r.Sum(s => s["OK_QTY"].toDecimal()),
                                    QUANTITY = r.Sum(s => s["QUANTITY"].toDecimal()),
                                    NG_QTY = r.Sum(s => s["NG_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable inputTable = acGridView1.NewTable();
                
                string colName1 = "OK_QTY";
                string colName2 = "QUANTITY";
                string colName3 = "NG_QTY";


                #region 확정불량PPM
                {
                    decimal dJAN1YAgo = rsltDt1YAgo.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName1));
                    decimal dFEB1YAgo = rsltDt1YAgo.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName1));
                    decimal dMAR1YAgo = rsltDt1YAgo.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAPR1YAgo = rsltDt1YAgo.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName1));
                    decimal dMAY1YAgo = rsltDt1YAgo.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName1));
                    decimal dJUN1YAgo = rsltDt1YAgo.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName1));
                    decimal dJUL1YAgo = rsltDt1YAgo.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAUG1YAgo = rsltDt1YAgo.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName1));
                    decimal dSEP1YAgo = rsltDt1YAgo.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName1));
                    decimal dOCT1YAgo = rsltDt1YAgo.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName1));
                    decimal dDEC1YAgo = rsltDt1YAgo.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName1));
                    decimal dNOV1YAgo = rsltDt1YAgo.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAVG1YAgo = rsltDt1YAgo.SUM(colName1);

                    DataRow inputRow = inputTable.NewRow();
                    inputRow["GUBUN"] = "전년도 확정불량 PPM";
                    inputRow["JAN"] = dJAN1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3)) / dJAN1YAgo * 1000000);
                    inputRow["FEB"] = dFEB1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3)) / dFEB1YAgo * 1000000);
                    inputRow["MAR"] = dMAR1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3)) / dMAR1YAgo * 1000000);
                    inputRow["APR"] = dAPR1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3)) / dAPR1YAgo * 1000000);
                    inputRow["MAY"] = dMAY1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3)) / dMAY1YAgo * 1000000);
                    inputRow["JUN"] = dJUN1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3)) / dJUN1YAgo * 1000000);
                    inputRow["JUL"] = dJUL1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3)) / dJUL1YAgo * 1000000);
                    inputRow["AUG"] = dAUG1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3)) / dAUG1YAgo * 1000000);
                    inputRow["SEP"] = dSEP1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3)) / dSEP1YAgo * 1000000);
                    inputRow["OCT"] = dOCT1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3)) / dOCT1YAgo * 1000000);
                    inputRow["DEC"] = dDEC1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3)) / dDEC1YAgo * 1000000);
                    inputRow["NOV"] = dNOV1YAgo == 0 ? 0 : (rsltDt1YAgo.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3)) / dNOV1YAgo * 1000000);
                    inputRow["AVG"] = dAVG1YAgo == 0 ? 0 : (rsltDt1YAgo.SUM(colName3) / dAVG1YAgo * 1000000);
                    inputTable.Rows.Add(inputRow);
                }
                #endregion


                SetChartGoalData(inputTable, e.result.Tables["RSLTDT_GOAL"]);

                #region 생산수량
                DataRow inputRow1 = inputTable.NewRow();
                inputRow1["GUBUN"] = "생산수량";
                decimal dJAN = rsltDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName1));
                decimal dFEB = rsltDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName1));
                decimal dMAR = rsltDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName1));
                decimal dAPR = rsltDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName1));
                decimal dMAY = rsltDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName1));
                decimal dJUN = rsltDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName1));
                decimal dJUL = rsltDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName1));
                decimal dAUG = rsltDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName1));
                decimal dSEP = rsltDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName1));
                decimal dOCT = rsltDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName1));
                decimal dDEC = rsltDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName1));
                decimal dNOV = rsltDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName1));
                decimal dAVG = rsltDt.SUM(colName1);
                inputRow1["JAN"] = dJAN;
                inputRow1["FEB"] = dFEB;
                inputRow1["MAR"] = dMAR;
                inputRow1["APR"] = dAPR;
                inputRow1["MAY"] = dMAY;
                inputRow1["JUN"] = dJUN;
                inputRow1["JUL"] = dJUL;
                inputRow1["AUG"] = dAUG;
                inputRow1["SEP"] = dSEP;
                inputRow1["OCT"] = dOCT;
                inputRow1["DEC"] = dDEC;
                inputRow1["NOV"] = dNOV;
                inputRow1["AVG"] = dAVG;
                inputTable.Rows.Add(inputRow1);
				#endregion

                #region 총불량 수량
				DataRow inputRow2 = inputTable.NewRow();
                inputRow2["GUBUN"] = "총불량 수량";
                inputRow2["JAN"] = rsltDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["FEB"] = rsltDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["MAR"] = rsltDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["APR"] = rsltDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["MAY"] = rsltDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["JUN"] = rsltDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["JUL"] = rsltDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["AUG"] = rsltDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["SEP"] = rsltDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["OCT"] = rsltDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["DEC"] = rsltDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["NOV"] = rsltDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["AVG"] = rsltDt.SUM(colName2);
                inputTable.Rows.Add(inputRow2);
                #endregion

                #region 확정불량수량
                DataRow inputRow3 = inputTable.NewRow();
                inputRow3["GUBUN"] = "확정불량 수량";
                inputRow3["JAN"] = rsltDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["FEB"] = rsltDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["MAR"] = rsltDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["APR"] = rsltDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["MAY"] = rsltDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["JUN"] = rsltDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["JUL"] = rsltDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["AUG"] = rsltDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["SEP"] = rsltDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["OCT"] = rsltDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["DEC"] = rsltDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["NOV"] = rsltDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["AVG"] = rsltDt.SUM(colName3);
                inputTable.Rows.Add(inputRow3);
				#endregion

                #region 총불량 PPM
				DataRow inputRow4 = inputTable.NewRow();
                inputRow4["GUBUN"] = "총불량PPM";
                inputRow4["JAN"] = dJAN == 0 ? 0 : (rsltDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName2)) / dJAN * 1000000);
                inputRow4["FEB"] = dFEB == 0 ? 0 : (rsltDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName2)) / dFEB * 1000000);
                inputRow4["MAR"] = dMAR == 0 ? 0 : (rsltDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName2)) / dMAR * 1000000);
                inputRow4["APR"] = dAPR == 0 ? 0 : (rsltDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName2)) / dAPR * 1000000);
                inputRow4["MAY"] = dMAY == 0 ? 0 : (rsltDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName2)) / dMAY * 1000000);
                inputRow4["JUN"] = dJUN == 0 ? 0 : (rsltDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName2)) / dJUN * 1000000);
                inputRow4["JUL"] = dJUL == 0 ? 0 : (rsltDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName2)) / dJUL * 1000000);
                inputRow4["AUG"] = dAUG == 0 ? 0 : (rsltDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName2)) / dAUG * 1000000);
                inputRow4["SEP"] = dSEP == 0 ? 0 : (rsltDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName2)) / dSEP * 1000000);
                inputRow4["OCT"] = dOCT == 0 ? 0 : (rsltDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName2)) / dOCT * 1000000);
                inputRow4["DEC"] = dDEC == 0 ? 0 : (rsltDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName2)) / dDEC * 1000000);
                inputRow4["NOV"] = dNOV == 0 ? 0 : (rsltDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName2)) / dNOV * 1000000);
                inputRow4["AVG"] = dAVG == 0 ? 0 : (rsltDt.SUM(colName2) / dAVG*1000000);
                inputTable.Rows.Add(inputRow4);
				#endregion

                #region 확정불량PPM
				DataRow inputRow5 = inputTable.NewRow();
                inputRow5["GUBUN"] = "확정불량 PPM";
                inputRow5["JAN"] = dJAN == 0 ? 0 : (rsltDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3)) / dJAN * 1000000);
                inputRow5["FEB"] = dFEB == 0 ? 0 : (rsltDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3)) / dFEB * 1000000);
                inputRow5["MAR"] = dMAR == 0 ? 0 : (rsltDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3)) / dMAR * 1000000);
                inputRow5["APR"] = dAPR == 0 ? 0 : (rsltDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3)) / dAPR * 1000000);
                inputRow5["MAY"] = dMAY == 0 ? 0 : (rsltDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3)) / dMAY * 1000000);
                inputRow5["JUN"] = dJUN == 0 ? 0 : (rsltDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3)) / dJUN * 1000000);
                inputRow5["JUL"] = dJUL == 0 ? 0 : (rsltDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3)) / dJUL * 1000000);
                inputRow5["AUG"] = dAUG == 0 ? 0 : (rsltDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3)) / dAUG * 1000000);
                inputRow5["SEP"] = dSEP == 0 ? 0 : (rsltDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3)) / dSEP * 1000000);
                inputRow5["OCT"] = dOCT == 0 ? 0 : (rsltDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3)) / dOCT * 1000000);
                inputRow5["DEC"] = dDEC == 0 ? 0 : (rsltDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3)) / dDEC * 1000000);
                inputRow5["NOV"] = dNOV == 0 ? 0 : (rsltDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3)) / dNOV * 1000000);
                inputRow5["AVG"] = dAVG == 0 ? 0 : (rsltDt.SUM(colName3) / dAVG * 1000000);
                inputTable.Rows.Add(inputRow5);
				#endregion

				SetChartData(inputRow5);

                acGridView1.GridControl.DataSource = inputTable;
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SetChartGoalData(DataTable inputTable, DataTable goalTable)
        {
            try
            {
                decimal janGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("01")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal febGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("02")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal marGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("03")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal aprGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("04")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal mayGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("05")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal junGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("06")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal julGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("07")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal augGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("08")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal sepGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("09")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal octGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("10")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal decGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("11")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal novGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("PROC_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("12")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();

                DataRow inputRow = inputTable.NewRow();
                inputRow["GUBUN"] = "금년 목표";
                inputRow["JAN"] = janGoal;
                inputRow["FEB"] = febGoal;
                inputRow["MAR"] = marGoal;
                inputRow["APR"] = aprGoal;
                inputRow["MAY"] = mayGoal;
                inputRow["JUN"] = junGoal;
                inputRow["JUL"] = julGoal;
                inputRow["AUG"] = augGoal;
                inputRow["SEP"] = sepGoal;
                inputRow["OCT"] = octGoal;
                inputRow["DEC"] = decGoal;
                inputRow["NOV"] = novGoal;
                inputRow["AVG"] = (janGoal +
                                  febGoal +
                                  marGoal +
                                  aprGoal +
                                  mayGoal +
                                  junGoal +
                                  julGoal +
                                  augGoal +
                                  sepGoal +
                                  octGoal +
                                  decGoal +
                                  novGoal) / 12;
                inputTable.Rows.Add(inputRow);

                SeriesPoint goalSeries1 = new SeriesPoint("[1월]", new object[] { janGoal });
                SeriesPoint goalSeries2 = new SeriesPoint("[2월]", new object[] { febGoal });
                SeriesPoint goalSeries3 = new SeriesPoint("[3월]", new object[] { marGoal });
                SeriesPoint goalSeries4 = new SeriesPoint("[4월]", new object[] { aprGoal });
                SeriesPoint goalSeries5 = new SeriesPoint("[5월]", new object[] { mayGoal });
                SeriesPoint goalSeries6 = new SeriesPoint("[6월]", new object[] { junGoal });
                SeriesPoint goalSeries7 = new SeriesPoint("[7월]", new object[] { julGoal });
                SeriesPoint goalSeries8 = new SeriesPoint("[8월]", new object[] { augGoal });
                SeriesPoint goalSeries9 = new SeriesPoint("[9월]", new object[] { sepGoal });
                SeriesPoint goalSeries10  = new SeriesPoint("[10월]", new object[] { octGoal });
                SeriesPoint goalSeries11  = new SeriesPoint("[11월]", new object[] { decGoal });
                SeriesPoint goalSeries12  = new SeriesPoint("[12월]", new object[] { novGoal });
                acChartControl1.AddSeriesPoint("GOAL", goalSeries1);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries2);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries3);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries4);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries5);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries6);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries7);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries8);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries9);
                acChartControl1.AddSeriesPoint("GOAL",  goalSeries10);
                acChartControl1.AddSeriesPoint("GOAL",  goalSeries11);
                acChartControl1.AddSeriesPoint("GOAL", goalSeries12);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SetChartData(DataRow inputRow)
        {
            try
            {
                SeriesPoint idleTime1 = new SeriesPoint("[1월]", new object[] { Math.Round(inputRow["JAN"].toDecimal(),1) });
                SeriesPoint idleTime2 = new SeriesPoint("[2월]", new object[] { Math.Round(inputRow["FEB"].toDecimal(),1) });
                SeriesPoint idleTime3 = new SeriesPoint("[3월]", new object[] { Math.Round(inputRow["MAR"].toDecimal(),1) });
                SeriesPoint idleTime4 = new SeriesPoint("[4월]", new object[] { Math.Round(inputRow["APR"].toDecimal(),1) });
                SeriesPoint idleTime5 = new SeriesPoint("[5월]", new object[] { Math.Round(inputRow["MAY"].toDecimal(),1) });
                SeriesPoint idleTime6 = new SeriesPoint("[6월]", new object[] { Math.Round(inputRow["JUN"].toDecimal(),1) });
                SeriesPoint idleTime7 = new SeriesPoint("[7월]", new object[] { Math.Round(inputRow["JUL"].toDecimal(),1) });
                SeriesPoint idleTime8 = new SeriesPoint("[8월]", new object[] { Math.Round(inputRow["AUG"].toDecimal(),1) });
                SeriesPoint idleTime9 = new SeriesPoint("[9월]", new object[] { Math.Round(inputRow["SEP"].toDecimal(),1) });
                SeriesPoint idleTime10 = new SeriesPoint("[10월]", new object[] { Math.Round(inputRow["OCT"].toDecimal(),1) });
                SeriesPoint idleTime11 = new SeriesPoint("[11월]", new object[] { Math.Round(inputRow["DEC"].toDecimal(),1) });
                SeriesPoint idleTime12 = new SeriesPoint("[12월]", new object[] { Math.Round(inputRow["NOV"].toDecimal(),1) });
                SeriesPoint idleTimeAvg = new SeriesPoint("[평균]", new object[] { Math.Round(inputRow["AVG"].toDecimal(), 1) });
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime1);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime2);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime3); 
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime4);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime5);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime6);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime7);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime8);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime9);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime10);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime11);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTime12);
                acChartControl1.AddSeriesPoint("NG_QTY", idleTimeAvg);
               
                foreach (string key in acChartControl1.SeriesDic.Keys)
                {
                    SideBySideBarSeriesView view = acChartControl1.SeriesDic[key].View as SideBySideBarSeriesView;
                    if (view == null) continue;
                    view.FillStyle.FillMode = FillMode.Solid;
                }
            }
            catch(Exception ex)
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

    }
}
