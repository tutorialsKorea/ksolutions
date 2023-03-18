using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS77A
    {
        public static DataSet SYS77A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
             
                DataTable dtRslt = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS77A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("REG_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("REG_DATE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG")) paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));
                
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {                                        

                    DataTable dtParam = UTIL.GetRowToDt(row);

                    //dtParam.Rows[0]["MENU_CODE"] = dtParam.Rows[0]["O_MENU_CODE"];

                    //1. 메뉴리스트 데이터 조회
                    DataTable dtMenuList = DSYS.TSYS_MENULIST.TSYS_MENULIST_SER(dtParam, bizExecute);


                    //1-1. 데이터 없으면 resource id 생성 및 menulist insert
                    if (dtMenuList.Rows.Count == 0)
                    {

                        UTIL.SetBizAddColumnToValue(dtParam, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtParam, "RES_LANG", "", typeof(String));
                        UTIL.SetBizAddColumnToValue(dtParam, "RES_TYPE", "", typeof(Int32));
                        UTIL.SetBizAddColumnToValue(dtParam, "RES_CONTENTS", "", typeof(String));

                        dtParam.Rows[0]["RES_LANG"] = dtParam.Rows[0]["LANG"];
                        dtParam.Rows[0]["RES_TYPE"] = 1;
                        dtParam.Rows[0]["RES_CONTENTS"] = dtParam.Rows[0]["MENU_NAME"];
                        string res_id = CTRL.CTRL.CreateResourceID(UTIL.GetDtToDs(dtParam), bizExecute);

                        //dtParam.Rows[0]["REG_DATE"] = dt;
                        //paramDS.Tables["RQSTDT"].Rows[0]["REG_EMP"] = row["REG_EMP"];
                        //dtParam.Rows[0]["DATA_FLAG"] = 0;
                        dtParam.Rows[0]["RES_ID"] = res_id;

                        DSYS.TSYS_MENULIST.TSYS_MENULIST_INS(dtParam, bizExecute);
                    }
                    else
                    {
                        
                        if (dtMenuList.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            if (dtParam.Rows[0]["OVERWRITE"].ToString() == "1")
                            {
                                UTIL.SetBizAddColumnToValue(dtParam, "O_MENU_CODE", dtParam.Rows[0]["MENU_CODE"], typeof(Byte));

                                UTIL.SetBizAddColumnToValue(dtParam, "RES_ID", dtMenuList.Rows[0]["RES_ID"], typeof(string));
                                //1-2. 삭제된 데이터이고, 이력데이터 덮어쓰기이면 Update
                                DSYS.TSYS_MENULIST.TSYS_MENULIST_UPD(dtParam, bizExecute);

                                UTIL.SetBizAddColumnToValue(dtParam, "RES_LANG", "LANG");
                                UTIL.SetBizAddColumnToValue(dtParam, "RES_CONTENTS", "MENU_NAME");
                                UTIL.SetBizAddColumnToValue(dtParam, "RES_TYPE", "1", typeof(Int32));

                                DataTable dtExist = DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_SER(dtParam, bizExecute);
                                if (dtExist.Rows.Count > 0)
                                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_UPD(dtParam, bizExecute);
                                else
                                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_INS(dtParam, bizExecute);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY);
                            }
                        }    
                        else
                        {
                            //1-3. 데이터 수정인 경우 update resource/menulist
                            DSYS.TSYS_MENULIST.TSYS_MENULIST_UPD(dtParam, bizExecute);                            

                            UTIL.SetBizAddColumnToValue(dtParam, "RES_LANG", "LANG");
                            UTIL.SetBizAddColumnToValue(dtParam, "RES_CONTENTS", "MENU_NAME");
                            UTIL.SetBizAddColumnToValue(dtParam, "RES_TYPE", "1", typeof(Int32));                           

                            DataTable dtExist = DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_SER(dtParam, bizExecute);
                            if (dtExist.Rows.Count > 0)
                                DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_UPD(dtParam, bizExecute);
                            else
                            {

                                if (dtParam.Rows[0]["RES_ID"].isNullOrEmpty())
                                {
                                    string res_id = CTRL.CTRL.CreateResourceID(UTIL.GetDtToDs(dtParam), bizExecute);
                                    dtParam.Rows[0]["RES_ID"] = res_id;
                                }
                                else
                                {
                                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_INS(dtParam, bizExecute);
                                }
                            }
                        }
                        

                    }
                }
                

                if (paramDS.Tables["RQSTDT2"].Rows.Count > 0)
                {
                    DataTable dtParam2 = paramDS.Tables["RQSTDT2"];

                    //SYS77A_DEL
                    DSYS.TSYS_MENULIST.TSYS_MENULIST_UDE(dtParam2, bizExecute);

                    DSYS.TSYS_STRINGTABLE.TSYS_STRINGTABLE_DEL(dtParam2, bizExecute);


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
