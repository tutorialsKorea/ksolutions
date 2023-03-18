using BizManager;
using ControlManager;
using DevExpress.Spreadsheet;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WOR
{
    public sealed partial class WOR07A_D1A : BaseMenuDialog
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

        DataRow _linkRow = null;

        public WOR07A_D1A(DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DataSet paramSet = acInfo.RefData.Clone();
            paramSet.Tables["RQSTDT"].Columns.Add("EMP_CODE", typeof(String));

            DataRow newRow = paramSet.Tables["RQSTDT"].NewRow();
            newRow["PLT_CODE"] = acInfo.PLT_CODE;
            newRow["EMP_CODE"] = _linkRow["EMP_CODE"];

            paramSet.Tables["RQSTDT"].Rows.Add(newRow);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD13A_SER2", paramSet, "RQSTDT", "RSLTDT");

            Stream stream = new MemoryStream(WOR.Resource.HOLI_CALC);

            spreadsheetControl1.LoadDocument(stream, DocumentFormat.Xlsx);

            IWorkbook workbook = spreadsheetControl1.Document;

            Worksheet ws = workbook.Worksheets[0];

            string target_date = "";
            string enfor_date = "";

            string hire_date = "";
            string retire_date = "";
            string account_date = "";

            if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                target_date = resultSet.Tables["RSLTDT"].Rows[0]["TARGET_DATE"].ToString();
                enfor_date = resultSet.Tables["RSLTDT"].Rows[0]["ENFOR_DATE"].ToString();

                hire_date = resultSet.Tables["RSLTDT"].Rows[0]["HIRE_DATE"].ToString();
                retire_date = resultSet.Tables["RSLTDT"].Rows[0]["RETIRE_DATE"].ToString();
                account_date = resultSet.Tables["RSLTDT"].Rows[0]["ACCOUNT_DATE"].ToString();
            }

            string hire_year = hire_date.Length > 0 ? hire_date.Substring(0,4) : "";
            string hire_month = hire_date.Length > 0 ? hire_date.Substring(4, 2) : "";
            string hire_day = hire_date.Length > 0 ? hire_date.Substring(6, 2) : "";

            string retire_year = retire_date.Length > 0 ? retire_date.Substring(0, 4) : "";
            string retire_month = retire_date.Length > 0 ? retire_date.Substring(4, 2) : "";
            string retire_day = retire_date.Length > 0 ? retire_date.Substring(6, 2) : "";

            string account_month = account_date.Length > 0 ? account_date.Substring(4, 2) : "";
            string account_day = account_date.Length > 0 ? account_date.Substring(6, 2) : "";

            ws["B7"].SetValue(target_date.toDateString("yyyy-MM-dd")); //대상자
            ws["C7"].SetValue(enfor_date.toDateString("yyyy-MM-dd")); //시행일자

            ws["F7"].SetValue(hire_year); //입사일자 - 년
            ws["G7"].SetValue(hire_month); //입사일자 - 월
            ws["H7"].SetValue(hire_day); //입사일자 - 일

            ws["I7"].SetValue(retire_year); //퇴사일자 - 년
            ws["J7"].SetValue(retire_month); //퇴사일자 - 월
            ws["K7"].SetValue(retire_day); //퇴사일자 - 일

            ws["L7"].SetValue(account_month); //회계년도 - 월
            ws["M7"].SetValue(account_day); //회계년도 - 일

            base.DialogInit();
        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //}
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
                IWorkbook workbook = spreadsheetControl1.Document;

                Worksheet ws = workbook.Worksheets[0];

                string sHoli = ws["F18"].Value.ToString();
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