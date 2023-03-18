using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace PLN
{
    public sealed partial class PLN02A_D1A : BaseMenuDialog
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

       

        private acTreeList _LinkView = null;
        private acGridView _LinkGridView = null;

        public PLN02A_D1A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;
            
            _LinkGridView = linkView;

            Initialize();

        }
        public PLN02A_D1A(acTreeList linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;

            Initialize();
            
        }

        private void Initialize()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("PT_ID", "품목ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("O_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("O_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MATERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("Surface_Treat", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
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
            //새로 만들기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //수주코드/명 LIKE 검색

            DataRow linkRow = (DataRow)_LinkData;

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = linkRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "PLN02A_SER4", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            base.DialogOpen();

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            try
            {
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private DataSet SaveData()
        {

            acGridView1.EndEditor();

            DataRow linkRow = ((DataRow)_LinkData);

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PT_ID", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            if (selectedView.Count == 0)
            {
                DataRow paramRow2 = paramTable.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["PT_ID"] = focusRow["PT_ID"];
                paramRow2["PROD_CODE"] = linkRow["PROD_CODE"];
                paramTable.Rows.Add(paramRow2);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow2 = paramTable.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["PT_ID"] = selectedView[i]["PT_ID"];
                    paramRow2["PROD_CODE"] = linkRow["PROD_CODE"];
                    paramTable.Rows.Add(paramRow2);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;

        }


        private string GetSplitData(string value)
        {
            try
            {

                string[] values = value.Split(':');
                return values[values.Length - 1];
            }
            catch
            {
                return value;
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {
                DataSet paramSet = SaveData();

                if (paramSet != null)
                {

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "PLN02A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("MDFY_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("MDFY_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                //frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
    }
}