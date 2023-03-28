using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cubic_Query_Builder
{
    public partial class main : MetroFramework.Forms.MetroForm
    {
        static main _instance;

        public static main Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new main();
                return _instance;
            }
        }

        public MetroFramework.Controls.MetroPanel MetroContainer
        {
            get { return metroPanel1; }
            set { metroPanel1 = value; }
        }

       

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            _instance = this;
            dashBoard uc = new dashBoard();
            uc.Dock = DockStyle.Fill;
            metroPanel1.Controls.Add(uc);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroPanel1.Controls["dashBoard"].BringToFront();

            
        }
    }
}
