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
    public sealed partial class PLN08A_D0A : BaseMenuDialog
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
        private DataTable dtDelPart = null;

        private DataRow _masterRow = null;

        private TreeListNode _linkTree = null;

        private acTreeList _linkTreeList = null;

        private bool _isChild = false;
        private bool _isTurning = false;
        private string _strBomPartCode = "";

        public PLN08A_D0A(DataRow masterRow, TreeListNode linkTree, acTreeList linkTreeList, bool isChild, bool isTurning)
        {
            InitializeComponent();

            _masterRow = masterRow;

            _linkTree = linkTree;

            _linkTreeList = linkTreeList;

            _isChild = isChild;
            _isTurning = isTurning;

            if (!_isChild)
            {
                //노드
                if (_masterRow != null)
                {
                    acLayoutControl1.GetEditor("PARENT_PART_CODE").Value = _masterRow["PART_CODE"].ToString();
                    acLayoutControl1.GetEditor("PARENT_PART_NAME").Value = _masterRow["PART_NAME"].ToString();
                    _strBomPartCode = _masterRow["PART_CODE"].ToString();
                }
                else
                {
                    acLayoutControl1.GetEditor("PARENT_PART_CODE").Value = _linkTree["PARENT_PART_CODE"].ToString();
                    acLayoutControl1.GetEditor("PARENT_PART_NAME").Value = _linkTree["PARENT_PART_NAME"].ToString();
                    _strBomPartCode = _linkTree["BOM_PART_CODE"].ToString();
                }
                
            }
            else
            {
                //자식노드
                acLayoutControl1.GetEditor("PARENT_PART_CODE").Value = _linkTree["PART_CODE"].ToString();
                acLayoutControl1.GetEditor("PARENT_PART_NAME").Value = _linkTree["PART_NAME"].ToString();
                _strBomPartCode = _linkTree["BOM_PART_CODE"].ToString();
            }


            dtDelPart = new DataTable("RQSTDT_DEL");

            dtDelPart.Columns.Add("PLT_CODE", typeof(String));
            dtDelPart.Columns.Add("BOM_ID", typeof(String));
            dtDelPart.Columns.Add("BOM_PART_CODE", typeof(String));
            dtDelPart.Columns.Add("PARENT_ID", typeof(String));
            
            acGridView1.AddHidden("BOM_ID", typeof(String));

            acGridView1.AddTextEdit("BOM_PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC1", "제품사양", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView1.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddLookUpEdit("STOCK_CODE", "창고코드", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M005");

            acGridView1.AddLookUpEdit("STOCK_TYPE", "완성재고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M013");

            acGridView1.AddTextEdit("BOM_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.KeyColumn = new string[] { "PART_CODE" };


            acGridView2.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAT_SPEC1", "제품사양", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAT_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView2.AddTextEdit("BOM_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.AddTextEdit("BOM_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);

            acGridView2.KeyColumn = new string[] { "PART_CODE" };

            #region 이벤트 설정

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView2.MouseDown += acGridView2_MouseDown;

            acGridView1.OnMapingRowChanged += acGridView1_OnMapingRowChanged;
            
            #endregion
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            try
            {
                if (type == acGridView.emMappingRowChangedType.ADD ||
                type == acGridView.emMappingRowChangedType.MODIFY)
                {
                    row["BOM_SEQ"] = acGridView1.FocusedRowHandle + 1;
                }
            }
            catch (Exception ex)
            { }
            
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (acGridView1.RowCount != 0)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
            
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (acGridView2.RowCount != 0)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    acBarButtonItem3_ItemClick(null, null);
                }
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }


        public override void DialogInit()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //
            paramTable.Columns.Add("BOM_ID", typeof(String)); //
            paramTable.Columns.Add("IS_TURNING", typeof(Int32)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BOM_PART_CODE"] = _strBomPartCode;
            paramRow["IS_TURNING"] = _isTurning;

            if (!_isChild)
            {
                if (_masterRow == null)
                {
                    paramRow["BOM_ID"] = _linkTree["PARENT_ID"];
                }
            }
            else
            {
                paramRow["BOM_ID"] = _linkTree["BOM_ID"];
            }
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "PLN08A_SER2", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            //acGridView1.BestFitColumns();

            PartSearch();

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_ID", typeof(String)); //

                paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //
                paramTable.Columns.Add("PARENT_ID", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_QTY", typeof(int)); //
                paramTable.Columns.Add("STOCK_CODE", typeof(String)); //
                paramTable.Columns.Add("STOCK_TYPE", typeof(String)); //
                paramTable.Columns.Add("BOM_SEQ", typeof(int)); //

                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataView ChildPart = acGridView1.GetDataSourceView("");

                for (int i = 0; i < ChildPart.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BOM_ID"] = ChildPart[i]["BOM_ID"];

                    paramRow["BOM_PART_CODE"] = _strBomPartCode;

                    if (!_isChild)
                    {
                        if (_masterRow == null)
                        {
                            paramRow["PARENT_ID"] = _linkTree["PARENT_ID"];
                        }
                    }
                    else
                    {
                        paramRow["PARENT_ID"] = _linkTree["BOM_ID"];
                    }

                    paramRow["PART_CODE"] = ChildPart[i]["PART_CODE"];
                    paramRow["BOM_QTY"] = ChildPart[i]["BOM_QTY"];    //DBNull.Value;
                    paramRow["STOCK_CODE"] = ChildPart[i]["STOCK_CODE"];
                    paramRow["STOCK_TYPE"] = ChildPart[i]["STOCK_TYPE"];
                    paramRow["BOM_SEQ"] = ChildPart[i]["BOM_SEQ"];

                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                paramSet.Tables.Add(dtDelPart.Copy());


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN08A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _linkTreeList.DataSource = e.result.Tables["RSLTDT"];

                _linkTreeList.ExpandAll();

                _linkTreeList.BestFitColumns();

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            PartSearch();
        }
        
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            DataRow focus = acGridView1.GetFocusedDataRow();

            DataRow paramRow = dtDelPart.NewRow();
            if (focus["BOM_ID"].ToString() != "")
            {
                paramRow["PLT_CODE"] = focus["PLT_CODE"];
                paramRow["BOM_ID"] = focus["BOM_ID"];
                paramRow["BOM_PART_CODE"] = focus["BOM_PART_CODE"];

                dtDelPart.Rows.Add(paramRow);
            }

            acGridView1.DeleteMappingRow(focus);

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_isTurning && acGridView1.RowCount > 0)
            {
                acMessageBox.Show(this, "선삭부품은 1개 이상 추가 하실수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }
            
            
            //추가
            DataRow focusRow = acGridView2.GetFocusedDataRow();

            DataView availPartView = acGridView1.GetDataSourceView("PART_CODE = '" + focusRow["PART_CODE"].ToString() + "'");

            //목록에 없으면 추가
            if (availPartView.Count == 0)
            {
                
                acGridView1.UpdateMapingRow(focusRow, true);
                //acGridView1.GetAddModifyRows()

            }
        }

        void PartSearch()
        {
            DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

            DataTable paramTable2 = new DataTable("RQSTDT");
            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable2.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable2.Columns.Add("IS_TURNING", typeof(Int32)); //

            DataRow paramRow2 = paramTable2.NewRow();
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow2["PART_LIKE"] = layoutRow2["PART_LIKE"];
            paramRow2["IS_TURNING"] = _isTurning;
            paramTable2.Rows.Add(paramRow2);

            DataSet paramSet2 = new DataSet();
            paramSet2.Tables.Add(paramTable2);

            DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "STD02A_SER", paramSet2, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet2.Tables["RSLTDT"];

            //acGridView2.BestFitColumns();
        }

        private void acTextEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PartSearch();
            }
        }
    }
}

