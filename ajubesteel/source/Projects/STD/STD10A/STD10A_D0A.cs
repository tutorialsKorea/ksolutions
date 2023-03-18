using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;
using CodeHelperManager;

namespace STD
{
    public sealed partial class STD10A_D0A : BaseMenuDialog
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

        private string _Mold_code = string.Empty;



        public STD10A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkView = linkView;

            _LinkData = linkData;

            //acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("MOLD_CODE", "금형코드", "40985", true, DevExpress.Utils.HorzAlignment.Far, true, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40235", true, DevExpress.Utils.HorzAlignment.Near, true, true, true, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("O_PART_CODE", "부품코드", "40235", true, DevExpress.Utils.HorzAlignment.Near, false, false, true, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40236", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PART_NUM", "품번", "40743", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SIZE", "사이즈", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("QLTY", "재질", "40572", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("HARDNESS", "경도", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            //acGridView1.AddTextEdit("PROD_VND", "제작처", "40840", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddHidden("PROD_VND", typeof(string));

            acGridView1.AddCustomEdit("PROD_VND_NAME", "제작처", "40840", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, new RepositoryItemVendor());
            acGridView1.AddDateEdit("BALJU_DATE", "발주일", "40206", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddDateEdit("YPGO_DATE", "입고일", "40515", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["PART_CODE"].ColumnEdit.KeyDown += new KeyEventHandler(partCode_KeyDown);
            acGridView1.Columns["PART_NAME"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            //acGridView1.Columns["PART_NUM"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["SIZE"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["QLTY"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["HARDNESS"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["PART_QTY"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["BALJU_DATE"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["YPGO_DATE"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);
            acGridView1.Columns["SCOMMENT"].ColumnEdit.KeyDown += new KeyEventHandler(ColumnEdit_KeyDown);

            //acGridView1.Columns["PROD_VND_NAME"].ColumnEdit.KeyDown += new KeyEventHandler(colProdVnd_KeyDown);


            (acGridView1.Columns["PROD_VND_NAME"].ColumnEdit as RepositoryItemVendor).ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(venCode_ButtonClick);

            DataRow dtRow = acGridView1.NewRow();
            dtRow["MOLD_CODE"] = "";
            acGridView1.AddRow(dtRow);

        }

        void AddPart()
        {
            //부품 행 추가
            acGridView1.EndEditor();

            DataView current = (DataView)acGridView1.DataSource;

            int rowCnt = current.Table.Rows.Count;

            //if (current.Table.Rows[rowCnt - 1]["PART_CODE"].ToString() != "")
            //{

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow dtRow = acGridView1.NewRow();
                dtRow["MOLD_CODE"] = layoutRow["MOLD_CODE"];
                acGridView1.AddRow(dtRow);

            //}
        }

        void DeletePart()
        {

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            DataTable dt = (DataTable)acGridView1.GridControl.DataSource;

            if (focusRow == null) return;

            ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", false, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));

            

            if (msgResult.DialogResult == DialogResult.Yes)
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MOLD_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MOLD_CODE"] = focusRow["MOLD_CODE"];
                paramRow["PART_CODE"] = focusRow["O_PART_CODE"];


                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL, "STD10A_DEL2", paramSet, "RQSTDT", "",
                    QuickDEL2,
                    QuickException);

                acGridView1.DeleteRow(acGridView1.FocusedRowHandle);
            }
        }

        void venCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                acVendor editor = sender as acVendor;

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                focusRow["PROD_VND"] = editor.Value;


                
                //DataRow dr = edit.SelectedRow;

                //if (dr != null) focusRow["PROD_NAME"] = dr["MODEL"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

      
        void partCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                DataRow focusRow = view.GetFocusedDataRow();

                if (e.KeyCode == Keys.Enter)
                {
                    //부품 행 추가
                    AddPart();
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    //부품 삭제
                    DeletePart();
                }
                else if (focusRow["O_PART_CODE"].ToString() != "")
                {
                    //부품코드는 변경할 수 없습니다.
                    acMessageBox.Show("부품 코드는 변경할 수 없습니다.", "금형 부품리스트", acMessageBox.emMessageBoxType.CONFIRM);
                    focusRow["PART_CODE"] = focusRow["O_PART_CODE"];
                    acGridView1.UpdateCurrentRow();

                    return;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void ColumnEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;

                acGridView view = (edit.Parent as acGridControl).MainView as acGridView;

                if (e.KeyCode == Keys.Enter)
                {
                    acGridView1.EndEditor();

                    DataView current = (DataView)view.DataSource;

                    int rowCnt = current.Table.Rows.Count;

                    if (current.Table.Rows[rowCnt - 1]["PART_CODE"].ToString() != "")
                    {

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        DataRow dtRow = acGridView1.NewRow();
                        dtRow["MOLD_CODE"] = layoutRow["MOLD_CODE"];
                        acGridView1.AddRow(dtRow);

                    }
                }
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        
        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.KeyColumns = new string[] { "MOLD_CODE" };

           
            base.DialogInit();
        }

        public override void DialogInitComplete()
        {

            base.DialogInitComplete();
        }


        public override void DialogNew()
        {
            //새로 만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            //초기값 설정
            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기
            try
            {

                barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                DataRow linkRow = (DataRow)_LinkData;

                _Mold_code = ((DataRow)_LinkData)["MOLD_CODE"].ToString();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MOLD_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = linkRow["PLT_CODE"];
                paramRow["MOLD_CODE"] = linkRow["MOLD_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD10A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

                if (resultSet.Tables["RSLTDT"].Rows.Count == 0)
                {
                    DataRow dtRow = acGridView1.NewRow();

                    dtRow["MOLD_CODE"] = _Mold_code;

                    acGridView1.AddRow(dtRow);
                }

                acLayoutControl1.DataBind(linkRow, true);


                base.DialogOpen();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;

                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false,false, true, false);


                if (frm.ShowDialog() == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
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

        private DataSet SaveData()
        {
            //유효성 확인
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }
            acGridView1.EndEditor();

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("MOLD_CODE", typeof(String)); //
            paramTable.Columns.Add("MODEL", typeof(String)); //
            paramTable.Columns.Add("MOLD_NAME", typeof(String)); //
            paramTable.Columns.Add("MOLD_NUM", typeof(String)); //
            paramTable.Columns.Add("MATERIAL", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("CUST_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_DATE", typeof(String)); //
            paramTable.Columns.Add("PROD_VND", typeof(String)); //
            paramTable.Columns.Add("BALJU_DATE", typeof(String)); //
            paramTable.Columns.Add("BALJU_VND", typeof(String)); //
            paramTable.Columns.Add("SIZE", typeof(String)); //
            paramTable.Columns.Add("WEIGHT", typeof(Decimal)); //
            paramTable.Columns.Add("TYPE", typeof(String)); //
            paramTable.Columns.Add("GATE", typeof(String)); //
            paramTable.Columns.Add("CAVITY", typeof(String)); //
            paramTable.Columns.Add("MOLD_EMP", typeof(String)); //
            paramTable.Columns.Add("ACC_SHOT", typeof(Decimal)); //
            paramTable.Columns.Add("MOLD_NO", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //

            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부
            paramTable.Columns.Add("O_MOLD_CODE", typeof(String)); //



            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MOLD_CODE"] = layoutRow["MOLD_CODE"];
            paramRow["MODEL"] = layoutRow["MODEL"];
            paramRow["MOLD_NAME"] = layoutRow["MOLD_NAME"];
            //paramRow["MOLD_NUM"] = layoutRow["MOLD_NUM"];
            paramRow["MATERIAL"] = layoutRow["MATERIAL"];
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            //paramRow["MC_CODE"] = layoutRow["MC_CODE"];
            paramRow["CUST_DATE"] = dtpProdDate.Text;
            paramRow["PROD_DATE"] = dtpProdDate.Text;
            paramRow["PROD_VND"] = layoutRow["PROD_VND"];
            paramRow["BALJU_DATE"] = dtpBaljuDate.Text;
            paramRow["BALJU_VND"] = layoutRow["BALJU_VND"];
            paramRow["SIZE"] = layoutRow["SIZE"];
            paramRow["WEIGHT"] = layoutRow["WEIGHT"];
            paramRow["TYPE"] = layoutRow["TYPE"];
            paramRow["GATE"] = layoutRow["GATE"];
            paramRow["CAVITY"] = layoutRow["CAVITY"];
            paramRow["MOLD_EMP"] = layoutRow["MOLD_EMP"];
            //paramRow["ACC_SHOT"] = layoutRow["ACC_SHOT"];
            //paramRow["MOLD_NO"] = layoutRow["MOLD_NO"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
            paramRow["REG_EMP"] = acInfo.UserID;
            paramRow["OVERWRITE"] = "1";
            paramRow["O_MOLD_CODE"] = _Mold_code;
            paramTable.Rows.Add(paramRow);

            DataTable paramTablePart = new DataTable("RQSTDT_PART");
            paramTablePart.Columns.Add("PLT_CODE", typeof(String)); //
            paramTablePart.Columns.Add("MOLD_CODE", typeof(String)); //
            paramTablePart.Columns.Add("PART_CODE", typeof(String)); //
            paramTablePart.Columns.Add("PART_NAME", typeof(String)); //
            paramTablePart.Columns.Add("PART_NUM", typeof(String)); //
            paramTablePart.Columns.Add("SIZE", typeof(String)); //
            paramTablePart.Columns.Add("QLTY", typeof(String)); //
            paramTablePart.Columns.Add("HARDNESS", typeof(String)); //
            paramTablePart.Columns.Add("PART_QTY", typeof(Int32)); //
            paramTablePart.Columns.Add("PROD_VND", typeof(String)); //
            paramTablePart.Columns.Add("BALJU_DATE", typeof(String)); //
            paramTablePart.Columns.Add("YPGO_DATE", typeof(String)); //
            paramTablePart.Columns.Add("SCOMMENT", typeof(String)); //
            paramTablePart.Columns.Add("O_PART_CODE", typeof(String)); //

            DataTable part = (DataTable)acGridView1.GridControl.DataSource;

            foreach (DataRow dr in part.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) break;

                if (dr["PART_CODE"].ToString() != "")
                {
                    DataRow partRow = paramTablePart.NewRow();

                    partRow["PLT_CODE"] = acInfo.PLT_CODE;
                    partRow["MOLD_CODE"] = layoutRow["MOLD_CODE"];
                    partRow["PART_CODE"] = dr["PART_CODE"];
                    partRow["PART_NAME"] = dr["PART_NAME"];
                    //partRow["PART_NUM"] = dr["PART_NUM"];
                    partRow["O_PART_CODE"] = dr["O_PART_CODE"];
                    partRow["SIZE"] = dr["SIZE"];
                    partRow["QLTY"] = dr["QLTY"];
                    partRow["HARDNESS"] = dr["HARDNESS"];
                    partRow["PART_QTY"] = dr["PART_QTY"];
                    partRow["PROD_VND"] = dr["PROD_VND"];
                    partRow["BALJU_DATE"] = dr["BALJU_DATE"].toDateString("yyyy-MM-dd");
                    partRow["YPGO_DATE"] = dr["YPGO_DATE"].toDateString("yyyy-MM-dd");
                    partRow["SCOMMENT"] = dr["SCOMMENT"];
                    paramTablePart.Rows.Add(partRow);
                }
            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramTablePart);

            return paramSet;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

                DataSet paramSet = SaveData();

                if (paramSet != null)
                {

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW, "STD10A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
                        QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기

            try
            {

                DataSet paramSet = SaveData();

                if (paramSet != null)
                {

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD10A_INS", paramSet, "RQSTDT", "RSLTDT",
                        QuickSaveClose,
                        QuickException);

                }

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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                //_Mold_code = layoutRow["MOLD_CODE"].ToString();

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

        void QuickDEL2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
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

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MOLD_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MOLD_CODE"] = linkRow["MOLD_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,"STD10A_DEL", paramSet, "RQSTDT", "",
                    QuickDEL,
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


        private void btnAddPart_Click(object sender, EventArgs e)
        {
            AddPart();
        }

        private void btnDelPart_Click(object sender, EventArgs e)
        {
            DeletePart();
        }


    }
}