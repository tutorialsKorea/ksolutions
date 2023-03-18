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
    public sealed partial class PUR07A_D0A : BaseMenuDialog
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

        public PUR07A_D0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            switch (info.ColumnName)
            {
                case "DUE_DATE":

                    if (dtReq.DateTime > dtDue.DateTime)
                    {
                        dtDue.DateTime = dtReq.DateTime; 
                    }

                    break;

            }
        }


        public override void DialogInit()
        {
            //脚没老

            acLayoutControl1.GetEditor("REQ_DATE").Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl1.GetEditor("REQ_DATE").isReadyOnly = !this.GetMenuConfig("IS_CHANGE_REQ_DATE").toBoolean();


            //脚没磊 夸备老

            acLayoutControl1.GetEditor("DUE_DATE").Value = acDateEdit.GetNowDateFromServer();

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

