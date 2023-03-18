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
//using DevExpress.XtraTreeList;
//using DevExpress.XtraTreeList.Columns;
//using DevExpress.XtraTreeList.Nodes;
//using System.Threading;
//using ControlManager;

//namespace BizManager
//{
//    public class QTreeListExportTo
//    {
//        public delegate void ExecuteCompleateInvoker(
//            string fileName,
//            TimeSpan executeTime);

//        private Control _ParentControl = null;


//        public QTreeListExportTo(Control parentControl)
//        {
//            _ParentControl = parentControl;

//        }

//        public enum emSaveFileType { Excel, PDF, RTF, Text, HTML, MHT };

       

//        private QProgress _QBizActorProgress = null;

//        private Control _FocusControl = null;

//        private acTreeList _SourceTreeList = null;

//        /// <summary>
//        /// 파일내보내기 기능을 실행합니다.
//        /// </summary>
//        /// <param name="parentControl"></param>
//        /// <param name="view"></param>
//        /// <param name="completeCallBack"></param>
//        public void ExecuteExportTo(
//            acTreeList view,
//            emSaveFileType fileType,
//            string fileName,
//            ExecuteCompleateInvoker completeCallBack)
//        {


//            _SourceTreeList = view;

//            Thread exportThread = new Thread(
//    new ParameterizedThreadStart(ExecuteExportToThread));


//            exportThread.Start(new object[] { 
//                view,
//                fileType,
//                fileName,
//                completeCallBack
//                });


//            this.FindFocusControl(_ParentControl, ref _FocusControl);

//            this.SetControlEnbled(_ParentControl, false);


//            _QBizActorProgress = new QProgress("파일 내보내는중...", false);


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


//        /// <summary>
//        /// 복원한 트리리스트 노드구조를 똑같이한다.
//        /// </summary>
//        /// <param name="node"></param>
//        void SyncNodes(TreeListNode targetNode, TreeList syncTreeList)
//        {

//            foreach (TreeListNode node in targetNode.Nodes)
//            {
//                int idx = node.TreeList.GetVisibleIndexByNode(node);

//                TreeListNode n = syncTreeList.GetNodeByVisibleIndex(idx);

//                if (n != null)
//                {

//                    n.Expanded = node.Expanded;
//                }
//                if (node.HasChildren == true)
//                {
//                    SyncNodes(node, syncTreeList);
//                }

//            }
//        }

//        void ExecuteExportToThread(object args)
//        {

//            object[] param = (object[])args;


//            acTreeList sourceTreeList = (acTreeList)param[0];

//            emSaveFileType fileType = (emSaveFileType)param[1];

//            string fileName = (string)param[2];

//            ExecuteCompleateInvoker completeInvoker = (ExecuteCompleateInvoker)param[3];

//            try
//            {

//                Form panel = new Form();

//                //임시 트리뷰
//                acTreeList tmpTreeList = new acTreeList();

//                tmpTreeList.Location = new System.Drawing.Point(96, 30);
//                tmpTreeList.Name = "tmpTreeList";
//                tmpTreeList.Size = new System.Drawing.Size(400, 200);
//                tmpTreeList.ParentControl = _ParentControl;

//                panel.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
//                panel.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//                panel.ClientSize = new System.Drawing.Size(563, 282);
//                panel.Controls.Add(tmpTreeList);
//                panel.Name = "Form1";
//                tmpTreeList.EndInit();

//                panel.Controls.Add(tmpTreeList);

//                MemoryStream layoutSt = new MemoryStream();

//                sourceTreeList.SaveLayoutToStream(layoutSt);

//                layoutSt.Seek(0, SeekOrigin.Begin);

//                tmpTreeList.RestoreLayoutFromStream(layoutSt);

//                layoutSt.Close();

//                tmpTreeList.DataSource = sourceTreeList.DataSource;

//                tmpTreeList.RefreshDataSource();

//                foreach (acTreeListColumn col in sourceTreeList.Columns)
//                {
//                    tmpTreeList.Columns[col.FieldName].ColumnEdit = col.ColumnEdit;
//                }

//                foreach (TreeListNode node in sourceTreeList.Nodes)
//                {

//                    int idx = sourceTreeList.GetVisibleIndexByNode(node);

//                    tmpTreeList.GetNodeByVisibleIndex(idx).Expanded = node.Expanded;

//                    if (node.HasChildren == true)
//                    {
//                        this.SyncNodes(node, tmpTreeList);
//                    }
//                }



//                DateTime beginTime = DateTime.Now;


//                switch (fileType)
//                {
//                    case emSaveFileType.Excel:

//                        DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

//                        tmpTreeList.ExportToXls(fileName, xlsOpt);

//                        break;

//                    case emSaveFileType.HTML:

//                        DevExpress.XtraPrinting.HtmlExportOptions htmlOpt = new DevExpress.XtraPrinting.HtmlExportOptions();

//                        htmlOpt.CharacterSet = "utf-8";
//                        htmlOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;

//                        tmpTreeList.ExportToHtml(fileName, htmlOpt);

//                        break;

//                    case emSaveFileType.MHT:

//                        DevExpress.XtraPrinting.MhtExportOptions mhtOpt = new DevExpress.XtraPrinting.MhtExportOptions();

//                        mhtOpt.CharacterSet = "utf-8";
//                        mhtOpt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;


//                        tmpTreeList.ExportToMht(fileName, mhtOpt);

//                        break;

//                    case emSaveFileType.PDF:

//                        tmpTreeList.ExportToPdf(fileName);

//                        break;

//                    case emSaveFileType.RTF:


//                        tmpTreeList.ExportToRtf(fileName);

//                        break;

//                    case emSaveFileType.Text:

//                        DevExpress.XtraPrinting.TextExportOptions txtOpt = new DevExpress.XtraPrinting.TextExportOptions();


//                        tmpTreeList.ExportToText(fileName, txtOpt);

//                        break;
//                }



//                DateTime afterTime = DateTime.Now;


//                TimeSpan executeTime = beginTime.Subtract(afterTime);

//                if (this._ParentControl.IsHandleCreated == true)
//                {
//                    this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
//                }

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

//            this._ParentControl.Controls.Remove(_QBizActorProgress);

//            this._QBizActorProgress.Dispose();

//            this.SetControlEnbled(_ParentControl, true);

//            if (_FocusControl != null)
//            {
//                _FocusControl.Focus();
//            }

//        }
//    }
//}
