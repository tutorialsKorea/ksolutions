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
    public sealed partial class STD13A_D1A : BaseMenuDialog
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

        private acTreeList _MasterTreeList = null;


        private object _MasterData = null;

        public object MasterData
        {
            get { return _MasterData; }
            set { _MasterData = value; }
        }





        public STD13A_D1A(acTreeList masterTreeList, object masterData, acGridView linkView, object linkData)
        {


            InitializeComponent();


            _MasterTreeList = masterTreeList;

            _MasterData = masterData;

            _LinkData = linkData;

            _LinkView = linkView;





        }


        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.KeyColumns = new string[] { "EMP_CODE" };


            (acLayoutControl1.GetEditor("EMP_TYPE").Editor as acLookupEdit).SetCode("S021");

            (acLayoutControl1.GetEditor("EMP_TITLE").Editor as acLookupEdit).SetCode("C040");

            (acLayoutControl1.GetEditor("WORK_LOC").Editor as acLookupEdit).SetCode("E001");
            (acLayoutControl1.GetEditor("PAY_CONTRACT").Editor as acLookupEdit).SetCode("E002");
            (acLayoutControl1.GetEditor("WORK_CONTRACT").Editor as acLookupEdit).SetCode("E003");
            (acLayoutControl1.GetEditor("EMP_NATIONAL").Editor as acLookupEdit).SetCode("E004");

            //(acLayoutControl1.GetEditor("EMP_REG_NUMBER").Editor as acTextEdit).Properties.UseMaskAsDisplayFormat = true;
            //(acLayoutControl1.GetEditor("EMP_REG_NUMBER").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            ////String regex = @"[0-9]{6}-[0-9]{7}";
            //String regex = @"[0-9][0-9][01][0-9][0123][0-9]-[12345678][0-9]{6}";

            //(acLayoutControl1.GetEditor("EMP_REG_NUMBER").Editor as acTextEdit).Properties.Mask.EditMask = regex;

            if (_LinkData.ToString() != "NEW")
            {
                DataSet paramSet = acInfo.RefData.Clone();
                paramSet.Tables["RQSTDT"].Columns.Add("EMP_CODE", typeof(String));

                DataRow newRow = paramSet.Tables["RQSTDT"].NewRow();
                newRow["PLT_CODE"] = acInfo.PLT_CODE;
                newRow["EMP_CODE"] = ((DataRow)_LinkData)["EMP_CODE"];

                paramSet.Tables["RQSTDT"].Rows.Add(newRow);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD13A_SER3", paramSet, "RQSTDT", "RSLTDT");
                if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acLayoutControl1.GetEditor("SIGN_IMG").Value = resultSet.Tables["RSLTDT"].Rows[0]["SIGN_IMG"];
                }
            }

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


            base.DialogInit();

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //if (info.ColumnName == "IS_VND")
            //{

            //    layout.GetEditor("EMP_VND").isRequired = newValue.toBoolean();

            //}

            
            // 사원형태가 퇴사일 경우 퇴사일을 필수 필드로 설정
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "EMP_TYPE":

                    if (newValue == null) return;

                    if (newValue.ToString() == "5")
                    {
                       
                        acLayoutControl1.GetEditor("RETIRE_DATE").isRequired = true;
                    }
                    else
                    {
                        acLayoutControl1.GetEditor("RETIRE_DATE").isRequired = false;
                        acLayoutControl1.GetEditor("RETIRE_DATE").Value = "";
                    }

                    break;
            }





        }

        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("ORG_CODE").Value = ((DataRowView)_MasterData).Row["ORG_CODE"];

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            acLayoutControl1.DataBind((DataRow)_LinkData, true);

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
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD13A_DEL2", paramSet, "RQSTDT", "",
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
            foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
            {
                this._LinkView.DeleteMappingRow(row);
            }

            this.Close();
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


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_NAME", typeof(String)); //
                paramTable.Columns.Add("EMP_TYPE", typeof(String)); //
                paramTable.Columns.Add("EMP_TITLE", typeof(String)); //
                paramTable.Columns.Add("EMP_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //
                paramTable.Columns.Add("MOBILE_PHONE", typeof(String)); //
                paramTable.Columns.Add("EMAIL", typeof(String)); //
                paramTable.Columns.Add("IS_VND", typeof(Byte)); //
                paramTable.Columns.Add("EMP_VND", typeof(String)); //
                paramTable.Columns.Add("IF_EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
           
                paramTable.Columns.Add("HIRE_DATE", typeof(String));
                paramTable.Columns.Add("RETIRE_DATE", typeof(String));
                paramTable.Columns.Add("BIRTH_DATE", typeof(String));
                //paramTable.Columns.Add("ACCOUNT_DATE", typeof(String));
                //paramTable.Columns.Add("TARGET_DATE", typeof(String));
                //paramTable.Columns.Add("ENFOR_DATE", typeof(String));
                paramTable.Columns.Add("IS_PROC", typeof(byte));
                paramTable.Columns.Add("SIGN_IMG", typeof(byte[]));

                paramTable.Columns.Add("EMP_REG_NUMBER", typeof(String));
                paramTable.Columns.Add("EMP_ADDRESS", typeof(String));

                paramTable.Columns.Add("WORK_LOC", typeof(String));
                paramTable.Columns.Add("PAY_CONTRACT", typeof(String));
                paramTable.Columns.Add("WORK_CONTRACT", typeof(String));
                paramTable.Columns.Add("EMP_NATIONAL", typeof(String));

                paramTable.Columns.Add("IS_CAM", typeof(String));
                paramTable.Columns.Add("IS_DAILY", typeof(Byte));
                
                paramTable.Columns.Add("SCOMMENT", typeof(String));
                paramTable.Columns.Add("LEADER_EMP_CODE", typeof(String));

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["EMP_NAME"] = layoutRow["EMP_NAME"];
                paramRow["EMP_TYPE"] = layoutRow["EMP_TYPE"];
                paramRow["EMP_TITLE"] = layoutRow["EMP_TITLE"];
                paramRow["EMP_SEQ"] = layoutRow["EMP_SEQ"];
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow["USRGRP_CODE"] = layoutRow["USRGRP_CODE"];
                paramRow["MOBILE_PHONE"] = layoutRow["MOBILE_PHONE"];
                paramRow["EMAIL"] = layoutRow["EMAIL"];
                //paramRow["IS_VND"] = layoutRow["IS_VND"];
                //paramRow["EMP_VND"] = layoutRow["EMP_VND"];
                //paramRow["IF_EMP_CODE"] = layoutRow["IF_EMP_CODE"];
                paramRow["REG_EMP"] = acInfo.UserID;
              
                paramRow["HIRE_DATE"] = layoutRow["HIRE_DATE"];
                paramRow["RETIRE_DATE"] = layoutRow["RETIRE_DATE"];
                paramRow["BIRTH_DATE"] = layoutRow["BIRTH_DATE"];
                //paramRow["ACCOUNT_DATE"] = layoutRow["ACCOUNT_DATE"];
                //paramRow["TARGET_DATE"] = layoutRow["TARGET_DATE"];
                //paramRow["ENFOR_DATE"] = layoutRow["ENFOR_DATE"];
                paramRow["IS_PROC"] = layoutRow["IS_PROC"];
                paramRow["SIGN_IMG"] = layoutRow["SIGN_IMG"];

                paramRow["EMP_REG_NUMBER"] = layoutRow["EMP_REG_NUMBER"];
                paramRow["EMP_ADDRESS"] = layoutRow["EMP_ADDRESS"];

                paramRow["WORK_LOC"] = layoutRow["WORK_LOC"];
                paramRow["PAY_CONTRACT"] = layoutRow["PAY_CONTRACT"];
                paramRow["WORK_CONTRACT"] = layoutRow["WORK_CONTRACT"];
                paramRow["EMP_NATIONAL"] = layoutRow["EMP_NATIONAL"];

                paramRow["IS_CAM"] = layoutRow["IS_CAM"];
                paramRow["IS_DAILY"] = layoutRow["IS_DAILY"];

                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["LEADER_EMP_CODE"] = layoutRow["LEADER_EMP_CODE"];

                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD13A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                acLayoutControl1.GetEditor("EMP_CODE").FocusEdit();
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
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_NAME", typeof(String)); //
                paramTable.Columns.Add("EMP_TYPE", typeof(String)); //
                paramTable.Columns.Add("EMP_TITLE", typeof(String)); //
                paramTable.Columns.Add("EMP_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("CPROC_CODE", typeof(String)); //
                paramTable.Columns.Add("USRGRP_CODE", typeof(String)); //
                paramTable.Columns.Add("MOBILE_PHONE", typeof(String)); //
                paramTable.Columns.Add("EMAIL", typeof(String)); //


                paramTable.Columns.Add("IS_VND", typeof(Byte)); //
                paramTable.Columns.Add("EMP_VND", typeof(String)); //
                paramTable.Columns.Add("IF_EMP_CODE", typeof(String)); //

                paramTable.Columns.Add("HIRE_DATE", typeof(String));
                paramTable.Columns.Add("RETIRE_DATE", typeof(String));
                paramTable.Columns.Add("BIRTH_DATE", typeof(String));
                //paramTable.Columns.Add("ACCOUNT_DATE", typeof(String));
                //paramTable.Columns.Add("TARGET_DATE", typeof(String));
                //paramTable.Columns.Add("ENFOR_DATE", typeof(String));
                paramTable.Columns.Add("IS_PROC", typeof(byte));
                paramTable.Columns.Add("SIGN_IMG", typeof(byte[]));

                paramTable.Columns.Add("EMP_REG_NUMBER", typeof(String));
                paramTable.Columns.Add("EMP_ADDRESS", typeof(String));

                paramTable.Columns.Add("WORK_LOC", typeof(String));
                paramTable.Columns.Add("PAY_CONTRACT", typeof(String));
                paramTable.Columns.Add("WORK_CONTRACT", typeof(String));
                paramTable.Columns.Add("EMP_NATIONAL", typeof(String));

                paramTable.Columns.Add("SCOMMENT", typeof(String));

                paramTable.Columns.Add("LEADER_EMP_CODE", typeof(String)); 

                paramTable.Columns.Add("IS_CAM", typeof(String));
                paramTable.Columns.Add("IS_DAILY", typeof(Byte));

                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["EMP_NAME"] = layoutRow["EMP_NAME"];
                paramRow["EMP_TYPE"] = layoutRow["EMP_TYPE"];
                paramRow["EMP_TITLE"] = layoutRow["EMP_TITLE"];
                paramRow["EMP_SEQ"] = layoutRow["EMP_SEQ"];
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["CPROC_CODE"] = layoutRow["CPROC_CODE"];
                paramRow["USRGRP_CODE"] = layoutRow["USRGRP_CODE"];
                paramRow["MOBILE_PHONE"] = layoutRow["MOBILE_PHONE"];
                paramRow["EMAIL"] = layoutRow["EMAIL"];

                //paramRow["IS_VND"] = layoutRow["IS_VND"];
                //paramRow["EMP_VND"] = layoutRow["EMP_VND"];
                //paramRow["IF_EMP_CODE"] = layoutRow["IF_EMP_CODE"];

                paramRow["HIRE_DATE"] = layoutRow["HIRE_DATE"];
                paramRow["RETIRE_DATE"] = layoutRow["RETIRE_DATE"];
                paramRow["BIRTH_DATE"] = layoutRow["BIRTH_DATE"];
                //paramRow["ACCOUNT_DATE"] = layoutRow["ACCOUNT_DATE"];
                //paramRow["TARGET_DATE"] = layoutRow["TARGET_DATE"];
                //paramRow["ENFOR_DATE"] = layoutRow["ENFOR_DATE"];
                paramRow["IS_PROC"] = layoutRow["IS_PROC"];
                paramRow["SIGN_IMG"] = layoutRow["SIGN_IMG"];

                paramRow["EMP_REG_NUMBER"] = layoutRow["EMP_REG_NUMBER"];
                paramRow["EMP_ADDRESS"] = layoutRow["EMP_ADDRESS"];

                paramRow["WORK_LOC"] = layoutRow["WORK_LOC"];
                paramRow["PAY_CONTRACT"] = layoutRow["PAY_CONTRACT"];
                paramRow["WORK_CONTRACT"] = layoutRow["WORK_CONTRACT"];
                paramRow["EMP_NATIONAL"] = layoutRow["EMP_NATIONAL"];

                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramRow["LEADER_EMP_CODE"] = layoutRow["LEADER_EMP_CODE"]; 

                paramRow["IS_CAM"] = layoutRow["IS_CAM"];
                paramRow["IS_DAILY"] = layoutRow["IS_DAILY"];

                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD13A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                DataRow focusMasterRow = ((DataRowView)_MasterTreeList.GetDataRecordByNode(_MasterTreeList.FocusedNode)).Row;



                //설정된 부서코드와 현재 마스터 부서코드가 동일하면 Row 업데이트
                if (focusMasterRow["ORG_CODE"].Equals(acLayoutControl1.GetEditor("ORG_CODE").Value))
                {


                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }

                }
                else
                {
                    //다르면 삭제

                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.DeleteMappingRow(row);

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
                DataRow resultRow = e.result.Tables["RSLTDT"].Rows[0];

                DataRow focusMasterRow = ((DataRowView)_MasterTreeList.GetDataRecordByNode(_MasterTreeList.FocusedNode)).Row;


                //설정된 부서코드와 현재 마스터 부서코드가 동일하면 Row 업데이트

                if (focusMasterRow["ORG_CODE"].isNull() == false)
                {
                    if (focusMasterRow["ORG_CODE"].Equals(acLayoutControl1.GetEditor("ORG_CODE").Value))
                    {
                        this._LinkView.UpdateMapingRow(resultRow, true);



                    }
                    else
                    {
                        //다르면 삭제
                        _LinkView.DeleteMappingRow(resultRow);
                    }

                }
                else
                {
                    _LinkView.UpdateMapingRow(resultRow, true);


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
            else if (ex.ErrNumber == 100022)
            {
                //시스템 예약어는 사원코드로 쓸수없음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                frm.ShowDialog();



            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acDateEdit2_EditValueChanged(object sender, EventArgs e)
        {

            if (acLayoutControl1.GetEditor("RETIRE_DATE").Value.toStringEmpty() != "")
            {
                acLayoutControl1.GetEditor("EMP_TYPE").Value = "5";
            }
            else
            {
                acLayoutControl1.GetEditor("EMP_TYPE").Value = acLayoutControl1.GetEditor("EMP_TYPE").Value;
            }

        }
    }
}