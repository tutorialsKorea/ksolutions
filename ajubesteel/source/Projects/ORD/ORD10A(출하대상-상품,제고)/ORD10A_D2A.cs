using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using BizManager;

namespace ORD
{
    public sealed partial class ORD10A_D2A : BaseMenuDialog
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


        private object _linkData = null;

        public object LinkData
        {
            set { _linkData = value; }
            get { return _linkData; }
        }

        public ORD10A_D2A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            this._linkView = linkView;

            this._linkData = linkData;

            (acLayoutControl1.GetEditor("PROD_LOCATION") as acLookupEdit).SetCode("M042");
            acLayoutControl1.GetEditor("PROD_LOCATION").Value = "0";
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.GridType = acGridView.emGridType.SEARCH_SEL;

            acGridView1.AddTextEdit("OUT_REQ_ID", "요청번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("OUT_REQ_STAT", "요청 상태", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S043");
            acGridView1.AddLookUpEdit("ORD_SHIP_FLAG", "출하여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M018");
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OUT_REQ_QTY", "출하지시 요청 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("OUT_QTY", "불출 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("O_SHIP_QTY", "기존 출하수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddTextEdit("SHIP_QTY", "출하할 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F1);
            acGridView1.AddDateEdit("OUT_DATE", "불출일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("OUT_EMP", "불출 담당자코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OUT_EMP_NAME", "불출 담당자", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddHidden("OUT_REQ_ID", typeof(string));
            acGridView1.AddHidden("OUT_ID", typeof(string));

            acGridView1.KeyColumn = new string[] { "OUT_REQ_ID" };

            Load += ORD10A_D2A_Load;

        }

        private void ORD10A_D2A_Load(object sender, EventArgs e)
        {
            DataRow linkRow = (DataRow)_linkData;
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = linkRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "ORD10A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            acGridView1.SelectAll();

        }

        public override void DialogInit()
        {

            acDateEdit1.EditValue = acDateEdit.GetNowDateFromServer();

            acEmp1.Value = acInfo.UserID;

            acLayoutControl1.GetEditor("SHIP_QTY").Value = (this._linkData as DataRow)["SHIP_QTY"];

            acLayoutControl1.GetEditor("PO_NO").Value = (this._linkData as DataRow)["PO_NO"];

            base.DialogInit();


        }

        public override void DialogNew()
        {


            base.DialogNew();
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView1.EndEditor();

                if (!acLayoutControl1.ValidCheck())
                    return;

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("PROD_CODE", typeof(String)); //
                paramTable1.Columns.Add("SHIP_QTY", typeof(int)); //
                paramTable1.Columns.Add("SHIP_DATE", typeof(String)); //
                paramTable1.Columns.Add("SHIP_EMP", typeof(String)); //
                paramTable1.Columns.Add("PROD_LOCATION", typeof(String)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("SHIP_PO_NO", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //

                DataRow linkRow = this._linkData as DataRow;

                DataRow paramRow1 = paramTable1.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROD_CODE"] = linkRow["PROD_CODE"];
                paramRow1["SHIP_DATE"] = layoutRow["SHIP_DATE"];
                paramRow1["SHIP_EMP"] = layoutRow["SHIP_EMP"];
                paramRow1["PROD_LOCATION"] = layoutRow["PROD_LOCATION"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow1["SHIP_PO_NO"] = layoutRow["PO_NO"]; 
                paramRow1["REG_EMP"] = acInfo.UserID;

                paramTable1.Rows.Add(paramRow1);


                DataTable dtParam = new DataTable("RQSTDT_STOCK");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("OUT_ID", typeof(String));
                dtParam.Columns.Add("OUT_REQ_ID", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("PART_NAME", typeof(String));
                dtParam.Columns.Add("OUT_DATE", typeof(String));
                dtParam.Columns.Add("OUT_EMP", typeof(String));
                dtParam.Columns.Add("OUT_QTY", typeof(Int32));
                dtParam.Columns.Add("OUT_ORG", typeof(String));
                dtParam.Columns.Add("SCOMMENT", typeof(String));
                dtParam.Columns.Add("OUT_REQ_QTY", typeof(Int32));
                dtParam.Columns.Add("O_SHIP_QTY", typeof(Int32));
                dtParam.Columns.Add("OUT_LOC", typeof(String));
                dtParam.Columns.Add("OUT_REQ_EMP", typeof(String));
                dtParam.Columns.Add("SHIP_QTY", typeof(Int32));
                dtParam.Columns.Add("PROD_CODE", typeof(String));
                dtParam.Columns.Add("REG_EMP", typeof(String));

                DataRow[] selectedRows = acGridView1.GetSelectedDataRows();

                //DataView view = acGridView1.GetDataView();

                //for (int i = 0; i < view.Count; i++)
                //{
                //    DataRow drParam = dtParam.NewRow();

                //    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                //    drParam["PROD_CODE"] = linkRow["PROD_CODE"];
                //    drParam["PART_CODE"] = view[i]["PART_CODE"];
                //    drParam["PART_NAME"] = view[i]["PART_NAME"];
                //    drParam["OUT_DATE"] = layoutRow["SHIP_DATE"];
                //    drParam["OUT_EMP"] = layoutRow["SHIP_EMP"];
                //    drParam["OUT_QTY"] = view[i]["OUT_QTY"];
                //    drParam["SCOMMENT"] = layoutRow["SCOMMENT"];
                //    drParam["OUT_LOC"] = layoutRow["PROD_LOCATION"];
                //    drParam["REG_EMP"] = acInfo.UserID; ;
                //    drParam["OUT_LOC"] = linkRow["PROD_CODE"];
                //    paramRow1["SHIP_QTY"] = paramRow1["SHIP_QTY"].toDecimal() + view[i]["OUT_QTY"].toDecimal();
                //    dtParam.Rows.Add(drParam);

                //}

                foreach (DataRow row in selectedRows)
                {
                    if (row["ORD_SHIP_FLAG"].ToString() == "1") continue;
                    if (row["OUT_REQ_STAT"].ToString() == "50") continue;

                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["PROD_CODE"] = linkRow["PROD_CODE"];
                    drParam["PART_CODE"] = row["PART_CODE"];
                    drParam["PART_NAME"] = row["PART_NAME"];
                    drParam["OUT_DATE"] = layoutRow["SHIP_DATE"];
                    drParam["OUT_EMP"] = layoutRow["SHIP_EMP"];
                    drParam["OUT_QTY"] = row["OUT_QTY"];
                    drParam["SCOMMENT"] = layoutRow["SCOMMENT"];
                    drParam["OUT_LOC"] = layoutRow["PROD_LOCATION"];
                    drParam["REG_EMP"] = acInfo.UserID; ;
                    drParam["OUT_LOC"] = linkRow["PROD_CODE"];
                    paramRow1["SHIP_QTY"] = paramRow1["SHIP_QTY"].toDecimal() + row["SHIP_QTY"].toDecimal();
                    drParam["OUT_REQ_ID"] = row["OUT_REQ_ID"];
                    drParam["OUT_ID"] = row["OUT_ID"];
                    drParam["SHIP_QTY"] = row["SHIP_QTY"];
                    drParam["O_SHIP_QTY"] = row["O_SHIP_QTY"];
                    dtParam.Rows.Add(drParam);
                }


                if (dtParam.Rows.Count == 0)
                {
                    acAlert.Show(this, "선택된 상품이 없습니다.", acAlertForm.enmType.Warning);
                    return;
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(dtParam);

                if (paramSet != null)
                {
                    acBarButtonItem1.Enabled = false;
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "ORD10A_UPD2", paramSet, "RQSTDT,RQSTDT_STOCK", "RSLTDT",
                QuickShip,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void QuickShip(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    if (row["PROD_STATE"].ToString() == "9")
                    {
                        this._linkView.DeleteMappingRow(row);
                    }
                    else
                    {
                        DataRow[] rows = e.result.Tables["RSLTDT"].Select("PROD_CODE = '" + row["PROD_CODE"].ToString() + "'");
                        if(rows.Length == 1) this._linkView.UpdateMapingRow(rows[0], true);
                    }
                }

                //this.acGridView1.ClearSelection();
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}