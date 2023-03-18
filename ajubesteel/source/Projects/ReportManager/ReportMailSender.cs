using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CodeHelperManager;
using System.IO;
using BizManager;

namespace ReportManager
{
    internal partial class ReportMailSender : ControlManager.acForm
    {
        private acReport _Report = null;


        public ReportMailSender(acReport report)
        {
            InitializeComponent();

            this._Report = report;


        }


        protected override void OnLoad(EventArgs e)
        {

            (acLayoutControl1.GetEditor("REPORT_INCLUDE_TYPE").Editor as acLookupEdit).SetCode("S001");


            acLayoutControl1.GetEditor("TO_ADDRESS").Value = this._Report.Mail_ToAddress;

            acLayoutControl1.GetEditor("SUBJECT").Value = this._Report.Mail_Subject;

            acLayoutControl1.GetEditor("BODY").Value = this._Report.Mail_Body;



            acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;

            acGridView1.AddTextEdit("FILE_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.GridControl.DataSource = AttachFileManager.acAttachFileControl.GetFileList(this._Report.Mail_AttatchFileLinkKey);

        

            base.OnLoad(e);

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }



                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataRow empRow = acEmp.GetDataRow(acInfo.UserID);

                DataRow reportRow = acReport.GetDataRow(this._Report.CategoryID, this._Report.GetType().Name);

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("TO_ADDRESS", typeof(String)); //
                paramTable1.Columns.Add("FROM_ADDRESS", typeof(String)); //
                paramTable1.Columns.Add("FROM_DISPLAY_NAME", typeof(String)); //
                paramTable1.Columns.Add("SUBJECT", typeof(String)); //
                paramTable1.Columns.Add("BODY", typeof(String)); //
                paramTable1.Columns.Add("ATTACH_FILE_ID", typeof(String)); //파일컨트롤의 첨부 파일ID ;로 여러개 가능

                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("ATTACH_LOCAL_FILE_NAME", typeof(String)); //
                paramTable2.Columns.Add("ATTACH_LOCAL_FILE_DATA", typeof(Byte[])); //


                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["TO_ADDRESS"] = layoutRow["TO_ADDRESS"];
                paramRow1["FROM_ADDRESS"] = empRow["EMAIL"];
                paramRow1["FROM_DISPLAY_NAME"] = empRow["EMP_NAME"];

                paramRow1["SUBJECT"] = layoutRow["SUBJECT"];

                paramRow1["BODY"] = layoutRow["BODY"];


                switch (layoutRow["REPORT_INCLUDE_TYPE"].ToString())
                {

                    case "EXCEL":
                        {

                            MemoryStream st = new MemoryStream();

                            DevExpress.XtraPrinting.XlsExportOptions opt = new DevExpress.XtraPrinting.XlsExportOptions();

                            this._Report.ExportToXls(st, opt);

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["ATTACH_LOCAL_FILE_NAME"] = string.Format("{0}.{1}", reportRow["RPT_NAME"].ToString(), "xls");
                            paramRow2["ATTACH_LOCAL_FILE_DATA"] = st.ToArray();
                            paramTable2.Rows.Add(paramRow2);

                            st.Close();

                        }


                        break;

                    case "PDF":
                        {

                            MemoryStream st = new MemoryStream();

                            DevExpress.XtraPrinting.PdfExportOptions opt = new DevExpress.XtraPrinting.PdfExportOptions();

                            this._Report.ExportToPdf(st, opt);

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["ATTACH_LOCAL_FILE_NAME"] = string.Format("{0}.{1}", reportRow["RPT_NAME"].ToString(), "pdf");
                            paramRow2["ATTACH_LOCAL_FILE_DATA"] = st.ToArray();
                            paramTable2.Rows.Add(paramRow2);

                            st.Close();

                        }

                        break;

                    case "MHT":
                        {

                            MemoryStream st = new MemoryStream();

                            DevExpress.XtraPrinting.MhtExportOptions opt = new DevExpress.XtraPrinting.MhtExportOptions();

                            this._Report.ExportToMht(st, opt);

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["ATTACH_LOCAL_FILE_NAME"] = string.Format("{0}.{1}", reportRow["RPT_NAME"].ToString(), "mht");
                            paramRow2["ATTACH_LOCAL_FILE_DATA"] = st.ToArray();
                            paramTable2.Rows.Add(paramRow2);

                            st.Close();



                        }

                        break;

                    case "RTF":
                        {

                            MemoryStream st = new MemoryStream();

                            DevExpress.XtraPrinting.RtfExportOptions opt = new DevExpress.XtraPrinting.RtfExportOptions();

                            this._Report.ExportToRtf(st, opt);

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["ATTACH_LOCAL_FILE_NAME"] = string.Format("{0}.{1}", reportRow["RPT_NAME"].ToString(), "rtf");
                            paramRow2["ATTACH_LOCAL_FILE_DATA"] = st.ToArray();
                            paramTable2.Rows.Add(paramRow2);

                            st.Close();


                        }

                        break;

                    case "IMG":
                        {

                            MemoryStream st = new MemoryStream();

                            DevExpress.XtraPrinting.ImageExportOptions opt = new DevExpress.XtraPrinting.ImageExportOptions();

                            opt.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage;

                            opt.Format = System.Drawing.Imaging.ImageFormat.Png;

                            opt.Resolution = 120;

                            this._Report.ExportToImage(st, opt);

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["ATTACH_LOCAL_FILE_NAME"] = string.Format("{0}.{1}", reportRow["RPT_NAME"].ToString(), "png");
                            paramRow2["ATTACH_LOCAL_FILE_DATA"] = st.ToArray();
                            paramTable2.Rows.Add(paramRow2);

                            st.Close();



                        }

                        break;


                }



                DataTable attachFiles = acGridView1.GridControl.DataSource as DataTable;


                paramRow1["ATTACH_FILE_ID"] = attachFiles.toString("FILE_ID", ";");



                paramTable1.Rows.Add(paramRow1);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "SEND_MAIL", paramSet, "RQSTDT,RQSTDT2", "",
                    QuickMail,
                    QuickException);

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

        void QuickMail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}