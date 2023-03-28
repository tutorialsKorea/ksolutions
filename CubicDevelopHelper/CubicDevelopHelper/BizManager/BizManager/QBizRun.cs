using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Diagnostics;
using BizExecute;
using System.Net;
using System.Net.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace BizManager
{
    public class QBizRun
    {

        private string _ServerIP = string.Empty;
        private string _DBName = string.Empty;

        private QBiz.emExecuteType _ExecuteType = QBiz.emExecuteType.NONE;

        public QBiz.emExecuteType ExecuteType
        {
            get { return _ExecuteType; }
            set { _ExecuteType = value; }
        }

        public QBizRun(string serverIp, string dbName, string Plant, string UserID, string clientIP, string apiUrl)
        {
            _ServerIP = serverIp;
            _DBName = dbName;

            ConnInfo.ServerIP = serverIp;
            ConnInfo.DatabaseName = dbName;
            ConnInfo.PLT_CODE = Plant;
            ConnInfo.UserID = UserID;
            ConnInfo.ApiUrl = apiUrl;
            ConnInfo.ClientIP = clientIP;

            if (UserID.ToUpper().Equals("ACTIVE") || UserID.ToUpper().Equals("ADMIN"))
                ConnInfo.IsSysUser = true;

        }

        //public QBizRun()
        //{
        //    string CONFIG_FULLPATH = @"C:\CubicTek\Config.xml";

        //    LoadConfigItem(CONFIG_FULLPATH);
        //}

        //private bool LoadConfigItem(string ConfigFileName)
        //{

        //    FileInfo configFile = new FileInfo(ConfigFileName);
        //    if (configFile.Exists == true)
        //    {

        //        XmlDocument newDoc = new XmlDocument();

        //        newDoc.Load(ConfigFileName);

        //        XmlNode config = newDoc.DocumentElement;

        //        string userid = string.Empty;

        //        foreach (XmlElement serverItem in config.ChildNodes)
        //        {
        //            if(serverItem.GetAttribute("use") == "true")
        //            { 
        //                _ServerIP = GetXmlNodeValue(serverItem.GetElementsByTagName("ServerIP").Item(0));
        //                _DBName = GetXmlNodeValue(serverItem.GetElementsByTagName("DatabaseName").Item(0));
        //                ConnInfo.ServerIP = _ServerIP;
        //                ConnInfo.DatabaseName = _DBName;
        //                ConnInfo.PLT_CODE = GetXmlNodeValue(serverItem.GetElementsByTagName("Plant").Item(0));
        //                ConnInfo.UserID = GetXmlNodeValue(serverItem.GetElementsByTagName("UserID").Item(0));

        //                break;
        //            }

        //        }
        //        return true;
        //    }
        //    else
        //    {                
        //        return false;
        //    }

        //    return false;

        //}

        //private string GetXmlNodeValue(XmlNode node)
        //{
        //    if (node == null) return string.Empty;


        //    if (node.FirstChild != null)
        //    {
        //        return node.FirstChild.Value;
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }

        //}

        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        public string ServerName
        {
            get { return _DBName; }
            set { _DBName = value; }
        }

        #region WebAPI
        public DataSet ApiService(
            object sender,
            QBiz.emExecuteType executeType,
            string ruleName,
            DataSet refData)
        {
            string[] strParam = ruleName.Split('_');

            return ApiService(sender, executeType, strParam[0], ruleName, refData);
        }


        public DataSet ApiService(
            object sender,
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            DataSet refData)
        {

            BizExecute.BizExecute bizExcute = null;

            try
            {

                bizExcute = new BizExecute.BizExecute(_ServerIP, _DBName);

                string strAssembly = "CUBIZ_BR";// +strParam[0].ToString();

                Assembly bizManager = bizManager = Assembly.Load(strAssembly);

                Type assemType = null;

                try
                {
                    assemType = bizManager.GetType("B" + className.Substring(0, 3) + "." + className, true, true);
                }
                catch
                {
                    assemType = bizManager.GetType(className + "." + className, true, true);
                }

                object obj = Activator.CreateInstance(assemType);

                MethodInfo mi = assemType.GetMethod(ruleName);

                //사업장코드 자동 삽입
                foreach (DataTable dt in refData.Tables)
                {
                    if (!dt.Columns.Contains("PLT_CODE"))
                    {
                        dt.Columns.Add("PLT_CODE", typeof(string));
                        DataRow row = dt.NewRow();
                        row["PLT_CODE"] = ConnInfo.PLT_CODE;
                    }
                }

                object result = mi.Invoke(obj, new object[] { refData, bizExcute });

                #region execute log
                string useSe = QBiz.GetExecuteLogTypeString(executeType);
                Type assemLog = bizManager.GetType("CTRL.CTRL", true, true);
                object logObj = Activator.CreateInstance(assemLog);
                MethodInfo miLog = assemLog.GetMethod("EXECUTE_LOG");
                DataTable dtLog = new DataTable("RQSTDT");
                dtLog.Columns.Add("useSe", typeof(string));
                dtLog.Columns.Add("dataUsgqty", typeof(int));
                dtLog.Columns.Add("ruleName", typeof(string));
                DataRow logRow = dtLog.NewRow();
                logRow["useSe"] = useSe;
                using (Stream s = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, result);
                    logRow["dataUsgqty"] = s.Length;
                }
                logRow["ruleName"] = ruleName;
                dtLog.Rows.Add(logRow);
                DataSet logData = new DataSet();
                logData.Tables.Add(dtLog);
                object logResult = miLog.Invoke(logObj, new object[] { logData, bizExcute });
                #endregion

                bizExcute.commitClose();
                //BizExecuteRun.BizConn.commitClose();

                return (DataSet)result;

            }
            catch (Exception ex)
            {
                if (!bizExcute.isNull()) bizExcute.rollbackClose();

                if (ex.InnerException != null) ex = ex.InnerException;

                BizException bizEx = new BizException(ex.Message, ex);

                bizEx.RefDataIdx = 0;

                string message = bizEx.Message.Replace(" ", string.Empty);


                if (ex.Data.Contains("DATA"))
                {
                    if (ExtensionMethod.isNumeric(ex.Data["DATA"].ToString()))
                    {
                        bizEx.ErrNumber = ex.Data["DATA"].toInt32();
                    }

                }

                //Biz 사용자정의 에러 생성

                int start = message.IndexOf('[');

                int end = message.IndexOf(']');

                if (start >= 0 || end >= 0)
                {

                    string parameterString = message.Substring(start + 1, (end - start) - 1);


                    string[] parameters = parameterString.Split(';');


                    foreach (string parameter in parameters)
                    {
                        string[] ps = parameter.Split('=');

                        if (ps.Length > 1) bizEx.ParameterDic.Add(ps[0], ps[1]);

                    }



                    //if (bizEx.ParameterDic.Count != 0)
                    if (bizEx.Data.Contains("ROW"))
                    {
                        bizEx.ParameterData = new DataTable();

                        Dictionary<string, object> dics = (Dictionary<string, object>)(bizEx.Data["ROW"]);

                        foreach (KeyValuePair<string, object> dic in dics)
                        {
                            switch (dic.Value.GetType().ToString())
                            {
                                case "System.String":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(string));
                                    break;
                                case "System.DateTime":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(DateTime));
                                    break;
                                case "System.Int32":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(int));
                                    break;
                                case "System.Decimal":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(decimal));
                                    break;
                                case "System.Byte":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(byte));
                                    break;
                                default:
                                    bizEx.ParameterData.Columns.Add(dic.Key);
                                    break;
                            }
                            //bizEx.ParameterData.Columns.Add(dic.Key,dic.Value.GetType());

                        }
                        //foreach(DataColumn col in ((DataRow)bizEx.Data["ROW"]).Table.Columns)
                        //{
                        //    bizEx.ParameterData.Columns.Add(col.ColumnName);
                        //}

                        DataRow paramRow = bizEx.ParameterData.NewRow();

                        foreach (DataColumn col in bizEx.ParameterData.Columns)
                        {
                            paramRow[col.ColumnName] = dics[col.ColumnName];
                        }

                        bizEx.ParameterData.Rows.Add(paramRow);

                    }
                }
                throw bizEx;
            }
        }
        #endregion

        public DataSet ExecuteService(
            object sender,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName)
        {
            string[] strParam = ruleName.Split('_');

            return ExecuteService(sender, strParam[0], ruleName, refData, inputTableName, outputTableName);
        }

        //public DataSet ExecuteService(
        //    object sender,
        //    QBiz.emExecuteType executeType,
        //    string ruleName,
        //    DataSet refData,
        //    string inputTableName,
        //    string outputTableName)
        //{
        //    string[] strParam = ruleName.Split('_');

        //    return ExecuteService(sender, executeType, strParam[0], ruleName, refData, inputTableName, outputTableName);
        //}

        public DataSet ExecuteService(
            object sender,
            string ruleName,
            string inputTableName,
            string outputTableName)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            string[] strParam = ruleName.Split('_');

            return ExecuteService(sender, strParam[0], ruleName, refData, inputTableName, outputTableName);
        }

        public DataSet ExecuteService(
            object sender,
            string className,
            string ruleName,
            string inputTableName,
            string outputTableName)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            return ExecuteService(sender, className, ruleName, refData, inputTableName, outputTableName);
        }


        public DataSet ExecuteService(
            QBiz.emExecuteType executeType,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName)
        {
            string[] strParam = ruleName.Split('_');

            this._ExecuteType = executeType;

            return ExecuteService(null, strParam[0], ruleName, refData, inputTableName, outputTableName);
        }


        public DataSet ExecuteService(
            QBiz.emExecuteType executeType,
            string ruleName,
            string inputTableName,
            string outputTableName)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            string[] strParam = ruleName.Split('_');

            this._ExecuteType = executeType;

            return ExecuteService(null, strParam[0], ruleName, refData, inputTableName, outputTableName);
        }

        public DataSet ExecuteService(
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            string inputTableName,
            string outputTableName)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            this._ExecuteType = executeType;

            return ExecuteService(null, className, ruleName, refData, inputTableName, outputTableName);
        }

        public DataSet ExecuteService(
            object sender,
            string className,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName)
        {
#if DEBUG
            BizExecute.BizExecute bizExcute = null;

            try
            {

                bizExcute = new BizExecute.BizExecute(_ServerIP, _DBName);

                string strAssembly = "CUBIZ_BR";// +strParam[0].ToString();

                Assembly bizManager = Assembly.Load(strAssembly);

                Type assemType = null;

                try
                {
                    assemType = bizManager.GetType("B" + className.Substring(0, 3) + "." + className, true, true);
                }
                catch
                {
                    assemType = bizManager.GetType(className + "." + className, true, true);
                }

                object obj = Activator.CreateInstance(assemType);

                MethodInfo mi = assemType.GetMethod(ruleName);

                //사업장코드 자동 삽입
                foreach (DataTable dt in refData.Tables)
                {
                    if (!dt.Columns.Contains("PLT_CODE"))
                    {
                        dt.Columns.Add("PLT_CODE", typeof(string));
                        DataRow row = dt.NewRow();
                        row["PLT_CODE"] = ConnInfo.PLT_CODE;
                    }
                }

                object result = mi.Invoke(obj, new object[] { refData, bizExcute });

                #region execute log
                if (this._ExecuteType != QBiz.emExecuteType.NONE)
                {
                    try
                    {
                        string useSe = QBiz.GetExecuteLogTypeString(this._ExecuteType);
                        Type assemLog = bizManager.GetType("CTRL.CTRL", true, true);
                        object logObj = Activator.CreateInstance(assemLog);
                        MethodInfo miLog = assemLog.GetMethod("EXECUTE_LOG");
                        DataTable dtLog = new DataTable("RQSTDT");
                        dtLog.Columns.Add("useSe", typeof(string));
                        dtLog.Columns.Add("dataUsgqty", typeof(int));
                        dtLog.Columns.Add("ruleName", typeof(string));
                        DataRow logRow = dtLog.NewRow();
                        logRow["useSe"] = useSe;
                        using (Stream s = new MemoryStream())
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(s, result);
                            logRow["dataUsgqty"] = s.Length;
                        }
                        logRow["ruleName"] = ruleName;
                        dtLog.Rows.Add(logRow);
                        DataSet logData = new DataSet();
                        logData.Tables.Add(dtLog);
                        object logResult = miLog.Invoke(logObj, new object[] { logData, bizExcute });
                    }
                    catch { }
                    
                }
                #endregion

                bizExcute.commitClose();
                //BizExecuteRun.BizConn.commitClose();

                return (DataSet)result;

            }
            catch (Exception ex)
            {
                if (!bizExcute.isNull()) bizExcute.rollbackClose();

                if (ex.InnerException != null) ex = ex.InnerException;

                BizException bizEx = new BizException(ex.Message, ex);

                bizEx.RefDataIdx = 0;

                string message = bizEx.Message.Replace(" ", string.Empty);


                if (ex.Data.Contains("DATA"))
                {
                    if (ExtensionMethod.isNumeric(ex.Data["DATA"].ToString()))
                    {
                        bizEx.ErrNumber = ex.Data["DATA"].toInt32();
                    }

                }

                //Biz 사용자정의 에러 생성

                int start = message.IndexOf('[');

                int end = message.IndexOf(']');

                if (start >= 0 || end >= 0)
                {

                    string parameterString = message.Substring(start + 1, (end - start) - 1);


                    string[] parameters = parameterString.Split(';');


                    foreach (string parameter in parameters)
                    {
                        string[] ps = parameter.Split('=');

                        if (ps.Length > 1) bizEx.ParameterDic.Add(ps[0], ps[1]);

                    }



                    //if (bizEx.ParameterDic.Count != 0)
                    if (bizEx.Data.Contains("ROW"))
                    {
                        bizEx.ParameterData = new DataTable();

                        Dictionary<string, object> dics = (Dictionary<string, object>)(bizEx.Data["ROW"]);

                        foreach (KeyValuePair<string, object> dic in dics)
                        {
                            switch (dic.Value.GetType().ToString())
                            {
                                case "System.String":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(string));
                                    break;
                                case "System.DateTime":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(DateTime));
                                    break;
                                case "System.Int32":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(int));
                                    break;
                                case "System.Decimal":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(decimal));
                                    break;
                                case "System.Byte":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(byte));
                                    break;
                                default:
                                    bizEx.ParameterData.Columns.Add(dic.Key);
                                    break;
                            }
                            //bizEx.ParameterData.Columns.Add(dic.Key,dic.Value.GetType());

                        }
                        //foreach(DataColumn col in ((DataRow)bizEx.Data["ROW"]).Table.Columns)
                        //{
                        //    bizEx.ParameterData.Columns.Add(col.ColumnName);
                        //}

                        DataRow paramRow = bizEx.ParameterData.NewRow();

                        foreach (DataColumn col in bizEx.ParameterData.Columns)
                        {
                            paramRow[col.ColumnName] = dics[col.ColumnName];
                        }

                        bizEx.ParameterData.Rows.Add(paramRow);

                    }
                }
                throw bizEx;
            }
#else
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConnInfo.ApiUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    refData.WriteXml(sw, XmlWriteMode.WriteSchema);

                    JsonObjectCollection jsonObj = new JsonObjectCollection();
                    jsonObj.Add(new JsonStringValue("EXECUTE_TYPE", executeType));
                    jsonObj.Add(new JsonStringValue("CLASS_NAME", className));
                    jsonObj.Add(new JsonStringValue("RULE_NAME", ruleName));
                    jsonObj.Add(new JsonStringValue("USER_ID", ConnInfo.UserID));
                    jsonObj.Add(new JsonStringValue("DATA", sw.ToString()));

                    streamWriter.Write(jsonObj);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    if (result.isNullOrEmpty()) return null;

                    StringReader xmlSr = new StringReader(result);

                    DataSet paramSet = new DataSet();
                    paramSet.ReadXml(xmlSr, XmlReadMode.Auto);

                    return paramSet;
                }
            }
            catch (Exception ex)
            {
                BizException bizEx = new BizException(ex.Message, ex);
                bizEx.RefDataIdx = 0;
                string message = bizEx.Message.Replace(" ", string.Empty);

                if (ex.Data.Contains("DATA"))
                {
                    if (ExtensionMethod.isNumeric(ex.Data["DATA"].ToString()))
                    {
                        bizEx.ErrNumber = ex.Data["DATA"].toInt32();
                    }
                }

                //Biz 사용자정의 에러 생성
                int start = message.IndexOf('[');
                int end = message.IndexOf(']');

                if (start >= 0 || end >= 0)
                {
                    string parameterString = message.Substring(start + 1, (end - start) - 1);
                    string[] parameters = parameterString.Split(';');

                    foreach (string parameter in parameters)
                    {
                        string[] ps = parameter.Split('=');
                        if (ps.Length > 1) bizEx.ParameterDic.Add(ps[0], ps[1]);
                    }

                    if (bizEx.Data.Contains("ROW"))
                    {
                        bizEx.ParameterData = new DataTable();
                        Dictionary<string, object> dics = (Dictionary<string, object>)(bizEx.Data["ROW"]);

                        foreach (KeyValuePair<string, object> dic in dics)
                        {
                            switch (dic.Value.GetType().ToString())
                            {
                                case "System.String":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(string));
                                    break;
                                case "System.DateTime":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(DateTime));
                                    break;
                                case "System.Int32":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(int));
                                    break;
                                case "System.Decimal":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(decimal));
                                    break;
                                case "System.Byte":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(byte));
                                    break;
                                default:
                                    bizEx.ParameterData.Columns.Add(dic.Key);
                                    break;
                            }

                        }
                        DataRow paramRow = bizEx.ParameterData.NewRow();

                        foreach (DataColumn col in bizEx.ParameterData.Columns)
                        {
                            paramRow[col.ColumnName] = dics[col.ColumnName];
                        }

                        bizEx.ParameterData.Rows.Add(paramRow);

                    }
                }
                throw bizEx;
            }
#endif
        }

        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string ruleName,
            string inputTableName,
            string outputTableName,
            object parameter,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            string[] strParam = ruleName.Split('_');

            ExecuteService(parentControl, executeType, strParam[0], ruleName, refData
                        , inputTableName, outputTableName, parameter, completeCallBack, customExceptionCallBack);

        }

        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            string inputTableName,
            string outputTableName,
            object parameter,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {
            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            ExecuteService(parentControl, executeType, className, ruleName, refData
                        , inputTableName, outputTableName, parameter, completeCallBack, customExceptionCallBack);

        }

        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName,
            object parameter,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {
            string[] strParam = ruleName.Split('_');

            ExecuteService(parentControl, executeType, strParam[0], ruleName, refData
                        , inputTableName, outputTableName, parameter, completeCallBack, customExceptionCallBack);

        }


        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName,
            object parameter,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {




            QBiz q = new QBiz(_ServerIP, _DBName);

            q.ExecuteType = executeType;
            q.ParentControl = parentControl;
            q.RefData = refData;
            q.className = className;
            q.RuleName = ruleName;
            q.InputTableName = inputTableName;
            q.OutputTableName = outputTableName;
            q.Parameter = parameter;

            q.UseThreadPool = false;

            q.CompleteCallBack = completeCallBack;
            q.ExcuteExceptionCallBack = customExceptionCallBack;

            q.Start();



        }

        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string ruleName,
            string inputTableName,
            string outputTableName,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {

            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            string[] strParam = ruleName.Split('_');

            ExecuteService(parentControl, executeType, strParam[0], ruleName, refData
                          , inputTableName, outputTableName, completeCallBack, customExceptionCallBack);
        }


        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            string inputTableName,
            string outputTableName,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {

            DataTable table = new DataTable("RQSTDT");
            table.Columns.Add("PLT_CODE", typeof(string));
            DataRow row = table.NewRow();
            row["PLT_CODE"] = ConnInfo.PLT_CODE;
            table.Rows.Add(row);
            DataSet refData = new DataSet();
            refData.Tables.Add(table);

            ExecuteService(parentControl, executeType, className, ruleName, refData
                          , inputTableName, outputTableName, completeCallBack, customExceptionCallBack);
        }

        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {

            string[] strParam = ruleName.Split('_');

            ExecuteService(parentControl, executeType, strParam[0], ruleName, refData
                          , inputTableName, outputTableName, completeCallBack, customExceptionCallBack);
        }


        public void ExecuteService(
            Control parentControl,
            QBiz.emExecuteType executeType,
            string className,
            string ruleName,
            DataSet refData,
            string inputTableName,
            string outputTableName,
            QBiz.ExecuteCompleateInvoker completeCallBack,
            QBiz.ExecuteExceptionInvoker customExceptionCallBack)
        {




            QBiz q = new QBiz(_ServerIP, _DBName);

            q.ExecuteType = executeType;
            q.ParentControl = parentControl;
            q.RefData = refData;
            q.className = className;
            q.RuleName = ruleName;
            q.InputTableName = inputTableName;
            q.OutputTableName = outputTableName;

            q.UseThreadPool = false;

            q.CompleteCallBack = completeCallBack;
            q.ExcuteExceptionCallBack = customExceptionCallBack;

            q.Start();



        }


        public DataSet ExecuteMultiService(
                object sender,
                string ruleName,
                List<DataSet> refDatas,
                string inputTableName,
                string outputTableName)
        {
            string[] strParam = ruleName.Split('_');

            return ExecuteMultiService(sender, strParam[0], ruleName, refDatas, inputTableName, outputTableName);
        }



        public DataSet ExecuteMultiService(
                object sender,
                string className,
                string ruleName,
                List<DataSet> refDatas,
                string inputTableName,
                string outputTableName)
        {

            int refIdx = 0;

            BizExecute.BizExecute bizExcute = null;

            try
            {
                List<DataSet> resultSets = new List<DataSet>();

                bizExcute = new BizExecute.BizExecute(_ServerIP, _DBName);

                foreach (DataSet refData in refDatas)
                {
                    //string[] strParam = ruleName.Split('_');

                    string strAssembly = "CUBIZ_BR";// +strParam[0].ToString();

                    Assembly bizManager = Assembly.Load(strAssembly);

                    Type assemType = null;

                    try
                    {
                        bizManager.GetType("B" + className.Substring(0, 3) + "." + className, true, true);
                    }
                    catch
                    {
                        bizManager.GetType(className + "." + className, true, true);
                    }


                    bizExcute = new BizExecute.BizExecute(this._ServerIP, this._DBName);

                    object obj = Activator.CreateInstance(assemType);

                    MethodInfo mi = assemType.GetMethod(ruleName);

                    //사업장코드 자동 삽입
                    foreach (DataTable dt in refData.Tables)
                    {
                        if (!dt.Columns.Contains("PLT_CODE"))
                        {
                            dt.Columns.Add("PLT_CODE", typeof(string));
                            DataRow row = dt.NewRow();
                            row["PLT_CODE"] = ConnInfo.PLT_CODE;
                        }
                    }

                    object result = mi.Invoke(obj, new object[] { refData, bizExcute });

                    DataSet resultSet = (DataSet)result;

                    resultSets.Add(resultSet);

                    ++refIdx;
                }

                if (resultSets.Count > 1)
                {
                    for (int i = 1; i < resultSets.Count; i++)
                    {
                        foreach (DataTable dt in resultSets[i].Tables)
                        {
                            resultSets[0].Tables[dt.TableName].Load(new DataTableReader(dt), LoadOption.OverwriteChanges);
                        }
                    }
                }

                BizExecuteRun.BizConn.commitClose();

                return resultSets[0];

            }
            catch (Exception ex)
            {
                if (BizExecuteRun.BizConn != null) BizExecuteRun.BizConn.rollbackClose();

                if (ex.InnerException != null) ex = ex.InnerException;

                BizException bizEx = new BizException(ex.Message, ex);

                bizEx.RefDataIdx = refIdx;

                string message = bizEx.Message.Replace(" ", string.Empty);


                if (ex.Data.Contains("DATA"))
                {
                    if (ExtensionMethod.isNumeric(ex.Data["DATA"].ToString()))
                    {
                        bizEx.ErrNumber = ex.Data["DATA"].toInt32();
                    }

                }

                //Biz 사용자정의 에러 생성

                int start = message.IndexOf('[');

                int end = message.IndexOf(']');

                if (start >= 0 || end >= 0)
                {

                    string parameterString = message.Substring(start + 1, (end - start) - 1);


                    string[] parameters = parameterString.Split(';');


                    foreach (string parameter in parameters)
                    {
                        string[] ps = parameter.Split('=');

                        bizEx.ParameterDic.Add(ps[0], ps[1]);

                    }


                    //if (bizEx.ParameterDic.Count != 0)
                    if (bizEx.Data.Contains("ROW"))
                    {
                        bizEx.ParameterData = new DataTable();

                        Dictionary<string, object> dics = (Dictionary<string, object>)(bizEx.Data["ROW"]);

                        foreach (KeyValuePair<string, object> dic in dics)
                        {
                            switch (dic.Value.GetType().ToString())
                            {
                                case "System.String":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(string));
                                    break;
                                case "System.DateTime":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(DateTime));
                                    break;
                                case "System.Int32":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(int));
                                    break;
                                case "System.Decimal":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(decimal));
                                    break;
                                case "System.Byte":
                                    bizEx.ParameterData.Columns.Add(dic.Key, typeof(byte));
                                    break;
                                default:
                                    bizEx.ParameterData.Columns.Add(dic.Key);
                                    break;
                            }
                            //bizEx.ParameterData.Columns.Add(dic.Key,dic.Value.GetType());

                        }
                        //foreach(DataColumn col in ((DataRow)bizEx.Data["ROW"]).Table.Columns)
                        //{
                        //    bizEx.ParameterData.Columns.Add(col.ColumnName);
                        //}

                        DataRow paramRow = bizEx.ParameterData.NewRow();

                        foreach (DataColumn col in bizEx.ParameterData.Columns)
                        {
                            paramRow[col.ColumnName] = dics[col.ColumnName];
                        }

                        bizEx.ParameterData.Rows.Add(paramRow);

                    }



                }



                throw bizEx;


            }


        }

        public void ExecuteMultiService(
    Control parentControl,
    QBiz.emExecuteType executeType,
    string ruleName,
    List<DataSet> refDatas,
    string inputTableName,
    string outputTableName,
    QBizMulti.ExecuteCompleateInvoker completeCallBack,
    QBizMulti.ExecuteExceptionInvoker customExceptionCallBack)
        {
            string[] strParam = ruleName.Split('_');

            ExecuteMultiService(parentControl, executeType, strParam[0], ruleName, refDatas
                , inputTableName, outputTableName, completeCallBack, customExceptionCallBack);
        }

        public void ExecuteMultiService(
    Control parentControl,
    QBiz.emExecuteType executeType,
    string className,
    string ruleName,
    List<DataSet> refDatas,
    string inputTableName,
    string outputTableName,
    QBizMulti.ExecuteCompleateInvoker completeCallBack,
    QBizMulti.ExecuteExceptionInvoker customExceptionCallBack)
        {


            try
            {

                QBizMulti q = new QBizMulti(this._ServerIP, this._DBName);

                q.ExecuteType = executeType;
                q.ParentControl = parentControl;
                q.RefDatas = refDatas;
                q.className = className;
                q.RuleName = ruleName;
                q.InputTableName = inputTableName;
                q.OutputTableName = outputTableName;

                q.CompleteCallBack = completeCallBack;
                q.ExecuteExceptionCallBack = customExceptionCallBack;

                q.Start();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
