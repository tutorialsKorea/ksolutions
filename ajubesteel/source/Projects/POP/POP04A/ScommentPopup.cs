using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Linq;
using BizManager;
using DevExpress.XtraTreeList.Nodes;

namespace POP
{
    public sealed partial class ScommentPopup : BaseMenuDialog
    {

       
        public override void BarCodeScanInput(string barcode)
        {

        }


        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        public static string default_Font = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public static int panel_fontSize = acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt();


        public ScommentPopup(DataRow linkData)
        {
            InitializeComponent();

            Control[] con = POP04A_M0A.formcount(this);
            
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(default_Font, panel_fontSize + 10, FontStyle.Regular, GraphicsUnit.Point);
                }

                if (down is acTextEdit)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acTextEdit)ctrls[0]).Font = new Font(default_Font, panel_fontSize + 10, FontStyle.Regular, GraphicsUnit.Point);
                }
                //if (down is acMemoEdit)
                //{
                //    Control[] ctrls = this.Controls.Find(down.Name, true);

                //    ((ControlManager.acMemoEdit)ctrls[0]).Properties.AppearanceReadOnly.Font = new Font(default_Font, panel_fontSize + 15, FontStyle.Regular, GraphicsUnit.Point);

                //}
            }
            acMemoEdit1.Value = linkData["SCOMMENT"];

            acLayoutControl2.DataBind(linkData, false);

        }


        public override void DialogInit()
        {
            acMemoEdit1.Properties.AppearanceReadOnly.Font = new Font(default_Font, panel_fontSize + 10, FontStyle.Regular, GraphicsUnit.Point);

            base.DialogInit();
        }

        public override void DialogNew()
        {
            
            try
            {

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

      
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static void SetPopGridFont(acTreeList grid)
        {
            int fontSz = 3;

            if (grid != null)
            {
                grid.Appearance.Row.Font = new Font(default_Font, panel_fontSize + fontSz);
                grid.Appearance.FocusedRow.Font = new Font(default_Font, panel_fontSize + fontSz, FontStyle.Bold);
                grid.Appearance.HideSelectionRow.Font = new Font(default_Font, panel_fontSize + fontSz);
                grid.Appearance.HeaderPanel.Font = new Font(default_Font, panel_fontSize + fontSz);
                //grid.Appearance.GroupRow.Font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);
            }

        }
    }
}