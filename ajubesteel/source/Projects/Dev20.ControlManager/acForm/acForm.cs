using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using DevExpress.Utils;
using System.Security.Permissions;
using BizManager;

namespace ControlManager
{
    public class acForm : DevExpress.XtraEditors.XtraForm, IBaseViewControl, IControl
    {

        private static Dictionary<string, acFormUserConfig> _UserConfigs = new Dictionary<string, acFormUserConfig>();

        public static void ClearUserConfig()
        {
            acForm._UserConfigs.Clear();
        }

        public static void RemoveUserConifg(string parentClassName)
        {
            List<string> removeKey = new List<string>();

            foreach (KeyValuePair<string, acFormUserConfig> uc in acForm._UserConfigs)
            {
                string[] names = uc.Key.Split(',');

                string className = names[0];
                string controlName = names[1];

                if (className == parentClassName)
                {
                    removeKey.Add(uc.Key);
                }
            }

            foreach (string key in removeKey)
            {
                acForm._UserConfigs.Remove(key);

            }
        }


        public static void SaveUserConfig()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //
            paramTable.Columns.Add("CONFIG_NAME", typeof(String)); //
            paramTable.Columns.Add("DEFAULT_USE", typeof(String)); //기본UI로 설정
            paramTable.Columns.Add("LAYOUT", typeof(Byte[])); //
            paramTable.Columns.Add("OBJECT", typeof(Byte[])); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


            foreach (KeyValuePair<string, acFormUserConfig> uc in acForm._UserConfigs)
            {
                string[] names = uc.Key.Split(',');

                string className = names[0];
                string controlName = names[1];

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;

                paramRow["CLASS_NAME"] = className;

                paramRow["CONTROL_NAME"] = controlName;
                paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
                paramRow["DEFAULT_USE"] = "1";
                paramRow["LAYOUT"] = null;
                paramRow["OBJECT"] = uc.Value.ToArray();
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL","SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");

            acForm._UserConfigs.Clear();
        }


       
        public static string GetClassName()
        {
            return "acForm";
        }

        private Control _ParentControl = null;

        /// <summary>
        /// 부모컨트롤
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set
            {
                _ParentControl = value;

            }
        }


        public acForm()
            : base()
        {



        }







        private object _FormKey = null;


        /// <summary>
        /// 창키값
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object FormKey
        {
            get { return _FormKey; }
            set { _FormKey = value; }
        }


        private object _OutputData = null;

        
        /// <summary>
        /// 출력데이터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object OutputData
        {
            get { return _OutputData; }
            set { _OutputData = value; }
        }


        private object _Parameter = null;



        /// <summary>
        /// 입력데이터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }


        private object _InitRefData = null;


        /// <summary>
        /// 초기화시 참조데이터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object InitRefData
        {
            get { return _InitRefData; }
            set { _InitRefData = value; }
        }



        public delegate void CloseHander(object sender);

        public event CloseHander OnClose;

        protected override void OnClosed(EventArgs e)
        {


            //닫을때 창크기 저장

            try
            {
                if (this._ParentControl != null)
                {

                    acFormUserConfig config = new acFormUserConfig(this);


                    string key = string.Format("{0},{1}", this.ParentControl.Name, this.Name);

                    if (!acForm._UserConfigs.ContainsKey(key))
                    {
                        acForm._UserConfigs.Add(key, config);
                    }
                    else
                    {
                        acForm._UserConfigs[key] = config;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            base.OnClosed(e);

            if (this.OnClose != null)
            {
                this.OnClose(this);
            }

            if (this.ParentControl is IControl)
            {
                (this.ParentControl as IControl).FocusContainer();
            }
        }



        public static Point GetCenterLocation(Rectangle parentRect, Rectangle childRect)
        {
            int x = parentRect.X + ((parentRect.Width / 2) - (childRect.Width / 2));

            int y = parentRect.Y + ((parentRect.Height / 2) - (childRect.Height / 2));

            return new Point(x, y);
        }

        /// <summary>
        /// 다이얼로그 화면을 특정범위 중앙에 위치하도록한다.
        /// </summary>
        /// <param name="parent"></param>
        public void SetPosition(Rectangle parentRectangle)
        {
            this.StartPosition = FormStartPosition.Manual;

            Point pt = GetCenterLocation(parentRectangle, new Rectangle(0, 0, this.Width, this.Height));

            this.Location = pt;

        }





        private string _InstantLog = null;


        /// <summary>
        /// 순간 로그
        /// </summary>
        public virtual string InstantLog
        {
            set { _InstantLog = value; }
        }




        protected override void OnLoad(EventArgs e)
        {


            base.OnLoad(e);

            
            try
            {
                if (acInfo.IsRunTime == true)
                {

                    


                    acFormUserConfig config = null;

                    string key = string.Format("{0},{1}", this.ParentControl.Name, this.Name);

                    if (acForm._UserConfigs.ContainsKey(key))
                    {
                        config = acForm._UserConfigs[key];



                    }
                    else
                    {
                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
                        paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EMP_CODE"] = acInfo.UserID;
                        paramRow["CLASS_NAME"] = this.ParentControl.Name;
                        paramRow["CONTROL_NAME"] = this.Name;
                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);


                        DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                                                
                        if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                        {

                            byte[] configData = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];

                            MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                            BinaryFormatter bformatter = new BinaryFormatter();
                            bformatter.Binder = new acFormUserConfigSerializationBinder();

                            config = (acFormUserConfig)bformatter.Deserialize(loadConfigSt);


                        }
                        
                    }

                    if (config != null)
                    {
                        this.Size = config.FormSize;
                        this.Location = config.FormLocation;

                        //화면 범위에 들지않으면 중앙에 위치하도록 설정
                        if (this.isScreen() == false)
                        {

                            this.SetPosition(Screen.PrimaryScreen.WorkingArea);
                        }

                    }
                    else
                    {
                        this.CenterToParent();
                    }

                    if (this._UseResourceID == true)
                    {
                        //리소스 설정

                        this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);

                    }

                    if (this._UseToolTipID == true)
                    {
                        //툴팁 타이틀로 설정

                        if (acInfo.ToolTip.IsToolTip(this._ToolTipID))
                        {
                            ToolTipTitleItem title = acInfo.ToolTip.GetToolTip(this._ToolTipID).Items[0] as ToolTipTitleItem;

                            this.Text = title.Text;
                        }
                        else
                        {
                            this.Text = string.Empty;
                        }

                    }



                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 스크린 범위안에 드는지 확인한다.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        bool isScreen()
        {

            Rectangle rect = new Rectangle(this.Location, this.Size);

            foreach (Screen scrn in Screen.AllScreens)
            {

                if (scrn.Bounds.Contains(rect))
                {
                    return true;
                }

            }

            return false;

        }





        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }


        #endregion



        #region IControl 멤버

        public void FocusContainer()
        {
            this.Focus();
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // acForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "acForm";
            //this.Load += new System.EventHandler(this.acForm_Load);
            this.ResumeLayout(false);

        }
    }
}
