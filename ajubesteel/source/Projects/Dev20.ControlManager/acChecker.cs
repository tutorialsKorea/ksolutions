using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
    public class acChecker
    {

        /// <summary>
        /// null, DBNull,empty 여부를 판단하여 반환한다. null일경우 true 반환
        /// </summary>
        /// <param name="vaules"></param>
        /// <returns></returns>
        public static bool isNull(params object[] vaules)
        {
            foreach (object vaule in vaules)
            {
                if (vaule is string)
                {
                    if (string.IsNullOrEmpty(vaule.ToString()))
                    {
                        return true;
                    }

                }
                else if (vaule is DateTime)
                {
                    if (vaule.Equals(DateTime.MinValue))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else
                {
                    if (vaule == DBNull.Value)
                    {
                        return true;
                    }
                    else if (vaule == null)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public static bool isValue(object target, params object[] vaules)
        {

            try
            {

                Type targetType = target.GetType();

                foreach (object value in vaules)
                {
                    object convertValue = Convert.ChangeType(value, targetType);

                    if (target.EqualsEx(convertValue))
                    {
                        return true;
                    }

                }

            }
            catch
            {
                return false;
            }

            return false;

        }


        public static bool IsNumeric(string s)
        {
            try
            {
                Int32.Parse(s);
            }
            catch
            {
                return false;

            }

            return true;
        }


        public static bool isDate(params object[] vaules)
        {
            foreach (object value in vaules)
            {
                if (value is string)
                {
                    string v = value.toStringEmpty();

                    if (v.Length < 8)
                    {
                        return false;
                    }
                }

            }

            return true;

        }




    }
}
