using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace PLN
{
    public sealed partial class PLN08A_D2A : BaseMenuDialog
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

        public PLN08A_D2A()
        {
            InitializeComponent();

            acRadioGroup1.EditValueChanged += acRadioGroup1_EditValueChanged;
        }

        void acRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            acRadioGroupItem item = acRadioGroup1.GetRadioGroupItem(acRadioGroup1.EditValue);

            if (item == null) return;
            if (item.Value.ToString() == "NODE")
            {
                //노드붙여넣기
                DialogResult = DialogResult.Yes;
            }
            else
            {
                //자식붙여넣기
                OutputData = false;
                DialogResult = DialogResult.No;
            }
        }

    

        public override void DialogInit()
        {
            base.DialogInit();
        }

        public override void DialogNew()
        {

            base.DialogNew();
        }

        public override void DialogOpen()
        {

            base.DialogOpen();
        }

    
        
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

    }
}

