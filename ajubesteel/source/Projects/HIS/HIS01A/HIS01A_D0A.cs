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

namespace HIS
{
    public sealed partial class HIS01A_D0A : BaseMenuDialog
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

        private acBandGridView _LinkView = null;

        


        public HIS01A_D0A(acBandGridView linkView, object linkData)
        {
            InitializeComponent();
            _LinkData = linkData;
            _LinkView = linkView;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddCheckEdit("MTN_MC_APPLY", "예비품 일괄 적용", "", false, true, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddTextEdit("USE_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
        }

        private void AcGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(acGridView1.GridControl.PointToScreen(e.Point));
            }
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

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

            DataSet paramSet = new DataSet();
            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MTN_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MTN_CODE"] = linkRow["MTN_CODE"];
            paramTable.Rows.Add(paramRow);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "HIS01A_SER4", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];
        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable.Columns.Add("MTN_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //
                

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                        "HIS01A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "HIS01A_INS1", paramSet, "RQSTDT", "RSLTDT",
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

            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataSet paramSet = new DataSet();

            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MTN_CODE", typeof(String)); //
            paramTable.Columns.Add("MTN_NAME", typeof(String)); //
            paramTable.Columns.Add("STD_PERIOD", typeof(Int32)); //
            paramTable.Columns.Add("MTN_SEQ", typeof(Int32)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //

            DataTable paramTableParts = paramSet.Tables.Add("RQSTDT_PARTS");
            paramTableParts.Columns.Add("PLT_CODE", typeof(String)); //
            paramTableParts.Columns.Add("MTN_CODE", typeof(String)); //
            paramTableParts.Columns.Add("PART_CODE", typeof(String)); //
            paramTableParts.Columns.Add("USE_QTY", typeof(decimal)); //
            paramTableParts.Columns.Add("MTN_MC_APPLY", typeof(Int32)); //
            paramTableParts.Columns.Add("SCOMMENT", typeof(String)); //
            paramTableParts.Columns.Add("IS_DEL", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
            paramRow["MTN_NAME"] = layoutRow["MTN_NAME"];
            paramRow["STD_PERIOD"] = layoutRow["STD_PERIOD"];
            paramRow["MTN_SEQ"] = layoutRow["MTN_SEQ"];
            paramRow["SCOMMENT"] = layoutRow["MTN_SCOMMENT"];
            paramTable.Rows.Add(paramRow);

            if (acGridView1.GridControl.DataSource is DataTable data)
            {

                DataTable addModifyTable = data.Clone();

                foreach (DataRow row in data.Rows)
                {
                    DataRow paramRowParts = paramTableParts.NewRow();
                    paramRowParts["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRowParts["MTN_CODE"] = layoutRow["MTN_CODE"];

                    switch (row.RowState)
                    {
                        case DataRowState.Deleted:
                            {
                                paramRowParts["PART_CODE"] = row["PART_CODE",DataRowVersion.Original];
                                paramRowParts["IS_DEL"] = "1";
                            }
                            break;
                        default:
                            {
                                paramRowParts["PART_CODE"] = row["PART_CODE"];
                                paramRowParts["MTN_MC_APPLY"] = row["MTN_MC_APPLY"];
                                paramRowParts["USE_QTY"] = row["USE_QTY"];
                                paramRowParts["SCOMMENT"] = row["SCOMMENT"];
                                paramRowParts["IS_DEL"] = "0";
                            }
                            break;
                    }
                    paramTableParts.Rows.Add(paramRowParts);
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
                if (this.ParentControl is BaseMenu bm)
                {
                    bm.DataRefresh(null);
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

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AddPart();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DelParts();
        }

        private void AddPart()
        {
            try
            {
                acPartForm partForm = new acPartForm();
                partForm.SelectType = acPart.emSelectType.MULTI;
                partForm.ParentControl = this;

                if (partForm.ShowDialog(this) == DialogResult.OK)
                {
                    if(partForm.OutputData is DataTable selPartsTable)
                    {
                        DataTable paramTable = acGridView1.CopyNewTable();

                        if(paramTable == null)
                        {
                            paramTable = acGridView1.NewTable();
                        }

                        foreach(DataRow row in selPartsTable.Rows)
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PART_CODE"] = row["PART_CODE"];
                            paramRow["PART_NAME"] = row["PART_NAME"];
                            paramRow["MAT_SPEC"] = row["MAT_SPEC"];
                            paramRow["USE_QTY"] = 1;
                            paramRow["SCOMMENT"] = "";
                            paramTable.Rows.Add(paramRow);
                        }

                        acGridView1.GridControl.DataSource = paramTable;
                        acGridView1.BestFitColumns();
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void DelParts()
        {
            try
            {
                if(acMessageBox.Show(this,"선택한 항목을 삭제하시겠습니까?","",false, acMessageBox.emMessageBoxType.YESNO)== DialogResult.Yes)
                {

                    DataView selView = acGridView1.GetDataSourceView("SEL='1'");
                    if(selView.Count == 0)
                    {
                        acGridView1.DeleteSelectedRows();
                    }
                    else
                    {
                        foreach(DataRowView row in selView)
                        {
                            row.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}