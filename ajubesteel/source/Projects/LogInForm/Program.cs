using System;
using System.Windows.Forms;

using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace LogInForm
{
    static class Program
    {

        public static ApplicationContext ac = new ApplicationContext();
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {


            string serverIP = Properties.Settings.Default.SERVER_IP;

            string databaseName = Properties.Settings.Default.DATABASE_NAME;

            string plant = Properties.Settings.Default.PLANT;

            string lang = Properties.Settings.Default.LANG;

            string userID = Properties.Settings.Default.USER_ID;

            string skin = Properties.Settings.Default.SKIN;

            //string menu = "";

            string is_dev = Properties.Settings.Default.DEV;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            string formName = "LogInForm." + Properties.Settings.Default.LOGINFORM_NAME;
            var varPageType = Type.GetType(formName);
            var varFormInstance = Activator.CreateInstance(varPageType) as XtraForm;

            ac.MainForm = varFormInstance;

            //LogInForm_V2 startFrom = new LogInForm_V2();
            //ac.MainForm = startFrom;
            //if (is_dev == "1")
            //    Application.Run(new MainForm(serverIP, databaseName, plant, lang, userID, skin, menu));
            //else
            Application.Run(ac);


        }
    }
}
