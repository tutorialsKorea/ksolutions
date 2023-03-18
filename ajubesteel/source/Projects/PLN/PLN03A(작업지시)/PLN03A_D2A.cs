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
    public sealed partial class PLN03A_D2A : BaseMenuDialog
    {

        
        public override void BarCodeScanInput(string barcode)
        {


        }

        object _linkData;

        public PLN03A_D2A(object linkData)
        {
            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddDateEdit("MDFY_DATE", "수정일시", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("EMP_NAME", "수정인", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            

            _linkData = linkData;

        }

        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.GridControl.DataSource = _linkData;
       
            base.DialogInit();

        }

        

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}