using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyTreeListLocalizer : DevExpress.XtraTreeList.Localization.TreeListLocalizer
    {

        public override string GetLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id)
        {

          

            switch (id)
            {
                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnBestFit:


                    return acInfo.Resource.GetString("컬럼 자동크기", "KT5H6DIK");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnBestFitAllColumns:

                    return acInfo.Resource.GetString("전체 컬럼 자동크기","AYN0WR6I");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnSortAscending:

                    return acInfo.Resource.GetString("오름차순 정렬", "X2O74WTT");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnSortDescending:

                    return acInfo.Resource.GetString("내림순 정렬", "PYFRPVPV"); 
                    
                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnColumnCustomization:

                    return acInfo.Resource.GetString("컬럼 선택", "1UJU8VI6");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.ColumnCustomizationText:

                    return acInfo.Resource.GetString("컬럼 선택", "1UJU8VI6");

                
                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnAutoFilterRowShow:

                    return acInfo.Resource.GetString("컬럼 자동 필터 열 보기", "73CZG2TW");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnAutoFilterRowHide:

                    return acInfo.Resource.GetString("컬럼 자동 필터 열 숨기기", "IBGV1GCO");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnFilterEditor:

                    return acInfo.Resource.GetString("필터 수정", "KOXYC8NC");

                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnFindFilterShow:

                    return acInfo.Resource.GetString("찾기 창 보기", "");
                case DevExpress.XtraTreeList.Localization.TreeListStringId.MenuColumnFindFilterHide:

                    return acInfo.Resource.GetString("찾기 창 숨기기", "");
            }


            return base.GetLocalizedString(id);
        }
    }
}
