using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ControlManager
{
    /// <summary>
    /// 기본 사용자 UI이 변경되었음
    /// </summary>
    public class DefaultSystemLayoutChangedException : Exception
    {

        public DefaultSystemLayoutChangedException()
            : base()
        {

        }

    }


    /// <summary>
    /// BizActor 예외
    /// </summary>
    public class BizActorException : Exception
    {

        public const int OVERWRITE = 100001;

        public const int OVERWRITE_HISTORY = 100002;


        public const int ABORT = 0;
       
        public const int DATA_REFRESH = 100003;

        /// <summary>
        /// 환경설정 없음
        /// </summary>
        public const int NONE_CONFIG = 100004;

        private int _ErrNumber = -1;

        public int ErrNumber
        {
            get { return _ErrNumber; }
            set { _ErrNumber = value; }
        }


        private Dictionary<string, string> _ParameterDic = new Dictionary<string, string>();

        public Dictionary<string, string> ParameterDic
        {
            get { return _ParameterDic; }
            set { _ParameterDic = value; }
        }


        private DataTable _ParameterData = null;

        public DataTable ParameterData
        {
            get { return _ParameterData; }
            set { _ParameterData = value; }
        }

        private int _RefDataIdx = -1;

        public int RefDataIdx
        {
            get { return _RefDataIdx; }
            set { _RefDataIdx = value; }
        }

        public BizActorException(int errorNumber)
            
        {
            _ErrNumber = errorNumber;
        }

        public BizActorException(string messgae, Exception innerException)
            : base(messgae, innerException)
        {

        }

  





    }
}
