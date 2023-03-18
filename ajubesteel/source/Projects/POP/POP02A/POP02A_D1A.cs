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
    public partial class POP02A_D1A : BaseMenuDialog
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

        private bool _isPopup = false;

        public POP02A_D1A(acGridView linkView, object linkData, bool isPopUp = false)
        {
            InitializeComponent();


            _LinkView = linkView;

            _LinkData = linkData;

            _isPopup = isPopUp;
        }

        public override void DialogInit()
        {

            //barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnProcLink.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //주원인
            (acLayoutControl1.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C400");


            //불량형태
            (acLayoutControl1.GetEditor("NG_TYPE").Editor as acLookupEdit).SetCode("Q004");

            //불량 분류(사내/외주)
            (acLayoutControl1.GetEditor("NG_CAT").Editor as acLookupEdit).SetCode("Q005");

            //불량비용항목
            (acLayoutControl1.GetEditor("NG_COST_CODE").Editor as acLookupEdit).SetCode("M036", "FCOST");

            //발생처
            (acLayoutControl1.GetEditor("NG_OCCUR").Editor as acCheckedComboBoxEdit).AddItem("Q007", 0, 1, CheckState.Unchecked);

            acLayoutControl1.GetEditor("NG_MEASURE_EMP").Value = acInfo.UserID;


            

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            DataRow linkRow = (DataRow)_LinkData;

            base.DialogInit();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;
            switch (info.ColumnName)
            {
                case "LINK_KEY":
                    DataRow woRow = acWorkOrder1.SelectedRow;

                    layout.GetEditor("PROC_CODE").Value = woRow["PROC_CODE"];
                    layout.GetEditor("PROD_CODE").Value = woRow["PROD_CODE"];
                    layout.GetEditor("PART_CODE").Value = woRow["PART_CODE"];
                    layout.GetEditor("PART_NAME").Value = woRow["PART_NAME"];
                    layout.GetEditor("PROD_NAME").Value = woRow["PROD_NAME"];

                    break;

                case "MASTER_CAUSE":
                    //사내불량 상세원인 설정
                    (layout.GetEditor("DETAIL_CAUSE").Editor as acLookupEdit).SetCode("C401", newValue);
                    break;
                case "NG_OUT_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_LAB_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_DIST_COST").Value.toDecimal()
                                                                + newValue.toDecimal();
                    break;
                case "NG_PROC_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OUT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_LAB_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_DIST_COST").Value.toDecimal()
                                                                + newValue.toDecimal();
                    break;
                case "NG_MAT_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OUT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_LAB_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_DIST_COST").Value.toDecimal()
                                                                + newValue.toDecimal();
                    break;
                case "NG_LAB_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OUT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_DIST_COST").Value.toDecimal()
                                                                + newValue.toDecimal();
                    break;
                case "NG_DIST_COST":
                    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OUT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_LAB_COST").Value.toDecimal()
                                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                                                                + newValue.toDecimal();
                    break;


            }
        }

        public override void DialogNew()
        {
            //새로만들기
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            acLayoutControl1.GetEditor("QUANTITY").isReadyOnly = false;


            base.DialogNew();

        }

        public override void DialogOpen()
        {
            base.DialogOpen();

            //열기

            //barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnProcLink.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)this._LinkData;

            acLayoutControl1.DataBind(linkRow, true);

            acLayoutControl1.GetEditor("LINK_KEY").isReadyOnly = true;
            acLayoutControl1.GetEditor("QUANTITY").isReadyOnly = true;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("NG_ID", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["NG_ID"] = linkRow["NG_ID"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "QCT01A_SER3", paramSet, "RQSTDT", "RSLTDT");

            if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
            {
                acLayoutControl1.GetEditor("NG_IMG").Value = resultSet.Tables["RSLTDT"].Rows[0]["NG_IMG"];
            }


            if (_isPopup)
            {
                barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                acLayoutControl1.SetAllReadOnly(true);
            }

            acAttachFileControl21.LinkKey = linkRow["NG_ID"];
            acAttachFileControl21.ShowKey = new object[] { linkRow["NG_ID"] };
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
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("LINK_KEY", typeof(String)); //
                paramTable.Columns.Add("ACT_TYPE", typeof(String)); //
                paramTable.Columns.Add("MASTER_CAUSE", typeof(String)); //
                paramTable.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                paramTable.Columns.Add("QUANTITY", typeof(Int32)); //
                paramTable.Columns.Add("NG_CAUSE", typeof(String)); //
                paramTable.Columns.Add("NG_CONTENTS", typeof(String)); //
                paramTable.Columns.Add("NG_MEASURE", typeof(String)); //
                paramTable.Columns.Add("NG_TYPE", typeof(String)); //
                paramTable.Columns.Add("NG_CAT", typeof(String));
                paramTable.Columns.Add("NG_OCCUR", typeof(String));
                paramTable.Columns.Add("NG_OUT_COST", typeof(decimal));
                paramTable.Columns.Add("NG_PROC_COST", typeof(decimal));
                paramTable.Columns.Add("NG_COST", typeof(decimal));
                paramTable.Columns.Add("NG_COST_CODE", typeof(String));
                paramTable.Columns.Add("NG_MAT_COST", typeof(decimal));
                paramTable.Columns.Add("NG_LAB_COST", typeof(decimal));
                paramTable.Columns.Add("NG_DIST_COST", typeof(decimal));
                paramTable.Columns.Add("NG_MEASURE_EMP", typeof(String)); 
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_IMG", typeof(byte[])); //
                paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //
                paramTable.Columns.Add("DEV_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NG_ID"] = null;
                paramRow["WO_NO"] = layoutRow["LINK_KEY"];
                paramRow["LINK_KEY"] = layoutRow["LINK_KEY"];
                paramRow["ACT_TYPE"] = "W";
                paramRow["MASTER_CAUSE"] = layoutRow["MASTER_CAUSE"];
                paramRow["DETAIL_CAUSE"] = layoutRow["DETAIL_CAUSE"];
                paramRow["QUANTITY"] = layoutRow["QUANTITY"];
                paramRow["NG_CAUSE"] = layoutRow["NG_CAUSE"];
                paramRow["NG_CONTENTS"] = layoutRow["NG_CONTENTS"];
                paramRow["NG_MEASURE"] = layoutRow["NG_MEASURE"];
                paramRow["NG_TYPE"] = layoutRow["NG_TYPE"];
                paramRow["NG_CAT"] = layoutRow["NG_CAT"];
                paramRow["NG_OCCUR"] = layoutRow["NG_OCCUR"];
                paramRow["NG_OUT_COST"] = layoutRow["NG_OUT_COST"];
                paramRow["NG_PROC_COST"] = layoutRow["NG_PROC_COST"];
                paramRow["NG_COST"] = layoutRow["NG_COST"];
                paramRow["NG_COST_CODE"] = layoutRow["NG_COST_CODE"];
                paramRow["NG_MAT_COST"] = layoutRow["NG_MAT_COST"];
                paramRow["NG_LAB_COST"] = layoutRow["NG_LAB_COST"];
                paramRow["NG_DIST_COST"] = layoutRow["NG_DIST_COST"];
                paramRow["NG_MEASURE_EMP"] = layoutRow["NG_MEASURE_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["MDFY_EMP"] = acInfo.UserID;
                paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["NG_IMG"] = layoutRow["NG_IMG"];
                paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow["DEV_EMP"] = layoutRow["DEV_EMP"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01B_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("LINK_KEY", typeof(String)); //
                paramTable.Columns.Add("ACT_TYPE", typeof(String)); //
                paramTable.Columns.Add("MASTER_CAUSE", typeof(String)); //
                paramTable.Columns.Add("DETAIL_CAUSE", typeof(String)); //
                paramTable.Columns.Add("QUANTITY", typeof(Int32)); //
                paramTable.Columns.Add("NG_CAUSE", typeof(String)); //
                paramTable.Columns.Add("NG_CONTENTS", typeof(String)); //
                paramTable.Columns.Add("NG_MEASURE", typeof(String)); //
                paramTable.Columns.Add("NG_TYPE", typeof(String)); //
                paramTable.Columns.Add("NG_CAT", typeof(String));
                paramTable.Columns.Add("NG_OCCUR", typeof(String));
                paramTable.Columns.Add("NG_OUT_COST", typeof(decimal));
                paramTable.Columns.Add("NG_PROC_COST", typeof(decimal));
                paramTable.Columns.Add("NG_COST", typeof(decimal));
                paramTable.Columns.Add("NG_COST_CODE", typeof(String));
                paramTable.Columns.Add("NG_MAT_COST", typeof(decimal));
                paramTable.Columns.Add("NG_LAB_COST", typeof(decimal));
                paramTable.Columns.Add("NG_DIST_COST", typeof(decimal));
                paramTable.Columns.Add("NG_MEASURE_EMP", typeof(String)); 
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_IMG", typeof(byte[])); //
                paramTable.Columns.Add("BUSINESS_EMP", typeof(String)); //
                paramTable.Columns.Add("DEV_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NG_ID"] = linkRow["NG_ID"];
                paramRow["WO_NO"] = layoutRow["LINK_KEY"];
                paramRow["LINK_KEY"] = layoutRow["LINK_KEY"];
                paramRow["ACT_TYPE"] = "W";
                paramRow["MASTER_CAUSE"] = layoutRow["MASTER_CAUSE"];
                paramRow["DETAIL_CAUSE"] = layoutRow["DETAIL_CAUSE"];
                paramRow["QUANTITY"] = layoutRow["QUANTITY"];
                paramRow["NG_CAUSE"] = layoutRow["NG_CAUSE"];
                paramRow["NG_CONTENTS"] = layoutRow["NG_CONTENTS"];
                paramRow["NG_MEASURE"] = layoutRow["NG_MEASURE"];
                paramRow["NG_TYPE"] = layoutRow["NG_TYPE"];
                paramRow["NG_CAT"] = layoutRow["NG_CAT"];
                paramRow["NG_OCCUR"] = layoutRow["NG_OCCUR"];
                paramRow["NG_OUT_COST"] = layoutRow["NG_OUT_COST"];
                paramRow["NG_PROC_COST"] = layoutRow["NG_PROC_COST"];
                paramRow["NG_COST"] = layoutRow["NG_COST"];
                paramRow["NG_COST_CODE"] = layoutRow["NG_COST_CODE"];
                paramRow["NG_MAT_COST"] = layoutRow["NG_MAT_COST"];
                paramRow["NG_LAB_COST"] = layoutRow["NG_LAB_COST"];
                paramRow["NG_DIST_COST"] = layoutRow["NG_DIST_COST"];
                paramRow["NG_MEASURE_EMP"] = layoutRow["NG_MEASURE_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["MDFY_EMP"] = acInfo.UserID;
                paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["NG_IMG"] = layoutRow["NG_IMG"];
                paramRow["BUSINESS_EMP"] = layoutRow["BUSINESS_EMP"];
                paramRow["DEV_EMP"] = layoutRow["DEV_EMP"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01B_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                    acAttachFileControl21.LinkKey = row["NG_ID"];
                    acAttachFileControl21.ShowKey = new object[] { row["NG_ID"] };
                    acAttachFileControl21.UploadFile();

                    _LinkView.RaiseFocusedRowChanged();
                }

                this.ControlBox = false;
                _saveMode = "Save";
                barItemSave.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        string _saveMode = "";

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);

                    acAttachFileControl21.LinkKey = row["NG_ID"];
                    acAttachFileControl21.ShowKey = new object[] { row["NG_ID"] };
                    acAttachFileControl21.UploadFile();

                    _LinkView.RaiseFocusedRowChanged();
                }

                this.ControlBox = false;
                _saveMode = "SaveClose";
                barItemSave.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void formClose()
        {
            while (true)
            {
                if (acAttachFileControl21.isComplete == true)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }

            if (acAttachFileControl21.isComplete == true)
            {
                this.Invoke(new MethodInvoker(end));
            }
        }
        void end()
        {
            if (_saveMode == "Save")
            {
                barItemSave.Enabled = true;
                this.ControlBox = true;
            }
            else if (_saveMode == "SaveClose")
            {
                this.Close();
            }

        }



        private void barItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = (DataRow)this._LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NG_ID"] = linkRow["NG_ID"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_DEL", paramSet, "RQSTDT", "",
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
