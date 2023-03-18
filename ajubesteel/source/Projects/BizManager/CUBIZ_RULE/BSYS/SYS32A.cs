using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS32A
    {
        public static DataSet SYS32A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_STRINGTABLE_QUERY.TSYS_STRINGTABLE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS32A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                string newResID;

                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count <= 0) return null;

                DataTable dtSer = DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_SER(dtParam, bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    newResID = dtSer.Rows[0]["RES_ID"].ToString();
                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_UPD(dtParam, bizExecute);
                }
                else
                {
                    if (dtParam.Rows[0]["RES_ID"].isNull())
                    {
                        newResID = CTRL.CTRL.CreateResourceID(paramDS, bizExecute);
                        dtParam.Rows[0]["RES_ID"] = newResID;
                    }
                    //DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_INS(dtParam, bizExecute);
                }

                DataTable dtResult = DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_SER(dtParam, bizExecute);
                dtResult.TableName = "RSLTDT";

                dsResult.Tables.Add(dtResult);

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// resource 일괄변경

        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static void SYS32A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                

                DataTable dtParam = paramDS.Tables["RQSTDT"];

                if (dtParam.Rows.Count <= 0) return;

                DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_UPD3(dtParam, bizExecute);

               
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 다국어 리소스 생성
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void SYS32A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //
                DataTable dtResult = DSYS.TSYS_STRINGTABLE_QUERY.TSYS_STRINGTABLE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtResult.Rows.Count > 0)
                {
                    if (!dtResult.Columns.Contains("RES_LANG")) dtResult.Columns.Add("RES_LANG");

                    foreach (DataRow dr in dtResult.Rows)
                    {
                        dr["RES_LANG"] = paramDS.Tables["RQSTDT"].Rows[0]["TARGET_LANG"];
                    }

                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_INS(dtResult, bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// resource 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void SYS32A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_DEL(paramDS.Tables["RQSTDT"], bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
