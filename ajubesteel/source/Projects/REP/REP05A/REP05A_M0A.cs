using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraCharts;
using System.Linq;
using BizManager;

namespace REP
{
    public sealed partial class REP05A_M0A : BaseMenu
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
        public override void MenuLink(object data)
        {
            try
            {
                DataRow linkRow = data as DataRow;

                if (linkRow.Table.Columns.Contains("MC_CODE"))
                {
                    acTabControl2.SelectedTabPage = acTabPage4;
                    acTabControl4.SelectedTabPage = acTabPage15;

                    acLayoutControl9.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-2);
                    acLayoutControl9.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();
                    acLayoutControl9.GetEditor("MC_CODE").Value = linkRow["MC_CODE"];

                    Search();


                }
                else
                {
                    acTabControl2.SelectedTabPage = acTabPage1;
                    acTabControl1.SelectedTabPage = acTabPage3;

                    DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String));
                    paramTable2.Columns.Add("EMP_CODE", typeof(String));
                    paramTable2.Columns.Add("IS_CAM", typeof(String));

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["EMP_CODE"] = linkRow["EMP_CODE"];
                    paramRow2["IS_CAM"] = "1";


                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_EMP_SEARCH", paramSet2, "RQSTDT", "RSLTDT",
                       QuickSearch3,
                       QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public REP05A_M0A()
        {
            InitializeComponent();



            //acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

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
            this.Search();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl2)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl3)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-22);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-1);
            }
            else if (sender == acLayoutControl4)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl5)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-22);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-1);
            }
            else if (sender == acLayoutControl6)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl7)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowDateFromServer();
            }
            else if (sender == acLayoutControl8)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-7);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(7);
            }
            else if (sender == acLayoutControl9)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-7);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(7);
            }

            

            base.ChildContainerInit(sender);
        }




        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.LIST;
            acGridView1.AddTextEdit("TYPE", "유  형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.GridType = acGridView.emGridType.LIST;
            acGridView2.AddTextEdit("WORK_LOC_NAME", "근무처", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_CODE", "CAM담당자코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "CAM담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TYPE", "유  형", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.GridType = acGridView.emGridType.LIST;
            acGridView4.AddTextEdit("CVND_NAME", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("WORK_AVG", "평균", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.GridType = acGridView.emGridType.AUTO_COL;

            acGridView6.AddLookUpEdit("WORK_LOC", "근무처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "E001");

            acGridView6.AddTextEdit("EMP_NAME", "사원명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.AddDateEdit("HIRE_DATE", "입사일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            acGridView6.AddTextEdit("ORG_NAME", "부서명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView6.Columns["EMP_NAME"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            acGridView6.AddHidden("EMP_CODE", typeof(String));

            acGridView6.AddHidden("ORG_CODE", typeof(String));


            acGridView7.GridType = acGridView.emGridType.LIST;
            acGridView7.AddTextEdit("TYPE_NAME", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView7.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView8.GridType = acGridView.emGridType.SEARCH;
            acGridView8.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("MATERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView8.AddTextEdit("MCT_ACT_QTY", "MCT 완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddTextEdit("OUT_ACT_QTY", "외주가공 완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddDateEdit("MCT_ACT_END_TIME", "완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView8.AddTextEdit("INS_ACT_QTY", "중간검사 완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView8.AddDateEdit("INS_ACT_END_TIME", "중간검사 완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView9.GridType = acGridView.emGridType.LIST;
            acGridView9.AddTextEdit("INS_NAME", "구  분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("WORK_1", "1월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_2", "2월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_3", "3월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_4", "4월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_5", "5월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_6", "6월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_7", "7월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_8", "8월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_9", "9월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_10", "10월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_11", "11월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_12", "12월", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView9.AddTextEdit("WORK_SUM", "합계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acGridView10.GridType = acGridView.emGridType.SEARCH;
            acGridView10.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("MATERIAL", "재질", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("SURFACE_TREAT", "표면처리/도장", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("AFTER_TREAT", "후처리", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddTextEdit("ACT_QTY", "완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView10.AddDateEdit("ACT_END_TIME", "중간검사 완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView11.GridType = acGridView.emGridType.SEARCH;
            acGridView11.AddTextEdit("TYPE1", "공정 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView11.AddTextEdit("TYPE2", "타입", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView11.AddTextEdit("TYPE3", "  ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView12.GridType = acGridView.emGridType.SEARCH;
            acGridView12.AddTextEdit("TYPE1", "공정 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView12.AddTextEdit("TYPE2", "타입", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView12.AddTextEdit("TYPE3", "  ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView13.GridType = acGridView.emGridType.SEARCH;
            acGridView13.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView13.AddTextEdit("CVND_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView10.AddDateEdit("WORK_DATE", "작업일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView13.AddTextEdit("OK_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView13.AddTextEdit("ACT_TIME", "가공시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);

            acGridView1.OptionsView.AllowCellMerge = true;
            acGridView2.OptionsView.AllowCellMerge = true;
            acGridView4.OptionsView.AllowCellMerge = true;
            acGridView11.OptionsView.AllowCellMerge = true;
            acGridView12.OptionsView.AllowCellMerge = true;

            acDateEdit1.Properties.EditMask = "yyyy";
            acDateEdit2.Properties.EditMask = "yyyy";
            acDateEdit4.Properties.EditMask = "yyyy";
            acDateEdit8.Properties.EditMask = "yyyy";
            acDateEdit9.Properties.EditMask = "yyyy";

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;
            acGridControl1.Paint += acGridControl1_Paint;

            acGridView2.CustomDrawCell += acGridView2_CustomDrawCell;
            acGridControl2.Paint += acGridControl2_Paint;

            acGridView4.CustomDrawCell += acGridView4_CustomDrawCell;
            acGridControl4.Paint += acGridControl4_Paint;

            acGridView11.CustomDrawCell += acGridView11_CustomDrawCell;
            acGridControl11.Paint += acGridControl11_Paint;

            acGridView12.CustomDrawCell += acGridView12_CustomDrawCell;
            acGridControl12.Paint += acGridControl12_Paint;


            acGridView2.Columns["WORK_LOC_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView2.Columns["EMP_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView2.Columns["EMP_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acGridView2.CellMerge += acGridView2_CellMerge;

            (acLayoutControl2.GetEditor("WORK_LOC") as acLookupEdit).SetCode("E001");

            //(acLayoutControl3.GetEditor("MC_GROUP").Editor as acLookupEdit).SetCode("C020");
            //(acLayoutControl3.GetEditor("MC_GROUP").Editor as acLookupEdit).Value = "A";


            acCheckedComboBoxEdit1.AddItem("C020", "1", "0", CheckState.Unchecked);
            acCheckedComboBoxEdit1.GetItem("A").CheckState = CheckState.Checked;
            acCheckedComboBoxEdit1.GetItem("B").CheckState = CheckState.Checked;
            acCheckedComboBoxEdit1.GetItem("C").CheckState = CheckState.Checked;
            acCheckedComboBoxEdit1.GetItem("H").CheckState = CheckState.Checked;
            acCheckedComboBoxEdit1.GetItem("D").CheckState = CheckState.Checked;
            acCheckedComboBoxEdit1.GetItem("E").CheckState = CheckState.Checked;


            acGridView4.ColumnFilterChanged += acGridView4_ColumnFilterChanged;

            acGridView4.CustomColumnSort += acGridView4_CustomColumnSort;

            foreach (acGridColumn col in acGridView4.Columns)
            {
                col.SortMode = ColumnSortMode.Custom;
            }

            //acGridView4.Columns["CVND_NAME"].SortMode = ColumnSortMode.Custom;

            acGridView6.FocusedRowChanged += acGridView6_FocusedRowChanged;




            base.MenuInit();

        }

        private void acGridView6_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                DataRow focusRow = acGridView6.GetFocusedDataRow();

                if (focusRow != null)
                {
                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String));
                    paramTable2.Columns.Add("YEAR", typeof(String));
                    //paramTable2.Columns.Add("WORK_LOC", typeof(String));
                    paramTable2.Columns.Add("EMP_CODE", typeof(String));


                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["YEAR"] = layoutRow2["YEAR"];
                    //paramRow2["WORK_LOC"] = layoutRow2["WORK_LOC"];
                    paramRow2["EMP_CODE"] = focusRow["EMP_CODE"];

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "REP05A_SER2", paramSet2, "RQSTDT", "RSLTDT, RSLTDT2. RSLTDT3",
                       QuickSearch2,
                       QuickException);
                }
                else
                {
                    acGridView2.ClearRow();
                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView4_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                e.Handled = true;

                string key1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "CVND_CODE").ToString();
                string key2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "CVND_CODE").ToString();

                if (key1 == key2)
                {
                    e.Handled = false;
                    return;
                }

                if (key1.Equals("AVG"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? -1 : 1);
                }
                else if (key2.Equals("AVG"))
                {
                    e.Result = (e.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending ? 1 : -1);
                }
                else
                {
                    if (e.Value1 == null || e.Value2 == null) return;

                    string val1 = e.Value1.ToString();
                    string val2 = e.Value2.ToString();

                    val1 = val1.Substring(0, val1.Length - 1);

                    decimal dVal1 = 0;
                    if (val1.isNumeric())
                    {
                        dVal1 = val1.toDecimal();
                    }

                    val2 = val2.Substring(0, val2.Length - 1);

                    decimal dVal2 = 0;
                    if (val2.isNumeric())
                    {
                        dVal2 = val2.toDecimal();
                    }

                    e.Result = dVal1.CompareTo(dVal2);


                    //e.Handled = false;
                }
            }
            catch { }
            

        }

        private void acGridView4_EndSorting(object sender, EventArgs e)
        {
        }

        private void acGridView4_StartSorting(object sender, EventArgs e)
        {
            
        }

        private void acGridView4_ColumnFilterChanged(object sender, EventArgs e)
        {
            
        }

        private void acGridView2_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName.Equals("EMP_CODE")
                || e.Column.FieldName.Equals("EMP_NAME")
                || e.Column.FieldName.Equals("WORK_LOC_NAME"))

            {
                string cEmp1 = acGridView2.GetRowCellValue(e.RowHandle1, "EMP_CODE").ToString();
                string cEmp2 = acGridView2.GetRowCellValue(e.RowHandle2, "EMP_CODE").ToString();

                if (cEmp1 == cEmp2)
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

        private void acGridView11_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName.Equals("TYPE1"))

            {
                string val1 = acGridView11.GetRowCellValue(e.RowHandle1, "TYPE1").ToString();
                string val2 = acGridView11.GetRowCellValue(e.RowHandle2, "TYPE1").ToString();

                if (val1 == val2)
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
            else if (e.Column.FieldName.Equals("TYPE2"))
            {
                string val1 = acGridView11.GetRowCellValue(e.RowHandle1, "TYPE2").ToString();
                string val2 = acGridView11.GetRowCellValue(e.RowHandle2, "TYPE2").ToString();

                if (val1 == val2)
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

        private void acGridView12_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName.Equals("TYPE1"))

            {
                string val1 = acGridView12.GetRowCellValue(e.RowHandle1, "TYPE1").ToString();
                string val2 = acGridView12.GetRowCellValue(e.RowHandle2, "TYPE1").ToString();

                if (val1 == val2)
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
            else if (e.Column.FieldName.Equals("TYPE2"))
            {
                string val1 = acGridView12.GetRowCellValue(e.RowHandle1, "TYPE2").ToString();
                string val2 = acGridView12.GetRowCellValue(e.RowHandle2, "TYPE2").ToString();

                if (val1 == val2)
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

        private void acGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "EMP_CODE"
                || e.Column.FieldName == "EMP_NAME"
                || e.Column.FieldName == "WORK_LOC_NAME") return;

            string type = acGridView1.GetRowCellValue(e.RowHandle, "TYPE").toStringEmpty();

            if (type == "총 건수"
                || type == "불량건수")
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void acGridControl1_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            for (int i = 0; i < acGridView1.RowCount; i++)
            {
                if (acGridView1.GetRowCellDisplayText(i, acGridView1.Columns["TYPE"]) == "총 건수")
                {
                    GridViewInfo info = (GridViewInfo)acGridView1.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView1.Columns["TYPE"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(acGridControl1.Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView1.Columns["WORK_SUM"]).Bounds.Right, cell.Bounds.Bottom));
                        prev = acGridView1.GetRowCellDisplayText(i, acGridView1.Columns["TYPE"]);
                    }
                }
            }

        }

        private void acGridView2_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "EMP_CODE"
                || e.Column.FieldName == "EMP_NAME"
                || e.Column.FieldName == "WORK_LOC_NAME") return;

            string type = acGridView2.GetRowCellValue(e.RowHandle, "TYPE").toStringEmpty();

            if (type == "총 건수"
                || type == "불량건수")
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void acGridControl2_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            for (int i = 0; i < acGridView2.RowCount; i++)
            {
                if (acGridView2.GetRowCellDisplayText(i, acGridView2.Columns["TYPE"]) == "총 건수")
                {
                    GridViewInfo info = (GridViewInfo)acGridView2.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView2.Columns["TYPE"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(info.GetGridCellInfo(i, acGridView2.Columns["TYPE"]).Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView2.Columns["WORK_SUM"]).Bounds.Right, cell.Bounds.Bottom));
                    }
                }

                if (acGridView2.GetRowCellDisplayText(i, acGridView2.Columns["TYPE"]) == "비율")
                {
                    GridViewInfo info = (GridViewInfo)acGridView2.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView2.Columns["TYPE"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(acGridControl1.Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView2.Columns["WORK_SUM"]).Bounds.Right, cell.Bounds.Bottom));
                    }
                }
            }

        }

        private void acGridView4_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "CVND_NAME") return;

            string type = acGridView4.GetRowCellValue(e.RowHandle, "CVND_NAME").toStringEmpty();

            if (type == "평균")
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void acGridControl4_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            for (int i = 0; i < acGridView4.RowCount; i++)
            {
                if (acGridView4.GetRowCellDisplayText(i, acGridView4.Columns["CVND_NAME"]) == "평균")
                {
                    GridViewInfo info = (GridViewInfo)acGridView4.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView4.Columns["CVND_NAME"]);
                    if (cell != null)
                    {
                        e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(info.GetGridCellInfo(i, acGridView4.Columns["CVND_NAME"]).Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView4.Columns["WORK_AVG"]).Bounds.Right, cell.Bounds.Bottom));
                    }
                }
            }

        }

        private void acGridView11_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "TYPE1") return;

            string type = acGridView11.GetRowCellValue(e.RowHandle, "TYPE2").toStringEmpty();

            if (type == "AL류")
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (type == "수지류")
            {
                e.Appearance.BackColor = Color.Cornsilk;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void acGridControl11_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            for (int i = 0; i < acGridView11.RowCount; i++)
            {
                if (acGridView11.GetRowCellDisplayText(i, acGridView11.Columns["TYPE2"]) == "수지류"
                    && acGridView11.GetRowCellDisplayText(i, acGridView11.Columns["TYPE3"]) == "수량")
                {
                    GridViewInfo info = (GridViewInfo)acGridView11.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView11.Columns["TYPE2"]);
                    GridCellInfo cell2 = info.GetGridCellInfo(i, acGridView11.Columns[acGridView11.Columns.Count - 1]);
                    if (cell != null && cell2 != null)
                    {
                        //e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(info.GetGridCellInfo(i, acGridView11.Columns["TYPE1"]).Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView11.Columns[acGridView11.Columns.Count - 1]).Bounds.Right, cell.Bounds.Bottom));
                    }
                }
            }

        }

        private void acGridView12_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "TYPE1") return;

            string type = acGridView12.GetRowCellValue(e.RowHandle, "TYPE2").toStringEmpty();

            if (type == "AL류")
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (type == "수지류")
            {
                e.Appearance.BackColor = Color.Cornsilk;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void acGridControl12_Paint(object sender, PaintEventArgs e)
        {
            string prev = string.Empty;
            for (int i = 0; i < acGridView12.RowCount; i++)
            {
                if (acGridView12.GetRowCellDisplayText(i, acGridView12.Columns["TYPE2"]) == "수지류"
                    && acGridView12.GetRowCellDisplayText(i, acGridView12.Columns["TYPE3"]) == "수량")
                {
                    GridViewInfo info = (GridViewInfo)acGridView12.GetViewInfo();
                    GridCellInfo cell = info.GetGridCellInfo(i, acGridView12.Columns["TYPE1"]);
                    GridCellInfo cell2 = info.GetGridCellInfo(i, acGridView12.Columns[acGridView11.Columns.Count - 1]);
                    if (cell != null && cell2 != null)
                    {
                        //e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(info.GetGridCellInfo(i, acGridView12.Columns["TYPE1"]).Bounds.Left, cell.Bounds.Bottom), new Point(info.GetGridCellInfo(i, acGridView12.Columns[acGridView12.Columns.Count - 1]).Bounds.Right, cell.Bounds.Bottom));
                    }
                }
            }

        }


        private BizManager.QThread _SearchThread = null;

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

        void Search()
        {
            switch (acTabControl2.GetSelectedContainerName())
            {
                case "CAM":

                    switch(acTabControl1.GetSelectedContainerName())
                    {
                        case "TOTAL":

                            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("YEAR", typeof(String));


                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["YEAR"] = layoutRow["YEAR"];

                            paramTable.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP05A_SER", paramSet, "RQSTDT", "RSLTDT, RSLTDT2. RSLTDT3",
                               QuickSearch,
                               QuickException);

                            break;

                        case "EMP":

                            DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                            DataTable paramTable2 = new DataTable("RQSTDT");
                            paramTable2.Columns.Add("PLT_CODE", typeof(String));
                            paramTable2.Columns.Add("EMP_CODE", typeof(String));
                            paramTable2.Columns.Add("WORK_LOC", typeof(String));
                            paramTable2.Columns.Add("IS_CAM", typeof(String));
                            paramTable2.Columns.Add("IS_RETIRE", typeof(String));

                            DataRow paramRow2 = paramTable2.NewRow();
                            paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow2["EMP_CODE"] = layoutRow2["EMP_CODE"];
                            paramRow2["WORK_LOC"] = layoutRow2["WORK_LOC"];
                            paramRow2["IS_CAM"] = "1";

                            paramRow2["IS_RETIRE"] = layoutRow2["IS_RETIRE"];

                            if (acCheckEdit1.Checked)
                            {
                                paramRow2["IS_RETIRE"] = null;
                            }

                            paramTable2.Rows.Add(paramRow2);
                            DataSet paramSet2 = new DataSet();
                            paramSet2.Tables.Add(paramTable2);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_EMP_SEARCH", paramSet2, "RQSTDT", "RSLTDT",
                               QuickSearch3,
                               QuickException);

                            break;
                    }

                    break;

                case "MCT":

                    switch(acTabControl4.GetSelectedContainerName())
                    {
                        case "MC":
                            if (acLayoutControl9.ValidCheck() == false)
                            {
                                return;
                            }

                            DataRow layoutRow9 = acLayoutControl9.CreateParameterRow();

                            DataTable paramTable9 = new DataTable("RQSTDT");
                            paramTable9.Columns.Add("PLT_CODE", typeof(String));
                            paramTable9.Columns.Add("S_WORK_DATE", typeof(String));
                            paramTable9.Columns.Add("E_WORK_DATE", typeof(String));
                            paramTable9.Columns.Add("MC_CODE", typeof(String));


                            DataRow paramRow9 = paramTable9.NewRow();
                            paramRow9["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow9["S_WORK_DATE"] = layoutRow9["S_DATE"];
                            paramRow9["E_WORK_DATE"] = layoutRow9["E_DATE"];
                            paramRow9["MC_CODE"] = layoutRow9["MC_CODE"];

                            paramTable9.Rows.Add(paramRow9);
                            DataSet paramSet9 = new DataSet();
                            paramSet9.Tables.Add(paramTable9);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP05A_SER9", paramSet9, "RQSTDT", "RSLTDT, RSLTDT2",
                               QuickSearch9,
                               QuickException);

                            break;

                        default:
                            DataRow layoutRow6 = acLayoutControl6.CreateParameterRow();

                            DataTable paramTable6 = new DataTable("RQSTDT");
                            paramTable6.Columns.Add("PLT_CODE", typeof(String));
                            paramTable6.Columns.Add("YEAR", typeof(String));


                            DataRow paramRow6 = paramTable6.NewRow();
                            paramRow6["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow6["YEAR"] = layoutRow6["YEAR"];

                            paramTable6.Rows.Add(paramRow6);
                            DataSet paramSet6 = new DataSet();
                            paramSet6.Tables.Add(paramTable6);

                            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP05A_SER7", paramSet6, "RQSTDT", "RSLTDT, RSLTDT2",
                               QuickSearch6,
                               QuickException);
                            break;
                    }



                    break;

                case "ACT":

                    DataRow layoutRow8 = acLayoutControl8.CreateParameterRow();

                    DataTable paramTable8 = new DataTable("RQSTDT");
                    paramTable8.Columns.Add("PLT_CODE", typeof(String));
                    paramTable8.Columns.Add("S_DATE", typeof(String));
                    paramTable8.Columns.Add("E_DATE", typeof(String));


                    DataRow paramRow8 = paramTable8.NewRow();
                    paramRow8["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow8["S_DATE"] = layoutRow8["S_DATE"];
                    paramRow8["E_DATE"] = layoutRow8["E_DATE"];

                    paramTable8.Rows.Add(paramRow8);
                    DataSet paramSet8 = new DataSet();
                    paramSet8.Tables.Add(paramTable8);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP05A_SER8", paramSet8, "RQSTDT", "RSLTDT, RSLTDT2",
                       QuickSearch8,
                       QuickException);

                    break;

                case "INS":

                    DataRow layoutRow7 = acLayoutControl7.CreateParameterRow();

                    DataTable paramTable7 = new DataTable("RQSTDT");
                    paramTable7.Columns.Add("PLT_CODE", typeof(String));
                    paramTable7.Columns.Add("YEAR", typeof(String));


                    DataRow paramRow7 = paramTable7.NewRow();
                    paramRow7["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow7["YEAR"] = layoutRow7["YEAR"];

                    paramTable7.Rows.Add(paramRow7);
                    DataSet paramSet7 = new DataSet();
                    paramSet7.Tables.Add(paramTable7);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "REP05A_SER6", paramSet7, "RQSTDT", "RSLTDT, RSLTDT2",
                       QuickSearch7,
                       QuickException);

                    break;

                case "MC":

                    switch (acTabControl3.GetSelectedContainerName())
                    {
                        case "MC":

                            DataRow layoutRow3 = acLayoutControl3.CreateParameterRow();

                            DataTable paramTable3 = new DataTable("RQSTDT");
                            paramTable3.Columns.Add("PLT_CODE", typeof(String));
                            paramTable3.Columns.Add("S_WORK_DATE", typeof(String));
                            paramTable3.Columns.Add("E_WORK_DATE", typeof(String));
                            paramTable3.Columns.Add("MC_GROUPS", typeof(String));

                            DataRow paramRow3 = paramTable3.NewRow();
                            paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow3["S_WORK_DATE"] = layoutRow3["S_DATE"];
                            paramRow3["E_WORK_DATE"] = layoutRow3["E_DATE"];
                            paramRow3["MC_GROUPS"] = layoutRow3["MC_GROUP"];

                            paramTable3.Rows.Add(paramRow3);
                            DataSet paramSet3 = new DataSet();
                            paramSet3.Tables.Add(paramTable3);

                            BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP05A_SER3", paramSet3, "RQSTDT", "RSLTDT",
                            DaySearchCallBack,
                            QuickException);
                            
                            break;

                        case "GROUP":
                            DataRow layoutRow5 = acLayoutControl5.CreateParameterRow();

                            DataTable paramTable5 = new DataTable("RQSTDT");
                            paramTable5.Columns.Add("PLT_CODE", typeof(String));
                            paramTable5.Columns.Add("S_WORK_DATE", typeof(String));
                            paramTable5.Columns.Add("E_WORK_DATE", typeof(String));

                            DataRow paramRow5 = paramTable5.NewRow();
                            paramRow5["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow5["S_WORK_DATE"] = layoutRow5["S_DATE"];
                            paramRow5["E_WORK_DATE"] = layoutRow5["E_DATE"];

                            paramTable5.Rows.Add(paramRow5);
                            DataSet paramSet5 = new DataSet();
                            paramSet5.Tables.Add(paramTable5);

                            BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.LOAD, "REP05A_SER3_2", paramSet5, "RQSTDT", "RSLTDT",
                            DaySearchCallBack2,
                            QuickException);
                            break;
                    }
                    

                    break;

                case "LT":

                    DataRow layoutRow4 = acLayoutControl4.CreateParameterRow();

                    DataTable paramTable4 = new DataTable("RQSTDT");
                    paramTable4.Columns.Add("PLT_CODE", typeof(String));
                    paramTable4.Columns.Add("YEAR", typeof(String));

                    DataRow paramRow4 = paramTable4.NewRow();
                    paramRow4["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow4["YEAR"] = layoutRow4["YEAR"];

                    paramTable4.Rows.Add(paramRow4);
                    DataSet paramSet4 = new DataSet();
                    paramSet4.Tables.Add(paramTable4);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD, "REP05A_SER4", paramSet4, "RQSTDT", "RSLTDT",
                    QuickLTSearch,
                    QuickException);

                    break;
            }

        }

        void QuickSearch3(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT"];
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
                acChartControl1.ClearSeries();
                acChartControl1.ClearSeriesPoint();

                acChartControl1.chartControl.PaletteName = "Metro";//Metro

                acChartControl1.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl1.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl1.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl1.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["TYPE"].ToString() != "New"
                        && row["TYPE"].ToString() != "Repeat")
                    {
                        continue;
                    }

                    if (!acChartControl1.SeriesDic.ContainsKey(row["TYPE"].ToString()))
                    {
                        acChartControl1.AddLineSeries(row["TYPE"].ToString()
                                , row["TYPE"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl1.SeriesDic[row["TYPE"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl1.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12_D"].toDouble() });
                        acChartControl1.AddSeriesPoint(row["TYPE"].ToString(), sp12);

                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void DaySearchCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acGridView3.Columns.Clear();

                acGridView3.ClearColumns();

                acGridView3.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                acChartControl2.ClearSeries();
                acChartControl2.ClearSeriesPoint();

                acChartControl2.chartControl.PaletteName = "Metro";//Metro

                acChartControl2.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl2.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl2.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl2.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}%";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }


                DateTime sDateTime = e.result.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"].toDateTime();
                DateTime eDateTime = e.result.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"].toDateTime();

                TimeSpan ts = eDateTime.Subtract(sDateTime);

                int days = ts.TotalDays.toInt() + 1;

                for (int i = 0; i < days; i++)
                {
                    string name = sDateTime.AddDays(i).toDateString("yyyyMMdd").Substring(4, 2) + " / " + sDateTime.AddDays(i).toDateString("yyyyMMdd").Substring(6, 2);

                    acGridView3.AddTextEdit(sDateTime.AddDays(i).toDateString("yyyyMMdd"), name, "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER100_2);

                    SeriesPoint srp = new SeriesPoint("[" + sDateTime.AddDays(i).toDateString("MM/dd") + "]", new double[] { 0 });

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        if (!acChartControl2.SeriesDic.ContainsKey(row["MC_NAME"].ToString()))
                        {
                            acChartControl2.AddLineSeries(row["MC_NAME"].ToString()
                            , row["MC_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                            Series series = acChartControl2.SeriesDic[row["MC_NAME"].ToString()];

                            LineSeriesView lsView = (LineSeriesView)series.View;

                            if (lsView != null)
                            {
                                //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                                lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                                //acChartControl2.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                            }
                            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                            PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                            psLabel.BackColor = Color.Transparent;
                            psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                            psLabel.Shadow.Visible = false;
                            //psLabel.TextColor = Color.DarkSlateGray;
                            psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                            psLabel.TextPattern = "{V:N0}%";
                            psLabel.Font = new Font("맑은 고딕", 10,
                                FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                        }

                        foreach (DataColumn col in e.result.Tables["RSLTDT"].Columns)
                        {
                            if (col.ColumnName == sDateTime.AddDays(i).toDateString("yyyyMMdd"))
                            {
                                srp = new SeriesPoint("[" + sDateTime.AddDays(i).toDateString("MM/dd") + "]", new double[] { row[col.ColumnName].toDouble() });
                                acChartControl2.AddSeriesPoint(row["MC_NAME"].ToString(), srp);

                                break;
                            }
                        }
                    }
                }


                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView3.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void DaySearchCallBack2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //acGridView5.Columns.Clear();

                acGridView5.ClearColumns();

                acGridView5.AddTextEdit("MC_GROUP", "설비그룹코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddTextEdit("MC_GROUP_NAME", "설비그룹", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                acChartControl4.ClearSeries();
                acChartControl4.ClearSeriesPoint();

                acChartControl4.chartControl.PaletteName = "Metro";//Metro

                acChartControl4.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl4.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl4.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl4.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}%";
                    diagram1.AxisX.Label.Visible = true;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }


                DateTime sDateTime = e.result.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"].toDateTime();
                DateTime eDateTime = e.result.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"].toDateTime();

                TimeSpan ts = eDateTime.Subtract(sDateTime);

                int days = ts.TotalDays.toInt() + 1;

                for (int i = 0; i < days; i++)
                {
                    string name = sDateTime.AddDays(i).toDateString("yyyyMMdd").Substring(4, 2) + " / " + sDateTime.AddDays(i).toDateString("yyyyMMdd").Substring(6, 2);

                    acGridView5.AddTextEdit(sDateTime.AddDays(i).toDateString("yyyyMMdd"), name, "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.PER100_2);

                    SeriesPoint srp = new SeriesPoint("[" + sDateTime.AddDays(i).toDateString("MM/dd") + "]", new double[] { 0 });

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        if (!acChartControl4.SeriesDic.ContainsKey(row["MC_GROUP_NAME"].ToString()))
                        {
                            acChartControl4.AddLineSeries(row["MC_GROUP_NAME"].ToString()
                            , row["MC_GROUP_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                            Series series = acChartControl4.SeriesDic[row["MC_GROUP_NAME"].ToString()];

                            LineSeriesView lsView = (LineSeriesView)series.View;

                            if (lsView != null)
                            {
                                //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                                lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                                //acChartControl4.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                            }
                            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                            PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                            psLabel.BackColor = Color.Transparent;
                            psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                            psLabel.Shadow.Visible = false;
                            //psLabel.TextColor = Color.DarkSlateGray;
                            psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                            psLabel.TextPattern = "{V:N0}%";
                            psLabel.Font = new Font("맑은 고딕", 10,
                                FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);
                        }

                        foreach (DataColumn col in e.result.Tables["RSLTDT"].Columns)
                        {
                            if (col.ColumnName == sDateTime.AddDays(i).toDateString("yyyyMMdd"))
                            {
                                srp = new SeriesPoint("[" + sDateTime.AddDays(i).toDateString("MM/dd") + "]", new double[] { row[col.ColumnName].toDouble() });
                                acChartControl4.AddSeriesPoint(row["MC_GROUP_NAME"].ToString(), srp);

                                break;
                            }
                        }
                    }
                }


                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView5.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickLTSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl3.ClearSeries();
                acChartControl3.ClearSeriesPoint();

                acChartControl3.chartControl.PaletteName = "Metro";//Metro

                acChartControl3.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl3.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl3.chartControl.Legend.Direction = LegendDirection.LeftToRight;
                acChartControl3.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                //차트 설정
                XYDiagram diagram1 = acChartControl3.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N1}일";
                    diagram1.AxisX.Label.Visible = false;
                    //diagram1.AxisX.Label.Angle = -30;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["CVND_CODE"].ToString() != "AVG")
                    {
                        continue;
                    }

                    if (!acChartControl3.SeriesDic.ContainsKey(row["CVND_NAME"].ToString()))
                    {
                        acChartControl3.AddLineSeries(row["CVND_NAME"].ToString()
                                , row["CVND_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Bar);

                        Series series = acChartControl3.SeriesDic[row["CVND_NAME"].ToString()];

                        //LineSeriesView lsView = (LineSeriesView)series.View;
                        BarSeriesView lsView = (BarSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            //lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl3.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        //PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        //psLabel.BackColor = Color.Transparent;
                        //psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        //psLabel.Shadow.Visible = false;
                        ////psLabel.TextColor = Color.DarkSlateGray;
                        //psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        //psLabel.TextPattern = "{V:N1}일";
                        //psLabel.Font = new Font("맑은 고딕", 10,
                        //FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        BarSeriesLabel bsLabel = (BarSeriesLabel)series.Label;
                        //bsLabel.BackColor = Color.Transparent;
                        bsLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        bsLabel.Shadow.Visible = false;
                        bsLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        bsLabel.TextPattern = "{V:N1}일";
                        bsLabel.Font = new Font("맑은 고딕", 10,
                        FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        foreach (Series s in acChartControl3.SeriesDic.Values)
                        {
                            SideBySideBarSeriesView view = s.View as SideBySideBarSeriesView;
                            if (view == null) continue;
                            view.FillStyle.FillMode = FillMode.Solid;
                            view.Color = Color.LightGreen;
                        }

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12_D"].toDouble() });
                        acChartControl3.AddSeriesPoint(row["CVND_NAME"].ToString(), sp12);

                    }
                }

                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView4.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch6(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl5.ClearSeries();
                acChartControl5.ClearSeriesPoint();

                acChartControl5.chartControl.PaletteName = "Metro";//Metro

                acChartControl5.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl5.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl5.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl5.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}";
                    diagram1.AxisX.Label.Visible = true;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (row["TYPE_NAME"].ToString() == "차이") continue;

                    if (!acChartControl5.SeriesDic.ContainsKey(row["TYPE_NAME"].ToString()))
                    {
                        acChartControl5.AddLineSeries(row["TYPE_NAME"].ToString()
                                , row["TYPE_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl5.SeriesDic[row["TYPE_NAME"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl5.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl5.AddSeriesPoint(row["TYPE_NAME"].ToString(), sp12);

                    }
                }

                acGridView7.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView8.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT2"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch7(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acChartControl6.ClearSeries();
                acChartControl6.ClearSeriesPoint();

                acChartControl6.chartControl.PaletteName = "Metro";//Metro

                acChartControl6.chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                acChartControl6.chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                acChartControl6.chartControl.Legend.Direction = LegendDirection.LeftToRight;

                //차트 설정
                XYDiagram diagram1 = acChartControl6.chartControl.Diagram as XYDiagram;
                if (diagram1 != null)
                {
                    diagram1.AxisY.Label.TextPattern = "{V:N0}";
                    diagram1.AxisX.Label.Visible = true;
                    diagram1.AxisY.Interlaced = true;
                    diagram1.AxisY.GridLines.Color = ColorTranslator.FromHtml("#8E8E8E"); //Color.WhiteSmoke;
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    if (!acChartControl6.SeriesDic.ContainsKey(row["INS_NAME"].ToString()))
                    {
                        acChartControl6.AddLineSeries(row["INS_NAME"].ToString()
                                , row["INS_NAME"].ToString(), "", false, acChartControl.SeriesPointType.NUMBER, DevExpress.XtraCharts.ViewType.Line);

                        Series series = acChartControl6.SeriesDic[row["INS_NAME"].ToString()];

                        LineSeriesView lsView = (LineSeriesView)series.View;

                        if (lsView != null)
                        {
                            //lsView.LineMarkerOptions.Kind = MarkerKind.Circle;
                            lsView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                            //acChartControl6.chartControl.Series[2].CrosshairLabelPattern = "{S} : {V:F3}";
                        }
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        PointSeriesLabel psLabel = (PointSeriesLabel)series.Label;
                        psLabel.BackColor = Color.Transparent;
                        psLabel.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                        psLabel.Shadow.Visible = false;
                        //psLabel.TextColor = Color.DarkSlateGray;
                        psLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                        psLabel.TextPattern = "{V:N0}";
                        psLabel.Font = new Font("맑은 고딕", 10,
                            FontStyle.Bold, DevExpress.Utils.AppearanceObject.DefaultFont.Unit);

                        SeriesPoint sp = new SeriesPoint("[1월]", new double[] { row["WORK_1"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp);

                        SeriesPoint sp2 = new SeriesPoint("[2월]", new double[] { row["WORK_2"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp2);

                        SeriesPoint sp3 = new SeriesPoint("[3월]", new double[] { row["WORK_3"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp3);

                        SeriesPoint sp4 = new SeriesPoint("[4월]", new double[] { row["WORK_4"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp4);

                        SeriesPoint sp5 = new SeriesPoint("[5월]", new double[] { row["WORK_5"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp5);

                        SeriesPoint sp6 = new SeriesPoint("[6월]", new double[] { row["WORK_6"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp6);

                        SeriesPoint sp7 = new SeriesPoint("[7월]", new double[] { row["WORK_7"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp7);

                        SeriesPoint sp8 = new SeriesPoint("[8월]", new double[] { row["WORK_8"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp8);

                        SeriesPoint sp9 = new SeriesPoint("[9월]", new double[] { row["WORK_9"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp9);

                        SeriesPoint sp10 = new SeriesPoint("[10월]", new double[] { row["WORK_10"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp10);

                        SeriesPoint sp11 = new SeriesPoint("[11월]", new double[] { row["WORK_11"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp11);

                        SeriesPoint sp12 = new SeriesPoint("[12월]", new double[] { row["WORK_12"].toDouble() });
                        acChartControl6.AddSeriesPoint(row["INS_NAME"].ToString(), sp12);

                    }
                }

                acGridView9.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView10.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT2"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch8(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView11.ClearColumns();
                acGridView11.AddTextEdit("TYPE1", "공정 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView11.AddTextEdit("TYPE2", "타입", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView11.AddTextEdit("TYPE3", "  ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView12.ClearColumns();
                acGridView12.AddTextEdit("TYPE1", "공정 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView12.AddTextEdit("TYPE2", "타입", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView12.AddTextEdit("TYPE3", "  ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                DateTime sDate = e.result.Tables["RQSTDT"].Rows[0]["S_DATE"].toDateTime();
                DateTime eDate = e.result.Tables["RQSTDT"].Rows[0]["E_DATE"].toDateTime();

                for (DateTime date = sDate; date <= eDate; date = date.AddDays(1))
                {
                    acGridView11.AddTextEdit(date.ToString("yyyyMMdd"), date.ToString("yy-MM-dd"), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                    acGridView12.AddTextEdit(date.ToString("yyyyMMdd"), date.ToString("yy-MM-dd"), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                }

                acGridView11.Columns["TYPE1"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                acGridView11.Columns["TYPE2"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                acGridView11.CellMerge -= acGridView11_CellMerge;
                acGridView11.CellMerge += acGridView11_CellMerge;

                acGridView11.GridControl.DataSource = e.result.Tables["RSLTDT"];

                

                acGridView11.BestFitColumns();


                acGridView12.Columns["TYPE1"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                acGridView12.Columns["TYPE2"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                acGridView12.CellMerge -= acGridView12_CellMerge;
                acGridView12.CellMerge += acGridView12_CellMerge;

                acGridView12.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                acGridView12.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch9(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView13.GridControl.DataSource = e.result.Tables["RSLTDT"];

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
    }
}