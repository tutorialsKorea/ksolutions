using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace LSEU
{

    public class LSEU
    {

        /// <summary>
        /// 표준공정 수정되면 표준공정계획 표준BOP 가용설비 모두 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static void UPDATE_STD_PROC(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSerMc = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER2(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtSerProc = DSTD.TSTD_PROCPLAN.TSTD_PROCPLAN_SER3(UTIL.GetRowToDt(row), bizExecute);


                    foreach(DataRow procRow in dtSerProc.Rows)
                    {
                        string loadbleMc = null;

                        if (object.Equals(procRow["LOADABLE_MC"], DBNull.Value))
                        {
                            loadbleMc = string.Empty;
                        }
                        else
                        {
                            loadbleMc = (string)procRow["LOADABLE_MC"];
                        }

                        string[] loadableMcs = loadbleMc.Split(';');

                        string newLoadableMc = null;

                        int cnt = 1;

                        foreach (string mc in loadableMcs)
                        {
                            bool check = false;

                            foreach (DataRow availMc in dtSerMc.Rows)
                            {
                                if (mc == (string)availMc["MC_CODE"])
                                {
                                    check = true;
                                    break;
                                }
                            }

                            if (check == true)
                            {
                                if (cnt < loadableMcs.Length)
                                {
                                    newLoadableMc += mc + ";";
                                }
                                else
                                {
                                    newLoadableMc += mc;
                                }
                            }

                            ++cnt;

                        }


                        procRow["LOADABLE_MC"] = newLoadableMc;

                    }

                    if (dtSerProc.Rows.Count > 0)
                    {
                        DSTD.TSTD_PROCPLAN.TSTD_PROCPLAN_UPD(dtSerProc, bizExecute);
                    }

                    DataTable dtSerBopProc = DLSE.LSE_STDBOP_PROC.LSE_STDBOP_PROC_SER3(UTIL.GetRowToDt(row), bizExecute);

                    foreach(DataRow bopProcRow in dtSerBopProc.Rows)
                    {
                        string loadbleMc = null;

                        if (object.Equals(bopProcRow["LOADABLE_MC"], DBNull.Value))
                        {
                            loadbleMc = string.Empty;
                        }
                        else
                        {
                            loadbleMc = (string)bopProcRow["LOADABLE_MC"];
                        }



                        string[] loadableMcs = loadbleMc.Split(';');

                        string newLoadableMc = null;

                        int cnt = 1;

                        foreach (string mc in loadableMcs)
                        {
                            bool check = false;

                            foreach (DataRow availMc in dtSerMc.Rows)
                            {
                                if (mc == (string)availMc["MC_CODE"])
                                {
                                    check = true;
                                    break;
                                }
                            }

                            if (check == true)
                            {
                                if (cnt < loadableMcs.Length)
                                {
                                    newLoadableMc += mc + ";";
                                }
                                else
                                {
                                    newLoadableMc += mc;
                                }
                            }

                            ++cnt;

                        }


                        bopProcRow["LOADABLE_MC"] = newLoadableMc;
                    }

                    if(dtSerBopProc.Rows.Count > 0)
                    {
                        DLSE.LSE_STDBOP_PROC.LSE_STDBOP_PROC_UPD2(dtSerBopProc, bizExecute);
                    }

                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        

    }
}
