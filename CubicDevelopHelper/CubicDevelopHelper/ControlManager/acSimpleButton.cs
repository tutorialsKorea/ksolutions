using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ControlManager
{
    public class acSimpleButton : DevExpress.XtraEditors.SimpleButton, IBaseViewControl
    {


        public acSimpleButton()
            : base()
        {



        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }
        protected override void OnCreateControl()
        {
            if (acInfo.IsRunTime == true)
            {

                if (_UseResourceID == true)
                {
                    this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);
                }


            }

            base.OnCreateControl();
        }





        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }



        #endregion
    }
}
