using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;

namespace ControlManager
{
    public partial class acDateEditInstantForm : BaseMenuDialog
    {
        public acDateEditInstantForm()
        {
            InitializeComponent();

            acDateNavigator1.MouseDown += new MouseEventHandler(acDateNavigator1_MouseDown);

        }

        void acDateNavigator1_MouseDown(object sender, MouseEventArgs e)
        {
            acDateNavigator nav = sender as acDateNavigator;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                CalendarHitInfo hitInfo = nav.GetHitInfo(e);

                if (hitInfo.Cell != null && hitInfo.Cell.Selected)
                {
                    this.OutputData = hitInfo.HitDate;

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}