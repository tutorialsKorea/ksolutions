using DevExpress.Utils.Drawing;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlManager
{
    //public class acViewInfoRegistrator : DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator
    public class acViewInfoRegistrator : DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator
    {
        public override string ViewName { get { return "acNavView"; } }

        int groupHeight = 0;
        public int GroupHeight
        {
            get { return groupHeight; }
            set { groupHeight = value; }
        }
        public override BaseNavGroupPainter CreateGroupPainter(NavBarControl navBar)
        {
            return new acViewNavBarGroupPainter(navBar);
        }
    }
    public class acViewNavBarGroupPainter : DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneGroupPainter
    {
        public acViewNavBarGroupPainter(NavBarControl navBar) : base(navBar) { }

        public override Rectangle CalcObjectMinBounds(ObjectInfoArgs e)
        {
            Rectangle rect = base.CalcObjectMinBounds(e);
            acViewInfoRegistrator view = NavBar.View as acViewInfoRegistrator;
            rect.Height = view.GroupHeight;
            return rect;
        }
    }
}
