using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Data.Common;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Menu;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Reflection;
using System.Linq;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraEditors.ViewInfo;
using BizManager;
using System.Globalization;
using System.Text.RegularExpressions;
//using DevExpress.XtraRichEdit;
using DevExpress.XtraEditors.Popup;

namespace ControlManager
{
    public class acGridColumnCollection : GridColumnCollection
    {
        public acGridColumnCollection(ColumnView view) : base(view) { }

        protected override GridColumn CreateColumn()
        {
            return new acGridColumn();
        }
    }


    public class acGridColumn : DevExpress.XtraGrid.Columns.GridColumn, IBaseViewControl
    {


        public acGridColumn()
            : base()
        {

        }


        /// <summary>
        /// 유효성을 확인한다.
        /// </summary>
        public bool Check()
        {
            switch (this._EditorType)
            {

                case acGridView.emEditorType.NONE:
                    {
                        return true;


                    }

                case acGridView.emEditorType.BUTTON:
                    {

                        return true;


                    }

                case acGridView.emEditorType.COLOR:
                    {
                        return true;


                    }


                case acGridView.emEditorType.CUSTOM:
                    {
                        return true;


                    }

                case acGridView.emEditorType.LOOKUP:
                    {
                        if (this._EditorData is Dictionary<string, object>)
                        {
                            Dictionary<string, object> editData = this._EditorData as Dictionary<string, object>;

                            string[] keys = new string[] {
                                "DISPLAY_COLUMN_NAME", 
                                "VALUE_COLUMN_NAME",
                                "CURRENT_SHOW_COLUMN_NAME",
                                "DATASOURCE"
                            };

                            foreach (string key in keys)
                            {
                                if (!editData.ContainsKey(key))
                                {
                                    return false;
                                }

                            }

                            return true;

                        }

                        return false;


                    }

                case acGridView.emEditorType.LOOKUP_CODE:
                    {

                        if (this._EditorData is Dictionary<string, object>)
                        {
                            Dictionary<string, object> editData = this._EditorData as Dictionary<string, object>;

                            string[] keys = new string[] {
                                "DISPLAY_COLUMN_NAME", 
                                "VALUE_COLUMN_NAME",
                                "CURRENT_SHOW_COLUMN_NAME",
                                "DATASOURCE",
                                "CAT_CODE"
                            };

                            foreach (string key in keys)
                            {
                                if (!editData.ContainsKey(key))
                                {
                                    return false;
                                }

                            }

                            return true;

                        }

                        return false;



                    }

                case acGridView.emEditorType.MEMO:
                    {
                        return true;


                    }

                case acGridView.emEditorType.PICTURE:
                    {
                        return true;


                    }

                case acGridView.emEditorType.PROGRESSBAR:
                    {
                        return true;


                    }
                case acGridView.emEditorType.TIME:
                    {
                        return true;


                    }

                case acGridView.emEditorType.TEXT:
                    {
                        if (this._EditorData is ControlManager.acGridView.emTextEditMask)
                        {
                            return true;
                        }

                        break;
                    }

                case acGridView.emEditorType.CHECK:
                    {

                        if (this._EditorData is ControlManager.acGridView.emCheckEditDataType)
                        {
                            return true;
                        }

                        break;
                    }

                case acGridView.emEditorType.DATE:
                    {
                        if (this._EditorData is ControlManager.acGridView.emDateMask)
                        {
                            return true;
                        }

                        break;

                    }

                case acGridView.emEditorType.DATE_STRING:
                    {

                        if (this._EditorData is string)
                        {
                            return true;
                        }

                        break;
                    }

                case acGridView.emEditorType.RADIO_GROUP:
                    {

                        return true;

                        break;
                    }



            }

            return false;

        }
        

        private acGridView.emEditorType _EditorType = acGridView.emEditorType.NONE;

        public acGridView.emEditorType EditorType
        {
            get { return _EditorType; }
            set { _EditorType = value; }
        }

        private object _EditorData = null;

        public object EditorData
        {
            get { return _EditorData; }
            set { _EditorData = value; }
        }

        private bool _IsRequired = false;

        public bool IsRequired
        {
            get { return _IsRequired; }
            set { _IsRequired = value; }
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


    public class acGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "acGridView"; } }

        public override BaseView CreateView(GridControl grid)
        {
            return new acGridView(grid as GridControl);
        }
        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new acGridViewInfo(view as acGridView);
        }
    }

    public class acGridViewInfo : GridViewInfo
    {
        public acGridViewInfo(DevExpress.XtraGrid.Views.Grid.GridView gridView)
            : base(gridView)
        {

        }

    }

    public class acGridControl : GridControl, IControl
    {
        private bool _IsCustomReportExcel = false;

        public bool IsCustomReportExcel { get => _IsCustomReportExcel; set => _IsCustomReportExcel = value; }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WIN32API.WM_CONTEXTMENU)
            {
                Point pt = new Point(m.LParam.ToInt32());

                Point cpt = this.PointToClient(pt);

                acGridView view = (acGridView)this.MainView;

                GridHitInfo hitInfo = view.CalcHitInfo(this.PointToClient(pt));


                view.RaiseShowGridPopupMenu(hitInfo, pt);

            }

            base.WndProc(ref m);
        }


        private DevExpress.XtraBars.BarManager _DefaultBarManager = null;


        private System.Windows.Forms.Timer _VisibleTimer = null;

        public acGridControl()
            : base()
        {

            this._VisibleTimer = new System.Windows.Forms.Timer();

            this._VisibleTimer.Interval = 100;

            if (acInfo.IsRunTime == true)
            {
                this._DefaultBarManager = new DevExpress.XtraBars.BarManager();

                this._DefaultBarManager.AllowCustomization = false;
                this._DefaultBarManager.AllowQuickCustomization = false;
                this._DefaultBarManager.AllowShowToolbarsPopup = false;
                this._DefaultBarManager.CloseButtonAffectAllTabs = false;
                this._DefaultBarManager.ShowFullMenusAfterDelay = false;
                this._DefaultBarManager.ShowFullMenus = true;


                this._DefaultBarManager.Form = this;


                this.MenuManager = this._DefaultBarManager as DevExpress.Utils.Menu.IDXMenuManager;

            }



            this.ProcessGridKey += new KeyEventHandler(acGridControl_ProcessGridKey);

            this.HandleDestroyed += new EventHandler(acGridControl_HandleDestroyed);


            this.VisibleChanged += new EventHandler(acGridControl_VisibleChanged);


            this._VisibleTimer.Tick += new EventHandler(VisibleTimer_Tick);

            try
            {
                SetFocusRowBorderPen = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_COLOR").isNullOrEmpty() ? Pens.Transparent : new Pen(acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_COLOR").toColor());
                SetFocusRowBorderPen.Width = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_HEIGHT").isNumeric() ? acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_HEIGHT").toInt() : 1;

                string sDashStyle = string.Empty;
                sDashStyle = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_STYLE");


                switch (sDashStyle)
                {
                    case "Dash":
                        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        break;
                    case "Dot":
                        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        break;
                    case "DashDot":
                        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        break;
                    case "Solid":
                        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                    case "DashDotDot":
                        SetFocusRowBorderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        break;
                }

                FocusRowBorderPenUse = acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_USE").isNullOrEmpty() ? false : acInfo.SysConfig.GetSysConfigByMemory("GRID_FOCUS_BORDER_USE").ToString() == "1" ? true : false;
                this.Paint += acGridControl_Paint;
            }
            catch { }
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        public Pen SetFocusRowBorderPen = Pens.Transparent;
        public bool FocusRowBorderPenUse = false;
        private void acGridControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (FocusRowBorderPenUse)
                {
                    GridControl grid = sender as GridControl;
                    GridView view = grid.FocusedView as GridView;
                    GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
                    GridRowInfo rowInfo = viewInfo.GetGridRowInfo(view.FocusedRowHandle);
                    if (rowInfo == null)
                        return;
                    Rectangle r = Rectangle.Empty;
                    r = rowInfo.Bounds;
                    if (r != Rectangle.Empty)
                    {
                        r.Height -= 2;
                        r.Width -= 2;
                        e.Graphics.DrawRectangle(SetFocusRowBorderPen, r);
                    }
                }
            }
            catch { }
        }

        private bool _InitLayout = false;


        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            acGridView view = this.MainView as acGridView;
            if (view != null
                && view.ParentControl == null)
            {
                view.ParentControl = this.GetContainerControl() as Control;
            }
        }


        void acGridControl_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible == true)
            {
                //보일때는 서브윈도우를 숨긴 창들을 표시

                acGridView view = (acGridView)this.MainView;


                if (view != null)
                {
                    //최초 한번만 실행


                    if (ControlManager.acInfo.IsRunTime == true)
                    {
                        if (this._InitLayout == false)
                        {


                            #region 시스템 UI 저장

                            acGridViewConfig systemConfig = new acGridViewConfig(view);

                            systemConfig.Save(out _SystemLayout, out _SystemConfig);

                            #endregion


                            if (view._IsLoadConfig == true)
                            {
                                DataTable paramTable = new DataTable("RQSTDT");
                                paramTable.Columns.Add("PLT_CODE");
                                paramTable.Columns.Add("EMP_CODE");
                                paramTable.Columns.Add("CLASS_NAME");
                                paramTable.Columns.Add("CONTROL_NAME");

                                DataRow paramRow = paramTable.NewRow();
                                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                paramRow["EMP_CODE"] = acInfo.UserID;
                                paramRow["CLASS_NAME"] = view.ParentControl.Name;
                                paramRow["CONTROL_NAME"] = view.Name;

                                paramTable.Rows.Add(paramRow);

                                DataSet paramSet = new DataSet();
                                paramSet.Tables.Add(paramTable);

                                //DataSet dsRslt =  BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

                                //if (dsRslt != null) QuickUse(dsRslt);
                                BizRun.QBizRun.ExecuteService(view.ParentControl, QBiz.emExecuteType.NONE, "CTRL",
                                "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT", QuickUse, QuickException);

                            }
                            else
                            {
                                GetLoadUserCustomReport();
                            }

                            if (base.DataSource == null)
                            {
                                view.DefaultTable.TableName = this.DefaultView.Name;

                                base.DataSource = view.DefaultTable;
                            }


                            this._InitLayout = true;

                            view.RaiseInitLayout();


                        }
                    }



                    view.ShowSubWindows();




                }


                this._VisibleTimer.Start();
            }

        }

        public void GetLoadUserCustomReport()
        {
            try
            {
                acGridView view = (acGridView)this.MainView;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = view.ParentControl.Name;
                paramRow["CONTROL_NAME"] = view.Name;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //DataSet dsRslt =  BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

                //if (dsRslt != null) QuickUse(dsRslt);
                BizRun.QBizRun.ExecuteService(view.ParentControl, QBiz.emExecuteType.NONE, "CTRL",
                "GET_USER_USED_CUSTOM_EXCEL", paramSet, "RQSTDT", "RSLTDT", QuickUseCustomExcel, QuickException);
            }
            catch
            {

            }
        }


        void VisibleTimer_Tick(object sender, EventArgs e)
        {

            if (this.Visible == false)
            {
                //보이지않을때는 서브윈도우를 모두 숨긴다.

                acGridView view = (acGridView)this.MainView;

                if (view != null)
                {

                    view.HideSubWindows();

                }

                this._VisibleTimer.Stop();
            }


        }



        void acGridControl_HandleDestroyed(object sender, EventArgs e)
        {
            if (ControlManager.acInfo.IsRunTime == true)
            {
                acGridView view = (acGridView)this.MainView;

                view.Dispose();
            }
        }



        internal byte[] _SystemLayout = null;

        internal byte[] _SystemConfig = null;

        internal int _OldFocusRowHandle = 0;

        internal object _OldDatasource = null;


        public DataTable ConvertDataSource(DataTable dt)
        {
            DataTable temp = (DataTable)dt;

            acGridView view = (acGridView)this.MainView;

            if (temp != null)
            {
                Dictionary<string, Type> list = new Dictionary<string, Type>();

                //변환된 데이터형태 정의

                foreach (acGridColumn col in view.Columns)
                {

                    if (col.EditorType == acGridView.emEditorType.DATE)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acGridView.emEditorType.DATE_STRING)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acGridView.emEditorType.LOOKUP_CODE)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(string))
                            {

                                list.Add(col.FieldName, typeof(string));

                            }
                        }
                    }


                }


                foreach (KeyValuePair<string, Type> col in list)
                {
                    temp.Columns.Add(col.Key + "_temp", Type.GetType(col.Value.FullName));
                }


                //그리드 행 순번
                int rowSeq = 0;

                if (!temp.Columns.Contains("GRID_ROW_SEQ"))
                {
                    temp.Columns.Add("GRID_ROW_SEQ", typeof(int));
                }


                foreach (DataRow tempRow in temp.Rows)
                {
                    tempRow["GRID_ROW_SEQ"] = rowSeq;

                    //컬럼 데이터 형태 변환

                    foreach (KeyValuePair<string, Type> col in list)
                    {
                        if (Type.GetType(col.Value.FullName) == typeof(DateTime))
                        {
                            tempRow[col.Key + "_temp"] = tempRow[col.Key].isNull() ? (object)DBNull.Value : (object)tempRow[col.Key].toDateTime();
                        }
                        else if (Type.GetType(col.Value.FullName) == typeof(string))
                        {
                            tempRow[col.Key + "_temp"] = tempRow[col.Key].toStringNull();
                        }

                    }


                    ++rowSeq;
                }


                //임시 컬럼 삭제

                foreach (KeyValuePair<string, Type> col in list)
                {
                    temp.Columns.Remove(col.Key);
                    temp.Columns[col.Key + "_temp"].ColumnName = col.Key;

                }




                temp.AcceptChanges();

            }

            return temp;
        }

        public override object DataSource
        {


            get
            {
                return base.DataSource;
            }
            set
            {


                acGridView view = (acGridView)this.MainView;

                //if (view._unraiseDSChanged) return;

                view._AllCheked = false;


                _OldFocusRowHandle = view.FocusedRowHandle;

                bool enableAppearanceFocusedCell = view.OptionsSelection.EnableAppearanceFocusedCell;
                bool enableAppearanceFocusedRow = view.OptionsSelection.EnableAppearanceFocusedRow;
                bool enableAppearanceHideSelection = view.OptionsSelection.EnableAppearanceHideSelection;


                view.OptionsSelection.EnableAppearanceFocusedCell = false;
                view.OptionsSelection.EnableAppearanceFocusedRow = false;
                view.OptionsSelection.EnableAppearanceHideSelection = false;


                DrawFocusRectStyle focusRectStyle = view.FocusRectStyle;

                view.FocusRectStyle = DrawFocusRectStyle.None;

                //this.Enabled = false;


                #region 데이터 변환

                DataTable temp = (DataTable)value;



                if (temp != null)
                {
                    Dictionary<string, Type> list = new Dictionary<string, Type>();

                    //변환된 데이터형태 정의

                    foreach (acGridColumn col in view.Columns)
                    {

                        if (col.EditorType == acGridView.emEditorType.DATE)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acGridView.emEditorType.DATE_STRING)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acGridView.emEditorType.LOOKUP_CODE)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(string))
                                {

                                    list.Add(col.FieldName, typeof(string));

                                }
                            }
                        }


                    }


                    foreach (KeyValuePair<string, Type> col in list)
                    {
                        temp.Columns.Add(col.Key + "_temp", Type.GetType(col.Value.FullName));
                    }


                    //그리드 행 순번
                    int rowSeq = 0;

                    if (!temp.Columns.Contains("GRID_ROW_SEQ"))
                    {
                        temp.Columns.Add("GRID_ROW_SEQ", typeof(int));
                    }


                    foreach (DataRow tempRow in temp.Rows)
                    {
                        if (tempRow.RowState.Equals(DataRowState.Deleted)) continue;

                        tempRow["GRID_ROW_SEQ"] = rowSeq;

                        //컬럼 데이터 형태 변환

                        foreach (KeyValuePair<string, Type> col in list)
                        {
                            if (Type.GetType(col.Value.FullName) == typeof(DateTime))
                            {
                                tempRow[col.Key + "_temp"] = tempRow[col.Key].isNull() ? (object)DBNull.Value : (object)tempRow[col.Key].toDateTime();
                            }
                            else if (Type.GetType(col.Value.FullName) == typeof(string))
                            {
                                tempRow[col.Key + "_temp"] = tempRow[col.Key].toStringNull();
                            }

                        }


                        ++rowSeq;
                    }


                    //임시 컬럼 삭제

                    foreach (KeyValuePair<string, Type> col in list)
                    {
                        temp.Columns.Remove(col.Key);
                        temp.Columns[col.Key + "_temp"].ColumnName = col.Key;

                    }




                    temp.AcceptChanges();

                }

                #endregion


                base.DataSource = temp;


                if (base.DataSource != null)
                {
                    _OldDatasource = ((DataTable)base.DataSource).Copy();
                }
                else
                {
                    _OldDatasource = null;

                }





                //this.Enabled = true;


                view.OptionsSelection.EnableAppearanceFocusedCell = enableAppearanceFocusedCell;
                view.OptionsSelection.EnableAppearanceFocusedRow = enableAppearanceFocusedRow;
                view.OptionsSelection.EnableAppearanceHideSelection = enableAppearanceHideSelection;


                view.FocusRectStyle = focusRectStyle;

                if (view._Config != null)
                {

                    if (view._Config.AlwaysBestFit == true)
                    {
                        view.BestFitColumnsThread();
                    }
                }


            }
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


        void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            acGridView view = (acGridView)this.MainView;

            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    view._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);



                }

                foreach (DataRow row in e.result.Tables["RSLTDT_REPORT"].Rows)
                {
                    view._CustomReportCusID = row["CUS_ID"].toStringEmpty();
                    view._CustomReportCusName = row["FILE_NAME"].toStringEmpty();
                }

                if(e.result.Tables["RSLTDT_REPORT"].Rows.Count ==0)
                {
                    view._CustomReportCusID = null;
                    view._CustomReportCusName = null;
                }
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
                        (((acGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                         (((acGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {

                    acMessageBox.Show(view.ParentControl, ex);
                }
            }


        }
        void QuickUseCustomExcel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            acGridView view = (acGridView)this.MainView;

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    view._CustomReportCusID = row["CUS_ID"].toStringEmpty();
                    view._CustomReportCusName = row["FILE_NAME"].toStringEmpty();
                }

                if(e.result.Tables["RSLTDT"].Rows.Count ==0)
                {
                    view._CustomReportCusID = null;
                    view._CustomReportCusName = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(view.ParentControl, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acGridView view = (acGridView)this.MainView;

            acMessageBox.Show(view.ParentControl, ex);
        }


        //void QuickUse(object sender, QBiz qBiz, QBizr.ExcuteCompleteArgs e)
        //{

        //    acGridView view = (acGridView)this.MainView;

        //    try
        //    {

        //        if (e.result.Tables["RSLTDT"].Rows.Count != 0)
        //        {
        //            DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

        //            byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
        //            byte[] configBuffer = (byte[])configRow["OBJECT"];

        //            view._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);



        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is TargetInvocationException)
        //        {
        //            acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
        //                (((acGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

        //        }
        //        else if (ex is DefaultSystemLayoutChangedException)
        //        {

        //            acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
        //                 (((acGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


        //        }
        //        else
        //        {

        //            acMessageBox.Show(view.ParentControl, ex);
        //        }
        //    }


        //}

        void acGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //단축키 설정

            acGridView view = (acGridView)this.MainView;

            //복사
            if (e.Control == true &&
                e.Shift == false &&
                e.Alt == false &&
                e.KeyCode == Keys.C)
            {
                GridCell[] cells = view.GetSelectedCells();

                if (cells.Length > 1)
                {
                    //string text = string.Empty;

                    //int currentHandle = -1;
                    //bool isFirst = false;
                    //foreach (GridCell cell in cells)
                    //{
                    //    if (currentHandle != cell.RowHandle)
                    //    {
                    //        currentHandle = cell.RowHandle;
                    //        isFirst = true;//해당 로우의 첫번째 인지
                    //    }

                    //    if (text == "")
                    //    {
                    //        text += view.GetRowCellDisplayText(cell.RowHandle, cell.Column);
                    //        isFirst = false;
                    //    }
                    //    else
                    //    {
                    //        if (isFirst)
                    //        {
                    //            text += "\n" + view.GetRowCellDisplayText(cell.RowHandle, cell.Column);
                    //            isFirst = false;
                    //        }
                    //        else
                    //            text += view.GetRowCellDisplayText(cell.RowHandle, cell.Column) + "\t";
                    //    }
                    //}
                    //Clipboard.SetText(text);
                    //e.Handled = true;
                    //return;

                }
                else
                {
                    if (view.GetFocusedRowCellValue(view.FocusedColumn).isNullOrEmpty() == false)
                    {
                        Clipboard.SetText(view.GetFocusedRowCellValue(view.FocusedColumn).ToString());

                        e.Handled = true;

                        return;
                    }
                }
            }
            //컬럼보이기 단축키 (Shift + C)
            else if (e.Control == false &&
                        e.Shift == true &&
                        e.Alt == false &&
                        e.KeyCode == Keys.C)
            {


                //view.OptionsView.ShowColumnHeaders = !view.OptionsView.ShowColumnHeaders;
            }

            //필터 단축키 (Ctrl + F)
            else if (e.Control == true &&
                        e.Shift == false &&
                        e.Alt == false &&
                        e.KeyCode == Keys.F)
            {


                if (view.FocusedRowHandle != GridControl.InvalidRowHandle)
                {
                    view.SetColumnFilter(view.FocusedColumn.FieldName, view.GetFocusedDisplayText());
                }
            }

            //빠른필터 (Ctrl + Shift + F)
            else if (e.Control == true &&
                        e.Shift == true &&
                        e.Alt == false &&
                        e.KeyCode == Keys.F)
            {

                view.ShowFastFilterEditor(view.FocusedColumn.FieldName);

            }
            //컬럼 최적화 (Ctrl + B)
            else if (e.Control == true &&
                        e.Shift == false &&
                        e.Alt == false &&
                        e.KeyCode == Keys.B)
            {

                view.FocusedColumn.BestFit();

            }
            //컬럼 최적화(전체)  (Ctrl + Shift + B)
            else if (e.Control == true &&
                        e.Shift == true &&
                        e.Alt == false &&
                        e.KeyCode == Keys.B)
            {


                view.BestFitColumnsThread();

            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                //Cell값 삭제



                if (view.FocusedColumn.OptionsColumn.AllowEdit == true)
                {
                    if (view.FocusedColumn.ColumnEdit is RepositoryItemColorEdit)
                    {
                        view.SetFocusedValue(DBNull.Value);

                        view.nRaiseCellValueChanging(new CellValueChangedEventArgs(view.FocusedRowHandle, view.FocusedColumn, DBNull.Value));

                        view.nRaiseCellValueChanged(new CellValueChangedEventArgs(view.FocusedRowHandle, view.FocusedColumn, DBNull.Value));

                    }

                }

            }

        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("acGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection
    collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new acGridViewInfoRegistrator());
        }

        #region IControl 멤버

        public void FocusContainer()
        {
            (this.MainView as acGridView).ParentControl.Focus();

        }

        #endregion
    }


    public class acGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        private int _ScrollSize = 17;
        private int _FirstMouseDownIdx = -1;
        private string _ColName;
        public string _CustomReportCusID = null;
        public string _CustomReportCusName = null;
        protected override ScrollInfo CreateScrollInfo()
        {
            if (acInfo.IsPopMenu == "1")
            {
                int _Size = acInfo.SysConfig.GetSysConfigByMemory("POP_SCROLL_SIZE").toInt();


                return new Scrollinfo(this, _Size);
            }
            else
            {
                return new Scrollinfo(this, _ScrollSize);
            }


        }

        public enum emEditorType
        {
            NONE,

            TEXT,

            RADIO_GROUP,

            MEMO,

            CHECK,

            DATE,

            DATE_STRING,

            TIME,

            /// <summary>
            /// 사용자정의 코드
            /// </summary>
            LOOKUP,

            /// <summary>
            /// 표준코드
            /// </summary>
            LOOKUP_CODE,

            PICTURE,

            COLOR,

            PROGRESSBAR,

            BUTTON,

            COMBOBOX,

            CUSTOM,

            CHECKEDCOMBO

        }


        public enum emNumericEditMask
        {
            /// <summary>
            /// 숫자
            /// </summary>
            NUMERIC,

            /// <summary>
            /// 수량
            /// </summary>
            QTY,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY
        }

        public enum emTextEditMask
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 영문대문자 1자리
            /// </summary>
            UPPERCASE,

            /// <summary>
            /// 숫자
            /// </summary>
            NUMERIC,

            /// <summary>
            /// numeric
            /// </summary>
            N,
            /// <summary>
            /// 수량
            /// </summary>
            QTY,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY,
            /// <summary>
            /// 돈(소수점이하 4자리)
            /// </summary>
            MONEY_F2,
            /// <summary>
            /// 돈(소수점이하 4자리)
            /// </summary>
            MONEY_F4,
            /// <summary>
            /// 파일크기
            /// </summary>
            FILE_SIZE,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT_F3,


            /// <summary>
            /// 퍼센트 소수점 둘째자리
            /// </summary>
            PER2,

            /// <summary>
            /// 퍼센트 소수점 없음
            /// </summary>
            PER0,

            /// <summary>
            /// 퍼센트 최대100 소수점자리 없음
            /// </summary>
            PER100,

            /// <summary>
            /// 퍼센트 최대100 소수점자리 없음
            /// </summary>
            PER100_2,

            /// <summary>
            /// 공수(시간)
            /// </summary>
            TIME,

            /// <summary>
            /// 소수점 둘째자리
            /// </summary>
            F2,

            /// <summary>
            /// 소수점 첫째자리
            /// </summary>
            F1,

            /// <summary>
            /// 소수점 셋째자리
            /// </summary>
            F3,

            /// <summary>
            /// 소수점 첫째자리
            /// </summary>
            F4,

            /// <summary>
            /// 소수점 여섯째자리
            /// </summary>
            F6,
            /// <summary>
            /// IP 주소
            /// </summary>
            IP,

            /// <summary>
            /// 전화번호
            /// </summary>
            TEL,

            /// <summary>
            /// 우편번호
            /// </summary>
            ZIP,

            /// <summary>
            /// 사업자등록번호
            /// </summary>
            CORP,

            /// <summary>
            /// 법인번호
            /// </summary>
            LAW,

            DIGIT,

            /// <summary>
            /// 작업 우선순위
            /// </summary>
            JOB_PRIORITY,

            /// <summary>
            /// 시간
            /// </summary>
            HHmm,

            /// <summary>
            /// NUM_4_0 0001~9999
            /// </summary>
            NUM_4_0,

            /// <summary>
            /// 온도
            /// </summary>
            TEMP,

            /// <summary>
            /// 주민번호
            /// </summary>
            REG_NUMBER

        };

        public enum emPartProdType { PROD, PART, MAT };
        public enum emCheckEditDataType { _BOOL, _STRING, _INT, _BYTE, _YN };

        public enum emVenType { PURCHASE, SALE, BOTH };
        public enum emGridType
        {
            /// <summary>
            /// 조회 그리드
            /// </summary>
            SEARCH,

            /// <summary>
            /// 조회 그리드 SEL 컬럼 없이 선택 모드 
            /// </summary>
            SEARCH_SEL,


            /// <summary>
            /// 고정 그리드
            /// </summary>
            FIXED,

            /// <summary>
            /// 고정 그리드-자동 WIdth
            /// </summary>
            FIXED_FULLWIDTH,

            FIXED_EXCEL,

            /// <summary>
            /// 고정그리드 한개
            /// </summary>
            FIXED_SINGLE,
            /// <summary>
            /// 공통 컨트롤 그리드
            /// </summary>
            COMMON_CONTROL,



            ATTACH_FILE_LIST,

            LIST,

            /// </summary>
            LIST_USERCONFIG,

            LIST_USERCONFIG2,

            /// <summary>
            /// 리스트 그리드 한개
            /// </summary>
            LIST_SINGLE,

            /// <summary>
            /// 그리드 컬럼 AUTOCOLUMN
            /// </summary>
            AUTO_COL


        }

        #region 속성

        private string[] _KeyColumn = new string[] { };

        /// <summary>
        /// 키컬럼을 설정합니다. , 로 여러개 설정가능(Column1,Column2)
        /// </summary>
        /// 
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] KeyColumn
        {
            get { return _KeyColumn; }
            set { _KeyColumn = value; }
        }


        private string[] _ExcelCustomMergColumns = new string[] { };

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] ExcelCustomMergColumns
        {
            get { return _ExcelCustomMergColumns; }
            set { _ExcelCustomMergColumns = value; }
        }


        private string _SaveFileName = null;


        /// <summary>
        /// 저장시 파일이름을 설정합니다.
        /// </summary>
        public string SaveFileName
        {
            get { return _SaveFileName; }
            set { _SaveFileName = value; }
        }




        private Control _ParentControl = null;

        /// <summary>
        /// 부모컨트롤(메뉴컨트롤)
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }



        /// <summary>
        /// 데이터 소스가 바뀌기전 FocusRowHandle을 반환합니다.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OldFocusRowHandle
        {
            get
            {
                acGridControl acGrid = (acGridControl)this.GridControl;

                return acGrid._OldFocusRowHandle;
            }
        }



        protected override void RaiseFocusedRowChanged(int prevFocused, int focusedRowHandle)
        {

            base.RaiseFocusedRowChanged(prevFocused, focusedRowHandle);
        }

        /// <summary>
        /// 그리드UI을 읽어올지여부를 설정합니다.
        /// </summary>
        internal bool _IsLoadConfig = false;

        internal bool _unraiseDSChanged = false;

        /// <summary>
        /// 사용자 UI
        /// </summary>
        internal acGridViewConfig _Config = null;

        internal bool _noApplyEditableCellColor = false;

        public bool NoApplyEditableCellColor
        {
            get { return _noApplyEditableCellColor; }
            set { _noApplyEditableCellColor = value; }
        }


        protected override GridColumnCollection CreateColumnCollection()
        {
            return new acGridColumnCollection(this);

        }



        void SetGridType()
        {
            switch (this._GridType)
            {

                case ControlManager.acGridView.emGridType.SEARCH:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = true;

                    this.OptionsMenu.EnableGroupPanelMenu = true;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = false;

                    this.OptionsView.ShowIndicator = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;

                    this._IsLoadConfig = true;

                    break;


                case ControlManager.acGridView.emGridType.SEARCH_SEL:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = true;

                    this.OptionsMenu.EnableGroupPanelMenu = true;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = false;

                    this.OptionsView.ShowIndicator = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;

                    this._IsLoadConfig = true;

                    this.OptionsSelection.MultiSelect = true;
                    this.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

                    break;

                case ControlManager.acGridView.emGridType.FIXED:


                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;

                    this.OptionsCustomization.AllowColumnMoving = false;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsView.ShowGroupPanel = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = false;

                    this.OptionsView.ShowIndicator = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;

                    break;

                case ControlManager.acGridView.emGridType.FIXED_FULLWIDTH:


                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = false;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsView.ShowGroupPanel = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsView.ShowIndicator = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;

                    break;

                case ControlManager.acGridView.emGridType.FIXED_EXCEL:


                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = false;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsView.ShowGroupPanel = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;

                    this.OptionsView.ColumnAutoWidth = false;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;

                    break;

                case emGridType.FIXED_SINGLE:


                    this.FocusRectStyle = DrawFocusRectStyle.CellFocus;

                    this.OptionsMenu.EnableColumnMenu = false;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = false;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;

                    this.OptionsView.ColumnAutoWidth = false;

                    this.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;


                    break;

                case ControlManager.acGridView.emGridType.COMMON_CONTROL:


                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;

                    this.OptionsView.ShowGroupPanel = false;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;


                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;

                    break;

                case ControlManager.acGridView.emGridType.LIST_USERCONFIG:


                    this.OptionsMenu.EnableColumnMenu = false;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this._IsLoadConfig = true;

                    break;

                case ControlManager.acGridView.emGridType.LIST_USERCONFIG2:


                    this.OptionsMenu.EnableColumnMenu = false;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = false;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = false;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this._IsLoadConfig = true;

                    break;

                case ControlManager.acGridView.emGridType.LIST:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = true;
                    this._IsLoadConfig = true;

                    break;

                case ControlManager.acGridView.emGridType.ATTACH_FILE_LIST:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;


                    this.OptionsCustomization.AllowColumnMoving = false;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = false;

                    this.OptionsCustomization.AllowSort = true;


                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;

                    break;


                case ControlManager.acGridView.emGridType.LIST_SINGLE:

                    this.FocusRectStyle = DrawFocusRectStyle.CellFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = false;

                    this.OptionsMenu.EnableGroupPanelMenu = false;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;


                    break;

                case ControlManager.acGridView.emGridType.AUTO_COL:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = true;

                    this.OptionsMenu.EnableGroupPanelMenu = true;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = true;

                    this._IsLoadConfig = true;

                    break;



            }

            this._Config.EditCellStyle.BackColor = Color.LemonChiffon;
            this.Appearance.FocusedRow.BackColor = Color.AliceBlue;
            this.Appearance.SelectedRow.BackColor = Color.AliceBlue;

        }


        private emGridType _GridType = emGridType.SEARCH;

        /// <summary>
        /// 그리드 형태를 설정합니다.
        /// </summary>
        [DefaultValue(ControlManager.acGridView.emGridType.SEARCH)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public emGridType GridType
        {
            get { return _GridType; }
            set
            {
                _GridType = value;

                if (acInfo.IsRunTime == true)
                {
                    this.SetGridType();

                }
            }
        }



        #endregion


        private bool _IsUserStyle = false;

        public bool IsUserStyle
        {
            get { return _IsUserStyle; }
            set
            {
                _IsUserStyle = value;

                if (this._IsUserStyle)
                {
                    this.GridControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                    this.GridControl.LookAndFeel.UseDefaultLookAndFeel = false; // <<<<<<<<
                    //acGridView1.GridControl.LookAndFeel.SkinName = "Sharp Plus";
                    this.Appearance.HeaderPanel.Options.UseBackColor = true;
                    this.Appearance.HeaderPanel.BackColor = ColorTranslator.FromHtml("#708090");// System.Drawing.Color.DarkBlue;
                    this.Appearance.HeaderPanel.Options.UseForeColor = true;
                    this.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
                    this.Appearance.HeaderPanel.Options.UseFont = true;
                    this.Appearance.HeaderPanel.Font = new Font("맑은 고딕", this.Appearance.HeaderPanel.Font.Size, FontStyle.Bold);

                }
            }
        }

        /// <summary>
        /// 기본테이블
        /// </summary>
        private DataTable _DefaultTable = null;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DefaultTable
        {
            get { return _DefaultTable; }
            set { _DefaultTable = value; }
        }


        private void Init()
        {
            this.RowHeight = 28;

            this.ColumnPanelRowHeight = 28;

            this.OptionsView.ShowGroupPanel = false;

            this.OptionsView.ShowIndicator = false;

            this.OptionsLayout.StoreAllOptions = true;

            this.OptionsLayout.Columns.StoreAllOptions = true;

            this.OptionsCustomization.AllowRowSizing = false;

            this.OptionsView.RowAutoHeight = true;

            //this.OptionsBehavior.AutoPopulateColumns = false;
            this.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            this.OptionsView.EnableAppearanceEvenRow = true;

            //this.Appearance.HorzLine.BackColor = Color.Black;
            //this.Appearance.VertLine.BackColor = Color.Black;

            if (acInfo.IsRunTime == true)
            {

                bool hotTrackUse = acInfo.SysConfig.GetSysConfigByMemory("GRID_HOT_TRACK_USE").isNullOrEmpty() ? false : acInfo.SysConfig.GetSysConfigByMemory("GRID_HOT_TRACK_USE").ToString() == "1" ? true : false;

                if (hotTrackUse)
                {
                    this.OptionsSelection.EnableAppearanceHotTrackedRow = DefaultBoolean.True;
                }


                this._DefaultTable = new DataTable();

                if (!this._DefaultTable.Columns.Contains("GRID_ROW_SEQ"))
                {
                    this._DefaultTable.Columns.Add("GRID_ROW_SEQ", typeof(int));
                }
                this._Config = new acGridViewConfig(this);

                this.SetGridType();

            }


            this.Click += new EventHandler(acGridView_Click);

            
            this.MouseDown += new MouseEventHandler(acGridView_MouseDown);
            //this.MouseMove += new MouseEventHandler(acGridView_MouseMove);
            //this.MouseUp += new MouseEventHandler(acGridView_MouseUp);

            //this.ShowGridMenuEx += new GridMenuEventHandler(acGridView_ShowGridMenu);
            this.ShowGridMenuEx += new ShowGridMenuExHandler(acGridView_ShowGridMenuEx); ;

            this.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(acGridView_CustomDrawRowIndicator);

            this.CustomDrawCell += new RowCellCustomDrawEventHandler(acGridView_CustomDrawCell);

            this.Disposed += new EventHandler(acGridView_Disposed);

            this.GroupSummary.CollectionChanged += new CollectionChangeEventHandler(GroupSummary_CollectionChanged);

            this.ShowCustomizationForm += new EventHandler(acGridView_ShowCustomizationForm);

            this.HideCustomizationForm += new EventHandler(acGridView_HideCustomizationForm);

            this.DragObjectDrop += new DragObjectDropEventHandler(acGridView_DragObjectDrop);

            this.DragObjectStart += new DragObjectStartEventHandler(acGridView_DragObjectStart);

            this.DataSourceChanged += new EventHandler(acGridView_DataSourceChanged);

            this.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(acGridView_CustomDrawColumnHeader);

            this.PopupMenuShowing += acGridView_PopupMenuShowing;

            this.ActiveFilter.Changed += ActiveFilter_Changed;
            this.ShowFilterPopupCheckedListBox += AcGridView_ShowFilterPopupCheckedListBox;
            this.ShowFilterPopupListBox += AcGridView_ShowFilterPopupListBox;
            //this.RowStyle += AcGridView_RowStyle;
            DevExpress.Utils.Filtering.ExcelFilterOptions.Default.ShowNulls = false;
        }

        private void AcGridView_ShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {
            try
            {
                if (e.Column.ColumnEdit is RepositoryItemCheckEdit ce)
                {
                    e.ComboBox.BeginUpdate();
                    acGridColumn col = e.Column as acGridColumn;
                    e.ComboBox.Items.Clear();
                    e.ComboBox.Items.Add(new FilterItem("모두 표시", new FilterItem("", 0)));
                    switch (col.EditorData)
                    {
                        case emCheckEditDataType._BOOL:
                            e.ComboBox.Items.Add(new FilterItem("True", true));
                            e.ComboBox.Items.Add(new FilterItem("False", false));
                            break;

                        case emCheckEditDataType._INT:
                            e.ComboBox.Items.Add(new FilterItem("True", 1));
                            e.ComboBox.Items.Add(new FilterItem("False", 0));
                            break;

                        case emCheckEditDataType._BYTE:
                            e.ComboBox.Items.Add(new FilterItem("True", (byte)1));
                            e.ComboBox.Items.Add(new FilterItem("False", (byte)0));
                            break;

                        case emCheckEditDataType._STRING:
                            e.ComboBox.Items.Add(new FilterItem("True", "1"));
                            e.ComboBox.Items.Add(new FilterItem("False", "0"));

                            break;

                        case emCheckEditDataType._YN:
                            e.ComboBox.Items.Add(new FilterItem("True", "Y"));
                            e.ComboBox.Items.Add(new FilterItem("False", "N"));
                            break;
                    }
                    e.ComboBox.EndUpdate();

                }
            }
            catch
            {

            }
        }

        bool _IsFilterChanged = false;
        private void ActiveFilter_Changed(object sender, EventArgs e)
        {
            try
            {
                if (_IsFilterChanged) return;

                _IsFilterChanged = true;
                List<ViewColumnFilterInfo> addFilterList = new List<ViewColumnFilterInfo>();

                foreach (ViewColumnFilterInfo vf in this.ActiveFilter)
                {
                    if (vf.Column is acGridColumn col && col.EditorType == emEditorType.CHECK)
                    {
                        string filter = vf.Filter.FilterString.Replace(" ", "").ToUpper();
                        switch (col.EditorData)
                        {
                            case emCheckEditDataType._BOOL:
                                if (filter.Contains("[" + col.FieldName + "]=FALSE") && !filter.Contains("ISNULLOREMPTY([" + col.FieldName + "])"))
                                {
                                    addFilterList.Add(new ViewColumnFilterInfo(col, new ColumnFilterInfo(vf.Filter.FilterString + " Or IsNullOrEmpty([" + col.FieldName + "])")));
                                }
                                break;

                            case emCheckEditDataType._INT:
                                if (filter.Contains("[" + col.FieldName + "]=0") && !filter.Contains("ISNULLOREMPTY([" + col.FieldName + "])"))
                                {
                                    addFilterList.Add(new ViewColumnFilterInfo(col, new ColumnFilterInfo(vf.Filter.FilterString + " Or IsNullOrEmpty([" + col.FieldName + "])")));
                                }
                                break;

                            case emCheckEditDataType._BYTE:
                                if (filter.Contains("[" + col.FieldName + "]=0B") && !filter.Contains("ISNULLOREMPTY([" + col.FieldName + "])"))
                                {
                                    addFilterList.Add(new ViewColumnFilterInfo(col, new ColumnFilterInfo(vf.Filter.FilterString + " Or IsNullOrEmpty([" + col.FieldName + "])")));
                                }
                                break;

                            case emCheckEditDataType._STRING:
                                if (filter.Contains("[" + col.FieldName + "]='0'") && !filter.Contains("ISNULLOREMPTY([" + col.FieldName + "])"))
                                {
                                    addFilterList.Add(new ViewColumnFilterInfo(col, new ColumnFilterInfo(vf.Filter.FilterString + " Or IsNullOrEmpty([" + col.FieldName + "])")));
                                }

                                break;

                            case emCheckEditDataType._YN:
                                if (filter.Contains("[" + col.FieldName + "]='N'") && !filter.Contains("ISNULLOREMPTY([" + col.FieldName + "])"))
                                {
                                    addFilterList.Add(new ViewColumnFilterInfo(col, new ColumnFilterInfo(vf.Filter.FilterString + " Or IsNullOrEmpty([" + col.FieldName + "])")));
                                }
                                break;
                        }
                    }
                }
                if (addFilterList.Count > 0)
                {
                    this.ActiveFilter.AddRange(addFilterList.ToArray());
                    this.ApplyColumnsFilterEx();
                }
            }
            catch
            {

            }
            finally
            {
                _IsFilterChanged = false;
            }
        }

        private void AcGridView_ShowFilterPopupCheckedListBox(object sender, FilterPopupCheckedListBoxEventArgs e)
        {
            try
            {
                if (e.Column.ColumnEdit is RepositoryItemCheckEdit ce)
                {
                    e.CheckedComboBox.BeginUpdate();
                    acGridColumn col = e.Column as acGridColumn;
                    e.CheckedComboBox.Items.Clear();
                    switch (col.EditorData)
                    {
                        case emCheckEditDataType._BOOL:
                            e.CheckedComboBox.Items.Add(new FilterItem("True", true), true);
                            e.CheckedComboBox.Items.Add(new FilterItem("False", false), false);
                            break;

                        case emCheckEditDataType._INT:
                            e.CheckedComboBox.Items.Add(new FilterItem("True", 1), true);
                            e.CheckedComboBox.Items.Add(new FilterItem("False", 0), false);
                            break;

                        case emCheckEditDataType._BYTE:
                            e.CheckedComboBox.Items.Add(new FilterItem("True", (byte)1), true);
                            e.CheckedComboBox.Items.Add(new FilterItem("False", (byte)0), false);
                            break;

                        case emCheckEditDataType._STRING:
                            e.CheckedComboBox.Items.Add(new FilterItem("True", "1"), true);
                            e.CheckedComboBox.Items.Add(new FilterItem("False", "0"), false);

                            break;

                        case emCheckEditDataType._YN:
                            e.CheckedComboBox.Items.Add(new FilterItem("True", "Y"), true);
                            e.CheckedComboBox.Items.Add(new FilterItem("False", "N"), false);
                            break;
                    }
                    e.CheckedComboBox.EndUpdate();
                    
                }
            }
            catch
            {

            }
        }

        private void AcGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                if (this.IsRowHotTracked(e.RowHandle))
                {
                    e.Appearance.BackColor = Color.Red;
                    //e.HighPriority = true;
                }
            }
            catch
            { }
        }

        protected override void OnGridLoadComplete()
		{
			base.OnGridLoadComplete();
            
            try
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("IS_FORM_ICON_COLOR_USE").toStringEmpty().Equals("1"))
                {
                    foreach (acGridColumn col in this.Columns)
                    {
                        if (col.ColumnEdit is RepositoryItemButtonEdit)
                        {
                            RepositoryItemButtonEdit rib = col.ColumnEdit as RepositoryItemButtonEdit;
                            foreach (EditorButton btn in rib.Buttons)
                            {
                                btn.Image = ChangeIconColor(btn.Image, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            if (img == null)
                return null;
            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    //if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }
        void acGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void acGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            this._ColumnHeaderHeight = e.Bounds.Height;
            this._ColumnHeaderCustomDrawEventArgs = e;
        }

        void acGridView_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void acGridView_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.FocusedRowHandle <= 0)
            {
                if (this.FocusedRowHandle == this.OldFocusRowHandle)
                {
                    this.RaiseFocusedRowChanged();
                }
            }

        }


        private int _DragDropColumnVisibleIdx = -1;

        void acGridView_DragObjectStart(object sender, DragObjectStartEventArgs e)
        {
            //드래그 컬럼 정보 저장

            acGridColumn cln = e.DragObject as acGridColumn;

            this._DragDropColumnVisibleIdx = cln.VisibleIndex;


        }

        void acGridView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
            acGridColumn cln = e.DragObject as acGridColumn;


            if (cln != null)
            {
                if (e.DropInfo.Index <= 100 && cln.Visible)
                {
                    // the column is being shown

                }
                else if (!cln.Visible)
                {
                    // the column is being hidden

                    if (cln.IsRequired == true)
                    {
                        //필수입력 컬럼은 컬럼제외하지않음

                        cln.Visible = true;

                        cln.VisibleIndex = this._DragDropColumnVisibleIdx;

                        acMessageBox.Show(this.ParentControl, "필수항목은 컬럼제외 할수없습니다.", "MMOX7NG8", true, acMessageBox.emMessageBoxType.CONFIRM);

                        return;

                    }


                }
            }
        }



        private MouseEventArgs _MouseDownArgs = null;

        void acGridView_MouseDown(object sender, MouseEventArgs e)
        {
            this._MouseDownArgs = e;
            if (this._FirstMouseDownIdx == -1)
            {
                GridHitInfo hitInfo = this.CalcHitInfo(e.Location);

                if (hitInfo.RowHandle < 0)
                    return;

                if (hitInfo.Column == null)
                    return;

                if (hitInfo.Column.ColumnEdit != null && hitInfo.Column.ColumnEdit.GetType() == typeof(RepositoryItemCheckEdit))
                {
                    this._FirstMouseDownIdx = hitInfo.RowHandle;
                    this._PreRowhandle = hitInfo.RowHandle;
                    this._ColName = hitInfo.Column.FieldName;
                }
            }
        }

        int _PreRowhandle = -1;
        private void acGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_PreRowhandle == -1)
                return;

            //드래그중
            if (e.Button.HasFlag(MouseButtons.Left)
                && this._FirstMouseDownIdx >= 0)
            {

                GridHitInfo hitInfo = this.CalcHitInfo(e.Location);

                if (_PreRowhandle != hitInfo.RowHandle)
                {
                    int startIdx;
                    int endIdx;

                    if (_FirstMouseDownIdx > hitInfo.RowHandle)
                    {
                        startIdx = hitInfo.RowHandle;
                        endIdx = _FirstMouseDownIdx;
                    }
                    else
                    {
                        startIdx = _FirstMouseDownIdx;
                        endIdx = hitInfo.RowHandle;
                    }

                    for (; startIdx <= endIdx; startIdx++)
                    {
                        this.SetRowCellValue(startIdx, this._ColName, true);
                    }
                }
                else
                {
                    _PreRowhandle = hitInfo.RowHandle;
                }
            }
        }
        private void acGridView_MouseUp(object sender, MouseEventArgs e)
        {

            if (this._FirstMouseDownIdx >= 0)
            {
                GridHitInfo hitInfo = this.CalcHitInfo(e.Location);

                int startIdx;
                int endIdx;

                if (_FirstMouseDownIdx > hitInfo.RowHandle)
                {
                    startIdx = hitInfo.RowHandle;
                    endIdx = _FirstMouseDownIdx;
                }
                else
                {
                    startIdx = _FirstMouseDownIdx;
                    endIdx = hitInfo.RowHandle;
                }

                for(;startIdx<=endIdx;startIdx++)
                {
                    this.SetRowCellValue(startIdx, this._ColName, true);
                }
            }

            this._FirstMouseDownIdx = -1;
        }

        private ColumnHeaderCustomDrawEventArgs _ColumnHeaderCustomDrawEventArgs = null;

        public ColumnHeaderCustomDrawEventArgs ColumnHeaderCustomDrawEventArgs
        {
            get { return _ColumnHeaderCustomDrawEventArgs; }
        }


        /// <summary>
        /// 커스터마이징 폼 여부
        /// </summary>
        private bool _isCustomizationForm = false;

        void acGridView_HideCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = false;
        }

        void acGridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = true;
        }

        void GroupSummary_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add ||
                e.Action == CollectionChangeAction.Refresh)
            {
                //그룹풋더는 해당컬럼의 마스크에따라 포맷스트링이 결정되게 수정

                GridGroupSummaryItem item = e.Element as GridGroupSummaryItem;

                if (item != null)
                {

                    acGridColumn col = this.Columns[item.FieldName] as acGridColumn;

                    if (col != null)
                    {

                        switch (col.EditorType)
                        {

                            case emEditorType.TEXT:


                                RepositoryItemTextEdit editor = col.ColumnEdit as RepositoryItemTextEdit;

                                item.DisplayFormat = "{0:" + editor.Mask.EditMask + "}";


                                break;

                        }

                    }

                }


            }


        }
        void TotalSummary_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add ||
                e.Action == CollectionChangeAction.Refresh)
            {
                //토탈 풋더는 해당컬럼의 마스크에따라 포맷스트링이 결정되게 수정

                GridColumnSummaryItem item = e.Element as GridColumnSummaryItem;

                if (item != null)
                {

                    acGridColumn col = this.Columns[item.FieldName] as acGridColumn;

                    if (col != null)
                    {

                        switch (col.EditorType)
                        {

                            case emEditorType.TEXT:


                                RepositoryItemTextEdit editor = col.ColumnEdit as RepositoryItemTextEdit;

                                item.DisplayFormat = "{0:" + editor.Mask.EditMask + "}";


                                break;

                        }

                    }
                }


            }
        }


        void acGridView_Disposed(object sender, EventArgs e)
        {
            if (_StyleBox != null)
            {

                _StyleBox.Dispose();
            }


            if (_ConfigManager != null)
            {
                _ConfigManager.Dispose();
            }

            //if (_CustomExcelManager != null)
            //{
            //    _CustomExcelManager.Dispose();
            //}

            if (_LoadConfig != null)
            {
                _LoadConfig.Dispose();
            }


            foreach (KeyValuePair<string, acGridViewFilterEditor> filter in _FilterEditors)
            {
                filter.Value.Dispose();
            }

            foreach (KeyValuePair<string, acGridViewMaskEdit> mask in _MaskEditors)
            {
                mask.Value.Dispose();
            }


        }




        /// <summary>
        /// 데이터가 변경되었는지 알아옵니다.
        /// </summary>
        /// <returns></returns>
        public bool IsDataUpdate()
        {
            DataTable data = (DataTable)this.GridControl.DataSource;

            foreach (DataRow row in data.Rows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    return true;
                }
            }

            return false;

        }


        public bool IsEqualOldFocusedRowHandle()
        {
            return this.OldFocusRowHandle == this.FocusedRowHandle;

        }



        //에디팅모드 색상변경 사용
        public bool AllowEditColorUse = true;
        public float EditCellSize = 0;
        void acGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

            try
            {

                if (this._Config == null)
                {
                    return;
                }

                if (_noApplyEditableCellColor) return;

                this._RowCellCustomDrawEventArgs = e;

                if (e.Column.OptionsColumn.AllowEdit == true && AllowEditColorUse)
                {
                    e.Appearance.BackColor = _Config.EditCellStyle.BackColor;

                    e.Appearance.BackColor2 = _Config.EditCellStyle.BackColor2;

                    //e.Appearance.Font = _Config.EditCellStyle.Font;

                    e.Appearance.ForeColor = Color.Black; //_Config.EditCellStyle.ForeColor;

                    e.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    RepositoryItem edit = (RepositoryItem)e.Column.ColumnEdit;

                    if (edit != null)
                    {

                        edit.Appearance.BackColor = _Config.EditCellStyle.BackColor;
                        edit.Appearance.BackColor2 = _Config.EditCellStyle.BackColor2;
                        //edit.Appearance.ForeColor = _Config.EditCellStyle.ForeColor;
                        edit.Appearance.ForeColor = Color.Black;//셀 value수정시 폰트 색상 안바껴서 검정색으로 고정(신재경)

                        //edit.Appearance.Font = _Config.EditCellStyle.Font;
                        edit.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    }

                }

                //수정가능한 셀

                if (e.Column.OptionsColumn.AllowEdit == true && AllowEditColorUse)
                {
                    RepositoryItem edit = e.Column.ColumnEdit as RepositoryItem;


                    if (edit != null)
                    {

                        if (edit.ReadOnly == false)
                        {
                            e.Appearance.BackColor = this._Config.EditCellStyle.BackColor;
                            e.Appearance.BackColor2 = this._Config.EditCellStyle.BackColor2;
                            //e.Appearance.Font = this._Config.EditCellStyle.Font;
                            e.Appearance.ForeColor = this._Config.EditCellStyle.ForeColor;
                            e.Appearance.GradientMode = this._Config.EditCellStyle.GradientMode;

                        }
                        else
                        {
                            e.Appearance.BackColor = acInfo.ReadOnlyBackColor;


                            if (edit != null)
                            {

                                edit.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                            }
                        }
                    }

                }

                this._RowHeight = e.Bounds.Height;





                //변경된 행

                if (e.RowHandle != this.FocusedRowHandle)
                {
                    DataRow row = this.GetDataRow(e.RowHandle);

                    if (row != null)
                    {
                        if (row.RowState == DataRowState.Modified && AllowEditColorUse)
                        {
                            e.Appearance.BackColor = this._Config.ModifiedRowStyle.BackColor;

                            e.Appearance.BackColor2 = this._Config.ModifiedRowStyle.BackColor2;

                            //e.Appearance.Font = this._Config.ModifiedRowStyle.Font;

                            e.Appearance.ForeColor = this._Config.ModifiedRowStyle.ForeColor;

                            e.Appearance.GradientMode = this._Config.ModifiedRowStyle.GradientMode;
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            //단말기 체크시 컬러가 바껴서 주석처리
                            //e.Appearance.BackColor = this._Config.ModifiedRowStyle.BackColor;

                            //e.Appearance.BackColor2 = this._Config.ModifiedRowStyle.BackColor2;

                            //e.Appearance.Font = this._Config.ModifiedRowStyle.Font;

                            //e.Appearance.ForeColor = this._Config.ModifiedRowStyle.ForeColor;

                            //e.Appearance.GradientMode = this._Config.ModifiedRowStyle.GradientMode;

                        }
                    }
                }


                //수정가능한 셀

                if (e.Column.OptionsColumn.AllowEdit == true && AllowEditColorUse)
                {
                    RepositoryItem edit = e.Column.ColumnEdit as RepositoryItem;


                    if (edit != null)
                    {

                        if (edit.ReadOnly == false)
                        {
                            e.Appearance.BackColor = this._Config.EditCellStyle.BackColor;
                            e.Appearance.BackColor2 = this._Config.EditCellStyle.BackColor2;
                            //e.Appearance.Font = this._Config.EditCellStyle.Font;
                            e.Appearance.ForeColor = this._Config.EditCellStyle.ForeColor;
                            e.Appearance.GradientMode = this._Config.EditCellStyle.GradientMode;

                        }
                        else
                        {
                            e.Appearance.BackColor = acInfo.ReadOnlyBackColor;


                            if (edit != null)
                            {

                                edit.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                            }
                        }
                    }

                }

                if (e.Column.OptionsColumn.AllowEdit == true && AllowEditColorUse)
                {
                    if (EditCellSize > 0)
                    {
                        e.Appearance.Font = new Font("Tahoma", EditCellSize, FontStyle.Regular, GraphicsUnit.Point);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }


        }


        private int _IndicatorWidth = 0;

        void acGridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {

            DataView view = (DataView)this.DataSource;


            if (view != null)
            {

                if (e.RowHandle >= 0)
                {
                    int num = (e.RowHandle + 1);

                    e.Info.DisplayText = num.ToString();

                }


                SizeF size = e.Graphics.MeasureString(view.Count.ToString(), e.Appearance.Font);

                int newIndicatorWidth = (int)size.Width + 20;

                if (_IndicatorWidth != newIndicatorWidth)
                {
                    _IndicatorWidth = newIndicatorWidth;

                    this.IndicatorWidth = _IndicatorWidth;

                    this.RefreshData();

                }
            }

        }


        public acGridView(GridControl owerGridControl)
            : base(owerGridControl)
        {

            this.Init();
        }

        public acGridView()
            : base()
        {

            this.Init();
        }

        private bool _ShowGroupFooter = false;


        void menuHelp_Click(object sender, EventArgs e)
        {
            if (this.GridType == emGridType.ATTACH_FILE_LIST)
            {
                //파일첨부 도움말

                string helpClassName = "HELP_CTRL_ATTACHFILE";

                if (!acInfo.HelpForms.ContainsKey(helpClassName))
                {
                    acMessageBoxHelp frm = new acMessageBoxHelp(helpClassName);

                    frm.ParentControl = this._ParentControl;

                    frm.Show();

                    acInfo.HelpForms.Add(helpClassName, frm);
                }
                else
                {
                    acInfo.HelpForms[helpClassName].Focus();
                }

            }
            else
            {
                //그리드 도움말

                string helpClassName = "HELP_CTRL_GRID";

                if (!acInfo.HelpForms.ContainsKey(helpClassName))
                {
                    acMessageBoxHelp frm = new acMessageBoxHelp(helpClassName);

                    frm.ParentControl = this._ParentControl;

                    frm.Show();

                    acInfo.HelpForms.Add(helpClassName, frm);
                }
                else
                {
                    acInfo.HelpForms[helpClassName].Focus();
                }

            }
        }

        void menuItemEditShowTypeValue_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

            Dictionary<string, object> editData = col.EditorData as Dictionary<string, object>;


            edit.DisplayMember = editData["VALUE_COLUMN_NAME"].ToString();

            editData["CURRENT_SHOW_COLUMN_NAME"] = edit.DisplayMember;



            this.RefreshData();

        }

        void menuItemEditShowTypeDisplay_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

            Dictionary<string, object> editData = col.EditorData as Dictionary<string, object>;

            edit.DisplayMember = editData["DISPLAY_COLUMN_NAME"].ToString();

            editData["CURRENT_SHOW_COLUMN_NAME"] = edit.DisplayMember;


            this.RefreshData();
        }

        void menuItemGroupCollapse_Click(object sender, EventArgs e)
        {
            //모든그룹 접기

            this.CollapseAllGroups();
        }

        void menuItemGroupExpand_Click(object sender, EventArgs e)
        {
            //모든그룹 펼치기

            this.ExpandAllGroups();




        }

        private RowCellCustomDrawEventArgs _RowCellCustomDrawEventArgs = null;

        public RowCellCustomDrawEventArgs RowCellCustomDrawEventArgs
        {
            get { return _RowCellCustomDrawEventArgs; }
        }



        void menuItemDefaultPrint_Click(object sender, EventArgs e)
        {
            //기본 인쇄


            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(ps);

            link.Component = this.GridControl;

            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            link.CreateDocument();

            link.ShowPreview();


        }




        private Dictionary<string, acGridViewFilterEditor> _FilterEditors = new Dictionary<string, acGridViewFilterEditor>();

        void menuItemFilter_Click(object sender, EventArgs e)
        {
            //빠른 필터기능

            acMenuItem item = (acMenuItem)sender;

            acGridColumn col = (acGridColumn)item.UserData;

            if (!_FilterEditors.ContainsKey(col.FieldName))
            {
                acGridViewFilterEditor frm = new acGridViewFilterEditor(this, col.FieldName);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(acGridViewFilter_FormClosed);


                frm.Show();

                _FilterEditors.Add(col.FieldName, frm);
            }
            else
            {
                _FilterEditors[col.FieldName].Focus();
            }


        }

        internal void ShowFastFilterEditor(string filedName)
        {
            if (!_FilterEditors.ContainsKey(filedName))
            {
                acGridViewFilterEditor frm = new acGridViewFilterEditor(this, filedName);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(acGridViewFilter_FormClosed);


                frm.Show();

                _FilterEditors.Add(filedName, frm);
            }
            else
            {
                _FilterEditors[filedName].Focus();
            }
        }

        void acGridViewFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            acGridViewFilterEditor frm = (acGridViewFilterEditor)sender;

            _FilterEditors.Remove(frm.FieldName);
        }

        /// <summary>
        /// 그리드에 종속적인 창들을 모두 숨긴다.
        /// </summary>
        internal void HideSubWindows()
        {
            if (this._isCustomizationForm == true)
            {
                this.HideCustomization();
            }

            //스타일상자

            if (this._StyleBox != null)
            {
                this._StyleBox.Hide();
            }

            //사용자 UI 불러오기

            if (this._LoadConfig != null)
            {

                this._LoadConfig.Hide();
            }

            //사용자 UI 관리

            if (this._ConfigManager != null)
            {
                this._ConfigManager.Hide();
            }

            //사용자 
            //if (this._CustomExcelManager != null)
            //{
            //    this._CustomExcelManager.Hide();
            //}

            //마스크 에디터

            foreach (KeyValuePair<string, acGridViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Hide();

            }

            //필터 에디터

            foreach (KeyValuePair<string, acGridViewFilterEditor> filterEditor in this._FilterEditors)
            {
                filterEditor.Value.Hide();
            }




        }

        /// <summary>
        /// 현재 사용자UI를 시스템UI로 저장한다.
        /// </summary>
        private void SaveSystemUserConfig()
        {
            acGridViewConfig systemConfig = new acGridViewConfig(this);

            acGridControl acGridControl = (acGridControl)this.GridControl;

            byte[] layout = null;
            byte[] config = null;


            systemConfig.Save(out layout, out config);

            acGridControl._SystemLayout = layout;
            acGridControl._SystemConfig = config;
        }

        /// <summary>
        /// 특정이름으로 사용자UI를 저장한다.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="controlName"></param>
        /// <param name="configName"></param>
        public void SaveDefaultUserConfig(string empCode, string className, string controlName, string configName)
        {
            try
            {
                byte[] layoutData = null;
                byte[] configData = null;


                this._Config.Save(out layoutData, out configData);


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
                paramRow["EMP_CODE"] = empCode;
                paramRow["CLASS_NAME"] = className;
                paramRow["CONTROL_NAME"] = controlName;
                paramRow["CONFIG_NAME"] = configName;
                paramRow["DEFAULT_USE"] = "1";
                paramRow["LAYOUT"] = layoutData;
                paramRow["OBJECT"] = configData;
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 특정 컨트롤에 사용중인 사용자 UI을 초기화한후 시스템UI를 불러온다.
        /// </summary>
        public void ResetUserConfig(string className, string controlName, string userID)
        {
            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("CLASS_NAME");
            paramTable.Columns.Add("CONTROL_NAME");


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = userID;
            paramRow["CLASS_NAME"] = className;
            paramRow["CONTROL_NAME"] = controlName;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_USERCONFIG_DEFAULT_USE_DEL", paramSet, "RQSTDT", "");

            //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE_DEL(paramSet);

            acGridControl acGrid = this.GridControl as acGridControl;

            this._Config.Load(null, null, acGrid._SystemLayout, acGrid._SystemConfig);

        }

        /// <summary>
        /// 특정 컨트롤에 사용중인 사용자 UI을 불러온다.
        /// </summary>
        public void LoadUserConfig(string className, string controlName, string userID)
        {
            try
            {

                this.SaveSystemUserConfig();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = userID;
                paramRow["CLASS_NAME"] = className;
                paramRow["CONTROL_NAME"] = controlName;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = resultSet.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    this._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                }

            }
            catch (Exception ex)
            {

                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
                        string.Empty, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                        string.Empty, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {
                    acMessageBox.Show(this.ParentControl, ex);
                }

            }



        }


        /// <summary>
        /// 사용중인 사용자 UI을 초기화시킨다.
        /// </summary>
        public void ResetUserConfig()
        {
            acGridControl grid = (this.GridControl as acGridControl);


            this._Config.Load(null, null, grid._SystemLayout, grid._SystemConfig);
        }



        /// <summary>
        /// 사용중인 사용자 UI을 불러온다.
        /// </summary>
        public void LoadUserConfig()
        {
            try
            {

                this.SaveSystemUserConfig();

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

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = resultSet.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    this._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                }

            }
            catch (Exception ex)
            {

                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
                        (((acGridView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                        (((acGridView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {
                    acMessageBox.Show(this.ParentControl, ex);
                }

            }



        }

        /// <summary>
        /// 그리드에 종송적인 창들을 모두 표시한다.
        /// </summary>
        internal void ShowSubWindows()
        {

            if (this._isCustomizationForm == true)
            {
                this.ShowCustomization();
            }

            //스타일상자

            if (this._StyleBox != null)
            {
                this._StyleBox.Show();
            }

            //사용자 UI 불러오기

            if (this._LoadConfig != null)
            {

                this._LoadConfig.Show();
            }

            //사용자 UI 관리

            if (this._ConfigManager != null)
            {
                this._ConfigManager.Show();
            }

            //if (this._CustomExcelManager != null)
            //{
            //    this._CustomExcelManager.Show();
            //}

            //마스크 에디터

            foreach (KeyValuePair<string, acGridViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Show();

            }

            //필터 에디터

            foreach (KeyValuePair<string, acGridViewFilterEditor> filterEditor in this._FilterEditors)
            {
                filterEditor.Value.Show();
            }



        }


        private Dictionary<string, acGridViewMaskEdit> _MaskEditors = new Dictionary<string, acGridViewMaskEdit>();


        void menuItemMask_Click(object sender, EventArgs e)
        {
            //마스크 설정

            acMenuItem item = (acMenuItem)sender;


            acGridColumn col = (acGridColumn)item.UserData;

            if (!_MaskEditors.ContainsKey(col.FieldName))
            {
                acGridViewMaskEdit frm = new acGridViewMaskEdit(col);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(_MaskEditor_FormClosed);


                frm.Show();

                _MaskEditors.Add(col.FieldName, frm);


            }
            else
            {
                _MaskEditors[col.FieldName].Focus();
            }

        }

        void _MaskEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            acGridViewMaskEdit frm = (acGridViewMaskEdit)sender;

            _MaskEditors.Remove(frm.Column.FieldName);

        }

        void menuItemAllBestFitColumns_Click(object sender, EventArgs e)
        {
            //컬럼 최적화
            this.BestFitColumnsThread();

        }



        private acGridViewUserConfigManager _ConfigManager = null;
        
        void menuItemConfigManager_Click(object sender, EventArgs e)
        {
            //사용자UI 관리

            if (_ConfigManager == null)
            {
                _ConfigManager = new acGridViewUserConfigManager(this);

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
        //private acGridViewUserCustomReportManager _CustomExcelManager = null;
        void menuItemCustomReportManager_Click(object sender, EventArgs e)
        {
            try
            {
                acGridViewUserCustomReportManager customExcelManager = new acGridViewUserCustomReportManager(this);
                customExcelManager.ParentControl = new Control();
                customExcelManager.ParentControl.Name = this.ParentControl.Name + "." + this.Name;
                customExcelManager.FormClosed += new FormClosedEventHandler(ReportManager_FormClosed);
                customExcelManager.ShowDialog();
                
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void _ConfigManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ConfigManager.Dispose();
            _ConfigManager = null;
        }

        void ReportManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            (this.GridControl as acGridControl).GetLoadUserCustomReport();
        }

        /// <summary>
        /// 에디터를 종료한다.
        /// </summary>
        public void EndEditor()
        {
            this.CloseEditor();
            this.UpdateCurrentRow();
        }


        public void ExpandMasterAllRow()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                this.ExpandMasterRow(i);
            }

        }




        /// <summary>
        /// BestFitColumns 기능을 쓰레드로 처리한다.
        /// </summary>
        public void BestFitColumnsThread()
        {

            QGridViewBestFitColumns quickBestFit = new QGridViewBestFitColumns();

            quickBestFit.ExecuteBestFit(_ParentControl, this, QuickBestFitColumns);

        }

        private void QuickExportTo(string fileName, TimeSpan executeTime)
        {
            //파일을 여시겠습니까?


            try
            {
                System.Diagnostics.Process.Start(fileName);

                //if (acMessageBox.Show(this.ParentControl, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                //{
                //    System.Diagnostics.Process.Start(fileName);
                //}
            }
            catch (Exception ex)
            {

                acMessageBox.Show(ex.Message, (this.ParentControl as BaseMenu).Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }


        }

        private void QuickBestFitColumns(TimeSpan executeTime)
        {

        }


        void menuItemAlwaysBestFit_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this._Config.AlwaysBestFit = item.Checked;

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

            //DataSet dsResult = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

            //QuickUse(dsResult);

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

        //void QuickUse(DataSet ds)
        //{
        //    try
        //    {
        //        if (ds.Tables["RQSTDT"].Rows.Count > 0)
        //        {
        //            this._Config.ConfigName = (string)ds.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
        //            this._Config.ConfigMaKer = (string)ds.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this.ParentControl, ex);
        //    }
        //}

        void QuickUse(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RQSTDT"].Rows.Count > 0)
                {

                    this._Config.ConfigName = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];

                }
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


        acGridViewUserConfigLoadEditor _LoadConfig = null;


        void menuItemConfigLoad_Click(object sender, EventArgs e)
        {

            if (this._LoadConfig == null)
            {
                _LoadConfig = new acGridViewUserConfigLoadEditor(this);

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

        void _LoadConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LoadConfig = null;
        }

        void menuItemConfigOtherSave_Click(object sender, EventArgs e)
        {
            acGridViewUserConfigSaveEditor frm = new acGridViewUserConfigSaveEditor(this);

            frm.ParentControl = new Control();

            frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

            frm.ShowDialog();


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

                //BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

            }
            else
            {
                acGridViewUserConfigSaveEditor frm = new acGridViewUserConfigSaveEditor(this);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.ShowDialog();


            }
        }

        void menuItemConfigSave_Click(object sender, EventArgs e)
        {
            this.SaveUserConfig();

        }

        void menuItemFooter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowFooter = item.Checked;
        }
        void menuItemGroupFooter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this._ShowGroupFooter = item.Checked;

            if (_ShowGroupFooter == true)
            {
                this.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            else
            {
                this.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            }
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

            //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE_DEL(paramSet);

            acGridControl acData = (acGridControl)this.GridControl;

            this._Config.Load(null, null, acData._SystemLayout, acData._SystemConfig);

        }

        void QuickUseDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridControl acData = (acGridControl)this.GridControl;

                this._Config.Load(null, null, acData._SystemLayout, acData._SystemConfig);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        acGridViewStyleBox _StyleBox = null;

        void menuItemStyleBox_Click(object sender, EventArgs e)
        {

            if (this._StyleBox == null)
            {

                _StyleBox = new acGridViewStyleBox(this);

                _StyleBox.ParentControl = new Control();

                _StyleBox.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                _StyleBox.FormClosed += new FormClosedEventHandler(_StyleBox_FormClosed);


                _StyleBox.Show();

            }
            else
            {
                _StyleBox.Focus();
            }

        }

        void _StyleBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._StyleBox = null;
        }


        void menuItemShowColumnHeader_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowColumnHeaders = item.Checked;

        }

        void menuItemShowRowNum_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this.OptionsView.ShowIndicator = item.Checked;

        }

        void menuItemFixedRight_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.Fixed = FixedStyle.Right;
            }
            else if (item.Checked == false)
            {
                col.Fixed = FixedStyle.None;
            }
        }

        void menuItemFixedLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.Fixed = FixedStyle.Left;
            }
            else if (item.Checked == false)
            {
                col.Fixed = FixedStyle.None;
            }

        }

        void menuItemAlignRight_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
        }

        void menuItemAlignCenter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        void menuItemAlignLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;

        }

        void menuItemMerge_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acGridColumn col = (acGridColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                this.OptionsView.AllowCellMerge = true;


            }
            else if (item.Checked == false)
            {
                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                this.OptionsView.AllowCellMerge = false;
            }

        }




        public void SaveGridViewToFile(QGridViewExportTo.emSaveFileType saveFileType)
        {


            try
            {

                this.OptionsPrint.PrintHeader = true;

                this.OptionsPrint.PrintHorzLines = true;
                this.OptionsPrint.PrintVertLines = true;

                this.OptionsPrint.AutoWidth = false;

                this.OptionsPrint.UsePrintStyles = true;


                SaveFileDialog saveDlg = new SaveFileDialog();


                QGridViewExportTo export = new QGridViewExportTo(_ParentControl);


                saveDlg.FileName = _SaveFileName;

                switch (saveFileType)
                {
                    case QGridViewExportTo.emSaveFileType.Excel:

                        saveDlg.Filter = acInfo.Resource.GetString("Excel 97 - 2003 통합 문서 (*.xls)|*.xls", "N5ZM3KM1");

                        break;

                    //case QGridViewExportTo.emSaveFileType.ExcelMerge:

                    //    saveDlg.Filter = acInfo.Resource.GetString("Excel 97 - 2003 통합 문서 (*.xls)|*.xls", "N5ZM3KM1");

                    //    break;

                    //case QGridViewExportTo.emSaveFileType.ExcelCustomMerge:

                    //    saveDlg.Filter = acInfo.Resource.GetString("Excel 97 - 2003 통합 문서 (*.xls)|*.xls", "N5ZM3KM1");

                    //    break;

                    case QGridViewExportTo.emSaveFileType.Xlsx:

                        saveDlg.Filter = acInfo.Resource.GetString("Excel 통합 문서 (*.xlsx)|*.xlsx", "N5ZM3KM2");

                        break;

                    case QGridViewExportTo.emSaveFileType.HTML:

                        saveDlg.Filter = acInfo.Resource.GetString("모든 웹페이지 (*.htm;*.html)|*.htm;*.html", "LYLGYIJ5");


                        break;

                    case QGridViewExportTo.emSaveFileType.PDF:

                        saveDlg.Filter = acInfo.Resource.GetString("Adobe Acrobat PDF 문서(*.pdf)|*.pdf", "L923N2Y4");

                        break;

                    case QGridViewExportTo.emSaveFileType.RTF:

                        saveDlg.Filter = acInfo.Resource.GetString("서식 있는 텍스트(RTF)|*.rtf", "59JZKX42");

                        break;

                    case QGridViewExportTo.emSaveFileType.Text:

                        saveDlg.Filter = acInfo.Resource.GetString("텍스트 문서(*.txt)|*.txt", "J8XTLYPT");

                        break;

                    case QGridViewExportTo.emSaveFileType.MHT:

                        saveDlg.Filter = acInfo.Resource.GetString("웹페이지 보관파일(*.mht)|*.mht", "CX1ZDGAC");

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
                acMessageBox.Show(this.GridControl, ex);
            }

        }


        public void SaveGridViewToFile2(QGridViewExportTo.emSaveFileType saveFileType)
        {


            try
            {

                this.OptionsPrint.PrintHeader = true;

                this.OptionsPrint.PrintHorzLines = true;
                this.OptionsPrint.PrintVertLines = true;

                this.OptionsPrint.AutoWidth = false;

                this.OptionsPrint.UsePrintStyles = true;

                QGridViewExportTo export = new QGridViewExportTo(_ParentControl);

                SaveFileDialog saveDlg = new SaveFileDialog();

                ControlManager.BaseMenu menu = this.ParentControl as ControlManager.BaseMenu;

                string saveFilename = acInfo.GetTempSystemDirectory() + @"\" + menu.MenuName;

                #region
                //saveDlg.FileName = menu.Caption;

                switch (saveFileType)
                {
                    case QGridViewExportTo.emSaveFileType.Excel:
                        saveFilename = saveFilename + ".xls";
                        //saveDlg.Filter = acInfo.Resource.GetString("Excel 97 - 2003 통합 문서 (*.xls)|*.xls", "N5ZM3KM1");

                        break;

                    case QGridViewExportTo.emSaveFileType.Xlsx:
                        saveFilename = saveFilename + ".xlsx";
                        //saveDlg.Filter = acInfo.Resource.GetString("Excel 통합 문서 (*.xlsx)|*.xlsx", "N5ZM3KM2");

                        break;

                    case QGridViewExportTo.emSaveFileType.HTML:
                        saveFilename = saveFilename + ".html";
                        //saveDlg.Filter = acInfo.Resource.GetString("모든 웹페이지 (*.htm;*.html)|*.htm;*.html", "LYLGYIJ5");


                        break;

                    case QGridViewExportTo.emSaveFileType.PDF:
                        saveFilename = saveFilename + ".pdf";
                        //saveDlg.Filter = acInfo.Resource.GetString("Adobe Acrobat PDF 문서(*.pdf)|*.pdf", "L923N2Y4");

                        break;

                    case QGridViewExportTo.emSaveFileType.RTF:
                        saveFilename = saveFilename + ".rtf";
                        //saveDlg.Filter = acInfo.Resource.GetString("서식 있는 텍스트(RTF)|*.rtf", "59JZKX42");

                        break;

                    case QGridViewExportTo.emSaveFileType.Text:
                        saveFilename = saveFilename + ".txt";
                        //saveDlg.Filter = acInfo.Resource.GetString("텍스트 문서(*.txt)|*.txt", "J8XTLYPT");

                        break;

                    case QGridViewExportTo.emSaveFileType.MHT:
                        saveFilename = saveFilename + ".mht";
                        //saveDlg.Filter = acInfo.Resource.GetString("웹페이지 보관파일(*.mht)|*.mht", "CX1ZDGAC");

                        break;

                }


                //if (saveDlg.ShowDialog() == DialogResult.OK)
                //{
                //    export.ExecuteExportTo(this,
                //        saveFileType,
                //        saveDlg.FileName,
                //        QuickExportTo);
                //}
                #endregion
                export.ExecuteExportTo(this,
                        saveFileType,
                        saveFilename,
                        QuickExportTo);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.GridControl, ex);
            }

        }







        /// <summary>
        /// Mht 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToMht_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.MHT);

        }


        /// <summary>
        /// Html 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToHtml_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.HTML);


        }

        /// <summary>
        /// RTF 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToRTF_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.RTF);


        }


        /// <summary>
        /// 텍스트 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToText_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Text);


        }

        /// <summary>
        /// PDF 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToPDF_Click(object sender, EventArgs e)
        {

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.PDF);

        }


        /// <summary>
        /// Excel 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToExcel_Click(object sender, EventArgs e)
        {

            //this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.ExcelCustomMerge);
            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Excel);
        }

        /// <summary>
        /// Xlsx 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItemToXlsx_Click(object sender, EventArgs e)
        {
            //this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Xlsx);
            this.SaveGridViewToFile2(QGridViewExportTo.emSaveFileType.Xlsx);
        }




        /// <summary>
        /// 필터에 해당되는 첫번째 로우를 반환합니다.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataRow GetDataRow(string filter)
        {


            DataView view = this.GetDataSourceView(filter);

            if (view.Count > 0)
            {

                return view[0].Row;
            }
            else
            {
                return null;
            }

        }


        /// <summary>
        /// KeyColumn에 매칭되는 Row를 삭제한다.
        /// </summary>
        /// <param name="row"></param>
        public bool DeleteMappingRow(DataRow delrow)
        {
            try
            {

                this.ConvertColumnType(delrow.Table);
                DataTable data = delrow.Table.Copy();
                DataRow row = data.NewRow();
                row.ItemArray = delrow.ItemArray;

                DataView view = (DataView)this.GetDataView();


                for (int i = 0; i < view.Count; i++)
                {
                    DataRowView rowView = view[i];

                    bool isFindRow = true;

                    foreach (string keyColumn in this._KeyColumn)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {
                            object value = Convert.ChangeType(row[keyColumn], rowView.Row[keyColumn].GetType());

                            if (!rowView.Row[keyColumn].Equals(value))
                            {
                                isFindRow = false;

                                break;
                            }
                        }
                    }

                    //매칭되는 Row 찾음
                    if (isFindRow == true)
                    {

                        //DataRow delRow = this.GetDataRow(i);
                        DataRow delRow = rowView.Row;

                        DataRow delRowCopy = delRow.NewCopy();

                        this.DeleteRow(i);

                        if (this.OnMapingRowChanged != null)
                        {
                            this.OnMapingRowChanged(emMappingRowChangedType.DELETE, delRowCopy);
                        }

                        return true;
                    }
                }


                return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// KeyColumn에 매칭되는 Row를 삭제한다.(Linq)
        /// </summary>
        /// <param name="row"></param>
        public bool DeleteMappingRowLinq(DataTable delDT)
        {
            try
            {
                this.AcceptChanges();

                if (delDT == null || delDT.Rows.Count == 0)
                {
                    return true;
                }

                this.BeginUpdate();

                //지울데이터가 있는 Table
                DataTable oriDT = this.GridControl.DataSource as DataTable;

                //키가 각 테이블에 존재하는지 체크 하나라도 없으면 실패 반환
                foreach (string keyColumn in this._KeyColumn)
                {
                    if (oriDT.Columns.Contains(keyColumn) == false || delDT.Columns.Contains(keyColumn) == false)
                    {
                        return false;
                    }
                }

                //키 비교를 동적으로 할수 없어서 Switch로 나눔
                switch (this._KeyColumn.Length)
                {
                    case 1:
                        {
                            var rsltDt = oriDT.AsEnumerable()
                                      .GroupJoin(delDT.AsEnumerable()
                                            , o => new { Key1 = o[this._KeyColumn[0]] }
                                            , d => new { Key1 = d[this._KeyColumn[0]] }
                                            , (o, d) => new { Ori = o, Del = d })
                                       .SelectMany(
                                            o => o.Del.DefaultIfEmpty(),
                                            (o, d) => new { Ori = o.Ori, Del = d })
                                       .Where(w => w.Del == null)   //LEFT JOIN 결과 DEL이 NULL인 것만 남긴다.(매칭된느것들은 삭제 대상)
                                       .Select(r => r.Ori);
                            if (rsltDt.Count() == 0) oriDT.Clear();
                            else this.GridControl.DataSource = rsltDt.CopyToDataTable();

                            return true;
                        }
                    case 2:
                        {
                            var rsltDt = oriDT.AsEnumerable()
                                      .GroupJoin(delDT.AsEnumerable()
                                            , d => new { Key1 = d[this._KeyColumn[0]], Key2 = d[this._KeyColumn[1]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]] }
                                            , (o, d) => new { Ori = o, Del = d })
                                       .SelectMany(
                                            o => o.Del.DefaultIfEmpty(),
                                            (o, d) => new { Ori = o.Ori, Del = d })
                                       .Where(w => w.Del == null)
                                       .Select(r => r.Ori);

                            if (rsltDt.Count() == 0) oriDT.Clear();
                            else this.GridControl.DataSource = rsltDt.CopyToDataTable();
                            return true;
                        }
                    case 3:
                        {
                            var rsltDt = oriDT.AsEnumerable()
                                      .GroupJoin(delDT.AsEnumerable()
                                            , d => new { Key1 = d[this._KeyColumn[0]], Key2 = d[this._KeyColumn[1]], Key3 = d[this._KeyColumn[2]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]] }
                                            , (o, d) => new { Ori = o, Del = d })
                                       .SelectMany(
                                            o => o.Del.DefaultIfEmpty(),
                                            (o, d) => new { Ori = o.Ori, Del = d })
                                       .Where(w => w.Del == null)
                                       .Select(r => r.Ori);
                            if (rsltDt.Count() == 0) oriDT.Clear();
                            else this.GridControl.DataSource = rsltDt.CopyToDataTable();
                            return true;
                        }
                    case 4:
                        {
                            var rsltDt = oriDT.AsEnumerable()
                                      .GroupJoin(delDT.AsEnumerable()
                                            , d => new { Key1 = d[this._KeyColumn[0]], Key2 = d[this._KeyColumn[1]], Key3 = d[this._KeyColumn[2]], Key4 = d[this._KeyColumn[3]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]], Key4 = o[this._KeyColumn[3]] }
                                            , (o, d) => new { Ori = o, Del = d })
                                       .SelectMany(
                                            o => o.Del.DefaultIfEmpty(),
                                            (o, d) => new { Ori = o.Ori, Del = d })
                                       .Where(w => w.Del == null)
                                       .Select(r => r.Ori);
                            if (rsltDt.Count() == 0) oriDT.Clear();
                            else this.GridControl.DataSource = rsltDt.CopyToDataTable();
                            return true;
                        }
                    case 5:
                        {
                            var rsltDt = oriDT.AsEnumerable()
                                      .GroupJoin(delDT.AsEnumerable()
                                            , d => new { Key1 = d[this._KeyColumn[0]], Key2 = d[this._KeyColumn[1]], Key3 = d[this._KeyColumn[2]], Key4 = d[this._KeyColumn[3]], Key5 = d[this._KeyColumn[4]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]], Key4 = o[this._KeyColumn[3]], Key5 = o[this._KeyColumn[4]] }
                                            , (o, d) => new { Ori = o, Del = d })
                                       .SelectMany(
                                            o => o.Del.DefaultIfEmpty(),
                                            (o, d) => new { Ori = o.Ori, Del = d })
                                       .Where(w => w.Del == null)
                                       .Select(r => r.Ori);
                            if (rsltDt.Count() == 0) oriDT.Clear();
                            else this.GridControl.DataSource = rsltDt.CopyToDataTable();
                            return true;
                        }
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.EndUpdate();
            }
        }
        public void ResetGridRowSeq()
        {

            DataTable dt = this.GridControl.DataSource as DataTable;

            int rowSeq = 0;

            foreach (DataRow row in dt.Rows)
            {
                row["GRID_ROW_SEQ"] = rowSeq;

                ++rowSeq;
            }
        }


        public enum emMappingRowChangedType { ADD, MODIFY, DELETE }

        public delegate void MapingRowChangedEventHandler(emMappingRowChangedType type, DataRow row);

        public event MapingRowChangedEventHandler OnMapingRowChanged;


        public delegate void InitLayoutEventHandler(object sender);

        public event InitLayoutEventHandler OnInitLayout;

        internal void RaiseInitLayout()
        {
            if (this.OnInitLayout != null)
            {
                this.OnInitLayout(this);
            }
        }




        public DataTable CopyNewTable()
        {
            DataTable dt = this.GridControl.DataSource as DataTable;

            if (dt != null)
            {

                DataTable newDt = dt.Clone();

                foreach (DataRow row in dt.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = newDt.NewRow();

                        newRow.ItemArray = row.ItemArray;

                        newDt.Rows.Add(newRow);

                    }
                }

                return newDt;

            }

            return null;
        }


        public DataTable NewTable()
        {
            DataView view = this.GetDataSourceView();


            return view.Table.Clone();



        }



        /// <summary>
        /// 새로운 Row 를 반환한다. GriView에 추가하지는않는다.
        /// </summary>
        /// <returns></returns>
        public DataRow NewRow()
        {

            DataView view = this.GetDataSourceView();


            return view.Table.Copy().NewRow();

        }




        /// <summary>
        /// Row를 추가한다.
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(DataRow row)
        {

            if (this._KeyColumn.Length != 0)
            {


                DataView view = (DataView)this.GetDataSourceView();

                bool isFindRow = true;

                int findRowHandle = 0;

                if (view.Count > 0)
                {
                    for (int i = 0; i < view.Count; i++)
                    {
                        DataRowView rowView = view[i];

                        foreach (string keyColumn in this._KeyColumn)
                        {
                            if (!rowView.Row[keyColumn].Equals(row[keyColumn]))
                            {
                                isFindRow = false;

                                break;

                            }


                        }


                        if (isFindRow == true)
                        {
                            break;
                        }


                    }
                }
                else
                {
                    isFindRow = false;
                }


                if (isFindRow == true)
                {

                    //KeyColumn과 매칭되는 행 찾음

                    this.FocusedRowHandle = findRowHandle;


                }
                else
                {
                    //KeyColumn 를 찾을수없을때 추가

                    this._AddRow(row);

                }

            }
            else
            {
                //KeyColumn이 없으면 추가

                this._AddRow(row);
            }


        }
                
        /// <summary>
        /// Row를 추가한다.
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(DataRow row, bool bFindKey)
        {

            if (this._KeyColumn.Length != 0)
            {


                DataView view = (DataView)this.GetDataSourceView();

                bool isFindRow = true;

                int findRowHandle = 0;

                if (view.Count > 0 && bFindKey)
                {
                    for (int i = 0; i < view.Count; i++)
                    {
                        DataRowView rowView = view[i];

                        foreach (string keyColumn in this._KeyColumn)
                        {
                            if (!rowView.Row[keyColumn].Equals(row[keyColumn]))
                            {
                                isFindRow = false;

                                break;

                            }


                        }


                        if (isFindRow == true)
                        {
                            break;
                        }


                    }
                }
                else
                {
                    isFindRow = false;
                }


                if (isFindRow == true)
                {

                    //KeyColumn과 매칭되는 행 찾음

                    this.FocusedRowHandle = findRowHandle;


                }
                else
                {
                    //KeyColumn 를 찾을수없을때 추가

                    this._AddRow(row);

                }

            }
            else
            {
                //KeyColumn이 없으면 추가

                this._AddRow(row);
            }


        }

        private void ConvertColumnType(DataTable dt)
        {
            Dictionary<string, Type> list = new Dictionary<string, Type>();

            foreach (DataColumn col in dt.Columns)
            {
                acGridColumn acCol = (acGridColumn)this.Columns[col.ColumnName];

                if (acCol != null)
                {

                    if (acCol.EditorType == acGridView.emEditorType.DATE)
                    {
                        if (col.DataType != typeof(DateTime))
                        {

                            list.Add(col.ColumnName, typeof(DateTime));

                        }
                    }
                    else if (acCol.EditorType == acGridView.emEditorType.LOOKUP_CODE)
                    {
                        if (col.DataType != typeof(string))
                        {

                            list.Add(col.ColumnName, typeof(string));

                        }
                    }
                }

            }


            foreach (KeyValuePair<string, Type> col in list)
            {
                dt.Columns.Add(col.Key + "_temp", Type.GetType(col.Value.FullName));
            }




            foreach (KeyValuePair<string, Type> col in list)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Type.GetType(col.Value.FullName) == typeof(DateTime))
                    {
                        row[col.Key + "_temp"] = row[col.Key].isNull() ? (object)DBNull.Value : (object)row[col.Key].toDateTime();
                    }
                    else if (Type.GetType(col.Value.FullName) == typeof(string))
                    {
                        row[col.Key + "_temp"] = row[col.Key].isNull() ? (object)DBNull.Value : (object)row[col.Key].ToString();
                    }

                }


            }



            foreach (KeyValuePair<string, Type> col in list)
            {
                dt.Columns.Remove(col.Key);
                dt.Columns[col.Key + "_temp"].ColumnName = col.Key;

            }

        }


        public DataRow _AddRow(DataRow row)
        {


            this.AddNewRow();


            if (row != null)
            {


                //Row 변환작업

                this.ConvertColumnType(row.Table);


                DataView addView = (DataView)this.DataSource;


                foreach (DataColumn col in row.Table.Columns)
                {
                    if (addView[addView.Count - 1].Row.Table.Columns.Contains(col.ColumnName))
                    {

                        addView[addView.Count - 1].Row[col.ColumnName] = row[col.ColumnName];

                    }



                }

                addView[addView.Count - 1].Row["GRID_ROW_SEQ"] = this.RowCount + 1;


                this.UpdateCurrentRow();



                return addView[addView.Count - 1].Row;


            }

            return null;

        }

        /// <summary>
        /// KeyColumn에 매칭되는 Row를 수정한다.
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="notFindAdd">찾을수없을때 추가할지여부</param>
        public void UpdateMapingRow(DataRow newRow, bool notFindAdd)
        {

            try
            {
                this.ConvertColumnType(newRow.Table);

                DataTable data = newRow.Table.Copy();

                DataRow row = data.NewRow();

                row.ItemArray = newRow.ItemArray;



                DataView view = (DataView)this.GetDataView();


                for (int i = 0; i < view.Count; i++)
                {
                    DataRowView rowView = view[i];
                    
                    bool isFindRow = true;

                    foreach (string keyColumn in this._KeyColumn)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {
                            Type type = rowView.Row[keyColumn].GetType();

                            if (type == DBNull.Value.GetType())
                                type = typeof(string);

                            object value = Convert.ChangeType(row[keyColumn], type);

                            if (!rowView.Row[keyColumn].Equals(value))
                            {
                                isFindRow = false;

                                break;
                            }
                        }
                    }

                    //매칭되는 Row 찾음

                    if (isFindRow == true)
                    {
                        //DataRow viewRow = this.GetDataRow(i);
                        DataRow viewRow = rowView.Row;
                        foreach (DataColumn col in rowView.Row.Table.Columns)
                        {

                            if (row.Table.Columns.Contains(col.ColumnName) &&
                                view.Table.Columns.Contains(col.ColumnName)
                                )
                            {

                                viewRow[col.ColumnName] = row[col.ColumnName];
                            }

                        }

                        viewRow.AcceptChanges();

                        notFindAdd = false;

                    }


                }

                if (notFindAdd == true)
                {
                    row = this._AddRow(row);
                }



                if (this.OnMapingRowChanged != null)
                {
                    if (notFindAdd == true)
                    {
                        this.OnMapingRowChanged(emMappingRowChangedType.ADD, row);
                    }
                    else
                    {
                        this.OnMapingRowChanged(emMappingRowChangedType.MODIFY, row);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        /// <summary>
        /// KeyColumn에 매칭되는 Row를 수정한다.(Linq)
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="notFindAdd">찾을수없을때 추가할지여부</param>
        public bool UpdateMapingRowLinq(DataTable uDt, bool notFindAdd)
        {

            try
            {
                this.AcceptChanges();

                this.ConvertColumnType(uDt);

                this.BeginUpdate();

                //지울데이터가 있는 Table
                DataTable oriDT = this.GridControl.DataSource as DataTable;

                //키가 각 테이블에 존재하는지 체크 하나라도 없으면 실패 반환
                foreach (string keyColumn in this._KeyColumn)
                {
                    if (oriDT.Columns.Contains(keyColumn) == false || uDt.Columns.Contains(keyColumn) == false)
                    {
                        return false;
                    }
                }

                List<DataRow[]> innerDt = null;   //데이터 존재 (Update 대상)
                DataTable leftDt = null;    //데이터 없음 (Insert 대상)
                //키 비교를 동적으로 할수 없어서 Switch로 나눔
                switch (this._KeyColumn.Length)
                {
                    case 1:
                        {
                            var joinDt = uDt.AsEnumerable()
                                      .GroupJoin(oriDT.AsEnumerable()
                                            , u => new { Key1 = u[this._KeyColumn[0]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]] }
                                            , (u, o) => new { Upd = u, Ori = o })
                                       .SelectMany(
                                            x => x.Ori.DefaultIfEmpty(),
                                            (u, o) => new { Upd = u.Upd, Ori = o });
                            //.Where(w => w.Del == null)   //LEFT JOIN 결과 DEL이 NULL인 것만 남긴다.(매칭된느것들은 삭제 대상)
                            //.Select(r => r.Ori)
                            //.CopyToDataTable();

                            //업데이트 데이터와 원본 데이터가 매칭되는게 있다.
                            innerDt = joinDt.Where(w => w.Ori != null)
                                            .Select(r => new DataRow[] { r.Upd, r.Ori })
                                            .ToList<DataRow[]>();
                            //업데이트 데이터와 원본 데이터가 매칭되는게 없다.
                            leftDt = joinDt.Where(w => w.Ori == null)
                                           .Select(r => r.Upd)
                                           .CopyToDataTable();
                            break;
                        }
                    case 2:
                        {
                            var joinDt = uDt.AsEnumerable()
                                        .GroupJoin(oriDT.AsEnumerable()
                                            , u => new { Key1 = u[this._KeyColumn[0]], Key2 = u[this._KeyColumn[1]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]] }
                                            , (u, o) => new { Upd = u, Ori = o })
                                       .SelectMany(
                                            x => x.Ori.DefaultIfEmpty(),
                                            (u, o) => new { Upd = u.Upd, Ori = o });

                            //업데이트 데이터와 원본 데이터가 매칭되는게 있다.
                            innerDt = joinDt.Where(w => w.Ori != null)
                                             .Select(r => new DataRow[] { r.Upd, r.Ori })
                                            .ToList<DataRow[]>();
                            //업데이트 데이터와 원본 데이터가 매칭되는게 없다.
                            leftDt = joinDt.Where(w => w.Ori == null)
                                           .Select(r => r.Upd)
                                           .CopyToDataTable();
                            break;
                        }
                    case 3:
                        {
                            var joinDt = uDt.AsEnumerable()
                                        .GroupJoin(oriDT.AsEnumerable()
                                            , u => new { Key1 = u[this._KeyColumn[0]], Key2 = u[this._KeyColumn[1]], Key3 = u[this._KeyColumn[2]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]] }
                                            , (u, o) => new { Upd = u, Ori = o })
                                       .SelectMany(
                                            x => x.Ori.DefaultIfEmpty(),
                                            (u, o) => new { Upd = u.Upd, Ori = o });

                            //업데이트 데이터와 원본 데이터가 매칭되는게 있다.
                            innerDt = joinDt.Where(w => w.Ori != null)
                                             .Select(r => new DataRow[] { r.Upd, r.Ori })
                                            .ToList<DataRow[]>();
                            //업데이트 데이터와 원본 데이터가 매칭되는게 없다.
                            leftDt = joinDt.Where(w => w.Ori == null)
                                           .Select(r => r.Upd)
                                           .CopyToDataTable();
                            break;
                        }
                    case 4:
                        {
                            var joinDt = uDt.AsEnumerable()
                                        .GroupJoin(oriDT.AsEnumerable()
                                            , u => new { Key1 = u[this._KeyColumn[0]], Key2 = u[this._KeyColumn[1]], Key3 = u[this._KeyColumn[2]], Key4 = u[this._KeyColumn[3]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]], Key4 = o[this._KeyColumn[3]] }
                                            , (u, o) => new { Upd = u, Ori = o })
                                       .SelectMany(
                                            x => x.Ori.DefaultIfEmpty(),
                                            (u, o) => new { Upd = u.Upd, Ori = o });

                            //업데이트 데이터와 원본 데이터가 매칭되는게 있다.
                            innerDt = joinDt.Where(w => w.Ori != null)
                                             .Select(r => new DataRow[] { r.Upd, r.Ori })
                                            .ToList<DataRow[]>();
                            //업데이트 데이터와 원본 데이터가 매칭되는게 없다.
                            leftDt = joinDt.Where(w => w.Ori == null)
                                           .Select(r => r.Upd)
                                           .CopyToDataTable();
                            break;
                        }
                    case 5:
                        {
                            var joinDt = uDt.AsEnumerable()
                                        .GroupJoin(oriDT.AsEnumerable()
                                            , u => new { Key1 = u[this._KeyColumn[0]], Key2 = u[this._KeyColumn[1]], Key3 = u[this._KeyColumn[2]], Key4 = u[this._KeyColumn[3]], Key5 = u[this._KeyColumn[4]] }
                                            , o => new { Key1 = o[this._KeyColumn[0]], Key2 = o[this._KeyColumn[1]], Key3 = o[this._KeyColumn[2]], Key4 = o[this._KeyColumn[3]], Key5 = o[this._KeyColumn[4]] }
                                            , (u, o) => new { Upd = u, Ori = o })
                                       .SelectMany(
                                            x => x.Ori.DefaultIfEmpty(),
                                            (u, o) => new { Upd = u.Upd, Ori = o });

                            //업데이트 데이터와 원본 데이터가 매칭되는게 있다.
                            innerDt = joinDt.Where(w => w.Ori != null)
                                            .Select(r => new DataRow[] { r.Upd, r.Ori })
                                            .ToList<DataRow[]>();
                            //업데이트 데이터와 원본 데이터가 매칭되는게 없다.
                            leftDt = joinDt.Where(w => w.Ori == null)
                                           .Select(r => r.Upd)
                                           .CopyToDataTable();

                            break;
                        }
                    default:
                        return false;
                }


                //update
                foreach (DataRow[] rows in innerDt)
                {
                    foreach (DataColumn col in oriDT.Columns)
                    {
                        if (rows[0].Table.Columns.Contains(col.ColumnName))
                        {
                            rows[1][col] = rows[0][col.ColumnName];
                        }
                    }

                    if (this.OnMapingRowChanged != null)
                    {
                        this.OnMapingRowChanged(emMappingRowChangedType.MODIFY, rows[1]);
                    }
                }

                if (notFindAdd)
                {
                    //insert
                    foreach (DataRow row in leftDt.Rows)
                    {
                        DataRow nRow = oriDT.NewRow();

                        foreach (DataColumn col in oriDT.Columns)
                        {
                            if (row.Table.Columns.Contains(col.ColumnName))
                            {
                                nRow[col] = row[col.ColumnName];
                            }
                        }
                        
                        if(oriDT.Columns.Contains("SEL"))
                        {
                            nRow["SEL"] = null;
                        }

                        oriDT.Rows.Add(nRow);

                        if (this.OnMapingRowChanged != null)
                        {
                            this.OnMapingRowChanged(emMappingRowChangedType.ADD, nRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.EndUpdate();
            }

            return true;
        }

        private int GetRowSeqHandle(int gridRowSeq)
        {
            DataView view = this.GetDataView();

            for (int i = 0; i < view.Count; i++)
            {
                if (view[i]["GRID_ROW_SEQ"].EqualsEx(gridRowSeq))
                {

                    return i;
                }

            }

            return -1;

        }


        private DXValidationProvider _ValidProvider = new DXValidationProvider();


        public bool ValidCheck()
        {
            return ValidCheck(string.Empty);
        }
        /// <summary>
        /// 유효성을 검사한다.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool ValidCheck(string filter)
        {


            DataView view = this.GetDataSourceView(filter);

            DataRow validRow = null;
            string validcolumnName = null;

            foreach (acGridColumn col in this.Columns)
            {
                if (col.IsRequired == true)
                {
                    for (int i = 0; i < view.Count; i++)
                    {
                        if (acChecker.isNull(view[i][col.FieldName]))
                        {
                            validcolumnName = col.FieldName;
                            validRow = view[i].Row;

                            break;
                        }

                    }


                    if (validRow != null)
                    {
                        break;
                    }
                }
            }


            if (validRow != null)
            {
                int validRowIdx = this.GetRowSeqHandle(validRow["GRID_ROW_SEQ"].toInt());

                if (validRowIdx != -1)
                {
                    //View에 보임

                    this.FocusedColumn = this.Columns[validcolumnName];

                    this.FocusedRowHandle = validRowIdx;

                    this.ShowEditor();

                    acGridViewValidationRule validRule = new acGridViewValidationRule();

                    validRule.ErrorType = ErrorType.Warning;

                    validRule.ErrorText = acInfo.Resource.GetString("필수 항목입니다.", "5AAPUVJM");

                    this._ValidProvider.SetValidationRule(this.ActiveEditor, validRule);

                    this._ValidProvider.Validate();

                    return false;

                }
                else
                {
                    //필터링으로 View에 보이지않음

                    acMessageBox.Show(this.ParentControl, "필터링 기능으로 인하여 보이지않는데이터에 필수항목이 누락된 데이터가 존재합니다.", "QC5DHTBA",
                        true, acMessageBox.emMessageBoxType.CONFIRM);

                    return false;
                }
            }


            return true;

        }


        /// <summary>
        /// 특정컬럼의 합계를 구한다.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public decimal GetDataSum(string columnName)
        {
            try
            {
                DataView view = this.GetDataSourceView();

                var sum = (0).toDecimal();

                switch (view.ToTable().Columns[columnName].DataType.ToString())
                {
                    case "System.Decimal":
                        sum = view.ToTable().AsEnumerable().Sum(x => x.Field<decimal>(columnName));
                        break;
                    case "System.Int32":
                        sum = view.ToTable().AsEnumerable().Sum(x => x.Field<int>(columnName)).toDecimal();
                        break;
                    case "System.Double":
                        sum = view.ToTable().AsEnumerable().Sum(x => x.Field<double>(columnName)).toDecimal();
                        break;
                    default:
                        sum = view.ToTable().AsEnumerable().Sum(x => x.Field<decimal>(columnName));
                        break;
                }
                return sum;

            }
            catch (Exception ex)
            {

                return 0;

            }
        }


        /// <summary>
        /// 데이터뷰 특정컬럼의 합계를 구한다.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public decimal GetViewSum(string columnName)
        {

            try
            {
                var sum = this.GetDataView().ToTable().AsEnumerable().Sum(x => x.Field<decimal>(columnName));

                return sum;

            }
            catch
            {

                return 0;

            }
        }


        /// <summary>
        /// 포커스행의 유효성 검사를 한다.
        /// </summary>
        /// <returns></returns>
        public bool ValidFocusRowHandle()
        {
            if (this.FocusedRowHandle >= 0)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 추가되거나 수정된 행을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAddModifyRows()
        {
            DataTable data = (DataTable)this.GridControl.DataSource;

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
        /// 변경되거나 삭제행을 모두 커밋합니다.
        /// </summary>
        public void AcceptChanges()
        {
            acGridControl grid = this.GridControl as acGridControl;

            ((DataTable)grid.DataSource).AcceptChanges();


        }

        public void RejectChanges()
        {
            acGridControl grid = this.GridControl as acGridControl;

            ((DataTable)grid.DataSource).RejectChanges();


        }



        /// <summary>
        /// 모든행을 제거한다.
        /// </summary>
        public void ClearRow()
        {
            int rowCnt = this.RowCount;

            for (int i = 0; i < rowCnt; i++)
            {
                this.DeleteRow(0);
            }

        }
        public void ClearRow(string filter)
        {

            DataTable selected = this.GetDataSourceView(filter).ToTable();

            foreach (DataRow row in selected.Rows)
            {
                this.DeleteMappingRow(row);
            }

        }


        public DataRow GetRow(string filter)
        {
            DataView view = this.GetDataSourceView(filter);

            if (view.Count == 1)
            {
                return view[0].Row;
            }
            else
            {
                return null;
            }

        }

        public void FocusMappingRow(DataRow row)
        {
            DataView view = (DataView)this.GetDataView();

            for (int i = 0; i < view.Count; i++)
            {
                DataRowView rowView = view[i];

                bool isFindRow = true;

                foreach (string keyColumn in this._KeyColumn)
                {
                    object value = Convert.ChangeType(row[keyColumn], rowView.Row[keyColumn].GetType());


                    if (!rowView.Row[keyColumn].Equals(value))
                    {
                        isFindRow = false;

                        break;
                    }

                }

                //매칭되는 Row 찾음

                if (isFindRow == true)
                {

                    this.FocusedRowHandle = i;

                    return;

                }

            }
        }




        /// <summary>
        /// 컬럼필터를 설정한다.
        /// </summary>
        /// <param name="columnName"></param>
        public void SetColumnFilter(string columnName, object value)
        {

            this.ActiveFilter.Clear();


            GridColumn col = this.Columns[columnName];

            string filterString = null;


            if (value.isNull())
            {
                filterString = string.Format("[{0}] Is Null", col.FieldName);
            }
            else
            {

                filterString = string.Format("[{0}] = '{1}'", col.FieldName, value.ToString());
            }


            ColumnFilterInfo colFilterInfo = new ColumnFilterInfo(filterString);


            ViewColumnFilterInfo viewColFilter = new DevExpress.XtraGrid.Views.Base.ViewColumnFilterInfo(col, colFilterInfo);


            col.FilterInfo = colFilterInfo;

        }


        /// <summary>
        /// 드래그 드랍 형태
        /// </summary>
        public enum emFocusRowImageType
        {

            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 추가
            /// </summary>
            ADD,

            /// <summary>
            /// 이동
            /// </summary>
            MOVE
        };


        /// <summary>
        /// 현재 포커스된 로우 이미지를 반환한다.
        /// </summary>
        /// <returns></returns>
        public Bitmap GetFocusRowImage(emFocusRowImageType focusRowImageType)
        {
            GridViewInfo info = this.GetViewInfo() as GridViewInfo;



            GridRowInfo rowInfo = info.GetGridRowInfo(this.FocusedRowHandle);

            if (rowInfo != null)
            {


                if (focusRowImageType == emFocusRowImageType.NONE)
                {
                    Bitmap bmp = new Bitmap(rowInfo.DataBounds.Width, rowInfo.DataBounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Graphics gp = Graphics.FromImage(bmp);

                    Point pt = this.GridControl.PointToScreen(new Point(rowInfo.DataBounds.X, rowInfo.DataBounds.Y));

                    gp.CopyFromScreen(pt.X, pt.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    return bmp;

                }
                else if (focusRowImageType == emFocusRowImageType.ADD)
                {

                    Image typeImage = ControlManager.Resource.add_x16;

                    Bitmap bmp = new Bitmap(rowInfo.DataBounds.Width + typeImage.Width, rowInfo.DataBounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Graphics gp = Graphics.FromImage(bmp);

                    Point pt = this.GridControl.PointToScreen(new Point(rowInfo.DataBounds.X, rowInfo.DataBounds.Y));

                    gp.CopyFromScreen(pt.X, pt.Y, typeImage.Width, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    gp.DrawImage(typeImage, 0, 0, typeImage.Width, typeImage.Height);

                    return bmp;

                }
                else if (focusRowImageType == emFocusRowImageType.MOVE)
                {

                    Image typeImage = ControlManager.Resource.edit_redo_x16;

                    Bitmap bmp = new Bitmap(rowInfo.DataBounds.Width + typeImage.Width, rowInfo.DataBounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Graphics gp = Graphics.FromImage(bmp);

                    Point pt = this.GridControl.PointToScreen(new Point(rowInfo.DataBounds.X, rowInfo.DataBounds.Y));

                    gp.CopyFromScreen(pt.X, pt.Y, typeImage.Width, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    gp.DrawImage(typeImage, 0, 0, typeImage.Width, typeImage.Height);

                    return bmp;


                }


                return null;


            }
            else
            {
                return null;
            }



        }

        private int _CarretPosition = 0;


        /// <summary>
        /// 현재 활성화된 에디터 위치를 저장한다.
        /// </summary>
        public void SaveActiveEditorCaretPosition()
        {

            if (this.ActiveEditor is TextEdit)
            {

                _CarretPosition = (this.ActiveEditor as TextEdit).SelectionStart;
            }

        }

        /// <summary>
        /// 저장된 에디터 위치를 설정한다.
        /// </summary>
        public void SetActiveEditorCaretPosition()
        {
            this.ShowEditor();

            if (this.ActiveEditor is TextEdit)
            {
                DevExpress.XtraEditors.TextEdit editor = this.ActiveEditor as TextEdit;

                editor.SelectionStart = _CarretPosition;

                editor.SelectionLength = 0;

            }

        }




        public void SetFocusCell(int rowHandle, string columnName)
        {
            this.FocusedRowHandle = rowHandle;

            this.FocusedColumn = this.Columns[columnName];
        }

        public DataRow[] GetSelectedDataRows()
        {
            int[] selectedIdxs = this.GetSelectedRows();

            List<DataRow> selectedRowList = new List<DataRow>();

            foreach (int i in selectedIdxs)
            {
                selectedRowList.Add(this.GetDataRow(i));
            }

            return selectedRowList.ToArray();

        }


        /// <summary>
        /// 데이터소스가 바뀌지전에 로우핸들로 설정합니다.
        /// </summary>
        /// <param name="raiseFocusedRowChanged">같은로우핸들일경우 로우변경이벤트를 발생시킬지여부 설정</param>
        public void SetOldFocusRowHandle(bool raiseFocusedRowChanged)
        {
            if (this.OldFocusRowHandle >= 0)
            {
                if (raiseFocusedRowChanged == true)
                {
                    if (this.FocusedRowHandle == this.OldFocusRowHandle)
                    {
                        this.RaiseFocusedRowChanged();
                    }
                }

                this.FocusedRowHandle = this.OldFocusRowHandle;

            }

        }

        public void SetValue(string filter, string columnName, object value)
        {
            DataView view = this.GetDataSourceView(filter);

            int cnt = view.Count;

            for (int i = 0; i < cnt; i++)
            {
                view[0][columnName] = value;

            }
        }

        public void SetValue(string columnName, object value)
        {
            DataView view = this.GetDataSourceView();

            for (int i = 0; i < view.Count; i++)
            {
                view[i].Row[columnName] = value;
            }
        }


        /// <summary>
        /// 현재(보여지고있는) 뷰 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataView GetDataView()
        {
            if (this.GridControl.DataSource == null)
            {
                this.GridControl.DataSource = this.DefaultTable;
            }


            return this.GetDataView(this.GridControl);


        }


        /// <summary>
        /// 현재(보여지고있는) 뷰에 추가적으로 필터를 적용하여 반환합니다.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataView GetDataView(string filter)
        {
            DataView view = this.GetDataSourceView(this.GridControl);

            if (view == null)
            {
                this.GridControl.DataSource = this.DefaultTable;

                view = this.GetDataView();
            }

            if (!string.IsNullOrEmpty(filter))
            {
                if (!string.IsNullOrEmpty(view.RowFilter))
                {
                    view.RowFilter = view.RowFilter + " And " + filter;
                }
                else
                {
                    view.RowFilter = filter;
                }
            }


            return view;

        }



        /// <summary>
        /// 원본뷰에  필터를 적용하여 반환합니다.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataView GetDataSourceView(string filter)
        {
            DataView view = this.GetDataSourceView(this.GridControl);

            if (view == null)
            {
                this.GridControl.DataSource = this.DefaultTable;

                view = this.GetDataSourceView(this.GridControl);
            }

            view.RowFilter = filter;

            return view;

        }


        public DataView GetDataSourceView()
        {
            if (this.GridControl.DataSource == null)
            {
                this.GridControl.DataSource = this.DefaultTable;
            }


            return this.GetDataSourceView(this.GridControl);


        }

        private DataView GetDataSourceView(GridControl gc)
        {
            DataView dv = null;

            if (gc.FocusedView != null && gc.FocusedView.DataSource != null)
            {
                ColumnView view = (ColumnView)gc.FocusedView;
                DataView current = (DataView)view.DataSource;

                string sortExpression = GetSortExpression(view);

                //create a new data view 
                dv = new DataView(current.Table);
                dv.Sort = sortExpression;


            }


            return dv;
        }


        private DataView GetDataView(GridControl gc)
        {
            DataView dv = null;

            if (gc.FocusedView != null && gc.FocusedView.DataSource != null)
            {
                ColumnView view = (ColumnView)gc.FocusedView;
                DataView current = (DataView)view.DataSource;

                //string filterExpression = GetFilterExpression(view);
                string filterExpression = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(view.ActiveFilterCriteria);
                string sortExpression = GetSortExpression(view);

                string currentFilter = current.RowFilter;

                //create a new data view 
                dv = new DataView(current.Table);
                dv.Sort = sortExpression;



                if (filterExpression != String.Empty)
                {
                    if (currentFilter != String.Empty)
                    {
                        currentFilter += " AND ";
                    }

                    currentFilter += filterExpression;
                }

                if (!currentFilter.Contains("IsNull"))
                {
                    if (!string.IsNullOrEmpty(currentFilter))
                    {
                        try
                        {
                            dv.RowFilter = "(" + currentFilter + ")";
                        }
                        catch { }

                    }
                }
                

            }


            return dv;
        }

        private string GetFilterExpression(ColumnView view)
        {
            string expression = String.Empty;

            if (view.ActiveFilter != null && view.ActiveFilterEnabled
                          && view.ActiveFilter.Expression != String.Empty)
            {
                expression = view.ActiveFilterCriteria.LegacyToString();


            }


            return expression;
        }

        private string GetSortExpression(ColumnView view)
        {
            string expression = String.Empty;

            string lastSortOrder = string.Empty;

            foreach (GridColumnSortInfo info in view.SortInfo)
            {

                expression += string.Format("[{0}]", info.Column.FieldName);

                if (info.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                {
                    expression += " DESC";

                    lastSortOrder = "DESC";

                }
                else
                {
                    expression += " ASC";

                    lastSortOrder = "ASC";

                }
                expression += ", ";

            }

            if (!string.IsNullOrEmpty(lastSortOrder))
            {
                expression += string.Format("[{0}] {1}", "GRID_ROW_SEQ", lastSortOrder);
            }

            return expression.TrimEnd(',', ' ');

        }




        /// <summary>
        /// 전체 체크 여부
        /// </summary>
        internal bool _AllCheked = false;


        void acGridView_Click(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;


            if (this._MouseDownArgs != null)
            {

                GridHitInfo hintInfo = gridView.CalcHitInfo(this._MouseDownArgs.Location);


                if (hintInfo.HitTest == GridHitTest.Column)
                {
                    #region 체크 타입은 정렬하지않고 전체선택 또는 해제합니다.


                    acGridColumn acCol = hintInfo.Column as acGridColumn;

                    if (acCol == null)
                    {
                        return;
                    }

                    //EditType이 체크면서 에디트 가능한 컬럼이면 전체선택 기능

                    if (acCol.EditorType == emEditorType.CHECK &&
                        acCol.OptionsColumn.AllowEdit == true)
                    {

                        DataView view = this.GetDataView(gridView.GridControl);

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


                        #region 모든 Row 체크로 변경

                        for (int i = 0; i < view.Count; i++)
                        {
                            DataRowView rowView = view[i];

                            rowView[hintInfo.Column.FieldName] = checkValue;

                            //이벤트 발생

                            this.RaiseCellValueChanging(new CellValueChangedEventArgs(i, hintInfo.Column, checkValue));

                            this.RaiseCellValueChanged(new CellValueChangedEventArgs(i, hintInfo.Column, checkValue));

                        }

                        #endregion

                        return;


                    }


                    #endregion

                }

            }


        }

        internal void nRaiseCellValueChanged(CellValueChangedEventArgs e)
        {
            this.RaiseCellValueChanged(e);
        }

        internal void nRaiseCellValueChanging(CellValueChangedEventArgs e)
        {
            this.RaiseCellValueChanging(e);
        }


        public enum emDateMask
        {

            /// <summary>
            /// 년월
            /// </summary>
            YEAR_DATE,

            /// <summary>
            /// 년월
            /// </summary>
            MONTH_DATE,

            /// <summary>
            /// 년월일
            /// </summary>
            SHORT_DATE,

            /// <summary>
            /// 년월일(yy-MM-dd)
            /// </summary>
            SHORT_DATE2,

            /// <summary>
            /// 년월일시분
            /// </summary>
            MEDIUM_DATE,

            /// <summary>
            /// 년월일시분
            /// </summary>
            MEDIUM_DATE2,

            /// <summary>
            /// 년월일시분
            /// </summary>
            LONG_DATE,
            /// <summary>
            /// 년월일시분초
            /// </summary>
            LONG_DATE2,

            /// <summary>
            /// 년월일시분초.밀리초(3)
            /// </summary>
            FULL_DATE,

            /// <summary>
            /// 년.월.일(YY.MM.DD)
            /// </summary>
            FMT_DATE,

            /// <summary>
            /// 분초
            /// </summary>
            MIN_DATE,

            /// <summary>
            /// 월일
            /// </summary>
            MONTH_DAY,

            HM_DATE
        };


        public void AddDateEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask, string ctr)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.DATE;


            if (!mask.isNullOrEmpty())
            {
                col.EditorData = mask;
            }

            _DefaultTable.Columns.Add(columnName, typeof(DateTime));

            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();

            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;


            if (!mask.isNullOrEmpty())
            {
                dateEdit.Mask.EditMask = mask;
            }

            if (!ctr.isNullOrEmpty())
            {
                CultureInfo culture = new CultureInfo(ctr);
                dateEdit.Mask.Culture = culture;
            }

            dateEdit.Mask.UseMaskAsDisplayFormat = true;

            dateEdit.Appearance.TextOptions.HAlignment = align;

            dateEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = dateEdit;


            this.Columns.Add(col);
        }



        public void AddDateEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.DATE_STRING;

            col.EditorData = mask;


            _DefaultTable.Columns.Add(columnName, typeof(DateTime));

            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();

            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;


            dateEdit.Mask.EditMask = mask;


            dateEdit.Mask.UseMaskAsDisplayFormat = true;

            dateEdit.Appearance.TextOptions.HAlignment = align;

            dateEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = dateEdit;


            this.Columns.Add(col);
        }


        public void AddDateEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emDateMask dateMask)
        {
            acGridColumn col = new acGridColumn();

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


            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.DATE;

            col.EditorData = dateMask;


            _DefaultTable.Columns.Add(columnName, typeof(DateTime));

            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();

            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;


            switch (dateMask)
            {
                case emDateMask.YEAR_DATE:

                    dateEdit.Mask.EditMask = "yyyy";

                    dateEdit.VistaCalendarInitialViewStyle = VistaCalendarInitialViewStyle.YearsGroupView;

                    dateEdit.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView;

                    break;

                case emDateMask.MONTH_DATE:

                    dateEdit.Mask.EditMask = "yyyy-MM";

                    break;


                case emDateMask.SHORT_DATE:

                    dateEdit.Mask.EditMask = "d";

                    break;

                case emDateMask.SHORT_DATE2:

                    dateEdit.Mask.EditMask = "yy-MM-dd";

                    break;

                case emDateMask.MEDIUM_DATE:

                    dateEdit.Mask.EditMask = "g";

                    break;

                case emDateMask.MEDIUM_DATE2:

                    dateEdit.Mask.EditMask = "yyyy-MM-dd HH:mm";

                    break;

                case emDateMask.LONG_DATE:

                    dateEdit.Mask.EditMask = "G";

                    break;

                case emDateMask.LONG_DATE2:

                    dateEdit.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";

                    break;

                case emDateMask.FULL_DATE:

                    dateEdit.Mask.EditMask = "yyyy-MM-dd HH:mm:ss.fff";

                    break;

                case emDateMask.FMT_DATE:

                    dateEdit.Mask.EditMask = "yy.MM.dd";
                    break;

                case emDateMask.MIN_DATE:

                    dateEdit.Mask.EditMask = "MM-dd HH:mm:ss";

                    break;

                case emDateMask.HM_DATE:

                    dateEdit.Mask.EditMask = "HH:mm";

                    break;
            }



            dateEdit.Mask.UseMaskAsDisplayFormat = true;

            dateEdit.Appearance.TextOptions.HAlignment = align;

            dateEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = dateEdit;


            this.Columns.Add(col);
        }



        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, RepositoryItem editItem)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.IsRequired = isRequired;

            col.EditorType = emEditorType.CUSTOM;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            editItem.Appearance.TextOptions.HAlignment = align;

            col.ColumnEdit = editItem;

            this.Columns.Add(col);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="resourceID"></param>
        /// <param name="useReSourceID"></param>
        /// <param name="hAlign"></param>
        /// <param name="vAlign"></param>
        /// <param name="allowEdit"></param>
        /// <param name="readOnly"></param>
        /// <param name="visible"></param>
        /// <param name="isRequired"></param>
        /// <param name="documentFormat">기본 Rtf로 할것</param>
        public void AddRitchEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool readOnly, bool visible, bool isRequired, DevExpress.XtraRichEdit.DocumentFormat documentFormat)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.VAlignment = vAlign;

            col.AppearanceCell.TextOptions.HAlignment = hAlign;


            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.MEMO;

            _DefaultTable.Columns.Add(columnName, typeof(string));


            RepositoryItemRichTextEdit richEdit = new RepositoryItemRichTextEdit();
            richEdit.DocumentFormat = documentFormat;
            if (documentFormat == DevExpress.XtraRichEdit.DocumentFormat.Html)
            {
                richEdit.Encoding = Encoding.UTF8;
            }
            richEdit.ReadOnly = readOnly;
            richEdit.EditValueChanging += new ChangingEventHandler(memoEdit_EditValueChanging);
            richEdit.Appearance.TextOptions.VAlignment = vAlign;
            richEdit.Appearance.TextOptions.HAlignment = hAlign;
            richEdit.Appearance.Options.UseTextOptions = true;
            col.ColumnEdit = richEdit;

            this.Columns.Add(col);
        }


        public void AddTimeEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.TIME;

            _DefaultTable.Columns.Add(columnName, typeof(DateTime));

            RepositoryItemTimeEdit timeEdit = new RepositoryItemTimeEdit();

            timeEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;

            timeEdit.Mask.EditMask = mask;

            timeEdit.Mask.UseMaskAsDisplayFormat = true;

            timeEdit.Appearance.TextOptions.HAlignment = align;

            timeEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = timeEdit;

            this.Columns.Add(col);
        }

        public void AddMemoEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool readOnly, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.VAlignment = vAlign;

            col.AppearanceCell.TextOptions.HAlignment = hAlign;


            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.MEMO;

            _DefaultTable.Columns.Add(columnName, typeof(string));



            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();

            memoEdit.ReadOnly = readOnly;

            memoEdit.EditValueChanging += new ChangingEventHandler(memoEdit_EditValueChanging);

            memoEdit.Appearance.TextOptions.VAlignment = vAlign;

            memoEdit.Appearance.TextOptions.HAlignment = hAlign;

            memoEdit.Appearance.Options.UseTextOptions = true;


            col.ColumnEdit = memoEdit;


            this.Columns.Add(col);
        }

        public void AddMemoExEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool readOnly, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.VAlignment = vAlign;

            col.AppearanceCell.TextOptions.HAlignment = hAlign;


            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.MEMO;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            RepositoryItemMemoExEdit memoExEdit = new RepositoryItemMemoExEdit();

            memoExEdit.ReadOnly = readOnly;

            //memoExEdit.EditValueChanging += new ChangingEventHandler(memoEdit_EditValueChanging);

            memoExEdit.EditValueChanging += MemoExEdit_EditValueChanging;
            
            memoExEdit.Appearance.TextOptions.VAlignment = vAlign;

            memoExEdit.Appearance.TextOptions.HAlignment = hAlign;

            memoExEdit.Appearance.Options.UseTextOptions = true;

            memoExEdit.ShowIcon = false;

            col.ColumnEdit = memoExEdit;


            this.Columns.Add(col);
        }

        private void MemoExEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            MemoExEdit edit = sender as MemoExEdit;

            if (edit.Properties.ReadOnly == true)
            {
                e.Cancel = true;

            }
        }

        public void AddPictrue(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.PICTURE;

            _DefaultTable.Columns.Add(columnName, typeof(System.Drawing.Bitmap));

            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();

            pictureEdit.AllowFocused = false;
            pictureEdit.SizeMode = PictureSizeMode.Squeeze;
            //pictureEdit.ShowMenu = allowEdit;
            //pictureEdit.PictureAlignment = ContentAlignment.MiddleCenter;
            pictureEdit.NullText = " ";
            //pictureEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            col.ColumnEdit = pictureEdit;

            this.Columns.Add(col);
        }


        public void AddPictrue(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, PictureSizeMode ImgSizeMode)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.PICTURE;

            _DefaultTable.Columns.Add(columnName, typeof(System.Drawing.Bitmap));

            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();

            pictureEdit.AllowFocused = false;
            pictureEdit.SizeMode = ImgSizeMode;
            pictureEdit.NullText = " ";

            col.ColumnEdit = pictureEdit;

            this.Columns.Add(col);
        }
        void memoEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            MemoEdit edit = sender as MemoEdit;

            if (edit.Properties.ReadOnly == true)
            {
                e.Cancel = true;

            }
        }


        public void AddProgressBar(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {

            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;



            col.EditorType = emEditorType.PROGRESSBAR;


            _DefaultTable.Columns.Add(columnName, typeof(int));

            RepositoryItemProgressBar progressBar = new RepositoryItemProgressBar();


            progressBar.ShowTitle = true;


            col.ColumnEdit = progressBar;

            this.Columns.Add(col);


        }

        public void AddColorEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;



            col.EditorType = emEditorType.COLOR;


            _DefaultTable.Columns.Add(columnName, typeof(int));

            RepositoryItemColorEdit colorEdit = new RepositoryItemColorEdit();

            colorEdit.ColorAlignment = align;

            col.ColumnEdit = colorEdit;

            this.Columns.Add(col);
        }


        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired, DevExpress.LookAndFeel.SkinStyle skinStyle = null)
        {
            AddButtonEdit(columnName, caption, resourceID, useReSourceID, align, textEditStyle, allowEdit, visible, isRequired, null,  skinStyle);
        }

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired, Image img, DevExpress.LookAndFeel.SkinStyle skinStyle = null)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            col.EditorType = emEditorType.BUTTON;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();

            btnEdit.TextEditStyle = textEditStyle;

            btnEdit.Mask.UseMaskAsDisplayFormat = true;

            btnEdit.Appearance.TextOptions.HAlignment = align;

            btnEdit.Appearance.Options.UseTextOptions = true;

            if (img != null)
            {
                btnEdit.Buttons[0].Image = img;
                btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            }

            if (skinStyle != null)
            {
                btnEdit.LookAndFeel.SetSkinStyle(skinStyle);
            }

            col.ColumnEdit = btnEdit;

            this.Columns.Add(col);
        }

        public RepositoryItemButtonEdit AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired
                                ,Image img, DevExpress.XtraEditors.Controls.ButtonPredefines bp, ButtonPressedEventHandler bpeHandler)
        {
            acGridColumn col = new acGridColumn();
            
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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            col.EditorType = emEditorType.BUTTON;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
            btnEdit.TextEditStyle = textEditStyle;
            btnEdit.Mask.UseMaskAsDisplayFormat = true;
            btnEdit.Appearance.TextOptions.HAlignment = align;
            btnEdit.Appearance.Options.UseTextOptions = true;
            btnEdit.Buttons[0].Image = img;
            btnEdit.Buttons[0].Kind = bp;
            btnEdit.ButtonClick += bpeHandler;

            col.ColumnEdit = btnEdit;

            this.Columns.Add(col);

            return btnEdit;
        }

        private void BtnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public int GetDataRowCount()
        {
            return (this.GridControl.DataSource as DataTable).Rows.Count;
        }

        public void AddHidden(string columnName, Type dataType)
        {
            _DefaultTable.Columns.Add(columnName, dataType);

        }



        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string catCode)
        {
            acGridColumn col = new acGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            col.Caption = col.Caption;

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;
            col.ToolTip = "표준코드 : " + catCode;
            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            //lookupEdit.UseCtrlScroll = true;
            //lookupEdit.AllowMouseWheel = false;
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "CD_NAME";
            displayColumnInfo.Caption = "CD_NAME";

            valueColumnInfo.FieldName = "CD_CODE";
            valueColumnInfo.Caption = "CD_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);



            lookupEdit.DataSource = acInfo.StdCodes.GetCatTable(catCode);


            lookupEdit.DisplayMember = "CD_NAME";

            lookupEdit.ValueMember = "CD_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);

            editorData.Add("CAT_CODE", catCode);

            col.ColumnEdit = lookupEdit;



            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    DataTable dt)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "PROC_NAME";
            displayColumnInfo.Caption = "PROC_NAME";

            valueColumnInfo.FieldName = "WO_NO";
            valueColumnInfo.Caption = "WO_NO";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);



            lookupEdit.DataSource = dt;


            lookupEdit.DisplayMember = "PROC_NAME";

            lookupEdit.ValueMember = "WO_NO";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);

            //editorData.Add("CAT_CODE", catCode);

            col.ColumnEdit = lookupEdit;



            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        //공정코드로 공정명 가져오기
        public void AddLookUpEditProc(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();

            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;

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

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_PROC_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];
            //lookupEdit.DataSource = acInfo.StdProcs.GetCatTable();


            lookupEdit.DisplayMember = "PROC_NAME";

            lookupEdit.ValueMember = "PROC_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);

            //editorData.Add("CAT_CODE", catCode);

            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        //공정코드로 공정명 가져오기 : 공정명 + 공정분류 + 품명 + 품번
        public void AddLookUpEditProcFull(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();

            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;

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

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_PROCGRPB_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];
            //lookupEdit.DataSource = acInfo.StdProcs.GetCatTable();


            lookupEdit.DisplayMember = "FULL_NAME";

            lookupEdit.ValueMember = "PROC_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);

            //editorData.Add("CAT_CODE", catCode);

            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }


        public void AddLookUpVendor(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);
            //lookupEdit.AutoSearchComplete += LookupEdit_AutoSearchComplete;

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
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "VEN_NAME";

            lookupEdit.ValueMember = "VEN_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }



        public void AddLookUpVendor(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emVenType venType)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);
            //lookupEdit.AutoSearchComplete += LookupEdit_AutoSearchComplete;

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
            paramTable.Columns.Add("CTRL_VEN_TYPE");

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            if (venType == emVenType.BOTH)
                paramRow["CTRL_VEN_TYPE"] = "4";
            else if (venType == emVenType.PURCHASE)
                paramRow["CTRL_VEN_TYPE"] = "2";
            else if (venType == emVenType.SALE)
                paramRow["CTRL_VEN_TYPE"] = "3";

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "VEN_NAME";

            lookupEdit.ValueMember = "VEN_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        public void AddLookUpPart(string columnName, string caption, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

            col.FieldName = columnName;

            col.Caption = caption;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT"); 
            paramTable.Columns.Add("PLT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_PART_SEARCH", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);
            DataTable resultTable = resultSet.Tables["RSLTDT"];

            if (resultTable.Columns.Contains("PART_NO"))
            {
                displayColumnInfo.FieldName = "PART_NO";
                displayColumnInfo.Caption = "PART_NO";
            }
            else
            {
                displayColumnInfo.FieldName = "PART_NAME";
                displayColumnInfo.Caption = "PART_NAME";
            }

            valueColumnInfo.FieldName = "PART_CODE";
            valueColumnInfo.Caption = "PART_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);


            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            if (resultTable.Columns.Contains("PART_NO"))
            {
                lookupEdit.DisplayMember = "PART_NO";
            }
            else
            {
                lookupEdit.DisplayMember = "PART_NAME";
            }

            lookupEdit.ValueMember = "PART_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        public void AddLookUpPart(string columnName, string caption, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
                 emPartProdType partProdtype, string valueMember, string displayMember)
        {
            acGridColumn col = new acGridColumn();

            col.FieldName = columnName;

            col.Caption = caption;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("PART_PRODTYPE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            if (partProdtype == emPartProdType.PROD)
                paramRow["PART_PRODTYPE"] = "1";
            else if (partProdtype == emPartProdType.PART)
                paramRow["PART_PRODTYPE"] = "2";
            else if (partProdtype == emPartProdType.MAT)
                paramRow["PART_PRODTYPE"] = "3";

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_STD_PART_SEARCH", paramSet, "RQSTDT", "RSLTDT");
            
            DataTable resultTable = resultSet.Tables["RSLTDT"];

            displayColumnInfo.FieldName = displayMember;
            displayColumnInfo.Caption = displayMember;
            
            valueColumnInfo.FieldName = valueMember;
            valueColumnInfo.Caption = valueMember;

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = displayMember;
            lookupEdit.ValueMember = valueMember;

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        public void AddLookUpOrg(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "ORG_NAME";
            displayColumnInfo.Caption = "ORG_NAME";

            valueColumnInfo.FieldName = "ORG_CODE";
            valueColumnInfo.Caption = "ORG_CODE";

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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_ORG", paramSet, "RQSTDT", "RSLTDT");

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "ORG_NAME";

            lookupEdit.ValueMember = "ORG_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        public void AddLookUpProc(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;


            col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_STDPROCS", paramSet, "RQSTDT", "RSLTDT");
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

            this.Columns.Add(col);
        
        }

        private string _empFilter = string.Empty;

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            AddLookUpEmp(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired,string.Empty);
        }

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,string filter)
        {
            _empFilter = filter;

            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            //lookupEdit.UseDropDownRowsAsMaxCount = true;
            //lookupEdit.DropDownRows = 100;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "EMP_NAME";
            displayColumnInfo.Caption = "EMP_NAME";

            valueColumnInfo.FieldName = "EMP_CODE";
            valueColumnInfo.Caption = "EMP_CODE";

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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "EMP_NAME";

            lookupEdit.ValueMember = "EMP_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

            col.Tag = "AddLookUpEmp";

            this.ShownEditor += acGridView_ShownEditor;

        }

        private void acGridView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn.Tag == null) return;

            if (view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit
                && view.FocusedColumn.Tag.ToString() == "AddLookUpEmp")
            {
                DevExpress.XtraEditors.LookUpEdit edit;

                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;

                DataTable table = edit.Properties.DataSource as DataTable;

                DataView clone = new DataView(table);

                clone.RowFilter = "DATA_FLAG = '0'" + (this._empFilter != string.Empty ? " AND " + this._empFilter : string.Empty);

                edit.Properties.DataSource = clone;
            }
        }

        void lookupEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.SetFocusedValue(DBNull.Value);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                LookUpEdit edit = sender as LookUpEdit;
                PopupLookUpEditForm popup = edit.GetPopupEditForm();
                if (popup == null) return;

                if (popup.Filter.RowCount == 1)
                {
                    edit.ItemIndex = 0;
                    var value = edit.GetColumnValue(edit.Properties.ValueMember);
                    edit.ClosePopup();
                    edit.EditValue = value;
                    edit.Enabled = false;

                }
            }
        }


        /// <summary>
        /// 컬럼에 매칭된 데이터소스를 업데이트한다.
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="datasource"></param>
        public void UpdateColumnDatasource(string columnName, object datasource)
        {
            if (this.Columns[columnName].ColumnEdit is RepositoryItemLookUpEdit)
            {
                ((RepositoryItemLookUpEdit)this.Columns[columnName].ColumnEdit).DataSource = datasource;
            }

        }

        public void AddLookUpMC(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.EditorType = emEditorType.LOOKUP;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "MC_NAME";
            displayColumnInfo.Caption = "MC_NAME";

            valueColumnInfo.FieldName = "MC_CODE";
            valueColumnInfo.Caption = "MC_CODE";

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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_MACHINE_SEARCH", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "MC_NAME";

            lookupEdit.ValueMember = "MC_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }


        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string displayColumnName, string valueColumnName, object dataSource)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;
            //col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();




            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.SearchMode = SearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);
            lookupEdit.AutoSearchComplete += LookupEdit_AutoSearchComplete; //2021.11.01 pkd 

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = displayColumnName;
            displayColumnInfo.Caption = displayColumnName;

            valueColumnInfo.FieldName = valueColumnName;
            valueColumnInfo.Caption = valueColumnName;

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);


            lookupEdit.DataSource = dataSource;

            lookupEdit.DisplayMember = displayColumnName;

            lookupEdit.ValueMember = valueColumnName;



            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", dataSource);


            col.ColumnEdit = lookupEdit;

            //col.FilterMode = ColumnFilterMode.DisplayText;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }

        private void LookupEdit_AutoSearchComplete(object sender, LookUpEditAutoSearchCompleteEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            PopupLookUpEditForm popup = edit.GetPopupEditForm();
            if (popup == null) return;

            if(popup.Filter.RowCount == 1)
            {
                edit.ItemIndex = 0;
                var value = edit.GetColumnValue(edit.Properties.ValueMember);
                edit.ClosePopup();
                edit.EditValue = value;
                edit.Enabled = false;
              
            }
        }

        public void AddGridLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string displayColumnName, string valueColumnName, object dataSource)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.LOOKUP;
            //col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();




            col.EditorData = editorData;

            RepositoryItemGridLookUpEdit lookupEdit = new RepositoryItemGridLookUpEdit();
            lookupEdit.SearchMode = GridLookUpSearchMode.AutoSearch;
            lookupEdit.TextEditStyle = TextEditStyles.Standard;
            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowFooter = true;


            lookupEdit.PopupView.OptionsBehavior.AutoPopulateColumns = true;

            lookupEdit.DataSource = dataSource;
            lookupEdit.DisplayMember = displayColumnName;
            lookupEdit.ValueMember = valueColumnName;



            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", dataSource);


            col.ColumnEdit = lookupEdit;

            //col.FilterMode = ColumnFilterMode.DisplayText;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }


        public RepositoryItemSearchLookUpEdit AddSearchLookUpEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string displayColumnName, string valueColumnName, object dataSource)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = align;

            col.AppearanceCell.Options.UseTextOptions = true;

            //col.EditorType
            //col.EditorType = emEditorType.LOOKUP;
            //col.EditorType = emEditorType.LOOKUP_CODE;

            col.IsRequired = isRequired;

            Dictionary<string, object> editorData = new Dictionary<string, object>();

            col.EditorData = editorData;
            RepositoryItemSearchLookUpEdit searchlookupedit = new RepositoryItemSearchLookUpEdit();

            //searchlookupedit.SearchMode = GridLookUpSearchMode.AutoSearch;
            searchlookupedit.TextEditStyle = TextEditStyles.Standard;
            //searchlookupedit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

            searchlookupedit.NullText = string.Empty;
            searchlookupedit.ShowFooter = true;


            searchlookupedit.PopupView.OptionsBehavior.AutoPopulateColumns = true;

            searchlookupedit.DataSource = dataSource;
            searchlookupedit.DisplayMember = displayColumnName;
            searchlookupedit.ValueMember = valueColumnName;

            editorData.Add("DISPLAY_COLUMN_NAME", searchlookupedit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", searchlookupedit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", searchlookupedit.DisplayMember);

            editorData.Add("DATASOURCE", dataSource);


            col.ColumnEdit = searchlookupedit;

            //col.FilterMode = ColumnFilterMode.DisplayText;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

            return searchlookupedit;
        }

        public void AddCheckEdit(string columnName, string caption, string resourceID, bool useReSourceID, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;
            col.OptionsColumn.AllowSort = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.EditorType = emEditorType.CHECK;

            col.EditorData = chekEditDataType;
            col.FilterMode = ColumnFilterMode.DisplayText;
            
            col.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
            
            RepositoryItemCheckEdit checkItemEdit = new RepositoryItemCheckEdit();
            checkItemEdit.ExportMode = ExportMode.DisplayText;
            checkItemEdit.DisplayValueChecked = "True";
            checkItemEdit.DisplayValueGrayed = "False";
            checkItemEdit.DisplayValueUnchecked = "False";
            checkItemEdit.AllowGrayed = false;
            checkItemEdit.NullStyle = StyleIndeterminate.Unchecked;


            switch (chekEditDataType)
            {
                case emCheckEditDataType._BOOL:

                    checkItemEdit.ValueChecked = true;
                    checkItemEdit.ValueUnchecked = false;

                    _DefaultTable.Columns.Add(columnName, typeof(bool));
                    _DefaultTable.Columns[columnName].DefaultValue = false;

                    break;

                case emCheckEditDataType._INT:

                    checkItemEdit.ValueChecked = 1;
                    checkItemEdit.ValueUnchecked = 0;

                    _DefaultTable.Columns.Add(columnName, typeof(int));
                    _DefaultTable.Columns[columnName].DefaultValue = 0;

                    break;

                case emCheckEditDataType._BYTE:

                    checkItemEdit.ValueChecked = (byte)1;
                    checkItemEdit.ValueUnchecked = (byte)0;

                    _DefaultTable.Columns.Add(columnName, typeof(byte));
                    _DefaultTable.Columns[columnName].DefaultValue = (byte)0;

                    break;

                case emCheckEditDataType._STRING:

                    checkItemEdit.ValueChecked = "1";
                    checkItemEdit.ValueUnchecked = "0";

                    _DefaultTable.Columns.Add(columnName, typeof(string));
                    _DefaultTable.Columns[columnName].DefaultValue = "0";

                    break;

                case emCheckEditDataType._YN:

                    checkItemEdit.ValueChecked = "Y";
                    checkItemEdit.ValueUnchecked = "N";

                    _DefaultTable.Columns.Add(columnName, typeof(string));
                    _DefaultTable.Columns[columnName].DefaultValue = "N";

                    break;



            }

            //col.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;

            col.ColumnEdit = checkItemEdit;

            this.Columns.Add(col);
            

        }

        /// <summary>
        /// 행 높이
        /// </summary>
        private int _RowHeight = 0;

        /// <summary>
        /// 컬럼 헤더 높이
        /// </summary>
        private int _ColumnHeaderHeight = 0;


        public void SetFocusRowHandleFromValue(string columnName, object value)
        {
            DataView view = this.GetDataView();

            for (int i = 0; i < view.Count; i++)
            {
                if (view[i].Row[columnName].EqualsEx(value))
                {
                    this.FocusedRowHandle = i;

                    return;
                }
            }
        }


        /// <summary>
        /// 현재 포커스 행에서 지정된 페이지(한화면당 표시)만큼 더함
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public void SetFocusRowHandleFromPage(int page)
        {
            int row = 0;

            int rowViewHeight = this.ViewRect.Height;

            if (this.OptionsView.ShowColumnHeaders == true)
            {
                rowViewHeight = rowViewHeight - (this._ColumnHeaderHeight + 4);
            }


            int viewRowCnt = (rowViewHeight / (this._RowHeight + 2));

            if (viewRowCnt == 0)
            {
                return;
            }

            int nowPage = (this.FocusedRowHandle / viewRowCnt);

            if (page > 0)
            {
                row = ((nowPage + page) * viewRowCnt);

                if (row > this.RowCount)
                {
                    //row = this.FocusedRowHandle;

                    row = 0;
                }



            }
            else
            {
                row = ((nowPage + page) * viewRowCnt);

                if (row < 0)
                {
                    row = 0;
                }


            }

            this.FocusedRowHandle = row;
            this.TopRowIndex = this.FocusedRowHandle;
        }


        public GridColumn GetColumn(string caption)
        {
            foreach (GridColumn col in this.Columns)
            {
                if (col.Caption == caption)
                {
                    return col;
                }

            }

            return null;
        }

        public string GetCodeName(string columnName, object value)
        {

            RepositoryItemLookUpEdit look = (RepositoryItemLookUpEdit)this.Columns[columnName].ColumnEdit;

            DataTable data = (DataTable)look.DataSource;

            string v = value.toStringNull();

            if (!string.IsNullOrEmpty(v))
            {


                DataRow[] codeRow = data.Select(look.ValueMember + " = '" + value.ToString() + "'");



                return codeRow[0][look.DisplayMember].toStringNull();

            }

            return null;

        }



        /// <summary>
        /// Row 포커스 이벤트를 발생시킨다.
        /// </summary>
        public void RaiseFocusedRowChanged()
        {
            this.RaiseFocusedRowChanged(this.FocusedRowHandle, this.FocusedRowHandle);


        }

        //public void RaiseShownEditor(object sender, EventArgs e)
        //{

        //    this.RaiseShownEditor(sender, e);
        //}


        /// <summary>
        /// 설정된 컴럼데이터를 초기화시킨다.
        /// </summary>
        public void ClearColumns()
        {

            this._Config.Reset();

            this.Columns.Clear();

            this._DefaultTable.Columns.Clear();
            this._DefaultTable.Rows.Clear();
        }

        /// <summary>
        /// 설정된 컬럼을 삭제한다. 
        /// </summary>
        public void RemoveColumns()
        {
            foreach (DataColumn col in this._DefaultTable.Columns)
            {
                this._DefaultTable.Columns.Remove(col);

                this.Columns.Remove(this.Columns[col.ColumnName]);
            }

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

        public void AddComboBoxEdit(string columnName, string caption, string resourceID, bool useReSourceID,
            HorzAlignment align, bool allowEdit, bool visible, bool isRequired, List<DataRow> list, string colName)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.COMBOBOX;

                col.IsRequired = isRequired;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                RepositoryItemComboBox comboBoxEditItem = new RepositoryItemComboBox();

                comboBoxEditItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                comboBoxEditItem.PopupSizeable = true;

                if (list != null)
                {
                    foreach (DataRow dr in list)
                    {
                        comboBoxEditItem.Items.Add(dr[colName].ToString());
                    }

                }

                col.ColumnEdit = comboBoxEditItem;

                _DefaultTable.Columns.Add(columnName, typeof(object));

                this.Columns.Add(col);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 팝업 컨트롤러 연결 컬럼
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="resourceID"></param>
        /// <param name="useReSourceID"></param>
        /// <param name="align"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible"></param>
        /// <param name="isRequired"></param>
        /// <param name="pcc">디자인에 추가한 acPopupContainerControl</param>
        public void AddPopupContainerEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, PopupContainerControl pcc)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.NONE;

                col.IsRequired = isRequired;



                RepositoryItemPopupContainerEdit popupContainerEditItem = new RepositoryItemPopupContainerEdit();
                col.ColumnEdit = popupContainerEditItem;
                popupContainerEditItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                popupContainerEditItem.Name = "pop" + columnName;
                popupContainerEditItem.PopupControl = pcc;

                _DefaultTable.Columns.Add(columnName, typeof(object));

                this.Columns.Add(col);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AddComboBoxEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, List<object> list)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.COMBOBOX;

                col.IsRequired = isRequired;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                RepositoryItemComboBox comboBoxEditItem = new RepositoryItemComboBox();

                comboBoxEditItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                comboBoxEditItem.PopupSizeable = true;

                if (list != null)
                {
                    foreach (object t in list)
                    {
                        comboBoxEditItem.Items.Add(t);
                    }
                }

                col.ColumnEdit = comboBoxEditItem;

                _DefaultTable.Columns.Add(columnName, typeof(object));

                this.Columns.Add(col);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask, Color cellColor)
        {
            try
            {
                acGridColumn col = AddTextEdit(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired, mask);
                col.AppearanceCell.BackColor = cellColor;
            }
            catch (Exception ex)
            {
                throw ex;

            }


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
        public acGridColumn AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;


                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.TEXT;

                col.IsRequired = isRequired;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                col.EditorData = mask;

                RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

                col.ColumnEdit = textEditItem;

                textEditItem.Mask.UseMaskAsDisplayFormat = true;

                switch (mask)
                {
                    case emTextEditMask.NONE:

                        _DefaultTable.Columns.Add(columnName);

                        break;

                    case emTextEditMask.DIGIT:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));


                        //textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                        //textEditItem.Mask.EditMask = "d";

                        break;
                    case emTextEditMask.NUMERIC:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "d";

                        break;


                    case emTextEditMask.QTY:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "N0";


                        break;

                    case emTextEditMask.MONEY:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");


                        break;

                    case emTextEditMask.MONEY_F2:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "N2";


                        break;

                    case emTextEditMask.MONEY_F4:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "N4";


                        break;
                    case emTextEditMask.FILE_SIZE:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "N0";


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

                    case emTextEditMask.PER0:

                        _DefaultTable.Columns.Add(columnName, typeof(double));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p0";


                        break;

                    case emTextEditMask.PER2:

                        _DefaultTable.Columns.Add(columnName, typeof(double));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p2";


                        break;
                    case emTextEditMask.PER100:

                        _DefaultTable.Columns.Add(columnName, typeof(byte));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,2}|100)%";

                        break;

                    case emTextEditMask.PER100_2:

                        _DefaultTable.Columns.Add(columnName, typeof(byte));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}|100)%";

                        break;

                    case emTextEditMask.F2:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //textEditItem.Mask.EditMask = "F2";
                        textEditItem.Mask.EditMask = "n2";

                        break;

                    case emTextEditMask.N:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "n2";

                        break;

                    case emTextEditMask.F1:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));
                        //_DefaultTable.Columns.Add(columnName, typeof(double));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //textEditItem.Mask.EditMask = "F1";
                        textEditItem.Mask.EditMask = "n1";


                        break;

                    case emTextEditMask.F3:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));
                        //_DefaultTable.Columns.Add(columnName, typeof(double));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //textEditItem.Mask.EditMask = "F1";
                        textEditItem.Mask.EditMask = "n3";


                        break;

                    case emTextEditMask.F4:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));
                        //_DefaultTable.Columns.Add(columnName, typeof(double));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //textEditItem.Mask.EditMask = "F1";
                        textEditItem.Mask.EditMask = "n4";


                        break;

                    case emTextEditMask.F6:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F6";


                        break;

                    case emTextEditMask.TIME:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F0";


                        break;

                    case emTextEditMask.UPPERCASE:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\p{Lu}+";

                        break;


                    case emTextEditMask.IP:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

                        break;

                    case emTextEditMask.CORP:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{3}\-\d{2}\-\d{5}";

                        break;

                    case emTextEditMask.LAW:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{6}\-\d{7}";

                        break;


                    case emTextEditMask.ZIP:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{3}\-\d{3}";

                        break;


                    case emTextEditMask.TEL:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{2,3}\-\d{1,4}\-\d{4}";


                        break;

                    case emTextEditMask.JOB_PRIORITY:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d{2}\-\d{2}";

                        break;
                    case emTextEditMask.NUM_4_0:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.UseMaskAsDisplayFormat = true;
                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "K0000"; 
                        //textEditItem.MaxLength = 4;
                        //textEditItem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                        //textEditItem.DisplayFormat.FormatString = "K{0:D4}";

                        break;

                    case emTextEditMask.TEMP:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"\d+ ℃";

                        break;

                    case emTextEditMask.HHmm:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"(0?\d|1\d|2[0-3])\:[0-5]\d";

                        break;

                    case emTextEditMask.REG_NUMBER:

                        _DefaultTable.Columns.Add(columnName, typeof(string));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"[0-9][0-9][01][0-9][0123][0-9]-[12345678][0-9]{6}";
                        break;
                }

                //마스크 타입이 숫자이고 기본정렬 일때 오른쪽 정렬을 기본으로 사용
                if(textEditItem.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric
                && align == HorzAlignment.Default)
                {
                    col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }

                textEditItem.EditValueChanging += new ChangingEventHandler(TextEdit_EditValueChanging);
                textEditItem.KeyPress += new KeyPressEventHandler(TextEdit_KeyPress);
                textEditItem.Tag = col;

                this.Columns.Add(col);

                return col;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public acGridColumn AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, DevExpress.XtraEditors.Mask.MaskType mask, string editMask)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;


                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.TEXT;

                col.IsRequired = isRequired;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                col.EditorData = mask;

                RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

                col.ColumnEdit = textEditItem;

                textEditItem.Mask.UseMaskAsDisplayFormat = true;


                switch (mask)
                {
                    case DevExpress.XtraEditors.Mask.MaskType.Numeric:
                        _DefaultTable.Columns.Add(columnName, typeof(decimal));
                        break;

                    default:
                        _DefaultTable.Columns.Add(columnName, typeof(string));
                        break;
                }

                textEditItem.Mask.MaskType = mask;
                textEditItem.Mask.EditMask = editMask;

                textEditItem.EditValueChanging += new ChangingEventHandler(TextEdit_EditValueChanging);
                textEditItem.KeyPress += new KeyPressEventHandler(TextEdit_KeyPress);
                textEditItem.Tag = col;

                this.Columns.Add(col);

                return col;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void TextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            //수량이 0을 입력할수 있거나, 금액을 0 입력할수있는지 결정 
            //단, 메뉴 마다 다를수있으니 확인


            TextEdit editor = sender as TextEdit;

            if (editor.Tag != null)
            {
                if (editor.Tag is RepositoryItem)
                {
                    RepositoryItem item = editor.Tag as RepositoryItem;

                    acGridColumn col = item.Tag as acGridColumn;

                    emTextEditMask mask = (emTextEditMask)col.EditorData;


                    //if (mask == emTextEditMask.QTY)
                    //{
                    //    if (e.NewValue.toDecimal() <= 0)
                    //    {
                    //        e.Cancel = true;
                    //    }


                    //}

                    if (mask == emTextEditMask.DIGIT)
                    {
                        string s = e.NewValue.ToString();

                        if (!s.isNumeric2())
                        {
                            e.Cancel = true;

                        }
                        //                        for (int i = 0; i < s.Length; i++)
                        //                        {
                        //                            //if 

                        //                            if (!char.IsDigit(s, i))
                        //                            {
                        //                                bool p = char.IsPunctuation(s, i);
                        //                                e.Cancel = true;
                        ////                                return;

                        //                            }
                        //                        }

                    }


                }

            }

            if (this.GridType == emGridType.SEARCH_SEL)
            {
                this.SelectRow(this.FocusedRowHandle);
            }
        }

        void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextEdit editor = sender as TextEdit;

            if (editor.Tag != null)
            {
                if (editor.Tag is RepositoryItem)
                {
                    RepositoryItem item = editor.Tag as RepositoryItem;

                    acGridColumn col = item.Tag as acGridColumn;

                    emTextEditMask mask = (emTextEditMask)col.EditorData;

                    if (mask == emTextEditMask.QTY ||
                        mask == emTextEditMask.WEIGHT
                        )
                    {
                        if (e.KeyChar == '-')
                        {
                            e.Handled = true;

                            return;
                        }
                    }
                    else if (mask == emTextEditMask.DIGIT)
                    {
                        if (!char.IsDigit(e.KeyChar))
                        {
                            e.Handled = false;

                            return;
                        }
                    }
                }
            }

        }

        public void AddCheckedComboBoxEdit(string columnName, string caption, string resourceID, bool useReSourceID,
            HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string catcode)
        {
            AddCheckedComboBoxEdit(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired, "CD_NAME", "CD_CODE", acInfo.StdCodes.GetCatTable(catcode));
        }
        public void AddCheckedComboBoxEdit(string columnName, string caption, string resourceID, bool useReSourceID,
            HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string displayColumnName, string valueColumnName, object dataSource)
        {

            try
            {
                acGridColumn col = new acGridColumn();

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

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.CHECKEDCOMBO;

                col.IsRequired = isRequired;

                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

                col.OptionsColumn.AllowMerge = DefaultBoolean.False;

                Dictionary<string, object> editorData = new Dictionary<string, object>();

                col.EditorData = editorData;

                RepositoryItemCheckedComboBoxEdit checkedComboBoxEditItem = new RepositoryItemCheckedComboBoxEdit();

                checkedComboBoxEditItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                checkedComboBoxEditItem.PopupSizeable = true;

                if (dataSource != null)
                {
                    foreach (DataRow dr in (dataSource as DataTable).Rows)
                    {
                        checkedComboBoxEditItem.Items.Add(dr[valueColumnName].ToString(), dr[displayColumnName].ToString());
                    }

                }

                col.ColumnEdit = checkedComboBoxEditItem;

                _DefaultTable.Columns.Add(columnName, typeof(object));

                this.Columns.Add(col);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRadioGroup(string columnName, string caption, string resourceID, bool useReSourceID, bool allowEdit, bool visible, bool isRequired,
    string catCode)
        {
            acGridColumn col = new acGridColumn();

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

            col.OptionsColumn.AllowMerge = DefaultBoolean.False;


            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            col.AppearanceHeader.Options.UseTextOptions = true;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            col.AppearanceCell.Options.UseTextOptions = true;

            col.EditorType = emEditorType.RADIO_GROUP;

            col.IsRequired = isRequired;

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            Dictionary<string, object> editorData = new Dictionary<string, object>();

            col.EditorData = editorData;

            RepositoryItemRadioGroup radioGroup = new RepositoryItemRadioGroup();

            radioGroup.NullText = string.Empty;

            DataTable stdInfo = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in stdInfo.Rows)
            {
                RadioGroupItem item = new RadioGroupItem(row["CD_CODE"], row["CD_NAME"].ToString());

                radioGroup.Items.Add(item);
            }

            editorData.Add("CAT_CODE", catCode);

            //editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            //editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            //editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", stdInfo);

            col.ColumnEdit = radioGroup;


            _DefaultTable.Columns.Add(columnName, typeof(string));

            this.Columns.Add(col);

        }


        /// <summary>
        /// 필드명으로 그리드에 포함된 컬럼인지 판단
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public bool ContainsColumn(string FieldName)
        {
            foreach(acGridColumn col in  this.Columns)
            {
                if (col.FieldName == FieldName)
                    return true;
            }

            return false;
        }


        //public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public event ShowGridMenuExHandler ShowGridMenuEx;

        private void SetGridColumnMenu(GridViewMenu menu, GridHitInfo hitInfo)
        {

            try
            {
                if (hitInfo.HitTest == GridHitTest.Column || hitInfo.HitTest == GridHitTest.ColumnPanel)
                {

                    acGridColumn acCol = (acGridColumn)hitInfo.Column;

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

                        #region 병합기능 설정

                        bool mergeCheckd = false;

                        if (acCol.OptionsColumn.AllowMerge == DefaultBoolean.True)
                        {
                            mergeCheckd = true;
                        }
                        else if (acCol.OptionsColumn.AllowMerge == DefaultBoolean.False)
                        {
                            mergeCheckd = false;
                        }

                        acDXMenuCheckItem menuItemMerge = new acDXMenuCheckItem(acInfo.Resource.GetString("병합", "HIPIWQ26"), mergeCheckd);
                        menuItemMerge.Image = ControlManager.Resource.application_side_boxesx_16;
                        menuItemMerge.Click += new EventHandler(menuItemMerge_Click);
                        menuItemMerge.RefObject = acCol;


                        acMenuItem menuItemMask = new acMenuItem(acInfo.Resource.GetString("마스크", "YSU2282M"));
                        menuItemMask.Image = ControlManager.Resource.text_lowercase_x16;
                        menuItemMask.Click += new EventHandler(menuItemMask_Click);
                        menuItemMask.UserData = acCol;


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

                        menuItemFilter.Click += new EventHandler(menuItemFilter_Click);

                        #endregion


                        menuItemAlign.Items.Add(menuItemAlignLeft);

                        menuItemAlign.Items.Add(menuItemAlignCenter);

                        menuItemAlign.Items.Add(menuItemAlignRight);

                        //정렬
                        menuItemColumn.Items.Add(menuItemAlign);

                        //고정
                        menuItemColumn.Items.Add(menuItemFixed);

                        //병합
                        menuItemColumn.Items.Add(menuItemMerge);

                        //마스크
                        menuItemColumn.Items.Add(menuItemMask);

                        //필터
                        menuItemColumn.Items.Add(menuItemFilter);



                        #region 에디터 형태 전용


                        if (acCol.EditorType == emEditorType.LOOKUP ||
                            acCol.EditorType == emEditorType.LOOKUP_CODE)
                        {

                            Dictionary<string, object> editData = acCol.EditorData as Dictionary<string, object>;

                            RepositoryItemLookUpEdit edit = acCol.ColumnEdit as RepositoryItemLookUpEdit;

                            bool menuItemEditShowTypeDisplayCheked = false;
                            bool menuItemEditShowTypeValueCheked = false;

                            if (edit.DisplayMember == editData["DISPLAY_COLUMN_NAME"].ToString())
                            {
                                menuItemEditShowTypeDisplayCheked = true;
                                menuItemEditShowTypeValueCheked = false;
                            }
                            else
                            {
                                menuItemEditShowTypeDisplayCheked = false;
                                menuItemEditShowTypeValueCheked = true;
                            }

                            DXSubMenuItem menuItemEditShowType = new DXSubMenuItem(acInfo.Resource.GetString("표시형태", "4RDULC0E"));
                            menuItemEditShowType.Image = ControlManager.Resource.textfield_rename_x16;

                            acDXMenuCheckItem menuItemEditShowTypeDisplay = new acDXMenuCheckItem(acInfo.Resource.GetString("명", "3F0G0LI0"), menuItemEditShowTypeDisplayCheked);

                            menuItemEditShowTypeDisplay.Click += new EventHandler(menuItemEditShowTypeDisplay_Click);
                            menuItemEditShowTypeDisplay.RefObject = acCol;

                            acDXMenuCheckItem menuItemEditShowTypeValue = new acDXMenuCheckItem(acInfo.Resource.GetString("값", "GJ8YAWE5"), menuItemEditShowTypeValueCheked);

                            menuItemEditShowTypeValue.Click += new EventHandler(menuItemEditShowTypeValue_Click);
                            menuItemEditShowTypeValue.RefObject = acCol;

                            menuItemEditShowType.Items.Add(menuItemEditShowTypeDisplay);
                            menuItemEditShowType.Items.Add(menuItemEditShowTypeValue);

                            menuItemColumn.Items.Add(menuItemEditShowType);
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

                    menuItemGroupExpand.Click += new EventHandler(menuItemGroupExpand_Click);
                    menuItemGroupCollapse.Click += new EventHandler(menuItemGroupCollapse_Click);

                    acDXMenuCheckItem menuItemAlwaysBestFit = new acDXMenuCheckItem(acInfo.Resource.GetString("항상 전체 컬럼 자동크기", "LHZDTQ5M"), _Config.AlwaysBestFit);
                    menuItemAlwaysBestFit.Image = ControlManager.Resource.adjustcol_star_x16;
                    menuItemAlwaysBestFit.Click += new EventHandler(menuItemAlwaysBestFit_Click);



                    menuItemMethod.Items.Add(menuItemAllBestFitColumns);


                    menuItemMethod.Items.Add(menuItemAlwaysBestFit);

                    menuItemMethod.Items.Add(menuItemGroupExpand);
                    menuItemMethod.Items.Add(menuItemGroupCollapse);

                    #endregion



                    acDXMenuCheckItem menuItemShowColumnHeader = new acDXMenuCheckItem(acInfo.Resource.GetString("컬럼", "8HEB5JMB"), this.OptionsView.ShowColumnHeaders);
                    menuItemShowColumnHeader.Click += new EventHandler(menuItemShowColumnHeader_Click);



                    acDXMenuCheckItem menuItemShowRowNum = new acDXMenuCheckItem(acInfo.Resource.GetString("행번호", "00GAQ8W2"), this.OptionsView.ShowIndicator);
                    menuItemShowRowNum.Click += new EventHandler(menuItemShowRowNum_Click);




                    acDXMenuCheckItem menuItemFooter = new acDXMenuCheckItem(acInfo.Resource.GetString("전체 요약", "1HTM1B9U"), this.OptionsView.ShowFooter);
                    menuItemFooter.Click += new EventHandler(menuItemFooter_Click);


                    acDXMenuCheckItem menuItemGroupFooter = new acDXMenuCheckItem(acInfo.Resource.GetString("그룹 요약", "7K0Y2QTV"), this._ShowGroupFooter);
                    menuItemGroupFooter.Click += new EventHandler(menuItemGroupFooter_Click);




                    menuItemShow.Items.Add(menuItemShowRowNum);
                    menuItemShow.Items.Add(menuItemShowColumnHeader);
                    menuItemShow.Items.Add(menuItemFooter);
                    menuItemShow.Items.Add(menuItemGroupFooter);




                    #region 스타일 상자



                    DXMenuItem menuItemStyleBox = new DXMenuItem(acInfo.Resource.GetString("스타일 상자", "6T0ZDDPE"));
                    menuItemStyleBox.Image = ControlManager.Resource.applications_graphics;
                    menuItemStyleBox.Click += new EventHandler(menuItemStyleBox_Click);



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

                    #region 사용자 등록 양식

                    DXSubMenuItem menuItemCustomExcel = new DXSubMenuItem("사용자 지정 양식 EXCEL");
                    menuItemCustomExcel.Image = ControlManager.Resource.doc_excel_table_x16;


                    DXMenuItem menuAssignCustomExcel = new DXMenuItem(string.Format("Excel 저장 - {0}", this._CustomReportCusName));
                    menuAssignCustomExcel.Image = ControlManager.Resource.document_save;
                    menuAssignCustomExcel.Click += MenuAssignCustomExcel_Click;

                    DXMenuItem menuItemManagerCustomExcel = new DXMenuItem("관리");
                    menuItemManagerCustomExcel.Image = ControlManager.Resource.edit_find_replace_x16;
                    menuItemManagerCustomExcel.Click += new EventHandler(menuItemCustomReportManager_Click);


                    //현재 설정중인 사용자 UI가 존재하지않음
                    if (string.IsNullOrEmpty(this._CustomReportCusID))
                    {
                        menuAssignCustomExcel.Visible = false;
                    }

                    menuItemCustomExcel.Items.Add(menuAssignCustomExcel);
                    menuItemCustomExcel.Items.Add(menuItemManagerCustomExcel);

                    #endregion

                    //인쇄


                    DXMenuItem menuItemDefaultPrint = new DXMenuItem(acInfo.Resource.GetString("인쇄", "4HOA9EHQ"));
                    menuItemDefaultPrint.Image = ControlManager.Resource.document_print_x16;
                    menuItemDefaultPrint.Click += new EventHandler(menuItemDefaultPrint_Click);


                    DXMenuItem menuHelp = new DXMenuItem(acInfo.Resource.GetString("도움말", "TGFJ3JK4"));
                    menuHelp.Image = ControlManager.Resource.help_browser_x16;
                    menuHelp.Click += new EventHandler(menuHelp_Click);

                    #region 메뉴 추가

                    if (hitInfo.InColumn == true)
                    {

                        switch (this.GridType)
                        {
                            case emGridType.SEARCH:
                            case emGridType.SEARCH_SEL:

                                //컬럼 자동크기(전체) 기본삭제

                                menu.Items.RemoveAt(9);




                                menu.Items.Add(menuItemColumn);

                                menuItemColumn.BeginGroup = true;


                                menu.Items.Add(menuItemShow);

                                menu.Items.Add(menuItemMethod);

                                menu.Items.Add(menuItemStyleBox);

                                menu.Items.Add(menuItemConfig);
                                menuItemConfig.BeginGroup = true;


                                menu.Items.Add(menuItemSaveFile);
                                menuItemSaveFile.BeginGroup = true;

                                menu.Items.Add(menuItemCustomExcel);
                                menuItemCustomExcel.BeginGroup = true;

                                menu.Items.Add(menuItemDefaultPrint);
                                menuItemDefaultPrint.BeginGroup = true;


                                menu.Items.Add(menuHelp);
                                menuHelp.BeginGroup = true;

                                break;


                            case emGridType.FIXED:
                                menu.Items.RemoveAt(4);
                                menu.Items.RemoveAt(6);


                                menu.Items.Add(menuItemMethod);

                                menu.Items.Add(menuItemSaveFile);
                                menuItemSaveFile.BeginGroup = true;

                                menu.Items.Add(menuItemCustomExcel);
                                menuItemCustomExcel.BeginGroup = true;

                                menu.Items.Add(menuItemDefaultPrint);
                                menuItemDefaultPrint.BeginGroup = true;

                                menu.Items.Add(menuHelp);
                                menuHelp.BeginGroup = true;
                                break;


                            case emGridType.LIST:

                                menu.Items.RemoveAt(9);

                                menu.Items.Add(menuItemMethod);

                                menu.Items.Add(menuItemSaveFile);
                                menuItemSaveFile.BeginGroup = true;

                                menu.Items.Add(menuItemCustomExcel);
                                menuItemCustomExcel.BeginGroup = true;

                                menu.Items.Add(menuItemDefaultPrint);
                                menuItemDefaultPrint.BeginGroup = true;

                                menu.Items.Add(menuItemConfig);
                                menuItemConfig.BeginGroup = true;

                                menu.Items.Add(menuHelp);
                                menuHelp.BeginGroup = true;

                                break;

                            case emGridType.ATTACH_FILE_LIST:


                                menu.Items.RemoveAt(4);


                                menu.Items.Add(menuHelp);
                                menuHelp.BeginGroup = true;

                                break;

                            case emGridType.COMMON_CONTROL:

                                menu.Items.RemoveAt(4);
                                menu.Items.RemoveAt(6);

                                break;


                            case emGridType.AUTO_COL:

                                //컬럼 자동크기(전체) 기본삭제

                                menu.Items.RemoveAt(9);




                                menu.Items.Add(menuItemColumn);

                                menuItemColumn.BeginGroup = true;


                                menu.Items.Add(menuItemShow);

                                menu.Items.Add(menuItemMethod);

                                menu.Items.Add(menuItemStyleBox);

                                menu.Items.Add(menuItemConfig);
                                menuItemConfig.BeginGroup = true;


                                menu.Items.Add(menuItemSaveFile);
                                menuItemSaveFile.BeginGroup = true;

                                menu.Items.Add(menuItemCustomExcel);
                                menuItemCustomExcel.BeginGroup = true;

                                menu.Items.Add(menuItemDefaultPrint);
                                menuItemDefaultPrint.BeginGroup = true;


                                menu.Items.Add(menuHelp);
                                menuHelp.BeginGroup = true;

                                break;



                        }

                    }


                    #endregion


                }
                else if (hitInfo.HitTest == GridHitTest.Footer || hitInfo.HitTest == GridHitTest.RowFooter)
                {
                    //풋더
                    acGridColumn acCol = (acGridColumn)hitInfo.Column;

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
            }
            catch (Exception ex)
            {

            }

        }

        private void MenuAssignCustomExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RowCount == 0)
                {
                    acMessageBox.Show("데이터가 존재하지 않습니다.", "엑셀 저장", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataSet paramCusSet = new DataSet();
                DataTable paramCusTable = paramCusSet.Tables.Add("RQSTDT");
                paramCusTable.Columns.Add("PLT_CODE", typeof(String));
                paramCusTable.Columns.Add("CUS_ID", typeof(String));

                DataRow paramCusRow = paramCusTable.NewRow();
                paramCusRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramCusRow["CUS_ID"] = _CustomReportCusID;
                paramCusTable.Rows.Add(paramCusRow);

                DataSet rsltExcelFileSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USE_CUSTOM_EXCELFILE", paramCusSet, "RQSTDT", "RSLTDT_M,RSLTDT_D");

                if (rsltExcelFileSet.Tables.Contains("RSLTDT_M") && rsltExcelFileSet.Tables["RSLTDT_M"].Rows.Count > 0)
                {

                    Dictionary<string, string> dicCol = new Dictionary<string, string>();
                    Dictionary<string, int> dicColRowidx = new Dictionary<string, int>();
                    Regex reg = new Regex(@"\d");
                    foreach (DataRow colRow in rsltExcelFileSet.Tables["RSLTDT_D"].Rows)
                    {
                        string colName = colRow["CONNET_COLUMN_NAME"].toStringEmpty();
                        string startCellName = colRow["START_CELL_NAME"].toStringEmpty();
                    //설정한 값이 없기때문에 건너띄기
                    if (startCellName.isNullOrEmpty()) continue;
                        if (!dicCol.ContainsKey(colName) && this.Columns.ColumnByFieldName(colName) != null)
                        {
                            string regVal = reg.Match(startCellName).Value;
                            dicCol.Add(colName, startCellName.Replace(regVal, ""));
                            dicColRowidx.Add(colName, regVal.toInt());
                        }
                    }

                    DataRow customExcelFileRow = rsltExcelFileSet.Tables["RSLTDT_M"].Rows[0];

                    using (DevExpress.XtraSpreadsheet.SpreadsheetControl ssc = new DevExpress.XtraSpreadsheet.SpreadsheetControl())
                    {
                        ssc.LoadDocument(customExcelFileRow["FILE_DATA"] as byte[]);
                        using (DevExpress.Spreadsheet.IWorkbook wb = ssc.Document)
                        {
                            DevExpress.Spreadsheet.Worksheet ws = wb.Worksheets[0];

                            switch (customExcelFileRow["EXPORT_TYPE"])
                            {
                            //리스트형태
                            case "LIST":
                                    {
                                        //foreach (DataRowView exportDataRow in this.GetDataSourceView())
                                        for (int i = 0; i < this.RowCount; i++)
                                        {
                                            foreach (string dicKey in dicCol.Keys)
                                            {
                                                //ws[dicCol[dicKey] + (dicColRowidx[dicKey]++)].Value = exportDataRow[dicKey].toStringEmpty();
                                                ws[dicCol[dicKey] + (dicColRowidx[dicKey]++)].Value = this.GetRowCellDisplayText(i, dicKey);
                                            }
                                        }

                                        SaveFileDialog sfd = new SaveFileDialog();
                                        sfd.Filter = "Excel(*.xlsx)|*.xlsx";
                                        if (sfd.ShowDialog() == DialogResult.OK)
                                        {
                                            ssc.SaveDocument(sfd.FileName);

                                            if (acMessageBox.Show("저장한 파일을 열어보시겠습니까?", "저장", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                                            {
                                                System.Diagnostics.Process.Start(sfd.FileName);
                                            }
                                        }

                                        break;
                                    }
                            //각각파일 형태
                            case "EACH":
                                    {
                                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                                        if (fbd.ShowDialog() == DialogResult.OK)
                                        {
                                            int fileIndex = 1;
                                            string dNow = DateTime.Now.ToString("yyyyMMddHHmm");

                                            if (!Directory.Exists(fbd.SelectedPath + "\\" + dNow + "\\"))
                                            {
                                                Directory.CreateDirectory(fbd.SelectedPath + "\\" + dNow + "\\");
                                            }

                                            //foreach (DataRowView exportDataRow in this.GetDataSourceView())
                                            for(int i=0;i<this.RowCount;i++)
                                            {
                                                foreach (string dicKey in dicCol.Keys)
                                                {
                                                    //ws[dicCol[dicKey] + (dicColRowidx[dicKey])].Value = exportDataRow[dicKey].toStringEmpty();
                                                    ws[dicCol[dicKey] + (dicColRowidx[dicKey])].Value = this.GetRowCellDisplayText(i, dicKey);
                                                }

                                                ssc.SaveDocument(fbd.SelectedPath + "\\" + dNow + "\\" + (fileIndex++) + ".xlsx", DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                                            }
                                        }

                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        internal void RaiseShowGridPopupMenu(GridHitInfo hitInfo, Point pt)
        {

            GridHitInfo hi = this.CalcHitInfo(this.GridControl.PointToClient(pt));


            if (hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.ColumnPanel)
            {

                GridViewColumnMenu columnMenu = new GridViewColumnMenu(this);

                columnMenu.Init(hi.Column);

                this.SetGridColumnMenu(columnMenu, hi);

                columnMenu.Show(this.GridControl.PointToClient(pt));


            }
            else if (hi.HitTest == GridHitTest.Footer || hi.HitTest == GridHitTest.RowFooter)
            {


                GridViewFooterMenu footerMenu = new GridViewFooterMenu(this);

                footerMenu.Init(hi);

                this.SetGridColumnMenu(footerMenu, hi);

                footerMenu.Show(this.GridControl.PointToClient(pt));
            }


            if (this.ShowGridMenuEx != null)
            {


                GridMenuType menuType = GridMenuType.User;

                if (hi.HitTest == GridHitTest.EmptyRow)
                {
                    DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);


                    menuType = GridMenuType.User;


                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }
                else if (hi.HitTest == GridHitTest.Row || hi.HitTest == GridHitTest.RowCell || hi.HitTest == GridHitTest.RowEdge || hi.HitTest == GridHitTest.RowDetail)
                {
                    DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);

                    menuType = GridMenuType.Row;

                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }
                else if (hi.HitTest == GridHitTest.Footer || hi.HitTest == GridHitTest.RowFooter)
                {
                    DevExpress.XtraGrid.Menu.GridViewFooterMenu menu = new GridViewFooterMenu(this);

                    menuType = GridMenuType.Summary;

                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }


            }

        }

        #region 병합 컬럼 Editor 구현
        protected override void ActivateEditor(GridCellInfo cell)
        {
            try
            {
                if (cell.MergedCell == null)
                {
                    base.ActivateEditor(cell);
                }
                else
                {
                    ActivateMergedCellEditor(cell);
                }
            }
            catch{

            }
        }

        private void ActivateMergedCellEditor(GridCellInfo cell)
        {
            if (cell == null) return;
            cell = cell.MergedCell.MergedCells[0];
            this.fEditingCell = cell;
            Rectangle bounds = GetMergedEditorBounds(cell);
            if (bounds.IsEmpty) return;
            RepositoryItem cellEdit = RequestCellEditor(cell);
            ViewInfo.UpdateCellAppearance(cell);
            ViewInfo.RequestCellEditViewInfo(cell);
            AppearanceObject appearance = new AppearanceObject();
            AppearanceHelper.Combine(appearance, new AppearanceObject[] { GetEditorAppearance(), ViewInfo.PaintAppearance.Row, cell.Appearance });
            if (cellEdit != cell.Editor && cellEdit.DefaultAlignment != HorzAlignment.Default)
            {
                appearance.TextOptions.HAlignment = cellEdit.DefaultAlignment;
            }
            UpdateEditor(cellEdit, new DevExpress.XtraEditors.Container.UpdateEditorInfoArgs(GetColumnReadOnly(cell.ColumnInfo.Column), bounds, appearance, cell.CellValue, ElementsLookAndFeel, cell.ViewInfo.ErrorIconText, cell.ViewInfo.ErrorIcon));
            ViewInfo.UpdateCellAppearance(cell);
            if (cell != null)
                InvalidateRow(cell.RowHandle);
        }
        Rectangle GetMergedEditorBounds(GridCellInfo cell)
        {
            Rectangle r = cell.CellValueRect;
            Rectangle bounds = ViewInfo.UpdateFixedRange(r, cell.ColumnInfo);
            if (bounds.Right > ViewInfo.ViewRects.Rows.Right)
            {
                bounds.Width = ViewInfo.ViewRects.Rows.Right - bounds.Left;
            }
            if (bounds.Bottom > ViewInfo.ViewRects.Rows.Bottom)
            {
                bounds.Height = ViewInfo.ViewRects.Rows.Bottom - bounds.Top;
            }
            if (bounds.Width < 1 || bounds.Height < 1) return Rectangle.Empty; ;

            for (int i = 1; i < cell.MergedCell.MergedCells.Count; i++)
                bounds.Height += cell.MergedCell.MergedCells[i].Bounds.Height;
            return bounds;
        }
        protected override bool PostEditor(bool causeValidation)
        {
            try
            {
                if (IsEditing)
                if ( this.fEditingCell != null)
                    {
                        if (this.fEditingCell.MergedCell != null)
                        {
                            int cellCnt = fEditingCell.MergedCell.MergedCells.Count;
                            int rowHandle = fEditingCell.RowHandle;
                            GridColumn gc = fEditingCell.Column;

                            object CurValue = ExtractEditingValue(fEditingCell.ColumnInfo.Column, EditingValue);
                            for (int i = 0; i < cellCnt; i++)
                            {
                                this.SetRowCellValue(rowHandle + i, gc, CurValue);
                            }
                        }
                    }
                    
                return base.PostEditor(causeValidation);
            }catch
            {                
                return base.PostEditor(causeValidation);
            }
        }
        #endregion
        //DevExpress Version-Up으로 인한 경고
        //경고	6	'DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs'은(는) 사용되지 않습니다. 'You should use the 'PopupMenuShowingEventArgs' instead'	

        //internal void RaiseShowGridPopupMenu(GridHitInfo hitInfo, Point pt)
        //{

        //    GridHitInfo hi = this.CalcHitInfo(this.GridControl.PointToClient(pt));


        //    if (hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.ColumnPanel)
        //    {

        //        GridViewColumnMenu columnMenu = new GridViewColumnMenu(this);

        //        columnMenu.Init(hi.Column);

        //        this.SetGridColumnMenu(columnMenu, hi);

        //        columnMenu.Show(this.GridControl.PointToClient(pt));


        //    }
        //    else if (hi.HitTest == GridHitTest.Footer || hi.HitTest == GridHitTest.RowFooter)
        //    {


        //        GridViewFooterMenu footerMenu = new GridViewFooterMenu(this);

        //        footerMenu.Init(hi);

        //        this.SetGridColumnMenu(footerMenu, hi);

        //        footerMenu.Show(this.GridControl.PointToClient(pt));
        //    }


        //    if (this.ShowGridMenuEx != null)
        //    {


        //        GridMenuType menuType = GridMenuType.User;

        //        if (hi.HitTest == GridHitTest.EmptyRow)
        //        {
        //            DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);


        //            menuType = GridMenuType.User;

        //            this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));

        //        }
        //        else if (hi.HitTest == GridHitTest.Row || hi.HitTest == GridHitTest.RowCell || hi.HitTest == GridHitTest.RowEdge)
        //        {
        //            DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);

        //            menuType = GridMenuType.Row;

        //            this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
        //        }
        //        else if (hi.HitTest == GridHitTest.Footer || hi.HitTest == GridHitTest.RowFooter)
        //        {
        //            DevExpress.XtraGrid.Menu.GridViewFooterMenu menu = new GridViewFooterMenu(this);

        //            menuType = GridMenuType.Summary;

        //            this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
        //        }


        //    }

        //}


    }
}
