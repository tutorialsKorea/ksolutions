using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;
using ControlManager;
using CodeHelperManager;

namespace PLN
{
    public sealed partial class PLN01A_D2A : BaseMenuDialog
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

        public PLN01A_D2A()
        {
            InitializeComponent();
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

           
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
              if(!acLayoutControl1.ValidCheck()) return;
                
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                this.OutputData = layoutRow;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}