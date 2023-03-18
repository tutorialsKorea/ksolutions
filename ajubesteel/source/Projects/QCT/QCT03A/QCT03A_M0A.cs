using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;

namespace QCT
{
    public partial class QCT03A_M0A : BaseMenu
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

        public QCT03A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;
        }

        public override void MenuInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;
            acGridView1.AddTextEdit("EVAL_NO", "평가번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("EVAL_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q009");
            acGridView1.AddTextEdit("EVAL_TITLE", "제목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_CODE", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("REG_EMP", "등록자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "등록자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "수정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "수정자 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "수정자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "EVAL_NO" };

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            cboDate.AddItem("등록일", false, "", "REG_DATE", true, false);

            base.MenuInit();

        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                acAttachFileControl1.LinkKey = focusRow["EVAL_NO"];
                acAttachFileControl1.ShowKey = new object[] { focusRow["EVAL_NO"] };
            }
            else
            {
                acAttachFileControl1.LinkKey = null;
                acAttachFileControl1.ShowKey = null;
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }


            base.ChildContainerInit(sender);
        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];

            foreach (string key in cboDate.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT03A_SER", paramSet, "RQSTDT", "RSLTDT",
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
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    QCT03A_D0A frm = new QCT03A_D0A(acGridView1, null);

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

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //열기
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["EVAL_NO"]))
                {

                    QCT03A_D0A frm = new QCT03A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["EVAL_NO"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["EVAL_NO"]);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");
                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EVAL_NO", typeof(String)); //

                if (selectedRows.Length == 0)
                {
                    //단일 삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EVAL_NO"] = focusRow["EVAL_NO"];

                    paramTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중 삭제 

                    //다중삭제
                    for (int i = 0; i < selectedRows.Length; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["EVAL_NO"] = selectedRows[i]["EVAL_NO"];

                        paramTable.Rows.Add(paramRow);
                    }

                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "QCT03A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }

                acGridView1.RaiseFocusedRowChanged();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}
