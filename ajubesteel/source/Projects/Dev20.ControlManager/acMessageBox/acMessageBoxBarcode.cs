using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace ControlManager
{
    internal partial class acMessageBoxBarcode : DevExpress.XtraEditors.XtraForm
    {



        private Control _BarCodeInputControl = null;

        private string _BarCode = null;

        private System.Threading.Timer _TimeChecker = null;



        public acMessageBoxBarcode(Control barCodeInputControl, string barCode)
        {

            InitializeComponent();



            this._BarCodeInputControl = barCodeInputControl;

            this._BarCode = barCode;




            this.acTextEdit1.EditValue = this._BarCode;

            TimerCallback tc = new TimerCallback(TimeCheckerCallBack);

            this._TimeChecker = new System.Threading.Timer(tc, null, 0, 10);
        }



        void TimeCheckerCallBack(object stateInfo)
        {

            if (this.InvokeRequired == true && this.Disposing == false)
            {
                this.BeginInvoke(new MethodInvoker(BarCodeClose));

                this._TimeChecker.Dispose();

            }

        }



        void BarCodeClose()
        {
            this.Close();

            IBase b = this._BarCodeInputControl as IBase;


            b.BarCodeScanInput(this._BarCode);


        }
    }
}