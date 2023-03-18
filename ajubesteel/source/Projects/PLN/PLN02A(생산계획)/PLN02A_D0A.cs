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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace PLN
{
    public sealed partial class PLN02A_D0A : BaseMenuDialog
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

       

        private acTreeList _LinkView = null;
        private acGridView _LinkGridView = null;

        Color _WAIT;
        Color _RUN;
        Color _PAUSE;
        Color _FINISH;

        public PLN02A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;
            
            _LinkGridView = linkView;

            Initialize();

        }
        public PLN02A_D0A(acTreeList linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;

            Initialize();
            
        }

        private void Initialize()
        {
            //공정정보 가져오기

            #region paramTable
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //            
            paramTable.Columns.Add("PT_ID", typeof(String)); //
            paramTable.Columns.Add("RE_WO_NO", typeof(String)); //
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PT_ID"] = ((DataRow)_LinkData)["PT_ID"];
            paramRow["PART_CODE"] = ((DataRow)_LinkData)["PART_CODE"];
            paramRow["RE_WO_NO"] = ((DataRow)_LinkData)["RE_WO_NO"];

            //paramRow["PART_CODE"] = ((TreeListNode)linkData)["PART_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            #endregion

            DataSet dsRsltdt = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN02A_SER_WO", paramSet, "RQSTDT", "RSLTDT_PROC,RSLTDT_MC,RSLTDT_EMP");

            DataTable dtRsltProc = dsRsltdt.Tables["RSLTDT_PROC"];
            DataTable dtRsltGrp = dsRsltdt.Tables["RSLTDT_GRP"];
            //DataTable dtRsltEmp = dsRsltdt.Tables["RSLTDT_EMP"];

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddLookUpEdit("WO_FLAG", "작업상태", "41055", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S032");
            acGridView1.AddLookUpEdit("JOB_PRIORITY", "우선순위", "41914", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "W001");
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_SEQ", "공정순서", "40921", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40303", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "MC_GROUP_NAME", "PROC_MC_GROUP", dtRsltGrp);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40303", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C020");
            //acGridView1.AddLookUpEdit("EMP_CODE", "작업자", "40542", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "EMP_NAME", "MC_EMP_CODE", dtRsltEmp);
            acGridView1.AddTextEdit("PLN_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("ACT_QTY", "완료수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("NG_QTY", "불량수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddDateEdit("PLN_START_TIME", "시작예정", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("PLN_END_TIME", "완료예정", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddCheckEdit("IS_OS", "공정외주", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddTextEdit("SCOMMENT", "지시사항", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CAUTION", "주의사항", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PLN_STD_TIME", "공수", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NUMERIC);
            acGridView1.AddTextEdit("PLN_PROC_TIME", "공수계", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.F2);
            //acGridView1.AddTextEdit("PROC_UC", "공정단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("PROC_COST", "공정비용", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            //acGridView1.AddTextEdit("ACT_START_TIME", "실적시작", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("ACT_END_TIME", "실적완료", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);
            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE2);

            acGridView1.AddLookUpEdit("IDLE_CODE", "중단사유", "UYJGZO3N", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C009");

            acGridView1.AddHidden("WP_NO", typeof(String));
            acGridView1.AddHidden("WO_NO", typeof(String));
            acGridView1.AddHidden("PROC_CODE", typeof(String));
            acGridView1.AddHidden("PART_ID", typeof(String));
            acGridView1.AddHidden("IS_MAT", typeof(Int32));
            acGridView1.AddHidden("WO_TYPE", typeof(string));

            //acGridView1.AddHidden("IS_OS", typeof(String));

            acGridView1.KeyColumn = new string[] { "PROC_CODE" };
            acGridView1.SortInfo.Add(acGridView1.Columns["PROC_SEQ"], DevExpress.Data.ColumnSortOrder.Ascending);

            this.acGridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(acGridView1_CellValueChanging);
            acGridView1.CellValueChanged += acGridView1_CellValueChanged;


            //acGridView1.ShownEditor += new EventHandler(acGridView1_ShownEditor);
            //acGridView1.HiddenEditor += new EventHandler(acGridView1_HiddenEditor);


            //dtRsltProc.Columns.Add("PLN_START_TIME", typeof(String));
            //dtRsltProc.Columns.Add("PLN_END_TIME", typeof(String));
            //dtRsltProc.Columns.Add("ACT_START_TIME", typeof(String));
            //dtRsltProc.Columns.Add("ACT_END_TIME", typeof(String));
            //dtRsltProc.Columns.Add("IDLE_CODE", typeof(String));

            //주의사항
            //dtRsltProc.Columns.Add("SCOMMENT", typeof(String));

            //외주 공정
            //dtRsltProc.Columns.Add("IS_OS", typeof(String));

            acGridView1.GridControl.DataSource = dtRsltProc;
            //acGridView1.BestFitColumns();

            this.acGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.acGridView1_CustomDrawCell);


            //acLayoutControl2.OnValueChanging += acLayoutControl2_OnValueChanging;

            acGridView1.CustomRowCellEdit += acGridView1_CustomRowCellEdit;

        }

        private void acGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            DataView dv = acGridView1.GetDataSourceView();

            acGridView view = sender as acGridView;

            if (view == null) return;
            if (dv.Count == 0) return;
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName == "MC_GROUP")
            {
                string type = acGridView1.GetRowCellValue(e.RowHandle, "WO_TYPE").ToString();

                //가공인경우만 편집가능
                if (type == "PRC")
                {
                    RepositoryItemLookUpEdit lookup = new RepositoryItemLookUpEdit();

                    lookup.SearchMode = SearchMode.AutoSearch;
                    lookup.TextEditStyle = TextEditStyles.Standard;

                    LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
                    LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();

                    displayColumnInfo.FieldName = "CD_NAME";
                    displayColumnInfo.Caption = "CD_NAME";

                    valueColumnInfo.FieldName = "CD_CODE";
                    valueColumnInfo.Caption = "CD_CODE";

                    valueColumnInfo.Visible = false;

                    lookup.NullText = string.Empty;
                    lookup.ShowHeader = false;
                    lookup.ShowFooter = true;

                    lookup.Columns.Add(displayColumnInfo);
                    lookup.Columns.Add(valueColumnInfo);

                    lookup.DataSource = acInfo.StdCodes.GetCatTable("C020");

                    lookup.DisplayMember = "CD_NAME";

                    lookup.ValueMember = "CD_CODE";
                    
                    lookup.ReadOnly = false;
                    e.RepositoryItem = lookup;
                }
                else
                {
                    RepositoryItemTextEdit txt = new RepositoryItemTextEdit();
                    txt.ReadOnly = true;
                    e.RepositoryItem = txt;
                }
            }
        }

        void acLayoutControl2_OnValueChanging(object sender, IBaseEditControl info, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            acLayoutControl layout = sender as acLayoutControl;
            int Sum_Qty = 0;
            switch (info.ColumnName)
            {
                case "P_QTY":

                    Sum_Qty = e.NewValue.toInt() + layout.GetEditor("T_QTY").Value.toInt();

                    if (acLayoutControl1.GetEditor("PLN_QTY").Value.toInt() < Sum_Qty)
                    {
                        layout.GetEditor("P_QTY").Value = 0;
                    }


                    break;

                case "T_QTY":

                    Sum_Qty = e.NewValue.toInt() + layout.GetEditor("P_QTY").Value.toInt();

                    if (acLayoutControl1.GetEditor("PLN_QTY").Value.toInt() < Sum_Qty)
                    {
                        layout.GetEditor("T_QTY").Value = 0;
                    }

                    break;

            }
        }


        void acGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "SEL":
                    
                    if (e.Value.ToString() == "1")
                    {
                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                        //acGridView1.SetRowCellValue(e.RowHandle, acGridView1.Columns["PLN_QTY"], layoutRow["PLN_QTY"]);

                    }
                    break;

                case "PLN_START_TIME":

                    if (e.Value.ToString() != "")
                    {
                        //DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                        //if (layoutRow["IS_SINGLE_PROC"].ToString() != "1")
                        //{
                        //    DataView selected = acGridView1.GetDataSourceView();
                        //    DateTime PlnEndTime = DateTime.Now;
                        //    for (int i = e.RowHandle; i < selected.Count; i++)
                        //    {
                        //        if (selected[i]["SEL"].ToString() == "1")
                        //        {         
                        //            if (i == e.RowHandle)
                        //            {
                        //                selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt() * selected[i]["PLN_QTY"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_END_TIME"].ToString() == "" && selected[i]["PLN_START_TIME"].ToString() != "")
                        //            {
                        //                selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt() * selected[i]["PLN_QTY"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_START_TIME"].ToString() == "")
                        //            {
                        //                selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt() * selected[i]["PLN_QTY"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_START_TIME"].ToString() != "")//&& selected[i]["PLN_START_TIME"].toDateTime() <= PlnEndTime)
                        //            {

                        //                if (selected[i]["PLN_END_TIME"].ToString() == "")
                        //                {
                        //                    selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                    selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt() * selected[i]["PLN_QTY"].toInt());
                        //                }
                        //                else
                        //                {
                        //                    TimeSpan ts = selected[i]["PLN_END_TIME"].toDateTime().Subtract(selected[i]["PLN_START_TIME"].toDateTime());
                        //                    selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                    selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(ts.TotalMinutes);
                        //                }
                        //            }
                        //            //else if (selected[i]["PLN_START_TIME"].ToString() != "" && selected[i]["PLN_START_TIME"].toDateTime() > PlnEndTime)
                        //            //{
                        //            //    if (selected[i]["PLN_END_TIME"].ToString() == "")
                        //            //    {
                        //            //        selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //            //    }
                        //            //    else
                        //            //    {
                        //            //        TimeSpan ts = selected[i]["PLN_END_TIME"].toDateTime().Subtract(selected[i]["PLN_START_TIME"].toDateTime());
                        //            //        selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(ts.TotalMinutes);
                        //            //    }

                        //            //}

                        //            PlnEndTime = selected[i]["PLN_END_TIME"].toDateTime();
                        //        }
                        //    }
                        //}
                    }

                    break;

                case "PLN_END_TIME":

                    if (e.Value.ToString() != "")
                    {
                        //DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                        //DataRow focusRow = acGridView1.GetFocusedDataRow();

                        //if (focusRow["PLN_START_TIME"].toDateTime() > e.Value.toDateTime())
                        //{
                        //    acMessageBox.Show(this, "시작예정보다 빠를 수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        //    focusRow["PLN_END_TIME"] = DBNull.Value;
                        //    return;
                        //}

                        //if (layoutRow["IS_SINGLE_PROC"].ToString() != "1")
                        //{
                        //    DataView selected = acGridView1.GetDataSourceView();
                        //    DateTime PlnEndTime = DateTime.Now;
                        //    for (int i = e.RowHandle; i < selected.Count; i++)
                        //    {
                        //        if (selected[i]["SEL"].ToString() == "1")
                        //        {
                        //            if (i == e.RowHandle)
                        //            {
                        //                //selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_END_TIME"].ToString() == "" && selected[i]["PLN_START_TIME"].ToString() != "")
                        //            {
                        //                selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_START_TIME"].ToString() == "")
                        //            {
                        //                selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //            }
                        //            else if (selected[i]["PLN_START_TIME"].ToString() != "")//&& selected[i]["PLN_START_TIME"].toDateTime() <= PlnEndTime)
                        //            {

                        //                if (selected[i]["PLN_END_TIME"].ToString() == "")
                        //                {
                        //                    selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                    selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //                }
                        //                else
                        //                {
                        //                    TimeSpan ts = selected[i]["PLN_END_TIME"].toDateTime().Subtract(selected[i]["PLN_START_TIME"].toDateTime());
                        //                    selected[i]["PLN_START_TIME"] = PlnEndTime;
                        //                    selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(ts.TotalMinutes);
                        //                }
                        //            }
                        //            //else if (selected[i]["PLN_START_TIME"].ToString() != "" && selected[i]["PLN_START_TIME"].toDateTime() > PlnEndTime)
                        //            //{
                        //            //    if (selected[i]["PLN_END_TIME"].ToString() == "")
                        //            //    {
                        //            //        selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(selected[i]["PLN_PROC_TIME"].toInt());
                        //            //    }
                        //            //    else
                        //            //    {
                        //            //        TimeSpan ts = selected[i]["PLN_END_TIME"].toDateTime().Subtract(selected[i]["PLN_START_TIME"].toDateTime());
                        //            //        selected[i]["PLN_END_TIME"] = selected[i]["PLN_START_TIME"].toDateTime().AddMinutes(ts.TotalMinutes);
                        //            //    }

                        //            //}

                        //            PlnEndTime = selected[i]["PLN_END_TIME"].toDateTime();
                        //        }
                        //    }
                        //}
                        
                    }

                    break;
                
            }
        }


        #region 그리드 상 편집시 코드 상하관계 설정
        private void acGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = acGridView1.GetDataRow(e.RowHandle);

            switch (e.Column.FieldName)
            {
                case "SEL":
                    
                    if (!row["WO_FLAG"].ToString().Equals("0") && !row["WO_FLAG"].ToString().Equals(""))
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "SEL", "1");
                    }
                    else
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "SEL", e.Value);
                    }
                    break;

                case "MC_CODE":
                    acGridView1.SetRowCellValue(e.RowHandle, "EMP_CODE", "");
                    acGridView1.SetRowCellValue(e.RowHandle, "MC_CODE", e.Value);
                    break;
                case "WO_FLAG":
                    //DataRow row = acGridView1.GetDataRow(e.RowHandle);
                    string flag = row["WO_FLAG"].ToString();

                    //이전 상태가 진행인 경우
                    if (flag == "2")
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "WO_FLAG", "2");
                        acMessageBox.Show("진행 중인 공정은 상태를 변경할 수 없습니다.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                    }    

                    //진행으로 상태 변경하는 경우
                    if (e.Value.ToString() == "2")
                    {
                        acGridView1.SetRowCellValue(e.RowHandle, "WO_FLAG", flag);
                        acMessageBox.Show("작업 진행은 단말기에서 [시작]하여야 합니다.", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                    }
                    break;
            }


        }


        private DataView clone = null;

        private void acGridView1_ShownEditor(object sender, EventArgs e)
        {

            GridView view = sender as GridView;
            if ((view.FocusedColumn.FieldName == "MC_GROUP")// || view.FocusedColumn.FieldName == "EMP_CODE")
                && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit)
            {
                string text = view.ActiveEditor.Parent.Name;

                DevExpress.XtraEditors.LookUpEdit edit;

                edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;



                DataTable table = edit.Properties.DataSource as DataTable;

                clone = new DataView(table);

                DataRow row = view.GetDataRow(view.FocusedRowHandle);

                //if (view.FocusedColumn.FieldName == "MC_GROUP")
                {
                    string PROC_CODE = row["PROC_CODE"].ToString();
                    clone.RowFilter = "PROC_CODE = " + "'" + PROC_CODE + "'";
                }
                //else if (view.FocusedColumn.FieldName == "EMP_CODE")
                //{
                //    string[] MC_CODE = row["MC_CODE"].ToString().Split(':');
                //    if (MC_CODE.Length != 2)
                //    { clone.RowFilter = "MC_CODE = " + "'" + "" + "'"; }
                //    else { clone.RowFilter = "MC_CODE = " + "'" + MC_CODE[1] + "'"; }

                //}

                edit.Properties.DataSource = clone;
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
        #endregion

        #region Repositoryitem....
        //void EMP_EditValueChanged(object sender, EventArgs e)
        //{
        //    acEmp editor = sender as acEmp;

        //    if (editor.IsSelected == true)
        //    {
        //        DataRow editorRow = editor.SelectedRow;

        //        DataRow focusRow = acGridView1.GetFocusedDataRow();

        //        focusRow["SPLIT_EMP_CODE"] = editorRow["EMP_CODE"];
        //    }
        //}


        //void EMP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{

        //    acEmp editor = sender as acEmp;

        //    DataRow focusRow = acGridView1.GetFocusedDataRow();

        //    editor.AVAILMC = focusRow["SPLIT_MC_CODE"];


        //}

        //void MC_EditValueChanged(object sender, EventArgs e)
        //{
        //    acMachine editor = sender as acMachine;

        //    if (editor.IsSelected == true)
        //    {
        //        DataRow editorRow = editor.SelectedRow;

        //        DataRow focusRow = acGridView1.GetFocusedDataRow();

        //        focusRow["SPLIT_MC_CODE"] = editorRow["MC_CODE"];
        //    }


        //}

        //void MC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{

        //    DataRow linkRow = this._LinkData as DataRow;

        //    acMachine editor = sender as acMachine;

        //    editor.PROC_CODE = linkRow["PROC_CODE"];


        //}
        #endregion

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            //초기값 설정
            //(acLayoutControl1.GetEditor("MAT_TYPE") as acLookupEdit).SetCode("S016");
            //(acLayoutControl1.GetEditor("PART_PRODTYPE").Editor as acLookupEdit).SetCode("M007");

            //(acLayoutControl2.GetEditor("STOCK_TYPE") as acLookupEdit).SetCode("M013");
            //(acLayoutControl2.GetEditor("STOCK_CODE") as acLookupEdit).SetCode("M005");
            

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로 만들기


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();

        }

        public override void DialogOpen()
        {
            //열기            

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            object pt_id, prod_code, part_code;

            if (_LinkData.GetType() == typeof(DataRow))
            {
                pt_id = ((DataRow)_LinkData)["PT_ID"];
                prod_code = ((DataRow)_LinkData)["PROD_CODE"];
                part_code = ((DataRow)_LinkData)["PART_CODE"];
            }
            else
            {
                pt_id = ((TreeListNode)_LinkData)["PT_ID"];
                prod_code = ((TreeListNode)_LinkData)["PROD_CODE"];
                part_code = ((TreeListNode)_LinkData)["PART_CODE"];
            }
                

            //TreeListNode linkNode = (TreeListNode)_LinkData;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("PT_ID", typeof(String));
            paramTable.Columns.Add("PROD_CODE", typeof(String));
            paramTable.Columns.Add("PART_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow(); 
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PT_ID"] = pt_id;
            paramRow["PROD_CODE"] = prod_code;      //linkNode["PROD_CODE"];
            paramRow["PART_CODE"] = part_code;      // linkNode["PART_CODE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //DataSet paramSet2 = paramSet.Copy();

            DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN02A_SER3", paramSet, "RQSTDT", "RSLTDT");

            DataTable dtIdle = rsltSet.Tables["RSLTDT_IDLE"];


            foreach (DataRow row in dtIdle.Rows)
            {                
                DataView idleView = acGridView1.GetDataView("WO_NO = '" + row["WO_NO"].ToString() + "'");

                if (idleView.Count > 0)
                {
                    idleView[0]["IDLE_CODE"] = row["IDLE_CODE"];
                }
                
            }


            //foreach (DataRow row in rsltSet.Tables["RSLTDT"].Rows)
            //{
            //    row["SEL"] = "1";
            //    DataRow[] drIdles = dtIdle.Select("WO_NO = '" + row["WO_NO"].ToString() + "'");

            //    if (drIdles.Length > 0)
            //    {
            //        row["IDLE_CODE"] = drIdles[drIdles.Length - 1]["IDLE_CODE"];
            //    }

            //    acGridView1.UpdateMapingRow(row, false);
            //}

            acLayoutControl1.DataBind(_LinkData as DataRow, true);

            //foreach(DataRow row in acGridView1.GetDataSourceView("SEL = '0' OR SEL IS NULL").ToTable().Rows)
            //{
            //    acGridView1.DeleteMappingRow(row);
            //}

            //acGridView1.GridControl.DataSource = rsltSet.Tables["RSLTDT"];

            //acGridView1.BestFitColumns();
            //DataSet rsltSet2 = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN02A_SER4", paramSet2, "RQSTDT", "RSLTDT");

            //acLayoutControl1.DataBind(rsltSet2.Tables["RSLTDT"].Rows[0], true);
            //if (rsltSet2.Tables["RSLTDT_D"].Rows.Count != 0)
            //{
            //    acLayoutControl1.DataBind(rsltSet2.Tables["RSLTDT_D"].Rows[0], true);
            //}
            //else
            //{
            //    acLayoutControl1.GetEditor("WORK_QTY").Value = 0;
            //    acLayoutControl1.GetEditor("WORK_T_QTY").Value = 0;
            //}

            //acLayoutControl2.DataBind(rsltSet2.Tables["RSLTDT"].Rows[0], true);
            //acLayoutControl3.DataBind(rsltSet2.Tables["RSLTDT"].Rows[0], true);


            base.DialogOpen();

        }



        void acLayoutControl3_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

        }

        void acLayoutControl3_OnValueChanging(object sender, IBaseEditControl info, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

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
            
            DataRow linkRow = ((DataRow)_LinkData);                
            
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("WP_NO", typeof(String)); //
            paramTable.Columns.Add("PT_ID", typeof(String)); //
            paramTable.Columns.Add("WO_NO", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_ID", typeof(Int32)); //
            paramTable.Columns.Add("PROC_CODE", typeof(String)); //
            paramTable.Columns.Add("PROC_ID", typeof(Int32)); //
            paramTable.Columns.Add("MC_GROUP", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("JOB_PRIORITY", typeof(String)); //
            paramTable.Columns.Add("SCOMMENT", typeof(String)); //지시사항
            paramTable.Columns.Add("CAUTION", typeof(String)); //지시사항
            paramTable.Columns.Add("PART_QTY", typeof(Int32)); //
            paramTable.Columns.Add("ACT_QTY", typeof(Int32)); //
            paramTable.Columns.Add("NG_QTY", typeof(Int32)); //
            paramTable.Columns.Add("PLN_START_DATE", typeof(String)); //            
            paramTable.Columns.Add("PLN_END_DATE", typeof(String)); //           
            paramTable.Columns.Add("PLN_START_TIME", typeof(String)); //            
            paramTable.Columns.Add("PLN_END_TIME", typeof(String)); //          
            paramTable.Columns.Add("PLN_STD_TIME", typeof(Decimal));
            paramTable.Columns.Add("PLN_PROC_TIME", typeof(Decimal));
            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("IS_SAVE", typeof(String)); //
            paramTable.Columns.Add("IS_LAST", typeof(Int32)); //   
            paramTable.Columns.Add("WO_FLAG", typeof(String)); //   
            paramTable.Columns.Add("IS_MAT", typeof(Int32));
            paramTable.Columns.Add("PROC_SEQ", typeof(String));
            paramTable.Columns.Add("IS_OS", typeof(String));
            paramTable.Columns.Add("WO_TYPE", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(byte));

            paramTable.Columns.Add("RE_WO_NO", typeof(String));
            paramTable.Columns.Add("ACT_START_TIME", typeof(DateTime));
            paramTable.Columns.Add("ACT_END_TIME", typeof(DateTime));

            paramTable.Columns.Add("IS_DES_CHANGE", typeof(String));
            paramTable.Columns.Add("IS_REMCT", typeof(String));
            paramTable.Columns.Add("IS_MODIFY", typeof(String));

            DataView selViews = acGridView1.GetDataView();
            int proc_id = 0;
            for (int i = 0; i < selViews.Count; i++)
            {
                DataRow paramRow2 = paramTable.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow2["WP_NO"] = linkRow["WP_NO"];
                paramRow2["PT_ID"] = linkRow["PT_ID"];
                paramRow2["WO_NO"] = selViews[i]["WO_NO"];
                paramRow2["PROD_CODE"] = linkRow["PROD_CODE"];
                paramRow2["PART_CODE"] = linkRow["PART_CODE"];
                paramRow2["PART_ID"] = 0;
                paramRow2["PROC_CODE"] = selViews[i]["PROC_CODE"];
                //paramRow2["PART_QTY"] = layoutRow["PLN_QTY"];
                paramRow2["PART_QTY"] = selViews[i]["PLN_QTY"];
                paramRow2["ACT_QTY"] = selViews[i]["ACT_QTY"];
                paramRow2["NG_QTY"] = selViews[i]["NG_QTY"];

                paramRow2["MC_GROUP"] = GetSplitData(selViews[i]["MC_GROUP"].ToString());
                paramRow2["MC_GROUP"] = selViews[i]["MC_GROUP"].ToString();
                paramRow2["EMP_CODE"] = GetSplitData(selViews[i]["EMP_CODE"].ToString());
                paramRow2["JOB_PRIORITY"] = selViews[i]["JOB_PRIORITY"];
                paramRow2["SCOMMENT"] = selViews[i]["SCOMMENT"];
                paramRow2["CAUTION"] = selViews[i]["CAUTION"];
                paramRow2["PLN_START_DATE"] = selViews[i]["PLN_START_TIME"].toDateString("yyyyMMddHHmm");
                paramRow2["PLN_END_DATE"] = selViews[i]["PLN_END_TIME"].toDateString("yyyyMMddHHmm");
                paramRow2["PLN_START_TIME"] = selViews[i]["PLN_START_TIME"].toDateString("yyyyMMddHHmm");
                paramRow2["PLN_END_TIME"] = selViews[i]["PLN_END_TIME"].toDateString("yyyyMMddHHmm");
                paramRow2["PLN_STD_TIME"] = selViews[i]["PLN_STD_TIME"];
                paramRow2["PLN_PROC_TIME"] = selViews[i]["PLN_PROC_TIME"];
                paramRow2["ACT_START_TIME"] = selViews[i]["ACT_START_TIME"];
                paramRow2["ACT_END_TIME"] = selViews[i]["ACT_END_TIME"];
                paramRow2["REG_EMP"] = acInfo.UserID;
                paramRow2["IS_LAST"] = "0";
                paramRow2["IS_SAVE"] = "1";

                paramRow2["WO_FLAG"] = selViews[i]["WO_FLAG"];
               // paramRow2["IS_MAT"] = selViews[i]["IS_MAT"];

                paramRow2["PROC_SEQ"] = selViews[i]["PROC_SEQ"];
                paramRow2["IS_OS"] = selViews[i]["IS_OS"];

                paramRow2["WO_TYPE"] = selViews[i]["WO_TYPE"];

                if (selViews[i]["SEL"].ToString() == "1")
                {
                    if (selViews[i]["PLN_START_TIME"].ToString() == "" || selViews[i]["PLN_END_TIME"].ToString() == "")
                    {
                        return null;
                    }

                    paramRow2["PROC_ID"] = proc_id++;
                    paramRow2["DATA_FLAG"] = 0;
                }
                else
                {
                    paramRow2["PROC_ID"] = -1;
                    paramRow2["DATA_FLAG"] = 2;
                }

                if (i == (selViews.Count - 1))
                {
                    paramRow2["IS_LAST"] = "1";                    
                }

                paramRow2["RE_WO_NO"] = linkRow["RE_WO_NO"];
                paramRow2["IS_DES_CHANGE"] = linkRow["IS_DES_CHANGE"];
                paramRow2["IS_REMCT"] = linkRow["IS_REMCT"];
                paramRow2["IS_MODIFY"] = linkRow["IS_MODIFY"];

                paramTable.Rows.Add(paramRow2);
            }                       

            DataSet paramSet = new DataSet();            
            paramSet.Tables.Add(paramTable);

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

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataSet paramSet = SaveData();

                if (paramSet != null)
                {

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "PLN02A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
                else
                {
                    acMessageBox.Show(this, "시작/종료예정일이 입력되지 않은 공정이 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                }

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

                //DataSet rsltSet = BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN11A_SER4", paramSet, "RQSTDT", "RSLTDT");

                //foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                //{
                //    row["SEL"] = "1";
                //    acGridView1.UpdateMapingRow(row, true);
                //}

                if (this.ParentControl.Name == "PLN02A_M0A")
                {
                    (this.ParentControl as PLN02A_M0A).DataRefresh(null);
                }

                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
                

                //this.Close();
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

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.SAVE, "PLN02A_SAVE2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
                else
                {
                    acMessageBox.Show(this, "시작/종료예정일이 입력되지 않은 공정이 있습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
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

                if (this.ParentControl.Name == "PLN02A_M0A")
                {
                    (this.ParentControl as PLN02A_M0A).DataRefresh(null);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
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

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PT_ID", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PT_ID"] = (this._LinkData as DataRow)["WP_NO"];
                paramRow["DEL_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                      this, QBiz.emExecuteType.DEL,
                      "PLN02A_DEL", paramSet, "RQSTDT", "",
                      QuickDEL,
                      QuickException);


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

                frm.View.AddDateEdit("MDFY_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                frm.View.AddTextEdit("MDFY_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                //frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);


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

        private void acGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == null
                || e.Column.FieldName != "SEL") return;


            string strWoFlag = acGridView1.GetDataRow(e.RowHandle)["WO_FLAG"].ToString();

            if (e.CellValue.ToString() == "1")
            {
                switch (strWoFlag)
                {
                    case "":
                        e.Appearance.BackColor = Color.YellowGreen;   // Color.YellowGreen;
                        break;
                    case "0":
                        e.Appearance.BackColor = Color.LightGray;   // Color.YellowGreen;
                        break;
                    case "1":
                        e.Appearance.BackColor = _WAIT;//Color.LightGray;
                        break;
                    case "2":
                        e.Appearance.BackColor = _RUN;//Color.SkyBlue;
                        break;
                    case "3":
                        e.Appearance.BackColor = _PAUSE; //Color.Purple;
                        break;
                    case "4":
                        e.Appearance.BackColor = _FINISH;   //Color.Orange;
                        break;

                }
            }

        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정


            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void acPart1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {


            if (this.DialogMode == emDialogMode.NEW)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //            

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = layoutRow["PART_CODE"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN03A_SER3", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearchStdProc,
                            QuickException);
            }
        }

        void QuickSearchStdProc(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    row["SEL"] = "1";

                    acGridView1.UpdateMapingRow(row, false);

                }

                //acGridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        // 해당일자의 주수를 가져오는 방법:
        private string GetJuCha(DateTime Date)
        {

            System.Globalization.CultureInfo myCI = new System.Globalization.CultureInfo("ko-KR");

            return myCI.Calendar.GetWeekOfYear

            (Date, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday).ToString();


        }
    }
}