using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public MyGridLocalizer()
        {

        }

        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {

            System.Diagnostics.Debug.WriteLine(id.ToString());

            switch (id)
            {

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit:
                    
                    return acInfo.Resource.GetString("컬럼 자동크기", "KT5H6DIK"); 
                    
                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns:

                    return acInfo.Resource.GetString("전체 컬럼 자동크기", "AYN0WR6I");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnClearFilter:

                    return acInfo.Resource.GetString("필터 제거", "OR78SULC"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnClearSorting:

                    return acInfo.Resource.GetString("정렬 제거", "JREZUKKA"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization:

                    return  acInfo.Resource.GetString("컬럼 선택","1UJU8VI6");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilter:

                    break;

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilterEditor:

                    return acInfo.Resource.GetString("필터 수정", "KOXYC8NC");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup:

                    return acInfo.Resource.GetString("컬럼 그룹화", "0L5PDBPT");

                //case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox:
                case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelShow:

                    return acInfo.Resource.GetString("컬럼 그룹 상자 보기", "E3EFGKDQ");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelHide:

                    return acInfo.Resource.GetString("컬럼 그룹 상자 숨기기", "9MP1PL18");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn:

                    return acInfo.Resource.GetString("컬럼 제거", "JZXSNF3B");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterShow:

                    return acInfo.Resource.GetString("컬럼 검색 필터 보기", "1UGHD12R");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFindFilterHide:

                    return acInfo.Resource.GetString("컬럼 검색 필터 숨기기", "ZZ72HALT");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowShow:

                    return acInfo.Resource.GetString("컬럼 자동 필터 열 보기", "73CZG2TW");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnAutoFilterRowHide:

                    return acInfo.Resource.GetString("컬럼 자동 필터 열 숨기기", "IBGV1GCO");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortAscending:

                    return acInfo.Resource.GetString("오름차순 정렬", "X2O74WTT"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnSortDescending:

                    return acInfo.Resource.GetString("내림차순 정렬", "PYFRPVPV"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnUnGroup:

                    return acInfo.Resource.GetString("컬럼 그룹화 취소", "D29OF672"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterAverage:

                    return acInfo.Resource.GetString("평균", "W5PTPQZV"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterCount:

                    return acInfo.Resource.GetString("총수", "5ME2E6DB");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMax:

                    return acInfo.Resource.GetString("최대값", "RTLH6LVK");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMin:

                    return acInfo.Resource.GetString("최소값", "NI5ZIKEN"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterNone:

                    return acInfo.Resource.GetString("없음", "S0AZSYJS"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterSum:

                    return acInfo.Resource.GetString("합계", "FBOA9W3E");

                case DevExpress.XtraGrid.Localization.GridStringId.PopupFilterAll:

                    return acInfo.Resource.GetString("모두 표시", "67AO2QEW");

                case DevExpress.XtraGrid.Localization.GridStringId.PopupFilterBlanks:

                    return acInfo.Resource.GetString("백지화", "4LU20GQJ");

                case DevExpress.XtraGrid.Localization.GridStringId.PopupFilterCustom:

                    return acInfo.Resource.GetString("사용자 정의", "G3LPGK4L");

                case DevExpress.XtraGrid.Localization.GridStringId.PopupFilterNonBlanks:

                    return acInfo.Resource.GetString("백지화 취소", "RVC1ESVX");

                case DevExpress.XtraGrid.Localization.GridStringId.FilterBuilderApplyButton:

                    return acInfo.Resource.GetString("필터 적용", "823N1Z6X"); 

                case DevExpress.XtraGrid.Localization.GridStringId.FilterBuilderCancelButton:

                    return acInfo.Resource.GetString("취소", "FRR80RHR");

                case DevExpress.XtraGrid.Localization.GridStringId.FilterBuilderOkButton:

                    return acInfo.Resource.GetString("확인", "KD40ZNWK");

                case DevExpress.XtraGrid.Localization.GridStringId.FilterPanelCustomizeButton:

                    return acInfo.Resource.GetString("필터 만들기", "081J8BSE"); 

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialog2FieldCheck:

                    break;

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogCancelButton:

                    return acInfo.Resource.GetString("취소", "FRR80RHR");

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogCaption:

                    return acInfo.Resource.GetString("사용자 정의 필터", "IY0BVV9O");

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogClearFilter:

                    return acInfo.Resource.GetString("사용자 정의 필터 제거", "CNQ2F3MG"); 
                //신재경 20150325 수정
                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionBlanks:

                //    return acInfo.Resource.GetString("NULL 이면", "Y6YPZAQ5"); 

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionEQU:

                //    return acInfo.Resource.GetString("동일하면", "NMAD8YSS");

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionGT:

                //    return acInfo.Resource.GetString("크면", "2UUUPG66");

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionGTE:

                //    return acInfo.Resource.GetString("크거나 같으면", "JP14M0BT"); 

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionLike:

                //    return acInfo.Resource.GetString("비슷하면", "7DFJDXRK");

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionLT:

                //    return acInfo.Resource.GetString("작으면", "16ARF6PV"); 

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionLTE:

                //    return acInfo.Resource.GetString("작거나 같으면", "NECM2XUE"); 

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionNEQ:

                //    return acInfo.Resource.GetString("동일하지않으면", "CGCCNH86"); 

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionNonBlanks:

                //    return acInfo.Resource.GetString("NULL이 아니면", "SWK5RHM7");

                //case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogConditionNotLike:

                    //return acInfo.Resource.GetString("비슷하지않으면", "8IWOLNPA"); 

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogFormCaption:

                    return acInfo.Resource.GetString("사용자 정의 필터", "IY0BVV9O");

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogOkButton:

                    return acInfo.Resource.GetString("확인", "KD40ZNWK");

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogRadioAnd:

                    return acInfo.Resource.GetString("그리고", "YIFYI9IP"); 

                case DevExpress.XtraGrid.Localization.GridStringId.CustomFilterDialogRadioOr:

                    return acInfo.Resource.GetString("또는", "18O2HSE7"); 

                case DevExpress.XtraGrid.Localization.GridStringId.FilterBuilderCaption:

                    return acInfo.Resource.GetString("필터 만들기", "081J8BSE");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilterMode:

                    return "필터모드";

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilterModeValue:

                    return "값";

                case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnFilterModeDisplayText:

                    return "표시";

                case DevExpress.XtraGrid.Localization.GridStringId.GridNewRowText:

                    return acInfo.Resource.GetString("여기에다가 행을 추가하세요.", "7A0236L6");

                case DevExpress.XtraGrid.Localization.GridStringId.GridGroupPanelText:

                    return acInfo.Resource.GetString("여기에다가 그룹으로 지정할 컬럼을 넣으세요.", "RD4N3D9Z"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullExpand:

                    return acInfo.Resource.GetString("그룹 펼치기", "53RIUWL3"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelFullCollapse:

                    return acInfo.Resource.GetString("그룹 접기", "RFQQZNY3"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuGroupPanelClearGrouping:

                    return acInfo.Resource.GetString("그룹 삭제", "ZBSRMLOA");


                case DevExpress.XtraGrid.Localization.GridStringId.CustomizationCaption:

                    return acInfo.Resource.GetString("컬럼 선택", "1UJU8VI6");


                case DevExpress.XtraGrid.Localization.GridStringId.CustomizationFormColumnHint:

                    return string.Empty;


                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterAverageFormat:

                    return acInfo.Resource.GetString("평균={0:N1}", "L33F2R81");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterCountFormat:

                    return acInfo.Resource.GetString("갯수={0:N1}", "UNQ088UY"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterCountGroupFormat:

                    return acInfo.Resource.GetString("그룹 갯수={0:N1}", "IXRHD3LV"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMaxFormat:

                    return acInfo.Resource.GetString("최대값={0:N1}", "1M4W1S9L"); 

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterMinFormat:

                    return acInfo.Resource.GetString("최소값={0:N1}", "BL5V7SP6");

                case DevExpress.XtraGrid.Localization.GridStringId.MenuFooterSumFormat:

                    return acInfo.Resource.GetString("합계={0:N1}", "0MF3I75D");

                case DevExpress.XtraGrid.Localization.GridStringId.CheckboxSelectorColumnCaption:

                    return acInfo.Resource.GetString("선택", "40290");
            }

            return base.GetLocalizedString(id);
        }

    }
}
