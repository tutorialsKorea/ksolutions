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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

namespace ControlManager
{
    public sealed partial class acMachineControlForm : BaseMenuDialog
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

        private String _mcCode = "";

        public acMachineControlForm(string mcCode)
        {
            InitializeComponent();

            _mcCode = mcCode;

        }








        public override void DialogInit()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = _mcCode;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "MNT01A_SER3", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);

           

            base.DialogInit();


        }

   

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    acLayoutControl1.DataBind(e.result.Tables["RSLTDT"].Rows[0], false);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            acMessageBox.Show(this, ex);

        }

        private void acLayoutControlGroup1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }



    }
}