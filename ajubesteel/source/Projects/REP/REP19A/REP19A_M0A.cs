using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ControlManager;
using BizManager;

namespace REP
{
    public partial class REP19A_M0A : BaseMenu
    {
        String _SerYear;
        DataTable _DDt = null;
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

        public REP19A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.GetEditor("SYEAR").Value = DateTime.Now;

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.CellMerge += AcGridView1_CellMerge;
            acGridView1.RowCellClick += AcGridView1_RowCellClick;
        }

        private void AcGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string month = null;
                    switch (e.Column.FieldName)
                    {
                        case "JAN":
                            month = "01";
                            break;
                        case "FEB":
                            month = "02";
                            break;
                        case "MAR":
                            month = "03";
                            break;
                        case "APR":
                            month = "04";
                            break;
                        case "MAY":
                            month = "05";
                            break;
                        case "JUN":
                            month = "06";
                            break;
                        case "JUL":
                            month = "07";
                            break;
                        case "AUG":
                            month = "08";
                            break;
                        case "SEP":
                            month = "09";
                            break;
                        case "OCT":
                            month = "10";
                            break;
                        case "DEC":
                            month = "11";
                            break;
                        case "NOV":
                            month = "12";
                            break;
                    }

                    if (month.isNullOrEmpty() == false)
                    {
                        Main.MoveLinkMenu("QCT04A", new string[] { _SerYear , month});
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
        
        private void AcGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if(e.Column.FieldName.Equals("MGUBUN")
                    && e.CellValue1.ToString().Equals(e.CellValue2))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }

                e.Handled = true;
            }
            catch
            {

            }
        }

        public override void MenuInit()
        {
            base.MenuInit();

            acGridView1.AddLookUpEdit("MGUBUN", "COST 구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "M035");
            acGridView1.AddLookUpEdit("DGUBUN", "산출항목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "M036");
            acGridView1.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("DEC", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("NOV", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.OptionsView.AllowCellMerge = true;

            acGridView1.Columns["MGUBUN"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            _DDt = acStdCodes.GetCatTableByServer("M036");
        }

        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
                return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["SYEAR"];

            _SerYear = layoutRow["SYEAR"].ToString();

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP19A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dtRsltQct = e.result.Tables["RSLTDT_QCT"];
                DataTable dtRsltNg = e.result.Tables["RSLTDT_NG"];
                DataTable dtRsltPNg = e.result.Tables["RSLTDT_PNG"];
                DataTable dtRsltAs = e.result.Tables["RSLTDT_AS"];

                DataTable inputTable = acGridView1.NewTable();

                foreach (DataRow row in _DDt.AsEnumerable().OrderBy(o => o["CD_PARENT"]).ThenBy(t => t["CD_NAME"]))
                {
                    DataRow inputRow = inputTable.NewRow();
                    inputRow["MGUBUN"] = row["CD_PARENT"];
                    inputRow["DGUBUN"] = row["CD_CODE"];
                    switch (inputRow["MGUBUN"].ToString())
                    {
                        case "FCOST":
                            inputRow["JAN"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["FEB"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAR"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["APR"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAY"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUN"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUL"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["AUG"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["SEP"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["OCT"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["DEC"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s=> s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["NOV"] = dtRsltNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltPNg.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"));
                            break;
                        case "EFCOST":
                            inputRow["JAN"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["FEB"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAR"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["APR"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAY"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUN"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUL"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["AUG"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["SEP"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["OCT"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["DEC"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["NOV"] = dtRsltAs.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"))
                                            + dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"));
                            break;
                        case "PYEONGGA":
                        case "YEBANG":
                            inputRow["JAN"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '01'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["FEB"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '02'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAR"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '03'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["APR"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '04'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["MAY"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '05'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUN"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '06'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["JUL"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '07'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["AUG"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '08'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["SEP"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '09'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["OCT"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '10'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["DEC"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '11'").Sum(s => s.Field<decimal>("COST"));
                            inputRow["NOV"] = dtRsltQct.Select("GUBUN='" + row["CD_CODE"] + "' AND MONTH = '12'").Sum(s => s.Field<decimal>("COST"));
                            break;
                    }
                    inputTable.Rows.Add(inputRow);
                }
                acGridView1.GridControl.DataSource = inputTable;
                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

    }
}
