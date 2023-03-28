using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BizManager;
using System.IO;


namespace ControlManager
{
    public partial class acMachineControl : BaseMenu
    {
        public acMachineControl()
        {
            InitializeComponent();
            simpleLabelItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            
        }


        //MC_NAME
        private string _MC_TITLE = null;
        public string MC_TITLE
        {
            get { return _MC_TITLE; }
            set 
            {
                _MC_TITLE = value;

                simpleLabelItem2.Text = this._MC_TITLE;
            }
        }


        //Color clrRun = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor();
        //Color clrPause = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor();
        //Color clrOff = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor();
        //Color clrError = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();

        private string _STATUS_CODE = null;

        public string STATUS_CODE
        {
            get { return _STATUS_CODE; }
            set
            {
                _STATUS_CODE = value;

                if (_STATUS_CODE == "R")//가동
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem3.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem4.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem5.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem6.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    panelControl1.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem1.Text = "가동";
                }
                else if (_STATUS_CODE == "W")//비가동
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem3.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem4.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem5.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem6.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    panelControl1.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor(); //clrPause;
                    simpleLabelItem1.Text = "비가동";
                }
                else if (_STATUS_CODE == "F")//전원OFF
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem3.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem4.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem5.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem6.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    panelControl1.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor(); //clrOff;
                    simpleLabelItem1.Text = "전원OFF";
                }
                else if (_STATUS_CODE == "A")//알람
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem3.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem4.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem5.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem6.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    panelControl1.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor(); //clrError;
                    simpleLabelItem1.Text = "알람";
                }
                else
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem3.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem4.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem5.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem6.AppearanceItemCaption.BackColor = Color.White;
                    panelControl1.BackColor = Color.White;
                }
            }
        }

        private string _PLT_CODE = null;
        public string PLT_CODE
        {
            get { return _PLT_CODE; }
            set
            {
                _PLT_CODE = value;
           }
        }

        private Image _MC_IMG = null;
        public Image MC_IMG
        {
            get { return _MC_IMG; }
            set 
            { 
                _MC_IMG = value;

                this.pictureEdit1.Image = this._MC_IMG;
            }
        }

        private string _PART_NAME = null;
        public string PART_NAME
        {
            get { return _PART_NAME; }
            set
            {
                _PART_NAME = value;

                simpleLabelItem3.Text = this._PART_NAME;
                simpleLabelItem3.OptionsToolTip.ToolTipTitle = this._PART_NAME;
            }
        }

        private string _PROC_NAME = null;
        public string PROC_NAME
        {
            get { return _PROC_NAME; }
            set
            {
                _PROC_NAME = value;

                simpleLabelItem4.Text = this._PROC_NAME;
                simpleLabelItem4.OptionsToolTip.ToolTipTitle = this._PROC_NAME;
            }
        }

        private string _MC_CODE = null;
        public string MC_CODE
        {
            get { return _MC_CODE; }
            set
            {
                _MC_CODE = value;
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SAVE_IMG(dialog.FileName);
            }
        }

        private void SAVE_IMG(string sFileName)
        {
            //저장

            try
            {
                FileStream fs = new FileStream(sFileName, FileMode.OpenOrCreate, FileAccess.Read);
                byte[] MyData = new byte[fs.Length];
                fs.Read(MyData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();

                pictureEdit1.Image = Image.FromFile(sFileName);
                
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_IMAGE", typeof(Byte[])); //

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = this._MC_CODE;
                paramRow["MC_IMAGE"] = MyData;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,"CTRL",
                "MC_IMG_SAVE", paramSet, "RQSTDT", "",
                QuickSave,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        void QuickSave(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            acMessageBox.Show(this, "설비 이미지 변경", "", false, acMessageBox.emMessageBoxType.CONFIRM);
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //popupMenu1.ShowPopup(MousePosition);
            }

            if (e.Button == MouseButtons.Left)
            {

                if (!base.ChildFormContains("MC"))
                {
                    acMachineControlForm frm = new acMachineControlForm(MC_CODE);

                    frm.ParentControl = this;

                    base.ChildFormAdd("MC", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("MC");
                }
                

            }
        }
        
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleLabelItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleLabelItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

      

      

    }

      
}
