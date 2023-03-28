using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using BizManager;

namespace ControlManager
{
    sealed class acDockManagerConfigSerializationBinder : SerializationBinder
    {

        public override Type BindToType(string assemblyName, string typeName)
        {

            Type returntype = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            returntype =
                Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));


            return returntype;

        }
    }

    [Serializable]
    public class acDockManagerConfig : ISerializable
    {



        private Dictionary<Guid, string> _ResourceDic = new Dictionary<Guid, string>();

        public Dictionary<Guid, string> ResourceDic
        {
            get { return _ResourceDic; }
            set { _ResourceDic = value; }
        }

        private Dictionary<Guid, bool> _UseResourceDic = new Dictionary<Guid, bool>();

        public Dictionary<Guid, bool> UseResourceDic
        {
            get { return _UseResourceDic; }
            set { _UseResourceDic = value; }
        }


        private Dictionary<Guid, bool> _DefaultPanelDic = new Dictionary<Guid, bool>();

        public Dictionary<Guid, bool> DefaultPanelDic
        {
            get { return _DefaultPanelDic; }
            set { _DefaultPanelDic = value; }
        }

        private acDockManager _DockManager = null;

        public acDockManagerConfig(acDockManager dockManager)
        {
            this._DockManager = dockManager;

            this.Save();

        }

        public acDockManagerConfig(acDockManager dockManager, byte[] layoutData, byte[] objectData)
        {
            this._DockManager = dockManager;

            this.Load(layoutData, objectData);

        }

        public void ReLoad()
        {
            this.Load(this.LayoutData, this.ObjectData);
        }

        public byte[] LayoutData = null;
        public byte[] ObjectData = null;


        private void Load(byte[] layoutData, byte[] configData)
        {
            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Binder = new acDockManagerConfigSerializationBinder();

            MemoryStream loadLayoutSt = new MemoryStream(layoutData, 0, layoutData.Length);

            MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);


            acDockManagerConfig config = (acDockManagerConfig)bformatter.Deserialize(loadConfigSt);


            this._DockManager.RestoreLayoutFromStream(loadLayoutSt);




            for (int i = 0; i < this._DockManager.Panels.Count; i++)
            {
                acDockPanel panel = this._DockManager.Panels[i] as acDockPanel;

                panel.ResourceID = config.ResourceDic[panel.ID];

                panel.UseResourceID = config.UseResourceDic[panel.ID];

                panel.IsDefaultPanel = config.DefaultPanelDic[panel.ID];

                if (panel.UseResourceID == true)
                {
                    panel.Text = acInfo.Resource.GetString(panel.Text, panel.ResourceID);
                }


            }

            this.DefaultPanelDic = config.DefaultPanelDic;
            this.ResourceDic = config.ResourceDic;
            this.UseResourceDic = config.UseResourceDic;


            loadLayoutSt.Close();

            loadConfigSt.Close();

        }


        public void Save()
        {
            try
            {
                MemoryStream layoutStream = new MemoryStream();
                MemoryStream objectStream = new MemoryStream();


                this._ResourceDic.Clear();
                this._UseResourceDic.Clear();
                this._DefaultPanelDic.Clear();


                for (int i = 0; i < this._DockManager.Panels.Count; i++)
                {
                    acDockPanel panel = this._DockManager.Panels[i] as acDockPanel;

                    this._ResourceDic.Add(panel.ID, panel.ResourceID);

                    this._UseResourceDic.Add(panel.ID, panel.UseResourceID);

                    this._DefaultPanelDic.Add(panel.ID, panel.IsDefaultPanel);
                }




                this._DockManager.SaveLayoutToStream(layoutStream);


                BinaryFormatter bformatter = new BinaryFormatter();

                bformatter.Serialize(objectStream, this);

                this.LayoutData = layoutStream.ToArray();

                this.ObjectData = objectStream.ToArray();

                layoutStream.Close();
                objectStream.Close();
            }
            catch { }
            
        }

        public acDockManagerConfig(SerializationInfo info, StreamingContext context)
        {


            try
            {
                this._ResourceDic = (Dictionary<Guid, string>)info.GetValue("ResourceDic", typeof(Dictionary<Guid, string>));
            }
            catch { }


            try
            {
                this._UseResourceDic = (Dictionary<Guid, bool>)info.GetValue("UseResourceDic", typeof(Dictionary<Guid, bool>));
            }
            catch { }


            try
            {
                this._DefaultPanelDic = (Dictionary<Guid, bool>)info.GetValue("DefaultPanelDic", typeof(Dictionary<Guid, bool>));
            }
            catch { }

        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {


            info.AddValue("ResourceDic", this._ResourceDic, typeof(Dictionary<Guid, string>));

            info.AddValue("UseResourceDic", this._UseResourceDic, typeof(Dictionary<Guid, bool>));

            info.AddValue("DefaultPanelDic", this._DefaultPanelDic, typeof(Dictionary<Guid, bool>));

        }

        #endregion



    }


    public class acDockManager : DevExpress.XtraBars.Docking.DockManager
    {
        private static Dictionary<string, acDockManagerConfig> _UserConfigs = new Dictionary<string, acDockManagerConfig>();

        public static void ClearUserConfig()
        {
            acDockManager._UserConfigs.Clear();
        }

        public static void RemoveUserConifg(string parentClassName)
        {
            List<string> removeKey = new List<string>();

            foreach (KeyValuePair<string, acDockManagerConfig> uc in acDockManager._UserConfigs)
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
                acDockManager._UserConfigs.Remove(key);

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

            foreach (KeyValuePair<string, acDockManagerConfig> uc in acDockManager._UserConfigs)
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
                paramRow["LAYOUT"] = uc.Value.LayoutData;
                paramRow["OBJECT"] = uc.Value.ObjectData;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);

            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL","SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            
            acDockManager._UserConfigs.Clear();
        }

        public static string GetClassName()
        {
            return "acDockManager";
        }

        public acDockManager()
            : base()
        {
            this.DockingOptions.ShowCloseButton = false;


        }
        public acDockManager(System.ComponentModel.IContainer container)
            : base(container)
        {
            this.DockingOptions.ShowCloseButton = false;

        }

        private List<Guid> _DefaultDockPanelList = new List<Guid>();

        private Dictionary<Guid, string> _ResourceDic = new Dictionary<Guid, string>();

        public override void EndInit()
        {
            base.EndInit();

            if (this.Form is BaseMenu)
            {
                BaseMenu b = this.Form as BaseMenu;

                b.OnMenuLoadManager += new BaseMenu.MenuLoadManagerEventHandler(acDockManager_OnMenuLoadManager);
                b.OnMenuLoadDockManager += new BaseMenu.MenuLoadDockManagerEventHandler(acDockManager_OnMenuLoadDockManager);
                b.OnMenuDestory += new BaseMenu.MenuDestoryEventHandler(acDockManager_OnMenuDestory);

            }
            else if (this.Form is BaseMenuDialog)
            {
                BaseMenuDialog b = this.Form as BaseMenuDialog;

                b.OnDialogLoadManager += new BaseMenuDialog.DialogLoadManagerEventHandler(acDockManager_OnDialogLoadManager);
                b.OnDialogLoadDockManager += new BaseMenuDialog.DialogLoadDockManagerEventHandler(acDockManager_OnDialogLoadDockManager);
                b.OnDialogDestory += new BaseMenuDialog.DialogDestoryEventHandler(acDockManager_OnDialogDestory);
            }
        }

        void acDockManager_OnDialogLoadDockManager(object sender)
        {
            this.LoadDefaultLayout();
        }

        void acDockManager_OnDialogLoadManager(object sender)
        {
            this.SaveSystemDefaultLayout();
        }

        void acDockManager_OnMenuLoadManager(object sender)
        {
            this.SaveSystemDefaultLayout();
        }


        void acDockManager_OnDialogDestory(object sender)
        {
            this.SaveDefaultLayout();
        }

        void acDockManager_OnMenuDestory(object sender)
        {
            this.SaveDefaultLayout();
        }

        void acDockManager_OnMenuLoadDockManager(object sender)
        {

            this.LoadDefaultLayout();
        }


        private acDockManagerConfig _SystemDefaultConfig = null;


        public void SaveSystemDefaultLayout()
        {
            this._SystemDefaultConfig = new acDockManagerConfig(this);


        }



        public void LoadSystemDefaultLayout()
        {

            this._SystemDefaultConfig.ReLoad();

            this.Form.Refresh();

            this.Form.Update();

        }


        /// <summary>
        /// 기본레이아웃을 불러온다.
        /// </summary>
        public void LoadDefaultLayout()
        {

            bool isSystemLayoutChanged = false;

            string key = string.Format("{0},{1}", this.Form.Name, GetClassName());

            acDockManagerConfig config = null;

            if (acDockManager._UserConfigs.ContainsKey(key))
            {
                config = acDockManager._UserConfigs[key];


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
                paramRow["CLASS_NAME"] = this.Form.Name;
                paramRow["CONTROL_NAME"] = "acDockManager";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");
                //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);
                if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                {


                    byte[] layout = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["LAYOUT"];

                    byte[] obj = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];


                    config = new acDockManagerConfig(this, layout, obj);


                }
  
            }


          

            if (config != null)
            {
                //추가된 판넬이 있는지 확인한다.

                foreach (KeyValuePair<Guid, bool> dic in this._SystemDefaultConfig.DefaultPanelDic)
                {
                    if (!config.DefaultPanelDic.ContainsKey(dic.Key))
                    {
                        isSystemLayoutChanged = true;

                        break;
                    }

                }


                //삭제된 판넬 있는지 확인한다.
                foreach (KeyValuePair<Guid, bool> dic in config.DefaultPanelDic)
                {
                    if (!this._SystemDefaultConfig.DefaultPanelDic.ContainsKey(dic.Key))
                    {
                        //isSystemLayoutChanged = true;

                        break;
                    }

                }
            }


            if (isSystemLayoutChanged == true)
            {
                this.LoadSystemDefaultLayout();

                acMessageBox.Show(this.Form, "추가기능으로 인하여 도킹 사용자 UI정보가 초기화되었습니다. 다시 실행합니다.", "O1R5SUW1", true, acMessageBox.emMessageBoxType.CONFIRM);

                if (this.Form is BaseMenu)
                {

                    BaseMenu b = this.Form as BaseMenu;

                    (b.Main as IMainControl).CloseMenu(b.Name);

                    (b.Main as IMainControl).MoveLinkMenu(b.MenuCode, null);
                }


            }

        }



        protected override DevExpress.XtraBars.Docking.DockPanel CreateDockPanel(DevExpress.XtraBars.Docking.DockingStyle dock, bool createControlContainer)
        {

            return new acDockPanel(createControlContainer, dock, this);
        }




        /// <summary>
        /// 기본레이아웃을 저장한다.
        /// </summary>
        public void SaveDefaultLayout()
        {

            acDockManagerConfig config = new acDockManagerConfig(this);

            if (this.Form == null) return;

            string key = string.Format("{0},{1}", this.Form.Name, GetClassName());

            if (!acDockManager._UserConfigs.ContainsKey(key))
            {
                acDockManager._UserConfigs.Add(key, config);
            }
            else
            {
                acDockManager._UserConfigs[key] = config;
            }

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            //paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            //paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //
            //paramTable.Columns.Add("CONFIG_NAME", typeof(String)); //
            //paramTable.Columns.Add("DEFAULT_USE", typeof(String)); //기본UI로 설정
            //paramTable.Columns.Add("LAYOUT", typeof(Byte[])); //
            //paramTable.Columns.Add("OBJECT", typeof(Byte[])); //
            //paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["EMP_CODE"] = acInfo.UserID;

            //paramRow["CLASS_NAME"] = this.Form.Name;

            //paramRow["CONTROL_NAME"] = "acDockManager";
            //paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
            //paramRow["DEFAULT_USE"] = "1";
            //paramRow["LAYOUT"] = config.LayoutData;
            //paramRow["OBJECT"] = config.ObjectData;
            //paramRow["OVERWRITE"] = "1";
            //paramTable.Rows.Add(paramRow);
            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            ////DataSet resultSet = acInfo.QBizActorRun.ExecuteService(this, "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            
        }


    }


    public class acDockPanel : DevExpress.XtraBars.Docking.DockPanel, IBaseViewControl
    {
        public acDockPanel(bool createControlContainer, DevExpress.XtraBars.Docking.DockingStyle dock, DevExpress.XtraBars.Docking.DockManager dockManager)
            : base(createControlContainer, dock, dockManager)
        {

        }



        public acDockPanel()
            : base()
        {

        }

        protected override void CreateHandle()
        {
            this.Options.AllowFloating = false;
            this.Options.ShowCloseButton = false;

            //리소스 설정

            if (acInfo.IsRunTime == true)
            {
                if (this._UseResourceID == true)
                {

                    this.SetText();

                }

            }



            base.CreateHandle();
        }

        private bool _IsDefaultPanel = false;

        [DefaultValue(false)]
        public bool IsDefaultPanel
        {
            get { return _IsDefaultPanel; }
            set { _IsDefaultPanel = value; }
        }

        public void SetText()
        {
            if (this.UseResourceID == true)
            {

                this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);

            }
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

                if (acInfo.IsRunTime == false)
                {
                    if (!string.IsNullOrEmpty(_ResourceID))
                    {
                        _UseResourceID = true;
                    }

                }

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
    }
}
