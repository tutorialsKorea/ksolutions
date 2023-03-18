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
    public sealed partial class STD28A_D0A : BaseMenuDialog
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
        private acGridView _LinkView = null;

        public STD28A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("BVEN_TYPE") as acLookupEdit).SetCode("V001");
            (acLayoutControl1.GetEditor("BVEN_CURRENCY") as acLookupEdit).SetCode("V002");

            base.DialogInit();
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            acLayoutControl1.KeyColumns = new string[] { "BVEN_CODE" };
            acLayoutControl1.DataBind(this._LinkData as DataRow, true);
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BVEN_CODE", typeof(string));
                paramTable.Columns.Add("BVEN_NAME", typeof(string));
                paramTable.Columns.Add("BVEN_TYPE", typeof(string));
                paramTable.Columns.Add("BVEN_CURRENCY", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BVEN_CODE"] = layoutRow["BVEN_CODE"];
                paramRow["BVEN_NAME"] = layoutRow["BVEN_NAME"];
                paramRow["BVEN_TYPE"] = layoutRow["BVEN_TYPE"];
                paramRow["BVEN_CURRENCY"] = layoutRow["BVEN_CURRENCY"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD28A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;
                
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BVEN_CODE", typeof(string));
                paramTable.Columns.Add("BVEN_NAME", typeof(string));
                paramTable.Columns.Add("BVEN_TYPE", typeof(string));
                paramTable.Columns.Add("BVEN_CURRENCY", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BVEN_CODE"] = linkRow["BVEN_CODE"];
                paramRow["BVEN_NAME"] = layoutRow["BVEN_NAME"];
                paramRow["BVEN_TYPE"] = layoutRow["BVEN_TYPE"];
                paramRow["BVEN_CURRENCY"] = layoutRow["BVEN_CURRENCY"];
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
               
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD28A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

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
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {
                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else if (ex.ErrNumber == 300000)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}