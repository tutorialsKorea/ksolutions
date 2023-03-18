using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD09A
    {

        private static string _SelectQuery = "SELECT '' AS SEL,  P.PLT_CODE," +
                            " PROD_CODE, " +
                            " MODEL, " +
                            " PART, " +
                            " P.PROD_VND, " +
                            " PV.VEN_NAME AS PROD_VND_NAME, " +
                            " P.MAT_CODE, " +
                            " M.MAT_NAME, " +
                            " PROD_LTYPE, " +
                            " PROD_MTYPE, " +
                            " PROD_STYPE, " +
                            " MOLD_NO, " +
                            " CAVITY, " +
                            " TO_DATE, " +
                            " PACK_UNIT, " +
                            " UNIT_COST, " +
                            " P.SCOMMENT, " +
                            " P.HISTORY, " +
                            
                            " P.REG_DATE, P.REG_EMP, " +
                            " P.MDFY_DATE, P.MDFY_EMP " +
                            " FROM TSTD_PRODUCT P LEFT JOIN TSTD_MATERIAL M " +
                            "   ON P.PLT_CODE = M.PLT_CODE " +
                            "  AND P.MAT_CODE = M.MAT_CODE " +
                            "  LEFT JOIN TSTD_VENDOR PV " +
                            "    ON P.PLT_CODE = PV.PLT_CODE " +
                            "   AND P.PROD_VND = PV.VEN_CODE ";

        public static DataSet STD09A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                string strQuery = "";
                strQuery = "SELECT * FROM TSTD_PRODUCT WHERE PROD_CODE = " + ExtensionMethod.toDBString(paramDr["PROD_CODE"]);

                DataTable dt = bizExecute.executeSelectQuery(strQuery);

                if (dt.Rows.Count > 0)
                    paramDr["O_PROD_CODE"] = paramDr["PROD_CODE"];


                //해당 제품코드가 있는지 확인
                if (paramDr["O_PROD_CODE"].ToString() == "")
                {
                    strQuery = "INSERT INTO TSTD_PRODUCT " +
                                    " ([PLT_CODE] " +
                                    " ,[PROD_CODE] " +
                                    " ,[MODEL] " +
                                    " ,[PART] " +
                                    " ,[PROD_VND] " +
                                    " ,[MAT_CODE] " +
                                    " ,[PROD_LTYPE] " +
                                    " ,[PROD_MTYPE] " +
                                    " ,[PROD_STYPE] " +
                                    " ,[MOLD_NO] " +
                                    " ,[CAVITY] " +
                                    " ,[TO_DATE]  " +
                                    " ,[PACK_UNIT] " +
                                    " ,[UNIT_COST] " +
                                    " ,[SCOMMENT] " +
                                    " ,[HISTORY] " +
                                    " ,[PROD_IMAGE] " +
                                    " ,[REG_DATE] " +
                                    " ,[REG_EMP] " +
                                    " ,[DATA_FLAG]) " +
                                      " VALUES " +
                                      " ( " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MODEL"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PART"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_VND"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MAT_CODE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_LTYPE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_MTYPE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["PROD_STYPE"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["MOLD_NO"]) + ", " +
                                      ExtensionMethod.toDBInt(paramDr["CAVITY"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["TO_DATE"]) + ", " +
                                      ExtensionMethod.toDBInt(paramDr["PACK_UNIT"]) + ", " +
                                      ExtensionMethod.toDBDecimal(paramDr["UNIT_COST"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["SCOMMENT"]) + ", " +
                                      ExtensionMethod.toDBString(paramDr["HISTORY"]) + ", " +
                                      " @PROD_IMAGE, " + //paramDr["PROD_IMAGE"] + ", " +
                                      "GETDATE(), " +
                                      ExtensionMethod.toDBString(paramDr["REG_EMP"]) + ", " +
                                      " 0 ) ";
                }
                else
                {

                    strQuery = "UPDATE TSTD_PRODUCT " +
                                  " SET MODEL = " + ExtensionMethod.toDBString(paramDr["MODEL"]) +
                                  " , [PART] = " + ExtensionMethod.toDBString(paramDr["PART"]) +
                                  " , [PROD_VND] = " + ExtensionMethod.toDBString(paramDr["PROD_VND"]) +
                                  " , [MAT_CODE] = " + ExtensionMethod.toDBString(paramDr["MAT_CODE"]) +
                                  " , [PROD_LTYPE] = " + ExtensionMethod.toDBString(paramDr["PROD_LTYPE"]) +
                                  " , [PROD_MTYPE] = " + ExtensionMethod.toDBDecimal(paramDr["PROD_MTYPE"]) +
                                  " , [PROD_STYPE] = " + ExtensionMethod.toDBString(paramDr["PROD_STYPE"]) +
                                  " , [MOLD_NO] = " + ExtensionMethod.toDBString(paramDr["MOLD_NO"]) +
                                  " , [CAVITY] = " + ExtensionMethod.toDBInt(paramDr["CAVITY"]) +
                                  " , [TO_DATE] = " + ExtensionMethod.toDBString(paramDr["TO_DATE"]) +
                                  " , [PACK_UNIT] = " + ExtensionMethod.toDBInt(paramDr["PACK_UNIT"]) +
                                  " , [UNIT_COST] = " + ExtensionMethod.toDBDecimal(paramDr["UNIT_COST"]) +
                                  " , [SCOMMENT] = " + ExtensionMethod.toDBString(paramDr["SCOMMENT"]) +
                                  " , [HISTORY] = " + ExtensionMethod.toDBString(paramDr["HISTORY"]) +
                                  " , [PROD_IMAGE] = @PROD_IMAGE " + //(paramDr["PROD_IMAGE"]) +
                                  " , [MDFY_EMP] = " + ExtensionMethod.toDBString(paramDr["REG_EMP"]) +
                                  " , [MDFY_DATE] = GETDATE() " +
                                  " , DATA_FLAG = 0 " +
                                  " WHERE PLT_CODE = " + ExtensionMethod.toDBString(paramDr["PLT_CODE"]) +
                                  " AND PROD_CODE = " + ExtensionMethod.toDBString(paramDr["PROD_CODE"]);
                }

                
                SqlParameter[] sqlparams = new SqlParameter[1];
                sqlparams[0] = new SqlParameter("@PROD_IMAGE", SqlDbType.Image);
                sqlparams[0].Value = paramDr["PROD_IMAGE"];

                bizExecute.executeInsertQuery(strQuery, sqlparams);

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("PROD_CODE", typeof(String));
                paramTable.Columns.Add("PROD_LIKE", typeof(String));
                paramTable.Columns.Add("PROD_VND", typeof(String));
                paramTable.Columns.Add("S_REG_DATE", typeof(String));
                paramTable.Columns.Add("E_REG_DATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = ExtensionMethod.PLT_CODE;
                paramRow["PROD_CODE"] = paramDr["PROD_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet selectSet = new DataSet();
                selectSet.Tables.Add(paramTable);

                return STD09A_SER(selectSet, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD09A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string strQuery = _SelectQuery;

                string strWhere = " WHERE P.DATA_FLAG = 0 ";


                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                if (paramDr["PLT_CODE"].ToString() != "") strWhere += " AND P.PLT_CODE = '" + paramDr["PLT_CODE"].ToString() + "'";

                if (paramDr["PROD_CODE"].ToString() != "") strWhere += " AND P.PROD_CODE = '" + paramDr["PROD_CODE"].ToString() + "'";

                if (paramDr["PROD_VND"].ToString() != "") strWhere += " AND P.PROD_VND = '" + paramDr["PROD_VND"].ToString() + "'";

                if (paramDr["PROD_LIKE"].ToString() != "")
                {
                    strWhere += " AND P.PROD_CODE LIKE '%" + paramDr["PROD_LIKE"].ToString() + "%'  ";

                }

                if (paramDr["S_REG_DATE"].ToString() != "") strWhere += " P.REG_DATE '" + paramDr["S_REG_DATE"].ToString() + "' AND '" + paramDr["E_REG_DATE"].ToString() + "'";

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

        public static DataSet STD09A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                string strQuery = " SELECT PROD_IMAGE FROM TSTD_PRODUCT ";

                string strWhere = " WHERE DATA_FLAG = 0 " +
                                "   AND PLT_CODE = '" + ExtensionMethod.PLT_CODE + "'" +
                                "   AND PROD_CODE = '" + paramDr["PROD_CODE"].ToString() + "'";

                strQuery += strWhere;

                DataTable dtRslt = bizExecute.executeSelectQuery(strQuery).Copy();

                dtRslt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD09A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataRow paramDr = paramDS.Tables["RQSTDT"].Rows[0];

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string strQuery = "UPDATE TSTD_PRODUCT " +
                                      " SET DATA_FLAG = 2 " +
                                      " , DEL_DATE = GETDATE() " +
                                      " , DEL_EMP = " + ExtensionMethod.toDBString(row["DEL_EMP"]) +
                                      " , DEL_REASON = " + ExtensionMethod.toDBString(row["DEL_REASON"]) +
                                      " WHERE PLT_CODE = " + ExtensionMethod.toDBString(row["PLT_CODE"]) +
                                      " AND PROD_CODE = " + ExtensionMethod.toDBString(row["PROD_CODE"]);

                    bizExecute.executeInsertQuery(strQuery); //  .executeSelectQuery(strQuery).Copy();

                }

                return paramDS;
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
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("PROD_VND", typeof(String));
            paramTable.Columns.Add("PROD_LIKE", typeof(String));
            paramTable.Columns.Add("S_REG_DATE", typeof(String));
            paramTable.Columns.Add("E_REG_DATE", typeof(String));

            return paramTable;
        }

        //delegate SetProgressValueCallback(int Value);
        //private void SetValueProgress(int Value)
        //{
        //    if (this.Progressbar1.InvokeRequired)
        //    {
        //        this.Invoke(new SetProgressValueCallback(SetProValue), new object[] { Value});
        //    }
        //    else
        //    {
        //        this.Progressbar1.Value = Value;
        //    }
        //}

        //private void SetProValue(int Value)
        //{
        //    this.Progressbar1.Value = Value;
        //}
    }
}
