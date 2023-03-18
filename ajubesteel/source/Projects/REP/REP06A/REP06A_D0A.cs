using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace REP
{
    public partial class REP06A_D0A : BaseMenuDialog
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


        public REP06A_D0A()
        {
            InitializeComponent();
        }

        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SOCKET", "Socket", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("PIN_BLOCK", "Pin Block", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("PARTS", "Parts", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("ACTUATOR", "Actuator", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.F2);
            acGridView1.KeyColumn = new string[] { "VEN_CODE" };

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;


            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            base.DialogInit();
        }

        public override void DialogInitComplete()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "REP06A_SER2", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            base.DialogInitComplete();
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell || e.HitInfo.HitTest == GridHitTest.EmptyRow)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
              
            }
        }

        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();

        }

        public override void DialogOpen()
        {

            //열기

            base.DialogOpen();

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                this.Close();

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

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
       
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);

                if (this.DialogMode == emDialogMode.NEW)
                {

                    //클리어


                    //this.barItemClear_ItemClick(null, null);
                }
                else if (this.DialogMode == emDialogMode.OPEN)
                {

                    this.Close();

                    //갱신

                    ((BaseMenu)this.ParentControl).DataRefresh(null);

                }
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기
            if (!base.ChildFormContains("NEW"))
            {

                REP06A_D1A frm = new REP06A_D1A(acGridView1, null);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                base.ChildFormAdd("NEW", frm);

                frm.Show(this);

            }
            else
            {
                base.ChildFormFocus("NEW");
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (!base.ChildFormContains(string.Format("{0}", focusRow["VEN_CODE"])))
            {

                REP06A_D1A frm = new REP06A_D1A(acGridView1, focusRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd(string.Format("{0}", focusRow["VEN_CODE"]), frm);

                frm.Show(this);

            }
            else
            {
                base.ChildFormFocus(string.Format("{0}", focusRow["VEN_CODE"]));
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //


                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CODE"] = focusRow["VEN_CODE"];

                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "REP06A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
