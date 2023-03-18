using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizationManager
{
    public class MyBarLocalizer : DevExpress.XtraBars.Localization.BarLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraBars.Localization.BarString id)
        {
            return base.GetLocalizedString(id);
        }
    }
}
