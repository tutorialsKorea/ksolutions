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
using System.Linq;
using System.IO;

namespace POP
{
    public sealed partial class POP20D_M0A : BaseMenu
    {


        public override void BarCodeScanInput(string barcode)
        {
        }



        public POP20D_M0A()
        {
            InitializeComponent();
        }

        Color _WAIT;
        Color _RUN;
        Color _PAUSE;
        Color _FINISH;

        private bool _isAll = false;

        private DataTable _ProdPartProcTable;

        private string _strMcCode = "";
        private string _strMcName = "";
        private string _strEmpCode = acInfo.UserID;
        private string _strEmpName = acInfo.UserName;
        private string _strIdleName = "";
        private string _strIdleStartTime = "";

        private string _strStdTime = "";
        private string _strScomment = "";

        private bool idleState = false;

        private DateTime nowDate = DateTime.Today;
        
        private string _strDay = "";
        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public override void MenuInit()
        {
            workOrderGridView.GridType = acGridView.emGridType.SEARCH;

            workOrderGridView.OptionsView.ShowIndicator = true;
            workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

            workOrderGridView.AddTextEdit("ITEM_CODE", "수주\n코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("DRAW_NO", "도면\n번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_CODE", "품목\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("MAT_SPEC1", "제품\n규격", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PLN_QTY", "계획\n수량", "NAFTT723", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            workOrderGridView.AddLookUpProc("PROC_CODE", "작업내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            workOrderGridView.AddTextEdit("ASSY_TIME", "표준\n시간[분]", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            workOrderGridView.AddTextEdit("JOB_TIME", "진행\n시간[분]", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F1);
            workOrderGridView.AddTextEdit("DAY", "작업일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("IS_PARTPROC_ASSY", "작업\n표준", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            workOrderGridView.AddTextEdit("CVND_CODE", "수주처\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PROD_CODE", "제품\n코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PART_CODE", "품목\n코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            workOrderGridView.KeyColumn = new string[] { "PROD_CODE", "PART_CODE", "PROC_CODE" };
            workOrderGridView.RowHeight = 40;


            acGridView1.GridType = acGridView.emGridType.COMMON_CONTROL;

            acGridView1.AddTextEdit("PART_CODE", "품번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면\n번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC1", "제품\n규격", "42545", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PRG_CODE", "공정 그룹 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PRG_NAME", "공정 그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
            //acGridView1.AddCheckEdit("SEL", "선택", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddTextEdit("PROC_CODE", "공정 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
            //acGridView1.AddMemoEdit("PROC_CONTENTS", "조립 내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
            //acGridView1.AddMemoEdit("PROC_REMARK", "조립 주의사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
            //acGridView1.AddMemoEdit("INS_METHOD", "검사 방법", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
            //acGridView1.AddTextEdit("ASSY_TIME", "조립 시간", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddTextEdit("IMPORTANCE", "비중", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NUMERIC);

            //acGridView1.Columns["PRG_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            //acGridView1.Columns["IMPORTANCE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;


            //acBandGridView1.GridType = acBandGridView.emGridType.COMMON_CONTROL;

            acBandGridView1.AddTextEdit("ITEM_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("ITEM_NAME", "프로젝트", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("CVND_NAME", "수주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S016");
            acBandGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddLookUpEdit("PROD_STATE", "제품상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S025");
            acBandGridView1.AddDateEdit("ORD_DATE", "수주일", "40902", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emDateMask.SHORT_DATE);
            acBandGridView1.AddDateEdit("DUE_DATE", "납기일", "40111", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emDateMask.SHORT_DATE);
            acBandGridView1.AddTextEdit("SALECONFM_DATE", "매출 확정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("MAT_SPEC1", "제품사양", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
            acBandGridView1.AddTextEdit("PROD_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.TIME);
            acBandGridView1.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M003");
            acBandGridView1.AddTextEdit("PROGRESS", "진척률(%)", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.QTY);
            #region 조립공정

            DataSet paramDS = new DataSet();

            DataTable paramTable = paramDS.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);


            if (BizRun.QBizRun.ExecuteService(this, "PLN17A_SER1", paramDS, "RQSTDT", "RSLTDT") is DataSet resultDS)
            {
                foreach (DataRow row in resultDS.Tables["RSLTDT"].Rows)
                {
                    string captionName = "";
                    foreach (char c in row["PROC_NAME"].ToString())
                    {
                        captionName += c + Environment.NewLine;
                    }
                    acBandGridView1.AddMemoEdit(row["PROC_CODE"].ToString(), captionName, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true,false, row["PRG_NAME"].ToString());
                }
            }
            #endregion

            acBandGridView1.ColumnPanelRowHeight = 75;

            //_strWeek = GetJuCha(nowDate);
            _strDay = nowDate.toDateString("yyyyMMdd");

            TimeLabel.Text = nowDate.toDateString("yyyy-MM-dd");//sDate.toDateString("yy/MM/dd") + " ∼ " + eDate.toDateString("yy/MM/dd");

            _strMcCode = _strEmpCode;
            _strMcName = _strEmpName;
            
            EmpLabel.Text = _strEmpName;


            workOrderGridView.CustomDrawCell += WorkOrderGridView_CustomDrawCell;
            workOrderGridView.FocusedRowChanged += workOrderGridView_FocusedRowChanged;
            
            acBandGridView1.CustomDrawCell += AcBandGridView1_CustomDrawCell;

            acGridView1.CellMerge += AcGridView1_CellMerge;

            //workOrderGridView.MouseDown += workOrderGridView_MouseDown;

            //workPlanGridView.FocusedColumnChanged += workPlanGridView_FocusedColumnChanged;
            //workPlanGridView.FocusedRowChanged += workPlanGridView_FocusedRowChanged;

            //workPlanGridView.MouseUp += workPlanGridView_MouseUp;

            #region 컨트롤 설정
            SetPopGridFont(workOrderGridView, null);

            //SetPopGridFont(workPlanGridView, null);

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            int extSz = 3;

            TimeLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Regular, GraphicsUnit.Point);

            EmpLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Regular, GraphicsUnit.Point);

            simpleLabelItem2.AppearanceItemCaption.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
                    FontStyle.Bold, GraphicsUnit.Point);

            lblTotalProgress.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + extSz,
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


        private void AcBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column is acBandedGridColumn bCol)
                {
                    e.Appearance.ForeColor = Color.Black;
                    if (!bCol.OwnerBand.Caption.Equals(bCol.Caption))
                    {
                        DataRow thisRow = acBandGridView1.GetDataRow(e.RowHandle);

                        DataRow partProc = _ProdPartProcTable.Select("PROD_CODE='" + thisRow["PROD_CODE"]
                                                                + "' AND PART_CODE = '" + thisRow["PART_CODE"]
                                                                + "' AND PROC_CODE = '" + bCol.FieldName + "'").FirstOrDefault();

                        if (partProc == null)
                            return;

                        switch (partProc["WO_FLAG"])
                        {
                            case "0":
                                e.Appearance.BackColor = Color.LightGray;   // Color.YellowGreen;
                                break;
                            case "1":
                                e.Appearance.BackColor = _WAIT;//Color.LightGray;
                                break;
                            case "2":
                                e.Appearance.BackColor = _RUN;//Color.SkyBlue;
                                break;
                            case "3":
                                e.Appearance.BackColor = _PAUSE; //Color.Purple;
                                break;
                            case "4":
                                e.Appearance.BackColor = _FINISH;   //Color.Orange;
                                break;
                            case "03":
                                e.Appearance.BackColor = Color.LightGray;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AcGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (sender is acGridView view
                    && e.Column.FieldName == "PRG_NAME")//Name 컬럼만 Merge
                {
                    var dr1 = view.GetDataRow(e.RowHandle1); //위에 행 정보
                    var dr2 = view.GetDataRow(e.RowHandle2); //아래 행 정보

                    e.Merge = dr1["PRG_CODE"].ToString().Equals(dr2["PRG_CODE"].ToString());
                }
                else
                    e.Merge = false;

                e.Handled = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void WorkOrderGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if(workOrderGridView.GetDataRow(e.RowHandle) is DataRow row)
                {
                    e.Appearance.ForeColor = Color.Black;
                    switch (row["WO_FLAG"])
                    {
                        case "0":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        case "1":
                            e.Appearance.BackColor = _WAIT;//Color.LightGray;
                            break;
                        case "2":
                            e.Appearance.BackColor = _RUN;//Color.SkyBlue;
                            break;
                        case "3":
                            e.Appearance.BackColor = _PAUSE; //Color.Purple;
                            break;
                        case "4":
                            e.Appearance.BackColor = _FINISH;   //Color.Orange;
                            break;
                        case "03":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        //void workPlanGridView_MouseUp(object sender, MouseEventArgs e)
        //{
        //    try
        //    {

        //        DataRow focus = workPlanGridView.GetFocusedDataRow();

        //        GridHitInfo hitInfo = workPlanGridView.CalcHitInfo(e.Location);

        //        if (hitInfo.HitTest == GridHitTest.RowCell)
        //        {
        //            if (hitInfo.Column.FieldName == "colATTACH" && focus["ATT_QTY"].toInt() > 0)
        //            {
        //                DataTable dtParam = new DataTable();
        //                dtParam.Columns.Add("WO_NO", typeof(String));

        //                DataRow dr = dtParam.NewRow();

        //                //focus["PART_CODE"] = workOrderGridView.GetRowCellValue(hitInfo.RowHandle, workOrderGridView.Columns["PART_CODE"]);

        //                AttachFileList frm = new AttachFileList(workPlanGridView.GetRowCellValue(hitInfo.RowHandle, workPlanGridView.Columns["PART_CODE"]));

        //                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //                frm.ParentControl = this;

        //                base.ChildFormAdd("NEW", frm);

        //                frm.ShowDialog();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}


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
            acMemoEdit1.Properties.Appearance.Font = new Font(acMemoEdit1.Properties.Appearance.Font.FontFamily, 11);
            acMemoEdit2.Properties.Appearance.Font = new Font(acMemoEdit1.Properties.Appearance.Font.FontFamily, 11);
            acMemoEdit3.Properties.Appearance.Font = new Font(acMemoEdit1.Properties.Appearance.Font.FontFamily, 11);
            acMemoEdit1.Properties.Appearance.Options.UseFont = true;
            acMemoEdit2.Properties.Appearance.Options.UseFont = true;
            acMemoEdit3.Properties.Appearance.Options.UseFont = true;

            acMemoEdit1.Properties.AppearanceFocused.Font = new Font(acMemoEdit1.Properties.AppearanceFocused.Font.FontFamily, 11);
            acMemoEdit2.Properties.AppearanceFocused.Font = new Font(acMemoEdit1.Properties.AppearanceFocused.Font.FontFamily, 11);
            acMemoEdit3.Properties.AppearanceFocused.Font = new Font(acMemoEdit1.Properties.AppearanceFocused.Font.FontFamily, 11);
            acMemoEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            acMemoEdit2.Properties.AppearanceFocused.Options.UseFont = true;
            acMemoEdit3.Properties.AppearanceFocused.Options.UseFont = true;

            acMemoEdit1.Properties.AppearanceReadOnly.Font = new Font(acMemoEdit1.Properties.AppearanceReadOnly.Font.FontFamily, 11);
            acMemoEdit2.Properties.AppearanceReadOnly.Font = new Font(acMemoEdit1.Properties.AppearanceReadOnly.Font.FontFamily, 11);
            acMemoEdit3.Properties.AppearanceReadOnly.Font = new Font(acMemoEdit1.Properties.AppearanceReadOnly.Font.FontFamily, 11);
            acMemoEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            acMemoEdit2.Properties.AppearanceReadOnly.Options.UseFont = true;
            acMemoEdit3.Properties.AppearanceReadOnly.Options.UseFont = true;

            //상단 그리드 조회
            this.search(_isAll);

            //현재 작업 그리드 조회
            //search_PLAN();

            base.OnLoad(e);
        }

        /// <summary>
        /// 작업지시 임시 그리드
        /// 버튼 작업을 위해 필요함.
        /// </summary>
        //void searchTMP()
        //{
        //    if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
        //    {
        //        workOrderTMPGridView.ClearRow();
        //        WorkStat();
        //        return;
        //    }

        //    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("WO_NO", typeof(String)); //


        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow["WO_NO"] = workPlanGridView.GetFocusedValue();

        //    paramTable.Rows.Add(paramRow);

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER3", paramSet, "RQSTDT", "RSLTDT",
        //           QuickSearchTMP,
        //           QuickException);
        //}

        //void QuickSearchTMP(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {

        //        workOrderTMPGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

        //        WorkStat();

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}

        /// <summary>
        /// 작업지시 조회 : 현재 상태
        /// </summary>
        void searchSTATE()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow focus = workOrderGridView.GetFocusedDataRow();

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
                    DataRow focus = workOrderGridView.GetFocusedDataRow();

                    btnStart.Enabled = false;
                    if (e.result.Tables["RSLTDT"].Rows[0]["WO_NO"].ToString().Equals(focus["WO_NO"]))
                    {
                        btnFinish.Enabled = true;
                        simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                e.result.Tables["RSLTDT"].Rows[0]["WO_NO"].ToString(),
                                e.result.Tables["RSLTDT"].Rows[0]["PART_CODE"].ToString() + "-" + e.result.Tables["RSLTDT"].Rows[0]["PART_NAME"].ToString(),
                                e.result.Tables["RSLTDT"].Rows[0]["PROC_NAME"].ToString());

                    }
                    else
                    {
                        btnFinish.Enabled = false;
                        //simpleLabelItem2.Text = "진행 중인 작업이 없습니다.";

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
            //if (workPlanGridView.GetFocusedValue() == null || workPlanGridView.GetFocusedValue().ToString() == "")
            //{
            //    workOrderTMPGridView.ClearRow();
            //    WorkStat();
            //    return;
            //}
            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            //DataRow focus = workPlanGridView.GetFocusedDataRow();

            DataRow focus = workOrderGridView.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = focus["WO_NO"];

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
            try
            {
                WorkStat();

                DataRow focusRow = workOrderGridView.GetFocusedDataRow();

                if (focusRow == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"].ToString(); ;
                paramRow["PART_CODE"] = focusRow["PART_CODE"].ToString(); ;
                paramRow["PROC_CODE"] = focusRow["PROC_CODE"].ToString(); ;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER19", paramSet, "RQSTDT", "RSLTDT,RSLTDT_PROC,RSLTDT_PART,RSLTDT_BOM,RSLTDT_BOM_PROC,RSLTDT_PRG_PROC,RSLTDT_ASSY_PROC",
                            QuickSearch2,
                            QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                #region 조립 공정 정보 (왼쪽 아래)
                DataTable procDt = e.result.Tables["RSLTDT_PRG_PROC"].AsEnumerable()
                                                             .GroupJoin(e.result.Tables["RSLTDT_ASSY_PROC"].AsEnumerable()
                                                                      , prg => prg["PROC_CODE"]
                                                                      , assy => assy["PROC_CODE"]
                                                                      , (prg, assy) => new
                                                                      {
                                                                          PRG = prg,
                                                                          ASSY = assy
                                                                      })
                                                            .SelectMany(
                                                                r1 => r1.ASSY.DefaultIfEmpty(),
                                                                (prg, assy) =>
                                                                    new
                                                                    {
                                                                        PLT_CODE = prg.PRG["PLT_CODE"]
                                                                        , PART_CODE = assy?["PART_CODE"]
                                                                        //, PART_NAME = assy?["PART_NAME"]
                                                                        , SEL = e.result.Tables["RSLTDT_PROC"]
                                                                                .Select("PLT_CODE='"+ prg.PRG["PLT_CODE"]
                                                                                    //+ "' AND PART_CODE='" + assy?["PART_CODE"]
                                                                                    + "' AND PROC_CODE='" + prg.PRG["PROC_CODE"]+"'").Length==0?"0":"1"
                                                                        , PRG_CODE = prg.PRG["PRG_CODE"]
                                                                        , PRG_NAME = prg.PRG["PRG_NAME"]
                                                                        , PROC_CODE = prg.PRG["PROC_CODE"]
                                                                        , PROC_NAME = prg.PRG["PROC_NAME"]
                                                                        , PROC_CONTENTS = assy?["PROC_CONTENTS"]
                                                                        , PROC_REMARK = assy?["PROC_REMARK"]
                                                                        , INS_METHOD = assy?["INS_METHOD"]
                                                                        , ASSY_TIME = assy?["ASSY_TIME"]
                                                                    }
                                                                ).LINQToDataTable();
                foreach(DataRow row in procDt.Rows)
                {
                    acLayoutControl5.DataBind(row, false);
                    acLayoutControl6.DataBind(row, false);
                    acLayoutControl7.DataBind(row, false);
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_PROD"];

                #endregion

                #region 조립 공정별 진행 정보
                _ProdPartProcTable = e.result.Tables["RSLTDT_PROC2"];

                e.result.Tables["RSLTDT"].Columns.Add("IS_SET", typeof(Int32));

                foreach (DataRow masterRow in e.result.Tables["RSLTDT"].Rows)
                {
                    foreach (DataRow procRow in _ProdPartProcTable.AsEnumerable()
                                                                    .Where(w => w["PROD_CODE"].Equals(masterRow["PROD_CODE"])
                                                                        && w["PART_CODE"].Equals(masterRow["PART_CODE"])))
                    {
                        if (!e.result.Tables["RSLTDT"].Columns.Contains(procRow["PROC_CODE"].ToString()))
                        {
                            e.result.Tables["RSLTDT"].Columns.Add(procRow["PROC_CODE"].ToString());
                        }

                        switch (procRow["WO_FLAG"])
                        {
                            case "1":
                                masterRow[procRow["PROC_CODE"].ToString()] = procRow["PLN_END"].toDateString("MM\n/dd");
                                break;
                            case "2":
                                masterRow[procRow["PROC_CODE"].ToString()] = (procRow["PART_QTY"].toInt() == 0 ?
                                                                                "0%" : ((procRow["ACT_QTY"].toDecimal() / procRow["PART_QTY"].toDecimal()) * 100).toInt() + "%");
                                break;
                            case "3":
                                masterRow[procRow["PROC_CODE"].ToString()] = (procRow["PART_QTY"].toInt() == 0 ?
                                                                                "0%" : ((procRow["ACT_QTY"].toDecimal() / procRow["PART_QTY"].toDecimal()) * 100).toInt() + "%");
                                break;
                            case "4":
                                masterRow[procRow["PROC_CODE"].ToString()] = procRow["ACT_END"].toDateString("MM\n/dd");
                                break;
                        }

                        masterRow["IS_SET"] = 1;
                    }
                }

                if (e.result.Tables["RSLTDT"].Select("IS_SET = 1") is DataRow[] drs)
                {
                    acBandGridView1.GridControl.DataSource = drs.CopyToDataTable();
                    acBandGridView1.ExpandAllGroups();

                    acBandGridView1.BestFitColumns();
                }
                else
                {
                    acBandGridView1.ClearRow();
                }
                #endregion

                #region PDF 뷰어 (오른쪽 아래)
                foreach (DataRow filerow in e.result.Tables["RSLTDT_PART"].Rows)
                {
                    if (filerow["ASSY_FILE_CONTENT"] is byte[] bytes)
                    {
                        Stream stream = new MemoryStream(bytes);
                        pdfViewer1.LoadDocument(stream);

                        break;
                    }
                }
                #endregion


                if (workOrderGridView.GridControl.DataSource is DataTable rsltDT)
                {
                    DataRow focusedRow = workOrderGridView.GetFocusedDataRow();
                    var times = rsltDT.AsEnumerable()
                                            .Where(w => w["PROD_CODE"].ToString().Equals(focusedRow["PROD_CODE"])
                                                    && w["PART_CODE"].ToString().Equals(focusedRow["PART_CODE"]))
                                            .GroupBy(g => new { PROD_CODE = g["PROD_CODE"], PART_CODE = g["PART_CODE"] })
                                            .Select(r => new
                                            {
                                                PROD_CODE = r.Key.PROD_CODE
                                                , PART_CODE = r.Key.PART_CODE
                                                , JOB_TIME = r.Sum(s => s["JOB_TIME"].toDecimal())
                                                , ASSY_TIME = r.Sum(s => s["ASSY_TIME"].toDecimal())
                                            });
                                                        //.Sum(s => s["ASSY_TIME"].toDecimal());
                    foreach(var time in times)
                    {
                        if (time.ASSY_TIME > 0)
                        {
                            //decimal jobTime = e.result.Tables["RSLTDT_PROC2"].AsEnumerable()
                            //                                .Sum(s => s["JOB_TIME"].toDecimal());
                            lblTotalProgress.Text = "현재 목표 달성율 : " + Environment.NewLine
                                                    + (Math.Round((time.JOB_TIME / time.ASSY_TIME), 1) * 100) + "%";
                        }
                        else
                        {
                            //없으면 초기화 한다.
                            lblTotalProgress.Text = "현재 목표 달성율 : 0%";
                        }
                    }
                }

                searchSTATE();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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

                this.search(_isAll);
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
                DataRow focus = workOrderGridView.GetFocusedDataRow();

                if (focus == null) return;

                string emp_code = _strEmpCode;

                if(emp_code.isNullOrEmpty())
                {
                    acMessageBox.Show(this, "현재 작업자가 선택되지 않았습니다. 작업자를 선택해 주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    ChangeEmp frm = new ChangeEmp();
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;

                    if (frm.ShowDialog() == DialogResult.OK)
                    { 
                        DataTable frmTable = frm.OutputData as DataTable;
                        DataRow frmRow = frmTable.Rows[0];
                        emp_code = frmRow["EMP_CODE"].ToString();
                    }
                }

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
                paramRow["EMP_CODE"] = emp_code;
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
                this.search(_isAll);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


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

            DataRow focus = workOrderGridView.GetFocusedDataRow();

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

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "POP20A_SER11_1", paramSet, "RQSTDT", "RSLTDT,RSLTDT_ACT");

                workOrderGridView.GridControl.DataSource = dsResult.Tables["RSLTDT"];

                workOrderGridView.SetOldFocusRowHandle(true);

                if (dsResult.Tables["RSLTDT_ACT"].Rows.Count > 0)
                {
                    simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["WO_NO"].ToString(),
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["PART_CODE"].ToString() + "-" + dsResult.Tables["RSLTDT_ACT"].Rows[0]["PART_NAME"].ToString(),
                                dsResult.Tables["RSLTDT_ACT"].Rows[0]["PROC_NAME"].ToString());
                }

                //workOrderGridView.BestFitColumns();
            }
            catch (Exception ex)
            {

            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        #region  버튼상태설정

        private void WorkStat()
        {
            try
            {
                if (_strMcCode != "")
                {
                    DataRow focus = workOrderGridView.GetFocusedDataRow();

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

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable.Columns.Add("IDLE_STATE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = _strMcCode;
                    paramRow["IDLE_STATE"] = 1;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    //비가동 정보 조회
                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER7", paramSet, "RQSTDT", "RSLTDT");

                    DataTable resultDT = resultSet.Tables["RSLTDT"];

                    if (resultDT.Rows.Count != 0)
                    {
                        //wo_no가 있으면 작업중단
                        string pause_wo_no = resultDT.Rows[0]["WO_NO"].ToString();

                        if (pause_wo_no == "")
                        {
                            //==============비가동 중=============================

                            _strIdleStartTime = resultDT.Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm");

                            simpleLabelItem2.Text = "비가동";
                            simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Violet;
                        }
                        else
                        {
                            //==============작업 중단 =============================

                            _strIdleStartTime = resultDT.Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm");

                            simpleLabelItem2.Text = "작업 중단";
                            simpleLabelItem2.AppearanceItemCaption.BackColor = Color.IndianRed;


                        }
                        idleState = true;

                        TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");
                        //==============비가동 중=============================
                    }
                    else
                    {
                        idleState = false;

                        DataView dv = workOrderGridView.GetDataView("WO_FLAG = 2");

                        if (dv.Count != 0)
                        {
                            //simpleLabelItem2.Text = "가공 중";
                            simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
                                dv[0]["WO_NO"].ToString(),
                                dv[0]["PART_CODE"].ToString() + "-" + dv[0]["PART_NAME"].ToString(),
                                dv[0]["PROC_NAME"].ToString());
                            simpleLabelItem2.AppearanceItemCaption.BackColor = Color.PowderBlue;
                            //=====================진행 중인 작업================================
                        }
                        else
                        {
                            simpleLabelItem2.Text = "진행중인 공정이 없습니다.";
                            simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Coral;
                        }

                        if (focus != null)
                        {
                            //POP20A_SER16
                            DataTable dtParam = new DataTable("RQSTDT");
                            dtParam.Columns.Add("PLT_CODE", typeof(String)); //
                            dtParam.Columns.Add("WO_NO", typeof(String)); //

                            DataRow drParam = dtParam.NewRow();
                            drParam["PLT_CODE"] = acInfo.PLT_CODE;
                            drParam["WO_NO"] = focus["WO_NO"];

                            dtParam.Rows.Add(drParam);
                            DataSet dsParam = new DataSet();
                            dsParam.Tables.Add(dtParam);

                            DataSet dsAct = BizRun.QBizRun.ExecuteService(this, "POP20A_SER16", dsParam, "RQSTDT", "RSLTDT");

                            int panel_stat = 0;

                            if (dsAct.Tables["RSLTDT"].Rows.Count > 0)
                            {
                                panel_stat = dsAct.Tables["RSLTDT"].Rows[0]["PANEL_STAT"].toInt();
                            }
                        }
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
                this.search(_isAll);
            }
            else
            {
                //전체 작업지시 조회
                this.search(_isAll);
            }
            //search_PLAN();
        }

        public static void SetPopGridFont(acGridView grid, acTreeList tree)
        {
            int fontSz = 2;

            if (grid != null)
            {
                grid.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                //grid.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                grid.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
            }
            if (tree != null)
            {
                tree.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                //tree.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                tree.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + fontSz);
            }
        }

        private void btnActLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusRow = workOrderGridView.GetFocusedDataRow();

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
                _isAll = true;
                //전체 작업지시 조회
                this.search(_isAll);
                btnAll.Text = "당일\n작업";
            }
            else
            {
                _isAll = false;
                //당일 작업지시 조회
                this.search(_isAll);
                btnAll.Text = "전체\n작업";
            }
                
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //자주검사
            try
            {
                //if (workOrderGridView.GetFocusedValue() == null || workOrderGridView.GetFocusedValue().ToString() == "")
                //{
                //    acMessageBox.Show("선택된 품목이 없습니다.", "자주검사", acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                //if (!workPlanGridView.FocusedColumn.Tag.Equals("P"))
                //{
                //    acMessageBox.Show("공정을 선택하세요.", "자주검사", acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}
                    

                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("EMP_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["EMP_NAME"] = _strEmpName;
                paramTable.Rows.Add(paramRow);

                DataRow planrow = workOrderGridView.GetFocusedDataRow();

                DataTable dtParam = new DataTable();
                dtParam.Columns.Add("WO_NO", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("PART_QTY", typeof(Int32));

                DataRow dr = dtParam.NewRow();
                dr["WO_NO"] = planrow["WO_NO"];
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

        private void btnRemoveEmp_Click(object sender, EventArgs e)
        {
            _strEmpCode = "";
            _strEmpName = "";

            EmpLabel.Text = _strEmpName;

            this.search(_isAll);

        }
    }
}
