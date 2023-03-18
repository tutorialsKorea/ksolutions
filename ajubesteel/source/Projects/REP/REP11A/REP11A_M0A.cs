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

namespace REP
{
    public sealed partial class REP11A_M0A : BaseMenu
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

        public REP11A_M0A()
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



            acPivotGridControl1.AddCodeField("PUR_TYPE", "구분", "41587", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "S047");


            acPivotGridControl1.AddField("OBEY_CNT", "입고준수 구매수", "51GMTSIO", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);

            acPivotGridControl1.AddField("DEFY_CNT", "입고비준수 구매수", "1Z6L1C0U", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);

            acPivotGridControl1.AddField("TOT_CNT", "전체입고 구매수", "2FXBQF4Y", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);


            acPivotGridControl1.AddUnboundField("OBEY_RATE", "입고준수율", "IDCSW1SY", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.UnboundColumnType.Decimal, acPivotGridControl.emPivotMask.PER2);

            acPivotGridControl1.Fields["OBEY_RATE"].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;





            acGridView1.AddDateEdit("WORK_MONTH", "월", "40985", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView1.AddLookUpEdit("PUR_TYPE", "구분", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S047");
            

            acGridView1.AddTextEdit("OBEY_CNT", "입고준수 구매수", "51GMTSIO", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("DEFY_CNT", "입고비준수 구매수", "1Z6L1C0U", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("TOT_CNT", "전체입고 구매수", "2FXBQF4Y", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("OBEY_RATE", "입고준수율", "IDCSW1SY", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);





            acGridView2.AddDateEdit("WORK_MONTH", "월", "40985", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddTextEdit("VEN_CODE", "거래처코드", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("VEN_NAME", "거래처명", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("OBEY_CNT", "입고준수 구매수", "51GMTSIO", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.AddTextEdit("DEFY_CNT", "입고비준수 구매수", "1Z6L1C0U", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.AddTextEdit("TOT_CNT", "전체입고 구매수", "2FXBQF4Y", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.AddTextEdit("OBEY_RATE", "입고준수율", "IDCSW1SY", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER2);





            acGridView1.DataSourceChanged += new EventHandler(acGridView1_DataSourceChanged);


            acGridView1.ColumnFilterChanged += new EventHandler(acGridView1_ColumnFilterChanged);

            acGridView1.EndSorting += new EventHandler(acGridView1_EndSorting);


            acGridView2.DataSourceChanged += new EventHandler(acGridView2_DataSourceChanged);


            acGridView2.ColumnFilterChanged += new EventHandler(acGridView2_ColumnFilterChanged);

            acGridView2.EndSorting += new EventHandler(acGridView2_EndSorting);



            acPivotGridControl1.CustomUnboundFieldData += new CustomFieldDataEventHandler(acPivotGridControl1_CustomUnboundFieldData);

            acPivotGridControl1.CustomSummary += new PivotGridCustomSummaryEventHandler(acPivotGridControl1_CustomSummary);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            acLayoutControl3.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl3_OnValueKeyDown);

            base.MenuInit();
        }

        void acLayoutControl3_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
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

        void acPivotGridControl1_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {

            if (e.DataField.SummaryType != DevExpress.Data.PivotGrid.PivotSummaryType.Custom) return;


            PivotDrillDownDataSource dataSource = e.CreateDrillDownDataSource();


            if (e.DataField.FieldName == "OBEY_RATE")
            {
                //납기준수율 사용자정의 합계

                if (dataSource.RowCount > 0)
                {
                    decimal obeyCnt = 0;
                    decimal totCnt = 0;


                    for (int i = 0; i < dataSource.RowCount; i++)
                    {
                        obeyCnt += dataSource[i]["OBEY_CNT"].toDecimal();
                        totCnt += dataSource[i]["TOT_CNT"].toDecimal();
                    }

                    if (totCnt != 0)
                    {
                        e.CustomValue = (obeyCnt / totCnt);
                    }
                }
            }

        }

        void acPivotGridControl1_CustomUnboundFieldData(object sender, CustomFieldDataEventArgs e)
        {

            if (e.Field.FieldName == "OBEY_RATE")
            {

                e.Value = e.GetListSourceColumnValue("OBEY_CNT").toDecimal() / e.GetListSourceColumnValue("TOT_CNT").toDecimal();

            }

        }



        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;


                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();


            }
            else if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;


                layout.GetEditor("S_MONTH").Value = acDateEdit.GetNowFirstMonth();
                layout.GetEditor("E_MONTH").Value = acDateEdit.GetNowMonth();
            }
            else if (sender == acLayoutControl3)
            {

                acLayoutControl layout = sender as acLayoutControl;


                layout.GetEditor("S_MONTH").Value = acDateEdit.GetNowFirstMonth();
                layout.GetEditor("E_MONTH").Value = acDateEdit.GetNowMonth();
            }

            base.ChildContainerInit(sender);
        }


        void acGridView2_EndSorting(object sender, EventArgs e)
        {
            this.acGridView2_DataSourceChanged(null, null); ;
        }

        void acGridView2_ColumnFilterChanged(object sender, EventArgs e)
        {
            this.acGridView2_DataSourceChanged(null, null);
        }

        void acGridView2_DataSourceChanged(object sender, EventArgs e)
        {


            DataView view = acGridView2.GetDataView();

            acChartControl2.ClearSeries();


            //거래처별로 차트시리얼키 생성

            var query = from row in view.ToTable().AsEnumerable()
                        group row by new { CVND_CODE = row["VEN_CODE"], CVND_NAME = row["VEN_NAME"] } into grp
                        select new
                        {

                            VEN_CODE = grp.Key.CVND_CODE,
                            VEN_NAME = grp.Key.CVND_NAME
                        };

            DataTable queryDt = query.LINQToDataTable();

            foreach (DataRow row in queryDt.Rows)
            {
                string srsKey = row["VEN_CODE"].toStringNull();

                string srsName = string.Format("{0} {1}", row["VEN_NAME"].toStringNull(), acInfo.Resource.GetString("입고준수율", "IDCSW1SY"));

                acChartControl2.AddLineSeries(srsKey, srsName, "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
            }



            for (int i = 0; i < view.Count; i++)
            {

                DateTime dt = view[i]["WORK_MONTH"].toDateTime();


                string argument = dt.ToString("yyyy-MM");



                //납기준수율
                SeriesPoint obeyRatePoint = new SeriesPoint(
                    argument,
                    new object[] { view[i]["OBEY_RATE"] }
                    );

                acChartControl2.AddSeriesPoint(view[i]["VEN_CODE"].toStringNull(), obeyRatePoint);



            }
        }


        void acGridView1_EndSorting(object sender, EventArgs e)
        {
            this.acGridView1_DataSourceChanged(null, null); ;
        }

        void acGridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            this.acGridView1_DataSourceChanged(null, null);
        }

        void acGridView1_DataSourceChanged(object sender, EventArgs e)
        {


            DataView view = acGridView1.GetDataView();

            acChartControl1.ClearSeries();


            //거래처별로 차트시리얼키 생성

            var query = from row in view.ToTable().AsEnumerable()
                        group row by new { PUR_TYPE = row["PUR_TYPE"] } into grp
                        select new
                        {

                            PUR_TYPE = grp.Key.PUR_TYPE
                        };


            DataTable queryDt = query.LINQToDataTable();

            foreach (DataRow row in queryDt.Rows)
            {
                string srsKey = row["PUR_TYPE"].toStringNull();

                string srsName = string.Format("{0} {1}", acInfo.StdCodes.GetNameByCode("S047", row["PUR_TYPE"]), acInfo.Resource.GetString("입고준수율", "IDCSW1SY"));

                acChartControl1.AddLineSeries(srsKey, srsName, "", false, acChartControl.SeriesPointType.PERCENT, DevExpress.XtraCharts.ViewType.Line);
            }


            for (int i = 0; i < view.Count; i++)
            {

                DateTime dt = view[i]["WORK_MONTH"].toDateTime();

                string argument = dt.ToString("yyyy-MM");


                //입고준수율
                SeriesPoint obeyRatePoint = new SeriesPoint(
                    argument,
                    new object[] { view[i]["OBEY_RATE"] }
                    );

                acChartControl1.AddSeriesPoint(view[i]["PUR_TYPE"].toStringNull(), obeyRatePoint);

            }


        }


        /// <summary>
        /// 월단위 거래처별 입고준수율
        /// </summary>
        void MonthVenSearch()
        {

            if (acLayoutControl3.ValidCheck() == false)
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String));
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String));
            paramTable.Columns.Add("VEN_CODE", typeof(String));

            DataRow layoutRow = acLayoutControl3.CreateParameterRow();

            foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["S_BALJU_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
                paramRow["E_BALJU_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];

                paramTable.Rows.Add(paramRow);

            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "REP11A_SER3", paramSet, "RQSTDT", "RSLTDT",
            MonthVenCallBack,
            QuickException);

        }
        void MonthVenCallBack(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            //월단위 거래처별
            try
            {

                e.result.Tables["RSLTDT"].Columns.Add("WORK_MONTH", typeof(DateTime));

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    DateTime dt = row["S_BALJU_DATE"].toDateTime();

                    row["WORK_MONTH"] = dt;

                }


                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];


                base.SetLog(e.executeType, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 월단위 전체 납기율
        /// </summary>
        void MonthAllSearch()
        {

            if (acLayoutControl2.ValidCheck() == false)
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String));
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String));


            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["S_BALJU_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
                paramRow["E_BALJU_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);

            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "REP11A_SER2", paramSet, "RQSTDT", "RSLTDT",
            MonthAllCallBack,
            QuickException);

        }

        void MonthAllCallBack(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                e.result.Tables["RSLTDT"].Columns.Add("WORK_MONTH", typeof(DateTime));


                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    DateTime dt = row["S_BALJU_DATE"].toDateTime();

                    row["WORK_MONTH"] = dt;

                }


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }





        /// <summary>
        /// 기간별 입고준수율 조회
        /// </summary>
        void PeriodAllSearch()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
            paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "REP11A_SER", paramSet, "RQSTDT", "RSLTDT",
            PeriodAllSearchCallBack,
            QuickException);



        }


        void PeriodAllSearchCallBack(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acPivotGridControl1.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);

        }

        void Search()
        {
            switch (acTabControl1.GetSelectedContainerName())
            {
                case "PERIOD_ALL":

                    //기간별 입고준수율

                    this.PeriodAllSearch();

                    break;

                case "MONTH_ALL":

                    //월단위 전체 입고준수율 조회

                    this.MonthAllSearch();

                    break;

                case "MONTH_VEN":

                    //월단위 거래처별 입고준수율 조회

                    this.MonthVenSearch();

                    break;
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
