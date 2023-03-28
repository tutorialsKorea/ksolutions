using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Painters;
using DevExpress.XtraBars.Styles;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using BizManager;
using System.Windows.Forms;
using DevExpress.Utils.Menu;

namespace ControlManager
{

    public class acDocumentManager : DevExpress.XtraBars.Docking2010.DocumentManager
    {
        public static string GetClassName()
        {
            return "acDocumentManager";
        }



        public acDocumentManager(IContainer container)
            : base(container)
        {
            acTabbedView tabbedView = new acTabbedView(container);

            this.View = tabbedView;
            this.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            tabbedView});

        }


        public acDocumentManager()
            : base()
        {

            acTabbedView tabbedView = new acTabbedView();

            this.View = tabbedView;
            this.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            tabbedView});

        }        
    }


    public class acTabbedView : DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    {

        public static string GetClassName()
        {
            return "acTabbedView";
        }

        public acTabbedView(IContainer container) : base(container)
        {
            this.PopupMenuShowing += acTabbedView_PopupMenuShowing;
        }

        public acTabbedView():base()
        {
            this.PopupMenuShowing += acTabbedView_PopupMenuShowing;
        }

        private void acTabbedView_PopupMenuShowing(object sender, DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventArgs e)
        {
            DXMenuItem item = e.Menu.Items[0];
            e.Menu.Items.Remove(item);
            e.Menu.Items.Insert(1, item);
        }
    }

}
