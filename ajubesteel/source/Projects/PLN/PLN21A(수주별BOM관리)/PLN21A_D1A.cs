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
    public sealed partial class PLN21A_D1A : BaseMenuDialog
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

       

        private acGridView _LinkView = null;

        public PLN21A_D1A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;

            Initialize();

        }

        private void Initialize()
        {

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

            DataRow linkRow = _LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogOpen();

        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "IS_REMCT":

                    if (newValue != null)
                    {
                        if (newValue.ToString() == "1")
                        {
                            layout.GetEditor("IS_MODIFY").Value = "0";
                        }
                    }

                    break;

                case "IS_MODIFY":
                    if (newValue != null)
                    {
                        if (newValue.ToString() == "1")
                        {
                            layout.GetEditor("IS_REMCT").Value = "0";
                        }
                    }
                    break;
            }

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

            DataRow linkRow = ((DataRow)_LinkData);

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PT_ID", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("Material", typeof(String)); //
            paramTable.Columns.Add("Surface_Treat", typeof(String)); //
            paramTable.Columns.Add("After_Treat", typeof(String)); //
            paramTable.Columns.Add("IS_REVISION", typeof(byte)); //
            paramTable.Columns.Add("IS_REMCT", typeof(byte)); //
            paramTable.Columns.Add("IS_MODIFY", typeof(byte)); //

            DataRow paramRow2 = paramTable.NewRow();
            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow2["PT_ID"] = linkRow["PT_ID"];
            paramRow2["PROD_CODE"] = linkRow["PROD_CODE"];
            paramRow2["Material"] = layoutRow["MATERIAL"];
            paramRow2["Surface_Treat"] = layoutRow["SURFACE_TREAT"];
            paramRow2["After_Treat"] = layoutRow["AFTER_TREAT"];
            paramRow2["IS_REMCT"] = layoutRow["IS_REMCT"];
            paramRow2["IS_MODIFY"] = layoutRow["IS_MODIFY"];

            if (layoutRow["IS_REMCT"].ToString() == "1"
                || layoutRow["IS_MODIFY"].ToString() == "1")
            {
                paramRow2["IS_REVISION"] = "1";
            }

            paramTable.Rows.Add(paramRow2);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;

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
                    this, QBiz.emExecuteType.SAVE, "PLN21A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _LinkView.UpdateMapingRow(row, false);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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