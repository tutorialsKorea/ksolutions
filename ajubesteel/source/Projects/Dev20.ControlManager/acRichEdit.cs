using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using System.Configuration;
using DevExpress.XtraRichEdit.Export.Rtf;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;

namespace ControlManager
{
    public class acRichEdit : DevExpress.XtraRichEdit.RichEditControl
    {
        public bool IsNotApplyColorStyle { get; set; }

        private DocumentFormat documentFormat = DocumentFormat.Rtf;

		public acRichEdit()
            : base()
        {
            this.GotFocus += new EventHandler(acRichEdit_GotFocus);

            this.LostFocus += new EventHandler(acRichEdit_LostFocus);

        }

        void acRichEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.SetColor();

                }
            }

        }

        void acRichEdit_GotFocus(object sender, EventArgs e)
        {

            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.Appearance.Text.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                    this.Appearance.Text.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                    this.Appearance.Text.Options.UseBackColor = true;

                }
            }
        }

        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {
            if (!IsNotApplyColorStyle)
            {
                //필수 +  읽기전용
                if (_isRequired == true && _isReadyOnly == true)
                {
                    this.Appearance.Text.BackColor = acInfo.ReadOnlyBackColor;

                    this.Appearance.Text.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Appearance.Text.Options.UseBackColor = true;

                }
                //필수
                else if (_isRequired == true && _isReadyOnly == false)
                {
                    this.Appearance.Text.BackColor = acInfo.RequiredBackColor;

                    this.Appearance.Text.ForeColor = acInfo.RequiredForeColor;

                    this.Appearance.Text.Options.UseBackColor = true;
                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Appearance.Text.BackColor = acInfo.ReadOnlyBackColor;

                    this.Appearance.Text.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Appearance.Text.Options.UseBackColor = true;
                }
                else
                {
                    this.Appearance.Text.BackColor = acInfo.StandardBackColor;

                    this.Appearance.Text.ForeColor = acInfo.StandardForeColor;

                    this.Appearance.Text.Options.UseBackColor = true;
                }
            }
            //this.Refresh();
        }

       
        protected override void OnCreateControl()
        {
            this.SetColor();

            this.Appearance.Text.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
            this.Appearance.Text.Options.UseFont = true;

            base.OnCreateControl();
        }

        #region IBaseControl 멤버


        private bool _isRequired = false;

        /// <summary>
        /// 필수입력 여부
        /// </summary>
        public bool isRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;

                this.SetColor();
            }
        }

        private bool _isReadyOnly = false;

        /// <summary>
        /// 읽기전용 여부
        /// </summary>
        public bool isReadyOnly
        {
            get
            {
                return _isReadyOnly;
            }
            set
            {
                _isReadyOnly = value;


                this.ReadOnly = _isReadyOnly;

                this.SetColor();

            }
        }

        private string _ColumnName = null;

        /// <summary>
        /// 컬럼명
        /// </summary>
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }


        public void FocusEdit()
        {
            this.Focus();
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

        private bool _isChanged = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool isChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }

		public DocumentFormat DocumentFormat { get => documentFormat; set => documentFormat = value; }


		#endregion
	}

}
