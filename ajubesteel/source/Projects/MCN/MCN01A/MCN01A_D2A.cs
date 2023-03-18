using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MCN
{
    public sealed partial class MCN01A_D2A : BaseMenuDialog
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

        public DataRow _linkRow = null;
        public acGridView _linkView = null;
        public acGridView _mainView = null;

        public MCN01A_D2A(acGridView mainView, acGridView linkView, DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;

            _linkView = linkView;
            _mainView = mainView;
        }


        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.acLayoutControl1.KeyColumns = new string[] { "MS_NO" };

            //this.acAttachFileControl1.AutoScroll = true;
            //this.acAttachFileControl1.HorizontalScroll.Enabled = true;
           
            (acLayoutControl1.GetEditor("REP_TYPE") as acLookupEdit).SetCode("M034");//계측기 상태
            acLayoutControl1.GetEditor("REP_DATE").Value = acDateEdit.GetNowDateFromServer();

            base.DialogInit();
        }

        public override void DialogNew()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("MS_NO").Value = _linkRow["MS_NO"];
            acLayoutControl1.GetEditor("MS_NAME").Value = _linkRow["MS_NAME"];
        
            base.DialogNew();
        }


        public override void DialogOpen()
        {

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            this.acLayoutControl1.DataBind(_linkRow, true);

            acAttachFileControl21.LinkKey = _linkRow["MS_REP_ID"];
            acAttachFileControl21.ShowKey = new object[] { _linkRow["MS_REP_ID"] };

            base.DialogOpen();
        }

     

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기 

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MS_NO", typeof(String));
            paramTable.Columns.Add("MS_REP_ID", typeof(String));
            paramTable.Columns.Add("MS_NAME", typeof(String));
            paramTable.Columns.Add("REP_VEN", typeof(String));
            paramTable.Columns.Add("REP_TYPE", typeof(String));
            paramTable.Columns.Add("REP_DATE", typeof(String));
            paramTable.Columns.Add("SCOMMENT", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_NO"] = layoutRow["MS_NO"];
            paramRow["MS_REP_ID"] = _linkRow["MS_REP_ID"];
            paramRow["MS_NAME"] = layoutRow["MS_NAME"];
            paramRow["REP_VEN"] = layoutRow["REP_VEN"];
            paramRow["REP_TYPE"] = layoutRow["REP_TYPE"];
            paramRow["REP_DATE"] = layoutRow["REP_DATE"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_INS3", paramSet, "RQSTDT", "RSLTDT",
              QuickSaveClose,
              QuickException);
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, true);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _mainView.UpdateMapingRow(row, true);
                }

                acAttachFileControl21.UploadFile();

                

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 저장 

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MS_NO", typeof(String));
            paramTable.Columns.Add("MS_REP_ID", typeof(String));
            paramTable.Columns.Add("MS_NAME", typeof(String));
            paramTable.Columns.Add("REP_VEN", typeof(String));
            paramTable.Columns.Add("REP_TYPE", typeof(String));
            paramTable.Columns.Add("REP_DATE", typeof(String));
            paramTable.Columns.Add("SCOMMENT", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_NO"] = layoutRow["MS_NO"];
            paramRow["MS_REP_ID"] = "";
            paramRow["MS_NAME"] = layoutRow["MS_NAME"];
            paramRow["REP_VEN"] = layoutRow["REP_VEN"];
            paramRow["REP_TYPE"] = layoutRow["REP_TYPE"];
            paramRow["REP_DATE"] = layoutRow["REP_DATE"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_INS3", paramSet, "RQSTDT", "RSLTDT",
              QuickSave,
              QuickException);

        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, true);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _mainView.UpdateMapingRow(row, true);
                }

                acAttachFileControl21.LinkKey = e.result.Tables["RSLTDT"].Rows[0]["MS_REP_ID"];
                acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RSLTDT"].Rows[0]["MS_REP_ID"] };
                acAttachFileControl21.UploadFile();



            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                _linkView.EndEditor();

                DataRow focusRow = _linkView.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MS_REP_ID", typeof(String)); //
                paramTable.Columns.Add("MS_NO", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MS_REP_ID"] = focusRow["MS_REP_ID"];
                paramRow["MS_NO"] = focusRow["MS_NO"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "HIS03A_DEL6", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    _linkView.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 초기화

            acLayoutControl1.ClearValue();

            acLayoutControl1.GetEditor("REP_TYPE").FocusEdit();
        }
    }
}

