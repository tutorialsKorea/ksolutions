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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using DevExpress.XtraPdfViewer;

namespace PLN
{
    public sealed partial class PLN01B_D1A : BaseMenuDialog
    {
        public PLN01B_D1A(DataRow row)
        {
            InitializeComponent();
            
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.ActualSize;

            Search(row);
        }

        private void Search(DataRow row)
        {
            try
            {
                DataSet paramSet = new DataSet();

                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("PROC_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = row["PART_CODE"];
                paramRow["PROC_CODE"] = row["PROC_CODE"];
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN01B_SER10", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataSet result = e.result;

                foreach (DataRow row in result.Tables["RSLTDT"].Rows)
                {
                    if (row["PROC_FILE_CONTENT"] is byte[] bytes)
                    {
                        Stream stream = new MemoryStream(bytes);
                        pdfViewer1.LoadDocument(stream);
                        pdfViewer1.Tag = row["PROC_FILE_NAME"];

                        pdfViewer1.ZoomMode = PdfZoomMode.PageLevel;

                        break;
                    }
                    else
                    {
                        pdfViewer1.CloseDocument();
                    }
                }
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
    }
}