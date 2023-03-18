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
    public partial class REP18A_M0A : BaseMenu
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

        public REP18A_M0A()
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


            acChartControl1.AddLineSeries("PPM", "PPM", "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Bar);
            acChartControl1.AddLineSeries("GOAL", "납품불량 목표 PPM", "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

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

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP18A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                DataTable rsltShipDt = e.result.Tables["RSLTDT_SHIP"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    DUE_QTY = r.Sum(s => s["SHIP_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable rsltShipDt1YAgo = e.result.Tables["RSLTDT_SHIP_1Y_AGO"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    DUE_QTY = r.Sum(s => s["SHIP_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable rsltAsDt = e.result.Tables["RSLTDT_AS"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    RE_QTY = r.Sum(s => s["AS_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable rsltNgDt = e.result.Tables["RSLTDT_NG"].AsEnumerable()
                                .GroupBy(g => new
                                {
                                    PLT_CODE = g["PLT_CODE"],
                                    SMONTH = g["MONTH"],
                                })
                                .Select(r => new
                                {
                                    PLT_CODE = r.Key.PLT_CODE,
                                    MONTH = r.Key.SMONTH,
                                    NG_QTY = r.Sum(s => s["NG_QTY"].toDecimal()),
                                })
                                .LINQToDataTable();

                DataTable rsltNgDt1YAgo = e.result.Tables["RSLTDT_NG_1Y_AGO"].AsEnumerable()
                               .GroupBy(g => new
                               {
                                   PLT_CODE = g["PLT_CODE"],
                                   SMONTH = g["MONTH"],
                               })
                               .Select(r => new
                               {
                                   PLT_CODE = r.Key.PLT_CODE,
                                   MONTH = r.Key.SMONTH,
                                   NG_QTY = r.Sum(s => s["NG_QTY"].toDecimal()),
                               })
                               .LINQToDataTable();

                DataTable inputTable = acGridView1.NewTable();


                string colName1 = "DUE_QTY";
                string colName2 = "RE_QTY";
                string colName3 = "NG_QTY";

                #region 전년도 PPM
                {
                    decimal dJAN_1YAgo = rsltShipDt1YAgo.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName1));
                    decimal dFEB_1YAgo = rsltShipDt1YAgo.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName1));
                    decimal dMAR_1YAgo = rsltShipDt1YAgo.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAPR_1YAgo = rsltShipDt1YAgo.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName1));
                    decimal dMAY_1YAgo = rsltShipDt1YAgo.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName1));
                    decimal dJUN_1YAgo = rsltShipDt1YAgo.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName1));
                    decimal dJUL_1YAgo = rsltShipDt1YAgo.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAUG_1YAgo = rsltShipDt1YAgo.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName1));
                    decimal dSEP_1YAgo = rsltShipDt1YAgo.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName1));
                    decimal dOCT_1YAgo = rsltShipDt1YAgo.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName1));
                    decimal dDEC_1YAgo = rsltShipDt1YAgo.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName1));
                    decimal dNOV_1YAgo = rsltShipDt1YAgo.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName1));
                    decimal dAVG_1YAgo = rsltShipDt1YAgo.SUM(colName1);

                    DataRow inputRow = inputTable.NewRow();
                    inputRow["GUBUN"] = "전년도 확정 불량 PPM";
                    inputRow["JAN"] = (dJAN_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3)) / dJAN_1YAgo * 1000000);
                    inputRow["FEB"] = (dFEB_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3)) / dFEB_1YAgo * 1000000);
                    inputRow["MAR"] = (dMAR_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3)) / dMAR_1YAgo * 1000000);
                    inputRow["APR"] = (dAPR_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3)) / dAPR_1YAgo * 1000000);
                    inputRow["MAY"] = (dMAY_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3)) / dMAY_1YAgo * 1000000);
                    inputRow["JUN"] = (dJUN_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3)) / dJUN_1YAgo * 1000000);
                    inputRow["JUL"] = (dJUL_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3)) / dJUL_1YAgo * 1000000);
                    inputRow["AUG"] = (dAUG_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3)) / dAUG_1YAgo * 1000000);
                    inputRow["SEP"] = (dSEP_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3)) / dSEP_1YAgo * 1000000);
                    inputRow["OCT"] = (dOCT_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3)) / dOCT_1YAgo * 1000000);
                    inputRow["DEC"] = (dDEC_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3)) / dDEC_1YAgo * 1000000);
                    inputRow["NOV"] = (dNOV_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3)) / dNOV_1YAgo * 1000000);
                    inputRow["AVG"] = (dAVG_1YAgo == 0 || rsltNgDt1YAgo.Rows.Count == 0) ? 0 : (rsltNgDt1YAgo.SUM(colName3) / dAVG_1YAgo * 1000000);                            
                    inputTable.Rows.Add(inputRow);
                }
                #endregion

                SetChartGoalData(inputTable, e.result.Tables["RSLTDT_GOAL"]);

                #region 납품 수량
                DataRow inputRow1 = inputTable.NewRow();
                inputRow1["GUBUN"] = "납품 수량";
                decimal dJAN = rsltShipDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName1));
                decimal dFEB = rsltShipDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName1));
                decimal dMAR = rsltShipDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName1));
                decimal dAPR = rsltShipDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName1));
                decimal dMAY = rsltShipDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName1));
                decimal dJUN = rsltShipDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName1));
                decimal dJUL = rsltShipDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName1));
                decimal dAUG = rsltShipDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName1));
                decimal dSEP = rsltShipDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName1));
                decimal dOCT = rsltShipDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName1));
                decimal dDEC = rsltShipDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName1));
                decimal dNOV = rsltShipDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName1));
                decimal dAVG = rsltShipDt.SUM(colName1);
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

                #region 반품 수량
				DataRow inputRow2 = inputTable.NewRow();
                inputRow2["GUBUN"] = "반품 수량";
                inputRow2["JAN"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["FEB"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["MAR"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["APR"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["MAY"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["JUN"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["JUL"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["AUG"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["SEP"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["OCT"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["DEC"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["NOV"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName2));
                inputRow2["AVG"] = rsltAsDt.Rows.Count == 0 ? 0 : rsltAsDt.SUM(colName2);
                inputTable.Rows.Add(inputRow2);
				#endregion

                #region 확정불량 수량
				DataRow inputRow3 = inputTable.NewRow();
                inputRow3["GUBUN"] = "확정불량 수량";
                inputRow3["JAN"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["FEB"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["MAR"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["APR"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["MAY"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["JUN"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["JUL"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["AUG"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["SEP"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["OCT"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["DEC"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["NOV"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3));
                inputRow3["AVG"] = rsltNgDt.Rows.Count == 0 ? 0 : rsltNgDt.SUM(colName3);
                inputTable.Rows.Add(inputRow3);
				#endregion

                #region PPM
				DataRow inputRow4 = inputTable.NewRow();
                inputRow4["GUBUN"] = "PPM";
                inputRow4["JAN"] = (dJAN == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='01'").Sum(s => s.Field<decimal>(colName3)) / dJAN * 1000000);
                inputRow4["FEB"] = (dFEB == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='02'").Sum(s => s.Field<decimal>(colName3)) / dFEB * 1000000);
                inputRow4["MAR"] = (dMAR == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='03'").Sum(s => s.Field<decimal>(colName3)) / dMAR * 1000000);
                inputRow4["APR"] = (dAPR == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='04'").Sum(s => s.Field<decimal>(colName3)) / dAPR * 1000000);
                inputRow4["MAY"] = (dMAY == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='05'").Sum(s => s.Field<decimal>(colName3)) / dMAY * 1000000);
                inputRow4["JUN"] = (dJUN == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='06'").Sum(s => s.Field<decimal>(colName3)) / dJUN * 1000000);
                inputRow4["JUL"] = (dJUL == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='07'").Sum(s => s.Field<decimal>(colName3)) / dJUL * 1000000);
                inputRow4["AUG"] = (dAUG == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='08'").Sum(s => s.Field<decimal>(colName3)) / dAUG * 1000000);
                inputRow4["SEP"] = (dSEP == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='09'").Sum(s => s.Field<decimal>(colName3)) / dSEP * 1000000);
                inputRow4["OCT"] = (dOCT == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='10'").Sum(s => s.Field<decimal>(colName3)) / dOCT * 1000000);
                inputRow4["DEC"] = (dDEC == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='11'").Sum(s => s.Field<decimal>(colName3)) / dDEC * 1000000);
                inputRow4["NOV"] = (dNOV == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.Select("MONTH='12'").Sum(s => s.Field<decimal>(colName3)) / dNOV * 1000000);
                inputRow4["AVG"] = (dAVG == 0 || rsltNgDt.Rows.Count == 0) ? 0 : (rsltNgDt.SUM(colName3) / dAVG * 1000000);
                inputTable.Rows.Add(inputRow4);
				#endregion

				SetChartData(inputRow4);

                acGridView1.GridControl.DataSource = inputTable;
                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                decimal janGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("01")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal febGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("02")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal marGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("03")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal aprGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("04")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal mayGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("05")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal junGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("06")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal julGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("07")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal augGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("08")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal sepGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("09")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal octGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("10")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal decGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("11")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
                decimal novGoal = goalTable.AsEnumerable().Where(w => w["GUBUN"].Equals("DUE_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("12")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();

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
                                  novGoal) /12;
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
                acChartControl1.AddSeriesPoint("PPM", idleTime1);
                acChartControl1.AddSeriesPoint("PPM", idleTime2);
                acChartControl1.AddSeriesPoint("PPM", idleTime3); 
                acChartControl1.AddSeriesPoint("PPM", idleTime4);
                acChartControl1.AddSeriesPoint("PPM", idleTime5);
                acChartControl1.AddSeriesPoint("PPM", idleTime6);
                acChartControl1.AddSeriesPoint("PPM", idleTime7);
                acChartControl1.AddSeriesPoint("PPM", idleTime8);
                acChartControl1.AddSeriesPoint("PPM", idleTime9);
                acChartControl1.AddSeriesPoint("PPM", idleTime10);
                acChartControl1.AddSeriesPoint("PPM", idleTime11);
                acChartControl1.AddSeriesPoint("PPM", idleTime12);
                acChartControl1.AddSeriesPoint("PPM", idleTimeAvg);
               
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
