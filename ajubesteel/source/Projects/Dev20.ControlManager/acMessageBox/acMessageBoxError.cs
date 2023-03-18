using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BizManager;

namespace ControlManager
{
    internal partial class acMessageBoxError : DevExpress.XtraEditors.XtraForm
    {



        private Control _ParentControl = null;


        public acMessageBoxError(Control parent, Exception ex)
        {

            InitializeComponent();

            this._ParentControl = parent;
            
            simpleLabelItem1.Text = ex.Message;

            string report = null;

            if (!string.IsNullOrEmpty(ex.Message))
            {

                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("Message:\r\n{0}", ex.Message);
            }

            if (ex.Data.Contains("LOC"))
            {
                report += System.Environment.NewLine + System.Environment.NewLine;

                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("LOC:\r\n{0}", ex.Data["LOC"].ToString());
            }

            if (ex.Data.Contains("DATA"))
            {

                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("DATA:\r\n{0}", ex.Data["DATA"].ToString());
            }
            
            if (!string.IsNullOrEmpty(ex.StackTrace))
            {

                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("StackTrace:\r\n{0}", ex.StackTrace);
            }

            Exception innerEx = ex.InnerException;

            while (true)
            {

                if (innerEx == null)
                {
                    break;

                }



                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("Message:\r\n{0}", innerEx.Message);


                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("StackTrace:\r\n{0}", innerEx.StackTrace);

                innerEx = innerEx.InnerException;

            }




            memoEdit1.EditValue = report;



        }

        protected override void OnClosed(EventArgs e)
        {
            this.SetErrorLog();

            base.OnClosed(e);
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //this.SetErrorLog();


            this.DialogResult = DialogResult.OK;



        }

        void SetErrorLog()
        {

            if (acInfo.IsRunTime == true)
            {
                try
                {

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("SYSTEM_VERSION", typeof(String)); //
                    paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
                    paramTable.Columns.Add("ERR_MESSAGE", typeof(String)); //
                    paramTable.Columns.Add("COMMENT", typeof(String)); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["SYSTEM_VERSION"] = acInfo.Version;
                    paramRow["CLASS_NAME"] = this._ParentControl.Name;
                    paramRow["ERR_MESSAGE"] = layoutRow["ERR_MESSAGE"];
                    paramRow["COMMENT"] = layoutRow["COMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_ERROR_LOG", paramSet, "RQSTDT", "");
                }
                catch { }

            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(layoutControlItem1.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                simpleLabelItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                simpleLabelItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }
}