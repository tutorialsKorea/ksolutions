﻿using BizManager;
using ControlManager;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Windows.Forms;

namespace SAN
{
    public sealed partial class SAN01A_D1A : BaseMenuDialog
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
        private acGridView _LinkView = null;

        private DataSet _WorkSet = null;
        private DataSet _HoliSet = null;
        private DataSet _IdleSet = null;

        private string _EmpCode = "";

        public SAN01A_D1A(acGridView linkView, object linkData, string empCode)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;

            _EmpCode = empCode;

            acLayoutControl1.GetEditor("EMP_CODE").Value = _EmpCode;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.AddTextEdit("DATE", "날짜", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns[0].Visible = false;

            acGridView1.OptionsView.ShowColumnHeaders = false;

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD25A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("WORK_CODE") as acLookupEdit).SetData("WORK_NAME", "WORK_CODE", resultSet.Tables["RSLTDT"]);
            (acLayoutControl1.GetEditor("WORK_CODE") as acLookupEdit).Properties.DropDownRows = resultSet.Tables["RSLTDT"].Rows.Count;

            _WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            _HoliSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER3", acInfo.RefData, "RQSTDT", "RSLTDT");

            _IdleSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER6", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("REQ_AMPM") as acLookupEdit).SetCode("W005");

            (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).SetCode("W006");
            DataTable sDT = (DataTable)(acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Properties.DataSource;
            (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Properties.DropDownRows = sDT.Rows.Count;

            (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).SetCode("W007");

            (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).SetCode("W006");
            DataTable eDT = (DataTable)(acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Properties.DataSource;
            (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Properties.DropDownRows = eDT.Rows.Count;

            (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).SetCode("W007");

            //외근구분
            (acLayoutControl1.GetEditor("OUT_TYPE") as acLookupEdit).SetCode("W011");

            //(acLayoutControl1.GetEditor("SCOMMNET_SEL") as acLookupEdit).SetCode("W010"); 
            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            SetItemSize(acLayoutControlItem23, 10);
            SetItemSize(acLayoutControlItem1);
            SetItemSize(acLayoutControlItem2, 20);
            SetItemSize(acLayoutControlItem4, 20);

            SetItemSize(acLayoutControlItem5, 70);
            SetItemSize(acLayoutControlItem6, 70);
            SetItemSize(acLayoutControlItem7, 70);
            SetItemSize(acLayoutControlItem8, 70);
            SetItemSize(acLayoutControlItem9, 70);
            SetItemSize(acLayoutControlItem11, 70);
            SetItemSize(acLayoutControlItem12, 70);

            SetItemSize(acLayoutControlItem13, 20);
            SetItemSize(acLayoutControlItem14);

            SetItemSize(acLayoutControlItem17, 40);
            SetItemSize(acLayoutControlItem18, 40);

            SetItemSize(acLayoutControlItem22, -60);
            SetItemSize(acLayoutControlItem25);

            SetItemSize(acLayoutControlItem27);

            SetItemSize(acLayoutControlItem28, 20);

            acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            acTextEdit1.Properties.Mask.EditMask = "N0";
            acTextEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            acTextEdit1.Properties.EditFormat.FormatString = "N0";
            acTextEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;


            acTextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            acTextEdit2.Properties.Mask.EditMask = "N0";
            acTextEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            acTextEdit2.Properties.EditFormat.FormatString = "N0";
            acTextEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            SetValidControl(acLayoutControl1, true, false, false, false, false, false, false, false, false, false, false, false, false, false, null);

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            base.DialogInit();
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string type = acGridView1.GetRowCellValue(e.RowHandle, "TYPE").ToString();

            if (type == "휴일")
            {
                e.Appearance.BackColor = System.Drawing.Color.OrangeRed;
                e.Appearance.ForeColor = System.Drawing.Color.White;
            }
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "WORK_CODE":

                    if (_WorkSet == null) return;

                    if (newValue == null)
                    {
                        SetValidControl(layout, true, true, true, true, true, true, true, true, false, false, false, false, false, false, null);
                        (layout.GetEditor("SCOMMNET_SEL") as acLookupEdit).Clear();
                        (layout.GetEditor("SCOMMENT") as acMemoEdit).Clear();
                        return;
                    }

                    layout.GetEditor("E_REQ_DATE").isReadyOnly = false;

                    DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + newValue.ToString() + "'");

                    if (workRows.Length == 1)
                    {
                        switch (workRows[0]["INPUT_TYPE"].ToString())
                        {
                            case "A":

                                SetValidControl(layout, true, false, false, true, false, false, false, true, false, false, false, false, false, false, workRows[0]);

                                break;

                            case "B":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false, false, false, workRows[0]);

                                break;

                            case "C":

                                SetValidControl(layout, true, false, false, false, false, false, true, false, false, false, false, false, false, false, workRows[0]);

                                break;

                            case "D":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false, false, false, workRows[0]);

                                break;

                            case "E":

                                SetValidControl(layout, true, true, true, true, true, true, false, true, false, false, false, false, false, false, workRows[0]);

                                break;

                            case "F":

                                SetValidControl(layout, true, true, false, true, true, false, false, true, true, true, false, false, false, false, workRows[0]);

                                break;

                            case "G":

                                SetValidControl(layout, true, false, false, true, false, false, false, true, false, false, true, true, true, true, workRows[0]);

                                break;
                        }
                    }

                    DataSet ds = acInfo.RefData.Clone();
                    ds.Tables["RQSTDT"].Columns.Add("WORK_CODE", typeof(string));

                    DataRow newRow = ds.Tables["RQSTDT"].NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["WORK_CODE"] = newValue;
                    ds.Tables["RQSTDT"].Rows.Add(newRow);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER5", ds, "RQSTDT", "RSLTDT");

                    (acLayoutControl1.GetEditor("SCOMMNET_SEL") as acLookupEdit).SetData("CAUSE_NAME", "CAUSE_CODE", resultSet.Tables["RSLTDT"]);
                    layout.GetEditor("REQ_SCOMMENT").Value = null;

                    layout.GetEditor("SCOMMENT").Value = workRows[0]["SCOMMENT"];

                    break;

                case "S_MIN_TEXT":

                    if (newValue == null) return;

                    if (newValue.toInt() < 0)
                    {
                        layout.GetEditor("S_MIN_TEXT").Value = "0";
                    }
                    else if (newValue.toInt() > 59)
                    {
                        layout.GetEditor("S_MIN_TEXT").Value = "59";
                    }

                    DataRow[] wRows1 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows1.Length == 1)
                    {
                        if (layout.GetEditor("S_HOUR").Value == null
                            || layout.GetEditor("E_HOUR").Value == null) return;

                        if (layout.GetEditor("S_HOUR").Value.ToString() != layout.GetEditor("E_HOUR").Value.ToString())
                        {
                            if (TimeValidCheck(layout, wRows1[0]["INPUT_TYPE"].ToString()) == false)
                            {
                                acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                                layout.GetEditor(info.ColumnName).Value = null;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                                layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
                            }
                        }
                        else
                        {
                            if (layout.GetEditor("E_MIN_TEXT").Value.toInt() < newValue.toInt())
                            {
                                layout.GetEditor("S_MIN_TEXT").Value = layout.GetEditor("E_MIN_TEXT").Value;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                                layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
                            }
                        }

                    }

                    break;

                case "E_MIN_TEXT":

                    if (newValue == null) return;

                    if (newValue.toInt() < 0)
                    {
                        layout.GetEditor("E_MIN_TEXT").Value = "0";
                    }
                    else if (newValue.toInt() > 59)
                    {
                        layout.GetEditor("E_MIN_TEXT").Value = "59";
                    }

                    DataRow[] wRows2 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows2.Length == 1)
                    {
                        if (layout.GetEditor("S_HOUR").Value == null
                            || layout.GetEditor("E_HOUR").Value == null) return;

                        if (layout.GetEditor("S_HOUR").Value.ToString() != layout.GetEditor("E_HOUR").Value.ToString())
                        {
                            if (TimeValidCheck(layout, wRows2[0]["INPUT_TYPE"].ToString()) == false)
                            {
                                acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                                layout.GetEditor(info.ColumnName).Value = null;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                                layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
                            }
                        }
                        else
                        {
                            if (layout.GetEditor("S_MIN_TEXT").Value.toInt() > newValue.toInt())
                            {
                                layout.GetEditor("E_MIN_TEXT").Value = layout.GetEditor("S_MIN_TEXT").Value;
                            }
                            else
                            {
                                layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                                layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
                            }
                        }
                    }

                    break;

                case "SCOMMNET_SEL":

                    DataRow row = (layout.GetEditor("SCOMMNET_SEL") as acLookupEdit).GetSelectedRow("CAUSE_CODE");

                    if (row != null)
                    {
                        layout.GetEditor("REQ_SCOMMENT").Value = row["SCOMMENT"];
                    }
                    else
                    {
                        layout.GetEditor("REQ_SCOMMENT").Value = null;
                    }

                    break;

                case "REQ_SCOMMENT":

                    break;

                case "S_REQ_DATE":

                    if (newValue == null) return;

                    if (layout.GetEditor("OUT_TYPE").Value.toStringEmpty() != "DAY")
                    {
                        layout.GetEditor("E_REQ_DATE").Value = newValue;
                    }

                    if (DayVaildCheck(layout, newValue, "E_REQ_DATE") == false)
                    {
                        acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                        layout.GetEditor("S_REQ_DATE").Value = layout.GetEditor("E_REQ_DATE").Value;
                    }
                    else
                    {
                        SetTime(layout, newValue, "S_REQ_DATE");
                    }

                    break;

                case "E_REQ_DATE":

                    if (newValue == null) return;

                    if (DayVaildCheck(layout, newValue, "S_REQ_DATE") == false)
                    {
                        acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                        layout.GetEditor("E_REQ_DATE").Value = layout.GetEditor("S_REQ_DATE").Value;
                    }
                    else
                    {
                        SetTime(layout, newValue, "E_REQ_DATE");
                    }

                    break;

                case "CC_EMP":
                    break;

                case "S_HOUR":
                case "S_MINUTE":
                case "E_HOUR":
                case "E_MINUTE":

                    if (newValue == null) return;

                    DataRow[] wRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                    if (wRows.Length == 1)
                    {
                        if (TimeValidCheck(layout, wRows[0]["INPUT_TYPE"].ToString()) == false)
                        {
                            acAlert.Show(this, "시작시간보다 작을 수 없습니다.", acAlertForm.enmType.Info);
                            layout.GetEditor(info.ColumnName).Value = null;
                        }
                        else
                        {
                            layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                            layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
                        }
                    }

                    break;

                case "OUT_TYPE":

                    if (newValue == null) return;

                    if (newValue.ToString() != "DAY")
                    {
                        layout.GetEditor("E_REQ_DATE").isReadyOnly = true;
                    }
                    else
                    {
                        layout.GetEditor("E_REQ_DATE").isReadyOnly = false;
                    }

                    break;

                default:

                    if (newValue == null) return;

                    layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
                    layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);

                    break;
            }
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            (acLayoutControl1.GetEditor("S_REQ_DATE") as acDateEdit).Value = nowDate;
            (acLayoutControl1.GetEditor("E_REQ_DATE") as acDateEdit).Value = nowDate;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = acInfo.UserORG;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER8", paramSet, "RQSTDT", "RSLTDT");

            resultSet.Tables["RSLTDT"].TableName = "RQSTDT2";

            dsEmp = resultSet;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            DataRow linkRow = this._LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);

            //(acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
            //(acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

            //(acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
            //(acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

            DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + linkRow["WORK_CODE"].ToString() + "'");

            if (workRows.Length == 1)
            {
                acLayoutControl1.OnValueChanged -= acLayoutControl1_OnValueChanged;
                switch (workRows[0]["INPUT_TYPE"].ToString())
                {
                    case "A":
                    case "G":
                        
                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();

                        break;

                    case "B":
                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;
                        
                        break;

                    case "C":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();

                        break;

                    case "D":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;

                    case "E":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("S_MINUTE") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        (acLayoutControl1.GetEditor("E_MINUTE") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;

                    case "F":

                        acLayoutControl1.GetEditor("S_REQ_DATE").Value = linkRow["REQ_START_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("S_HOUR") as acLookupEdit).Value = linkRow["REQ_START_DATE"].toDateTime().Hour;
                        acLayoutControl1.GetEditor("S_MIN_TEXT").Value = linkRow["REQ_START_DATE"].toDateTime().Minute;

                        acLayoutControl1.GetEditor("E_REQ_DATE").Value = linkRow["REQ_END_DATE"].toDateTime();
                        (acLayoutControl1.GetEditor("E_HOUR") as acLookupEdit).Value = linkRow["REQ_END_DATE"].toDateTime().Hour;
                        acLayoutControl1.GetEditor("E_MIN_TEXT").Value = linkRow["REQ_END_DATE"].toDateTime().Minute;

                        break;
                }
                acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            }

            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            SetTime(acLayoutControl1, "", "");

            //기존 등록된 참조자 추가
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("WORK_ID", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WORK_ID"] = linkRow["WORK_ID"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER7", paramSet, "RQSTDT", "RSLTDT");

            resultSet.Tables["RSLTDT"].TableName = "RQSTDT2";

            dsEmp = resultSet;

            if (resultSet.Tables["RQSTDT2"].Rows.Count == 0)
            {
                paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("ORG_CODE", typeof(String));

                paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = acInfo.UserORG;
                paramTable.Rows.Add(paramRow);
                paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER8", paramSet, "RQSTDT", "RSLTDT");

                resultSet.Tables["RSLTDT"].TableName = "RQSTDT2";

                dsEmp = resultSet;
            }

            acAttachFileControl21.LinkKey = linkRow["WORK_ID"];
            acAttachFileControl21.ShowKey = new object[] { linkRow["WORK_ID"] };

            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("WORK_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("REQ_STATUS", typeof(string));
                paramTable.Columns.Add("REQ_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_START_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_END_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_TIME", typeof(decimal));
                paramTable.Columns.Add("REQ_AMPM", typeof(string));
                paramTable.Columns.Add("CC_EMP", typeof(string));
                paramTable.Columns.Add("REQ_SCOMMENT", typeof(string));
                paramTable.Columns.Add("APP_SCOMMENT", typeof(string));
                paramTable.Columns.Add("IS_DIR_IN", typeof(string));
                paramTable.Columns.Add("IS_DIR_OUT", typeof(string));
                paramTable.Columns.Add("OUT_VEN_CODE", typeof(string));
                paramTable.Columns.Add("OUT_TYPE", typeof(string));
                paramTable.Columns.Add("APP_TYPE", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = null;
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["EMP_CODE"] = _EmpCode;
                paramRow["REQ_STATUS"] = "0";
                paramRow["REQ_DATE"] = acDateEdit.GetNowDateFromServer();

                int sYear = layoutRow["S_REQ_DATE"].toDateTime().Year;
                int sMonth = layoutRow["S_REQ_DATE"].toDateTime().Month;
                int sDay = layoutRow["S_REQ_DATE"].toDateTime().Day;
                int sHour = layoutRow["S_HOUR"].ToString() == "" ? 8 : layoutRow["S_HOUR"].toInt();
                //int sMinute = layoutRow["S_MINUTE"].ToString() == "" ? 0 : layoutRow["S_MINUTE"].toInt();

                int sMinute = 0;

                if (layoutRow["S_MINUTE"].ToString() != "")
                {
                    sMinute = layoutRow["S_MINUTE"].toInt();
                }
                else if (layoutRow["S_MIN_TEXT"].ToString() != "")
                {
                    sMinute = layoutRow["S_MIN_TEXT"].toInt();
                }

                int eYear = layoutRow["E_REQ_DATE"].ToString() == "" ? sYear : layoutRow["E_REQ_DATE"].toDateTime().Year;
                int eMonth = layoutRow["E_REQ_DATE"].ToString() == "" ? sMonth : layoutRow["E_REQ_DATE"].toDateTime().Month;
                int eDay = layoutRow["E_REQ_DATE"].ToString() == "" ? sDay : layoutRow["E_REQ_DATE"].toDateTime().Day;
                int eHour = layoutRow["E_HOUR"].ToString() == "" ? 8 : layoutRow["E_HOUR"].toInt();
                //int eMinute = layoutRow["E_MINUTE"].ToString() == "" ? 0 : layoutRow["E_MINUTE"].toInt();

                int eMinute = 0;

                if (layoutRow["E_MINUTE"].ToString() != "")
                {
                    eMinute = layoutRow["E_MINUTE"].toInt();
                }
                else if (layoutRow["E_MIN_TEXT"].ToString() != "")
                {
                    eMinute = layoutRow["E_MIN_TEXT"].toInt();
                }

                DateTime startDate = new DateTime(sYear, sMonth, sDay, sHour, sMinute, 0);

                DateTime endDate = new DateTime(eYear, eMonth, eDay, eHour, eMinute, 0);

                //DateTime endDate = startDate;

                ////END시간이 작을경우 다음날로 변경
                //if (eYear != 0)
                //{
                //    endDate = new DateTime(eYear, sMonth, eDay, eHour, eMinute, 0);

                //    if (sHour > eHour)
                //    {
                //        endDate = endDate.AddDays(1);
                //    }
                //}

                paramRow["REQ_START_DATE"] = startDate;
                paramRow["REQ_END_DATE"] = endDate;

                int idleTime = 0;

                foreach (DataRow row in _IdleSet.Tables["RSLTDT"].Rows)
                {
                    string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                    string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                    string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                    string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                    DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                    DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                    if (startDate.Day != endDate.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                    {
                        idleStartTime = idleStartTime.AddDays(1);
                        idleEndTime = idleEndTime.AddDays(1);
                    }

                    TimeSpan idleTs = new TimeSpan();

                    if (idleStartTime < startDate && idleEndTime > startDate)
                    {
                        //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                        idleTs = idleEndTime.Subtract(startDate);

                    }
                    else if (idleStartTime >= startDate && idleEndTime <= endDate)
                    {
                        //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                        idleTs = idleEndTime.Subtract(idleStartTime);
                    }
                    else if (idleStartTime < endDate && idleEndTime > endDate)
                    {
                        //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                        idleTs = endDate.Subtract(idleStartTime);
                    }
                    else if (idleStartTime <= startDate && idleEndTime >= endDate)
                    {
                        //정례화 시간이 신청시간보다 클때
                        idleTs = endDate.Subtract(startDate);
                    }

                    idleTime = idleTime + idleTs.TotalMinutes.toInt();
                }

                ////시작시간과 종료시간이 같으면 종료시간에 하루 추가해서 시간(분)계산
                //if (startDate == endDate)
                //{
                //    endDate = endDate.AddDays(1);
                //}

                DateTime checkStartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                DateTime checkEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);
                TimeSpan checkTs = checkEndDate.Subtract(checkStartDate);

                TimeSpan ts = endDate.Subtract(startDate);

                //근태유형별 입력에 따라 시간계산
                DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layoutRow["WORK_CODE"].ToString() + "'");

                if (workRows.Length == 1)
                {
                    //다음날 10시이전 등록여부
                    if (workRows[0]["IS_YESTERDAY"].ToString() == "1")
                    {
                        DateTime nowdatetime = acDateEdit.GetNowDateFromServer();
                        DateTime nowdatetime2 = new DateTime(nowdatetime.Year, nowdatetime.Month, nowdatetime.Day, 9, 0, 0);

                        TimeSpan compTs = nowdatetime - startDate;

                        int compDays = nowdatetime.Day - startDate.Day;

                        bool isYesterday = false;
                        if (compDays == 1)
                        {
                            if (nowdatetime >= nowdatetime2)
                            {
                                isYesterday = true;
                            }
                        }
                        else if (compDays > 1)
                        {
                            acAlert.Show(this, "전일 작업만 등록 가능합니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        if (isYesterday)
                        {
                            acAlert.Show(this, "오전 10시까지만 등록 가능합니다.", acAlertForm.enmType.Warning);
                            return;
                        }
                    }

                    //휴일체크
                    int iHoliday = 0;
                    for (DateTime sDate = startDate; sDate.toDateString("yyyyMMdd").toInt() <= endDate.toDateString("yyyyMMdd").toInt(); sDate = sDate.AddDays(1))
                    {
                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + sDate.toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0 
                            || sDate.DayOfWeek == DayOfWeek.Saturday
                            || sDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            iHoliday++;
                        }
                    }

                    int days = checkTs.TotalDays.toInt() + 1;

                    if (iHoliday > 0)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "0")
                        {
                            //if (!(layoutRow["WORK_CODE"].ToString() == "W05" || layoutRow["WORK_CODE"].ToString() == "W06" || layoutRow["WORK_CODE"].ToString() == "W07") || days == iHoliday)
                            //{
                            //    acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            //    return;
                            //}

                            if (!(layoutRow["WORK_CODE"].ToString() == "W05" || layoutRow["WORK_CODE"].ToString() == "W06" || layoutRow["WORK_CODE"].ToString() == "W07")
                                || days == iHoliday)
                            {
                                if ((layoutRow["WORK_CODE"].ToString() == "W08" || layoutRow["WORK_CODE"].ToString() == "W09" || layoutRow["WORK_CODE"].ToString() == "W11") && days == iHoliday)
                                {
                                    acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                    return;
                                }
                            }
                        }
                    }
                    
                    if (days != iHoliday)
                    {
                        if (iHoliday == 0)
                        {
                            if (workRows[0]["IS_HOLI"].ToString() == "1")
                            {
                                acMessageBox.Show(this, "휴일만 신청 할 수 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                return;
                            }
                        }
                    }

                    //시간(분) 계산
                    switch (workRows[0]["INPUT_TYPE"].ToString())
                    {
                        case "A":
                            /*
                             연차
                            */

                            if (layoutRow["WORK_CODE"].ToString() == "W07")
                            {
                                iHoliday = 0;
                            }

                            //하루 8시간 = 480분으로 계산
                            paramRow["REQ_TIME"] = (ts.TotalDays.toInt() + 1 - iHoliday) * 480;

                            DateTime sdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime edt = paramRow["REQ_END_DATE"].toDateTime();
                            paramRow["REQ_START_DATE"] = new DateTime(sdt.Year, sdt.Month, sdt.Day, 8, 30, 0);
                            paramRow["REQ_END_DATE"] = new DateTime(edt.Year, edt.Month, edt.Day, 17, 30, 0);

                            break;

                        case "B":
                            /*
                             잔업, 교대, 특근, 휴일교대
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "C":
                            /*
                             반차
                            */

                            //근태유형 기준정보에서 IS_HALF가 설정된경우 하루에서 반 나눠준다 반차와 같은 하루 절반인 경우
                            if (workRows[0]["IS_HALF"].ToString() == "1")
                            {
                                paramRow["REQ_TIME"] = ((ts.TotalDays.toInt() + 1) * 480) / 2;
                            }

                            DateTime shdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime ehdt = paramRow["REQ_END_DATE"].toDateTime();

                            if (layoutRow["REQ_AMPM"].ToString() == "AM")
                            {
                                paramRow["REQ_START_DATE"] = new DateTime(shdt.Year, shdt.Month, shdt.Day, 8, 30, 0);
                                paramRow["REQ_END_DATE"] = new DateTime(ehdt.Year, ehdt.Month, ehdt.Day, 12, 30, 0);
                            }
                            else if (layoutRow["REQ_AMPM"].ToString() == "PM")
                            {
                                paramRow["REQ_START_DATE"] = new DateTime(shdt.Year, shdt.Month, shdt.Day, 13, 30, 0);
                                paramRow["REQ_END_DATE"] = new DateTime(ehdt.Year, ehdt.Month, ehdt.Day, 17, 30, 0);

                            }

                            break;

                        case "D":
                            /*
                             외출, 조퇴, 무급
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "E":
                            /*
                             연차/반차(육아)?
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "F":
                            /*
                             지각
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "G":
                            /*
                             외근
                            */

                            //외근 타입에 따른 시간표시

                            DateTime sOutdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime eOutdt = paramRow["REQ_END_DATE"].toDateTime();

                            switch (layoutRow["OUT_TYPE"].ToString())
                            {
                                case "DAY":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 8, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 17, 30, 0);
                                    break;
                                case "AM":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 8, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 12, 30, 0);
                                    break;

                                case "PM":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 13, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 17, 30, 0);
                                    break;
                            }

                            break;
                    }
                }


                paramRow["REQ_AMPM"] = layoutRow["REQ_AMPM"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["REQ_SCOMMENT"] = layoutRow["REQ_SCOMMENT"];
                paramRow["APP_SCOMMENT"] = null;

                paramRow["IS_DIR_IN"] = layoutRow["IS_DIR_IN"];
                paramRow["IS_DIR_OUT"] = layoutRow["IS_DIR_OUT"];
                paramRow["OUT_TYPE"] = layoutRow["OUT_TYPE"];
                paramRow["OUT_VEN_CODE"] = layoutRow["OUT_VEN_CODE"];

                string appType = "ATD";
                if (workRows.Length == 1)
                {
                    if (workRows[0]["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }
                }

                paramRow["APP_TYPE"] = appType;

                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "WOR08A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        string _saveMode = "";

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //int iAppStep = 0;
                    //foreach (DataRow appRow in e.result.Tables["RSLTDT_APP_EMP"].Rows)
                    //{
                    //    iAppStep = 1;
                    //    row["APP_EMP_CODE1"] = appRow["APP_EMP1"];
                    //    row["APP_EMP_NAME1"] = appRow["APP_EMP_NAME1"];
                    //    if (iAppStep == 1) row["APP_EMP1_FLAG"] = "1"; else row["APP_EMP1_FLAG"] = "0";

                    //    row["APP_EMP_CODE2"] = appRow["APP_EMP2"];
                    //    row["APP_EMP_NAME2"] = appRow["APP_EMP_NAME2"];
                    //    if (iAppStep == 2) row["APP_EMP2_FLAG"] = "1"; else row["APP_EMP2_FLAG"] = "0";

                    //    row["APP_EMP_CODE3"] = appRow["APP_EMP3"];
                    //    row["APP_EMP_NAME3"] = appRow["APP_EMP_NAME3"];
                    //    if (iAppStep == 3) row["APP_EMP3_FLAG"] = "1"; else row["APP_EMP3_FLAG"] = "0";

                    //    row["APP_EMP_CODE4"] = appRow["APP_EMP4"];
                    //    row["APP_EMP_NAME4"] = appRow["APP_EMP_NAME4"];
                    //    if (iAppStep == 4) row["APP_EMP4_FLAG"] = "1"; else row["APP_EMP4_FLAG"] = "0";
                    //}

                    this._LinkView.UpdateMapingRow(row, true);

                    acAttachFileControl21.LinkKey = row["WORK_ID"];
                    acAttachFileControl21.ShowKey = new object[] { row["WORK_ID"] };
                    acAttachFileControl21.UploadFile();
                }

                this.ControlBox = false;
                _saveMode = "SaveClose";
                barItemSave.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();
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
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("WORK_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("REQ_STATUS", typeof(string));
                paramTable.Columns.Add("REQ_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_START_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_END_DATE", typeof(DateTime));
                paramTable.Columns.Add("REQ_TIME", typeof(decimal));
                paramTable.Columns.Add("REQ_AMPM", typeof(string));
                paramTable.Columns.Add("CC_EMP", typeof(string));
                paramTable.Columns.Add("REQ_SCOMMENT", typeof(string));
                paramTable.Columns.Add("APP_SCOMMENT", typeof(string));
                paramTable.Columns.Add("IS_DIR_IN", typeof(string));
                paramTable.Columns.Add("IS_DIR_OUT", typeof(string));
                paramTable.Columns.Add("OUT_TYPE", typeof(string));
                paramTable.Columns.Add("OUT_VEN_CODE", typeof(string));
                paramTable.Columns.Add("APP_TYPE", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = linkRow["WORK_ID"];
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["EMP_CODE"] = _EmpCode;
                paramRow["REQ_STATUS"] = linkRow["REQ_STATUS"];
                paramRow["REQ_DATE"] = linkRow["REQ_DATE"];

                int sYear = layoutRow["S_REQ_DATE"].toDateTime().Year;
                int sMonth = layoutRow["S_REQ_DATE"].toDateTime().Month;
                int sDay = layoutRow["S_REQ_DATE"].toDateTime().Day;
                int sHour = layoutRow["S_HOUR"].ToString() == "" ? 8 : layoutRow["S_HOUR"].toInt();
                //int sMinute = layoutRow["S_MINUTE"].ToString() == "" ? 0 : layoutRow["S_MINUTE"].toInt();
                int sMinute = 0;

                if (layoutRow["S_MINUTE"].ToString() != "")
                {
                    sMinute = layoutRow["S_MINUTE"].toInt();
                }
                else if (layoutRow["S_MIN_TEXT"].ToString() != "")
                {
                    sMinute = layoutRow["S_MIN_TEXT"].toInt();
                }


                

                int eYear = layoutRow["E_REQ_DATE"].ToString() == "" ? sYear : layoutRow["E_REQ_DATE"].toDateTime().Year;
                int eMonth = layoutRow["E_REQ_DATE"].ToString() == "" ? sMonth : layoutRow["E_REQ_DATE"].toDateTime().Month;
                int eDay = layoutRow["E_REQ_DATE"].ToString() == "" ? sDay : layoutRow["E_REQ_DATE"].toDateTime().Day;
                int eHour = layoutRow["E_HOUR"].ToString() == "" ? 8 : layoutRow["E_HOUR"].toInt();
                //int eMinute = layoutRow["E_MINUTE"].ToString() == "" ? 0 : layoutRow["E_MINUTE"].toInt();

                int eMinute = 0;

                if (layoutRow["E_MINUTE"].ToString() != "")
                {
                    eMinute = layoutRow["E_MINUTE"].toInt();
                }
                else if (layoutRow["E_MIN_TEXT"].ToString() != "")
                {
                    eMinute = layoutRow["E_MIN_TEXT"].toInt();
                }

                DateTime startDate = new DateTime(sYear, sMonth, sDay, sHour, sMinute, 0);

                DateTime endDate = new DateTime(eYear, eMonth, eDay, eHour, eMinute, 0);

                //DateTime endDate = startDate;

                ////END시간이 작을경우 다음날로 변경
                //if (eYear != 0)
                //{
                //    endDate = new DateTime(eYear, sMonth, eDay, eHour, eMinute, 0);

                //    if (sHour > eHour)
                //    {
                //        endDate = endDate.AddDays(1);
                //    }
                //}

                paramRow["REQ_START_DATE"] = startDate;
                paramRow["REQ_END_DATE"] = endDate;

                int idleTime = 0;

                foreach (DataRow row in _IdleSet.Tables["RSLTDT"].Rows)
                {
                    string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                    string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                    string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                    string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                    DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                    DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                    if (startDate.Day != endDate.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                    {
                        idleStartTime = idleStartTime.AddDays(1);
                        idleEndTime = idleEndTime.AddDays(1);
                    }

                    TimeSpan idleTs = new TimeSpan();

                    if (idleStartTime < startDate && idleEndTime > startDate)
                    {
                        //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                        idleTs = idleEndTime.Subtract(startDate);

                    }
                    else if (idleStartTime >= startDate && idleEndTime <= endDate)
                    {
                        //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                        idleTs = idleEndTime.Subtract(idleStartTime);
                    }
                    else if (idleStartTime < endDate && idleEndTime > endDate)
                    {
                        //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                        idleTs = endDate.Subtract(idleStartTime);
                    }
                    else if (idleStartTime <= startDate && idleEndTime >= endDate)
                    {
                        //정례화 시간이 신청시간보다 클때
                        idleTs = endDate.Subtract(startDate);
                    }

                    idleTime = idleTime + idleTs.TotalMinutes.toInt();
                }

                ////시작시간과 종료시간이 같으면 종료시간에 하루 추가해서 시간(분)계산
                //if (startDate == endDate)
                //{
                //    endDate = endDate.AddDays(1);
                //}

                DateTime checkStartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                DateTime checkEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);
                TimeSpan checkTs = checkEndDate.Subtract(checkStartDate);

                TimeSpan ts = endDate.Subtract(startDate);

                //근태유형별 입력에 따라 시간계산
                DataRow[] workRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layoutRow["WORK_CODE"].ToString() + "'");

                if (workRows.Length == 1)
                {
                    //다음날 10시이전 등록여부
                    if (workRows[0]["IS_YESTERDAY"].ToString() == "1")
                    {
                        DateTime nowdatetime = acDateEdit.GetNowDateFromServer();
                        DateTime nowdatetime2 = new DateTime(nowdatetime.Year, nowdatetime.Month, nowdatetime.Day, 9, 0, 0);

                        TimeSpan compTs = nowdatetime - startDate;

                        int compDays = nowdatetime.Day - startDate.Day;

                        bool isYesterday = false;
                        if (compDays == 1)
                        {
                            if (nowdatetime >= nowdatetime2)
                            {
                                isYesterday = true;
                            }
                        }
                        else if (compDays > 1)
                        {
                            acAlert.Show(this, "전일 작업만 등록 가능합니다.", acAlertForm.enmType.Warning);
                            return;
                        }

                        if (isYesterday)
                        {
                            acAlert.Show(this, "오전 10시까지만 등록 가능합니다.", acAlertForm.enmType.Warning);
                            return;
                        }
                    }

                    //휴일체크
                    int iHoliday = 0;
                    for (DateTime sDate = startDate; sDate.toDateString("yyyyMMdd").toInt() <= endDate.toDateString("yyyyMMdd").toInt(); sDate = sDate.AddDays(1))
                    {
                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + sDate.toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0
                            || sDate.DayOfWeek == DayOfWeek.Saturday
                            || sDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            iHoliday++;
                        }
                    }

                    int days = checkTs.TotalDays.toInt() + 1;

                    if (iHoliday > 0)
                    {
                        if (workRows[0]["IS_HOLI"].ToString() == "0")
                        {
                            //if (!(layoutRow["WORK_CODE"].ToString() == "W05" || layoutRow["WORK_CODE"].ToString() == "W06" || layoutRow["WORK_CODE"].ToString() == "W07") || days == iHoliday)
                            //{
                            //    acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                            //    return;
                            //}
                            if (!(layoutRow["WORK_CODE"].ToString() == "W05" || layoutRow["WORK_CODE"].ToString() == "W06" || layoutRow["WORK_CODE"].ToString() == "W07")
                                || days == iHoliday)
                            {
                                if ((layoutRow["WORK_CODE"].ToString() == "W08" || layoutRow["WORK_CODE"].ToString() == "W09" || layoutRow["WORK_CODE"].ToString() == "W11") && days == iHoliday)
                                {
                                    acMessageBox.Show(this, "휴일에 신청 할 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                    return;
                                }
                            }
                        }
                    }

                    if (days != iHoliday)
                    {
                        if (iHoliday == 0)
                        {
                            if (workRows[0]["IS_HOLI"].ToString() == "1")
                            {
                                acMessageBox.Show(this, "휴일만 신청 할 수 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                                return;
                            }
                        }
                    }

                    switch (workRows[0]["INPUT_TYPE"].ToString())
                    {
                        case "A":
                            /*
                             연차
                            */

                            if (layoutRow["WORK_CODE"].ToString() == "W07")
                            {
                                iHoliday = 0;
                            }

                            //하루 8시간 = 480분으로 계산
                            paramRow["REQ_TIME"] = (ts.TotalDays.toInt() + 1 - iHoliday) * 480;

                            DateTime sdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime edt = paramRow["REQ_END_DATE"].toDateTime();
                            paramRow["REQ_START_DATE"] = new DateTime(sdt.Year, sdt.Month, sdt.Day, 8, 30, 0);
                            paramRow["REQ_END_DATE"] = new DateTime(edt.Year, edt.Month, edt.Day, 17, 30, 0);

                            break;

                        case "B":

                            /*
                             잔업, 교대, 특근, 휴일교대
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "C":
                            /*
                             반차
                            */

                            //근태유형 기준정보에서 IS_HALF가 설정된경우 하루에서 반 나눠준다 반차와 같은 하루 절반인 경우
                            if (workRows[0]["IS_HALF"].ToString() == "1")
                            {
                                paramRow["REQ_TIME"] = ((ts.TotalDays.toInt() + 1) * 480) / 2;
                            }

                            DateTime shdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime ehdt = paramRow["REQ_END_DATE"].toDateTime();

                            if (layoutRow["REQ_AMPM"].ToString() == "AM")
                            {
                                paramRow["REQ_START_DATE"] = new DateTime(shdt.Year, shdt.Month, shdt.Day, 8, 30, 0);
                                paramRow["REQ_END_DATE"] = new DateTime(ehdt.Year, ehdt.Month, ehdt.Day, 12, 30, 0);
                            }
                            else if (layoutRow["REQ_AMPM"].ToString() == "PM")
                            {
                                paramRow["REQ_START_DATE"] = new DateTime(shdt.Year, shdt.Month, shdt.Day, 13, 30, 0);
                                paramRow["REQ_END_DATE"] = new DateTime(ehdt.Year, ehdt.Month, ehdt.Day, 17, 30, 0);

                            }

                            break;

                        case "D":
                            /*
                             외출, 조퇴, 무급
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "E":
                            /*
                             연차/반차(육아)?
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "F":
                            /*
                             지각
                            */

                            //분계산
                            paramRow["REQ_TIME"] = ts.TotalMinutes.toInt() - idleTime;

                            break;

                        case "G":
                            /*
                             외근
                            */

                            //분계산
                            //외근 타입에 따른 시간표시

                            DateTime sOutdt = paramRow["REQ_START_DATE"].toDateTime();
                            DateTime eOutdt = paramRow["REQ_END_DATE"].toDateTime();

                            switch (layoutRow["OUT_TYPE"].ToString())
                            {
                                case "DAY":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 8, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 17, 30, 0);
                                    break;
                                case "AM":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 8, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 12, 30, 0);
                                    break;

                                case "PM":
                                    paramRow["REQ_START_DATE"] = new DateTime(sOutdt.Year, sOutdt.Month, sOutdt.Day, 13, 30, 0);
                                    paramRow["REQ_END_DATE"] = new DateTime(eOutdt.Year, eOutdt.Month, eOutdt.Day, 17, 30, 0);
                                    break;
                            }
                            break;
                    }
                }

                paramRow["REQ_AMPM"] = layoutRow["REQ_AMPM"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["REQ_SCOMMENT"] = layoutRow["REQ_SCOMMENT"];
                paramRow["APP_SCOMMENT"] = linkRow["APP_SCOMMENT"];

                paramRow["IS_DIR_IN"] = layoutRow["IS_DIR_IN"];
                paramRow["IS_DIR_OUT"] = layoutRow["IS_DIR_OUT"];
                paramRow["OUT_TYPE"] = layoutRow["OUT_TYPE"];
                paramRow["OUT_VEN_CODE"] = layoutRow["OUT_VEN_CODE"];

                string appType = "ATD";
                if (workRows.Length == 1)
                {
                    if (workRows[0]["IS_OUT"].ToString() == "1")
                    {
                        appType = "OUT";
                    }
                }

                paramRow["APP_TYPE"] = appType;

                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "WOR08A_INS", paramSet, "RQSTDT", "RSLTDT",
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

                    this._LinkView.UpdateMapingRow(row, true);

                    acAttachFileControl21.LinkKey = row["WORK_ID"];
                    acAttachFileControl21.ShowKey = new object[] { row["WORK_ID"] };
                    //acAttachFileControl21.UploadFile();
                    acAttachFileControl21.UploadFile();
                }

                this.ControlBox = false;
                barItemSaveClose.Enabled = false;
                _saveMode = "SaveClose";
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void formClose()
        {
            while (true)
            {
                if (acAttachFileControl21.isComplete == true)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }

            if (acAttachFileControl21.isComplete == true)
            {
                this.Invoke(new MethodInvoker(end));
            }
        }

        void end()
        {
            if (_saveMode == "Save")
            {
                barItemSave.Enabled = true;
                this.ControlBox = true;
            }
            else if (_saveMode == "SaveClose")
            {
                this.Close();
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
            else if (ex.ErrNumber == 300000 || ex.ErrNumber == 999999)
            {
                //acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                acMessageBox.Show(ex.Message, this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SetValidControl(acLayoutControl layout, bool isSdate, bool isShour, bool isSminute, bool isEdate, bool isEhour, bool isEminute, bool isampm, bool isWave, bool isSMinText, bool isEminText, bool isDirIn, bool isDirOut, bool isVendor, bool isOutType, DataRow workRow)
        {

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            //시작일
            if (isSdate) 
            {
                acLayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                layout.GetEditor("S_REQ_DATE").Value = nowDate;
            }
            else if (!isSdate)
            {
                layout.GetEditor("S_REQ_DATE").Value = null;
                layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                acLayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작시간
            if (isShour) 
            { 
                acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_HOUR").isRequired = isShour;

                layout.GetEditor("S_HOUR").Value = null;

                if (workRow != null)
                {
                    if (workRow["START_TIME"].ToString() != "")
                    {
                        layout.GetEditor("S_HOUR").Value = workRow["START_TIME"].ToString().Substring(0, 2).toInt();
                    }
                }

            }
            else if (!isShour) 
            {
                layout.GetEditor("S_HOUR").Value = null;
                layout.GetEditor("S_HOUR").isRequired = isShour;
                acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작분
            if (isSminute)
            {
                acLayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_MINUTE").isRequired = isSminute;

                layout.GetEditor("S_MINUTE").Value = null;

                if (workRow != null)
                {
                    if (workRow["START_TIME"].ToString() != "")
                    {
                        layout.GetEditor("S_MINUTE").Value = workRow["START_TIME"].ToString().Substring(2, 2).toInt();
                    }
                }
            }
            else if (!isSminute)
            {
                layout.GetEditor("S_MINUTE").Value = null;
                layout.GetEditor("S_MINUTE").isRequired = isSminute;
                acLayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료일
            if (isEdate)
            {
                acLayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_REQ_DATE").isRequired = isEdate;
                layout.GetEditor("E_REQ_DATE").Value = nowDate;
            }
            else if (!isEdate)
            {
                layout.GetEditor("E_REQ_DATE").Value = null;
                layout.GetEditor("E_REQ_DATE").isRequired = isEdate;
                acLayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료시간
            if (isEhour)
            {
                acLayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_HOUR").isRequired = isEhour;
            }
            else if (!isEhour)
            {
                layout.GetEditor("E_HOUR").Value = null;
                layout.GetEditor("E_HOUR").isRequired = isEhour;
                acLayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료분
            if (isEminute)
            {
                acLayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_MINUTE").isRequired = isEminute;
            }
            else if (!isEminute)
            {
                layout.GetEditor("E_MINUTE").Value = null;
                layout.GetEditor("E_MINUTE").isRequired = isEminute;
                acLayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //오전오후
            if (isampm)
            {
                acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("REQ_AMPM").isRequired = isampm;
            }
            else if (!isampm)
            {
                layout.GetEditor("REQ_AMPM").Value = null;
                layout.GetEditor("REQ_AMPM").isRequired = isampm;
                acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //물결
            if (isWave)
            {
                acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (!isWave)
            {
                //layout.GetEditor("S_REQ_DATE").Value = null;
                //layout.GetEditor("S_REQ_DATE").isRequired = isSdate;
                acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //시작분(text)
            if (isSMinText)
            {
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("S_MIN_TEXT").isRequired = isSMinText;
                //layout.GetEditor("S_MIN_TEXT").Value = "30";

                layout.GetEditor("S_MIN_TEXT").Value = null;
                if (workRow != null)
                {
                    if (workRow["START_TIME"].ToString() != "")
                    {
                        layout.GetEditor("S_MIN_TEXT").Value = workRow["START_TIME"].ToString().Substring(2, 2).toInt();
                    }
                }
            }
            else if (!isSMinText)
            {
                layout.GetEditor("S_MIN_TEXT").Value = null;
                layout.GetEditor("S_MIN_TEXT").isRequired = isSMinText;
                acLayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //종료분(text)
            if (isEminText)
            {
                acLayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("E_MIN_TEXT").isRequired = isEminText;
            }
            else if (!isEminText)
            {
                layout.GetEditor("E_MIN_TEXT").Value = null;
                layout.GetEditor("E_MIN_TEXT").isRequired = isEminText;
                acLayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //직출여부
            if (isDirIn)
            {
                acLayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layout.GetEditor("IS_DIR_IN").Value = null;
                acLayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //직퇴여부
            if (isDirOut)
            {
                acLayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layout.GetEditor("IS_DIR_OUT").Value = null;
                acLayoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //업체여부
            if (isVendor)
            {
                acLayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layout.GetEditor("OUT_VEN_CODE").Value = null;
                acLayoutControlItem25.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //외근구분
            if (isOutType)
            {
                acLayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layout.GetEditor("OUT_TYPE").Value = "DAY";
                layout.GetEditor("OUT_TYPE").isRequired = true;
            }
            else
            {
                layout.GetEditor("OUT_TYPE").Value = null;
                acLayoutControlItem27.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layout.GetEditor("OUT_TYPE").isRequired = false;
            }
        }

        void SetTime(acLayoutControl layout, object value, string type)
        {
            if (layout.GetEditor("WORK_CODE").Value == null) return;

            if (type != "")
            {
                DataRow[] workRows2 = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE = '" + layout.GetEditor("WORK_CODE").Value.ToString() + "'");

                if (workRows2.Length == 1)
                {
                    if (workRows2[0]["IS_PRE"].ToString() == "1")
                    {
                        if (value.toDateString("yyyyMMdd").toInt() < acDateEdit.GetNowDateFromServer().toDateString("yyyyMMdd").toInt())
                        {
                            layout.GetEditor(type).Value = acDateEdit.GetNowDateFromServer();
                        }
                    }
                }
            }

            layout.GetEditor("REQ_MINUTE").Value = SetReqMinute();
            layout.GetEditor("REQ_HOUR").Value = Math.Round(layout.GetEditor("REQ_MINUTE").Value.toDecimal() / 60, 1);
        }

        string SetReqMinute()
        {
            if (acLayoutControl1.GetEditor("S_REQ_DATE").Value == null) return "";
            if (acLayoutControl1.GetEditor("E_REQ_DATE").Value == null) return "";
            if (acLayoutControl1.GetEditor("S_HOUR").Value == null) return "";
            if (acLayoutControl1.GetEditor("E_HOUR").Value == null) return "";

            bool isSelectMin = false;
            if (acLayoutControl1.GetEditor("S_MINUTE").Value != null
                && acLayoutControl1.GetEditor("E_MINUTE").Value != null)
            {
                isSelectMin = true;
            }

            bool isTextMin = false;
            if (acLayoutControl1.GetEditor("S_MIN_TEXT").Value != null
                && acLayoutControl1.GetEditor("E_MIN_TEXT").Value != null)
            {
                isTextMin = true;
            }

            string sYear = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(0, 4);
            string sMonth = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(4, 2);
            string SDay = acLayoutControl1.GetEditor("S_REQ_DATE").Value.ToString().Substring(6, 2);

            string eYear = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(0, 4);
            string eMonth = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(4, 2);
            string eDay = acLayoutControl1.GetEditor("E_REQ_DATE").Value.ToString().Substring(6, 2);

            DateTime StartTime = DateTime.Now;
            DateTime EndTime = DateTime.Now;

            if (isSelectMin)
            {
                StartTime = new DateTime(sYear.toInt(), sMonth.toInt(), SDay.toInt(), acLayoutControl1.GetEditor("S_HOUR").Value.toInt(), acLayoutControl1.GetEditor("S_MINUTE").Value.toInt(), 0);
                EndTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), acLayoutControl1.GetEditor("E_HOUR").Value.toInt(), acLayoutControl1.GetEditor("E_MINUTE").Value.toInt(), 0);
            }
            else if (isTextMin)
            {
                StartTime = new DateTime(sYear.toInt(), sMonth.toInt(), SDay.toInt(), acLayoutControl1.GetEditor("S_HOUR").Value.toInt(), acLayoutControl1.GetEditor("S_MIN_TEXT").Value.toInt(), 0);
                EndTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), acLayoutControl1.GetEditor("E_HOUR").Value.toInt(), acLayoutControl1.GetEditor("E_MIN_TEXT").Value.toInt(), 0);
            }
            else
            {
                return "";
            }

            //if (StartTime.Hour > EndTime.Hour)
            //{
            //    EndTime = EndTime.AddDays(1);
            //}

            int idleTime = 0;

            foreach (DataRow row in _IdleSet.Tables["RSLTDT"].Rows)
            {
                string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                DateTime idleStartTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                DateTime idleEndTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                if (StartTime.Day != EndTime.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                {
                    idleStartTime = idleStartTime.AddDays(1);
                    idleEndTime = idleEndTime.AddDays(1);
                }

                TimeSpan idleTs = new TimeSpan();

                if (idleStartTime < StartTime && idleEndTime > StartTime)
                {
                    //정례화 시작시간이 신청시작시간보다 작거나 같고 정례화 종료시간이 신청시작시간보다 클떄
                    idleTs = idleEndTime.Subtract(StartTime);

                }
                else if (idleStartTime >= StartTime && idleEndTime <= EndTime)
                {
                    //정례화 시작시간 종료시간이 신청시간사이에 포함될때
                    idleTs = idleEndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime < EndTime && idleEndTime > EndTime)
                {
                    //정례화 시작시간이 신청종료시간보다 작고 정례화 종료시간이 신청종료시간보다 클때
                    idleTs = EndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime <= StartTime && idleEndTime >= EndTime)
                {
                    //정례화 시간이 신청시간보다 클때
                    idleTs = EndTime.Subtract(StartTime);
                }

                idleTime = idleTime + idleTs.TotalMinutes.toInt();
            }

            TimeSpan ts = EndTime.Subtract(StartTime);

            return (ts.TotalMinutes.toInt() - idleTime).ToString();
        }

        bool DayVaildCheck(acLayoutControl layout, object value, string stdName)
        {
            if (layout.GetEditor(stdName).Value == null) return true;

            switch (stdName)
            {
                case "S_REQ_DATE":

                    if (layout.GetEditor(stdName).Value.toInt() > value.toInt())
                    {
                        return false;
                    }

                    break;

                case "E_REQ_DATE":

                    if (layout.GetEditor(stdName).Value.toInt() < value.toInt())
                    {
                        return false;
                    }

                    break;
            }


            return true;
        }

        bool TimeValidCheck(acLayoutControl layout, string inputType)
        {
            if (layout.GetEditor("S_HOUR").Value == null
                || layout.GetEditor("E_HOUR").Value == null)
            {
                return true;
            }

            string sYear = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(0, 4);
            string sMonth = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(4, 2);
            string sDay = layout.GetEditor("S_REQ_DATE").Value.ToString().Substring(6, 2);
            string sHour = layout.GetEditor("S_HOUR").Value.ToString();
            string sMin = "";

            string eYear = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(0, 4);
            string eMonth = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(4, 2);
            string eDay = layout.GetEditor("E_REQ_DATE").Value.ToString().Substring(6, 2);
            string eHour = layout.GetEditor("E_HOUR").Value.ToString();
            string eMin = "";


            if (inputType == "F")
            {
                if (layout.GetEditor("S_MIN_TEXT").Value == null
                    || layout.GetEditor("E_MIN_TEXT").Value == null)
                {
                    string day1 = layout.GetEditor("S_REQ_DATE").Value.ToString();
                    string hour1 = layout.GetEditor("S_HOUR").Value.ToString().PadLeft(2, '0');
                    string day2 = layout.GetEditor("E_REQ_DATE").Value.ToString();
                    string hour2 = layout.GetEditor("E_HOUR").Value.ToString().PadLeft(2, '0');

                    string date1 = day1 + hour1;
                    string date2 = day2 + hour2;

                    if (date1.toInt() > date2.toInt())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                sMin = layout.GetEditor("S_MIN_TEXT").Value.ToString();
                eMin = layout.GetEditor("E_MIN_TEXT").Value.ToString();
            }
            else if (inputType == "B"
                    || inputType == "D"
                    || inputType == "E")
            {
                if (layout.GetEditor("S_MINUTE").Value == null
                    || layout.GetEditor("E_MINUTE").Value == null)
                {
                    string day1 = layout.GetEditor("S_REQ_DATE").Value.ToString();
                    string hour1 = layout.GetEditor("S_HOUR").Value.ToString().PadLeft(2, '0');
                    string day2 = layout.GetEditor("E_REQ_DATE").Value.ToString();
                    string hour2 = layout.GetEditor("E_HOUR").Value.ToString().PadLeft(2, '0');

                    string date1 = day1 + hour1;
                    string date2 = day2 + hour2;

                    if (date1.toInt() > date2.toInt())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                sMin = layout.GetEditor("S_MINUTE").Value.ToString();
                eMin = layout.GetEditor("E_MINUTE").Value.ToString();
            }
            else
            {
                return true;
            }


            DateTime sDateTime = new DateTime(sYear.toInt(), sMonth.toInt(), sDay.toInt(), sHour.toInt(), sMin.toInt(), 0);
            DateTime eDateTime = new DateTime(eYear.toInt(), eMonth.toInt(), eDay.toInt(), eHour.toInt(), eMin.toInt(), 0);

            if (sDateTime > eDateTime)
            {
                return false;
            }

            return true;
        }

        void SetItemSize(acLayoutControlItem item, int iMinus = 0)
        {
            item.SizeConstraintsType = SizeConstraintsType.Custom;

            int margin = (DevExpress.Utils.AppearanceObject.DefaultFont.Size.toInt() - acInfo.DefaultFont.Size.toInt()) * 10;
            int itemHeight = item.Size.Height;
            int width = item.TextSize.Width + 150 + margin - iMinus;

            item.MinSize = new System.Drawing.Size(width, itemHeight);

            item.MaxSize = new System.Drawing.Size(width, itemHeight);

            item.Size = new System.Drawing.Size(width, itemHeight);
        }

        private DataSet dsEmp = null;
        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //참조자 추가
            if (!base.ChildFormContains("CC_NEW"))
            {

                SAN01A_D2A frm = new SAN01A_D2A(_LinkData, dsEmp);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("CC_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsEmp = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("CC_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["CC_EMP"];
                }

            }
            else
            {

                base.ChildFormFocus("CC_NEW");

            }
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //기간확인
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable gridTable = new DataTable();
                gridTable.Columns.Add("DATE", typeof(string));
                gridTable.Columns.Add("TYPE", typeof(string));

                if (layoutRow["S_REQ_DATE"].ToString() == "" && layoutRow["E_REQ_DATE"].ToString() == "")
                {
                    acAlert.Show(this, "기간설정이 없습니다.", acAlertForm.enmType.Warning);
                }
                else if (acLayoutControlItem4.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
                {
                    if (layoutRow["S_REQ_DATE"].ToString() == "")
                    {
                        acAlert.Show(this, "기간설정이 없습니다.", acAlertForm.enmType.Warning);
                    }
                    else
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow["DATE"] = layoutRow["S_REQ_DATE"].toDateTime().toDateString("yyyy-MM-dd");

                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + layoutRow["S_REQ_DATE"].toDateTime().toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0
                            || layoutRow["S_REQ_DATE"].toDateTime().DayOfWeek == DayOfWeek.Saturday
                            || layoutRow["S_REQ_DATE"].toDateTime().DayOfWeek == DayOfWeek.Sunday)
                        {
                            newRow["TYPE"] = "휴일";
                        }
                        else
                        {
                            newRow["TYPE"] = "평일";
                        }

                        gridTable.Rows.Add(newRow);
                    }
                }
                else if (layoutRow["S_REQ_DATE"].ToString() != "" && layoutRow["E_REQ_DATE"].ToString() != "")
                {
                    DateTime sDate = layoutRow["S_REQ_DATE"].toDateTime();
                    DateTime eDate = layoutRow["E_REQ_DATE"].toDateTime();

                    for (DateTime date = sDate; date.toDateString("yyyyMMdd").toInt() <= eDate.toDateString("yyyyMMdd").toInt(); date = date.AddDays(1))
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow["DATE"] = date.toDateString("yyyy-MM-dd");

                        DataRow[] rows = _HoliSet.Tables["RSLTDT"].Select("HOLI_DATE = '" + date.toDateString("yyyyMMdd") + "'");

                        if (rows.Length > 0
                            || date.DayOfWeek == DayOfWeek.Saturday
                            || date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            newRow["TYPE"] = "휴일";
                        }
                        else
                        {
                            newRow["TYPE"] = "평일";
                        }

                        gridTable.Rows.Add(newRow);
                    }
                }

                acGridView1.GridControl.DataSource = gridTable;
                acGridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}