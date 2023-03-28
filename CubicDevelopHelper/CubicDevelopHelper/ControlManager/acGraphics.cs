using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ControlManager
{
    public class acGraphics
    {





        public static Bitmap Capturewindow(Control window)
        {
            IntPtr hBitmap;
            // 데스크탑 DC
            IntPtr hDC = WIN32API.GetWindowDC(window.Handle);
            // 데스크탑 DC 메모리
            IntPtr hMemDC = WIN32API.CreateCompatibleDC(hDC);
            // 데스크탑 DC 비트맵
            hBitmap = WIN32API.CreateCompatibleBitmap(hDC, window.Width, window.Height);
            if (hBitmap != IntPtr.Zero)
            {
                // 메모리에서 비트맵 가져오기
                IntPtr hold = (IntPtr)WIN32API.SelectObject(hMemDC, hBitmap);
                // DC에서 DC 메모리로 bit를 가져온다.
                WIN32API.BitBlt(hMemDC, 0, 0, window.Width, window.Height, hDC, 0, 0, WIN32API.SRCCOPY);
                // DC에서 DC 메모리로 복사
                WIN32API.SelectObject(hMemDC, hold);
                // DC 메모리 해제
                WIN32API.DeleteDC(hMemDC);
                // DC 해제
                WIN32API.ReleaseDC(WIN32API.GetDesktopWindow(), hDC);
                // 비트맵 정보를 복사
                Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap);
                // DC 비트맵 해제
                WIN32API.DeleteObject(hBitmap);

                GC.Collect();

                return bmp;
            }
            return null;
        }






        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        public static IntPtr pointeurCurseur;

        public static Cursor CreateCursor(Bitmap bmp_parm, int xHotSpot, int yHotSpot)
        {
            Image img = bmp_parm;
            Bitmap bmp = new Bitmap(img, new Size(img.Width * 1, img.Height * 1));

            //bmp.MakeTransparent(Color.White);

            if (pointeurCurseur != IntPtr.Zero) DestroyIcon(pointeurCurseur);

            IntPtr ptr = bmp.GetHicon();
            WIN32API.IconInfo tmp = new WIN32API.IconInfo();
            WIN32API.GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            pointeurCurseur = WIN32API.CreateIconIndirect(ref tmp);

            if (tmp.hbmColor != IntPtr.Zero) WIN32API.DeleteObject(tmp.hbmColor);
            if (tmp.hbmMask != IntPtr.Zero) WIN32API.DeleteObject(tmp.hbmMask);
            if (ptr != IntPtr.Zero) WIN32API.DestroyIcon(ptr);

            return new Cursor(pointeurCurseur);
        }





    }
}
