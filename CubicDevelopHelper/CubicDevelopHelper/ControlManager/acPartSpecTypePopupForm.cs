using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace ControlManager
{
    public sealed partial class acPartSpecTypePopupForm : XtraForm
    {
        public object ParentControl = null;

        public object OutputData = null;





        public acPartSpecTypePopupForm()
        {
            InitializeComponent();


            this.acTextEdit1.KeyDown += new KeyEventHandler(acTextEdit1_KeyDown);

       }

        void acTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                this.OutputData = acTextEdit1.Value;

                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        protected override void OnLoad(EventArgs e)
        {


            acPartSpecTypePopupEdit edit = this.ParentControl as acPartSpecTypePopupEdit;

 
            DataRow codeRow = acInfo.StdCodes.GetCodeRow("S062", edit.SpecType);


            if (!codeRow["VALUE"].isNullOrEmpty())
            {

                acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                acTextEdit1.Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                acTextEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;



            }
            else
            {
                acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                acTextEdit1.Properties.Mask.EditMask = null;

                acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                acTextEdit1.Properties.Mask.EditMask = null;

            }

            acTextEdit1.Value = edit.EditValue;

            base.OnLoad(e);
        }




    }
}