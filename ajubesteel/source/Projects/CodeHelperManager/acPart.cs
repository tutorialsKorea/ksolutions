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
using System.Text.RegularExpressions;
using BizManager;

namespace CodeHelperManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemPart : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemPart()
        {
            Register();
        }


        public RepositoryItemPart()
        {
            base.Buttons.Clear();

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CodeHelperManager.Resource.edit_find_1x, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});

            if (acInfo.IsRunTime == true)
            {
                base.Buttons[0].SuperTip = acInfo.ToolTip.GetToolTip("IM12EHO3");
            }

        }


        internal const string EditorName = "acPart";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acPart),
                typeof(RepositoryItemPart), typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acPart : acUserPopupContainerEdit, ControlManager.IBaseEditControl
    {

        private Dictionary<string, object> _ParameterDic = new Dictionary<string, object>();
        private String _VenCode;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> ParameterDic
        {
            get { return _ParameterDic; }
        }


        private ControlManager.acLayoutControl acLayoutControl1;
        private ControlManager.acGridControl acGridControl1;
        private ControlManager.acGridView acGridView1;
        private ControlManager.acTextEdit QuickFindEditor;
        private ControlManager.acLayoutControlGroup layoutControlGroup1;
        private ControlManager.acLayoutControlItem acLayoutControlItem1;
        private ControlManager.acLayoutControlItem acLayoutControlItem2;
        private acPopupContainerControl acPopupContainerControl1 = null;

        static acPart()
        {
            RepositoryItemPart.Register();
        }

        private string _mat_ltype = string.Empty;

        public string MAT_LTYPE
        {
            get { return this._mat_ltype; }

            set { this._mat_ltype = value; }
        }

        private string _mat_mtype = string.Empty;

        public string MAT_MTYPE
        {
            get { return this._mat_mtype; }

            set { this._mat_mtype = value; }
        }

        private string _is_main_part = string.Empty;

        public string IS_MAIN_PART
        {
            get { return this._is_main_part; }

            set { this._is_main_part = value; }
        }

        public acPart()
        {

            #region 팝업 컨트롤 생성


            this.acLayoutControl1 = new ControlManager.acLayoutControl();
            this.layoutControlGroup1 = new ControlManager.acLayoutControlGroup();
            this.QuickFindEditor = new ControlManager.acTextEdit();
            this.acLayoutControlItem1 = new ControlManager.acLayoutControlItem();
            this.acGridControl1 = new ControlManager.acGridControl();
            this.acGridView1 = new ControlManager.acGridView();
            this.acLayoutControlItem2 = new ControlManager.acLayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).BeginInit();
            this.acLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickFindEditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).BeginInit();
            this.SuspendLayout();

            // acLayoutControl1
            // 
            this.acLayoutControl1.AllowCustomizationMenu = false;
            this.acLayoutControl1.AutoScroll = false;

            this.acLayoutControl1.Controls.Add(this.acGridControl1);
            this.acLayoutControl1.Controls.Add(this.QuickFindEditor);
            this.acLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControl1.Name = "acLayoutControl1";
            this.acLayoutControl1.ParentControl = null;
            this.acLayoutControl1.Root = this.layoutControlGroup1;
            this.acLayoutControl1.Size = new System.Drawing.Size(760, 523);
            this.acLayoutControl1.TabIndex = 0;
            this.acLayoutControl1.Text = "acLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.acLayoutControlItem1,
            this.acLayoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(760, 523);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // acTextEdit1
            // 
            this.QuickFindEditor.ColumnName = null;
            this.QuickFindEditor.isReadyOnly = false;
            this.QuickFindEditor.isRequired = false;
            this.QuickFindEditor.Location = new System.Drawing.Point(6, 6);
            this.QuickFindEditor.MaskType = ControlManager.acTextEdit.emMaskType.NONE;
            this.QuickFindEditor.Name = "acTextEdit1";
            this.QuickFindEditor.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.QuickFindEditor.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.QuickFindEditor.Properties.Appearance.Options.UseBackColor = true;
            this.QuickFindEditor.Properties.Appearance.Options.UseForeColor = true;
            this.QuickFindEditor.Size = new System.Drawing.Size(749, 21);
            this.QuickFindEditor.StyleController = this.acLayoutControl1;
            this.QuickFindEditor.TabIndex = 4;
            this.QuickFindEditor.ToolTipID = null;
            this.QuickFindEditor.UseToolTipID = false;
            // 
            // acLayoutControlItem1
            // 
            this.acLayoutControlItem1.Control = this.QuickFindEditor;
            this.acLayoutControlItem1.CustomizationFormText = "acLayoutControlItem1";
            this.acLayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.acLayoutControlItem1.Name = "acLayoutControlItem1";
            this.acLayoutControlItem1.ResourceID = null;
            this.acLayoutControlItem1.Size = new System.Drawing.Size(760, 32);
            this.acLayoutControlItem1.Text = "acLayoutControlItem1";
            this.acLayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem1.TextToControlDistance = 0;
            this.acLayoutControlItem1.TextVisible = false;
            this.acLayoutControlItem1.ToolTipID = null;
            this.acLayoutControlItem1.UseResourceID = false;
            this.acLayoutControlItem1.UseToolTipID = false;
            // 
            // acGridControl1
            // 
            this.acGridControl1.Location = new System.Drawing.Point(6, 38);
            this.acGridControl1.MainView = this.acGridView1;
            this.acGridControl1.Name = "acGridControl1";
            this.acGridControl1.Size = new System.Drawing.Size(749, 480);
            this.acGridControl1.TabIndex = 5;
            this.acGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.acGridView1});
            // 
            // acGridView1
            // 
            this.acGridView1.GridType = ControlManager.acGridView.emGridType.FIXED;

            this.acGridView1.GridControl = this.acGridControl1;
            this.acGridView1.Name = "acGridView1";
            this.acGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.acGridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.acGridView1.OptionsLayout.StoreAllOptions = true;
            this.acGridView1.OptionsView.RowAutoHeight = true;
            this.acGridView1.OptionsView.ShowGroupPanel = false;
            this.acGridView1.OptionsView.ShowIndicator = false;
            this.acGridView1.ParentControl = this;
            this.acGridView1.SaveFileName = null;
            // 
            // acLayoutControlItem2
            // 
            this.acLayoutControlItem2.Control = this.acGridControl1;
            this.acLayoutControlItem2.CustomizationFormText = "acLayoutControlItem2";
            this.acLayoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.acLayoutControlItem2.Name = "acLayoutControlItem2";
            this.acLayoutControlItem2.ResourceID = null;
            this.acLayoutControlItem2.Size = new System.Drawing.Size(760, 491);
            this.acLayoutControlItem2.Text = "acLayoutControlItem2";
            this.acLayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.acLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.acLayoutControlItem2.TextToControlDistance = 0;
            this.acLayoutControlItem2.TextVisible = false;
            this.acLayoutControlItem2.ToolTipID = null;
            this.acLayoutControlItem2.UseResourceID = false;
            this.acLayoutControlItem2.UseToolTipID = false;



            this.acPopupContainerControl1 = new ControlManager.acPopupContainerControl();

            this.acPopupContainerControl1.Controls.Add(this.acLayoutControl1);
            this.acPopupContainerControl1.Location = new System.Drawing.Point(41, 50);
            this.acPopupContainerControl1.Name = "acPopupContainerControl1";
            this.acPopupContainerControl1.Size = new System.Drawing.Size(250, 150);
            this.acPopupContainerControl1.TabIndex = 1;

            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControl1)).EndInit();
            this.acLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuickFindEditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acLayoutControlItem2)).EndInit();


            #endregion

            this.Properties.PopupControl = acPopupContainerControl1;


            this.Properties.Buttons.Clear();


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton("DETAIL", DevExpress.XtraEditors.Controls.ButtonPredefines.Down),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CodeHelperManager.Resource.edit_find_1x, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "", "FIND")});

            if (ControlManager.acInfo.IsRunTime == true)
            {
                acPart.SetPopupGridView(acGridView1);

            }


            acGridView1.OnInitLayout += new acGridView.InitLayoutEventHandler(acGridView1_OnInitLayout);
            this.CloseUp += new CloseUpEventHandler(acPart_CloseUp);
            this.Popup += new EventHandler(acPart_Popup);
            this.QuickFindEditor.KeyDown += new KeyEventHandler(QuickFindEditor_KeyDown);

            this.GotFocus += new EventHandler(acPart_GotFocus);
            this.LostFocus += new EventHandler(acPart_LostFocus);


        }

        void acPart_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
            {
                this.SetStyle();
            }
        }

        void acPart_GotFocus(object sender, EventArgs e)
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
            view.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            //옵션컬럼
            //view.AddTextEdit("PART_ENAME", "부품명(영문)", "40235", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            view.AddTextEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //view.AddTextEdit("MAT_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            //view.AddTextEdit("MAT_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            //view.AddTextEdit("MAT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //view.AddTextEdit("MAT_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //view.AddTextEdit("MAT_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //view.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M003");

            //view.AddLookUpEdit("PART_PRODTYPE", "부품제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");

            //view.AddLookUpEdit("SPEC_TYPE", "규격입력형태", "42540", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S062");


        }

        void acPart_CloseUp(object sender, CloseUpEventArgs e)
        {
            QuickFindEditor.EditValue = null;
        }

        void acPart_Popup(object sender, EventArgs e)
        {
            if (this._isReadyOnly == false)
            {
                acLayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                acLayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            }
            //acLayoutControl1.GetEditor("MAT_LTYPE").Value = this._mat_ltype;
            //acLayoutControl1.GetEditor("MAT_MTYPE").Value = this._mat_mtype;
        }


        void QuickFindEditor_KeyDown(object sender, KeyEventArgs e)
        {
            //빠른코드검색
            if (e.KeyCode == Keys.Enter)
            {

                if (acChecker.isNull(QuickFindEditor.Value) == false)
                {
                    if (this.SetCode(QuickFindEditor.Value) == true)
                    {
                        this.ClosePopup();
                    }
                    else
                    {


                        object parameter = QuickFindEditor.Value;

                        this.ClosePopup();

                        this.Execute(emMethodType.QUICK_FIND, parameter);


                    }

                }

            }


        }
        void acGridView1_OnInitLayout(object sender)
        {
            acGridView view = sender as acGridView;

            view.LoadUserConfig("SYS04B_M0A", "acPart", acInfo.DefaultConfigUser);

            object datasource = view.GridControl.DataSource;

            view.GridType = acGridView.emGridType.FIXED;

            view.GridControl.DataSource = datasource;

        }
        public override string EditorTypeName
        {
            get { return RepositoryItemPart.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPart Properties
        {
            get
            {

                return base.Properties as RepositoryItemPart;

            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (char.IsLetterOrDigit(e.KeyChar))
            {

                this.ShowPopup();

                QuickFindEditor.SendKey(null,e);

                e.Handled = false;
            }


            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

            if (this._isReadyOnly == false)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {

                    _Value = null;

                    acGridView1.GridControl.DataSource = null;

                    this.EditValue = _Value;

                }
                else if (e.Control == true && e.KeyCode == Keys.Enter)
                {
                    this.Execute(emMethodType.FIND, null);
                }
                else if (e.Control == true && e.KeyCode == Keys.V)
                {

                    this.ShowPopup();

                    QuickFindEditor.Value = Clipboard.GetText();

                    QuickFindEditor.SelectionStart = QuickFindEditor.Value.toStringEmpty().Length;

                    e.Handled = false;
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

        public enum emSelectType
        {
            SINGLE,

            MULTI
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
            FIND,

            /// <summary>
            /// 빠른찾기
            /// </summary>
            QUICK_FIND
        };

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get
            {
                if (this._Value.isNullOrEmpty())
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

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
            acPartForm frmFind = new acPartForm();
            frmFind.VenCode = this._VenCode;

            frmFind.MAT_LTYPE = this._mat_ltype;

            frmFind.MAT_MTYPE = this._mat_mtype;

            frmFind.IS_MAIN_PART = this._is_main_part;

            frmFind.Filter = this._Filter;

            frmFind.Parameter = parameter;

            frmFind.ExecuteMethodType = method;

            frmFind.ParentControl = this;

            if (frmFind.ShowDialog() == DialogResult.OK)
            {
                bool isCodeChange = false;

                bool isEditValueChange = false;


                DataTable result = (DataTable)frmFind.OutputData;

                acGridView1.GridControl.DataSource = result;


                if (!this._Value.EqualsEx(result.Rows[0]["PART_CODE"]))
                {


                    isCodeChange = true;
                }
                else
                {
                    isCodeChange = false;
                }


                this._Value = result.Rows[0]["PART_CODE"];



                if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PART_SHOW_COLUMN"))))
                {


                    isEditValueChange = false;
                }
                else
                {
                    isEditValueChange = true;
                }



                this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PART_SHOW_COLUMN"));


                if (isCodeChange == true && isEditValueChange == false)
                {
                    this.RaiseEditValueChanged();
                }


            }





        }


        public static string GetClassName()
        {
            return "acPart";
        }



        public static string GetAutoMarginSpec(object parCode, object spec)
        {

            try
            {
                string SPEC_KEYCHAR_X = acInfo.SysConfig.GetSysConfigByMemory("SPEC_KEYCHAR_X");
                string SPEC_KEYCHAR_CIRCLE = acInfo.SysConfig.GetSysConfigByMemory("SPEC_KEYCHAR_CIRCLE");
                string SPEC_KEYCHAR_HEXA = acInfo.SysConfig.GetSysConfigByMemory("SPEC_KEYCHAR_HEXA");

                DataRow partRow = acPart.GetDataRow(parCode);

                DataRow specTypeRow = acInfo.StdCodes.GetCodeRow("S062", partRow["SPEC_TYPE"]);

                string partSpec = spec.toStringEmpty();

                if (!string.IsNullOrEmpty(partSpec))
                {
                    //여유사양
                    string[] marginSpecItems = partRow["AUTO_MARGIN_SPEC"].toStringEmpty().Split(Convert.ToChar(SPEC_KEYCHAR_X));


                    //완성사양
                    string[] partSpecItems = partSpec.Split(Convert.ToChar(SPEC_KEYCHAR_X));

                    //소재사양
                    List<string> matSpecItems = new List<string>();

                    if (marginSpecItems.Length == partSpecItems.Length)
                    {

                        for (int i = 0; i < partSpecItems.Length; i++)
                        {
                            Regex numberRegx = new Regex(@"[.0-9]+");

                            MatchCollection partSpecItemMatchs = numberRegx.Matches(partSpecItems[i]);
                            MatchCollection marginSpecItemMatchs = numberRegx.Matches(marginSpecItems[i]);

                            if (partSpecItemMatchs.Count == marginSpecItemMatchs.Count)
                            {
                                double specPlusValue = partSpecItemMatchs[0].Value.toDouble() + marginSpecItemMatchs[0].Value.toDouble();

                                matSpecItems.Add(specPlusValue.ToString());
                            }

                        }
                    }

                    if (matSpecItems.Count > 0)
                    {
      

                        string matSpec =  matSpecItems.ToArray().toString(SPEC_KEYCHAR_X);

                        acTextEdit edit = new acTextEdit();

                        edit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        edit.Properties.Mask.EditMask = specTypeRow["VALUE"].toStringEmpty();
                        edit.Properties.Mask.UseMaskAsDisplayFormat = true;

                        edit.EditValue = matSpec;

                        return edit.Text;
                    }


                }

            }
            catch
            {

                return null;
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
            paramTable.Columns.Add("PART_CODE", typeof(String)); //부품코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = code;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(), "CONTROL_PART_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

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
                paramTable.Columns.Add("PART_CODE", typeof(String)); //부품코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable result = BizRun.QBizRun.ExecuteService(this, "CTRL","CONTROL_PART_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

                if (result.Rows.Count != 0)
                {
                    bool isCodeChange = false;

                    bool isEditValueChange = false;


                    acGridView1.GridControl.DataSource = result;

                    if (!this._Value.EqualsEx(result.Rows[0]["PART_CODE"]))
                    {


                        isCodeChange = true;
                    }
                    else
                    {
                        isCodeChange = false;
                    }



                    this._Value = result.Rows[0]["PART_CODE"];


                    if (this.EditValue.EqualsEx(result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PART_SHOW_COLUMN"))))
                    {
                        isEditValueChange = false;
                    }
                    else
                    {
                        isEditValueChange = true;
                    }



                    this.EditValue = result.Rows[0].GetStringByMaskScript(acInfo.SysConfig.GetSysConfigByMemory("CTRL_PART_SHOW_COLUMN"));


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
            if (this.Enabled == true)
            {
                //필수 +  읽기전용
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

                //빠른찾기 에디터
                this.QuickFindEditor.SuperTip = acInfo.ToolTip.GetToolTip("5TYT6LJD");


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

        public string VenCode { get => _VenCode; set => _VenCode = value; }

        private string _Filter = string.Empty;
        public string Filter { get => _Filter; set => _Filter = value; }

        #endregion



    }
}
