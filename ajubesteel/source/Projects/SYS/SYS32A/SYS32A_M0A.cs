using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS32A_M0A : BaseMenu
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

        public SYS32A_M0A()
        {
            InitializeComponent();



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


            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("RES_ID", "ID", "OYL0JR2M", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddMemoEdit("RES_CONTENTS", "내용", "O00RH4SM", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, false, true, false);

            acGridView1.KeyColumn = new string[] { "RES_ID" };



            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            base.MenuInit();


        }



        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["RES_ID"]);
            }
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

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                        break;

                    case GridMenuType.User:

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                        break;
                }



                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }



        public override bool MenuDestory(object sender)
        {

            if (base.MenuStatus == emMenuStatus.WORK)
            {

                if (acMessageBox.Show(this, "수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?", "AEIR4MG6", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {

                    base.MenuDestory(sender);

                    return true;
                }
                else
                {
                    return false;
                }

            }


            base.MenuDestory(sender);

            return true;
        }

        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }


        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName != "SEL")
            {
                base.MenuStatus = emMenuStatus.WORK;
            }
        }


        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("RES_ID", typeof(String));
            paramTable.Columns.Add("RES_LANG", typeof(String));
            paramTable.Columns.Add("RES_CONTENTS_LIKE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["RES_ID"] = layoutRow["RES_ID"];
            paramRow["RES_LANG"] = acInfo.Lang;
            paramRow["RES_CONTENTS_LIKE"] = layoutRow["RES_CONTENTS_LIKE"];
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS32A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);

        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //검색
            try
            {
                this.Search();

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



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetData("DEFAULT", e.result);

                base.MenuStatus = emMenuStatus.NONE;

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                //조회 메뉴로그 
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS32A_SER", refreshSet, "RQSTDT", "RSLTDT",
                    QuickSearch,
                    QuickException);


                }

            }

        }
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {
                acGridView1.EndEditor();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RES_ID", typeof(String)); //
                paramTable.Columns.Add("RES_LANG", typeof(String)); //
                paramTable.Columns.Add("RES_CONTENTS", typeof(String)); //


                DataTable data = acGridControl1.GetAddModifyRows();


                foreach (DataRow row in data.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RES_ID"] = row["RES_ID"];
                    paramRow["RES_LANG"] = acInfo.Lang;
                    paramRow["RES_CONTENTS"] = row["RES_CONTENTS"];
                    paramTable.Rows.Add(paramRow);

                }

                if (paramTable.Rows.Count != 0)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "SYS32A_INS", paramSet, "RQSTDT", "RSLTDT",
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

            base.MenuStatus = emMenuStatus.NONE;

            if (e.result.Tables["RSLTDT"].Rows.Count != 0)
            {

                //리소스 업데이트

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acInfo.Resource.Update(row["RES_ID"].ToString(), row["RES_CONTENTS"].ToString());
                }

                acGridView1.AcceptChanges();


                //저장 메뉴로그 
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }


        }




        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //추가
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS32A_D0A frm = new SYS32A_D0A(acGridView1, null);

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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {
                
                //정말 삭제하시겠습니까?
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RES_ID", typeof(String)); //
                paramTable.Columns.Add("RES_LANG", typeof(String)); //


                if (selected.Count == 0)
                {
                    //단일 삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RES_ID"] = focusRow["RES_ID"];
                    paramRow["RES_LANG"] = focusRow["RES_LANG"];

                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //다중 삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["RES_ID"] = selected[i]["RES_ID"];
                        paramRow["RES_LANG"] = selected[i]["RES_LANG"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                            "SYS32A_DEL", paramSet, "RQSTDT", "",
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

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //리소스 일괄변경

            try
            {
                SYS32A_D1A frm = new SYS32A_D1A(acGridView1, null);

                frm.Text = e.Item.Caption;

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    this.DataRefresh("DEFAULT");

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Excel에서 데이터 가져오기

            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                SYS32A_D2A frm = new SYS32A_D2A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.DataRefresh("DEFAULT");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //다국어 복사기능
            try
            {
                SYS32A_D3A frm = new SYS32A_D3A();

                frm.Text = e.Item.Caption;

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }




    }
}