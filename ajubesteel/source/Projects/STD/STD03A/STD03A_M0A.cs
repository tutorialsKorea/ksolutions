using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD03A_M0A : BaseMenu
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

        public STD03A_M0A()
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
            acGridView1.GridType = ControlManager.acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);


            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MQLTY_CODE", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MQLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("PART_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "PLN_CODE" };


            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);


            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);


            acGridView2.GridType = acGridView.emGridType.SEARCH;



            acGridView2.AddTextEdit("PLN_SEQ", "순서", "40382", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView2.AddTextEdit("PLN_PROC", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PLN_PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("LOADABLE_MC", "가용설비", "40011", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PLN_MAN_TIME", "유인 계획공수", "5PODWBO7", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView2.AddTextEdit("PLN_SELF_TIME", "무인 계획공수", "7MNBO9IX", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


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

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["PLN_CODE"]);
            }
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //표준공정계획 편집기 열기

                    this.acBarButtonItem5_ItemClick(null, null);
                }

            }
        }


        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {


                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }

        }




        void GetDetail()
        {

            if (acGridView1.ValidFocusRowHandle() == true)
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //필수,사업장 코드
                paramTable.Columns.Add("PLN_CODE", typeof(String)); //필수,표준공정계획 코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                paramRow["PLN_CODE"] = focusRow["PLN_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "STD03A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickDetail,
                QuickException);


            }
            else
            {
                acGridView2.ClearRow();
            }


        }


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }



        void Search()
        {

            //조회

            DataRow layout = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable.Columns.Add("PART_SPEC1_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_LIKE"] = layout["PART_LIKE"];
            paramRow["PART_SPEC1_LIKE"] = layout["PART_SPEC1_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD03A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);




        }
        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

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



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공정계획 삭제
            try
            {
                acGridView1.EndEditor();

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PLN_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");



                if (selectedView.Count == 0)
                {
                    //단일 삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLN_CODE"] = focusRow["PLN_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중 삭제
                    foreach (DataRowView rv in selectedView)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLN_CODE"] = rv["PLN_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);

                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD03A_DEL", paramSet, "RQSTDT", "",
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


        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //새로만들기 표준공정계획 편집기
                if (!base.ChildFormContains("NEW"))
                {

                    STD03A_D0A frm = new STD03A_D0A(acGridView1, new object[] { null, null });

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


        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 표준공정계획 편집기
            try
            {

                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["PLN_CODE"]))
                {

                    STD03A_D0A frm = new STD03A_D0A(acGridView1, new object[] { focusRow, acGridView2.GridControl.DataSource });

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["PLN_CODE"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["PLN_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공정삭제
            try
            {
                acGridView2.DeleteRow(acGridView2.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공정계획공수 갱신
            try
            {
                acGridView1.EndEditor();

                STD03A_D1A frm = new STD03A_D1A();

                frm.Text = e.Item.Caption;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    List<DataSet> paramSets = new List<DataSet>();


                    DataRow frmRow = frm.OutputData as DataRow;

                    DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");


                    if (selectedView.Count == 0)
                    {
                        //단일
                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("PLN_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //


                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PLN_CODE"] = focusRow["PLN_CODE"];
                        paramRow["S_WORK_DATE"] = frmRow["S_WORK_DATE"];
                        paramRow["E_WORK_DATE"] = frmRow["E_WORK_DATE"];
                        paramTable.Rows.Add(paramRow);


                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        paramSets.Add(paramSet);

                    }
                    else
                    {


                        //다중
                        for (int i = 0; i < selectedView.Count; i++)
                        {

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("PLN_CODE", typeof(String)); //
                            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
                            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PLN_CODE"] = selectedView[i]["PLN_CODE"];
                            paramRow["S_WORK_DATE"] = frmRow["S_WORK_DATE"];
                            paramRow["E_WORK_DATE"] = frmRow["E_WORK_DATE"];
                            paramTable.Rows.Add(paramRow);


                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            paramSets.Add(paramSet);
                        }




                    }



                    BizRun.QBizRun.ExecuteMultiService(
                    this, QBiz.emExecuteType.PROCESS,
                    "STD03A_UPD", paramSets, "RQSTDT", "",
                    QuickUPD,
                    QuickMultiException);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

        void QuickUPD(object sender, QBizMulti QBizMulti, QBizMulti.ExcuteCompleteArgs e)
        {
            acGridView1.SetValue("SEL", "0");

            acGridView1.RaiseFocusedRowChanged();
        }
        void QuickMultiException(object sender, QBizMulti QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


    }

}

