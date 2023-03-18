using DevExpress.Utils.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYS.SYS03A
{
    public partial class Notice : UserControl
    {
        public Notice()
        {
            InitializeComponent();
            acRichEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
            {
                acRichEdit1.Appearance.Text.ForeColor = ForeColor;
                acRichEdit1.Document.SetPageBackground(BackColor);
            }
        }
        public void SetValues(string accLevel, string title, string contents)
        {
            lblAccLevel.Text = accLevel;
            lblTitle.Text = title;
            //acRichEdit1.RtfText = contents;
            acRichEdit1.Text = contents;
        }
    }
}
