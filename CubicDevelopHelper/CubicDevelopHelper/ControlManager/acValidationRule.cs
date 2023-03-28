using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ControlManager
{

    public class acLayoutControlValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {

            IBaseEditControl viewEdit = (IBaseEditControl)control;

            if (acChecker.isNull(viewEdit.Value) == false)
            {
                if (acChecker.isNull(control.Text) == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }


        }
    }

    public class acGridViewValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            BaseEdit edit = control as BaseEdit;

            if (acChecker.isNull(edit.EditValue) == false)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
