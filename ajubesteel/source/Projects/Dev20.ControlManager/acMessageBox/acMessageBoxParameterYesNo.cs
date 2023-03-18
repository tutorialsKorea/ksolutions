﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ControlManager
{
    public sealed partial class acMessageBoxParameterYesNo : DevExpress.XtraEditors.XtraForm
    {


        private object _Parameter = null;

        public object Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }

        public acMessageBoxParameterYesNo(Control parent, string text, string caption, string parameterCaption)
        {
            InitializeComponent();


            this.layoutControlItem1.Text = parameterCaption;



            Size nowSize = layoutControl1.Root.Size;

            simpleLabelItem1.Text = text;

            Size deffSize = new Size();

            deffSize.Width = layoutControl1.Root.Size.Width - nowSize.Width;

            deffSize.Height = layoutControl1.Root.Size.Height - nowSize.Height;

            Size newSize = new Size(this.Size.Width + deffSize.Width, this.Size.Height + deffSize.Height);

            this.Size = newSize;

            this.Text = caption;


        }


        protected override void OnClosed(EventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.No;
            }

            base.OnClosed(e);
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._Parameter = acMemoEdit1.Value;

            this.DialogResult = DialogResult.Yes;
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}