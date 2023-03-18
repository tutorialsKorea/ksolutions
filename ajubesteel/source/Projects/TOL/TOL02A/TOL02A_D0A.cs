﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;

namespace TOL
{
    public sealed partial class TOL02A_D0A : BaseMenuDialog
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




        public TOL02A_D0A(acGridView linkView, object linkData)
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

            acLayoutControl1.GetEditor("RTN_DATE").Value = DateTime.Now;
            acLayoutControl1.GetEditor("RTN_EMP").Value = acInfo.UserID;
        }


        public override void DialogNew()
        {
            base.DialogNew();
        }

        public override void DialogOpen()
        {
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogOpen();
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
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

                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();
            }
            else
            {
                acMessageBox.Show(this, ex);
                if (this.ParentControl is BaseMenu bm)
                {
                    bm.DataRefresh(null);
                }
            }
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

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                paramTable.Columns.Add("GIVE_NO", typeof(String)); //
                paramTable.Columns.Add("GIVE_SEQ", typeof(String)); //
                paramTable.Columns.Add("GIVE_STATE", typeof(String)); //
                paramTable.Columns.Add("RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("RTN_EMP", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["GIVE_STATE"] = layoutRow["TL_CODE"];
                paramRow["RTN_DATE"] = layoutRow["RTN_DATE"];
                paramRow["RTN_EMP"] = layoutRow["RTN_EMP"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                   "TOL02A_INS", paramSet, "RQSTDT", "RSLTDT",
                   QuickSave,
                   QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        /// <summary>
        /// 저장 후 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                paramTable.Columns.Add("RTN_NO", typeof(String)); //생성정보
                paramTable.Columns.Add("RTN_SEQ", typeof(String)); //생성 정보
                paramTable.Columns.Add("GIVE_NO", typeof(String)); //DB 정보에서 불러옴
                paramTable.Columns.Add("GIVE_SEQ", typeof(String)); //DB 정보에서 불러옴
                paramTable.Columns.Add("TL_LOT", typeof(String)); //DB 정보에서 불러옴

                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("RTN_DATE", typeof(String)); //
                paramTable.Columns.Add("RTN_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("GIVE_STATE", typeof(String)); //
                paramTable.Columns.Add("TL_STAT", typeof(String)); //
                paramTable.Columns.Add("ADD_QTY", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                string giveState = acStdCodes.GetCodeByNameServer("T005", "반납");
                string tlStat = acStdCodes.GetCodeByNameServer("T005", "신품");
                DataView selView = _LinkView.GetDataSourceView("SEL='1'");
                for(int i=0;i<selView.Count;i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TL_CODE"] = selView[i]["TL_CODE"];
                    paramRow["RTN_DATE"] = layoutRow["RTN_DATE"].toDateString("yyyyMMdd");
                    paramRow["RTN_EMP"] = layoutRow["RTN_EMP"];
                    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramRow["GIVE_STATE"] = giveState; //지급 상태 반납으로 변경
                    paramRow["TL_STAT"] = tlStat;   //TTOL_TOOLLIST 지급에서  신품 상태로 변경
                    paramRow["ADD_QTY"] = selView[i]["RTN_QTY"];    //반납이라는 행위는 재고량을 증가 시키는 행위, TTOL_TOOL의 재고량 증가
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                   "TOL02A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    this._LinkView.UpdateMapingRow(row, true);
                //}
                this.DialogResult = DialogResult.OK;
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
                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    if (row["GIVE_QTY"].toInt() > 0)
                //    {
                //        this._LinkView.UpdateMapingRow(row, true);
                //    }
                //    else
                //    {
                //        this._LinkView.DeleteMappingRow(row);
                //    }
                //}
                this.DialogResult = DialogResult.OK;
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
                //if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                //{
                //    return;
                //}

                //DataRow linkRow = this._LinkData as DataRow;


                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("TL_CODE", typeof(String)); //
                //paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                //DataRow paramRow = paramTable.NewRow();
                //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["TL_CODE"] = linkRow["TL_CODE"];
                //paramRow["DEL_EMP"] = acInfo.UserID;
                //paramTable.Rows.Add(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                // "TOL02A_DEL", paramSet, "RQSTDT", "RSLTDT",
                // QuickDEL,
                // QuickException);
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