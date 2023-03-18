using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ControlManager
{
    public static class RegexEx
    {
        public enum RegexType
        {
            PASSWORD,
            EMAIL,
            TEL,
            URL,
            NUMBER,
            JUMIN
        }

        public static bool CheckRegex(this object source, RegexType type)
        {
            bool bFlg = false;

            if (source is string && !source.isNullOrEmpty())
            {
                switch (type)
                {
                    case RegexType.PASSWORD:
                        bFlg = Regex.IsMatch(source.ToString(), @"[0-9a-zA-Z]{8,16}$");
                        if (!bFlg) break;
                        bFlg = Regex.IsMatch(source.ToString(), @"[a-z]");
                        if (!bFlg) break;
                        bFlg = Regex.IsMatch(source.ToString(), @"[0-9]");
                        break;
                    case RegexType.EMAIL:
                        bFlg = Regex.IsMatch(source.ToString(), @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
                        break;
                    case RegexType.TEL:
                        bFlg = Regex.IsMatch(source.ToString(), @"[0-9]{2,3}-[0-9]{3,4}-[0-9]{4}");
                        break;
                    case RegexType.URL:
                        bFlg = Regex.IsMatch(source.ToString(), @"^https?://([\w-]+\.)+[\w-]+(/[\w-./?&%=]*)?$");
                        break;
                    case RegexType.NUMBER:
                        bFlg = Regex.IsMatch(source.ToString(), @"^\d+$");
                        break;
                    case RegexType.JUMIN:
                        bFlg = Regex.IsMatch(source.ToString(), @"^\d{6}-?[1234]\d{6}$");
                        break;
                    default:
                        break;
                }
            }

            return bFlg;
        }
    }
}
