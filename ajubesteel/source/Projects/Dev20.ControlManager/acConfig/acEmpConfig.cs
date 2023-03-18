using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BizManager;

namespace ControlManager
{
    public class acEmpConfig
    {

        private Dictionary<string, string> _empConfigDic = new Dictionary<string,string>();

        public acEmpConfig(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow confRow = dt.Rows[i];

                if (!this._empConfigDic.ContainsKey(confRow["CONF_NAME"].ToString()))
                {
                    this._empConfigDic.Add(confRow["CONF_NAME"].ToString(), confRow["CONF_VALUE"].toStringNull());
                }
            }
        }

        /// <summary>
        /// 서버에 환경설정을 저장합니다.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public void SetEmpConfigByServer(string configName, object value)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //
                paramTable.Columns.Add("CONF_VALUE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CONF_NAME"] = configName;
                paramRow["CONF_VALUE"] = value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_EMP_CONFIG", paramSet, "RQSTDT", "");

                //BizManager.acControls.SET_EMP_CONFIG(paramSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataTable GetEmpConfigRowTableByServer()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;


            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMP_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMP_CONFIG_ALL(paramSet);

            DataTable data = new DataTable();

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                if (row["CONF_NAME"].isNullOrEmpty() == false)
                {
                    data.Columns.Add(row["CONF_NAME"].ToString(), typeof(string));
                }

            }

            DataRow newRow = data.NewRow();

            foreach (DataColumn col in data.Columns)
            {
                DataRow[] findRow = resultSet.Tables["RSLTDT"].Select("CONF_NAME = '" + col.ColumnName + "'");

                if (findRow.Length > 0)
                {
                    newRow[col.ColumnName] = findRow[0]["CONF_VALUE"];

                }
            }

            data.Rows.Add(newRow);

            return data;


        }


        /// <summary>
        /// 서버에서 환경설정을 알아옵니다.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public string GetEmpConfigByServer(string configName)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CONF_NAME"] = configName;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL","GET_EMP_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_EMP_CONFIG(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    return resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();
                }
                else
                {
                    return string.Empty;
                    //new BizException(BizException.NONE_CONFIG);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return null;
        }


        public static string GetClassName()
        {
            return "acEmpConfig";
        }


        /// <summary>
        /// 환경설정을 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemoryEmpConfig()
        {

            this._empConfigDic.Clear();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL","GET_EMP_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_EMP_CONFIG_ALL(paramSet);

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                this._empConfigDic.Add(row["CONF_NAME"].toStringNull(), row["CONF_VALUE"].toStringNull());
            }

        }



        public string GetEmpConfigByMemory(string configName)
        {
            try
            {
                if (!string.IsNullOrEmpty(configName))
                {
                    if (_empConfigDic.ContainsKey(configName))
                    {
                        return _empConfigDic[configName];
                    }
                    else
                    {
                        new BizException(BizException.NONE_CONFIG);
                    }
                }
                else
                {
                    new BizException(BizException.NONE_CONFIG);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return null;
        }


    }
}
