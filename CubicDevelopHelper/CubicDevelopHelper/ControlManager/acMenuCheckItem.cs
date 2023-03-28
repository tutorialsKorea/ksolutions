using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils.Menu;

namespace ControlManager
{
    public class acDXMenuCheckItem : DXMenuCheckItem
    {


        public object RefObject = null;

        public acDXMenuCheckItem(string caption, bool cheked)
            : base(caption, cheked)
        {

        }

    }


    public class acDXMenuItem : DXMenuItem
    {
        public object RefObject = null;

        public acDXMenuItem(string caption)
            : base(caption)
        {

        }

    }
}
