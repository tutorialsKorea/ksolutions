using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace PLN
{
    public sealed partial class PLN08A_D1A : BaseMenuDialog
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

        private TreeListNode _linkTree = null;

        private acTreeList _linkTreeList = null;

        public PLN08A_D1A(TreeListNode linkTree, acTreeList linkTreeList)
        {
            InitializeComponent();

            _linkTree = linkTree;

            _linkTreeList = linkTreeList;

            //단위
            (acLayoutControl1.GetEditor("MAT_UNIT").Editor as acLookupEdit).SetCode("M003");

            //대분류
            (acLayoutControl1.GetEditor("MAT_LTYPE").Editor as acLookupEdit).SetCode("M001");
            
            //자재형태
            (acLayoutControl1.GetEditor("MAT_TYPE").Editor as acLookupEdit).SetCode("S016");
            
            //창고
            (acLayoutControl1.GetEditor("STOCK_CODE").Editor as acLookupEdit).SetCode("M005");
            
            //완성재고형태
            (acLayoutControl1.GetEditor("STOCK_TYPE").Editor as acLookupEdit).SetCode("M013");
        }

    

        public override void DialogInit()
        {
            base.DialogInit();
        }

        public override void DialogNew()
        {

            base.DialogNew();
        }

        public override void DialogOpen()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BOM_ID", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BOM_ID"] = _linkTree["BOM_ID"];
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "PLN08A_SER4", paramSet, "RQSTDT", "RSLTDT");

            acLayoutControl1.DataBind(resultSet.Tables["RSLTDT"].Rows[0], false);

            base.DialogOpen();
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_ID", typeof(String)); //

                paramTable.Columns.Add("BOM_PART_CODE", typeof(String)); //
                paramTable.Columns.Add("BOM_QTY", typeof(int)); //
                paramTable.Columns.Add("STOCK_CODE", typeof(String)); //
                paramTable.Columns.Add("STOCK_TYPE", typeof(String)); //

                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BOM_ID"] = _linkTree["BOM_ID"];

                paramRow["BOM_PART_CODE"] = _linkTree["BOM_PART_CODE"];
                paramRow["BOM_QTY"] = layoutRow["BOM_QTY"];
                paramRow["STOCK_CODE"] = layoutRow["STOCK_CODE"];
                paramRow["STOCK_TYPE"] = layoutRow["STOCK_TYPE"];

                paramRow["REG_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataTable dtDelPart = new DataTable("RQSTDT_DEL");

                paramSet.Tables.Add(dtDelPart);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN08A_INS", paramSet, "RQSTDT", "RSLTDT",
                            QuickSave,
                            QuickException);
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
                _linkTreeList.DataSource = e.result.Tables["RSLTDT"];

                _linkTreeList.ExpandAll();

                _linkTreeList.BestFitColumns();

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

