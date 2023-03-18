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

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace HIS
{
    public sealed partial class HIS02A_M0A : BaseMenu
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

        public HIS02A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;

            acLayoutControl4.OnValueChanged += acLayoutControl4_OnValueChanged;

        }


        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.SearchMtn();
        }

        void acLayoutControl4_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;
            switch (info.ColumnName)
            {
                case "YEAR":
                    this.SearchPlan(newValue);
                    break;
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
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._INT);
                acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
                acGridView1.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new[] { "MC_CODE" };

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.AddTextEdit("MTN_CODE", "관리코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MC_PERIOD", "보전주기(일)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("P_SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                          
                acGridView2.KeyColumn = new[] { "MTN_CODE"};

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.AddTextEdit("MTN_CODE", "보전코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("PLN_DATE", "계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddDateEdit("NEXT_PLN_DATE", "다음 계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddDateEdit("ACT_DATE", "실적일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.KeyColumn = new[] { "MTN_CODE", "MC_CODE", "PLN_DATE" };

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
            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["YEAR"];
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "HIS02A_SER1", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_PLAN"];
                acGridView1.SetOldFocusRowHandle(false);

                DataRow layoutRow = acLayoutControl4.CreateParameterRow();
                if(layoutRow != null
                    && layoutRow["YEAR"].isNullOrEmpty())
                {
                    acLayoutControl4.GetEditor("YEAR").Value = DateTime.Now;
                }
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

        private void SearchMtn()
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                    return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = focusRow["MC_CODE"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS02A_SER2", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearchMtn,
                  QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSearchMtn(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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
        private void SearchPlan(object selYear)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["YEAR"] = selYear;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "HIS02A_SER3", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearchPlan,
                  QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSearchPlan(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataView selView = acGridView1.GetDataSourceView("SEL=1");

                if (selView.Count == 0)
                {
                    acMessageBox.Show(this, "대상 설비를 선택해 주십시오.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataSet paramSet = new DataSet();

                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
               
                foreach (DataRowView row in selView)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = row["MC_CODE"];
                    paramTable.Rows.Add(paramRow);
                }

                if (!base.ChildFormContains("NEW"))
                {
                    HIS02A_D0A frm = new HIS02A_D0A(acGridView3, paramTable);
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ParentControl = this;
                    base.ChildFormAdd("NEW", frm);
                    frm.ShowDialog(this);

                    DataRow layoutRow = acLayoutControl4.CreateParameterRow();
                    this.SearchPlan(layoutRow["YEAR"]);
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
