using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

namespace ORD
{
    public sealed partial class ORD26A_D0A : BaseMenuDialog
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



        public ORD26A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            //재료비
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WEIGHT_VOLUME", "소재중량", "40629", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.WEIGHT);

            acGridView1.AddTextEdit("PART_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("UNIT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("MAT_COST", "금액", "40084", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView1.AddHidden("SEQ", typeof(int));

            acGridView1.KeyColumn = new string[] { "SEQ" };

            acGridView1.OptionsView.ShowFooter = true;

            acGridView1.Columns["MAT_COST"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView1.Columns["MAT_COST"].DisplayFormat.FormatString);


            //가공비

            acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_TIME", "공수", "7A7ETV8Y", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView2.AddTextEdit("PROC_COST", "가공비", "HZKNBQA3", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView2.AddHidden("SEQ", typeof(int));

            acGridView2.KeyColumn = new string[] { "SEQ" };

            acGridView2.OptionsView.ShowFooter = true;


            acGridView2.Columns["PROC_COST"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView2.Columns["PROC_COST"].DisplayFormat.FormatString);


            //기타항목

            acGridView3.AddLookUpEdit("ELSE_CODE", "항목", "41224", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C302");

            acGridView3.AddTextEdit("ELSE_COST", "비용", "P8L1KW66", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView3.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView3.AddHidden("SEQ", typeof(int));

            acGridView3.KeyColumn = new string[] { "SEQ" };

            acGridView3.OptionsView.ShowFooter = true;

            acGridView3.Columns["ELSE_COST"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView3.Columns["ELSE_COST"].DisplayFormat.FormatString);


            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);


            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);

            acGridView3.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView3_ShowGridMenuEx);
            acGridView3.MouseDown += new MouseEventHandler(acGridView3_MouseDown);
            acGridView3.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView3_OnMapingRowChanged);



            acGridControl1.DragDrop += new DragEventHandler(acGridControl1_DragDrop);

            acGridControl1.DragOver += new DragEventHandler(acGridControl1_DragOver);

            acGridControl1.DragLeave += new EventHandler(acGridControl1_DragLeave);

            acGridView1.MouseMove += new MouseEventHandler(acGridView1_MouseMove);

            acGridControl1.GiveFeedback += new GiveFeedbackEventHandler(acGridControl1_GiveFeedback);



            acGridControl2.DragDrop += new DragEventHandler(acGridControl2_DragDrop);

            acGridControl2.DragOver += new DragEventHandler(acGridControl2_DragOver);

            acGridControl2.DragLeave += new EventHandler(acGridControl2_DragLeave);

            acGridView2.MouseMove += new MouseEventHandler(acGridView2_MouseMove);

            acGridControl2.GiveFeedback += new GiveFeedbackEventHandler(acGridControl2_GiveFeedback);


            acGridControl3.DragDrop += new DragEventHandler(acGridControl2_DragDrop);

            acGridControl3.DragOver += new DragEventHandler(acGridControl2_DragOver);

            acGridControl3.DragLeave += new EventHandler(acGridControl2_DragLeave);

            acGridView3.MouseMove += new MouseEventHandler(acGridView2_MouseMove);

            acGridControl3.GiveFeedback += new GiveFeedbackEventHandler(acGridControl2_GiveFeedback);




            _LinkData = linkData;

            _LinkView = linkView;
        }


        public override void DialogInit()
        {



            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;






            base.DialogInit();


        }

        void acGridControl1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
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

        void acGridControl1_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        void acGridControl1_DragOver(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;

            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor((grid.MainView as acGridView).GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
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


        void acGridControl2_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        void acGridView2_MouseMove(object sender, MouseEventArgs e)
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

        void acGridControl2_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private GridHitInfo _MouseDownHitInfo = null;

        void acGridControl2_DragOver(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;

            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor((grid.MainView as acGridView).GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                }

            }
        }

        void acGridControl2_DragDrop(object sender, DragEventArgs e)
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


        void acGridControl3_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        void acGridView3_MouseMove(object sender, MouseEventArgs e)
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

        void acGridControl3_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        void acGridControl3_DragOver(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;

            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor((grid.MainView as acGridView).GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                }

            }
        }

        void acGridControl3_DragDrop(object sender, DragEventArgs e)
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

        /// <summary>
        /// 견적 총비용을 계산한다.
        /// </summary>
        void CalcTotalMoney()
        {
            acLayoutControl1.GetEditor("EST_AMT").Value = acGridView1.GetDataSum("MAT_COST") + acGridView2.GetDataSum("PROC_COST") + acGridView3.GetDataSum("ELSE_COST");

        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            this.CalcTotalMoney();

        }
        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            this.CalcTotalMoney();

        }

        void acGridView3_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            this.CalcTotalMoney();
        }


        void acGridView3_MouseDown(object sender, MouseEventArgs e)
        {

            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);


            if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _MouseDownHitInfo = hitInfo;
                }
            }




            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //가공비 편집기 열기

                    this.acBarButtonItem8_ItemClick(null, null);
                }


            }



        }

        void acGridView3_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //가공비 편집기 메뉴

            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

        }


        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);


            if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _MouseDownHitInfo = hitInfo;
                }
            }




            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //가공비 편집기 열기

                    this.acBarButtonItem5_ItemClick(null, null);
                }


            }


        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //가공비 편집기 메뉴

            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);


            if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _MouseDownHitInfo = hitInfo;
                }
            }




            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //재료비 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }


            }



        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //재료비 편집기 메뉴

            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }

        }


        public override void DialogNew()
        {
            //새로만들기

            acLayoutControl1.GetEditor("EST_DATE").Value = DateTime.Now;


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


        }

        public override void DialogOpen()
        {
            //열기

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            DataRow linkRow = (DataRow)_LinkData;

            acLayoutControl1.DataBind(linkRow, true);


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EST_NO", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EST_NO"] = linkRow["EST_NO"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ORD26A_SER2", paramSet, "RQSTDT", "PART,PROC,ELSE");

            acGridView1.GridControl.DataSource = resultSet.Tables["PART"];
            acGridView2.GridControl.DataSource = resultSet.Tables["PROC"];
            acGridView3.GridControl.DataSource = resultSet.Tables["ELSE"];


        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acGridView1.ClearRow();
                acGridView2.ClearRow();
                acGridView3.ClearRow();

                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("EST_DATE").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장하기
            try
            {


                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();
                acGridView2.EndEditor();
                acGridView3.EndEditor();


                //기본정보
                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("EST_NO", typeof(String)); //
                paramTable1.Columns.Add("EST_DATE", typeof(String)); //
                paramTable1.Columns.Add("EST_NAME", typeof(String)); //
                paramTable1.Columns.Add("CVND_CODE", typeof(String)); //
                paramTable1.Columns.Add("EST_AMT", typeof(Decimal)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //



                //재료비 항목
                DataTable paramTable2 = new DataTable("PART");
                paramTable2.Columns.Add("PART_CODE", typeof(String)); //
                paramTable2.Columns.Add("PART_NUM", typeof(String)); //
                paramTable2.Columns.Add("PART_QLTY", typeof(String)); //
                paramTable2.Columns.Add("PART_SPEC", typeof(String)); //
                paramTable2.Columns.Add("PART_QTY", typeof(Int32)); //
                paramTable2.Columns.Add("WEIGHT_VOLUME", typeof(Decimal)); //
                paramTable2.Columns.Add("UNIT_COST", typeof(Decimal)); //
                paramTable2.Columns.Add("MAT_COST", typeof(Decimal)); //
                paramTable2.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable2.Columns.Add("SEQ", typeof(Int32)); //


                //가공비 항목
                DataTable paramTable3 = new DataTable("PROC");
                paramTable3.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable3.Columns.Add("PROC_TIME", typeof(Single)); //
                paramTable3.Columns.Add("PROC_COST", typeof(Decimal)); //
                paramTable3.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable3.Columns.Add("SEQ", typeof(Int32)); //


                //기타비용 항목 
                DataTable paramTable4 = new DataTable("ELSE");
                paramTable4.Columns.Add("ELSE_CODE", typeof(String)); //
                paramTable4.Columns.Add("ELSE_COST", typeof(Decimal)); //
                paramTable4.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable4.Columns.Add("SEQ", typeof(Int32)); //



                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //견적정보 마스터
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["EST_NO"] = null;
                paramRow1["EST_DATE"] = layoutRow["EST_DATE"];
                paramRow1["EST_NAME"] = layoutRow["EST_NAME"];
                paramRow1["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow1["EST_AMT"] = layoutRow["EST_AMT"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramTable1.Rows.Add(paramRow1);


                //재료비 항목 데이터 넣기

                int partSeqCnt = 0;

                foreach (DataRow row in acGridView1.CopyNewTable().Rows)
                {

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PART_CODE"] = row["PART_CODE"];
                    paramRow2["PART_NUM"] = row["PART_NUM"];
                    paramRow2["PART_QLTY"] = row["PART_QLTY"];
                    paramRow2["PART_SPEC"] = row["PART_SPEC"];
                    paramRow2["PART_QTY"] = row["PART_QTY"];
                    paramRow2["WEIGHT_VOLUME"] = row["WEIGHT_VOLUME"];
                    paramRow2["UNIT_COST"] = row["UNIT_COST"];
                    paramRow2["MAT_COST"] = row["MAT_COST"];
                    paramRow2["SCOMMENT"] = row["SCOMMENT"];
                    paramRow2["SEQ"] = partSeqCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++partSeqCnt;

                }


                //가공비 항목 데이터 넣기

                int procSeqCnt = 0;

                foreach (DataRow row in acGridView2.CopyNewTable().Rows)
                {

                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["PROC_CODE"] = row["PROC_CODE"];
                    paramRow3["PROC_TIME"] = row["PROC_TIME"];
                    paramRow3["PROC_COST"] = row["PROC_COST"];
                    paramRow3["SCOMMENT"] = row["SCOMMENT"];
                    paramRow3["SEQ"] = procSeqCnt;
                    paramTable3.Rows.Add(paramRow3);

                    ++procSeqCnt;
                }


                //기타항목 데이터 넣기

                int elseSeqCnt = 0;

                foreach (DataRow row in acGridView3.CopyNewTable().Rows)
                {
                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["ELSE_CODE"] = row["ELSE_CODE"];
                    paramRow4["ELSE_COST"] = row["ELSE_COST"];
                    paramRow4["SCOMMENT"] = row["SCOMMENT"];
                    paramRow4["SEQ"] = elseSeqCnt;
                    paramTable4.Rows.Add(paramRow4);

                    ++elseSeqCnt;
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);
                paramSet.Tables.Add(paramTable3);
                paramSet.Tables.Add(paramTable4);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "ORD26A_INS", paramSet, "RQSTDT,PART,PROC,ELSE", "RSLTDT",
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

                acGridView1.EndEditor();
                acGridView2.EndEditor();
                acGridView3.EndEditor();


                //기본정보
                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("EST_NO", typeof(String)); //
                paramTable1.Columns.Add("EST_DATE", typeof(String)); //
                paramTable1.Columns.Add("EST_NAME", typeof(String)); //
                paramTable1.Columns.Add("CVND_CODE", typeof(String)); //
                paramTable1.Columns.Add("EST_AMT", typeof(Decimal)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //



                //재료비 항목
                DataTable paramTable2 = new DataTable("PART");
                paramTable2.Columns.Add("PART_CODE", typeof(String)); //
                paramTable2.Columns.Add("PART_NUM", typeof(String)); //
                paramTable2.Columns.Add("PART_QLTY", typeof(String)); //
                paramTable2.Columns.Add("PART_SPEC", typeof(String)); //
                paramTable2.Columns.Add("PART_QTY", typeof(Int32)); //
                paramTable2.Columns.Add("WEIGHT_VOLUME", typeof(Decimal)); //
                paramTable2.Columns.Add("UNIT_COST", typeof(Decimal)); //
                paramTable2.Columns.Add("MAT_COST", typeof(Decimal)); //
                paramTable2.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable2.Columns.Add("SEQ", typeof(Int32)); //


                //가공비 항목
                DataTable paramTable3 = new DataTable("PROC");
                paramTable3.Columns.Add("PROC_CODE", typeof(String)); //
                paramTable3.Columns.Add("PROC_TIME", typeof(Single)); //
                paramTable3.Columns.Add("PROC_COST", typeof(Decimal)); //
                paramTable3.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable3.Columns.Add("SEQ", typeof(Int32)); //


                //기타비용 항목 
                DataTable paramTable4 = new DataTable("ELSE");
                paramTable4.Columns.Add("ELSE_CODE", typeof(String)); //
                paramTable4.Columns.Add("ELSE_COST", typeof(Decimal)); //
                paramTable4.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable4.Columns.Add("SEQ", typeof(Int32)); //



                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                //견적정보 마스터
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["EST_NO"] = linkRow["EST_NO"];
                paramRow1["EST_DATE"] = layoutRow["EST_DATE"];
                paramRow1["EST_NAME"] = layoutRow["EST_NAME"];
                paramRow1["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow1["EST_AMT"] = layoutRow["EST_AMT"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramTable1.Rows.Add(paramRow1);


                //재료비 항목 데이터 넣기

                int partSeqCnt = 0;

                foreach (DataRow row in acGridView1.CopyNewTable().Rows)
                {

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PART_CODE"] = row["PART_CODE"];
                    paramRow2["PART_NUM"] = row["PART_NUM"];
                    paramRow2["PART_QLTY"] = row["PART_QLTY"];
                    paramRow2["PART_SPEC"] = row["PART_SPEC"];
                    paramRow2["PART_QTY"] = row["PART_QTY"];
                    paramRow2["WEIGHT_VOLUME"] = row["WEIGHT_VOLUME"];
                    paramRow2["UNIT_COST"] = row["UNIT_COST"];
                    paramRow2["MAT_COST"] = row["MAT_COST"];
                    paramRow2["SCOMMENT"] = row["SCOMMENT"];
                    paramRow2["SEQ"] = partSeqCnt;
                    paramTable2.Rows.Add(paramRow2);

                    ++partSeqCnt;

                }


                //가공비 항목 데이터 넣기

                int procSeqCnt = 0;

                foreach (DataRow row in acGridView2.CopyNewTable().Rows)
                {

                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["PROC_CODE"] = row["PROC_CODE"];
                    paramRow3["PROC_TIME"] = row["PROC_TIME"];
                    paramRow3["PROC_COST"] = row["PROC_COST"];
                    paramRow3["SCOMMENT"] = row["SCOMMENT"];
                    paramRow3["SEQ"] = procSeqCnt;
                    paramTable3.Rows.Add(paramRow3);

                    ++procSeqCnt;
                }


                //기타항목 데이터 넣기

                int elseSeqCnt = 0;

                foreach (DataRow row in acGridView3.CopyNewTable().Rows)
                {
                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["ELSE_CODE"] = row["ELSE_CODE"];
                    paramRow4["ELSE_COST"] = row["ELSE_COST"];
                    paramRow4["SCOMMENT"] = row["SCOMMENT"];
                    paramRow4["SEQ"] = elseSeqCnt;
                    paramTable4.Rows.Add(paramRow4);

                    ++elseSeqCnt;
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);
                paramSet.Tables.Add(paramTable3);
                paramSet.Tables.Add(paramTable4);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "ORD26A_INS", paramSet, "RQSTDT,PART,PROC,ELSE", "RSLTDT",
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


                _LinkView.RaiseFocusedRowChanged();


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


                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EST_NO", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EST_NO"] = linkRow["EST_NO"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD26A_DEL", paramSet, "RQSTDT", "",
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


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {


            acMessageBox.Show(this, ex);

        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 재료비
            try
            {
                ORD26A_D1A frm = new ORD26A_D1A(acGridView1, "NEW");

                frm.DialogMode = emDialogMode.NEW;

                frm.ParentControl = this;

                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 재료비
            try
            {
                ORD26A_D1A frm = new ORD26A_D1A(acGridView1, acGridView1.GetFocusedDataRow());

                frm.DialogMode = emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 재료비
            try
            {
                acGridView1.DeleteMappingRow(acGridView1.GetFocusedDataRow());
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 가공비
            try
            {
                ORD26A_D2A frm = new ORD26A_D2A(acGridView2, "NEW");

                frm.DialogMode = emDialogMode.NEW;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 가공비
            try
            {
                ORD26A_D2A frm = new ORD26A_D2A(acGridView2, acGridView2.GetFocusedDataRow());

                frm.DialogMode = emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 가공비
            try
            {
                acGridView2.DeleteMappingRow(acGridView2.GetFocusedDataRow());
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 기타비용 편집기
            try
            {
                ORD26A_D3A frm = new ORD26A_D3A(acGridView3, "NEW");

                frm.DialogMode = emDialogMode.NEW;

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 기타비용 편집기
            try
            {
                ORD26A_D3A frm = new ORD26A_D3A(acGridView3, acGridView3.GetFocusedDataRow());

                frm.DialogMode = emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 기타비용

            acGridView3.DeleteMappingRow(acGridView3.GetFocusedDataRow());
        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //금형원가 참조 견적생성
            try
            {
                ORD26A_D4A frm = new ORD26A_D4A();

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    acGridView1.ClearRow();
                    acGridView2.ClearRow();


                    DataSet data = frm.OutputData as DataSet;


                    DataTable matCostDt = acGridView1.NewTable();


                    //재료비 매칭

                    foreach (DataRow row in data.Tables["MAT_COST"].Rows)
                    {
                        DataRow newRow = matCostDt.NewRow();

                        newRow["PART_CODE"] = row["PART_CODE"];
                        newRow["PART_NAME"] = row["PART_NAME"];
                        newRow["PART_NUM"] = row["PART_NUM"];
                        newRow["PART_QLTY"] = row["PART_QLTY"];
                        newRow["PART_QLTY_NAME"] = row["PART_QLTY_NAME"];
                        newRow["WEIGHT_VOLUME"] = row["WEIGHT_VOLUME"];
                        newRow["PART_SPEC"] = row["PART_SPEC"];
                        newRow["UNIT_COST"] = row["UNIT_COST"];
                        newRow["PART_QTY"] = row["PART_QTY"];
                        newRow["MAT_COST"] = row["MAT_COST"];
                        newRow["SCOMMENT"] = DBNull.Value;

                        matCostDt.Rows.Add(newRow);


                    }


                    //가공비 매칭

                    DataTable procCostDt = acGridView2.NewTable();


                    foreach (DataRow row in data.Tables["PROC_COST"].Rows)
                    {
                        DataRow newRow = procCostDt.NewRow();

                        newRow["PROC_CODE"] = row["PROC_CODE"];
                        newRow["PROC_NAME"] = row["PROC_NAME"];
                        newRow["PROC_TIME"] = row["PROC_TIME"];
                        newRow["PROC_COST"] = row["PROC_COST"];
                        newRow["SCOMMENT"] = DBNull.Value;

                        procCostDt.Rows.Add(newRow);


                    }


                    acGridView1.GridControl.DataSource = matCostDt;

                    acGridView2.GridControl.DataSource = procCostDt;

                    this.CalcTotalMoney();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

    }
}