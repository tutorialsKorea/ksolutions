using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;


namespace CodeHelperManager
{
    public sealed partial class acBillVendorForm : BaseMenuDialog
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

        public acBillVendor.emMethodType ExecuteMethodType { get; set; }

        public acBillVendorForm()
        {

            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("BVEN_CODE", "마감처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BVEN_NAME", "마감처명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("BVEN_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "V001");
            acGridView1.AddLookUpEdit("BVEN_CURRENCY", "화폐", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "V002");

            acGridView1.MouseDown += new MouseEventHandler(gvVendor_MouseDown);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


        }


        /// <summary>
        /// 입력 파라메터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();

        public override void DialogInit()
        {
            acBillVendor edit = this.ParentControl as acBillVendor;


            base.DialogInit();
        }


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);


            //포커스
            acLayoutControl1.GetEditor("BVEN_LIKE").FocusEdit();



            if (this.ExecuteMethodType == acBillVendor.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_BILL_VENDOR_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acBillVendor.emMethodType.QUICK_FIND)
            {
                this.Search();
            }

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
                acLayoutControl layout = sender as acLayoutControl;

                acBillVendor ctrl = (acBillVendor)base.ParentControl;

                if (this.ExecuteMethodType == acBillVendor.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("BVEN_LIKE").Value = this.Parameter;

                }

            }

        }

        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }



            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("BVEN_LIKE", typeof(String));


            //부모 파라메터 컬럼 생성

            if (base.ParentControl is acProd)
            {

                acProd ctrl = (acProd)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }

            //창 파라메터 컬럼 생성
            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BVEN_LIKE"] = layoutRow["BVEN_LIKE"];

            //부모 파라메터 입력

            if (base.ParentControl is acProd)
            {

                acProd ctrl = (acProd)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }

            }

            //창 파라메터 입력
            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_BILL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);


        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
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

        void gvVendor_MouseDown(object sender, MouseEventArgs e)
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


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //검색
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

