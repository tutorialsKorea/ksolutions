using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Columns;
using System.Data;
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
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraEditors.TableLayout;
//using DevExpress.XtraRichEdit;

namespace ControlManager
{
    public class acTileViewColumnCollection : TileViewColumnCollection
    {
        public acTileViewColumnCollection(TileView view) : base(view) { }

        protected override GridColumn CreateColumn()
        {
            return new acTileViewColumn();
        }
    }


    public class acTileViewColumn : DevExpress.XtraGrid.Columns.TileViewColumn, IBaseViewControl
    {


        public acTileViewColumn()
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

                case acTileView.emEditorType.NONE:
                    {
                        return true;


                    }

                case acTileView.emEditorType.BUTTON:
                    {

                        return true;


                    }

                case acTileView.emEditorType.COLOR:
                    {
                        return true;


                    }


                case acTileView.emEditorType.CUSTOM:
                    {
                        return true;


                    }

                case acTileView.emEditorType.LOOKUP:
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

                case acTileView.emEditorType.LOOKUP_CODE:
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

                case acTileView.emEditorType.MEMO:
                    {
                        return true;


                    }

                case acTileView.emEditorType.PICTURE:
                    {
                        return true;


                    }

                case acTileView.emEditorType.PROGRESSBAR:
                    {
                        return true;


                    }
                case acTileView.emEditorType.TIME:
                    {
                        return true;


                    }

                case acTileView.emEditorType.TEXT:
                    {
                        if (this._EditorData is ControlManager.acTileView.emTextEditMask)
                        {
                            return true;
                        }

                        break;
                    }

                case acTileView.emEditorType.CHECK:
                    {

                        if (this._EditorData is ControlManager.acTileView.emCheckEditDataType)
                        {
                            return true;
                        }

                        break;
                    }

                case acTileView.emEditorType.DATE:
                    {
                        if (this._EditorData is ControlManager.acTileView.emDateMask)
                        {
                            return true;
                        }

                        break;

                    }

                case acTileView.emEditorType.DATE_STRING:
                    {

                        if (this._EditorData is string)
                        {
                            return true;
                        }

                        break;
                    }




            }

            return false;

        }


        private acTileView.emEditorType _EditorType = acTileView.emEditorType.NONE;

        public acTileView.emEditorType EditorType
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


    public class acTileViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "acTileView"; } }

        public override BaseView CreateView(GridControl grid)
        {
            return new acTileView(grid as GridControl);
        }
        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new acTileViewInfo(view as acTileView);
        }
    }

    public class acTileViewInfo : TileViewInfo
    {
        public acTileViewInfo(DevExpress.XtraGrid.Views.Tile.TileView TileView)
            : base(TileView)
        {

        }

    }

    public class acTileGridControl : GridControl, IControl
    {


        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WIN32API.WM_CONTEXTMENU)
            //{
            //    Point pt = new Point(m.LParam.ToInt32());

            //    Point cpt = this.PointToClient(pt);

            //    acTileView view = (acTileView)this.MainView;

            //    TileViewHitInfo hitInfo = view.CalcHitInfo(this.PointToClient(pt));
            //}

            base.WndProc(ref m);
        }


        private DevExpress.XtraBars.BarManager _DefaultBarManager = null;


        private System.Windows.Forms.Timer _VisibleTimer = null;

        public acTileGridControl()
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



            this.HandleDestroyed += new EventHandler(acTileGridControl_HandleDestroyed);


            //this.VisibleChanged += new EventHandler(acTileGridControl_VisibleChanged);


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
            }
            catch { }
        }

        public Pen SetFocusRowBorderPen = Pens.Transparent;
        public bool FocusRowBorderPenUse = false;
  
        private bool _InitLayout = false;


        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            acTileView view = this.MainView as acTileView;
            if (view != null
                && view.ParentControl == null)
            {
                view.ParentControl = this.GetContainerControl() as Control;
            }
        }


        void acTileGridControl_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible == true)
            {
                //보일때는 서브윈도우를 숨긴 창들을 표시

                acTileView view = (acTileView)this.MainView;


                if (view != null)
                {
                    //최초 한번만 실행


                    if (ControlManager.acInfo.IsRunTime == true)
                    {
                        if (this._InitLayout == false)
                        {


                            #region 시스템 UI 저장

                            acTileViewConfig systemConfig = new acTileViewConfig(view);

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




        void VisibleTimer_Tick(object sender, EventArgs e)
        {

            if (this.Visible == false)
            {
                //보이지않을때는 서브윈도우를 모두 숨긴다.

                acTileView view = (acTileView)this.MainView;

                if (view != null)
                {

                    view.HideSubWindows();

                }

                this._VisibleTimer.Stop();
            }


        }



        void acTileGridControl_HandleDestroyed(object sender, EventArgs e)
        {
            if (ControlManager.acInfo.IsRunTime == true)
            {
                acTileView view = (acTileView)this.MainView;

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

            acTileView view = (acTileView)this.MainView;

            if (temp != null)
            {
                Dictionary<string, Type> list = new Dictionary<string, Type>();

                //변환된 데이터형태 정의

                foreach (acTileViewColumn col in view.Columns)
                {

                    if (col.EditorType == acTileView.emEditorType.DATE)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acTileView.emEditorType.DATE_STRING)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acTileView.emEditorType.LOOKUP_CODE)
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


                acTileView view = (acTileView)this.MainView;

                //if (view._unraiseDSChanged) return;

                _OldFocusRowHandle = view.FocusedRowHandle;

                #region 데이터 변환

                DataTable temp = (DataTable)value;



                if (temp != null)
                {
                    Dictionary<string, Type> list = new Dictionary<string, Type>();

                    //변환된 데이터형태 정의

                    foreach (acTileViewColumn col in view.Columns)
                    {

                        if (col.EditorType == acTileView.emEditorType.DATE)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acTileView.emEditorType.DATE_STRING)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acTileView.emEditorType.LOOKUP_CODE)
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

            acTileView view = (acTileView)this.MainView;

            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    view._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);



                }

            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
                        (((acTileView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                         (((acTileView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {

                    acMessageBox.Show(view.ParentControl, ex);
                }
            }


        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acTileView view = (acTileView)this.MainView;

            acMessageBox.Show(view.ParentControl, ex);
        }


        //void QuickUse(object sender, QBiz qBiz, QBizr.ExcuteCompleteArgs e)
        //{

        //    acTileView view = (acTileView)this.MainView;

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
        //                (((acTileView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

        //        }
        //        else if (ex is DefaultSystemLayoutChangedException)
        //        {

        //            acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
        //                 (((acTileView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


        //        }
        //        else
        //        {

        //            acMessageBox.Show(view.ParentControl, ex);
        //        }
        //    }


        //}

        protected override BaseView CreateDefaultView()
        {
            return CreateView("acTileView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection
    collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new acTileViewInfoRegistrator());
        }

        #region IControl 멤버

        public void FocusContainer()
        {
            (this.MainView as acTileView).ParentControl.Focus();

        }

        #endregion
    }


    public class acTileView : DevExpress.XtraGrid.Views.Tile.TileView
    {
        List<TableColumnDefinition> _Columns;
        List<TableRowDefinition> _Rows;

        private int _ScrollSize = 17;
        private int _FirstMouseDownIdx = -1;
        private string _ColName;
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
            TEMP

        };


        public enum emCheckEditDataType { _BOOL, _STRING, _INT, _BYTE, _YN };

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
                acTileGridControl acGrid = (acTileGridControl)this.GridControl;

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
        internal acTileViewConfig _Config = null;

        internal bool _noApplyEditableCellColor = false;

        public bool NoApplyEditableCellColor
        {
            get { return _noApplyEditableCellColor; }
            set { _noApplyEditableCellColor = value; }
        }


        protected override GridColumnCollection CreateColumnCollection()
        {
            return new acTileViewColumnCollection(this);

        }



        //void SetGridType()
        //{
        //    switch (this._GridType)
        //    {

        //        case ControlManager.acTileView.emGridType.SEARCH:

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.Option.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = true;

        //            this.OptionsMenu.EnableGroupPanelMenu = true;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = true;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = false;

        //            this.OptionsView.ShowIndicator = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;

        //            this._IsLoadConfig = true;

        //            break;


        //        case ControlManager.acTileView.emGridType.SEARCH_SEL:

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = true;

        //            this.OptionsMenu.EnableGroupPanelMenu = true;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = true;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = false;

        //            this.OptionsView.ShowIndicator = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;

        //            this._IsLoadConfig = true;

        //            this.OptionsSelection.MultiSelect = true;
        //            this.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

        //            break;

        //        case ControlManager.acTileView.emGridType.FIXED:


        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;

        //            this.OptionsCustomization.AllowColumnMoving = false;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsView.ShowGroupPanel = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = false;

        //            this.OptionsView.ShowIndicator = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;

        //            break;

        //        case ControlManager.acTileView.emGridType.FIXED_FULLWIDTH:


        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = false;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsView.ShowGroupPanel = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsView.ShowIndicator = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;

        //            break;

        //        case ControlManager.acTileView.emGridType.FIXED_EXCEL:


        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = false;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsView.ShowGroupPanel = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;

        //            this.OptionsView.ColumnAutoWidth = false;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;

        //            break;

        //        case emGridType.FIXED_SINGLE:


        //            this.FocusRectStyle = DrawFocusRectStyle.CellFocus;

        //            this.OptionsMenu.EnableColumnMenu = false;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = false;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = false;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;


        //            break;

        //        case ControlManager.acTileView.emGridType.COMMON_CONTROL:


        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;

        //            this.OptionsView.ShowGroupPanel = false;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;


        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;

        //            break;

        //        case ControlManager.acTileView.emGridType.LIST_USERCONFIG:


        //            this.OptionsMenu.EnableColumnMenu = false;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = false;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this._IsLoadConfig = true;

        //            break;

        //        case ControlManager.acTileView.emGridType.LIST_USERCONFIG2:


        //            this.OptionsMenu.EnableColumnMenu = false;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = false;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = false;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = false;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this._IsLoadConfig = true;

        //            break;

        //        case ControlManager.acTileView.emGridType.LIST:

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = true;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = true;
        //            this._IsLoadConfig = false;

        //            break;

        //        case ControlManager.acTileView.emGridType.ATTACH_FILE_LIST:

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;


        //            this.OptionsCustomization.AllowColumnMoving = false;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = false;

        //            this.OptionsCustomization.AllowSort = true;


        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;

        //            break;


        //        case ControlManager.acTileView.emGridType.LIST_SINGLE:

        //            this.FocusRectStyle = DrawFocusRectStyle.CellFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = false;

        //            this.OptionsMenu.EnableGroupPanelMenu = false;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = true;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = false;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = false;
        //            this._IsLoadConfig = false;


        //            break;

        //        case ControlManager.acTileView.emGridType.AUTO_COL:

        //            this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

        //            this.OptionsMenu.EnableColumnMenu = true;

        //            this.OptionsMenu.EnableFooterMenu = true;

        //            this.OptionsMenu.EnableGroupPanelMenu = true;

        //            this.OptionsCustomization.AllowColumnMoving = true;

        //            this.OptionsCustomization.AllowFilter = true;

        //            this.OptionsCustomization.AllowGroup = true;

        //            this.OptionsCustomization.AllowSort = true;

        //            this.OptionsView.ColumnAutoWidth = true;

        //            this.OptionsSelection.EnableAppearanceFocusedCell = true;
        //            this.OptionsSelection.EnableAppearanceFocusedRow = true;
        //            this.OptionsSelection.EnableAppearanceHideSelection = true;

        //            this._Config.AlwaysBestFit = true;

        //            this._IsLoadConfig = true;

        //            break;



        //    }

        //    this._Config.EditCellStyle.BackColor = Color.LemonChiffon;
        //    this.Appearance.ItemFocused.BackColor = Color.AliceBlue;
        //    this.Appearance.ItemSelected.BackColor = Color.AliceBlue;

        //}


        private emGridType _GridType = emGridType.SEARCH;

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
                    //acTileView1.GridControl.LookAndFeel.SkinName = "Sharp Plus";
                    this.Appearance.ViewCaption.Options.UseBackColor = true;
                    this.Appearance.ViewCaption.BackColor = ColorTranslator.FromHtml("#708090");// System.Drawing.Color.DarkBlue;
                    this.Appearance.ViewCaption.Options.UseForeColor = true;
                    this.Appearance.ViewCaption.ForeColor = System.Drawing.Color.White;
                    this.Appearance.ViewCaption.Options.UseFont = true;
                    this.Appearance.ViewCaption.Font = new Font("맑은 고딕", this.Appearance.ViewCaption.Font.Size, FontStyle.Bold);

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
        #endregion

        private void Init()
        {

            this.OptionsLayout.StoreAllOptions = true;

            this.OptionsLayout.Columns.StoreAllOptions = true;

            if (acInfo.IsRunTime == true)
            {
                this._DefaultTable = new DataTable();

                if (!this._DefaultTable.Columns.Contains("GRID_ROW_SEQ"))
                {
                    this._DefaultTable.Columns.Add("GRID_ROW_SEQ", typeof(int));
                }
                this._Config = new acTileViewConfig(this);
            }


            this.MouseDown += new MouseEventHandler(acTileView_MouseDown);
            //this.MouseMove += new MouseEventHandler(acTileView_MouseMove);
            //this.MouseUp += new MouseEventHandler(acTileView_MouseUp);

            //this.ShowGridMenuEx += new GridMenuEventHandler(acTileView_ShowGridMenu);
            this.ShowGridMenuEx += new ShowGridMenuExHandler(acTileView_ShowGridMenuEx); ;

            this.Disposed += new EventHandler(acTileView_Disposed);

            this.DataSourceChanged += new EventHandler(acTileView_DataSourceChanged);
        }

		protected override void OnGridLoadComplete()
		{
			base.OnGridLoadComplete();
            
            try
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("IS_FORM_ICON_COLOR_USE").toStringEmpty().Equals("1"))
                {
                    foreach (acTileViewColumn col in this.Columns)
                    {
                        if (col.ColumnEdit is RepositoryItemButtonEdit)
                        {
                            RepositoryItemButtonEdit rib = col.ColumnEdit as RepositoryItemButtonEdit;
                            rib.Buttons[0].Image = ChangeIconColor(rib.Buttons[0].Image, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
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

                    if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }
        void acTileView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void acTileView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            this._ColumnHeaderHeight = e.Bounds.Height;
            this._ColumnHeaderCustomDrawEventArgs = e;
        }

        void acTileView_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void acTileView_DataSourceChanged(object sender, EventArgs e)
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

        void acTileView_DragObjectStart(object sender, DragObjectStartEventArgs e)
        {
            //드래그 컬럼 정보 저장

            acTileViewColumn cln = e.DragObject as acTileViewColumn;

            this._DragDropColumnVisibleIdx = cln.VisibleIndex;


        }

        void acTileView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
            acTileViewColumn cln = e.DragObject as acTileViewColumn;

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

        void acTileView_MouseDown(object sender, MouseEventArgs e)
        {
            this._MouseDownArgs = e;
            if (this._FirstMouseDownIdx == -1)
            {
                TileViewHitInfo hitInfo = this.CalcHitInfo(e.Location);

                if (hitInfo.RowHandle < 0)
                    return;

                if (hitInfo.Item == null)
                    return;

                if (hitInfo.Item != null && hitInfo.Item.GetType() == typeof(RepositoryItemCheckEdit))
                {
                    this._FirstMouseDownIdx = hitInfo.RowHandle;
                    this._PreRowhandle = hitInfo.RowHandle;
                    this._ColName = hitInfo.Item.Name;
                }
            }
        }

        int _PreRowhandle = -1;
        private void acTileView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_PreRowhandle == -1)
                return;

            //드래그중
            if (e.Button.HasFlag(MouseButtons.Left)
                && this._FirstMouseDownIdx >= 0)
            {

                TileViewHitInfo hitInfo = this.CalcHitInfo(e.Location);

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
        private void acTileView_MouseUp(object sender, MouseEventArgs e)
        {

            if (this._FirstMouseDownIdx >= 0)
            {
                TileViewHitInfo hitInfo = this.CalcHitInfo(e.Location);

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

        void acTileView_HideCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = false;
        }

        void acTileView_ShowCustomizationForm(object sender, EventArgs e)
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

                    acTileViewColumn col = this.Columns[item.FieldName] as acTileViewColumn;

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

                    acTileViewColumn col = this.Columns[item.FieldName] as acTileViewColumn;

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


        void acTileView_Disposed(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, acTileViewMaskEdit> mask in _MaskEditors)
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
     
        private int _IndicatorWidth = 0;
        public acTileView(GridControl owerGridControl)
            : base(owerGridControl)
        {

            this.Init();
        }


        public acTileView()
            : base()
        {

            this.Init();
        }

        private bool _ShowGroupFooter = false;


        /// <summary>
        /// 그리드에 종속적인 창들을 모두 숨긴다.
        /// </summary>
        internal void HideSubWindows()
        {
            //마스크 에디터

            foreach (KeyValuePair<string, acTileViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Hide();

            }


        }

        /// <summary>
        /// 현재 사용자UI를 시스템UI로 저장한다.
        /// </summary>
        private void SaveSystemUserConfig()
        {
            acTileViewConfig systemConfig = new acTileViewConfig(this);

            acTileGridControl acTileGridControl = (acTileGridControl)this.GridControl;

            byte[] layout = null;
            byte[] config = null;


            systemConfig.Save(out layout, out config);

            acTileGridControl._SystemLayout = layout;
            acTileGridControl._SystemConfig = config;
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

            acTileGridControl acGrid = this.GridControl as acTileGridControl;

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
            acTileGridControl grid = (this.GridControl as acTileGridControl);


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
                        (((acTileView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                        (((acTileView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


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
            //마스크 에디터

            foreach (KeyValuePair<string, acTileViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Show();

            }
        }


        private Dictionary<string, acTileViewMaskEdit> _MaskEditors = new Dictionary<string, acTileViewMaskEdit>();

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
                acTileViewColumn acCol = (acTileViewColumn)this.Columns[col.ColumnName];

                if (acCol != null)
                {

                    if (acCol.EditorType == acTileView.emEditorType.DATE)
                    {
                        if (col.DataType != typeof(DateTime))
                        {

                            list.Add(col.ColumnName, typeof(DateTime));

                        }
                    }
                    else if (acCol.EditorType == acTileView.emEditorType.LOOKUP_CODE)
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

            foreach (acTileViewColumn col in this.Columns)
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
            acTileGridControl grid = this.GridControl as acTileGridControl;

            ((DataTable)grid.DataSource).AcceptChanges();


        }

        public void RejectChanges()
        {
            acTileGridControl grid = this.GridControl as acTileGridControl;

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

                string filterExpression = GetFilterExpression(view);
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

                        dv.RowFilter = "(" + currentFilter + ")";

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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

        public void AddPictrue(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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

            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired)
        {
            acTileViewColumn col = new acTileViewColumn();

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



            col.EditorType = emEditorType.BUTTON;

            _DefaultTable.Columns.Add(columnName, typeof(string));

            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();

            btnEdit.TextEditStyle = textEditStyle;

            btnEdit.Mask.UseMaskAsDisplayFormat = true;

            btnEdit.Appearance.TextOptions.HAlignment = align;

            btnEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = btnEdit;

            this.Columns.Add(col);
        }

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired
                                ,Image img, DevExpress.XtraEditors.Controls.ButtonPredefines bp, ButtonPressedEventHandler bpeHandler)
        {
            acTileViewColumn col = new acTileViewColumn();
            
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
            acTileViewColumn col = new acTileViewColumn();

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

            col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;

            Dictionary<string, object> editorData = new Dictionary<string, object>();


            col.EditorData = editorData;


            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            //lookupEdit.UseCtrlScroll = true;
            //lookupEdit.AllowMouseWheel = false;
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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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


        public void AddLookUpOrg(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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



        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            acTileViewColumn col = new acTileViewColumn();

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

        }

        void lookupEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.SetFocusedValue(DBNull.Value);
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
            acTileViewColumn col = new acTileViewColumn();

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
            acTileViewColumn col = new acTileViewColumn();

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

            lookupEdit.KeyDown += new KeyEventHandler(lookupEdit_KeyDown);

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




        public void AddCheckEdit(string columnName, string caption, string resourceID, bool useReSourceID, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType)
        {
            acTileViewColumn col = new acTileViewColumn();

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

                case emCheckEditDataType._YN:

                    checkItemEdit.ValueChecked = "Y";
                    checkItemEdit.ValueUnchecked = "N";

                    _DefaultTable.Columns.Add(columnName, typeof(string));

                    break;



            }

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
                acTileViewColumn col = new acTileViewColumn();

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
        /// <param name="pcc"></param>
        public void AddPopupContainerEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, PopupContainerControl pcc)
        {

            try
            {
                acTileViewColumn col = new acTileViewColumn();

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
                acTileViewColumn col = new acTileViewColumn();

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
                acTileViewColumn col = AddTextEdit(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired, mask);
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
        public acTileViewColumn AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask)
        {

            try
            {
                acTileViewColumn col = new acTileViewColumn();

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


        public acTileViewColumn AddTextEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, DevExpress.XtraEditors.Mask.MaskType mask, string editMask)
        {

            try
            {
                acTileViewColumn col = new acTileViewColumn();

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

                    acTileViewColumn col = item.Tag as acTileViewColumn;

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


        }

        void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextEdit editor = sender as TextEdit;

            if (editor.Tag != null)
            {
                if (editor.Tag is RepositoryItem)
                {
                    RepositoryItem item = editor.Tag as RepositoryItem;

                    acTileViewColumn col = item.Tag as acTileViewColumn;

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
                acTileViewColumn col = new acTileViewColumn();

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

        //public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public event ShowGridMenuExHandler ShowGridMenuEx;

    }
}
