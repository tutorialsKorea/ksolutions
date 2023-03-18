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

namespace SYS
{
    public sealed partial class SYS14A_D3A : BaseMenuDialog
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


        private acBandGridView _linkView = null;

        public SYS14A_D3A(acBandGridView linkView)
        {
            InitializeComponent();
            _linkView = linkView;
        }

        public override void DialogInit()
        {

            (acLayoutControl1.GetEditor("DLOG_TYPE") as acLookupEdit).SetCode("S096");
            (acLayoutControl1.GetEditor("RELATED_PROD") as acLookupEdit).SetCode("S099");
            acLayoutControl1.GetEditor("DLOG_TYPE").Value = null;
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
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow[] selectedRows = _linkView.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //


                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = _linkView.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["DLOG_ID"] = focusRow["DLOG_ID"];
                    paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                    paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                    paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DLOG_ID"] = selectedRows[i]["DLOG_ID"];
                        paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                        paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                        paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS14A_INS4", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);




                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                //paramTable.Columns.Add("DLOG_TIME", typeof(decimal)); //
                //paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                //paramTable.Columns.Add("DLOG_ACT_FLAG", typeof(byte)); //


                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
                //paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                //paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                //paramRow["DLOG_ACT_FLAG"] = 1;

                //paramTable.Rows.Add(paramRow);

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

                DataRow[] selectedRows = _linkView.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                

                if (selectedRows.Length == 0)
                {
                    //단일
                    DataRow focusRow = _linkView.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["DLOG_ID"] = focusRow["DLOG_ID"];
                    paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                    paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];                    
                    paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중
                    for (int i = 0; selectedRows.Length > i; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DLOG_ID"] = selectedRows[i]["DLOG_ID"];
                        paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                        paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                        paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS14A_INS4", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);


                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                //paramTable.Columns.Add("DLOG_TIME", typeof(decimal)); //
                //paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                //paramTable.Columns.Add("DLOG_ACT_FLAG", typeof(byte)); //


                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
                //paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                //paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                //paramRow["DLOG_ACT_FLAG"] = 1;

                //paramTable.Rows.Add(paramRow);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
            {
                _linkView.UpdateMapingRow(row, false);
            }
            _linkView.ClearSelection();

            DialogResult = DialogResult.OK;
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