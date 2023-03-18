﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;

namespace ORD
{
    public sealed partial class ORD05A_D2A : BaseMenuDialog
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

        public ORD05A_D2A()
        {
            InitializeComponent();
        }



        public override void DialogInit()
        {
            base.DialogInit();

        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                
                this.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}