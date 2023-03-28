using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ControlManager
{
    public class acInput
    {


        public static WIN32API.KEYBDINPUT CreateKeybordInput(uint flags, ushort vkKey)
        {
            ControlManager.WIN32API.KEYBDINPUT ki = new WIN32API.KEYBDINPUT();

            ki.wVk = vkKey;
            ki.wScan = 0;
            ki.time = 0;
            ki.dwFlags = flags;
            ki.dwExtraInfo = IntPtr.Zero;

            return ki;

        }

        public static WIN32API.MOUSEINPUT CreateMouseInput(int x, int y, uint data, uint t, uint flag)
        {
            ControlManager.WIN32API.MOUSEINPUT mi = new WIN32API.MOUSEINPUT();
            mi.dx = x;
            mi.dy = y;
            mi.mouseData = data;
            mi.time = t;
            mi.dwFlags = flag;

            return mi;

        }

        public static void SendInput(WIN32API.INPUT[] input)
        {
            WIN32API.SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
        }
    }
}
