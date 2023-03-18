using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace POP
{


    public sealed partial class POP21A_M0A : BaseMenu
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




        public POP21A_M0A()
        {
            InitializeComponent();
        }


        public override void MenuInit()
        {
            //실적완료 등록
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("ACTUAL_ID", "작업실적번호", "ZU7TGN7X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MAT_TYPE", "품목구분", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

            acGridView1.AddTextEdit("PROD_CODE", "제품코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_SPEC1", "규격", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("STOCK_CODE", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView1.AddLookUpEdit("STOCK_TYPE", "재고구분", "F6Z0JHP5", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M013");
            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddTextEdit("PART_QTY", "생산량", "RREEL82Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.AddTextEdit("PLN_QTY", "계획량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            
            acGridView1.KeyColumn = new string[] { "ACTUAL_ID", "WO_NO" };

            acCheckedComboBoxEdit1.AddItem("생산일", true, "40540", "WORK_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("계획일", true, "42112", "PLN_DATE", true, false);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            
            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
            
            //실적완료 등록취소
            acGridView3.GridType = acGridView.emGridType.SEARCH;
            acGridView3.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView3.AddTextEdit("ACTUAL_ID", "작업실적번호", "ZU7TGN7X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("STK_ID", "재고번호", "CGGZMGYX", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView3.AddDateEdit("STOCK_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpEdit("MAT_TYPE", "품목구분", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

            acGridView3.AddTextEdit("PROD_CODE", "제품코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("MAT_SPEC1", "규격", "42545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("MAT_SPEC", "규격", "42544", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("STOCK_CODE", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView3.AddLookUpEdit("STOCK_TYPE", "재고구분", "F6Z0JHP5", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M013");
            acGridView3.AddTextEdit("PART_QTY", "등록 재고량", "QRT93QPW", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("REG_EMP", "등록자", "608I87JD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "ACTUAL_ID", "WO_NO" };


            acCheckedComboBoxEdit2.AddItem("실적완료일", false, "", "STOCK_DATE", true, false, CheckState.Checked);
            
            acGridView3.ShowGridMenuEx += acGridView3_ShowGridMenuEx;
            
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl2.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl2_OnValueChanged);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);



            base.MenuInit();
        }

        void acLayoutControl3_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
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

        void acLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

                layout.GetEditor("DATE").Value = "WORK_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-3);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }
            else if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-3);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

            }

            base.ChildContainerInit(sender);
        }

        void acGridView3_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = acGridView1.GetFocusedDataRow();


            if (focusRow == null)
            {
                return;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void GetDetail()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["PART_CODE"] = focusRow["PART_CODE"];


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL, "POP21A_SER2", paramSet, "RQSTDT", "RSLTDT",
                    QuickDetail,
                    QuickException);
            }
            else
            {
                acGridView2.ClearColumns();
                acGridView2.ClearRow();

                acGridView2.GridControl.Enabled = false;
            }

        }

        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.ClearColumns();
                acGridView2.ClearRow();

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsView.ShowIndicator = true;
                acGridView2.AddLookUpEdit("INS_CODE", "검사항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M011");
                acGridView2.AddLookUpEdit("MEAS_CODE", "측정기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M012");
                acGridView2.AddTextEdit("AVG_VAL", "기준치", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MIN_VAL", "최소값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MAX_VAL", "최대값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                //신규 검사 컬럼 추가
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                if (focusRow != null)
                {
                    for (int i = 1; i < focusRow["PLN_QTY"].toInt() + 1; i++)
                    {
                        acGridView2.AddTextEdit(i.ToString(), "X" + i.ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F2);
                    }

                }
                
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickCalcelSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView3.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }
        
        void QuickREGSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            //데이터 갱신이 필요함
            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);

                this.DataRefresh(null);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }

        void Search()
        {

            switch (acTabControl1.GetSelectedContainerName())
            {

                case "WORKORDER":
                    {

                        //실적 완료 등록

                        if (acLayoutControl1.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일-조회시작
                        paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업일-조회완료
                        paramTable.Columns.Add("PLN_START_DATE", typeof(String)); //작업지시 계획일- 조회시작
                        paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //작업시지 계획일- 조회완료
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드
                        paramTable.Columns.Add("IS_NOT_REG_STOCK_QTY", typeof(String)); //재고등록 없음 포함

                        DataRow paramRow = paramTable.NewRow();


                        foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                        {
                            switch (key)
                            {
                                case "WORK_DATE":

                                    paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                                    paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];
                                    
                                    break;

                                case "PLN_DATE":

                                    paramRow["PLN_START_DATE"] = layoutRow["S_DATE"];
                                    paramRow["PLN_END_DATE"] = layoutRow["E_DATE"];

                                    break;

                            }
                        }

                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["IS_NOT_REG_STOCK_QTY"] = layoutRow["IS_NOT_REG_STOCK_QTY"];

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD, "POP21A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickREGSearch,
                        QuickException);


                    }

                    break;

                case "WORKCANCEL":
                    {
                        //실적 완료 취소

                        if (acLayoutControl2.ValidCheck() == false)
                        {
                            return;
                        }

                        DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("S_STOCK_DATE", typeof(String)); //작업일 - 조회시작
                        paramTable.Columns.Add("E_STOCK_DATE", typeof(String)); //작업일 - 조회완료


                        DataRow paramRow = paramTable.NewRow();


                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                        if (acCheckedComboBoxEdit2.GetKeyValue("STOCK_DATE").Equals(true))
                        {
                            paramRow["S_STOCK_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_STOCK_DATE"] = layoutRow["E_DATE"];
                        }


                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.LOAD, "POP21A_SER3", paramSet, "RQSTDT", "RSLTDT",
                        QuickCalcelSearch,
                        QuickException);

                    }

                    break;
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

        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //실적 완료
            try
            {
               
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }

                
                acGridView1.EndEditor();
                
                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    acMessageBox.Show("선택한 품목이 없습니다.", "실적 완료 등록", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                //DataRow[] drs = selected.ToTable().Select("ISNULL(STOCK_CODE, '') = ''");

                //if (selected.ToTable().Select("ISNULL(STOCK_CODE, '') = ''").Length > 0)
                //{
                //    acMessageBox.Show("창고가 없습니다.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                //if (selected.ToTable().Select("ISNULL(STOCK_TYPE, '') = ''").Length > 0)
                //{
                //    acMessageBox.Show("재고 구분이 없습니다.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}


                if (acMessageBox.Show(this, "정말 완료처리하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("STOCK_CODE", typeof(String)); //창고
                paramTable.Columns.Add("STOCK_TYPE", typeof(String)); //완성재고형태
                paramTable.Columns.Add("PART_QTY", typeof(int)); //
                paramTable.Columns.Add("P_QTY", typeof(int));
                paramTable.Columns.Add("T_QTY", typeof(int));
                paramTable.Columns.Add("IS_NOT_REG_STOCK_QTY", typeof(String)); //완성재고형태

                //if (selected.Count == 0)
                //{
                //    //단일

                //    DataRow focusRow = acGridView1.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
                //    paramRow["WO_NO"] = focusRow["WO_NO"];
                //    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                //    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                //    paramRow["STOCK_CODE"] = focusRow["STOCK_CODE"];
                //    paramRow["STOCK_TYPE"] = focusRow["STOCK_TYPE"];
                //    paramRow["PART_QTY"] = focusRow["PART_QTY"];

                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                //다중
                for (int i = 0; i < selected.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ACTUAL_ID"] = selected[i]["ACTUAL_ID"];
                    paramRow["WO_NO"] = selected[i]["WO_NO"];
                    paramRow["PROD_CODE"] = selected[i]["PROD_CODE"];
                    paramRow["PART_CODE"] = selected[i]["PART_CODE"];
                    paramRow["PART_QTY"] = selected[i]["PART_QTY"];
                    paramRow["STOCK_CODE"] = selected[i]["STOCK_CODE"];
                    paramRow["STOCK_TYPE"] = selected[i]["STOCK_TYPE"];
                    paramRow["P_QTY"] = selected[i]["P_QTY"];
                    paramRow["T_QTY"] = selected[i]["T_QTY"];
                    if (paramRow["STOCK_TYPE"].toStringEmpty().Equals("S03"))//선삭재고 없음
                    {
                        paramRow["IS_NOT_REG_STOCK_QTY"] = "1";
                    }
                    paramTable.Rows.Add(paramRow);
                }
                //}

                //return;

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "POP21A_INS", paramSet, "RQSTDT", "",
                QuickStock,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickStock(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickStockDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        private void acBarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //실적 완료 등록 취소
            try
            {
                if (acGridView3.ValidFocusRowHandle() == false) return;
                
                if (acMessageBox.Show(this, "정말 등록취소 처리하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView3.EndEditor();

                DataView selected = acGridView3.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    acMessageBox.Show("선택한 품목이 없습니다.", "실적 완료 취소", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("STK_ID", typeof(String)); //
                paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("STOCK_TYPE", typeof(String)); //
                paramTable.Columns.Add("PART_QTY", typeof(int)); //
                paramTable.Columns.Add("P_QTY", typeof(int)); //
                paramTable.Columns.Add("T_QTY", typeof(int)); //



                //if (selected.Count == 0)
                //{
                //    //단일

                //    DataRow focusRow = acGridView3.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["STK_ID"] = focusRow["STK_ID"];
                //    paramRow["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
                //    paramRow["WO_NO"] = focusRow["WO_NO"];
                //    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                //    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                //    paramRow["STOCK_TYPE"] = focusRow["STOCK_TYPE"];
                //    paramRow["PART_QTY"] = focusRow["PART_QTY"];

                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                    //다중
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["STK_ID"] = selected[i]["STK_ID"];
                        paramRow["ACTUAL_ID"] = selected[i]["ACTUAL_ID"];
                        paramRow["WO_NO"] = selected[i]["WO_NO"];
                        paramRow["PROD_CODE"] = selected[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selected[i]["PART_CODE"];
                        paramRow["STOCK_TYPE"] = selected[i]["STOCK_TYPE"];
                        paramRow["PART_QTY"] = selected[i]["PART_QTY"];
                        paramRow["P_QTY"] = selected[i]["P_QTY"];
                        paramRow["T_QTY"] = selected[i]["T_QTY"];

                        paramTable.Rows.Add(paramRow);
                    }
                //}

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL, "POP21A_DEL", paramSet, "RQSTDT", "",
                QuickStockDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 실적등록 완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acBarButtonItem11_ItemClick(sender, e);
        }

        /// <summary>
        /// 실적등록 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acBarButtonItem12_ItemClick(sender, e);
        }

    }


}
