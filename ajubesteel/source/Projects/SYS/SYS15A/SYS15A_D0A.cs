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

namespace SYS
{
    public sealed partial class SYS15A_D0A : BaseMenuDialog
    {

   
        public override void BarCodeScanInput(string barcode)
        {


        }


        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        public SYS15A_D0A(DataRow linkData)
        {
            InitializeComponent();

            _LinkData = linkData;
        }

        public override void DialogInit()
        {
            base.DialogInit();
        }

        public override void DialogNew()
        {
            GetFileList();
        }

        public override void DialogOpen()
        {
          
        }

        void GetFileList()
        {
            try
            {
                if (_LinkData != null)
                {
                 
                    this.acAttachFileControl1.LinkKey = _LinkData["DLOG_ID"];
                    this.acAttachFileControl1.ShowKey = new object[] { _LinkData["DLOG_ID"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

    }
}