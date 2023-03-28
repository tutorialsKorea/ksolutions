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
//using DevExpress.XtraPivotGrid;
//using DevExpress.XtraPrinting;
//using ControlManager;

//namespace BizManager
//{
//    public class QPivotGridExportTo
//    {
//        public delegate void ExecuteCompleateInvoker(
//            string fileName,
//            TimeSpan executeTime);

//        private Control _ParentControl = null;


//        public QPivotGridExportTo(Control parentControl)
//        {
//            _ParentControl = parentControl;

//        }

//        public enum emSaveFileType { Excel, PDF, RTF, Text, HTML, MHT };


//        private QProgress _QBizActorProgress = null;

//        private Control _FocusControl = null;

//        private PivotGridControl _SourcePivot = null;

//        /// <summary>
//        /// 파일내보내기 기능을 실행합니다.
//        /// </summary>
//        /// <param name="parentControl"></param>
//        /// <param name="view"></param>
//        /// <param name="completeCallBack"></param>
//        public void ExecuteExportTo(
//            PivotGridControl pivot,
//            emSaveFileType fileType,
//            string fileName,
//            ExecuteCompleateInvoker completeCallBack)
//        {


//            _SourcePivot = pivot;

//            Thread exportThread = new System.Threading.Thread(
//    new System.Threading.ParameterizedThreadStart(ExecuteExportToThread));


//            exportThread.Start(new object[] { 
//                _ParentControl, 
//                pivot,
//                fileType,
//                fileName,
//                completeCallBack
//                });


//            this.FindFocusControl(_ParentControl, ref _FocusControl);

//            this.SetControlEnbled(_ParentControl, false);


//            _QBizActorProgress = new QProgress(acInfo.Resource.GetString("파일 내보내는중...", "3QDGTIVQ"), false);


//            _QBizActorProgress.OnClose += new QProgress.CloseEventHandler(_QBizActorProgress_OnClose);

//            if (_ParentControl.Parent != null)
//            {
//                _ParentControl.Parent.Controls.Add(_QBizActorProgress);
//            }
//            else
//            {
//                _ParentControl.Controls.Add(_QBizActorProgress);
//            }

//            int x = (_ParentControl.Width / 2) - (_QBizActorProgress.Width / 2);
//            int y = (_ParentControl.Height / 2) - (_QBizActorProgress.Height / 2);

//            _QBizActorProgress.Location = new System.Drawing.Point(x, y);

//            _QBizActorProgress.BringToFront();


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
//            try
//            {
//                object[] param = (object[])args;

//                Control parentControl = (Control)param[0];

//                acPivotGridControl sourcePivot = (acPivotGridControl)param[1];

//                emSaveFileType fileType = (emSaveFileType)param[2];

//                string fileName = (string)param[3];


//                ExecuteCompleateInvoker completeInvoker = (ExecuteCompleateInvoker)param[4];


//                DateTime beginTime = DateTime.Now;


//                switch (fileType)
//                {
//                    case emSaveFileType.Excel:

//                        DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

//                        sourcePivot.ExportToXls(fileName, xlsOpt);

//                        break;

//                    case emSaveFileType.HTML:

//                        DevExpress.XtraPrinting.HtmlExportOptions htmlOpt = new DevExpress.XtraPrinting.HtmlExportOptions();

//                        htmlOpt.CharacterSet = "utf-8";
//                        htmlOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;

//                        sourcePivot.ExportToHtml(fileName, htmlOpt);

//                        break;

//                    case emSaveFileType.MHT:

//                        DevExpress.XtraPrinting.MhtExportOptions mhtOpt = new DevExpress.XtraPrinting.MhtExportOptions();

//                        mhtOpt.CharacterSet = "utf-8";
//                        mhtOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;


//                        sourcePivot.ExportToMht(fileName, mhtOpt);

//                        break;

//                    case emSaveFileType.PDF:

//                        sourcePivot.ExportToPdf(fileName);

//                        break;

//                    case emSaveFileType.RTF:


//                        sourcePivot.ExportToRtf(fileName);

//                        break;

//                    case emSaveFileType.Text:

//                        DevExpress.XtraPrinting.TextExportOptions txtOpt = new DevExpress.XtraPrinting.TextExportOptions();


//                        sourcePivot.ExportToText(fileName, txtOpt);

//                        break;
//                }



//                DateTime afterTime = DateTime.Now;


//                TimeSpan executeTime = beginTime.Subtract(afterTime);


//                parentControl.BeginInvoke(new MethodInvoker(ProgressClose));

//                if (this._IsThreadAbort == false)
//                {
//                    if (this._ParentControl.IsHandleCreated == true)
//                    {
//                        this._ParentControl.BeginInvoke(completeInvoker, fileName, executeTime);
//                    }
//                }


//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }


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
