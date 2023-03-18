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
    public sealed partial class PLN01A_D4A : BaseMenuDialog
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

        string _rev_part = string.Empty;

        public PLN01A_D4A(string rev_part)
        {
            InitializeComponent();

            _rev_part = rev_part;
            
            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "개정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddMemoEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddTextEdit("MDFY_EMP", "개정인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddMemoEdit("REV_COMMENT", "개정사유", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, false, true, false);
            acGridView1.AddTextEdit("colATTACH", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("LINK_KEY", "도면", "40144", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.MouseUp += acGridView1_MouseUp;
        }

        void acGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);
                if (hitInfo.Column == null) return;

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (hitInfo.Column.FieldName == "colATTACH")
                {

                    if (focusRow["LINK_KEY"].ToString() != "")
                    {
                        AttachFileList frm = new AttachFileList(focusRow, "PART_CODE");
                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                        frm.ParentControl = this;

                        base.ChildFormAdd("NEW", frm);

                        frm.ShowDialog();
                    }

                }
                else if (hitInfo.Column.FieldName == "REV_PART")
                {
                    string rev_part = focusRow["REV_PART_CODE"].ToString();

                    if (rev_part == "") return;

                    PLN01A_D4A frm = new PLN01A_D4A(rev_part);

                    frm.ParentControl = this;

                    base.ChildFormAdd(rev_part, frm);

                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


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
            //선택한 품목의 개정이력 보기
            DataSet paramSet = new DataSet();
            
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("REV_PART_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["REV_PART_CODE"] = _rev_part;
            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN01A_SER5", paramSet, "RQSTDT", "RSLTDT");

            //rsltSet.Tables["RSLTDT"].Select("", "ORDER BY MDFY_DATE DESC");

            acGridView1.GridControl.DataSource = rsltSet.Tables["RSLTDT"];
            acGridView1.Columns["MDFY_DATE"].SortIndex = 0;
            acGridView1.Columns["MDFY_DATE"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            acGridView1.BestFitColumns();
  
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