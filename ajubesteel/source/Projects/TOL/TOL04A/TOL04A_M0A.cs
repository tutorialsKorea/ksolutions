using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;
using DevExpress.XtraPivotGrid;

namespace TOL
{
    public sealed partial class TOL04A_M0A : BaseMenu
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

        public TOL04A_M0A()
        {

            InitializeComponent();

            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl2.OnValueChanged += AcLayoutControl1_OnValueChanged;
            acLayoutControl3.OnValueChanged += AcLayoutControl1_OnValueChanged;
        }

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {
            #region ����
            acPivotGridControl1.AddField("GIVE_NO", "���޹�ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_SEQ","���޼���",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_DATE", "������",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            acPivotGridControl1.AddField("GIVE_STATE_NAME", "���޻���",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_MC_CODE", "���� �����ڵ�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_MC_NAME", "���� �����",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_EMP_CODE", "�������ڵ�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("GIVE_EMP_NAME", "�����ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl1.AddField("���� �μ��ڵ�", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl1.AddField("���� �μ���", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_LOT", "LOT��ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_CODE","�����ڵ�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_NAME", "������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_TYPE_NAME", "��������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_LTYPE_NAME", "���� ��з�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_MTYPE_NAME", "���� �ߺз�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_STYPE_NAME", "���� �Һз�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_SPEC", "���",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_UNIT","����",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("TL_QTY", "����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("SCOMMENT", "���",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_DATE", "����ó������",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_EMP_CODE", "����ó�����ڵ�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl1.AddField("REG_EMP_NAME", "����ó���ڸ�",  "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            #region �ݳ�

            acPivotGridControl2.AddField("GIVE_NO", "���޹�ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_SEQ", "���޼���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_DATE", "������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            acPivotGridControl2.AddField("GIVE_STATE_NAME", "���޻���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_MC_CODE", "���� �����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_MC_NAME", "���� �����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_EMP_CODE", "�������ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("GIVE_EMP_NAME", "�����ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_NO", "�ݳ���ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_SEQ", "�ݳ�����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_DATE", "�ݳ���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_EMP_CODE", "�ݳ����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("RTN_EMP_NAME", "�ݳ��ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl2.AddField("���� �μ��ڵ�", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl2.AddField("���� �μ���", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_LOT", "LOT��ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_CODE", "�����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_NAME", "������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_TYPE_NAME", "��������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_LTYPE_NAME", "���� ��з�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_MTYPE_NAME", "���� �ߺз�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_STYPE_NAME", "���� �Һз�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_SPEC", "���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_UNIT", "����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("TL_QTY", "����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("SCOMMENT", "���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_DATE", "�ݳ�ó������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_EMP_CODE", "�ݳ�ó�����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl2.AddField("REG_EMP_NAME", "�ݳ�ó���ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            #region ���

            acPivotGridControl3.AddField("TDU_NO", "����ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_SEQ", "������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_DATE", "�����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);
            //acPivotGridControl3.AddField("��� �����ڵ�", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("��� �����", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_EMP_CODE", "��� �۾����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TDU_EMP_NAME", "��� �۾��ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("��� �μ��ڵ�", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            //acPivotGridControl3.AddField("��� �μ���", "", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_LOT", "LOT��ȣ", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_CODE", "�����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_NAME", "������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_TYPE_NAME", "��������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_LTYPE_NAME", "���� ��з�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_MTYPE_NAME", "���� �ߺз�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_STYPE_NAME", "���� �Һз�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_SPEC", "���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_UNIT", "����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("TL_QTY", "����", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("SCOMMENT", "���", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_DATE", "���ó������", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_EMP_CODE", "���ó�����ڵ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);
            acPivotGridControl3.AddField("REG_EMP_NAME", "���ó���ڸ�", "", false, PivotArea.FilterArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            #endregion

            acCheckedComboBoxEdit1.AddItem("�����", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("������", false, "", "GIVE_DATE", true, false);

            acCheckedComboBoxEdit3.AddItem("�����", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit3.AddItem("�ݳ���", false, "", "RTN_DATE", true, false);

            acCheckedComboBoxEdit2.AddItem("�����", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit2.AddItem("�����", false, "", "TDU_DATE", true, false);

            base.MenuInit();
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl1.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl1.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl1.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;

            }

            if (sender == acLayoutControl2)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl2.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl2.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl2.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;

            }

            if (sender == acLayoutControl3)
            {
                acLayoutControl layout = sender as acLayoutControl;

                (acLayoutControl3.GetEditor("DATE") as acCheckedComboBoxEdit).Value = "REG_DATE";
                (acLayoutControl3.GetEditor("S_DATE") as acDateEdit).Value = DateTime.Now.AddDays(-7);
                (acLayoutControl3.GetEditor("E_DATE") as acDateEdit).Value = DateTime.Now;
            }
        }


        public override void MenuInitComplete()
        {
            base.MenuInitComplete();

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

        void Search()
        {
            if (xtraTabControl1.SelectedTabPage == GiveTab)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_MC_CODE", typeof(String)); //
                paramTable.Columns.Add("GIVE_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("E_GIVE_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GIVE_MC_CODE"] = layoutRow["GIVE_MC_CODE"];
                paramRow["GIVE_EMP_CODE"] = layoutRow["GIVE_EMP_CODE"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "GIVE_DATE":

                            paramRow["S_GIVE_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_GIVE_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL04A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == ReturnTab)
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("RTN_MC_CODE", typeof(String)); //
                paramTable.Columns.Add("RTN_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("E_RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["RTN_MC_CODE"] = layoutRow["RTN_MC_CODE"];
                paramRow["RTN_EMP_CODE"] = layoutRow["RTN_EMP_CODE"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "RTN_DATE":

                            paramRow["S_RTN_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_RTN_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                //paramRow["TL_STAT"] = acStdCodes.GetCodeByNameServer("T005", "��ǰ");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL04A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);
            }
            else if (xtraTabControl1.SelectedTabPage == DisuseTab)
            {
                DataRow layoutRow = acLayoutControl3.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TDU_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("S_YPGO_DATE", typeof(String)); //
                paramTable.Columns.Add("E_YPGO_DATE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TDU_EMP_CODE"] = layoutRow["TDU_EMP_CODE"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (key)
                    {
                        case "REG_DATE":

                            paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                            break;
                        case "TDU_DATE":

                            paramRow["S_TDU_DATE"] = layoutRow["S_DATE"];
                            paramRow["E_TDU_DATE"] = layoutRow["E_DATE"];

                            break;
                    }
                }
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "TOL04A_SER3", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail2,
                QuickException);
            }
            
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acPivotGridControl1.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acPivotGridControl2.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearchDetail2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acPivotGridControl3.DataSource = e.result.Tables["RSLTDT"];

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

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }



        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //�˾��޴� ����

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}

