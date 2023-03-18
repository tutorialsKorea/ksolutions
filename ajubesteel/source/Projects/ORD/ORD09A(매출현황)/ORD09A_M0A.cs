using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace ORD
{
    public partial class ORD09A_M0A : BaseMenu
    {

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();

        }

        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);

        }



        public ORD09A_M0A()
        {
            InitializeComponent();
        }


        public override void MenuInit()
        {
            try
            {
                // acGridView1.GridType = acGridView.emGridType.SEARCH;

                DataTable currDT = acInfo.StdCodes.GetCatTable("V002");

                #region 년도별 탭

                acBandGridView1.AddLookUpEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "V001");

                string[] month = new string[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView1.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView1.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView1.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }
                        }
                        else
                        {
                            acBandGridView1.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView1.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView1.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }
                        }
                    }
                }
                acBandGridView1.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //acBandGridView1.Columns["GUBUN"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                //acGridView1.AddLookUpEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "V001");
                ////acGridView1.AddTextEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("NOV", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("DEC", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView1.AddTextEdit("TOTAL", "계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                #endregion


                #region 고객사별 탭
                //acGridView2.AddLookUpVendor("CVND_CODE", "고객사", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                acBandGridView2.AddTextEdit("TVND_CODE", "고객사코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView2.AddTextEdit("TVND_NAME", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView2.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView2.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView2.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                        else
                        {
                            acBandGridView2.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView2.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView2.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                    }
                }

                acBandGridView2.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                acBandGridView2.Bands[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //acBandGridView2.Columns["TVND_CODE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //acBandGridView2.Columns["TVND_NAME"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                //acGridView2.AddTextEdit("TVND_CODE", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("TVND_NAME", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView2.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("NOV", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView2.AddTextEdit("DEC", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView2.AddTextEdit("TOTAL", "계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                #endregion


                #region 제품유형별 탭

                (acLayoutControl3.GetEditor("PROD_TYPE").Editor as acLookupEdit).SetCode("P010");

                acBandGridView3.AddCheckedComboBoxEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView3.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView3.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView3.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                        else
                        {
                            acBandGridView3.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView3.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView3.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                    }
                }

                acBandGridView3.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //acBandGridView3.Columns["PROD_TYPE"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                ////acGridView3.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P009");
                //acGridView3.AddCheckedComboBoxEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P009");
                //acGridView3.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("NOV", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView3.AddTextEdit("DEC", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView3.AddTextEdit("TOTAL", "계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                #endregion


                #region 영업담당자별 탭

                acBandGridView4.AddLookUpEmp("BUSINESS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView4.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView4.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView4.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                        else
                        {
                            acBandGridView4.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView4.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView4.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                    }
                }

                acBandGridView4.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //acBandGridView4.Columns["BUSINESS_EMP"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                //acGridView4.AddLookUpEmp("BUSINESS_EMP", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                //acGridView4.AddTextEdit("JAN", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("FEB", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("MAR", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("APR", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("MAY", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("JUN", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("JUL", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("AUG", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("SEP", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("OCT", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("NOV", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView4.AddTextEdit("DEC", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

                //acGridView4.AddTextEdit("TOTAL", "계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                #endregion

                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C011");
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
                acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("TVND_CODE", "계산서 발행처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("TVND_NAME", "계산서 발행처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("SHIP_DATE", "출하일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                
                acGridView1.AddTextEdit("EST_COST", "견적단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("PROD_COST", "공급단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddTextEdit("PROD_AMT", "총금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddCheckEdit("ORD_VAT", "VAT별도", "", false, false, true, acGridView.emCheckEditDataType._STRING);
                acGridView1.AddLookUpEdit("CURR_UNIT", "통화", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");

                acGridView1.AddTextEdit("PROD_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                acGridView1.AddTextEdit("SHIP_QTY", "출하수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

                acGridView1.AddTextEdit("TRADE_DATE", "거래명세표", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("TAX_DATE", "세금계산서", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("WIP", "재공", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("STK", "재고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                #region 미수
                acBandGridView5.AddTextEdit("BVEN_NAME", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView5.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView5.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView5.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                        else
                        {
                            acBandGridView5.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView5.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView5.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                    }
                }
                #endregion

                #region 미결
                acBandGridView6.AddTextEdit("BVEN_NAME", "고객사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                for (int i = 0; i < 13; i++)
                {
                    foreach (DataRow row in currDT.Rows)
                    {
                        if (i < 12)
                        {
                            acBandGridView6.AddTextEdit(month[i] + "_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, (i + 1).ToString() + "월");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView6.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView6.Columns[month[i] + "_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, month[i] + "_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                        else
                        {
                            acBandGridView6.AddTextEdit("TOTAL_" + row["CD_CODE"].ToString(), row["CD_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY, "계");

                            if (row["CD_CODE"].ToString() == "01")
                            {
                                acBandGridView6.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N0}");
                            }
                            else
                            {
                                acBandGridView6.Columns["TOTAL_" + row["CD_CODE"].ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_" + row["CD_CODE"], "합계={0:N2}");
                            }

                        }
                    }
                }

                #endregion




                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl2.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl3.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl4.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl5.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl6.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
                acLayoutControl7.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                acDateEdit5.Properties.EditMask = "yyyy-MM";
                acDateEdit6.Properties.EditMask = "yyyy-MM";
                acDateEdit7.Properties.EditMask = "yyyy";
                acDateEdit8.Properties.EditMask = "yyyy";
                acDateEdit9.Properties.EditMask = "yyyy-MM";

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            acLayoutControl1.GetEditor("YEAR").Value = DateTime.Now;
            acLayoutControl2.GetEditor("YEAR").Value = DateTime.Now;
            acLayoutControl3.GetEditor("YEAR").Value = DateTime.Now;
            acLayoutControl4.GetEditor("YEAR").Value = DateTime.Now;
            acLayoutControl5.GetEditor("S_MONTH").Value = acDateEdit.GetNowFirstMonth();
            acLayoutControl5.GetEditor("E_MONTH").Value = acDateEdit.GetNowMonth();

            acLayoutControl5.GetEditor("STD_MONTH").Value = acDateEdit.GetNowMonth();

            acLayoutControl6.GetEditor("YEAR").Value = DateTime.Now;
            acLayoutControl7.GetEditor("YEAR").Value = DateTime.Now;


            base.ChildContainerInit(sender);
        }



        void Search()
        {
            try
            {
                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "Y": //년도별 
                        {
                          
                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("WORK_YEAR", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WORK_YEAR"] = layoutRow["YEAR"];
                            paramTable.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER", paramSet, "RQSTDT", "RSLTDT",
                              QuickSearch,
                              QuickException);
                            break;
                        }
                    case "C": //고객사별 (tvnd_code)
                        {
                            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("WORK_YEAR", typeof(String)); //
                            paramTable.Columns.Add("TVND_CODE", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WORK_YEAR"] = layoutRow["YEAR"];
                            paramRow["TVND_CODE"] = layoutRow["TVND_CODE"];
                            paramTable.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER", paramSet, "RQSTDT", "RSLTDT",
                              QuickSearch,
                              QuickException);

                            break;
                        }
                    case "P": //제품분류별 (PROD_TYPE)
                        {
                            DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("WORK_YEAR", typeof(String)); //
                            paramTable.Columns.Add("PROD_TYPE", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WORK_YEAR"] = layoutRow["YEAR"];
                            paramRow["PROD_TYPE"] = layoutRow["PROD_TYPE"];
                            paramTable.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER", paramSet, "RQSTDT", "RSLTDT",
                              QuickSearch,
                              QuickException);

                            break;
                        }
                    case "B": //영업담당자 (Business_emp)
                        {
                            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("WORK_YEAR", typeof(String)); //
                            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["WORK_YEAR"] = layoutRow["YEAR"];
                            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

                            paramTable.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER", paramSet, "RQSTDT", "RSLTDT",
                              QuickSearch,
                              QuickException);

                            break;
                        }

                    case "WIP":
                        {
                            DataRow layoutRow = acLayoutControl5.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("S_MONTH", typeof(String)); //
                            paramTable.Columns.Add("E_MONTH", typeof(String)); //
                            paramTable.Columns.Add("STD_MONTH", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["S_MONTH"] = layoutRow["S_MONTH"];
                            paramRow["E_MONTH"] = layoutRow["E_MONTH"];
                            paramRow["STD_MONTH"] = layoutRow["STD_MONTH"];
                            

                            paramTable.Rows.Add(paramRow);

                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER2", paramSet, "RQSTDT", "RSLTDT",
                              QuickSearch2,
                              QuickException);
                        }
                        break;

                    case "REMAIN":
                        {

                            switch (acTabControl2.GetSelectedContainerName())
                            {
                                case "COL":

                                    DataRow layoutRow = acLayoutControl6.CreateParameterRow();

                                    DataTable paramTable = new DataTable("RQSTDT");
                                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                                    paramTable.Columns.Add("YEAR", typeof(String)); //

                                    DataRow paramRow = paramTable.NewRow();
                                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                                    paramRow["YEAR"] = layoutRow["YEAR"];

                                    paramTable.Rows.Add(paramRow);

                                    DataSet paramSet = new DataSet();
                                    paramSet.Tables.Add(paramTable);

                                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER3", paramSet, "RQSTDT", "RSLTDT",
                                      QuickSearch3,
                                      QuickException);

                                    break;

                                case "TAX":

                                    DataRow layoutRow2 = acLayoutControl7.CreateParameterRow();

                                    DataTable paramTable2 = new DataTable("RQSTDT");
                                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                                    paramTable2.Columns.Add("YEAR", typeof(String)); //

                                    DataRow paramRow2 = paramTable2.NewRow();
                                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                                    paramRow2["YEAR"] = layoutRow2["YEAR"];

                                    paramTable2.Rows.Add(paramRow2);

                                    DataSet paramSet2 = new DataSet();
                                    paramSet2.Tables.Add(paramTable2);

                                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "ORD09A_SER4", paramSet2, "RQSTDT", "RSLTDT",
                                      QuickSearch4,
                                      QuickException);

                                    break;
                            }
                            
                        }
                        break;


                }

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

                switch (acTabControl1.GetSelectedContainerName())
                {
                    case "Y" :
                        {
                            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                           GUBUN = g["BVEN_TYPE"],
                                                           CURR_UNIT = g["CURR_UNIT"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           GUBUN = r.Key.GUBUN,
                                                           CURR_UNIT = r.Key.CURR_UNIT,
                                                           PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           GUBUN = g.GUBUN,
                                                           CURR_UNIT = g.CURR_UNIT

                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           //GUBUN = "국내",
                                                           GUBUN = r.Key.GUBUN,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();

                            DataTable gridDT = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                            foreach (DataRow row in groupDt.Rows)
                            {
                                DataRow[] rows = gridDT.Select("GUBUN = '" + row["GUBUN"].ToString() +"'");

                                if (rows.Length == 0)
                                {
                                    DataRow newRow = gridDT.NewRow();
                                    newRow["GUBUN"] = row["GUBUN"];

                                    gridDT.Rows.Add(newRow);
                                }

                                rows = gridDT.Select("GUBUN = '" + row["GUBUN"].ToString() + "'");

                                foreach (DataColumn col in gridDT.Columns)
                                {
                                    string[] strs = col.ColumnName.Split('_');

                                    if (strs.Length == 2)
                                    {
                                        if (rows[0][col.ColumnName].ToString() == "")
                                        {
                                            rows[0][col.ColumnName] = 0;
                                        }

                                        if (strs[1] == row["CURR_UNIT"].ToString())
                                        {
                                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                                        }
                                        else
                                        {
                                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                                            {
                                                rows[0][col.ColumnName] = 0;
                                            }
                                        }
                                    }
                                }
                            }

                            acBandGridView1.GridControl.DataSource = gridDT;

                            break;
                        }
                    case "C" :
                        {
                            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           TVND_CODE = g["TVND_CODE"],
                                                           TVND_NAME = g["TVND_NAME"],
                                                           WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                           CURR_UNIT = g["CURR_UNIT"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           TVND_CODE = r.Key.TVND_CODE,
                                                           TVND_NAME = r.Key.TVND_NAME,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           CURR_UNIT = r.Key.CURR_UNIT,
                                                           PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           TVND_CODE = g.TVND_CODE,
                                                           TVND_NAME = g.TVND_NAME,
                                                           CURR_UNIT = g.CURR_UNIT

})
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           TVND_CODE = r.Key.TVND_CODE,
                                                           TVND_NAME = r.Key.TVND_NAME,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();


                            DataTable gridDT = ((DataTable)acBandGridView2.GridControl.DataSource).Clone();

                            foreach (DataRow row in groupDt.Rows)
                            {
                                DataRow[] rows = gridDT.Select("TVND_CODE = '" + row["TVND_CODE"].ToString() + "'");

                                if (rows.Length == 0)
                                {
                                    DataRow newRow = gridDT.NewRow();
                                    newRow["TVND_CODE"] = row["TVND_CODE"];
                                    newRow["TVND_NAME"] = row["TVND_NAME"];

                                    gridDT.Rows.Add(newRow);
                                }

                                rows = gridDT.Select("TVND_CODE = '" + row["TVND_CODE"].ToString() + "'");

                                foreach (DataColumn col in gridDT.Columns)
                                {
                                    if (col.ColumnName.StartsWith("TVND"))
                                    {
                                        continue;
                                    }

                                    string[] strs = col.ColumnName.Split('_');

                                    if (strs.Length == 2)
                                    {
                                        if (rows[0][col.ColumnName].ToString() == "")
                                        {
                                            rows[0][col.ColumnName] = 0;
                                        }

                                        if (strs[1] == row["CURR_UNIT"].ToString())
                                        {
                                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                                        }
                                        else
                                        {
                                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                                            {
                                                rows[0][col.ColumnName] = 0;
                                            }
                                        }
                                    }
                                }
                            }

                            acBandGridView2.GridControl.DataSource = gridDT;


                            //acGridView2.GridControl.DataSource = groupDt;


                            break;
                        }
                    case "P" :
                        {
                            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           PROD_TYPE = g["PROD_TYPE"],
                                                           WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                           CURR_UNIT = g["CURR_UNIT"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           PROD_TYPE = r.Key.PROD_TYPE,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                                           CURR_UNIT = r.Key.CURR_UNIT
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           PROD_TYPE = g.PROD_TYPE,
                                                           CURR_UNIT = g.CURR_UNIT

                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           PROD_TYPE = r.Key.PROD_TYPE,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();

                            DataTable gridDT = ((DataTable)acBandGridView3.GridControl.DataSource).Clone();

                            foreach (DataRow row in groupDt.Rows)
                            {
                                DataRow[] rows = null;

                                if (row["PROD_TYPE"].toStringNull() == null)
                                {
                                    rows = gridDT.Select("PROD_TYPE IS NULL");
                                }
                                else
                                {
                                    rows = gridDT.Select("PROD_TYPE = '" + row["PROD_TYPE"].ToString() + "'");
                                }

                                if (rows.Length == 0)
                                {
                                    DataRow newRow = gridDT.NewRow();
                                    newRow["PROD_TYPE"] = row["PROD_TYPE"];

                                    gridDT.Rows.Add(newRow);
                                }

                                if (row["PROD_TYPE"].toStringNull() == null)
                                {
                                    rows = gridDT.Select("PROD_TYPE IS NULL");
                                }
                                else
                                {
                                    rows = gridDT.Select("PROD_TYPE = '" + row["PROD_TYPE"].ToString() + "'");
                                }

                                foreach (DataColumn col in gridDT.Columns)
                                {
                                    if (col.ColumnName.StartsWith("PROD_TYPE"))
                                    {
                                        continue;
                                    }

                                    string[] strs = col.ColumnName.Split('_');

                                    if (strs.Length == 2)
                                    {
                                        if (rows[0][col.ColumnName].ToString() == "")
                                        {
                                            rows[0][col.ColumnName] = 0;
                                        }

                                        if (strs[1] == row["CURR_UNIT"].ToString())
                                        {
                                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                                        }
                                        else
                                        {
                                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                                            {
                                                rows[0][col.ColumnName] = 0;
                                            }
                                        }
                                    }
                                }
                            }

                            acBandGridView3.GridControl.DataSource = gridDT;


                            //acGridView3.GridControl.DataSource = groupDt;

                            break;
                        }
                    case "B" :
                        {
                            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           BUSINESS_EMP = g["BUSINESS_EMP"],
                                                           WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                           CURR_UNIT = g["CURR_UNIT"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BUSINESS_EMP = r.Key.BUSINESS_EMP,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                                           CURR_UNIT = r.Key.CURR_UNIT
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           BUSINESS_EMP = g.BUSINESS_EMP,
                                                           CURR_UNIT = g.CURR_UNIT

                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BUSINESS_EMP = r.Key.BUSINESS_EMP,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();

                            DataTable gridDT = ((DataTable)acBandGridView4.GridControl.DataSource).Clone();

                            foreach (DataRow row in groupDt.Rows)
                            {
                                DataRow[] rows = null;

                                if (row["BUSINESS_EMP"].toStringNull() == null)
                                {
                                    rows = gridDT.Select("BUSINESS_EMP IS NULL");
                                }
                                else
                                {
                                    rows = gridDT.Select("BUSINESS_EMP = '" + row["BUSINESS_EMP"].ToString() + "'");
                                }

                                if (rows.Length == 0)
                                {
                                    DataRow newRow = gridDT.NewRow();
                                    newRow["BUSINESS_EMP"] = row["BUSINESS_EMP"];

                                    gridDT.Rows.Add(newRow);
                                }

                                if (row["BUSINESS_EMP"].toStringNull() == null)
                                {
                                    rows = gridDT.Select("BUSINESS_EMP IS NULL");
                                }
                                else
                                {
                                    rows = gridDT.Select("BUSINESS_EMP = '" + row["BUSINESS_EMP"].ToString() + "'");
                                }

                                foreach (DataColumn col in gridDT.Columns)
                                {
                                    if (col.ColumnName.StartsWith("BUSINESS_EMP"))
                                    {
                                        continue;
                                    }

                                    string[] strs = col.ColumnName.Split('_');

                                    if (strs.Length == 2)
                                    {
                                        if (rows[0][col.ColumnName].ToString() == "")
                                        {
                                            rows[0][col.ColumnName] = 0;
                                        }

                                        if (strs[1] == row["CURR_UNIT"].ToString())
                                        {
                                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                                        }
                                        else
                                        {
                                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                                            {
                                                rows[0][col.ColumnName] = 0;
                                            }
                                        }
                                    }
                                }
                            }

                            acBandGridView4.GridControl.DataSource = gridDT;

                            //acGridView4.GridControl.DataSource = groupDt;

                            break;
                        }

                }

             
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 엑셀저장
            try
            {
                acBandGridView gridView = null;

                if(acTabControl1.GetSelectedContainerName() == "Y" )
                {
                    gridView = acBandGridView1;
                }
                else if(acTabControl1.GetSelectedContainerName() == "C")
                {
                    gridView = acBandGridView2;
                }
                else if (acTabControl1.GetSelectedContainerName() == "P")
                {
                    gridView = acBandGridView3;
                }
                else if (acTabControl1.GetSelectedContainerName() == "B")
                {
                    gridView = acBandGridView4;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                saveFileDialog.Title = "저장할 위치를 입력하여 주십시오.";

                saveFileDialog.FileName = "그리드뷰_엑셀정보";

                saveFileDialog.Filter = " Excel Files |*.xlsx; | All files|*.* ";

                saveFileDialog.FilterIndex = 1;

                saveFileDialog.RestoreDirectory = true;

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsxExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsxExportOptions();

                    gridView.OptionsPrint.AutoWidth = false;

                    gridView.Export(DevExpress.XtraPrinting.ExportTarget.Xlsx, saveFileDialog.FileName, xlsOpt);

                    System.Diagnostics.Process.Start(saveFileDialog.FileName);

                }


            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

            base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        }

        void QuickSearch3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           BVEN_NAME = g["BVEN_NAME"],
                                                           WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                           CURR_UNIT = g["BVEN_CURRENCY"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BVEN_NAME = r.Key.BVEN_NAME,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           CURR_UNIT = r.Key.CURR_UNIT,
                                                           PROD_AMT = r.Sum(s => s["BILL_AMT"].toDecimal()),
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           BVEN_NAME = g.BVEN_NAME,
                                                           CURR_UNIT = g.CURR_UNIT

                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BVEN_NAME = r.Key.BVEN_NAME,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();


            DataTable gridDT = ((DataTable)acBandGridView5.GridControl.DataSource).Clone();

            foreach (DataRow row in groupDt.Rows)
            {
                DataRow[] rows = gridDT.Select("BVEN_NAME = '" + row["BVEN_NAME"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridDT.NewRow();
                    newRow["BVEN_NAME"] = row["BVEN_NAME"];

                    gridDT.Rows.Add(newRow);
                }

                rows = gridDT.Select("BVEN_NAME = '" + row["BVEN_NAME"].ToString() + "'");

                foreach (DataColumn col in gridDT.Columns)
                {
                    if (col.ColumnName.StartsWith("BVEN"))
                    {
                        continue;
                    }

                    string[] strs = col.ColumnName.Split('_');

                    if (strs.Length == 2)
                    {
                        if (rows[0][col.ColumnName].ToString() == "")
                        {
                            rows[0][col.ColumnName] = 0;
                        }

                        if (strs[1] == row["CURR_UNIT"].ToString())
                        {
                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                        }
                        else
                        {
                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                            {
                                rows[0][col.ColumnName] = 0;
                            }
                        }
                    }
                }
            }

            acBandGridView5.GridControl.DataSource = gridDT;

            base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        }

        void QuickSearch4(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            DataTable groupDt = e.result.Tables["RSLTDT"]
                                                       .AsEnumerable()
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g["PLT_CODE"],
                                                           BVEN_NAME = g["BVEN_NAME"],
                                                           WORK_MONTH = g["SHIP_DATE"].toDateString("MM"),
                                                           CURR_UNIT = g["BVEN_CURRENCY"]
                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BVEN_NAME = r.Key.BVEN_NAME,
                                                           WORK_MONTH = r.Key.WORK_MONTH,
                                                           CURR_UNIT = r.Key.CURR_UNIT,
                                                           PROD_AMT = r.Sum(s => s["REMAIN_AMT"].toDecimal()),
                                                       })
                                                       .GroupBy(g => new
                                                       {
                                                           PLT_CODE = g.PLT_CODE,
                                                           BVEN_NAME = g.BVEN_NAME,
                                                           CURR_UNIT = g.CURR_UNIT

                                                       })
                                                       .Select(r => new
                                                       {
                                                           PLT_CODE = r.Key.PLT_CODE,
                                                           BVEN_NAME = r.Key.BVEN_NAME,
                                                           CURR_UNIT = r.Key.CURR_UNIT,

                                                           JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                                           FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                                           MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                                           APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                                           MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                                           JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                                           JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                                           AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                                           SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                                           OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                                           NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                                           DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                                           TOTAL = r.Sum(s => s.PROD_AMT)


                                                       })
                                                       .LINQToDataTable();


            DataTable gridDT = ((DataTable)acBandGridView6.GridControl.DataSource).Clone();

            foreach (DataRow row in groupDt.Rows)
            {
                DataRow[] rows = gridDT.Select("BVEN_NAME = '" + row["BVEN_NAME"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridDT.NewRow();
                    newRow["BVEN_NAME"] = row["BVEN_NAME"];

                    gridDT.Rows.Add(newRow);
                }

                rows = gridDT.Select("BVEN_NAME = '" + row["BVEN_NAME"].ToString() + "'");

                foreach (DataColumn col in gridDT.Columns)
                {
                    if (col.ColumnName.StartsWith("BVEN"))
                    {
                        continue;
                    }

                    string[] strs = col.ColumnName.Split('_');

                    if (strs.Length == 2)
                    {
                        if (rows[0][col.ColumnName].ToString() == "")
                        {
                            rows[0][col.ColumnName] = 0;
                        }

                        if (strs[1] == row["CURR_UNIT"].ToString())
                        {
                            rows[0][col.ColumnName] = System.Convert.ToDecimal(rows[0][col.ColumnName]) + System.Convert.ToDecimal(row[strs[0]]);
                        }
                        else
                        {
                            if (System.Convert.ToDecimal(rows[0][col.ColumnName]) == 0)
                            {
                                rows[0][col.ColumnName] = 0;
                            }
                        }
                    }
                }
            }

            acBandGridView6.GridControl.DataSource = gridDT;

            base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
        }
    }
}