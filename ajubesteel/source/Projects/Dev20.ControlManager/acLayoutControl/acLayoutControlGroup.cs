using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
    public class acLayoutControlGroup : DevExpress.XtraLayout.LayoutControlGroup, IBaseViewControl
    {

        public acLayoutControlGroup()
            : base()
        {

        }

        public acLayoutControlGroup(DevExpress.XtraLayout.LayoutGroup lg)
            : base(lg)
        {


        }





        protected override DevExpress.XtraLayout.LayoutItem CreateLayoutItem()
        {
            return new acLayoutControlItem();
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

        private bool _isHeader = false;

        public bool IsHeader
        {
            get
            {
                return _isHeader;
            }
            set
            {
                _isHeader = value;
            }
        }

        #endregion
    }
}
