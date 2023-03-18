using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace POP
{
    public partial class ChangeTerminal : ControlManager.acForm
    {

        public ChangeTerminal()
        {
            InitializeComponent();

            gv.GridType = acGridView.emGridType.FIXED;

            gv.AddTextEdit("PANEL_NAME", "단말기명", "KSIYSC78", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            gv.AddTextEdit("MC_LIST", "설비목록", "FYFAJYIO", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);


            DataTable dtIn = new DataTable("RQSTDT");
            dtIn.Columns.Add("PLT_CODE");
            dtIn.Columns.Add("DATA_FLAG");

            DataRow drIn = dtIn.NewRow();
            drIn["PLT_CODE"] = acInfo.PLT_CODE;
            drIn["DATA_FLAG"] = "0";
            dtIn.Rows.Add(drIn);

            DataSet dsIn = new DataSet();
            dsIn.Tables.Add(dtIn);


            DataSet dsOut = BizRun.QBizRun.ExecuteService(this, "MAINFORM_GET_PANEL", dsIn, "RQSTDT", "RSLTDT");

            this.gv.GridControl.DataSource = dsOut.Tables["RSLTDT"];

            this.gv.Focus();

            #region 이벤트 설정


            gv.MouseDown += new MouseEventHandler(gv_MouseDown);

            #endregion

        }

        void gv_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Clicks == 2)
            {
                GridView view = sender as GridView;

                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

                if (hitInfo.InRow == true)
                {
                    OK();
                }
            }
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            //this.gv.Focus();
            this.gv.FocusedRowHandle = this.gv.FocusedRowHandle - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //this.gv.Focus();
            this.gv.FocusedRowHandle = this.gv.FocusedRowHandle + 1;
        }


        private void OK()
        {
            if (this.gv.FocusedRowHandle >= 0)
            {
                this.OutputData = gv.GetFocusedDataRow();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //취소

            this.DialogResult = DialogResult.Cancel;
        }

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }
    }
}

