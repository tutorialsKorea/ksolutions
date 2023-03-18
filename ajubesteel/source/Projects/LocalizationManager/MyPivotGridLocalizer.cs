using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyPivotGridLocalizer : DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer
    {
        public MyPivotGridLocalizer()
        {


        }

        public override string GetLocalizedString(DevExpress.XtraPivotGrid.Localization.PivotGridStringId id)
        {

            switch (id)
            {
                //신재경 20150325 수정
                //case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.CannotCopyMultipleSelections:
                //case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.:

                //    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.CellError:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.ColumnArea:

                    return  acInfo.Resource.GetString("컬럼","8HEB5JMB");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.ColumnHeadersCustomization:

                    return acInfo.Resource.GetString("여기에다가 컬럼 필드를 놓으세요.", "MGSGO0M8"); 


                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.CustomizationFormAddTo:

                    return acInfo.Resource.GetString("추가", "JBPV296G");


                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.CustomizationFormCaption:

                    return acInfo.Resource.GetString("필드 목록", "482RWHPM");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.CustomizationFormText:

                    return acInfo.Resource.GetString("항목을 드래그하여 놓으세요.", "T8TQU0FB"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.DataArea:

                    return acInfo.Resource.GetString("데이터", "L5V08ZA5"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.DataFieldCaption:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.DataHeadersCustomization:

                    return acInfo.Resource.GetString("여기에다가 데이터 필드를 놓으세요.", "KWC5MV1M"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.EditPrefilter:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterArea:

                    return acInfo.Resource.GetString("필터", "FN66LR5T"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterCancel:

                    return acInfo.Resource.GetString("취소", "FRR80RHR"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterHeadersCustomization:

                    return acInfo.Resource.GetString("여기에다가 필터 필드를 놓으세요.", "KBN2MI7M");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterOk:

                    return acInfo.Resource.GetString("확인", "KD40ZNWK");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterShowAll:

                    return acInfo.Resource.GetString("모두 보이기", "H2V4EHPH"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.FilterShowBlanks:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.GrandTotal:

                    return acInfo.Resource.GetString("총합계", "24KC9XQW"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.OLAPDrillDownFilterException:

                    break;


                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuCollapse:

                    return acInfo.Resource.GetString("접기", "60VP0NXY"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuCollapseAll:

                    return acInfo.Resource.GetString("모두 접기", "1ZBDE8TU"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuExpand:

                    return acInfo.Resource.GetString("펼치기", "4XZGE5BN");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuExpandAll:

                    return acInfo.Resource.GetString("모두 펼치기", "P1NOM5W6");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuFieldOrder:

                    return acInfo.Resource.GetString("순서", "40382");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuHideField:

                    return acInfo.Resource.GetString("숨기기", "DSBP3BKN");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuHideFieldList:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuHidePrefilter:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuMovetoBeginning:

                    return acInfo.Resource.GetString("처음으로 이동", "6OJJNZR8");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuMovetoEnd:


                    return acInfo.Resource.GetString("끝으로 이동", "RHUVUR5C");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuMovetoLeft:

                    return acInfo.Resource.GetString("왼쪽으로 이동", "ZW0ICCN3"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuMovetoRight:

                    return acInfo.Resource.GetString("오른쪽으로 이동", "JUFUGFE1"); 


                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuRefreshData:


                    return acInfo.Resource.GetString("데이터 갱신", "B2FI64YC");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuShowFieldList:

                    return acInfo.Resource.GetString("필드 목록", "482RWHPM");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PopupMenuShowPrefilter:

                    return acInfo.Resource.GetString("필터 만들기", "081J8BSE"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrefilterFormCaption:

                    return acInfo.Resource.GetString("필터 만들기", "081J8BSE"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesigner:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerCategoryDefault:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerCategoryHeaders:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerCategoryLines:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerColumnHeaders:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerDataHeaders:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerFilterHeaders:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerHorizontalLines:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerPageBehavior:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerPageOptions:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerRowHeaders:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerUsePrintAppearance:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.PrintDesignerVerticalLines:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.RowArea:

                    return acInfo.Resource.GetString("로우", "JLQLF63V");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.RowHeadersCustomization:

                    return acInfo.Resource.GetString("여기에다가 로우 필드를 놓으세요.", "U87MQ15N"); 

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TopValueOthersRow:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.Total:

                    return acInfo.Resource.GetString("합계", "FBOA9W3E");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormat:

                    return acInfo.Resource.GetString("합계", "FBOA9W3E");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatAverage:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatCount:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatCustom:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatMax:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatMin:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatStdDev:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatStdDevp:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatSum:

                    return acInfo.Resource.GetString("합계", "FBOA9W3E");

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatVar:

                    break;

                case DevExpress.XtraPivotGrid.Localization.PivotGridStringId.TotalFormatVarp:

                    break;


            }

            return base.GetLocalizedString(id);
        }

    }
}
