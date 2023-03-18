using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace POP
{
    public partial class ChangeMC3 : BaseMenuDialog
    {

        private string _mcGroup;

        public ChangeMC3(string mcGroup)
        {

            _mcGroup = mcGroup;

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

            gv.AddLookUpEdit("MC_GROUP", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            gv.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            gv.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, ControlManager.acGridView.emTextEditMask.NONE);

            POP04A_M0A.SetPopGridFont(gv, null, null);


            // PC 이름
            // string hostName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Split('\\')[0]; // 단말기 이름(PC명)

            #region 수정전
            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("IP_ADDR", typeof(String)); //

            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["IP_ADDR"] = acNetWork.GetLanIPAddress();

            //paramTable.Rows.Add(paramRow);
            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);

            //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP04A_SER", paramSet, "RQSTDT", "RSLTDT");


            //if(resultSet.Tables["RSLTDT"].Rows.Count > 0)
            //{
            //    this.gv.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            //    this.gv.Focus();
            //}
            //else
            //{
            //    //파일에서 설비코드를 읽어들인다.
            //    string main_mc = System.IO.File.ReadAllText("C:\\CubicTek\\active_POP.ini"); //파일명 미확정

            //    if(main_mc != null)
            //    {

            //        DataTable paramTable2 = new DataTable("RQSTDT_MC");
            //        paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
            //        paramTable2.Columns.Add("MC_CODE", typeof(String)); //

            //        DataRow paramRow2 = paramTable2.NewRow();
            //        paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
            //        paramRow2["MC_CODE"] = main_mc;

            //        paramTable2.Rows.Add(paramRow2);
            //        DataSet paramSet2 = new DataSet();
            //        paramSet2.Tables.Add(paramTable2);

            //        DataSet resultSet2 = BizRun.QBizRun.ExecuteService(this, "POP04A_SER10", paramSet2, "RQSTDT_MC", "RSLTDT");

            //        this.gv.GridControl.DataSource = resultSet2.Tables["RSLTDT"];

            //        this.gv.Focus();

            //    }

            //}
            #endregion


            #region 이벤트 설정

            gv.MouseDown += new MouseEventHandler(gv_MouseDown);
            
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            #endregion

            gv.RowCellStyle += gv_RowCellStyle;

        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (gv.FocusedRowHandle != e.RowHandle)
            {
                DataRowView view = (DataRowView)gv.GetRow(e.RowHandle);

                if (view != null)
                {
                    switch (view.Row["MC_STAT"].ToString())
                    {
                        case "0": // 대기

                            //e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_WAIT").toColor();

                            break;

                        case "1":  //가동
        
                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_RUN").toColor();

                            break;

                        case "2":  //비가동

                            e.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("MC_OPERATE_CLR_IDLE").toColor();

                            // 비가동 상태인 Row인 경우 포커스 고정
                            // if (view["WO_NO"].ToString() == _strIdleWorkNo) { acGridView1.SetFocusCell(e.RowHandle,"WO_FLAG"); }

                            break;
                    }

                }
            }
        }

        public override void DialogInit()
        {
            this.Search();

            base.DialogInit();

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

        void Search() // 입력된 설비코드에 대한 정보를 읽어옴 (엔터)
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MC_LIKE", typeof(String));
            paramTable.Columns.Add("MC_GROUP", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            paramRow["MC_GROUP"] = _mcGroup;
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


           BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "POP04A_SER14", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);

        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

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

