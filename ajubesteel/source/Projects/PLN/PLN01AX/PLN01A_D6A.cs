using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace PLN
{
    public sealed partial class PLN01A_D6A : BaseMenuDialog
    {

        public override void BarCodeScanInput(string barcode)
        {


        }

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        public PLN01A_D6A(object linkData)
        {

            InitializeComponent();


            LinkData = linkData;
        }



        public override void DialogInit()
        {
            base.DialogInit();
        }

        public override void DialogNew()
        {
        }

        public override void DialogOpen()
        {
            acLayoutControl1.DataBind((DataRow)_LinkData,true);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}