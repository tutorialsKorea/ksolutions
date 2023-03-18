using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraLayout;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.ComponentModel;
using DevExpress.Utils;
using System.Drawing;
//using DevExpress.Spreadsheet;
//using DevExpress.XtraRichEdit;

namespace ControlManager
{
    public class acLayoutControlImplementor : LayoutControlImplementor
    {
        public acLayoutControlImplementor(ILayoutControlOwner owner) : base(owner) { }
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            return new acLayoutControlGroup(parent);
        }
    }


    public class acLayoutControl : DevExpress.XtraLayout.LayoutControl, IBaseContainer
    {

        private bool _IsBinding = false;

        /// <summary>
        /// 데이터 바인딩중인지 여부
        /// </summary>
        public bool IsBinding
        {
            get { return _IsBinding; }

        }

        public acLayoutControl()
            : base()
        {
            this.ToolTipController = new DevExpress.Utils.ToolTipController();

            this.ToolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;

            this.AllowCustomizationMenu = false;

            //this.Root.GroupBordersVisible = false;

            if (acInfo.IsRunTime == true && acInfo.SysConfig != null)
            {
                this.OptionsView.DrawItemBorders = acInfo.SysConfig.GetSysConfigByMemory("LAYOUT_DRAW_ITEM_BORDERS").toBoolean();

                this.OptionsView.HighlightFocusedItem = acInfo.SysConfig.GetSysConfigByMemory("LAYOUT_HIGHLIGHT_FOCUS_ITEM").toBoolean();


            }
        }


        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new acLayoutControlImplementor(this);
        }

        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            return new acLayoutControlItem();
        }


        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            return new acLayoutControlGroup();
        }





        private bool _IsInit = false;

        /// <summary>
        /// 초기화 여부
        /// </summary>
        public bool IsInit
        {
            get { return _IsInit; }
        }



        private Dictionary<string, IBaseEditControl> _EditorDic = new Dictionary<string, IBaseEditControl>();


        public enum emLayoutType
        {

            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 조건
            /// </summary>
            CONDITION

        };

        private emLayoutType _LayoutType = emLayoutType.NONE;

        public emLayoutType LayoutType
        {
            get { return _LayoutType; }
            set { _LayoutType = value; }
        }

        /// <summary>
        /// 맵핑작업
        /// </summary>
        /// <param name="grp"></param>
        void _Mapping(acLayoutControlGroup grp)
        {
            try
            {

                if (grp.UseResourceID == true)
                {
                    grp.Text = acInfo.Resource.GetString(grp.Text, grp.ResourceID);
                }

                if (grp.IsHeader == true)
                {
                    //grp.AppearanceGroup.ForeColor = System.Drawing.Color.;

                    grp.AppearanceGroup.Font = new System.Drawing.Font("맑은고딕", 10, System.Drawing.FontStyle.Italic);

                }

                foreach (object obj in grp.Items)
                {
                    if (obj is acLayoutControlItem)
                    {
                        acLayoutControlItem item = (acLayoutControlItem)obj;



                        //사이즈 설정
                        if (this._LayoutType == emLayoutType.CONDITION)
                        {
                            int margin = (DevExpress.Utils.AppearanceObject.DefaultFont.Size.toInt() - acInfo.DefaultFont.Size.toInt()) * 10;

                            if (item.Control is IBaseEditControl)
                            {

                                if (item.TextVisible == true)
                                {
                                    int itemHeight = item.Size.Height;

                                    item.SizeConstraintsType = SizeConstraintsType.Custom;

                                    int width = item.TextSize.Width + 150 + margin;



                                    item.MinSize = new System.Drawing.Size(width, itemHeight);

                                    item.MaxSize = new System.Drawing.Size(width, itemHeight);

                                    item.Size = new System.Drawing.Size(width, itemHeight);


                                    item.TextAlignMode = TextAlignModeItem.AutoSize;

                                    //item.SizeConstraintsType = SizeConstraintsType.Custom;

                                }
                                else
                                {
                                    if (item.Control is acCheckEdit)
                                    {
                                        item.SizeConstraintsType = SizeConstraintsType.Default;
                                    }
                                    else
                                    {
                                        int itemHeight = item.Size.Height;

                                        item.SizeConstraintsType = SizeConstraintsType.Custom;
                                     
                                        int width = 150 + margin;


                                        item.MinSize = new System.Drawing.Size(width, itemHeight);
                                        item.MaxSize = new System.Drawing.Size(width, itemHeight);

                                        item.Size = new System.Drawing.Size(width, itemHeight);

                                        item.TextAlignMode = TextAlignModeItem.AutoSize;

                                        //item.SizeConstraintsType = SizeConstraintsType.Custom;
                                    }

                                }
                            }
                            else
                            {
                                if (item.Control is acLabelControl)
                                {
                                    int itemHeight = item.Size.Height;

                                    item.SizeConstraintsType = SizeConstraintsType.Custom;

                                    int width = DevExpress.Utils.AppearanceObject.DefaultFont.Size.toInt();


                                    item.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);

                                    item.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;

                                    item.MinSize = new System.Drawing.Size(width, itemHeight);
                                    item.MaxSize = new System.Drawing.Size(width, itemHeight);

                                    item.Size = new System.Drawing.Size(width, itemHeight);

                                    //item.SizeConstraintsType = SizeConstraintsType.Custom;
                                }
                                else
                                {
                                    item.SizeConstraintsType = SizeConstraintsType.Custom;
                                }




                            }
                        }



                        //리소스 설정
                        if (item.UseResourceID == true)
                        {
                            if (item.Control is IBaseEditControl)
                            {
                                //acCheckEdit 자신에게 리소스 표시

                                if (item.Control is acCheckEdit)
                                {
                                    item.Control.Text = acInfo.Resource.GetString(item.Control.Text, item.ResourceID);
                                }
                                else
                                {
                                    item.Text = acInfo.Resource.GetString(item.Text, item.ResourceID);
                                }

                            }
                            else if (item.Control is IBaseViewControl)
                            {
                                //자신에게 리소스 표시

                                if (item.Control is acLabelControl)
                                {
                                    item.Control.Text = acInfo.Resource.GetString(item.Control.Text, item.ResourceID);
                                }
                                else if (item.Control is acSimpleButton)
                                {
                                    item.Control.Text = acInfo.Resource.GetString(item.Control.Text, item.ResourceID);

                                }
                            }
                            else
                            {
                                item.Text = acInfo.Resource.GetString(item.Text, item.ResourceID);
                            }


                        }

                        //툴팁생성

                        if (item.UseToolTipID == true)
                        {

                            if (item.Control is acCheckEdit)
                            {
                                item.TextVisible = true;

                                item.TextAlignMode = TextAlignModeItem.AutoSize;

                                item.Text = " ";

                                item.OptionsToolTip.ToolTipTitle = item.Control.Text;

                                item.TextToControlDistance = 0;


                            }
                            else
                            {
                                item.OptionsToolTip.ToolTipTitle = item.Text;
                            }



                            if (!string.IsNullOrEmpty(item.ToolTipID))
                            {
                                if (acInfo.ToolTip.IsToolTip(item.ToolTipID))
                                {


                                    SuperToolTip stt = acInfo.ToolTip.GetToolTip(item.ToolTipID);

                                    foreach (BaseToolTipItem tt in stt.Items)
                                    {
                                        if (tt is ToolTipItem)
                                        {

                                            item.OptionsToolTip.ToolTip = (tt as ToolTipItem).Text;

                                            item.Image = Resource.sign_question_x16;

                                            item.ImageToTextDistance = 1;


                                            break;
                                        }

                                    }


                                }
                            }


                        }

                        if (item.ToolTipStdCode != null)
                        {
                            if (item.ToolTipStdCode != "")
                            {
                                item.Image = Resource.suggestion_16x16;

                                item.OptionsToolTip.ToolTip = "표준코드 [" + item.ToolTipStdCode + "]";
                            }

                        }

                        if (item.IsTitle == true)
                        {
                            //item.Image = 
                            item.Image = Resource.alignjustify_16x16;
                        }
                        //에디트 이벤트 생성
                        if (item.Control is IBaseEditControl)
                        {
                            IBaseEditControl ib = item.Control as IBaseEditControl;


                            if (ib != null)
                            {
                                if (!string.IsNullOrEmpty(ib.ColumnName) && !this._EditorDic.ContainsKey(ib.ColumnName))
                                {
                                    this._EditorDic.Add(ib.ColumnName, ib);
                                }
                            }

                            if (item.Control is BaseEdit)
                            {
                                BaseEdit itemEdit = item.Control as BaseEdit;

                                itemEdit.EditValueChanged += new EventHandler(itemEdit_EditValueChanged);

                                itemEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(itemEdit_EditValueChanging);

                                itemEdit.KeyDown += new KeyEventHandler(itemEdit_KeyDown);
                            }
                        }

                        if (_EnterMoveNextControl)
                        {
                            IBaseEditControl ib = item.Control as IBaseEditControl;

                            if (item.Control is BaseEdit)
                            {
                                BaseEdit itemEdit = item.Control as BaseEdit;

                                itemEdit.EnterMoveNextControl = true;
                            }
                        }

                        item.Hidden += new EventHandler(item_Hidden);

                        item.Shown += new EventHandler(item_Shown);

                    }
                    else if (obj is acLayoutControlGroup)
                    {

                        this._Mapping((acLayoutControlGroup)obj);

                    }



                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void item_Shown(object sender, EventArgs e)
        {
            acLayoutControlItem item = sender as acLayoutControlItem;

            item.Control.Enabled = true;

        }

        void item_Hidden(object sender, EventArgs e)
        {
            acLayoutControlItem item = sender as acLayoutControlItem;

            if (item.Control == null) return;

            item.Control.Enabled = false;


        }

        private bool _IsMapping = false;


        protected override void OnCreateControl()
        {

            base.OnCreateControl();

            if (acInfo.IsRunTime == true && this._IsMapping == false)
            {
                if (this.Root != null)
                {
                    this._Mapping((acLayoutControlGroup)this.Root);

                    this._IsMapping = true;

                }

            }

        }

        protected override void OnVisibleChanged(EventArgs e)
        {


            if (this.Visible == true)
            {
                if (acInfo.IsRunTime == true && this._IsInit == false)
                {

                    if (this._IsInit == false)
                    {


                        //최상위 부모컨트롤한테 초기화 알림

                        IBase b = BaseMenu.GetBaseControl(this) as IBase;


                        this._IsInit = true;

                        if (b != null)
                        {

                            b.ChildContainerInit(this);
                        }


                    }


                }


            }

            base.OnVisibleChanged(e);




        }

        void itemEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is IBaseEditControl)
            {
                IBaseEditControl info = (IBaseEditControl)sender;

                if (this.OnValueKeyDown != null)
                {
                    this.OnValueKeyDown(this, info, e);
                }

            }
        }





        public List<string> GetMappingColumns()
        {
            List<string> colList = new List<string>();


            foreach (KeyValuePair<string, IBaseEditControl> editor in this._EditorDic)
            {

                colList.Add(editor.Value.ColumnName);
            }

            return colList;
        }





        /// <summary>
        /// 수정된 매핑 컬럼을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public List<string> GetMappingColumnChanged()
        {

            List<string> modifyList = new List<string>();


            foreach (KeyValuePair<string, IBaseEditControl> editor in this._EditorDic)
            {

                if (editor.Value.isChanged == true)
                {
                    modifyList.Add(editor.Value.ColumnName);
                }

            }

            return modifyList;



        }

        public void AcceptMappingColumnChanged()
        {

            foreach (KeyValuePair<string, IBaseEditControl> editor in this._EditorDic)
            {
                editor.Value.isChanged = false;
            }

        }

        public void RaiseEditValueChanged(string columnName)
        {
            if (this.OnValueChanged != null)
            {
                IBaseEditControl be = this.GetEditor(columnName);

                this.OnValueChanged(this, be, be.Value);
            }
        }

        void itemEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            if (this._NotRaiseEvent == true)
            {
                return;
            }



            if (this._IsBinding == false && this._IsInit == true)
            {
                if (sender is IBaseEditControl)
                {
                    IBaseEditControl info = (IBaseEditControl)sender;

                    if (this.OnValueChanging != null)
                    {
                        this.OnValueChanging(this, info, e);
                    }

                }
            }


        }

        void itemEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this._NotRaiseEvent == true)
                {
                    return;
                }


                if (this._IsInit == true)
                {
                    if (sender is IBaseEditControl)
                    {
                        IBaseEditControl info = (IBaseEditControl)sender;

                        //바인딩중이 아닐때
                        if (this._IsBinding == false)
                        {
                            info.isChanged = true;

                        }

                        if (this.OnValueChanged != null)
                        {
                            this.OnValueChanged(this, info, info.Value);
                        }

                        if (info.Value != null)
                        {
                            _ValidProvider.SetValidationRule((Control)info.Editor, null);
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private Control _ParentControl = null;

        public Control ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }

        private string _DefaultErrText = string.Empty;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DefaultErrText
        {
            get { return _DefaultErrText; }
            set { _DefaultErrText = value; }
        }

        private bool _EnterMoveNextControl;
        public bool EnterMoveNextControl
        {
            get { return _EnterMoveNextControl; }
            set { _EnterMoveNextControl = value; }
        }

        /// <summary>
        /// 값 유효성검사
        /// </summary>
        /// <param name="grp"></param>
        private void _ValidCheck(LayoutControlGroup grp)
        {


            foreach (object item in grp.Items)
            {
                if (item is acLayoutControlItem)
                {
                    acLayoutControlItem layoutItem = item as acLayoutControlItem;

                    if (layoutItem.Control is IBaseEditControl)
                    {

                        IBaseEditControl info = (IBaseEditControl)layoutItem.Control;

                        if (info.isRequired == true && info.isReadyOnly == false)
                        {
                            //컨트롤 사용가능이면 유효성 체크한다.

                            acLayoutControlValidationRule validRule = new acLayoutControlValidationRule();

                            validRule.ErrorType = ErrorType.Warning;

                            if (acInfo.Resource != null)
                            {

                                validRule.ErrorText = acInfo.Resource.GetString("필수 항목입니다.", "5AAPUVJM");
                            }
                            else
                            {
                                validRule.ErrorText = this.DefaultErrText;
                            }


                            if (layoutItem.Control.Enabled == true)
                            {
                                _ValidProvider.SetValidationRule((Control)info.Editor, validRule);
                            }
                            else
                            {
                                _ValidProvider.SetValidationRule((Control)info.Editor, null);
                            }

                        }
                        else
                        {
                            _ValidProvider.SetValidationRule((Control)info.Editor, null);
                        }


                    }

                }
                else if (item is LayoutControlGroup)
                {

                    this._ValidCheck((LayoutControlGroup)item);

                }
            }

        }




        private bool _ResultValidMaskCheck = true;

        /// <summary>
        /// 마스크 유효성검사
        /// </summary>
        /// <param name="grp"></param>
        private void _ValidMaskCheck(LayoutControlGroup grp)
        {

            foreach (object item in grp.Items)
            {
                if (item is acLayoutControlItem)
                {
                    acLayoutControlItem layoutItem = item as acLayoutControlItem;

                    if (layoutItem.Control is BaseEdit)
                    {
                        BaseEdit b = layoutItem.Control as BaseEdit;

                        if (b.DoValidate() == false)
                        {
                            this._ResultValidMaskCheck = false;

                            return;
                        }


                    }

                }
                else if (item is LayoutControlGroup)
                {

                    this._ValidMaskCheck((LayoutControlGroup)item);

                }
            }

        }


        DXValidationProvider _ValidProvider = new DXValidationProvider();

        /// <summary>
        /// 유효성을 체크합니다. 실패하면 false 반환
        /// </summary>
        /// <returns></returns>
        public bool ValidCheck()
        {
            this._ResultValidMaskCheck = true;

            this._ValidMaskCheck(this.Root);

            if (this._ResultValidMaskCheck == false)
            {
                return false;
            }

            this._ValidCheck(this.Root);

            bool result = _ValidProvider.Validate();

            IList<Control> list = _ValidProvider.GetInvalidControls();


            if (list.Count != 0)
            {
                IBaseEditControl edit = (IBaseEditControl)list[0];

                edit.FocusEdit();
            }

            return result;

        }


        /// <summary>
        /// 해당컬럼에 맵칭된 컨트롤 인터페이스를 반환합니다.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public IBaseEditControl GetEditor(string columnName)
        {
            this.MappingCheck();


            if (this._EditorDic.ContainsKey(columnName))
            {
                return this._EditorDic[columnName];
            }
            else
            {
                return null;
            }

        }


        private void MappingCheck()
        {
            if (this._IsMapping == false)
            {
                this.OnCreateControl();
            }
        }



        private string[] _KeyColumns = new string[] { };

        /// <summary>
        /// 현재 형식에서 키가 되는 컬럼이거나 바인딩시 수정하지못하도록하는 컬럼 , 여러개 가능
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] KeyColumns
        {
            get { return _KeyColumns; }
            set
            {
                _KeyColumns = value;
            }
        }



        /// <summary>
        /// 수정된 항목이 있는지 확인한다.
        /// </summary>
        /// <returns></returns>
        public bool ModifyCheck()
        {
            foreach (LayoutControlItem item in this.Root.Items)
            {
                if (item.Control != null)
                {
                    if (item.Control is IBaseEditControl)
                    {
                        BaseEdit editor = (BaseEdit)item.Control;

                        if (editor.IsModified == true)
                        {
                            return true;
                        }

                    }
                }


            }

            return false;
        }

        public delegate void ValueChangedEventHandler(object sender, IBaseEditControl info, object newValue);


        public event ValueChangedEventHandler OnValueChanged;



        public delegate void ValueChangingEventHandler(object sender, IBaseEditControl info, DevExpress.XtraEditors.Controls.ChangingEventArgs e);


        public event ValueChangingEventHandler OnValueChanging;


        public delegate void ValueKeyDownEventHandler(object sender, IBaseEditControl info, KeyEventArgs e);


        public event ValueKeyDownEventHandler OnValueKeyDown;






        private void _SetData(acLayoutControlGroup grp, DataRow row)
        {
            foreach (object obj in grp.Items)
            {
                if (obj is LayoutControlItem)
                {
                    LayoutControlItem item = obj as LayoutControlItem;

                    if (item.Control != null)
                    {
                        if (item.Control is IBaseEditControl)
                        {
                            IBaseEditControl info = (IBaseEditControl)item.Control;

                            if (!string.IsNullOrEmpty(info.ColumnName))
                            {
                                if (row.Table.Columns.Contains(info.ColumnName))
                                {
                                    info.Value = row[info.ColumnName];
                                }

                            }


                        }
                    }
                }
                else
                {
                    _SetData((acLayoutControlGroup)obj, row);
                }

            }
        }

        /// <summary>
        /// 컨트롤에 데이터를 설정한다.
        /// </summary>
        /// <param name="dataRow"></param>
        public void SetData(DataRow dataRow)
        {

            try
            {
                //초기화 없이 데이터 바인딩을 했을경우 초기화한다.

                if (_IsInit == false)
                {
                    this.OnCreateControl();
                }


                this._SetData((acLayoutControlGroup)this.Root, dataRow);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void _DataBind(acLayoutControlGroup layoutGroup, DataRow dataRow, bool isKeyColumnReadOnly)
        {
            try
            {
                foreach (object obj in layoutGroup.Items)
                {

                    if (obj is acLayoutControlItem)
                    {
                        acLayoutControlItem item = obj as acLayoutControlItem;

                        if (item.Control != null)
                        {
                            if (item.Control is IBaseEditControl)
                            {
                                //if (item.Control.Enabled == false)
                                //    continue;

                                IBaseEditControl info = (IBaseEditControl)item.Control;

                                //System.Diagnostics.Debug.WriteLine(info.ColumnName);

                                if (!string.IsNullOrEmpty(info.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info.ColumnName))
                                    {
                                        if ((info.Value != null
                                            && info.Value.ToString().Equals(dataRow[info.ColumnName].ToString()) == false)
                                            || info.Value == null)
                                            info.Value = dataRow[info.ColumnName];
                                    }

                                    //키컬럼 ReadOnly로

                                    if (isKeyColumnReadOnly == true)
                                    {
                                        foreach (string col in _KeyColumns)
                                        {
                                            if (col == info.ColumnName)
                                            {
                                                info.isReadyOnly = true;
                                            }
                                        }
                                    }

                                }

                            }
                            else if (item.Control is acRichEdit info)
                            {
                                if (!string.IsNullOrEmpty(info.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info.ColumnName))
                                    {
                                        if ((!info.Text.isNullOrEmpty()
                                            && info.Text.ToString().Equals(dataRow[info.ColumnName].ToString()) == false)
                                            || info.Text.isNullOrEmpty())


                                            if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Rtf)
                                            {
                                                info.RtfText = dataRow[info.ColumnName].ToString();
                                            }
                                            else if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Html)
                                            {
                                                info.HtmlText = dataRow[info.ColumnName].ToString();
                                            }
                                    }

                                    //키컬럼 ReadOnly로

                                    if (isKeyColumnReadOnly == true)
                                    {
                                        foreach (string col in _KeyColumns)
                                        {
                                            if (col == info.ColumnName)
                                            {
                                                info.isReadyOnly = true;
                                            }
                                        }
                                    }

                                }
                            }
                            else if (item.Control is acCheckedListBoxControl info2)
                            {
                                if (!string.IsNullOrEmpty(info2.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info2.ColumnName))
                                    {
                                        if ((!info2.Text.isNullOrEmpty()
                                            && info2.Text.ToString().Equals(dataRow[info2.ColumnName].ToString()) == false)
                                            || info2.Text.isNullOrEmpty())

                                            info2.Value = dataRow[info2.ColumnName].ToString();                                        
                                    }

                                    //키컬럼 ReadOnly로

                                    if (isKeyColumnReadOnly == true)
                                    {
                                        foreach (string col in _KeyColumns)
                                        {
                                            if (col == info2.ColumnName)
                                            {
                                                info2.isReadyOnly = true;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                    else if (obj is acLayoutControlGroup)
                    {

                        this._DataBind((acLayoutControlGroup)obj, dataRow, isKeyColumnReadOnly);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 컨트롤에 데이터를 매칭시킨다.
        /// </summary>
        /// <param name="dataRow"></param>
        public void DataBind(DataRow row, bool isKeyColumnReadOnly)
        {

            try
            {
                this.MappingCheck();


                this._IsBinding = true;

                this._DataBind(this.Root as acLayoutControlGroup, row, isKeyColumnReadOnly);

                this._IsBinding = false;




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void _DataDisable(acLayoutControlGroup layoutGroup, DataRow dataRow)
        {
            try
            {
                foreach (object obj in layoutGroup.Items)
                {

                    if (obj is acLayoutControlItem)
                    {
                        acLayoutControlItem item = obj as acLayoutControlItem;

                        if (item.Control != null)
                        {
                            if (item.Control is IBaseEditControl)
                            {
                                if (item.Control.Enabled == true)
                                    continue;

                                IBaseEditControl info = (IBaseEditControl)item.Control;

                                //System.Diagnostics.Debug.WriteLine(info.ColumnName);

                                if (!string.IsNullOrEmpty(info.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info.ColumnName))
                                    {
                                        info.Value = null;
                                    }
                                }

                            }
                            else if (item.Control is acRichEdit info)
                            {
                                if (item.Control.Enabled == true)
                                    continue;

                                //System.Diagnostics.Debug.WriteLine(info.ColumnName);

                                if (!string.IsNullOrEmpty(info.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info.ColumnName))
                                    {
                                        if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Rtf)
                                        {
                                            info.RtfText = null;
                                        }
                                        else if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Html)
                                        {
                                            info.HtmlText = null;
                                        }
                                    }
                                }
                            }
                            else if (item.Control is acCheckedListBoxControl info2)
                            {
                                if (item.Control.Enabled == true)
                                    continue;

                                //System.Diagnostics.Debug.WriteLine(info.ColumnName);

                                if (!string.IsNullOrEmpty(info2.ColumnName))
                                {
                                    if (dataRow.Table.Columns.Contains(info2.ColumnName))
                                    {
                                        info2.Value = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (obj is acLayoutControlGroup)
                    {

                        this._DataDisable((acLayoutControlGroup)obj, dataRow);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 컨트롤에 데이터를 매칭시킨다.
        /// </summary>
        /// <param name="dataRow"></param>
        public void DataDisable(DataRow row)
        {

            try
            {
                this.MappingCheck();


                this._IsBinding = true;

                this._DataDisable(this.Root as acLayoutControlGroup, row);

                this._IsBinding = false;




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 매칭된 컨트롤을 초기화한다.
        /// </summary>
        /// <param name="dataRow"></param>
        public void ClearValue()
        {
            this._ClearValue(this.Root as acLayoutControlGroup, false);

        }

        /// <summary>
        /// 매칭된 컨트롤을 초기화한다.
        /// </summary>
        /// <param name="dataRow"></param>
        public void ClearValue(bool bReadOnly)
        {
            this._ClearValue(this.Root as acLayoutControlGroup, bReadOnly);

        }

        private bool _NotRaiseEvent = false;

        private void ClearValueNotRaiseEvent()
        {
            this._NotRaiseEvent = true;

            this._ClearValue(this.Root as acLayoutControlGroup, false);

            this._NotRaiseEvent = false;

        }



        private void _ClearValue(acLayoutControlGroup layoutGroup, bool bReadOnly)
        {
            foreach (object obj in layoutGroup.Items)
            {

                if (obj is acLayoutControlItem)
                {
                    acLayoutControlItem item = obj as acLayoutControlItem;


                    if (item.Control != null)
                    {
                        if (item.Control is IBaseEditControl)
                        {
                            if (item.Control == null)
                                System.Diagnostics.Debugger.Break();
                            IBaseEditControl info = (IBaseEditControl)item.Control;

                            if (info == null)
                                System.Diagnostics.Debugger.Break();
                            System.Diagnostics.Debug.WriteLine(info.ColumnName);

                            if (info.isReadyOnly == false || bReadOnly)
                            {
                                info.Clear();
                            }
                        }
                        else if (item.Control is acRichEdit info)
                        {
                            if (item.Control == null)
                                System.Diagnostics.Debugger.Break();
    
                            if (info == null)
                                System.Diagnostics.Debugger.Break();
                            System.Diagnostics.Debug.WriteLine(info.ColumnName);

                            if (info.isReadyOnly == false || bReadOnly)
                            {
                                if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Rtf)
                                {
                                    info.RtfText = null;
                                }
                                else if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Html)
                                {
                                    info.HtmlText = null;
                                }
                            }
                            
                        }
                        else if (item.Control is acCheckedListBoxControl info2)
                        {
                            if (item.Control == null)
                                System.Diagnostics.Debugger.Break();
             
                            if (info2 == null)
                                System.Diagnostics.Debugger.Break();
                            System.Diagnostics.Debug.WriteLine(info2.ColumnName);

                            if (info2.isReadyOnly == false || bReadOnly)
                            {
                                info2.Clear();
                            }
                        }
                    }


                }
                else if (obj is acLayoutControlGroup)
                {
                    if (obj == null)
                        System.Diagnostics.Debugger.Break();
                    this._ClearValue(obj as acLayoutControlGroup, bReadOnly);
                }

            }


        }

        /// <summary>
        /// 소속된 모든 acControl들의 폰트를 변경한다.
        /// </summary>
        public void SetAllFont(Font Fn)
        {
            try
            {

                foreach (object obj in this.Root.Items)
                {
                    if (obj is acLayoutControlGroup)
                    {
                        foreach (object obj2 in ((acLayoutControlGroup)obj).Items)
                        {
                            if (obj2 is acLayoutControlItem)
                            {
                                acLayoutControlItem item = obj2 as acLayoutControlItem;

                                if (item.Control is IBaseEditControl)
                                {
                                    IBaseEditControl control = item.Control as IBaseEditControl;

                                    item.AppearanceItemCaption.Font = Fn;
                                    control.Editor.Font = Fn;
                                }
                            }
                        }

                    }
                    else if (obj is acLayoutControlItem)
                    {
                        acLayoutControlItem item = obj as acLayoutControlItem;

                        if (((acLayoutControlItem)obj).Control is IBaseEditControl)
                        {
                            IBaseEditControl control2 = (IBaseEditControl)((acLayoutControlItem)obj).Control;

                            item.AppearanceItemCaption.Font = Fn;
                            control2.Editor.Font = Fn;


                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 소속된 모든 acControl들을 읽기전용으로 변경한다.
        /// </summary>
        public void SetAllReadOnly(bool readOnly)
        {
            foreach (object obj in this.Root.Items)
            {
                if (obj is acLayoutControlGroup)
                {
                    foreach (object obj2 in ((acLayoutControlGroup)obj).Items)
                    {
                        if (obj2 is acLayoutControlItem)
                        {
                            acLayoutControlItem item = obj2 as acLayoutControlItem;

                            //item.Control
                            if (item.Control is IBaseEditControl)
                            {
                                IBaseEditControl control = item.Control as IBaseEditControl;

                                control.isReadyOnly = readOnly;
                            }
                        }
                    }

                }
                else if (obj is acLayoutControlItem)
                {
                    if (((acLayoutControlItem)obj).Control is IBaseEditControl)
                    {
                        IBaseEditControl control2 = (IBaseEditControl)((acLayoutControlItem)obj).Control;

                        control2.isReadyOnly = readOnly;


                    }
                }

            }

        }


        /// <summary>
        /// 소속된 모든 acControl들을 읽기전용으로 변경한다.
        /// </summary>
        public void SetAllEnable(bool readOnly)
        {
            foreach (object obj in this.Root.Items)
            {
                if (obj is acLayoutControlGroup)
                {
                    foreach (object obj2 in ((acLayoutControlGroup)obj).Items)
                    {
                        if (obj2 is acLayoutControlItem)
                        {
                            acLayoutControlItem item = obj2 as acLayoutControlItem;

                            item.Control.Enabled = readOnly;

                            //if (item.Control is IBaseEditControl)
                            //{
                            //    IBaseEditControl control = item.Control as IBaseEditControl;

                            //    control.isReadyOnly = readOnly;
                            //}
                        }
                    }

                }
                else if (obj is acLayoutControlItem)
                {
                    ((acLayoutControlItem)obj).Control.Enabled = readOnly;

                    //if (((acLayoutControlItem)obj).Control is IBaseEditControl)
                    //{

                    //    IBaseEditControl control2 = (IBaseEditControl)((acLayoutControlItem)obj).Control;

                    //    control2.isReadyOnly = readOnly;

                    //}
                }

            }

        }

        private void _CreateParameterRow(LayoutControlGroup grp, ref DataTable paramTable, ref Dictionary<string, object> values)
        {
            foreach (object item in grp.Items)
            {
                if (item is acLayoutControlItem)
                {
                    acLayoutControlItem layoutItem = item as acLayoutControlItem;

                    if (layoutItem.Control != null)
                    {
                        if (layoutItem.Control is IBaseEditControl)
                        {
                            IBaseEditControl info = (IBaseEditControl)layoutItem.Control;

                            if (!string.IsNullOrEmpty(info.ColumnName))
                            {
                                values.Add(info.ColumnName, info.Value);

                                if (info.Value.isNull() == false)
                                {
                                    paramTable.Columns.Add(info.ColumnName, info.Value.GetType());
                                }
                                else
                                {
                                    paramTable.Columns.Add(info.ColumnName, typeof(object));
                                }

                            }
                        }
                        else if (layoutItem.Control is acRichEdit info)
                        {
                            if (!string.IsNullOrEmpty(info.ColumnName))
                            {
                                string text = null;

                                if(info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Rtf)
                                {
                                    text = info.RtfText;
                                }
                                else if (info.DocumentFormat == DevExpress.XtraRichEdit.DocumentFormat.Html)
                                {
                                    text = info.HtmlText;
                                }

                                values.Add(info.ColumnName, text);

                                if (info.Text.isNullOrEmpty() == false)
                                {
                                    paramTable.Columns.Add(info.ColumnName, info.Text.GetType());
                                }
                                else
                                {
                                    paramTable.Columns.Add(info.ColumnName, typeof(object));
                                }

                            }
                        }
                        if (layoutItem.Control is acCheckedListBoxControl info2)
                        {
                            
                            if (!string.IsNullOrEmpty(info2.ColumnName))
                            {
                                values.Add(info2.ColumnName, info2.Value);

                                if (info2.Value.isNull() == false)
                                {
                                    paramTable.Columns.Add(info2.ColumnName, info2.Value.GetType());
                                }
                                else
                                {
                                    paramTable.Columns.Add(info2.ColumnName, typeof(object));
                                }

                            }
                        }
                    }
                }
                else if (item is LayoutControlGroup)
                {

                    this._CreateParameterRow((LayoutControlGroup)item, ref paramTable, ref values);

                }
            }

        }
        /// <summary>
        /// 파라메터를 생성합니다.
        /// </summary>
        /// <param name="tableName">테이블명</param>
        /// <param name="isCreatePltCode">기본 컬럼 생성여부</param>
        /// <returns></returns>
        public DataRow CreateParameterRow()
        {
            #region 컬럼 생성

            DataTable paramTable = new DataTable();

            Dictionary<string, object> values = new Dictionary<string, object>();


            this._CreateParameterRow((LayoutControlGroup)this.Root, ref paramTable, ref values);


            #endregion

            #region 값 넣기

            DataRow paramRow = paramTable.NewRow();

            foreach (KeyValuePair<string, object> value in values)
            {
                if (value.Value is DataTable)
                {
                    DataTable dt = (DataTable)value.Value;

                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Columns.Contains("KEY"))
                        {
                            paramRow[value.Key] = dt.Rows[0]["KEY"];
                        }
                    }
                }
                else
                {
                    paramRow[value.Key] = value.Value;
                }
            }


            paramTable.Rows.Add(paramRow);

            #endregion

            return paramRow;


        }




        #region IBaseContainer 멤버

        private string _ContainerName = null;

        public string ContainerName
        {
            get
            {
                return _ContainerName;
            }
            set
            {
                _ContainerName = value;
            }
        }

        #endregion
    }


}
