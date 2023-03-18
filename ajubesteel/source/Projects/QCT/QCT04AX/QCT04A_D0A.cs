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
    public partial class QCT04A_D0A : BaseMenuDialog
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

        public QCT04A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;
        }

        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("QCT_CAT").Editor as acLookupEdit).SetCode("M035");
            (acLayoutControl1.GetEditor("QCT_CODE").Editor as acLookupEdit).SetCode("M036");

            acLayoutControl1.GetEditor("QCT_DATE").Value = DateTime.Now;
            acLayoutControl1.GetEditor("QCT_EMP").Value = acInfo.UserID;

            acLayoutControl1.KeyColumns = new String[] { "QCT_NO" };

            acLayoutControl1.OnValueChanged += AcLayoutControl1_OnValueChanged;
            
            base.DialogInit();
        }

        private void AcLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                switch (info.ColumnName)
                {
                    case "QCT_CAT":
                        (acLayoutControl1.GetEditor("QCT_CODE").Editor as acLookupEdit).SetCode("M036", newValue);
                        break;
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void DialogOpen()
        {
            acLayoutControl1.DataBind((DataRow)this._LinkData, true);

            base.DialogOpen();
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }



        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {

                if (acLayoutControl1.ValidCheck() == false) return;
                
                if(acMessageBox.Show(this,"저장하시겠습니까?","",false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCT_NO", typeof(String)); //
                paramTable.Columns.Add("QCT_DATE", typeof(String)); //
                paramTable.Columns.Add("QCT_EMP", typeof(String)); //
                paramTable.Columns.Add("QCT_CAT", typeof(String)); //
                paramTable.Columns.Add("QCT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCT_COST", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["QCT_NO"] = linkRow["QCT_NO"];
                paramRow["QCT_DATE"] = layoutRow["QCT_DATE"];
                paramRow["QCT_EMP"] = layoutRow["QCT_EMP"];
                paramRow["QCT_CAT"] = layoutRow["QCT_CAT"];
                paramRow["QCT_CODE"] = layoutRow["QCT_CODE"];
                paramRow["QCT_COST"] = layoutRow["QCT_COST"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT04A_INS", paramSet, "RQSTDT", "RSLTDT",
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
            //창고정


            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
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

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                if (acLayoutControl1.ValidCheck() == false) return;

                if (acMessageBox.Show(this, "저장하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCT_NO", typeof(String)); //
                paramTable.Columns.Add("QCT_DATE", typeof(String)); //
                paramTable.Columns.Add("QCT_EMP", typeof(String)); //
                paramTable.Columns.Add("QCT_CAT", typeof(String)); //
                paramTable.Columns.Add("QCT_CODE", typeof(String)); //
                paramTable.Columns.Add("QCT_COST", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                if (layoutRow["QCT_NO"].isNullOrEmpty() == false)
                {
                    paramRow["QCT_NO"] = layoutRow["QCT_NO"];
                }
                paramRow["QCT_DATE"] = layoutRow["QCT_DATE"];
                paramRow["QCT_EMP"] = layoutRow["QCT_EMP"];
                paramRow["QCT_CAT"] = layoutRow["QCT_CAT"];
                paramRow["QCT_CODE"] = layoutRow["QCT_CODE"];
                paramRow["QCT_COST"] = layoutRow["QCT_COST"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT04A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acLayoutControl1.DataBind(row, false);
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
