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
    public sealed partial class WOR04A_D0A : BaseMenuDialog
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

        DataTable _holiTable = null;

        string _planYear = "";

        public WOR04A_D0A(acGridView linkView, DataRow linkRow)
        {
            InitializeComponent();

            _linkView = linkView;
            _linkRow = linkRow;
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

            //DateTime nowDT = acDateEdit.GetNowFirstYear();

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(string));
            //paramTable.Columns.Add("PLAN_MON", typeof(string));
            //paramTable.Columns.Add("PLAN_MONTH", typeof(string));
            //paramTable.Columns.Add("PLAN_NO", typeof(string));

            //for (int i = 0; i < 6; i++)
            //{
            //    DataRow paramRow = paramTable.NewRow();
            //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow["PLAN_MON"] = nowDT.toDateString("yyyyMM");
            //    paramRow["PLAN_MONTH"] = nowDT.toDateString("yyyy-MM");

            //    if (_linkRow != null)
            //    {
            //        paramRow["PLAN_NO"] = _linkRow["PLAN_NO"];
            //    }

            //    paramTable.Rows.Add(paramRow);
            //    nowDT = nowDT.AddMonths(1);
            //}


            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR04A_SER2", paramSet, "RQSTDT", "RSLTDT");

            //_stdHoliTable = resultSet.Tables["RSLTDT_HOLI"];

            //_holiTable = resultSet.Tables["RSLTDT_PLAN"];

            //if (resultSet.Tables["RSLTDT_PLAN"].Rows.Count == 0)
            //{
            //    _holiTable = null;
            //}

            //acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            //acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

            //acGridView1.BestFitColumns();

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;


            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;
            acGridView1.ShowingEditor += acGridView1_ShowingEditor;

            //(acLayoutControl4.GetEditor("START_DATE") as acDateEdit).Properties.UseMaskAsDisplayFormat = true;
            //(acLayoutControl4.GetEditor("START_DATE") as acDateEdit).Properties.EditMask = "yyyy-MM";

            //acLayoutControl4.GetEditor("START_DATE").Value = acDateEdit.GetNowFirstYear();
            acLayoutControlItem9.Text = acDateEdit.GetNowFirstYear().Year.ToString() + " 발생연차";
            _planYear = acDateEdit.GetNowFirstYear().Year.ToString();

            (acLayoutControl4.GetEditor("PLAN_SEQ") as acLookupEdit).SetCode("W009");

            (acLayoutControl2.GetEditor("EMP_TITLE").Editor as acLookupEdit).SetCode("C040");
                        
            acLayoutControl2.OnValueChanged += acLayoutControl2_OnValueChanged;

            if (_linkRow != null)
            {
                acLayoutControl2.GetEditor("EMP_CODE").Value = _linkRow["EMP_CODE"];
                acLayoutControl2.GetEditor("EMP_CODE").isReadyOnly = true;

                //DateTime dt = new DateTime(_linkRow["PLAN_YEAR"].toInt(), 1, 1);
                //acLayoutControl4.GetEditor("START_DATE").Value = dt;
                acLayoutControlItem9.Text = _linkRow["PLAN_YEAR"].ToString() + " 발생연차";
                _planYear = _linkRow["PLAN_YEAR"].ToString();

                //acLayoutControl4.GetEditor("MONTH_PERIOD").isReadyOnly = true;
                //acLayoutControl4.GetEditor("START_DATE").isReadyOnly = true;
                //acLayoutControl4.GetEditor("START_DATE").isReadyOnly = true;
                acLayoutControl4.GetEditor("PLAN_SEQ").isReadyOnly = true;
                acSimpleButton2.Enabled = false;
                acLayoutControl3.DataBind(_linkRow, false);
                acLayoutControl4.DataBind(_linkRow, false);
            }

            base.DialogInit();
        }

        private void acLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    if (newValue == null) return;

                    DataRow empRow = (layout.GetEditor("EMP_CODE") as acEmp).SelectedRow;

                    layout.DataBind(empRow, false);

                    DataRow layoutRow = acLayoutControl4.CreateParameterRow();

                    DateTime nowDateTime = acDateEdit.GetNowDateFromServer();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("EMP_CODE", typeof(string));
                    paramTable.Columns.Add("REQ_YEAR", typeof(string));
                    paramTable.Columns.Add("COMPARE_YEAR", typeof(string));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = newValue;
                    paramRow["REQ_YEAR"] = nowDateTime.toDateString("yyyy");
                    paramRow["COMPARE_YEAR"] = nowDateTime.toDateString("yyyy").toInt() - DateTime.Now.Year;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR04A_SER3", paramSet, "RQSTDT", "RSLTDT");

                    //if (resultSet.Tables["RSLTDT_HOLI"].Rows.Count > 0)
                    //{
                        acLayoutControl3.GetEditor("YEAR_HOLI").Value = resultSet.Tables["RSLTDT_HOLI"].Rows.Count > 0 ? resultSet.Tables["RSLTDT_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"] : "0.0";
                    //}

                    //if (resultSet.Tables["RSLTDT_USE_HOLI"].Rows.Count > 0)
                    //{
                        acLayoutControl3.GetEditor("USE_HOLI").Value = resultSet.Tables["RSLTDT_USE_HOLI"].Rows.Count > 0 ? resultSet.Tables["RSLTDT_USE_HOLI"].Rows[0]["HOLI_DAY"] : "0.0";
                    //}
                    
                    double planDay = 0.0;
                    if (_holiTable != null)
                    {
                        if (_holiTable.Rows.Count > 0)
                        {
                            planDay = _holiTable.Compute("sum(PLAN_HOLI)", "").toDouble();
                        }
                    }

                    acLayoutControl3.GetEditor("POS_HOLI").Value = acLayoutControl3.GetEditor("YEAR_HOLI").Value.toDouble() - acLayoutControl3.GetEditor("USE_HOLI").Value.toDouble() - planDay;

                    acLayoutControl3.GetEditor("REQ_HOLI").Value = planDay.ToString();

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
                        ri.ButtonClick += HoliCheck_ButtonClick;

                        string month = acGridView1.GetRowCellValue(e.RowHandle, "PLAN_MONTH").ToString();
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

                            if (_holiTable != null)
                            {
                                DataRow[] rows = _holiTable.Select("PLAN_DATE = '" + month + day + "'");

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

        private void HoliCheck_ButtonClick(object sender, ButtonPressedEventArgs e)
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

                string holidate = focusRow["PLAN_MONTH"].ToString();
                string day = acGridView1.GetRowCellValue(acGridView1.FocusedRowHandle, acGridView1.FocusedColumn).ToString().PadLeft(2, '0');
                holidate = holidate + day;

                if (_holiTable != null)
                {
                    DataRow[] rows = _holiTable.Select("PLAN_DATE = '" + holidate + "'");
                    if (rows.Length > 0)
                    {
                        acLayoutControl3.GetEditor("POS_HOLI").Value = acLayoutControl3.GetEditor("POS_HOLI").Value.toDouble() + rows[0]["PLAN_HOLI"].toDouble();
                        acLayoutControl3.GetEditor("REQ_HOLI").Value = acLayoutControl3.GetEditor("REQ_HOLI").Value.toDouble() - rows[0]["PLAN_HOLI"].toDouble();

                        _holiTable.Rows.Remove(rows[0]);
                    }
                    else
                    {
                        if (acLayoutControl3.GetEditor("POS_HOLI").Value.ToString() == "0")
                        {
                            acMessageBox.Show(this, "가능연차가 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, "DATE_PERIOD");
                            return;
                        }

                        double Value = acLayoutControl3.GetEditor("POS_HOLI").Value.toDouble() == 0.5 ? 0.5 : 1.0;

                        DataRow newRow = _holiTable.NewRow();
                        newRow["PLT_CODE"] = acInfo.PLT_CODE;
                        if (_linkRow != null)
                        {
                            newRow["PLAN_NO"] = _linkRow["PLAN_NO"];
                        }
                        newRow["PLAN_DATE"] = holidate;
                        newRow["PLAN_HOLI"] = Value;
                        _holiTable.Rows.Add(newRow);                        

                        acLayoutControl3.GetEditor("POS_HOLI").Value = acLayoutControl3.GetEditor("POS_HOLI").Value.toDouble() - Value;
                        acLayoutControl3.GetEditor("REQ_HOLI").Value = acLayoutControl3.GetEditor("REQ_HOLI").Value.toDouble() + Value;
                    }
                }
                else
                {
                    if (acLayoutControl3.GetEditor("POS_HOLI").Value.ToString() == "0")
                    {
                        acMessageBox.Show(this, "가능연차가 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, "DATE_PERIOD");
                        return;
                    }

                    double Value = acLayoutControl3.GetEditor("POS_HOLI").Value.toDouble() == 0.5 ? 0.5 : 1.0;

                    _holiTable = new DataTable();
                    _holiTable.Columns.Add("PLT_CODE", typeof(String));
                    _holiTable.Columns.Add("PLAN_NO", typeof(String));
                    _holiTable.Columns.Add("PLAN_DATE", typeof(String));
                    _holiTable.Columns.Add("PLAN_HOLI", typeof(decimal));
                    DataRow newRow = _holiTable.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    if (_linkRow != null)
                    {
                        newRow["PLAN_NO"] = _linkRow["PLAN_NO"];
                    }
                    newRow["PLAN_DATE"] = holidate;
                    newRow["PLAN_HOLI"] = Value;
                    _holiTable.Rows.Add(newRow);

                    acLayoutControl3.GetEditor("POS_HOLI").Value = acLayoutControl3.GetEditor("POS_HOLI").Value.toDouble() - Value;
                    acLayoutControl3.GetEditor("REQ_HOLI").Value = acLayoutControl3.GetEditor("REQ_HOLI").Value.toDouble() + Value;
                }


                acGridView1.SetFocusCell(acGridView1.FocusedRowHandle, "DATE_PERIOD");
            }
            catch { }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (_stdHoliTable == null) return;

            string month = acGridView1.GetRowCellValue(e.RowHandle, "PLAN_MONTH").ToString();

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

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //acLayoutControl1.DataBind(_linkRow, true);

            //DateTime nowDT = acDateEdit.GetNowFirstYear();

            int iMonth = 1;

            if (_linkRow["PLAN_SEQ"].ToString() == "2")
            {
                iMonth = 7;
            }

            DateTime startDate = new DateTime(_linkRow["PLAN_YEAR"].toInt(), iMonth, 1, 0, 0, 0);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PLAN_MON", typeof(string));
            paramTable.Columns.Add("PLAN_MONTH", typeof(string));
            paramTable.Columns.Add("PLAN_NO", typeof(string));

            for (int i = 0; i < 6; i++)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLAN_MON"] = startDate.toDateString("yyyyMM");
                paramRow["PLAN_MONTH"] = startDate.toDateString("yyyy-MM");

                if (_linkRow != null)
                {
                    paramRow["PLAN_NO"] = _linkRow["PLAN_NO"];
                }

                paramTable.Rows.Add(paramRow);
                startDate = startDate.AddMonths(1);
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR04A_SER2", paramSet, "RQSTDT", "RSLTDT");

            _stdHoliTable = resultSet.Tables["RSLTDT_HOLI"];

            _holiTable = resultSet.Tables["RSLTDT_PLAN"];

            if (resultSet.Tables["RSLTDT_PLAN"].Rows.Count == 0)
            {
                _holiTable = null;
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
                DataRow holiRow = acLayoutControl3.CreateParameterRow();

                DataRow seqRow = acLayoutControl4.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable.Columns.Add("PLAN_NO", typeof(string)); //
                paramTable.Columns.Add("PLAN_YEAR", typeof(string)); //
                paramTable.Columns.Add("PLAN_SEQ", typeof(int)); //
                paramTable.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable.Columns.Add("PLAN_STATUS", typeof(string)); //
                paramTable.Columns.Add("YEAR_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("USE_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("POS_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("REQ_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("OVERWRITE", typeof(string)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLAN_NO"] = null;
                paramRow["PLAN_YEAR"] = _planYear;
                paramRow["PLAN_SEQ"] = seqRow["PLAN_SEQ"];
                paramRow["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow["PLAN_STATUS"] = "0";
                paramRow["YEAR_HOLI"] = holiRow["YEAR_HOLI"];
                paramRow["USE_HOLI"] = holiRow["USE_HOLI"];
                paramRow["POS_HOLI"] = holiRow["POS_HOLI"];
                paramRow["REQ_HOLI"] = holiRow["REQ_HOLI"];
                paramRow["OVERWRITE"] = "0";

                paramTable.Rows.Add(paramRow);


                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable2.Columns.Add("PLAN_NO", typeof(string)); //
                paramTable2.Columns.Add("PLAN_DATE", typeof(string)); //
                paramTable2.Columns.Add("PLAN_HOLI", typeof(Decimal)); //

                if (_holiTable != null)
                {
                    foreach (DataRow row in _holiTable.Rows)
                    {
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["PLAN_NO"] = null;
                        paramRow2["PLAN_DATE"] = row["PLAN_DATE"];
                        paramRow2["PLAN_HOLI"] = row["PLAN_HOLI"];

                        paramTable2.Rows.Add(paramRow2);
                    }
                }


                DataTable paramTable3 = new DataTable("RQSTDT_EMP");
                paramTable3.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable3.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable3.Columns.Add("EMP_TITLE", typeof(string)); //
                paramTable3.Columns.Add("HIRE_DATE", typeof(string)); //
                paramTable3.Columns.Add("EMP_REG_NUMBER", typeof(string)); //
                paramTable3.Columns.Add("EMP_ADDRESS", typeof(string)); //

                DataRow paramRow3 = paramTable3.NewRow();
                paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow3["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow3["EMP_TITLE"] = empRow["EMP_TITLE"];
                paramRow3["HIRE_DATE"] = empRow["HIRE_DATE"];
                paramRow3["EMP_REG_NUMBER"] = empRow["EMP_REG_NUMBER"];
                paramRow3["EMP_ADDRESS"] = empRow["EMP_ADDRESS"];

                paramTable3.Rows.Add(paramRow3);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);
                paramSet.Tables.Add(paramTable3);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR04A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                DataRow holiRow = acLayoutControl3.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable.Columns.Add("PLAN_NO", typeof(string)); //
                paramTable.Columns.Add("PLAN_YEAR", typeof(string)); //
                paramTable.Columns.Add("PLAN_SEQ", typeof(int)); //
                paramTable.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable.Columns.Add("PLAN_STATUS", typeof(string)); //
                paramTable.Columns.Add("YEAR_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("USE_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("POS_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("REQ_HOLI", typeof(decimal)); //
                paramTable.Columns.Add("OVERWRITE", typeof(string)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PLAN_NO"] = _linkRow["PLAN_NO"];
                paramRow["PLAN_YEAR"] = _planYear;
                paramRow["PLAN_SEQ"] = _linkRow["PLAN_SEQ"];
                paramRow["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow["PLAN_STATUS"] = "0";
                paramRow["YEAR_HOLI"] = holiRow["YEAR_HOLI"];
                paramRow["USE_HOLI"] = holiRow["USE_HOLI"];
                paramRow["POS_HOLI"] = holiRow["POS_HOLI"];
                paramRow["REQ_HOLI"] = holiRow["REQ_HOLI"];
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);


                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable2.Columns.Add("PLAN_NO", typeof(string)); //
                paramTable2.Columns.Add("PLAN_DATE", typeof(string)); //
                paramTable2.Columns.Add("PLAN_HOLI", typeof(Decimal)); //

                if (_holiTable != null)
                {
                    foreach (DataRow row in _holiTable.Rows)
                    {
                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow2["PLAN_NO"] = _linkRow["PLAN_NO"];
                        paramRow2["PLAN_DATE"] = row["PLAN_DATE"];
                        paramRow2["PLAN_HOLI"] = row["PLAN_HOLI"];

                        paramTable2.Rows.Add(paramRow2);
                    }
                }

                DataTable paramTable3 = new DataTable("RQSTDT_EMP");
                paramTable3.Columns.Add("PLT_CODE", typeof(string)); //
                paramTable3.Columns.Add("EMP_CODE", typeof(string)); //
                paramTable3.Columns.Add("EMP_TITLE", typeof(string)); //
                paramTable3.Columns.Add("HIRE_DATE", typeof(string)); //
                paramTable3.Columns.Add("EMP_REG_NUMBER", typeof(string)); //
                paramTable3.Columns.Add("EMP_ADDRESS", typeof(string)); //

                DataRow paramRow3 = paramTable3.NewRow();
                paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow3["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow3["EMP_TITLE"] = empRow["EMP_TITLE"];
                paramRow3["HIRE_DATE"] = empRow["HIRE_DATE"];
                paramRow3["EMP_REG_NUMBER"] = empRow["EMP_REG_NUMBER"];
                paramRow3["EMP_ADDRESS"] = empRow["EMP_ADDRESS"];

                paramTable3.Rows.Add(paramRow3);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);
                paramSet.Tables.Add(paramTable3);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "WOR04A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                    _linkView.UpdateMapingRow(row, true);
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
                DataRow empRow = acLayoutControl2.CreateParameterRow();

                DataRow seqRow = acLayoutControl4.CreateParameterRow();

                if (seqRow["PLAN_SEQ"].ToString() == "") return;

                if (empRow["EMP_CODE"].ToString() == "")
                {
                    acMessageBox.Show(this, "사원이 선택되지 않았습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (acMessageBox.Show(this, "계획기간을 갱신하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                
                DataRow layoutRow = acLayoutControl4.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PLAN_MON", typeof(string));
                paramTable.Columns.Add("PLAN_MONTH", typeof(string));
                paramTable.Columns.Add("PLAN_NO", typeof(string));

                DateTime startDate = acDateEdit.GetNowDateFromServer();

                for (int i = 0; i < 6; i++)
                {
                    //if (layoutRow["START_DATE"].toDateTime().Year != layoutRow["START_DATE"].toDateTime().AddMonths(i).Year)
                    //{
                    //    break;
                    //}

                    if (seqRow["PLAN_SEQ"].ToString() == "1")
                    {
                        startDate = new DateTime(startDate.Year, 1, 1, 0, 0, 0);
                    }
                    else if (seqRow["PLAN_SEQ"].ToString() == "2")
                    {
                        startDate = new DateTime(startDate.Year, 7, 1, 0, 0, 0);
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PLAN_MON"] = startDate.AddMonths(i).toDateString("yyyyMM");
                    paramRow["PLAN_MONTH"] = startDate.AddMonths(i).toDateString("yyyy-MM");

                    if (_linkRow != null)
                    {
                        paramRow["PLAN_NO"] = _linkRow["PLAN_NO"];
                    }

                    paramTable.Rows.Add(paramRow);
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR04A_SER2", paramSet, "RQSTDT", "RSLTDT");

                _stdHoliTable = resultSet.Tables["RSLTDT_HOLI"];

                acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

                acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

                if (_holiTable != null)
                {
                    _holiTable.Rows.Clear();
                }

                DataTable paramTable2 = new DataTable("RQSTDT");
                paramTable2.Columns.Add("PLT_CODE", typeof(string));
                paramTable2.Columns.Add("EMP_CODE", typeof(string));
                paramTable2.Columns.Add("REQ_YEAR", typeof(string));
                paramTable2.Columns.Add("COMPARE_YEAR", typeof(string));

                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["EMP_CODE"] = empRow["EMP_CODE"];
                paramRow2["REQ_YEAR"] = startDate.toDateString("yyyy");
                paramRow2["COMPARE_YEAR"] = startDate.toDateString("yyyy").toInt() - DateTime.Now.Year;
                paramTable2.Rows.Add(paramRow2);

                DataSet paramSet2 = new DataSet();
                paramSet2.Tables.Add(paramTable2);

                DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "WOR04A_SER3", paramSet2, "RQSTDT", "RSLTDT");


                acLayoutControlItem9.Text = startDate.toDateString("yyyy") + " 발생연차";
                _planYear = startDate.toDateString("yyyy");
                //if (resultSet.Tables["RSLTDT_HOLI"].Rows.Count > 0)
                //{
                acLayoutControl3.GetEditor("YEAR_HOLI").Value = resultSet2.Tables["RSLTDT_HOLI"].Rows.Count > 0 ? resultSet2.Tables["RSLTDT_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"] : "0.0";
                //}

                //if (resultSet.Tables["RSLTDT_USE_HOLI"].Rows.Count > 0)
                //{
                acLayoutControl3.GetEditor("USE_HOLI").Value = resultSet2.Tables["RSLTDT_USE_HOLI"].Rows.Count > 0 ? resultSet2.Tables["RSLTDT_USE_HOLI"].Rows[0]["HOLI_DAY"] : "0.0";
                //}

                acLayoutControl3.GetEditor("POS_HOLI").Value = acLayoutControl3.GetEditor("YEAR_HOLI").Value.toDouble() - acLayoutControl3.GetEditor("USE_HOLI").Value.toDouble();
                acLayoutControl3.GetEditor("REQ_HOLI").Value = "0.0";

                acGridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}