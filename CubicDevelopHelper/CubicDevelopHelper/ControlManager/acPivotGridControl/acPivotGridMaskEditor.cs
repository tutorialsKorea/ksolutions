using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{
    public sealed partial class acPivotGridMaskEdit : ControlManager.acForm
    {

        private acPivotGridField _Field = null;

        public acPivotGridField Field
        {
            get { return _Field; }
            set { _Field = value; }
        }


        public acPivotGridMaskEdit(acPivotGridField field)
        {
            InitializeComponent();

            _Field = field;

            #region 컨트롤 설정

            this.Text = field.Caption + " " + "마스크 설정";
            
            acTextEdit1.EditValue = _Field.CellFormat.FormatString;

            #endregion

            #region 이벤트 설정

            acTextEdit1.EditValueChanged += new EventHandler(acTextEdit1_EditValueChanged);

            #endregion
        }

        void acTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            _Field.CellFormat.FormatString = acTextEdit1.EditValue.toStringNull();

            if (_Field.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
            {
                _Field.PivotGrid.RefreshData();
            }
            else
            {
                _Field.PivotGrid.Refresh();
            }

        }




    }
}