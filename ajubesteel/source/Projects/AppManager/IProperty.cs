using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager
{
    public interface IProperty
    {
        int LCID { get; set; }


        void ShowViewer(string url ,string userAgent ,string desLogin );

    }
}
