using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace STD
{
    public sealed partial class STD16A_M0A : BaseMenu
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

        public STD16A_M0A()
        {
            InitializeComponent();
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("IDLE_ID", "정례화 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IDLE_NAME", "정례화명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IDLE_START_TIME", "시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.HHmm);

            acGridView1.AddTextEdit("IDLE_END_TIME", "종료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.HHmm);

            acGridView1.AddTextEdit("IDLE_SEQ", "순번", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddCheckEdit("IDLE_FLAG", "야간여부", "", false, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "IDLE_ID" };


            //이벤트 설정

            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);



            base.MenuInit();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                this.Search();
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


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }


        void Search()
        {
            //조회

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("IDLE_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["IDLE_LIKE"] = layoutRow["IDLE_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD16A_SER", paramSet, "RQSTDT", "RSLTDT",
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

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void EditItem()
        {
            //열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["IDLE_ID"]))
                {

                    STD16A_D0A frm = new STD16A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["IDLE_ID"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["IDLE_ID"]);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditItem();         
        }

        private void AddItem()
        {
            try
            {
                //새로만들기 거래처편집기
                if (!base.ChildFormContains("NEW"))
                {
                    STD16A_D0A frm = new STD16A_D0A(acGridView1, null);

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

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.EndEditor();
                
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("IDLE_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                if (selected.Count == 0)
                {
                    //단일 삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["IDLE_ID"] = focusRow["IDLE_ID"];
                    paramRow["DEL_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["IDLE_ID"] = selected[i]["IDLE_ID"];
                        paramRow["DEL_EMP"] = acInfo.UserID;

                        paramTable.Rows.Add(paramRow);
                    }

                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD16A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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
    }
}