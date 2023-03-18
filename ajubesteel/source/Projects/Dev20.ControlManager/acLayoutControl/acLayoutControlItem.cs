using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
    public class acLayoutControlItem : DevExpress.XtraLayout.LayoutControlItem, IBaseViewControl
    {

        public acLayoutControlItem()
            : base()
        {

            //this.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            //this.TrimClientAreaToControl = false;
            //this.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;

            this.Padding = new DevExpress.XtraLayout.Utils.Padding(5,5,5,5);
            //System.Drawing.Font font = this.AppearanceItemCaption.Font;
            //font = new System.Drawing.Font(font.FontFamily, font.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold);
            //this.AppearanceItemCaption.Font = font;
            //if(this.AppearanceItemCaption.ForeColor.ToArgb() == 0)
            //    this.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkSlateBlue;
            ////this.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }



        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                this.CustomizationFormText = base.Text;

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

        private string _ToolTipStdCode = null;

        public string ToolTipStdCode
        {
            get
            {
                return _ToolTipStdCode;
            }
            set
            {
                _ToolTipStdCode = value;
            }
        }

        private bool _isTitle = false;

        public bool IsTitle
        {
            get
            {
                return _isTitle;
            }
            set
            {
                _isTitle = value;
            }
        }

        private bool _IsHeader = false;

        public bool IsHeader
        {
            get
            {
                return _IsHeader;
            }
            set
            {
                _IsHeader = value;
            }
        }
        #endregion
    }
}
