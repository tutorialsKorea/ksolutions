using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ControlManager
{
    public class acCheckEdit : DevExpress.XtraEditors.CheckEdit, IBaseEditControl
    {



        public acCheckEdit()
            : base()
        {


            this.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;


            this.GotFocus += new EventHandler(acCheckEdit_GotFocus);

            this.LostFocus += new EventHandler(acCheckEdit_LostFocus);
        }

        void acCheckEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.Options.UseBackColor = false;

            }
        }

        void acCheckEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (acInfo.ReleaseMode == true)
            {
                if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
                {
                    SendKeys.SendWait("{TAB}");

                    return;

                }

            }

            base.OnKeyDown(e);
        }

        public enum emValueType { DEFAULT, INT, BYTE, STRING, YN };

        private emValueType _ValueType = emValueType.DEFAULT;

        public emValueType ValueType
        {
            get
            {
                return _ValueType;
            }

            set
            {
                _ValueType = value;

                switch (_ValueType)
                {
                    case emValueType.DEFAULT:

                        this.Properties.ValueChecked = (bool)true;

                        this.Properties.ValueUnchecked = (bool)false;

                        break;

                    case emValueType.BYTE:

                        this.Properties.ValueChecked = (byte)1;

                        this.Properties.ValueUnchecked = (byte)0;

                        break;

                    case emValueType.INT:

                        this.Properties.ValueChecked = 1;

                        this.Properties.ValueUnchecked = 0;

                        break;



                    case emValueType.STRING:

                        this.Properties.ValueChecked = (string)"1";

                        this.Properties.ValueUnchecked = (string)"0";

                        break;
                    case emValueType.YN:

                        this.Properties.ValueChecked = (string)"Y";

                        this.Properties.ValueUnchecked = (string)"N";

                        break;
                }

                //값 바꿈

                if (this.Checked == true)
                {
                    this.EditValue = this.Properties.ValueChecked;
                }
                else
                {
                    this.EditValue = this.Properties.ValueUnchecked;
                }


            }
        }

        private void SetSuperTip()
        {
            if (acInfo.IsRunTime == true)
            {
                if (_UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(_ToolTipID))
                    {
                        this.SuperTip = acInfo.ToolTip.GetToolTip(_ToolTipID);
                    }
                }
            }
        }


        #region IBaseEditControl 멤버





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

            }
        }

        /// <summary>
        /// 값
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            this.Checked = false;
        }


        public void FocusEdit()
        {

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
    }
}
