using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace ControlManager
{
    public sealed class acKey
    {
        public static string GetShortCutName(System.Windows.Forms.Keys key)
        {
            return key.ToString();

        }


        public static System.Windows.Forms.Shortcut GetShortCut(short control, short alt, short shift, int WParam)
        {

            //short control = WIN32API.GetAsyncKeyState(WIN32API.VK_CONTROL);
            //short alt = WIN32API.GetAsyncKeyState(WIN32API.VK_ALT);
            //short shift = WIN32API.GetAsyncKeyState(WIN32API.VK_SHIFT);



            if (control < 0 && alt >= 0 && shift >= 0)
            {
                //CONTROL

                

                switch (WParam)
                {
                    case WIN32API.VK_0:

                        return System.Windows.Forms.Shortcut.Ctrl0;

                    case WIN32API.VK_1:

                        return System.Windows.Forms.Shortcut.Ctrl1;

                    case WIN32API.VK_2:

                        return System.Windows.Forms.Shortcut.Ctrl2;

                    case WIN32API.VK_3:

                        return System.Windows.Forms.Shortcut.Ctrl3;


                    case WIN32API.VK_4:

                        return System.Windows.Forms.Shortcut.Ctrl4;

                    case WIN32API.VK_5:

                        return System.Windows.Forms.Shortcut.Ctrl5;

                    case WIN32API.VK_6:

                        return System.Windows.Forms.Shortcut.Ctrl6;

                    case WIN32API.VK_7:

                        return System.Windows.Forms.Shortcut.Ctrl7;

                    case WIN32API.VK_8:

                        return System.Windows.Forms.Shortcut.Ctrl8;

                    case WIN32API.VK_9:

                        return System.Windows.Forms.Shortcut.Ctrl9;

                    case WIN32API.VK_A:

                        return System.Windows.Forms.Shortcut.CtrlA;

                    case WIN32API.VK_B:

                        return System.Windows.Forms.Shortcut.CtrlB;


                    case WIN32API.VK_C:

                        return System.Windows.Forms.Shortcut.CtrlC;


                    case WIN32API.VK_D:

                        return System.Windows.Forms.Shortcut.CtrlD;


                    case WIN32API.VK_E:

                        return System.Windows.Forms.Shortcut.CtrlE;


                    case WIN32API.VK_F:

                        return System.Windows.Forms.Shortcut.CtrlF;


                    case WIN32API.VK_G:

                        return System.Windows.Forms.Shortcut.CtrlG;


                    case WIN32API.VK_H:

                        return System.Windows.Forms.Shortcut.CtrlH;


                    case WIN32API.VK_I:

                        return System.Windows.Forms.Shortcut.CtrlI;


                    case WIN32API.VK_J:

                        return System.Windows.Forms.Shortcut.CtrlJ;


                    case WIN32API.VK_K:

                        return System.Windows.Forms.Shortcut.CtrlK;


                    case WIN32API.VK_L:

                        return System.Windows.Forms.Shortcut.CtrlL;

                    case WIN32API.VK_M:

                        return System.Windows.Forms.Shortcut.CtrlM;


                    case WIN32API.VK_N:

                        return System.Windows.Forms.Shortcut.CtrlN;

                    case WIN32API.VK_O:

                        return System.Windows.Forms.Shortcut.CtrlO;

                    case WIN32API.VK_P:

                        return System.Windows.Forms.Shortcut.CtrlP;

                    case WIN32API.VK_Q:

                        return System.Windows.Forms.Shortcut.CtrlQ;

                    case WIN32API.VK_R:

                        return System.Windows.Forms.Shortcut.CtrlR;


                    case WIN32API.VK_S:

                        return System.Windows.Forms.Shortcut.CtrlS;

                    case WIN32API.VK_T:

                        return System.Windows.Forms.Shortcut.CtrlT;

                    case WIN32API.VK_U:

                        return System.Windows.Forms.Shortcut.CtrlU;


                    case WIN32API.VK_V:

                        return System.Windows.Forms.Shortcut.CtrlV;

                    case WIN32API.VK_W:

                        return System.Windows.Forms.Shortcut.CtrlW;

                    case WIN32API.VK_X:

                        return System.Windows.Forms.Shortcut.CtrlX;


                    case WIN32API.VK_Y:

                        return System.Windows.Forms.Shortcut.CtrlY;

                    case WIN32API.VK_Z:

                        return System.Windows.Forms.Shortcut.CtrlZ;


                    case WIN32API.VK_F1:

                        return System.Windows.Forms.Shortcut.CtrlF1;

                    case WIN32API.VK_F2:

                        return System.Windows.Forms.Shortcut.CtrlF2;

                    case WIN32API.VK_F3:

                        return System.Windows.Forms.Shortcut.CtrlF3;

                    case WIN32API.VK_F4:

                        return System.Windows.Forms.Shortcut.CtrlF4;

                    case WIN32API.VK_F5:

                        return System.Windows.Forms.Shortcut.CtrlF5;

                    case WIN32API.VK_F6:

                        return System.Windows.Forms.Shortcut.CtrlF6;

                    case WIN32API.VK_F7:

                        return System.Windows.Forms.Shortcut.CtrlF7;

                    case WIN32API.VK_F8:

                        return System.Windows.Forms.Shortcut.CtrlF8;

                    case WIN32API.VK_F9:

                        return System.Windows.Forms.Shortcut.CtrlF9;

                    case WIN32API.VK_INSERT:

                        return System.Windows.Forms.Shortcut.CtrlIns;

                    case WIN32API.VK_DELETE:

                        return System.Windows.Forms.Shortcut.CtrlDel;

                }


            }
            else if (control < 0 && alt >= 0 && shift < 0)
            {
                //CONTROL & SHIFT
                switch (WParam)
                {

                    case WIN32API.VK_0:

                        return System.Windows.Forms.Shortcut.CtrlShift0;

                    case WIN32API.VK_1:

                        return System.Windows.Forms.Shortcut.CtrlShift1;

                    case WIN32API.VK_2:

                        return System.Windows.Forms.Shortcut.CtrlShift2;

                    case WIN32API.VK_3:

                        return System.Windows.Forms.Shortcut.CtrlShift3;

                    case WIN32API.VK_4:

                        return System.Windows.Forms.Shortcut.CtrlShift4;

                    case WIN32API.VK_5:

                        return System.Windows.Forms.Shortcut.CtrlShift5;

                    case WIN32API.VK_6:

                        return System.Windows.Forms.Shortcut.CtrlShift6;

                    case WIN32API.VK_7:

                        return System.Windows.Forms.Shortcut.CtrlShift7;

                    case WIN32API.VK_8:

                        return System.Windows.Forms.Shortcut.CtrlShift8;

                    case WIN32API.VK_A:

                        return System.Windows.Forms.Shortcut.CtrlShiftA;

                    case WIN32API.VK_B:

                        return System.Windows.Forms.Shortcut.CtrlShiftB;

                    case WIN32API.VK_C:

                        return System.Windows.Forms.Shortcut.CtrlShiftC;

                    case WIN32API.VK_D:

                        return System.Windows.Forms.Shortcut.CtrlShiftD;

                    case WIN32API.VK_E:

                        return System.Windows.Forms.Shortcut.CtrlShiftE;

                    case WIN32API.VK_F:

                        return System.Windows.Forms.Shortcut.CtrlShiftF;

                    case WIN32API.VK_G:

                        return System.Windows.Forms.Shortcut.CtrlShiftG;

                    case WIN32API.VK_H:

                        return System.Windows.Forms.Shortcut.CtrlShiftH;

                    case WIN32API.VK_I:

                        return System.Windows.Forms.Shortcut.CtrlShiftI;

                    case WIN32API.VK_J:

                        return System.Windows.Forms.Shortcut.CtrlShiftJ;

                    case WIN32API.VK_K:

                        return System.Windows.Forms.Shortcut.CtrlShiftK;

                    case WIN32API.VK_L:

                        return System.Windows.Forms.Shortcut.CtrlShiftL;

                    case WIN32API.VK_M:

                        return System.Windows.Forms.Shortcut.CtrlShiftM;

                    case WIN32API.VK_N:

                        return System.Windows.Forms.Shortcut.CtrlShiftN;

                    case WIN32API.VK_O:

                        return System.Windows.Forms.Shortcut.CtrlShiftO;

                    case WIN32API.VK_P:

                        return System.Windows.Forms.Shortcut.CtrlShiftP;

                    case WIN32API.VK_Q:

                        return System.Windows.Forms.Shortcut.CtrlShiftQ;

                    case WIN32API.VK_R:

                        return System.Windows.Forms.Shortcut.CtrlShiftR;

                    case WIN32API.VK_S:

                        return System.Windows.Forms.Shortcut.CtrlShiftS;

                    case WIN32API.VK_T:

                        return System.Windows.Forms.Shortcut.CtrlShiftT;

                    case WIN32API.VK_U:

                        return System.Windows.Forms.Shortcut.CtrlShiftU;

                    case WIN32API.VK_V:

                        return System.Windows.Forms.Shortcut.CtrlShiftV;

                    case WIN32API.VK_W:

                        return System.Windows.Forms.Shortcut.CtrlShiftW;

                    case WIN32API.VK_X:

                        return System.Windows.Forms.Shortcut.CtrlShiftX;

                    case WIN32API.VK_Y:

                        return System.Windows.Forms.Shortcut.CtrlShiftY;

                    case WIN32API.VK_Z:

                        return System.Windows.Forms.Shortcut.CtrlShiftZ;

                    case WIN32API.VK_F1:

                        return System.Windows.Forms.Shortcut.CtrlShiftF1;

                    case WIN32API.VK_F2:

                        return System.Windows.Forms.Shortcut.CtrlShiftF2;


                    case WIN32API.VK_F3:

                        return System.Windows.Forms.Shortcut.CtrlShiftF3;

                    case WIN32API.VK_F4:

                        return System.Windows.Forms.Shortcut.CtrlShiftF4;

                    case WIN32API.VK_F5:

                        return System.Windows.Forms.Shortcut.CtrlShiftF5;

                    case WIN32API.VK_F6:

                        return System.Windows.Forms.Shortcut.CtrlShiftF6;

                    case WIN32API.VK_F7:

                        return System.Windows.Forms.Shortcut.CtrlShiftF7;

                    case WIN32API.VK_F8:

                        return System.Windows.Forms.Shortcut.CtrlShiftF8;

                    case WIN32API.VK_F9:

                        return System.Windows.Forms.Shortcut.CtrlShiftF9;

                }
            }
            else if (control >= 0 && alt < 0 && shift >= 0)
            {
                //ALT
                switch (WParam)
                {
                    case WIN32API.VK_0:

                      return System.Windows.Forms.Shortcut.Alt0;

                    case WIN32API.VK_1:

                      return System.Windows.Forms.Shortcut.Alt1;

                    case WIN32API.VK_2:

                      return System.Windows.Forms.Shortcut.Alt2;

                    case WIN32API.VK_3:

                      return System.Windows.Forms.Shortcut.Alt3;

                    case WIN32API.VK_4:

                      return System.Windows.Forms.Shortcut.Alt4;

                    case WIN32API.VK_5:

                      return System.Windows.Forms.Shortcut.Alt5;

                    case WIN32API.VK_6:

                      return System.Windows.Forms.Shortcut.Alt6;

                    case WIN32API.VK_7:

                      return System.Windows.Forms.Shortcut.Alt7;

                    case WIN32API.VK_8:

                      return System.Windows.Forms.Shortcut.Alt8;

                    case WIN32API.VK_9:

                      return System.Windows.Forms.Shortcut.Alt9;

                    case WIN32API.VK_BACK:

                      return System.Windows.Forms.Shortcut.AltBksp;


                    case WIN32API.VK_LEFT:

                      return System.Windows.Forms.Shortcut.AltLeftArrow;

                    case WIN32API.VK_RIGHT:

                      return System.Windows.Forms.Shortcut.AltRightArrow;

                    case WIN32API.VK_UP:

                      return System.Windows.Forms.Shortcut.AltUpArrow;

                    case WIN32API.VK_DOWN:

                      return System.Windows.Forms.Shortcut.AltDownArrow;

                    case WIN32API.VK_F1:

                      return System.Windows.Forms.Shortcut.AltF1;

                    case WIN32API.VK_F2:

                      return System.Windows.Forms.Shortcut.AltF2;

                    case WIN32API.VK_F3:

                      return System.Windows.Forms.Shortcut.AltF3;

                    case WIN32API.VK_F4:

                      return System.Windows.Forms.Shortcut.AltF4;

                    case WIN32API.VK_F5:

                      return System.Windows.Forms.Shortcut.AltF5;

                    case WIN32API.VK_F6:

                      return System.Windows.Forms.Shortcut.AltF6;

                    case WIN32API.VK_F7:

                      return System.Windows.Forms.Shortcut.AltF7;

                    case WIN32API.VK_F8:

                      return System.Windows.Forms.Shortcut.AltF8;

                    case WIN32API.VK_F9:

                      return System.Windows.Forms.Shortcut.AltF9;

                }

            }
            else if (control >= 0 && alt >= 0 && shift < 0)
            {
                //SHIFT

                switch (WParam)
                {
                    case WIN32API.VK_DELETE:

                        return System.Windows.Forms.Shortcut.ShiftDel;

                    case WIN32API.VK_INSERT:

                        return System.Windows.Forms.Shortcut.ShiftIns;

                    case WIN32API.VK_F1:

                        return System.Windows.Forms.Shortcut.ShiftF1;

                    case WIN32API.VK_F2:

                        return System.Windows.Forms.Shortcut.ShiftF2;

                    case WIN32API.VK_F3:

                        return System.Windows.Forms.Shortcut.ShiftF3;


                    case WIN32API.VK_F4:

                        return System.Windows.Forms.Shortcut.ShiftF4;


                    case WIN32API.VK_F5:

                        return System.Windows.Forms.Shortcut.ShiftF5;


                    case WIN32API.VK_F6:

                        return System.Windows.Forms.Shortcut.ShiftF6;


                    case WIN32API.VK_F7:

                        return System.Windows.Forms.Shortcut.ShiftF7;


                    case WIN32API.VK_F8:

                        return System.Windows.Forms.Shortcut.ShiftF8;


                    case WIN32API.VK_F9:

                        return System.Windows.Forms.Shortcut.ShiftF9;
                }

            }
            else if (control >= 0 && alt >= 0 && shift >= 0)
            {
                switch (WParam)
                {
                    case WIN32API.VK_F1:

                        return System.Windows.Forms.Shortcut.F1;

                    case WIN32API.VK_F2:

                        return System.Windows.Forms.Shortcut.F2;

                    case WIN32API.VK_F3:

                        return System.Windows.Forms.Shortcut.F3;

                    case WIN32API.VK_F4:

                        return System.Windows.Forms.Shortcut.F4;

                    case WIN32API.VK_F5:

                        return System.Windows.Forms.Shortcut.F5;

                    case WIN32API.VK_F6:

                        return System.Windows.Forms.Shortcut.F6;

                    case WIN32API.VK_F7:

                        return System.Windows.Forms.Shortcut.F7;

                    case WIN32API.VK_F8:

                        return System.Windows.Forms.Shortcut.F8;

                    case WIN32API.VK_F9:

                        return System.Windows.Forms.Shortcut.F9;

                }

            }



            return System.Windows.Forms.Shortcut.None;

        }


        public static string GetShortCutName(System.Windows.Forms.Shortcut sc)
        {
            switch (sc)
            {
                case System.Windows.Forms.Shortcut.F1:

                    return "F1";

                case System.Windows.Forms.Shortcut.F2:

                    return "F2";

                case System.Windows.Forms.Shortcut.F3:

                    return "F3";

                case System.Windows.Forms.Shortcut.F4:

                    return "F4";

                case System.Windows.Forms.Shortcut.F5:

                    return "F5";

                case System.Windows.Forms.Shortcut.F6:

                    return "F6";

                case System.Windows.Forms.Shortcut.F7:

                    return "F7";

                case System.Windows.Forms.Shortcut.F8:

                    return "F8";

                case System.Windows.Forms.Shortcut.F9:

                    return "F9";

                                       
                case System.Windows.Forms.Shortcut.Alt0:

                    return "Alt + 0";

                case System.Windows.Forms.Shortcut.Alt1:

                    return "Alt + 1";

                case System.Windows.Forms.Shortcut.Alt2:

                    return "Alt + 2";

                case System.Windows.Forms.Shortcut.Alt3:

                    return "Alt + 3";

                case System.Windows.Forms.Shortcut.Alt4:

                    return "Alt + 4";

                case System.Windows.Forms.Shortcut.Alt5:

                    return "Alt + 5";

                case System.Windows.Forms.Shortcut.Alt6:

                    return "Alt + 6";

                case System.Windows.Forms.Shortcut.Alt7:

                    return "Alt + 7";

                case System.Windows.Forms.Shortcut.Alt8:

                    return "Alt + 8";

                case System.Windows.Forms.Shortcut.Alt9:

                    return "Alt + 9";

                case System.Windows.Forms.Shortcut.AltBksp:

                    return "Alt + BackSpace";

                case System.Windows.Forms.Shortcut.AltDownArrow:

                    return "Alt + ↓";

                case System.Windows.Forms.Shortcut.AltF1:

                    return "Alt + F1";

                case System.Windows.Forms.Shortcut.AltF10:

                    return "Alt + F10";

                case System.Windows.Forms.Shortcut.AltF11:

                    return "Alt + F11";

                case System.Windows.Forms.Shortcut.AltF12:

                    return "Alt + F12";

                case System.Windows.Forms.Shortcut.AltF2:

                    return "Alt + F2";

                case System.Windows.Forms.Shortcut.AltF3:

                    return "Alt + F3";
                case System.Windows.Forms.Shortcut.AltF4:

                    return "Alt + F4";

                case System.Windows.Forms.Shortcut.AltF5:

                    return "Alt + F5";

                case System.Windows.Forms.Shortcut.AltF6:

                    return "Alt + F6";

                case System.Windows.Forms.Shortcut.AltF7:

                    return "Alt + F7";

                case System.Windows.Forms.Shortcut.AltF8:

                    return "Alt + F8";

                case System.Windows.Forms.Shortcut.AltF9:

                    return "Alt + F9";

                case System.Windows.Forms.Shortcut.AltLeftArrow:

                    return "Alt + ←";

                case System.Windows.Forms.Shortcut.AltRightArrow:

                    return "Alt + →";

                case System.Windows.Forms.Shortcut.AltUpArrow:

                    return "Alt + ↑";

                case System.Windows.Forms.Shortcut.Ctrl0:

                    return "Ctrl + 0";

                case System.Windows.Forms.Shortcut.Ctrl1:

                    return "Ctrl + 1";

                case System.Windows.Forms.Shortcut.Ctrl2:

                    return "Ctrl + 2";

                case System.Windows.Forms.Shortcut.Ctrl3:

                    return "Ctrl + 3";

                case System.Windows.Forms.Shortcut.Ctrl4:

                    return "Ctrl + 4";

                case System.Windows.Forms.Shortcut.Ctrl5:

                    return "Ctrl + 5";

                case System.Windows.Forms.Shortcut.Ctrl6:

                    return "Ctrl + 6";

                case System.Windows.Forms.Shortcut.Ctrl7:

                    return "Ctrl + 7";

                case System.Windows.Forms.Shortcut.Ctrl8:

                    return "Ctrl + 8";

                case System.Windows.Forms.Shortcut.Ctrl9:

                    return "Ctrl + 9";

                case System.Windows.Forms.Shortcut.CtrlA:

                    return "Ctrl + A";

                case System.Windows.Forms.Shortcut.CtrlB:

                    return "Ctrl + B";

                case System.Windows.Forms.Shortcut.CtrlC:

                    return "Ctrl + C";

                case System.Windows.Forms.Shortcut.CtrlD:

                    return "Ctrl + D";

                case System.Windows.Forms.Shortcut.CtrlDel:

                    return "Ctrl + Delete";

                case System.Windows.Forms.Shortcut.CtrlE:

                    return "Ctrl + E";

                case System.Windows.Forms.Shortcut.CtrlF:

                    return "Ctrl + F";

                case System.Windows.Forms.Shortcut.CtrlF1:

                    return "Ctrl + F1";

                case System.Windows.Forms.Shortcut.CtrlF10:

                    return "Ctrl + F10";

                case System.Windows.Forms.Shortcut.CtrlF11:

                    return "Ctrl + F11";

                case System.Windows.Forms.Shortcut.CtrlF12:

                    return "Ctrl + F12";

                case System.Windows.Forms.Shortcut.CtrlF2:

                    return "Ctrl + F2";

                case System.Windows.Forms.Shortcut.CtrlF3:

                    return "Ctrl + F3";

                case System.Windows.Forms.Shortcut.CtrlF4:

                    return "Ctrl + F4";

                case System.Windows.Forms.Shortcut.CtrlF5:

                    return "Ctrl + F5";

                case System.Windows.Forms.Shortcut.CtrlF6:

                    return "Ctrl + F6";

                case System.Windows.Forms.Shortcut.CtrlF7:

                    return "Ctrl + F7";

                case System.Windows.Forms.Shortcut.CtrlF8:

                    return "Ctrl + F8";

                case System.Windows.Forms.Shortcut.CtrlF9:

                    return "Ctrl + F9";

                case System.Windows.Forms.Shortcut.CtrlG:

                    return "Ctrl + G";

                case System.Windows.Forms.Shortcut.CtrlH:

                    return "Ctrl + H";

                case System.Windows.Forms.Shortcut.CtrlI:

                    return "Ctrl + I";

                case System.Windows.Forms.Shortcut.CtrlIns:

                    return "Ctrl + Insert";

                case System.Windows.Forms.Shortcut.CtrlJ:

                    return "Ctrl + J";

                case System.Windows.Forms.Shortcut.CtrlK:

                    return "Ctrl + K";

                case System.Windows.Forms.Shortcut.CtrlL:

                    return "Ctrl + L";

                case System.Windows.Forms.Shortcut.CtrlM:

                    return "Ctrl + M";

                case System.Windows.Forms.Shortcut.CtrlN:

                    return "Ctrl + N";

                case System.Windows.Forms.Shortcut.CtrlO:

                    return "Ctrl + O";

                case System.Windows.Forms.Shortcut.CtrlP:

                    return "Ctrl + P";

                case System.Windows.Forms.Shortcut.CtrlQ:

                    return "Ctrl + Q";

                case System.Windows.Forms.Shortcut.CtrlR:

                    return "Ctrl + R";

                case System.Windows.Forms.Shortcut.CtrlS:

                    return "Ctrl + S";

                case System.Windows.Forms.Shortcut.CtrlShift0:

                    return "Ctrl + Shift + 0";


                case System.Windows.Forms.Shortcut.CtrlShift1:

                    return "Ctrl + Shift + 1";

                case System.Windows.Forms.Shortcut.CtrlShift2:

                    return "Ctrl + Shift + 2";

                case System.Windows.Forms.Shortcut.CtrlShift3:

                    return "Ctrl + Shift + 3";

                case System.Windows.Forms.Shortcut.CtrlShift4:

                    return "Ctrl + Shift + 4";

                case System.Windows.Forms.Shortcut.CtrlShift5:

                    return "Ctrl + Shift + 5";

                case System.Windows.Forms.Shortcut.CtrlShift6:

                    return "Ctrl + Shift + 6";

                case System.Windows.Forms.Shortcut.CtrlShift7:

                    return "Ctrl + Shift + 7";

                case System.Windows.Forms.Shortcut.CtrlShift8:

                    return "Ctrl + Shift + 8";

                case System.Windows.Forms.Shortcut.CtrlShift9:

                    return "Ctrl + Shift + 9";

                case System.Windows.Forms.Shortcut.CtrlShiftA:

                    return "Ctrl + Shift + A";

                case System.Windows.Forms.Shortcut.CtrlShiftB:

                    return "Ctrl + Shift + B";

                case System.Windows.Forms.Shortcut.CtrlShiftC:

                    return "Ctrl + Shift + C";

                case System.Windows.Forms.Shortcut.CtrlShiftD:

                    return "Ctrl + Shift + D";

                case System.Windows.Forms.Shortcut.CtrlShiftE:

                    return "Ctrl + Shift + E";

                case System.Windows.Forms.Shortcut.CtrlShiftF:

                    return "Ctrl + Shift + F";

                case System.Windows.Forms.Shortcut.CtrlShiftF1:

                    return "Ctrl + Shift + F1";

                case System.Windows.Forms.Shortcut.CtrlShiftF10:

                    return "Ctrl + Shift + F10";

                case System.Windows.Forms.Shortcut.CtrlShiftF11:

                    return "Ctrl + Shift + F11";

                case System.Windows.Forms.Shortcut.CtrlShiftF12:

                    return "Ctrl + Shift + F12";

                case System.Windows.Forms.Shortcut.CtrlShiftF2:

                    return "Ctrl + Shift + F2";

                case System.Windows.Forms.Shortcut.CtrlShiftF3:

                    return "Ctrl + Shift + F3";

                case System.Windows.Forms.Shortcut.CtrlShiftF4:

                    return "Ctrl + Shift + F4";

                case System.Windows.Forms.Shortcut.CtrlShiftF5:

                    return "Ctrl + Shift + F5";


                case System.Windows.Forms.Shortcut.CtrlShiftF6:

                    return "Ctrl + Shift + F6";

                case System.Windows.Forms.Shortcut.CtrlShiftF7:

                    return "Ctrl + Shift + F7";

                case System.Windows.Forms.Shortcut.CtrlShiftF8:

                    return "Ctrl + Shift + F8";

                case System.Windows.Forms.Shortcut.CtrlShiftF9:

                    return "Ctrl + Shift + F9";

                case System.Windows.Forms.Shortcut.CtrlShiftG:

                    return "Ctrl + Shift + G";

                case System.Windows.Forms.Shortcut.CtrlShiftH:

                    return "Ctrl + Shift + H";

                case System.Windows.Forms.Shortcut.CtrlShiftI:

                    return "Ctrl + Shift + I";

                case System.Windows.Forms.Shortcut.CtrlShiftJ:

                    return "Ctrl + Shift + J";

                case System.Windows.Forms.Shortcut.CtrlShiftK:

                    return "Ctrl + Shift + K";

                case System.Windows.Forms.Shortcut.CtrlShiftL:

                    return "Ctrl + Shift + L";

                case System.Windows.Forms.Shortcut.CtrlShiftM:

                    return "Ctrl + Shift + M";

                case System.Windows.Forms.Shortcut.CtrlShiftN:

                    return "Ctrl + Shift + N";

                case System.Windows.Forms.Shortcut.CtrlShiftO:

                    return "Ctrl + Shift + O";

                case System.Windows.Forms.Shortcut.CtrlShiftP:

                    return "Ctrl + Shift + P";

                case System.Windows.Forms.Shortcut.CtrlShiftQ:

                    return "Ctrl + Shift + Q";

                case System.Windows.Forms.Shortcut.CtrlShiftR:

                    return "Ctrl + Shift + R";

                case System.Windows.Forms.Shortcut.CtrlShiftS:

                    return "Ctrl + Shift + S";

                case System.Windows.Forms.Shortcut.CtrlShiftT:

                    return "Ctrl + Shift + T";

                case System.Windows.Forms.Shortcut.CtrlShiftU:

                    return "Ctrl + Shift + U";

                case System.Windows.Forms.Shortcut.CtrlShiftV:

                    return "Ctrl + Shift + V";

                case System.Windows.Forms.Shortcut.CtrlShiftW:

                    return "Ctrl + Shift + W";

                case System.Windows.Forms.Shortcut.CtrlShiftX:

                    return "Ctrl + Shift + X";

                case System.Windows.Forms.Shortcut.CtrlShiftY:

                    return "Ctrl + Shift + Y";

                case System.Windows.Forms.Shortcut.CtrlShiftZ:

                    return "Ctrl + Shift + Z";

                case System.Windows.Forms.Shortcut.CtrlT:

                    return "Ctrl + T";

                case System.Windows.Forms.Shortcut.CtrlU:

                    return "Ctrl + U";

                case System.Windows.Forms.Shortcut.CtrlV:

                    return "Ctrl + V";

                case System.Windows.Forms.Shortcut.CtrlW:

                    return "Ctrl + W";

                case System.Windows.Forms.Shortcut.CtrlX:

                    return "Ctrl + X";

                case System.Windows.Forms.Shortcut.CtrlY:

                    return "Ctrl + Y";

                case System.Windows.Forms.Shortcut.CtrlZ:

                    return "Ctrl + Z";

                case System.Windows.Forms.Shortcut.ShiftDel:

                    return "Shift + Delete";

                case System.Windows.Forms.Shortcut.ShiftF1:

                    return "Shift + F1";

                case System.Windows.Forms.Shortcut.ShiftF10:

                    return "Shift + F10";

                case System.Windows.Forms.Shortcut.ShiftF11:

                    return "Shift + F11";

                case System.Windows.Forms.Shortcut.ShiftF12:

                    return "Shift + F12";

                case System.Windows.Forms.Shortcut.ShiftF2:

                    return "Shift + F2";

                case System.Windows.Forms.Shortcut.ShiftF3:

                    return "Shift + F3";

                case System.Windows.Forms.Shortcut.ShiftF4:

                    return "Shift + F4";

                case System.Windows.Forms.Shortcut.ShiftF5:

                    return "Shift + F5";

                case System.Windows.Forms.Shortcut.ShiftF6:

                    return "Shift + F6";

                case System.Windows.Forms.Shortcut.ShiftF7:

                    return "Shift + F7";

                case System.Windows.Forms.Shortcut.ShiftF8:

                    return "Shift + F8";

                case System.Windows.Forms.Shortcut.ShiftF9:

                    return "Shift + F9";

                case System.Windows.Forms.Shortcut.ShiftIns:

                    return "Shift + Insert";

                default:

                    return sc.ToString();

            }

        }



        public sealed class InputDevice
        {
            #region const definitions

            // The following constants are defined in Windows.h

            private const int RIDEV_INPUTSINK = 0x00000100;
            private const int RID_INPUT = 0x10000003;

            private const int FAPPCOMMAND_MASK = 0xF000;
            private const int FAPPCOMMAND_MOUSE = 0x8000;
            private const int FAPPCOMMAND_OEM = 0x1000;

            private const int RIM_TYPEMOUSE = 0;
            private const int RIM_TYPEKEYBOARD = 1;
            private const int RIM_TYPEHID = 2;

            private const int RIDI_DEVICENAME = 0x20000007;

            private const int WM_KEYDOWN = 0x0100;
            private const int WM_SYSKEYDOWN = 0x0104;
            private const int WM_INPUT = 0x00FF;
            private const int VK_OEM_CLEAR = 0xFE;
            private const int VK_LAST_KEY = VK_OEM_CLEAR; // this is a made up value used as a sentinel

            #endregion const definitions

            #region structs & enums

            /// <summary>
            /// An enum representing the different types of input devices.
            /// </summary>
            public enum DeviceType
            {
                Key,
                Mouse,
                OEM,
                UNKNOWN
            }

            /// <summary>
            /// Class encapsulating the information about a
            /// keyboard event, including the device it
            /// originated with and what key was pressed
            /// </summary>
            public class DeviceInfo
            {
                public string deviceName;
                public string deviceType;
                public IntPtr deviceHandle;
                public string Name;
                public string source;
                public ushort key;
                public string vKey;
            }

            #region Windows.h structure declarations

            // The following structures are defined in Windows.h

            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWINPUTDEVICELIST
            {
                public IntPtr hDevice;
                [MarshalAs(UnmanagedType.U4)]
                public int dwType;
            }

            [StructLayout(LayoutKind.Explicit)]
            internal struct RAWINPUTDATA
            {
                [FieldOffset(0)]
                private IntPtr _pad;
                [FieldOffset(0)]
                public RAWMOUSE mouse;
                [FieldOffset(0)]
                public RAWKEYBOARD keyboard;
                [FieldOffset(0)]
                public RAWHID hid;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWINPUT
            {
                public RAWINPUTHEADER header;
                public RAWINPUTDATA data;
            }


            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWINPUTHEADER
            {
                [MarshalAs(UnmanagedType.U4)]
                public int dwType;
                [MarshalAs(UnmanagedType.U4)]
                public int dwSize;
                public IntPtr hDevice;
                public IntPtr wParam;
            }


            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWHID
            {
                [MarshalAs(UnmanagedType.U4)]
                public int dwSizHid;
                [MarshalAs(UnmanagedType.U4)]
                public int dwCount;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct BUTTONSSTR
            {
                [MarshalAs(UnmanagedType.U2)]
                public ushort usButtonFlags;
                [MarshalAs(UnmanagedType.U2)]
                public ushort usButtonData;
            }

            [StructLayout(LayoutKind.Explicit)]
            internal struct RAWMOUSE
            {
                [MarshalAs(UnmanagedType.U2)]
                [FieldOffset(0)]
                public ushort usFlags;
                [MarshalAs(UnmanagedType.U4)]
                [FieldOffset(4)]
                public uint ulButtons;
                [FieldOffset(4)]
                public BUTTONSSTR buttonsStr;
                [MarshalAs(UnmanagedType.U4)]
                [FieldOffset(8)]
                public uint ulRawButtons;
                [FieldOffset(12)]
                public int lLastX;
                [FieldOffset(16)]
                public int lLastY;
                [MarshalAs(UnmanagedType.U4)]
                [FieldOffset(20)]
                public uint ulExtraInformation;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWKEYBOARD
            {
                [MarshalAs(UnmanagedType.U2)]
                public ushort MakeCode;
                [MarshalAs(UnmanagedType.U2)]
                public ushort Flags;
                [MarshalAs(UnmanagedType.U2)]
                public ushort Reserved;
                [MarshalAs(UnmanagedType.U2)]
                public ushort VKey;
                [MarshalAs(UnmanagedType.U4)]
                public uint Message;
                [MarshalAs(UnmanagedType.U4)]
                public uint ExtraInformation;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct RAWINPUTDEVICE
            {
                [MarshalAs(UnmanagedType.U2)]
                public ushort usUsagePage;
                [MarshalAs(UnmanagedType.U2)]
                public ushort usUsage;
                [MarshalAs(UnmanagedType.U4)]
                public int dwFlags;
                public IntPtr hwndTarget;
            }
            #endregion Windows.h structure declarations


            #endregion structs & enums

            #region DllImports

            [DllImport("User32.dll")]
            extern static uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint uiNumDevices, uint cbSize);

            [DllImport("User32.dll")]
            extern static uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

            [DllImport("User32.dll")]
            extern static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices, uint cbSize);

            [DllImport("User32.dll")]
            extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

            #endregion DllImports

            #region Variables and event handling

            /// <summary>
            /// List of keyboard devices. Key: the device handle
            /// Value: the device info class
            /// </summary>
            private Hashtable deviceList = new Hashtable();

            /// <summary>
            /// The delegate to handle KeyPressed events.
            /// </summary>
            /// <param name="sender">The object sending the event.</param>
            /// <param name="e">A set of KeyControlEventArgs information about the key that was pressed and the device it was on.</param>
            public delegate void DeviceEventHandler(object sender, KeyControlEventArgs e);

            /// <summary>
            /// The event raised when InputDevice detects that a key was pressed.
            /// </summary>
            public event DeviceEventHandler KeyPressed;

            /// <summary>
            /// Arguments provided by the handler for the KeyPressed
            /// event.
            /// </summary>
            public class KeyControlEventArgs : EventArgs
            {
                private DeviceInfo m_deviceInfo;
                private DeviceType m_device;

                public KeyControlEventArgs(DeviceInfo dInfo, DeviceType device)
                {
                    m_deviceInfo = dInfo;
                    m_device = device;
                }

                public KeyControlEventArgs()
                {
                }

                public DeviceInfo Keyboard
                {
                    get { return m_deviceInfo; }
                    set { m_deviceInfo = value; }
                }

                public DeviceType Device
                {
                    get { return m_device; }
                    set { m_device = value; }
                }
            }

            #endregion Variables and event handling

            #region InputDevice( IntPtr hwnd )

            public IntPtr Handle = IntPtr.Zero;

            /// <summary>
            /// InputDevice constructor; registers the raw input devices
            /// for the calling window.
            /// </summary>
            /// <param name="hwnd">Handle of the window listening for key presses</param>
            public InputDevice(IntPtr hwnd)
            {
                //Create an array of all the raw input devices we want to 
                //listen to. In this case, only keyboard devices.
                //RIDEV_INPUTSINK determines that the window will continue
                //to receive messages even when it doesn't have the focus.
                RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];

                rid[0].usUsagePage = 0x01;
                rid[0].usUsage = 0x06;
                rid[0].dwFlags = RIDEV_INPUTSINK;
                rid[0].hwndTarget = hwnd;

                this.Handle = hwnd;

                if (!RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
                {
                    throw new ApplicationException("Failed to register raw input device(s).");
                }
            }

            #endregion InputDevice( IntPtr hwnd )

            #region ReadReg( string item, ref bool isKeyboard )

            /// <summary>
            /// Reads the Registry to retrieve a friendly description
            /// of the device, and determine whether it is a keyboard.
            /// </summary>
            /// <param name="item">The device name to search for, as provided by GetRawInputDeviceInfo.</param>
            /// <param name="isKeyboard">Determines whether the device's class is "Keyboard".</param>
            /// <returns>The device description stored in the Registry entry's DeviceDesc value.</returns>
            private string ReadReg(string item, ref bool isKeyboard)
            {
                // Example Device Identification string
                // @"\??\ACPI#PNP0303#3&13c0b0c5&0#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}";

                try
                {
                    // remove the \??\
                    item = item.Substring(4);

                    string[] split = item.Split('#');

                    string id_01 = split[0];    // ACPI (Class code)
                    string id_02 = split[1];    // PNP0303 (SubClass code)
                    string id_03 = split[2];    // 3&13c0b0c5&0 (Protocol code)
                    //The final part is the class GUID and is not needed here

                    //Open the appropriate key as read-only so no permissions
                    //are needed.
                    Microsoft.Win32.RegistryKey OurKey = Microsoft.Win32.Registry.LocalMachine;

                    string findme = string.Format(@"System\CurrentControlSet\Enum\{0}\{1}\{2}", id_01, id_02, id_03);

                    OurKey = OurKey.OpenSubKey(findme, false);

                    //Retrieve the desired information and set isKeyboard
                    string deviceDesc = (string)OurKey.GetValue("DeviceDesc");
                    string deviceClass = (string)OurKey.GetValue("Class");

                    //if (deviceClass.ToUpper().Equals("KEYBOARD"))
                    //{
                    //    isKeyboard = true;
                    //}
                    //else
                    //{
                    //    isKeyboard = false;
                    //}
                    if (deviceDesc.IndexOf("keyboard", 0) > -1)
                    {
                        isKeyboard = true;
                    }
                    else
                    {
                        isKeyboard = false;
                    }
                    return deviceDesc;

                }
                catch
                {
                    return string.Empty;
                }
            }

            #endregion ReadReg( string item, ref bool isKeyboard )

            #region int EnumerateDevices()

            /// <summary>
            /// Iterates through the list provided by GetRawInputDeviceList,
            /// counting keyboard devices and adding them to deviceList.
            /// </summary>
            /// <returns>The number of keyboard devices found.</returns>
            public int EnumerateDevices()
            {

                int NumberOfDevices = 0;
                uint deviceCount = 0;
                int dwSize = (Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));

                // Get the number of raw input devices in the list,
                // then allocate sufficient memory and get the entire list
                if (GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)dwSize) == (uint)0)
                {
                    IntPtr pRawInputDeviceList = Marshal.AllocHGlobal((int)(dwSize * deviceCount));
                    GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, (uint)dwSize);
                    
                    // Iterate through the list, discarding undesired items
                    // and retrieving further information on keyboard devices
                    for (int i = 0; i < deviceCount; i++)
                    {
                        DeviceInfo dInfo;
                        string deviceName;
                        uint pcbSize = 0;
                        
                        RAWINPUTDEVICELIST rid = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(
                                                   IntPtr.Add(pRawInputDeviceList, (dwSize * i)),
                                                   typeof(RAWINPUTDEVICELIST));
                        GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, IntPtr.Zero, ref pcbSize);
                        if (pcbSize > 0)
                        {
                            IntPtr pData = Marshal.AllocHGlobal((int)pcbSize);
                            GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, pData, ref pcbSize);
                            deviceName = (string)Marshal.PtrToStringAnsi(pData);
                            
                            // Drop the "root" keyboard and mouse devices used for Terminal 
                            // Services and the Remote Desktop
                            if (deviceName.ToUpper().Contains("ROOT"))
                            {
                                continue;
                            }

                            // If the device is identified in the list as a keyboard or 
                            // HID device, create a DeviceInfo object to store information 
                            // about it
                            if (rid.dwType == RIM_TYPEKEYBOARD || rid.dwType == RIM_TYPEHID)
                            {
                                dInfo = new DeviceInfo();

                                dInfo.deviceName = (string)Marshal.PtrToStringAnsi(pData);
                                dInfo.deviceHandle = rid.hDevice;
                                dInfo.deviceType = GetDeviceType(rid.dwType);

                                // Check the Registry to see whether this is actually a 
                                // keyboard, and to retrieve a more friendly description.
                                bool IsKeyboardDevice = false;
                                string DeviceDesc = ReadReg(deviceName, ref IsKeyboardDevice);
                                dInfo.Name = DeviceDesc;

                                // If it is a keyboard and it isn't already in the list,
                                // add it to the deviceList hashtable and increase the
                                // NumberOfDevices count
                                if (!deviceList.Contains(rid.hDevice) && IsKeyboardDevice)
                                {
                                    NumberOfDevices++;
                                    deviceList.Add(rid.hDevice, dInfo);
                                }
                            }
                            Marshal.FreeHGlobal(pData);
                        }
                    }


                    Marshal.FreeHGlobal(pRawInputDeviceList);

                    return NumberOfDevices;

                }
                else
                {
                    throw new ApplicationException("An error occurred while retrieving the list of devices.");
                }

            }

            #endregion EnumerateDevices()

            #region ProcessInputCommand( Message message )

            /// <summary>
            /// Processes WM_INPUT messages to retrieve information about any
            /// keyboard events that occur.
            /// </summary>
            /// <param name="message">The WM_INPUT message to process.</param>
            public void ProcessInputCommand(System.Windows.Forms.Message message)
            {
                uint dwSize = 0;

                // First call to GetRawInputData sets the value of dwSize,
                // which can then be used to allocate the appropriate amount of memory,
                // storing the pointer in "buffer".
                GetRawInputData(message.LParam,
                                 RID_INPUT, IntPtr.Zero,
                                 ref dwSize,
                                 (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

                IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
                try
                {
                    // Check that buffer points to something, and if so,
                    // call GetRawInputData again to fill the allocated memory
                    // with information about the input
                    if (buffer != IntPtr.Zero &&
                        GetRawInputData(message.LParam,
                                         RID_INPUT,
                                         buffer,
                                         ref dwSize,
                                         (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER))) == dwSize)
                    {
                        // Store the message information in "raw", then check
                        // that the input comes from a keyboard device before
                        // processing it to raise an appropriate KeyPressed event.

                        RAWINPUT raw = (RAWINPUT)Marshal.PtrToStructure(buffer, typeof(RAWINPUT));

                        if (raw.header.dwType == RIM_TYPEKEYBOARD)
                        {
                            // Filter for Key Down events and then retrieve information 
                            // about the keystroke
                            if (raw.data.keyboard.Message == WM_KEYDOWN || raw.data.keyboard.Message == WM_SYSKEYDOWN)
                            {

                                ushort key = raw.data.keyboard.VKey;

                                // On most keyboards, "extended" keys such as the arrow or 
                                // page keys return two codes - the key's own code, and an
                                // "extended key" flag, which translates to 255. This flag
                                // isn't useful to us, so it can be disregarded.
                                if (key > VK_LAST_KEY)
                                {
                                    return;
                                }

                                // Retrieve information about the device and the
                                // key that was pressed.
                                DeviceInfo dInfo = null;

                                if (deviceList.Contains(raw.header.hDevice))
                                {
                                    System.Windows.Forms.Keys myKey;

                                    dInfo = (DeviceInfo)deviceList[raw.header.hDevice];

                                    myKey = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), Enum.GetName(typeof(System.Windows.Forms.Keys), key));
                                    dInfo.vKey = myKey.ToString();
                                    dInfo.key = key;
                                }
                                else
                                {
                                    //string errMessage = String.Format("Handle :{0} was not in hashtable. The device may support more than one handle or usage page, and is probably not a standard keyboard.", raw.header.hDevice);
                                    //throw new ApplicationException(errMessage);
                                }

                                if (dInfo != null)
                                {
                                    dInfo.deviceName = dInfo.deviceName.ToUpper();
                                }

                                // If the key that was pressed is valid and there
                                // was no problem retrieving information on the device,
                                // raise the KeyPressed event.
                                if (KeyPressed != null && dInfo != null)
                                {
                                    KeyPressed(this, new KeyControlEventArgs(dInfo, GetDevice(message.LParam.ToInt32())));
                                }
                                else
                                {
                                    //KeyPressed(this, new KeyControlEventArgs(dInfo, DeviceType.UNKNOWN));

                                    //string errMessage = String.Format("Received Unknown Key: {0}. Possibly an unknown device", key);
                                    //throw new ApplicationException(errMessage);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }


            }

            #endregion ProcessInputCommand( Message message )

            #region DeviceType GetDevice( int param )

            /// <summary>
            /// Determines what type of device triggered a WM_INPUT message.
            /// (Used in the ProcessInputCommand method).
            /// </summary>
            /// <param name="param">The LParam from a WM_INPUT message.</param>
            /// <returns>A DeviceType enum value.</returns>
            private DeviceType GetDevice(int param)
            {
                DeviceType deviceType;

                switch ((int)(((ushort)(param >> 16)) & FAPPCOMMAND_MASK))
                {
                    case FAPPCOMMAND_OEM:
                        deviceType = DeviceType.OEM;
                        break;
                    case FAPPCOMMAND_MOUSE:
                        deviceType = DeviceType.Mouse;
                        break;
                    default:
                        deviceType = DeviceType.Key;
                        break;
                }

                return deviceType;
            }

            #endregion DeviceType GetDevice( int param )

            #region ProcessMessage( Message message )

            /// <summary>
            /// Filters Windows messages for WM_INPUT messages and calls
            /// ProcessInputCommand if necessary.
            /// </summary>
            /// <param name="message">The Windows message.</param>
            public void ProcessMessage(System.Windows.Forms.Message message)
            {
                switch (message.Msg)
                {
                    case WM_INPUT:
                        {
                            ProcessInputCommand(message);
                        }
                        break;
                }
            }

            #endregion ProcessMessage( Message message )

            #region GetDeviceType( int device )

            /// <summary>
            /// Converts a RAWINPUTDEVICELIST dwType value to a string
            /// describing the device type.
            /// </summary>
            /// <param name="device">A dwType value (RIM_TYPEMOUSE, 
            /// RIM_TYPEKEYBOARD or RIM_TYPEHID).</param>
            /// <returns>A string representation of the input value.</returns>
            private string GetDeviceType(int device)
            {
                string deviceType;
                switch (device)
                {
                    case RIM_TYPEMOUSE: deviceType = "MOUSE"; break;
                    case RIM_TYPEKEYBOARD: deviceType = "KEYBOARD"; break;
                    case RIM_TYPEHID: deviceType = "HID"; break;
                    default: deviceType = "UNKNOWN"; break;
                }
                return deviceType;
            }

            #endregion GetDeviceType( int device )

        }
    }
}
