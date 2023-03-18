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
using ControlManager;

namespace MNT
{
    public partial class acMntMachine : DevExpress.XtraEditors.XtraUserControl
    {
        public acMntMachine()
        {
            InitializeComponent();

        }


        private string _STATUS_CODE = null;

        public string STATUS_CODE
        {
            get { return _STATUS_CODE; }
            set
            {
                _STATUS_CODE = value;

               if (_STATUS_CODE == "2")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();  //clrPause;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "가동";
                }
                else if (_STATUS_CODE == "3")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();  //clrOff;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "중지";
                }
                else if (_STATUS_CODE == "4")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Red;//acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();  //clrError;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "비가동";
                }
                else if (_STATUS_CODE == "5")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Gray;//acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();  //clrError;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "알람";
                }
                else
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    simpleLabelItem2.Text = " ";
                }
            }
        }

        private string _MC_STATUS_CODE = null;

        public string MC_STATUS_CODE
        {
            get { return _MC_STATUS_CODE; }
            set
            {
                _MC_STATUS_CODE = value;

                if (_MC_STATUS_CODE == "2")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();  //clrPause;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "가동";
                }
                else if (_MC_STATUS_CODE == "3")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();  //clrOff;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "중지";
                }
                else if (_MC_STATUS_CODE == "9")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Red;//acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();  //clrError;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    //simpleLabelItem2.Text = "알람";
                }
                else if (_MC_STATUS_CODE == "99")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.Gray;//acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();  //clrError;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                }
                else
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    simpleLabelItem2.Text = " ";
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


        private string _MC_CODE = null;
        public string MC_CODE
        {
            get { return _MC_CODE; }
            set
            {
                _MC_CODE = value;
            }
        }

        private string _MC_NAME = null;
        public string MC_NAME
        {
            get { return _MC_NAME; }
            set
            {
                _MC_NAME = value;

                simpleLabelItem2.Text = _MC_NAME;
            }
        }

        //public delegate void MCImageMouseDownEventHandler(object sender, MouseEventArgs e);

        //public event MCImageMouseDownEventHandler OnMCImageMouseDown;

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (this.OnMCImageMouseDown != null)
            //{
            //    this.OnMCImageMouseDown(this, e);
            //}

            if (e.Button == MouseButtons.Right)
            {
                //popupMenu1.ShowPopup(MousePosition);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        

    }

      
}
