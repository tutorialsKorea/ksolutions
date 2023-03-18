using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace MAT
{
    public sealed partial class MAT02A_D1A : BaseMenuDialog
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
        public DataTable _linkTable = null;

        public MAT02A_D1A(DataTable linkTable)
        {
            InitializeComponent();

            _linkTable = linkTable;
        }


        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
            acGridView1.AddTextEdit("PART_QTY", "총 소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("OUT_QTY", "불출수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("REMAIN_QTY", "남은수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.AddTextEdit("OUT_REQ_QTY", "기 불출요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("STOCK_QTY", "재고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;
            acGridView1.GridControl.DataSource = _linkTable;

            acGridView1.BestFitColumnsThread();

            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acMessageBox.Show(this, "불출요청을 진행하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                DialogResult = DialogResult.No;
                return;
            }

            DialogResult = DialogResult.Yes;

        }
    }
}

