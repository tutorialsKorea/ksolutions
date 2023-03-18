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

namespace POP
{
    public sealed partial class POP05B_D1A : BaseMenuDialog
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

        public POP05B_D1A(DataRow linkData)
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
                 
                    this.acAttachFileControl1.LinkKey = "INS" + _LinkData["WO_NO"].ToString();
                    this.acAttachFileControl1.ShowKey = new object[] { "INS" + _LinkData["WO_NO"].ToString() };

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