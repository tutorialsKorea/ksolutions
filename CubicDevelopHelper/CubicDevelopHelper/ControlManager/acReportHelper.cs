using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizManager;

namespace ControlManager
{
    public class acReportHelper
    {

        public static DateTime GetNowDateFromServer()
        {


            DataTable paramTable = new DataTable();

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GetDateTimeNow", paramSet, "", "RSLTDT");

            //DataSet resultSet = BizManager.acControls.GetDateTimeNow();

            return (DateTime)resultSet.Tables["RSLTDT"].Rows[0]["DATETIME"];

        }


        public class acEmp
        {
            public static DataRow GetDataRow(object code)
            {
                if (acChecker.isNull(code))
                {
                    return null;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //부품코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL","CONTROL_EMP_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];

                //DataTable data = BizManager.acControls.CONTROL_EMP_SEARCH(paramSet).Tables["RSLTDT"];
                if (data.Rows.Count != 0)
                {
                    return data.Rows[0];
                }

                return null;

            }
        }

        public class acVendor
        {

            public static DataRow GetDataRow(object code)
            {
                if (acChecker.isNull(code))
                {
                    return null;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //부품코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CODE"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];
                //DataTable data = BizManager.acControls.CONTROL_VENDOR_SEARCH(paramSet).Tables["RSLTDT"];
                if (data.Rows.Count != 0)
                {
                    return data.Rows[0];
                }

                return null;

            }

            /// <summary>
            /// 내회사정보를 반환합니다.
            /// </summary>
            /// <returns></returns>
            public static DataRow GetMyVendor()
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_MYVENDOR", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_MYVENDOR(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                {
                    return resultSet.Tables["RSLTDT"].Rows[0];
                }

                return null;
            }
        }


        public class acProd
        {
            public static DataRow GetDataRow(object code)
            {
                if (acChecker.isNull(code))
                {
                    return null;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //부품코드

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = code;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable data = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "CONTROL_PROD_SEARCH", paramSet, "RQSTDT", "RSLTDT").Tables[1];
                //DataTable data = BizManager.acControls.CONTROL_PROD_SEARCH(paramSet).Tables["RSLTDT"];

                if (data.Rows.Count != 0)
                {
                    return data.Rows[0];
                }

                return null;

            }
        }

        public class acBill
        {
            public static DataSet GetBill(object code)
            {
                DataTable dtBillNo = (DataTable)code;

                if (dtBillNo.Rows.Count == 0)
                {
                    return null;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BILL_NO", typeof(String)); //

                if (dtBillNo.Rows.Count > 1)
                {
                    foreach (DataRow row in dtBillNo.Rows)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["BILL_NO"] = row["BILL_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
                else
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BILL_NO"] = dtBillNo.Rows[0]["BILL_NO"];

                    paramTable.Rows.Add(paramRow);
                }
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "GET_BILL", paramSet, "RQSTDT", "RSLTDT_M, RSLTDT_D");

                if (resultSet.Tables.Count > 0)
                {
                    return resultSet;
                }

                return null;
            }
        }


        public static string GetClassName()
        {
            return "CodeHelper";
        }
    }
}
