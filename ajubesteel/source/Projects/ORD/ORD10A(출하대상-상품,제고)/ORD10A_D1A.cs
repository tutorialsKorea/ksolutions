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
using DevExpress.XtraGrid.Views.Grid;

namespace ORD
{
    public sealed partial class ORD10A_D1A : BaseMenuDialog
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
        public ORD10A_D1A(DataSet dsEmp)
        {
            InitializeComponent();
            
            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.KeyColumn = new string[] { "EMP_CODE" };



            //작업자 설정

            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            acGridView2.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");

            acGridView2.KeyColumn = new string[] { "EMP_CODE" };


            //acGridView2.Columns["ORG_NAME"].GroupIndex = 0;
            //acGridView2.Columns["ORG_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

            acGridView1.MouseDown += acGridView1_MouseDown;
            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView2.MouseDown += acGridView2_MouseDown;
            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;

            if (dsEmp != null)
            {
                acGridView1.GridControl.DataSource = dsEmp.Tables["RQSTDT2"].Copy();
            }

        }

        private void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        private void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.InRow == true && hitInfo.RowHandle >= 0)
                {
                    acGridView1.EndEditor();

                    DataView dv = acGridView1.GetDataSourceView("SEL = '1'");

                    if (dv.Count == 0)
                    {
                        acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
                    }
                    else
                    {
                        int cnt = dv.Count;

                        for (int i = 0; i < cnt; i++)
                        {
                            acGridView1.DeleteMappingRow(dv[0].Row);
                        }
                    }
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

                    DataView dv = acGridView2.GetDataSourceView("SEL = '1'");

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (dv.Count == 0)
                    {
                        DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + focusRow["EMP_CODE"].ToString() + "'");

                        //작업자 목록에 없으면 추가
                        if (availEmpView.Count == 0)
                        {
                            focusRow["SEL"] = "0";
                            acGridView1.AddRow(focusRow);
                        }
                    }
                    else
                    {
                        int cnt = dv.Count;

                        for (int i = 0; i < cnt; i++)
                        {
                            DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + dv[0]["EMP_CODE"].ToString() + "'");

                            //작업자 목록에 없으면 추가
                            if (availEmpView.Count == 0)
                            {
                                DataRow addRow = dv[0].Row.NewCopy();
                                addRow["SEL"] = "0";
                                acGridView1.AddRow(addRow);
                            }

                            dv[0]["SEL"] = "0";
                        }
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
            ///모든 사원 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];

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
                paramTable.Columns.Add("OUT_EMP", typeof(String));

                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("ORG_NAME", typeof(String)); //
                paramTable2.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable2.Columns.Add("EMP_NAME", typeof(String)); //
                paramTable2.Columns.Add("SEL", typeof(String)); //

                DataView availEmpData = acGridView1.GetDataSourceView();

                string receiver = "";
                foreach (DataRowView empRowView in availEmpData)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["ORG_NAME"] = empRowView["ORG_NAME"];
                    paramRow2["EMP_CODE"] = empRowView["EMP_CODE"];
                    paramRow2["EMP_NAME"] = empRowView["EMP_NAME"];
                    paramTable2.Rows.Add(paramRow2);

                    receiver += empRowView["EMP_NAME"].ToString() +"("+ empRowView["EMP_CODE"].ToString() +")" + ", ";

                }
                if (receiver != "")
                {
                    receiver = receiver.Substring(0, receiver.Length - 2);
                }
                DataRow paramRow = paramTable.NewRow();
                paramRow["OUT_EMP"] = receiver;
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //추가
            acGridView2.EndEditor();

            DataView dv = acGridView2.GetDataSourceView("SEL = '1'");

            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (dv.Count == 0)
            {
                if (focusRow == null) return;

                DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + focusRow["EMP_CODE"].ToString() + "'");

                //작업자 목록에 없으면 추가
                if (availEmpView.Count == 0)
                {
                    focusRow["SEL"] = "0";
                    acGridView1.AddRow(focusRow);
                }
            }
            else
            {
                int cnt = dv.Count;

                for (int i = 0; i < cnt; i++)
                {
                    DataView availEmpView = acGridView1.GetDataSourceView("EMP_CODE = '" + dv[0]["EMP_CODE"].ToString() + "'");

                    //작업자 목록에 없으면 추가
                    if (availEmpView.Count == 0)
                    {
                        DataRow addRow = dv[0].Row.NewCopy();
                        addRow["SEL"] = "0";
                        acGridView1.AddRow(addRow);
                    }

                    dv[0]["SEL"] = "0";
                }
            }

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            acGridView1.EndEditor();

            DataView dv = acGridView1.GetDataSourceView("SEL = '1'");

            if (dv.Count == 0)
            {
                acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
            }
            else
            {
                int cnt = dv.Count;

                for (int i = 0; i < cnt; i++)
                {
                    acGridView1.DeleteMappingRow(dv[0].Row);
                }
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            GetEmp();
        }


        private void acTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmp();
            }
        }

        void GetEmp()
        {
            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_LIKE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];
        }
    }
}