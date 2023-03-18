using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;

using BizManager;

namespace STD
{
    public sealed partial class STD45A_M0A : BaseMenu
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

        public STD45A_M0A()
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


            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            
            
            acGridView1.AddTextEdit("PANEL_CODE", "단말기코드", "41162", false , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PANEL_NAME", "단말기명", "41202", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            //acGridView1.AddLookUpEdit("CONN_TYPE", "연결 타입", "40400", false , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S029");

            //acGridView1.AddTextEdit("CONN_INFO", "연결 정보", "40400", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PANEL_SEQ", "표시순서", "40400", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("MAIN_MC", "설비코드", "40400", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAIN_MC_NAME", "설비명", "40400", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "PANEL_CODE" };

            

            //acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);  

            acLayoutControl1.OnValueKeyDown+=new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            base.MenuInit();
        }

        private void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            //if (acGridView1.FocusedRowHandle < 0)
            //{
            //    return;
            //}

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


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


                //팝업메뉴 열기

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //this.GetDetail();
        }



        //void GetDetail()
        //{
        //    try
        //    {
        //        if (acGridView1.ValidFocusRowHandle() == true)
        //        {
        //            DataRow focusRow = acGridView1.GetFocusedDataRow();

        //            DataTable paramTable = new DataTable("RQSTDT");
        //            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //            paramTable.Columns.Add("MC_CODE", typeof(String)); //

        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["MC_CODE"] = focusRow["MC_CODE"];
        //            paramTable.Rows.Add(paramRow);
        //            DataSet paramSet = new DataSet();
        //            paramSet.Tables.Add(paramTable);

        //            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD44A_SER2", paramSet, "RQSTDT", "RSLTDT",
        //                            QuickDetail,
        //                            QuickException);
        //        }
        //        else
        //        {
        //            acGridView2.ClearRow();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}


        //void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

        //        acGridView2.BestFitColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}


        //void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        //{

        //    if (acGridView1.FocusedRowHandle < 0)
        //    {
        //        return;
        //    }

        //    acGridView view = sender as acGridView;

        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {




        //        if (e.MenuType == GridMenuType.User)
        //        {
        //            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


        //        }
        //        else if (e.MenuType == GridMenuType.Row)
        //        {
        //            if (e.HitInfo.RowHandle >= 0)
        //            {

        //                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            }
        //            else
        //            {
        //                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            }

        //        }


        //        //팝업메뉴 열기

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


        //    }
        //}

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
           
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

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PANEL_LIKE", typeof(String));


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PANEL_LIKE"] = layoutRow["PANEL_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD45A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }



        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                
                acGridView1.BestFitColumns();

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }



        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        /// <summary>
        /// 새로 만들기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focused = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains("NEW"))
                {
                    STD45A_D0A frm = new STD45A_D0A(acGridView1, focused);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;


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

        /// <summary>
        /// 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["PANEL_CODE"]))
                {

                    STD45A_D0A frm = new STD45A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["PANEL_CODE"], frm);


                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["PANEL_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                paramTable.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드


                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PANEL_CODE"] = focusRow["PANEL_CODE"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Length; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PANEL_CODE"] = selected[i]["PANEL_CODE"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                        paramTable.Rows.Add(paramRow);
                    }


                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "STD45A_DEL", paramSet, "RQSTDT", "",
                QuickDel,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //점검항목 편집기 열기

                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

    }
}

