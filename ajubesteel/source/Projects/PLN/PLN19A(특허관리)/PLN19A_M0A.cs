using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using BizManager;

namespace PLN
{
    public sealed partial class PLN19A_M0A : BaseMenu
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


        public PLN19A_M0A()
        {
            InitializeComponent();


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            // acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


           this.Load += PLN19A_M0A_Load;
        }

        void PLN19A_M0A_Load(object sender, EventArgs e)
        {
           // this.Search();
        }

        void GetDetail()
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    this.acAttachFileControl1.LinkKey = focusRow["PATENT_CODE"];
                    this.acAttachFileControl1.ShowKey = new object[] { focusRow["PATENT_CODE"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        // 특허 건별 첨부파일 불러오기  
        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
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

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }


            base.ChildContainerInit(sender);
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;



            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //특허관리 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

        public override void MenuNotify(object data)
        {
            base.MenuNotify(data);
        }


        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.AddLookUpEdit("PATENT_STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S028");
            
            acGridView1.AddTextEdit("TITLE", "명칭", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("KOR_TITLE", "국문명칭", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ENG_TITLE", "영문명칭", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("PATENT_DATE", "출원일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PATENT_NO", "출원번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("PATENT_REG_DATE", "등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PATENT_REG_NO", "등록번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("NATION", "출원대상국가", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S022");

            acGridView1.AddTextEdit("PATENTEE", "특허권자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("INVENTOR", "발명자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("INVENTOR", "발명자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "");

            acGridView1.AddTextEdit("PATENT_FIELD", "사업적용분야", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
     
            acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);

            acGridView1.AddPictrue("PATENT_IMG", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch);

            acGridView1.AddTextEdit("IMG_CNT", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
            EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
            riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);

            button.Caption = "이미지 보기";
            button.ToolTip = "이미지 보기";

            riButtonEdit.Buttons.Clear();
            riButtonEdit.Buttons.Add(button);
            riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            riButtonEdit.ButtonClick += picture_ButtonClick;

            acGridView1.AddCustomEdit("IMG_OPEN", "대표도", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, riButtonEdit);


            // acGridView1.AddCheckEdit("HAS_ATTACH", "첨부파일유무", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddHidden("PATENT_CODE", typeof(String));

            acGridView1.KeyColumn = new string[] { "PATENT_CODE" };

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);

            (acLayoutControl1.GetEditor("PATENT_STATE") as acLookupEdit).SetCode("S028");

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;


            base.MenuInit();

        }


        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
        }



        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("TITLE_LIKE", typeof(String)); //
            paramTable.Columns.Add("PATENT_STATE", typeof(String)); //

            paramTable.Columns.Add("S_REG_DATE", typeof(string)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(string)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["TITLE_LIKE"] = layoutRow["TITLE_LIKE"];
            paramRow["PATENT_STATE"] = layoutRow["PATENT_STATE"];


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        //업무일자
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "PLN19A_SER2", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.BestFitColumns();

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




        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 열기

            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["PATENT_CODE"]))
                {

                    PLN19A_D0A frm = new PLN19A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["PATENT_CODE"], frm);

                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["PATENT_CODE"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {

                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();
             
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PATENT_CODE", typeof(String)); //

                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PATENT_CODE"] = focusRow["PATENT_CODE"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PATENT_CODE"] = selectedRows[i]["PATENT_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "PLN19A_DEL", paramSet, "RQSTDT", "",
                        QuickDEL,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //링크된 자식창 삭제
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void picture_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    PLN19A_D1A frm = new PLN19A_D1A(focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (acGridView1.RowCount == 0) return;
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "IMG_OPEN")
            {
                int intCnt = acGridView1.GetRowCellValue(e.RowHandle, "IMG_CNT").toInt();

                if (intCnt == 0)
                {
                    RepositoryItemButtonEdit riButtonEdit = new RepositoryItemButtonEdit();
                    EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, null);
                    
                    button.Caption = "없음";
                    button.ToolTip = "없음";
                    button.Enabled = false;
                    riButtonEdit.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
                    riButtonEdit.Buttons.Clear();
                    riButtonEdit.Buttons.Add(button);
                    riButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                    riButtonEdit.ButtonClick += picture_ButtonClick;
                    e.RepositoryItem = riButtonEdit;
                }
            }
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 특허관리 편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    PLN19A_D0A frm = new PLN19A_D0A(acGridView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);

                }
                else
                {

                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}
