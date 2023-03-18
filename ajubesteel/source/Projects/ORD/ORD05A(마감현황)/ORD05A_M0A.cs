using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;
using CodeHelperManager;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;

namespace ORD
{
    public sealed partial class ORD05A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public ORD05A_M0A()
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

        private enum emOption
        {
            //계획일정
            PLN_TIME,

            //지시상태
            WO_STATE,

            //도형
            WO_FIG

        }

        private emOption _viewOpt = emOption.PLN_TIME;

        private DataTable _billDT = null;
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




        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();

        }

        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {
 
        }

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            //acGridView1.AddTextEdit("SHIP_ID", "출하번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SHIP_STATE", "출하상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");
            acGridView1.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            //acGridView1.AddCheckEdit("LOCK_FLAG", "잠금", "", false, false, true, acGridView.emCheckEditDataType._BYTE);            
            //acGridView1.AddLookUpEmp("LOCK_EMP", "잠금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
            acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
            acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");            
            acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
            //acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("BUSINESS_EMP", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("CUSTDESIGN_EMP", "고객설계자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");

            acGridView1.AddTextEdit("PO_NO", "PO No", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처 코드", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_BILL_NO", "계산서 발행No", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("OLD_SHIP_QTY", "출하수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("SHIP_QTY", "잔량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddTextEdit("SHIP_AMT", "출하금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            RepositoryItemTwoButtonEdit editItem_Tax = new RepositoryItemTwoButtonEdit();
            editItem_Tax.Buttons[0].Click += ButtonEdit_Tax_Reg_Click;
            editItem_Tax.Buttons[1].Click += ButtonEdit_Tax_Del_Click;
            acGridView1.AddCustomEdit("TAX_DATE", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, editItem_Tax);
            acGridView1.Columns["TAX_DATE"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //editItem_Tax.ButtonClick += EditItem_Tax_ButtonClick;

            acGridView1.AddTextEdit("TAX_BILL_QTY", "세금계산서 합계수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TAX_BILL_AMT", "세금계산서 합계금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("COL_PLAN_DATE", "수금예정일", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            RepositoryItemTwoButtonEdit editItem_Trade = new RepositoryItemTwoButtonEdit();
            editItem_Trade.Buttons[0].Click += ButtonEdit_Trade_Reg_Click;
            editItem_Trade.Buttons[1].Click += ButtonEdit_Trade_Del_Click;
            acGridView1.AddCustomEdit("TRADE_DATE", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, editItem_Trade);
            acGridView1.Columns["TRADE_DATE"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //editItem_Trade.ButtonClick += EditItem_Trade_ButtonClick;
            //editItem_Trade.ButtonPressed += EditItem_Trade_ButtonPressed;

            #region 주석 editbutton test
            //acGridView1.AddButtonEdit("BILL_DEL", "삭제", "", false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.DisableTextEditor, false, true, false);

            //RepositoryItemButtonEdit riBtnEdit = acGridView1.Columns["BILL_DEL"].ColumnEdit as RepositoryItemButtonEdit;

            //EditorButton button1 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ExtensionMethods.ChangeIconColor(global::ORD.Resource.add_1x, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor()));
            //button1.ToolTip = "추가";
            //button1.Click += Button1_Click;
            //EditorButton button2 = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter,ExtensionMethods.ChangeIconColor(global::ORD.Resource.remove_sign_1x, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor()));
            //button2.ToolTip = "삭제";

            //riBtnEdit.Buttons.Clear();
            //riBtnEdit.Buttons.Add(button1);
            //riBtnEdit.Buttons.Add(button2);

            //acGridView1.Columns["BILL_DEL"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;


            //acGridColumn colCommand = acGridView1.Columns.AddVisible("ACT_STOP") as acGridColumn;
            //colCommand.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
            //EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ExtensionMethods.ChangeIconColor(global::ORD.Resource.remove_sign_1x, Color.Navy));
            //button.ToolTip = "작업중지";
            ////button.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);

            //riButtonEdit.Buttons.Clear();
            //riButtonEdit.Buttons.Add(button);
            //riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            //riButtonEdit.ReadOnly = true;
            //riButtonEdit.ButtonClick += RiButtonEdit_ButtonClick;

            //acGridControl1.RepositoryItems.Add(riButtonEdit);
            //colCommand.ColumnEdit = riButtonEdit;
            //acGridView1.Columns["ACT_STOP"].Caption = "중지";
            //acGridView1.Columns["ACT_STOP"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //acGridView1.Columns["ACT_STOP"].VisibleIndex = 3;
            //acGridView1.Columns["ACT_STOP"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            //acGridView1.Columns["ACT_STOP"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            #endregion

            acGridView1.AddTextEdit("TRADE_BILL_QTY", "거래명세표 합계수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TRADE_BILL_AMT", "거래명세표 합계금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

;
            //RepositoryItemOneButtonEdit editItem_Col = new RepositoryItemOneButtonEdit();
            //editItem_Col.Buttons[0].Click += ButtonEdit_Col_Reg_Click;
            //acGridView1.AddCustomEdit("COL_DATE", "수금일", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, editItem_Col);
            //acGridView1.Columns["COL_DATE"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            RepositoryItemTwoButtonEdit editItem_Col = new RepositoryItemTwoButtonEdit();
            editItem_Col.Buttons[0].Click += ButtonEdit_Col_Reg_Click;
            editItem_Col.Buttons[1].Click += ButtonEdit_Col_Del_Click;
            acGridView1.AddCustomEdit("COL_DATE", "수금일", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, editItem_Col);
            acGridView1.Columns["COL_DATE"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            acGridView1.AddTextEdit("COL_BILL_QTY", "수금일 합계수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("COL_BILL_AMT", "수금일 합계금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);



            //acGridView1.AddLookUpEmp("SHIP_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddDateEdit("SHIP_DATE", "출하일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("SHIP_DATE", "출하일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("SHIP_END_DATE", "출하완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddDateEdit("COL_DATE", "수금일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddMemoEdit("SHIP_SCOMMENT", "출하비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("EST_COST", "견적단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("PROD_COST", "공급단가", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("PROD_AMT", "총금액", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

            //acGridView1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
            //acGridView1.AddLookUpEdit("BILL_YN", "수금등록", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");

            //acGridView1.AddMemoEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            //acGridView1.AddMemoEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROD_CODE" };

            acGridView1.Columns["TAX_DATE"].Width = 200;
            acGridView1.Columns["TRADE_DATE"].Width = 200;
            acGridView1.Columns["COL_DATE"].Width = 200;

            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하일", false, "", "SHIP_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("세금계산서 발행일", false, "", "TAX_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("거래명세표 발행일", false, "", "TRADE_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수금예정일", false, "", "COL_PLAN_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수금일", false, "", "COL_DATE", true, false);

            //acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);            
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);


            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.RowCellStyle += AcGridView1_RowCellStyle;
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            this.acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            base.MenuInit();
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

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


                }
                else
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                acAttachFileControl1.LinkKey = focusRow["PROD_CODE"];
                acAttachFileControl1.ShowKey = new object[] { focusRow["PROD_CODE"] };
            }
            else
            {
                acAttachFileControl1.LinkKey = null;
                acAttachFileControl1.ShowKey = null;
            }
        }

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                

                GridView view = sender as GridView;
                GridHitInfo hi = view.CalcHitInfo(e.Location);
                if (hi.InRowCell)
                {
                    if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemTwoButtonEdit))
                    {
                        view.FocusedRowHandle = hi.RowHandle;
                        view.FocusedColumn = hi.Column;
                        
                        view.ShowEditor();
                        
                        //(view.ActiveEditor as ComboBoxEdit).ShowPopup();
                        //force button click  
                        ButtonEdit edit = (view.ActiveEditor as acTwoButtonEdit);
                        //RepositoryItemTwoButtonEdit edit2 = hi.Column.RealColumnEdit as RepositoryItemTwoButtonEdit;
                        Rectangle rectangle = edit.Bounds;
                        if(rectangle.X + rectangle.Width - 45 < e.Location.X
                          &&  rectangle.X + rectangle.Width - 22 > e.Location.X)
                        {
                            if (hi.Column.FieldName.Contains("TAX"))
                            {
                                ButtonEdit_Tax_Reg_Click(null, null);
                            }
                            else if (hi.Column.FieldName.Contains("TRADE"))
                            {
                                ButtonEdit_Trade_Reg_Click(null, null);
                            }
                            else if (hi.Column.FieldName.Contains("COL"))
                            {
                                ButtonEdit_Col_Reg_Click(null, null);
                            }
                        }
                        else if (rectangle.X + rectangle.Width - 23 < e.Location.X
                          && rectangle.X + rectangle.Width - 0 > e.Location.X)
                        {                            
                            if (hi.Column.FieldName.Contains("TAX"))
                            {
                                ButtonEdit_Tax_Del_Click(null, null);
                            }
                            else if (hi.Column.FieldName.Contains("TRADE"))
                            {
                                ButtonEdit_Trade_Del_Click(null, null);
                            }
                            else if (hi.Column.FieldName.Contains("COL"))
                            {
                                ButtonEdit_Col_Del_Click(null, null);
                            }
                        }
                        
                    }
                    //else if (hi.Column.RealColumnEdit.GetType() == typeof(RepositoryItemOneButtonEdit))
                    //{
                    //    view.FocusedRowHandle = hi.RowHandle;
                    //    view.FocusedColumn = hi.Column;

                    //    view.ShowEditor();

                    //    //(view.ActiveEditor as ComboBoxEdit).ShowPopup();
                    //    //force button click  
                    //    ButtonEdit edit = (view.ActiveEditor as acOneButtonEdit);
                    //    //RepositoryItemTwoButtonEdit edit2 = hi.Column.RealColumnEdit as RepositoryItemTwoButtonEdit;
                    //    Rectangle rectangle = edit.Bounds;
                    //    if (rectangle.X + rectangle.Width - 23 < e.Location.X
                    //      && rectangle.X + rectangle.Width - 0 > e.Location.X)
                    //    {
                    //        if (hi.Column.FieldName.Contains("COL"))
                    //        {
                    //            ButtonEdit_Col_Reg_Click(null, null);
                    //        }
                    //    }

                    //}
                }
            }


            //GridHitInfo hitInfo = new GridHitInfo();

            //hitInfo = acGridView1.CalcHitInfo(e.Location);

            //if(hitInfo.InRowCell)
            //{
            //    if(hitInfo.Column.FieldName == "TAX_DATE")
            //    {
            //        GridColumn column = hitInfo.Column;
            //        int RowHandle = hitInfo.RowHandle;

            //        //Get more information  
            //        GridViewInfo viewInfo = (acGridView1.GetViewInfo() as GridViewInfo);
            //        GridCellInfo cellInfo = viewInfo.GetGridCellInfo(hitInfo);

            //        RepositoryItemTwoButtonEdit edit = column.ColumnEdit as RepositoryItemTwoButtonEdit;

            //        edit.Buttons[0].
            //    }

            //}
        }

        //private void RiButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //private void EditItem_Trade_ButtonPressed(object sender, ButtonPressedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //private void EditItem_Trade_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}

        //private void EditItem_Tax_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    acGridView1.EndEditor();

        //    ORD05A_D0A frm = new ORD05A_D0A("TRADE");
        //    frm.ParentControl = this;
        //    frm.ShowDialog(this);

        //    if (frm.DialogResult != DialogResult.OK)
        //    {
        //        acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, acGridView1.FocusedColumn.FieldName);
        //        return;
        //    }

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();
        //    DataRow outputRow = frm.OutputData as DataRow;

        //    DataTable paramTable1 = new DataTable("RQSTDT");
        //    paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_TYPE", typeof(String)); //
        //    paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_DATE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_EMP", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_QTY", typeof(int)); //
        //    paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
        //    paramTable1.Columns.Add("REG_EMP", typeof(String)); //

        //    DataRow paramRow1 = paramTable1.NewRow();
        //    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow1["BILL_TYPE"] = "TRADE";
        //    paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
        //    paramRow1["BILL_DATE"] = outputRow["BILL_DATE"];
        //    paramRow1["BILL_EMP"] = outputRow["BILL_EMP"];
        //    paramRow1["BILL_QTY"] = outputRow["BILL_QTY"];
        //    paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
        //    paramRow1["REG_EMP"] = acInfo.UserID;

        //    paramTable1.Rows.Add(paramRow1);

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable1);

        //    BizRun.QBizRun.ExecuteService(
        //    this, QBiz.emExecuteType.SAVE,
        //    "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT",
        //    QuickBill,
        //    QuickException);
        //}

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    acGridView1.EndEditor();

        //    ORD05A_D0A frm = new ORD05A_D0A("TRADE");
        //    frm.ParentControl = this;
        //    frm.ShowDialog(this);

        //    if (frm.DialogResult != DialogResult.OK)
        //    {
        //        acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, acGridView1.FocusedColumn.FieldName);
        //        return;
        //    }

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();
        //    DataRow outputRow = frm.OutputData as DataRow;

        //    DataTable paramTable1 = new DataTable("RQSTDT");
        //    paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_TYPE", typeof(String)); //
        //    paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_DATE", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_EMP", typeof(String)); //
        //    paramTable1.Columns.Add("BILL_QTY", typeof(int)); //
        //    paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
        //    paramTable1.Columns.Add("REG_EMP", typeof(String)); //

        //    DataRow paramRow1 = paramTable1.NewRow();
        //    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow1["BILL_TYPE"] = "TRADE";
        //    paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
        //    paramRow1["BILL_DATE"] = outputRow["BILL_DATE"];
        //    paramRow1["BILL_EMP"] = outputRow["BILL_EMP"];
        //    paramRow1["BILL_QTY"] = outputRow["BILL_QTY"];
        //    paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
        //    paramRow1["REG_EMP"] = acInfo.UserID;

        //    paramTable1.Rows.Add(paramRow1);

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable1);

        //    BizRun.QBizRun.ExecuteService(
        //    this, QBiz.emExecuteType.SAVE,
        //    "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT",
        //    QuickBill,
        //    QuickException);
        //}

        private void AcGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                //DataRow dataRow = acGridView1.GetDataRow(e.RowHandle);
                //if (dataRow["SHIP_QTY"].toInt() > 0)
                //    dataRow["SHIP_STATE"] = "부분출하";
                //else
                //    dataRow["SHIP_STATE"] = "출하완료";
            }
            catch { }

        }

        private void ButtonEdit_Trade_Reg_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D0A frm = new ORD05A_D0A("TRADE", focusRow["PROD_QTY"].toInt() - focusRow["TRADE_BILL_QTY"].toInt());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;
            
            DataRow outputRow = frm.OutputData as DataRow;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_TYPE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_DATE", typeof(String)); //
            paramTable1.Columns.Add("BILL_EMP", typeof(String)); //
            paramTable1.Columns.Add("BILL_QTY", typeof(int)); //
            paramTable1.Columns.Add("BILL_AMT", typeof(Decimal)); //
            paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow1["BILL_TYPE"] = "TRADE";
            paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
            paramRow1["BILL_DATE"] = outputRow["BILL_DATE"];
            paramRow1["BILL_EMP"] = outputRow["BILL_EMP"];
            paramRow1["BILL_QTY"] = outputRow["BILL_QTY"];
            paramRow1["BILL_AMT"] = outputRow["BILL_AMT"];
            paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
            paramRow1["REG_EMP"] = acInfo.UserID;

            paramTable1.Rows.Add(paramRow1);
   
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT",
            QuickBill,
            QuickException);
        }

        private void ButtonEdit_Trade_Del_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D1A frm = new ORD05A_D1A("TRADE", focusRow["PROD_CODE"].ToString());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;
            
            DataSet paramSet = frm.OutputData as DataSet;

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT,RQSTDT_DEL",
            QuickBill,
            QuickException);
        }

        private void ButtonEdit_Tax_Reg_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D0A frm = new ORD05A_D0A("TAX", focusRow["PROD_QTY"].toInt() - focusRow["TAX_BILL_QTY"].toInt());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;
            
            DataRow outputRow = frm.OutputData as DataRow;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_TYPE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_DATE", typeof(String)); //
            paramTable1.Columns.Add("BILL_EMP", typeof(String)); //
            paramTable1.Columns.Add("BILL_QTY", typeof(int)); //
            paramTable1.Columns.Add("BILL_AMT", typeof(Decimal)); //
            paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //
            paramTable1.Columns.Add("COL_PLAN_DATE", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow1["BILL_TYPE"] = "TAX";
            paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
            paramRow1["BILL_DATE"] = outputRow["BILL_DATE"];
            paramRow1["BILL_EMP"] = outputRow["BILL_EMP"];
            paramRow1["BILL_QTY"] = outputRow["BILL_QTY"];
            paramRow1["BILL_AMT"] = outputRow["BILL_AMT"];
            paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
            paramRow1["REG_EMP"] = acInfo.UserID;
            paramRow1["COL_PLAN_DATE"] = outputRow["COL_PLAN_DATE"];

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT",
            QuickBill,
            QuickException);
        }        

        private void ButtonEdit_Tax_Del_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D1A frm = new ORD05A_D1A("TAX", focusRow["PROD_CODE"].ToString());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;

            DataSet paramSet = frm.OutputData as DataSet;

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT,RQSTDT_DEL",
            QuickBill,
            QuickException);
        }

        private void ButtonEdit_Col_Reg_Click(object sender, EventArgs e)
        {
            //acGridView1.EndEditor();

            //DataRow focusRow = acGridView1.GetFocusedDataRow();

            //ORD05A_D7A frm = new ORD05A_D7A("TAX", focusRow["PROD_CODE"].ToString());
            //frm.ParentControl = this;
            //frm.ShowDialog(this);

            //if (frm.DialogResult != DialogResult.OK)
            //    return;

            //DataSet paramSet = frm.OutputData as DataSet;

            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.SAVE,
            //"ORD05A_INS8", paramSet, "RQSTDT", "RSLTDT",
            //QuickBill,
            //QuickException);

            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D0A frm = new ORD05A_D0A("COL", focusRow["PROD_QTY"].toInt() - focusRow["COL_BILL_QTY"].toInt());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;

            DataRow outputRow = frm.OutputData as DataRow;

            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_TYPE", typeof(String)); //
            paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable1.Columns.Add("BILL_DATE", typeof(String)); //
            paramTable1.Columns.Add("BILL_EMP", typeof(String)); //
            paramTable1.Columns.Add("BILL_QTY", typeof(int)); //
            paramTable1.Columns.Add("BILL_AMT", typeof(Decimal)); //
            paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable1.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRow1 = paramTable1.NewRow();
            paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow1["BILL_TYPE"] = "COL";
            paramRow1["PROD_CODE"] = focusRow["PROD_CODE"];
            paramRow1["BILL_DATE"] = outputRow["BILL_DATE"];
            paramRow1["BILL_EMP"] = outputRow["BILL_EMP"];
            paramRow1["BILL_QTY"] = outputRow["BILL_QTY"];
            paramRow1["BILL_AMT"] = outputRow["BILL_AMT"];
            paramRow1["SCOMMENT"] = outputRow["SCOMMENT"];
            paramRow1["REG_EMP"] = acInfo.UserID;

            paramTable1.Rows.Add(paramRow1);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT",
            QuickBill,
            QuickException);
        }

        private void ButtonEdit_Col_Del_Click(object sender, EventArgs e)
        {
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            ORD05A_D1A frm = new ORD05A_D1A("COL", focusRow["PROD_CODE"].ToString());
            frm.ParentControl = this;
            frm.ShowDialog(this);

            if (frm.DialogResult != DialogResult.OK)
                return;

            DataSet paramSet = frm.OutputData as DataSet;

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS", paramSet, "RQSTDT", "RSLTDT,RQSTDT_DEL",
            QuickBill,
            QuickException);
        }

        void QuickBill(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, true);
                }

                setBillData(e.result);

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (sender is acGridView view)
                {
                    DataRow row = view.GetDataRow(e.RowHandle);
                    if (row == null)
                        return;

                    if (row["PROD_STATE"].ToString() == "5")
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.Black;
                    }

                    //if (row["SHIP_QTY"].toInt() > 0)
                    //{
                    //    e.Appearance.BackColor = Color.Yellow;
                    //    e.Appearance.ForeColor = Color.Black;
                    //}
                }
            }
            catch
            {

            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "PROD_CODE", row["PROD_CODE"]);

                base.ChildFormRemove(formKey);
            }

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


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하 시작일
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //납품 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //납품 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일

            paramTable.Columns.Add("S_TAX_DATE", typeof(String)); //세금계산서 시작일
            paramTable.Columns.Add("E_TAX_DATE", typeof(String)); //세금계산서 종료일

            paramTable.Columns.Add("S_TRADE_DATE", typeof(String)); //거래명세표 시작일
            paramTable.Columns.Add("E_TRADE_DATE", typeof(String)); //거래명세표 종료일

            paramTable.Columns.Add("S_COL_PLAN_DATE", typeof(String)); //거래명세표 시작일
            paramTable.Columns.Add("E_COL_PLAN_DATE", typeof(String)); //거래명세표 종료일

            paramTable.Columns.Add("S_COL_DATE", typeof(String)); //거래명세표 시작일
            paramTable.Columns.Add("E_COL_DATE", typeof(String)); //거래명세표 종료일

            paramTable.Columns.Add("BILL_TYPE", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":
                        //등록일
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                    case "SHIP_DATE":
                        //출하일
                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;

                    case "TAX_DATE":
                        //세금계산서
                        paramRow["S_TAX_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_TAX_DATE"] = layoutRow["E_DATE"];
                        paramRow["BILL_TYPE"] = "TAX";

                        break;

                    case "TRADE_DATE":
                        //거래명세표
                        paramRow["S_TRADE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_TRADE_DATE"] = layoutRow["E_DATE"];
                        paramRow["BILL_TYPE"] = "TRADE";

                        break;

                    case "COL_PLAN_DATE":
                        //수금예정일
                        paramRow["S_COL_PLAN_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_COL_PLAN_DATE"] = layoutRow["E_DATE"];
                        paramRow["BILL_TYPE"] = "TAX";

                        break;

                    case "COL_DATE":
                        //수금일
                        paramRow["S_COL_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_COL_DATE"] = layoutRow["E_DATE"];
                        paramRow["BILL_TYPE"] = "COL";

                        break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "ORD05A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
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

        public override void DataRefresh(object data)
        {
            if (data.EqualsEx("PROD"))
            {
                if (base.IsData(data))
                {
                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.REFRESH,
                 "ORD05A_SER", refreshSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);

                }

            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == 200027)
            {
                //부품이 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == 200059)
            {
                //세트외주 구매정보가 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm2", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false,  this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            }
            else if (ex.ErrNumber == 200083)
            {
                //금형상태가 유효하지않음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm3", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                if (ex.ParameterData == null)
                {
                    acMessageBox.Show(this, ex);

                    return;
                }

                foreach (DataRow row in ex.ParameterData.Rows)
                {
                    row["CHECK_PROD_STATE"] = acInfo.StdCodes.GetNameByCodes("S025", row["CHECK_PROD_STATE"]);
                }

                frm.ParentControl = this;

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddLookUpEdit("NOW_PROD_STATE", "금형상태", "WJB3HAFK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("CHECK_PROD_STATE", "유효 금형상태", "Y91G7XDQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                //데이터 갱신
                acMessageBox.Show(this, ex);

                this.DataRefresh("ITEM");
            }
            else if (ex.ErrNumber == 200202)
            {
                acMessageBox.Show("품목이 존재하여 삭제할 수 없습니다. \n품목을 먼저 삭제하세요. ", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200203)
            {
                acMessageBox.Show("대기 상태인 수주만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200204)
            {
                acMessageBox.Show("대기 상태인 품목만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }




        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("PROD", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                                

                acGridView1.SetOldFocusRowHandle(true);


                if (e.result.Tables.Contains("RSLTDT_BILL"))
                {
                    _billDT = e.result.Tables["RSLTDT_BILL"];
                }

                if (_billDT != null)
                {
                    Decimal sumTaxAmt = 0;
                    Decimal sumTradeAmt = 0;

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    string sDate = layoutRow["S_DATE"].ToString();
                    string eDate = layoutRow["E_DATE"].ToString();

                    if (sDate != "" && eDate != "")
                    {
                        DataRow[] rows = _billDT.Select("BILL_DATE >= '" + sDate + "' AND BILL_DATE <= '" + eDate + "'");

                        foreach (DataRow row in rows)
                        {
                            if (row["BILL_TYPE"].ToString() == "TAX")
                            {
                                sumTaxAmt = sumTaxAmt + row["BILL_AMT"].toDecimal();
                            }
                            else if (row["BILL_TYPE"].ToString() == "TRADE")
                            {
                                sumTradeAmt = sumTradeAmt + row["BILL_AMT"].toDecimal();
                            }
                        }

                        string totTaxAmt = string.Format("{0}:{1:n2}", "세금계산서", sumTaxAmt);
                        string totTradeAmt = string.Format("{0}{1:n2}", "거래명세표", sumTradeAmt);

                        acLabelControl2.Text = totTaxAmt;
                        acLabelControl3.Text = totTradeAmt;
                    }
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        /// <summary>
        /// 출하 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            if (selectedRows.Length == 0)
            {
                acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }


            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("SHIP_ID", typeof(String)); //
            paramTable1.Columns.Add("DEL_EMP", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["SHIP_ID"] = dr["SHIP_ID"];
                paramRow1["DEL_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD04A_CANCEL", paramSet, "RQSTDT", "RSLTDT",
            QuickCancel,
            QuickException);
        }

        void QuickCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //계산서 발행처 일괄 수정
            acGridView1.EndEditor();

            DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

            DataRow focuseRow = acGridView1.GetFocusedDataRow();

            if(focuseRow == null)
            {
                return;
            }

            //발행처 선택 팝업
            ORD05A_D2A frm = new ORD05A_D2A();
            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = (DataRow)frm.OutputData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));
                paramTable.Columns.Add("TVND_CODE", typeof(string));

                if (selectedRow.Length == 0)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focuseRow["PROD_CODE"];
                    paramRow["TVND_CODE"] = frmRow["TVND_CODE"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow row in selectedRow)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramRow["TVND_CODE"] = frmRow["TVND_CODE"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD05A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);
            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acGridView1.UpdateMapingRow(row, false);
                }

                setBillData(e.result);

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //계산서 발행 No 등록
            acGridView1.EndEditor();

            DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

            DataRow focuseRow = acGridView1.GetFocusedDataRow();

            if (focuseRow == null)
            {
                return;
            }

            //계산서 발행 No 등록 팝업
            ORD05A_D3A frm = new ORD05A_D3A();
            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = (DataRow)frm.OutputData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));
                paramTable.Columns.Add("PROD_BILL_NO", typeof(string));

                if (selectedRow.Length == 0)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focuseRow["PROD_CODE"];
                    paramRow["PROD_BILL_NO"] = frmRow["PROD_BILL_NO"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow row in selectedRow)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = row["PROD_CODE"];
                        paramRow["PROD_BILL_NO"] = frmRow["PROD_BILL_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD05A_INS3", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //수금일 일괄 등록

            acGridView1.EndEditor();

            DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

            DataRow focuseRow = acGridView1.GetFocusedDataRow();

            if (focuseRow == null)
            {
                return;
            }

            //수금일 등록 팝업
            ORD05A_D5A frm = new ORD05A_D5A("COL");
            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = (DataRow)frm.OutputData;

                SetDate(selectedRow, focuseRow, frmRow, "COL");
            }


            //acGridView1.EndEditor();

            //DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

            //DataRow focuseRow = acGridView1.GetFocusedDataRow();

            //if (focuseRow == null)
            //{
            //    return;
            //}

            ////수금일 등록 팝업
            //ORD05A_D4A frm = new ORD05A_D4A();
            //frm.ParentControl = this;
            //frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    DataRow frmRow = (DataRow)frm.OutputData;

            //    DataTable paramTable = new DataTable("RQSTDT");
            //    paramTable.Columns.Add("PLT_CODE", typeof(string));
            //    paramTable.Columns.Add("PROD_CODE", typeof(string));
            //    paramTable.Columns.Add("COL_DATE", typeof(string));

            //    if (selectedRow.Length == 0)
            //    {
            //        DataRow paramRow = paramTable.NewRow();
            //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //        paramRow["PROD_CODE"] = focuseRow["PROD_CODE"];
            //        paramRow["COL_DATE"] = frmRow["COL_DATE"];

            //        paramTable.Rows.Add(paramRow);
            //    }
            //    else
            //    {
            //        foreach (DataRow row in selectedRow)
            //        {
            //            DataRow paramRow = paramTable.NewRow();
            //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //            paramRow["PROD_CODE"] = row["PROD_CODE"];
            //            paramRow["COL_DATE"] = frmRow["COL_DATE"];

            //            paramTable.Rows.Add(paramRow);
            //        }
            //    }

            //    DataSet paramSet = new DataSet();
            //    paramSet.Tables.Add(paramTable);

            //    BizRun.QBizRun.ExecuteService(
            //    this, QBiz.emExecuteType.SAVE,
            //    "ORD05A_INS4", paramSet, "RQSTDT", "RSLTDT",
            //    QuickSave,
            //    QuickException);
            //}
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //세금계산서 일괄등록
            try
            {
                acGridView1.EndEditor();

                DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

                DataRow focuseRow = acGridView1.GetFocusedDataRow();

                if (focuseRow == null)
                {
                    return;
                }

                //발행일 등록 팝업
                ORD05A_D5A frm = new ORD05A_D5A("TAX");
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = (DataRow)frm.OutputData;

                    SetDate(selectedRow, focuseRow, frmRow, "TAX");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //거래명세표 일괄등록
            try
            {
                acGridView1.EndEditor();

                DataRow[] selectedRow = acGridView1.GetSelectedDataRows();

                DataRow focuseRow = acGridView1.GetFocusedDataRow();

                if (focuseRow == null)
                {
                    return;
                }

                //발행일 등록 팝업
                ORD05A_D5A frm = new ORD05A_D5A("TRADE");
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = (DataRow)frm.OutputData;
                    SetDate(selectedRow, focuseRow, frmRow, "TRADE");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SetDate(DataRow[] selectedRow, DataRow focusRow, DataRow frmRow, string billType)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("BILL_DATE", typeof(string));
            paramTable.Columns.Add("BILL_TYPE", typeof(string));
            paramTable.Columns.Add("COL_PLAN_DATE", typeof(string));

            if (selectedRow.Length == 0)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                paramRow["BILL_DATE"] = frmRow["DATE"];
                paramRow["BILL_TYPE"] = billType;
                paramRow["COL_PLAN_DATE"] = frmRow["COL_PLAN_DATE"];

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                foreach (DataRow row in selectedRow)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["BILL_DATE"] = frmRow["DATE"];
                    paramRow["BILL_TYPE"] = billType;
                    paramRow["COL_PLAN_DATE"] = frmRow["COL_PLAN_DATE"];

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD05A_INS5", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //선택합계
            if (_billDT != null)
            {
                Decimal sumTaxAmt = 0;
                Decimal sumTradeAmt = 0;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                string sDate = layoutRow["S_DATE"].ToString();
                string eDate = layoutRow["E_DATE"].ToString();

                if (sDate != "" && eDate != "")
                {
                    DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                    if (selectedRows.Length > 0)
                    {
                        foreach (DataRow row in selectedRows)
                        {
                            DataRow[] rows = _billDT.Select("BILL_DATE >= '" + sDate + "' AND BILL_DATE <= '" + eDate + "' AND PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");

                            foreach (DataRow rw in rows)
                            {
                                if (rw["BILL_TYPE"].ToString() == "TAX")
                                {
                                    sumTaxAmt = sumTaxAmt + rw["BILL_AMT"].toDecimal();
                                }
                                else if (rw["BILL_TYPE"].ToString() == "TRADE")
                                {
                                    sumTradeAmt = sumTradeAmt + rw["BILL_AMT"].toDecimal();
                                }
                            }
                        }

                        string totTaxAmt = string.Format("{0}:{1:n2}", "세금계산서", sumTaxAmt);
                        string totTradeAmt = string.Format("{0}:{1:n2}", "거래명세표", sumTradeAmt);

                        acLabelControl2.Text = totTaxAmt;
                        acLabelControl3.Text = totTradeAmt;
                    }
                    else
                    {
                        DataRow[] rows = _billDT.Select("BILL_DATE >= '" + sDate + "' AND BILL_DATE <= '" + eDate + "'");

                        foreach (DataRow rw in rows)
                        {
                            if (rw["BILL_TYPE"].ToString() == "TAX")
                            {
                                sumTaxAmt = sumTaxAmt + rw["BILL_AMT"].toDecimal();
                            }
                            else if (rw["BILL_TYPE"].ToString() == "TRADE")
                            {
                                sumTradeAmt = sumTradeAmt + rw["BILL_AMT"].toDecimal();
                            }
                        }

                        string totTaxAmt = string.Format("{0}:{1:n2}", "세금계산서", sumTaxAmt);
                        string totTradeAmt = string.Format("{0}{1:n2}", "거래명세표", sumTradeAmt);

                        acLabelControl2.Text = totTaxAmt;
                        acLabelControl3.Text = totTradeAmt;

                    }                
                }


            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 수주편집기

            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                string formKey = string.Format("{0},{1}", "PROD", focusRow["PROD_CODE"]);

                if (!base.ChildFormContains(formKey))
                {

                    ORD05A_D6A frm = new ORD05A_D6A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus(formKey);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //완료
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    if (acMessageBox.Show("완료 하시겠습니까?", "완료", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_STATE", typeof(string));

                    bool isAmtChk = false;

                    if (selectedRows.Length == 0)
                    {
                        if (focusRow["PROD_STATE"].ToString() != "9")
                        {
                            acAlert.Show(this, "출하상태가 아닌 수주입니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        if (focusRow["PROD_AMT"].toDecimal() != focusRow["TAX_BILL_AMT"].toDecimal())
                        {
                            isAmtChk = true;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                        paramRow["PROD_STATE"] = "2";

                        paramTable.Rows.Add(paramRow);

                    }
                    else
                    {
                        foreach (DataRow row in selectedRows)
                        {
                            if (row["PROD_STATE"].ToString() != "9")
                            {
                                acAlert.Show(this, "출하상태가 아닌 수주가 있습니다.", acAlertForm.enmType.Warning);
                                return;
                            }

                            if (row["PROD_AMT"].toDecimal() != row["TAX_BILL_AMT"].toDecimal())
                            {
                                isAmtChk = true;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PROD_CODE"] = row["PROD_CODE"];
                            paramRow["PROD_STATE"] = "2";

                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    if (isAmtChk)
                    {
                        if (acMessageBox.Show(this, "계산서발행금액과 총금액이 다릅니다.\r\n완료처리를 진행 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                        {
                            return;
                        }
                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD05A_INS7", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

                }
                else
                {
                    acAlert.Show(this, "선택된 수주가 없습니다.", acAlertForm.enmType.Warning);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //완료취소
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    if (acMessageBox.Show("완료취소 하시겠습니까?", "완료취소", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_STATE", typeof(string));

                    if (selectedRows.Length == 0)
                    {
                        if (focusRow["PROD_STATE"].ToString() != "2")
                        {
                            acAlert.Show(this, "완료상태가 아닌 수주입니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                        paramRow["PROD_STATE"] = "9";

                        paramTable.Rows.Add(paramRow);

                    }
                    else
                    {
                        foreach (DataRow row in selectedRows)
                        {
                            if (row["PROD_STATE"].ToString() != "2")
                            {
                                acAlert.Show(this, "완료상태가 아닌 수주가 있습니다.", acAlertForm.enmType.Warning);
                                return;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PROD_CODE"] = row["PROD_CODE"];
                            paramRow["PROD_STATE"] = "9";

                            paramTable.Rows.Add(paramRow);
                        }
                    }


                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD05A_INS7", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

                }
                else
                {
                    acAlert.Show(this, "선택된 수주가 없습니다.", acAlertForm.enmType.Warning);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void setBillData(DataSet ds)
        {
            if (ds.Tables.Contains("RSLTDT_BILL"))
            {
                if (_billDT != null)
                {
                    string prodCode = "";

                    foreach (DataRow row in ds.Tables["RQSTDT"].Rows)
                    {
                        if (row["PROD_CODE"].ToString() != prodCode)
                        {
                            DataRow[] rows = _billDT.Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");

                            if (rows.Length > 0)
                            {
                                foreach (DataRow rw in rows)
                                {
                                    _billDT.Rows.Remove(rw);
                                }
                            }
                        }

                        prodCode = row["PROD_CODE"].ToString();
                    }

                    foreach (DataRow row in ds.Tables["RSLTDT_BILL"].Rows)
                    {
                        DataRow newRow = _billDT.NewRow();
                        newRow.ItemArray = row.ItemArray;

                        _billDT.Rows.Add(newRow);
                    }
                }
            }
        }
    }
}
