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
using BizManager;

namespace SYS
{
    public sealed partial class SYS01A_M0A : BaseMenu
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





        public SYS01A_M0A()
        {
            InitializeComponent();



            acGridView1.ShowGridMenuEx+= new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }





        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["RPT_CLASS"]);
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

        public override void MenuInit()
        {


            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MENU_CODE", "메뉴코드", "C8PZLBQT", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MENU_NAME", "메뉴명", "D6UJPZ3J", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("RPT_CATEGORY_ID", "출력양식분류ID", "AZKPRF30", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("RPT_CLASS", "출력양식 클래스", "3YIY6L96", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("RPT_NAME", "출력양식명", "E1UPMPS1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("IS_USE", "사용여부", "UP426DTD",true , false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false,false, true,false);


            acGridView1.KeyColumn = new string[] { "RPT_CLASS" };


            base.MenuInit();

        }

        public override void MenuInitComplete()
        {


            base.MenuInitComplete();
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            GridView gridView = sender as GridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gridView.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem4_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            GridView gridView = sender as GridView;



            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = gridView.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(gridView.GridControl.PointToScreen(e.Point));


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

        void Search()
        {
            //조회

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //
            paramTable.Columns.Add("RPT_NAME_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramRow["RPT_NAME_LIKE"] = layoutRow["RPT_NAME_LIKE"];
            paramTable.Rows.Add(paramRow);
            
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "SYS01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];


                acGridView1.SetOldFocusRowHandle(true);


                //조회 메뉴로그 
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }





        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 출력양식 편집기
            try
            {
                if (!base.ChildFormContains("NEW_CLASS"))
                {
                    SYS01A_D1A frm = new SYS01A_D1A(acGridView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW_CLASS", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_CLASS");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 출력양식 편집기
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["RPT_CLASS"]))
                {

                    SYS01A_D1A frm = new SYS01A_D1A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["RPT_CLASS"], frm);

                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["RPT_CLASS"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 출력양식 
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView1.EndEditor();


                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RPT_CLASS", typeof(String)); //


                if (selectedView.Count == 0)
                {
                    //단일 선택

                    DataRow focusRow = acGridView1.GetFocusedDataRow();



                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RPT_CLASS"] = focusRow["RPT_CLASS"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 선택

                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["RPT_CLASS"] = selectedView[i]["RPT_CLASS"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS01A_DEL", paramSet, "RQSTDT", "",
                QuickDEL2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickDEL2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

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

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //출력양식 미리보기
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                ReportManager.acReportView.ShowReportClassPreview(focusRow["RPT_CLASS"].ToString());

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}
