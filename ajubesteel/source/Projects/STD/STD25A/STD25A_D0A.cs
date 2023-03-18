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
    public sealed partial class STD25A_D0A : BaseMenuDialog
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

        public STD25A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD25A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            (acLayoutControl1.GetEditor("WORK_CODE") as acLookupEdit).SetData("WORK_NAME", "WORK_CODE", resultSet.Tables["RSLTDT"]);


            base.DialogInit();
        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
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
                paramTable.Columns.Add("WT_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("WORK_START_HOUR", typeof(string));
                paramTable.Columns.Add("WORK_END_HOUR", typeof(string));
                paramTable.Columns.Add("WORK_RATE", typeof(decimal));
                paramTable.Columns.Add("NIGHT_FLAG", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WT_ID"] = null;
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["WORK_START_HOUR"] = layoutRow["WORK_START_HOUR"].ToString().Replace(":", "");//.toDateString("HHmm");
                paramRow["WORK_END_HOUR"] = layoutRow["WORK_END_HOUR"].ToString().Replace(":", "");//.toDateString("HHmm");
                paramRow["WORK_RATE"] = layoutRow["WORK_RATE"];
                paramRow["NIGHT_FLAG"] = layoutRow["NIGHT_FLAG"];
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD25A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                paramTable.Columns.Add("WT_ID", typeof(string));
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("WORK_START_HOUR", typeof(string));
                paramTable.Columns.Add("WORK_END_HOUR", typeof(string));
                paramTable.Columns.Add("WORK_RATE", typeof(decimal));
                paramTable.Columns.Add("NIGHT_FLAG", typeof(string));
                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WT_ID"] = linkRow["WT_ID"];
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["WORK_START_HOUR"] = layoutRow["WORK_START_HOUR"].ToString().Replace(":", "");//.toDateString("HHmm");
                paramRow["WORK_END_HOUR"] = layoutRow["WORK_END_HOUR"].ToString().Replace(":", "");//.toDateString("HHmm");
                paramRow["WORK_RATE"] = layoutRow["WORK_RATE"];
                paramRow["NIGHT_FLAG"] = layoutRow["NIGHT_FLAG"];
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
               
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD25A_INS", paramSet, "RQSTDT", "RSLTDT",
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