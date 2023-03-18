using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemRadioComboBoxEdit : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemRadioComboBoxEdit()
        {
            Register();
        }


        public RepositoryItemRadioComboBoxEdit()
        {

        }


        internal const string EditorName = "acRadioComboBoxEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acRadioComboBoxEdit),
                typeof(RepositoryItemRadioComboBoxEdit), typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acRadioComboBoxEdit : acUserPopupContainerEdit, ControlManager.IBaseEditControl
    {



        private acRadioGroup acRadioGroup1 = null;


        private acPopupContainerControl acPopupContainerControl1 = null;

        static acRadioComboBoxEdit()
        {
            RepositoryItemRadioComboBoxEdit.Register();
        }

        public acRadioGroup RadioGroup
        {
            get
            {
                return this.acRadioGroup1;
            }
        }


        public void SetCode(string catCode)
        {

            DataTable dt = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in dt.Rows)
            {
                acRadioGroupItem item = new acRadioGroupItem(row["CD_CODE"], row["CD_NAME"].toStringNull(), row["SCOMMENT"].toStringNull());

                this.RadioGroup.Properties.Items.Add(item);

            }




        }


        public acRadioComboBoxEdit()
        {

            this.acRadioGroup1 = new acRadioGroup();
            this.acRadioGroup1.Dock = DockStyle.Fill;
            this.acRadioGroup1.BorderStyle = BorderStyles.NoBorder;

            this.acPopupContainerControl1 = new ControlManager.acPopupContainerControl();

            this.acPopupContainerControl1.Controls.Add(this.acRadioGroup1);
            this.acPopupContainerControl1.Location = new System.Drawing.Point(41, 50);
            this.acPopupContainerControl1.Name = "acPopupContainerControl1";
            this.acPopupContainerControl1.Size = new System.Drawing.Size(250, 78);
            this.acPopupContainerControl1.TabIndex = 1;

            this.Properties.PopupControl = acPopupContainerControl1;


            this.Properties.Buttons.Clear();


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton("DETAIL", DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});




            this.acRadioGroup1.EditValueChanged += new EventHandler(acRadioGroup1_EditValueChanged);

            this.GotFocus += new EventHandler(acRadioComboBoxEdit_GotFocus);
            this.LostFocus += new EventHandler(acRadioComboBoxEdit_LostFocus);

        }

        void acRadioComboBoxEdit_LostFocus(object sender, EventArgs e)
        {

            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acRadioComboBoxEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        void acRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            this._Value = this.acRadioGroup1.EditValue;

            if (!this._Value.isNull())
            {

                if (acRadioGroup1.ContainsRadioGroupItem(this._Value))
                {
                    this.EditValue = acRadioGroup1.GetRadioGroupItem(this._Value).Description;

                    return;
                }
            }


            this.EditValue = this._Value;

        }

        public override void CreateToolTip()
        {

            if (acInfo.IsRunTime == true)
            {
                acRadioGroupItem item = acRadioGroup1.GetRadioGroupItem(this._Value);

                if (item != null)
                {
                    if (item.GroupItemType == acRadioGroupItem.emGroupItemType.STANDARD)
                    {
                        if (item.UseToolTipID == true)
                        {
                            if (!item.ToolTipID.isNull())
                            {
                                SuperToolTip tt = acInfo.ToolTip.GetToolTip(item.ToolTipID);

                                ToolTipItem content = tt.Items[0] as ToolTipItem;

                                this.SuperTip = new SuperToolTip();

                                ToolTipTitleItem newTitle = new ToolTipTitleItem();
                                ToolTipItem newContent = new ToolTipItem();

                                newTitle.Text = this.EditValue.toStringNull();
                                newContent.Text = content.Text;

                                this.SuperTip.Items.Add(newTitle);
                                this.SuperTip.Items.Add(newContent);

                            }

                        }
                    }
                    else if (item.GroupItemType == acRadioGroupItem.emGroupItemType.CODE)
                    {
                        if (item.Comment.isNull() == false)
                        {
                            this.SuperTip = new SuperToolTip();

                            ToolTipTitleItem newTitle = new ToolTipTitleItem();
                            ToolTipItem newContent = new ToolTipItem();

                            newTitle.Text = this.EditValue.toStringNull();
                            newContent.Text = item.Comment;

                            this.SuperTip.Items.Add(newTitle);
                            this.SuperTip.Items.Add(newContent);
                        }

                    }

                }
            }
        }


        public override string EditorTypeName
        {
            get { return RepositoryItemRadioComboBoxEdit.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemRadioComboBoxEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemRadioComboBoxEdit;

            }
        }




        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

            if (this._isReadyOnly == false)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    if (this._isReadyOnly == false)
                    {

                        _Value = null;

                        this.acRadioGroup1.EditValue = _Value;

                    }

                }
            }

            base.OnKeyDown(e);
        }





        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {


            base.OnClickButton(buttonInfo);
        }


        protected override void OnCreateControl()
        {
            this.SetColor();

            base.OnCreateControl();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {

            this.SetColor();


            base.OnEnabledChanged(e);

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

        private object _Value = null;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {

                return _Value;

            }
            set
            {

                if (this.Enabled == false)
                    return;

                _Value = value;

                this.acRadioGroup1.EditValue = _Value;

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
            this.Value = null;
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
