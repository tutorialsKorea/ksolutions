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
    public sealed partial class acSimulationForm : BaseMenuDialog
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

        public acSimulationForm()
        {
            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("SMLT_ID", "시뮬레이션 ID", "GXBNS93J", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("BOP_REF_TYPE", "BOP 참조형태", "PUYV3ONT", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S083");

            acGridView1.AddTextEdit("BOP_REF_CODE", "BOP 참조코드", "ZJ2GYZDX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddMemoEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, true , false);

            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);




            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);




        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

                case "BOP_REF_TYPE":

                    if (newValue.EqualsEx("PROD"))
                    {
                        

                        acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                        layout.GetEditor("PROD_CODE").Editor.Enabled = true;
                        layout.GetEditor("STDBOP_CODE").Editor.Enabled = false;

                    }
                    if (newValue.EqualsEx("PSTDBOP"))
                    {
                        

                        acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                        layout.GetEditor("PROD_CODE").Editor.Enabled = true;
                        layout.GetEditor("STDBOP_CODE").Editor.Enabled = false;

                    }
                    else if (newValue.EqualsEx("STDBOP"))
                    {
                        

                        acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        acLayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                        layout.GetEditor("STDBOP_CODE").Editor.Enabled = true;
                        layout.GetEditor("PROD_CODE").Editor.Enabled = false;
                    }

                    break;

            }

        }


        public override void DialogInit()
        {
            acCheckedComboBoxEdit1.AddItem("등록일", true, "CZP2OQ22", "REG_DATE", true, false, CheckState.Unchecked);

            acRadioComboBoxEdit1.RadioGroup.AddRadioItem("금형", true, "40086", false, string.Empty, "PROD");
            acRadioComboBoxEdit1.RadioGroup.AddRadioItem("표준 BOP", true, "42628", false, string.Empty, "STDBOP");


            acLayoutControl1.GetEditor("S_DATE").Value = System.DateTime.Now.AddDays(-7);
            acLayoutControl1.GetEditor("E_DATE").Value = System.DateTime.Now;

            acLayoutControl1.GetEditor("DATE").Value = "REG_DATE";

            acLayoutControl1.GetEditor("BOP_REF_TYPE").Value = "PROD";


            base.DialogInit();
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
            paramTable.Columns.Add("SMLT_ID", typeof(String)); //
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(DateTime)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(DateTime)); //
            paramTable.Columns.Add("BOP_REF_CODE", typeof(String)); //
            paramTable.Columns.Add("BOP_REF_TYPE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["SMLT_ID"] = null;
            paramRow["DATA_FLAG"] = 0;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;

                }

                break;
            }

            paramRow["BOP_REF_TYPE"] = layoutRow["BOP_REF_TYPE"];


            if (paramRow["BOP_REF_TYPE"].EqualsEx("PROD"))
            {
                paramRow["BOP_REF_CODE"] = layoutRow["PROD_CODE"];

            }
            else if (paramRow["BOP_REF_TYPE"].EqualsEx("STDBOP"))
            {
                paramRow["BOP_REF_CODE"] = layoutRow["STDBOP_CODE"];

            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CONTROL_SIMULATION_SEARCH", paramSet, "RQSTDT", "RSLTDT",
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