using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using BizManager;

namespace ControlManager
{

    public class acSplitContainerControl : DevExpress.XtraEditors.SplitContainerControl
    {
        public static Dictionary<string, acSplitContainerControlUserConfig> _UserConfigs = new Dictionary<string, acSplitContainerControlUserConfig>();

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

        public acSplitContainerControl()
            : base()
        {

            this.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;

            this.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

        }
        public static void ClearUserConfig()
        {
            acSplitContainerControl._UserConfigs.Clear();
        }

        public static void RemoveUserConifg(string parentClassName)
        {
            List<string> removeKey = new List<string>();

            foreach (KeyValuePair<string, acSplitContainerControlUserConfig> uc in acSplitContainerControl._UserConfigs)
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
                acSplitContainerControl._UserConfigs.Remove(key);

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


            foreach (KeyValuePair<string, acSplitContainerControlUserConfig> uc in acSplitContainerControl._UserConfigs)
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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");

        }

        public static string GetClassName()
        {
            return "acSplitContainerControl";
        }

        public void LoadDefaultConfig()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;


            paramRow["CLASS_NAME"] = _ParentControl.Name;

            paramRow["CONTROL_NAME"] = this.Name;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

            //DataSet resultSet = acInfo.QBizActorRun.ExecuteService(this, "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {

                byte[] configData = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acSplitContainerControlUserConfigSerializationBinder();

                acSplitContainerControlUserConfig config = (acSplitContainerControlUserConfig)bformatter.Deserialize(loadConfigSt);


                if (this.Horizontal == true)
                {
                    //가로 분할

                    this.SplitterPosition = (int)(this.Size.Width * config.SplitterRatio);
                }
                else
                {
                    //세로 분할
                    this.SplitterPosition = (int)(this.Size.Height * config.SplitterRatio);
                }


            }

            //텍스트가 표시안되는 현상있음 조치

            ++this.Panel2.Height;
            --this.Panel2.Height;
        }


        protected override void OnLoaded()
        {


            base.OnLoaded();

            if (ControlManager.acInfo.IsRunTime == true)
            {


                //포지션 로드
                acSplitContainerControlUserConfig config = null;

                string key = string.Format("{0},{1}", BaseMenu.GetBaseControl(this).Name, this.Name);

                if (acSplitContainerControl._UserConfigs.ContainsKey(key))
                {
                    config = acSplitContainerControl._UserConfigs[key];

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
                    paramRow["CLASS_NAME"] = BaseMenu.GetBaseControl(this).Name;
                    paramRow["CONTROL_NAME"] = this.Name;

                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

                    if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
                    {

                        byte[] configData = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];

                        MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                        BinaryFormatter bformatter = new BinaryFormatter();
                        bformatter.Binder = new acSplitContainerControlUserConfigSerializationBinder();

                        config = (acSplitContainerControlUserConfig)bformatter.Deserialize(loadConfigSt);


                    }


                }

                //UI설정 적용
                if (config != null)
                {
                    if (this.Horizontal == true)
                    {
                        //가로 분할

                        this.SplitterPosition = (int)(this.Size.Width * config.SplitterRatio);
                    }
                    else
                    {
                        //세로 분할
                        this.SplitterPosition = (int)(this.Size.Height * config.SplitterRatio);
                    }
                }

            }


        }


        protected override void OnHandleDestroyed(EventArgs e)
        {
            //닫을때 포지션 저장
            if (ControlManager.acInfo.IsRunTime == true)
            {

                acSplitContainerControlUserConfig config = new acSplitContainerControlUserConfig(this);

                string key = string.Format("{0},{1}", BaseMenu.GetBaseControl(this).Name, this.Name);

                if (!acSplitContainerControl._UserConfigs.ContainsKey(key))
                {
                    acSplitContainerControl._UserConfigs.Add(key, config);
                }
                else
                {
                    acSplitContainerControl._UserConfigs[key] = config;
                }

            }

            base.OnHandleDestroyed(e);


        }


    }
}
