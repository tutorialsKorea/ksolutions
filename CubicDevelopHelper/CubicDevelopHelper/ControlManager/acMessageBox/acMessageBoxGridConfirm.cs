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
    public sealed partial class acMessageBoxGridConfirm : ControlManager.acForm
    {
        private object _DataSource = null;


        private object _OutputData;

        public object OutData
        {
            get { return _OutputData; }
            set { _OutputData = value; }
        }
        public acMessageBoxGridConfirm(Control parent, string name, string text, string resourceID, bool useReSourceID, string caption, object dataSource)
        {
            InitializeComponent();

            base.ParentControl = parent;

            this.Name = name;

            Size nowSize = layoutControl1.Root.Size;

            if (useReSourceID == true)
            {
                simpleLabelItem1.Text = acInfo.Resource.GetString(text, resourceID);
            }
            else
            {
                simpleLabelItem1.Text = text;
            }


            Size deffSize = new Size();
            
            deffSize.Width = layoutControl1.Root.Size.Width - nowSize.Width;

            deffSize.Height = layoutControl1.Root.Size.Height - nowSize.Height;

            Size newSize = new Size(this.Size.Width + deffSize.Width ,this.Size.Height + deffSize.Height);
            
            this.Size = newSize;

            this.Text = caption;

            this._DataSource = dataSource;
           

        }

        protected override void OnLoad(EventArgs e)
        {
            this.View.GridControl.DataSource = this._DataSource;

            this.View.BestFitColumns();

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //base.OutputData = this.View.GetFocusedDataRow();
            this._OutputData = this.View.GetFocusedDataRow();
            this.Close();
        }
    }
}