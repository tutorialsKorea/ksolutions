using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using System.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.Menu;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BizManager;
using System.Reflection;
using DevExpress.XtraPrinting;

namespace ControlManager
{


    public class acTreeListColumnCollection : TreeListColumnCollection
    {
        public acTreeListColumnCollection(TreeList view) : base(view) { }

        protected override TreeListColumn CreateColumn()
        {
            return new acTreeListColumn();
        }


    }

    public class acTreeListColumn : DevExpress.XtraTreeList.Columns.TreeListColumn, IBaseViewControl
    {
        public acTreeListColumn()
            : base()
        {

        }



        private object _EditorData = null;

        public object EditorData
        {
            get { return _EditorData; }
            set { _EditorData = value; }
        }


        private acTreeList.emEditorType _EditorType = acTreeList.emEditorType.NONE;

        public acTreeList.emEditorType EditorType
        {
            get { return _EditorType; }
            set { _EditorType = value; }
        }

        /// <summary>
        /// 유효성을 확인한다.
        /// </summary>
        public bool Check()
        {
            switch (this._EditorType)
            {

                case acTreeList.emEditorType.NONE:
                    {
                        return true;


                    }

                case acTreeList.emEditorType.BUTTON:
                    {

                        return true;


                    }

                case acTreeList.emEditorType.COLOR:
                    {
                        return true;


                    }



                case acTreeList.emEditorType.LOOKUP:
                    {
                        //if (this._EditorData is Dictionary<string, object>)
                        //{
                        //    Dictionary<string, object> editData = this._EditorData as Dictionary<string, object>;

                        //    string[] keys = new string[] {
                        //        "DISPLAY_COLUMN_NAME",
                        //        "VALUE_COLUMN_NAME",
                        //        "CURRENT_SHOW_COLUMN_NAME",
                        //        "DATASOURCE"
                        //    };

                        //    foreach (string key in keys)
                        //    {
                        //        if (!editData.ContainsKey(key))
                        //        {
                        //            return false;
                        //        }

                        //    }

                        //    return true;

                        //}

                        //return false;

                        return true;
                    }


                case acTreeList.emEditorType.PICTURE:
                    {
                        return true;


                    }

                case acTreeList.emEditorType.TEXT:
                    {
                        return true;

                    }

                case acTreeList.emEditorType.CHECK:
                    {

                        if (this._EditorData is ControlManager.acTreeList.emCheckEditDataType)
                        {
                            return true;
                        }

                        break;
                    }

                case acTreeList.emEditorType.DATE:
                    {

                        return true;

                    }





            }

            return false;

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

        private bool _IsRequired = false;

        public bool IsRequired
        {
            get
            {
                return _IsRequired;
            }
            set
            {
                _IsRequired = value;
            }

        }
        #endregion
    }


    public class acTreeList : DevExpress.XtraTreeList.TreeList
    {
        private bool _ShowMenu = false;



        protected override void WndProc(ref Message m)
        {
            try
            {
                if (acInfo.ReleaseMode == true)
                {
                    if (m.Msg == WIN32API.WM_CONTEXTMENU)
                    {
                        Point pt = new Point(m.LParam.ToInt32());

                        Point cpt = this.PointToClient(pt);

                        acTreeList list = this;

                        TreeListHitInfo hitInfo = list.CalcHitInfo(this.PointToClient(pt));

                        list.RaiseShowPopupMenu(hitInfo, pt);

                        //this._ShowMenu = true;


                        //if (_MouseEventArgs != null)
                        //{
                        //    base.OnMouseDown(_MouseEventArgs);
                        //}


                        //this._ShowMenu = false;


                    }
                }

                base.WndProc(ref m);
            }
            catch { }

        }



        private MouseEventArgs _MouseEventArgs = null;

        protected override void OnMouseDown(MouseEventArgs ee)
        {
            try
            {
                this._MouseEventArgs = ee;

                if (acInfo.ReleaseMode == true)
                {
                    if (ee.Button == MouseButtons.Right)
                    {
                        if (this._ShowMenu == true)
                        {
                            base.OnMouseDown(ee);

                        }
                    }
                    else
                    {
                        base.OnMouseDown(ee);
                    }

                }
                else
                {
                    base.OnMouseDown(ee);
                }

            }
            catch { }

        }



        private Control _ParentControl = null;



        internal byte[] _SystemLayout = null;

        internal byte[] _SystemConfig = null;

        /// <summary>
        /// 부모컨트롤(메뉴컨트롤)
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.ParentControl == null)
            {
                this.ParentControl = this.GetContainerControl() as Control;
            }

        }

        public enum emDateMask
        {

            /// <summary>
            /// 년월
            /// </summary>
            MONTH_DATE,

            /// <summary>
            /// 년월일
            /// </summary>
            SHORT_DATE,

            /// <summary>
            /// 년월일시분
            /// </summary>
            MEDIUM_DATE,

            /// <summary>
            /// 년월일시분초
            /// </summary>
            LONG_DATE
        };


        private string _SaveFileName = null;


        /// <summary>
        /// 저장시 파일이름을 설정합니다.
        /// </summary>
        public string SaveFileName
        {
            get { return _SaveFileName; }
            set { _SaveFileName = value; }
        }

        public delegate void ChangeDatasourceEvenHandler();

        /// <summary>
        /// 데이터소스가 변경되었을때 발생합니다.
        /// </summary>
        public event ChangeDatasourceEvenHandler ChangeDataSource;

        private DevExpress.XtraBars.BarManager _DefaultBarManager = null;

        private System.Windows.Forms.Timer _VisibleTimer = null;

        public acTreeList()
            : base()
        {

            //this._VisibleTimer = new System.Windows.Forms.Timer();

            //this._VisibleTimer.Interval = 100;

            if (acInfo.IsRunTime == true)
            {

                this._DefaultTable = new DataTable(this.Name);

                this.DataSource = _DefaultTable;


                this._DefaultBarManager = new DevExpress.XtraBars.BarManager();

                //this._DefaultBarManager.AllowCustomization = false;
                //this._DefaultBarManager.AllowQuickCustomization = false;
                //this._DefaultBarManager.AllowShowToolbarsPopup = false;
                //this._DefaultBarManager.CloseButtonAffectAllTabs = false;
                //this._DefaultBarManager.ShowFullMenusAfterDelay = false;
                //this._DefaultBarManager.ShowFullMenus = true;


                this._DefaultBarManager.Form = this;


                this.MenuManager = this._DefaultBarManager as DevExpress.Utils.Menu.IDXMenuManager;


            }

            this._IsLoadConfig = true;

            this.OptionsMenu.EnableColumnMenu = true;
            this.OptionsMenu.EnableFooterMenu = true;
            this.OptionsMenu.ShowExpandCollapseItems = false;
            this.ColumnPanelRowHeight = 30;
            
            this.RowHeight = 20;
            this.OptionsView.ShowIndicator = true;
            this.IndicatorWidth = 30;
            
            this._Config = new acTreeListUserConfig(this);

            this.Appearance.SelectedRow.ForeColor = Color.Black;
            this.Appearance.FocusedRow.ForeColor = Color.Black;

            this.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(acTreeList_PopupMenuShowing);

            this.Disposed += AcTreeList_Disposed;
            this.DragObjectDrop += new DragObjectDropEventHandler(AcTreeList_DragObjectDrop);
            this.DragObjectStart += new DragObjectStartEventHandler(AcTreeList_DragObjectStart);


            this.MouseDown += new MouseEventHandler(acTreeList_MouseDown);
            this.MouseMove += new MouseEventHandler(acTreeList_MouseMove);

            this.Click += new EventHandler(acTreeList_Click);
            this.KeyDown += AcTreeList_KeyDown;

            this.VisibleChanged += new EventHandler(acTreeList_VisibleChanged);

            //this._VisibleTimer.Tick += new EventHandler(VisibleTimer_Tick);

            this.CustomDrawNodeIndicator += AcTreeList_CustomDrawNodeIndicator;

            this.CustomDrawNodeCell += AcTreeList_CustomDrawNodeCell;
            //try
            //{
            //SetFocusRowBorderPen = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_COLOR").isNullOrEmpty() ? Pens.Transparent : new Pen(acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_COLOR").toColor());
            //SetFocusRowBorderPen.Width = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_HEIGHT").isNumeric() ? acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_HEIGHT").toInt() : 1;

            //string sDashStyle = string.Empty;
            //sDashStyle = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_STYLE");


            //switch (sDashStyle)
            //{
            //    case "Dash":
            //        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //        break;
            //    case "Dot":
            //        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //        break;
            //    case "DashDot":
            //        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //        break;
            //    case "Solid":
            //        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //        break;
            //    case "DashDotDot":
            //        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            //        break;
            //}

            //FocusRowBorderPenUse = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_USE").isNullOrEmpty() ? false : acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_USE").ToString() == "1" ? true : false;

            //    this.Paint += acTreeList_Paint;
            //}
            //catch { }



        }

        public bool AllowEditColorUse = true;
        private Color clreditNode = Color.LightGoldenrodYellow;

        private void AcTreeList_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            try
            {

                if (this._Config == null)
                {
                    return;
                }

                
                if (e.Column.OptionsColumn.AllowEdit == true && AllowEditColorUse)
                {
                    e.Appearance.BackColor = clreditNode;

                    e.Appearance.BackColor2 = clreditNode;

                    //e.Appearance.Font = _Config.EditCellStyle.Font;

                    e.Appearance.ForeColor = Color.Black; //_Config.EditCellStyle.ForeColor;

                    //e.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    RepositoryItem edit = (RepositoryItem)e.Column.ColumnEdit;

                    if (edit != null)
                    {

                        edit.Appearance.BackColor = clreditNode;
                        edit.Appearance.BackColor2 = clreditNode;
                        edit.Appearance.ForeColor = Color.Black;//셀 value수정시 폰트 색상 안바껴서 검정색으로 고정(신재경)

                        //edit.Appearance.Font = _Config.EditCellStyle.Font;
                        //edit.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    }

                }


                //수정가능한 셀



            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void AcTreeList_Disposed(object sender, EventArgs e)
        {


            if (_ConfigManager != null)
            {
                _ConfigManager.Dispose();
            }

            if (_LoadConfig != null)
            {
                _LoadConfig.Dispose();
            }



        }

        void VisibleTimer_Tick(object sender, EventArgs e)
        {

            if (this.Visible == false)
            {
                //보이지않을때는 서브윈도우를 모두 숨긴다.

                acTreeList list = (acTreeList)this;

                if (list != null)
                {
                    //list.hide

                }

                this._VisibleTimer.Stop();
            }


        }


        private void AcTreeList_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;

                DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
                args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();
            }
            catch { }

        }

        private bool _InitLayout = false;

        void acTreeList_VisibleChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.Visible == true)
                {

                    if (this._Config != null)
                    {
                        //최초 한번만 실행
                        if (ControlManager.acInfo.IsRunTime == true)
                        {
                            if (this._InitLayout == false)
                            {

                                #region 시스템 UI 저장

                                acTreeListUserConfig systemConfig = new acTreeListUserConfig(this);

                                systemConfig.Save(out _SystemLayout, out _SystemConfig);

                                #endregion

                                if (this._IsLoadConfig == true)
                                {
                                    DataTable paramTable = new DataTable("RQSTDT");
                                    paramTable.Columns.Add("PLT_CODE");
                                    paramTable.Columns.Add("EMP_CODE");
                                    paramTable.Columns.Add("CLASS_NAME");
                                    paramTable.Columns.Add("CONTROL_NAME");

                                    DataRow paramRow = paramTable.NewRow();
                                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                    paramRow["EMP_CODE"] = acInfo.UserID;
                                    paramRow["CLASS_NAME"] = this.ParentControl.Name;
                                    paramRow["CONTROL_NAME"] = this.Name;

                                    paramTable.Rows.Add(paramRow);

                                    DataSet paramSet = new DataSet();
                                    paramSet.Tables.Add(paramTable);

                                    BizRun.QBizRun.ExecuteService(this.ParentControl, QBiz.emExecuteType.NONE, "CTRL",
                                    "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT", QuickUse2, QuickException);

                                }

                            }

                            _InitLayout = true;
                        }

                        #region 저장된 설정 불러오기

                        //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                        //if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                        //{
                        //    DataRow configRow = resultSet.Tables["RSLTDT"].Rows[0];

                        //    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                        //    byte[] configBuffer = (byte[])configRow["OBJECT"];

                        //    this._Config.Restore(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                        //}

                        #endregion 저장된 설정 불러오기
                    }
                }

            }
            catch { }
        }

        void QuickUse2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            acTreeList list = (acTreeList)this;

            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    list._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);



                }

            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
                        (this.ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                         (this.ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {

                    acMessageBox.Show(this.ParentControl, ex);
                }
            }


        }

        void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

                if (e.result.Tables["RQSTDT"].Rows.Count > 0)
                {

                    this._Config.ConfigName = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];

                }

                //if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                //{
                //    DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

                //    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                //    byte[] configBuffer = (byte[])configRow["OBJECT"];

                //    this._Config.Restore(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                //}

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);

            }


        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this.ParentControl, ex);
        }

        private int _DragDropColumnVisibleIdx = -1;
        void AcTreeList_DragObjectStart(object sender, DragObjectStartEventArgs e)
        {
            //드래그 컬럼 정보 저장
            try
            {
                acTreeListColumn cln = e.DragObject as acTreeListColumn;

                this._DragDropColumnVisibleIdx = cln.VisibleIndex;

            }
            catch { }

        }

        private void AcTreeList_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
            try
            {
                acTreeListColumn cln = e.DragObject as acTreeListColumn;


                if (cln != null)
                {
                    if (cln.Visible)
                    {
                        if (cln.IsRequired == true)
                        {
                            // 필수입력 컬럼은 컬럼제외하지않음

                            cln.Visible = true;

                            cln.VisibleIndex = this._DragDropColumnVisibleIdx;

                            acMessageBox.Show(this.ParentControl, "필수항목은 컬럼제외 할수없습니다.", "MMOX7NG8", true, acMessageBox.emMessageBoxType.CONFIRM);

                            return;

                        }
                    }
                }
            }
            catch { }
        }

        private void AcTreeList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    TreeList treeList = sender as TreeList;
                    Clipboard.SetText(treeList.FocusedNode.GetDisplayText(treeList.FocusedColumn));
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }

        public Pen SetFocusRowBorderPen = Pens.Transparent;
        public bool FocusRowBorderPenUse = false;
        private void acTreeList_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                //if (FocusRowBorderPenUse)
                //{
                //    acTreeList tl = sender as acTreeList;

                //    if (tl.FocusedRow == null)
                //        return;
                //    Rectangle r = Rectangle.Empty;
                //    r = tl.FocusedRow.Bounds;
                //    if (r != Rectangle.Empty)
                //    {
                //        r.Height -= 2;
                //        r.Width -= 2;
                //        e.Graphics.DrawRectangle(SetFocusRowBorderPen, r);
                //    }
                //}
            }
            catch { }
        }

        private MouseEventArgs _MouseDownArgs = null;

        private int _FirstMouseDownIdx = -1;

        void acTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            this._MouseDownArgs = e;
        }


        int _PreRowhandle = -1;
        private void acTreeList_MouseMove(object sender, MouseEventArgs e)
        {
            if (_PreRowhandle == -1)
                return;

        }

        /// <summary>
        /// 전체 체크 여부
        /// </summary>
        /// 
        internal bool _AllCheked = false;


        void acTreeList_Click(object sender, EventArgs e)
        {

            acTreeList treeList = sender as acTreeList;

            if (this._MouseDownArgs != null)
            {


                TreeListHitInfo hintInfo = treeList.CalcHitInfo(this._MouseDownArgs.Location);


                //체크 타입은 정렬하지않고 전체선택 또는 해제합니다.

                if (hintInfo.HitInfoType == HitInfoType.Column)
                {


                    acTreeListColumn acCol = hintInfo.Column as acTreeListColumn;

                    if (acCol == null)
                    {
                        return;
                    }

                    //EditType이 체크면서 에디트 가능한 컬럼이면 전체선택 기능

                    if (acCol.EditorType == emEditorType.CHECK &&
                        acCol.OptionsColumn.AllowEdit == true)
                    {



                        object checkValue = null;

                        emCheckEditDataType checkType = (emCheckEditDataType)acCol.EditorData;

                        switch (checkType)
                        {
                            case emCheckEditDataType._BOOL:

                                if (_AllCheked == false)
                                {
                                    checkValue = true;

                                    _AllCheked = true;

                                }
                                else
                                {
                                    checkValue = false;

                                    _AllCheked = false;
                                }

                                break;

                            case emCheckEditDataType._INT:

                                if (_AllCheked == false)
                                {
                                    checkValue = 1;

                                    _AllCheked = true;

                                }
                                else
                                {
                                    checkValue = 0;

                                    _AllCheked = false;
                                }

                                break;

                            case emCheckEditDataType._BYTE:

                                if (_AllCheked == false)
                                {
                                    checkValue = (byte)1;

                                    _AllCheked = true;

                                }
                                else
                                {
                                    checkValue = (byte)0;

                                    _AllCheked = false;
                                }

                                break;

                            case emCheckEditDataType._STRING:


                                if (_AllCheked == false)
                                {
                                    checkValue = "1";

                                    _AllCheked = true;
                                }
                                else
                                {
                                    checkValue = "0";

                                    _AllCheked = false;
                                }


                                break;

                        }


                        //모든 Row 체크로 변경

                        DataTable data = this.DataSource as DataTable;

                        foreach (DataRow row in data.Rows)
                        {
                            row[hintInfo.Column.FieldName] = checkValue;
                        }



                        return;


                    }



                }

            }
        }


        public DataView GetDataView()
        {

            DataTable data = base.DataSource as DataTable;

            DataView view = new DataView(data);


            return view;

        }

        public DataView GetDataView(string filter)
        {

            DataTable data = base.DataSource as DataTable;

            DataView view = new DataView(data);

            view.RowFilter = filter;


            return view;

        }

        /// <summary>
        /// 에디터를 종료한다.
        /// </summary>
        public void EndEditor()
        {
            this.CloseEditor();

            this.AcceptChanges();


        }

        private object _OldFocusKeyFieldValue = null;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object OldFocusKeyFieldValue
        {
            get { return _OldFocusKeyFieldValue; }
        }

        public void SetOldFocusNode()
        {
            this.FocusedNode = this.FindNodeByFieldValue(this.KeyFieldName, this.OldFocusKeyFieldValue);
        }


        /// <summary>
        /// TreeList 컬럼형식맞게 테이블 변경
        /// </summary>
        /// <param name="dt"></param>
        private void ConvertColumnType(DataTable dt)
        {
            Dictionary<string, Type> list = new Dictionary<string, Type>();

            //변환된 데이터형태 정의

            foreach (acTreeListColumn col in this.Columns)
            {

                if (col.EditorType == emEditorType.DATE)
                {
                    if (dt.Columns.Contains(col.FieldName))
                    {
                        if (dt.Columns[col.FieldName].DataType != typeof(DateTime))
                        {

                            list.Add(col.FieldName, typeof(DateTime));

                        }
                    }
                }


            }


            foreach (KeyValuePair<string, Type> col in list)
            {
                dt.Columns.Add(col.Key + "_temp", Type.GetType(col.Value.FullName));
            }

            //컬럼 데이터 형태 변환

            foreach (DataRow row in dt.Rows)
            {
                foreach (KeyValuePair<string, Type> col in list)
                {
                    if (Type.GetType(col.Value.FullName) == typeof(DateTime))
                    {
                        row[col.Key + "_temp"] = row[col.Key].isNull() ? (object)DBNull.Value : (object)row[col.Key].toDateTime();
                    }
                    else if (Type.GetType(col.Value.FullName) == typeof(string))
                    {
                        row[col.Key + "_temp"] = row[col.Key].toStringNull();
                    }

                }

            }

            foreach (KeyValuePair<string, Type> col in list)
            {
                dt.Columns.Remove(col.Key);
                dt.Columns[col.Key + "_temp"].ColumnName = col.Key;

            }

        }

        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                DataTable temp = value as DataTable;

                if (this.FocusedNode != null)
                {
                    this._OldFocusKeyFieldValue = this.FocusedNode[this.KeyFieldName];
                }

                if (temp != null)
                {
                    this.ConvertColumnType(temp);

                    base.DataSource = temp;

                }
                else
                {
                    base.DataSource = value;
                }

            }


        }

        private bool _ShowGroupFooter = false;



        private void SetTreeColumnMenu(TreeListMenu menu, TreeListHitInfo hitInfo)
        {
            try
            {

                if (hitInfo.HitInfoType == HitInfoType.Column || hitInfo.HitInfoType == HitInfoType.ColumnPanel)
                {
                    acTreeListColumn acCol = (acTreeListColumn)hitInfo.Column;

                    DXSubMenuItem menuItemColumn = null;

                    if (acCol != null)
                    {
                        menuItemColumn = new DXSubMenuItem(acCol.Caption);
                        menuItemColumn.Image = ControlManager.Resource.emblem_symbolic_link;

                        #region 고정기능 설정

                        bool fixedLeftChecked = false;
                        bool fixedRightChecked = false;

                        if (acCol.Fixed == FixedStyle.Left)
                        {
                            fixedLeftChecked = true;
                            fixedRightChecked = false;

                        }
                        else if (acCol.Fixed == FixedStyle.Right)
                        {
                            fixedLeftChecked = false;
                            fixedRightChecked = true;

                        }
                        else
                        {
                            fixedLeftChecked = false;
                            fixedRightChecked = false;
                        }

                        DXSubMenuItem menuItemFixed = new DXSubMenuItem(acInfo.Resource.GetString("고정", "V6SLB3R7"));

                        menuItemFixed.Image = ControlManager.Resource.cell_edit;

                        acDXMenuCheckItem menuItemFixedLeft = new acDXMenuCheckItem(acInfo.Resource.GetString("왼쪽", "CGIKO9PD"), fixedLeftChecked);

                        menuItemFixedLeft.RefObject = acCol;
                        menuItemFixedLeft.Click += new EventHandler(menuItemFixedLeft_Click);

                        acDXMenuCheckItem menuItemFixedRight = new acDXMenuCheckItem(acInfo.Resource.GetString("오른쪽", "0H3LO6W4"), fixedRightChecked);

                        menuItemFixedRight.RefObject = acCol;
                        menuItemFixedRight.Click += new EventHandler(menuItemFixedRight_Click);

                        menuItemFixed.Items.Add(menuItemFixedLeft);
                        menuItemFixed.Items.Add(menuItemFixedRight);

                        #endregion


                        #region 정렬기능 설정

                        DXSubMenuItem menuItemAlign = new DXSubMenuItem(acInfo.Resource.GetString("정렬", "RCX5CLOA"));
                        menuItemAlign.Image = ControlManager.Resource.format_decreaseindent;

                        bool leftAlignChecked = false;
                        bool centerAlignChecked = false;
                        bool rightAlignChecked = false;

                        switch (acCol.AppearanceCell.TextOptions.HAlignment)
                        {
                            case HorzAlignment.Near:

                                leftAlignChecked = true;
                                centerAlignChecked = false;
                                rightAlignChecked = false;

                                break;

                            case HorzAlignment.Center:

                                leftAlignChecked = false;
                                centerAlignChecked = true;
                                rightAlignChecked = false;

                                break;

                            case HorzAlignment.Far:

                                leftAlignChecked = false;
                                centerAlignChecked = false;
                                rightAlignChecked = true;

                                break;
                        }


                        acDXMenuCheckItem menuItemAlignLeft = new acDXMenuCheckItem(acInfo.Resource.GetString("왼쪽", "CGIKO9PD"), leftAlignChecked);

                        menuItemAlignLeft.Click += new EventHandler(menuItemAlignLeft_Click);
                        menuItemAlignLeft.RefObject = acCol;

                        acDXMenuCheckItem menuItemAlignCenter = new acDXMenuCheckItem(acInfo.Resource.GetString("중앙", "U3V3VON0"), centerAlignChecked);

                        menuItemAlignCenter.Click += new EventHandler(menuItemAlignCenter_Click);
                        menuItemAlignCenter.RefObject = acCol;

                        acDXMenuCheckItem menuItemAlignRight = new acDXMenuCheckItem(acInfo.Resource.GetString("오른쪽", "0H3LO6W4"), rightAlignChecked);

                        menuItemAlignRight.Click += new EventHandler(menuItemAlignRight_Click);
                        menuItemAlignRight.RefObject = acCol;

                        #endregion

                        #region 빠른 필터 기능 설정

                        acMenuItem menuItemFilter = new acMenuItem(acInfo.Resource.GetString("빠른 필터", "78ED5IQF"));

                        menuItemFilter.Image = ControlManager.Resource.flag_blue_x16;

                        menuItemFilter.UserData = acCol;

                        //menuItemFilter.Click += new EventHandler(menuItemFilter_Click);

                        #endregion


                        menuItemAlign.Items.Add(menuItemAlignLeft);

                        menuItemAlign.Items.Add(menuItemAlignCenter);

                        menuItemAlign.Items.Add(menuItemAlignRight);

                        //정렬
                        menuItemColumn.Items.Add(menuItemAlign);

                        //고정
                        menuItemColumn.Items.Add(menuItemFixed);

                        //필터
                        menuItemColumn.Items.Add(menuItemFilter);



                        #region 에디터 형태 전용


                        if (acCol.EditorType == emEditorType.LOOKUP)
                        {

                            //Dictionary<string, object> editData = acCol.EditorData as Dictionary<string, object>;

                            //RepositoryItemLookUpEdit edit = acCol.ColumnEdit as RepositoryItemLookUpEdit;

                            //bool menuItemEditShowTypeDisplayCheked = false;
                            //bool menuItemEditShowTypeValueCheked = false;

                            //if (edit.DisplayMember == editData["DISPLAY_COLUMN_NAME"].ToString())
                            //{
                            //    menuItemEditShowTypeDisplayCheked = true;
                            //    menuItemEditShowTypeValueCheked = false;
                            //}
                            //else
                            //{
                            //    menuItemEditShowTypeDisplayCheked = false;
                            //    menuItemEditShowTypeValueCheked = true;
                            //}

                            //DXSubMenuItem menuItemEditShowType = new DXSubMenuItem(acInfo.Resource.GetString("표시형태", "4RDULC0E"));
                            //menuItemEditShowType.Image = ControlManager.Resource.textfield_rename_x16;

                            //acDXMenuCheckItem menuItemEditShowTypeDisplay = new acDXMenuCheckItem(acInfo.Resource.GetString("명", "3F0G0LI0"), menuItemEditShowTypeDisplayCheked);

                            //menuItemEditShowTypeDisplay.Click += new EventHandler(menuItemEditShowTypeDisplay_Click);
                            //menuItemEditShowTypeDisplay.RefObject = acCol;

                            //acDXMenuCheckItem menuItemEditShowTypeValue = new acDXMenuCheckItem(acInfo.Resource.GetString("값", "GJ8YAWE5"), menuItemEditShowTypeValueCheked);

                            //menuItemEditShowTypeValue.Click += new EventHandler(menuItemEditShowTypeValue_Click);
                            //menuItemEditShowTypeValue.RefObject = acCol;

                            //menuItemEditShowType.Items.Add(menuItemEditShowTypeDisplay);
                            //menuItemEditShowType.Items.Add(menuItemEditShowTypeValue);

                            //menuItemColumn.Items.Add(menuItemEditShowType);
                        }


                        #endregion

                    }

                    //컬럼 자동크기(전체)

                    DXMenuItem menuItemAllBestFitColumns = new DXMenuItem(acInfo.Resource.GetString("전체 컬럼 자동크기", "AYN0WR6I"));
                    menuItemAllBestFitColumns.Image = ControlManager.Resource.adjustcol;
                    menuItemAllBestFitColumns.Click += new EventHandler(menuItemAllBestFitColumns_Click);


                    DXSubMenuItem menuItemShow = new DXSubMenuItem(acInfo.Resource.GetString("표시", "0VXIPFNO"));
                    menuItemShow.Image = ControlManager.Resource.preferences_desktop_locale;


                    #region 기능


                    DXSubMenuItem menuItemMethod = new DXSubMenuItem(acInfo.Resource.GetString("기능", "QS1MTC9B"));
                    menuItemMethod.Image = ControlManager.Resource.wand_x16;

                    DXMenuItem menuItemGroupExpand = new DXMenuItem(acInfo.Resource.GetString("모든 그룹 펼치기", "FSEYB4YS"));
                    menuItemGroupExpand.Image = ControlManager.Resource.arrow_expand_x16;

                    DXMenuItem menuItemGroupCollapse = new DXMenuItem(acInfo.Resource.GetString("모든 그룹 접기", "7I2HYTI0"));
                    menuItemGroupCollapse.Image = ControlManager.Resource.arrow_contract_x16;

                    menuItemGroupExpand.Click += MenuItemGroupExpand_Click;
                    menuItemGroupCollapse.Click += MenuItemGroupCollapse_Click;

                    acDXMenuCheckItem menuItemAlwaysBestFit = new acDXMenuCheckItem(acInfo.Resource.GetString("항상 전체 컬럼 자동크기", "LHZDTQ5M"), _Config.AlwaysBestFit);
                    menuItemAlwaysBestFit.Image = ControlManager.Resource.adjustcol_star_x16;
                    menuItemAlwaysBestFit.Click += new EventHandler(menuItemAlwaysBestFit_Click);


                    menuItemMethod.Items.Add(menuItemAllBestFitColumns);


                    menuItemMethod.Items.Add(menuItemAlwaysBestFit);

                    menuItemMethod.Items.Add(menuItemGroupExpand);
                    menuItemMethod.Items.Add(menuItemGroupCollapse);

                    #endregion



                    acDXMenuCheckItem menuItemShowColumnHeader = new acDXMenuCheckItem(acInfo.Resource.GetString("컬럼", "8HEB5JMB"), this.OptionsView.ShowCaption);
                    menuItemShowColumnHeader.Click += new EventHandler(menuItemShowColumnHeader_Click);

                    acDXMenuCheckItem menuItemShowRowNum = new acDXMenuCheckItem(acInfo.Resource.GetString("행번호", "00GAQ8W2"), this.OptionsView.ShowIndicator);
                    menuItemShowRowNum.Click += new EventHandler(menuItemShowRowNum_Click);

                    acDXMenuCheckItem menuItemFooter = new acDXMenuCheckItem(acInfo.Resource.GetString("전체 요약", "1HTM1B9U"), this.OptionsView.ShowSummaryFooter);
                    menuItemFooter.Click += new EventHandler(menuItemFooter_Click);

                    acDXMenuCheckItem menuItemGroupFooter = new acDXMenuCheckItem(acInfo.Resource.GetString("그룹 요약", "7K0Y2QTV"), this._ShowGroupFooter);
                    menuItemGroupFooter.Click += new EventHandler(menuItemGroupFooter_Click);

                    menuItemShow.Items.Add(menuItemShowRowNum);
                    menuItemShow.Items.Add(menuItemShowColumnHeader);
                    menuItemShow.Items.Add(menuItemFooter);
                    menuItemShow.Items.Add(menuItemGroupFooter);

                    #region 스타일 상자

                    //DXMenuItem menuItemStyleBox = new DXMenuItem(acInfo.Resource.GetString("스타일 상자", "6T0ZDDPE"));
                    //menuItemStyleBox.Image = ControlManager.Resource.applications_graphics;
                    //menuItemStyleBox.Click += new EventHandler(menuItemStyleBox_Click);

                    #endregion

                    #region 사용자UI

                    DXSubMenuItem menuItemConfig = new DXSubMenuItem(acInfo.Resource.GetString("사용자 UI", "MVDNG5SB"));
                    menuItemConfig.Image = ControlManager.Resource.color_swatchx_16;


                    //적용된 사용자 UI
                    DXMenuItem menuAssignConfig = new DXMenuItem(string.Format(acInfo.Resource.GetString("현재 설정된 UI - {0}", "NK9O7TO0"), this._Config.ConfigName));

                    menuAssignConfig.Image = ControlManager.Resource.appointment;

                    DXMenuItem menuItemConfigLoad = new DXMenuItem(acInfo.Resource.GetString("불러오기", "VO8OYFRA"));
                    menuItemConfigLoad.Image = ControlManager.Resource.document_open;
                    menuItemConfigLoad.Click += new EventHandler(menuItemConfigLoad_Click);

                    DXMenuItem menuItemConfigSave = new DXMenuItem(acInfo.Resource.GetString("저장", "7NKYXFU5"));
                    menuItemConfigSave.Image = ControlManager.Resource.document_save;
                    menuItemConfigSave.Click += new EventHandler(menuItemConfigSave_Click);

                    DXMenuItem menuItemConfigOtherSave = new DXMenuItem(acInfo.Resource.GetString("다른이름으로 저장", "Q8JXEI9K"));
                    menuItemConfigOtherSave.Image = ControlManager.Resource.document_save_as;
                    menuItemConfigOtherSave.Click += new EventHandler(menuItemConfigOtherSave_Click);


                    DXMenuItem menuItemConfigUse = new DXMenuItem(acInfo.Resource.GetString("현재 사용자 UI을 기본으로 설정", "K913LULF"));
                    menuItemConfigUse.Image = ControlManager.Resource.table_refresh_x16;
                    menuItemConfigUse.Click += new EventHandler(menuItemConfigUse_Click);


                    DXMenuItem menuItemSystemConfig = new DXMenuItem(acInfo.Resource.GetString("시스템 UI로 초기화", "7Z7GBDQ6"));
                    menuItemSystemConfig.Image = ControlManager.Resource.layout_x16;
                    menuItemSystemConfig.Click += new EventHandler(menuItemSystemConfig_Click);

                    DXMenuItem menuItemConfigManager = new DXMenuItem(acInfo.Resource.GetString("관리", "0FNNF1ZT"));
                    menuItemConfigManager.Image = ControlManager.Resource.edit_find_replace_x16;
                    menuItemConfigManager.Click += new EventHandler(menuItemConfigManager_Click);


                    //현재 설정중인 사용자 UI가 존재하지않음
                    if (string.IsNullOrEmpty(this._Config.ConfigName))
                    {
                        menuAssignConfig.Visible = false;
                        menuItemConfigUse.Enabled = false;
                        menuItemSystemConfig.Enabled = false;
                    }


                    menuItemConfig.Items.Add(menuAssignConfig);

                    menuItemConfig.Items.Add(menuItemConfigLoad);

                    menuItemConfig.Items.Add(menuItemConfigSave);
                    menuItemConfig.Items.Add(menuItemConfigOtherSave);


                    menuItemConfig.Items.Add(menuItemConfigUse);

                    menuItemConfig.Items.Add(menuItemSystemConfig);

                    menuItemConfig.Items.Add(menuItemConfigManager);

                    #endregion


                    DXSubMenuItem menuItemSaveFile = new DXSubMenuItem(acInfo.Resource.GetString("파일로 저장", "LVJVBFZF"));
                    menuItemSaveFile.Image = ControlManager.Resource.document_save;

                    DXMenuItem menuItemToExcel = new DXMenuItem("Microsoft Excel(.xls)");
                    menuItemToExcel.Image = ControlManager.Resource.page_excel_x16;
                    menuItemToExcel.Click += new EventHandler(menuItemToExcel_Click);

                    DXMenuItem menuItemToXlsx = new DXMenuItem("Microsoft Excel(.xlsx)");
                    menuItemToXlsx.Image = ControlManager.Resource.page_excel_x16;
                    menuItemToXlsx.Click += menuItemToXlsx_Click;


                    DXMenuItem menuItemToPDF = new DXMenuItem(acInfo.Resource.GetString("Adobe Acrobat PDF", "FWSGOLL9"));
                    menuItemToPDF.Image = ControlManager.Resource.pdf;
                    menuItemToPDF.Click += new EventHandler(menuItemToPDF_Click);

                    DXMenuItem menuItemToText = new DXMenuItem(acInfo.Resource.GetString("텍스트 문서", "PR5RRJCW"));
                    menuItemToText.Image = ControlManager.Resource.txt;
                    menuItemToText.Click += new EventHandler(menuItemToText_Click);

                    DXMenuItem menuItemToRTF = new DXMenuItem(acInfo.Resource.GetString("서식있는 텍스트(RTF)", "G2HTCWBM"));
                    menuItemToRTF.Image = ControlManager.Resource.document;
                    menuItemToRTF.Click += new EventHandler(menuItemToRTF_Click);

                    DXMenuItem menuItemToHtml = new DXMenuItem(acInfo.Resource.GetString("웹문서 (html)", "JD5SEGA7"));
                    menuItemToHtml.Image = ControlManager.Resource.html;
                    menuItemToHtml.Click += new EventHandler(menuItemToHtml_Click);

                    DXMenuItem menuItemToMht = new DXMenuItem(acInfo.Resource.GetString("웹페이지 보관파일 (mht)", "BWPMBX6C"));
                    menuItemToMht.Image = ControlManager.Resource.templates;
                    menuItemToMht.Click += new EventHandler(menuItemToMht_Click);


                    menuItemSaveFile.Items.Add(menuItemToExcel);
                    menuItemSaveFile.Items.Add(menuItemToXlsx);
                    menuItemSaveFile.Items.Add(menuItemToPDF);
                    menuItemSaveFile.Items.Add(menuItemToText);
                    menuItemSaveFile.Items.Add(menuItemToRTF);
                    menuItemSaveFile.Items.Add(menuItemToHtml);
                    menuItemSaveFile.Items.Add(menuItemToMht);


                    //인쇄


                    DXMenuItem menuItemDefaultPrint = new DXMenuItem(acInfo.Resource.GetString("인쇄", "4HOA9EHQ"));
                    menuItemDefaultPrint.Image = ControlManager.Resource.document_print_x16;
                    menuItemDefaultPrint.Click += new EventHandler(menuItemDefaultPrint_Click);


                    //DXMenuItem menuHelp = new DXMenuItem(acInfo.Resource.GetString("도움말", "TGFJ3JK4"));
                    //menuHelp.Image = ControlManager.Resource.help_browser_x16;
                    //menuHelp.Click += new EventHandler(menuHelp_Click);

                    #region 메뉴 추가


                    menu.Items.Add(menuItemColumn);

                    menuItemColumn.BeginGroup = true;


                    menu.Items.Add(menuItemShow);

                    menu.Items.Add(menuItemMethod);

                    //menu.Items.Add(menuItemStyleBox);

                    menu.Items.Add(menuItemConfig);
                    menuItemConfig.BeginGroup = true;

                    menu.Items.Add(menuItemSaveFile);
                    menuItemSaveFile.BeginGroup = true;

                    menu.Items.Add(menuItemDefaultPrint);
                    menuItemDefaultPrint.BeginGroup = true;

                    //menu.Items.Add(menuHelp);
                    //menuHelp.BeginGroup = true;
                }
                else if (hitInfo.HitInfoType == HitInfoType.RowFooter || hitInfo.HitInfoType == HitInfoType.SummaryFooter)
                {
                    acTreeListColumn acCol = (acTreeListColumn)hitInfo.Column;

                    menu.Items[0].Enabled = false;
                    menu.Items[1].Enabled = false;
                    menu.Items[2].Enabled = false;
                    menu.Items[3].Enabled = false;
                    menu.Items[4].Enabled = false;

                    menu.Items[0].Caption = acCol.Caption + " - " + menu.Items[0].Caption;
                    menu.Items[1].Caption = acCol.Caption + " - " + menu.Items[1].Caption;
                    menu.Items[2].Caption = acCol.Caption + " - " + menu.Items[2].Caption;
                    menu.Items[3].Caption = acCol.Caption + " - " + menu.Items[3].Caption;
                    menu.Items[4].Caption = acCol.Caption + " - " + menu.Items[4].Caption;


                    if (acCol.EditorType == emEditorType.TEXT)
                    {
                        RepositoryItemTextEdit editor = acCol.ColumnEdit as RepositoryItemTextEdit;

                        if (editor.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
                        {
                            menu.Items[0].Enabled = true;
                            menu.Items[1].Enabled = true;
                            menu.Items[2].Enabled = true;
                            menu.Items[3].Enabled = true;
                            menu.Items[4].Enabled = true;
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

            }


        }

        void menuItemShowColumnHeader_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowCaption = item.Checked;

        }

        void menuItemFooter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowSummaryFooter = item.Checked;
        }
        void menuItemGroupFooter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowRowFooterSummary = item.Checked;

            if (_ShowGroupFooter == true)
            {
                this.OptionsView.ShowRowFooterSummary = true;
            }
            else
            {
                this.OptionsView.ShowRowFooterSummary = false;
                //this.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            }
        }

        void menuItemShowRowNum_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowIndicator = item.Checked;

        }

        private void MenuItemGroupCollapse_Click(object sender, EventArgs e)
        {
            this.CollapseAll();
        }

        private void MenuItemGroupExpand_Click(object sender, EventArgs e)
        {
            this.ExpandAll();
        }

        void menuItemAlwaysBestFit_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this._Config.AlwaysBestFit = item.Checked;

        }

        void menuItemDefaultPrint_Click(object sender, EventArgs e)
        {
            //기본 인쇄


            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(ps);

            link.Component = this;

            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            link.CreateDocument();

            link.ShowPreview();


        }
        internal void RaiseShowPopupMenu(TreeListHitInfo hitInfo, Point pt)
        {

            TreeListHitInfo hi = this.CalcHitInfo(this.PointToClient(pt));

            if (hi.HitTest.HitInfoType == HitInfoType.Column || hi.HitTest.HitInfoType == HitInfoType.ColumnPanel)
            {
                TreeListColumnMenu columnMenu = new TreeListColumnMenu(this);

                columnMenu.Init(hi.Column);

                this.SetTreeColumnMenu(columnMenu, hi);

                columnMenu.Show(this.PointToClient(pt));
            }
            else if (hi.HitTest.HitInfoType == HitInfoType.SummaryFooter)
            {

                TreeListFooterMenu footerMenu = new TreeListFooterMenu(this);

                footerMenu.Init(hi.HitTest);

                //footerMenu.Init(hi.Column);

                this.SetTreeColumnMenu(footerMenu, hi);

                footerMenu.Show(this.PointToClient(pt));
            }

            if (hi.HitTest.InRow == true)
            {
                if (_MouseEventArgs != null)
                {
                    base.OnMouseDown(_MouseEventArgs);
                }
            }


        }


        void acTreeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == DevExpress.XtraTreeList.Menu.TreeListMenuType.Column)
            {
                e.Allow = false;
            }

            //if (e.Menu.MenuType == DevExpress.XtraTreeList.Menu.TreeListMenuType.Column)
            //{


            //    #region 기능
            //    DXSubMenuItem menuItemMethod = new DXSubMenuItem(acInfo.Resource.GetString("기능", "QS1MTC9B"));
            //    menuItemMethod.BeginGroup = true;

            //    menuItemMethod.Image = ControlManager.Resource.wand_x16;

            //    acMenuItem menuItemExpandAll = new acMenuItem(acInfo.Resource.GetString("모두 펼치기", "P1NOM5W6"));
            //    menuItemExpandAll.Image = ControlManager.Resource.arrow_expand_x16;
            //    menuItemExpandAll.Click += new EventHandler(menuItemExpandAll_Click);


            //    acMenuItem menuItemCollapseAll = new acMenuItem(acInfo.Resource.GetString("모두 접기", "1ZBDE8TU"));
            //    menuItemCollapseAll.Image = ControlManager.Resource.arrow_contract_x16;

            //    menuItemCollapseAll.Click += new EventHandler(menuItemCollapseAll_Click);

            //    menuItemMethod.Items.Add(menuItemExpandAll);
            //    menuItemMethod.Items.Add(menuItemCollapseAll);

            //    #endregion

            //    #region 파일로 저장
            //    DXSubMenuItem menuItemSaveFile = new DXSubMenuItem(acInfo.Resource.GetString("파일로 저장", "LVJVBFZF"));
            //    menuItemSaveFile.BeginGroup = true;

            //    menuItemSaveFile.Image = ControlManager.Resource.document_save;

            //    DXMenuItem menuItemToExcel = new DXMenuItem(acInfo.Resource.GetString("Microsoft Excel", "GQ52W2AQ"));
            //    menuItemToExcel.Image = ControlManager.Resource.page_excel_x16;
            //    menuItemToExcel.Click += new EventHandler(menuItemToExcel_Click);

            //    DXMenuItem menuItemToPDF = new DXMenuItem(acInfo.Resource.GetString("Adobe Acrobat PDF", "FWSGOLL9"));
            //    menuItemToPDF.Image = ControlManager.Resource.pdf;
            //    menuItemToPDF.Click += new EventHandler(menuItemToPDF_Click);

            //    DXMenuItem menuItemToText = new DXMenuItem(acInfo.Resource.GetString("텍스트 문서", "PR5RRJCW"));
            //    menuItemToText.Image = ControlManager.Resource.txt;
            //    menuItemToText.Click += new EventHandler(menuItemToText_Click);

            //    DXMenuItem menuItemToRTF = new DXMenuItem(acInfo.Resource.GetString("서식있는 텍스트(RTF)", "G2HTCWBM"));
            //    menuItemToRTF.Image = ControlManager.Resource.document;
            //    menuItemToRTF.Click += new EventHandler(menuItemToRTF_Click);

            //    DXMenuItem menuItemToHtml = new DXMenuItem(acInfo.Resource.GetString("웹문서 (html)", "JD5SEGA7"));
            //    menuItemToHtml.Image = ControlManager.Resource.html;
            //    menuItemToHtml.Click += new EventHandler(menuItemToHtml_Click);

            //    DXMenuItem menuItemToMht = new DXMenuItem(acInfo.Resource.GetString("웹페이지 보관파일 (mht)", "BWPMBX6C"));
            //    menuItemToMht.Image = ControlManager.Resource.templates;
            //    menuItemToMht.Click += new EventHandler(menuItemToMht_Click);



            //    menuItemSaveFile.Items.Add(menuItemToExcel);
            //    menuItemSaveFile.Items.Add(menuItemToPDF);
            //    menuItemSaveFile.Items.Add(menuItemToText);
            //    menuItemSaveFile.Items.Add(menuItemToRTF);
            //    menuItemSaveFile.Items.Add(menuItemToHtml);
            //    menuItemSaveFile.Items.Add(menuItemToMht);

            //    #endregion

            //    #region 사용자 컬럼
            //    DXSubMenuItem menuItemUserColumn = new DXSubMenuItem(acInfo.Resource.GetString("사용자 UI", "MVDNG5SB"));
            //    menuItemUserColumn.Image = ControlManager.Resource.color_swatchx_16;
            //    menuItemUserColumn.BeginGroup = true;

            //    DXMenuItem menuAssignConfig = new DXMenuItem(string.Format(acInfo.Resource.GetString("현재 설정된 UI - {0}", "NK9O7TO0"), this._Config.ConfigName));

            //    menuAssignConfig.Image = ControlManager.Resource.appointment;

            //    DXMenuItem menuItemConfigLoad = new DXMenuItem(acInfo.Resource.GetString("불러오기", "VO8OYFRA"));
            //    menuItemConfigLoad.Image = ControlManager.Resource.document_open;
            //    menuItemConfigLoad.Click += new EventHandler(menuItemConfigLoad_Click);

            //    DXMenuItem menuItemConfigSave = new DXMenuItem(acInfo.Resource.GetString("저장", "7NKYXFU5"));
            //    menuItemConfigSave.Image = ControlManager.Resource.document_save;
            //    menuItemConfigSave.Click += new EventHandler(menuItemConfigSave_Click);

            //    DXMenuItem menuItemConfigOtherSave = new DXMenuItem(acInfo.Resource.GetString("다른이름으로 저장", "Q8JXEI9K"));
            //    menuItemConfigOtherSave.Image = ControlManager.Resource.document_save_as;
            //    menuItemConfigOtherSave.Click += new EventHandler(menuItemConfigOtherSave_Click);


            //    DXMenuItem menuItemConfigUse = new DXMenuItem(acInfo.Resource.GetString("현재 사용자 UI을 기본으로 설정", "K913LULF"));
            //    menuItemConfigUse.Image = ControlManager.Resource.table_refresh_x16;
            //    menuItemConfigUse.Click += new EventHandler(menuItemConfigUse_Click);


            //    DXMenuItem menuItemSystemConfig = new DXMenuItem(acInfo.Resource.GetString("시스템 UI로 초기화", "7Z7GBDQ6"));
            //    menuItemSystemConfig.Image = ControlManager.Resource.layout_x16;
            //    menuItemSystemConfig.Click += new EventHandler(menuItemSystemConfig_Click);

            //    DXMenuItem menuItemConfigManager = new DXMenuItem(acInfo.Resource.GetString("관리", "0FNNF1ZT"));
            //    menuItemConfigManager.Image = ControlManager.Resource.edit_find_replace_x16;
            //    menuItemConfigManager.Click += new EventHandler(menuItemConfigManager_Click);


            //    //DXMenuItem menuItemSave = new DXMenuItem(acInfo.Resource.GetString("저장", ""));
            //    //menuItemSave.Image = ControlManager.Resource.document_save;
            //    //menuItemSave.Click += new EventHandler(menuItemSave_Click);

            //    //DXMenuItem menuItemRestore = new DXMenuItem(acInfo.Resource.GetString("불러오기", ""));
            //    //menuItemRestore.Image = ControlManager.Resource.document_open;
            //    //menuItemRestore.Click += new EventHandler(menuItemRestore_Click);

            //    //DXMenuItem menuItemInit = new DXMenuItem(acInfo.Resource.GetString("시스템 UI로 초기화", ""));
            //    //menuItemInit.Image = ControlManager.Resource.layout_x16;
            //    //menuItemInit.Click += new EventHandler(menuItemInit_Click);

            //    //현재 설정중인 사용자 UI가 존재하지않음
            //    if (string.IsNullOrEmpty(this._Config.ConfigName))
            //    {
            //        menuAssignConfig.Visible = false;
            //        menuItemConfigUse.Enabled = false;
            //        menuItemSystemConfig.Enabled = false;
            //    }


            //    menuItemUserColumn.Items.Add(menuAssignConfig);

            //    menuItemUserColumn.Items.Add(menuItemConfigLoad);

            //    menuItemUserColumn.Items.Add(menuItemConfigSave);
            //    menuItemUserColumn.Items.Add(menuItemConfigOtherSave);


            //    menuItemUserColumn.Items.Add(menuItemConfigUse);

            //    menuItemUserColumn.Items.Add(menuItemSystemConfig);

            //    menuItemUserColumn.Items.Add(menuItemConfigManager);


            //    //불러오기 ==> 팝업창
            //    //현재 UI를 기본값으로 설정


            //    //menuItemUserColumn.Items.Add(menuItemRestore);
            //    //menuItemUserColumn.Items.Add(menuItemSave);
            //    //menuItemUserColumn.Items.Add(menuItemInit);


            //    #endregion

            //    e.Menu.Items.Add(menuItemMethod);
            //    e.Menu.Items.Add(menuItemUserColumn);
            //    e.Menu.Items.Add(menuItemSaveFile);


            //}

        }

        public void SaveUserConfig()
        {
            if (this._Config.ConfigMaKer == acInfo.UserID)
            {
                //현재 적용중인 그리드UI 작성자가 본인일경우는 바로 저장된다.

                byte[] layoutData = null;
                byte[] configData = null;

                this._Config.Save(out layoutData, out configData);

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("CLASS_NAME", typeof(string));
                paramTable.Columns.Add("CONTROL_NAME", typeof(string));
                paramTable.Columns.Add("CONFIG_NAME", typeof(string));
                paramTable.Columns.Add("LAYOUT", typeof(byte[]));
                paramTable.Columns.Add("OBJECT", typeof(byte[]));
                paramTable.Columns.Add("OVERWRITE", typeof(string));


                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = this.ParentControl.Name;
                paramRow["CONTROL_NAME"] = this.Name;
                paramRow["CONFIG_NAME"] = this._Config.ConfigName;
                paramRow["LAYOUT"] = layoutData;
                paramRow["OBJECT"] = configData;
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this.ParentControl, QBiz.emExecuteType.SAVE, "CTRL",
                    "SET_USERCONFIG_SAVE2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);

            }
            else
            {
                acTreeListUserConfigSaveEditor frm = new acTreeListUserConfigSaveEditor(this);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.ShowDialog();


            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    this._Config.ConfigName = (string)e.result.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)e.result.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        acTreeListUserConfigLoadEditor _LoadConfig = null;
        //사용자 ui 불러오기
        void menuItemConfigLoad_Click(object sender, EventArgs e)
        {

            if (this._LoadConfig == null)
            {
                _LoadConfig = new acTreeListUserConfigLoadEditor(this);

                _LoadConfig.ParentControl = new Control();

                _LoadConfig.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                _LoadConfig.FormClosed += new FormClosedEventHandler(_LoadConfig_FormClosed);


                _LoadConfig.Show();

            }
            else
            {
                _LoadConfig.Focus();
            }
        }

        void menuItemConfigSave_Click(object sender, EventArgs e)
        {
            this.SaveUserConfig();

        }

        void menuItemConfigOtherSave_Click(object sender, EventArgs e)
        {
            acTreeListUserConfigSaveEditor frm = new acTreeListUserConfigSaveEditor(this);


            frm.ParentControl = new Control();

            frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

            frm.ShowDialog();


        }

        void menuItemConfigUse_Click(object sender, EventArgs e)
        {
            //기본UI로 설정


            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("CLASS_NAME");
            paramTable.Columns.Add("CONTROL_NAME");
            paramTable.Columns.Add("USE_CONFIG_NAME");
            paramTable.Columns.Add("USE_CONFIG_MAKER");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = _ParentControl.Name;
            paramRow["CONTROL_NAME"] = this.Name;
            paramRow["USE_CONFIG_NAME"] = this._Config.ConfigName;
            paramRow["USE_CONFIG_MAKER"] = this._Config.ConfigMaKer;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this._ParentControl, QBiz.emExecuteType.SAVE, "CTRL",
                "SET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "", QuickUse, QuickException);


        }

        void menuItemSystemConfig_Click(object sender, EventArgs e)
        {

            //그리드 초기화

            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("CLASS_NAME");
            paramTable.Columns.Add("CONTROL_NAME");


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = _ParentControl.Name;
            paramRow["CONTROL_NAME"] = this.Name;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this._ParentControl, QBiz.emExecuteType.SAVE, "CTRL",
            "SET_USERCONFIG_DEFAULT_USE_DEL", paramSet, "RQSTDT", "", QuickUseDel, QuickException);


            acTreeList acData = (acTreeList)this;

            this._Config.Load(null, null, acData._SystemLayout, acData._SystemConfig);


        }

        void QuickUseDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acTreeList acData = (acTreeList)this;

                this._Config.Load(null, null, acData._SystemLayout, acData._SystemConfig);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }



        private acTreeListUserConfigManager _ConfigManager = null;
        void menuItemConfigManager_Click(object sender, EventArgs e)
        {
            //사용자UI 관리

            if (_ConfigManager == null)
            {
                _ConfigManager = new acTreeListUserConfigManager(this);

                _ConfigManager.ParentControl = new Control();

                _ConfigManager.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                _ConfigManager.FormClosed += new FormClosedEventHandler(_ConfigManager_FormClosed);

                _ConfigManager.Show();

            }
            else
            {
                _ConfigManager.Focus();
            }

        }

        void _ConfigManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ConfigManager.Dispose();

            _ConfigManager = null;
        }

        void _LoadConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LoadConfig = null;
        }
        /// <summary>
        /// Mht 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToMht_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.MHT);

        }


        /// <summary>
        /// Html 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToHtml_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.HTML);


        }

        /// <summary>
        /// RTF 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToRTF_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.RTF);


        }


        /// <summary>
        /// 텍스트 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToText_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.Text);


        }

        /// <summary>
        /// PDF 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToPDF_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.PDF);

        }


        /// <summary>
        /// Excel 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToExcel_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.Excel);
        }

        void menuItemToXlsx_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QTreeListExportTo.emSaveFileType.Xlsx);
        }

        void menuItemSave_Click(object sender, EventArgs e)
        {
            this.SaveUserColumn();


        }

        void menuItemRestore_Click(object sender, EventArgs e)
        {

            this.RestoreUserColumn();

        }

        void menuItemInit_Click(object sender, EventArgs e)
        {

            this.ReSetUsercolumn();

        }

        void menuItemFixedLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.Fixed = FixedStyle.Left;
            }
            else if (item.Checked == false)
            {
                col.Fixed = FixedStyle.None;
            }

        }
        void menuItemFixedRight_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.Fixed = FixedStyle.Right;
            }
            else if (item.Checked == false)
            {
                col.Fixed = FixedStyle.None;
            }
        }

        void menuItemAlignRight_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
        }

        void menuItemAlignCenter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        void menuItemAlignLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;

        }

        void menuItemEditShowTypeDisplay_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

            Dictionary<string, object> editData = col.EditorData as Dictionary<string, object>;

            edit.DisplayMember = editData["DISPLAY_COLUMN_NAME"].ToString();

            editData["CURRENT_SHOW_COLUMN_NAME"] = edit.DisplayMember;

            this.Refresh();
        }

        void menuItemEditShowTypeValue_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acTreeListColumn col = (acTreeListColumn)item.RefObject;

            RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

            Dictionary<string, object> editData = col.EditorData as Dictionary<string, object>;


            edit.DisplayMember = editData["VALUE_COLUMN_NAME"].ToString();

            editData["CURRENT_SHOW_COLUMN_NAME"] = edit.DisplayMember;



            this.Refresh();

        }


        void menuItemAllBestFitColumns_Click(object sender, EventArgs e)
        {
            //컬럼 최적화
            this.BestFitColumns();

        }



        //void menuItemFilter_Click(object sender, EventArgs e)
        //{
        //    //빠른 필터기능

        //    acMenuItem item = (acMenuItem)sender;

        //    acTreeListColumn col = (acTreeListColumn)item.UserData;

        //    if (!_FilterEditors.ContainsKey(col.FieldName))
        //    {
        //        acGridViewFilterEditor frm = new acGridViewFilterEditor(this, col.FieldName);

        //        frm.ParentControl = new Control();

        //        frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

        //        frm.FormClosed += new FormClosedEventHandler(acGridViewFilter_FormClosed);


        //        frm.Show();

        //        _FilterEditors.Add(col.FieldName, frm);
        //    }
        //    else
        //    {
        //        _FilterEditors[col.FieldName].Focus();
        //    }


        //}

        private void SaveGridViewToFile(QTreeListExportTo.emSaveFileType saveFileType)
        {


            try
            {

                this.OptionsPrint.PrintHorzLines = this.OptionsView.ShowHorzLines;
                this.OptionsPrint.PrintVertLines = this.OptionsView.ShowVertLines;

                this.OptionsPrint.AutoWidth = false;

                this.OptionsPrint.UsePrintStyles = true;


                SaveFileDialog saveDlg = new SaveFileDialog();


                QTreeListExportTo export = new QTreeListExportTo(_ParentControl);


                saveDlg.FileName = _SaveFileName;

                switch (saveFileType)
                {
                    case QTreeListExportTo.emSaveFileType.Excel:

                        saveDlg.Filter = "Excel 97 - 2003 통합 문서 (*.xls)|*.xls";


                        break;

                    case QTreeListExportTo.emSaveFileType.Xlsx:

                        saveDlg.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx";


                        break;

                    case QTreeListExportTo.emSaveFileType.HTML:

                        saveDlg.Filter = "모든 웹페이지 (*.htm;*.html)|*.htm;*.html";


                        break;

                    case QTreeListExportTo.emSaveFileType.PDF:

                        saveDlg.Filter = "Adobe Acrobat PDF 문서(*.pdf)|*.pdf";

                        break;

                    case QTreeListExportTo.emSaveFileType.RTF:

                        saveDlg.Filter = "서식 있는 텍스트(RTF)|*.rtf";

                        break;

                    case QTreeListExportTo.emSaveFileType.Text:

                        saveDlg.Filter = "텍스트 문서(*.txt)|*.txt";

                        break;

                    case QTreeListExportTo.emSaveFileType.MHT:

                        saveDlg.Filter = "웹페이지 보관파일(*.mht)|*.mht";

                        break;

                }

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    export.ExecuteExportTo(this,
                        saveFileType,
                        saveDlg.FileName,
                        QuickExportTo);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }


        private void QuickExportTo(string fileName, TimeSpan executeTime)
        {
            //파일을 여시겠습니까?


            try
            {
                if (acMessageBox.Show(this.ParentControl, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {

                acMessageBox.Show(ex.Message, (this.ParentControl as BaseMenu).Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
        }

        void menuItemCollapseAll_Click(object sender, EventArgs e)
        {
            //모두 접기

            this.CollapseAll();
        }

        void menuItemExpandAll_Click(object sender, EventArgs e)
        {
            //모두 펼치기

            this.ExpandAll();
        }

        internal bool _IsLoadConfig = false;

        internal acTreeListUserConfig _Config = null;

        private void SaveUserColumn()
        {


            try
            {
                byte[] layoutStream = null;
                byte[] configStream = null;

                this._Config.Save(out layoutStream, out configStream);

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("CLASS_NAME", typeof(string));
                paramTable.Columns.Add("CONTROL_NAME", typeof(string));
                paramTable.Columns.Add("CONFIG_NAME", typeof(string));
                paramTable.Columns.Add("DEFAULT_USE", typeof(string));
                paramTable.Columns.Add("LAYOUT", typeof(byte[]));
                paramTable.Columns.Add("OBJECT", typeof(byte[]));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = acInfo.MenuClassName;
                paramRow["CONTROL_NAME"] = this.Name;
                paramRow["CONFIG_NAME"] = "UserColumn";
                paramRow["DEFAULT_USE"] = "1";
                paramRow["LAYOUT"] = layoutStream;
                paramRow["OBJECT"] = configStream;
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");

                acMessageBox.Show(this.ParentControl, "저장되었습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }


        private void RestoreUserColumn()
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");
                paramTable.Columns.Add("CONFIG_NAME");

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = acInfo.MenuClassName;
                paramRow["CONTROL_NAME"] = this.Name;    // this.Name;
                paramRow["CONFIG_NAME"] = "UserColumn";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");


                if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
                {
                    DataRow configRow = dsResult.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = null;
                    byte[] configBuffer = null;

                    if (configRow["LAYOUT"] != null) layoutBuffer = (byte[])configRow["LAYOUT"];
                    if (configRow["OBJECT"] != null) configBuffer = (byte[])configRow["OBJECT"];


                    this._Config.Restore(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                }
                else
                {
                    acMessageBox.Show(this.ParentControl, "저장된 정보가 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
            catch
            {

            }
        }

        private void ReSetUsercolumn()
        {
            try
            {

                this._Config.Restore(null, null, this._SystemLayout, this._SystemConfig);

            }
            catch
            {

            }
        }

        protected override DevExpress.XtraTreeList.Data.TreeListData CreateData()
        {
            if (this.DataSource != null)
            {
                _DeleteData = ((DataTable)this.DataSource).Clone();

                ((DataTable)this.DataSource).RowDeleting += new DataRowChangeEventHandler(acTreeList_RowDeleting);

                ((DataTable)this.DataSource).RowChanging += new DataRowChangeEventHandler(acTreeList_RowChanging);



            }

            return base.CreateData();
        }

        void acTreeList_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            if (this.ChangeDataSource != null)
            {
                this.ChangeDataSource();
            }


        }

        void acTreeList_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            DataRow delRow = _DeleteData.NewRow();

            delRow.ItemArray = e.Row.ItemArray;

            _DeleteData.Rows.Add(delRow);

            if (this.ChangeDataSource != null)
            {
                this.ChangeDataSource();
            }

        }

        private DataTable _DeleteData = null;


        /// <summary>
        /// 변경되거나 삭제행을 모두 커밋합니다.
        /// </summary>
        public void AcceptChanges()
        {
            ((DataTable)this.DataSource).AcceptChanges();

            _DeleteData.Clear();
        }


        /// <summary>
        /// 삭제된 행을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeleteRows()
        {

            return _DeleteData;
        }

        /// <summary>
        /// 추가되거나 수정된 행을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAddModifyRows()
        {
            DataTable data = (DataTable)this.DataSource;

            DataTable addModifyTable = data.Clone();

            foreach (DataRow row in data.Rows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    DataRow newRow = addModifyTable.NewRow();

                    newRow.ItemArray = row.ItemArray;

                    addModifyTable.Rows.Add(newRow);
                }
            }

            return addModifyTable;


        }

        /// <summary>
        /// KeyColumn에 매칭되는 Row를 수정한다.
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="notFindAdd">찾을수없을때 추가할지여부</param>
        public void UpdateMapingRow(DataRow row, bool notFindAdd)
        {

            try
            {
                this.ConvertColumnType(row.Table);

                DataTable treeListData = (DataTable)this.DataSource;

                treeListData.AcceptChanges();

                bool isFindRow = false;


                int cnt = 0;

                foreach (DataRow treeListRow in treeListData.Rows)
                {

                    if (treeListRow[this.KeyFieldName].Equals(row[this.KeyFieldName]))
                    {
                        isFindRow = true;

                        break;

                    }

                    ++cnt;

                }


                if (isFindRow == true)
                {

                    foreach (DataColumn col in row.Table.Columns)
                    {

                        treeListData.Rows[cnt][col.ColumnName] = row[col.ColumnName];

                    }

                    return;
                }

                if (notFindAdd == true)
                {
                    this.AddRow(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Row를 추가한다.
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(DataRow row)
        {

            this.AppendNode(row, this.FindMappingNode(row[this.ParentFieldName]));

        }


        /// <summary>
        /// KeyColumn에 매칭되는 Row를 삭제한다.
        /// </summary>
        /// <param name="row"></param>
        public object DeleteMappingRow(DataRow row)
        {

            TreeListNode mappingNode = this.FindMappingNode(row[this.KeyFieldName]);

            if (mappingNode != null)
            {
                DataRow nodeRow = ((DataRowView)this.GetDataRecordByNode(mappingNode)).Row;

                this.DeleteNode(mappingNode);

                return nodeRow;
            }

            return null;

        }


        private TreeListNode FindMappingNode(object key)
        {
            foreach (TreeListNode node in this.Nodes)
            {

                TreeListNode getNode = null;

                this._FindMappingNode(node, key, ref getNode);

                if (getNode != null)
                {
                    return getNode;
                }

            }

            return null;

        }

        private void _FindMappingNode(TreeListNode node, object key, ref TreeListNode getNode)
        {

            DataRowView nodeData = (DataRowView)this.GetDataRecordByNode(node);

            if (nodeData[this.KeyFieldName].Equals(key))
            {
                getNode = node;
            }

            if (node.Nodes.Count != 0)
            {
                foreach (TreeListNode childNode in node.Nodes)
                {
                    this._FindMappingNode(childNode, key, ref getNode);
                }
            }

        }






        public enum emTextEditMask
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 수량
            /// </summary>
            QTY,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,

            /// <summary>
            /// 무게 소수점 3자리
            /// </summary>
            WEIGHT_F3,
            /// <summary>
            /// 퍼센트 소수점 둘째자리
            /// </summary>
            PER2,

            /// <summary>
            /// 공수(시간)
            /// </summary>
            TIME,

            /// <summary>
            /// 총일자
            /// </summary>
            TOTAL_DAYS,

            /// <summary>
            /// 짧은 날짜
            /// </summary>
            SHORT_DATE_STRING,

            /// <summary>
            /// 긴 날짜
            /// </summary>
            LONG_DATAE_STRING,

            /// <summary>
            /// 코드
            /// </summary>
            CODE,

            /// <summary>
            /// 숫자
            /// </summary>
            NUMBER,

            /// <summary>
            /// 소수점 첫자리
            /// </summary>
            F1,

            /// <summary>
            /// 소수점 둘째자리
            /// </summary>
            F2,

            /// <summary>
            /// 소수점 셋째자리
            /// </summary>
            F3,

            /// <summary>
            /// 소수점 넷째자리
            /// </summary>
            F4


        };

        public enum emEditorType
        {
            NONE,

            TEXT,

            CHECK,

            DATE,

            PICTURE,

            LOOKUP,

            COLOR,

            BUTTON

        }

        internal DataTable _DefaultTable = null;


        protected override TreeListColumnCollection CreateColumns()
        {
            return new acTreeListColumnCollection(this);
        }

        public void Clear()
        {
            _DefaultTable.Columns.Clear();

            this.Columns.Clear();

            this.DataSource = _DefaultTable;
        }

        /// <summary>
        /// 설정된 컬럼를 삭제한다.
        /// </summary>
        /// <param name="column"></param>
        public void RemoveColumn(string column)
        {
            if (this._DefaultTable.Columns.Contains(column))
            {
                this._DefaultTable.Columns.Remove(column);
            }


            this.Columns.Remove(this.Columns[column]);

        }

        public void AddColorEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;


            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.COLOR;


            RepositoryItemColorEdit colorEdit = new RepositoryItemColorEdit();

            if (allowEdit == false)
            {
                colorEdit.Buttons.Clear();
            }

            colorEdit.StoreColorAsInteger = true;

            colorEdit.ColorAlignment = align;

            col.ColumnEdit = colorEdit;

            _DefaultTable.Columns.Add(columnName, typeof(int));

            this.Columns.AddRange(new TreeListColumn[] { col });

        }


        /// <summary>
        /// TextEdit 형태의 컬럼을 추가합니다.
        /// </summary>
        /// <param name="columnName">컬럼명</param>
        /// <param name="caption">캡션</param>
        /// <param name="resourceID">리소스아이디</param>
        /// <param name="align">정렬형태</param>
        /// <param name="allowEdit">에디트여부</param>
        /// <param name="visible">보여줄지여부</param>
        /// <param name="mask">마스크</param>
        public void AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, emTextEditMask mask)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }


            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.TEXT;

            RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

            col.ColumnEdit = textEditItem;

            textEditItem.Mask.UseMaskAsDisplayFormat = true;

            switch (mask)
            {
                case emTextEditMask.NONE:

                    _DefaultTable.Columns.Add(columnName);

                    break;

                case emTextEditMask.QTY:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "N0";


                    break;

                case emTextEditMask.MONEY:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MONEY");


                    break;

                case emTextEditMask.WEIGHT:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;
                case emTextEditMask.WEIGHT_F3:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F3";


                    break;

                case emTextEditMask.PER2:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "p2";


                    break;


                case emTextEditMask.TOTAL_DAYS:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;

                case emTextEditMask.TIME:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;

                case emTextEditMask.SHORT_DATE_STRING:

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    textEditItem.Mask.EditMask = "9999-99-99";


                    break;

                case emTextEditMask.LONG_DATAE_STRING:

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    textEditItem.Mask.EditMask = "9999-99-99 99:99:99";


                    break;

                case emTextEditMask.CODE:


                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                    textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_CODE_TYPE");

                    break;


                case emTextEditMask.NUMBER:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "d";

                    break;


                case emTextEditMask.F1:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n1";

                    break;

                case emTextEditMask.F2:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n2";

                    break;

                case emTextEditMask.F3:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n3";

                    break;

                case emTextEditMask.F4:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n4";

                    break;

            }



            this.Columns.AddRange(new TreeListColumn[] { col });


        }

        public void AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, emTextEditMask mask, bool isRequired)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }


            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.IsRequired = isRequired;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.TEXT;

            RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

            col.ColumnEdit = textEditItem;

            textEditItem.Mask.UseMaskAsDisplayFormat = true;

            switch (mask)
            {
                case emTextEditMask.NONE:

                    _DefaultTable.Columns.Add(columnName);

                    break;

                case emTextEditMask.QTY:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "N0";


                    break;

                case emTextEditMask.MONEY:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MONEY");


                    break;

                case emTextEditMask.WEIGHT:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;
                case emTextEditMask.WEIGHT_F3:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F3";


                    break;

                case emTextEditMask.PER2:

                    _DefaultTable.Columns.Add(columnName, typeof(double));


                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "p2";


                    break;


                case emTextEditMask.TOTAL_DAYS:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;

                case emTextEditMask.TIME:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    textEditItem.Mask.EditMask = "F2";


                    break;

                case emTextEditMask.SHORT_DATE_STRING:

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    textEditItem.Mask.EditMask = "9999-99-99";


                    break;

                case emTextEditMask.LONG_DATAE_STRING:

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    textEditItem.Mask.EditMask = "9999-99-99 99:99:99";


                    break;

                case emTextEditMask.CODE:


                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                    textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_CODE_TYPE");

                    break;


                case emTextEditMask.NUMBER:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "d";

                    break;


                case emTextEditMask.F1:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n1";

                    break;

                case emTextEditMask.F2:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n2";

                    break;

                case emTextEditMask.F3:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n3";

                    break;

                case emTextEditMask.F4:

                    _DefaultTable.Columns.Add(columnName, typeof(decimal));

                    textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                    textEditItem.Mask.EditMask = "n4";

                    break;

            }



            this.Columns.AddRange(new TreeListColumn[] { col });


        }


        public void AddDateEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, emDateMask dateMask)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;

            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }





            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.DATE;


            _DefaultTable.Columns.Add(columnName, typeof(DateTime));

            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();

            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;


            switch (dateMask)
            {
                case emDateMask.MONTH_DATE:

                    dateEdit.Mask.EditMask = "yyyy-MM";

                    break;


                case emDateMask.SHORT_DATE:

                    dateEdit.Mask.EditMask = "d";

                    break;

                case emDateMask.MEDIUM_DATE:

                    dateEdit.Mask.EditMask = "g";

                    break;

                case emDateMask.LONG_DATE:

                    dateEdit.Mask.EditMask = "G";

                    break;
            }



            dateEdit.Mask.UseMaskAsDisplayFormat = true;

            dateEdit.Appearance.TextOptions.HAlignment = align;

            dateEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = dateEdit;


            this.Columns.AddRange(new TreeListColumn[] { col });
        }




        public void AddHidden(string columnName, Type dataType)
        {
            _DefaultTable.Columns.Add(columnName, dataType);

        }

        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible,
    DataTable data, string displayColumnName, string valueColumnName, bool isShowValue)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }


            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;


            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = displayColumnName;
            displayColumnInfo.Caption = displayColumnName;

            valueColumnInfo.FieldName = valueColumnName;
            valueColumnInfo.Caption = valueColumnName;

            valueColumnInfo.Visible = isShowValue;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);

            lookupEdit.DataSource = data;

            lookupEdit.DisplayMember = displayColumnName;

            lookupEdit.ValueMember = valueColumnName;

            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.AddRange(new TreeListColumn[] { col });


        }


        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible,
string catCode, bool isShowValue)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }


            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "CD_NAME";
            displayColumnInfo.Caption = "CD_NAME";

            valueColumnInfo.FieldName = "CD_CODE";
            valueColumnInfo.Caption = "CD_CODE";

            valueColumnInfo.Visible = isShowValue;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);



            lookupEdit.DataSource = acInfo.StdCodes.GetCatTable(catCode);

            lookupEdit.DisplayMember = "CD_NAME";

            lookupEdit.ValueMember = "CD_CODE";

            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.AddRange(new TreeListColumn[] { col });


        }


        public void AddLookUpVendor(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            Dictionary<string, object> editorData = new Dictionary<string, object>();

            col.EditorData = editorData;

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();

            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();





            displayColumnInfo.FieldName = "VEN_NAME";
            displayColumnInfo.Caption = "VEN_NAME";

            valueColumnInfo.FieldName = "VEN_CODE";
            valueColumnInfo.Caption = "VEN_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "VEN_NAME";

            lookupEdit.ValueMember = "VEN_CODE";


            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.AddRange(new TreeListColumn[] { col });

        }


        public void AddLookUpProc(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            Dictionary<string, object> editorData = new Dictionary<string, object>();

            col.EditorData = editorData;

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();

            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "PROC_NAME";
            displayColumnInfo.Caption = "PROC_NAME";

            valueColumnInfo.FieldName = "PROC_CODE";
            valueColumnInfo.Caption = "PROC_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("DATA_FLAG");

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["DATA_FLAG"] = "0";

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_PROC_SEARCH", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "PROC_NAME";

            lookupEdit.ValueMember = "PROC_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.AddRange(new TreeListColumn[] { col });

        }

        void lookupEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.EditingValue = DBNull.Value;
            }
        }

        public void AddPictrue(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;


            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.PICTURE;


            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();

            pictureEdit.AllowFocused = false;

            col.ColumnEdit = pictureEdit;

            _DefaultTable.Columns.Add(columnName, typeof(System.Drawing.Bitmap));

            this.Columns.AddRange(new TreeListColumn[] { col });
        }

        public enum emCheckEditDataType { _BOOL, _STRING, _INT, _BYTE };

        public void AddCheckEdit(string columnName, string caption, string resourceID, bool useReSourceID, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }




            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.EditorType = emEditorType.CHECK;
            col.EditorData = chekEditDataType;

            col.OptionsColumn.AllowSort = false;

            RepositoryItemCheckEdit checkItemEdit = new RepositoryItemCheckEdit();

            checkItemEdit.NullStyle = StyleIndeterminate.Unchecked;


            switch (chekEditDataType)
            {
                case emCheckEditDataType._BOOL:

                    checkItemEdit.ValueChecked = true;
                    checkItemEdit.ValueUnchecked = false;

                    _DefaultTable.Columns.Add(columnName, typeof(bool));

                    break;

                case emCheckEditDataType._INT:

                    checkItemEdit.ValueChecked = 1;
                    checkItemEdit.ValueUnchecked = 0;

                    _DefaultTable.Columns.Add(columnName, typeof(int));


                    break;

                case emCheckEditDataType._BYTE:

                    checkItemEdit.ValueChecked = (byte)1;
                    checkItemEdit.ValueUnchecked = (byte)0;

                    _DefaultTable.Columns.Add(columnName, typeof(byte));


                    break;

                case emCheckEditDataType._STRING:

                    checkItemEdit.ValueChecked = "1";
                    checkItemEdit.ValueUnchecked = "0";

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    break;



            }

            col.ColumnEdit = checkItemEdit;

            this.Columns.AddRange(new TreeListColumn[] { col });

        }


        public void AddMemoEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }


            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }


            if (allowEdit)
            {
                //    col.AppearanceCell.BackColor = acInfo.RequiredBackColor;
                //    col.AppearanceCell.ForeColor = acInfo.RequiredForeColor;
                //    col.AppearanceCell.Options.UseBackColor = true;

            }
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.TEXT;

            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();

            //memoEdit.EditValueChanging += new ChangingEventHandler(memoEdit_EditValueChanging);

            memoEdit.Appearance.TextOptions.HAlignment = align;
            memoEdit.Appearance.TextOptions.VAlignment = VertAlignment.Center;

            memoEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = memoEdit;


            this.Columns.AddRange(new TreeListColumn[] { col });


        }


        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired)
        {
            acTreeListColumn col = new acTreeListColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;

            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;


            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            if (allowEdit)
            {
                //col.AppearanceCell.BackColor = acInfo.RequiredBackColor;
                //col.AppearanceCell.ForeColor = acInfo.RequiredForeColor;
                //col.AppearanceCell.Options.UseBackColor = true;

            }

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;



            col.EditorType = emEditorType.BUTTON;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();

            if (btnEdit.Buttons.Count == 1)
            {
                btnEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
                btnEdit.Buttons[0].Caption = caption;
                btnEdit.Buttons[0].ToolTip = caption;
            }

            btnEdit.TextEditStyle = textEditStyle;

            btnEdit.Mask.UseMaskAsDisplayFormat = true;

            btnEdit.Appearance.TextOptions.HAlignment = align;

            btnEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = btnEdit;

            this.Columns.AddRange(new TreeListColumn[] { col });
        }

    }
}
