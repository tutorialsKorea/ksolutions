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
    public sealed partial class MNT11A_M0A : BaseMenu
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
        
        Color _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
        Color _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
        Color _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
        Color _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

        public MNT11A_M0A()
        {
            InitializeComponent();

        }

        public override void MenuInit()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            base.MenuInit();
        }

        Timer panel_timer;

        DataTable _dtGridview1 = new DataTable();
        DataTable _dtGridview2 = new DataTable();


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            acGridView1.GridType = acGridView.emGridType.AUTO_COL;
            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.AddTextEdit("ITEM_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_NAME", "고객명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddMemoEdit("PART", "품번 / 품명", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddTextEdit("QTY", "완료/ 총 수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            _dtGridview1.Columns.Add("ITEM_CODE", typeof(String));
            _dtGridview1.Columns.Add("DUE_DATE", typeof(String));
            _dtGridview1.Columns.Add("CVND_NAME", typeof(String));
            _dtGridview1.Columns.Add("PART", typeof(String));
            _dtGridview1.Columns.Add("QTY", typeof(String));
            _dtGridview1.Columns.Add("STATE", typeof(String));

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN_PROC", paramSet, "RQSTDT", "RSLTDT");

            DataRow[] drAssyProcs = rsltSet.Tables["RSLTDT"].Select(string.Format("MPROC_CODE = '{0}'", "C001"));

            if (drAssyProcs.Length > 0)
            {
                foreach (DataRow row in drAssyProcs)
                {
                    acGridView1.AddMemoEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                    acGridView1.Columns[row["PROC_CODE"].ToString()].Tag = "PROC_COL";

                    _dtGridview1.Columns.Add(row["PROC_CODE"].ToString(), typeof(String));
                }
            }

            acGridView1.AddTextEdit("END_DATE", "완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROG_PART", "가공 진행 중 부품", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            _dtGridview1.Columns.Add("END_DATE", typeof(String));
            _dtGridview1.Columns.Add("PROG_PART", typeof(String));

            Font mnt_font = new Font("맑은 고딕", 11);
            Font mnt_Headerfont = new Font("맑은 고딕", 15, FontStyle.Bold);
            acGridView1.ColumnPanelRowHeight = 50;
            acGridView2.ColumnPanelRowHeight = 50;

            foreach(DevExpress.XtraGrid.Columns.GridColumn col in acGridView1.Columns)
            {
                //col.
                col.AppearanceCell.Font = mnt_font;
                col.AppearanceHeader.Font = mnt_Headerfont;
                
                col.AppearanceHeader.BackColor = Color.DarkCyan;
                col.AppearanceHeader.BackColor2 = Color.DarkCyan;
                col.AppearanceHeader.ForeColor = Color.White;
                
            }

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;


            //출하현황 그리드
            acGridView2.GridType = acGridView.emGridType.AUTO_COL;
            acGridView2.OptionsView.ShowIndicator = true;
            acGridView2.OptionsView.AllowHtmlDrawHeaders = true;

            acGridView2.AddTextEdit("ITEM_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("출하예정일", "납기일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("CVND_NAME", "고객명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddMemoEdit("PART", "품번/품명", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddTextEdit("QTY", "납품 수량 \n/ 총 수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            _dtGridview2.Columns.Add("ITEM_CODE", typeof(String));
            _dtGridview2.Columns.Add("DUE_DATE", typeof(String));
            _dtGridview2.Columns.Add("CVND_NAME", typeof(String));
            _dtGridview2.Columns.Add("PART", typeof(String));
            _dtGridview2.Columns.Add("QTY", typeof(String));
            _dtGridview2.Columns.Add("STATE", typeof(String));

            DataRow[] drShipProcs = rsltSet.Tables["RSLTDT"].Select("IS_SHIP_PROC = 1");

            if (drShipProcs.Length > 0)
            {
                foreach (DataRow row in drShipProcs)
                {
                    acGridView2.AddMemoEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                    acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC_COL";
                    _dtGridview2.Columns.Add(row["PROC_CODE"].ToString(), typeof(String));

                }
            }

            
            acGridView2.AddTextEdit("SH_PLN_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SH_FNS_DATE", "출하완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            _dtGridview2.Columns.Add("SH_PLN_DATE", typeof(String));
            _dtGridview2.Columns.Add("SH_FNS_DATE", typeof(String));

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in acGridView2.Columns)
            {
                //col.
                col.AppearanceCell.Font = mnt_font;
                col.AppearanceHeader.Font = mnt_Headerfont;

                col.AppearanceHeader.BackColor = Color.DarkCyan;
                col.AppearanceHeader.BackColor2 = Color.DarkCyan;
                col.AppearanceHeader.ForeColor = Color.White;
            }

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;

            Search();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;

            panel_timer = new Timer();
            panel_timer.Interval = 10000;
            panel_timer.Tick += panel_timer_Tick;
            panel_timer.Start();

        }

        void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Tag == null) return;

            if (e.Column.Tag.ToString() == "PROC_COL")
            {

                e.Appearance.ForeColor = Color.Black;
                string[] arrState = e.CellValue.ToString().Split('\n');

                if (arrState.Length == 2)
                {
                    //switch (e.CellValue.ToString())
                    switch (arrState[1])
                    {
                        case "(지연)":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        case "(ND)":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        case "(확정)":
                            e.Appearance.BackColor = _WAIT;
                            break;
                        case "(실적)":
                            e.Appearance.BackColor = _RUN;
                            break;
                        case "(중지)":
                            e.Appearance.BackColor = _PAUSE;
                            break;
                        case "(완료)":
                            e.Appearance.BackColor = _FINISH;
                            break;

                    }
                }

            }
            
        }

        void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Tag == null) return;

            if (e.Column.Tag.ToString() == "PROC_COL")
            {

                e.Appearance.ForeColor = Color.Black;
                string[] arrState = e.CellValue.ToString().Split('\n');

                if (arrState.Length == 2)
                {
                    //switch (e.CellValue.ToString())
                    switch (arrState[1])
                    {
                        case "(지연)":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        case "(ND)":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        case "(확정)":
                            e.Appearance.BackColor = _WAIT;
                            break;
                        case "(진행)":
                            e.Appearance.BackColor = _RUN;
                            break;
                        case "(실적)":
                            e.Appearance.BackColor = _RUN;
                            break;
                        case "(중지)":
                            e.Appearance.BackColor = _PAUSE;
                            break;
                        case "(완료)":
                            e.Appearance.BackColor = _FINISH;
                            break;
                        
                    }
                }
                
            }
            
            
        }
        private int n_panel = 0;

        void panel_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                n_panel += 1;

                switch (n_panel % 2)
                {
                    case 0:
                        Search();
                        panel1.Visible = true;
                        panel1.Dock = DockStyle.Fill;
                        panel2.Visible = false;

                        n_panel = 0;
                        break;

                    case 1:
                        Search2();
                        panel2.Visible = true;
                        panel2.Dock = DockStyle.Fill;
                        panel1.Visible = false;

                        break;
                }
            }
            catch (Exception)
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
            //조립현황
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //조립 중일정 그룹 코드로 조립 공정만 표시.
            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "MNT11A_SER", paramSet, "RQSTDT", "RSLTDT",
            //  QuickSearch,
            //  QuickException);

            DataSet dtResult = BizRun.QBizRun.ExecuteService(this, "MNT11A_SER", paramSet, "RQSTDT", "RSLTDT");

            QuickAssySearch(dtResult);
        }

        void QuickAssySearch(DataSet ds)
        {
            try
            {
                DataTable dtRslt = ds.Tables["RSLTDT"];
                DataTable dtRslt_Part = ds.Tables["RSLTDT_PART"];

                string prod_code = dtRslt.Rows.Count > 0 ? dtRslt.Rows[0]["PROD_CODE"].ToString() : "";
                string part_code = dtRslt.Rows.Count > 0 ? dtRslt.Rows[0]["PART_CODE"].ToString() : "";
                string str_key = string.Empty;
                string wo_flag = string.Empty;
                string disp_proc = string.Empty;
                string old_prod = string.Empty;
                string old_part = string.Empty;

                DataRow newrow = null;
                _dtGridview1.Rows.Clear();

                foreach (DataRow row in dtRslt.Rows)
                {
                    
                    if (str_key == row["PROD_CODE"].ToString() + row["PART_CODE"].ToString())
                    {
                        string pln_end = row["PLN_END_TIME"].ToString();
                        string flag = row["WO_FLAG"].ToString();

                        disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");

                        if (row["ACT_END_TIME"].ToString() != "" )
                            disp_proc = row["ACT_END_TIME"].toDateString("MM/dd");                            
                        
                        disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";

                        //0:미확정, 1:확정, 2:진행, 3:중지, 4:완료
                        if (((row["WO_FLAG"].ToString() == "0") || (row["WO_FLAG"].ToString() == "1")) &&
                            (row["PLN_END_TIME"].ToString() != "") && 
                            (row["PLN_END_TIME"].toDateTime() < DateTime.Today))
                        {
                            //disp_proc += "\n(지연)";
                            disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");
                            disp_proc += "\n(지연)";
                        }
                                

                        newrow[row["PROC_CODE"].ToString()] = disp_proc;

                        newrow["STATE"] = acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString());

                        if (row["PROC_CODE"].ToString() == "P-23")
                            newrow["END_DATE"] = row["END_DATE"].toDateString("MM/dd");
                    }
                    else
                    {
                      //최종 상태 표시
                        if (newrow != null)
                        {
                            DataRow[] drRows = dtRslt.Select(string.Format("PROD_CODE = '{0}' AND PART_CODE = '{1}'", old_prod, old_part));
                            string state = string.Empty;
                            bool bfinish = false;

                            foreach (DataRow dr in drRows)
                            {
                                if (dr["WO_FLAG"].ToString() == "2")
                                {
                                    state = "진행";
                                    break;
                                }
                                else if (dr["WO_FLAG"].ToString() == "3")
                                {
                                    state = "중지";
                                    break;
                                }
                                else if ((dr["PROC_CODE"].ToString() == "P-23") && (dr["WO_FLAG"].ToString() == "4"))
                                {
                                    //조립검사 완료이면 상태는 완료, 완료일에 조립검사 완료일 설정
                                    bfinish = true;
                                    state = "완료";
                                    break;
                                }
                                else if ((dr["PROC_CODE"].ToString() == "P-22") && (dr["WO_FLAG"].ToString() == "4"))
                                {
                                    //정조립 완료일 경우, 해당 품목에 조립검사 공정이 없으면 완료로 본다.
                                    DataRow[] isEnd = dtRslt.Select(string.Format("PROD_CODE = '{0}' AND PART_CODE = '{1}' AND PROC_CODE = 'P-23'", old_prod, old_part));
                                    if (isEnd.Length == 0)
                                    {
                                        bfinish = true;
                                        state = "완료";
                                        break;
                                    }
                                    
                                }
                                else if (dr["WO_FLAG"].ToString() == "0" || dr["WO_FLAG"].ToString() == "1")
                                {
                                    if (dr["PLN_END_TIME"].ToString() == "")
                                    {
                                        state = "일정미확정";
                                    }
                                    else if (dr["PLN_END_TIME"].toDateTime() < DateTime.Today)
                                    {
                                        state = "지연";
                                    }
                                    else
                                    {
                                        state = "확정";
                                    }
                                    break;
                                }                                
                            }

                            //가공중 부품
                            DataRow[] drPrgParts = dtRslt_Part.Select(string.Format("PROD_CODE = '{0}' ", old_prod));
                            string prg_parts = string.Empty;
                            foreach (DataRow drPrg in drPrgParts)
                            {
                                prg_parts += drPrg["PART_CODE"].ToString() + "\n";
                            }

                            newrow["PROG_PART"] = prg_parts;

                            if (bfinish)
                            {
                                //조립검사 완료일이 어제가 아니면 skip.
                                string dt = DateTime.Today.AddDays(-1).ToString("MM-dd");
                                bfinish = false;

                                if (dt == newrow["END_DATE"].ToString())
                                    _dtGridview1.Rows.Add(newrow);
                            }
                            else
                            {
                                newrow["STATE"] = state;
                                _dtGridview1.Rows.Add(newrow);
                            }
                                
                        }
                            

                        str_key = row["PROD_CODE"].ToString() + row["PART_CODE"].ToString();
                        old_prod = row["PROD_CODE"].ToString();
                        old_part = row["PART_CODE"].ToString();

                        newrow = _dtGridview1.NewRow();
                        newrow["ITEM_CODE"] = row["ITEM_CODE"];
                        newrow["DUE_DATE"] = row["DUE_DATE"].toDateString("yyyy-MM-dd");
                        newrow["CVND_NAME"] = row["CVND_NAME"];
                        newrow["PART"] = row["PART_CODE"].ToString() + " \n" + row["PROD_NAME"].ToString();
                        newrow["QTY"] = row["OK_QTY"].ToString() + " / " + row["PROD_QTY"].ToString();

                        disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");

                        if (row["ACT_END_TIME"].ToString() != "")
                            disp_proc = row["ACT_END_TIME"].toDateString("MM/dd");

                        disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";

                        //0:미확정, 1:확정, 2:진행, 3:중지, 4:완료
                        if (((row["WO_FLAG"].ToString() == "0") || (row["WO_FLAG"].ToString() == "1")) &&
                            (row["PLN_END_TIME"].ToString() != "") &&
                            (row["PLN_END_TIME"].toDateTime() < DateTime.Today))
                        {
                            //disp_proc += "\n(지연)";
                            disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");
                            disp_proc += "\n(지연)";
                        }

                        newrow[row["PROC_CODE"].ToString()] = disp_proc;
                        newrow["STATE"] = acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString());

                    }
                }

                //DataRow[] drSorted = _dtGridview1.Select("", "CVND_NAME, PART ");
                DataRow[] drSorted = _dtGridview1.Select("", "DUE_DATE  ");
                acGridView1.GridControl.DataSource = drSorted.CopyToDataTable();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void Search2()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); 
            paramTable.Columns.Add("WORK_DATE", typeof(String)); 

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WORK_DATE"] = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "MNT11A_SER2", paramSet, "RQSTDT", "RSLTDT",
            //  QuickSearch2,
            //  QuickException);

            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "MNT11A_SER2", paramSet, "RQSTDT", "RSLTDT");

            QuickSearch2(dsResult);

        }

        void QuickSearch2(DataSet ds)
        {
            try
            {
                DataTable dtRslt = ds.Tables["RSLTDT"];
                DataTable dtpart = ds.Tables["RSLTDT_PROD"];

                string prod_code = dtRslt.Rows.Count > 0 ? dtRslt.Rows[0]["PROD_CODE"].ToString() : "";
                string part_code = dtRslt.Rows.Count > 0 ? dtRslt.Rows[0]["PART_CODE"].ToString() : "";
                string str_key = string.Empty;
                string wo_flag = string.Empty;
                string disp_proc = string.Empty;
                string old_prod = string.Empty; 
                string old_part = string.Empty;

                DataRow newrow = null;
                _dtGridview2.Rows.Clear();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (str_key == row["PROD_CODE"].ToString() + row["PART_CODE"].ToString())
                    {
                        disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");

                        if (row["ACT_END_TIME"].ToString() != "")
                            disp_proc = row["ACT_END_TIME"].toDateString("MM/dd");

                        disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";

                        //0:미확정, 1:확정, 2:진행, 3:중지, 4:완료
                        if (((row["WO_FLAG"].ToString() == "0") || (row["WO_FLAG"].ToString() == "1")) &&
                            (row["PLN_END_TIME"].ToString() != "") &&
                            (row["PLN_END_TIME"].toDateTime() < DateTime.Today))
                        {
                            //disp_proc += "\n(지연)";
                            disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");
                            disp_proc += "\n(지연)";
                        }



                        //if ((row["PLN_END_TIME"].ToString() != "") && (row["PLN_END_TIME"].toDateTime() < DateTime.Today))
                        //    disp_proc += "\n(지연)";
                        //else if (row["ACT_END_TIME"].ToString() == "")
                        //    disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";
                        //else
                        //{
                        //    disp_proc = row["ACT_END_TIME"].toDateString("MM/dd");
                        //    disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";
                        //}
                        
                        newrow[row["PROC_CODE"].ToString()] = disp_proc;

                        newrow["STATE"] = acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString());

                    }
                    else
                    {

                        //최종 상태 표시

                        if (newrow != null)
                        {
                            DataRow[] drRows = dtRslt.Select(string.Format("PROD_CODE = '{0}' AND PART_CODE = '{1}'", old_prod, old_part));
                            string state = string.Empty;

                            foreach (DataRow dr in drRows)
                            {
                                if (dr["WO_FLAG"].ToString() == "2")
                                {
                                    state = "진행";
                                    break;
                                }
                                else if (dr["WO_FLAG"].ToString() == "3")
                                {
                                    state = "중지";
                                    break;
                                }
                                else if ((dr["PROC_CODE"].ToString() == "P-25") && (dr["WO_FLAG"].ToString() == "4"))
                                {
                                    state = "완료";
                                    break;
                                }
                                else if (dr["WO_FLAG"].ToString() == "4")
                                {
                                    state = "진행";
                                    break;
                                }
                                else if (dr["WO_FLAG"].ToString() == "0" || dr["WO_FLAG"].ToString() == "1")
                                {
                                    if (dr["PLN_END_TIME"].toDateTime() < DateTime.Today)
                                            state = "지연";
                                        else
                                            state = "확정";
                                        
                                }                                
                            }

                            newrow["STATE"] = state;
                            DataRow[] drship = dtpart.Select(string.Format("PROD_CODE = '{0}' AND PART_CODE = '{1}'", old_prod, old_part));

                            if (drship.Length > 0)
                            {
                                newrow["QTY"] = drship[0]["SHIP_QTY"].ToString() + " / " + drship[0]["PROD_QTY"].ToString();
                                if (drship[0]["SHIP_DATE"].ToString() != "")
                                    newrow["SH_FNS_DATE"] = drship[0]["SHIP_DATE"].toDateString("MM/dd");
                            }

                            _dtGridview2.Rows.Add(newrow);
                        }

                        str_key = row["PROD_CODE"].ToString() + row["PART_CODE"].ToString();
                        old_prod = row["PROD_CODE"].ToString();
                        old_part = row["PART_CODE"].ToString();

                        newrow = _dtGridview2.NewRow();
                        newrow["ITEM_CODE"] = row["ITEM_CODE"];
                        newrow["DUE_DATE"] = row["DUE_DATE"];
                        newrow["CVND_NAME"] = row["CVND_NAME"];
                        newrow["PART"] = row["PART_CODE"].ToString() + " \n" + row["PROD_NAME"].ToString();
                        

                        disp_proc = row["PLN_END_TIME"].toDateString("MM/dd");

                        if (row["ACT_END_TIME"].ToString() == "")
                        {
                            if (row["PROC_CODE"].ToString() == "P-25")
                                newrow["SH_PLN_DATE"] = disp_proc;

                            if ((row["PLN_END_TIME"].ToString() != "") && (row["PLN_END_TIME"].toDateTime() < DateTime.Today))
                                disp_proc += "\n(지연)";
                            else
                                disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";

                            if (row["PROC_CODE"].ToString() == "P-25")
                                newrow["SH_PLN_DATE"] = disp_proc;
                        }
                        else
                        {

                            disp_proc = row["ACT_END_TIME"].toDateString("MM/dd");

                            if (row["PROC_CODE"].ToString() == "P-25")
                                newrow["SH_PLN_DATE"] = disp_proc;

                            disp_proc += "\n(" + acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString()) + ")";
                        }

                        
                        newrow[row["PROC_CODE"].ToString()] = disp_proc;
                        //newrow["STATE"] = acInfo.StdCodes.GetNameByCode("S032", row["WO_FLAG"].ToString());

                    }
                }

                DataRow[] drSorted = _dtGridview2.Select("", "SH_PLN_DATE DESC");
                acGridView2.GridControl.DataSource = drSorted.CopyToDataTable();
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

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int interval = barEditItem2.EditValue.toInt();

                panel_timer.Stop();
                panel_timer.Interval = interval * 1000;
                panel_timer.Start();

            }
            catch (Exception ex)
            {

            }
            
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel2.Visible = false;
           
            panel_timer.Stop();
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search2();
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
            panel1.Visible = false;

            panel_timer.Stop();
        }

    }
}


