using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using PlexityHide.GTP;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors;
using System.IO;

using ControlManager;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CodeHelperManager;
using BizManager;

namespace MNT
{

    public sealed partial class MNT03A_M0A : BaseMenu
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

        private class TimeItemReference
        {
            public DateTime OldStart = DateTime.MinValue;

            public DateTime OldStop = DateTime.MinValue;

            public TimeItem RelationTimeItem = null;

            public DataRow Data = null;

            public string ToolTipText = null;

        }

        public MNT03A_M0A()
        {
            InitializeComponent();

            gt.RegisterRuntimeKey("I DO NOT WANT TO SEND ANY FEEDBACK TO PLEXITYHIDE AND HENCE DO NOT WANT TO USE RUNTIMEKEYS", " CSGTPNET30114");
            gt.DateScaler.CultureInfoDateTimeFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
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

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowDateFromServer();
            }


            base.ChildContainerInit(sender);
        }

        Color clrRun = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_R").toColor();
        Color clrPause = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_W").toColor();
        Color clrOff = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_F").toColor();
        Color clrError = acInfo.SysConfig.GetSysConfigByServer("MC_SIGNAL_OPERATE_CLR_A").toColor();

        public override void MenuInit()
        {
        
            gt.VerticalLines = true;

            gt.AddColumn("MC_NAME", "설비명", "41202", CellType.SingleText, true, false);
            //gt.AddColumn("WORK_RATE", "가동률", "40004", CellType.SingleText, true, false);
            gt.AddColumn("MC_TIME", "가동시간", "", CellType.SingleText, true, false);
            gt.AddColumn("IDLE_TIME", "비가동시간", "", CellType.SingleText, true, false);
            gt.AddColumn("ALA_TIME", "알람시간", "", CellType.SingleText, true, false);
            gt.AddColumn("UPDATE_DATE", "최근 신호시각", "WG2Q38TP", CellType.SingleText, true, false);
            

            gt.EnterLinkCreateMode(false);
            gt.EnterTimeItemCreateMode(false, null, 0);

            gt.Grid.AllowRowResize = false;
            gt.Grid.GridStructure.RowSelect = true;
            gt.Grid.GridStructure.MultiSelect = false;

            barGanttHeightSize.Edit.EditValueChanged += new EventHandler(barGanttHeightSize_EditValueChanged);


            simpleLabelItem1.AppearanceItemCaption.BackColor = clrRun;
            simpleLabelItem2.AppearanceItemCaption.BackColor = clrPause;
            simpleLabelItem3.AppearanceItemCaption.BackColor = clrOff;
            simpleLabelItem4.AppearanceItemCaption.BackColor = clrError;

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            base.MenuInit();
        }


        void gt_OnTimeItemAreaUserPaintBackground(OffscreenDraw aOffscreenDraw, OffscreenDrawArgs e)
        {
            int selectedRowIndx = -1;

            //선택된 형태 그림
            if (gt.Grid.GridStructure.FocusedCell != null)
            {
                if (gt.Grid.GridStructure.FocusedCell.Selected == true)
                {
                    Rectangle r = Gantt.GanttRowFromGridNode(gt.Grid.GridStructure.FocusedCell.Node).Rect();

                    int rowIndex = gt.Grid.GridStructure.FocusedCell.Node.Index;


                    Rectangle s = Gantt.GanttRowFromGridNode(gt.Grid.GridStructure.RootNodes[rowIndex]).Rect();

                    Rectangle uni = Rectangle.Union(r, s);

                    SolidBrush b = new SolidBrush(gt.GridProperties.CellLayouts[0].SelectedColor);

                    e.G.FillRectangle(b, uni);

                    selectedRowIndx = rowIndex; 

                }
            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        private DataSet _ReadData = null;

        /// <summary>
        /// 읽은 데이터
        /// </summary>
        private DataSet ReadData
        {
            get { return _ReadData; }
            set
            {

                _ReadData = value;
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WORK_DATE"] = layoutRow["S_DATE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD, "MNT03A_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2",
                DrawGantt,
                QuickException);

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        void DrawGantt(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //기계명, 시간, 가동 데이터, 총 가도시간,  비가동 시간, 가동율
                //MC_CODE		, M.MC_NAME, UPDATE_DATE	 TOT_CAPA  MC_TIME		 IDLE_TIME , WORK_RATE	");
                    
                DataTable data = e.result.Tables["RSLTDT"];     
                DataTable dtLog = e.result.Tables["RSLTDT2"];

                gt.Enabled = true;

                //Clear
                gt.TimeItemTextLayouts.Clear();
                gt.Grid.GridStructure.RootNodes.Clear();
                
                gt.ClearVerticalLine();
                gt.TimeItemLinks.Clear();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                gt.DateScaler.StartTime = layoutRow["S_DATE"].toDateTime().AddHours(8);
                gt.DateScaler.StopTime = layoutRow["S_DATE"].toDateTime().AddHours(8).Add(new TimeSpan(9, 59, 59));
                gt.DateScaler.BoxesOnDaysRulerOnTime = true;

                

                if (data.Rows.Count > 0)
                {
                    GridNode gn = null;
                    GanttRow gr = null;
                    
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        gn = gt.Grid.GridStructure.RootNodes.AddNode();
                        

                        string mc_code = data.Rows[i]["MC_CODE"].ToString();
                        string condition = "MC_CODE = '" + mc_code  + "'";

                        gn.GetCell(this.gt.GetColumn("MC_NAME").Index).Content.Value = data.Rows[i]["MC_NAME"];
                        gn.GetCell(this.gt.GetColumn("UPDATE_DATE").Index).Content.Value = data.Rows[i]["UPDATE_DATE"].toDateString("yyyy-MM-dd HH:mm");
                        //string.Format("{0:,##0}", Double.Parse(data.Rows[i]["MC_TIME"].ToString()));
                        gn.GetCell(this.gt.GetColumn("MC_TIME").Index).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["MC_TIME"].ToString()));
                        gn.GetCell(this.gt.GetColumn("IDLE_TIME").Index).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["IDLE_TIME"].ToString()));
                        gn.GetCell(this.gt.GetColumn("ALA_TIME").Index).Content.Value = string.Format("{0:,##0}", Double.Parse(data.Rows[i]["ALA_TIME"].ToString()));

                        gn.UserReference = data.Rows[i];


                        gr = GanttRow.FromGridNode(gn);
                        gr.CollisionDetect = false;
                        TimeItem ti = null;

                        DataRow[] drArr = dtLog.Select(condition);

                        for (int j = 0; j < drArr.Length; j++)
                        {
                            ti = this.CreateTimeItem(gr.Layers[0], drArr[j]);
                        }

                        CellLayout cl = gn.GetCell(this.gt.GetColumn("MC_NAME").Index).Layout.Clone() as CellLayout;

                        gn.GetCell(this.gt.GetColumn("MC_NAME").Index).Layout = cl;
                        cl.HorzAlign = StringAlignment.Near;

                        

                        //CellLayout cl2 = gn.GetCell(this.gt.GetColumn("WORK_RATE").Index).Layout.Clone() as CellLayout;

                        //gn.GetCell(this.gt.GetColumn("WORK_RATE").Index).Layout = cl2;
                        //cl2.HorzAlign = StringAlignment.Far;

                        CellLayout cl3 = gn.GetCell(this.gt.GetColumn("UPDATE_DATE").Index).Layout.Clone() as CellLayout;

                        gn.GetCell(this.gt.GetColumn("UPDATE_DATE").Index).Layout = cl3;
                        cl3.HorzAlign = StringAlignment.Near;

                    }

                    this.gt.GetColumn("MC_NAME").Layout.HorzAlign = StringAlignment.Far;
                    //this.gt.GetColumn("WORK_RATE").Layout.HorzAlign = StringAlignment.Center;
                    this.gt.GetColumn("MC_NAME").Width = 130;
                    this.gt.GetColumn("MC_TIME").Width = 80;
                    this.gt.GetColumn("IDLE_TIME").Width = 80;
                    this.gt.GetColumn("ALA_TIME").Width = 80;
                    this.gt.GetColumn("UPDATE_DATE").Width = 130;

                    
                    gt.GridWidth = 505;
                    gt.RowHeight = 60;
                    barGanttHeightSize.EditValue = 60;

                   
                }


                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    
        private TimeItem CreateTimeItem(Layer layer, DataRow dr)
        {

            try
            {

                TimeItem ti = new TimeItem();

                ti.TimeItemLayout = new TimeItemLayout();

                ti.TimeItemLayout.AllowResizeEast = false;
                ti.TimeItemLayout.AllowResizeWest = false;
                ti.TimeItemLayout.AllowChangeRow = false;
                ti.TimeItemLayout.AllowMove = false;

                ti.TimeItemLayout.AllowLinkReAssignStart = false;
                ti.TimeItemLayout.AllowLinkReAssignTarget = false;
                ti.TimeItemLayout.AllowLinkSelectionStart = false;
                ti.TimeItemLayout.AllowLinkSelectionTarget = false;

                Color cl = Color.White;

                ti.TimeItemLayout.Color = cl;
                ti.TimeItemLayout.TimeItemStyle = TimeItemStyle.Square; // TimeItemStyle.Pipe;
                ti.TimeItemLayout.ConflictAreaDrawStyle = ConflictAreaDrawStyle.Normal;
                ti.TimeItemLayout.BottomInset = 5;
                ti.TimeItemLayout.TopInset = 5;

                ti.TimeItemLayout.BrushKind = BrushKind.Solid;

                

                ti.Start = dr["MC_START_TIME"].toDateTime();
                ti.Stop = dr["MC_END_TIME"].toDateTime();

                //설비신호에 따른 아이콘 설정
                switch (dr["MC_STATE"].ToString())
                {
                    case "3":
                        //가동
                        ti.TimeItemLayout.Color = clrRun;//Color.DodgerBlue;
                        ti.TimeItemLayout.FrameColor = clrRun;
                        break;

                    case "2":
                        //비가동
                        ti.TimeItemLayout.Color = clrPause;//Color.White;
                        ti.TimeItemLayout.FrameColor = clrPause;
                        break;

                    case "0":
                        //전원off
                        ti.TimeItemLayout.Color = clrOff;
                        ti.TimeItemLayout.FrameColor = clrOff;
                        
                        break;

                    case "9":
                        //알람
                        ti.TimeItemLayout.Color = clrError;//Color.Red;
                        ti.TimeItemLayout.FrameColor = clrError;
                        break;
                   

                }
                ti.TimeItemLayout.FrameColor = Color.Black;

                //ti.TimeItemLayout.HatchStyle = System.Drawing.Drawing2D.HatchStyle.LightVertical;
                                

                layer.Add(ti);

                return ti;

            }
            catch
            {
                return null;
            }
        }


        void barGanttHeightSize_EditValueChanged(object sender, EventArgs e)
        {
            //간트 세로 크기 조절
            ZoomTrackBarControl track = sender as ZoomTrackBarControl;

            gt.RowHeight = track.Value;
        }

    }


}
