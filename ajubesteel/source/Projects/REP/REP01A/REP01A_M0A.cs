using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraPivotGrid;
using BizManager;
using System.Collections;
using System.Threading;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraBars.Docking;

namespace REP
{
    public sealed partial class REP01A_M0A : BaseMenu
    {



        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public REP01A_M0A()
        {
            InitializeComponent();
        }

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


        Color _WAIT;
        Color _RUN;
        Color _PAUSE;
        Color _FINISH;

        private Dictionary<string, string> _dicProcStat = null;
        private DataTable _dtProcList = null;

        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            #region 상세 진행 내역
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP", "캠담당자 코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP_NAME", "캠담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");


            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("PART_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView1.AddLookUpEdit("IS_OS", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P016");
            acGridView1.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C401");
            acGridView1.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");
            acGridView1.AddTextEdit("GROUP_PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ASSY_SCOMMENT", "조립 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("INS_SCOMMENT", "출하검사 비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["PROD_CODE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            acGridView1.Columns["PROD_NAME"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            acGridView1.Columns["PART_CODE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            acGridView1.Columns["PART_NAME"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            acGridView1.Columns["DUE_DATE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            acGridView1.Columns["CHG_DUE_DATE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            //공정 컬럼 생성
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            //this._dtProcList = ExtensionMethods.GetProcList(this);

            DataTable procParamTable = new DataTable("RQSTDT");
            procParamTable.Columns.Add("PLT_CODE", typeof(String)); //
            procParamTable.Columns.Add("IS_DISP", typeof(Byte)); //
            procParamTable.Columns.Add("IS_DISP2", typeof(Byte)); //

            DataRow procParamRow = procParamTable.NewRow();
            procParamRow["PLT_CODE"] = acInfo.PLT_CODE;
            procParamRow["IS_DISP"] = 0;
            procParamRow["IS_DISP2"] = 0;

            procParamTable.Rows.Add(procParamRow);
            DataSet procParamSet = new DataSet();
            procParamSet.Tables.Add(procParamTable);

            DataTable dtProc = BizRun.QBizRun.ExecuteService(this, "COMMON", "COMMON_PROC", procParamSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            this._dtProcList = dtProc;

            foreach (DataRow row in this._dtProcList.Rows)
            {

                //acGridView1.AddMemoEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddMemoEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView1.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
            }

            acGridView1.KeyColumn = new string[] {"PROD_CODE", "PART_CODE" };
            #endregion

            acGridView1.OptionsView.AllowCellMerge = true;

            //acGridView1.RowHeight = 40;
            //acGridView1.ColumnPanelRowHeight = 50;

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            txtNone.BackColor = Color.LightGray;
            txtWait.BackColor = _WAIT;
            txtRun.BackColor = _RUN;
            txtPause.BackColor = _PAUSE;
            txtFinish.BackColor = _FINISH;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);

            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;

            acGridView1.TopRowChanged += AcGridView1_TopRowChanged;

            //acGridView1.Columns["CHG_DUE_DATE"].AppearanceCell.ForeColor = Color.Red;

            _dicProcStat = new Dictionary<string, string>();

            base.MenuInit();
        }

        private void AcGridView1_TopRowChanged(object sender, EventArgs e)
        {
            // 스크롤링하는 경우 포커스 잡기위해 추가
            acGridView gridView1 = sender as acGridView;

            gridView1.FocusedRowHandle = acGridView1.TopRowIndex;
        }


        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {

                
                if (e.RowHandle < 0) return;

                if (e.Column.FieldName == "CHG_DUE_DATE")
                {
                    e.Appearance.ForeColor = Color.Red;
                }

                if (e.Column.Tag == null) return;
                if (e.CellValue == null) return;

                e.Appearance.ForeColor = Color.Black;

                DataRow thisRow = acGridView1.GetDataRow(e.RowHandle);

                string key = thisRow["PT_ID"].ToString() + e.Column.FieldName + thisRow["RE_WO_NO"].ToString();

                if (!_dicProcStat.ContainsKey(key))
                    return;

                switch (_dicProcStat[key])
                {
                    case "0":
                        e.Appearance.BackColor = Color.LightGray;
                        break;
                    case "1":
                        e.Appearance.BackColor = _WAIT;
                        break;
                    case "2":
                        e.Appearance.BackColor = _RUN;
                        break;
                    case "3":
                        e.Appearance.BackColor = _PAUSE;
                        break;
                    case "4":
                        e.Appearance.BackColor = _FINISH;
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();

            }

            base.ChildContainerInit(sender);

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


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }


        void Search()
        {
            //조회
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable.Columns.Add("IS_NON_ASSY", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ORD_DATE":

                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;

                    case "DUE_DATE":

                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }

            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            if (acCheckEdit1.Checked)
            {
                paramRow["IS_NON_ASSY"] = "1";
            }
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                    "REP01A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                this._dicProcStat.Clear();

                DataTable dtTemp = e.result.Tables["RSLTDT"];

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                }



                foreach (DataRow row in dtTemp.Rows)
                {
                    //if (!dtTemp.Columns.Contains(row["PROC_CODE"].ToString()))
                    //    continue;

                    string where = string.Format("PT_ID = '{0}' AND RE_WO_NO IS NULL", row["PT_ID"]);

                    if (row["RE_WO_NO"].toStringEmpty() != "")
                    {
                        where = string.Format("PT_ID = '{0}' AND RE_WO_NO = '{1}'", row["PT_ID"], row["RE_WO_NO"]);
                    }

                    DataRow[] dataRows = e.result.Tables["RSLTDT_WO"].Select(where);

                    if (dataRows.Length == 0)
                        continue;

                    //string endTime = "-";

                    //if (row["ACT_END_TIME"].ToString().Length > 0)
                    //{
                    //    endTime = row["ACT_END_TIME"].toDateString("yyyy-MM-dd HH:mm:ss");
                    //}

                    foreach (DataRow rw in dataRows)
                    {

                        if (!dtTemp.Columns.Contains(rw["PROC_CODE"].ToString())) continue;

                        if (rw["PROC_CODE"].ToString() == "P-02")
                        {
                            row["MC_GROUP"] = rw["MC_GROUP"];
                            row["CAM_EMP"] = rw["CAM_EMP"];
                            row["CAM_EMP_NAME"] = rw["CAM_EMP_NAME"];
                        }

                        if (rw["PROC_CODE"].ToString() == "P14")
                        {
                            row["IS_OS"] = "1";
                        }


                        row["PART_QTY"] = rw["PART_QTY"];


                        string plnQty = "-";

                        if (rw["PLN_QTY"].ToString().Length > 0)
                        {
                            plnQty = string.Format("{0:#,##0}", rw["PLN_QTY"]);
                        }

                        string okQty = "0";

                        if (rw["OK_QTY"].ToString().Length > 0)
                        {
                            okQty = string.Format("{0:#,##0}", rw["OK_QTY"]);
                        }

                        row[rw["PROC_CODE"].ToString()] = plnQty + " / " + okQty;

                        //switch (row["WO_FLAG"].ToString())
                        //{
                        //    case "0":
                        //    case "1":
                        //        dataRows[0][row["PROC_CODE"].ToString()] = row["PLN_START_TIME"].toDateString("MM/dd");
                        //        break;
                        //    case "2":
                        //    case "3":
                        //        dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_START_TIME"].toDateString("MM/dd");
                        //        break;
                        //    case "4":
                        //        dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_END_TIME"].toDateString("MM/dd");
                        //        break;
                        //}

                        if (!this._dicProcStat.ContainsKey(rw["PT_ID"].ToString() + rw["PROC_CODE"].ToString() + rw["RE_WO_NO"].ToString()))
                        {
                            this._dicProcStat.Add(rw["PT_ID"].ToString() + rw["PROC_CODE"].ToString() + rw["RE_WO_NO"].ToString(), rw["WO_FLAG"].ToString());
                        }
                    }


                }






                ////foreach (DataRow row in e.result.Tables["RSLTDT_WO"].Rows)
                ////{

                ////    if (!dtTemp.Columns.Contains(row["PROC_CODE"].ToString()))
                ////        continue;

                ////    string where = string.Format("PT_ID = '{0}' AND RE_WO_NO IS NULL", row["PT_ID"]);

                ////    if (row["RE_WO_NO"].toStringEmpty() != "")
                ////    {
                ////        where = string.Format("PT_ID = '{0}' AND RE_WO_NO = '{1}'", row["PT_ID"], row["RE_WO_NO"]);
                ////    }

                ////    DataRow[] dataRows = dtTemp.Select(where);

                ////    if (dataRows.Length == 0)
                ////        continue;

                ////    //string endTime = "-";

                ////    //if (row["ACT_END_TIME"].ToString().Length > 0)
                ////    //{
                ////    //    endTime = row["ACT_END_TIME"].toDateString("yyyy-MM-dd HH:mm:ss");
                ////    //}

                ////    if (row["PROC_CODE"].ToString() == "P-02")
                ////    {
                ////        dataRows[0]["MC_GROUP"] = row["MC_GROUP"];
                ////        dataRows[0]["CAM_EMP"] = row["CAM_EMP"];
                ////        dataRows[0]["CAM_EMP_NAME"] = row["CAM_EMP_NAME"];
                ////    }


                ////    string plnQty = "-";

                ////    if (row["PLN_QTY"].ToString().Length > 0)
                ////    {
                ////        plnQty = string.Format("{0:#,##0}", row["PLN_QTY"]);
                ////    }

                ////    string okQty = "-";

                ////    if (row["OK_QTY"].ToString().Length > 0)
                ////    {
                ////        okQty = string.Format("{0:#,##0}", row["OK_QTY"]);
                ////    }

                ////    dataRows[0][row["PROC_CODE"].ToString()] = plnQty + " / " + okQty;

                ////    //switch (row["WO_FLAG"].ToString())
                ////    //{
                ////    //    case "0":
                ////    //    case "1":
                ////    //        dataRows[0][row["PROC_CODE"].ToString()] = row["PLN_START_TIME"].toDateString("MM/dd");
                ////    //        break;
                ////    //    case "2":
                ////    //    case "3":
                ////    //        dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_START_TIME"].toDateString("MM/dd");
                ////    //        break;
                ////    //    case "4":
                ////    //        dataRows[0][row["PROC_CODE"].ToString()] = row["ACT_END_TIME"].toDateString("MM/dd");
                ////    //        break;
                ////    //}

                ////    if (!this._dicProcStat.ContainsKey(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString()))
                ////    {
                ////        this._dicProcStat.Add(row["PT_ID"].ToString() + row["PROC_CODE"].ToString() + row["RE_WO_NO"].ToString(), row["WO_FLAG"].ToString());
                ////    }
                ////}

                acGridView1.GridControl.DataSource = dtTemp;

                acGridView1.BestFitColumns();
                acGridView1.Columns["PROD_NAME"].Width = acGridView1.Columns["DRAW_NO"].Width;
                acGridView1.Columns["PART_NAME"].Width = acGridView1.Columns["DRAW_NO"].Width;


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //전체화면으로 보기
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;

                frm.ShowFullScreen(this, this.pnlScreenBase);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 전체화면
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;

                frm.Load += Frm_Load;

                frm.HandleDestroyed += Frm_HandleDestroyed;

                frm.ShowFullScreen(this, this.pnlScreenBase);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void Frm_HandleDestroyed(object sender, EventArgs e)
        {
            this.acSplitContainerControl1.SplitterPosition = 57;

            timer1.Stop();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            this.acSplitContainerControl1.SplitterPosition = 0; // 검색조건 보이지 않도록 처리

            timer1.Interval = acInfo.SysConfig.GetSysConfigByMemory("SCROLLING_TIME").toInt() * 1000; //30*1000 = 30초 주기
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            int visibleRecordCount = 0;

            // 현재 그리드뷰상에 보여지고 있는 최대 행의 갯수  
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo info = acGridView1.GetViewInfo() as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo;
            visibleRecordCount = (info.RowsInfo.Count -1); //(마지막 행이 반쯤 잘려나오기 때문에 -1 처리)

            // 조회된 전체 행의 갯수로 다음 페이지로 이동할지 말지 결정 
            if (visibleRecordCount < acGridView1.GetDataView().Count)
            {
                // 현재 Row 포커스가 마지막 페이지의 범위안에 있는 경우 
                if ((acGridView1.GetDataView().Count - visibleRecordCount) <= acGridView1.FocusedRowHandle && acGridView1.FocusedRowHandle <= acGridView1.GetDataView().Count)
                {
                    acGridView1.MoveFirst();
                }
                else
                {
                    acGridView1.MoveBy(visibleRecordCount + 1);
                }
                
            }
   
        }
    }
}
