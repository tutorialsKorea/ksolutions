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

namespace PLN
{
    public sealed partial class PLN01A_D7A : BaseMenuDialog
    {
        DataTable _LotTable;
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

        public acTool.emMethodType ExecuteMethodType { get; set; }


        public PLN01A_D7A(String mcCode, DataTable lotTable)
        {
            InitializeComponent();
            
            _LotTable = lotTable;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_LOT", "공구Lot코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_LIFE", "공구수명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView1.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView1.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView1.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView1.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("TL_MAKER", "제작사", "9HDUX97V", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_UNITCOST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddLookUpEdit("TL_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView1.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpVendor("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            //acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");
            //acGridView1.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C600");
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            //공구형태
            (acLayoutControl1.GetEditor("TL_TYPE").Editor as acLookupEdit).SetCode("T004");
            //대분류
            (acLayoutControl1.GetEditor("TL_LTYPE").Editor as acLookupEdit).SetCode("T001");
            acLayoutControl1.GetEditor("MC_CODE").Value = mcCode;
        }

        public PLN01A_D7A()
        {
            InitializeComponent();
        }

        public override void DialogInit()
        {
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

        protected override void OnShown(EventArgs e)
        {
            //포커스
            acLayoutControl1.GetEditor("TL_LIKE").FocusEdit();


            base.OnShown(e);

            if (this.ExecuteMethodType == acTool.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_TOOL_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acTool.emMethodType.QUICK_FIND)
            {
                this.Search();
            }

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }


        }
        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                acTool ctrl = base.ParentControl as acTool;

                if (this.ExecuteMethodType == acTool.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("TL_LIKE").Value = this.Parameter;

                }


            }

        }


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "TL_LTYPE":

                    if (layout.IsBinding == false)
                    {

                        //공구 중분류

                        (layout.GetEditor("TL_MTYPE").Editor as acLookupEdit).SetCode("T002", newValue);
                    }

                    break;


                case "TL_STYPE":

                    if (layout.IsBinding == false)
                    {
                        //공구 소분류

                        (layout.GetEditor("TL_STYPE").Editor as acLookupEdit).SetCode("T003", newValue);
                    }

                    break;

            }
        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }


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



        void Search()
        {

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("TL_TYPE", typeof(String));
            paramTable.Columns.Add("TL_LTYPE", typeof(String));
            paramTable.Columns.Add("TL_MTYPE", typeof(String));
            paramTable.Columns.Add("MAT_STYPE", typeof(String));
            paramTable.Columns.Add("TL_STYPE", typeof(String));
            paramTable.Columns.Add("TL_LIKE", typeof(String));
            paramTable.Columns.Add("TL_STAT", typeof(String));
            paramTable.Columns.Add("TL_SPEC_LIKE", typeof(String));
            paramTable.Columns.Add("WO_NO_LIKE", typeof(String));
            paramTable.Columns.Add("MC_CODE", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["TL_TYPE"] = layoutRow["TL_TYPE"];
            paramRow["TL_LTYPE"] = layoutRow["TL_LTYPE"];
            paramRow["TL_MTYPE"] = layoutRow["TL_MTYPE"];
            paramRow["TL_STYPE"] = layoutRow["TL_STYPE"];
            paramRow["TL_LIKE"] = layoutRow["TL_LIKE"];
            paramRow["TL_STAT"] = "NP,GU";
            paramRow["TL_SPEC_LIKE"] = layoutRow["TL_SPEC_LIKE"];
            paramRow["WO_NO_LIKE"] = layoutRow["WO_NO_LIKE"];
            paramRow["MC_CODE"] = layoutRow["MC_CODE"];
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "CTRL", "CONTROL_TOOL_LOT_SEARCH", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);

        }
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach(DataRow row in _LotTable.Rows)
                {
                    DataRow findRow = e.result.Tables["RSLTDT"].Select("TL_LOT='" + row["TL_LOT"] + "'").FirstOrDefault();
                    if(findRow != null)
                    {
                        e.result.Tables["RSLTDT"].Rows.Remove(findRow);
                    }
                }

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //검색
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
