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
    public partial class ChangeMC : BaseMenuDialog
    {
        private string _strEmpCode = "";
        public ChangeMC(string empCode)
        {
            InitializeComponent();

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            gv.RowHeight = 40;

            gv.GridType = acGridView.emGridType.LIST_USERCONFIG2;

            gv.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            gv.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            POP20A_M0A.SetPopGridFont(gv, null);

            // _strEmpCode = empCode; 작업자에게 할당된 설비를 불러오기 위해 사용 
            _strEmpCode = ""; // 테스트용으로 임시 추가 

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = _strEmpCode;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAINFORM_GET_PANEL", paramSet, "RQSTDT", "RSLTDT");

            this.gv.GridControl.DataSource = resultSet.Tables["RSLTDT"];

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
            this.OutputData = this.gv.GetFocusedDataRow();

            this.DialogResult = DialogResult.OK;
        }


        //private void btnUp_Click(object sender, EventArgs e)
        //{
   
        //    this.gv.FocusedRowHandle = this.gv.FocusedRowHandle - 1;
        //}

        //private void btnDown_Click(object sender, EventArgs e)
        //{
 
        //    this.gv.FocusedRowHandle = this.gv.FocusedRowHandle + 1;
        //}


        private void btnOk_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }


    }
}

