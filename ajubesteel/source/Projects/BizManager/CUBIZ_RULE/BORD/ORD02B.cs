using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD02B
    {
        private static string _SelectQuery = "SELECT '' AS SEL,  I.PLT_CODE," +
                            " I.ITEM_CODE, " +
                            " I.ITEM_NAME, " +
                            " I.CVND_CODE, " +
                            " V.VEN_NAME AS CVND_NAME, " +
                            " I.ORD_DATE, " +
                            " I.ITEM_FLAG, " +
                            " I.PROD_TYPE, " +
                            " I.ORD_STATE, " +
                            " I.TOT_QTY, " +
                            " I.CONFIRM_PRICE, " +
                            " I.BUSINESS_EMP, " +
                            " E.EMP_NAME AS BUSINESS_EMP_NAME, " +
                            " I.SCOMMENT, " +
                            " I.REG_DATE, I.REG_EMP, " +
                            " I.MDFY_DATE, I.MDFY_EMP, I.ITEM_CODE AS O_ITEM_CODE " +
                            " FROM TORD_ITEM I LEFT JOIN TSTD_VENDOR V " +
                            "   ON I.PLT_CODE = V.PLT_CODE " +
                            "  AND I.CVND_CODE = V.VEN_CODE " +
                            "  LEFT JOIN TSTD_EMPLOYEE E " +
                            "    ON I.PLT_CODE = E.PLT_CODE " +
                            "   AND I.BUSINESS_EMP = E.EMP_CODE ";

        public static DataSet ORD02B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                string strQuery = "";
                string regEmp = paramDr["REG_EMP"].ToString();

                //해당 제품코드가 있는지 확인
                if (paramDr["O_ITEM_CODE"].ToString() == "")
                {
                    strQuery = "INSERT INTO TORD_ITEM " +
                                    " ([PLT_CODE] " +
                                    " ,[ITEM_CODE] " +
                                    " ,[ITEM_NAME] " +
                                    " ,[CVND_CODE] " +
                                    " ,[ORD_DATE] " +
                                    " ,[ITEM_FLAG] " +
                                    " ,[PROD_TYPE] " +
                                    " ,[ORD_STATE] " +
                                    " ,[TOT_QTY] " +
                                    " ,[CONFIRM_PRICE] " +
                                    " ,[BUSINESS_EMP] " +
                                    " ,[SCOMMENT] " +
                                    " ,[REG_DATE] " +
                                    " ,[REG_EMP] " +
                                    " ,[DATA_FLAG]) " +
                                      " VALUES " +
                                      " ( " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["ITEM_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["ITEM_NAME"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["CVND_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["ORD_DATE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["ITEM_FLAG"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_TYPE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["ORD_STATE"]) + ", " +
                                      ExtensionMethod.toDBInt(paramDr["TOT_QTY"]) + ", " +
                                      ExtensionMethod.toDBDecimal(paramDr["CONFIRM_PRICE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["BUSINESS_EMP"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["SCOMMENT"]) + ", " +
                                      "GETDATE(), " +
                                      ExtensionMethod.toDBString(paramDr["REG_EMP"]) + ", " +
                                      " 0 ) ";

                    //DBConnection dbConn = new DBConnection();
                    bizExecute.executeInsertQuery(strQuery);

                    DataTable paramTablePart = paramDS.Tables["RQSTDT_PROD"];

                    foreach (DataRow row in paramTablePart.Rows)
                    {
                        strQuery = "INSERT INTO TORD_PRODUCT " +
                                        " ([PLT_CODE] " +
                                        " ,[PROD_CODE] " +
                                        " ,[ITEM_CODE] " +
                                        " ,[PROD_NAME] " +
                                        " ,[DUE_DATE] " +
                                        " ,[PROD_QTY] " +
                                        " ,[PROD_UC] " +
                                        " ,[PROD_COST] " +
                                        " ,[SCOMMENT] " +
                                        " ,[REG_DATE] " +
                                        " ,[REG_EMP] " +
                                        " ,[DATA_FLAG]) " +
                                          " VALUES " +
                                          " ( " + ExtensionMethod.toDBString(row["PLT_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["ITEM_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_NAME"]) + ", " +
                                          ExtensionMethod.toDBString(row["DUE_DATE"]) + ", " +
                                          ExtensionMethod.toDBInt(row["PROD_QTY"]) + ", " +
                                          ExtensionMethod.toDBDecimal(row["PROD_UC"]) + ", " +
                                          ExtensionMethod.toDBDecimal(row["PROD_COST"]) + ", " +
                                          ExtensionMethod.toDBString(row["SCOMMENT"]) + ", " +
                                          " GETDATE(), " +
                                          ExtensionMethod.toDBString(row["REG_EMP"]) + ", " +
                                          " 0 ) ";

                        bizExecute.executeInsertQuery(strQuery);
                    }
                }
                else
                {

                    strQuery = "UPDATE TORD_ITEM " +
                                  " SET ITEM_NAME = " + ExtensionMethod.toDBString(paramDr["ITEM_NAME"]) +
                                  " , [CVND_CODE] = " + ExtensionMethod.toDBString(paramDr["CVND_CODE"]) +
                                  " , [ORD_DATE] = " + ExtensionMethod.toDBString(paramDr["ORD_DATE"]) +
                                  " , [ITEM_FLAG] = " + ExtensionMethod.toDBString(paramDr["ITEM_FLAG"]) +
                                 // " , [PROD_TYPE] = " + ExtensionMethods.toDBString(paramDr["PROD_TYPE"]) +
                                 // " , [ORD_STATE] = " + ExtensionMethods.toDBString(paramDr["ORD_STATE"]) +
                                  " , [TOT_QTY] = " + ExtensionMethod.toDBInt(paramDr["TOT_QTY"]) +
                                  " , [CONFIRM_PRICE] = " + ExtensionMethod.toDBDecimal(paramDr["CONFIRM_PRICE"]) +
                                  " , [BUSINESS_EMP] = " + ExtensionMethod.toDBString(paramDr["BUSINESS_EMP"]) +
                                  " , [SCOMMENT] = " + ExtensionMethod.toDBString(paramDr["SCOMMENT"]) +
                                  " , [MDFY_EMP] = " + ExtensionMethod.toDBString(paramDr["REG_EMP"]) +
                                  " , [MDFY_DATE] = GETDATE() " +
                                  " WHERE PLT_CODE = " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) +
                                  " AND ITEM_CODE = " + ExtensionMethod.toDBString(paramDr["ITEM_CODE"]);

                    bizExecute.executeInsertQuery(strQuery);

                    DataTable paramTablePart = paramDS.Tables["RQSTDT_PROD"];

                    foreach (DataRow row in paramTablePart.Rows)
                    {
                        if (row["O_PROD_CODE"].ToString() != "")
                        {
                            strQuery = "UPDATE TORD_PRODUCT " +
                                            " SET PROD_NAME = " + ExtensionMethod.toDBString(row["PROD_NAME"]) +
                                            "  , DUE_DATE = " + ExtensionMethod.toDBString(row["DUE_DATE"]) +
                                            "  , PROD_QTY = " + ExtensionMethod.toDBInt(row["PROD_QTY"]) +
                                            "  , PROD_UC = " + ExtensionMethod.toDBDecimal(row["PROD_UC"]) +
                                            "  , PROD_COST = " + ExtensionMethod.toDBDecimal(row["PROD_COST"]) +
                                            "  , SCOMMENT = " + ExtensionMethod.toDBString(row["SCOMMENT"]) +
                                            "  , MDFY_DATE = GETDATE() " +
                                            "  , MDFY_EMP = " + ExtensionMethod.toDBString(row["REG_EMP"]) +
                                              " WHERE PLT_CODE =  " + ExtensionMethod.toDBString(row["PLT_CODE"]) + 
                                              "   AND ITEM_CODE = " + ExtensionMethod.toDBString(row["ITEM_CODE"]) + 
                                              "   AND PROD_CODE = " + ExtensionMethod.toDBString(row["PROD_CODE"]);
                        }
                        else
                        {
                            strQuery = "INSERT INTO TORD_PRODUCT " +
                                        " ([PLT_CODE] " +
                                        " ,[PROD_CODE] " +
                                        " ,[ITEM_CODE] " +
                                        " ,[PROD_NAME] " +
                                        " ,[DUE_DATE] " +
                                        " ,[PROD_QTY] " +
                                        " ,[PROD_UC] " +
                                        " ,[PROD_COST] " +
                                        " ,[SCOMMENT] " +
                                        " ,[REG_DATE] " +
                                        " ,[REG_EMP] " +
                                        " ,[DATA_FLAG]) " +
                                          " VALUES " +
                                          " ( " + ExtensionMethod.toDBString(row["PLT_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["ITEM_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_NAME"]) + ", " +
                                          ExtensionMethod.toDBString(row["DUE_DATE"]) + ", " +
                                          ExtensionMethod.toDBInt(row["PROD_QTY"]) + ", " +
                                          ExtensionMethod.toDBDecimal(row["PROD_UC"]) + ", " +
                                          ExtensionMethod.toDBDecimal(row["PROD_COST"]) + ", " +
                                          ExtensionMethod.toDBString(row["SCOMMENT"]) + ", " +
                                          " GETDATE(), " +
                                          ExtensionMethod.toDBString(row["REG_EMP"]) + ", " +
                                          " 0 ) ";
                        }

                        bizExecute.executeInsertQuery(strQuery);
                    }

                    DataTable paramTableDel = paramDS.Tables["RQSTDT3"];

                    foreach (DataRow rowDel in paramTableDel.Rows)
                    {

                        strQuery = "UPDATE TORD_PRODUCT " +
                                " SET DATA_FLAG = 2 , " +
                                "  DEL_DATE = GETDATE(), " +
                                "  DEL_EMP = " + ExtensionMethod.toDBString(regEmp) +
                                " WHERE PLT_CODE = " + ExtensionMethod.toDBString(rowDel["PLT_CODE"]) +
                                "   AND PROD_CODE = " + ExtensionMethod.toDBString(rowDel["PROD_CODE"]) +
                                "   AND ITEM_CODE = " + ExtensionMethod.toDBString(rowDel["ITEM_CODE"]);


                        bizExecute.executeInsertQuery(strQuery);
                    }                    
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("ITEM_CODE", typeof(String));
                paramTable.Columns.Add("ITEM_LIKE", typeof(String));
                paramTable.Columns.Add("CVND_CODE", typeof(String));
                paramTable.Columns.Add("S_ORD_DATE", typeof(String));
                paramTable.Columns.Add("E_ORD_DATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = ExtensionMethod.PLT_CODE;
                paramRow["ITEM_CODE"] = paramDr["ITEM_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet selectSet = new DataSet();
                selectSet.Tables.Add(paramTable);

                DataSet resultSet = ORD02B_SER(selectSet, bizExecute);
                resultSet.Tables.Add(ORD02B_SER2(selectSet, bizExecute).Tables["RSLTDT2"].Copy());

                return resultSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //수주 목록
        public static DataSet ORD02B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            string strQuery = _SelectQuery;

            string strWhere = " WHERE I.DATA_FLAG = 0 ";


            DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

            if (paramDr["PLT_CODE"].ToString() != "") strWhere += " AND I.PLT_CODE = '" + paramDr["PLT_CODE"].ToString() + "'";

            if (paramDr["ITEM_CODE"].ToString() != "") strWhere += " AND I.ITEM_CODE = '" + paramDr["ITEM_CODE"].ToString() + "'";

            if (paramDr["ITEM_LIKE"].ToString() != "")
            {
                strWhere += " AND ( I.ITEM_CODE LIKE '%" + paramDr["ITEM_LIKE"].ToString() + "%' OR  ";
                strWhere += "   I.ITEM_NAME LIKE '%" + paramDr["ITEM_LIKE"].ToString() + "%')  ";

            }

            if (paramDr["S_ORD_DATE"].ToString() != "") strWhere += " S.ORD_DATE '" + paramDr["S_ORD_DATE"].ToString() + "' AND '" + paramDr["E_ORD_DATE"].ToString() + "'";

            if (paramDr["CVND_CODE"].ToString() != "") strWhere += " AND I.CVND_CODE = '" + paramDr["CVND_CODE"].ToString() + "'";

            strQuery += strWhere;

            //DBConnection dbConn = new DBConnection();

            DataTable dtRslt = bizExecute.executeSelectQuery(strQuery).Copy();

            dtRslt.TableName = "RSLTDT";

            DataTable dtRqst = paramDS.Tables["RQSTDT"].Copy();

            DataSet dsRslt = new DataSet();
            dsRslt.Tables.Add(dtRslt);
            dsRslt.Tables.Add(dtRqst);

            return dsRslt;
        }

        //수주-제품 목록
        public static DataSet ORD02B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            string strQuery = "SELECT P.ITEM_CODE," +
                            " P.PROD_CODE,  " +
                            " P.PROD_NAME, " +
                            " PS.PART, " +
                            " PS.MOLD_NO, " +
                            " PS.CAVITY, " +
                            " P.DUE_DATE, " +
                            " P.PROD_QTY, P.PROD_UC, P.PROD_COST, P.SCOMMENT, P.PROD_CODE AS O_PROD_CODE " +
                            " FROM TORD_PRODUCT P JOIN TSTD_PRODUCT PS " +
                            "   ON P.PLT_CODE = PS.PLT_CODE " +
                            "  AND P.PROD_CODE = PS.PROD_CODE ";


            string strWhere = " WHERE P.DATA_FLAG = 0 ";

            DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

            if (paramDr["PLT_CODE"].ToString() != "") strWhere += " AND P.PLT_CODE = '" + paramDr["PLT_CODE"].ToString() + "'";

            if (paramDr["ITEM_CODE"].ToString() != "") strWhere += " AND P.ITEM_CODE = '" + paramDr["ITEM_CODE"].ToString() + "'";

            strQuery += strWhere;

            //DBConnection dbConn = new DBConnection();

            DataTable dtRslt = bizExecute.executeSelectQuery(strQuery).Copy();

            dtRslt.TableName = "RSLTDT2";

            DataTable dtRqst = paramDS.Tables["RQSTDT"].Copy();

            DataSet dsRslt = new DataSet();
            dsRslt.Tables.Add(dtRslt);
            dsRslt.Tables.Add(dtRqst);

            return dsRslt;
        }

        public static DataSet ORD02B_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            DataRow paramDr = paramDS.Tables["RQSTDT_D"].Rows[0];

            foreach (DataRow row in paramDS.Tables["RQSTDT_D"].Rows)
            {
                string strQuery = "UPDATE TORD_ITEM " +
                                  " SET DATA_FLAG = 2 " +
                                  " , DEL_DATE = GETDATE() " +
                                  " , DEL_EMP = " + ExtensionMethod.toDBString(row["DEL_EMP"]) +
                                  //" , DEL_REASON = " + ExtensionMethods.toDBString(row["DEL_REASON"]) +
                                  " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                  " AND ITEM_CODE = " + ExtensionMethod.toDBString(row["ITEM_CODE"]);

                bizExecute.executeInsertQuery(strQuery);

                string strQuery2 = " UPDATE TORD_PRODUCT " +
                                " SET DATA_FLAG = 2 " +
                                " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                "   AND ITEM_CODE = " + ExtensionMethod.toDBString(row["ITEM_CODE"]);

                bizExecute.executeInsertQuery(strQuery2);
            }

            return ORD02B_SER(paramDS,bizExecute);
        }

        public static void ORD02B_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
            {

                string strQuery = " DELETE FROM TSTD_MOLD_PART " +
                                " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                "   AND MOLD_CODE = " + ExtensionMethod.toDBString(row["MOLD_CODE"]) +
                                "   AND PART_CODE = " + ExtensionMethod.toDBString(row["PART_CODE"]);

                //DBConnection dbConn = new DBConnection();
                bizExecute.executeInsertQuery(strQuery);
            }

            return;
        }


        public static DataTable QueryTableSchema()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("CVND_CODE", typeof(String));
            paramTable.Columns.Add("ITEM_CODE", typeof(String));
            paramTable.Columns.Add("ITEM_LIKE", typeof(String));
            paramTable.Columns.Add("S_ORD_DATE", typeof(String));
            paramTable.Columns.Add("E_ORD_DATE", typeof(String));

            return paramTable;
        }
    }
}
