using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemTimeSpinEdit : RepositoryItemSpinEdit
    {
        static RepositoryItemTimeSpinEdit()
        {
            Register();
        }





        public RepositoryItemTimeSpinEdit()
        {


            base.Buttons.Clear();


            this.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            this.Mask.EditMask = "d";


            this.Mask.UseMaskAsDisplayFormat = true;

            this.Enter += new EventHandler(RepositoryItemTimeSpinEdit_Enter);

            this.Leave += new EventHandler(RepositoryItemTimeSpinEdit_Leave);

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { 
                new DevExpress.XtraEditors.Controls.EditorButton(),
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::ControlManager.Resource.arrow_refresh_x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "H_CONVERT") });


        }



        void RepositoryItemTimeSpinEdit_Leave(object sender, EventArgs e)
        {
            acTimeSpinEdit edit = sender as acTimeSpinEdit;

            edit.PressButtonCnt = 0;
        }


        private object _ParentControl = null;


        [Browsable(false)]
        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }


        void RepositoryItemTimeSpinEdit_Enter(object sender, EventArgs e)
        {
            acTimeSpinEdit edit = sender as acTimeSpinEdit;

            edit.ParentControl = this.ParentControl;

        }




        internal const string EditorName = "acTimeSpinEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acTimeSpinEdit),
                typeof(RepositoryItemTimeSpinEdit), typeof(DevExpress.XtraEditors.ViewInfo.BaseSpinEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acTimeSpinEdit : DevExpress.XtraEditors.SpinEdit, IBaseEditControl
    {
        static acTimeSpinEdit()
        {
            RepositoryItemTimeSpinEdit.Register();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemTimeSpinEdit.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemTimeSpinEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemTimeSpinEdit;

            }
        }

        public acTimeSpinEdit()
        {



            this.Properties.Buttons.Clear();


            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            this.Properties.Mask.EditMask = "d";

            this.Properties.Mask.UseMaskAsDisplayFormat = true;

            this.EditValue = 0;

            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            this.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { 
                new DevExpress.XtraEditors.Controls.EditorButton() ,
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::ControlManager.Resource.arrow_refresh_x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "H_CONVERT") });

            this.GotFocus += new EventHandler(acTimeSpinEdit_GotFocus);
            this.LostFocus += new EventHandler(acTimeSpinEdit_LostFocus);


        }

        void acTimeSpinEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetStyle();

            }
        }

        void acTimeSpinEdit_GotFocus(object sender, EventArgs e)
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
                SendKeys.SendWait("{TAB}");

                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }


        internal int PressButtonCnt = 0;


        private object _ParentControl = null;

        [Browsable(false)]
        [DefaultValue(null)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }


        protected override void OnSpin(SpinEventArgs e)
        {
            //RepositoryItem 에서는 처음 이벤트 발생시 처리하지않도록한다.
  

            if (this.ParentControl is acGridView)
            {
                if (this.PressButtonCnt == 0)
                {
                    e.Handled = true;
                }
            }


            ++PressButtonCnt;

            base.OnSpin(e);
        }


        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
 


            if (this.ParentControl is acGridView)
            {

                if (this.PressButtonCnt > 0)
                {
                    if (buttonInfo.Button.Tag != null)
                    {

                        if (buttonInfo.Button.Tag.Equals("H_CONVERT"))
                        {
                            this.TimeConvert(60);
                        }
                    }
                }

            }
            else
            {
                if (buttonInfo.Button.Tag != null)
                {

                    if (buttonInfo.Button.Tag.Equals("H_CONVERT"))
                    {
                        this.TimeConvert(60);
                    }
                }
            }

            ++PressButtonCnt;

            base.OnClickButton(buttonInfo);

        }
      
        void TimeConvert(decimal vaule)
        {

            this.EditValue = this.EditValue.toDecimal() * vaule;
        }

        protected override void OnEditValueChanged()
        {

            if (this.EditValue == null)
            {
                this.EditValue = 0;

            }
            else if (this.EditValue.toDecimal() < 0)
            {
                this.EditValue = 0;
            }

            base.OnEditValueChanged();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }


        protected override void OnEnabledChanged(EventArgs e)
        {

            this.SetStyle();


            base.OnEnabledChanged(e);

        }

        private void SetSuperTip()
        {
            if (acInfo.IsRunTime == true)
            {
                if (_UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(_ToolTipID))
                    {
                        this.SuperTip =  acInfo.ToolTip.GetToolTip(_ToolTipID);
                    }
                }
            }
        }

        /// <summary>
        /// 속성에 따른 형태 변경
        /// </summary>
        private void SetStyle()
        {

            if (this.Enabled == true)
            {
                //필수 +  읽기전용
                if (_isRequired == true && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag != null)
                        {
                            if (btn.Tag.Equals("H_CONVERT"))
                            {
                                btn.Enabled = false;
                            }
                        }

                    }

                }
                //필수 
                else if (_isRequired == true && _isReadyOnly == false)
                {
                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag != null)
                        {
                            if (btn.Tag.Equals("H_CONVERT"))
                            {
                                btn.Enabled = true;
                            }
                        }

                    }
                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag != null)
                        {
                            if (btn.Tag.Equals("H_CONVERT"))
                            {
                                btn.Enabled = false;
                            }
                        }

                    }
                }
                else
                {
                    this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag != null)
                        {
                            if (btn.Tag.Equals("H_CONVERT"))
                            {
                                btn.Enabled = true;
                            }
                        }

                    }
                }

            }
            else
            {

                this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;
                this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;
            }


        }

        protected override void OnCreateControl()
        {

            if (acInfo.IsRunTime == true)
            {
                //툴팁 설정

                //분 변환
                this.Properties.Buttons[1].SuperTip =  acInfo.ToolTip.GetToolTip("GFGLMJ3Z");


            }

            this.SetStyle();

            base.OnCreateControl();
        }



        #region IBaseEditControl 멤버


        public BaseEdit Editor
        {
            get
            {
                return this;
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


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object Value
        {
            get
            {
                return this.EditValue;
            }
            set
            {
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

            this.EditValue = 0;

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

                this.SetStyle();
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

                this.SetStyle();
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
