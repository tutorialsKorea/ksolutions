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
using DevExpress.XtraPivotGrid;

namespace TOL
{
    public sealed partial class TOL04A_M0A : BaseMenu
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

        public TOL04A_M0A()
        {

            InitializeComponent();

            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl2.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl3.OnValueChanged += AcLayoutControl1_OnValueChanged;
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
            #region 지급
            acPivotGridControl1.AddField("GIVE_NO", "지급번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_SEQ","지급순번",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_DATE", "지급일",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            acPivotGridControl1.AddField("GIVE_STATE_NAME", "지급상태",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_MC_CODE", "지급 설비코드",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_MC_NAME", "지급 설비명",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_EMP_CODE", "지급자코드",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_EMP_NAME", "지급자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl1.AddField("지급 부서코드", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl1.AddField("지급 부서명", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_LOT", "LOT번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_CODE","공구코드",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_NAME", "공구명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_TYPE_NAME", "공구형태", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_LTYPE_NAME", "공구 대분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_MTYPE_NAME", "공구 중분류",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_STYPE_NAME", "공구 소분류",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_SPEC", "사양",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_UNIT","단위",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_QTY", "수량", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("SCOMMENT", "비고",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_DATE", "지급처리일자",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_EMP_CODE", "지급처리자코드",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_EMP_NAME", "지급처리자명",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            #region 반납

            acPivotGridControl2.AddField("GIVE_NO", "지급번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_SEQ", "지급순번", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_DATE", "지급일", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            acPivotGridControl2.AddField("GIVE_STATE_NAME", "지급상태", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_MC_CODE", "지급 설비코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_MC_NAME", "지급 설비명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_EMP_CODE", "지급자코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_EMP_NAME", "지급자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_NO", "반납번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_SEQ", "반납순번", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_DATE", "반납일", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_EMP_CODE", "반납자코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_EMP_NAME", "반납자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl2.AddField("지급 부서코드", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl2.AddField("지급 부서명", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_LOT", "LOT번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_CODE", "공구코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_NAME", "공구명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_TYPE_NAME", "공구형태", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_LTYPE_NAME", "공구 대분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_MTYPE_NAME", "공구 중분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_STYPE_NAME", "공구 소분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_SPEC", "사양", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_UNIT", "단위", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_QTY", "수량", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("SCOMMENT", "비고", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_DATE", "반납처리일자", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_EMP_CODE", "반납처리자코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_EMP_NAME", "반납처리자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            #region 폐기

            acPivotGridControl3.AddField("TDU_NO", "폐기번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_SEQ", "폐기순번", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_DATE", "폐기일", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            //acPivotGridControl3.AddField("폐기 설비코드", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("폐기 설비명", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_EMP_CODE", "폐기 작업자코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_EMP_NAME", "폐기 작업자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("폐기 부서코드", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("폐기 부서명", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_LOT", "LOT번호", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_CODE", "공구코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_NAME", "공구명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_TYPE_NAME", "공구형태", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_LTYPE_NAME", "공구 대분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_MTYPE_NAME", "공구 중분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_STYPE_NAME", "공구 소분류", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_SPEC", "사양", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_UNIT", "단위", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_QTY", "수량", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("SCOMMENT", "비고", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_DATE", "폐기처리일자", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_EMP_CODE", "폐기처리자코드", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_EMP_NAME", "폐기처리자명", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("지급일", false, "", "GIVE_DATE", true, false);

            acCheckedComboBoxEdit3.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit3.AddItem("반납일", false, "", "RTN_DATE", true, false);

            acCheckedComboBoxEdit2.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit2.AddItem("폐기일", false, "", "TDU_DATE", true, false);

            base.MenuInit();
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

            if (sender == acLayoutControl2)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl2.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl2.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl2.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;

            }

            if (sender == acLayoutControl3)
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

        void Search()
        {
            if (xtraTabControl1.SelectedTabPage == GiveTab)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_MC_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GIVE_MC_CODE"] = layoutRow["GIVE_MC_CODE"];
                paramRow["GIVE_EMP_CODE"] = layoutRow["GIVE_EMP_CODE"];
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
                "TOL04A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == ReturnTab)
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RTN_MC_CODE", typeof(String)); //
                paramTable.Columns.Add("RTN_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("E_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["RTN_MC_CODE"] = layoutRow["RTN_MC_CODE"];
                paramRow["RTN_EMP_CODE"] = layoutRow["RTN_EMP_CODE"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
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
                //paramRow["TL_STAT"] = acStdCodes.GetCodeByNameServer("T005", "신품");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL04A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == DisuseTab)
            {
                DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TDU_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_YPGO_DATE", typeof(String)); //
                paramTable.Columns.Add("E_YPGO_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TDU_EMP_CODE"] = layoutRow["TDU_EMP_CODE"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "TDU_DATE":

                            paramRow["S_TDU_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_TDU_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL04A_SER3", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail2,
                QuickException);
            }
            
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acPivotGridControl1.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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

                acPivotGridControl2.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
                acPivotGridControl3.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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
        /// 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

    }
}

