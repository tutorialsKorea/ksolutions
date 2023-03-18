using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using BizManager;

namespace MAT
{
    public sealed partial class MAT03A_D1A : BaseMenuDialog
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

        private DataTable _linkData = null;

        public MAT03A_D1A(DataTable linkData)
        {
            try
            {
                InitializeComponent();

                _linkData = linkData;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DialogInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView1.AddTextEdit("PLT_CODE", "�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "���ΰ�����ȣ", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SERIAL_NO", "Serial No", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "ǰ���ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "ǰ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "�԰�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PART_PRODTYPE", "����", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");
            acGridView1.AddTextEdit("DRAW_NO", "�����ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PT_ID" };

            base.DialogInit();
        }

        public override void DialogInitComplete()
        {
            acGridView1.GridControl.DataSource = _linkData;

            base.DialogInitComplete();
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

