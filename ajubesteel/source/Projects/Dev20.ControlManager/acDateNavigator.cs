using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Media;
using DevExpress.XtraEditors.Controls;

namespace ControlManager
{
	public class acDateNavigator : DevExpress.XtraScheduler.DateNavigator
	{

        public delegate void ChangeEditDateHandler(DevExpress.XtraEditors.Calendar.CalendarHitInfoType infoType);

        public event ChangeEditDateHandler OnChangeEditDate;

        public delegate void DateChangedHandler(DateTime value);

        public event DateChangedHandler OnDateChanged;

		DevExpress.XtraEditors.Calendar.CalendarHitInfoType _ClickType;
		private DataTable _HoliDayTable = null;


		[DefaultValue(null)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataTable HoliDayTable
		{
			get { return _HoliDayTable; }
			set
			{
				_HoliDayTable = value;


				this.Refresh();
			}
		}




		public acDateNavigator()
		{
			this.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
			this.CustomDrawDayNumberCell += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(SmartDateNavigator_CustomDrawDayNumberCell);
            this.MouseDown += AcDateNavigator_MouseDown;
		}

        private void AcDateNavigator_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraEditors.Calendar.CalendarHitInfo hitInfo = this.GetHitInfo(e);
			_ClickType = hitInfo.HitTest;
        }

		void SmartDateNavigator_CustomDrawDayNumberCell(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
		{

			if (acInfo.IsRunTime == true)
			{

				if (e.Selected == true)
				{
					e.Graphics.FillRectangle(Brushes.SkyBlue, e.Bounds);
				}
				else
				{
					e.Graphics.FillRectangle(Brushes.White, e.Bounds);
				}

				Font fontBold = new Font(e.Style.Font, FontStyle.Regular);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Far;

				Brush WeekColor = Brushes.Black;

				switch (e.Date.DayOfWeek)
				{
					case DayOfWeek.Monday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("MONDAY_COLOR").toColor());
						break;
					case DayOfWeek.Tuesday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("TUESDAY_COLOR").toColor());
						break;
					case DayOfWeek.Wednesday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("WEDNESDAY_COLOR").toColor());
						break;
					case DayOfWeek.Thursday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("THURSDAY_COLOR").toColor());
						break;
					case DayOfWeek.Friday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("FRIDAY_COLOR").toColor());
						break;
					case DayOfWeek.Saturday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("SATURDAY_COLOR").toColor());
						break;
					case DayOfWeek.Sunday:
						WeekColor = new SolidBrush(acInfo.SysConfig.GetSysConfigByMemory("SUNDAY_COLOR").toColor());
						break;
				}

				e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, WeekColor, e.Bounds, sf);

				if (_HoliDayTable != null)
				{
					DataRow[] drArr = _HoliDayTable.Select("HOLI_DATE = '" + e.Date.ToString("yyyyMMdd") + "'");

					if (drArr.Length != 0)
					{
						e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, Brushes.Red, e.Bounds, sf);
					}
				}

				e.Handled = true;
			}
		}

        private int _MaxCalendar = 1;


        [DefaultValue(1)]
        public int MaxCalendar
        {
            get { return _MaxCalendar; }
            set { _MaxCalendar = value; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (this._MaxCalendar > 0)
            {
                if (this.CalendarViewInfo.Calendars.Count > this._MaxCalendar)
                {

                    for (int i = _MaxCalendar; i < this.CalendarViewInfo.Calendars.Count; i++)
                    {
						this.CalendarViewInfo.Calendars.RemoveAt(i);

                        --i;
                    }
                }

            }
            base.OnPaint(e);
        }


        protected override void CheckDateTimeChanged(DateTime prevDate)
		{
			switch (_ClickType)
			{
				case DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecMonth:
				case DevExpress.XtraEditors.Calendar.CalendarHitInfoType.DecYear:
				case DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncMonth:
				case DevExpress.XtraEditors.Calendar.CalendarHitInfoType.IncYear:
					{
						if (this.OnChangeEditDate != null)
						{
							this.OnChangeEditDate(_ClickType);
						}
						break;
					}
				default:
					{
						if (!this.DateTime.Equals(prevDate))
						{
							if (this.OnDateChanged != null)
							{
								this.OnDateChanged(DateTime);
							}
						}
						break;
					}
			}
		}

        protected override DateTime ChangeSelectedDay(DateTime value)
		{
			return base.ChangeSelectedDay(value);
		}

		public DateTime StartDateTime
		{
			get
			{
				return this.GetStartDate();

			}
		}

		public DateTime EndDateTime
		{
			get
			{

				return this.GetEndDate();


			}
		}


	}
}
