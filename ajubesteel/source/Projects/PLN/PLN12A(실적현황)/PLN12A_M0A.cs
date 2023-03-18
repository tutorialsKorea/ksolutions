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

namespace PLN
{
    public sealed partial class PLN12A_M0A : BaseMenu
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

        public PLN12A_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
            //acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);         
            //acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);
            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;
            //acGridView2.RowCellClick += acGridView2_RowCellClick;

            acGridView3.CustomDrawCell += acGridView3_CustomDrawCell;
            acGridView3.FocusedRowChanged += acGridView3_FocusedRowChanged;

            acTreeList1.FocusedNodeChanged += acTreeList1_FocusedNodeChanged;
            
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
        }

        void acGridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SearchActual();
        }

        void acGridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //선택한 발주처별 품목 정보 조회
            DataRow focus = acGridView3.GetFocusedDataRow();

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (focus != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("CVND_CODE", typeof(String));
                paramTable.Columns.Add("S_ORD_DATE", typeof(String));
                paramTable.Columns.Add("E_ORD_DATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CVND_CODE"] = focus["VEN_CODE"];

                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "ORD_DATE":
                            //수주일

                            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];
                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                 this, QBiz.emExecuteType.LOAD_DETAIL,
                 "PLN03A_SER4", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearch3,
                 QuickException);
            }
            else
            {
                acTreeList1.ClearNodes();

                return;
            }

            //DataRow focus = acGridView3.GetFocusedDataRow();

            //if (focus != null)
            //{
            //    DataTable paramTable = new DataTable("RQSTDT");
            //    paramTable.Columns.Add("PLT_CODE", typeof(String));
            //    paramTable.Columns.Add("CVND_CODE", typeof(String));

            //    DataRow paramRow = paramTable.NewRow();
            //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow["CVND_CODE"] = focus["VEN_CODE"];

            //    paramTable.Rows.Add(paramRow);
            //    DataSet paramSet = new DataSet();
            //    paramSet.Tables.Add(paramTable);

            //    BizRun.QBizRun.ExecuteService(
            //     this, QBiz.emExecuteType.LOAD_DETAIL,
            //     "PLN03A_SER5", paramSet, "RQSTDT", "RSLTDT",
            //     QuickSearch2,
            //     QuickException);
            //}
        }

        

        void acTreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //제품정보 변경 시 작업지시 정보 조회
            SearchWorkorder();
            //DataRow focusRow = acGridView1.GetFocusedDataRow();

            //TreeListNode focusNode = acTreeList1.FocusedNode;

            //if (focusNode != null)
            //{
            //    if (focusNode["WP_NO"].ToString() != "")
            //    {
            //        DataTable paramTable = new DataTable("RQSTDT");
            //        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //        paramTable.Columns.Add("WP_NO", typeof(String)); //

            //        DataRow paramRow = paramTable.NewRow();
            //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //        paramRow["WP_NO"] = focusNode["WP_NO"];

            //        paramTable.Rows.Add(paramRow);

            //        DataSet paramSet = new DataSet();
            //        paramSet.Tables.Add(paramTable);


            //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "PLN03A_SER2", paramSet, "RQSTDT", "RSLTDT",
            //                    QuickSearchDetail,
            //                    QuickException);
            //    }
            //    else
            //    {
            //        acGridView2.ClearRow();
            //    }
            //}

        }

        void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            DataRow focusRow = view.GetFocusedDataRow();

        }


        
        //계획 정보 상세 보기
        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {                    

                    //this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");

                //acGridView1.AddLookUpEdit("WO_TYPE", "작업지시 형태", "BPIJ8QTW", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S037");

                acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("JOB_PRIORITY", "우선순위", "41914", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");

                acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                //acGridView1.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("PLN_START_TIME", "계획시작시간", "10613", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("PLN_END_TIME", "계획완료시간", "10614", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddTextEdit("ACT_MAN_TIME", "유인 실적공수", "CLLN0WCV", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("ACT_TIME", "총 가공시간", "29TE26WL", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

                acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


                acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

                acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.KeyColumn = new string[] { "WO_NO" };


                acGridView2.GridType = acGridView.emGridType.SEARCH;

                acGridView2.AddLookUpEdit("INPUT_FLAG", "입력구분", "UYJGZO3N", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S039");

                acGridView2.AddDateEdit("WORK_DATE", "작업일", "40540", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView2.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("EMP_NAME", "작업자", "40542", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("MC_NM_CHECK", "유/무인", "NVJLZWWQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S033");


                acGridView2.AddLookUpEdit("PROC_STAT", "공정상태", "41055", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S038");


                acGridView2.AddDateEdit("ACT_START_TIME", "시작시간", "N8Z1NIPS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("ACT_END_TIME", "완료시간", "O74LS73I", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("MAN_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("MAN_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("PRE_START_TIME", "준비시작시각", "RTWG2G0Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("PRE_END_TIME", "준비완료시각", "27CR70AY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddTextEdit("MAN_TIME", "유인 실적공수", "CLLN0WCV", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("OT_TIME", "잔업 실적공수", "70NF0OEU", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("PRE_TIME", "준비 실적공수", "IVNZDKSG", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
                //acGridView2.AddTextEdit("SELF_TIME", "무인 실적공수", "DWNYLR5F", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);


                //acGridView2.AddTextEdit("PAUSE_TIME", "작업중지시간", "42640", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);


                acGridView2.AddTextEdit("WORK_TIME", "실적공수", "40402", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);


                acGridView2.AddTextEdit("WORK_QTY", "작업수량", "42643", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("OK_QTY", "양품수량", "42644", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("NG_QTY", "불량수량", "UGW32N5B", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


                acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

                acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


                acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


                acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


                acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);



                acGridView2.KeyColumn = new string[] { "ACTUAL_ID" };

                acGridView3.GridType = acGridView.emGridType.AUTO_COL;

                acGridView3.AddTextEdit("VEN_CODE", "발주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("VEN_NAME", "발주처", "40838", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.AddTextEdit("WORK_CNT", "작업", "WECL735S", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView3.OptionsCustomization.AllowSort = false;


                acTreeList1.KeyFieldName = "PART_KEY";

                acTreeList1.ParentFieldName = "PART_PARENT";

                acTreeList1.AddTextEdit("WP_NO", "계획번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("PARENT_PART", "모품목코드", "56P24JOK", false, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("ITEM_CODE", "수주코드", "40377", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("CVND_NAME", "발주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddDateEdit("ORD_DATE", "수주일", "40902", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emDateMask.SHORT_DATE);

                acTreeList1.AddDateEdit("DUE_DATE", "출하예정일", "40111", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emDateMask.SHORT_DATE);

                acTreeList1.AddTextEdit("PROD_CODE", "제품코드", "40900", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("PART_CODE", "품목코드", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("PART_NAME", "품목명", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("MAT_SPEC", "규격", "C8PZLBQT", false, DevExpress.Utils.HorzAlignment.Center, false, true, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

                acTreeList1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, false, "M003", true);

                //acTreeList1.AddTextEdit("BOM_QTY", "소요수량", "SKYQB65F", true, DevExpress.Utils.HorzAlignment.Center, false, false, ControlManager.acTreeList.emTextEditMask.QTY);

                acTreeList1.AddLookUpEdit("STOCK_CODE", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, false, false, "M005", true);


                acCheckedComboBoxEdit1.AddItem("수주일", true, "40902", "ORD_DATE", true, false);

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "ORD_DATE";
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

        void SearchWorkorder()
        {
            TreeListNode focusNode = acTreeList1.FocusedNode;

            if (focusNode == null) return;

            DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일-조회시작
            //paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업일-조회완료
            //paramTable.Columns.Add("PLN_START_DATE", typeof(String)); //작업지시 계획일- 조회시작
            //paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //작업시지 계획일- 조회완료
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드
            paramTable.Columns.Add("WO_NO", typeof(String)); //작업지시번호

            paramTable.Columns.Add("PROD_CODE", typeof(String));
            //paramTable.Columns.Add("ACT_EMP_CODE", typeof(String));
            //paramTable.Columns.Add("PROC_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();

            //paramRow["PROC_CODE"] = layoutRow["PROC_CODE"];
            //paramRow["WO_NO"] = layoutRow["WO_NO"];
            //paramRow["ACT_ORG_CODE"] = layoutRow["ACT_ORG_CODE"];
            //paramRow["ACT_EMP_CODE"] = layoutRow["ACT_EMP_CODE"];
            paramRow["PROD_CODE"] = focusNode["PROD_CODE"];
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "POP02A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickWorkOrderSearch,
            QuickException);
        }

        void QuickWorkOrderSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.BestFitColumns();

                
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SearchActual()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow != null)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow["WO_NO"] = focusRow["WO_NO"];


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL, "POP02A_SER2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSearchActual,
                    QuickException);
            }
            else
            {
                acGridView2.ClearRow();

                acGridView2.GridControl.Enabled = false;
            }

        }

        void QuickSearchActual(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView2.GridControl.Enabled = true;

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView2.BestFitColumns();
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
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_STATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];
            paramRow["PROD_STATE"] = "WK,PG,SH";

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ORD_DATE":
                        //수주일

                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN03A_SER6", paramSet, "RQSTDT", "RSLTDT,RSLTDT_HEAD",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acGridView3.Columns["VEN_NAME"].Caption = "업체 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["VEN_CNT"].ToString();
                //acGridView3.Columns["WORK_CNT"].Caption = "작업 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"].ToString();

                DataRow dr = e.result.Tables["RSLTDT"].NewRow();
                dr["VEN_NAME"] = "전체 " + "(업체 : " + e.result.Tables["RSLTDT_HEAD"].Rows[0]["VEN_CNT"].ToString() + ")";
                dr["WORK_CNT"] = e.result.Tables["RSLTDT_HEAD"].Rows[0]["WORK_SUM"];

                e.result.Tables["RSLTDT"].Rows.InsertAt(dr, 0);

                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView3.BestFitColumns();


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch3(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acTreeList1.DataSource = e.result.Tables["RSLTDT"];
                acTreeList1.ExpandAll();
                
                acTreeList1.BestFitColumns();

                if (e.result.Tables["RSLTDT"].Rows.Count == 0)
                {
                    acGridView2.ClearRow();
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickSearchDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
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

        //private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        if (acGridView1.ValidFocusRowHandle() == false)
        //        {
        //            return;
        //        }


        //        DataRow focusRow = acGridView1.GetFocusedDataRow();


        //        string formKey = string.Format("{0},{1}", "WP_NO", focusRow["WP_NO"]);

        //        if (!base.ChildFormContains(formKey))
        //        {

        //            PLN03A_D0A frm = new PLN03A_D0A(acGridView1,acGridView2, focusRow);

        //            frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

        //            frm.ParentControl = this;

        //            base.ChildFormAdd(formKey, frm);

        //            frm.Show(this);

        //        }
        //        else
        //        {
        //            base.ChildFormFocus(formKey);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}

        //삭제
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WP_NO", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //

            DataView selectedView = acGridView1.GetDataView("SEL = '1'");

            if (selectedView.Count == 0)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WP_NO"] = focusRow["WP_NO"];
                paramRow["DEL_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
            }
            else
            {
                for (int i = 0; i < selectedView.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["WP_NO"] = selectedView[i]["WP_NO"];
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


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in e.result.Tables["RSLTDT"].Rows)
                {

                    acGridView2.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        
    }
}
