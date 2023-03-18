using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD10A
    {
        private static string _SelectQuery = "SELECT '' AS SEL,  M.PLT_CODE," +
                            " M.MOLD_CODE, " +
                            " M.MODEL, " +
                            " M.MOLD_NAME, " +
                            " M.MOLD_NUM, " +
                            " M.MATERIAL, " +
                            " M.PROD_CODE, " +
                            " P.MODEL AS PROD_NAME, " +
                            " P.PART, " +
                            " P.MOLD_NO, " +
                            " M.MC_CODE, " +
                            " MC.MC_NAME, " +
                            " M.CUST_DATE, " +
                            " M.PROD_DATE, " +
                            " M.PROD_VND, " +
                            " PV.VEN_NAME AS PROD_VND_NAME, " +
                            " M.BALJU_DATE, " +
                            " M.BALJU_VND, " +
                            " BV.VEN_NAME AS BALJU_VND_NAME, " +
                            " M.SIZE, " +
                            " M.WEIGHT, " +
                            " M.TYPE, " +
                            " M.GATE, " +
                            " M.CAVITY, " +
                            " M.MOLD_EMP, " +
                            " '' AS MOLD_EMP_NAME, " +
                            " M.ACC_SHOT, " +
                            " M.MOLD_NO, " +
                            " M.SCOMMENT, " +
                            " M.REG_DATE, M.REG_EMP, " +
                            " M.MDFY_DATE, M.MDFY_EMP " +
                            " FROM TSTD_MOLD M LEFT JOIN TSTD_PRODUCT P " +
                            "   ON M.PLT_CODE = P.PLT_CODE " +
                            "  AND M.PROD_CODE = P.PROD_CODE " +
                            "  LEFT JOIN TSTD_MACHINE MC " +
                            "    ON M.PLT_CODE = MC.PLT_CODE " +
                            "   AND M.MC_CODE = MC.MC_CODE " +
                            "  LEFT JOIN TSTD_VENDOR PV " +
                            "    ON M.PLT_CODE = PV.PLT_CODE " +
                            "   AND M.PROD_VND = PV.VEN_CODE " +
                            "  LEFT JOIN TSTD_VENDOR BV " +
                            "    ON M.PLT_CODE = BV.PLT_CODE " +
                            "   AND M.BALJU_VND = BV.VEN_CODE ";

        public static DataSet STD10A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                string strQuery = "";
                string o_mold_code = paramDr["O_MOLD_CODE"].ToString();

                //삭제된 데이터 있는지 파악
                strQuery = " SELECT * FROM TSTD_MOLD " +
                     " WHERE PLT_CODE = " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) +
                     "   AND MOLD_CODE = " + ExtensionMethod.toDBString(paramDr["MOLD_CODE"]);

                DataTable dt = bizExecute.executeSelectQuery(strQuery);

                if (dt.Rows.Count > 0)
                    o_mold_code = paramDr["MOLD_CODE"].ToString();



                //해당 제품코드가 있는지 확인
                if (o_mold_code == "")
                {
                    

                    strQuery = "INSERT INTO TSTD_MOLD " +
                                    " ([PLT_CODE] " +
                                    " ,[MOLD_CODE] " +
                                    " ,[MODEL] " +
                                    " ,[MOLD_NAME] " +
                                    " ,[MOLD_NUM] " +
                                    " ,[MATERIAL] " +
                                    " ,[PROD_CODE] " +
                                    " ,[MC_CODE] " +
                                    " ,[CUST_DATE] " +
                                    " ,[PROD_DATE] " +
                                    " ,[PROD_VND] " +
                                    " ,[BALJU_DATE] " +
                                    " ,[BALJU_VND] " +
                                    " ,[SIZE] " +
                                    " ,[WEIGHT] " +
                                    " ,[TYPE] " +
                                    " ,[GATE] " +
                                    " ,[CAVITY] " +
                                    " ,[MOLD_EMP] " +
                                    " ,[ACC_SHOT] " +
                                    " ,[MOLD_NO]  " +
                                    " ,[SCOMMENT] " +
                                    " ,[REG_DATE] " +
                                    " ,[REG_EMP] " +
                                    " ,[DATA_FLAG]) " +
                                      " VALUES " +
                                      " ( " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MODEL"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_NAME"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_NUM"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MATERIAL"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MC_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["CUST_DATE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_DATE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_VND"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["BALJU_DATE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["BALJU_VND"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["SIZE"]) + ", " +
                                      ExtensionMethod.toDBDecimal(paramDr["WEIGHT"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["TYPE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["GATE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["CAVITY"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_EMP"]) + ", " +
                                      ExtensionMethod.toDBDecimal(paramDr["ACC_SHOT"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_NO"]) + ", " +
                                      ExtensionMethod.toDBInt(paramDr["SCOMMENT"]) + ", " +
                                      "GETDATE(), " +
                                      ExtensionMethod.toDBString(paramDr["REG_EMP"]) + ", " +
                                      " 0 ) ";

                    bizExecute.executeInsertQuery(strQuery);

                    DataTable paramTablePart = paramDS.Tables["RQSTDT_PART"];

                    foreach (DataRow row in paramDS.Tables["RQSTDT_PART"].Rows)
                    {
                        strQuery = "INSERT INTO TSTD_MOLD_PART " +
                                        " ([PLT_CODE] " +
                                        " ,[MOLD_CODE] " +
                                        " ,[PART_CODE] " +
                                        " ,[PART_NAME] " +
                                        " ,[PART_NUM] " +
                                        " ,[SIZE] " +
                                        " ,[QLTY] " +
                                        " ,[HARDNESS] " +
                                        " ,[PART_QTY] " +
                                        " ,[PROD_VND] " +
                                        " ,[BALJU_DATE] " +
                                        " ,[YPGO_DATE] " +
                                        " ,[SCOMMENT] " +
                                        " ,[DATA_FLAG]) " +
                                          " VALUES " +
                                          " ( " + ExtensionMethod.toDBString(row["PLT_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["MOLD_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_NAME"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_NUM"]) + ", " +
                                          ExtensionMethod.toDBString(row["SIZE"]) + ", " +
                                          ExtensionMethod.toDBString(row["QLTY"]) + ", " +
                                          ExtensionMethod.toDBString(row["HARDNESS"]) + ", " +
                                          ExtensionMethod.toDBInt(row["PART_QTY"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_VND"]) + ", " +
                                          ExtensionMethod.toDBString(row["BALJU_DATE"]) + ", " +
                                          ExtensionMethod.toDBString(row["YPGO_DATE"]) + ", " +
                                          ExtensionMethod.toDBString(row["SCOMMENT"]) + ", " +
                                          " 0 ) ";

                        bizExecute.executeInsertQuery(strQuery);

                    }
                }
                else
                {

                    strQuery = "UPDATE TSTD_MOLD " +
                                  " SET MOLD_NAME = " + ExtensionMethod.toDBString(paramDr["MOLD_NAME"]) +
                                  " , [MODEL] = " + ExtensionMethod.toDBString(paramDr["MODEL"]) +
                                  " , [MOLD_NUM] = " + ExtensionMethod.toDBString(paramDr["PROD_CODE"]) +
                                  " , [MATERIAL] = " + ExtensionMethod.toDBString(paramDr["PROD_CODE"]) +

                                  " , [PROD_CODE] = " + ExtensionMethod.toDBString(paramDr["PROD_CODE"]) +
                                  " , [MC_CODE] = " + ExtensionMethod.toDBString(paramDr["MC_CODE"]) +
                                  " , [CUST_DATE] = " + ExtensionMethod.toDBString(paramDr["PROD_DATE"]) +
                                  " , [PROD_DATE] = " + ExtensionMethod.toDBString(paramDr["PROD_DATE"]) +
                                  " , [PROD_VND] = " + ExtensionMethod.toDBString(paramDr["PROD_VND"]) +
                                  " , [BALJU_DATE] = " + ExtensionMethod.toDBString(paramDr["BALJU_DATE"]) +
                                  " , [BALJU_VND] = " + ExtensionMethod.toDBString(paramDr["BALJU_VND"]) +
                                  
                                  " , [SIZE] = " + ExtensionMethod.toDBString(paramDr["SIZE"]) +
                                  " , [WEIGHT] = " + ExtensionMethod.toDBDecimal(paramDr["WEIGHT"]) +
                                  " , [TYPE] = " + ExtensionMethod.toDBString(paramDr["TYPE"]) +
                                  " , [GATE] = " + ExtensionMethod.toDBString(paramDr["GATE"]) +
                                  " , [CAVITY] = " + ExtensionMethod.toDBString(paramDr["CAVITY"]) +

                                  " , [MOLD_EMP] = " + ExtensionMethod.toDBString(paramDr["MOLD_EMP"]) +
                                  " , [ACC_SHOT] = " + ExtensionMethod.toDBDecimal(paramDr["ACC_SHOT"]) +
                                  " , [MOLD_NO] = " + ExtensionMethod.toDBString(paramDr["MOLD_NO"]) +
                                  " , [SCOMMENT] = " + ExtensionMethod.toDBString(paramDr["SCOMMENT"]) +
                                  " , [MDFY_EMP] = " + ExtensionMethod.toDBString(paramDr["REG_EMP"]) +
                                  " , [MDFY_DATE] = GETDATE() " +
                                  " , [DATA_FLAG] = 0 " +
                                  " WHERE PLT_CODE = " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) +
                                  " AND MOLD_CODE = " + ExtensionMethod.toDBString(paramDr["MOLD_CODE"]);

                    bizExecute.executeInsertQuery(strQuery);

                    DataTable paramTablePart = paramDS.Tables["RQSTDT_PART"];

                    foreach (DataRow row in paramDS.Tables["RQSTDT_PART"].Rows)
                    {
                        if (row["O_PART_CODE"].ToString() != "")
                        {
                            strQuery = "UPDATE TSTD_MOLD_PART " +
                                            " SET PART_NAME = " + ExtensionMethod.toDBString(row["PART_NAME"]) +
                                            "  , PART_NUM = " + ExtensionMethod.toDBString(row["PART_NUM"]) +
                                            "  , SIZE = " + ExtensionMethod.toDBString(row["SIZE"]) +
                                            "  , QLTY = " + ExtensionMethod.toDBString(row["QLTY"]) +
                                            "  , HARDNESS = " + ExtensionMethod.toDBString(row["HARDNESS"]) +
                                            "  , PART_QTY = " + ExtensionMethod.toDBInt(row["PART_QTY"]) +
                                            "  , PROD_VND = " + ExtensionMethod.toDBString(row["PROD_VND"]) +
                                            "  , BALJU_DATE = " + ExtensionMethod.toDBString(row["BALJU_DATE"]) +
                                            "  , YPGO_DATE = " + ExtensionMethod.toDBString(row["YPGO_DATE"]) +
                                            "  , SCOMMENT = " + ExtensionMethod.toDBString(row["SCOMMENT"]) +
                                              " WHERE PLT_CODE =  " + ExtensionMethod.toDBString(row["PLT_CODE"]) + 
                                              "   AND MOLD_CODE = " + ExtensionMethod.toDBString(row["MOLD_CODE"]) + 
                                              "   AND PART_CODE = " + ExtensionMethod.toDBString(row["PART_CODE"]);
                        }
                        else
                        {
                            strQuery = "INSERT INTO TSTD_MOLD_PART " +
                                        " ([PLT_CODE] " +
                                        " ,[MOLD_CODE] " +
                                        " ,[PART_CODE] " +
                                        " ,[PART_NAME] " +
                                        " ,[PART_NUM] " +
                                        " ,[SIZE] " +
                                        " ,[QLTY] " +
                                        " ,[HARDNESS] " +
                                        " ,[PART_QTY] " +
                                        " ,[PROD_VND] " +
                                        " ,[BALJU_DATE] " +
                                        " ,[YPGO_DATE] " +
                                        " ,[SCOMMENT] " +
                                        " ,[DATA_FLAG]) " +
                                          " VALUES " +
                                          " ( " + ExtensionMethod.toDBString(row["PLT_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["MOLD_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_CODE"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_NAME"]) + ", " +
                                          ExtensionMethod.toDBString(row["PART_NUM"]) + ", " +
                                          ExtensionMethod.toDBString(row["SIZE"]) + ", " +
                                          ExtensionMethod.toDBString(row["QLTY"]) + ", " +
                                          ExtensionMethod.toDBString(row["HARDNESS"]) + ", " +
                                          ExtensionMethod.toDBInt(row["PART_QTY"]) + ", " +
                                          ExtensionMethod.toDBString(row["PROD_VND"]) + ", " +
                                          ExtensionMethod.toDBString(row["BALJU_DATE"]) + ", " +
                                          ExtensionMethod.toDBString(row["YPGO_DATE"]) + ", " +
                                          ExtensionMethod.toDBString(row["SCOMMENT"]) + ", " +
                                          " 0 ) ";
                            
                        }

                        bizExecute.executeInsertQuery(strQuery);
                    }

                }

                

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("MOLD_CODE", typeof(String));
                paramTable.Columns.Add("MOLD_LIKE", typeof(String));
                paramTable.Columns.Add("S_REG_DATE", typeof(String));
                paramTable.Columns.Add("E_REG_DATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = ExtensionMethod.PLT_CODE;
                paramRow["MOLD_CODE"] = paramDr["MOLD_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet selectSet = new DataSet();
                selectSet.Tables.Add(paramTable);


                return STD10A_SER(selectSet, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);            
            }
        }

        public static DataSet STD10A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string strQuery = _SelectQuery;

                string strWhere = " WHERE M.DATA_FLAG = 0 ";


                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                if (paramDr["PLT_CODE"].ToString() != "") strWhere += " AND M.PLT_CODE = '" + paramDr["PLT_CODE"].ToString() + "'";

                if (paramDr["MOLD_CODE"].ToString() != "") strWhere += " AND M.MOLD_CODE = '" + paramDr["MOLD_CODE"].ToString() + "'";

                if (paramDr["MOLD_LIKE"].ToString() != "")
                {
                    strWhere += " AND ( M.MOLD_CODE LIKE '%" + paramDr["MOLD_LIKE"].ToString() + "%' OR  ";
                    strWhere += "   M.MOLD_NAME LIKE '%" + paramDr["MOLD_LIKE"].ToString() + "%')  ";

                }

                if (paramDr["S_REG_DATE"].ToString() != "") strWhere += " M.REG_DATE '" + paramDr["S_REG_DATE"].ToString() + "' AND '" + paramDr["E_REG_DATE"].ToString() + "'";

                strQuery += strWhere;


                DataTable dtRslt = bizExecute.executeSelectQuery(strQuery).Copy();

                dtRslt.TableName = "RSLTDT";

                DataTable dtRqst = paramDS.Tables["RQSTDT"].Copy();

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);
                dsRslt.Tables.Add(dtRqst);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name); 
            }

        }

        public static DataSet STD10A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string strQuery = "SELECT P.PLT_CODE," +
                                " P.MOLD_CODE,  " +
                                " P.PART_CODE, P.PART_CODE AS O_PART_CODE, " +
                                " P.PART_NAME, " +
                                " P.PART_NUM, " +
                                " P.SIZE, " +
                                " P.QLTY, " +
                                " P.HARDNESS, " +
                                " P.PART_QTY, " +
                                " P.PROD_VND, " +
                                " V.VEN_NAME AS PROD_VND_NAME, " +
                                " P.BALJU_DATE, " +
                                " P.YPGO_DATE, " +
                                " P.SCOMMENT " +
                                " FROM TSTD_MOLD_PART P LEFT OUTER JOIN TSTD_VENDOR V " +
                                "   ON P.PLT_CODE = V.PLT_CODE " +
                                "  AND P.PROD_VND = V.VEN_CODE ";

                string strWhere = " WHERE P.DATA_FLAG = 0 ";

                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                if (paramDr["PLT_CODE"].ToString() != "") strWhere += " AND P.PLT_CODE = '" + paramDr["PLT_CODE"].ToString() + "'";

                if (paramDr["MOLD_CODE"].ToString() != "") strWhere += " AND P.MOLD_CODE = '" + paramDr["MOLD_CODE"].ToString() + "'";

                strQuery += strWhere;


                DataTable dtRslt = bizExecute.executeSelectQuery(strQuery).Copy();

                dtRslt.TableName = "RSLTDT";

                DataTable dtRqst = paramDS.Tables["RQSTDT"].Copy();

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);
                dsRslt.Tables.Add(dtRqst);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);            
            }
        }

        public static DataSet STD10A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string strQuery = "UPDATE TSTD_MOLD " +
                                      " SET DATA_FLAG = 2 " +
                                      " , DEL_DATE = GETDATE() " +
                                      " , DEL_EMP = " + ExtensionMethod.toDBString(row["DEL_EMP"]) +
                                      " , DEL_REASON = " + ExtensionMethod.toDBString(row["DEL_REASON"]) +
                                      " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                      " AND MOLD_CODE = " + ExtensionMethod.toDBString(row["MOLD_CODE"]);


                    bizExecute.executeInsertQuery(strQuery);

                    string strQuery2 = " UPDATE TSTD_MOLD_PART " +
                                    " SET DATA_FLAG = 2 " +
                                    " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                    "   AND MOLD_CODE = " + ExtensionMethod.toDBString(row["MOLD_CODE"]);

                    bizExecute.executeInsertQuery(strQuery2);
                }

                return STD10A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);            
            }
        }

        public static DataSet STD10A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    string strQuery = " DELETE FROM TSTD_MOLD_PART " +
                                    " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                    "   AND MOLD_CODE = " + ExtensionMethod.toDBString(row["MOLD_CODE"]) +
                                    "   AND PART_CODE = " + ExtensionMethod.toDBString(row["PART_CODE"]);


                    bizExecute.executeInsertQuery(strQuery);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);            
            }
        }


        public static DataTable QueryTableSchema()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("MOLD_CODE", typeof(String));
            paramTable.Columns.Add("MOLD_LIKE", typeof(String));
            paramTable.Columns.Add("S_REG_DATE", typeof(String));
            paramTable.Columns.Add("E_REG_DATE", typeof(String));


            return paramTable;
        }
    }
}
