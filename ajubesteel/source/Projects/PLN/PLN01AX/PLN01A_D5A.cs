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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PlexityHide.GTP;

namespace PLN
{
    public sealed partial class PLN01A_D5A : BaseMenuDialog
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

        string _part_code = string.Empty;

        public PLN01A_D5A(string part_code)
        {
            InitializeComponent();

            _part_code = part_code;

            acTreeList2.KeyFieldName = "BOM_ID";

            acTreeList2.ParentFieldName = "PARENT_ID";

            acTreeList2.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("BOM_PART_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("PARENT_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("PART_CODE", "품목코드", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("PART_NAME", "품목명", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("MAT_SPEC1", "규격", "42545", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true);

            acTreeList2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", true);

            acTreeList2.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, "S016", true);

            acTreeList2.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.QTY);

            acTreeList2.AddLookUpEdit("STOCK_CODE", "창고코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M005", true);

            acTreeList2.AddLookUpEdit("STOCK_TYPE", "완성재고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M013", true);

            acTreeList2.AddTextEdit("BOM_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);

            acTreeList2.OptionsSelection.MultiSelect = true;


        }

        
        public override void DialogInit()
        {

            base.DialogInit();

            BindData();
        }

        public override void DialogNew()
        {
            //새로 만들기

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기            
           
            base.DialogOpen();
        }

        void BindData()
        {
            try
            {
                acTreeList2.ClearNodes();

                if (_part_code == "") return;

                //BOM조회
                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("BOM_PART_CODE", typeof(String)); //

                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["BOM_PART_CODE"] = _part_code;

                paramTable2.Rows.Add(paramRow2);

                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable2);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PLN08A_SER3", paramSet2, "RQSTDT", "RSLTDT");

                acTreeList2.DataSource = dsResult.Tables["RSLTDT"];

                acTreeList2.ExpandAll();

                acTreeList2.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
  
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기

        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
           
        }
                
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}