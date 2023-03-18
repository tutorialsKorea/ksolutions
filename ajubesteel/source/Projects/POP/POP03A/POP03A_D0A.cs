using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;
using System.Linq;

namespace POP
{
    public partial class POP03A_D0A : BaseMenuDialog
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

        public POP03A_D0A(acGridView linkView, object linkData,bool isEnd)
        {
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;

           // _isEnd = isEnd;

            _isEnd = true;
        }


        private bool _isEnd = false;
        public override void DialogInit()
        {

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            ////주원인
            //(acLayoutControl1.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");


            ////불량형태
            //(acLayoutControl1.GetEditor("NG_TYPE").Editor as acLookupEdit).SetCode("Q004");

            ////불량 분류(사내/외주)
            //(acLayoutControl1.GetEditor("NG_CAT").Editor as acLookupEdit).SetCode("Q005");

            ////불량비용항목
            //(acLayoutControl1.GetEditor("NG_COST_CODE").Editor as acLookupEdit).SetCode("M036", "FCOST");

            //acLayoutControl1.GetEditor("NG_MEASURE_EMP").Value = acInfo.UserID; 

            acRadioGroup1.AddRadioItem("No", false, "", false, "", "0");
            acRadioGroup1.AddRadioItem("Yes", false, "", false, "", "1");

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            
            base.DialogInit();
        }
        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;
            switch (info.ColumnName)
            {
                case "MAT_OUT":
                   
                    if(newValue.ToString() == "0")
                    {
                        layout.GetEditor("OUT_MAT_CODE").isReadyOnly = true;
                        layout.GetEditor("OUT_QTY").isReadyOnly = true;
                        layout.GetEditor("OUT_MAT_CODE").Value = null;
                        layout.GetEditor("OUT_QTY").Value = 0;
                    }
                    else
                    {
                        layout.GetEditor("OUT_MAT_CODE").isReadyOnly = false;
                        layout.GetEditor("OUT_QTY").isReadyOnly = false;
                        layout.GetEditor("OUT_MAT_CODE").Value = layout.GetEditor("MAT_CODE").Value;
                    }

                    break;              

            }
        }

        public override void DialogNew()
        {
            //새로만들기



            //barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;            

            acLayoutControl1.DataBind((DataRow)this._LinkData, true);

            acRadioGroup1.Value = "0";

            acLayoutControl1.GetEditor("MILL_EMP").Value = acInfo.UserID;
            

            base.DialogNew();

        }

        public override void DialogOpen()
        {
            base.DialogOpen();

            //열기

            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            
            acLayoutControl1.DataBind((DataRow)this._LinkData, true);

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

                OutputData = layoutRow;

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정


            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
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

                OutputData = layoutRow;

                DialogResult = DialogResult.OK;

                //DataRow linkRow = this._LinkData as DataRow;

                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("WO_NO", typeof(String)); //
                //paramTable.Columns.Add("PT_ID", typeof(String)); //
                //paramTable.Columns.Add("ACTUAL_ID", typeof(String)); //
                //paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                //paramTable.Columns.Add("MAT_CODE", typeof(String)); //
                //paramTable.Columns.Add("MAT_OUT", typeof(String)); //
                //paramTable.Columns.Add("OUT_MAT_CODE", typeof(String)); //
                //paramTable.Columns.Add("OUT_QTY", typeof(Int32)); //                
                //paramTable.Columns.Add("ACT_QTY", typeof(Int32)); //                
                //paramTable.Columns.Add("REG_EMP", typeof(String)); //

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["ACTUAL_ID"] = linkRow["ACTUAL_ID"];
                //paramRow["WO_NO"] = linkRow["WO_NO"];
                //paramRow["PT_ID"] = linkRow["PT_ID"];
                //paramRow["EMP_CODE"] = layoutRow["MILL_EMP"];
                //paramRow["MAT_CODE"] = layoutRow["MAT_CODE"];
                //paramRow["MAT_OUT"] = layoutRow["MAT_OUT"];
                //paramRow["OUT_MAT_CODE"] = layoutRow["OUT_MAT_CODE"];
                //paramRow["OUT_QTY"] = layoutRow["OUT_QTY"];
                //paramRow["ACT_QTY"] = layoutRow["PART_QTY"];
                //paramRow["REG_EMP"] = acInfo.UserID;

                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP03A_SAVE", paramSet, "RQSTDT", "RSLTDT",
                //        QuickSaveClose,
                //        QuickException);

                
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

                if (this._isEnd)
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, false);
                    }

                    this._LinkView.RefreshData();


                    acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
                }
                else
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        this._LinkView.DeleteMappingRow(row);
                    }
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

            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);

                if (this.DialogMode == emDialogMode.NEW)
                {

                    //클리어


                    //this.barItemClear_ItemClick(null, null);
                }
                else if (this.DialogMode == emDialogMode.OPEN)
                {

                    this.Close();

                    //갱신

                    ((BaseMenu)this.ParentControl).DataRefresh(null);

                }
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}