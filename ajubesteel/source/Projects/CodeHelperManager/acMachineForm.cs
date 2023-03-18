using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acMachineForm : BaseMenuDialog
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

        public acMachine.emMethodType ExecuteMethodType { get; set; }

        public acMachineForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            acGridView1.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CT", "Cycle Time", "40774", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_TON", "Ton", "K8GKZPXM", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);


//            acGridView1.AddTextEdit("MC_SEQ", "표시순서", "40723", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_TYPE", "신호취득", "V4OOUWJC", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C022");

            acGridView1.AddTextEdit("MC_IP", "설비IP", "42556", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.IP);

            //acGridView1.AddTextEdit("FTP_PORT", "FTP 포트", "881W45YM", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "MC_CODE" };

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = acLayoutControl1 as acLayoutControl;


                if (this.ExecuteMethodType == acMachine.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("MC_LIKE").Value = this.Parameter;

                }

            }

            base.ChildContainerInit(sender);
        }

        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            //포커스
            acLayoutControl1.GetEditor("MC_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acMachine.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_MACHINE_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acMachine.emMethodType.QUICK_FIND)
            {
                this.Search();
            }

        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            acMachine parent = (acMachine)base.ParentControl;

            if (parent.PROC_CODE == null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AVAILEMP", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String));
                paramTable.Columns.Add("MC_LIKE", typeof(String)); //
                paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
                paramRow["MC_GROUP"] = parent.PARENT_MC_CODE;
                paramRow["AVAILEMP"] = parent.AVAILEMP;
                paramRow["DATA_FLAG"] = 0;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CTRL", "CONTROL_MACHINE_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);

            }
            else
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String));
                paramTable.Columns.Add("AVAILEMP", typeof(String)); //
                paramTable.Columns.Add("MC_LIKE", typeof(String)); //
                paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROC_CODE"] = parent.PROC_CODE;
                paramRow["MC_GROUP"] = parent.PARENT_MC_CODE;
                paramRow["AVAILEMP"] = parent.AVAILEMP;
                paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];

                paramRow["DATA_FLAG"] = 0;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CTRL", "CONTROL_AVAILMACHINE_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }



        }



        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

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
    }
}