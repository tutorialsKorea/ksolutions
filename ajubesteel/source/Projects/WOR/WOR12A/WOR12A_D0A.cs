using BizManager;
using CodeHelperManager;
using ControlManager;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR12A_D0A : BaseMenuDialog
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

        DataRow _linkRow = null;

        acGridView _linkView = null;

        DataTable _stdHoliTable = null;

        DataTable _workTable = null;

        string _workYear = "";

        public WOR12A_D0A(acGridView linkView, DataRow linkRow, string year)
        {
            InitializeComponent();

            _linkView = linkView;
            _linkRow = linkRow;
            _workYear = year;

            (acLayoutControl2.GetEditor("YEAR") as acDateEdit).Properties.UseMaskAsDisplayFormat = true;
            (acLayoutControl2.GetEditor("YEAR") as acDateEdit).Properties.EditMask = "yyyy";

            (acLayoutControl4.GetEditor("MONTH_DATE") as acDateEdit).Properties.UseMaskAsDisplayFormat = true;
            (acLayoutControl4.GetEditor("MONTH_DATE") as acDateEdit).Properties.EditMask = "yyyy-MM";

            (acLayoutControl4.GetEditor("DAY_DATE") as acDateEdit).Value = acDateEdit.GetNowDateFromServer();
            (acLayoutControl4.GetEditor("MONTH_DATE") as acDateEdit).Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl2.GetEditor("YEAR").Value = new DateTime(_workYear.toInt(), 1, 1, 0, 0, 0);
            acLayoutControl2.GetEditor("YEAR").isReadyOnly = true;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("DATE_PERIOD", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PLAN_MONTH", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("1", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("2", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("3", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("4", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("5", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("6", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("7", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("8", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("9", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("10", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("11", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("12", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("13", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("14", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("15", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("16", " ", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;


            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;
            acGridView1.ShowingEditor += acGridView1_ShowingEditor;
                                   
            acLayoutControl2.OnValueChanged += acLayoutControl2_OnValueChanged;

            if (_linkRow != null)
            {
                acLayoutControl2.GetEditor("EMP_CODE").Value = _linkRow["EMP_CODE"];
                acLayoutControl2.GetEditor("EMP_CODE").isReadyOnly = true;

                _workYear = _linkRow["WORK_YEAR"].ToString();

                acLayoutControl4.DataBind(_linkRow, false);
            }

            acWeekDate1.SetType(acWeekDate.DateType.WEEK);
            acWeekDate1.SetWeekOnly();

            base.DialogInit();
        }

        private void acLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    break;
            }
        }

        private void acGridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;
                foreach (acGridColumn col in acGridView1.Columns)
                {
                    if (col.FieldName.isNumeric()
                        && col.FieldName == gridView.FocusedColumn.FieldName)
                    {
                        string caption = acGridView1.GetRowCellValue(gridView.FocusedRowHandle, col.FieldName).ToString();

                        if (caption == "")
                        {
                            e.Cancel = true;
                        }
                    }
                }

            }
            catch
            {
            }
        }

        private void acGridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            foreach (acGridColumn col in acGridView1.Columns)
            {
                if (col.FieldName.isNumeric()
                    && col.FieldName == e.Column.FieldName)
                {
                    string caption = acGridView1.GetRowCellValue(e.RowHandle, col.FieldName).ToString();

                    if (caption != "")
                    {
                        RepositoryItemButtonEdit ri = new RepositoryItemButtonEdit();

                        ri.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                        ri.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                        ri.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
                        ri.Buttons[0].Caption = caption;
                        ri.Buttons[0].Appearance.ForeColor = Color.Black;
                        ri.ButtonClick += WorkCheck_ButtonClick;

                        string month = acGridView1.GetRowCellValue(e.RowHandle, "WORK_MONTH").ToString();
                        if (col.FieldName.isNumeric())
                        {
                            string day = acGridView1.GetRowCellValue(e.RowHandle, col.FieldName).ToString().PadLeft(2, '0');

                            if (_stdHoliTable != null)
                            {
                                DataRow[] rows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");

                                DateTime dt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);

                                if (rows.Length > 0
                                    || dt.DayOfWeek == DayOfWeek.Saturday
                                    || dt.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (e.Column.FieldName == col.FieldName)
                                    {
                                        ri.Buttons[0].Enabled = false;
                                        ri.Buttons[0].Appearance.ForeColor = Color.Red;
                                        ri.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Caramel);
                                    }
                                }
                            }

                            if (_workTable != null)
                            {
                                DataRow[] rows = _workTable.Select("EWT_DATE = '" + month + day + "' AND EWT_TYPE = '1'");

                                if (rows.Length > 0)
                                {
                                    if (e.Column.FieldName == col.FieldName)
                                    {
                                        ri.Buttons[0].Appearance.ForeColor = Color.White;
                                        ri.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Darkroom);
                                    }
                                }
                            }
                        }
                        
                        e.RepositoryItem = ri;
                    }
                    else
                    {
                        RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
                        e.RepositoryItem = txt;
                    }
                }
                
            }
        }

        private void WorkCheck_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                if (layoutRow["EMP_CODE"].ToString() == "")
                {
                    acMessageBox.Show(this, "사원이 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, "DATE_PERIOD");
                    return;
                }

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                string workdate = focusRow["WORK_MONTH"].ToString();
                string day = acGridView1.GetRowCellValue(acGridView1.FocusedRowHandle, acGridView1.FocusedColumn).ToString().PadLeft(2, '0');
                workdate = workdate + day;

                if (_workTable != null)
                {
                    DataRow[] rows = _workTable.Select("EWT_DATE = '" + workdate + "'");

                    if (rows.Length > 0)
                    {
                        if (rows[0]["EWT_TYPE"].ToString() == "1")
                        {
                            rows[0]["EWT_TYPE"] = "0";
                        }
                        else if (rows[0]["EWT_TYPE"].ToString() == "0")
                        {
                            rows[0]["EWT_TYPE"] = "1";
                        }

                    }
                    else
                    {
                        DataRow newRow = _workTable.NewRow();
                        newRow["PLT_CODE"] = acInfo.PLT_CODE;
                        if (_linkRow != null)
                        {
                            newRow["EWT_NO"] = _linkRow["EWT_NO"];
                        }
                        newRow["EWT_DATE"] = workdate;
                        newRow["EWT_TYPE"] = "1";
                        _workTable.Rows.Add(newRow);
                    }
                }
                else
                {
                    _workTable = new DataTable();
                    _workTable.Columns.Add("PLT_CODE", typeof(String));
                    _workTable.Columns.Add("EWT_NO", typeof(String));
                    _workTable.Columns.Add("EWT_DATE", typeof(String));
                    _workTable.Columns.Add("EWT_TYPE", typeof(String));
                    DataRow newRow = _workTable.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;

                    if (_linkRow != null)
                    {
                        newRow["EWT_NO"] = _linkRow["EWT_NO"];
                    }
                    newRow["EWT_DATE"] = workdate;
                    newRow["EWT_TYPE"] = "1";
                    _workTable.Rows.Add(newRow);
                }

                acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, "DATE_PERIOD");
            }
            catch { }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (_stdHoliTable == null) return;

            string month = acGridView1.GetRowCellValue(e.RowHandle, "WORK_MONTH").ToString();

            foreach(acGridColumn col in acGridView1.Columns)
            {
                if (!col.FieldName.isNumeric())
                {
                    continue;
                }
                //string day = col.FieldName.PadLeft(2, '0');
                string day = acGridView1.GetRowCellValue(e.RowHandle, col.FieldName).ToString().PadLeft(2, '0');

                if (day == "00") continue;

                DataRow[] rows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");

                DateTime dt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);

                if (rows.Length > 0
                    || dt.DayOfWeek == DayOfWeek.Saturday
                    || dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (e.Column.FieldName == col.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //}
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            int iMonth = 1;

            DateTime startDate = new DateTime(_workYear.toInt(), iMonth, 1, 0, 0, 0);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WORK_MON", typeof(string));
            paramTable.Columns.Add("WORK_MONTH", typeof(string));
            paramTable.Columns.Add("EWT_NO", typeof(string));

            for (int i = 0; i < 12; i++)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_MON"] = startDate.toDateString("yyyyMM");
                paramRow["WORK_MONTH"] = startDate.toDateString("yyyy-MM");

                if (_linkRow != null)
                {
                    paramRow["EWT_NO"] = _linkRow["EWT_NO"];
                }

                paramTable.Rows.Add(paramRow);
                startDate = startDate.AddMonths(1);
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR12A_SER2", paramSet, "RQSTDT", "RSLTDT");

            _stdHoliTable = resultSet.Tables["RSLTDT_HOLI"];

            _workTable = resultSet.Tables["RSLTDT_WORK"];

            if (resultSet.Tables["RSLTDT_WORK"].Rows.Count == 0)
            {
                _workTable = null;
            }

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView1.BestFitColumns();


            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                string month = row["WORK_MONTH"].ToString();

                foreach (acGridColumn col in acGridView1.Columns)
                {
                    if (!col.FieldName.isNumeric())
                    {
                        continue;
                    }
                    //string day = col.FieldName.PadLeft(2, '0');
                    string day = row[col.FieldName].ToString().PadLeft(2, '0');

                    if (day == "00") continue;

                    DataRow[] rows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");

                    DateTime dt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);

                    if (rows.Length == 0
                        && dt.DayOfWeek != DayOfWeek.Saturday
                        && dt.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (_workTable == null)
                        {
                            _workTable = new DataTable();
                            _workTable.Columns.Add("PLT_CODE", typeof(String));
                            _workTable.Columns.Add("EWT_NO", typeof(String));
                            _workTable.Columns.Add("EWT_DATE", typeof(String));
                            _workTable.Columns.Add("EWT_TYPE", typeof(String));

                            DataRow newRow = _workTable.NewRow();
                            newRow["PLT_CODE"] = acInfo.PLT_CODE;
                            newRow["EWT_DATE"] = dt.toDateString("yyyyMMdd");
                            newRow["EWT_TYPE"] = "0";
                            _workTable.Rows.Add(newRow);
                        }
                        else
                        {
                            DataRow newRow = _workTable.NewRow();
                            newRow["PLT_CODE"] = acInfo.PLT_CODE;
                            newRow["EWT_DATE"] = dt.toDateString("yyyyMMdd");
                            newRow["EWT_TYPE"] = "0";
                            _workTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //acLayoutControl1.DataBind(_linkRow, true);

            //DateTime nowDT = acDateEdit.GetNowFirstYear();

            int iMonth = 1;

            DateTime startDate = new DateTime(_linkRow["WORK_YEAR"].toInt(), iMonth, 1, 0, 0, 0);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("WORK_MON", typeof(string));
            paramTable.Columns.Add("WORK_MONTH", typeof(string));
            paramTable.Columns.Add("EWT_NO", typeof(string));

            for (int i = 0; i < 12; i++)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_MON"] = startDate.toDateString("yyyyMM");
                paramRow["WORK_MONTH"] = startDate.toDateString("yyyy-MM");

                if (_linkRow != null)
                {
                    paramRow["EWT_NO"] = _linkRow["EWT_NO"];
                }

                paramTable.Rows.Add(paramRow);
                startDate = startDate.AddMonths(1);
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR12A_SER2", paramSet, "RQSTDT", "RSLTDT");

            _stdHoliTable = resultSet.Tables["RSLTDT_HOLI"];

            _workTable = resultSet.Tables["RSLTDT_WORK"];

            if (resultSet.Tables["RSLTDT_WORK"].Rows.Count == 0)
            {
                _workTable = null;

                foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
                {
                    string month = row["WORK_MONTH"].ToString();

                    foreach (acGridColumn col in acGridView1.Columns)
                    {
                        if (!col.FieldName.isNumeric())
                        {
                            continue;
                        }
                        //string day = col.FieldName.PadLeft(2, '0');
                        string day = row[col.FieldName].ToString().PadLeft(2, '0');

                        if (day == "00") continue;

                        DataRow[] rows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");

                        DateTime dt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);

                        if (rows.Length == 0
                            && dt.DayOfWeek != DayOfWeek.Saturday
                            && dt.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (_workTable == null)
                            {
                                _workTable = new DataTable();
                                _workTable.Columns.Add("PLT_CODE", typeof(String));
                                _workTable.Columns.Add("EWT_NO", typeof(String));
                                _workTable.Columns.Add("EWT_DATE", typeof(String));
                                _workTable.Columns.Add("EWT_TYPE", typeof(String));

                                DataRow newRow = _workTable.NewRow();
                                newRow["PLT_CODE"] = acInfo.PLT_CODE;
                                newRow["EWT_DATE"] = dt.toDateString("yyyyMMdd");
                                newRow["EWT_TYPE"] = "0";
                                _workTable.Rows.Add(newRow);
                            }
                            else
                            {
                                DataRow newRow = _workTable.NewRow();
                                newRow["PLT_CODE"] = acInfo.PLT_CODE;
                                newRow["EWT_DATE"] = dt.toDateString("yyyyMMdd");
                                newRow["EWT_TYPE"] = "0";
                                _workTable.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView1.BestFitColumns();


            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl2.ValidCheck() == false) return;

                DataRow empRow = acLayoutControl2.CreateParameterRow();

                DataRow seqRow = acLayoutControl4.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable.Columns.Add("EWT_NO", typeof(string)); //
                paramTable.Columns.Add("WORK_YEAR", typeof(string)); //
                paramTable.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable.Columns.Add("OVERWRITE", typeof(string)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EWT_NO"] = null;
                paramRow["WORK_YEAR"] = _workYear;
                paramRow["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow["OVERWRITE"] = "0";

                paramTable.Rows.Add(paramRow);

                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable2.Columns.Add("EWT_NO", typeof(string)); //
                paramTable2.Columns.Add("EWT_DATE", typeof(string)); //
                paramTable2.Columns.Add("EWT_TYPE", typeof(string)); //

                if (_workTable != null)
                {
                    foreach (DataRow row in _workTable.Rows)
                    {
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["EWT_NO"] = null;
                        paramRow2["EWT_DATE"] = row["EWT_DATE"];
                        paramRow2["EWT_TYPE"] = row["EWT_TYPE"];

                        paramTable2.Rows.Add(paramRow2);
                    }
                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR12A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, true);
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
            //저장 후 닫기
            try
            {
                if (acLayoutControl2.ValidCheck() == false) return;

                DataRow empRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable.Columns.Add("EWT_NO", typeof(string)); //
                paramTable.Columns.Add("WORK_YEAR", typeof(string)); //
                paramTable.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable.Columns.Add("OVERWRITE", typeof(string)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EWT_NO"] = _linkRow["EWT_NO"];
                paramRow["WORK_YEAR"] = _workYear;
                paramRow["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);


                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable2.Columns.Add("EWT_NO", typeof(string)); //
                paramTable2.Columns.Add("EWT_DATE", typeof(string)); //
                paramTable2.Columns.Add("EWT_TYPE", typeof(string)); //

                if (_workTable != null)
                {
                    foreach (DataRow row in _workTable.Rows)
                    {
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["EWT_NO"] = _linkRow["EWT_NO"];
                        paramRow2["EWT_DATE"] = row["EWT_DATE"];
                        paramRow2["EWT_TYPE"] = row["EWT_TYPE"];

                        paramTable2.Rows.Add(paramRow2);
                    }
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR12A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

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
                    _linkView.UpdateMapingRow(row, false);
                }

                _linkView.RaiseFocusedRowChanged();
                this.Close();
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
            else if (ex.ErrNumber == 300000)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //일적용

            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            DataRow[] rows = _workTable.Select("EWT_DATE = '" + layoutRow["DAY_DATE"].ToString() + "'");

            if (rows.Length > 0)
            {
                if (rows[0]["EWT_TYPE"].ToString() == "0")
                {
                    rows[0]["EWT_TYPE"] = "1";
                }
                else if (rows[0]["EWT_TYPE"].ToString() == "1")
                {
                    rows[0]["EWT_TYPE"] = "0";
                }
            }

            acGridView1.RefreshData();

        }

        private void acSimpleButton2_Click_1(object sender, EventArgs e)
        {
            //월적용

            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            DataRow[] rows = _workTable.Select("EWT_DATE >= '" + layoutRow["MONTH_DATE"].ToString() + "01" + "' AND EWT_DATE <= '" + layoutRow["MONTH_DATE"].ToString() + "31" + "'");

            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    if (row["EWT_TYPE"].ToString() == "0")
                    {
                        row["EWT_TYPE"] = "1";
                    }
                    else if (row["EWT_TYPE"].ToString() == "1")
                    {
                        row["EWT_TYPE"] = "0";
                    }
                }
            }

            acGridView1.RefreshData();
        }

        private void acSimpleButton3_Click(object sender, EventArgs e)
        {
            //주차적용

            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            DataRow weekRow = acWeekDate1.WeekRow;

            DataRow[] rows = _workTable.Select("EWT_DATE >= '" + weekRow["START_TIME"].toDateString("yyyyMMdd") + "' AND EWT_DATE <= '" + weekRow["END_TIME"].toDateString("yyyyMMdd") + "'");

            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    if (row["EWT_TYPE"].ToString() == "0")
                    {
                        row["EWT_TYPE"] = "1";
                    }
                    else if (row["EWT_TYPE"].ToString() == "1")
                    {
                        row["EWT_TYPE"] = "0";
                    }
                }
            }

            acGridView1.RefreshData();
        }
    }
}