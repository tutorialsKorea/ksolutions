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

namespace ControlManager
{
    public sealed partial class acLoadableMcForm : BaseMenuDialog
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

        public acLoadableMcForm()
        {
            InitializeComponent();

            gvNotSel.GridType = acGridView.emGridType.FIXED_FULLWIDTH;

            gvNotSel.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvNotSel.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvNotSel.KeyColumn = new string[] { "MC_CODE" };



            gvSel.GridType = acGridView.emGridType.FIXED_FULLWIDTH;

            gvSel.OptionsView.ShowIndicator = true;

            gvSel.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvSel.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvSel.KeyColumn = new string[] { "MC_CODE" };


            #region 이벤트 설정



            gvNotSel.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvNotSel_ShowGridMenuEx);


            gvNotSel.MouseDown += new MouseEventHandler(gvNotSel_MouseDown);




            gvSel.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvSel_ShowGridMenuEx);


            gvSel.MouseDown += new MouseEventHandler(gvSel_MouseDown);

            gcSel.DragDrop += new DragEventHandler(gcSel_DragDrop);

            gcSel.DragOver += new DragEventHandler(gcSel_DragOver);

            gcSel.DragLeave += new EventHandler(gcSel_DragLeave);

            gvSel.MouseMove += new MouseEventHandler(gvSel_MouseMove);

            gcSel.GiveFeedback += new GiveFeedbackEventHandler(gcSel_GiveFeedback);


            #endregion
        }





        void gcSel_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        void gcSel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        private GridHitInfo _MouseDownHitInfo = null;

        void gcSel_DragOver(object sender, DragEventArgs e)
        {

            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor(gvSel.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                }

            }

        }

        void gcSel_DragDrop(object sender, DragEventArgs e)
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


        void gvSel_MouseMove(object sender, MouseEventArgs e)
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


        void gvSel_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (view.GetSelectedRows().Length != 0)
                {
                    //선택된 row가 있으면 팝업창 표시

                    popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

                }
            }
        }

        void gvNotSel_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {


            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (view.GetSelectedRows().Length != 0)
                {
                    //선택된 row가 있으면 팝업창 표시

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

                }


            }

        }

        void gvNotSel_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));


            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2_ItemClick(null, null);

                }
            }
        }

        void gvSel_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    _MouseDownHitInfo = hitInfo;
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    acBarButtonItem3_ItemClick(null, null);
                }
            }



        }




        public override void DialogInit()
        {

            acLoadableMcEdit edit = this.ParentControl as acLoadableMcEdit;



            //가용설비 가져오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROC_CODE"] = edit.ProcCode;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_LOADABLEMC_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);

            //DataSet dsResult = BizManager.acControls.CONTROL_LOADABLEMC_SEARCH(paramSet);

            //QuickSearch(dsResult);

            base.DialogInit();


        }

        void QuickSearch(DataSet ds)
        {


            //선택된 설비 리스트 변환
            try
            {

                acLoadableMcEdit edit = this.ParentControl as acLoadableMcEdit;


                DataTable selectedMc = new DataTable();


                string loadableMcs = edit.Value.toStringEmpty();


                selectedMc.Columns.Add("MC_CODE");

                foreach (string loadableMC in loadableMcs.Split(";".ToCharArray()))
                {
                    DataRow mcRow = selectedMc.NewRow();

                    mcRow["MC_CODE"] = loadableMC;

                    selectedMc.Rows.Add(mcRow);

                }


                //사용 가능한 설비리스트 
                DataTable notSelectedMc = ds.Tables["RSLTDT"];

                for (int i = 0; i < selectedMc.Rows.Count; i++)
                {
                    DataRow[] selRows = notSelectedMc.Select("MC_CODE = '" + selectedMc.Rows[i]["MC_CODE"].ToString() + "'");

                    foreach (DataRow selRow in selRows)
                    {
                        gvSel.AddRow(selRow);

                        notSelectedMc.Rows.Remove(selRow);
                    }
                }


                gvNotSel.GridControl.DataSource = notSelectedMc;


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {


            //선택된 설비 리스트 변환
            try
            {

                acLoadableMcEdit edit = this.ParentControl as acLoadableMcEdit;


                DataTable selectedMc = new DataTable();


                string loadableMcs = edit.Value.toStringEmpty();


                selectedMc.Columns.Add("MC_CODE");

                foreach (string loadableMC in loadableMcs.Split(";".ToCharArray()))
                {
                    DataRow mcRow = selectedMc.NewRow();

                    mcRow["MC_CODE"] = loadableMC;

                    selectedMc.Rows.Add(mcRow);

                }


                //사용 가능한 설비리스트 
                DataTable notSelectedMc = e.result.Tables["RSLTDT"];

                for (int i = 0; i < selectedMc.Rows.Count; i++)
                {
                    DataRow[] selRows = notSelectedMc.Select("MC_CODE = '" + selectedMc.Rows[i]["MC_CODE"].ToString() + "'");

                    foreach (DataRow selRow in selRows)
                    {
                        gvSel.AddRow(selRow);

                        notSelectedMc.Rows.Remove(selRow);
                    }
                }


                gvNotSel.GridControl.DataSource = notSelectedMc;


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            acMessageBox.Show(this, ex);

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {
                DataTable selMc = gvSel.GridControl.DataSource as DataTable;


                if (selMc.Rows.Count == 0)
                {

                    acMessageBox.Show(this, "하나 이상의 가용설비가 설정되어야합니다.", "HQFK4MH9",
                        true, acMessageBox.emMessageBoxType.CONFIRM);

                    return;
                }


                selMc.AcceptChanges();

                string loadableMcs = string.Empty;

                string loadableMcNames = string.Empty;

                if (selMc.Rows.Count > 0)
                {
                    for (int i = 0; i < selMc.Rows.Count; i++)
                    {
                        loadableMcs += selMc.Rows[i]["MC_CODE"].ToString() + ';';

                        loadableMcNames += selMc.Rows[i]["MC_NAME"].ToString() + ';';

                    }

                    loadableMcs = loadableMcs.Substring(0, loadableMcs.Length - 1);
                }


                this.OutputData = loadableMcs;

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택가능설비에서 가용설비로 이동


            int[] rowHandles = gvNotSel.GetSelectedRows();

            List<DataRow> selRows = new List<DataRow>();

            foreach (int rowHandle in rowHandles)
            {
                DataRow row = gvNotSel.GetDataRow(rowHandle);

                gvSel.AddRow(row);

                selRows.Add(row);


            }

            foreach (DataRow selRow in selRows)
            {
                gvNotSel.DeleteMappingRow(selRow);

            }

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //가용설비에서 선택가능 설비로 이동
            try
            {
                int[] rowHandles = gvSel.GetSelectedRows();

                List<DataRow> selRows = new List<DataRow>();

                foreach (int rowHandle in rowHandles)
                {
                    DataRow row = gvSel.GetDataRow(rowHandle);

                    gvNotSel.AddRow(row);

                    selRows.Add(row);


                }

                foreach (DataRow selRow in selRows)
                {
                    gvSel.DeleteMappingRow(selRow);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}