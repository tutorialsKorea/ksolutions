using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using BizManager;
using CodeHelperManager;
using ControlManager;

namespace STD
{
    public sealed partial class STD50A_D2A : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        public STD50A_D2A()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("BM_CODE", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PARENT_CODE", "상위 품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PARENT_NAME", "상위 품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            acPart1.EditValueChanged += acPart1_EditValueChanged;
            acPart2.EditValueChanged += acPart2_EditValueChanged;
        }

        void acPart2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                acPart part = sender as acPart;

                if (part.SelectedRow != null)
                {
                    acLayoutControl1.GetEditor("AFT_PART_NAME").Value = part.SelectedRow["PART_CODE"];
                    acLayoutControl1.GetEditor("AFT_DRAW_NO").Value = part.SelectedRow["DRAW_NO"];
                }
                else
                {
                    acLayoutControl1.GetEditor("AFT_PART_NAME").Value = "";
                    acLayoutControl1.GetEditor("AFT_DRAW_NO").Value = "";
                }
               
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acPart1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                acPart part = sender as acPart;
                acLayoutControl1.GetEditor("BEF_PART_NAME").Value = part.SelectedRow["PART_CODE"];
                acLayoutControl1.GetEditor("BEF_DRAW_NO").Value = part.SelectedRow["DRAW_NO"];

            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                switch (info.ColumnName)
                {
                    case "BEF_PART_CODE":
                        Search();
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            
        }

        public override void DialogInit()
        {

            base.DialogInit();
        }

        private void Search()
        {
            try
            {
                if (acLayoutControl1.GetEditor("BEF_PART_CODE").Value == null) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["PART_CODE"] = acLayoutControl1.GetEditor("BEF_PART_CODE").Value;
                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "DES01A_SER3", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                if (acLayoutControl1.ValidCheck() == false) return;

                if (acLayoutControl1.GetEditor("BEF_PART_CODE").Value != null)
                {
                    if (acLayoutControl1.GetEditor("BEF_PART_CODE").Value.ToString() == acLayoutControl1.GetEditor("AFT_PART_CODE").Value.ToString())
                    {
                        acMessageBox.Show("변경 전과 후의 품목이 같습니다.", "품목 일괄변경", acMessageBox.emMessageBoxType.CONFIRM);
                        acPart2.Focus();
                        return;
                    }
                }
                

                if (((DataTable)acGridView1.GridControl.DataSource).Rows.Count == 0)
                {
                    acMessageBox.Show("변경할 리스트가 없습니다.", "품목 일괄변경", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                
                if (acMessageBox.Show("선택한 품목으로 일괄 변경하시겠습니까?", "품목 일괄변경", acMessageBox.emMessageBoxType.YESNO) == System.Windows.Forms.DialogResult.No) return;

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

     

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }


    }
}