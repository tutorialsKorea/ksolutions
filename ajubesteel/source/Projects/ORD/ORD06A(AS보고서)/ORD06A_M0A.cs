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

namespace ORD
{
    public sealed partial class ORD06A_M0A : BaseMenu
    {

        private GridHitInfo _downHitInfo = null;

        public ORD06A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;            
            acGridView1.AddTextEdit("AS_NO", "접수번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("AS_STATE", "처리상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A010");

            acGridView1.AddLookUpEmp("AS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddDateEdit("ACCEPT_DATE", "접수일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("REQ_DATE", "처리요구일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("PROD_NAME", "제품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("AS_DATE", "처리완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("APP_ORG_NAME", "승인자그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "고객사", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckedComboBoxEdit("AS_CHECK", "접수구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A001");
            acGridView1.AddMemoEdit("AS_CONTENTS", "접수구분(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddMemoEdit("PROD_CONTENTS", "제품이력", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            acGridView1.AddCheckedComboBoxEdit("GUBUN_CHECK", "부적합구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A002");            
            acGridView1.AddCheckedComboBoxEdit("CAUSE_CHECK", "부적합원인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A003");
            acGridView1.AddMemoEdit("CAUSE_CONTENTS", "부적합원인(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("WORK_CHECK", "조치내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A004");
            acGridView1.AddMemoEdit("WORK_CONTENTS", "조치내용(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("RESULT_CHECK", "조치결과", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A005");
            acGridView1.AddMemoEdit("RESULT_CONTENTS", "조치결과(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("CONFIRM_DATE", "확인일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("WORK_DATE", "조치일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("OCCUR_DATE", "발생일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddMemoEdit("PLAN_CONTENTS", "향후대책", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddCheckedComboBoxEdit("LAST_CHECK", "최종의견", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "A006");
            acGridView1.AddMemoEdit("LAST_CONTENTS", "최종의견(비고)", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "AS_NO" };



            acCheckedComboBoxEdit1.AddItem("접수일", false, "", "ACCEPT_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("처리일", false, "", "AS_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);            
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);


            this.acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            //this.acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            this.acGridView1.RowCellStyle += acGridView1_RowCellStyle;
            this.acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);
            this.acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            this.acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            base.MenuInit();
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //수주 편집기 열기

                    this.btnOpen_ItemClick(null, null);
                }

            }
        }

        private void acGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            DataRow dataRow = acGridView1.GetDataRow(e.RowHandle);
            //if(dataRow["SHIP_QTY"].toInt() > 0)
            //    e.Appearance.BackColor = Color.Yellow;
        }


        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //try
            //{
            //    if (sender is acGridView view)
            //    {
            //        DataRow row = view.GetDataRow(e.RowHandle);
            //        if (row == null)
            //            return;

            //        if (row["PROD_STATE"].ToString() == "5")
            //        {
            //            e.Appearance.BackColor = Color.Orange;
            //            e.Appearance.ForeColor = Color.Black;
            //        }

            //        //if (row["SHIP_QTY"].toInt() > 0)
            //        //{
            //        //    e.Appearance.BackColor = Color.Yellow;
            //        //    e.Appearance.ForeColor = Color.Black;
            //        //}
            //    }
            //}
            //catch
            //{

            //}
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", "AS_NO", row["AS_NO"]);

                base.ChildFormRemove(formKey);
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
            

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["AS_EMP"] = layoutRow["AS_EMP"];


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
             "ORD06A_SER", paramSet, "RQSTDT", "RSLTDT",
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

        public override void DataRefresh(object data)
        {
            if (data.EqualsEx("PROD"))
            {
                if (base.IsData(data))
                {
                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.REFRESH,
                 "ORD06A_SER", refreshSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);

                }

            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == 200027)
            {
                //부품이 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == 200059)
            {
                //세트외주 구매정보가 존재하여 삭제할수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm2", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false,  this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            }
            else if (ex.ErrNumber == 200083)
            {
                //금형상태가 유효하지않음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm3", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                if (ex.ParameterData == null)
                {
                    acMessageBox.Show(this, ex);

                    return;
                }

                foreach (DataRow row in ex.ParameterData.Rows)
                {
                    row["CHECK_PROD_STATE"] = acInfo.StdCodes.GetNameByCodes("S025", row["CHECK_PROD_STATE"]);
                }

                frm.ParentControl = this;

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddLookUpEdit("NOW_PROD_STATE", "금형상태", "WJB3HAFK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");

                frm.View.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("CHECK_PROD_STATE", "유효 금형상태", "Y91G7XDQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();

            }
            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                //데이터 갱신
                acMessageBox.Show(this, ex);

                this.DataRefresh("ITEM");
            }
            else if (ex.ErrNumber == 200202)
            {
                acMessageBox.Show("품목이 존재하여 삭제할 수 없습니다. \n품목을 먼저 삭제하세요. ", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200203)
            {
                acMessageBox.Show("대기 상태인 수주만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else if (ex.ErrNumber == 200204)
            {
                acMessageBox.Show("대기 상태인 품목만 삭제 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }




        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //base.SetData("PROD", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.SetOldFocusRowHandle(true);

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        /// <summary>
        /// 출하 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

            if (selectedRows.Length == 0)
            {
                acMessageBox.Show("선택된 데이터가 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }


            DataTable paramTable1 = new DataTable("RQSTDT");
            paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable1.Columns.Add("SHIP_ID", typeof(String)); //
            paramTable1.Columns.Add("DEL_EMP", typeof(String)); //

            foreach (DataRow dr in selectedRows)
            {
                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["SHIP_ID"] = dr["SHIP_ID"];
                paramRow1["DEL_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable1);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.SAVE,
            "ORD04A_CANCEL", paramSet, "RQSTDT", "RSLTDT",
            QuickCancel,
            QuickException);
        }

        void QuickCancel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

                this.acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!base.ChildFormContains("NEW_AS"))
            {
                ORD06A_D0A frm = new ORD06A_D0A(acGridView1, "NEW_AS");

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW_AS", frm);

                frm.Show(this);


            }
            else
            {
                base.ChildFormFocus("NEW_PROD");
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AS_NO", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];                    
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    foreach(DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];                        
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD06A_DEL", paramSet, "RQSTDT", "RSLTDT",
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
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();


                string formKey = string.Format("{0},{1}", "AS", focusRow["AS_NO"]);

                if (!base.ChildFormContains(formKey))
                {

                    ORD06A_D0A frm = new ORD06A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus(formKey);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnRequest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();


                DataRow[] selected = acGridView1.GetSelectedDataRows();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("AS_NO", typeof(String)); //                

                if (selected.Length == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["AS_NO"] = focusRow["AS_NO"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    foreach (DataRow row in selected)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["REG_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["AS_NO"] = row["AS_NO"];
                        paramTable.Rows.Add(paramRow);

                    }


                }


                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD06A_UPD", paramSet, "RQSTDT", "RSLTDT",
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

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row,false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}
