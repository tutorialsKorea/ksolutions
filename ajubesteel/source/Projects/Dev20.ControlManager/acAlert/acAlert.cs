using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlManager
{
    public static  class acAlert
    { 
        public static void Show(Control parentControl,string msg, acAlertForm.enmType type)
        {
            acAlertForm frm = new acAlertForm();
            frm.showAlert(parentControl,msg, type);
        }
    }
}
