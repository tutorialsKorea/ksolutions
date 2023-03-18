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
    public sealed partial class REP12A_M0A : BaseMenu
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

        public REP12A_M0A()
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

            //기간별

            acPivotGridControl1.AddField("WORK_DATE", "작업일", "40540", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            acPivotGridControl1.AddCodeField("MC_GROUP", "설비그룹", "40308", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C020");

            acPivotGridControl1.AddField("MC_CODE", "설비코드", "41162", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("MC_NAME", "설비명", "41202", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);


            acPivotGridControl1.AddField("EMP_CODE", "작업자코드", "40551", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("EMP_NAME", "작업자명", "40545", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddCodeField("IDLE_CODE", "비가동 사유", "42437", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C010");

            acPivotGridControl1.AddField("IDLE_TIME", "비가동 시간", "41150", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);


            acPivotGridControl1.AddField("SCOMMENT", "비고", "ARYZ726K", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);



            //월별 


            acGridView2.AddDateEdit("MONTH", "월", "40985", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddLookUpEdit("IDLE_CODE", "비가동 사유", "42437", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C010");

            acGridView2.AddTextEdit("IDLE_TIME", "비가동 시간", "41150", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


 

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            acGridView2.ColumnFilterChanged += new EventHandler(acGridView2_ColumnFilterChanged);
            acGridView2.EndSorting += new EventHandler(acGridView2_EndSorting);
            acGridView2.DataSourceChanged += new EventHandler(acGridView2_DataSourceChanged);





            base.MenuInit();
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


                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
            }
            else if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;


                layout.GetEditor("S_MONTH").Value = acDateEdit.GetNowFirstMonth();
                layout.GetEditor("E_MONTH").Value = acDateEdit.GetNowMonth();
            }

            base.ChildContainerInit(sender);
        }
        void acGridView2_EndSorting(object sender, EventArgs e)
        {
            this.acGridView2_DataSourceChanged(null, null);

        }

        void acGridView2_ColumnFilterChanged(object sender, EventArgs e)
        {
            this.acGridView2_DataSourceChanged(null, null);

        }

        void acGridView2_DataSourceChanged(object sender, EventArgs e)
        {
            DataView view = acGridView2.GetDataView();

            DataTable viewSource = view.ToTable();

            acChartControl1.ClearSeries();
            acChartControl1.ClearSeriesPoint();


            var query = from row in viewSource.AsEnumerable()
                        group row by new { IDLE_CODE = row["IDLE_CODE"] } into grp
                        select new
                        {
                            IDLE_CODE = grp.Key.IDLE_CODE,

                        };
            
            foreach (var r in query)
            {
                string srKey = string.Format("{0}", r.IDLE_CODE);

                string srName = string.Format("{0}", acInfo.StdCodes.GetNameByCode("C010", r.IDLE_CODE));

                acChartControl1.AddLineSeries(srKey, srName, "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);
            }

            foreach (DataRow row in viewSource.Rows)
            {
                DateTime dt = row["MONTH"].toDateTime();

                string argument = dt.ToString("yyyy-MM");

                string srKey = string.Format("{0}", row["IDLE_CODE"].ToString());

                SeriesPoint idleTime = new SeriesPoint(argument, new double[] { row["IDLE_TIME"].toDouble() });

                acChartControl1.AddSeriesPoint(srKey, idleTime);
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
                case "PERIOD":
                    {
                        //기간
                        if (acLayoutControl1.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();



                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_DATE", typeof(String)); //
                        paramTable.Columns.Add("EMP_CODE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MC_CODE"] = layoutRow["MC_CODE"];



                        paramRow["S_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DATE"] = layoutRow["E_DATE"];



                        paramRow["EMP_CODE"] = null;
                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP12A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);

                    }

                    break;

                case "MONTH":
                    {
                        //월별
                        if (acLayoutControl2.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl2.CreateParameterRow();


                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_DATE", typeof(String)); //작업일 (시작)
                        paramTable.Columns.Add("E_DATE", typeof(String)); //작업일 (종료)

                        foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                            paramRow["S_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
                            paramRow["E_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);

                        }

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP12A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);
                    }

                    break;

            }



        }
        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                acPivotGridControl1.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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
