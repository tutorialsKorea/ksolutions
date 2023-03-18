using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace MAT
{
    public partial class MAT01A_M0A : BaseMenu
    {
        public MAT01A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.GridType = acGridView.emGridType.SEARCH;
                          
                acGridView1.AddLookUpEdit("LOCATION", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");
                acGridView1.AddTextEdit("PART_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "ItemType");
                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView1.AddTextEdit("CHANGE_VALUE", "환산수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpEdit("MAT_UNIT", "관리 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M022");
                acGridView1.AddTextEdit("MAT_QTY", "재고 수량(관리)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
                acGridView1.AddLookUpEdit("STK_UNIT", "재고 단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M022");
                acGridView1.AddTextEdit("PART_QTY", "재고 수량(재고)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
                //acGridView2.AddTextEdit("STOCK_AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                //acGridView1.AddTextEdit("REQ_QTY", "소요예상수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F1);
                acGridView1.AddTextEdit("STK_ID", "재고ID", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
                         
                         
                          
                acGridView1.KeyColumn = new string[] { "PART_CODE" };

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Search();
        }



        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }



        DataTable _dtSearch;

        void Search()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                _dtSearch = new DataTable("RQSTDT");
                _dtSearch.Columns.Add("PLT_CODE", typeof(String));
                _dtSearch.Columns.Add("PART_LIKE", typeof(String));
                _dtSearch.Columns.Add("PART_SAP_CODE", typeof(String));
                _dtSearch.Columns.Add("SPEC_LIKE", typeof(String));

                DataRow paramRow = _dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["PART_SAP_CODE"] = layoutRow["PART_SAP_CODE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];

                _dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(_dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT01A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
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
                //acGridView2.BestFitColumns();
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


        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {

                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}
