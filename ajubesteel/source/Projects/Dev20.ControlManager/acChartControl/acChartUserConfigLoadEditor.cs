using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;
using BizManager;

namespace ControlManager
{
    public sealed partial class acChartUserConfigLoadEditor : BaseMenuDialog
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

        private acChartControl _SourceChart = null;


        public acChartUserConfigLoadEditor(acChartControl sourceChart)
        {
            InitializeComponent();

            _SourceChart = sourceChart;



            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);



        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.AssignConfig();

                }

            }
        }


        /// <summary>
        /// 사용자UI 적용
        /// </summary>
        void AssignConfig()
        {



            DataRow focusRow = acGridView1.GetFocusedDataRow();


            if (focusRow != null)
            {


                byte[] layoutBuffer = (byte[])focusRow["LAYOUT"];


                //사용자 UI을 불러온다.

                _SourceChart._Config.LoadLayout(focusRow["CONFIG_NAME"], focusRow["EMP_CODE"], layoutBuffer);

                //레이아웃을 불러오면 시리즈를 다시설정

                foreach (KeyValuePair<string, DevExpress.XtraCharts.Series> series in this._SourceChart.SeriesDic)
                {
                    this._SourceChart.SeriesDic[series.Key] = this._SourceChart._Chart.Series[this._SourceChart._SeriesIndexDic[series.Key]];

                }
            }



        }


        protected override void OnLoad(EventArgs e)
        {



            acGridView1.GridType = acGridView.emGridType.LIST;

            acGridView1.AddTextEdit("CONFIG_NAME", "사용자 UI명", "3P24JPW6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "등록자", "608I87JD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);


            base.OnLoad(e);



        }

        void Search()
        {
            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("CLASS_NAME");
            paramTable.Columns.Add("CONTROL_NAME");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["CLASS_NAME"] = _SourceChart.ParentControl.Name;
            paramRow["CONTROL_NAME"] = _SourceChart.Name;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
           _SourceChart.ParentControl, QBiz.emExecuteType.LOAD,"CTRL",
           "GET_USERCONFIG_LIST", paramSet, "RQSTDT", "RSLTDT", QuickSearch, QuickException);

            //DataSet ds = BizManager.acControls.GET_USERCONFIG_LIST(paramSet);

            //acGridView1.GridControl.DataSource = ds.Tables["RSLTDT"];
        }
        protected override void OnShown(EventArgs e)
        {



            base.OnShown(e);

            this.Search();

        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //사용자 UI 불러오기
            try
            {
                this.AssignConfig();
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException)
                {
                    acMessageBox.Show(this, "사용자 UI 데이터를 읽어올수없습니다. 새로 구성하여 저장하시기 바랍니다.", "GFX5D9VY", true, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else
                {
                    acMessageBox.Show(this, ex);
                }

            }
        }


    }
}