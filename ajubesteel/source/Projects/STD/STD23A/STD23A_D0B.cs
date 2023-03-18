using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD23A_D0B : BaseMenuDialog
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

        public STD23A_D0B()
        {
            InitializeComponent();

            acDateEdit1.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            acDateEdit2.EditValue = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));


            acGridView2.GridType = ControlManager.acGridView.emGridType.FIXED;


            acGridView2.AddCheckEdit("MON", "월", "40985", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("TUE", "화", "40986", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("WED", "수", "40987", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("THR", "목", "40988", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("FRI", "금", "40989", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("SAT", "토", "40990", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("SUN", "일", "40991", true, true, true, acGridView.emCheckEditDataType._STRING);



            acGridView1.GridType = ControlManager.acGridView.emGridType.LIST;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            //MC_GROUP

        }

        public override void DialogInitComplete()
        {
            DataRow defaultRow = acGridView2.NewRow();

            defaultRow["MON"] = "1";
            defaultRow["TUE"] = "1";
            defaultRow["WED"] = "1";
            defaultRow["THR"] = "1";
            defaultRow["FRI"] = "1";
            defaultRow["SAT"] = "1";
            defaultRow["SUN"] = "1";

            acGridView2.AddRow(defaultRow);


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD23A_SER5", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);


            base.DialogInitComplete();
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz,  BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickMultiException(object sender, QBizMulti qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }



        void QuickMultiSave(object sender, QBizMulti qBizMulti, QBizMulti.ExcuteCompleteArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //제조월력 생성
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();
                acGridView2.EndEditor();


                DataTable paramTable1Schema = new DataTable("RQSTDT");
                paramTable1Schema.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable1Schema.Columns.Add("FR_DATE", typeof(DateTime)); //
                paramTable1Schema.Columns.Add("TO_DATE", typeof(DateTime)); //
                paramTable1Schema.Columns.Add("CHECKZERO", typeof(String)); //덮어쓰기 여부
                paramTable1Schema.Columns.Add("Sunday", typeof(String)); //
                paramTable1Schema.Columns.Add("Monday", typeof(String)); //
                paramTable1Schema.Columns.Add("Tuesday", typeof(String)); //
                paramTable1Schema.Columns.Add("Wednesday", typeof(String)); //
                paramTable1Schema.Columns.Add("Thursday", typeof(String)); //
                paramTable1Schema.Columns.Add("Friday", typeof(String)); //
                paramTable1Schema.Columns.Add("Saturday", typeof(String)); //


            

                DataRow layoutParam = acLayoutControl1.CreateParameterRow();
                DataRow weekParam = acGridView2.GetFocusedDataRow();

                List<DataSet> paramSets = new List<DataSet>();


                DataTable paramTable1 = new DataTable();

                paramTable1 = paramTable1Schema.Clone();

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["FR_DATE"] = layoutParam["FR_DATE"];
                paramRow1["TO_DATE"] = layoutParam["TO_DATE"];
                paramRow1["CHECKZERO"] = layoutParam["CHECKZERO"];
                paramRow1["Sunday"] = weekParam["SUN"];
                paramRow1["Monday"] = weekParam["MON"];
                paramRow1["Tuesday"] = weekParam["TUE"];
                paramRow1["Wednesday"] = weekParam["WED"];
                paramRow1["Thursday"] = weekParam["THR"];
                paramRow1["Friday"] = weekParam["FRI"];
                paramRow1["Saturday"] = weekParam["SAT"];
                paramTable1.Rows.Add(paramRow1);


                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("MC_CODE", typeof(String)); //
                paramTable2.Columns.Add("PLT_CODE", typeof(String));
                

                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["MC_CODE"] = selectedView[i]["MC_CODE"];
                    paramTable2.Rows.Add(paramRow2);

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);

                paramSets.Add(paramSet);



                BizRun.QBizRun.ExecuteMultiService(
                this, QBiz.emExecuteType.PROCESS,
                "STD23A_INS_CAPA", paramSets, "RQSTDT,RQSTDT2", "",
                QuickMultiSave,
                QuickMultiException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

    }
}