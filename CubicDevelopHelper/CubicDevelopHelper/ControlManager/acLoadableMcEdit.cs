using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemLoadableMcEdit : RepositoryItemButtonEdit
    {
        static RepositoryItemLoadableMcEdit()
        {
            Register();
        }


        internal const string EditorName = "acLoadableMcEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acLoadableMcEdit),
                typeof(RepositoryItemLoadableMcEdit), typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acLoadableMcEdit : DevExpress.XtraEditors.ButtonEdit, IBaseEditControl
    {


        private object _ProcCode = null;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object ProcCode
        {
            get { return _ProcCode; }
            set { _ProcCode = value; }
        }



        public acLoadableMcEdit() :
            base()
        {

            this.GotFocus += new EventHandler(acLoadableMcEdit_GotFocus);
            this.LostFocus += new EventHandler(acLoadableMcEdit_LostFocus);

        }

        void acLoadableMcEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acLoadableMcEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        static acLoadableMcEdit()
        {
            RepositoryItemLoadableMcEdit.Register();
        }


        public override string EditorTypeName
        {
            get { return RepositoryItemLoadableMcEdit.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemLoadableMcEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemLoadableMcEdit;

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


        protected override void OnCreateControl()
        {

            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.SetColor();

            base.OnCreateControl();
        }


        protected override void OnEnabledChanged(EventArgs e)
        {

            this.SetColor();


            base.OnEnabledChanged(e);

        }

        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            base.OnClickButton(buttonInfo);

            acLoadableMcForm frm = new acLoadableMcForm();



            frm.ParentControl = this;


            if (frm.ShowDialog() == DialogResult.OK)
            {

                this.Value = frm.OutputData;

            }



        }


        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {

            if (this.Enabled == true)
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
