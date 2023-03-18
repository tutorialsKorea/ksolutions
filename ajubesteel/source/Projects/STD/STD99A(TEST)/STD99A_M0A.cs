using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using BizManager;


namespace STD
{
    public sealed partial class STD99A_M0A : BaseMenu
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

        public STD99A_M0A()
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

            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("USRGRP_CODE", "사용자 그룹코드", "42509", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("USRGRP_NAME", "사용자 그룹명", "42510", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "USRGRP_CODE" };


            acTreeList1.KeyFieldName = "MENU_CODE";
            acTreeList1.ParentFieldName = "MENU_PARENT";

            acTreeList1.AddPictrue("ICON", "", "", false , DevExpress.Utils.HorzAlignment.Center, false, true);

            acTreeList1.AddTextEdit("MENU_NAME", "메뉴명", "D6UJPZ3J", true , DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList1.AddLookUpEdit("ACC_LEVEL", "권한", "40075", true , DevExpress.Utils.HorzAlignment.Center, true, true, "S003", false);

            acTreeList1.AddCheckEdit("IS_DEFAULT_MENU", "기본메뉴 여부", "I2UQZADU", true, true, true, acTreeList.emCheckEditDataType._BYTE);


            acTreeList1.AddTextEdit("SUM", "계 테스트", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.NUMBER);

            acBarButtonItem5.Caption = acInfo.StdCodes.GetNameByCode("S003", "1");
            acBarButtonItem6.Caption = acInfo.StdCodes.GetNameByCode("S003", "2");

            //이벤트 설정

            acTreeList1.MouseDown += new MouseEventHandler(acTreeList1_MouseDown);

            acTreeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(acTreeList1_CellValueChanging);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            base.MenuInit();
        }

        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {

            TreeListHitInfo hitInfo = acTreeList1.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right)
            {

                if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                {

                    popupMenu2.ShowPopup(acTreeList1.PointToScreen(e.Location));

                }

            }


        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["USRGRP_CODE"]);
            }
        }

        void acTreeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            base.MenuStatus = emMenuStatus.WORK;
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //사용자 그룹 편집기 열기

                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void GetDetail()
        {


            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("LANG", typeof(String));
                paramTable.Columns.Add("RES_LANG", typeof(String));
                paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //사용자 그룹 코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LANG"] = acInfo.Lang;
                paramRow["RES_LANG"] = acInfo.Lang;
                paramRow["USRGRP_CODE"] = focusRow["USRGRP_CODE"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "STD20A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);

            }
            else
            {

                acTreeList1.ClearNodes();

                acTreeList1.Enabled = false;
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            this.GetDetail();

        }
        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                base.MenuStatus = emMenuStatus.NONE;


                e.result.Tables["RSLTDT"].Columns.Add("SUM", typeof(int));

                int i = 0;
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    row["SUM"] = i;
                    i++;
                }

                DataView view = new DataView(e.result.Tables["RSLTDT"]);

                view.Sort = "MENU_SEQ ASC";


                acTreeList1.Enabled = true;

                acTreeList1.DataSource = view.ToTable();


                acTreeList1.ExpandAll();

                acTreeList1.BestFitColumns(true);
                //acTreeList1.

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        public override bool MenuDestory(object sender)
        {

            if (base.MenuStatus == emMenuStatus.WORK)
            {
                if (acMessageBox.Show(this,"수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?", "AEIR4MG6", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return false;
                }

            }


            base.MenuDestory(sender);

            return true;

        }

        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }

        void Search()
        {
            //조회

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("USRGRP_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["USRGRP_LIKE"] = layoutRow["USRGRP_LIKE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD20A_SER", paramSet, "RQSTDT", "RSLTDT",
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
            if (ex.ErrNumber == 200011)
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


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);



                base.MenuStatus = emMenuStatus.NONE;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acTreeList1.CloseEditor();

                acTreeList1.EndCurrentEdit();

                DataRow masterRow = acGridView1.GetFocusedDataRow();

                if (masterRow != null)
                {
                    DataTable accLevelData = (DataTable)acTreeList1.DataSource;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //
                    paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                    paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                    paramTable.Columns.Add("IS_DEFAULT_MENU", typeof(Byte)); //


                    foreach (DataRow accRow in accLevelData.Rows)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["USRGRP_CODE"] = masterRow["USRGRP_CODE"];
                        paramRow["MENU_CODE"] = accRow["MENU_CODE"];
                        paramRow["ACC_LEVEL"] = accRow["ACC_LEVEL"];
                        paramRow["IS_DEFAULT_MENU"] = accRow["IS_DEFAULT_MENU"];

                        paramTable.Rows.Add(paramRow);

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "STD20A_INS2", paramSet, "RQSTDT", "",
                    QuickSave,
                    QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);



                base.MenuStatus = emMenuStatus.NONE;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 사용자그룹
            try
            {

                if (!base.ChildFormContains("NEW"))
                {

                    STD99A_D0A frm = new STD99A_D0A(acGridView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);

                }
                else
                {

                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 그룹 열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["USRGRP_CODE"]))
                {

                    STD99A_D0A frm = new STD99A_D0A(acGridView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["USRGRP_CODE"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["USRGRP_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //삭제
            try
            {
                acGridView1.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }



                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //
                paramTable.Columns.Add("DEL_DATE", typeof(String)); //

                paramTable.Columns.Add("OVERDEL", typeof(String));

                if (selected.Count == 0)
                {
                    //단일

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["USRGRP_CODE"] = focusRow["USRGRP_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;
                    paramRow["DEL_DATE"] = null;

                    paramRow["OVERDEL"] = "0";

                    paramTable.Rows.Add(paramRow);

                }
                else
                {

                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["USRGRP_CODE"] = selected[i]["USRGRP_CODE"];
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
                "STD20A_DEL", paramSet, "RQSTDT", "",
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
                //링크된 자식창 삭제
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



        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 그룹 복사
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();


                STD99A_D1A frm = new STD99A_D1A(acGridView1, focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                frm.ShowDialog(this);
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

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //권한설정 X

            DataTable dt = acTreeList1.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                row.BeginEdit();
                row["ACC_LEVEL"] = "1";
                row.EndEdit();
            }

            dt.AcceptChanges();


        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //권한설정 O

            DataTable dt = acTreeList1.DataSource as DataTable;

            foreach(DataRow row in dt.Rows)
            {
                row.BeginEdit();
                row["ACC_LEVEL"] = "2";
                row.EndEdit();
            }

            dt.AcceptChanges();

        }
    }
}