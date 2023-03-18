using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using BizManager;

namespace POP
{
    public partial class POP10A_D0A : BaseMenuDialog
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

        /// <summary>
        /// 작업지시 번호
        /// </summary>
        internal object _WO_NO = null;

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        public POP10A_D0A(acGridView linkView, object linkData)
        {
            
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;
        }

        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



            base.DialogInit();

        }

        public override void DialogInitComplete()
        {



            base.DialogInitComplete();
        }


        public override void DialogNew()
        {
            //새로 만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;





            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기



            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;



            acLayoutControl1.DataBind(linkRow, true);





            base.DialogOpen();

        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {


            if (ex.ErrNumber == 200065)
            {

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);


                frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                frm.View.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.ShowDialog();


            }
            else
            {

                acMessageBox.Show(this, ex);

            }

        }



        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //클리어

            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("TL_CODE").FocusEdit();
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

                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_NUM", typeof(String)); //
                paramTable.Columns.Add("TL_TIME", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_ID"] = null;
                paramRow["WO_NO"] = this._WO_NO;
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["TL_NUM"] = layoutRow["TL_NUM"];
                paramRow["TL_TIME"] = layoutRow["TL_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "POP05A_INS", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_ID", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_NUM", typeof(String)); //
                paramTable.Columns.Add("TL_TIME", typeof(Decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_ID"] = linkRow["TL_ID"];
                paramRow["WO_NO"] = linkRow["WO_NO"];
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["TL_NUM"] = layoutRow["TL_NUM"];
                paramRow["TL_TIME"] = layoutRow["TL_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "POP10A_INS", paramSet, "RQSTDT", "RSLTDT",
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


        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_ID"] = linkRow["TL_ID"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.DEL,
                    "POP05A_DEL", paramSet, "RQSTDT", "",
                    QuickDEL,
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
    }
}
