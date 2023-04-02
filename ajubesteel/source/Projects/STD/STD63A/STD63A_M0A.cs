using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;
using DSTD;

namespace STD
{
    public sealed partial class STD63A_M0A : BaseMenu
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

        public STD63A_M0A()
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
            acGridView2.GridType = acGridView.emGridType.AUTO_COL;
            acGridView2.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            
            acGridView2.AddTextEdit("MDR_TCODE", "비가동구분코드", "AB_L0037", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDR_TCODE_NAME", "비가동구분명", "AB_L0038", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDR_RCODE", "비가동원인코드", "AB_L0039", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDR_RCODE_NAME", "비가동원인명", "AB_L0040", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "MDR_TCODE", "MDR_RCODE" };
            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            acGridView2.MouseDown += new MouseEventHandler(acGridView2_MouseDown);
            acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView2_OnMapingRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            base.MenuInit();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Search();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                string formKey = string.Format("{0},{1}", row["MDR_TCODE"], row["MDR_RCODE"]);

                base.ChildFormRemove(formKey);
            }
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem5_ItemClick(null, null);
                }

            }
        }

        void acGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        public override void MenuInitComplete()
        {
   
            base.MenuInitComplete();
        }

        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }

        public override bool MenuDestory(object sender)
        {

            return base.MenuDestory(sender);
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }

        }

        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.Enabled = true;

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.BestFitColumns();
                
                acGridView2.SetOldFocusRowHandle(false);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void Search()
        {
            //검색

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MDR_TCODE", typeof(String));
            //paramTable.Columns.Add("MDR_RCODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MDR_TCODE"] = layoutRow["NAME_LIKE"];
            //paramRow["MDR_RCODE"] = layoutRow["MDR_RCODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD63A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickDetail,
              QuickException);

        }
        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                
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
                if (!base.ChildFormContains("NEW_CAT"))
                {
                    
                }
                else
                {
                    base.ChildFormFocus("NEW_CAT");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
              
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void EditItem()
        {
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                string formKey = string.Format("{0},{1}", focusRow["MDR_TCODE"], focusRow["MDR_RCODE"]);

                if (!base.ChildFormContains(formKey))
                {
                    STD63A_D0A frm = new STD63A_D0A("PIPE", acGridView2, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(formKey);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditItem();
        }

        private void AddItem()
        {
            try
            {
                if (!base.ChildFormContains("NEW_CD"))
                {
                    STD63A_D0A frm = new STD63A_D0A("PIPE", acGridView2, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    base.ChildFormAdd("NEW_CD", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW_CD");

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MDR_TCODE", typeof(String));
                paramTable.Columns.Add("MDR_RCODE", typeof(String));
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                if (selected.Count == 0)
                {

                    //단일삭제
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MDR_TCODE"] = focusRow["MDR_TCODE"];
                    paramRow["MDR_RCODE"] = focusRow["MDR_RCODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    //다중삭제
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MDR_TCODE"] = selected[i]["MDR_TCODE"];
                        paramRow["MDR_RCODE"] = selected[i]["MDR_RCODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "STD63A_DEL", paramSet, "RQSTDT", "",
                QuickDEL2,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView2.DeleteMappingRow(row);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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

        private void barAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void barEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditItem();
        }

    }
}