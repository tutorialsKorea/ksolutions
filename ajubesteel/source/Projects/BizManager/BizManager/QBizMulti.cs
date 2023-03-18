using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using System.Data.SqlClient;
using System.Reflection;
using BizExecute;
using System.Runtime.Serialization.Formatters.Binary;

namespace BizManager
{

    public sealed partial class QBizMulti
    {

        public class ExcuteCompleteArgs
        {
            public string className = null;

            public string ruleName = null;

            public DataSet result = null;

            public TimeSpan executeTime = TimeSpan.MinValue;

            public QBiz.emExecuteType executeType = QBiz.emExecuteType.NONE;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">요청컨트롤</param>
        /// <param name="ruleName">Biz Rule</param>
        /// <param name="data">결과 데이터</param>
        /// <param name="executeTime">실행시간</param>
        public delegate void ExecuteCompleateInvoker(
            object sender,
            QBizMulti qBizMulti,
            ExcuteCompleteArgs e
            );



        /// <summary>
        /// 사용자 정의 예외발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="QBizMulti"></param>
        /// <param name="errorNumber"></param>
        public delegate void ExecuteExceptionInvoker(
            object sender,
            QBizMulti qBizMulti,
            BizException ex);


        private string _ServerIP = string.Empty;
        private string _DbName = string.Empty;



        public QBizMulti(string serverip, string dbname)
        {
            this._ServerIP = serverip;
            this._DbName = dbname;
        }


        private Control _ParentControl = null;

        public Control ParentControl
        {
            get { return _ParentControl; }
            set { _ParentControl = value; }
        }

        private QBiz.emExecuteType _ExecuteType = QBiz.emExecuteType.NONE;

        public QBiz.emExecuteType ExecuteType
        {
            get { return _ExecuteType; }
            set { _ExecuteType = value; }
        }

        private string _ClassName = null;

        public string className
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        private string _RuleName = null;

        public string RuleName
        {
            get { return _RuleName; }
            set { _RuleName = value; }
        }

        private List<DataSet> _RefDatas = null;

        public List<DataSet> RefDatas
        {
            get { return _RefDatas; }
            set { _RefDatas = value; }
        }

        private string _InputTableName = null;

        public string InputTableName
        {
            get { return _InputTableName; }
            set { _InputTableName = value; }
        }

        private string _OutputTableName = null;

        public string OutputTableName
        {
            get { return _OutputTableName; }
            set { _OutputTableName = value; }
        }

        private ExecuteCompleateInvoker _CompleteCallBack = null;

        public ExecuteCompleateInvoker CompleteCallBack
        {
            get { return _CompleteCallBack; }
            set { _CompleteCallBack = value; }
        }

        private ExecuteExceptionInvoker _ExecuteExceptionCallBack = null;

        public ExecuteExceptionInvoker ExecuteExceptionCallBack
        {
            get { return _ExecuteExceptionCallBack; }
            set { _ExecuteExceptionCallBack = value; }
        }



        public QBizMulti()
        {

        }


        private QProgress _QBizMultiProgress = null;


        private Control _FocusControl = null;

        /// <summary>
        /// 서비스를 실행합니다.
        /// </summary>
        /// <param name="parentControl">호출하는 컨트롤</param>
        /// <param name="executeType">실행타입</param>
        /// <param name="ruleName">서비스이름</param>
        /// <param name="refData">데이터셋</param>
        /// <param name="inputTableName">입력테이블명</param>
        /// <param name="outputTableName">결과테이블명</param>
        /// <param name="completeCallBack">완료후 콜백함수</param>
        public void Start()
        {


            ParameterizedThreadStart paramThread = new ParameterizedThreadStart(ThreadProcessing);

            Thread searchThead = new Thread(paramThread);

            searchThead.Start(new object[] { });


            //진행바 표시여부
            bool progressVisible = false;


            //진행바 텍스트
            string progressCaption = null;

            //진행바 닫기여부
            bool progressCloseButton = false;


            switch (_ExecuteType)
            {
                case QBiz.emExecuteType.NONE:

                    progressVisible = false;

                    break;

                case QBiz.emExecuteType.LOAD:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("읽는중...", "0O0BPWD8");
                    progressCaption = "읽는중...";

                    progressCloseButton = true;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;

                case QBiz.emExecuteType.REFRESH:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("새로고침중...", "OBEGGOQ8");
                    progressCaption = "새로고침중...";

                    progressCloseButton = true;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);


                    this.SetControlEnbled(_ParentControl, false);

                    break;


                case QBiz.emExecuteType.LOAD_DETAIL:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("상세정보 읽는중...", "TFJJKJGQ");
                    progressCaption = "상세정보 읽는중...";

                    progressCloseButton = true;

                    break;

                case QBiz.emExecuteType.NEW:
                case QBiz.emExecuteType.SAVE:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("저장중...", "11PE5VS5");
                    progressCaption = "저장중...";

                    progressCloseButton = false;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;

                case QBiz.emExecuteType.DEL:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("삭제중...", "P8O6W3AI");
                    progressCaption = "삭제중...";

                    progressCloseButton = false;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);

                    this.SetControlEnbled(_ParentControl, false);

                    break;


                case QBiz.emExecuteType.PROCESS:

                    progressVisible = true;

                    //progressCaption = acInfo.Resource.GetString("처리중...", "RW353VO6");
                    progressCaption = "처리중...";

                    progressCloseButton = false;

                    //현재 포커스를 찾는다.
                    this.FindFocusControl(_ParentControl, ref _FocusControl);


                    this.SetControlEnbled(_ParentControl, false);

                    break;


            }

            if (progressVisible == true)
            {
                this._QBizMultiProgress = new QProgress(progressCaption, progressCloseButton);


                this._QBizMultiProgress.OnClose += new QProgress.CloseEventHandler(_QBizMultiProgress_OnClose);

                if (_ParentControl.Parent != null)
                {
                    _ParentControl.Parent.Controls.Add(_QBizMultiProgress);
                }
                else
                {
                    _ParentControl.Controls.Add(_QBizMultiProgress);
                }



                int x = (_ParentControl.Width / 2) - (_QBizMultiProgress.Width / 2);
                int y = (_ParentControl.Height / 2) - (_QBizMultiProgress.Height / 2);

                _QBizMultiProgress.Location = new System.Drawing.Point(x, y);

                _QBizMultiProgress.BringToFront();

            }




        }

        private bool _IsThreadAbort = false;


        public void Abort()
        {
            this._IsThreadAbort = true;

            if (this._ParentControl.IsHandleCreated == true)
            {
                this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
            }
        }



        /// <summary>
        /// 현재 포커스를 가진 컨트롤을 찾는다.
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="focusControl"></param>
        private void FindFocusControl(Control rootControl, ref Control focusControl)
        {
            foreach (Control child in rootControl.Controls)
            {
                if (child.Controls.Count != 0)
                {
                    FindFocusControl(child, ref focusControl);
                }

                if (child.Focused == true)
                {
                    focusControl = child;

                    return;
                }
            }

        }



        /// <summary>
        /// 컨트롤을 비활성화 한다.
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="enbled"></param>
        private void SetControlEnbled(Control rootControl, bool enbled)
        {

            if (rootControl.Parent != null)
            {

                foreach (Control child in rootControl.Parent.Controls)
                {
                    child.Enabled = enbled;
                }
            }
            else
            {
                foreach (Control child in rootControl.Controls)
                {
                    child.Enabled = enbled;
                }

            }

        }




        void _QBizMultiProgress_OnClose()
        {
            this._IsThreadAbort = true;

            if (this._ParentControl.IsHandleCreated == true)
            {
                this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
            }

        }




        private void ThreadProcessing(object args)
        {


            int refIdx = 0;

            BizExecute.BizExecute bizExcute = null;

            try
            {                

                List<DataSet> resultSets = new List<DataSet>();


                DateTime startTime = DateTime.Now;

                string strAssembly = "CUBIZ_BR";// +strParam[0].ToString();

                Assembly bizManager = bizManager = Assembly.Load(strAssembly);

                Type assemType = null;

                foreach (DataSet refData in this._RefDatas)
                {

                    this._ParentControl.BeginInvoke((MethodInvoker)delegate
                    {

                        this._QBizMultiProgress.SetCount(refIdx, this._RefDatas.Count);

                    });

                    try
                    {
                        assemType = bizManager.GetType("B" + this._ClassName.Substring(0, 3) + "." + this._ClassName, true, true);
                    }
                    catch
                    {
                        assemType = bizManager.GetType(this._ClassName + "." + this._ClassName, true, true);
                    }

                    bizExcute = new BizExecute.BizExecute(this._ServerIP, this._DbName);

                    object obj = Activator.CreateInstance(assemType);

                    MethodInfo mi = assemType.GetMethod(this._RuleName);

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


                #region execute log
                Type assemLog = bizManager.GetType("CTRL.CTRL", true, true);
                object logObj = Activator.CreateInstance(assemLog);
                MethodInfo miLog = assemLog.GetMethod("EXECUTE_LOG");
                DataTable dtLog = new DataTable("RQSTDT");
                dtLog.Columns.Add("useSe", typeof(string));
                dtLog.Columns.Add("dataUsgqty", typeof(int));
                dtLog.Columns.Add("ruleName", typeof(string));
                DataRow logRow = dtLog.NewRow();
                logRow["useSe"] = QBiz.GetExecuteLogTypeString(this._ExecuteType);
                using (Stream s = new MemoryStream())
                {
                    foreach (DataSet ds in resultSets)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(s, ds);
                        logRow["dataUsgqty"] = logRow["dataUsgqty"].toInt() + s.Length;
                    }
                }
                logRow["ruleName"] = this._RuleName;
                dtLog.Rows.Add(logRow);
                DataSet logData = new DataSet();
                logData.Tables.Add(dtLog);
                object logResult = miLog.Invoke(logObj, new object[] { logData, bizExcute });
                #endregion


                DateTime endTime = DateTime.Now;

                TimeSpan executeTime = endTime.Subtract(startTime);



                if (this._IsThreadAbort == false)
                {
                    if (this._ExecuteType != QBiz.emExecuteType.NONE)
                    {
                        if (this._ParentControl.IsHandleCreated == true)
                        {
                            this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
                        }

                    }


                    ExcuteCompleteArgs e = new ExcuteCompleteArgs();

                    e.ruleName = this._RuleName;
                    e.result = resultSets[0];
                    e.executeTime = executeTime;
                    e.executeType = this._ExecuteType;

                    if (this._ParentControl.IsHandleCreated == true)
                    {
                        this.ParentControl.BeginInvoke(this._CompleteCallBack, this._ParentControl, this, e);

                    }

                }
                bizExcute.commitClose();
            }
            catch (Exception ex)
            {

                //쓰레드 종료가 아니면 예외를 처리한다.

                //쓰레드 종료가 아니면 예외를 처리한다.
                if (bizExcute != null) bizExcute.rollbackClose();

                if (this._IsThreadAbort == false)
                {


                    if (this._ExecuteType != QBiz.emExecuteType.NONE)
                    {
                        if (this._ParentControl.IsHandleCreated == true)
                        {
                            this._ParentControl.BeginInvoke(new MethodInvoker(ProgressClose));
                        }

                    }

                    if (ex.InnerException != null) ex = ex.InnerException; 

                    BizException bizEx = new BizException(ex.Message, ex);

                    bizEx.RefDataIdx = refIdx;

                    if (ex.Data.Contains("LOC"))
                    {
                        bizEx.Data.Add("LOC", ex.Data["LOC"]);
                    }

                    if (ex.Data.Contains("DATA"))
                    {
                        bizEx.Data.Add("DATA", ex.Data["DATA"]);
                    }

                    string message = bizEx.Message.Replace(" ", string.Empty);


                    if (bizEx.Data.Contains("DATA"))
                    {

                        if (ExtensionMethod.isNumeric(bizEx.Data["DATA"].ToString()))
                        {
                            //Biz 사용자정의 에러 생성
                            bizEx.ErrNumber = ex.Data["DATA"].toInt32();

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
                                //bizEx.ParameterData.Rows.Add((DataRow)bizEx.Data["ROW"]);
                            }

                            //bizEx.ParameterData = new DataTable();

                            //foreach (KeyValuePair<string, string> dic in bizEx.ParameterDic)
                            //{
                            //    bizEx.ParameterData.Columns.Add(dic.Key);
                            //}

                            //DataRow paramRow = bizEx.ParameterData.NewRow();

                            //foreach (DataColumn col in bizEx.ParameterData.Columns)
                            //{
                            //    paramRow[col.ColumnName] = bizEx.ParameterDic[col.ColumnName];
                            //}

                            //bizEx.ParameterData.Rows.Add(paramRow);

                            if (this._ParentControl.IsHandleCreated == true)
                            {
                                this._ParentControl.BeginInvoke(this._ExecuteExceptionCallBack, this._ParentControl, this, bizEx);
                            }

                        }
                        else
                        {
                            if (this._ParentControl.IsHandleCreated == true)
                            {
                                this._ParentControl.BeginInvoke(this._ExecuteExceptionCallBack, this._ParentControl, this, bizEx);

                            }
                        }

                    }
                    else
                    {
                        if (this._ParentControl.IsHandleCreated == true)
                        {
                            this._ParentControl.BeginInvoke(this._ExecuteExceptionCallBack, this._ParentControl, this, bizEx);
                        }
                    }


                }

            }


        }


        private void ProgressClose()
        {

            if (_ParentControl.Parent != null)
            {
                _ParentControl.Parent.Controls.Remove(_QBizMultiProgress);

            }
            else
            {
                _ParentControl.Controls.Remove(_QBizMultiProgress);

            }

            _QBizMultiProgress.Dispose();

            this.SetControlEnbled(_ParentControl, true);

            //if (_FocusControl != null)
            //{
            //    if (_FocusControl is IBaseEditControl || _FocusControl is DevExpress.XtraEditors.TextBoxMaskBox)
            //    {
            //        _FocusControl.Focus();
            //    }
            //    else
            //    {
            //        Control ctrl = BaseMenu.GetBaseControl(_FocusControl);

            //        if (ctrl.Parent != null)
            //        {
            //            ctrl.Parent.Focus();
            //        }
            //        else
            //        {
            //            ctrl.Focus();
            //        }
            //    }

            //}

        }


    }


}
