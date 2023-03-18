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

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace PLN
{
    public sealed partial class PLN13A_M0A : BaseMenu
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

        public PLN13A_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            acGridView2.MouseDown += AcGridView2_MouseDown;


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, focusRow["FILE_TYPE"].ToString());
                }

            }
        }

        public override void MenuInit()
        {
            try
            {

                acGridView1.GridType = acGridView.emGridType.AUTO_COL;

                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.Columns["PART_NAME"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;


                acGridView2.GridType = acGridView.emGridType.SEARCH;

                acGridView2.OptionsView.ShowIndicator = true;

                acGridView2.AddTextEdit("PART_REV_ID", "Rev", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_DIVISION", "Division", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_FILE_PATH", "파일경로", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_FILE_NAME", "파일명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_DRIVER", "Driver", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("FILE_TYPE", "Type", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.OptionsView.ColumnAutoWidth = true;

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

            //    layout.GetEditor("DATE").Value = "ORD_DATE";
            //    layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
            //    layout.GetEditor("E_DATE").Value = DateTime.Now;
            //}            

            //(acLayoutControl1.GetEditor("WEEK_YEAR").Editor as acDateEdit).EditValue = DateTime.Today;

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //    case "DATE":

            //        //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

            //        if (newValue.EqualsEx(string.Empty))
            //        {


            //            layout.GetEditor("S_DATE").isRequired = false;
            //            layout.GetEditor("E_DATE").isRequired = false;

            //        }
            //        else
            //        {

            //            layout.GetEditor("S_DATE").isRequired = true;
            //            layout.GetEditor("E_DATE").isRequired = true;
            //        }

            //        break;

            //}
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
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PART_LIKE", typeof(String));
            paramTable.Columns.Add("MAT_LTYPE_IN", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            //paramRow["MAT_LTYPE_IN"] = "0"; // 가공품

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "PLN13A_SER", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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



        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetDetail();

            acGridView1.EndEditor();

            try
            {
                if (acGridView1.ValidFocusRowHandle() == true)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    this.acAttachFileControl1.LinkKey = focusRow["PART_CODE"];
                    this.acAttachFileControl1.ShowKey = new object[] { focusRow["PART_CODE"] };

                }
                else
                {
                    this.acAttachFileControl1.LinkKey = null;
                    this.acAttachFileControl1.ShowKey = null;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        public void GetDetail()
        {
            //도면내역 조회
            DataRow focus = acGridView1.GetFocusedDataRow();

            if (focus != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PART_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_NO"] = focus["PART_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "PLN13A_SER2", paramSet, "RQSTDT", "RSLTDT",
                 QuickDetail,
                 QuickException);
            }
            else
            {
                acGridView2.ClearRow();
                return;
            }

        }


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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
        
    }
}
