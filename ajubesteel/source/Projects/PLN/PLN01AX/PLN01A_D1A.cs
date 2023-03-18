using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;
using ControlManager;
using CodeHelperManager;

namespace PLN
{
    public sealed partial class PLN01A_D1A : BaseMenuDialog
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

        private string _procCode;
        private string _partCode;
        private object _tag;

        public PLN01A_D1A(string part_code, string proc_code, object tag)
        {

            InitializeComponent();

            _partCode = part_code;
            _procCode = proc_code;

            _tag = tag;
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acProc1.Value = _procCode;

            if (_tag != null)
            {
                string[] info = _tag.ToString().Split(':');
                if (info.Length == 2) 
                {
                    acMachine1.Value = info[0];
                    acEmp1.Value = info[1];
                }
            }
        }

        public string GetSelected()
        {
            string mc_code = string.Empty;
            string emp_code = string.Empty;

            if (acMachine1.Value != null)
                mc_code = acMachine1.Value.ToString();

            if (acEmp1.Value != null)
                emp_code = acEmp1.Value.ToString();

            return mc_code + ":" + emp_code;
        }

        public string GetMcName()
        {
            return acMachine1.SelectedRow["MC_NAME"].ToString();
        }

        public string GetEmpName()
        {
            return acEmp1.SelectedRow["EMP_NAME"].ToString();
        }

        private DataSet SaveData()
        {
            if (acLayoutControl1.ValidCheck() == false) return null;
            
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PART_CODE", typeof(String));
            paramTable.Columns.Add("PROC_CODE", typeof(String));
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = _partCode;
            paramRow["PROC_CODE"] = _procCode;
            paramRow["MC_CODE"] = layoutRow["MC_CODE"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;
        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
              
                case "PROC_CODE":
                    acMachine1.PROC_CODE = newValue;

                    DataTable availMc = acMachine.GetAvailMcByProc(newValue);

                    if (availMc.Rows.Count == 1)
                    {
                        acMachine1.Value = availMc.Rows[0]["MC_CODE"];
                        acMachine1.FindButtonVisible = true;
                    }
                    else
                    {
                        acMachine1.Value = null;
                        acMachine1.FindButtonVisible = true;
                    }

                    break;

                case "MC_CODE":

                    acEmp1.AVAILMC = newValue;

                    DataTable avilEmp = acEmp.GetAvailEmp(newValue);

                    acEmp1.FindButtonVisible = true;

                    if (avilEmp.Rows.Count == 1)
                    {
                        acEmp1.Value = avilEmp.Rows[0]["EMP_CODE"];
                    }
                    else
                    {
                        acEmp1.Value = null;
                    }

                    break;
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                if (this.DialogMode == emDialogMode.NEW)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    this.Close();
                }
                else
                {
                    DataSet partSet = SaveData();

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "PLN01A_SAVE3", partSet, "RQSTDT", "RSLTDT",
                            QuickSaveClose,
                            QuickException);
                }
                    

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}