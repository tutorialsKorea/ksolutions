using BizManager;
using CodeHelperManager;
using ControlManager;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraSpreadsheet;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR05A_D0A : BaseMenuDialog
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
        DataTable _calendarTable = null;
        DataTable _holiTable = null;
        DataTable _stdHoliTable = null;

        public WOR05A_D0A(DataRow linkRow, DataTable calendarTable, DataTable holiTable, DataTable stdHoliTable)
        {
            InitializeComponent();

            _linkRow = linkRow;
            _calendarTable = calendarTable;
            _holiTable = holiTable;
            _stdHoliTable = stdHoliTable;
        }

        public override void DialogInit()
        {
            string plan_deadline_date = acInfo.SysConfig.GetSysConfigByMemory("PLAN_DEADLINE_DATE");
            string plan_s_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_S_MARK_MONTH");
            string plan_e_mark_month = acInfo.SysConfig.GetSysConfigByMemory("PLAN_E_MARK_MONTH");

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            byte[] holi_plan = Resource.holi_plan;
            SpreadsheetControl spread = new SpreadsheetControl();
            spread.LoadDocument(holi_plan, DocumentFormat.Xlsx);

            //Stream stream = new MemoryStream(Resource.holi_plan);
            //spread.LoadDocument(stream, DocumentFormat.Xlsx);

            IWorkbook workbook = spread.Document;

            Worksheet ws = workbook.Worksheets[0];

            ws["B2"].SetValue("연차유급휴가 사용촉진 통지서(계획서)-" + _linkRow["PLAN_SEQ"].ToString() + "차");

            RichTextRunFont rtfUnder = new RichTextRunFont();
            rtfUnder.UnderlineType = UnderlineType.Single;
            rtfUnder.Bold = true;
            rtfUnder.Name = "굴림";
            rtfUnder.Size = 10;

            RichTextRunFont rtfNomal = new RichTextRunFont();
            rtfNomal.Name = "굴림";
            rtfNomal.Size = 10;

            RichTextString rt = new RichTextString();
            rt.AddTextRun("근로기준법 제61조(연차유급휴가의 사용촉진)에 의거하여 당사는 연차유급휴가 사용촉진제도를 시행합니다.", rtfNomal);
            rt.AddTextRun("\n\n당해에 사용하지 않은 미사용 연차에 대해서는 다음해로 이월되거나 수당으로 지급되지 않고 자동 소멸됩니다.", rtfNomal);
            rt.AddTextRun("\n\n하여 아래와 같이 잔여일수를 확인하고 연차휴가 사용계획서를 작성하여 10일이내에(", rtfNomal);
            if (plan_deadline_date.Length == 8)
            {
                rt.AddTextRun(plan_deadline_date.Substring(0, 4) + "년 " + plan_deadline_date.Substring(4, 2) + "월 " + plan_deadline_date.Substring(6, 2) + "일까지", rtfUnder);
            }
            rt.AddTextRun(") 서면으로 제출해 주시기 바랍니다.", rtfNomal);

            ws["B10"].SetRichText(rt);

            DataRow myVenderRow = acVendor.GetMyVendor();

            if (myVenderRow != null)
            {
                ws["F15"].SetValue(myVenderRow["VEN_NAME"].toStringEmpty());
                ws["Q15"].SetValue(myVenderRow["VEN_TEL"].toStringEmpty());
                ws["F16"].SetValue(myVenderRow["VEN_ADDRESS"].toStringEmpty());
            }

            DataTable empTable = new DataTable("RQSTDT");
            empTable.Columns.Add("PLT_CODE", typeof(string));
            empTable.Columns.Add("EMP_CODE", typeof(string));

            DataRow newEmpRow = empTable.NewRow();
            newEmpRow["PLT_CODE"] = acInfo.PLT_CODE;
            newEmpRow["EMP_CODE"] = _linkRow["EMP_CODE"];
            empTable.Rows.Add(newEmpRow);

            DataSet empSet = new DataSet();
            empSet.Tables.Add(empTable);

            DataSet empResultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", empSet, "RQSTDT", "RSLTDT");

            if (empResultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                ws["F18"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_NAME"].toStringEmpty());
                ws["Q18"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_REG_NUMBER"].toStringEmpty());
                ws["F19"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["EMP_ADDRESS"].toStringEmpty());

                ws["F21"].SetValue(empResultSet.Tables["RSLTDT"].Rows[0]["HIRE_DATE"].toDateString("yyyy-MM-dd"));
                ws["Q21"].SetValue(acStdCodes.GetNameByCodeServer("C040", empResultSet.Tables["RSLTDT"].Rows[0]["EMP_TITLE"].toStringEmpty()) );
            }

            ws["F22"].SetValue(_linkRow["PLAN_YEAR"].ToString() + "년 발생 연차");
            ws["L22"].SetValue("사용 연차");
            ws["R22"].SetValue("잔여 연차");

            ws["F23"].SetValue(_linkRow["YEAR_HOLI"].toDecimal());
            ws["L23"].SetValue(_linkRow["USE_HOLI"].toDecimal());


            //int idx = 0;
            int iDatePeriod = 28;

            string sYear = _linkRow["PLAN_YEAR"].ToString();

            foreach (DataRow row in _calendarTable.Rows)
            {
                //if (idx == 10) break;

                //foreach (DataColumn col in _calendarTable.Columns)
                //{
                //    ws["B" + iDatePeriod.ToString()].SetValue("");
                //}

                string month = row["PLAN_MONTH"].ToString();

                if ((sYear + plan_s_mark_month).toInt() > month.toInt())
                {
                    continue;
                }
                if ((sYear + plan_e_mark_month).toInt() < month.toInt())
                {
                    continue;
                }

                ws["B" + iDatePeriod.ToString()].SetValue(row["DATE_PERIOD"].toStringEmpty());
                SpreadsheetFont sf = ws["B" + iDatePeriod.ToString()].Font;
                sf.Name = "굴림";
                sf.Size = 9;

                ws["E" + iDatePeriod.ToString()].SetValue(row["1"].toStringEmpty());
                SetCell(ws, "E", row, "1", month, iDatePeriod);

                ws["F" + iDatePeriod.ToString()].SetValue(row["2"].toStringEmpty());
                SetCell(ws, "F", row, "2", month, iDatePeriod);

                ws["G" + iDatePeriod.ToString()].SetValue(row["3"].toStringEmpty());
                SetCell(ws, "G", row, "3", month, iDatePeriod);

                ws["H" + iDatePeriod.ToString()].SetValue(row["4"].toStringEmpty());
                SetCell(ws, "H", row, "4", month, iDatePeriod);

                ws["I" + iDatePeriod.ToString()].SetValue(row["5"].toStringEmpty());
                SetCell(ws, "I", row, "5", month, iDatePeriod);

                ws["J" + iDatePeriod.ToString()].SetValue(row["6"].toStringEmpty());
                SetCell(ws, "J", row, "6", month, iDatePeriod);

                ws["K" + iDatePeriod.ToString()].SetValue(row["7"].toStringEmpty());
                SetCell(ws, "K", row, "7", month, iDatePeriod);

                ws["L" + iDatePeriod.ToString()].SetValue(row["8"].toStringEmpty());
                SetCell(ws, "L", row, "8", month, iDatePeriod);

                ws["M" + iDatePeriod.ToString()].SetValue(row["9"].toStringEmpty());
                SetCell(ws, "M", row, "9", month, iDatePeriod);

                ws["N" + iDatePeriod.ToString()].SetValue(row["10"].toStringEmpty());
                SetCell(ws, "N", row, "10", month, iDatePeriod);

                ws["O" + iDatePeriod.ToString()].SetValue(row["11"].toStringEmpty());
                SetCell(ws, "O", row, "11", month, iDatePeriod);

                ws["P" + iDatePeriod.ToString()].SetValue(row["12"].toStringEmpty());
                SetCell(ws, "P", row, "12", month, iDatePeriod);

                ws["Q" + iDatePeriod.ToString()].SetValue(row["13"].toStringEmpty());
                SetCell(ws, "Q", row, "13", month, iDatePeriod);

                ws["R" + iDatePeriod.ToString()].SetValue(row["14"].toStringEmpty());
                SetCell(ws, "R", row, "14", month, iDatePeriod);

                ws["S" + iDatePeriod.ToString()].SetValue(row["15"].toStringEmpty());
                SetCell(ws, "S", row, "15", month, iDatePeriod);

                ws["T" + iDatePeriod.ToString()].SetValue(row["16"].toStringEmpty());
                SetCell(ws, "T", row, "16", month, iDatePeriod);

                iDatePeriod++;
                //idx++;
            }

            DateTime nowDateTime = acDateEdit.GetNowDateFromServer();

            string nowYear = nowDateTime.Year.ToString();
            string nowMonth = nowDateTime.Month.ToString().PadLeft(2, '0');
            string nowDay = nowDateTime.Day.ToString().PadLeft(2, '0');

            ws["B44"].SetValue(nowYear + "  년         " + nowMonth + "  월       " + nowDay + " 일 ");


            DataRow[] planHoliRows = _holiTable.Select("PLAN_DATE >= '" + sYear + plan_s_mark_month + "01' AND PLAN_DATE <= '" + sYear + plan_e_mark_month + "31'");

            decimal planHoliCnt = 0;
            if (planHoliRows.Length > 0)
            {
                planHoliCnt = planHoliRows.CopyToDataTable().Compute("sum(PLAN_HOLI)", "").toDecimal();
            }

            decimal point = planHoliCnt - Math.Truncate(planHoliCnt);

            string holiCnt = planHoliCnt.ToString();
            if (point == 0)
            {
                holiCnt = Math.Truncate(planHoliCnt).ToString();
            }

            

            ws["B45"].SetValue("기재한 연차 사용계획 일수 :                     " + holiCnt.ToString() + "  일 ");
            ws["B46"].SetValue(" 제출자 :            " + _linkRow["EMP_NAME"].ToString() + "               (서명 또는 인)");
            SpreadsheetFont Bsf = ws["B46"].Font;
            Bsf.Color = Color.Black;

            //spread.ShowPrintPreview();

            //pdfFileStream = new FileStream("test" + ".pdf", FileMode.Create);

            Stream stream = new MemoryStream();

            workbook.Worksheets[0].PrintOptions.FitToPage = true;
            workbook.Worksheets[0].PrintOptions.FitToWidth = 1;
            workbook.Worksheets[0].PrintOptions.FitToHeight = 1;
            workbook.Worksheets[0].ActiveView.Orientation = PageOrientation.Portrait;
            workbook.ExportToPdf(stream);

            pdfViewer1.LoadDocument(stream);

            base.DialogInit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

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

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                
                //decimal dHoli = Math.Round(sHoli.toDecimal(), 1);
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

        void SetCell(Worksheet ws, string CellName, DataRow row, string rowSeq, string month, int iDatePeriod)
        {            
            string day = row[rowSeq].toStringEmpty().PadLeft(2, '0');
            SpreadsheetFont sf = ws[CellName + iDatePeriod.ToString()].Font;
            sf.Color = Color.Black;

            if (day != "00")
            {
                DataRow[] eRows = _stdHoliTable.Select("HOLI_DATE = '" + month + day + "'");
                DateTime eStdHolidt = new DateTime(month.Substring(0, 4).toInt(), month.Substring(4, 2).toInt(), day.toInt(), 0, 0, 0);
                if (eRows.Length > 0
                    || eStdHolidt.DayOfWeek == DayOfWeek.Saturday
                    || eStdHolidt.DayOfWeek == DayOfWeek.Sunday)
                {
                    sf.Color = Color.Red;
                }

                eRows = _holiTable.Select("PLAN_DATE = '" + month + day + "'");

                if (eRows.Length > 0)
                {
                    ws[CellName + iDatePeriod.ToString()].Fill.BackgroundColor = Color.Yellow;

                    Formatting formatting = ws[CellName + iDatePeriod.ToString()].BeginUpdateFormatting();
                    Borders borders = formatting.Borders;
                    ws[CellName + iDatePeriod.ToString()].Borders.SetAllBorders(Color.Black, BorderLineStyle.Medium);

                    if (eRows[0]["PLAN_HOLI"].toDouble() == 0.5)
                    {
                        borders.DiagonalBorderType = DiagonalBorderType.Up;
                        borders.DiagonalBorderLineStyle = BorderLineStyle.Medium;
                    }
                }
                else
                {
                    ws[CellName + iDatePeriod.ToString()].Fill.BackgroundColor = Color.Transparent;
                }
            }
        }
    }
}