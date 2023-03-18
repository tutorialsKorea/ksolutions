using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using BizManager;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace POP
{
    public partial class POP10A_M0A : ControlManager.BaseMenu
    {

        public POP10A_M0A()
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



        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH;


            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddLookUpEdit("PRE_CAM", "CAM 데이터 등록완료", "LPQZ75CC", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S066");

            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");


            acGridView1.AddLookUpEdit("WO_TYPE", "작업지시 형태", "BPIJ8QTW", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S037");

            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("JOB_PRIORITY", "우선순위", "41914", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");

            acGridView1.AddLookUpEdit("PROD_STATE", "금형상태", "WJB3HAFK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");

            acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_SPEC", "소재사양", "42544", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);




            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("PLN_START_TIME", "계획시작시간", "10613", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("PLN_END_TIME", "계획완료시간", "10614", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddTextEdit("PLN_PROC_TIME", "계획공수", "10588", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("PLN_PROC_MAN_TIME", "유인 계획공수", "5PODWBO7", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("PLN_PROC_SELF_TIME", "무인 계획공수", "7MNBO9IX", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddTextEdit("ACT_MC_TIME", "무인 실적공수", "DWNYLR5F", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("ACT_MAN_TIME", "유인 실적공수", "CLLN0WCV", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


            acGridView1.AddLookUpEdit("PREV_WO_FLAG", "이전공정 작업지시상태", "EBV1GLT6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

            acGridView1.AddTextEdit("PREV_PROC_CODE", "이전 공정코드", "Z8ORYMAF", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PREV_PROC_NAME", "이전 공정명", "3YFUSCS4", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddLookUpEdit("NEXT_WO_FLAG", "다음공정 작업지시상태", "4KVFECF1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

            acGridView1.AddTextEdit("NEXT_PROC_CODE", "다음 공정코드", "7TK7X38J", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("NEXT_PROC_NAME", "다음 공정명", "4QRWRS06", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "WO_NO" };


            acCheckedComboBoxEdit2.AddItem("계획일", true, "42112", "PLN_DATE", true, false);
            acCheckedComboBoxEdit2.AddItem("기준계획일", true, "WB7B84J9", "STD_PLN_DATE", true, false);


            acBarButtonItem1.Caption = acInfo.StdCodes.GetNameByCode("S066", "0");
            acBarButtonItem2.Caption = acInfo.StdCodes.GetNameByCode("S066", "1");



            acGridView2.AddHidden("TL_ID", typeof(string));

            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_NUM", "공구품번", "2XEVDYLQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_TIME", "가공시간", "6S5HF69R", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


            acGridView2.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");

            acGridView2.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");

            acGridView2.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");

            acGridView2.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");

            acGridView2.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.KeyColumn = new string[] { "TL_ID" };





            this.acGridControl2.Enabled = false;
            this.acBarButtonItem6.Enabled = false;


            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);



            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);




            cmbPROD.FixedProdState = new acProd.emProdState[] { acProd.emProdState.대기, acProd.emProdState.계획수립, acProd.emProdState.진행, acProd.emProdState.출하신청 };



            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);



            acGridControl2.DragDrop += new DragEventHandler(acGridControl2_DragDrop);

            acGridControl2.DragEnter += new DragEventHandler(acGridControl2_DragEnter);




            if (acInfo.PackageType == acInfo.emPackageEditionType.Standard)
            {
                acTabControl1.GetContainerName("TOOLLIST").PageVisible = false;
            }






            base.MenuInit();
        }

        void acGridControl2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void acGridControl2_DragDrop(object sender, DragEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Object data = e.Data.GetData(DataFormats.FileDrop);

                if (data != null)
                {

                    string[] fileNames = (string[])data;

                    POP10A_D1A frm = new POP10A_D1A(acGridView1.GetFocusedDataRow(), acGridView2);

                    frm.FileNames = fileNames;

                    frm.Text = fileNames.toString(" | ");

                    frm.ParentControl = this;

                    frm.Show();


                }

            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }


        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["TL_ID"]);
            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //공구리스트 편집기 열기

                    this.acBarButtonItem4_ItemClick(null, null);
                }

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {




                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {

                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //팝업메뉴 열기

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }
        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (focusRow != null)
            {


                this.acAttachFileControl1.LinkKey = focusRow["WO_NO"];
                this.acAttachFileControl1.ShowKey = new object[] { focusRow["WO_NO"] };


                this.acGridControl2.Enabled = true;
                this.acBarButtonItem6.Enabled = true;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "POP10A_SER2", paramSet, "RQSTDT", "RSLTDT",
                    QuickDetail,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.LOAD_DETAIL,
                //"POP05A_SER2", paramSet, "RQSTDT", "RSLTDT",
                //QuickDetail,
                //QuickException);

            }
            else
            {
                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;

                this.acGridControl2.Enabled = false;
                this.acBarButtonItem6.Enabled = false;

            }

        }
        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["WO_NO"]);
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

                layout.GetEditor("DATE").Value = "PLN_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now;
                layout.GetEditor("E_DATE").Value = DateTime.Now.AddDays(5);


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



        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }




        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber > 0)
            {
                if (ex.ParameterData != null)
                {
                    //정보가 존재하는 오류

                    acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                    frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                    frm.View.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    frm.ShowDialog();


                }
                else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
                {

                    acMessageBox.Show(this, ex);


                    //데이터 갱신이 필요함

                    this.DataRefresh("WORKORDER");


                }
            }

            else
            {
                acMessageBox.Show(this, ex);
            }


        }




        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PROD_CODE", typeof(String)); //금형코드


            paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드

            paramTable.Columns.Add("WO_NO", typeof(String)); //작업지시 번호

            paramTable.Columns.Add("PLN_START_DATE", typeof(String));
            paramTable.Columns.Add("PLN_END_DATE", typeof(String));

            paramTable.Columns.Add("S_STD_PLN_DATE", typeof(String));
            paramTable.Columns.Add("E_STD_PLN_DATE", typeof(String));


            DataRow paramRow = paramTable.NewRow();

            foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
            {
                switch (key)
                {
                    case "PLN_DATE":

                        paramRow["PLN_START_DATE"] = layoutRow["S_DATE"];
                        paramRow["PLN_END_DATE"] = layoutRow["E_DATE"];

                        break;


                    case "STD_PLN_DATE":

                        paramRow["S_STD_PLN_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_STD_PLN_DATE"] = layoutRow["E_DATE"];

                        break;

                }
            }


            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];


            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramRow["WO_NO"] = layoutRow["WO_NO"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD, "POP10A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);

        }


        public override void DataRefresh(object data)
        {
            if (data.EqualsEx("WORKORDER"))
            {

                if (base.IsData(data))
                {

                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD, "POP10A_SER", refreshSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);                    
                }
            }

        }





        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                base.SetData("WORKORDER", e.result);


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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

        void QuickProcess(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            //변경된 Row 업데이트
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, true);
                }

                acGridView1.SetValue("SEL", "0");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //CAM 데이터 등록완료 X
            try
            {

                this.CamFileRegComplete("0");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //CAM 데이터 등록완료 O
            try
            {
                this.CamFileRegComplete("1");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void CamFileRegComplete(object value)
        {
            //CAM 파일등록여부 설정
            acGridView1.EndEditor();


            DataView selelected = acGridView1.GetDataSourceView("SEL = '1'");


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("WO_NO", typeof(String)); //지시번호

            paramTable.Columns.Add("PRE_CAM", typeof(String)); //작업준비형태

            paramTable.Columns.Add("REG_EMP", typeof(String));


            if (selelected.Count == 0)
            {
                //단일 작업준비 변경

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["PRE_CAM"] = value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);



            }
            else
            {
                //다중 작업준비 변경


                for (int i = 0; i < selelected.Count; i++)
                {

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = selelected[i]["WO_NO"];
                    paramRow["PRE_CAM"] = value;
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);


                }
            }



            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "POP10A_UPD", paramSet, "RQSTDT", "",
                QuickProcess,
                QuickException);


        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공구리스트 새로 만들기


            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    DataRow masterFocusRow = acGridView1.GetFocusedDataRow();

                    POP10A_D0A frm = new POP10A_D0A(acGridView2, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm._WO_NO = masterFocusRow["WO_NO"];

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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공구리스트 열기

            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["TL_ID"]))
                {

                    POP10A_D0A frm = new POP10A_D0A(acGridView2, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["TL_ID"], frm);


                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["TL_ID"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공구리스트 삭제

            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView2.EndEditor();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("TL_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드


                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["TL_ID"] = focusRow["TL_ID"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["TL_ID"] = selected[i]["TL_ID"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramTable.Rows.Add(paramRow);
                    }


                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "POP10A_DEL", paramSet, "RQSTDT", "",
                    QuickDel,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
        void QuickDel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);

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

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //공구리스트 엑셀 불러오기
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                POP10A_D1A frm = new POP10A_D1A(acGridView1.GetFocusedDataRow(), acGridView2);

                frm.ParentControl = this;

                frm.Text = item.Caption;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }


    }
}
