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
using System.Runtime.InteropServices;
using ControlManager;

namespace MNT
{
    public partial class acMntDeplus : UserControl
    {
        public acMntDeplus()
        {
            InitializeComponent();
            acRoundLabel1.cornerRadius = 30;
            acRoundLabel1.backColor = Color.Silver;
            acRoundLabel1.borderColor = Color.White;
            acRoundLabel1.borderWidth = 2;
            //acRoundLabel1.backColor = Color.Green;

            acRoundLabel2.borderColor = Color.White;
            acRoundLabel2.cornerRadius = 30;
            acRoundLabel2.borderWidth = 2;

            acRoundLabel3.cornerRadius = 30;
            acRoundLabel3.backColor = Color.DarkGray;
            acRoundLabel3.borderColor = Color.White;
            acRoundLabel3.borderWidth = 2;
            acRoundLabel3.isFillLeftBtm = true;
            acRoundLabel3.isFillRightBtm = true;

            acRoundLabel4.cornerRadius = 30;
            acRoundLabel4.backColor = Color.Gainsboro;
            acRoundLabel4.borderColor = Color.White;
            acRoundLabel4.borderWidth = 2;

            acRoundLabel4.isFillLeftTop = true;
            acRoundLabel4.isFillRightTop = true;
        }


        ~acMntDeplus()
        {

        }
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
          int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void acMntDeplus2_Load(object sender, EventArgs e)
        {
            //label1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label1.Width, label1.Height, 30, 30));
            //label2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label2.Width, label2.Height, 30, 30));
            //label3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label3.Width, label3.Height, 30, 30));
            //label4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label4.Width, label4.Height, 30, 30));

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

            tableLayoutPanel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height, 30, 30));
        }

        public void SetRegin()
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

            tableLayoutPanel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height, 30, 30));
        }


        //MC_CODE
        private string _MC_CODE = string.Empty;
        public string MC_CODE
        {
            get { return this._MC_CODE; }
            set
            {
                this._MC_CODE = value;
            }
        }

        //MC_NAME
        public string MC_NAME
        {
            get { return this.acRoundLabel1.Text; }
            set
            {
                this.acRoundLabel1.Text = value;
            }
        }

        private string _MC_STATUS = "0";
        //STATUS
        public string MC_STATUS
        {
            get { return this._MC_STATUS; }
            set
            {
                switch (value)
                {
                    case "0"://무작업
                        this.acRoundLabel2.backColor = Color.LightGray;
                        break;
                    case "1":
                        this.acRoundLabel2.backColor = Color.LightGray;
                        break;
                    case "2"://가동
                        this.acRoundLabel2.backColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
                        break;
                    case "3"://중지
                        this.acRoundLabel2.backColor = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
                        break;
                    case "9"://비가동
                        this.acRoundLabel2.backColor = Color.Red;
                        break;
                    case "99"://비가동
                        this.acRoundLabel2.backColor = Color.LightGray;
                        break;
                    case "88"://신호 5분이상차이남
                        this.acRoundLabel2.backColor = Color.Black;
                        break;
                }

                this._MC_STATUS = value;
            }
        }


        public string PROD_CODE
        {
            get { return this.acRoundLabel4.Text; }
            set
            {
                this.acRoundLabel4.Text = value;
            }
        }

    }
}
