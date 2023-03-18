using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ControlManager
{
    public class acFile
    {

        public static byte[] GetByteFromFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();


            return data;


        }

    }
}
