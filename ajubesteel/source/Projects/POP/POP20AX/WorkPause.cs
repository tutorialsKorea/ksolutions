using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace POP
{
    public partial class WorkPause : BaseMenuDialog
    {
        public WorkPause()
        {
            InitializeComponent();

            #region �̺�Ʈ ����



            #endregion


        }
       

        private void OK()
        {
                this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ȯ��
            this.OK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //���
            this.DialogResult = DialogResult.Cancel;
        }


    }
}

