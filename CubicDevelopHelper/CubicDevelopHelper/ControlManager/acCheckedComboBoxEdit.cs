using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using BizManager;

namespace ControlManager
{
    public class acCheckedComboBoxEdit : DevExpress.XtraEditors.CheckedComboBoxEdit, IBaseEditControl
    {

        public acCheckedComboBoxEdit()
            : base()
        {
            this.GotFocus += new EventHandler(acCheckedComboBoxEdit_GotFocus);

            this.LostFocus += new EventHandler(acCheckedComboBoxEdit_LostFocus);
        }

        void acCheckedComboBoxEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetColor();

            }
        }

        void acCheckedComboBoxEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }


        public void CreateToolTip()
        {
            if (!this.EditValue.isNull())
            {

                this.SuperTip = new SuperToolTip();

                ToolTipItem contentTT = new ToolTipItem();

                contentTT.Text = this.EditValue.toStringNull();

                this.SuperTip.Items.Add(contentTT);
            }
            else
            {
                if (this.SuperTip != null)
                {
                    this.SuperTip.Items.Clear();
                }

            }

        }



        protected override void OnEditValueChanged()
        {

            this.CreateToolTip();


            base.OnEditValueChanged();
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyData == System.Windows.Forms.Keys.Delete || e.KeyData == System.Windows.Forms.Keys.Back)
            {
                this.Value = string.Empty;
            }


            base.OnKeyDown(e);

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



        public void AddItem(string catCode, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataTable dt = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in dt.Rows)
            {
                this.AddItem(row["CD_NAME"].ToString(), false, "", row["CD_CODE"].ToString(), checkedValue, uncheckedValue, defaultCheckd);
            }

        }


        public void AddItem(string displayName, string valueName, DataTable dataTable, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            

            foreach (DataRow row in dataTable.Rows)
            {
                this.AddItem(row[displayName].ToString(), false, "", row[valueName].ToString(), checkedValue, uncheckedValue, defaultCheckd);
            }

        }

        public void AddItem(string displayName, string valueName,DataSet paramSet, string ruleName, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {
      
            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, ruleName, paramSet, "RQSTDT", "RSLTDT");

            AddItem(displayName, valueName, paramSet.Tables["RSLTDT"], checkedValue, uncheckedValue, defaultCheckd);

        }

        public void AddItem(string displayName, string valueName, DataSet paramSet,string outTableName, string ruleName, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, ruleName, paramSet, "RQSTDT", outTableName);

            AddItem(displayName, valueName, paramSet.Tables[outTableName], checkedValue, uncheckedValue, defaultCheckd);

        }

        public void AddItem(string displayName, string valueName, string ruleName, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, ruleName, paramSet, "RQSTDT", "RSLTDT");

            AddItem(displayName, valueName, paramSet, ruleName, checkedValue, uncheckedValue, defaultCheckd);

        }

        //사용안함
        //public void AddItemPlants(object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        //{

        //    DataTable paramTable = new DataTable();

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    DataSet resultSet = acInfo.QBizActorRun.ExecuteService(this, "TSYS_PLANTS_SER", paramSet, "", "RSLTDT");



        //    foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
        //    {
        //        this.AddItem(row["PLT_NAME"].ToString(), false, null, row["PLT_CODE"].ToString(), checkedValue, uncheckedValue, defaultCheckd);
        //    }

        //}

        public void SetCodes(string catCode, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataSet paramSet = new DataSet();

            DataTable dtResult = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in dtResult.Rows)
            {
                this.AddItem(row["CD_NAME"].ToString(), false, null, row["CD_CODE"].ToString(), checkedValue, uncheckedValue, defaultCheckd);
            }

        }

        public void SetData(DataTable dtData, string displayName, string key, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            
            foreach (DataRow row in dtData.Rows)
            {
                this.AddItem(row[displayName].ToString(), false, null, row[key].ToString(), checkedValue, uncheckedValue, defaultCheckd);
            }

        }

        /// <summary>
        /// 아이템을 추가합니다.
        /// </summary>
        /// <param name="displayValue">표시값</param>
        /// <param name="key">키값</param>
        /// <param name="chekedValue">체크할때값</param>
        /// <param name="uncheckedValue">체크안할때값</param>
        /// <param name="defaultCheked">기본체크</param>
        public void AddItem(
            string displayName,
            bool useResourceID,
            string resourceID,
            string key,
            object chekedValue,
            object uncheckedValue,
            System.Windows.Forms.CheckState defaultCheked)
        {
            acCheckedListBoxItem item = new acCheckedListBoxItem(
                displayName,
                useResourceID,
                resourceID,
                key,
                chekedValue,
                uncheckedValue,
                defaultCheked);

            this.Properties.Items.Add(item);



        }

        public void RemoveItem(int i)
        {
            this.Properties.Items.RemoveAt(i);
        }


        public void AddItem(
    string displayName,
    bool useResourceID,
    string resourceID,
    string key,
    object chekedValue,
    object uncheckedValue)
        {
            acCheckedListBoxItem item = new acCheckedListBoxItem(
                displayName,
                useResourceID,
                resourceID,
                key,
                chekedValue,
                uncheckedValue);

            this.Properties.Items.Add(item);


        }

        public void AddItem(acCheckedListBoxItem item)
        {
            this.Properties.Items.Add(item);
        }

        public acCheckedListBoxItem GetItem(string key)
        {

            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {
                if (item.Key == key)
                {
                    return item;
                }

            }

            return null;

        }


        /// <summary>
        /// 키값을 모두 알아옵니다.
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            List<string> keyList = new List<string>();

            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {

                keyList.Add(item.Key);

            }

            return keyList;

        }

        /// <summary>
        /// 체크된 키값을 모두 알아옵니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<string> GetKeyChecked()
        {
            List<string> keyList = new List<string>();

            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {
                if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    keyList.Add(item.Key);

                }

            }

            return keyList;

        }

        /// <summary>
        /// 키값으로 값을 알아옵니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetKeyValue(string key)
        {
            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {
                if (item.Key == key)
                {
                    if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        return item.CheckedValue;
                    }
                    else if (item.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    {
                        return item.UnCheckedValue;
                    }

                }

            }

            return null;

        }


        /// <summary>
        /// 키값으로 값을 설정합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void SetKeyValue(string key, object value)
        {


            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {
                if (item.Key == key)
                {
                    if (item.CheckedValue.EqualsEx(value))
                    {

                        item.CheckState = System.Windows.Forms.CheckState.Checked;

                        break;
                    }
                    else if (item.UnCheckedValue.EqualsEx(value))
                    {

                        item.CheckState = System.Windows.Forms.CheckState.Unchecked;

                        break;
                    }

                }

            }



        }




        /// <summary>
        /// 키값으로 체크와 사용여부를 설정한다.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="checkValue"></param>
        /// <param name="enabledValue"></param>
        public void SetKeyEnabled(string key, System.Windows.Forms.CheckState checkValue, bool enabledValue)
        {
            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {
                if (item.Key == key)
                {
                    item.CheckState = checkValue;

                    item.Enabled = enabledValue;


                    return;

                }

            }

        }


        /// <summary>
        /// 체크된 아이템이 하나라도 있는지 확인한다.
        /// </summary>
        /// <returns></returns>
        public bool isChecked()
        {

            foreach (acCheckedListBoxItem item in this.Properties.Items)
            {

                if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    return true;
                }

            }

            return false;

        }

        protected override void OnEnabledChanged(EventArgs e)
        {

            this.SetColor();


            base.OnEnabledChanged(e);

        }

        protected override void OnCreateControl()
        {
            this.SetColor();
            this.Properties.SelectAllItemVisible = false;

            base.OnCreateControl();
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
                this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.Appearance.Options.UseBackColor = true;

                this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                this.Properties.AppearanceReadOnly.Options.UseBackColor = true;
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


                List<string> checkedList = this.GetKeyChecked();

                string checkedString = string.Empty;

                int cnt = 0;

                foreach (string key in checkedList)
                {
                    checkedString += key;

                    ++cnt;

                    if (checkedList.Count > cnt)
                    {
                        checkedString += ",";
                    }
                }

                return checkedString;


            }
            set
            {
                if (this.Enabled == false)
                    return;

                string[] checkedKeys = value.ToString().Split(',');

                string checkedString = string.Empty;

                int cnt = 0;

                foreach (acCheckedListBoxItem item in this.Properties.Items)
                {
                    this.SetKeyValue(item.Key, item.UnCheckedValue);
                }


                foreach (string checkedKey in checkedKeys)
                {
                    acCheckedListBoxItem item = this.GetItem(checkedKey);

                    if (item != null)
                    {

                        this.SetKeyValue(item.Key, item.CheckedValue);

                        checkedString += item.ToString();

                        ++cnt;

                        if (checkedKeys.Length > cnt)
                        {
                            checkedString += ",";
                        }


                    }
                }


                this.EditValue = checkedString;



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

    public class acCheckedListBoxItem : DevExpress.XtraEditors.Controls.CheckedListBoxItem, IBaseViewControl
    {

        private string _Key = null;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private object _CheckedValue = null;

        public object CheckedValue
        {
            get { return _CheckedValue; }
            set { _CheckedValue = value; }
        }


        private object _UnCheckedValue = null;


        public object UnCheckedValue
        {
            get { return _UnCheckedValue; }
            set { _UnCheckedValue = value; }
        }



        public acCheckedListBoxItem()
            : base()
        {



        }

        public acCheckedListBoxItem(
    string displayName,
    bool useResourceID,
    string resourceID,
    string key,
    object checkedValue,
    object uncheckedValue)
        {


            this._UseResourceID = useResourceID;

            this._ResourceID = resourceID;

            if (useResourceID == true)
            {

                this.Value = acInfo.Resource.GetString(displayName, resourceID);
            }
            else
            {
                this.Value = displayName;
            }

            this._Key = key;

            this._CheckedValue = checkedValue;

            this._UnCheckedValue = uncheckedValue;

            this.CheckState = System.Windows.Forms.CheckState.Unchecked;

        }

        public acCheckedListBoxItem(
            string displayName,
            bool useResourceID,
            string resourceID,
            string key,
            object checkedValue,
            object uncheckedValue,
            System.Windows.Forms.CheckState defaultCheked)
        {

            this._UseResourceID = useResourceID;

            this._ResourceID = resourceID;

            if (useResourceID == true)
            {
                this.Value = acInfo.Resource.GetString(displayName, resourceID);
            }
            else
            {
                this.Value = displayName;
            }

            this._Key = key;

            this._CheckedValue = checkedValue;

            this._UnCheckedValue = uncheckedValue;

            this.CheckState = defaultCheked;

        }



        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
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

        #endregion
    }
}
