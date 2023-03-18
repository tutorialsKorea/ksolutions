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
    public sealed partial class acStdBopForm : BaseMenuDialog
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

        public acStdBop.emMethodType ExecuteMethodType { get; set; }

        public acStdBopForm()
        {
            InitializeComponent();


            acGridView1.GridType = acGridView.emGridType.SEARCH;



            acGridView1.AddTextEdit("PROD_NAME", "표준BOP명", "42631", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PRJ_CODE", "모델코드", "40171", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PRJ_NAME", "모델명", "40175", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("LOCK_ID", "공정잠금 사용자코드", "MARXHIP1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("LOCK_NAME", "공정잠금 사용자명", "YXBDAIG5", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);




            acGridView1.KeyColumn = new string[] { "PROD_CODE" };



            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);


            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                if (this.ExecuteMethodType == acStdBop.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("PROD_LIKE").Value = this.Parameter;


                }


            }

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();

        }

        void GetDetail()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                pictureEdit1.Image = focusRow["THUMBNAIL"].toImage();

            }
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //포커스
            acLayoutControl1.GetEditor("PROD_LIKE").FocusEdit();


            if (this.ExecuteMethodType == acStdBop.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_STDBOP_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acStdBop.emMethodType.QUICK_FIND)
            {
                this.Search();
            }
        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PRJ_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = null;
            paramRow["PRJ_CODE"] = layoutRow["PRJ_CODE"];
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "CONTROL_STDBOP_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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