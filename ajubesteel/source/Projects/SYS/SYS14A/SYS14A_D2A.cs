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
    public sealed partial class SYS14A_D2A : BaseMenuDialog
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

        public SYS14A_D2A(DataRow linkData)
        {
            InitializeComponent();
            _LinkData = linkData;
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.GetEditor("WORK_DATE").Value = acDateEdit.GetNowDateFromServer();

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind(_LinkData as DataRow, false);
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

                acLayoutControl1.GetEditor("WORK_DATE").FocusEdit();

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

                this.OutputData = layoutRow;

                DialogResult = DialogResult.OK;

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

                this.OutputData = layoutRow;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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