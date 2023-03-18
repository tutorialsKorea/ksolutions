using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acParentPartForm : BaseMenuDialog
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

        public acParentPart.emMethodType ExecuteMethodType { get; set; }

        public acParentPartForm()
        {
            InitializeComponent();


            acGridView1.GridType = ControlManager.acGridView.emGridType.LIST;


            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PT_NAME", "부품명", "40234", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PART_CODE", "PART_NUM" };



            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

  
        }
        
        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }


        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            if (this.ExecuteMethodType == acParentPart.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PPART_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }


        }


        void Search()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("LANG", typeof(String)); //언어
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //금형코드
            paramTable.Columns.Add("MY_PT_ID", typeof(String)); //현재 자신 부품 ID 에 대한 파생부품 제외함


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramRow["PROD_CODE"] = ((acParentPart)base.ParentControl).PROD_CODE;
            paramRow["MY_PT_ID"] = ((acParentPart)base.ParentControl).PT_ID;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "CONTROL_PARENTPART_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);


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


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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


        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
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