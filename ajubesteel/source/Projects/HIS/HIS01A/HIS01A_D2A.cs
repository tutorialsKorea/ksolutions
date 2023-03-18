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
using DevExpress.XtraEditors.Controls;

namespace HIS
{
    public sealed partial class HIS01A_D2A : BaseMenuDialog
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




        public HIS01A_D2A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;
            _LinkView = linkView;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DataRow linkData = _LinkData as DataRow;
            if (linkData != null)
            {
                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("MTN_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = linkData["MTN_CODE"];
                paramTable.Rows.Add(paramRow);

                DataSet rsltSet = BizRun.QBizRun.ExecuteService(this, "HIS01A_SER4", paramSet, "RQSTDT", "RSLTDT");
                
                acLookupEdit partLe = acLayoutControl1.GetEditor("PART_CODE") as acLookupEdit;
                if (partLe != null && rsltSet.Tables.Count != 0)
                {
                    partLe.Clear();

                    LookUpColumnInfo partCodeInfo = new LookUpColumnInfo("PART_CODE","부품코드",100);
                    LookUpColumnInfo partNameInfo = new LookUpColumnInfo("PART_NAME", "부품명", 100);
                    LookUpColumnInfo useQtyInfo = new LookUpColumnInfo("USE_QTY","소요수량", 100);
                    LookUpColumnInfo scommentInfo = new LookUpColumnInfo("SCOMMENT","비고", 200);
                    partLe.Properties.Columns.Add(partCodeInfo);
                    partLe.Properties.Columns.Add(partNameInfo);
                    partLe.Properties.Columns.Add(useQtyInfo);
                    partLe.Properties.Columns.Add(scommentInfo);

                    partLe.Properties.DisplayMember = "PART_NAME";
                    partLe.Properties.ValueMember = "PART_CODE";
                    partLe.Properties.DataSource = rsltSet.Tables["RSLTDT"];
                    partLe.Properties.ShowHeader = true;
                    partLe.Properties.PopupWidth = 800;
                }
            }
            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (_LinkData as DataRow).NewCopy();
            linkRow["SCOMMENT"] = null;
            acLayoutControl1.DataBind(linkRow, true);
        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = _LinkData as DataRow;
            acLayoutControl1.DataBind(linkRow, true);

            acLayoutControl1.GetEditor("PART_CODE").isReadyOnly = true;

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "HIS01A_INS3", paramSet, "RQSTDT", "RSLTDT",
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
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataSet paramSet = new DataSet();

            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MTN_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("USE_QTY", typeof(decimal)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
            paramRow["MC_CODE"] = layoutRow["MC_CODE"];
            paramRow["PART_CODE"] = layoutRow["PART_CODE"];
            paramRow["USE_QTY"] = layoutRow["USE_QTY"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramTable.Rows.Add(paramRow);

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
                    "HIS01A_INS3", paramSet, "RQSTDT", "RSLTDT",
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
                    _LinkView.UpdateMapingRow(row, true);
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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _LinkView.UpdateMapingRow(row, true);
                }
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
    }
}