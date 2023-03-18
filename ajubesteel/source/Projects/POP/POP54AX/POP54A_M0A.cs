using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Linq;
using BizManager;

namespace POP
{
    public sealed partial class POP54A_M0A : BaseMenu
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
        public POP54A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
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


            gridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("MC_NAME", "설비명", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gridView1.AddLookUpEdit("PANEL_STAT", "구분", "41587", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S036");

            gridView1.AddLookUpEdit("MC_NM_CHECK", "유/무인", "NVJLZWWQ", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "S033");

            gridView1.AddDateEdit("EVENT_DATE", "입력시간", "UAS0U7A5", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            gridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PT_NAME", "부품명", "40234", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PART_NUM", "품번", "40743", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("EMP_CODE", "작업자코드", "40551", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("EMP_NAME", "작업자명", "40545", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gridView1.AddTextEdit("IDLE_CODE", "비가동 사유코드", "50238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("IDLE_NAME", "비가동 사유", "42437", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gridView1.AddTextEdit("IDLE_TIME", "비가동 시간", "41150", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            gridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            gridView1.Columns["MC_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gridView1.Columns["MC_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            acCheckedComboBoxEdit1.AddItem("입력일", true, "BFCLW38D", "INPUT_DATE", true, false);


            base.MenuInit();
        }


        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "INPUT_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }


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

        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장
            paramTable.Columns.Add("MC_CODE", typeof(String)); //설비코드
            paramTable.Columns.Add("START_DATE", typeof(DateTime)); //
            paramTable.Columns.Add("END_DATE", typeof(DateTime)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = layoutRow["MC_CODE"];

            foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (checkedKey)
                {
                    case "INPUT_DATE":

                        paramRow["START_DATE"] = layoutRow["S_DATE"];
                        paramRow["END_DATE"] = layoutRow["E_DATE"];


                        break;
                }


            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);



            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD, "POP54A_SER", paramSet, "RQSTDT", "RSLTDT",
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


                var query = from c in e.result.Tables["RSLTDT"].AsEnumerable()
                            orderby c.Field<DateTime>("EVENT_DATE") ascending
                            select c;



                gridView1.GridControl.DataSource = query.AsDataView().ToTable();

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





    }
}
