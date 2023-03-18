using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD16A_D0A : BaseMenuDialog
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

        

        public STD16A_D0A(acGridView linkView, object linkData)
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

            DataRow linkRow = this._LinkData as DataRow;

            if (linkRow["IDLE_START_TIME"].ToString().Length < 5) linkRow["IDLE_START_TIME"] = linkRow["IDLE_START_TIME"].ToString().Substring(0, 2) + ":" + linkRow["IDLE_START_TIME"].ToString().Substring(2, 2);

            if (linkRow["IDLE_END_TIME"].ToString().Length < 5) linkRow["IDLE_END_TIME"] = linkRow["IDLE_END_TIME"].ToString().Substring(0, 2) + ":" + linkRow["IDLE_END_TIME"].ToString().Substring(2, 2);

            acLayoutControl1.DataBind(linkRow, true);

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

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                DataRow linkRow = _LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("IDLE_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["IDLE_ID"] = linkRow["IDLE_ID"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD16A_DEL", paramSet, "RQSTDT", "",
                QuickDEL,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        private DataSet SaveData(string overwrite)
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow linkRow = _LinkData as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("IDLE_ID", typeof(String)); //
            paramTable.Columns.Add("IDLE_NAME", typeof(String)); //
            paramTable.Columns.Add("IDLE_START_TIME", typeof(String)); //
            paramTable.Columns.Add("IDLE_END_TIME", typeof(String)); //
            paramTable.Columns.Add("IDLE_SEQ", typeof(int)); //
            paramTable.Columns.Add("IDLE_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            if (overwrite == "1")
            {
                paramRow["IDLE_ID"] = linkRow["IDLE_ID"];
            }
            paramRow["IDLE_NAME"] = layoutRow["IDLE_NAME"];

            string strStime = "";
            string strEtime = "";

            if (layoutRow["IDLE_START_TIME"].ToString().Length > 0)
            {
                if (layoutRow["IDLE_START_TIME"].ToString().Length == 4)
                {
                    layoutRow["IDLE_START_TIME"] = "0" + layoutRow["IDLE_START_TIME"].ToString();
                }

                strStime = layoutRow["IDLE_START_TIME"].ToString().Substring(0, 2) + layoutRow["IDLE_START_TIME"].ToString().Substring(3, 2);
            }

            if (layoutRow["IDLE_END_TIME"].ToString().Length > 0)
            {
                if (layoutRow["IDLE_END_TIME"].ToString().Length == 4)
                {
                    layoutRow["IDLE_END_TIME"] = "0" + layoutRow["IDLE_END_TIME"].ToString();
                }

                strEtime = layoutRow["IDLE_END_TIME"].ToString().Substring(0, 2) + layoutRow["IDLE_END_TIME"].ToString().Substring(3, 2);
            }

            paramRow["IDLE_START_TIME"] = strStime;
            paramRow["IDLE_END_TIME"] = strEtime;

            paramRow["IDLE_SEQ"] = layoutRow["IDLE_SEQ"];
            paramRow["IDLE_FLAG"] = layoutRow["IDLE_FLAG"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["OVERWRITE"] = overwrite;

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

                DataSet paramSet = SaveData("1");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD16A_INS", paramSet, "RQSTDT", "RSLTDT",
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

                DataSet paramSet = SaveData("0");

                if (paramSet != null)
                {
                    BizRun.QBizRun.ExecuteService(
                            this, QBiz.emExecuteType.NEW,
                            "STD16A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);

                }
                

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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


        void QuickException(object sender, QBiz qBiz, BizException ex)
        {


            if (ex.ErrNumber == BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();


            }
            else if (ex.ErrNumber == BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber),string.Empty,false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }


    }
}