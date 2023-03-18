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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace POP
{
    public sealed partial class POP06A_D0A : BaseMenuDialog
    {

   
        public override void BarCodeScanInput(string barcode)
        {


        }

        private DataRow _linkRow = null;
        private acGridView _linkView = null;
        private string _flag = null;

        public POP06A_D0A(DataRow linkRow, acGridView linkView, String flag)
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.FIXED;

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            //acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.KeyColumn = new string[] { "EMP_CODE" };



            //작업자 설정

            //acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            //acGridView2.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView2.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            //acGridView2.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");

            acGridView2.KeyColumn = new string[] { "EMP_CODE" };

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView2.MouseDown += acGridView2_MouseDown;

            _linkRow = linkRow;
            _linkView = linkView;
            _flag = flag;
        }


        public override void DialogInit()
        {
            base.DialogInit();
        }

        public override void DialogNew()
        {
        }

        public override void DialogOpen()
        {
            
        }

        public override void DialogInitComplete()
        {
            ///모든 사원 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = "P008";
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];


            ///추가된 사원 불러오기
            DataTable paramTable2 = new DataTable("RQSTDT");
            paramTable2.Columns.Add("PLT_CODE", typeof(String));
            paramTable2.Columns.Add("PT_ID", typeof(String));
            paramTable2.Columns.Add("FLAG", typeof(String));

            DataRow paramRow2 = paramTable2.NewRow();
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow2["PT_ID"] = _linkRow["PT_ID"];
            paramRow2["FLAG"] = _flag;

            paramTable2.Rows.Add(paramRow2);
            DataSet paramSet2 = new DataSet();
            paramSet2.Tables.Add(paramTable2);

            DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "POP06A_SER4", paramSet2, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet2.Tables["RSLTDT"];

            base.DialogInitComplete();
        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    acGridView1.EndEditor();

                    //DataView dv = acGridView1.GetDataSourceView("SEL = '1'");

                    //if (dv.Count == 0)
                    //{
                        acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
                    //}
                    //else
                    //{
                    //    int cnt = dv.Count;

                    //    for (int i = 0; i < cnt; i++)
                    //    {
                    //        acGridView1.DeleteMappingRow(dv[0].Row);
                    //    }
                    //}
                }

            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.InRow && hitInfo.InRowCell)
                {
                    acGridView2.EndEditor();

                    //DataView dv = acGridView2.GetDataSourceView("SEL = '1'");

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    //if (dv.Count == 0)
                    //{
                        DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + focusRow["EMP_CODE"].ToString() + "'");

                        //작업자 목록에 없으면 추가
                        if (availEmpView.Count == 0)
                        {
                            //focusRow["SEL"] = "0";
                            acGridView1.AddRow(focusRow);
                        }
                    //}
                    //else
                    //{
                    //    int cnt = dv.Count;

                    //    for (int i = 0; i < cnt; i++)
                    //    {
                    //        DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + dv[0]["EMP_CODE"].ToString() + "'");

                    //        //작업자 목록에 없으면 추가
                    //        if (availEmpView.Count == 0)
                    //        {
                    //            DataRow addRow = dv[0].Row.NewCopy();
                    //            addRow["SEL"] = "0";
                    //            acGridView1.AddRow(addRow);
                    //        }

                    //        dv[0]["SEL"] = "0";
                    //    }
                    //}




                }

            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            DataTable masterTable = new DataTable("RQSTDT");
            masterTable.Columns.Add("PLT_CODE", typeof(String));
            masterTable.Columns.Add("PROD_CODE", typeof(String));
            masterTable.Columns.Add("PT_ID", typeof(String));
            masterTable.Columns.Add("FLAG", typeof(String));

            DataRow masterRow = masterTable.NewRow();
            masterRow["PLT_CODE"] = acInfo.PLT_CODE;
            masterRow["PROD_CODE"] = _linkRow["PROD_CODE"];
            masterRow["PT_ID"] = _linkRow["PT_ID"];
            masterRow["FLAG"] = _flag;

            masterTable.Rows.Add(masterRow);

            DataTable paramTable = new DataTable("RQSTDT_EMP");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("PT_ID", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("FLAG", typeof(String)); 

            DataTable paramTable2 = new DataTable("RQSTDT2");
            paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable2.Columns.Add("PT_ID", typeof(String)); //
            paramTable2.Columns.Add("EMPS", typeof(String)); //
            paramTable2.Columns.Add("FLAG", typeof(String));

            DataView availEmpData = acGridView1.GetDataSourceView();
            string assyEmps = "";
            foreach (DataRowView empRowView in availEmpData)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = _linkRow["PROD_CODE"];
                paramRow["PT_ID"] = _linkRow["PT_ID"];
                paramRow["EMP_CODE"] = empRowView["EMP_CODE"];
                paramRow["FLAG"] = _flag;
                
                paramTable.Rows.Add(paramRow);

                assyEmps += empRowView["EMP_NAME"].ToString() + ", ";
            }

            if (assyEmps != "")
            {
                assyEmps = assyEmps.Substring(0, assyEmps.Length - 2);
            }

            DataRow paramRow2 = paramTable2.NewRow();
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow2["PT_ID"] = _linkRow["PT_ID"];
            paramRow2["EMPS"] = assyEmps;
            paramRow2["FLAG"] = _flag;
            paramTable2.Rows.Add(paramRow2);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(masterTable);
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTable2);

            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "POP06A_INS", paramSet, "RQSTDT", "RSLTDT",
             QuickSave,
             QuickException);

        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, false);
                }

                this.Close();
                //DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}