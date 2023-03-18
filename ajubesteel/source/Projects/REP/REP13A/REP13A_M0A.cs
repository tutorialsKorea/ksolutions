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
    public sealed partial class REP13A_M0A : BaseMenu
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

        public REP13A_M0A()
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

            acPivotGridControl1.AddField("NG_ID", "불량번호", "16SQP5J9", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddCodeField("PUR_TYPE", "구분", "41587", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "S047");

            //acPivotGridControl1.AddCodeField("YPGO_STAT", "상태", "40278", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "S043");

            acPivotGridControl1.AddField("BALJU_NUM", "발주번호", "40203", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("BALJU_SEQ", "발주순번", "42597", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("BALJU_DATE", "발주일", "40206", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            acPivotGridControl1.AddField("BALJU_DUE_DATE", "입고예정일", "S06YYU8H", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            acPivotGridControl1.AddField("YPGO_DATE", "입고일", "40515", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            acPivotGridControl1.AddField("CHECK_DATE", "검사일", "3DETEJ14", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);


            acPivotGridControl1.AddField("VEN_CODE", "거래처코드", "40957", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("VEN_NAME", "거래처명", "40956", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("ITEM_CODE", "수주코드", "40377", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("ITEM_NAME", "수주명", "41906", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PROD_CODE", "금형코드", "40900", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PROD_NAME", "금형명", "40901", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_CODE", "부품코드", "40239", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_NAME", "부품명", "40234", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_NUM", "품번", "40743", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddCodeField("MAT_LTYPE", "대분류", "40132", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "M001");

            acPivotGridControl1.AddCodeField("MAT_MTYPE", "중분류", "40630", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "M002");

            acPivotGridControl1.AddCodeField("MAT_STYPE", "소분류", "40338", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "M008");

            acPivotGridControl1.AddCodeField("PART_PRODTYPE", "부품제작구분", "40238", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "M007");

            acPivotGridControl1.AddField("PART_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_QLTY_NAME", "재질명", "40572", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_SPEC", "소재사양", "42544", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PART_SPEC1", "완성사양", "42545", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("WEIGHT_VOLUME", "소재중량", "40629", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.WEIGHT);

            //mainGrid.AddField("WEIGHT_VOLUME1", "중량2", "42546", true , DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.WEIGHT);



            acPivotGridControl1.AddField("PROC_CODE", "공정코드", "40920", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PROC_NAME", "공정명", "40921", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PRG_CODE", "일정코드", "WHZ16F4U", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PRG_NAME", "일정명", "EJPVN5D0", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);


            acPivotGridControl1.AddField("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddCodeField("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "T004");

            acPivotGridControl1.AddCodeField("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "T001");

            acPivotGridControl1.AddCodeField("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "T002");

            acPivotGridControl1.AddCodeField("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "T003");

            acPivotGridControl1.AddField("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddCodeField("UNIT", "단위", "40123", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "M003");




            //acPivotGridControl1.AddField("QTY", "입고수량", "41535", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);


            acPivotGridControl1.AddCodeField("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C402");

            acPivotGridControl1.AddCodeField("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "C403");


            acPivotGridControl1.AddField("NG_QTY", "검사불량수량", "D02A16BY", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);


            acPivotGridControl1.AddCodeField("NG_RESULT", "결과", "M9ERIN2S", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, "Q002");


            acPivotGridControl1.AddField("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.XtraPivotGrid.PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);



            acCheckedComboBoxEdit1.AddItem("검사일", true, "3DETEJ14", "CHECK_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("발주일", true, "40206", "BALJU_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("입고예정일", true, "S06YYU8H", "BALJU_DUE_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("입고일", true, "40515", "YPGO_DATE", true, false);


            //월별 


            acGridView2.AddDateEdit("MONTH", "월", "40985", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);

            acGridView2.AddLookUpEdit("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C402");

            acGridView2.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C403");

            acGridView2.AddTextEdit("QTY", "검사불량수량", "D02A16BY", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
             

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

                layout.GetEditor("DATE").Value = "CHECK_DATE";
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
                        if (acLayoutControl1.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //
                        paramTable.Columns.Add("S_BALJU_DUE_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_BALJU_DUE_DATE", typeof(String)); //
                        paramTable.Columns.Add("S_YPGO_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_YPGO_DATE", typeof(String)); //
                        paramTable.Columns.Add("S_CHECK_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_CHECK_DATE", typeof(String)); //
                        paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                        paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                        paramTable.Columns.Add("BALJU_NUM_LIKE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();

                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                        paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
                        paramRow["BALJU_NUM_LIKE"] = layoutRow["BALJU_NUM_LIKE"];


                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "BALJU_DATE":
                                    //발주일

                                    paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                                    break;

                                case "BALJU_DUE_DATE":
                                    //입고예정일

                                    paramRow["S_BALJU_DUE_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_BALJU_DUE_DATE"] = layoutRow["E_DATE"];

                                    break;

                                case "YPGO_DATE":
                                    //입고일

                                    paramRow["S_YPGO_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_YPGO_DATE"] = layoutRow["E_DATE"];

                                    break;


                                case "CHECK_DATE":
                                    //검사일
                                    paramRow["S_CHECK_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_CHECK_DATE"] = layoutRow["E_DATE"];

                                    break;

                            }

                        }


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);



                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD,
                        "REP13A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                        paramTable.Columns.Add("S_CHECK_DATE", typeof(String)); 
                        paramTable.Columns.Add("E_CHECK_DATE", typeof(String)); 

                        foreach (DateTime item in acDateEdit.GetMonthList(layoutRow["S_MONTH"].toDateTime(), layoutRow["E_MONTH"].toDateTime()))
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["S_CHECK_DATE"] = item.GetFirstDate().toDateString("yyyyMMdd");
                            paramRow["E_CHECK_DATE"] = item.GetLastDate().toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);

                        }

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP13A_SER2", paramSet, "RQSTDT", "RSLTDT",
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
