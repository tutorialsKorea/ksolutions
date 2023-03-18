using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace HIS
{
    public sealed partial class HIS03A_D2A : BaseMenuDialog
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

     
        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

      

        public HIS03A_D2A(acGridView linkView, DataRow linkData)
        {

            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("INS_SEQ", "점검순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("INS_INTERVAL", "점검주기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S091");

            acGridView1.AddLookUpEdit("INS_ITEM", "점검항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S092");

            acGridView1.AddTextEdit("INS_METHOD", "점검방법", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("INS_SPEC", "검사 SPEC", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("INS_ACTION", "조치사항", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("LIMIT_LOW", "점검 하한치", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddTextEdit("LIMIT_HIGH", "점검 상한치", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddTextEdit("MEASURE", "측정치", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acGridView.emTextEditMask.NUMERIC);

            acGridView1.AddCheckEdit("INS_OK", "적합", "", false, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("INS_NG", "부적합", "", false, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddHidden("MC_INS_CODE", typeof(String));
            
            acGridView1.AddHidden("MC_CODE", typeof(String));

            // acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.CellValueChanged += acGridView1_CellValueChanged;

            acGridView1.KeyColumn = new string[] { "MC_INS_CODE" };

            acGridView1.Columns["INS_SEQ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;


        }



        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.GetEditor("INS_DATE").Value = DateTime.Now;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = _LinkData["MC_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD44A_SER2", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch,
                                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            try
            {

                DataTable paramTable = new DataTable("RQSTDT");
              //  paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_DATE", typeof(String)); //
                paramTable.Columns.Add("INS_CHARGE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
              //  paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = _LinkData["MC_CODE"];
                paramRow["INS_DATE"] = _LinkData["INS_DATE"].toDateString("yyyyMMdd");
                paramRow["INS_CHARGE"] = _LinkData["INS_CHARGE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD44A_SER3", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch2,
                                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 저장 후 닫기
            try
            {
                if (acGridView1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable mdfyDt = acGridControl1.GetAddModifyRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MRI_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_ITEM", typeof(String)); //
                paramTable.Columns.Add("INS_DATE", typeof(String)); //
                paramTable.Columns.Add("MEASURE", typeof(String)); //
                paramTable.Columns.Add("INS_OK", typeof(byte)); //
                paramTable.Columns.Add("INS_NG", typeof(byte)); //
                paramTable.Columns.Add("INS_CHARGE", typeof(String)); //


                foreach (DataRow dr in mdfyDt.Rows)
                {

                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = dr["MC_CODE"];
                    paramRow["MRI_CODE"] = dr["MRI_CODE"];
                    paramRow["INS_ITEM"] = dr["INS_ITEM"];
                    paramRow["INS_DATE"] = layoutRow["INS_DATE"].toDateString("yyyyMMdd");
                    paramRow["MEASURE"] = dr["MEASURE"];
                    paramRow["INS_OK"] = dr["INS_OK"];
                    paramRow["INS_NG"] = dr["INS_NG"];
                    paramRow["INS_CHARGE"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "HIS03A_INS3", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }



        void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            DataRow row = acGridView1.GetDataRow(e.RowHandle);

        
            switch (e.Column.FieldName)
            {
                case "MEASURE":

                    if (row["LIMIT_LOW"].toDecimal() <= row["MEASURE"].toDecimal() && row["MEASURE"].toDecimal() <= row["LIMIT_HIGH"].toDecimal())
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, acGridView1.Columns["INS_NG"], 0);
                        acGridView1.SetRowCellValue(e.RowHandle, acGridView1.Columns["INS_OK"], 1);
                    }
                    else
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, acGridView1.Columns["INS_OK"], 0);
                        acGridView1.SetRowCellValue(e.RowHandle, acGridView1.Columns["INS_NG"], 1);
                    }
                 break;
            }

        }



        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 저장
            try
            {
                if (acGridView1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable mdfyDt = acGridControl1.GetAddModifyRows();

                if (mdfyDt.Rows.Count == 0) { return; }
             
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MRI_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_ITEM", typeof(String)); //
                paramTable.Columns.Add("INS_DATE", typeof(String)); //
                paramTable.Columns.Add("MEASURE", typeof(String)); //
                paramTable.Columns.Add("INS_OK", typeof(byte)); //
                paramTable.Columns.Add("INS_NG", typeof(byte)); //
                paramTable.Columns.Add("INS_CHARGE", typeof(String)); //


                foreach (DataRow dr in mdfyDt.Rows)
                {

                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MC_CODE"] = dr["MC_CODE"];
                    paramRow["MRI_CODE"] = "";
                    paramRow["INS_ITEM"] = dr["INS_ITEM"];
                    paramRow["INS_DATE"] = layoutRow["INS_DATE"].toDateString("yyyyMMdd");
                    paramRow["MEASURE"] = dr["MEASURE"];
                    paramRow["INS_OK"] = dr["INS_OK"];
                    paramRow["INS_NG"] = dr["INS_NG"];
                    paramRow["INS_CHARGE"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "HIS03A_INS3", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

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

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this._LinkView.BestFitColumns();

                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this._LinkView.BestFitColumns();
                
                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

       

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acLayoutControl1.GetEditor("INS_DATE").Value = e.result.Tables["RSLTDT"].Rows[0]["INS_DATE"];
                
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
               acMessageBox.Show(this, ex);
        }

    }
}