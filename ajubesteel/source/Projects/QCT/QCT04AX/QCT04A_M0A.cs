using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace QCT
{
    public partial class QCT04A_M0A : BaseMenu
    {
        bool _IsMenuLink = false;

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


        public QCT04A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;
            acGridView1.MouseDown += acGridView1_MouseDown;
            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (sender is acGridView view)
                {
                    DataRow cellRow = view.GetDataRow(e.RowHandle);
                    if (cellRow.RowState == DataRowState.Modified)
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                }
            }
            catch
            {

            }
        }

        public override void MenuLink(object data)
        {
            base.MenuLink(data);

            try
            {
                if (data.GetType() == typeof(string[]))
                {
                    _IsMenuLink = true;

                    string[] strData = data as string[];
                    string year = strData.GetValue(0).ToString();
                    string month = strData.GetValue(1).ToString();

                    cboDate.Value = "QCT_DATE";
                    acLayoutControl1.GetEditor("S_DATE").Value = new DateTime(year.toInt(), month.toInt(), 1);
                    acLayoutControl1.GetEditor("E_DATE").Value = new DateTime(year.toInt(), month.toInt(), 1).GetLastDate();
                }
            }
            catch { }
            //cboDate.Value = "QCT_DATE";

            //acLayoutControl1.GetEditor("QCT_CAT").Value = "";
       
        }

        public override void MenuInit()
        {

            acGridView1.AddHidden("NG_ID", typeof(string));

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("QCT_NO", "비용관리번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("QCT_DATE", "발생일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEmp("QCT_EMP", "작성자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddLookUpEdit("QCT_CAT", "품질비용 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M035");
            acGridView1.AddLookUpEdit("QCT_CODE", "품질비용 항목", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M036");
            acGridView1.AddTextEdit("QCT_COST", "비용", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "최초 작성일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEmp("REG_EMP", "최초 작성자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.KeyColumn = new string[] { "QCT_NO" };

            cboDate.AddItem("발생일", false, "", "QCT_DATE", true, false);
            cboDate.AddItem("작성일", false, "", "REG_DATE", true, false);

            //비용 구분
            (acLayoutControl1.GetEditor("QCT_CAT").Editor as acLookupEdit).SetCode("M035");

            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정
            if(_IsMenuLink == false
             && sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "QCT_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            _IsMenuLink = false;

            base.ChildContainerInit(sender);
        }

        private void btnIns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    QCT04A_D0A frm = new QCT04A_D0A(acGridView1, null);
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
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }

                DataRow focusRow = acGridView1.GetFocusedDataRow();


                if (!base.ChildFormContains(focusRow["QCT_NO"]))
                {
                    QCT04A_D0A frm = new QCT04A_D0A(acGridView1, focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    base.ChildFormAdd(focusRow["QCT_NO"], frm);
                    frm.Show(this);

                }
                else
                {
                    base.ChildFormFocus(focusRow["QCT_NO"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    btnIns.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {
                        acLayoutControl1.GetEditor("S_DATE").isRequired = false;
                        acLayoutControl1.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        acLayoutControl1.GetEditor("S_DATE").isRequired = true;
                        acLayoutControl1.GetEditor("E_DATE").isRequired = true;
                    }

                    break;
                
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        public override void DataRefresh(object data)
        {

            if (base.IsData("READ"))
            {
                DataSet refresh = base.GetData("READ") as DataSet;

                refresh.Tables.Remove("RSLTDT");

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER", refresh, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

            }

        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("QCT_CAT", typeof(String)); //
            paramTable.Columns.Add("S_QCT_DATE", typeof(String)); //
            paramTable.Columns.Add("E_QCT_DATE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["QCT_CAT"] = layoutRow["QCT_CAT"];

            foreach (string key in cboDate.GetKeyChecked())
            {
                switch (key)
                {
                    case "QCT_DATE":
                        paramRow["S_QCT_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_QCT_DATE"] = layoutRow["E_DATE"];
                        break;
                    case "REG_DATE":
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT04A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);
                //데이터 갱신
                this.DataRefresh(null);
            }
            else if (ex.ErrNumber == BizManager.BizException.CANNOT_DELETE)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), "불량 삭제", acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();
                acGridView1.SetOldFocusRowHandle(true);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDelete(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                if (acMessageBox.Show("등록된 품질비용 내역을 삭제하시겠습니까?", "품질비용 현황", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("QCT_NO", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["QCT_NO"] = focusRow["QCT_NO"];

                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT04A_DEL", paramSet, "RQSTDT", "RSLTDT",
                        QuickDelete,
                        QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            if (acMessageBox.Show("품질비용을 수정하시겠습니까?", "품질비용 현황", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

            if (acGridView1.GetAddModifyRows() is DataTable mdfyTable
                && mdfyTable.Rows.Count > 0)
            {
                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("QCT_NO", typeof(String));
                dtParam.Columns.Add("QCT_COST", typeof(String));

                foreach (DataRow mdfyRow in mdfyTable.Rows)
                {
                    DataRow drParam = dtParam.NewRow();
                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["QCT_NO"] = mdfyRow["QCT_NO"];
                    drParam["QCT_COST"] = mdfyRow["QCT_COST"];
                    dtParam.Rows.Add(drParam);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT04A_INS2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
            }
            else
            {
                acMessageBox.Show("수정된 항목이 존재하지 않습니다.", "품질비용 현황", acMessageBox.emMessageBoxType.CONFIRM);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
               if(acGridView1.GridControl.DataSource is DataTable sourceTable)
                {
                    sourceTable.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
