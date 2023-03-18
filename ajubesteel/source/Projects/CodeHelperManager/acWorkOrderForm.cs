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
    public sealed partial class acWorkOrderForm : BaseMenuDialog
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

        public acWorkOrder.emMethodType ExecuteMethodType { get; set; }

        public acWorkOrderForm()
        {
            InitializeComponent();

            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddLookUpEdit("IS_REWORK", "재작업여부", "", false , DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");


            acGridView1.KeyColumn = new string[] { "WO_NO" };

            DataTable dtProcList = ExtensionMethods.GetProcList(this);

            foreach (DataRow row in dtProcList.Rows)
            {
                if (row["PROC_CODE"].ToString() == "P-01"
                    || row["PROC_CODE"].ToString() == "P-02"
                    || row["PROC_CODE"].ToString() == "P-04"
                    || row["PROC_CODE"].ToString() == "P-09")
                {
                    acCheckedComboBoxEdit1.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false, CheckState.Checked);
                }
                else
                {
                    acCheckedComboBoxEdit1.AddItem(row["PROC_NAME"].ToString(), false, "", row["PROC_CODE"].ToString(), true, false);
                }
            }

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


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

                acWorkOrder ctrl = (acWorkOrder)base.ParentControl;
                
                acLayoutControl1.GetEditor("PROD_LIKE").Value = ctrl.ProdCode;
                acLayoutControl1.GetEditor("PART_LIKE").Value = ctrl.PartCode;

                acCheckedListBoxItem item = acCheckedComboBoxEdit1.GetItem(ctrl.ProcCode);
                if(item != null) item.CheckState = CheckState.Checked;

                //고정 작업지시상태가 설정되면 모두 체크해제및 사용금지

                if (ctrl.FixedWoFlag.Length != 0)
                {

                }


                //조건저장 복원

                if (this.ExecuteMethodType == acWorkOrder.emMethodType.FIND)
                {
                    if (ctrl._ConditionStorage != null)
                    {
                        acLayoutControl1.SetData(ctrl._ConditionStorage.Tables[0].Rows[0]);

                    }
                }
                else if (this.ExecuteMethodType == acWorkOrder.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("WO_NO").Value = this.Parameter;


                }

            }


            base.ChildContainerInit(sender);
        }



        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
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
            acLayoutControl1.GetEditor("WO_NO").FocusEdit();


            if (this.ExecuteMethodType == acWorkOrder.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_WO_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
                else
                {

                    if (((acWorkOrder)base.ParentControl).PROD_CODE != null)
                    {
                        string prod_code = ((acWorkOrder)base.ParentControl).PROD_CODE.ToString();
                        string part_code = ((acWorkOrder)base.ParentControl).PART_CODE.ToString();

                        if (prod_code != "")
                        {
                            acLayoutControl1.GetEditor("PROD_LIKE").Value = prod_code;
                            acLayoutControl1.GetEditor("PART_LIKE").Value = part_code;
                            Search();
                        }
                    }
                }
      
            }
            else if (this.ExecuteMethodType == acWorkOrder.emMethodType.QUICK_FIND)
            {
                this.Search();
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
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("WO_NO", typeof(String));
            paramTable.Columns.Add("PROD_LIKE", typeof(String));
            paramTable.Columns.Add("PART_LIKE", typeof(String));
            paramTable.Columns.Add("PROC_CODE_IN", typeof(String));

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = layoutRow["WO_NO"];
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

            string procCodeIn = string.Empty;
            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                procCodeIn = procCodeIn + key + ",";
            }

            if (procCodeIn.Length > 0)
            {
                procCodeIn = procCodeIn.Substring(0, procCodeIn.Length - 1);
            }

            paramRow["PROC_CODE_IN"] = procCodeIn;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this,
               QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_WORKORDER_SEARCH", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            (base.ParentControl as acWorkOrder)._ConditionStorage = layoutRow.Table.NewDataSet();

            base.OnClosing(e);
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