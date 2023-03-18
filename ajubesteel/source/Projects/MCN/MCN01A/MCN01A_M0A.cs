using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;
using System.Text.RegularExpressions;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MCN
{
    public sealed partial class MCN01A_M0A : BaseMenu
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

        public MCN01A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;
            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;

            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;
            acGridView2.MouseDown += AcGridView2_MouseDown;
            
            acGridView3.ShowGridMenuEx += AcGridView3_ShowGridMenuEx;
            acGridView3.MouseDown += AcGridView3_MouseDown;
        }

       

        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }

        private void AcGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }



        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                DateTime rep_date = DateTime.Now;

                acGridView currentView = (sender as acGridView);

               
                if (e.Column.FieldName.Contains("REP_DATE"))
                {
                   
                    DataRow row = currentView.GetDataRow(e.RowHandle);

                    if(!row["MS_PERIOD"].isNullOrEmpty()) // 점검주기 유무확인
                    {
                        if (row["MS_PERIOD"].ToString().Contains("년"))
                        {
                            string year = Regex.Replace(row["MS_PERIOD"].ToString(), @"\D", ""); // 2년 -> 2로 변경

                            // Year +
                            rep_date = Convert.ToDateTime(row["REP_DATE"]).AddYears(year.toInt());

                        }
                        else
                        {
                            // Day +
                            rep_date = Convert.ToDateTime(row["REP_DATE"]).AddDays(row["MS_PERIOD"].toInt());
                        }
                    }

                    // 0: 비교대상 날짜와 현재날짜가 동일,   1: 비교날짜가 현재날짜보다 이전

                    if (DateTime.Now.Date.CompareTo(rep_date) >= 0 )  
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }
            
                }
            }
            catch { }
        }




        private void AcGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnOpenReg.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnOpenReg.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }


        private void AcGridView3_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnOpenRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDelRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnOpenRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnDelRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnOpenRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDelRep.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }


        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (sender is acGridView view)
                    {
                        switch (e.Clicks)
                        {
                            case 2:
                                {
                                    DataRow focusRow = view.GetFocusedDataRow();

                                    if (!base.ChildFormContains(focusRow["MS_NO"]))
                                    {

                                        MCN01A_D0A frm = new MCN01A_D0A(acGridView1, focusRow);
                                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                                        frm.ParentControl = this;
                                        base.ChildFormAdd(focusRow["MS_NO"], frm);
                                        frm.ShowDialog(this);
                                    }
                                    else
                                    {
                                        base.ChildFormFocus(focusRow["MS_NO"]);
                                    }

                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }
            }
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (sender is acGridView view)
                    {
                        switch (e.Clicks)
                        {
                            case 2:
                                {
                                    DataRow focusRow = view.GetFocusedDataRow();

                              
                                    if (!base.ChildFormContains(focusRow["MS_NO"]))
                                    {

                                        MCN01A_D1A frm = new MCN01A_D1A(acGridView1, acGridView2, focusRow);
                                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                                        frm.ParentControl = this;
                                        base.ChildFormAdd(focusRow["MS_NO"], frm);


                                        switch (focusRow["HIS_TYPE"].ToString())
                                        {
                                            case "GIVE":
                                                frm.FormStatus = MCN01A_D1A.emStatus.GIVE;
                                                break;
                                            case "RETURN":
                                                frm.FormStatus = MCN01A_D1A.emStatus.RETURN;
                                                break;
                                            case "DISUSE":
                                                frm.FormStatus = MCN01A_D1A.emStatus.DISUSE;
                                                break;
                                        }

                                        frm.ShowDialog(this);
                                    }
                                    else
                                    {
                                        base.ChildFormFocus(focusRow["MS_NO"]);
                                    }

                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }
            }
        }

        private void AcGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (sender is acGridView view)
                    {
                        switch (e.Clicks)
                        {
                            case 2:
                                {
                                    DataRow focusRow = view.GetFocusedDataRow();

                                    if (!base.ChildFormContains(focusRow["MS_NO"]))
                                    {

                                        MCN01A_D2A frm = new MCN01A_D2A(acGridView1, acGridView2, focusRow);
                                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                                        frm.ParentControl = this;
                                        base.ChildFormAdd(focusRow["MS_NO"], frm);
                                        frm.ShowDialog(this);
                                    }
                                    else
                                    {
                                        base.ChildFormFocus(focusRow["MS_NO"]);
                                    }

                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }
            }
        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;
            }

            base.ChildContainerInit(sender);
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
            try
            {
                #region 계측기 목록
                acGridView1.AddTextEdit("MS_NO", "관리번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("ASSET_NO", "자산번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MS_TYPE", "유형 그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M030");
                acGridView1.AddLookUpEdit("MS_STATE", "상태 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M031");
                acGridView1.AddLookUpEdit("MS_CAT", "계측기 분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M032");
                acGridView1.AddTextEdit("MS_NAME", "계측기명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MS_SERIAL_NO", "시리얼 번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MS_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MS_MAKER", "제조사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MS_COST", "가격", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("MS_BUY_DATE", "구입일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpOrg("GIVE_ORG_CODE", "지급 부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddLookUpEmp("GIVE_EMP_CODE", "사용자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddDateEdit("GIVE_DATE", "지급일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("REP_DATE", "최종 검교정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("MS_PERIOD", "교정주기(일)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("REP_VEN", "교정업체", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("MS_NEXT_DATE", "차기 교정계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DISUSE_DATE", "폐기일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView1.AddLookUpEdit("", "계측기 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "");
                acGridView1.AddLookUpEmp("REG_EMP", "최초 등록자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                
                acGridView1.KeyColumn = new string[] { "MS_NO" };
                
                #endregion

                #region 지급 이력 => 이력인듯
                acGridView2.AddTextEdit("MS_HIS_ID", "등록ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MS_NAME", "계측기이름", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("HIS_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M033");
                //acGridView2.AddLookUpEmp("HIS_EMP", "사용자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddTextEdit("HIS_EMP_NAME", "사용자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddDateEdit("HIS_DATE", "작업일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEmp("REG_EMP", "최초 등록자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
                acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);
                
                acGridView2.KeyColumn = new string[] { "MS_HIS_ID" };
               
                #endregion

                #region 검교정 및 보전 이력

                acGridView3.AddTextEdit("MS_REP_ID", "검교정ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("REP_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M034");
                acGridView3.AddTextEdit("MS_NAME", "계측기이름", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("REP_VEN", "교정 업체", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("REP_DATE", "교정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEmp("REG_EMP", "최초 등록자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
                acGridView3.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

                acGridView3.KeyColumn = new string[] { "MS_REP_ID" };
           
                #endregion

                (acLayoutControl1.GetEditor("MS_CAT") as acLookupEdit).SetCode("M032"); //계측기 분류
                (acLayoutControl1.GetEditor("MS_TYPE") as acLookupEdit).SetCode("M030");//계측기 상태

                base.MenuInit();
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

        void Search()
        {


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MS_NO_LIKE", typeof(String)); //
            paramTable.Columns.Add("MS_CAT", typeof(String)); //
            paramTable.Columns.Add("MS_NAME_LIKE", typeof(String)); //
            paramTable.Columns.Add("MCN_EMP", typeof(String)); //
            paramTable.Columns.Add("MCN_GRP", typeof(String)); //
            paramTable.Columns.Add("MS_TYPE", typeof(String)); //
            paramTable.Columns.Add("DAY_ARRANGE", typeof(Int32)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_NO_LIKE"] = layoutRow["MS_NO_LIKE"];
            paramRow["MS_CAT"] = layoutRow["MS_CAT"];
            paramRow["MS_NAME_LIKE"] = layoutRow["MS_NAME_LIKE"];
            paramRow["MCN_EMP"] = layoutRow["MCN_EMP"];
            paramRow["MCN_GRP"] = layoutRow["MCN_GRP"];
            paramRow["MS_TYPE"] = layoutRow["MS_TYPE"];
            if (layoutRow["IS_REPAIR"].toInt() == 1)
            {
                paramRow["DAY_ARRANGE"] = 30;
            }

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MCN01A_SER1", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void GetDetail()
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
                return;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MS_NO", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_NO"] = focusRow["MS_NO"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "MCN01A_SER2", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
              QuickSearchDetail,
              QuickException);
        }

        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_HIS"];
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_REP"];

                acGridView2.BestFitColumns();
                acGridView3.BestFitColumns();

               
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

        /// <summary>
        /// 계측기 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (!base.ChildFormContains("NEW"))
                {

                    MCN01A_D0A frm = new MCN01A_D0A(acGridView1, null);
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
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 계측기 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D0A frm = new MCN01A_D0A(acGridView1, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 계측기 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MS_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MS_NO"] = focusRow["MS_NO"];
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MCN01A_UDE", paramSet, "RQSTDT", "RSLTDT",
                    QuickDel,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow delRow in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(delRow);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 계측기 지급
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGiveMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D1A frm = new MCN01A_D1A(acGridView1, acGridView2, focusRow);
                    frm.FormStatus = MCN01A_D1A.emStatus.GIVE;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 계측기 반납
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D1A frm = new MCN01A_D1A(acGridView1, acGridView2, focusRow);
                    frm.FormStatus = MCN01A_D1A.emStatus.RETURN;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 계측기 폐기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisuseMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D1A frm = new MCN01A_D1A(acGridView1, acGridView2, focusRow);
                    frm.FormStatus = MCN01A_D1A.emStatus.DISUSE;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 계측기 검교정 및 보전 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepairMeasure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D2A frm = new MCN01A_D2A(acGridView1, acGridView3, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 열기

            try
            {

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D1A frm = new MCN01A_D1A(acGridView1, acGridView2, focusRow);

                    switch (focusRow["HIS_TYPE"])
                    {
                        case "GIVE":
                            {
                                frm.FormStatus = MCN01A_D1A.emStatus.GIVE;
                            }
                            break;
                        case "RETURN":
                            {
                                frm.FormStatus = MCN01A_D1A.emStatus.RETURN;
                            }
                            break;
                        case "DISUSE":
                            {
                                frm.FormStatus = MCN01A_D1A.emStatus.DISUSE;
                            }
                            break;
                    }


                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
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
                    acGridView2.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnOpenRep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 검교정 열기 
            try
            {
                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["MS_NO"]))
                {
                    MCN01A_D2A frm = new MCN01A_D2A(acGridView1, acGridView3, focusRow);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd(focusRow["MS_NO"], frm);
                    frm.ShowDialog(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MS_NO"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnDelRep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 검교정 삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView3.EndEditor();

                DataRow focusRow = acGridView3.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MS_REP_ID", typeof(String)); //
                paramTable.Columns.Add("MS_NO", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MS_REP_ID"] = focusRow["MS_REP_ID"];
                paramRow["MS_NO"] = focusRow["MS_NO"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "HIS03A_DEL6", paramSet, "RQSTDT", "",
                QuickDEL2,
                QuickException);

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
                    acGridView3.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }

}
