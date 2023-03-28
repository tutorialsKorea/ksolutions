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
    public partial class acMntMachine : DevExpress.XtraEditors.XtraUserControl
    {
        public acMntMachine()
        {
            InitializeComponent();

            layoutControl2.AllowCustomizationMenu = false;
        }


        //MC_NAME
        private string _MC_TITLE = null;
        public string MC_TITLE
        {
            get { return _MC_TITLE; }
            set 
            {
                _MC_TITLE = value;

                acLabelControl1.Text = this._MC_TITLE;
            }
        }


        //WORK_Info #1 NAME
        private string _WK_OPT_NAME1 = null;
        public string WK_OPT_NAME1
        {
            get { return _WK_OPT_NAME1; }
            set
            {
                _WK_OPT_NAME1 = value;

                layoutControlItem2.Text = this._WK_OPT_NAME1;
            }
        }

        //WORK_Info #2 NAME
        private string _WK_OPT_NAME2 = null;
        public string WK_OPT_NAME2
        {
            get { return _WK_OPT_NAME2; }
            set
            {
                _WK_OPT_NAME2 = value;

                layoutControlItem3.Text = this._WK_OPT_NAME2;
            }
        }

        //WORK_Info #3 NAME
        private string _WK_OPT_NAME3 = null;
        public string WK_OPT_NAME3
        {
            get { return _WK_OPT_NAME3; }
            set
            {
                _WK_OPT_NAME3 = value;

                layoutControlItem4.Text = this._WK_OPT_NAME3;
            }
        }

        //WORK_Info #4 NAME
        private string _WK_OPT_NAME4 = null;
        public string WK_OPT_NAME4
        {
            get { return _WK_OPT_NAME4; }
            set
            {
                _WK_OPT_NAME4 = value;

                layoutControlItem5.Text = this._WK_OPT_NAME4;
            }
        }

        //WORK_Info #1 CODE
        private string _WK_OPT_CODE1 = null;
        public string WK_OPT_CODE1
        {
            get { return _WK_OPT_CODE1; }
            set
            {
                _WK_OPT_CODE1 = value;

                textEdit1.Text = this._WK_OPT_CODE1;
            }
        }

        //WORK_Info #2 CODE
        private string _WK_OPT_CODE2 = null;
        public string WK_OPT_CODE2
        {
            get { return _WK_OPT_CODE2; }
            set
            {
                _WK_OPT_CODE2 = value;

                textEdit2.Text = this._WK_OPT_CODE2;
            }
        }

        //WORK_Info #3 CODE
        private string _WK_OPT_CODE3 = null;
        public string WK_OPT_CODE3
        {
            get { return _WK_OPT_CODE3; }
            set
            {
                _WK_OPT_CODE3 = value;

                textEdit3.Text = this._WK_OPT_CODE3;
            }
        }

        //WORK_Info #4 CODE
        private string _WK_OPT_CODE4 = null;
        public string WK_OPT_CODE4
        {
            get { return _WK_OPT_CODE4; }
            set
            {
                _WK_OPT_CODE4 = value;

                textEdit4.Text = this._WK_OPT_CODE4;
            }
        }

        //WORK_Info #4 CODE
        private string _WK_OPT_CODE5 = null;
        public string WK_OPT_CODE5
        {
            get { return _WK_OPT_CODE5; }
            set
            {
                _WK_OPT_CODE5 = value;

                textEdit5.Text = this._WK_OPT_CODE5;
            }
        }

  

        //Bottom_Items
        private int _Bottom_Items = 0;
        public int Bottom_Items
        {
            get { return _Bottom_Items; }
            set
            {
                _Bottom_Items = value;

                CHK_Bottom_Items(this._Bottom_Items);
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

                //if (_STATUS_CODE == "R")
                if (_STATUS_CODE == "3")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor(); //clrRun;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.White; //가동일때 글자 안보여서 글자색 흰색으로
                    simpleLabelItem2.Text = "가동";
                }
                //else if (_STATUS_CODE == "W")
                else if (_STATUS_CODE == "2")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor();  //clrPause;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    simpleLabelItem2.Text = "비가동";
                }
                //else if (_STATUS_CODE == "F")
                else if (_STATUS_CODE == "0")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor();  //clrOff;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    simpleLabelItem2.Text = "전원OFF";
                }
                //else if (_STATUS_CODE == "A")
                else if (_STATUS_CODE == "9")
                {
                    simpleLabelItem2.AppearanceItemCaption.BackColor = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();  //clrError;
                    simpleLabelItem2.AppearanceItemCaption.ForeColor = Color.Black;
                    simpleLabelItem2.Text = "알람";
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

        private string _MC_CODE = null;
        public string MC_CODE
        {
            get { return _MC_CODE; }
            set
            {
                _MC_CODE = value;
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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (layoutControlItem2.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }
        }

      
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (layoutControlItem3.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void CHK_Bottom_Items(int iCount)
        {
            switch (iCount)
            {
                case 0:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 1:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 2:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 3:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 4:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 5:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    break;
                default:
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    break;
            }
        }

        

    }

      
}
