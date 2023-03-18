using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;

namespace POP
{
    /// <summary>
    /// 비가동 내역  편집기
    /// </summary>
    public sealed partial class POP09A_D0A : BaseMenuDialog
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


        public POP09A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;

            //이벤트 설정

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


        }



        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            switch (info.ColumnName)
            {

                case "WORK_DATE":

                    if (acLayoutControl1.IsBinding == false)
                    {
                        acTimeEdit1.EditValue = newValue;

                        acTimeEdit2.EditValue = newValue;
                    }

                    break;


                case "MC_CODE":


                    //if (newValue == null)
                    //{
                    //    acEmp1.FindButtonVisible = false;
                    //}
                    //else
                    //{
                    //    acEmp1.FindButtonVisible = true;
                    //}

                    //acEmp1.AVAILMC = newValue;

                    //acEmp1.Value = null;


                    break;

                case "START_TIME":

                    if (acLayoutControl1.IsBinding == false)
                    {

                        if(acTimeEdit1.EditValue != null && acTimeEdit2.EditValue != null)
                        {
                            acTextEdit3.EditValue = acDateEdit.SubtractMinute(acTimeEdit1.EditValue, acTimeEdit2.EditValue);
                        }
                       
                    }
                    break;


                case "END_TIME":

                    if (acLayoutControl1.IsBinding == false)
                    {
                        if (acTimeEdit1.EditValue != null && acTimeEdit2.EditValue != null)
                        {
                            acTextEdit3.EditValue = acDateEdit.SubtractMinute(acTimeEdit1.EditValue, acTimeEdit2.EditValue);
                        }
                    }

                    break;



            }

        }

        public override void DialogInit()
        {
            //(acLayoutControl1.GetEditor("PAUSE_CODE").Editor as acLookupEdit).SetCode("C009");
            (acLayoutControl1.GetEditor("IDLE_CODE").Editor as acLookupEdit).SetCode("C010");

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


            //작업일 오늘날짜로

            acLayoutControl1.GetEditor("WORK_DATE").Value = DateTime.Now;

            acLayoutControl1.GetEditor("START_TIME").Value = DateTime.Now.toDateTimeStart().Add(acDateEdit.GetWorkStartTime(DateTime.Now));

            acLayoutControl1.GetEditor("END_TIME").Value = acLayoutControl1.GetEditor("START_TIME").Value;

            base.DialogNew();

        }

        public override void DialogOpen()
        {

            //열기

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)this._LinkData;

            acLayoutControl1.DataBind(linkRow, true);


            base.DialogOpen();


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

        private DataSet SaveData(object idle_id)
        {
            try
            {

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return null;
                }

                //작업일 대비 실적시간 유효성확인

                DateTime checkActStart = acDateEdit1.DateTime.AddMinutesEx(acDateEdit.GetWorkStartTime(acDateEdit1.DateTime).TotalMinutes);
                DateTime checkActEnd = checkActStart.AddDays(1);


                if ((DateTime)acTimeEdit1.EditValue < checkActStart)
                {

                    acMessageBox.Show(this, "작업일내에 시간을 입력하셔야합니다.", "VYC424F9", true, acMessageBox.emMessageBoxType.CONFIRM);

                    acTimeEdit1.Focus();

                    return null;
                }

                if ((DateTime)acTimeEdit2.EditValue > checkActEnd)
                {
                    acMessageBox.Show(this, "작업일내에 시간을 입력하셔야합니다.", "VYC424F9", true, acMessageBox.emMessageBoxType.CONFIRM);

                    acTimeEdit2.Focus();

                    return null;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //if (layoutRow["IDLE_CODE"].ToString() != "" && layoutRow["PAUSE_CODE"].ToString() != "")
                //{
                //    acMessageBox.Show("한가지 원인만 등록해주시기 바랍니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);

                //    acLayoutControl1.GetEditor("IDLE_CODE").Value = "";
                //    acLayoutControl1.GetEditor("PAUSE_CODE").Value = "";

                //    return;
                //}
                //else if (layoutRow["IDLE_CODE"].ToString() == "" && layoutRow["PAUSE_CODE"].ToString() == "")
                //{
                //    acMessageBox.Show("원인이 선택되지 않았습니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("IDLE_ID", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("IDLE_CODE", typeof(String)); //
                paramTable.Columns.Add("IDLE_TIME", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("START_TIME", typeof(DateTime)); //
                paramTable.Columns.Add("END_TIME", typeof(DateTime)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["IDLE_ID"] = idle_id;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
                paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

                //if (layoutRow["IDLE_CODE"].ToString() != "")
                //{
                //    paramRow["IDLE_CODE"] = layoutRow["IDLE_CODE"];
                //}
                //else if (layoutRow["PAUSE_CODE"].ToString() != "")
                //{
                //    paramRow["IDLE_CODE"] = layoutRow["PAUSE_CODE"];
                //}
                paramRow["IDLE_CODE"] = layoutRow["IDLE_CODE"];
                paramRow["IDLE_TIME"] = layoutRow["IDLE_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["START_TIME"] = layoutRow["START_TIME"];
                paramRow["END_TIME"] = layoutRow["END_TIME"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                return paramSet;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return null;
            }
        }
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

                DataSet paramSet = SaveData(null);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "POP09A_INS", paramSet, "RQSTDT", "RSLTDT",
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
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
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

            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {

                acMessageBox.Show(this, ex);

                this.Close();

                //갱신

                ((BaseMenu)this.ParentControl).DataRefresh("IDLE");

            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }
        
        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {
                
                DataRow linkRow = (DataRow)this._LinkData;

                DataSet paramSet = SaveData(linkRow["IDLE_ID"]);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE, "POP09A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

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

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = (DataRow)this._LinkData;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("IDLE_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["IDLE_ID"] = linkRow["IDLE_ID"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL, "POP09A_DEL", paramSet, "RQSTDT", "",
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

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

    }
}