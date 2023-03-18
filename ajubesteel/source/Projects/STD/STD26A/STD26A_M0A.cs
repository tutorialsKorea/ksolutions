using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace STD
{

    /// <summary>
    /// 재질관리
    /// </summary>
    public sealed partial class STD26A_M0A : BaseMenu
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

        public STD26A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.AUTO_COL;
            
            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MQLTY_CODE", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MQLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MQLTY_RANGE", "재질 범위", "U2KQC8Y8", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MQLTY_WEIGHT", "비중", "40248", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F6);

            acGridView1.AddTextEdit("UNIT_CONVERT_VALUE", "단위환산값", "VRR6Q9XZ", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "MQLTY_CODE" };



            acGridView2.GridType = acGridView.emGridType.AUTO_COL;
            
            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddCheckEdit("APPLIED", "적용", "", false, false, true, acGridView.emCheckEditDataType._YN);

            acGridView2.AddDateEdit("MQLTY_START", "적용시작일", "K802GZJQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("MQLTY_END", "적용종료일", "8QDB9HRE", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddTextEdit("MQLTY_UC", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.KeyColumn = new string[] { "QCD_ID" };




            //이벤트 설정

            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);


            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);


            acGridView2.ShowGridMenuEx+= new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);

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

        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["QCD_ID"]);
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["MQLTY_CODE"]);
            }
        }


        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //재질단가 적용기간 편집기 열기

                    this.acBarButtonItem4_ItemClick(null, null);
                }

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void GetDetail()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MQLTY_CODE"] = focusRow["MQLTY_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD26A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView2.GridControl.Enabled = true;
                acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];
                acGridView2.SetOldFocusRowHandle(false);
                

            }
            else
            {
                acGridView2.ClearRow();

                acGridView2.GridControl.Enabled = false;

            }

        }

        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                //acGridView2.GridControl.Enabled = true;

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView2.BestFitColumns();

                acGridView2.SetOldFocusRowHandle(false);

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

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //재질 편집기 열기

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

        public override void MenuInitComplete()
        {
            acGridView2.GridControl.Enabled = false;


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

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MQLTY_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MQLTY_LIKE"] = layoutRow["MQLTY_LIKE"];


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                    "STD26A_SER", paramSet, "RQSTDT", "RSLTDT",
                    QuickSearch,
                    QuickException);
            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.LOAD,
            //"STD26A_SER", paramSet, "RQSTDT", "RSLTDT",
            //QuickSearch,
            //QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];


                acGridView1.SetOldFocusRowHandle(true);

                //acGridView1.BestFitColumns();

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



        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재질 새로만들기
            try
            {
                if (!base.ChildFormContains("NEW_M"))
                {
                    STD26A_D0A frm = new STD26A_D0A(acGridView1, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_M", frm);

                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus("NEW_M");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재질 열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["MQLTY_CODE"]))
                {

                    STD26A_D0A frm = new STD26A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["MQLTY_CODE"], frm);

                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["MQLTY_CODE"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //재질 삭제
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
                paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["MQLTY_CODE"] = focusRow["MQLTY_CODE"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["MQLTY_CODE"] = selected[i]["MQLTY_CODE"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }


                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD26A_DEL", paramSet, "RQSTDT", "",
                    QuickDEL,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.DEL,
                //"STD26A_DEL", paramSet, "RQSTDT", "",
                //QuickDEL,
                //QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            //링크된 자식창 삭제

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



        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 재질단가 적용기간 편집기
            try
            {
                if (!base.ChildFormContains("NEW_D"))
                {
                    STD26A_D1A frm = new STD26A_D1A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_D", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_D");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재질단가 적용기간 편집기 열기

            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["QCD_ID"]))
                {

                    STD26A_D1A frm = new STD26A_D1A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["QCD_ID"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["QCD_ID"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }



        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재질단가 적용기간 삭제
            try
            {
                acGridView2.EndEditor();



                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCD_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //



                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["QCD_ID"] = focusRow["QCD_ID"];
                    paramRow["DEL_EMP"] = acInfo.UserID;


                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["QCD_ID"] = selected[i]["QCD_ID"];
                        paramRow["DEL_EMP"] = acInfo.UserID;


                        paramTable.Rows.Add(paramRow);
                    }


                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD26A_DEL2", paramSet, "RQSTDT", "",
                    QuickDEL2,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.DEL,
                //"STD26A_DEL2", paramSet, "RQSTDT", "",
                //QuickDEL2,
                //QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
        void QuickDEL2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {

                    acGridView2.DeleteMappingRow(row);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 데이터 불러오기

            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD26A_D2A frm = new STD26A_D2A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


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

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusedRow = acGridView2.GetFocusedDataRow();

                if (focusedRow == null) return;

                if (acMessageBox.Show("선택하신 단가로 품목정보에 일괄 적용하시겠습니까?", "재질 단가 일괄 적용", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("QCD_ID", typeof(String));
                    dtParam.Columns.Add("MQLTY_CODE", typeof(String));
                    dtParam.Columns.Add("MAT_UC", typeof(float));
                    dtParam.Columns.Add("MDFY_EMP", typeof(String));
                    dtParam.Columns.Add("APPLIED", typeof(String));

                    DataRow drParam = dtParam.NewRow();
                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["QCD_ID"] = focusedRow["QCD_ID"];
                    drParam["MQLTY_CODE"] = acGridView1.GetFocusedDataRow()["MQLTY_CODE"];
                    drParam["MAT_UC"] = focusedRow["MQLTY_UC"];
                    drParam["MDFY_EMP"] = acInfo.UserID;
                    drParam["APPLIED"] = "Y";

                    dtParam.Rows.Add(drParam);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtParam);

                    DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD26A_INS3", paramSet, "RQSTDT", "RSLTDT");

                    foreach (DataRow dr in dsResult.Tables["RSLTDT"].Rows)
                    {
                        acGridView2.UpdateMapingRow(dr, false);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}