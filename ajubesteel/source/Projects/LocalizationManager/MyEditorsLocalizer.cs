using System;
using System.Collections.Generic;
using System.Text;
using ControlManager;

namespace LocalizationManager
{
    public class MyEditorsLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {

        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id)
        {
            switch (id)
            {
                case DevExpress.XtraEditors.Controls.StringId.Apply:

                    return  acInfo.Resource.GetString("적용","H80OCOQV");


                case DevExpress.XtraEditors.Controls.StringId.DateEditToday:

                    return acInfo.Resource.GetString("오늘", "B45KG5KH");

                case DevExpress.XtraEditors.Controls.StringId.DateEditClear:

                    return acInfo.Resource.GetString("초기화", "8NE7AZU0");

                case DevExpress.XtraEditors.Controls.StringId.OK:

                    return acInfo.Resource.GetString("확인", "KD40ZNWK"); 

                case DevExpress.XtraEditors.Controls.StringId.Cancel:

                    return acInfo.Resource.GetString("취소", "FRR80RHR");

                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuCopy:

                    return acInfo.Resource.GetString("복사", "T2FWJ94V");

                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuCut:

                    return acInfo.Resource.GetString("잘라내기", "ZNU5L4DG");

                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuDelete:

                    return acInfo.Resource.GetString("삭제", "Y1JCF012"); 

                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuPaste:

                    return acInfo.Resource.GetString("붙여넣기", "AX9R0IV1"); 


                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuSelectAll:

                    return acInfo.Resource.GetString("모두 선택", "DPYZGFVF");

                case DevExpress.XtraEditors.Controls.StringId.TextEditMenuUndo:

                    return acInfo.Resource.GetString("되돌리기", "QGFXABNK"); 
                
                case DevExpress.XtraEditors.Controls.StringId.FilterShowAll:

                    return acInfo.Resource.GetString("모두 선택", "DPYZGFVF");


                case DevExpress.XtraEditors.Controls.StringId.FilterMenuClearAll:

                    return acInfo.Resource.GetString("모두 삭제", "7QKM0OGJ"); 
                
                case DevExpress.XtraEditors.Controls.StringId.FilterClauseAnyOf:

                    return acInfo.Resource.GetString("안에 들면", "BLW0QENL"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseBeginsWith:

                    return acInfo.Resource.GetString("시작이 비슷하면", "0GKPXP3Q");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseBetween:

                    return acInfo.Resource.GetString("사이에 들면", "S5MNYDC9"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseBetweenAnd:

                    return acInfo.Resource.GetString("에서", "OKGNCH2T");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseContains:

                    return acInfo.Resource.GetString("속하면", "60ML4KPG"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseDoesNotContain:

                    return acInfo.Resource.GetString("속하지 않으면", "NC8BB9FE");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseDoesNotEqual:

                    return acInfo.Resource.GetString("동일하지않으면", "CGCCNH86"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseEndsWith:

                    return acInfo.Resource.GetString("끝이 비슷하면", "228S1EDM"); ;

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseEquals:

                    return acInfo.Resource.GetString("동일하면", "NMAD8YSS");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseGreater:

                    return acInfo.Resource.GetString("크면", "2UUUPG66"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseGreaterOrEqual:

                    return acInfo.Resource.GetString("크거나 같으면", "JP14M0BT");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseIsNotNull:

                    return acInfo.Resource.GetString("NULL 이 아니면", "SWK5RHM7"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseIsNull:

                    return acInfo.Resource.GetString("NULL 이면", "Y6YPZAQ5");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseLess:

                    return acInfo.Resource.GetString("작으면", "16ARF6PV"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseLessOrEqual:

                    return acInfo.Resource.GetString("작거나 같으면", "NECM2XUE");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseLike:

                    return acInfo.Resource.GetString("비슷하면", "7DFJDXRK"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseNoneOf:

                    return acInfo.Resource.GetString("안에 들지않으면", "1TJPK0WZ"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseNotBetween:

                    return acInfo.Resource.GetString("사이에 들지않으면", "7NOGYZJ0");

                case DevExpress.XtraEditors.Controls.StringId.FilterClauseNotLike:

                    return acInfo.Resource.GetString("비슷하지않으면", "8IWOLNPA");

                case DevExpress.XtraEditors.Controls.StringId.FilterGroupAnd:

                    break;

                case DevExpress.XtraEditors.Controls.StringId.FilterGroupNotAnd:

                    break;

                case DevExpress.XtraEditors.Controls.StringId.FilterGroupNotOr:

                    break;

                case DevExpress.XtraEditors.Controls.StringId.FilterGroupOr:

                    break;

                case DevExpress.XtraEditors.Controls.StringId.FilterMenuConditionAdd:

                    return acInfo.Resource.GetString("조건추가", "AEL68Z63"); 

                
                case DevExpress.XtraEditors.Controls.StringId.FilterMenuGroupAdd:

                    return acInfo.Resource.GetString("그룹추가", "VQWKT6GU"); 

                case DevExpress.XtraEditors.Controls.StringId.FilterMenuRowRemove:

                    break;

                case DevExpress.XtraEditors.Controls.StringId.ColorTabCustom:

                    return acInfo.Resource.GetString("사용자 정의", "G3LPGK4L");

                case DevExpress.XtraEditors.Controls.StringId.ColorTabSystem:

                    return acInfo.Resource.GetString("시스템", "UO57ITXM");

                case DevExpress.XtraEditors.Controls.StringId.ColorTabWeb:

                    return acInfo.Resource.GetString("웹", "EWS4E0AT");

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuLoad:

                    return acInfo.Resource.GetString("불러오기", "VO8OYFRA");

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuCopy:

                    return acInfo.Resource.GetString("복사", "T2FWJ94V"); 

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuCut:

                    return acInfo.Resource.GetString("잘라내기", "ZNU5L4DG"); 

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuDelete:

                    return acInfo.Resource.GetString("삭제", "Y1JCF012"); 

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuPaste:

                    return acInfo.Resource.GetString("붙여넣기", "AX9R0IV1");

                case DevExpress.XtraEditors.Controls.StringId.PictureEditMenuSave:

                    return acInfo.Resource.GetString("저장", "7NKYXFU5"); 

                case DevExpress.XtraEditors.Controls.StringId.PictureEditOpenFileTitle:

                    return acInfo.Resource.GetString("열기", "5E5CQSN3"); 

        
                case DevExpress.XtraEditors.Controls.StringId.CheckChecked:

                    return acInfo.Resource.GetString("체크됨", "NHZ9NZ6U"); 

                case DevExpress.XtraEditors.Controls.StringId.CheckUnchecked:

                    return acInfo.Resource.GetString("체크안됨", "AGC7PFKU");


                case DevExpress.XtraEditors.Controls.StringId.DataEmpty:

                    return acInfo.Resource.GetString("이미지 없음", "OCK8T3RR"); 
                    
                case DevExpress.XtraEditors.Controls.StringId.TabHeaderButtonClose:

                    return acInfo.Resource.GetString("닫기", "VIIH5XSV"); 

                case DevExpress.XtraEditors.Controls.StringId.TabHeaderButtonNext:

                    return acInfo.Resource.GetString("오른쪽으로", "XI7E48FM");

                case DevExpress.XtraEditors.Controls.StringId.TabHeaderButtonPrev:

                    return acInfo.Resource.GetString("왼쪽으로", "P42SMNXV");

 
            }


            return base.GetLocalizedString(id);
        }
    }
}
