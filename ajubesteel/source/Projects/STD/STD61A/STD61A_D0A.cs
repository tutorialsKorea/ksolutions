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

namespace STD
{
    public sealed partial class STD61A_D0A : BaseMenuDialog
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

        public STD61A_D0A(acGridView linkView, object linkData)
        {

            _LinkData = linkData;

            _LinkView = linkView;

            InitializeComponent();

        }

        public override void DialogInit()
        {
#if DEBUG
            acLayoutControl1.GetEditor("TRP_CODE").Value = "T";
            acLayoutControl1.GetEditor("TRP_TYPE").Value = "5톤";
            acLayoutControl1.GetEditor("TRP_NAME").Value = "서울1가1234";
            acLayoutControl1.GetEditor("TRP_OWNER").Value = "홍길동";
            acLayoutControl1.GetEditor("TRP_TEL").Value = "010-1234-1234";
#endif


            acLayoutControl1.KeyColumns = new string[] { "TRP_CODE" };

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
            //표준 코드 삭제

            try
            {

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TRP_TYPE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TRP_TYPE"] = layoutRow["TRP_TYPE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD61A_DEL", paramSet, "RQSTDT", "",
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

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("TRP_CODE", typeof(String));
                paramTable.Columns.Add("TRP_TYPE", typeof(String));
                paramTable.Columns.Add("TRP_NAME", typeof(String));
                paramTable.Columns.Add("TRP_OWNER", typeof(String));
                paramTable.Columns.Add("TRP_TEL", typeof(String));
                paramTable.Columns.Add("TRP_ACCT_HOLDR", typeof(String));
                paramTable.Columns.Add("TRP_BANK", typeof(String));
                paramTable.Columns.Add("TRP_ACCT_NO", typeof(String));
                paramTable.Columns.Add("TRP_BIZ_NO", typeof(String));
                paramTable.Columns.Add("TRP_COMPANY", typeof(String));
                paramTable.Columns.Add("TRP_CEO", typeof(String));
                paramTable.Columns.Add("TRP_REGION", typeof(String));
                paramTable.Columns.Add("TRP_TAX_INVOICE", typeof(Byte));
                paramTable.Columns.Add("TRP_RECEIPT", typeof(String));
                paramTable.Columns.Add("TRP_ACTIVE", typeof(Byte));
                paramTable.Columns.Add("SCOMMENT", typeof(String));
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("DATA_FLAG", typeof(String));
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TRP_CODE"] = layoutRow["TRP_CODE"];
                paramRow["TRP_TYPE"] = layoutRow["TRP_TYPE"];
                paramRow["TRP_NAME"] = layoutRow["TRP_NAME"];
                paramRow["TRP_OWNER"] = layoutRow["TRP_OWNER"];
                paramRow["TRP_TEL"] = layoutRow["TRP_TEL"];
                paramRow["TRP_ACCT_HOLDR"] = layoutRow["TRP_ACCT_HOLDR"];
                paramRow["TRP_BANK"] = layoutRow["TRP_BANK"];
                paramRow["TRP_ACCT_NO"] = layoutRow["TRP_ACCT_NO"];
                paramRow["TRP_BIZ_NO"] = layoutRow["TRP_BIZ_NO"];
                paramRow["TRP_COMPANY"] = layoutRow["TRP_COMPANY"];
                paramRow["TRP_CEO"] = layoutRow["TRP_CEO"];
                paramRow["TRP_REGION"] = layoutRow["TRP_REGION"];
                paramRow["TRP_TAX_INVOICE"] = layoutRow["TRP_TAX_INVOICE"];
                paramRow["TRP_RECEIPT"] = layoutRow["TRP_RECEIPT"];
                paramRow["TRP_ACTIVE"] = layoutRow["TRP_ACTIVE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["DATA_FLAG"] = "0";
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD61A_INS", paramSet, "RQSTDT", "RSLTDT",
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


                acLayoutControl1.GetEditor("CD_CODE").FocusEdit();
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


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("TRP_CODE", typeof(String));
                paramTable.Columns.Add("TRP_TYPE", typeof(String));
                paramTable.Columns.Add("TRP_NAME", typeof(String));
                paramTable.Columns.Add("TRP_OWNER", typeof(String));
                paramTable.Columns.Add("TRP_TEL", typeof(String));
                paramTable.Columns.Add("TRP_ACCT_HOLDR", typeof(String));
                paramTable.Columns.Add("TRP_BANK", typeof(String));
                paramTable.Columns.Add("TRP_ACCT_NO", typeof(String));
                paramTable.Columns.Add("TRP_BIZ_NO", typeof(String));
                paramTable.Columns.Add("TRP_COMPANY", typeof(String));
                paramTable.Columns.Add("TRP_CEO", typeof(String));
                paramTable.Columns.Add("TRP_REGION", typeof(String));
                paramTable.Columns.Add("TRP_TAX_INVOICE", typeof(Byte));
                paramTable.Columns.Add("TRP_RECEIPT", typeof(String));
                paramTable.Columns.Add("TRP_ACTIVE", typeof(Byte));
                paramTable.Columns.Add("SCOMMENT", typeof(String));
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("DATA_FLAG", typeof(String));
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TRP_CODE"] = layoutRow["TRP_CODE"];
                paramRow["TRP_TYPE"] = layoutRow["TRP_TYPE"];
                paramRow["TRP_NAME"] = layoutRow["TRP_NAME"];
                paramRow["TRP_OWNER"] = layoutRow["TRP_OWNER"];
                paramRow["TRP_TEL"] = layoutRow["TRP_TEL"];
                paramRow["TRP_ACCT_HOLDR"] = layoutRow["TRP_ACCT_HOLDR"];
                paramRow["TRP_BANK"] = layoutRow["TRP_BANK"];
                paramRow["TRP_ACCT_NO"] = layoutRow["TRP_ACCT_NO"];
                paramRow["TRP_BIZ_NO"] = layoutRow["TRP_BIZ_NO"];
                paramRow["TRP_COMPANY"] = layoutRow["TRP_COMPANY"];
                paramRow["TRP_CEO"] = layoutRow["TRP_CEO"];
                paramRow["TRP_REGION"] = layoutRow["TRP_REGION"];
                paramRow["TRP_TAX_INVOICE"] = layoutRow["TRP_TAX_INVOICE"];
                paramRow["TRP_RECEIPT"] = layoutRow["TRP_RECEIPT"];
                paramRow["TRP_ACTIVE"] = layoutRow["TRP_ACTIVE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["DATA_FLAG"] = "0";
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                        "STD61A_INS", paramSet, "RQSTDT", "RSLTDT",
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