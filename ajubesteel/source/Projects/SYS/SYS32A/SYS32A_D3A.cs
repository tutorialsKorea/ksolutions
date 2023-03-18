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
    public sealed partial class SYS32A_D3A : BaseMenuDialog
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



        public SYS32A_D3A()
        {


            InitializeComponent();

        }



        public override void DialogInit()
        {

            (acLayoutControl1.GetEditor("TARGET_LANG").Editor as acLookupEdit).SetCode("S004");


            base.DialogInit();


        }

        public override void DialogNew()
        {


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


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORIGINAL_LANG", typeof(String)); //원본 언어
                paramTable.Columns.Add("TARGET_LANG", typeof(String)); //대상 언어

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORIGINAL_LANG"] = acInfo.Lang;
                paramRow["TARGET_LANG"] = layoutRow["TARGET_LANG"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "SYS32A_INS3", paramSet, "RQSTDT", "RSLTDT",
                            QuickSaveClose,
                            QuickException);
                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.PROCESS,
                //"SYS32A_INS3", paramSet, "RQSTDT", "",
                //QuickSaveClose,
                //QuickException);

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