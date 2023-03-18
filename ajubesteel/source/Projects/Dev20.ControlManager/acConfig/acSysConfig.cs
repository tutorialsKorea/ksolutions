using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BizManager;

namespace ControlManager
{
    public class acSysConfig
    {

        /// <summary>
        /// 점심 시작시간
        /// </summary>
        public TimeSpan LUNCH_START_TIME
        {
            get
            {
                string[] value = this._sysConfigDic["LUNCH_TIME"].Split(',');

                return value[0].toTimeSpan();
            }
        }

        public TimeSpan DAY_CLOSE_TIME
        {
            get
            {
                return this._sysConfigDic["DAY_CLOSE_TIME"].toTimeSpan();
            }
        }

        public DateTime getWorkDate
        {
            get
            {
                
                DateTime compDate = acDateEdit.GetNowDateFromServer().toDateString("yyyyMMdd").toDateTime().Add(this._sysConfigDic["DAY_CLOSE_TIME"].toTimeSpan());
                DateTime returnDate = acDateEdit.GetNowDateFromServer();
                if(compDate > returnDate)
                {
                    returnDate = returnDate.AddDays(-1);
                }
                return returnDate;
            }
        }

        public string[] getChangeTime
        {
            get
            {
                string[] value = this._sysConfigDic["WORK_CHANGE_TIME"].Split(',');

                return value;
            }
        }
        /// <summary>
        /// 점심 종료시간
        /// </summary>
        public TimeSpan LUNCH_END_TIME
        {
            get
            {
                string[] value = this._sysConfigDic["LUNCH_TIME"].Split(',');

                return value[1].toTimeSpan();
            }
        }

        /// <summary>
        /// 저녁 시작시간
        /// </summary>
        public TimeSpan OFF_START_TIME
        {
            get
            {
                string[] value = this._sysConfigDic["OFF_TIME"].Split(',');

                return value[0].toTimeSpan();
            }
        }


        /// <summary>
        /// 저녁 종료시간
        /// </summary>
        public TimeSpan OFF_END_TIME
        {

            get
            {
                string[] value = this._sysConfigDic["OFF_TIME"].Split(',');

                return value[1].toTimeSpan();
            }

        }

        /// <summary>
        /// 근무 시작시간
        /// </summary>
        public TimeSpan WK_START_TIME(DateTime date)
        {


            string confName = null;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //일요일

                confName = "SUN_WORK_TIME";

            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //토요일
                confName = "SAT_WORK_TIME";

            }
            else
            {
                //평일

                confName = "NOR_WORK_TIME";
            }


            string[] values = this._sysConfigDic[confName].Split(',');

            return values[0].toTimeSpan();


        }

        /// <summary>
        /// 근무 종료시간
        /// </summary>
        public TimeSpan WK_END_TIME(DateTime date)
        {


            string confName = null;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //일요일

                confName = "SUN_WORK_TIME";

            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //토요일
                confName = "SAT_WORK_TIME";

            }
            else
            {
                //평일

                confName = "NOR_WORK_TIME";
            }


            string[] values = this._sysConfigDic[confName].Split(',');

            return values[1].toTimeSpan();


        }

        /// <summary>
        /// 잔업 시작시간
        /// </summary>
        public TimeSpan OT_START_TIME(DateTime date)
        {


            string confName = null;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //일요일

                confName = "SUN_WORK_TIME";

            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //토요일
                confName = "SAT_WORK_TIME";

            }
            else
            {
                //평일

                confName = "NOR_WORK_TIME";
            }


            string[] values = this._sysConfigDic[confName].Split(',');

            return values[2].toTimeSpan();


        }

        /// <summary>
        /// 잔업 종료시간
        /// </summary>
        public TimeSpan OT_END_TIME(DateTime date)
        {



            string confName = null;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //일요일

                confName = "SUN_WORK_TIME";

            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //토요일
                confName = "SAT_WORK_TIME";

            }
            else
            {
                //평일

                confName = "NOR_WORK_TIME";
            }


            string[] values = this._sysConfigDic[confName].Split(',');

            return values[3].toTimeSpan();


        }

        private Dictionary<string, string> _sysConfigDic = new Dictionary<string,string>();

        public acSysConfig(DataTable dt)
        {


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow confRow = dt.Rows[i];

                if (!this._sysConfigDic.ContainsKey(confRow["CONF_NAME"].ToString()))
                {
                    this._sysConfigDic.Add(confRow["CONF_NAME"].ToString(), confRow["CONF_VALUE"].toStringNull());
                }
            }


        }




        /// <summary>
        /// 서버에 환경설정을 저장합니다.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public void SetSysConfigByServer(string configName, object value)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //
                paramTable.Columns.Add("CONF_VALUE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = "SYS";
                paramRow["CONF_NAME"] = configName;
                paramRow["CONF_VALUE"] = value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_SYS_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.SET_SYS_CONFIG(paramSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public void SetSysConfigByServer(string configName, object value, object section)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //
                paramTable.Columns.Add("CONF_VALUE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = section;
                paramRow["CONF_NAME"] = configName;
                paramRow["CONF_VALUE"] = value;
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_SYS_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.SET_SYS_CONFIG(paramSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }



        public DataTable GetSysConfigRowTableByServer()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("CONF_SECTION", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CONF_SECTION"] = "SYS";


            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL","GET_SYS_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG_ALL(paramSet);

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
        public string GetSysConfigByServer(string configName)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("CONF_SECTION", typeof(String)); //
                paramTable.Columns.Add("CONF_NAME", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CONF_SECTION"] = "SYS";
                paramRow["CONF_NAME"] = configName;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_SYS_CONFIG", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG(paramSet);

                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    return resultSet.Tables["RSLTDT"].Rows[0]["CONF_VALUE"].toStringNull();
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


        public static string GetClassName()
        {
            return "acSysConfig";
        }


        /// <summary>
        /// 환경설정을 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemorySysConfig()
        {

            this._sysConfigDic.Clear();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_SYS_CONFIG_ALL", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_SYS_CONFIG_ALL(paramSet);

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {
                this._sysConfigDic.Add(row["CONF_NAME"].toStringNull(), row["CONF_VALUE"].toStringNull());
            }

        }



        public string GetSysConfigByMemory(string configName)
        {
            try
            {
                if (!string.IsNullOrEmpty(configName))
                {
                    if (_sysConfigDic.ContainsKey(configName))
                    {
                        return _sysConfigDic[configName];
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
