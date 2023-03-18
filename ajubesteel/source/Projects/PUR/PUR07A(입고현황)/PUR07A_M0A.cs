using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;

using ControlManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using BizManager;
using DevExpress.Spreadsheet;

namespace PUR
{
    public sealed partial class PUR07A_M0A : BaseMenu
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


        public PUR07A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acTabControl1.SelectedPageChanged += AcTabControl1_SelectedPageChanged;
        }

        

        private string _selectedPage;

        

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            
            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddLookUpEdit("BAL_STAT", "���� ����", "", false, HorzAlignment.Center, false, true, false, "S043");
            acGridView1.AddLookUpEdit("BAL_TYPE", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            acGridView1.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BALJU_SEQ", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("CHECK_FLAG", "Ȯ��", "", false, false, false, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("CHECK_EMP", "Ȯ���� �ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHECK_EMP_NAME", "Ȯ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("CHECK_DATE", "Ȯ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("CHECK_DEL_EMP", "Ȯ������� �ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHECK_DEL_EMP_NAME", "Ȯ�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("CHECK_DEL_DATE", "Ȯ�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("PART_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME2", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("PART_PRODTYPE", "�з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView1.AddLookUpEdit("MAT_LTYPE", "��з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "�ߺз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView1.AddLookUpVendor("VEN_CODE", "����ó", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("BALJU_REG_EMP", "�������ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BALJU_REG_EMP_NAME", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("BALJU_DATE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("DUE_DATE", "�԰�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("YPGO_DATE", "�԰���", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("BALJU_SCOMMENT", "���� ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("YPGO_SCOMMENT", "�԰� ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BAL_QTY", "���ּ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("YPGO_QTY", "�԰����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("MAT_UNIT", "����", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView1.AddTextEdit("YPGO_COST", "�԰�ܰ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("AMT", "�԰�ݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddLookUpEdit("BAL_UNIT", "ȭ�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");
            acGridView1.AddLookUpEdit("YPGO_LOC", "����â��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView1.AddHidden("YPGO_ID", typeof(string));

            acGridView1.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

            acGridView2.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView2.AddLookUpEdit("BAL_STAT", "���� ����", "", false, HorzAlignment.Center, false, true, false, "S043");
            acGridView2.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BALJU_SEQ", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddCheckEdit("CHECK_FLAG", "Ȯ��", "", false, false, false, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("CHECK_EMP", "Ȯ���� �ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHECK_EMP_NAME", "Ȯ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("CHECK_DATE", "Ȯ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("CHECK_DEL_EMP", "Ȯ������� �ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHECK_DEL_EMP_NAME", "Ȯ�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("CHECK_DEL_DATE", "Ȯ�������", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddTextEdit("PROD_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("WO_NO", "�۾����ù�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME2", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddLookUpEdit("PART_PRODTYPE", "�з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView2.AddLookUpEdit("MAT_LTYPE", "��з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView2.AddLookUpEdit("MAT_MTYPE", "�ߺз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView2.AddLookUpVendor("VEN_CODE", "����ó", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView2.AddDateEdit("BALJU_DATE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("DUE_DATE", "�԰�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("INS_DATE", "�˻���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("YPGO_DATE", "�԰���", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("BALJU_SCOMMENT", "���� ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("YPGO_SCOMMENT", "�԰� ���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEmp("REG_EMP", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddLookUpEdit("INS_FLAG", "�˻翩��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
            acGridView2.AddTextEdit("BAL_QTY", "���ּ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("YPGO_QTY", "�԰����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddLookUpEdit("MAT_UNIT", "����", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddTextEdit("YPGO_COST", "�԰�ܰ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("AMT", "�԰�ݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddLookUpEdit("BAL_UNIT", "ȭ�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P008");
            acGridView2.AddLookUpEdit("YPGO_LOC", "����â��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
            acGridView2.AddHidden("YPGO_ID", typeof(string));

            acGridView2.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

            (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

            acCheckedComboBoxEdit1.AddItem("�԰���", false, "40206", "YPGO_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("������", false, "40206", "BALJU_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("�԰��û��", false, "40206", "DUE_DATE", true, false);
            

            _selectedPage = "MAT";

            base.MenuInit();

        }

        

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "YPGO_DATE";

                layout.GetEditor("S_DATE").Value = System.DateTime.Now.AddDays(-7);

                layout.GetEditor("E_DATE").Value = System.DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }
        private void AcTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            acTabControl tc = sender as acTabControl;

            if (tc.SelectedTabPage == acTabPage1)
            {
                _selectedPage = "MAT";
            }
            else
            {
                _selectedPage = "OUT";
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
            //���� ���Ǻ���
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

        
        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("S_YPGO_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("E_YPGO_DATE", typeof(String)); //������ ����
            paramTable.Columns.Add("MAT_LTYPE", typeof(String)); 
            paramTable.Columns.Add("BALJU_NUM_LIKE", typeof(String)); 
            paramTable.Columns.Add("PART_LIKE", typeof(String)); 

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
            paramRow["BALJU_NUM_LIKE"] = layoutRow["BALJU_NUM_LIKE"];
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {

                    case "BALJU_DATE":

                        //������
                        paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":

                        //������
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "YPGO_DATE":

                        //������
                        paramRow["S_YPGO_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_YPGO_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (_selectedPage == "MAT")
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR07A_SER", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];
            }
            else
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR07A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView2.GridControl.DataSource = dsResult.Tables["RSLTDT"];
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //�԰���� 
            try
            {
                DataRow[] selectedRows;

                if (_selectedPage == "MAT")
                {
                
                    acGridView1.EndEditor();

                    selectedRows = acGridView1.GetSelectedDataRows();

                    
                    if (!acGridView1.ValidCheck()) return;
                }
                else
                {
                    acGridView2.EndEditor();

                    selectedRows = acGridView2.GetSelectedDataRows();

                    if (!acGridView2.ValidCheck()) return;
                }
                
                if (acMessageBox.Show("������ ���� �԰� ��� �Ͻðڽ��ϱ�?", "�԰� ���", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {

                    
                    DataTable paramtable = new DataTable("RQSTDT");
                    paramtable.Columns.Add("PLT_CODE", typeof(string));
                    paramtable.Columns.Add("BALJU_NUM", typeof(string));
                    paramtable.Columns.Add("BALJU_SEQ", typeof(string));
                    paramtable.Columns.Add("YPGO_ID", typeof(string));
                    paramtable.Columns.Add("WO_NO", typeof(string));
                    paramtable.Columns.Add("REG_EMP", typeof(string));
                    paramtable.Columns.Add("ACT_QTY", typeof(int));
                    paramtable.Columns.Add("PART_CODE", typeof(string));

                    if (selectedRows.Length == 0)
                    {
                        DataRow focusedRow = acGridView1.GetFocusedDataRow();

                        if (_selectedPage == "OUT")
                        {

                            focusedRow = acGridView2.GetFocusedDataRow();
                        }

                        DataRow datarow = paramtable.NewRow();
                        datarow["PLT_CODE"] = acInfo.PLT_CODE;
                        datarow["BALJU_NUM"] = focusedRow["BALJU_NUM"];
                        datarow["BALJU_SEQ"] = focusedRow["BALJU_SEQ"];
                        datarow["YPGO_ID"] = focusedRow["YPGO_ID"];

                        datarow["REG_EMP"] = acInfo.UserID;
                        datarow["ACT_QTY"] = focusedRow["BAL_QTY"].toInt() - focusedRow["YPGO_QTY"].toInt();
                        datarow["PART_CODE"] = focusedRow["PART_CODE"];

                        if (focusedRow.Table.Columns.Contains("WO_NO"))
                            datarow["WO_NO"] = focusedRow["WO_NO"];

                        paramtable.Rows.Add(datarow);
                    }
                    else
                    {
                        foreach (DataRow dr in selectedRows)
                        {
                            DataRow datarow = paramtable.NewRow();
                            datarow["PLT_CODE"] = acInfo.PLT_CODE;
                            datarow["BALJU_NUM"] = dr["BALJU_NUM"];
                            datarow["BALJU_SEQ"] = dr["BALJU_SEQ"];
                            datarow["YPGO_ID"] = dr["YPGO_ID"];

                            datarow["REG_EMP"] = acInfo.UserID;
                            datarow["ACT_QTY"] = dr["BAL_QTY"].toInt() - dr["YPGO_QTY"].toInt();
                            datarow["PART_CODE"] = dr["PART_CODE"];

                            if (dr.Table.Columns.Contains("WO_NO"))
                                datarow["WO_NO"] = dr["WO_NO"];

                            paramtable.Rows.Add(datarow);

                        }
                    }
                    

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramtable);

                    if (_selectedPage == "MAT")
                    {
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR07A_DEL", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
                    }
                    else
                    {
                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR07A_DEL2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_selectedPage == "MAT")
                {
                    foreach(DataRow dr in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView1.DeleteMappingRow(dr);
                    }
                    //acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }
                else
                {
                    foreach (DataRow dr in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView2.DeleteMappingRow(dr);
                    }
                    //acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                }

                acAlert.Show(this, "��� �Ǿ����ϴ�.", acAlertForm.enmType.Success);

                base.SetLog(e.executeType, e.result.Tables["RQSTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow[] selectedRows;

            if (_selectedPage == "MAT")
            {

                acGridView1.EndEditor();

                selectedRows = acGridView1.GetSelectedDataRows();


                if (!acGridView1.ValidCheck()) return;
            }
            else
            {
                acGridView2.EndEditor();

                selectedRows = acGridView2.GetSelectedDataRows();

                if (!acGridView2.ValidCheck()) return;
            }

            if (acMessageBox.Show("������ �� �԰��� ������ �Ͻðڽ��ϱ�?", "�԰��� ����", acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
            {


                DataTable paramtable = new DataTable("RQSTDT");
                paramtable.Columns.Add("PLT_CODE", typeof(string));
                paramtable.Columns.Add("YPGO_ID", typeof(string));
                paramtable.Columns.Add("YPGO_DATE", typeof(string));

                if (selectedRows.Length == 0)
                {
                    DataRow focusedRow = acGridView1.GetFocusedDataRow();

                    if (_selectedPage == "OUT")
                    {

                        focusedRow = acGridView2.GetFocusedDataRow();
                    }

                    DataRow datarow = paramtable.NewRow();
                    datarow["PLT_CODE"] = acInfo.PLT_CODE;
                    datarow["YPGO_ID"] = focusedRow["YPGO_ID"];
                    datarow["YPGO_DATE"] = focusedRow["YPGO_DATE"].toDateString("yyyyMMdd");


                    paramtable.Rows.Add(datarow);
                }
                else
                {
                    foreach (DataRow dr in selectedRows)
                    {
                        DataRow datarow = paramtable.NewRow();
                        datarow["PLT_CODE"] = acInfo.PLT_CODE;
                        datarow["YPGO_ID"] = dr["YPGO_ID"];;
                        datarow["YPGO_DATE"] = dr["YPGO_DATE"].toDateString("yyyyMMdd");

                        paramtable.Rows.Add(datarow);

                    }
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramtable);

                if (_selectedPage == "MAT")
                {
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR07A_UPD2", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);
                }
                else
                {
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PUR07A_UPD3", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);
                }
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_selectedPage == "MAT")
                {
                    acGridView1.ClearSelection();
                }
                else
                {
                    acGridView1.ClearSelection();
                }

                acAlert.Show(this, "���� �Ǿ����ϴ�.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Ȯ��
            try
            {
                if (_selectedPage == "MAT")
                {
                    acGridView1.EndEditor();

                    if (acMessageBox.Show(this, "���� �Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedrows = acGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("YPGO_ID", typeof(String)); //
                    paramTable.Columns.Add("CHECK_FLAG", typeof(String)); //
                    paramTable.Columns.Add("CHECK_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DATE", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_DATE", typeof(String)); //

                    if (selectedrows.Length == 0)
                    {
                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        if (focusRow["CHECK_FLAG"].ToString() == "1")
                        {
                            acAlert.Show(this, "�̹� Ȯ�ε� �׸��Դϴ�.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["YPGO_ID"] = focusRow["YPGO_ID"];
                        paramRow["CHECK_FLAG"] = "1";
                        paramRow["CHECK_EMP"] = acInfo.UserID;
                        paramRow["CHECK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        foreach (DataRow row in selectedrows)
                        {
                            if (row["CHECK_FLAG"].ToString() == "1")
                            {
                                acAlert.Show(this, "�̹� Ȯ�ε� �׸��� �����մϴ�.", acAlertForm.enmType.Warning);
                                return;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["YPGO_ID"] = row["YPGO_ID"];
                            paramRow["CHECK_FLAG"] = "1";
                            paramRow["CHECK_EMP"] = acInfo.UserID;
                            paramRow["CHECK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "PUR07A_UPD4", paramSet, "RQSTDT", "RSLTDT",
                    QuickChk,
                    QuickException);
                }
                else
                {
                    acGridView2.EndEditor();

                    if (acMessageBox.Show(this, "���� �Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedrows = acGridView2.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("YPGO_ID", typeof(String)); //
                    paramTable.Columns.Add("CHECK_FLAG", typeof(String)); //
                    paramTable.Columns.Add("CHECK_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DATE", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_DATE", typeof(String)); //

                    if (selectedrows.Length == 0)
                    {
                        DataRow focusRow = acGridView2.GetFocusedDataRow();

                        if (focusRow["CHECK_FLAG"].ToString() == "1")
                        {
                            acAlert.Show(this, "�̹� Ȯ�ε� �׸��Դϴ�.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["YPGO_ID"] = focusRow["YPGO_ID"];
                        paramRow["CHECK_FLAG"] = "1";
                        paramRow["CHECK_EMP"] = acInfo.UserID;
                        paramRow["CHECK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        foreach (DataRow row in selectedrows)
                        {

                            if (row["CHECK_FLAG"].ToString() == "1")
                            {
                                acAlert.Show(this, "�̹� Ȯ�ε� �׸��� �����մϴ�.", acAlertForm.enmType.Warning);
                                return;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["YPGO_ID"] = row["YPGO_ID"];
                            paramRow["CHECK_FLAG"] = "1";
                            paramRow["CHECK_EMP"] = acInfo.UserID;
                            paramRow["CHECK_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "PUR07A_UPD5", paramSet, "RQSTDT", "RSLTDT",
                    QuickChk2,
                    QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickChk(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }

                acGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickChk2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acGridView2.UpdateMapingRow(row, false);
                }
                acGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Ȯ�����
            try
            {
                if (_selectedPage == "MAT")
                {
                    acGridView1.EndEditor();

                    if (acMessageBox.Show(this, "���� �Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedrows = acGridView1.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("YPGO_ID", typeof(String)); //
                    paramTable.Columns.Add("CHECK_FLAG", typeof(String)); //
                    paramTable.Columns.Add("CHECK_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DATE", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_DATE", typeof(String)); //

                    if (selectedrows.Length == 0)
                    {
                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        if (focusRow["CHECK_FLAG"].ToString() == "0")
                        {
                            acAlert.Show(this, "��Ȯ�� �׸��Դϴ�.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["YPGO_ID"] = focusRow["YPGO_ID"];
                        paramRow["CHECK_FLAG"] = "0";
                        paramRow["CHECK_DEL_EMP"] = acInfo.UserID;
                        paramRow["CHECK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        foreach (DataRow row in selectedrows)
                        {
                            if (row["CHECK_FLAG"].ToString() == "0")
                            {
                                acAlert.Show(this, "��Ȯ�� �׸��� �����մϴ�.", acAlertForm.enmType.Warning);
                                return;
                            }


                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["YPGO_ID"] = row["YPGO_ID"];
                            paramRow["CHECK_FLAG"] = "0";
                            paramRow["CHECK_DEL_EMP"] = acInfo.UserID;
                            paramRow["CHECK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "PUR07A_UPD4", paramSet, "RQSTDT", "RSLTDT",
                    QuickChk,
                    QuickException);
                }
                else
                {
                    acGridView2.EndEditor();

                    if (acMessageBox.Show(this, "���� �Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    DataRow[] selectedrows = acGridView2.GetSelectedDataRows();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("YPGO_ID", typeof(String)); //
                    paramTable.Columns.Add("CHECK_FLAG", typeof(String)); //
                    paramTable.Columns.Add("CHECK_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DATE", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_EMP", typeof(String)); //
                    paramTable.Columns.Add("CHECK_DEL_DATE", typeof(String)); //

                    if (selectedrows.Length == 0)
                    {
                        DataRow focusRow = acGridView2.GetFocusedDataRow();

                        if (focusRow["CHECK_FLAG"].ToString() == "0")
                        {
                            acAlert.Show(this, "��Ȯ�� �׸��Դϴ�.", acAlertForm.enmType.Warning);
                            return;
                        }

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["YPGO_ID"] = focusRow["YPGO_ID"];
                        paramRow["CHECK_FLAG"] = "0";
                        paramRow["CHECK_DEL_EMP"] = acInfo.UserID;
                        paramRow["CHECK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");

                        paramTable.Rows.Add(paramRow);
                    }
                    else
                    {
                        foreach (DataRow row in selectedrows)
                        {

                            if (row["CHECK_FLAG"].ToString() == "0")
                            {
                                acAlert.Show(this, "��Ȯ�� �׸��� �����մϴ�.", acAlertForm.enmType.Warning);
                                return;
                            }

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["YPGO_ID"] = row["YPGO_ID"];
                            paramRow["CHECK_FLAG"] = "0";
                            paramRow["CHECK_DEL_EMP"] = acInfo.UserID;
                            paramRow["CHECK_DEL_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    DataSet paramSet = new DataSet();

                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "PUR07A_UPD5", paramSet, "RQSTDT", "RSLTDT",
                    QuickChk2,
                    QuickException);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}



