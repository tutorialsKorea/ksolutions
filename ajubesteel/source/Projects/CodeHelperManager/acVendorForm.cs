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
    public sealed partial class acVendorForm : BaseMenuDialog
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

        public acVendor.emMethodType ExecuteMethodType { get; set; }

        public acVendorForm()
        {

            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("VEN_CODE", "�ŷ�ó�ڵ�", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_NAME", "�ŷ�ó��", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("VEN_SHORT_NAME", "�ŷ�ó����", "41005", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("VEN_TYPE", "�ŷ�ó ����", "6OAMFTNJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S019");

            acGridView1.AddLookUpEdit("VEN_CAT_CODE", "�ŷ�ó �з�", "U48S66C9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C016");

            //20160517 ���ر� - ���ֹ�ȣ �ڵ�ä��
            acGridView1.AddLookUpEdit("ITEM_AUTO_CODE", "���� ����", "L3MCOFSK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "D001");

            acGridView1.AddLookUpEdit("VEN_COUNTRY", "����", "40074", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S020");

            acGridView1.AddTextEdit("VEN_CEO", "��ǥ�ڸ�", "40139", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_BIZ_NO", "����ڵ�Ϲ�ȣ", "40256", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.CORP);

            acGridView1.AddTextEdit("VEN_ID_NO", "���ε�Ϲ�ȣ", "41006", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.LAW);

            acGridView1.AddDateEdit("VEN_START_DATE", "�ŷ�������", "40020", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("VEN_BANK", "�ŷ�����", "40022", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C404");

            acGridView1.AddTextEdit("VEN_BANK_NO", "���¹�ȣ", "E4T9XCVC", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_UPTAE", "����", "40421", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_UPJONG", "����", "40417", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("VEN_CREDIT", "�ſ���", "40396", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C021");

            acGridView1.AddTextEdit("VEN_ZIP", "�����ȣ", "40455", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.ZIP);

            acGridView1.AddTextEdit("VEN_ADDRESS", "�ּ�", "40626", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_TEL", "��ȭ��ȣ", "WCO6Q0OP", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TEL);

            acGridView1.AddTextEdit("VEN_FAX", "�ѽ�", "40713", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TEL);

            acGridView1.AddTextEdit("VEN_EMAIL", "E-Mail", "40790", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_PRODUCTS", "���ǰ��", "40683", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_CHARGE_EMP", "�����", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_CHARGE_DEPT", "����ںμ�", "42377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_CHARGE_TEL", "����� ��ȭ��ȣ", "40128", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TEL);

            acGridView1.AddTextEdit("VEN_CHARGE_HP", "����� �޴���", "40129", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TEL);

            acGridView1.AddTextEdit("SCOMMENT", "���", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.TEL);


            acGridView1.MouseDown += new MouseEventHandler(gvVendor_MouseDown);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


        }


        /// <summary>
        /// �Է� �Ķ����
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();

        public override void DialogInit()
        {
            //�ŷ�ó ����
            (acLayoutControl1.GetEditor("VEN_TYPE") as acLookupEdit).SetCode("S019");

            acVendor edit = this.ParentControl as acVendor;
            acLayoutControl1.GetEditor("VEN_TYPE").Value = edit.VenType;
            //acLookupEdit1.Value = edit.VenType;

            //�ŷ�ó �з�
            (acLayoutControl1.GetEditor("VEN_CAT_CODE") as acLookupEdit).SetCode("C016");

            base.DialogInit();
        }


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);


            //��Ŀ��
            acLayoutControl1.GetEditor("VEN_LIKE").FocusEdit();



            if (this.ExecuteMethodType == acVendor.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_VENDOR_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acVendor.emMethodType.QUICK_FIND)
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

                acVendor ctrl = (acVendor)base.ParentControl;

                if (this.ExecuteMethodType == acVendor.emMethodType.QUICK_FIND)
                {
                    //�ڵ� �˻��κп� �Է��� ��ȸ

                    layout.GetEditor("VEN_LIKE").Value = this.Parameter;

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
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //������ڵ�
            paramTable.Columns.Add("VEN_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_LIKE", typeof(String)); //VEN_CODE , NAME LIKE �˻�
            paramTable.Columns.Add("VEN_CAT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_TYPE", typeof(String)); //


            //�θ� �Ķ���� �÷� ����

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

            //â �Ķ���� �÷� ����
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
            paramRow["VEN_CODE"] = null;
            paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];
            paramRow["VEN_CAT_CODE"] = layoutRow["VEN_CAT_CODE"];
            paramRow["VEN_TYPE"] = layoutRow["VEN_TYPE"];

            //�θ� �Ķ���� �Է�

            if (base.ParentControl is acProd)
            {

                acProd ctrl = (acProd)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }

            }

            //â �Ķ���� �Է�
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

            //BizRun.QBizRun.ExecuteService(
            //    this, QBiz.emExecuteType.LOAD,
            //    "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            //    QuickSearch,
            //    QuickException);

            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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
            //�˻�
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
            //����
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

