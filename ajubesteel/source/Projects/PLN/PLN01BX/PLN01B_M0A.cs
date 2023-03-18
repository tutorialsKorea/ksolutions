using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;

using CodeHelperManager;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using GemBox.Spreadsheet;
using System.IO;
using System.Linq;

namespace PLN
{
    public sealed partial class PLN01B_M0A : BaseMenu
    {
        GridHitInfo _downHitInfo = null;
        DataRow _masterRow = null;
        String _selectProcCode = null;
        DataTable _procList = null;

        enum emState
        {
            INIT,
            PART_SEARCH,
            PROC_SELECT
        }
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

        private bool _hasProc = false;

        public PLN01B_M0A()
        {
            InitializeComponent();

            chkShowAssy.CheckedChanged += ChkShowAssy_CheckedChanged;

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            this.acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.acGridView1_CustomDrawCell);

            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView1.CustomDrawColumnHeader += AcGridView1_CustomDrawColumnHeader;
            acGridView1.CustomRowCellEdit += AcGridView1_CustomRowCellEdit;

            acGridView2.CellMerge += AcGridView2_CellMerge;
            //acGridView2.CellValueChanged += AcGridView2_CellValueChanged;

            //acGridView3.FocusedRowChanged += acGridView3_FocusedRowChanged;
            acGridView3.MouseDown += acGridView3_MouseDown;
            acGridView3.MouseMove += AcGridView3_MouseMove;

            acGridView5.ShownEditor += AcGridView5_ShownEditor;
            acGridView5.HiddenEditor += AcGridView5_HiddenEditor;
            acGridView5.CellValueChanged += AcGridView5_CellValueChanged;

            acGridView5.ShowGridMenuEx += AcGridView5_ShowGridMenuEx;
            acGridView7.ShowGridMenuEx += AcGridView7_ShowGridMenuEx;
            acGridView4.ShowGridMenuEx += AcGridView4_ShowGridMenuEx;

            acGridView7.InitNewRow += AcGridView7_InitNewRow;

            acGridControl3.DragOver += AcGridControl3_DragOver;
            acGridControl3.DragLeave += AcGridControl3_DragLeave;
            acGridControl3.GiveFeedback += AcGridControl3_GiveFeedback;

            acTreeList2.DragOver += AcTreeList2_DragOver;
            acTreeList2.DragDrop += AcTreeList2_DragDrop;
            acTreeList2.DragLeave += AcTreeList2_DragLeave;
            //acTreeList2.DragEnter += AcTreeList2_DragEnter;
            acTreeList2.CellValueChanged += AcTreeList2_CellValueChanged;
            acTreeList2.CustomDrawNodeCell += AcTreeList2_CustomDrawNodeCell;

            acTabPage4.VisibleChanged += AcTabPage4_VisibleChanged;
        }

        private void AcGridView5_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }
        private void AcGridView7_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        private void AcGridView4_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDel3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
            else if(e.HitInfo.HitTest == GridHitTest.EmptyRow)
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDel3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            switch(e.RowHandle)
            {
                case 0:
                    {
                        RepositoryItemCheckEdit checkItemEdit = new RepositoryItemCheckEdit();
                        checkItemEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                        checkItemEdit.ValueChecked = "1";
                        checkItemEdit.ValueUnchecked = "0";

                        e.RepositoryItem = checkItemEdit;
                    }
                    break;
                case 1:
                    {
                        e.RepositoryItem = new RepositoryItemTextEdit();
                    }
                    break;
            }
        }

        private void ChkShowAssy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_procList != null)
                {
                    foreach (DataRow row in _procList.Rows)
                    {
                        if (acTreeList2.Columns.ColumnByFieldName(row["PROC_CODE"].ToString()) is acTreeListColumn tlc)
                        {
                            if (row["IS_ASSY"].toInt() == 1)
                            {
                                tlc.Visible = true;
                            }
                            else
                            {
                                tlc.Visible = !chkShowAssy.Checked;
                            }

                            if (tlc.Visible)
                            {
                                tlc.VisibleIndex = tlc.AbsoluteIndex;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void AcTreeList2_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.CellValue == null
                || (e.Column.ColumnEdit != null 
                   && e.Column.ColumnEdit.GetType().Name.Equals("RepositoryItemCheckEdit") == false)) return;
            if (e.CellValue.ToString() == "1")
            {
                e.Appearance.BackColor = Color.YellowGreen;
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }
        private void AcGridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.isNull()) return;

                if(_selectProcCode.isNullOrEmpty() == false)
                {
                    if(e.Column.FieldName.Equals(_selectProcCode))
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 11, FontStyle.Bold | FontStyle.Italic);
                    }
                    else
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, 9, FontStyle.Regular);
                    }
                }
            }
            catch
            {

            }
        }

        private void AcGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if(e.Column.FieldName.Equals("IMPORTANCE")
            //        && sender is acGridView view)
            //    {
            //        if (view.GetDataRow(e.RowHandle) is DataRow focusRow)
            //        {
            //            DataView prgView = view.GetDataSourceView("PRG_CODE = '" + focusRow["PRG_CODE"] + "'");

            //            for(int i=0;i<prgView.Count;i++)
            //            {
            //                prgView[i]["IMPORTANCE"] = e.Value;
            //            }
            //        }
            //    }
            //}
            //catch( Exception ex)
            //{

            //}
        }

        private void AcGridView2_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (sender is acGridView view)//Name 컬럼만 Merge
                {
                    switch (e.Column.FieldName)
                    {
                        case "PRG_NAME":
                        case "IMPORTANCE":
                            var dr1 = view.GetDataRow(e.RowHandle1); //위에 행 정보
                            var dr2 = view.GetDataRow(e.RowHandle2); //아래 행 정보

                            e.Merge = dr1["PRG_CODE"].ToString().Equals(dr2["PRG_CODE"].ToString());
                            break;
                    }
                }
                else
                    e.Merge = false;

                e.Handled = true;
            }
            catch( Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView7_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if(sender is acGridView view)
                {
                    DataRow row = view.GetDataRow(e.RowHandle);

                    row["PROC_SEQ"] = view.RowCount+1;
                }
            }
            catch( Exception ex)
            {
            }
        }

        private void AcGridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                switch (e.Column.FieldName)
                {
                    case "WORK_CONT_CODE":
                        {
                            if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit edit)
                            {
                                DataTable table = edit.Properties.DataSource as DataTable;
                                //DataView clone = new DataView(table);

                                if(table.AsEnumerable().Where(w=>w["CD_CODE"].ToString().Equals(e.Value)).FirstOrDefault()
                                    is DataRow row)
                                {
                                    acGridView5.SetRowCellValue(e.RowHandle, "WORK_GUBUN_CODE", row["CD_PARENT"]);
                                }
                            }
                        }
                        break;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private DataView clone = null;

        private void AcGridView5_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "WORK_CONT_CODE"
                    && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
                {
                    DevExpress.XtraEditors.LookUpEdit edit;
                    edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;

                    DataTable table = edit.Properties.DataSource as DataTable;

                    clone = new DataView(table);

                    DataRow row = view.GetDataRow(view.FocusedRowHandle);

                    if (row != null && view.FocusedColumn.FieldName == "WORK_CONT_CODE")
                    {
                        string cdParent = row["WORK_GUBUN_CODE"].toStringEmpty();
                        clone.RowFilter = "CD_PARENT = " + "'" + cdParent + "'";
                    }

                    edit.Properties.DataSource = clone;
                }
            }catch(Exception ex)
            {

            }

        }

        private void AcGridView5_HiddenEditor(object sender, EventArgs e)
        {
            if (clone != null)
            {
                clone.Dispose();
                clone = null;
            }
        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is acGridView gridView)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    GridHitInfo hitInfo = gridView.CalcHitInfo(e.Location);

                    if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                    {
                        if (gridView.GetRowCellValue(0, hitInfo.Column) is string value
                            && value.Equals("1"))
                        {
                            SetControlState(emState.PROC_SELECT);

                            lblSelectProc.Text = hitInfo.Column.Caption.Replace("\n","").Trim();
                            _selectProcCode = hitInfo.Column.FieldName;

                            DataSet paramSet = new DataSet();

                            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("PART_CODE", typeof(String));
                            paramTable.Columns.Add("PROC_CODE", typeof(String));

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_CODE"] = _masterRow["PART_CODE"];
                            paramRow["PROC_CODE"] = hitInfo.Column.FieldName;
                            paramTable.Rows.Add(paramRow);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN01A_SER9", paramSet, "RQSTDT", "RSLTDT_WORK,RSLTDT_PRE,RSLTDT_CONT",
                            QuickSearch3,
                            QuickException);
                        }
                    }
                }
            }
        }

        void QuickSearch3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataSet result = e.result;

                acGridView5.GridControl.DataSource = result.Tables["RSLTDT_WORK"];
                acGridView6.GridControl.DataSource = result.Tables["RSLTDT_PRE"];
                acGridView7.GridControl.DataSource = result.Tables["RSLTDT_CONT"];
                acGridView4.GridControl.DataSource = result.Tables["RSLTDT_ACT_TOOL"];

                foreach (DataRow row in result.Tables["RSLTDT_PROC_FILE"].Rows)
                {
                    acLayoutControl4.DataBind(row, false);

                    if (row["PROC_FILE_CONTENT"] is byte[] bytes)
                    {
                        Stream stream = new MemoryStream(bytes);
                        pdfViewer1.LoadDocument(stream);

                        break;
                    }
                }

                acSplitContainerControl3.Panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void AcTreeList2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                acTreeList2.EndEditor();

                switch (e.Column.FieldName)
                {
                    case "BOM_ID":
                    case "BOM_PART_CODE":
                    case "PARENT_ID":
                    case "PARENT_PART_CODE":
                    case "PARENT_PART_NAME":
                    case "PART_CODE":
                    case "PART_NAME":
                        break;

                    case "MAT_SPEC1":
                    case "DRAW_NO":
                    case "MAT_UNIT":
                    case "MAT_LTYPE":
                    case "MAT_TYPE":
                        {
                            DataSet paramSet = new DataSet();

                            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("PART_CODE", typeof(String));
                            paramTable.Columns.Add(e.Column.FieldName, e.Column.GetType());

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_CODE"] = e.Node["PART_CODE"];
                            paramRow[e.Column.FieldName] = e.Value;
                            paramTable.Rows.Add(paramRow);

                            BizRun.QBizRun.ExecuteService(this, "PLN01A_SAVE6", paramSet, "RQSTDT", "RSLTDT");
                        }
                        break;

                    case "BOM_QTY":
                    case "STOCK_CODE":
                    case "STOCK_TYPE":
                    case "BOM_SEQ":
                        {
                            DataSet paramSet = new DataSet();

                            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("BOM_ID", typeof(String));
                            paramTable.Columns.Add(e.Column.FieldName, e.Column.ColumnType);

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["BOM_ID"] = e.Node["BOM_ID"];
                            paramRow[e.Column.FieldName] = e.Value;
                            paramTable.Rows.Add(paramRow);

                            BizRun.QBizRun.ExecuteService(this, "PLN01A_SAVE7", paramSet, "RQSTDT", "RSLTDT");
                        }
                        break;
                    default:
                        {
                            DataSet paramSet = new DataSet();

                            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("PART_CODE", typeof(String));
                            paramTable.Columns.Add("PROC_CODE", typeof(String));
                            paramTable.Columns.Add("IS_SAVE", typeof(Int32));

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_CODE"] = e.Node["PART_CODE"];
                            paramRow["PROC_CODE"] = e.Column.FieldName;
                            paramRow["IS_SAVE"] = e.Value.toInt();
                            paramTable.Rows.Add(paramRow);

                            BizRun.QBizRun.ExecuteService(this, "PLN01A_SAVE8", paramSet, "RQSTDT", "RSLTDT");
                        }
                        break;
                }

            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcTabPage4_VisibleChanged(object sender, EventArgs e)
        {
            acLabelControl2.Visible = acTabPage4.PageVisible;
        }

        #region Drag Drop

        private void AcGridView3_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && _downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 2,
                    _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    if (view != null) view.GridControl.DoDragDrop(_downHitInfo, DragDropEffects.All);
                    _downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void AcGridControl3_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                if (sender is GridControl)
                {
                    acGridControl grid = sender as acGridControl;
                    if (grid.MainView is GridView)
                    {
                        acGridView view = grid.MainView as acGridView;
                        GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                        if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        {
                            e.Effect = DragDropEffects.Move;
                            this.Cursor = acGraphics.CreateCursor(view.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                        }
                        else
                            e.Effect = DragDropEffects.None;

                    }
                }
            }
        }

        private void AcTreeList2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                if (_downHitInfo == null)
                    return;

                if (sender is acTreeList)
                {
                    GridControl grid = _downHitInfo.View.GridControl;
                    if (grid.MainView is GridView)
                    {
                        acGridView view = grid.MainView as acGridView;
                        GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                        if (hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        {
                            e.Effect = DragDropEffects.Move;
                            this.Cursor = acGraphics.CreateCursor(view.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                        }
                        else
                            e.Effect = DragDropEffects.None;

                    }
                }
            }
        }

        private void AcGridControl3_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void AcGridControl3_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }


        private void AcTreeList2_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void AcTreeList2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void AcTreeList2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;

                acTreeList treeList = sender as acTreeList;

                if (e.Data.GetDataPresent(typeof(GridHitInfo)))
                {
                    DXDragEventArgs args = acTreeList2.GetDXDragEventArgs(e);
                    DragInsertPosition position = args.DragInsertPosition;

                    if (e.Data.GetData(typeof(GridHitInfo)) is GridHitInfo ghi)
                    {
                        GridHitInfo gridHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;

                        if (gridHitInfo == null)
                        {
                            acMessageBox.Show(this, "입력 대상 부품의 정보를 읽어오지 못하였습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            return;
                        }

                        TreeListNode node = args.TargetNode;

                        DataRow inputDataRow = gridHitInfo.View.GetDataRow(gridHitInfo.RowHandle);
                        if (node == null)
                        {
                            //루트 노드에 붙이기
                            //SaveBom(null, gridHitInfo.View.GetDataRow(gridHitInfo.RowHandle));
                            if(acTreeList2.GetDataRecordByNode(acTreeList2.Nodes.FirstNode) is DataRowView root)
                            {
                                SaveBom(root.Row, inputDataRow);
                            }
                            else
                            {
                                acMessageBox.Show(this, "최상위 행의 정보를 읽어오지 못하였습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            }
                        }
                        else
                        {
                            DataRowView dView = acTreeList2.GetDataRecordByNode(node) as DataRowView;


                            if (node.Level <= 1 && inputDataRow["IS_TURNING"].toInt() == 1 && !node["MAT_TYPE"].toStringEmpty().Equals("단품"))
                            {
                                acMessageBox.Show(this, "선삭 부품은 현재 위치에 등록 하실수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                return;
                            }
                            //else if(node.Level > 0 && inputDataRow["IS_TURNING"].toInt() == 0)
                            else if (node.Level == 1)
                            {
                                if (inputDataRow["IS_TURNING"].toInt() == 1)
                                {
                                    dView = acTreeList2.GetDataRecordByNode(node) as DataRowView;
                                }
                                else
                                {
                                    dView = acTreeList2.GetDataRecordByNode(acTreeList2.Nodes.FirstNode) as DataRowView;
                                }
                            }
                            else if(node.Level == 2)
                            {
                                if (inputDataRow["IS_TURNING"].toInt() == 1)
                                {
                                    dView = acTreeList2.GetDataRecordByNode(node.ParentNode) as DataRowView;
                                }
                                else
                                {
                                    acMessageBox.Show(this, "선삭 부품이 아니면 현재 위치에 등록하실 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                    return;
                                }
                            }
                            
                            if (dView != null)
                            {
                                SaveBom(dView.Row, inputDataRow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page.Tag.ToString() == "ATTACH_LIST")
                {
                    DataRow focusRow = _masterRow;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PART_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, "PLN01A_SAVE5", paramSet, "RQSTDT", "RSLTDT");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        void acGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    GridHitInfo hitInfo = acGridView3.CalcHitInfo(e.Location);

            //    if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
            //    {
            //        DataRow dr = acGridView3.GetFocusedDataRow();
            //        PLN01A_D5A frm = new PLN01A_D5A(dr["PART_CODE"].ToString());
            //        frm.ParentControl = this;
            //        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
            //        base.ChildFormAdd("NEW_CD", frm);
            //        frm.Show(this);
            //    }
            //}
            //else 
            if (e.Button == MouseButtons.Left)
            {
                GridView view = sender as GridView;
                _downHitInfo = null;

                if (view != null)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                    if (Control.ModifierKeys != Keys.None)
                        return;
                    if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        _downHitInfo = hitInfo;
                }
            }
        }

       
        public override void MenuInit()
        {
            try
            {
                //acGridView2.GridType = acGridView.emGridType.COMMON_CONTROL;
                acGridView2.OptionsView.AllowCellMerge = true;

                acGridView2.AddTextEdit("PRG_CODE", "공정 그룹 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PRG_NAME", "공정 그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView2.AddCheckEdit("SEL", "선택", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("PROC_CODE", "공정 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROC_NAME", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView2.AddMemoEdit("PROC_CONTENTS", "조립 내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView2.AddMemoEdit("PROC_REMARK", "조립 주의사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView2.AddMemoEdit("INS_METHOD", "검사 방법", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView2.AddTextEdit("ASSY_TIME", "조립 시간", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NUMERIC);
                acGridView2.AddTextEdit("IMPORTANCE", "비중", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NUMERIC);

                acGridView2.Columns["PRG_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                acGridView2.Columns["IMPORTANCE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.AddButtonEdit("SEARCH", "조회", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("REV_COMMENT", "개정 사유", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_TYPE", "구분", "40229", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                //acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");
                acGridView3.AddTextEdit("MAIN_VND_NAME", "고객", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView3.AddTextEdit("MAT_SPEC1", "제품규격", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MAT_SPEC", "소재규격", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MAT_QLTY", "재질", "7QEYM43V", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MQLTY_NAME", "재질", "7QEYM43V", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_CNT", "개체 수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                if (acGridView3.Columns.ColumnByFieldName("SEARCH").ColumnEdit is RepositoryItemButtonEdit rib)
                {
                    rib.ButtonClick += Rib_ButtonClick;
                    rib.Buttons[0].Image = Resource.system_search_2x;
                    rib.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                }

                acGridView3.OptionsView.ShowGroupPanel = true;
                acGridView3.Columns["MAT_TYPE"].GroupIndex = 0;
                acGridView3.Columns["MAT_TYPE"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

                acGridView3.KeyColumn = new string[] { "PART_CODE" };

                acGridView3.OptionsPrint.ExpandAllGroups = true;

                #region 가공 상태

                acGridView5.GridType = acGridView.emGridType.AUTO_COL;

                acGridView5.AddTextEdit("WORK_CODE", "코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, true, acGridView.emTextEditMask.NONE);
                acGridView5.AddLookUpEdit("WORK_GUBUN_CODE", "구분", "40239", false, DevExpress.Utils.HorzAlignment.Center, true, true, true,"C050");
                acGridView5.AddTextEdit("WORK_SEQ", "작업순서", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, true, acGridView.emTextEditMask.NUMERIC);
                acGridView5.AddLookUpEdit("WORK_CONT_CODE", "내용", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, true, "C051");
                acGridView5.AddTextEdit("WORK_TIME", "표준시간", "40234", false, DevExpress.Utils.HorzAlignment.Near, true, true, true, acGridView.emTextEditMask.NUMERIC);

                #endregion

                #region 준비 주의사항

                acGridView6.GridType = acGridView.emGridType.AUTO_COL;

                acGridView6.AddLookUpEdit("PRE_CODE", "준비 주의사항", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, true, "C052");
                acGridView6.AddMemoEdit("PRE_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true,false, true, false);
                acGridView6.AddMemoEdit("PRE_CHECK", "체크사항", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);

                #endregion

                #region 가공

                acGridView7.GridType = acGridView.emGridType.AUTO_COL;

                acGridView7.AddTextEdit("CONT_CODE", "코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, true, acGridView.emTextEditMask.NONE);
                acGridView7.AddTextEdit("PROC_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NONE);
                acGridView7.AddMemoEdit("PROC_CONTENTS", "내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);

                #endregion


                #region 공구

                #endregion
                acGridView4.GridType = acGridView.emGridType.AUTO_COL;
                acGridView4.AddTextEdit("TL_CODE", "공구코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("TL_LOT", "공구코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("HOLDER", "홀더", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("TL_NAME", "공구", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView4.Columns["TL_NAME"].ColumnEdit.MouseDown += TolColumnEdit_MouseDown;
                acGridView4.AddTextEdit("TL_LENGTH", "공구\n길이", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("TL_LIFE", "공구\n수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("WO_RPM", "RPM", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddTextEdit("WO_FEED", "FEED", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

                #region 공정정보
                acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;
              
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN_PROC", paramSet, "RQSTDT", "RSLTDT");

                DataTable dtSchem = new DataTable();

                _procList = rsltSet.Tables["RSLTDT"];

                if (_procList.Rows.Count > 0)
                {
                    foreach (DataRow row in _procList.Rows)
                    {
                        string strColumnNmae = "";
                        foreach (char c in row["PROC_NAME"].ToString())
                        {
                            strColumnNmae += (c + "\n");
                        }
                        dtSchem.Columns.Add(row["PROC_CODE"].ToString());

                        //strColumnNmae = row["PROC_NAME"].ToString() + "\n" + "sss";
                        //acGridView1.AddCheckEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, false, true, acGridView.emCheckEditDataType._INT);
                        RepositoryItem item = new RepositoryItem();
                        acGridView1.AddCustomEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, DevExpress.Utils.HorzAlignment.Center, false, true,false, item);

                    }
                }

                acGridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView1.OptionsSelection.EnableAppearanceHideSelection = true;

                acGridView1.ColumnPanelRowHeight = 90;
                acGridView1.RowHeight = 50;
                
                #endregion

                #region BOM TREE 


                acTreeList2.OptionsMenu.EnableColumnMenu = true;
                acTreeList2.OptionsMenu.EnableFooterMenu = false;
                acTreeList2.OptionsView.AutoWidth = false;
                acTreeList2.OptionsSelection.EnableAppearanceFocusedCell = true;
                acTreeList2.OptionsSelection.EnableAppearanceFocusedRow = true;


                acTreeList2.KeyFieldName = "BOM_ID";

                acTreeList2.ParentFieldName = "PARENT_ID";
                
                acTreeList2.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("BOM_PART_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("PARENT_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("PART_CODE", "품목코드", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("PART_NAME", "품목명", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddButtonEdit("MODFY", "공정\n정보\n편집", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);
                acTreeList2.AddTextEdit("MAT_SPEC1", "규격", "42545", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
                acTreeList2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true);
                acTreeList2.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", true);
                //acTreeList2.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, "S016", true);
                acTreeList2.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.QTY);
                //acTreeList2.AddLookUpEdit("STOCK_CODE", "창고코드", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, "M005", true);
                //acTreeList2.AddLookUpEdit("STOCK_TYPE", "완성재고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, "M013", true);
                acTreeList2.AddTextEdit("BOM_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, true, true, acTreeList.emTextEditMask.QTY);
                // acTreeList2.AddCheckEdit("MM", "공정1", "", false, false, true, acTreeList.emCheckEditDataType._BOOL);
                acTreeList2.OptionsSelection.MultiSelect = true;

                if (acTreeList2.Columns.ColumnByFieldName("MODFY").ColumnEdit is RepositoryItemButtonEdit treeRib)
                {
                    treeRib.ButtonClick += TreeRib_ButtonClick;
                    treeRib.Buttons[0].Image = Resource.edit_2x;
                    treeRib.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                }

                #endregion

                if (rsltSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    foreach (DataRow row in rsltSet.Tables["RSLTDT"].Select("IS_ASSY='1'"))
                    {
                        string strColumnNmae = "";
                        foreach (char c in row["PROC_NAME"].ToString())
                        {
                            strColumnNmae += (c + Environment.NewLine);
                        }
                        //dtSchem.Columns.Add(row["PROC_CODE"].ToString());

                        //strColumnNmae = row["PROC_NAME"].ToString() + "\n" + "sss";
                        acTreeList2.AddCheckEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, true, true, acTreeList.emCheckEditDataType._INT);                    }
                }

                if (acTreeList2.Columns.ColumnByFieldName("PART_CODE") is acTreeListColumn codeTlc)
                {
                    codeTlc.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                }

                if (acTreeList2.Columns.ColumnByFieldName("PART_NAME") is acTreeListColumn nameTlc)
                {
                    nameTlc.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                }

                if (acTreeList2.Columns.ColumnByFieldName("MODFY") is acTreeListColumn modfyTlc)
                {
                    modfyTlc.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
                }

                //검색조건
                (acLayoutControl1.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M001");
                (acLayoutControl1.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M002");
                (acLayoutControl1.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M008");

                
                
                acCheckedComboBoxEdit1.AddItem("등록일", false, "40515", "REG_DATE", false, false);

                acLabelControl2.Visible = true;


                SetControlState(emState.INIT);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void Rib_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_isChange)
            {
                if (acMessageBox.Show("수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                 //   acGridView3.FocusedRowChanged -= acGridView3_FocusedRowChanged;
                    return;
                }
            }
            
            _isChange = false;
            this.GetDetail();
        }

        void acGridView4_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            switch (e.RowHandle)
            {
                case 0:
                    e.Appearance.BackColor = Color.Beige;
                    break;
                //case 1:
                //    e.Appearance.BackColor = Color.Ivory;
                //    break;
            }
        }

        public override bool MenuDestory(object sender)
        {
            if (_isChange)
            {
                if (acMessageBox.Show("수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }

        string _part_code = string.Empty;
        string _copy_partCode = string.Empty;

        public override void MenuLink(object data)
        {
            if (data == null) return;

            //acLayoutControl1.GetEditor("PART_CODE").Value = data.ToString();
            _part_code = data.ToString();
            Search();


            _part_code = string.Empty;

            //base.MenuLink(data);
        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
            paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
            paramTable.Columns.Add("MAT_STYPE", typeof(String)); //
            paramTable.Columns.Add("SEARCH_CON", typeof(String));

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            if (_part_code != "")
            {
                paramRow["PART_CODE"] = _part_code;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PLN01A_SER", paramSet, "RQSTDT", "RSLTDT");
                acGridView3.GridControl.DataSource = dsResult.Tables["RSLTDT"];


                acGridView3.ExpandAllGroups();
                //.true.acGridView3.ExpandAllGroups();
                
            }
            else
            {
                

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":
                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];
                            break;
                    }
                }


                //paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["PART_CODE"] = _part_code;
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                paramRow["SEARCH_CON"] = layoutRow["PART_LIKE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN01A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
            }
    
        }

        private DataSet _dsResult = new DataSet();

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                
                _dsResult = e.result;
                
                acGridView3.GridControl.DataSource = _dsResult.Tables["RSLTDT"].Copy();
                acGridView3.SetOldFocusRowHandle(true);
                acGridView3.ExpandAllGroups();
                
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


      
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }
                
                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DataRefresh(object data)
        {

            this.GetProc();
        }


        private bool _isBind = false;

        private DataTable _procData = new DataTable();

        void GetDetail()
        {
            try
            {
                SetControlState(emState.PART_SEARCH);

                _masterRow = acGridView3.GetFocusedDataRow();
                DataRow focusRow = _masterRow;

                if (focusRow == null) return;

                string part_code = focusRow["PART_CODE"].ToString();

                //acLayoutControl2.DataBind(focusRow, false);

                //GET BOM
                acTreeList2.ClearNodes();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = part_code;
                paramRow["BOM_PART_CODE"] = part_code;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN01A_SER8", paramSet, "RQSTDT", "RSLTDT,RSLTDT_PROC,RSLTDT_PART,RSLTDT_BOM,RSLTDT_BOM_PROC,RSLTDT_PRG_PROC,RSLTDT_ASSY_PROC",
                            QuickSearch2,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void GetProc()
        {
            acGridView1.ClearRow();
            DataRow row = acGridView1.NewRow();

            DataRow dr = _masterRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = dr["PART_CODE"].ToString();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "PLN01A_SER2", paramSet, "RQSTDT", "RSLTDT");

            if (dsRslt.Tables["RSLTDT_PROC"].Rows.Count > 0) _hasProc = true;

            foreach (DataRow procRow in dsRslt.Tables["RSLTDT_PROC"].Rows)
            {
                row[procRow["PROC_CODE"].ToString()] = "1";
                if (procRow["MC_CODE"].ToString() != "")
                    acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = procRow["MC_CODE"].ToString() + ":" + procRow["EMP_CODE"].ToString();
                else
                    acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = null;
            }

            acGridView1.AddRow(row);


            if (dsRslt.Tables["RSLTDT_PART"].Rows.Count > 0)
            {
                //acLayoutControl2.DataBind(dsRslt.Tables["RSLTDT_PART"].Rows[0], false);
            }
        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                #region acGridView1
                if (e.result.Tables["RSLTDT_PROC"].Rows.Count > 0) _hasProc = true;

                acGridView1.ClearRow();
                DataRow row = acGridView1.NewRow();
                DataRow row2 = acGridView1.NewRow();
                foreach (DataRow procRow in e.result.Tables["RSLTDT_PROC"].Rows)
                {
                    row[procRow["PROC_CODE"].ToString()] = "1";
                    row2[procRow["PROC_CODE"].ToString()] = procRow["MC_NAME"];
                    if (procRow["MC_CODE"].ToString() != "")
                        acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = procRow["MC_CODE"].ToString() + ":" + procRow["EMP_CODE"].ToString();
                    else
                        acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = null;
                }

                acGridView1.AddRow(row);
                acGridView1.AddRow(row2);

                #endregion

                #region acTreeList2
                if (e.result.Tables["RSLTDT_BOM"] is DataTable dtBom)
                {
                    DataTable dtBomTree = acTreeList2.GetDataView().Table.Clone();
                    
                    if (dtBom.Rows.Count > 0)
                    {
                        foreach (DataRow bomRow in dtBom.Rows)
                        {
                            DataRow newBomRow = dtBomTree.NewRow();
                            
                            newBomRow["BOM_ID"] = bomRow["BOM_ID"];
                            newBomRow["BOM_PART_CODE"] = bomRow["BOM_PART_CODE"];
                            newBomRow["PARENT_ID"] = bomRow["PARENT_ID"];
                            newBomRow["PARENT_PART_CODE"] = bomRow["PARENT_PART_CODE"];
                            newBomRow["PARENT_PART_NAME"] = bomRow["PARENT_PART_NAME"];
                            newBomRow["PART_CODE"] = bomRow["PART_CODE"];
                            newBomRow["PART_NAME"] = bomRow["PART_NAME"];
                            newBomRow["MAT_SPEC1"] = bomRow["MAT_SPEC1"];
                            newBomRow["DRAW_NO"] = bomRow["DRAW_NO"];
                            newBomRow["MAT_UNIT"] = bomRow["MAT_UNIT"];
                            newBomRow["MAT_LTYPE"] = bomRow["MAT_LTYPE"];
                            newBomRow["MAT_TYPE"] = bomRow["MAT_TYPE"];
                            newBomRow["BOM_QTY"] = bomRow["BOM_QTY"];
                            //newBomRow["STOCK_CODE"] = bomRow["STOCK_CODE"];
                            //newBomRow["STOCK_TYPE"] = bomRow["STOCK_TYPE"];
                            newBomRow["BOM_SEQ"] = bomRow["BOM_SEQ"];

                            DataRow[] bomProcRows = e.result.Tables["RSLTDT_BOM_PROC"].AsEnumerable()
                                                            .Where(w => w["PART_CODE"].ToString().Equals(bomRow["PART_CODE"])).ToArray();
                            foreach (DataRow bomProcRow in bomProcRows)
                            {
                                if (dtBomTree.Columns.Contains(bomProcRow["PROC_CODE"].ToString()))
                                {
                                    newBomRow[bomProcRow["PROC_CODE"].ToString()] = "1";
                                }
                                //if (procRow["MC_CODE"].ToString() != "")
                                //    acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = procRow["MC_CODE"].ToString() + ":" + procRow["EMP_CODE"].ToString();
                                //else
                                //    acGridView1.Columns[procRow["PROC_CODE"].ToString()].Tag = null;
                            }

                            dtBomTree.Rows.Add(newBomRow);
                        }
                    }
                    else
                    {
                    
                        DataRow newBomRow = dtBomTree.NewRow();

                        if (e.result.Tables["RSLTDT_PART"].AsEnumerable().FirstOrDefault() is DataRow dr)
                        {
                            newBomRow["BOM_ID"] = "NEW";
                            newBomRow["BOM_PART_CODE"] = dr["PART_CODE"];
                            newBomRow["PARENT_ID"] = "";
                            newBomRow["PARENT_PART_CODE"] = dr["PART_CODE"];
                            newBomRow["PARENT_PART_NAME"] = dr["PART_NAME"];
                            newBomRow["PART_CODE"] = dr["PART_CODE"];
                            newBomRow["PART_NAME"] = dr["PART_NAME"];
                            newBomRow["MAT_SPEC1"] = dr["MAT_SPEC1"];
                            newBomRow["DRAW_NO"] = dr["DRAW_NO"];
                            newBomRow["MAT_UNIT"] = dr["MAT_UNIT"];
                            newBomRow["MAT_LTYPE"] = dr["MAT_LTYPE"];
                            newBomRow["MAT_TYPE"] = dr["MAT_TYPE"];
                            newBomRow["BOM_QTY"] = 0;
                            //newBomRow["STOCK_CODE"] = "";
                            //newBomRow["STOCK_TYPE"] = "";
                            newBomRow["BOM_SEQ"] = 0;

                            foreach (DataRow procRow in e.result.Tables["RSLTDT_PROC"].Rows)
                            {
                                if (dtBomTree.Columns.Contains(procRow["PROC_CODE"].ToString()))
                                {
                                    newBomRow[procRow["PROC_CODE"].ToString()] = "1";
                                }
                            }

                            dtBomTree.Rows.Add(newBomRow);
                        }
                    }
                    acTreeList2.DataSource = dtBomTree;
                }

                acTreeList2.ExpandAll();

                acTreeList2.BestFitColumns();
                #endregion

                DataTable rsltAssyProc = e.result.Tables["RSLTDT_PRG_PROC"].AsEnumerable()
                                                             .GroupJoin(e.result.Tables["RSLTDT_ASSY_PROC"].AsEnumerable()
                                                                      , prg => prg["PROC_CODE"]
                                                                      , assy => assy["PROC_CODE"]
                                                                      , (prg, assy) => new
                                                                      {
                                                                          PRG = prg,
                                                                          ASSY = assy
                                                                      })
                                                            .SelectMany(
                                                                r1 => r1.ASSY.DefaultIfEmpty(),
                                                                (prg,assy) =>
                                                                    new {
                                                                            PLT_CODE = prg.PRG["PLT_CODE"]
                                                                            , PART_CODE = assy?["PART_CODE"]
                                                                            //, PART_NAME = assy?["PART_NAME"]
                                                                            , SEL = e.result.Tables["RSLTDT_PROC"]
                                                                                    .Select("PLT_CODE='"+ prg.PRG["PLT_CODE"]
                                                                                        //+ "' AND PART_CODE='" + assy?["PART_CODE"]
                                                                                        + "' AND PROC_CODE='" + prg.PRG["PROC_CODE"]+"'").Length==0?"0":"1"
                                                                            , PRG_CODE = prg.PRG["PRG_CODE"]
                                                                            , PRG_NAME = prg.PRG["PRG_NAME"]
                                                                            , PROC_CODE = prg.PRG["PROC_CODE"]
                                                                            , PROC_NAME = prg.PRG["PROC_NAME"]
                                                                            , PROC_CONTENTS = assy?["PROC_CONTENTS"]
                                                                            , PROC_REMARK = assy?["PROC_REMARK"]
                                                                            , INS_METHOD = assy?["INS_METHOD"]
                                                                            , ASSY_TIME = assy?["ASSY_TIME"]
                                                                            , IMPORTANCE = assy?["IMPORTANCE"]
                                                                        })
                                                            .LINQToDataTable();


                foreach(var prgGrp in rsltAssyProc.AsEnumerable()
                                                    .GroupBy(g=>g["PRG_CODE"])
                                                    .Select(r=>new { PRG_CODE = r.Key
                                                                    , IMPORTANCE = r.Max(m=>m["IMPORTANCE"].toDecimal())
                                                                    , PRG_LIST = r.ToList()}))
                {
                    foreach(DataRow assyRow in prgGrp.PRG_LIST)
                    {
                        assyRow["IMPORTANCE"] = prgGrp.IMPORTANCE;
                    }
                }

                acGridView2.GridControl.DataSource = rsltAssyProc;
                foreach (DataRow filerow in e.result.Tables["RSLTDT_PART"].Rows)
                {
                    acLayoutControl3.DataBind(filerow, false);
                    if (filerow["ASSY_FILE_CONTENT"] is byte[] bytes)
                    {
                        Stream stream = new MemoryStream(bytes);
                        pdfViewer2.LoadDocument(stream);

                        break;
                    }
                }

                btnSaveContents.Enabled = true;


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

            //    layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }

            base.ChildContainerInit(sender);
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {

                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private bool _isChange = false;

     
        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == null) return;
            if (e.CellValue.ToString() == "1")
            {
                e.Appearance.BackColor = Color.YellowGreen;
                //e.Appearance.Font = new Font("나눔고딕", 15);
                //System.Diagnostics.Debug.WriteLine("색상변경:"+ e.Column.FieldName);
                
            }
        }


        
        private void btnSetMC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            //가공별 정보 저장
            try
            {
                if (_selectProcCode == null)
                    return;

                DateTime now = DateTime.Now;

                DataSet paramSet = new DataSet();

                DataTable paramTable_Del = paramSet.Tables.Add("RQSTDT_DEL");
                paramTable_Del.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable_Del.Columns.Add("PART_CODE", typeof(String)); //
                paramTable_Del.Columns.Add("PROC_CODE", typeof(String)); //

                DataRow paramRow_Del = paramTable_Del.NewRow();
                paramRow_Del["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow_Del["PART_CODE"] = _masterRow["PART_CODE"];
                paramRow_Del["PROC_CODE"] = _selectProcCode;
                paramTable_Del.Rows.Add(paramRow_Del);

                DataTable paramTable_Work = paramSet.Tables.Add("RQSTDT_WORK");
                paramTable_Work.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("PART_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("WORK_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("WORK_GUBUN_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("WORK_CONT_CODE", typeof(String)); //
                paramTable_Work.Columns.Add("WORK_SEQ", typeof(Int32)); //
                paramTable_Work.Columns.Add("WORK_TIME", typeof(Int32)); //
                paramTable_Work.Columns.Add("REG_EMP", typeof(String)); //
                paramTable_Work.Columns.Add("REG_DATE", typeof(DateTime)); //

                foreach (DataRow row in (acGridView5.GridControl.DataSource as DataTable).Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        continue;
                    }

                    DataRow paramRow_Work = paramTable_Work.NewRow();
                    paramRow_Work["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow_Work["PART_CODE"] = _masterRow["PART_CODE"];
                    paramRow_Work["PROC_CODE"] = _selectProcCode;
                    paramRow_Work["WORK_CODE"] = row["WORK_CODE"];
                    paramRow_Work["WORK_GUBUN_CODE"] = row["WORK_GUBUN_CODE"];
                    paramRow_Work["WORK_CONT_CODE"] = row["WORK_CONT_CODE"];
                    paramRow_Work["WORK_SEQ"] = row["WORK_SEQ"];
                    paramRow_Work["WORK_TIME"] = row["WORK_TIME"];
                    paramRow_Work["REG_EMP"] = acInfo.UserID;
                    paramRow_Work["REG_DATE"] = now;
                    paramTable_Work.Rows.Add(paramRow_Work);
                }


                DataTable paramTable_Pre = paramSet.Tables.Add("RQSTDT_PRE");
                paramTable_Pre.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable_Pre.Columns.Add("PART_CODE", typeof(String)); //
                paramTable_Pre.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable_Pre.Columns.Add("PRE_CODE", typeof(String)); //
                paramTable_Pre.Columns.Add("PRE_SPEC", typeof(String)); //
                paramTable_Pre.Columns.Add("PRE_CHECK", typeof(String)); //
                paramTable_Pre.Columns.Add("REG_EMP", typeof(String)); //
                paramTable_Pre.Columns.Add("REG_DATE", typeof(DateTime)); //

                foreach (DataRow row in (acGridView6.GridControl.DataSource as DataTable).Rows)
                {
                    DataRow paramRow_Pre = paramTable_Pre.NewRow();
                    paramRow_Pre["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow_Pre["PART_CODE"] = _masterRow["PART_CODE"];
                    paramRow_Pre["PROC_CODE"] = _selectProcCode;
                    paramRow_Pre["PRE_CODE"] = row["PRE_CODE"];
                    paramRow_Pre["PRE_SPEC"] = row["PRE_SPEC"];
                    paramRow_Pre["PRE_CHECK"] = row["PRE_CHECK"];
                    paramRow_Pre["REG_EMP"] = acInfo.UserID;
                    paramRow_Pre["REG_DATE"] = now;
                    paramTable_Pre.Rows.Add(paramRow_Pre);
                }

                DataTable paramTable_Cont = paramSet.Tables.Add("RQSTDT_CONT");
                paramTable_Cont.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable_Cont.Columns.Add("PART_CODE", typeof(String)); //
                paramTable_Cont.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable_Cont.Columns.Add("CONT_CODE", typeof(String)); //
                paramTable_Cont.Columns.Add("PROC_SEQ", typeof(Int32)); //
                paramTable_Cont.Columns.Add("PROC_CONTENTS", typeof(String)); //
                paramTable_Cont.Columns.Add("REG_EMP", typeof(String)); //
                paramTable_Cont.Columns.Add("REG_DATE", typeof(DateTime)); //

                if (acGridView7.GridControl.DataSource is DataTable dataTableCont)
                {
                    if (dataTableCont.AsEnumerable()
                                       .Where(w=>w.RowState != DataRowState.Deleted)
                                       .GroupBy(g => g["PROC_SEQ"])
                                       .Select(r => new { PROC_SEQ = r.Key, CNT = r.Count() })
                                       .Where(w => w.CNT > 1)
                                       .Any())
                    {
                        acMessageBox.Show(this, "중복되는 숫자가 존재합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    int index = 1;
                    foreach (DataRow row in dataTableCont.AsEnumerable().Where(w => w.RowState != DataRowState.Deleted).OrderBy(o=>o["PROC_SEQ"]))
                    {
                        if (row.RowState == DataRowState.Deleted)
                        {
                            continue;
                        }

                        DataRow paramRow_Cont = paramTable_Cont.NewRow();
                        paramRow_Cont["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow_Cont["PART_CODE"] = _masterRow["PART_CODE"];
                        paramRow_Cont["PROC_CODE"] = _selectProcCode;
                        paramRow_Cont["CONT_CODE"] = row["CONT_CODE"];
                        paramRow_Cont["PROC_SEQ"] = index++;
                        paramRow_Cont["PROC_CONTENTS"] = row["PROC_CONTENTS"];
                        paramRow_Cont["REG_EMP"] = acInfo.UserID;
                        paramRow_Cont["REG_DATE"] = now;
                        paramTable_Cont.Rows.Add(paramRow_Cont);
                    }
                }

                DataTable paramTable_Actual_Tool = paramSet.Tables.Add("RQSTDT_ACTTOOL");
                paramTable_Actual_Tool.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("PART_CODE", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("TL_LOT", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("WO_RPM", typeof(Int32)); //
                paramTable_Actual_Tool.Columns.Add("WO_FEED", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("REG_EMP", typeof(String)); //
                paramTable_Actual_Tool.Columns.Add("REG_DATE", typeof(DateTime)); //
                paramTable_Actual_Tool.Columns.Add("IS_DEL", typeof(String)); //

                foreach (DataRow row in (acGridView4.GridControl.DataSource as DataTable).Rows)
                {
                    DataRow paramRow_Actual_Tool = paramTable_Actual_Tool.NewRow();
                    paramRow_Actual_Tool["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow_Actual_Tool["PART_CODE"] = _masterRow["PART_CODE"];
                    paramRow_Actual_Tool["PROC_CODE"] = _selectProcCode;
                    paramRow_Actual_Tool["REG_EMP"] = acInfo.UserID;
                    paramRow_Actual_Tool["REG_DATE"] = now;

                    if (row.RowState == DataRowState.Deleted)
                    {
                        paramRow_Actual_Tool["IS_DEL"] = "1";
                        paramRow_Actual_Tool["TL_LOT"] = row["TL_LOT",DataRowVersion.Original];
                        paramRow_Actual_Tool["WO_RPM"] = row["WO_RPM", DataRowVersion.Original];
                        paramRow_Actual_Tool["WO_FEED"] = row["WO_FEED", DataRowVersion.Original];
                    }
                    else
                    {
                        paramRow_Actual_Tool["TL_LOT"] = row["TL_LOT"];
                        paramRow_Actual_Tool["WO_RPM"] = row["WO_RPM"];
                        paramRow_Actual_Tool["WO_FEED"] = row["WO_FEED"];
                    }

                    paramTable_Actual_Tool.Rows.Add(paramRow_Actual_Tool);

                }

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch4,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch4(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //foreach(DataRow row in e.result.Tables["RQSTDT_CONT"].Rows)
                //{
                //    acGridView7.UpdateMapingRow(row, false);
                //}

                acGridView5.GridControl.DataSource = e.result.Tables["RQSTDT_WORK"];
                acGridView6.GridControl.DataSource = e.result.Tables["RQSTDT_PRE"];
                acGridView7.GridControl.DataSource = e.result.Tables["RQSTDT_CONT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //삭제
            try
            {

                acGridView3.EndEditor();



                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }



                DataView selected = acGridView3.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                if (selected.Count == 0)
                {

                    //단일삭제
                    DataRow focusRow = acGridView3.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);



                }
                else
                {

                    //다중삭제
                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_CODE"] = selected[i]["PART_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "STD02A_DEL", paramSet, "RQSTDT", "RSLTDT",
                    QuickDEL2,
                    QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickDEL2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            acSimpleButton2_Click(null, null);
        }


      
        /// <summary>
        /// BOM 삽입
        /// </summary>
        /// <param name="parentRow">부모행</param>
        /// <param name="insertRow">자식행</param>
        void SaveBom(DataRow parentRow, DataRow insertRow)
        {
            try
            {
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

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BOM_PART_CODE"] = parentRow["PART_CODE"];
                paramRow["PART_CODE"] = insertRow["PART_CODE"];
                if (!parentRow["BOM_ID"].toStringEmpty().Equals("NEW"))
                    paramRow["PARENT_ID"] = parentRow["BOM_ID"];
                paramRow["BOM_QTY"] = 1;    //기본값 1로 설정
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (acGridView2.GridControl.DataSource is DataTable dt)
                {
                    DateTime nowTime = DateTime.Now;

                    DataSet paramSet = new DataSet();

                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PART_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_CONTENTS", typeof(String)); //
                    paramTable.Columns.Add("PROC_REMARK", typeof(String)); //
                    paramTable.Columns.Add("INS_METHOD", typeof(String)); //
                    paramTable.Columns.Add("ASSY_TIME", typeof(Int32)); //
                    paramTable.Columns.Add("IMPORTANCE", typeof(Int32)); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //
                    paramTable.Columns.Add("REG_DATE", typeof(DateTime)); //
                    paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                    paramTable.Columns.Add("MDFY_DATE", typeof(DateTime)); //

                    foreach (DataRow row in dt.Select("SEL = '1'"))
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_CODE"] = _masterRow["PART_CODE"];
                        paramRow["PROC_CODE"] = row["PROC_CODE"];
                        paramRow["PROC_CONTENTS"] = row["PROC_CONTENTS"];
                        paramRow["PROC_REMARK"] = row["PROC_REMARK"];
                        paramRow["INS_METHOD"] = row["INS_METHOD"];
                        paramRow["ASSY_TIME"] = row["ASSY_TIME"];
                        paramRow["IMPORTANCE"] = row["IMPORTANCE"];
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["REG_DATE"] = nowTime;
                        paramRow["MDFY_EMP"] = acInfo.UserID;
                        paramRow["MDFY_DATE"] = nowTime;
                        paramTable.Rows.Add(paramRow);
                    }

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS3", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);
                }
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

                acMessageBox.Show(this, "저장 완료", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnUpload1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.PDF(문서) | *.PDF";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataSet paramSet = new DataSet();

                    DateTime nowTime = DateTime.Now;

                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PART_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_FILE_NAME", typeof(String)); //
                    paramTable.Columns.Add("PROC_FILE_CONTENT", typeof(byte[])); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //
                    paramTable.Columns.Add("REG_DATE", typeof(DateTime)); //
                    paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                    paramTable.Columns.Add("MDFY_DATE", typeof(DateTime)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = _masterRow["PART_CODE"];
                    paramRow["PROC_CODE"] = _selectProcCode;
                    paramRow["PROC_FILE_NAME"] = new FileInfo(ofd.FileName).Name;

                    txtUploadFile1.Text = new FileInfo(ofd.FileName).Name;

                    byte[] array;
                    using (FileStream fs = File.OpenRead(ofd.FileName))
                    {
                        array = new byte[fs.Length];
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            paramRow["PROC_FILE_CONTENT"] = br.ReadBytes((int)fs.Length);
                        }
                    }

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["REG_DATE"] = nowTime;
                    paramRow["MDFY_EMP"] = acInfo.UserID;
                    paramRow["MDFY_DATE"] = nowTime;
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS4", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnDownload1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "*.PDF | *.PDF";

                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        pdfViewer1.SaveDocument(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnUpload2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.PDF(문서) | *.PDF";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataSet paramSet = new DataSet();

                    DateTime nowTime = DateTime.Now;

                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("PART_CODE", typeof(String)); //
                    paramTable.Columns.Add("ASSY_FILE_NAME", typeof(String)); //
                    paramTable.Columns.Add("ASSY_FILE_CONTENT", typeof(byte[])); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //
                    paramTable.Columns.Add("REG_DATE", typeof(DateTime)); //
                    paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                    paramTable.Columns.Add("MDFY_DATE", typeof(DateTime)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = _masterRow["PART_CODE"];
                    paramRow["ASSY_FILE_NAME"] = new FileInfo(ofd.FileName).Name;

                    txtUploadFile2.Text = new FileInfo(ofd.FileName).Name;

                    byte[] array;
                    using (FileStream fs = File.OpenRead(ofd.FileName))
                    {
                        array = new byte[fs.Length];
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            paramRow["ASSY_FILE_CONTENT"] = br.ReadBytes((int)fs.Length);
                        }
                    }

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["REG_DATE"] = nowTime;
                    paramRow["MDFY_EMP"] = acInfo.UserID;
                    paramRow["MDFY_DATE"] = nowTime;
                    paramTable.Rows.Add(paramRow);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS5", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDownload2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "*.PDF | *.PDF";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        pdfViewer2.SaveDocument(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetControlState(emState e)
        {
            switch(e)
            {
                case emState.INIT:
                    {
                        acGridView1.ClearRow();
                        acGridView2.ClearRow();
                        acGridView5.ClearRow();
                        acGridView6.ClearRow();
                        acGridView7.ClearRow();
                        acTreeList2.ClearNodes();

                        lblSelectProc.Text = "";
                        _selectProcCode = "";

                        btnSaveContents.Enabled = false;
                    }
                    break;
                case emState.PART_SEARCH:
                    {
                        acGridView2.ClearRow();
                        acGridView5.ClearRow();
                        acGridView6.ClearRow();
                        acGridView7.ClearRow();
                        acTreeList2.ClearNodes();

                        lblSelectProc.Text = "";
                        _selectProcCode = "";

                        acSplitContainerControl3.Panel2.Enabled = false;
                    }
                    break;
                case emState.PROC_SELECT:
                    {
                        acGridView5.ClearRow();
                        acGridView6.ClearRow();
                        acGridView7.ClearRow();

                        lblSelectProc.Text = "";
                        _selectProcCode = "";

                        acSplitContainerControl3.Panel2.Enabled = false;
                    }
                    break;
            }
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int focusRowIndex = acGridView5.GetFocusedDataSourceRowIndex();
                acGridView5.DeleteRow(focusRowIndex);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnDel2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int focusRowIndex = acGridView7.GetFocusedDataSourceRowIndex();
                acGridView7.DeleteRow(focusRowIndex);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnDel3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int focusRowIndex = acGridView4.GetFocusedDataSourceRowIndex();
                acGridView4.DeleteRow(focusRowIndex);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acGridView4.GridControl.DataSource is DataTable lotTable)
                {
                    string mcCode = null;
                    if (acGridView1.Columns[_selectProcCode].Tag != null)
                    {
                        string tag = acGridView1.Columns[_selectProcCode].Tag.toStringEmpty();
                        string[] spliteTag = tag.Split(':');
                        mcCode = spliteTag.FirstOrDefault();
                    }

                    PLN01A_D7A toolFrm = new PLN01A_D7A(mcCode, lotTable);
                    toolFrm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    toolFrm.ParentControl = this;
                    if (toolFrm.ShowDialog() == DialogResult.OK)
                    {
                        if (toolFrm.OutputData is DataTable dt)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                acGridView4.AddNewRow();
                                DataRow row = acGridView4.GetFocusedDataRow();

                                row["PART_CODE"] = _masterRow["PART_CODE"];
                                row["PROC_CODE"] = _selectProcCode;

                                foreach (DataColumn col in dt.Columns)
                                {
                                    if (acGridView4.Columns.ColumnByFieldName(col.ColumnName) != null)
                                    {
                                        //view.SetFocusedRowCellValue(col.ColumnName, dr[col.ColumnName]);
                                        row[col.ColumnName] = dr[col.ColumnName];
                                    }
                                }
                            }
                        }
                    }
                    acGridView4.RefreshData();
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void TreeRib_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRowView drView = acTreeList2.GetDataRecordByNode(acTreeList2.FocusedNode) as DataRowView;
                
                if (drView == null) return;

                DataRow dr = drView.Row;

                if (dr == null) return;

                DataTable paramTable = new DataTable();

                PLN01B_D0A frm = new PLN01B_D0A(acGridView1, acGridView3.GetFocusedDataRow(), dr["PART_CODE"].ToString());

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("PROC_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = _masterRow["PART_CODE"];
                paramRow["PROC_CODE"] = _selectProcCode;
                paramTable.Rows.Add(paramRow);

                PLN01B_D1A frm = new PLN01B_D1A(paramRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

