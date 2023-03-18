using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationManager
{
    public class MyDocumentManagerLocalizer : DevExpress.XtraBars.Docking2010.DocumentManagerLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraBars.Docking2010.DocumentManagerStringId id)
        {
            switch(id)
            {
                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandClose:
                    return "닫기";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandFloat:
                    return "분리하기";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandCloseAll:
                    return "모든 탭 닫기";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandCloseAllButThis:
                    return "이 창을 제외하고 모두 닫기";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandNewHorizontalDocumentGroup:
                    return "새 가로 문서 그룹";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandNewVerticalDocumentGroup:
                    return "새 세로 문서 그룹";

                case DevExpress.XtraBars.Docking2010.DocumentManagerStringId.CommandOpenedWindowsDialog:
                    return "탭 관리 창";

                default:
                    return base.GetLocalizedString(id);
            }
            
        }
    }
}
