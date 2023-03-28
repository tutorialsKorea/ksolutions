using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlManager
{
    public partial class acWeekDate : UserControl
    {
        public delegate void PrevButtonClicked();

        public event PrevButtonClicked OnPrevButtonClick;

        public delegate void NextButtonClicked();

        public event NextButtonClicked OnNextButtonClick;

        public delegate void StartDateEnter();

        public event StartDateEnter OnStartDateEnter;

        public delegate void EndDateEnter();

        public event EndDateEnter OnEndDateEnter;

        public enum emWeekType
        {
            /// <summary>
            /// 월~금
            /// </summary>
            MonToFri,

            /// <summary>
            /// 월~일
            /// </summary>
            MonToSun
        }

        private emWeekType _weekType = emWeekType.MonToFri;

        [DefaultValue(emWeekType.MonToFri)]
        public emWeekType WeekType
        {
            get { return _weekType; }
            set
            {
                _weekType = value;
            }
        }

        public acWeekDate()
        {
            InitializeComponent();

            this.dtStart.EditValue = DateTime.Today;
            this.dtEnd.EditValue = DateTime.Today;

            dtStart.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            dtEnd.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;

            dtStart.KeyDown += dtStart_KeyDown;
            dtEnd.KeyDown += dtEnd_KeyDown;
        }

        public void SetType(DateType type)
        {
            switch (type)
            {
                case DateType.DATE:
                    cboSelect.SelectedIndex = 0;
                    this._type = DateType.DATE;
                    break;
                case DateType.WEEK:
                    cboSelect.SelectedIndex = 1;
                    this._type = DateType.WEEK;

                    SetWeekNo(dtStart.EditValue.toDateTime());
                    break;
            }
        }

        public void SetWeekNoRule(DevExpress.XtraEditors.Controls.WeekNumberRule rule)
        {
            dtStart.Properties.WeekNumberRule = rule;
            dtEnd.Properties.WeekNumberRule = rule;
        }

        private DateTime _startDate;
        private DateTime _endDate;
        private int _weekno;
        private int _endWeekno;
        private string _year;
        private string _endYear; //종료 년도
        private string _month;
        private DateType _type;
        private string _yearWeekNoS;
        private string _yearWeekNoE;

        private string _ColumnName = null;

        private DataRow _WeekRow;

        /// <summary>
        /// 컬럼명

        /// </summary>
        [DefaultValue(null)]
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }

        public enum DateType
        {
            DATE,
            WEEK
        }
        public DateTime StartDate
        {
            get { return this._startDate; }
        }

        public DateTime EndDate
        {
            get { return this._endDate; }
        }

        public int WeekNo
        {
            get { return this._weekno; }
        }
        public int EndWeekNo
        {
            get { return this._endWeekno; }
        }

        public string Year
        {
            get { return this._year; }
        }

        public string EndYear
        {
            get { return this._endYear; }
        }

        public string Month
        {
            get { return this._month; }
        }

        public string YearWeekNoS
        {
            get { return this._yearWeekNoS; }
        }

        public string YearWeekNoE
        {
            get { return this._yearWeekNoE; }
        }

        public DateType Type
        {
            get { return this._type; }
        }

        private string _labelText;

        public DataRow WeekRow
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("START_TIME", typeof(DateTime));
                dt.Columns.Add("END_TIME", typeof(DateTime));

                _WeekRow = dt.NewRow();
                _WeekRow["START_TIME"] = dtStart.DateTime;
                _WeekRow["END_TIME"] = dtEnd.DateTime;

                return this._WeekRow;
            }
        }

        public void SetWeekOnly()
        {
            cboSelect.SelectedIndex = 1;
            cboSelect.Properties.ReadOnly = true;
            cboSelect.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedText)
            {
                case "주차":
                    //dtControl.Enabled = true;
                    txtWeekNo.Enabled = true;
                    btnPrev.Enabled = true;
                    btnNext.Enabled = true;
                    _type = DateType.WEEK;
                    //dtStart.Properties.ReadOnly = true;
                    //dtEnd.Properties.ReadOnly = true;

                    SetWeekNo(dtStart.EditValue.toDateTime());
                    break;
                case "일자":
                    //dtControl.Enabled = false;
                    txtWeekNo.Enabled = false;
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    _type = DateType.DATE;
                    //dtStart.Properties.ReadOnly = false;
                    dtEnd.Properties.ReadOnly = false;

                    break;
            }
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            if (this._type == DateType.WEEK)
            {
                object newValue = ((DevExpress.XtraEditors.DateEdit)sender).EditValue;
                SetWeekNo(newValue.toDateTime());
            }
            else
            {
                this._startDate = dtStart.DateTime;
                //this._endDate = dtEnd.DateTime;

                //SetDateWeekNo();
            }
        }


        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {

            if (this._type == DateType.WEEK)
            {
                object newValue = ((DevExpress.XtraEditors.DateEdit)sender).EditValue;
                SetWeekNo(newValue.toDateTime());
            }
            else
            {

                this._endDate = dtEnd.DateTime;

                //SetEndDateWeekNo();
            }
        }

        private void SetWeekNo(DateTime s_date)
        {
            switch(_weekType)
            {
                case emWeekType.MonToFri:
                    
                        ExtensionMethods.GetJuStartEndDate(s_date, out this._startDate, out this._endDate);
                        dtStart.EditValue = this._startDate;
                        dtEnd.EditValue = this._endDate;

                        string strJuCha = ExtensionMethods.GetJuCha(s_date);
                        string strEJuCha = ExtensionMethods.GetJuCha(dtEnd.DateTime);


                        this._year = this._startDate.toDateString("yyyy");
                        this._endYear = this._endDate.toDateString("yyyy");
                        this._month = this._startDate.toDateString("MM");
                        this._weekno = strJuCha.toInt();
                        this._endWeekno = strEJuCha.toInt();

                        //this._yearWeekNoS = this._year +  this._weekno.ToString().PadLeft(2,'0');
                        //this._yearWeekNoE = this._endYear + this._endWeekno.ToString().PadLeft(2, '0');

                        this._yearWeekNoS = this._year + this._weekno.ToString();
                        this._yearWeekNoE = this._endYear + this._endWeekno.ToString();

                        txtWeekNo.EditValue = this._year + "-" + this._month + "  " + strJuCha + "주차";

                    break;


                case emWeekType.MonToSun:
                    
                        ExtensionMethods.GetJuFullStartEndDate(s_date, out this._startDate, out this._endDate);
                        dtStart.EditValue = this._startDate;
                        dtEnd.EditValue = this._endDate;

                        string strJuCha2 = ExtensionMethods.GetJuCha2(s_date);
                        string strEJuCha2 = ExtensionMethods.GetJuCha2(dtEnd.DateTime);


                        this._year = this._startDate.toDateString("yyyy");
                        this._endYear = this._endDate.toDateString("yyyy");
                        this._month = this._startDate.toDateString("MM");
                        this._weekno = strJuCha2.toInt();
                        this._endWeekno = strEJuCha2.toInt();

                        //this._yearWeekNoS = this._year +  this._weekno.ToString().PadLeft(2,'0');
                        //this._yearWeekNoE = this._endYear + this._endWeekno.ToString().PadLeft(2, '0');

                        this._yearWeekNoS = this._year + this._weekno.ToString();
                        this._yearWeekNoE = this._endYear + this._endWeekno.ToString();

                        txtWeekNo.EditValue = this._year + "-" + this._month + "  " + strJuCha2 + "주차";
                    
                    break;
            }            
        }

        private void SetDateWeekNo()
        {
            switch (_weekType)
            {
                case emWeekType.MonToFri:

                    ExtensionMethods.GetJuStartEndDate(dtStart.DateTime, out this._startDate, out this._endDate);

                    string strJuCha = ExtensionMethods.GetJuCha(dtStart.DateTime);

                    this._year = this._startDate.toDateString("yyyy");

                    this._month = this._startDate.toDateString("MM");
                    this._weekno = strJuCha.toInt();

                    txtWeekNo.EditValue = "";

                    this._yearWeekNoS = this._year + this._weekno.ToString();   //.PadRight(2, '0');

                    break;

                case emWeekType.MonToSun:

                    ExtensionMethods.GetJuFullStartEndDate(dtStart.DateTime, out this._startDate, out this._endDate);

                    string strJuCha2 = ExtensionMethods.GetJuCha2(dtStart.DateTime);

                    this._year = this._startDate.toDateString("yyyy");

                    this._month = this._startDate.toDateString("MM");
                    this._weekno = strJuCha2.toInt();

                    txtWeekNo.EditValue = "";

                    this._yearWeekNoS = this._year + this._weekno.ToString();   //.PadRight(2, '0');

                    break;
            }


        }

        private void SetEndDateWeekNo()
        {
            switch (_weekType)
            {
                case emWeekType.MonToFri:

                    ExtensionMethods.GetJuStartEndDate(dtStart.DateTime, out this._startDate, out this._endDate);


                    string strEJuCha = ExtensionMethods.GetJuCha(dtEnd.DateTime);


                    this._endYear = this._endDate.toDateString("yyyy");

                    this._endWeekno = strEJuCha.toInt();

                    txtWeekNo.EditValue = "";

                    this._yearWeekNoE = this._endYear + this._endWeekno.ToString();     //.PadRight(2, '0');

                    break;

                case emWeekType.MonToSun:

                    ExtensionMethods.GetJuFullStartEndDate(dtStart.DateTime, out this._startDate, out this._endDate);


                    string strEJuCha2 = ExtensionMethods.GetJuCha2(dtEnd.DateTime);


                    this._endYear = this._endDate.toDateString("yyyy");

                    this._endWeekno = strEJuCha2.toInt();

                    txtWeekNo.EditValue = "";

                    this._yearWeekNoE = this._endYear + this._endWeekno.ToString();     //.PadRight(2, '0');

                    break;
            }


        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime s_date = dtStart.DateTime.AddDays(-7);
            SetWeekNo(s_date);

            if (OnPrevButtonClick != null)
            {
                OnPrevButtonClick();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime s_date = dtStart.DateTime.AddDays(7);
            SetWeekNo(s_date);

            if (OnNextButtonClick != null)
            {
                OnNextButtonClick();
            }
        }

        private void dtStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OnStartDateEnter != null)
                {
                    if (this._type == DateType.WEEK)
                    {
                        txtWeekNo.Focus();
                        object newValue = ((DevExpress.XtraEditors.DateEdit)sender).EditValue;
                        ((DevExpress.XtraEditors.DateEdit)sender).Focus();
                        SetWeekNo(newValue.toDateTime());
                    }
                    else
                    {
                        this._startDate = dtStart.DateTime;
                    }

                    OnStartDateEnter();
                }
            }
        }

        private void dtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OnEndDateEnter != null)
                {
                    if (this._type == DateType.WEEK)
                    {
                        txtWeekNo.Focus();
                        object newValue = ((DevExpress.XtraEditors.DateEdit)sender).EditValue;
                        ((DevExpress.XtraEditors.DateEdit)sender).Focus();
                        SetWeekNo(newValue.toDateTime());
                    }
                    else
                    {
                        this._startDate = dtStart.DateTime;
                        //this._endDate = dtEnd.DateTime;

                        //SetDateWeekNo();
                    }

                    OnEndDateEnter();
                }
            }
        }


    }
}
