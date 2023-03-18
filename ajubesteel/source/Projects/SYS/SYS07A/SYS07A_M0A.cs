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

using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS07A_M0A : BaseMenu
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



        public SYS07A_M0A()
        {
            InitializeComponent();

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }


        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "40225", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "사원명", "40266", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            acGridView1.Columns["ORG_NAME"].GroupIndex = 0;
            acGridView1.Columns["ORG_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;

            base.MenuInit();
        }

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }
        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            
            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS07A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
        }


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 복사
            try
            {
                acGridView1.EndEditor();

                SYS07A_D0A frm = new SYS07A_D0A();

                frm.Text = e.Item.Caption;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow frmRow = frm.OutputData as DataRow;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("SOURCE_EMP", typeof(String)); //원본 사용자 코드
                    paramTable.Columns.Add("TARGET_EMP", typeof(String)); //대상 사용자코드


                    DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                    if (selected.Count == 0)
                    {

                        //단일선택

                        DataRow focusRow = acGridView1.GetFocusedDataRow();


                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["SOURCE_EMP"] = frmRow["SOURCE_EMP"];
                        paramRow["TARGET_EMP"] = focusRow["EMP_CODE"];
                        paramTable.Rows.Add(paramRow);

                    }
                    else
                    {
                        //다중선택
                        for (int i = 0; i < selected.Count; i++)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["SOURCE_EMP"] = frmRow["SOURCE_EMP"];
                            paramRow["TARGET_EMP"] = selected[i]["EMP_CODE"];
                            paramTable.Rows.Add(paramRow);
                        }

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "SYS07A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickProcess,
                        QuickException);

                }


                //사용자 UI을 하기때문에 현재는 폼은 해제하지않음
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickProcess(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.SetValue("SEL", "0");

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);

                //base.SetLog(e.executeType, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 초기화(전체)
            try
            {
                if (acMessageBox.Show(this, "정말 초기화 하시겠습니까?", "T20NZ3XF", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));


                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                if (selected.Count == 0)
                {

                    //단일선택

                    DataRow focusRow = acGridView1.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중선택
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = selected[i]["EMP_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "SYS07A_DEL", paramSet, "RQSTDT", "RSLTDT",
                    QuickProcess,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 초기화(자동)
            try
            {
                if (acMessageBox.Show(this, "정말 초기화 하시겠습니까?", "T20NZ3XF", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));
                paramTable.Columns.Add("USE_CONFIG_NAME", typeof(String));

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                if (selected.Count == 0)
                {

                    //단일선택

                    DataRow focusRow = acGridView1.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
                    paramRow["USE_CONFIG_NAME"] = acInfo.DefaultConfigName;

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중선택
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = selected[i]["EMP_CODE"];
                        paramRow["USE_CONFIG_NAME"] = acInfo.DefaultConfigName;
                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "SYS07A_DEL2", paramSet, "RQSTDT", "RSLTDT",
                    QuickProcess,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}
