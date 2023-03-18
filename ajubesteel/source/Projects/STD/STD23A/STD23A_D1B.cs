using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD23A_D1B : BaseMenuDialog
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

        private string _HoliReason = null;

        public string HoliReason
        {
            get { return _HoliReason; }
        }

        private DateTime _HoliDateTime = DateTime.MinValue;

        public DateTime HoliDateTime
        {
            get { return _HoliDateTime; }
        }

        public STD23A_D1B(DateTime date)
        {
            InitializeComponent();

            dateEdit1.EditValue = date;
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this._HoliDateTime = (DateTime)dateEdit1.EditValue;
                this._HoliReason = (string)textEdit1.EditValue;


                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
    }
}