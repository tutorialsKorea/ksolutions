using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cubic_Query_Builder
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string strActivePath = @"C:\CubicTek\CubicDevelopHelper";

            string path = Application.StartupPath;

            DirectoryInfo activeDirInfo = new DirectoryInfo(@"C:\CubicTek\CubicDevelopHelper");

            if (activeDirInfo.Exists == false)
            {
                activeDirInfo.Create();
            }


            //개발이면 바로 실행
            bool isDev = false;

            string[] strsPath = path.Split('\\');

            if(strsPath.Length > 0)
            {
                if (strsPath[strsPath.Length - 1] == "Debug" && strsPath[strsPath.Length - 2] == "bin")
                {
                    isDev = true;
                }
            }

            if (strActivePath == path || isDev)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CubicDevelopHelper());
                //Application.Run(new main());

            }
            else
            {
                try
                {
                    string fileName = System.IO.Path.GetFileName(strActivePath + @"\CubicDevelopHelper.exe");
                    string destFile = System.IO.Path.Combine(strActivePath, fileName);

                    System.IO.File.Copy(path + @"\CubicDevelopHelper.exe", destFile, true);

                    System.Diagnostics.Process.Start(destFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이미 실행중입니다.");
                }
            }
        }
    }
}
