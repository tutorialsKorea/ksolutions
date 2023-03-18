using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BizManager;
using ControlManager;

namespace LogInForm
{
    public partial class EmpConf : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }



        public override void BarCodeScanInput(string barcode)
        {


        }



        public EmpConf()
        {
            InitializeComponent();
        }


        public override void DialogInit()
        {

            acVerticalGrid1.AddTextEdit("NOTIFY_POPUP_TIME", "알림 메시지 표시시간(초)", "21YG5TW2", true, "알림 메시지가 표시후, 사라지는 시간을 설정합니다.", "8M9DOCPH", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddCheckEdit("NOTIFY_NOTICE", "공지사항, 업무 게시판 알림", "1ATG4RC3", false, "공지사항 및 업무 게시판에 등록되면 알립니다.", "CL4GX6AI", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddCheckEdit("NOTIFY_SELF_M_PUR_EVENT", "자재구매 알림", "8T448W9I", true, "자신이 신청한 항목의 구매상태가 변경되면 알립니다.", "ADUL7XRA", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddCheckEdit("NOTIFY_SELF_PO_PUR_EVENT", "공정외주구매 알림", "PI42HMLL", true, "자신이 신청한 항목의 구매상태가 변경되면 알립니다.", "ADUL7XRA", true, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddCheckEdit("NOTIFY_SELF_SO_PUR_EVENT", "세트외주구매 알림", "PS08K7YD", true, "자신이 신청한 항목의 구매상태가 변경되면 알립니다.", "ADUL7XRA", true, DevExpress.Utils.HorzAlignment.Near, true, false, acVerticalGrid.emCheckEditDataType._STRING);

            //acVerticalGrid1.AddCheckEdit("NOTIFY_SELF_TL_PUR_EVENT", "공구구매 알림", "WY3XMGDW", true, "자신이 신청한 항목의 구매상태가 변경되면 알립니다.", "ADUL7XRA", true, DevExpress.Utils.HorzAlignment.Near, true, false, acVerticalGrid.emCheckEditDataType._STRING);


            acVerticalGrid1.DataBind(acInfo.EmpConfig.GetEmpConfigRowTableByServer().Rows[0]);

            acVerticalGrid1.BestFit();


            base.DialogInit();

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

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            acVerticalGrid1.DataBind(acInfo.EmpConfig.GetEmpConfigRowTableByServer().Rows[0]);

            base.SetLog(QBiz.emExecuteType.REFRESH);
        }
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장


            try
            {
                acVerticalGrid1.EndEditor();


                DataTable data = acVerticalGrid1.CreateParameterTable(true);

                foreach (DataColumn col in data.Columns)
                {


                    acInfo.EmpConfig.SetEmpConfigByServer(col.ColumnName, data.Rows[0][col.ColumnName].toStringEmpty());


                }

                acVerticalGrid1.ClearValueChanged();


                acInfo.EmpConfig.UpdateMemoryEmpConfig();

                base.SetLog(QBiz.emExecuteType.SAVE);


            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }

    }
}
