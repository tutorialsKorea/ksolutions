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
    public sealed partial class STD02A_D0A : BaseMenuDialog
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


        public STD02A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();


            _LinkView = linkView;

            _LinkData = linkData;



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

                    layout.GetEditor("MAT_MTYPE").Value = null;
                    layout.GetEditor("MAT_STYPE").Value = null;

                    if (newValue == null) return;

                    (layout.GetEditor("MAT_MTYPE").Editor as acLookupEdit).SetCode("M015",newValue);


                    break;

                case "MAT_MTYPE":

                    layout.GetEditor("MAT_STYPE").Value = null;

                    if (newValue == null) return;

                    (layout.GetEditor("MAT_STYPE").Editor as acLookupEdit).SetCode("M016", newValue);


                    break;


                //case "SPEC_TYPE":



                //    if (acChecker.isNull(acLookupEdit9.EditValue) == false)
                //    {

                //        layout.GetEditor("MAT_SPEC").Editor.Enabled = true;
                //        layout.GetEditor("MAT_SPEC1").Editor.Enabled = true;
                //        layout.GetEditor("AUTO_MARGIN_SPEC").Editor.Enabled = true;

                //        DataRow codeRow = acInfo.StdCodes.GetCodeRow("S062", layout.GetEditor("SPEC_TYPE").Value);


                //        if (!codeRow["VALUE"].isNullOrEmpty())
                //        {
                //            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                //            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                //            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;


                //            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                //            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                //            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;


                //            (layout.GetEditor("AUTO_MARGIN_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                //            (layout.GetEditor("AUTO_MARGIN_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                //            (layout.GetEditor("AUTO_MARGIN_SPEC").Editor as acTextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;




                //        }
                //        else
                //        {
                //            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                //            (layout.GetEditor("MAT_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = null;

                //            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                //            (layout.GetEditor("MAT_SPEC1").Editor as acTextEdit).Properties.Mask.EditMask = null;

                //            (layout.GetEditor("AUTO_MARGIN_SPEC").Editor as acTextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                //            (layout.GetEditor("AUTO_MARGIN_SPEC").Editor as acTextEdit).Properties.Mask.EditMask = null;

                //        }
                //    }
                //    else
                //    {

                //        layout.GetEditor("MAT_SPEC").Editor.Enabled = false;
                //        layout.GetEditor("MAT_SPEC1").Editor.Enabled = false;
                //        layout.GetEditor("AUTO_MARGIN_SPEC").Editor.Enabled = false;
                //    }



                //    break;


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
            (acLayoutControl1.GetEditor("MAT_TYPE1") as acLookupEdit).SetCode("M001");

            //자재형태 : 일반/구매/소모품
            (acLayoutControl1.GetEditor("MAT_TYPE") as acLookupEdit).SetCode("S016");


            //품목유형 -- 2022.01.25 pkd (임시추가)
            (acLayoutControl1.GetEditor("PART_CAT") as acLookupEdit).SetCode("P030");


            //부품제작구분
            (acLayoutControl1.GetEditor("PART_PRODTYPE") as acLookupEdit).SetCode("M007");


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
            (acLayoutControl1.GetEditor("STK_LOCATION") as acLookupEdit).SetCode("M005");


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("MNG_NO").Value = "1";



        }

        public override void DialogOpen()
        {
            //열기
            try
            { 
                barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                acLayoutControl1.DataBind((DataRow)_LinkData, true);

                if(((DataRow)_LinkData)["MNG_FLAG"].ToString() == "Y")
                {
                    acLayoutControl1.GetEditor("MNG_YES").Value = "1";
                }
                else
                {
                    acLayoutControl1.GetEditor("MNG_NO").Value = "1";
                }

            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = layoutRow["PART_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                    "STD02A_DEL", paramSet, "RQSTDT", "",
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
            //삭제후
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

                DataSet paramSet = GetData("1");

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "STD02A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                paramTable.Columns.Add("PART_NAME", typeof(String)); //
                //paramTable.Columns.Add("PART_ENAME", typeof(String)); //

                paramTable.Columns.Add("PART_CAT", typeof(String)); //  2022.01.25 pkd 추가

                //paramTable.Columns.Add("PART_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("MAT_TYPE", typeof(String)); //
                paramTable.Columns.Add("PART_PRODTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_STYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_TYPE1", typeof(String)); //
                paramTable.Columns.Add("MAT_TYPE2", typeof(String)); //
                paramTable.Columns.Add("MAT_UNIT", typeof(String)); //
                paramTable.Columns.Add("PACK_UNIT", typeof(String)); //
                paramTable.Columns.Add("MAT_COST", typeof(Decimal)); //
                //paramTable.Columns.Add("MAT_QLTY", typeof(String)); //
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable.Columns.Add("SUPP_VND", typeof(String)); //
                //paramTable.Columns.Add("STD_PT_NUM", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("SPEC_TYPE", typeof(String)); //                
                paramTable.Columns.Add("MAT_SPEC", typeof(String)); //
                paramTable.Columns.Add("CUTTING_CNT", typeof(decimal)); //
                //paramTable.Columns.Add("MAT_SPEC1", typeof(String)); //
                //paramTable.Columns.Add("SCH_METHOD", typeof(Byte)); //
                paramTable.Columns.Add("LOAD_FLAG", typeof(Byte)); //
                paramTable.Columns.Add("INS_FLAG", typeof(String)); //
                paramTable.Columns.Add("ACT_CODE", typeof(String)); //
                //paramTable.Columns.Add("IF_PART_CODE", typeof(String)); //

                paramTable.Columns.Add("STK_LOCATION", typeof(String)); //
                paramTable.Columns.Add("SAFE_STK_QTY", typeof(Decimal)); //

                //paramTable.Columns.Add("AUTO_CREATE", typeof(Byte)); //
                //paramTable.Columns.Add("AUTO_MARGIN", typeof(Byte)); //
                //paramTable.Columns.Add("AUTO_MARGIN_SPEC", typeof(String)); //

                paramTable.Columns.Add("STK_MNG", typeof(Byte)); //

                paramTable.Columns.Add("DRAW_NO", typeof(String)); //
                paramTable.Columns.Add("PROC_COST", typeof(decimal)); //
                

                paramTable.Columns.Add("MNG_FLAG", typeof(String));  // 관리유무

                paramTable.Columns.Add("BALJU_QTY", typeof(int)); //
                paramTable.Columns.Add("IS_MAIN_PART", typeof(byte)); //
                paramTable.Columns.Add("IS_MAIN_SEARCH", typeof(byte)); //

                paramTable.Columns.Add("PROC_COST2", typeof(decimal)); //
                paramTable.Columns.Add("MAIN_VND2", typeof(String)); //

                paramTable.Columns.Add("CAM_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MIL_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MC_TIME", typeof(decimal)); //
                paramTable.Columns.Add("MID_INS_TIME", typeof(decimal)); //
                paramTable.Columns.Add("ASSEY_TIME", typeof(decimal)); //
                paramTable.Columns.Add("SHIP_INS_TIME", typeof(decimal)); //

                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = layoutRow["PART_CODE"];
                paramRow["PART_NAME"] = layoutRow["PART_NAME"];
                //paramRow["PART_ENAME"] = layoutRow["PART_ENAME"];

                //paramRow["PART_SEQ"] = layoutRow["PART_SEQ"];
                paramRow["MAT_TYPE"] = layoutRow["MAT_TYPE"];
                paramRow["MAT_TYPE1"] = layoutRow["MAT_TYPE1"];
                paramRow["MAT_TYPE2"] = layoutRow["MAT_TYPE2"];
                paramRow["PART_PRODTYPE"] = layoutRow["PART_PRODTYPE"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramRow["MAT_STYPE"] = layoutRow["MAT_STYPE"];
                paramRow["MAT_UNIT"] = layoutRow["MAT_UNIT"];
                paramRow["PACK_UNIT"] = layoutRow["PACK_UNIT"];
                paramRow["MAT_COST"] = layoutRow["MAT_COST"];
                //paramRow["MAT_QLTY"] = layoutRow["MAT_QLTY"];
                paramRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                paramRow["SUPP_VND"] = layoutRow["SUPP_VND"];
                //paramRow["STD_PT_NUM"] = layoutRow["STD_PT_NUM"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                //paramRow["SPEC_TYPE"] = layoutRow["SPEC_TYPE"];                
                paramRow["MAT_SPEC"] = layoutRow["MAT_SPEC"];
                paramRow["CUTTING_CNT"] = layoutRow["CUTTING_CNT"];
                //paramRow["SCH_METHOD"] = layoutRow["SCH_METHOD"].toByte();
                //paramRow["LOAD_FLAG"] = layoutRow["LOAD_FLAG"];
                paramRow["INS_FLAG"] = layoutRow["INS_FLAG"];
                //paramRow["ACT_CODE"] = layoutRow["ACT_CODE"];
                //paramRow["IF_PART_CODE"] = layoutRow["IF_PART_CODE"];
                paramRow["STK_LOCATION"] = layoutRow["STK_LOCATION"];
                paramRow["SAFE_STK_QTY"] = layoutRow["SAFE_STK_QTY"];

                //paramRow["AUTO_CREATE"] = layoutRow["AUTO_CREATE"];
                //paramRow["AUTO_MARGIN"] = layoutRow["AUTO_MARGIN"];
                //paramRow["AUTO_MARGIN_SPEC"] = layoutRow["AUTO_MARGIN_SPEC"];

                //paramRow["STK_MNG"] = layoutRow["STK_MNG"];

                paramRow["PART_CAT"] = layoutRow["PART_CAT"]; // 2022.01.25 pkd 추가

                paramRow["DRAW_NO"] = layoutRow["DRAW_NO"];
                paramRow["PROC_COST"] = layoutRow["PROC_COST"];

                paramRow["BALJU_QTY"] = layoutRow["BALJU_QTY"];

                if (layoutRow["MNG_YES"].ToString() == "1")
                    paramRow["MNG_FLAG"] = "Y";
                else
                    paramRow["MNG_FLAG"] = "N";


                paramRow["IS_MAIN_PART"] = layoutRow["IS_MAIN_PART"];
                paramRow["IS_MAIN_SEARCH"] = layoutRow["IS_MAIN_SEARCH"];

                paramRow["PROC_COST2"] = layoutRow["PROC_COST2"];
                paramRow["MAIN_VND2"] = layoutRow["MAIN_VND2"];

                paramRow["CAM_TIME"] = layoutRow["CAM_TIME"];
                paramRow["MIL_TIME"] = layoutRow["MIL_TIME"];
                paramRow["MC_TIME"] = layoutRow["MC_TIME"];
                paramRow["MID_INS_TIME"] = layoutRow["MID_INS_TIME"];
                paramRow["ASSEY_TIME"] = layoutRow["ASSEY_TIME"];
                paramRow["SHIP_INS_TIME"] = layoutRow["SHIP_INS_TIME"];

                paramRow["OVERWRITE"] = overwrite;
                paramTable.Rows.Add(paramRow);
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

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                    "STD02A_INS", paramSet, "RQSTDT", "RSLTDT",
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

        private void acCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            if(acCheckEdit1.CheckState == CheckState.Checked)
            {
                acCheckEdit2.CheckState = CheckState.Unchecked;
            }
        }

        private void acCheckEdit2_CheckStateChanged(object sender, EventArgs e)
        {
            if (acCheckEdit2.CheckState == CheckState.Checked)
            {
                acCheckEdit1.CheckState = CheckState.Unchecked;
            }
        }
    }
}