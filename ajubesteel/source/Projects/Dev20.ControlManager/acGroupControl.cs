using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace ControlManager
{
    public class acGroupControl : DevExpress.XtraEditors.GroupControl, IBaseViewControl
    {

        private bool _IsNavPlan = false;

        public bool IsNavPlan
        {
            get { return _IsNavPlan; }
            set { _IsNavPlan = value; }
        }

        private bool _Collapsed = false;

        public acGroupControl()
            : base()
        {


            this.MouseDown += new System.Windows.Forms.MouseEventHandler(acGroupControl_MouseDown);
        }

        private Size _OriginalSize = Size.Empty;



        void acGroupControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this._IsNavPlan == true)
            {
                if (e.Clicks == 2 && this.IsCaptionBound(e.Location) == true)
                {
                    if (this._Collapsed == false)
                    {
                        this._OriginalSize = this.Size;


                        this.Size = new Size(ViewInfo.CaptionBounds.Width, ViewInfo.CaptionBounds.Height + 2);


                        this._Collapsed = true;
                    }
                    else
                    {
                        this.Size = this._OriginalSize;

                        this._Collapsed = false;
                    }

                }

            }
        }


        public bool IsCaptionBound(Point p)
        {
            Rectangle r = new Rectangle(ViewInfo.CaptionBounds.X, ViewInfo.CaptionBounds.Y, ViewInfo.CaptionBounds.Width,
    ViewInfo.CaptionBounds.Height);

            if (r.Contains(p)) return true;

            return false;
        }





        protected override void OnCreateControl()
        {
            if (acInfo.IsRunTime == true)
            {

                if (_UseResourceID == true)
                {
                    this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);

                }


                if (this._IsNavPlan == true)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is acLayoutControl)
                        {

                            acLayoutControl layout = ctrl as acLayoutControl;


                            Size layoutSize = new Size(layout.Width, layout.Height);

                            Point layoutPt = layout.Location;

                            layout.Dock = DockStyle.None;

                            layout.Size = layoutSize;
                            layout.Location = layoutPt;

                            this.AutoSize = true;

                            Size groupSize = this.Size;

                            this.AutoSize = false;


                            float margin = ((DevExpress.Utils.AppearanceObject.DefaultFont.Size - DefaultFont.Size) * 2);

                            this.Size = new Size(groupSize.Width, groupSize.Height - (ViewInfo.CaptionBounds.Height - margin.toInt()));

                            layout.Dock = DockStyle.Fill;



                            layout.AutoScroll = true;

                            layout.Invalidate();

                        }
                    }

                }

                if (_isHeader)
                {
                    this.AppearanceCaption.Font = new Font("나눔고딕", 10, FontStyle.Bold);
                    //this.AppearanceCaption.Font.
                    this.AppearanceCaption.ForeColor = Color.DeepPink;
                }

                //acInfo.SysConfig.GetSysConfigByMemory("USE_GROUPCTRL_BORDERCOLOR").isNullOrEmpty() ;
                if (!acInfo.SysConfig.GetSysConfigByMemory("USE_GROUPCTRL_BORDERCOLOR").isNullOrEmpty())
                    this.AppearanceCaption.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;

            }

            base.OnCreateControl();
        }


        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }

        private bool _isHeader = false;

        public bool IsHeader
        {
            get
            {
                return _isHeader;
            }

            set
            {
                _isHeader = value;
            }
        }

        #endregion
    }
}
