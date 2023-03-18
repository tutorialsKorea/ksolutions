using System;
using System.Runtime.InteropServices;

namespace AppManager
{

    [Guid("4B5BD6AD-7C13-47a8-82EA-7ABB0CA6272A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEvent
    {

        [DispId(0x60015000)]
        void LogOut();


        [DispId(0x60015001)]
        void Login();

        /// <summary>
        /// 에러가 발생하였습니다.
        /// </summary>
        [DispId(0x60015002)]
        void Error(string errorMessage);
    }
}
