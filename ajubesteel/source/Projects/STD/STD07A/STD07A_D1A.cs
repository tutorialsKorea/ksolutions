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
    public sealed partial class STD07A_D1A : BaseMenuDialog
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

        private acGridView _LinkView1 = null;
        private acGridView _LinkView2 = null;



        public STD07A_D1A(acGridView linkView1, acGridView linkView2, object linkData)
        {

            InitializeComponent();

            _LinkView1 = linkView1;
            _LinkView2 = linkView2;
            _LinkData = linkData;
        }

        public override void DialogInit()
        {
            acLayoutControl1.KeyColumns = new string[] { "TL_CODE" };

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            acDateEdit1.EditValue = DateTime.Today;

            base.DialogInit();

        }

        public override void DialogInitComplete()
        {



            base.DialogInitComplete();
        }


        public override void DialogNew()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;
            acLayoutControl1.DataBind(linkRow, true);

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;
            acLayoutControl1.DataBind(linkRow, true);

            base.DialogOpen();
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

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                if (layoutRow["YPGO_DATE"].toDateTime() > DateTime.Today)
                {
                    acMessageBox.Show(this, "입고일이 오늘 이후 입니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (layoutRow["ADD_QTY"].toInt() <= 0)
                {
                    acMessageBox.Show(this, "입고 수량을 확인해 주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("TL_CODE", typeof(String));
                paramTable.Columns.Add("ADD_QTY", typeof(decimal));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["ADD_QTY"] = layoutRow["ADD_QTY"];
                paramTable.Rows.Add(paramRow);


                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("TL_CODE", typeof(String)); //
                paramTable2.Columns.Add("TL_NAME", typeof(String)); //
                paramTable2.Columns.Add("TL_STAT", typeof(String)); //
                paramTable2.Columns.Add("YPGO_DATE", typeof(String)); //
                paramTable2.Columns.Add("REG_EMP", typeof(String)); //

                for (int i = 0; i < layoutRow["ADD_QTY"].toInt(); i++)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["TL_CODE"] = layoutRow["TL_CODE"];
                    paramRow2["TL_NAME"] = layoutRow["TL_NAME"];
                    paramRow2["TL_STAT"] = acStdCodes.GetCodeByNameServer("T005", "신품");
                    paramRow2["YPGO_DATE"] = layoutRow["YPGO_DATE"].toDateString("yyyyMMdd");
                    paramRow2["REG_EMP"] = acInfo.UserID;
                    paramTable2.Rows.Add(paramRow2);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
              this, QBiz.emExecuteType.NEW, "STD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
              QuickSave,
              QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 저장 후 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                if (layoutRow["YPGO_DATE"].toDateTime() > DateTime.Today)
                {
                    acMessageBox.Show(this, "입고일이 오늘 이후 입니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (layoutRow["ADD_QTY"].toInt() <= 0)
                {
                    acMessageBox.Show(this, "입고 수량을 확인해 주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("TL_CODE", typeof(String));
                paramTable.Columns.Add("ADD_QTY", typeof(decimal));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["ADD_QTY"] = layoutRow["ADD_QTY"];
                paramTable.Rows.Add(paramRow);


                DataTable paramTable2 = new DataTable("RQSTDT_DETAIL");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable2.Columns.Add("TL_CODE", typeof(String)); //
                paramTable2.Columns.Add("TL_NAME", typeof(String)); //
                paramTable2.Columns.Add("TL_STAT", typeof(String)); //
                paramTable2.Columns.Add("YPGO_DATE", typeof(String)); //
                paramTable2.Columns.Add("REG_EMP", typeof(String)); //

                for (int i = 0; i < layoutRow["ADD_QTY"].toInt(); i++)
                {
                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["TL_CODE"] = layoutRow["TL_CODE"];
                    paramRow2["TL_NAME"] = layoutRow["TL_NAME"];
                    paramRow2["TL_STAT"] = acStdCodes.GetCodeByNameServer("T005", "신품");
                    paramRow2["YPGO_DATE"] = layoutRow["YPGO_DATE"].toDateString("yyyyMMdd");
                    paramRow2["REG_EMP"] = acInfo.UserID;
                    paramTable2.Rows.Add(paramRow2);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "STD07A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
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
                    this._LinkView1.UpdateMapingRow(row, true);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT_DETAIL"].Rows)
                {
                    this._LinkView2.UpdateMapingRow(row, true);
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
                    this._LinkView1.UpdateMapingRow(row, true);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT_DETAIL"].Rows)
                {
                    this._LinkView2.UpdateMapingRow(row, true);
                }

                this.Close();
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
                    this._LinkView2.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                //if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                //{
                //    return;
                //}

                //DataRow linkRow = this._LinkData as DataRow;


                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("TL_CODE", typeof(String)); //
                //paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["TL_CODE"] = linkRow["TL_CODE"];
                //paramRow["DEL_EMP"] = acInfo.UserID;
                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.DEL,
                //"STD07A_DEL", paramSet, "RQSTDT", "",
                //QuickDEL,
                //QuickException);

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
    }
}