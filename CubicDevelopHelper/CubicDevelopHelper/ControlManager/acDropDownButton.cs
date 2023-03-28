using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlManager
{
    public class acDropDownButton : DevExpress.XtraEditors.DropDownButton, IBaseViewControl
    {
        public acDropDownButton()
            : base()
        {



        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (this.Font != acInfo.LabelTextFont)
            {
                this.Font = acInfo.LabelTextFont;
            }

            base.OnPaint(e);
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.AllowFocus = false;




            if (this.DropDownControl is DevExpress.XtraBars.PopupMenu)
            {
                DevExpress.XtraBars.PopupMenu menu = this.DropDownControl as DevExpress.XtraBars.PopupMenu;

                menu.MenuAppearance.Menu.Font = acInfo.LabelTextFont;
            }

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
