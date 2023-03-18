using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace HIS
{
    public sealed partial class HIS04A_D0A : BaseMenuDialog
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

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        


        public HIS04A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;
            _LinkView = linkView;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MTN_CODE", "보전코드", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_PERIOD", "보전주기(일)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("ACT_DATE", "최근 보전일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._INT);
            acGridView2.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MTN_CODE", "보전코드", "", false, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MTN_NAME", "보전항목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MC_PERIOD", "보전주기(일)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddDateEdit("PLN_DATE", "계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("NEXT_PLN_DATE", "다음 계획일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;
        }

        private void AcLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            switch(info.ColumnName)
            {
                case "YEAR":
                {
                    this.SetCreatedPlan(newValue);
                    break;
                }
            }
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //(acLayoutControl1.GetEditor("MEAS_CODE").Editor as acLookupEdit).SetCode("M012");

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            this.Search();
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "HIS04A_INS1", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private DataSet SaveData()
        {
            DataView selView = acGridView2.GetDataSourceView("SEL=1");

            if(selView.Count == 0)
            {
                acMessageBox.Show(this, "선택한 대상이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                return null;
            }

            if(acMessageBox.Show(this,"설비별 최근 보전일부터 생성연도 마지막일까지 계획정보가 생성됩니다.\n(기존 계획 정보는 삭제 후 재생성됩니다.)\n진행하시겠습니까?","",false, acMessageBox.emMessageBoxType.YESNO)== DialogResult.No)
            {
                return null;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MTN_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("PLN_DATE", typeof(String)); //
            paramTable.Columns.Add("NEXT_PLN_DATE", typeof(String)); //

            foreach (DataRowView row in selView)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = row["MTN_CODE"];
                paramRow["MC_CODE"] = row["MC_CODE"];
                paramRow["PLN_DATE"] = row["PLN_DATE"].toDateString("yyyyMMdd");
                paramRow["NEXT_PLN_DATE"] = row["NEXT_PLN_DATE"].toDateString("yyyyMMdd");
                paramTable.Rows.Add(paramRow);
            }
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장


            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;
                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "HIS04A_INS1", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                //this._LinkView.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    this._LinkView.UpdateMapingRow(row, true);
                //}

                //this._LinkView.GridControl.DataSource = e.result.Tables["RSLTDT"];
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }
        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add((_LinkData as DataTable).Copy());

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS04A_SER2", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();
                //연도 지정
                acLayoutControl2.GetEditor("YEAR").Value = DateTime.Now;
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void SetCreatedPlan(object yearValue)
        {
            try
            {
                DataView selView = acGridView1.GetDataSourceView("SEL=1");

                if(selView.Count == 0)
                {
                    acMessageBox.Show(this, "선택된 설비가 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("SEL", typeof(Int32));
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MTN_CODE", typeof(String));
                paramTable.Columns.Add("MTN_NAME", typeof(String));
                paramTable.Columns.Add("MC_CODE", typeof(String));
                paramTable.Columns.Add("MC_NAME", typeof(String));
                paramTable.Columns.Add("MC_PERIOD", typeof(Decimal));
                paramTable.Columns.Add("PLN_DATE", typeof(String));
                paramTable.Columns.Add("NEXT_PLN_DATE", typeof(String));

                foreach (DataRowView row in selView)
                {
                    DateTime lastDate = row["ACT_DATE"].toDateTime();

                    int period = row["MC_PERIOD"].toInt();

                    int selYear = yearValue.toInt();

                    for (int i = 1; lastDate.AddDays(i * period).Year < (selYear+1); i++)
                    {
                        //int count = 1;
                        //do
                        //{
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["SEL"] = 1;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MTN_CODE"] = row["MTN_CODE"];
                        paramRow["MTN_NAME"] = row["MTN_NAME"];
                        paramRow["MC_CODE"] = row["MC_CODE"];
                        paramRow["MC_NAME"] = row["MC_NAME"];
                        paramRow["MC_PERIOD"] = row["MC_PERIOD"];
                        paramRow["PLN_DATE"] = lastDate.AddDays(i * period).ToString("yyyyMMdd");
                        paramRow["NEXT_PLN_DATE"] = lastDate.AddDays((i + 1) * period).ToString("yyyyMMdd");
                        paramTable.Rows.Add(paramRow);
                    //} while (lastDate.AddDays(count++ * period).Year < selYear
                    //        && count< 1000);
                            //count<1000은 혹시 모를 무한 반복 탈출용
                    }
                }

                acGridView2.GridControl.DataSource = paramTable;
                acGridView2.BestFitColumns();
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}