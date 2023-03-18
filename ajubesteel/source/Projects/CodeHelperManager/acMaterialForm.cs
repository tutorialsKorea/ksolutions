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
    public sealed partial class acMaterialForm : BaseMenuDialog
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

        public acMaterial.emMethodType ExecuteMethodType { get; set; }

        public acMaterialForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("MQLTY_CODE", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MQLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MQLTY_RANGE", "재질범위", "U2KQC8Y8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MQLTY_WEIGHT", "비중", "40248", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F6);
            acGridView1.AddTextEdit("UNIT_CONVERT_VALUE", "단위환산값", "VRR6Q9XZ", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("MQLTY_UC", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.KeyColumn = new string[] { "MQLTY_CODE" };
            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);



        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
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
            acLayoutControl1.GetEditor("MAT_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acMaterial.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_MATERIAL_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acMaterial.emMethodType.QUICK_FIND)
            {
                this.Search();
            }

        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                acMaterial ctrl = base.ParentControl as acMaterial;

                if (this.ExecuteMethodType == acMaterial.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("MAT_LIKE").Value = this.Parameter;

                }


            }

        }


        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //
            paramTable.Columns.Add("MQLTY_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MQLTY_CODE"] = null;
            paramRow["MQLTY_LIKE"] = layoutRow["MAT_LIKE"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
                        
            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "CTRL", "CONTROL_MQLTY_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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