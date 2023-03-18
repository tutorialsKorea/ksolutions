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
using DevExpress.XtraGrid.Views.Layout;
using BizManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Base.ViewInfo;



namespace POP
{
    public sealed partial class POP13A_M0A : BaseMenu
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

        public POP13A_M0A()
        {

            InitializeComponent();

            lvwMain.CustomFieldCaptionImage += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldCaptionImageEventHandler(lvwMain_CustomFieldCaptionImage);

            //lvwMain.CustomCardLayout += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomCardLayoutEventHandler(lvwMain_CustomCardLayout);

            lvwMain.MouseDown += new MouseEventHandler(layoutViewCard1_MouseDown);

            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Interval = 1000;

        }

        private int _RuningCnt = 0;
        DataTable _dt = new DataTable();
        int _chkNo = 0;

        void timer1_Tick(object sender, EventArgs e)
        {
            this._RuningCnt += 1;


            //자동 조회
            //if (this._RuningCnt == acInfo.SysConfig.GetSysConfigByMemory("POP_TERMINAL_REFRESH_TIME").toInt())
            if (this._RuningCnt == 60)
            {
                this.Search();
                this._RuningCnt = 0;
            }
        }


        void lvwMain_CustomFieldCaptionImage(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldCaptionImageEventArgs e)
        {
            LayoutView view = sender as LayoutView;

            if (e.Column.FieldName == "CD_NAME")
            {
                if (view.GetRowCellValue(e.RowHandle, "CD_NAME").ToString() == "가동중")
                {
                    e.Image = imageList1.Images[1];

                }
                else if (view.GetRowCellValue(e.RowHandle, "CD_NAME").ToString() == "중단")
                {
                    e.Image = imageList1.Images[3];
                }

                e.ImageAlignment = ContentAlignment.MiddleCenter;

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
            base.MenuInit();
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

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP13A_SER", paramSet, "RQSTDT", "RSLTDT",
                      QuickSearch2,
                      QuickException);

            spinEdit1.Value = lvwMain.OptionsMultiRecordMode.MaxCardColumns;
            spinEdit2.Value = lvwMain.OptionsMultiRecordMode.MaxCardRows;

        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DateTime nowTime = DateTime.Now;
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MC_CODE", typeof(String));
                paramTable.Columns.Add("MC_NAME", typeof(String));
                paramTable.Columns.Add("MC_STATE", typeof(String));
                paramTable.Columns.Add("LAST_OP_TIME", typeof(String));

                DataRow paramRow = paramTable.NewRow();

                _dt = e.result.Tables["RSLTDT"];

                if (_chkNo == 0)
                {
                    //시간 비교해서 업데이트 해주는 Biz 호출
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        int j = 0;
                        if (_dt.Rows[i][5].ToString() != "")
                        {
                            DateTime calMinutes = _dt.Rows[i][5].toDateTime().AddMinutes(_dt.Rows[i][4].toInt());
                            if (DateTime.Compare(nowTime, calMinutes) > 0)
                            {
                                paramTable.ImportRow(_dt.Rows[i]);
                                paramTable.Rows[j][3] = 1;
                                j++;
                            }

                            else
                            {
                                paramTable.ImportRow(_dt.Rows[i]);
                                paramTable.Rows[j][3] = 0;
                                j++;
                            }

                        }

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);


                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP13A_INS2", paramSet, "RQSTDT", "",
                              null,
                              QuickException);


                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                lvwMain.GridControl.DataSource = e.result.Tables["RSLTDT"];



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
            //
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            lvwMain.OptionsMultiRecordMode.MaxCardColumns = (int)spinEdit1.Value;

        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            lvwMain.OptionsMultiRecordMode.MaxCardRows = (int)spinEdit2.Value;
        }



        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //설비상태 가동으로 변경
            DataRow selectedRow = lvwMain.GetFocusedDataRow();
            if (selectedRow[5].ToString() == "" && selectedRow[0].ToString() != "" && selectedRow[3].toInt() == 0)
            {
                //Insert문 여기에 넣어서 MC_STATUS에 1 넣으면 됨
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MC_CODE", typeof(String));
                paramTable.Columns.Add("MC_STATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = selectedRow[1].ToString();
                paramRow["MC_STATE"] = 1;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP13A_INS", paramSet, "RQSTDT", "",
                          QuickSearch,
                          QuickException);
            }
            //this.Search();
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //설비상태 중지로 변경
            DataRow selectedRow = lvwMain.GetFocusedDataRow();
            if (selectedRow[5].ToString() == "" && selectedRow[0].ToString() != "" && selectedRow[3].toInt() == 1)
            {
                //Insert문 여기에 넣어서 MC_STATUS에 0 넣으면 됨
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MC_CODE", typeof(String));
                paramTable.Columns.Add("MC_STATE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = selectedRow[1].ToString();
                paramRow["MC_STATE"] = 0;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP13A_INS", paramSet, "RQSTDT", "",
                          QuickSearch,
                          QuickException);
            }
            //this.Search();
        }


        private void layoutViewCard1_MouseDown(object sender, MouseEventArgs e)
        {
            DataRow selectedRow = lvwMain.GetFocusedDataRow();
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            //if (selectedRow[4].ToString() == "" && selectedRow[0].ToString() == "")
            //{
            //    return;
            //}

            //else if (selectedRow[4].ToString() != "" && selectedRow[0].ToString() != "") 
            //{
            //    return;
            //}

            //popupMenu1.ClearLinks();
            BaseView view = grdMain.GetViewAt(e.Location);

            DevExpress.XtraGrid.Views.Layout.ViewInfo.LayoutViewHitInfo info = (DevExpress.XtraGrid.Views.Layout.ViewInfo.LayoutViewHitInfo)view.CalcHitInfo(e.Location);

            popupMenu1.ShowPopup(grdMain.PointToScreen(e.Location));

        }



    }
}

