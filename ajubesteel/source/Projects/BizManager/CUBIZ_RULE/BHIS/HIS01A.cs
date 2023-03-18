using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BHIS
{
    public class HIS01A
    {
        public static DataSet HIS01A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_STD_PM_QUERY.THIS_STD_PM_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_MC_PARTS_QUERY.THIS_PM_MC_PARTS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_STD_PM_PARTS_QUERY.THIS_STD_PM_PARTS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltPm = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPm.Columns.Add("SEL", typeof(string));
                dtRsltPm.TableName = "RSLTDT_PM";


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(int));
                DataTable dtRsltMc = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltMc.Columns.Add("SEL", typeof(string));
                dtRsltMc.TableName = "RSLTDT_MC";

                paramDS.Tables.Add(dtRsltPm);
                paramDS.Tables.Add(dtRsltMc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable resultTable = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                    if (resultTable.Rows.Count > 0)
                    {
                        throw UTIL.SetException("등록된 계획 정보가 존재하여 삭제하실 수 없습니다."
                                , row["MTN_CODE"].ToString()
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , 200090, row);
                    }
                    else
                    {
                        DHIS.THIS_STD_PM.THIS_STD_PM_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                        DHIS.THIS_STD_PM_PARTS.THIS_STD_PM_PARTS_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                        DHIS.THIS_PM_MC.THIS_PM_MC_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                        DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_DEL(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_INS1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string mtnCode = null;

                foreach(DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    if(paramRow["MTN_CODE"].isNullOrEmpty())
                    {
                        mtnCode = UTIL.UTILITY_GET_SERIALNO(paramRow["PLT_CODE"].ToString(), "MTN",UTIL.emSerialFormat.YYMMDD,"", bizExecute);
                        paramRow["MTN_CODE"] = mtnCode;
                    }

                    DataTable serTable = DHIS.THIS_STD_PM.THIS_STD_PM_SER(UTIL.GetRowToDt(paramRow), bizExecute);

                    if(serTable.Rows.Count ==0)
                    {
                        DHIS.THIS_STD_PM.THIS_STD_PM_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        DHIS.THIS_STD_PM.THIS_STD_PM_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }

                foreach (DataRow paramRow in paramDS.Tables["RQSTDT_PARTS"].Rows)
                {
                    if(paramRow["MTN_CODE"].isNullOrEmpty())
                    {
                        paramRow["MTN_CODE"] = mtnCode;
                    }

                    DataTable serTable = DHIS.THIS_STD_PM_PARTS.THIS_STD_PM_PARTS_SER(UTIL.GetRowToDt(paramRow), bizExecute);
                    
                    if (paramRow["IS_DEL"].Equals("1"))
                    {
                        DHIS.THIS_STD_PM_PARTS.THIS_STD_PM_PARTS_DEL(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        if (serTable.Rows.Count == 0)
                        {
                            DHIS.THIS_STD_PM_PARTS.THIS_STD_PM_PARTS_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                        }
                        else
                        {
                            DHIS.THIS_STD_PM_PARTS.THIS_STD_PM_PARTS_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                        }
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    if(paramRow["IS_DEL"].Equals("1"))
                    {
                        //삭제
                        DHIS.THIS_PM_MC.THIS_PM_MC_DEL(UTIL.GetRowToDt(paramRow), bizExecute);

                        DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_DEL(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        DataTable rsltDt = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(UTIL.GetRowToDt(paramRow), bizExecute);

                        if (rsltDt.Rows.Count > 0)
                        {
                            //업데이트
                            DHIS.THIS_PM_MC.THIS_PM_MC_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                        }
                        else
                        {
                            //입력
                            DHIS.THIS_PM_MC.THIS_PM_MC_INS(UTIL.GetRowToDt(paramRow), bizExecute);

                            if (paramRow["IS_USE"].Equals(1))
                            {
                                DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_COPY(UTIL.GetRowToDt(paramRow), bizExecute);
                            }
                        }
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS01A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable rsltDt = DHIS.THIS_PM_MC_PARTS_QUERY.THIS_PM_MC_PARTS_QUERY1(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (rsltDt.Rows.Count > 0)
                    {
                        //업데이트
                        DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        //입력
                        DHIS.THIS_PM_MC_PARTS.THIS_PM_MC_PARTS_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }

                return HIS01A_SER3(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
