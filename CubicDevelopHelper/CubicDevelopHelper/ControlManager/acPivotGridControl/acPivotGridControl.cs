using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils.Menu;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Data;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPrinting;
using BizManager;

namespace ControlManager
{


    public class acPivotGridViewInfoData : PivotGridViewInfoData
    {

        public override void RetrieveFields()
        {
            base.RetrieveFields();
        }


        public acPivotGridViewInfoData(IViewInfoControl control)
            : base(control)
        {

        }

        protected override PivotGridFieldCollectionBase CreateFieldCollection()
        {
            return new acPivotGridFieldCollection(this);


        }
    }

    public class acPivotGridFieldCollection : PivotGridFieldCollection
    {
        public acPivotGridFieldCollection(PivotGridData data)
            : base(data)
        {


        }

        protected override PivotGridFieldBase CreateField(string fieldName, PivotArea area)
        {
            return new acPivotGridField(fieldName, area);
        }

    }


    public class acPivotGridField : PivotGridField, IBaseViewControl
    {

        public acPivotGridField()
            : base()
        {


        }

        public acPivotGridField(string fieldName, PivotArea area)
            : base(fieldName, area)
        {

        }



        private string _Code = null;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }


        private acPivotGridControl.emPivotMask _Mask = acPivotGridControl.emPivotMask.NONE;

        public acPivotGridControl.emPivotMask Mask
        {
            get { return _Mask; }
            set { _Mask = value; }
        }

        private acPivotGridControl.emFieldType _FieldType = acPivotGridControl.emFieldType.TEXT;

        public acPivotGridControl.emFieldType FieldType
        {
            get { return _FieldType; }
            set { _FieldType = value; }
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


    public class acPivotGridControl : DevExpress.XtraPivotGrid.PivotGridControl
    {

        private bool _ShowMenu = false;


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WIN32API.WM_CONTEXTMENU)
            {
                Point pt = new Point(m.LParam.ToInt32());

                Point cpt = this.PointToClient(pt);


                this._ShowMenu = true;


                if (_MouseEventArgs != null)
                {
                    base.OnMouseDown(_MouseEventArgs);
                }


                this._ShowMenu = false;


            }

            base.WndProc(ref m);
        }


        private MouseEventArgs _MouseEventArgs = null;

        protected override void OnMouseDown(MouseEventArgs ee)
        {
            this._MouseEventArgs = ee;

            base.OnMouseDown(ee);
        }

        public enum emFieldType
        {

            TEXT,


            CODE,


            TEMP,

            EMP

        }


        public enum emPivotMask
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

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
            MONEY,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,

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
            F2,

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

            MONTH_DATE,

            SHORT_DATE,

            MEDIUM_DATE,

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




        private Control _ParentControl = null;

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

        private acPivotGridStyleBox _StyleBox = null;


        internal byte[] _SystemLayout = null;

        internal byte[] _SystemConfig = null;




        private System.Windows.Forms.Timer _VisibleTimer = null;


        public acPivotGridControl()
            : base()
        {

            this._VisibleTimer = new System.Windows.Forms.Timer();

            this._VisibleTimer.Interval = 100;


            this._Config = new acPivotGridConfig(this);

            this.OptionsBehavior.HorizontalScrolling = PivotGridScrolling.Control;



            

            //this.ShowMenu += new DevExpress.XtraPivotGrid.PivotGridMenuEventHandler(acPivotGridControl_ShowMenu);            

            this.PopupMenuShowing += new PopupMenuShowingEventHandler(acPivotGridControl_PopupMenuShowing);

            this.CustomDrawFieldValue += new PivotCustomDrawFieldValueEventHandler(acPivotGridControl_CustomDrawFieldValue);

            //this.CustomUnboundFieldData += new CustomFieldDataEventHandler(acPivotGridControl_CustomUnboundFieldData);

            this.Disposed += new EventHandler(acPivotGridControl_Disposed);


            this._VisibleTimer.Tick += new EventHandler(_VisibleTimer_Tick);


            this.VisibleChanged += new EventHandler(acPivotGridControl_VisibleChanged);

            this.ShowCustomizationForm += new EventHandler(acPivotGridControl_ShowCustomizationForm);

            this.HideCustomizationForm += new EventHandler(acPivotGridControl_HideCustomizationForm);



        }

        void acPivotGridControl_CustomUnboundFieldData(object sender, CustomFieldDataEventArgs e)
        {
            try
            {
                if (e.Field.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                {
                    acPivotGridField pf = (acPivotGridField)e.Field;

                    if (pf.FieldType == emFieldType.TEMP)
                    {
                        if (pf.Mask == emPivotMask.SHORT_DATE ||
                            pf.Mask == emPivotMask.MEDIUM_DATE ||
                            pf.Mask == emPivotMask.LONG_DATE ||
                            pf.Mask == emPivotMask.MONTH_DATE)
                        {
                            object v = e.GetListSourceColumnValue(pf.FieldName.Replace("TEMP_", ""));

                            DateTime dt = v.toDateTime();

                            if (dt != DateTime.MinValue)
                            {
                                e.Value = string.Format("{0:" + pf.CellFormat.FormatString + "}", dt);
                            }

                        }
                    }

                }
            }
            catch
            {


            }

        }











        void acPivotGridControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                //보일때는 서브윈도우를 숨긴 창들을 표시


                this.ShowSubWindows();



                this._VisibleTimer.Start();
            }
        }

        void _VisibleTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                //보이지않을때는 서브윈도우를 모두 숨긴다.


                this.HideSubWindows();


                this._VisibleTimer.Stop();
            }
        }



        /// <summary>
        /// 그리드에 종송적인 창들을 모두 표시한다.
        /// </summary>
        internal void ShowSubWindows()
        {

            if (this._isCustomizationForm == true)
            {
                this.FieldsCustomization();
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

            foreach (KeyValuePair<string, acPivotGridMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Show();

            }

        }

        /// <summary>
        /// 그리드에 종속적인 창들을 모두 숨긴다.
        /// </summary>
        internal void HideSubWindows()
        {
            if (this._isCustomizationForm == true)
            {
                this.DestroyCustomization();

                this._isCustomizationForm = true;
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

            foreach (KeyValuePair<string, acPivotGridMaskEdit> maskEditor in this._MaskEditors)
            {
                maskEditor.Value.Hide();

            }


        }



        private bool _isCustomizationForm = false;

        void acPivotGridControl_HideCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = false;
        }

        void acPivotGridControl_ShowCustomizationForm(object sender, EventArgs e)
        {
            this._isCustomizationForm = true;
        }



        void acPivotGridControl_Disposed(object sender, EventArgs e)
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


            foreach (KeyValuePair<string, acPivotGridMaskEdit> masks in _MaskEditors)
            {
                masks.Value.Dispose();
            }



        }

        private DevExpress.XtraBars.BarManager _DefaultBarManager = null;

        protected override void OnLoaded()
        {

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


                //시스템 사용자 UI 저장
                acPivotGridConfig systemConfig = new acPivotGridConfig(this);

                systemConfig.Save(out _SystemLayout, out _SystemConfig);

                //사용중인 사용자 UI을 불러온다.

                this.DefaultConfigLoad();

            }


            base.OnLoaded();

        }

        /// <summary>
        /// 사용중인 기본UI를 불러온다.
        /// </summary>
        public void DefaultConfigLoad()
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

            BizRun.QBizRun.ExecuteService(
this.ParentControl, QBiz.emExecuteType.NONE,"CTRL",
"GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT", QuickConfigLoad, QuickException);

            //DataSet dsResult = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

            //QuickConfigLoad(dsResult);

        }

        void QuickConfigLoad(DataSet ds)
        {
            try
            {


                if (ds.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = ds.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    this._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                }
                else
                {
                    this._Config.Clear();
                }

            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(this.ParentControl, "사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY",
                       true, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(this.ParentControl, "사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D",
                        true, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {
                    acMessageBox.Show(this.ParentControl, ex);
                }
            }
        }

        void QuickConfigLoad(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            //사용자 UI 적용

            try
            {


                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    DataRow configRow = e.result.Tables["RSLTDT"].Rows[0];

                    byte[] layoutBuffer = (byte[])configRow["LAYOUT"];
                    byte[] configBuffer = (byte[])configRow["OBJECT"];

                    this._Config.Load(configRow["CONFIG_NAME"], configRow["EMP_CODE"], layoutBuffer, configBuffer);

                }
                else
                {
                    this._Config.Clear();
                }

            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(this.ParentControl, "사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY",
                       true, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else if (ex is DefaultSystemLayoutChangedException)
                {

                    acMessageBox.Show(this.ParentControl, "사용자 UI에 변경된 사항이 있습니다. 변경된 항목을 확인후 다시 저장하시기 바랍니다.", "SKW2GF5D",
                        true, acMessageBox.emMessageBoxType.CONFIRM);


                }
                else
                {
                    acMessageBox.Show(this.ParentControl, ex);
                }
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

                base.DataSource = value;

                if (base.DataSource != null)
                {

                    DataTable CodeData = new DataTable();

                    foreach (string code in _CodeList)
                    {
                        DataTable dt = acInfo.StdCodes.GetCatTable(code);

                        CodeData.Load(new DataTableReader(dt));


                    }

                    DataTable EmpData = null;

                    DataTable paramTableEmp = new DataTable("RQSTDT");
                    paramTableEmp.Columns.Add("PLT_CODE");

                    DataRow paramRow = paramTableEmp.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                    DataSet paramSetEmp = new DataSet();
                    paramSetEmp.Tables.Add(paramTableEmp);

                    DataSet resultSetEmp = BizRun.QBizRun.ExecuteService(this,"STD13A_SER2", paramSetEmp, "RQSTDT", "RSLTDT");
                    //DataSet resultSetEmp = BizManager.acControls.GET_EMPLOYEE(paramSetEmp);

                    EmpData = resultSetEmp.Tables["RSLTDT"];


                    //데이터 가공

                    DataTable data = (DataTable)this.DataSource;

                    DataTable tempData = data.Copy();

                    Dictionary<string, string> colList = new Dictionary<string, string>();

                    Dictionary<string, acPivotGridField> tempColList = new Dictionary<string, acPivotGridField>();

                    Dictionary<string, string> colListEmp = new Dictionary<string, string>();

                    Dictionary<string, acPivotGridField> tempColListEmp = new Dictionary<string, acPivotGridField>();

                    foreach (DataColumn col in data.Columns)
                    {
                        if (this.Fields.GetFieldByName("PN_" + col.ColumnName) != null)
                        {

                            acPivotGridField field = (acPivotGridField)this.Fields[col.ColumnName];

                            if (field != null)
                            {

                                if (field.FieldType == emFieldType.CODE)
                                {
                                    string tempColName = col.ColumnName + "_temp";

                                    tempData.Columns.Add(tempColName);

                                    tempColList.Add(tempColName, field);

                                    colList.Add(tempColName, col.ColumnName);

                                }

                                if (field.FieldType == emFieldType.EMP)
                                {
                                    string tempColName = col.ColumnName + "_temp";

                                    tempData.Columns.Add(tempColName);

                                    tempColListEmp.Add(tempColName, field);

                                    colListEmp.Add(tempColName, col.ColumnName);

                                }
                            }


                        }

                    }

                    if (tempColList.Count != 0 || tempColListEmp.Count != 0)
                    {


                        foreach (KeyValuePair<string, acPivotGridField> tempCol in tempColList)
                        {

                            string orignalColumnName = colList[tempCol.Key].toStringEmpty();

                            foreach (DataRow row in tempData.Rows)
                            {
                                DataRow[] cdRow = CodeData.Select("PLT_CODE = '" + row["PLT_CODE"].ToString() + "' AND CAT_CODE = '" + tempCol.Value.Code + "' AND CD_CODE ='" + row[orignalColumnName].ToString() + "'");

                                if (cdRow.Length != 0)
                                {
                                    row[tempCol.Key] = cdRow[0]["CD_NAME"];
                                }

                            }

                            tempData.Columns.Remove(orignalColumnName);

                            tempData.Columns[tempCol.Key].ColumnName = orignalColumnName;

                        }

                        foreach (KeyValuePair<string, acPivotGridField> tempCol in tempColListEmp)
                        {

                            string orignalColumnName = colListEmp[tempCol.Key].toStringEmpty();

                            foreach (DataRow row in tempData.Rows)
                            {
                                DataRow[] cdRow = EmpData.Select("PLT_CODE = '" + row["PLT_CODE"].ToString() + "' AND EMP_CODE ='" + row[orignalColumnName].ToString() + "'");

                                if (cdRow.Length != 0)
                                {
                                    row[tempCol.Key] = cdRow[0]["EMP_NAME"];
                                }

                            }

                            tempData.Columns.Remove(orignalColumnName);

                            tempData.Columns[tempCol.Key].ColumnName = orignalColumnName;

                        }

                        //가공된데이터소스 지정

                        base.DataSource = tempData;
                    }


                }

                //조회후 BestFit 조회

                if (this._Config.AlwaysBestFit == true)
                {
                    this.BestFit();
                }

            }

        }




        /// <summary>
        /// 기준코드 리스트
        /// </summary>
        internal List<string> _CodeList = new List<string>();



        public void AddCodeField(string columnName, string caption, string resourceID, bool useResourceID, PivotArea area, HorzAlignment align, string code)
        {
            acPivotGridField pf = new acPivotGridField();

            pf.Area = area;

            pf.FieldName = columnName;

            pf.Name = "PN_" + columnName;

            pf.Appearance.Value.TextOptions.HAlignment = align;

            pf.Appearance.Value.Options.UseTextOptions = true;



            if (useResourceID == true)
            {
                pf.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                pf.Caption = caption;
            }

            pf.ResourceID = resourceID;

            pf.UseResourceID = useResourceID;


            pf.Code = code;

            _CodeList.Add(code);

            pf.FieldType = emFieldType.CODE;


            this.Fields.Add(pf);

        }

        public void AddEmpField(string columnName, string caption, string resourceID, bool useResourceID, PivotArea area, HorzAlignment align)
        {
            acPivotGridField pf = new acPivotGridField();

            pf.Area = area;

            pf.FieldName = columnName;

            pf.Name = "PN_" + columnName;

            pf.Appearance.Value.TextOptions.HAlignment = align;

            pf.Appearance.Value.Options.UseTextOptions = true;



            if (useResourceID == true)
            {
                pf.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                pf.Caption = caption;
            }

            pf.ResourceID = resourceID;

            pf.UseResourceID = useResourceID;


            //pf.Code = code;

            //_CodeList.Add(code);

            pf.FieldType = emFieldType.EMP;


            this.Fields.Add(pf);

        }

        public void AddUnboundField(string columnName, string caption, string resourceID, bool useResourceID, PivotArea area, HorzAlignment align, DevExpress.Data.UnboundColumnType unBoundColType, emPivotMask mask)
        {
            acPivotGridField pf = new acPivotGridField();

            pf.Area = area;

            pf.FieldName = columnName;

            pf.Name = "PN_" + columnName;

            pf.Appearance.Value.TextOptions.HAlignment = align;

            pf.Appearance.Value.Options.UseTextOptions = true;

            pf.ResourceID = resourceID;

            if (useResourceID == true)
            {
                pf.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                pf.Caption = caption;
            }

            pf.ResourceID = resourceID;

            pf.UseResourceID = useResourceID;

            pf.Mask = mask;


            switch (mask)
            {
                case emPivotMask.NONE:


                    break;


                case emPivotMask.NUMERIC:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "G";

                    break;


                case emPivotMask.MONEY:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");


                    break;

                case emPivotMask.QTY:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "N0";


                    break;

                case emPivotMask.WEIGHT:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "F2";


                    break;

                case emPivotMask.PER2:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "p2";


                    break;


                case emPivotMask.TIME:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "F0";


                    break;

            }


            pf.FieldType = emFieldType.TEXT;

            pf.UnboundType = unBoundColType;


            this.Fields.Add(pf);
        }

        public void AddField(string columnName, string caption, string resourceID, bool useResourceID, PivotArea area, HorzAlignment align, emPivotMask mask)
        {
            acPivotGridField pf = new acPivotGridField();

            pf.Area = area;

            pf.FieldName = columnName;



            pf.Appearance.Value.TextOptions.HAlignment = align;

            pf.Appearance.Value.Options.UseTextOptions = true;



            if (useResourceID == true)
            {
                pf.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                pf.Caption = caption;
            }

            pf.ResourceID = resourceID;

            pf.UseResourceID = useResourceID;

            pf.Mask = mask;


            switch (mask)
            {
                case emPivotMask.NONE:


                    break;

                case emPivotMask.NUMERIC:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "d";

                    break;

                case emPivotMask.MONEY:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");

                    pf.FieldType = emFieldType.TEXT;
                    break;

                case emPivotMask.QTY:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "N0";
                    pf.FieldType = emFieldType.TEXT;

                    break;

                case emPivotMask.WEIGHT:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "F2";

                    pf.FieldType = emFieldType.TEXT;
                    break;

                case emPivotMask.PER2:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "p2";

                    pf.FieldType = emFieldType.TEXT;
                    break;


                case emPivotMask.TIME:

                    pf.CellFormat.FormatType = FormatType.Numeric;
                    pf.CellFormat.FormatString = "F0";
                    pf.FieldType = emFieldType.TEXT;

                    break;

                case emPivotMask.MONTH_DATE:

                    pf.FieldName = "TEMP_" + pf.FieldName;

                    pf.CellFormat.FormatString = "yyyy-MM";


                    pf.UnboundType = DevExpress.Data.UnboundColumnType.String;

                    pf.FieldType = emFieldType.TEMP;

                    break;


                case emPivotMask.SHORT_DATE:

                    pf.FieldName = "TEMP_" + pf.FieldName;

                    pf.CellFormat.FormatString = "d";

                    pf.UnboundType = DevExpress.Data.UnboundColumnType.String;

                    pf.FieldType = emFieldType.TEMP;

                    break;


                case emPivotMask.MEDIUM_DATE:

                    pf.FieldName = "TEMP_" + pf.FieldName;

                    pf.CellFormat.FormatString = "g";


                    pf.UnboundType = DevExpress.Data.UnboundColumnType.String;

                    pf.FieldType = emFieldType.TEMP;

                    break;

                case emPivotMask.LONG_DATE:

                    pf.FieldName = "TEMP_" + pf.FieldName;

                    pf.CellFormat.FormatString = "G";

                    pf.UnboundType = DevExpress.Data.UnboundColumnType.String;

                    pf.FieldType = emFieldType.TEMP;

                    break;

            }

            pf.Name = "PN_" + columnName;

            this.Fields.Add(pf);



        }







        void acPivotGridControl_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            //피벗그리드 사용자정의 
            if (e.Field != null)
            {
                if (e.Area == PivotArea.DataArea || e.Area == PivotArea.RowArea)
                {
                    DateTime dt = DateTime.MinValue;


                    acPivotGridField pf = (acPivotGridField)e.Field;

                    ////필드 값
                    if (e.ValueType == PivotGridValueType.Value)
                    {

                        e.Info.Caption = string.Format("{0:" + pf.CellFormat.FormatString + "}", e.Value);
                    }




                    //필드 합계
                    else if (e.ValueType == PivotGridValueType.Total)
                    {

                        if (pf.FieldType == emFieldType.TEXT ||
                            pf.FieldType == emFieldType.TEMP)
                        {
                            //텍스트 형태

                            e.Info.Caption = string.Format("{0} {1}", e.DisplayText, acInfo.Resource.GetString("합계", "FBOA9W3E"));


                        }


                    }


                }
                else if (e.Area == PivotArea.ColumnArea)
                {
                    acPivotGridField pf = (acPivotGridField)e.Field;

                    if (e.ValueType == PivotGridValueType.Value)
                    {
                        //if (pf.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                        //{
                        //    e.Info.Caption = string.Format("{0:" + pf.CellFormat.FormatString + "}", e.Value);
                        //}
                    }

                }
            }


        }

        /// <summary>
        /// 사용자 UI
        /// </summary>
        internal acPivotGridConfig _Config = null;
    
        //20150331 신재경
        //void acPivotGridControl_PopupMenuShowing(object sender, DevExpress.XtraPivotGrid.PivotPopupMenuShowingEventArgs e)        
        void acPivotGridControl_PopupMenuShowing(object sender, DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs e)        
        {
            if (this._ShowMenu == false)
            {
                e.Allow = false;

                return;
            }

            //if (e.Button == MouseButtons.Left)
            //{
            //    return;
            //}

            DXMenuItem menuItemStyleBox = new DXMenuItem(acInfo.Resource.GetString("스타일 상자", "6T0ZDDPE"));
            menuItemStyleBox.Image = ControlManager.Resource.applications_graphics;
            menuItemStyleBox.Click += new EventHandler(menuItemStyleBox_Click);


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




            //컬럼 자동크기(전체) 기본
            DXMenuItem menuItemBestFit = new DXMenuItem(acInfo.Resource.GetString("전체 컬럼 자동크기", "AYN0WR6I"));
            menuItemBestFit.Image = ControlManager.Resource.adjustcol;
            menuItemBestFit.Click += new EventHandler(menuItemBestFit_Click);



            DXSubMenuItem menuItemShow = new DXSubMenuItem(acInfo.Resource.GetString("표시", "0VXIPFNO"));
            menuItemShow.Image = ControlManager.Resource.preferences_desktop_locale;

            acDXMenuCheckItem menuItemShowFilterHeaders = new acDXMenuCheckItem(acInfo.Resource.GetString("필터 필드", "9YEQLQO0"), this.OptionsView.ShowFilterHeaders);
            menuItemShowFilterHeaders.Click += new EventHandler(menuItemShowFilterHeaders_Click);


            acDXMenuCheckItem menuItemShowDataHeaders = new acDXMenuCheckItem(acInfo.Resource.GetString("데이터 필드", "YVKRRRGO"), this.OptionsView.ShowDataHeaders);
            menuItemShowDataHeaders.Click += new EventHandler(menuItemShowDataHeaders_Click);


            acDXMenuCheckItem menuItemShowColumnHeaders = new acDXMenuCheckItem(acInfo.Resource.GetString("컬럼 필드", "A35XBTCZ"), this.OptionsView.ShowColumnHeaders);
            menuItemShowColumnHeaders.Click += new EventHandler(menuItemShowColumnHeaders_Click);

            acDXMenuCheckItem menuItemShowRowHeaders = new acDXMenuCheckItem(acInfo.Resource.GetString("로우 필드", "4PPI5Q3P"), this.OptionsView.ShowRowHeaders);
            menuItemShowRowHeaders.Click += new EventHandler(menuItemShowRowHeaders_Click);



            menuItemShow.Items.Add(menuItemShowFilterHeaders);

            menuItemShow.Items.Add(menuItemShowDataHeaders);
            menuItemShow.Items.Add(menuItemShowColumnHeaders);
            menuItemShow.Items.Add(menuItemShowRowHeaders);

            DXSubMenuItem menuItemMethod = new DXSubMenuItem(acInfo.Resource.GetString("기능", "QS1MTC9B"));
            menuItemMethod.Image = ControlManager.Resource.emblem_system;

            acDXMenuCheckItem menuItemAlwaysBestFit = new acDXMenuCheckItem(acInfo.Resource.GetString("항상 전체 컬럼 자동크기", "LHZDTQ5M"), _Config.AlwaysBestFit);
            menuItemAlwaysBestFit.Image = ControlManager.Resource.adjustcol_star_x16;
            menuItemAlwaysBestFit.Click += new EventHandler(menuItemAlwaysBestFit_Click);
         




            menuItemMethod.Items.Add(menuItemBestFit);
            menuItemMethod.Items.Add(menuItemAlwaysBestFit);





            DXSubMenuItem menuItemConfig = new DXSubMenuItem(acInfo.Resource.GetString("사용자 UI", "MVDNG5SB"));
            menuItemConfig.Image = ControlManager.Resource.color_swatchx_16;



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
            menuItemConfigUse.Image = ControlManager.Resource.table_refresh_x16; ;
            menuItemConfigUse.Click += new EventHandler(menuItemConfigUse_Click);


            DXMenuItem menuItemSystemConfig = new DXMenuItem(acInfo.Resource.GetString("시스템 UI로 초기화", "7Z7GBDQ6"));
            menuItemSystemConfig.Image = ControlManager.Resource.layout_x16;
            menuItemSystemConfig.Click += new EventHandler(menuItemSystemConfig_Click);

            DXMenuItem menuItemConfigManager = new DXMenuItem(acInfo.Resource.GetString("관리", "0FNNF1ZT"));
            menuItemConfigManager.Image = ControlManager.Resource.edit_find_replace_x16;
            menuItemConfigManager.Click += new EventHandler(menuItemConfigManager_Click);


            //현재 설정중인 UI가 존재하지않음
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




            //인쇄



            DXMenuItem menuItemDefaultPrint = new DXMenuItem(acInfo.Resource.GetString("인쇄", "4HOA9EHQ"));
            menuItemDefaultPrint.Image = ControlManager.Resource.document_print_x16;
            menuItemDefaultPrint.Click += new EventHandler(menuItemDefaultPrint_Click);




            DXMenuItem menuHelp = new DXMenuItem(acInfo.Resource.GetString("도움말", "TGFJ3JK4"));
            menuHelp.Image = ControlManager.Resource.help_browser_x16;
            menuHelp.Click += new EventHandler(menuHelp_Click);


            //acPivotGridControl pGrid = (acPivotGridControl)sender;
            
            if (e.MenuType == PivotGridMenuType.Header)
            {
                //정렬기능
                
                acPivotGridField acPivotField = (acPivotGridField)e.Field;

 
                DXSubMenuItem menuItemColumn = new DXSubMenuItem(acPivotField.Caption);
                menuItemColumn.Image = ControlManager.Resource.emblem_symbolic_link;


                bool leftAlignChecked = false;
                bool centerAlignChecked = false;
                bool rightAlignChecked = false;

                switch (acPivotField.Appearance.Value.TextOptions.HAlignment)
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





                DXSubMenuItem menuItemAlign = new DXSubMenuItem(acInfo.Resource.GetString("정렬", "RCX5CLOA"));
                menuItemAlign.Image = ControlManager.Resource.format_decreaseindent;


                acDXMenuCheckItem menuItemAlignLeft = new acDXMenuCheckItem(acInfo.Resource.GetString("왼쪽", "CGIKO9PD"), leftAlignChecked);
                menuItemAlignLeft.Click += new EventHandler(menuItemAlignLeft_Click);
                menuItemAlignLeft.RefObject = acPivotField;

                acDXMenuCheckItem menuItemAlignCenter = new acDXMenuCheckItem(acInfo.Resource.GetString("중앙", "U3V3VON0"), centerAlignChecked);

                menuItemAlignCenter.Click += new EventHandler(menuItemAlignCenter_Click);
                menuItemAlignCenter.RefObject = acPivotField;

                acDXMenuCheckItem menuItemAlignRight = new acDXMenuCheckItem(acInfo.Resource.GetString("오른쪽", "0H3LO6W4"), rightAlignChecked);
                menuItemAlignRight.Click += new EventHandler(menuItemAlignRight_Click);
                menuItemAlignRight.RefObject = acPivotField;


                menuItemAlign.Items.Add(menuItemAlignLeft);
                menuItemAlign.Items.Add(menuItemAlignCenter);
                menuItemAlign.Items.Add(menuItemAlignRight);

                //마스크

                acMenuItem menuItemMask = new acMenuItem(acInfo.Resource.GetString("마스크", "YSU2282M"));
                menuItemMask.Image = ControlManager.Resource.text_lowercase_x16;
                menuItemMask.Click += new EventHandler(menuItemMask_Click);
                menuItemMask.UserData = acPivotField;







                //합계표시 기능


                bool isChecked = false;

                if (e.Field.TotalsVisibility == PivotTotalsVisibility.AutomaticTotals ||
                    e.Field.TotalsVisibility == PivotTotalsVisibility.CustomTotals)
                {
                    isChecked = true;
                }
                else
                {
                    isChecked = false;
                }

                acDXMenuCheckItem menuItemSum = new acDXMenuCheckItem(acInfo.Resource.GetString("합계 표시", "QKLT6X48"), isChecked);

                menuItemSum.RefObject = acPivotField;

                menuItemSum.Click += new EventHandler(MenuItemSum_Click);

                menuItemColumn.Items.Add(menuItemAlign);
                menuItemColumn.Items.Add(menuItemMask);
                menuItemColumn.Items.Add(menuItemSum);

                e.Menu.Items.Add(menuItemColumn);


            }
            if (e.MenuType == PivotGridMenuType.FieldValue)
            {
                acDXMenuItem menuItemTextCopy = new acDXMenuItem(acInfo.Resource.GetString("복사", "T2FWJ94V"));
                menuItemTextCopy.RefObject = e.HitInfo.ValueInfo.Value;
                menuItemTextCopy.Click += new EventHandler(menuItemTextCopy_Click);


                e.Menu.Items.Add(menuItemTextCopy);
            }

            e.Menu.Items.Add(menuItemShow);
            menuItemShow.BeginGroup = true;


            e.Menu.Items.Add(menuItemMethod);
            e.Menu.Items.Add(menuItemStyleBox);



            e.Menu.Items.Add(menuItemConfig);
            menuItemConfig.BeginGroup = true;

            e.Menu.Items.Add(menuItemSaveFile);
            menuItemSaveFile.BeginGroup = true;

            e.Menu.Items.Add(menuItemDefaultPrint);
            menuItemDefaultPrint.BeginGroup = true;

            e.Menu.Items.Add(menuHelp);
            menuHelp.BeginGroup = true;


        }

        void menuItemTextCopy_Click(object sender, EventArgs e)
        {
            acDXMenuItem item = sender as acDXMenuItem;

            if(item.RefObject != null)
            {
                Clipboard.SetText(item.RefObject.toStringEmpty());
            }

        }



        void menuItemShowRowHeaders_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = sender as acDXMenuCheckItem;

            this.OptionsView.ShowRowHeaders = item.Checked;
        }

        void menuItemShowColumnHeaders_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = sender as acDXMenuCheckItem;

            this.OptionsView.ShowColumnHeaders = item.Checked;
        }

        void menuItemShowDataHeaders_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = sender as acDXMenuCheckItem;

            this.OptionsView.ShowDataHeaders = item.Checked;

        }

        void menuItemShowFilterHeaders_Click(object sender, EventArgs e)
        {
            acDXMenuCheckItem item = sender as acDXMenuCheckItem;

            this.OptionsView.ShowFilterHeaders = item.Checked;
        }

        void menuHelp_Click(object sender, EventArgs e)
        {
            //피벗그리드 도움말

            string helpClassName = "HELP_CTRL_PIVOT";

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



        void menuItemDefaultPrint_Click(object sender, EventArgs e)
        {
            //기본 양식 인쇄

            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(ps);

            link.Component = this;

            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            link.CreateDocument();

            link.ShowPreview();



        }

        void menuItemBestFit_Click(object sender, EventArgs e)
        {
            //컬럼 최적화

            this.BestFit();

        }


        private Dictionary<string, acPivotGridMaskEdit> _MaskEditors = new Dictionary<string, acPivotGridMaskEdit>();


        void menuItemMask_Click(object sender, EventArgs e)
        {
            //마스크 설정

            acMenuItem item = (acMenuItem)sender;

            acPivotGridField field = (acPivotGridField)item.UserData;

            if (!_MaskEditors.ContainsKey(field.FieldName))
            {


                acPivotGridMaskEdit frm = new acPivotGridMaskEdit(field);

                frm.ParentControl = new Control();

                frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;

                frm.FormClosed += new FormClosedEventHandler(_MaskEditor_FormClosed);


                frm.Show();

                _MaskEditors.Add(field.FieldName, frm);

            }
            else
            {
                _MaskEditors[field.FieldName].Focus();
            }
        }


        void _MaskEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            acPivotGridMaskEdit frm = (acPivotGridMaskEdit)sender;

            _MaskEditors.Remove(frm.Field.FieldName);
        }



        private void QuickBestFit(TimeSpan executeTime)
        {

        }

        void menuItemAlwaysBestFit_Click(object sender, EventArgs e)
        {
            //조회후 항상 BestFit

            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            this._Config.AlwaysBestFit = item.Checked;

        }


        acPivotGridUserConfigManager _ConfigManager = null;


        void menuItemConfigManager_Click(object sender, EventArgs e)
        {
            //사용자 UI 관리

            if (_ConfigManager == null)
            {
                _ConfigManager = new acPivotGridUserConfigManager(this);

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
            _ConfigManager = null;
        }


        void menuItemSystemConfig_Click(object sender, EventArgs e)
        {
            //시스템 사용자 UI으로 초기화

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
            this._ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
            "SET_USERCONFIG_DEFAULT_USE_DEL", paramSet, "RQSTDT", "", QuickUseDel, QuickException);

            //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE_DEL(paramSet);

            //this._Config.Load(null, null, this._SystemLayout, this._SystemConfig);

        }

        void QuickUseDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._Config.Load(null, null, this._SystemLayout, this._SystemConfig);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }


        protected override PivotGridViewInfoData CreateData()
        {
            return new acPivotGridViewInfoData(this);
        }


        void menuItemConfigUse_Click(object sender, EventArgs e)
        {
            //현재 사용자 UI 기본으로 사용
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
    this._ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
    "SET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "", QuickUse, QuickException);

            //BizManager.acControls.SET_USERCONFIG_DEFAULT_USE(paramSet);

            //try
            //{
            //    this._Config.ConfigName = (string)dsResult.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
            //    this._Config.ConfigMaKer = (string)dsResult.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
            //}
            //catch (Exception ex)
            //{
            //    acMessageBox.Show(this.ParentControl, ex);
            //}
        }

        void QuickUse(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._Config.ConfigName = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_NAME"];
                this._Config.ConfigMaKer = (string)e.result.Tables["RQSTDT"].Rows[0]["USE_CONFIG_MAKER"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void menuItemConfigOtherSave_Click(object sender, EventArgs e)
        {
            //사용자 UI 다른이름으로 저장

            acPivotGridUserConfigSaveEditor frm = new acPivotGridUserConfigSaveEditor(this);

            frm.ParentControl = new Control();

            frm.ParentControl.Name = this.ParentControl.Name + "." + this.Name;


            frm.ShowDialog();


        }

        void menuItemConfigSave_Click(object sender, EventArgs e)
        {
            //사용자 UI 저장

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
                    this.ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
                    "SET_USERCONFIG_SAVE2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);

                //DataSet dsResult = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

                //if (dsResult.Tables["RSLTDT"].Rows.Count != 0)
                //{
                //    this._Config.ConfigName = (string)dsResult.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                //    this._Config.ConfigMaKer = (string)dsResult.Tables["RSLTDT"].Rows[0]["EMP_CODE"];
                //}

            }
            else
            {
                acPivotGridUserConfigSaveEditor frm = new acPivotGridUserConfigSaveEditor(this);

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

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            if (ex.ErrNumber == BizException.OVERWRITE ||
                ex.ErrNumber == BizException.OVERWRITE_HISTORY)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), (this.ParentControl as IBase).Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }


        acPivotGridUserConfigLoadEditor _LoadConfig = null;


        void menuItemConfigLoad_Click(object sender, EventArgs e)
        {
            //사용자 UI 불러오기

            if (this._LoadConfig == null)
            {
                _LoadConfig = new acPivotGridUserConfigLoadEditor(this);

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

        void menuItemStyleBox_Click(object sender, EventArgs e)
        {
            //스타일 상자 열기
            if (this._StyleBox == null)
            {

                _StyleBox = new acPivotGridStyleBox(this);

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

        void menuItemAlignRight_Click(object sender, EventArgs e)
        {
            //정렬 오른쪽
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acPivotGridField col = (acPivotGridField)item.RefObject;

            col.Appearance.Value.TextOptions.HAlignment = HorzAlignment.Far;
        }

        void menuItemAlignCenter_Click(object sender, EventArgs e)
        {
            //정렬 중앙
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acPivotGridField col = (acPivotGridField)item.RefObject;

            col.Appearance.Value.TextOptions.HAlignment = HorzAlignment.Center;
        }

        void menuItemAlignLeft_Click(object sender, EventArgs e)
        {
            //정렬 왼쪽
            acDXMenuCheckItem item = (acDXMenuCheckItem)sender;

            acPivotGridField col = (acPivotGridField)item.RefObject;

            col.Appearance.Value.TextOptions.HAlignment = HorzAlignment.Near;
        }



        void MenuItemSum_Click(object sender, EventArgs e)
        {
            //합계표시

            acDXMenuCheckItem menuItem = (acDXMenuCheckItem)sender;

            PivotGridField pivotCol = (PivotGridField)menuItem.RefObject;


            if (menuItem.Checked == true)
            {

                pivotCol.TotalsVisibility = PivotTotalsVisibility.AutomaticTotals;
            }
            else
            {
                pivotCol.TotalsVisibility = PivotTotalsVisibility.None;
            }
        }



        private void SavePivotToFile(QPivotGridExportTo.emSaveFileType saveFileType)
        {
            try
            {
                SaveFileDialog saveDlg = new SaveFileDialog();

                saveDlg.FileName = _SaveFileName;

                QPivotGridExportTo export = new QPivotGridExportTo(_ParentControl);

                switch (saveFileType)
                {
                    case QPivotGridExportTo.emSaveFileType.Excel:

                        saveDlg.Filter = acInfo.Resource.GetString("Excel 97 - 2003 통합 문서 (*.xls)|*.xls", "N5ZM3KM1");

                        break;

                    case QPivotGridExportTo.emSaveFileType.HTML:

                        saveDlg.Filter = acInfo.Resource.GetString("모든 웹페이지 (*.htm;*.html)|*.htm;*.html", "LYLGYIJ5");

                        break;

                    case QPivotGridExportTo.emSaveFileType.PDF:

                        saveDlg.Filter = acInfo.Resource.GetString("Adobe Acrobat PDF 문서(*.pdf)|*.pdf", "L923N2Y4");

                        break;

                    case QPivotGridExportTo.emSaveFileType.RTF:

                        saveDlg.Filter = acInfo.Resource.GetString("서식 있는 텍스트(RTF)|*.rtf", "59JZKX42");

                        break;

                    case QPivotGridExportTo.emSaveFileType.Text:

                        saveDlg.Filter = acInfo.Resource.GetString("텍스트 문서(*.txt)|*.txt", "J8XTLYPT");

                        break;

                    case QPivotGridExportTo.emSaveFileType.MHT:

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

                acMessageBox.Show(ex.Message, this._ParentControl.Parent.Text, acMessageBox.emMessageBoxType.CONFIRM);
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

        void menuItemToExcel_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.Excel);

        }

        void menuItemToPDF_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.PDF);
        }

        void menuItemToText_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.Text);
        }

        void menuItemToRTF_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.RTF);
        }


        void menuItemToHtml_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.HTML);
        }


        void menuItemToMht_Click(object sender, EventArgs e)
        {
            this.SavePivotToFile(QPivotGridExportTo.emSaveFileType.MHT);

        }

        void menuItemToCustom_Click(object sender, EventArgs e)
        {

        }





    }
}
