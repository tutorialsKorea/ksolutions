using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ControlManager
{
    public interface IBase
    {

        void BarCodeScanInput(string barCode);

        bool IsBarCodeScaning { get; set; }

        void ChildContainerInit(Control sender);




        string Caption { get; }

        bool IsProcessing { get; set; }

        string MenuCode { get; }

       
    }
}
