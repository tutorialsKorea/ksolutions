using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using BizManager;

namespace SYS
{
    public sealed partial class SYS10A_M0A : BaseMenu
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



        public SYS10A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                switch (e.MenuType)
                {
                    case GridMenuType.Row:

                      
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;

                    case GridMenuType.User:


     
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        break;
                }



                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }

        }


        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("SR_CODE", "시리얼번호코드", "VB55C0G7", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("SR_NAME", "시리얼번호명", "LOJ4XRIB", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "SR_CODE" };





            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

          

            base.MenuInit();
        }




        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            paramTable.Columns.Add("SR_LIKE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["SR_LIKE"] = layoutRow["SR_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS10A_SER", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("DEFAULT", e.result);

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);


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




        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("SR_CODE", typeof(String)); //


                if (selected.Count == 0)
                {
                    //단일 삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["SR_CODE"] = focusRow["SR_CODE"];

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["SR_CODE"] = selected[i]["SR_CODE"];
                        paramTable.Rows.Add(paramRow);
                    }
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS10A_DEL", paramSet, "RQSTDT", "",
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
                //링크된 자식창 삭제
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


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //새로만들기 오류 편집기
                if (!base.ChildFormContains("NEW"))
                {
                    SYS10A_D0A frm = new SYS10A_D0A(acGridView1, null);

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
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void DataRefresh(object data)
        {
            if (data.EqualsEx("DEFAULT"))
            {
                if (base.IsData(data))
                {
                    DataSet refreshSet = base.GetData(data) as DataSet;

                    refreshSet.Tables.Remove("RSLTDT");

                    BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.REFRESH,
                 "SYS10A_SER", refreshSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);

                }

            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView1.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("SR_CODE", typeof(String)); //
                paramTable.Columns.Add("SR_NAME", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부


                DataTable data = acGridControl1.GetAddModifyRows();


                foreach (DataRow row in data.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["SR_CODE"] = row["SR_CODE"];
                    paramRow["SR_NAME"] = row["SR_NAME"];
                    paramRow["OVERWRITE"] = "1";
                    paramTable.Rows.Add(paramRow);

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                if (paramTable.Rows.Count != 0)
                {

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "SYS10A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.MenuStatus = emMenuStatus.NONE;

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {

                    acGridView1.AcceptChanges();


                    //저장 메뉴로그 
                    base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



    }
}
