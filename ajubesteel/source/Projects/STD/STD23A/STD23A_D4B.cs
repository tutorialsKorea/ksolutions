using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Net;
using System.IO;
using System.Xml;
using BizManager;

namespace STD
{
    public sealed partial class STD23A_D4B : BaseMenuDialog
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

        acGridView _LinkView = null;

        public STD23A_D4B()
        {
            InitializeComponent();

            acDateEdit1.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            acDateEdit2.EditValue = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));

            
            //(acLayoutControl1.GetEditor("FR_DATE") as acDateEdit).DateTime = dtSelectedDT;
            //(acLayoutControl1.GetEditor("TO_DATE") as acDateEdit).DateTime = dtSelectedDT;
            
            acGridView1.GridType = ControlManager.acGridView.emGridType.LIST;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
                        
            acGridView1.AddDateEdit("HOLI_DATE", "날짜", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("HOLI_NAME", "공휴일명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("HOLI_NAME", "공휴일명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //this._LinkView = linkView;

            //MC_GROUP

        }

        public override void DialogInitComplete()
        {


///*            DataTable paramTable = new DataTable("RQSTDT");
//            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

//            DataRow paramRow = paramTable.NewRow();
//            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
//            paramTable.Rows.Add(paramRow);
//            DataSet paramSet = new DataSet();
//            paramSet.Tables.Add(paramTable);


//            BizRun.QBizRun.ExecuteService(
//            this, QBiz.emExecuteType.LOAD,
//            "STD23A_SER5", paramSet, "RQSTDT", "RSLTDT",
//            QuickSearch,
//            QuickException);
//*/

            base.DialogInitComplete();
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz,  BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickMultiException(object sender, QBizMulti qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }



        void QuickMultiSave(object sender, QBizMulti qBizMulti, QBizMulti.ExcuteCompleteArgs e)
        {

            this.DialogResult = DialogResult.OK;

            foreach (DataRow row in e.result.Tables["RQSTDT2"].Rows)
            {
                this._LinkView.UpdateMapingRow(row, true);
            }

            

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //휴일설정 생성
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("WORK_DATE");
                paramTable.Columns.Add("HOLI_NAME");
                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");

                DataView view = acGridView1.GetDataView("SEL = '1'");

                for (int i = 0; i < view.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["WORK_DATE"] = view[i]["HOLI_DATE"].toDateString("yyyyMMdd");
                    paramRow["HOLI_NAME"] = view[i]["HOLI_NAME"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                   "STD23B_UPD2", paramSet, "RQSTDT", "",
                   QuickProcess,
                   QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }




        }

        void QuickProcess(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //this.Search();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            

            DateTime start = acDateEdit1.DateTime;

            DateTime end = acDateEdit2.DateTime;

            DataTable dataTable = new DataTable("RQSTDT");
            dataTable.Columns.Add("PLT_CODE", typeof(string));
            dataTable.Columns.Add("SEL", typeof(string));
            dataTable.Columns.Add("HOLI_DATE", typeof(string));
            dataTable.Columns.Add("HOLI_NAME", typeof(string));
            dataTable.Columns.Add("IS_HOLI", typeof(string));

            for (int i = 0; start.AddMonths(i).toDateString("yyyyMM").toInt() <= end.toDateString("yyyyMM").toInt(); i++)
            {

                string year = start.AddMonths(i).toDateString("yyyy");

                string month = start.AddMonths(i).toDateString("MM");

                string url = "http://apis.data.go.kr/B090041/openapi/service/SpcdeInfoService/getRestDeInfo"; // URL
                url += "?ServiceKey=" + acInfo.SysConfig.GetSysConfigByServer("WEB_API_KEY_HOLIDAY").ToString(); // Service Key
                url += "&pageNo=1";
                url += "&numOfRows=10";
                url += "&solYear=" + year;
                url += "&solMonth="+ month;

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                string results = string.Empty;
                HttpWebResponse response;
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(results);

                    XmlNodeList xnList = xml.GetElementsByTagName("body");
                    XmlNodeList xnListItem = xnList.Item(0).ChildNodes;
                    XmlNodeList xnListItem2 = xnListItem.Item(0).ChildNodes;


                    foreach (XmlNode node in xnListItem2)
                    {
                        DataRow row = dataTable.NewRow();
                        row["PLT_CODE"] = "100";
                        row["SEL"] = "1";
                        row["HOLI_DATE"] = node["locdate"].InnerText;
                        row["HOLI_NAME"] = node["dateName"].InnerText;
                        row["IS_HOLI"] = node["isHoliday"].InnerText;
                        dataTable.Rows.Add(row);
                    }

                }

            }

            acGridView1.GridControl.DataSource = dataTable;
        }
    }
}