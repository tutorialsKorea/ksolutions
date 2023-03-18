using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ControlManager
{
    public class acTimeEdit : DevExpress.XtraEditors.TimeEdit, IBaseEditControl
    {
        public acTimeEdit()
            : base()
        {

            this.GotFocus += new EventHandler(acTimeEdit_GotFocus);
            this.LostFocus += new EventHandler(acTimeEdit_LostFocus);

        }

        void acTimeEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acTimeEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }
        protected override void OnCreateControl()
        {
            this.SetColor();

            base.OnCreateControl();
        }


        protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                SendKeys.SendWait("{TAB}");


                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }






        private string _CreateParameterFormat = null;

        /// <summary>
        /// 파라메터 생성시 포맷을 설정하거나 반환합니다.
        /// </summary>
        public string CreateParameterFormat
        {
            get { return _CreateParameterFormat; }
            set { _CreateParameterFormat = value; }
        }


        protected override void OnEditValueChanged()
        {
            if (this.EditValue is string)
            {
                string value = (string)this.EditValue;

                value = value.Replace("-", "");
                value = value.Replace(":", "");
                value = value.Replace(" ", "");

                if (value.Length == 8)
                {
                    DateTime resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                     System.Convert.ToInt32(value.Substring(4, 2)),
                                     System.Convert.ToInt32(value.Substring(6, 2)));

                    this.EditValue = resultDataTime;


                }
                else if (value.Length == 12)
                {
                    DateTime resultDataTime = new DateTime(
                            System.Convert.ToInt32(value.Substring(0, 4)),
                            System.Convert.ToInt32(value.Substring(4, 2)),
                            System.Convert.ToInt32(value.Substring(6, 2)),
                            System.Convert.ToInt32(value.Substring(8, 2)),
                            System.Convert.ToInt32(value.Substring(10, 2)),
                            0
                            );

                    this.EditValue = resultDataTime;

                }
                else if (value.Length == 14)
                {
                    DateTime resultDataTime = new DateTime(
                            System.Convert.ToInt32(value.Substring(0, 4)),
                            System.Convert.ToInt32(value.Substring(4, 2)),
                            System.Convert.ToInt32(value.Substring(6, 2)),
                            System.Convert.ToInt32(value.Substring(8, 2)),
                            System.Convert.ToInt32(value.Substring(10, 2)),
                            System.Convert.ToInt32(value.Substring(12, 2))
                            );

                    this.EditValue = resultDataTime;
                }
                else
                {

                    this.EditValue = null;
                }

            }
            else if (this.EditValue is DateTime)
            {

            }
            else
            {
                this.EditValue = null;
            }


            base.OnEditValueChanged();
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

                this.Properties.ReadOnly = _isReadyOnly;

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
                //Format 변환

                if (this.EditValue != null)
                {

                    if (!string.IsNullOrEmpty(this._CreateParameterFormat))
                    {
                        
                        string dateString = this.Time.ToString(this._CreateParameterFormat);

                        return dateString;
                    }
                    else
                    {
                        return this.EditValue;
                    }
                }
                else
                {

                    return this.EditValue;
                }

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

        #endregion
    }
}
