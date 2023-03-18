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
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PlexityHide.GTP;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace PLN
{
    public sealed partial class PLN01B_D0A : BaseMenuDialog
    {
        /// <summary>
        /// 공정별 할당된 가용설비 리스트
        /// </summary>
        //Dictionary<string,Dictionary<int,string>> _mcCodeListOfProc;
        Dictionary<string, List<string>> _mcCodeListOfProc;

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
        private string _partCode;
        private DataTable _dtProc; 

        public PLN01B_D0A(acGridView linkView, object linkData, string part_code)
        {
            InitializeComponent();

            this._LinkData = linkData;
            this._LinkView = linkView;
            this._partCode = part_code;

            //_mcCodeListOfProc = new Dictionary<string, Dictionary<int, string>>();
            _mcCodeListOfProc = new Dictionary<string, List<string>>();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PART_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = part_code;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsRsltdt = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN01B_SER_STD2", paramSet, "RQSTDT", "RSLTDT_PROC,RSLTDT_MC,RSLTDT_EMP");

            _dtProc = dsRsltdt.Tables["RSLTDT_PROC"];

            foreach (DataRow procRow in _dtProc.Rows)
            {
                List<string> mcList = new List<string>();
                foreach (DataRow mcRow in dsRsltdt.Tables["RSLTDT_AVAIL_MC"]
                                                    .Select("PART_CODE= '" + part_code
                                                        + "' AND PROC_CODE='" + procRow["PROC_CODE"].ToString() + "'"))
                {
                    //mcList.Add(mcRow["MC_SEQ"].toInt(), mcRow["MC_CODE"].ToString());
                    mcList.Add(mcRow["MC_CODE"].ToString());
                }

                if (mcList.Count > 0)
                    _mcCodeListOfProc.Add(procRow["PROC_CODE"].ToString(), mcList);
            }

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.OptionsView.ShowIndicator = true;
            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._INT);
            acGridView1.AddTextEdit("ROW_NUM", "공정순서", "40921", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_SEQ", "공정순서", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddCheckEdit("INS_FLAG", "검사여부", "", false, true, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddCheckEdit("IS_SAMPLING", "샘플링 대상", "", false, true, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddCheckEdit("IS_OS", "외주", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddLookUpEdit("MC_CODE", "설비", "40303", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "MC_NAME", "PROC_MC_CODE", dsRsltdt.Tables["RSLTDT_MC"]);
            acGridView1.AddTextEdit("MC_CNT", "가용설비개수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddButtonEdit("MC_CNT", "가용설비개수", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);
            acGridView1.AddTextEdit("STD_TIME_DAY", "공수[일]", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("STD_TIME", "공수[분]", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NUMERIC);
            //acGridView1.AddLookUpEdit("EMP_CODE", "작업자", "40542", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "EMP_NAME", "MC_EMP_CODE", dtRsltEmp);
            //acGridView1.AddTextEdit("PROC_MAN_TIME", "공수계", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("PROC_TIME", "공수계", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("PROC_UC", "공정 단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F2);
            acGridView1.AddTextEdit("PROC_COST", "공정 비용", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("SCOMMENT", "지시사항", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PUR_SCOMMENT", "구매 비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "PROC_CODE" };

            //if (acGridView1.Columns.ColumnByFieldName("MC_CNT").ColumnEdit is RepositoryItemButtonEdit rib)
            //{
            //    acGridView1.Columns["MC_CNT"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //    rib.ButtonClick += Rib_ButtonClick;
                
            //    //rib.Buttons[0].Image = Resource.edit_x22;
            //    //rib.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            //}

            acGridView1.SortInfo.Add(acGridView1.Columns["SEL"], DevExpress.Data.ColumnSortOrder.Descending);
            acGridView1.SortInfo.Add(acGridView1.Columns["ROW_NUM"], DevExpress.Data.ColumnSortOrder.Ascending);

            this.acGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);
            acGridView1.ShownEditor += new EventHandler(acGridView1_ShownEditor);
            acGridView1.MouseDown += AcGridView1_MouseDown;
            acGridView1.HiddenEditor += new EventHandler(acGridView1_HiddenEditor);
            acGridView1.CustomDrawCell += acGridView1_CustomDrawCell;
            acGridView1.ShowGridMenuEx += AcGridView1_ShowGridMenuEx;

        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로 만들기
            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기            
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            BindData();

            base.DialogOpen();
        }

        void BindData()
        {

            DataRow[] matProcs = _dtProc.Select("IS_MAT = 1");

            if (matProcs.Length > 0)
            {
               
                //발주중량으로 공수계 default 세팅
                DataRow dr = (DataRow)this._LinkData;

                matProcs[0]["PROC_TIME"] = dr["BAL_WEIGHT"];
                matProcs[0]["PROC_UC"] = dr["MAT_UC"];
                matProcs[0]["PROC_COST"] = dr["MAT_COST"];
               
                
            }
            acGridView1.GridControl.DataSource = _dtProc;
            //acGridView1.BestFitColumns();
  
        }

        private DataSet SaveData()
        {
            acGridView1.EndEditor();

            DataView dv = acGridView1.GetDataView();

            if(dv.Table.Select("SEL = '1' AND (PROC_SEQ IS NULL OR STD_TIME IS NULL)").Any())
            {
                acMessageBox.Show(this, "선택한 공정의 우선순위 및 공수를 입력해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);

                return null;
            }
            #region 기존 공정 정보 입력
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_SEQ", typeof(Int32)); //
            paramTable.Columns.Add("IS_SAMPLING", typeof(Byte)); //
            paramTable.Columns.Add("IS_OS", typeof(Byte)); //
            paramTable.Columns.Add("INS_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("STD_TIME", typeof(Decimal)); //
            paramTable.Columns.Add("PROC_TIME", typeof(Decimal)); //
            paramTable.Columns.Add("PROC_UC", typeof(Decimal)); //
            paramTable.Columns.Add("PROC_COST", typeof(Decimal)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("PUR_SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            #endregion

            #region 설비 정보
            DataTable mcParamTable = new DataTable("RQSTDT_MC_SEQ");
            mcParamTable.Columns.Add("PLT_CODE", typeof(String)); //
            mcParamTable.Columns.Add("PART_CODE", typeof(String)); //
            mcParamTable.Columns.Add("PROC_CODE", typeof(String)); //
            mcParamTable.Columns.Add("MC_CODE", typeof(String)); //
            mcParamTable.Columns.Add("MC_SEQ", typeof(Int32)); //
            mcParamTable.Columns.Add("TACT_TIME", typeof(Int32)); //
            mcParamTable.Columns.Add("PROC_TIME", typeof(Int32)); //
            #endregion

            foreach (DataRow dr in dv.Table.Rows)
            {
                if (dr["SEL"].Equals(1))
                {
                    string procCode = dr["PROC_CODE"].ToString(); 
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = _partCode;
                    paramRow["PROC_CODE"] = procCode;
                    paramRow["PROC_SEQ"] = dr["PROC_SEQ"];
                    paramRow["IS_SAMPLING"] = dr["IS_SAMPLING"];
                    paramRow["IS_OS"] = dr["IS_OS"];
                    paramRow["INS_FLAG"] = dr["INS_FLAG"];
                    paramRow["MC_CODE"] = GetSplitData(dr["MC_CODE"].ToString());
                    paramRow["EMP_CODE"] = GetSplitData(dr["EMP_CODE"].ToString());
                    paramRow["STD_TIME"] = dr["STD_TIME"].toInt();
                    paramRow["PROC_TIME"] = dr["PROC_TIME"];
                    paramRow["PROC_UC"] = dr["PROC_UC"];
                    paramRow["PROC_COST"] = dr["PROC_COST"];
                    paramRow["SCOMMENT"] = dr["SCOMMENT"];
                    paramRow["PUR_SCOMMENT"] = dr["PUR_SCOMMENT"];
                    paramRow["REG_EMP"] = acInfo.UserID;
                    
                    paramTable.Rows.Add(paramRow);


                    if(_mcCodeListOfProc.ContainsKey(procCode))
                    {
                        //Dictionary<int, string> mcList = _mcCodeListOfProc[procCode];
                        List<string> mcList = _mcCodeListOfProc[procCode];
                        foreach (string mc in mcList)
                        {
                            DataRow mcParamRow = mcParamTable.NewRow();
                            mcParamRow["PLT_CODE"] = acInfo.PLT_CODE;
                            mcParamRow["PART_CODE"] = _partCode;
                            mcParamRow["PROC_CODE"] = procCode;
                            mcParamRow["MC_CODE"] = mc;
                            //mcParamRow["MC_SEQ"] = seq;
                            mcParamRow["TACT_TIME"] = dr["STD_TIME"];
                            mcParamRow["PROC_TIME"] = dr["STD_TIME"];
                            mcParamTable.Rows.Add(mcParamRow);
                        }
                    }
                }
            }
   
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(mcParamTable);

            return paramSet;

        }

        private string GetSplitData(string value)
        {
            try
            {

                string[] values = value.Split(':');
                return values[values.Length - 1];
            }
            catch
            {
                return value;
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {

                DataSet paramSet = new DataSet();

                paramSet = SaveData();

                if (paramSet != null)
                {

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "PLN01B_SAVE", paramSet, "RQSTDT", "RSLTDT",
                        QuickSaveClose,
                        QuickException);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                ((PLN01B_M0A)this.ParentControl).DataRefresh(null);

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


        #region Grid Events



        void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            DataRow row = (sender as acGridView).GetDataRow(e.RowHandle);
            
            switch (e.Column.FieldName)
            {
                case "MC_CODE":
                    acGridView1.SetRowCellValue(e.RowHandle, "EMP_CODE", "");
                    //acGridView1.SetRowCellValue(e.RowHandle, "MC_CODE", e.Value);
                    break;
                case "PROC_TIME":
                case "PROC_UC":
                    acGridView1.SetRowCellValue(e.RowHandle, "PROC_COST", (row["PROC_TIME"].toDecimal() * row["PROC_UC"].toDecimal()));
                    break;
                case "STD_TIME":
                    row["STD_TIME_DAY"] = e.Value.toDouble() / 1440;
                    break;
                case "STD_TIME_DAY":
                    row["STD_TIME"] = e.Value.toDouble() * 1440;
                    break;
            }


        }

        private DataView clone = null;

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            if ((view.FocusedColumn.FieldName == "MC_CODE" || view.FocusedColumn.FieldName == "EMP_CODE")
                && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {
                string text = view.ActiveEditor.Parent.Name;

                DevExpress.XtraEditors.LookUpEdit edit;

                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;
                
                DataTable table = edit.Properties.DataSource as DataTable;

                clone = new DataView(table);

                DataRow row = view.GetDataRow(view.FocusedRowHandle);

                if (view.FocusedColumn.FieldName == "MC_CODE")
                {
                    string PROC_CODE = row["PROC_CODE"].ToString();
                    clone.RowFilter = "PROC_CODE = " + "'" + PROC_CODE + "'";
                }
                else if (view.FocusedColumn.FieldName == "EMP_CODE")
                {
                    string[] MC_CODE = row["MC_CODE"].ToString().Split(':');
                    if (MC_CODE.Length != 2)
                    { clone.RowFilter = "MC_CODE = " + "'" + "" + "'"; }
                    else { clone.RowFilter = "MC_CODE = " + "'" + MC_CODE[1] + "'"; }

                }

                edit.Properties.DataSource = clone;
            }

        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (!hitInfo.Column.FieldName.Equals("MC_CNT"))
                {
                    return;
                }

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    SettingAvailableMc();
                }
            }
        }

        private void SettingAvailableMc()
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                List<string> dicMcOfProc = null;
                if (focusRow != null)
                {
                    string procCode = focusRow["PROC_CODE"].ToString();
                    if (_mcCodeListOfProc.ContainsKey(procCode))
                    {
                        dicMcOfProc = _mcCodeListOfProc[procCode];
                    }
                }

                //PLN_D0A frm = new PLN_D0A(_partCode,focusRow, dicMcOfProc);
                PLN_D0A frm = new PLN_D0A(_partCode, focusRow, dicMcOfProc);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    //object[2] 전달 받음 
                    //0 : dictionary<int:우선순위, string:설비코드>
                    //1 : string ("IN" : 사내, "OUT" : 외주)

                    object[] receiveData = frm.OutputData as object[];
                    List<string> mcPreset = receiveData[0] as List<string>;
                    if (_mcCodeListOfProc.ContainsKey(focusRow["PROC_CODE"].ToString()))
                    {
                        _mcCodeListOfProc[focusRow["PROC_CODE"].ToString()] = mcPreset;
                    }
                    else
                    {
                        _mcCodeListOfProc.Add(focusRow["PROC_CODE"].ToString(), mcPreset);
                    }

                    if (receiveData[1].ToString().Equals("OUT"))
                    {
                        //외주일때 체크
                        focusRow["IS_OS"] = 1;
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acGridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (clone != null)
            {
                clone.Dispose();
                clone = null;
            }
        }

        void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            switch(e.Column.FieldName)
            {
                case "SEL":
                    {
                        if (e.CellValue == null) return;
                        if (e.CellValue.ToString() == "1")
                            e.Appearance.BackColor = Color.YellowGreen;
                    }
                    break;
                case "MC_CNT":
                    {
                        DataRow row = acGridView1.GetDataRow(e.RowHandle);
                        if(row != null)
                        {
                            string procCode = row["PROC_CODE"].ToString();
                            if(_mcCodeListOfProc.ContainsKey(procCode))
                            {
                                e.DisplayText = _mcCodeListOfProc[procCode].Count.ToString();
                            }
                        }
                    }
                    break;
            }

        }

        #endregion Grid Event

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void Rib_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ButtonEdit be = sender as ButtonEdit;
                ButtonEditViewInfo evi = be.GetViewInfo() as ButtonEditViewInfo;
                EditorButtonObjectInfoArgs bvi = evi.ButtonInfoByButton(e.Button);
                Point pt = new Point(bvi.Bounds.Left, bvi.Bounds.Bottom);
                popupMenu1.ShowPopup(be.PointToScreen(pt));
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                if (e.HitInfo.Column.FieldName.Equals("MC_CNT"))
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                    popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));
                }
            }
        }

        private void btnEditMc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SettingAvailableMc();
        }

        private void btnSameSelMc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView view = acGridView1;
                if (view == null) return;
                
                DataRow focusRow = view.GetFocusedDataRow();
                if (focusRow == null) return;

                if(focusRow["MC_CODE"].isNullOrEmpty())
                {
                    acMessageBox.Show(this, "선택된 설비가 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                List<string> mcPreset = new List<string> { focusRow["MC_CODE"].ToString()};
                if (_mcCodeListOfProc.ContainsKey(focusRow["PROC_CODE"].ToString()))
                {
                    _mcCodeListOfProc[focusRow["PROC_CODE"].ToString()] = mcPreset;
                }
                else
                {
                    _mcCodeListOfProc.Add(focusRow["PROC_CODE"].ToString(), mcPreset);
                }

                RepositoryItemLookUpEdit lookEdit = (view.Columns["MC_CODE"].ColumnEdit as RepositoryItemLookUpEdit);
                DataTable mcTable = lookEdit.DataSource as DataTable;
                DataRow mcRow = mcTable.Select("PROC_MC_CODE = '" + focusRow["MC_CODE"].ToString() + "'").FirstOrDefault();
                
                focusRow["IS_OS"] = mcRow["MC_OS"].toInt();

                view.RefreshData();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}