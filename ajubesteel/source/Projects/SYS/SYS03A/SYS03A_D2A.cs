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

namespace SYS
{
    public sealed partial class SYS03A_D2A : BaseMenuDialog
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


        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }
        
        public SYS03A_D2A(object linkData, DataSet dsOrg)
        {
            InitializeComponent();

            _LinkData = linkData;


            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.KeyColumn = new string[] { "ORG_CODE" };



            acGridView2.GridType = acGridView.emGridType.AUTO_COL;

           // acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "ORG_CODE" };


           // acGridView2.Columns["ORG_NAME"].GroupIndex = 0;
           // acGridView2.Columns["ORG_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView2.MouseDown += acGridView2_MouseDown;

            if (dsOrg != null)
            {
                acGridView1.GridControl.DataSource = dsOrg.Tables["RQSTDT2"].Copy();
            }


        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {

                    acGridView2.AddRow(focusRow);

                    acGridView1.DeleteRow(acGridView1.FocusedRowHandle);

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
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataView availOrgView = acGridView1.GetDataSourceView("ORG_CODE = '" + focusRow["ORG_CODE"].ToString() + "'");

                    //부서 목록에 없으면 추가
                    if (availOrgView.Count == 0)
                    {
                        acGridView1.AddRow(focusRow);
                        acGridView2.DeleteRow(acGridView2.FocusedRowHandle);
                    }


                }

            }
        }

        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            
            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogInitComplete()
        {
            ///모든 부서 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD13A_SER4", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            DataRow dr = _LinkData as DataRow;

            base.DialogInitComplete();
        }

       
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
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
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("RECEIVER", typeof(String));

                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable2.Columns.Add("ORG_NAME", typeof(String)); //

                DataView availEmpData = acGridView1.GetDataSourceView();

                string receiver = "";
                foreach (DataRowView empRowView in availEmpData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["ORG_CODE"] = empRowView["ORG_CODE"];
                    paramRow2["ORG_NAME"] = empRowView["ORG_NAME"];
                    paramTable2.Rows.Add(paramRow2);

                    receiver += empRowView["ORG_NAME"].ToString() + "(" + empRowView["ORG_CODE"].ToString() + ")" + ", ";

                }
                if (receiver != "")
                {
                    receiver = receiver.Substring(0, receiver.Length - 2);
                }
                DataRow paramRow = paramTable.NewRow();
                paramRow["RECEIVER"] = receiver;
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                this.OutputData = paramSet;

                DialogResult = DialogResult.OK;

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


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}