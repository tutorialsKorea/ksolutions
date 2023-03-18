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
    public partial class ChangeMC2 : BaseMenuDialog
    {

        private string _strEmpCode = "";


        public ChangeMC2(string empCode)
        {
            InitializeComponent();

            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 10, 
                        FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            gv.RowHeight = 40;

            gv.GridType = acGridView.emGridType.LIST_USERCONFIG2;

            gv.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            gv.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            POP04A_M0A.SetPopGridFont(gv, null, null);


            _strEmpCode = empCode;


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = _strEmpCode;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "MAINFORM_GET_PANEL2", paramSet, "RQSTDT", "RSLTDT");

           // DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD04A_SER", paramSet, "RQSTDT", "RSLTDT");

            this.gv.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            this.gv.Focus();


            #region 이벤트 설정

            gv.MouseDown += new MouseEventHandler(gv_MouseDown);
           
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MC_LIKE", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


           BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "STD04A_SER", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);

            // BizRun.QBizRun.ExecuteService(this,
            //ControlManager.QBiz.emExecuteType.LOAD, "CONTROL_EMP_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            //QuickSearch,
            //QuickException);

        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                // this._EmpSet = e.result;

                this.gv.GridControl.DataSource = e.result.Tables["RSLTDT"];

             
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
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

