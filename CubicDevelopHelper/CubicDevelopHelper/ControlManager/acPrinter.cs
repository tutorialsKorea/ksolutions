using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;

namespace ControlManager
{
    public class acPrinter
    {

        public static bool IsPrinterName(string printerName)
        {
            IntPtr pHandle = IntPtr.Zero;

            WIN32API.OpenPrinter(printerName, out pHandle, IntPtr.Zero);

            uint cbNeeded = 0;


            bool bRet = WIN32API.GetPrinter(pHandle, 2, IntPtr.Zero, 0, ref cbNeeded);

            if (cbNeeded > 0)
            {
                return true;
            }

            return false;

        }

        private static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount, ref Int32 dwError)
        {
            Int32 dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            WIN32API.DOCINFOA di = new WIN32API.DOCINFOA();
            bool bSuccess = false;

            // Assume failure unless you specifically succeed.     

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.     
            if (WIN32API.OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.       
                if (WIN32API.StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.         
                    if (WIN32API.StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.           
                        bSuccess = WIN32API.WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        WIN32API.EndPagePrinter(hPrinter);
                    }

                    WIN32API.EndDocPrinter(hPrinter);
                }

                WIN32API.ClosePrinter(hPrinter);

            }

            // If you did not succeed, GetLastError may give more information     
            // about why not.    

            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();

            }

            return bSuccess;

        }

        private static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            Int32 dwError = 0;

            // Open the file.     
            FileStream fs = new FileStream(szFileName, FileMode.Open);

            // Create a BinaryReader on the file.     

            BinaryReader br = new BinaryReader(fs);

            // Dim an array of bytes big enough to hold the file's contents.     

            Byte[] bytes = new Byte[fs.Length];

            bool bSuccess = false;

            // Your unmanaged pointer.     

            IntPtr pUnmanagedBytes = new IntPtr(0);

            int nLength;
            nLength = Convert.ToInt32(fs.Length);

            // Read the contents of the file into the array.     

            bytes = br.ReadBytes(nLength);

            // Allocate some unmanaged memory for those bytes.     

            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);

            // Copy the managed byte array into the unmanaged array.     

            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);

            // Send the unmanaged bytes to the printer.     

            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength, ref dwError);

            // Free the unmanaged memory that you allocated earlier.     

            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        public static void SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes = IntPtr.Zero;
            Int32 dwCount;
            Int32 dwError = 0;

            try
            {
                // How many characters are in the string?     
                // Fix from Nicholas Piasecki:     // 

                dwCount = szString.Length;
                dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;

                // Assume that the printer is expecting ANSI text, and then convert     
                // the string to ANSI text.     
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);

                // Send the converted ANSI string to the printer.     

                bool result = SendBytesToPrinter(szPrinterName, pBytes, dwCount, ref dwError);

                if (result == false)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                }


            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                Marshal.FreeCoTaskMem(pBytes);
            }

        }

    }
}
