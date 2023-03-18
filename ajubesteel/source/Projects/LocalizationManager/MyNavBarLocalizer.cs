using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyNavBarLocalizer : DevExpress.XtraNavBar.NavBarLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraNavBar.NavBarStringId id)
        {

            switch (id)
            {

                case DevExpress.XtraNavBar.NavBarStringId.NavPaneMenuAddRemoveButtons:

                    return acInfo.Resource.GetString("버튼 추가/삭제", "9SOSUYFA");

                case DevExpress.XtraNavBar.NavBarStringId.NavPaneMenuShowFewerButtons:

                    return acInfo.Resource.GetString("아이콘 버튼으로 표시", "5OEEY184");

   
                case DevExpress.XtraNavBar.NavBarStringId.NavPaneMenuShowMoreButtons:

                    return acInfo.Resource.GetString("버튼으로 표시", "L2J1ROHB");
                    
            }
            
            return base.GetLocalizedString(id);
        }
    }
}
