using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace BizExecute
{
    public static class UTIL
    {
        public enum emSerialFormat
        {

            YYYYMMDD,

            YYMMDD,

            YYMMDDHH,

            YYMMDDHHMI,

            YYMM,
                
            YY

        }

        private static string SetSerialNo(string plt_code, string sr_code, string sr_key, string sep, BizExecute bizExecute)
        {
            try
            {
                //string plt_code = paramTable.Rows[0]["PLT_CODE"].ToString();
                //string sr_code = paramTable.Rows[0]["SR_CODE"].ToString();
                string sepChar = string.Empty;



                int sr_no = 0;

                //1. TSYS_SERIAL 조회하여(PLT_CODE, SR_CODE, SR_KEY) SR_NO 받아옴.
                //2.  데이터 존재하면 SR_NO 1증가하여 UPDATE TSYS_SERIAL 
                //3.  데이터 없으면 SR_NO 1로 INSERT TSYS_SERIAL
                string strQuery = "SELECT   PLT_CODE " +
                                "       , SR_CODE " +
                                "       , SR_KEY " +
                                "       , SR_NO " +
                                "  FROM TSYS_SERIAL " +
                                "  WHERE PLT_CODE = " + ExtensionMethod.toDBString(plt_code) +
                                "   AND SR_CODE = " + ExtensionMethod.toDBString(sr_code) +
                                "   AND SR_KEY = " + ExtensionMethod.toDBString(sr_key);


                DataTable serialDT = bizExecute.executeSelectQuery(strQuery).Copy();  //dbConn.executeSelectQuery(strQuery).Copy();

                bizExecute.executeInsertQuery(strQuery);

                if (serialDT.Rows.Count > 0)
                {
                    sr_no = serialDT.Rows[0]["SR_NO"].toInt32() + 1;

                    strQuery = "UPDATE TSYS_SERIAL " +
                        " SET   SR_NO = " + sr_no + "" +
                        " WHERE PLT_CODE = '" + plt_code + "'" +
                        "   AND SR_CODE = '" + sr_code + "'" +
                        "   AND SR_KEY = '" + sr_key + "'";

                    bizExecute.executeUpdateQuery(strQuery);
                }
                else
                {
                    sr_no = 1;

                    strQuery = " INSERT INTO TSYS_SERIAL " +
                        " ( PLT_CODE     , SR_CODE     , SR_KEY     , SR_NO ) " +
                        " VALUES " +
                        " ( '" + plt_code + "', '" + sr_code + "', '" + sr_key + "', " + sr_no + ")";

                    bizExecute.executeInsertQuery(strQuery);

                }

                string sr_num = string.Empty;
                if (sep == "")
                {
                    sr_num = sr_code + sr_key + string.Format("{0:D3}", Convert.ToInt32(sr_no));
                }
                else if (sep == "W")
                {
                    sr_num = sr_code + sr_key + string.Format("{0:D4}", Convert.ToInt32(sr_no));
                }
                else
                {
                    sr_num = sr_code + sr_key + sep + string.Format("{0:D4}", Convert.ToInt32(sr_no));
                }


                switch (sr_code)
                {
                    case "PROD":
                    {
                        sr_num = sr_key + sep + string.Format("{0:D4}", Convert.ToInt32(sr_no));
                        break;
                    }
                    case "ITEM":
                    {
                        sr_num = sr_key + sep + string.Format("{0:D4}", Convert.ToInt32(sr_no));
                        break;
                    }
                    case "PM":
                    {
                        sr_num = sr_code + sr_key + string.Format("{0:D4}", Convert.ToInt32(sr_no));
                        break;
                    }
                    case "INS":
                        {
                            sr_num = sr_code + sr_key + string.Format("{0:D6}", Convert.ToInt32(sr_no));
                            break;
                        }
                }

                return sr_num;
            }
            catch //(Exception ex)
            {
                return "";
            }
        }

        //품번생성
        public static string UTILITY_GET_SERIALNO(string plt_code, string sr_code, string item_code, string sep, BizExecute bizExecute)
        {

            string sr_key = string.Empty;

            sr_key = item_code;

            return SetSerialNo(plt_code, sr_code, sr_key, sep, bizExecute);
        }


        public static string UTILITY_GET_SERIALNO(string plt_code, string sr_code, BizExecute bizExecute)
        {
            string sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYMMDD"].ToString();

            return SetSerialNo(plt_code, sr_code, sr_key, "", bizExecute);
        }

        public static string UTILITY_GET_SERIALNO(string plt_code, string sr_code, emSerialFormat keyFormat, string sep, BizExecute bizExecute)
        {

            string sr_key = string.Empty;

            switch (keyFormat)
            {
                case emSerialFormat.YYYYMMDD :
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYYYMMDD"].ToString();
                    break;

                case emSerialFormat.YYMMDD :
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYMMDD"].ToString();
                    break;

                case emSerialFormat.YYMMDDHH:
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYMMDDHH"].ToString();
                    break;

                case emSerialFormat.YYMMDDHHMI :
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYMMDDHHMI"].ToString();
                    break;

                case emSerialFormat.YYMM:
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YYMM"].ToString();
                    break;
                case emSerialFormat.YY:
                    sr_key = UTILITY_GET_DTNOW(bizExecute).Rows[0]["YY"].ToString();
                    break;
            }


            return SetSerialNo(plt_code, sr_code, sr_key, sep, bizExecute);
        }

        public static DataTable UTILITY_GET_DTNOW(BizExecute bizExecute)
        {
            string query = "SELECT CONVERT(datetime, GETDATE(), 120) 'NOW_DT', " + 
                " convert(char(8), GETDATE(), 112) AS 'YYYYMMDD', " +
                " convert(char(6), GETDATE(), 12) AS 'YYMMDD', " +
                " convert(char(4), GETDATE(), 12) AS 'YYMM', " +
                " convert(char(2), GETDATE(), 12) AS 'YY', " +
                " cast(datepart(hour, GETDATE()) as Nchar(2)) 'HH', " +
                " cast(datepart(minute, GETDATE()) as Nchar(2)) 'MI', '' AS 'YYMMDDHHMI', '' AS 'YYMMDDHH' ";

            //DBConnection con = new DBConnection();
            
            //DataTable resultDT = con.executeSelectQuery(query).Copy();

            DataTable resultDT = bizExecute.executeSelectQuery(query).Copy();

            //BizRun.BizConn.executeInsertQuery(query);

            if (resultDT.Rows[0]["HH"].ToString().Trim().Length == 1)
                resultDT.Rows[0]["HH"] = "0" + resultDT.Rows[0]["HH"].ToString();

            if (resultDT.Rows[0]["MI"].ToString().Trim().Length == 1)
                resultDT.Rows[0]["MI"] = "0" + resultDT.Rows[0]["MI"].ToString();

            if (resultDT.Rows[0]["YY"].ToString().Trim().Length == 1)
                resultDT.Rows[0]["YY"] = "0" + resultDT.Rows[0]["YY"].ToString();

            resultDT.Rows[0]["YYMMDDHHMI"] = resultDT.Rows[0]["YYMMDD"].ToString() +
                resultDT.Rows[0]["HH"].ToString() +
                resultDT.Rows[0]["MI"].ToString();

            resultDT.Rows[0]["YYMMDDHH"] = resultDT.Rows[0]["YYMMDD"].ToString() +
                resultDT.Rows[0]["HH"].ToString();

            return resultDT;

        }


        public static DateTime UTILITY_GET_NOW(BizExecute bizExecute)
        {
            try
            {
                string query = "SELECT GETDATE() ";

                //DBConnection con = new DBConnection();

                //DataTable resultDT = con.executeSelectQuery(query).Copy();

                DataTable resultDT = bizExecute.executeSelectQuery(query).Copy();

                //BizRun.BizConn.executeInsertQuery(query);

                return resultDT.Rows[0][0].toDateTime();
            }
            catch
            {
                return DateTime.Now;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strKeyList">ex)"key1,key2,..... </param>
        /// <param name="drKey"></param>
        /// <returns></returns>
        public static DataTable GetSelectExist(string strTableName, string strKeyList, DataRow drKey, BizExecute bizExecute)
        {
            string[] strKeys = strKeyList.Split(',');

            string strQuery = "SELECT TOP 1 * FROM " + strTableName + " ";
            string strWhere = "WHERE 1=1 ";

            foreach (string key in strKeys)
            {
                strWhere += " AND " + key + " = " + ExtensionMethod.toDBString(drKey[key]);
            }

            strQuery += strWhere;

            return bizExecute.executeSelectQuery(strQuery);
        }


        public static DataSet SetError(string strErrMsg, Exception ex)
        {
            DataTable errTable = new DataTable("ERROR");
            errTable.Columns.Add("ERR_MSG",typeof(String));
            errTable.Columns.Add("EX",typeof(Object));
            DataRow errRow = errTable.NewRow();

            errRow["ERR_MSG"] = strErrMsg;
            errRow["EX"] = ex;

            errTable.Rows.Add(errRow);

            DataSet dsErr = new DataSet();
            dsErr.Tables.Add(errTable);

            return dsErr;
        }

        public static DataSet GetXmlSchema(string strXmlData)
        {
            try
            {

                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(strXmlData);
                writer.Flush();
                stream.Position = 0;
                DataSet dsSchema = new DataSet();
                dsSchema.ReadXmlSchema(stream);
                //dsSchema.ReadXml(stream);
                return dsSchema;
            }
            catch
            {
                return null;
            }
        }

        //필드명에 해당하는 컬럼 유무 확인
        public static bool ValidColumn(DataRow row, string strColumnName)
        {
            try
            {
                strColumnName = strColumnName.Trim();

                if (row[strColumnName] != null && row[strColumnName].ToString() != "")
                {
                    return true;
                }                
            }
            catch
            {
                return false;
            }
            return false;
        }


        public static string GetValidValue(string value)
        {
            return "'" + value + "'";
        }

        //필드명의 데이터를 가져오고 컬럼이 없다면 null 값을 넘긴다
        //데이터의 타입이 스트링이면 압뒤로 ' 붙인다
        public static object GetValidValue_IN(DataRow row, string strColumnName)
        {
            try
            {
                strColumnName = strColumnName.Trim();

                strColumnName = strColumnName.Replace("@", "");

                if (row[strColumnName] != null && row[strColumnName].ToString() != "")
                {

                    if (row[strColumnName].GetType() == typeof(string))
                    {
                        if (row[strColumnName].ToString().Contains(","))
                        {
                            string[] conds = row[strColumnName].ToString().Split(',');
                            string value = "";

                            foreach (string cond in conds)
                            {
                                string tmp = cond.ToString().Replace("'", "''");
                                value += "'" + tmp.Replace(" ", "") + "',";
                            }

                            return value.Substring(0, value.Length - 1);
                        }
                        else
                        {
                            string value = row[strColumnName].ToString().Replace("'", "''");
                            return "'" + value + "'";
                        }

                    }
                    else if (IsNumeric(row[strColumnName].ToString()))
                    {
                        return row[strColumnName].ToString();
                    }
                    else
                    {
                        return row[strColumnName];
                    }
                }
            }
            catch
            {
                return "''";
            }
            return "''";
        }

        //필드명의 데이터를 가져오고 컬럼이 없다면 null 값을 넘긴다
        //데이터의 타입이 스트링이면 압뒤로 ' 붙인다
        public static object GetValidValue(DataRow row, string strColumnName)
        {
            try
            {
                strColumnName = strColumnName.Trim();

                strColumnName = strColumnName.Replace("@", "");

                if (row[strColumnName] != null && row[strColumnName].ToString() != "")
                {

                    if (row[strColumnName].GetType() == typeof(string))
                    {
                        //if (row[strColumnName].ToString().Contains(","))
                        //{
                        //    string[] conds = row[strColumnName].ToString().Split(',');
                        //    string value = "";

                        //    foreach (string cond in conds)
                        //    {
                        //        string tmp = cond.ToString().Replace("'", "''");
                        //        value += "'" + tmp.Replace(" ", "") + "',";
                        //    }

                        //    return value.Substring(0, value.Length - 1);
                        //}
                        //else
                        //{
                            string value = row[strColumnName].ToString().Replace("'", "''");
                            return "'" + value + "'";
                        //}

                    }
                    else if (IsNumeric(row[strColumnName].ToString()))
                    {
                        return row[strColumnName].ToString();
                    }
                    else
                    {
                        return row[strColumnName];
                    }
                }
            }
            catch
            {
                return "''";
            }
            return "''";
        }


        public enum SqlCondType
        {
            NONE,
            BETWEEN,
            LIKE,
            IN
        }


        public static string GetWhere(string value,string strWhereColumnName)
        {
            try
            {
                if (value == "") return "";

                string query = "";

                query = strWhereColumnName + " = '" + value + "'";
                
                return " AND (" + query + ") ";
            }
            catch
            {
                return "";
            }
            
        }

        public static string GetWhere(string value,string strColumn , string strWhereColumnName)
        {
            try
            {
                if (value == "") return "";

                string query = strWhereColumnName.Replace(strColumn, "'"+ value + "'") ; 

                return " AND (" + query + ") ";
            }
            catch
            {
                return "";
            }

        }

        public static string GetWhere(DataRow row, string strColumnName, string strWhereColumnName)
        {
            return GetWhere(row, strColumnName, strWhereColumnName, SqlCondType.NONE);
        }


        /// <summary>
        /// 조건 쿼리 생상 (AND 자동 포함) 
        /// </summary>
        /// <param name="row">RQSTDT Row</param>
        /// <param name="strColumnName">RQSTDT 컬럼, 날짜 검색시 (ex "S_DATE,E_DATE) </param>
        /// <param name="strWhereColumnName">검색 테이블 플드명(ex "A.PLT_CODE", 또는 "A.PLT_CODE,B.PROD_CODE" => OR 조건문으로 변환 
        ///                                  2개이상일시 무조건 OR로 검색  </param>
        /// <param name="SqlCondType">0:일반,1:Between, 2:LIKE </param>//사용안합
        /// <returns></returns>
        public static string GetWhere(DataRow row, string strColumnName, string strWhereColumnName, SqlCondType SqlCondType)
        {
            try
            {
                string query = "";
                string[] valueColumns = strColumnName.Split(',');
                string[] tableColumns = strWhereColumnName.Split(',');
                string returnStr = "";

                switch (SqlCondType)
                {
                    case UTIL.SqlCondType.NONE:

                        if (strColumnName == "")
                        {
                            query = strWhereColumnName;

                            //return " AND ( " + query + " ) ";
                            returnStr = " AND ( " + query + " ) ";
                        }
                        else //if(strWhereColumnName.Contains("@"))
                        {
                            query = strWhereColumnName;
                            foreach (string value in valueColumns)
                            {
                                if (!ValidColumn(row, value.Replace("@", ""))) return "";

                                query = query.Replace(value, GetValidValue(row, value.Replace("@", "")).ToString());
                            }

                            //return " AND ( " + query + " ) ";
                            returnStr = " AND ( " + query + " ) ";
                        }
                        break;

                    case UTIL.SqlCondType.IN:
                        query = strWhereColumnName;
                        foreach (string value in valueColumns)
                        {
                            if (!ValidColumn(row, value.Replace("@", ""))) return "";
                            
                            //query = query.Replace(value, "(" + GetValidValue(row, value.Replace("@", "")).ToString() + ")");
                            query = query.Replace(value, "(" + GetValidValue_IN(row, value.Replace("@", "")).ToString() + ")");
                        }

                        returnStr = " AND ( " + query + " ) ";
                        break;

                    //else
                    //{
                    #region 사용안합
                    //    switch (SqlCondType)
                    //    {
                    //        case SqlCondType.NONE://OR
                    //            if (ValidColumn(row, strColumnName))
                    //            {
                    //                foreach (string column in tableColumns)
                    //                {
                    //                    if (column != "")
                    //                    {
                    //                        if (query != "") { query += " OR "; }

                    //                        query += " " + column + " = " + GetValidValue(row, strColumnName);
                    //                    }
                    //                }
                    //                return " AND (" + query + ") ";
                    //            }
                    //            break;
                    //        case SqlCondType.BETWEEN://Bewteen                        
                    //            if (tableColumns.Length != 1) return "";
                    //            if (valueColumns.Length != 2) return "";
                    //            if (ValidColumn(row, valueColumns[0]) && ValidColumn(row, valueColumns[1]))
                    //            {
                    //                query += " " + strWhereColumnName + " BETWEEN " + UTIL.GetValidValue(row, valueColumns[0]) + " AND " + UTIL.GetValidValue(row, valueColumns[1]);

                    //                return " AND (" + query + ") ";
                    //            }
                    //            break;

                    //        case SqlCondType.LIKE://OR LIKE 
                    //            if (ValidColumn(row, strColumnName))
                    //            {
                    //                foreach (string column in tableColumns)
                    //                {
                    //                    if (column != "")
                    //                    {
                    //                        if (query != "") { query += " OR "; }

                    //                        query += " " + column + " LIKE '%'+" + UTIL.GetValidValue(row, strColumnName) + "+'%'";
                    //                    }
                    //                }
                    //                return " AND (" + query + ") ";
                    //            }
                    //            break;
                    //        //case SqlCondType.IN://IN
                    //        //    if (ValidColumn(row, strColumnName))
                    //        //    {
                    //        //        foreach (string column in tableColumns)
                    //        //        {
                    //        //            if (column != "")
                    //        //            {
                    //        //                if (query != "") { query += ","; }

                    //        //                query += " " + column + " LIKE '%'+" + UTIL.GetValidValue(row, strColumnName) + "+'%'";
                    //        //            }
                    //        //        }
                    //        //        return " AND (" + query + ") ";
                    //        //    }
                    //        //    break;
                    //    }
                    #endregion
                    //}
                }

                return returnStr;
                
                    
            }
            catch { }
            return "";
        }

                
        public static Exception SetException(Exception ex)
        {
            if(ex.InnerException == null)
            {
                return ex;
            }
            return SetException((Exception)(ex.InnerException), "", "");
        }

        public static Exception SetException(Exception ex, string loc)
        {
            if (ex.InnerException == null)
            {
                if (loc != "")
                {
                    if (ex.Data.Contains("LOC"))
                        ex.Data["LOC"] = "[" + loc + "] -> " + ex.Data["LOC"].ToString();
                    else
                        ex.Data.Add("LOC", "[" + loc + "]");
                }
                return ex;
            }
            return SetException((Exception)(ex.InnerException), loc, "");
        }

        /// <summary>
        /// 오류처리 사용자 정의(중복됐을시, Overwrite History 삭제된 항목)
        /// </summary>
        /// <param name="message">오류 메세지</param>
        /// <param name="Key">오류 키값</param>
        /// <param name="loc">오류 메소드</param>
        /// <param name="errNumber">오류 번호</param>
        /// <param name="row">중복된 행값</param>
        /// <returns></returns>
        public static Exception SetException(string message, string Key, string loc, int errNumber, DataRow row)
        {                     

            Exception ex = new Exception(message + "[KEY=" + Key + "]");

            Dictionary<string, object> dic = new Dictionary<string, object>();
            
            foreach(DataColumn col in row.Table.Columns)
            {
                dic.Add(col.ColumnName, row[col.ColumnName]);
            }

            ex.Data.Add("ROW", dic);

            return SetException(ex, loc, errNumber.ToString());
        }

        /// <summary>
        /// 오류 처리 사용자 정의(중복 처리시, Overwrite)
        /// </summary>
        /// <param name="message">오류 메세지</param>
        /// <param name="Key">오류 키값</param>
        /// <param name="loc">오류 메소드</param>
        /// <param name="errNumber">오류 번호</param>
        /// <returns></returns>
        public static Exception SetException(string message, string Key, string loc, int errNumber)
        {
            Exception bizEx = new Exception(message, null);

            Exception ex = new Exception(message + "[KEY=" + Key + "]");

            return SetException(bizEx, loc, errNumber.ToString());
        }

        public static Exception SetException(string message, string loc, int errNumber)
        {
            Exception ex = new Exception(message,null);

            return SetException(ex, loc, errNumber.ToString());
        }

        public static Exception SetException(string message, string loc)
        {
            Exception ex = new Exception(message, null);

            return SetException(ex, loc, "");
        }

        public static Exception SetException(string message)
        {
            Exception ex = new Exception(message, null);

            return SetException(ex, "", "");
        }

        public static Exception SetException(string message, int errNumber)
        {
            Exception ex = new Exception(message,null);

            return SetException(ex, "", errNumber.ToString());
        }

        /// <summary>
        /// 예외처리
        /// </summary>
        /// <param name="ex">오류</param>
        /// <param name="loc">오류 메소드 위치 저장</param>
        /// <param name="data">쿼리일경우 저장</param>
        /// <returns></returns>
        public static Exception SetException(Exception ex, string loc, string data)
        {               
            if (ex.InnerException == null)
            {
                if (loc != "")
                {
                    if (ex.Data.Contains("LOC"))
                        ex.Data["LOC"] = "[" + loc + "] -> " + ex.Data["LOC"].ToString();
                    else
                        ex.Data.Add("LOC", "[" + loc + "]");
                }

                if (data != "") ex.Data.Add("DATA", data);             

                return ex;
            }
            return SetException((Exception)(ex.InnerException), loc, data);
        }

        //문자, 숫자, "_" 일때만 True
        public static bool CheckParam(string chr)
        {  
            if (CheckEnglishNumber(chr) || (chr == "_"))
            {
                return true;
            }
            return false;
        }


        #region #. CheckEnglish
        /// <summary>
        /// 영문체크
        /// </summary>
        /// <param name="letter">문자
        /// 
        public static bool CheckEnglish(string letter)
        {
            bool IsCheck = true;

            Regex engRegex = new Regex(@"[a-zA-Z]");
            Boolean ismatch = engRegex.IsMatch(letter);

            if (!ismatch)
            {
                IsCheck = false;
            }

            return IsCheck;
        }
        #endregion

        #region #. CheckNumber
        /// <summary>
        /// 숫자체크
        /// </summary>
        /// <param name="letter">문자
        /// 
        public static bool CheckNumber(string letter)
        {
            bool IsCheck = true;

            Regex numRegex = new Regex(@"[0-9]");
            Boolean ismatch = numRegex.IsMatch(letter);

            if (!ismatch)
            {
                IsCheck = false;
            }

            return IsCheck;
        }
        #endregion

        #region #. CheckEnglishNumber
        /// <summary>
        /// 영문/숫자체크
        /// </summary>
        /// <param name="letter">문자
        /// 
        public static bool CheckEnglishNumber(string letter)
        {
            bool IsCheck = true;

            Regex engRegex = new Regex(@"[a-zA-Z]");
            Boolean ismatch = engRegex.IsMatch(letter);
            Regex numRegex = new Regex(@"[0-9]");
            Boolean ismatchNum = numRegex.IsMatch(letter);

            if (!ismatch && !ismatchNum)
            {
                IsCheck = false;
            }

            return IsCheck;
        }
        #endregion





        public static void SetBizAddColumnToValue(DataTable dt, string addColumn, Type type)
        {
            try
            {
                dt.Columns.Add(addColumn, type);                
            }
            catch
            { }
        }

        //public static void SetBizAddColumnToValue(DataTable dt, string addColumn)
        //{
        //    SetBizAddColumnToValue(dt, addColumn, addColumn);
        //}


        /// <summary>
        /// 같은 테이블에 있는 값 가져올때
        /// dt 테이블에 addColumn컬럼 추가하여 dt 테이블에 있는 addValueColumn컬럼에 해당하는 값  입력
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="addColumn"></param>
        /// <param name="addValueColumn"></param>
        public static void SetBizAddColumnToValue(DataTable dt, string addColumn, string addValueColumn)
        {
            try
            {
                dt.Columns.Add(addColumn);
            }
            catch
            { }

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[addColumn] = row[addValueColumn];
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 테이블에 컬럼 추가 및 Value 추가
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="addColumn">추가할 컬럼명</param>
        /// <param name="addValue">추가할 컬럼에 들어갈 값</param>
        /// <param name="type">추가할 컬럼 데이터 타입</param>
        /// <param name="IsNotNewRow">데이터 Row가 없을시 행추가 여부 확인</param>
        public static void SetBizAddColumnToValue(DataTable dt, string addColumn, object addValue, Type type, bool IsNotNewRow = false)
        {
            try
            {
                dt.Columns.Add(addColumn,type);
            }
            catch
            {  }
            try
            {
                foreach(DataRow row in dt.Rows)
                {
                    row[addColumn] = addValue;
                }

                if (dt.Rows.Count == 0
                    && IsNotNewRow == false)
                {
                    DataRow r = dt.NewRow();
                    r[addColumn] = addValue;
                    dt.Rows.Add(r);
                }
            }
            catch
            { }
        }


        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);            
        } 

        /// <summary>
        /// 데이타 테이블을 데이타셋으로 변환하여 반환
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataSet GetDtToDs(DataTable dt)
        {
            return GetDtToDs(dt, "RQSTDT");
        }


        /// <summary>
        /// 데이타 테이블을 데이타셋으로 변환하여 반환
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>
        public static DataSet GetDtToDs(DataTable dt, string dtName)
        {
            DataSet ds = new DataSet();

            DataTable dtCopy = dt.Copy();

            dtCopy.TableName = dtName;

            ds.Tables.Add(dtCopy.Copy());

            return ds;
        }

        public static DataTable GetDsToDt(DataSet ds)
        {
            if(ds.Tables.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }

            return ds.Tables[0].Copy();
        }

        public static DataTable GetDsToDt(DataSet ds,string dtName)
        {
            if (ds.Tables.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }

            return ds.Tables[dtName].Copy();
        }

        public static DataTable GetRowToDt(DataRow row)
        {
            DataTable dtRsltdt = row.Table.Clone();

            dtRsltdt.ImportRow(row);

            return dtRsltdt;
        }


        /// <summary>
        /// 지정된 컬럼으로만 테이블 반환값 생성
        /// </summary>
        /// <param name="row"></param>
        /// <param name="strColList">ex) plt_code,plt_name....</param>
        /// <returns></returns>
        public static DataTable GetRowToDt(DataRow row,string strColList)
        {
            string[] ColList = strColList.Split(',');

            DataTable dtRsltdt = new DataTable();
            foreach(string colName in ColList)
            {
                try
                {
                    dtRsltdt.Columns.Add(colName);
                }
                catch { }
            }

            DataRow newRow = dtRsltdt.NewRow();

            foreach (string colName in ColList)
            {
                try
                {
                    //dtRsltdt.Columns.Add(colName, row[colName].GetType());
                    newRow[colName] = row[colName];
                }
                catch { }
            }

            dtRsltdt.Rows.Add(newRow);

            return dtRsltdt;
        }


        /// <summary>
        /// 지정된 컬럼으로만 테이블 반환값 생성
        /// </summary>
        /// <param name="row"></param>
        /// <param name="strColList">ex) plt_code,plt_name....</param>
        /// <returns></returns>
        public static DataTable GetDtToDt(DataTable dt, string strColList)
        {
            string[] ColList = strColList.Split(',');

            DataTable dtRsltdt = new DataTable();
            foreach (string colName in ColList)
            {
                try
                {
                    dtRsltdt.Columns.Add(colName, dt.Columns[colName].DataType);
                }
                catch { }
            }

            foreach (DataRow row in dt.Rows)
            {
                DataRow newRow = dtRsltdt.NewRow();

                foreach (string colName in ColList)
                {
                    try
                    {
                        //dtRsltdt.Columns.Add(colName, row[colName].GetType());
                        newRow[colName] = row[colName];
                    }
                    catch { }
                }

                dtRsltdt.Rows.Add(newRow);
            }

            return dtRsltdt;
        }


        public static string GetConfValue(string conf_name, BizExecute bizExecute)
        {

            string Query = string.Format("SELECT CONF_VALUE FROM TSYS_CONF WHERE PLT_CODE = '{0}' AND CONF_NAME = '{1}'", ConnInfo.PLT_CODE, conf_name);

            DataTable dtRslt = bizExecute.executeSelectQuery(Query);

            if(dtRslt.Rows.Count > 0)
            {
                return dtRslt.Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }

        }

        public static bool IsHoliday(DateTime dateTime, BizExecute bizExecute)
        {            

            string Query = string.Format("SELECT HOLI_NAME FROM LSE_HOLIDAY WHERE PLT_CODE = '{0}' AND HOLI_DATE = '{1}'", ConnInfo.PLT_CODE, dateTime.toDateString("yyyyMMdd"));

            DataTable dtRslt = bizExecute.executeSelectQuery(Query);

            if (dtRslt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }            
    
}
