using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInForm
{
    public enum LanguageList
    {

        /// <summary>
        /// 한국어
        /// </summary>
        KR,

        /// <summary>
        /// 일본어
        /// </summary>
        JP,

        /// <summary>
        /// 중국어
        /// </summary>
        CHS,

        /// <summary>
        /// 영어
        /// </summary>
        EN,

    }

    public class ConfigMember
    {
        public ConfigMember()
        {

        }

        public void Set(ConfigMember member)
        {
            _ServerIP = member.ServerIP;
            _ServerName = member.ServerName;
            _DBName = member.DatabaseName;
            _Plant = member.Plant;
            _Language = member.Language;
            _Skin = member.Skin;
            _UserID = member.UserID;
            _Pwd = member.PassWD;
            _Use = member.Use;
            _SavePwd = member.SavePwd;
            _ApiUrl = member._ApiUrl;
        }

        private string _DBName = null;

        public string DatabaseName
        {
            get { return _DBName; }
            set { _DBName = value; }
        }

        private string _ServerName = null;

        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        private string _ServerIP = null;

        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private string _ServerPort = "";

        public string ServerPort
        {
            get { return _ServerPort; }
            set { _ServerPort = value; }
        }

        private string _ServerNum = "";

        public string ServerNum
        {
            get { return _ServerNum; }
            set { _ServerNum = value; }
        }

        private string _Language = "";

        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }


        private string _Plant = "";

        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }

        private string _Skin = "";

        public string Skin
        {
            get { return _Skin; }
            set { _Skin = value; }
        }

        private string _Use = null;

        public string Use
        {
            get { return _Use; }
            set { _Use = value; }
        }

        private string _UserID = "";

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _Pwd = "";

        public string PassWD
        {
            get { return _Pwd; }
            set { _Pwd = value; }
        }

        private string _SavePwd = "";

        public string SavePwd
        {
            get { return _SavePwd; }
            set { _SavePwd = value; }
        }
        
        private string _ApiUrl = "";

        public string ApiUrl { get => _ApiUrl; set => _ApiUrl = value; }


    }

}