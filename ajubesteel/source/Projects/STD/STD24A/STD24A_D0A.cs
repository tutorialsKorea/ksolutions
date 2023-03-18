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
    public sealed partial class STD24A_D0A : BaseMenuDialog
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

        public STD24A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            this._LinkData = linkData;

            this._LinkView = linkView;

            acLayoutControl1.KeyColumns = new string[] { "WORK_CODE" };

        }

        public override void DialogInit()
        {
            (acLayoutControl1.GetEditor("INPUT_TYPE") as acLookupEdit).SetCode("W004");

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

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
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("WORK_NAME", typeof(string));
                paramTable.Columns.Add("INPUT_TYPE", typeof(string));
                paramTable.Columns.Add("SCOMMENT", typeof(string));

                paramTable.Columns.Add("IS_HALF", typeof(string));
                paramTable.Columns.Add("IS_HOLI", typeof(string));
                paramTable.Columns.Add("IS_PRE", typeof(string));
                paramTable.Columns.Add("IS_OUT", typeof(string));
                paramTable.Columns.Add("IS_YESTERDAY", typeof(string));
                paramTable.Columns.Add("IS_UPD", typeof(string));
                paramTable.Columns.Add("WORK_SEQ", typeof(int));

                paramTable.Columns.Add("START_TIME", typeof(string));

                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["WORK_NAME"] = layoutRow["WORK_NAME"];
                paramRow["INPUT_TYPE"] = layoutRow["INPUT_TYPE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramRow["IS_HALF"] = layoutRow["IS_HALF"];
                paramRow["IS_HOLI"] = layoutRow["IS_HOLI"];
                paramRow["IS_PRE"] = layoutRow["IS_PRE"];
                paramRow["IS_OUT"] = layoutRow["IS_OUT"];
                paramRow["IS_YESTERDAY"] = layoutRow["IS_YESTERDAY"];
                paramRow["IS_UPD"] = layoutRow["IS_UPD"];
                paramRow["WORK_SEQ"] = layoutRow["WORK_SEQ"];

                string strStime = "";

                if (layoutRow["START_TIME"].ToString().Length > 0)
                {
                    if (layoutRow["START_TIME"].ToString().IndexOf(':') > -1)
                    {
                        if (layoutRow["START_TIME"].ToString().Length == 4)
                        {
                            layoutRow["START_TIME"] = "0" + layoutRow["START_TIME"].ToString();
                        }

                        strStime = layoutRow["START_TIME"].ToString().Substring(0, 2) + layoutRow["START_TIME"].ToString().Substring(3, 2);
                    }
                    else
                    {
                        strStime = layoutRow["START_TIME"].ToString();
                    }
                }

                paramRow["START_TIME"] = strStime;

                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD24A_INS", paramSet, "RQSTDT,RQSTDT_CAUSE", "RSLTDT",
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
                paramTable.Columns.Add("WORK_CODE", typeof(string));
                paramTable.Columns.Add("WORK_NAME", typeof(string));
                paramTable.Columns.Add("INPUT_TYPE", typeof(string));
                paramTable.Columns.Add("SCOMMENT", typeof(string));

                paramTable.Columns.Add("IS_HALF", typeof(string));
                paramTable.Columns.Add("IS_HOLI", typeof(string));
                paramTable.Columns.Add("IS_PRE", typeof(string));
                paramTable.Columns.Add("IS_OUT", typeof(string));
                paramTable.Columns.Add("IS_YESTERDAY", typeof(string));
                paramTable.Columns.Add("IS_UPD", typeof(string));
                paramTable.Columns.Add("WORK_SEQ", typeof(int));

                paramTable.Columns.Add("START_TIME", typeof(string));

                paramTable.Columns.Add("OVERWRITE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_CODE"] = layoutRow["WORK_CODE"];
                paramRow["WORK_NAME"] = layoutRow["WORK_NAME"];
                paramRow["INPUT_TYPE"] = layoutRow["INPUT_TYPE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramRow["IS_HALF"] = layoutRow["IS_HALF"];
                paramRow["IS_HOLI"] = layoutRow["IS_HOLI"];
                paramRow["IS_PRE"] = layoutRow["IS_PRE"];
                paramRow["IS_OUT"] = layoutRow["IS_OUT"];
                paramRow["IS_YESTERDAY"] = layoutRow["IS_YESTERDAY"];
                paramRow["IS_UPD"] = layoutRow["IS_UPD"];
                paramRow["WORK_SEQ"] = layoutRow["WORK_SEQ"];

                string strStime = "";

                if (layoutRow["START_TIME"].ToString().Length > 0)
                {
                    if (layoutRow["START_TIME"].ToString().IndexOf(':') > -1)
                    {
                        if (layoutRow["START_TIME"].ToString().Length == 4)
                        {
                            layoutRow["START_TIME"] = "0" + layoutRow["START_TIME"].ToString();
                        }

                        strStime = layoutRow["START_TIME"].ToString().Substring(0, 2) + layoutRow["START_TIME"].ToString().Substring(3, 2);
                    }
                    else
                    {
                        strStime = layoutRow["START_TIME"].ToString();
                    }
                }

                paramRow["START_TIME"] = strStime;

                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD24A_INS", paramSet, "RQSTDT", "RSLTDT",
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
            else
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}