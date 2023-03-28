using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Text.RegularExpressions;
using DevExpress.Utils;
using System.ComponentModel;
using BizManager;

namespace ControlManager
{
    public class acUserPopupContainerEdit : DevExpress.XtraEditors.PopupContainerEdit
    {



        public acUserPopupContainerEdit()
            : base()
        {
            this.QueryPopUp +=new System.ComponentModel.CancelEventHandler(acUserPopupContainerEdit_QueryPopUp);

            this.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(acUserPopupContainerEdit_Closed);

        }


        public virtual void CreateToolTip()
        {
            if (!this.EditValue.isNull())
            {

                this.SuperTip = new SuperToolTip();

                ToolTipItem contentTT = new ToolTipItem();

                contentTT.Text = this.EditValue.toStringNull();

                this.SuperTip.Items.Add(contentTT);
            }
            else
            {
                if (this.SuperTip != null)
                {
                    this.SuperTip.Items.Clear();
                }

            }

        }

 

        protected override void OnEditValueChanged()
        {

            this.CreateToolTip();


            base.OnEditValueChanged();
        }

        public EditorButton GetButton(string name)
        {
            foreach (EditorButton btn in this.Properties.Buttons)
            {
                if (btn.Tag != null)
                {
                    if (btn.Tag.Equals(name))
                    {
                        return btn;
                    }
                }

            }

            return null;
        }

        protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                this.ClosePopup();

                SendKeys.SendWait("{TAB}");
                
                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }


        void acUserPopupContainerEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            acUserPopupContainerEditUserConfig config = new acUserPopupContainerEditUserConfig(this);

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

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;

            paramRow["CLASS_NAME"] = BaseMenu.GetBaseControl(this).Name;

            paramRow["CONTROL_NAME"] = this.Name;
            paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
            paramRow["DEFAULT_USE"] = "1";
            paramRow["LAYOUT"] = null;
            paramRow["OBJECT"] = config.ToArray();
            paramRow["OVERWRITE"] = "1";
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL","SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

        }

        void acUserPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
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

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL","GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");

            //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {

                byte[] configData = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acUserPopupContainerEditUserConfigSerializationBinder();

                acUserPopupContainerEditUserConfig config = (acUserPopupContainerEditUserConfig)bformatter.Deserialize(loadConfigSt);

                this.Properties.PopupControl.Size = config.PopupControlSize;

            }
        }

    }
}
