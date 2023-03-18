using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;
using BizManager;

namespace PLN
{
    public sealed partial class PLN20A_D1A : BaseMenuDialog
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



        public PLN20A_D1A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;


        }


        public override void DialogInit()
        {



            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



            acLayoutControl1.KeyColumns = new string[] { "PROD_CODE" };

            //수주상태
            (acLayoutControl1.GetEditor("PROD_STATE").Editor as acLookupEdit).SetCode("P012");

            //공정명
            (acLayoutControl1.GetEditor("PROC_FLAG").Editor as acLookupEdit).SetCode("P005");
            //유형
            (acLayoutControl1.GetEditor("PROD_FLAG").Editor as acLookupEdit).SetCode("P006");
            //성적서
            (acLayoutControl1.GetEditor("INS_YN").Editor as acLookupEdit).SetCode("P007");
            //소켓측정
            (acLayoutControl1.GetEditor("SOCKET_YN").Editor as acLookupEdit).SetCode("P007");
            //제품분류
            (acLayoutControl1.GetEditor("PROD_TYPE").Editor as acLookupEdit).SetCode("P010");
            //제품유형
            (acLayoutControl1.GetEditor("PROD_CATEGORY").Editor as acCheckedComboBoxEdit).AddItem("P009", 0, 1, CheckState.Unchecked);
            //액츄에이터유무
            (acLayoutControl1.GetEditor("ACTUATOR_YN").Editor as acLookupEdit).SetCode("S101");
            //
            (acLayoutControl1.GetEditor("PIN_TYPE").Editor as acCheckedComboBoxEdit).AddItem("P011",0,1, CheckState.Unchecked);
            //통화
            (acLayoutControl1.GetEditor("CURR_UNIT").Editor as acLookupEdit).SetCode("P008");
            //거레명세
            (acLayoutControl1.GetEditor("TRADE_YN").Editor as acLookupEdit).SetCode("P007");
            //세금
            (acLayoutControl1.GetEditor("TAX_YN").Editor as acLookupEdit).SetCode("P007");
            //수금
            (acLayoutControl1.GetEditor("BILL_YN").Editor as acLookupEdit).SetCode("P007");

            acCheckEdit1.Checked = true;


            this.acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            

            base.DialogInit();

        }




        int _ven_charge_id = 0;

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            acLayoutControl layout = sender as acLayoutControl;

            switch(info.ColumnName)
            {
                case "PROD_QTY":
                    decimal cost = layout.GetEditor("PROD_COST").Value.toDecimal();

                    layout.GetEditor("PROD_AMT").Value = cost * newValue.toDecimal();
                    break;
                case "PROD_COST":
                    decimal qty = layout.GetEditor("PROD_QTY").Value.toDecimal();

                    layout.GetEditor("PROD_AMT").Value = qty * newValue.toDecimal();

                    break;
            }

            //if (info.ColumnName == "ORD_DATE")
            //{
            //    layout.GetEditor("SALECONFM_DATE").Value = newValue;
            //}
            //else if (info.ColumnName == "CVND_CODE")
            //{

            //    if (acLayoutControl1.GetEditor("CVND_CODE").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("CVND_CODE").Editor as acVendor).SelectedRow;

            //        layout.GetEditor("ITEM_AUTO_CODE").Value = row["ITEM_AUTO_CODE"];

            //        if (acLayoutControl1.GetEditor("ITEM_CODE").Value == null)
            //            acLayoutControl1.DataBind(row, false);

            //    }
 
                
            //}
            //else if (info.ColumnName == "CHARGE_EMP")
            //{
            //    if (acLayoutControl1.GetEditor("CHARGE_EMP").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("CHARGE_EMP").Editor as acVendorCharge).SelectedRow;

            //        acLayoutControl1.DataBind(row, false);


            //        _ven_charge_id = row["VEN_CHARGE_ID"].toInt();

            //    }
            //    else
            //    {
            //        layout.GetEditor("CHARGE_DEPT").Value = "";
            //        layout.GetEditor("CHARGE_TEL").Value = "";
            //        layout.GetEditor("CHARGE_HP").Value = "";
            //        layout.GetEditor("CHARGE_EMAIL").Value = "";
            //        layout.GetEditor("CHARGE_SCOMMENT").Value = "";

            //        _ven_charge_id = 0;
            //    }
            //}
            //else if (info.ColumnName == "BUSINESS_EMP")
            //{
            //    if (acLayoutControl1.GetEditor("BUSINESS_EMP").Value != null)
            //    {
            //        DataRow row = (acLayoutControl1.GetEditor("BUSINESS_EMP").Editor as acEmp).SelectedRow;

            //        acLayoutControl1.DataBind(row, false);
            //    }
            //    else
            //    {
            //        acLayoutControl1.GetEditor("MOBILE_PHONE").Value = "";
            //     }
            //}

        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            //acLayoutControl1.GetEditor("SALECONFM_DATE").Value = acDateEdit.GetNowDateFromServer();
            acLayoutControl1.GetEditor("ORD_DATE").Value = acDateEdit.GetNowDateFromServer();
            //acLayoutControl1.GetEditor("DUE_DATE").Value = acDateEdit.GetNowDateFromServer().AddMonths(1);

            acLayoutControl1.GetEditor("BUSINESS_EMP").Value = acInfo.UserID;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            //20160517 김준구 - 수주번호 자동채번
            acLayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;

            acLayoutControl1.DataBind(linkRow, true);

        }

        public override void DialogUser()
        {
            //복사

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            DataRow linkRow = (DataRow)_LinkData;

            acLayoutControl1.DataBind(linkRow, true);
            
            acLayoutControl1.GetEditor("ORD_DATE").Value = acDateEdit.GetNowDateFromServer();
            //acLayoutControl1.GetEditor("DUE_DATE").Value = acDateEdit.GetNowDateFromServer().AddMonths(1);

            acLayoutControl1.GetEditor("BUSINESS_EMP").Value = acInfo.UserID;


            acLayoutControl1.GetEditor("PROD_CODE").Value = null;
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


                DataSet paramSet = GetSaveData("1");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD02A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
                    QuickException);
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



            if (ex.ErrNumber == BizManager.BizException.OVERWRITE ||
                ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
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
            else if (ex.ErrNumber == 200200)
            {
                acMessageBox.Show("대기 상태인 수주만 수정 가능합니다.", this.Text, acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }
        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //삭제
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ITEM_CODE", typeof(String)); //

                DataRow linkRow = (DataRow)_LinkData;

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = linkRow["ITEM_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "ORD02A_DEL", paramSet, "RQSTDT", "",
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
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();


                acLayoutControl1.GetEditor("ITEM_CODE").FocusEdit();
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


                DataSet paramSet = GetSaveData("0");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE,
                    "ORD02A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
        void QuickSave(object sender, QBiz qBi, QBiz.ExcuteCompleteArgs e)
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


        DataSet GetSaveData(string overwrite)
        {
            try
            {

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                //기본정보
                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //                
                paramTable1.Columns.Add("PROD_CODE", typeof(String));
                paramTable1.Columns.Add("PROD_NAME", typeof(String));
                paramTable1.Columns.Add("PROD_STATE", typeof(String));
                paramTable1.Columns.Add("PROD_VERSION", typeof(String));
                paramTable1.Columns.Add("PROC_FLAG", typeof(String));
                paramTable1.Columns.Add("PROD_FLAG", typeof(String));
                paramTable1.Columns.Add("INS_YN", typeof(String));
                paramTable1.Columns.Add("SOCKET_YN", typeof(String));
                paramTable1.Columns.Add("PROD_TYPE", typeof(String));
                paramTable1.Columns.Add("PROD_CATEGORY", typeof(String));
                paramTable1.Columns.Add("BUSINESS_EMP", typeof(String));
                paramTable1.Columns.Add("CUSTOMER_EMP", typeof(String));
                paramTable1.Columns.Add("CUSTDESIGN_EMP", typeof(String));
                paramTable1.Columns.Add("ACTUATOR_YN", typeof(String));
                paramTable1.Columns.Add("CVND_CODE", typeof(String));
                paramTable1.Columns.Add("TVND_CODE", typeof(String));
                paramTable1.Columns.Add("PIN_TYPE", typeof(String));
                paramTable1.Columns.Add("CURR_UNIT", typeof(String));
                paramTable1.Columns.Add("ORD_DATE", typeof(String));
                paramTable1.Columns.Add("DUE_DATE", typeof(String));
                paramTable1.Columns.Add("CHG_DUE_DATE", typeof(String));
                //paramTable1.Columns.Add("DELIVERY_DATE", typeof(String));
                paramTable1.Columns.Add("PROD_QTY", typeof(int));
                paramTable1.Columns.Add("ORD_VAT", typeof(String));
                paramTable1.Columns.Add("PROD_COST", typeof(decimal));
                paramTable1.Columns.Add("PROD_AMT", typeof(decimal));
                paramTable1.Columns.Add("TRADE_YN", typeof(String));
                paramTable1.Columns.Add("TAX_YN", typeof(String));
                paramTable1.Columns.Add("BILL_YN", typeof(String));
                paramTable1.Columns.Add("SCOMMENT", typeof(String));
                paramTable1.Columns.Add("REMARK", typeof(String));

                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부



                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = layoutRow["PROD_CODE"];
                paramRow1["PROD_NAME"] = layoutRow["PROD_NAME"];
                paramRow1["PROD_STATE"] = layoutRow["PROD_STATE"];
                paramRow1["PROD_VERSION"] = layoutRow["PROD_VERSION"];
                paramRow1["PROC_FLAG"] = layoutRow["PROC_FLAG"];
                paramRow1["PROD_FLAG"] = layoutRow["PROD_FLAG"];
                paramRow1["INS_YN"] = layoutRow["INS_YN"];
                paramRow1["SOCKET_YN"] = layoutRow["SOCKET_YN"];
                paramRow1["PROD_TYPE"] = layoutRow["PROD_TYPE"];
                paramRow1["PROD_CATEGORY"] = layoutRow["PROD_CATEGORY"];
                paramRow1["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow1["CUSTOMER_EMP"] = layoutRow["CUSTOMER_EMP"];
                paramRow1["CUSTDESIGN_EMP"] = layoutRow["CUSTDESIGN_EMP"];
                paramRow1["ACTUATOR_YN"] = layoutRow["ACTUATOR_YN"];
                paramRow1["CVND_CODE"] = layoutRow["CVND_CODE"];
                paramRow1["TVND_CODE"] = layoutRow["TVND_CODE"];
                paramRow1["PIN_TYPE"] = layoutRow["PIN_TYPE"];
                paramRow1["CURR_UNIT"] = layoutRow["CURR_UNIT"];
                paramRow1["ORD_DATE"] = layoutRow["ORD_DATE"];
                paramRow1["DUE_DATE"] = layoutRow["DUE_DATE"];
                paramRow1["CHG_DUE_DATE"] = layoutRow["CHG_DUE_DATE"];
                paramRow1["SHIP_DATE"] = layoutRow["SHIP_DATE"];
                paramRow1["PROD_QTY"] = layoutRow["PROD_QTY"];
                paramRow1["ORD_VAT"] = layoutRow["ORD_VAT"];
                paramRow1["PROD_COST"] = layoutRow["PROD_COST"];
                paramRow1["PROD_AMT"] = layoutRow["PROD_AMT"];
                paramRow1["TRADE_YN"] = layoutRow["TRADE_YN"];
                paramRow1["TAX_YN"] = layoutRow["TAX_YN"];
                paramRow1["BILL_YN"] = layoutRow["BILL_YN"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["REMARK"] = layoutRow["REMARK"];
                paramRow1["REG_EMP"] = acInfo.UserID;
                paramRow1["OVERWRITE"] = overwrite;


                paramTable1.Rows.Add(paramRow1);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);

                return paramSet;
            }
            catch(Exception ex)
            {

                acMessageBox.Show(this,ex);
                return null;
            }

        }
       
    }
}