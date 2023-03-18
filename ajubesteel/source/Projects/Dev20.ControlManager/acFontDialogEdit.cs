using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Drawing.Text;
using System.Linq;
using System.IO;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemFontDialogEdit : RepositoryItemButtonEdit
    {
        static RepositoryItemFontDialogEdit()
        {
            Register();
        }


        public RepositoryItemFontDialogEdit()
        {


        }


        internal const string EditorName = "acFontDialogEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acFontDialogEdit),
                typeof(RepositoryItemFontDialogEdit), typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acFontDialogEdit : DevExpress.XtraEditors.ButtonEdit, IBaseEditControl
    {



        public acFontDialogEdit() :
            base()
        {

            this.GotFocus += new EventHandler(acFontDialogEdit_GotFocus);
            this.LostFocus += new EventHandler(acFontDialogEdit_LostFocus);

        }

        void acFontDialogEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acFontDialogEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        static acFontDialogEdit()
        {
            RepositoryItemFontDialogEdit.Register();
        }


        public override string EditorTypeName
        {
            get { return RepositoryItemFontDialogEdit.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemFontDialogEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemFontDialogEdit;

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


        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {

            FontDialog fontDlg = new FontDialog();

            System.Drawing.Font fnt = this.Font;


            if (this.Value != null)
            {
                fnt = this.Value as System.Drawing.Font;
            }

            fontDlg.Font = new Font(fnt, fnt.Style);


            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                this.Value = fontDlg.Font;
            }


            base.OnClickButton(buttonInfo);
        }


        public static void InstallFont(string fontFileName)
        {
            FileInfo f = new FileInfo(fontFileName);

            string fontPath = string.Format(@"{0}\{1}\{2}", System.Environment.GetEnvironmentVariable("windir"), "Fonts", f.Name);

            f.CopyTo(fontPath, true);

           
            WIN32API.AddFontResource(fontPath);

            WIN32API.SendMessage(WIN32API.HWND_BROADCAST, WIN32API.WM_FONTCHANGE, 0, 0);

            WIN32API.WriteProfileString("fonts", acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT") + " (TrueType)", f.Name); 
           

        }


        public static bool IsInstallFontName(string fontName)
        {
            var arialFontFamilies = from fontFamily in new InstalledFontCollection().Families
                                    where fontFamily.Name.Contains(fontName)
                                    select fontFamily;


            foreach (FontFamily f in arialFontFamilies)
            {
                if (f.Name == fontName)
                {
                    return true;
                }

            }

            return false;

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
