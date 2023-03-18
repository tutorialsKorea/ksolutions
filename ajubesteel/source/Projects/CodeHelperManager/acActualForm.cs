using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acActualForm : BaseMenuDialog
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

        public acActual.emMethodType ExecuteMethodType { get; set; }

        public acActualForm()
        {
            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddLookUpEdit("ACT_TYPE", "실적구분", "YCIHDVOH", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S069");

            acGridView1.AddLookUpEdit("WO_TYPE", "작업지시 형태", "BPIJ8QTW", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S037");

            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40234", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEdit("INPUT_FLAG", "입력구분", "UYJGZO3N", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S039");

            acGridView1.AddDateEdit("WORK_DATE", "작업일", "40540", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "작업자코드", "40551", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "작업자", "40542", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            acGridView1.AddTextEdit("MAN_TIME", "유인 실적공수", "CLLN0WCV", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("OT_TIME", "잔업 실적공수", "70NF0OEU", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("SELF_TIME", "무인 실적공수", "DWNYLR5F", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("PAUSE_TIME", "작업중지시간", "42640", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("WORK_TIME", "실적공수", "40402", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);

            acGridView1.AddTextEdit("WORK_QTY", "작업수량", "42643", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("OK_QTY", "양품수량", "42644", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("NG_QTY", "불량수량", "UGW32N5B", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);



            acCheckedComboBoxEdit1.AddItem("작업일", true, "40540", "WORK_DATE", true, false);


            acDateEdit1.DateTime = DateTime.Now.AddDays(-3);
            acDateEdit2.DateTime = DateTime.Now;


     


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

   

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "WORK_DATE";

                acActual ctrl = (acActual)base.ParentControl;


                //조건저장 복원

                if (ctrl._ConditionStorage != null)
                {
                    acLayoutControl1.SetData(ctrl._ConditionStorage.Tables[0].Rows[0]);

                }

            }


            base.ChildContainerInit(sender);
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


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }



        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            if (this.ExecuteMethodType == acActual.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_ACTUAL_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }


        }

        void Search()
        {


            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //작업일 시작
            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //작업지 종료
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("ORG_CODE", typeof(String)); //



            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "WORK_DATE":

                        paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }

            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            paramRow["EMP_CODE"] = layoutRow["ACT_EMP_CODE"];
            paramRow["ORG_CODE"] = layoutRow["ACT_ORG_CODE"];



            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this,
                 QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_ACTUAL_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                 QuickSearch,
                 QuickException);


        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            (base.ParentControl as acActual)._ConditionStorage = layoutRow.Table.NewDataSet();
            
            base.OnClosing(e);
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


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}