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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace POP
{
    public sealed partial class POP20A_D0A : BaseMenuDialog
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

        private acGridView _LinkView = null;
        private string _McCode = null;
        private string _WoNo = null;

        /// <summary>
        /// string : TL_LOT, bool : SAVE(1)
        /// </summary>
        Dictionary<string, bool> _originList = null;


        public POP20A_D0A(acGridView linkView,string woNo, string mcCode)
        {

            InitializeComponent();

            _LinkView = linkView;
            _WoNo = woNo;
            _McCode = mcCode;

            _originList = new Dictionary<string, bool>();

            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView2.MouseDown += AcGridView2_MouseDown;
            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;
            acGridView2.ShowGridMenuEx += AcGridView2_ShowGridMenuEx;


            acGridView1.GridType = acGridView.emGridType.AUTO_COL;
            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.AddTextEdit("TL_CODE", "공구코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_LOT", "공구코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("HOLDER", "홀더", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, true, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_NAME", "공구", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_LENGTH", "공구\n길이", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_LIFE", "공구\n수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WO_RPM", "RPM", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WO_FEED", "FEED", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.KeyColumn = new string[] { "TL_CODE", "TL_LOT" };

            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_LOT", "공구Lot코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_LIFE", "공구수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView2.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView2.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView2.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView2.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_MAKER", "제작사", "9HDUX97V", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_UNITCOST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddLookUpEdit("TL_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpVendor("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.KeyColumn = new string[] { "TL_CODE", "TL_LOT" };

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void DialogInit()
        {
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

            DataSet paramSet = new DataSet();
            DataTable paramTable = paramSet.Tables.Add("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("TL_STAT", typeof(String));
            paramTable.Columns.Add("MC_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["TL_STAT"] = "NP,GU";
            paramRow["MC_CODE"] = _McCode;
            paramTable.Rows.Add(paramRow);

            DataSet rsltSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_TOOL_LOT_SEARCH", paramSet,"RQSTDT","RSLTDT");
            if(rsltSet.Tables.Contains("RSLTDT"))
            {
                acGridView2.GridControl.DataSource = rsltSet.Tables["RSLTDT"];
            }

            DataTable linkTable = (_LinkView.GridControl.DataSource as DataTable).Copy();

            foreach(DataRow row in (linkTable).Rows)
            {
                if (_originList.ContainsKey(row["TL_LOT"].toStringEmpty()) == false)
                {
                    _originList.Add(row["TL_LOT"].toStringEmpty(), true);
                }
            }

            acGridView1.GridControl.DataSource = linkTable;
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "POP20A_SAVE", paramSet, "RQSTDT", "RSLTDT",
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

                acLayoutControl1.GetEditor("INS_CODE").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private DataSet SaveData()
        {
            try
            {
                acGridView1.EndEditor();
                acGridView1.AcceptChanges();
                if (acGridView1.GridControl.DataSource is DataTable dt)
                {
                    DataSet paramSet = new DataSet();

                    DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("TL_LOT", typeof(String));
                    paramTable.Columns.Add("WO_NO", typeof(String));
                    paramTable.Columns.Add("WO_MC", typeof(String));
                    paramTable.Columns.Add("WO_RPM", typeof(String));
                    paramTable.Columns.Add("WO_FEED", typeof(String));
                    paramTable.Columns.Add("IS_SAVE", typeof(String));

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["TL_LOT"] = row["TL_LOT"];
                        paramRow["WO_NO"] = _WoNo;
                        paramRow["WO_MC"] = _McCode;
                        paramRow["WO_RPM"] = row["WO_RPM"];
                        paramRow["WO_FEED"] = row["WO_FEED"];
                            //저장
                        paramRow["IS_SAVE"] = "1";
                        paramTable.Rows.Add(paramRow);
                    }

                    foreach (string tlLot in _originList.Keys)
                    {
                        if(_originList[tlLot] == false)
                        {
                            //삭제인것
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["TL_LOT"] = tlLot;
                            paramRow["WO_NO"] = _WoNo;
                            //저장
                            paramRow["IS_SAVE"] = "0";
                            paramTable.Rows.Add(paramRow);
                        }
                    }

                    return paramSet;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            return null;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장


            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;
                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "POP20A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
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
                _LinkView.ClearRow();
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    if (row["IS_SAVE"].toInt() == 1)
                    {
                        _LinkView.UpdateMapingRow(row, true);
                    }
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
                _LinkView.ClearRow();
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
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

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left
                && sender is acGridView view)
            {
                if (e.Clicks == 1)
                {
                    GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                    if (hitInfo.HitTest == GridHitTest.RowCell)
                    {

                        switch (hitInfo.Column.FieldName)
                        {
                            case "WO_RPM":
                            case "WO_FEED":
                            case "WO_LIFE":
                            {
                                KeyPad kp = new KeyPad();
                                kp.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                                kp.ParentControl = this;
                                base.ChildFormAdd("NEW_KEY", kp);

                                if (kp.ShowDialog() == DialogResult.OK)
                                {
                                    view.SetRowCellValue(hitInfo.RowHandle, hitInfo.Column, kp.OutputData);

                                    //DataRow dr = view.GetDataRow(hitInfo.RowHandle);
                                    //dr[hitInfo.Column.FieldName] = kp.OutputData;
                                    view.EndEditor();
                                }

                                break;
                            }
                        }
                    }
                }
                if (e.Clicks == 2)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                    if (hitInfo.HitTest == GridHitTest.RowCell)
                    {
                        DataRow row = view.GetDataRow(hitInfo.RowHandle);
                        if (_originList.ContainsKey(row["TL_LOT"].toStringEmpty()))
                        {
                            _originList[row["TL_LOT"].toStringEmpty()] = false;
                        }
                        view.DeleteMappingRow(row);
                    }
                }
            }
        }
        private void AcGridView2_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                acGridView view = sender as acGridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                acGridView view = sender as acGridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }

        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left
                && sender is acGridView view
                && e.Clicks == 2)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell)
                {
                    DataRow row = view.GetDataRow(hitInfo.RowHandle);

                    if (_originList.ContainsKey(row["TL_LOT"].toStringEmpty()))
                    {
                        _originList[row["TL_LOT"].toStringEmpty()] = true;
                    }

                    acGridView1.UpdateMapingRow(row, true);
                }
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acGridView2.GetFocusedDataRow() is DataRow row)
            {
                if (_originList.ContainsKey(row["TL_LOT"].toStringEmpty()))
                {
                    _originList[row["TL_LOT"].toStringEmpty()] = true;
                }
                acGridView1.UpdateMapingRow(row, false);
            }
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acGridView1.GetFocusedDataRow() is DataRow row)
            {
                if (_originList.ContainsKey(row["TL_LOT"].toStringEmpty()))
                {
                    _originList[row["TL_LOT"].toStringEmpty()] = false;
                }
                acGridView1.DeleteMappingRow(row);
            }
        }
    }
}