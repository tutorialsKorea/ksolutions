using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acPartForm : BaseMenuDialog
    {
        private string _VenCode;
        public string VenCode { get => _VenCode; set => _VenCode = value; }

        private string _Filter = string.Empty;
        public string Filter { get => _Filter; set => _Filter = value; }

        private string _mat_ltype = string.Empty;
        public string MAT_LTYPE { get => _mat_ltype; set => _mat_ltype = value; }

        private string _mat_mtype = string.Empty;
        public string MAT_MTYPE { get => _mat_mtype; set => _mat_mtype = value; }

        private string _is_main_part = string.Empty;
        public string IS_MAIN_PART { get => _is_main_part; set => _is_main_part = value; }

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

        public acPart.emMethodType ExecuteMethodType { get; set; }

        public acPart.emSelectType SelectType { get; set; }

        public acPartForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.SelectType == acPart.emSelectType.MULTI)
            {
                acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.OptionsSelection.MultiSelect = true;
                acGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("STD_PT_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("PART_ENAME", "부품명(영문)", "40235", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("PART_PRODTYPE", "품목제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");

            acGridView1.AddTextEdit("STK_QTY", "재고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView1.AddLookUpEdit("SPEC_TYPE", "규격입력형태", "42540", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S062");

            acGridView1.AddTextEdit("MAT_SPEC1", "제품규격", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_SPEC", "소재규격", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAT_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAT_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

            //acGridView1.AddCheckEdit("STK_MNG", "재고관리", "F0A4HGPZ", true, false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddTextEdit("STK_LOCATION", "보관위치", "35444KQ4", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("STK_COMPLETE", "완재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("STK_TURNING", "선삭재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("STK_TOTAL", "재고 합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

            acGridView1.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            //acGridView1.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C600");

            acGridView1.AddTextEdit("PART_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            (acLayoutControl1.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M014");
            //(acLayoutControl1.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M015");
            //(acLayoutControl1.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M016");
            (acLayoutControl1.GetEditor("PART_PRODTYPE").Editor as acLookupEdit).SetCode("M007");

            acGridView1.MouseDown += new MouseEventHandler(gvPart_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
        }

        protected override void OnShown(EventArgs e)
        {


            base.OnShown(e);
            
            //포커스
            acLayoutControl1.GetEditor("PART_LIKE").FocusEdit();

            (acLayoutControl1.GetEditor("VEN_CODE") as acVendor).Value = this._VenCode;


            (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).Value = this._mat_ltype;


            (acLayoutControl1.GetEditor("MAT_MTYPE") as acLookupEdit).Value = this._mat_mtype;


            if (this.ExecuteMethodType == acPart.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PART_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acPart.emMethodType.QUICK_FIND)
            {
                this.Search();
            }


        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }


        }
        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                //acPart ctrl = (acPart)base.ParentControl;

                if (this.ExecuteMethodType == acPart.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("PART_LIKE").Value = this.Parameter;

                }


            }

        }


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MAT_LTYPE":


                    (layout.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M015", newValue);
                    (layout.GetEditor("MAT_MTYPE").Editor as acLookupEdit).Value = null;

                    break;

                case "MAT_MTYPE":

                    (layout.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M016", newValue);
                    (layout.GetEditor("MAT_STYPE").Editor as acLookupEdit).Value = null;

                    break;

            }
        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }


        }

        void gvPart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                    this.acBarButtonItem2_ItemClick(null, null);

                }

            }
        }



        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            acPart editor = this.ParentControl as acPart;


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //부품 대분류
            paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //부품 중분류
            paramTable.Columns.Add("MAT_STYPE", typeof(String)); //부품 소분류
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //PART_CODE,NAME LIKE 검색
            paramTable.Columns.Add("PART_PRODTYPE", typeof(String)); //PART_PRODTYPE LIKE 검색
            paramTable.Columns.Add("PART_PRODTYPE_LIKE", typeof(String)); //PART_PRODTYPE LIKE 검색
            paramTable.Columns.Add("VEN_CODE", typeof(String)); //
            paramTable.Columns.Add("FILTER_LIKE", typeof(String)); //
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //

            paramTable.Columns.Add("IS_MAIN_PART", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = null;
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
            paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
            paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
            paramRow["FILTER_LIKE"] = this._Filter;

            if (_is_main_part == "1")
            {
                paramRow["IS_MAIN_PART"] = _is_main_part;
            }

            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CTRL","CONTROL_PART_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);


        }
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //검색
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                if (this.SelectType == acPart.emSelectType.MULTI)
                {
                    acGridView1.EndEditor();

                    DataRow[] selected = ((DataTable)acGridView1.GridControl.DataSource).Select("SEL = '1'");

                    if (selected.Length == 0)
                    {
                        DataRow dr = acGridView1.GetFocusedDataRow();

                        DataTable dt = dr.Table.Clone();

                        dt.ImportRow(dr);

                        this.OutputData = dt;

                    }
                    else
                    {
                        this.OutputData = selected.CopyToDataTable();
                    }
                    

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        this.OutputData = focusRow.NewTable();

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}