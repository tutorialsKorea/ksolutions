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

namespace TOL
{
    public sealed partial class TOL03A_D2A : BaseMenuDialog
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


        public TOL03A_D2A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkView = linkView;
            _LinkData = linkData;
        }

        public override void DialogInit()
        {
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            base.DialogInit();

        }

        public override void DialogInitComplete()
        {

            acLayoutControl1.GetEditor("TDU_DATE").Value = DateTime.Now;
            acLayoutControl1.GetEditor("TDU_EMP").Value = acInfo.UserID;

            base.DialogInitComplete();
        }


        public override void DialogNew()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기
            //barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

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

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("TDU_NO", typeof(String));
                paramTable.Columns.Add("TDU_SEQ", typeof(String));
                paramTable.Columns.Add("TDU_DATE", typeof(String));
                paramTable.Columns.Add("TDU_EMP", typeof(String));
                paramTable.Columns.Add("SCOMMENT", typeof(String));

                DataView selectedView = _LinkView.GetDataSourceView("SEL='1'");

                if (selectedView.Count == 0)
                {
                    DataRow focusRow = _LinkView.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TDU_NO"] = focusRow["TDU_NO"];
                    paramRow["TDU_SEQ"] = focusRow["TDU_SEQ"];
                    paramRow["TDU_DATE"] = layoutRow["TDU_DATE"];
                    paramRow["TDU_EMP"] = layoutRow["TDU_EMP"];
                    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    for(int i=0;i<selectedView.Count;i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["TDU_NO"] = selectedView[i]["TDU_NO"];
                        paramRow["TDU_SEQ"] = selectedView[i]["TDU_SEQ"];
                        paramRow["TDU_DATE"] = layoutRow["TDU_DATE"];
                        paramRow["TDU_EMP"] = layoutRow["TDU_EMP"];
                        paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "TOL03A_UPD", paramSet, "RQSTDT", "RSLTDT",
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
                    _LinkView.UpdateMapingRow(row, false);
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
                //"TOL03A_DEL", paramSet, "RQSTDT", "",
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