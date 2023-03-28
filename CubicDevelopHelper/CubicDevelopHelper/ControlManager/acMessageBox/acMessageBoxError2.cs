using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ControlManager
{
    internal partial class acMessageBoxError2 : DevExpress.XtraEditors.XtraForm
    {
        

        private Control _ParentControl = null;


        public acMessageBoxError2(Control parent, Exception ex)
        {

            InitializeComponent();

            this._ParentControl = parent;


            string report = null;


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

            if (!string.IsNullOrEmpty(ex.Message))
            {

                if (!string.IsNullOrEmpty(report))
                {
                    report += System.Environment.NewLine;
                }

                report += string.Format("Message:\r\n{0}", ex.Message);
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


            base.OnClosed(e);
        }




    }
}