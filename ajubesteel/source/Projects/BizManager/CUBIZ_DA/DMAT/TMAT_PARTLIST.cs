using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DMAT
{
    public class TMAT_PARTLIST
    {
        public static DataTable TMAT_PARTLIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID			   ");
                    sbQuery.Append(" ,PT_NO			   ");
                    sbQuery.Append(" ,PROD_CODE		   ");
                    sbQuery.Append(" ,PART_CODE		   ");
                    sbQuery.Append(" ,PART_NUM		   ");
                    sbQuery.Append(" ,PT_NAME		   ");
                    sbQuery.Append(" ,PART_PRODTYPE	   ");
                    sbQuery.Append(" ,PART_QLTY		   ");
                    sbQuery.Append(" ,PART_SPEC		   ");
                    sbQuery.Append(" ,PART_SPEC1	   ");
                    sbQuery.Append(" ,PART_QTY		   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME	   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1   ");
                    sbQuery.Append(" ,UNIT_COST		   ");
                    sbQuery.Append(" ,MAT_COST		   ");
                    sbQuery.Append(" ,DRAW_EMP		   ");
                    sbQuery.Append(" ,DRAW_NO		   ");
                    sbQuery.Append(" ,O_PT_ID		   ");
                    sbQuery.Append(" ,INS_FLAG		   ");
                    sbQuery.Append(" ,PUR_STAT		   ");
                    sbQuery.Append(" ,SCOMMENT		   ");
                    sbQuery.Append(" ,ROUT_CODE		   ");

                    sbQuery.Append(" ,Tab_Machine		   ");
                    sbQuery.Append(" ,MakeSideHole		   ");
                    sbQuery.Append(" ,Slit_Division		   ");
                    sbQuery.Append(" ,Material		   ");
                    sbQuery.Append(" ,Surface_Treat		   ");
                    sbQuery.Append(" ,After_Treat		   ");
                    sbQuery.Append(" ,MAKE_DESC		   ");

                    sbQuery.Append(" ,REG_DATE		   ");
                    sbQuery.Append(" ,REG_EMP		   ");
                    sbQuery.Append(" ,MDFY_DATE		   ");
                    sbQuery.Append(" ,MDFY_EMP		   ");
                    sbQuery.Append(" ,DEL_DATE		   ");
                    sbQuery.Append(" ,DEL_EMP		   ");
                    sbQuery.Append(" ,DATA_FLAG		   ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_PARTLIST_SER_(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID			   ");
                    sbQuery.Append(" ,PT_NO			   ");
                    sbQuery.Append(" ,PROD_CODE		   ");
                    sbQuery.Append(" ,PART_CODE		   ");
                    sbQuery.Append(" ,PART_NUM		   ");
                    sbQuery.Append(" ,PT_NAME		   ");
                    sbQuery.Append(" ,PART_PRODTYPE	   ");
                    sbQuery.Append(" ,PART_QLTY		   ");
                    sbQuery.Append(" ,PART_SPEC		   ");
                    sbQuery.Append(" ,PART_SPEC1	   ");
                    sbQuery.Append(" ,PART_QTY		   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME	   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1   ");
                    sbQuery.Append(" ,UNIT_COST		   ");
                    sbQuery.Append(" ,MAT_COST		   ");
                    sbQuery.Append(" ,DRAW_EMP		   ");
                    sbQuery.Append(" ,DRAW_NO		   ");
                    sbQuery.Append(" ,O_PT_ID		   ");
                    sbQuery.Append(" ,INS_FLAG		   ");
                    sbQuery.Append(" ,PUR_STAT		   ");
                    sbQuery.Append(" ,SCOMMENT		   ");
                    sbQuery.Append(" ,ROUT_CODE		   ");

                    sbQuery.Append(" ,Tab_Machine		   ");
                    sbQuery.Append(" ,MakeSideHole		   ");
                    sbQuery.Append(" ,Slit_Division		   ");
                    sbQuery.Append(" ,Material		   ");
                    sbQuery.Append(" ,Surface_Treat		   ");
                    sbQuery.Append(" ,After_Treat		   ");
                    sbQuery.Append(" ,MAKE_DESC		   ");
                    sbQuery.Append(" ,IS_REVISION		   ");
                    sbQuery.Append(" ,IS_REMCT		   ");
                    sbQuery.Append(" ,IS_MODIFY		   ");
                    sbQuery.Append(" ,REG_DATE		   ");
                    sbQuery.Append(" ,REG_EMP		   ");
                    sbQuery.Append(" ,MDFY_DATE		   ");
                    sbQuery.Append(" ,MDFY_EMP		   ");
                    sbQuery.Append(" ,DEL_DATE		   ");
                    sbQuery.Append(" ,DEL_EMP		   ");
                    sbQuery.Append(" ,DATA_FLAG		   ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_PARTLIST_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PT_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PT_NAME ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,PART_QLTY ");
                    sbQuery.Append(" ,PART_SPEC ");
                    sbQuery.Append(" ,PART_SPEC1 ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,WEIGHT_VOLUME ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,DRAW_EMP ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,O_PT_ID ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OUT_REQ ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,WO_PART ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,IS_PLM_DEL ");
                    sbQuery.Append(" ,PART_PUID ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_PARTLIST_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PT_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PT_NAME ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,PART_QLTY ");
                    sbQuery.Append(" ,PART_SPEC ");
                    sbQuery.Append(" ,PART_SPEC1 ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,WEIGHT_VOLUME ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,DRAW_EMP ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,O_PT_ID ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OUT_REQ ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,WO_PART ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,IS_PLM_DEL ");
                    sbQuery.Append(" ,PART_PUID ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_PARTLIST_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PT_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PT_NAME ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,PART_QLTY ");
                    sbQuery.Append(" ,PART_SPEC ");
                    sbQuery.Append(" ,PART_SPEC1 ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,WEIGHT_VOLUME ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,DRAW_EMP ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,O_PT_ID ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OUT_REQ ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,WO_PART ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,IS_PLM_DEL ");
                    sbQuery.Append(" ,PART_PUID ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");
                    sbQuery.Append(" AND ISNULL(O_PT_ID,'') = '' AND LEFT(PART_CODE, 1) = 'A' "); 
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TMAT_PARTLIST_SER5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PT_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PT_NAME ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,PART_QLTY ");
                    sbQuery.Append(" ,PART_SPEC ");
                    sbQuery.Append(" ,PART_SPEC1 ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,WEIGHT_VOLUME ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,DRAW_EMP ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,O_PT_ID ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OUT_REQ ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,WO_PART ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,IS_PLM_DEL ");
                    sbQuery.Append(" ,PART_PUID ");
                    sbQuery.Append(" FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND LEFT(PART_CODE,1) = 'A' ");
                    sbQuery.Append(" AND ISNULL(O_PT_ID, '') = '' ");
                    sbQuery.Append(" AND DATA_FLAG = 0 ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //public static DataTable TMAT_PARTLIST_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        DataSet dsResult = new DataSet();

        //        if (dtParam.Rows.Count > 0)
        //        {
        //            StringBuilder sbQuery = new StringBuilder();

        //            sbQuery.Append(" SELECT PLT_CODE   ");
        //            sbQuery.Append(" ,PT_ID			   ");
        //            sbQuery.Append(" ,PT_NO			   ");
        //            sbQuery.Append(" ,PROD_CODE		   ");
        //            sbQuery.Append(" ,PART_CODE		   ");
        //            sbQuery.Append(" ,PART_NUM		   ");
        //            sbQuery.Append(" ,PT_NAME		   ");
        //            sbQuery.Append(" ,PART_PRODTYPE	   ");
        //            sbQuery.Append(" ,PART_QLTY		   ");
        //            sbQuery.Append(" ,PART_SPEC		   ");
        //            sbQuery.Append(" ,PART_SPEC1	   ");
        //            sbQuery.Append(" ,PART_QTY		   ");
        //            sbQuery.Append(" ,WEIGHT_VOLUME	   ");
        //            sbQuery.Append(" ,WEIGHT_VOLUME1   ");
        //            sbQuery.Append(" ,UNIT_COST		   ");
        //            sbQuery.Append(" ,MAT_COST		   ");
        //            sbQuery.Append(" ,DRAW_EMP		   ");
        //            sbQuery.Append(" ,DRAW_NO		   ");
        //            sbQuery.Append(" ,O_PT_ID		   ");
        //            sbQuery.Append(" ,INS_FLAG		   ");
        //            sbQuery.Append(" ,PUR_STAT		   ");
        //            sbQuery.Append(" ,SCOMMENT		   ");
        //            sbQuery.Append(" ,REG_DATE		   ");
        //            sbQuery.Append(" ,REG_EMP		   ");
        //            sbQuery.Append(" ,MDFY_DATE		   ");
        //            sbQuery.Append(" ,MDFY_EMP		   ");
        //            sbQuery.Append(" ,DEL_DATE		   ");
        //            sbQuery.Append(" ,DEL_EMP		   ");
        //            sbQuery.Append(" ,DATA_FLAG		   ");
        //            sbQuery.Append(" FROM TMAT_PARTLIST");
        //            sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
        //            sbQuery.Append(" AND PT_ID = @PT_ID ");
        //            sbQuery.Append(" AND DATA_FLAG = 0 ");

        //            foreach (DataRow row in dtParam.Rows)
        //            {
        //                bool isHasColumn = true;

        //                if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
        //                if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

        //                if (isHasColumn == true)
        //                {

        //                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

        //                    sourceTable.TableName = "RSLTDT";
        //                    dsResult.Merge(sourceTable);
        //                }
        //            }
        //        }


        //        return UTIL.GetDsToDt(dsResult);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        public static void TMAT_PARTLIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_PARTLIST (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,PT_NO ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,PART_NUM ");
                    sbQuery.Append(" ,PT_NAME ");
                    sbQuery.Append(" ,PART_PRODTYPE ");
                    sbQuery.Append(" ,PART_QLTY ");
                    sbQuery.Append(" ,PART_SPEC ");
                    sbQuery.Append(" ,PART_SPEC1 ");
                    sbQuery.Append(" ,PART_QTY ");
                    sbQuery.Append(" ,ORD_QTY ");
                    sbQuery.Append(" ,O_PART_QTY ");
                    sbQuery.Append(" ,WEIGHT_VOLUME ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,MAT_COST ");
                    sbQuery.Append(" ,DRAW_EMP ");
                    sbQuery.Append(" ,DRAW_NO ");
                    sbQuery.Append(" ,O_PT_ID ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,PUR_STAT ");
                    sbQuery.Append(" ,OUT_REQ ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE ");
                    sbQuery.Append(" ,WO_PART ");
                    sbQuery.Append(" ,IS_PLM_DEL ");
                    sbQuery.Append(" ,PART_PUID ");
                    sbQuery.Append(" ,PREV_PART_CODE ");
                    sbQuery.Append(" ,PREV_PT_ID ");
                    sbQuery.Append(" ,PREV_O_PT_ID ");

                    sbQuery.Append(" ,Tab_Machine ");
                    sbQuery.Append(" ,MakeSideHole ");
                    sbQuery.Append(" ,Slit_Division ");
                    sbQuery.Append(" ,Material ");
                    sbQuery.Append(" ,Surface_Treat ");
                    sbQuery.Append(" ,After_Treat ");
                    sbQuery.Append(" ,MAKE_DESC ");
                    sbQuery.Append(" ,IS_COPY_SIDE ");
                    sbQuery.Append(" ,IS_SIDE "); 

                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@PT_ID ");
                    sbQuery.Append(" ,@PT_NO ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,@PART_NUM ");
                    sbQuery.Append(" ,@PT_NAME ");
                    sbQuery.Append(" ,@PART_PRODTYPE ");
                    sbQuery.Append(" ,@PART_QLTY ");
                    sbQuery.Append(" ,@PART_SPEC ");
                    sbQuery.Append(" ,@PART_SPEC1 ");
                    sbQuery.Append(" ,@PART_QTY ");
                    sbQuery.Append(" ,@ORD_QTY ");
                    sbQuery.Append(" ,@O_PART_QTY ");
                    sbQuery.Append(" ,@WEIGHT_VOLUME ");
                    sbQuery.Append(" ,@WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,@UNIT_COST ");
                    sbQuery.Append(" ,@MAT_COST ");
                    sbQuery.Append(" ,@DRAW_EMP ");
                    sbQuery.Append(" ,@DRAW_NO ");
                    sbQuery.Append(" ,@O_PT_ID ");
                    sbQuery.Append(" ,@INS_FLAG ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@PUR_STAT ");
                    sbQuery.Append(" ,@OUT_REQ ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,0 ");
                    sbQuery.Append(" ,@MAT_CODE ");
                    sbQuery.Append(" ,@WO_PART ");
                    sbQuery.Append(" ,@IS_PLM_DEL ");
                    sbQuery.Append(" ,@PART_PUID ");
                    sbQuery.Append(" ,@PREV_PART_CODE ");
                    sbQuery.Append(" ,@PREV_PT_ID ");
                    sbQuery.Append(" ,@PREV_O_PT_ID ");

                    sbQuery.Append(" ,@Tab_Machine ");
                    sbQuery.Append(" ,@MakeSideHole ");
                    sbQuery.Append(" ,@Slit_Division ");
                    sbQuery.Append(" ,@Material ");
                    sbQuery.Append(" ,@Surface_Treat ");
                    sbQuery.Append(" ,@After_Treat ");
                    sbQuery.Append(" ,@MAKE_DESC ");
                    sbQuery.Append(" ,@IS_COPY_SIDE ");
                    sbQuery.Append(" ,@IS_SIDE ");
                    sbQuery.Append("  ) ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append("  PT_NO = @PT_NO ");
                    sbQuery.Append(" ,PROD_CODE = @PROD_CODE ");                                                                                
                    sbQuery.Append(" ,PART_QLTY = @PART_QLTY ");                    
                    sbQuery.Append(" ,PART_QTY = @PART_QTY ");
                    sbQuery.Append(" ,ORD_QTY = @ORD_QTY ");
                    sbQuery.Append(" ,O_PT_ID = @O_PT_ID ");
                    sbQuery.Append(" ,O_PART_QTY = @O_PART_QTY ");
                    sbQuery.Append(" ,INS_FLAG = @INS_FLAG ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,PREV_PART_CODE = @PREV_PART_CODE ");

                    sbQuery.Append(" ,Tab_Machine = @TAB_MACHINE ");
                    sbQuery.Append(" ,MakeSideHole = @MakeSideHole ");
                    sbQuery.Append(" ,Slit_Division = @Slit_Division ");
                    sbQuery.Append(" ,Material = @Material ");
                    sbQuery.Append(" ,Surface_Treat = @Surface_Treat ");
                    sbQuery.Append(" ,After_Treat = @AFTER_TREAT ");
                    sbQuery.Append(" ,MAKE_DESC = @MAKE_DESC ");

                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MAT_CODE = @MAT_CODE ");
                    sbQuery.Append(" ,WO_PART = @WO_PART ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 설비 그룹, 라우트 코드 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_PARTLIST_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" ROUT_CODE = @ROUT_CODE ");
                    sbQuery.Append(" ,MC_GROUP = @MC_GROUP ");                    
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");                    
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        public static void TMAT_PARTLIST_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST		 ");
                    sbQuery.Append(" SET MC_GROUP = @MC_GROUP      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        public static void TMAT_PARTLIST_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST		 ");
                    sbQuery.Append(" SET OUT_REQ = @OUT_REQ      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TMAT_PARTLIST_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST		 ");
                    sbQuery.Append(" SET SCOMMENT = @SCOMMENT      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST		 ");
                    sbQuery.Append(" SET OUT_DEL_FLAG = @OUT_DEL_FLAG      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST		 ");
                    sbQuery.Append(" SET WO_PART = @WO_PART      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE			");
                    sbQuery.Append(" AND PT_ID = @PT_ID			");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" PART_QTY = @PART_QTY ");
                    sbQuery.Append(" ,ORD_QTY = @ORD_QTY ");
                    sbQuery.Append(" ,O_PART_QTY = @O_PART_QTY ");
                    sbQuery.Append(" ,Tab_Machine = @TAB_MACHINE ");
                    sbQuery.Append(" ,MakeSideHole = @MakeSideHole ");
                    sbQuery.Append(" ,Slit_Division = @Slit_Division ");
                    sbQuery.Append(" ,Material = @Material ");
                    sbQuery.Append(" ,Surface_Treat = @Surface_Treat ");
                    sbQuery.Append(" ,After_Treat = @AFTER_TREAT ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TMAT_PARTLIST_UPD9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" Material = @Material ");
                    sbQuery.Append(" ,Surface_Treat = @Surface_Treat ");
                    sbQuery.Append(" ,After_Treat = @AFTER_TREAT ");
                    sbQuery.Append(" ,IS_REVISION = @IS_REVISION ");
                    sbQuery.Append(" ,IS_REMCT = @IS_REMCT ");
                    sbQuery.Append(" ,IS_MODIFY = @IS_MODIFY ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" ASSY_EMPS = @ASSY_EMPS ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    //sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" PIN_EMPS = @PIN_EMPS ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    //sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" IS_REVISION = '0' ");
                    sbQuery.Append(" ,IS_REMCT = '0' ");
                    sbQuery.Append(" ,IS_MODIFY = '0' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UPD13(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST SET  ");
                    sbQuery.Append(" IS_COPY_SIDE = @IS_COPY_SIDE ");
                    sbQuery.Append(" ,COPY_SIDE_DATE = @COPY_SIDE_DATE ");
                    sbQuery.Append(" ,COPY_SIDE_EMP = @COPY_SIDE_EMP ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TMAT_PARTLIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append(" ,DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PT_ID = @PT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static void TMAT_PARTLIST_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_PARTLIST ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append(" ,DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }

    public class TMAT_PARTLIST_QUERY
    {
      
        public static DataTable TMAT_PARTLIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PART_NUM");
                    sbQuery.Append(" ,PT_ID");
                    sbQuery.Append(" ,PT_NAME");
                    sbQuery.Append(" ,PART_PRODTYPE");
                    sbQuery.Append(" ,PART_QLTY");
                    sbQuery.Append(" ,PART_SPEC");
                    sbQuery.Append(" ,PART_QTY");
                    sbQuery.Append(" ,WEIGHT_VOLUME");
                    sbQuery.Append(" ,UNIT_COST");
                    sbQuery.Append(" ,MAT_COST");
                    sbQuery.Append(" ,DRAW_EMP");
                    sbQuery.Append(" ,DRAW_NO");
                    sbQuery.Append(" ,O_PT_ID");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,PART_SPEC1");
                    sbQuery.Append(" ,WEIGHT_VOLUME1");
                    sbQuery.Append(" ,INS_FLAG");
                    sbQuery.Append(" ,PT_NO");
                    sbQuery.Append("  FROM TMAT_PARTLIST");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@O_PT_ID", "O_PT_ID = @O_PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_NUM", "PART_NUM = @PART_NUM"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
        
        public static DataTable TMAT_PARTLIST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE");
                    sbQuery.Append(" ,PT.PUR_STAT");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE");
                    sbQuery.Append(" ,P.PIN_TYPE");
                    sbQuery.Append(" ,P.VISION_TYPE");
                    sbQuery.Append(" ,P.VISION_DIRECTION");
                    sbQuery.Append(" ,P.GND_PIN");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK");
                    sbQuery.Append(" ,P.CROSS_MARKING");
                    sbQuery.Append(" ,P.VACUUM");
                    sbQuery.Append(" ,P.SOCKET_MARKING");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION");
                    sbQuery.Append(" ,P.MSOP_DFM");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE");
                    sbQuery.Append(" ,P.DRAW_DATE");
                    sbQuery.Append(" ,P.DRAW_TYPE");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,PT.PART_NUM");
                    sbQuery.Append(" ,PT.PART_QLTY");
                    sbQuery.Append(" ,S.MAT_SPEC AS PART_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,PT.PART_SPEC1");
                    sbQuery.Append(" ,PT.PART_PRODTYPE");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) AS BOM_QTY");
                    sbQuery.Append(" ,ISNULL(PT.ORD_QTY,0) AS ORD_QTY");
                    //sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) * P.PROD_QTY AS QTY");
                    //sbQuery.Append(" ,ISNULL(W.PART_QTY,1) AS QTY");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) AS PART_QTY");
                    sbQuery.Append(" ,CASE WHEN ISNULL(PT.ORD_QTY,0) > 0 THEN PT.ORD_QTY ELSE P.PROD_QTY END AS OS_PROD_QTY");
                    sbQuery.Append(" ,PT.PART_QTY AS OS_PART_QTY");
                    sbQuery.Append(" ,ISNULL(PT.O_PART_QTY,1) AS OS_O_PART_QTY");
                    sbQuery.Append(" ,PT.PART_QTY * P.PROD_QTY * ISNULL(PT.O_PART_QTY,1) AS OS_QTY");
                    sbQuery.Append(" ,PT.SCOMMENT");
                    sbQuery.Append(" ,PT.UNIT_COST");
                    sbQuery.Append(" ,S.MAT_COST");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1");
                    sbQuery.Append(" ,PT.MAT_COST");
                    sbQuery.Append(" ,MAT_TYPE=NULL");
                    sbQuery.Append(" ,Q.MQLTY_CODE AS PART_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME");
                    sbQuery.Append(" ,OPT.PART_CODE AS P_PART_CODE");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM");
                    sbQuery.Append(" ,PT.INS_FLAG");
                    sbQuery.Append(" ,S.ACT_CODE");
                    sbQuery.Append(" ,S.MAT_UNIT");
                    sbQuery.Append(" ,Q.MQLTY_WEIGHT AS MQLTY_WEIGHT");
                    sbQuery.Append(" ,PT.PT_ID");
                    sbQuery.Append(" ,PT.O_PT_ID");
                    sbQuery.Append(" ,S.MAT_LTYPE");
                    sbQuery.Append(" ,S.MAT_MTYPE");
                    sbQuery.Append(" ,S.MAT_STYPE");
                    sbQuery.Append(" ,S.MAT_TYPE");
                    sbQuery.Append(" ,S.MAT_TYPE1");
                    sbQuery.Append(" ,S.MAT_TYPE2");
                    sbQuery.Append(" ,PT.REG_DATE");
                    sbQuery.Append(" ,PT.PT_NO");
                    sbQuery.Append(" ,PT.WO_PART");
                    sbQuery.Append(" ,PT.ROUT_CODE");
                    sbQuery.Append(" ,PT.MC_GROUP");
                    sbQuery.Append(" ,CASE WHEN (SELECT MAX(WO_NO) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID  AND DATA_FLAG = 0) IS NULL THEN '0' ELSE '1' END AS HAS_WO");
                    sbQuery.Append(" ,(SELECT MIN(MC_GROUP) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND MC_GROUP <> '' AND DATA_FLAG = 0) AS MC_GROUP");
                    sbQuery.Append(" ,(SELECT MAX(PLN_END_TIME) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND DATA_FLAG = 0) AS PLN_END_TIME");
                    sbQuery.Append(" ,PT.DATA_FLAG");
                    sbQuery.Append(" ,PT.O_PART_QTY");
                    //sbQuery.Append(" ,ISNULL(PT.Material, S.MAT_QLTY) AS MAT_QLTY");
                    //sbQuery.Append(" ,ISNULL(PT.SURFACE_TREAT, VP.SURFACE_TREAT) AS SURFACE_TREAT");
                    //sbQuery.Append(" ,ISNULL(PT.AFTER_TREAT, S.AFTER_TREAT) AS AFTER_TREAT");

                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");
                    sbQuery.Append(" ,PT.Material");
                    sbQuery.Append(" ,PT.Surface_Treat ");
                    sbQuery.Append(" ,PT.After_Treat ");
                    sbQuery.Append(" ,PT.MAKE_DESC ");
                    sbQuery.Append(" ,PT.IS_REVISION ");
                    sbQuery.Append(" ,PT.IS_REMCT ");
                    sbQuery.Append(" ,PT.IS_MODIFY ");
                    sbQuery.Append(" ,OW.IS_ORD ");
                    sbQuery.Append(" ,OW.OS_ORD_EMP ");
                    sbQuery.Append(" ,E.EMP_NAME AS OS_ORD_EMP_NAME ");
                    sbQuery.Append(" ,OW.OS_ORD_DATE ");
                    sbQuery.Append(" ,ISNULL(PT.IS_COPY_SIDE, 0) AS IS_COPY_SIDE ");
                    sbQuery.Append(" ,ISNULL(PT.IS_SIDE, 0) AS IS_SIDE ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = S.PLT_CODE");

                    //sbQuery.Append(" LEFT JOIN VIF_PLM_PART VP");
                    //sbQuery.Append(" ON PT.PART_CODE = VP.Part_Code ");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = P.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I");
                    sbQuery.Append(" ON P.ITEM_CODE = I.ITEM_CODE");
                    sbQuery.Append(" AND P.PLT_CODE = I.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE");
                    sbQuery.Append(" AND OPT.DATA_FLAG = 0");

                    sbQuery.Append(" LEFT JOIN ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PT_ID FROM TSHP_ACTUAL_MILL GROUP BY PLT_CODE, PT_ID");
                    sbQuery.Append(" ) AM");
                    sbQuery.Append(" ON PT.PLT_CODE = AM.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = AM.PT_ID");

                    sbQuery.Append(" LEFT JOIN ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PT_ID, IS_ORD, OS_ORD_EMP, OS_ORD_DATE FROM TSHP_WORKORDER WHERE IS_ORD = '1' AND DATA_FLAG = '0' GROUP BY PLT_CODE, PT_ID, IS_ORD, OS_ORD_EMP, OS_ORD_DATE");
                    sbQuery.Append(" ) OW");
                    sbQuery.Append(" ON PT.PLT_CODE = OW.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = OW.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON OW.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND OW.OS_ORD_EMP = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "PT.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "PT.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "S.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "S.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "S.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PT.PART_PRODTYPE = @PART_PRODTYPE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "SUBSTRING(PT.PART_CODE,1,1) = 'M' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "PT.WO_PART = '1' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "P.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PT.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_PART", "PT.WO_PART = @WO_PART"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP", "P.PROD_STATE NOT IN ('8','9','10','11','12','13')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_ORD_OS", "AM.PT_ID IS NULL"));

                        sbWhere.Append(UTIL.GetWhere(row, "@BUSINESS_EMP", "P.BUSINESS_EMP = @BUSINESS_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CVND_LIKE", "(P.CVND_CODE LIKE '%' + @CVND_LIKE + '%' OR V.VEN_NAME LIKE '%' + @CVND_LIKE + '%')"));
                        //sbWhere.Append(" ORDER BY PT.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY2_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE");
                    sbQuery.Append(" ,PT.PUR_STAT");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_CODE AS GROUP_PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE");
                    sbQuery.Append(" ,P.PIN_TYPE");
                    sbQuery.Append(" ,P.VISION_TYPE");
                    sbQuery.Append(" ,P.VISION_DIRECTION");
                    sbQuery.Append(" ,P.GND_PIN");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK");
                    sbQuery.Append(" ,P.CROSS_MARKING");
                    sbQuery.Append(" ,P.VACUUM");
                    sbQuery.Append(" ,P.SOCKET_MARKING");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION");
                    sbQuery.Append(" ,P.MSOP_DFM");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE");
                    sbQuery.Append(" ,P.DRAW_DATE");
                    sbQuery.Append(" ,P.DRAW_TYPE");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,PT.PART_NUM");
                    sbQuery.Append(" ,PT.PART_QLTY");
                    sbQuery.Append(" ,S.MAT_SPEC AS PART_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,PT.PART_SPEC1");
                    sbQuery.Append(" ,PT.PART_PRODTYPE");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) AS BOM_QTY");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) * P.PROD_QTY AS QTY");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) * P.PROD_QTY AS PART_QTY");
                    sbQuery.Append(" ,CASE WHEN NG.RE_WO_NO IS NOT NULL THEN NG.WK_NG_QTY ELSE ISNULL(PT.PART_QTY,1) * P.PROD_QTY * ISNULL(PT.O_PART_QTY, 1) END AS PRC_PART_QTY");
                    sbQuery.Append(" ,PT.SCOMMENT AS PART_SCOMMENT");
                    sbQuery.Append(" ,PT.UNIT_COST");
                    sbQuery.Append(" ,S.MAT_COST");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1");
                    sbQuery.Append(" ,PT.MAT_COST");
                    sbQuery.Append(" ,MAT_TYPE=NULL");
                    sbQuery.Append(" ,Q.MQLTY_CODE AS PART_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME");
                    sbQuery.Append(" ,OPT.PART_CODE AS P_PART_CODE");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM");
                    sbQuery.Append(" ,PT.INS_FLAG");
                    sbQuery.Append(" ,S.ACT_CODE");
                    sbQuery.Append(" ,S.MAT_UNIT");
                    sbQuery.Append(" ,Q.MQLTY_WEIGHT AS MQLTY_WEIGHT");
                    sbQuery.Append(" ,PT.PT_ID");
                    sbQuery.Append(" ,PT.O_PT_ID");
                    sbQuery.Append(" ,S.MAT_LTYPE");
                    sbQuery.Append(" ,S.MAT_MTYPE");
                    sbQuery.Append(" ,S.MAT_STYPE");
                    sbQuery.Append(" ,S.MAT_TYPE");
                    sbQuery.Append(" ,S.MAT_TYPE1");
                    sbQuery.Append(" ,S.MAT_TYPE2");
                    sbQuery.Append(" ,PT.REG_DATE");
                    sbQuery.Append(" ,PT.PT_NO");
                    sbQuery.Append(" ,PT.WO_PART");
                    sbQuery.Append(" ,PT.ROUT_CODE");
                    sbQuery.Append(" ,PT.MC_GROUP");
                    sbQuery.Append(" ,CASE WHEN (SELECT MAX(WO_NO) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID  AND DATA_FLAG = 0) IS NULL THEN '0' ELSE '1' END AS HAS_WO");
                    sbQuery.Append(" ,(SELECT MIN(MC_GROUP) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND MC_GROUP <> '' AND DATA_FLAG = 0) AS MC_GROUP");
                    sbQuery.Append(" ,(SELECT MAX(PLN_END_TIME) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND DATA_FLAG = 0) AS PLN_END_TIME");
                    sbQuery.Append(" ,PT.DATA_FLAG");
                    sbQuery.Append(" ,WPT.RE_WO_NO");
                    sbQuery.Append(" ,WPT.IS_DES_CHANGE");
                    sbQuery.Append(" ,WPT.IS_REMCT AS IS_DES_REMCT");
                    sbQuery.Append(" ,WPT.IS_MODIFY AS IS_DES_MODIFY");
                    sbQuery.Append(" ,CASE WHEN WPT.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 0 AND ISNULL(WPT.IS_MODIFY,0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 0 AND ISNULL(WPT.IS_MODIFY,0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 1 AND ISNULL(WPT.IS_MODIFY,0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN WPT.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");
                    sbQuery.Append(" ,WPT.DETAIL_CAUSE");
                    //sbQuery.Append("   ELSE CASE WHEN WPT.IS_DES_CHANGE = 1 AND WPT.IS_REMCT IS NULL AND WPT.IS_MODIFY IS NULL  THEN '2' ELSE '1' END END AS IS_REWORK");
                    //sbQuery.Append(" ,VP.MARTERIAL ");
                    //sbQuery.Append(" ,S.MAT_QLTY ");
                    //sbQuery.Append(" ,VP.SURFACE_TREAT ");
                    //sbQuery.Append(" ,S.AFTER_TREAT ");


                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");
                    sbQuery.Append(" ,PT.Material AS MATERIAL");
                    sbQuery.Append(" ,PT.IS_REVISION ");
                    sbQuery.Append(" ,PT.IS_REMCT ");
                    sbQuery.Append(" ,PT.IS_MODIFY ");
                    sbQuery.Append(" ,PT.Surface_Treat AS SURFACE_TREAT");
                    sbQuery.Append(" ,PT.After_Treat AS AFTER_TREAT");
                    sbQuery.Append(" ,PT.MAKE_DESC ");

                    sbQuery.Append(" ,'0' AS IS_OS");

                    sbQuery.Append(" ,INS.SCOMMENT AS INS_SCOMMENT ");
                    sbQuery.Append(" ,ASS.SCOMMENT AS ASSY_SCOMMENT ");

                    sbQuery.Append(" ,CASE WHEN ISNULL(PT.IS_COPY_SIDE, 0) = 1 THEN 'O' ELSE '' END AS IS_COPY_SIDE_DISP  ");
                    sbQuery.Append(" ,PT.COPY_SIDE_DATE ");
                    sbQuery.Append(" ,PT.COPY_SIDE_EMP ");
                    sbQuery.Append(" ,CE.EMP_NAME AS COPY_SIDE_EMP_NAME ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = S.PLT_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = P.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I");
                    sbQuery.Append(" ON P.ITEM_CODE = I.ITEM_CODE");
                    sbQuery.Append(" AND P.PLT_CODE = I.PLT_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE");
                    sbQuery.Append(" AND OPT.DATA_FLAG = 0");

                    //sbQuery.Append(" LEFT JOIN VIF_PLM_PART VP");
                    //sbQuery.Append(" ON PT.PART_CODE = VP.Part_Code ");

                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, PT_ID, IS_DES_CHANGE FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    //sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, IS_DES_CHANGE, PT_ID");
                    //sbQuery.Append(" ) WPT");
                    //sbQuery.Append(" ON PT.PLT_CODE = WPT.PLT_CODE");
                    //sbQuery.Append(" AND PT.PROD_CODE = WPT.PROD_CODE");
                    //sbQuery.Append(" AND PT.PART_CODE = WPT.PART_CODE");
                    //sbQuery.Append(" AND PT.PT_ID = WPT.PT_ID");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT W.PLT_CODE, W.PROD_CODE, W.PART_CODE, W.RE_WO_NO, W.PT_ID, W.IS_DES_CHANGE, W.IS_REMCT, W.IS_MODIFY, N.NG_TYPE, N.DETAIL_CAUSE FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");
                    sbQuery.Append(" WHERE W.DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY W.PLT_CODE, W.PROD_CODE, W.PART_CODE, W.RE_WO_NO, W.IS_DES_CHANGE, W.IS_REMCT, W.IS_MODIFY, W.PT_ID, N.NG_TYPE, N.DETAIL_CAUSE");
                    sbQuery.Append(" ) WPT");
                    sbQuery.Append(" ON PT.PLT_CODE = WPT.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = WPT.PROD_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = WPT.PART_CODE");
                    sbQuery.Append(" AND PT.PT_ID = WPT.PT_ID");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT N.PLT_CODE, W.PROD_CODE, W.PART_CODE, N.IS_NG_REWORK, N.RE_WO_NO, N.WK_NG_QTY FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = W.WO_NO");
                    sbQuery.Append(" ) NG");
                    sbQuery.Append(" ON NG.PLT_CODE = WPT.PLT_CODE");
                    sbQuery.Append(" AND NG.PROD_CODE = WPT.PROD_CODE");
                    sbQuery.Append(" AND NG.PART_CODE = WPT.PART_CODE");
                    sbQuery.Append(" AND NG.RE_WO_NO = WPT.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE FROM TSHP_WORKORDER WHERE PROC_CODE = 'P-09' AND DATA_FLAG = '0' AND WO_FLAG = '4' GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) ASSY");
                    sbQuery.Append(" ON PT.PLT_CODE = ASSY.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = ASSY.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TPOP_INS_SCOMMENT INS");
                    sbQuery.Append(" ON PT.PLT_CODE = INS.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = INS.PROD_CODE");
                    sbQuery.Append(" AND PT.PT_ID = INS.PT_ID");

                    sbQuery.Append(" LEFT JOIN TPOP_ASSY_SCOMMENT ASS");
                    sbQuery.Append(" ON PT.PLT_CODE = ASS.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = ASS.PROD_CODE");
                    sbQuery.Append(" AND PT.PT_ID = ASS.PT_ID");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CE");
                    sbQuery.Append(" ON PT.PLT_CODE = CE.PLT_CODE");
                    sbQuery.Append(" AND PT.COPY_SIDE_EMP = CE.EMP_CODE");

                    //sbQuery.Append(" LEFT JOIN (");
                    //sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PT_ID, RE_WO_NO FROM TSHP_WORKORDER WHERE PROC_CODE = 'P14' AND DATA_FLAG = '0' GROUP BY PLT_CODE, PROD_CODE, PT_ID, RE_WO_NO");
                    //sbQuery.Append(" ) OW");
                    //sbQuery.Append(" ON PT.PLT_CODE = OW.PLT_CODE");
                    //sbQuery.Append(" AND PT.PROD_CODE = OW.PROD_CODE");
                    //sbQuery.Append(" AND PT.PT_ID = OW.PT_ID");
                    //sbQuery.Append(" AND ISNULL(WPT.RE_WO_NO,'9999') = ISNULL(OW.RE_WO_NO,'9999)");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "PT.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "PT.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "S.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "S.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "S.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PT.PART_PRODTYPE = @PART_PRODTYPE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "SUBSTRING(PT.PART_CODE,1,1) = 'M' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "PT.WO_PART = '1' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PT.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NON_ASSY", "ASSY.PROD_CODE IS NULL"));

                        sbWhere.Append(" AND P.DATA_FLAG = '0'");

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP", "P.PROD_STATE NOT IN ('8','9')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP_FINISH", "P.PROD_STATE NOT IN ('9', '5')"));
                        sbWhere.Append(" ORDER BY REG_DATE");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY2_3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE");
                    sbQuery.Append(" ,PT.PUR_STAT");
                    sbQuery.Append(" ,I.ITEM_CODE");
                    sbQuery.Append(" ,I.ITEM_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_CODE AS GROUP_PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.MODEL_TYPE");
                    sbQuery.Append(" ,P.MODEL_CODE");
                    sbQuery.Append(" ,P.PROD_VERSION");
                    sbQuery.Append(" ,P.PROC_FLAG");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.INS_YN");
                    sbQuery.Append(" ,P.SOCKET_YN");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.PROD_CATEGORY");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,P.CUSTOMER_EMP");
                    sbQuery.Append(" ,P.CUSTDESIGN_EMP");
                    sbQuery.Append(" ,P.ACTUATOR_YN");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,P.TVND_CODE");
                    sbQuery.Append(" ,P.PROBE_PIN");
                    sbQuery.Append(" ,P.CURR_UNIT");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.INDUE_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" ,P.CHG_DUE_DATE");
                    sbQuery.Append(" ,P.END_DATE");
                    sbQuery.Append(" ,P.DELIVERY_DATE");
                    sbQuery.Append(" ,P.PROD_QTY");
                    sbQuery.Append(" ,P.LOAD_FLAG");
                    sbQuery.Append(" ,P.LOCK_FLAG");
                    sbQuery.Append(" ,P.LOCK_EMP");
                    sbQuery.Append(" ,P.SHIP_FLAG");
                    sbQuery.Append(" ,P.PROD_STATE");
                    sbQuery.Append(" ,P.INOUT_FLAG");
                    sbQuery.Append(" ,P.ORD_VAT");
                    sbQuery.Append(" ,P.PROD_UC");
                    sbQuery.Append(" ,P.PROD_COST");
                    sbQuery.Append(" ,P.PROD_VAT");
                    sbQuery.Append(" ,P.PROD_AMT");
                    sbQuery.Append(" ,P.PROD_KIND");
                    sbQuery.Append(" ,P.PROD_TYPE1");
                    sbQuery.Append(" ,P.PROD_TYPE2");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.TRADE_YN");
                    sbQuery.Append(" ,P.TAX_YN");
                    sbQuery.Append(" ,P.BILL_YN");
                    sbQuery.Append(" ,P.SCOMMENT");
                    sbQuery.Append(" ,P.REMARK");
                    sbQuery.Append(" ,P.MODULE_TYPE");
                    sbQuery.Append(" ,P.PIN_TYPE");
                    sbQuery.Append(" ,P.VISION_TYPE");
                    sbQuery.Append(" ,P.VISION_DIRECTION");
                    sbQuery.Append(" ,P.GND_PIN");
                    sbQuery.Append(" ,P.FIDUCIAL_MARK");
                    sbQuery.Append(" ,P.CROSS_MARKING");
                    sbQuery.Append(" ,P.VACUUM");
                    sbQuery.Append(" ,P.SOCKET_MARKING");
                    sbQuery.Append(" ,P.MODULE_IN_TYPE");
                    sbQuery.Append(" ,P.IF_PIN_BLOCK");
                    sbQuery.Append(" ,P.SOCKET_OPEN_DIRECTION");
                    sbQuery.Append(" ,P.MSOP_DFM");
                    sbQuery.Append(" ,P.MSOP_DFM_DATE");
                    sbQuery.Append(" ,P.DRAW_DATE");
                    sbQuery.Append(" ,P.DRAW_TYPE");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,S.PART_NAME");
                    sbQuery.Append(" ,S.DRAW_NO");
                    sbQuery.Append(" ,PT.PART_NUM");
                    sbQuery.Append(" ,PT.PART_QLTY");
                    sbQuery.Append(" ,S.MAT_SPEC AS PART_SPEC");
                    sbQuery.Append(" ,S.MAT_SPEC");
                    sbQuery.Append(" ,PT.PART_SPEC1");
                    sbQuery.Append(" ,PT.PART_PRODTYPE");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) AS BOM_QTY");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) * P.PROD_QTY AS QTY");
                    sbQuery.Append(" ,ISNULL(PT.PART_QTY,1) * P.PROD_QTY AS PART_QTY");
                    sbQuery.Append(" ,CASE WHEN NG.RE_WO_NO IS NOT NULL THEN NG.WK_NG_QTY ELSE ISNULL(PT.PART_QTY,1) * P.PROD_QTY * ISNULL(PT.O_PART_QTY, 1) END AS PRC_PART_QTY");
                    sbQuery.Append(" ,PT.SCOMMENT AS PART_SCOMMENT");
                    sbQuery.Append(" ,PT.UNIT_COST");
                    sbQuery.Append(" ,S.MAT_COST");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1");
                    sbQuery.Append(" ,PT.MAT_COST");
                    sbQuery.Append(" ,MAT_TYPE=NULL");
                    sbQuery.Append(" ,Q.MQLTY_CODE AS PART_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME");
                    sbQuery.Append(" ,OPT.PART_CODE AS P_PART_CODE");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM");
                    sbQuery.Append(" ,PT.INS_FLAG");
                    sbQuery.Append(" ,S.ACT_CODE");
                    sbQuery.Append(" ,S.MAT_UNIT");
                    sbQuery.Append(" ,Q.MQLTY_WEIGHT AS MQLTY_WEIGHT");
                    sbQuery.Append(" ,PT.PT_ID");
                    sbQuery.Append(" ,PT.O_PT_ID");
                    sbQuery.Append(" ,S.MAT_LTYPE");
                    sbQuery.Append(" ,S.MAT_MTYPE");
                    sbQuery.Append(" ,S.MAT_STYPE");
                    sbQuery.Append(" ,S.MAT_TYPE");
                    sbQuery.Append(" ,S.MAT_TYPE1");
                    sbQuery.Append(" ,S.MAT_TYPE2");
                    sbQuery.Append(" ,PT.REG_DATE");
                    sbQuery.Append(" ,PT.PT_NO");
                    sbQuery.Append(" ,PT.WO_PART");
                    sbQuery.Append(" ,PT.ROUT_CODE");
                    sbQuery.Append(" ,PT.MC_GROUP");
                    sbQuery.Append(" ,CASE WHEN (SELECT MAX(WO_NO) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID  AND DATA_FLAG = 0) IS NULL THEN '0' ELSE '1' END AS HAS_WO");
                    sbQuery.Append(" ,(SELECT MIN(MC_GROUP) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND MC_GROUP <> '' AND DATA_FLAG = 0) AS MC_GROUP");
                    sbQuery.Append(" ,(SELECT MAX(PLN_END_TIME) FROM TSHP_WORKORDER WHERE PLT_CODE = PT.PLT_CODE AND PT_ID = PT.PT_ID AND DATA_FLAG = 0) AS PLN_END_TIME");
                    sbQuery.Append(" ,PT.DATA_FLAG");
                    sbQuery.Append(" ,WPT.RE_WO_NO");
                    sbQuery.Append(" ,WPT.IS_DES_CHANGE");
                    sbQuery.Append(" ,WPT.IS_REMCT AS IS_DES_REMCT");
                    sbQuery.Append(" ,WPT.IS_MODIFY AS IS_DES_MODIFY");
                    sbQuery.Append(" ,CASE WHEN WPT.RE_WO_NO IS NULL THEN '0'");
                    sbQuery.Append("   ELSE CASE WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 0 AND ISNULL(WPT.IS_MODIFY,0) = 0 THEN '2' ");
                    sbQuery.Append("             WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 0 AND ISNULL(WPT.IS_MODIFY,0) = 1 THEN '3'");
                    sbQuery.Append("             WHEN WPT.IS_DES_CHANGE = 1 AND ISNULL(WPT.IS_REMCT,0) = 1 AND ISNULL(WPT.IS_MODIFY,0) = 0 THEN '4'");
                    sbQuery.Append("             WHEN WPT.NG_TYPE = 'P' THEN '5' ELSE '6' END END AS IS_REWORK");
                    sbQuery.Append(" ,CONVERT(VARCHAR(8), WPT.REG_DATE, 112) AS NG_REG_DATE ");
                    sbQuery.Append(" ,WPT.PART_QTY AS PRC_PART_QTY ");
                    //sbQuery.Append("   ELSE CASE WHEN WPT.IS_DES_CHANGE = 1 AND WPT.IS_REMCT IS NULL AND WPT.IS_MODIFY IS NULL  THEN '2' ELSE '1' END END AS IS_REWORK");
                    //sbQuery.Append(" ,VP.MARTERIAL ");
                    //sbQuery.Append(" ,S.MAT_QLTY ");
                    //sbQuery.Append(" ,VP.SURFACE_TREAT ");
                    //sbQuery.Append(" ,S.AFTER_TREAT ");


                    sbQuery.Append(" ,PT.Material AS MAT_QLTY");
                    sbQuery.Append(" ,PT.Material AS MATERIAL");
                    sbQuery.Append(" ,PT.IS_REVISION ");
                    sbQuery.Append(" ,PT.IS_REMCT ");
                    sbQuery.Append(" ,PT.IS_MODIFY ");
                    sbQuery.Append(" ,PT.Surface_Treat AS SURFACE_TREAT");
                    sbQuery.Append(" ,PT.After_Treat AS AFTER_TREAT");
                    sbQuery.Append(" ,PT.MAKE_DESC ");

                    sbQuery.Append(" ,DPT.DRAW_EMP ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PART_CODE = S.PART_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = S.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" AND PT.PLT_CODE = P.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_ITEM I");
                    sbQuery.Append(" ON P.ITEM_CODE = I.ITEM_CODE");
                    sbQuery.Append(" AND P.PLT_CODE = I.PLT_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE");
                    sbQuery.Append(" AND OPT.DATA_FLAG = 0");

                    //sbQuery.Append(" LEFT JOIN VIF_PLM_PART VP");
                    //sbQuery.Append(" ON PT.PART_CODE = VP.Part_Code ");

                    //sbQuery.Append(" LEFT JOIN");
                    //sbQuery.Append(" (");
                    //sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, PT_ID, IS_DES_CHANGE FROM TSHP_WORKORDER");
                    //sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    //sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PART_CODE, RE_WO_NO, IS_DES_CHANGE, PT_ID");
                    //sbQuery.Append(" ) WPT");
                    //sbQuery.Append(" ON PT.PLT_CODE = WPT.PLT_CODE");
                    //sbQuery.Append(" AND PT.PROD_CODE = WPT.PROD_CODE");
                    //sbQuery.Append(" AND PT.PART_CODE = WPT.PART_CODE");
                    //sbQuery.Append(" AND PT.PT_ID = WPT.PT_ID");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT W.PLT_CODE, W.PROD_CODE, W.PART_CODE, W.RE_WO_NO, W.PT_ID, W.IS_DES_CHANGE, W.IS_REMCT, W.IS_MODIFY, N.NG_TYPE, MAX(W.REG_DATE) AS REG_DATE, MAX(W.PART_QTY) AS PART_QTY FROM TSHP_WORKORDER W");
                    sbQuery.Append(" LEFT JOIN TSHP_NG N");
                    sbQuery.Append(" ON W.PLT_CODE = N.PLT_CODE");
                    sbQuery.Append(" AND W.RE_WO_NO = N.RE_WO_NO");
                    sbQuery.Append(" WHERE W.DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY W.PLT_CODE, W.PROD_CODE, W.PART_CODE, W.RE_WO_NO, W.IS_DES_CHANGE, W.IS_REMCT, W.IS_MODIFY, W.PT_ID, N.NG_TYPE");
                    sbQuery.Append(" ) WPT");
                    sbQuery.Append(" ON PT.PLT_CODE = WPT.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = WPT.PROD_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = WPT.PART_CODE");
                    sbQuery.Append(" AND PT.PT_ID = WPT.PT_ID");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT N.PLT_CODE, W.PROD_CODE, W.PART_CODE, N.IS_NG_REWORK, N.RE_WO_NO, N.WK_NG_QTY FROM TSHP_NG N");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON N.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND N.LINK_KEY = W.WO_NO");
                    sbQuery.Append(" ) NG");
                    sbQuery.Append(" ON NG.PLT_CODE = WPT.PLT_CODE");
                    sbQuery.Append(" AND NG.PROD_CODE = WPT.PROD_CODE");
                    sbQuery.Append(" AND NG.PART_CODE = WPT.PART_CODE");
                    sbQuery.Append(" AND NG.RE_WO_NO = WPT.RE_WO_NO");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PROD_CODE, DRAW_EMP FROM TMAT_PARTLIST WHERE LEFT(PART_CODE, 1) = 'A' AND ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' GROUP BY PLT_CODE, PROD_CODE, DRAW_EMP) DPT");
                    sbQuery.Append(" ON PT.PLT_CODE = DPT.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = DPT.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT A.PLT_CODE, A.LINK_KEY, B.PROD_CODE, B.PT_ID FROM TSHP_NG A");
                    sbQuery.Append(" JOIN TSHP_WORKORDER B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.LINK_KEY = B.WO_NO");
                    sbQuery.Append(" ) NG_CHK");
                    sbQuery.Append(" ON PT.PLT_CODE = NG_CHK.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = NG_CHK.PROD_CODE");
                    sbQuery.Append(" AND PT.PT_ID = NG_CHK.PT_ID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "PT.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "PT.REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "S.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "S.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "S.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "PT.PART_PRODTYPE = @PART_PRODTYPE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "SUBSTRING(PT.PART_CODE,1,1) = 'M' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_WO_PART", "PT.WO_PART = '1' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "ISNULL(P.CHG_DUE_DATE, P.DUE_DATE) BETWEEN @S_DUE_DATE AND @E_DUE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(PT.PART_CODE LIKE '%' + @PART_LIKE + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PT.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND P.DATA_FLAG = '0' AND NG_CHK.LINK_KEY IS NULL");
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_DES_CHANGE", "WPT.IS_DES_CHANGE = '1'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_NG_DATE, @E_NG_DATE", "CONVERT(VARCHAR(8), WPT.REG_DATE, 112) BETWEEN @S_NG_DATE AND @E_NG_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP", "P.PROD_STATE NOT IN ('8','9')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_NOT_SHIP_FINISH", "P.PROD_STATE NOT IN ('9', '5')"));
                        sbWhere.Append(" ORDER BY REG_DATE");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY2_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PT.PLT_CODE");
                    sbQuery.Append(" ,PT.PROD_CODE");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,PT.PT_ID");
                    sbQuery.Append(" ,PT.PART_QTY");
                    sbQuery.Append(" ,SP.MAT_QLTY");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,R.OUT_REQ_QTY");
                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ R");
                    sbQuery.Append(" ON PT.PLT_CODE = R.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = R.PT_ID");
                    sbQuery.Append(" AND R.DATA_FLAG = '0'");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(" AND P.PROD_KIND = 'IE' AND P.DATA_FLAG = '0' AND PT.DATA_FLAG = '0' AND R.OUT_REQ_QTY IS NOT NULL");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PT.PLT_CODE, ");
                    sbQuery.Append(" PT.PUR_STAT, ");
                    //sbQuery.Append(" P.PRJ_CODE,");
                    //sbQuery.Append(" PJ.PRJ_NAME,");
                    sbQuery.Append(" I.ITEM_CODE, ");
                    sbQuery.Append(" I.ITEM_NAME, ");
                    sbQuery.Append(" P.PROD_CODE, ");
                    sbQuery.Append(" P.PROD_NAME, ");
                    sbQuery.Append(" P.CVND_CODE, ");
                    sbQuery.Append(" P.DUE_DATE, "); 
                    sbQuery.Append(" P.PROD_FLAG, "); 
                    sbQuery.Append(" P.PROD_CATEGORY, ");
                    //sbQuery.Append(" P.PROD_QTY, ");
                    //sbQuery.Append(" S.IS_OS, ");
                    sbQuery.Append(" PT.PART_CODE, ");
                    sbQuery.Append(" S.PART_NAME, ");
                    sbQuery.Append(" S.DRAW_NO, ");
                    sbQuery.Append(" PT.PART_NUM, ");
                    sbQuery.Append(" PT.PART_QLTY, ");
                    sbQuery.Append(" S.MAT_SPEC, ");
                    sbQuery.Append(" S.MAT_LTYPE, ");
                    sbQuery.Append(" S.MAT_MTYPE, ");
                    sbQuery.Append(" S.MAT_STYPE, ");
                    sbQuery.Append(" PT.PART_SPEC1, ");
                    sbQuery.Append(" S.PART_PRODTYPE, ");
                    //sbQuery.Append(" CASE WHEN P.PROD_KIND = 'PD' THEN PT.PART_QTY * P.PROD_QTY ELSE PT.PART_QTY END AS QTY, ");
                    sbQuery.Append(" CASE WHEN P.PROD_KIND = 'PD' THEN PT.PART_QTY * PT.O_PART_QTY * (CASE WHEN ISNULL(PT.ORD_QTY, 0) > 0 THEN PT.ORD_QTY ELSE P.PROD_QTY END) ELSE PT.PART_QTY END AS QTY, ");
                    sbQuery.Append(" PT.PART_QTY , ");

                    sbQuery.Append(" 	 CASE WHEN ISNULL(PT.ORD_QTY, 0) > 0 THEN PT.ORD_QTY ELSE P.PROD_QTY END AS PROD_QTY,  ");
                    sbQuery.Append(" 	 PT.O_PART_QTY,          ");

                    sbQuery.Append(" PT.SCOMMENT, ");
                    sbQuery.Append(" PT.UNIT_COST, ");
                    sbQuery.Append(" S.MAT_COST, ");
                    sbQuery.Append(" PT.WEIGHT_VOLUME, ");
                    sbQuery.Append(" PT.WEIGHT_VOLUME1, ");
                    sbQuery.Append(" PT.MAT_COST, ");
                    sbQuery.Append(" MAT_TYPE=NULL, ");
                    sbQuery.Append(" Q.MQLTY_CODE AS PART_QLTY , ");
                    sbQuery.Append(" Q.MQLTY_NAME AS PART_QLTY_NAME, ");
                    sbQuery.Append(" A.PART_CODE AS P_PART_CODE, 	 ");
                    sbQuery.Append(" A.PT_NAME AS P_PART_NAME, ");
                    sbQuery.Append(" A.PART_NUM AS P_PART_NUM, ");
                    sbQuery.Append(" PT.INS_FLAG, ");
                    sbQuery.Append(" S.ACT_CODE, ");
                    sbQuery.Append(" S.MAT_UNIT, ");
                    sbQuery.Append(" Q.MQLTY_WEIGHT AS MQLTY_WEIGHT ,");
                    sbQuery.Append(" PT.PT_ID, ");
                    sbQuery.Append(" PT.PT_NO,");
                    sbQuery.Append(" ISNULL(STOCK.STOCK_QTY,0) AS STOCK_QTY, ");
                    sbQuery.Append(" S.SAFE_STK_QTY, ");
                    sbQuery.Append(" REQ.OUT_REQ_QTY ");


                    sbQuery.Append(" 	, AW.WO_FLAG          ");
                    sbQuery.Append(" 	, S.SUPP_VND          ");
                    sbQuery.Append(" 	, V.VEN_NAME AS SUPP_VND_NAME          ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ");
                    sbQuery.Append(" ON PT.PART_CODE = S.PART_CODE	 ");
                    sbQuery.Append(" AND PT.PLT_CODE = S.PLT_CODE	 ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON PT.PROD_CODE = P.PROD_CODE	 ");
                    sbQuery.Append(" AND PT.PLT_CODE = P.PLT_CODE	 ");
                    
                    //sbQuery.Append(" LEFT JOIN TORD_PROJECT PJ		 ");
                    //sbQuery.Append(" ON P.PLT_CODE = PJ.PLT_CODE	 ");
                    //sbQuery.Append(" AND P.PRJ_CODE = PJ.PRJ_CODE	 ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I 			 ");
                    sbQuery.Append(" ON P.ITEM_CODE = I.ITEM_CODE	 ");
                    sbQuery.Append(" AND P.PLT_CODE = I.PLT_CODE	 ");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q	 ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE 	 ");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE ");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST A 		 ");
                    sbQuery.Append(" ON PT.O_PT_ID = A.PT_ID		 ");
                    sbQuery.Append(" AND PT.PLT_CODE = A.PLT_CODE	 ");
                    //sbQuery.Append(" LEFT JOIN (SELECT STK.PLT_CODE, STK.PART_CODE, COUNT(*) AS STOCK_QTY, SUM(ISNULL(STKD.UNIT_COST,0)) AS TOT_AMT  ");
                    //sbQuery.Append("            FROM TMAT_STOCK STK ");
                    //sbQuery.Append("                INNER JOIN TMAT_STOCK_LOT STKD  ");
                    //sbQuery.Append("                    ON STK.PLT_CODE = STKD.PLT_CODE AND STK.STK_ID = STKD.STK_ID 		 ");
                    //sbQuery.Append("            WHERE STKD.STOCK_FLAG IN ('NE','YP') 		 ");
                    //sbQuery.Append("            GROUP BY STK.PLT_CODE, STK.PART_CODE ) STOCK 		 ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS STOCK_QTY FROM TMAT_STOCK  ");
                    sbQuery.Append("            GROUP BY PLT_CODE, PART_CODE) STOCK 		 ");
                    sbQuery.Append(" ON PT.PART_CODE = STOCK.PART_CODE		 ");
                    sbQuery.Append(" AND PT.PLT_CODE = STOCK.PLT_CODE	 ");

                    sbQuery.Append("  LEFT JOIN (SELECT PLT_CODE, PT_ID, SUM(OUT_REQ_QTY) AS OUT_REQ_QTY FROM TMAT_OUT_REQ WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, PT_ID) REQ  		 ");
                    sbQuery.Append("    ON PT.PT_ID = REQ.PT_ID		 ");
                    sbQuery.Append("    AND PT.PLT_CODE = REQ.PLT_CODE	 ");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PROC_CODE, MAX(WO_FLAG) AS WO_FLAG FROM TSHP_WORKORDER WITH(NOLOCK)");
                    sbQuery.Append(" WHERE PROC_CODE = 'P-09' AND DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PROC_CODE");
                    sbQuery.Append(" ) AW");
                    sbQuery.Append(" ON P.PLT_CODE = AW.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = AW.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V 			 ");
                    sbQuery.Append(" ON S.PLT_CODE = V.PLT_CODE	 ");
                    sbQuery.Append(" AND S.SUPP_VND = V.VEN_CODE	 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "S.PART_CODE LIKE '%' + @PART_LIKE  + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "S.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR S.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "S.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "S.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "S.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "S.MAT_STYPE = @MAT_STYPE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ", "ISNULL(PT.OUT_REQ,0) = @OUT_REQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_QTY_ZERO", "STOCK.STOCK_QTY > 0 "));

                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_DEL_FLAG", "ISNULL(PT.OUT_DEL_FLAG, 0) = @OUT_DEL_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN", "ISNULL(S.IS_MAIN_PART, '0') = '1'  "));

                        //sbWhere.Append(" AND ISNULL(REQ.OUT_REQ_QTY,0) < PT.PART_QTY ");
                        sbWhere.Append(" AND PT.DATA_FLAG = '0' ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PT.PLT_CODE, ");
                    sbQuery.Append(" PT.PUR_STAT, ");
                    //sbQuery.Append(" P.PRJ_CODE,");
                    //sbQuery.Append(" PJ.PRJ_NAME,");
                    sbQuery.Append(" I.ITEM_CODE, ");
                    sbQuery.Append(" I.ITEM_NAME, ");
                    sbQuery.Append(" P.PROD_CODE, ");
                    sbQuery.Append(" P.PROD_NAME, ");
                    sbQuery.Append(" P.CVND_CODE, ");
                    sbQuery.Append(" P.DUE_DATE, ");
                    sbQuery.Append(" P.PROD_FLAG, ");
                    sbQuery.Append(" P.PROD_CATEGORY, ");
                    sbQuery.Append(" P.PROD_QTY, ");
                    sbQuery.Append(" PT.PART_CODE, ");
                    sbQuery.Append(" S.PART_NAME, ");
                    sbQuery.Append(" S.MAT_LTYPE, ");
                    sbQuery.Append(" S.MAT_MTYPE, ");
                    sbQuery.Append(" S.MAT_STYPE, ");
                    sbQuery.Append(" S.DRAW_NO, ");
                    sbQuery.Append(" PT.PART_NUM, ");
                    sbQuery.Append(" PT.PART_QLTY, ");
                    sbQuery.Append(" S.MAT_SPEC AS PART_SPEC, ");
                    sbQuery.Append(" PT.PART_SPEC1, ");
                    sbQuery.Append(" S.PART_PRODTYPE, ");
                    sbQuery.Append(" PT.PART_QTY AS QTY, ");
                    sbQuery.Append(" PT.PART_QTY , ");
                    sbQuery.Append(" PT.SCOMMENT, ");
                    sbQuery.Append(" PT.UNIT_COST, ");
                    sbQuery.Append(" S.MAT_COST, ");
                    sbQuery.Append(" PT.WEIGHT_VOLUME, ");
                    sbQuery.Append(" PT.WEIGHT_VOLUME1, ");
                    sbQuery.Append(" PT.MAT_COST, ");
                    sbQuery.Append(" MAT_TYPE=NULL, ");
                    sbQuery.Append(" A.PART_CODE AS P_PART_CODE, 	 ");
                    sbQuery.Append(" A.PT_NAME AS P_PART_NAME, ");
                    sbQuery.Append(" A.PART_NUM AS P_PART_NUM, ");
                    sbQuery.Append(" PT.INS_FLAG, ");
                    sbQuery.Append(" S.ACT_CODE, ");
                    sbQuery.Append(" S.MAT_UNIT, ");
                    sbQuery.Append(" PT.PT_ID, ");
                    sbQuery.Append(" PT.PT_NO,");
                    sbQuery.Append(" ISNULL(STOCK.STOCK_QTY,0) AS STOCK_QTY, ");
                    sbQuery.Append(" S.SAFE_STK_QTY, ");
                    sbQuery.Append(" REQ.OUT_REQ_QTY, ");
                    sbQuery.Append(" OUT.OUT_QTY, ");
                    sbQuery.Append(" ISNULL((SELECT SUM(RET_REQ_QTY) FROM TMAT_RET_REQ WHERE PT_ID = PT.PT_ID AND DATA_FLAG = '0' AND RET_REQ_STAT = '22'),0) AS RET_REQ_QTY ");  //상태:22 완료

                    sbQuery.Append(" ,OUT.OUT_ID ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S ");
                    sbQuery.Append(" ON PT.PART_CODE = S.PART_CODE	 ");
                    sbQuery.Append(" AND PT.PLT_CODE = S.PLT_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON PT.PROD_CODE = P.PROD_CODE	 ");
                    sbQuery.Append(" AND PT.PLT_CODE = P.PLT_CODE	 ");
                    //sbQuery.Append(" LEFT JOIN TORD_PROJECT PJ		 ");
                    //sbQuery.Append(" ON P.PLT_CODE = PJ.PLT_CODE	 ");
                    //sbQuery.Append(" AND P.PRJ_CODE = PJ.PRJ_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I 			 ");
                    sbQuery.Append(" ON P.ITEM_CODE = I.ITEM_CODE	 ");
                    sbQuery.Append(" AND P.PLT_CODE = I.PLT_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST A 		 ");
                    sbQuery.Append(" ON PT.O_PT_ID = A.PT_ID		 ");
                    sbQuery.Append(" AND PT.PLT_CODE = A.PLT_CODE	 ");
                    //sbQuery.Append(" LEFT JOIN (SELECT STK.PLT_CODE, STK.PART_CODE, COUNT(*) AS STOCK_QTY, SUM(ISNULL(STKD.UNIT_COST,0)) AS TOT_AMT  ");
                    //sbQuery.Append("            FROM TMAT_STOCK STK ");
                    //sbQuery.Append("                INNER JOIN TMAT_STOCK_LOT STKD  ");
                    //sbQuery.Append("                    ON STK.PLT_CODE = STKD.PLT_CODE AND STK.STK_ID = STKD.STK_ID 		 ");
                    //sbQuery.Append("            WHERE STKD.STOCK_FLAG IN ('NE','YP') 		 ");
                    //sbQuery.Append("            GROUP BY STK.PLT_CODE, STK.PART_CODE ) STOCK 		 ");
                    //sbQuery.Append(" ON PT.PART_CODE = STOCK.PART_CODE		 ");
                    //sbQuery.Append(" AND PT.PLT_CODE = STOCK.PLT_CODE	 ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PART_CODE, SUM(PART_QTY) AS STOCK_QTY FROM TMAT_STOCK  ");
                    sbQuery.Append("            GROUP BY PLT_CODE, PART_CODE) STOCK 		 ");
                    sbQuery.Append(" ON PT.PART_CODE = STOCK.PART_CODE		 ");
                    sbQuery.Append(" AND PT.PLT_CODE = STOCK.PLT_CODE	 ");
                    sbQuery.Append(" INNER JOIN TMAT_OUT_REQ REQ ");
                    sbQuery.Append(" 	ON PT.PT_ID = REQ.PT_ID ");
                    sbQuery.Append(" 	AND PT.PLT_CODE = REQ.PLT_CODE ");
                    sbQuery.Append(" INNER JOIN TMAT_OUT OUT ");    //불출된 내역이 존재하는것
                    sbQuery.Append(" 	ON REQ.OUT_REQ_ID = OUT.OUT_REQ_ID ");
                    sbQuery.Append(" 	AND REQ.PLT_CODE = OUT.PLT_CODE ");
                    sbQuery.Append(" 	AND OUT.DATA_FLAG = '0' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "P.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR P.PROD_NAME LIKE '%' + @PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "S.PART_CODE LIKE '%' + @PART_LIKE  + '%' OR S.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "S.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' OR S.MAT_SPEC1 LIKE '%' + @SPEC_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_TYPE", "S.MAT_TYPE = @MAT_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ", "ISNULL(PT.OUT_REQ,0) = @OUT_REQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_QTY_ZERO", "STOCK.STOCK_QTY > 0 "));

                        //sbWhere.Append(" AND PT.DATA_FLAG = '0' ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }






        /// <summary>
        /// BOM 복사
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TMAT_PARTLIST_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE   ");
                    sbQuery.Append(" ,PT.PT_ID ");
                    sbQuery.Append(" ,PT.PT_NO ");
                    sbQuery.Append(" ,PT.PROD_CODE ");
                    sbQuery.Append(" ,PT.PART_CODE ");
                    sbQuery.Append(" ,S.PART_NAME ");
                    sbQuery.Append(" ,S.MAT_LTYPE ");
                    sbQuery.Append(" ,S.MAT_SPEC ");
                    sbQuery.Append(" ,PT.PART_NUM ");
                    sbQuery.Append(" ,PT.PT_NAME ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.PART_QLTY ");
                    sbQuery.Append(" ,PT.PART_SPEC ");
                    sbQuery.Append(" ,PT.PART_SPEC1 ");
                    sbQuery.Append(" ,PT.PART_QTY ");
                    sbQuery.Append(" ,PT.O_PART_QTY ");
                    sbQuery.Append(" ,0 AS ORD_QTY ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,PT.UNIT_COST ");
                    sbQuery.Append(" ,PT.MAT_COST ");
                    sbQuery.Append(" ,PT.DRAW_EMP ");
                    sbQuery.Append(" ,S.DRAW_NO ");
                    sbQuery.Append(" ,PT.O_PT_ID ");
                    sbQuery.Append(" ,OPT.PART_CODE  AS P_PART_CODE ");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME ");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM ");
                    sbQuery.Append(" ,PT.INS_FLAG ");
                    //sbQuery.Append(" ,PT.SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                    sbQuery.Append(" ,PT.PUR_STAT ");
                    sbQuery.Append(" ,PT.OUT_REQ ");
                    sbQuery.Append(" ,PT.REG_DATE ");
                    sbQuery.Append(" ,PT.REG_EMP ");
                    sbQuery.Append(" ,PT.MDFY_DATE ");
                    sbQuery.Append(" ,PT.MDFY_EMP ");
                    sbQuery.Append(" ,PT.DEL_DATE ");
                    sbQuery.Append(" ,PT.DEL_EMP ");
                    sbQuery.Append(" ,PT.DATA_FLAG ");
                    sbQuery.Append(" ,PT.MAT_CODE ");
                    sbQuery.Append(" ,PT.WO_PART ");
                    sbQuery.Append(" ,PT.MC_GROUP ");
                    sbQuery.Append(" ,PT.ROUT_CODE ");
                    sbQuery.Append(" ,PT.IS_PLM_DEL ");
                    sbQuery.Append(" ,PT.PART_PUID ");

                    sbQuery.Append(" ,PT.Tab_Machine ");
                    sbQuery.Append(" ,PT.MakeSideHole ");
                    sbQuery.Append(" ,PT.Slit_Division ");
                    sbQuery.Append(" ,PT.Material ");
                    sbQuery.Append(" ,PT.Surface_Treat ");
                    sbQuery.Append(" ,PT.After_Treat ");
                    sbQuery.Append(" ,PT.MAKE_DESC ");
                    sbQuery.Append(" ,ISNULL(PT.IS_COPY_SIDE, '0') AS IS_COPY_SIDE "); 

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append(" AND PT.PART_CODE = S.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID ");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(" AND PT.DATA_FLAG = '0'  ORDER BY PT.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY5_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE   ");
                    sbQuery.Append(" ,PT.PT_ID ");
                    sbQuery.Append(" ,PT.PT_NO ");
                    sbQuery.Append(" ,PT.PROD_CODE ");
                    sbQuery.Append(" ,PT.PART_CODE ");
                    sbQuery.Append(" ,S.PART_NAME ");
                    sbQuery.Append(" ,S.MAT_LTYPE ");
                    sbQuery.Append(" ,S.MAT_SPEC ");
                    sbQuery.Append(" ,PT.PART_NUM ");
                    sbQuery.Append(" ,PT.PT_NAME ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.PART_QLTY ");
                    sbQuery.Append(" ,PT.PART_SPEC ");
                    sbQuery.Append(" ,PT.PART_SPEC1 ");
                    sbQuery.Append(" ,PT.PART_QTY ");
                    sbQuery.Append(" ,PT.O_PART_QTY ");
                    sbQuery.Append(" ,ISNULL(PT.ORD_QTY, 0) AS ORD_QTY");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,PT.UNIT_COST ");
                    sbQuery.Append(" ,PT.MAT_COST ");
                    sbQuery.Append(" ,PT.DRAW_EMP ");
                    sbQuery.Append(" ,S.DRAW_NO ");
                    sbQuery.Append(" ,PT.O_PT_ID ");
                    sbQuery.Append(" ,OPT.PART_CODE  AS P_PART_CODE ");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME ");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM ");
                    sbQuery.Append(" ,PT.INS_FLAG ");
                    //sbQuery.Append(" ,PT.SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                    sbQuery.Append(" ,PT.PUR_STAT ");
                    sbQuery.Append(" ,PT.OUT_REQ ");
                    sbQuery.Append(" ,PT.REG_DATE ");
                    sbQuery.Append(" ,PT.REG_EMP ");
                    sbQuery.Append(" ,PT.MDFY_DATE ");
                    sbQuery.Append(" ,PT.MDFY_EMP ");
                    sbQuery.Append(" ,PT.DEL_DATE ");
                    sbQuery.Append(" ,PT.DEL_EMP ");
                    sbQuery.Append(" ,PT.DATA_FLAG ");
                    sbQuery.Append(" ,PT.MAT_CODE ");
                    sbQuery.Append(" ,PT.WO_PART ");
                    sbQuery.Append(" ,PT.MC_GROUP ");
                    sbQuery.Append(" ,PT.ROUT_CODE ");
                    sbQuery.Append(" ,PT.IS_PLM_DEL ");
                    sbQuery.Append(" ,PT.PART_PUID ");

                    sbQuery.Append(" ,PT.Tab_Machine ");
                    sbQuery.Append(" ,PT.MakeSideHole ");
                    sbQuery.Append(" ,PT.Slit_Division ");
                    sbQuery.Append(" ,PT.Material ");
                    sbQuery.Append(" ,PT.Surface_Treat ");
                    sbQuery.Append(" ,PT.After_Treat ");
                    sbQuery.Append(" ,PT.MAKE_DESC ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append(" AND PT.PART_CODE = S.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID ");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(" ORDER BY PT.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY5_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PT.PLT_CODE   ");
                    sbQuery.Append(" ,PT.PT_ID ");
                    sbQuery.Append(" ,PT.PT_NO ");
                    sbQuery.Append(" ,PT.PROD_CODE ");
                    sbQuery.Append(" ,PT.PART_CODE ");
                    sbQuery.Append(" ,S.PART_NAME ");
                    sbQuery.Append(" ,S.MAT_LTYPE ");
                    sbQuery.Append(" ,S.MAT_SPEC ");
                    sbQuery.Append(" ,PT.PART_NUM ");
                    sbQuery.Append(" ,PT.PT_NAME ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.PART_QLTY ");
                    sbQuery.Append(" ,PT.PART_SPEC ");
                    sbQuery.Append(" ,PT.PART_SPEC1 ");
                    sbQuery.Append(" ,PT.PART_QTY ");
                    sbQuery.Append(" ,PT.O_PART_QTY ");
                    sbQuery.Append(" ,ISNULL(PT.ORD_QTY, 0) AS ORD_QTY");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,PT.UNIT_COST ");
                    sbQuery.Append(" ,PT.MAT_COST ");
                    sbQuery.Append(" ,PT.DRAW_EMP ");
                    sbQuery.Append(" ,S.DRAW_NO ");
                    sbQuery.Append(" ,PT.O_PT_ID ");
                    sbQuery.Append(" ,OPT.PART_CODE  AS P_PART_CODE ");
                    sbQuery.Append(" ,OPT.PT_NAME AS P_PART_NAME ");
                    sbQuery.Append(" ,OPT.PART_NUM AS P_PART_NUM ");
                    sbQuery.Append(" ,PT.INS_FLAG ");
                    //sbQuery.Append(" ,PT.SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                    sbQuery.Append(" ,PT.PUR_STAT ");
                    sbQuery.Append(" ,PT.OUT_REQ ");
                    sbQuery.Append(" ,PT.REG_DATE ");
                    sbQuery.Append(" ,PT.REG_EMP ");
                    sbQuery.Append(" ,PT.MDFY_DATE ");
                    sbQuery.Append(" ,PT.MDFY_EMP ");
                    sbQuery.Append(" ,PT.DEL_DATE ");
                    sbQuery.Append(" ,PT.DEL_EMP ");
                    sbQuery.Append(" ,PT.DATA_FLAG ");
                    sbQuery.Append(" ,PT.MAT_CODE ");
                    sbQuery.Append(" ,PT.WO_PART ");
                    sbQuery.Append(" ,PT.MC_GROUP ");
                    sbQuery.Append(" ,PT.ROUT_CODE ");
                    sbQuery.Append(" ,PT.IS_PLM_DEL ");
                    sbQuery.Append(" ,PT.PART_PUID ");

                    sbQuery.Append(" ,PT.Tab_Machine ");
                    sbQuery.Append(" ,PT.MakeSideHole ");
                    sbQuery.Append(" ,PT.Slit_Division ");
                    sbQuery.Append(" ,PT.Material ");
                    sbQuery.Append(" ,PT.Surface_Treat ");
                    sbQuery.Append(" ,PT.After_Treat ");
                    sbQuery.Append(" ,PT.MAKE_DESC ");

                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART S");
                    sbQuery.Append(" ON PT.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append(" AND PT.PART_CODE = S.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.O_PT_ID = OPT.PT_ID ");
                    sbQuery.Append(" AND PT.PLT_CODE = OPT.PLT_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));

                        sbWhere.Append(" AND PT.DATA_FLAG = '0'  ORDER BY PT.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataTable TMAT_PARTLIST_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PT.PLT_CODE");
                    sbQuery.Append(" ,PT.PT_ID");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,OPT.PART_CODE AS O_PART_CODE");
                    sbQuery.Append(" ,OSP.PART_NAME AS O_PART_NAME");
                    sbQuery.Append(" ,PT.TAB_MACHINE");
                    sbQuery.Append(" ,PT.MAKESIDEHOLE");
                    sbQuery.Append(" ,PT.SLIT_DIVISION");
                    sbQuery.Append(" ,ISNULL(PT.MATERIAL, SP.MAT_QLTY) AS MATERIAL");
                    sbQuery.Append(" ,PT.SURFACE_TREAT");
                    sbQuery.Append(" ,PT.AFTER_TREAT");
                    sbQuery.Append(" FROM TMAT_PARTLIST PT");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OPT");
                    sbQuery.Append(" ON PT.PLT_CODE = OPT.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = OPT.O_PT_ID");
                    sbQuery.Append(" AND PT.O_PT_ID IS NOT NULL"); 

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART OSP");
                    sbQuery.Append(" ON OPT.PLT_CODE = OSP.PLT_CODE");
                    sbQuery.Append(" AND OPT.PART_CODE = OSP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PT_ID, PART_CODE FROM TSHP_WORKORDER");
                    sbQuery.Append(" WHERE DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PT_ID, PART_CODE");
                    sbQuery.Append(" ) W");
                    sbQuery.Append(" ON PT.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = W.PT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_PART", "PT.WO_PART = @WO_PART"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND SP.MAT_LTYPE IN('11','33') "); 
                        sbWhere.Append(" AND W.PART_CODE IS NULL ");
                        

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataTable TMAT_PARTLIST_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" TP.PLT_CODE");
                    sbQuery.Append(" ,TP.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,TP.O_PT_ID");
                    sbQuery.Append(" ,OTP.PART_CODE AS O_PART_CODE");
                    sbQuery.Append(" ,OSP.PART_NAME AS O_PART_NAME");
                    sbQuery.Append(" ,TP.TAB_MACHINE");
                    sbQuery.Append(" ,TP.MAKESIDEHOLE");
                    sbQuery.Append(" ,TP.SLIT_DIVISION");
                    sbQuery.Append(" ,SP.SAFE_STK_QTY");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,TP.MAKE_DESC");
                    sbQuery.Append(" ,TP.PART_QTY");
                    sbQuery.Append(" ,TP.ORD_QTY");
                    sbQuery.Append(" ,TP.IS_REVISION");
                    sbQuery.Append(" FROM TMAT_PARTLIST TP");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON TP.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND TP.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OTP");
                    sbQuery.Append(" ON TP.PLT_CODE = OTP.PLT_CODE");
                    sbQuery.Append(" AND TP.O_PT_ID = OTP.PT_ID");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART OSP");
                    sbQuery.Append(" ON OTP.PLT_CODE = OSP.PLT_CODE");
                    sbQuery.Append(" AND OTP.PART_CODE = OSP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" TP.PLT_CODE");
                    sbQuery.Append(" ,TP.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,TP.O_PT_ID");
                    sbQuery.Append(" ,OTP.PART_CODE AS O_PART_CODE");
                    sbQuery.Append(" ,OSP.PART_NAME AS O_PART_NAME");
                    sbQuery.Append(" ,TP.TAB_MACHINE");
                    sbQuery.Append(" ,TP.MAKESIDEHOLE");
                    sbQuery.Append(" ,TP.SLIT_DIVISION");
                    sbQuery.Append(" ,SP.SAFE_STK_QTY");
                    sbQuery.Append(" ,TP.MATERIAL");
                    sbQuery.Append(" ,TP.SURFACE_TREAT");
                    sbQuery.Append(" ,TP.AFTER_TREAT");
                    sbQuery.Append(" ,TP.IS_REVISION");
                    sbQuery.Append(" ,TP.MAKE_DESC");
                    sbQuery.Append(" ,TP.PART_QTY");
                    sbQuery.Append(" ,TP.ORD_QTY");
                    sbQuery.Append(" FROM TMAT_PARTLIST TP");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON TP.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND TP.PART_CODE = SP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OTP");
                    sbQuery.Append(" ON TP.PLT_CODE = OTP.PLT_CODE");
                    sbQuery.Append(" AND TP.O_PT_ID = OTP.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART OSP");
                    sbQuery.Append(" ON OTP.PLT_CODE = OSP.PLT_CODE");
                    sbQuery.Append(" AND OTP.PART_CODE = OSP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "TP.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable TMAT_PARTLIST_QUERY9(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" TP.PLT_CODE");
                    sbQuery.Append(" ,TP.PT_ID");
                    sbQuery.Append(" ,TP.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    //sbQuery.Append(" ,TP.O_PT_ID");
                    //sbQuery.Append(" ,OTP.PART_CODE AS O_PART_CODE");
                    //sbQuery.Append(" ,OSP.PART_NAME AS O_PART_NAME");
                    //sbQuery.Append(" ,TP.TAB_MACHINE");
                    //sbQuery.Append(" ,TP.MAKESIDEHOLE");
                    //sbQuery.Append(" ,TP.SLIT_DIVISION");
                    //sbQuery.Append(" ,SP.SAFE_STK_QTY");
                    sbQuery.Append(" ,TP.Material");
                    sbQuery.Append(" ,TP.Surface_Treat");
                    sbQuery.Append(" ,TP.After_Treat");
                    sbQuery.Append(" ,TP.IS_REVISION");
                    sbQuery.Append(" ,TP.IS_REMCT");
                    sbQuery.Append(" ,TP.IS_MODIFY");
                    //sbQuery.Append(" ,TP.MAKE_DESC");
                    //sbQuery.Append(" ,TP.PART_QTY");
                    //sbQuery.Append(" ,TP.ORD_QTY");
                    sbQuery.Append(" FROM TMAT_PARTLIST TP");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON TP.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND TP.PART_CODE = SP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST OTP");
                    sbQuery.Append(" ON TP.PLT_CODE = OTP.PLT_CODE");
                    sbQuery.Append(" AND TP.O_PT_ID = OTP.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART OSP");
                    sbQuery.Append(" ON OTP.PLT_CODE = OSP.PLT_CODE");
                    sbQuery.Append(" AND OTP.PART_CODE = OSP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "TP.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "TP.PT_ID = @PT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TP.DATA_FLAG = @DATA_FLAG"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}