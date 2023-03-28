using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
    public class acMenuItem : DevExpress.Utils.Menu.DXMenuItem, IBaseViewControl
    {

        public acMenuItem(string menuCaption)
            : base(menuCaption)
        {



        }

        private object _UserData = null;

        public object UserData
        {
            get { return _UserData; }
            set { _UserData = value; }
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
