using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;
using CodeHelperManager;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace SAN
{
    public sealed partial class SAN04A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public SAN04A_M0A()
        {
            InitializeComponent();
        }

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        private enum emOption
        {
            //계획일정
            PLN_TIME,

            //지시상태
            WO_STATE,

            //도형
            WO_FIG

        }

        private emOption _viewOpt = emOption.PLN_TIME;

        public override void BarCodeScanInput(string barcode)
        {


        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();

        }

        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);

        }


        public override void MenuLink(object data)
        {
 
        }

        public override void MenuInit()
        {
            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", acInfo.RefData, "RQSTDT", "RSLTDT");

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;            
            acGridView1.AddTextEdit("AS_NO", "접수번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("AS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddDateEdit("ACCEPT_DATE", "접수일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("REQ_DATE", "처리요구일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("PROD_NAME", "제품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("AS_DATE", "처리완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "고객사", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckedComboBoxEdit("AS_CHECK", "접수구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A001");
            acGridView1.AddMemoEdit("AS_CONTENTS", "접수구분(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddMemoEdit("PROD_CONTENTS", "제품이력", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddCheckedComboBoxEdit("GUBUN_CHECK", "부적합구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A002");            
            acGridView1.AddCheckedComboBoxEdit("CAUSE_CHECK", "부적합원인", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "A003");
            acGridView1.AddMemoEdit("CAUSE_CONTENTS", "부적합원인(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("WORK_CHECK", "조치내용", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "A004");
            acGridView1.AddMemoEdit("WORK_CONTENTS", "조치내용(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("RESULT_CHECK", "조치결과", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A005");
            acGridView1.AddMemoEdit("RESULT_CONTENTS", "조치결과(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("CONFIRM_DATE", "확인일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("WORK_DATE", "조치일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("OCCUR_DATE", "발생일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddMemoEdit("PLAN_CONTENTS", "향후대책", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("LAST_CHECK", "최종의견", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A006");
            acGridView1.AddMemoEdit("LAST_CONTENTS", "최종의견(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            //acGridView1.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.Columns["APP_EMP4"].Fixed = FixedStyle.Right;
            acGridView1.Columns["APP_EMP3"].Fixed = FixedStyle.Right;
            acGridView1.Columns["APP_EMP2"].Fixed = FixedStyle.Right;
            acGridView1.Columns["APP_EMP1"].Fixed = FixedStyle.Right;

            acGridView1.KeyColumn = new string[] { "AS_NO" };


            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView2.AddTextEdit("AS_NO", "접수번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEmp("AS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView2.AddDateEdit("ACCEPT_DATE", "접수일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("REQ_DATE", "처리요구일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("PROD_NAME", "제품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("AS_DATE", "처리완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CVND_NAME", "고객사", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddCheckedComboBoxEdit("AS_CHECK", "접수구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A001");
            acGridView2.AddMemoEdit("AS_CONTENTS", "접수구분(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView2.AddMemoEdit("PROD_CONTENTS", "제품이력", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView2.AddCheckedComboBoxEdit("GUBUN_CHECK", "부적합구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A002");
            acGridView2.AddCheckedComboBoxEdit("CAUSE_CHECK", "부적합원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A003");
            acGridView2.AddMemoEdit("CAUSE_CONTENTS", "부적합원인(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddCheckedComboBoxEdit("WORK_CHECK", "조치내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A004");
            acGridView2.AddMemoEdit("WORK_CONTENTS", "조치내용(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddCheckedComboBoxEdit("RESULT_CHECK", "조치결과", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A005");
            acGridView2.AddMemoEdit("RESULT_CONTENTS", "조치결과(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddDateEdit("CONFIRM_DATE", "확인일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("WORK_DATE", "조치일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("OCCUR_DATE", "발생일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddMemoEdit("PLAN_CONTENTS", "향후대책", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView2.AddCheckedComboBoxEdit("LAST_CHECK", "최종의견", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A006");
            acGridView2.AddMemoEdit("LAST_CONTENTS", "최종의견(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            //acGridView2.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.Columns["APP_EMP4"].Fixed = FixedStyle.Right;
            acGridView2.Columns["APP_EMP3"].Fixed = FixedStyle.Right;
            acGridView2.Columns["APP_EMP2"].Fixed = FixedStyle.Right;
            acGridView2.Columns["APP_EMP1"].Fixed = FixedStyle.Right;

            acGridView2.KeyColumn = new string[] { "AS_NO" };


            acGridView3.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView3.AddTextEdit("AS_NO", "접수번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEmp("AS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView3.AddDateEdit("ACCEPT_DATE", "접수일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddDateEdit("REQ_DATE", "처리요구일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("PROD_NAME", "제품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("AS_DATE", "처리완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView3.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CVND_NAME", "고객사", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddCheckedComboBoxEdit("AS_CHECK", "접수구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A001");
            acGridView3.AddMemoEdit("AS_CONTENTS", "접수구분(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView3.AddMemoEdit("PROD_CONTENTS", "제품이력", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView3.AddCheckedComboBoxEdit("GUBUN_CHECK", "부적합구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A002");
            acGridView3.AddCheckedComboBoxEdit("CAUSE_CHECK", "부적합원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A003");
            acGridView3.AddMemoEdit("CAUSE_CONTENTS", "부적합원인(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView3.AddCheckedComboBoxEdit("WORK_CHECK", "조치내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A004");
            acGridView3.AddMemoEdit("WORK_CONTENTS", "조치내용(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView3.AddCheckedComboBoxEdit("RESULT_CHECK", "조치결과", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A005");
            acGridView3.AddMemoEdit("RESULT_CONTENTS", "조치결과(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView3.AddDateEdit("CONFIRM_DATE", "확인일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddDateEdit("WORK_DATE", "조치일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddDateEdit("OCCUR_DATE", "발생일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddMemoEdit("PLAN_CONTENTS", "향후대책", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView3.AddCheckedComboBoxEdit("LAST_CHECK", "최종의견", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A006");
            acGridView3.AddMemoEdit("LAST_CONTENTS", "최종의견(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            //acGridView3.AddLookUpEmp("APP_EMP1", "승인자1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP1", "승인자1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG1", "승인자1상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP2", "승인자2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP2", "승인자2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG2", "승인자2상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP3", "승인자3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP3", "승인자3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG3", "승인자3상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEmp("APP_EMP4", "승인자4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("APP_EMP4", "승인자4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", resultSet.Tables["RSLTDT"]);
            acGridView3.AddTextEdit("APP_EMP_FLAG4", "승인자4상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.Columns["APP_EMP4"].Fixed = FixedStyle.Right;
            acGridView3.Columns["APP_EMP3"].Fixed = FixedStyle.Right;
            acGridView3.Columns["APP_EMP2"].Fixed = FixedStyle.Right;
            acGridView3.Columns["APP_EMP1"].Fixed = FixedStyle.Right;

            acGridView3.KeyColumn = new string[] { "AS_NO" };

            acCheckedComboBoxEdit1.AddItem("접수일", false, "", "ACCEPT_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("처리일", false, "", "AS_DATE", true, false);

            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.acGridView1.CustomDrawCell += acGridView_CustomDrawCell;
            this.acGridView2.CustomDrawCell += acGridView_CustomDrawCell;
            this.acGridView3.CustomDrawCell += acGridView_CustomDrawCell;

            acGridView1.RowCountChanged += acGridView_RowCountChanged;
            acGridView2.RowCountChanged += acGridView_RowCountChanged;
            acGridView3.RowCountChanged += acGridView_RowCountChanged;

            btnApproval.Enabled = false;
            btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnCancel.Enabled = false;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            btnReject.Enabled = false;
            btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            btnRejectCancel.Enabled = false;
            btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

            _OK = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
            _PROGRESS = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
            _DENY = acInfo.SysConfig.GetSysConfigByServer("APP_STATE_DENY").toColor();

            base.MenuInit();
        }
        private Color _PROGRESS;
        private Color _OK;
        private Color _DENY;

        private void acGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            acGridView gridView = sender as acGridView;

            if (e.RowHandle < 0) return;

            string app1 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
            string app2 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
            string app3 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
            string app4 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

            if (e.Column.FieldName.StartsWith("APP_EMP"))
            {
                if (e.Column.FieldName.IndexOf("1") > -1)
                {
                    //if (app1 != "0")
                    //{
                    e.Appearance.BackColor = GetStatColor(app1);
                    e.Appearance.ForeColor = GetStatFontColor(app1);
                    //}
                }
                else if (e.Column.FieldName.IndexOf("2") > -1)
                {
                    //if (app2 != "0")
                    //{
                    e.Appearance.BackColor = GetStatColor(app2);
                    e.Appearance.ForeColor = GetStatFontColor(app2);
                    //}
                }
                else if (e.Column.FieldName.IndexOf("3") > -1)
                {
                    //if (app3 != "0")
                    //{
                    e.Appearance.BackColor = GetStatColor(app3);
                    e.Appearance.ForeColor = GetStatFontColor(app3);
                    //}
                }
                else if (e.Column.FieldName.IndexOf("4") > -1)
                {
                    //if (app4 != "0")
                    //{
                    e.Appearance.BackColor = GetStatColor(app4);
                    e.Appearance.ForeColor = GetStatFontColor(app4);
                    //}
                }
            }

            #region
            //acGridView currentView = (sender as acGridView);
            //if (e.Column.FieldName.Contains("APP_EMP"))
            //{
            //    DataRow row = currentView.GetDataRow(e.RowHandle);

            //    // 승인완료
            //    if ((!e.CellValue.isNullOrEmpty() && row[e.Column.FieldName + "_OK"].ToString() == "1"))
            //    {
            //        e.Appearance.BackColor = _OK;
            //        e.Appearance.ForeColor = Color.Black;

            //    }
            //    //승인대기 상태
            //    else if ((!e.CellValue.isNullOrEmpty() && row[e.Column.FieldName + "_OK"].ToString() == "0"))
            //    {
            //        e.Appearance.BackColor = _PROGRESS;
            //        e.Appearance.ForeColor = Color.Black;
            //    }

            //}
            #endregion
        }

        Color GetStatColor(string flag)
        {
            Color color = Color.Transparent;

            switch (flag)
            {
                case "0":
                    color = _PROGRESS;
                    break;

                case "1":
                    color = _OK;
                    break;

                case "2":
                    color = _DENY;
                    break;
            }

            return color;
        }

        Color GetStatFontColor(string flag)
        {
            Color color = Color.Black;

            switch (flag)
            {
                case "0":
                    color = Color.Black;
                    break;

                case "1":
                    color = Color.Black;
                    break;

                case "2":
                    color = Color.Black;
                    break;
            }

            return color;
        }

        private void acGridView_RowCountChanged(object sender, EventArgs e)
        {
            acGridView gridView = sender as acGridView;

            string tabName = acTabControl1.GetSelectedContainerName();

            bool isEnabled = false;

            if (gridView.RowCount > 0)
            {
                isEnabled = true;
            }
            else
            {
                isEnabled = false;
            }

            switch (tabName)
            {
                case "REQ_APP":
                    btnApproval.Enabled = isEnabled;
                    btnReject.Enabled = isEnabled;
                    break;

                case "APP_CANCEL":
                    btnCancel.Enabled = isEnabled;
                    break;

                case "REJ_CANCEL":
                    btnRejectCancel.Enabled = isEnabled;
                    break;
            }
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tabControl = sender as acTabControl;
            DataRow focusRow = null;
            switch (tabControl.GetSelectedContainerName())
            {
                case "REQ_APP": //신청 승인/반려

                    //btnApproval.Enabled = true;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = true;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView1.GetFocusedDataRow();

                    break;

                case "APP_CANCEL": //승인취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = true;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = false;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    focusRow = acGridView2.GetFocusedDataRow();

                    break;

                case "REJ_CANCEL": //반려취소

                    //btnApproval.Enabled = false;
                    btnApproval.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnCancel.Enabled = false;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnReject.Enabled = false;
                    btnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    //btnRejectCancel.Enabled = true;
                    btnRejectCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    focusRow = acGridView3.GetFocusedDataRow();

                    break;
            }
        }


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

            }

        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "ACCEPT_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }
            base.ChildContainerInit(sender);
        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }


        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("AS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_ACCEPT_DATE", typeof(String)); //접수 시작일
            paramTable.Columns.Add("E_ACCEPT_DATE", typeof(String)); //접수 종료일
            paramTable.Columns.Add("S_AS_DATE", typeof(String)); //완료 시작일
            paramTable.Columns.Add("E_AS_DATE", typeof(String)); //완료 종료일

            paramTable.Columns.Add("SER_TYPE", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["AS_EMP"] = layoutRow["AS_EMP"];

            paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
            paramRow["REG_EMP"] = acInfo.UserID;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ACCEPT_DATE":
                        //등록일
                        paramRow["S_ACCEPT_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ACCEPT_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "AS_DATE":
                        //수주일
                        paramRow["S_AS_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_AS_DATE"] = layoutRow["E_DATE"];

                        break;                    
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "SAN04A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                switch (e.result.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "REQ_APP":
                        acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView1.BestFitColumns();
                        break;

                    case "APP_CANCEL":
                        acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView2.BestFitColumns();
                        break;

                    case "REJ_CANCEL":
                        acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                        acGridView3.BestFitColumns();
                        break;
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnApproval_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;


                if (acMessageBox.Show(this, "정말 승인 하시겠습니까?", "TB43FSY3", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AS_NO", typeof(String)); //                                                                 //            
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];
                    paramRow["APP_FLAG"] = "1";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중승인
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];
                        paramRow["APP_FLAG"] = "1";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN04A_UPD", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;


                if (acMessageBox.Show(this, "정말 승인취소 하시겠습니까?", "TB43FSY3", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView2.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AS_NO", typeof(String)); //                
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일승인취소

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중승인취소
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN04A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD2,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }

                acAlert.Show(this, "승인취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnReject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //반려
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("AS_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];
                    paramRow["APP_FLAG"] = "2";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];
                        paramRow["APP_FLAG"] = "2";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN04A_UPD3", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD3,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                acAlert.Show(this, "반려되었습니다.", acAlertForm.enmType.Error);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnRejectCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //반려취소
            try
            {
                acGridView3.EndEditor();

                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show(this, "정말 반려취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selectedView = acGridView3.GetDataSourceView("SEL = '1'");
                DataRow[] selected = acGridView3.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("AS_NO", typeof(String));
                paramTable.Columns.Add("APP_FLAG", typeof(String));
                paramTable.Columns.Add("SER_TYPE", typeof(String));

                if (selected.Length == 0)
                {
                    //단일반려

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];
                    paramRow["APP_FLAG"] = "0";
                    paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중반려
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];
                        paramRow["APP_FLAG"] = "0";
                        paramRow["SER_TYPE"] = acTabControl1.GetSelectedContainerName();
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "SAN04A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                QuickUPD4,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUPD4(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }

                acAlert.Show(this, "반려취소되었습니다.", acAlertForm.enmType.Warning);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
