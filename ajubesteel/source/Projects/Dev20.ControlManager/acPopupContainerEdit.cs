using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ControlManager
{
    public class acPopupContainerEdit : DevExpress.XtraEditors.PopupContainerEdit , IBaseEditControl
    {
        public acPopupContainerEdit()
            : base()
        {


            this.GotFocus += new EventHandler(acPopupContainerEdit_GotFocus);
            this.LostFocus += new EventHandler(acPopupContainerEdit_LostFocus);

        }

        void acPopupContainerEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acPopupContainerEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                this.ClosePopup();

                SendKeys.SendWait("{TAB}");


                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }


        #region IBaseControl 멤버


        public BaseEdit Editor
        {
            get
            {
                return this;
            }

        }




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

                if (_isReadyOnly == true)
                {
                    this.Properties.ReadOnly = true;
                }
                else
                {
                    this.Properties.ReadOnly = false;

                }

                this.SetColor();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                if (this.Enabled == false)
                    return;

                this.EditValue = value;
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

        public void Clear()
        {
            this.EditValue = null;
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

                this.SetSuperTip();

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

                this.SetSuperTip();
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


        #endregion

        private void SetSuperTip()
        {
            if (acInfo.IsRunTime == true)
            {
                if (_UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(_ToolTipID))
                    {
                        this.SuperTip = acInfo.ToolTip.GetToolTip(this._ToolTipID);
                    }
                }
            }
        }

        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {

            //필수 +  읽기전용
            if (_isRequired == true && _isReadyOnly == true)
            {
                this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

            }
            //필수 
            else if (_isRequired == true && _isReadyOnly == false)
            {
                this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;

                this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                this.Properties.Appearance.Options.UseBackColor = true;
            }

            //읽기전용
            else if (_isRequired == false && _isReadyOnly == true)
            {
                this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            }
            else
            {
                this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                this.Properties.Appearance.Options.UseBackColor = true;
            }

            //this.Refresh();
        }


    }
}
