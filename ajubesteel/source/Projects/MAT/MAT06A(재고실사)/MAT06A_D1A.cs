using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace MAT
{
    public sealed partial class MAT06A_D1A : BaseMenuDialog
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

        private object _linkData = null;
        public object LinkData { get => _linkData; set => _linkData = value; }

        public MAT06A_D1A(object linkData)
        {
            Init();
            this.LinkData = linkData;
        }

        public MAT06A_D1A()
        {
            Init();
        }

        void Init()
        {
            InitializeComponent();

            (acLayoutControl1.GetEditor("STOCK_LOC").Editor as acLookupEdit).SetCode("M005");

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                acLayoutControl layout = sender as acLayoutControl;

                switch (info.ColumnName)
                {
                    case "PART_QTY":

                        layout.GetEditor("YPGO_AMT").Value = layout.GetEditor("YPGO_COST").Value.toDecimal() * newValue.toDecimal();

                        break;

                    case "YPGO_COST":

                        layout.GetEditor("YPGO_AMT").Value = layout.GetEditor("PART_QTY").Value.toDecimal() * newValue.toDecimal();

                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void DialogInit()
        {

            if (LinkData is DataRow focusRow)
            {
                acLayoutControl1.GetEditor("PART_CODE").Value = focusRow["PART_CODE"];
            }
            
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

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

