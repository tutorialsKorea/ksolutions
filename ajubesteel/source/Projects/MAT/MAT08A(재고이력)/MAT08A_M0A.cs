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
    public partial class MAT08A_M0A : BaseMenu
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
        public MAT08A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView1.AddTextEdit("STOCK_LOC", "자재창고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView1.AddTextEdit("MAT_TYPE", "자재형태", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SAFE_QTY", "안전재고 수량", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_QTY", "재고 수량(재고)", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.MONEY);

                acGridView1.AddTextEdit("MNG_FLAG", "관리유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                acGridView1.KeyColumn = new string[] { "SAVE_DATE", "STOCK_LOC", "PART_CODE" };


                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                //acGridView2.AddTextEdit("GUBUN", "구 분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("AMT", "금 액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                acGridView2.AddTextEdit("MNG_FLAG", "관리유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                //acTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

                acDateEdit1.Value = DateTime.Now;
                acDateEdit2.Value = DateTime.Now;

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl2.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                acLayoutControl1.GetEditor("MNG_YES").Value = "1";
                acLayoutControl2.GetEditor("MNG_YES").Value = "1";

                base.MenuInit();
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
            base.ChildContainerInit(sender);
        }

        void Search()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "L":
                        {
                            if (!acLayoutControl1.ValidCheck()) return;

                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("SAVE_DATE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("STK_LOC", typeof(String));
                            dtSearch.Columns.Add("MNG_FLAG", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["SAVE_DATE"] = layoutRow["SAVE_DATE"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                            paramRow["STK_LOC"] = layoutRow["STK_LOC"];
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

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT08A_SER", paramSet, "RQSTDT", "RSLTDT",
                                        QuickSearch,
                                        QuickException);
                            break;
                        }
                    case "S":
                        {
                            if (!acLayoutControl2.ValidCheck()) return;

                            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                            DataTable dtSearch = new DataTable("RQSTDT");
                            dtSearch.Columns.Add("PLT_CODE", typeof(String));
                            dtSearch.Columns.Add("SAVE_DATE", typeof(String));
                            dtSearch.Columns.Add("PART_LIKE", typeof(String));
                            dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                            dtSearch.Columns.Add("STK_LOC", typeof(String));
                            dtSearch.Columns.Add("MNG_FLAG", typeof(String));

                            DataRow paramRow = dtSearch.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["SAVE_DATE"] = layoutRow["SAVE_DATE"];
                            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
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

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT08A_SER", paramSet, "RQSTDT", "RSLTDT",
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

                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    DataTable resultTable = e.result.Tables["RSLTDT"].AsEnumerable()
                                                                    .GroupBy(g => new
                                                                    {
                                                                        PLT_CODE = g["PLT_CODE"],
                                                                        PART_CODE = g["PART_CODE"],
                                                                        PART_NAME = g["PART_NAME"],
                                                                        MAT_LTYPE = g["MAT_LTYPE"],
                                                                        MAT_MTYPE = g["MAT_MTYPE"],
                                                                        MAT_STYPE = g["MAT_STYPE"],

                                                                    })
                                                                    .Select(r => new
                                                                    {
                                                                        PLT_CODE = r.Key.PLT_CODE,
                                                                        PART_CODE = r.Key.PART_CODE,
                                                                        PART_NAME = r.Key.PART_NAME,
                                                                        MAT_LTYPE = r.Key.MAT_LTYPE,
                                                                        MAT_MTYPE = r.Key.MAT_MTYPE,
                                                                        MAT_STYPE = r.Key.MAT_STYPE,
                                                                        QTY = r.Sum(s => s["PART_QTY"].toDecimal()),
                                                                        AMT = r.Sum(s => s["AMT"].toDecimal())
                                                                    })
                                                                    .LINQToDataTable();
                    DataRow SumRow = resultTable.NewRow();
                    SumRow["PLT_CODE"] = acInfo.PLT_CODE;
                    SumRow["PART_CODE"] = "SUM";
                    SumRow["PART_NAME"] = "합계";
                    SumRow["QTY"] = resultTable.SUM("QTY");
                    SumRow["AMT"] = resultTable.SUM("AMT");
                    resultTable.Rows.Add(SumRow);

                    acGridView2.GridControl.DataSource = resultTable;
                    base.SetLog(e.executeType, resultTable.Rows.Count, e.executeTime);
                }
                else
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                }
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

        private void acCheckEdit6_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit6.CheckState == CheckState.Checked)
            {
                acCheckEdit4.CheckState = CheckState.Unchecked;
                acCheckEdit5.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit5_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit5.CheckState == CheckState.Checked)
            {
                acCheckEdit4.CheckState = CheckState.Unchecked;
                acCheckEdit6.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit4_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit4.CheckState == CheckState.Checked)
            {
                acCheckEdit5.CheckState = CheckState.Unchecked;
                acCheckEdit6.CheckState = CheckState.Unchecked;
            }
        }
    }
}
