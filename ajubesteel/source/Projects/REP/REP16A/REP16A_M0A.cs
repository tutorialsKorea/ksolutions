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
using System.Linq;
using BizManager;

namespace REP
{
    public partial class REP16A_M0A : BaseMenu
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

        public REP16A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);



            acPivotGridControl1.CustomFieldSort += new DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventHandler(acPivotGridControl1_CustomFieldSort);


        }



        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }





        void acPivotGridControl1_CustomFieldSort(object sender, DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs e)
        {

            acPivotGridControl view = sender as acPivotGridControl;

            int val1 = 0;
            int val2 = 0;

            if (e.Field.FieldName == "CD_NAME")
            {


                val1 = (view.DataSource as DataTable).Rows[e.ListSourceRowIndex1]["CD_SEQ"].toInt();
                val2 = (view.DataSource as DataTable).Rows[e.ListSourceRowIndex2]["CD_SEQ"].toInt();


                e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                if (e.Result == 0)
                {

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }



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


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }



        public override void MenuInit()
        {

            //금형별

            acPivotGridControl1.AddField("PROD_CODE", "금형코드", "40900", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("PROD_NAME", "금형명", "40901", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("CD_NAME", "항목명", "V7D8MCLU", true, DevExpress.XtraPivotGrid.PivotArea.ColumnArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            acPivotGridControl1.AddField("TARGET_PRIMECOST", "목표원가", "XDCI0P6Z", true, DevExpress.XtraPivotGrid.PivotArea.DataArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.MONEY);

            acPivotGridControl1.AddField("COST", "비용", "P8L1KW66", true, DevExpress.XtraPivotGrid.PivotArea.DataArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.MONEY);

            acPivotGridControl1.AddField("DIFF_COST", "차액", "Q5U9T49U", true, DevExpress.XtraPivotGrid.PivotArea.DataArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.MONEY);


            acPivotGridControl1.Fields["CD_NAME"].SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom;




            acCheckedComboBoxEdit1.AddItem("수주일", true, "40902", "ITEM_ORD_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("납기일", true, "40111", "DUE_DATE", true, false);

            acCheckedComboBoxEdit1.AddItem("출하일", true, "42362", "SHIP_DATE", true, false);



            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                //금형별 검색조건

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "ITEM_ORD_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


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


        void Search()
        {

            //금형별

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;

            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("S_ITEM_ORD_DATE", typeof(String)); //수주일 시작
            paramTable.Columns.Add("E_ITEM_ORD_DATE", typeof(String)); //수주일 종료
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //금형 납기일 시작
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //금형 납기일 종료
            paramTable.Columns.Add("S_SHIP_DATE", typeof(String)); //출하일 시작
            paramTable.Columns.Add("E_SHIP_DATE", typeof(String)); //출하일 종료

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ITEM_ORD_DATE":


                        paramRow["S_ITEM_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ITEM_ORD_DATE"] = layoutRow["E_DATE"];

                        break;

                    case "DUE_DATE":

                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;

                    case "SHIP_DATE":

                        paramRow["S_SHIP_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_SHIP_DATE"] = layoutRow["E_DATE"];

                        break;
                }


            }
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "REP16A_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2",
            QuickSearch,
            QuickException);


        }



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

                var join = from tb1 in e.result.Tables["RSLTDT"].AsEnumerable()
                           join tb2 in e.result.Tables["RSLTDT2"].AsEnumerable()
                           on new { KEY1 = tb1["PROD_CODE"], KEY2 = tb1["CD_CODE"] } equals new { KEY1 = tb2["PROD_CODE"], KEY2 = tb2["CD_CODE"] } into rows
                           from r in rows.DefaultIfEmpty()
                           select new
                           {
                               PROD_CODE = tb1["PROD_CODE"],
                               PROD_NAME = tb1["PROD_NAME"],
                               CD_CODE = tb1["CD_CODE"],
                               CD_NAME = tb1["CD_NAME"],
                               CD_SEQ = tb1["CD_SEQ"],
                               TARGET_PRIMECOST = tb1["TARGET_PRIMECOST"],
                               COST = r["COST"]
                           };


                DataTable dt = join.LINQToDataTable();

                dt.Columns.Add("DIFF_COST", typeof(decimal));

                foreach (DataRow row in dt.Rows)
                {
                    row["DIFF_COST"] = row["TARGET_PRIMECOST"].toDecimal() - row["COST"].toDecimal();
                }


                acPivotGridControl1.DataSource = dt;


                base.SetLog(e.executeType, dt.Rows.Count, e.executeTime);

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




    }
}