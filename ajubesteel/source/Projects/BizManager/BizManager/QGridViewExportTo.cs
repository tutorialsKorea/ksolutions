//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using DevExpress.XtraGrid.Views.Grid;
//using System.Windows.Forms;
//using DevExpress.XtraGrid;
//using System.IO;
//using System.Drawing;
//using DevExpress.XtraGrid.Columns;
//using System.Threading;
//using DevExpress.XtraEditors.Repository;
//using ControlManager;
//using GemBox.Spreadsheet;

//namespace BizManager
//{
//    public class QGridViewExportTo
//    {
//        public delegate void ExecuteCompleateInvoker(
//            string fileName,
//            TimeSpan executeTime);

//        private Control _ParentControl = null;


//        public QGridViewExportTo(Control parentControl)
//        {
//            _ParentControl = parentControl;

//        }

//        public enum emSaveFileType { Excel, ExcelMerge, ExcelCustomMerge, PDF, RTF, Text, HTML, MHT };

       

//        private QProgress _QBizActorProgress = null;

//        private Control _FocusControl = null;

//        private acGridView _SourceView = null;

//        /// <summary>
//        /// 파일내보내기 기능을 실행합니다.
//        /// </summary>
//        /// <param name="parentControl"></param>
//        /// <param name="view"></param>
//        /// <param name="completeCallBack"></param>
//        public void ExecuteExportTo(
//            acGridView view,
//            emSaveFileType fileType,
//            string fileName,
//            ExecuteCompleateInvoker completeCallBack)
//        {


//            try
//            {

//                _SourceView = view;


//                Thread exportThread = new System.Threading.Thread(
//        new System.Threading.ParameterizedThreadStart(ExecuteExportToThread));


//                exportThread.Start(new object[] { 
//                _ParentControl, 
//                view,
//                fileType,
//                fileName,
//                completeCallBack
//                });


//                this.FindFocusControl(_ParentControl, ref _FocusControl);

//                this.SetControlEnbled(_ParentControl, false);


//                _QBizActorProgress = new QProgress(acInfo.Resource.GetString("파일 내보내는중...", "3QDGTIVQ"), false);


//                _QBizActorProgress.OnClose += new QProgress.CloseEventHandler(_QBizActorProgress_OnClose);

//                if (_ParentControl.Parent != null)
//                {
//                    _ParentControl.Parent.Controls.Add(_QBizActorProgress);
//                }
//                else
//                {
//                    _ParentControl.Controls.Add(_QBizActorProgress);
//                }

//                int x = (_ParentControl.Width / 2) - (_QBizActorProgress.Width / 2);
//                int y = (_ParentControl.Height / 2) - (_QBizActorProgress.Height / 2);

//                _QBizActorProgress.Location = new System.Drawing.Point(x, y);

//                _QBizActorProgress.BringToFront();

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }





//        }
//        /// <summary>
//        /// 현재 포커스를 가진 컨트롤을 찾는다.
//        /// </summary>
//        /// <param name="rootControl"></param>
//        /// <param name="focusControl"></param>
//        private void FindFocusControl(Control rootControl, ref Control focusControl)
//        {
//            foreach (Control child in rootControl.Controls)
//            {
//                if (child.Controls.Count != 0)
//                {
//                    FindFocusControl(child, ref focusControl);
//                }

//                if (child.Focused == true)
//                {
//                    focusControl = child;

//                    return;
//                }
//            }

//        }

//        /// <summary>
//        /// 컨트롤을 비활성화 한다.
//        /// </summary>
//        /// <param name="rootControl"></param>
//        /// <param name="enbled"></param>
//        private void SetControlEnbled(Control rootControl, bool enbled)
//        {

//            if (rootControl.Parent != null)
//            {

//                foreach (Control child in rootControl.Parent.Controls)
//                {
//                    child.Enabled = enbled;
//                }
//            }
//            else
//            {

//            }

//        }
//        private bool _IsThreadAbort = false;

//        void _QBizActorProgress_OnClose()
//        {
//            this._IsThreadAbort = true;

//            this._ParentControl.Enabled = true;
//        }

//        void ExecuteExportToThread(object args)
//        {
//                object[] param = (object[])args;

//                Control parentControl = (Control)param[0];

//                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true ;

//                acGridView sourceView = (acGridView)param[1];

//                emSaveFileType fileType = (emSaveFileType)param[2];

//                string fileName = (string)param[3];

//                ExecuteCompleateInvoker completeInvoker = (ExecuteCompleateInvoker)param[4];

//                Form panel = new Form();

//                acGridControl gc = new acGridControl();

//                acGridView gv = new acGridView(gc);

//                panel.Controls.Add(gc);

//                gc.Name = "tempGridControl";

//                gc.Parent = panel;
//                gc.Location = new Point(0, 0);
//                gc.Size = new Size(0, 0);
//                gc.Visible = false;
//                gv.ParentControl = panel;

//                gc.MainView = gv;

//                gc.ViewCollection.Add(gv);

                
//                gc.DataSource = sourceView.GridControl.DataSource;

//                MemoryStream layoutSt = new MemoryStream();

//                sourceView.SaveLayoutToStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

//                layoutSt.Seek(0, SeekOrigin.Begin);

//                gv.RestoreLayoutFromStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

//                layoutSt.Close();


//                foreach (acGridColumn col in sourceView.Columns)
//                {
//                    if (col.EditorType == acGridView.emEditorType.COLOR)
//                    {
//                        gv.Columns[col.FieldName].ColumnEdit = new RepositoryItemTextEdit();
//                    }
//                    else if (col.EditorType == acGridView.emEditorType.PICTURE)
//                    {
//                        gv.Columns[col.FieldName].ColumnEdit = new RepositoryItemTextEdit();
//                    }
//                    else
//                    {
//                        gv.Columns[col.FieldName].ColumnEdit = col.ColumnEdit;

//                    }
//                }


//                DateTime beginTime = DateTime.Now;


//                switch (fileType)
//                {
//                    case emSaveFileType.Excel:
//                        {
//                            DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

//                            gv.ExportToXls(fileName, xlsOpt);

//                        }
//                        break;

//                    case emSaveFileType.ExcelMerge:
//                        {
//                            DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

//                            this.ExportToMerge(gv, fileName, xlsOpt);

//                        }

//                        break;

//                    case emSaveFileType.ExcelCustomMerge:
//                        {
//                            DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

//                            this.ExportToCustomMerge(gv, fileName, this._SourceView.ExcelCustomMergColumns, xlsOpt);

//                        }

//                        break;

//                    case emSaveFileType.HTML:

//                        DevExpress.XtraPrinting.HtmlExportOptions htmlOpt = new DevExpress.XtraPrinting.HtmlExportOptions();

//                        htmlOpt.CharacterSet = "utf-8";
//                        htmlOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;

//                        gv.ExportToHtml(fileName, htmlOpt);

//                        break;

//                    case emSaveFileType.MHT:

//                        DevExpress.XtraPrinting.MhtExportOptions mhtOpt = new DevExpress.XtraPrinting.MhtExportOptions();

//                        mhtOpt.CharacterSet = "utf-8";
//                        mhtOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;


//                        gv.ExportToMht(fileName, mhtOpt);

//                        break;

//                    case emSaveFileType.PDF:


//                        gv.ExportToPdf(fileName);

//                        break;

//                    case emSaveFileType.RTF:


//                        gv.ExportToRtf(fileName);

//                        break;

//                    case emSaveFileType.Text:

//                        DevExpress.XtraPrinting.TextExportOptions txtOpt = new DevExpress.XtraPrinting.TextExportOptions();


//                        gv.ExportToText(fileName, txtOpt);

//                        break;
//                }



//                DateTime afterTime = DateTime.Now;


//                TimeSpan executeTime = beginTime.Subtract(afterTime);



//                if (this._IsThreadAbort == false)
//                {
//                    if (this._ParentControl.IsHandleCreated == true)
//                    {
//                        this._ParentControl.BeginInvoke(completeInvoker, fileName, executeTime);
//                    }
//                }



//                parentControl.BeginInvoke(new MethodInvoker(ProgressClose));



     


//        }

//        void ExportToMerge(acGridView gv, string fileName, DevExpress.XtraPrinting.XlsExportOptions xlsOpt)
//        {
//            FileInfo originalFileInfo = new FileInfo(fileName);

//            string tempFileName = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), originalFileInfo.Name);


//            gv.ExportToXls(tempFileName, xlsOpt);



//            ExcelFile ef = new ExcelFile();


//            FileInfo tempFileInfo = new FileInfo(tempFileName);


//            if (tempFileInfo.Extension.ToLower() == ".xls")
//            {
//                ef.LoadXls(tempFileName);
//            }
//            else if (tempFileInfo.Extension.ToLower() == ".xlsx")
//            {
//                ef.LoadXlsx(tempFileName, XlsxOptions.None);
//            }
//            else
//            {
//                return;
//            }

//            ExcelWorksheet sheet = ef.Worksheets[0];


//            Dictionary<int, string> mergeColumnDic = new Dictionary<int, string>();

//            Dictionary<int, string> checkEditDic = new Dictionary<int, string>();


//            foreach (GridColumn col in gv.Columns)
//            {
//                if (col.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True && col.Visible == true)
//                {
//                    mergeColumnDic.Add(col.VisibleIndex, col.FieldName);
//                }

//                if (col.ColumnEdit is RepositoryItemCheckEdit && col.Visible == true)
//                {
//                    checkEditDic.Add(col.VisibleIndex, col.FieldName);

//                }

//            }


//            CellRange maxRange = sheet.GetUsedCellRange(true);

//            int maxCnt = maxRange.EndPosition.toCharDigit().toInt();


//            foreach (KeyValuePair<int, string> key in mergeColumnDic)
//            {

//                string columnPosition = CellRange.RowColumnToPosition(0, key.Key);

//                columnPosition = columnPosition.toCharSting();

//                int nRow = 1;

//                object cellValue = null;

//                int startIdx = 0;

//                int endIdx = 0;

//                while (true)
//                {

//                    sheet.Columns[columnPosition].Cells[nRow].Style.VerticalAlignment = VerticalAlignmentStyle.Center;

//                    if (!cellValue.EqualsEx(sheet.Columns[columnPosition].Cells[nRow].Value.toStringEmpty()))
//                    {

//                        cellValue = sheet.Columns[columnPosition].Cells[nRow].Value.toStringEmpty();

//                        if ((endIdx - startIdx) > 0)
//                        {

//                            CellRange cr = sheet.Cells.GetSubrange(string.Format("{0}{1}", columnPosition, startIdx + 1), string.Format("{0}{1}", columnPosition, endIdx + 1));

//                            cr.Merged = true;

//                            endIdx = nRow;

//                        }


//                        startIdx = nRow;

//                    }
//                    else
//                    {
//                        endIdx = nRow;
//                    }


//                    if (nRow == maxCnt)
//                    {
//                        break;
//                    }


//                    ++nRow;

//                }


//                if ((endIdx - startIdx) > 0)
//                {

//                    CellRange cr = sheet.Cells.GetSubrange(string.Format("{0}{1}", columnPosition, startIdx + 1), string.Format("{0}{1}", columnPosition, endIdx));

//                    cr.Merged = true;

//                }



//            }


//            //체크에디터 형태
 
//            DataTable gridDt = gv.GetDataView().ToTable();

//            if (gridDt.Rows.Count > 0)
//            {
//                foreach (KeyValuePair<int, string> key in checkEditDic)
//                {
//                    string columnPosition = CellRange.RowColumnToPosition(0, key.Key);

//                    columnPosition = columnPosition.toCharSting();

//                    int nRow = 1;

//                    GridColumn col = gv.GetVisibleColumn(key.Key);

//                    if (col != null)
//                    {
//                        while (true)
//                        {
//                            sheet.Columns[columnPosition].Cells[nRow].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
//                            sheet.Columns[columnPosition].Cells[nRow].Style.VerticalAlignment = VerticalAlignmentStyle.Center;

//                            sheet.Columns[columnPosition].Cells[nRow].Value = gridDt.Rows[nRow - 1][col.FieldName].toInt();


//                            if (nRow == (maxCnt - 1))
//                            {
//                                break;
//                            }

//                            ++nRow;
//                        }

//                    }

//                }
//            }
       

//            tempFileInfo.Delete();

//            ef.SaveXls(fileName);

//        }

//        void ExportToCustomMerge(acGridView gv, string fileName, string[] mergeColumns, DevExpress.XtraPrinting.XlsExportOptions xlsOpt)
//        {
//            FileInfo originalFileInfo = new FileInfo(fileName);

//            string tempFileName = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), originalFileInfo.Name);


//            gv.ExportToXls(tempFileName, xlsOpt);



//            ExcelFile ef = new ExcelFile();


//            FileInfo tempFileInfo = new FileInfo(tempFileName);


//            if (tempFileInfo.Extension.ToLower() == ".xls")
//            {
//                ef.LoadXls(tempFileName);
//            }
//            else if (tempFileInfo.Extension.ToLower() == ".xlsx")
//            {
//                ef.LoadXlsx(tempFileName, XlsxOptions.None);
//            }
//            else
//            {
//                return;
//            }

//            ExcelWorksheet sheet = ef.Worksheets[0];


//            Dictionary<int, string> mergeColumnDic = new Dictionary<int, string>();

//            Dictionary<int, string> checkEditDic = new Dictionary<int, string>();


//            foreach (GridColumn col in gv.Columns)
//            {
//                if (col.OptionsColumn.AllowMerge == DevExpress.Utils.DefaultBoolean.True && col.Visible == true)
//                {
//                    mergeColumnDic.Add(col.VisibleIndex, col.FieldName);
//                }

//                if (col.ColumnEdit is RepositoryItemCheckEdit && col.Visible == true)
//                {
//                    checkEditDic.Add(col.VisibleIndex, col.FieldName);

//                }

//            }


//            CellRange maxRange = sheet.GetUsedCellRange(true);

//            int maxCnt = maxRange.EndPosition.toCharDigit().toInt();


//            foreach (KeyValuePair<int, string> key in mergeColumnDic)
//            {

//                string columnPosition = CellRange.RowColumnToPosition(0, key.Key);

//                columnPosition = columnPosition.toCharSting();

//                int nRow = 1;

//                object cellValue = null;

//                int startIdx = 0;

//                int endIdx = 0;

//                while (true)
//                {

//                    sheet.Columns[columnPosition].Cells[nRow].Style.VerticalAlignment = VerticalAlignmentStyle.Center;

//                    string mergeKey = null;

//                    foreach (string mc in mergeColumns)
//                    {
//                        mergeKey += string.Format("{0}", sheet.Columns[mc].Cells[nRow].Value);

//                    }


//                    if (!cellValue.EqualsEx(mergeKey))
//                    {

//                        cellValue = mergeKey;


//                        if ((endIdx - startIdx) > 0)
//                        {

//                            CellRange cr = sheet.Cells.GetSubrange(string.Format("{0}{1}", columnPosition, startIdx + 1), string.Format("{0}{1}", columnPosition, endIdx + 1));

//                            cr.Merged = true;

//                            endIdx = nRow;

//                        }


//                        startIdx = nRow;

//                    }
//                    else
//                    {
//                        endIdx = nRow;
//                    }


//                    if (nRow == maxCnt)
//                    {
//                        break;
//                    }


//                    ++nRow;

//                }


//                if ((endIdx - startIdx) > 0)
//                {

//                    CellRange cr = sheet.Cells.GetSubrange(string.Format("{0}{1}", columnPosition, startIdx + 1), string.Format("{0}{1}", columnPosition, endIdx));

//                    cr.Merged = true;

//                }



//            }


//            //체크에디터 형태

//            DataTable gridDt = gv.GetDataView().ToTable();


//            foreach (KeyValuePair<int, string> key in checkEditDic)
//            {
//                string columnPosition = CellRange.RowColumnToPosition(0, key.Key);

//                columnPosition = columnPosition.toCharSting();

//                int nRow = 1;

//                GridColumn col = gv.GetVisibleColumn(key.Key);

//                if (col != null)
//                {
//                    while (true)
//                    {
//                        sheet.Columns[columnPosition].Cells[nRow].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
//                        sheet.Columns[columnPosition].Cells[nRow].Style.VerticalAlignment = VerticalAlignmentStyle.Center;

//                        sheet.Columns[columnPosition].Cells[nRow].Value = gridDt.Rows[nRow - 1][col.FieldName].toInt();


//                        if (nRow == (maxCnt - 1))
//                        {
//                            break;
//                        }

//                        ++nRow;
//                    }

//                }

//            }


//            tempFileInfo.Delete();

//            ef.SaveXls(fileName);

//        }

//        private void ProgressClose()
//        {

//            _ParentControl.Controls.Remove(_QBizActorProgress);

//            _QBizActorProgress.Dispose();

//            this.SetControlEnbled(_ParentControl, true);

//            if (_FocusControl != null)
//            {
//                _FocusControl.Focus();
//            }

//        }
//    }
//}
