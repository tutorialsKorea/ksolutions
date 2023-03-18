using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace ControlManager
{
    public class acColorEdit : DevExpress.XtraEditors.ColorEdit, IBaseEditControl
    {



        public acColorEdit()
            : base()
        {

            this.GotFocus += new EventHandler(acColorEdit_GotFocus);
            this.LostFocus += new EventHandler(acColorEdit_LostFocus);
        }

        void acColorEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acColorEdit_GotFocus(object sender, EventArgs e)
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




        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Delete || e.KeyData == System.Windows.Forms.Keys.Back)
            {

                this.EditValue = System.Drawing.Color.Empty;

            }

            base.OnKeyDown(e);
        }

        public static Color FromArgb(int argb)
        {
            if (argb == 0)
            {
                return Color.Empty;

            }
            else
            {
                return Color.FromArgb(argb);
            }
        }


        /// <summary>
        /// 반전색상을 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color GetReverseColor(Color value)
        {
            int r = 255 - value.R;

            int g = 255 - value.G;

            int b = 255 - value.B;

            return Color.FromArgb(value.A, r, g, b);


        }

        public static Color FromName(string name)
        {
            try
            {
                return Color.FromName(name);
            }
            catch
            {
                return Color.Empty;
            }
        }

        public static Color GetBoldColor(Color color)
        {


            int rm = (color.R * 0.5).toInt();

            int r = color.R - rm;

            int gm = (color.G * 0.5).toInt();

            int g = color.G - gm;

            int bm = (color.B * 0.5).toInt();

            int b = color.B - bm;

            return Color.FromArgb(color.A, r, g, b);


        }

        public static Color GetGradientColor(Color startColor, Color endColor, int location)
        {
            List<Color> gradientColors = new List<Color>();

            for (int i = 0; i < 101; i++)
            {
                int r = Interpolate(startColor.R, endColor.R, 100, i),
                    g = Interpolate(startColor.G, endColor.G, 100, i),
                    b = Interpolate(startColor.B, endColor.B, 100, i);

                gradientColors.Add(Color.FromArgb(r, g, b));
            }

            return gradientColors[location];
        }

        private static int Interpolate(int start, int end, int steps, int count)
        {
            float s = start, e = end, final = s + (((e - s) / steps) * count); return (int)final;
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

        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {

            //필수 +  읽기전용

            if (this.Enabled == true)
            {

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
            }
            else
            {
                this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                this.Properties.Appearance.Options.UseBackColor = true;
            }

            //this.Refresh();

        }

        protected override void OnCreateControl()
        {
            this.SetColor();
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

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        btn.Visible = false;
                    }


                }
                else
                {
                    this.Properties.ReadOnly = false;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        btn.Visible = true;
                    }
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
                return this.Color.ToArgb();
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
    }
}
