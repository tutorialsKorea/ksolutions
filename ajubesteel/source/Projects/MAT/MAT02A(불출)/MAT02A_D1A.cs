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
            acGridView1.AddTextEdit("PART_CODE", "ǰ���ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "ǰ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_LTYPE", "��з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "�ߺз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView1.AddLookUpEdit("MAT_STYPE", "�Һз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
            acGridView1.AddTextEdit("PART_QTY", "�� �ҿ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("OUT_QTY", "�������", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("REMAIN_QTY", "��������", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.AddTextEdit("OUT_REQ_QTY", "�� �����û ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("STOCK_QTY", "������", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;
            acGridView1.GridControl.DataSource = _linkTable;

            acGridView1.BestFitColumnsThread();

            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acMessageBox.Show(this, "�����û�� �����Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                DialogResult = DialogResult.No;
                return;
            }

            DialogResult = DialogResult.Yes;

        }
    }
}

