using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;
using BizManager;
using DevExpress.XtraTreeList.Nodes;

namespace POP
{
    public sealed partial class PopBom : BaseMenuDialog
    {
       
       
        public override void BarCodeScanInput(string barcode)
        {


        }

        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        public PopBom(DataRow linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            #region BOM
            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", false);
            acTreeList1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("PART_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("P_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            //acTreeList1.AddTextEdit("P_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);
            acTreeList1.AddTextEdit("DATA_FLAG", "삭제여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "PT_ID";
            acTreeList1.ParentFieldName = "O_PT_ID";

            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            #endregion
        }


        public override void DialogInit()
        {
           // acTreeList1.RowHeight = 45;

           // acTreeList1.ColumnPanelRowHeight = 70;

            base.DialogInit();

        }


        public override void DialogNew()
        {

            //새로만들기
            try
            {
                acTreeList1.ClearNodes();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PROD_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROD_CODE"] = _LinkData["PROD_CODE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_SER13", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearch,
                  QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acTreeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {

            TreeListNode node = e.Node;

            if (node["DATA_FLAG"].ToString() == "2")
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

              acTreeList1.DataSource = e.result.Tables["RSLTDT"];
              acTreeList1.ExpandAll();
              acTreeList1.BestFitColumns();

              base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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