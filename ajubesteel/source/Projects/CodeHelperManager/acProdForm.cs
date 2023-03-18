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
using System.Runtime.InteropServices;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acProdForm : BaseMenuDialog
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



        public acProd.emMethodType ExecuteMethodType { get; set; }


        public acProdForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;
            
            acGridView1.AddTextEdit("PROD_CODE", "제품코드", "40900", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MODEL", "제품명", "40901", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART", "분류", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_VND", "고객사", "1WZQHKCW", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_VND_NAME", "고객사", "1WZQHKCW", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MAT_CODE", "원자재코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_NAME", "원자재명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("PROD_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
            acGridView1.AddLookUpEdit("PROD_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
            acGridView1.AddLookUpEdit("PROD_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M008");

            acGridView1.AddTextEdit("MOLD_NO", "차수", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("CAVITY", "CAVITY", "40848", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("TO_DATE", "TO_DATE", "3SJ93J4H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask);

            acGridView1.AddDateEdit("TO_DATE", "TO_DATE", "3SJ93J4H", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PACK_UNIT", "포장단위", "Z8OA566Z", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("UNIT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            
            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(layoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);



        }


        /// <summary>
        /// 입력 파라메터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();

        public override void DialogInit()
        {
            acProd edit = this.ParentControl as acProd;
            //금형구분
            //(acLayoutControl1.GetEditor("PROD_CATEGORY").Editor as acLookupEdit).SetCode("C011");

            ////금형 대분류
            //(acLayoutControl1.GetEditor("PROD_KIND").Editor as acLookupEdit).SetCode("C001");

            cmbCVND.Value = edit.CvndCode;

            if (edit.CvndCode != null)
            {
                Search();
            }
            
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        protected override void OnShown(EventArgs e)
        {


            base.OnShown(e);
            
            //포커스
            acLayoutControl1.GetEditor("PROD_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acProd.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PROD_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
     
            }
            else if (this.ExecuteMethodType == acProd.emMethodType.QUICK_FIND)
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


        void layoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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


                //제품 대분류
                case "PROD_KIND":

                    //제품 중분류 설정

                    cmbMtype.SetCode("C002", newValue);

                    break;


                //제품 중분류 
                case "PROD_TYPE1":

                    //제품 소분류 설정

                    cmbStype.SetCode("C012", newValue);

                    break;

            }

        }





        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;


                if (base.ParentControl is acProd)
                {

                    acProd ctrl = (acProd)base.ParentControl;



                    if (this.ExecuteMethodType == acProd.emMethodType.FIND)
                    {
                        //조건저장 복원

                        if (ctrl._ConditionStorage != null)
                        {
                            layout.SetData(ctrl._ConditionStorage.Tables[0].Rows[0]);

                        }

                    }
                    else if (this.ExecuteMethodType == acProd.emMethodType.QUICK_FIND)
                    {
                        //코드 검색부분에 입력후 조회

                        layout.GetEditor("PROD_LIKE").Value = this.Parameter;

                    }

                }


            }


            base.ChildContainerInit(sender);
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


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE", typeof(String)); //플랜트 코드

            paramTable.Columns.Add("PROD_CODE", typeof(String)); //수주처
            paramTable.Columns.Add("PROD_VND", typeof(String)); //모델
            paramTable.Columns.Add("MODEL", typeof(String)); //수주코드
            paramTable.Columns.Add("MAT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LTYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_MTYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_STYPE", typeof(String)); //

            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //PROD_CODE, NAME LIKE 검색

            
            //부모 파라메터 컬럼 생성

            if (base.ParentControl is acProd)
            {

                acProd ctrl = (acProd)base.ParentControl;

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

            //paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            paramRow["PROD_VND"] = layoutRow["PROD_VND"];
            //paramRow["MODEL"] = layoutRow["MODEL"];

            //paramRow["MAT_CODE"] = layoutRow["MAT_CODE"];
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["PROD_LTYPE"] = layoutRow["PROD_LTYPE"];
            paramRow["PROD_MTYPE"] = layoutRow["PROD_MTYPE"];
            paramRow["PROD_STYPE"] = layoutRow["PROD_STYPE"];
            
            //부모 파라메터 입력

            if (base.ParentControl is acProd)
            {

                acProd ctrl = (acProd)base.ParentControl;

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


       
            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_PROD_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (base.ParentControl is acProd)
            {
                (base.ParentControl as acProd)._ConditionStorage = layoutRow.Table.NewDataSet();
            }

            base.OnClosing(e);
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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
            this.Search();
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