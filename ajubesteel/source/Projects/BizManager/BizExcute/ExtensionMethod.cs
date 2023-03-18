using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BizExecute
{
    public static class ExtensionMethod
    {

        public static string PLT_CODE = "100";

        public static string toDBString(this object value)
        {
            string val = "'" + value.ToString() + "'";

            return val;
        }

        public static double toDbl(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToDouble(value);
            }
            else
            {
                return 0;
            }


        }

        public static int toInt32(this object value)
        {
            try
            {
                if (value.isNumeric())
                {
                    return System.Convert.ToInt32(value);

                }
                else
                {
                    return 0;

                }
            }
            catch// (Exception ex)
            {
                return 0;
            }
        }

        public static bool isNull(this object value)
        {
            if (value == null || value == DBNull.Value)
            {

                return true;

            }
            else
            {
                return false;
            }

        }

        public static string toStrNull(this object value)
        {

            if (!value.isNull())
            {
                return System.Convert.ToString(value);

            }
            else
            {
                return null;

            }
        }

        public static string toDateString(this object value, string format)
        {

            DateTime dateTime = DateTime.MinValue;

            if (!value.isNull())
            {
                if (value is DateTime)
                {
                    dateTime = (DateTime)value;

                }
                else
                {

                    dateTime = value.toDateTime();

                }

                return dateTime.ToString(format);

            }

            return null;


        }

        public static object toDateStringDBNull(this object value, string format)
        {

            DateTime dateTime = DateTime.MinValue;

            if (!value.isNull())
            {
                if (value is DateTime)
                {
                    dateTime = (DateTime)value;

                }
                else
                {

                    dateTime = value.toDateTime();

                }

                return dateTime.ToString(format);

            }

            return DBNull.Value;


        }

        public static TimeSpan toTimeSpan(this object value)
        {
            if (value is string)
            {

                string sValue = value.toStringEmpty();

                sValue = sValue.Replace("-", "");
                sValue = sValue.Replace(":", "");

                if (sValue.Length == 4)
                {
                    return new TimeSpan(System.Convert.ToInt32(sValue.Substring(0, 2)),
                                     System.Convert.ToInt32(sValue.Substring(2, 2)), 0);

                }
                else if (sValue.Length == 6)
                {
                    return new TimeSpan(System.Convert.ToInt32(sValue.Substring(0, 2)),
                                     System.Convert.ToInt32(sValue.Substring(2, 2)),
                                     System.Convert.ToInt32(sValue.Substring(4, 2)));
                }

            }

            else if (value is DateTime)
            {
                return ((DateTime)value).TimeOfDay;
            }


            return TimeSpan.Zero;

        }




        public static object toNull(this object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }






        /// <summary>
        /// 데이터셋의 모든테이블의 행갯수를 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int TablesRowCount(this DataSet value)
        {
            int cnt = 0;

            foreach (DataTable t in value.Tables)
            {
                cnt += t.Rows.Count;
            }


            return cnt;
        }

        public static object toDateTimeDBNull(this object value)
        {
            if (value.isNull() == true)
            {
                return DBNull.Value;
            }
            else
            {
                return value.toDateTime();
            }

        }

        public static DateTime toDateTime(this object value)
        {


            DateTime resultDataTime = DateTime.MinValue;


            if (value is string)
            {

                string dateString = value.toStringEmpty();

                dateString = dateString.Replace("-", "");
                dateString = dateString.Replace(":", "");
                dateString = dateString.Replace("/", "");


                if (dateString.Length == 6)
                {
                    resultDataTime = new DateTime(System.Convert.ToInt32(dateString.Substring(0, 4)),
                                     System.Convert.ToInt32(dateString.Substring(4, 2)), 1);

                }
                else if (dateString.Length == 8)
                {
                    resultDataTime = new DateTime(System.Convert.ToInt32(dateString.Substring(0, 4)),
                                     System.Convert.ToInt32(dateString.Substring(4, 2)),
                                     System.Convert.ToInt32(dateString.Substring(6, 2)));

                }
                else if (dateString.Length == 12)
                {

                    resultDataTime = new DateTime(
                            System.Convert.ToInt32(dateString.Substring(0, 4)),
                            System.Convert.ToInt32(dateString.Substring(4, 2)),
                            System.Convert.ToInt32(dateString.Substring(6, 2)),
                            System.Convert.ToInt32(dateString.Substring(8, 2)),
                            System.Convert.ToInt32(dateString.Substring(10, 2)),
                            0
                            );
                }
                else if (dateString.Length == 14)
                {
                    resultDataTime = new DateTime(
                            System.Convert.ToInt32(dateString.Substring(0, 4)),
                            System.Convert.ToInt32(dateString.Substring(4, 2)),
                            System.Convert.ToInt32(dateString.Substring(6, 2)),
                            System.Convert.ToInt32(dateString.Substring(8, 2)),
                            System.Convert.ToInt32(dateString.Substring(10, 2)),
                            System.Convert.ToInt32(dateString.Substring(12, 2))
                            );
                }
                else if (dateString.Length == 17)
                {
                    resultDataTime = new DateTime(
                    System.Convert.ToInt32(dateString.Substring(0, 4)),
                    System.Convert.ToInt32(dateString.Substring(4, 2)),
                    System.Convert.ToInt32(dateString.Substring(6, 2)),
                    System.Convert.ToInt32(dateString.Substring(8, 2)),
                    System.Convert.ToInt32(dateString.Substring(10, 2)),
                    System.Convert.ToInt32(dateString.Substring(12, 2)),
                    System.Convert.ToInt32(dateString.Substring(14, 3))
                    );
                }
                else
                {
                    resultDataTime = DateTime.MinValue;
                }



            }
            else if (value is DateTime)
            {
                //resultDataTime = System.Convert.ToDateTime(value);

                resultDataTime = (DateTime)value;

            }



            return resultDataTime;
        }





        public static DataTable NewTable(this DataRow value)
        {
            DataTable dt = value.Table.Clone();

            DataRow newRow = dt.NewRow();

            newRow.ItemArray = value.ItemArray;

            dt.Rows.Add(newRow);

            return dt;

        }

        public static DataSet NewDataSet(this DataTable value)
        {
            DataSet newSet = new DataSet();


            newSet.Tables.Add(value);


            return newSet;

        }

        public static DataSet Union(this DataSet value, params DataSet[] addDataSets)
        {
            foreach (DataSet ds in addDataSets)
            {
                if (ds != null)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (!value.Tables.Contains(dt.TableName))
                        {

                            value.Tables.Add(dt.Copy());

                        }
                    }
                }
            }

            return value.Copy();

        }



        public static DataRow NewCopy(this DataRow value)
        {
            DataTable table = value.Table.Clone();

            DataRow newRow = table.NewRow();

            newRow.ItemArray = value.ItemArray;

            table.Rows.Add(newRow);

            return newRow;
        }

        public static string ReplaceEx(this string value, string[] oldValues, string newValue)
        {
            string replaceStr = null;

            replaceStr = value;

            foreach (string oldValue in oldValues)
            {
                replaceStr = replaceStr.Replace(oldValue, newValue);

            }

            return replaceStr;
        }


        public static bool isNullOrEmpty(this object valule)
        {
            if (string.IsNullOrEmpty(valule.toStringNull()))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string toCharDigit(this object value)
        {
            if (value.isNullOrEmpty())
            {
                return null;
            }

            string s = value.ToString();

            string r = null;

            for (int i = 0; i < s.Length; i++)
            {

                if (char.IsDigit(s, i) == true)
                {
                    r += s.Substring(i, 1);

                }
            }

            return r;

        }

        public static bool isNumeric(this object value)
        {
            if (value.isNullOrEmpty())
            {
                return false;
            }

            string s = value.ToString();


            int cnt = 0;

            bool isPoint = false;

            foreach (char c in s)
            {
                if (cnt == 0 && (c == '-' || c == '+'))
                {
                    ++cnt;

                    continue;
                }
                else if (cnt != 0 && (c == '-' || c == '+'))
                {
                    return false;
                }


                if (c == '.' && isPoint == false)
                {
                    isPoint = true;

                    ++cnt;

                    continue;
                }
                else if (c == '.' && isPoint == true)
                {
                    //두번째 포인트가 나오면 숫자형태 아님

                    return false;
                }

                if (!char.IsNumber(c))
                {
                    return false;
                }

                ++cnt;
            }

            return true;

        }

        public static double toDouble(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToDouble(value);
            }
            else
            {
                return 0;
            }


        }
        public static bool toBoolean(this object value)
        {

            if (value is string)
            {
                return System.Convert.ToBoolean(value.toInt());
            }
            else
            {
                return System.Convert.ToBoolean(value);
            }


        }

        public static int toInt(this object value)
        {
            try
            {
                if (value.isNumeric())
                {
                    return System.Convert.ToInt32(value);

                }
                else
                {
                    return 0;

                }
            }
            catch //(Exception ex)
            {
                return 0;
            }
        }


        public static decimal toRate(this object value, object total)
        {
            decimal v = value.toDecimal();

            if (v == 0)
            {
                return 0;
            }
            else
            {
                return (v / total.toDecimal());
            }

        }

        public static byte toByte(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToByte(value);

            }
            else
            {
                return 0;

            }
        }

        public static decimal toDecimal(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToDecimal(value);

            }
            else
            {
                return 0;

            }
        }

        public static string toString(this DataTable values, string columnName, string divStr)
        {

            if (!values.isNull())
            {

                string str = null;



                for (int i = 0; i < values.Rows.Count; i++)
                {
                    if (i != (values.Rows.Count - 1))
                    {
                        str += string.Format("{0}{1}", values.Rows[i][columnName].toStringEmpty(), divStr);
                    }

                    else
                    {
                        str += values.Rows[i][columnName].toStringEmpty();
                    }

                }

                return str;
            }
            else
            {
                return string.Empty;
            }

        }

        public static string toString(this string[] values, string divStr)
        {

            if (!values.isNull())
            {

                string str = null;

                for (int i = 0; i < values.Length; i++)
                {
                    if (i != (values.Length - 1))
                    {
                        str += string.Format("{0}{1}", values[i], divStr);
                    }

                    else
                    {
                        str += values[i];
                    }

                }

                return str;
            }
            else
            {
                return string.Empty;
            }

        }

        public static string toStringEmpty(this object value)
        {

            if (!value.isNull())
            {

                return System.Convert.ToString(value);
            }
            else
            {
                return string.Empty;
            }

        }


        public static string toStringNull(this object value)
        {

            if (!value.isNull())
            {
                return System.Convert.ToString(value);

            }
            else
            {
                return null;

            }
        }

        public static object toDBInt(this object value)
        {
            if (value.isNumeric())
            {
                return System.Convert.ToInt32(value);

            }
            else
            {
                return "null";
            }
        }

        public static object toDBDecimal(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToDecimal(value);

            }
            else
            {
                return 0;

            }
        }

        public static DataTable CreateSchema(string dtName, string[] param, Type[] paramType)
        {

            DataTable dt = new DataTable(dtName);

            foreach (string pr in param)
            {
                dt.Columns.Add(pr, paramType[0]);
            }


            return dt;

        }


        public static decimal toDecimal2(this object value)
        {
            if (value.isNumeric())
            {

                return System.Convert.ToDecimal(value);

            }
            else
            {
                return 0;

            }
        }

        /// <summary>
        /// LINQ 결과를 테이블형태로 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public static DataTable LINQToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }

            return dtReturn;
        }

        public static string GetStringToMD5(string pwd)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, pwd);
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //비밀번호 조합 체크 (알파벳, 숫자, 특수문자
        public static bool VerifyPasswordCheck(string password, out string result, int passLen = 6)
        {

            result = "성공";


            if (passLen > 0 && password.Length < passLen)
            {
                result = string.Format("패스워드는 {0}자리 이상이어야 합니다.", passLen);
                return false;
            }

            //^[0-9a-z]+$  => 숫자 영문
            // /^[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*\.[a-zA-Z]{2,3}$/i => 이메일
            //if (Regex.IsMatch(password, @"[a-zA-Z0-9~`!@#$%^&*()_\-+={}[\]|\\;:'""<>,.?/]") == false)
            if (Regex.IsMatch(password, @"(?=.*\d{1,50})(?=.*[~`!@#$%\^&*()-+=]{1,50})(?=.*[a-zA-Z]{2,50}).{1,50}$") == false)
            {
                result = "패스워드는 영문/숫자/특수문자가 포함 되어야 합니다.";
                return false;
            }



            return true;
        }

    }





}
