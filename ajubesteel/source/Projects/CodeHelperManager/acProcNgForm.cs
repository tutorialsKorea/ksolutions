using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acProcNgForm : BaseMenuDialog
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

        public acProcNg.emMethodType ExecuteMethodType { get; set; }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();


        public acProcNgForm()
        {
            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("NG_ID", "불량번호", "16SQP5J9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("WORK_DATE", "불량발생일", "F1HO50M4", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("NG_STATE", "불량상태", "587SOBFY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q003");

            acGridView1.AddLookUpEdit("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C400");

            acGridView1.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C401");

            acGridView1.AddTextEdit("QUANTITY", "불량수량", "UGW32N5B", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddLookUpEdit("NG_TYPE", "불량형태", "C1VMAHMU", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q004");

            acGridView1.AddMemoEdit("NG_CONTENTS", "불량내용", "IGBK9DTD", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView1.AddMemoEdit("NG_CAUSE", "불량원인", "J0Q7135N", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView1.AddMemoEdit("NG_MEASURE", "불량대책", "30PLWWE1", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            acGridView1.AddDateEdit("NG_MEASURE_DATE", "불량대책일", "H3COOO13", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("NG_MEASURE_EMP", "불량대책완료자코드", "AFKOXLUA", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("NG_MEASURE_EMP_NAME", "불량대책완료자명", "O79POXF6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "작업자명", "40545", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acCheckedComboBoxEdit1.AddItem("불량발생일", true, "F1HO50M4", "WORK_DATE", true, false);



            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


        }

        public override void DialogInit()
        {


            base.DialogInit();
        }

        protected override void OnShown(EventArgs e)
        {


            base.OnShown(e);
            
            
            //포커스
            acLayoutControl1.GetEditor("NG_ID").FocusEdit();


            if (this.ExecuteMethodType == acProcNg.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PROC_NG_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acProcNg.emMethodType.QUICK_FIND)
            {
                this.Search();
            }

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

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                if (base.ParentControl is acProcNg)
                {

                    acProcNg ctrl = (acProcNg)base.ParentControl;

                    if (this.ExecuteMethodType == acProcNg.emMethodType.FIND)
                    {
                        layout.GetEditor("DATE").Value = "WORK_DATE";
                        layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                        layout.GetEditor("E_DATE").Value = DateTime.Now;

                    }
                    else if (this.ExecuteMethodType == acProcNg.emMethodType.QUICK_FIND)
                    {
                        //코드 검색부분에 입력후 조회

                        layout.GetEditor("NG_ID").Value = this.Parameter;


                    }


                }

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


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }


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



        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }



            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("S_WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("E_WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("NG_STATE", typeof(String));
            paramTable.Columns.Add("NG_TYPE", typeof(String));


            //부모 파라메터 컬럼 생성

            if (base.ParentControl is acProcNg)
            {

                acProcNg ctrl = (acProcNg)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }

            //창 파라메터 컬럼 생성

            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }







            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];



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


            //부모 파라메터 입력

            if (base.ParentControl is acProcNg)
            {

                acProcNg ctrl = (acProcNg)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }

            }

            //창 파라메터 입력
            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }
            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CONTROL_PROC_NG_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //검색
            try
            {
                Search();
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