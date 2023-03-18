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
    public sealed partial class STD27A_D1A : BaseMenuDialog
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

        

        public STD27A_D1A(acGridView masterView, object masterData, acGridView linkView, object linkData)
        {
  
            _LinkData = linkData;

            _LinkView = linkView;

            _MasterView = masterView;

            _MasterData = masterData;

            InitializeComponent();

            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddHidden("TYPE", typeof(string));
            acGridView1.AddTextEdit("TYPE_NAME", "구분", "41587", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MON", "월", "40985", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TUE", "화", "40986", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("WED", "수", "40987", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("THR", "목", "40988", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("FRI", "금", "40989", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SAT", "토", "40990", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SUN", "일", "40991", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);



            
            #region 이벤트 설정


            #endregion

        }




        public override void DialogInit()
        {



            DataRow masterRow = (DataRow)_MasterData;

            acLayoutControl1.GetEditor("UTC_CODE").Value = masterRow["UTC_CODE"];
            acLayoutControl1.GetEditor("UTC_NAME").Value = masterRow["UTC_NAME"];

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


            DataRow newRow1 = acGridView1.NewRow();

            newRow1["TYPE"] = "MAN";
            newRow1["TYPE_NAME"] = acInfo.Resource.GetString("유인임률","N7SYDPE0");
            newRow1["MON"] = 0;
            newRow1["TUE"] = 0;
            newRow1["WED"] = 0;
            newRow1["THR"] = 0;
            newRow1["FRI"] = 0;
            newRow1["SAT"] = 0;
            newRow1["SUN"] = 0;

            DataRow newRow2 = acGridView1.NewRow();

            newRow2["TYPE"] = "SELF";
            newRow2["TYPE_NAME"] = acInfo.Resource.GetString("무인임률", "OWFU4DVX");
            newRow2["MON"] = 0;
            newRow2["TUE"] = 0;
            newRow2["WED"] = 0;
            newRow2["THR"] = 0;
            newRow2["FRI"] = 0;
            newRow2["SAT"] = 0;
            newRow2["SUN"] = 0;

            DataRow newRow3= acGridView1.NewRow();

            newRow3["TYPE"] = "OT";
            newRow3["TYPE_NAME"] = acInfo.Resource.GetString("잔업임률", "IGHDSHAT");
            newRow3["MON"] = 0;
            newRow3["TUE"] = 0;
            newRow3["WED"] = 0;
            newRow3["THR"] = 0;
            newRow3["FRI"] = 0;
            newRow3["SAT"] = 0;
            newRow3["SUN"] = 0;

            acGridView1.AddRow(newRow1);
            acGridView1.AddRow(newRow2);
            acGridView1.AddRow(newRow3);

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            DataRow linkRow = (DataRow)_LinkData;

            acLayoutControl1.DataBind(linkRow, true);


            DataRow newRow1 = acGridView1.NewRow();

            newRow1["TYPE"] = "MAN";
            newRow1["TYPE_NAME"] = acInfo.Resource.GetString("유인임률", "N7SYDPE0");
            newRow1["MON"] = linkRow["MON_MAN"];
            newRow1["TUE"] = linkRow["TUE_MAN"]; 
            newRow1["WED"] = linkRow["WED_MAN"];
            newRow1["THR"] = linkRow["THR_MAN"];
            newRow1["FRI"] = linkRow["FRI_MAN"];
            newRow1["SAT"] = linkRow["SAT_MAN"];
            newRow1["SUN"] = linkRow["SUN_MAN"];

            DataRow newRow2 = acGridView1.NewRow();

            newRow2["TYPE"] = "SELF";
            newRow2["TYPE_NAME"] = acInfo.Resource.GetString("무인임률", "OWFU4DVX");
            newRow2["MON"] = linkRow["MON_SELF"];
            newRow2["TUE"] = linkRow["TUE_SELF"];
            newRow2["WED"] = linkRow["WED_SELF"];
            newRow2["THR"] = linkRow["THR_SELF"];
            newRow2["FRI"] = linkRow["FRI_SELF"];
            newRow2["SAT"] = linkRow["SAT_SELF"];
            newRow2["SUN"] = linkRow["SUN_SELF"];

            DataRow newRow3 = acGridView1.NewRow();

            newRow3["TYPE"] = "OT";
            newRow3["TYPE_NAME"] = acInfo.Resource.GetString("잔업임률", "IGHDSHAT");
            newRow3["MON"] = linkRow["MON_OT"];
            newRow3["TUE"] = linkRow["TUE_OT"];
            newRow3["WED"] = linkRow["WED_OT"];
            newRow3["THR"] = linkRow["THR_OT"];
            newRow3["FRI"] = linkRow["FRI_OT"];
            newRow3["SAT"] = linkRow["SAT_OT"];
            newRow3["SUN"] = linkRow["SUN_OT"];

            acGridView1.AddRow(newRow1);
            acGridView1.AddRow(newRow2);
            acGridView1.AddRow(newRow3);


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


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UCD_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UCD_ID"] = linkRow["UCD_ID"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD27A_DEL2", paramSet, "RQSTDT", "",
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



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("UCD_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UTC_CODE", typeof(String)); //
                paramTable.Columns.Add("UTC_START", typeof(String)); //
                paramTable.Columns.Add("UTC_END", typeof(String)); //
                paramTable.Columns.Add("MON_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("MON_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("MON_OT", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_OT", typeof(Decimal)); //
                paramTable.Columns.Add("WED_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("WED_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("WED_OT", typeof(Decimal)); //
                paramTable.Columns.Add("THR_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("THR_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("THR_OT", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_OT", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_OT", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_OT", typeof(Decimal)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow manRow = acGridView1.GetDataRow("TYPE = 'MAN'");
                DataRow selfRow = acGridView1.GetDataRow("TYPE = 'SELF'");
                DataRow otRow = acGridView1.GetDataRow("TYPE = 'OT'");

                DataRow paramRow = paramTable.NewRow();
                paramRow["UCD_ID"] = linkRow["UCD_ID"];
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UTC_CODE"] = layoutRow["UTC_CODE"];
                paramRow["UTC_START"] = layoutRow["UTC_START"];
                paramRow["UTC_END"] = layoutRow["UTC_END"];
                paramRow["MON_MAN"] = manRow["MON"];
                paramRow["MON_SELF"] = selfRow["MON"];
                paramRow["MON_OT"] = otRow["MON"];
                paramRow["TUE_MAN"] = manRow["TUE"];
                paramRow["TUE_SELF"] = selfRow["TUE"];
                paramRow["TUE_OT"] = otRow["TUE"];
                paramRow["WED_MAN"] = manRow["WED"];
                paramRow["WED_SELF"] = selfRow["WED"];
                paramRow["WED_OT"] = otRow["WED"];
                paramRow["THR_MAN"] = manRow["THR"];
                paramRow["THR_SELF"] = selfRow["THR"];
                paramRow["THR_OT"] = otRow["THR"];
                paramRow["FRI_MAN"] = manRow["FRI"];
                paramRow["FRI_SELF"] = selfRow["FRI"];
                paramRow["FRI_OT"] = otRow["FRI"];
                paramRow["SAT_MAN"] = manRow["SAT"];
                paramRow["SAT_SELF"] = selfRow["SAT"];
                paramRow["SAT_OT"] = otRow["SAT"];
                paramRow["SUN_MAN"] = manRow["SUN"];
                paramRow["SUN_SELF"] = selfRow["SUN"];
                paramRow["SUN_OT"] = otRow["SUN"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "STD27A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                acGridView1.EndEditor();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("UCD_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("UTC_CODE", typeof(String)); //
                paramTable.Columns.Add("UTC_START", typeof(String)); //
                paramTable.Columns.Add("UTC_END", typeof(String)); //
                paramTable.Columns.Add("MON_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("MON_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("MON_OT", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("TUE_OT", typeof(Decimal)); //
                paramTable.Columns.Add("WED_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("WED_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("WED_OT", typeof(Decimal)); //
                paramTable.Columns.Add("THR_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("THR_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("THR_OT", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("FRI_OT", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("SAT_OT", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_MAN", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_SELF", typeof(Decimal)); //
                paramTable.Columns.Add("SUN_OT", typeof(Decimal)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow manRow = acGridView1.GetDataRow("TYPE = 'MAN'");
                DataRow selfRow = acGridView1.GetDataRow("TYPE = 'SELF'");
                DataRow otRow = acGridView1.GetDataRow("TYPE = 'OT'");

                DataRow paramRow = paramTable.NewRow();
                paramRow["UCD_ID"] = null;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UTC_CODE"] = layoutRow["UTC_CODE"];
                paramRow["UTC_START"] = layoutRow["UTC_START"];
                paramRow["UTC_END"] = layoutRow["UTC_END"];
                paramRow["MON_MAN"] = manRow["MON"];
                paramRow["MON_SELF"] = selfRow["MON"];
                paramRow["MON_OT"] = otRow["MON"];
                paramRow["TUE_MAN"] = manRow["TUE"];
                paramRow["TUE_SELF"] = selfRow["TUE"];
                paramRow["TUE_OT"] = otRow["TUE"];
                paramRow["WED_MAN"] = manRow["WED"];
                paramRow["WED_SELF"] = selfRow["WED"];
                paramRow["WED_OT"] = otRow["WED"];
                paramRow["THR_MAN"] = manRow["THR"];
                paramRow["THR_SELF"] = selfRow["THR"];
                paramRow["THR_OT"] = otRow["THR"];
                paramRow["FRI_MAN"] = manRow["FRI"];
                paramRow["FRI_SELF"] = selfRow["FRI"];
                paramRow["FRI_OT"] = otRow["FRI"];
                paramRow["SAT_MAN"] = manRow["SAT"];
                paramRow["SAT_SELF"] = selfRow["SAT"];
                paramRow["SAT_OT"] = otRow["SAT"];
                paramRow["SUN_MAN"] = manRow["SUN"];
                paramRow["SUN_SELF"] = selfRow["SUN"];
                paramRow["SUN_OT"] = otRow["SUN"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                "STD27A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
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

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
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
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE || ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                //중복됨 덮어쓰기 여부 물어본다.

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

            else
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}