using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;
using AttachFileManager;

namespace POP
{
    public sealed partial class FileList : BaseMenuDialog
    {

   
        public override void BarCodeScanInput(string barcode)
        {


        }


        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");



        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        public FileList(DataRow linkData)
        {
            InitializeComponent();

            Control[] con = POP04A_M0A.formcount(this);

            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if(down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT")
                                                                            , acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            _LinkData = linkData;

     
        }

        public override void DialogInit()
        {
            acAttachFileControl1.fileGridView.RowHeight = 45;
            acAttachFileControl1.fileGridView.ColumnPanelRowHeight = 70;

            acAttachFileControl1.fileTransferGridView.RowHeight = 45;
            acAttachFileControl1.fileTransferGridView.ColumnPanelRowHeight = 70;

            acAttachFileControl1.fileDelHistoryGridView.RowHeight = 45;
            acAttachFileControl1.fileDelHistoryGridView.ColumnPanelRowHeight = 70;

            SetPopGridFont(acAttachFileControl1);

            base.DialogInit();
        }

        public static void SetPopGridFont(acAttachFileControl ctrl)
        {
            int fontSz = 3;

            //if (grid != null)
            {
                ctrl.fileGridView.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileGridView.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                ctrl.fileGridView.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileGridView.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                //grid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);

                ctrl.fileTransferGridView.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileTransferGridView.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                ctrl.fileTransferGridView.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileTransferGridView.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);


                ctrl.fileDelHistoryGridView.Appearance.Row.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileDelHistoryGridView.Appearance.FocusedRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                ctrl.fileDelHistoryGridView.Appearance.HideSelectionRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
                ctrl.fileDelHistoryGridView.Appearance.HeaderPanel.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
            }

        }

        public override void DialogNew()
        {
            GetFileList();
        }

        public override void DialogOpen()
        {
            
        }

        void GetFileList()
        {
            try
            {
                if (_LinkData != null)
                {
                 
                    this.acAttachFileControl1.LinkKey = _LinkData["PT_ID"];
                    this.acAttachFileControl1.ShowKey = new object[] { _LinkData["PT_ID"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}