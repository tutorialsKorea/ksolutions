using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
using System.Management;
using BizManager;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ControlManager
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// 해당 컬럼으로 그룹화하여 Row 총갯수를 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="groupColumns"></param>
        /// <returns></returns>
        public static int GroupCnt(this DataTable value, string[] groupColumns)
        {

            DataTable srcData = value.Clone();

            foreach (DataRow destRow in value.Rows)
            {

                int groupColumnCnt = 0;

                foreach (string groupColumn in groupColumns)
                {
                    if (srcData.Columns.Contains(groupColumn))
                    {

                        foreach (DataRow srcRow in srcData.Rows)
                        {
                            if (destRow[groupColumn].ToString() == srcRow[groupColumn].ToString())
                            {
                                ++groupColumnCnt;
                            }

                        }
                    }

                }

                if (groupColumnCnt != groupColumns.Length)
                {
                    DataRow srcRow = srcData.NewRow();

                    srcRow.ItemArray = destRow.ItemArray;

                    srcData.Rows.Add(srcRow);
                }

            }

            return srcData.Rows.Count;

        }

        public static DataRow GetRow(this DataTable value, string keyColumnName, object rowValue)
        {

            DataTable srcData = value.Clone();

            foreach (DataRow destRow in value.Rows)
            {
                if (destRow[keyColumnName].EqualsEx(rowValue))
                {
                    return destRow;
                }



            }
            return null;

        }

        /// <summary>
        /// 컬럼의 합계를 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static decimal SUM(this DataTable value, string columnName)
        {

            var sum = value.AsEnumerable().Sum(x => x.Field<decimal>(columnName));

            return sum;

        }


        /// <summary>
        /// 컬럼의 최소값을 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static object MIN(this DataTable value, string columnName)
        {

            var min = value.AsEnumerable().Min(x => x.Field<object>(columnName));

            return min;

        }

        /// <summary>
        /// 컬럼의 최대값을 반환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static object MAX(this DataTable value, string columnName)
        {

            var max = value.AsEnumerable().Max(x => x.Field<object>(columnName));

            return max;

        }

        /// <summary>
        /// 100분 -> 1.4 형태의 H.M 으로 변환한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal toTimeHM(this object value)
        {
            decimal min = value.toDecimal();

            decimal t = Math.Floor(min / 60);

            decimal m = Math.Round((min % 60), 1) / 100;

            return (t + m);

        }

        /// <summary>
        /// 1.4 -> 100분형태로 분으로 변환합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal toTimeMin(this object value)
        {
            double hm = value.toDouble();

            double h = Math.Floor(hm);

            double min = (h * 60) + ((hm - h) * 100);

            return (decimal)min;
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

                        if (!dtReturn.Columns.Contains(pi.Name))
                        {
                            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                        }
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

        /// <summary>
        /// LINQ 결과를 테이블형태로 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public static DataTable LINQToDataTable<T>(this IEnumerable<T> varlist, string name)
        {
            DataTable dtReturn = new DataTable(name);

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
        /// <summary>
        /// 마지막날을 반환합니다.
        /// </summary>
        public static DateTime GetLastDate(this DateTime value)
        {
            DateTime first = value.AddDays(-(value.Day - 1));

            return first.AddDays(DateTime.DaysInMonth(first.Year, first.Month) - 1);
        }




        /// <summary>
        /// 첫날을 반환합니다.
        /// </summary>
        public static DateTime GetFirstDate(this DateTime value)
        {
            return value.AddDays(-(value.Day - 1));
        }

        /// <summary>
        /// DateTime.MaxValue를 넘어가는경우 DateTime.MaxValue를 반환
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddMinutesEx(this DateTime obj, double value)
        {
            double maxMin = DateTime.MaxValue.Subtract(obj).TotalMinutes;

            if (maxMin < value)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return obj.AddMinutes(value);
            }

        }

        /// <summary>
        /// DateTime.MaxValue를 넘어가는경우 DateTime.MaxValue를 반환
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddMillisecondEx(this DateTime obj, double value)
        {
            double maxMin = DateTime.MaxValue.Subtract(obj).TotalMilliseconds;

            if (maxMin < value)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return obj.AddMilliseconds(value);
            }

        }


        /// <summary>
        /// DateTime.MaxValue를 넘어가는경우 DateTime.MaxValue를 반환
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddDaysEx(this DateTime obj, double value)
        {
            double maxMin = DateTime.MaxValue.Subtract(obj).TotalDays;

            if (maxMin < value)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return obj.AddDays(value);
            }

        }


        /// <summary>
        /// 날짜 일자 시작시간
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime toDateTimeStart(this DateTime obj)
        {

            return new DateTime(obj.Year, obj.Month, obj.Day, 0, 0, 0);
        }

        /// <summary>
        /// 날짜 일자 마지막시간
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime toDateTimeEnd(this DateTime obj)
        {

            return new DateTime(obj.Year, obj.Month, obj.Day, 23, 59, 59);
        }


        public static decimal toPercent(this object value, int decimals)
        {

            decimal v = value.toDecimal();

            decimal percent = Math.Round((v * 100), decimals);

            return percent;



        }

        public static bool EqualsOrEx(this object objA, params object[] objB)
        {


            foreach (object o in objB)
            {
                if (objA.isNull() == false)
                {
                    object convertObj = Convert.ChangeType(o, objA.GetType());

                    if (object.Equals(objA, convertObj))
                    {
                        return true;
                    }
                }
                else
                {

                    if (object.Equals(objA, o))
                    {
                        return true;
                    }
                }

            }

            return false;

        }

        public static bool EqualsEx(this object objA, object objB)
        {
            if (objA.isNull() == false)
            {
                object convertObj = Convert.ChangeType(objB, objA.GetType());

                return object.Equals(objA, convertObj);

            }
            else
            {
                return object.Equals(objA, objB);
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
                try
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
                    else if (dateString.Length == 18)
                    {
                        resultDataTime = System.Convert.ToDateTime(value);
                    }
                    else
                    {
                        resultDataTime = DateTime.MinValue;
                    }

                }
                catch
                {
                    return DateTime.Parse(value.ToString());
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

        public static string GetStringByMaskScript(this string value)
        {

            string pattern = value.toStringNull();
                 
            Regex regx = new Regex(@"(%&[A-Z]\([A-Z0-9_,]+\)%)");

            MatchCollection patternMatchs = regx.Matches(pattern);

            foreach (Match m in patternMatchs)
            {

                Regex sysTypeRegx = new Regex(@"&[A-Z]");

                MatchCollection sysTypeMatchs = sysTypeRegx.Matches(m.Value);


                if (sysTypeMatchs[0].Value == "&S")
                {
                    //표준코드
                    Regex stdCodeRegx = new Regex(@"\(.+\,.+\)");

                    MatchCollection stdCodeMatchs = stdCodeRegx.Matches(m.Value);

                    string codesTemp = stdCodeMatchs[0].Value.ReplaceEx(new string[] { "(", ")" }, string.Empty);

                    string[] codes = codesTemp.Split(',');

                    string codeName = acInfo.StdCodes.GetNameByCode(codes[0], codes[1]);

                    pattern = pattern.Replace(m.Value, codeName);

                }
                else if (sysTypeMatchs[0].Value == "&R")
                {
                    //리소스

                    Regex resRegx = new Regex(@"\(.+\)");

                    MatchCollection resMatchs = resRegx.Matches(m.Value);

                    string resID = resMatchs[0].Value.ReplaceEx(new string[] { "(", ")" }, string.Empty);

                    pattern = pattern.Replace(m.Value, acInfo.Resource.GetString(m.Value, resID));

                }



            }

            pattern = pattern.Replace(@"\r\n", System.Environment.NewLine);

            return pattern;



        }


        public static string GetStringByMaskScript(this DataRow row, string pattern)
        {

            if (pattern == null) return "";

            Regex regx = new Regex(@"(%&[A-Z]\([A-Z0-9_,]+\)%)|(%[a-zA-Z0-9_]+#[A-Z]{1}\([^()]+\)%)|(%[a-zA-Z0-9_]+%)");

            MatchCollection patternMatchs = regx.Matches(pattern);

            foreach (Match m in patternMatchs)
            {
                string colName = m.Value.Replace("%", string.Empty);

                Regex maskRegx = new Regex(@"[a-zA-Z0-9]+#[A-Z]{1}\([^()]+\)");

                MatchCollection maskMatchs = maskRegx.Matches(colName);

                if (maskMatchs.Count == 0)
                {
                    //마스크 없음

                    Regex sysTypeRegx = new Regex(@"&[A-Z]");

                    MatchCollection sysTypeMatchs = sysTypeRegx.Matches(colName);

                    if (sysTypeMatchs.Count == 0)
                    {
                        if (row.Table.Columns.Contains(colName))
                        {
                            pattern = pattern.Replace(m.Value, row[colName].ToString());
                        }
                    }
                    else
                    {

                        if (sysTypeMatchs[0].Value == "&S")
                        {
                            //표준코드
                            Regex stdCodeRegx = new Regex(@"\(.+\,.+\)");

                            MatchCollection stdCodeMatchs = stdCodeRegx.Matches(colName);

                            string codesTemp = stdCodeMatchs[0].Value.ReplaceEx(new string[] { "(", ")" }, string.Empty);

                            string[] codes = codesTemp.Split(',');

                            string codeName = acInfo.StdCodes.GetNameByCode(codes[0], codes[1]);

                            pattern = pattern.Replace(m.Value, codeName);

                        }
                        else if (sysTypeMatchs[0].Value == "&R")
                        {
                            //리소스

                            Regex resRegx = new Regex(@"\(.+\)");

                            MatchCollection resMatchs = resRegx.Matches(colName);

                            string resID = resMatchs[0].Value.ReplaceEx(new string[] { "(", ")" }, string.Empty);

                            pattern = pattern.Replace(m.Value, acInfo.Resource.GetString(m.Value, resID));

                        }

                    }
                }
                else
                {
                    //마스크 존재

                    Regex colRegx = new Regex(@"[a-zA-Z0-9_]+");

                    MatchCollection colMatchs = colRegx.Matches(maskMatchs[0].Value);


                    if (row.Table.Columns.Contains(colMatchs[0].Value))
                    {
                        Regex maskTypeRegx = new Regex(@"#[A-Z]{1}");

                        MatchCollection maskTypeMatchs = maskTypeRegx.Matches(maskMatchs[0].Value);

                        Regex maskStringRegx = new Regex(@"\([^()]+\)");

                        MatchCollection maskStringMatchs = maskStringRegx.Matches(m.Value);

                        if (maskTypeMatchs[0].Value == "#D")
                        {
                            //날짜형 마스트

                            string maskString = maskStringMatchs[0].Value.Replace("(", string.Empty);

                            maskString = maskString.Replace(")", string.Empty);

                            pattern = pattern.Replace(m.Value, row[colMatchs[0].Value].toDateString(maskString));


                        }
                        else if (maskTypeMatchs[0].Value == "#N")
                        {
                            //숫자형 마스트

                            string maskString = maskStringMatchs[0].Value.Replace("(", string.Empty);

                            maskString = maskString.Replace(")", string.Empty);

                            pattern = pattern.Replace(m.Value, string.Format("{0:" + maskString + "}", row[colMatchs[0].Value].toDecimal()));


                        }
                        else if (maskTypeMatchs[0].Value == "#S")
                        {
                            //SUBSTRING

                            string maskString = maskStringMatchs[0].Value.Replace("(", string.Empty);

                            maskString = maskString.Replace(")", string.Empty);

                            List<string> idxs = new List<string>(maskString.Split(','));

                            if (idxs.Count > 0)
                            {
                                if (idxs[1] == "END")
                                {
                                    idxs[1] = (row[colMatchs[0].Value].ToString().Length - idxs[0].toInt()).ToString();
                                }

                                int r = idxs[0].toInt() + idxs[1].toInt();

                                if (r != 0)
                                {
                                    pattern = pattern.Replace(m.Value, row[colMatchs[0].Value].ToString().Substring(idxs[0].toInt(), idxs[1].toInt()));
                                }
                                else
                                {
                                    pattern = pattern.Replace(m.Value, string.Empty);
                                }


                            }

                        }
                    }

                }
            }

            pattern = pattern.Replace(@"\r\n", System.Environment.NewLine);

            return pattern;



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




        public static Image toImage(this object value)
        {

            if (value is Byte[])
            {

                MemoryStream memSt = new MemoryStream((byte[])value);

                return Image.FromStream(memSt);
            }

            
            return null;
        }

        //public static Brush toBrush(this object value)
        //{
        //    if (value.isNull() == false)
        //    {
        //        if (value is Brush)
        //        {
        //            return (Brush)value;
        //        }
        //        else
        //        {
        //            return Brush.  Color.FromArgb(value.toInt());
        //        }
        //    }
        //    else
        //    {
        //        return 
        //    }
        //}

        public static Color toColor(this object value)
        {
            if (value.isNull() == false)
            {
                if (value is Color)
                {
                    return (Color)value;
                }
                else
                {
                    return Color.FromArgb(value.toInt());
                }
            }
            else
            {
                return Color.Transparent;
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

        public static string toCharSting(this object value)
        {
            if (value.isNullOrEmpty())
            {
                return null;
            }

            string s = value.ToString();

            string r = null;

            for (int i = 0; i < s.Length; i++)
            {

                if (char.IsLetter(s, i) == true)
                {
                    r += s.Substring(i, 1);

                }
            }

            return r;

        }

        public static bool isNumeric2(this object value)
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
                //if (cnt == 0 && (c == '-' || c == '+'))
                //{
                //    //++cnt;

                //    //continue;
                //}
                //else 
                if (cnt != 0 && (c == '-' || c == '+'))
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
            try
            {
                if (value is string)
                {
                    return System.Convert.ToBoolean(value.toInt());
                }
                else
                {
                    return System.Convert.ToBoolean(value);
                }
            }catch
            {
                return false;
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
            catch (Exception ex)
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

        public static string toDBString(this object value)
        {
            string val = "'" + value.ToString() + "'";

            return val;
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

        private static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }


        // 해당일자의 주수를 가져오는 방법:
        public static string GetJuCha(DateTime Date)
        {

            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("ko-KR");

            return myCI.Calendar.GetWeekOfYear

            (Date, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday).ToString();


        }

        // 해당일자의 주수를 가져오는 방법:
        public static string GetJuCha2(DateTime Date)
        {
            return GetWeekOfYear(Date, null).ToString();
        }

        /// <summary>
        /// 연도 주차 구하기
        /// </summary>
        /// <param name="sourceDate">소스 일자</param>
        /// <param name="cultureInfo">문화 정보</param>
        /// <returns>연도 주차</returns>
        public static int GetWeekOfYear(DateTime sourceDate, CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }


            //CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek + 1;
            return cultureInfo.Calendar.GetWeekOfYear(sourceDate, calendarWeekRule, firstDayOfWeek);
        }

        //해당일자의 월요일에서 금요일 가져오기
        public static void GetJuStartEndDate(DateTime date, out DateTime sDate, out DateTime eDate)
        {
            DateTime dtToday = date;

            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwToday = ciCurrent.Calendar.GetDayOfWeek(dtToday);

            int iDiff = dwToday - dwFirst;
            DateTime dtFirstDayOfThisWeek = dtToday.AddDays(-iDiff + 1);
            DateTime dtLastDayOfThisWeek = dtFirstDayOfThisWeek.AddDays(4);

            sDate = dtFirstDayOfThisWeek;
            eDate = dtLastDayOfThisWeek;
        }

        //해당일자의 월요일에서 일요일 가져오기
        public static void GetJuFullStartEndDate(DateTime date, out DateTime sDate, out DateTime eDate)
        {
            DateTime dtToday = date;

            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwToday = ciCurrent.Calendar.GetDayOfWeek(dtToday);

            int iDiff = dwToday - dwFirst - 1;

            if (iDiff < 0)
            {
                iDiff = 6;
            }

            DateTime dtFirstDayOfThisWeek = dtToday.AddDays(-iDiff);
            DateTime dtLastDayOfThisWeek = dtFirstDayOfThisWeek.AddDays(6);

            sDate = dtFirstDayOfThisWeek;
            eDate = dtLastDayOfThisWeek;
        }

        public static void SendBarcode(DataRow row,string zplCode)
        {
            try
            { 
                bool isVar = false;

                string strTempVar = "";

                string strTempZPLString = zplCode;

                foreach (char c in strTempZPLString)
                {
                    if (c == '@')
                    {
                        isVar = true;
                    }
                    else if (isVar == true && c == '^')
                    {
                        isVar = false;

                        try
                        {
                            if (strTempVar.Contains("DATE"))
                            {
                                zplCode = zplCode.Replace(strTempVar, row[strTempVar.Replace("@", "")].toDateString("yyyy-MM-dd"));
                            }
                            else
                            {
                                zplCode = zplCode.Replace(strTempVar, row[strTempVar.Replace("@", "")].ToString());
                            }

                        }
                        catch
                        {
                            zplCode = zplCode.Replace(strTempVar, "");
                        }

                        strTempVar = "";
                    }

                    if (isVar == true)
                    {
                        strTempVar += c;
                    }
                }

                string print_type = "0";

                try
                {
                    print_type = acInfo.SysConfig.GetSysConfigByServer("BARCODE_PRINT_TYPE").ToString();
                }
                catch {
                    print_type = "0";
                }

                if (print_type == "0")
                {
                    SendUsbBarcode(zplCode);
                }
                else
                {
                    SendTcpBarcode(zplCode);
                }
            }
            catch
            {

            }

        }

        private static void SendTcpBarcode(String ZPLString)
        {
            // Printer IP Address and communication port
            string ipAddress = acInfo.SysConfig.GetSysConfigByServer("BARCODE_PRINT_IP").ToString();
            int port = acInfo.SysConfig.GetSysConfigByServer("BARCODE_PRINT_PORT").toInt();

            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);

                if (!client.Connected)
                {
                    acMessageBox.Show("네트워크 바코드(제브라) 프린터를 찾을수 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    client.Close();
                    return;
                }

                // Write ZPL String to connection
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                // Catch Exception
            }
        }

        public static void SendUsbBarcode(String ZPLString)
        {
            try
            {

                var enumDevices = Zebra.Printing.UsbPrinterConnector.EnumDevices();

                if (enumDevices.Keys.Count < 1)
                {
                    acMessageBox.Show("바코드(제브라) 프린터를 찾을수 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                string key = enumDevices.Keys[0];

                Zebra.Printing.UsbPrinterConnector usbPrint = new Zebra.Printing.UsbPrinterConnector(key);


                byte[] buffer = Encoding.UTF8.GetBytes(ZPLString); // ASCIIEncoding.ASCII.GetBytes(ZPLString);
                //byte[] buffer = ASCIIEncoding.ASCII.GetBytes(ZPLString);  
                usbPrint.IsConnected = true;
                usbPrint.Send(buffer);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void SendPutBarcode(string barcodeTxt, string put_date, string strWeight, string partName, string origin, string exp_date, string history_no)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("^Q100,3");
                sb.AppendLine("^W100");
                sb.AppendLine("^H10");
                sb.AppendLine("^P1");
                sb.AppendLine("^S2");
                sb.AppendLine("^AD");
                sb.AppendLine("^C1");
                sb.AppendLine("^R0");
                sb.AppendLine("~Q+0");
                sb.AppendLine("^O0");
                sb.AppendLine("^D0");
                sb.AppendLine("^E35");
                sb.AppendLine("~R200");
                sb.AppendLine("^L");
                sb.AppendLine("Dy2-me-dd");
                sb.AppendLine("Th:m:s");
                sb.AppendLine("R14,6,786,788,1,1");
                sb.AppendLine("Lo,18,240,787,240");
                sb.AppendLine("BA,44,630,3,10,100,0,1," + barcodeTxt);
                sb.AppendLine("Lo,1334,318,1335,319");
                sb.AppendLine("AF,246,16,1,1,0,0," + put_date);
                sb.AppendLine("AF,216,92,1,1,0,0," + barcodeTxt);
                sb.AppendLine("AG,241,505,1,1,0,0," + strWeight);
                sb.AppendLine("Lo,14,160,783,160");
                sb.AppendLine("AZ,40,172,2,2,0,0,품  명");
                sb.AppendLine("Lo,10,80,782,80");
                sb.AppendLine("AZ,241,253,2,2,0,0," + origin);
                sb.AppendLine("AF,243,331,1,1,0,0," + exp_date);
                sb.AppendLine("AZ,36,253,2,2,0,0,원산지");
                sb.AppendLine("AZ,20,333,2,2,0,0,유통기한");
                sb.AppendLine("AZ,20,422,2,2,0,0,이력번호");
                sb.AppendLine("AZ,37,528,2,2,0,0,중  량");
                sb.AppendLine("AF,243,415,1,1,0,0," + history_no);
                sb.AppendLine("Lo,18,606,787,606");
                sb.AppendLine("Lo,16,494,785,494");
                sb.AppendLine("Lo,18,398,787,398");
                sb.AppendLine("Lo,16,318,785,318");
                sb.AppendLine("Lo,219,160,220,607");
                sb.AppendLine("W622,500,2,1,M,8,5,12,0");
                sb.AppendLine(barcodeTxt);
                sb.AppendLine("AZ,239,174,2,2,0,0," + partName);
                sb.AppendLine("E");
                

                var enumDevices = Zebra.Printing.UsbPrinterConnector.EnumDevices("BP-DT-4");

                if (enumDevices.Keys.Count < 1)
                {
                    acMessageBox.Show("바코드(BP-DT-4) 프린터를 찾을수 없습니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                string key = enumDevices.Keys[0];

                Zebra.Printing.UsbPrinterConnector usbPrint = new Zebra.Printing.UsbPrinterConnector(key);

                //byte[] buffer = Encoding.UTF8.GetBytes(ZPLString); 
                byte[] buffer = Encoding.GetEncoding("ks_c_5601-1987").GetBytes(sb.ToString());

                usbPrint.IsConnected = true;
                usbPrint.Send(buffer);

                usbPrint.IsConnected = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetProcList(object sender)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("IS_DISP2", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["IS_DISP2"] = "0";

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataTable dtProc = BizRun.QBizRun.ExecuteService(sender,"COMMON", "COMMON_PROC", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            return dtProc;
        }
        public static string GetSerialNo(object sender,string sr_code)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("SR_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["SR_CODE"] = sr_code;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);            

            return BizRun.QBizRun.ExecuteService(sender, "COMMON", "COMMON_GET_SERIAL", paramSet, "RQSTDT", "RSLTDT").Tables["RQSTDT"].Rows[0]["SR_NO"].ToString();
        }


        public static Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    //if (p.R == 0 && p.G == 0 && p.B == 0)
                    bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }


        /// <summary>
        /// 약속된 데이터로 기본 파람 데이터셋을 만들어 준다.
        /// 코드 간소화 
        /// PLT_CODE 는 기본으로 만들어준다.
        /// 기본적으로 모든 컬럼 타입은 string 으로 넘긴다.
        /// </summary>
        /// <param name="data">ex) CVND_CODE:1220,PART_CODE:2222,.....</param>
        /// <returns></returns>
        public static DataSet GetCubizParam(string data,string tableName = "RQSTDT")
        {
            try
            {                

                DataTable dataTable = new DataTable(tableName);
                dataTable.Columns.Add("PLT_CODE", typeof(string));
                DataRow dataRow = dataTable.NewRow();
                dataRow["PLT_CODE"] = acInfo.PLT_CODE;

                string[] p = data.Split(',');
                
                foreach(string s in p)
                {
                    string[] v = s.Split(':');

                    dataTable.Columns.Add(v[0], typeof(string));
                    dataRow[v[0]] = v[1];
                }
                dataTable.Rows.Add(dataRow);

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(dataTable);

                return dataSet;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }

    public class IFModule
    {
        private string gDrive = string.Empty;

        /// <summary>
        /// 네트워크 연결 구조체 선언
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }


        /// <summary>
        /// 네트워크 연결
        /// </summary>
        /// <returns></returns>
        [DllImport("mpr.dll", CharSet = CharSet.Ansi)]
        public static extern int WNetUseConnection(
                    IntPtr hwndOwner,
                    [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE lpNetResource,
                    string lpPassword,
                    string lpUserID,
                    uint dwFlags,
                    StringBuilder lpAccessName,
                    ref int lpBufferSize,
                    out uint lpResult);


        /// <summary>
        /// 네트워크 연결해제
        /// </summary>
        [DllImport("mpr.dll", CharSet = CharSet.Ansi)]
        public static extern int WNetCancelConnection2(
                    string lpName,
                    uint dwFlags,
                    bool fForce);


        /// <summary>
        /// 네트워크 연결
        /// </summary>
        /// <param name="NetNm">네트워크 경로</param>
        /// <param name="UserId">아이디</param>
        /// <param name="Password">비밀번호</param>
        /// <param name="Drive">드라이브 경로</param>
        public int NetWorkAccess(string netNm, string userId, string passWord)
        {
            try
            {
                int capacity = 64;
                uint resultFlags = 0;
                uint flags = 0;
                System.Text.StringBuilder sb = new System.Text.StringBuilder(capacity);
                NETRESOURCE ns = new NETRESOURCE();
                ns.dwType = 1;
                ns.lpLocalName = null;
                ns.lpRemoteName = netNm;
                ns.lpProvider = null;

                int result = WNetUseConnection(IntPtr.Zero, ref ns, passWord, userId, flags,
                                                sb, ref capacity, out resultFlags);

                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 네트워크 연결
        /// </summary>
        /// <param name="NetNm">네트워크 경로</param>
        /// <param name="UserId">아이디</param>
        /// <param name="Password">비밀번호</param>
        /// <param name="Drive">드라이브 경로</param>
        public int NetWorkAccess()
        {
            try
            {
                int capacity = 64;
                uint resultFlags = 0;
                uint flags = 0;
                System.Text.StringBuilder sb = new System.Text.StringBuilder(capacity);
                NETRESOURCE ns = new NETRESOURCE();
                ns.dwType = 1;
                ns.lpLocalName = null;
                ns.lpRemoteName = _netNm;
                ns.lpProvider = null;

                int result = WNetUseConnection(IntPtr.Zero, ref ns, _passWord, _userId, flags,
                                                sb, ref capacity, out resultFlags);

                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IFModule()
        {
            //dbinsert = new DBInsert();
        }

        string _netNm = string.Empty, _passWord = string.Empty, _userId = string.Empty;

        public IFModule(string netWorkName, string id, string pass)
        {
            _netNm = netWorkName;
            _userId = id;
            _passWord = pass;
        }

        /// <summary>
        ///  네크워크 연결해제
        /// </summary>
        /// <param name="Drive">드라이브 경로</param>
        /// <returns></returns>
        public int NetWorkDeleteAccess(string netnm)
        {
            try
            {
                //string lpname = drive;
                uint flag = 0;
                bool force = true;
                int result = WNetCancelConnection2(netnm, flag, force);

                return result;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }

}
