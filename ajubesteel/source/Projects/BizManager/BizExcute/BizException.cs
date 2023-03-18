using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace BizExecute
{
    /// <summary>
    /// Biz 예외
    /// </summary>
    public class BizException : Exception
    {

        public const int OVERWRITE = 100001;

        public const int OVERWRITE_HISTORY = 100002;

        public const int UNVALID_DATA = 100003;

        public const int CHECK_DEL_AUTH = 100012;

        public const int ABORT = 0;

        public const int PROD_LOCK = 1;

        public const int STOCK_ERROR = 300000;

        public const int DATA_REFRESH = 100003;

        public const int NOT_EXISTS_TOOL = 200065;

        public const int NOT_EXISTS_NGTYPE = 200078;

        public const int CANNOT_DELETE = 200103;
        /// <summary>
        /// 환경설정 없음
        /// </summary>
        public const int NONE_CONFIG = 100004;

        public const int SYSTEM_REG = 100022;

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

        public BizException(int errorNumber)
        {
            _ErrNumber = errorNumber;
        }

        public BizException(string messgae, Exception innerException)
            : base(messgae, innerException)
        {

        }
    }
}
