using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Management;

namespace ControlManager
{
    public class acNetWork
    {

        public static string GetMacAddress()
        {
            try
            {
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'");

                ManagementObjectCollection queryCol = query.Get();

                foreach (ManagementObject mo in queryCol)
                {
                    return (string)mo["MACAddress"];
                }

                return null;

            }
            catch
            {
                return null;
            }

        }

        public static string GetLanIPAddress()
        {
            IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in entry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();

                }
            }

            return null;

        }

        public static string GetWanIPAddress()
        {
            try
            {

                string whatIsMyIp = "http://211.238.138.160:7862/ActiveShop/ServerVariables.aspx";

                WebClient wc = new WebClient();

                UTF8Encoding utf8 = new UTF8Encoding();

                string requestHtml = utf8.GetString(wc.DownloadData(whatIsMyIp));


                Regex maskStringRegx = new Regex(@"REMOTE_HOST\[\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\]");

                MatchCollection maskStringMatchs = maskStringRegx.Matches(requestHtml);


                string outIpAddress = null;

                if (maskStringMatchs.Count > 0)
                {


                    int ipIdx = maskStringMatchs[0].Value.IndexOf("[");
                    int endIdx = maskStringMatchs[0].Value.IndexOf("]");

                    outIpAddress = maskStringMatchs[0].Value.Substring(ipIdx + 1, (endIdx - ipIdx) - 1);



                }

                return outIpAddress;

            }
            catch
            {
                return null;
            }

        }

    }
}
