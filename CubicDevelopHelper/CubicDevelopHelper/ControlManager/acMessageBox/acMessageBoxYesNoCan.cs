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
    internal partial class acMessageBoxYesNoCan : DevExpress.XtraEditors.XtraForm
    {
        public acMessageBoxYesNoCan(string text , string caption)
        {
            InitializeComponent();

            Size nowSize = layoutControl1.Root.Size;

            simpleLabelItem1.Text = text;

            Size deffSize = new Size();

            deffSize.Width = layoutControl1.Root.Size.Width - nowSize.Width;

            deffSize.Height = layoutControl1.Root.Size.Height - nowSize.Height;

            Size newSize = new Size(this.Size.Width + deffSize.Width ,this.Size.Height + deffSize.Height);
            
            this.Size = newSize;

            this.Text = caption;

           

        }



        protected override void OnClosed(EventArgs e)
        {

            base.OnClosed(e);
        }

 

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //예

            this.DialogResult = DialogResult.Yes;
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //아니오
            
            this.DialogResult = DialogResult.No;
            
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }
    }
}