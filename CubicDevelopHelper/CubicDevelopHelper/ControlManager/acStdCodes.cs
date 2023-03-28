using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BizManager;

namespace ControlManager
{
    public class acStdCodes
    {



        private DataTable _StdCodesDt = null;

        public acStdCodes(DataTable dt)
        {
            this._StdCodesDt = dt;
        }


        public static string GetClassName()
        {
            return "acStdCodes";
        }

        public DataRow GetCodeRow(object catCode, object code)
        {
            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}' AND CD_CODE = '{1}'", catCode, code));

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable().Rows[0];
            }
            else
            {
                return null;
            }

        }

        public DataRow GetDefaultCodeRow(object catCode)
        {
            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}' AND IS_DEFAULT = 1", catCode));

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable().Rows[0];
            }
            else
            {
                return null;
            }

        }

        public static DataRow GetCodeRowByServer(object catCode, object code)
        {
            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;


            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);

            DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select(string.Format("CD_CODE = '{0}'", code));

            return codeRows[0];

        }

        public static DataTable GetCatTableByServer(object catCode)
        {
            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;


            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL","GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);
            return resultSet.Tables["RSLTDT"];

        }

        public DataTable GetCatTable(object catCode)
        {

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE ='{0}'", catCode), "CD_SEQ");

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable();
            }
            else
            {
                return this._StdCodesDt.Clone();
            }

        }

        public DataTable GetCatTable(object catCode, object cdParent, bool visibleCommon = false)
        {
            DataRow[] rows = null;
            if (visibleCommon == true)
            {
                rows = this._StdCodesDt.Select(string.Format("CAT_CODE ='{0}' AND (CD_PARENT = '{1}' OR CD_PARENT IS NULL OR CD_PARENT = '')", catCode, cdParent));
            }
            else
            {
                rows = this._StdCodesDt.Select(string.Format("CAT_CODE ='{0}' AND CD_PARENT = '{1}'", catCode, cdParent));
            }

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable();
            }
            else
            {
                return this._StdCodesDt.Clone();
            }


        }
        /// <summary>
        /// 코드를 알아온다.
        /// </summary>
        /// <param name="catCode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetCodeByName(object catCode, object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE ='{0}' AND CD_NAME = '{1}'", catCode, name));

            if (rows.Length > 0)
            {
                return rows[0]["CD_CODE"].toStringNull();
            }
            else
            {
                return null;
            }


        }


        public static string GetCodeByNameServer(object catCode, object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");
            paramTable.Columns.Add("CD_NAME");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;
            paramRow["CD_NAME"] = name;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);
            DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select(string.Format("CD_NAME = '{0}'", name));

            if (codeRows.Length != 0)
            {
                return codeRows[0]["CD_CODE"].toStringNull();
            }
            else
            {
                return null;
            }


        }

        public string GetCodeByName(object catCode, object parent, object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }


            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE='{0}' AND CD_PARENT = '{1}' AND CD_NAME = '{2}'", catCode, parent, name));

            if (rows.Length > 0)
            {
                return rows[0]["CD_CODE"].toStringNull();
            }
            else
            {
                return null;
            }


        }

        public static string GetCodeByNameServer(object catCode, object parent, object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");
            paramTable.Columns.Add("CD_PARENT");
            paramTable.Columns.Add("CD_NAME");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;
            paramRow["CD_PARENT"] = parent;
            paramRow["CD_NAME"] = name;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);
            DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select(string.Format("CD_NAME = '{0}'", name));

            if (codeRows.Length != 0)
            {
                return codeRows[0]["CD_CODE"].toStringNull();
            }
            else
            {
                return null;
            }


        }

        public string GetCodeByValue(object catCode, object value)
        {
            if (acChecker.isNull(value))
            {
                return null;
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE ='{0}' AND VALUE = '{1}'", catCode, value));

            if (rows.Length > 0)
            {
                return rows[0]["CD_CODE"].toStringNull();
            }
            else
            {
                return null;
            }


        }



        /// <summary>
        /// 코드명을 알아온다
        /// </summary>
        /// <param name="catCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetNameByCodeServer(object catCode, object code)
        {
            if (acChecker.isNull(code))
            {
                return null;
            }

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;


            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);

            DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select("CD_CODE = '" + code.toStringNull() + "'");

            if (codeRows.Length != 0)
            {
                return codeRows[0]["CD_NAME"].toStringNull();
            }
            else
            {
                return null;
            }


        }

        /// <summary>
        /// 코드명을 알아온다
        /// </summary>
        /// <param name="catCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetNameByCode(object catCode, object code)
        {
            if (acChecker.isNull(code))
            {
                return "";
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}' AND  CD_CODE ='{1}'", catCode, code));

            if (rows.Length > 0)
            {
                return rows[0]["CD_NAME"].toStringNull();
            }
            else
            {
                return "";
            }


        }

        /// <summary>
        /// 코드 Value을 알아온다
        /// </summary>
        /// <param name="catCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetValueByCode(object catCode, object code)
        {
            if (acChecker.isNull(code))
            {
                return "";
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}' AND  CD_CODE ='{1}'", catCode, code));

            if (rows.Length > 0)
            {
                return rows[0]["VALUE"].ToString();
            }
            else
            {
                return "";
            }


        }
        public string GetScommentByCode(object catCode, object code)
        {
            if (acChecker.isNull(code))
            {
                return "";
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}' AND  CD_CODE ='{1}'", catCode, code));

            if (rows.Length > 0)
            {
                return rows[0]["SCOMMENT"].toStringNull();
            }
            else
            {
                return "";
            }


        }

        public string GetNameByCodes(object catCode, object codes)
        {
            if (acChecker.isNull(codes))
            {
                return null;
            }

            DataRow[] rows = this._StdCodesDt.Select(string.Format("CAT_CODE = '{0}'", catCode));

            if (rows.Length > 0)
            {

                DataTable dt = rows.CopyToDataTable();

                string codeNames = null;

                string codesStr = codes.toStringEmpty();

                string[] codeArray = codesStr.Split(',');

                foreach (string code in codeArray)
                {
                    DataRow[] codeRows = dt.Select(string.Format("CD_CODE = '{0}'", code));

                    if (codeRows.Length != 0)
                    {
                        if (string.IsNullOrEmpty(codeNames))
                        {
                            codeNames += string.Format("{0}", codeRows[0]["CD_NAME"]);
                        }
                        else
                        {
                            codeNames += string.Format(",{0}", codeRows[0]["CD_NAME"]);
                        }
                    }

                }

                return codeNames;

            }
            else
            {
                return null;
            }

        }

        public static string GetNameByCodesServer(object catCode, object codes)
        {
            if (acChecker.isNull(codes))
            {
                return null;
            }

            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("CAT_CODE");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CAT_CODE"] = catCode;

            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL","GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);
            string codeNames = null;

            string codesStr = codes.toStringEmpty();

            string[] codeArray = codesStr.Split(',');

            foreach (string code in codeArray)
            {
                DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select(string.Format("CD_CODE = '{0}'", code));

                if (codeRows.Length != 0)
                {
                    if (string.IsNullOrEmpty(codeNames))
                    {
                        codeNames += string.Format("{0}", codeRows[0]["CD_NAME"]);
                    }
                    else
                    {
                        codeNames += string.Format(",{0}", codeRows[0]["CD_NAME"]);
                    }
                }

            }

            return codeNames;

        }

        /// <summary>
        /// 환경설정을 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemoryStdCodes()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL","GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);

            this._StdCodesDt = resultSet.Tables["RSLTDT"];

        }


    }
}
