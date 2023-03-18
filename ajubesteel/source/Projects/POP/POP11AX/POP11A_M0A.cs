using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraGrid.Views.Layout;
using BizManager;

namespace POP
{
    public sealed partial class POP11A_M0A : BaseMenu
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

        public POP11A_M0A()
        {

            InitializeComponent();

            layoutView1.CustomFieldCaptionImage += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldCaptionImageEventHandler(lvwMain_CustomFieldCaptionImage);

            layoutView1.CustomCardLayout += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomCardLayoutEventHandler(lvwMain_CustomCardLayout);



            //timer1.Tick += new EventHandler(timer1_Tick);
            //timer1.Enabled = true;
            //timer1.Interval = 1000;

        }

        private int _RuningCnt = 0;

        void timer1_Tick(object sender, EventArgs e)
        {
            this._RuningCnt += 1;


            //자동 조회
            if (this._RuningCnt == acInfo.SysConfig.GetSysConfigByMemory("POP_TERMINAL_REFRESH_TIME").toInt())
            {
                this.Search();
            }
        }

        void lvwMain_CustomCardLayout(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomCardLayoutEventArgs e)
        {
            //if (!CustomEventsPageVisible) return;
            //string colNotesFieldName = layoutViewField_colNotes.Name;
            //string colPhotoFieldName = layoutViewField_colPhoto.Name;
            //string groupContactInfoName = "contactInfoGroup";
            //LayoutViewCardDifferences differences = e.CardDifferences;
            //if (contactInfoInFocusedCardOnly)
            //{
            //    differences.AddItemDifference(groupContactInfoName, LayoutItemDifferenceType.ItemVisibility, (layoutView1.FocusedRowHandle == e.RowHandle));
            //}
            //else
            //{
            //    differences.AddItemDifference(groupContactInfoName, LayoutItemDifferenceType.ItemVisibility, true);
            //}
            //differences.AddItemDifference(colNotesFieldName, LayoutItemDifferenceType.ItemVisibility, fieldNotesCustomVisibility);
            //differences.AddItemDifference(colPhotoFieldName, LayoutItemDifferenceType.ItemVisibility, fieldPhotoCustomVisibility);
        }

        void lvwMain_CustomFieldCaptionImage(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldCaptionImageEventArgs e)
        {
            LayoutView view = sender as LayoutView;

            //if (e.Column.FieldName == "CD_NAME")
            //{
            //    if (view.GetRowCellValue(e.RowHandle, "CD_NAME").ToString() == "가동")
            //    {
            //        e.Image = imageList1.Images[2];

            //    }
            //    else if (view.GetRowCellValue(e.RowHandle, "CD_NAME").ToString() == "중단")
            //    {
            //        e.Image = imageList1.Images[1];
            //    }
            //    else if (view.GetRowCellValue(e.RowHandle, "CD_NAME").ToString() == "알람")
            //    {
            //        e.Image = imageList1.Images[3];
            //    }
            //    else
            //    {
            //        e.Image = imageList1.Images[0];
            //    }


            //    e.ImageAlignment = ContentAlignment.MiddleCenter;

            //}
        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public override void MenuInit()
        {
            base.MenuInit();
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();
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



        void Search()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "POP11A_SEL", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);

            //spinEdit1.Value = lvwMain.OptionsMultiRecordMode.MaxCardColumns;
            //spinEdit2.Value = lvwMain.OptionsMultiRecordMode.MaxCardRows;

        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //grdMain.DataSource = e.result.Tables["RSLTDT"];

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



        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //layoutView1.OptionsMultiRecordMode.MaxCardColumns = (int)spinEdit1.Value;

        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //layoutView1.OptionsMultiRecordMode.MaxCardRows = (int)spinEdit2.Value;
        }


    }
}

