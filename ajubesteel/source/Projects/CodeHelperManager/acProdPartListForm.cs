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
    public sealed partial class acProdPartListForm : BaseMenuDialog
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

        public acProdPartList.emMethodType ExecuteMethodType { get; set; }

        public acProdPartListForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;


            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PT_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("P_PART_CODE", "모부품코드", "42562", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("P_PART_NUM", "모품번", "42564", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("P_PART_NAME", "모부품명", "PRNIWQYY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("PART_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);



            acGridView1.AddTextEdit("WEIGHT_VOLUME", "소재중량", "40629", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.WEIGHT);


            acGridView1.AddTextEdit("UNIT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("MAT_COST", "자재비", "WEFGH5XM", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");




            acGridView1.KeyColumn = new string[] { "PT_ID" };




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

        protected override void OnShown(EventArgs e)
        {



            base.OnShown(e);

            //포커스
            acLayoutControl1.GetEditor("PART_LIKE").FocusEdit();


            if (this.ExecuteMethodType == acProdPartList.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PART_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }


        }


        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드

            paramTable.Columns.Add("PROD_CODE", typeof(String)); //금형코드
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //금형코드
            paramTable.Columns.Add("PART_NUM_LIKE", typeof(String)); //금형코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramRow["PROD_CODE"] = ((acProdPartList)base.ParentControl).PROD_CODE;
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["PART_NUM_LIKE"] = layoutRow["PART_NUM_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "CONTROL_PRODPART_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Search();
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