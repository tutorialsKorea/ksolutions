using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using BizManager;
using DevExpress.XtraBars;

namespace POP
{
    public partial class RegActRealTime : BaseMenuDialog
    {
        private int _Qty = 0;

        private DataRow dr = null;
        private POP20C_M0A _Form = null;
        public int Qty
        {
            get => _Qty;
            set {
                _Qty = value;
                ApplyQty.Text = _Qty + "";
            }
        }
        public RegActRealTime(DataRow focus, POP20C_M0A form)
        {
            InitializeComponent();

            this._Form = form;

            SetDataRow(focus);

            toggle.CheckedChanged += Toggle_CheckedChanged;
        }

        private void Toggle_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarToggleSwitchItem bts = sender as BarToggleSwitchItem;

            if(bts.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        public override void DialogInit()
        {
            base.DialogInit();

            #region font
            string strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

            acLayoutControlItem1.AppearanceItemCaption.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt()+5,
                    FontStyle.Regular, GraphicsUnit.Point);
            acLayoutControlItem2.AppearanceItemCaption.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt()+5,
                    FontStyle.Regular, GraphicsUnit.Point);
            acLayoutControlItem6.AppearanceItemCaption.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt()+5,
                    FontStyle.Regular, GraphicsUnit.Point);
            ApplyQty.Appearance.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 40,
                    FontStyle.Regular, GraphicsUnit.Point);
            ActQty.Appearance.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 40,
                    FontStyle.Regular, GraphicsUnit.Point);
            acLabelControl1.Appearance.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 40,
                    FontStyle.Regular, GraphicsUnit.Point);

            Control.ControlCollection ctrBtns = acLayoutControl1.Controls;

            btnApply.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 20,
                    FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 20,
                FontStyle.Regular, GraphicsUnit.Point);
            btnPlus.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 60,
            FontStyle.Regular, GraphicsUnit.Point);

            btnMinus.Font = new Font(strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 60,
                    FontStyle.Regular, GraphicsUnit.Point);
            #endregion
        }

        public bool SetDataRow(DataRow focus)
        { 

            dr = focus;

            this.Text = "수주코드 : " + dr["ITEM_CODE"] + "    품명 : " + dr["PART_NAME"] + "    공정 : " + dr["PROC_NAME"];

            this.ActQty.Text = dr["ACT_QTY"].toInt()+"";
            this.acLabelControl1.Text = dr["PART_QTY"].ToString();
            Qty = 0;

            return true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (dr["WO_FLAG"].ToString() != "2")
                {
                    acMessageBox.Show(this, "작업을 시작해야 입력이 가능합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                if (acMessageBox.Show(this, "저장하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                string stat = _Form.ActProcess(Qty);
                if(stat.Equals("CLOSE"))
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Qty++;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Qty == 0)
                return;
            Qty--;
        }

        public static Control[] formcount(Control controlcount)
        {
            List<Control> list = new List<Control>();
            Queue<Control.ControlCollection> que = new Queue<Control.ControlCollection>();

            que.Enqueue(controlcount.Controls);

            while (que.Count > 0)
            {

                //que에 들어있는 컨트롤을 controls에 넣으면서 큐에서 지워준다. 
                Control.ControlCollection controls = (Control.ControlCollection)que.Dequeue();

                //controls가 비여있다면 while문을 벗어난다.

                if (controls == null || controls.Count == 0)
                {
                    continue;
                }



                foreach (Control control in controls)
                {
                    list.Add(control);
                    que.Enqueue(control.Controls);  //control 하위에 Control들이 있다면 que에 다시 추가한다
                }

            }
            return list.ToArray();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

