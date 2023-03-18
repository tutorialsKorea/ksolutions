using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acEstForm : BaseMenuDialog
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

        public acEst.emMethodType ExecuteMethodType { get; set; }


        public acEstForm()
        {
            InitializeComponent();

            acGridView1.AddDateEdit("EST_DATE", "견적일", "42326", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("EST_NO", "견적번호", "42315", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EST_NAME", "견적명", "42327", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_NAME", "견적처", "R1NZ3256", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EST_AMT", "견적금액", "42328", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "EST_NO" };


            acDateEdit1.EditValue = DateTime.Now;

            acDateEdit2.EditValue = DateTime.Now.AddDays(10);


            acCheckedComboBoxEdit1.AddItem("견적일", true, "42326", "EST_DATE", true, false);


   
            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acLayoutControl1.OnValueChanged+=new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown+=new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


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
                acLayoutControl layout = acLayoutControl1 as acLayoutControl;

    
                if (this.ExecuteMethodType == acEst.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("EST_LIKE").Value = this.Parameter;


                }

            }

            base.ChildContainerInit(sender);
        }


        void acLayoutControl1_OnValueChanged(object sender , IBaseEditControl info, object newValue)
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
            acLayoutControl1.GetEditor("EST_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acEst.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_EST_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
   
            }
            else if (this.ExecuteMethodType == acEst.emMethodType.QUICK_FIND)
            {
                this.Search();
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
            paramTable.Columns.Add("CVND_CODE", typeof(String)); //견적처
            paramTable.Columns.Add("EST_LIKE", typeof(String));

            paramTable.Columns.Add("S_EST_DATE", typeof(String)); //견적일자 시작일자
            paramTable.Columns.Add("E_EST_DATE", typeof(String)); //견적일자 종료일자
            paramTable.Columns.Add("AVAIL_EST", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CVND_CODE"] = layoutRow["CVND_CODE"];
            paramRow["EST_LIKE"] = layoutRow["EST_LIKE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "EST_DATE":

                        paramRow["S_EST_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_EST_DATE"] = layoutRow["E_DATE"];

                        break;
                }

            }


            paramRow["AVAIL_EST"] = "1";
            paramRow["DATA_FLAG"] = 0;


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "CONTROL_EST_SEARCH", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
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


                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
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