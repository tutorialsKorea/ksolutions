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
using System.Collections;

namespace MNT
{
    public sealed partial class MNT02A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }
        }

        Color _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
        Color _IDLE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_IDLE").toColor();
        Color _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();

        public override void BarCodeScanInput(string barcode)
        {


        }

        public MNT02A_M0A()
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


        DataTable _dtCtrlInfo = new DataTable();

        Timer _timer = null;

        public override void MenuInit()
        {
            acGridView1.GridType = acGridView.emGridType.FIXED_SINGLE;
            acGridView1.AddTextEdit("MC_NAME", "설비", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_MNT_NAME", "호기", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("STS_CODE", "구분코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("STS_NAME", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TOOL_NO", "Tool No.", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("UPDATE_TIME", "갱신시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "yy.MM.dd HH:mm");

            acGridView1.OptionsView.AllowCellMerge = true;
            acGridView1.OptionsView.ShowIndicator = false;

            _dtCtrlInfo.Columns.Add("CTRL_NAME", typeof(string));
            _dtCtrlInfo.Columns.Add("MC_CODE", typeof(string));
            _dtCtrlInfo.Columns.Add("LOC_X", typeof(string));
            _dtCtrlInfo.Columns.Add("LOC_Y", typeof(string));
            _dtCtrlInfo.Columns.Add("WIDTH", typeof(string));
            _dtCtrlInfo.Columns.Add("HEIGHT", typeof(string));
            _dtCtrlInfo.Columns.Add("P_WIDTH", typeof(string));
            _dtCtrlInfo.Columns.Add("P_HEIGHT", typeof(string));
            
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(acMntMachine))
                {
                    acMntMachine gc = ctrl as acMntMachine;
                    DataRow newRow = _dtCtrlInfo.NewRow();
                    newRow["CTRL_NAME"] = gc.Name;
                    newRow["LOC_X"] = ctrl.Location.X;
                    newRow["LOC_Y"] = ctrl.Location.Y;
                    newRow["WIDTH"] = ctrl.Size.Width;
                    newRow["HEIGHT"] = ctrl.Size.Height;
                    newRow["P_WIDTH"] = ctrl.Parent.Size.Width;
                    newRow["P_HEIGHT"] = ctrl.Parent.Size.Height;

                    _dtCtrlInfo.Rows.Add(newRow);
                }
                else if (ctrl.GetType() == typeof(acGridControl))
                {
                    acGridControl gc = ctrl as acGridControl;
                    DataRow newRow = _dtCtrlInfo.NewRow();
                    newRow["CTRL_NAME"] = gc.Name;
                    newRow["LOC_X"] = ctrl.Location.X;
                    newRow["LOC_Y"] = ctrl.Location.Y;
                    newRow["WIDTH"] = ctrl.Size.Width;
                    newRow["HEIGHT"] = ctrl.Size.Height;
                    newRow["P_WIDTH"] = ctrl.Parent.Size.Width;
                    newRow["P_HEIGHT"] = ctrl.Parent.Size.Height;

                    _dtCtrlInfo.Rows.Add(newRow);
                }
                else if (ctrl.GetType() == typeof(acLabelControl))
                {
                    acLabelControl gc = ctrl as acLabelControl;
                    DataRow newRow = _dtCtrlInfo.NewRow();
                    newRow["CTRL_NAME"] = gc.Name;
                    newRow["LOC_X"] = ctrl.Location.X;
                    newRow["LOC_Y"] = ctrl.Location.Y;
                    newRow["WIDTH"] = ctrl.Size.Width;
                    newRow["HEIGHT"] = ctrl.Size.Height;
                    newRow["P_WIDTH"] = ctrl.Parent.Size.Width;
                    newRow["P_HEIGHT"] = ctrl.Parent.Size.Height;

                    _dtCtrlInfo.Rows.Add(newRow);
                }
            }

            panel1.SizeChanged += panel1_SizeChanged;

            _timer = new Timer();
            _timer.Interval = 1000 * 30;
            _timer.Tick += timer_Tick;

            this.Load += MNT02A_M0A_Load;

            acMntMachine006.MC_CODE = "MCT-B1";
            acMntMachine007.MC_CODE = "MCT-B2";
            acMntMachine008.MC_CODE = "MCT-B3";
            acMntMachine009.MC_CODE = "MCT-B4";
            acMntMachine010.MC_CODE = "MCT-B5";
            acMntMachine011.MC_CODE = "MCT-B6";
            acMntMachine012.MC_CODE = "MCT-B7";
            acMntMachine013.MC_CODE = "MCT-B8";
            acMntMachine014.MC_CODE = "MCT-A6";
            acMntMachine015.MC_CODE = "MCT-A7";

            acMntMachine018.MC_CODE = "MCT-C1";
            acMntMachine019.MC_CODE = "MCT-C2";
            acMntMachine020.MC_CODE = "MCT-C3";
            acMntMachine021.MC_CODE = "MCT-C4";
            acMntMachine022.MC_CODE = "MCT-C5";

            acMntMachine001.MC_CODE = "MCT-A1";
            acMntMachine002.MC_CODE = "MCT-A2";
            acMntMachine003.MC_CODE = "MCT-A3";
            acMntMachine004.MC_CODE = "MCT-A4";
            acMntMachine005.MC_CODE = "MCT-A5";
            acMntMachine016.MC_CODE = "MCT-B9";
            acMntMachine017.MC_CODE = "MCT-B10";

            acMntMachine006.MC_NAME = "6호기";
            acMntMachine007.MC_NAME = "7호기";
            acMntMachine008.MC_NAME = "8호기";
            acMntMachine009.MC_NAME = "9호기";
            acMntMachine010.MC_NAME = "10호기";
            acMntMachine011.MC_NAME = "11호기";
            acMntMachine012.MC_NAME = "12호기";
            acMntMachine013.MC_NAME = "13호기";
            acMntMachine014.MC_NAME = "14호기";
            acMntMachine015.MC_NAME = "15호기";

            acMntMachine018.MC_NAME = "18호기";
            acMntMachine019.MC_NAME = "19호기";
            acMntMachine020.MC_NAME = "20호기";
            acMntMachine021.MC_NAME = "21호기";
            acMntMachine022.MC_NAME = "22호기";

            acMntMachine001.MC_NAME = "1호기";
            acMntMachine002.MC_NAME = "2호기";
            acMntMachine003.MC_NAME = "3호기";
            acMntMachine004.MC_NAME = "4호기";
            acMntMachine005.MC_NAME = "5호기";
            acMntMachine016.MC_NAME = "16호기";
            acMntMachine017.MC_NAME = "17호기";

            acMntMachine23.MC_NAME = "가동";
            acMntMachine24.MC_NAME = "중지";
            acMntMachine25.MC_NAME = "알람";

            acMntMachine23.MC_STATUS_CODE = "2";
            acMntMachine24.MC_STATUS_CODE = "3";
            acMntMachine25.MC_STATUS_CODE = "9";

            base.MenuInit();
        }

        private void MNT02A_M0A_Load(object sender, EventArgs e)
        {
            Search();

            _timer.Start();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                try
                {
                    if (ctrl.GetType() == typeof(acMntMachine))
                    {
                        acMntMachine Gc = ctrl as acMntMachine;

                        DataRow[] serRows = _dtCtrlInfo.Select(String.Format("CTRL_NAME = '{0}'", Gc.Name));

                        if (serRows.Length == 0) continue;

                        DataRow gtRow = serRows[0];

                        double o_width = gtRow["P_WIDTH"].toDouble();
                        double o_height = gtRow["P_HEIGHT"].toDouble();
                        double width = this.panel1.Width;
                        double height = this.panel1.Height;

                        double projectionX = width / o_width;
                        double projectionY = height / o_height;

                        Gc.Location = new Point((int)(gtRow["LOC_X"].toDouble() * projectionX), (int)(gtRow["LOC_Y"].toDouble() * projectionY));

                        Gc.Size = new Size((int)(gtRow["WIDTH"].toDouble() * projectionX), (int)(gtRow["HEIGHT"].toDouble() * projectionY));
                    }
                    else if (ctrl.GetType() == typeof(acGridControl))
                    {
                        acGridControl Gc = ctrl as acGridControl;

                        DataRow[] serRows = _dtCtrlInfo.Select(String.Format("CTRL_NAME = '{0}'", Gc.Name));

                        if (serRows.Length == 0) continue;

                        DataRow gtRow = serRows[0];

                        double o_width = gtRow["P_WIDTH"].toDouble();
                        double o_height = gtRow["P_HEIGHT"].toDouble();
                        double width = this.panel1.Width;
                        double height = this.panel1.Height;

                        double projectionX = width / o_width;
                        double projectionY = height / o_height;

                        Gc.Location = new Point((int)(gtRow["LOC_X"].toDouble() * projectionX), (int)(gtRow["LOC_Y"].toDouble() * projectionY));

                        Gc.Size = new Size((int)(gtRow["WIDTH"].toDouble() * projectionX), (int)(gtRow["HEIGHT"].toDouble() * projectionY));
                    }
                    else if (ctrl.GetType() == typeof(acLabelControl))
                    {
                        acLabelControl Gc = ctrl as acLabelControl;

                        DataRow[] serRows = _dtCtrlInfo.Select(String.Format("CTRL_NAME = '{0}'", Gc.Name));

                        if (serRows.Length == 0) continue;

                        DataRow gtRow = serRows[0];

                        double o_width = gtRow["P_WIDTH"].toDouble();
                        double o_height = gtRow["P_HEIGHT"].toDouble();
                        double width = this.panel1.Width;
                        double height = this.panel1.Height;

                        double projectionX = width / o_width;
                        double projectionY = height / o_height;

                        Gc.Location = new Point((int)(gtRow["LOC_X"].toDouble() * projectionX), (int)(gtRow["LOC_Y"].toDouble() * projectionY));

                        Gc.Size = new Size((int)(gtRow["WIDTH"].toDouble() * projectionX), (int)(gtRow["HEIGHT"].toDouble() * projectionY));
                    }
                
                }
                catch
                { }
            }
        }

        public override void MenuInitComplete()
        {
            //_timer.Start();

            base.MenuInitComplete();
        }


        public override bool MenuDestory(object sender)
        {
            _timer.Stop();
            return base.MenuDestory(sender);
        }


        public override void MenuGotFocus()
        {
            _timer.Start();
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            _timer.Stop();
            base.MenuLostFocus();
        }


        void Search()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "MNT02A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable gridTable = e.result.Tables["RSLTDT"];

                int iWorkCnt = 0;
                int iStopCnt = 0;
                int iAlarmCnt = 0;

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl.GetType() == typeof(acMntMachine))
                    {
                        acMntMachine mnt = ctrl as acMntMachine;

                        if (mnt.MC_CODE == null
                            || mnt.MC_CODE == "") continue;

                        DataRow[] signalRows = e.result.Tables["RSLTDT"].Select("MC_CODE = '" + mnt.MC_CODE + "'");

                        if (signalRows.Length > 0)
                        {
                            mnt.MC_STATUS_CODE = signalRows[0]["STS_CODE"].ToString();

                            switch (signalRows[0]["STS_CODE"].ToString())
                            {
                                case "2":
                                    iWorkCnt++;
                                    break;

                                case "3":
                                    iStopCnt++;
                                    break;

                                case "9":
                                    iAlarmCnt++;
                                    break;
                            }
                        }
                        else
                        {
                            mnt.MC_STATUS_CODE = "99";
                        }
                    }
                }

                DataView dv = gridTable.DefaultView;
                dv.Sort = "MC_SEQ ASC";
                gridTable = dv.ToTable();

                acMntMachine23.MC_NAME = "가동 (" + iWorkCnt.ToString() + ")";
                acMntMachine24.MC_NAME = "중지 (" + iStopCnt.ToString() + ")";
                acMntMachine25.MC_NAME = "알람 (" + iAlarmCnt.ToString() + ")";

                acGridView1.GridControl.DataSource = gridTable;
                //acGridView1.BestFitColumns();
                //acGridView1.Columns["MC_MNT_NAME"].Width = 50;
                acGridView1.BestFitColumns();

                acLabelControl1.Text = acDateEdit.GetNowDateFromServer().toDateString("yyyy년 MM월 dd일");
            }
            catch (Exception ex) { }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            //acMessageBox.Show(this, ex);
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            Search();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Search();
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //전체화면으로 보기
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;

                frm.ShowFullScreen(this, this.pnlScreenBase);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

