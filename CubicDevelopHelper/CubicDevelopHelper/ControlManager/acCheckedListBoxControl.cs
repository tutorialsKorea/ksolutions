using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using BizManager;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace ControlManager
{


    public class acListBoxItemPainter : ListBoxItemPainter
    {
        public acListBoxItemPainter() : base() { }
        protected override void DrawItemBar(ListBoxItemObjectInfoArgs e) { e.PaintAppearance.FillRectangle(e.Cache, e.Bounds); }
    }

    public class acBaseListBoxViewInfo : CheckedListBoxViewInfo
    {
        public acBaseListBoxViewInfo(CheckedListBoxControl owner) : base(owner) { }

        protected override BaseListBoxItemPainter CreateItemPainter()
        {
            base.CreateItemPainter();
            if (IsSkinnedHighlightingEnabled) return new acListBoxSkinItemPainter();
            return new acListBoxItemPainter();
        }
    }

    public class acListBoxSkinItemPainter : ListBoxSkinItemPainter
    {
        public acListBoxSkinItemPainter() : base() { }
        protected override void DrawItemBar(ListBoxItemObjectInfoArgs e)
        {
            e.ItemState = DrawItemState.Default;
            e.PaintAppearance.ForeColor = System.Drawing.Color.Black;
            DrawItemBarCore(e);
        }
    }

    public class acCheckedListBoxControl : DevExpress.XtraEditors.CheckedListBoxControl//, IBaseEditControl
    {

        public acCheckedListBoxControl()
            : base()
        {
            //this.GotFocus += new EventHandler(acCheckedListBoxControl_GotFocus);

            //this.LostFocus += new EventHandler(acCheckedListBoxControl_LostFocus);
        }


        protected override BaseStyleControlViewInfo CreateViewInfo()
        {
            return new acBaseListBoxViewInfo(this);
        }

        //void acCheckedListBoxControl_LostFocus(object sender, EventArgs e)
        //{
        //    if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
        //    {
        //        this.SetColor();

        //    }
        //}

        //void acCheckedListBoxControl_GotFocus(object sender, EventArgs e)
        //{
        //    if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
        //    {
        //        this.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

        //        this.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

        //        this.Appearance.Options.UseBackColor = true;

        //    }
        //}


        //public void CreateToolTip()
        //{
        //    if (!this.Value.isNull())
        //    {

        //        this.SuperTip = new SuperToolTip();

        //        ToolTipItem contentTT = new ToolTipItem();

        //        contentTT.Text = this.Value.toStringNull();

        //        this.SuperTip.Items.Add(contentTT);
        //    }
        //    else
        //    {
        //        if (this.SuperTip != null)
        //        {
        //            this.SuperTip.Items.Clear();
        //        }

        //    }

        //}



        //protected override void OnTextChanged()
        //{

        //    this.CreateToolTip();


        //    base.OnTextChanged();
        //}

        //protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        //{

        //    if (e.KeyData == System.Windows.Forms.Keys.Delete || e.KeyData == System.Windows.Forms.Keys.Back)
        //    {
        //        this.Value = string.Empty;
        //    }


        //    base.OnKeyDown(e);

        //}

        //protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
        //    {
        //        this.ClosePopup();

        //        SendKeys.SendWait("{TAB}");


        //        return;


        //    }

        //    base.OnEditorKeyDownProcessNullInputKeys(e);
        //}



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


        public void SetCodes(string catCode, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataSet paramSet = new DataSet();

            DataTable dtResult = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in dtResult.Rows)
            {
                this.AddItem(row["CD_NAME"].ToString(), false, null, row["CD_CODE"].ToString(), checkedValue, uncheckedValue, defaultCheckd);
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

            this.Items.Add(item);



        }

        public void RemoveItem(int i)
        {
            this.Items.RemoveAt(i);
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

            this.Items.Add(item);


        }

        public void AddItem(acCheckedListBoxItem item)
        {
            this.Items.Add(item);
        }

        public acCheckedListBoxItem GetItem(string key)
        {

            foreach (acCheckedListBoxItem item in this.Items)
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

            foreach (acCheckedListBoxItem item in this.Items)
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

            foreach (acCheckedListBoxItem item in this.Items)
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
            foreach (acCheckedListBoxItem item in this.Items)
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


            foreach (acCheckedListBoxItem item in this.Items)
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
            foreach (acCheckedListBoxItem item in this.Items)
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
        //public bool isChecked()
        //{

        //    foreach (acCheckedListBoxItem item in this.Items)
        //    {

        //        if (item.CheckState == System.Windows.Forms.CheckState.Checked)
        //        {
        //            return true;
        //        }

        //    }

        //    return false;

        //}

        //protected override void OnEnabledChanged(EventArgs e)
        //{

        //    //this.SetColor();


        //    base.OnEnabledChanged(e);

        //}

        //protected override void OnCreateControl()
        //{
        //    //this.SetColor();
        //    //this.SelectAllItemVisible = false;

        //    base.OnCreateControl();
        //}

        ///// <summary>
        ///// 속성에 따른 배경색 결정
        ///// </summary>
        //private void SetColor()
        //{

        //    //필수 +  읽기전용

        //    if (this.Enabled == true)
        //    {

        //        if (_isRequired == true && _isReadyOnly == true)
        //        {
        //            this.AppearanceDisabled.BackColor = acInfo.ReadOnlyBackColor;

        //            this.AppearanceDisabled.ForeColor = acInfo.ReadOnlyForeColor;

        //            this.AppearanceDisabled.Options.UseBackColor = true;

        //        }
        //        //필수 
        //        else if (_isRequired == true && _isReadyOnly == false)
        //        {
        //            this.Appearance.BackColor = acInfo.RequiredBackColor;

        //            this.Appearance.ForeColor = acInfo.RequiredForeColor;

        //            this.Appearance.Options.UseBackColor = true;
        //        }

        //        //읽기전용
        //        else if (_isRequired == false && _isReadyOnly == true)
        //        {
        //            this.AppearanceDisabled.BackColor = acInfo.ReadOnlyBackColor;

        //            this.AppearanceDisabled.ForeColor = acInfo.ReadOnlyForeColor;

        //            this.AppearanceDisabled.Options.UseBackColor = true;
        //        }
        //        else
        //        {
        //            this.Appearance.BackColor = acInfo.StandardBackColor;

        //            this.Appearance.ForeColor = acInfo.StandardForeColor;

        //            this.Appearance.Options.UseBackColor = true;
        //        }
        //    }
        //    else
        //    {
        //        this.Appearance.BackColor = acInfo.ReadOnlyBackColor;

        //        this.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

        //        this.Appearance.Options.UseBackColor = true;

        //        this.AppearanceDisabled.BackColor = acInfo.ReadOnlyBackColor;

        //        this.AppearanceDisabled.ForeColor = acInfo.ReadOnlyForeColor;

        //        this.AppearanceDisabled.Options.UseBackColor = true;
        //    }

        //    //this.Refresh();
        //}


        #region IBaseControl 멤버


        //public BaseEdit Editor
        //{
        //    get
        //    {
        //        return this.Editor;
        //    }

        //}




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

                //this.SetColor();
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
                    this.ReadOnly = true;
                }
                else
                {
                    this.ReadOnly = false;

                }

                //this.SetColor();
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

                if (value == null) 
                {

                    foreach (acCheckedListBoxItem item in this.Items)
                    {
                        this.SetKeyValue(item.Key, item.UnCheckedValue);
                    }
                    return;
                }

                string[] checkedKeys = value.ToString().Split(',');

                string checkedString = string.Empty;

                int cnt = 0;

                

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


                this.Value = checkedString;



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



        #region IBaseViewControl 멤버

        //private string _ResourceID = null;

        //public string ResourceID
        //{
        //    get
        //    {
        //        return _ResourceID;
        //    }
        //    set
        //    {
        //        _ResourceID = value;
        //    }
        //}

        //private bool _UseResourceID = false;

        //public bool UseResourceID
        //{
        //    get
        //    {
        //        return _UseResourceID;
        //    }
        //    set
        //    {
        //        _UseResourceID = value;
        //    }
        //}


        #endregion
    }
}
