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
using BizManager;

namespace POP
{
    public partial class ViewCheck : BaseMenuDialog
    {
        private DataRow dr = null;

        
        public ViewCheck(DataRow focus)
        {
            InitializeComponent();

            #region 컨트롤설정
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
            #endregion

            dr = focus;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddLookUpProc("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView1.AddLookUpEdit("INS_CODE", "검사항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M011");
            acGridView1.AddLookUpEdit("MEAS_CODE", "측정기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M012");
            acGridView1.AddTextEdit("AVG_VAL", "기준치", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MIN_VAL", "최소값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAX_VAL", "최대값", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            search();

        }

        
        void search()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = dr["WO_NO"];
            paramRow["PROD_CODE"] = dr["PROD_CODE"];
            paramRow["PART_CODE"] = dr["PART_CODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "POP20A_SER17", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {   
                //신규 검사 컬럼 추가
                for (int i = 1; i < dr["PART_QTY"].toInt() + 1; i++)
                {
                    acGridView1.AddTextEdit(i.ToString(), "X" + i.ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F3);
                    
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
        
        private void OK()
        {
                this.DialogResult = DialogResult.OK;
        }
        
     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }
        
    }
}

