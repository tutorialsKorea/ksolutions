using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.IO;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using System.Threading;

namespace ControlManager
{
    public class QGridViewBestFitColumns
    {
        public delegate void ExecuteCompleateInvoker(
            TimeSpan executeTime);


        private delegate void AssignColumnsInvoker(GridView view);


        public QGridViewBestFitColumns()
        {


        }




        private QProgress _QBizActorProgress = null;


        private Control _FocusControl = null;


        private GridView _SourceView = null;


        private Control _ParentControl = null;

        /// <summary>
        /// 컬럼최적화 기능을 실행합니다.
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="view"></param>
        /// <param name="completeCallBack"></param>
        public void ExecuteBestFit(
            Control parentControl,
            GridView view,
            ExecuteCompleateInvoker completeCallBack)
        {

            _SourceView = view;

            _ParentControl = parentControl;

            Thread bestFitThread = new Thread(
    new ParameterizedThreadStart(ExecuteBestFitThread));


            bestFitThread.Start(new object[] { 
                completeCallBack
                });



            _QBizActorProgress = new QProgress(acInfo.Resource.GetString("컬럼자동크기 설정중...", "7NEBTDYE"), false);


            _QBizActorProgress.OnClose += new QProgress.CloseEventHandler(_QBizActorProgress_OnClose);

            if (_ParentControl.Parent != null)
            {
                _ParentControl.Parent.Controls.Add(_QBizActorProgress);
            }
            else
            {
                _ParentControl.Controls.Add(_QBizActorProgress);
            }

            int x = (_ParentControl.Width / 2) - (_QBizActorProgress.Width / 2);
            int y = (_ParentControl.Height / 2) - (_QBizActorProgress.Height / 2);

            _QBizActorProgress.Location = new System.Drawing.Point(x, y);

            _QBizActorProgress.BringToFront();

        }

        private bool _IsThreadAbort = false;

        void _QBizActorProgress_OnClose()
        {
            this._IsThreadAbort = true;

            this._ParentControl.Enabled = true;
        }


        /// <summary>
        /// 현재 포커스를 가진 컨트롤을 찾는다.
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="focusControl"></param>
        private void FindFocusControl(Control rootControl, ref Control focusControl)
        {
            foreach (Control child in rootControl.Controls)
            {
                if (child.Controls.Count != 0)
                {
                    FindFocusControl(child, ref focusControl);
                }

                if (child.Focused == true)
                {
                    focusControl = child;

                    return;
                }
            }

        }

        /// <summary>
        /// 컨트롤을 비활성화 한다.
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="enbled"></param>
        private void SetControlEnbled(Control rootControl, bool enbled)
        {

            if (rootControl.Parent != null)
            {

                foreach (Control child in rootControl.Parent.Controls)
                {
                    child.Enabled = enbled;
                }
            }
            else
            {
               
            }

        }

        void ExecuteBestFitThread(object args)
        {
            try
            {
                object[] param = (object[])args;


                ExecuteCompleateInvoker completeInvoker = (ExecuteCompleateInvoker)param[0];

                Form panel = new Form();

                GridControl gc = new GridControl();

                GridView gv = new GridView(gc);


                panel.Controls.Add(gc);

                gc.Name = "tempGridControl";

                gc.Parent = panel;
                gc.Location = new Point(0, 0);
                gc.Size = new Size(0, 0);
                gc.Visible = false;

                gc.MainView = gv;

                gc.ViewCollection.Add(gv);

                gc.DataSource = this._SourceView.GridControl.DataSource;

                MemoryStream layoutSt = new MemoryStream();

                this._SourceView.SaveLayoutToStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                layoutSt.Seek(0, SeekOrigin.Begin);

                gv.RestoreLayoutFromStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                layoutSt.Close();


                foreach (GridColumn col in this._SourceView.Columns)
                {
                    if (gv.Columns[col.FieldName] != null)
                    {
                        gv.Columns[col.FieldName].ColumnEdit = col.ColumnEdit;
                    }

                }


                DateTime beginTime = DateTime.Now;

                gv.BestFitColumns();

                DateTime afterTime = DateTime.Now;


                TimeSpan executeTime = beginTime.Subtract(afterTime);

                

                if (this._ParentControl.IsHandleCreated == true)
                {
                    this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
                }
                else
                {
                    this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose)); // 창이 안없어지는 버그 때문에 임시 조치 (손한결 2020.03.20) - bandgridview AUTO_COL 설정 시 발생
                }

                if (this._IsThreadAbort == false)
                {
                    if (this._ParentControl.IsHandleCreated == true)
                    {
                        this._ParentControl.BeginInvoke(new AssignColumnsInvoker(AssignColumns), gv);

                        this._ParentControl.BeginInvoke(completeInvoker, executeTime);

                    }
                }


            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            catch 
            {
                _QBizActorProgress.Dispose();
            }

        }

        private void ProgressClose()
        {

            _ParentControl.Controls.Remove(_QBizActorProgress);

            _QBizActorProgress.Dispose();

            this.SetControlEnbled(_ParentControl, true);

            if (_FocusControl != null)
            {
                _FocusControl.Focus();
            }

        }

        void AssignColumns(GridView view)
        {
            MemoryStream layoutSt = new MemoryStream();

            view.SaveLayoutToStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            layoutSt.Seek(0, SeekOrigin.Begin);

            int focusRowHandle = _SourceView.FocusedRowHandle;

            _SourceView.RestoreLayoutFromStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            layoutSt.Close();

            _SourceView.FocusedRowHandle = focusRowHandle;

        }

    }
}
