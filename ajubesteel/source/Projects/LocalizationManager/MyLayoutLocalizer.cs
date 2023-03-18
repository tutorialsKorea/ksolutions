using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationManager
{
    public class MyLayoutLocalizer : DevExpress.XtraLayout.Localization.LayoutLocalizer
    {

        public override string GetLocalizedString(DevExpress.XtraLayout.Localization.LayoutStringId id)
        {

            switch (id)
            {

                case DevExpress.XtraLayout.Localization.LayoutStringId.AddTabMenuText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.ControlGroupDefaultText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.CreateEmptySpaceItem:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.CreateTabbedGroupMenuText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.CustomizationFormTitle:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.CustomizationParentName:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.DefaultActionText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.DefaultEmptyText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.DefaultItemText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.EmptyRootGroupText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.EmptySpaceItemDefaultText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.EmptyTabbedGroupText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.FreeSizingMenuItem:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.GroupItemsMenuText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.HiddenItemsNodeText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.HiddenItemsPageTitle:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.HideCustomizationFormMenuText:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.HideItemMenutext:

                    break;

                case DevExpress.XtraLayout.Localization.LayoutStringId.HideTextMenuItem:

                    break;
                
            }
            
            return base.GetLocalizedString(id);

        }
    }
}
