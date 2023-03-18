using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace MAT
{
    public partial class MAT05A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }
        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }
        public MAT05A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                //반납요청 자재 마스터
                acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddTextEdit("RET_REQ_ID", "반납요청번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("RET_REQ_DATE", "반납요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView1.AddLookUpEdit("STOCK_LOC", "반납요청 자재창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView1.AddTextEdit("RET_REQ_ORG", "반납요청부서 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("RET_REQ_ORG_NAME", "반납요청부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("RET_REQ_EMP", "반납요청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddTextEdit("RET_REQ_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                //acGridView1.AddTextEdit("REMAIN_QTY", "미입고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "RET_REQ_ID" };

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("RET_REQ_ID", "반납요청번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddDateEdit("RET_REQ_DATE", "반납요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView2.AddLookUpEdit("STOCK_LOC", "반납요청 자재창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                //acGridView2.AddTextEdit("RET_REQ_ORG", "반납요청부서 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("RET_REQ_ORG_NAME", "반납요청부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("RET_REQ_EMP", "반납요청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView2.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView2.AddTextEdit("RET_REQ_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddTextEdit("MAT_COST", "자재 단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F1);
                acGridView2.AddTextEdit("MAT_AMT", "자재 금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F1);
                //acGridView2.AddTextEdit("RET_REQ_COST", "재고 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F4);
                //acGridView2.AddTextEdit("RET_AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F4);
                //acGridView2.AddLookUpEdit("INS_FLAG", "수입검사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, "S063");
                //acGridView2.AddTextEdit("REMAIN_QTY", "미입고수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView2.AddTextEdit("SCOMMENT_D", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("SCOMMENT", "반납요청_비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.KeyColumn = new string[] { "RET_REQ_ID" };

                acGridView3.GridType = acGridView.emGridType.SEARCH;
                acGridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView3.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView3.AddTextEdit("RET_REQ_ID", "반납요청번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("RET_REQ_DATE", "반납요청일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView3.AddLookUpEdit("STOCK_LOC", "반납요청 자재창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView3.AddTextEdit("RET_REQ_ORG", "반납요청부서 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("RET_REQ_ORG_NAME", "반납요청부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("RET_REQ_EMP", "반납요청자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView3.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView3.AddTextEdit("RET_REQ_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.KeyColumn = new string[] { "RET_REQ_ID" };

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                acCheckedComboBoxEdit2.AddItem("반납요청일", false, "", "RET_REQ_DATE", false, false, CheckState.Unchecked);
                (acLayoutControl2.GetEditor("STK_LOC") as acLookupEdit).SetCode("M005");

                this.acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
                this.acGridView1.MouseDown += acGridView1_MouseDown;
                this.acGridView1.SelectionChanged += acGridView1_SelectionChanged;

                this.acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;
                this.acGridView2.MouseDown += acGridView2_MouseDown;
                this.acGridView2.SelectionChanged += acGridView2_SelectionChanged;
                this.acGridView2.CellValueChanged += AcGridView2_CellValueChanged;

                this.acLayoutControl1.OnValueChanged += AcLayoutControl_OnValueChanged;

                this.acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

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

                layout.GetEditor("DATE").Value = "RET_REQ_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            //if (sender == acLayoutControl2)
            //{

            //    acLayoutControl layout = sender as acLayoutControl;

            //    layout.GetEditor("DATE").Value = "OUT_DATE";
            //    layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
            //    layout.GetEditor("E_DATE").Value = DateTime.Now;
            //}


            base.ChildContainerInit(sender);
        }

        void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "Y":

                        btnReYpgo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnYpgoCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        break;

                    case "C":

                        btnReYpgo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnYpgoCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcLayoutControl_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        private void AcGridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try{
                DataRow focusRow = acGridView2.GetDataRow(e.RowHandle);
                if (focusRow == null) return;

                decimal qty = focusRow["RET_REQ_QTY"].toDecimal();
                if (qty == 0) return;
            switch (e.Column.FieldName)
            {
                    case "MAT_COST":
                        {
                            focusRow["MAT_AMT"] = e.Value.toDecimal() * qty;
                        }
                        break;
                    case "MAT_AMT":
                        {
                            focusRow["MAT_COST"] = e.Value.toDecimal() / qty;
                        }
                        break;
                }
            }catch( Exception ex)
            { }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //반납요청 발주목록에 넣기
            acGridView view = sender as acGridView;

            if (view.RowCount == 0)
            {
                return;
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }
        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //재입고 목록에 넣기
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }
        void acGridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            selectionChanged(acGridView3);
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //반납요청 발주목록에서 제외
            acGridView view = sender as acGridView;


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            //재입고목록에서 제외
            acGridView view = sender as acGridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem3_ItemClick(null, null);
                }

            }
        }
        
        void acGridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            selectionChanged(acGridView2);
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }


        void Search()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "Y":
                        {
                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                            //날짜 검색조건 없음
                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("RET_REQ_LIKE", typeof(String)); //반납요청번호
                            paramTable.Columns.Add("RET_REQ_ORG", typeof(String)); //반납요청부서
                            paramTable.Columns.Add("PART_LIKE", typeof(String)); //품목코드/명
                            paramTable.Columns.Add("S_RET_REQ_DATE", typeof(String)); //반납요청일 시작
                            paramTable.Columns.Add("E_RET_REQ_DATE", typeof(String)); //반납요청일 종료

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["RET_REQ_LIKE"] = layoutRow["RET_REQ_LIKE"];
                            paramRow["RET_REQ_ORG"] = layoutRow["RET_REQ_ORG"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            foreach (string key in acCheckedComboBoxEdit2.GetKeyChecked())
                            {
                                switch (key)
                                {

                                    case "RET_REQ_DATE":


                                        paramRow["S_RET_REQ_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                                        paramRow["E_RET_REQ_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                                        break;


                                }
                            }
                            paramTable.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);


                            BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD,
                             "MAT05A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);

                            break;
                        }
                    case "C":
                        {
                            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("STK_LOC", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["STK_LOC"] = layoutRow["STK_LOC"];

                            dtSearch.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dtSearch);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT05A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch2,
                                        QuickException);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickMultiSearch(object sender, QBizMulti qBizActorMulti, QBizMulti.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //발주목록에 있는것은 제외한다.
                DataView view = acGridView2.GetDataSourceView();

                for (int i = 0; i < view.Count; i++)
                {
                    acGridView1.DeleteMappingRow(view[i].Row);
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickMultiException(object sender, QBizMulti qBizActor, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
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
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
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

        void selectionChanged(acGridView view)
        {
            int[] SelectionIdx = view.GetSelectedRows();

            if (SelectionIdx.Length != 1)
            {
                foreach (DataRow row in view.GetSelectedDataRows())
                {
                    row["SEL"] = "1";
                }
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    //단일선택
                    DataRow focusRow = acGridView1.GetFocusedDataRow();
                    if (focusRow != null)
                    {
                        DataRow row = focusRow.NewCopy();
                        row["SEL"] = "0";
                        acGridView2.UpdateMapingRow(row, true);
                        acGridView1.DeleteMappingRow(row);
                    }
                }
                else
                {
                    //다중선택
                    int cnt = selectedView.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        DataRow row = selectedView[0].Row.NewCopy();
                        row["SEL"] = "0";
                        acGridView2.UpdateMapingRow(row, true);
                        acGridView1.DeleteMappingRow(row);
                    }
                    acGridView2.RaiseFocusedRowChanged();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataView selectedView = acGridView2.GetDataSourceView("SEL = '1'");
                if (selectedView.Count == 0)
                {
                    //단일선택
                    DataRow focusRow = acGridView2.GetFocusedDataRow();
                    if (focusRow != null)
                    {
                        DataRow row = focusRow.NewCopy();
                        row["SEL"] = "0";
                        acGridView1.UpdateMapingRow(row, true);
                        acGridView2.DeleteMappingRow(row);
                    }

                }
                else
                {
                    //다중선택
                    int cnt = selectedView.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        DataRow row = selectedView[0].Row.NewCopy();
                        row["SEL"] = "0";
                        acGridView1.UpdateMapingRow(row, true);
                        acGridView2.DeleteMappingRow(row);
                    }
                }
                acGridView2.RaiseFocusedRowChanged();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnReYpgo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                if (acGridView2.GetSelectedDataRows().Length == 0)
                {
                    acAlert.Show(this, "재입고 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("RET_REQ_ID", typeof(String));
                paramTable.Columns.Add("YPGO_ID", typeof(String));
                paramTable.Columns.Add("MAT_COST", typeof(String));
                paramTable.Columns.Add("MAT_AMT", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(string));
                paramTable.Columns.Add("YPGO_DATE", typeof(string));
                paramTable.Columns.Add("QTY", typeof(int));
                paramTable.Columns.Add("YPGO_COST", typeof(decimal));
                paramTable.Columns.Add("YPGO_AMT", typeof(decimal));
                paramTable.Columns.Add("SCOMMENT", typeof(string));
                paramTable.Columns.Add("STK_LOCATION", typeof(string));

                if(acGridView2.GetDataSourceView("MAT_AMT IS NULL OR MAT_AMT = 0").Count > 0)
                {
                    acAlert.Show(this, "단가를 입력해주세요.", acAlertForm.enmType.Warning);
                    return;
                }

                foreach (DataRowView row in acGridView2.GetDataSourceView())
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RET_REQ_ID"] = row["RET_REQ_ID"];
                    paramRow["MAT_COST"] = row["MAT_COST"];
                    paramRow["MAT_AMT"] = row["MAT_AMT"];
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["YPGO_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                    paramRow["QTY"] = row["RET_REQ_QTY"];
                    paramRow["YPGO_COST"] = row["MAT_COST"];
                    paramRow["YPGO_AMT"] = row["MAT_AMT"];
                    paramRow["SCOMMENT"] = row["SCOMMENT_D"];
                    paramRow["STK_LOCATION"] = row["STOCK_LOC"];
                    paramTable.Rows.Add(paramRow);
                }


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT05A_INS", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);
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
                acGridView2.ClearRow();
                acAlert.Show(this, "재입고 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnYpgoCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView3.EndEditor();

                if (acGridView3.GetSelectedDataRows().Length == 0)
                {
                    acAlert.Show(this, "재입고 취소 목록이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                DataView selView = acGridView3.GetDataSourceView("SEL='1'");

                if (selView.Count == 0)
                {
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("RET_REQ_ID", typeof(String));
                paramTable.Columns.Add("YPGO_ID", typeof(String));
                //paramTable.Columns.Add("MAT_COST", typeof(String));
                //paramTable.Columns.Add("MAT_AMT", typeof(String));
                //paramTable.Columns.Add("SCOMMENT", typeof(String));

                foreach (DataRowView row in selView)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RET_REQ_ID"] = row["RET_REQ_ID"];
                    paramRow["YPGO_ID"] = row["YPGO_ID"];
                    //paramRow["MAT_COST"] = row["MAT_COST"];
                    //paramRow["MAT_AMT"] = row["MAT_AMT"];
                    //paramRow["SCOMMENT"] = row["SCOMMENT_D"];
                    paramTable.Rows.Add(paramRow);
                }

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT05A_DEL", paramSet, "RQSTDT", "RSLTDT",
                                QuickDel,
                                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView3.DeleteMappingRow(row);
                }
                acAlert.Show(this, "재입고 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
