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
using POP;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.IO;

namespace PLN
{
    public sealed partial class PLN22A_M0A : BaseMenu
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

        private DataTable _dtProcList = null;
        Dictionary<string, Color> _SetColor = new Dictionary<string, Color>();
        Dictionary<Color, string> _SetColor2 = new Dictionary<Color, string>();

        bool _prcIsnull = false;

        acGridView _gridView = null;

        public PLN22A_M0A()
        {
            InitializeComponent();

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            _gridView = acGridView1;
        }


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem9.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }

            if (_prcIsnull)
            {
                acBarButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                acBarButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                acBarButtonItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu3.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }

        }


        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;

                acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

                acGridView1.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("MAT_QLTY", "재질", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE); 
                acGridView1.AddTextEdit("PART_PUID", "참조 부품코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_PUID_NAME", "참조 부품명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
                acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "P012");
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
                acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView1.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView1.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView1.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");
                acGridView1.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpEdit("PIN_TYPE", "PIN TYPE", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P011");
                acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView1.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                //acGridView1.AddTextEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddHidden("PT_ID", typeof(string));
                acGridView1.AddHidden("RE_WO_NO", typeof(string));
                acGridView1.AddHidden("RE_WO_KEY", typeof(string));
                acGridView1.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                this._dtProcList = ExtensionMethods.GetProcList(this);

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    acGridView1.AddLookUpEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
                    acGridView1.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
                }

                acGridView1.KeyColumn = new string[] { "PT_ID", "RE_WO_KEY" };

                acGridView1.Columns["SEL"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                acGridView1.OptionsView.AllowCellMerge = true;

                acGridView1.CellMerge += acGridView1_CellMerge;

                acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;


                acGridView2.GridType = acGridView.emGridType.SEARCH;

                acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);

                //acGridView2.AddTextEdit("CHAIN_WO_NO", "묶음 작업지시번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("IS_REWORK", "재작업여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W012");
                acGridView2.AddHidden("CHAIN_WO_NO", typeof(string));
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P028");
                acGridView2.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "P012");
                acGridView2.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PROD_VERSION", "버전", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("PROC_FLAG", "공정명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P005");
                acGridView2.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
                acGridView2.AddLookUpEdit("INS_YN", "성적서", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView2.AddLookUpEdit("SOCKET_YN", "소켓측정", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P007");
                acGridView2.AddCheckedComboBoxEdit("PROD_CATEGORY", "제품유형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P009");
                acGridView2.AddLookUpEdit("ACTUATOR_YN", "Actuator유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S101");
                acGridView2.AddTextEdit("CVND_NAME", "발주처", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddDateEdit("ORD_DATE", "수주일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddDateEdit("DUE_DATE", "출하예정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                //acGridView2.AddDateEdit("DELIVERY_DATE", "납품일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView2.AddCheckedComboBoxEdit("PIN_TYPE", "Contact", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "P011");
                acGridView2.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
                acGridView2.AddTextEdit("PROD_QTY", "수량", "CPW0FS8W", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
                //acGridView2.AddTextEdit("REMARK", "특기사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddHidden("PT_ID", typeof(string));

                acGridView2.AddTextEdit("DRAW_EMP", "조립품 개발자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                foreach (DataRow row in this._dtProcList.Rows)
                {
                    acGridView2.AddLookUpEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
                    acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
                }

                acGridView2.KeyColumn = new string[] { "PT_ID" };

                acGridView2.Columns["SEL"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;


                acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
                acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
                //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

                acTabControl1.SelectedPageChanged += acTabControl1_SelectedPageChanged;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string type = acTabControl1.GetSelectedContainerName();

            switch (type)
            {
                case "PRC":
                    _prcIsnull = false;
                    _gridView = acGridView1;
                    break;

                case "ETC":
                    _prcIsnull = true;
                    _gridView = acGridView2;
                    break;
            }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "SEL") return;

            string cWo = acGridView1.GetRowCellValue(e.RowHandle, "CHAIN_WO_NO").ToString();

            if (_SetColor.ContainsKey(cWo))
            {
                e.Appearance.BackColor = _SetColor[cWo];
            }
        }

        private void acGridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("SEL"))
                {
                    string cWo1 = acGridView1.GetRowCellValue(e.RowHandle1, "CHAIN_WO_NO").ToString();
                    string cWo2 = acGridView1.GetRowCellValue(e.RowHandle2, "CHAIN_WO_NO").ToString();

                    if (cWo1 == cWo2
                        && cWo1 != "" && cWo2 != "")
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                e.Handled = true;
            }
            catch
            {

            }
        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "DUE_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            //(acLayoutControl1.GetEditor("WEEK_YEAR").Editor as acDateEdit).EditValue = DateTime.Today;

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {


                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {

                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }
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

        void Search()
        {
            //조회
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
            paramTable.Columns.Add("CVND_LIKE", typeof(String)); //발주
            paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //발주
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일

            paramTable.Columns.Add("PRC_ISNULL", typeof(String)); //가공공정
            paramTable.Columns.Add("PRC_ISNOTNULL", typeof(String)); //가공공정외

            paramTable.Columns.Add("IS_MILL", typeof(String));

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["CVND_LIKE"] = layoutRow["CVND_LIKE"];
            paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];

            if (_prcIsnull)
            {
                paramRow["PRC_ISNULL"] = "1";
            }
            else
            {
                paramRow["PRC_ISNOTNULL"] = "1";
            }

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }

            bool isCon = true;

            

            paramTable.Rows.Add(paramRow);

            foreach (DataRow row in paramTable.Rows)
            {
                foreach (DataColumn col in paramTable.Columns)
                {
                    if (col.ColumnName == "PRC_ISNULL"
                        || col.ColumnName == "PRC_ISNOTNULL"
                        || col.ColumnName == "PLT_CODE") continue;

                    if (row[col.ColumnName].ToString() != "")
                    {
                        isCon = false;
                    }
                }
            }

            if (isCon)
            {
                paramRow["IS_MILL"] = "1";
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "PLN22A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _gridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    //DataRow[] rows = e.result.Tables["RSLTDT_WO"].Select("PT_ID = '" + row["PT_ID"].ToString() + "'");
                    //if (rows.Length > 0)
                    //{
                    //    foreach (DataRow rw in rows)
                    //    {
                    //        if (!e.result.Tables["RSLTDT"].Columns.Contains(rw["PROC_CODE"].ToString()))
                    //        {
                    //            e.result.Tables["RSLTDT"].Columns.Add(rw["PROC_CODE"].ToString(), typeof(String));
                    //        }

                    //        row[rw["PROC_CODE"].ToString()] = rw["WO_FLAG"];
                    //    }
                    //}

                    if (row["CHAIN_WO_NO"].ToString() == "") continue;

                    Set_Color(row["CHAIN_WO_NO"].ToString());
                }

                _gridView.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ParameterData != null)
            {
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("WO_NO", "작업지시번호", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_CODE", "품목코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PART_NAME", "품목명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_CODE", "공정코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddTextEdit("PROC_NAME", "공정명", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();
            }
            else
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

        //삭제
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //

            DataView selectedView = acGridView1.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["DEL_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = selectedView[i]["WO_NO"];
                    paramRow["DEL_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                  this, QBiz.emExecuteType.DEL,
                  "PLN03A_DEL", paramSet, "RQSTDT", "",
                  QuickDEL,
                  QuickException);
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acGridView1.DeleteMappingRow(row);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        
        //확정
        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));                        
            paramTable.Columns.Add("WO_NO", typeof(String));
            paramTable.Columns.Add("WO_FLAG", typeof(String));
            paramTable.Columns.Add("REG_EMP", typeof(String));            

            //DataView selectedView = acGridView2.GetDataView("SEL = '1'");
            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();


            if (selectedRows.Length == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "1";
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["WO_FLAG"] = "1";
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN03A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);

        }
        //확정 취소
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acGridView1.EndEditor();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("ITEM_CODE", typeof(String));
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("WO_NO", typeof(String));
            paramTable.Columns.Add("WO_FLAG", typeof(String));
            paramTable.Columns.Add("REG_EMP", typeof(String));
            paramTable.Columns.Add("IS_MAT", typeof(int));
            paramTable.Columns.Add("WP_NO", typeof(String));

            DataRow[] selectedRows = acGridView1.GetSelectedDataRows();


            if (selectedRows.Length == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = focusRow["WO_NO"];
                paramRow["WO_FLAG"] = "0";
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WO_NO"] = row["WO_NO"];
                    paramRow["WO_FLAG"] = "0";
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }
            }


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
        }



        //private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    acGridView2.EndEditor();
        //    //주의사항 입력

        //    DataRow focusRow = acGridView2.GetFocusedDataRow();


        //    string formKey = string.Format("{0},{1}", "WO_NO", focusRow["WO_NO"]);

        //    if (!base.ChildFormContains(formKey))
        //    {

        //        PLN03A_D1A frm = new PLN03A_D1A(acGridView2, focusRow);

        //        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

        //        frm.ParentControl = this;

        //        base.ChildFormAdd(formKey, frm);

        //        if (frm.ShowDialog(this) == DialogResult.OK)
        //        {
        //            DataRow output = (DataRow)frm.OutputData;

        //            DataTable paramTable = new DataTable("RQSTDT");
        //            paramTable.Columns.Add("PLT_CODE", typeof(String));
        //            paramTable.Columns.Add("WO_NO", typeof(String));
        //            paramTable.Columns.Add("CAUTION", typeof(String));

        //            DataRow[] selectedRows = acGridView2.GetSelectedDataRows();


        //            if (selectedRows.Length == 0)
        //            {
        //                //DataRow focusRow = acGridView2.GetFocusedDataRow();
        //                DataRow paramRow = paramTable.NewRow();
        //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                paramRow["WO_NO"] = focusRow["WO_NO"];
        //                paramRow["CAUTION"] = output["CAUTION"];
        //                //paramRow["REG_EMP"] = acInfo.UserID;

        //                paramTable.Rows.Add(paramRow);
        //            }
        //            else
        //            {
        //                foreach (DataRow row in selectedRows)
        //                {
        //                    DataRow paramRow = paramTable.NewRow();
        //                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                    paramRow["WO_NO"] = row["WO_NO"];
        //                    paramRow["CAUTION"] = output["CAUTION"];
        //                   // paramRow["REG_EMP"] = acInfo.UserID;

        //                    paramTable.Rows.Add(paramRow);
        //                }
        //            }



        //            DataSet paramSet = new DataSet();
        //            paramSet.Tables.Add(paramTable);

        //            BizRun.QBizRun.ExecuteService(
        //            this, QBiz.emExecuteType.SAVE, "PLN03A_UPD", paramSet, "RQSTDT", "RSLTDT",
        //            QuickSave,
        //            QuickException);
        //        }
        //    }
        //    else
        //    {
        //        base.ChildFormFocus(formKey);

        //    }
        //}

        ////확정/확정취소 이력 보기
        //private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    DataRow focusRow = acGridView2.GetFocusedDataRow();

        //    string formKey = string.Format("{0},{1}", "WO_NO", focusRow["WO_NO"]);

        //    if (!base.ChildFormContains(formKey))
        //    {

        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("WO_NO", typeof(String));

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["WO_NO"] = focusRow["WO_NO"];

        //        paramTable.Rows.Add(paramRow);
        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SER7", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

        //        PLN03A_D2A frm = new PLN03A_D2A(dtResult);

        //        frm.ParentControl = this;

        //        base.ChildFormAdd(formKey, frm);

        //        frm.Show();

        //    }
        //}
        //+
        //private void btnRework_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //재작업지시
        //    try
        //    {

        //        DataRow focusRow = acGridView2.GetFocusedDataRow();

        //        if (focusRow == null) return;
        //        //중지나 완료인 경우만 재작업지시 가능
        //        if (focusRow["WO_FLAG"].ToString() == "3" || focusRow["WO_FLAG"].ToString() == "4")
        //        {
        //            PLN03A_D3A frm = new PLN03A_D3A();

        //            frm.ParentControl = this;

        //            base.ChildFormAdd("WO_NO", frm);

        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                DataRow dr = (DataRow)frm.OutputData;

        //                DataTable paramTable = new DataTable("RQSTDT");
        //                paramTable.Columns.Add("PLT_CODE", typeof(String));
        //                paramTable.Columns.Add("WO_NO", typeof(String));

        //                DataRow paramRow = paramTable.NewRow();
        //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                paramRow["WO_NO"] = focusRow["WO_NO"];

        //                paramTable.Rows.Add(paramRow);                       

        //                DataSet paramSet = new DataSet();
        //                paramSet.Tables.Add(paramTable);

        //                DataTable dtResult = BizRun.QBizRun.ExecuteService(this, "PLN03A_SAVE3", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];
        //                foreach (DataRow row in dtResult.Rows)
        //                {
        //                    acGridView2.UpdateMapingRow(row, true);
        //                }
        //                acMessageBox.Show("재작업 지시 처리되었습니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);
        //            }
        //        }
        //        else
        //        {
        //            acMessageBox.Show("재작업지시는 중지 혹은 완료된 작업만 가능합니다. ", "재작업지시", acMessageBox.emMessageBoxType.CONFIRM);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //private void btnDelWO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    //지시 삭제
        //    try
        //    {
        //        if (acMessageBox.Show("선택한 작업지시를 삭제하시겠습니까? ", "작업지시 삭제", acMessageBox.emMessageBoxType.YESNO) != DialogResult.Yes)
        //            return;


        //        DataRow[] selectedRows = acGridView2.GetSelectedDataRows();

        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("WO_NO", typeof(String));
        //        paramTable.Columns.Add("IS_MAT", typeof(String));


        //        if (selectedRows.Length == 0)
        //        {
        //            DataRow focusRow = acGridView2.GetFocusedDataRow();


        //            //if (focusRow["WO_FLAG"].ToString() == "1" || focusRow["WO_FLAG"].ToString() == "0")
        //            //{
        //            //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //            //    return;
        //            //}

        //            DataRow paramRow = paramTable.NewRow();
        //            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //            paramRow["WO_NO"] = focusRow["WO_NO"];
        //            paramRow["IS_MAT"] = focusRow["IS_MAT"];

        //            paramTable.Rows.Add(paramRow);
        //        }
        //        else
        //        {
        //            foreach (DataRow row in selectedRows)
        //            {
        //                //if (row["WO_FLAG"].ToString() == "1" || row["WO_FLAG"].ToString() == "0")
        //                //{
        //                //    acMessageBox.Show("작업지시 삭제는 [미확정] 혹은 [확정]된 작업만 가능합니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //                //    return;
        //                //}
        //                DataRow paramRow = paramTable.NewRow();
        //                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //                paramRow["WO_NO"] = row["WO_NO"];
        //                paramRow["IS_MAT"] = row["IS_MAT"];

        //                paramTable.Rows.Add(paramRow);
        //            }
        //        }

        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);

        //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN03A_DEL", paramSet, "RQSTDT", "RSLTDT",
        //                QuickDel,
        //                QuickException);

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
        //        {
        //            this.acGridView2.DeleteMappingRow(row);
        //        }

        //        acMessageBox.Show("삭제 처리되었습니다. ", "작업지시 삭제", acMessageBox.emMessageBoxType.CONFIRM);
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        private void acBarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 제작사양서 보기

            DataRow focusRow = _gridView.GetFocusedDataRow();

            if (focusRow == null) { return; }

            //ProdSpec frm = new ProdSpec(focusRow);

            PopSpec frm = new PopSpec(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // BOM 보기

            DataRow focusRow = _gridView.GetFocusedDataRow();

            if (focusRow == null) { return; }

            PopBom frm = new PopBom(focusRow);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

            frm.ParentControl = this;

            frm.ShowDialog(this);

        }

        private void acBarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 도면 보기
            try
            {
                DataRow focusRow = _gridView.GetFocusedDataRow();

                CodeHelperManager.acOpenDrawFile.GetFile(this, focusRow, "JT");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //묶음
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count > 0)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("PART_CODE", typeof(string));
                    paramTable.Columns.Add("PT_ID", typeof(string));
                    paramTable.Columns.Add("RE_WO_NO", typeof(string));

                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        if (selectedView[i]["CHAIN_WO_NO"].ToString() != "")
                        {
                            acAlert.Show(this, "묶음처리되어있는 품목이 존재합니다", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PLN22A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //묶음취소
            try
            {
                acGridView1.EndEditor();

                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("PROD_CODE", typeof(string));
                paramTable.Columns.Add("PART_CODE", typeof(string));
                paramTable.Columns.Add("PT_ID", typeof(string));
                paramTable.Columns.Add("RE_WO_NO", typeof(string));

                if (selectedView.Count > 0)
                {
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                        paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                        paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
                else
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if (focusRow["CHAIN_WO_NO"].ToString() == "") { return; }

                    DataView chainView = acGridView1.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                    for (int i = 0; i < chainView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                        paramRow["PT_ID"] = chainView[i]["PT_ID"];
                        paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PLN22A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //확정
            _gridView.EndEditor();

            DataView selectedView = _gridView.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("PART_CODE", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("RE_WO_NO", typeof(string));

            if (selectedView.Count > 0)
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                    paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                    paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                    paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                    paramTable.Rows.Add(paramRow);
                }
            }
            else
            {
                DataRow focusRow = _gridView.GetFocusedDataRow();

                if (focusRow["CHAIN_WO_NO"].ToString() == "")
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["PT_ID"] = focusRow["PT_ID"];
                    paramRow["RE_WO_NO"] = focusRow["RE_WO_NO"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    DataView chainView = _gridView.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                    for (int i = 0; i < chainView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                        paramRow["PT_ID"] = chainView[i]["PT_ID"];
                        paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PLN22A_INS3", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        private void acBarButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //확정취소
            _gridView.EndEditor();

            DataView selectedView = _gridView.GetDataSourceView("SEL = '1'");

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("PROD_CODE", typeof(string));
            paramTable.Columns.Add("PART_CODE", typeof(string));
            paramTable.Columns.Add("PT_ID", typeof(string));
            paramTable.Columns.Add("RE_WO_NO", typeof(string));

            if (selectedView.Count > 0)
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = selectedView[i]["PROD_CODE"];
                    paramRow["PART_CODE"] = selectedView[i]["PART_CODE"];
                    paramRow["PT_ID"] = selectedView[i]["PT_ID"];
                    paramRow["RE_WO_NO"] = selectedView[i]["RE_WO_NO"];

                    paramTable.Rows.Add(paramRow);
                }
            }
            else
            {
                DataRow focusRow = _gridView.GetFocusedDataRow();

                if (focusRow["CHAIN_WO_NO"].ToString() == "")
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PROD_CODE"] = focusRow["PROD_CODE"];
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["PT_ID"] = focusRow["PT_ID"];
                    paramRow["RE_WO_NO"] = focusRow["RE_WO_NO"];

                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    DataView chainView = _gridView.GetDataSourceView("CHAIN_WO_NO = '" + focusRow["CHAIN_WO_NO"].ToString() + "'");

                    for (int i = 0; i < chainView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PROD_CODE"] = chainView[i]["PROD_CODE"];
                        paramRow["PART_CODE"] = chainView[i]["PART_CODE"];
                        paramRow["PT_ID"] = chainView[i]["PT_ID"];
                        paramRow["RE_WO_NO"] = chainView[i]["RE_WO_NO"];

                        paramTable.Rows.Add(paramRow);
                    }
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PLN22A_INS4", paramSet, "RQSTDT", "RSLTDT",
            QuickSave,
            QuickException);
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {

                    string where = string.Format("PT_ID = '{0}' AND RE_WO_NO IS NULL", row["PT_ID"]);

                    if (row["RE_WO_NO"].toStringEmpty() != "")
                    {
                        where = string.Format("PT_ID = '{0}' AND RE_WO_NO = '{1}'", row["PT_ID"], row["RE_WO_NO"]);
                    }

                    DataRow[] rows = e.result.Tables["RSLTDT_WO"].Select(where);

                    //DataRow[] rows = e.result.Tables["RSLTDT_WO"].Select("PT_ID = '" + row["PT_ID"].ToString() + "'");

                    if (rows.Length > 0)
                    {
                        foreach (DataRow rw in rows)
                        {
                            if (!e.result.Tables["RSLTDT"].Columns.Contains(rw["PROC_CODE"].ToString()))
                            {
                                e.result.Tables["RSLTDT"].Columns.Add(rw["PROC_CODE"].ToString(), typeof(String));
                            }

                            row[rw["PROC_CODE"].ToString()] = rw["WO_FLAG"];
                        }
                    }

                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        Set_Color(row["CHAIN_WO_NO"].ToString());
                    }

                    this._gridView.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void Set_Color(string sName)
        {
            if (!_SetColor.ContainsKey(sName))
            {
                Random r = new Random();

                while (1 < 2)
                {
                    // Get a random fore- and backcolor
                    Color backColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                    Color foreColor = Color.Black;//Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));

                    if (!_SetColor2.ContainsKey(backColor))
                    {
                        // Contrast readable?
                        if (ContrastReadableIs(foreColor, backColor))
                        {
                            _SetColor.Add(sName, backColor);
                            _SetColor2.Add(backColor, sName);
                            break;
                        }
                    }
                }
            }
        }

        public static bool ContrastReadableIs(Color color_1, Color color_2)
        {
            // Maximum contrast would be a value of "1.0f" which is the brightness
            // difference between "Color.Black" and "Color.White"
            float minContrast = 0.8f;

            float brightness_1 = color_1.GetBrightness();
            float brightness_2 = color_2.GetBrightness();

            // Contrast readable?
            return (Math.Abs(brightness_1 - brightness_2) >= minContrast);
        }

    }
}
