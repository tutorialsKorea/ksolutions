using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using BizManager;

namespace SYS
{
    public sealed partial class SYS09A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }



        public SYS09A_M0A()
        {
            InitializeComponent();


        }


        public override void MenuInit()
        {


            acGridView1.GridType = acGridView.emGridType.SEARCH;


            acGridView1.AddDateEdit("REG_DATE", "등록시간", "DN16C5HE", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("SYSTEM_VERSION", "시스템 버전", "GKY0J48T", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CLASS_NAME", "클래스", "7BHPEKNS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("REG_EMP", "등록자코드", "W91VQNT4", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "등록자명", "0JEUXGE6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acCheckedComboBoxEdit1.AddItem("등록시간", true, "DN16C5HE", "REG_DATE", true, false);


            acGridView1.OptionsDetail.ShowDetailTabs = false;



            acGridView acGridView1detail = new acGridView(acGridView1.GridControl);

            acGridView1detail.GridType = acGridView.emGridType.FIXED;


            acGridView1detail.AddMemoEdit("ERR_MESSAGE", "오류 메시지", "5CRYBGZD", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, true, true, false);

            acGridView1detail.AddMemoEdit("COMMENT", "의견", "WQJN4NQ0", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

            //acGridView1detail.OptionsView.ShowColumnHeaders = false;

            acGridView1.GridControl.LevelTree.Nodes.Add("M", acGridView1detail);


            acGridView1detail.GotFocus += new EventHandler(acGridView1detail_GotFocus);


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);


            base.MenuInit();
        }

        void acGridView1detail_GotFocus(object sender, EventArgs e)
        {
            GridView childView = sender as GridView;

            GridView masterView = childView.ParentView as GridView;

            if (masterView.FocusedRowHandle != childView.SourceRowHandle)
            {
                masterView.FocusedRowHandle = childView.SourceRowHandle;
            }
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

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }



            base.ChildContainerInit(sender);
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
            paramTable.Columns.Add("S_REG_DATE", typeof(DateTime)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(DateTime)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (checkedKey)
                {

                    case "REG_DATE":

                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];


                        break;

                }

            }


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS09A_SER", paramSet, "RQSTDT", "RSLTDT",
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


                DataTable titleDt = e.result.Tables["RSLTDT"].Copy();
                DataTable contentsDt = e.result.Tables["RSLTDT"].Copy();

                contentsDt.TableName = "D";

                DataSet data = new DataSet();

                data.Tables.Add(titleDt);
                data.Tables.Add(contentsDt);

                DataColumn keyColumn = titleDt.Columns["UID"];
                DataColumn foreignKeyColumn = contentsDt.Columns["UID"];

                data.Relations.Add("M", keyColumn, foreignKeyColumn);

                acGridView1.GridControl.DataSource = data.Tables[0];

                acGridView1.SetOldFocusRowHandle(false);



                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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






    }
}
