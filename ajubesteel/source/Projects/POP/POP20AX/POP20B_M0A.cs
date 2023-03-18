using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using BizManager;
using CodeHelperManager;

namespace POP
{
    public sealed partial class POP20B_M0A : BaseMenu
    {


        public override void BarCodeScanInput(string barcode)
        {
        }



        public POP20B_M0A()
        {
            InitializeComponent();
        }

        private string _strMcCode = "";
        private string _strMcName = "";
        private string _strEmpCode = acInfo.UserID;
        private string _strEmpName = acInfo.UserName;
        private string _strIdleName = "";
        private string _strIdleStartTime = "";

        private string _strStdTime = "";
        private string _strScomment = "";

        private bool idleState = false;
        private bool _prog = false;

        private DateTime nowDate = DateTime.Today;
        
        private string _strDay = "";
        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public override void MenuInit()
        {
            workOrderGridView.GridType = acGridView.emGridType.LIST_USERCONFIG;

            workOrderGridView.OptionsView.ShowIndicator = true;

            workOrderGridView.AddTextEdit("AP", "▼", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("ITEM_CODE", "수주\n코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddDateEdit("DUE_DATE", "납기일", "40111", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.FMT_DATE);
            workOrderGridView.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("DRAW_NO", "도면\n번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("MAT_SPEC1", "제품\n규격", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PLN_QTY", "계획\n수량", "NAFTT723", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            
            //workOrderGridView.AddTextEdit("SCOMMENT", "주의사항", "D2FYBIE6", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            workOrderGridView.AddTextEdit("CVND_CODE", "수주처\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PROD_CODE", "제품\n코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_CODE", "품목\n코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PRG_CODE", "공정그룹", "40962", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            //workOrderGridView.AddTextEdit("SCOMMENT", "지시\n사항", "D5RQPURL", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.QTY);
            workOrderGridView.AddTextEdit("OK_QTY", "완료\n수량", "U2DGVJ7B", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.QTY);
            //workOrderGridView.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S032");

            workOrderGridView.KeyColumn = new string[] { "PROD_CODE", "PART_CODE" };

            workOrderGridView.RowHeight = 40;
            workPlanGridView.RowHeight = 40;


            #region 임시 작업지시 저장

            workOrderTMPGridView.GridType = acGridView.emGridType.LIST_USERCONFIG;
            workOrderTMPGridView.OptionsView.ShowIndicator = true;

            workOrderTMPGridView.AddTextEdit("PLT_CODE", "사업장코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("CVND_CODE", "수주처\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("ITEM_CODE", "수주\n코드", "40377", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PROD_CODE", "제품\n코드", "40900", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PART_CODE", "품목\n코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddLookUpEdit("JOB_PRIORITY", "우선\n순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");
            workOrderTMPGridView.AddTextEdit("PART_NAME", "품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("DRAW_NO", "도면\n번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("MAT_SPEC1", "제품\n규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("MC_CODE", "설비", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("PART_QTY", "계획\n수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("ACT_QTY", "완료\n수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddTextEdit("WORK_PROGRESS", "진행률", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderTMPGridView.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            workOrderTMPGridView.AddPictrue("ATTACH", "첨부\n파일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true);

            workOrderTMPGridView.KeyColumn = new string[] { "WO_NO" };

            workOrderTMPGridView.RowHeight = 40;

            #endregion

            //_strWeek = GetJuCha(nowDate);
            _strDay = nowDate.toDateString("yyyyMMdd");

            TimeLabel.Text = nowDate.toDateString("yyyy-MM-dd");//sDate.toDateString("yy/MM/dd") + " ∼ " + eDate.toDateString("yy/MM/dd");

            _strMcCode = _strEmpCode;
            _strMcName = _strEmpName;
            
            EmpLabel.Text = _strEmpName;

            //workOrderGridView.FocusedRowChanged += workOrderGridView_FocusedRowChanged;
            //workOrderGridView.MouseDown += workOrderGridView_MouseDown;

            workPlanGridView.FocusedColumnChanged += workPlanGridView_FocusedColumnChanged;
            workPlanGridView.FocusedRowChanged += workPlanGridView_FocusedRowChanged;
            
            workPlanGridView.MouseUp += workPlanGridView_MouseUp;

            #region 컨트롤 설정
            SetPopGridFont(workOrderGridView, null);

            SetPopGridFont(workPlanGridView, null);

            int extSz = 3;

            TimeLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Regular, GraphicsUnit.Point);

            EmpLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Regular, GraphicsUnit.Point);

            simpleLabelItem2.AppearanceItemCaption.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Bold, GraphicsUnit.Point);


            Control[] con = formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            ControlCollection ctrBtns = acLayoutControl3.Controls;

            foreach (Control ctr in ctrBtns)
            {
                if (ctr.Name.StartsWith("btn"))
                {
                    ((ControlManager.acSimpleButton)ctr).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 20,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }


            btnAll.Text = "전체\n작업";

            #endregion

            base.MenuInit();
        }

        void workPlanGridView_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                
                DataRow focus = workPlanGridView.GetFocusedDataRow();

                GridHitInfo hitInfo = workPlanGridView.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    if (hitInfo.Column.FieldName == "colATTACH" )
                        //&& focus.Table.Columns.Contains("ATT_QTY")
                        //&& focus["ATT_QTY"].toInt() > 0)
                    {
                        DataTable dtParam = new DataTable();
                        dtParam.Columns.Add("WO_NO", typeof(String));

                        DataRow dr = dtParam.NewRow();

                        //focus["PART_CODE"] = workOrderGridView.GetRowCellValue(hitInfo.RowHandle, workOrderGridView.Columns["PART_CODE"]);

                        AttachFileList frm = new AttachFileList(workPlanGridView.GetRowCellValue(hitInfo.RowHandle, workPlanGridView.Columns["PART_CODE"]));

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW", frm);

                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
        }

        protected override void OnLoad(EventArgs e)
        {
            //상단 그리드 조회
            this.search(false);

            //현재 작업 그리드 조회
            search_PLAN();

            base.OnLoad(e);
        }

        /// <summary>
        /// 작업지시 임시 그리드
        /// 버튼 작업을 위해 필요함.
        /// </summary>
        void searchTMP()
        {
            if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
            {
                workOrderTMPGridView.ClearRow();
                WorkStat();
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = workPlanGridView.GetFocusedValue();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER3", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearchTMP,
                   QuickException);
        }

        void QuickSearchTMP(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
             
                workOrderTMPGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

                WorkStat();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 작업지시 조회 : 현재 상태
        /// </summary>
        void searchSTATE()
        {
            if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
            {
                workOrderTMPGridView.ClearRow();
                WorkStat();
                return;
            }
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow focus = workPlanGridView.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = focus["PROD_CODE"].ToString();
            paramRow["PART_CODE"] = focus["PART_CODE"].ToString();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER13", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearchSTATE,
                   QuickException);
        }

        void QuickSearchSTATE(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //작업중인 데이터가 있다면 버튼 비활성화
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    btnStart.Enabled = false;
                    if (e.result.Tables["RSLTDT"].Rows[0]["WO_NO"].ToString() == workPlanGridView.GetFocusedValue().ToString())
                    {
                        btnFinish.Enabled = true;
                        simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                e.result.Tables["RSLTDT"].Rows[0]["WO_NO"].ToString(),
                                e.result.Tables["RSLTDT"].Rows[0]["PART_CODE"].ToString() + "-" + e.result.Tables["RSLTDT"].Rows[0]["PART_NAME"].ToString(),
                                e.result.Tables["RSLTDT"].Rows[0]["PROC_NAME"].ToString());

                        _prog = true;
                    }
                    else
                    {
                        btnFinish.Enabled = false;
                        //simpleLabelItem2.Text = "진행 중인 작업이 없습니다.";

                        _prog = false;
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 작업 시작 시, 하단 주의사항 표시
        /// </summary>
        void searchWoMsg()
        {
            if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
            {
                workOrderTMPGridView.ClearRow();
                WorkStat();
                return;
            }
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow focus = workPlanGridView.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = workPlanGridView.GetFocusedValue();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER14", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearchWoMsg,
                   QuickException);
        }

        void QuickSearchWoMsg(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    _strStdTime = e.result.Tables["RSLTDT"].Rows[0]["PLN_PROC_TIME"].ToString();
                    _strScomment = e.result.Tables["RSLTDT"].Rows[0]["CAUTION"].ToString();

                    //simpleLabelItem1.Text = "표준시간 : " + _strStdTime + "\n주의사항 : " + _strScomment;
                    simpleLabelItem1.Text = "주의사항 : " + _strScomment;
                }
                else
                {
                    _strStdTime = "";
                    _strScomment = "";

                    simpleLabelItem1.Text = " ";
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private string _strWoflag = "";


        void workOrderGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ////보류
            //DataRow focus = workOrderGridView.GetFocusedDataRow();
            //workOrderGridView.Appearance.FocusedRow.Options.UseBackColor = true;

            //if (focus != null)
            //{
            //    switch (focus["WO_FLAG"].ToString())
            //    {
            //        case "1":
            //            workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
            //            workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
            //            workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;
            //            break;

            //        case "2":

            //            workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
            //            workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
            //            workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

            //            break;

            //        case "3":

            //            workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
            //            workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
            //            workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

            //            break;

            //        case "4":

            //            workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();
            //            workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();
            //            workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

            //            break;
            //    }
            //}

            //WorkStat();
        }

        void workPlanGridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

            try
            {
                if (e.FocusedColumn.Tag != null)
                    workPlanGridView.Appearance.FocusedCell.BackColor = Color.Orange;
                else
                    workPlanGridView.Appearance.FocusedCell.BackColor = Color.Transparent;

                simpleLabelItem1.Text = " ";

                searchTMP();

                searchSTATE();

                searchWoMsg();
            }
            catch { }
        }

        void workPlanGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                simpleLabelItem1.Text = " ";

                searchTMP();

                searchSTATE();

                searchWoMsg();
            }
            catch { }
        }

       

        private void btnChangeEmp_Click(object sender, EventArgs e)
        {
            ChangeEmp frm = new ChangeEmp();

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable frmTable = frm.OutputData as DataTable;

                DataRow frmRow = frmTable.Rows[0];

                _strEmpCode = frmRow["EMP_CODE"].ToString();
                _strEmpName = frmRow["EMP_NAME"].ToString();

                _strMcCode = _strEmpCode;
                _strMcName = _strEmpName;

                EmpLabel.Text = _strEmpName;

                //acInfo.EmpConfig.UpdateMemoryEmpConfig();

                this.search(false);

                search_PLAN();
            }
        }

        

        /// <summary>
        /// 시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focus = workOrderTMPGridView.GetFocusedDataRow();

                if (focus == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("PANEL_STAT", typeof(String)); //
                paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
                paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
                paramTable.Columns.Add("OK_QTY", typeof(int)); //
                paramTable.Columns.Add("NG_QTY", typeof(int)); //

                DataTable paramTable2 = new DataTable("RQSTDT_NG");
                paramTable2.Columns.Add("MASTER_CAUSE", typeof(String)); //
                paramTable2.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                paramTable2.Columns.Add("QUANTITY", typeof(int)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["WO_NO"] = focus["WO_NO"];
                paramRow["MC_CODE"] = focus["MC_CODE"]; // _strMcCode;

                if (focus["WO_FLAG"].ToString() == "1")
                {
                    paramRow["PANEL_STAT"] = 1;
                }
                else if (focus["WO_FLAG"].ToString() == "3" || focus["WO_FLAG"].ToString() == "4")
                {
                    paramRow["PANEL_STAT"] = 3;
                }

                paramRow["MC_NM_CHECK"] = 0;
                paramRow["MULTI_START_CNT"] = 1;
                paramRow["OK_QTY"] = DBNull.Value;
                paramRow["NG_QTY"] = DBNull.Value;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS", paramSet, "RQSTDT", "RSLTDT",
                       QuickIns,
                       QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        void QuickIns(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.search(false);
                search_PLAN();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private DateTime sidle = DateTime.Now;
        private DateTime eidle = DateTime.Now;
        private string _strStopCause = "";

        #region 주석
        ////
        //private void btnActHandling_Click(object sender, EventArgs e)
        //{

        //    DataTable paramTable = new DataTable();
        //    paramTable.Columns.Add("EMP_CODE");
        //    paramTable.Columns.Add("EMP_NAME");
        //    paramTable.Columns.Add("MC_CODE");
        //    paramTable.Columns.Add("MC_NAME");

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["EMP_CODE"] = _strEmpCode;
        //    paramRow["EMP_NAME"] = _strEmpName;
        //    paramRow["MC_CODE"] = _strMcCode;
        //    paramRow["MC_NAME"] = _strMcName;

        //    paramTable.Rows.Add(paramRow);

        //    RegHandAct frm = new RegHandAct(paramTable.Rows[0]);

        //    //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //    frm.ParentControl = this;

        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {

        //        DataRow frmRow = frm.OutputData as DataRow;

        //    }
        //}

        //private void btnStop_Click(object sender, EventArgs e)
        //{
        //    DataRow focusRow = workOrderTMPGridView.GetFocusedDataRow();

        //    if (btnStop.Text.ToString() == "비가동")
        //    {
        //        WorkStop frm = new WorkStop();

        //        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //        frm.ParentControl = this;

        //        base.ChildFormAdd("NEW", frm);

        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            DataRow frmRow = frm.OutputData as DataRow;

        //            DataTable paramTable = new DataTable("RQSTDT");
        //            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //            paramTable.Columns.Add("MC_CODE", typeof(String)); //
        //            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
        //            paramTable.Columns.Add("IDLE_CODE", typeof(String)); //
        //            paramTable.Columns.Add("IDLE_TIME", typeof(String)); //
        //            paramTable.Columns.Add("IDLE_STATE", typeof(String)); //
        //            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
        //            paramTable.Columns.Add("REG_EMP", typeof(String)); //
        //            paramTable.Columns.Add("DATA_FLAG", typeof(String)); //

        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["MC_CODE"] = _strMcCode;
        //            paramRow["EMP_CODE"] = _strEmpCode;
        //            paramRow["IDLE_CODE"] = frmRow["IDLE_CAUSE"].ToString();
        //            paramRow["IDLE_TIME"] = 1;
        //            paramRow["IDLE_STATE"] = 1;
        //            paramRow["SCOMMENT"] = DBNull.Value;
        //            paramRow["REG_EMP"] = acInfo.UserID;
        //            paramRow["DATA_FLAG"] = 0;


        //            paramTable.Rows.Add(paramRow);
        //            DataSet paramSet = new DataSet();
        //            paramSet.Tables.Add(paramTable);

        //            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS3", paramSet, "RQSTDT", "RSLTDT",
        //                   QuickIns,
        //                   QuickException);

        //        }
        //    }
        //    else if (btnStop.Text.ToString() == "비가동 종료")
        //    {

        //        WorkStopEnd frm = new WorkStopEnd(_strMcCode, _strEmpCode,true);

        //        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //        frm.ParentControl = this;

        //        base.ChildFormAdd("NEW", frm);

        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {

        //            search(false);
        //            search_PLAN();

        //        }
        //    }

        //    WorkStat();
        //}

        #endregion 

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DataTable paramTable = new DataTable();
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("EMP_NAME");
            paramTable.Columns.Add("MC_CODE");
            paramTable.Columns.Add("MC_NAME");

            DataRow paramRow = paramTable.NewRow();
            paramRow["EMP_CODE"] = _strEmpCode;
            paramRow["EMP_NAME"] = _strEmpName;
            paramRow["MC_CODE"] = _strMcCode;
            paramRow["MC_NAME"] = _strMcName;

            paramTable.Rows.Add(paramRow);

            DataRow focus = workOrderTMPGridView.GetFocusedDataRow();

            RegAct frm = new RegAct(focus, paramTable.Rows[0]);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            base.ChildFormAdd("NEW", frm);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = frm.OutputData as DataRow;

                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable2.Columns.Add("WO_NO", typeof(String)); //
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("PANEL_STAT", typeof(String)); //
                paramTable2.Columns.Add("MC_NM_CHECK", typeof(String)); //
                paramTable2.Columns.Add("MULTI_START_CNT", typeof(String)); //
                paramTable2.Columns.Add("OK_QTY", typeof(int)); //
                paramTable2.Columns.Add("NG_QTY", typeof(int)); //

                DataTable paramTable3 = new DataTable("RQSTDT_NG");
                paramTable3.Columns.Add("MASTER_CAUSE", typeof(String)); //
                paramTable3.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                paramTable3.Columns.Add("QUANTITY", typeof(int)); //


                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["EMP_CODE"] = _strEmpCode;
                paramRow2["WO_NO"] = focus["WO_NO"];
                paramRow2["MC_CODE"] = focus["MC_CODE"]; //_strMcCode;

                paramRow2["PANEL_STAT"] = 2;

                paramRow2["MC_NM_CHECK"] = 0;
                paramRow2["MULTI_START_CNT"] = 1;
                paramRow2["OK_QTY"] = frmRow["OK_QTY"];
                paramRow2["NG_QTY"] = frmRow["NG_QTY"];

                if (frmRow["MASTER_CAUSE"].ToString() != "")
                {
                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["MASTER_CAUSE"] = frmRow["MASTER_CAUSE"];
                    paramRow3["DETAIL_CAUSE"] = frmRow["DETAIL_CAUSE"];
                    paramRow3["QUANTITY"] = frmRow["NG_QTY"];
                    paramTable3.Rows.Add(paramRow3);
                }

                paramTable2.Rows.Add(paramRow2);
                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable2);
                paramSet2.Tables.Add(paramTable3);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS", paramSet2, "RQSTDT,RQSTDT_NG", "RSLTDT",
                       QuickIns,
                       QuickException);


                WorkStat();
            }
        }

        //상단 그리드 조회
        //선택된 작업자의 확정,진행, 금일 완료된 작업--확인
        void search(bool bAll)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("W_DATE", typeof(String)); //일자//주차

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = _strEmpCode;
                if (!bAll)
                    paramRow["W_DATE"] = _strDay;//_strWeek;


                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //현재 선택된 작업자의 확정,진행,중지인 작업지시
                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER11", paramSet, "RQSTDT", "RSLTDT,RSLTDT_ACT",
                //       QuickSearch,
                //       QuickException);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "POP20A_SER11", paramSet, "RQSTDT", "RSLTDT,RSLTDT_ACT");

                workOrderGridView.GridControl.DataSource = dsResult.Tables["RSLTDT"];

                //workOrderGridView.BestFitColumns();

                workOrderGridView.SetOldFocusRowHandle(true);

                if (dsResult.Tables["RSLTDT_ACT"].Rows.Count > 0)
                {
                    simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["WO_NO"].ToString(),
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["PART_CODE"].ToString() + "-" + dsResult.Tables["RSLTDT_ACT"].Rows[0]["PART_NAME"].ToString(),
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["PROC_NAME"].ToString());

                }


            }
            catch (Exception ex)
            {

            }
            

            
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                workOrderGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //workOrderGridView.BestFitColumns();

                workOrderGridView.SetOldFocusRowHandle(true);

                if (e.result.Tables["RSLTDT_ACT"].Rows.Count > 0)
                {
                    simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                e.result.Tables["RSLTDT_ACT"].Rows[0]["WO_NO"].ToString(),
                                e.result.Tables["RSLTDT_ACT"].Rows[0]["PART_CODE"].ToString() + "-" + e.result.Tables["RSLTDT_ACT"].Rows[0]["PART_NAME"].ToString(),
                                e.result.Tables["RSLTDT_ACT"].Rows[0]["PROC_NAME"].ToString());
 
                }

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

        /// <summary>
        /// 작업자별 조립 계획 데이터 조회
        /// </summary>
        void search_PLAN()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            //paramTable.Columns.Add("W_DATE", typeof(String)); //일자//주차

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = _strEmpCode;
            //if (!bAll)
            //    paramRow["W_DATE"] = _strDay;//_strWeek;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER12", paramSet, "RQSTDT", "RSLTDT,RSLTDT_CNT",
                   QuickSearchPLN,
                   QuickException);
        }
        //하단 그리드 설정
        void QuickSearchPLN(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                workPlanGridView.ClearColumns();
                workPlanGridView.ClearRow();

                workPlanGridView.GridType = acGridView.emGridType.SEARCH;

                workPlanGridView.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("CVND_NAME", "수주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("MAT_SPEC1", "제품\n규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("PART_QTY", "계획\n수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                workPlanGridView.AddTextEdit("ITEM_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("PROD_CODE", "제품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                
                workPlanGridView.KeyColumn = new string[] { "PROD_CODE", "PART_CODE" };

                for (int i = 1; i < e.result.Tables["RSLTDT_CNT"].Rows[0]["PROC_MAX"].toInt() + 1; i++)
                {
                    workPlanGridView.AddLookUpEdit(i.ToString(), i.ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, e.result.Tables["RSLTDT"]);
                    workPlanGridView.Columns[i.ToString()].Tag = "P";
                }

                workPlanGridView.AddTextEdit("colATTACH", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //workPlanGridView.AddTextEdit("LINK_KEY", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                workPlanGridView.AddTextEdit("ATT_QTY", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                workPlanGridView.GridControl.DataSource = e.result.Tables["RSLTDT_DATA"];

                workPlanGridView.RowHeight = 40;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        #region  버튼상태설정

        private void WorkStat()
        {
            try
            {
                if (_strMcCode != "")
                {
          

                    #region 비가동 관련
                    //DataTable paramTable = new DataTable("RQSTDT");
                    //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    //paramTable.Columns.Add("MC_CODE", typeof(String)); //
                    //paramTable.Columns.Add("IDLE_STATE", typeof(String)); //


                    //DataRow paramRow = paramTable.NewRow();
                    //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    //paramRow["MC_CODE"] = _strMcCode;
                    //paramRow["IDLE_STATE"] = 1;

                    //paramTable.Rows.Add(paramRow);
                    //DataSet paramSet = new DataSet();
                    //paramSet.Tables.Add(paramTable);

                    //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER7", paramSet, "RQSTDT", "RSLTDT");

                    //DataTable resultDT = resultSet.Tables["RSLTDT"];

                    //if (resultDT.Rows.Count != 0)
                    //{
                    //    _strIdleName = resultDT.Rows[0]["IDLE_CODE"].ToString();
                    //    _strIdleStartTime = resultDT.Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm");

                    //    btnStop.Text = "비가동 종료";

                    //    simpleLabelItem2.Text = "비가동";
                    //    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Violet;

                    //    btnStart.Enabled = false;
                    //    btnFinish.Enabled = false;
                    //    //btnChangeEmp.Enabled = false;
                    //    btnStop.Enabled = true;

                    //    idleState = true;
                    //}
                    //else
                    //{
                    //    btnChangeEmp.Enabled = true;

                    //    idleState = false;

                    //    DataView dv = workOrderTMPGridView.GetDataView("WO_FLAG = 2");

                    //    if (dv.Count != 0)
                    //    {
                    //        btnStop.Enabled = false;
                    //        btnStop.Text = "비가동";
                    //        simpleLabelItem2.Text = "작업 중";
                    //        simpleLabelItem2.AppearanceItemCaption.BackColor = Color.PowderBlue;

                    //    }
                    //    else
                    //    {
                    //        btnStop.Enabled = true;
                    //        btnStop.Text = "비가동";
                    //        //simpleLabelItem2.Text = "진행중인 공정이 없습니다.";
                    //        //simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Coral;
                    //    }

                    #endregion

                    DataRow focus = workOrderTMPGridView.GetFocusedDataRow();

                    if (focus != null)
                    {
                        if (focus["WO_FLAG"].ToString() == "1")
                        {
                            btnStart.Enabled = true;
                            btnFinish.Enabled = false;
                        }
                        else if (focus["WO_FLAG"].ToString() == "2")
                        {
                            btnStart.Enabled = false;
                            btnFinish.Enabled = true;
                        }
                        else if (focus["WO_FLAG"].ToString() == "3")
                        {
                            btnStart.Enabled = true;
                            btnFinish.Enabled = false;
                        }
                        else if (focus["WO_FLAG"].ToString() == "4")
                        {
                            btnStart.Enabled = true;
                            btnFinish.Enabled = false;
                        }

                    }
                    else
                    {
                        btnStart.Enabled = false;
                        btnFinish.Enabled = false;
                    }
                }
                else
                {
                    btnChangeEmp.Enabled = true;
                    btnStart.Enabled = false;
                    btnFinish.Enabled = false;
                    //btnStop.Enabled = false;
                  
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        #endregion

        #region 컨트롤 설정
        public static Control[] formcount(Control controlcount)
        {
            List<Control> list = new List<Control>();
            Queue<Control.ControlCollection> que = new Queue<Control.ControlCollection>();

            que.Enqueue(controlcount.Controls);

            while (que.Count > 0)
            {

                //que에 들어있는 컨트롤을 controls에 넣으면서 큐에서 지워준다. 
                Control.ControlCollection controls = (Control.ControlCollection)que.Dequeue();

                //controls가 비여있다면 while문을 벗어난다.

                if (controls == null || controls.Count == 0)
                {
                    continue;
                }



                foreach (Control control in controls)
                {
                    list.Add(control);
                    que.Enqueue(control.Controls);  //control 하위에 Control들이 있다면 que에 다시 추가한다
                }

            }
            return list.ToArray();
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnAll.Text == "전체\n작업")    //당일 작업분 조회
            {
                //당일 작업지시 조회
                this.search(false);
                

            }
            else
            {

                //전체 작업지시 조회
                this.search(true);
                
            }
            search_PLAN();
        }



        public static Point GetCenterLocation(Rectangle parentRect, Rectangle childRect)
        {
            int x = parentRect.X + ((parentRect.Width / 2) - (childRect.Width / 2));

            int y = parentRect.Y + ((parentRect.Height / 2) - (childRect.Height / 2));

            return new Point(x, y);
        }


        public static void SetPopGridFont(acGridView grid, acTreeList tree)
        {
            int fontSz = 2;

            if (grid != null)
            {
                grid.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                grid.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
            }
            if (tree != null)
            {
                tree.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
            }
        }

        private void btnActLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
                {
                    acMessageBox.Show("선택된 품목이 없습니다.", "불량내역 보기", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataRow focusRow = workPlanGridView.GetFocusedDataRow();

                DataTable dtParam = new DataTable();
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("PART_NAME", typeof(String));
                dtParam.Columns.Add("PROC_CODE", typeof(String));
                dtParam.Columns.Add("PROC_NAME", typeof(String));

                DataRow dr = dtParam.NewRow();
                dr["PART_CODE"] = focusRow["PART_CODE"];
                dr["PART_NAME"] = focusRow["PART_NAME"];
                //dr["PROC_CODE"] = focusRow["PROC_CODE"];
                //dr["PROC_NAME"] = focusRow["PROC_NAME"];
                dtParam.Rows.Add(dr);

                NgLog frm = new NgLog(dr, "AS");

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        
        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                //조립추가
                DataRow focus = workOrderGridView.GetFocusedDataRow();

                if (focus == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focus["PROD_CODE"];
                paramRow["PART_CODE"] = focus["PART_CODE"];
                paramRow["REG_EMP"] = _strEmpCode;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS5", paramSet, "RQSTDT", "RSLTDT",
                       QuickInsPLN,
                       QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        void QuickInsPLN(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                btnSearch_Click(null, null);

                //search_PLAN();

                //search(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnRMV_Click(object sender, EventArgs e)
        {
            try
            {
                //조립제거
                DataRow focus = workPlanGridView.GetFocusedDataRow();

                if (focus == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focus["PROD_CODE"];
                paramRow["PART_CODE"] = focus["PART_CODE"];
                paramRow["REG_EMP"] = _strEmpCode;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_DEL", paramSet, "RQSTDT", "RSLTDT",
                       QuickInsPLN,
                       QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            if (acMessageBox.Show(acInfo.Resource.GetString("정말 종료하시겠습니까?", "XPCDAJOT"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (btnAll.Text == "전체\n작업")
            {
                //전체 작업지시 조회
                this.search(true);
                btnAll.Text = "당일\n작업";
            }
            else
            {
                //당일 작업지시 조회
                this.search(false);
                btnAll.Text = "전체\n작업";
            }
                
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //자주검사
            try
            {
                if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
                {
                    acMessageBox.Show("선택된 품목이 없습니다.", "자주검사", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!workPlanGridView.FocusedColumn.Tag.Equals("P"))
                {
                    acMessageBox.Show("공정을 선택하세요.", "자주검사", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                    

                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("EMP_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["EMP_NAME"] = _strEmpName;
                paramTable.Rows.Add(paramRow);

                DataRow planrow = workPlanGridView.GetFocusedDataRow();

                DataTable dtParam = new DataTable();
                dtParam.Columns.Add("WO_NO", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("PART_QTY", typeof(Int32));

                DataRow dr = dtParam.NewRow();
                dr["WO_NO"] = workPlanGridView.GetFocusedValue();
                dr["PART_CODE"] = planrow["PART_CODE"];
                dr["PART_QTY"] = planrow["PART_QTY"];

                if (dr["PART_QTY"].toInt() > 0)
                {
                    RegCheck frm = new RegCheck(dr, paramTable.Rows[0]);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.ShowDialog();
                }
                else
                {
                    base.ChildFormFocus("NEW");
                    acMessageBox.Show(this, "계획 수량이 부족합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
            catch { }
        }

    }
}
