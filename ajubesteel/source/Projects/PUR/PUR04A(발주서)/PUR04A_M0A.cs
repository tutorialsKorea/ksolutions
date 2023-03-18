using BizManager;
using ControlManager;
using DevExpress.Spreadsheet;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSpreadsheet;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PUR
{
    public sealed partial class PUR04A_M0A : BaseMenu
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

        private Color _progColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_PROG").toColor();
        private Color _okColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_OK").toColor();
        private Color _denyColor = acInfo.SysConfig.GetSysConfigByMemory("APP_STATE_DENY").toColor();

        public PUR04A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;
            acGridView4.FocusedRowChanged += acGridView1_FocusedRowChanged;

            acGridView2.FocusedRowChanged += AcGridView2_FocusedRowChanged;
            acGridView5.FocusedRowChanged += AcGridView2_FocusedRowChanged;

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
            DataSet empResultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_EMPLOYEE", acInfo.RefData, "RQSTDT", "RSLTDT");

            //���� ������
            acGridView1.GridType = acGridView.emGridType.LIST;
            acGridView1.AddLookUpEdit("BAL_TYPE", "����", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
            //acGridView1.AddTextEdit("BAL_TYPE", "����", "40957", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_CODE", "�ŷ�ó�ڵ�", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("VEN_NAME", "�ŷ�ó��", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.GridType = acGridView.emGridType.SEARCH;
            acGridView2.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "40203", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("BALJU_DATE", "������", "40206", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("REG_EMP", "�������ڵ�", "N089BVX6", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "�����ڸ�", "HEP4DK2T", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("BAL_TYPE", "����", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("INCL_VAT", "�ΰ�������", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("SPLIT", "���ҳ�ǰ", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("DELIVERY_LOCATION", "��ǰ���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PAY_CONDITION", "��������", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("YPGO_CHARGE", "�԰���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("CHK_MEASURE", "ġ���˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("CHK_PERFORM", "���ɰ˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("CHK_ATTEND", "��ȸ�˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("CHK_TEST", "�˻缺����", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddCheckEdit("CHK_RD", "�������ߺ�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("CHK_ADD1", "��Ÿ1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHK_ADD2", "��Ÿ2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CHK_ADD3", "��Ÿ3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SCOMMENT", "Ư�����", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("USE_GLOBAL", "�ؿܹ��ּ� ��뿩��", "", false, false, false, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("PO_NO", "PO NO.", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("DELIVERY", "Delivery", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("SHIP_DATE", "Ship date", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("SHIPMENT", "Shipment", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddLookUpEdit("APP_EMP1", "������1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG1", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("APP_EMP2", "������2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG2", "������2����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("APP_EMP3", "������3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG3", "������3����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("APP_EMP4", "������4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView2.AddTextEdit("APP_EMP_FLAG4", "������4����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddHidden("APP_STATUS", typeof(string));

            acGridView3.GridType = acGridView.emGridType.SEARCH;
            acGridView3.AddLookUpEdit("BAL_STAT", "���ֻ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S043");
            acGridView3.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("BALJU_SEQ", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("DETAIL_PART_NAME", "���� �����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView3.AddLookUpEdit("PART_PRODTYPE", "�з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView3.AddLookUpEdit("MAT_TYPE", "���źз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S016");
            acGridView3.AddLookUpEdit("MAT_LTYPE", "��з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView3.AddLookUpEdit("MAT_MTYPE", "�ߺз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView3.AddLookUpVendor("MVND_CODE", "����ó", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddDateEdit("BALJU_DATE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddDateEdit("DUE_DATE", "�԰�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddTextEdit("STATUS", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("QTY", "���ּ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddLookUpEdit("MAT_UNIT", "����", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView3.AddTextEdit("UNIT_COST", "�ܰ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("AMT", "�ݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpEdit("PART_CAT", "ǰ������", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "P030");

            acGridView3.AddTextEdit("REAL_AMT", "���� �Աݱݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("BANK", "����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PUR_VEN_ACCOUNT", "������", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("BANK_NO", "���¹�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };

            acGridView7.GridType = acGridView.emGridType.AUTO_COL;
            acGridView7.AddTextEdit("SUBJECT", "����", "40203", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("BODY", "����", "40203", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView7.AddDateEdit("BODY", "����", "40206", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView7.AddTextEdit("FROM", "������ ���", "N089BVX6", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("TO", "�޴� ���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("CC", "����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView7.AddTextEdit("ATTATCH_FILE", "÷������", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddTextEdit("RESULT", "�߼۰��", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView7.AddDateEdit("REG_DATE", "�߼۽ð�", "", false, HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView7.AddTextEdit("LINK_NO", "����Ű", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView8.GridType = acGridView.emGridType.AUTO_COL;
            acGridView8.AddDateEdit("REG_DATE", "��½ð�", "", false, HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView8.AddLookUpEmp("REG_EMP", "�����", "", false, HorzAlignment.Center, false, true, false);

            acGridView4.GridType = acGridView.emGridType.LIST;
            //acGridView4.AddLookUpEdit("BAL_TYPE", "����", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S047");
            acGridView4.AddTextEdit("VEN_CODE", "�ŷ�ó�ڵ�", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView4.AddTextEdit("VEN_NAME", "�ŷ�ó��", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView5.GridType = acGridView.emGridType.SEARCH;
            acGridView5.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "40203", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddDateEdit("BALJU_DATE", "������", "40206", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView5.AddTextEdit("REG_EMP", "�������ڵ�", "N089BVX6", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("REG_EMP_NAME", "�����ڸ�", "HEP4DK2T", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView5.AddCheckEdit("INCL_VAT", "�ΰ�������", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddCheckEdit("SPLIT", "���ҳ�ǰ", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddTextEdit("DELIVERY_LOCATION", "��ǰ���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("PAY_CONDITION", "��������", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("YPGO_CHARGE", "�԰���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddCheckEdit("CHK_MEASURE", "ġ���˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddCheckEdit("CHK_PERFORM", "���ɰ˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddCheckEdit("CHK_ATTEND", "��ȸ�˻�", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddCheckEdit("CHK_TEST", "�˻缺����", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddCheckEdit("CHK_MEEL", "MEEL SHEET", "", false, false, true, acGridView.emCheckEditDataType._STRING);
            acGridView5.AddTextEdit("CHK_ADD1", "��Ÿ1", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("CHK_ADD2", "��Ÿ2", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("CHK_ADD3", "��Ÿ3", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddTextEdit("SCOMMENT", "Ư�����", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView5.AddTextEdit("PO_NO", "PO NO.", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddDateEdit("DELIVERY", "Delivery", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView5.AddDateEdit("SHIP_DATE", "Ship date", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView5.AddDateEdit("SHIPMENT", "Shipment", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView5.AddLookUpEdit("APP_EMP1", "������1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView5.AddTextEdit("APP_EMP_FLAG1", "������1����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddLookUpEdit("APP_EMP2", "������2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView5.AddTextEdit("APP_EMP_FLAG2", "������2����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddLookUpEdit("APP_EMP3", "������3", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView5.AddTextEdit("APP_EMP_FLAG3", "������3����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView5.AddLookUpEdit("APP_EMP4", "������4", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "EMP_NAME", "EMP_CODE", empResultSet.Tables["RSLTDT"]);
            acGridView5.AddTextEdit("APP_EMP_FLAG4", "������4����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView5.AddHidden("APP_STATUS", typeof(string));

            acGridView5.KeyColumn = new string[] { "BALJU_NUM" };

            acGridView6.GridType = acGridView.emGridType.SEARCH;
            acGridView6.AddLookUpEdit("BAL_STAT", "���ֻ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S043");
            acGridView6.AddTextEdit("BALJU_NUM", "���ֹ�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("BALJU_SEQ", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("PROD_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("WO_NO", "�۾����ù�ȣ", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("PART_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddTextEdit("PART_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView6.AddLookUpEdit("PART_PRODTYPE", "�з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
            acGridView6.AddLookUpEdit("MAT_LTYPE", "��з�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView6.AddLookUpVendor("OVND_CODE", "����ó", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView6.AddDateEdit("BALJU_DATE", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView6.AddDateEdit("DUE_DATE", "�԰�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView6.AddTextEdit("QTY", "���ּ���", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView6.AddLookUpEdit("MAT_UNIT", "����", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView6.AddTextEdit("UNIT_COST", "�ܰ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView6.AddTextEdit("AMT", "�ݾ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView6.AddTextEdit("SCOMMENT", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEmp("REG_EMP", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView6.AddLookUpEmp("STATUS", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
            acGridView6.AddTextEdit("MAT_SPEC", "���", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView6.AddLookUpEdit("MAT_TYPE", "���źз�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S016");
            acGridView6.KeyColumn = new string[] { "BALJU_NUM", "BALJU_SEQ" };


            acGridView9.GridType = acGridView.emGridType.AUTO_COL;
            acGridView9.AddTextEdit("SUBJECT", "����", "40203", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("BODY", "����", "40203", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("FROM", "������ ���", "N089BVX6", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("TO", "�޴� ���", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("CC", "����", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView9.AddTextEdit("ATTATCH_FILE", "÷������", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddTextEdit("RESULT", "�߼۰��", "HEP4DK2T", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView9.AddDateEdit("REG_DATE", "�߼۽ð�", "", false, HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView9.AddTextEdit("LINK_NO", "����Ű", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView10.GridType = acGridView.emGridType.AUTO_COL;
            acGridView10.AddDateEdit("REG_DATE", "��½ð�", "", false, HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
            acGridView10.AddLookUpEmp("REG_EMP", "�����", "", false, HorzAlignment.Center, false, true, false);

            acGridView7.ShowGridMenuEx += acGridView7_ShowGridMenuEx;
            acGridView9.ShowGridMenuEx += acGridView9_ShowGridMenuEx;

            acCheckedComboBoxEdit1.AddItem("������", true, "40206", "BALJU_DATE", true, false);

            _selectedPage = "MAT";

            acGridView2.CustomDrawCell += acGridView_CustomDrawCell;
            acGridView5.CustomDrawCell += acGridView_CustomDrawCell;

            this.acGridView5.ShowGridMenuEx += AcGridView5_ShowGridMenuEx;


            this.acGridView2.ShowGridMenuEx += AcGridView5_ShowGridMenuEx;

            radioButton2.Checked = true;

            base.MenuInit();

        }

        private void acGridView7_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void acGridView9_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            
            acGridView view = sender as acGridView;

            if (view.FocusedRowHandle < 0)
            {
                return;
            }

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }


        private void AcGridView5_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //������ Row�� �����ؾ� �˾�â�� ����.

            acGridView gridView = sender as acGridView;

            if (gridView.FocusedRowHandle < 0)
            {
                return;
            }

            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "BALJU_DATE";

                layout.GetEditor("S_DATE").Value = System.DateTime.Now.AddDays(-7);

                layout.GetEditor("E_DATE").Value = System.DateTime.Now;
            }

            base.ChildContainerInit(sender);
        }

        private void acGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                acGridView gridView = sender as acGridView;

                if (e.RowHandle < 0) return;

                string app1 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG1").ToString();
                string app2 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG2").ToString();
                string app3 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG3").ToString();
                string app4 = gridView.GetRowCellValue(e.RowHandle, "APP_EMP_FLAG4").ToString();

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

            switch (flag)
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


        void acGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.GetList();
        }

        private void AcGridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
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

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {

                    case "BALJU_DATE":

                        //������
                        paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];

                        break;

                }

            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (_selectedPage == "MAT")
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR04A_SER", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];
                //acGridView1.SetOldFocusRowHandle(true);
            }
            else
            {
                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "PUR04A_SER4", paramSet, "RQSTDT", "RSLTDT");

                acGridView4.GridControl.DataSource = dsResult.Tables["RSLTDT"];
                //acGridView4.SetOldFocusRowHandle(true);
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

        void GetList()
        {
            try
            {

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow focusRow = acGridView1.GetFocusedDataRow();
                string ruleName = "PUR04A_SER2";

                if (_selectedPage == "OUT")
                {
                    focusRow = acGridView4.GetFocusedDataRow();
                    ruleName = "PUR04A_SER3";
                }
                    
                if (focusRow == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("BAL_TYPE", typeof(String)); //
                paramTable.Columns.Add("S_BALJU_DATE", typeof(String)); //
                paramTable.Columns.Add("E_BALJU_DATE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CODE"] = focusRow["VEN_CODE"];
                paramRow["S_BALJU_DATE"] = layoutRow["S_DATE"];
                paramRow["E_BALJU_DATE"] = layoutRow["E_DATE"];
                if (_selectedPage == "MAT")
                    paramRow["BAL_TYPE"] = focusRow["BAL_TYPE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //DataSet dsResult = BizRun.QBizRun.ExecuteService(this, ruleName, paramSet, "RQSTDT", "RSLTDT");

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL, ruleName, paramSet, "RQSTDT", "RSLTDT",
                    QuickListDetail,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickListDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_selectedPage == "MAT")
                {
                    acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    acGridView2.BestFitColumns();
                    //acGridView2.SetOldFocusRowHandle(true);
                }
                else
                {
                    acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    acGridView5.BestFitColumns();
                    //acGridView5.SetOldFocusRowHandle(true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void GetDetail()
        {
            
            DataRow focusRow = acGridView2.GetFocusedDataRow();

            if (_selectedPage == "OUT")
            {
                focusRow = acGridView5.GetFocusedDataRow();
            }

            if (focusRow == null)
            {
                if (_selectedPage == "OUT")
                {
                    acGridView6.ClearRow();
                    acGridView9.ClearRow();
                    acGridView10.ClearRow();
                }
                else
                {
                    acGridView3.ClearRow();
                    acGridView7.ClearRow();
                    acGridView8.ClearRow();
                }
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
            paramTable.Columns.Add("BAL_TYPE", typeof(String)); //
            paramTable.Columns.Add("LINK_NO", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
            paramRow["LINK_NO"] = focusRow["BALJU_NUM"];
            if (_selectedPage == "MAT")
                paramRow["BAL_TYPE"] = focusRow["BAL_TYPE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (_selectedPage == "MAT")
            {
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD_DETAIL, "PUR04A_SER5", paramSet, "RQSTDT", "RSLTDT",
                    QuickDetail,
                    QuickException);
            }
            else
            {
                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD_DETAIL, "PUR03A_SER2", paramSet, "RQSTDT", "RSLTDT",
                        QuickDetail,
                        QuickException);
            }

        }

        void QuickDetail(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (_selectedPage == "MAT")
                {
                    acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    //acGridView3.SetOldFocusRowHandle(false);

                    acGridView7.GridControl.DataSource = e.result.Tables["RSLTDT_MAIL"];
                    acGridView8.GridControl.DataSource = e.result.Tables["RSLTDT_PRINT"];
                }
                else
                {
                    acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT"];
                    //acGridView6.SetOldFocusRowHandle(false);
                    acGridView9.GridControl.DataSource = e.result.Tables["RSLTDT_MAIL"];
                    acGridView10.GridControl.DataSource = e.result.Tables["RSLTDT_PRINT"];
                }

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //���ּ� ���
            try
            {
                if (_selectedPage == "PUR")
                {
                    if (acGridView3.FocusedRowHandle < 0) return;
                    
                }
                else
                {
                    if (acGridView6.FocusedRowHandle < 0) return;
                }
                acMessageBox.Show("���ּ� ��� ��� �ʿ�.", "���ּ� ���", acMessageBox.emMessageBoxType.CONFIRM);
                
                
                //DataView view = acGridView2.GetDataSourceView("SEL = '1'");

                //DataRow focusRow = acGridView1.GetFocusedDataRow();

                //DataSet dataSource = new DataSet();

                //DataTable master = focusRow.NewTable();
                //master.TableName = "M";

                //DataTable detail = view.ToTable();
                //detail.TableName = "D";

                //dataSource.Tables.AddRange(new DataTable[] { master, detail });


                ////���ּ�
                //ReportManager.acReportView.ShowReportCategoryPreview(this, "DEFAULT", dataSource);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private DataRow _drMaster = null;
        private DataTable _dtDetail = null;


        private ControlManager.QThread _writeThread = null;

        SpreadsheetControl spreadsheetControl1 = null;
        IWorkbook workBook = null;

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool isPrice = true;

                if (radioButton1.Checked)
                {
                    isPrice = false;
                }
                else if (radioButton2.Checked)
                {
                    isPrice = true;
                }


                if (_selectedPage == "MAT")
                {
                    _drMaster = acGridView2.GetFocusedDataRow();
                    _dtDetail = acGridView3.GridControl.DataSource as DataTable;

                    //WriteXlsx();

                    PUR04A_D0A frm = new PUR04A_D0A(_drMaster, _dtDetail, isPrice);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        GetDetail();
                    }
                }
                else if (_selectedPage == "OUT")
                {

                    DataRow focusedrow = acGridView5.GetFocusedDataRow();

                    if (focusedrow.isNullOrEmpty()) { return; }

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE");
                    paramTable.Columns.Add("BALJU_NUM");

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BALJU_NUM"] = focusedrow["BALJU_NUM"];
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "PUR04A_SER3", paramSet, "RQSTDT", "RSLTDT");

                    DataRow masterRow = resultSet.Tables["RSLTDT"].Rows[0];
                    DataTable dtDetail = acGridView6.GridControl.DataSource as DataTable;

                    PUR04A_D0A frm = new PUR04A_D0A(masterRow, dtDetail, isPrice);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    frm.ShowDialog();
                }

                

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //���ּ� ���� ����

            DataRow focusRow = null;
            if (_selectedPage == "MAT")
            {
                focusRow = acGridView2.GetFocusedDataRow();
            }
            else if (_selectedPage == "OUT")
            {
                focusRow = acGridView5.GetFocusedDataRow();
            }

            PUR04A_D1A frm = new PUR04A_D1A(focusRow);

            frm.ParentControl = this;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow frmRow = (DataRow)frm.OutputData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("BALJU_NUM", typeof(string));
                paramTable.Columns.Add("DELIVERY", typeof(string));
                paramTable.Columns.Add("SHIP_DATE", typeof(string));
                paramTable.Columns.Add("SHIPMENT", typeof(string));
                paramTable.Columns.Add("PO_NO", typeof(string));
                paramTable.Columns.Add("TYPE", typeof(string));

                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BALJU_NUM"] = focusRow["BALJU_NUM"];
                paramRow["DELIVERY"] = frmRow["DELIVERY"];
                paramRow["SHIP_DATE"] = frmRow["SHIP_DATE"];
                paramRow["SHIPMENT"] = frmRow["SHIPMENT"];
                paramRow["PO_NO"] = frmRow["PO_NO"];
                paramRow["TYPE"] = _selectedPage;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "PUR04A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

            }

        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (_selectedPage == "MAT")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acGridView2.UpdateMapingRow(row, false);
                    }
                }
                else if (_selectedPage == "OUT")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acGridView5.UpdateMapingRow(row, false);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //����
                if (_selectedPage == "MAT")
                {
                    DataRow focusRow = acGridView7.GetFocusedDataRow();

                    PUR04A_D2A frm = new PUR04A_D2A(focusRow);
                    frm.ParentControl = this;
                    frm.Text = "���� ���� ����";
                    frm.Show();
                }
                else if (_selectedPage == "OUT")
                {
                    DataRow focusRow = acGridView9.GetFocusedDataRow();

                    PUR04A_D2A frm = new PUR04A_D2A(focusRow);
                    frm.ParentControl = this;
                    frm.Text = "���� ���� ����";
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}

