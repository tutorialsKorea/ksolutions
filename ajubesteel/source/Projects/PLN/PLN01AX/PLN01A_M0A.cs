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
    public sealed partial class PLN01A_M0A : BaseMenu
    {
        DataRow _menuLinkData = null;
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        private bool _hasProc = false;

        public PLN01A_M0A()
        {
            InitializeComponent();

            this.acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.acGridView1_CustomDrawCell);

            btnAddIns.ItemClick += btnAddIns_ItemClick;
            btnEditIns.ItemClick += btnEditIns_ItemClick;
            btnDeleteIns.ItemClick += btnDeleteIns_ItemClick;

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl2.OnValueChanged += acLayoutControl2_OnValueChanged;
            acLayoutControl3.OnValueChanged += acLayoutControl3_OnValueChanged;
            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;
            acGridView2.MouseDown += acGridView2_MouseDown;
            acGridView2.OnMapingRowChanged += acGridView2_OnMapingRowChanged;

            acGridView2.GridControl.DragLeave += acGridView2_DragLeave;
            acGridView2.GridControl.GiveFeedback += acGridView2_GiveFeedback;
            acGridView2.GridControl.DragOver += acGridView2_DragOver;
            acGridView2.GridControl.DragDrop += acGridView2_DragDrop;
            acGridView2.MouseMove += acGridView2_MouseMove;

            acGridView3.FocusedRowChanged += acGridView3_FocusedRowChanged;
            acGridView3.MouseDown += acGridView3_MouseDown;

            acAttachFileControl1.acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

            acPictureEdit1.MouseDoubleClick += AcPictureEdit1_MouseDoubleClick;
        }

        #region 드래그 앤 드랍

        private GridHitInfo _MouseDownHitInfo = null;

        void acGridView2_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void acGridView2_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }

        void acGridView2_DragOver(object sender, DragEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor(acGridView2.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);

                }
            }

        }

        void acGridView2_DragDrop(object sender, DragEventArgs e)
        {
            try
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

                SaveJajuSeq();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        #endregion
        private void AcPictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                if (layoutRow == null)
                    return;

                if (layoutRow["STK_LOCATION_IMG"].isNullOrEmpty())
                {
                    acMessageBox.Show(this, "이미지가 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!base.ChildFormContains(layoutRow["PART_CODE"]))
                {
                    PLN01A_D6A frm = new PLN01A_D6A(layoutRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    base.ChildFormAdd(layoutRow["PART_CODE"], frm);
                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(layoutRow["PART_CODE"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page.Tag.ToString() == "ATTACH_LIST")
                {
                    DataRow focusRow = acGridView3.GetFocusedDataRow();

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
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView3.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow dr = acGridView3.GetFocusedDataRow();

                    PLN01A_D5A frm = new PLN01A_D5A(dr["PART_CODE"].ToString());

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_CD", frm);

                    frm.Show(this);

                }

            }
        }


        public override void MenuInit()
        {
            try
            {
                acGridView3.GridType = acGridView.emGridType.SEARCH;

                acGridView3.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("REV_COMMENT", "개정 사유", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, true, acGridView.emTextEditMask.NONE);

                acGridView3.AddLookUpEdit("MAT_TYPE", "구분", "40229", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

                acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");

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

                acGridView3.OptionsView.ShowGroupPanel = true;
                acGridView3.Columns["MAT_TYPE"].GroupIndex = 0;
                acGridView3.Columns["MAT_TYPE"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

                acGridView3.KeyColumn = new string[] { "PART_CODE" };

                acGridView3.OptionsPrint.ExpandAllGroups = true;

                #region 표준공정 리스트 컬럼 설정
                acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;
                acGridView4.GridType = acGridView.emGridType.FIXED_SINGLE;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN_PROC", paramSet, "RQSTDT", "RSLTDT");

                DataTable dtSchem = new DataTable();

                if (rsltSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    foreach (DataRow row in rsltSet.Tables["RSLTDT"].Rows)
                    {
                        string strColumnNmae = "";
                        foreach (char c in row["PROC_NAME"].ToString())
                        {
                            strColumnNmae += (c + "\n");
                        }
                        dtSchem.Columns.Add(row["PROC_CODE"].ToString());

                        //strColumnNmae = row["PROC_NAME"].ToString() + "\n" + "sss";
                        acGridView1.AddCheckEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, false, true, acGridView.emCheckEditDataType._INT);
                        acGridView4.AddMemoEdit(row["PROC_CODE"].ToString(), strColumnNmae, "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, false, true, true, true);
                    }
                }

                acGridView4.GridControl.DataSource = dtSchem;

                acGridView1.ColumnPanelRowHeight = 90;
                acGridView1.RowHeight = 50;

                //acGridView1.BestFitColumns();
                acGridView4.GridType = acGridView.emGridType.FIXED_SINGLE;
                acGridView4.RowHeight = 50;
                acGridView4.OptionsView.ShowColumnHeaders = false;

                acGridView4.Appearance.FocusedRow.BackColor = Color.Transparent;
                acGridView4.Appearance.HideSelectionRow.BackColor = Color.Transparent;

                #endregion

                acGridView2.GridType = acGridView.emGridType.FIXED_SINGLE;


                acGridView2.AddLookUpEdit("INS_CODE", "검사항목", "6EBKRYNM", true, DevExpress.Utils.HorzAlignment.Near, false, true, true, "M011");
                acGridView2.AddLookUpEdit("MEAS_CODE", "측정기", "VRBPTMP7", true, DevExpress.Utils.HorzAlignment.Near, false, true, true, "M012");

                acGridView2.AddTextEdit("AVG_VAL", "기준치", "1NLJVXPA", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MIN_VAL", "최소값", "NI5ZIKEN", true, DevExpress.Utils.HorzAlignment.Far, false, true, true, acGridView.emTextEditMask.F3);
                acGridView2.AddTextEdit("MAX_VAL", "최대값", "RTLH6LVK", true, DevExpress.Utils.HorzAlignment.Far, false, true, true, acGridView.emTextEditMask.F3);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, true, acGridView.emTextEditMask.NONE);

                acGridView2.KeyColumn = new string[] { "INS_CODE" };

                acGridView4.RowCellStyle += acGridView4_RowCellStyle;
                //검색조건
                (acLayoutControl1.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M001");
                (acLayoutControl1.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M002");
                (acLayoutControl1.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M008");

                //상세정보
                (acLayoutControl2.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M001");
                (acLayoutControl2.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M002");
                (acLayoutControl2.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M008");

                (acLayoutControl2.GetEditor("PART_PRODTYPE").Editor as acLookupEdit).SetCode("M007");

                (acLayoutControl2.GetEditor("MAT_TYPE").Editor as acLookupEdit).SetCode("S016");
                (acLayoutControl2.GetEditor("MAT_UNIT").Editor as acLookupEdit).SetCode("M003");

                (acLayoutControl2.GetEditor("STK_LOCATION").Editor as acLookupEdit).SetCode("M005");

                (acLayoutControl2.GetEditor("SPEC_TYPE").Editor as acLookupEdit).SetCode("S062");

                acVendor1.VenType = "3";

                acTextEdit7.Enabled = false;
                acTextEdit13.Enabled = false;

                acCheckedComboBoxEdit1.AddItem("등록일", false, "40515", "REG_DATE", false, false);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (_menuLinkData != null)
            {
                LinkSearch(_menuLinkData);
                _menuLinkData = null;
            }
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

            Type t = data.GetType();

            if (t == typeof(DataRow)) //if ( t == typeof(String))
            {
                _menuLinkData = (DataRow)data;
            }
            else 
            {
                //acLayoutControl1.GetEditor("PART_CODE").Value = data.ToString();
                _part_code = data.ToString();
                Search();
                _part_code = string.Empty;
            }
            //base.MenuLink(data);
        }

        void LinkSearch(DataRow linkRow)
        {
            try
            {

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
                paramRow["PART_CODE"] = linkRow["PART_CODE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN01A_SER", paramSet, "RQSTDT", "RSLTDT",
                       QuickLinkSearch,
                       QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickLinkSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                _dsResult = e.result;

                acGridView3.GridControl.DataSource = _dsResult.Tables["RSLTDT"];

                if (_dsResult.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acGridView3.FocusedRowHandle = 0;
                    acGridView3.RaiseFocusedRowChanged();

                    popupProc();
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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
                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null) return;

                string part_code = focusRow["PART_CODE"].ToString();

                //품목정보 data binding
                //DataRow[] dr = _dsResult.Tables["RSLTDT"].Select(string.Format("PLT_CODE = '{0}' AND PART_CODE = '{1}'", acInfo.PLT_CODE, part_code));
                //if (dr.Length > 0) acLayoutControl2.DataBind(dr[0], false);

                acLayoutControl2.DataBind(focusRow, false);

                DataTable tmpDt = focusRow.NewTable();
                tmpDt.TableName = "RQSTDT";
                DataTable resultDt = BizRun.QBizRun.ExecuteService(this, "PLN01A_SER6", tmpDt.NewDataSet(), "RQSTDT", "RSLTDT").Tables["RSLTDT"];
                if (resultDt.Rows.Count > 0)
                {
                    object img = resultDt.Rows[0]["STK_LOCATION_IMG"];
                    (acLayoutControl2.GetEditor("STK_LOCATION_IMG") as acPictureEdit).EditValue = img;
                }

                _isBind = false;

                acLayoutControl3.DataBind(focusRow, false);

                _isBind = true;

                //자주검사 항목 조회
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = part_code;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                #region 공정 시간 총합
                DataSet paramSet2 = paramSet.Copy();
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PLN01A_SER4", paramSet2, "RQSTDT", "RSLTDT");
                acLayoutControl2.GetEditor("STD_TIME_SUM").Value = dsResult.Tables["RSLTDT"].AsEnumerable()
                                                                                //.Where(w => !w.IsNull("STD_TIME"))
                                                                                .Select(r => r.Field<decimal?>("STD_TIME"))
                                                                                .Sum();
                #endregion

                DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "PLN01A_SER2", paramSet, "RQSTDT", "RSLTDT");
                acGridControl2.DataSource = dsRslt.Tables["RSLTDT"];


                //공정정보 조회
                GetProc();

                //첨부파일 조회
                if (part_code != "")
                {
                    this.acAttachFileControl1.Enabled = true;

                    this.acAttachFileControl1.LinkKey = focusRow["PART_CODE"];
                    this.acAttachFileControl1.ShowKey = new object[] { focusRow["PART_CODE"] };
                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }

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

            DataRow dr = acGridView3.GetFocusedDataRow();

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

            DataTable dtTemp = (acGridView4.GridControl.DataSource) as DataTable;
            //DataTable dtTemp = (acGridView1.GridControl.DataSource) as DataTable;
            DataTable dt = dtTemp.Clone();
            DataRow mc_row = dt.NewRow();
            //DataRow emp_row = dt.NewRow();

            foreach (DataRow procRow in dsRslt.Tables["RSLTDT_PROC"].Rows)
            {
                mc_row[procRow["PROC_CODE"].ToString()] = procRow["MC_NAME"];
                //emp_row[procRow["PROC_CODE"].ToString()] = procRow["EMP_NAME"];
            }
            dt.Rows.Add(mc_row);
            //dt.Rows.Add(emp_row);

            acGridView4.GridControl.DataSource = dt;

            if (dsRslt.Tables["RSLTDT_PART"].Rows.Count > 0)
            {
                acLayoutControl2.DataBind(dsRslt.Tables["RSLTDT_PART"].Rows[0], false);

                _isBind = false;

                acLayoutControl3.DataBind(dsRslt.Tables["RSLTDT_PART"].Rows[0], false);

                _isBind = true;
            }
        }

        private DataSet SaveData(bool isOtherName, String _strPartCode, String _strPartName)
        {
            if (acLayoutControl2.ValidCheck() == false) return null;

            DataRow layoutRow = acLayoutControl2.CreateParameterRow();
            DataRow layoutRow2 = acLayoutControl3.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("OLD_PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_NAME", typeof(String)); //
                                                                 //paramTable.Columns.Add("PART_ENAME", typeof(String)); //

            paramTable.Columns.Add("PART_SEQ", typeof(Int32));
            paramTable.Columns.Add("MAT_TYPE", typeof(String));
            paramTable.Columns.Add("PART_PRODTYPE", typeof(String));
            paramTable.Columns.Add("DRAW_NO", typeof(String));
            paramTable.Columns.Add("ZIG_NO", typeof(String));
            paramTable.Columns.Add("MAT_LTYPE", typeof(String));
            paramTable.Columns.Add("MAT_MTYPE", typeof(String));
            paramTable.Columns.Add("MAT_STYPE", typeof(String));
            paramTable.Columns.Add("MAT_UNIT", typeof(String));
            paramTable.Columns.Add("UNIT_QTY", typeof(Decimal));
            paramTable.Columns.Add("MAT_UC", typeof(Decimal));
            paramTable.Columns.Add("MAT_COST", typeof(Decimal));
            paramTable.Columns.Add("SPEC_TYPE", typeof(String));
            paramTable.Columns.Add("MAT_SPEC", typeof(String));
            paramTable.Columns.Add("MAT_SPEC1", typeof(String));
            paramTable.Columns.Add("BAL_SPEC", typeof(String));
            paramTable.Columns.Add("MAT_WEIGHT", typeof(Decimal));
            paramTable.Columns.Add("MAT_WEIGHT1", typeof(Decimal));
            paramTable.Columns.Add("BAL_WEIGHT", typeof(Decimal));
            paramTable.Columns.Add("AUTO_MARGIN_SPEC", typeof(String));
            paramTable.Columns.Add("MAT_QLTY", typeof(String));
            paramTable.Columns.Add("MAIN_VND", typeof(String));
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("REV_COMMENT", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            paramTable.Columns.Add("FAC_PRICE", typeof(Decimal));       //출고가
            paramTable.Columns.Add("PROC_COST", typeof(Decimal));       //가공비
            paramTable.Columns.Add("MNG_COST", typeof(Decimal));        //일반관리비
            paramTable.Columns.Add("PROD_COST", typeof(Decimal));       //제조원가
            paramTable.Columns.Add("PROFIT_PRICE", typeof(Decimal));       //이익금
            paramTable.Columns.Add("PROFIT_RATIO", typeof(float));       //이익율

            paramTable.Columns.Add("JIG_CONTENTS", typeof(String));    //지그 제작내용
            paramTable.Columns.Add("JIG_COST", typeof(Decimal));       //지그제작비
            paramTable.Columns.Add("ETC_CONTENTS", typeof(String));    //기타내용
            paramTable.Columns.Add("ETC_COST", typeof(Decimal));       //기타비용

            //paramTable.Columns.Add("LOAD_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("INS_FLAG", typeof(String)); //
            //paramTable.Columns.Add("ACT_CODE", typeof(String)); //
            //paramTable.Columns.Add("IF_PART_CODE", typeof(String)); //
            paramTable.Columns.Add("STK_LOCATION", typeof(String)); //
            paramTable.Columns.Add("STK_LOCATION_DETAIL", typeof(String)); //
            paramTable.Columns.Add("STK_LOCATION_IMG", typeof(Byte[])); //
            paramTable.Columns.Add("SAFE_STK_QTY", typeof(Decimal)); //
            paramTable.Columns.Add("AUTO_CREATE", typeof(Byte)); //
            paramTable.Columns.Add("AUTO_MARGIN", typeof(Byte)); //
            paramTable.Columns.Add("STK_MNG", typeof(Byte)); //
            paramTable.Columns.Add("REV_PART_CODE", typeof(String)); //
            paramTable.Columns.Add("IS_TURNING", typeof(Int32)); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            if (!isOtherName)
            {
                paramRow["OLD_PART_CODE"] = null;
                paramRow["PART_CODE"] = layoutRow["PART_CODE"];
                paramRow["PART_NAME"] = layoutRow["PART_NAME"];
                paramRow["REV_PART_CODE"] = layoutRow["REV_PART_CODE"];
            }
            else
            {
                paramRow["OLD_PART_CODE"] = layoutRow["PART_CODE"];
                paramRow["PART_CODE"] = _strPartCode;
                paramRow["PART_NAME"] = _strPartName;
                paramRow["REV_PART_CODE"] = null;
            }

            //paramRow["PART_ENAME"] = layoutRow["PART_ENAME"];
            paramRow["DRAW_NO"] = layoutRow["DRAW_NO"];
            paramRow["ZIG_NO"] = layoutRow["ZIG_NO"];

            //paramRow["PART_SEQ"] = layoutRow["PART_SEQ"];
            paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];
            paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
            paramRow["MAT_UNIT"] = layoutRow["MAT_UNIT"];
            paramRow["UNIT_QTY"] = 1;
            paramRow["MAT_UC"] = layoutRow["MAT_UC"];
            paramRow["MAT_COST"] = layoutRow["MAT_COST"];
            paramRow["SPEC_TYPE"] = layoutRow["SPEC_TYPE"];
            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
            paramRow["MAT_SPEC"] = layoutRow["MAT_SPEC"];
            paramRow["MAT_SPEC1"] = layoutRow["MAT_SPEC1"];
            paramRow["BAL_SPEC"] = layoutRow["BAL_SPEC"];
            paramRow["MAT_WEIGHT"] = layoutRow["MAT_WEIGHT"];
            paramRow["MAT_WEIGHT1"] = layoutRow["MAT_WEIGHT1"];
            paramRow["BAL_WEIGHT"] = layoutRow["BAL_WEIGHT"];
            paramRow["MAT_QLTY"] = layoutRow["MAT_QLTY"];
            paramRow["MAIN_VND"] = layoutRow["MAIN_VND"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["REV_COMMENT"] = layoutRow["REV_COMMENT"];
            paramRow["REG_EMP"] = acInfo.UserID;

            paramRow["FAC_PRICE"] = layoutRow2["FAC_PRICE"];
            paramRow["PROC_COST"] = layoutRow2["PROC_COST"];
            paramRow["MNG_COST"] = layoutRow2["MNG_COST"];
            paramRow["PROD_COST"] = layoutRow2["PROD_COST"];
            paramRow["PROFIT_PRICE"] = layoutRow2["PROFIT_PRICE"];

            paramRow["JIG_CONTENTS"] = layoutRow2["JIG_CONTENTS"];
            paramRow["JIG_COST"] = layoutRow2["JIG_COST"];
            paramRow["ETC_CONTENTS"] = layoutRow2["ETC_CONTENTS"];
            paramRow["ETC_COST"] = layoutRow2["ETC_COST"];

            paramRow["PROFIT_RATIO"] = layoutRow2["PROFIT_RATIO"];
            //paramRow["LOAD_FLAG"] = layoutRow["LOAD_FLAG"];
            paramRow["INS_FLAG"] = 0;
            //paramRow["ACT_CODE"] = layoutRow["ACT_CODE"];
            //paramRow["IF_PART_CODE"] = layoutRow["IF_PART_CODE"];

            paramRow["STK_LOCATION"] = layoutRow["STK_LOCATION"];
            paramRow["STK_LOCATION_DETAIL"] = layoutRow["STK_LOCATION_DETAIL"];
            paramRow["STK_LOCATION_IMG"] = layoutRow["STK_LOCATION_IMG"];
            paramRow["SAFE_STK_QTY"] = layoutRow["SAFE_STK_QTY"];
            paramRow["IS_TURNING"] = layoutRow["IS_TURNING"];

            paramRow["AUTO_CREATE"] = 0;
            paramRow["AUTO_MARGIN"] = "0";

            paramRow["STK_MNG"] = 0;
            if (is_New || isOtherName)
            {
                paramRow["OVERWRITE"] = "0";
            }
            else
            {
                paramRow["OVERWRITE"] = "1";
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow row = acGridView1.GetDataRow(0);

                foreach (acGridColumn col in acGridView1.Columns)
                {
                    if (row[col.FieldName].ToString() != "1")
                    {
                        DataRow mc_row = acGridView4.GetDataRow(0);
                        //DataRow emp_row = acGridView4.GetDataRow(1);

                        if (mc_row != null)
                            mc_row[col.FieldName] = null;

                        //if (emp_row != null)
                        //    emp_row[col.FieldName] = null;

                        col.Tag = null;
                    }
                }
                _isChange = false;
                //acTreeList1.DataSource = e.result.Tables["RSLTDT"];                   

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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


        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["INS_CODE"]);
            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
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
                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.btnEditIns_ItemClick(null, null);
                }
            }
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnAddIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView3_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_isChange)
            {
                if (acMessageBox.Show("수정된 항목이 있습니다. 계속 진행 하시겠습니까?", "확인", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
                {
                    acGridView3.FocusedRowChanged -= acGridView3_FocusedRowChanged;

                    return;
                }
            }



            _isChange = false;

            this.GetDetail();
        }


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {


                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {

                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

                case "MAT_LTYPE":

                    (acLayoutControl1.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M002", newValue);

                    break;

                case "MAT_MTYPE":

                    (acLayoutControl1.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M008", newValue);
                    break;
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        void acLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;


            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    acLeMatMtype.SetCode("M002", newValue);
                    break;

                case "MAT_MTYPE":

                    acLeMatStype.SetCode("M008", newValue);
                    break;

                case "SPEC_TYPE":

                    //if (layout.IsBinding == false)
                    //{

                    if (acChecker.isNull(acLookupEdit6.EditValue) == false)
                    {

                        layout.GetEditor("MAT_SPEC").Editor.Enabled = true;
                        layout.GetEditor("MAT_SPEC1").Editor.Enabled = true;

                        DataRow codeRow = acInfo.StdCodes.GetCodeRow("S062", layout.GetEditor("SPEC_TYPE").Value);


                        if (!codeRow["VALUE"].isNullOrEmpty())
                        {
                            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;


                            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;

                        }
                        else
                        {
                            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = null;

                            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.EditMask = null;


                        }
                    }
                    else
                    {

                        layout.GetEditor("MAT_SPEC").Editor.Enabled = false;
                        layout.GetEditor("MAT_SPEC1").Editor.Enabled = false;
                    }


                    //}
                    break;


                case "MAT_QLTY":

                    if (layout.IsBinding == false)
                    {
                        //제품중량
                        layout.GetEditor("MAT_WEIGHT1").Value = acMaterial.GetMatWeight(layout.GetEditor("MAT_SPEC1").Value, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);
                        //소재중량
                        layout.GetEditor("MAT_WEIGHT").Value = acMaterial.GetMatWeight(layout.GetEditor("MAT_SPEC").Value, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);
                        //발주중량
                        layout.GetEditor("BAL_WEIGHT").Value = acMaterial.GetMatWeight(layout.GetEditor("BAL_SPEC").Value, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);

                        if (newValue != null)
                        {
                            //단가 및 소재비 계산(발주 중량으로)
                            layout.GetEditor("MAT_UC").Value = acMaterial.GetDataRow(newValue)["MQLTY_UC"];
                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(0, layout.GetEditor("BAL_WEIGHT").Value, layout.GetEditor("MAT_UC").Value, 1);
                        }

                    }

                    break;

                case "MAT_SPEC1":   //제품규격

                    if (layout.IsBinding == false)
                    {
                        if (layout.GetEditor("MAT_QLTY").Value != null)
                        {

                            if (newValue != null &&
                                acMaterial1.SelectedRow["MQLTY_CODE"] != null)
                            {
                                //제품중량 계산
                                layout.GetEditor("MAT_WEIGHT1").Value = acMaterial.GetMatWeight(newValue, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);
                                //layout.GetEditor("MAT_WEIGHT").Value = acMaterial.GetMatWeight(layout.GetEditor("MAT_SPEC").Value, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);
                            }

                        }
                        else
                        {
                            //if (newValue != null)
                            //    acMessageBox.Show(this, "재질을 선택하세요.", "KUC6LQGE", true, acMessageBox.emMessageBoxType.CONFIRM);
                        }
                    }

                    break;

                case "MAT_SPEC":    //소재규격 -- 사용자 입력, 발주규격 자동 입력, 소재 중량 및 발주 중량 계산

                    if (layout.IsBinding == false)
                    {

                        if (layout.GetEditor("MAT_QLTY").Value != null)
                        {

                            layout.GetEditor("BAL_SPEC").Value = acMaterial.GetAutoMarginSpecByMqlty(acMaterial1.SelectedRow["MQLTY_CODE"].ToString(), newValue, layout.GetEditor("SPEC_TYPE").Value);

                            layout.GetEditor("MAT_WEIGHT").Value = acMaterial.GetMatWeight(newValue, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);
                            layout.GetEditor("BAL_WEIGHT").Value = acMaterial.GetMatWeight(layout.GetEditor("BAL_SPEC").Value, acMaterial1.SelectedRow["MQLTY_CODE"], layout.GetEditor("SPEC_TYPE").Value);

                            layout.GetEditor("MAT_UC").Value = acMaterial.GetDataRow(layout.GetEditor("MAT_QLTY").Value)["MQLTY_UC"];
                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(0, layout.GetEditor("BAL_WEIGHT").Value, layout.GetEditor("MAT_UC").Value, 1);
                        }

                    }

                    break;

                case "BAL_SPEC":    //발주규격

                    if (layout.IsBinding == false)
                    {

                        if (layout.GetEditor("MAT_QLTY").Value != null)
                        {

                            layout.GetEditor("MAT_UC").Value = acMaterial.GetDataRow(layout.GetEditor("MAT_QLTY").Value)["MQLTY_UC"];
                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(0, layout.GetEditor("BAL_WEIGHT").Value, layout.GetEditor("MAT_UC").Value, 1);
                        }

                    }
                    break;
                case "BAL_WEIGHT":
                    if (layout.IsBinding == false)
                    {

                        layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(0, layout.GetEditor("BAL_WEIGHT").Value, layout.GetEditor("MAT_UC").Value, 1);

                    }
                    break;
                case "MAT_UC":
                    if (layout.IsBinding == false)
                    {
                        layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(0, layout.GetEditor("BAL_WEIGHT").Value, layout.GetEditor("MAT_UC").Value, 1);

                    }
                    break;
            }
        }

        double jig_cost, etc_cost;

        void acLayoutControl3_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            double mng_cost, cost, profit, profit_ratio;

            switch (info.ColumnName)
            {
                case "PROC_COST":   //가공비
                    mng_cost = (newValue.toDouble() + layout.GetEditor("MAT_COST").Value.toDouble()) * 0.15;
                    //일반관리비 산출
                    layout.GetEditor("MNG_COST").Value = mng_cost;
                    //제조원가 = 소재비 + 가공비 + 일반관리비
                    cost = (layout.GetEditor("MAT_COST").Value.toDouble() + newValue.toDouble() + mng_cost);
                    layout.GetEditor("PROD_COST").Value = cost;
                    //이익금
                    profit = (layout.GetEditor("FAC_PRICE").Value.toDouble() - cost);
                    layout.GetEditor("PROFIT_PRICE").Value = profit;
                    //이익율
                    profit_ratio = (layout.GetEditor("FAC_PRICE").Value.toDouble() - cost) / layout.GetEditor("FAC_PRICE").Value.toDouble() * 100;
                    layout.GetEditor("PROFIT_RATIO").Value = profit_ratio;
                    break;

                case "FAC_PRICE":
                    cost = (layout.GetEditor("MAT_COST").Value.toDouble() + layout.GetEditor("PROC_COST").Value.toDouble() + layout.GetEditor("MNG_COST").Value.toDouble());
                    //이익금
                    profit = (newValue.toDouble() - cost);
                    layout.GetEditor("PROFIT_PRICE").Value = profit;
                    //이익율
                    profit_ratio = (layout.GetEditor("FAC_PRICE").Value.toDouble() - cost) / layout.GetEditor("FAC_PRICE").Value.toDouble() * 100;

                    layout.GetEditor("PROFIT_RATIO").Value = profit_ratio;
                    break;

                case "JIG_COST":

                    if (jig_cost != newValue.toDouble())
                    {
                        layout.GetEditor("PROC_COST").Value = layout.GetEditor("PROC_COST").Value.toDouble() - jig_cost;
                    }

                    jig_cost = newValue.toDouble();

                    if (_isBind)
                    {
                        layout.GetEditor("PROC_COST").Value = layout.GetEditor("PROC_COST").Value.toDouble() + newValue.toDouble();
                    }


                    break;

                case "ETC_COST":

                    if (etc_cost != newValue.toDouble())
                    {
                        layout.GetEditor("PROC_COST").Value = layout.GetEditor("PROC_COST").Value.toDouble() - etc_cost;
                    }

                    etc_cost = newValue.toDouble();

                    if (_isBind)
                    {
                        layout.GetEditor("PROC_COST").Value = layout.GetEditor("PROC_COST").Value.toDouble() + newValue.toDouble();
                    }

                    break;
            }
        }

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



        GridHitInfo _gv1hitinfo;
        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    btnSetMC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnAddIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        btnSetMC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnAddIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    else
                    {
                        btnSetMC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnAddIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnEditIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnDeleteIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }

                _gv1hitinfo = view.CalcHitInfo(e.Point);

                DataRow row = acGridView1.GetDataRow(0);

                if (row[_gv1hitinfo.Column.FieldName].ToString() == "1")
                {
                    popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }


            }
        }

        /// <summary>
        /// 자주검사 항목 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddIns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //TreeListNode focusNode = acTreeList1.FocusedNode;

                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null) return;

                string part_code = focusRow["PART_CODE"].ToString();

                if (!base.ChildFormContains("NEW_CD"))
                {

                    PLN01A_D0A frm = new PLN01A_D0A(acGridView2, acGridView2.GetFocusedDataRow(), part_code);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_CD", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_CD");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 자주검사 항목 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEditIns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                //TreeListNode focusNode = acTreeList1.FocusedNode;

                DataRow focusRow2 = acGridView3.GetFocusedDataRow();

                if (focusRow2 == null) return;

                string part_code = focusRow2["PART_CODE"].ToString();

                if (!base.ChildFormContains(focusRow["INS_CODE"]))
                {
                    PLN01A_D0A frm = new PLN01A_D0A(acGridView2, acGridView2.GetFocusedDataRow(), part_code);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["INS_CODE"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["INS_CODE"]);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 자주검사 항목 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDeleteIns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                acGridView1.EndEditor();

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));

                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focusRow["PART_CODE"];
                paramRow["INS_CODE"] = focusRow["INS_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "PLN01A_DEL", paramSet, "RQSTDT", "RSLTDT",
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
                    acGridView2.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnSetMC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = acGridView3.GetFocusedDataRow();

            string proc_code = _gv1hitinfo.Column.FieldName;

            PLN01A_D1A frm = new PLN01A_D1A(dr["PART_CODE"].ToString(), proc_code, _gv1hitinfo.Column.Tag);

            frm.ParentControl = this;

            if (_hasProc)
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
            else
                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            base.ChildFormAdd("NEW_CD", frm);

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                _gv1hitinfo.Column.Tag = frm.GetSelected();

                DataRow mc_row = acGridView4.GetDataRow(0);
                //DataRow emp_row = acGridView4.GetDataRow(1);

                if (mc_row != null)
                    mc_row[proc_code] = frm.GetMcName();

                //if (emp_row != null)
                //    emp_row[proc_code] = frm.GetEmpName();
            }
        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {
            //품목 상세 정보 저장
            if (!acLayoutControl2.ValidCheck()) return;
            DataSet partSet = SaveData(false, null, null);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD02A_INS", partSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                //int rowhandle = this.acGridView3.FocusedRowHandle;

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView3.UpdateMapingRow(row, true);
                    //acGridView3.UpdateMapingRow(row, false);
                }

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.UpdateMapingRow(row, true);
                    //acGridView3.UpdateMapingRow(row, false);
                }

                is_New = false;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        bool is_New = false;
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                acTextEdit2.isReadyOnly = false;
                acLayoutControl2.ClearValue();
                acLayoutControl3.ClearValue();
                acLookupEdit1.Focus();

                acTextEdit7.Enabled = false;
                acTextEdit13.Enabled = false;

                //공정정보 clear
                acGridView1.ClearRow();
                DataRow row = acGridView1.NewRow();

                acGridView1.AddRow(row);
                acGridView4.ClearRow();

                //자주검사 항목 clear
                acGridView2.ClearRow();

                //첨부파일 clear
                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;

                is_New = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void btnSaveProc_Click(object sender, EventArgs e)
        {
            try
            {
                popupProc();

                #region 기존코드
                //if (acGridView3.RowCount == 0) return;

                //DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("PART_CODE", typeof(String)); //
                //paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                //paramTable.Columns.Add("PROC_SEQ", typeof(Int32)); //
                //paramTable.Columns.Add("MC_CODE", typeof(String)); //
                //paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                //paramTable.Columns.Add("REG_EMP", typeof(String)); //

                //int i = 0;

                //DataRow row = acGridView1.GetDataRow(0);

                //foreach (acGridColumn col in acGridView1.Columns)
                //{
                //    if (row[col.FieldName].ToString() == "1")
                //    {
                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //        paramRow["PART_CODE"] = layoutRow["PART_CODE"];
                //        paramRow["PROC_CODE"] = col.FieldName;
                //        if (col.Tag != null)
                //        {
                //            string[] info = col.Tag.ToString().Split(':');
                //            paramRow["MC_CODE"] = info[0].ToString();
                //            paramRow["EMP_CODE"] = info[1].ToString();
                //            //col.Tag = null;
                //        }

                //        paramRow["PROC_SEQ"] = i;
                //        paramRow["REG_EMP"] = acInfo.UserID;

                //        paramTable.Rows.Add(paramRow);

                //        i++;
                //    }
                //}

                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                //            QuickSave,
                //            QuickException);
                #endregion

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void popupProc()
        {

            DataRow dr = acGridView3.GetFocusedDataRow();

            if (dr == null) return;

            DataTable paramTable = new DataTable();

            PLN01A_D3A frm = new PLN01A_D3A(acGridView1, acGridView3.GetFocusedDataRow(), dr["PART_CODE"].ToString());

            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            frm.ParentControl = this;

            frm.ShowDialog(this);
        }

        private void btnViewRev_Click(object sender, EventArgs e)
        {
            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            string rev_part = layoutRow["REV_PART_CODE"].ToString();

            if (rev_part == "")
            {
                acMessageBox.Show("모품목을 선택하세요.", "개정 이력 보기", acMessageBox.emMessageBoxType.CONFIRM);
                return;

            }

            PLN01A_D4A frm = new PLN01A_D4A(rev_part);

            frm.ParentControl = this;

            base.ChildFormAdd(rev_part, frm);

            frm.Show();
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {

            //다른이름으로 저장

            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            if (!base.ChildFormContains(layoutRow["PART_CODE"]))
            {

                PLN01A_D2A frm = new PLN01A_D2A();

                frm.ParentControl = this;

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                base.ChildFormAdd(layoutRow["PART_CODE"], frm);

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    DataRow outputRow = (DataRow)frm.OutputData;

                    if (!acLayoutControl2.ValidCheck()) return;
                    DataSet partSet = SaveData(true, outputRow["PART_CODE"].ToString(), outputRow["PART_NAME"].ToString());

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "STD02A_INS2", partSet, "RQSTDT", "RSLTDT",
                            QuickSaveClose,
                            QuickException);
                }
            }
            else
            {

                base.ChildFormFocus(layoutRow["PART_CODE"]);

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

        private void btnCopyProc_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                _copy_partCode = layoutRow["PART_CODE"].ToString();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (_copy_partCode == "")
                {
                    acMessageBox.Show("[공정정보 복사] 버튼을 클릭하여 복사할 공정을 먼저 선택하세요.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (acMessageBox.Show("[" + _copy_partCode + "] 품목의 공정정보를 복사하시겠습니까? \r\n 복사하면 기존의 공정정보는 사라집니다. ", this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                    DataSet paramSet = new DataSet();

                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("PART_CODE", typeof(String));       //복사하려는 품목
                    dtParam.Columns.Add("O_PART_CODE", typeof(String));     //복사한 품목

                    DataRow dtRow = dtParam.NewRow();
                    dtRow["PLT_CODE"] = acInfo.PLT_CODE;
                    dtRow["PART_CODE"] = layoutRow["PART_CODE"];
                    dtRow["O_PART_CODE"] = _copy_partCode;
                    dtParam.Rows.Add(dtRow);

                    paramSet.Tables.Add(dtParam);

                    DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PLN01A_SAVE4", paramSet, "RQSTDT", "RSLTDT");

                    this.GetProc();

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




        private void ExportXls()
        {
            try
            {
                DataRow focus = acGridView3.GetFocusedDataRow();

                DataRow MatRow = acMaterial1.SelectedRow;

                if (focus == null) return;

                if (acMessageBox.Show(this, "엑셀 내보내기를 하시겠습니까?", "5DE1YPBV", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //공정정보 조회
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focus["PART_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsRsltdt = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN01A_SER_STD", paramSet, "RQSTDT", "RSLTDT_PROC,RSLTDT_MC,RSLTDT_EMP");

                DataTable proc_cost = dsRsltdt.Tables["RSLTDT_PROC"].Copy();

                SaveFileDialog pFileDlg = new SaveFileDialog();
                pFileDlg.Filter = "Excel Files (.xlsx)|*.xlsx";
                pFileDlg.Title = "저장할 위치를 입력하여 주십시오.";
                pFileDlg.FileName = focus["PART_NAME"].ToString() + " - 사전원가 분석표";
                if (pFileDlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                String strFullPathFile = pFileDlg.FileName;

                bool exists = System.IO.Directory.Exists(acInfo.DefaultDirectory);

                if (!exists)
                    System.IO.Directory.CreateDirectory(acInfo.DefaultDirectory);

                string xlsPath = Path.Combine(acInfo.DefaultDirectory, "cost.xlsx");

                Stream stream = new MemoryStream(Resource.CostAnalysisTable);

                byte[] buffer = new byte[stream.Length];

                using (System.IO.FileStream output = new FileStream(xlsPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int readBytes = 0;
                    while ((readBytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, readBytes);
                    }

                    //output.Close();
                }

                stream.Close();

                System.Threading.Thread.Sleep(100);

                string year = acDateEdit.GetNowDateFromServer().toDateString("yyyy");
                string month = acDateEdit.GetNowDateFromServer().toDateString("MM");
                string day = acDateEdit.GetNowDateFromServer().toDateString("dd");

                DataRow partRow = acLayoutControl2.CreateParameterRow();
                DataRow costRow = acLayoutControl3.CreateParameterRow();

                Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel._Workbook wb = oXL.Workbooks.Open(xlsPath);

                Microsoft.Office.Interop.Excel._Worksheet ws = (Microsoft.Office.Interop.Excel._Worksheet)wb.ActiveSheet;

                //Resource 엑셀파일 첫Sheet 복사 생성
                //ExcelWorksheet copy_ws = xlsFile.Worksheets[0];

                bool isFile = File.Exists(strFullPathFile);

                if (isFile)
                {
                    wb = oXL.Workbooks.Open(strFullPathFile);

                    int idx = wb.Sheets.Count;
                    ws.Copy(System.Reflection.Missing.Value, wb.Sheets[idx]);
                    ws = (Microsoft.Office.Interop.Excel._Worksheet)wb.ActiveSheet;

                }

                Microsoft.Office.Interop.Excel.Range xlRange = ws.UsedRange;

                //내용 작성
                ws.get_Range("A2").Value2 = "작 성 일 : " + year + "년 " + month + "월 " + day + "일";
                ws.get_Range("C4").Value2 = acVendor1.Text;

                ws.get_Range("I4").Value2 = costRow["FAC_PRICE"];

                ws.get_Range("C6").Value2 = partRow["DRAW_NO"];

                ws.get_Range("I6").Value2 = partRow["MAT_SPEC1"];

                ws.get_Range("C7").Value2 = partRow["PART_NAME"];

                ws.get_Range("I7").Value2 = partRow["MAT_SPEC"];

                ws.get_Range("C8").Value2 = MatRow["MQLTY_NAME"];

                ws.get_Range("I8").Value2 = partRow["BAL_WEIGHT"];

                ws.get_Range("C9").Value2 = partRow["MAT_UC"];

                ws.get_Range("I9").Value2 = partRow["MAT_COST"];



                for (int i = 0; i < 17; i++)
                {
                    foreach (DataRow row in proc_cost.Rows)
                    {

                        if (ws.get_Range("B" + (14 + i).ToString()).Value.ToString() == row["PROC_NAME"].ToString())
                        {
                            ws.get_Range("D" + (14 + i).ToString()).Value2 = row["PROC_TIME"];
                            ws.get_Range("F" + (14 + i).ToString()).Value2 = row["PROC_UC"];
                            ws.get_Range("H" + (14 + i).ToString()).Value2 = row["PROC_COST"];
                            ws.get_Range("I" + (14 + i).ToString()).Value2 = row["SCOMMENT"];

                        }
                    }
                }

                ws.get_Range("H31").Value2 = costRow["JIG_COST"];

                ws.get_Range("I31").Value2 = costRow["JIG_CONTENTS"];

                ws.get_Range("H32").Value2 = costRow["ETC_COST"];

                ws.get_Range("I32").Value2 = costRow["ETC_CONTENTS"];

                ws.get_Range("D34").Value2 = costRow["MAT_COST"];

                ws.get_Range("H34").Value2 = costRow["PROC_COST"];

                ws.get_Range("D36").Value2 = costRow["MAT_COST"].toDouble() + costRow["PROC_COST"].toDouble();

                ws.get_Range("H36").Value2 = costRow["PROD_COST"];

                ws.get_Range("D38").Value2 = costRow["MNG_COST"];

                ws.get_Range("H38").Value2 = costRow["PROFIT_PRICE"];

                ws.get_Range("L38").Value2 = costRow["PROFIT_RATIO"].toDouble() / 100;

                wb.SaveAs(strFullPathFile);

                wb.Close();

                oXL.Quit();


                releaseObject(xlRange);
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(oXL);


                System.Threading.Thread.Sleep(100);

                if (acMessageBox.Show(this, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strFullPathFile);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                GC.Collect();

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private void acSimpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ExportXls();

                return;

                //DataRow focus = acGridView3.GetFocusedDataRow();

                //DataRow MatRow = acMaterial1.SelectedRow;

                //if (focus == null) return;

                //if (acMessageBox.Show(this, "엑셀 내보내기를 하시겠습니까?", "5DE1YPBV", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                //{
                //    return;
                //}

                ////공정정보 조회
                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String));
                //paramTable.Columns.Add("PART_CODE", typeof(String));

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["PART_CODE"] = focus["PART_CODE"];

                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //DataSet dsRsltdt = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN01A_SER_STD", paramSet, "RQSTDT", "RSLTDT_PROC,RSLTDT_MC,RSLTDT_EMP");

                //DataTable proc_cost = dsRsltdt.Tables["RSLTDT_PROC"].Copy();

                //SaveFileDialog pFileDlg = new SaveFileDialog();
                //pFileDlg.Filter = "Excel Files (.xls)|*.xls";//Excel Files (.xlsx)|*.xlsx";
                //pFileDlg.Title = "저장할 위치를 입력하여 주십시오.";
                //pFileDlg.FileName = focus["PART_NAME"].ToString() + " - 사전원가 분석표";
                //if (pFileDlg.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}

                //SpreadsheetInfo.SetLicense("EORI-HF5T-MS0D-LVMH");

                //String strFullPathFile = pFileDlg.FileName;

                ////Resource 엑셀파일
                //ExcelFile xlsFile = new ExcelFile();

                ////불러온 엑셀 파일
                //ExcelFile xlsFile2 = new ExcelFile();

                //Stream stream = new MemoryStream(Resource.CostAnalysisTable);


                ////xlsFile.LoadXlsx(stream, XlsxOptions.PreserveMakeCopy);
                //xlsFile.LoadXls(stream);
                //stream.Close();

                //string year = acDateEdit.GetNowDateFromServer().toDateString("yyyy");
                //string month = acDateEdit.GetNowDateFromServer().toDateString("MM");
                //string day = acDateEdit.GetNowDateFromServer().toDateString("dd");

                //DataRow partRow = acLayoutControl2.CreateParameterRow();

                //DataRow costRow = acLayoutControl3.CreateParameterRow();

                //ExcelWorksheet ws = null;

                ////Resource 엑셀파일 첫Sheet 복사 생성
                //ExcelWorksheet copy_ws = xlsFile.Worksheets[0];

                //bool isFile = File.Exists(strFullPathFile);

                //if (isFile)
                //{
                //    Stream stream2 = File.Open(strFullPathFile, FileMode.Open, FileAccess.ReadWrite);

                //    xlsFile2.LoadXls(stream2);
                //    stream2.Close();

                //    int idx = xlsFile2.Worksheets.Count;

                //    int idx2 = idx + 1;

                //    xlsFile2.Worksheets.AddCopy("sheet" + idx2, copy_ws);

                //    ws = xlsFile2.Worksheets[idx];
                //}
                //else
                //{
                //    ws = xlsFile.Worksheets[0];
                //}

                ////
                ////ExcelPicture pic = ws.Pictures
                ////(acLayoutControl1.GetEditor("C_IMG").Editor as acPictureEdit).Image.Save(C_IMG, System.Drawing.Imaging.ImageFormat.Jpeg);
                ////ws.Pictures.Add(C_IMG, PositioningMode.FreeFloating, new AnchorCell(ws.Columns[27], ws.Rows[21], 10, 10), new AnchorCell(ws.Columns[33], ws.Rows[26], false), ExcelPictureFormat.Jpeg);                 

                //MemoryStream sign = new MemoryStream();

                ////System.Drawing.Bitmap bitmap = new Bitmap(Resource.sign);

                //(Resource.sign).Save(sign, System.Drawing.Imaging.ImageFormat.Jpeg);
                ////bitmap.Save(sign, System.Drawing.Imaging.ImageFormat.Jpeg);

                ////var picture = new MemoryStream(Resource.sign);

                //ws.Pictures.Add(sign, PositioningMode.FreeFloating, new AnchorCell(ws.Columns[7], ws.Rows[0], 10, 10), new AnchorCell(ws.Columns[12], ws.Rows[0], false), ExcelPictureFormat.Jpeg);
                ////ws.Pictures.Add(picture, PositioningMode.FreeFloating, new AnchorCell(ws.Columns[7], ws.Rows[0], 10, 10));


                ////내용 작성
                //ws.Cells[1, 0].Value = "작 성 일 : " + year + "년 " + month + "월 " + day + "일";

                //ws.Cells[3, 2].Value = acVendor1.Text;

                //ws.Cells[3, 8].Value = costRow["FAC_PRICE"];

                //ws.Cells[5, 2].Value = partRow["DRAW_NO"];

                //ws.Cells[5, 8].Value = partRow["MAT_SPEC1"];

                //ws.Cells[6, 2].Value = partRow["PART_NAME"];

                //ws.Cells[6, 8].Value = partRow["MAT_SPEC"];

                //ws.Cells[7, 2].Value = MatRow["MQLTY_NAME"];

                //ws.Cells[7, 8].Value = partRow["BAL_WEIGHT"];

                //ws.Cells[8, 2].Value = partRow["MAT_UC"];

                //ws.Cells[8, 8].Value = partRow["MAT_COST"];

                //for (int i = 0; i < 17; i++)
                //{
                //    foreach (DataRow row in proc_cost.Rows)
                //    {
                //        if (ws.Cells[13 + i, 1].Value.toStringEmpty() == row["PROC_NAME"].ToString())
                //        {
                //            ws.Cells[13 + i, 3].Value = row["PROC_TIME"];
                //            ws.Cells[13 + i, 5].Value = row["PROC_UC"];
                //            ws.Cells[13 + i, 7].Value = row["PROC_COST"];
                //            ws.Cells[13 + i, 8].Value = row["SCOMMENT"];
                //        }
                //    }
                //}

                //ws.Cells[30, 7].Value = costRow["JIG_COST"];
                //ws.Cells[30, 8].Value = costRow["JIG_CONTENTS"];

                //ws.Cells[31, 7].Value = costRow["ETC_COST"];
                //ws.Cells[31, 8].Value = costRow["ETC_CONTENTS"];


                //ws.Cells[33, 3].Value = costRow["MAT_COST"];
                //ws.Cells[33, 7].Value = costRow["PROC_COST"];

                //ws.Cells[35, 3].Value = costRow["MAT_COST"].toDouble() + costRow["PROC_COST"].toDouble();
                //ws.Cells[35, 7].Value = costRow["PROD_COST"];

                //ws.Cells[37, 3].Value = costRow["MNG_COST"];
                //ws.Cells[37, 7].Value = costRow["PROFIT_PRICE"];
                //ws.Cells[37, 11].Value = costRow["PROFIT_RATIO"].toDouble() / 100;

                ////엑셀 파일 저장
                //if (isFile)
                //{

                //    xlsFile2.Worksheets.ActiveWorksheet = ws;

                //    if (pFileDlg.FilterIndex == 1)
                //    {
                //        xlsFile2.SaveXls(strFullPathFile);
                //    }
                //    else
                //    {
                //        xlsFile2.SaveXlsx(strFullPathFile);
                //    }
                //}
                //else
                //{
                //    int cnt = xlsFile.Worksheets.Count;

                //    ////최초생성시 불필요 sheet 삭제
                //    //for (int i = 1; i < cnt; i++)
                //    //{
                //    //    xlsFile.Worksheets[1].Delete();
                //    //}

                //    xlsFile.Worksheets.ActiveWorksheet = ws;

                //    if (pFileDlg.FilterIndex == 1)
                //    {
                //        xlsFile.SaveXls(strFullPathFile);
                //    }
                //    else
                //    {
                //        xlsFile.SaveXlsx(strFullPathFile);
                //    }
                //}


                ////if (acMessageBox.Show(this, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                ////{
                //    System.Diagnostics.Process.Start(strFullPathFile);
                ////}

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSplitContainerControl2_Panel2_Resize(object sender, EventArgs e)
        {
            int splitWidth = acSplitContainerControl2.Panel2.Width;

            acLayoutControl5.Width = splitWidth / 3;
        }

        private void SaveJajuSeq()
        {
            DataTable dt = acGridView2.GridControl.DataSource as DataTable;
            if (dt != null)
            {
                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("INS_CODE", typeof(String));
                paramTable.Columns.Add("INS_SEQ", typeof(Int32));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = dt.Rows[i]["PART_CODE"];
                    paramRow["INS_CODE"] = dt.Rows[i]["INS_CODE"];
                    paramRow["INS_SEQ"] = i;
                    paramTable.Rows.Add(paramRow);
                }

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01A_INS6", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

