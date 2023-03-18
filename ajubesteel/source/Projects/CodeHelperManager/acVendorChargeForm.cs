using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using BizManager;


namespace CodeHelperManager
{
    public sealed partial class acVendorChargeForm : BaseMenuDialog
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

        public acVendorCharge.emMethodType ExecuteMethodType { get; set; }

        public acVendorChargeForm()
        {
            InitializeComponent();


            gvEmployee.GridType = acGridView.emGridType.SEARCH;

            gvEmployee.AddTextEdit("VEN_CHARGE_ID", "담당자ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("VEN_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("CHARGE_EMP", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("CHARGE_DEPT", "담당부서", "42377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("CHARGE_TEL", "전화번호", "40128", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("CHARGE_HP", "휴대전화", "40129", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("CHARGE_EMAIL", "이메일", "40790", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            this.gvEmployee.MouseDown += new MouseEventHandler(gvEmployee_MouseDown);

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        void gvEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gvEmployee.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                    this.acBarButtonItem1_ItemClick(null, null);

                }

            }
        }


        private DataSet _EmpSet = null;

        private DataSet _OrgSet = null;


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            this.Search();

        }

        public override void ChildContainerInit(Control sender)
        {
            acEmp ctrl = base.ParentControl as acEmp;

            base.ChildContainerInit(sender);

        }

        void Search()
        {


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("VEN_CODE", typeof(String));
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_CODE"] = ((acVendorCharge)base.ParentControl).VenCode;
           
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_VENDOR_CHARGE_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);

        }


        protected override void OnClosing(CancelEventArgs e)
        {            

            base.OnClosing(e);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                this._EmpSet = e.result;

                gcEmployee.DataSource = e.result.Tables["RSLTDT"];

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


        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택

            try
            {
                DataRow focusRow = gvEmployee.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }
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



    }

}