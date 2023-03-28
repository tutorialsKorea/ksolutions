using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ControlManager
{
    public partial class BaseFullScreenMenu : DevExpress.XtraEditors.XtraForm
    {

        //BaseFullScreenMenu frm = new BaseFullScreenMenu();

        //frm.ShowFullScreen(this, this.pnlScreenBase);

        private static bool _IsFullScreen = false;
        public bool IsFullScreen = false;

        public BaseFullScreenMenu()
        {
            InitializeComponent();


        }

        private Control _OriginalParent = null;

        private Control _MoveControl = null;

        public void ShowFullScreen(Control originalParent, Control moveControl)
        {
            if (BaseFullScreenMenu._IsFullScreen == false)
            {
                this._OriginalParent = originalParent;
                this._MoveControl = moveControl;

                this.panelControl1.Controls.Add(this._MoveControl);

                this.Size = Screen.PrimaryScreen.Bounds.Size;

                BaseFullScreenMenu._IsFullScreen = true;
                IsFullScreen = true;

                this.ShowDialog();

               
            }

        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WIN32API.WM_KEYDOWN)
            {

                if ((int)m.WParam == WIN32API.VK_ESCAPE)
                {
                    this.Close();
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

        protected override void OnClosed(EventArgs e)
        {
            BaseFullScreenMenu._IsFullScreen = false;
            IsFullScreen = false;

            this._OriginalParent.Controls.Add(this._MoveControl);

            base.OnClosed(e);
        }
    }
}