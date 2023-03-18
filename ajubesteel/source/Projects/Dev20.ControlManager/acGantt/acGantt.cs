using System;
using System.Collections.Generic;
using System.Text;
using PlexityHide.GTP;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Globalization;
using BizManager;

namespace ControlManager
{

    [Serializable]
    public class acGanntGridColumnSerializable : ISerializable
    {


        public acGanntGridColumnSerializable()
            : base()
        {

        }

        public int UserIndex = 0;

        public string ColumnName = null;

        public int Width = 0;

        public acGanntGridColumnSerializable(SerializationInfo info, StreamingContext context)
        {

            try
            {
                this.ColumnName = (string)info.GetValue("ColumnName", typeof(string));
            }
            catch
            {

            }

            try
            {
                this.UserIndex = (int)info.GetValue("UserIndex", typeof(int));
            }
            catch
            {

            }

            try
            {
                this.Width = (int)info.GetValue("Width", typeof(int));
            }
            catch
            {

            }

        }


        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ColumnName", this.ColumnName, typeof(string));

            info.AddValue("UserIndex", this.UserIndex, typeof(int));

            info.AddValue("Width", this.Width, typeof(int));

        }

        #endregion


    }


    public class acGanntGridColumn : PlexityHide.GTP.GridColumn
    {
        private string _ColumnName = null;

        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }


        public acGanntGridColumn()
            : base()
        {

        }

        private int _UserIndex = 0;

        public int UserIndex
        {
            get { return _UserIndex; }
            set { _UserIndex = value; }
        }


    }

    public enum emGanttVerticalLineType { NONE, WHOLE, GRID_NODE };


    public class acGanttVerticalLine
    {
        public emGanttVerticalLineType GanttVerticalLineType = emGanttVerticalLineType.NONE;


        public DateTime DateTime = DateTime.MinValue;

        public string Comment = null;

        public Color LineColor = Color.Empty;

        public bool IsBestFit = false;

        public GridNode Node = null;


    }

    public class GanttToolTipEventArgs
    {
        private string _Title = null;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Content = null;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private bool _Cancel = true;

        public bool Cancel
        {
            get { return _Cancel; }
            set { _Cancel = value; }
        }


    }

    public class acGantt : PlexityHide.GTP.Gantt
    {

        private System.Windows.Forms.Timer hoverTimeItemTimer;

        private int _HoverTimeItemTimerInterval = 300;
        public int _HoverTimerCnt = 4;

        private Control _ParentControl = null;

        /// <summary>
        /// 부모컨트롤
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set
            {
                _ParentControl = value;

            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.ParentControl == null)
            {
                this.ParentControl = this.GetContainerControl() as Control;
            }

        }

        private double _AddMinutesValue = 0;


        /// <summary>
        /// Stop 타임 추가 시간(분)
        /// </summary>
        public double AddMinutesValue
        {
            get { return _AddMinutesValue; }
            set { _AddMinutesValue = value; }
        }



        private DevExpress.Utils.ToolTipController _GanttToolTipController = null;


        public delegate void TimeItemShowToolTipEventHandler(TimeItem ti, GanttToolTipEventArgs e);

        /// <summary>
        /// 툴팁 보여주기전에 이벤트
        /// </summary>
        public event TimeItemShowToolTipEventHandler OnTimeItemBeginShowToolTip;

        public delegate void ProcessKeyPreviewEventHandler(ref Message m);

        public event ProcessKeyPreviewEventHandler OnProcessKeyPreviewEventHandler;


        protected override bool ProcessKeyPreview(ref Message m)
        {

            if (this.OnProcessKeyPreviewEventHandler != null)
            {
                this.OnProcessKeyPreviewEventHandler(ref m);
            }

            return base.ProcessKeyPreview(ref m);
        }




        public acGantt()
            : base()
        {

        }



        void acGantt_OnDialogLoadManager(object sender)
        {
            this.LoadUserConfig();
        }

        void acGantt_OnMenuLoadManager(object sender)
        {
            this.LoadUserConfig();
        }


        void acGantt_OnDialogDestory(object sender)
        {
            this.SaveUserConfig();
        }

        void acGantt_OnMenuDestory(object sender)
        {
            this.SaveUserConfig();
        }




        public acGantt(System.ComponentModel.IContainer container)
            : base(container)
        {


            this.OnTimeItemAreaPaintBackground += new OffscreenDrawEvent(acGantt_OnTimeItemAreaPaintBackground);

            this.OnTimeItemAreaPaintForeground += new OffscreenDrawEvent(acGantt_OnTimeItemAreaPaintForeground);

            this.OnDateScalerDrawString += new DateScalerDrawStringEventHandler(acGantt_OnDateScalerDrawString);

            this.OnTimeItem_Hoover += new TimeItemEvent(acGantt_OnTimeItem_Hoover);
            this.OnGridMouseWheel += new MouseEventHandler(acGantt_OnGridMouseWheel);
            this.OnDateScalerScaleChangeEvent += new EventHandler(acGantt_OnDateScalerScaleChangeEvent);
            this.OnDateScalerMouseDown += new MouseEventHandler(acGantt_OnDateScalerMouseDown);

            this.OnTimeItem_SelectionChanged += new TimeItemEvent(acGantt_OnTimeItem_SelectionChanged);


            this.OnTimeItemAreaMouseDown += new MouseEventHandler(acGantt_OnTimeItemAreaMouseDown);

            this.OnTimeItemLink_SelectionChanged += new TimeItemLinkHandler(acGantt_OnTimeItemLink_SelectionChanged);

            _GanttToolTipController = new ToolTipController();

            hoverTimeItemTimer = new System.Windows.Forms.Timer();

            hoverTimeItemTimer.Interval = HoverTimeItemTimerInterval;

            hoverTimeItemTimer.Tick += new EventHandler(hoverTimeItemTimer_Tick);


            if (acInfo.IsRunTime == true)
            {

                hoverTimeItemTimer.Start();
            }


            this.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
            this.Grid.Font = DevExpress.Utils.AppearanceObject.DefaultFont;
            this.TimeItemArea.Font = DevExpress.Utils.AppearanceObject.DefaultFont;



        }



        private TimeItemLink _SelectedTimeItemLink = null;

        public TimeItemLink SelectedTimeItemLink
        {
            get { return _SelectedTimeItemLink; }
            set { _SelectedTimeItemLink = value; }
        }


        void acGantt_OnTimeItemLink_SelectionChanged(TimeItemLinks aLinks, TimeItemLinkArgs args)
        {
            if (args.TimeItemLink != null)
            {

                this._SelectedTimeItemLink = args.TimeItemLink;


            }
            else
            {
                this._SelectedTimeItemLink = null;
            }

        }



        void acGantt_OnTimeItemAreaMouseDown(object sender, MouseEventArgs e)
        {


            Point pt = new Point(e.X, e.Y);

            TimeItem ti = this.TimeItemFromPoint(pt.X, pt.Y);

            GanttRow row = this.GanttRowFromPoint(pt);

            if (row != null && ti == null && this._SelectedTimeItemLink == null)
            {

                if (this.Grid.GridStructure.FocusedCell != null)
                {
                    this.ClearGridSelected();
                }

                row.GridNode.GetCell(0).Selected = true;

            }
        }

        void acGantt_OnDateScalerDrawString(DateScaler dateScaler, DateScalerDrawStringEventArgs e)
        {

            if (e.Resolution == NonLinearTime.TimeResolution.hours ||
                e.Resolution == NonLinearTime.TimeResolution.hours3 ||
                e.Resolution == NonLinearTime.TimeResolution.hours6)
            {

                List<string> dayNames = new List<string>(DateTimeFormatInfo.CurrentInfo.DayNames);

                if (dayNames.Contains(e.OutputText))
                {

                    e.OutputText = e.DateTime.ToString(acInfo.SysConfig.GetSysConfigByMemory("GANTT_DAYOFWEEK_DISPLAY_TYPE"));


                    e.ContinueDraw = true;
                }

            }
            else if (e.Resolution == NonLinearTime.TimeResolution.days)
            {

                if (e.pos.Y > 30)
                {
                    e.OutputText = e.DateTime.ToString(acInfo.SysConfig.GetSysConfigByMemory("GANTT_DAY_DISPLAY_TYPE"));

                    e.ContinueDraw = true;
                }

            }




        }

        void acGantt_OnTimeItemAreaPaintForeground(OffscreenDraw aOffscreenDraw, OffscreenDrawArgs e)
        {


            if (acInfo.SysConfig.GetSysConfigByMemory("GANTT_DISPLAY_TIMELINE").toBoolean() == true)
            {
                int days = 1;

                while (true)
                {

                    DateTime dt = this.DateScaler.StartTime.Date.AddDays(days);

                    if (dt > this.DateScaler.StopTime)
                    {

                        break;

                    }


                    Color penColor = acInfo.SysConfig.GetSysConfigByMemory("GANTT_TIMELINE_COLOR").toColor();

                    Pen linePen = new Pen(penColor);

                    TimeSpan t = acInfo.SysConfig.GetSysConfigByMemory("GANTT_TIMELINE_DISPLAY_TIME").toTimeSpan();


                    int x = this.DateScaler.TimeToPixel(dt.Add(t));

                    e.G.DrawLine(linePen, x, this.TimeItemArea.CalcTop, x, this.TimeItemArea.CalcBottom);

                    ++days;
                }

            }


            List<DrawVerticalLine> verticalCommentRectangles = new List<DrawVerticalLine>();


            foreach (KeyValuePair<string, acGanttVerticalLine> verticalLine in this._GanntVerticalLineDic)
            {
                Brush bs = new SolidBrush(verticalLine.Value.LineColor);

                Pen pen = new Pen(bs, 2);

                int x = this.DateScaler.TimeToPixel(verticalLine.Value.DateTime);

                if (verticalLine.Value.GanttVerticalLineType == emGanttVerticalLineType.WHOLE)
                {

                    if (this.TimeItemArea.FlipView)
                    {
                        e.G.DrawLine(pen, this.TimeItemArea.CalcLeft, x, this.TimeItemArea.CalcWidth, x);
                    }
                    else
                    {
                        e.G.DrawLine(pen, x, this.TimeItemArea.CalcTop, x, this.TimeItemArea.CalcBottom);
                    }

                    //글꼴 사이즈를 알아온다.
                    Size fnSize = Size.Ceiling(e.G.MeasureString(verticalLine.Value.Comment, this.Font));


                    int y = this.TimeItemArea.CalcBottom - (this.DateScaler.Height + fnSize.Height);


                    Rectangle rect = new Rectangle(new Point(x, y), new Size(fnSize.Width, fnSize.Height));

                    DrawVerticalLine vline = new DrawVerticalLine();

                    vline.Rect = rect;
                    vline.Text = verticalLine.Value.Comment;
                    vline.TextColor = verticalLine.Value.LineColor;

                    verticalCommentRectangles.Add(vline);

                }
                else if (verticalLine.Value.GanttVerticalLineType == emGanttVerticalLineType.GRID_NODE)
                {
                    Rectangle nodeRect = verticalLine.Value.Node.Rect();

                    if (nodeRect.Top > 0 && nodeRect.Bottom > 0)
                    {


                        e.G.DrawLine(pen, x, nodeRect.Top - 18, x, nodeRect.Bottom - 18);

                        //글꼴 사이즈를 알아온다.
                        Size fnSize = Size.Ceiling(e.G.MeasureString(verticalLine.Value.Comment, this.Font));

                        int y = nodeRect.Bottom + 26 - (this.DateScaler.Height + fnSize.Height);

                        Rectangle rect = new Rectangle(new Point(x, y), new Size(fnSize.Width, fnSize.Height));

                        DrawVerticalLine vline = new DrawVerticalLine();

                        vline.Rect = rect;
                        vline.Text = verticalLine.Value.Comment;
                        vline.TextColor = verticalLine.Value.LineColor;

                        verticalCommentRectangles.Add(vline);

                    }


                }




            }

            //중첩 좌표가 없을때까지 반복
            while (true)
            {
                bool r = false;

                for (int i = 0; i < verticalCommentRectangles.Count; i++)
                {

                    for (int j = 0; j < verticalCommentRectangles.Count; j++)
                    {
                        if (i != j)
                        {
                            if (verticalCommentRectangles[i].Rect.IntersectsWith(verticalCommentRectangles[j].Rect) == true)
                            {
                                if (verticalCommentRectangles[j].Rect.Y < 0)
                                {
                                    break;
                                }


                                verticalCommentRectangles[j].Rect = new Rectangle(
                                    verticalCommentRectangles[j].Rect.X,
                                    verticalCommentRectangles[j].Rect.Y - verticalCommentRectangles[j].Rect.Height,
                                    verticalCommentRectangles[j].Rect.Width,
                                    verticalCommentRectangles[j].Rect.Height);

                                r = true;

                            }
                        }
                    }
                }

                if (r == false)
                {
                    break;
                }


            }


            //버티컬 텍스트 표시
            for (int i = 0; i < verticalCommentRectangles.Count; i++)
            {

                Brush bs = new SolidBrush(verticalCommentRectangles[i].TextColor);

                Size fSize = Size.Ceiling(e.G.MeasureString(verticalCommentRectangles[i].Text, this.Font));

                Rectangle rect = new Rectangle(verticalCommentRectangles[i].Rect.X + 2, verticalCommentRectangles[i].Rect.Y, fSize.Width, fSize.Height);

                //텍스트 배경
                e.G.FillRectangle(Brushes.Transparent, rect);


                //텍스트
                e.G.DrawString(verticalCommentRectangles[i].Text, this.Font, bs, verticalCommentRectangles[i].Rect.X, verticalCommentRectangles[i].Rect.Y);

            }
        }



        TimeItemLayout tempTimeItemLayout = new TimeItemLayout();

        TimeItemTextLayout tempTimeItemTextLayout = new TimeItemTextLayout();

        public void ResetSelectedTimeItemLayout()
        {
            tempTimeItemLayout = null;
            tempTimeItemTextLayout = null;

        }




        void acGantt_OnTimeItem_SelectionChanged(Gantt aGantt, TimeItemEventArgs e)
        {
            try
            {
                if (e.TimeItem != null)
                {
                    if (e.TimeItem.Selected == true)
                    {

                        tempTimeItemLayout = e.TimeItem.TimeItemLayout.Clone() as TimeItemLayout;

                        tempTimeItemTextLayout = e.TimeItem.TimeItemTexts[0].TimeItemTextLayout.Clone() as TimeItemTextLayout;


                        TimeItemLayout newTimeItemLayout = new TimeItemLayout();

                        newTimeItemLayout = e.TimeItem.TimeItemLayout.Clone() as TimeItemLayout;


                        newTimeItemLayout.Color = acInfo.SysConfig.GetSysConfigByMemory("GANTT_SELECTED_ITEM_COLOR").toColor();

                        newTimeItemLayout.SelectHandles = acInfo.SysConfig.GetSysConfigByMemory("GANTT_SELECTED_ITEM_COLOR").toColor();

                        e.TimeItem.TimeItemTexts[0].TimeItemTextLayout.Color = acColorEdit.GetReverseColor(acInfo.SysConfig.GetSysConfigByMemory("GANTT_SELECTED_ITEM_COLOR").toColor());

                        e.TimeItem.TimeItemLayout = newTimeItemLayout;


                    }
                    else
                    {


                        if (tempTimeItemLayout != null)
                        {
                            e.TimeItem.TimeItemLayout.Color = tempTimeItemLayout.Color;

                            e.TimeItem.TimeItemLayout.SelectHandles = tempTimeItemLayout.SelectHandles;
                        }

                        if (tempTimeItemTextLayout != null)
                        {
                            e.TimeItem.TimeItemTexts[0].TimeItemTextLayout.Color = tempTimeItemTextLayout.Color;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == "인덱스가 범위를 벗어났습니다. 인덱스는 음수가 아니어야 하며 컬렉션의 크기보다 작아야 합니다.\r\n매개 변수 이름: index")
                {
                    return;
                }
                else
                {
                    acMessageBox.Show(this, ex);
                }
            }
        }

        void acGantt_OnDateScalerMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                this.BestFitDateScaler();
            }

        }


        public DateTime OldDateScalerStartTime = DateTime.MinValue;


        public DateTime OldDateScalerStopTime = DateTime.MinValue;


        public void SetOldDateScaler()
        {
            this.DateScaler.StartTime = this.OldDateScalerStartTime;
            this.DateScaler.StopTime = this.OldDateScalerStopTime;

            this.ReSizeRowHeight(this._RowHeight, this.Grid.GridStructure.RootNodes);
        }


        private bool _IsSaveOldDateScaler = false;

        [DefaultValue(false)]
        public bool IsSaveOldDateScaler
        {
            get { return _IsSaveOldDateScaler; }
            set { _IsSaveOldDateScaler = value; }
        }


        void acGantt_OnDateScalerScaleChangeEvent(object sender, EventArgs e)
        {
            if (this._IsSaveOldDateScaler == true)
            {
                this.OldDateScalerStartTime = this.DateScaler.StartTime;
                this.OldDateScalerStopTime = this.DateScaler.StopTime;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (acInfo.IsRunTime == true)
            {
                this.GridProperties.CellLayouts[0].Font = DevExpress.Utils.AppearanceObject.DefaultFont;

                this.DateScalerHeight = this.DateScalerHeight = (DevExpress.Utils.AppearanceObject.DefaultFont.Size * 5).toInt();

                this.DateScaler.Font = DevExpress.Utils.AppearanceObject.DefaultFont;


            }

            if (this.ParentControl is BaseMenu)
            {
                BaseMenu b = this.ParentControl as BaseMenu;

                b.OnMenuLoadManager += new BaseMenu.MenuLoadManagerEventHandler(acGantt_OnMenuLoadManager);
                b.OnMenuDestory += new BaseMenu.MenuDestoryEventHandler(acGantt_OnMenuDestory);

            }
            else if (this.ParentControl is BaseMenuDialog)
            {
                BaseMenuDialog b = this.ParentControl as BaseMenuDialog;

                b.OnDialogLoadManager += new BaseMenuDialog.DialogLoadManagerEventHandler(acGantt_OnDialogLoadManager);
                b.OnDialogDestory += new BaseMenuDialog.DialogDestoryEventHandler(acGantt_OnDialogDestory);
            }


            base.OnHandleCreated(e);
        }



        void acGantt_OnTimeItem_Hoover(Gantt aGantt, TimeItemEventArgs e)
        {
            if (e.TimeItem == null)
            {
                this._GanttToolTipController.HideHint();

                this._StopHitCnt = 0;
            }
        }






        /// <summary>
        /// 사용자 UI 저장
        /// </summary>
        private void SaveUserConfig()
        {

            acGanttUserConfig config = new acGanttUserConfig(this);

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //
            paramTable.Columns.Add("CONFIG_NAME", typeof(String)); //
            paramTable.Columns.Add("DEFAULT_USE", typeof(String)); //기본UI로 설정
            paramTable.Columns.Add("LAYOUT", typeof(Byte[])); //
            paramTable.Columns.Add("OBJECT", typeof(Byte[])); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = this.ParentControl.Name;
            paramRow["CONTROL_NAME"] = this.Name;
            paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
            paramRow["DEFAULT_USE"] = "1";
            paramRow["LAYOUT"] = null;
            paramRow["OBJECT"] = config.ToArray();
            paramRow["OVERWRITE"] = "1";
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            //BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);
        }

        private void LoadUserConfig()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = this.ParentControl.Name;
            paramRow["CONTROL_NAME"] = this.Name;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {
                //사용자 UI 불러오기

                byte[] configData = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["OBJECT"];

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acGanttUserConfigSerializationBinder();

                acGanttUserConfig config = (acGanttUserConfig)bformatter.Deserialize(loadConfigSt, null);

                this.AddMinutesValue = config.AddMinutesValue;

                this.RowHeight = config.RowHeight;

                this.GridWidth = config.GridWidth;


                //컬럼 설정 불러오기

                foreach (KeyValuePair<string, object> column in config.ColumnDic)
                {
                    acGanntGridColumn targetCol = this.GetColumn(column.Key);

                    acGanntGridColumnSerializable srz = (acGanntGridColumnSerializable)column.Value;

                    if (targetCol != null)
                    {

                        targetCol.Width = srz.Width;

                        this.Grid.Columns.Move(targetCol.Index, srz.UserIndex);
                    }

                }

            }
        }



        /// <summary>
        /// 기준 아이템 중심으로 시간상 뒤에 아이템을 찾는다.
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        public TimeItem GetAfterTimeItem(TimeItem standard)
        {
            TimeItem findItem = null;


            for (int timeCnt = 0; timeCnt < standard.GanttRow.Layers[0].Count; ++timeCnt)
            {

                if (standard.GanttRow.Layers[0][timeCnt].Start > standard.Stop)
                {
                    if (findItem == null)
                    {
                        findItem = standard.GanttRow.Layers[0][timeCnt];
                    }
                    else
                    {
                        if (standard.GanttRow.Layers[0][timeCnt].Start < findItem.Start)
                        {
                            findItem = standard.GanttRow.Layers[0][timeCnt];
                        }
                    }

                }

            }


            return findItem;

        }


        /// <summary>
        /// 기준 아이템 중심으로 시간상 앞에 아이템을 찾는다.
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        public TimeItem GetBeforeTimeItem(TimeItem standard)
        {
            TimeItem findItem = null;


            for (int timeCnt = 0; timeCnt < standard.GanttRow.Layers[0].Count; ++timeCnt)
            {

                if (standard.GanttRow.Layers[0][timeCnt].Stop < standard.Start)
                {
                    if (findItem == null)
                    {
                        findItem = standard.GanttRow.Layers[0][timeCnt];
                    }
                    else
                    {
                        if (standard.GanttRow.Layers[0][timeCnt].Stop > findItem.Stop)
                        {
                            findItem = standard.GanttRow.Layers[0][timeCnt];
                        }
                    }

                }

            }


            return findItem;

        }



        private Point _TimeItemAreaPoint = Point.Empty;

        private int _StopHitCnt = 0;

        private TimeItem _HitTimeItem = null;

        void hoverTimeItemTimer_Tick(object sender, EventArgs e)
        {

            if (this.TimeItemArea == null)
            {
                this._GanttToolTipController.HideHint();

                this._StopHitCnt = 0;

                return;
            }

            if (WIN32API.WindowFromPoint(Control.MousePosition.X, Control.MousePosition.Y) != (IntPtr)this.TimeItemArea.Handle)
            {
                this._GanttToolTipController.HideHint();

                this._StopHitCnt = 0;

                return;
            }


            TimeItem ti = this.TimeItemFromPoint(this._TimeItemAreaPoint);


            if (this._HitTimeItem != ti)
            {
                this._HitTimeItem = ti;

                this._GanttToolTipController.HideHint();

                this._StopHitCnt = 0;

                return;
            }


            if (ti != null)
            {

                if (this._StopHitCnt == this._HoverTimerCnt)
                {
                    if (this.OnTimeItemBeginShowToolTip != null)
                    {
                        if (this.Enabled == true)
                        {
                            GanttToolTipEventArgs toolTipArgs = new GanttToolTipEventArgs();

                            this.OnTimeItemBeginShowToolTip(ti, toolTipArgs);


                            if (toolTipArgs.Cancel == false)
                            {
                                SuperToolTip superTT = new SuperToolTip();

                                ToolTipTitleItem titleTT = new ToolTipTitleItem();

                                ToolTipItem contentTT = new ToolTipItem();

                                if (!string.IsNullOrEmpty(toolTipArgs.Title))
                                {
                                    titleTT.Text = toolTipArgs.Title;
                                    superTT.Items.Add(titleTT);
                                }

                                if (!string.IsNullOrEmpty(toolTipArgs.Content))
                                {
                                    contentTT.Text = toolTipArgs.Content;
                                    superTT.Items.Add(contentTT);

                                }

                                DevExpress.Utils.ToolTipControllerShowEventArgs args = new DevExpress.Utils.ToolTipControllerShowEventArgs();

                                args.SuperTip = superTT;

                                args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;

                                this._GanttToolTipController.ShowHint(args, Control.MousePosition);
                            }
                        }


                    }

                    this._StopHitCnt = 0;

                }

                ++this._StopHitCnt;

            }


            this._TimeItemAreaPoint = this.TimeItemArea.PointToClient(Control.MousePosition);



        }


        public void ShowHint(string title, string content)
        {
            SuperToolTip superTT = new SuperToolTip();

            ToolTipTitleItem titleTT = new ToolTipTitleItem();

            ToolTipItem contentTT = new ToolTipItem();

            titleTT.Text = title;
            contentTT.Text = content;

            superTT.Items.Add(titleTT);
            superTT.Items.Add(contentTT);

            DevExpress.Utils.ToolTipControllerShowEventArgs args = new DevExpress.Utils.ToolTipControllerShowEventArgs();

            args.SuperTip = superTT;

            args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;

            this._GanttToolTipController.ShowHint(args, Control.MousePosition);
        }




        Dictionary<string, acGanttVerticalLine> _GanntVerticalLineDic = new Dictionary<string, acGanttVerticalLine>();



        public void AddColumn(string columnName, string caption, string resourceID, CellType cellType, bool readOnly, bool hide)
        {
            acGanntGridColumn col = new acGanntGridColumn();

            col.ColumnName = columnName;


            col.Type = cellType;

            col.Title = acInfo.Resource.GetString(caption, resourceID);

            col.ReadOnly = readOnly;

            col.Hide = hide;

            col.ColumnCell.Layout = new CellLayout();

            col.ColumnCell.Layout.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            col.ColumnCell.Layout.HorzAlign = StringAlignment.Center;

            col.ColumnCell.Layout.VertAlign = StringAlignment.Center;


            col.Tree = true;


            this.Grid.Columns.Add(col);

        }

        public void AddColumn(string columnName, string caption, string resourceID, bool useReSourceID, CellType cellType, bool readOnly, bool hide)
        {
            acGanntGridColumn col = new acGanntGridColumn();

            col.ColumnName = columnName;


            col.Type = cellType;

            if (useReSourceID == true)
            {
                col.Title = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Title = caption;
            }

            col.ReadOnly = readOnly;

            col.Hide = hide;

            col.ColumnCell.Layout = new CellLayout();

            col.ColumnCell.Layout.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            col.ColumnCell.Layout.HorzAlign = StringAlignment.Center;

            col.ColumnCell.Layout.VertAlign = StringAlignment.Center;


            col.Tree = true;


            this.Grid.Columns.Add(col);

        }

        public void AddColumn(string columnName, string caption, int colWidth, string resourceID, CellType cellType, bool readOnly, bool hide)
        {
            acGanntGridColumn col = new acGanntGridColumn();

            col.ColumnName = columnName;


            col.Type = cellType;

            col.Title = acInfo.Resource.GetString(caption, resourceID);

            col.ReadOnly = readOnly;

            col.Hide = hide;

            col.ColumnCell.Layout = new CellLayout();

            col.ColumnCell.Layout.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            col.ColumnCell.Layout.HorzAlign = StringAlignment.Center;

            col.ColumnCell.Layout.VertAlign = StringAlignment.Center;

            col.Width = colWidth;

            col.Tree = true;


            this.Grid.Columns.Add(col);

        }

        public void AddColumn(string columnName, string caption, int colWidth, string resourceID, CellType cellType, bool readOnly, bool hide, bool useReSourceID)
        {
            acGanntGridColumn col = new acGanntGridColumn();

            col.ColumnName = columnName;


            col.Type = cellType;

            if (useReSourceID == true)
            {
                col.Title = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Title = caption;
            }

            col.ReadOnly = readOnly;

            col.Hide = hide;

            col.ColumnCell.Layout = new CellLayout();

            col.ColumnCell.Layout.Font = DevExpress.Utils.AppearanceObject.DefaultFont;

            col.ColumnCell.Layout.HorzAlign = StringAlignment.Center;

            col.ColumnCell.Layout.VertAlign = StringAlignment.Center;

            col.Width = colWidth;

            col.Tree = true;


            this.Grid.Columns.Add(col);

        }
     
        public acGanntGridColumn GetColumn(string columnName)
        {

            foreach (acGanntGridColumn col in this.Grid.Columns)
            {
                if (col.ColumnName == columnName)
                {
                    return col;
                }

            }

            return null;

        }








        /// <summary>
        /// 버티컬 라인을 클리어한다.
        /// </summary>
        public void ClearVerticalLine()
        {
            _GanntVerticalLineDic.Clear();
        }

        /// <summary>
        /// 버티컬 라인을 추가한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="time">시간</param>
        /// <param name="lineColor">선색</param>
        /// <param name="comment">설명</param>
        public void AddGanntVerticalLine(string name, DateTime time, Color lineColor, string comment, bool isBestFit)
        {
            acGanttVerticalLine verticalLine = new acGanttVerticalLine();

            verticalLine.GanttVerticalLineType = emGanttVerticalLineType.WHOLE;
            verticalLine.DateTime = time;
            verticalLine.LineColor = lineColor;
            verticalLine.Comment = comment;
            verticalLine.IsBestFit = isBestFit;

            _GanntVerticalLineDic.Add(name, verticalLine);
        }

        public void AddGridNodeVerticalLine(GridNode node, string name, DateTime time, Color lineColor, string comment, bool isBestFit)
        {
            acGanttVerticalLine verticalLine = new acGanttVerticalLine();

            verticalLine.Node = node;
            verticalLine.GanttVerticalLineType = emGanttVerticalLineType.GRID_NODE;
            verticalLine.DateTime = time;
            verticalLine.LineColor = lineColor;
            verticalLine.Comment = comment;
            verticalLine.IsBestFit = isBestFit;

            _GanntVerticalLineDic.Add(name, verticalLine);
        }



        public delegate void TimeItemAreaUserPaintBackgroundEventHandler(OffscreenDraw aOffscreenDraw, OffscreenDrawArgs e);

        public event TimeItemAreaUserPaintBackgroundEventHandler OnTimeItemAreaUserPaintBackground;



        private class DrawVerticalLine
        {
            public string Text { get; set; }
            public Rectangle Rect { get; set; }
            public Color TextColor { get; set; }

        }


        void acGantt_OnTimeItemAreaPaintBackground(OffscreenDraw aOffscreenDraw, OffscreenDrawArgs e)
        {

            if (this.OnTimeItemAreaUserPaintBackground != null)
            {
                this.OnTimeItemAreaUserPaintBackground(aOffscreenDraw, e);
            }




        }




        private int _RowHeight = 0;


        /// <summary>
        /// 간트Row 높이
        /// </summary>
        public int RowHeight
        {
            get
            {

                return _RowHeight;

            }
            set
            {
                _RowHeight = ReSizeRowHeight(value, this.Grid.GridStructure.RootNodes);
            }
        }

        public int HoverTimeItemTimerInterval
        {
            get
            {
                return _HoverTimeItemTimerInterval;
            }
            set
            {
                _HoverTimeItemTimerInterval = value;
                hoverTimeItemTimer.Interval = _HoverTimeItemTimerInterval;
            }
        }

        void acGantt_OnGridMouseWheel(object sender, MouseEventArgs e)
        {

            if (WIN32API.GetAsyncKeyState(WIN32API.VK_Z) < 0)
            {
                int height = 0;


                if (this.Grid.FocusedCell != null)
                {
                    height = this.Grid.FocusedCell.GridNode.UserRowHeight;

                }

                this.ReSizeRowHeight(height - (e.Delta / 10), this.Grid.GridStructure.RootNodes);


            }
        }

        private int ReSizeRowHeight(int rangeHeight, GridNodes gns)
        {

            foreach (GridNode gn in gns)
            {

                gn.UserRowHeight = rangeHeight;

                if (gn.SubNodes.Count > 0)
                {
                    ReSizeRowHeight(rangeHeight, gn.SubNodes);
                }
            }

            this._RowHeight = rangeHeight;

            return rangeHeight;
        }


        public void SetFocusNode(string columnName, object value)
        {
            GridNode findNode = null;

            this._GetGridNodeByValue(this.Grid.GridStructure.RootNodes, columnName, value, ref findNode);



            this.ClearGridSelected();

            this.Grid.FocusedCell = findNode.GetCell(this.GetColumn(columnName).Index);

            int subNodeCnt = 0;

            this._GetVisibleGridNodeCnt(findNode.SubNodes, ref subNodeCnt);

            int scrIdx = findNode.Index * (subNodeCnt + 1);

            if (this.Grid.ScrollbarNodes.Maximum >= scrIdx)
            {
                this.Grid.ScrollbarNodes.Value = scrIdx;
            }
            else
            {
                this.Grid.ScrollbarNodes.Value = this.Grid.ScrollbarNodes.Maximum;
            }
            




        }



        private void _GetVisibleGridNodeCnt(GridNodes startNodes, ref int cnt)
        {
            for (int idx = 0; idx < startNodes.Count; ++idx)
            {

                ++cnt;


                if (startNodes[idx].SubNodes.Count > 0)
                {

                    this._GetVisibleGridNodeCnt(startNodes[idx].SubNodes, ref cnt);

                }


            }


        }


        private void _GetGridNodeByValue(GridNodes startNodes, string columnName, object value, ref GridNode node)
        {
            for (int idx = 0; idx < startNodes.Count; ++idx)
            {


                for (int nodeCnt = 0; nodeCnt < startNodes[idx].OwningCollection.Count; ++nodeCnt)
                {
                    if (startNodes[idx].OwningCollection[nodeCnt].GetCell(this.GetColumn(columnName).Index).Content.Value.EqualsEx(value))
                    {

                        node = startNodes[idx].OwningCollection[nodeCnt];

                    }

                }


                if (startNodes[idx].SubNodes.Count > 0)
                {

                    this._GetGridNodeByValue(startNodes[idx].SubNodes, columnName, value, ref node);

                }


            }


        }


        public void SetFocusShowTimeItem(TimeItem ti)
        {

            if (ti != null)
            {

                ti.Gantt.Update();


                this.FocusedTimeItem = ti;


                this.FocusedTimeItem.Selected = true;

                GridNodeScreenStatus stat = this.FocusedTimeItem.GanttRow.GridNode.ScreenStatus();

                if (stat == GridNodeScreenStatus.AboveScreen
                    || stat == GridNodeScreenStatus.BelowScreen
                    || stat == GridNodeScreenStatus.InNonExpandedAncestor)
                {

                    if (stat == GridNodeScreenStatus.InNonExpandedAncestor)
                    {
                        this.Grid.GridStructure.ExpandAll(true);
                    }

                    int nodeCnt = 0;



                    foreach (GridNode n in this.Grid.GridStructure.VisibleNodes)
                    {

                        if (n == this.FocusedTimeItem.GanttRow.GridNode)
                        {
                            break;
                        }

                        ++nodeCnt;
                    }


                    this.Grid.ScrollbarNodes.Value = nodeCnt;
                }


            }



        }

        /// <summary>
        /// TimeItem 중심으로 DateScaler 맞춘다.
        /// </summary>
        /// <param name="ti"></param>
        public void SetDateScaler(TimeItem ti)
        {
            if (ti != null)
            {
                DateTime oldStartTime = this.DateScaler.StartTime;

                DateTime oldStopTime = this.DateScaler.StopTime;


                this.DateScaler.StartTime = ti.Start;

                this.DateScaler.StopTime = this.DateScaler.StartTime.AddMinutesEx(Math.Abs(oldStartTime.Subtract(oldStopTime).TotalMinutes));


            }
        }



        /// <summary>
        /// 현재 화면 이미지를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {

            int ganntHeight = GetGanntHeight() + this.DateScaler.Height;

            Rectangle r = Rectangle.FromLTRB(0, 0, this.Width, ganntHeight);
            Bitmap bm = new Bitmap(this.Width, ganntHeight);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(this.BackColor), r);
            g.FillRectangle(new SolidBrush(this.Grid.BackColor), new Rectangle(0, 0, this.Grid.Width, ganntHeight));
            bool hasMorePages = false;
            this.PrintInit(null);
            this.PrintPage(g, r, this.Grid.Width, this.DateScaler.Height, false, ref hasMorePages, false);
            this.PrintEnd();


            return bm;

        }

        /// <summary>
        /// 현재 화면 비트맵을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public byte[] GetImageByteArray()
        {

            int ganntHeight = GetGanntHeight() + this.DateScaler.Height;

            Rectangle r = Rectangle.FromLTRB(0, 0, this.Width, ganntHeight);
            Bitmap bm = new Bitmap(this.Width, ganntHeight);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(new SolidBrush(this.BackColor), r);
            g.FillRectangle(new SolidBrush(this.Grid.BackColor), new Rectangle(0, 0, this.Grid.Width, ganntHeight));
            bool hasMorePages = false;
            this.PrintInit(null);
            this.PrintPage(g, r, this.Grid.Width, this.DateScaler.Height, false, ref hasMorePages, false);
            this.PrintEnd();

            MemoryStream ganntPictureMemStream = new System.IO.MemoryStream();

            bm.Save(ganntPictureMemStream, System.Drawing.Imaging.ImageFormat.Png);

            byte[] data = ganntPictureMemStream.ToArray();

            ganntPictureMemStream.Close();

            return data;

        }


        /// <summary>
        /// 모든 타임아이템을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public List<TimeItem> GetAllTimeItems()
        {
            List<TimeItem> result = new List<TimeItem>();

            if (this.Grid.GridStructure.RootNodes[0] != null)
            {

                for (int nodeCnt = 0; nodeCnt < this.Grid.GridStructure.RootNodes[0].OwningCollection.Count; ++nodeCnt)
                {
                    Layers ganntLayers = GanttRow.FromGridNode(this.Grid.GridStructure.RootNodes[0].OwningCollection[nodeCnt]).Layers;

                    for (int layerCnt = 0; layerCnt < ganntLayers.Count; layerCnt++)
                    {

                        for (int i = 0; i < ganntLayers[layerCnt].Count; i++)
                        {
                            result.Add(ganntLayers[layerCnt][i]);

                        }
                    }
                }
            }

            return result;

        }

        public void BestFitGrid()
        {

            int width = 0;

            foreach (GridColumn col in this.Grid.Columns)
            {
                if (col.Hide == false)
                {

                    width += col.Width;
                }
            }

            this.GridWidth = width;

        }


        private void _TimeItemTimeList(GridNodes nodes, ref List<DateTime> timeList)
        {
            for (int idx = 0; idx < nodes.Count; ++idx)
            {


                for (int nodeCnt = 0; nodeCnt < nodes[idx].OwningCollection.Count; ++nodeCnt)
                {

                    Layers ganntLayers = GanttRow.FromGridNode(nodes[idx].OwningCollection[nodeCnt]).Layers;

                    for (int layerCnt = 0; layerCnt < ganntLayers.Count; layerCnt++)
                    {
                        for (int i = 0; i < ganntLayers[layerCnt].Count; i++)
                        {
                            timeList.Add(ganntLayers[layerCnt][i].Start);
                            timeList.Add(ganntLayers[layerCnt][i].Stop);

                        }

                    }


                }


                if (nodes[idx].SubNodes.Count > 0)
                {

                    this._TimeItemTimeList(nodes[idx].SubNodes, ref  timeList);

                }


            }


        }

        /// <summary>
        /// TimeItem 를 기준으로 최적의 스케일로 설정합니다.
        /// </summary>
        public void BestFitDateScaler()
        {

            List<DateTime> timeList = new List<DateTime>();


            //버티칼 라인의 시작날짜와 종료날짜를 알아온다.

            if (_GanntVerticalLineDic.Count != 0)
            {
                foreach (KeyValuePair<string, acGanttVerticalLine> verticalLine in this._GanntVerticalLineDic)
                {
                    if (verticalLine.Value.IsBestFit == true)
                    {
                        timeList.Add(verticalLine.Value.DateTime);
                    }
                }

            }


            //타임아이템으로 최적날짜 스케일 표시

            this._TimeItemTimeList(this.Grid.GridStructure.RootNodes, ref timeList);

            timeList.Sort((a, b) => a.CompareTo(b));


            if (timeList.Count > 0)
            {

                this.DateScaler.StartTime = timeList[0].Year > 1 ? timeList[0].AddDays(-1) : timeList[0];
                this.DateScaler.StopTime = timeList[timeList.Count - 1].AddDays(1);
            }
            else
            {

                this.DateScaler.StartTime = DateTime.Now.AddDays(-1);
                this.DateScaler.StopTime = DateTime.Now.AddDays(1);
            }

            this.ReSizeRowHeight(this._RowHeight, this.Grid.GridStructure.RootNodes);

        }

        public DateTime GetStartDate()
        {
            List<DateTime> timeList = new List<DateTime>();

            this._TimeItemTimeList(this.Grid.GridStructure.RootNodes, ref timeList);

            timeList.Sort((a, b) => a.CompareTo(b));

            if (timeList.Count > 0)
            {
                return timeList[0];
            }
            else
            {
                return DateTime.MinValue;
            }
        }


        public DateTime GetEndDate()
        {
            List<DateTime> timeList = new List<DateTime>();

            this._TimeItemTimeList(this.Grid.GridStructure.RootNodes, ref timeList);

            timeList.Sort((a, b) => a.CompareTo(b));

            if (timeList.Count > 0)
            {
                return timeList[timeList.Count - 1];
            }
            else
            {
                return DateTime.MinValue;
            }
        }


        private int GetGanntHeight()
        {

            int height = 0;

            int defaultHeight = this.GridProperties.Columns[0].Layout.MinHeight;


            foreach (GridNode parent in this.Grid.RootNodes)
            {
                if (parent.UserRowHeight <= 0)
                {
                    height += defaultHeight;
                }
                else
                {
                    height += parent.UserRowHeight;

                }

                height += this.GridProperties.Columns[0].Layout.LineTop.Width;

                if (parent.SubNodes.Count != 0)
                {

                    int subHeight = 0;

                    GetSubNodesHeight(parent, defaultHeight, ref subHeight);

                    height += subHeight;

                }
            }

            height += this.GridProperties.Columns[0].Layout.LineBottom.Width + 1;

            return height;

        }

        private void GetSubNodesHeight(GridNode pareint, int defaultHeight, ref int height)
        {
            foreach (GridNode node in pareint.SubNodes)
            {
                if (node.UserRowHeight == 0)
                {
                    height += defaultHeight;


                }
                else
                {
                    height += node.UserRowHeight;


                }

                height += this.GridProperties.Columns[0].Layout.LineBottom.Width;

                if (node.SubNodes.Count != 0)
                {
                    GetSubNodesHeight(node, defaultHeight, ref  height);
                }

            }


        }

        public void ClearAllSelected()
        {
            this.ClearTimeItemSelected();
            this.ClearGridSelected();

        }

        public void ClearTimeItemSelected()
        {
            base.ClearSelected();

            this.FocusedTimeItem = null;



        }

        public void ClearGridSelected()
        {
            if (this.Grid.FocusedCell != null)
            {

                try
                {
                    this.Grid.GridStructure.ClearSelections();
                }
                catch
                {

                }

                this.Grid.FocusedCell = null;
            }

        }


        /// <summary>
        /// 해당 인덱스를 가지는 GridNode를 반환
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GridNode GetGridNode(int index)
        {
            for (int nodeCnt = 0; nodeCnt < this.Grid.GridStructure.RootNodes[0].OwningCollection.Count; ++nodeCnt)
            {
                GridNode gNode = GanttRow.FromGridNode(this.Grid.GridStructure.RootNodes[0].OwningCollection[nodeCnt]).GridNode;

                if (gNode.Index == index)
                {
                    return gNode;
                }

            }

            return null;
        }


        public void _FindCell(GridNodes nodes, int ColumnIndex, object findValue, ref Cell cell)
        {
            for (int nodeCnt = 0; nodeCnt < nodes.Count; ++nodeCnt)
            {
                if (nodes[nodeCnt].SubNodes.Count > 0)
                {
                    _FindCell(nodes[nodeCnt].SubNodes, ColumnIndex, findValue, ref cell);
                }

                for (int ownCnt = 0; ownCnt < nodes[nodeCnt].OwningCollection.Count; ++ownCnt)
                {
                    GridNode gNode = GanttRow.FromGridNode(nodes[nodeCnt].OwningCollection[ownCnt]).GridNode;

                    if (gNode.GetCell(ColumnIndex).Content.Value.EqualsEx(findValue))
                    {
                        cell = gNode.GetCell(ColumnIndex);

                        return;
                    }

                }

            }



        }

        /// <summary>
        /// 컬럼위치에 특정값을 가지고있는 셀을 찾는다.
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="findValue"></param>
        /// <returns></returns>
        public Cell FindCell(int ColumnIndex, object findValue)
        {
            Cell cell = null;

            _FindCell(this.Grid.GridStructure.RootNodes, ColumnIndex, findValue, ref cell);

            return cell;

        }



    }
}
