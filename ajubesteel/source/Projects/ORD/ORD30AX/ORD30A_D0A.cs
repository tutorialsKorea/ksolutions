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

namespace ORD
{
    public sealed partial class ORD30A_D0A : BaseMenuDialog
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


        public ORD30A_D0A(acGridView linkView, object linkData)
        {


            InitializeComponent();


            _LinkData = linkData;
            _LinkView = linkView;


            //작업지시 설정
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.AddLookUpEdit("WO_FLAG", "상태", "40278", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            //acGridView1.AddLookUpEdit("WO_TYPE", "작업지시 형태", "BPIJ8QTW", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S037");
            //acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("JOB_PRIORITY", "우선순위", "41914", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "W001");
            acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PROD_NAME", "금형명", "40901", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("PLN_START_TIME", "계획시작시간", "10613", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("PLN_END_TIME", "계획완료시간", "10614", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            //acGridView1.AddTextEdit("ACT_MAN_TIME", "유인 실적공수", "CLLN0WCV", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);
            //acGridView1.AddTextEdit("ACT_TIME", "총 가공시간", "29TE26WL", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("PART_QTY", "수량", "40345", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            //acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            Search_WK();
        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            acLayoutControl layout = sender as acLayoutControl;

            layout.GetEditor("SHIP_EMP").Value = acInfo.UserID;
            layout.GetEditor("SHIP_DATE").Value = DateTime.Now;

            base.ChildContainerInit(sender);
        }

        private void Search_WK()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("ITEM_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("WO_FLAG_OPT4", typeof(String)); //

            foreach (DataRow dr in (List<DataRow>)_LinkData)
            {
                DataRow paramRow = paramTable.NewRow();

                DataRow row = dr;

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ITEM_CODE"] = row["ITEM_CODE"];
                paramRow["PROD_CODE"] = row["PROD_CODE"];
                paramRow["PART_CODE"] = row["PART_CODE"];
                paramRow["WO_FLAG_OPT4"] = "1";
                paramTable.Rows.Add(paramRow);
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "POP02A_SER10", paramSet, "RQSTDT", "RSLTDT",
            QuickWorkOrderSearch,
            QuickException);

        }

        void QuickWorkOrderSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                //acGridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void DialogInit()
        {
            acLayoutControl1.KeyColumns = new string[] { "ITEM_CODE" };

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

            foreach (DataRow dr in (List<DataRow>)_LinkData)
            {
                DataRow row = dr;

                if (row["REMAIN_QTY"].toInt() > acLayoutControl1.GetEditor("SHIP_QTY").Value.toInt())
                {
                    //acLayoutControl1.GetEditor("SHIP_QTY").Value = row["ACT_QTY"];
                    acLayoutControl1.GetEditor("SHIP_QTY").Value = row["REMAIN_QTY"];
                }
            }

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                string sMSG = "";
                if (acGridView1.DataRowCount > 0)
                {
                    sMSG = " \n미완료 작업지시가 존재합니다.\n[출 하]하시겠습니까? \n\n[작업지시 상태 변경]\n▷미확정/확정→삭제\n▷진행/중지→완료\n  ";
                }
                else
                {
                    sMSG = "[출 하]하시겠습니까?";
                }

                if (acMessageBox.Show(sMSG, this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ITEM_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("SHIP_QTY", typeof(int)); //
                paramTable.Columns.Add("PROD_QTY", typeof(int)); //
                paramTable.Columns.Add("SHIPPED_QTY", typeof(int)); //
                paramTable.Columns.Add("SHIP_DATE", typeof(String)); //
                paramTable.Columns.Add("SHIP_EMP", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                foreach (DataRow dr in (List<DataRow>)_LinkData)
                {
                    DataRow paramRow = paramTable.NewRow();

                    DataRow row = dr;

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["ITEM_CODE"] = row["ITEM_CODE"];
                    paramRow["PROD_CODE"] = row["PROD_CODE"];
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["PROD_QTY"] = row["PROD_QTY"];
                    paramRow["SHIPPED_QTY"] = row["SHIP_QTY"];
                    paramRow["SHIP_QTY"] = layoutRow["SHIP_QTY"];
                    paramRow["SHIP_DATE"] = layoutRow["SHIP_DATE"];
                    paramRow["SHIP_EMP"] = layoutRow["SHIP_EMP"];
                    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["OVERWRITE"] = "0";

                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "ORD30A_INS", paramSet, "RQSTDT", "RSLTDT",
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
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("CAT_CODE").FocusEdit();
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
                //foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                //{
                //    this._LinkView.DeleteMappingRow(row);
                //}

                //DataRow linkRow = (DataRow)this._TRLinkData;
                //if (linkRow["WORK_CNT"].toInt() - e.result.Tables["RQSTDT"].Rows.Count == 0)
                //{
                //    linkRow.Delete();
                //}
                //else
                //{
                //    linkRow["WORK_CNT"] = linkRow["WORK_CNT"].toInt() - e.result.Tables["RQSTDT"].Rows.Count;
                //}
                this.DialogResult = DialogResult.OK;

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