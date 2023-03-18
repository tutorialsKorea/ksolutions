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
using System.Collections;

namespace PLN
{
    public sealed partial class PLN07A_M0A : BaseMenu
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

        public PLN07A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);            
        }               
        

        //private DataTable _dtProcList = null;

        public override void MenuInit()
        {
            try
            {                
                #region 표준공정 리스트 컬럼 설정

                acGridView3.GridType = acGridView.emGridType.LIST;
                acGridView3.OptionsView.AllowCellMerge = true;

                acGridView3.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpEdit("PART_PRODTYPE", "품목제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE );
                acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PROC_CODE", "공정코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("PROC_NAME", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);                
                acGridView3.AddTextEdit("PLN_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);                
                acGridView3.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView3.AddTextEdit("RATE", "달성율", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.PER100);
       

                acGridView3.Columns["MC_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                acGridView3.Columns["MC_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                //acGridView3.BestFitColumns();
                #endregion

                acWeekDate1.SetType(acWeekDate.DateType.WEEK);
                acWeekDate1.SetWeekOnly();
                
                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        public override void ChildContainerInit(Control sender)
        {

            //if (sender == acLayoutControl1)
            //{

            //    acLayoutControl layout = sender as acLayoutControl;

            //    layout.GetEditor("DATE").Value = "REG_DATE";
            //    layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
            //    layout.GetEditor("E_DATE").Value = DateTime.Now;


            //}

            //acLayoutControl2.SetAllReadOnly();

            //(acLayoutControl1.GetEditor("WEEK_YEAR").Editor as acDateEdit).EditValue = DateTime.Today;

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {

                case "WEEK_YEAR":
                    
                    string strJuCha = ExtensionMethods.GetJuCha(newValue.toDateTime());                                        
                    (acLayoutControl1.GetEditor("WEEK_NO").Editor as acTextEdit).EditValue = strJuCha;

                    DateTime sDate, eDate;
                    ExtensionMethods.GetJuStartEndDate(newValue.toDateTime(), out sDate, out eDate);

                    (acLayoutControl1.GetEditor("PLN_START_DATE").Editor as acDateEdit).EditValue = sDate;
                    (acLayoutControl1.GetEditor("PLN_END_DATE").Editor as acDateEdit).EditValue = eDate;

                    break;
                case "WEEK":
                    break;

            }
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

        
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];

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


        void Search()
        {

            acGridView3.ClearRow();

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WEEK_YEAR", typeof(String)); //
            paramTable.Columns.Add("WEEK_NO", typeof(String)); //
            paramTable.Columns.Add("PLN_START_DATE", typeof(String)); //
            paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["WEEK_YEAR"] = layoutRow["WEEK_YEAR"].toDateString("yyyy");
            //paramRow["WEEK_NO"] =  layoutRow["WEEK_NO"];
            paramRow["PLN_START_DATE"] = acWeekDate1.StartDate.ToString("yyyyMMdd"); //layoutRow["PLN_START_DATE"];
            paramRow["PLN_END_DATE"] = acWeekDate1.EndDate.ToString("yyyyMMdd"); ; //layoutRow["PLN_END_DATE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN07A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);


        }


        
    }

}
