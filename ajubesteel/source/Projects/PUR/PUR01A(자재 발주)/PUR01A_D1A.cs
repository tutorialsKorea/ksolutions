using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using BizManager;

namespace PUR
{
    public sealed partial class PUR01A_D1A : BaseMenuDialog
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
        private DataRow _linkRow = null;

        public PUR01A_D1A(acGridView linkView, DataRow linkRow)
        {
            InitializeComponent();

            _linkView = linkView;
            _linkRow = linkRow;

            acLayoutControl1.GetEditor("SCOMMENT").Value = _linkRow["M_SCOMMENT"];

        }


        public override void DialogInit()
        {
            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BALJU_NUM", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BALJU_NUM"] = _linkRow["BALJU_NUM"];

                paramTable.Rows.Add(paramRow);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "PUR01A_UPD2", paramSet, "RQSTDT", "",
                    QuickUpdate,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickUpdate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, false);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

       
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

    }
}

