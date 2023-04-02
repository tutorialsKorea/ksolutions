using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using BizManager;

namespace STD
{
    public sealed partial class STD13A_M0A : BaseMenu
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

        public STD13A_M0A()
        {
            InitializeComponent();
        }





        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public override void MenuInit()
        {

    

            acTreeList1.KeyFieldName = "ORG_CODE";
            acTreeList1.ParentFieldName = "ORG_PARENT";

            acTreeList1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acTreeList.emCheckEditDataType._STRING);

            acTreeList1.AddTextEdit("ORG_CODE", "부서코드", "40225", true , DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ORG_NAME", "부서명", "40223", true , DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ORG_LEADER", "부서관리자코드", "CXFRELKS", true , DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ORG_LEADER_NAME", "부서관리자명", "5UVPVQL3", true , DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("CC_EMP", "근태참조자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ORG_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddCheckEdit("ORG_CLASS", "영업소 여부", "AB_L0041", false, false, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddCheckEdit("IS_DEV", "개발담당 등록 여부", "", false, false, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddCheckEdit("IS_SECRET", "영업기밀 허용 여부", "", false, false, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddCheckEdit("IS_ADMIN", "수주 관리 여부", "", false, false, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emDateMask.LONG_DATE);

            acTreeList1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);


            acTreeList1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emDateMask.LONG_DATE);


            acTreeList1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);


            acTreeList1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);




            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center,false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "사원명", "40266", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");
            acGridView1.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            acGridView1.AddTextEdit("CPROC_CODE", "임률코드", "0BXLGNK0", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CPROC_NAME", "임률명", "PQB42PSL", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("USRGRP_CODE", "사용자 그룹코드", "42509", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("USRGRP_NAME", "사용자 그룹명", "42510", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MOBILE_PHONE", "휴대폰", "0SRN1JQ9", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMAIL", "E-Mail", "40790", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("HIRE_DATE", "입사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("ACCOUNT_DATE", "첫회계일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("RETIRE_DATE", "퇴사일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("BIRTH_DATE", "생년월일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddDateEdit("TARGET_DATE", "대상자(일)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView1.AddDateEdit("ENFOR_DATE", "시행일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddCheckEdit("IS_PROC", "가공유무", "", false, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("IS_CAM", "CAM가능", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddCheckEdit("IS_DAILY", "업무현황 관리자 여부", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("WORK_LOC", "근무처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E001");
            acGridView1.AddLookUpEdit("PAY_CONTRACT", "급여계약", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E002");
            acGridView1.AddLookUpEdit("WORK_CONTRACT", "근로계약", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E003");
            acGridView1.AddLookUpEdit("EMP_NATIONAL", "국적", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E004");

            acGridView1.AddPictrue("SIGN_IMG", "이미지", "", false, DevExpress.Utils.HorzAlignment.Center, false, false);

            acGridView1.AddTextEdit("EMP_REG_NUMBER", "주민번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.REG_NUMBER);
            acGridView1.AddTextEdit("EMP_ADDRESS", "주소", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("LEADER_EMP_CODE", "팀장코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("LEADER_EMP_NAME", "팀장", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("IS_VND", "거래처 사용자", "P58SD6V6", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddTextEdit("EMP_VND", "거래처", "OY7HV0XN", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("IF_EMP_CODE", "IF 코드", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);




            acGridView1.KeyColumn = new string[] { "EMP_CODE" };


            acTreeList1.MouseDown += new MouseEventHandler(acTreeList1_MouseDown);

            acTreeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(acTreeList1_FocusedNodeChanged);


            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


            this.Load += STD13A_M0A_Load;
            base.MenuInit();
        }

        void STD13A_M0A_Load(object sender, EventArgs e)
        {
            this.Search();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                //연관된 폼 삭제

                List<object> deleteList = new List<object>();

                foreach (KeyValuePair<object, BaseMenuDialog> relationForm in this._ChildForm)
                {

                    if (relationForm.Value is STD13A_D1A)
                    {
                        STD13A_D1A frm = relationForm.Value as STD13A_D1A;

                        DataRow masterRow = (frm.MasterData as DataRowView).Row;

                        if (masterRow.RowState == DataRowState.Detached)
                        {
                            deleteList.Add(relationForm.Key);

                        }
                    }


                }

                foreach (object obj in deleteList)
                {
                    this._ChildForm[obj].Dispose();

                    this._ChildForm.Remove(obj);

                }
            }
        }



        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //사원 편집기 열기

                    this.acBarButtonItem6_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if( e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.MenuType == GridMenuType.User)
                {
                   
                    acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                       
                        acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        
                        acBarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    }
                }


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acTreeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
           
            this.GetDetail();
        }

        void GetDetail()
        {
            //부서 인원 조회
            DataRowView focusRowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);

            if (focusRowView != null)
            {

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_LIKE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = focusRowView["ORG_CODE"];
                paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "STD13A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickDetail,
                QuickException);
            }
            else
            {
                acGridView1.ClearRow();
            }

        }
        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitInfo = acTreeList1.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    //부서 편집기 열기

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
            else
            {

                if (e.Button == MouseButtons.Right)
                {

                    if (hitInfo.HitInfoType == HitInfoType.Empty)
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                    }
                    else
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


                    }

                    if (hitInfo.HitInfoType != HitInfoType.Column)
                    {
                        if (hitInfo.Node != null)
                        {
                            acTreeList1.FocusedNode = hitInfo.Node;
                        }


                        popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));

                    }
                }

            }


        }

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        public override bool MenuDestory(object sender)
        {
            foreach (object key in _ChildForm.Keys)
            {
                _ChildForm[key].Dispose();

            }

            return true;

        }

        public override void MenuGotFocus()
        {

            foreach (object key in _ChildForm.Keys)
            {

                if (_ChildForm[key].IsFixedWindow == false)
                {
                    _ChildForm[key].Show();
                }

            }

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            foreach (object key in _ChildForm.Keys)
            {

                if (_ChildForm[key].IsFixedWindow == false)
                {
                    _ChildForm[key].Hide();
                }

            }

            base.MenuLostFocus();
        }



        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //갱신
            try
            {

                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD13A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable org = e.result.Tables["RSLTDT"].Copy();


                DataRow dr = org.NewRow();
                dr["ORG_CODE"] = DBNull.Value;
                dr["ORG_NAME"] = acInfo.Resource.GetString("전체", "40583");


                org.Rows.InsertAt(dr, 0);

                DataRow[] rows = org.Select("ORG_PARENT = '' OR ORG_PARENT IS NULL");

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["ORG_PARENT"] = DBNull.Value;
                }
              

                acTreeList1.DataSource = org;

                acTreeList1.ExpandAll();

                //조회 메뉴로그 
                base.SetLog(e.executeType, org.Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz,  BizManager.BizException ex)
        {

            if (ex.ErrNumber == 200012)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Parent.Text, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERDEL"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }



        private Dictionary<object, BaseMenuDialog> _ChildForm = new Dictionary<object, BaseMenuDialog>();

        private void AddOrg()
        {
                        //새로만들기 부서 편집기
            try
            {
                if (!_ChildForm.ContainsKey("NEW"))
                {
                    STD13A_D0A frm = new STD13A_D0A(this, acTreeList1, "NEW");

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    _ChildForm.Add("NEW", frm);

                    frm.FormClosed += new FormClosedEventHandler(STD13A_ChildForm_FormClosed);

                    frm.Show(this);


                }
                else
                {

                    _ChildForm["NEW"].Focus();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddOrg();
        }

        private void EditOrg()
        {
            //부서 편집기 열기
            try
            {
                DataRowView focusRowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);

                if (focusRowView == null)
                {
                    return;
                }

                if (!_ChildForm.ContainsKey(focusRowView.Row))
                {

                    STD13A_D0A frm = new STD13A_D0A(this, acTreeList1, focusRowView.Row);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    _ChildForm.Add(focusRowView.Row, frm);


                    frm.FormClosed += new FormClosedEventHandler(STD13A_ChildForm_FormClosed);

                    frm.Show(this);
                }
                else
                {

                    _ChildForm[focusRowView.Row].Focus();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditOrg();
        }

        
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        
            //부서 삭제

            try
            {
                acTreeList1.EndEditor();

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataView selected = acTreeList1.GetDataView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //
                paramTable.Columns.Add("OVERDEL", typeof(String)); //

                if (selected.Count == 0)
                {

                    DataRow focusRow = ((DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode)).Row;


                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ORG_CODE"] = focusRow["ORG_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;
                    paramRow["OVERDEL"] = "0";

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();

                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["ORG_CODE"] = selected[i]["ORG_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;
                        paramRow["OVERDEL"] = "0";

                        paramTable.Rows.Add(paramRow);
                    }

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD13A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }


        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {

                    acTreeList1.DeleteMappingRow(row);

                    //링크된 자식창 삭제

                    if (_ChildForm.ContainsKey(row))
                    {
                        _ChildForm[row].Dispose();

                        _ChildForm.Remove(row);
                    }
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void STD13A_ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is STD13A_D0A)
            {
                STD13A_D0A frm = sender as STD13A_D0A;

                _ChildForm.Remove(frm.LinkData);

                
            }
            else if (sender is STD13A_D1A)
            {
                STD13A_D1A frm = sender as STD13A_D1A;

                _ChildForm.Remove(frm.LinkData);

                
            }
        }

        private void AddEmp()
        {
            //사원편집기 새로만들기
            try
            {
                if (!_ChildForm.ContainsKey("NEW"))
                {
                    STD13A_D1A frm = new STD13A_D1A(acTreeList1, acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode), acGridView1, "NEW");

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    _ChildForm.Add("NEW", frm);

                    frm.FormClosed += new FormClosedEventHandler(STD13A_ChildForm_FormClosed);

                    frm.Show(this);


                }
                else
                {

                    _ChildForm["NEW"].Focus();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddEmp();
        }

        private void EditEmp()
        {
            //사원편집기 열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();



                if (focusRow == null)
                {
                    return;
                }

                if (!_ChildForm.ContainsKey(focusRow))
                {

                    STD13A_D1A frm = new STD13A_D1A(acTreeList1, acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode), acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    _ChildForm.Add(focusRow, frm);

                    frm.FormClosed += new FormClosedEventHandler(STD13A_ChildForm_FormClosed);

                    frm.Show(this);
                }
                else
                {

                    _ChildForm[focusRow].Focus();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditEmp();
        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //사원 삭제
            try
            {

                acGridView1.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                if (selected.Count == 0)
                {

                    //단일선택

                    DataRow focusRow = acGridView1.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;


                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중선택
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = selected[i]["EMP_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD13A_DEL2", paramSet, "RQSTDT", "",
                QuickDEL2,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }
        void QuickDEL2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //링크된 자식창 삭제
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {

                    acGridView1.DeleteMappingRow(row);


                    if (_ChildForm.ContainsKey(row))
                    {
                        _ChildForm[row].Dispose();

                        _ChildForm.Remove(row);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //비밀번호 초기화
            try
            {

                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 초기화 하시겠습니까?", "T20NZ3XF", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //


                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                if (selected.Count == 0)
                {

                    //단일선택

                    DataRow focusRow = acGridView1.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = focusRow["EMP_CODE"];


                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중선택
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = selected[i]["EMP_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "STD13A_UPD", paramSet, "RQSTDT", "",
                QuickProcess,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
        void QuickProcess(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.SetValue("SEL", "0");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD13A_D2A frm = new STD13A_D2A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barAddOrg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddOrg();
        }

        private void barEditOrg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditOrg();
        }

        private void barEditEmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditEmp();
        }

        private void barAddEmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddEmp();
        }

    }
}