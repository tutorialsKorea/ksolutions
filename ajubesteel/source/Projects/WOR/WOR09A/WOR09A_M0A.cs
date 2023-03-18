using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace WOR
{
    public sealed partial class WOR09A_M0A : BaseMenu
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

        public WOR09A_M0A()
        {
            InitializeComponent();

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }

        public override void MenuInitComplete()
        {

            base.MenuInitComplete();
        }

        public override void MenuInit()
        {
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "��û���ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "��û��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_NAME", "���¸�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REQ_START_DATE", "���۽ð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("REQ_END_DATE", "����ð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("REQ_DATE", "��û�Ͻ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddLookUpEdit("REQ_STATUS", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddTextEdit("REQ_SCOMMENT", "��û����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APP_SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddLookUpEmp("APP_EMP1", "������1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("APP_EMP_FLAG1", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP2", "������2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("APP_EMP_FLAG2", "������2����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP3", "������3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("APP_EMP_FLAG3", "������3����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEmp("APP_EMP4", "������4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddTextEdit("APP_EMP_FLAG4", "������4����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddHidden("DIFF_STATE", typeof(string));
            acGridView1.KeyColumn = new string[] { "WORK_ID" };


            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddDateEdit("WORK_DATE", "�ٹ�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            //acGridView2.AddTextEdit("WORK_DATE", "�ٹ�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("ORG_NAME", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_CODE", "���ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "�̸�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_TITLE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddDateEdit("WORK_START_TIME", "��ٽð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            //acGridView2.AddTextEdit("WORK_START_TIME", "��ٽð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddDateEdit("WORK_END_TIME", "��ٽð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            //acGridView2.AddTextEdit("WORK_END_TIME", "��ٽð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("WORK_START_TYPE", "�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("WORK_END_TYPE", "�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("WORK_TIME", "�����ٹ��ð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("WORK_ID", typeof(string));

            acGridView2.KeyColumn = new string[] { "WORK_DATE", "EMP_CODE" };

            acCheckedComboBoxEdit1.AddItem("������", false, "", "WORK_DATE", true, false);

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            base.MenuInit();
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            acGridView view = sender as acGridView;

            //if (!(view.DataSource as DataView).Table.Columns.Contains("DIFF_STATE")) return;

            //string diff_state = view.GetRowCellValue(e.RowHandle, "DIFF_STATE").ToString();

            if(e.FocusedRowHandle > -1)
            {
                string emp_code = view.GetRowCellValue(e.FocusedRowHandle, "EMP_CODE").ToString();

                string work_date = view.GetRowCellValue(e.FocusedRowHandle, "REQ_START_DATE").toDateString("yyyyMMdd");


                DataRow selectRow = acGridView2.GetDataRow(string.Format("EMP_CODE = '{0}' AND WORK_DATE = '{1}'", emp_code, work_date.toDateTime()));
                //DataView selectView = acGridView2.GetDataView(string.Format("EMP_CODE = '{0}' AND WORK_DATE = '{1}'", emp_code, work_date));
                //acGridView2.GetDataRow()

                if(selectRow != null)
                    acGridView2.FocusMappingRow(selectRow);
            }

        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (!(view.DataSource as DataView).Table.Columns.Contains("DIFF_STATE")) return;

            string diff_state = view.GetRowCellValue(e.RowHandle, "DIFF_STATE").ToString();

            switch(diff_state)
            {
                case "1"://�ð��� Ʋ�����
                    e.Appearance.BackColor = Color.OrangeRed;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "2"://���� ������ ���°��
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "WORK_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer().AddDays(-6);
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowDateFromServer();
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //��¥�˻������� �����ϸ� ��¥��Ʈ���� �ʼ��� �ٲ۴�.

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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("S_WORK_DATE", typeof(String));
            paramTable.Columns.Add("E_WORK_DATE", typeof(String));
            paramTable.Columns.Add("S_REQ_DATE", typeof(String));
            paramTable.Columns.Add("E_REQ_DATE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "WORK_DATE":
                        paramRow["S_WORK_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_WORK_DATE"] = layoutRow["E_DATE"];

                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR09A_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if(!e.result.Tables["RSLTDT"].Columns.Contains("DIFF_STATE"))
                    e.result.Tables["RSLTDT"].Columns.Add("DIFF_STATE", typeof(string));

                if (!e.result.Tables["RSLTDT2"].Columns.Contains("WORK_ID"))
                    e.result.Tables["RSLTDT2"].Columns.Add("WORK_ID", typeof(string));


                foreach (DataRow row in e.result.Tables["RSLTDT"].Select("WORK_CODE = 'W08'"))
                {
                    string diff_state = "0";

                    string emp_code = row["EMP_CODE"].ToString();

                    string work_date = row["REQ_START_DATE"].toDateString("yyyyMMdd");

                    DataRow[] serRow = e.result.Tables["RSLTDT2"].Select(string.Format("EMP_CODE = '{0}' AND WORK_DATE = '{1}'",emp_code, work_date));

                    if (serRow.Length == 0)
                        diff_state = "2";
                    else
                    {
                        foreach(DataRow workRow in serRow)
                        {
                            if(workRow["WORK_END_TIME"].toDateTime() < row["REQ_END_DATE"].toDateTime())
                                diff_state = "1";

                            workRow["WORK_ID"] = row["WORK_ID"];
                        }
                    }

                    row["DIFF_STATE"] = diff_state;
                }



                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT2"];
                acGridView2.BestFitColumns();

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

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                WOR09A_D0A frm = new WOR09A_D0A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //this.Search();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

