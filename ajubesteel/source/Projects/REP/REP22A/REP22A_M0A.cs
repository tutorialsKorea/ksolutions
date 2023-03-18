using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid;
using DevExpress.XtraCharts;
using BizManager;

namespace REP
{
    public sealed partial class REP22A_M0A : BaseMenu
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

        public REP22A_M0A()
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



            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_COST", "원가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            acGridView1.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView1.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BUSINESS_EMP_NAME", "영업담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_CIRCLE", "1.원판비 합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_PROC", "2.가공비 합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_PO_MAT", "3.구매비 합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_EX_COST", "제조경비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROD_AMT", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                        
            acGridView2.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            acGridView2.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView2.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView2.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("IS_OS", "제조구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_CODE", "부품코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "부품명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MATERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("MAT_CODE", "소재코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            

            acGridView2.AddTextEdit("CIRCLE_COST", "재료비", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("PART_QTY", "생산수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView2.AddTextEdit("DES_COST", "설계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("MILL_COST", "밀링", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("CAM_COST", "CAM", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("MCT_COST", "MCT", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("SIDE_COST", "후공정", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("ASSY_COST", "조립", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("SHIP_COST", "출하", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("INS_COST", "검사", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView3.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            acGridView3.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView3.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView3.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView3.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView3.AddTextEdit("OUT_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("MAT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("OUT_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView4.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P027");
            acGridView4.AddLookUpEdit("PROD_FLAG", "유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P006");
            acGridView4.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P010");
            acGridView4.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("OVND_CODE", "거래처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("OVND_NAME", "거래처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView4.AddTextEdit("AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            base.MenuInit();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }
        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = new DateTime(DateTime.Now.Year, 1, 1);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (acLayoutControl1.ValidCheck() == false)
            {

                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_ORD_DATE", typeof(String));
            paramTable.Columns.Add("E_ORD_DATE", typeof(String));
            

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "REP22A_SER", paramSet, "RQSTDT", "RSLTDT",
            DaySearchCallBack,
            QuickException);



        }
        void DaySearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_PROC"];
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_MAT"];
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT_PO"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {

            acMessageBox.Show(this, ex);

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!base.ChildFormContains("NEW"))
            {

                REP22A_D0A frm = new REP22A_D0A();

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
    }
}
