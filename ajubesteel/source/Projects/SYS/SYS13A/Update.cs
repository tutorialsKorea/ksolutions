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

namespace SYS.SYS13A
{
    public partial class Update : UserControl
    {
        public Update()
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
        public void SetValues(string title, string version, string contents)
        {
            //lblAccLevel.Text = accLevel;
            lblTitle.Text = title;
            lblVersion.Text =  "Version : " + version;
            //acRichEdit1.RtfText = contents;
            acRichEdit1.Text = contents;
        }
    }
}
