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
    public partial class QCT03A_D0A : BaseMenuDialog
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

        public QCT03A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;
        }

        public override void DialogInit()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            (acLayoutControl1.GetEditor("EVAL_TYPE") as acLookupEdit).SetCode("Q009");

            base.DialogInit();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

        }

        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();

        }

        public override void DialogOpen()
        {

            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)this._LinkData;

            acLayoutControl1.DataBind(linkRow, true);

            acAttachFileControl21.LinkKey = linkRow["EVAL_NO"];
            acAttachFileControl21.ShowKey = new object[] { linkRow["EVAL_NO"] };

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
                paramTable.Columns.Add("EVAL_NO", typeof(String)); //
                paramTable.Columns.Add("EVAL_TYPE", typeof(String)); //
                paramTable.Columns.Add("EVAL_TITLE", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EVAL_NO"] = layoutRow["EVAL_NO"];
                paramRow["EVAL_TYPE"] = layoutRow["EVAL_TYPE"];
                paramRow["EVAL_TITLE"] = layoutRow["EVAL_TITLE"];
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT03A_INS", paramSet, "RQSTDT", "RSLTDT",
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


        string _saveMode = "";

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);

                    acAttachFileControl21.LinkKey = row["EVAL_NO"];
                    acAttachFileControl21.ShowKey = new object[] { row["EVAL_NO"] };

                    acAttachFileControl21.UploadFile();
                }

                this.ControlBox = false;
                _saveMode = "SaveClose";
                barItemSaveClose.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();

                //this.Close();
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
                barItemSaveClose.Enabled = true;
                this.ControlBox = true;
            }
            else if (_saveMode == "SaveClose")
            {
                _LinkView.RaiseFocusedRowChanged();
                this.Close();
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

                }
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}
