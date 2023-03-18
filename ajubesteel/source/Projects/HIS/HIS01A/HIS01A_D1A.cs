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
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Linq;

namespace HIS
{
    public sealed partial class HIS01A_D1A : BaseMenuDialog
    {

        private HashSet<string> _originMcList = null;

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

        


        public HIS01A_D1A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _originMcList = new HashSet<string>();
            _LinkData = linkData;
            _LinkView = linkView;

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_PERIOD", "보전주기(일)", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.KeyColumn = new string[] { "MC_CODE" };

            acGridView2.AddTextEdit("MC_CODE", "설비코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MC_NAME", "설비명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("MC_MGT_FLAG", "관리대상", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView2.KeyColumn = new string[] { "MC_CODE" };

            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView2.MouseDown += AcGridView2_MouseDown;
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left
                && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    DataRow row = acGridView2.GetDataRow(hitInfo.RowHandle);
                    row["MC_PERIOD"] = (_LinkData as DataRow)["STD_PERIOD"];

                    acGridView1.UpdateMapingRow(row, true);

                    acGridView2.DeleteMappingRow(row);

                }
            }
        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left
             && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);
                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    DataRow row = acGridView1.GetDataRow(hitInfo.RowHandle);

                    acGridView2.AddRow(row);

                    acGridView1.DeleteMappingRow(row);
                }
            }
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            Search();
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

            DataRow linkRow = _LinkData as DataRow;
            acLayoutControl1.DataBind(linkRow, true);

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "HIS01A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            try
            {
                acLayoutControl1.ClearValue();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private DataSet SaveData()
        {
            acGridView1.EndEditor();
            acGridView1.AcceptChanges();
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataSet paramSet = new DataSet();

            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MTN_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_PERIOD", typeof(Int32)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("IS_USE", typeof(Int32)); //
            paramTable.Columns.Add("IS_DEL", typeof(String)); //


            if (acGridView1.GridControl.DataSource is DataTable data)
            {
                foreach (DataRow row in data.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
                    paramRow["MC_CODE"] = row["MC_CODE"];
                    paramRow["MC_PERIOD"] = row["MC_PERIOD"];
                    paramRow["SCOMMENT"] = row["SCOMMENT"];
                    paramRow["IS_USE"] = layoutRow["IS_USE"];
                    paramRow["IS_DEL"] = "0";
                    paramTable.Rows.Add(paramRow);
                }

                foreach(string mcCode in _originMcList)
                {
                    if(paramTable.Select("MC_CODE='" + mcCode +"'").Any() == false)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
                        paramRow["MC_CODE"] = mcCode;
                        paramRow["IS_DEL"] = "1";
                        paramTable.Rows.Add(paramRow);
                    }
                }

            }

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
                    "HIS01A_INS1", paramSet, "RQSTDT", "RSLTDT",
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
                if (this.ParentControl is BaseMenu bm)
                {
                    bm.DataRefresh(null);
                }
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
                this.DialogResult = DialogResult.OK;
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
            try
            {
                DataRow linkRow = _LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MTN_CODE", typeof(String)); //
                //paramTable.Columns.Add("MC_GROUP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = linkRow["MTN_CODE"];
               // paramRow["MC_GROUP"] = "MCT";

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.LOAD, "HIS01A_SER5", paramSet, "RQSTDT", "RSLTDT_PC,RSLTDT_MC",
                    QuickSearch,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                e.result.Tables["RSLTDT_MC"].Columns.Add("MC_PERIOD", typeof(decimal));

                foreach (DataRow row in e.result.Tables["RSLTDT_PM"].Rows)
                {
                    if (_originMcList.Contains(row["MC_CODE"].ToString()) == false)
                    {
                        _originMcList.Add(row["MC_CODE"].ToString());
                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_PM"];
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_MC"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT_PM"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



    }
}