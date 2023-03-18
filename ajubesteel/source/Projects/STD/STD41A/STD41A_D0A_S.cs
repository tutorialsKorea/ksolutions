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
    public sealed partial class STD41A_D0A_S : BaseMenuDialog
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

        private acGridView _MasterView1 = null;

        private object _MasterData1 = null;

        public object MasterData1
        {
            get { return _MasterData1; }
            set { _MasterData1 = value; }
        }

        private acGridView _MasterView2 = null;

        private object _MasterData2 = null;

        public object MasterData2
        {
            get { return _MasterData2; }
            set { _MasterData2 = value; }
        }




        public STD41A_D0A_S(acGridView masterView1, object masterData1,
            acGridView masterView2, object masterData2,
            acGridView linkView, object linkData)
        {
            InitializeComponent();


            _MasterView1 = masterView1;

            _MasterData1 = masterData1;


            _MasterView2 = masterView2;

            _MasterData2 = masterData2;

            _LinkData = linkData;

            _LinkView = linkView;




            //가용설비

            gvLeft.GridType = acGridView.emGridType.FIXED;

            gvLeft.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvLeft.AddLookUpEdit("MC_GROUP", "기계그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gvLeft.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvLeft.AddCheckEdit("MC_OS", "외부설비", "40974", true, false, false, acGridView.emCheckEditDataType._BYTE);

            gvLeft.OptionsView.ShowIndicator = true;

            gvLeft.KeyColumn = new string[] { "MC_CODE" };


            //표준설비

            gvRight.GridType = acGridView.emGridType.SEARCH;

            gvRight.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            gvRight.AddLookUpEdit("MC_GROUP", "기계그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gvRight.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MC_MODEL", "실모델명", "40400", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddCheckEdit("MC_AUTOMATED", "무인가공", "40973", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddCheckEdit("MC_OS", "외부설비", "40974", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddCheckEdit("MC_MGT_FLAG", "부하 관리대상", "40065", true, false, true, acGridView.emCheckEditDataType._BYTE);

            gvRight.AddDateEdit("MC_OPEN_DATE", "유효시작일", "40477", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvRight.AddDateEdit("MC_CLOSE_DATE", "유효종료일", "40478", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            gvRight.AddTextEdit("MC_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvRight.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);





            gvLeft.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvLeft_ShowGridMenuEx);
            gvLeft.MouseDown += new MouseEventHandler(gvLeft_MouseDown);



            gcLeft.DragDrop += new DragEventHandler(gcLeft_DragDrop);

            gcLeft.DragOver += new DragEventHandler(gcLeft_DragOver);

            gcLeft.DragLeave += new EventHandler(gcLeft_DragLeave);
            gcLeft.GiveFeedback += new GiveFeedbackEventHandler(gcLeft_GiveFeedback);

            gvLeft.MouseMove += new MouseEventHandler(gvLeft_MouseMove);




            gvRight.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(gvRight_ShowGridMenuEx);
            gvRight.MouseDown += new MouseEventHandler(gvRight_MouseDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;


            switch (info.ColumnName)
            {

                case "IS_OS":

                    //외주가능 

                    if (newValue.EqualsEx(1))
                    {
                        layout.GetEditor("WO_DEFAULT_OSMC").isRequired = true;
                    }
                    else
                    {
                        layout.GetEditor("WO_DEFAULT_OSMC").isRequired = false;
                    }

                    break;
            }


        }




        void gvRight_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }


        void gvLeft_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


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



            //가용설비에서 삭제
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    gvLeft.DeleteMappingRow(gvLeft.GetFocusedDataRow());
                }

            }
        }

        void gvRight_MouseDown(object sender, MouseEventArgs e)
        {
            //가용설비에 추가

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
                        gvLeft.UpdateMapingRow(focusRow, true);
                    }

                }

            }
        }



        public override void DialogInit()
        {

            acLayoutControl1.KeyColumns = new string[] { "PROC_CODE" };


            

            //검사여부
            (acLayoutControl1.GetEditor("INS_FLAG") as acLookupEdit).SetCode("S063");


            //회계계정
            (acLayoutControl1.GetEditor("ACT_CODE") as acLookupEdit).SetCode("C600");
                   

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



            //표준설비 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);



            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD41A_SER5", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);


            base.DialogInit();
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                gvRight.GridControl.DataSource = e.result.Tables["RSLTDT"];
                if(gvLeft.RowCount == 0) gvLeft.GridControl.DataSource = e.result.Tables["RSLTDT"].Clone();
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
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


                if (frm.ShowDialog() == DialogResult.No)
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
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("PROC_CODE").FocusEdit();

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

                DataRow masterRow1 = (DataRow)_MasterData1;
                DataRow masterRow2 = (DataRow)_MasterData2;

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //

                paramTable1.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("PROC_NAME", typeof(String)); //
                paramTable1.Columns.Add("MPROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("LPROC_CODE", typeof(String)); //

                paramTable1.Columns.Add("PROC_SEQ", typeof(Int32)); //
                paramTable1.Columns.Add("PROC_COLOR", typeof(String)); //
                paramTable1.Columns.Add("PROC_MAN_TIME", typeof(Single)); //
                paramTable1.Columns.Add("PROC_SELF_TIME", typeof(Single)); //
                paramTable1.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("WO_DEFAULT_OSMC", typeof(String)); //

                paramTable1.Columns.Add("IS_CHECK_PREV_PROC", typeof(Byte));
                paramTable1.Columns.Add("IS_PART_SAME_START", typeof(Byte));
                paramTable1.Columns.Add("IS_CHECK_TOOL", typeof(Byte));


                paramTable1.Columns.Add("MPROC_PROGRESS_RATE", typeof(Decimal));

                paramTable1.Columns.Add("IS_OS", typeof(Byte)); //
                paramTable1.Columns.Add("IS_BOP_PROC", typeof(Byte)); //
                paramTable1.Columns.Add("INS_FLAG", typeof(String)); //


                paramTable1.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable1.Columns.Add("ACT_CODE", typeof(String)); //
                paramTable1.Columns.Add("IF_PROC_CODE", typeof(String)); //

                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow1["PROC_CODE"] = layoutRow["PROC_CODE"];
                paramRow1["PROC_NAME"] = layoutRow["PROC_NAME"];
                paramRow1["MPROC_CODE"] = masterRow2["PRG_CODE"];
                paramRow1["LPROC_CODE"] = masterRow1["PRG_CODE"];

                paramRow1["PROC_SEQ"] = layoutRow["PROC_SEQ"];
                paramRow1["PROC_COLOR"] = layoutRow["PROC_COLOR"];
                paramRow1["PROC_MAN_TIME"] = layoutRow["PROC_MAN_TIME"];
                paramRow1["PROC_SELF_TIME"] = layoutRow["PROC_SELF_TIME"];
                paramRow1["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow1["WO_DEFAULT_OSMC"] = layoutRow["WO_DEFAULT_OSMC"];
                paramRow1["IS_OS"] = layoutRow["IS_OS"];

                paramRow1["IS_CHECK_PREV_PROC"] = layoutRow["IS_CHECK_PREV_PROC"];
                paramRow1["IS_PART_SAME_START"] = layoutRow["IS_PART_SAME_START"];
                paramRow1["IS_CHECK_TOOL"] = layoutRow["IS_CHECK_TOOL"];

                paramRow1["MPROC_PROGRESS_RATE"] = layoutRow["MPROC_PROGRESS_RATE"];

                paramRow1["IS_BOP_PROC"] = layoutRow["IS_BOP_PROC"];
                paramRow1["INS_FLAG"] = layoutRow["INS_FLAG"];

                paramRow1["MAIN_VND"] = layoutRow["MAIN_VND"];
                paramRow1["ACT_CODE"] = layoutRow["ACT_CODE"];
                paramRow1["IF_PROC_CODE"] = layoutRow["IF_PROC_CODE"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "0";
                paramTable1.Rows.Add(paramRow1);



                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_SEQ", typeof(Int32)); //


                DataView availMCData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView mcRowView in availMCData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["MC_CODE"] = mcRowView["MC_CODE"];
                    paramRow2["MC_SEQ"] = mcCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++mcCnt;

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD41A_INS3", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
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
                DataRow focusMasterRow1 = _MasterView1.GetFocusedDataRow();

                DataRow focusMasterRow2 = _MasterView2.GetFocusedDataRow();

                //마스터 그리드뷰의 코드와 현재 코드가 동일하면 Row 업데이트
                if (focusMasterRow1["PRG_CODE"].Equals(((DataRow)_MasterData1)["PRG_CODE"])
                    &&
                    focusMasterRow2["PRG_CODE"].Equals(((DataRow)_MasterData2)["PRG_CODE"])
                    )
                {

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }

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
                DataRow focusMasterRow1 = _MasterView1.GetFocusedDataRow();

                DataRow focusMasterRow2 = _MasterView2.GetFocusedDataRow();

                //마스터 그리드뷰의 코드와 현재 코드가 동일하면 Row 업데이트
                if (focusMasterRow1["PRG_CODE"].Equals(((DataRow)_MasterData1)["PRG_CODE"])
                    &&
                    focusMasterRow2["PRG_CODE"].Equals(((DataRow)_MasterData2)["PRG_CODE"])
                    )
                {

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }

                    this._LinkView.RaiseFocusedRowChanged();
                }

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

                DataRow masterRow1 = (DataRow)_MasterData1;
                DataRow masterRow2 = (DataRow)_MasterData2;

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //

                paramTable1.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("PROC_NAME", typeof(String)); //
                paramTable1.Columns.Add("MPROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("LPROC_CODE", typeof(String)); //

                paramTable1.Columns.Add("PROC_SEQ", typeof(Int32)); //
                paramTable1.Columns.Add("PROC_COLOR", typeof(String)); //
                paramTable1.Columns.Add("PROC_MAN_TIME", typeof(Single)); //
                paramTable1.Columns.Add("PROC_SELF_TIME", typeof(Single)); //
                paramTable1.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable1.Columns.Add("WO_DEFAULT_OSMC", typeof(String)); //

                paramTable1.Columns.Add("IS_CHECK_PREV_PROC", typeof(Byte)); //
                paramTable1.Columns.Add("IS_PART_SAME_START", typeof(Byte)); //
                paramTable1.Columns.Add("IS_CHECK_TOOL", typeof(Byte)); //

                paramTable1.Columns.Add("IS_OS", typeof(Byte)); //

                paramTable1.Columns.Add("IS_BOP_PROC", typeof(Byte)); //


                paramTable1.Columns.Add("MPROC_PROGRESS_RATE", typeof(Decimal));


                paramTable1.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable1.Columns.Add("MAIN_VND", typeof(String)); //

                paramTable1.Columns.Add("ACT_CODE", typeof(String)); //
                paramTable1.Columns.Add("IF_PROC_CODE", typeof(String)); //

                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow1["PROC_CODE"] = layoutRow["PROC_CODE"];
                paramRow1["PROC_NAME"] = layoutRow["PROC_NAME"];
                paramRow1["MPROC_CODE"] = masterRow2["PRG_CODE"];
                paramRow1["LPROC_CODE"] = masterRow1["PRG_CODE"];

                paramRow1["PROC_SEQ"] = layoutRow["PROC_SEQ"];
                paramRow1["PROC_COLOR"] = layoutRow["PROC_COLOR"];
                paramRow1["PROC_MAN_TIME"] = layoutRow["PROC_MAN_TIME"];
                paramRow1["PROC_SELF_TIME"] = layoutRow["PROC_SELF_TIME"];
                paramRow1["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow1["WO_DEFAULT_OSMC"] = layoutRow["WO_DEFAULT_OSMC"];


                paramRow1["IS_BOP_PROC"] = layoutRow["IS_BOP_PROC"];
                paramRow1["INS_FLAG"] = layoutRow["INS_FLAG"];

                paramRow1["IS_CHECK_PREV_PROC"] = layoutRow["IS_CHECK_PREV_PROC"];
                paramRow1["IS_PART_SAME_START"] = layoutRow["IS_PART_SAME_START"];
                paramRow1["IS_CHECK_TOOL"] = layoutRow["IS_CHECK_TOOL"];

                paramRow1["IS_OS"] = layoutRow["IS_OS"];
                paramRow1["MPROC_PROGRESS_RATE"] = layoutRow["MPROC_PROGRESS_RATE"];

                paramRow1["MAIN_VND"] = layoutRow["MAIN_VND"];
                paramRow1["ACT_CODE"] = layoutRow["ACT_CODE"];
                paramRow1["IF_PROC_CODE"] = layoutRow["IF_PROC_CODE"];

                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = "1";
                paramTable1.Rows.Add(paramRow1);



                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("MC_SEQ", typeof(Int32)); //


                DataView availMCData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView mcRowView in availMCData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["MC_CODE"] = mcRowView["MC_CODE"];
                    paramRow2["MC_SEQ"] = mcCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++mcCnt;

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD41A_INS3", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
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

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROC_CODE"] = layoutRow["PROC_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD41A_DEL3", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //가용설비 삭제
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
            //가용설비 추가

            try
            {


                gvRight.EndEditor();

                DataView selectedView = gvRight.GetDataSourceView("SEL = '1'");


                if (selectedView.Count == 0)
                {
                    //단일

                    DataRow focusRow = gvRight.GetFocusedDataRow();

                    DataView availMcView = gvLeft.GetDataSourceView("MC_CODE = '" + focusRow["MC_CODE"].ToString() + "'");

                    //가용설비 목록에 없으면 추가
                    if (availMcView.Count == 0)
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
                        DataView availMcView = gvLeft.GetDataSourceView("MC_CODE = '" + selectedView[i]["MC_CODE"].ToString() + "'");

                        //가용설비 목록에 없으면 추가
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