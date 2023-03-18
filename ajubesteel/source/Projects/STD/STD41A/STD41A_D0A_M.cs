using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD41A_D0A_M : BaseMenuDialog
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

        private acGridView _MasterView = null;

        private object _MasterData = null;

        public object MasterData
        {
            get { return _MasterData; }
            set { _MasterData = value; }
        }




        public STD41A_D0A_M(acGridView masterView, object masterData, acGridView linkView, object linkData)
        {
            InitializeComponent();


            _MasterView = masterView;

            _MasterData = masterData;

            _LinkData = linkData;

            _LinkView = linkView;


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {


        }



        public override void DialogInit()
        {




            acLayoutControl1.KeyColumns = new string[] { "PRG_CODE" };

            (acLayoutControl1.GetEditor("INS_FLAG").Editor as acLookupEdit).SetCode("S063");
            (acLayoutControl1.GetEditor("PRG_TYPE").Editor as acLookupEdit).SetCode("S006");

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;




            base.DialogInit();
        }


        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기


            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData, true);

            base.DialogOpen();
        }

        public override void DialogInitComplete()
        {

            base.DialogInitComplete();
        }


        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("PRG_CODE").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow masterRow = (DataRow)_MasterData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_NAME", typeof(String)); //
                paramTable.Columns.Add("UP_CLASS", typeof(String)); //
                paramTable.Columns.Add("MCLASS_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("PRG_TYPE", typeof(String)); //
                paramTable.Columns.Add("PRG_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_COLOR", typeof(String)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("IS_OS", typeof(Byte)); //

                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = layoutRow["PRG_CODE"];
                paramRow["PRG_NAME"] = layoutRow["PRG_NAME"];
                paramRow["UP_CLASS"] = masterRow["PRG_CODE"];
                paramRow["MCLASS_FLAG"] = layoutRow["MCLASS_FLAG"];
                paramRow["PRG_TYPE"] = layoutRow["PRG_TYPE"];
                paramRow["PRG_SEQ"] = layoutRow["PRG_SEQ"];
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["PRG_COLOR"] = layoutRow["PRG_COLOR"];
                paramRow["INS_FLAG"] = layoutRow["INS_FLAG"];
                paramRow["IS_OS"] = layoutRow["IS_OS"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD41A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow masterRow = (DataRow)_MasterData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_NAME", typeof(String)); //
                paramTable.Columns.Add("UP_CLASS", typeof(String)); //
                paramTable.Columns.Add("MCLASS_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("PRG_TYPE", typeof(String)); //
                paramTable.Columns.Add("PRG_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("PRG_COLOR", typeof(String)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("IS_OS", typeof(Byte)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = layoutRow["PRG_CODE"];
                paramRow["PRG_NAME"] = layoutRow["PRG_NAME"];
                paramRow["UP_CLASS"] = masterRow["PRG_CODE"];
                paramRow["MCLASS_FLAG"] = layoutRow["MCLASS_FLAG"];
                paramRow["PRG_TYPE"] = layoutRow["PRG_TYPE"];
                paramRow["PRG_SEQ"] = layoutRow["PRG_SEQ"];
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["PRG_COLOR"] = layoutRow["PRG_COLOR"];
                paramRow["INS_FLAG"] = layoutRow["INS_FLAG"];
                paramRow["IS_OS"] = layoutRow["IS_OS"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD41A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow focusMasterRow = _MasterView.GetFocusedDataRow();

                //마스터 그리드뷰의 코드와 현재 코드가 동일하면 Row 업데이트
                if (focusMasterRow["PRG_CODE"].Equals(((DataRow)_MasterData)["PRG_CODE"]))
                {

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow focusMasterRow = _MasterView.GetFocusedDataRow();

                //마스터 그리드뷰의 코드와 현재 코드가 동일하면 Row 업데이트
                if (focusMasterRow["PRG_CODE"].Equals(((DataRow)_MasterData)["PRG_CODE"]))
                {

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }

                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

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


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                paramTable.Columns.Add("PRG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PRG_CODE"] = layoutRow["PRG_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD41A_DEL2", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }




    }
}

