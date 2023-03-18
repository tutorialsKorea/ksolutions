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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using BizManager;

namespace SYS
{
    public sealed partial class SYS15A_M0A : BaseMenu
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


        public SYS15A_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);


            acBandGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

           // acGridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView2_FocusedRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acBandGridView1.ShowGridMenuEx += acBandGridView1_ShowGridMenuEx;

            this.Load += SYS15A_M0A_Load;
        }

        private void acBandGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acBandGridView view = sender as acBandGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }



        void SYS15A_M0A_Load(object sender, EventArgs e)
        {
            //this.Search();
        }



        // 사용자별 업무일지 조회
        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           this.GetDetail();
        }



        void GetDetail()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focus = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
           

                paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("S_PLAN_DATE", typeof(String)); //
                paramTable.Columns.Add("E_PLAN_DATE", typeof(String)); //
                //paramTable.Columns.Add("IS_NON_ACT", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = focus["EMP_CODE"]; // 사원코드
                //paramRow["IS_NON_ACT"] = "1";

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "WORK_DATE":
                            paramRow["S_WORK_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                            paramRow["E_WORK_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");
                            break;

                        case "PLAN_DATE":
                            paramRow["S_PLAN_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                            paramRow["E_PLAN_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");
                            break;
                    }
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS15A_SER2", paramSet, "RQSTDT", "RSLTDT_L, RSLTDT_A",
                   QuickDetail,
                   QuickException);
            }
            else
            {
                acBandGridView1.ClearRow();
            }
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

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "WORK_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


                DataSet paramSet = acInfo.RefData.Clone();
                paramSet.Tables["RQSTDT"].Columns.Add("EMP_CODE", typeof(string));

                DataRow newRow = paramSet.Tables["RQSTDT"].NewRow();
                newRow["PLT_CODE"] = acInfo.PLT_CODE;
                newRow["EMP_CODE"] = acInfo.UserID;
                paramSet.Tables["RQSTDT"].Rows.Add(newRow);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "SYS15A_SER3", paramSet, "RQSTDT", "RSLTDT");

                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    if (resultSet.Tables["RSLTDT"].Rows[0]["IS_DAILY"].ToString() != "1")
                    {
                        layout.GetEditor("ORG_CODE").Value = acInfo.UserORG;
                        layout.GetEditor("ORG_CODE").isReadyOnly = true;
                    }
                }
            }

            base.ChildContainerInit(sender);
        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acBandGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    
                    //
                  
                }

            }
        }

        public override void MenuNotify(object data)
        {
            base.MenuNotify(data);
        }


        public override void MenuInit()
        {

            #region 사원정보
            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("HIRE_DATE", "입사일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("IS_PROC", "가공유무", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["EMP_NAME"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            acGridView1.AddHidden("EMP_CODE", typeof(String));

            acGridView1.AddHidden("ORG_CODE", typeof(String));

            //acGridView1.OptionsCustomization.AllowSort = false;

            #endregion

            #region 업무일지

            acBandGridView1.GridType = acBandGridView.emGridType.SEARCH;

            acBandGridView1.OptionsView.ShowIndicator = true;

            acBandGridView1.AddLookUpEdit("DLOG_CAT", "분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S095");

            acBandGridView1.AddLookUpEdit("DLOG_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S096");

            acBandGridView1.AddLookUpEdit("DLOG_PERIOD", "수행주기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S097");

            acBandGridView1.AddLookUpEdit("DLOG_PLAN", "수행예정시기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S098");

            acBandGridView1.AddLookUpVendor("VEN_CODE", "고객명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acBandGridView1.AddTextEdit("RELATED_EMP", "관련자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);

            acBandGridView1.AddLookUpEdit("RELATED_PROD", "직무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S099");

            acBandGridView1.AddMemoEdit("CONTENTS", "직무내용", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);

            acBandGridView1.AddDateEdit("PLAN_DATE", "계획일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE, "계획");

            acBandGridView1.AddTextEdit("DLOG_PLAN_TIME", "예상 소요시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.TIME, "계획");

            acBandGridView1.AddTextEdit("DLOG_PLAN_HOUR_TIME", "예상 소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "계획");

            acBandGridView1.AddTextEdit("PLAN_SCOMMENT", "세부내용 및 특이사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, "계획");

            acBandGridView1.AddDateEdit("WORK_DATE", "수행일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE, "수행");

            acBandGridView1.AddTextEdit("DLOG_TIME", "소요시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.TIME, "수행");

            acBandGridView1.AddTextEdit("DLOG_HOUR_TIME", "소요시간", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.F1, "수행");

            acBandGridView1.AddTextEdit("SCOMMENT", "세부내용 및 특이사항", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE, "수행");

            acBandGridView1.AddCheckEdit("DLOG_ACT_FLAG", "수행여부", "", false, false, true, acBandGridView.emCheckEditDataType._BYTE);

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "조회";

            acBandGridView1.AddCustomEdit("ATCH_FILE", "첨부파일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);

            acBandGridView1.AddCheckEdit("HAS_ATTACH", "첨부파일유무", "", false, false, true, acBandGridView.emCheckEditDataType._STRING);

            acBandGridView1.RowClick += AcGridView2_RowClick;

            acBandGridView1.AddHidden("DLOG_ID", typeof(String));

            acBandGridView1.OptionsView.ShowIndicator = true;

            acBandGridView1.KeyColumn = new string[] { "DLOG_ID" };

            #endregion

            #region 실적

            acGridView3.GridType = acGridView.emGridType.SEARCH;

            acGridView3.OptionsView.ShowIndicator = true;

            acGridView3.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView3.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpVendor("CVND_CODE", "거래처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView3.AddTextEdit("PART_CODE", "품번", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("PART_NAME", "품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView3.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView3.AddTextEdit("MAN_TIME", "실적공수", "CLLN0WCV", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            //acGridView3.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("PLN_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);;

            //acGridView3.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView3.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("EMP_CODE", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView3.AddTextEdit("ORG_NAME", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "WO_NO" };

            #endregion

            acCheckedComboBoxEdit1.AddItem("수행일자", false, "", "WORK_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("계획일자", false, "", "PLAN_DATE", true, false);

            base.MenuInit();


        }

  

        private void attachedFile_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();
                
                if (focusRow != null)
                {
                    if (!base.ChildFormContains("NEW_ITEM"))
                    {
                        SYS15A_D0A frm = new SYS15A_D0A(focusRow);
                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                        frm.ParentControl = this;
                        base.ChildFormAdd("NEW_ITEM", frm);
                        frm.Show(this);
                    }
                    else
                    {
                        base.ChildFormFocus("NEW_ITEM");
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void MenuInitComplete()
        {
            this.Search();
            base.MenuInitComplete();
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
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));
            paramTable.Columns.Add("IS_RETIRE", typeof(String));
            //paramTable.Columns.Add("EMP_CODE", typeof(String)); 


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            //paramRow["EMP_CODE"] = layoutRow["EMP_CODE"]; 

            paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

            if (acCheckEdit1.Checked)
            {
                paramRow["IS_RETIRE"] = null;
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS15A_SER", paramSet, "RQSTDT", "RSLTDT",
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


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_L"];

                acBandGridView1.BestFitColumns();

                if (e.result.Tables["RSLTDT2"].Rows.Count > 0)
                {
                    acLayoutControl2.DataBind(e.result.Tables["RSLTDT2"].Rows[0], false);
                }

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_A"];

                acGridView3.BestFitColumns();


                base.SetLog(e.executeType, e.result.Tables["RSLTDT_L"].Rows.Count, e.executeTime);
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


        private void AcGridView2_RowClick(object sender, RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = (sender as GridView).CalcHitInfo(new Point(e.X, e.Y));

            if (hi.Column != null && hi.Column.FieldName == "ATCH_FILE" && hi.InDataRow)
            {
                try
                {
                    DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (!base.ChildFormContains("NEW_ITEM"))
                        {
                            SYS15A_D0A frm = new SYS15A_D0A(focusRow);
                            frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                            frm.ParentControl = this;
                            base.ChildFormAdd("NEW_ITEM", frm);
                            frm.Show(this);
                            focusRow = null;
                        }
                        else
                        {
                            base.ChildFormFocus("NEW_ITEM");
                        }
                    }
                }
                catch (Exception ex)
                {
                    acMessageBox.Show(this, ex);
                }

            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //상세보기
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["DLOG_ID"]))
                {
                    SYS15A_D1A frm = new SYS15A_D1A(acGridView1, acBandGridView1, focusRow, acTabControl1.GetSelectedContainerName());

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["DLOG_ID"], frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["DLOG_ID"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
