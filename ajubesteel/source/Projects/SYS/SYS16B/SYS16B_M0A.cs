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
using DevExpress.XtraGrid.Views.Base;
using BizManager;

namespace SYS
{
    public sealed partial class SYS16B_M0A : BaseMenu
    {
        private Color _PROGRESS;
        private Color _OK;
        private Color _DENY;
  

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


        public SYS16B_M0A()
        {
            InitializeComponent();

            _OK = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
            _PROGRESS = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
            _DENY = acInfo.SysConfig.GetSysConfigByServer("APP_STATE_DENY").toColor();


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
        
        }

        void GetDetail()
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    this.acAttachFileControl1.LinkKey = focusRow["ISSU_FILE_ID"];
                    this.acAttachFileControl1.ShowKey = new object[] { focusRow["ISSU_FILE_ID"] };

                    this.acAttachFileControl2.LinkKey = focusRow["SOL_FILE_ID"];
                    this.acAttachFileControl2.ShowKey = new object[] { focusRow["SOL_FILE_ID"] };

                    this.acAttachFileControl3.LinkKey = focusRow["RPT_FILE_ID"];
                    this.acAttachFileControl3.ShowKey = new object[] { focusRow["RPT_FILE_ID"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;

                    this.acAttachFileControl2.LinkKey = null;
                    this.acAttachFileControl2.ShowKey = null;

                    this.acAttachFileControl3.LinkKey = null;
                    this.acAttachFileControl3.ShowKey = null;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        // 업무일지 건별 첨부파일 불러오기  
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

                layout.GetEditor("DATE").Value = "PROPS_DATE";
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
                    //제안서 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

      
        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("PROPS_DATE", "제안일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PROPS_ID", "제안번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpOrg("ORG_CODE", "소속", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddLookUpEmp("EMP_CODE", "성명", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddTextEdit("TITLE", "제목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROPS_STATE", "개선완료여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("FINISH_DATE", "개선완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("GRADE", "등급", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REWARD", "포상금액(원)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddDateEdit("REWARD_DATE", "포상일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddHidden("APP_EMP1_OK", typeof(string));
            //acGridView1.AddHidden("APP_EMP2_OK", typeof(string));
            //acGridView1.AddHidden("APP_EMP3_OK", typeof(string));
            //acGridView1.AddHidden("APP_EMP4_OK", typeof(string));


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.KeyColumn = new string[] { "PROPS_ID" };

            acCheckedComboBoxEdit1.AddItem("제안일자", false, "", "PROPS_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("완료일자", false, "", "FINISH_DATE", true, false);

            
            base.MenuInit();

        }


        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
        }


        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                if (e.RowHandle < 0) return;

                string app1 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

                if (e.Column.FieldName.StartsWith("APP_EMP"))
                {
                    if (e.Column.FieldName.IndexOf("1") > -1)
                    {
                        //if (app1 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app1);
                        e.Appearance.ForeColor = GetStatFontColor(app1);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("2") > -1)
                    {
                        //if (app2 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app2);
                        e.Appearance.ForeColor = GetStatFontColor(app2);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("3") > -1)
                    {
                        //if (app3 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app3);
                        e.Appearance.ForeColor = GetStatFontColor(app3);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("4") > -1)
                    {
                        //if (app4 != "0")
                        //{
                        e.Appearance.BackColor = GetStatColor(app4);
                        e.Appearance.ForeColor = GetStatFontColor(app4);
                        //}
                    }
                }

                #region 기존소스
                //acGridView currentView = (sender as acGridView);

                #region 개선완료 여부에 따른 색상 변경 (보류중)
                ////if (e.Column.FieldName == "PROPS_STATUS")
                ////{
                ////    switch (e.CellValue.ToString())
                ////    {
                ////        case "완료":
                ////            e.Appearance.BackColor = Color.Yellow;
                ////            e.Appearance.ForeColor = Color.Black;
                ////            break;
                ////        case "반려":
                ////            e.Appearance.BackColor = Color.Red;
                ////            e.Appearance.ForeColor = Color.White;
                ////            break;
                ////        default:
                ////            break;
                ////    }
                ////}
                #endregion

                //if (e.Column.FieldName.Contains("APP_EMP"))
                //{
                //    DataRow row = currentView.GetDataRow(e.RowHandle);

                //    // 승인완료
                //    if ((!e.CellValue.isNullOrEmpty() && row[e.Column.FieldName + "_OK"].ToString() == "1"))
                //    {
                //        e.Appearance.BackColor = _OK;
                //        e.Appearance.ForeColor = Color.Black;

                //    }
                //    //승인대기 상태
                //    else if ((!e.CellValue.isNullOrEmpty() && row[e.Column.FieldName + "_OK"].ToString() == "0"))
                //    {
                //        e.Appearance.BackColor = _PROGRESS;
                //        e.Appearance.ForeColor = Color.Black;
                //    }

                //}
                #endregion
            }
            catch { }
        }

        Color GetStatColor(string flag)
        {
            Color color = Color.Transparent;

            switch (flag)
            {
                case "0":
                    color = _PROGRESS;
                    break;

                case "1":
                    color = _OK;
                    break;

                case "2":
                    color = _DENY;
                    break;
            }

            return color;
        }

        Color GetStatFontColor(string flag)
        {
            Color color = Color.Black;

            switch (flag)
            {
                case "0":
                    color = Color.Black;
                    break;

                case "1":
                    color = Color.Black;
                    break;

                case "2":
                    color = Color.Black;
                    break;
            }

            return color;
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

            paramTable.Columns.Add("S_PROPS_DATE", typeof(String)); //
            paramTable.Columns.Add("E_PROPS_DATE", typeof(String)); //
           
            paramTable.Columns.Add("S_FINISH_DATE", typeof(String)); //
            paramTable.Columns.Add("E_FINISH_DATE", typeof(String)); //

           
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["TITLE_LIKE"] = layoutRow["TITLE_LIKE"];


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {

                    case "PROPS_DATE":

                        //제안일자
                        paramRow["S_PROPS_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_PROPS_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                        
                        break;

                    case "FINISH_DATE":

                        //완료일자
                        paramRow["S_FINISH_DATE"] = ((DateTime)layoutRow["S_DATE"]).toDateString("yyyyMMdd");
                        paramRow["E_FINISH_DATE"] = ((DateTime)layoutRow["E_DATE"]).toDateString("yyyyMMdd");
                
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS16B_SER2", paramSet, "RQSTDT", "RSLTDT",
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

                if (!base.ChildFormContains(focusRow["PROPS_ID"]))
                {

                    SYS16B_D0A frm = new SYS16B_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["PROPS_ID"], frm);


                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["PROPS_ID"]);

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

                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROPS_ID", typeof(String)); //

                if (selected.Length == 0)
                {
                    //단일
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROPS_ID"] = focusRow["PROPS_ID"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    foreach(DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROPS_ID"] = row["PROPS_ID"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS16B_DEL", paramSet, "RQSTDT", "",
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


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 제안서 편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS16B_D0A frm = new SYS16B_D0A(acGridView1, null);

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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS16B_D1A frm = new SYS16B_D1A();

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
