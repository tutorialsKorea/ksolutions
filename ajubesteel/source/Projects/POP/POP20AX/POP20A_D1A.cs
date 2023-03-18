using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace POP
{
    public sealed partial class POP20A_D1A : BaseMenuDialog
    {


        public POP20A_D1A(string mcNames)
        {
            InitializeComponent();
            acLabelControl2.Text = mcNames;
            acLabelControl2.Font = AutoFontSize(acLabelControl2, mcNames);
        }

        public Font AutoFontSize(acLabelControl label, String text)
        {
            Font ft;
            Graphics gp;
            SizeF sz;
            Single Faktor, FaktorX, FaktorY;

            gp = label.CreateGraphics();
            sz = gp.MeasureString(text, label.Font);
            gp.Dispose();

            FaktorX = (label.Width) / sz.Width;
            FaktorY = (label.Height) / sz.Height;

            if (FaktorX > FaktorY)
                Faktor = FaktorY;
            else
                Faktor = FaktorX;
            ft = label.Font;

            if (ft.SizeInPoints * (Faktor) - 1 > 50)
            {
                return new Font(ft.Name, 50);
            }
            else
            {
                return new Font(ft.Name, ft.SizeInPoints * (Faktor) - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}