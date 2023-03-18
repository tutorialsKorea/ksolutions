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

            #region ��Ʈ�Ѽ���
            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // ��Ʈ�� ��ü ��ȸ
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
            acGridView1.AddLookUpProc("PROC_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView1.AddLookUpEdit("INS_CODE", "�˻��׸�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M011");
            acGridView1.AddLookUpEdit("MEAS_CODE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M012");
            acGridView1.AddTextEdit("AVG_VAL", "����ġ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MIN_VAL", "�ּҰ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAX_VAL", "�ִ밪", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

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
                //�ű� �˻� �÷� �߰�
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
            //���
            this.DialogResult = DialogResult.Cancel;
        }
        
    }
}

