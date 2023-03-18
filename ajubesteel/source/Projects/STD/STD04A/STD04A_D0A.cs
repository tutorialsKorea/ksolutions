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
    public sealed partial class STD04A_D0A : BaseMenuDialog
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




        public STD04A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();




            _LinkView = linkView;

            _LinkData = linkData;



            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddTextEdit("MON_TIME", "월", "40985", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("TUE_TIME", "화", "40986", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("WED_TIME", "수", "40987", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("THR_TIME", "목", "40988", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("FRI_TIME", "금", "40989", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("SAT_TIME", "토", "40990", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("SUN_TIME", "일", "40991", true, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);


            DataRow mcShiftRow = acGridView1.NewRow();

            mcShiftRow["MON_TIME"] = 0;
            mcShiftRow["TUE_TIME"] = 0;
            mcShiftRow["WED_TIME"] = 0;
            mcShiftRow["THR_TIME"] = 0;
            mcShiftRow["MON_TIME"] = 0;
            mcShiftRow["FRI_TIME"] = 0;
            mcShiftRow["SAT_TIME"] = 0;
            mcShiftRow["SUN_TIME"] = 0;

            acGridView1.AddRow(mcShiftRow);


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

        void gvRight_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);
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


        //void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        //{
        //    acLayoutControl layout = sender as acLayoutControl;

        //    switch (info.ColumnName)
        //    {

        //        case "IS_SIGNAL":

        //            if (newValue.Equals((byte)1))
        //            {
        //                layout.GetEditor("SIGNAL_TYPE").isRequired = true;
        //                layout.GetEditor("PLC_IP").isRequired = true;
        //                layout.GetEditor("PLC_PORT").isRequired = true;

        //            }
        //            else
        //            {
        //                layout.GetEditor("SIGNAL_TYPE").isRequired = false;
        //                layout.GetEditor("PLC_IP").isRequired = false;
        //                layout.GetEditor("PLC_PORT").isRequired = false;
        //            }

        //            break;

        //    }



        //}




        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.KeyColumns = new string[] { "MC_CODE" };



            (acLayoutControl1.GetEditor("MC_GROUP").Editor as acLookupEdit).SetCode("C020");

            //(acLayoutControl1.GetEditor("SIGNAL_TYPE").Editor as acLookupEdit).SetCode("C022");

            dtpValidate1.DateTime = acDateEdit.GetNowFirstYear();
            dtpValidate2.DateTime = new DateTime(DateTime.Now.Year + 100, 12, 31, 0, 0, 0, 0);
          


            base.DialogInit();
        }

        public override void DialogInitComplete()
        {



            base.DialogInitComplete();
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


        public override void DialogNew()
        {
            //새로 만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            
            ///모든 사원 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

            gvRight.GridControl.DataSource = resultSet.Tables["RSLTDT"];



            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기


            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;

            {
                //가용인원 불러오기
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
         
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = linkRow["MC_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER2", paramSet, "RQSTDT", "RSLTDT");

                gvLeft.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            }

            {
                ///모든 사원 불러오기
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

                gvRight.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            }

            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = linkRow["PLT_CODE"];
                paramRow["MC_CODE"] = linkRow["MC_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD04A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            }

            acLayoutControl1.DataBind(linkRow, true);
            base.DialogOpen();

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

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false,false, true, false);


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



        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //클리어
            try
            {
                acLayoutControl1.ClearValue();
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

                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_NAME", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //

                paramTable.Columns.Add("MC_AUTOMATED", typeof(Byte)); //
                paramTable.Columns.Add("MC_OS", typeof(Byte)); //
                paramTable.Columns.Add("MC_SHIFT", typeof(Byte)); //
                paramTable.Columns.Add("MC_MGT_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("IS_SIGNAL", typeof(Byte)); //

                paramTable.Columns.Add("IS_OPERATE_STATE", typeof(Byte)); //

                paramTable.Columns.Add("MC_OPEN_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_CLOSE_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_MODEL", typeof(String)); //

                paramTable.Columns.Add("MC_MAKER", typeof(String)); //
                paramTable.Columns.Add("ASSET_NO", typeof(String)); //
                paramTable.Columns.Add("AS_TEL", typeof(String)); //

                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE2", typeof(String)); //
                paramTable.Columns.Add("MC_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("MAIN_EMP", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                //paramTable.Columns.Add("MC_IP", typeof(String)); //
                //paramTable.Columns.Add("PLC_IP", typeof(String)); //
                //paramTable.Columns.Add("PLC_PORT", typeof(String)); //          
                //paramTable.Columns.Add("FTP_PORT", typeof(String)); //
                //paramTable.Columns.Add("FTP_DIR", typeof(String)); //
                //paramTable.Columns.Add("FTP_USER", typeof(String)); //
                //paramTable.Columns.Add("FTP_USER_PW", typeof(String)); //

                paramTable.Columns.Add("IS_MULTI_START", typeof(Byte)); //
                paramTable.Columns.Add("MULTI_START_DIV", typeof(Byte)); //

                //paramTable.Columns.Add("SIGNAL_TYPE", typeof(String)); //
                //paramTable.Columns.Add("IF_MC_CODE", typeof(String)); //

                paramTable.Columns.Add("MON_TIME", typeof(Single)); //
                paramTable.Columns.Add("TUE_TIME", typeof(Single)); //
                paramTable.Columns.Add("WED_TIME", typeof(Single)); //
                paramTable.Columns.Add("THR_TIME", typeof(Single)); //
                paramTable.Columns.Add("FRI_TIME", typeof(Single)); //
                paramTable.Columns.Add("SAT_TIME", typeof(Single)); //
                paramTable.Columns.Add("SUN_TIME", typeof(Single)); //

                paramTable.Columns.Add("OPT_CAPA_CHANGE", typeof(String)); //

                paramTable.Columns.Add("MC_IMAGE", typeof(Byte[])); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                paramRow["MC_NAME"] = layoutRow["MC_NAME"];
                paramRow["MC_GROUP"] = layoutRow["MC_GROUP"];

                paramRow["MC_AUTOMATED"] = layoutRow["MC_AUTOMATED"];
                paramRow["MC_OS"] = layoutRow["MC_OS"];
                paramRow["MC_SHIFT"] = 1;
                paramRow["MC_MGT_FLAG"] = layoutRow["MC_MGT_FLAG"];
                paramRow["IS_SIGNAL"] = layoutRow["IS_SIGNAL"];

                paramRow["MC_MAKER"] = layoutRow["MC_MAKER"];
                paramRow["ASSET_NO"] = layoutRow["ASSET_NO"];
                paramRow["AS_TEL"] = layoutRow["AS_TEL"];

                paramRow["IS_OPERATE_STATE"] = layoutRow["IS_OPERATE_STATE"];

                paramRow["MC_OPEN_DATE"] = layoutRow["MC_OPEN_DATE"];
                paramRow["MC_CLOSE_DATE"] = layoutRow["MC_CLOSE_DATE"];
                paramRow["MC_MODEL"] = layoutRow["MC_MODEL"];

                paramRow["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow["CPROC_CODE2"] = layoutRow["CPROC_CODE2"];
                paramRow["MC_SEQ"] = layoutRow["MC_SEQ"];
                paramRow["MAIN_EMP"] = layoutRow["MAIN_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                //paramRow["MC_IP"] = layoutRow["MC_IP"];
                //paramRow["PLC_IP"] = layoutRow["PLC_IP"];
                //paramRow["PLC_PORT"] = layoutRow["PLC_PORT"];
                //paramRow["FTP_PORT"] = layoutRow["FTP_PORT"];
                //paramRow["FTP_DIR"] = layoutRow["FTP_DIR"];
                //paramRow["FTP_USER"] = layoutRow["FTP_USER"];
                //paramRow["FTP_USER_PW"] = layoutRow["FTP_USER_PW"];

                paramRow["IS_MULTI_START"] = layoutRow["IS_MULTI_START"];

                paramRow["MULTI_START_DIV"] = layoutRow["MULTI_START_DIV"];

               // paramRow["SIGNAL_TYPE"] = layoutRow["SIGNAL_TYPE"];
                //paramRow["IF_MC_CODE"] = layoutRow["IF_MC_CODE"];

                paramRow["MC_IMAGE"] = layoutRow["MC_IMAGE"];

                paramRow["OVERWRITE"] = "0";


                DataTable mcShiftDataTable = acGridView1.GridControl.DataSource as DataTable;

                for (int i = 0; i < mcShiftDataTable.Rows.Count; i++)
                {

                    paramRow["MON_TIME"] = mcShiftDataTable.Rows[i]["MON_TIME"];
                    paramRow["TUE_TIME"] = mcShiftDataTable.Rows[i]["TUE_TIME"];
                    paramRow["WED_TIME"] = mcShiftDataTable.Rows[i]["WED_TIME"];
                    paramRow["THR_TIME"] = mcShiftDataTable.Rows[i]["THR_TIME"];
                    paramRow["FRI_TIME"] = mcShiftDataTable.Rows[i]["FRI_TIME"];
                    paramRow["SAT_TIME"] = mcShiftDataTable.Rows[i]["SAT_TIME"];
                    paramRow["SUN_TIME"] = mcShiftDataTable.Rows[i]["SUN_TIME"];

                }

                paramRow["OPT_CAPA_CHANGE"] = "0";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();


                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW, "STD04A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);



                DataTable paramTable3 = new DataTable("RQSTDT3");
                paramTable3.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable3.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow3 = paramTable3.NewRow();
                paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow3["MC_CODE"] = layoutRow["MC_CODE"];


                paramTable3.Rows.Add(paramRow3);


                DataTable paramTable4 = new DataTable("RQSTDT4");
                paramTable4.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable4.Columns.Add("EMP_SEQ", typeof(Int32)); //


                DataView availEmpData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView empRowView in availEmpData)
                {
                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["EMP_CODE"] = empRowView["EMP_CODE"];
                    paramRow4["EMP_SEQ"] = mcCnt;
                    paramTable4.Rows.Add(paramRow4);

                    ++mcCnt;

                }

                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable3);
                paramSet2.Tables.Add(paramTable4);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD06A_INS", paramSet2, "RQSTDT,RQSTDT2", "RSLTDT",
                QuickSave,
                QuickException);

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

                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false) return;
                
                acGridView1.EndEditor();

                string optCapaChange = null;


                //설비 CAPA 변경됨
                //if (acGridView1.IsDataUpdate() == true)
                //{
                //    if (acMessageBox.Show(this, "설비 CAPA가 변경되었습니다. 오늘이후부터 존재하는 제조월력 CAPA를 수정하시겠습니까?", "IWTJET9Q", true, acMessageBox.emMessageBoxType.YESNO)
                //        == DialogResult.Yes)
                //    {
                //        optCapaChange = "1";
                //    }
                //    else
                //    {
                //        optCapaChange = "0";
                //    }
                //}

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_NAME", typeof(String)); //
                paramTable.Columns.Add("MC_GROUP", typeof(String)); //

                paramTable.Columns.Add("MC_AUTOMATED", typeof(Byte)); //
                paramTable.Columns.Add("MC_OS", typeof(Byte)); //
                paramTable.Columns.Add("MC_SHIFT", typeof(Byte)); //
                paramTable.Columns.Add("MC_MGT_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("IS_SIGNAL", typeof(Byte)); //

                paramTable.Columns.Add("IS_OPERATE_STATE", typeof(Byte)); //

                paramTable.Columns.Add("MC_OPEN_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_CLOSE_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_MODEL", typeof(String)); //

                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE2", typeof(String)); //
                paramTable.Columns.Add("MC_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("MAIN_EMP", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                //paramTable.Columns.Add("MC_IP", typeof(String)); //
                paramTable.Columns.Add("PLC_IP", typeof(String)); //

                paramTable.Columns.Add("MC_MAKER", typeof(String)); //
                paramTable.Columns.Add("ASSET_NO", typeof(String)); //
                paramTable.Columns.Add("AS_TEL", typeof(String)); //
                //paramTable.Columns.Add("PLC_PORT", typeof(String)); //
                //paramTable.Columns.Add("FTP_PORT", typeof(String)); //
                //paramTable.Columns.Add("FTP_DIR", typeof(String)); //
                //paramTable.Columns.Add("FTP_USER", typeof(String)); //
                //paramTable.Columns.Add("FTP_USER_PW", typeof(String)); //

                paramTable.Columns.Add("IS_MULTI_START", typeof(Byte)); //
                paramTable.Columns.Add("MULTI_START_DIV", typeof(Byte)); //
                //paramTable.Columns.Add("SIGNAL_TYPE", typeof(String)); //
                //paramTable.Columns.Add("IF_MC_CODE", typeof(String)); //

                paramTable.Columns.Add("MON_TIME", typeof(Single)); //
                paramTable.Columns.Add("TUE_TIME", typeof(Single)); //
                paramTable.Columns.Add("WED_TIME", typeof(Single)); //
                paramTable.Columns.Add("THR_TIME", typeof(Single)); //
                paramTable.Columns.Add("FRI_TIME", typeof(Single)); //
                paramTable.Columns.Add("SAT_TIME", typeof(Single)); //
                paramTable.Columns.Add("SUN_TIME", typeof(Single)); //


                paramTable.Columns.Add("OPT_CAPA_CHANGE", typeof(String)); //

                paramTable.Columns.Add("MC_IMAGE", typeof(Byte[])); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = linkRow["MC_CODE"];
                paramRow["MC_NAME"] = layoutRow["MC_NAME"];
                paramRow["MC_GROUP"] = layoutRow["MC_GROUP"];

                paramRow["MC_AUTOMATED"] = layoutRow["MC_AUTOMATED"];
                paramRow["MC_OS"] = layoutRow["MC_OS"];
                paramRow["MC_SHIFT"] = 1;
                paramRow["MC_MGT_FLAG"] = layoutRow["MC_MGT_FLAG"];
                paramRow["IS_SIGNAL"] = layoutRow["IS_SIGNAL"];


                paramRow["IS_OPERATE_STATE"] = layoutRow["IS_OPERATE_STATE"];

                paramRow["MC_OPEN_DATE"] = layoutRow["MC_OPEN_DATE"];
                paramRow["MC_CLOSE_DATE"] = layoutRow["MC_CLOSE_DATE"];
                paramRow["MC_MODEL"] = layoutRow["MC_MODEL"];

                paramRow["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow["CPROC_CODE2"] = layoutRow["CPROC_CODE2"];
                paramRow["MC_SEQ"] = layoutRow["MC_SEQ"];
                paramRow["MAIN_EMP"] = layoutRow["MAIN_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                //paramRow["MC_IP"] = layoutRow["MC_IP"];
                paramRow["PLC_IP"] = layoutRow["PLC_IP"];
                paramRow["MC_MAKER"] = layoutRow["MC_MAKER"];
                paramRow["ASSET_NO"] = layoutRow["ASSET_NO"];
                paramRow["AS_TEL"] = layoutRow["AS_TEL"];
                //paramRow["PLC_PORT"] = layoutRow["PLC_PORT"];
                //paramRow["FTP_PORT"] = layoutRow["FTP_PORT"];
                //paramRow["FTP_DIR"] = layoutRow["FTP_DIR"];
                //paramRow["FTP_USER"] = layoutRow["FTP_USER"];
                //paramRow["FTP_USER_PW"] = layoutRow["FTP_USER_PW"];

                paramRow["IS_MULTI_START"] = layoutRow["IS_MULTI_START"];
                paramRow["MULTI_START_DIV"] = layoutRow["MULTI_START_DIV"];
                //paramRow["SIGNAL_TYPE"] = layoutRow["SIGNAL_TYPE"];
                //paramRow["IF_MC_CODE"] = layoutRow["IF_MC_CODE"];

                paramRow["MC_IMAGE"] = layoutRow["MC_IMAGE"];

                paramRow["OVERWRITE"] = "1";


                DataTable mcShiftDataTable = acGridView1.GridControl.DataSource as DataTable;

                for (int i = 0; i < mcShiftDataTable.Rows.Count; i++)
                {

                    paramRow["MON_TIME"] = mcShiftDataTable.Rows[i]["MON_TIME"];
                    paramRow["TUE_TIME"] = mcShiftDataTable.Rows[i]["TUE_TIME"];
                    paramRow["WED_TIME"] = mcShiftDataTable.Rows[i]["WED_TIME"];
                    paramRow["THR_TIME"] = mcShiftDataTable.Rows[i]["THR_TIME"];
                    paramRow["FRI_TIME"] = mcShiftDataTable.Rows[i]["FRI_TIME"];
                    paramRow["SAT_TIME"] = mcShiftDataTable.Rows[i]["SAT_TIME"];
                    paramRow["SUN_TIME"] = mcShiftDataTable.Rows[i]["SUN_TIME"];

                }

                paramTable.Rows.Add(paramRow);


                paramRow["OPT_CAPA_CHANGE"] = optCapaChange;



                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);



                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "STD04A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

                DataTable paramTable3 = new DataTable("RQSTDT3");
                paramTable3.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable3.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow3 = paramTable3.NewRow();
                paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow3["MC_CODE"] = layoutRow["MC_CODE"];


                paramTable3.Rows.Add(paramRow3);


                DataTable paramTable4 = new DataTable("RQSTDT4");
                paramTable4.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable4.Columns.Add("EMP_SEQ", typeof(Int32)); //


                DataView availEmpData = gvLeft.GetDataSourceView();

                int mcCnt = 0;

                foreach (DataRowView empRowView in availEmpData)
                {
                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["EMP_CODE"] = empRowView["EMP_CODE"];
                    paramRow4["EMP_SEQ"] = mcCnt;
                    paramTable4.Rows.Add(paramRow4);

                    ++mcCnt;

                }

                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable3);
                paramSet2.Tables.Add(paramTable4);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD06A_INS", paramSet2, "RQSTDT,RQSTDT2", "RSLTDT",
                QuickSaveClose2,
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

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveClose2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
                this.Close();
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


        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = linkRow["MC_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD04A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
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
            //추가
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