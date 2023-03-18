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

namespace POP
{
    public sealed partial class POP04A_M0A : BaseMenu
    {


        public override void BarCodeScanInput(string barcode)
        {
        }



        public POP04A_M0A()
        {
            InitializeComponent();
        }

        private string _strMcCode = "";
        private string _strMcName = "";
        private string _strEmpCode = acInfo.UserID;
        private string _strEmpName = acInfo.UserName;
        private string _strIdleCode = "";
        private string _strIdleName = "";
        private string _strIdleStartTime = "";
        
        private string _StrMsg = "진행중인 작업이 없습니다";

        private bool idleState = false;
        private bool _bIdle = false;        //true:비가동, false:작업중단

        private DateTime nowDate = DateTime.Today;
        //private string _strWeek = "";
        private string _strDay = "";
        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public override void MenuInit()
        {
            workOrderGridView.GridType = acGridView.emGridType.SEARCH;
            workOrderGridView.OptionsView.ColumnAutoWidth = true;
            workOrderGridView.OptionsView.ShowIndicator = false;

            lb_info.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
            lb_info.ForeColor = Color.Black;

            // 상태관련

            workOrderGridView.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            workOrderGridView.Columns["WO_FLAG"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            #region 작업시작
            if (1 == 1)  // 동일 변수명을 사용하기 위해 If(1==1) 처리
            {
                acGridColumn colCommand = workOrderGridView.Columns.AddVisible("ACT_START") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_72_play2x, Color.Navy));
                button.ToolTip = "작업시작";
                //button.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woStart_ButtonClick;

                workOrderGridControl.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;
                workOrderGridView.Columns["ACT_START"].Caption = "시작";
                workOrderGridView.Columns["ACT_START"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                workOrderGridView.Columns["ACT_START"].VisibleIndex = 2;
                workOrderGridView.Columns["ACT_START"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            #endregion

            #region 작업중지
            if(1==1)
            {
                acGridColumn colCommand = workOrderGridView.Columns.AddVisible("ACT_STOP") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_73_pause2x, Color.Navy));
                button.ToolTip = "작업중지";
                //button.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woStop_ButtonClick;

                workOrderGridControl.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;
                workOrderGridView.Columns["ACT_STOP"].Caption = "중지";
                workOrderGridView.Columns["ACT_STOP"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                workOrderGridView.Columns["ACT_STOP"].VisibleIndex = 3;
                workOrderGridView.Columns["ACT_STOP"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
               
            }
            #endregion

            #region 작업완료
            if (1==1)
            {
                acGridColumn colCommand = workOrderGridView.Columns.AddVisible("ACT_END") as acGridColumn;
                colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_74_stop2x, Color.Navy));
                button.ToolTip = "작업완료";
                //button.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);

                riButtonEdit.Buttons.Clear();
                riButtonEdit.Buttons.Add(button);
                riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                riButtonEdit.ReadOnly = true;
                riButtonEdit.ButtonClick += woEnd_ButtonClick;

                workOrderGridControl.RepositoryItems.Add(riButtonEdit);
                colCommand.ColumnEdit = riButtonEdit;
                workOrderGridView.Columns["ACT_END"].Caption = "완료";
                workOrderGridView.Columns["ACT_END"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                workOrderGridView.Columns["ACT_END"].VisibleIndex = 4;
                workOrderGridView.Columns["ACT_END"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
               
            }
            #endregion


            workOrderGridView.AddTextEdit("PLT_CODE", "사업장코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("CVND_CODE", "수주처\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("CVND_NAME", "고객사", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddLookUpEdit("PROD_FLAG", "수주유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            workOrderGridView.AddLookUpEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P009");
            workOrderGridView.AddTextEdit("TEMP1", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("TEMP3", "가공소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("ACT_QTY", "완료수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("TEMP6", "CAM담당", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("TEMP7", "X", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);
            workOrderGridView.AddTextEdit("TEMP8", "Y", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);
            workOrderGridView.AddTextEdit("TEMP9", "소재", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("TEMP10", "두께", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            workOrderGridView.AddTextEdit("TEMP11", "특이사항", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            #region TEMP1
            //workOrderGridView.AddTextEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddLookUpEdit("JOB_PRIORITY", "우선\n순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");
            //workOrderGridView.AddTextEdit("PART_CODE", "품목\n코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PART_NAME", "품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("DRAW_NO", "도면\n번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("MAT_SPEC1", "제품\n사양", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //workOrderGridView.AddTextEdit("SCOMMENT", "지시사항", "D5RQPURL", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("PART_QTY", "계획\n수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("ACT_QTY", "완료\n수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddTextEdit("WORK_PROGRESS", "진행률", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //workOrderGridView.AddLookUpEdit("WO_FLAG", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

            //workOrderGridView.AddTextEdit("colATTACH", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //workOrderGridView.AddDateEdit("PLN_START_TIME", "계획시작시간", "10613", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            //workOrderGridView.AddDateEdit("PLN_END_TIME", "계획완료시간", "10614", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            #endregion


            workOrderGridView.KeyColumn = new string[] { "WO_NO" };

            workOrderGridView.RowHeight = 45;

            workOrderGridView.ColumnPanelRowHeight = 70;

            //_strWeek = GetJuCha(nowDate);
            _strDay = nowDate.toDateString("yyyyMMdd");

            //DateTime sDate, eDate;
            //this.GetJuStartEndDate(nowDate, out sDate, out eDate);

            // TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");//sDate.toDateString("yy/MM/dd") + " ∼ " + eDate.toDateString("yy/MM/dd");

            // EmpLabel.Text = _strEmpName;
           
            _strEmpName = " [" + _strEmpName + "]";

            lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, _strMcName, _strEmpName); 

           // btnAll.Text = "전체\n작업";

            workOrderGridView.FocusedRowChanged += workOrderGridView_FocusedRowChanged;

            workOrderGridView.CustomRowCellEdit += workOrderGridView_CustomRowCellEdit;

            workOrderGridView.MouseUp += workOrderGridView_MouseUp;

           // workOrderGridControl.Paint += workOrderGridControl_Paint;

            SetPopGridFont(workOrderGridView, null);

            #region 컨트롤 설정


            //TimeLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
            //        FontStyle.Regular, GraphicsUnit.Point);

            //McLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
            //        FontStyle.Regular, GraphicsUnit.Point);

            //EmpLabel.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
            //        FontStyle.Regular, GraphicsUnit.Point);

            //simpleLabelItem2.AppearanceItemCaption.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 7,
            //        FontStyle.Bold, GraphicsUnit.Point);


            //lb_Msg.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 6,
            //          FontStyle.Regular, GraphicsUnit.Point);

            lb_info.Appearance.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 6,
                     FontStyle.Regular, GraphicsUnit.Point);




            Control[] con = formcount(this);
            foreach (Control down in con) // 컨트롤이 버튼인 경우 폰트를 일치시킨다.
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 2,
                    FontStyle.Regular, GraphicsUnit.Point);
                }

                else if (down.Name.StartsWith("chk"))
                {
                    ((ControlManager.acCheckEdit)down).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 3,
                    FontStyle.Regular, GraphicsUnit.Point);
                }

            }

         //   ControlCollection ctrBtns = acLayoutControl3.Controls;

            //foreach (Control ctr in ctrBtns)
            //{
            //    if (ctr.Name.StartsWith("btn"))
            //    {
            //        ((ControlManager.acSimpleButton)ctr).Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 20,
            //        FontStyle.Regular, GraphicsUnit.Point);
            //    }
            //}

   

            #endregion

            base.MenuInit();
        }

        void workOrderGridView_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataRow focus = workOrderGridView.GetFocusedDataRow();

                GridHitInfo hitInfo = workOrderGridView.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    if (hitInfo.Column.FieldName == "colATTACH" && focus["ATT_QTY"].toInt() > 0)
                    {


                        AttachFileList frm = new AttachFileList(workOrderGridView.GetRowCellValue(hitInfo.RowHandle, workOrderGridView.Columns["PART_CODE"]));

                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;



                        base.ChildFormAdd("NEW", frm);

                        frm.ShowDialog();

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }


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

            //this.McSetting();

            //if (_strMcCode != "")
            //{
            //    this.search(_isAll);
            //}
            //else
            //{
            //    //WorkStat();
            //}
        }


        // 뭔지모름
        //void workOrderGridControl_Paint(object sender, PaintEventArgs e)
        //{
        //    if (idleState == true)
        //    {
        //        //  string msg = string.Format("{0}\n\n{1}\n\n{2} ∼", simpleLabelItem2.Text + " 중" , "사유 : " + _strIdleName, _strIdleStartTime);

        //        string msg = string.Empty; // 위에 주석처리로 임시추가

        //        SizeF fSizef = e.Graphics.MeasureString(msg, acInfo.LabelTextFont);

        //        Size fSize = fSizef.ToSize();

        //        Rectangle textBox = new Rectangle(0, 0, (workOrderGridControl.Width / 3), (workOrderGridControl.Height / 2));

        //        Point pt = GetCenterLocation(new Rectangle(0, 0, workOrderGridControl.Width, workOrderGridControl.Height), textBox);

        //        textBox = new Rectangle(pt.X, pt.Y, (workOrderGridControl.Width / 3), (workOrderGridControl.Height / 2));

        //        Color idleColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_IDLE").toColor();

        //        Brush idleBrush = new SolidBrush(idleColor);


        //        e.Graphics.FillRectangle(idleBrush, textBox);

        //        StringFormat sf = new StringFormat();

        //        sf.Alignment = StringAlignment.Center;
        //        sf.LineAlignment = StringAlignment.Center;

        //        Font font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
        //            FontStyle.Regular, GraphicsUnit.Point);

        //        e.Graphics.DrawString(msg, font, Brushes.White, textBox, sf);
        //    }
        //}

        
        void workOrderGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow focus = workOrderGridView.GetFocusedDataRow();
            workOrderGridView.Appearance.FocusedRow.Options.UseBackColor = true;

            if (focus != null)
            {
                switch (focus["WO_FLAG"].ToString())
                {
                    case "1":
                        workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
                        workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();
                        workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;
                        break;

                    case "2":

                        workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
                        workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();
                        workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

                        break;

                    case "3":

                        workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
                        workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();
                        workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

                        break;

                    case "4":

                        workOrderGridView.Appearance.FocusedRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();
                        workOrderGridView.Appearance.HideSelectionRow.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();
                        workOrderGridView.Appearance.FocusedRow.ForeColor = Color.Black;

                        break;
                }
            }

            //WorkStat();
        }

        private void workOrderGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (workOrderGridView.FocusedRowHandle != e.RowHandle)
            {
                DataRowView view = (DataRowView)workOrderGridView.GetRow(e.RowHandle);

                if (view != null)
                {
                    switch (view.Row["WO_FLAG"].ToString())
                    {
                        case "1": // 작업확정  ("0": 미확인)

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();

                            break;

                        case "2":  //작업진행

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();

                            break;

                        case "3":  //작업정지

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_PAUSE").toColor();

                            break;

                        case "4":  //작업완료

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_FINISH").toColor();

                            break;
                    }
                }
            }
        }


        // 시작/중지/완료 버튼 활성화 조건
        private void workOrderGridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            DataView dv = workOrderGridView.GetDataSourceView();

            if (dv.Count == 0) return;
            if (e.RowHandle < 0) return;

            string status = workOrderGridView.GetRowCellValue(e.RowHandle, "WO_FLAG").ToString();

            if (e.Column.FieldName == "ACT_START")
            {
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_72_play2x, Color.Navy));
                button.ToolTip = "작업시작";

                if (status == "2")
            
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
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_73_pause2x, Color.Navy));
                button.ToolTip = "작업중지";

                if (status == "2")
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
            else if (e.Column.FieldName == "ACT_END")
            {
                RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::POP.Resource.glyphicons_halflings_74_stop2x, Color.Navy));
                button.ToolTip = "작업완료";

                if (status == "2" || status == "3")  // 작지상태가 진행이거나 중지인 경우 활성화
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
            ChangeMC2 frm = new ChangeMC2(_strEmpCode);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            base.ChildFormAdd("NEW", frm);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = frm.OutputData as DataRow;

                if (frmRow == null) return;

                _strMcCode = frmRow["MC_CODE"].ToString();
                _strMcName = frmRow["MC_NAME"].ToString();

                _strMcName = " [" + _strMcName + "]";

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //
                paramTable.Columns.Add("CONF_VALUE", typeof(String)); //
                
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_NAME"] = "POP_MC_CODE";
                paramRow["CONF_VALUE"] = _strMcCode;
                paramTable.Rows.Add(paramRow);

                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                // 작업자가 사용한 마지막 설비를 업데이트 
                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_UPD2", paramSet, "RQSTDT", "");

                // McLabel.Text = _strMcName;

                lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, _strMcName, _strEmpName);

                //TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");
                acInfo.EmpConfig.UpdateMemoryEmpConfig();

                // this.search(_isAll);
                this.search(); //temp add 

            }
        }

        private void btnChangeEmp_Click(object sender, EventArgs e)
        {
            ChangeEmp frm = new ChangeEmp();

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            //frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK) 
            {
                DataTable frmTable = frm.OutputData as DataTable;

                DataRow frmRow = frmTable.Rows[0];

                _strEmpCode = frmRow["EMP_CODE"].ToString();
                _strEmpName = frmRow["EMP_NAME"].ToString();

                _strEmpName = " [" + _strEmpName + "]";

                // EmpLabel.Text = _strEmpName;

                // lb_info.Text = _strEmpName;

                lb_info.Text = string.Format("{0}\n{1} {2}", _StrMsg, _strMcName, _strEmpName);

            }
        }

        private void btnActHandling_Click(object sender, EventArgs e)
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

            RegHandAct frm = new RegHandAct(paramTable.Rows[0]);

            //frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                DataRow frmRow = frm.OutputData as DataRow;

            }
        }

        /// <summary>
        /// 시작(버튼)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void woStart_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow focuseRow = workOrderGridView.GetFocusedDataRow();

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


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER5", paramMcSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT_WO"].Rows.Count == 0)
            {
                acMessageBox.Show("선택한 작업지시가 유효하지 않습니다. 작업을 재조회 후에 진행하십시오.", "작업 시작", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {
                if (!resultSet.Tables["RSLTDT"].Rows[0]["IS_MULTI_START"].EqualsEx(1))
                {
                    acMessageBox.Show(this, "진행 중인 다른 작업이 있습니다. \r\n다른 작업을 완료 후에 진행하십시오.", "VICJ5KO6", false, acMessageBox.emMessageBoxType.CONFIRM);

                    return;
                }
            }

            // 비가동상태에서 재시작하는 경우 
            if(focuseRow["WO_FLAG"].ToString() == "3")
            {
                if (acMessageBox.Show(this, "진행중인 작업을 중지하고 재시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                // 해당 실적에 대해 비가동 종료 처리를 먼저 실행
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


                // 신규 실적 생성
                DataTable paramActTable = new DataTable("RQSTDT_ACT");
                paramActTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramActTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramActTable.Columns.Add("WO_NO", typeof(String)); //
                paramActTable.Columns.Add("WO_FLAG", typeof(String)); //
                paramActTable.Columns.Add("MC_CODE", typeof(String)); //
                paramActTable.Columns.Add("WORK_DATE", typeof(String)); //
                paramActTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
                paramActTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
                paramActTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
                paramActTable.Columns.Add("PROC_STAT", typeof(String)); //
                paramActTable.Columns.Add("PANEL_STAT", typeof(String)); //

                DataRow paramActRow = paramActTable.NewRow();
                paramActRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramActRow["EMP_CODE"] = _strEmpCode;
                paramActRow["WO_NO"] = focuseRow["WO_NO"];
                paramActRow["WO_FLAG"] = 2; 
                paramActRow["MC_CODE"] = _strMcCode;
                paramActRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                paramActRow["MC_NM_CHECK"] = 0;
                paramActRow["ACT_START_TIME"] = DateTime.Now;
                paramActRow["MULTI_START_CNT"] = 1;
                paramActRow["PROC_STAT"] = 2;
                paramActRow["PANEL_STAT"] = 1;


                paramIdleTable.Rows.Add(paramIdleRow);
                paramActTable.Rows.Add(paramActRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramIdleTable);
                paramSet.Tables.Add(paramActTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS12", paramSet, "RQSTDT", "RSLTDT",
                       QuickIns,
                       QuickException);

            }
            else
            {
                if(focuseRow["WO_FLAG"].ToString() == "4")
                {
                    if (acMessageBox.Show(this, "재시작하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }
                }
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
                paramTable.Columns.Add("PROC_STAT", typeof(String)); //
                paramTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
                paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
                paramTable.Columns.Add("PANEL_STAT", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["WO_NO"] = focuseRow["WO_NO"];
                paramRow["WO_FLAG"] = 2;
                paramRow["MC_CODE"] = _strMcCode;
                paramRow["WORK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                paramRow["MC_NM_CHECK"] = 0;
                paramRow["PROC_STAT"] = 2;
                paramRow["ACT_START_TIME"] = DateTime.Now;
                paramRow["MULTI_START_CNT"] = 1;
                paramRow["PANEL_STAT"] = 1;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS9", paramSet, "RQSTDT", "RSLTDT",
                       QuickIns,
                       QuickException);

            }

        }

        void QuickIns(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                // this.search(_isAll);
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
                DataRow focuseRow = workOrderGridView.GetFocusedDataRow();

                if (acMessageBox.Show(this, "중지하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }
                {
                    idleState = true;  // 비가동상태로 변경
                }

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

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS10", paramSet, "RQSTDT", "RSLTDT",
                               QuickIns,
                               QuickException);

                    }
                }
                //else if (btnStop.Text.ToString() == "비가동 종료")
                //{

                //    WorkStopEnd frm = new WorkStopEnd(_strMcCode, _strEmpCode, true);

                //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                //    frm.ParentControl = this;

                //    base.ChildFormAdd("NEW", frm);

                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {

                //        this. search( );
                //    }
                //}

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
                DataRow focuseRow = workOrderGridView.GetFocusedDataRow();

                if (acMessageBox.Show(this, "완료하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                // if(focuseRow["WO_FLAG"])
                if (focuseRow["WO_FLAG"].ToString() == "3")   
                {

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("WO_NO", typeof(String)); //
                    paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                    paramTable.Columns.Add("END_TIME", typeof(DateTime)); //
                    paramTable.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable.Columns.Add("NULL_END_TIME", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = focuseRow["WO_NO"];
                    paramRow["WO_FLAG"] = 4;
                    paramRow["END_TIME"] = DateTime.Now;
                    paramRow["MC_CODE"] = _strMcCode;
                    paramRow["EMP_CODE"] = _strEmpCode;
                    paramRow["NULL_END_TIME"] = 1;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_UPD6", paramSet, "RQSTDT", "RSLTDT",
                           QuickIns,
                           QuickException);

                }
                // 진행상태에서 완료처리할 경우
                else
                {

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("WO_NO", typeof(String)); //
                    paramTable.Columns.Add("WO_FLAG", typeof(String)); //
                    paramTable.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                    paramTable.Columns.Add("ACT_END_TIME", typeof(DateTime));
                    paramTable.Columns.Add("NULL_END_TIME", typeof(String)); //


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = focuseRow["WO_NO"];
                    paramRow["WO_FLAG"] = 4;
                    paramRow["MC_CODE"] = _strMcCode;
                    paramRow["EMP_CODE"] = _strEmpCode;
                    paramRow["ACT_END_TIME"] = DateTime.Now;
                    paramRow["NULL_END_TIME"] = 1;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS11", paramSet, "RQSTDT", "RSLTDT",
                           QuickIns,
                           QuickException);
                }

            }
            catch (Exception ex)
            { }
        }



        // Search( ) 원본소스
        //void search(bool bAll)
        //{
        //    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("MC_CODE", typeof(String)); //
        //    paramTable.Columns.Add("W_DATE", typeof(String)); //일자//주차

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow["MC_CODE"] = _strMcCode;
        //    if (!bAll)
        //        paramRow["W_DATE"] = _strDay;//_strWeek;

        //    paramTable.Rows.Add(paramRow);

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER3", paramSet, "RQSTDT", "RSLTDT",
        //           QuickSearch,
        //           QuickException);
        //}


        void search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("IS_FINISH", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = _strMcCode;
            paramRow["IS_FINISH"] = acLayoutControl1.GetEditor("IS_FINISH").Value;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP20A_SER3_1", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                workOrderGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];


                workOrderGridView.SetOldFocusRowHandle(true);


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


        #region  버튼상태설정

        //private void WorkStat()
        //{
        //    try
        //    {
        //        if (_strMcCode != "")
        //        {
        //            btnActHandling.Enabled = true;
        //            //btnSearch.Enabled = true;
        //            btnActLog.Enabled = true;
        //           // btnLeft.Enabled = true;
        //            btnRight.Enabled = true;

        //            DataTable paramTable = new DataTable("RQSTDT");
        //            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //            paramTable.Columns.Add("MC_CODE", typeof(String)); //
        //            paramTable.Columns.Add("IDLE_STATE", typeof(String)); //

        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["MC_CODE"] = _strMcCode;
        //            paramRow["IDLE_STATE"] = 1;

        //            paramTable.Rows.Add(paramRow);
        //            DataSet paramSet = new DataSet();
        //            paramSet.Tables.Add(paramTable);

        //            //비가동 정보 조회
        //            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER7", paramSet, "RQSTDT", "RSLTDT");

        //            DataTable resultDT = resultSet.Tables["RSLTDT"];

        //            if (resultDT.Rows.Count != 0)
        //            {
        //                //wo_no가 있으면 작업중단
        //                string pause_wo_no = resultDT.Rows[0]["WO_NO"].ToString();
                        
        //                if (pause_wo_no == "")
        //                {
        //                    //==============비가동 중=============================
        //                    _strIdleCode = resultDT.Rows[0]["IDLE_CODE"].ToString();
        //                    _strIdleName = acStdCodes.GetNameByCodeServer("C010", _strIdleCode);

        //                    _strIdleStartTime = resultDT.Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm");
        //                    _bIdle = true;

        //                    btnStop.Text = "비가동 종료";
                            
        //                    simpleLabelItem2.Text = "비가동";
        //                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Violet;

        //                    btnStop.Enabled = true;
        //                }
        //                else
        //                {
        //                    //==============작업 중단 =============================
        //                    _strIdleCode = resultDT.Rows[0]["IDLE_CODE"].ToString();
        //                    _strIdleName = acStdCodes.GetNameByCodeServer("C009", _strIdleCode);

        //                    _strIdleStartTime = resultDT.Rows[0]["START_TIME"].toDateString("yyyy-MM-dd HH:mm");
        //                    _bIdle = false;

        //                    btnPause.Text = "작업\n중단\n종료";

        //                    simpleLabelItem2.Text = "작업 중단";
        //                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.IndianRed;

        //                    btnStop.Enabled = false;
                            
        //                }

        //                btnStart.Enabled = false;
        //                btnFinish.Enabled = false;
        //                btnChangeEmp.Enabled = false;
        //                btnChangeMc.Enabled = true;
        //                //btnStop.Enabled = true;

        //                btnCancel.Enabled = false;
        //                btnPre.Enabled = false;
        //                btnPause.Enabled = true;

        //                idleState = true;

        //                TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");
        //                //==============비가동 중=============================
        //            }
        //            else
        //            {
        //                btnChangeEmp.Enabled = true;
        //                btnChangeMc.Enabled = true;

        //                btnPause.Text = "작업\n중단";

        //                idleState = false;

        //                DataView dv = workOrderGridView.GetDataView("WO_FLAG = 2");

        //                if (dv.Count != 0)
        //                {
        //                    //=====================진행 중인 작업================================
        //                    btnStop.Enabled = false;
        //                    btnStop.Text = "비가동";
        //                    //simpleLabelItem2.Text = "가공 중";
        //                    simpleLabelItem2.Text = string.Format("진행 중인 작업 :: 지시번호 [{0}] 품목 [{1}] 공정 [{2}]",
        //                        dv[0]["WO_NO"].ToString(),
        //                        dv[0]["PART_CODE"].ToString() + "-" + dv[0]["PART_NAME"].ToString(),
        //                        dv[0]["PROC_NAME"].ToString());
        //                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.PowderBlue;
        //                    //=====================진행 중인 작업================================
        //                }
        //                else
        //                {
        //                    btnStop.Enabled = true;
        //                    btnStop.Text = "비가동";
        //                    simpleLabelItem2.Text = "진행중인 공정이 없습니다.";
        //                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Coral;
        //                }

        //                DataRow focus = workOrderGridView.GetFocusedDataRow();

        //                if (focus != null)
        //                {
        //                    //POP20A_SER16
        //                    DataTable dtParam = new DataTable("RQSTDT");
        //                    dtParam.Columns.Add("PLT_CODE", typeof(String)); //
        //                    dtParam.Columns.Add("WO_NO", typeof(String)); //
                            
        //                    DataRow drParam = dtParam.NewRow();
        //                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
        //                    drParam["WO_NO"] = focus["WO_NO"];
                            
        //                    dtParam.Rows.Add(drParam);
        //                    DataSet dsParam = new DataSet();
        //                    dsParam.Tables.Add(dtParam);

        //                    DataSet dsAct = BizRun.QBizRun.ExecuteService(this, "POP20A_SER16", dsParam, "RQSTDT", "RSLTDT");

        //                    int panel_stat = 0;

        //                    if (dsAct.Tables["RSLTDT"].Rows.Count > 0)
        //                    {
        //                        panel_stat = dsAct.Tables["RSLTDT"].Rows[0]["PANEL_STAT"].toInt();
        //                    }


        //                    if (focus["WO_FLAG"].ToString() == "1")             
        //                    {
        //                        //확정
        //                        btnStart.Enabled = true;
        //                        btnFinish.Enabled = false;

        //                        btnPre.Enabled = false;
        //                        btnPause.Enabled = false;
        //                        btnCancel.Enabled = false;
        //                    }
        //                    else if (focus["WO_FLAG"].ToString() == "2")
        //                    {
        //                        //진행
        //                        btnStart.Enabled = false;
        //                        btnFinish.Enabled = true;

        //                        if (panel_stat == 6)
        //                        {
        //                            btnPre.Enabled = false;
        //                            btnPause.Enabled = true;
        //                            btnCancel.Enabled = false;

        //                        }
        //                        else
        //                        {
        //                            btnPre.Enabled = true;
        //                            btnPause.Enabled = true;
        //                            btnCancel.Enabled = true;
        //                        }
                                
        //                    }
        //                    else if (focus["WO_FLAG"].ToString() == "3")
        //                    {
        //                        //중지
        //                        btnStart.Enabled = true;
        //                        btnFinish.Enabled = false;

        //                        btnPre.Enabled = false;
        //                        btnPause.Enabled = false;
        //                        btnCancel.Enabled = false;
        //                    }
        //                    else if (focus["WO_FLAG"].ToString() == "4")
        //                    {
        //                        //완료
        //                        btnStart.Enabled = true;
        //                        btnFinish.Enabled = false;

        //                        btnPre.Enabled = false;
        //                        btnPause.Enabled = false;
        //                        btnCancel.Enabled = false;
        //                    }

        //                }
        //                else
        //                {
        //                    btnStart.Enabled = false;
        //                    btnFinish.Enabled = false;

        //                    btnPre.Enabled = false;
        //                    btnPause.Enabled = false;
        //                    btnCancel.Enabled = false;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            //===========설비가 지정되지 않은 상태====================
        //            btnChangeEmp.Enabled = true;
        //            btnChangeMc.Enabled = true;
        //            btnStart.Enabled = false;
        //            btnFinish.Enabled = false;
        //            btnStop.Enabled = false;
        //            btnActHandling.Enabled = false;
        //          //  btnSearch.Enabled = false;
        //            btnActLog.Enabled = false;
        //          //  btnLeft.Enabled = false;
        //            btnRight.Enabled = false;

        //        }

                

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}
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

        // 조회버튼 
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    search(_isAll);
        //}



        public static Point GetCenterLocation(Rectangle parentRect, Rectangle childRect)
        {
            int x = parentRect.X + ((parentRect.Width / 2) - (childRect.Width / 2));

            int y = parentRect.Y + ((parentRect.Height / 2) - (childRect.Height / 2));

            return new Point(x, y);
        }

        
        
        private void btnLeft_Click(object sender, EventArgs e)
        {
            moveWeek(-1);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            moveWeek(1);
        }

        // 해당일자의 주수를 가져오는 방법:
        private string GetJuCha(DateTime Date)
        {

            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("ko-KR");

            return myCI.Calendar.GetWeekOfYear

            (Date, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday).ToString();


        }

        //해당일자의 월요일에서 금요일 가져오기
        private void GetJuStartEndDate(DateTime date, out DateTime sDate, out DateTime eDate)
        {
            DateTime dtToday = date;

            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwToday = ciCurrent.Calendar.GetDayOfWeek(dtToday);

            int iDiff = dwToday - dwFirst;
            DateTime dtFirstDayOfThisWeek = dtToday.AddDays(-iDiff + 1);
            DateTime dtLastDayOfThisWeek = dtFirstDayOfThisWeek.AddDays(4);

            sDate = dtFirstDayOfThisWeek;
            eDate = dtLastDayOfThisWeek;
        }



        void moveWeek(double day)
        {
            
            //_strWeek = GetJuCha(nowDate.AddDays(day));
            _strDay = nowDate.AddDays(day).toDateString("yyyyMMdd");

            //DateTime sDate, eDate;
            //this.GetJuStartEndDate(nowDate.AddDays(day), out sDate, out eDate);

            nowDate = nowDate.AddDays(day);

            // TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");

            // this.search(_isAll);
            this.search();  // temp add
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
            ActLog frm = new ActLog(_strMcCode);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            base.ChildFormAdd("NEW", frm);

            frm.ShowDialog();
        }

        void McSetting()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            if (acInfo.EmpConfig.GetEmpConfigByMemory("POP_MC_CODE").ToString() != "0")
            {
                paramRow["MC_CODE"] = acInfo.EmpConfig.GetEmpConfigByMemory("POP_MC_CODE");
            }
            
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER9", paramSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {
                _strMcCode = resultSet.Tables["RSLTDT"].Rows[0]["MC_CODE"].ToString();
                _strMcName = resultSet.Tables["RSLTDT"].Rows[0]["MC_NAME"].ToString();

               // McLabel.Text = _strMcName;
              //  TimeLabel.Text = DateTime.Now.toDateString("yyyy-MM-dd HH:mm");
            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //자주검사
            try
            {
                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("EMP_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["EMP_CODE"] = _strEmpCode;
                paramRow["EMP_NAME"] = _strEmpName;
                paramTable.Rows.Add(paramRow);

                DataRow focus = workOrderGridView.GetFocusedDataRow();

                if (focus["PART_QTY"].toInt() > 0)
                {
                    RegCheck frm = new RegCheck(focus, paramTable.Rows[0]);

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

        private void btnNActLog_Click(object sender, EventArgs e)
        {
            try 
            {
                //불량내역
                DataRow focusRow = workOrderGridView.GetFocusedDataRow();

                if (focusRow == null) return;

                NgLog frm = new NgLog(focusRow, "");

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

        //private void acSimpleButton1_Click(object sender, EventArgs e)
        //{
        //    if (acMessageBox.Show(acInfo.Resource.GetString("정말 종료하시겠습니까?", "XPCDAJOT"), acInfo.SystemName, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //}

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        bool _isAll = false;


        // 전체 작업조회
        //private void btnAll_Click(object sender, EventArgs e)
        //{
        //    if (btnAll.Text == "전체\n작업")
        //    {
        //        _isAll = true;
        //        this.search(_isAll);
        //        btnAll.Text = "당일\n작업";
        //    }
        //    else
        //    {
        //        _isAll = false;
        //        this.search(_isAll);
        //        btnAll.Text = "전체\n작업";
        //    }
        //}

        /// <summary>
        /// 작업취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //delete tpop_pannel_log
        //        //진행 중인 작업지시 선택 -> 작업 취소

        //        DataRow focusedRow = workOrderGridView.GetFocusedDataRow();

        //        //wo_no, emp_code, mc_code, panel_stat
        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String)); 
        //        paramTable.Columns.Add("WO_NO", typeof(String)); 
        //        paramTable.Columns.Add("EMP_CODE", typeof(String)); 
        //        paramTable.Columns.Add("MC_CODE", typeof(String));
        //        paramTable.Columns.Add("W_DATE", typeof(String)); 

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["WO_NO"] = focusedRow["WO_NO"];
        //        paramRow["EMP_CODE"] = _strEmpCode;
        //        paramRow["MC_CODE"] = _strMcCode;
        //        paramRow["W_DATE"] = _strDay;

        //        paramTable.Rows.Add(paramRow);

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP20A_UPD3", paramSet, "RQSTDT", "RSLTDT",
        //            QuickSearch,
        //            QuickException);
               

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}

        /// <summary>
        /// 준비완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnPre_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataRow focus = workOrderGridView.GetFocusedDataRow();

        //        if (focus == null) return;

        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
        //        paramTable.Columns.Add("WO_NO", typeof(String)); //
        //        paramTable.Columns.Add("MC_CODE", typeof(String)); //
        //        paramTable.Columns.Add("PANEL_STAT", typeof(String)); //
        //        paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
        //        paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
        //        paramTable.Columns.Add("OK_QTY", typeof(int)); //
        //        paramTable.Columns.Add("NG_QTY", typeof(int)); //
        //        paramTable.Columns.Add("PAUSE_REASON", typeof(String)); //

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["EMP_CODE"] = _strEmpCode;
        //        paramRow["WO_NO"] = focus["WO_NO"];
        //        paramRow["MC_CODE"] = _strMcCode;

        //        paramRow["PANEL_STAT"] = 6;
        //        paramRow["MC_NM_CHECK"] = 0;
        //        paramRow["MULTI_START_CNT"] = 1;

        //        paramTable.Rows.Add(paramRow);

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS6", paramSet, "RQSTDT", "",
        //        //       QuickIns,
        //        //       QuickException);

        //        BizRun.QBizRun.ExecuteService(this, "POP20A_INS6", paramSet, "RQSTDT", "");

        //        WorkStat();

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}

        /// <summary>
        /// 작업중단
        ///  : 진행 중인 작업에서만 유효
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnPause_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //작어중단 종료
        //        if (idleState && !_bIdle)
        //        {
        //            WorkStopEnd frmEnd = new WorkStopEnd(_strMcCode, _strEmpCode, false);

        //            frmEnd.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //            frmEnd.ParentControl = this;

        //            base.ChildFormAdd("NEW", frmEnd);

        //            if (frmEnd.ShowDialog() == DialogResult.OK)
        //                search(_isAll);

        //            WorkStat();
        //            return;

        //        }

        //        DataRow focusRow = workOrderGridView.GetFocusedDataRow();

        //        if (!focusRow["WO_FLAG"].Equals("2")) return;

        //        WorkStop frm = new WorkStop("C009");

        //        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

        //        frm.ParentControl = this;

        //        base.ChildFormAdd("NEW", frm);

        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            DataRow frmRow = frm.OutputData as DataRow;

        //            #region PANEL_ PARAM TABLE
        //            DataTable paramTable = new DataTable("RQSTDT_PANEL");
        //            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
        //            paramTable.Columns.Add("WO_NO", typeof(String)); //
        //            paramTable.Columns.Add("MC_CODE", typeof(String)); //
        //            paramTable.Columns.Add("PANEL_STAT", typeof(String)); //
        //            paramTable.Columns.Add("MC_NM_CHECK", typeof(String)); //
        //            paramTable.Columns.Add("MULTI_START_CNT", typeof(String)); //
        //            paramTable.Columns.Add("OK_QTY", typeof(int)); //
        //            paramTable.Columns.Add("NG_QTY", typeof(int)); //
        //            paramTable.Columns.Add("PAUSE_REASON", typeof(String)); //

        //            #endregion
        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["EMP_CODE"] = _strEmpCode;
        //            paramRow["WO_NO"] = focusRow["WO_NO"];
        //            paramRow["MC_CODE"] = _strMcCode;
        //            paramRow["PANEL_STAT"] = 2;
        //            paramRow["MC_NM_CHECK"] = 0;
        //            paramRow["MULTI_START_CNT"] = 1;
        //            paramTable.Rows.Add(paramRow);

        //            #region IDLE_ PARAM TABLE
        //            DataTable paramIdleTable = new DataTable("RQSTDT_IDLE");
        //            paramIdleTable.Columns.Add("PLT_CODE", typeof(String)); //
        //            paramIdleTable.Columns.Add("MC_CODE", typeof(String)); //
        //            paramIdleTable.Columns.Add("EMP_CODE", typeof(String)); //
        //            paramIdleTable.Columns.Add("IDLE_CODE", typeof(String)); //
        //            paramIdleTable.Columns.Add("IDLE_TIME", typeof(String)); //
        //            paramIdleTable.Columns.Add("IDLE_STATE", typeof(String)); //
        //            paramIdleTable.Columns.Add("SCOMMENT", typeof(String)); //
        //            paramIdleTable.Columns.Add("WO_NO", typeof(String)); //
        //            paramIdleTable.Columns.Add("REG_EMP", typeof(String)); //
        //            paramIdleTable.Columns.Add("DATA_FLAG", typeof(String)); //
        //            #endregion

        //            DataRow paramIdleRow = paramIdleTable.NewRow();
        //            paramIdleRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramIdleRow["MC_CODE"] = _strMcCode;
        //            paramIdleRow["EMP_CODE"] = _strEmpCode;
        //            paramIdleRow["IDLE_CODE"] = frmRow["IDLE_CAUSE"].ToString();
        //            paramIdleRow["IDLE_TIME"] = 1;
        //            paramIdleRow["IDLE_STATE"] = 1;
        //            paramIdleRow["SCOMMENT"] = DBNull.Value;
        //            paramIdleRow["WO_NO"] = focusRow["WO_NO"];
        //            paramIdleRow["REG_EMP"] = acInfo.UserID;
        //            paramIdleRow["DATA_FLAG"] = 0;

        //            paramIdleTable.Rows.Add(paramIdleRow);

        //            DataSet paramSet = new DataSet();
        //            paramSet.Tables.Add(paramTable);
        //            paramSet.Tables.Add(paramIdleTable);


        //            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP20A_INS7", paramSet, "RQSTDT_PANEL,RQSTDT_IDLE", "RSLTDT",
        //                   QuickIns,
        //                   QuickException);

        //        }
             
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        private void btnViewCheck_Click(object sender, EventArgs e)
        {
            //자주검사
            try
            {
                
                DataRow focus = workOrderGridView.GetFocusedDataRow();

                if (focus == null) return;

                ViewCheck frm = new ViewCheck(focus);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                frm.ShowDialog();

                
            }
            catch { }
        }

       
        private void btnRegNG_Click(object sender, EventArgs e)
        {
            // 부적합등록 

            DataRow focusRow = workOrderGridView.GetFocusedDataRow();
            if (focusRow == null)
            {
                return;
            }

            if (_strEmpCode.isNullOrEmpty() || _strMcCode.isNullOrEmpty())
            {
                acMessageBox.Show(this, "설비 또는 작업자를 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            McRegNg frm = new McRegNg(focusRow, _strEmpCode, _strMcCode);
            frm.ParentControl = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //this.Search();
            }







        }
    }
}
