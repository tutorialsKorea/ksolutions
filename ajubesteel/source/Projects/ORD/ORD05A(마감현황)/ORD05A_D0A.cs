using System;
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
    public sealed partial class ORD05A_D0A : BaseMenuDialog
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


        private string _type = "TAX";


        private int _prod_qty = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">TRADE:거래명세표, TAX:세금계산서</param>
        public ORD05A_D0A(string type,int prod_qty )
        {
            InitializeComponent();

            this._type = type;

            this._prod_qty = prod_qty;

            this.Text = "세금계산서 발행일 등록";

            if (type == "TRADE")
            {
                this.Text = "거래명세표 발행일 등록";
            }
            else if (type == "TAX")
            {
                this.Text = "세금계산서 발행일 등록";
                acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (type == "COL")
            {
                this.Text = "수금일 등록";
                acLayoutControlItem1.Text = "수금일자";
            }
        }



        public override void DialogInit()
        {


            acLayoutControl1.GetEditor("BILL_DATE").Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl1.GetEditor("BILL_EMP").Value = acInfo.UserID;

            acLayoutControl1.GetEditor("BILL_QTY").Value = _prod_qty;

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