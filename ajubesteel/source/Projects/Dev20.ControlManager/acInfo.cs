using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;

namespace ControlManager
{
    public class acInfo
    {


        /// <summary>
        /// 패키지 에디션
        /// </summary>
        public enum emPackageEditionType
        {

            //알수없음
            Unknown,

            /// <summary>
            /// 스탠다드 에디션
            /// </summary>
            Standard,

            /// <summary>
            /// 프로페셔럴 에디션
            /// </summary>
            Professional

        };

        public enum AppType
        {
            Unknown, 

            DEV,

            TEST,

            LIVE
        }

        private static DataSet _refData = null;

        public static DataSet RefData
        {
            get
            {
                DataTable dt = new DataTable("RQSTDT");
                dt.Columns.Add("PLT_CODE", typeof(string));
                DataRow newRow = dt.NewRow();
                newRow["PLT_CODE"] = acInfo.PLT_CODE;
                dt.Rows.Add(newRow);
                _refData = new DataSet();
                _refData.Tables.Add(dt);
                return _refData;
            }
        }
        public static string ApiUrl = "";

        public static string SystemName = "Proactive MES";

        public static string MenuLocation = "V";

        public static emPackageEditionType PackageType = emPackageEditionType.Standard; 

        public static string Version = "";

        public static string DefaultConfigName = "@DEFAULT";

        public static string DefaultConfigUser = "@SYSTEM";

        public static string DefaultDirectory = @"C:\Cubictek";

        public static string ASSY_PART = "ASSEMBLY";

        public static string ASSY_PROC = "ASSY";

        public static string DEFAULT_STK = "0";

        public static string INIT_PWD = "1";

        public static Font DefaultFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        public static string PLT_CODE = null;

        public static string BuildVersion = null;

        public static string PLT_NAME = null;

        public static string Lang = null;

        public static string UserID = null;

        public static string UserName = null;

        public static string EmailAddr = null;

        public static string UserPhone = null;

        public static string UserORG = null;

        public static string UserORG_Name = null;

        public static string UserGROUP = null;

        public static string UserField = null;

        public static string UserFieldName = null;

        public static string LineNO = null;

        public static string LineName = null;

        public static string PK_LineNO = null;

        public static string PK_LineName = null;


        public static bool IsSystemUser = false;

        public static string ServerIp = null;

        public static string DB_ID = null;

        public static string DB_PW = null;

        public static string DatabaseID = null;

        public static string DatabasePW = null;

        public static string DatabaseName = null;

        public static string ServerPort = null;

        public static string ServerNum = null;

        public static string Skin = null;

        public static string MenuClassName = null;

        public static string IsPopMenu = null;

        public static bool ReleaseMode = true;

        public static Color TransparentBackColor = Color.Transparent;

        public static Color StandardBackColor = Color.White;

        public static Color StandardForeColor = Color.Black;

        public static Color ReadOnlyBackColor = Color.WhiteSmoke;

        public static Color ReadOnlyForeColor = Color.Black;

        public static Color RequiredBackColor = Color.LightGoldenrodYellow;

        public static Color RequiredForeColor = Color.Black;

        public static int ApplicationCnt = 0;

        public static BizManager.QBiz QBiz = null;

        //public static BizManager.QBizRun QBizRun = null;

        public static bool IsRunTime = false;

        public static acResource Resource = null;

        public static acSysConfig SysConfig = null;

        public static acMenuConfig MenuConfig = null;

        public static acEmpConfig EmpConfig = null;

        public static acBizError BizError = null;

        public static acToolTip ToolTip = null;

        public static acStdCodes StdCodes = null;

        public static acStdEmps StdEmps = null;

        public static AppType APP = AppType.Unknown;

        public static Dictionary<string, acMessageBoxHelp> HelpForms = new Dictionary<string, acMessageBoxHelp>();

        public static string SelectedTabName = null;

        public static string LProcCode = null;
        public static string MProcCode = null;

        public static bool AutoLogin = false;

        //단말기 추가
        public static Font LabelTextFont = DevExpress.Utils.AppearanceObject.DefaultFont;

        public static Font ButtonFont = DevExpress.Utils.AppearanceObject.DefaultFont;

        public static Font GridFont = DevExpress.Utils.AppearanceObject.DefaultFont;

        public static int GridRowHeight = 0;

        public static int LOG_UID = 0;
        /// <summary>
        /// 임시 시스템 디렉토리를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static string GetTempSystemDirectory()
        {
            return string.Format(@"{0}\{1}\{2}", System.Environment.GetFolderPath(Environment.SpecialFolder.Templates), acInfo.SystemName, acInfo.PLT_CODE);


        }

        /// <summary>
        /// 시스템이 활성화되어있는지 반환한다.
        /// </summary>
        /// <returns></returns>
        public static bool IsSystemFocused()
        {

            Process runninProcesse = Process.GetProcessById(Process.GetCurrentProcess().Id);

            IntPtr activeWindowHandle = (IntPtr)WIN32API.GetForegroundWindow();

            if (runninProcesse.MainWindowHandle.Equals(activeWindowHandle))
            {
                return true;
            }


            return false;
        }

    }
}
