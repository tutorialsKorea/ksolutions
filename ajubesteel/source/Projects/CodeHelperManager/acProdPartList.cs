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
using ControlManager;
using BizManager;

namespace CodeHelperManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemProdPartList : RepositoryItemPopupContainerEdit
    {

        static RepositoryItemProdPartList()
        {
            Register();
        }


        public RepositoryItemProdPartList()
        {
            base.Buttons.Clear();

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CodeHelperManager.Resource.edit_find_1x, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});

            if (acInfo.IsRunTime == true)
            {
                base.Buttons[0].SuperTip = acInfo.ToolTip.GetToolTip("IM12EHO3");
            }

        }


        internal const string EditorName = "acProdPartList";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acProdPartList),
                typeof(RepositoryItemProdPartList), typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acProdPartList : acUserPopupContainerEdit, ControlManager.IBaseEditControl
    {




        private ControlManager.acGridControl acGridControl1 = null;

        private ControlManager.acGridView acGridView1 = null;

        private acPopupContainerControl acPopupContainerControl1 = null;

        static acProdPartList()
        {
            RepositoryItemProdPartList.Register();
        }



        public acProdPartList()
        {
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();

            this.acGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acGridControl1.Location = new System.Drawing.Point(0, 0);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(250, 78);
            this.acGridControl1.TabIndex = 0;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});


            
            this.acGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.GridType = ControlManager.acGridView.emGridType.FIXED;

            this.acGridView1.Name = "acGridView1";
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsMenu.EnableColumnMenu = false;
            this.acGridView1.OptionsMenu.EnableFooterMenu = false;
            this.acGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.acGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.SaveFileName = null;


            this.acPopupContainerControl1 = new ControlManager.acPopupContainerControl();

            this.acPopupContainerControl1.Controls.Add(this.acGridControl1);
            this.acPopupContainerControl1.Location = new System.Drawing.Point(41, 50);
            this.acPopupContainerControl1.Name = "acPopupContainerControl1";
            this.acPopupContainerControl1.Size = new System.Drawing.Size(250, 78);
            this.acPopupContainerControl1.TabIndex = 1;

            this.Properties.PopupControl = acPopupContainerControl1;
            this.Properties.Buttons.Clear();


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton("DETAIL", DevExpress.XtraEditors.Controls.ButtonPredefines.Down),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CodeHelperManager.Resource.edit_find_1x, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});

            if (ControlManager.acInfo.IsRunTime == true)
            {
                acProdPartList.SetPopupGridView(acGridView1);

            }



            acGridView1.OnInitLayout += new acGridView.InitLayoutEventHandler(acGridView1_OnInitLayout);


            this.GotFocus += new EventHandler(acProdPartList_GotFocus);
            this.LostFocus += new EventHandler(acProdPartList_LostFocus);

        }

        void acProdPartList_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetStyle();

            }
        }

        void acProdPartList_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        public static void SetPopupGridView(acGridView view)
        {

            //기본컬럼
            view.AddTextEdit("PART_CODE", "부품코드", "40239", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PART_NUM", "품번", "40743", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PT_NAME", "부품명", "40234", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            //옵션컬럼
            view.AddTextEdit("P_PART_CODE", "모부품코드", "42562", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            view.AddTextEdit("P_PART_NUM", "모품번", "42564", true , DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            view.AddTextEdit("P_PART_NAME", "모부품명", "PRNIWQYY", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            view.AddTextEdit("PART_QLTY", "재질코드", "QGD6SY0U", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            view.AddTextEdit("PART_QLTY_NAME", "재질명", "40572", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            view.AddTextEdit("DRAW_NO", "도면번호", "40145", true , DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PART_SPEC", "소재사양", "42544", true , DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PART_SPEC1", "완성사양", "42545", true , DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PART_QTY", "수량", "40345", true , DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);


            view.AddLookUpEdit("MAT_UNIT", "단위", "40123", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, "M003");


            view.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);


            view.AddTextEdit("WEIGHT_VOLUME", "소재중량", "40629", true , DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.WEIGHT);

            //view.AddTextEdit("WEIGHT_VOLUME1", "중량2", "42546", true , DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.WEIGHT);

            view.AddTextEdit("UNIT_COST", "단가", "40121", true , DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.MONEY);

            view.AddTextEdit("MAT_COST", "자재비", "WEFGH5XM", true , DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.MONEY);

  
            view.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, "S063");


        }


        void acGridView1_OnInitLayout(object sender)
        {
            acGridView view = sender as acGridView;

            view.LoadUserConfig("SYS04B_M0A", "acProdPartList", acInfo.DefaultConfigUser);

            object datasource = view.GridControl.DataSource;

            view.GridType = acGridView.emGridType.FIXED;

            view.GridControl.DataSource = datasource;

        }


        private object _PROD_CODE = null;

        /// <summary>
        /// 종속 금형
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object PROD_CODE
        {
            get { return _PROD_CODE; }
            set
            {

                if (_PROD_CODE != null &&
                    _PROD_CODE != value)
                {
                    this._Value = null;

                    this.EditValue = _Value;

                    acGridView1.GridControl.DataSource = null;
                }

                _PROD_CODE = value;

                if (_PROD_CODE == null)
                {
                    this._Value = null;

                    this.EditValue = _Value;

                    acGridView1.GridControl.DataSource = null;

                }



                this.SetStyle();

            }
        }


        private object _PT_ID = null;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object PT_ID
        {
            get { return _PT_ID; }
            set { _PT_ID = value; }
        }



        public override string EditorTypeName
        {
            get { return RepositoryItemProdPartList.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemProdPartList Properties
        {
            get
            {

                return base.Properties as RepositoryItemProdPartList;

            }
        }




        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

            if (this._isReadyOnly == false)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {

                    _Value = null;

                    this.EditValue = _Value;

                    acGridView1.GridControl.DataSource = null;

                }
                else if (e.Control == true && e.KeyCode == Keys.Enter)
                {
                    this.Execute(emMethodType.FIND, null);
                }

            }

            base.OnKeyDown(e);
        }





        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            base.OnClickButton(buttonInfo);

            if (buttonInfo.Button.Tag.Equals("FIND"))
            {
                this.Execute(emMethodType.FIND, null);
            }

        }


        public enum emMethodType
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 찾기
            /// </summary>
            FIND

        };




        public DataRow SelectedRow
        {
            get
            {
                DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

                if (dt != null)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
        }
        void Execute(emMethodType method, object parameter)
        {

            acProdPartListForm frmFind = new acProdPartListForm();

            

            frmFind.ParentControl = this;

            frmFind.Parameter = parameter;

            frmFind.ExecuteMethodType = method;


            if (frmFind.ShowDialog() == DialogResult.OK)
            {
                bool isCodeChange = false;

                bool isEditValueChange = false;


                DataTable result = (DataTable)frmFind.OutputData;

                acGridView1.GridControl.DataSource = result;


                if (!this._Value.EqualsEx(result.Rows[0]["PT_ID"]))
                {


                    isCodeChange = true;
                }
                else
                {
                    isCodeChange = false;
                }


                this._Value = result.Rows[0]["PT_ID"];



                if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PART_SHOW_COLUMN"))))
                {

                    isEditValueChange = false;
                }
                else
                {
                    isEditValueChange = true;
                }



                this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PART_SHOW_COLUMN"));


                if (isCodeChange == true && isEditValueChange == false)
                {
                    this.RaiseEditValueChanged();
                }


            }

            


        }


        public static string GetClassName()
        {
            return "acProdPartList";
        }


        /// <summary>
        /// 코드 데이터를 알아옵니다.
        /// </summary>
        /// <param name="code">PT_ID</param>
        /// <returns></returns>
        public static DataRow GetDataRow(object code)
        {
            if (acChecker.isNull(code))
            {
                return null;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("PT_ID", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PT_ID"] = code;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PARENTPART_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            if (data.Rows.Count != 0)
            {
                return data.Rows[0];
            }

            return null;

        }


        /// <summary>
        /// 코드 데이터를 알아옵니다.
        /// </summary>
        /// <param name="prodCode"></param>
        /// <param name="partCode"></param>
        /// <param name="partNum"></param>
        /// <returns></returns>
        public static DataRow GetDataRow(object prodCode, object partCode, object partNum)
        {
            if (acChecker.isNull(prodCode, partCode, partNum))
            {
                return null;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PT_ID", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_NUM", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PT_ID"] = null;
            paramRow["PROD_CODE"] = prodCode;
            paramRow["PART_CODE"] = partCode;
            paramRow["PART_NUM"] = partNum;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PRODPART_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            if (data.Rows.Count != 0)
            {
                return data.Rows[0];
            }

            return null;

        }


        /// <summary>
        /// 컨트롤에 데이터를 설정합니다.
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        private bool SetCode(object code)
        {


            if (acChecker.isNull(code) == false)
            {


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("PT_ID", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable result = BizRun.QBizRun.ExecuteService(this, "CONTROL_PRODPART_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];


                if (result.Rows.Count != 0)
                {
                    bool isCodeChange = false;

                    bool isEditValueChange = false;


                    acGridView1.GridControl.DataSource = result;

                    if (!this._Value.EqualsEx(result.Rows[0]["PT_ID"]))
                    {


                        isCodeChange = true;
                    }
                    else
                    {
                        isCodeChange = false;
                    }



                    this._Value = result.Rows[0]["PT_ID"];


                    if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PART_SHOW_COLUMN"))))
                    {
                        isEditValueChange = false;
                    }
                    else
                    {
                        isEditValueChange = true;
                    }



                    this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PL_PART_SHOW_COLUMN"));


                    if (isCodeChange == true && isEditValueChange == false)
                    {
                        this.RaiseEditValueChanged();
                    }


                    return true;
                }


            }



            acGridView1.GridControl.DataSource = null;

            _Value = null;

            this.EditValue = _Value;

            return false;

        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            this.SetStyle();

            base.OnEnabledChanged(e);


        }
        /// <summary>
        /// 속성에 따른 형태 결정
        /// </summary>
        private void SetStyle()
        {

            //필수 +  읽기전용
            if (this.Enabled == true)
            {
                if (_isRequired == true && _isReadyOnly == true)
                {

                    this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag.Equals("FIND"))
                        {
                            btn.Visible = false;
                        }

                    }

                }
                //필수 
                else if (_isRequired == true && _isReadyOnly == false)
                {


                    bool fbVisible = false;


                    if (this._PROD_CODE != null)
                    {
                        fbVisible = true;


                    }

                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag.Equals("FIND"))
                        {
                            btn.Visible = fbVisible;
                        }
                    }

                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag.Equals("FIND"))
                        {
                            btn.Visible = false;
                        }
                    }
                }
                else
                {

                    bool fbVisible = false;


                    if (this._PROD_CODE != null)
                    {
                        fbVisible = true;

                    }
                    this.Properties.Appearance.BackColor = acInfo.StandardBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;


                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        if (btn.Tag.Equals("FIND"))
                        {
                            btn.Visible = fbVisible;
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

        protected override void OnLoaded()
        {
            if (acInfo.IsRunTime == true)
            {

                //항목버튼
                this.Properties.Buttons[0].SuperTip = acInfo.ToolTip.GetToolTip("6CLFY45I");

                //찾기버튼
                this.Properties.Buttons[1].SuperTip = acInfo.ToolTip.GetToolTip("IM12EHO3");

                this.Properties.Buttons[1].Image = CodeHelperManager.Resource.edit_find_1x;
            }

            base.OnLoaded();
        }


        protected override void OnCreateControl()
        {


            this.SetStyle();

            base.OnCreateControl();

            bool visible = false;

            if (this._PROD_CODE != null)
            {
                visible = true;
            }

            foreach (EditorButton btn in this.Properties.Buttons)
            {
                if (btn.Tag.Equals("FIND"))
                {
                    btn.Visible = visible;
                }

            }

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

                this.SetStyle();

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
                this.SetCode(value);


                this.SetStyle();
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

                this.SetStyle();

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
            _Value = null;

            this.EditValue = _Value;
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
