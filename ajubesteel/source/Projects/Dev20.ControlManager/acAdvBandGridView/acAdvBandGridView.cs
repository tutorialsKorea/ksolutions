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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraEditors.ViewInfo;
using BizManager;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using System.Text.RegularExpressions;

namespace ControlManager
{
    //public class acAdvBandedGridColumnCollection : BandedGridColumnCollection
    //{
    //    public acAdvBandedGridColumnCollection(ColumnView view) : base(view) { }

    //    //public acAdvBandedGridColumnCollection(AdvBandedGridView view) : base(view) { }

    //    protected override BandedGridColumn CreateGridColumn()
    //    {
    //        BandedGridColumn dd = new BandedGridColumn();

    //        return new acAdvBandedGridColumn();
    //    }
    //}


    public class acAdvBandedGridColumn : BandedGridColumn, IBaseViewControl
    {


        public acAdvBandedGridColumn()
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

                case acAdvBandGridView.emEditorType.NONE:
                    {
                        return true;


                    }

                case acAdvBandGridView.emEditorType.BUTTON:
                    {

                        return true;


                    }

                case acAdvBandGridView.emEditorType.COLOR:
                    {
                        return true;


                    }


                case acAdvBandGridView.emEditorType.CUSTOM:
                    {
                        return true;


                    }

                case acAdvBandGridView.emEditorType.LOOKUP:
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

                case acAdvBandGridView.emEditorType.LOOKUP_CODE:
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

                case acAdvBandGridView.emEditorType.MEMO:
                    {
                        return true;


                    }

                case acAdvBandGridView.emEditorType.PICTURE:
                    {
                        return true;


                    }

                case acAdvBandGridView.emEditorType.PROGRESSBAR:
                    {
                        return true;


                    }
                case acAdvBandGridView.emEditorType.TIME:
                    {
                        return true;


                    }

                case acAdvBandGridView.emEditorType.TEXT:
                    {
                        if (this._EditorData is ControlManager.acAdvBandGridView.emTextEditMask)
                        {
                            return true;
                        }

                        break;
                    }

                case acAdvBandGridView.emEditorType.CHECK:
                    {

                        if (this._EditorData is ControlManager.acAdvBandGridView.emCheckEditDataType)
                        {
                            return true;
                        }

                        break;
                    }

                case acAdvBandGridView.emEditorType.DATE:
                    {
                        if (this._EditorData is ControlManager.acAdvBandGridView.emDateMask)
                        {
                            return true;
                        }

                        break;

                    }

                case acAdvBandGridView.emEditorType.DATE_STRING:
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


        private acAdvBandGridView.emEditorType _EditorType = acAdvBandGridView.emEditorType.NONE;

        public acAdvBandGridView.emEditorType EditorType
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


    public class acAdvBandGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "acAdvBandGridView"; } }

        public override BaseView CreateView(GridControl grid)
        {
            return new acAdvBandGridView(grid as GridControl);
        }
        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new acAdvBandGridViewInfo(view as acAdvBandGridView);
        }
    }

    public class acAdvBandGridViewInfo : GridViewInfo
    {
        public acAdvBandGridViewInfo(DevExpress.XtraGrid.Views.Grid.GridView gridView)
            : base(gridView)
        {

        }

    }




    public class acAdvBandGridControl : GridControl, IControl
    {


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WIN32API.WM_CONTEXTMENU)
            {
                Point pt = new Point(m.LParam.ToInt32());

                Point cpt = this.PointToClient(pt);

                acAdvBandGridView view = (acAdvBandGridView)this.MainView;

                BandedGridHitInfo hitInfo = view.CalcHitInfo(this.PointToClient(pt));


                view.RaiseShowGridPopupMenu(hitInfo, pt);

            }

            base.WndProc(ref m);
        }


        private DevExpress.XtraBars.BarManager _DefaultBarManager = null;


        private System.Windows.Forms.Timer _VisibleTimer = null;

        public acAdvBandGridControl()
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
                this.Paint += acAdvBandGridControl_Paint;
            }
            catch { }

        }

        public Pen SetFocusRowBorderPen = Pens.Transparent;
        public bool FocusRowBorderPenUse = false;
        private void acAdvBandGridControl_Paint(object sender, PaintEventArgs e)
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



        void acGridControl_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible == true)
            {
                //보일때는 서브윈도우를 숨긴 창들을 표시

                acAdvBandGridView view = (acAdvBandGridView)this.MainView;


                if (view != null)
                {
                    //최초 한번만 실행


                    if (ControlManager.acInfo.IsRunTime == true)
                    {
                        if (this._InitLayout == false)
                        {


                            #region 시스템 UI 저장

                            //acAdvBandGridViewConfig systemConfig = new acAdvBandGridViewConfig(view);

                            //systemConfig.Save(out _SystemLayout, out _SystemConfig);

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

                acAdvBandGridView view = (acAdvBandGridView)this.MainView;

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
                acAdvBandGridView view = (acAdvBandGridView)this.MainView;

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

            acAdvBandGridView view = (acAdvBandGridView)this.MainView;

            if (temp != null)
            {
                Dictionary<string, Type> list = new Dictionary<string, Type>();

                //변환된 데이터형태 정의

                foreach (acAdvBandedGridColumn col in view.Columns)
                {

                    if (col.EditorType == acAdvBandGridView.emEditorType.DATE)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acAdvBandGridView.emEditorType.DATE_STRING)
                    {
                        if (temp.Columns.Contains(col.FieldName))
                        {
                            if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                            {

                                list.Add(col.FieldName, typeof(DateTime));

                            }
                        }
                    }
                    else if (col.EditorType == acAdvBandGridView.emEditorType.LOOKUP_CODE)
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


                acAdvBandGridView view = (acAdvBandGridView)this.MainView;


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

                this.Enabled = false;


                #region 데이터 변환

                DataTable temp = (DataTable)value;



                if (temp != null)
                {
                    Dictionary<string, Type> list = new Dictionary<string, Type>();

                    //변환된 데이터형태 정의

                    foreach (acAdvBandedGridColumn col in view.Columns)
                    {

                        if (col.EditorType == acAdvBandGridView.emEditorType.DATE)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acAdvBandGridView.emEditorType.DATE_STRING)
                        {
                            if (temp.Columns.Contains(col.FieldName))
                            {
                                if (temp.Columns[col.FieldName].DataType != typeof(DateTime))
                                {

                                    list.Add(col.FieldName, typeof(DateTime));

                                }
                            }
                        }
                        else if (col.EditorType == acAdvBandGridView.emEditorType.LOOKUP_CODE)
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





                this.Enabled = true;


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

            acAdvBandGridView view = (acAdvBandGridView)this.MainView;

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
                        (((acAdvBandGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                         (((acAdvBandGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {

                    acMessageBox.Show(view.ParentControl, ex);
                }
            }


        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acAdvBandGridView view = (acAdvBandGridView)this.MainView;

            acMessageBox.Show(view.ParentControl, ex);
        }


        //void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{

        //    acAdvBandGridView view = (acAdvBandGridView)this.MainView;

        //    try
        //    {

        //        if (e.result.Tables["RSLTDT"].Rows.Count != 0)
        //        {
        //            DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

        //            byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
        //            byte[] configBuffer = (byte[])configRow["OBJECT"];

        //            //view._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);



        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is TargetInvocationException)
        //        {
        //            acMessageBox.Show(acInfo.Resource.GetString("사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY"),
        //                (((acAdvBandGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

        //        }
        //        else if (ex is DefaultSystemLayoutChangedException)
        //        {

        //            acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
        //                 (((acAdvBandGridView)this.MainView).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


        //        }
        //        else
        //        {

        //            acMessageBox.Show(view.ParentControl, ex);
        //        }
        //    }


        //}

        void acGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                //단축키 설정
                acAdvBandGridView view = (acAdvBandGridView)this.MainView;

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
            catch //(Exception ex)
            { }

        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("acAdvBandGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection
    collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new acAdvBandGridViewInfoRegistrator());
        }

        #region IControl 멤버

        public void FocusContainer()
        {
            (this.MainView as acAdvBandGridView).ParentControl.Focus();

        }

        #endregion
    }


    public class acAdvBandGridView : DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    {
        private int _ScrollSize = 17;

        private bool _UserUseFont = false;

        public bool UserUseFont
        {
            set { _UserUseFont = value; }
            get { return _UserUseFont; }
        }

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

            CUSTOM

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
            /// 수량
            /// </summary>
            QTY,
            /// <summary>
            /// 톤(한글)
            /// </summary>
            TON,
            /// <summary>
            /// Percent(%)
            /// </summary>
            PER_UNIT,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY,


            /// <summary>
            /// 파일크기
            /// </summary>
            FILE_SIZE,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,

            /// <summary>
            /// 퍼센트 소수점 첫째자리
            /// </summary>
            PER1,

            /// <summary>
            /// 퍼센트 소수점 둘째자리
            /// </summary>
            PER2,


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
            /// 소수점 세째자리
            /// </summary>
            F3,

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
            LAW

        };


        public enum emCheckEditDataType { _BOOL, _STRING, _INT, _BYTE };

        public enum emGridType
        {
            /// <summary>
            /// 조회 그리드
            /// </summary>
            SEARCH,


            /// <summary>
            /// 고정 그리드
            /// </summary>
            FIXED,

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
            AUTO_COL,

            SEARCH_FONT

            

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
                acAdvBandGridControl acGrid = (acAdvBandGridControl)this.GridControl;

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



        /// <summary>
        /// 사용자 UI
        /// </summary>
        internal acAdvBandGridViewConfig _Config = null;







        //protected override BandedGridColumnCollection CreateBandColumnCollection()
        //{
        //    return new acAdvBandedGridColumnCollection(this);

        //}



        void SetGridType()
        {
            switch (this._GridType)
            {

                case ControlManager.acAdvBandGridView.emGridType.SEARCH:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = true;

                    this.OptionsMenu.EnableGroupPanelMenu = true;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = false;
                    //this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    
                    this._IsLoadConfig = true;

                    break;

                case ControlManager.acAdvBandGridView.emGridType.SEARCH_FONT:

                    this.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                    this.OptionsMenu.EnableColumnMenu = true;

                    this.OptionsMenu.EnableFooterMenu = true;

                    this.OptionsMenu.EnableGroupPanelMenu = true;

                    this.OptionsCustomization.AllowColumnMoving = true;

                    this.OptionsCustomization.AllowFilter = true;

                    this.OptionsCustomization.AllowGroup = true;

                    this.OptionsCustomization.AllowSort = true;

                    this.OptionsView.ColumnAutoWidth = false;
                    //this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = true;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;

                    this._Config.EditCellStyle.Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), 13);

                    this._Config.ModifiedRowStyle.Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), 13);

                    this._IsLoadConfig = true;

                    break;

                case ControlManager.acAdvBandGridView.emGridType.FIXED:


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

                case ControlManager.acAdvBandGridView.emGridType.FIXED_EXCEL:


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

                    this.OptionsView.ColumnAutoWidth = true;

                    this.OptionsSelection.EnableAppearanceFocusedCell = false;
                    this.OptionsSelection.EnableAppearanceFocusedRow = true;
                    this.OptionsSelection.EnableAppearanceHideSelection = true;

                    this._Config.AlwaysBestFit = false;
                    this._IsLoadConfig = false;


                    break;

                case ControlManager.acAdvBandGridView.emGridType.COMMON_CONTROL:


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

                case ControlManager.acAdvBandGridView.emGridType.LIST_USERCONFIG:


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

                case ControlManager.acAdvBandGridView.emGridType.LIST_USERCONFIG2:


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

                case ControlManager.acAdvBandGridView.emGridType.LIST:

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
                    this._IsLoadConfig = false;

                    break;

                case ControlManager.acAdvBandGridView.emGridType.ATTACH_FILE_LIST:

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


                case ControlManager.acAdvBandGridView.emGridType.LIST_SINGLE:

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

                case ControlManager.acAdvBandGridView.emGridType.AUTO_COL:

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
        [DefaultValue(ControlManager.acAdvBandGridView.emGridType.SEARCH)]
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
            this.RowHeight = 30;

            this.ColumnPanelRowHeight = 30;

            this.OptionsView.ShowGroupPanel = false;

            this.OptionsView.ShowIndicator = false;

            this.OptionsLayout.StoreAllOptions = true;

            this.OptionsLayout.Columns.StoreAllOptions = true;

            this.OptionsCustomization.AllowRowSizing = false;

            this.OptionsView.RowAutoHeight = true;

            this.OptionsBehavior.AutoPopulateColumns = false;


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
                this._Config = new acAdvBandGridViewConfig(this);

                this.SetGridType();

            }


            this.Click += new EventHandler(acAdvBandGridView_Click);

            this.MouseDown += new MouseEventHandler(acAdvBandGridView_MouseDown);

            //this.ShowGridMenuEx += new GridMenuEventHandler(acAdvBandGridView_ShowGridMenu);
            this.ShowGridMenuEx += new ShowGridMenuExHandler(acAdvBandGridView_ShowGridMenuEx); ;
            
            this.PopupMenuShowing += new PopupMenuShowingEventHandler(acAdvBandGridView_PopupMenuShowing);

            this.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(acAdvBandGridView_CustomDrawRowIndicator);

            this.CustomDrawCell += new RowCellCustomDrawEventHandler(acAdvBandGridView_CustomDrawCell);

            this.Disposed += new EventHandler(acAdvBandGridView_Disposed);

            this.GroupSummary.CollectionChanged += new CollectionChangeEventHandler(GroupSummary_CollectionChanged);

            //this.TotalSummary.CollectionChanged += new CollectionChangeEventHandler(TotalSummary_CollectionChanged);
            
            this.ShowCustomizationForm += new EventHandler(acAdvBandGridView_ShowCustomizationForm);

            this.HideCustomizationForm += new EventHandler(acAdvBandGridView_HideCustomizationForm);

            this.DragObjectDrop += new DragObjectDropEventHandler(acAdvBandGridView_DragObjectDrop);

            this.DragObjectStart += new DragObjectStartEventHandler(acAdvBandGridView_DragObjectStart);

            this.DataSourceChanged += new EventHandler(acAdvBandGridView_DataSourceChanged);

            this.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(acAdvBandGridView_CustomDrawColumnHeader);
        }

        void acAdvBandGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            this._ColumnHeaderHeight = e.Bounds.Height;
            this._ColumnHeaderCustomDrawEventArgs = e;
        }
        
        void acAdvBandGridView_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        private void acAdvBandGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void acAdvBandGridView_DataSourceChanged(object sender, EventArgs e)
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

        void acAdvBandGridView_DragObjectStart(object sender, DragObjectStartEventArgs e)
        {
            //드래그 컬럼 정보 저장

            acAdvBandedGridColumn cln = e.DragObject as acAdvBandedGridColumn;

            if (cln != null)
            {
                this._DragDropColumnVisibleIdx = cln.VisibleIndex;
            }

        }

        void acAdvBandGridView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
            acAdvBandedGridColumn cln = e.DragObject as acAdvBandedGridColumn;


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

        void acAdvBandGridView_MouseDown(object sender, MouseEventArgs e)
        {
            this._MouseDownArgs = e;
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

        void acAdvBandGridView_HideCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = false;
        }

        void acAdvBandGridView_ShowCustomizationForm(object sender, EventArgs e)
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

                    acAdvBandedGridColumn col = this.Columns[item.FieldName] as acAdvBandedGridColumn;

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

                    acAdvBandedGridColumn col = this.Columns[item.FieldName] as acAdvBandedGridColumn;

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


        void acAdvBandGridView_Disposed(object sender, EventArgs e)
        {
            if (_StyleBox != null)
            {

                _StyleBox.Dispose();
            }


            if (_ConfigManager != null)
            {
                _ConfigManager.Dispose();
            }

            if (_LoadConfig != null)
            {
                _LoadConfig.Dispose();
            }


            foreach (KeyValuePair<string, acAdvBandGridViewFilterEditor> filter in _FilterEditors)
            {
                filter.Value.Dispose();
            }

            foreach (KeyValuePair<string, acAdvBandGridViewMaskEdit> mask in _MaskEditors)
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



        void acAdvBandGridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

            try
            {

                this._RowCellCustomDrawEventArgs = e;

                if (e.Column.OptionsColumn.AllowEdit == true)
                {
                    e.Appearance.BackColor = _Config.EditCellStyle.BackColor;

                    e.Appearance.BackColor2 = _Config.EditCellStyle.BackColor2;
                    if(!_UserUseFont) e.Appearance.Font = _Config.EditCellStyle.Font;

                    e.Appearance.ForeColor = _Config.EditCellStyle.ForeColor;

                    e.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    RepositoryItem edit = (RepositoryItem)e.Column.ColumnEdit;

                    if (edit != null)
                    {

                        edit.Appearance.BackColor = _Config.EditCellStyle.BackColor;
                        edit.Appearance.BackColor2 = _Config.EditCellStyle.BackColor2;
                        //edit.Appearance.ForeColor = _Config.EditCellStyle.ForeColor;
                        edit.Appearance.ForeColor = Color.Black;//셀 value수정시 폰트 색상 안바껴서 검정색으로 고정(신재경)

                        edit.Appearance.Font = _Config.EditCellStyle.Font;
                        edit.Appearance.GradientMode = _Config.EditCellStyle.GradientMode;

                    }

                }

                this._RowHeight = e.Bounds.Height;

                if (this._Config == null)
                {
                    return;
                }



                //변경된 행

                if (e.RowHandle != this.FocusedRowHandle)
                {
                    DataRow row = this.GetDataRow(e.RowHandle);

                    if (row != null)
                    {

                        if (row.RowState == DataRowState.Modified)
                        {
                            e.Appearance.BackColor = this._Config.ModifiedRowStyle.BackColor;

                            e.Appearance.BackColor2 = this._Config.ModifiedRowStyle.BackColor2;

                            if (!_UserUseFont) e.Appearance.Font = this._Config.ModifiedRowStyle.Font;

                            e.Appearance.ForeColor = this._Config.ModifiedRowStyle.ForeColor;

                            e.Appearance.GradientMode = this._Config.ModifiedRowStyle.GradientMode;

                        }
                    }
                }

                //수정가능한 셀

                if (e.Column.OptionsColumn.AllowEdit == true)
                {
                    RepositoryItem edit = e.Column.ColumnEdit as RepositoryItem;


                    if (edit != null)
                    {

                        if (edit.ReadOnly == false)
                        {
                            e.Appearance.BackColor = this._Config.EditCellStyle.BackColor;
                            e.Appearance.BackColor2 = this._Config.EditCellStyle.BackColor2;
                            if(!_UserUseFont) e.Appearance.Font = this._Config.EditCellStyle.Font;
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


            }
            catch (Exception ex)
            {
                throw ex;

            }


        }


        private int _IndicatorWidth = 0;

        void acAdvBandGridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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


        public acAdvBandGridView(GridControl owerGridControl)
            : base(owerGridControl)
        {

            this.Init();
        }


        public acAdvBandGridView()
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

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

            Dictionary<string, object> editData = col.EditorData as Dictionary<string, object>;


            edit.DisplayMember = editData["VALUE_COLUMN_NAME"].ToString();

            editData["CURRENT_SHOW_COLUMN_NAME"] = edit.DisplayMember;



            this.RefreshData();

        }

        void menuItemEditShowTypeDisplay_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

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




        private Dictionary<string, acAdvBandGridViewFilterEditor> _FilterEditors = new Dictionary<string, acAdvBandGridViewFilterEditor>();

        void menuItemFilter_Click(object sender, EventArgs e)
        {
            //빠른 필터기능

            acMenuItem item = (acMenuItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.UserData;

            if (!_FilterEditors.ContainsKey(col.FieldName))
            {
                acAdvBandGridViewFilterEditor frm = new acAdvBandGridViewFilterEditor(this, col.FieldName);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(acAdvBandGridViewFilter_FormClosed);


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
                acAdvBandGridViewFilterEditor frm = new acAdvBandGridViewFilterEditor(this, filedName);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(acAdvBandGridViewFilter_FormClosed);


                frm.Show();

                _FilterEditors.Add(filedName, frm);
            }
            else
            {
                _FilterEditors[filedName].Focus();
            }
        }

        void acAdvBandGridViewFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            //acAdvBandGridViewFilterEditor frm = (acAdvBandGridViewFilterEditor)sender;

            //_FilterEditors.Remove(frm.FieldName);
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

            //마스크 에디터

            foreach (KeyValuePair<string, acAdvBandGridViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Hide();

            }

            //필터 에디터

            foreach (KeyValuePair<string, acAdvBandGridViewFilterEditor> filterEditor in this._FilterEditors)
            {
                filterEditor.Value.Hide();
            }




        }

        /// <summary>
        /// 현재 사용자UI를 시스템UI로 저장한다.
        /// </summary>
        private void SaveSystemUserConfig()
        {
            acAdvBandGridViewConfig systemConfig = new acAdvBandGridViewConfig(this);

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
                        (((acAdvBandGridView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(acInfo.Resource.GetString("사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D"),
                        (((acAdvBandGridView)this).ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);


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

            //마스크 에디터

            foreach (KeyValuePair<string, acAdvBandGridViewMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Show();

            }

            //필터 에디터

            foreach (KeyValuePair<string, acAdvBandGridViewFilterEditor> filterEditor in this._FilterEditors)
            {
                filterEditor.Value.Show();
            }



        }


        private Dictionary<string, acAdvBandGridViewMaskEdit> _MaskEditors = new Dictionary<string, acAdvBandGridViewMaskEdit>();


        void menuItemMask_Click(object sender, EventArgs e)
        {
            //마스크 설정

            acMenuItem item = (acMenuItem)sender;


            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.UserData;

            if (!_MaskEditors.ContainsKey(col.FieldName))
            {
                acAdvBandGridViewMaskEdit frm = new acAdvBandGridViewMaskEdit(col);

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
            //acAdvBandGridViewMaskEdit frm = (acAdvBandGridViewMaskEdit)sender;

            //_MaskEditors.Remove(frm.Column.FieldName);

        }

        void menuItemAllBestFitColumns_Click(object sender, EventArgs e)
        {
            //컬럼 최적화
            this.BestFitColumnsThread();

        }



        private acAdvBandGridViewUserConfigManager _ConfigManager = null;

        void menuItemConfigManager_Click(object sender, EventArgs e)
        {
            //사용자UI 관리

            if (_ConfigManager == null)
            {
                _ConfigManager = new acAdvBandGridViewUserConfigManager(this);

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

        private void QuickBestFitColumns(TimeSpan executeTime)
        {

        }


        void menuItemAlwaysBestFit_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            //this._Config.AlwaysBestFit = item.Checked;

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

        void QuickUse(DataSet ds)
        {
            try
            {
                if (ds.Tables["RQSTDT"].Rows.Count > 0)
                {
                    this._Config.ConfigName = (string)ds.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                    this._Config.ConfigMaKer = (string)ds.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RQSTDT"].Rows.Count > 0)
                {

                    //this._Config.ConfigName = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                    //this._Config.ConfigMaKer = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];

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


        acAdvBandGridViewUserConfigLoadEditor _LoadConfig = null;


        void menuItemConfigLoad_Click(object sender, EventArgs e)
        {

            if (this._LoadConfig == null)
            {
                _LoadConfig = new acAdvBandGridViewUserConfigLoadEditor(this);

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
            acAdvBandGridViewUserConfigSaveEditor frm = new acAdvBandGridViewUserConfigSaveEditor(this);

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
                acAdvBandGridViewUserConfigSaveEditor frm = new acAdvBandGridViewUserConfigSaveEditor(this);

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
                this.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            else
            {
                this.OptionsView.GroupFooterShowMode = GroupFooterShowMode.Hidden;
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

        acAdvBandGridViewStyleBox _StyleBox = null;

        void menuItemStyleBox_Click(object sender, EventArgs e)
        {

            if (this._StyleBox == null)
            {

                _StyleBox = new acAdvBandGridViewStyleBox(this);

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
            //this._StyleBox = null;
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

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            GridBand gb = col.OwnerBand;

            if (item.Checked == true)
            {
                gb.Fixed = FixedStyle.Left;
                col.Fixed = FixedStyle.Right;
            }
            else if (item.Checked == false)
            {
                gb.Fixed = FixedStyle.None;
                col.Fixed = FixedStyle.None;
            }
        }

        void menuItemFixedLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;
            GridBand gb = col.OwnerBand;

            if (item.Checked == true)
            {
                gb.Fixed = FixedStyle.Left;
                col.Fixed = FixedStyle.Left;
            }
            else if (item.Checked == false)
            {
                gb.Fixed = FixedStyle.None;
                col.Fixed = FixedStyle.None;
            }

        }

        void menuItemAlignRight_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
        }

        void menuItemAlignCenter_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        void menuItemAlignLeft_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;

        }

        void menuItemMerge_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acAdvBandedGridColumn col = (acAdvBandedGridColumn)item.RefObject;

            if (item.Checked == true)
            {
                col.OptionsColumn.AllowMerge = DefaultBoolean.True;

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

                //this.OptionsPrint.PrintHeader = true;


                //this.OptionsPrint.PrintHorzLines = this.OptionsView.ShowHorizontalLines;
                //this.OptionsPrint.PrintVertLines = this.OptionsView.ShowVerticalLines;

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

            this.SaveGridViewToFile(QGridViewExportTo.emSaveFileType.Excel);
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

        //public bool DeleteMappingRow2(DataRow row)
        //{
        //    try
        //    {
        //        DataTable dt = (DataTable)this.GridControl.DataSource;

        //        DataRowCollection drCol = dt.Rows;

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            bool isFindRow = true;

        //            foreach (string keyColumn in this._KeyColumn)
        //            {
                  

        //                //데이터컬럼 타입에 따른 변환
        //                acAdvBandedGridColumn col = (acAdvBandedGridColumn)this.Columns[keyColumn];

        //                object value = null;

        //                if (col != null)
        //                {
        //                    if (col.EditorType == emEditorType.DATE)
        //                    {
        //                        value = row[keyColumn].toDateTime();
        //                    }
        //                    else
        //                    {
        //                        value = Convert.ChangeType(row[keyColumn], dr[keyColumn].GetType());
        //                    }
        //                }
        //                else
        //                {
        //                    value = Convert.ChangeType(row[keyColumn], dr[keyColumn].GetType());
        //                }


        //                if (!dr[keyColumn].Equals(value))
        //                {
        //                    isFindRow = false;

        //                    break;
        //                }
        //            }

        //            if (isFindRow == true)
        //            {
        //                //dr.Delete();
        //                drCol.Remove(dr);

        //                //DataRow delRow = this.GetDataRow(i);

        //                //DataRow delRowCopy = delRow.NewCopy();

        //                //this.DeleteRow(i);


        //                //if (this.OnMapingRowChanged != null)
        //                //{
        //                //    this.OnMapingRowChanged(emMappingRowChangedType.DELETE, delRowCopy);
        //                //}


        //                return true;
        //            }
        //        }

                
        //        return false;

               
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        /// <summary>
        /// KeyColumn에 매칭되는 Row를 삭제한다.
        /// </summary>
        /// <param name="row"></param>
        public bool DeleteMappingRow(DataRow row)
        {
            try
            {

                DataView view = this.GetDataView();

                for (int i = 0; i < view.Count; i++)
                {
                    DataRowView rowView = view[i];

                    bool isFindRow = true;
               
                    foreach (string keyColumn in this._KeyColumn)
                    {
            

                        //데이터컬럼 타입에 따른 변환

                        acAdvBandedGridColumn col = (acAdvBandedGridColumn)this.Columns[keyColumn];

                        object value = null;

                        if (col != null)
                        {
                            if (col.EditorType == emEditorType.DATE)
                            {
                                value = row[keyColumn].toDateTime();
                            }
                            else
                            {
                                value = Convert.ChangeType(row[keyColumn], rowView.Row[keyColumn].GetType());

                            }
                        }
                        else
                        {
                            value = Convert.ChangeType(row[keyColumn], rowView.Row[keyColumn].GetType());
                        }


                        if (!rowView.Row[keyColumn].Equals(value))
                        {
                            isFindRow = false;

                            break;
                        }

                    }

                    if (isFindRow == true)
                    {



                        DataRow delRow = this.GetDataRow(i);

                        DataRow delRowCopy = delRow.NewCopy();

                        this.DeleteRow(i);


                        //acGridControl grid = this.GridControl as acGridControl;

                        //this.del


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

            if (view == null) view = new DataView();

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

        private void ConvertColumnType(DataTable dt)
        {
            Dictionary<string, Type> list = new Dictionary<string, Type>();

            foreach (DataColumn col in dt.Columns)
            {
                acAdvBandedGridColumn acCol = (acAdvBandedGridColumn)this.Columns[col.ColumnName];

                if (acCol != null)
                {

                    if (acCol.EditorType == acAdvBandGridView.emEditorType.DATE)
                    {
                        if (col.DataType != typeof(DateTime))
                        {

                            list.Add(col.ColumnName, typeof(DateTime));

                        }
                    }
                    else if (acCol.EditorType == acAdvBandGridView.emEditorType.LOOKUP_CODE)
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
                        object value = Convert.ChangeType(row[keyColumn], rowView.Row[keyColumn].GetType());

                        if (rowView.Row.Table.Columns.Contains(keyColumn))
                        {
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
                        
                        DataRow viewRow = this.GetDataRow(i);


                        if (viewRow != null)
                        {
                            foreach (DataColumn col in rowView.Row.Table.Columns)
                            {


                                if (row.Table.Columns.Contains(col.ColumnName) &&
                                    view.Table.Columns.Contains(col.ColumnName))
                                {
                                    //rowView.Row.Table.Rows[i][col.ColumnName] = row[col.ColumnName];
                                    viewRow[col.ColumnName] = row[col.ColumnName];
                                }

                            }

                            viewRow.AcceptChanges();
                            //notFindAdd = false;
                        }
                        else
                        {
                            foreach (DataColumn col in rowView.Row.Table.Columns)
                            {

                                //if (rowView.Row.Table.Columns.Contains(col.ColumnName))
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    rowView.Row.Table.Rows[i][col.ColumnName] = row[col.ColumnName];


                            }

                        }
                        
                        

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

            foreach (acAdvBandedGridColumn col in this.Columns)
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

                var sum = view.ToTable().AsEnumerable().Sum(x => x.Field<decimal>(columnName));

                return sum;

            }
            catch//(Exception ex)
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
            acAdvBandGridControl grid = this.GridControl as acAdvBandGridControl;

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

                    if (Regex.IsMatch(filterExpression, @"\w+\(\[\w+\]\,\s+\'\w+\'\)"))
                    {
                        foreach (Match match in Regex.Matches(filterExpression, @"\w+\(\[\w+\]\,\s+\'\w+\'\)"))
                        {
                            string matchValue = match.Groups[0].Value;

                            string expression = Regex.Match(matchValue, @"(^\w+)").Groups[1].Value;
                            string colName = Regex.Match(matchValue, @"\[(\w+)\]").Groups[1].Value;
                            string value = Regex.Match(matchValue, @"\'(\w+)\'").Groups[1].Value;

                            switch (expression.ToUpper())
                            {
                                case "CONTAINS":
                                    currentFilter += colName + " LIKE '%" + value + "%'";
                                    break;
                            }
                        }

                    }
                    else
                        currentFilter += filterExpression;
                }

                if (!string.IsNullOrEmpty(currentFilter))
                {

                    dv.RowFilter = "(" + currentFilter + ")";

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


        void acAdvBandGridView_Click(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;


            if (this._MouseDownArgs != null)
            {

                GridHitInfo hintInfo = gridView.CalcHitInfo(this._MouseDownArgs.Location);


                if (hintInfo.HitTest == GridHitTest.Column)
                {
                    #region 체크 타입은 정렬하지않고 전체선택 또는 해제합니다.


                    acAdvBandedGridColumn acCol = hintInfo.Column as acAdvBandedGridColumn;

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

        public void AddPictrue(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible,string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();
            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();

            pictureEdit.AllowFocused = false;
            pictureEdit.AllowFocused = false;
            //pictureEdit.ShowMenu = false;
            pictureEdit.ShowMenu = true;
            pictureEdit.PictureAlignment = ContentAlignment.MiddleCenter;
            pictureEdit.NullText = " ";
            pictureEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;


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
            
            col.ColumnEdit = pictureEdit;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

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
            /// 년월일시분(24시기준)
            /// </summary>
            MEDIUM_DATE2,

            /// <summary>
            /// 년월일시분초
            /// </summary>
            LONG_DATE,

            /// <summary>
            /// 년월일시분초.밀리초(3)
            /// </summary>
            FULL_DATE,

            /// <summary>
            /// 년.월.일(YY.MM.DD)
            /// </summary>
            FMT_DATE
        };


        public void AddDateEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask)
        {
            AddDateEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, mask, caption);
        }

        public void AddDateEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask,string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddDateEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask, GridBand parentBand)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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

            parentBand.Columns.Add(col);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddDateEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emDateMask dateMask)
        {
            AddDateEdit(columnName, caption,rowCount,rowIndex,colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, dateMask, caption);
        }

        public void AddDateEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emDateMask dateMask, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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
                case emDateMask.MONTH_DATE:

                    dateEdit.Mask.EditMask = "yyyy-MM";

                    break;


                case emDateMask.SHORT_DATE:

                    dateEdit.Mask.EditMask = "d";

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

                case emDateMask.FULL_DATE:

                    dateEdit.Mask.EditMask = "yyyy-MM-dd HH:mm:ss.fff";

                    break;
                case emDateMask.FMT_DATE:

                    dateEdit.Mask.EditMask = "yy.MM.dd";
                    break;

            }



            dateEdit.Mask.UseMaskAsDisplayFormat = true;

            dateEdit.Appearance.TextOptions.HAlignment = align;

            dateEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = dateEdit;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }


        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, RepositoryItem editItem)
        {
            AddCustomEdit(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired, editItem, caption);
        }

        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, RepositoryItem editItem, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);
        }

        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, RepositoryItem editItem, GridBand parentBand)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            _DefaultTable.Columns.Add(columnName, typeof(object));

            editItem.Appearance.TextOptions.HAlignment = align;

            col.ColumnEdit = editItem;

            parentBand.Columns.Add(col);
            //this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);
        }

        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, GridBand parent)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            //editItem.Appearance.TextOptions.HAlignment = align;

            //col.ColumnEdit = editItem;

            parent.Columns.Add(col);

            this.Columns.Add(col);
        }

        public void AddTimeEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask)
        {
            AddTimeEdit(columnName, caption, resourceID, useReSourceID, align, allowEdit, visible, isRequired, mask, caption);
        }


        public void AddTimeEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask,string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);
        }

        public void AddMemoEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool readOnly, bool visible, bool isRequired)
        {
            AddMemoEdit(columnName, caption, resourceID, useReSourceID, hAlign, vAlign, allowEdit, readOnly, visible, isRequired, caption);
        }

        public void AddMemoEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool readOnly, bool visible, bool isRequired, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            this.SetAddBand(col, bandCaption);

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

            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

        public void AddProgressBar(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, string bandCaption)
        {

            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            col.RowCount = rowCount;
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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }
        public void AddColorEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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
            AddButtonEdit(columnName, caption, resourceID, useReSourceID, align, textEditStyle, allowEdit, visible, isRequired, caption);
        }

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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

            _DefaultTable.Columns.Add(columnName, typeof(object));

            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();

            btnEdit.TextEditStyle = textEditStyle;

            btnEdit.Mask.UseMaskAsDisplayFormat = true;

            btnEdit.Appearance.TextOptions.HAlignment = align;

            btnEdit.Appearance.Options.UseTextOptions = true;

            col.ColumnEdit = btnEdit;

            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);
        }

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired
                                , Image img, DevExpress.XtraEditors.Controls.ButtonPredefines bp, ButtonPressedEventHandler bpeHandler, string bandCaption = null)
        {
            if (bandCaption==null)
            {
                bandCaption =  columnName;
            }

            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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


            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);
        }

        public void AddButtonEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, TextEditStyles textEditStyle, bool allowEdit, bool visible, bool isRequired
                                , Image img, DevExpress.XtraEditors.Controls.ButtonPredefines bp, ButtonPressedEventHandler bpeHandler, string bandCaption = null)
        {
            if (bandCaption == null)
            {
                bandCaption = caption;
            }

            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            
            col.RowCount = rowCount;
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


            col.ShowButtonMode = ShowButtonModeEnum.ShowAlways;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public int GetDataRowCount()
        {
            return (this.GridControl.DataSource as DataTable).Rows.Count;
        }

        public void AddHidden(string columnName, Type dataType)
        {
            _DefaultTable.Columns.Add(columnName, dataType);

        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string catCode)
        {
            AddLookUpEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, catCode, caption);
        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string catCode, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            //col.Caption = col.Caption + "(" + catCode + ")";
            col.RowCount = rowCount;

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;

            col.OptionsColumn.AllowEdit = allowEdit;

            col.Visible = visible;

            if (col.Visible == true)
            {
                col.VisibleIndex = this.VisibleColumns.Count + 1;
            }

            col.OptionsColumn.AllowMerge = DefaultBoolean.True;


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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);

        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
   string catCode, GridBand parentBand)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            col.Caption = col.Caption + "(" + catCode + ")";
            col.RowCount = rowCount;

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

            parentBand.Columns.Add(col);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    DataTable dt)
        {
            AddLookUpEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, dt, caption);
        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    DataTable dt, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddLookUpVendor(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string bandCaption = null)
        {
            if (bandCaption == null)
            {
                bandCaption = columnName;
            }

            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;
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

            this.SetAddBand(col, bandCaption);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            AddLookUpEmp(columnName, caption, resourceID, useReSourceID, null, null, align, allowEdit, visible, isRequired, caption);
        }

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, string org_code, string grp_code, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            AddLookUpEmp(columnName, caption, resourceID, useReSourceID, org_code, grp_code, align, allowEdit, visible, isRequired, caption);
        }

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, string org_code, HorzAlignment align, bool allowEdit, bool visible, bool isRequired)
        {
            AddLookUpEmp(columnName, caption, resourceID, useReSourceID, org_code, null, align, allowEdit, visible, isRequired, caption);
        }

        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string bandCaption)
        {
            AddLookUpEmp(columnName, caption, resourceID, useReSourceID, null, null, align, allowEdit, visible, isRequired, bandCaption);
        }


        public void AddLookUpEmp(string columnName, string caption, string resourceID, bool useReSourceID, string org_code, string grp_code, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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
            paramTable.Columns.Add("ORG_CODE");
            paramTable.Columns.Add("USRGRP_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = org_code;
            paramRow["USRGRP_CODE"] = grp_code;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_EMPLOYEE", paramSet, "RQSTDT", "RSLTDT");
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

            
            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

        }

        public void AddLookUpEmp(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, string org_code, string grp_code, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }
            col.RowCount = rowCount;

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
            paramTable.Columns.Add("ORG_CODE");
            paramTable.Columns.Add("USRGRP_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = org_code;
            paramRow["USRGRP_CODE"] = grp_code;

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


            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }

        public void AddLookUpMat(string columnName, string caption, string resourceID, bool useReSourceID, string cd_code, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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


            displayColumnInfo.FieldName = "MATERIAL_NAME";
            displayColumnInfo.Caption = "MATERIAL_NAME";

            valueColumnInfo.FieldName = "MATERIAL_CODE";
            valueColumnInfo.Caption = "MATERIAL_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CD_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CD_CODE"] = cd_code;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_MAT_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            lookupEdit.DataSource = resultSet.Tables["RSLTDT"];

            lookupEdit.DisplayMember = "MATERIAL_NAME";

            lookupEdit.ValueMember = "MATERIAL_CODE";

            editorData.Add("DISPLAY_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("VALUE_COLUMN_NAME", lookupEdit.ValueMember);

            editorData.Add("CURRENT_SHOW_COLUMN_NAME", lookupEdit.DisplayMember);

            editorData.Add("DATASOURCE", lookupEdit.DataSource);


            col.ColumnEdit = lookupEdit;

            _DefaultTable.Columns.Add(columnName, typeof(string));


            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

        }

        private void SetAddBand(BandedGridColumn col, String bandCaption)
        {
            if(this.Columns.Count == 0)
            {
                this.Bands.Clear();
            }

            String[] bandCaptions = bandCaption.Split(',');

            if (bandCaptions.Length == 1)
            {

                bool isHasBand = false;
                GridBand band = null;
                //if (this.Bands.Count != 0)
                //    if (this.Bands[this.Bands.Count - 1].Caption == bandCaption)
                //    {
                //        band = this.Bands[this.Bands.Count - 1];
                //        isHasBand = true;
                //    }
                for (int i = 0; i < this.Bands.Count; i++)
                {
                    if (this.Bands[i].Caption == bandCaption)
                    {
                        band = this.Bands[i];
                        isHasBand = true;
                        break;
                    }
                }

                if (isHasBand)
                {
                    band.Columns.Add(col);
                }
                else
                {
                    band = new GridBand();
                    //band.Name = "band_" + col.FieldName;
                    band.Caption = bandCaption;
                    band.Name = bandCaption;
                    band.AppearanceHeader.Options.UseTextOptions = true;
                    band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    band.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                    band.Visible = col.Visible;
                    band.AutoFillDown = false;
                    band.Columns.Add(col);
                    
                    this.Bands.Add(band);

                    if (bandCaption == col.Caption)
                    {
                        if (this.GridControl.DataSource == null) this.GridControl.DataSource = this.DefaultTable;
                        acBandPaintHelper helper = new acBandPaintHelper(this, new GridBand[] { band });
                    }
                }
            }
            else
            {
                
                GridBand band = null;
                GridBandCollection bands = this.Bands;

                string lastBandCaption = "";

                foreach(String caption in bandCaptions)
                {
                    lastBandCaption = caption.Trim();
                    band = SetAddBand(bands, caption.Trim(), col);
                    bands = band.Children;                    
                }

                if (lastBandCaption == col.Caption.Trim())
                {
                    if (this.GridControl.DataSource == null) this.GridControl.DataSource = this.DefaultTable;
                    acBandPaintHelper helper = new acBandPaintHelper(this, new GridBand[] { band });
                }

                band.Columns.Add(col);
            }
            
        }

        GridBand SetAddBand(GridBandCollection bands, String caption, BandedGridColumn col)
        {
            //bool isHasBand = false;
            GridBand band = null;

            for (int i = 0; i < bands.Count; i++)
            {
                if (bands[i].Caption == caption)
                {
                    band = bands[i];
                    return band;
                    //break;
                }
            }
            
            band = new GridBand();
            band.Caption = caption;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            band.Visible = col.Visible;
            band.AutoFillDown = false;
            bands.Add(band);

            return band;
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

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string displayColumnName, string valueColumnName, object dataSource)
        {
            AddLookUpEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, displayColumnName, valueColumnName, dataSource, caption);
        }

        public void AddLookUpEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired,
    string displayColumnName, string valueColumnName, object dataSource, string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);
        }


        public void AddCheckEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType)
        {
            AddCheckEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, allowEdit, visible, chekEditDataType, caption);
        }

        public void AddCheckEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType,string bandCaption)
        {
            acAdvBandedGridColumn col = new acAdvBandedGridColumn();

            col.FieldName = columnName;

            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.RowCount = rowCount;

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



            }

            col.ColumnEdit = checkItemEdit;

            this.SetAddBand(col, bandCaption);

            this.Columns.Add(col);

            this.SetColumnPosition(col, rowIndex, colIndex);

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



        /// <summary>
        /// 설정된 컴럼데이터를 초기화시킨다.
        /// </summary>
        public void ClearColumns()
        {

            //this._Config.Reset();

            this.Columns.Clear();

            this._DefaultTable.Columns.Clear();


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

        public void AddComboBoxEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, List<object> list)
        {

            try
            {
                acAdvBandedGridColumn col = new acAdvBandedGridColumn();

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



                RepositoryItemComboBox comboBoxEditItem = new RepositoryItemComboBox();

                comboBoxEditItem.TextEditStyle = TextEditStyles.DisableTextEditor;

                foreach (object t in list)
                {


                    comboBoxEditItem.Items.Add(t);
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
        /// TextEdit 형태의 컬럼을 추가합니다.
        /// </summary>
        /// <param name="columnName">컬럼명</param>
        /// <param name="caption">캡션</param>
        /// <param name="resourceID">리소스아이디</param>
        /// <param name="align">정렬형태</param>
        /// <param name="allowEdit">에디트여부</param>
        /// <param name="visible">보여줄지여부</param>
        /// <param name="mask">마스크</param>
        public void AddTextEdit(string columnName, string caption,int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask)
        {
            AddTextEdit(columnName, caption, rowCount, rowIndex, colIndex, resourceID, useReSourceID, align, allowEdit, visible, isRequired, mask, caption);
        }

        public void AddTextEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask,string bandCaption)
        {
            try
            {
                acAdvBandedGridColumn col = new acAdvBandedGridColumn();

                col.FieldName = columnName;

                if (useReSourceID == true)
                {
                    col.Caption = acInfo.Resource.GetString(caption, resourceID);
                }
                else
                {
                    col.Caption = caption;
                }

                col.RowCount = rowCount;
                
                col.ResourceID = resourceID;

                col.UseResourceID = useReSourceID;


                col.OptionsColumn.AllowEdit = allowEdit;

                col.Visible = visible;

                if (col.Visible == true)
                {
                    col.VisibleIndex = this.VisibleColumns.Count + 1;
                }

                col.OptionsColumn.AllowMerge = DefaultBoolean.True;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.TEXT;

                col.IsRequired = isRequired;

                col.EditorData = mask;

                RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

                col.ColumnEdit = textEditItem;
                
                textEditItem.Mask.UseMaskAsDisplayFormat = true;

                switch (mask)
                {
                    case emTextEditMask.NONE:

                        _DefaultTable.Columns.Add(columnName);
                        //textEditItem.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
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
                    case emTextEditMask.TON:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        //textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        //textEditItem.Mask.EditMask = @"(\d{#,##0})톤";
                        textEditItem.Mask.UseMaskAsDisplayFormat = true;
                        textEditItem.DisplayFormat.FormatType = FormatType.Numeric;
                        textEditItem.DisplayFormat.FormatString = "#,##0톤";

                        break;
                    case emTextEditMask.PER_UNIT:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        //textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        //textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,1})%"; ;
                        textEditItem.Mask.UseMaskAsDisplayFormat = true;
                        textEditItem.DisplayFormat.FormatType = FormatType.Numeric;
                        textEditItem.DisplayFormat.FormatString = "#,##0.0%";


                        break;

                    case emTextEditMask.MONEY:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");


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

                    case emTextEditMask.PER2:

                        _DefaultTable.Columns.Add(columnName, typeof(double));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p2";


                        break;

                    case emTextEditMask.PER1:

                        _DefaultTable.Columns.Add(columnName, typeof(double));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p1";


                        break;

                    case emTextEditMask.PER100:

                        _DefaultTable.Columns.Add(columnName, typeof(float));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        textEditItem.Mask.EditMask = "p";
                        //textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,2}|100)%";

                        break;

                    case emTextEditMask.F2:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F2";


                        break;

                    case emTextEditMask.F6:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F6";


                        break;

                    case emTextEditMask.F3:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F3";


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

                }
                
                textEditItem.EditValueChanging += new ChangingEventHandler(TextEdit_EditValueChanging);
                textEditItem.KeyPress += new KeyPressEventHandler(TextEdit_KeyPress);
                textEditItem.Tag = col;

                this.Columns.Add(col);

                this.SetAddBand(col,bandCaption);

                this.SetColumnPosition(col, rowIndex, colIndex);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTextEdit(string columnName, string caption, int rowCount, int rowIndex, int colIndex, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, emTextEditMask mask, GridBand parentBand)
        {
            try
            {
                acAdvBandedGridColumn col = new acAdvBandedGridColumn();

                col.FieldName = columnName;

                if (useReSourceID == true)
                {
                    col.Caption = acInfo.Resource.GetString(caption, resourceID);
                }
                else
                {
                    col.Caption = caption;
                }

                col.RowCount = rowCount;

                col.ResourceID = resourceID;

                col.UseResourceID = useReSourceID;


                col.OptionsColumn.AllowEdit = allowEdit;

                col.Visible = visible;

                if (col.Visible == true)
                {
                    col.VisibleIndex = this.VisibleColumns.Count + 1;
                }

                col.OptionsColumn.AllowMerge = DefaultBoolean.True;

                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                col.AppearanceHeader.Options.UseTextOptions = true;

                col.AppearanceCell.TextOptions.HAlignment = align;

                col.AppearanceCell.Options.UseTextOptions = true;

                col.EditorType = emEditorType.TEXT;

                col.IsRequired = isRequired;

                col.EditorData = mask;

                RepositoryItemTextEdit textEditItem = new RepositoryItemTextEdit();

                col.ColumnEdit = textEditItem;

                textEditItem.Mask.UseMaskAsDisplayFormat = true;

                switch (mask)
                {
                    case emTextEditMask.NONE:

                        _DefaultTable.Columns.Add(columnName);
                        //textEditItem.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
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
                    case emTextEditMask.TON:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        //textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        //textEditItem.Mask.EditMask = @"(\d{#,##0})톤";
                        textEditItem.Mask.UseMaskAsDisplayFormat = true;
                        textEditItem.DisplayFormat.FormatType = FormatType.Numeric;
                        textEditItem.DisplayFormat.FormatString = "#,##0톤";

                        break;
                    case emTextEditMask.PER_UNIT:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        //textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        //textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,1})%"; ;
                        textEditItem.Mask.UseMaskAsDisplayFormat = true;
                        textEditItem.DisplayFormat.FormatType = FormatType.Numeric;
                        textEditItem.DisplayFormat.FormatString = "#,##0.0%";


                        break;

                    case emTextEditMask.MONEY:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");


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

                    case emTextEditMask.PER2:

                        _DefaultTable.Columns.Add(columnName, typeof(double));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p2";


                        break;

                    case emTextEditMask.PER1:

                        _DefaultTable.Columns.Add(columnName, typeof(double));


                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "p1";


                        break;

                    case emTextEditMask.PER100:

                        _DefaultTable.Columns.Add(columnName, typeof(byte));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        textEditItem.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,2}|100)%";

                        break;

                    case emTextEditMask.F2:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F2";


                        break;

                    case emTextEditMask.F6:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F6";


                        break;

                    case emTextEditMask.F3:

                        _DefaultTable.Columns.Add(columnName, typeof(decimal));

                        textEditItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        textEditItem.Mask.EditMask = "F3";


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

                }

                textEditItem.EditValueChanging += new ChangingEventHandler(TextEdit_EditValueChanging);
                textEditItem.KeyPress += new KeyPressEventHandler(TextEdit_KeyPress);
                textEditItem.Tag = col;

                parentBand.Columns.Add(col);

                this.Columns.Add(col);

                this.SetColumnPosition(col, rowIndex, colIndex);

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
            /*
    
            TextEdit editor = sender as TextEdit;

            if (editor.Tag != null)
            {
                if (editor.Tag is RepositoryItem)
                {
                    RepositoryItem item = editor.Tag as RepositoryItem;

                    acAdvBandedGridColumn col = item.Tag as acAdvBandedGridColumn;

                    emTextEditMask mask = (emTextEditMask)col.EditorData;


                    if (mask == emTextEditMask.QTY)
                    {
                        if (e.NewValue.toDecimal() <= 0)
                        {
                            e.Cancel = true;
                        }


                    }

                }

            }
             */

        }

        void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextEdit editor = sender as TextEdit;

            if (editor.Tag != null)
            {
                if (editor.Tag is RepositoryItem)
                {
                    RepositoryItem item = editor.Tag as RepositoryItem;

                    acAdvBandedGridColumn col = item.Tag as acAdvBandedGridColumn;

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
                }
            }

        }


        //public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public delegate void ShowGridMenuExHandler(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e);

        public event ShowGridMenuExHandler ShowGridMenuEx;

        private void SetGridColumnMenu(GridViewMenu menu, BandedGridHitInfo hitInfo)
        {

            if (hitInfo.HitTest == BandedGridHitTest.Band || hitInfo.HitTest == BandedGridHitTest.Column || hitInfo.HitTest == BandedGridHitTest.ColumnPanel)// || hitInfo.HitTest == GridHitTest.RowDetail)
            {

                acAdvBandedGridColumn acCol = (acAdvBandedGridColumn)hitInfo.Column;
                
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
               
                acDXMenuCheckItem menuItemAlwaysBestFit = new acDXMenuCheckItem(acInfo.Resource.GetString("항상 전체 컬럼 자동크기", "LHZDTQ5M"),false);//_Config.AlwaysBestFit);
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

                //DXSubMenuItem menuItemConfig = new DXSubMenuItem(acInfo.Resource.GetString("사용자 UI", "MVDNG5SB"));
                //menuItemConfig.Image = ControlManager.Resource.color_swatchx_16;


                ////적용된 사용자 UI



                //DXMenuItem menuAssignConfig = new DXMenuItem(string.Format(acInfo.Resource.GetString("현재 설정된 UI - {0}", "NK9O7TO0"), ""));

                //menuAssignConfig.Image = ControlManager.Resource.appointment;

                //DXMenuItem menuItemConfigLoad = new DXMenuItem(acInfo.Resource.GetString("불러오기", "VO8OYFRA"));
                //menuItemConfigLoad.Image = ControlManager.Resource.document_open;
                //menuItemConfigLoad.Click += new EventHandler(menuItemConfigLoad_Click);

                //DXMenuItem menuItemConfigSave = new DXMenuItem(acInfo.Resource.GetString("저장", "7NKYXFU5"));
                //menuItemConfigSave.Image = ControlManager.Resource.document_save;
                //menuItemConfigSave.Click += new EventHandler(menuItemConfigSave_Click);

                //DXMenuItem menuItemConfigOtherSave = new DXMenuItem(acInfo.Resource.GetString("다른이름으로 저장", "Q8JXEI9K"));
                //menuItemConfigOtherSave.Image = ControlManager.Resource.document_save_as;
                //menuItemConfigOtherSave.Click += new EventHandler(menuItemConfigOtherSave_Click);


                //DXMenuItem menuItemConfigUse = new DXMenuItem(acInfo.Resource.GetString("현재 사용자 UI을 기본으로 설정", "K913LULF"));
                //menuItemConfigUse.Image = ControlManager.Resource.table_refresh_x16;
                //menuItemConfigUse.Click += new EventHandler(menuItemConfigUse_Click);


                //DXMenuItem menuItemSystemConfig = new DXMenuItem(acInfo.Resource.GetString("시스템 UI로 초기화", "7Z7GBDQ6"));
                //menuItemSystemConfig.Image = ControlManager.Resource.layout_x16;
                //menuItemSystemConfig.Click += new EventHandler(menuItemSystemConfig_Click);

                //DXMenuItem menuItemConfigManager = new DXMenuItem(acInfo.Resource.GetString("관리", "0FNNF1ZT"));
                //menuItemConfigManager.Image = ControlManager.Resource.edit_find_replace_x16;
                //menuItemConfigManager.Click += new EventHandler(menuItemConfigManager_Click);


                ////현재 설정중인 사용자 UI가 존재하지않음
                ////if (string.IsNullOrEmpty(this._Config.ConfigName))
                ////{
                ////    menuAssignConfig.Visible = false;
                ////    menuItemConfigUse.Enabled = false;
                ////    menuItemSystemConfig.Enabled = false;
                ////}


                //menuItemConfig.Items.Add(menuAssignConfig);

                //menuItemConfig.Items.Add(menuItemConfigLoad);

                //menuItemConfig.Items.Add(menuItemConfigSave);
                //menuItemConfig.Items.Add(menuItemConfigOtherSave);


                //menuItemConfig.Items.Add(menuItemConfigUse);

                //menuItemConfig.Items.Add(menuItemSystemConfig);

                //menuItemConfig.Items.Add(menuItemConfigManager);

                #endregion


                DXSubMenuItem menuItemSaveFile = new DXSubMenuItem(acInfo.Resource.GetString("파일로 저장", "LVJVBFZF"));
                menuItemSaveFile.Image = ControlManager.Resource.document_save;

                DXMenuItem menuItemToExcel = new DXMenuItem(acInfo.Resource.GetString("Microsoft Excel", "GQ52W2AQ"));
                menuItemToExcel.Image = ControlManager.Resource.page_excel_x16;
                menuItemToExcel.Click += new EventHandler(menuItemToExcel_Click);


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
                menuItemSaveFile.Items.Add(menuItemToPDF);
                menuItemSaveFile.Items.Add(menuItemToText);
                menuItemSaveFile.Items.Add(menuItemToRTF);
                menuItemSaveFile.Items.Add(menuItemToHtml);
                menuItemSaveFile.Items.Add(menuItemToMht);


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

                            //컬럼 자동크기(전체) 기본삭제

                            //menu.Items.RemoveAt(9);




                            menu.Items.Add(menuItemColumn);

                            menuItemColumn.BeginGroup = true;


                            menu.Items.Add(menuItemShow);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemStyleBox);

                            //menu.Items.Add(menuItemConfig);
                            //menuItemConfig.BeginGroup = true;


                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;


                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;

                            break;


                        case emGridType.FIXED:
                            menu.Items.RemoveAt(4);
                            //menu.Items.RemoveAt(6);


                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;

                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;
                            break;


                        case emGridType.LIST:

                            //menu.Items.RemoveAt(9);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;

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
                            //menu.Items.RemoveAt(6);

                            break;


                        case emGridType.AUTO_COL:

                            //컬럼 자동크기(전체) 기본삭제

                            //menu.Items.RemoveAt(9);




                            menu.Items.Add(menuItemColumn);

                            menuItemColumn.BeginGroup = true;


                            menu.Items.Add(menuItemShow);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemStyleBox);

                            //menu.Items.Add(menuItemConfig);
                            //menuItemConfig.BeginGroup = true;


                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;


                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;

                            break;



                    }

                }
                else if (hitInfo.InBandPanel)
                {

                    switch (this.GridType)
                    {
                        case emGridType.SEARCH:

                            //컬럼 자동크기(전체) 기본삭제

                            //menu.Items.RemoveAt(9);
                            menu.Items.Add(menuItemShow);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemStyleBox);

                            //menu.Items.Add(menuItemConfig);
                            //menuItemConfig.BeginGroup = true;


                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;


                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;

                            break;


                        case emGridType.FIXED:
                            menu.Items.RemoveAt(4);
                            //menu.Items.RemoveAt(6);


                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;

                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;
                            break;


                        case emGridType.LIST:

                            //menu.Items.RemoveAt(9);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;

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
                            //menu.Items.RemoveAt(6);

                            break;


                        case emGridType.AUTO_COL:

                            //컬럼 자동크기(전체) 기본삭제

                            //menu.Items.RemoveAt(9);

                            menu.Items.Add(menuItemShow);

                            menu.Items.Add(menuItemMethod);

                            menu.Items.Add(menuItemStyleBox);

                            //menu.Items.Add(menuItemConfig);
                            //menuItemConfig.BeginGroup = true;


                            menu.Items.Add(menuItemSaveFile);
                            menuItemSaveFile.BeginGroup = true;

                            menu.Items.Add(menuItemDefaultPrint);
                            menuItemDefaultPrint.BeginGroup = true;


                            menu.Items.Add(menuHelp);
                            menuHelp.BeginGroup = true;

                            break;



                    }

                }

                #endregion
            }
            else if (hitInfo.HitTest == BandedGridHitTest.Footer || hitInfo.HitTest == BandedGridHitTest.RowFooter)
            {
                //풋더


                acAdvBandedGridColumn acCol = (acAdvBandedGridColumn)hitInfo.Column;

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

        internal void RaiseShowGridPopupMenu(BandedGridHitInfo hitInfo, Point pt)
        {

            BandedGridHitInfo hi = this.CalcHitInfo(this.GridControl.PointToClient(pt));

            if (hi.HitTest == BandedGridHitTest.Band || hi.HitTest == BandedGridHitTest.Column || hi.HitTest == BandedGridHitTest.ColumnPanel)
            {
                GridViewColumnMenu columnMenu = new GridViewColumnMenu(this);

                columnMenu.Init(hi.Column);

                this.SetGridColumnMenu(columnMenu, hi);

                columnMenu.Show(this.GridControl.PointToClient(pt));

            }
            else if (hi.HitTest == BandedGridHitTest.Footer || hi.HitTest == BandedGridHitTest.RowFooter)
            {


                GridViewFooterMenu footerMenu = new GridViewFooterMenu(this);

                footerMenu.Init(hi);

                this.SetGridColumnMenu(footerMenu, hi);

                footerMenu.Show(this.GridControl.PointToClient(pt));
            }


            if (this.ShowGridMenuEx != null)
            {


                GridMenuType menuType = GridMenuType.User;

                if (hi.HitTest == BandedGridHitTest.EmptyRow)
                {
                    DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);


                    menuType = GridMenuType.User;

                    
                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }
                else if (hi.HitTest == BandedGridHitTest.Row || hi.HitTest == BandedGridHitTest.RowCell || hi.HitTest == BandedGridHitTest.RowEdge || hi.HitTest == BandedGridHitTest.RowDetail)
                {
                    DevExpress.XtraGrid.Menu.GridViewMenu menu = new DevExpress.XtraGrid.Menu.GridViewMenu(this);

                    menuType = GridMenuType.Row;

                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }
                else if (hi.HitTest == BandedGridHitTest.Footer || hi.HitTest == BandedGridHitTest.RowFooter)
                {
                    DevExpress.XtraGrid.Menu.GridViewFooterMenu menu = new GridViewFooterMenu(this);

                    menuType = GridMenuType.Summary;

                    //this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                    this.ShowGridMenuEx(this, new PopupMenuShowingEventArgs(menuType, menu, hi, true));
                }


            }

        }

        public object GetRowCellValue(int rowHandle, int colIndex)
        {
            return this.GetRowCellValue(rowHandle, this.Columns[colIndex]);
        }

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
