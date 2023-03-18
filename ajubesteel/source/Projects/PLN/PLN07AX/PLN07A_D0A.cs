using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace PLN
{
    public sealed partial class PLN07A_D0A : BaseMenuDialog
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


        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        public PLN07A_D0A(object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "실적종료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("MC_NAME", "설비", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "작업자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["OK_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QC_QTY", "{0:N2}");
            acGridView1.Columns["NG_QTY"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "NG_QTY", "{0:N2}");
            
            //acGridView1.KeyColumn = new string[] { "PROC_CODE" };

            //this.acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);
            //acGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanged);

            //acGridView1.ShownEditor += new EventHandler(acGridView1_ShownEditor);
            //acGridView1.HiddenEditor += new EventHandler(acGridView1_HiddenEditor);

            #region 주석
            //acGridView1.AddHidden("SPLIT_MC_CODE", typeof(string));

            //acGridView1.AddCustomEdit("MC_CODE", "설비", "40303", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemMachine());

            //(acGridView1.Columns["MC_CODE"].ColumnEdit as RepositoryItemMachine).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(MC_ButtonClick);
            //(acGridView1.Columns["MC_CODE"].ColumnEdit as RepositoryItemMachine).EditValueChanged += new EventHandler(MC_EditValueChanged);

            //acGridView1.AddHidden("SPLIT_EMP_CODE", typeof(string));

            //acGridView1.AddCustomEdit("EMP_CODE", "작업자", "40542", true, DevExpress.Utils.HorzAlignment.Center, true, true, true, new RepositoryItemEmp());

            //(acGridView1.Columns["EMP_CODE"].ColumnEdit as RepositoryItemEmp).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(EMP_ButtonClick);
            //(acGridView1.Columns["EMP_CODE"].ColumnEdit as RepositoryItemEmp).EditValueChanged += new EventHandler(EMP_EditValueChanged);
            #endregion

            //acGridView1.GridControl.DataSource = dtRsltProc;

            //this.acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.acGridView1_CustomDrawCell);

            //acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
           
                       
        }

        #region 그리드 상 편집시 코드 상하관계 설정

        private void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            switch(e.Column.FieldName)
            {
                case "SEL":
                    DataRow row = acGridView1.GetDataRow(e.RowHandle);
                    if (!row["WO_FLAG"].ToString().Equals("0") && !row["WO_FLAG"].ToString().Equals(""))
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "SEL", "1");
                    }
                    else
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "SEL", e.Value);
                    }
                    break;

                case "MC_CODE":
                    acGridView1.SetRowCellValue(e.RowHandle, "EMP_CODE", "");
                    acGridView1.SetRowCellValue(e.RowHandle, "MC_CODE", e.Value);
                    break;                   

            }
            
            //acGridView1_CellValueChanged(sender, e);

        }

        //private void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    acGridView1.cel
        //}

        private DataView clone = null;

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            if ((view.FocusedColumn.FieldName == "MC_CODE" || view.FocusedColumn.FieldName == "EMP_CODE")
                && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {
                string text = view.ActiveEditor.Parent.Name;

                DevExpress.XtraEditors.LookUpEdit edit;

                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;



                DataTable table = edit.Properties.DataSource as DataTable;

                clone = new DataView(table);

                DataRow row = view.GetDataRow(view.FocusedRowHandle);

                if (view.FocusedColumn.FieldName == "MC_CODE")
                {
                    string PROC_CODE = row["PROC_CODE"].ToString();
                    clone.RowFilter = "PROC_CODE = " + "'" + PROC_CODE + "'";
                }
                else if (view.FocusedColumn.FieldName == "EMP_CODE")
                {
                    string[] MC_CODE = row["MC_CODE"].ToString().Split(':');
                    if (MC_CODE.Length != 2)
                    { clone.RowFilter = "MC_CODE = " + "'" + "" + "'"; }
                    else { clone.RowFilter = "MC_CODE = " + "'" + MC_CODE[1] + "'"; }
                    
                }

                edit.Properties.DataSource = clone;
            }

        }

        private void acGridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (clone != null)
            {
                clone.Dispose();
                clone = null;
            }
        }
        #endregion

        #region Repositoryitem....
        //void EMP_EditValueChanged(object sender, EventArgs e)
        //{
        //    acEmp editor = sender as acEmp;

        //    if (editor.IsSelected == true)
        //    {
        //        DataRow editorRow = editor.SelectedRow;

        //        DataRow focusRow = acGridView1.GetFocusedDataRow();

        //        focusRow["SPLIT_EMP_CODE"] = editorRow["EMP_CODE"];
        //    }
        //}


        //void EMP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{

        //    acEmp editor = sender as acEmp;

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();

        //    editor.AVAILMC = focusRow["SPLIT_MC_CODE"];


        //}

        //void MC_EditValueChanged(object sender, EventArgs e)
        //{
        //    acMachine editor = sender as acMachine;

        //    if (editor.IsSelected == true)
        //    {
        //        DataRow editorRow = editor.SelectedRow;

        //        DataRow focusRow = acGridView1.GetFocusedDataRow();

        //        focusRow["SPLIT_MC_CODE"] = editorRow["MC_CODE"];
        //    }


        //}

        //void MC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{

        //    DataRow linkRow = this._LinkData as DataRow;

        //    acMachine editor = sender as acMachine;

        //    editor.PROC_CODE = linkRow["PROC_CODE"];


        //}
        #endregion

        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //초기값 설정
            (acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");
            (acLayoutControl1.GetEditor("WO_FLAG") as acLookupEdit).SetCode("S032");
 

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로 만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

           
            base.DialogNew();


        }

        public override void DialogOpen()
        {
            //열기            

            //barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            this.GetActual();


            base.DialogOpen();

        }


        void GetActual()
        {

            string strWoNo = (string)_LinkData;
            
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //            

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WO_NO"] = strWoNo;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN04A_SER2", paramSet, "RQSTDT", "RSLTDT_M,RSLTDT_D",
                        QuickSearch,
                        QuickException);


        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT_M"].Rows.Count == 0)
                {
                    this.Close();
                }

                acLayoutControl1.DataBind(e.result.Tables["RSLTDT_M"].Rows[0],true);

                foreach (DataRow row in e.result.Tables["RSLTDT_D"].Rows)
                {
                    acGridView1.AddRow(row);
                }

                //acGridView1.BestFitColumns();

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

        

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                //acLayoutControl1.GetEditor("YPGO_DATE").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
        //닫기
        private void barItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}