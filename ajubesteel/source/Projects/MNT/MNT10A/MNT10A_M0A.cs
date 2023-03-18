using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;
using PlexityHide.GTP;

namespace MNT
{
    public sealed partial class MNT10A_M0A : BaseMenu
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
        
        List<Control> ctrlMC = new List<Control>();
        //Dictionary<string, Control> dicMc = new Dictionary<string, Control>();
        SortedList<string, Control> lstMc;
        Color clrRun = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor();
        Color clrPause = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor();
        Color clrOff = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor();
        Color clrError = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();

        Color _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
        Color _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
        Color _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
        Color _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();


        private int gt_rowheight = 40;


        public MNT10A_M0A()
        {
            InitializeComponent();

            lstMc = new SortedList<string, Control>();

            acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            foreach (Control ctrl in acLayoutControl1.Controls)
            {
                if (ctrl.Name.StartsWith("acMntMachine"))
                {
                    lstMc.Add(((ControlManager.acMntMachine)ctrl).MC_CODE, ctrl);
                    ctrlMC.Add(ctrl);
                }
                    
            }

            foreach (Control ctrl in ctrlMC)
            {
                if (ctrl.Name.StartsWith("acMntMachine"))
                {
                    ((ControlManager.acMntMachine)ctrl).Bottom_Items = 3;
                    ((ControlManager.acMntMachine)ctrl).WK_OPT_NAME1 = acInfo.Resource.GetString("품번", "A3OZJ7DD");
                    ((ControlManager.acMntMachine)ctrl).WK_OPT_NAME2 = acInfo.Resource.GetString("작업자", "40542");
                    ((ControlManager.acMntMachine)ctrl).WK_OPT_NAME3 = acInfo.Resource.GetString("비가동", "1OQA8BS3");
                }
            }
            simpleLabelItem1.AppearanceItemCaption.BackColor = clrRun;
            simpleLabelItem2.AppearanceItemCaption.BackColor = clrPause;
            simpleLabelItem3.AppearanceItemCaption.BackColor = clrOff;
            simpleLabelItem4.AppearanceItemCaption.BackColor = clrError;

            simpleLabelItem7.AppearanceItemCaption.BackColor = clrRun;
            simpleLabelItem8.AppearanceItemCaption.BackColor = clrPause;
            simpleLabelItem9.AppearanceItemCaption.BackColor = clrOff;
            simpleLabelItem10.AppearanceItemCaption.BackColor = clrError;

            gt1.RegisterRuntimeKey("I DO NOT WANT TO SEND ANY FEEDBACK TO PLEXITYHIDE AND HENCE DO NOT WANT TO USE RUNTIMEKEYS", " CSGTPNET30114");
            gt1.DateScaler.CultureInfoDateTimeFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;

            gt2.RegisterRuntimeKey("I DO NOT WANT TO SEND ANY FEEDBACK TO PLEXITYHIDE AND HENCE DO NOT WANT TO USE RUNTIMEKEYS", " CSGTPNET30114");
            gt2.DateScaler.CultureInfoDateTimeFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;

            gridView1.CustomDrawCell += gridView1_CustomDrawCell;
            gridView1.RowCellStyle += gridView1_RowCellStyle;

            panel1.Visible = false;
            panel2.Visible = false;


            this.Resize += MNT10A_M0A_Resize;
            this.SizeChanged += MNT10A_M0A_SizeChanged;
            
        }

        void MNT10A_M0A_SizeChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void MNT10A_M0A_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //acLayoutControlGroup2
            //acLayoutControlGroup3

            try
            {
                if (panel1.Visible)
                {
                    acLayoutControlGroup2.Width = panel1.Width / 2;
                    acLayoutControlGroup3.Width = panel1.Width / 2;
                }
                
            }
            catch(Exception ex)
            {

            }

            
        }



        void MNT10A_M0A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = "현황판 I";

                frm.ShowFullScreen(this, this.pnlScreenBase);
            }
        }

        void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "W_STATE")
            {
                if (e.CellValue.ToString() == "비가동")
                {
                    e.Appearance.Options.UseBackColor = true;
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.BackColor2 = Color.LightGray;
                }
                
            }
        }

        void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            string state = gridView1.GetDataRow(e.RowHandle)["W_STATE"].ToString();

            if (e.Column.FieldName == "W_STATE")
            {

                switch (state)
                {
                    case "비가동":
                        e.Appearance.BackColor = Color.LightGray;
                        
                        break;
                    case "중단":
                        e.Appearance.BackColor = _PAUSE;
                        break;
                    case "진행":
                        e.Appearance.BackColor = _RUN;
                        break;
                    case "완료":
                        e.Appearance.BackColor = _FINISH;
                        break;
                }
            }

            if (e.Column.FieldName == "W_PROG")
            {
                

                if (state == "비가동" || state == "중단")
                {
                    e.DisplayText = gridView1.GetDataRow(e.RowHandle)["W_DESC"].ToString();
                }

                
                
            }

            if (e.Column.FieldName == "PLN_END_TIME")
            {
                if (e.CellValue.ToString() != "")
                    e.DisplayText = acDateEdit.GetFomattedDateTime(e.CellValue.ToString(), "MM/dd hh:mm");
            }
        }

        public override void MenuInit()
        {

            gt1.VerticalLines = true;

            gt1.AddColumn("MC_NAME", "설비명", "41202", CellType.SingleText, true, false);
            gt1.AddColumn("UPDATE_DATE", "최근 신호시각", "WG2Q38TP", CellType.SingleText, true, false);

            gt1.AddColumn("MC_TIME", "가동(분)", "", CellType.SingleText, true, false);
            gt1.AddColumn("IDLE_TIME", "비가동(분)", "", CellType.SingleText, true, false);
            gt1.AddColumn("RATE", "가동율", "", CellType.SingleText, true, false);

            gt1.EnterLinkCreateMode(false);
            gt1.EnterTimeItemCreateMode(false, null, 0);

            gt1.Grid.AllowRowResize = false;
            gt1.Grid.GridStructure.RowSelect = true;
            gt1.Grid.GridStructure.MultiSelect = false;

            gt2.VerticalLines = true;

            gt2.AddColumn("MC_NAME", "설비명", "41202", CellType.SingleText, true, false);
            gt2.AddColumn("UPDATE_DATE", "최근 신호시각", "WG2Q38TP", CellType.SingleText, true, false);

            gt2.AddColumn("MC_TIME", "가동(분)", "", CellType.SingleText, true, false);
            gt2.AddColumn("IDLE_TIME", "비가동(분)", "", CellType.SingleText, true, false);
            gt2.AddColumn("RATE", "가동율", "", CellType.SingleText, true, false);

            gt2.EnterLinkCreateMode(false);
            gt2.EnterTimeItemCreateMode(false, null, 0);

            gt2.Grid.AllowRowResize = false;
            gt2.Grid.GridStructure.RowSelect = true;
            gt2.Grid.GridStructure.MultiSelect = false;


            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            //this.gridView1.OptionsView.
            this.gridView1.OptionsView.ColumnAutoWidth = true;

            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            //this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            //this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            //this.OptionsSelection.EnableAppearanceHideSelection = true;

            base.MenuInit();
        }


        Timer panel_timer;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            simpleLabelItem5.Text = string.Format(" 최근 갱신 시각 : [{0}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //1000:1초
            panel_timer = new Timer();
            panel_timer.Interval = 60 * 1000;
            panel_timer.Tick += panel_timer_Tick;
            panel_timer.Start();

            Search();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel2.Visible = false;
            panel3.Visible = false;

            //Search_Gantt();
            //panel2.Visible = true;
            //panel2.Dock = DockStyle.Fill;

            //Search_Progress();
            //panel3.Visible = true;
            //panel3.Dock = DockStyle.Fill;
        }
        private int n_panel = 1;

        void panel_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                n_panel += 1;

                switch (n_panel % 3)
                {

                    case 1:
                        Search();
                        panel1.Visible = true;
                        panel1.Dock = DockStyle.Fill;
                        panel2.Visible = false;
                        panel3.Visible = false;

                        break;

                    case 2:
                        Search_Gantt();
                        panel2.Visible = true;
                        panel2.Dock = DockStyle.Fill;
                        panel1.Visible = false;
                        panel3.Visible = false;

                        break;

                    case 0:
                        Search_Progress();
                        panel3.Visible = true;
                        panel3.Dock = DockStyle.Fill;
                        panel1.Visible = false;
                        panel2.Visible = false;

                        n_panel = 1;
                        break;

                }
            }
            catch (Exception ex)
            {

            }
            

        }



        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
        }


        public override bool MenuDestory(object sender)
        {

            return base.MenuDestory(sender);
        }


        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }


        void Search()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("MC_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["MC_CODE"] = sMC_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "MNT01A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);   
        }



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            
            //설비 기본정보
            foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
            {
                string mc_code = row["MC_CODE"].ToString();
                
                if (lstMc.ContainsKey(mc_code))
                {
                    Control ctr = lstMc[mc_code];

                    ((ControlManager.acMntMachine)ctr).MC_IMG = row["MC_IMAGE"].toImage();
                    ((ControlManager.acMntMachine)ctr).MC_TITLE = row["MC_NAME"].ToString();
                    ((ControlManager.acMntMachine)ctr).STATUS_CODE = row["STS_CODE"].ToString();

                    DataRow[] actRows = e.result.Tables["RSACT"].Select(string.Format("MC_CODE = '{0}'", mc_code));

                    DataRow[] idleRows = e.result.Tables["RSIDLE"].Select(string.Format("MC_CODE = '{0}'", mc_code));


                    //실적 품목 정보
                    if (actRows.Length > 0)
                    {
                        ((ControlManager.acMntMachine)ctr).WK_OPT_CODE1 = actRows[0]["PART_NAME"].ToString();
                        ((ControlManager.acMntMachine)ctr).WK_OPT_CODE2 = actRows[0]["EMP_NAME"].ToString();
                    }

                    //비가동 사유 코드                         
                    if (idleRows.Length > 0)
                    {
                        ((ControlManager.acMntMachine)ctr).WK_OPT_CODE3 = idleRows[0]["IDLE_NAME"].ToString();
                    }
                }
                
            }

   
            base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        }

        void Search_Gantt()
        {
            try
            {
                //int colWidth = 100;
                //grid1.GridStructure.DrawPyjamas = true;

                //GridColumn mc_time = new GridColumn(CellType.SingleText, grid1.GridStructure);
                //mc_time.Title = "총 가동시간";
                //mc_time.Width = colWidth;
                //grid1.Columns.Add(mc_time);
                //mc_time.Layout.MinHeight = 20;

                //GridColumn idle_time = new GridColumn(CellType.SingleText, grid1.GridStructure);
                
                //idle_time.Title = "비가동시간";
                //idle_time.Width = colWidth;
                //grid1.Columns.Add(idle_time);
                //idle_time.Layout.MinHeight = 20;

                //GridColumn rate = new GridColumn(CellType.SingleText, grid1.GridStructure);
                //rate.Title = "가동율";
                //rate.Width = colWidth;
                //grid1.Columns.Add(rate);
                //rate.Layout.MinHeight = 20;

                
                //GridColumn mc_time2 = new GridColumn(CellType.SingleText, grid1.GridStructure);
                //mc_time.Title = "총 가동(분)";
                //mc_time.Width = colWidth;
                //grid2.Columns.Add(mc_time);
                

                //GridColumn idle_time2 = new GridColumn(CellType.SingleText, grid1.GridStructure);
                //idle_time.Title = "비가동(분)";
                //idle_time.Width = colWidth;
                //grid2.Columns.Add(idle_time);
                
                //GridColumn rate2 = new GridColumn(CellType.SingleText, grid1.GridStructure);
                //rate.Title = "가동율";
                //rate.Width = colWidth;
                //grid2.Columns.Add(rate);
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_DATE"] =DateTime.Now.ToString("yyyyMMdd");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD, "MNT03A_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2",
                    DrawGantt,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        void DrawGantt(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //기계명, 시간, 가동 데이터, 총 가도시간,  비가동 시간, 가동율
                //MC_CODE		, M.MC_NAME, UPDATE_DATE	 TOT_CAPA  MC_TIME		 IDLE_TIME , WORK_RATE	");

                DataTable data = e.result.Tables["RSLTDT"];
                DataTable dtLog = e.result.Tables["RSLTDT2"];

                
                if (data.Rows.Count > 0)
                {

                    DrawGT(data.Select("DEPT_INFO = '가공 1팀'").CopyToDataTable(), dtLog, gt1);

                    DrawGT(data.Select("DEPT_INFO = '가공 2팀'").CopyToDataTable(), dtLog, gt2);

                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void DrawGT(DataTable data, DataTable dtLog, acGantt gt)
        {
            gt.Enabled = true;
            
            //Clear
            gt.TimeItemTextLayouts.Clear();
            gt.Grid.GridStructure.RootNodes.Clear();
           
            gt.ClearVerticalLine();
            gt.TimeItemLinks.Clear();
           

            gt.DateScaler.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);//, layoutRow["S_DATE"].toDateTime().AddHours(8);
            gt.DateScaler.StopTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);  //layoutRow["S_DATE"].toDateTime().AddHours(8).Add(new TimeSpan(23, 59, 59));

            gt.DateScaler.BoxesOnDaysRulerOnTime = true;

            double mc_sum = 0, idle_sum = 0;
            double cnt = 0;
            double rate = 0;

            if (data.Rows.Count > 0)
            {
                GridNode gn = null;
                GanttRow gr = null;
                
                for (int i = 0; i < data.Rows.Count + 1; i++)
                {
                    //간트차트 내 그리드
                    gn = gt.Grid.GridStructure.RootNodes.AddNode();
                    //우측 그리드
                    //r_gn = grd.GridStructure.RootNodes.AddNode();
                    //r_gn.UserRowHeight = gt_rowheight;

                    if (i == data.Rows.Count)
                    {
                        gn.GetCell(gt.GetColumn("MC_NAME").Index).Content.Value = string.Empty;
                        gn.GetCell(gt.GetColumn("UPDATE_DATE").Index).Content.Value = "평 균";

                        gn.GetCell(gt.GetColumn("MC_TIME").Index).Content.Value = string.Empty;
                        gn.GetCell(gt.GetColumn("IDLE_TIME").Index).Content.Value = string.Empty;
                        gn.GetCell(gt.GetColumn("RATE").Index).Content.Value = string.Format("{0:#,##0.#}", (rate / data.Rows.Count)) + "%   ";

                        //r_gn.GetCell(0).Content.Value = string.Empty;
                        //r_gn.GetCell(1).Content.Value = "평균";
                        //r_gn.GetCell(2).Content.Value = string.Format("{0:#,##0.#}", (mc_sum / (data.Rows.Count * 8) * 100)) + "%   ";

                        continue;
                    }
                    

                    string mc_code = data.Rows[i]["MC_CODE"].ToString();
                    string condition = "MC_CODE = '" + mc_code + "'";

                    gn.GetCell(gt.GetColumn("MC_NAME").Index).Content.Value = data.Rows[i]["MC_NAME"];
                    gn.GetCell(gt.GetColumn("UPDATE_DATE").Index).Content.Value = data.Rows[i]["UPDATE_DATE"].toDateString("yyyy-MM-dd HH:mm");

                    gn.GetCell(gt.GetColumn("MC_TIME").Index).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["MC_TIME"].ToString()));
                    gn.GetCell(gt.GetColumn("IDLE_TIME").Index).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["IDLE_TIME"].ToString()));
                    gn.GetCell(gt.GetColumn("RATE").Index).Content.Value = string.Format("{0:#,##0.#}", Double.Parse(data.Rows[i]["WORK_RATE"].ToString())) + "%   ";

                    //r_gn.GetCell(0).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["MC_TIME"].ToString()));
                    //r_gn.GetCell(1).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["IDLE_TIME"].ToString())); 
                    //r_gn.GetCell(2).Content.Value = string.Format("{0:#,##0.#}", Double.Parse(data.Rows[i]["WORK_RATE"].ToString())) + "%   ";

                    mc_sum += data.Rows[i]["MC_TIME"].toDouble();
                    idle_sum += data.Rows[i]["IDLE_TIME"].toDouble();
                    rate += data.Rows[i]["WORK_RATE"].toDouble();

                    gn.GetCell(gt.GetColumn("MC_NAME").Index).Layout.HorzAlign = StringAlignment.Near;
                    gn.GetCell(gt.GetColumn("MC_NAME").Index).Layout.VertAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("UPDATE_DATE").Index).Layout.HorzAlign = StringAlignment.Center; 
                    gn.GetCell(gt.GetColumn("UPDATE_DATE").Index).Layout.VertAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("MC_TIME").Index).Layout.HorzAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("MC_TIME").Index).Layout.VertAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("IDLE_TIME").Index).Layout.HorzAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("IDLE_TIME").Index).Layout.VertAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("RATE").Index).Layout.HorzAlign = StringAlignment.Center;
                    gn.GetCell(gt.GetColumn("RATE").Index).Layout.VertAlign = StringAlignment.Center;

                    gr = GanttRow.FromGridNode(gn);
                    gr.CollisionDetect = false;
                    
                    DataRow[] drArr = dtLog.Select(condition);
                    
                    for (int j = 0; j < drArr.Length; j++)
                    {
                        this.CreateTimeItem(gr.Layers[0], drArr[j]);
                    }

                }

                
                gt.GetColumn("MC_NAME").Width = 100;
                gt.GetColumn("UPDATE_DATE").Width = 140;
                gt.GetColumn("MC_TIME").Width = 70;
                gt.GetColumn("IDLE_TIME").Width = 70;
                gt.GetColumn("RATE").Width = 70;

                gt.GridWidth = 480;
                gt.RowHeight = gt_rowheight;
                
                //grd.Width = 100;
                
            }
        }

        private TimeItem CreateTimeItem(Layer layer, DataRow dr)
        {

            try
            {

                TimeItem ti = new TimeItem();

                ti.TimeItemLayout = new TimeItemLayout();

                ti.TimeItemLayout.AllowResizeEast = false;
                ti.TimeItemLayout.AllowResizeWest = false;
                ti.TimeItemLayout.AllowChangeRow = false;
                ti.TimeItemLayout.AllowMove = false;

                ti.TimeItemLayout.AllowLinkReAssignStart = false;
                ti.TimeItemLayout.AllowLinkReAssignTarget = false;
                ti.TimeItemLayout.AllowLinkSelectionStart = false;
                ti.TimeItemLayout.AllowLinkSelectionTarget = false;

                Color cl = Color.White;

                ti.TimeItemLayout.Color = cl;
                //ti.TimeItemLayout.TimeItemStyle = TimeItemStyle.Pipe;
                ti.TimeItemLayout.TimeItemStyle = TimeItemStyle.Square;
                ti.TimeItemLayout.ConflictAreaDrawStyle = ConflictAreaDrawStyle.Normal;

                ti.Start = dr["MC_START_TIME"].toDateTime();
                ti.Stop = dr["MC_END_TIME"].toDateTime();

                //설비신호에 따른 아이콘 설정
                switch (dr["MC_STATE"].ToString())
                {
                    case "3":
                        //가동
                        ti.TimeItemLayout.Color = clrRun;//Color.DodgerBlue;
                        ti.TimeItemLayout.FrameColor = clrRun;
                        break;

                    case "2":
                        //비가동
                        ti.TimeItemLayout.Color = clrPause;//Color.White;
                        ti.TimeItemLayout.FrameColor = clrPause;
                        break;

                    case "0":
                        //전원off
                        ti.TimeItemLayout.Color = clrOff;
                        ti.TimeItemLayout.FrameColor = clrOff;

                        break;

                    case "9":
                        //알람
                        ti.TimeItemLayout.Color = clrError;//Color.Red;
                        ti.TimeItemLayout.FrameColor = clrError;
                        break;


                }
                ti.TimeItemLayout.BrushKind = BrushKind.Solid;
                
                layer.Add(ti);

                return ti;

            }
            catch
            {
                return null;
            }
        }

        //가공현황
        void Search_Progress()
        {
            gcQTY.Caption = "완료수량 \n 총수량";

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("MC_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["MC_CODE"] = sMC_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "MNT10A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearchProgress,
              QuickException);
        }

        void QuickSearchProgress(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                e.result.Tables["RSLTDT"].Columns.Add("W_PROG");
                e.result.Tables["RSLTDT"].Columns.Add("PART");
                e.result.Tables["RSLTDT"].Columns.Add("QTY");
                
                for (int i = 0; i < e.result.Tables["RSLTDT"].Rows.Count; i++)
                {

                    if (e.result.Tables["RSLTDT"].Rows[i]["PART_QTY"].toInt() != 0)
                    {
                        e.result.Tables["RSLTDT"].Rows[i]["W_PROG"] = Math.Round(e.result.Tables["RSLTDT"].Rows[i]["ACT_QTY"].toDouble() / e.result.Tables["RSLTDT"].Rows[i]["PART_QTY"].toDouble(), 2) * 100; // (Math.Round(e.result.Tables["RSLTDT"].Rows[i]["ACT_QTY"].toDouble() / e.result.Tables["RSLTDT"].Rows[i]["PART_QTY"].toDouble(), 2) * 100).ToString() + "%";
                    }
                    else
                    {
                        e.result.Tables["RSLTDT"].Rows[i]["W_PROG"] = 0;// "0%";
                    }

                    e.result.Tables["RSLTDT"].Rows[i]["PART"] = e.result.Tables["RSLTDT"].Rows[i]["PART_CODE"].ToString() + " \n" +
                        e.result.Tables["RSLTDT"].Rows[i]["PART_NAME"].ToString();

                    e.result.Tables["RSLTDT"].Rows[i]["QTY"] = e.result.Tables["RSLTDT"].Rows[i]["ACT_QTY"].ToString() + " / " +
                        e.result.Tables["RSLTDT"].Rows[i]["PART_QTY"].ToString();

                }


                gridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
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

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            Search();
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnViewPanel1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel2.Visible = false;
            panel3.Visible = false;

            panel_timer.Stop();
            
        }

        private void btnViewPanel2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search_Gantt();
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
            panel1.Visible = false;
            panel3.Visible = false;

            panel_timer.Stop();
        }

        private void btnViewPanel3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search_Progress();
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panel1.Visible = false;
            panel2.Visible = false;

            panel_timer.Stop();
        }

        private void btnAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel_timer.Start();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int interval = barEditItem1.EditValue.toInt();

                panel_timer.Stop();
                panel_timer.Interval = interval * 1000;
                panel_timer.Start();
            }
            catch (Exception ex)
            {

            }
            

        }

    }
}

