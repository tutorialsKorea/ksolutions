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
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemCodeGeneratorEdit : RepositoryItemButtonEdit
    {
        static RepositoryItemCodeGeneratorEdit()
        {
            Register();
        }


        public RepositoryItemCodeGeneratorEdit()
        {


            base.Buttons.Clear();

            if (acInfo.IsRunTime == true)
            {
                this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_CODE_TYPE");

                this.Properties.Mask.UseMaskAsDisplayFormat = true;
            }

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { 
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::ControlManager.Resource.book_key_x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "GENERATOR") });




        }


        internal const string EditorName = "acCodeGeneratorEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acCodeGeneratorEdit),
                typeof(RepositoryItemCodeGeneratorEdit), typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acCodeGeneratorEdit : DevExpress.XtraEditors.ButtonEdit, IBaseEditControl
    {

        private Control _ParentControl = null;

        [DefaultValue(null)]
        public Control ParentControl
        {
            get { return _ParentControl; }

            set
            {

                _ParentControl = value;
            }
        }

        static acCodeGeneratorEdit()
        {
            RepositoryItemCodeGeneratorEdit.Register();
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemCodeGeneratorEdit.EditorName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCodeGeneratorEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemCodeGeneratorEdit;

            }
        }




        public acCodeGeneratorEdit()
        {

            this.Properties.Buttons.Clear();


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { 
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::ControlManager.Resource.book_key_x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "GENERATOR") });


            if (acInfo.IsRunTime == true)
            {

                this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_CODE_TYPE");

                this.Properties.Mask.UseMaskAsDisplayFormat = true;
            }


            this.GotFocus += new EventHandler(acCodeGeneratorEdit_GotFocus);
            this.LostFocus += new EventHandler(acCodeGeneratorEdit_LostFocus);

        }

        void acCodeGeneratorEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetStyle();

            }
        }

        void acCodeGeneratorEdit_GotFocus(object sender, EventArgs e)
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




        protected override void OnPressButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            if (buttonInfo.Button.Tag.EqualsEx("GENERATOR"))
            {
                

                if (this.OnGenerateCode != null)
                {
                    this.OnGenerateCode(this);
                }

            }

            base.OnPressButton(buttonInfo);
        }

        public void GenerateCode(string generatorType , DataTable refData)
        {
            //코드생성

            try
            {
                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("GENERATOR_TYPE", typeof(String)); //
                //paramTable.Columns.Add("REF_DATA", typeof(Byte[])); //

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["GENERATOR_TYPE"] = generatorType;
                //paramRow["REF_DATA"] = this.GetRefDataToByte(refData);
                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);


                //DataSet resultSet = acInfo.QBizActorRun.ExecuteService(this, "GET_GENERATE_CODE", paramSet, "RQSTDT", "RSLTDT");

                //if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                //{
                //    this.Value = resultSet.Tables["RSLTDT"].Rows[0]["CODE"];
                //}
                //else
                //{
                //    acMessageBox.Show(this, "코드 생성규칙이 존재하지않습니다.", "GEWQN0ZH", true, acMessageBox.emMessageBoxType.CONFIRM);

                //    return;

                //}

            }
            catch
            {
                acMessageBox.Show(this,"코드 생성규칙을 찾을수 없습니다.", "LWH1U07Y", true, acMessageBox.emMessageBoxType.CONFIRM);
            }

        }

        public delegate void GenerateCodeEventHandler(object sender);

        public event GenerateCodeEventHandler OnGenerateCode;

        private byte[] GetRefDataToByte(DataTable refData)
        {
            MemoryStream st = new MemoryStream();

            BinaryFormatter format = new BinaryFormatter();

            format.Serialize(st, refData);

            byte[] result = st.ToArray();

            st.Close();

            return result;
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
                            if (btn.Tag.Equals("GENERATOR"))
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
                            if (btn.Tag.Equals("GENERATOR"))
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
                            if (btn.Tag.Equals("GENERATOR"))
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
                            if (btn.Tag.Equals("GENERATOR"))
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
            if (this.ParentControl == null)
            {
                this.ParentControl = this.GetContainerControl() as Control;
            }

            if (acInfo.IsRunTime == true)
            {
                //툴팁 설정
                this.Properties.Buttons[0].SuperTip =  acInfo.ToolTip.GetToolTip("B92D5JOW");

                this.Properties.Buttons[0].Image = ControlManager.Resource.book_key_x16;

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
