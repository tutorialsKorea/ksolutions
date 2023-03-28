using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlManager
{
    public partial class acAlertForm : Form
    {
        public acAlertForm()
        {
            InitializeComponent();

            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Paint += acAlertForm_Paint;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);

        private void acAlertForm_Paint(object sender, PaintEventArgs e)
        {
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 10, 10);
            this.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private acAlertForm.enmAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 3000;
                    action = enmAction.close;
                    break;
                case acAlertForm.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = acAlertForm.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(Control parentControl,string msg, enmType type)
        {
            this.Opacity = 0;
            //this.BackColor = Color.Transparent;

            Screen screen = Screen.PrimaryScreen;

            foreach(Screen sc in Screen.AllScreens)
            {
                Point point = new Point();

                Control ctrl = parentControl;

                if (parentControl.Parent != null)
                {
                    ctrl = parentControl.Parent;
                    if (parentControl.Parent.Parent != null)
                    {
                        ctrl = parentControl.Parent.Parent;
                        if (parentControl.Parent.Parent.Parent != null)
                        {
                            ctrl = parentControl.Parent.Parent.Parent;
                            if (parentControl.Parent.Parent.Parent.Parent != null)
                            {
                                ctrl = parentControl.Parent.Parent.Parent.Parent;
                            }
                        }
                    }
                }
                point.X = ctrl.Location.X + ctrl.Width / 2;
                point.Y = ctrl.Location.Y + ctrl.Height / 2;

                if (sc.WorkingArea.Contains(point))
                {
                    screen = sc;
                    break;
                }
            }

            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                acAlertForm frm = (acAlertForm)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = screen.WorkingArea.Left + screen.WorkingArea.Width - this.Width + 15;
                    this.y = screen.WorkingArea.Top + screen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);

                    //this.Left = screen.Bounds.Width - this.Width + 15;
                   
                    break;

                }

            }
            this.x = screen.WorkingArea.Left + screen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Resource.alert_success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resource.alert_error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resource.alert_info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Resource.alert_warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.lblMsg.Text = msg;

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void acPictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void Alert(string msg, Form_Alert.enmType type)
        //{
        //    Form_Alert frm = new Form_Alert();
        //    frm.showAlert(msg, type);
        //}

    }
}
