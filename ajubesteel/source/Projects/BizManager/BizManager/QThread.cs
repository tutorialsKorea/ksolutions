using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.IO;
using System.Drawing;
using System.Threading;

namespace BizManager
{
    public class QThread
    {





        public QThread(Control parentControl, emExecuteType executeType)
        {

            this._ParentControl = parentControl;
            this._ExecuteType = executeType;

        }




        public delegate void QThreadCompleateInvoker(object data);


        private Thread _Thread = null;

        private QProgress _QBizActorProgress = null;

        public QProgress QBizActorProgress
        {
            get { return _QBizActorProgress; }
        }


        private Control _FocusControl = null;


        private Control _ParentControl = null;

        public enum emExecuteType
        {

            NONE,

            /// <summary>
            /// 읽기
            /// </summary>
            LOAD,

            /// <summary>
            /// 처리
            /// </summary>
            PROCESS,

            /// <summary>
            /// 다운로드
            /// </summary>
            DOWNLOAD,


        }

        private emExecuteType _ExecuteType = emExecuteType.NONE;

        public emExecuteType ExecuteType
        {
            get { return _ExecuteType; }
        }

        private TimeSpan _ExecuteTime = TimeSpan.MinValue;

        public TimeSpan ExecuteTime
        {
            get { return _ExecuteTime; }
        }

        public Thread Thread { get => _Thread; set => _Thread = value; }

        public void SetCount(int cnt)
        {
            this._ParentControl.BeginInvoke((MethodInvoker)delegate
            {

                this._QBizActorProgress.SetCount(cnt);

            });
        }


        public static string GetExecuteTypeString(QThread.emExecuteType excuteType)
        {
            string typeMsg = string.Empty;

            switch (excuteType)
            {


                case QThread.emExecuteType.LOAD:

                    //typeMsg = acInfo.Resource.GetString("읽기", "PKELTPXA");
                    typeMsg = "읽기";

                    break;

                case QThread.emExecuteType.PROCESS:

                    //typeMsg = acInfo.Resource.GetString("처리", "39PXBV5E");
                    typeMsg = "처리";

                    break;

                case emExecuteType.DOWNLOAD:

                    //typeMsg = acInfo.Resource.GetString("다운로드", "AW0VNDIO");
                    typeMsg = "다운로드";

                    break;


            }

            return typeMsg;

        }


        /// <summary>
        /// 쓰레드도중에 종료여부
        /// </summary>
        public bool IsThreadAbort = false;

        public void Execute(
            System.Threading.ParameterizedThreadStart threadMethod,
            object parameter)
        {






            Thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(threadMethod));

            //진행바 표시여부
            bool progressVisible = false;


            string progressCaption = null;

            bool progressCloseButton = false;

            switch (this._ExecuteType)
            {


                case emExecuteType.NONE:

                    progressVisible = false;


                    break;

                case emExecuteType.LOAD:

                    progressVisible = true;


                    //progressCaption = acInfo.Resource.GetString("읽는중...", "0O0BPWD8");
                    progressCaption = "읽는중...";

                    progressCloseButton = true;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;


                case emExecuteType.PROCESS:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("처리중...", "RW353VO6");
                    progressCaption = "처리중...";

                    progressCloseButton = false;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;

                case emExecuteType.DOWNLOAD:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("다운로드중...", "IGKHMVSW");
                    progressCaption = "다운로드중...";

                    progressCloseButton = true;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;


            }


            this.IsThreadAbort = false;


            this._ThreadStartTime = DateTime.Now;

            if (progressVisible == true)
            {
                _QBizActorProgress = new QProgress(progressCaption, progressCloseButton);

                Thread.Start(parameter);

                Thread checkerThread = new Thread(new System.Threading.ParameterizedThreadStart(ThreadCheaker));

                checkerThread.Start(_ParentControl);

                _QBizActorProgress.OnClose += new QProgress.CloseEventHandler(_QBizActorProgress_OnClose);

                if (_ParentControl.Parent != null)
                {
                    _ParentControl.Parent.Controls.Add(_QBizActorProgress);
                }
                else
                {

                    this._ParentControl.Controls.Add(_QBizActorProgress);

                }


                int x = (_ParentControl.Width / 2) - (_QBizActorProgress.Width / 2);
                int y = (_ParentControl.Height / 2) - (_QBizActorProgress.Height / 2);

                this._QBizActorProgress.Location = new System.Drawing.Point(x, y);

                this._QBizActorProgress.BringToFront();
            }
            else
            {


                Thread.Start(parameter);

                Thread checkerThread = new Thread(new System.Threading.ParameterizedThreadStart(ThreadCheaker));

                checkerThread.Start(_ParentControl);
            }





        }

        private DateTime _ThreadStartTime = DateTime.MinValue;


        void ThreadCheaker(object sender)
        {


            while (true)
            {
                if (Thread.IsAlive == false)
                {
                    Control ctrl = (Control)sender;

                    if (ctrl.IsHandleCreated == true)
                    {
                        this._ExecuteTime = DateTime.Now.Subtract(this._ThreadStartTime);

                        ctrl.BeginInvoke(new MethodInvoker(ProgressClose));

                        Thread.Sleep(100);
                    }

                    break;

                }

            }

        }


        void _QBizActorProgress_OnClose()
        {

            this.IsThreadAbort = true;

            if (this._ParentControl.IsHandleCreated == true)
            {
                this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
            }

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
                foreach (Control child in rootControl.Controls)
                {
                    child.Enabled = enbled;
                }
            }

        }

        public event OnProgressCloseHandler OnProgressClose;

        public delegate void OnProgressCloseHandler();



        private void ProgressClose()
        {

            this.Thread.Abort();


            if (_ParentControl.Parent != null)
            {
                _ParentControl.Parent.Controls.Remove(_QBizActorProgress);

            }
            {
                _ParentControl.Controls.Remove(_QBizActorProgress);
            }

            if (_QBizActorProgress != null)
            {
                _QBizActorProgress.Dispose();
            }

            this.SetControlEnbled(_ParentControl, true);

            if (_FocusControl != null)
            {
                _FocusControl.Focus();
            }

            if (this.OnProgressClose != null)
            {
                this.OnProgressClose();
            }



        }


    }
}
