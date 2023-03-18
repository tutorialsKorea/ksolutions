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
	public partial class REP21A_M0A : BaseMenu
	{
		DataTable _DDt = null;
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

		public REP21A_M0A()
		{
			InitializeComponent();

			acLayoutControl1.GetEditor("SYEAR").Value = DateTime.Now;

			acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

			acGridView1.CellMerge += AcGridView1_CellMerge;
			acGridView1.CustomColumnDisplayText += AcGridView1_CustomColumnDisplayText;
			acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
		}

		private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
		{
			try{
				switch(e.RowHandle)
				{
					case 3:
					case 4:
						e.Appearance.BackColor = Color.LightYellow;
						break;
					case 7:
						e.Appearance.BackColor = Color.LightGoldenrodYellow;
						break;
				}
			}
			catch
			{

			}
		}

		private void AcGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			try
			{
				if (!e.Column.FieldName.Equals("GUBUN"))
				{
					switch(e.ListSourceRowIndex)
					{
						case 4:
						case 6:
						case 9:
							e.DisplayText = String.Format("{0:p1}", e.Value);
							break;
						default:
							e.DisplayText = String.Format("{0:n0}", e.Value);
							break;
					}
				}
			}
			catch
			{
			}
		}

		private void AcGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
		{
			try{
				if (e.Column.FieldName.Equals("GUBUN")
					   && e.CellValue1.ToString().Equals(e.CellValue2))
				{
					e.Merge = true;
				}
				else
				{
					e.Merge = false;
				}

				e.Handled = true;
			}
			catch
			{

			}
		}

		public override void MenuInit()
		{
			base.MenuInit();


			acGridView1.OptionsView.AllowCellMerge = true;

			//acChartControl1.chartControl.Titles. = "Q-COST 점유율 현황 (제조원가대비)";
			//acChartControl2.chartControl.Titles = "실패(F), 평가(P), 예방(A) 비용 점유율 현황";

			acChartControl1.AddLineSeries("QCOST", "Q-COST 점유율", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
			acChartControl1.AddLineSeries("QCOST_GOAL", "Q-COST 목표", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

			acChartControl2.AddLineSeries("FCOST", "F-COST 점유율", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
			acChartControl2.AddLineSeries("PACOST", "P,A-COST 점유율", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
			acChartControl2.AddLineSeries("FCOST_GOAL", "F-COST 목표", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
			acChartControl2.AddLineSeries("PACOST_GOAL", "P,A-COST 목표", "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);

			foreach (string key in acChartControl1.SeriesDic.Keys)
			{
				if (key.Equals("QCOST_GOAL"))
				{
					LineSeriesView view = acChartControl1.SeriesDic[key].View as LineSeriesView;
					if (view == null) continue;
					view.LineStyle.DashStyle = DashStyle.Dash;
				}
				else
				{
					LineSeriesView view = acChartControl1.SeriesDic[key].View as LineSeriesView;
					if (view == null) continue;
					view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				}
			}

			foreach (string key in acChartControl2.SeriesDic.Keys)
			{
				if (key.Equals("FCOST_GOAL")
					|| key.Equals("PACOST_GOAL"))
				{
					LineSeriesView view = acChartControl2.SeriesDic[key].View as LineSeriesView;
					if (view == null) continue;
					view.LineStyle.DashStyle = DashStyle.Dash;
				}
				else
				{
					LineSeriesView view = acChartControl2.SeriesDic[key].View as LineSeriesView;
					if (view == null) continue;
					view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
				}
			}

			//acGridView1.AddTextEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
			acGridView1.AddMemoEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
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
			acGridView1.AddTextEdit("SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);

			acGridView1.Columns["GUBUN"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

			_DDt = acStdCodes.GetCatTableByServer("M036");
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
			paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

			DataRow paramRow = paramTable.NewRow();
			paramRow["PLT_CODE"] = acInfo.PLT_CODE;
			paramRow["YEAR"] = layoutRow["SYEAR"];
			paramRow["DATA_FLAG"] = 0;

			paramTable.Rows.Add(paramRow);
			DataSet paramSet = new DataSet();
			paramSet.Tables.Add(paramTable);

			BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP21A_SER", paramSet, "RQSTDT", "RSLTDT",
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
				decimal[] iInNgCost = new decimal[12];
				decimal[] iCusNgCost = new decimal[12];
				decimal[] iCusClaimCost = new decimal[12];
				decimal[] iFCost = new decimal[12];
				decimal[] iPACost = new decimal[12];
				decimal[] iSalesCost = new decimal[12];

				DataTable dtRsltNg = e.result.Tables["RSLTDT_NG"];
				DataTable dtRsltPNg = e.result.Tables["RSLTDT_PNG"];
				DataTable dtRsltAs = e.result.Tables["RSLTDT_AS"];
				DataTable dtRsltQct = e.result.Tables["RSLTDT_QCT"];
				DataTable dtRsltShip = e.result.Tables["RSLTDT_SHIP"].AsEnumerable()
																	 .Select(r=> new
																	 {
																		PLT_CODE = r["PLT_CODE"],
																		MONTH = r["SHIP_DATE"].ToString().Substring(4,2),
																		COST  = r["UNIT_COST"]
																	 })
																	 .LINQToDataTable();
				DataTable dtRsltGoal = e.result.Tables["RSLTDT_GOAL"];

				DataTable inputTable = acGridView1.NewTable();

				#region 사내실패 비용
				{
					//FCOST => 사내실패코스트
					string[] inNgCostCatCodes = _DDt.AsEnumerable().Where(w=>w["CD_PARENT"].ToString().Equals("FCOST")).Select(r=>r["CD_CODE"].ToString()).ToArray();
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "사내실패 비용";
					for (int i = 0; i < 12; i++)
					{
						//iInNgCost[i] = dtRsltQct.Rows.Count == 0 ? 0 : dtRsltQct.Select("MONTH='" + string.Format("{0:D2}", (i + 1)) + "' AND MGUBUN = 'FCOST'").Sum(s => s["NG_COST"].toDecimal());
						iInNgCost[i] = dtRsltNg.AsEnumerable().Where(w=> inNgCostCatCodes.Contains(w["GUBUN"].ToString()) && w["MONTH"].Equals(string.Format("{0:D2}", (i + 1)))).Sum(s => s.Field<decimal>("COST"))
									 + dtRsltPNg.AsEnumerable().Where(w => inNgCostCatCodes.Contains(w["GUBUN"].ToString()) && w["MONTH"].Equals(string.Format("{0:D2}", (i + 1)))).Sum(s => s.Field<decimal>("COST"))
									 + dtRsltQct.AsEnumerable().Where(w => inNgCostCatCodes.Contains(w["GUBUN"].ToString()) && w["MONTH"].Equals(string.Format("{0:D2}", (i + 1)))).Sum(s => s.Field<decimal>("COST"));
					}

					inputRow["JAN"] = iInNgCost[0];
					inputRow["FEB"] = iInNgCost[1];
					inputRow["MAR"] = iInNgCost[2];
					inputRow["APR"] = iInNgCost[3];
					inputRow["MAY"] = iInNgCost[4];
					inputRow["JUN"] = iInNgCost[5];
					inputRow["JUL"] = iInNgCost[6];
					inputRow["AUG"] = iInNgCost[7];
					inputRow["SEP"] = iInNgCost[8];
					inputRow["OCT"] = iInNgCost[9];
					inputRow["DEC"] = iInNgCost[10];
					inputRow["NOV"] = iInNgCost[11];
					inputRow["SUM"] = iInNgCost.Sum();

					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region 고객실패 비용
				{
					//EFCOST => 고객실패코스트
					string[] cusNgCostCatCodes = _DDt.AsEnumerable().Where(w => w["CD_PARENT"].ToString().Equals("EFCOST")).Select(r => r["CD_CODE"].ToString()).ToArray();
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "고객실패 비용";

					for (int i = 0; i < 12; i++)
					{
						//GUBUN 9 => 클레임 비용
						//iCusNgCost[i] = dtRsltQct.Rows.Count == 0 ? 0 : dtRsltQct.Select("MGUBUN = 'EFCOST' AND GUBUN <> '9' AND MONTH='" + string.Format("{0:D2}", (i+1)) + "'").Sum(s => s["COST"].toDecimal());
						iCusNgCost[i] = dtRsltAs.AsEnumerable().Where(w => cusNgCostCatCodes.Contains(w["GUBUN"].ToString()) && w["MONTH"].Equals(string.Format("{0:D2}", (i + 1)))).Sum(s => s.Field<decimal>("COST"))
										+ dtRsltQct.AsEnumerable().Where(w => !w["GUBUN"].Equals("9") && cusNgCostCatCodes.Contains(w["GUBUN"].ToString()) && w["MONTH"].Equals(string.Format("{0:D2}", (i + 1)))).Sum(s => s.Field<decimal>("COST"));
					}

					inputRow["JAN"] = iCusNgCost[0];
					inputRow["FEB"] = iCusNgCost[1];
					inputRow["MAR"] = iCusNgCost[2];
					inputRow["APR"] = iCusNgCost[3];
					inputRow["MAY"] = iCusNgCost[4];
					inputRow["JUN"] = iCusNgCost[5];
					inputRow["JUL"] = iCusNgCost[6];
					inputRow["AUG"] = iCusNgCost[7];
					inputRow["SEP"] = iCusNgCost[8];
					inputRow["OCT"] = iCusNgCost[9];
					inputRow["DEC"] = iCusNgCost[10];
					inputRow["NOV"] = iCusNgCost[11];
					//inputRow["SUM"] = dtRsltAs.Rows.Count == 0 ? 0 : (dtRsltAs.Select("GUBUN = '8'").Sum(s => s["COST"].toDecimal()));
					inputRow["SUM"] = iCusNgCost.Sum();
					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region 고객 클레임 비용
				{
					//GUBUN 9는 클레임 비용
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "고객 CLAIM비용";
					for (int i = 0; i < 12; i++)
					{
						iCusClaimCost[i] = dtRsltAs.Rows.Count == 0 ? 0 : dtRsltAs.Select("GUBUN = '9' AND MONTH='" + string.Format("{0:D2}", (i + 1)) + "'").Sum(s => s["COST"].toDecimal());
					}

					inputRow["JAN"] = iCusClaimCost[0];
					inputRow["FEB"] = iCusClaimCost[1];
					inputRow["MAR"] = iCusClaimCost[2];
					inputRow["APR"] = iCusClaimCost[3];
					inputRow["MAY"] = iCusClaimCost[4];
					inputRow["JUN"] = iCusClaimCost[5];
					inputRow["JUL"] = iCusClaimCost[6];
					inputRow["AUG"] = iCusClaimCost[7];
					inputRow["SEP"] = iCusClaimCost[8];
					inputRow["OCT"] = iCusClaimCost[9];
					inputRow["DEC"] = iCusClaimCost[10];
					inputRow["NOV"] = iCusClaimCost[11];
					inputRow["SUM"] = dtRsltAs.Rows.Count == 0 ? 0 : (dtRsltAs.Select("GUBUN = '9'").Sum(s => s["COST"].toDecimal()));
					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region F-COST, [P,A-COST]
				{
					for (int i = 0; i < 12; i++)
					{
						iFCost[i] = iInNgCost[i] + iCusNgCost[i] + iCusClaimCost[i];
					}

					for (int i = 0; i < 12; i++)
					{
						iPACost[i] = dtRsltQct.Rows.Count == 0 ? 0 : (dtRsltQct.Select("(MGUBUN='PYEONGGA' OR MGUBUN='YEBANG') AND MONTH='" + string.Format("{0:D2}", (i + 1)) + "'").Sum(s => s["COST"].toDecimal()));
					}

				}
				#endregion

				#region F-COST
				{
					DataRow inputRow1 = inputTable.NewRow();
					inputRow1["GUBUN"] = "F-COST" + Environment.NewLine + "(실패비용)";
					inputRow1["JAN"] = iFCost[0];
					inputRow1["FEB"] = iFCost[1];
					inputRow1["MAR"] = iFCost[2];
					inputRow1["APR"] = iFCost[3];
					inputRow1["MAY"] = iFCost[4];
					inputRow1["JUN"] = iFCost[5];
					inputRow1["JUL"] = iFCost[6];
					inputRow1["AUG"] = iFCost[7];
					inputRow1["SEP"] = iFCost[8];
					inputRow1["OCT"] = iFCost[9];
					inputRow1["DEC"] = iFCost[10];
					inputRow1["NOV"] = iFCost[11];
					inputRow1["SUM"] = iFCost.Sum();
					inputTable.Rows.Add(inputRow1);

					DataRow inputRow2 = inputTable.NewRow();
					inputRow2["GUBUN"] = "F-COST" + Environment.NewLine + "(실패비용)";
					inputRow2["JAN"] = (iFCost[0] + iPACost[0]) == 0 ? 0 : (iFCost[0]/ (iFCost[0] + iPACost[0]));
					inputRow2["FEB"] = (iFCost[1] + iPACost[1]) == 0 ? 0 : (iFCost[1]/ (iFCost[1] + iPACost[1]));
					inputRow2["MAR"] = (iFCost[2] + iPACost[2]) == 0 ? 0 : (iFCost[2]/ (iFCost[2] + iPACost[2]));
					inputRow2["APR"] = (iFCost[3] + iPACost[3]) == 0 ? 0 : (iFCost[3]/ (iFCost[3] + iPACost[3]));
					inputRow2["MAY"] = (iFCost[4] + iPACost[4]) == 0 ? 0 : (iFCost[4]/ (iFCost[4] + iPACost[4]));
					inputRow2["JUN"] = (iFCost[5] + iPACost[5]) == 0 ? 0 : (iFCost[5]/ (iFCost[5] + iPACost[5]));
					inputRow2["JUL"] = (iFCost[6] + iPACost[6]) == 0 ? 0 : (iFCost[6]/ (iFCost[6] + iPACost[6]));
					inputRow2["AUG"] = (iFCost[7] + iPACost[7]) == 0 ? 0 : (iFCost[7]/ (iFCost[7] + iPACost[7]));
					inputRow2["SEP"] = (iFCost[8] + iPACost[8]) == 0 ? 0 : (iFCost[8]/ (iFCost[8] + iPACost[8]));
					inputRow2["OCT"] = (iFCost[9] + iPACost[9]) == 0 ? 0 : (iFCost[9]/ (iFCost[9] + iPACost[9]));
					inputRow2["DEC"] = (iFCost[10] + iPACost[10]) == 0 ? 0 : (iFCost[10] / (iFCost[10] + iPACost[10]));
					inputRow2["NOV"] = (iFCost[11] + iPACost[11]) == 0 ? 0 : (iFCost[11] / (iFCost[11] + iPACost[11]));
					inputRow2["SUM"] = (iFCost.Sum() + iPACost.Sum()) == 0 ? 0 : (iFCost.Sum() / (iFCost.Sum() + iPACost.Sum()));
					inputTable.Rows.Add(inputRow2);
				}
				#endregion

				#region P,A-COST
				{
					DataRow inputRow1 = inputTable.NewRow();
					inputRow1["GUBUN"] = "P,A-COST" + Environment.NewLine + "(평가/예방비용)";
					inputRow1["JAN"] = iPACost[0];
					inputRow1["FEB"] = iPACost[1];
					inputRow1["MAR"] = iPACost[2];
					inputRow1["APR"] = iPACost[3];
					inputRow1["MAY"] = iPACost[4];
					inputRow1["JUN"] = iPACost[5];
					inputRow1["JUL"] = iPACost[6];
					inputRow1["AUG"] = iPACost[7];
					inputRow1["SEP"] = iPACost[8];
					inputRow1["OCT"] = iPACost[9];
					inputRow1["DEC"] = iPACost[10];
					inputRow1["NOV"] = iPACost[11];
					inputRow1["SUM"] = iPACost.Sum();
					inputTable.Rows.Add(inputRow1);

					DataRow inputRow2 = inputTable.NewRow();
					inputRow2["GUBUN"] = "P,A-COST" + Environment.NewLine + "(평가/예방비용)";
					inputRow2["JAN"] = (iFCost[0] + iPACost[0]) == 0 ? 0 : (iPACost[0]/ (iFCost[0] + iPACost[0]));
					inputRow2["FEB"] = (iFCost[1] + iPACost[1]) == 0 ? 0 : (iPACost[1]/ (iFCost[1] + iPACost[1]));
					inputRow2["MAR"] = (iFCost[2] + iPACost[2]) == 0 ? 0 : (iPACost[2]/ (iFCost[2] + iPACost[2]));
					inputRow2["APR"] = (iFCost[3] + iPACost[3]) == 0 ? 0 : (iPACost[3]/ (iFCost[3] + iPACost[3]));
					inputRow2["MAY"] = (iFCost[4] + iPACost[4]) == 0 ? 0 : (iPACost[4]/ (iFCost[4] + iPACost[4]));
					inputRow2["JUN"] = (iFCost[5] + iPACost[5]) == 0 ? 0 : (iPACost[5]/ (iFCost[5] + iPACost[5]));
					inputRow2["JUL"] = (iFCost[6] + iPACost[6]) == 0 ? 0 : (iPACost[6]/ (iFCost[6] + iPACost[6]));
					inputRow2["AUG"] = (iFCost[7] + iPACost[7]) == 0 ? 0 : (iPACost[7]/ (iFCost[7] + iPACost[7]));
					inputRow2["SEP"] = (iFCost[8] + iPACost[8]) == 0 ? 0 : (iPACost[8]/ (iFCost[8] + iPACost[8]));
					inputRow2["OCT"] = (iFCost[9] + iPACost[9]) == 0 ? 0 : (iPACost[9]/ (iFCost[9] + iPACost[9]));
					inputRow2["DEC"] = (iFCost[10] + iPACost[10]) == 0 ? 0 : (iPACost[10] / (iFCost[10] + iPACost[10]));
					inputRow2["NOV"] = (iFCost[11] + iPACost[11]) == 0 ? 0 : (iPACost[11] / (iFCost[11] + iPACost[11]));
					inputRow2["SUM"] = (iFCost.Sum() + iPACost.Sum()) == 0 ? 0 : (iPACost.Sum() / (iFCost.Sum() + iPACost.Sum()));
					inputTable.Rows.Add(inputRow2);
				}
				#endregion

				#region Q-COST
				{
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "Q-COST";
					inputRow["JAN"] = iFCost[0] + iPACost[0];
					inputRow["FEB"] = iFCost[1] + iPACost[1];
					inputRow["MAR"] = iFCost[2] + iPACost[2];
					inputRow["APR"] = iFCost[3] + iPACost[3];
					inputRow["MAY"] = iFCost[4] + iPACost[4];
					inputRow["JUN"] = iFCost[5] + iPACost[5];
					inputRow["JUL"] = iFCost[6] + iPACost[6];
					inputRow["AUG"] = iFCost[7] + iPACost[7];
					inputRow["SEP"] = iFCost[8] + iPACost[8];
					inputRow["OCT"] = iFCost[9] + iPACost[9];
					inputRow["DEC"] = iFCost[10] + iPACost[10];
					inputRow["NOV"] = iFCost[11] + iPACost[11];
					inputRow["SUM"] = iFCost.Sum() + iPACost.Sum();
					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region 매출 실적
				{
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "매출 실적";
					for (int i = 0; i < 12; i++)
					{
						iSalesCost[i] = dtRsltShip.Rows.Count == 0 ? 0 : dtRsltShip.Select("MONTH='" + string.Format("{0:D2}", (i + 1)) + "'").Sum(s => s["COST"].toDecimal());
					}
					inputRow["JAN"] = iSalesCost[0];
					inputRow["FEB"] = iSalesCost[1];
					inputRow["MAR"] = iSalesCost[2];
					inputRow["APR"] = iSalesCost[3];
					inputRow["MAY"] = iSalesCost[4];
					inputRow["JUN"] = iSalesCost[5];
					inputRow["JUL"] = iSalesCost[6];
					inputRow["AUG"] = iSalesCost[7];
					inputRow["SEP"] = iSalesCost[8];
					inputRow["OCT"] = iSalesCost[9];
					inputRow["DEC"] = iSalesCost[10];
					inputRow["NOV"] = iSalesCost[11];
					inputRow["SUM"] = iSalesCost.Sum();
					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region 발생 점유율
				{
					DataRow inputRow = inputTable.NewRow();
					inputRow["GUBUN"] = "Q-COST 발생" + Environment.NewLine + "점유율(%)";
					inputRow["JAN"] = iSalesCost[0] == 0 ? 0 : ((iFCost[0] + iPACost[0]) / iSalesCost[0]);
					inputRow["FEB"] = iSalesCost[1] == 0 ? 0 : ((iFCost[1] + iPACost[1]) / iSalesCost[1]);
					inputRow["MAR"] = iSalesCost[2] == 0 ? 0 : ((iFCost[2] + iPACost[2]) / iSalesCost[2]);
					inputRow["APR"] = iSalesCost[3] == 0 ? 0 : ((iFCost[3] + iPACost[3]) / iSalesCost[3]);
					inputRow["MAY"] = iSalesCost[4] == 0 ? 0 : ((iFCost[4] + iPACost[4]) / iSalesCost[4]);
					inputRow["JUN"] = iSalesCost[5] == 0 ? 0 : ((iFCost[5] + iPACost[5]) / iSalesCost[5]);
					inputRow["JUL"] = iSalesCost[6] == 0 ? 0 : ((iFCost[6] + iPACost[6]) / iSalesCost[6]);
					inputRow["AUG"] = iSalesCost[7] == 0 ? 0 : ((iFCost[7] + iPACost[7]) / iSalesCost[7]);
					inputRow["SEP"] = iSalesCost[8] == 0 ? 0 : ((iFCost[8] + iPACost[8]) / iSalesCost[8]);
					inputRow["OCT"] = iSalesCost[9] == 0 ? 0 : ((iFCost[9] + iPACost[9]) / iSalesCost[9]);
					inputRow["DEC"] = iSalesCost[10] == 0 ? 0 : ((iFCost[10] + iPACost[10]) / iSalesCost[10]);
					inputRow["NOV"] = iSalesCost[11] == 0 ? 0 : ((iFCost[11] + iPACost[11]) / iSalesCost[11]);
					inputRow["SUM"] = iSalesCost.Sum() == 0 ? 0 : ((iFCost.Sum() + iPACost.Sum()) / iSalesCost.Sum());
					inputTable.Rows.Add(inputRow);
				}
				#endregion

				#region 차트
				{
					acChartControl1.ClearSeriesPoint();
					acChartControl2.ClearSeriesPoint();

					SeriesPoint qCostSeries1 = new SeriesPoint("[1월]", new object[] { Math.Round(iSalesCost[0] == 0 ? 0 : ((iFCost[0] + iPACost[0]) / iSalesCost[0] * 100), 1) });
					SeriesPoint qCostSeries2 = new SeriesPoint("[2월]", new object[] { Math.Round(iSalesCost[1] == 0 ? 0 : ((iFCost[1] + iPACost[1]) / iSalesCost[1] * 100), 1) });
					SeriesPoint qCostSeries3 = new SeriesPoint("[3월]", new object[] { Math.Round(iSalesCost[2] == 0 ? 0 : ((iFCost[2] + iPACost[2]) / iSalesCost[2] * 100), 1) });
					SeriesPoint qCostSeries4 = new SeriesPoint("[4월]", new object[] { Math.Round(iSalesCost[3] == 0 ? 0 : ((iFCost[3] + iPACost[3]) / iSalesCost[3] * 100), 1) });
					SeriesPoint qCostSeries5 = new SeriesPoint("[5월]", new object[] { Math.Round(iSalesCost[4] == 0 ? 0 : ((iFCost[4] + iPACost[4]) / iSalesCost[4] * 100), 1) });
					SeriesPoint qCostSeries6 = new SeriesPoint("[6월]", new object[] { Math.Round(iSalesCost[5] == 0 ? 0 : ((iFCost[5] + iPACost[5]) / iSalesCost[5] * 100), 1) });
					SeriesPoint qCostSeries7 = new SeriesPoint("[7월]", new object[] { Math.Round(iSalesCost[6] == 0 ? 0 : ((iFCost[6] + iPACost[6]) / iSalesCost[6] * 100), 1) });
					SeriesPoint qCostSeries8 = new SeriesPoint("[8월]", new object[] { Math.Round(iSalesCost[7] == 0 ? 0 : ((iFCost[7] + iPACost[7]) / iSalesCost[7] * 100), 1) });
					SeriesPoint qCostSeries9 = new SeriesPoint("[9월]", new object[] { Math.Round(iSalesCost[8] == 0 ? 0 : ((iFCost[8] + iPACost[8]) / iSalesCost[8] * 100), 1) });
					SeriesPoint qCostSeries10 = new SeriesPoint("[10월]", new object[] { Math.Round(iSalesCost[9] == 0 ? 0 : ((iFCost[9] + iPACost[9]) / iSalesCost[9] * 100), 1) });
					SeriesPoint qCostSeries11 = new SeriesPoint("[11월]", new object[] { Math.Round(iSalesCost[10] == 0 ? 0 : ((iFCost[10] + iPACost[10]) / iSalesCost[10] * 100), 1) });
					SeriesPoint qCostSeries12 = new SeriesPoint("[12월]", new object[] { Math.Round(iSalesCost[11] == 0 ? 0 : ((iFCost[11] + iPACost[11]) / iSalesCost[11] * 100), 1) });
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries1);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries2);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries3);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries4);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries5);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries6);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries7);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries8);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries9);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries10);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries11);
					acChartControl1.AddSeriesPoint("QCOST", qCostSeries12);


					SeriesPoint fCostSeries1 = new SeriesPoint("[1월]", new object[] { Math.Round((iFCost[0] + iPACost[0]) == 0 ? 0 : (iFCost[0] / (iFCost[0] + iPACost[0]) * 100),1) });
					SeriesPoint fCostSeries2 = new SeriesPoint("[2월]", new object[] { Math.Round((iFCost[1] + iPACost[1]) == 0 ? 0 : (iFCost[1] / (iFCost[1] + iPACost[1]) * 100), 1) });
					SeriesPoint fCostSeries3 = new SeriesPoint("[3월]", new object[] { Math.Round((iFCost[2] + iPACost[2]) == 0 ? 0 : (iFCost[2] / (iFCost[2] + iPACost[2]) * 100), 1) });
					SeriesPoint fCostSeries4 = new SeriesPoint("[4월]", new object[] { Math.Round((iFCost[3] + iPACost[3]) == 0 ? 0 : (iFCost[3] / (iFCost[3] + iPACost[3]) * 100), 1) });
					SeriesPoint fCostSeries5 = new SeriesPoint("[5월]", new object[] { Math.Round((iFCost[4] + iPACost[4]) == 0 ? 0 : (iFCost[4] / (iFCost[4] + iPACost[4]) * 100), 1) });
					SeriesPoint fCostSeries6 = new SeriesPoint("[6월]", new object[] { Math.Round((iFCost[5] + iPACost[5]) == 0 ? 0 : (iFCost[5] / (iFCost[5] + iPACost[5]) * 100), 1) });
					SeriesPoint fCostSeries7 = new SeriesPoint("[7월]", new object[] { Math.Round((iFCost[6] + iPACost[6]) == 0 ? 0 : (iFCost[6] / (iFCost[6] + iPACost[6]) * 100), 1) });
					SeriesPoint fCostSeries8 = new SeriesPoint("[8월]", new object[] { Math.Round((iFCost[7] + iPACost[7]) == 0 ? 0 : (iFCost[7] / (iFCost[7] + iPACost[7]) * 100), 1) });
					SeriesPoint fCostSeries9 = new SeriesPoint("[9월]", new object[] { Math.Round((iFCost[8] + iPACost[8]) == 0 ? 0 : (iFCost[8] / (iFCost[8] + iPACost[8]) * 100), 1) });
					SeriesPoint fCostSeries10 = new SeriesPoint("[10월]", new object[] { Math.Round((iFCost[9] + iPACost[9]) == 0 ? 0 : (iFCost[9] / (iFCost[9] + iPACost[9]) * 100), 1) });
					SeriesPoint fCostSeries11 = new SeriesPoint("[11월]", new object[] { Math.Round((iFCost[10] + iPACost[10]) == 0 ? 0 : (iFCost[10] / (iFCost[10] + iPACost[10]) * 100), 1) });
					SeriesPoint fCostSeries12 = new SeriesPoint("[12월]", new object[] { Math.Round((iFCost[11] + iPACost[11]) == 0 ? 0 : (iFCost[11] / (iFCost[11] + iPACost[11]) * 100), 1) });
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries1);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries2);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries3);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries4);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries5);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries6);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries7);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries8);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries9);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries10);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries11);
					acChartControl2.AddSeriesPoint("FCOST", fCostSeries12);

					SeriesPoint paCostSeries1 = new SeriesPoint("[1월]", new object[] { Math.Round((iFCost[0] + iPACost[0]) == 0 ? 0 : (iPACost[0] / (iFCost[0] + iPACost[0]) * 100), 1) });
					SeriesPoint paCostSeries2 = new SeriesPoint("[2월]", new object[] { Math.Round((iFCost[1] + iPACost[1]) == 0 ? 0 : (iPACost[1] / (iFCost[1] + iPACost[1]) * 100),1) });
					SeriesPoint paCostSeries3 = new SeriesPoint("[3월]", new object[] { Math.Round((iFCost[2] + iPACost[2]) == 0 ? 0 : (iPACost[2] / (iFCost[2] + iPACost[2]) * 100),1) });
					SeriesPoint paCostSeries4 = new SeriesPoint("[4월]", new object[] { Math.Round((iFCost[3] + iPACost[3]) == 0 ? 0 : (iPACost[3] / (iFCost[3] + iPACost[3]) * 100),1) });
					SeriesPoint paCostSeries5 = new SeriesPoint("[5월]", new object[] { Math.Round((iFCost[4] + iPACost[4]) == 0 ? 0 : (iPACost[4] / (iFCost[4] + iPACost[4]) * 100),1) });
					SeriesPoint paCostSeries6 = new SeriesPoint("[6월]", new object[] { Math.Round((iFCost[5] + iPACost[5]) == 0 ? 0 : (iPACost[5] / (iFCost[5] + iPACost[5]) * 100),1) });
					SeriesPoint paCostSeries7 = new SeriesPoint("[7월]", new object[] { Math.Round((iFCost[6] + iPACost[6]) == 0 ? 0 : (iPACost[6] / (iFCost[6] + iPACost[6]) * 100),1) });
					SeriesPoint paCostSeries8 = new SeriesPoint("[8월]", new object[] { Math.Round((iFCost[7] + iPACost[7]) == 0 ? 0 : (iPACost[7] / (iFCost[7] + iPACost[7]) * 100),1) });
					SeriesPoint paCostSeries9 = new SeriesPoint("[9월]", new object[] { Math.Round((iFCost[8] + iPACost[8]) == 0 ? 0 : (iPACost[8] / (iFCost[8] + iPACost[8]) * 100), 1) });
					SeriesPoint paCostSeries10 = new SeriesPoint("[10월]", new object[] { Math.Round((iFCost[9] + iPACost[9]) == 0 ? 0 : (iPACost[9] / (iFCost[9] + iPACost[9]) * 100), 1) });
					SeriesPoint paCostSeries11 = new SeriesPoint("[11월]", new object[] { Math.Round((iFCost[10] + iPACost[10]) == 0 ? 0 : (iPACost[10] / (iFCost[10] + iPACost[10]) * 100), 1) });
					SeriesPoint paCostSeries12 = new SeriesPoint("[12월]", new object[] { Math.Round((iFCost[11] + iPACost[11]) == 0 ? 0 : (iPACost[11] / (iFCost[11] + iPACost[11]) * 100), 1) });
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries1);
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries2);
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries3);
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries4) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries5) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries6) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries7) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries8) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries9) ;
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries10);
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries11);
					acChartControl2.AddSeriesPoint("PACOST", paCostSeries12);


					decimal janQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("01")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal febQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("02")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal marQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("03")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal aprQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("04")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal mayQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("05")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal junQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("06")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal julQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("07")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal augQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("08")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal sepQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("09")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal octQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("10")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal decQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("11")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal novQGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("Q_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("12")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();

					decimal avgQGoal = (janQGoal
									  + febQGoal
									  + marQGoal
									  + aprQGoal
									  + mayQGoal
									  + junQGoal
									  + julQGoal
									  + augQGoal
									  + sepQGoal
									  + octQGoal
									  + decQGoal
									  + novQGoal) / 12;

					SeriesPoint goalSeries1 = new SeriesPoint("[1월]", new object[] { janQGoal });
					SeriesPoint goalSeries2 = new SeriesPoint("[2월]", new object[] { febQGoal });
					SeriesPoint goalSeries3 = new SeriesPoint("[3월]", new object[] { marQGoal });
					SeriesPoint goalSeries4 = new SeriesPoint("[4월]", new object[] { aprQGoal });
					SeriesPoint goalSeries5 = new SeriesPoint("[5월]", new object[] { mayQGoal });
					SeriesPoint goalSeries6 = new SeriesPoint("[6월]", new object[] { junQGoal });
					SeriesPoint goalSeries7 = new SeriesPoint("[7월]", new object[] { julQGoal });
					SeriesPoint goalSeries8 = new SeriesPoint("[8월]", new object[] { augQGoal });
					SeriesPoint goalSeries9 = new SeriesPoint("[9월]", new object[] { sepQGoal });
					SeriesPoint goalSeries10 = new SeriesPoint("[10월]", new object[] { octQGoal });
					SeriesPoint goalSeries11 = new SeriesPoint("[11월]", new object[] { decQGoal });
					SeriesPoint goalSeries12 = new SeriesPoint("[12월]", new object[] { novQGoal });
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries1);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries2);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries3);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries4);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries5);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries6);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries7);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries8);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries9);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries10);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries11);
					acChartControl1.AddSeriesPoint("QCOST_GOAL", goalSeries12);

					acChartControl1.SeriesDic["QCOST_GOAL"].LegendText = string.Format("Q-COST 목표 {0}%\n(제조원가의)",Math.Round(avgQGoal,1));

					decimal janFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("01")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal febFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("02")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal marFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("03")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal aprFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("04")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal mayFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("05")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal junFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("06")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal julFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("07")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal augFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("08")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal sepFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("09")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal octFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("10")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal decFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("11")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal novFGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("F_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("12")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();

					decimal avgFGoal = (janFGoal
									  + febFGoal
									  + marFGoal
									  + aprFGoal
									  + mayFGoal
									  + junFGoal
									  + julFGoal
									  + augFGoal
									  + sepFGoal
									  + octFGoal
									  + decFGoal
									  + novFGoal) / 12;

					SeriesPoint fGoalSeries1 = new SeriesPoint("[1월]", new object[] { janFGoal });
					SeriesPoint fGoalSeries2 = new SeriesPoint("[2월]", new object[] { febFGoal });
					SeriesPoint fGoalSeries3 = new SeriesPoint("[3월]", new object[] { marFGoal });
					SeriesPoint fGoalSeries4 = new SeriesPoint("[4월]", new object[] { aprFGoal });
					SeriesPoint fGoalSeries5 = new SeriesPoint("[5월]", new object[] { mayFGoal });
					SeriesPoint fGoalSeries6 = new SeriesPoint("[6월]", new object[] { junFGoal });
					SeriesPoint fGoalSeries7 = new SeriesPoint("[7월]", new object[] { julFGoal });
					SeriesPoint fGoalSeries8 = new SeriesPoint("[8월]", new object[] { augFGoal });
					SeriesPoint fGoalSeries9 = new SeriesPoint("[9월]", new object[] { sepFGoal });
					SeriesPoint fGoalSeries10 = new SeriesPoint("[10월]", new object[] { octFGoal });
					SeriesPoint fGoalSeries11 = new SeriesPoint("[11월]", new object[] { decFGoal });
					SeriesPoint fGoalSeries12 = new SeriesPoint("[12월]", new object[] { novFGoal });
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries1) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries2) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries3) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries4) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries5) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries6) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries7) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries8) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries9) ;
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries10);
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries11);
					acChartControl2.AddSeriesPoint("FCOST_GOAL", fGoalSeries12);

					acChartControl2.SeriesDic["FCOST_GOAL"].LegendText = string.Format("F-COST 목표 {0}%", Math.Round(avgFGoal, 1));

					decimal janPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("01")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal febPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("02")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal marPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("03")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal aprPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("04")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal mayPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("05")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal junPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("06")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal julPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("07")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal augPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("08")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal sepPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("09")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal octPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("10")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal decPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("11")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();
					decimal novPAGoal = dtRsltGoal.AsEnumerable().Where(w => w["GUBUN"].Equals("P_A_COST_GOAL") && w["GOAL_DATE"].ToString().Substring(4).Equals("12")).Select(r => r["VALUE"].toDecimal()).FirstOrDefault();

					decimal avgPAGoal = (janPAGoal
								       + febPAGoal
								       + marPAGoal
								       + aprPAGoal
								       + mayPAGoal
								       + junPAGoal
								       + julPAGoal
								       + augPAGoal
								       + sepPAGoal
								       + octPAGoal
								       + decPAGoal
								       + novPAGoal) / 12;

					SeriesPoint paGoalSeries1 = new SeriesPoint("[1월]", new object[] { janPAGoal });
					SeriesPoint paGoalSeries2 = new SeriesPoint("[2월]", new object[] { febPAGoal });
					SeriesPoint paGoalSeries3 = new SeriesPoint("[3월]", new object[] { marPAGoal });
					SeriesPoint paGoalSeries4 = new SeriesPoint("[4월]", new object[] { aprPAGoal });
					SeriesPoint paGoalSeries5 = new SeriesPoint("[5월]", new object[] { mayPAGoal });
					SeriesPoint paGoalSeries6 = new SeriesPoint("[6월]", new object[] { junPAGoal });
					SeriesPoint paGoalSeries7 = new SeriesPoint("[7월]", new object[] { julPAGoal });
					SeriesPoint paGoalSeries8 = new SeriesPoint("[8월]", new object[] { augPAGoal });
					SeriesPoint paGoalSeries9 = new SeriesPoint("[9월]", new object[] { sepPAGoal });
					SeriesPoint paGoalSeries10 = new SeriesPoint("[10월]", new object[] { octPAGoal });
					SeriesPoint paGoalSeries11 = new SeriesPoint("[11월]", new object[] { decPAGoal });
					SeriesPoint paGoalSeries12 = new SeriesPoint("[12월]", new object[] { novPAGoal });
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries1);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries2);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries3);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries4);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries5);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries6);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries7);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries8);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries9);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries10);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries11);
					acChartControl2.AddSeriesPoint("PACOST_GOAL", paGoalSeries12);

					acChartControl2.SeriesDic["PACOST_GOAL"].LegendText = string.Format("P,A-COST 목표 {0}%", Math.Round(avgPAGoal, 1));
				}									
				#endregion

				acGridView1.GridControl.DataSource = inputTable;
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

		void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				this.Search();
			}
		}

	}
}
