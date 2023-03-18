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

using BizManager;

namespace STD
{
    public sealed partial class STD27A_M0A : BaseMenu
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

        public STD27A_M0A()
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



            //기본임률


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("UTC_CODE", "임률코드", "0BXLGNK0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("UTC_NAME", "임률명", "PQB42PSL", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "UTC_CODE" };


            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddDateEdit("UTC_START", "적용시작일", "K802GZJQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("UTC_END", "적용종료일", "8QDB9HRE", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddTextEdit("MON_MAN", "월/유인임률", "SXH6PBD9", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("MON_SELF", "월/무인임률", "D7EJBWPE", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("MON_OT", "월/잔업임률", "T0LG3Z5O", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("TUE_MAN", "화/유인임률", "TZDD6ICY", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("TUE_SELF", "화/무인임률", "NQUMLX1H", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("TUE_OT", "화/잔업임률", "87XUN0QB", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("WED_MAN", "수/유인임률", "33V3RAK1", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("WED_SELF", "수/무인임률", "CM3YZ3CB", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("WED_OT", "수/잔업임률", "HZRO1WW6", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("THR_MAN", "목/유인임률", "U79KGDSN", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("THR_SELF", "목/무인임률", "FU9H4YFB", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("THR_OT", "목/잔업임률", "YHUEXGQA", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddTextEdit("FRI_MAN", "금/유인임률", "YDX1GFIT", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("FRI_SELF", "금/무인임률", "O00DIP3A", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("FRI_OT", "금/잔업임률", "372STE5U", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


            acGridView2.AddTextEdit("SAT_MAN", "토/유인임률", "FC5DU3LB", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SAT_SELF", "토/무인임률", "YLKDEG1L", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SAT_OT", "토/잔업임률", "DS5HQGQM", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


            acGridView2.AddTextEdit("SUN_MAN", "일/유인임률", "9S5ZLYVV", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SUN_SELF", "일/무인임률", "BMV52TNC", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SUN_OT", "일/잔업임률", "YU64BG1G", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView2.KeyColumn = new string[] { "UCD_ID" };

            acGridView2.GridControl.Enabled = false;

            acCheckedComboBoxEdit1.AddItem("날짜", true, "DPG7RXWP", "UTC_DATE", true, false);


            //특정일 임률

            acGridView3.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView3.AddHidden("UID", typeof(Int32));

            acGridView3.AddTextEdit("UTC_CODE", "임률코드", "0BXLGNK0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("UTC_NAME", "임률명", "PQB42PSL", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddDateEdit("UTC_DATE", "날짜", "DPG7RXWP", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("MAN", "유인임률", "N7SYDPE0", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("SELF", "무인임률", "OWFU4DVX", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("OT", "잔업임률", "IGHDSHAT", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView3.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView3.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView3.KeyColumn = new string[] { "UID" };


            //이벤트 설정


            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);


            acGridView2.ShowGridMenuEx+= new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);

            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);

            acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);



            acGridView3.ShowGridMenuEx+= new acGridView.ShowGridMenuExHandler(acGridView3_ShowGridMenuEx);

            acGridView3.MouseDown += new MouseEventHandler(acGridView3_MouseDown);

            acGridView3.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView3_OnMapingRowChanged);

            acLayoutControl2.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);

            base.MenuInit();
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
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

        void acGridView3_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["UID"]);
            }
        }

        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["UCD_ID"]);
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["UTC_CODE"]);
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl2)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "UTC_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();


            }


            base.ChildContainerInit(sender);
        }

        void acGridView3_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView3.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //특정일 임률 편집기 열기

                    this.acBarButtonItem7_ItemClick(null, null);
                }

            }

        }

        void acGridView3_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {

            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }



                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));


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





        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //임률 적용기간 편집기 열기

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


                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //임률 편집기 열기

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


                }
                else if (e.MenuType == GridMenuType.Row)
                {

                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UTC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UTC_CODE"] = focusRow["UTC_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.LOAD_DETAIL,
                //"STD27A_SER2", paramSet, "RQSTDT", "RSLTDT",
                //QuickDetail,
                //QuickException);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL,
                "STD27A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickDetail,
                QuickException);
            }
            else
            {
                acGridView2.GridControl.Enabled = false;

                acGridView2.ClearRow();
            }


        }



        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }

        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.Enabled = true;

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.SetOldFocusRowHandle(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {

                this.DataRefresh(null);

            }
            else
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



        void Search()
        {


            switch (acTabControl1.GetSelectedContainerName())
            {
                case "DEFAULT":
                    {
                        //기본 임률  조회

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("UTC_CODE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["UTC_CODE"] = null;
                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);
                        
                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.NONE,
                        "STD27A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch1,
                        QuickException);
                    }

                    break;

                case "CUSTOM":
                    {
                        //특정일 임률 조회

                        if (acLayoutControl2.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_UTC_DATE", typeof(String)); //
                        paramTable.Columns.Add("E_UTC_DATE", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "UTC_DATE":

                                    paramRow["S_UTC_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_UTC_DATE"] = layoutRow["E_DATE"];

                                    break;
                            }

                        }


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.NONE,
                        "STD27A_SER3", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch2,
                        QuickException);
                    }

                    break;
            }


        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void QuickSearch1(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView3.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로 만들기 임률편집기
            try
            {
                if (!base.ChildFormContains("NEW_M"))
                {
                    STD27A_D0A frm = new STD27A_D0A(acGridView1, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_M", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_M");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 임률편집기
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;

                }
                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["UTC_CODE"]))
                {

                    STD27A_D0A frm = new STD27A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["UTC_CODE"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["UTC_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 임률마스터

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
                paramTable.Columns.Add("UTC_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //




                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["UTC_CODE"] = focusRow["UTC_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중삭제

                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();

                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["UTC_CODE"] = selected[i]["UTC_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD27A_DEL", paramSet, "RQSTDT", "",
                QuickDEL1,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }



        void QuickDEL1(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로 만들기 임률적용기간 편집기

            try
            {
                if (!base.ChildFormContains("NEW_D"))
                {
                    STD27A_D1A frm = new STD27A_D1A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_D", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW_D");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }





        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 임률적용기간 편집기
            try
            {
                if (acGridView2.ValidFocusRowHandle() == false)
                {
                    return;
                }

                DataRow focusRow = acGridView2.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["UCD_ID"]))
                {

                    STD27A_D1A frm = new STD27A_D1A(acGridView1, acGridView1.GetFocusedDataRow(), acGridView2, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["UCD_ID"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["UCD_ID"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 임률적용기간 삭제
            try
            {
                acGridView2.EndEditor();



                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UCD_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                if (selected.Count == 0)
                {
                    //단일

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["UCD_ID"] = focusRow["UCD_ID"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중

                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["UCD_ID"] = selected[i]["UCD_ID"];
                        paramRow["DEL_EMP"] = acInfo.UserID;

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD27A_DEL2", paramSet, "RQSTDT", "",
                QuickDEL2,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickDEL3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }
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


        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //특정일 임률 편집기 생성
            try
            {
                STD27A_D2A frm = new STD27A_D2A(acGridView3);

                frm.ParentControl = this;

                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


            

        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기 특정일 임률 편집기

            try
            {
                if (acGridView3.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView3.GetFocusedDataRow();

                if (!base.ChildFormContains(focusRow["UID"]))
                {

                    STD27A_D3A frm = new STD27A_D3A(acGridView3, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["UID"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("UID");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제 특정일 임률 
            try
            {
                acGridView3.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataView selectedView = acGridView3.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UID", typeof(String)); //


                if (selectedView.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView3.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["UID"] = focusRow["UID"];

                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중삭제

                    for (int i = 0; selectedView.Count > i; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["UID"] = selectedView[i]["UID"];

                        paramTable.Rows.Add(paramRow);

                    }


                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD27A_DEL3", paramSet, "RQSTDT", "",
                QuickDEL3,
                QuickException);
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

    }
}