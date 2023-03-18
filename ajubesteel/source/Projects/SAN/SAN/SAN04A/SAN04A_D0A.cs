using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;


using System.Drawing.Imaging;

namespace SAN
{
    public sealed partial class SAN04A_D0A : BaseMenuDialog
    {

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }


        public override void BarCodeScanInput(string barcode)
        {
        }

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;


        //private DataTable _dtModel = null;

        //private DataTable _dtMotor = null;

        //private DataTable _dtRpm = null;

        //private DataTable _dtEmpList = null;

        //private String _serial_no = "";

        //private DataTable _dtPartDelete = null;

        //private String _work_state = "W";

        //public DisplayClass dc = null;

        protected override void OnClosing(CancelEventArgs e)
        {
            //dc.DisplayAbort();
            //dc = null;
            base.OnClosing(e);
        }

        //private string _cust_eva = "";//고객 만족도

        //class Work
        //{
        //    public string as_num = "";
        //    public int work_seq = 0;
        //}

        //Dictionary<int, Work> _dicWorkList = new Dictionary<int, Work>();

        public SAN04A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;

            //this._serial_no = serial_no;

            DataTable dtParam = new DataTable("RQSTDT");
            dtParam.Columns.Add("PLT_CODE", typeof(String));

            DataRow drParam = dtParam.NewRow();
            drParam["PLT_CODE"] = acInfo.PLT_CODE;

            dtParam.Rows.Add(drParam);

            DataSet dsParam = new DataSet();
            dsParam.Tables.Add(dtParam);

            //_dtModel = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_ACT_MODEL", dsParam, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            //_dtMotor = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_ACT_MODEL_MOTOR", dsParam, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            //_dtRpm = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_ACT_MODEL_MOTOR_RPM", dsParam, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            #region 사용자재

            ////선택된 BOM
            //acTreeList1.KeyFieldName = "BOM_ID";
            //acTreeList1.ParentFieldName = "PARENT_ID";

            //acTreeList1.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("BM_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddTextEdit("PARENT_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddTextEdit("PART_CODE", "품목코드", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("PART_NAME", "품목명", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Near, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddLookUpEdit("MAT_TYPE", "품목형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "S016", false);
            //acTreeList1.AddTextEdit("MAT_SPEC", "규격", "42545", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddLookUpEdit("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, dtProc, "PROC_NAME", "PROC_CODE", true);
            //acTreeList1.AddTextEdit("PART_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.QTY);
            //acTreeList1.AddTextEdit("BOM_QTY", "기준소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, ControlManager.acTreeList.emTextEditMask.QTY);
            ////acTreeList1.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, true, false, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddTextEdit("PROC_NAME", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            ////acTreeList1.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true);

            #endregion

            //acGridView1.CellValueChanging += acGridView1_CellValueChanging;

            //acGridView1.RowUpdated += acGridView1_RowUpdated;

            //acGridView1.ShownEditor += new EventHandler(acGridView1_ShownEditor);

            //acGridView1.HiddenEditor += new EventHandler(acGridView1_HiddenEditor);

            //acGridControl1.EditorKeyDown += acGridControl1_EditorKeyDown;

            //_dtPartDelete = new DataTable("DEL_RQSTDT");
            //_dtPartDelete.Columns.Add("PLT_CODE", typeof(String));
            //_dtPartDelete.Columns.Add("AS_NUM", typeof(String));
            //_dtPartDelete.Columns.Add("WORK_SEQ", typeof(Int32));
            //_dtPartDelete.Columns.Add("BOM_ID", typeof(String));
            //_dtPartDelete.Columns.Add("PARENT_ID", typeof(String));
            //_dtPartDelete.Columns.Add("PART_CODE", typeof(String));
            //_dtPartDelete.Columns.Add("REG_EMP", typeof(String));

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            //dc = new DisplayClass();
            //dc.DisPlayNumber = 1;
            //dc.OnDisplayRotated += dc_OnDisplayRotated;

        }

        private void dc_OnDisplayRotated(object sender)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.Invoke(new MethodInvoker(delegate () { this.WindowState = FormWindowState.Minimized; }));
                    this.Invoke(new MethodInvoker(delegate () { this.WindowState = FormWindowState.Maximized; }));
                }
            }
            catch { }
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            if (newValue == null) newValue = "";

            switch (info.ColumnName)
            {

            }
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barBtnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barItemPrev.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barItemNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barStaticNow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //(acLayoutControl1.GetEditor("CUST_CODE").Editor as acVendor).VenType = "3";

            //(acLayoutControl1.GetEditor("AS_GUBUN").Editor as acLookupEdit).SetCode("AS01");

            //(acLayoutControl1.GetEditor("AS_STATE").Editor as acLookupEdit).SetCode("AS02");

            //(acLayoutControl1.GetEditor("CUST_LOCAL").Editor as acLookupEdit).SetCode("S020");

            //(acLayoutControl1.GetEditor("CUST_COUNTRY").Editor as acLookupEdit).SetCode("C003");



            //(acLayoutControl1.GetEditor("CUST_CITY").Editor as acLookupEdit).SetCode("P003");

            //(acLayoutControl1.GetEditor("CUST_GU").Editor as acLookupEdit).SetCode("P003");

            //(acLayoutControl1.GetEditor("CUST_SITE").Editor as acLookupEdit).SetCode("P003");

            //(acLayoutControl1.GetEditor("CHARGE_CODE").Editor as acLookupEdit).SetCode("AS06");

            //(acLayoutControl1.GetEditor("VOLT").Editor as acLookupEdit).SetCode("E001");

            //(acLayoutControl1.GetEditor("C_VOLT").Editor as acLookupEdit).SetCode("E001");

            //(acLayoutControl1.GetEditor("MODEL").Editor as acLookupEdit).SetData("MODEL","MODEL",_dtModel);           

            //SetCauseCheck();


            SetCodes(AS_CHECK, "A001", "1", "0", CheckState.Unchecked);
            SetCodes(GUBUN_CHECK, "A002", "1", "0", CheckState.Unchecked);
            SetCodes(CAUSE_CHECK, "A003", "1", "0", CheckState.Unchecked);
            SetCodes(WORK_CHECK, "A004", "1", "0", CheckState.Unchecked);
            SetCodes(RESULT_CHECK, "A005", "1", "0", CheckState.Unchecked);
            SetCodes(LAST_CHECK, "A006", "1", "0", CheckState.Unchecked);

            AS_CHECK.ColumnWidth = 110;
            GUBUN_CHECK.ColumnWidth = 110;
            CAUSE_CHECK.ColumnWidth = 110;
            RESULT_CHECK.ColumnWidth = 110;
            WORK_CHECK.ColumnWidth = 110;
            LAST_CHECK.ColumnWidth = 110;

            base.DialogInit();

        }

        #region CheckedListBoxControl Custom
        public void SetCodes(CheckedListBoxControl ctrl, string catCode, object checkedValue, object uncheckedValue, System.Windows.Forms.CheckState defaultCheckd)
        {

            DataSet paramSet = new DataSet();

            DataTable dtResult = acInfo.StdCodes.GetCatTable(catCode);

            foreach (DataRow row in dtResult.Rows)
            {
                AddItem(ctrl, row["CD_NAME"].ToString(), false, null, row["CD_CODE"].ToString(), checkedValue, uncheckedValue, defaultCheckd);
            }

        }

        /// <summary>
        /// 아이템을 추가합니다.
        /// </summary>
        /// <param name="displayValue">표시값</param>
        /// <param name="key">키값</param>
        /// <param name="chekedValue">체크할때값</param>
        /// <param name="uncheckedValue">체크안할때값</param>
        /// <param name="defaultCheked">기본체크</param>
        public void AddItem(
            CheckedListBoxControl ctrl,
            string displayName,
            bool useResourceID,
            string resourceID,
            string key,
            object chekedValue,
            object uncheckedValue,
            System.Windows.Forms.CheckState defaultCheked)
        {
            acCheckedListBoxItem item = new acCheckedListBoxItem(
                displayName,
                useResourceID,
                resourceID,
                key,
                chekedValue,
                uncheckedValue,
                defaultCheked);

            ctrl.Items.Add(item);



        }

        public List<string> GetKeyChecked(CheckedListBoxControl ctrl)
        {
            List<string> keyList = new List<string>();

            foreach (acCheckedListBoxItem item in ctrl.Items)
            {
                if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    keyList.Add(item.Key);

                }

            }

            return keyList;

        }

        public string GetValue(CheckedListBoxControl ctrl)
        {
            List<string> checkedList = GetKeyChecked(ctrl);

            string checkedString = string.Empty;

            int cnt = 0;

            foreach (string key in checkedList)
            {
                checkedString += key;

                ++cnt;

                if (checkedList.Count > cnt)
                {
                    checkedString += ",";
                }
            }

            return checkedString;

        }

        /// <summary>
        /// 키값으로 값을 설정합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void SetKeyValue(CheckedListBoxControl ctrl,string key, object value)
        {


            foreach (acCheckedListBoxItem item in ctrl.Items)
            {
                if (item.Key == key)
                {
                    if (item.CheckedValue.EqualsEx(value))
                    {

                        item.CheckState = System.Windows.Forms.CheckState.Checked;

                        break;
                    }
                    else if (item.UnCheckedValue.EqualsEx(value))
                    {

                        item.CheckState = System.Windows.Forms.CheckState.Unchecked;

                        break;
                    }

                }

            }

        }

        public acCheckedListBoxItem GetItem(CheckedListBoxControl ctrl, string key)
        {

            foreach (acCheckedListBoxItem item in ctrl.Items)
            {
                if (item.Key == key)
                {
                    return item;
                }

            }

            return null;

        }


        public void SetValue(CheckedListBoxControl ctrl,object value)
        {
            
            if (ctrl.Enabled == false)
                return;

            string[] checkedKeys = value.ToString().Split(',');

            string checkedString = string.Empty;

            int cnt = 0;

            foreach (acCheckedListBoxItem item in ctrl.Items)
            {
                SetKeyValue(ctrl, item.Key, item.UnCheckedValue);
            }


            foreach (string checkedKey in checkedKeys)
            {
                acCheckedListBoxItem item = GetItem(ctrl, checkedKey);

                if (item != null)
                {

                    SetKeyValue(ctrl, item.Key, item.CheckedValue);

                    checkedString += item.ToString();

                    ++cnt;

                    if (checkedKeys.Length > cnt)
                    {
                        checkedString += ",";
                    }


                }
            }


            //ctrl.Value = checkedString;

        }
        #endregion
        //private acCheckEdit[] _chkCause1 = null;//접수
        //private acCheckEdit[] _chkCause2 = null;//현장
        //private acCheckEdit[] _chkCause3 = null;//원인파악
        //private acCheckEdit[] _chkCause4 = null;//근본원인

        //void SetCauseCheck()
        //{
        //    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String));
        //    //paramTable.Columns.Add("CS_GUBUN", typeof(String));

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    //paramRow["CS_GUBUN"] = "CS01";

        //    paramTable.Rows.Add(paramRow);
        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    DataTable dtRslt = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_AS_CAUSE", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

        //    if (dtRslt.Rows.Count == 0) return;

        //    DataTable dtCause1 = dtRslt.Select("CS_GUBUN = 'CS01'").CopyToDataTable();//접수
        //    DataTable dtCause2 = dtRslt.Select("CS_GUBUN = 'CS02'").CopyToDataTable();//현장
        //    DataTable dtCause3 = dtRslt.Select("CS_GUBUN = 'CS03'").CopyToDataTable();//원인
        //    DataTable dtCause4 = dtRslt.Select("CS_GUBUN = 'CS04'").CopyToDataTable();//근본

        //    _chkCause1 = new acCheckEdit[dtCause1.Rows.Count];
        //    _chkCause2 = new acCheckEdit[dtCause2.Rows.Count];
        //    _chkCause3 = new acCheckEdit[dtCause3.Rows.Count];
        //    _chkCause4 = new acCheckEdit[dtCause4.Rows.Count];
        //    //접수
        //    int y = 0;
        //    int ax = 20;
        //    for (int i = 0; i < dtCause1.Rows.Count; i++)
        //    {
        //        if (i > 0 && (i % 7 == 0))
        //        {
        //            y += 30;
        //            ax = 20;
        //        }

        //        DataRow row = dtCause1.Rows[i];

        //        _chkCause1[i] = new acCheckEdit();
        //        _chkCause1[i].Text = row["CS_NAME"].ToString();
        //        _chkCause1[i].Size = new Size(100, 40);
        //        _chkCause1[i].Location = new Point(ax, y+3);
        //        _chkCause1[i].Tag = row["CS_CODE"].ToString();
        //        _chkCause1[i].Name = "chk" + row["CS_CODE"].ToString();
        //        _chkCause1[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
        //        _chkCause1[i].ValueType = acCheckEdit.emValueType.STRING;

        //        //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
        //        xtraScrollableControl1.Controls.Add(_chkCause1[i]);

        //        ax = ax + 100;                

        //    }

        //    //현장
        //    y = 0;
        //    ax = 20;
        //    for (int i = 0; i < dtCause2.Rows.Count; i++)
        //    {
        //        if (i > 0 && (i % 7 == 0))
        //        {
        //            y += 30;
        //            ax = 20;
        //        }

        //        DataRow row = dtCause2.Rows[i];

        //        _chkCause2[i] = new acCheckEdit();
        //        _chkCause2[i].Text = row["CS_NAME"].ToString();
        //        _chkCause2[i].Size = new Size(120, 40);
        //        _chkCause2[i].Location = new Point(ax, y + 3);
        //        _chkCause2[i].Tag = row["CS_CODE"].ToString();
        //        _chkCause2[i].Name = "chk" + row["CS_CODE"].ToString();
        //        _chkCause2[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
        //        _chkCause2[i].ValueType = acCheckEdit.emValueType.STRING;

        //        //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
        //        xtraScrollableControl3.Controls.Add(_chkCause2[i]);

        //        ax = ax + 121;

        //    }

        //    //원인
        //    y = 0;
        //    ax = 20;
        //    for (int i = 0; i < dtCause3.Rows.Count; i++)
        //    {
        //        if (i > 0 && (i % 7 == 0))
        //        {
        //            y += 30;
        //            ax = 20;
        //        }

        //        DataRow row = dtCause3.Rows[i];

        //        _chkCause3[i] = new acCheckEdit();
        //        _chkCause3[i].Text = row["CS_NAME"].ToString();
        //        _chkCause3[i].Size = new Size(120, 40);
        //        _chkCause3[i].Location = new Point(ax, y + 3);
        //        _chkCause3[i].Tag = row["CS_CODE"].ToString();
        //        _chkCause3[i].Name = "chk" + row["CS_CODE"].ToString();
        //        _chkCause3[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
        //        _chkCause3[i].ValueType = acCheckEdit.emValueType.STRING;

        //        //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
        //        xtraScrollableControl2.Controls.Add(_chkCause3[i]);

        //        ax = ax + 121;

        //    }


        //    //근분
        //    y = 0;
        //    ax = 20;
        //    for (int i = 0; i < dtCause4.Rows.Count; i++)
        //    {
        //        if (i > 0 && (i % 7 == 0))
        //        {
        //            y += 30;
        //            ax = 20;
        //        }

        //        DataRow row = dtCause4.Rows[i];

        //        _chkCause4[i] = new acCheckEdit();
        //        _chkCause4[i].Text = row["CS_NAME"].ToString();
        //        _chkCause4[i].Size = new Size(120, 40);
        //        _chkCause4[i].Location = new Point(ax, y + 3);
        //        _chkCause4[i].Tag = row["CS_CODE"].ToString();
        //        _chkCause4[i].Name = "chk" + row["CS_CODE"].ToString();
        //        _chkCause4[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
        //        _chkCause4[i].ValueType = acCheckEdit.emValueType.STRING;

        //        //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
        //        xtraScrollableControl4.Controls.Add(_chkCause4[i]);

        //        ax = ax + 121;

        //    }



        //}


        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("ACCEPT_DATE").Value = acDateEdit.GetNowDateFromServer();

            //acLayoutControl1.GetEditor("WORK_DATE").Value = acDateEdit.GetNowDateFromServer();

            //acLayoutControl1.GetEditor("AS_PLN_DATE").Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl1.GetEditor("AS_EMP").Value = acInfo.UserID;

            //acLayoutControl1.GetEditor("AS_STATE").Value = "0";

            //acLayoutControl1.GetEditor("CHARGE_CODE").Value = "1";

            //acLayoutControl1.GetEditor("CUST_LOCAL").Value = "1";

            //acLayoutControl1.GetEditor("AS_GUBUN").FocusEdit();

            //acLayoutControl1.DataBind((this._LinkData as DataRow), true);

            //GetDetailNewInfo();

            #region 담당자 리스트
            //_dtEmpList = new DataTable();
            //_dtEmpList.Columns.Add("EMP_CODE", typeof(String));
            //_dtEmpList.Columns.Add("EMP_NAME", typeof(String));
            //_dtEmpList.Columns.Add("EMP_TYPE", typeof(String));
            //_dtEmpList.Columns.Add("EMP_TITLE", typeof(String));
            #endregion

        }

        private void GetDetailNewInfo()
        {
            try
            {
                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String));
                //paramTable.Columns.Add("AS_NUM", typeof(String));
                //paramTable.Columns.Add("SERIAL_NO", typeof(String));

                //DataRow linkRow = this._LinkData as DataRow;

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["AS_NUM"] = linkRow["AS_NUM"];
                ////paramRow["SERIAL_NO"] = this._serial_no;

                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ASM03A_SER5", paramSet, "RQSTDT", "RSLTDT,RSLTDT_MAN,RSLTDT_CAUSE,RSLTDT_PART");


                //this._dtEmpList = dsRslt.Tables["RSLTDT_MAN"];

                //string empNameList = "";

                //acCheckedComboBoxEdit1.Clear();

                //foreach (DataRow row in this._dtEmpList.Rows)
                //{
                //    empNameList += (empNameList == "" ? row["EMP_NAME"].ToString() : "," + row["EMP_NAME"].ToString());
                //    acCheckedComboBoxEdit1.AddItem(row["EMP_NAME"].ToString(), false, "", row["EMP_CODE"].ToString(), "1", "0", CheckState.Checked);
                //}

                //acTextEdit7.Text = empNameList;

                //if (dsRslt.Tables["RSLTDT"].Rows.Count > 0)
                //{
                //    acLayoutControl1.DataBind(dsRslt.Tables["RSLTDT"].Rows[0], true);
                //    acLayoutControl1.GetEditor("SERIAL_NO").Value = this._serial_no;
                //    if (this._serial_no == null || this._serial_no == "")
                //    {
                //        (acLayoutControl1.GetEditor("CHARGE_CODE").Editor as acLookupEdit).Value = "";

                //        (acLayoutControl1.GetEditor("VOLT").Editor as acLookupEdit).Value = "";

                //        (acLayoutControl1.GetEditor("C_VOLT").Editor as acLookupEdit).Value = "";

                //        (acLayoutControl1.GetEditor("MODEL").Editor as acLookupEdit).Value = "";

                //        (acLayoutControl1.GetEditor("VALVE").Editor as acTextEdit).Value = "";

                //        (acLayoutControl1.GetEditor("TAG_NO").Editor as acTextEdit).Value = "";
                //    }
                //}
                //else
                //{
                //    acLayoutControl1.GetEditor("SERIAL_NO").Value = this._serial_no;
                //}


                //if (_chkCause1 != null && _chkCause1.Length > 0)
                //{
                //    foreach (DataRow row in dsRslt.Tables["RSLTDT_CAUSE"].Rows)
                //    {
                //        foreach (acCheckEdit chk in this._chkCause1)
                //        {
                //            if (chk.Tag.ToString() == row["CS_CODE"].ToString())
                //            {
                //                chk.Checked = true;
                //                break;
                //            }
                //        }
                //    }
                //}

                //acTreeList1.DataSource = dsRslt.Tables["RSLTDT_PART"];
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
                this.Close();
            }
        }


        public override void DialogUser()
        {

            base.DialogUser();

        }
        public override void DialogOpen()
        {
            //열기

            DataRow linkRow = this._LinkData as DataRow;

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barBtnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
   
            acLayoutControl1.DataBind(linkRow, true);


            SearchDetail(linkRow);

            acLayoutControl1.KeyColumns = new string[] { "AS_NO"};

        }


        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                //acGridView1.ClearRow();

                //acLayoutControl1.GetEditor("AS_GUBUN").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private DataSet SaveData(string overwrite)
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_NO", typeof(String)); //            
            paramTable.Columns.Add("AS_EMP", typeof(String)); //
            paramTable.Columns.Add("ACCEPT_DATE", typeof(String)); //
            paramTable.Columns.Add("REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_NAME", typeof(String)); //
            paramTable.Columns.Add("AS_DATE", typeof(String)); //
            paramTable.Columns.Add("CUSTOMER_EMP", typeof(String)); //
            paramTable.Columns.Add("CVND_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_CHECK", typeof(String)); //
            paramTable.Columns.Add("AS_CONTENTS", typeof(String)); //            
            paramTable.Columns.Add("PROD_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("GUBUN_CHECK", typeof(String)); //            
            paramTable.Columns.Add("CAUSE_CHECK", typeof(String)); //
            paramTable.Columns.Add("CAUSE_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("WORK_CHECK", typeof(String)); //
            paramTable.Columns.Add("WORK_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("WORK_IMG1", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG2", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG3", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG4", typeof(Byte[])); //
            paramTable.Columns.Add("RESULT_CHECK", typeof(String)); //
            paramTable.Columns.Add("RESULT_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("CONFIRM_DATE", typeof(String)); //            
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("OCCUR_DATE", typeof(String)); //            
            paramTable.Columns.Add("PLAN_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("LAST_CHECK", typeof(String)); //
            paramTable.Columns.Add("LAST_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AS_NO"] = overwrite == "0" ? string.Empty : layoutRow["AS_NO"];
            paramRow["AS_EMP"] = layoutRow["AS_EMP"];
            paramRow["ACCEPT_DATE"] = layoutRow["ACCEPT_DATE"];            
            paramRow["REQ_DATE"] = layoutRow["REQ_DATE"];
            paramRow["PROD_NAME"] = layoutRow["PROD_NAME"];
            paramRow["AS_DATE"] = layoutRow["AS_DATE"];
            paramRow["CUSTOMER_EMP"] = layoutRow["CUSTOMER_EMP"];
            paramRow["CVND_CODE"] = layoutRow["CVND_CODE"];
            paramRow["AS_CHECK"] = GetValue(AS_CHECK);
            paramRow["AS_CONTENTS"] = layoutRow["AS_CONTENTS"];
            paramRow["PROD_CONTENTS"] = layoutRow["PROD_CONTENTS"];
            paramRow["GUBUN_CHECK"] = GetValue(GUBUN_CHECK);
            paramRow["CAUSE_CHECK"] = GetValue(CAUSE_CHECK);
            paramRow["CAUSE_CONTENTS"] = layoutRow["CAUSE_CONTENTS"];            
            paramRow["WORK_CHECK"] = GetValue(WORK_CHECK);
            paramRow["WORK_CONTENTS"] = layoutRow["WORK_CONTENTS"];
            paramRow["WORK_IMG1"] = layoutRow["WORK_IMG1"];
            paramRow["WORK_IMG2"] = layoutRow["WORK_IMG2"];
            paramRow["WORK_IMG3"] = layoutRow["WORK_IMG3"];
            //paramRow["WORK_IMG4"] = layoutRow["WORK_IMG4"];
            paramRow["RESULT_CHECK"] = GetValue(RESULT_CHECK);
            paramRow["RESULT_CONTENTS"] = layoutRow["RESULT_CONTENTS"];
            paramRow["CONFIRM_DATE"] = layoutRow["CONFIRM_DATE"];
            paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
            paramRow["OCCUR_DATE"] = layoutRow["OCCUR_DATE"];
            paramRow["PLAN_CONTENTS"] = layoutRow["PLAN_CONTENTS"];
            paramRow["LAST_CHECK"] = GetValue(LAST_CHECK);
            paramRow["LAST_CONTENTS"] = layoutRow["LAST_CONTENTS"];
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["OVERWRITE"] = overwrite;

            paramTable.Rows.Add(paramRow);

            

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                DataSet paramSet = SaveData("0");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD06A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                DataSet paramSet = SaveData("1");

                if (paramSet == null)
                {
                    return;

                }

                BizRun.QBizRun.ExecuteService(
                                    this, QBiz.emExecuteType.SAVE,
                                    "ORD06A_INS", paramSet, "RQSTDT", "RSLTDT",
                                    QuickSaveClose,
                                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSaveClose(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //삭제
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AS_NO", typeof(String)); //

                DataRow linkRow = (DataRow)_LinkData;

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["AS_NO"] = layoutRow["AS_NO"];
                
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "ORD06A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickDEL(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBizActor, BizException ex)
        {

            if (ex.ErrNumber == BizException.OVERWRITE ||
                ex.ErrNumber == BizException.OVERWRITE_HISTORY)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBizActor.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBizActor.Start();

            }

            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        /// <summary>
        /// 시리얼, 작업자 원인
        /// </summary>
        private void SearchDetail(DataRow row)
        {            
            SetValue(AS_CHECK, row["AS_CHECK"]);
            SetValue(GUBUN_CHECK, row["GUBUN_CHECK"]);
            SetValue(CAUSE_CHECK, row["CAUSE_CHECK"]);
            SetValue(RESULT_CHECK, row["RESULT_CHECK"]);
            SetValue(WORK_CHECK, row["WORK_CHECK"]);
            SetValue(LAST_CHECK, row["LAST_CHECK"]);


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("AS_NO", typeof(String));
            
            DataRow linkRow = this._LinkData as DataRow;

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AS_NO"] = row["AS_NO"];
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD, "ORD06A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
 
        }

        void QuickSearch(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Value = e.result.Tables["RSLTDT"].Rows[0]["WORK_IMG1"];
                    (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Value = e.result.Tables["RSLTDT"].Rows[0]["WORK_IMG1"];
                    (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Value = e.result.Tables["RSLTDT"].Rows[0]["WORK_IMG1"];
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }        

        private void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                //DataSet dsData = SavePrintData();
                //if (dsData == null) return;

                //object output = ReportManager.acReportView.PrintOut("ASM03B", "DEFAULT", dsData, true);
                //if (output != null)
                //{
                //    acLayoutControl1.GetEditor("WORK_SIGN").Value = (output as DataRow)["WORK_SIGN"];
                //    this._cust_eva = (output as DataRow)["CUST_EVA"].ToString();
                //}

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(this._work_state != "A")
            //    this.barItemSave_ItemClick(null, null);

            //ASM03A_D2A frm = new ASM03A_D2A(this._LinkData as DataRow);

            //frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            //frm.ParentControl = this;

            //base.ChildFormAdd("NEW_COPY", frm);

            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{
            //    acLayoutControl1.GetEditor("SERIAL_NO").Value = frm.OutputData as String;
            //    this._serial_no = frm.OutputData as String;

            //    DataTable paramTable = new DataTable("RQSTDT");
            //    paramTable.Columns.Add("PLT_CODE", typeof(String));
            //    paramTable.Columns.Add("AS_NUM", typeof(String));
            //    paramTable.Columns.Add("SERIAL_NO", typeof(String));

            //    DataRow linkRow = this._LinkData as DataRow;

            //    DataRow paramRow = paramTable.NewRow();
            //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow["AS_NUM"] = (this._LinkData as DataRow)["AS_NUM"];
            //    paramRow["SERIAL_NO"] = this._serial_no;

            //    paramTable.Rows.Add(paramRow);
            //    DataSet paramSet = new DataSet();
            //    paramSet.Tables.Add(paramTable);

            //    DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ASM03A_SER7", paramSet, "RQSTDT", "RSLTDT");


            //    if (dsRslt.Tables["RSLTDT"].Rows.Count > 0)
            //    {
            //        acLayoutControl1.DataBind(dsRslt.Tables["RSLTDT"].Rows[0], true);
            //    }

            //    acLayoutControl1.GetEditor("WORK_SEQ").Value = "";
            //    acPictureEdit1.Image = null;
            //    foreach (DataRow row in (acTreeList1.DataSource as DataTable).Rows)
            //    {
            //        row["STATE"] = "ADD";
            //    }

            //    this.barItemSave.Enabled = true;
            //    this.barItemSaveClose.Enabled = true;

            //    this.barItemPrev.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.barItemNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    this.barStaticNow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                
            //}
        }

        private void barBtnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataSet paramSet = SaveData("0");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD06A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave2(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //DataRow linkRow = _LinkData as DataRow;

                //this.SetWorkList(e.result.Tables["RSLTDT_WORKLIST"], linkRow["WORK_SEQ"].toInt());

                //if (this.ParentControl is ASM03A_M0A)
                //    (this.ParentControl as ASM03A_M0A).Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        

        //private DataSet SavePrintData()
        //{
        //    if (acLayoutControl1.ValidCheck() == false)
        //    {
        //        return null;
        //    }


        //    DataTable paramTable = new DataTable("WORK");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("AS_NUM", typeof(String)); //            
        //    paramTable.Columns.Add("AS_GUBUN", typeof(String)); //
        //    paramTable.Columns.Add("AS_DATE", typeof(String)); //
        //    paramTable.Columns.Add("AS_PLN_START", typeof(String)); //
        //    paramTable.Columns.Add("AS_PLN_END", typeof(String)); //
        //    paramTable.Columns.Add("AS_REG_EMP", typeof(String)); //
        //    paramTable.Columns.Add("AS_REG_DEPT", typeof(String)); //
        //    paramTable.Columns.Add("AS_QTY", typeof(Int32)); //
        //    paramTable.Columns.Add("CUST_CODE", typeof(String)); //
        //    paramTable.Columns.Add("CUST_LOCAL", typeof(String)); //
        //    paramTable.Columns.Add("CUST_COUNTRY", typeof(String)); //
        //    paramTable.Columns.Add("CUST_CITY", typeof(String)); //
        //    paramTable.Columns.Add("CUST_GU", typeof(String)); //
        //    paramTable.Columns.Add("CUST_SITE", typeof(String)); //
        //    paramTable.Columns.Add("CUST_EMP", typeof(String)); //
        //    paramTable.Columns.Add("CUST_EMP_TEL", typeof(String)); //
        //    paramTable.Columns.Add("CUST_ADDR", typeof(String)); //
        //    paramTable.Columns.Add("SITE_NAME", typeof(String)); //
        //    paramTable.Columns.Add("CHARGE_CODE", typeof(String)); //
        //    paramTable.Columns.Add("AS_COST", typeof(Decimal)); //
        //    paramTable.Columns.Add("AS_CHARGE", typeof(Decimal)); //            
        //    paramTable.Columns.Add("AS_CONTENTS", typeof(String)); //
        //    paramTable.Columns.Add("SCOMMENT", typeof(String)); //
        //    paramTable.Columns.Add("AS_EMP_LIST", typeof(String)); //
        //    paramTable.Columns.Add("WORK_SEQ", typeof(Int32)); //
        //    paramTable.Columns.Add("SERIAL_NO", typeof(String)); //
        //    paramTable.Columns.Add("TAG_NO", typeof(String)); //
        //    paramTable.Columns.Add("VALVE", typeof(String)); //
        //    paramTable.Columns.Add("MODEL", typeof(String)); //
        //    paramTable.Columns.Add("MOTOR", typeof(String)); //
        //    paramTable.Columns.Add("VOLT", typeof(String)); //
        //    paramTable.Columns.Add("C_VOLT", typeof(String)); //
        //    paramTable.Columns.Add("RPM", typeof(String)); //
        //    paramTable.Columns.Add("YPGO_DATE", typeof(String)); //
        //    paramTable.Columns.Add("SHIP_DATE", typeof(String)); //
        //    paramTable.Columns.Add("WORK_DATE", typeof(String)); //
        //    paramTable.Columns.Add("WORK_EMP_LIST", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_CHANGE", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_RESET", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_ADD", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_CHECK", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_REQ", typeof(String)); //            
        //    paramTable.Columns.Add("RESULT_FINE", typeof(String)); //
        //    paramTable.Columns.Add("RESULT_ETC", typeof(String)); //
        //    paramTable.Columns.Add("CHECK_CONTENTS", typeof(String)); //
        //    paramTable.Columns.Add("BASIC_CONTENTS", typeof(String)); //
        //    paramTable.Columns.Add("WORK_CONTENTS", typeof(String)); //
        //    paramTable.Columns.Add("WORK_SIGN", typeof(Byte[])); //
        //    //paramTable.Columns.Add("WORK_RESULT", typeof(String)); //
        //    paramTable.Columns.Add("WORK_IMG1", typeof(Byte[])); //
        //    paramTable.Columns.Add("WORK_IMG2", typeof(Byte[])); //
        //    paramTable.Columns.Add("WORK_IMG3", typeof(Byte[])); //
        //    paramTable.Columns.Add("WORK_IMG4", typeof(Byte[])); //
        //    paramTable.Columns.Add("WORK_FAULT_CUST", typeof(String)); //
        //    paramTable.Columns.Add("WORK_FAULT_ENER", typeof(String)); //
        //    paramTable.Columns.Add("WORK_SALE", typeof(String)); //
        //    paramTable.Columns.Add("WORK_DESI", typeof(String)); //
        //    paramTable.Columns.Add("WORK_ASSY", typeof(String)); //
        //    paramTable.Columns.Add("WORK_PROC", typeof(String)); //
        //    paramTable.Columns.Add("WORK_AS", typeof(String)); //
        //    paramTable.Columns.Add("WORK_QUAL", typeof(String)); //
        //    paramTable.Columns.Add("WORK_DEV", typeof(String)); //
        //    paramTable.Columns.Add("WORK_COOP", typeof(String)); //
        //    paramTable.Columns.Add("WORK_COOP2", typeof(String)); //            

        //    paramTable.Columns.Add("APP_OK", typeof(String)); //            
        //    paramTable.Columns.Add("APP_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("AUTO_OK", typeof(String)); //            
        //    paramTable.Columns.Add("AUTO_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("LOC_OK", typeof(String)); //            
        //    paramTable.Columns.Add("LOC_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("POS_OK", typeof(String)); //
        //    paramTable.Columns.Add("POS_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("TOR_OK", typeof(String)); //
        //    paramTable.Columns.Add("TOR_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("MOT_OK", typeof(String)); //
        //    paramTable.Columns.Add("MOT_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("REM_OK", typeof(String)); //
        //    paramTable.Columns.Add("REM_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("OUT_OK", typeof(String)); //
        //    paramTable.Columns.Add("OUT_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("COM_OK", typeof(String)); //
        //    paramTable.Columns.Add("COM_ACTION", typeof(String)); //
        //    paramTable.Columns.Add("REG_EMP", typeof(String)); //

        //    paramTable.Columns.Add("USE_PART", typeof(String)); //

        //    paramTable.Columns.Add("CUST_EVA", typeof(String)); //

        //    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    //paramRow["AS_NUM"] = layoutRow["AS_NUM"];
        //    paramRow["AS_GUBUN"] = layoutRow["AS_GUBUN"];
        //    paramRow["AS_DATE"] = layoutRow["AS_DATE"];
        //    //paramRow["AS_PLN_DATE"] = layoutRow["AS_PLN_DATE"];
        //    paramRow["AS_REG_EMP"] = layoutRow["AS_REG_EMP"];
        //    paramRow["AS_REG_DEPT"] = (acLayoutControl1.GetEditor("AS_REG_EMP").Editor as acEmp).SelectedRow["ORG_CODE"];
        //    //paramRow["AS_QTY"] = acGridView1.RowCount;
        //    paramRow["CUST_CODE"] = layoutRow["CUST_CODE"];
        //    paramRow["CUST_LOCAL"] = layoutRow["CUST_LOCAL"];
        //    paramRow["CUST_COUNTRY"] = layoutRow["CUST_COUNTRY"];
        //    paramRow["CUST_CITY"] = layoutRow["CUST_CITY"];
        //    paramRow["CUST_GU"] = layoutRow["CUST_GU"];
        //    paramRow["CUST_SITE"] = layoutRow["CUST_SITE"];

        //    if (paramRow["CUST_SITE"].ToString() != "")
        //        paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_SITE").Editor as acLookupEdit).Text;
        //    else if (paramRow["CUST_GU"].ToString() != "")
        //        paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_GU").Editor as acLookupEdit).Text;
        //    else if (paramRow["CUST_CITY"].ToString() != "")
        //        paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_CITY").Editor as acLookupEdit).Text;

        //    //paramRow["CUST_EMP"] = layoutRow["CUST_EMP"];
        //    //paramRow["CUST_EMP_TEL"] = layoutRow["CUST_EMP_TEL"];
        //    paramRow["CUST_ADDR"] = layoutRow["CUST_ADDR"];
        //    paramRow["CHARGE_CODE"] = layoutRow["CHARGE_CODE"];
        //    paramRow["AS_COST"] = layoutRow["AS_COST"];
        //    //paramRow["AS_CHARGE"] = layoutRow["AS_CHARGE"];
        //    paramRow["AS_CONTENTS"] = layoutRow["AS_CONTENTS"];
        //    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
        //    paramRow["REG_EMP"] = acInfo.UserID;


        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    paramRow["AS_NUM"] = layoutRow["AS_NUM"];
        //    paramRow["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //    paramRow["SERIAL_NO"] = layoutRow["SERIAL_NO"];
        //    paramRow["TAG_NO"] = layoutRow["TAG_NO"];
        //    paramRow["VALVE"] = layoutRow["VALVE"];
        //    paramRow["MODEL"] = layoutRow["MODEL"];
        //    paramRow["MOTOR"] = layoutRow["MOTOR"];
        //    paramRow["VOLT"] = layoutRow["VOLT"];
        //    paramRow["C_VOLT"] = layoutRow["C_VOLT"];
        //    paramRow["RPM"] = layoutRow["RPM"];
        //    paramRow["YPGO_DATE"] = layoutRow["YPGO_DATE"];
        //    paramRow["SHIP_DATE"] = layoutRow["SHIP_DATE"];
        //    paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
        //    paramRow["WORK_EMP_LIST"] = layoutRow["WORK_EMP_LIST"];
        //    paramRow["RESULT_CHANGE"] = RESULT_CHANGE.EditValue;
        //    paramRow["RESULT_RESET"] = RESULT_RESET.EditValue;
        //    paramRow["RESULT_ADD"] = RESULT_ADD.EditValue;
        //    paramRow["RESULT_CHECK"] = RESULT_CHECK.EditValue;
        //    paramRow["RESULT_REQ"] = RESULT_REQ.EditValue;
        //    paramRow["RESULT_FINE"] = RESULT_FINE.EditValue;
        //    paramRow["RESULT_ETC"] = RESULT_ETC.EditValue;
        //    paramRow["CHECK_CONTENTS"] = layoutRow["CHECK_CONTENTS"];
        //    paramRow["BASIC_CONTENTS"] = layoutRow["BASIC_CONTENTS"];
        //    paramRow["WORK_CONTENTS"] = layoutRow["WORK_CONTENTS"];
        //    paramRow["WORK_SIGN"] = layoutRow["WORK_SIGN"];// acPictureEdit1.Image;
        //    //paramRow["WORK_RESULT"] = richEditControl1.RtfText;// layoutRow["WORK_RESULT"];
        //    paramRow["WORK_IMG1"] = layoutRow["WORK_IMG1"];
        //    paramRow["WORK_IMG2"] = layoutRow["WORK_IMG2"];
        //    paramRow["WORK_IMG3"] = layoutRow["WORK_IMG3"];
        //    paramRow["WORK_IMG4"] = layoutRow["WORK_IMG4"];

        //    paramRow["APP_OK"] = layoutRow["APP_OK"];
        //    paramRow["APP_ACTION"] = layoutRow["APP_ACTION"];
        //    paramRow["AUTO_OK"] = layoutRow["AUTO_OK"];
        //    paramRow["AUTO_ACTION"] = layoutRow["AUTO_ACTION"];
        //    paramRow["LOC_OK"] = layoutRow["LOC_OK"];
        //    paramRow["LOC_ACTION"] = layoutRow["LOC_ACTION"];
        //    paramRow["POS_OK"] = layoutRow["POS_OK"];
        //    paramRow["POS_ACTION"] = layoutRow["POS_ACTION"];
        //    paramRow["TOR_OK"] = layoutRow["TOR_OK"];
        //    paramRow["TOR_ACTION"] = layoutRow["TOR_ACTION"];
        //    paramRow["MOT_OK"] = layoutRow["MOT_OK"];
        //    paramRow["MOT_ACTION"] = layoutRow["MOT_ACTION"];
        //    paramRow["REM_OK"] = layoutRow["REM_OK"];
        //    paramRow["REM_ACTION"] = layoutRow["REM_ACTION"];
        //    paramRow["OUT_OK"] = layoutRow["OUT_OK"];
        //    paramRow["OUT_ACTION"] = layoutRow["OUT_ACTION"];
        //    paramRow["COM_OK"] = layoutRow["COM_OK"];
        //    paramRow["COM_ACTION"] = layoutRow["COM_ACTION"];

        //    paramTable.Rows.Add(paramRow);


        //    //접수
        //    DataTable paramTable1 = new DataTable("CAUSE1");
        //    paramTable1.Columns.Add("AS_NUM", typeof(String)); //  
        //    paramTable1.Columns.Add("WORK_SEQ", typeof(Int32)); //  
        //    paramTable1.Columns.Add("CS_CODE", typeof(String)); //
        //    paramTable1.Columns.Add("CS_NAME", typeof(String)); //
        //    paramTable1.Columns.Add("VALUE", typeof(String)); //
        //    foreach (CheckEdit chk in _chkCause1)
        //    {
        //        //if (!chk.Checked) continue;
        //        DataRow paramRow1 = paramTable1.NewRow();
        //        paramRow1["AS_NUM"] = layoutRow["AS_NUM"];
        //        paramRow1["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //        paramRow1["CS_CODE"] = chk.Tag.ToString();
        //        paramRow1["CS_NAME"] = chk.Text;
        //        paramRow1["VALUE"] = chk.EditValue;
        //        paramTable1.Rows.Add(paramRow1);                
        //    }

        //    //현장
        //    DataTable paramTable2 = new DataTable("CAUSE2");
        //    paramTable2.Columns.Add("AS_NUM", typeof(String)); //  
        //    paramTable2.Columns.Add("WORK_SEQ", typeof(Int32)); //  
        //    paramTable2.Columns.Add("CS_CODE", typeof(String)); //
        //    paramTable2.Columns.Add("CS_NAME", typeof(String)); //
        //    paramTable2.Columns.Add("VALUE", typeof(String)); //
        //    foreach (CheckEdit chk in _chkCause2)
        //    {
        //        //if (!chk.Checked) continue;
        //        DataRow paramRow2 = paramTable2.NewRow();
        //        paramRow2["AS_NUM"] = layoutRow["AS_NUM"];
        //        paramRow2["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //        paramRow2["CS_CODE"] = chk.Tag.ToString();
        //        paramRow2["CS_NAME"] = chk.Text;
        //        paramRow2["VALUE"] = chk.EditValue;
        //        paramTable2.Rows.Add(paramRow2);
        //    }
        //    //원인
        //    DataTable paramTable3 = new DataTable("CAUSE3");
        //    paramTable3.Columns.Add("AS_NUM", typeof(String)); //  
        //    paramTable3.Columns.Add("WORK_SEQ", typeof(Int32)); //  
        //    paramTable3.Columns.Add("CS_CODE", typeof(String)); //
        //    paramTable3.Columns.Add("CS_NAME", typeof(String)); //
        //    paramTable3.Columns.Add("VALUE", typeof(String)); //
        //    foreach (CheckEdit chk in _chkCause3)
        //    {
        //        //if (!chk.Checked) continue;
        //        DataRow paramRow3 = paramTable3.NewRow();
        //        paramRow3["AS_NUM"] = layoutRow["AS_NUM"];
        //        paramRow3["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //        paramRow3["CS_CODE"] = chk.Tag.ToString();
        //        paramRow3["CS_NAME"] = chk.Text;
        //        paramRow3["VALUE"] = chk.EditValue;
        //        paramTable3.Rows.Add(paramRow3);
        //    }
        //    //근본
        //    DataTable paramTable4 = new DataTable("CAUSE4");
        //    paramTable4.Columns.Add("AS_NUM", typeof(String)); //  
        //    paramTable4.Columns.Add("WORK_SEQ", typeof(Int32)); //  
        //    paramTable4.Columns.Add("CS_CODE", typeof(String)); //
        //    paramTable4.Columns.Add("CS_NAME", typeof(String)); //
        //    paramTable4.Columns.Add("VALUE", typeof(String)); //
        //    foreach (CheckEdit chk in _chkCause4)
        //    {
        //        //if (!chk.Checked) continue;
        //        DataRow paramRow4 = paramTable4.NewRow();
        //        paramRow4["AS_NUM"] = layoutRow["AS_NUM"];
        //        paramRow4["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //        paramRow4["CS_CODE"] = chk.Tag.ToString();
        //        paramRow4["CS_NAME"] = chk.Text;
        //        paramRow4["VALUE"] = chk.EditValue;
        //        paramTable4.Rows.Add(paramRow4);
        //    }
        //    ////작업자
        //    //DataTable paramTableEmp = new DataTable("RQSTDT_WORKEMP");
        //    //paramTableEmp.Columns.Add("EMP_CODE", typeof(String)); //
        //    //foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
        //    //{
        //    //    DataRow paramRowWorkEmp = paramTableEmp.NewRow();
        //    //    paramRowWorkEmp["EMP_CODE"] = checkedKey.ToString();
        //    //    paramTableEmp.Rows.Add(paramRowWorkEmp);
        //    //}


        //    //DataTable paramTablePart = new DataTable("PART");
        //    //paramTablePart.Columns.Add("AS_NUM", typeof(String)); //  
        //    //paramTablePart.Columns.Add("WORK_SEQ", typeof(Int32)); //  
        //    //paramTablePart.Columns.Add("BOM_ID", typeof(String)); //
        //    //paramTablePart.Columns.Add("PARENT_ID", typeof(String)); //
        //    //paramTablePart.Columns.Add("PART_CODE", typeof(String)); //
        //    //paramTablePart.Columns.Add("PART_NAME", typeof(String)); //
        //    //paramTablePart.Columns.Add("MAT_SPEC", typeof(String)); //
        //    //paramTablePart.Columns.Add("MAT_TYPE", typeof(String)); //
        //    //paramTablePart.Columns.Add("PART_QTY", typeof(Int32)); //
        //    //paramTablePart.Columns.Add("ID", typeof(String)); //
        //    //paramTablePart.Columns.Add("P_ID", typeof(String)); //

        //    //DataRow[] partRows = acTreeList1.GetDataView().Table.Select();

        //    //foreach (DataRow dr in partRows)
        //    //{

        //    //    if (dr["BOM_ID"].ToString() == "" || dr["STATE"].ToString() == "MODI" || dr["STATE"].ToString() == "ADD")
        //    //    {
        //    //        DataRow paramRowPart = paramTablePart.NewRow();
        //    //        paramRowPart["AS_NUM"] = layoutRow["AS_NUM"];
        //    //        paramRowPart["WORK_SEQ"] = layoutRow["WORK_SEQ"];
        //    //        paramRowPart["BOM_ID"] = dr["BOM_ID"];
        //    //        paramRowPart["PARENT_ID"] = dr["PARENT_ID"];
        //    //        paramRowPart["PART_CODE"] = dr["PART_CODE"];
        //    //        paramRowPart["PART_NAME"] = dr["PART_NAME"];
        //    //        paramRowPart["MAT_TYPE"] = dr["MAT_TYPE"];
        //    //        paramRowPart["MAT_SPEC"] = dr["MAT_SPEC"];
        //    //        paramRowPart["PART_QTY"] = dr["PART_QTY"];
        //    //        paramRowPart["ID"] = dr["BOM_ID"];
        //    //        paramRowPart["P_ID"] = dr["PARENT_ID"];

        //    //        paramTablePart.Rows.Add(paramRowPart);
        //    //    }
        //    //}

        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);
        //    paramSet.Tables.Add(paramTable1);
        //    paramSet.Tables.Add(paramTable2);
        //    paramSet.Tables.Add(paramTable3);
        //    paramSet.Tables.Add(paramTable4);

        //    //paramSet.Tables.Add(paramTablePart);
        //    //paramSet.Tables.Add(paramTableEmp);

        //    return paramSet;
        //}

        //private void barBtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.Close();
        //}

        

        #region 이미지 1
   
        private void acSimpleButton2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDlg = new OpenFileDialog();
            //openFileDlg.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";
            openFileDlg.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDlg.FileName);

                    frmPictureEdit frm = new frmPictureEdit(img);

                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Image resultImg = frm.OutputData as Image;

                        //Clipboard.SetDataObject(resultImg);

                        //richEditControl1.Paste();
                        acLayoutControl1.GetEditor("WORK_IMG1").Value = resultImg;
                    }
                }
                catch
                {
                    acMessageBox.Show("이미지 파일이 아닙니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            try
            {
                //DevExpress.XtraRichEdit.API.Native.DocumentRange range = richEditControl1.Document.Selection;

                //DevExpress.XtraRichEdit.API.Native.DocumentImageCollection collection = richEditControl1.Document.GetImages(range);

                //foreach (DevExpress.XtraRichEdit.API.Native.DocumentImage dimage in collection)
                //{
                //    dimage.Image.NativeImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                //    Clipboard.SetDataObject("");
                //    richEditControl1.Paste();
                //}
                Image img = (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Image;
                //richEditControl1.Document.Selection = range;
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {

            try
            {

                //DevExpress.XtraRichEdit.API.Native.DocumentRange range = richEditControl1.Document.Selection;

                //DevExpress.XtraRichEdit.API.Native.DocumentImageCollection collection = richEditControl1.Document.GetImages(range);

                //foreach (DevExpress.XtraRichEdit.API.Native.DocumentImage dimage in collection)
                //{
                //    dimage.Image.NativeImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //    Clipboard.SetDataObject("");
                //    richEditControl1.Paste();

                //}

                //richEditControl1.Document.Selection = range;
                Image img = (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG1").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }
        #endregion

        #region 이미지 2

        private void acSimpleButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            //openFileDlg.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";
            openFileDlg.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDlg.FileName);

                    frmPictureEdit frm = new frmPictureEdit(img);

                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Image resultImg = frm.OutputData as Image;
                        acLayoutControl1.GetEditor("WORK_IMG2").Value = resultImg;
                    }
                }
                catch
                {
                    acMessageBox.Show("이미지 파일이 아닙니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
        }

        private void acSimpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG2").Editor as acPictureEdit).Image;
                //richEditControl1.Document.Selection = range;
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG2").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }

        private void acSimpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG2").Editor as acPictureEdit).Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG2").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }
        #endregion

        #region 이미지 3
        private void acSimpleButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            //openFileDlg.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";
            openFileDlg.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDlg.FileName);

                    frmPictureEdit frm = new frmPictureEdit(img);

                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Image resultImg = frm.OutputData as Image;
                        acLayoutControl1.GetEditor("WORK_IMG3").Value = resultImg;
                    }
                }
                catch
                {
                    acMessageBox.Show("이미지 파일이 아닙니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
        }

        private void acSimpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG3").Editor as acPictureEdit).Image;
                //richEditControl1.Document.Selection = range;
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG3").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }

        private void acSimpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG3").Editor as acPictureEdit).Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG3").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }
        #endregion

        #region 이미지 4

        private void acSimpleButton14_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            //openFileDlg.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";
            openFileDlg.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openFileDlg.FileName);

                    frmPictureEdit frm = new frmPictureEdit(img);

                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Image resultImg = frm.OutputData as Image;
                        acLayoutControl1.GetEditor("WORK_IMG4").Value = resultImg;
                    }
                }
                catch
                {
                    acMessageBox.Show("이미지 파일이 아닙니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                }
            }
        }

        private void acSimpleButton13_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG4").Editor as acPictureEdit).Image;
                //richEditControl1.Document.Selection = range;
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG4").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }

        private void acSimpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (acLayoutControl1.GetEditor("WORK_IMG4").Editor as acPictureEdit).Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                (acLayoutControl1.GetEditor("WORK_IMG4").Editor as acPictureEdit).Image = img;
            }
            catch { }
        }
        #endregion
        
    }



}