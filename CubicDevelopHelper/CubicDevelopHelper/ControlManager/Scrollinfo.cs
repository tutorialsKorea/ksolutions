using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using System.Windows.Forms;
using DevExpress.XtraTreeList;

namespace ControlManager
{
    public class Scrollinfo :ScrollInfo {
        int _Size = 0;
        public Scrollinfo(BaseView view, int Scrollsize) : base(view) { _Size = Scrollsize; }


        public override int VScrollSize
        {
            get { return _Size; }
        }
        
          
        public override int HScrollSize
        {
        get { return _Size; }
        }

        protected override int HScrollHeight
        {
            get { return _Size; }
        }

        protected override VCrkScrollBar CreateVScroll()
        {
            return new MyVCrkScrollBar(this);
        }

        protected override HCrkScrollBar CreateHScroll()
        {
            return new MyHCrkScrollBar(this);
        }

        public class MyVCrkScrollBar : VCrkScrollBar
        {
            public MyVCrkScrollBar(ScrollInfo scrollInfo) : base(scrollInfo) { }

            protected override ScrollBarViewInfo CreateScrollBarViewInfo()
            {
                return new MyScrollBarViewinfo(this);
            }
        }

        public class MyHCrkScrollBar : HCrkScrollBar
        {
            public MyHCrkScrollBar(ScrollInfo scrollInfo) : base(scrollInfo) { }

            protected override ScrollBarViewInfo CreateScrollBarViewInfo()
            {
                return new MyScrollBarViewinfo(this);
            }
        }

        public class MyScrollBarViewinfo : ScrollBarViewInfo
        {
            public MyScrollBarViewinfo(IScrollBar scrollBar) : base(scrollBar) { }

            public override int ButtonWidth
            {
                get { return SystemInformation.VerticalScrollBarArrowHeight; }
            }

           
        }
    }
}
