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

namespace STD
{
    public sealed partial class STD26A_D1A : BaseMenuDialog
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

        

        public STD26A_D1A(acGridView masterView, object masterData, acGridView linkView, object linkData)
        {

            _LinkData = linkData;

            _LinkView = linkView;

            _MasterView = masterView;

            _MasterData = masterData;

            InitializeComponent();

            #region 이벤트 설정


            #endregion

        }




        public override void DialogInit()
        {



            DataRow masterRow = (DataRow)_MasterData;

            acLayoutControl1.GetEditor("MQLTY_CODE").Value = masterRow["MQLTY_CODE"];
            acLayoutControl1.GetEditor("MQLTY_NAME").Value = masterRow["MQLTY_NAME"];
            acLayoutControl1.GetEditor("MQLTY_START").Value = acDateEdit.GetNowFirstMonth();
            acLayoutControl1.GetEditor("MQLTY_END").Value = acDateEdit.GetNowLastMonth();

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData,true);
        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //삭제
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCD_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["QCD_ID"] = linkRow["QCD_ID"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD26A_DEL2", paramSet, "RQSTDT", "",
                    QuickDEL,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.DEL,
                //"STD26A_DEL2", paramSet, "RQSTDT", "",
                //QuickDEL,
                //QuickException);

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
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataRow linkRow = (DataRow)_LinkData;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("QCD_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_START", typeof(String)); //
                paramTable.Columns.Add("MQLTY_END", typeof(String)); //
                paramTable.Columns.Add("MQLTY_UC", typeof(Decimal)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["QCD_ID"] = linkRow["QCD_ID"];
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MQLTY_CODE"] = layoutRow["MQLTY_CODE"];
                paramRow["MQLTY_START"] = layoutRow["MQLTY_START"];
                paramRow["MQLTY_END"] = layoutRow["MQLTY_END"];
                paramRow["MQLTY_UC"] = layoutRow["MQLTY_UC"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD26A_INS2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.SAVE,
                //"STD26A_INS2", paramSet, "RQSTDT", "RSLTDT",
                //QuickSaveClose,
                //QuickException);

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

                acLayoutControl1.GetEditor("MQLTY_START").FocusEdit();
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


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("QCD_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_CODE", typeof(String)); //
                paramTable.Columns.Add("MQLTY_START", typeof(String)); //
                paramTable.Columns.Add("MQLTY_END", typeof(String)); //
                paramTable.Columns.Add("MQLTY_UC", typeof(Decimal)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["QCD_ID"] = null;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MQLTY_CODE"] = layoutRow["MQLTY_CODE"];
                paramRow["MQLTY_START"] = layoutRow["MQLTY_START"];
                paramRow["MQLTY_END"] = layoutRow["MQLTY_END"];
                paramRow["MQLTY_UC"] = layoutRow["MQLTY_UC"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                    "STD26A_INS2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.SAVE,
                //"STD26A_INS2", paramSet, "RQSTDT", "RSLTDT",
                //QuickSave,
                //QuickException);


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
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



            this.Close();

        }


        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE || ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                //중복됨 덮어쓰기 여부 물어본다.

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
            else if (ex.ErrNumber == 200026)
            {
                acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }



    }
}