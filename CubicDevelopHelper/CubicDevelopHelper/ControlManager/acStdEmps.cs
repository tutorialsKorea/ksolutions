///수정중 신재경 2015.05.04

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BizManager;

namespace ControlManager
{
    public class acStdEmps
    {



        private DataTable _StdEmpsDt = null;

        public acStdEmps(DataTable dt)
        {
            this._StdEmpsDt = dt;
        }


        public static string GetClassName()
        {
            return "acStdEmps";
        }

        public DataRow GetCodeRow(object empcode)
        {
            DataRow[] rows = this._StdEmpsDt.Select(string.Format("EMP_CODE = '{0}'", empcode));

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable().Rows[0];
            }
            else
            {
                return null;
            }

        }

        public static DataRow GetCodeRowByServer(object empcode)
        {
            DataSet paramSet = new DataSet();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "STD13A_SER2", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);

            DataRow[] codeRows = resultSet.Tables["RSLTDT"].Select(string.Format("EMP_CODE = '{0}'", empcode));

            return codeRows[0];

        }

        public static DataTable GetEmpTableByServer()
        {
            DataSet paramSet = new DataSet();

            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE");

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "GET_EMPLOYEE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMPLOYEE(paramSet);
            return resultSet.Tables["RSLTDT"];

        }

        public DataTable GetCatTable()
        {

            DataRow[] rows = this._StdEmpsDt.Select(string.Format("1=1"));

            if (rows.Length > 0)
            {
                return rows.CopyToDataTable();
            }
            else
            {
                return this._StdEmpsDt.Clone();
            }

        }

        
        public string GetCodeByName(object catCode, object parent, object name)
        {
            if (acChecker.isNull(name))
            {
                return null;
            }


            DataRow[] rows = this._StdEmpsDt.Select(string.Format("CAT_CODE='{0}' AND CD_PARENT = '{1}' AND CD_NAME = '{2}'", catCode, parent, name));

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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_STDCODES", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_STDCODES(paramSet);

            this._StdEmpsDt = resultSet.Tables["RSLTDT"];

        }


    }
}
