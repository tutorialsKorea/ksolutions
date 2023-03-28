using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraPrinting;
using System.Drawing.Imaging;
using DevExpress.XtraReports.UI;
using System.Drawing;
using BizManager;

namespace ControlManager
{
    public class acReport : DevExpress.XtraReports.UI.XtraReport
    {
        private string _CategoryID = null;

        public string CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        private bool _IsUseDefaultFont = true;
        public bool IsUseDefaultFont
        {
            get { return _IsUseDefaultFont; }
            set { _IsUseDefaultFont = value; }
        }

        public object Mail_ToAddress = null;

        public object Mail_Subject = null;

        public object Mail_Body = null;

        public object Mail_Type = null;

        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private BottomMarginBand bottomMarginBand1;

        public object Mail_AttatchFileLinkKey = null;


      

        public acReport()
            : base()
        {
            
        }

        private void _ChangeFont(XRControl c)
        {
            //2019-09-25 
            //DEFAULT_FONT 찾지 못하여 에러나는것 방지용 try-catch
            try
            {
                if (IsUseDefaultFont)
                {
                    c.Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), c.Font.Size, c.Font.Style);

                    foreach (XRControl ctrl in c.Controls)
                    {
                        ctrl.Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), ctrl.Font.Size, ctrl.Font.Style);

                        if (ctrl.Controls.Count != 0)
                        {
                            _ChangeFont(ctrl);
                        }
                    }
                }
            }
            catch
            {

            }

        }

        protected override void OnBeforePrint(System.Drawing.Printing.PrintEventArgs e)
        {
            //if (acInfo.IsRunTime == true)
            //{
            //    foreach (Band b in this.Bands)
            //    {
            //        foreach (XRControl ctrl in b.Controls)
            //        {
            //            _ChangeFont(ctrl);
            //        }

            //    }
            //}

            base.OnBeforePrint(e);
        }
        public static string GetClassName()
        {
            return "acReport";
        }

        public static DataRow GetDataRow(string categoryID, string reportClass)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); 
            paramTable.Columns.Add("RPT_CATEGORY_ID", typeof(String));
            paramTable.Columns.Add("RPT_CLASS", typeof(String)); 

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["RPT_CATEGORY_ID"] = categoryID;
            paramRow["RPT_CLASS"] = reportClass;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_REPORT", paramSet, "RQSTDT", "RSLTDT").Tables[1];
            //DataTable data = BizManager.acControls.GET_REPORT(paramSet).Tables["RSLTDT"];

            if (data.Rows.Count != 0)
            {
                return data.Rows[0];
            }

            return null;
        }
       

        public virtual object DataSourceProcess(object datasource)
        {
            return datasource;
        }

        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // acReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "20.2";
            //this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }





    }
}
