using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace TOL
{
    public sealed partial class TOL02A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {
            get
            {
                return acBarManager1;
            }
        }

        public override void DataRefresh(object data)
        {
            this.Search();
        }

        public override void BarCodeScanInput(string barcode)
        {


        }

        public TOL02A_M0A()
        {

            InitializeComponent();

            #region 선입 반납 탭 이벤트

            //acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            //acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acGridView1.CellValueChanged += AcGridView1_CellValueChanged;
            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;

            #endregion

            #region 선택 반납 탭 이벤트

            //acGridView2.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);
            acLayoutControl2.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            #endregion

            #region 반납 목록 탭 이벤트
            acLayoutControl3.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl3.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            #endregion

            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
        }

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            #region 선입 반납 탭 

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            //acGridView1.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("EMP_CODE", "작업자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("EMP_NAME", "작업자명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView1.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView1.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView1.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView1.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("TL_MIN", "MIN", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("TL_MAX", "MAX", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("TL_DANGER_QTY", "위험 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("GIVE_QTY", "지급수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("RTN_QTY", "반납 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TL_UNITCOST", "단가", "40121", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddLookUpEdit("TL_UNIT", "단위", "40123", true , DevExpress.Utils.HorzAlignment.Center, false, true, false , "M003");
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "TL_CODE" };

            #endregion

            #region 선택 반납 탭 

            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddDateEdit("GIVE_DATE", "반납일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("GIVE_MC_CODE", "지급설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("GIVE_MC_NAME", "지급설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("GIVE_EMP_CODE", "지급자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("GIVE_EMP_NAME", "지급자명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_LOT", "LOT NO", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("TL_STAT", "공구상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T005");
            //acGridView2.AddTextEdit("TL_LIFE", "공구수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("STD_LIFE", "기준 수명", "836KV66Y", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_LIFE", "공구 수명", "836KV66Y", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView2.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView2.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView2.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView2.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_UNITCOST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddLookUpEdit("TL_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            //acGridView2.AddTextEdit("TL_MIN", "MIN", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView2.AddTextEdit("TL_MAX", "MAX", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView2.AddTextEdit("TL_DANGER_QTY", "위험 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "TL_LOT" };

            #endregion

            #region 반납 목록 탭 

            acGridView3.GridType = acGridView.emGridType.SEARCH;

            acGridView3.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("RTN_NO", "반납번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("RTN_SEQ", "반납순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("RTN_DATE", "반납일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("RTN_EMP_CODE", "반납자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("RTN_EMP_NAME", "반납자명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_NO", "반납순번", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_SEQ", "반납번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_EMP_CODE", "지급자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("GIVE_EMP_NAME", "지급자명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("TL_LOT", "LOT번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("TL_LIFE", "공구수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView3.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView3.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView3.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView3.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("TL_UNITCOST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddLookUpEdit("TL_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            //acGridView3.AddTextEdit("TL_MIN", "MIN", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView3.AddTextEdit("TL_MAX", "MAX", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView3.AddTextEdit("TL_DANGER_QTY", "위험 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView3.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView3.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "RTN_NO", "RTN_SEQ" };

            #endregion

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("지급일", false, "", "GIVE_DATE", true, false);

            acCheckedComboBoxEdit3.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit3.AddItem("지급일", false, "", "GIVE_DATE", true, false);

            acCheckedComboBoxEdit2.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit2.AddItem("반납일", false, "", "RTN_DATE", true, false);

            btnReturn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnReturnCancelLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnReturnMdfyLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            base.MenuInit();
        }

        private void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == returnGroupTab)
            {
                btnReturn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnReturnCancelLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnReturnMdfyLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (xtraTabControl1.SelectedTabPage == returnLotTab)
            {
                btnReturn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnReturnCancelLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnReturnMdfyLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if(xtraTabControl1.SelectedTabPage == returnLotCancelTab)
            {
                btnReturn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnReturnCancelLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnReturnMdfyLot.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void AcGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName.Equals("RTN_QTY"))
            {
                int inputQty = e.Value.toInt();
                if (acGridView1.GetRowCellValue(e.RowHandle, "GIVE_QTY").toInt() < inputQty)
                {
                    acMessageBox.Show(this, "반납수량보다 큽니다. 다시 입력해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    acGridView1.SetRowCellValue(e.RowHandle, e.Column, 0);
                }
                else if (inputQty > 0)
                {
                    acGridView1.SetRowCellValue(e.RowHandle, "SEL", "1");
                }
                else if (inputQty == 0)
                {
                    acGridView1.SetRowCellValue(e.RowHandle, "SEL", "0");
                }
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl1.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl1.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl1.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;

            }

            else if (sender == acLayoutControl2)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl2.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl2.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl2.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;
            }

            else if (sender == acLayoutControl3)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl3.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl3.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl3.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;
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

        public void Search()
        {
            if (xtraTabControl1.SelectedTabPage == returnGroupTab)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("GIVE_MC", typeof(String)); //
                //paramTable.Columns.Add("GIVE_EMP", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["GIVE_MC"] = layoutRow["GIVE_MC"];
                //paramRow["GIVE_EMP"] = layoutRow["GIVE_EMP"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "GIVE_DATE":

                            paramRow["S_GIVE_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_GIVE_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL02A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == returnLotTab)
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_MC", typeof(String)); //
                paramTable.Columns.Add("GIVE_EMP", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_LOT_LIKE", typeof(String)); //
                paramTable.Columns.Add("S_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GIVE_MC"] = layoutRow["GIVE_MC"];
                paramRow["GIVE_EMP"] = layoutRow["GIVE_EMP"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["TL_LOT_LIKE"] = layoutRow["TL_LOT_LIKE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "GIVE_DATE":

                            paramRow["S_GIVE_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_GIVE_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL02A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == returnLotCancelTab)
            {
                DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_MC", typeof(String)); //
                paramTable.Columns.Add("GIVE_EMP", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_LOT_LIKE", typeof(String)); //
                paramTable.Columns.Add("S_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("E_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GIVE_MC"] = layoutRow["GIVE_MC"];
                paramRow["GIVE_EMP"] = layoutRow["GIVE_EMP"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["TL_LOT_LIKE"] = layoutRow["TL_LOT_LIKE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "RTN_DATE":

                            paramRow["S_RTN_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_RTN_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL02A_SER3", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail2,
                QuickException);
            }
            
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView1.RowCount, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView2.RowCount, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearchDetail2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView3.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView3.RowCount, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }



        void QuickDel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row,false);
                    acGridView2.UpdateMapingRow(row, false);
                    acGridView3.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        /// <summary>
        /// 새로 만들기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    TOL02A_D0A frm = new TOL02A_D0A(acGridView1, null);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
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

        /// <summary>
        /// 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["TL_CODE"]))
                {
                    TOL02A_D0A frm = new TOL02A_D0A(acGridView1, focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    base.ChildFormAdd(focusRow["TL_CODE"], frm);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Search();
                    }
                }
                else
                {
                    base.ChildFormFocus(focusRow["TL_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //표준공구 편집기 열기
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


                //팝업메뉴 열기

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


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

        /// <summary>
        /// 반납
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == returnGroupTab)
            {
                this.ReturnTool();
            }
            else if (xtraTabControl1.SelectedTabPage == returnLotTab)
            {
                this.ReturnToolLot();
            }
        }

        /// <summary>
        /// 공구 반납 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnCancelLot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DeleteReturnLot();
        }

        /// <summary>
        /// 반납 수정
        /// 설비, 작업자
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnMdfyLot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.MdfyReturnLot();
        }

        private void ReturnTool()
        {
            acGridView1.EndEditor();

            try
            {
                //선택한 행이 없다면 리턴
                if (acGridView1.GetDataRow("SEL='1'") == null)
                {
                    acMessageBox.Show(this, "선택한 행이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                //선택한 행 중 수량 입력한 컬럼이 없을때 리턴
                if (acGridView1.GetDataRow("SEL='1' AND RTN_QTY > 0") == null)
                {
                    acMessageBox.Show(this, "선택한 행 중 반납할 수량이 입력되지 않은 행이 존재합니다. ", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (!base.ChildFormContains("NEW"))
                {
                    TOL02A_D0A frm = new TOL02A_D0A(acGridView1, null);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    base.ChildFormAdd("NEW", frm);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Search();
                    }
                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void ReturnToolLot()
        {
            acGridView2.EndEditor();

            //선택한 행이 없다면 리턴
            if (acGridView2.GetDataRow("SEL='1'") == null)
            {
                acMessageBox.Show(this, "선택한 행이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            if (!base.ChildFormContains("NEW"))
            {
                TOL02A_D1A frm = new TOL02A_D1A(acGridView2, null);
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                base.ChildFormAdd("NEW", frm);
                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("NEW");
            }

        }

        private void MdfyReturnLot()
        {
            acGridView3.EndEditor();

            //선택한 행이 없다면 리턴
            if (acGridView3.GetDataRow("SEL='1'") == null && acGridView3.GetFocusedDataRow() == null)
            {
                acMessageBox.Show(this, "선택한 행이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            if (!base.ChildFormContains("NEW"))
            {
                TOL02A_D2A frm = new TOL02A_D2A(acGridView3, null);
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                base.ChildFormAdd("NEW", frm);
                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus("NEW");
            }
        }

        private void DeleteReturnLot()
        {
            //삭제의 경우 완전 삭제 (Delete)
            //삭제하는 경우가 거의 없을거라 판단된다고 하였음
            if (acMessageBox.Show(this, "선택한 공구들의 반납을 취소 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            {
                acGridView3.EndEditor();

                DataView selView = acGridView3.GetDataSourceView("SEL='1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //반납 목록 삭제
                paramTable.Columns.Add("RTN_NO", typeof(String)); //
                paramTable.Columns.Add("RTN_SEQ", typeof(String)); //
                //반납 목록 상태 지급으로 변경
                paramTable.Columns.Add("GIVE_NO", typeof(String)); //
                paramTable.Columns.Add("GIVE_SEQ", typeof(String)); //
                paramTable.Columns.Add("GIVE_STATE", typeof(String)); //
                //LOT 상태 신품 -> 지급 변경
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_LOT", typeof(String)); //
                paramTable.Columns.Add("TL_STAT", typeof(String)); //
                paramTable.Columns.Add("GIVE_QTY", typeof(decimal)); //

                string stateCode = acStdCodes.GetCodeByNameServer("T005", "지급");
                if (selView.Count ==0)
                {
                    DataRow focusRow = acGridView3.GetFocusedDataRow();
                    if (focusRow == null)
                    {
                        acMessageBox.Show(this, "선택한 목록이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RTN_NO"] = focusRow["RTN_NO"];
                    paramRow["RTN_SEQ"] = focusRow["RTN_SEQ"];
                    paramRow["GIVE_NO"] = focusRow["GIVE_NO"];
                    paramRow["GIVE_SEQ"] = focusRow["GIVE_SEQ"];
                    paramRow["GIVE_STATE"] = stateCode;
                    paramRow["TL_CODE"] = focusRow["TL_CODE"];
                    paramRow["TL_LOT"] = focusRow["TL_LOT"];
                    paramRow["TL_STAT"] = stateCode;
                    paramRow["GIVE_QTY"] = 1;
                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    for(int i=0;i<selView.Count;i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["RTN_NO"] = selView[i]["RTN_NO"];
                        paramRow["RTN_SEQ"] = selView[i]["RTN_SEQ"];
                        paramRow["GIVE_NO"] = selView[i]["GIVE_NO"];
                        paramRow["GIVE_SEQ"] = selView[i]["GIVE_SEQ"];
                        paramRow["GIVE_STATE"] = stateCode;
                        paramRow["TL_CODE"] = selView[i]["TL_CODE"];
                        paramRow["TL_LOT"] = selView[i]["TL_LOT"];
                        paramRow["TL_STAT"] = stateCode;
                        paramRow["GIVE_QTY"] = 1;
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL02A_DEL", paramSet, "RQSTDT", "RSLTDT",
                QuickDel,
                QuickException);
            }
        }
    }
}

