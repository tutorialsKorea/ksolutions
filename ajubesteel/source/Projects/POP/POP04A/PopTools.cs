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

namespace POP
{
    public sealed partial class PopTools : BaseMenuDialog
    {
        

        public override acBarManager BarManager
        {
            get
            {
                return acBarManager1;
            }
        }

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;


        public PopTools(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            
            acGridView1.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddLookUpEdit("TL_TYPE", "공구형태", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            
            acGridView1.AddLookUpEdit("TL_LTYPE", "공구 대분류", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            
            acGridView1.AddLookUpEdit("TL_MTYPE", "공구 중분류", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            
            acGridView1.AddLookUpEdit("TL_STYPE", "공구 소분류", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            
            acGridView1.AddTextEdit("TL_SPEC", "공구사양", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("MNT_POS", "장착 위치", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            
            acGridView1.AddTextEdit("STD_LIFE", "기준 수명", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            
            acGridView1.AddLookUpEdit("TL_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
        

            acGridView1.KeyColumn = new string[] { "TL_CODE" };

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }


        public override void DialogInit()
        {

            //공구형태
            //(acLayoutControl1.GetEditor("TL_TYPE").Editor as acLookupEdit).SetCode("T004");
           
            //공구 대분류
            (acLayoutControl1.GetEditor("TL_LTYPE").Editor as acLookupEdit).SetCode("T001");
            (acLayoutControl1.GetEditor("TL_MTYPE").Editor as acLookupEdit).SetCode("T002");
            (acLayoutControl1.GetEditor("TL_STYPE").Editor as acLookupEdit).SetCode("T003");

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

            this.Search();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }

        }


        //public override void ChildContainerInit(Control sender)
        //{

        //    if (sender == acLayoutControl1)
        //    {
        //        acLayoutControl layout = sender as acLayoutControl;

        //        acTool ctrl = base.ParentControl as acTool;

        //        if (this.ExecuteMethodType == acTool.emMethodType.QUICK_FIND)
        //        {
        //            //코드 검색부분에 입력후 조회
        //            layout.GetEditor("TL_LIKE").Value = this.Parameter;
        //        }

        //    }

        //}


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            //acLayoutControl layout = sender as acLayoutControl;

            //switch (info.ColumnName)
            //{
            //    case "TL_LTYPE":

            //        if (layout.IsBinding == false)
            //        {

            //            //공구 중분류

            //            (layout.GetEditor("TL_MTYPE").Editor as acLookupEdit).SetCode("T002", newValue);
            //        }

            //        break;


            //    case "TL_STYPE":

            //        if (layout.IsBinding == false)
            //        {
            //            //공구 소분류

            //            (layout.GetEditor("TL_STYPE").Editor as acLookupEdit).SetCode("T003", newValue);
            //        }

            //        break;

            //}
        }


        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }

        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("TL_LTYPE", typeof(String)); //
            paramTable.Columns.Add("TL_MTYPE", typeof(String)); //
            paramTable.Columns.Add("TL_STYPE", typeof(String)); //

            paramTable.Columns.Add("TL_LIKE", typeof(String)); //
            paramTable.Columns.Add("TL_SPEC_LIKE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramRow["TL_LTYPE"] = layoutRow["TL_LTYPE"];
            paramRow["TL_MTYPE"] = layoutRow["TL_MTYPE"];
            paramRow["TL_STYPE"] = layoutRow["TL_STYPE"];

            paramRow["TL_LIKE"] = layoutRow["TL_LIKE"];
            paramRow["TL_SPEC_LIKE"] = layoutRow["TL_SPEC_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "POP04A_SER8", paramSet, "RQSTDT", "RSLTDT",
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
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView1.RowCount, e.executeTime);
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
           
            acGridView1.EndEditor();

            try
            {
                //선택한 행이 없다면 리턴
                if (acGridView1.GetDataRow("SEL='1'") == null)
                {
                    acMessageBox.Show(this, "선택한 행이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                //선택한 행 중 수량 입력한 컬럼이 없을때 리턴
                if (acGridView1.GetDataRow("SEL='1' AND MNT_POS > 0") == null)
                {
                    acMessageBox.Show(this, "선택한 행 중 장착위치가 입력되지 않은 행이 존재합니다. ", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                // 공구장착 

                DataView dv =  acGridView1.GetDataSourceView("SEL = '1' AND MNT_POS > 0");

                DataTable dt = dv.ToTable();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MOUNT_ID", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("MNT_POS", typeof(int)); //
                paramTable.Columns.Add("USED_LIFE", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
             
                foreach(DataRow dr in dt.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MOUNT_ID"] = "";
                    paramRow["MC_CODE"] = _LinkData.ToString();
                    paramRow["TL_CODE"] = dr["TL_CODE"];
                    paramRow["MNT_POS"] = dr["MNT_POS"];
                    paramRow["USED_LIFE"] = 0;
                    paramRow["REG_EMP"] = acInfo.UserID;

                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "POP04A_INS5", paramSet, "RQSTDT", "RSLTDT",
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

    }
}
