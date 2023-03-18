using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace PLN
{
    public sealed partial class PLN03A_D3A : BaseMenuDialog
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

        public PLN03A_D3A()
        {
            InitializeComponent();

            (acLayoutControl1.GetEditor("WORK_CODE").Editor as acLookupEdit).SetCode("C108");
            
        }

        public override void DialogInit()
        {

            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

       
            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로 만들기

           
            base.DialogNew();


        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                this.OutputData = layoutRow;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        
        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}