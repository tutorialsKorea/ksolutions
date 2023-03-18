using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace WOR
{
    public sealed partial class WOR15A_M0A : BaseMenu
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

        public WOR15A_M0A()
        {
            InitializeComponent();

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
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

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("EMP_CODE", "�����ȣ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_CODE", "�μ��ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "�μ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("HIRE_DATE", "�Ի���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEdit("PAY_CONTRACT", "�޿����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E002");
            acGridView1.AddTextEdit("HOLI_DATE", "�����ϼ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("NON_TIME", "����,����,����,����(��)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVER_TIME1", "����ٹ�(A)(�ð�)\r\n(1.5)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("NO_TIME", "���ܽð�\r\n(1.5)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SUB_TOTAL_TIME", "�հ�\r\n(1.5)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVER_TIME2", "����ٹ�(B)(�ð�)\r\n(0.5)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVER_TIME3", "����ٹ�(C)(�ð�)\r\n(1.0)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REAL_TOTAL_TIME", "��ü�հ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TOTAL_TIME", "��ü�հ�\r\n(���ܽð� ����)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.ColumnPanelRowHeight = 40;

            (acLayoutControl1.GetEditor("MONTH") as acDateEdit).Properties.EditMask = "yyyy-MM";


            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("MONTH").Value = acDateEdit.GetNowMonth();
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    //Search();

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

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));
            paramTable.Columns.Add("REQ_MONTH", typeof(String));
            paramTable.Columns.Add("IS_RETIRE", typeof(String));
            paramTable.Columns.Add("RETIRE_DATE_MONTH", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            paramRow["REQ_MONTH"] = layoutRow["MONTH"];
            paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];
            

            if (acCheckEdit1.Checked)
            {
                paramRow["IS_RETIRE"] = null;

                paramRow["RETIRE_DATE_MONTH"] = layoutRow["MONTH"];
            }
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR15A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();

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

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ
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

