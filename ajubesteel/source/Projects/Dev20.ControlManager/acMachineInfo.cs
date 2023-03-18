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
    public partial class acMachineInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public acMachineInfo()
        {
            InitializeComponent();
        }


        //MC_NAME
        private string _MC_TITLE = null;
        public string MC_TITLE
        {
            get { return _MC_TITLE; }
            set 
            {
                _MC_TITLE = value;

                simpleLabelItem1.Text = this._MC_TITLE;
            }
        }

        //MC_Info #1
        private string _MC_OPT_CODE1 = null;
        public string MC_OPT_CODE1
        {
            get { return _MC_OPT_CODE1; }
            set
            {
                _MC_OPT_CODE1 = value;

                simpleLabelItem2.Text = this._MC_OPT_CODE1;
            }
        }

        //MC_Info #2
        private string _MC_OPT_CODE2 = null;
        public string MC_OPT_CODE2
        {
            get { return _MC_OPT_CODE2; }
            set
            {
                _MC_OPT_CODE2 = value;

                simpleLabelItem3.Text = this._MC_OPT_CODE2;
            }
        }

        //MC_Info #3
        private string _MC_OPT_CODE3 = null;
        public string MC_OPT_CODE3
        {
            get { return _MC_OPT_CODE3; }
            set
            {
                _MC_OPT_CODE3 = value;

                simpleLabelItem4.Text = this._MC_OPT_CODE3;
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

        //Update TIme
        private string _UPDATE_TIME = null;
        public string UPDATE_TIME
        {
            get { return _UPDATE_TIME; }
            set
            {
                _UPDATE_TIME = value;

                textEdit5.Text = this._UPDATE_TIME;
            }
        }

        //Right_Items
        private int _Right_Items = 0;
        public int Right_Items
        {
            get { return _Right_Items; }
            set
            {
                _Right_Items = value;

                CHK_Right_Items(this._Right_Items);
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


        private string _STATUS_CODE = null;

        public string STATUS_CODE
        {
            get { return _STATUS_CODE; }
            set
            {
                _STATUS_CODE = value;

                if (_STATUS_CODE == "S")
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.Yellow;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.Black;
                }
                else if (_STATUS_CODE == "R")
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.ForestGreen;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.White;
                }
                else if (_STATUS_CODE == "M")
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.DodgerBlue;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.White;
                }
                else if (_STATUS_CODE == "E")
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.Red;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.White;
                }
                else if (_STATUS_CODE == "N")
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.Black;
                }
                else 
                {
                    simpleLabelItem1.AppearanceItemCaption.BackColor = Color.White;
                    simpleLabelItem1.AppearanceItemCaption.ForeColor = Color.Black;
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
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "*.*";

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
            MessageBox.Show("설비 이미지 변경");
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void CHK_Right_Items(int iCount)
        {
            switch (iCount)
            {
                case 0:
                    simpleLabelItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 1:
                    simpleLabelItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 2:
                    simpleLabelItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    break;
                case 3:
                    simpleLabelItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    break;
                default:
                    simpleLabelItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    simpleLabelItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    break;

            }
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
