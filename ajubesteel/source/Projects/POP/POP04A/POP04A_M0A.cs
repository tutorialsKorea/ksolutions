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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using BizManager;
using CodeHelperManager;
using System.IO;
using System.Linq;

namespace POP
{
    public sealed partial class POP04A_M0A : BaseMenu
    {
        enum PANEL_STAT
        {
            비가동 = 0
            , 유인시작 = 1
            , 중지 = 2
            , 재시작 = 3
            , 완료 = 4
            , 무인시작 = 5
        }

        const string _RootFolderPath = "C:\\CubicTek";
        public POP04A_M0A()
        {
            InitializeComponent();
        }

        private string _strMcCode = "";
        private string _strMcName = "";
        private string _strMcGroup = "";
        private string _strEmpCode = acInfo.UserID;
        private string _strEmpName = acInfo.UserName;
        private string _strIdleStartTime = "";

      
        private string _prodCode = "";
        private string _partName = "";
        private string _StrMsg = "진행중인 작업이 없습니다";
        private string _strIdleCode = "";
        private string _strIdleWorkNo = "";
        private string _strIdleName = "";
        private bool idleState = false;
        private bool IsWorking = false;
        private bool thisMcWorking = false;

        /// <summary>
        /// 완료작업포함
        /// </summary>
        private bool IS_FINISH
        {
            get
            {
                return chkFinish.Checked;
            }
        }

        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public override void MenuInit()
        {

            //GetPopKioskInfo();
            // 작지상태관련

            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S032");
            acGridView1.Columns["WO_FLAG"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            lb_info.ForeColor = Color.Black;

            #region 작업시작
            if (1 == 1)
            {
                acGridColumn colCommand = acGridView1.Columns.AddVisible("ACT_START") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.play_2x, Color.Navy));
                button.ToolTip = "작업시작";

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woStart_ButtonClick;

                acGridControl1.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;

                //acGridView1.AddPictrue("ACT_START", "시작", "", false, DevExpress.Utils.HorzAlignment.Center, true, true);

                acGridView1.Columns["ACT_START"].Caption = "시작";
                acGridView1.Columns["ACT_START"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                acGridView1.Columns["ACT_START"].VisibleIndex = 2;
                acGridView1.Columns["ACT_START"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            #endregion

            #region 작업중지
            if (1 == 1)
            {
                acGridColumn colCommand = acGridView1.Columns.AddVisible("ACT_STOP") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.pause_2x, Color.Navy));
                button.ToolTip = "작업중지";
             
                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woStop_ButtonClick;

                acGridControl1.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;
                acGridView1.Columns["ACT_STOP"].Caption = "중지";
                acGridView1.Columns["ACT_STOP"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                acGridView1.Columns["ACT_STOP"].VisibleIndex = 3;
                acGridView1.Columns["ACT_STOP"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            #endregion

            #region 비가동 중지
            RepositoryItemButtonEdit btnIdleStop = acGridView1.AddButtonEdit("ACT_IDLESTOP", "비가동\n중지", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.HideTextEditor, true, true, false, ChangeIconColor(POP.Resource.pauseStop_2x, Color.Navy), ButtonPredefines.Glyph, woIdleStop_ButtonClick);
            btnIdleStop.ReadOnly = true;
            acGridView1.Columns["ACT_IDLESTOP"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            #endregion

            #region 작업완료
            if (1 == 1)
            {
                acGridColumn colCommand = acGridView1.Columns.AddVisible("ACT_END") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.stop_2x, Color.Navy));
                button.ToolTip = "작업완료";
             
                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woEnd_ButtonClick;

                acGridControl1.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;
                acGridView1.Columns["ACT_END"].Caption = "완료";
                acGridView1.Columns["ACT_END"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                acGridView1.Columns["ACT_END"].VisibleIndex = 4;
                acGridView1.Columns["ACT_END"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            #endregion

            acLayoutControl3.SetAllReadOnly(true);
            //(acLayoutControl3.GetEditor("PROD_FLAG") as acLookupEdit).SetCode("P006");
            //(acLayoutControl3.GetEditor("PROD_CATEGORY") as acLookupEdit).SetCode("P009");

            acLabelControl1.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
            acLabelControl2.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
            acLabelControl5.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN2").toColor();
            acLabelControl3.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
            acLabelControl4.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();
            
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            //acGridView1.AddTextEdit("PLT_CODE", "사업장코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WO_NO", "작업지시\r\n번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("IS_REWORK", "재작업 여부", "", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");

            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpVendor("CVND_CODE", "고객사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P009");
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MILL_MAT_NAME", "가공소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ING_QTY", "가공진행\r\n수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ACT_QTY", "완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ING_EMP", "가공진행\r\n작업자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP", "CAM담당 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAM_EMP_NAME", "CAM담당", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("X_VALUE", "X", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("Y_VALUE", "Y", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("T_VALUE", "두께(T)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F3);
            acGridView1.AddTextEdit("CAM_MAT_NAME", "소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_QLTY", "소재(재질)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAUTION", "특이사항", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "WO_NO" };

            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.AddHidden("PT_ID", typeof(string));

            acGridView1.Columns["CHAIN_WO_NO"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView1.Columns["ACT_START"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["ACT_STOP"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["ACT_IDLESTOP"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["ACT_END"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView1.OptionsView.AllowCellMerge = true;

            acGridView1.CellMerge += acGridView1_CellMerge;

            // acGridView1.SortInfo.Add(acGridView1.Columns["WO_FLAG"], DevExpress.Data.ColumnSortOrder.Descending);

            acGridView1.RowHeight = 45;

            acGridView1.ColumnPanelRowHeight = 70;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

            SetPopGridFont(acGridView1, null, null);

            chkFinish.CheckedChanged += ChkFinish_CheckedChanged;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.MouseUp += acGridView1_MouseUp;

            #region 컨트롤 설정

            lb_info.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 8,
                     FontStyle.Bold, GraphicsUnit.Point);
            //lblPOPName.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 12,
            //        FontStyle.Bold, GraphicsUnit.Point);

            Control[] con = formcount(this);

            foreach (Control down in con) // 컨트롤이 버튼인 경우 폰트를 일치시킨다.
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 4,
                    FontStyle.Regular, GraphicsUnit.Point);
                }

                else if (down.Name.StartsWith("chk"))
                {
                    if (down is acCheckEdit ce)
                    {
                        ce.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 6,
                        FontStyle.Regular, GraphicsUnit.Point);
                    }

                    if (down is CheckButton cb)
                    {
                        cb.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 6,
                        FontStyle.Regular, GraphicsUnit.Point);
                    }
                }

            }

            //   ControlCollection ctrBtns = acLayoutControl3.Controls;

            //foreach (Control ctr in ctrBtns)
            //{
            //    if (ctr.Name.StartsWith("btn"))
            //    {
            //        ((ControlManager.acSimpleButton)ctr).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 20,
            //        FontStyle.Regular, GraphicsUnit.Point);
            //    }
            //}



            #endregion


            // 상단 메뉴버튼 스타일 설정
            foreach (Control ctrl in acLayoutControl1.Controls)
            {
                if (ctrl.GetType().Name.IndexOf("acSimpleButton") > -1)
                //&& ctrl.Name.StartsWith("btn"))
                {
                    acSimpleButton btn = ctrl as acSimpleButton;

                    btn.LookAndFeel.UseDefaultLookAndFeel = false;
                    btn.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.SevenClassic);
                }
            }


            timer1.Interval = acInfo.SysConfig.GetSysConfigByMemory("POP_TERMINAL_REFRESH_TIME").toInt() * 1000; //300*1000 = 30초 주기

            timer1.Start();

            acLayoutControl1.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-7);
            acLayoutControl1.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();


            base.MenuInit();
        }

        private void acGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo == null) return;
                if (hitInfo.Column == null) return;
                if (hitInfo.Column.FieldName == "SCOMMENT")
                {
                    if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                    {
                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        if (focusRow == null) return;

                        ScommentPopup frm = new ScommentPopup(focusRow);

                        frm.ParentControl = this;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ACT_START"
                    || e.Column.FieldName == "ACT_STOP"
                    || e.Column.FieldName == "ACT_IDLESTOP"
                    || e.Column.FieldName == "ACT_END") return;

                //DataRowView view = (DataRowView)acGridView1.GetRow(e.RowHandle);
                DataRow row = acGridView1.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    switch (row["WO_FLAG"].ToString())
                    {
                        case "1": // 작업확정  ("0": 미확인)

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();

                            break;

                        case "2":  //작업진행

                            if (row["ING_EMP"].ToString().Contains(_strMcCode))   //현재 설비가 가공 진행내역에 존재할때
                            {
                                e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();

                            }
                            else
                            {
                                e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN2").toColor();
                            }
                            break;

                        case "3":  //작업정지

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();

                            // 비가동 상태인 Row인 경우 포커스 고정
                            // if (view["WO_NO"].ToString() == _strIdleWorkNo) { acGridView1.SetFocusCell(e.RowHandle,"WO_FLAG"); }

                            break;

                        case "4":  //작업완료

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();

                            break;
                    }

                }
            }
            catch { }
        }

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("CHAIN_WO_NO")
                    || e.Column.FieldName.Equals("ACT_START")
                    || e.Column.FieldName.Equals("ACT_STOP")
                    || e.Column.FieldName.Equals("ACT_IDLESTOP")
                    || e.Column.FieldName.Equals("ACT_END"))
                //if (e.Column.FieldName.Equals("CHAIN_WO_NO"))
                {
                    string cWo1 = acGridView1.GetRowCellValue(e.RowHandle1, "CHAIN_WO_NO").ToString();
                    string cWo2 = acGridView1.GetRowCellValue(e.RowHandle2, "CHAIN_WO_NO").ToString();

                    string proc1 = acGridView1.GetRowCellValue(e.RowHandle1, "PROC_CODE").ToString();
                    string proc2 = acGridView1.GetRowCellValue(e.RowHandle2, "PROC_CODE").ToString();

                    if (cWo1 == cWo2
                        && cWo1 != "" && cWo2 != ""
                        && proc1 == proc2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                e.Handled = true;
            }
            catch
            {

            }
        }

        private void AcAdvBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                switch(e.Column.FieldName)
                {
                    case "WO_FLAG":
                        {
                            Font f = e.Appearance.GetFont();
                            e.Appearance.Font = new Font(f, FontStyle.Bold);
                        }
                        break;
                }
            }
            catch
            { }
        }

        private void ChkFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (IS_FINISH)
            {
                chkFinish.Text = "√ 완료작업 포함";

            }
            else
            {
                chkFinish.Text = "완료작업 포함";
            }

            this.search();
        }



        // 시작,중지,완료버튼 색상변경
        private Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GetStartInit();

            timer1_Tick(null, null);

        }

        void GetStartInit()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("IP_ADDR", typeof(String)); //
            paramTable.Columns.Add("MAC_ADDR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["IP_ADDR"] = acNetWork.GetLanIPAddress();
            paramRow["MAC_ADDR"] = acNetWork.GetMacAddress();


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER", paramSet, "RQSTDT", "RSLTDT");

            // 단말기에 등록된 설비가 있으면 바로 조회
            if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            {

                foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
                {
                    _strMcCode = row["MC_CODE"].ToString();
                    _strMcName = row["MC_NAME"].ToString();
                    _strMcGroup = row["MC_GROUP"].ToString();
                }

                UpdSearch();

            } // 없으면 파일에서 설비를 읽어들인다.
            else if (System.IO.File.Exists(_RootFolderPath+"\\ActivePOP.ini"))
            {
                string main_mc = System.IO.File.ReadAllText(_RootFolderPath + "\\ActivePOP.ini");

                if (!main_mc.isNullOrEmpty())
                {

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable2.Columns.Add("MC_CODE", typeof(String)); //

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["MC_CODE"] = main_mc;

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "POP04A_SER10", paramSet2, "RQSTDT", "RSLTDT");

                    if (resultSet2.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        foreach (DataRow row in resultSet2.Tables["RSLTDT"].Rows)
                        {
                            _strMcCode = row["MC_CODE"].ToString();
                            _strMcName = row["MC_NAME"].ToString();
                            _strMcGroup = row["MC_GROUP"].ToString();
                        }

                        UpdSearch();
                    }
                }
            }

        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow focus = acGridView1.GetFocusedDataRow();

            if (focus != null)
            {
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                acLayoutControl3.DataBind(focus, false);

                if (focus["WO_FLAG"].ToString() == "1"
                    || focus["WO_FLAG"].ToString() == "3"
                    || focus["WO_FLAG"].ToString() == "4")
                {
                    btnFile.Enabled = true;
                }
                else
                {
                    btnFile.Enabled = false;
                }
            }
            else
            {
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                btnFile.Enabled = false;
            }
        }

        // 시작/중지/완료 버튼 활성화 조건
        private void acGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            //DataView dv = acGridView1.GetDataSourceView();

            acGridView view = sender as acGridView;

            if (view == null) return;
            //if (dv.Count == 0) return;
            if (e.RowHandle < 0) return;

            string status = acGridView1.GetRowCellValue(e.RowHandle, "WO_FLAG").ToString();
            string workno = acGridView1.GetRowCellValue(e.RowHandle, "WO_NO").ToString();

            //bool isWorking = false;

            //// 현재 진행중인 작업이 있는지 검사
            //foreach (DataRow dr in dv.ToTable().Rows)
            //{
            //    if (dr["WO_FLAG"].ToString() == "2")
            //    {
            //        isWorking = true;
            //    }
            //}

            DataRow row = view.GetDataRow(e.RowHandle);

            if (e.Column.FieldName == "ACT_START")
            {
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.play_2x, Color.Navy));
                button.ToolTip = "작업시작";


                //if (isWorking == true && row["WO_FLAG"].ToString() == "2" && row["ING_EMP"].ToString().Contains(_strMcCode))
                if (row["WO_FLAG"].ToString() == "2" && row["ING_EMP"].ToString().Contains(_strMcCode))
                {
                    button.Enabled = false;
                }
                else
                {
                    button.Enabled = true;
                }


                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.ButtonClick += woStart_ButtonClick;
                e.RepositoryItem = riButtonEdit;

            }
            else if (e.Column.FieldName == "ACT_STOP")
            {
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.pause_2x, Color.Navy));
                button.ToolTip = "작업중지";

                if (status == "2" && row["ING_EMP"].ToString().Contains(_strMcCode))
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;  // 작지상태가 진행이 아닌 경우 비활성화
                }

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woStop_ButtonClick;
                e.RepositoryItem = riButtonEdit;
            }
            else if (e.Column.FieldName == "ACT_IDLESTOP")
            {
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.pauseStop_2x, Color.Navy));
                button.ToolTip = "비가동중지";
                
                if(idleState == true && _strIdleWorkNo.isNullOrEmpty() == false && row["WO_NO"].ToString() == _strIdleWorkNo)
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
                }

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woIdleStop_ButtonClick;
                e.RepositoryItem = riButtonEdit;
            }
            else if (e.Column.FieldName == "ACT_END")
            {
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.stop_2x, Color.Navy));
                button.ToolTip = "작업완료";

                if (status == "2" && row["ING_EMP"].ToString().Contains(_strMcCode))
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
                }

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woEnd_ButtonClick;
                e.RepositoryItem = riButtonEdit;
            }
        }

        public override bool MenuDestory(object sender)
        {
            timer1.Stop();

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

        private void btnChangeMc_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeMC3 frm = new ChangeMC3(_strMcGroup);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    DataRow frmRow = frm.OutputData as DataRow;

                    if (frmRow == null) return;

                    _strMcCode = frmRow["MC_CODE"].ToString();
                    _strMcName = frmRow["MC_NAME"].ToString();
                    _strMcGroup = frmRow["MC_GROUP"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("MAC", typeof(String));
                    paramTable.Columns.Add("MC_CODE", typeof(String));
                    paramTable.Columns.Add("DATA_FLAG", typeof(byte));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MAC"] = acNetWork.GetMacAddress();
                    paramRow["MC_CODE"] = _strMcCode;
                    paramRow["DATA_FLAG"] = 0;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, "POP04A_INS14", paramSet, "RQSTDT", "RSLTDT");



                    UpdSearch();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnChangeEmp_Click(object sender, EventArgs e)
        {
            ChangeOnlyProcEmp frm = new ChangeOnlyProcEmp();
            
            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            base.ChildFormAdd("NEW", frm);

            if (frm.ShowDialog() == DialogResult.OK) 
            {
                DataRow frmRow = frm.OutputData as DataRow; 
              
                if (frmRow == null) return;

                _strEmpCode = frmRow["EMP_CODE"].ToString();
                _strEmpName = frmRow["EMP_NAME"].ToString();

                lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);

                // this.search();

            }
        }

 
        /// <summary>
        /// 시작(버튼)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void woStart_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focuseRow = null;

                if (sender == null && e == null)
                {
                    focuseRow = acGridView1.GetFocusedDataRow();
                }
                else
                {
                    if ((sender as ButtonEdit).Parent.GetType() == typeof(acGridControl))
                    {
                        focuseRow = acGridView1.GetFocusedDataRow();
                    }
                    else
                    {
                        return;
                    }
                }

                if (_strMcCode == "")
                {
                    acMessageBox.Show(this, "설비가 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                //확인용 설비 체크
                DataTable paramMcChkTable = new DataTable("RQSTDT");
                paramMcChkTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramMcChkTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramMcChkRow = paramMcChkTable.NewRow();
                paramMcChkRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramMcChkRow["MC_CODE"] = _strMcCode;

                paramMcChkTable.Rows.Add(paramMcChkRow);

                DataSet paramMcChkSet = new DataSet();
                paramMcChkSet.Tables.Add(paramMcChkTable);

                DataSet mcChkResultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER17", paramMcChkSet, "RQSTDT", "RSLTDT");
                
                if(mcChkResultSet.Tables["RSLTDT"].Rows.Count == 1)
                {
                    if (focuseRow["MC_GROUP"].ToString() != mcChkResultSet.Tables["RSLTDT"].Rows[0]["MC_GROUP"].ToString())
                    {
                        acAlert.Show(this, "선택된 설비 정보가 맞지 않습니다.", acAlertForm.enmType.Info);
                        return;
                    }
                }
                else
                {
                    acAlert.Show(this, "설비 기준정보가 없습니다.", acAlertForm.enmType.Info);
                }

                if (focuseRow["CHAIN_WO_NO"].ToString() != "")
                {
                    //묶음 실행
                    DataView selectedView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"].ToString() +"' AND PROC_CODE = '" + focuseRow["PROC_CODE"].ToString() + "'");

                    DataTable paramMcTable = new DataTable("RQSTDT");
                    paramMcTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramMcTable.Columns.Add("WO_NO", typeof(String)); //
                    paramMcTable.Columns.Add("MC_CODE", typeof(String)); //

                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramMcRow = paramMcTable.NewRow();
                        paramMcRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramMcRow["MC_CODE"] = _strMcCode;
                        paramMcRow["WO_NO"] = selectedView[i]["WO_NO"];

                        paramMcTable.Rows.Add(paramMcRow);
                    }
                    
                    DataSet paramMcSet = new DataSet();
                    paramMcSet.Tables.Add(paramMcTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER5", paramMcSet, "RQSTDT", "RSLTDT");

                    // 작업지시 테이블에 현재 선택한 작업지시가 있는지 없는지 확인  
                    if (resultSet.Tables["RSLTDT_WO"].Rows.Count != selectedView.Count)
                    {
                        acMessageBox.Show("선택한 작업지시가 유효하지 않습니다. 작업을 재조회 후에 진행하십시오.", "작업 시작", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    // 비가동상태에서 재시작하는 경우 
                    if ((focuseRow["WO_FLAG"].ToString() == "1" || focuseRow["WO_FLAG"].ToString() == "3" || focuseRow["WO_FLAG"].ToString() == "4") && idleState == true)
                    {
                        if (acMessageBox.Show(this, "비가동을 종료하고 재시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                        {
                            return;
                        }

                        idleState = false;

                        // 해당 실적에 대해 비가동 종료 처리를 먼저 실행
                        DataTable paramIdleTable = new DataTable("RQSTDT_IDL");
                        paramIdleTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("WO_NO", typeof(String)); //
                        paramIdleTable.Columns.Add("WO_FLAG", typeof(String)); //
                        paramIdleTable.Columns.Add("END_TIME", typeof(DateTime)); //
                        paramIdleTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("NULL_END_TIME", typeof(String)); //추후 NULL_END_TIME 조건을 IDLE_STATE = 1로 변경할것.


                        DataRow paramIdleRow = paramIdleTable.NewRow();
                        paramIdleRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramIdleRow["WO_NO"] = _strIdleWorkNo; //비가동 중인 작업지시
                        paramIdleRow["WO_FLAG"] = 2;
                        paramIdleRow["END_TIME"] = DateTime.Now; // 비가동 종료시간
                        paramIdleRow["MC_CODE"] = _strMcCode;
                        paramIdleRow["EMP_CODE"] = _strEmpCode;
                        paramIdleRow["NULL_END_TIME"] = 1;
                        paramIdleTable.Rows.Add(paramIdleRow);

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramIdleTable);

                        BizRun.QBizRun.ExecuteService(this, "POP04A_INS12", paramSet, "RQSTDT", "RSLTDT");
                    }
                    else
                    {
                        if ((focuseRow["WO_FLAG"].ToString() == "1" || focuseRow["WO_FLAG"].ToString() == "2" || focuseRow["WO_FLAG"].ToString() == "4" || focuseRow["WO_FLAG"].ToString() == "3") && idleState == false)
                        {
                            if (IsWorking == true)
                            {
                                if (acMessageBox.Show(this, "현재 진행중인 작업이 있습니다. \n종료 후 다음 작업을 시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    // 현재 작업이 진행중인 Row를 가져온다
                                    DataView flagView = acGridView1.GetDataSourceView("WO_FLAG = '2' AND ING_EMP LIKE '%" + _strMcCode + "%'");

                                    DataRow runRow = null;

                                    if (flagView.Count > 0)
                                    {
                                        for (int i = 0; i < flagView.Count; i++)
                                        {
                                            runRow = flagView[i].Row;
                                        }
                                    }

                                    if (runRow["CHAIN_WO_NO"].ToString() == "")
                                    {
                                        // 실적등록 
                                        if (RegAct(runRow) == false)
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + runRow["CHAIN_WO_NO"].ToString() + "'");
                                        DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + runRow["CHAIN_WO_NO"].ToString() + "' AND PROC_CODE = '" + runRow["PROC_CODE"].ToString() + "'");

                                        if (MultiRegAct(ChainView.ToTable()) == false)
                                        {
                                            return;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //if (acMessageBox.Show(this, "시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                                //{
                                //    return;
                                //}
                            }
                        }
                    }

                    ActExpQtyMulti frm = new ActExpQtyMulti(selectedView.ToTable());

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    // 신규 실적 생성

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = frm.OutputData as DataRow;

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTable.Columns.Add("WO_NO", typeof(String)); //
                        paramTable.Columns.Add("CHAIN_WO_NO", typeof(String)); //
                        paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                        paramTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
                        paramTable.Columns.Add("PROC_STAT", typeof(String)); //
                        paramTable.Columns.Add("PANEL_STAT", typeof(String)); //
                        paramTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
                        paramTable.Columns.Add("MAN_START_TIME", typeof(DateTime));
                        paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
                        paramTable.Columns.Add("INPUT_FLAG", typeof(byte)); //
                        paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                        paramTable.Columns.Add("PLN_QTY", typeof(int)); //


                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = _strEmpCode;
                        paramRow["CHAIN_WO_NO"] = focuseRow["CHAIN_WO_NO"];
                        paramRow["WO_FLAG"] = 2;
                        paramRow["MC_CODE"] = _strMcCode;
                        paramRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                        paramRow["MC_NM_CHECK"] = 0;
                        paramRow["PROC_STAT"] = 2;

                        if (focuseRow["WO_FLAG"].ToString() == "1" || thisMcWorking == false)
                        {
                            paramRow["PANEL_STAT"] = (int)PANEL_STAT.유인시작;
                        }
                        else
                        {
                            paramRow["PANEL_STAT"] = (int)PANEL_STAT.재시작;
                        }

                        paramRow["ACT_START_TIME"] = DateTime.Now;
                        paramRow["MAN_START_TIME"] = DateTime.Now;
                        paramRow["MULTI_START_CNT"] = 1;
                        paramRow["INPUT_FLAG"] = 0;
                        paramRow["PROC_CODE"] = focuseRow["PROC_CODE"];
                        paramRow["PLN_QTY"] = frmRow["PLN_QTY"].toInt();


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS9_2", paramSet, "RQSTDT", "RSLTDT",
                               QuickIns,
                               QuickException);

                    }
                    else
                    {
                        return;
                    }


                }
                else
                {
                    //단일 실행
                    DataTable paramMcTable = new DataTable("RQSTDT");
                    paramMcTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramMcTable.Columns.Add("WO_NO", typeof(String)); //
                    paramMcTable.Columns.Add("MC_CODE", typeof(String)); //

                    DataRow paramMcRow = paramMcTable.NewRow();
                    paramMcRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramMcRow["MC_CODE"] = _strMcCode;
                    paramMcRow["WO_NO"] = focuseRow["WO_NO"];

                    paramMcTable.Rows.Add(paramMcRow);
                    DataSet paramMcSet = new DataSet();
                    paramMcSet.Tables.Add(paramMcTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER5", paramMcSet, "RQSTDT", "RSLTDT");

                    // 작업지시 테이블에 현재 선택한 작업지시가 있는지 없는지 확인  
                    if (resultSet.Tables["RSLTDT_WO"].Rows.Count == 0)
                    {
                        acMessageBox.Show("선택한 작업지시가 유효하지 않습니다. 작업을 재조회 후에 진행하십시오.", "작업 시작", acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    // 비가동상태에서 재시작하는 경우 
                    if ((focuseRow["WO_FLAG"].ToString() == "1" || focuseRow["WO_FLAG"].ToString() == "3" || focuseRow["WO_FLAG"].ToString() == "4") && idleState == true)
                    {
                        if (acMessageBox.Show(this, "비가동을 종료하고 재시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                        {
                            return;
                        }

                        idleState = false;

                        //2021-08-03 비가동 내역은 중지하지만 기존 작지는 진행하지 않게 변경함
                        // 해당 실적에 대해 비가동 종료 처리를 먼저 실행
                        DataTable paramIdleTable = new DataTable("RQSTDT_IDL");
                        paramIdleTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("WO_NO", typeof(String)); //
                        paramIdleTable.Columns.Add("WO_FLAG", typeof(String)); //
                        paramIdleTable.Columns.Add("END_TIME", typeof(DateTime)); //
                        paramIdleTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramIdleTable.Columns.Add("NULL_END_TIME", typeof(String)); //추후 NULL_END_TIME 조건을 IDLE_STATE = 1로 변경할것.


                        DataRow paramIdleRow = paramIdleTable.NewRow();
                        paramIdleRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramIdleRow["WO_NO"] = _strIdleWorkNo; //비가동 중인 작업지시
                        paramIdleRow["WO_FLAG"] = 2;
                        paramIdleRow["END_TIME"] = DateTime.Now; // 비가동 종료시간
                        paramIdleRow["MC_CODE"] = _strMcCode;
                        paramIdleRow["EMP_CODE"] = _strEmpCode;
                        paramIdleRow["NULL_END_TIME"] = 1;
                        paramIdleTable.Rows.Add(paramIdleRow);

                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramIdleTable);

                        BizRun.QBizRun.ExecuteService(this, "POP04A_INS12", paramSet, "RQSTDT", "RSLTDT");
                    }
                    else
                    {
                        if ((focuseRow["WO_FLAG"].ToString() == "1" || focuseRow["WO_FLAG"].ToString() == "2" || focuseRow["WO_FLAG"].ToString() == "4" || focuseRow["WO_FLAG"].ToString() == "3") && idleState == false)
                        {
                            if (IsWorking == true)
                            {
                                if (acMessageBox.Show(this, "현재 진행중인 작업이 있습니다. \n종료 후 다음 작업을 시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    // 현재 작업이 진행중인 Row를 가져온다
                                    DataView flagView = acGridView1.GetDataSourceView("WO_FLAG = '2' AND ING_EMP LIKE '%" + _strMcCode + "%'");

                                    DataRow runRow = null;

                                    if (flagView.Count > 0)
                                    {
                                        for (int i = 0; i < flagView.Count; i++)
                                        {
                                            runRow = flagView[i].Row;
                                        }
                                    }

                                    if (runRow["CHAIN_WO_NO"].ToString() == "")
                                    {
                                        // 실적등록 
                                        if (RegAct(runRow) == false)
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + runRow["CHAIN_WO_NO"].ToString() + "'");
                                        DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"].ToString() + "' AND PROC_CODE = '" + focuseRow["PROC_CODE"].ToString() + "'");

                                        if (MultiRegAct(ChainView.ToTable()) == false)
                                        {
                                            return;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //if (acMessageBox.Show(this, "시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                                //{
                                //    return;
                                //}
                            }
                        }
                    }

                    ActExpQty frm = new ActExpQty(focuseRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    // 신규 실적 생성

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = frm.OutputData as DataRow;

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTable.Columns.Add("WO_NO", typeof(String)); //
                        paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                        paramTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
                        paramTable.Columns.Add("PROC_STAT", typeof(String)); //
                        paramTable.Columns.Add("PANEL_STAT", typeof(String)); //
                        paramTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
                        paramTable.Columns.Add("MAN_START_TIME", typeof(DateTime));
                        paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
                        paramTable.Columns.Add("INPUT_FLAG", typeof(byte)); //
                        paramTable.Columns.Add("PLN_QTY", typeof(int)); //


                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = _strEmpCode;
                        paramRow["WO_NO"] = focuseRow["WO_NO"];
                        paramRow["WO_FLAG"] = 2;
                        paramRow["MC_CODE"] = _strMcCode;
                        paramRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                        paramRow["MC_NM_CHECK"] = 0;
                        paramRow["PROC_STAT"] = 2;

                        if (focuseRow["WO_FLAG"].ToString() == "1" || thisMcWorking == false)
                        {
                            paramRow["PANEL_STAT"] = (int)PANEL_STAT.유인시작;
                        }
                        else
                        {
                            paramRow["PANEL_STAT"] = (int)PANEL_STAT.재시작;
                        }

                        paramRow["ACT_START_TIME"] = DateTime.Now;
                        paramRow["MAN_START_TIME"] = DateTime.Now;
                        paramRow["MULTI_START_CNT"] = 1;
                        paramRow["INPUT_FLAG"] = 0;
                        paramRow["PLN_QTY"] = frmRow["PLN_QTY"].toInt();


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS9", paramSet, "RQSTDT", "RSLTDT",
                               QuickIns,
                               QuickException);

                    }
                    else
                    {
                        return;
                    }
                }
                
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickIns(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void woStop_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focuseRow = null;

                if ((sender as ButtonEdit).Parent.GetType() == typeof(acGridControl))
                {
                    focuseRow = acGridView1.GetFocusedDataRow();
                }
                else
                {
                    return;
                }

                if (_strMcCode == "")
                {
                    acMessageBox.Show(this, "설비가 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                //확인용 설비 체크
                DataTable paramMcChkTable = new DataTable("RQSTDT");
                paramMcChkTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramMcChkTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramMcChkRow = paramMcChkTable.NewRow();
                paramMcChkRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramMcChkRow["MC_CODE"] = _strMcCode;

                paramMcChkTable.Rows.Add(paramMcChkRow);

                DataSet paramMcChkSet = new DataSet();
                paramMcChkSet.Tables.Add(paramMcChkTable);

                DataSet mcChkResultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER17", paramMcChkSet, "RQSTDT", "RSLTDT");

                if (mcChkResultSet.Tables["RSLTDT"].Rows.Count == 1)
                {
                    if (focuseRow["MC_GROUP"].ToString() != mcChkResultSet.Tables["RSLTDT"].Rows[0]["MC_GROUP"].ToString())
                    {
                        acAlert.Show(this, "선택된 설비 정보가 맞지 않습니다.", acAlertForm.enmType.Info);
                        return;
                    }
                }
                else
                {
                    acAlert.Show(this, "설비 기준정보가 없습니다.", acAlertForm.enmType.Info);
                }

                //if (acMessageBox.Show(this, "중지하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                //{
                //    return;
                //}


                idleState = true;  // 비가동상태로 변경
                _strIdleWorkNo = focuseRow["WO_NO"].ToString();

                if (idleState == true)  
                {
                    WorkStop2 frm = new WorkStop2();

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow frmRow = frm.OutputData as DataRow;

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("WO_NO", typeof(String)); //
                        paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                        paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("START_TIME", typeof(DateTime)); //
                        paramTable.Columns.Add("MC_CODE", typeof(String)); //
                        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTable.Columns.Add("IDLE_CODE", typeof(String)); //
                        paramTable.Columns.Add("IDLE_TIME", typeof(String)); //
                        paramTable.Columns.Add("IDLE_STATE", typeof(String)); //
                        paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                        paramTable.Columns.Add("REG_EMP", typeof(String)); //
                        paramTable.Columns.Add("NULL_END_TIME", typeof(String)); //

                        if (focuseRow["CHAIN_WO_NO"].ToString() != "")
                        {
                            //DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"] + "'");
                            DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"].ToString() + "' AND PROC_CODE = '" + focuseRow["PROC_CODE"].ToString() + "'");

                            DateTime startTime = DateTime.Now;

                            for (int i = 0; i < chainView.Count; i++)
                            {
                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["WO_NO"] = chainView[i]["WO_NO"];
                                paramRow["WO_FLAG"] = 3;
                                paramRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                                paramRow["START_TIME"] = startTime;
                                paramRow["MC_CODE"] = _strMcCode;
                                paramRow["EMP_CODE"] = _strEmpCode;
                                paramRow["IDLE_CODE"] = frmRow["IDLE_CAUSE"].ToString();
                                paramRow["IDLE_TIME"] = 1;
                                paramRow["IDLE_STATE"] = 1;
                                paramRow["SCOMMENT"] = DBNull.Value;
                                paramRow["REG_EMP"] = acInfo.UserID;
                                paramRow["NULL_END_TIME"] = 1;


                                paramTable.Rows.Add(paramRow);
                            }
                            
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS10_2", paramSet, "RQSTDT", "RSLTDT",
                                   QuickIns,
                                   QuickException);
                        }
                        else
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WO_NO"] = focuseRow["WO_NO"];
                            paramRow["WO_FLAG"] = 3;
                            paramRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            paramRow["START_TIME"] = DateTime.Now;
                            paramRow["MC_CODE"] = _strMcCode;
                            paramRow["EMP_CODE"] = _strEmpCode;
                            paramRow["IDLE_CODE"] = frmRow["IDLE_CAUSE"].ToString();
                            paramRow["IDLE_TIME"] = 1;
                            paramRow["IDLE_STATE"] = 1;
                            paramRow["SCOMMENT"] = DBNull.Value;
                            paramRow["REG_EMP"] = acInfo.UserID;
                            paramRow["NULL_END_TIME"] = 1;


                            paramTable.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS10", paramSet, "RQSTDT", "RSLTDT",
                                   QuickIns,
                                   QuickException);
                        }
                    }
                    {
                        idleState = false;
                    }
                }
              
            }
            catch (Exception ex)
            { }
        }

        private void woIdleStop_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focuseRow = null;

                if ((sender as ButtonEdit).Parent.GetType() == typeof(acGridControl))
                {
                    focuseRow = acGridView1.GetFocusedDataRow();
                }
                else
                {
                    return;
                }

                if (acMessageBox.Show(this, "비가동 중지하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                idleState = false;  // 비가동상태로 변경
                _strIdleWorkNo = string.Empty;

                DataTable paramIdleTable = new DataTable("RQSTDT_IDL");
                paramIdleTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramIdleTable.Columns.Add("WO_NO", typeof(String)); //
                paramIdleTable.Columns.Add("WO_FLAG", typeof(String)); //
                paramIdleTable.Columns.Add("END_TIME", typeof(DateTime)); //
                paramIdleTable.Columns.Add("MC_CODE", typeof(String)); //
                paramIdleTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramIdleTable.Columns.Add("NULL_END_TIME", typeof(String)); //추후 NULL_END_TIME 조건을 IDLE_STATE = 1로 변경할것.


                DataRow paramIdleRow = paramIdleTable.NewRow();
                paramIdleRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramIdleRow["WO_NO"] = _strIdleWorkNo; //비가동 중인 작업지시
                paramIdleRow["WO_FLAG"] = 2;
                paramIdleRow["END_TIME"] = DateTime.Now; // 비가동 종료시간
                paramIdleRow["MC_CODE"] = _strMcCode;
                paramIdleRow["EMP_CODE"] = _strEmpCode;
                paramIdleRow["NULL_END_TIME"] = 1;
                paramIdleTable.Rows.Add(paramIdleRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramIdleTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS12", paramSet, "RQSTDT", "RSLTDT",
                       QuickIns,
                       QuickException);
                //BizRun.QBizRun.ExecuteService(this, "POP04A_INS12", paramSet, "RQSTDT", "RSLTDT");
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// 작업완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void woEnd_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            try
            {
                DataRow focuseRow = null;

                if ((sender as ButtonEdit).Parent.GetType() == typeof(acGridControl))
                {
                    focuseRow = acGridView1.GetFocusedDataRow();
                }
                else
                {
                    return;
                }

                if (_strMcCode == "")
                {
                    acMessageBox.Show(this, "설비가 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                //확인용 설비 체크
                DataTable paramMcChkTable = new DataTable("RQSTDT");
                paramMcChkTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramMcChkTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramMcChkRow = paramMcChkTable.NewRow();
                paramMcChkRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramMcChkRow["MC_CODE"] = _strMcCode;

                paramMcChkTable.Rows.Add(paramMcChkRow);

                DataSet paramMcChkSet = new DataSet();
                paramMcChkSet.Tables.Add(paramMcChkTable);

                DataSet mcChkResultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER17", paramMcChkSet, "RQSTDT", "RSLTDT");

                if (mcChkResultSet.Tables["RSLTDT"].Rows.Count == 1)
                {
                    if (focuseRow["MC_GROUP"].ToString() != mcChkResultSet.Tables["RSLTDT"].Rows[0]["MC_GROUP"].ToString())
                    {
                        acAlert.Show(this, "선택된 설비 정보가 맞지 않습니다.", acAlertForm.enmType.Info);
                        return;
                    }
                }
                else
                {
                    acAlert.Show(this, "설비 기준정보가 없습니다.", acAlertForm.enmType.Info);
                }

                if (focuseRow["WO_FLAG"].ToString() == "3" && idleState == true) // 비가동 상태에서 완료 
                {

                    if (acMessageBox.Show(this, "비가동 상태를 종료하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataTable paramIdleTable = new DataTable("RQSTDT_IDL");
                    paramIdleTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramIdleTable.Columns.Add("WO_NO", typeof(String)); //
                    paramIdleTable.Columns.Add("WO_FLAG", typeof(String)); //
                    paramIdleTable.Columns.Add("END_TIME", typeof(DateTime)); //
                    paramIdleTable.Columns.Add("MC_CODE", typeof(String)); //
                    paramIdleTable.Columns.Add("EMP_CODE", typeof(String)); //
                    paramIdleTable.Columns.Add("NULL_END_TIME", typeof(String)); //


                    DataRow paramIdleRow = paramIdleTable.NewRow();
                    paramIdleRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramIdleRow["WO_NO"] = focuseRow["WO_NO"];
                    paramIdleRow["WO_FLAG"] = 4;
                    paramIdleRow["END_TIME"] = DateTime.Now; // 비가동 종료시간
                    paramIdleRow["MC_CODE"] = _strMcCode;
                    paramIdleRow["EMP_CODE"] = _strEmpCode;
                    paramIdleRow["NULL_END_TIME"] = 1;

                    paramIdleTable.Rows.Add(paramIdleRow);
                  
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramIdleTable);
               
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS13", paramSet, "RQSTDT", "RSLTDT",
                           QuickIns,
                           QuickException);

                }
                else
                {

                    //if (acMessageBox.Show(this, "완료하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    //{
                    //    return;
                    //}

                    if (focuseRow["CHAIN_WO_NO"].ToString() == "")
                    {
                        // 실적입력
                        if (RegAct(focuseRow))
                        {
                            //입력 후 재검색
                            search();
                        }
                    }
                    else
                    {
                        //DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"].ToString() + "'");
                        DataView ChainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focuseRow["CHAIN_WO_NO"].ToString() + "' AND PROC_CODE = '" + focuseRow["PROC_CODE"].ToString() + "'");
                        // 묶음실적입력
                        if (MultiRegAct(ChainView.ToTable()))
                        {
                            //입력 후 재검색
                            search();
                        }
                    }

                    #region 원본
                    // 실적등록 팝업 초기화 세팅
                    //DataTable paramTable = new DataTable();
                    //paramTable.Columns.Add("EMP_CODE");
                    //paramTable.Columns.Add("EMP_NAME");
                    //paramTable.Columns.Add("MC_CODE");
                    //paramTable.Columns.Add("MC_NAME");

                    //DataRow paramRow = paramTable.NewRow();
                    //paramRow["EMP_CODE"] = _strEmpCode;
                    //paramRow["EMP_NAME"] = _strEmpName;
                    //paramRow["MC_CODE"] = _strMcCode;
                    //paramRow["MC_NAME"] = _strMcName;

                    //paramTable.Rows.Add(paramRow);

                    //RegAct2 frm = new RegAct2(focuseRow, paramTable.Rows[0]);

                    //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    //frm.ParentControl = this;

                    //base.ChildFormAdd("NEW", frm);


                    //if (frm.ShowDialog() == DialogResult.OK)
                    //{

                    //    DataRow frmRow = frm.OutputData as DataRow;

                    //    DataTable paramTable2 = new DataTable("RQSTDT");
                    //    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    //    paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                    //    paramTable2.Columns.Add("WO_NO", typeof(String)); //
                    //    paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                    //    paramTable2.Columns.Add("WO_FLAG", typeof(String)); //
                    //    paramTable2.Columns.Add("PANEL_STAT", typeof(String)); //
                    //    paramTable2.Columns.Add("NULL_END_TIME", typeof(String)); //
                    //    paramTable2.Columns.Add("MC_NM_CHECK", typeof(String)); //
                    //    paramTable2.Columns.Add("MULTI_START_CNT", typeof(String)); //
                    //    paramTable2.Columns.Add("OK_QTY", typeof(int)); //
                    //    paramTable2.Columns.Add("NG_QTY", typeof(int)); //
                    //    paramTable2.Columns.Add("PAUSE_REASON", typeof(String)); //

                    //    DataTable paramTable3 = new DataTable("RQSTDT_NG");
                    //    paramTable3.Columns.Add("MASTER_CAUSE", typeof(String)); //
                    //    paramTable3.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                    //    paramTable3.Columns.Add("QUANTITY", typeof(int)); //


                    //    DataRow paramRow2 = paramTable2.NewRow();
                    //    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    //    paramRow2["EMP_CODE"] = _strEmpCode;
                    //    paramRow2["WO_NO"] = focuseRow["WO_NO"];
                    //    paramRow2["MC_CODE"] = _strMcCode;

                    //    // 계획수량 <= (이전수량 + 완료수량)
                    //    if (frmRow["PART_QTY"].toInt() <= (frmRow["ACT_QTY"].toInt() + frmRow["OK_QTY"].toInt()))
                    //    {
                    //        paramRow2["WO_FLAG"] = 4; //완료
                    //    }
                    //    else
                    //    {
                    //        paramRow2["WO_FLAG"] = 3; //중지
                    //    }

                    //    paramRow2["PANEL_STAT"] = 2;
                    //    paramRow2["NULL_END_TIME"] = 1;
                    //    paramRow2["MC_NM_CHECK"] = 0;
                    //    paramRow2["MULTI_START_CNT"] = 1;
                    //    paramRow2["OK_QTY"] = frmRow["OK_QTY"];
                    //    paramRow2["NG_QTY"] = frmRow["NG_QTY"];
                    //    paramRow2["PAUSE_REASON"] = frmRow["PAUSE_REASON"];

                    //    if (frmRow["MASTER_CAUSE"].ToString() != "")
                    //    {
                    //        DataRow paramRow3 = paramTable3.NewRow();
                    //        paramRow3["MASTER_CAUSE"] = frmRow["MASTER_CAUSE"];
                    //        paramRow3["DETAIL_CAUSE"] = frmRow["DETAIL_CAUSE"];
                    //        paramRow3["QUANTITY"] = frmRow["NG_QTY"];
                    //        paramTable3.Rows.Add(paramRow3);
                    //    }

                    //    paramTable2.Rows.Add(paramRow2);

                    //    DataSet paramSet = new DataSet();
                    //    paramSet.Tables.Add(paramTable2);
                    //    paramSet.Tables.Add(paramTable3);

                    //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP04A_INS3", paramSet, "RQSTDT,RQSTDT_NG", "RSLTDT",
                    //           QuickIns,
                    //           QuickException);

                    //}
                    #endregion

                }
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_GROUP", typeof(String)); //
            paramTable.Columns.Add("IS_FINISH", typeof(Boolean)); // 

            paramTable.Columns.Add("S_FIN_DATE", typeof(String)); //
            paramTable.Columns.Add("E_FIN_DATE", typeof(String)); //

            if (_strMcGroup.isNullOrEmpty()) _strMcGroup = "GROUP"; // 설비가 선택 안된 상태에서 잘못된 조회를 막기위함

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = _strMcCode;
            paramRow["MC_GROUP"] = _strMcGroup;
            paramRow["IS_FINISH"] = IS_FINISH;

            if (IS_FINISH)
            {
                paramRow["S_FIN_DATE"] = layoutRow["S_DATE"];
                paramRow["E_FIN_DATE"] = layoutRow["E_DATE"];
            }

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP04A_SER3", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (!e.result.Tables["RSLTDT"].Columns.Contains("ACT_START"))
                {
                    e.result.Tables["RSLTDT"].Columns.Add("ACT_START", typeof(Image));
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    row["ACT_START"] = Resource.play_2x;
                }

                _StrMsg = "진행중인 작업이 없습니다.";
                // lb_info.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
                lb_info.BackColor = Color.Transparent;
                lb_info.ForeColor = Color.Black;
                lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);

                //string status = acGridView1.GetRowCellValue(e.RowHandle, "WO_FLAG").ToString();

                IsWorking = false;

                // 현재 설비에서 진행중인 작업지시가 존재하는지 판단
                if (e.result.Tables["RSLTDT_PROG"].Rows.Count>0)
                {
                    thisMcWorking = true;
                }
                else
                {
                    thisMcWorking = false;
                }

                //진행중인 작업이 있는지 판단
                if (e.result.Tables["RSLTDT"].Select("WO_FLAG = '2' AND ING_EMP LIKE '%"+_strMcCode+"%'").Any())
                {
                    IsWorking = true;
                }

                // 현재 진행중인 작업이 없으면 비가동유무 판단하여 출력
                if(thisMcWorking == false)
                {
                    //비가동내역이 존재할때
                    if (e.result.Tables["RSLTDT_IDLE"].Rows.Count > 0)
                    {
                        // 비가동 작업실적이 있으나 현재 작업중인 설비가 아니면 비가동 상태로 넘어가지 않음 

                        foreach (DataRow row in e.result.Tables["RSLTDT_IDLE"].Rows)
                        {
                            if (_strMcCode == row["MC_CODE"].ToString())
                            {
                                idleState = true;
                                break;
                            }
                        }

                        if (idleState == true)
                        {
                            _strIdleCode = e.result.Tables["RSLTDT_IDLE"].Rows[0]["IDLE_ID"].ToString();
                            _strIdleName = e.result.Tables["RSLTDT_IDLE"].Rows[0]["IDLE_NAME"].ToString(); ;
                            _strIdleStartTime = e.result.Tables["RSLTDT_IDLE"].Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm:ss");
                            _strIdleWorkNo = e.result.Tables["RSLTDT_IDLE"].Rows[0]["WO_NO"].ToString();
                            _StrMsg = String.Format("[비가동] [사유 : {0}]  [{1} ~ ]", _strIdleName, _strIdleStartTime);

                            //lb_info.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_IDLE").toColor();
                            //2021-07-21 이성구 부장 요청 - 중지와 색 똑같이
                            lb_info.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
                            lb_info.ForeColor = Color.White;

                            //lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "[" + _strMcName + "]", " [" + _strEmpName + "]");
                            lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);

                        }
                        else
                        {
                            _strIdleCode = string.Empty;
                            _strIdleName = string.Empty;
                            _strIdleStartTime = string.Empty;
                            _strIdleWorkNo = string.Empty;
                            _StrMsg = string.Empty;
                        }

                    }
                    else
                    {
                        idleState = false;

                        _strIdleCode = string.Empty;
                        _strIdleName = string.Empty;
                        _strIdleStartTime = string.Empty;
                        _strIdleWorkNo = string.Empty;
                        _StrMsg = string.Empty;
                    }

                }

                foreach (DataRow dr in e.result.Tables["RSLTDT"].Rows)
                {
                    if (dr["WO_FLAG"].isNullOrEmpty())
                    {
                        //대기(확정상태)
                        dr["WO_FLAG"] = "1";
                    }

                    //if (dr["WO_FLAG"].ToString() == "2"
                    //   && dr["EMP_CODE"].ToString() == _strEmpCode
                    //    && dr["MC_CODE"].ToString() == _strMcCode)


                    if(dr["WO_FLAG"].ToString() == "2" && thisMcWorking == true)
                    {
                        //진행중
                        if (e.result.Tables["RSLTDT_IDLE"].Rows.Count == 0 || IsWorking == true)
                        {

                            //_StrMsg = "[오더번호 : " + dr["WO_NO"].ToString() + "]" +  " 진행 중입니다.";
                            _prodCode = dr["PROD_CODE"].ToString();
                            _partName = dr["PART_NAME"].ToString();
                            
                            lb_info.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
                            lb_info.ForeColor = Color.Black;

                            //lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "[" + _strMcName + "]", " [" + _strEmpName + "]");
                            lb_info.Text = string.Format("{0}\n{1}\n {2} {3}", "수주번호 : " + _prodCode, "품목명 : " + _partName, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);
                        }
                    }
                }

     
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //조회 메뉴로그 
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


        // 설비선택 팝업의 그리드뷰 or 트리리스트 폰트를 통일
        public static void SetPopGridFont(acGridView grid, acAdvBandGridView advGrid, acTreeList tree)
        {
            int fontSz = 2;

            if (grid != null)
            {
                grid.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                grid.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                grid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
            }

            if (advGrid != null)
            {
                advGrid.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                advGrid.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                advGrid.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                advGrid.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                advGrid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
            }

            if (tree != null)
            {
                tree.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                tree.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
            }
        }

        private void btnActLog_Click(object sender, EventArgs e)
        {
            //제작사양

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            ProdSpec frm = new ProdSpec(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            //실적현황

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            ActualLog frm = new ActualLog(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void btnNActLog_Click(object sender, EventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            BomList frm = new BomList(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);
        }

        private void btnViewCheck_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "JT");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        #region 부적합등록
        //private void btnRegNG_Click(object sender, EventArgs e)
        //{
        //    // 부적합등록 

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();

        //    if (focusRow == null)
        //    {
        //        return;
        //    }

        //    if (_strEmpCode.isNullOrEmpty() || _strMcCode.isNullOrEmpty())
        //    {
        //        acMessageBox.Show(this, "설비 또는 작업자를 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
        //        return;
        //    }



        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("WO_NO", typeof(String)); //

        //    DataRow paramMcRow = paramTable.NewRow();
        //    paramMcRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramMcRow["WO_NO"] = focusRow["WO_NO"];

        //    paramTable.Rows.Add(paramMcRow);
        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);


        //    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER2", paramSet, "RQSTDT", "RSLTDT");

        //    if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
        //    {
        //        acMessageBox.Show("해당 실적번호가 존재하지 않습니다.", "부적합 등록", acMessageBox.emMessageBoxType.CONFIRM);
        //        return;
        //    }


        //    PopAct frm = new PopAct(focusRow);

        //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //    frm.ParentControl = this;

        //    frm.Show(this);

        //}
        #endregion


        private void btnChkNG_Click(object sender, EventArgs e)
        {
            //부적합현황

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            NgLog frm = new NgLog(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void btnChkTools_Click(object sender, EventArgs e)
        {
            //공구현황

            if (this._strMcCode == string.Empty)
                return;

            ToolLog frm = new ToolLog(this._strMcCode);

            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //완료작업포함 

            if(acGridView1.DataRowCount > 0 && IS_FINISH == true)
            {
                this.search();
            }
            else if(acGridView1.DataRowCount > 0 && IS_FINISH == false)
            {
                this.search();
            }
           
        }

        private void btnWorkMng_Click(object sender, EventArgs e)
        {
            //근태신청
            try
            {
                WorkMng frm = new WorkMng(null, _strEmpCode);

                frm.ParentControl = this;

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    acAlert.Show(this, "신청되었습니다.", acAlertForm.enmType.Success);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        // 작업실적등록
        private bool RegAct(DataRow focusedRow)
        {
            try
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

                RegAct2 frm = new RegAct2(focusedRow, paramTable.Rows[0]);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool isSameMcIng = false;
                    if (focusedRow["ING_EMP"].toStringEmpty().Split(',').Length > 1)
                    {
                        //여러 설비가 동시 진행
                        isSameMcIng = true;
                    }

                    DataRow frmRow = frm.OutputData as DataRow;

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable2.Columns.Add("WO_NO", typeof(String)); //
                    paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable2.Columns.Add("WO_FLAG", typeof(String)); //
                    paramTable2.Columns.Add("PANEL_STAT", typeof(String)); //
                    paramTable2.Columns.Add("PROC_STAT", typeof(String)); //
                    paramTable2.Columns.Add("NULL_END_TIME", typeof(String)); //
                    paramTable2.Columns.Add("MC_NM_CHECK", typeof(String)); //
                    paramTable2.Columns.Add("MULTI_START_CNT", typeof(String)); //
                    paramTable2.Columns.Add("OK_QTY", typeof(int)); //
                    paramTable2.Columns.Add("NG_QTY", typeof(int)); //
                    paramTable2.Columns.Add("ACT_END_TIME", typeof(DateTime)); //

                    DataTable paramTable3 = new DataTable("RQSTDT_NG");
                    paramTable3.Columns.Add("MASTER_CAUSE", typeof(String)); //
                    paramTable3.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                    paramTable3.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable3.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable3.Columns.Add("QUANTITY", typeof(int)); //



                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["EMP_CODE"] = _strEmpCode;
                    paramRow2["WO_NO"] = focusedRow["WO_NO"];
                    paramRow2["MC_CODE"] = _strMcCode;

                    // 계획수량 <= (이전수량 + 완료수량)
                    if (frmRow["PART_QTY"].toInt() <= (frmRow["ACT_QTY"].toInt() + frmRow["OK_QTY"].toInt()))
                    {
                        //완료(동시진행 설비 존재시 계속 진행)
                        if(isSameMcIng) paramRow2["WO_FLAG"] = 2;
                        else paramRow2["WO_FLAG"] = 4;

                        paramRow2["PANEL_STAT"] = (int)PANEL_STAT.완료;
                        paramRow2["PROC_STAT"] = 4;
                    }
                    else
                    {
                        //중지(동시진행 설비 존재시 계속 진행)
                        if (isSameMcIng) paramRow2["WO_FLAG"] = 2;
                        else paramRow2["WO_FLAG"] = 3;
                        paramRow2["PANEL_STAT"] = (int)PANEL_STAT.중지;
                        paramRow2["PROC_STAT"] = 3;
                    }

                    paramRow2["NULL_END_TIME"] = 1;
                    paramRow2["MC_NM_CHECK"] = 0;
                    paramRow2["MULTI_START_CNT"] = 1;
                    paramRow2["OK_QTY"] = frmRow["OK_QTY"];
                    paramRow2["NG_QTY"] = frmRow["NG_QTY"];
                    paramRow2["ACT_END_TIME"] = DateTime.Now;

                    if (frmRow["MASTER_CAUSE"].ToString() != "")
                    {
                        DataRow paramRow3 = paramTable3.NewRow();
                        paramRow3["MASTER_CAUSE"] = frmRow["MASTER_CAUSE"];
                        paramRow3["DETAIL_CAUSE"] = frmRow["DETAIL_CAUSE"];
                        paramRow3["EMP_CODE"] = _strEmpCode;
                        paramRow3["MC_CODE"] = _strMcCode;
                        paramRow3["QUANTITY"] = frmRow["NG_QTY"];
                        paramTable3.Rows.Add(paramRow3);
                    }


                    paramTable2.Rows.Add(paramRow2);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable2);
                    paramSet.Tables.Add(paramTable3);


                    BizRun.QBizRun.ExecuteService(this, "POP04A_INS3", paramSet, "RQSTDT,RQSTDT_NG", "RSLTDT");

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return false;
            }
        }


        private bool MultiRegAct(DataTable dt)
        {
            try
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

                if (!dt.Columns.Contains("EMP_CODE")) dt.Columns.Add("EMP_CODE", typeof(string));
                if (!dt.Columns.Contains("EMP_NAME")) dt.Columns.Add("EMP_NAME", typeof(string));
                if (!dt.Columns.Contains("MC_CODE")) dt.Columns.Add("MC_CODE", typeof(string));
                if (!dt.Columns.Contains("MC_NAME")) dt.Columns.Add("MC_NAME", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["EMP_CODE"] = _strEmpCode;
                    row["EMP_NAME"] = _strEmpName;
                    row["MC_CODE"] = _strMcCode;
                    row["MC_NAME"] = _strMcName;
                }

                RegAct3 frm = new RegAct3(dt);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool isSameMcIng = false;
                    if (dt.Rows[0]["ING_EMP"].toStringEmpty().Split(',').Length > 1)
                    {
                        //여러 설비가 동시 진행
                        isSameMcIng = true;
                    }

                    DataRow frmRow = frm.OutputData as DataRow;

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable2.Columns.Add("WO_NO", typeof(String)); //
                    paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable2.Columns.Add("WO_FLAG", typeof(String)); //
                    paramTable2.Columns.Add("PANEL_STAT", typeof(String)); //
                    paramTable2.Columns.Add("PROC_STAT", typeof(String)); //
                    paramTable2.Columns.Add("NULL_END_TIME", typeof(String)); //
                    paramTable2.Columns.Add("MC_NM_CHECK", typeof(String)); //
                    paramTable2.Columns.Add("MULTI_START_CNT", typeof(String)); //
                    paramTable2.Columns.Add("OK_QTY", typeof(int)); //
                    paramTable2.Columns.Add("NG_QTY", typeof(int)); //
                    paramTable2.Columns.Add("ACT_END_TIME", typeof(DateTime)); //

                    DataTable paramTable3 = new DataTable("RQSTDT_NG");
                    paramTable3.Columns.Add("MASTER_CAUSE", typeof(String)); //
                    paramTable3.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                    paramTable3.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable3.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable3.Columns.Add("QUANTITY", typeof(int)); //

                    DateTime startTime = DateTime.Now;

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["EMP_CODE"] = _strEmpCode;
                        paramRow2["WO_NO"] = row["WO_NO"];
                        //paramRow2["CHAIN_WO_NO"] = dt.Rows[0]["CHAIN_WO_NO"];
                        paramRow2["MC_CODE"] = _strMcCode;
                        if (isSameMcIng) paramRow2["WO_FLAG"] = 2;
                        else paramRow2["WO_FLAG"] = 3;
                        paramRow2["PANEL_STAT"] = (int)PANEL_STAT.중지;
                        paramRow2["PROC_STAT"] = 3;

                        //// 계획수량 <= (이전수량 + 완료수량)
                        //if (frmRow["PART_QTY"].toInt() <= (frmRow["ACT_QTY"].toInt() + frmRow["OK_QTY"].toInt()))
                        //{
                        //    //완료(동시진행 설비 존재시 계속 진행)
                        //    if (isSameMcIng) paramRow2["WO_FLAG"] = 2;
                        //    else paramRow2["WO_FLAG"] = 4;

                        //    paramRow2["PANEL_STAT"] = (int)PANEL_STAT.완료;
                        //    paramRow2["PROC_STAT"] = 4;
                        //}
                        //else
                        //{
                        //    //중지(동시진행 설비 존재시 계속 진행)
                        //    if (isSameMcIng) paramRow2["WO_FLAG"] = 2;
                        //    else paramRow2["WO_FLAG"] = 3;
                        //    paramRow2["PANEL_STAT"] = (int)PANEL_STAT.중지;
                        //    paramRow2["PROC_STAT"] = 3;
                        //}

                        paramRow2["NULL_END_TIME"] = 1;
                        paramRow2["MC_NM_CHECK"] = 0;
                        paramRow2["MULTI_START_CNT"] = 1;
                        paramRow2["OK_QTY"] = frmRow["OK_QTY"];
                        paramRow2["NG_QTY"] = frmRow["NG_QTY"];
                        paramRow2["ACT_END_TIME"] = startTime;

                        paramTable2.Rows.Add(paramRow2);

                    }



                    if (frmRow["MASTER_CAUSE"].ToString() != "")
                    {
                        DataRow paramRow3 = paramTable3.NewRow();
                        paramRow3["MASTER_CAUSE"] = frmRow["MASTER_CAUSE"];
                        paramRow3["DETAIL_CAUSE"] = frmRow["DETAIL_CAUSE"];
                        paramRow3["EMP_CODE"] = _strEmpCode;
                        paramRow3["MC_CODE"] = _strMcCode;
                        paramRow3["QUANTITY"] = frmRow["NG_QTY"];
                        paramTable3.Rows.Add(paramRow3);
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable2);
                    paramSet.Tables.Add(paramTable3);


                    BizRun.QBizRun.ExecuteService(this, "POP04A_INS3_2", paramSet, "RQSTDT,RQSTDT_NG", "RSLTDT");

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return false;
            }
        }


        private void UpdSearch()
        {
            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String));   //
            //paramTable.Columns.Add("CONF_NAME", typeof(String));  //
            //paramTable.Columns.Add("CONF_VALUE", typeof(String)); //

            //DataRow paramRow2 = paramTable.NewRow();
            //paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow2["CONF_NAME"] = "POP_MC_CODE";
            //paramRow2["CONF_VALUE"] = _strMcCode;

            //paramTable.Rows.Add(paramRow2);

            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //// 작업자가 사용한 마지막 설비를 업데이트 
            //BizRun.QBizRun.ExecuteService(this, "POP04A_UPD2", paramSet, "RQSTDT", "");

            if(!Directory.Exists(_RootFolderPath))
            {
                Directory.CreateDirectory(_RootFolderPath);
            }

            System.IO.File.WriteAllText(_RootFolderPath + "\\ActivePOP.ini", _strMcCode);

            //lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, _strMcName, _strEmpName);
            lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);

            //acInfo.EmpConfig.UpdateMemoryEmpConfig();

            this.search();
        }


        DateTime nowDate = DateTime.Now;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nowDate.ToString("yyyyMMdd") != acDateEdit.GetNowDateFromServer().ToString("yyyyMMdd"))
            {
                acLayoutControl1.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-7);
                acLayoutControl1.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();

                nowDate = acDateEdit.GetNowDateFromServer();
            }

            this.search();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            acTabControl1.SelectedTabPageIndex = 1;
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            acTabControl1.SelectedTabPageIndex = 0;
        }

        private void GetPopKioskInfo()
        {
            try
            {
                //string lanIp = acNetWork.GetLanIPAddress();
                //string wanIp = acNetWork.GetWanIPAddress();
                string macAddr = acNetWork.GetMacAddress();

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MAC_ADDR", typeof(String));
                //paramTable.Columns.Add("LAN_IP", typeof(String));
                //paramTable.Columns.Add("WAN_IP", typeof(String));



                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MAC_ADDR"] = macAddr;
                //paramRow["LAN_IP"] = lanIp;
                //paramRow["WAN_IP"] = wanIp;
                paramTable.Rows.Add(paramRow);

                DataSet rsltSet = BizRun.QBizRun.ExecuteService(this, "POP04A_POP_INFO", paramSet, "RQSTDT", "RSLTDT");
                if(rsltSet.Tables.Contains("RSLTDT"))
                {
                    DataTable rsltDt = rsltSet.Tables["RSLTDT"];
                    if (rsltDt.Rows.Count == 0) return;
                    //lblPOPName.Text = rsltDt.Rows[0]["PANEL_NAME"].toStringEmpty();
                    _strMcGroup = rsltDt.Rows[0]["MC_GROUP"].ToString();
                }

            }
            catch{
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            //FileList frm = new FileList(focusRow);

            //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            //frm.ParentControl = this;

            //frm.ShowDialog(this);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WO_NO", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("CHAIN_WO_NO", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = focusRow["WO_NO"];
            paramRow["PT_ID"] = focusRow["PT_ID"];
            paramRow["CHAIN_WO_NO"] = focusRow["CHAIN_WO_NO"];
            paramRow["PROD_CODE"] = focusRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_SER18", paramSet, "RQSTDT", "RSLTDT",
                               QuickFile,
                               QuickException);

        }

        void QuickFile(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_strMcCode == "")
                {
                    acMessageBox.Show(this, "설비가 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                acFTP acFtp1 = new acFTP();
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                    acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                    acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                    acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                    acFtp1.FileType = FileType.Image;
                    acFtp1.DoEvents = true;
                    acFtp1.Passive = true;
                    acFtp1.Restart = false;
                }

                string dir = "";

                string orginfilename = "";
                string filename = "";
                string fileID = "";

                bool isFile = false;

                int i = 0;
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    isFile = true;
                    dir = row["REG_DATE"].ToString().Substring(0, 10);

                    orginfilename = row["FILE_NAME"].ToString();
                    filename = row["FILE_ID"].ToString() + getExtName(row["FILE_NAME"].ToString());
                    fileID = row["FILE_ID"].ToString();

                    //string filePath = @"C:\ncopt\Ncdata";
                    string filePath = acInfo.SysConfig.GetSysConfigByServer("POP_FILE_DIR");
                    //FileInfo fInfo = new FileInfo(filePath);

                    if (i == 0)
                    {
                        DirectoryInfo dInfo = new DirectoryInfo(filePath);
                        if (dInfo.Exists)
                        {
                            foreach (FileInfo fInfo in dInfo.GetFiles())
                            {
                                fInfo.Delete();
                            }
                        }
                    }

                    i++;


                    string fileDir = string.Format(@"{0}\{1}", filePath, orginfilename);

                    FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileDir);
                }

                if (isFile)
                {
                    //acAlert.Show(this, "완료되었습니다.", acAlertForm.enmType.Success);

                    woStart_ButtonClick(null, null);

                }
                else
                {
                    acAlert.Show(this, "파일이 없습니다.", acAlertForm.enmType.Warning);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        string getExtName(string filename)
        {

            string[] str = filename.Split('.');

            if (str.Length > 1)
            {
                string extname = str[str.Length - 1];
                return "." + extname;
            }
            else
            {
                return "";
            }
        }

        private void btnChangePan_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePanel frm = new ChangePanel();

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    DataRow frmRow = frm.OutputData as DataRow;

                    if (frmRow == null) return;

                    _strMcGroup = frmRow["MC_GROUP"].ToString();

                    _strMcCode = "";
                    _strMcName = "";
                    

                    UpdSearch();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnActCancel_Click(object sender, EventArgs e)
        {
            //진행취소

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            if (acMessageBox.Show("진행 취소 하시겠습니까?", "진행취소", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WO_NO", typeof(string));
            paramTable.Columns.Add("CHAIN_WO_NO", typeof(string));
            paramTable.Columns.Add("PROC_CODE", typeof(string));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = focusRow["WO_NO"];
            paramRow["CHAIN_WO_NO"] = focusRow["CHAIN_WO_NO"];
            paramRow["PROC_CODE"] = focusRow["PROC_CODE"];
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_UPD7", paramSet, "RQSTDT", "RSLTDT",
                   QuickCancel,
                   QuickException);
        }

        void QuickCancel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                _StrMsg = "진행중인 작업이 없습니다.";
                lb_info.BackColor = Color.Transparent;
                lb_info.ForeColor = Color.Black;
                lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, "장비명 : " + _strMcName + ",", " 작업자 : " + _strEmpName);
                IsWorking = false;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {

            //if (_strMcCode == "")
            //{
            //    acMessageBox.Show(this, "설비가 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}

            //진행되지 않은 건

            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("MC_CODE", typeof(String)); //
            //paramTable.Columns.Add("MC_GROUP", typeof(String)); //
            //paramTable.Columns.Add("IS_FINISH", typeof(Boolean)); // 

            //if (_strMcGroup.isNullOrEmpty()) _strMcGroup = "GROUP"; // 설비가 선택 안된 상태에서 잘못된 조회를 막기위함

            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["MC_CODE"] = _strMcCode;
            //paramRow["MC_GROUP"] = _strMcGroup;
            //paramRow["IS_FINISH"] = IS_FINISH;

            //paramTable.Rows.Add(paramRow);

            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP04A_SER3", paramSet, "RQSTDT", "RSLTDT",
            //       QuickSearch,
            //       QuickException);

            search();
        }
    }
}
