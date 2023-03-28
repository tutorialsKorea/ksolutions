using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Windows.Forms;
using BizManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{
    public class acGridLookupEdit : DevExpress.XtraEditors.GridLookUpEdit, IBaseEditControl
    {
        private object _SaveValue = null;
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

                    this.Properties.AppearanceReadOnly.Options.UseForeColor = true;

                }
                //필수 
                else if (_isRequired == true && _isReadyOnly == false)
                {
                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;

                    this.Properties.Appearance.Options.UseForeColor = true;


                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

                    this.Properties.AppearanceReadOnly.Options.UseForeColor = true;
                }
                else
                {
                    //if (this.Properties.Appearance.BackColor.Name == "0")
                    //{
                        //this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                        //this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                        //this.Properties.Appearance.Options.UseBackColor = true;

                        //this.Properties.Appearance.Options.UseForeColor = true;
                    //}
                    
                }
            }
            else
            {
                //this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                //this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                //this.Properties.Appearance.Options.UseBackColor = true;
            }

            //this.Refresh();

        }


        protected override void OnCreateControl()
        {
            this.SetColor();

            this.BorderStyle = BorderStyles.Simple;
        }


        public enum emDefaultValueType { NONE, FIRST_ROW };

        private emDefaultValueType _DefaultValueType = emDefaultValueType.NONE;

        /// <summary>
        /// 기본값 형태
        /// </summary>
        public emDefaultValueType DefaultValueType
        {
            get { return _DefaultValueType; }
            set
            {
                _DefaultValueType = value;

                this.View_DataSourceChanged(null,null);
            }
        }

        public acGridLookupEdit()
            : base()
        {

            this.GotFocus += new EventHandler(acGridLookupEdit_GotFocus);

            this.LostFocus += new EventHandler(acGridLookupEdit_LostFocus);

            this.EnabledChanged += acGridLookupEdit_EnabledChanged;
            this.EditValueChanged += acGridLookupEdit_EditValueChanged;
            this.Properties.View.DataSourceChanged += View_DataSourceChanged;

        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            this.Properties.NullText = null;
            this.Properties.View.OptionsView.ShowColumnHeaders = false;
            this.Properties.View.OptionsView.ShowIndicator = false;
            this.Properties.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            //this.Properties.View.OptionsBehavior.AutoPopulateColumns = true;
        }

        private void View_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.Properties.DataSource is DataTable dt)
            {
                if (this.EditValue == null)
                {
                    //기본값이 있을경우 설정

                    DataTable listData = (DataTable)this.Properties.DataSource;

                    if (listData.Columns.Contains("IS_DEFAULT") && this.Enabled == true)
                    {
                        DataRow[] defaultRow = listData.Select("IS_DEFAULT = 1");

                        if (defaultRow.Length > 0)
                        {
                            this.EditValue = defaultRow[0][this.Properties.ValueMember];
                        }
                    }
                }

            }
        }

        private void acGridLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (this.Enabled == true && this.EditValue.isNullOrEmpty() == false)
            if (this.Enabled == true)
            {
                this._SaveValue = this.EditValue;
            }
        }

        private void acGridLookupEdit_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if(this.Properties.DataSource != null
                    && (this.Properties.DataSource as DataTable).Select(this.Properties.ValueMember+"='"+this._SaveValue+"'").Length > 0)
                    this.EditValue = this._SaveValue;
            }
        }

        void acGridLookupEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.SetColor();

                }
            }
        }

        void acGridLookupEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                    this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                    this.Properties.Appearance.Options.UseBackColor = true;
                }
            }

        }



        /// <summary>
        /// 코드를 설정합니다.
        /// </summary>
        /// <param name="catCode"></param>
        /// <param name="parentCode"></param>
        public void SetCode(object catCode, object parentCode, bool visibleCommon = false, string filterString = null)
        {

            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }



            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);


            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";


            if (parentCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

            }
            else
            {
                DataTable rslt = acInfo.StdCodes.GetCatTable(catCode, parentCode, visibleCommon);
                
                this.Properties.DataSource = rslt;

                SetDataFilter(rslt, filterString);
            }

        }

        public void SetCodeNoSetIdx(object catCode, object parentCode, string filterString = null)
        {

            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }


            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);


            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";


            if (parentCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

            }
            else
            {


                DataTable rslt = acInfo.StdCodes.GetCatTable(catCode, parentCode);

                this.Properties.DataSource = rslt;

                SetDataFilter(rslt, filterString);
            }

        }

        /// <summary>
        /// 기준코드를 설정합니다.
        /// </summary>
        /// <param name="catCode"></param>
        public void SetCode(object catCode, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }

            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";


            DataTable rslt = acInfo.StdCodes.GetCatTable(catCode);
            this.Properties.DataSource = rslt;
            SetDataFilter(rslt, filterString);
        }

        /// <summary>
        /// 기준코드를 설정합니다.
        /// </summary>
        /// <param name="catCode"></param>
        public void SetCodeValue(object catCode, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }

            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("VALUE", "VALUE", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "VALUE";
            this.Properties.ValueMember = "CD_CODE";


            DataTable rslt = acInfo.StdCodes.GetCatTable(catCode);
            this.Properties.DataSource = rslt;
            SetDataFilter(rslt, filterString);
        }

        public void SetCodeValue(object catCode, object parentCode, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }

            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("VALUE", "VALUE", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "VALUE";
            this.Properties.ValueMember = "CD_CODE";


            //this.Properties.DataSource = acInfo.StdCodes.GetCatTable(catCode);

            if (parentCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

            }
            else
            {
                DataTable rslt = acInfo.StdCodes.GetCatTable(catCode, parentCode);
                this.Properties.DataSource = rslt;
                SetDataFilter(rslt, filterString);
            }
        }

        public void SetCodebyNameLike(object catCode, object parentCode, object nameLike, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }

            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";

            DataTable dtSource = acInfo.StdCodes.GetCatTable(catCode, parentCode);

            DataRow[] dtSelectedRows = dtSource.Select(string.Format("CD_NAME LIKE '{0}'", "%" + nameLike.ToString() + "%"));

            if (dtSelectedRows.Length > 0)
            {
                this.Properties.DataSource = dtSelectedRows.CopyToDataTable();
            }
            else
            {
                this.Properties.DataSource = acInfo.StdCodes.GetCatTable(catCode);
            }

            SetDataFilter(this.Properties.DataSource as DataTable, filterString);

            DataTable listData = (DataTable)this.Properties.DataSource;

            if (listData.Columns.Contains("IS_DEFAULT"))
            {
                DataRow[] defaultRow = listData.Select("IS_DEFAULT = 1");

                if (defaultRow.Length > 0 && this.Enabled == true)
                {
                    this.EditValue = defaultRow[0][this.Properties.ValueMember];
                }
                else
                {
                }
            }
        }


        public void SetCodebyValueLike(object catCode, object value, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }

            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";

            DataTable dtSource = acInfo.StdCodes.GetCatTable(catCode);

            DataRow[] dtSelectedRows = dtSource.Select(string.Format("VALUE LIKE '{0}'", "%" + value.ToString() + "%"));

            if (dtSelectedRows.Length > 0)
            {
                this.Properties.DataSource = dtSelectedRows.CopyToDataTable();
            }
            else
            {
                this.Properties.DataSource = acInfo.StdCodes.GetCatTable(catCode);
            }

            SetDataFilter(this.Properties.DataSource as DataTable, filterString);

            DataTable listData = (DataTable)this.Properties.DataSource;

            if (listData.Columns.Contains("IS_DEFAULT"))
            {
                DataRow[] defaultRow = listData.Select("IS_DEFAULT = 1");

                if (defaultRow.Length > 0 && this.Enabled == true)
                {
                    this.EditValue = defaultRow[0][this.Properties.ValueMember];
                }
                else
                {
                }
            }
        }

        public void SetCodebyValueLike2(object catCode, object value, object name_like, string filterString = null)
        {


            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }


            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";

            DataTable dtSource = acInfo.StdCodes.GetCatTable(catCode);

            DataRow[] dtSelectedRows = dtSource.Select(string.Format("VALUE LIKE '{0}' AND CD_NAME LIKE '{1}'",
                "%" + value.ToString() + "%",
                "%" + name_like.ToString() + "%"));

            if (dtSelectedRows.Length > 0)
            {
                this.Properties.DataSource = dtSelectedRows.CopyToDataTable();
            }
            else
            {
                this.Properties.DataSource = acInfo.StdCodes.GetCatTable(catCode);
            }

            SetDataFilter(this.Properties.DataSource as DataTable, filterString);

            if (this.Enabled == false)
                return;

            DataTable listData = (DataTable)this.Properties.DataSource;

            if (listData.Columns.Contains("IS_DEFAULT"))
            {
                DataRow[] defaultRow = listData.Select("IS_DEFAULT = 1");

                if (defaultRow.Length > 0)
                {
                    this.EditValue = defaultRow[0][this.Properties.ValueMember];
                }
                else
                {
                }
            }

        }

        public void SetCodeANDValue(object catCode, object parentCode, object value, string filterString = null)
        {

            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }


            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";


            if (parentCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

            }
            else
            {
                DataTable dtSource = acInfo.StdCodes.GetCatTable(catCode, parentCode);


                if (value != null)
                {
                    DataRow[] drSelected = dtSource.Select(string.Format("VALUE LIKE '{0}'", "%" + value + "%"));
                    if (drSelected.Length > 0)
                        this.Properties.DataSource = drSelected.CopyToDataTable();
                    
                }
                else
                {
                    this.Properties.DataSource = acInfo.StdCodes.GetCatTable(catCode, parentCode);    
                }

                SetDataFilter(this.Properties.DataSource as DataTable, filterString);
            }

        }

        protected override void OnEditValueChanged()
        {

            DataTable dt = this.Properties.DataSource as DataTable;

            if (dt != null)
            {
                if (dt.Columns.Contains("CD_CODE") == true)
                {
                    DataRow[] selectRow = dt.Select("CD_CODE = '" + this.EditValue.toStringNull() + "'");

                    if (selectRow.Length != 0)
                    {
                        if (selectRow[0]["SCOMMENT"].isNullOrEmpty() == false)
                        {
                            this.SuperTip = new DevExpress.Utils.SuperToolTip();

                            ToolTipTitleItem titleTT = new ToolTipTitleItem();

                            titleTT.Text = selectRow[0]["CD_NAME"].toStringNull();

                            ToolTipItem contentTT = new ToolTipItem();

                            contentTT.Text = selectRow[0]["SCOMMENT"].toStringNull();

                            this.SuperTip.Items.Add(titleTT);
                            this.SuperTip.Items.Add(contentTT);
                        }

                    }
                }

            }

            base.OnEditValueChanged();
        }


        public DataRow GetSelectedRowCodes()
        {
            DataTable dt = this.Properties.DataSource as DataTable;

            DataRow[] selected = dt.Select(string.Format("CD_CODE = '{0}'", this.EditValue));

            if (selected.Length > 0)
            {
                return selected[0];
            }
            else
            {
                return null;
            }
        }

        public DataRow GetSelectedRow(string keyColumnName)
        {
            DataTable dt = this.Properties.DataSource as DataTable;

            DataRow[] selected = dt.Select(string.Format(keyColumnName +" = '{0}'", this.EditValue));

            if (selected.Length > 0)
            {
                return selected[0];
            }
            else
            {
                return null;
            }
        }

        public DataRow GetSelectedRow()
        {
            DataTable dt = this.Properties.DataSource as DataTable;

            DataRow[] selected = dt.Select(string.Format("CD_CODE = '{0}'", this.EditValue));

            if (selected.Length > 0)
            {
                return selected[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 기준코드를 설정합니다. 특정코드만 가져옴
        /// </summary>
        /// <param name="catCode"></param>
        public void SetCode(object catCode, string[] codes, string filterString = null)
        {

            if (catCode.isNull())
            {
                this.EditValue = null;

                this.Properties.DataSource = null;

                return;
            }



            DataTable dt = acInfo.StdCodes.GetCatTable(catCode);


            this.Properties.View.Columns.Clear();

            //this.AddTextEdit("CD_CODE", "CD_CODE", HorzAlignment.Near, false, false);
            //this.AddTextEdit("CD_NAME", "CD_NAME", HorzAlignment.Near, false, true);

            this.Properties.DisplayMember = "CD_NAME";
            this.Properties.ValueMember = "CD_CODE";

            DataTable userCodeList = dt.Clone();

            foreach (string code in codes)
            {
                DataRow[] codeRow = dt.Select(string.Format("CD_CODE = '{0}'", code));

                if (codeRow.Length != 0)
                {
                    DataRow newRow = userCodeList.NewRow();

                    newRow.ItemArray = codeRow[0].ItemArray;

                    userCodeList.Rows.Add(newRow);
                }

            }

            DataTable codeList = userCodeList.Copy();




            this.Properties.DataSource = codeList;

            SetDataFilter(codeList, filterString);
        }

        public void SetData(string displayColumn, string valueColumn, DataTable refData, string filterString = null)
        {

            this.Properties.View.Columns.Clear();
            //this.AddTextEdit(displayColumn, displayColumn, HorzAlignment.Near, false, true);
            //this.AddTextEdit(valueColumn, valueColumn, HorzAlignment.Near, false, false);

            this.Properties.DisplayMember = displayColumn;
            this.Properties.ValueMember = valueColumn;

            this.Properties.DataSource = refData;

            SetDataFilter(refData, filterString);
        }

        public void SetData(string displayColumn, string valueColumn, string ruleName, DataSet refData, string inputTableName, string outputTableName, string filterString = null)
        {
            string[] strParam = ruleName.Split('_');

            SetData(displayColumn, valueColumn, strParam[0], ruleName, refData, inputTableName, outputTableName,filterString);
        }


        public void SetData(string displayColumn, string valueColumn,string className, string ruleName, DataSet refData, string inputTableName, string outputTableName, string filterString = null)
        {
            this.Properties.View.Columns.Clear();
            //this.AddTextEdit(displayColumn, displayColumn, HorzAlignment.Near, false, true);
            //this.AddTextEdit(valueColumn, valueColumn, HorzAlignment.Near, false, false);

            this.Properties.DisplayMember = displayColumn;
            this.Properties.ValueMember = valueColumn;

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, className,ruleName,refData, inputTableName, outputTableName);

            //DataSet resultSet = BizManager.BizRun.QBizRun.ExecuteService(this, ruleName, refData, inputTableName, outputTableName);

            this.Properties.DataSource = resultSet.Tables[outputTableName];

            SetDataFilter(this.Properties.DataSource as DataTable, filterString);
        }

        /// <summary>
        /// bizRuleName 만 전달해서 데이타 불러오기 신재경 20191115
        /// </summary>
        /// <param name="displayColumn"></param>
        /// <param name="valueColumn"></param>
        /// <param name="ruleName"></param>
        public void SetData(string displayColumn, string valueColumn, string ruleName, string filterString = null)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            SetData(displayColumn, valueColumn, ruleName, paramSet, "RQSTDT", "RSLTDT",filterString);
        }

        /// <summary>
        /// bizRuleName 만 전달해서 데이타 불러오기 신재경 20191115
        /// </summary>
        /// <param name="displayColumn"></param>
        /// <param name="valueColumn"></param>
        /// <param name="className"></param>
        /// <param name="ruleName"></param>
        public void SetData(string displayColumn, string valueColumn, string className, string ruleName, string filterString = null)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            SetData(displayColumn, valueColumn, className, ruleName, paramSet, "RQSTDT", "RSLTDT",filterString);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

            if (e.Control == true && e.KeyCode == Keys.C)
            {
                //클립보드 복사

                Clipboard.SetText(this.Value.ToString());
            }
            else if (e.KeyData == System.Windows.Forms.Keys.Delete || e.KeyData == System.Windows.Forms.Keys.Back)
            {
                if (this.isReadyOnly == false)
                {
                    this.EditValue = null;
                }
            }



            base.OnKeyDown(e);

        }

        public GridColumn AddTextEdit(string columnName, string caption, HorzAlignment align, bool allowEdit, bool visible)
        {

            try
            {
                GridColumn col = new GridColumn();

                col.FieldName = columnName;


                col.Caption = caption;


                col.OptionsColumn.AllowEdit = allowEdit;

                col.Visible = visible;

                if (col.Visible == true)
                {
                    col.VisibleIndex = this.Properties.View.VisibleColumns.Count + 1;
                }

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                col.AppearanceHeader.Options.UseTextOptions = true;


                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

                col.ColumnEdit = textEditItem;

                textEditItem.Mask.UseMaskAsDisplayFormat = true;

                textEditItem.Tag = col;

                this.Properties.View.Columns.Add(col);

                return col;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetDataFilter(DataTable createColumnTable, string filterString)
        {
            //컬럼 자동 생성 시켜주기
            this.Properties.View.PopulateColumns(createColumnTable);

            foreach (DataColumn dc in createColumnTable.Columns)
            {
                //화면 표시 컬럼 제외 전부 안보이게 처리
                if (!dc.ColumnName.Equals(this.Properties.DisplayMember))
                    this.Properties.View.Columns[dc.ColumnName].Visible = false;
            }

            //필터 조건 입력
            this.Properties.View.ActiveFilterString = filterString;
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

        public object Value
        {
            get
            {

                return this.EditValue;

            }
            set
            {
                if (this.Enabled == false)
                {
                    this.EditValue = null;
                    return;
                }
                
                this.EditValue = value;

                if (this.EditValue != value)
                {
                    this.EditValue = Convert.ChangeType(value, ((DataTable)this.Properties.DataSource).Columns[this.Properties.ValueMember].DataType);
                }

                _SaveValue = this.EditValue;
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
            DataTable listData = (DataTable)this.Properties.DataSource;


            if (listData != null)
            {
                if (listData.Columns.Contains("IS_DEFAULT"))
                {

                    DataRow[] defaultRow = listData.Select("IS_DEFAULT = 1");


                    if (defaultRow.Length > 0&& this.Enabled == true)
                    {

                        this.EditValue = defaultRow[0][this.Properties.ValueMember];
                    }
                    else
                    {
                        this.EditValue = null;
                    }
                }

            }
            else
            {
                this.EditValue = null;
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
