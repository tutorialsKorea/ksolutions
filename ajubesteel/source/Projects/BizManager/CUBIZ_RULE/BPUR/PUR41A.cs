using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;


namespace BPUR
{
    public class PUR41A
    {
        public static DataSet PUR41A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "13", typeof(String));

                DataTable dtRslt_M = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_M.TableName = "RSLTDT";

                DataTable dtRslt_PM = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_PM.TableName = "RSLTDT";

                DataTable dtRslt_PO = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_PO.TableName = "RSLTDT";

                paramDS.Merge(dtRslt_M);
                paramDS.Merge(dtRslt_PM);
                paramDS.Merge(dtRslt_PO);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR41A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string AUTOAPP_CONF_NAME = "AUTOAPP_MAT_BAL";
                string MENU_CODE = "PUR03B";

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(String));

                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Merge(dtRslt);

                //자동승인 환경설정 조회
                DataTable dtConf = paramDS.Tables["RQSTDT"];
                UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", MENU_CODE, typeof(String));
                UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", AUTOAPP_CONF_NAME, typeof(String));

                DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "13", typeof(String));

                    //DataTable dtRslt3 = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                    DataTable dtRslt4 = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                    //dtRslt3.Columns.Add("SEL");
                    //dtRslt4.Columns.Add("SEL");

                    UTIL.SetBizAddColumnToValue(dtRslt4, "SEL", "1", typeof(String));

                    //dtRslt3.TableName = "RSLTDT";
                    dtRslt4.TableName = "RSLTDT";

                    //paramDS.Merge(dtRslt3);
                    paramDS.Merge(dtRslt4);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR41A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string AUTOAPP_CONF_NAME = "AUTOAPP_OUT_BAL";
                string MENU_CODE = "PUR13B";

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(String));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Merge(dtRslt);

                //자동승인 환경설정 조회
                DataTable dtConf = paramDS.Tables["RQSTDT"];
                UTIL.SetBizAddColumnToValue(dtConf, "MENU_CODE", MENU_CODE, typeof(String));
                UTIL.SetBizAddColumnToValue(dtConf, "CONF_NAME", AUTOAPP_CONF_NAME, typeof(String));

                DataSet dsConfRslt = CTRL.CTRL.GET_MENU_CONFIG(UTIL.GetDtToDs(dtConf), bizExecute);

                if (dsConfRslt.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].ToString() == "1")
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "13", typeof(String));

                    DataTable dtRslt3 = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                    //dtRslt3.Columns.Add("SEL");
                    UTIL.SetBizAddColumnToValue(dtRslt3, "SEL", "1", typeof(String));

                    dtRslt3.TableName = "RSLTDT";

                    paramDS.Merge(dtRslt3);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet PUR41A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD6(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
