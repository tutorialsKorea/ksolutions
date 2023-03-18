using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Resources;
using System.Runtime.InteropServices;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;

namespace LogInForm
{
    public partial class LogInForm : XtraForm
    {
       
        public DataTable serverItemsTable = null;

        public static ResourceManager ResManager = null;

        string _UserID;
        
        private int _LCID = 1042;

        private const string CONFIG_PATH = @"C:\CubicTek";
        private const string CONFIG_FILENAME = "Config.xml";
        private const string CONFIG_FULLPATH = @"C:\CubicTek\Config.xml";

        public string UserID
        { get { return _UserID; } }

        public LogInForm() {

            InitializeComponent();

            #region skin list
            Dictionary<string, string> skinList = new Dictionary<string, string>();

            skinList.Add("Caramel", @"Caramel");
            skinList.Add("Money Twins", @"Money Twins");
            skinList.Add("Lilian", @"Lilian");
            skinList.Add("The Asphalt World", @"The Asphalt World");
            skinList.Add("iMaginary", @"iMaginary");
            skinList.Add("Black", @"Black");
            skinList.Add("Blue", @"Blue");
            skinList.Add("Office 2010 Blue", @"Office 2010 Blue");
            skinList.Add("Office 2010 Black", @"Office 2010 Black");
            skinList.Add("Office 2010 Silver", @"Office 2010 Silver");
            skinList.Add("Office 2010 Green", @"Office 2010 Green");
            skinList.Add("Office 2010 Pink", @"Office 2010 Pink");
            skinList.Add("Coffee", "Coffee");
            skinList.Add("Liquid Sky", @"Liquid Sky");
            skinList.Add("London Liquid Sky", @"London Liquid Sky");
            skinList.Add("Glass Oceans", @"Glass Oceans");
            skinList.Add("Stardust", @"Stardust");
            skinList.Add("Xmas 2008 Blue", @"Xmas 2008 Blue");
            skinList.Add("Valentine", @"Valentine");
            skinList.Add("McSkin", @"McSkin");
            skinList.Add("DevExpress Dark Style", @"DevExpress Dark Style");

            DataTable skinTable = new DataTable();

            skinTable.Columns.Add("SKIN_NAME");
            skinTable.Columns.Add("SKIN_CODE");

            foreach (KeyValuePair<string, string> skinItem in skinList)
            {
                DataRow skinRow = skinTable.NewRow();

                skinRow["SKIN_NAME"] = skinItem.Key;
                skinRow["SKIN_CODE"] = skinItem.Value;

                skinTable.Rows.Add(skinRow);
            }

            lueSkin.Properties.ShowHeader = false;

            lueSkin.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SKIN_NAME"));

            lueSkin.Properties.DisplayMember = "SKIN_NAME";
            lueSkin.Properties.ValueMember = "SKIN_CODE";

            lueSkin.Properties.DataSource = skinTable;

            lueSkin.EditValue = "0";
            #endregion


            //Server 접속 정보 가져오기
            _configMember = new ConfigMember();
            _configMember = GetSetting();

            switch (this._LCID)
            {

                case 1042:
                    //한국어
                    ResManager = LangPack_ko_KR.ResourceManager;
                    break;

                case 1041:
                    //일본어
                    ResManager = LangPack_ja_JP.ResourceManager;
                    break;

                case 2052:
                    //중국어
                    ResManager = LangPack_zh_CHS.ResourceManager;
                    break;

                case 1033:
                    //영어
                    ResManager = LangPack_us_EN.ResourceManager;
                    break;
                default:
                    ResManager = LangPack_ko_KR.ResourceManager;
                    break;

            }

            this.Load += LogInForm_Load;

        }

        void LogInForm_Load(object sender, EventArgs e)
        {
            txtUserID.Text = _configMember.UserID;
            lueSkin.Value = _configMember.Skin;
            //txtPassword.Text = _configMember.PassWD;

            if (_configMember.SavePwd == "1")
            {
                chkSavePwd.Checked = true;
                txtPassword.Text = _configMember.PassWD;
            }

        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtUserID.Text.isNullOrEmpty())
            {
                acMessageBox.Show(this, "아이디를 입력해 주세요", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }
            else if (txtPassword.Text.isNullOrEmpty())
            {
                acMessageBox.Show(this, "비밀번호를 입력해 주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return;
            }

            Login(txtUserID.Text, txtPassword.Text);
        }

        
        /// <summary>
        /// userid, userpw로 tstd_employee 검색하여 로그인 결과를 알려준다.
        /// 1. 해당 id없음.
        /// 2. 비밀번호 불일치.
        /// 3. login 성공
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userPW"></param>
        /// <returns></returns>
        private void Login(string userID, string userPW)
        {

            try
            {
                //접속서버 가져옴.
                string macAddr = acNetWork.GetMacAddress();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("LANG", typeof(String)); //사업장 코드
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //사원코드
                paramTable.Columns.Add("ACC_PWD", typeof(String)); //비밀번호
                paramTable.Columns.Add("LAN_ADDR", typeof(String)); //LAN IP 주소
                paramTable.Columns.Add("WAN_ADDR", typeof(String)); //WAN IP 주소
                paramTable.Columns.Add("MAC_ADDR", typeof(String)); //MAC IP 주소
                paramTable.Columns.Add("VERSION", typeof(String)); //버전

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = _configMember.Plant;
                paramRow["LANG"] = _configMember.Language;
                paramRow["EMP_CODE"] = userID;
                paramRow["ACC_PWD"] = userPW;
                paramRow["LAN_ADDR"] = acNetWork.GetLanIPAddress();
                paramRow["WAN_ADDR"] = acNetWork.GetWanIPAddress();
                paramRow["MAC_ADDR"] = macAddr;
                paramRow["VERSION"] = acInfo.Version;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun = new QBizRun(_configMember.ServerIP, _configMember.DatabaseName, _configMember.Plant, userID, acNetWork.GetWanIPAddress(), _configMember.ApiUrl);
                //BizRun.QBizRun = new QBizRun(member.ServerIP, member.DatabaseName, member.Plant, member.UserID);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, 
                    "MAINFORM_LOG_IN", paramSet, "RQSTDT", "", QuickSave, QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this._UserID = txtUserID.Text;

                //환경설정 값 save
                _configMember.UserID = txtUserID.Text;
                _configMember.PassWD = txtPassword.Text;
                _configMember.Skin = lueSkin.Value.ToString();

                //ConfigForm.AddConfigItem(CONFIG_FULLPATH, _configMember);
                SaveSetting();

                ControlManager.acInfo.IsRunTime = true;
                ControlManager.acInfo.PLT_CODE = _configMember.Plant;
                ControlManager.acInfo.Lang = _configMember.Language;
                ControlManager.acInfo.ServerIp = _configMember.ServerIP;
                ControlManager.acInfo.UserID = _configMember.UserID;
                ControlManager.acInfo.Skin = _configMember.Skin;
                ControlManager.acInfo.DatabaseName = _configMember.DatabaseName;
                ControlManager.acInfo.ApiUrl = _configMember.ApiUrl;

                //if(use_password_policy)
                if (e.result.Tables["RSLTDT"].Rows[0]["PWD_POLICY_USE"].Equals("1"))
                {
                    DateTime server_time = e.result.Tables["RSLTDT"].Rows[0]["SERVER_TIME"].toDateTime();
                    //비밀번호 마지막 변경일
                    DateTime pwd_changed_dt = e.result.Tables["RSLTDT"].Rows[0]["PWD_CHANGED_DT"].toDateTime();

                    //비빌번호 변경 주기
                    int pwd_change_period = e.result.Tables["RSLTDT"].Rows[0]["PWD_CHANGE_PERIOD"].toInt();

                    int pwd_change_remain_day = e.result.Tables["RSLTDT"].Rows[0]["PWD_CHANGE_REMAIN_DAY"].toInt();

                    if (pwd_change_period != 0 && server_time.Subtract(pwd_changed_dt).TotalDays > pwd_change_period.toDouble())
                    {
                        //if(acMessageBox.Show(string.Format("비밀번호 변경시기가 {0}일이 경과 되었습니다.\r\n비밀번호를 변경하시겠습니까?\r\n(마지막변경일시:{1})"
                        //          , pwd_change_period, pwd_changed_dt.ToString("yyyy-MM-dd HH:mm")), "확인", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                        acMessageBox.Show(string.Format("비밀번호 변경시기가 {0}일이 경과 되었습니다.\r\n비밀번호를 변경하여 주십시오.\r\n(마지막변경일시:{1})"
                                    , pwd_change_period, pwd_changed_dt.ToString("yyyy-MM-dd HH:mm")), "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        ChangePassword frm = new ChangePassword();

                        frm.Text = "비밀번호 갱신";

                        frm.ParentControl = this;

                        if (frm.ShowDialog(this) != DialogResult.OK)
                        {
                            acMessageBox.Show("비밀번호 변경 후 로그인이 가능합니다.", "확인", acMessageBox.emMessageBoxType.CONFIRM);

                            return;
                        }
                    }
                    else if (pwd_change_period != 0 && (pwd_change_period.toDouble() - server_time.Subtract(pwd_changed_dt).TotalDays) < pwd_change_remain_day)
                    {
                        int remainDay = (pwd_change_period.toDouble() - server_time.Subtract(pwd_changed_dt).TotalDays).toInt();
                        acMessageBox.Show(string.Format("비밀번호 만료일이 {0}일 남았습니다.\r\n비밀번호를 변경하여 주십시오."
                                    , remainDay), "확인", acMessageBox.emMessageBoxType.CONFIRM);
                    }

                    if (txtPassword.Text == "1")
                    {
                        acMessageBox.Show(string.Format("비밀번호를 초기화 하였습니다. 비밀번호를 변경하여 주십시오.(필수)"), "확인", acMessageBox.emMessageBoxType.CONFIRM);
                        ChangePassword frm = new ChangePassword();

                        frm.Text = "비밀번호 갱신";

                        frm.ParentControl = this;

                        if (frm.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
                try
                {
                    acInfo.LOG_UID = e.result.Tables["RSLTDT_LOG"].Rows[0]["UID"].toInt();
                }
                catch { }

                this.Hide();

                MainForm _MainControl = new MainForm(this._UserID);

                _MainControl.Show();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            if (ex.ErrNumber == 200060)
            {
                //아이디또는 비밀번호 오류
                acMessageBox.Show("아이디 또는 비밀번호를 확인하세요.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                txtUserID.Focus();
                
            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }
        /// <summary>
        /// 환경 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigForm _Config = new ConfigForm(CONFIG_PATH, CONFIG_FILENAME);

                _Config.ShowDialog();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        
        ConfigMember _configMember;

        public ConfigMember Config
        {
            get { return _configMember; }
        }

        

        
        private string GetXmlNodeValue(XmlNode node)
        {
            if (node == null) return string.Empty;


            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            else
            {
                return string.Empty;
            }

        }

        private void SaveSetting()
        {

            
            Properties.Settings.Default.USER_ID = txtUserID.Text;
            Properties.Settings.Default.SKIN = lueSkin.EditValue.ToString();

            if (chkSavePwd.Checked)
            {
                Properties.Settings.Default.PASS_WORD = txtPassword.Text;
                Properties.Settings.Default.SAVE_PWD = "1";
            }

            Properties.Settings.Default.Save();
        }

        private ConfigMember GetSetting()
        {
            ConfigMember member = new ConfigMember();
            member.Plant = Properties.Settings.Default.PLANT;
            member.ServerIP = Properties.Settings.Default.SERVER_IP;
            member.DatabaseName = Properties.Settings.Default.DATABASE_NAME;
            member.UserID = Properties.Settings.Default.USER_ID;
            member.PassWD = Properties.Settings.Default.PASS_WORD;
            member.SavePwd = Properties.Settings.Default.SAVE_PWD;
            member.Skin = Properties.Settings.Default.SKIN;
            member.ServerName = Properties.Settings.Default.ServerName;
            member.Language = Properties.Settings.Default.LANG;
            member.ApiUrl = Properties.Settings.Default.API_URL;
            return member;
        }

        private void SaveConfigUserid()
        {
            FileInfo configFile = new FileInfo(CONFIG_FULLPATH);

            if (configFile.Exists == true)
            {
                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(CONFIG_FULLPATH);

                XmlNode config = newDoc.DocumentElement;

                XmlElement server = null;

                foreach (XmlElement serverItem in config.ChildNodes)
                {

                    server = serverItem;
                    serverItem.SetAttribute("userID", txtUserID.Text);
                    break;


                }

                newDoc.Save(CONFIG_FULLPATH);

            }

        }

        private bool LoadConfigItem(string ConfigFileName)
        {

            FileInfo configFile = new FileInfo(ConfigFileName);
            if (configFile.Exists == true)
            {
                serverItemsTable = new DataTable();

                serverItemsTable.Columns.Add("Check", typeof(string));
                serverItemsTable.Columns.Add("ServerName", typeof(string));
                serverItemsTable.Columns.Add("ConfigMember", typeof(ConfigMember));

                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;

                string userid = string.Empty;

                ConfigMember configList;

                foreach (XmlElement serverItem in config.ChildNodes)
                {
                    configList = new ConfigMember();

                    configList.ServerName = serverItem.GetAttribute("name");
                    configList.Use = serverItem.GetAttribute("use");

                    configList.ServerIP = GetXmlNodeValue(serverItem.GetElementsByTagName("ServerIP").Item(0));
                    configList.DatabaseName = GetXmlNodeValue(serverItem.GetElementsByTagName("DatabaseName").Item(0));
                    configList.Language = GetXmlNodeValue(serverItem.GetElementsByTagName("Language").Item(0));
                    configList.Plant = GetXmlNodeValue(serverItem.GetElementsByTagName("Plant").Item(0));
                    configList.Skin = GetXmlNodeValue(serverItem.GetElementsByTagName("Skin").Item(0));
                    configList.UserID = GetXmlNodeValue(serverItem.GetElementsByTagName("UserID").Item(0));
                    configList.PassWD = GetXmlNodeValue(serverItem.GetElementsByTagName("PassWD").Item(0));

                    userid = configList.UserID;

                    DataRow serverItemRow = serverItemsTable.NewRow();

                    serverItemRow["ServerName"] = configList.ServerName;

                    serverItemRow["ConfigMember"] = configList;

                    if (configList.Use == "true")
                    {
                        serverItemRow["Check"] = "1";
                        _configMember = new ConfigMember();
                        _configMember.Set(configList);

                    }
                    else
                    {
                        serverItemRow["Check"] = "0";
                    }

                    serverItemsTable.Rows.Add(serverItemRow);

                }

                return true;
            }
            else
            {
                //환경설정 파일이 없습니다.
                //acMessageBox.Show("환경설정 파일이 없습니다. ", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                return false;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        

        /// <summary>
        /// 매뉴얼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManual_Click(object sender, EventArgs e)
        {
            
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "setup_manual.pdf";
                process.Start();
            }
            catch (Exception Ex)
            {
                acMessageBox.Show(this, Ex);
            }
            
        }

        /// <summary>
        /// 원격지원
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemote_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("QuickSupport_ko.exe");
            }
            catch (Exception Ex)
            {
                acMessageBox.Show(this, Ex);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect_Click(null, null);
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect_Click(null, null);
            }
        }

    }
}