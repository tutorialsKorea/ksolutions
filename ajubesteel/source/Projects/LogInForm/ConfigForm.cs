using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;
using DevExpress.XtraEditors.Repository;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Globalization;

namespace LogInForm
{
    public sealed partial class ConfigForm : DevExpress.XtraEditors.XtraForm
    {
        private string _ConfigPath = null;

        private string _ConfigFileName = null;

        private string _ConfigFileFullPath = null;


        public ConfigForm(string configPath, string configFileName)
        {
            try
            {
                InitializeComponent();

                _ConfigPath = configPath;

                _ConfigFileName = configFileName;

                _ConfigFileFullPath = _ConfigPath + @"\" + _ConfigFileName;

                #region 이벤트 설정

                acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

                
                #endregion

                #region 언어 리스트



                DataTable langTable = new DataTable();

                langTable.Columns.Add("LANG_NAME");
                langTable.Columns.Add("LANG_CODE");


                foreach(LanguageList lang in Enum.GetValues(typeof(LanguageList)))
                {

                    DataRow langRow = langTable.NewRow();

                    langRow["LANG_NAME"] = LogInForm.ResManager.GetString(string.Format("LANG_{0}",lang.ToString()));
                    langRow["LANG_CODE"] = lang.ToString();

                    langTable.Rows.Add(langRow);
                }


                lookUpEdit1.Properties.ShowHeader = false;

                lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LANG_NAME"));

                lookUpEdit1.Properties.DisplayMember = "LANG_NAME";
                lookUpEdit1.Properties.ValueMember = "LANG_CODE";

                lookUpEdit1.Properties.DataSource = langTable;

                lookUpEdit1.EditValue = "KR";

                #endregion


                #region 스킨 리스트


                Dictionary<string, string> skinList = new Dictionary<string, string>();

                skinList.Add("Caramel", @"Caramel");
                skinList.Add("Money Twins", @"Money Twins");
                skinList.Add("Lilian", @"Lilian");
                skinList.Add("The Asphalt World", @"The Asphalt World");
                skinList.Add("iMaginary", @"iMaginary");
                skinList.Add("Black", @"Black");
                skinList.Add("Blue", @"Blue");
                skinList.Add("Office 2007 Blue", @"Office 2007 Blue");
                skinList.Add("Office 2007 Black", @"Office 2007 Black");
                skinList.Add("Office 2007 Silver", @"Office 2007 Silver");
                skinList.Add("Office 2007 Green", @"Office 2007 Green");
                skinList.Add("Office 2007 Pink", @"Office 2007 Pink");
                skinList.Add("Coffee", "Coffee");
                skinList.Add("Liquid Sky", @"Liquid Sky");
                skinList.Add("London Liquid Sky", @"London Liquid Sky");
                skinList.Add("Glass Oceans", @"Glass Oceans");
                skinList.Add("Stardust", @"Stardust");
                skinList.Add("Xmas 2008 Blue", @"Xmas 2008 Blue");
                skinList.Add("Valentine", @"Valentine");
                skinList.Add("McSkin", @"McSkin");

                DataTable skinTable = new DataTable();

                skinTable.Columns.Add("SKIN_NAME");
                skinTable.Columns.Add("SKIN_CODE");

                foreach (KeyValuePair<string, string> skinItem in skinList)
                {
                    DataRow skinRow = skinTable.NewRow();

                    skinRow["SKIN_NAME"] = skinItem.Key;
                    skinRow["SKIN_CODE"] = skinItem.Value;

                    skinTable.Rows.Add(skinRow);
                }

                lookUpEdit2.Properties.ShowHeader = false;

                lookUpEdit2.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SKIN_NAME"));

                lookUpEdit2.Properties.DisplayMember = "SKIN_NAME";
                lookUpEdit2.Properties.ValueMember = "SKIN_CODE";

                lookUpEdit2.Properties.DataSource = skinTable;

                lookUpEdit2.EditValue = "0";

                #endregion

                #region 그리드 설정


                //acGridColumn checkCol = new acGridColumn();
                DevExpress.XtraGrid.Columns.GridColumn checkCol = new DevExpress.XtraGrid.Columns.GridColumn();
                RepositoryItemPictureEdit checkPic = new RepositoryItemPictureEdit();
                checkPic.AllowFocused = false;
                checkPic.ShowMenu = false;
                checkPic.PictureAlignment = ContentAlignment.MiddleCenter;
                checkPic.NullText = " ";
                checkPic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                checkCol.FieldName = "Check";
                checkCol.Visible = true;
                checkCol.VisibleIndex = 0;
                checkCol.ColumnEdit = checkPic;
                checkCol.Width = 25;
                checkCol.Caption = "선택";
                checkCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                

                DevExpress.XtraGrid.Columns.GridColumn serverNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
                //acGridColumn serverNameCol = new acGridColumn();
                serverNameCol.FieldName = "ServerName";
                serverNameCol.Visible = true;
                serverNameCol.VisibleIndex = 1;
                serverNameCol.Caption = "서버명";
                serverNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                //DevExpress.XtraGrid.Columns.GridColumn configMemberCol = new DevExpress.XtraGrid.Columns.GridColumn();
                acGridColumn configMemberCol = new acGridColumn();
                configMemberCol.FieldName = "ConfigMember";
                configMemberCol.Visible = false;
                

                acGridView1.Columns.Add(checkCol);
                acGridView1.Columns.Add(serverNameCol);
                acGridView1.Columns.Add(configMemberCol);


                acGridView1.OptionsBehavior.Editable = false;

                acGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;

                acGridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;


                #endregion


                this.LoadConfigItem(_ConfigFileFullPath);


                #region 접속으로 설정된 서버로 포커스 맞춤


                ConfigMember connentMember = GetConnectConfigItem(_ConfigFileFullPath);

                if (connentMember != null)
                {
                    DataTable gridTable = (DataTable)acGridView1.GridControl.DataSource;

                    int rowHandle = 0;

                    foreach (DataRow gridRow in gridTable.Rows)
                    {
                        if (gridRow["ServerName"].Equals(connentMember.ServerName))
                        {
                            break;
                        }

                        ++rowHandle;
                    }

                    acGridView1.FocusedRowHandle = rowHandle;
                }

                #endregion


                //리소스 설정

                this.Text = LogInForm.ResManager.GetString("CONFIG");
                this.layoutItem_ServerName.Text = LogInForm.ResManager.GetString("SERVER_NAME");
                this.layoutItem_ServerIP.Text = LogInForm.ResManager.GetString("SERVER_IP");
                this.layoutItem_DatabaseName.Text = LogInForm.ResManager.GetString("DATABASE_NAME");
                this.layoutItem_Plant.Text = LogInForm.ResManager.GetString("PLANT");
                this.layoutItem_Lang.Text = LogInForm.ResManager.GetString("LANG");
                this.layoutItem_Skin.Text = LogInForm.ResManager.GetString("SKIN");
                this.acBarButtonItem3.Caption = LogInForm.ResManager.GetString("SET_CONN");
                this.acBarButtonItem4.Caption = LogInForm.ResManager.GetString("DELETE");
                this.layoutControl1.DefaultErrText = LogInForm.ResManager.GetString("REQUIRED_TEXT");
                this.textEdit1.DefaultInvalidValueText = LogInForm.ResManager.GetString("INVALID_VALUE_TEXT");


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();


            if (focusRow != null)
            {

                ConfigMember member = (ConfigMember)focusRow["ConfigMember"];

                textEdit5.Value = member.ServerName;
                textEdit1.Value = member.ServerIP;
                textEdit2.Value = member.DatabaseName;
                textEdit4.Value = member.Plant;
                lookUpEdit1.Value = member.Language;
                lookUpEdit2.Value = member.Skin;

            }

        }




        /// <summary>
        /// 접속서버로 설정
        /// </summary>
        /// <param name="ConfigFileName"></param>
        public static void SetConnetConfigItem(string ConfigFileName, string serverName)
        {
            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == true)
            {
                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;

                if (configFile.Exists == true)
                {
                    foreach (XmlElement serverItem in config.ChildNodes)
                    {
                        if (serverName == serverItem.GetAttribute("name"))
                        {
                            serverItem.SetAttribute("use", "true");
                        }
                        else
                        {
                            serverItem.SetAttribute("use", "false");
                        }
                    }

                }

                newDoc.Save(ConfigFileName);
            }
        }



        /// <summary>
        /// 접속서버로 설정한 환경설정 멤버를 알아옵니다.
        /// </summary>
        /// <param name="ConfigFileName"></param>
        /// <returns></returns>
        public static ConfigMember GetConnectConfigItem(string ConfigFileName)
        {
            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == true)
            {
                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;
                foreach (XmlElement serverItem in config.ChildNodes)
                {

                    if (serverItem.GetAttribute("use") == "true")
                    {
                        ConfigMember member = new ConfigMember();

                        member.ServerName = serverItem.GetAttribute("name");
                        member.Use = serverItem.GetAttribute("use");
                        member.ServerIP = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerIP").Item(0));
                        member.DatabaseName = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("DatabaseName").Item(0));
                        //member.ServerPort = Config.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerPort").Item(0));
                        //member.ServerNum = Config.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerNum").Item(0));
                        member.Language = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Language").Item(0));
                        member.Plant = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Plant").Item(0));
                        member.Skin = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Skin").Item(0));
                        member.UserID = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("UserID").Item(0));
                        member.PassWD = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("PassWD").Item(0));
                        member.SavePwd = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("SavePwd").Item(0));

                        return member;
                    }
                }

            }

            return null;

        }

        private static string GetXmlNodeValue(XmlNode node)
        {
            if (node == null) return string.Empty;

            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            else
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 환경설정 아이템을 불러옵니다.
        /// </summary>
        /// <param name="ConfigFileName"></param>
        private void LoadConfigItem(string ConfigFileName)
        {
            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == true)
            {

                DataTable serverItemsTable = new DataTable();

                serverItemsTable.Columns.Add("Check", typeof(Bitmap));
                serverItemsTable.Columns.Add("ServerName", typeof(string));
                serverItemsTable.Columns.Add("ConfigMember", typeof(ConfigMember));
                //serverItemsTable.Columns.Add("ConfigMember", typeof(string));


                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;


                foreach (XmlElement serverItem in config.ChildNodes)
                {
                    ConfigMember member = new ConfigMember();

                    member.ServerName = serverItem.GetAttribute("name");
                    member.Use = serverItem.GetAttribute("use");
                    member.ServerIP = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerIP").Item(0));
                    member.DatabaseName = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("DatabaseName").Item(0));
                    //member.ServerPort = Config.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerPort").Item(0));
                    //member.ServerNum = Config.GetXmlNodeValue(serverItem.GetElementsByTagName("ServerNum").Item(0));
                    member.Language = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Language").Item(0));
                    member.Plant = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Plant").Item(0));
                    member.Skin = ConfigForm.GetXmlNodeValue(serverItem.GetElementsByTagName("Skin").Item(0));

                    DataRow serverItemRow = serverItemsTable.NewRow();

                    if (member.Use == "true")
                    {
                        serverItemRow["Check"] = Resource.brick_check_1x;

                    }
                    else
                    {
                        serverItemRow["Check"] = Resource.brick_1x;
                    }

                    serverItemRow["ServerName"] = member.ServerName;

                    serverItemRow["ConfigMember"] = member;


                    serverItemsTable.Rows.Add(serverItemRow);

                }

                acGridView1.GridControl.DataSource = serverItemsTable;


            }


        }

        private void RemoveConfigItem(string ConfigFileName, string serverName)
        {

            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == true)
            {
                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;

                if (configFile.Exists == true)
                {
                    foreach (XmlElement serverItem in config.ChildNodes)
                    {
                        if (serverName == serverItem.GetAttribute("name"))
                        {
                            config.RemoveChild(serverItem);

                            break;
                        }

                    }
                }

                newDoc.Save(ConfigFileName);
            }

        }

        public static void AddConfigItem(string ConfigFileName, ConfigMember member)
        {
            FileInfo configFile = new FileInfo(ConfigFileName);

            if (configFile.Exists == false)
            {
                //생성
                XmlDocument newDoc = new XmlDocument();

                newDoc.AppendChild(newDoc.CreateXmlDeclaration("1.0", "utf-8", string.Empty));

                XmlElement config = newDoc.CreateElement("Config");

                newDoc.AppendChild(config);

                XmlElement server = newDoc.CreateElement("Server");

                config.AppendChild(server);

                server.SetAttribute("name", member.ServerName);
                server.SetAttribute("use", "true");

                XmlElement xmlEm = newDoc.CreateElement("ServerIP");
                server.AppendChild(xmlEm);

                XmlText xt = newDoc.CreateTextNode(member.ServerIP);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("DatabaseName");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.DatabaseName);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("ServerPort");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.ServerPort);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("ServerNum");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.ServerNum);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("Plant");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.Plant);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("Language");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.Language);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("Skin");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.Skin);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("UserID");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.UserID);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("PassWD");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.PassWD);
                xmlEm.AppendChild(xt);

                xmlEm = newDoc.CreateElement("SavePwd");
                server.AppendChild(xmlEm);
                xt = newDoc.CreateTextNode(member.SavePwd.ToString());
                xmlEm.AppendChild(xt);

                newDoc.Save(ConfigFileName);

            }
            else
            {
                XmlDocument newDoc = new XmlDocument();

                newDoc.Load(ConfigFileName);

                XmlNode config = newDoc.DocumentElement;

                XmlElement server = null;

                foreach (XmlElement serverItem in config.ChildNodes)
                {
                    if (member.ServerName == serverItem.GetAttribute("name"))
                    {
                        server = serverItem;

                        break;
                    }

                }

                if (server == null)
                {
                    server = newDoc.CreateElement("Server");

                    config.AppendChild(server);

                    server.SetAttribute("name", member.ServerName);
                    server.SetAttribute("use", "false");

                    XmlElement xmlEm = newDoc.CreateElement("ServerIP");

                    server.AppendChild(xmlEm);

                    XmlText xt = newDoc.CreateTextNode(member.ServerIP);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("DatabaseName");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.DatabaseName);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("ServerPort");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.ServerPort);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("ServerNum");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.ServerNum);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("Plant");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.Plant);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("Language");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.Language);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("Skin");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.Skin);

                    xmlEm.AppendChild(xt);

                    xmlEm = newDoc.CreateElement("UserID");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.UserID);

                    xmlEm.AppendChild(xt);

                    
                    xmlEm = newDoc.CreateElement("PassWD");

                    server.AppendChild(xmlEm);

                    xt = newDoc.CreateTextNode(member.PassWD);

                    xmlEm.AppendChild(xt);


                    newDoc.Save(ConfigFileName);
                }
                else
                {
                    server.SetAttribute("name", member.ServerName);
                    server.SetAttribute("use", "true");
                    server.SetAttribute("userID", member.UserID);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "ServerIP", member.ServerIP);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "DatabaseName", member.DatabaseName);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "ServerPort", member.ServerPort);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "ServerNum", member.ServerNum);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "Plant", member.Plant);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "Language", member.Language);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "Skin", member.Skin);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "UserID", member.UserID);

                    ConfigForm.SetXmlNodeValue(newDoc, server, "PassWD", member.PassWD);

                    
                }

                newDoc.Save(ConfigFileName);
            }
        }

        public static void SetXmlNodeValue(XmlDocument newDoc, XmlElement parent, string nodeName, string value)
        {
            if (parent.GetElementsByTagName(nodeName).Item(0) != null)
            {
                if (parent.GetElementsByTagName(nodeName).Item(0).HasChildNodes)
                    parent.GetElementsByTagName(nodeName).Item(0).FirstChild.Value = value;
                
            }
            else
            {
                XmlElement em = newDoc.CreateElement(nodeName);

                parent.AppendChild(em);

                XmlText xt = newDoc.CreateTextNode(value);

                em.AppendChild(xt);
            }

        }


        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {
                if (layoutControl1.ValidCheck() == false) return;
                
                DataRow layoutRow = layoutControl1.CreateParameterRow();

                DirectoryInfo configDirInfo = new DirectoryInfo(_ConfigPath);

                if (configDirInfo.Exists == false)
                {
                    configDirInfo.Create();
                }

                ConfigMember member = new ConfigMember();

                member.ServerIP = layoutRow["SERVER_IP"].toStringEmpty();
                member.ServerName = layoutRow["SERVER_NAME"].toStringEmpty();
                member.DatabaseName = layoutRow["DATABASE_NAME"].toStringEmpty();
                member.Plant = layoutRow["PLANT"].toStringEmpty();
                member.Skin = layoutRow["SKIN"].toStringEmpty();
                member.Language = layoutRow["LANG"].toStringEmpty();

                AddConfigItem(_ConfigFileFullPath, member);

                //int focusHandle = acGridView1.FocusedRowHandle;

                //this.LoadConfigItem(_ConfigFileFullPath);

                //if (focusHandle > 0)
                //    acGridView1.FocusedRowHandle = focusHandle;

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.ShowEx2(this, ex);
            }

        }


        private void btnSetServer_Click(object sender, EventArgs e)
        {
            try
            {
                //접속 서버로 설정
                DirectoryInfo configDirInfo = new DirectoryInfo(_ConfigPath);

                if (configDirInfo.Exists == false)
                {
                    configDirInfo.Create();
                }

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    SetConnetConfigItem(_ConfigFileFullPath, focusRow["ServerName"].toStringEmpty());


                    int focusRowHandle = acGridView1.FocusedRowHandle;

                    this.LoadConfigItem(_ConfigFileFullPath);

                    acGridView1.FocusedRowHandle = focusRowHandle;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.ShowEx2(this, ex);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //삭제
            try
            {
                DirectoryInfo configDirInfo = new DirectoryInfo(_ConfigPath);

                if (configDirInfo.Exists == false)
                {
                    configDirInfo.Create();
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    //정말 삭제하시겠습니까?

                    if (acMessageBox.Show(LogInForm.ResManager.GetString("DEL_QUE"), this.Text, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    this.RemoveConfigItem(_ConfigFileFullPath, focusRow["ServerName"].toStringEmpty());

                    int focusRowHandle = acGridView1.FocusedRowHandle;

                    this.LoadConfigItem(_ConfigFileFullPath);

                    acGridView1.FocusedRowHandle = focusRowHandle;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.ShowEx2(this, ex);
            }
        }



    }
}