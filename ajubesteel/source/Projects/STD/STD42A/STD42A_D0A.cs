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
    public sealed partial class STD42A_D0A : BaseMenuDialog
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



        public STD42A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();



            _LinkData = linkData;

            _LinkView = linkView;



            //가용설비


            gvLeft.GridType = acGridView.emGridType.FIXED;

            gvLeft.OptionsView.ShowIndicator = true;

            gvLeft.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvLeft.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.KeyColumn = new string[] { "MC_CODE" };


            //표준설비

            gvRight.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvRight.AddLookUpEdit("MC_GROUP", "기계그룹", "40308", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gvRight.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true , false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddCheckEdit("MC_OS", "외부설비", "40974", true , false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true , false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvRight.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvRight.AddTextEdit("MC_SEQ", "표시순서", "40723", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.KeyColumn = new string[] { "MC_CODE" };



            //gvLeft.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvLeft_ShowGridMenuEx);
            //gvRight.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvRight_ShowGridMenuEx);

            gvLeft.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvLeft_ShowGridMenuEx);
            gvRight.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvRight_ShowGridMenuEx);

            gvLeft.MouseDown += new MouseEventHandler(gvLeft_MouseDown);


            gvLeft.KeyDown += new KeyEventHandler(gvLeft_KeyDown);


            gcLeft.DragDrop += new DragEventHandler(gcLeft_DragDrop);
            gcLeft.DragLeave += new EventHandler(gcLeft_DragLeave);
            gcLeft.DragOver += new DragEventHandler(gcLeft_DragOver);

            gcLeft.GiveFeedback += new GiveFeedbackEventHandler(gcLeft_GiveFeedback);

            gvLeft.MouseMove += new MouseEventHandler(gvLeft_MouseMove);

            gvRight.MouseDown += new MouseEventHandler(gvRight_MouseDown);


        }
        
        

        //void gvRight_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (e.HitInfo.RowHandle >= 0 &&
        //        (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //        )
        //    {
        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        if (hitInfo.InColumn == false)
        //        {
        //            popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
        //        }

        //    }
        //}

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


        //void gvLeft_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;

        //    if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {
        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        if (hitInfo.InColumn == false)
        //        {
        //            popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
        //        }

        //    }
        //}

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

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = gvRight.GetFocusedDataRow();

                    DataView availMcView = gvLeft.GetDataSourceView("MC_CODE = '" + focusRow["MC_CODE"].ToString() + "'");

                    //가용설비 목록에 없으면 추가
                    if (availMcView.Count == 0)
                    {
                        gvLeft.AddRow(focusRow);
                    }


                }

            }
        }

        public override void DialogInit()
        {



            acLayoutControl1.KeyColumns = new string[] { "PANEL_CODE" };



            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;





            //표준설비 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD42A_SER3", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);

            


            base.DialogInit();
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            gvRight.GridControl.DataSource = e.result.Tables["RSLTDT"];
        }


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber),string.Empty,false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);


            }
        }



        public override void DialogNew()
        {
            //새로만들기



            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기


            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = this._LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);


            //단말기 설비 불러옴


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PANEL_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PANEL_CODE"] = linkRow["PANEL_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "STD42A_SER2", paramSet, "RQSTDT", "RSLTDT",
                    QuickDetail,
                    QuickException);

            


            base.DialogOpen();
        }

        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                gvLeft.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("PANEL_CODE").FocusEdit();

                gvLeft.ClearRow();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable1.Columns.Add("PANEL_NAME", typeof(String)); //
                paramTable1.Columns.Add("MAC_ADDR", typeof(String)); //
                paramTable1.Columns.Add("IS_ACCESS", typeof(Byte)); //
                paramTable1.Columns.Add("PANEL_SEQ", typeof(Int32)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PANEL_CODE"] = null;
                paramRow1["PANEL_NAME"] = layoutRow["PANEL_NAME"];
                paramRow1["MAC_ADDR"] = layoutRow["MAC_ADDR"];
                paramRow1["IS_ACCESS"] = layoutRow["IS_ACCESS"];
                paramRow1["PANEL_SEQ"] = layoutRow["PANEL_SEQ"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "0";
                paramTable1.Rows.Add(paramRow1);


                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_SEQ", typeof(Int32)); //


                DataView availMCData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView mcRowView in availMCData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["MC_CODE"] = mcRowView["MC_CODE"];
                    paramRow2["MC_SEQ"] = mcCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++mcCnt;

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                "STD42A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            //덮어쓰기면 재갱신


            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this._LinkView.RaiseFocusedRowChanged();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable1.Columns.Add("PANEL_NAME", typeof(String)); //
                paramTable1.Columns.Add("MAC_ADDR", typeof(String)); //
                paramTable1.Columns.Add("IS_ACCESS", typeof(Byte)); //
                paramTable1.Columns.Add("PANEL_SEQ", typeof(Int32)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PANEL_CODE"] = linkRow["PANEL_CODE"];
                paramRow1["PANEL_NAME"] = layoutRow["PANEL_NAME"];
                paramRow1["MAC_ADDR"] = layoutRow["MAC_ADDR"];
                paramRow1["IS_ACCESS"] = layoutRow["IS_ACCESS"];
                paramRow1["PANEL_SEQ"] = layoutRow["PANEL_SEQ"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "1";

                paramTable1.Rows.Add(paramRow1);


                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_SEQ", typeof(Int32)); //


                DataView availMCData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView mcRowView in availMCData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["MC_CODE"] = mcRowView["MC_CODE"];
                    paramRow2["MC_SEQ"] = mcCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++mcCnt;

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "STD42A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PANEL_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PANEL_CODE"] = linkRow["PANEL_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD42A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //단말기 설비 추가
            try
            {
                gvRight.EndEditor();

                DataView selectedView = gvRight.GetDataSourceView("SEL = '1'");


                if (selectedView.Count == 0)
                {
                    //단일

                    DataRow focusRow = gvRight.GetFocusedDataRow();

                    DataView mcView = gvLeft.GetDataSourceView("MC_CODE = '" + focusRow["MC_CODE"].ToString() + "'");

                    //설비가에 없으면 추가
                    if (mcView.Count == 0)
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
                        DataView mcView = gvLeft.GetDataSourceView("MC_CODE = '" + selectedView[i]["MC_CODE"].ToString() + "'");

                        //설비가에 없으면 추가
                        if (mcView.Count == 0)
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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //단말기 설비 삭제
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


    }
}