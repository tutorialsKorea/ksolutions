using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acORGForm : BaseMenuDialog
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

        public acORG.emMethodType ExecuteMethodType { get; set; }

        public acORGForm()
        {
            InitializeComponent();


            acTreeList1.KeyFieldName = "ORG_CODE";
            acTreeList1.ParentFieldName = "ORG_PARENT";

            acTreeList1.AddTextEdit("ORG_CODE", "부서코드", "40225", true , DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ORG_NAME", "부서명", "40223", true , DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);




            acTreeList1.MouseDown += new MouseEventHandler(acTreeList1_MouseDown);



        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }


        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                TreeListHitInfo hitInfo = acTreeList1.CalcHitInfo(e.Location);

                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }




        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            if (this.ExecuteMethodType == acORG.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_ORG_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }



        }

        void Search()
        {
            //조회

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "CTRL", "CONTROL_ORG_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acTreeList1.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

                acTreeList1.ExpandAll();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickException(object sender, QBiz qBiz,  BizManager.BizException ex)
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

                if (acTreeList1.FocusedNode != null)
                {
                    DataRowView focusRowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);


                    base.OutputData = focusRowView.Row.NewTable();

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