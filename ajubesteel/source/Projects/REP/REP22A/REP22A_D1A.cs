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

namespace REP
{
    public partial class REP22A_D1A : BaseMenuDialog
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

        private acGridView _linkView = null;

        public REP22A_D1A(acGridView linkView)
        {
            InitializeComponent();

            _linkView = linkView;
        }

        public override void DialogInit()
        {
            base.DialogInit();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
              
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

            base.DialogOpen();

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("COST_DES_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_CAM_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_MILL_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_SIDE_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_INS_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_ASSY_TIME", typeof(decimal));
                paramTable.Columns.Add("COST_SHIP_TIME", typeof(decimal));

                DataRow[] selected = _linkView.GetSelectedDataRows();

                DataRow focusRow = _linkView.GetFocusedDataRow();

                if (selected.Length == 0)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = focusRow["PART_CODE"];
                    paramRow["COST_DES_TIME"] = layoutRow["COST_DES_TIME"];
                    paramRow["COST_CAM_TIME"] = layoutRow["COST_CAM_TIME"];
                    paramRow["COST_MILL_TIME"] = layoutRow["COST_MILL_TIME"];
                    paramRow["COST_SIDE_TIME"] = layoutRow["COST_SIDE_TIME"];
                    paramRow["COST_INS_TIME"] = layoutRow["COST_INS_TIME"];
                    paramRow["COST_ASSY_TIME"] = layoutRow["COST_ASSY_TIME"];
                    paramRow["COST_SHIP_TIME"] = layoutRow["COST_SHIP_TIME"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {
                    foreach (DataRow row in selected)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["PART_CODE"] = row["PART_CODE"];
                        paramRow["COST_DES_TIME"] = layoutRow["COST_DES_TIME"];
                        paramRow["COST_CAM_TIME"] = layoutRow["COST_CAM_TIME"];
                        paramRow["COST_MILL_TIME"] = layoutRow["COST_MILL_TIME"];
                        paramRow["COST_SIDE_TIME"] = layoutRow["COST_SIDE_TIME"];
                        paramRow["COST_INS_TIME"] = layoutRow["COST_INS_TIME"];
                        paramRow["COST_ASSY_TIME"] = layoutRow["COST_ASSY_TIME"];
                        paramRow["COST_SHIP_TIME"] = layoutRow["COST_SHIP_TIME"];
                        paramTable.Rows.Add(paramRow);
                    }
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "REP22A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                    _linkView.UpdateMapingRow(row, true);
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
