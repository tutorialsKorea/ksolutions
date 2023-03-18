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
using CodeHelperManager;
using BizManager;

namespace STD
{
    public sealed partial class STD02A_D3A : BaseMenuDialog
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


        public STD02A_D3A(acGridView linkView)
        {

            InitializeComponent();


            _LinkView = linkView;


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }



        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            acLayoutControl layout = sender as acLayoutControl;


            switch (info.ColumnName)
            {
                case "MAT_TYPE1":

                    (layout.GetEditor("MAT_TYPE2").Editor as acLookupEdit).SetCode("M002", newValue);

                    break;


                case "MAT_LTYPE":


                    (layout.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M015",newValue);


                    break;

                case "MAT_MTYPE":


                    (layout.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M016", newValue);


                    break;



                case "STK_MNG":


                    layout.GetEditor("STK_LOCATION").isRequired = newValue.toBoolean();


                    break;

                case "MAT_QLTY":

                    if (layout.IsBinding == false)
                    {
                        layout.GetEditor("MAT_COST").Value = acMaterial.GetDataRow(newValue)["MQLTY_UC"];

                    }

                    break;
            }


        }



        public override void DialogInit()
        {




            acLayoutControl1.KeyColumns = new string[] { "PART_CODE" };


            //대분류
            (acLayoutControl1.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");

            //자재구분
            //(acLayoutControl1.GetEditor("MAT_TYPE1") as acLookupEdit).SetCode("M001");

            //자재형태 : 일반/구매/소모품
            (acLayoutControl1.GetEditor("MAT_TYPE") as acLookupEdit).SetCode("S016");


            //부품제작구분
            //(acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");


            //단위
            (acLayoutControl1.GetEditor("MAT_UNIT") as acLookupEdit).SetCode("M003");
            //포장
            (acLayoutControl1.GetEditor("PACK_UNIT") as acLookupEdit).SetCode("M003");

            //규격입력형태
            //(acLayoutControl1.GetEditor("SPEC_TYPE") as acLookupEdit).SetCode("S062");



            //BOP 부품
            //(acLayoutControl1.GetEditor("LOAD_FLAG") as acLookupEdit).SetCode("S024");

            //스케줄방법
            //(acLayoutControl1.GetEditor("SCH_METHOD") as acLookupEdit).SetCode("S060");

            //검사여부

            (acLayoutControl1.GetEditor("INS_FLAG") as acLookupEdit).SetCode("S063");

            //회계계정
            //(acLayoutControl1.GetEditor("ACT_CODE") as acLookupEdit).SetCode("C600");

            //창고
            //(acLayoutControl1.GetEditor("STK_LOCATION") as acLookupEdit).SetCode("M005");

            (acLayoutControl1.GetEditor("PART_CAT") as acLookupEdit).SetCode("P030");


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            ////20160412 김준구 - 숨김 항목 중 필수항목 기본값 적용
            //Invisible_Init();
            
            ////20160412 김준구 - 숨김 항목
            //Invisible_Item();

            base.DialogInit();
        }


        public override void DialogInitComplete()
        {
            //완료된후 이벤트 설정


            base.DialogInitComplete();
        }





        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


        }

        public override void DialogOpen()
        {
            //열기
            try
            { 
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {

                DataSet paramSet = GetData("1");

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
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

        private DataSet GetData(string overwrite)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return null;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //                                
                paramTable.Columns.Add("MAT_TYPE", typeof(String)); //                
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_STYPE", typeof(String)); //                
                paramTable.Columns.Add("MAT_UNIT", typeof(String)); //
                paramTable.Columns.Add("PACK_UNIT", typeof(String)); //                
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable.Columns.Add("SUPP_VND", typeof(String)); //                
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("PART_CAT", typeof(String)); //
                paramTable.Columns.Add("PROC_COST", typeof(decimal)); //
                paramTable.Columns.Add("PROC_COST2", typeof(decimal)); //
                paramTable.Columns.Add("MAT_COST", typeof(decimal)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //                //

                paramTable.Columns.Add("MNG_FLAG", typeof(String)); //                //
                paramTable.Columns.Add("CAM_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MIL_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MC_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MID_INS_TIME", typeof(decimal)); //
                paramTable.Columns.Add("ASSEY_TIME", typeof(decimal)); //
                paramTable.Columns.Add("SHIP_INS_TIME", typeof(decimal)); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow[] selectedRow = (_LinkView as acGridView).GetSelectedDataRows();

                foreach (DataRow row in selectedRow)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    if(chkMAT_TYPE.Checked)
                        paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];
                    else
                        paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];

                    if(chkMAT_LTYPE.Checked)
                        paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                    else
                        paramRow["MAT_LTYPE"] = row["MAT_LTYPE"];

                    if(chkMAT_MTYPE.Checked)
                        paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                    else
                        paramRow["MAT_MTYPE"] = row["MAT_MTYPE"];

                    if(chkMAT_STYPE.Checked)
                        paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                    else
                        paramRow["MAT_STYPE"] = row["MAT_STYPE"];

                    if(chkMAT_UNIT.Checked)
                        paramRow["MAT_UNIT"] = layoutRow["MAT_UNIT"];
                    else
                        paramRow["MAT_UNIT"] = row["MAT_UNIT"];

                    if(chkPACK_UNIT.Checked)
                        paramRow["PACK_UNIT"] = layoutRow["PACK_UNIT"];
                    else
                        paramRow["PACK_UNIT"] = row["PACK_UNIT"];

                    if(chkMAIN_VND.Checked)                    
                        paramRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                    else
                        paramRow["MAIN_VND"] = row["MAIN_VND"];

                    if(chkSUPP_VND.Checked)
                        paramRow["SUPP_VND"] = layoutRow["SUPP_VND"];
                    else
                        paramRow["SUPP_VND"] = row["SUPP_VND"];

                    if(chkISN_FLAG.Checked)
                        paramRow["INS_FLAG"] = layoutRow["INS_FLAG"];
                    else
                        paramRow["INS_FLAG"] = row["INS_FLAG"];

                    if (chkPART_CAT.Checked)
                        paramRow["PART_CAT"] = layoutRow["PART_CAT"];
                    else
                        paramRow["PART_CAT"] = row["PART_CAT"];

                    if (acCheckEdit1.Checked)
                        paramRow["PROC_COST"] = layoutRow["PROC_COST"];
                    else
                        paramRow["PROC_COST"] = row["PROC_COST"];

                    if (acCheckEdit3.Checked)
                        paramRow["PROC_COST2"] = layoutRow["PROC_COST2"];
                    else
                        paramRow["PROC_COST2"] = row["PROC_COST2"];

                    if (acCheckEdit2.Checked)
                        paramRow["MAT_COST"] = layoutRow["MAT_COST"];
                    else
                        paramRow["MAT_COST"] = row["MAT_COST"];

                    //
                    if (acCheckEdit4.Checked)
                        paramRow["CAM_TIME"] = layoutRow["CAM_TIME"];
                    else
                        paramRow["CAM_TIME"] = row["CAM_TIME"];

                    if (acCheckEdit5.Checked)
                        paramRow["MIL_TIME"] = layoutRow["MIL_TIME"];
                    else
                        paramRow["MIL_TIME"] = row["MIL_TIME"];

                    if (acCheckEdit6.Checked)
                        paramRow["MC_TIME"] = layoutRow["MC_TIME"];
                    else
                        paramRow["MC_TIME"] = row["MC_TIME"];

                    if (acCheckEdit7.Checked)
                        paramRow["MID_INS_TIME"] = layoutRow["MID_INS_TIME"];
                    else
                        paramRow["MID_INS_TIME"] = row["MID_INS_TIME"];

                    if (acCheckEdit8.Checked)
                        paramRow["ASSEY_TIME"] = layoutRow["ASSEY_TIME"];
                    else
                        paramRow["ASSEY_TIME"] = row["ASSEY_TIME"];

                    if (acCheckEdit9.Checked)
                        paramRow["SHIP_INS_TIME"] = layoutRow["SHIP_INS_TIME"];
                    else
                        paramRow["SHIP_INS_TIME"] = row["SHIP_INS_TIME"];

                    if (acCheckEdit10.Checked)
                    {
                        if (layoutRow["MNG_YES"].ToString() == "1")
                            paramRow["MNG_FLAG"] = "Y";
                        else
                            paramRow["MNG_FLAG"] = "N";
                    }
                    else
                    {
                        paramRow["MNG_FLAG"] = row["MNG_FLAG"];
                    }


                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = overwrite;
                    paramTable.Rows.Add(paramRow);
                    
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                return paramSet;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {

                DataSet paramSet = GetData("0");

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD02A_UPD", paramSet, "RQSTDT", "RSLTDT",
                    QuickSaveClose,
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

        private void acCheckEdit11_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit11.CheckState == CheckState.Checked)
            {
                acCheckEdit12.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit12_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit12.CheckState == CheckState.Checked)
            {
                acCheckEdit11.CheckState = CheckState.Unchecked;
            }
        }
    }
}