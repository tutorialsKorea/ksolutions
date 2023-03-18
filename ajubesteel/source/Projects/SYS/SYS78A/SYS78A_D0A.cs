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

namespace SYS
{
    public sealed partial class SYS78A_D0A : BaseMenuDialog
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


        public SYS78A_D0A(acGridView linkView, object linkData)
        {


            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;





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

                acTextEdit1.Focus();
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
                paramTable.Columns.Add("TT_GUID", typeof(String)); //
                paramTable.Columns.Add("LANG", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TT_GUID"] = layoutRow["TT_GUID"];
                paramRow["LANG"] = acInfo.Lang;
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];

                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "SYS78A_INS", paramSet, "RQSTDT", "RSLTDT",
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


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);


        }




    }
}