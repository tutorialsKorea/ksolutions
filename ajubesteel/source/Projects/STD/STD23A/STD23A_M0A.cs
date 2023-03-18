using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace STD
{
    public sealed partial class STD23A_M0A : BaseMenu
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


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }





        public STD23A_M0A()
        {

            InitializeComponent();



            dnCalender.OnChangeEditDate += new acDateNavigator.ChangeEditDateHandler(dnCalender_OnChangeEditDate);

            dnCalender.OnDateChanged += new acDateNavigator.DateChangedHandler(dnCalender_OnDateChanged);



            dnCalender.MouseClick += new MouseEventHandler(dnCalender_MouseClick);

            popupMenu1.BeforePopup += new CancelEventHandler(popupMenu1_BeforePopup);
            gvHoli.MouseDown += new MouseEventHandler(gvHoli_MouseDown);

            gvHoli.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvHoli_ShowGridMenuEx);

        }



        void popupMenu1_BeforePopup(object sender, CancelEventArgs e)
        {
            if (dnCalender.HoliDayTable != null)
            {
                DataRow[] hoilResult = dnCalender.HoliDayTable.Select("HOLI_DATE = '" + dnCalender.DateTime.ToString("yyyyMMdd") + "'");

                if (hoilResult.Length == 0)
                {

                    acBarButtonItem1.Enabled = true;
                    acBarButtonItem2.Enabled = false;


                }
                else
                {
                    acBarButtonItem1.Enabled = false;
                    acBarButtonItem2.Enabled = true;
                }
            }

        }

        public override void MenuInit()
        {
            gvHoli.GridType = acGridView.emGridType.AUTO_COL;

            gvHoli.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvHoli.AddDateEdit("WORK_DATE", "일자", "T1R1O52X", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            gvHoli.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvHoli.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvHoli.AddTextEdit("CAPA", "CAPA", "40774", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            gvHoli.AddTextEdit("HOLI_NAME", "휴일명", "QGZ6WHRI", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvHoli.AddTextEdit("FT1", "오전", "IVTTWUJC", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            gvHoli.AddTextEdit("FT2", "오후", "24XMZR2U", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            gvHoli.AddTextEdit("FOT", "잔업", "41163", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            gvHoli.AddTextEdit("SCOMMENT", "CAPA 변경사유", "YQYEZL82", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            base.MenuInit();

        }


        void gvHoli_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gvHoli.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                    this.CapaModify();
                }

            }

        }

        void gvHoli_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.Row)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void dnCalender_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(dnCalender.PointToScreen(e.Location));
            }
        }



        void dnCalender_OnDateChanged(DateTime value)
        {
            try
            {
                if (this.IsMenuInit == false)
                {
                    return;
                }



                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("DATE1", typeof(String)); //기간(From)
                paramTable1.Columns.Add("DATE2", typeof(String)); //기간(To)
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["DATE1"] = value.ToString("yyyyMMdd");
                paramRow1["DATE2"] = value.ToString("yyyyMMdd");
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable1.Rows.Add(paramRow1);



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE,
               "STD23A_SER", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }

        }

        void dnCalender_OnChangeEditDate(DevExpress.XtraEditors.Calendar.CalendarHitInfoType infoType)
        {
            if (infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecMonth ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecYear ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncMonth ||
                infoType == DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncYear
                )
            {

                this.Search();

            }
        }




        void gvHoli_DoubleClick(object sender, EventArgs e)
        {
            this.CapaModify();
        }



        public override void MenuInitComplete()
        {



            dnCalender.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dnCalender.MaxCalendar = 12;



            this.Search();

            base.MenuInitComplete();

        }



        void Search()
        {
            //달력 정보 갱신


            DateTime timeLastDateTime = new DateTime(
dnCalender.EndDateTime.Year,
dnCalender.EndDateTime.Month,
DateTime.DaysInMonth(dnCalender.EndDateTime.Year, dnCalender.EndDateTime.Month)
);

            DataTable paramTable2 = new DataTable("RQSTDT");
            paramTable2.Columns.Add("S_HOLI_DATE", typeof(String)); //기간(From)
            paramTable2.Columns.Add("E_HOLI_DATE", typeof(String)); //기간(To)
            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

            DataRow paramRow2 = paramTable2.NewRow();
            paramRow2["S_HOLI_DATE"] = dnCalender.StartDateTime.ToString("yyyyMMdd");
            paramRow2["E_HOLI_DATE"] = timeLastDateTime.ToString("yyyyMMdd");
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable2.Rows.Add(paramRow2);



            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable2);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD23A_SER1", paramSet, "RQSTDT", "RSLTDT");

            dnCalender.HoliDayTable = resultSet.Tables["RSLTDT"];

            


        }
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                gvHoli.GridControl.DataSource = e.result.Tables["RSLTDT"];

                gvHoli.SetOldFocusRowHandle(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void CapaModify()
        {




            DataRow focusRow = gvHoli.GetFocusedDataRow();


            STD23A_D2B frm = new STD23A_D2B(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            frm.ParentControl = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {


                dnCalender_OnDateChanged(dnCalender.DateTime);



            }



        }




        private void barItemCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //생성
            try
            {
                STD23A_D0B frm = new STD23A_D0B();

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();

                    this.dnCalender_OnDateChanged(dnCalender.DateTime);
                }

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


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //휴일설정

            try
            {
                STD23A_D1B frm = new STD23A_D1B(dnCalender.DateTime);

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("WORK_DATE");
                    paramTable.Columns.Add("HOLI_NAME");
                    paramTable.Columns.Add("PLT_CODE");
                    paramTable.Columns.Add("EMP_CODE");
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["WORK_DATE"] = frm.HoliDateTime.ToString("yyyyMMdd");
                    paramRow["HOLI_NAME"] = frm.HoliReason;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
               "STD23A_UPD2", paramSet, "RQSTDT", "",
               QuickProcess,
               QuickException);


                }




            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //휴일해제

            try
            {


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("HOLI_DATE", typeof(String)); //휴일

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["HOLI_DATE"] = dnCalender.DateTime.ToString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
               "STD23A_UPD3", paramSet, "RQSTDT", "",
               QuickProcess,
               QuickException);



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CAPA 변경
            try
            {
                this.CapaModify();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CAPA 기본값으로 변경
            try
            {
                gvHoli.EndEditor();

                DataView selectedView = gvHoli.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //날짜
                paramTable.Columns.Add("MC_CODE", typeof(String)); //설비코드


                if (selectedView.Count == 0)
                {
                    //단일

                    DataRow focusRow = gvHoli.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WORK_DATE"] = focusRow["WORK_DATE"].toDateString("yyyyMMdd");
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중

                    for (int i = 0; i < selectedView.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["WORK_DATE"] = selectedView[i]["WORK_DATE"].toDateString("yyyyMMdd");
                        paramRow["MC_CODE"] = selectedView[i]["MC_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
               "STD23A_UPD1", paramSet, "RQSTDT", "",
               QuickProcess,
               QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickProcess(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Search();

                this.dnCalender_OnDateChanged(dnCalender.DateTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }



    }
}

