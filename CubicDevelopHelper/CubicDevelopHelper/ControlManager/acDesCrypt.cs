using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ControlManager
{
    public class acDesCrypt
    {
        public static string Encrypt(string str, string key)
        {
            //키 유효성 검사
            byte[] btKey = ConvertStringToByteArrayA(key);

            //키가 8Byte가 아니면 예외발생

            if (btKey.Length != 8)
            {
                throw (new Exception("Invalid key. Key length must be 8 byte."));
            }


            //소스 문자열
            byte[] btSrc = ConvertStringToByteArray(str);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            des.Key = btKey;
            des.IV = btKey;

            ICryptoTransform desencrypt = des.CreateEncryptor();

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, desencrypt,
             CryptoStreamMode.Write);

            cs.Write(btSrc, 0, btSrc.Length);
            cs.FlushFinalBlock();


            byte[] btEncData = ms.ToArray();

            return (ConvertByteArrayToStringB(btEncData));
        }//end of func DesEncrypt

        /// <summary>
        /// 복호화
        /// </summary>
        /// <param name="str">암호화된 문자열</param>
        /// <param name="key">암호화 키</param>
        /// <returns></returns>
        public static string Decrypt(string str, string key)
        {
            //키 유효성 검사
            byte[] btKey = ConvertStringToByteArrayA(key);

            //키가 8Byte가 아니면 예외발생

            if (btKey.Length != 8)
            {
                throw (new Exception("Invalid key. Key length must be 8 byte."));
            }



            byte[] btEncData = ConvertStringToByteArrayB(str);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            des.Key = btKey;
            des.IV = btKey;

            ICryptoTransform desdecrypt = des.CreateDecryptor();

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, desdecrypt,
             CryptoStreamMode.Write);

            cs.Write(btEncData, 0, btEncData.Length);

            cs.FlushFinalBlock();

            byte[] btSrc = ms.ToArray();


            return (ConvertByteArrayToString(btSrc));

        }
        //문자열->유니코드 바이트 배열
        private static Byte[] ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        //유니코드 바이트 배열->문자열
        private static string ConvertByteArrayToString(byte[] b)
        {
            return (new UnicodeEncoding()).GetString(b, 0, b.Length);
        }

        //문자열->안시 바이트 배열
        private static Byte[] ConvertStringToByteArrayA(String s)
        {
            return (new ASCIIEncoding()).GetBytes(s);
        }

        //안시 바이트 배열->문자열
        private static string ConvertByteArrayToStringA(byte[] b)
        {
            return (new ASCIIEncoding()).GetString(b, 0, b.Length);
        }

        //문자열->Base64 바이트 배열
        private static Byte[] ConvertStringToByteArrayB(String s)
        {
            return System.Convert.FromBase64String(s);
        }

        //Base64 바이트 배열->문자열
        private static string ConvertByteArrayToStringB(byte[] b)
        {
            return System.Convert.ToBase64String(b);
        }
    }
}
