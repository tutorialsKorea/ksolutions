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
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;

namespace PLN
{
    public sealed partial class PLN06A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public PLN06A_M0A()
        {
            InitializeComponent();
            
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }


        
        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.AUTO_COL;

                acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

                acGridView1.AddTextEdit("STK_ID", "재고ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PART_PRODTYPE", "품목제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROC_NAME", "공정명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("WORK_DATE", "재고등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("OK_QTY", "재고량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddHidden("ACTUAL_ID", typeof(String));
                acGridView1.AddHidden("WO_NO", typeof(String));

                acCheckedComboBoxEdit1.AddItem("생산일", true, "S1WXKDXT", "WORK_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("재고등록일", true, "S1WXKDXT", "STOCK_DATE", true, false);

                acGridView1.KeyColumn = new string[] { "ACTUAL_ID" };

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "STOCK_DATE";
                layout.GetEditor("START_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("END_DATE").Value = DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search(); 
            }
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("W_START_DATE", typeof(String)); //
            paramTable.Columns.Add("W_END_DATE", typeof(String)); //            
            paramTable.Columns.Add("S_START_DATE", typeof(String)); //
            paramTable.Columns.Add("S_END_DATE", typeof(String)); //            

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (checkedKey)
                {

                    case "WORK_DATE":
                        paramRow["W_START_DATE"] = layoutRow["START_DATE"].toDateString("yyyyMMdd");
                        paramRow["W_END_DATE"] = layoutRow["END_DATE"].toDateString("yyyyMMdd");

                        break;

                    case "STOCK_DATE":
                        paramRow["S_START_DATE"] = layoutRow["START_DATE"].toDateString("yyyyMMdd");
                        paramRow["S_END_DATE"] = layoutRow["END_DATE"].toDateString("yyyyMMdd");
                        break;
                }
            }
                
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN06A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.BestFitColumns();



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


        public override bool MenuDestory(object sender)
        {            
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }



        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void btnStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acMessageBox.Show("반제품 출하 취소하시겠습니까?", this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            { 

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String));
                paramTable1.Columns.Add("ACTUAL_ID", typeof(String)); 
                paramTable1.Columns.Add("WO_NO", typeof(String));
                paramTable1.Columns.Add("STK_ID", typeof(String)); 

                if (selectedView.Count == 0)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow dr = paramTable1.NewRow();
                    dr["PLT_CODE"] = acInfo.PLT_CODE;
                    dr["ACTUAL_ID"] = focusRow["ACTUAL_ID"];
                    dr["WO_NO"] = focusRow["WO_NO"];
                    dr["STK_ID"] = focusRow["STK_ID"];

                    paramTable1.Rows.Add(dr);
                }
                else
                {
                    int cnt = selectedView.Count;

                    for(int i = 0; i < cnt; i++)
                    {
                        
                        DataRow dr = paramTable1.NewRow();
                        dr["PLT_CODE"] = acInfo.PLT_CODE;
                        dr["ACTUAL_ID"] = selectedView[i].Row["ACTUAL_ID"];
                        dr["WO_NO"] = selectedView[i].Row["WO_NO"];
                        dr["STK_ID"] = selectedView[i].Row["STK_ID"];

                        paramTable1.Rows.Add(dr);
                    }
                }

                DataSet dsRqst = new DataSet();
                dsRqst.Tables.Add(paramTable1);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN06A_INS", dsRqst, "RQSTDT", "",
                    QuickSave,
                    QuickException);

            }
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }
                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        

        
        
    }
}
