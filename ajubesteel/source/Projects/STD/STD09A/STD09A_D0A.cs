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
    public sealed partial class STD09A_D0A : BaseMenuDialog
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

        private string _Prod_code = string.Empty;

        public STD09A_D0A(acGridView linkView, object linkData)
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
                case "PROD_LTYPE":

                    acLookupEdit2.SetCode("C002", newValue);
                    break;


                case "PROD_MTYPE":
                    acLookupEdit3.SetCode("C012", newValue);
                    break;

            }
        }



        public override void DialogInit()
        {
            acLayoutControl1.KeyColumns = new string[] { "PROD_CODE" };

            //대분류
            (acLayoutControl1.GetEditor("PROD_LTYPE") as acLookupEdit).SetCode("C001");

            
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


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
        }

        public override void DialogOpen()
        {
            //열기
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            _Prod_code = ((DataRow)_LinkData)["PROD_CODE"].ToString();

            acLayoutControl1.DataBind((DataRow)_LinkData, true);


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PROD_CODE"] = _Prod_code;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsImage = BizRun.QBizRun.ExecuteService(this, "STD09A_SER2", paramSet, "RQSTDT", "");

            if (dsImage.Tables["RSLTDT"].Rows.Count > 0)
                acLayoutControl1.GetEditor("PROD_IMAGE").Value = dsImage.Tables["RSLTDT"].Rows[0]["PROD_IMAGE"];

        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));

                if (msgResult.DialogResult == DialogResult.No) return;

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
                    "STD09A_DEL", paramSet, "RQSTDT", "",
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

        private DataSet SaveData()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("MODEL", typeof(String)); //
            paramTable.Columns.Add("PART", typeof(String)); //
            paramTable.Columns.Add("PROD_VND", typeof(String)); //
            paramTable.Columns.Add("MAT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LTYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_MTYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_STYPE", typeof(String)); //

            paramTable.Columns.Add("MOLD_NO", typeof(String)); //
            paramTable.Columns.Add("CAVITY", typeof(Int32)); //
            paramTable.Columns.Add("TO_DATE", typeof(String)); //
            paramTable.Columns.Add("PACK_UNIT", typeof(Int32)); //
            paramTable.Columns.Add("UNIT_COST", typeof(Decimal)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("HISTORY", typeof(String)); //
            paramTable.Columns.Add("PROD_IMAGE", typeof(Byte[])); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("O_PROD_CODE", typeof(String)); //
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            paramRow["MODEL"] = layoutRow["MODEL"];
            paramRow["PART"] = layoutRow["PART"];
            paramRow["PROD_VND"] = layoutRow["PROD_VND"];
            paramRow["MAT_CODE"] = layoutRow["MAT_CODE"];
            paramRow["PROD_LTYPE"] = layoutRow["PROD_LTYPE"];
            paramRow["PROD_MTYPE"] = layoutRow["PROD_MTYPE"];
            paramRow["PROD_STYPE"] = layoutRow["PROD_STYPE"];
            paramRow["MOLD_NO"] = layoutRow["MOLD_NO"];
            paramRow["CAVITY"] = layoutRow["CAVITY"];
            paramRow["TO_DATE"] = dtpValidate2.Text; //layoutRow["TO_DATE"].toDateTime().Date;
            paramRow["PACK_UNIT"] = layoutRow["PACK_UNIT"];
            paramRow["UNIT_COST"] = layoutRow["UNIT_COST"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["HISTORY"] = layoutRow["HISTORY"];
            paramRow["PROD_IMAGE"] = acPictureEdit1.Value;
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["O_PROD_CODE"] = _Prod_code;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            return paramSet;

          
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                DataSet paramSet = SaveData();

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "STD09A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSaveClose,
                        QuickException);
                }

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

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {

                DataSet paramSet = SaveData();

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                    "STD09A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }

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




    }
}