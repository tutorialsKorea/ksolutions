using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

namespace STD
{
    public sealed partial class STD06A_D0A : BaseMenuDialog
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

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;



        public STD06A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();



            _LinkData = linkData;

            _LinkView = linkView;



            //가용설비

            gvLeft.GridType = acGridView.emGridType.FIXED;

            gvLeft.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvLeft.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            gvLeft.OptionsView.ShowIndicator = true;

            gvLeft.KeyColumn = new string[] { "EMP_CODE" };



            //작업자 설정

            gvRight.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvRight.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");

            gvRight.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            gvRight.KeyColumn = new string[] { "EMP_CODE" };


            gvRight.Columns["ORG_NAME"].GroupIndex = 0;
            gvRight.Columns["ORG_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;




            gvRight.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(gvRight_CustomColumnSort);


            gvLeft.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvLeft_ShowGridMenuEx);

            gvRight.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvRight_ShowGridMenuEx);


            gvRight.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(gvRight_CustomDrawGroupRow);

            gvRight.MouseDown += new MouseEventHandler(gvRight_MouseDown);


            gvLeft.MouseDown += new MouseEventHandler(gvLeft_MouseDown);


            gvLeft.KeyDown += new KeyEventHandler(gvLeft_KeyDown);

            gcLeft.DragDrop += new DragEventHandler(gcLeft_DragDrop);

            gcLeft.DragOver += new DragEventHandler(gcLeft_DragOver);

            gcLeft.DragLeave += new EventHandler(gcLeft_DragLeave);
            gcLeft.GiveFeedback += new GiveFeedbackEventHandler(gcLeft_GiveFeedback);

            gvLeft.MouseMove += new MouseEventHandler(gvLeft_MouseMove);

            gvRight.MouseDown += new MouseEventHandler(gvRight_MouseDown);




        }

        void gvRight_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            acGridView view = sender as acGridView;

            int val1 = 0;
            int val2 = 0;

            switch (e.Column.FieldName)
            {

                case "ORG_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "ORG_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "ORG_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }


                    break;

            }

        }

        void gvRight_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.RowHandle >= 0 &&
                (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
                )
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        void gvLeft_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                if (hitInfo.InColumn == false)
                {
                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }

            }
        }

        void gcLeft_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void gcLeft_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        void gcLeft_DragOver(object sender, DragEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor(gvLeft.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);

                }
            }
        }

        void gcLeft_DragDrop(object sender, DragEventArgs e)
        {
            this.Cursor = Cursors.Default;


            GridControl grid = sender as GridControl;

            DataTable table = grid.DataSource as DataTable;

            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;

            Point pt = grid.PointToClient(new Point(e.X, e.Y));

            GridView view = (GridView)grid.GetViewAt(pt);

            int ndx = view.CalcHitInfo(pt).RowHandle;

            int nR = table.Rows.IndexOf(row);

            if (ndx < 0 || nR == ndx)
            {
                return;
            }

            DataRow dr = table.NewRow();

            dr.ItemArray = row.ItemArray;


            table.Rows.RemoveAt(nR);

            table.Rows.InsertAt(dr, ndx);


            view.FocusedRowHandle = ndx;

            table.AcceptChanges();



        }

        void gvLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                gvLeft.DeleteRow(gvLeft.FocusedRowHandle);
            }
        }

        private GridHitInfo _MouseDownHitInfo = null;

        void gvLeft_MouseMove(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && _MouseDownHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;

                Rectangle dragRect = new Rectangle(new Point(_MouseDownHitInfo.HitPoint.X - dragSize.Width / 2,
                    _MouseDownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(_MouseDownHitInfo.RowHandle);

                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);

                    _MouseDownHitInfo = null;

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }



        void gvLeft_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

            if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _MouseDownHitInfo = hitInfo;
                }
            }


            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    gvLeft.DeleteRow(gvLeft.FocusedRowHandle);
                }

            }
        }

        void gvRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gvRight.CalcHitInfo(e.Location);

                if (hitInfo.InRow && hitInfo.InRowCell)
                {
                    DataRow focusRow = gvRight.GetFocusedDataRow();

                    DataView availEmpView = gvLeft.GetDataSourceView("EMP_CODE = '" + focusRow["EMP_CODE"].ToString() + "'");

                    //작업자 목록에 없으면 추가
                    if (availEmpView.Count == 0)
                    {
                        gvLeft.AddRow(focusRow);
                    }


                }

            }
        }



        public override void DialogInit()
        {



            //작업자 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);


            base.DialogInit();
        }

        void gvRight_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                gvRight.GridControl.DataSource = e.result.Tables["RSLTDT"];
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



        public override void DialogNew()
        {
            //새로만들기


            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기

            object[] linkData = (object[])_LinkData;

            acLayoutControl1.DataBind((DataRow)linkData[0], true);

            DataTable availMc = linkData[1] as DataTable;

            gvLeft.GridControl.DataSource = availMc.Copy();



            base.DialogOpen();
        }


        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                gvLeft.ClearRow();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this._LinkView.RaiseFocusedRowChanged();

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {


                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["MC_CODE"] = layoutRow["MC_CODE"];


                paramTable1.Rows.Add(paramRow1);


                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable2.Columns.Add("EMP_SEQ", typeof(Int32)); //


                DataView availEmpData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView empRowView in availEmpData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["EMP_CODE"] = empRowView["EMP_CODE"];
                    paramRow2["EMP_SEQ"] = mcCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++mcCnt;

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD06A_INS", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //작업자 삭제
            try
            {
                gvLeft.EndEditor();

                DataView selectedView = gvLeft.GetDataSourceView("SEL = '1'");


                if (selectedView.Count == 0)
                {
                    //단일
                    gvLeft.DeleteMappingRow(gvLeft.GetFocusedDataRow());
                }
                else
                {
                    //다중
                    int cnt = selectedView.Count;

                    for (int i = 0; i < cnt; i++)
                    {
                        gvLeft.DeleteMappingRow(selectedView[0].Row);
                    }

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //작업자 추가
            try
            {
                gvRight.EndEditor();


                DataView selectedView = gvRight.GetDataSourceView("SEL = '1'");


                if (selectedView.Count == 0)
                {
                    //단일
                    DataRow focusRow = gvRight.GetFocusedDataRow();

                    DataView availEmpView = gvLeft.GetDataSourceView("EMP_CODE = '" + focusRow["EMP_CODE"].ToString() + "'");

                    //작업자 목록에 없으면 추가
                    if (availEmpView.Count == 0)
                    {
                        DataRow row = focusRow.NewCopy();

                        row["SEL"] = "0";

                        gvLeft.UpdateMapingRow(focusRow, true);
                    }

                }
                else
                {
                    //다중
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataView availMcView = gvLeft.GetDataSourceView("EMP_CODE = '" + selectedView[i]["EMP_CODE"].ToString() + "'");

                        //작업자 목록에 없으면 추가
                        if (availMcView.Count == 0)
                        {
                            DataRow row = selectedView[i].Row.NewCopy();

                            row["SEL"] = "0";

                            gvLeft.UpdateMapingRow(row, true);
                        }
                    }

                    gvRight.SetValue("SEL", "0");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }



    }
}