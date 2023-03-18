using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using System.Collections;

//using OpenCvSharp;

namespace ORD
{
    public sealed partial class frmPictureEdit : BaseMenuDialog
    {

        private int _nowLevel = 0;

        private int _picWidth = 0;

        private int _picHeight = 0;

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }
        
        public override void BarCodeScanInput(string barcode)
        {
        }

        List<Image> imgList = new List<Image>();

        Point p;

        Rectangle _rect;

        public frmPictureEdit(Image img)
        {
            InitializeComponent();

            Size resize = new Size(acPictureEdit1.Width, acPictureEdit1.Height);
            Bitmap bmp = new Bitmap(img, resize);

            acPictureEdit1.MouseDown += acPictureEdit1_MouseDown;
            acPictureEdit1.MouseMove += acPictureEdit1_MouseMove;

            acPictureEdit1.Paint += acPictureEdit1_Paint;

            //this._rect = new Rectangle(0, 0, acPictureEdit1.Width, acPictureEdit1.Height);

            acPictureEdit1.Image = bmp;

            this._picHeight = acPictureEdit1.Height;
            this._picWidth = acPictureEdit1.Width;

        }

        private void acPictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Blue, this._rect);
        }

        private void acPictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = acPictureEdit1.CreateGraphics();

                if (p.X == 0 && p.Y == 0)
                {
                    p.X = e.X;
                    p.Y = e.Y;
                }

                int width = e.X - p.X;

                int height = e.Y - p.Y;

                Point rectPoint = p;

                if (width < 0)
                {
                    rectPoint.X = e.X;
                }

                if (height < 0)
                {
                    rectPoint.Y = e.Y;
                }

                if(rectPoint.X < 0)
                {
                    width = Math.Abs(width) + rectPoint.X;

                    rectPoint.X = 1;
                }
                else if (Math.Abs(width) + rectPoint.X > acPictureEdit1.Width)
                {
                    width = acPictureEdit1.Width - rectPoint.X - 1;                    
                }

                if (rectPoint.Y < 0)
                {
                    height = Math.Abs(height) + rectPoint.Y;

                    rectPoint.Y = 1;
                }
                else if (Math.Abs(height) + rectPoint.Y > acPictureEdit1.Height)
                {
                    height = acPictureEdit1.Height - rectPoint.Y - 1;
                }


                if (Math.Abs(width) > 0 && Math.Abs(height) > 0)
                {
                    

                    this._rect = new Rectangle(rectPoint, new Size(Math.Abs(width), Math.Abs(height)));

                    g.DrawRectangle(Pens.Blue, new Rectangle(rectPoint, new Size(Math.Abs(width), Math.Abs(height))));

                }

                g.Dispose();

                acPictureEdit1.Refresh();
            }
        }

        private void acPictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {

            p.X = e.X;
            p.Y = e.Y;

        }

        public override void DialogInit()
        {

            base.DialogInit();
        }


        public override void DialogNew()
        {
            //새로만들기
            

        }


        public override void DialogUser()
        {

            base.DialogUser();

        }
        public override void DialogOpen()
        {
            //열기


        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                System.GC.Collect();

                Size resize = new Size(acPictureEdit1.Width, acPictureEdit1.Height);                

                //double xRate = bmp.Width.toDouble() / acPictureEdit1.Width.toDouble();

                //double yRate = bmp.Height.toDouble() / acPictureEdit1.Height.toDouble();

                //this._rect = new Rectangle((this._rect.X.toDouble() * xRate).toInt(), (this._rect.Y.toDouble() * yRate).toInt()
                //                              , (this._rect.Width.toDouble() * xRate).toInt(), (this._rect.Height.toDouble() * yRate).toInt());

                Image img = null;
                if (this._rect != null && this._rect.Width != 0 && this._rect.Height != 0)
                {

                    if (this._rect.Width > acPictureEdit1.Width) this._rect.Width = acPictureEdit1.Width;

                    if (this._rect.Height > acPictureEdit1.Height) this._rect.Height = acPictureEdit1.Height;

                    Bitmap bmp = new Bitmap(acPictureEdit1.Image, resize);
                    img = bmp.Clone(this._rect, bmp.PixelFormat);
                    bmp.Dispose();
                }
                else
                {
                    img = acPictureEdit1.Image;
                }
                //Image img = bmp.Clone(this._rect, bmp.PixelFormat);                

                int width = 200;//acPictureEdit1.Width / 3;
                int height = 152;//acPictureEdit1.Height / 3;
                resize = new Size(width, height);

                Bitmap resizeImage = new Bitmap(img, resize);

                this.OutputData = resizeImage;

                this.DialogResult = DialogResult.OK;

                this.Close();
              
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._rect = new Rectangle(0, 0, acPictureEdit1.Width, acPictureEdit1.Height);
        }

        public Bitmap ResizeImageToSave(Image image, int desWidth, int desHeight)
        {

            var bmp = new Bitmap(desWidth, desHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, desWidth, desHeight);
            }
            return bmp;
        }

        private void btnBarZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_nowLevel < 4)
                this._nowLevel++;

            SetZoom();
        }

        private void btnBarZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_nowLevel > -2)
                this._nowLevel--;

            SetZoom();
        }


        private void SetZoom()
        {
            switch(this._nowLevel)
            {
                case -2:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 0.5).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 0.5).toInt();
                    break;
                case -1:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 0.75).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 0.75).toInt();
                    break;
                case 0:
                    acPictureEdit1.Width = this._picWidth;
                    acPictureEdit1.Height = this._picHeight;
                    break;
                case 1:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 1.25).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 1.25).toInt();
                    break;
                case 2:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 1.5).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 1.5).toInt();
                    break;
                case 3:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 1.75).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 1.75).toInt();
                    break;
                case 4:
                    acPictureEdit1.Width = (this._picWidth.toDouble() * 2).toInt();
                    acPictureEdit1.Height = (this._picHeight.toDouble() * 2).toInt();
                    break;
            }
        }
    }

}