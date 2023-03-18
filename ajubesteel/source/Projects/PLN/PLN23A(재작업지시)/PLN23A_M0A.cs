using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;
using POP;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace PLN
{
    public sealed partial class PLN23A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public PLN23A_M0A()
        {
            InitializeComponent();

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }

        }


        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;

                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddCheckEdit("IS_NG_REWORK", "재작업지시여부", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
                acGridView1.AddTextEdit("NG_ID", "불량번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("NG_TYPE", "불량형태", "C1VMAHMU", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, "Q004");
                acGridView1.AddLookUpEdit("NG_CAT", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q005");
                acGridView1.AddTextEdit("WK_NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_PUID", "참조 부품코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_PUID_NAME", "참조 부품명", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
                acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "P012");
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
                acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");
                acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpEdit("PIN_TYPE", "PIN TYPE", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
                acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView1.AddTextEdit("PROD_QTY", "수주수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                //acGridView1.AddTextEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SCOMMENT", "전달사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddHidden("PT_ID", typeof(string));
                acGridView1.AddHidden("WO_NO", typeof(string));

                acGridView1.KeyColumn = new string[] { "NG_ID" };

                acCheckedComboBoxEdit1.AddItem("불량일", false, "", "NG_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
                //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "NG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            base.ChildContainerInit(sender);
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
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
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PROD_LIKE", typeof(String));
            paramTable.Columns.Add("PART_LIKE", typeof(String));
            paramTable.Columns.Add("NG_STATE", typeof(String));
            paramTable.Columns.Add("NG_TYPE_CON", typeof(String));

            paramTable.Columns.Add("S_NG_DATE", typeof(String)); //불량일 시작일
            paramTable.Columns.Add("E_NG_DATE", typeof(String)); //불량일 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["NG_STATE"] = "C";
            paramRow["NG_TYPE_CON"] = "1";

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "NG_DATE":
                        //불량일
                        paramRow["S_NG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_NG_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN23A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ParameterData != null)
            {
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("WO_NO", "작업지시번호", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_CODE", "품목코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_NAME", "품목명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_CODE", "공정코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_NAME", "공정명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
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
        
        //private void btnRework_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //재작업지시
        //    try
        //    {

        //        DataRow focusRow = acGridView2.GetFocusedDataRow();

        //        if (focusRow == null) return;
        //        //중지나 완료인 경우만 재작업지시 가능
        //        if (focusRow["WO_FLAG"].ToString() == "3" || focusRow["WO_FLAG"].ToString() == "4")
        //        {
        //            PLN03A_D3A frm = new PLN03A_D3A();

        //            frm.ParentControl = this;

        //            base.ChildFormAdd("WO_NO", frm);

        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                DataRow dr = (DataRow)frm.OutputData;

        //                DataTable paramTable = new DataTable("RQSTDT");
        //                paramTable.Columns.Add("PLT_CODE", typeof(String));
        //                paramTable.Columns.Add("WO_NO", typeof(String));

        //                DataRow paramRow = paramTable.NewRow();
        //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                paramRow["WO_NO"] = focusRow["WO_NO"];

        //                paramTable.Rows.Add(paramRow);                       

        //                DataSet paramSet = new DataSet();
        //                paramSet.Tables.Add(paramTable);

        //                DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SAVE3", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
        //                foreach (DataRow row in dtResult.Rows)
        //                {
        //                    acGridView2.UpdateMapingRow(row, true);
        //                }
        //                acMessageBox.Show("재작업 지시 처리되었습니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);
        //            }
        //        }
        //        else
        //        {
        //            acMessageBox.Show("재작업지시는 중지 혹은 완료된 작업만 가능합니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //private void btnDelWO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //지시 삭제
        //    try
        //    {
        //        if (acMessageBox.Show("선택한 작업지시를 삭제하시겠습니까? ", "작업지시 삭제", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
        //            return;


        //        DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("WO_NO", typeof(String));
        //        paramTable.Columns.Add("IS_MAT", typeof(String));


        //        if (selectedRows.Length == 0)
        //        {
        //            DataRow focusRow = acGridView2.GetFocusedDataRow();


        //            //if (focusRow["WO_FLAG"].ToString() == "1" || focusRow["WO_FLAG"].ToString() == "0")
        //            //{
        //            //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //            //    return;
        //            //}

        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["WO_NO"] = focusRow["WO_NO"];
        //            paramRow["IS_MAT"] = focusRow["IS_MAT"];

        //            paramTable.Rows.Add(paramRow);
        //        }
        //        else
        //        {
        //            foreach (DataRow row in selectedRows)
        //            {
        //                //if (row["WO_FLAG"].ToString() == "1" || row["WO_FLAG"].ToString() == "0")
        //                //{
        //                //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //                //    return;
        //                //}
        //                DataRow paramRow = paramTable.NewRow();
        //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                paramRow["WO_NO"] = row["WO_NO"];
        //                paramRow["IS_MAT"] = row["IS_MAT"];

        //                paramTable.Rows.Add(paramRow);
        //            }
        //        }

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_DEL", paramSet, "RQSTDT", "RSLTDT",
        //                QuickDel,
        //                QuickException);

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
        //        {
        //            this.acGridView2.DeleteMappingRow(row);
        //        }

        //        acMessageBox.Show("삭제 처리되었습니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 제작사양서 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            //ProdSpec frm = new ProdSpec(focusRow);

            PopSpec frm = new PopSpec(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // BOM 보기

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopBom frm = new PopBom(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "JT");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //재작업지시
            acGridView1.EndEditor();

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null) return;


            DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

            bool isRework = false;
            if (selectedView.Count != 0)
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    if (selectedView[i]["IS_NG_REWORK"].ToString() == "1")
                    {
                        isRework = true;
                        break;
                    }
                }
            }
            else
            {
                if (focusRow["IS_NG_REWORK"].ToString() == "1")
                {
                    isRework = true;
                }
            }

            if (isRework)
            {
                acAlert.Show(this, "이미 재작업지시를 했습니다.", acAlertForm.enmType.Warning);
                return;
            }

            if (acMessageBox.Show("재작업지시 하시겠습니까?", "재작업지시", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            PLN23A_D0A frm = new PLN23A_D0A();

            frm.ParentControl = this;
            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = frm.OutputData as DataRow;

                //DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("NG_ID", typeof(string));
                paramTable.Columns.Add("PT_ID", typeof(string));
                paramTable.Columns.Add("PLAN_QTY", typeof(string));
                paramTable.Columns.Add("PLAN_DATE", typeof(DateTime));
                paramTable.Columns.Add("NG_TYPE", typeof(string));
                paramTable.Columns.Add("NG_CAT", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));
                paramTable.Columns.Add("WO_NO", typeof(string));

                if (selectedView.Count == 0)
                {
                    if (focusRow["WK_NG_QTY"].ToString() == "")
                    {
                        acAlert.Show(this, "불량수량이 없습니다.", acAlertForm.enmType.Info);
                        return;
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["NG_ID"] = focusRow["NG_ID"];
                    paramRow["PT_ID"] = focusRow["PT_ID"];
                    paramRow["PLAN_QTY"] = focusRow["WK_NG_QTY"];
                    paramRow["PLAN_DATE"] = frmRow["PLAN_DATE"];
                    paramRow["NG_TYPE"] = focusRow["NG_TYPE"];
                    paramRow["NG_CAT"] = focusRow["NG_CAT"];
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["WO_NO"] = focusRow["WO_NO"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {

                        if (selectedView[i]["WK_NG_QTY"].ToString() == "")
                        {
                            acAlert.Show(this, "불량수량이 없습니다.", acAlertForm.enmType.Info);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["NG_ID"] = selectedView[i]["NG_ID"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["PLAN_QTY"] = selectedView[i]["WK_NG_QTY"];
                        paramRow["PLAN_DATE"] = frmRow["PLAN_DATE"];
                        paramRow["NG_TYPE"] = selectedView[i]["NG_TYPE"];
                        paramRow["NG_CAT"] = selectedView[i]["NG_CAT"];
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.PROCESS,
                 "PLN23A_INS", paramSet, "RQSTDT", "RSLTDT",
                 QuickSave,
                 QuickException);
            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                acAlert.Show(this, "재작업지시 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
