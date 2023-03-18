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
    public sealed partial class acItemForm : BaseMenuDialog
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

        public acItem.emMethodType ExecuteMethodType { get; set; }

        public acItemForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddLookUpEdit("ORD_STATE", "수주상태", "40841", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S026");

            acGridView1.AddTextEdit("ITEM_CODE", "수주코드", "40377", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("ITEM_NAME", "수주명", "41906", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_NAME", "수주처명", "42428", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("ITEM_FLAG", "수주종류", "KIKFGICD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C023");

            acGridView1.AddDateEdit("ORD_DATE", "수주일", "40902", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);


            acGridView1.AddTextEdit("BUSINESS_EMP", "영업담당자코드", "ZGBOI8X8", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("BUSINESS_EMP_NAME", "영업담당자명", "IKXJXBCK", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("PROD_CNT", "금형수", "Z4S4ERDO", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);


            acCheckedComboBoxEdit1.AddItem("수주일", true, "40902", "ORD_DATE", true, false);


            acDateEdit1.DateTime = acDateEdit.GetNowFirstDate();
            acDateEdit2.DateTime = acDateEdit.GetNowLastDate();



            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

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

                acItem ctrl = (acItem)base.ParentControl;

                layout.GetEditor("DATE").Value = string.Empty;
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();


                if (this.ExecuteMethodType == acItem.emMethodType.FIND)
                {
                    //조건저장 복원

                    if (ctrl._ConditionStorage != null)
                    {
                        layout.SetData(ctrl._ConditionStorage.Tables[0].Rows[0]);

                    }

                }
                else if (this.ExecuteMethodType == acItem.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("ITEM_LIKE").Value = this.Parameter;


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

            //포커스
            acLayoutControl1.GetEditor("ITEM_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acItem.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_ITEM_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }
            else if (this.ExecuteMethodType == acItem.emMethodType.QUICK_FIND)
            {
                this.Search();
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

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");



            paramTable.Columns.Add("PLT_CODE", typeof(String));

            paramTable.Columns.Add("CVND_CODE", typeof(String)); 
            paramTable.Columns.Add("PRJ_CODE", typeof(String)); 

            paramTable.Columns.Add("PROD_LIKE", typeof(String)); 
            paramTable.Columns.Add("ITEM_LIKE", typeof(String)); 

            paramTable.Columns.Add("S_ORD_DATE", typeof(String));
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); 

            paramTable.Columns.Add("DATA_FLAG", typeof(byte));

            DataRow paramRow = paramTable.NewRow();


            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramRow["CVND_CODE"] = layoutRow["CVND_CODE"];
            paramRow["PRJ_CODE"] = layoutRow["PRJ_CODE"];

            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["ITEM_LIKE"] = layoutRow["ITEM_LIKE"];
            
            paramRow["DATA_FLAG"] = 0;


            List<string> checkedKeys = acCheckedComboBoxEdit1.GetKeyChecked();


            foreach (string key in checkedKeys)
            {
                switch (key)
                {
                    case "ORD_DATE":


                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }



            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_ITEM_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);


        }


        protected override void OnClosing(CancelEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            (base.ParentControl as acItem)._ConditionStorage = layoutRow.Table.NewDataSet();

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