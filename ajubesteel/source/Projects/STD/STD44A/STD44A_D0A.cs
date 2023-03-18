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
    public sealed partial class STD44A_D0A : BaseMenuDialog
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

        


        public STD44A_D0A(acGridView linkView, object linkData)
        {


            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;


        }



        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            (acLayoutControl1.GetEditor("INS_INTERVAL") as acLookupEdit).SetCode("S091"); // 점검주기
            (acLayoutControl1.GetEditor("INS_ITEM") as acLookupEdit).SetCode("S092"); // 점검항목
            (acLayoutControl1.GetEditor("INS_UNIT") as acLookupEdit).SetCode("S050"); // 점검항목

            //(acLayoutControl1.GetEditor("CAT_PARENT") as acLookupEdit).SetData("CAT_NAME", "CAT_CODE", "STD14A_SER", paramSet, "RQSTDT", "RSLTDT");


            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData,true);

        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_INS_CODE", typeof(String)); //
             

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["MC_INS_CODE"] = ((DataRow)_LinkData)["MC_INS_CODE"];
             
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "STD44A_DEL", paramSet, "RQSTDT", "",
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

                DataRow unitRow = (acLayoutControl1.GetEditor("INS_UNIT").Editor as acLookupEdit).GetSelectedRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_INS_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_INTERVAL", typeof(Byte)); //
                paramTable.Columns.Add("INS_ITEM", typeof(String)); //
                paramTable.Columns.Add("INS_SEQ", typeof(int)); //
                paramTable.Columns.Add("LIMIT_LOW", typeof(String)); //
                paramTable.Columns.Add("LIMIT_HIGH", typeof(String)); //
                paramTable.Columns.Add("INS_UNIT", typeof(String)); //
                paramTable.Columns.Add("INS_METHOD", typeof(String)); //
                paramTable.Columns.Add("INS_SPEC", typeof(String)); //
                paramTable.Columns.Add("INS_ACTION", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_INS_CODE"] = ((DataRow)_LinkData)["MC_INS_CODE"];
                paramRow["INS_INTERVAL"] = layoutRow["INS_INTERVAL"];
                paramRow["INS_ITEM"] = layoutRow["INS_ITEM"];
                paramRow["INS_SEQ"] = layoutRow["INS_SEQ"];
                paramRow["INS_METHOD"] = layoutRow["INS_METHOD"];
                paramRow["LIMIT_LOW"] = layoutRow["LIMIT_LOW"];
                paramRow["LIMIT_HIGH"] = layoutRow["LIMIT_HIGH"];
                paramRow["INS_UNIT"] = layoutRow["INS_UNIT"];
                paramRow["INS_SPEC"] = layoutRow["LIMIT_LOW"].toInt().ToString() + " ~ " + layoutRow["LIMIT_HIGH"].toInt().ToString() + unitRow["CD_NAME"].ToString();
                paramRow["INS_ACTION"] = layoutRow["INS_ACTION"];
                paramRow["MDFY_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "STD44A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                acLayoutControl1.GetEditor("INS_ITEM").FocusEdit();
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
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_INS_CODE", typeof(String)); //
                paramTable.Columns.Add("INS_INTERVAL", typeof(Byte)); //
                paramTable.Columns.Add("INS_ITEM", typeof(String)); //
                paramTable.Columns.Add("INS_SEQ", typeof(int)); //
                paramTable.Columns.Add("INS_METHOD", typeof(String)); //
                paramTable.Columns.Add("LIMIT_LOW", typeof(String)); //
                paramTable.Columns.Add("LIMIT_HIGH", typeof(String)); //
                paramTable.Columns.Add("INS_UNIT", typeof(String)); //
                paramTable.Columns.Add("INS_ACTION", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
       

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = ((DataRow)_LinkData)["MC_CODE"];
                paramRow["MC_INS_CODE"] = "";
                paramRow["INS_INTERVAL"] = layoutRow["INS_INTERVAL"];
                paramRow["INS_ITEM"] = layoutRow["INS_ITEM"];
                paramRow["INS_SEQ"] = layoutRow["INS_SEQ"];
                paramRow["INS_METHOD"] = layoutRow["INS_METHOD"];
                paramRow["LIMIT_LOW"] = layoutRow["LIMIT_LOW"];
                paramRow["LIMIT_HIGH"] = layoutRow["LIMIT_HIGH"];
                paramRow["INS_UNIT"] = layoutRow["INS_UNIT"];
                paramRow["INS_ACTION"] = layoutRow["INS_ACTION"];
                paramRow["REG_EMP"] = acInfo.UserID;
                
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                    "STD44A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
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

            acMessageBox.Show(this, ex);

        } 
    }
}