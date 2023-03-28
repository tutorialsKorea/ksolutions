﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlManager
{
    public class acRoundLabel : Label
    {
        public int cornerRadius = 15; //라운드 너비
        public Color borderColor = Color.DarkGray;//외곽선 색상
        public int borderWidth = 1;//외곽선 두께
        public Color backColor = Color.LightGray;//배경 색상

        public bool isFillLeftTop = false;//왼쪽위 사각으로 채우기(라운드 적용X)
        public bool isFillRightTop = false;//오른쪽위 사각으로 채우기(라운드 적용X)
        public bool isFillLeftBtm = false;//왼쪽아래 사각으로 채우기(라운드 적용X)
        public bool isFillRightBtm = false;//오른쪽아래 사각으로 채우기(라운드 적용X)

        //int diminisher = 1;

        public acRoundLabel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = _getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var brush = new SolidBrush(backColor);
                var pen = new Pen(borderColor, borderWidth);
                e.Graphics.FillPath(brush, graphicsPath);
                e.Graphics.DrawPath(pen, graphicsPath);

                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }

        private GraphicsPath _getRoundRectangle(Rectangle rectangle)
        {
            GraphicsPath path = new GraphicsPath();

            //path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);

            int left = rectangle.X;
            int top = rectangle.Y;
            int right = rectangle.X + rectangle.Width - borderWidth;
            int bottom = rectangle.Y + rectangle.Height - borderWidth;

            if (isFillLeftTop)
            {//좌상
                path.AddLine(left, top + cornerRadius, left, top);
                path.AddLine(left, top, left + cornerRadius, top);
            }
            else
            {
                path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            }
            if (isFillRightTop)
            {//우상
                path.AddLine(right - cornerRadius, top, right, top);
                path.AddLine(right, top, right, top + cornerRadius);
            }
            else
            {
                path.AddArc(rectangle.X + rectangle.Width - cornerRadius - borderWidth, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            }
            if (isFillRightBtm)
            {//우하
                path.AddLine(right, bottom - cornerRadius, right, bottom);
                path.AddLine(right, bottom, right - cornerRadius, bottom);
            }
            else
            {
                path.AddArc(rectangle.X + rectangle.Width - cornerRadius - borderWidth, rectangle.Y + rectangle.Height - cornerRadius - borderWidth, cornerRadius, cornerRadius, 0, 90);
            }
            if (isFillLeftBtm)
            {//좌하
                path.AddLine(left + cornerRadius, bottom, left, bottom);
                path.AddLine(left, bottom, left, bottom - cornerRadius);
            }
            else
            {
                path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - borderWidth, cornerRadius, cornerRadius, 90, 90);
            }

            path.CloseAllFigures();

            return path;
        }

    }
}
