using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace PUR
{
    public sealed partial class PUR08A_D0A : BaseMenuDialog
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

        private string _balju_num;
        public PUR08A_D0A(string balju_num)
        {
            InitializeComponent();

            _balju_num = balju_num;

            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
        }

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "QTY":

                    layout.GetEditor("AMT").Value = layout.GetEditor("UNIT_COST").Value.toDecimal() * newValue.toInt();

                    break;

                case "UNIT_COST":

                    layout.GetEditor("AMT").Value = layout.GetEditor("QTY").Value.toInt() * newValue.toDecimal();

                    break;

            }
        }

        public override void DialogInit()
        {
            //¿‘∞Ì¿œ

            acLayoutControl1.GetEditor("BALJU_NUM").Value = _balju_num;

            acLayoutControl1.GetEditor("YPGO_DATE").Value = DateTime.Today;

            acLayoutControl1.GetEditor("QTY").Value = 1;

            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow datarow = acLayoutControl1.CreateParameterRow();
                
                base.OutputData = datarow;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

