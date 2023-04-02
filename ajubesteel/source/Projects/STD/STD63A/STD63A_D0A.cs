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
using DSTD;

namespace STD
{
    public sealed partial class STD63A_D0A : BaseMenuDialog
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

        private string CAT_CODE = null;

        public STD63A_D0A(string CAT_CODE, acGridView linkView, object linkData)
        {
            this.CAT_CODE = CAT_CODE;

            _LinkData = linkData;

            _LinkView = linkView;

            InitializeComponent();

        }

        public override void DialogInit()
        {
#if DEBUG

#endif
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("CAT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = TSTD_CODES.비가동구분;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            // 품목(중분류)
            (acLayoutControl1.GetEditor("MDR_TCODE") as acLookupEdit).SetData("CD_NAME", "CD_CODE", "STD14A_SER2", paramSet, "RQSTDT", "RSLTDT");

            // 품목구분
            paramSet.Tables["RQSTDT"].Rows[0]["CAT_CODE"] = TSTD_CODES.비가동원인;
            paramSet.Tables.Remove("RSLTDT");
            (acLayoutControl1.GetEditor("MDR_RCODE") as acLookupEdit).SetData("CD_NAME", "CD_CODE", "STD14A_SER2", paramSet, "RQSTDT", "RSLTDT");

            acLayoutControl1.KeyColumns = new string[] { "MDR_TCODE", "MDR_RCODE" };

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

            acLayoutControl1.DataBind((DataRow)_LinkData, true);

        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));

                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MDR_TCODE", typeof(String));
                paramTable.Columns.Add("MDR_RCODE", typeof(String));
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MDR_TCODE"] = layoutRow["MDR_TCODE"];
                paramRow["MDR_RCODE"] = layoutRow["MDR_RCODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD63A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
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
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow dr = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MDR_TCODE", typeof(String));
                paramTable.Columns.Add("MDR_RCODE", typeof(String));
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("DATA_FLAG", typeof(Byte));
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MDR_TCODE"] = dr["MDR_TCODE"];
                paramRow["MDR_RCODE"] = dr["MDR_RCODE"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["DATA_FLAG"] = "0";
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD63A_INS", paramSet, "RQSTDT", "RSLTDT",
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

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("MDR_TCODE").FocusEdit();
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

                DataRow dr = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MDR_TCODE", typeof(String));
                paramTable.Columns.Add("MDR_RCODE", typeof(String));
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("DATA_FLAG", typeof(String));
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰  기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MDR_TCODE"] = dr["MDR_TCODE"];
                paramRow["MDR_RCODE"] = dr["MDR_RCODE"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["DATA_FLAG"] = "0";
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                        "STD63A_INS", paramSet, "RQSTDT", "RSLTDT",
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

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


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




    }
}