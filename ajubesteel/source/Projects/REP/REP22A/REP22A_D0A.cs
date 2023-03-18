using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace REP
{
    public partial class REP22A_D0A : BaseMenuDialog
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


        public REP22A_D0A()
        {
            InitializeComponent();
        }

        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;            
            acGridView1.AddTextEdit("DES_RATE", "설계", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("MILL_RATE", "밀링", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("CAM_RATE", "CAM", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("MCT_RATE", "가공", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("SIDE_RATE", "후가공", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("INS_RATE", "검사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("ASSY_RATE", "조립", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("SHIP_RATE", "출하", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView2.AddTextEdit("COST_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("COST_FLAG", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("DES_COST", "설계", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("MILL_COST", "밀링", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("CAM_COST", "CAM", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("MCT_COST", "가공", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("SIDE_COST", "후가공", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("INS_COST", "검사", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("ASSY_COST", "조립", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.AddTextEdit("SHIP_COST", "출하", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView2.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView3.AddDateEdit("MONTH", "월", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MONTH_DATE);
            acGridView3.AddTextEdit("DOLLAR", "달러환율", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView3.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView4.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView4.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_DES_TIME", "설계", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_CAM_TIME", "CAM", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_MILL_TIME", "밀링", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_SIDE_TIME", "후가공", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_INS_TIME", "검사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_ASSY_TIME", "조립", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("COST_SHIP_TIME", "출하", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView4.Columns["GRID_ROW_SEQ"].Visible = false;

            acGridView4.KeyColumn = new string[] { "PART_CODE" };


            acDateEdit1.Properties.EditMask = "yyyy";

            acDateEdit1.Value = DateTime.Now;

            acGridView2.ShowGridMenuEx += acGridView2_ShowGridMenuEx;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();
        }

        public override void DialogInitComplete()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("YEAR", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = acDateEdit1.Value;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "REP22A_SER2", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT2"];
            acGridView3.GridControl.DataSource = resultSet.Tables["RSLTDT3"];
            acGridView4.GridControl.DataSource = resultSet.Tables["RSLTDT4"];
            base.DialogInitComplete();
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell || e.HitInfo.HitTest == GridHitTest.EmptyRow)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "YEAR":

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("YEAR", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["YEAR"] = acDateEdit1.Value;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "REP22A_SER3", paramSet, "RQSTDT", "RSLTDT");

                    acGridView3.GridControl.DataSource = resultSet.Tables["RSLTDT"];

                    if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
                    {
                        DataTable dt = new DataTable("RSLTDT");
                        dt.Columns.Add("PLT_CODE", typeof(string));
                        dt.Columns.Add("MONTH", typeof(string));
                        dt.Columns.Add("DOLLAR", typeof(string));

                        for (int i = 0; i < 12; i++)
                        {
                            DataRow newRow = dt.NewRow();
                            newRow["PLT_CODE"] = acInfo.PLT_CODE;
                            newRow["MONTH"] = acDateEdit1.Value + (i + 1).ToString().PadLeft(2, '0');
                            newRow["DOLLAR"] = 1.0;

                            dt.Rows.Add(newRow);
                        }

                        acGridView3.GridControl.DataSource = dt;
                    }

                    break;
            }
        }

        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();

        }

        public override void DialogOpen()
        {

            //열기

            base.DialogOpen();

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                acGridView1.EndEditor();
                acGridView2.EndEditor();
                acGridView3.EndEditor();

                DataTable partRateTable = new DataTable("RQSTDT_PART_RATE");
                partRateTable.Columns.Add("PLT_CODE", typeof(string));
                partRateTable.Columns.Add("DES_RATE", typeof(decimal));
                partRateTable.Columns.Add("MILL_RATE", typeof(decimal));
                partRateTable.Columns.Add("CAM_RATE", typeof(decimal));
                partRateTable.Columns.Add("MCT_RATE", typeof(decimal));
                partRateTable.Columns.Add("SIDE_RATE", typeof(decimal));
                partRateTable.Columns.Add("INS_RATE", typeof(decimal));
                partRateTable.Columns.Add("ASSY_RATE", typeof(decimal));
                partRateTable.Columns.Add("SHIP_RATE", typeof(decimal));


                DataTable costTypeTable = new DataTable("RQSTDT_COST_TYPE");
                costTypeTable.Columns.Add("PLT_CODE", typeof(string));
                costTypeTable.Columns.Add("COST_TYPE", typeof(string));
                costTypeTable.Columns.Add("COST_FLAG", typeof(string));
                costTypeTable.Columns.Add("DES_COST", typeof(decimal));
                costTypeTable.Columns.Add("MILL_COST", typeof(decimal));
                costTypeTable.Columns.Add("CAM_COST", typeof(decimal));
                costTypeTable.Columns.Add("MCT_COST", typeof(decimal));
                costTypeTable.Columns.Add("SIDE_COST", typeof(decimal));
                costTypeTable.Columns.Add("INS_COST", typeof(decimal));
                costTypeTable.Columns.Add("ASSY_COST", typeof(decimal));
                costTypeTable.Columns.Add("SHIP_COST", typeof(decimal));

                DataTable exchangeTable = new DataTable("RQSTDT_EXCHANGE");
                exchangeTable.Columns.Add("PLT_CODE", typeof(string));
                exchangeTable.Columns.Add("MONTH", typeof(string));
                exchangeTable.Columns.Add("DOLLAR", typeof(decimal));


                DataView dv1 = acGridView1.GetDataSourceView();

                for (int i = 0; i < dv1.Count; i++)
                {
                    DataRow newRow1 = partRateTable.NewRow();
                    newRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow1["DES_RATE"] = dv1[i]["DES_RATE"];
                    newRow1["MILL_RATE"] = dv1[i]["MILL_RATE"];
                    newRow1["CAM_RATE"] = dv1[i]["CAM_RATE"];
                    newRow1["MCT_RATE"] = dv1[i]["MCT_RATE"];
                    newRow1["SIDE_RATE"] = dv1[i]["SIDE_RATE"];
                    newRow1["INS_RATE"] = dv1[i]["INS_RATE"];
                    newRow1["ASSY_RATE"] = dv1[i]["ASSY_RATE"];
                    newRow1["SHIP_RATE"] = dv1[i]["SHIP_RATE"];

                    partRateTable.Rows.Add(newRow1);
                }

                DataView dv2 = acGridView2.GetDataSourceView();

                for (int i = 0; i < dv2.Count; i++)
                {
                    DataRow newRow2 = costTypeTable.NewRow();
                    newRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow2["COST_TYPE"] = dv2[i]["COST_TYPE"];
                    newRow2["COST_FLAG"] = dv2[i]["COST_FLAG"];
                    newRow2["DES_COST"] = dv2[i]["DES_COST"];
                    newRow2["MILL_COST"] = dv2[i]["MILL_COST"];
                    newRow2["CAM_COST"] = dv2[i]["CAM_COST"];
                    newRow2["MCT_COST"] = dv2[i]["MCT_COST"];
                    newRow2["SIDE_COST"] = dv2[i]["SIDE_COST"];
                    newRow2["INS_COST"] = dv2[i]["INS_COST"];
                    newRow2["ASSY_COST"] = dv2[i]["ASSY_COST"];
                    newRow2["SHIP_COST"] = dv2[i]["SHIP_COST"];

                    costTypeTable.Rows.Add(newRow2);
                }


                DataView dv3 = acGridView3.GetDataSourceView();

                for (int i = 0; i < dv3.Count; i++)
                {
                    DataRow newRow3 = exchangeTable.NewRow();
                    newRow3["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow3["MONTH"] = dv3[i]["MONTH"].toDateString("yyyyMM");
                    newRow3["DOLLAR"] = dv3[i]["DOLLAR"];

                    exchangeTable.Rows.Add(newRow3);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(partRateTable);
                paramSet.Tables.Add(costTypeTable);
                paramSet.Tables.Add(exchangeTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "REP22A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정


            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
       
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);

                if (this.DialogMode == emDialogMode.NEW)
                {

                    //클리어


                    //this.barItemClear_ItemClick(null, null);
                }
                else if (this.DialogMode == emDialogMode.OPEN)
                {

                    this.Close();

                    //갱신

                    ((BaseMenu)this.ParentControl).DataRefresh(null);

                }
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기
            if (!base.ChildFormContains("NEW"))
            {

                REP22A_D1A frm = new REP22A_D1A(acGridView1);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                frm.Show(this);

            }
            else
            {
                base.ChildFormFocus("NEW");
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (!base.ChildFormContains(string.Format("{0}", focusRow["VEN_CODE"])))
            {

                REP06A_D1A frm = new REP06A_D1A(acGridView1, focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd(string.Format("{0}", focusRow["VEN_CODE"]), frm);

                frm.Show(this);

            }
            else
            {
                base.ChildFormFocus(string.Format("{0}", focusRow["VEN_CODE"]));
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //


                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CODE"] = focusRow["VEN_CODE"];

                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "REP06A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acTabControl1.SelectedTabPage != acTabPage2) return;

            if (!base.ChildFormContains("NEW"))
            {

                REP22A_D1A frm = new REP22A_D1A(acGridView4);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                frm.Show(this);

            }
            else
            {
                base.ChildFormFocus("NEW");
            }
        }
    }
}
