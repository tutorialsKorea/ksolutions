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
    public sealed partial class REP14A_M0A : BaseMenu
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

        public REP14A_M0A()
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

            acPivotGridControl1.AddField("WORK_DATE", "불량발생일", "F1HO50M4", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
                       
            acPivotGridControl1.AddCodeField("NG_STATE", "불량상태", "587SOBFY", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "Q003");

            acPivotGridControl1.AddField("NG_MEASURE_DATE", "불량대책일", "H3COOO13", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            acPivotGridControl1.AddCodeField("NG_TYPE", "불량형태", "C1VMAHMU", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "Q004");

            acPivotGridControl1.AddField("NG_MEASURE_EMP", "불량대책완료자코드", "AFKOXLUA", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("NG_MEASURE_EMP_NAME", "불량대책완료자명", "O79POXF6", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PROD_CODE", "금형코드", "40900", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PROD_NAME", "금형명", "40901", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PART_CODE", "부품코드", "40239", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PART_NAME", "부품명", "40234", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PART_NUM", "품번", "40743", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PROC_CODE", "공정코드", "40920", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("PROC_NAME", "공정명", "40921", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("MC_CODE", "설비코드", "41162", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("MC_NAME", "설비명", "41202", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("EMP_CODE", "작업자코드", "40551", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("EMP_NAME", "작업자명", "40545", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddCodeField("MASTER_CAUSE", "주원인", "V4X4CXSS", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C400");
            acPivotGridControl1.AddCodeField("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C401");
            acPivotGridControl1.AddField("QUANTITY", "불량수량", "UGW32N5B", true, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);
            
            
            acCheckedComboBoxEdit1.AddItem("불량발생일", true, "F1HO50M4", "WORK_DATE", true, false);



            //월별 


            acGridView2.AddDateEdit("MONTH", "월", "40985", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddLookUpEdit("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C400");

            acGridView2.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C401");

            acGridView2.AddTextEdit("QTY", "불량수량", "UGW32N5B", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
             

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged+=new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            acGridView2.ColumnFilterChanged += new EventHandler(acGridView2_ColumnFilterChanged);
            acGridView2.EndSorting += new EventHandler(acGridView2_EndSorting);
            acGridView2.DataSourceChanged += new EventHandler(acGridView2_DataSourceChanged);





            base.MenuInit();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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


        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "WORK_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

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
                        group row by new { MASTER_CAUSE = row["MASTER_CAUSE"], DETAIL_CAUSE = row["DETAIL_CAUSE"] } into grp
                        select new
                        {
                            MASTER_CAUSE = grp.Key.MASTER_CAUSE
                            ,DETAIL_CAUSE = grp.Key.DETAIL_CAUSE

                        };
            
            foreach (var r in query)
            {
                string srKey = string.Format("{0}_{1}", r.MASTER_CAUSE , r.DETAIL_CAUSE);

                string srName = string.Format("{0}-{1}", acInfo.StdCodes.GetNameByCode("C402", r.MASTER_CAUSE), acInfo.StdCodes.GetNameByCode("C403", r.DETAIL_CAUSE));

                acChartControl1.AddLineSeries(srKey, srName, "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);
            }

            foreach (DataRow row in viewSource.Rows)
            {
                DateTime dt = row["MONTH"].toDateTime();

                string argument = dt.ToString("yyyy-MM");

                string srKey = string.Format("{0}_{1}", row["MASTER_CAUSE"].ToString(), row["DETAIL_CAUSE"].ToString());

                SeriesPoint idleTime = new SeriesPoint(argument, new double[] { row["QTY"].toDouble() });

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
                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];

                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "WORK_DATE":

                                    paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];

                                    break;

                            }

                        }


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP14A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                        paramTable.Columns.Add("S_WORK_DATE", typeof(String)); 
                        paramTable.Columns.Add("E_WORK_DATE", typeof(String)); 

                        foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["S_WORK_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
                            paramRow["E_WORK_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);

                        }

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP14A_SER2", paramSet, "RQSTDT", "RSLTDT",
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
