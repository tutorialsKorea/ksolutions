using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using BizManager;

namespace LogInForm
{
    public partial class ChangePassword : BaseMenuDialog
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

        public ChangePassword()
        {

            InitializeComponent();

        }


        public override void DialogInit()
        {

            base.DialogInit();

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기

            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("OLD_PASSWORD", typeof(String)); //
                paramTable.Columns.Add("NEW_PASSWORD", typeof(String)); //
                paramTable.Columns.Add("NEW_PASSWORD_CFM", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["OLD_PASSWORD"] = layoutRow["OLD_PASSWORD"];
                paramRow["NEW_PASSWORD"] = layoutRow["NEW_PASSWORD"];
                paramRow["NEW_PASSWORD_CFM"] = layoutRow["NEW_PASSWORD_CFM"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                // BizRun.QBizRun.ExecuteService(this,            QBiz.emExecuteType.LOAD, "CTRL", "CONTROL_VENDOR_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           //QuickSearch,
           //QuickException);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "CTRL", "CHANGE_PASSWORD", paramSet, "RQSTDT", "", paramSet,
                        QuickSaveClose,
                        QuickException);
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
