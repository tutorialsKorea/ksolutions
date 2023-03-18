using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace ControlManager
{
    public sealed partial class QProgress : DevExpress.XtraEditors.XtraUserControl
    {

        public delegate void CloseEventHandler();

        public event CloseEventHandler OnClose;


        private string _Caption = string.Empty;

        public string Caption
        {
            get { return _Caption; }
            set
            {
                _Caption = value;

                Size nowSize = layoutControl1.Root.Size;

                Size deffSize = new Size();

                simpleLabelItem1.Text = _Caption;

                deffSize.Width = layoutControl1.Root.Size.Width - nowSize.Width;

                deffSize.Height = layoutControl1.Root.Size.Height - nowSize.Height;

                Size newSize = new Size(this.Size.Width + deffSize.Width, this.Size.Height + deffSize.Height);

                this.Size = newSize;

            }
        }



        private int _TickCount = 0;


        private System.Threading.Timer _TimeChecker = null;

        private string _Message = null;

        public QProgress(string message, bool isCloseButton)
        {
            InitializeComponent();


            Size nowSize = layoutControl1.Root.Size;

            Size deffSize = new Size();

            this._Message = message;

            simpleLabelItem1.Text = message;

            deffSize.Width = layoutControl1.Root.Size.Width - nowSize.Width;

            deffSize.Height = layoutControl1.Root.Size.Height - nowSize.Height;

            Size newSize = new Size(this.Size.Width + deffSize.Width, this.Size.Height + deffSize.Height);

            this.Size = newSize;


            this.Visible = false;

            TimerCallback tc = new TimerCallback(TimeCheckerCallBack);

            this._TimeChecker = new System.Threading.Timer(tc, null, 0, 100);

            if (isCloseButton == false)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            this.Disposed += new EventHandler(QProgress_Disposed);
        }

        public void SetCount(int nowCnt, int maxCnt)
        {
            double per = ((double)nowCnt / (double)maxCnt) * 100;

            simpleLabelItem1.Text = string.Format("{0}{1}%({2}/{3})", this._Message, Math.Round(per, 0), nowCnt, maxCnt);

        }

        public void SetCount(int nowCnt)
        {
            simpleLabelItem1.Text = string.Format("{0}({1})", this._Message, nowCnt);

        }
        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams baseParams = base.CreateParams;

                baseParams.ExStyle |= (int)(WIN32API.WS_EX_NOACTIVATE) | (int)(WIN32API.WS_EX_TOPMOST);

                return baseParams;
            }
        }

        void QProgress_Disposed(object sender, EventArgs e)
        {
            this._TimeChecker.Dispose();
        }



        void TimeCheckerCallBack(object stateInfo)
        {

            //1초이상 걸릴시 상태표시한다.

            if (this._TickCount > 10)
            {
                if (this.InvokeRequired == true && this.Disposing == false)
                {
                    this.BeginInvoke(new MethodInvoker(SetVisible));

                    this._TimeChecker.Dispose();

                }
            }

            ++this._TickCount;

        }





        void SetVisible()
        {

            if (this.Visible == false)
            {
                this.Visible = true;


            }
        }




        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //닫기

            if (this.OnClose != null)
            {
                this.OnClose();
            }



        }

    }
}
