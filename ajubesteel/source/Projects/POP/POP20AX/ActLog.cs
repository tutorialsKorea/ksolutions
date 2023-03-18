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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using BizManager;

namespace POP
{
    public partial class ActLog : BaseMenuDialog
    {
        private DateTime nowDate = DateTime.Today;
        private string _strWeek = "";
        private string _strMcCode = "";
        private DataRow _row = null;
        public ActLog(string mcCode)
        {
            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.LIST_USERCONFIG;

            acGridView1.AddTextEdit("PLT_CODE", "������ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_CODE", "�۾����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "�۾���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WORK_DATE", "�۾���", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "ǰ��", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "ǰ��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "�԰�", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("STD_PT_NUM", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CODE", "�����ڵ�", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("ACT_START_TIME", "������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "�Ϸ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("OK_QTY", "�Ϸ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("NG_QTY", "�ҷ�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            POP20A_M0A.SetPopGridFont(acGridView1,null);

            acGridView1.RowHeight = 50;
         
            TimeLabel.Appearance.Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 9,
                    FontStyle.Regular, GraphicsUnit.Point);

            Control[] con = POP20A_M0A.formcount(this);

            foreach (Control ctrs in con)
            {
                if (ctrs.Name.StartsWith("btn"))
                {

                    Control[] ctrls = this.Controls.Find(ctrs.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            _strMcCode = mcCode;
            _strWeek = GetJuCha(nowDate);

            DateTime sDate, eDate;
            this.GetJuStartEndDate(nowDate, out sDate, out eDate);

            TimeLabel.Text = sDate.toDateString("yy/MM/dd") + " �� " + eDate.toDateString("yy/MM/dd");

            #region �̺�Ʈ ����



            #endregion


        }

        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            this.Search();


        }
       

        private void OK()
        {
                this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ȯ��
            this.OK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //���
            this.DialogResult = DialogResult.Cancel;
        }

        void Search()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MC_CODE", typeof(String));
            paramTable.Columns.Add("PART_CODE", typeof(String));
            paramTable.Columns.Add("W_DATE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = _strMcCode;
            //paramRow["PART_CODE"] = DBNull.Value;
            paramRow["W_DATE"] = _strWeek;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD, "POP20A_SER8", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);
        }
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                //acGridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        // �ش������� �ּ��� �������� ���:
        private string GetJuCha(DateTime Date)
        {

            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("ko-KR");

            return myCI.Calendar.GetWeekOfYear

            (Date, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday).ToString();


        }

        //�ش������� �����Ͽ��� �ݿ��� ��������
        private void GetJuStartEndDate(DateTime date, out DateTime sDate, out DateTime eDate)
        {
            DateTime dtToday = date;

            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwToday = ciCurrent.Calendar.GetDayOfWeek(dtToday);

            int iDiff = dwToday - dwFirst;
            DateTime dtFirstDayOfThisWeek = dtToday.AddDays(-iDiff + 1);
            DateTime dtLastDayOfThisWeek = dtFirstDayOfThisWeek.AddDays(4);

            sDate = dtFirstDayOfThisWeek;
            eDate = dtLastDayOfThisWeek;
        }



        void moveWeek(double day)
        {

            _strWeek = GetJuCha(nowDate.AddDays(day));

            DateTime sDate, eDate;
            this.GetJuStartEndDate(nowDate.AddDays(day), out sDate, out eDate);

            nowDate = nowDate.AddDays(day);

            TimeLabel.Text = sDate.toDateString("yy/MM/dd") + " �� " + eDate.toDateString("yy/MM/dd");

            this.Search();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            moveWeek(7);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            moveWeek(-7);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

