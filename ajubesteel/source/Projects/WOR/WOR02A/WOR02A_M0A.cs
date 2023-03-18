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
    public sealed partial class WOR02A_M0A : BaseMenu
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

        public WOR02A_M0A()
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
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            //_WorkSet = BizRun.QBizRun.ExecuteService(this, "WOR01A_SER2", acInfo.RefData, "RQSTDT", "RSLTDT");

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

            acBandGridView1.AddTextEdit("WORK_DAY", "���ٹ�\r\n�ϼ�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands8);
            
            acBandGridView1.AddTextEdit("WORK_MONTH_TIME", "����\r\n�ִ�\r\n�ð�\r\n(��52)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands9);
            
            acBandGridView1.AddTextEdit("WORK_HOUR", "�⺻�ٹ�\r\n�ϼ�\r\n(�ٹ��ϼ�*8)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands10);

            string[] bands11 = new string[] { "�ð����� ���", "��,��\r\n����\r\n����\r\n�ð�" };
            string[] bands12 = new string[] { "�ð����� ���", "�Ǳٹ��ð�" };
            string[] bands13 = new string[] { "�ð����� ���", "���ܿ�\r\n����\r\n�ð�" };
            string[] bands14 = new string[] { "�ð����� ���", "����\r\n����\r\n�ð�" };

            acBandGridView1.AddTextEdit("HOLI_TIME", "��,��\r\n����\r\n����\r\n�ð�", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands11);
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
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands2++;
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands3++;
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] bands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView1.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, bands);
                    acBandGridView1.Columns[row["WORK_CODE"].ToString() + "_" + iBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iBands4++;
                }
            }

            acBandGridView1.BestFitColumns();
            acBandGridView1.ColumnPanelRowHeight = 100;
            acBandGridView1.OptionsView.ShowColumnHeaders = false;

            acBandGridView1.Bands[0].Visible = false;

            acBandGridView1.CustomDrawCell += acBandGridView1_CustomDrawCell;
            acBandGridView1.FocusedRowChanged += acBandGridView1_FocusedRowChanged;


            acBandGridView2.OptionsView.AllowCellMerge = true;

            //�󼼱׸���
            string[] DetailBands1 = new string[] { "��¥", "��" };
            string[] DetailBands1_1 = new string[] { "��¥", "��" };
            acBandGridView2.AddTextEdit("MONTH", "��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands1);
            acBandGridView2.AddTextEdit("DAY", "��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands1_1);

            string[] DetailBands2 = new string[] { "�д��� ���", "����" };
            string[] DetailBands3 = new string[] { "�д��� ���", "����" };
            string[] DetailBands4 = new string[] { "�д��� ���", "����" };
            string[] DetailBands5 = new string[] { "�д��� ���", "����" };

            acBandGridView2.AddTextEdit("W01", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands2);
            acBandGridView2.AddTextEdit("W02", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands3);
            acBandGridView2.AddTextEdit("W03", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands4);
            acBandGridView2.AddTextEdit("W04", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands5);

            string[] DetailBands6 = new string[] { "�ϴ��� ���", "����\r\n����" };
            string[] DetailBands7 = new string[] { "�ϴ��� ���", "����" };

            acBandGridView2.AddTextEdit("W05_W06", "����\r\n����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands6);
            acBandGridView2.AddTextEdit("W07", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands7);

            int iDetailBands1 = 1;
            int iDetailBands2 = 1;
            int iDetailBands3 = 1;
            int iDetailBands4 = 1;
            foreach (DataRow row in _WorkTimeSet.Tables["RSLTDT"].Rows)
            {
                if (row["WORK_CODE"].ToString() == "W08")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands1.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands1.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands1++;
                }
                else if (row["WORK_CODE"].ToString() == "W09")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands2.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands2.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands2++;
                }
                else if (row["WORK_CODE"].ToString() == "W10")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands3.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands3.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands3++;
                }
                else if (row["WORK_CODE"].ToString() == "W11")
                {
                    string sTime = row["WORK_START_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_START_HOUR"].ToString().Substring(2, 2);
                    string eTime = row["WORK_END_HOUR"].ToString().Substring(0, 2) + ":" + row["WORK_END_HOUR"].ToString().Substring(2, 2);
                    string[] DetailBands = new string[] { "�ð����� ���", row["WORK_NAME"].ToString(), sTime, eTime, row["WORK_RATE"].ToString() };

                    acBandGridView2.AddTextEdit(row["WORK_CODE"].ToString() + "_" + iDetailBands4.ToString(), row["WORK_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.NONE, DetailBands);
                    acBandGridView2.Columns[row["WORK_CODE"].ToString() + "_" + iDetailBands4.ToString()].Tag = row["WORK_START_HOUR"].ToString() + "-" + row["WORK_END_HOUR"].ToString();
                    iDetailBands4++;
                }
            }


            foreach (acBandedGridColumn col in acBandGridView2.Columns)
            {
                if (col.FieldName == "MONTH")
                {
                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                {
                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                }
            }

            acBandGridView2.BestFitColumns();
            acBandGridView2.ColumnPanelRowHeight = 100;
            acBandGridView2.OptionsView.ShowColumnHeaders = false;
            acBandGridView2.Bands[0].Visible = false;
            acBandGridView2.CustomDrawCell += acBandGridView2_CustomDrawCell;

            (acLayoutControl1.GetEditor("YEAR") as acDateEdit).Properties.EditMask = "yyyy";

            base.MenuInit();
        }

        private void acBandGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                this.DetailGrid();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

        private void acBandGridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string dayValue = acBandGridView2.GetRowCellDisplayText(e.RowHandle, "DAY").ToString();

            if (dayValue == "��")
            {
                e.Appearance.BackColor = Color.DimGray;
                e.Appearance.ForeColor = Color.White;
            }

            string monValue = acBandGridView2.GetRowCellDisplayText(e.RowHandle, "MONTH").ToString();

            if (monValue.IndexOf("��") < 0 && monValue != "")
            {
                if (e.Column.FieldName == "MONTH"
                    || e.Column.FieldName == "DAY")
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }

                if ((e.Column.FieldName == "W02"
                        || e.Column.FieldName == "W03")
                    && (monValue == "�ܾ�" 
                        || monValue == "���� ����"))
                {
                    e.Appearance.BackColor = Color.Honeydew;
                }
            }

            if (dayValue.IndexOf("��") > -1)
            {
                if (e.Column.FieldName.StartsWith("W01")
                    || e.Column.FieldName.StartsWith("W02")
                    || e.Column.FieldName.StartsWith("W03")
                    || e.Column.FieldName.StartsWith("W04"))
                {
                    e.Appearance.BackColor = Color.WhiteSmoke;
                }
                else if (e.Column.FieldName.StartsWith("W05")
                        || e.Column.FieldName.StartsWith("W07"))
                {

                }
                else if (e.Column.FieldName.StartsWith("W08"))
                {
                    e.Appearance.BackColor = Color.Linen;
                }
                else if (e.Column.FieldName.StartsWith("W09"))
                {
                    e.Appearance.BackColor = Color.Cornsilk;
                }
                else if (e.Column.FieldName.StartsWith("W10"))
                {
                    e.Appearance.BackColor = Color.Azure;
                }
                else if (e.Column.FieldName.StartsWith("W11"))
                {
                    e.Appearance.BackColor = Color.FloralWhite;
                }
            }

            //if (e.Column.FieldName == "WORK_DAY"
            //    || e.Column.FieldName == "WORK_MONTH_TIME"
            //    || e.Column.FieldName == "WORK_HOUR")
            //{
            //    if (e.RowHandle < 12)
            //    {
            //        e.Appearance.BackColor = Color.LightGray;
            //    }
            //}

            //string sFirstColumn = acBandGridView1.GetRowCellDisplayText(e.RowHandle, "YEAR").ToString();

            //if (sFirstColumn == "�հ�")
            //{
            //    e.Appearance.BackColor = Color.DimGray;
            //    e.Appearance.ForeColor = Color.White;
            //}

            //if (sFirstColumn == "���"
            //    || sFirstColumn == "����"
            //    || sFirstColumn == "�߻�")
            //{
            //    if (e.Column.FieldName.Contains("W11"))
            //    {
            //        string[] cols = e.Column.FieldName.Split('_');

            //        int iCols = cols[1].toInt();

            //        if (iCols < 3)
            //        {
            //            e.Appearance.BackColor = Color.LightGreen;
            //            e.Appearance.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("YEAR").Value = acDateEdit.GetNowFirstYear();
                layout.GetEditor("EMP_CODE").Value = acInfo.UserID;
                layout.GetEditor("EMP_CODE").isReadyOnly = true;
            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_CODE":

                    DataRow empRow = (layout.GetEditor("EMP_CODE") as acEmp).SelectedRow;

                    layout.GetEditor("HIRE_DATE").Value = empRow["HIRE_DATE"];

                    Search();

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
            paramTable.Columns.Add("YEAR", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["YEAR"] = layoutRow["YEAR"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "WOR02A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //�ٷ���Ȳ������ ����
                _WorkSet = e.result;

                DataTable gridTable = ((DataTable)acBandGridView1.GridControl.DataSource).Clone();

                //�հ� ���� dictionary
                Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

                for (int i = 1; i <= 12; i++)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["YEAR"] = i.ToString() + "��";

                    string month = e.result.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + Convert.ToString(i).PadLeft(2, '0');

                    DataRow[] reqRwos = e.result.Tables["RSLTDT"].Select("REQ_START_MONTH = '" + month + "'");

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
                double dUseHoli = 0;
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


        void DetailGrid()
        {
            DataTable gridTable = ((DataTable)acBandGridView2.GridControl.DataSource).Clone();

            DataRow focusRow = acBandGridView1.GetFocusedDataRow();

            if (focusRow == null) return;

            if (focusRow["YEAR"].ToString().IndexOf("��") < 0) return;

            //����(W05),����(W07) ��¥ �ɰ���
            DataRow[] dayRows = _WorkSet.Tables["RSLTDT"].Select("WORK_CODE IN ('W05','W07')");

            foreach (DataRow row in dayRows)
            {
                int days = row["REQ_TIME"].toInt() / 480;

                for (int i = 0; i < days; i++)
                {
                    DateTime reqDateTime = row["REQ_START_DATE"].toDateTime().AddDays(i);

                    if (row["WORK_CODE"].ToString() != "W07")
                    {
                        DataRow[] holiRows = _WorkSet.Tables["RSLTDT_HOLI"].Select("HOLI_DATE = '" + reqDateTime.toDateString("yyyyMMdd") + "'");

                        if (holiRows.Length > 0
                            || reqDateTime.DayOfWeek == DayOfWeek.Saturday
                            || reqDateTime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            days++;
                            continue;
                        }
                    }

                    DataRow newRow = _WorkSet.Tables["RSLTDT"].NewRow();
                    newRow.ItemArray = row.ItemArray;

                    newRow["STR_REQ_DATE"] = reqDateTime.toDateString("yyyyMMdd");
                    newRow["REQ_START_DATE"] = reqDateTime;
                    newRow["REQ_END_DATE"] = reqDateTime;
                    newRow["REQ_TIME"] = 480;

                    _WorkSet.Tables["RSLTDT"].Rows.Add(newRow);
                }

                _WorkSet.Tables["RSLTDT"].Rows.Remove(row);
            }

            int yearidx = focusRow["YEAR"].ToString().IndexOf("��");

            string month = focusRow["YEAR"].ToString().Substring(0, yearidx);

            DateTime startDate = new DateTime(_WorkSet.Tables["RQSTDT"].Rows[0]["YEAR"].toInt(), month.toInt(), 1);
            DateTime first = startDate.AddDays(-(startDate.Day - 1));
            DateTime endDate = first.AddDays(DateTime.DaysInMonth(first.Year, first.Month) - 1);

            //�հ� ���� dictionary
            Dictionary<string, decimal> sumDic = new Dictionary<string, decimal>();

            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                DataRow newRow = gridTable.NewRow();
                newRow["MONTH"] = focusRow["YEAR"];
                newRow["DAY"] = dt.Day.ToString() + "��";

                string day = dt.toDateString("yyyyMMdd");

                DataRow[] reqRwos = _WorkSet.Tables["RSLTDT"].Select("STR_REQ_DATE = '" + day + "'");

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
                                        //�հ� - ��������
                                        if (sumDic.ContainsKey("CUM_TIME"))
                                        {
                                            //sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                            sumDic["CUM_TIME"] = sumDic["CUM_TIME"] + Math.Round((time).toDecimal() / 60, 1).toDecimal();
                                        }
                                        else
                                        {
                                            sumDic.Add("CUM_TIME", newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }
                                    }
                                    else
                                    {
                                        if (sumDic.ContainsKey("NIGHT_TIME"))
                                        {
                                            sumDic["NIGHT_TIME"] = sumDic["NIGHT_TIME"] + newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal();
                                        }
                                        else
                                        {
                                            sumDic.Add("NIGHT_TIME", newRow[row["WORK_CODE"].ToString() + "_" + iSeq.ToString()].toDecimal());
                                        }
                                    }
                                }

                                

                                

                                iSeq++;
                            }

                            break;
                    }
                }

                gridTable.Rows.Add(newRow);
            }

            //�հ�
            DataRow sumRow = gridTable.NewRow();
            sumRow["DAY"] = "��";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName))
                {
                    sumRow[col.ColumnName] = sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(sumRow);


            //�ܾ�
            DataRow remainRow = gridTable.NewRow();
            remainRow["MONTH"] = "�ܾ�";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W08"))
                {
                    remainRow["DAY"] = remainRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }

                //����ٹ� - �߰��ٹ�����
                remainRow["W02"] = "����ٹ�";
                if (sumDic.ContainsKey("CUM_TIME"))
                {
                    remainRow["W03"] = sumDic["CUM_TIME"];
                }
            }

            gridTable.Rows.Add(remainRow);

            //���� ����
            DataRow nomalRow = gridTable.NewRow();
            nomalRow["MONTH"] = "���� ����";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W09"))
                {
                    nomalRow["DAY"] = nomalRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            //�߰��ٹ�
            nomalRow["W02"] = "�߰��ٹ�";
            if (sumDic.ContainsKey("NIGHT_TIME"))
            {
                nomalRow["W03"] = sumDic["NIGHT_TIME"];
            }

            gridTable.Rows.Add(nomalRow);

            //Ư��
            DataRow specialRow = gridTable.NewRow();
            specialRow["MONTH"] = "Ư��";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W10"))
                {
                    specialRow["DAY"] = specialRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(specialRow);

            //���� ����
            DataRow holiWorkRow = gridTable.NewRow();
            holiWorkRow["MONTH"] = "���ϱ���";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W11"))
                {
                    holiWorkRow["DAY"] = holiWorkRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(holiWorkRow);

            //��,��,��,��
            DataRow minuteRow = gridTable.NewRow();
            minuteRow["MONTH"] = "��,��,��,��";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && (col.ColumnName.Contains("W01")
                        || col.ColumnName.Contains("W02")
                        || col.ColumnName.Contains("W03")
                        || col.ColumnName.Contains("W04")))
                {
                    minuteRow["DAY"] = minuteRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(minuteRow);

            //����,����
            DataRow holiRow = gridTable.NewRow();
            holiRow["MONTH"] = "����,����";

            foreach (DataColumn col in gridTable.Columns)
            {
                if (sumDic.ContainsKey(col.ColumnName)
                    && col.ColumnName.Contains("W05_W06"))
                {
                    holiRow["DAY"] = holiRow["DAY"].toDecimal() + sumDic[col.ColumnName];
                }
            }

            gridTable.Rows.Add(holiRow);


            acBandGridView2.GridControl.DataSource = gridTable;
            acBandGridView2.OptionsView.ShowColumnHeaders = true;
            acBandGridView2.BestFitColumns();
            acBandGridView2.OptionsView.ShowColumnHeaders = false;

        }

        int GetIdleTime(DateTime startDate, DateTime endDate, string idleFilter)
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

