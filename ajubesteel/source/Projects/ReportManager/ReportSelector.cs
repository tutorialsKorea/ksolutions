using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ReportManager
{
    internal partial class ReportSelector : ControlManager.acForm
    {
        private object _ReportList = null;


        public ReportSelector(object reportList)
        {
            InitializeComponent();

            this._ReportList = reportList;

            #region 이벤트 설정

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            #endregion

        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gridView.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        protected override void OnLoad(EventArgs e)
        {

            acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;
            
 
            acGridView1.AddTextEdit("RPT_NAME", "출력양식명", "E1UPMPS1", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.GridControl.DataSource = this._ReportList;
            
            

            base.OnLoad(e);

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OutputData = acGridView1.GetFocusedDataRow();


                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}