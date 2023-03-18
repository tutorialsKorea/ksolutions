﻿using System;
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

namespace CodeHelperManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemPlan : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemPlan()
        {
            Register();
        }


        public RepositoryItemPlan()
        {
            base.Buttons.Clear();

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CodeHelperManager.Resource.edit_find_1x, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});

            if (acInfo.IsRunTime == true)
            {
                base.Buttons[0].SuperTip = acInfo.ToolTip.GetToolTip("IM12EHO3");
            }

        }


        internal const string EditorName = "acPlan";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acPlan),
                typeof(RepositoryItemPlan), typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acPlanInstantResult
    {
        public DialogResult DialogResult = DialogResult.None;

        public object OutputData = null;


    }

    public class acPlan : acUserPopupContainerEdit, ControlManager.IBaseEditControl
    {







        private ControlManager.acGridControl acGridControl1 = null;

        private ControlManager.acGridView acGridView1 = null;

        private acPopupContainerControl acPopupContainerControl1 = null;

        static acPlan()
        {
            RepositoryItemPlan.Register();
        }




        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();


        public acPlan()
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
                acPlan.SetPopupGridView(acGridView1);

            }

            acGridView1.OnInitLayout += new acGridView.InitLayoutEventHandler(acGridView1_OnInitLayout);

            this.GotFocus += new EventHandler(acPlan_GotFocus);
            this.LostFocus += new EventHandler(acPlan_LostFocus);


        }

        void acPlan_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                this.Properties.Appearance.Options.UseBackColor = true;

            }
        }

        void acPlan_LostFocus(object sender, EventArgs e)
        {

            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetStyle();

            }
        }

        public static void SetPopupGridView(acGridView view)
        {
            view.AddTextEdit("PRG_CODE", "일정코드", "WHZ16F4U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PRG_NAME", "일정명", "EJPVN5D0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

        }


        void acGridView1_OnInitLayout(object sender)
        {
            acGridView view = sender as acGridView;

            view.LoadUserConfig("SYS04B_M0A", "acPlan", acInfo.DefaultConfigUser);

            object datasource = view.GridControl.DataSource;

            view.GridType = acGridView.emGridType.FIXED;

            view.GridControl.DataSource = datasource;

        }

        public override string EditorTypeName
        {
            get { return RepositoryItemPlan.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPlan Properties
        {
            get
            {

                return base.Properties as RepositoryItemPlan;

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

            if (buttonInfo.Button.Tag.Equals("FIND"))
            {
                this.Execute(emMethodType.FIND, null);
            }




            base.OnClickButton(buttonInfo);
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





        public static acPlanInstantResult ShowInstantForm(Control parent, emShowPlanType showPlanType, string caption, Dictionary<string, object> inputParameters)
        {
            acPlanForm frmFind = new acPlanForm();

            frmFind.ParentControl = parent;

            frmFind.UseResourceID = false;

            

            frmFind.Text = caption;

            frmFind.InputParameters = inputParameters;

            frmFind.ShowPlanType = showPlanType;

            frmFind.ExecuteMethodType = emMethodType.FIND;

            if (frmFind.ShowDialog() == DialogResult.OK)
            {

                DataTable result = (DataTable)frmFind.OutputData;

                return new acPlanInstantResult() { OutputData = result.Rows[0], DialogResult = DialogResult.OK };
            }


            return new acPlanInstantResult() { OutputData = null, DialogResult = DialogResult.Cancel };

        }

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


            acPlanForm frmFind = new acPlanForm();

            

            frmFind.ParentControl = this;

            frmFind.Parameter = parameter;

            frmFind.ShowPlanType = this._ShowPlanType;

            frmFind.ExecuteMethodType = method;

            if (frmFind.ShowDialog() == DialogResult.OK)
            {
                bool isCodeChange = false;

                bool isEditValueChange = false;


                DataTable result = (DataTable)frmFind.OutputData;

                acGridView1.GridControl.DataSource = result;


                if (!this._Value.EqualsEx(result.Rows[0]["PRG_CODE"]))
                {


                    isCodeChange = true;
                }
                else
                {
                    isCodeChange = false;
                }


                this._Value = result.Rows[0]["PRG_CODE"];



                if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PLAN_SHOW_COLUMN"))))
                {


                    isEditValueChange = false;
                }
                else
                {
                    isEditValueChange = true;
                }



                this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PLAN_SHOW_COLUMN"));


                if (isCodeChange == true && isEditValueChange == false)
                {
                    this.RaiseEditValueChanged();
                }


            }



        }

        public static object GetCodeByName(object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("PRG_NAME", typeof(String)); //부품코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PRG_NAME"] = name;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            
            DataTable data = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            if (data.Rows.Count != 0)
            {
                return data.Rows[0]["PRG_CODE"];
            }

            return null;


        }


        /// <summary>
        /// 코드 데이터를 알아옵니다.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static DataRow GetDataRow(object code)
        {
            if (acChecker.isNull(code))
            {
                return null;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("PRG_CODE", typeof(String)); //부품코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PRG_CODE"] = code;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            DataTable data = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            if (data.Rows.Count != 0)
            {
                return data.Rows[0];
            }

            return null;

        }



        public static DataTable GetData()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            DataTable data = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            return data;
        }


        public static string GetClassName()
        {
            return "acPlan";
        }


        public enum emShowPlanType
        {
            /// <summary>
            /// 대정일정
            /// </summary>
            L,

            /// <summary>
            /// 중일정
            /// </summary>
            M,

            /// <summary>
            /// 대,중일정
            /// </summary>
            LM,


            /// <summary>
            /// 중일정만관리 일정
            /// </summary>
            MM
        };

        private emShowPlanType _ShowPlanType = emShowPlanType.LM;


        [DefaultValue(emShowPlanType.LM)]
        public emShowPlanType ShowPlanType
        {
            get
            {
                return _ShowPlanType;
            }
            set
            {
                _ShowPlanType = value;

            }
        }


        /// <summary>
        /// 파라메터에 해당되는 코드를 설정한다.
        /// </summary>
        /// <param name="InputParameters"></param>
        /// <returns></returns>
        public void SetValue(Dictionary<string, object> InputParameters)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["DATA_FLAG"] = 0;



            foreach (KeyValuePair<string, object> parameter in InputParameters)
            {
                if (!paramTable.Columns.Contains(parameter.Key))
                {
                    paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                }

            }

            foreach (KeyValuePair<string, object> parameter in InputParameters)
            {
                paramRow[parameter.Key] = parameter.Value;
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);



            //DataTable result = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];
            DataTable result = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            if (result.Rows.Count > 0)
            {
                this.Value = result.Rows[0]["PRG_CODE"];

            }
            else
            {


                this.Value = null;
            }

           


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
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //부품코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //DataTable result = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];
                DataTable result = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

                if (result.Rows.Count != 0)
                {
                    bool isCodeChange = false;

                    bool isEditValueChange = false;


                    acGridView1.GridControl.DataSource = result;

                    if (!this._Value.EqualsEx(result.Rows[0]["PRG_CODE"]))
                    {


                        isCodeChange = true;
                    }
                    else
                    {
                        isCodeChange = false;
                    }



                    this._Value = result.Rows[0]["PRG_CODE"];


                    if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PLAN_SHOW_COLUMN"))))
                    {
                        isEditValueChange = false;
                    }
                    else
                    {
                        isEditValueChange = true;
                    }



                    this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PLAN_SHOW_COLUMN"));


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

                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;


                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        btn.Visible = true;
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
                    this.Properties.Appearance.BackColor = acInfo.StandardBackColor;
                    this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                    foreach (EditorButton btn in this.Properties.Buttons)
                    {
                        btn.Visible = true;
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
