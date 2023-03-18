using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acProcForm : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }


        public override void BarCodeScanInput(string barcode)
        {


        }

        public acProc.emMethodType ExecuteMethodType { get; set; }


        public acProcForm()
        {
            InitializeComponent();

            acGridView1.GridType = ControlManager.acGridView.emGridType.LIST;


            acGridView1.AddTextEdit("LPROC_NAME", "대일정", "40134", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MPROC_NAME", "중일정", "40632", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddColorEdit("PROC_COLOR", "색상", "40281", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddCheckEdit("IS_OS", "외주가능", "0PZP4HXS", true, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.Columns["LPROC_NAME"].GroupIndex = 0;
            acGridView1.Columns["LPROC_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


            acGridView1.Columns["MPROC_NAME"].GroupIndex = 1;
            acGridView1.Columns["MPROC_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


            acGridView1.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(acGridView1_CustomDrawGroupRow);

            acGridView1.CustomColumnSort += new CustomColumnSortEventHandler(acGridView1_CustomColumnSort);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            acGridView view = sender as acGridView;

            int val1 = 0;
            int val2 = 0;

            switch (e.Column.FieldName)
            {

                case "LPROC_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "PGL_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "PGL_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }

                    break;

                case "MPROC_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "PGM_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "PGM_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }

                    break;

            }

        }


        void acGridView1_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);

        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                acProc ctrl = (acProc)base.ParentControl;

                if (this.ExecuteMethodType == acProc.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("PROC_LIKE").Value = this.Parameter;

                }


            }

        }

        protected override void OnShown(EventArgs e)
        {



            base.OnShown(e);

            //포커스
            acLayoutControl1.GetEditor("PROC_LIKE").FocusEdit();
            


            if (this.ExecuteMethodType == acProc.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PROC_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acProc.emMethodType.QUICK_FIND)
            {
                this.Search();
            }
        }

        void Search()
        {

            acProc parent = base.ParentControl as acProc;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();



            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("AVAILEMP", typeof(String)); //
            paramTable.Columns.Add("AVAILMC", typeof(String)); //

            paramTable.Columns.Add("LPROC_CODE", typeof(String)); //
            paramTable.Columns.Add("MPROC_CODE", typeof(String)); //

            paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("IS_OS", typeof(Byte)); //
            paramTable.Columns.Add("MCLASS_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("PROC_LIKE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["AVAILEMP"] = parent.AVAILEMP;
            paramRow["AVAILMC"] = parent.AVAILMC;

            paramRow["LPROC_CODE"] = parent.LPROC_CODE;
            paramRow["MPROC_CODE"] = parent.MPROC_CODE;

            if(parent.IS_OS!=-1)
            {
                paramRow["IS_OS"] = parent.IS_OS;
            }


            if (parent.MCLASS_FLAG != -1)
            {
                paramRow["MCLASS_FLAG"] = parent.MCLASS_FLAG;
            }


            paramRow["DATA_FLAG"] = 0;
            paramRow["PROC_LIKE"] = layoutRow["PROC_LIKE"];


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "CTRL",
            "CONTROL_PROC_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);

        }



        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.InRow && hitInfo.InRowCell)
                {

                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];


                acGridView1.SetOldFocusRowHandle(false);


                acGridView1.ExpandAllGroups();



                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}