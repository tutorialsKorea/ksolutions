using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
    public interface IMainControl
    {
        void ReceiveWindowMessage(string msg);

        void MoveLinkMenu(string menuCode, object data);

        void MoveNotifyMenu(string menuCode, object data);

        void CloseMenu(string className);

        void Exit();

    
    }
}
