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
using BizManager;

namespace POP
{
    public partial class ChangeEmp_old : BaseMenuDialog
    {


        public ChangeEmp_old()
        {
            InitializeComponent();

            Control[] con =  POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).LookAndFeel.UseDefaultLookAndFeel = false;
                    ((ControlManager.acSimpleButton)ctrls[0]).LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                    ((ControlManager.acSimpleButton)ctrls[0]).LookAndFeel.SkinName = "DevExpress Style";
                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            #region 버튼 Color 설정

            btnOk.Appearance.BackColor = Color.DodgerBlue;
            btnOk.Appearance.BackColor2 = Color.DodgerBlue;
            btnOk.Appearance.BorderColor = Color.Black;
            btnOk.Appearance.ForeColor = Color.White;

            btnCancel.Appearance.BackColor = Color.DarkGray;
            btnCancel.Appearance.BackColor2 = Color.DarkGray;
            btnCancel.Appearance.BorderColor = Color.Black;
            btnCancel.Appearance.ForeColor = Color.White;

            btnUp.Appearance.BackColor = Color.DodgerBlue;
            btnUp.Appearance.BackColor2 = Color.DodgerBlue;
            btnUp.Appearance.BorderColor = Color.Black;
            btnUp.Appearance.ForeColor = Color.White;

            btnDown.Appearance.BackColor = Color.DodgerBlue;
            btnDown.Appearance.BackColor2 = Color.DodgerBlue;
            btnDown.Appearance.BorderColor = Color.Black;
            btnDown.Appearance.ForeColor = Color.White;

            #endregion

            gv.GridType = acGridView.emGridType.LIST_USERCONFIG2;

            gv.AddTextEdit("EMP_CODE", "작업자코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            gv.AddTextEdit("EMP_NAME", "작업자명", "40545", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("MC_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAINFORM_GET_EMP", paramSet, "RQSTDT", "RSLTDT");

            gv.GridControl.DataSource = resultSet.Tables["RSLTDT"];


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

        private void OK()
        {
            //if (this.gv.FocusedRowHandle >= 0)
            //{
                this.OutputData = this.gv.GetFocusedDataRow();

                this.DialogResult = DialogResult.OK;

            //}
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
   
            this.gv.FocusedRowHandle = this.gv.FocusedRowHandle - 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
 
            this.gv.FocusedRowHandle = this.gv.FocusedRowHandle + 1;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.Close();
        }



    }
}

