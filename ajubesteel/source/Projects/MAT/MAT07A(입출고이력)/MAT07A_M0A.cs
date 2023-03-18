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
    public partial class MAT07A_M0A : BaseMenu
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
        public MAT07A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView1.AddTextEdit("UID", "ID", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_TYPE", "구매 분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView1.AddTextEdit("PART_PRODTYPE", "사용처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView1.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView1.AddDateEdit("EVENT_TIME", "날짜", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("STOCK_FLAG", "구분", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S087");
                acGridView1.AddTextEdit("PREV_QTY", "전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("PREV_AMT", "전 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("IN_QTY", "입고량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("IN_COST", "입고 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("IN_AMT", "입고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("OUT_QTY", "출고량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("OUT_COST", "출고 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("OUT_AMT", "출고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("NEXT_QTY", "현재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("NEXT_AMT", "현재 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


                acGridView1.AddTextEdit("MNG_FLAG", "관리유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("REG_EMP_NAME", "등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("CVND_CODE", "공급사코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("CVND_NAME", "공급사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);



                acGridView1.Columns["PART_CODE"].GroupIndex = 0;
                //acGridView1.Columns["STOCK_LOC"].GroupIndex = 1;
                acGridView1.KeyColumn = new string[] { "UID" };


                acGridView2.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_TYPE", "구매 분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView3.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView3.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView3.AddTextEdit("PART_PRODTYPE", "사용처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView3.AddTextEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView3.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView3.AddDateEdit("EVENT_TIME", "날짜", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                acGridView3.AddLookUpEdit("STOCK_FLAG", "구분", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S087");
                acGridView3.AddTextEdit("PREV_QTY", "전재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("PREV_AMT", "전 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("IN_QTY", "입고량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("IN_COST", "입고 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("IN_AMT", "입고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("OUT_QTY", "출고량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("OUT_COST", "입고 단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("OUT_AMT", "출고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView3.AddTextEdit("NEXT_QTY", "현재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("NEXT_AMT", "현재 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);


                acGridView3.AddTextEdit("MNG_FLAG", "관리유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("REG_EMP_NAME", "등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("CVND_CODE", "공급사코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("CVND_NAME", "공급사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.Columns["PART_CODE"].GroupIndex = 0;

                acCheckedComboBoxEdit1.AddItem("기간", false, "", "EVENT_TIME", true, false, CheckState.Checked);


                ((acLayoutControl1.GetEditor("STOCK_LOC").Editor) as acLookupEdit).SetCode("M005");
                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

                acGridView2.Appearance.FocusedCell.BackColor = Color.CornflowerBlue;


                acLayoutControl1.GetEditor("MNG_YES").Value = "1";

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void acGridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                GetDetail();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }

        void Search()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("PART_LIKE", typeof(String));
                dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                dtSearch.Columns.Add("STOCK_LOC", typeof(String));
                dtSearch.Columns.Add("S_DATE", typeof(String));
                dtSearch.Columns.Add("E_DATE", typeof(String));
                dtSearch.Columns.Add("MNG_FLAG", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                paramRow["STOCK_LOC"] = layoutRow["STOCK_LOC"];
                //paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyy-MM-dd");
                //paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyy-MM-dd");

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "EVENT_TIME":
                            paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                            paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");
                            break;
                    }
                }

                if (layoutRow["MNG_YES"].ToString() == "1")
                {
                    paramRow["MNG_FLAG"] = "Y";
                }
                else if (layoutRow["MNG_NO"].ToString() == "1")
                {
                    paramRow["MNG_FLAG"] = "N";
                }

                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "P":
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT07A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
                        break;

                    case "S":
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT07A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.ExpandAllGroups();

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

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

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

        void GetDetail()
        {
            DataRow focusRow = acGridView2.GetFocusedDataRow();
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (focusRow != null)
            {
                DataTable dtSearch = new DataTable("RQSTDT");
                dtSearch.Columns.Add("PLT_CODE", typeof(String));
                dtSearch.Columns.Add("STOCK_LOC", typeof(String));

                dtSearch.Columns.Add("PART_LIKE", typeof(String));
                dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                dtSearch.Columns.Add("SPEC_LIKE", typeof(String));

                dtSearch.Columns.Add("S_DATE", typeof(String));
                dtSearch.Columns.Add("E_DATE", typeof(String));

                DataRow paramRow = dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["STOCK_LOC"] = focusRow["STOCK_LOC"];
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];

                paramRow["S_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                paramRow["E_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");



                dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "MAT07A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearchDetail,
                            QuickException);
            }
            else
            {
                acGridView3.ClearRow();
            }
        }

        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView3.ExpandAllGroups();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        private void btnAdjustStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSet paramSet = new DataSet();

            BizRun.QBizRun.ExecuteService(this, "MAT07A_ADJ", paramSet, "RQSTDT", "RSLTDT");

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //비고 저장
            acGridView1.EndEditor();
            DataTable mdfyRows = acGridView1.GetAddModifyRows();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("UID", typeof(string));
            paramTable.Columns.Add("SCOMMENT", typeof(string));

            foreach (DataRow row in mdfyRows.Rows)
            {
                DataRow newRow = paramTable.NewRow();
                newRow["PLT_CODE"] = row["PLT_CODE"];
                newRow["UID"] = row["UID"];
                newRow["SCOMMENT"] = row["SCOMMENT"];
                paramTable.Rows.Add(newRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MAT07A_INS", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);


        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                acAlert.Show(this, "저장 되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit1.CheckState == CheckState.Checked)
            {
                acCheckEdit2.CheckState = CheckState.Unchecked;
                acCheckEdit3.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit2_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit2.CheckState == CheckState.Checked)
            {
                acCheckEdit1.CheckState = CheckState.Unchecked;
                acCheckEdit3.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit3_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit3.CheckState == CheckState.Checked)
            {
                acCheckEdit1.CheckState = CheckState.Unchecked;
                acCheckEdit2.CheckState = CheckState.Unchecked;
            }
        }
    }
}
