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

            #region 이벤트 설정



            #endregion


        }
       

        private void OK()
        {
                this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }


    }
}

