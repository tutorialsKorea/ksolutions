using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

namespace ControlManager
{
    public class acConvert
    {



        /// <summary>
        /// 파라메터로 받은 값을 십진수로 변환하여 합계를 반환
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static decimal toTotal(params object[] values)
        {
            decimal total = 0;

            foreach (object value in values)
            {
                total += acConvert.toDecimal(value);

            }

            return total;

        }


        /// <summary>
        /// true,false에 따른 객체를 반환합니다.
        /// </summary>
        /// <param name="var">값</param>
        /// <param name="trueObject">true일때 반환할 객체</param>
        /// <param name="falseObject">false일때 반환할 객체</param>
        /// <returns></returns>
        public static object toBooleanObject(bool var, object trueObject, object falseObject)
        {
            if (var == true)
            {
                return trueObject;
            }
            else
            {
                return falseObject;
            }
        }

        /// <summary>
        /// 해당 컬럼으로 그룹화하여 Row 총갯수를 반환합니다.
        /// </summary>
        /// <param name="groupColumns">컬럼명</param>
        /// <param name="destData">테이블</param>
        /// <returns></returns>
        public static int toGroupCount(string[] groupColumns, DataTable destData)
        {

            DataTable srcData = destData.Clone();

            foreach (DataRow destRow in destData.Rows)
            {

                int groupColumnCnt = 0;

                foreach (string groupColumn in groupColumns)
                {

                    foreach (DataRow srcRow in srcData.Rows)
                    {
                        if (destRow[groupColumn].ToString() == srcRow[groupColumn].ToString())
                        {
                            ++groupColumnCnt;
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
        public static object toValue(DataSet dataSet, string tableName, string columnName, int rowIndex)
        {
            try
            {
                return dataSet.Tables[tableName].Rows[rowIndex][columnName];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// decimal 형태로 반환합니다.
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static decimal toDecimal(object pObj)
        {
            try
            {

                return System.Convert.ToDecimal(pObj);

            }
            catch
            {
                return 0;

            }

        }

        public static object toParamRow(object obj)
        {
            if (obj != null)
            {
                if (obj.ToString() == string.Empty)
                {
                    return null;
                }

            }

            return obj;

        }


        /// <summary>
        /// datetime 형태로 반환합니다.
        /// </summary>
        /// <param name="pValue">값</param>
        /// <returns></returns>
        public static object toTableDateTime(object pValue)
        {
            DateTime resultDataTime = DateTime.MinValue;

            try
            {
                if (pValue is string)
                {

                    string value = pValue.ToString();

                    //value = value.Replace("-", "");
                    //value = value.Replace(":", "");

                    if (value.Length == 6)
                    {
                        resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                         System.Convert.ToInt32(value.Substring(4, 2)), 1);

                    }
                    else if (value.Length == 8)
                    {
                        resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                         System.Convert.ToInt32(value.Substring(4, 2)),
                                         System.Convert.ToInt32(value.Substring(6, 2)));

                    }
                    else if (value.Length == 12)
                    {
                        resultDataTime = new DateTime(
                                System.Convert.ToInt32(value.Substring(0, 4)),
                                System.Convert.ToInt32(value.Substring(4, 2)),
                                System.Convert.ToInt32(value.Substring(6, 2)),
                                System.Convert.ToInt32(value.Substring(8, 2)),
                                System.Convert.ToInt32(value.Substring(10, 2)),
                                0
                                );
                    }
                    else if (value.Length == 14)
                    {
                        resultDataTime = new DateTime(
                                System.Convert.ToInt32(value.Substring(0, 4)),
                                System.Convert.ToInt32(value.Substring(4, 2)),
                                System.Convert.ToInt32(value.Substring(6, 2)),
                                System.Convert.ToInt32(value.Substring(8, 2)),
                                System.Convert.ToInt32(value.Substring(10, 2)),
                                System.Convert.ToInt32(value.Substring(12, 2))
                                );
                    }
                    else
                    {

                        return DBNull.Value;
                    }
                }
                else if (pValue is DateTime)
                {
                    return pValue;
                }

                else
                {
                    return DBNull.Value;
                }
            }
            catch
            {

                return DBNull.Value;


            }

            return resultDataTime;

        }



        public static TimeSpan toTimeSpan(object value)
        {

            if (value is string)
            {

                string sValue = value.ToString();

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


        /// <summary>
        /// datetime 형태로 반환합니다.
        /// </summary>
        /// <param name="pValue">값</param>
        /// <returns></returns>
        public static DateTime toDateTime(object pValue)
        {
            DateTime resultDataTime = DateTime.MinValue;

            try
            {
                resultDataTime = System.Convert.ToDateTime(pValue);

            }
            catch
            {

                if (pValue is string)
                {

                    string value = pValue.ToString();

                    value = value.Replace("-", "");
                    value = value.Replace(":", "");


                    if (value.Length == 6)
                    {
                        resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                         System.Convert.ToInt32(value.Substring(4, 2)), 1);

                    }
                    else if (value.Length == 8)
                    {
                        resultDataTime = new DateTime(System.Convert.ToInt32(value.Substring(0, 4)),
                                         System.Convert.ToInt32(value.Substring(4, 2)),
                                         System.Convert.ToInt32(value.Substring(6, 2)));

                    }
                    else if (value.Length == 12)
                    {
                        resultDataTime = new DateTime(
                                System.Convert.ToInt32(value.Substring(0, 4)),
                                System.Convert.ToInt32(value.Substring(4, 2)),
                                System.Convert.ToInt32(value.Substring(6, 2)),
                                System.Convert.ToInt32(value.Substring(8, 2)),
                                System.Convert.ToInt32(value.Substring(10, 2)),
                                0
                                );
                    }
                    else if (value.Length == 14)
                    {
                        resultDataTime = new DateTime(
                                System.Convert.ToInt32(value.Substring(0, 4)),
                                System.Convert.ToInt32(value.Substring(4, 2)),
                                System.Convert.ToInt32(value.Substring(6, 2)),
                                System.Convert.ToInt32(value.Substring(8, 2)),
                                System.Convert.ToInt32(value.Substring(10, 2)),
                                System.Convert.ToInt32(value.Substring(12, 2))
                                );
                    }



                }


            }

            return resultDataTime;

        }

        /// <summary>
        /// double 형태로 반환합니다.
        /// </summary>
        /// <param name="pObj">값</param>
        /// <returns></returns>
        public static double toDouble(object pObj)
        {
            try
            {

                return System.Convert.ToDouble(pObj);

            }
            catch
            {
                return 0;

            }

        }


        /// <summary>
        /// int32 형태로 반환합니다.
        /// </summary>
        /// <param name="pObj">값</param>
        /// <returns></returns>
        public static int toInt(object pObj)
        {
            try
            {

                return System.Convert.ToInt32(pObj);
            }
            catch
            {

                return 0;

            }

        }

        /// <summary>
        /// null일경우 DBNull 값형태로 반환합니다.
        /// </summary>
        /// <param name="pObj">값</param>
        /// <returns></returns>
        public static object toDB(object pObj)
        {
            if (pObj != null)
            {
                return pObj;
            }
            else
            {
                return DBNull.Value;
            }

        }

        public static object toNull(object obj)
        {
            if (obj != null || obj == DBNull.Value)
            {

                if (!string.IsNullOrEmpty(obj.ToString()))
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// string으로 변환하나, null일경우 empty로 반환합니다.
        /// </summary>
        /// <param name="pObj">값</param>
        /// <returns></returns>
        public static string toStringEmpty(object pObj)
        {
            if (pObj != null)
            {
                return pObj.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// string으로 변환하나 null일경우, null로 반환합니다.
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string toStringNull(object pObj)
        {
            if (pObj != null)
            {
                if (!string.IsNullOrEmpty(pObj.ToString()))
                {
                    return pObj.ToString();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 날짜를 string 형태로 반환합니다.
        /// </summary>
        /// <param name="pDateTime">날짜값</param>
        /// <param name="pFormat">형식</param>
        /// <returns></returns>
        public static string toDateString(object pDateTime, string pFormat)
        {
            try
            {
                DateTime dateTime = DateTime.MinValue;

                if (pDateTime != null)
                {
                    if (pDateTime is DateTime)
                    {
                        dateTime = (DateTime)pDateTime;

                    }
                    else
                    {

                        dateTime = System.Convert.ToDateTime(pDateTime);

                    }
                    return dateTime.ToString(pFormat);

                }

                return null;
            }
            catch
            {
                return null;
            }

        }



        public static Image toImage(object obj)
        {
            if (obj != DBNull.Value)
            {
                MemoryStream memSt = new MemoryStream((byte[])obj);

                return Image.FromStream(memSt);

            }

            return null;
        }



        /// <summary>
        /// int32 형태로 반환합니다.
        /// </summary>
        /// <param name="pObj">값</param>
        /// <returns></returns>
        public static int toInt32(object value)
        {
            try
            {

                return System.Convert.ToInt32(value);
            }
            catch
            {

                return 0;

            }

        }



        /// <summary>
        /// DataRow 를 테이블형태로 변환
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static DataTable CreateTable(DataRow row)
        {
            DataTable dt = row.Table.Clone();

            DataRow newRow = dt.NewRow();

            newRow.ItemArray = row.ItemArray;

            dt.Rows.Add(newRow);

            return dt;

        }


        public static Point GetCenterLocation(Rectangle parentRect, Rectangle childRect)
        {
            int x = parentRect.X + (parentRect.Width / 2) - (childRect.Width / 2);

            int y = parentRect.Y + (parentRect.Height / 2) - (childRect.Height / 2);

            return new Point(x, y);
        }



    }
}
