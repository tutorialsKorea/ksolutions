using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using DevExpress.XtraGrid;
using CodeHelperManager;
using BizManager;

namespace STD
{
    public sealed partial class STD03A_D0A : BaseMenuDialog
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



        public STD03A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();



            _LinkData = linkData;

            _LinkView = linkView;



            acGridView1.GridType = ControlManager.acGridView.emGridType.FIXED;



            acGridView1.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView1.AddTextEdit("PLN_PROC", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PLN_PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddCustomEdit("LOADABLE_MC", "가용설비", "40011", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemLoadableMcEdit());



            acGridView1.AddCustomEdit("PLN_MAN_TIME", "유인 계획공수", "5PODWBO7", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, new RepositoryItemTimeSpinEdit());

            acGridView1.AddCustomEdit("PLN_SELF_TIME", "무인 계획공수", "7MNBO9IX", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, new RepositoryItemTimeSpinEdit());



            acGridView1.OptionsView.ShowIndicator = true;


            (acGridView1.Columns["LOADABLE_MC"].ColumnEdit as RepositoryItemLoadableMcEdit).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(LoadableMc_ButtonClick);



            acGridView1.KeyDown += new KeyEventHandler(acGridView1_KeyDown);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridControl1.DragDrop += new DragEventHandler(acGridControl1_DragDrop);

            acGridControl1.DragOver += new DragEventHandler(acGridControl1_DragOver);

            acGridControl1.DragLeave += new EventHandler(acGridControl1_DragLeave);
            acGridControl1.GiveFeedback += new GiveFeedbackEventHandler(acGridControl1_GiveFeedback);

            acGridView1.MouseMove += new MouseEventHandler(acGridView1_MouseMove);




            acGridView2.GridType = ControlManager.acGridView.emGridType.LIST;

            acGridView2.AddTextEdit("LPROC_NAME", "대일정", "40134", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MPROC_NAME", "중일정", "40632", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);





            acGridView2.Columns["LPROC_NAME"].GroupIndex = 0;
            acGridView2.Columns["MPROC_NAME"].GroupIndex = 1;



            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);


            acGridView2.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(acGridView2_CustomDrawGroupRow);

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {

                case "PART_CODE":
                    {
                        DataRow partData = acPart.GetDataRow(newValue);

                        DataRow codeRow = acInfo.StdCodes.GetCodeRow("S062", partData["SPEC_TYPE"]);


                        acTextEdit spec1Edit = layout.GetEditor("PART_SPEC1").Editor as acTextEdit;

                        if (!codeRow["VALUE"].isNullOrEmpty())
                        {
                            spec1Edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                            spec1Edit.Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                            spec1Edit.Properties.Mask.UseMaskAsDisplayFormat = true;

                        }
                        else
                        {
                            spec1Edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                            spec1Edit.Properties.Mask.EditMask = null;

                        }

                    }

                    break;

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
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

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
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

        void acGridControl1_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        void acGridControl1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }



        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }


        /// <summary>
        /// 마스터 데이터 로우
        /// </summary>
        private DataRow _MasterRow = null;

        public override void DialogOpen()
        {

            //열기


            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            object[] linkData = (object[])_LinkData;

            this._MasterRow = linkData[0] as DataRow;

            acLayoutControl1.DataBind(this._MasterRow, true);

            DataTable plnProcs = linkData[1] as DataTable;

            acGridView1.GridControl.DataSource = plnProcs.Copy();





            base.DialogOpen();
        }

        public override void DialogInitComplete()
        {

            base.DialogInitComplete();
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



            //공정목록

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("LANG", typeof(String)); //언어


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD03A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            acGridView2.ExpandAllGroups();


            base.DialogInit();
        }

        void acGridView1_MouseMove(object sender, MouseEventArgs e)
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

        void acGridControl1_DragOver(object sender, DragEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor(acGridView1.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);

                }
            }
        }

        void acGridControl1_DragDrop(object sender, DragEventArgs e)
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


        private GridHitInfo _MouseDownHitInfo = null;

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
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
                acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
            }

        }

        void acGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Delete)
            {
                acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
            }

        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.InRow && hitInfo.InRowCell)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataTable focusTable = focusRow.NewTable();

                    focusTable.Columns["PROC_CODE"].ColumnName = "PLN_PROC";
                    focusTable.Columns["PROC_NAME"].ColumnName = "PLN_PROC_NAME";
                    focusTable.Columns["PROC_SELF_TIME"].ColumnName = "PLN_SELF_TIME";
                    focusTable.Columns["PROC_MAN_TIME"].ColumnName = "PLN_MAN_TIME";

                    acGridView1.AddRow(focusTable.Rows[0]);

                }

            }
        }




        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE || ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT_M"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == 200079)
            {

                if (acMessageBox.Show(this, acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {

                    foreach (DataRow row in QBiz.RefData.Tables["RQSTDT_M"].Rows)
                    {
                        row["PLN_CODE"] = ex.ParameterDic["PLN_CODE"];
                        row["OVERWRITE"] = "1";
                    }
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);


            }
        }

        void LoadableMc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            acLoadableMcEdit edit = sender as acLoadableMcEdit;

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            edit.ProcCode = focusRow["PLN_PROC"];

        }


        void acGridView2_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            acLayoutControl1.ClearValue();

            acLayoutControl1.GetEditor("PART_CODE").FocusEdit();

            acGridView1.ClearRow();



        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

                acGridView1.EndEditor();


                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }



                DataView procs = acGridView1.GetDataSourceView();

                if (procs.Count == 0)
                {
                    acMessageBox.Show(this, "공정계획순서가 존재해야 저장할수 있습니다.", "OOZIOH9Z", true, acMessageBox.emMessageBoxType.CONFIRM);

                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable1 = new DataTable("RQSTDT_M");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PLN_CODE", typeof(String)); //
                paramTable1.Columns.Add("PART_CODE", typeof(String)); //
                paramTable1.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable1.Columns.Add("PART_SPEC1", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PLN_CODE"] = null;
                paramRow1["PART_CODE"] = layoutRow["PART_CODE"];
                paramRow1["MQLTY_CODE"] = layoutRow["MQLTY_CODE"];
                paramRow1["PART_SPEC1"] = layoutRow["PART_SPEC1"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "0";
                paramTable1.Rows.Add(paramRow1);



                DataTable paramTable2 = new DataTable("RQSTDT_D");
                paramTable2.Columns.Add("PLN_PROC", typeof(String)); //
                paramTable2.Columns.Add("LOADABLE_MC", typeof(String)); //
                paramTable2.Columns.Add("PLN_SEQ", typeof(Int32)); //
                paramTable2.Columns.Add("PLN_SELF_TIME", typeof(Decimal)); //무인 계획시간
                paramTable2.Columns.Add("PLN_MAN_TIME", typeof(Decimal)); //유인 계획시간

                int seq = 1;

                foreach (DataRowView rv in procs)
                {

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLN_PROC"] = rv["PLN_PROC"];
                    paramRow2["LOADABLE_MC"] = rv["LOADABLE_MC"];
                    paramRow2["PLN_SEQ"] = seq;
                    paramRow2["PLN_SELF_TIME"] = rv["PLN_SELF_TIME"];
                    paramRow2["PLN_MAN_TIME"] = rv["PLN_MAN_TIME"];
                    paramTable2.Rows.Add(paramRow2);

                    ++seq;

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD03A_INS", paramSet, "RQSTDT_M,RQSTDT_D", "RSLTDT",
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
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                //덮어쓰기면 재갱신
                if (e.result.Tables["RQSTDT_M"].Rows[0]["OVERWRITE"].Equals("1"))
                {
                    this._LinkView.RaiseFocusedRowChanged();
                }
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

                acGridView1.EndEditor();


                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataView procs = acGridView1.GetDataSourceView();

                if (procs.Count == 0)
                {
                    acMessageBox.Show(this, "공정계획순서가 존재해야 저장할수 있습니다.", "OOZIOH9Z", true, acMessageBox.emMessageBoxType.CONFIRM);

                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();



                DataTable paramTable1 = new DataTable("RQSTDT_M");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PLN_CODE", typeof(String)); //
                paramTable1.Columns.Add("PART_CODE", typeof(String)); //
                paramTable1.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable1.Columns.Add("PART_SPEC1", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PLN_CODE"] = this._MasterRow["PLN_CODE"];
                paramRow1["PART_CODE"] = layoutRow["PART_CODE"];
                paramRow1["MQLTY_CODE"] = layoutRow["MQLTY_CODE"];
                paramRow1["PART_SPEC1"] = layoutRow["PART_SPEC1"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "1";
                paramTable1.Rows.Add(paramRow1);



                DataTable paramTable2 = new DataTable("RQSTDT_D");
                paramTable2.Columns.Add("PLN_PROC", typeof(String)); //
                paramTable2.Columns.Add("LOADABLE_MC", typeof(String)); //
                paramTable2.Columns.Add("PLN_SEQ", typeof(Int32)); //
                paramTable2.Columns.Add("PLN_SELF_TIME", typeof(Decimal)); //무인 계획시간
                paramTable2.Columns.Add("PLN_MAN_TIME", typeof(Decimal)); //유인 계획시간

                int seq = 1;

                foreach (DataRowView rv in procs)
                {

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLN_PROC"] = rv["PLN_PROC"];
                    paramRow2["LOADABLE_MC"] = rv["LOADABLE_MC"];
                    paramRow2["PLN_SEQ"] = seq;
                    paramRow2["PLN_SELF_TIME"] = rv["PLN_SELF_TIME"];
                    paramRow2["PLN_MAN_TIME"] = rv["PLN_MAN_TIME"];
                    paramTable2.Rows.Add(paramRow2);

                    ++seq;

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD03A_INS", paramSet, "RQSTDT_M,RQSTDT_D", "RSLTDT",
                QuickSaveClose,
                QuickException);

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

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PLN_CODE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLN_CODE"] = this._MasterRow["PLN_CODE"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD03A_DEL", paramSet, "RQSTDT", "",
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
            //고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공정 삭제
            try
            {
                acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공정 추가
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                DataTable focusTable = focusRow.NewTable();

                focusTable.Columns["PROC_CODE"].ColumnName = "PLN_PROC";
                focusTable.Columns["PROC_NAME"].ColumnName = "PLN_PROC_NAME";
                focusTable.Columns["PROC_SELF_TIME"].ColumnName = "PLN_SELF_TIME";
                focusTable.Columns["PROC_MAN_TIME"].ColumnName = "PLN_MAN_TIME";

                acGridView1.AddRow(focusTable.Rows[0]);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

    }
}