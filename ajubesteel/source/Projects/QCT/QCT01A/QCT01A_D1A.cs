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

namespace QCT
{
    public partial class QCT01A_D1A : BaseMenuDialog
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

        public QCT01A_D1A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;
        }

        public override void DialogInit()
        {

            
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //주원인

            (acLayoutControl1.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");



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


            }
        }

        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();

        }

        public override void DialogOpen()
        {

            //열기

            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)this._LinkData, true);


            base.DialogOpen();

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {

                if (acLayoutControl1.ValidCheck() == false) return;
                
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("WK_NG_QTY", typeof(Int32));
                paramTable.Columns.Add("NG_ID", typeof(String));
                paramTable.Columns.Add("REG_EMP", typeof(String));
                paramTable.Columns.Add("PROD_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("NG_MEASURE_EMP", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = linkRow["WO_NO"];
                paramRow["WK_NG_QTY"] = layoutRow["QUANTITY"];
                paramRow["NG_ID"] = linkRow["NG_ID"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["PROD_CODE"] = linkRow["PROD_CODE"];
                paramRow["PART_CODE"] = linkRow["PART_CODE"];
                paramRow["NG_MEASURE_EMP"] = linkRow["NG_MEASURE_EMP"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_INS2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);

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

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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
