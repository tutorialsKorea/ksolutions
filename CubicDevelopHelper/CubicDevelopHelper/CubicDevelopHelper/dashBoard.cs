using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace Cubic_Query_Builder
{
    public partial class dashBoard : UserControl
    {
        BackgroundWorker _bgWorker = new BackgroundWorker();

        public dashBoard()
        {
            InitializeComponent();

            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.WorkerSupportsCancellation = true;


        }



        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (_bgWorker.IsBusy != true)
            {
                _bgWorker.RunWorkerAsync();

                if (!main.Instance.MetroContainer.Controls.ContainsKey("ucDevelopHelper"))
                {
                    //Form1.Instance.MetroContainerucDevelopHelperControls.Remove(Form1.Instance.MetroContainer.Controls["ucCollectImage"]);                
                    ucDevelopHelper uc = new ucDevelopHelper();
                    uc.Dock = DockStyle.Fill;
                    main.Instance.MetroContainer.Controls.Add(uc);
                    main.Instance.MetroContainer.Tag = "ucDevelopHelper";
                }

                main.Instance.MetroContainer.Controls["ucDevelopHelper"].BringToFront();
            }
            
            //main.Instance.MetroBack.Visible = true;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (_bgWorker.IsBusy != true)
            {
                _bgWorker.RunWorkerAsync();

                if (!main.Instance.MetroContainer.Controls.ContainsKey("ucBoard"))
                {

                    ucBoard uc = new ucBoard();
                    uc.Dock = DockStyle.Fill;
                    main.Instance.MetroContainer.Controls.Add(uc);
                    main.Instance.MetroContainer.Tag = "ucBoard";
                }

                main.Instance.MetroContainer.Controls["ucBoard"].BringToFront();

            }
        }

    }
}
