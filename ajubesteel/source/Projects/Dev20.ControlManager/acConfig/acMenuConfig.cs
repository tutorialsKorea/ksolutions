using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BizManager;

namespace ControlManager
{
    public class acMenuConfig
    {

        private Dictionary<string, string> _menuConfigDic = new Dictionary<string, string>();

        public acMenuConfig(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow confRow = dt.Rows[i];

                string key = string.Format("{0}&{1}", confRow["MENU_CODE"], confRow["CONF_NAME"]);

                if (!this._menuConfigDic.ContainsKey(key))
                {
                    this._menuConfigDic.Add(key, confRow["CONF_VALUE"].toStringNull());
                }
            }

        }

        /// <summary>
        /// 서버에 환경설정을 저장합니다.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public void SetMenuConfigByServer(string menuCode, string confName ,  object value)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //
                paramTable.Columns.Add("CONF_VALUE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MENU_CODE"] = menuCode;
                paramRow["CONF_NAME"] = confName;
                paramRow["CONF_VALUE"] = value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL","SET_MENU_CONFIG", paramSet, "RQSTDT", "");
                //BizManager.acControls.SET_MENU_CONFIG(paramSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        public DataTable GetMenuConfigRowTableByServer(object menuCode)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MENU_CODE", typeof(String)); //
       
            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MENU_CODE"] = menuCode;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_MENU_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_MENU_CONFIG_ALL(paramSet);
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
        public string GetMenuConfigByServer(string menuCode, string configName)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MENU_CODE"] = menuCode;
                paramRow["CONF_NAME"] = configName;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_MENU_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    return resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();
                }
                else
                {
                    return string.Empty; // new BizException(BizException.NONE_CONFIG);
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
            return "acMenuConfig";
        }


        /// <summary>
        /// 환경설정을 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemoryMenuConfig(string menuCode)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MENU_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MENU_CODE"] = menuCode;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_MENU_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");

            //DataSet resultSet = BizManager.acControls.GET_MENU_CONFIG_ALL(paramSet);

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                string key = string.Format("{0}&{1}", row["MENU_CODE"], row["CONF_NAME"]);

                if (!this._menuConfigDic.ContainsKey(key))
                {
                    this._menuConfigDic.Add(key, row["CONF_VALUE"].toStringNull());
                }
                else
                {
                    this._menuConfigDic[key] = row["CONF_VALUE"].toStringNull();
                }

               
            }

        }

        /// <summary>
        /// 환경설정을 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemoryMenuConfig()
        {

            this._menuConfigDic.Clear();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_MENU_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_MENU_CONFIG_ALL(paramSet);

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                string key = string.Format("{0}&{1}", row["MENU_CODE"], row["CONF_NAME"]);

                this._menuConfigDic.Add(key, row["CONF_VALUE"].toStringNull());
            }

        }



        public string GetMenuConfigByMemory(string menuCode, string confName)
        {
            try
            {
                string key = string.Format("{0}&{1}", menuCode, confName);

                if (!string.IsNullOrEmpty(key))
                {
                    if (_menuConfigDic.ContainsKey(key))
                    {
                        return _menuConfigDic[key];
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
