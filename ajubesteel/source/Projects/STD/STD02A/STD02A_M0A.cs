using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace STD
{
    public sealed partial class STD02A_M0A : BaseMenu
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

        /// <summary>
        /// 표준부품
        /// </summary>
        public STD02A_M0A()
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


        private DataTable _dtProcList = null;

        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            //acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("STD_PT_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEdit("MAT_TYPE1", "자재구분", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");

            //acGridView1.AddLookUpEdit("MAT_TYPE2", "자재유형", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");


            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");

            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");

            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

            //acGridView1.AddTextEdit("PART_ENAME", "부품명(영문)", "40235", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEdit("PART_PRODTYPE", "부품제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");

            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView1.AddLookUpEdit("PACK_UNIT", "포장단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            //acGridView1.AddLookUpEdit("SPEC_TYPE", "규격입력형태", "42540", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S062");

            acGridView1.AddTextEdit("CUTTING_CNT", "절단가능수량", "42545", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "42544", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "42545", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //PART_PRODTYPE
            //MAT_TYPE S016
            //MAIN_VND, SUPP_VND

            acGridView1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "M007");
            acGridView1.AddLookUpEdit("MAT_TYPE", "구매 분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");

            acGridView1.AddLookUpEdit("STK_LOCATION", "기본창고", "NO1T1YEG", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M005");

            acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("BALJU_QTY", "발주수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("MNG_FLAG", "관리유무", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            
            acGridView1.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            //acGridView1.AddTextEdit("AUTO_MARGIN_SPEC", "여유사양", "1AW7AFGL", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEdit("LOAD_FLAG", "BOP 부품", "M920A2XO", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S024");

            //acGridView1.AddLookUpEdit("SCH_METHOD", "스케줄 방법", "42462", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S060");

            //acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

            // acGridView1.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAT_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MAT_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");

            //acGridView1.AddLookUpEdit("USE_FLAG", "사영여부", "42560", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S063");

            acGridView1.AddTextEdit("MAT_COST", "자재단가", "40121", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("PROC_COST", "가공 외주단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddLookUpVendor("MAIN_VND", "가공 외주업체", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);

            acGridView1.AddTextEdit("PROC_COST2", "도금 외주단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddLookUpVendor("MAIN_VND2", "도금 외주업체", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);

            //acGridView1.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "C600");

            //acGridView1.AddTextEdit("PART_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("IS_MAIN_PART", "자재관리 대표자재", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddCheckEdit("IS_MAIN_SEARCH", "주요부품", "", false, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddLookUpEdit("PART_CAT", "품목유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P030");

            acGridView1.AddTextEdit("CAM_TIME", "CAM시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("MIL_TIME", "밀링시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("MC_TIME", "가공시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("MID_INS_TIME", "중간검사 시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("ASSEY_TIME", "조립시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("SHIP_INS_TIME", "출하검사 시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DWG_NAME", "도면명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROJECT_NAME", "프로젝트명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CMS_NO", "CMS NO", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("ORDERCOUNT", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SPECIFICATION", "규격", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONNECTOR_NO", "커넥터 NO", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONNECTOR_ANGLE", "커넥터 각도", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONTACT_PIN1", "적용핀1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONTACT_PIN2", "적용핀2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONTACT_PIN3", "적용핀3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONTACT_PIN4", "적용핀4", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CORE_HOUSING1", "코어 하우징1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CORE_HOUSING2", "코어 하우징2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CORE_HOUSING3", "코어 하우징3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CORE_HOUSING4", "코어 하우징4", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONTACT_DIRECTION", "커텍 방향", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CONNECTOR_DIRECTION", "커넥터 방향", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IMAGE_DIRECTION", "화상 방향", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APPLY_INTERFACE", "인터페이스 적용 유무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("INTERFACE_PIN", "인터페이스 핀", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APPLY_INTERFACE_PIN", "GND 핀 적용 유무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("GND_PIN", "GND 핀", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IMAGE_ANGLE1", "화각1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IMAGE_ANGLE2", "화각2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IMAGE_ANGLE3", "화각3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("IMAGE_ANGLE4", "화각4", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_REV_ID", "파트 리비전 아이디", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_PUID", "파트 PUID", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DIVISION_P", "제작구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DIVISION", "제품구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MARTERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAKESIDEHOLE", "추가가공", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TAB_MACHINE", "탭유무", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MACHINE_TIME", "가공시간", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);



            //acGridView1.AddTextEdit("IF_PART_CODE", "IF 코드", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "PART_CODE" };


            acCheckedComboBoxEdit1.AddItem("등록일", true, "CZP2OQ22", "REG_DATE", true, false);



            acGridView2.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MAT_SPEC", "규격", "42544", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            this._dtProcList = ExtensionMethods.GetProcList(this);

            foreach (DataRow row in this._dtProcList.Rows)
            {

                //acGridView2.AddTextEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddCheckEdit(row["PROC_CODE"].ToString(), row["PROC_NAME"].ToString(), "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.Columns[row["PROC_CODE"].ToString()].Tag = "PROC";
            }


            acGridView2.RowHeight = 45;
            //이벤트 설정

            acGridView1.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;


            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            acGridView2.CellValueChanging += acGridView2_CellValueChanging;
            //barAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //barEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

            base.MenuInit();
        }

        private void acGridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.acGridView2.SetRowCellValue(e.RowHandle, e.Column, e.Value);
            this.acGridView2.EndEditor();
        }

        private void acGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.CellValue.ToString() == "1")
                e.Appearance.BackColor = Color.YellowGreen;
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.ValidFocusRowHandle())
            {
                this.GetDetail();
                this.btnProcSave.Enabled = true;
            }
            else
            {
                acGridView2.ClearRow();
                this.btnProcSave.Enabled = false;
            }
        }

        private void GetDetail()
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acGridView2.ClearRow();

                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = focusRow["PART_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "STD02A_SER2", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);

        }


        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //this._dicProcStat.Clear();

                DataTable dtTemp = new DataTable();

                dtTemp.Columns.Add("PART_CODE", typeof(string));
                dtTemp.Columns.Add("PART_NAME", typeof(string));
                dtTemp.Columns.Add("MAT_SPEC", typeof(string));

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                foreach (DataRow row in this._dtProcList.Rows)
                {
                    dtTemp.Columns.Add(row["PROC_CODE"].ToString(), typeof(string));
                }

                DataRow newRow = dtTemp.NewRow();
                newRow["PART_CODE"] = focusRow["PART_CODE"];
                newRow["PART_NAME"] = focusRow["PART_NAME"];
                newRow["MAT_SPEC"] = focusRow["MAT_SPEC"];
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    newRow[row["PROC_CODE"].ToString()] = 1;
                }

                dtTemp.Rows.Add(newRow);

                acGridView2.GridControl.DataSource = dtTemp;

                acGridView2.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
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

                case "MAT_LTYPE":

                    if (newValue == null)
                    {
                        layout.GetEditor("MAT_MTYPE").Value = null;
                    }

                    (layout.GetEditor("MAT_MTYPE") as acLookupEdit).SetCode("M015", newValue);

                    break;

            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["PART_CODE"]);
            }
        }
        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = string.Empty;
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;
                this.btnProcSave.Enabled = false;

            }

        }


        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

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

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //표준부품 편집기 열기

                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }

        //void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        //{
        //    acGridView view = sender as acGridView;


        //    if (e.MenuType == GridMenuType.User)
        //    {
        //        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        //    }
        //    else if (e.MenuType == GridMenuType.Row)
        //    {
        //        if (e.HitInfo.RowHandle >= 0)
        //        {
        //            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //        }
        //        else
        //        {
        //            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //            acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //        }
        //    }


        //    if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
        //    {

        //        GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

        //        popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


        //    }
        //}


        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("PART_LIKE", typeof(String));
            paramTable.Columns.Add("SPEC_LIKE", typeof(String));
            paramTable.Columns.Add("S_REG_DATE", typeof(String));
            paramTable.Columns.Add("E_REG_DATE", typeof(String));
            paramTable.Columns.Add("MAT_LTYPE", typeof(String));
            paramTable.Columns.Add("MAT_MTYPE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"].toDateString("yyyyMMdd");
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"].toDateString("yyyyMMdd");

                        break;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "STD02A_SER", paramSet, "RQSTDT", "RSLTDT",
                   QuickSearch,
                   QuickException);

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
        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.SetOldFocusRowHandle(false);


                //조회 메뉴로그 
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

        private void EditItem()
        {
            //표준부품 편집기 열기
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["PART_CODE"]))
                {

                    STD02A_D0A frm = new STD02A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["PART_CODE"], frm);

                    frm.Show(this);


                }
                else
                {

                    base.ChildFormFocus(focusRow["PART_CODE"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditItem();
        }

        private void AddItem()
        {

            //표준부품 편집기 새로만들기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    STD02A_D0A frm = new STD02A_D0A(acGridView1, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

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
            AddItem();

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                acGridView1.EndEditor();



                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }



                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                if (selectedRows.Length == 0)
                {

                    //단일삭제
                    DataRow focusRow = acGridView1.GetFocusedDataRow();


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);



                }
                else
                {

                    //다중삭제
                    //for (int i = 0; i < selected.Count; i++)
                    foreach(DataRow row in selectedRows)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_CODE"] = row["PART_CODE"];
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }

                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "STD02A_DEL", paramSet, "RQSTDT", "RSLTDT",
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

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //엑셀 데이터 불러오기
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD02A_D1A frm = new STD02A_D1A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



            
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //표준화 필요성 부품

            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD02A_D2A frm = new STD02A_D2A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
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

        private void btnProcSave_Click(object sender, EventArgs e)
        {
            if (acGridView2.RowCount == 0) return;

            acGridView2.EndEditor();
            //DataRow masterRow = acGridView1.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_SEQ", typeof(int)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //


            int i = 0;

            foreach(acGridColumn col in acGridView2.Columns)
            {
                if(col.Tag != null && col.Tag.ToString() == "PROC")
                {
                    string test = acGridView2.GetFocusedDataRow()[col.FieldName].ToString();

                    if (acGridView2.GetFocusedDataRow()[col.FieldName].Equals("1") || acGridView2.GetFocusedDataRow()[col.FieldName].Equals(""))
                    {
                        DataRow newRow = paramTable.NewRow();
                        newRow["PLT_CODE"] = acInfo.PLT_CODE;
                        newRow["PART_CODE"] = acGridView2.GetFocusedDataRow()["PART_CODE"];
                        newRow["PROC_CODE"] = col.FieldName;
                        newRow["PROC_SEQ"] = i;
                        newRow["REG_EMP"] = acInfo.UserID;
                        i++;

                        paramTable.Rows.Add(newRow);
                    }
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "STD02A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);
        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnMultiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //표준부품 편집기 열기
            try
            {

      

                if (!base.ChildFormContains("MULTI_STD_PART_EDIT"))
                {

                    STD02A_D3A frm = new STD02A_D3A(acGridView1);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd("MULTI_STD_PART_EDIT", frm);

                    frm.Show(this);


                }
                else
                {

                    base.ChildFormFocus("MULTI_STD_PART_EDIT");

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}