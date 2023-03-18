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

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Drawing.Imaging;

namespace ORD
{
    public sealed partial class ORD06A_D1A : BaseMenuDialog
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

        //private acGridView _LinkView = null;


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

        public ORD06A_D1A(object linkData, String serial_no)
        {
            InitializeComponent();

            this._LinkData = linkData;

            //this._LinkView = linkView;

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

            SetCauseCheck();

            base.DialogInit();

        }


        private acCheckEdit[] _chkCause1 = null;//접수
        private acCheckEdit[] _chkCause2 = null;//현장
        private acCheckEdit[] _chkCause3 = null;//원인파악
        private acCheckEdit[] _chkCause4 = null;//근본원인

        void SetCauseCheck()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            //paramTable.Columns.Add("CS_GUBUN", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["CS_GUBUN"] = "CS01";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable dtRslt = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_AS_CAUSE", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            if (dtRslt.Rows.Count == 0) return;

            DataTable dtCause1 = dtRslt.Select("CS_GUBUN = 'CS01'").CopyToDataTable();//접수
            DataTable dtCause2 = dtRslt.Select("CS_GUBUN = 'CS02'").CopyToDataTable();//현장
            DataTable dtCause3 = dtRslt.Select("CS_GUBUN = 'CS03'").CopyToDataTable();//원인
            DataTable dtCause4 = dtRslt.Select("CS_GUBUN = 'CS04'").CopyToDataTable();//근본

            _chkCause1 = new acCheckEdit[dtCause1.Rows.Count];
            _chkCause2 = new acCheckEdit[dtCause2.Rows.Count];
            _chkCause3 = new acCheckEdit[dtCause3.Rows.Count];
            _chkCause4 = new acCheckEdit[dtCause4.Rows.Count];
            //접수
            int y = 0;
            int ax = 20;
            for (int i = 0; i < dtCause1.Rows.Count; i++)
            {
                if (i > 0 && (i % 7 == 0))
                {
                    y += 30;
                    ax = 20;
                }

                DataRow row = dtCause1.Rows[i];

                _chkCause1[i] = new acCheckEdit();
                _chkCause1[i].Text = row["CS_NAME"].ToString();
                _chkCause1[i].Size = new Size(100, 40);
                _chkCause1[i].Location = new Point(ax, y+3);
                _chkCause1[i].Tag = row["CS_CODE"].ToString();
                _chkCause1[i].Name = "chk" + row["CS_CODE"].ToString();
                _chkCause1[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
                _chkCause1[i].ValueType = acCheckEdit.emValueType.STRING;

                //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
                xtraScrollableControl1.Controls.Add(_chkCause1[i]);

                ax = ax + 100;                

            }

            //현장
            y = 0;
            ax = 20;
            for (int i = 0; i < dtCause2.Rows.Count; i++)
            {
                if (i > 0 && (i % 7 == 0))
                {
                    y += 30;
                    ax = 20;
                }

                DataRow row = dtCause2.Rows[i];

                _chkCause2[i] = new acCheckEdit();
                _chkCause2[i].Text = row["CS_NAME"].ToString();
                _chkCause2[i].Size = new Size(120, 40);
                _chkCause2[i].Location = new Point(ax, y + 3);
                _chkCause2[i].Tag = row["CS_CODE"].ToString();
                _chkCause2[i].Name = "chk" + row["CS_CODE"].ToString();
                _chkCause2[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
                _chkCause2[i].ValueType = acCheckEdit.emValueType.STRING;

                //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
                xtraScrollableControl3.Controls.Add(_chkCause2[i]);

                ax = ax + 121;

            }

            //원인
            y = 0;
            ax = 20;
            for (int i = 0; i < dtCause3.Rows.Count; i++)
            {
                if (i > 0 && (i % 7 == 0))
                {
                    y += 30;
                    ax = 20;
                }

                DataRow row = dtCause3.Rows[i];

                _chkCause3[i] = new acCheckEdit();
                _chkCause3[i].Text = row["CS_NAME"].ToString();
                _chkCause3[i].Size = new Size(120, 40);
                _chkCause3[i].Location = new Point(ax, y + 3);
                _chkCause3[i].Tag = row["CS_CODE"].ToString();
                _chkCause3[i].Name = "chk" + row["CS_CODE"].ToString();
                _chkCause3[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
                _chkCause3[i].ValueType = acCheckEdit.emValueType.STRING;

                //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
                xtraScrollableControl2.Controls.Add(_chkCause3[i]);

                ax = ax + 121;

            }


            //근분
            y = 0;
            ax = 20;
            for (int i = 0; i < dtCause4.Rows.Count; i++)
            {
                if (i > 0 && (i % 7 == 0))
                {
                    y += 30;
                    ax = 20;
                }

                DataRow row = dtCause4.Rows[i];

                _chkCause4[i] = new acCheckEdit();
                _chkCause4[i].Text = row["CS_NAME"].ToString();
                _chkCause4[i].Size = new Size(120, 40);
                _chkCause4[i].Location = new Point(ax, y + 3);
                _chkCause4[i].Tag = row["CS_CODE"].ToString();
                _chkCause4[i].Name = "chk" + row["CS_CODE"].ToString();
                _chkCause4[i].Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
                _chkCause4[i].ValueType = acCheckEdit.emValueType.STRING;

                //chkbtn[i].EditValueChanging += CHK_EditValueChanging;
                xtraScrollableControl4.Controls.Add(_chkCause4[i]);

                ax = ax + 121;

            }



        }

        
        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //acLayoutControl1.GetEditor("AS_DATE").Value = acDateEdit.GetNowDateFromServer();

            //acLayoutControl1.GetEditor("WORK_DATE").Value = acDateEdit.GetNowDateFromServer();

            //acLayoutControl1.GetEditor("AS_PLN_DATE").Value = acDateEdit.GetNowDateFromServer();

            //acLayoutControl1.GetEditor("AS_REG_EMP").Value = acInfo.UserID;

            //acLayoutControl1.GetEditor("AS_STATE").Value = "0";

            //acLayoutControl1.GetEditor("CHARGE_CODE").Value = "1";

            //acLayoutControl1.GetEditor("CUST_LOCAL").Value = "1";

            //acLayoutControl1.GetEditor("AS_GUBUN").FocusEdit();

            acLayoutControl1.DataBind((this._LinkData as DataRow), true);

            GetDetailNewInfo();

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

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //DataRow linkRow = this._LinkData as DataRow;

            //acLayoutControl1.DataBind(linkRow, true);

            SearchDetail();

            acLayoutControl1.KeyColumns = new string[] { "AS_NUM", "WORK_SEQ" };

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

        private DataSet SaveData()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_NUM", typeof(String)); //            
            paramTable.Columns.Add("AS_GUBUN", typeof(String)); //
            paramTable.Columns.Add("AS_DATE", typeof(String)); //
            paramTable.Columns.Add("AS_PLN_START", typeof(String)); //
            paramTable.Columns.Add("AS_PLN_END", typeof(String)); //
            paramTable.Columns.Add("AS_REG_EMP", typeof(String)); //
            paramTable.Columns.Add("AS_REG_DEPT", typeof(String)); //
            paramTable.Columns.Add("AS_QTY", typeof(Int32)); //
            paramTable.Columns.Add("CUST_CODE", typeof(String)); //
            paramTable.Columns.Add("CUST_LOCAL", typeof(String)); //
            paramTable.Columns.Add("CUST_COUNTRY", typeof(String)); //
            paramTable.Columns.Add("CUST_CITY", typeof(String)); //
            paramTable.Columns.Add("CUST_GU", typeof(String)); //
            paramTable.Columns.Add("CUST_SITE", typeof(String)); //
            paramTable.Columns.Add("CUST_EMP", typeof(String)); //
            paramTable.Columns.Add("CUST_EMP_TEL", typeof(String)); //
            paramTable.Columns.Add("CUST_ADDR", typeof(String)); //
            paramTable.Columns.Add("CHARGE_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_COST", typeof(Decimal)); //
            paramTable.Columns.Add("AS_CHARGE", typeof(Decimal)); //            
            paramTable.Columns.Add("AS_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("AS_EMP_LIST", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AS_NUM"] = layoutRow["AS_NUM"];
            paramRow["AS_GUBUN"] = layoutRow["AS_GUBUN"];
            paramRow["AS_DATE"] = layoutRow["AS_DATE"];
            //paramRow["AS_PLN_DATE"] = layoutRow["AS_PLN_DATE"];
            paramRow["AS_REG_EMP"] = layoutRow["AS_REG_EMP"];
            paramRow["AS_REG_DEPT"] = (acLayoutControl1.GetEditor("AS_REG_EMP").Editor as acEmp).SelectedRow["ORG_CODE"];
            //paramRow["AS_QTY"] = acGridView1.RowCount;
            paramRow["CUST_CODE"] = layoutRow["CUST_CODE"];
            paramRow["CUST_LOCAL"] = layoutRow["CUST_LOCAL"];
            paramRow["CUST_COUNTRY"] = layoutRow["CUST_COUNTRY"];
            paramRow["CUST_CITY"] = layoutRow["CUST_CITY"];
            paramRow["CUST_GU"] = layoutRow["CUST_GU"];
            paramRow["CUST_SITE"] = layoutRow["CUST_SITE"];
            paramRow["CUST_EMP"] = layoutRow["CUST_EMP"];
            paramRow["CUST_EMP_TEL"] = layoutRow["CUST_EMP_TEL"];
            paramRow["CUST_ADDR"] = layoutRow["CUST_ADDR"];
            paramRow["CHARGE_CODE"] = layoutRow["CHARGE_CODE"];
            paramRow["AS_COST"] = layoutRow["AS_COST"];
            //paramRow["AS_CHARGE"] = layoutRow["AS_CHARGE"];
            paramRow["AS_CONTENTS"] = layoutRow["AS_CONTENTS"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["REG_EMP"] = acInfo.UserID;

            paramTable.Rows.Add(paramRow);

            DataTable paramTableWork = new DataTable("RQSTDT_WORK");
            paramTableWork.Columns.Add("PLT_CODE", typeof(String)); //
            paramTableWork.Columns.Add("AS_NUM", typeof(String)); //            
            paramTableWork.Columns.Add("WORK_SEQ", typeof(Int32)); //
            paramTableWork.Columns.Add("SERIAL_NO", typeof(String)); //
            paramTableWork.Columns.Add("TAG_NO", typeof(String)); //
            paramTableWork.Columns.Add("VALVE", typeof(String)); //
            paramTableWork.Columns.Add("MODEL", typeof(String)); //
            paramTableWork.Columns.Add("MOTOR", typeof(String)); //
            paramTableWork.Columns.Add("VOLT", typeof(String)); //
            paramTableWork.Columns.Add("C_VOLT", typeof(String)); //
            paramTableWork.Columns.Add("RPM", typeof(String)); //
            paramTableWork.Columns.Add("YPGO_DATE", typeof(String)); //
            paramTableWork.Columns.Add("SHIP_DATE", typeof(String)); //
            paramTableWork.Columns.Add("WORK_DATE", typeof(String)); //
            paramTableWork.Columns.Add("WORK_EMP_LIST", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_CHANGE", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_RESET", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_ADD", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_CHECK", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_REQ", typeof(String)); //            
            paramTableWork.Columns.Add("RESULT_FINE", typeof(String)); //
            paramTableWork.Columns.Add("RESULT_ETC", typeof(String)); //
            paramTableWork.Columns.Add("CHECK_CONTENTS", typeof(String)); //
            paramTableWork.Columns.Add("BASIC_CONTENTS", typeof(String)); //
            paramTableWork.Columns.Add("WORK_CONTENTS", typeof(String)); //
            paramTableWork.Columns.Add("WORK_SIGN", typeof(Byte[])); //
            paramTableWork.Columns.Add("WORK_RESULT", typeof(String)); //
            paramTableWork.Columns.Add("WORK_IMG1", typeof(Byte[])); //
            paramTableWork.Columns.Add("WORK_IMG2", typeof(Byte[])); //
            paramTableWork.Columns.Add("WORK_IMG3", typeof(Byte[])); //
            paramTableWork.Columns.Add("WORK_IMG4", typeof(Byte[])); //
            paramTableWork.Columns.Add("WORK_FAULT_CUST", typeof(String)); //
            paramTableWork.Columns.Add("WORK_FAULT_ENER", typeof(String)); //
            paramTableWork.Columns.Add("WORK_SALE", typeof(String)); //
            paramTableWork.Columns.Add("WORK_DESI", typeof(String)); //
            paramTableWork.Columns.Add("WORK_ASSY", typeof(String)); //
            paramTableWork.Columns.Add("WORK_PROC", typeof(String)); //
            paramTableWork.Columns.Add("WORK_AS", typeof(String)); //
            paramTableWork.Columns.Add("WORK_QUAL", typeof(String)); //
            paramTableWork.Columns.Add("WORK_DEV", typeof(String)); //
            paramTableWork.Columns.Add("WORK_COOP", typeof(String)); //
            paramTableWork.Columns.Add("WORK_COOP2", typeof(String)); //            

            paramTableWork.Columns.Add("APP_OK", typeof(String)); //            
            paramTableWork.Columns.Add("APP_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("AUTO_OK", typeof(String)); //            
            paramTableWork.Columns.Add("AUTO_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("LOC_OK", typeof(String)); //            
            paramTableWork.Columns.Add("LOC_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("POS_OK", typeof(String)); //
            paramTableWork.Columns.Add("POS_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("TOR_OK", typeof(String)); //
            paramTableWork.Columns.Add("TOR_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("MOT_OK", typeof(String)); //
            paramTableWork.Columns.Add("MOT_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("REM_OK", typeof(String)); //
            paramTableWork.Columns.Add("REM_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("OUT_OK", typeof(String)); //
            paramTableWork.Columns.Add("OUT_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("COM_OK", typeof(String)); //
            paramTableWork.Columns.Add("COM_ACTION", typeof(String)); //
            paramTableWork.Columns.Add("SITE_CODE", typeof(String)); //

            paramTableWork.Columns.Add("CUST_EVA", typeof(String)); //

            paramTableWork.Columns.Add("REG_EMP", typeof(String)); //

            DataRow paramRowWork = paramTableWork.NewRow();
            paramRowWork["PLT_CODE"] = acInfo.PLT_CODE;
            paramRowWork["AS_NUM"] = layoutRow["AS_NUM"];
            paramRowWork["WORK_SEQ"] = layoutRow["WORK_SEQ"];
            paramRowWork["SERIAL_NO"] = layoutRow["SERIAL_NO"];
            paramRowWork["TAG_NO"] = layoutRow["TAG_NO"];
            paramRowWork["VALVE"] = layoutRow["VALVE"];
            paramRowWork["MODEL"] = layoutRow["MODEL"];
            paramRowWork["MOTOR"] = layoutRow["MOTOR"];
            paramRowWork["VOLT"] = layoutRow["VOLT"];
            paramRowWork["C_VOLT"] = layoutRow["C_VOLT"];
            paramRowWork["RPM"] = layoutRow["RPM"];
            paramRowWork["YPGO_DATE"] = layoutRow["YPGO_DATE"];
            paramRowWork["SHIP_DATE"] = layoutRow["SHIP_DATE"];
            paramRowWork["WORK_DATE"] = layoutRow["WORK_DATE"];
            paramRowWork["WORK_EMP_LIST"] = layoutRow["WORK_EMP_LIST"];
            paramRowWork["RESULT_CHANGE"] = RESULT_CHANGE.EditValue;
            paramRowWork["RESULT_RESET"] = RESULT_RESET.EditValue;
            paramRowWork["RESULT_ADD"] = RESULT_ADD.EditValue;
            paramRowWork["RESULT_CHECK"] = RESULT_CHECK.EditValue;
            paramRowWork["RESULT_REQ"] = RESULT_REQ.EditValue;
            paramRowWork["RESULT_FINE"] = RESULT_FINE.EditValue;
            paramRowWork["RESULT_ETC"] = RESULT_ETC.EditValue;
            paramRowWork["CHECK_CONTENTS"] = layoutRow["CHECK_CONTENTS"];
            paramRowWork["BASIC_CONTENTS"] = layoutRow["BASIC_CONTENTS"];
            paramRowWork["WORK_CONTENTS"] = layoutRow["WORK_CONTENTS"];
            paramRowWork["WORK_SIGN"] = layoutRow["WORK_SIGN"];
            //paramRowWork["WORK_RESULT"] = richEditControl1.RtfText;// layoutRow["WORK_RESULT"];
            paramRowWork["WORK_IMG1"] = layoutRow["WORK_IMG1"];
            paramRowWork["WORK_IMG2"] = layoutRow["WORK_IMG2"];
            paramRowWork["WORK_IMG3"] = layoutRow["WORK_IMG3"];
            paramRowWork["WORK_IMG4"] = layoutRow["WORK_IMG4"];
            paramRowWork["WORK_FAULT_CUST"] = WORK_FAULT_CUST.EditValue;
            paramRowWork["WORK_FAULT_ENER"] = WORK_FAULT_ENER.EditValue;

            paramRowWork["APP_OK"] = layoutRow["APP_OK"];
            paramRowWork["APP_ACTION"] = layoutRow["APP_ACTION"];
            paramRowWork["AUTO_OK"] = layoutRow["AUTO_OK"];
            paramRowWork["AUTO_ACTION"] = layoutRow["AUTO_ACTION"];
            paramRowWork["LOC_OK"] = layoutRow["LOC_OK"];
            paramRowWork["LOC_ACTION"] = layoutRow["LOC_ACTION"];
            paramRowWork["POS_OK"] = layoutRow["POS_OK"];
            paramRowWork["POS_ACTION"] = layoutRow["POS_ACTION"];
            paramRowWork["TOR_OK"] = layoutRow["TOR_OK"];
            paramRowWork["TOR_ACTION"] = layoutRow["TOR_ACTION"];
            paramRowWork["MOT_OK"] = layoutRow["MOT_OK"];
            paramRowWork["MOT_ACTION"] = layoutRow["MOT_ACTION"];
            paramRowWork["REM_OK"] = layoutRow["REM_OK"];
            paramRowWork["REM_ACTION"] = layoutRow["REM_ACTION"];
            paramRowWork["OUT_OK"] = layoutRow["OUT_OK"];
            paramRowWork["OUT_ACTION"] = layoutRow["OUT_ACTION"];
            paramRowWork["COM_OK"] = layoutRow["COM_OK"];
            paramRowWork["COM_ACTION"] = layoutRow["COM_ACTION"];

            paramRowWork["REG_EMP"] = acInfo.UserID;
            paramTableWork.Rows.Add(paramRowWork);

            //접수
            DataTable paramTable1 = new DataTable("RQSTDT_CAUSE1");
            paramTable1.Columns.Add("CS_CODE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause1)
            {
                if (chk.Checked)
                {
                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["CS_CODE"] = chk.Tag.ToString();
                    paramTable1.Rows.Add(paramRow1);
                }
            }

            //현장
            DataTable paramTable2 = new DataTable("RQSTDT_CAUSE2");
            paramTable2.Columns.Add("CS_CODE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause2)
            {
                if (chk.Checked)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["CS_CODE"] = chk.Tag.ToString();
                    paramTable2.Rows.Add(paramRow2);
                }
            }
            //원인
            DataTable paramTable3 = new DataTable("RQSTDT_CAUSE3");
            paramTable3.Columns.Add("CS_CODE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause3)
            {
                if (chk.Checked)
                {
                    DataRow paramRow3 = paramTable3.NewRow();
                    paramRow3["CS_CODE"] = chk.Tag.ToString();
                    paramTable3.Rows.Add(paramRow3);
                }
            }
            //근본
            DataTable paramTable4 = new DataTable("RQSTDT_CAUSE4");
            paramTable4.Columns.Add("CS_CODE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause4)
            {
                if (chk.Checked)
                {
                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["CS_CODE"] = chk.Tag.ToString();
                    paramTable4.Rows.Add(paramRow4);
                }
            }
            //작업자
            //DataTable paramTableEmp = new DataTable("RQSTDT_WORKEMP");
            //paramTableEmp.Columns.Add("EMP_CODE", typeof(String)); //
            //foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
            //{
            //    DataRow paramRowWorkEmp = paramTableEmp.NewRow();
            //    paramRowWorkEmp["EMP_CODE"] = checkedKey.ToString();
            //    paramTableEmp.Rows.Add(paramRowWorkEmp);
            //}


            DataTable paramTablePart = new DataTable("RQSTDT_PART");                                          
            paramTablePart.Columns.Add("BOM_ID", typeof(String)); //
            paramTablePart.Columns.Add("PARENT_ID", typeof(String)); //
            paramTablePart.Columns.Add("PART_CODE", typeof(String)); //
            paramTablePart.Columns.Add("PART_NAME", typeof(String)); //
            paramTablePart.Columns.Add("MAT_SPEC", typeof(String)); //
            paramTablePart.Columns.Add("MAT_TYPE", typeof(String)); //
            paramTablePart.Columns.Add("PART_QTY", typeof(Int32)); //
            paramTablePart.Columns.Add("BOM_QTY", typeof(Int32)); //
            paramTablePart.Columns.Add("ID", typeof(String)); //
            paramTablePart.Columns.Add("P_ID", typeof(String)); //


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTableWork);
            paramSet.Tables.Add(paramTable1);
            paramSet.Tables.Add(paramTable2);
            paramSet.Tables.Add(paramTable3);
            paramSet.Tables.Add(paramTable4);

            return paramSet;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                DataSet paramSet = SaveData();

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ASM03A_INS2", paramSet, "RQSTDT,RQSTDT_MAN,RQSTDT_CAUSE1,RQSTDT_CAUSE2,RQSTDT_CAUSE3,RQSTDT_CAUSE4,RQSTDT_PART", "RSLTDT",
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
                //if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                //{
                //    this.acLayoutControl1.DataBind(e.result.Tables["RSLTDT"].Rows[0], true);
                //    this._work_state = e.result.Tables["RSLTDT"].Rows[0]["WORK_STATE"].ToString();
                //    if (this._work_state == "A")
                //    {
                //        this.barItemSave.Enabled = false;
                //        this.barItemSaveClose.Enabled = false;
                //    }
                //    else
                //    {
                //        this.barItemSave.Enabled = true;
                //        this.barItemSaveClose.Enabled = true;
                //    }
                //}
                //this.acTreeList1.DataSource = e.result.Tables["RSLTDT_PART"];
                ////this.acTreeList1.ExpandToLevel(0);
                //this.acTreeList1.CollapseAll();

                //this._dtPartDelete.Clear();

                //this.SetWorkList(e.result.Tables["RSLTDT_WORKLIST"], e.result.Tables["RSLTDT"].Rows[0]["WORK_SEQ"].toInt());

                //if (this.ParentControl is ASM03A_M0A)
                //    (this.ParentControl as ASM03A_M0A).Search();

                this.acLayoutControl1.Refresh();
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

                DataSet paramSet = SaveData();

                if (paramSet == null)
                {
                    return;

                }

                BizRun.QBizRun.ExecuteService(
                                    this, QBiz.emExecuteType.SAVE,
                                    "ASM03A_INS2", paramSet, "RQSTDT,RQSTDT_SERIAL,RQSTDT_MAN,RQSTDT_CAUSE", "RSLTDT",
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
                //if (this.ParentControl is ASM03A_M0A)
                //    (this.ParentControl as ASM03A_M0A).Search();

                //this._dtPartDelete.Clear();

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
                paramTable.Columns.Add("AS_NUM", typeof(String)); //
                paramTable.Columns.Add("WORK_SEQ", typeof(Int32)); //

                DataRow linkRow = (DataRow)_LinkData;

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["AS_NUM"] = layoutRow["AS_NUM"];
                paramRow["WORK_SEQ"] = layoutRow["WORK_SEQ"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "ASM03A_DEL3", paramSet, "RQSTDT", "",
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
                //if (this.ParentControl is ASM03A_M0A)
                //    (this.ParentControl as ASM03A_M0A).Search();

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
        private void SearchDetail()
        {
            //DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("AS_NUM", typeof(String));
            paramTable.Columns.Add("WORK_SEQ", typeof(Int32));

            DataRow linkRow = this._LinkData as DataRow;

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AS_NUM"] = linkRow["AS_NUM"];
            paramRow["WORK_SEQ"] = linkRow["WORK_SEQ"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD, "ASM03A_SER4", paramSet, "RQSTDT", "RSLTDT,RSLTDT_MAN,RSLTDT_CAUSE1,RSLTDT_CAUSE2,RSLTDT_CAUSE3,RSLTDT_CAUSE4,RSLTDT_PART",
                QuickSearch,
                QuickException);
 
        }

        void QuickSearch(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //this._dtEmpList = e.result.Tables["RSLTDT_MAN"];

                //string empNameList = "";

                //acCheckedComboBoxEdit1.Clear();

                //foreach (DataRow row in this._dtEmpList.Rows)
                //{
                //    empNameList += (empNameList == "" ? row["EMP_NAME"].ToString() : "," + row["EMP_NAME"].ToString());
                //    acCheckedComboBoxEdit1.AddItem(row["EMP_NAME"].ToString(), false, "", row["EMP_CODE"].ToString(), "1", "0");
                //}

                //acTextEdit7.Text = empNameList;

                //if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                //{
                //    acLayoutControl1.DataBind(e.result.Tables["RSLTDT"].Rows[0], true);

                //    this._work_state = e.result.Tables["RSLTDT"].Rows[0]["WORK_STATE"].ToString();

                //    //acLayoutControl1.GetEditor("CUST_SITE").Value = e.result.Tables["RSLTDT"].Rows[0]["CUST_SITE"];

                //    if(this._work_state == "A")
                //    {
                //        this.barItemSave.Enabled = false;
                //        this.barItemSaveClose.Enabled = false;
                //    }
                //    else
                //    {
                //        this.barItemSave.Enabled = true;
                //        this.barItemSaveClose.Enabled = true;
                //    }

                //    this._cust_eva = e.result.Tables["RSLTDT"].Rows[0]["CUST_EVA"].ToString();

                //    RESULT_CHANGE.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_CHANGE"];
                //    RESULT_RESET.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_RESET"];
                //    RESULT_ADD.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_ADD"];
                //    RESULT_CHECK.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_CHECK"];
                //    RESULT_REQ.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_REQ"];
                //    RESULT_FINE.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_FINE"];
                //    RESULT_ETC.EditValue = e.result.Tables["RSLTDT"].Rows[0]["RESULT_ETC"];
                //    //richEditControl1.RtfText = e.result.Tables["RSLTDT"].Rows[0]["WORK_RESULT"].ToString();
                //    WORK_FAULT_CUST.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_FAULT_CUST"];
                //    WORK_FAULT_ENER.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_FAULT_ENER"];
                //    WORK_SALE.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_SALE"];
                //    WORK_DESI.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_DESI"];
                //    WORK_ASSY.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_ASSY"];
                //    WORK_PROC.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_PROC"];
                //    WORK_AS.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_AS"];
                //    WORK_QUAL.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_QUAL"];
                //    WORK_DEV.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_DEV"];
                //    WORK_COOP.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_COOP"];
                //    WORK_COOP2.EditValue = e.result.Tables["RSLTDT"].Rows[0]["WORK_COOP2"];
                //    try
                //    {
                //        acPictureEdit1.Image = e.result.Tables["RSLTDT"].Rows[0]["WORK_SIGN"].toImage();
                //    }
                //    catch {}

                //    SetWorkList(e.result.Tables["RSLTDT_WORKLIST"], e.result.Tables["RSLTDT"].Rows[0]["WORK_SEQ"].toInt());
                //}
                

                //if (_chkCause1 != null && _chkCause1.Length > 0)
                //{
                //    foreach (DataRow row in e.result.Tables["RSLTDT_CAUSE1"].Rows)
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

                //if (_chkCause2 != null && _chkCause1.Length > 0)
                //{
                //    foreach (DataRow row in e.result.Tables["RSLTDT_CAUSE2"].Rows)
                //    {
                //        foreach (acCheckEdit chk in this._chkCause2)
                //        {
                //            if (chk.Tag.ToString() == row["CS_CODE"].ToString())
                //            {
                //                chk.Checked = true;
                //                break;
                //            }
                //        }
                //    }
                //}

                //if (_chkCause3 != null && _chkCause1.Length > 0)
                //{
                //    foreach (DataRow row in e.result.Tables["RSLTDT_CAUSE3"].Rows)
                //    {
                //        foreach (acCheckEdit chk in this._chkCause3)
                //        {
                //            if (chk.Tag.ToString() == row["CS_CODE"].ToString())
                //            {
                //                chk.Checked = true;
                //                break;
                //            }
                //        }
                //    }
                //}

                //if (_chkCause4 != null && _chkCause1.Length > 0)
                //{
                //    foreach (DataRow row in e.result.Tables["RSLTDT_CAUSE4"].Rows)
                //    {
                //        foreach (acCheckEdit chk in this._chkCause4)
                //        {
                //            if (chk.Tag.ToString() == row["CS_CODE"].ToString())
                //            {
                //                chk.Checked = true;
                //                break;
                //            }
                //        }
                //    }
                //}

                //this.acTreeList1.DataSource = e.result.Tables["RSLTDT_PART"];
                ////this.acTreeList1.ExpandToLevel(0);
                //this.acTreeList1.CollapseAll();                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SetWorkList(DataTable dtWork,int work_seq = -1)
        {
            //this._dicWorkList.Clear();

            //for(int i = 0; i < dtWork.Rows.Count; i++)
            //{
            //    DataRow row = dtWork.Rows[i];
            //    Work work = new Work();
            //    work.as_num = row["AS_NUM"].ToString();
            //    work.work_seq = row["WORK_SEQ"].toInt();
            //    this._dicWorkList.Add(i, work);

            //    if (work_seq == work.work_seq)
            //    {
            //        _nowWorkSeq = i;                    
            //    }
            //}

            //if(this._dicWorkList.Count > 0)
            //{
            //    if (_nowWorkSeq < 0)
            //    {
            //        _nowWorkSeq = (_dicWorkList[0] as Work).work_seq;
            //        barStaticNow.Caption = (_nowWorkSeq + 1).ToString() + "/" + _dicWorkList.Count.ToString();
            //    }
            //    else
            //    {
            //        barStaticNow.Caption = (_nowWorkSeq + 1).ToString() + "/" + _dicWorkList.Count.ToString();
            //    }
            //    barItemPrev.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    barItemNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    barStaticNow.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else
            //{
            //    barItemPrev.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    barItemNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    barStaticNow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
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
                //if(this._work_state != "A")
                //    this.barItemSave_ItemClick(null, null);

                //ASM03A_D2A frm = new ASM03A_D2A(this._LinkData as DataRow);

                //frm.IsCopy = true;

                //frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                //frm.ParentControl = this;

                //frm.Text = "복사하여 저장[시리얼 번호 선택]";

                //base.ChildFormAdd("MULTI_COPY", frm);

                //if (frm.ShowDialog(this) == DialogResult.OK)
                //{
                                  

                //    DataTable paramTable = new DataTable("RQSTDT_SERIAL");
                //    paramTable.Columns.Add("SERIAL_NO",typeof(String));                    
                //    paramTable.Columns.Add("TAG_NO", typeof(String)); //
                //    paramTable.Columns.Add("VALVE", typeof(String)); //
                //    paramTable.Columns.Add("MODEL", typeof(String)); //
                //    paramTable.Columns.Add("MOTOR", typeof(String)); //
                //    paramTable.Columns.Add("VOLT", typeof(String)); //
                //    paramTable.Columns.Add("C_VOLT", typeof(String)); //
                //    paramTable.Columns.Add("RPM", typeof(String)); //
                //    paramTable.Columns.Add("YPGO_DATE", typeof(String)); //
                //    paramTable.Columns.Add("SHIP_DATE", typeof(String)); //
                //    paramTable.Columns.Add("CUST_CODE", typeof(String)); //
                //    paramTable.Columns.Add("COPY_TYPE", typeof(String)); //

                //    if (frm.CopyType == "1")
                //    {
                //        DataView serialView = frm.OutputData as DataView;

                //        if (serialView.Count == 0) return;

                //        for (int i = 0; i < serialView.Count; i++)
                //        {
                //            DataRow paramRow = paramTable.NewRow();

                //            paramRow["SERIAL_NO"] = serialView[i]["SERIAL_NO"];
                //            paramRow["TAG_NO"] = serialView[i]["TAG_NO"];
                //            paramRow["VALVE"] = serialView[i]["VALVE"];
                //            paramRow["MODEL"] = serialView[i]["MODEL"];
                //            paramRow["MOTOR"] = serialView[i]["MOTOR"];
                //            paramRow["VOLT"] = serialView[i]["VOLT"];
                //            paramRow["C_VOLT"] = serialView[i]["C_VOLT"];
                //            paramRow["RPM"] = serialView[i]["RPM"];
                //            paramRow["YPGO_DATE"] = serialView[i]["YPGO_DATE"].toDateString("yyyyMMdd");
                //            paramRow["SHIP_DATE"] = serialView[i]["SHIP_DATE"].toDateString("yyyyMMdd");
                //            paramRow["CUST_CODE"] = acLayoutControl1.GetEditor("CUST_CODE").Value;
                //            paramRow["COPY_TYPE"] = "1";
                //            paramTable.Rows.Add(paramRow);

                //        }
                //    }
                //    else
                //    {
                //        string fromTo = frm.OutputData as string;

                //        if (fromTo == "") return;

                //        string[] fromTos = fromTo.Split('/');

                //        if (fromTos.Length != 2) return;

                //        if (fromTos[0] == "" || fromTos[1] == "") return;

                //        int from = fromTos[0].toInt();

                //        int to = fromTos[1].toInt();

                //        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //        for(; from <= to; from++)
                //        {
                //            DataRow paramRow = paramTable.NewRow();
                //            if(layoutRow["SERIAL_NO"].ToString().Length == 13)
                //                paramRow["SERIAL_NO"] = layoutRow["SERIAL_NO"].ToString().Substring(2, 6) + "-" + from.ToString().PadLeft(4, '0');
                //            else
                //                paramRow["SERIAL_NO"] = layoutRow["SERIAL_NO"].ToString().Substring(0,6) + "-" + from.ToString().PadLeft(4,'0');
                //            paramRow["TAG_NO"] = layoutRow["TAG_NO"];
                //            paramRow["VALVE"] = layoutRow["VALVE"];
                //            paramRow["MODEL"] = layoutRow["MODEL"];
                //            paramRow["MOTOR"] = layoutRow["MOTOR"];
                //            paramRow["VOLT"] = layoutRow["VOLT"];
                //            paramRow["C_VOLT"] = layoutRow["C_VOLT"];
                //            paramRow["RPM"] = layoutRow["RPM"];
                //            paramRow["YPGO_DATE"] = layoutRow["YPGO_DATE"].toDateString("yyyyMMdd");
                //            paramRow["SHIP_DATE"] = layoutRow["SHIP_DATE"].toDateString("yyyyMMdd");
                //            paramRow["CUST_CODE"] = layoutRow["CUST_CODE"];
                //            paramRow["COPY_TYPE"] = "2";
                //            paramTable.Rows.Add(paramRow);
                //        }
                //        if (paramTable.Rows.Count == 0) return;
                //    }                    

                //    string tempWorSeq = acLayoutControl1.GetEditor("WORK_SEQ").Value.ToString();

                //    Image tempImg = acPictureEdit1.Image;

                //    acLayoutControl1.GetEditor("WORK_SEQ").Value = "";

                //    acPictureEdit1.Image = null;

                //    foreach (DataRow row in (acTreeList1.DataSource as DataTable).Rows)
                //    {
                //        row["STATE"] = "ADD";
                //    }

                //    DataSet paramSet = SaveData();

                //    acLayoutControl1.GetEditor("WORK_SEQ").Value = tempWorSeq;

                //    acPictureEdit1.Image = tempImg;

                //    if (paramSet != null)
                //    {
                //        paramSet.Tables.Add(paramTable);

                //        BizRun.QBizRun.ExecuteService(
                //        this, QBiz.emExecuteType.SAVE,
                //        "ASM03A_INS4", paramSet, "RQSTDT,RQSTDT_SERIAL,RQSTDT_MAN,RQSTDT_CAUSE1,RQSTDT_CAUSE2,RQSTDT_CAUSE3,RQSTDT_CAUSE4,RQSTDT_PART", "RSLTDT",
                //        QuickSave2,
                //        QuickException);
                //    }
                
                //}
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
        

        private DataSet SavePrintData()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }


            DataTable paramTable = new DataTable("WORK");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_NUM", typeof(String)); //            
            paramTable.Columns.Add("AS_GUBUN", typeof(String)); //
            paramTable.Columns.Add("AS_DATE", typeof(String)); //
            paramTable.Columns.Add("AS_PLN_START", typeof(String)); //
            paramTable.Columns.Add("AS_PLN_END", typeof(String)); //
            paramTable.Columns.Add("AS_REG_EMP", typeof(String)); //
            paramTable.Columns.Add("AS_REG_DEPT", typeof(String)); //
            paramTable.Columns.Add("AS_QTY", typeof(Int32)); //
            paramTable.Columns.Add("CUST_CODE", typeof(String)); //
            paramTable.Columns.Add("CUST_LOCAL", typeof(String)); //
            paramTable.Columns.Add("CUST_COUNTRY", typeof(String)); //
            paramTable.Columns.Add("CUST_CITY", typeof(String)); //
            paramTable.Columns.Add("CUST_GU", typeof(String)); //
            paramTable.Columns.Add("CUST_SITE", typeof(String)); //
            paramTable.Columns.Add("CUST_EMP", typeof(String)); //
            paramTable.Columns.Add("CUST_EMP_TEL", typeof(String)); //
            paramTable.Columns.Add("CUST_ADDR", typeof(String)); //
            paramTable.Columns.Add("SITE_NAME", typeof(String)); //
            paramTable.Columns.Add("CHARGE_CODE", typeof(String)); //
            paramTable.Columns.Add("AS_COST", typeof(Decimal)); //
            paramTable.Columns.Add("AS_CHARGE", typeof(Decimal)); //            
            paramTable.Columns.Add("AS_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("AS_EMP_LIST", typeof(String)); //
            paramTable.Columns.Add("WORK_SEQ", typeof(Int32)); //
            paramTable.Columns.Add("SERIAL_NO", typeof(String)); //
            paramTable.Columns.Add("TAG_NO", typeof(String)); //
            paramTable.Columns.Add("VALVE", typeof(String)); //
            paramTable.Columns.Add("MODEL", typeof(String)); //
            paramTable.Columns.Add("MOTOR", typeof(String)); //
            paramTable.Columns.Add("VOLT", typeof(String)); //
            paramTable.Columns.Add("C_VOLT", typeof(String)); //
            paramTable.Columns.Add("RPM", typeof(String)); //
            paramTable.Columns.Add("YPGO_DATE", typeof(String)); //
            paramTable.Columns.Add("SHIP_DATE", typeof(String)); //
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("WORK_EMP_LIST", typeof(String)); //
            paramTable.Columns.Add("RESULT_CHANGE", typeof(String)); //
            paramTable.Columns.Add("RESULT_RESET", typeof(String)); //
            paramTable.Columns.Add("RESULT_ADD", typeof(String)); //
            paramTable.Columns.Add("RESULT_CHECK", typeof(String)); //
            paramTable.Columns.Add("RESULT_REQ", typeof(String)); //            
            paramTable.Columns.Add("RESULT_FINE", typeof(String)); //
            paramTable.Columns.Add("RESULT_ETC", typeof(String)); //
            paramTable.Columns.Add("CHECK_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("BASIC_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("WORK_CONTENTS", typeof(String)); //
            paramTable.Columns.Add("WORK_SIGN", typeof(Byte[])); //
            //paramTable.Columns.Add("WORK_RESULT", typeof(String)); //
            paramTable.Columns.Add("WORK_IMG1", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG2", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG3", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_IMG4", typeof(Byte[])); //
            paramTable.Columns.Add("WORK_FAULT_CUST", typeof(String)); //
            paramTable.Columns.Add("WORK_FAULT_ENER", typeof(String)); //
            paramTable.Columns.Add("WORK_SALE", typeof(String)); //
            paramTable.Columns.Add("WORK_DESI", typeof(String)); //
            paramTable.Columns.Add("WORK_ASSY", typeof(String)); //
            paramTable.Columns.Add("WORK_PROC", typeof(String)); //
            paramTable.Columns.Add("WORK_AS", typeof(String)); //
            paramTable.Columns.Add("WORK_QUAL", typeof(String)); //
            paramTable.Columns.Add("WORK_DEV", typeof(String)); //
            paramTable.Columns.Add("WORK_COOP", typeof(String)); //
            paramTable.Columns.Add("WORK_COOP2", typeof(String)); //            

            paramTable.Columns.Add("APP_OK", typeof(String)); //            
            paramTable.Columns.Add("APP_ACTION", typeof(String)); //
            paramTable.Columns.Add("AUTO_OK", typeof(String)); //            
            paramTable.Columns.Add("AUTO_ACTION", typeof(String)); //
            paramTable.Columns.Add("LOC_OK", typeof(String)); //            
            paramTable.Columns.Add("LOC_ACTION", typeof(String)); //
            paramTable.Columns.Add("POS_OK", typeof(String)); //
            paramTable.Columns.Add("POS_ACTION", typeof(String)); //
            paramTable.Columns.Add("TOR_OK", typeof(String)); //
            paramTable.Columns.Add("TOR_ACTION", typeof(String)); //
            paramTable.Columns.Add("MOT_OK", typeof(String)); //
            paramTable.Columns.Add("MOT_ACTION", typeof(String)); //
            paramTable.Columns.Add("REM_OK", typeof(String)); //
            paramTable.Columns.Add("REM_ACTION", typeof(String)); //
            paramTable.Columns.Add("OUT_OK", typeof(String)); //
            paramTable.Columns.Add("OUT_ACTION", typeof(String)); //
            paramTable.Columns.Add("COM_OK", typeof(String)); //
            paramTable.Columns.Add("COM_ACTION", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            paramTable.Columns.Add("USE_PART", typeof(String)); //

            paramTable.Columns.Add("CUST_EVA", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["AS_NUM"] = layoutRow["AS_NUM"];
            paramRow["AS_GUBUN"] = layoutRow["AS_GUBUN"];
            paramRow["AS_DATE"] = layoutRow["AS_DATE"];
            //paramRow["AS_PLN_DATE"] = layoutRow["AS_PLN_DATE"];
            paramRow["AS_REG_EMP"] = layoutRow["AS_REG_EMP"];
            paramRow["AS_REG_DEPT"] = (acLayoutControl1.GetEditor("AS_REG_EMP").Editor as acEmp).SelectedRow["ORG_CODE"];
            //paramRow["AS_QTY"] = acGridView1.RowCount;
            paramRow["CUST_CODE"] = layoutRow["CUST_CODE"];
            paramRow["CUST_LOCAL"] = layoutRow["CUST_LOCAL"];
            paramRow["CUST_COUNTRY"] = layoutRow["CUST_COUNTRY"];
            paramRow["CUST_CITY"] = layoutRow["CUST_CITY"];
            paramRow["CUST_GU"] = layoutRow["CUST_GU"];
            paramRow["CUST_SITE"] = layoutRow["CUST_SITE"];

            if (paramRow["CUST_SITE"].ToString() != "")
                paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_SITE").Editor as acLookupEdit).Text;
            else if (paramRow["CUST_GU"].ToString() != "")
                paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_GU").Editor as acLookupEdit).Text;
            else if (paramRow["CUST_CITY"].ToString() != "")
                paramRow["SITE_NAME"] = (acLayoutControl1.GetEditor("CUST_CITY").Editor as acLookupEdit).Text;

            //paramRow["CUST_EMP"] = layoutRow["CUST_EMP"];
            //paramRow["CUST_EMP_TEL"] = layoutRow["CUST_EMP_TEL"];
            paramRow["CUST_ADDR"] = layoutRow["CUST_ADDR"];
            paramRow["CHARGE_CODE"] = layoutRow["CHARGE_CODE"];
            paramRow["AS_COST"] = layoutRow["AS_COST"];
            //paramRow["AS_CHARGE"] = layoutRow["AS_CHARGE"];
            paramRow["AS_CONTENTS"] = layoutRow["AS_CONTENTS"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["REG_EMP"] = acInfo.UserID;


            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AS_NUM"] = layoutRow["AS_NUM"];
            paramRow["WORK_SEQ"] = layoutRow["WORK_SEQ"];
            paramRow["SERIAL_NO"] = layoutRow["SERIAL_NO"];
            paramRow["TAG_NO"] = layoutRow["TAG_NO"];
            paramRow["VALVE"] = layoutRow["VALVE"];
            paramRow["MODEL"] = layoutRow["MODEL"];
            paramRow["MOTOR"] = layoutRow["MOTOR"];
            paramRow["VOLT"] = layoutRow["VOLT"];
            paramRow["C_VOLT"] = layoutRow["C_VOLT"];
            paramRow["RPM"] = layoutRow["RPM"];
            paramRow["YPGO_DATE"] = layoutRow["YPGO_DATE"];
            paramRow["SHIP_DATE"] = layoutRow["SHIP_DATE"];
            paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
            paramRow["WORK_EMP_LIST"] = layoutRow["WORK_EMP_LIST"];
            paramRow["RESULT_CHANGE"] = RESULT_CHANGE.EditValue;
            paramRow["RESULT_RESET"] = RESULT_RESET.EditValue;
            paramRow["RESULT_ADD"] = RESULT_ADD.EditValue;
            paramRow["RESULT_CHECK"] = RESULT_CHECK.EditValue;
            paramRow["RESULT_REQ"] = RESULT_REQ.EditValue;
            paramRow["RESULT_FINE"] = RESULT_FINE.EditValue;
            paramRow["RESULT_ETC"] = RESULT_ETC.EditValue;
            paramRow["CHECK_CONTENTS"] = layoutRow["CHECK_CONTENTS"];
            paramRow["BASIC_CONTENTS"] = layoutRow["BASIC_CONTENTS"];
            paramRow["WORK_CONTENTS"] = layoutRow["WORK_CONTENTS"];
            paramRow["WORK_SIGN"] = layoutRow["WORK_SIGN"];// acPictureEdit1.Image;
            //paramRow["WORK_RESULT"] = richEditControl1.RtfText;// layoutRow["WORK_RESULT"];
            paramRow["WORK_IMG1"] = layoutRow["WORK_IMG1"];
            paramRow["WORK_IMG2"] = layoutRow["WORK_IMG2"];
            paramRow["WORK_IMG3"] = layoutRow["WORK_IMG3"];
            paramRow["WORK_IMG4"] = layoutRow["WORK_IMG4"];

            paramRow["APP_OK"] = layoutRow["APP_OK"];
            paramRow["APP_ACTION"] = layoutRow["APP_ACTION"];
            paramRow["AUTO_OK"] = layoutRow["AUTO_OK"];
            paramRow["AUTO_ACTION"] = layoutRow["AUTO_ACTION"];
            paramRow["LOC_OK"] = layoutRow["LOC_OK"];
            paramRow["LOC_ACTION"] = layoutRow["LOC_ACTION"];
            paramRow["POS_OK"] = layoutRow["POS_OK"];
            paramRow["POS_ACTION"] = layoutRow["POS_ACTION"];
            paramRow["TOR_OK"] = layoutRow["TOR_OK"];
            paramRow["TOR_ACTION"] = layoutRow["TOR_ACTION"];
            paramRow["MOT_OK"] = layoutRow["MOT_OK"];
            paramRow["MOT_ACTION"] = layoutRow["MOT_ACTION"];
            paramRow["REM_OK"] = layoutRow["REM_OK"];
            paramRow["REM_ACTION"] = layoutRow["REM_ACTION"];
            paramRow["OUT_OK"] = layoutRow["OUT_OK"];
            paramRow["OUT_ACTION"] = layoutRow["OUT_ACTION"];
            paramRow["COM_OK"] = layoutRow["COM_OK"];
            paramRow["COM_ACTION"] = layoutRow["COM_ACTION"];

            paramTable.Rows.Add(paramRow);


            //접수
            DataTable paramTable1 = new DataTable("CAUSE1");
            paramTable1.Columns.Add("AS_NUM", typeof(String)); //  
            paramTable1.Columns.Add("WORK_SEQ", typeof(Int32)); //  
            paramTable1.Columns.Add("CS_CODE", typeof(String)); //
            paramTable1.Columns.Add("CS_NAME", typeof(String)); //
            paramTable1.Columns.Add("VALUE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause1)
            {
                //if (!chk.Checked) continue;
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["AS_NUM"] = layoutRow["AS_NUM"];
                paramRow1["WORK_SEQ"] = layoutRow["WORK_SEQ"];
                paramRow1["CS_CODE"] = chk.Tag.ToString();
                paramRow1["CS_NAME"] = chk.Text;
                paramRow1["VALUE"] = chk.EditValue;
                paramTable1.Rows.Add(paramRow1);                
            }

            //현장
            DataTable paramTable2 = new DataTable("CAUSE2");
            paramTable2.Columns.Add("AS_NUM", typeof(String)); //  
            paramTable2.Columns.Add("WORK_SEQ", typeof(Int32)); //  
            paramTable2.Columns.Add("CS_CODE", typeof(String)); //
            paramTable2.Columns.Add("CS_NAME", typeof(String)); //
            paramTable2.Columns.Add("VALUE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause2)
            {
                //if (!chk.Checked) continue;
                DataRow paramRow2 = paramTable2.NewRow();
                paramRow2["AS_NUM"] = layoutRow["AS_NUM"];
                paramRow2["WORK_SEQ"] = layoutRow["WORK_SEQ"];
                paramRow2["CS_CODE"] = chk.Tag.ToString();
                paramRow2["CS_NAME"] = chk.Text;
                paramRow2["VALUE"] = chk.EditValue;
                paramTable2.Rows.Add(paramRow2);
            }
            //원인
            DataTable paramTable3 = new DataTable("CAUSE3");
            paramTable3.Columns.Add("AS_NUM", typeof(String)); //  
            paramTable3.Columns.Add("WORK_SEQ", typeof(Int32)); //  
            paramTable3.Columns.Add("CS_CODE", typeof(String)); //
            paramTable3.Columns.Add("CS_NAME", typeof(String)); //
            paramTable3.Columns.Add("VALUE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause3)
            {
                //if (!chk.Checked) continue;
                DataRow paramRow3 = paramTable3.NewRow();
                paramRow3["AS_NUM"] = layoutRow["AS_NUM"];
                paramRow3["WORK_SEQ"] = layoutRow["WORK_SEQ"];
                paramRow3["CS_CODE"] = chk.Tag.ToString();
                paramRow3["CS_NAME"] = chk.Text;
                paramRow3["VALUE"] = chk.EditValue;
                paramTable3.Rows.Add(paramRow3);
            }
            //근본
            DataTable paramTable4 = new DataTable("CAUSE4");
            paramTable4.Columns.Add("AS_NUM", typeof(String)); //  
            paramTable4.Columns.Add("WORK_SEQ", typeof(Int32)); //  
            paramTable4.Columns.Add("CS_CODE", typeof(String)); //
            paramTable4.Columns.Add("CS_NAME", typeof(String)); //
            paramTable4.Columns.Add("VALUE", typeof(String)); //
            foreach (CheckEdit chk in _chkCause4)
            {
                //if (!chk.Checked) continue;
                DataRow paramRow4 = paramTable4.NewRow();
                paramRow4["AS_NUM"] = layoutRow["AS_NUM"];
                paramRow4["WORK_SEQ"] = layoutRow["WORK_SEQ"];
                paramRow4["CS_CODE"] = chk.Tag.ToString();
                paramRow4["CS_NAME"] = chk.Text;
                paramRow4["VALUE"] = chk.EditValue;
                paramTable4.Rows.Add(paramRow4);
            }
            ////작업자
            //DataTable paramTableEmp = new DataTable("RQSTDT_WORKEMP");
            //paramTableEmp.Columns.Add("EMP_CODE", typeof(String)); //
            //foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
            //{
            //    DataRow paramRowWorkEmp = paramTableEmp.NewRow();
            //    paramRowWorkEmp["EMP_CODE"] = checkedKey.ToString();
            //    paramTableEmp.Rows.Add(paramRowWorkEmp);
            //}


            //DataTable paramTablePart = new DataTable("PART");
            //paramTablePart.Columns.Add("AS_NUM", typeof(String)); //  
            //paramTablePart.Columns.Add("WORK_SEQ", typeof(Int32)); //  
            //paramTablePart.Columns.Add("BOM_ID", typeof(String)); //
            //paramTablePart.Columns.Add("PARENT_ID", typeof(String)); //
            //paramTablePart.Columns.Add("PART_CODE", typeof(String)); //
            //paramTablePart.Columns.Add("PART_NAME", typeof(String)); //
            //paramTablePart.Columns.Add("MAT_SPEC", typeof(String)); //
            //paramTablePart.Columns.Add("MAT_TYPE", typeof(String)); //
            //paramTablePart.Columns.Add("PART_QTY", typeof(Int32)); //
            //paramTablePart.Columns.Add("ID", typeof(String)); //
            //paramTablePart.Columns.Add("P_ID", typeof(String)); //

            //DataRow[] partRows = acTreeList1.GetDataView().Table.Select();

            //foreach (DataRow dr in partRows)
            //{

            //    if (dr["BOM_ID"].ToString() == "" || dr["STATE"].ToString() == "MODI" || dr["STATE"].ToString() == "ADD")
            //    {
            //        DataRow paramRowPart = paramTablePart.NewRow();
            //        paramRowPart["AS_NUM"] = layoutRow["AS_NUM"];
            //        paramRowPart["WORK_SEQ"] = layoutRow["WORK_SEQ"];
            //        paramRowPart["BOM_ID"] = dr["BOM_ID"];
            //        paramRowPart["PARENT_ID"] = dr["PARENT_ID"];
            //        paramRowPart["PART_CODE"] = dr["PART_CODE"];
            //        paramRowPart["PART_NAME"] = dr["PART_NAME"];
            //        paramRowPart["MAT_TYPE"] = dr["MAT_TYPE"];
            //        paramRowPart["MAT_SPEC"] = dr["MAT_SPEC"];
            //        paramRowPart["PART_QTY"] = dr["PART_QTY"];
            //        paramRowPart["ID"] = dr["BOM_ID"];
            //        paramRowPart["P_ID"] = dr["PARENT_ID"];

            //        paramTablePart.Rows.Add(paramRowPart);
            //    }
            //}

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTable1);
            paramSet.Tables.Add(paramTable2);
            paramSet.Tables.Add(paramTable3);
            paramSet.Tables.Add(paramTable4);

            //paramSet.Tables.Add(paramTablePart);
            //paramSet.Tables.Add(paramTableEmp);

            return paramSet;
        }

        private void barBtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        

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