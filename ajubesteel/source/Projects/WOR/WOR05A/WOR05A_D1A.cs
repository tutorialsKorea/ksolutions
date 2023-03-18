using BizManager;
using CodeHelperManager;
using ControlManager;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraSpreadsheet;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR05A_D1A : BaseMenuDialog
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
        public WOR05A_D1A()
        {
            InitializeComponent();
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            (acLayoutControl1.GetEditor("PLAN_DEADLINE_DATE") as acDateEdit).Properties.UseMaskAsDisplayFormat = true;
            (acLayoutControl1.GetEditor("PLAN_DEADLINE_DATE") as acDateEdit).Properties.EditMask = "yyyy-MM-dd";


            string plan_deadline_date = acInfo.SysConfig.GetSysConfigByMemory("PLAN_DEADLINE_DATE");

            (acLayoutControl1.GetEditor("PLAN_DEADLINE_DATE") as acDateEdit).Value = plan_deadline_date.toDateTime();

            base.DialogInit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

        }

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                
                //decimal dHoli = Math.Round(sHoli.toDecimal(), 1);
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

                acInfo.SysConfig.SetSysConfigByServer("PLAN_DEADLINE_DATE", layoutRow["PLAN_DEADLINE_DATE"].ToString(), "WOR");
                acInfo.SysConfig.UpdateMemorySysConfig();

                DialogResult = DialogResult.OK;
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

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
    }
}