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
using BizManager;
using CodeHelperManager;
using System.Linq;

namespace ORD
{
    public sealed partial class ORD02A_D4A : BaseMenuDialog
    {
        public override acBarManager BarManager
        {
            get
            {
                return acBarManager1;
            }
        }

        public enum GridType
        {
            /// <summary>
            /// 거래처
            /// </summary>
            Vendor,

            /// <summary>
            /// 모델(대분류)
            /// </summary>
            Model,

            /// <summary>
            /// 모델(중분류)
            /// </summary>
            DetailModel

        }

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        private GridType _GridType = GridType.Vendor;

        private string _Text = "";

        public ORD02A_D4A(object linkData, GridType gridType, string text)
        {
            InitializeComponent();

            _LinkData = linkData;
            _GridType = gridType;

            _Text = text;
        }


        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            switch (_GridType)
            {
                case GridType.Vendor:

                    acGridView1.AddTextEdit("VEN_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    acGridView1.AddTextEdit("VEN_NAME", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    break;

                case GridType.Model:

                    acGridView1.AddTextEdit("SCODE", "코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                    acGridView1.AddTextEdit("MODEL_CODE", "대분류코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    acGridView1.AddTextEdit("MODEL_NAME", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    break;

                case GridType.DetailModel:

                    acGridView1.AddTextEdit("SCODE", "코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                    acGridView1.AddTextEdit("MODEL_CODE", "중분류코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    acGridView1.AddTextEdit("MODEL_NAME", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                    break;
            }

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;


            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.KeyDown += acGridView1_KeyDown;

            acGridView1.OptionsView.ColumnAutoWidth = true;

            base.DialogInit();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        public override void DialogNew()
        {

            base.DialogNew();
        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();


            switch(_GridType)
            {
                case GridType.Vendor:

                    VendorSearch();

                    break;

                case GridType.Model:

                    ModelSearch();

                    break;

                case GridType.DetailModel:

                    DetailModelSearch();

                    break;
            }
        }

        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                
                }

            }
        }

        private void acGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }
            }
        }


        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //선택

            acGridView1.EndEditor();

            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow;

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void ModelSearch()
        {
            DataRow row = _LinkData as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MODEL_LIKE", typeof(String));
            paramTable.Columns.Add("VEN_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MODEL_LIKE"] = _Text;
            paramRow["VEN_CODE"] = row["CVND_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD_DETAIL,
             "ORD02A_SER3", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        void DetailModelSearch()
        {
            DataRow row = _LinkData as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MODEL_LIKE", typeof(String));
            paramTable.Columns.Add("P_SCODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MODEL_LIKE"] = _Text;
            paramRow["P_SCODE"] = row["MODEL_TYPE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD_DETAIL,
             "ORD02A_SER4", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        void VendorSearch()
        {
            DataRow row = _LinkData as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("VEN_LIKE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_LIKE"] = _Text;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD_DETAIL,
             "ORD02A_SER5", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        

    }
}
