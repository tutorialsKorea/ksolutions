using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Zebra.Printing
{
    public class SendBarcode
    {
        public static void SendUsbBarcode(String ZPLString)
        {

            //ZPLString = ZPLStr(ZPLString, row);

            var enumDevices = Zebra.Printing.UsbPrinterConnector.EnumDevices();

            if (enumDevices.Keys.Count < 1)
            {
                return;
            }

            string key = enumDevices.Keys[0];

            Zebra.Printing.UsbPrinterConnector usbPrint = new Zebra.Printing.UsbPrinterConnector(key);

            byte[] buffer = Encoding.UTF8.GetBytes(ZPLString); // ASCIIEncoding.ASCII.GetBytes(ZPLString);
            usbPrint.IsConnected = true;
            usbPrint.Send(buffer);

            usbPrint.IsConnected = false;

        }

        public static void SendTcpBarcode(String ZPLString, String IP, int Port, DataRow row)
        {
            // Printer IP Address and communication port
            string ipAddress = IP;
            int port = Port;

            ZPLString = ZPLStr(ZPLString, row);

            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);

                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
            }
            catch //(Exception ex)
            {
                // Catch Exception
            }
        }

        public static void SendSerialBarcode(String ZPLString, DataRow row)
        {
            try
            {
                ZPLString = ZPLStr(ZPLString, row);


            }
            catch
            {

            }
        }

        private static String ZPLStr(String ZPLStr, DataRow rw)
        {
            bool isVar = false;

            string strTempVar = "";

            string strTempZPLString = ZPLStr;

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
                        ZPLStr = ZPLStr.Replace(strTempVar, rw[strTempVar.Replace("@", "")].ToString());
                    }
                    catch
                    {
                        ZPLStr = ZPLStr.Replace(strTempVar, "");
                    }

                    strTempVar = "";
                }

                if (isVar == true)
                {
                    strTempVar += c;
                }
            }

            return ZPLStr;
        }
    }
}
