using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Data;

namespace ControlManager
{
    public class acComboBoxEdit : DevExpress.XtraEditors.ComboBoxEdit , IBaseEditControl
    {
        private object _SaveValue = null;

        private DataTable _dtDataSource = null;

        private string _keyColumnName = "";
        public acComboBoxEdit()
            : base()
        {

            //this.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            this.PreviewKeyDown += acComboBoxEdit_PreviewKeyDown;
            this.GotFocus += new EventHandler(acComboBoxEdit_GotFocus);
            this.LostFocus += new EventHandler(acComboBoxEdit_LostFocus);

            this.EnabledChanged += AcComboBoxEdit_EnabledChanged;
            this.EditValueChanged += AcComboBoxEdit_EditValueChanged;
        }

        private void AcComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (this.Enabled == true && this.EditValue.isNullOrEmpty() == false)
            if (this.Enabled == true)
            {
               this._SaveValue = this.EditValue;
            }
        }

        private void AcComboBoxEdit_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled == true && this._SaveValue.isNullOrEmpty() == false)
                this.EditValue = this._SaveValue;
        }

        void acComboBoxEdit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                acComboBoxEdit editor = sender as acComboBoxEdit;
                editor.EditValue = null;
            }
        }

        void acComboBoxEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acComboBoxEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        public DataRow GetSelectedRow()
        {
            DataRow[] rows = _dtDataSource.Select(String.Format(this._keyColumnName + " = '{0}'", this.SelectedText));

            if (rows.Length > 0)
                return rows[0];
            else
                return null;
        }
        public void SetCode(object catCode)
        {
            DataTable dtCatTable = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow dr in dtCatTable.Rows)
            {
                this.Properties.Items.Add(dr["CD_NAME"]);
            }
        }

        public void SetCode(object catCode, object parentCode)
        {
            DataTable dtCatTable = acInfo.StdCodes.GetCatTable(catCode, parentCode);

            foreach (DataRow dr in dtCatTable.Rows)
            {
                this.Properties.Items.Add(dr["CD_NAME"]);
            }

        }

        public void SetCodeValue(object catCode)
        {
            DataTable dtCatTable = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow dr in dtCatTable.Rows)
            {
                this.Properties.Items.Add(dr["VALUE"]);
            }

        }

        public void SetCodeDistinctValue(object catCode)
        {

            DataView view = acInfo.StdCodes.GetCatTable(catCode).AsDataView();

            DataTable distictTable = view.ToTable(true, "VALUE");

            foreach (DataRow dr in distictTable.Rows)
            {
                this.Properties.Items.Add(dr["VALUE"]);
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

        public void AddItem(DataTable dtSource, string keyColumnName )
        {
            try
            {
                this._keyColumnName = keyColumnName;
                _dtDataSource = dtSource;

                foreach (DataRow dr in dtSource.Rows)
                {
                    this.Properties.Items.Add(dr[keyColumnName]);
                }
                
            }
            catch { }
        }

        public void AddItem(DataTable dtSource, string keyColumnName, bool distinct)
        {
            try
            {
                DataTable dtDistinct = null;

                if (distinct)
                {
                    dtDistinct = dtSource.DefaultView.ToTable(true, keyColumnName);
                    AddItem(dtDistinct, keyColumnName);
                }
                else
                {
                    if (dtSource != null)
                        AddItem(dtSource, keyColumnName);
                }
            }
            catch { }
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
                this._SaveValue = this.EditValue;
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
            try
            {
                foreach (acCheckedListBoxItem item in this.Properties.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }

                this.EditValue = string.Empty;
            }
            catch { }
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
