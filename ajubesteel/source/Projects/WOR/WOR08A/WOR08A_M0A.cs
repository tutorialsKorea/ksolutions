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
using DevExpress.XtraEditors.Repository;

namespace WOR
{
    public sealed partial class WOR08A_M0A : BaseMenu
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

        public WOR08A_M0A()
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

        private Color _progColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
        private Color _okColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
        private Color _denyColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_DENY").toColor();

        private DataSet _WorkSet = null;
        private DataSet _WorkTimeSet = null;
        private DataSet _IdleSet = null;

        public override void MenuInit()
        {
            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.AddTextEdit("EMP_CODE", "����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("EMP_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("HIRE_DATE", "�Ի���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("ORG_CODE", "�μ��ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ORG_NAME", "�μ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CNT_HOLI", "�߻�����", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("USE_HOLI", "��뿬��", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);
            acGridView2.AddTextEdit("REMAIN_HOLI", "�ܿ�����", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.F1);

            acGridView2.FocusedRowChanged += acGridView2_FocusedRowChanged;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            //acGridView1.AddCheckEdit("SEL", "����", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("WORK_ID", "ID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "��û���ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "��û��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_NAME", "���¸�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REQ_START_DATE", "���۽ð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("REQ_END_DATE", "����ð�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddTextEdit("REQ_DAY", "�ϴ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("REQ_HOUR", "��û�ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.Columns["REQ_HOUR"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_HOUR", "�հ�={0:N1}");
            acGridView1.AddTextEdit("REQ_TIME", "��û�ð�(��)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.Columns["REQ_TIME"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "REQ_TIME", "�հ�={0:N0}");
            acGridView1.AddDateEdit("REQ_DATE", "��û�Ͻ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddLookUpEdit("REQ_AMPM", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W005");
            acGridView1.AddLookUpEdit("OUT_TYPE", "�ܱ� ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W011");
            acGridView1.AddCheckEdit("IS_DIR_IN", "���⿩��", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddCheckEdit("IS_DIR_OUT", "���𿩺�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("OUT_VEN_CODE", "��ü�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OUT_VEN_NAME", "��ü��", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("REQ_STATUS", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W008");
            acGridView1.AddTextEdit("REQ_SCOMMENT", "��û����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("APP_SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CC_EMP", "������", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("REJECT_DATE", "�ݷ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("REJECT_REASON", "�ݷ�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE1", "������1�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME1", "������1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP1_FLAG", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE2", "������2�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME2", "������2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP2_FLAG", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE3", "������3�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME3", "������3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP3_FLAG", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("APP_EMP_CODE4", "������4�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP_NAME4", "������4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("APP_EMP4_FLAG", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEmp("APP_EMP1", "������1", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG1", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP2", "������2", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG2", "������2����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP3", "������3", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG3", "������3����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEmp("APP_EMP4", "������4", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("APP_EMP_FLAG4", "������4����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            RepositoryItemHyperLinkEdit repItemHLE = new RepositoryItemHyperLinkEdit();
            repItemHLE.NullText = "÷������";

            acGridView1.AddCustomEdit("ATCH_FILE", "÷������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, repItemHLE);

            acGridView1.AddCheckEdit("HAS_ATTACH", "÷����������", "", false, false, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddDateEdit("REG_DATE", "���� �����", "UL1O77MB", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "���� ������ڵ�", "P72K0SQJ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "���� �����", "GPQHG8QQ", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "�ֱ� ������", "6RXQO0B2", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "�ֱ� �������ڵ�", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "�ֱ� ������", "FHJDO4F0", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "WORK_ID" };

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.MouseUp += acGridView1_MouseUp;

            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

            //acGridView1.CustomSummaryCalculate += acGridView1_CustomSummaryCalculate;

            _WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

            _WorkTimeSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER4", acInfo.RefData, "RQSTDT", "RSLTDT");

            _IdleSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER6", acInfo.RefData, "RQSTDT", "RSLTDT");

            DateTime nowDate = acDateEdit.GetNowDateFromServer();

            string[] bands1 = new string[] { "����", nowDate.Year.ToString() + "��" };

            acBandGridView1.AddTextEdit("YEAR", nowDate.Year.ToString() + "��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands1);


            string[] bands2 = new string[] { "�д��� ���", "����" };
            string[] bands3 = new string[] { "�д��� ���", "����" };
            string[] bands4 = new string[] { "�д��� ���", "����" };
            string[] bands5 = new string[] { "�д��� ���", "����" };

            acBandGridView1.AddTextEdit("W01", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands2);
            acBandGridView1.AddTextEdit("W02", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands3);
            acBandGridView1.AddTextEdit("W03", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands4);
            acBandGridView1.AddTextEdit("W04", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands5);


            string[] bands6 = new string[] { "�ϴ��� ���", "����\r\n����"};
            string[] bands7 = new string[] { "�ϴ��� ���", "����"};

            acBandGridView1.AddTextEdit("W05_W06", "����\r\n����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands6);
            acBandGridView1.AddTextEdit("W07", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands7);


            string[] bands8 = new string[] { nowDate.Year.ToString() + "��" + " ������", "���ٹ�\r\n�ϼ�" };
            string[] bands9 = new string[] { nowDate.Year.ToString() + "��" + " ������", "����\r\n�ִ�\r\n�ð�\r\n(��52)" };
            string[] bands10 = new string[] { nowDate.Year.ToString() + "��" + " ������", "�⺻�ٹ�\r\n�ϼ�\r\n(�ٹ��ϼ�*8)" };

            //Dictionary<string, Color> colColorDic = new Dictionary<string, Color>();

            acBandGridView1.AddTextEdit("WORK_DAY", "���ٹ�\r\n�ϼ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands8);
            //colColorDic.Add("WORK_DAY:BACK", Color.LightGray);
            acBandGridView1.AddTextEdit("WORK_MONTH_TIME", "����\r\n�ִ�\r\n�ð�\r\n(��52)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands9);
            //colColorDic.Add("WORK_MONTH_TIME:BACK", Color.LightGray);
            acBandGridView1.AddTextEdit("WORK_HOUR", "�⺻�ٹ�\r\n�ϼ�\r\n(�ٹ��ϼ�*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands10);
            //colColorDic.Add("WORK_HOUR:BACK", Color.LightGray);


            string[] bands11 = new string[] { "�ð����� ���", "��,��\r\n����\r\n����\r\n�ð�" };
            string[] bands12 = new string[] { "�ð����� ���", "�Ǳٹ��ð�" };
            string[] bands13 = new string[] { "�ð����� ���", "���ܿ�\r\n����\r\n�ð�" };
            string[] bands14 = new string[] { "�ð����� ���", "����\r\n����\r\n�ð�" };

            acBandGridView1.AddTextEdit("HOLI_TIME", "��,��\r\n����\r\n����\r\n�ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands11);
            //colColorDic.Add("HOLI_TIME:FORE", Color.Red);
            acBandGridView1.AddTextEdit("WORK_TIME", "�Ǳٹ��ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands12);
            acBandGridView1.AddTextEdit("REMAIN_TIME", "���ܿ�\r\n����\r\n�ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands13);
            acBandGridView1.AddTextEdit("CUM_TIME", "����\r\n����\r\n�ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands14);

            int iBands1 = 1;
            int iBands2 = 1;
            int iBands3 = 1;
            int iBands4 = 1;
            foreach (DataRow row in _WorkTimeSet.Tables["RSLTDT"].Rows)
            {
                if (row["WORK_CODE"].ToString() == "W08")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0,2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands1++;
                    //string[] bands15 = new string[] { "�ð����� ���", "�ܾ�", "18:00", "22:00", "1.5" };
                    //string[] bands16 = new string[] { "�ð����� ���", "�ܾ�", "22:00", "06:00", "2.0" };
                    //string[] bands17 = new string[] { "�ð����� ���", "�ܾ�", "06:00", "08:00", "1.5" };

                    //acBandGridView1.AddTextEdit("W08_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands15);
                    //acBandGridView1.AddTextEdit("W08_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands16);
                    //acBandGridView1.AddTextEdit("W08_3", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands17);
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands2++;

                    //string[] bands18 = new string[] { "�ð����� ���", "����", "22:00", "05:30", "0.5" };
                    //string[] bands19 = new string[] { "�ð����� ���", "����", "06:00", "08:00", "1.5" };

                    //acBandGridView1.AddTextEdit("W09_1", "0.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands18);
                    //acBandGridView1.AddTextEdit("W09_2", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands19);
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands3++;

                    //string[] bands20 = new string[] { "�ð����� ���", "Ư��", "08:30", "17:30", "1.5" };
                    //string[] bands21 = new string[] { "�ð����� ���", "Ư��", "18:00", "22:00", "2.0" };
                    //string[] bands22 = new string[] { "�ð����� ���", "Ư��", "22:00", "06:00", "2.5" };
                    //string[] bands23 = new string[] { "�ð����� ���", "Ư��", "06:00", "08:00", "2.0" };

                    //acBandGridView1.AddTextEdit("W10_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands20);
                    //acBandGridView1.AddTextEdit("W10_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands21);
                    //acBandGridView1.AddTextEdit("W10_3", "2.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands22);
                    //acBandGridView1.AddTextEdit("W10_4", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands23);
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands4++;

                    //string[] bands24 = new string[] { "�ð����� ���", "���ϱ���", "20:30", "22:00", "1.5" };
                    //string[] bands25 = new string[] { "�ð����� ���", "���ϱ���", "22:00", "05:30", "2.0" };
                    //string[] bands26 = new string[] { "�ð����� ���", "���ϱ���", "06:00", "08:00", "2.0" };

                    //acBandGridView1.AddTextEdit("W11_1", "1.5", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands24);
                    //acBandGridView1.AddTextEdit("W11_2", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands25);
                    //acBandGridView1.AddTextEdit("W11_3", "2.0", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, bands26);
                }
            }

            acBandGridView1.BestFitColumns();
            acBandGridView1.ColumnPanelRowHeight = 100;
            acBandGridView1.OptionsView.ShowColumnHeaders = false;

            acBandGridView1.Bands[0].Visible = false;

            acBandGridView1.CustomDrawCell += acBandGridView1_CustomDrawCell;


            acCheckedComboBoxEdit1.AddItem("��û���۽ð�", false, "", "REQ_DATE", true, false);

            base.MenuInit();
        }

        private void acGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            
        }

        private void acGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

            if (hitInfo.Column == null) return;

            if (hitInfo.Column.FieldName == "ATCH_FILE" && hitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    if (!base.ChildFormContains("NEW_ITEM"))
                    {
                        WOR08A_D1A frm = new WOR08A_D1A(focusRow);
                        frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                        frm.ParentControl = this;
                        base.ChildFormAdd("NEW_ITEM", frm);
                        frm.Show(this);
                        focusRow = null;
                    }
                    else
                    {
                        base.ChildFormFocus("NEW_ITEM");
                    }
                }
            }
        }

        private void acGridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Search();
        }

        private void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow empRow = acGridView2.GetFocusedDataRow();

            if (empRow["EMP_NAME"].ToString() == "��ü")
            {
                acBandGridView1.ClearRow();
                //GetDetail();
            }
        }

        private void acBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "WORK_DAY"
                || e.Column.FieldName == "WORK_MONTH_TIME"
                || e.Column.FieldName == "WORK_HOUR")
            {
                if (e.RowHandle < 12)
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }

            if (e.Column.FieldName == "HOLI_TIME")
            {
                e.Appearance.ForeColor = Color.Red;
            }

            string sFirstColumn = acBandGridView1.GetRowCellDisplayText(e.RowHandle, "YEAR").ToString();

            if (sFirstColumn == "�հ�")
            {
                e.Appearance.BackColor = Color.DimGray;
                e.Appearance.ForeColor = Color.White;
            }

            if (sFirstColumn == "���"
                || sFirstColumn == "����"
                || sFirstColumn == "�߻�")
            {
                if (e.Column.FieldName.Contains("W11"))
                {
                    string[] cols = e.Column.FieldName.Split('_');

                    int iCols = cols[1].toInt();

                    if (iCols < 3)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                string app1 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = acGridView1.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

                if (e.Column.FieldName.StartsWith("APP_EMP"))
                {
                    if (e.Column.FieldName.IndexOf("1") > -1)
                    {
                        //if (app1 != "0")
                        //{
                            e.Appearance.BackColor = GetStatColor(app1);
                            e.Appearance.ForeColor = GetStatFontColor(app1);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("2") > -1)
                    {
                        //if (app2 != "0")
                        //{
                            e.Appearance.BackColor = GetStatColor(app2);
                            e.Appearance.ForeColor = GetStatFontColor(app2);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("3") > -1)
                    {
                        //if (app3 != "0")
                        //{
                            e.Appearance.BackColor = GetStatColor(app3);
                            e.Appearance.ForeColor = GetStatFontColor(app3);
                        //}
                    }
                    else if (e.Column.FieldName.IndexOf("4") > -1)
                    {
                        //if (app4 != "0")
                        //{
                            e.Appearance.BackColor = GetStatColor(app4);
                            e.Appearance.ForeColor = GetStatFontColor(app4);
                        //}
                    }
                }
            }
            catch { }
        }


        Color GetStatColor(string flag)
        {
            Color color = Color.Transparent;

            switch(flag)
            {
                case "0":
                    color = _progColor;
                    break;

                case "1":
                    color = _okColor;
                    break;

                case "2":
                    color = _denyColor;
                    break;
            }

            return color;
        }

        Color GetStatFontColor(string flag)
        {
            Color color = Color.Black;

            switch (flag)
            {
                case "0":
                    color = Color.Black;
                    break;

                case "1":
                    color = Color.Black;
                    break;

                case "2":
                    color = Color.Black;
                    break;
            }

            return color;
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                //layout.GetEditor("EMP_CODE").Value = acInfo.UserID;
                layout.GetEditor("DATE").Value = "REQ_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstYear();
                layout.GetEditor("E_DATE").Value = acDateEdit.GetNowLastDate();
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

        private void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    acBarButtonItem2_ItemClick(null, null);
                }
            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow == null) return;

                bool isAll = false;
                if (focusRow["EMP_NAME"].ToString() == "��ü")
                {
                    isAll = true;
                }

                if (e.MenuType == GridMenuType.User)
                {
                    acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarSubItem1.Visibility = isAll == true ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchEmp();
            }
        }

        void Search(bool isDel = false)
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow focusRow = acGridView2.GetFocusedDataRow();
            if (focusRow == null)
            {
                acBandGridView1.ClearRow();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //
            paramTable.Columns.Add("IS_DEL", typeof(bool)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
            //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
            //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
            paramRow["IS_DEL"] = isDel;


            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":
                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (!e.result.Tables["RQSTDT"].Rows[0]["IS_DEL"].toBoolean())
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView1.BestFitColumns();
                }

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow != null)
                {
                    acLayoutControl2.DataBind(focusRow, false);
                }

                if (focusRow["EMP_NAME"].ToString() == "��ü")
                {
                    acBandGridView1.ClearRow();
                    return;
                }

                //acBandGridView1.ClearRow();

                //return;

                //�ٷ���Ȳ������ ����

                DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                //�հ� ���� dictionary
                Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["YEAR"] = i.ToString() + "��";

                    string month = e.result.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                    DataRow[] reqRwos = e.result.Tables["RSLTDT_YEAR"].Select("REQ_START_MONTH = '" + month + "'");

                    foreach (DataRow row in reqRwos)
                    {
                        //�д��� - ����(W01), ����(W02), ����(W03), ����(W04)
                        //�ϴ��� - ����/����(W05/W06), ����(W07)
                        //�ð����� - �ܾ�(W08), ����(W09), Ư��(W10), ���ϱ���(W11)
                        switch (row["WORK_CODE"].ToString())
                        {
                            case "W01": //����

                                newRow["W01"] = newRow["W01"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W01"))
                                {
                                    sumDic["W01"] = sumDic["W01"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W01", newRow["W01"].toDecimal());
                                }

                                break;

                            case "W02": //����

                                newRow["W02"] = newRow["W02"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W02"))
                                {
                                    sumDic["W02"] = sumDic["W02"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W02", newRow["W02"].toDecimal());
                                }

                                break;

                            case "W03": //����

                                newRow["W03"] = newRow["W03"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W03"))
                                {
                                    sumDic["W03"] = sumDic["W03"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W03", newRow["W03"].toDecimal());
                                }

                                break;

                            case "W04": //����

                                newRow["W04"] = newRow["W04"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W04"))
                                {
                                    sumDic["W04"] = sumDic["W04"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W04", newRow["W04"].toDecimal());
                                }

                                break;

                            case "W05": //����
                            case "W06": //����

                                newRow["W05_W06"] = Math.Round(((newRow["W05_W06"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W05_W06"))
                                {
                                    sumDic["W05_W06"] = sumDic["W05_W06"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W05_W06", newRow["W05_W06"].toDecimal());
                                }

                                break;

                            case "W07": //����

                                newRow["W07"] = Math.Round(((newRow["W07"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W07"))
                                {
                                    sumDic["W07"] = sumDic["W07"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W07", newRow["W07"].toDecimal());
                                }

                                break;

                            case "W08": //�ܾ�
                            case "W09": //����
                            case "W10": //Ư��
                            case "W11": //���ϱ���

                                //�ٹ����¿� ���� ��,�߰� ����ȭ �ð��� �����´�.
                                DataTable idleTable = new DataTable("RQSTDT");
                                idleTable.Columns.Add("PLT_CODE", typeof(string));
                                idleTable.Columns.Add("EMP_CODE", typeof(string));
                                idleTable.Columns.Add("WORK_YEAR", typeof(string));
                                idleTable.Columns.Add("EWT_DATE", typeof(string));

                                DataRow idleRow = idleTable.NewRow();
                                idleRow["PLT_CODE"] = acInfo.PLT_CODE;
                                idleRow["EMP_CODE"] = row["EMP_CODE"];
                                idleRow["WORK_YEAR"] = row["REQ_START_DATE"].toDateTime().ToString("yyyy");
                                idleRow["EWT_DATE"] = row["REQ_START_DATE"].toDateTime().ToString("yyyyMMdd");

                                idleTable.Rows.Add(idleRow);
                                DataSet idleSet = new DataSet();
                                idleSet.Tables.Add(idleTable);

                                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                                //IDLE_FLAG - 0 : �ְ� , 1 : �߰�
                                string idleFillter = "IDLE_FLAG = '0'";

                                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                                {
                                    if (resultSet.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
                                    {
                                        idleFillter = "IDLE_FLAG = '1'";
                                    }
                                }

                                //���ϱ����� ��� ���� �߰��ٹ���
                                if (row["WORK_CODE"].ToString() == "W11")
                                {
                                    idleFillter = "IDLE_FLAG = '1'";
                                }

                                //���ؽð��� �����ձ��ϱ�
                                //1.��û�ð��� ���ؽð� ���۽ð��� ����ð��� ���ԵȰ��
                                //2.���ؽ��۽ð��� ��û�ð� ���̿� �ִ°��
                                //3.���ؽð��� ��û�ð� ���۽ð��� ����ð��� ���ԵȰ��
                                //5.��������ð��� ��û�ð� ���̿� �ִ°��
                                DataRow[] workRows = _WorkTimeSet.Tables["RSLTDT"].Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

                                Dictionary<string, bool> nextdaydic = new Dictionary<string, bool>();

                                if (!nextdaydic.ContainsKey(row["WORK_CODE"].ToString()))
                                {
                                    nextdaydic.Add(row["WORK_CODE"].ToString(), false);
                                }
                                else
                                {
                                    nextdaydic[row["WORK_CODE"].ToString()] = false;
                                }

                                int iSeq = 1;
                                foreach (DataRow workRow in workRows)
                                {           
                                    DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
                                    DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

                                    DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
                                    DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);


                                    if (nextdaydic[row["WORK_CODE"].ToString()])
                                    {
                                        stdStartDate = stdStartDate.AddDays(1);
                                        stdEndDate = stdEndDate.AddDays(1);
                                    }

                                    //����ð��� ������� �Ϸ� ����
                                    if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
                                    {
                                        stdEndDate = stdEndDate.AddDays(1);

                                        nextdaydic[row["WORK_CODE"].ToString()] = true;
                                    }

                                    //if (workRows[0]["WORK_START_HOUR"].toInt() > workRow["WORK_START_HOUR"].toInt())
                                    //{
                                    //    stdStartDate = stdStartDate.AddDays(1);
                                    //    stdEndDate = stdEndDate.AddDays(1);
                                    //}

                                    TimeSpan ts = new TimeSpan();
                                    double time = 0.0;
                                    //�ð� ������ ����
                                    if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdEndDate) //��û�ð��� ���ؽð� ���۽ð��� ����ð��� ���ԵȰ��
                                    {
                                        ts = stdEndDate.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdStartDate) //���ؽ��۽ð��� ��û�ð� ���̿� �ִ°��
                                    {
                                        ts = reqEndDateTime.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (stdStartDate <= reqStartDateTime && stdEndDate >= reqEndDateTime) //���ؽð��� ��û�ð� ���۽ð��� ����ð��� ���ԵȰ��
                                    {
                                        ts = reqEndDateTime.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdEndDate && reqEndDateTime >= stdEndDate) //��������ð��� ��û�ð� ���̿� �ִ°��
                                    {
                                        ts = stdEndDate.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }

                                    if (time > 0)
                                    {
                                        //�հ� - ��������
                                        if (sumDic.ContainsKey(row["WORK_CODE"].ToString() + "_" + iSeq.ToString()))
                                        {
                                            sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] + Math.Round((time).toDecimal() / 60, 1);
                                        }
                                        else
                                        {
                                            sumDic.Add(row["WORK_CODE"].ToString() + "_" + iSeq.ToString(), newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }

                                        //�߰��ٹ��� ������ ���� ����ð�
                                        if (workRow["NIGHT_FLAG"].ToString() != "1")
                                        {
                                            //newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + Math.Round((time).toDecimal() / 60, 1).toDecimal();

                                            //�հ� - ��������
                                            if (sumDic.ContainsKey("CUM_TIME"))
                                            {
                                                //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                                sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                            }
                                            else
                                            {
                                                sumDic.Add("CUM_TIME", newRow["CUM_TIME"].toDecimal());
                                            }
                                        }                                        
                                    }

                                    iSeq++;
                                }

                                break;
                        }
                    }

                    //��,�� ���� ���� �ð� : (����/60 + ����/60 + ����/60 + ����/60) + �������� * 8  + ���� * 8
                    newRow["HOLI_TIME"] = (Math.Round((newRow["W01"].toDecimal() / 60), 2) + Math.Round((newRow["W02"].toDecimal() / 60), 2) + Math.Round((newRow["W03"].toDecimal() / 60), 2) + Math.Round((newRow["W04"].toDecimal() / 60), 2))
                       + (newRow["W05_W06"].toDecimal() * 8) + (newRow["W07"].toDecimal() * 8);

                    ////�հ� - ��������
                    //if (sumDic.ContainsKey("HOLI_TIME"))
                    //{
                    //    sumDic["HOLI_TIME"] = sumDic["HOLI_TIME"] + newRow["HOLI_TIME"].toDecimal();
                    //}
                    //else
                    //{
                    //    sumDic.Add("HOLI_TIME", newRow["HOLI_TIME"].toDecimal());
                    //}

                    //������
                    DataRow[] dayRows = e.result.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
                    if (dayRows.Length > 0)
                    {
                        newRow["WORK_DAY"] = dayRows[0]["WORK_DAY"];
                        newRow["WORK_MONTH_TIME"] = dayRows[0]["WORK_MONTH_TIME"];
                        newRow["WORK_HOUR"] = dayRows[0]["WORK_HOUR"];
                    }

                    //�Ǳٹ��ð� : (�⺻�ٹ��ð� + ���崩��ð�) - ��,�� ���⿬���ð�
                    newRow["WORK_TIME"] = newRow["WORK_HOUR"].toDecimal() + newRow["CUM_TIME"].toDecimal() - newRow["HOLI_TIME"].toDecimal();

                    //���ܿ��ð� : �����ִ�ð� - �Ǳٹ��ð�
                    newRow["REMAIN_TIME"] = newRow["WORK_MONTH_TIME"].toDecimal() - newRow["WORK_TIME"].toDecimal();

                    gridTable.Rows.Add(newRow);
                }

                //�հ�
                DataRow sumRow = gridTable.NewRow();
                sumRow["YEAR"] = "�հ�";

                foreach (DataColumn col in gridTable.Columns)
                {
                    if (sumDic.ContainsKey(col.ColumnName))
                    {
                        sumRow[col.ColumnName] = sumDic[col.ColumnName];
                    }
                }

                gridTable.Rows.Add(sumRow);

                //���
                DataRow useRow = gridTable.NewRow();
                useRow["YEAR"] = "���";
                useRow["W01"] = "���� : ";
                if (sumDic.ContainsKey("W05_W06"))
                {
                    useRow["W02"] = sumDic["W05_W06"];
                }

                //�б⺰ �ܿ��ð� : 1�б�
                int iquarter = 0;
                int remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 0)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 1)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow["W11_1"] = "1/4";
                useRow["W11_2"] = remainQuarter;
                gridTable.Rows.Add(useRow);

                //����
                DataRow conRow = gridTable.NewRow();
                conRow["YEAR"] = "����";
                conRow["W01"] = "���� : ";
                if (sumDic.ContainsKey("W07"))
                {
                    conRow["W02"] = sumDic["W07"];
                }

                //�б⺰ �ܿ��ð� : 2�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 3)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 4)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                conRow["W11_1"] = "2/4";
                conRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(conRow);

                //�߻�
                DataRow occRow = gridTable.NewRow();
                occRow["YEAR"] = "�߻�";
                occRow["W01"] = "���� : ";
                double dHoli = 0.0;
                if (e.result.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
                {
                    dHoli = e.result.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
                }
                occRow["W02"] = dHoli;


                //�б⺰ �ܿ��ð� : 3�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 6)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 7)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                occRow["W11_1"] = "3/4";
                occRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(occRow);

                //���
                DataRow useRow2 = gridTable.NewRow();
                useRow2["YEAR"] = "���";
                useRow2["W01"] = "���� : ";


                //�б⺰ �ܿ��ð� : 4�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 9)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 10)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow2["W11_1"] = "4/4";
                useRow2["W11_2"] = remainQuarter;

                gridTable.Rows.Add(useRow2);

                //����
                DataRow remainRow = gridTable.NewRow();
                remainRow["YEAR"] = "����";
                remainRow["W01"] = "���� : ";
                double dUseHoli = 0.0;
                if (sumDic.ContainsKey("W05_W06"))
                {
                    dUseHoli = sumDic["W05_W06"].toDouble();
                }

                remainRow["W02"] = dHoli - dUseHoli;
                gridTable.Rows.Add(remainRow);

                acBandGridView1.GridControl.DataSource = gridTable;
                acBandGridView1.OptionsView.ShowColumnHeaders = true;
                acBandGridView1.BestFitColumns();
                acBandGridView1.OptionsView.ShowColumnHeaders = false;

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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

        void SearchEmp()
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //
                paramTable.Columns.Add("IS_RETIRE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];

                paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");
                paramRow["IS_RETIRE"] = layoutRow["IS_RETIRE"];

                if (acCheckEdit1.Checked)
                {
                    paramRow["IS_RETIRE"] = null;
                }

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR08A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchEmp,
                QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchEmp(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow newAllRow = e.result.Tables["RSLTDT"].NewRow();
                newAllRow["PLT_CODE"] = acInfo.PLT_CODE;
                newAllRow["EMP_NAME"] = "��ü";

                e.result.Tables["RSLTDT"].Rows.InsertAt(newAllRow, 0);

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ
            try
            {
                this.SearchEmp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //���θ����
            try
            {
                if (!base.ChildFormContains("NEW"))
                { 

                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (focusRow == null) return;

                    WOR08A_D0A frm = new WOR08A_D0A(acGridView1, null, focusRow["EMP_CODE"].ToString());
                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //����
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                string formKey = string.Format("{0}", focusRow["WORK_ID"]);

                if (!base.ChildFormContains(formKey))
                {
                    WOR08A_D0A frm = new WOR08A_D0A(acGridView1, focusRow, focusRow["EMP_CODE"].ToString());
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(formKey, frm);

                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(formKey);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //����
            try
            {
                acGridView1.EndEditor();

                if (acMessageBox.Show(this, "���� �����Ͻðڽ��ϱ�?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No) return;

                //DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_ID", typeof(String)); //

                //���ϻ���
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_ID"] = focusRow["WORK_ID"];

                paramTable.Rows.Add(paramRow);

                //if (selected.Count == 0)
                //{
                //    //���ϻ���
                //    DataRow focusRow = acGridView1.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["WORK_ID"] = focusRow["WORK_ID"];

                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                //    //���߻���
                //    for (int i = 0; i < selected.Count; i++)
                //    {

                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //        paramRow["WORK_ID"] = selected[i]["WORK_ID"];

                //        paramTable.Rows.Add(paramRow);
                //    }

                //}

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                "WOR08A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                Search(true);

                //acGridView1.RaiseFocusedRowChanged();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void GetDetail()
        {
            if (acLayoutControl1.ValidCheck() == false) return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow focusRow = acGridView1.GetFocusedDataRow();
            if (focusRow == null)
            {
                acBandGridView1.ClearRow();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("S_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REQ_DATE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
            //paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
            //paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REQ_DATE":
                        paramRow["S_REQ_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REQ_DATE"] = layoutRow["E_DATE"];
                        break;
                }
            }

            paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "WOR01A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickDetailSearch,
            QuickException);
        }

        void QuickDetailSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("YEAR", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = focusRow["EMP_CODE"];

                paramRow["YEAR"] = layoutRow["S_DATE"].toDateTime().toDateString("yyyy");

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);

                DataSet empSet = BizRun.QBizRun.ExecuteService(this, "WOR08A_SER", paramSet, "RQSTDT", "RSLTDT");

                if (empSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acLayoutControl2.DataBind(empSet.Tables["RSLTDT"].Rows[0], false);
                }
                
                //DataRow focusRow = acGridView2.GetFocusedDataRow();

                //if (focusRow != null)
                //{
                //    acLayoutControl2.DataBind(focusRow, false);
                //}


                //�ٷ���Ȳ������ ����

                DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                //�հ� ���� dictionary
                Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["YEAR"] = i.ToString() + "��";

                    string month = e.result.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                    DataRow[] reqRwos = e.result.Tables["RSLTDT_YEAR"].Select("REQ_START_MONTH = '" + month + "'");

                    foreach (DataRow row in reqRwos)
                    {
                        //�д��� - ����(W01), ����(W02), ����(W03), ����(W04)
                        //�ϴ��� - ����/����(W05/W06), ����(W07)
                        //�ð����� - �ܾ�(W08), ����(W09), Ư��(W10), ���ϱ���(W11)
                        switch (row["WORK_CODE"].ToString())
                        {
                            case "W01": //����

                                newRow["W01"] = newRow["W01"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W01"))
                                {
                                    sumDic["W01"] = sumDic["W01"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W01", newRow["W01"].toDecimal());
                                }

                                break;

                            case "W02": //����

                                newRow["W02"] = newRow["W02"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W02"))
                                {
                                    sumDic["W02"] = sumDic["W02"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W02", newRow["W02"].toDecimal());
                                }

                                break;

                            case "W03": //����

                                newRow["W03"] = newRow["W03"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W03"))
                                {
                                    sumDic["W03"] = sumDic["W03"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W03", newRow["W03"].toDecimal());
                                }

                                break;

                            case "W04": //����

                                newRow["W04"] = newRow["W04"].toInt() + row["REQ_TIME"].toInt();

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W04"))
                                {
                                    sumDic["W04"] = sumDic["W04"] + row["REQ_TIME"].toInt();
                                }
                                else
                                {
                                    sumDic.Add("W04", newRow["W04"].toDecimal());
                                }

                                break;

                            case "W05": //����
                            case "W06": //����

                                newRow["W05_W06"] = Math.Round(((newRow["W05_W06"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W05_W06"))
                                {
                                    sumDic["W05_W06"] = sumDic["W05_W06"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W05_W06", newRow["W05_W06"].toDecimal());
                                }

                                break;

                            case "W07": //����

                                newRow["W07"] = Math.Round(((newRow["W07"].toDecimal() * 480) + row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);

                                //�հ� - ��������
                                if (sumDic.ContainsKey("W07"))
                                {
                                    sumDic["W07"] = sumDic["W07"] + Math.Round((row["REQ_TIME"].toDecimal()).toDecimal() / 480, 1);
                                }
                                else
                                {
                                    sumDic.Add("W07", newRow["W07"].toDecimal());
                                }

                                break;

                            case "W08": //�ܾ�
                            case "W09": //����
                            case "W10": //Ư��
                            case "W11": //���ϱ���

                                //�ٹ����¿� ���� ��,�߰� ����ȭ �ð��� �����´�.
                                DataTable idleTable = new DataTable("RQSTDT");
                                idleTable.Columns.Add("PLT_CODE", typeof(string));
                                idleTable.Columns.Add("EMP_CODE", typeof(string));
                                idleTable.Columns.Add("WORK_YEAR", typeof(string));
                                idleTable.Columns.Add("EWT_DATE", typeof(string));

                                DataRow idleRow = idleTable.NewRow();
                                idleRow["PLT_CODE"] = acInfo.PLT_CODE;
                                idleRow["EMP_CODE"] = row["EMP_CODE"];
                                idleRow["WORK_YEAR"] = row["REQ_START_DATE"].toDateTime().ToString("yyyy");
                                idleRow["EWT_DATE"] = row["REQ_START_DATE"].toDateTime().ToString("yyyyMMdd");

                                idleTable.Rows.Add(idleRow);
                                DataSet idleSet = new DataSet();
                                idleSet.Tables.Add(idleTable);

                                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER10", idleSet, "RQSTDT", "RSLTDT");

                                //IDLE_FLAG - 0 : �ְ� , 1 : �߰�
                                string idleFillter = "IDLE_FLAG = '0'";

                                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                                {
                                    if (resultSet.Tables["RSLTDT"].Rows[0]["EWT_TYPE"].ToString() == "1")
                                    {
                                        idleFillter = "IDLE_FLAG = '1'";
                                    }
                                }

                                //���ϱ����� ��� ���� �߰��ٹ���
                                if (row["WORK_CODE"].ToString() == "W11")
                                {
                                    idleFillter = "IDLE_FLAG = '1'";
                                }

                                //���ؽð��� �����ձ��ϱ�
                                //1.��û�ð��� ���ؽð� ���۽ð��� ����ð��� ���ԵȰ��
                                //2.���ؽ��۽ð��� ��û�ð� ���̿� �ִ°��
                                //3.���ؽð��� ��û�ð� ���۽ð��� ����ð��� ���ԵȰ��
                                //5.��������ð��� ��û�ð� ���̿� �ִ°��
                                DataRow[] workRows = _WorkTimeSet.Tables["RSLTDT"].Select("WORK_CODE = '" + row["WORK_CODE"].ToString() + "'");

                                Dictionary<string, bool> nextdaydic = new Dictionary<string, bool>();

                                if (!nextdaydic.ContainsKey(row["WORK_CODE"].ToString()))
                                {
                                    nextdaydic.Add(row["WORK_CODE"].ToString(), false);
                                }
                                else
                                {
                                    nextdaydic[row["WORK_CODE"].ToString()] = false;
                                }

                                int iSeq = 1;
                                foreach (DataRow workRow in workRows)
                                {
                                    DateTime reqStartDateTime = row["REQ_START_DATE"].toDateTime();
                                    DateTime reqEndDateTime = row["REQ_END_DATE"].toDateTime();

                                    DateTime stdStartDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_START_HOUR"].ToString().Substring(2, 2).toInt(), 0);
                                    DateTime stdEndDate = new DateTime(reqStartDateTime.Year, reqStartDateTime.Month, reqStartDateTime.Day, workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt(), workRow["WORK_END_HOUR"].ToString().Substring(2, 2).toInt(), 0);

                                    if (nextdaydic[row["WORK_CODE"].ToString()])
                                    {
                                        stdStartDate = stdStartDate.AddDays(1);
                                        stdEndDate = stdEndDate.AddDays(1);
                                    }

                                    //����ð��� ������� �Ϸ� ����
                                    if (workRow["WORK_START_HOUR"].ToString().Substring(0, 2).toInt() > workRow["WORK_END_HOUR"].ToString().Substring(0, 2).toInt())
                                    {
                                        stdEndDate = stdEndDate.AddDays(1);

                                        nextdaydic[row["WORK_CODE"].ToString()] = true;
                                    }

                                    //if (workRows[0]["WORK_START_HOUR"].toInt() > workRow["WORK_START_HOUR"].toInt())
                                    //{
                                    //    stdStartDate = stdStartDate.AddDays(1);
                                    //    stdEndDate = stdEndDate.AddDays(1);
                                    //}

                                    TimeSpan ts = new TimeSpan();
                                    double time = 0.0;
                                    //�ð� ������ ����
                                    if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdEndDate) //��û�ð��� ���ؽð� ���۽ð��� ����ð��� ���ԵȰ��
                                    {
                                        ts = stdEndDate.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdStartDate && reqEndDateTime >= stdStartDate) //���ؽ��۽ð��� ��û�ð� ���̿� �ִ°��
                                    {
                                        ts = reqEndDateTime.Subtract(stdStartDate);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(stdStartDate, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (stdStartDate <= reqStartDateTime && stdEndDate >= reqEndDateTime) //���ؽð��� ��û�ð� ���۽ð��� ����ð��� ���ԵȰ��
                                    {
                                        ts = reqEndDateTime.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, reqEndDateTime, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }
                                    else if (reqStartDateTime <= stdEndDate && reqEndDateTime >= stdEndDate) //��������ð��� ��û�ð� ���̿� �ִ°��
                                    {
                                        ts = stdEndDate.Subtract(reqStartDateTime);
                                        time = ts.TotalMinutes;
                                        time = time - GetIdleTime(reqStartDateTime, stdEndDate, idleFillter);
                                        newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = Math.Round(((newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDouble() * 60) + time).toDecimal() / 60, 1);
                                    }

                                    if (time > 0)
                                    {
                                        //�հ� - ��������
                                        if (sumDic.ContainsKey(row["WORK_CODE"].ToString() + "_" + iSeq.ToString()))
                                        {
                                            sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] = sumDic[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()] + Math.Round((time).toDecimal() / 60, 1);
                                        }
                                        else
                                        {
                                            sumDic.Add(row["WORK_CODE"].ToString() + "_" + iSeq.ToString(), newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }

                                        //�߰��ٹ��� ������ ���� ����ð�
                                        if (workRow["NIGHT_FLAG"].ToString() != "1")
                                        {
                                            //newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            newRow["CUM_TIME"] = newRow["CUM_TIME"].toDecimal() + Math.Round((time).toDecimal() / 60, 1).toDecimal();

                                            //�հ� - ��������
                                            if (sumDic.ContainsKey("CUM_TIME"))
                                            {
                                                //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                                sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                            }
                                            else
                                            {
                                                sumDic.Add("CUM_TIME", newRow["CUM_TIME"].toDecimal());
                                            }
                                        }
                                    }

                                    iSeq++;
                                }

                                break;
                        }
                    }

                    //��,�� ���� ���� �ð� : (����/60 + ����/60 + ����/60 + ����/60) + �������� * 8  + ���� * 8
                    newRow["HOLI_TIME"] = (Math.Round((newRow["W01"].toDecimal() / 60), 2) + Math.Round((newRow["W02"].toDecimal() / 60), 2) + Math.Round((newRow["W03"].toDecimal() / 60), 2) + Math.Round((newRow["W04"].toDecimal() / 60), 2))
                       + (newRow["W05_W06"].toDecimal() * 8) + (newRow["W07"].toDecimal() * 8);

                    ////�հ� - ��������
                    //if (sumDic.ContainsKey("HOLI_TIME"))
                    //{
                    //    sumDic["HOLI_TIME"] = sumDic["HOLI_TIME"] + newRow["HOLI_TIME"].toDecimal();
                    //}
                    //else
                    //{
                    //    sumDic.Add("HOLI_TIME", newRow["HOLI_TIME"].toDecimal());
                    //}

                    //������
                    DataRow[] dayRows = e.result.Tables["RSLTDT_WORKDAY"].Select("WORK_MONTH = '" + month + "'");
                    if (dayRows.Length > 0)
                    {
                        newRow["WORK_DAY"] = dayRows[0]["WORK_DAY"];
                        newRow["WORK_MONTH_TIME"] = dayRows[0]["WORK_MONTH_TIME"];
                        newRow["WORK_HOUR"] = dayRows[0]["WORK_HOUR"];
                    }

                    //�Ǳٹ��ð� : (�⺻�ٹ��ð� + ���崩��ð�) - ��,�� ���⿬���ð�
                    newRow["WORK_TIME"] = newRow["WORK_HOUR"].toDecimal() + newRow["CUM_TIME"].toDecimal() - newRow["HOLI_TIME"].toDecimal();

                    //���ܿ��ð� : �����ִ�ð� - �Ǳٹ��ð�
                    newRow["REMAIN_TIME"] = newRow["WORK_MONTH_TIME"].toDecimal() - newRow["WORK_TIME"].toDecimal();

                    gridTable.Rows.Add(newRow);
                }

                //�հ�
                DataRow sumRow = gridTable.NewRow();
                sumRow["YEAR"] = "�հ�";

                foreach (DataColumn col in gridTable.Columns)
                {
                    if (sumDic.ContainsKey(col.ColumnName))
                    {
                        sumRow[col.ColumnName] = sumDic[col.ColumnName];
                    }
                }

                gridTable.Rows.Add(sumRow);

                //���
                DataRow useRow = gridTable.NewRow();
                useRow["YEAR"] = "���";
                useRow["W01"] = "���� : ";
                if (sumDic.ContainsKey("W05_W06"))
                {
                    useRow["W02"] = sumDic["W05_W06"];
                }

                //�б⺰ �ܿ��ð� : 1�б�
                int iquarter = 0;
                int remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 0)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 1)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow["W11_1"] = "1/4";
                useRow["W11_2"] = remainQuarter;
                gridTable.Rows.Add(useRow);

                //����
                DataRow conRow = gridTable.NewRow();
                conRow["YEAR"] = "����";
                conRow["W01"] = "���� : ";
                if (sumDic.ContainsKey("W07"))
                {
                    conRow["W02"] = sumDic["W07"];
                }

                //�б⺰ �ܿ��ð� : 2�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 3)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 4)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                conRow["W11_1"] = "2/4";
                conRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(conRow);

                //�߻�
                DataRow occRow = gridTable.NewRow();
                occRow["YEAR"] = "�߻�";
                occRow["W01"] = "���� : ";
                double dHoli = 0.0;
                if (e.result.Tables["RSLTDT_EMP_HOLI"].Rows.Count > 0)
                {
                    dHoli = e.result.Tables["RSLTDT_EMP_HOLI"].Rows[0]["HOLI_OCCUR_INPUT_CNT"].toDouble();
                }
                occRow["W02"] = dHoli;


                //�б⺰ �ܿ��ð� : 3�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 6)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 7)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                occRow["W11_1"] = "3/4";
                occRow["W11_2"] = remainQuarter;

                gridTable.Rows.Add(occRow);

                //���
                DataRow useRow2 = gridTable.NewRow();
                useRow2["YEAR"] = "���";
                useRow2["W01"] = "���� : ";


                //�б⺰ �ܿ��ð� : 4�б�
                iquarter = 0;
                remainQuarter = 0;
                foreach (DataRow row in gridTable.Rows)
                {
                    if (iquarter >= 9)
                    {
                        remainQuarter = (remainQuarter.toDecimal() + (row["WORK_MONTH_TIME"].toDecimal() - row["WORK_TIME"].toDecimal())).toInt();

                        if (iquarter > 10)
                        {
                            break;
                        }
                    }
                    iquarter++;
                }

                useRow2["W11_1"] = "4/4";
                useRow2["W11_2"] = remainQuarter;

                gridTable.Rows.Add(useRow2);

                //����
                DataRow remainRow = gridTable.NewRow();
                remainRow["YEAR"] = "����";
                remainRow["W01"] = "���� : ";
                double dUseHoli = 0.0;
                if (sumDic.ContainsKey("W05_W06"))
                {
                    dUseHoli = sumDic["W05_W06"].toDouble();
                }

                remainRow["W02"] = dHoli - dUseHoli;
                gridTable.Rows.Add(remainRow);

                acBandGridView1.GridControl.DataSource = gridTable;
                acBandGridView1.OptionsView.ShowColumnHeaders = true;
                acBandGridView1.BestFitColumns();
                acBandGridView1.OptionsView.ShowColumnHeaders = false;

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        int GetIdleTime(DateTime startDate, DateTime endDate, String idleFilter)
        {
            int idleTime = 0;

            DataRow[] idleRows = _IdleSet.Tables["RSLTDT"].Select(idleFilter);

            foreach (DataRow row in idleRows)
            {
                string sIdleHour = row["IDLE_START_TIME"].ToString().Substring(0, 2);
                string sIdleMinute = row["IDLE_START_TIME"].ToString().Substring(2, 2);

                string eIdleHour = row["IDLE_END_TIME"].ToString().Substring(0, 2);
                string eIdleMinute = row["IDLE_END_TIME"].ToString().Substring(2, 2);

                DateTime idleStartTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, sIdleHour.toInt(), sIdleMinute.toInt(), 0);
                DateTime idleEndTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, eIdleHour.toInt(), eIdleMinute.toInt(), 0);

                if (startDate.Day != endDate.Day && (sIdleHour.toInt() >= 0 && sIdleHour.toInt() <= 7))
                {
                    idleStartTime = idleStartTime.AddDays(1);
                    idleEndTime = idleEndTime.AddDays(1);
                }

                TimeSpan idleTs = new TimeSpan();

                if (idleStartTime < startDate && idleEndTime > startDate)
                {
                    //����ȭ ���۽ð��� ��û���۽ð����� �۰ų� ���� ����ȭ ����ð��� ��û���۽ð����� Ŭ��
                    idleTs = idleEndTime.Subtract(startDate);

                }
                else if (idleStartTime >= startDate && idleEndTime <= endDate)
                {
                    //����ȭ ���۽ð� ����ð��� ��û�ð����̿� ���Եɶ�
                    idleTs = idleEndTime.Subtract(idleStartTime);
                }
                else if (idleStartTime < endDate && idleEndTime > endDate)
                {
                    //����ȭ ���۽ð��� ��û����ð����� �۰� ����ȭ ����ð��� ��û����ð����� Ŭ��
                    idleTs = endDate.Subtract(idleStartTime);
                }
                else if (idleStartTime <= startDate && idleEndTime >= endDate)
                {
                    //����ȭ �ð��� ��û�ð����� Ŭ��
                    idleTs = endDate.Subtract(startDate);
                }

                idleTime = idleTime + idleTs.TotalMinutes.toInt();
            }

            return idleTime;
        }
    }
}

