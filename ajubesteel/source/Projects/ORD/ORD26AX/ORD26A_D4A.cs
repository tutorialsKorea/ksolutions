using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Linq;
using BizManager;

namespace ORD
{
    public sealed partial class ORD26A_D4A : BaseMenuDialog
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

        public ORD26A_D4A()
        {
            InitializeComponent();

            //재료비

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QLTY", "재질코드", "QGD6SY0U", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_QLTY_NAME", "재질명", "40572", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("WEIGHT_VOLUME", "소재중량", "40629", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.WEIGHT);

            acGridView1.AddTextEdit("PART_SPEC", "소재사양", "42544", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("UNIT_COST", "단가", "40121", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("MAT_COST", "금액", "40084", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);



            acGridView1.OptionsView.ShowFooter = true;

            acGridView1.Columns["MAT_COST"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView1.Columns["MAT_COST"].DisplayFormat.FormatString);


            //가공비

            acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PROC_TIME", "공수", "7A7ETV8Y", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView2.AddTextEdit("PROC_COST", "가공비", "HZKNBQA3", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView2.OptionsView.ShowFooter = true;


            acGridView2.Columns["PROC_COST"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, acGridView2.Columns["PROC_COST"].DisplayFormat.FormatString);



            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(layoutControl1_OnValueChanged);

        }

        void layoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            switch (info.ColumnName)
            {

                case "PROD_CODE":

                    this.Search();

                    break;

            }
        }




        public override void DialogInit()
        {



            base.DialogInit();

        }


        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "ORD26A_SER3", paramSet, "RQSTDT", "MAT_COST,PROC_COST",
            QuickSearch,
            QuickException);

        }
        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {


            try
            {

                //같은공정 그룹으로 변환
                var procCostGroupBy = from row in e.result.Tables["PROC_COST"].AsEnumerable()
                                      group row by new { PROC_CODE = row["PROC_CODE"], PROC_NAME = row["PROC_NAME"] } into grp
                                      select new
                                      {

                                          PROC_CODE = grp.Key.PROC_CODE,
                                          PROC_NAME = grp.Key.PROC_NAME,
                                          PROC_TIME = grp.Sum(r => r.Field<decimal>("PROC_TIME")),
                                          PROC_COST = grp.Sum(r => r.Field<decimal>("PROC_COST")),


                                      };



                DataTable procDt = procCostGroupBy.LINQToDataTable("PROC_COST");




                acGridView1.GridControl.DataSource = e.result.Tables["MAT_COST"];

                acGridView2.GridControl.DataSource = procDt;

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
            try
            {

                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                DataSet data = new DataSet();

                data.Tables.Add((acGridView1.GridControl.DataSource as DataTable).Copy());
                data.Tables.Add((acGridView2.GridControl.DataSource as DataTable).Copy());


                this.OutputData = data;

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




    }
}