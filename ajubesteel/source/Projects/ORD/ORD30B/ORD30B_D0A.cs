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

namespace ORD
{
    public sealed partial class ORD30B_D0A : BaseMenuDialog
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


        public ORD30B_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;
            _LinkView = linkView;

        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            acLayoutControl layout = sender as acLayoutControl;

            layout.GetEditor("SHIP_EMP").Value = acInfo.UserID;
            layout.GetEditor("SHIP_DATE").Value = DateTime.Now;

            base.ChildContainerInit(sender);
        }


        public override void DialogInit()
        {
            acLayoutControl1.KeyColumns = new string[] { "ITEM_CODE" };

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;
                
                string sMSG = "[출 하] 하시겠습니까?";
   
                if (acMessageBox.Show(sMSG, this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ITEM_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("SHIP_QTY", typeof(int)); //
                paramTable.Columns.Add("SHIP_DATE", typeof(String)); //
                paramTable.Columns.Add("SHIP_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("STK_ID", typeof(String)); //
                paramTable.Columns.Add("DELIVERY", typeof(String));

                foreach (DataRow dr in (List<DataRow>)_LinkData)
                {
                    DataRow paramRow = paramTable.NewRow();

                    DataRow row = dr;

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ITEM_CODE"] = row["ITEM_CODE"];
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["SHIP_QTY"] = row["PART_QTY"];
                    paramRow["SHIP_DATE"] = layoutRow["SHIP_DATE"];
                    paramRow["SHIP_EMP"] = layoutRow["SHIP_EMP"];
                    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["STK_ID"] = row["STK_ID"];
                    paramRow["DELIVERY"] = row["DELIVERY"];

                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "ORD30B_INS", paramSet, "RQSTDT", "RSLTDT",
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

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
    }
}