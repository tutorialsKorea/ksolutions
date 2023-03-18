using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace STD
{
    public sealed partial class STD42A_M0A : BaseMenu
    {
        string _SearchYear;
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

        public STD42A_M0A()
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

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }


        public override void MenuInit()
        {
            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddTextEdit("GOAL_DATE", "목표기간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_GOAL", "공정불량 목표(PPM)", "", false,  DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("DUE_GOAL", "납품불량 목표(PPM)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("Q_COST_GOAL", "Q-COST 목표(%)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("P_A_COST_GOAL", "P-COST + A-COST 목표(%)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("F_COST_GOAL", "F-COST 목표(%)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.GetEditor("GOAL_YEAR").Value = DateTime.Now;

            base.MenuInit();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            _SearchYear = layoutRow["GOAL_YEAR"].ToString();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("GOAL_YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["GOAL_YEAR"] = _SearchYear;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD42A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable inputTable = acGridView2.NewTable();

                DataTable rsltDt = e.result.Tables["RSLTDT"];
                foreach (DataRow rqstRow in e.result.Tables["RQSTDT"].Rows)
                {
                    //12달
                    for(int i=1;i<=12;i++)
                    {
                        string m = rqstRow["GOAL_YEAR"] + string.Format("{0:D2}", i);
                        DataRow inputRow = inputTable.NewRow();
                        inputRow["GOAL_DATE"] = String.Format("{0:D2}", i);
                        if (rsltDt.Rows.Count > 0)
                        {
                            inputRow["PROC_GOAL"] = rsltDt.AsEnumerable().Where(w => w["GOAL_DATE"].toStringEmpty().Equals(m) && w["GUBUN"].toStringEmpty().Equals("PROC_GOAL")).Select(r => r["VALUE"]).FirstOrDefault();
                            inputRow["DUE_GOAL"] = rsltDt.AsEnumerable().Where(w => w["GOAL_DATE"].toStringEmpty().Equals(m) && w["GUBUN"].toStringEmpty().Equals("DUE_GOAL")).Select(r => r["VALUE"]).FirstOrDefault();
                            inputRow["Q_COST_GOAL"] = rsltDt.AsEnumerable().Where(w => w["GOAL_DATE"].toStringEmpty().Equals(m) && w["GUBUN"].toStringEmpty().Equals("Q_COST_GOAL")).Select(r => r["VALUE"]).FirstOrDefault();
                            inputRow["P_A_COST_GOAL"] = rsltDt.AsEnumerable().Where(w => w["GOAL_DATE"].toStringEmpty().Equals(m) && w["GUBUN"].toStringEmpty().Equals("P_A_COST_GOAL")).Select(r => r["VALUE"]).FirstOrDefault();
                            inputRow["F_COST_GOAL"] = rsltDt.AsEnumerable().Where(w => w["GOAL_DATE"].toStringEmpty().Equals(m) && w["GUBUN"].toStringEmpty().Equals("F_COST_GOAL")).Select(r => r["VALUE"]).FirstOrDefault();
                        }
                        inputTable.Rows.Add(inputRow);
                    }
                }
                acGridView2.GridControl.DataSource = inputTable;

                acGridView2.BestFitColumns();

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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_SearchYear.isNullOrEmpty())
                {
                    return;
                }

                acGridView2.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("GOAL_DATE", typeof(String)); //
                paramTable.Columns.Add("GUBUN", typeof(String)); //
                paramTable.Columns.Add("VALUE", typeof(String)); //

                DataView view = acGridView2.GetDataSourceView();
                foreach (DataRowView row in view)
                {
                    string goalDate = _SearchYear + row["GOAL_DATE"]; ;


                    DataRow paramRow1 = paramTable.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["GOAL_DATE"] = goalDate;
                    paramRow1["GUBUN"] = "PROC_GOAL";
                    paramRow1["VALUE"] = row["PROC_GOAL"];
                    paramTable.Rows.Add(paramRow1);

                    DataRow paramRow2 = paramTable.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["GOAL_DATE"] = goalDate;
                    paramRow2["GUBUN"] = "DUE_GOAL";
                    paramRow2["VALUE"] = row["DUE_GOAL"];
                    paramTable.Rows.Add(paramRow2);

                    DataRow paramRow3 = paramTable.NewRow();
                    paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow3["GOAL_DATE"] = goalDate;
                    paramRow3["GUBUN"] = "Q_COST_GOAL";
                    paramRow3["VALUE"] = row["Q_COST_GOAL"];
                    paramTable.Rows.Add(paramRow3);

                    DataRow paramRow4 = paramTable.NewRow();
                    paramRow4["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow4["GOAL_DATE"] = goalDate;
                    paramRow4["GUBUN"] = "P_A_COST_GOAL";
                    paramRow4["VALUE"] = row["P_A_COST_GOAL"];
                    paramTable.Rows.Add(paramRow4);

                    DataRow paramRow5 = paramTable.NewRow();
                    paramRow5["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow5["GOAL_DATE"] = goalDate;
                    paramRow5["GUBUN"] = "F_COST_GOAL";
                    paramRow5["VALUE"] = row["F_COST_GOAL"];
                    paramTable.Rows.Add(paramRow5);
                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD42A_INS", paramSet, "RQSTDT", "",
                QuickSave,
                QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acMessageBox.Show(this, "저장 완료!", "", false, acMessageBox.emMessageBoxType.CONFIRM);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

