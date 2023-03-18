using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInForm
{

    public class ConnectMember
    {


        public ConnectMember()
        {

        }

        private string _ServerName = null;

        /// <summary>
        /// 서버이름
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        private string _ServerIP = null;

        /// <summary>
        /// 서버주소
        /// </summary>
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private string _ServerPort = null;

        /// <summary>
        /// 서버포트
        /// </summary>
        public string ServerPort
        {
            get { return _ServerPort; }
            set { _ServerPort = value; }
        }


        private string _ServerNum = null;

        /// <summary>
        /// 서버번호
        /// </summary>
        public string ServerNum
        {
            get { return _ServerNum; }
            set { _ServerNum = value; }
        }

        private string _Language = null;

        /// <summary>
        /// 언어
        /// </summary>
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

        private string _Plant = null;

        /// <summary>
        /// 사업장코드
        /// </summary>
        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }

        private string _Skin = null;

        /// <summary>
        /// 스킨
        /// </summary>
        public string Skin
        {
            get { return _Skin; }
            set { _Skin = value; }
        }



        private string _Menu = null;

        /// <summary>
        /// 메뉴
        /// </summary>
        public string Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }


        private string _UserID = null;

        /// <summary>
        /// 유저아이디
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }





    }
}
