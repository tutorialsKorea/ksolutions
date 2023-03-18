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

namespace POP
{
    public partial class RegNG : BaseMenuDialog
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


        public RegNG(DataRow linkData)
        {
            InitializeComponent();

            _LinkData = linkData;
        }

        private DataRow _LinkData = null;


        public override void DialogInit()
        {

            //barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //주원인
            (acLayoutControl1.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");


            //불량형태
            (acLayoutControl1.GetEditor("NG_TYPE").Editor as acLookupEdit).SetCode("Q004");

            //불량 분류(사내/외주)
            (acLayoutControl1.GetEditor("NG_CAT").Editor as acLookupEdit).SetCode("Q005");

            acLayoutControl1.GetEditor("LINK_KEY").Value = _LinkData["ACTUAL_ID"];
           
            acLayoutControl1.GetEditor("NG_OCCUR").Value = _LinkData["MC_NAME"];

            acLayoutControl1.GetEditor("NG_MEASURE_EMP").Value = acInfo.UserID; 

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            
            base.DialogInit();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MASTER_CAUSE":

                    //사내불량 상세원인 설정

                    (layout.GetEditor("DETAIL_CAUSE").Editor as acLookupEdit).SetCode("C401", newValue);

                    break;

                case "NG_OUT_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal() + newValue.toDecimal();

                    break;
                case "NG_PROC_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OUT_COST").Value.toDecimal() + newValue.toDecimal();
                    break;


            }
        }

        public override void DialogNew()
        {
            //새로만들기

            //barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            acLayoutControl1.GetEditor("LINK_KEY").isReadyOnly = false;
            acLayoutControl1.GetEditor("QUANTITY").isReadyOnly = false;


            base.DialogNew();

        }

        public override void DialogOpen()
        {
            //열기
            base.DialogOpen();
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

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_ID", typeof(String)); //
                paramTable.Columns.Add("LINK_KEY", typeof(String)); //
                paramTable.Columns.Add("ACT_TYPE", typeof(String)); //
                paramTable.Columns.Add("MASTER_CAUSE", typeof(String)); //
                paramTable.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                paramTable.Columns.Add("QUANTITY", typeof(Int32)); //
                paramTable.Columns.Add("NG_CONTENTS", typeof(String)); //
                paramTable.Columns.Add("NG_TYPE", typeof(String)); //
                paramTable.Columns.Add("NG_CAT", typeof(String));
                paramTable.Columns.Add("NG_OCCUR", typeof(String));
                paramTable.Columns.Add("NG_MEASURE_EMP", typeof(String)); 
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NG_ID"] = null;
                paramRow["LINK_KEY"] = layoutRow["LINK_KEY"];
                paramRow["ACT_TYPE"] = "W";
                paramRow["MASTER_CAUSE"] = layoutRow["MASTER_CAUSE"];
                paramRow["DETAIL_CAUSE"] = layoutRow["DETAIL_CAUSE"];
                paramRow["QUANTITY"] = layoutRow["QUANTITY"];
                paramRow["NG_CONTENTS"] = layoutRow["NG_CONTENTS"];
                paramRow["NG_TYPE"] = layoutRow["NG_TYPE"];
                paramRow["NG_CAT"] = layoutRow["NG_CAT"];
                paramRow["NG_OCCUR"] = layoutRow["NG_OCCUR"];
                paramRow["NG_MEASURE_EMP"] = layoutRow["NG_MEASURE_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_INS4", paramSet, "RQSTDT", "RSLTDT",
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
       
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
           
        }


        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           

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

    }
}
