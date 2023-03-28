using System;
using System.Collections.Generic;
using System.Text;

namespace ControlManager
{
   public class acLabelControl : DevExpress.XtraEditors.LabelControl, IBaseViewControl
    {

       public acLabelControl()
            : base()
        {



        }


       protected override void OnCreateControl()
       {
           if (acInfo.IsRunTime == true)
           {

               if (_UseResourceID == true)
               {
                   this.Text = acInfo.Resource.GetString(this.Text, this._ResourceID);

               }


           }

           base.OnCreateControl();
       }

        #region IBaseViewControl 멤버

       private string _ResourceID = null;

       public string ResourceID
       {
           get
           {
               return _ResourceID;
           }
           set
           {
               _ResourceID = value;
           }
       }

       private bool _UseResourceID = false;

       public bool UseResourceID
       {
           get
           {
               return _UseResourceID;
           }
           set
           {
               _UseResourceID = value;
           }
       }

       private string _ToolTipID = null;

       public string ToolTipID
       {
           get
           {
               return _ToolTipID;
           }
           set
           {
               _ToolTipID = value;
           }
       }

       private bool _UseToolTipID = false;

       public bool UseToolTipID
       {
           get
           {
               return _UseToolTipID;
           }
           set
           {
               _UseToolTipID = value;
           }
       }



        #endregion
    }
}
