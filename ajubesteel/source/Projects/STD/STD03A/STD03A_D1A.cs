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

namespace STD
{
    public sealed partial class STD03A_D1A : BaseMenuDialog
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




        public STD03A_D1A()
        {


            InitializeComponent();

        }





        public override void DialogInit()
        {
            acLayoutControl1.GetEditor("E_WORK_DATE").Value = DateTime.Now.AddDaysEx(-1);

  


            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기


        }

        public override void DialogOpen()
        {
            //열기



        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                this.OutputData = layoutRow;

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                this.Close();


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}