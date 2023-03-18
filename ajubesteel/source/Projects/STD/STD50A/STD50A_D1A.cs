using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DevExpress.Utils.DragDrop;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using BizManager;
using CodeHelperManager;
using ControlManager;
using System.Linq;

using DevExpress.Utils.Behaviors;

namespace STD
{
    public sealed partial class STD50A_D1A : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        private DataRow _masterRow = null;

        private acTreeList _linkTreeList = null;

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private string _parent_id = string.Empty;
        

        private DataTable dtDeleted = null;
        private Color _clrAssy;
        private Color _clrMat;
        private Color _clrRoot;

        public STD50A_D1A(DataRow masterRow, acTreeList linkTreeList, bool EditParent)
        {
            InitializeComponent();

            _masterRow = masterRow;

            _linkTreeList = linkTreeList;
            
            dtDeleted = new DataTable("DEL_RQSTDT");
            dtDeleted.Columns.Add("PLT_CODE", typeof(String));
            dtDeleted.Columns.Add("BM_CODE", typeof(String));
            dtDeleted.Columns.Add("BOM_ID", typeof(String));

            //acLayoutControl1.GetEditor("PART_CODE").Value = _masterRow["PART_CODE"];

            if (EditParent)
            {
                _parent_id = linkTreeList.FocusedNode["BOM_ID"].ToString();                
            }

            #region Set Grid Columns
            //전체 품목 grid
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("MAT_LTYPE", "자재구분", "40132", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M001");
            acGridView1.AddLookUpEdit("MAT_MTYPE", "자재유형", "40630", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M002");
            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

            acGridView1.AddTextEdit("MAT_SPEC1", "절단가능수량", "42545", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAT_SPEC", "규격", "42544", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "42545", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "M007");
            acGridView1.AddLookUpEdit("MAT_TYPE", "구매 분류", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
            acGridView1.AddLookUpEdit("STK_LOCATION", "기본창고", "NO1T1YEG", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M005");
            acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpVendor("MAIN_VND", "외주업체", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView1.AddLookUpVendor("SUPP_VND", "공급사", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false);
            acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S063");

            //acGridView1.AddTextEdit("MAT_COST", "자재단가", "40121", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("PROC_COST", "가공단가", "40121", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_DATE", "최초등록일", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP", "최초등록자", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_DATE", "최근수정일", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근수정자", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddHidden("REV_NO", typeof(string));

            acGridView1.OptionsSelection.MultiSelect = true;

            //bom data

            acTreeList1.KeyFieldName = "BOM_ID";
            acTreeList1.ParentFieldName = "PARENT_ID";

            acTreeList1.AddTextEdit("BM_KEY", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE, true);
            acTreeList1.AddTextEdit("BM_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE, true);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Default, true, true, "M007", false);
            acTreeList1.AddLookUpEdit("MAT_LTYPE", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M001", true);
            acTreeList1.AddLookUpEdit("MAT_MTYPE", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M002", true);
            //acTreeList1.AddTextEdit("REV_NO", "Rev.", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER, true);
            acTreeList1.AddTextEdit("ORI_BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, false, ControlManager.acTreeList.emTextEditMask.F2, true);
            
            acTreeList1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M003", true); 
            //acTreeList1.AddLookUpProc("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
            //acTreeList1.AddLookUpEdit("PART_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "0A16", true);
            acTreeList1.AddTextEdit("BOM_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER, true);            
            //acTreeList1.AddLookUpVendor("MVND_CODE", "공급업체", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
            acTreeList1.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            
            
            acTreeList2.AddTextEdit("BM_KEY", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("BM_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("REV_NO", "Rev.no", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PROD_NAME", "품명", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PART_CODE_OLD", "Part Code", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PART_DESC", "Description", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.F2);
            acTreeList2.AddTextEdit("ORI_BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, false, ControlManager.acTreeList.emTextEditMask.F2);
            acTreeList2.AddLookUpEdit("PROC_GRP", "공정그룹", "", false, DevExpress.Utils.HorzAlignment.Default, true, false, "P100", false);
            acTreeList2.AddLookUpProc("PROC_CODE", "공정", "", false, DevExpress.Utils.HorzAlignment.Default, true, true, false);
            acTreeList2.AddTextEdit("BOM_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER);
            acTreeList2.AddLookUpEdit("PART_CAT1", "분류1", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "0A01", true);
            acTreeList2.AddLookUpEdit("PART_CAT2", "분류2", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "0A02", true);
            acTreeList2.AddLookUpEdit("PART_TYPE", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "0A16", true);
            acTreeList2.AddLookUpEdit("CUR_UNIT", "화폐단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "O001", true);
            acTreeList2.AddLookUpEdit("PART_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, "M003", true);
            acTreeList2.AddTextEdit("UNIT_COST", "단가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, ControlManager.acTreeList.emTextEditMask.F4);
            acTreeList2.AddLookUpVendor("MVND_CODE", "공급업체", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
            acTreeList2.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("CD_VALUE", "CD_VALUE", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            //acTreeList2.Columns["BOM_SEQ"].SortOrder = SortOrder.Ascending;

            acTreeList2.KeyFieldName = "BOM_ID";
            acTreeList2.ParentFieldName = "PARENT_ID";

            #endregion

            _clrAssy = acInfo.SysConfig.GetSysConfigByServer("ASSY_DISP_COLOR").toColor();
            _clrMat = acInfo.SysConfig.GetSysConfigByServer("MAT_DISP_COLOR").toColor();
            _clrRoot = acInfo.SysConfig.GetSysConfigByServer("ROOT_DISP_COLOR").toColor();

            acGridView1.MouseMove += acGridView1_MouseMove;
            acGridView1.MouseDown += acGridView1_MouseDown;
            acGridControl1.DragOver += AcGridControl1_DragOver;
            acGridControl1.DragLeave += AcGridControl1_DragLeave;
            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;
            acGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;

            acTreeList1.OptionsView.ShowIndicator = true;
            acTreeList1.IndicatorWidth = 30;

            acTreeList1.AllowDrop = true;
            acTreeList1.OptionsDragAndDrop.DragNodesMode = DragNodesMode.Multiple;


            acTreeList1.OptionsDragAndDrop.DropNodesMode = DropNodesMode.Advanced;
            acTreeList1.OptionsSelection.MultiSelect = true;
            //acTreeList1.OptionsView.BestFitNodes = TreeListBestFitNodes.Display;

            acTreeList1.DragOver += acTreeList1_DragOver;
            acTreeList1.DragDrop += AcTreeList1_DragDrop;
            acTreeList1.AfterDragNode += AcTreeList1_AfterDragNode;
            acTreeList1.MouseMove += acTreeList1_MouseMove;
            acTreeList1.MouseDown += acTreeList1_MouseDown;
            acTreeList1.GiveFeedback += acTreeList1_GiveFeedback;

            acTreeList1.CellValueChanged += acTreeList1_CellValueChanged;
            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            acTreeList1.KeyDown += AcTreeList1_KeyDown;
            acTreeList1.KeyUp += AcTreeList1_KeyUp;
        
            acLayoutControl2.OnValueKeyDown += acLayoutControl2_OnValueKeyDown;
            acLayoutControl2.OnValueChanged += AcLayoutControl2_OnValueChanged;

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
            //BOM 상태
            (acLayoutControl1.GetEditor("BOM_STATE").Editor as acLookupEdit).SetCode("0A04");
            //내용
            ////분류1
            //(acLayoutControl2.GetEditor("PART_CAT1").Editor as acLookupEdit).SetCode("0A01");
            ////분류2
            //(acLayoutControl2.GetEditor("PART_CAT2").Editor as acLookupEdit).SetCode("0A02");
            
        }


        private void AcGridControl1_DragLeave(object sender, EventArgs e)
        {
            //if (_griddragRowCursor != null)
            //    this.Cursor = _griddragRowCursor;
        }

        private void AcGridControl1_DragOver(object sender, DragEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                {
                    e.Effect = DragDropEffects.Move;

                    this.Cursor = acGraphics.CreateCursor(acGridView1.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);

                }
            }
        }

        private void AcTreeList1_AfterDragNode(object sender, AfterDragNodeEventArgs e)
        {
            try
            {
                SaveNewRecordPosition(e);
            }
            catch { }
        }
        Keys _modifierKey = Keys.None;

        private void AcTreeList1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                acTreeList treeList = sender as acTreeList;

                if (e.KeyCode == Keys.Escape)
                {
                    acTreeListColumn col = treeList.FocusedColumn as acTreeListColumn;

                    if (col.FieldName == "BOM_QTY")
                    {
                        e.Handled = true;
                        //TreeListNode node = treeList.FocusedNode;

                        //object val = node.GetValue("BOM_QTY");

                        //treeList.FocusedNode.SetValue("BOM_QTY", val);

                        //acMessageBox.Show(val.ToString(), "", acMessageBox.emMessageBoxType.CONFIRM);
                    }
                }

                this._holdingshift = e.Shift;

                _modifierKey = e.KeyCode;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        bool _holdingshift = false;

        private void AcTreeList1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this._holdingshift = e.Shift;
            }
            catch { }
        }
        
        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                if (focusRow == null) return;

                //DataTable dtParam = new DataTable("RQSTDT");
                //dtParam.Columns.Add("PLT_CODE", typeof(String));
                //dtParam.Columns.Add("BM_CODE", typeof(String));

                //DataRow drParam = dtParam.NewRow();
                //drParam["PLT_CODE"] = acInfo.PLT_CODE;
                //drParam["BM_CODE"] = focusRow["PART_CODE"];

                //dtParam.Rows.Add(drParam);

                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(dtParam);

                //DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD50A_SER9", paramSet, "RQSTDT", "RSLTDT");

                //DataTable resultTable = resultSet.Tables["RSLTDT"];
                //DataRow[] sortedRows = resultTable.Select("", "BOM_SEQ");
                //acTreeList2.DataSource = sortedRows.CopyToDataTable();

                //acTreeList2.CollapseAll();
            }
            catch { }

        }

        void acTreeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                //e.Node["STATE"] = "MODI";

                if (e.Column.FieldName == "BOM_QTY")
                {
                    
                    if (e.Node.HasChildren)
                    {
                        SetModichildnodeQty(e.Node, e.Node["BOM_QTY"].toInt());
                    }

                    e.Node["UNIT_AMT"] = e.Node["BOM_QTY"].toDecimal() * e.Node["UNIT_COST"].toDecimal();
                    e.Node["STATE"] = "MODI";
                }

                //if (e.Column.FieldName == "PROC_CODE")
                //    e.Node["STATE"] = "MODI";
                //if (e.Column.FieldName == "STATE")
                //e.Node["BOM_SEQ"] = acTreeList1.GetNodeIndex(e.Node);


                //BomSeqIncrease(e.Node["PARENT_ID"].ToString(), e.Node["BOM_ID"].ToString(), e.Node["BOM_ID"].ToString(), e.Node["BOM_SEQ"].toInt());
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SetModichildnodeQty(TreeListNode node, decimal pln_qty)
        {
            try
            {
                for(int i = 0; i < node.Nodes.Count; i++)
                {
                    TreeListNode n = node.Nodes[i];
                
                    //BOM 정보가 이미 저장되어 있는 경우 사용.
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BOM_ID", typeof(String)); //
                    paramTable.Columns.Add("PART_CODE", typeof(String)); //
                    paramTable.Columns.Add("PARENT_PART_CODE", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BOM_ID"] = n["BOM_ID"];
                    paramRow["PART_CODE"] = n["PART_CODE"];
                    paramRow["PARENT_PART_CODE"] = node["PART_CODE"];
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD50A_SER11", paramSet, "RQSTDT", "RSLTDT");
                    DataSet dsResult2 = BizRun.QBizRun.ExecuteService(this, "STD50A_SER12", paramSet, "RQSTDT", "RSLTDT2");

                    //C-80-001255

                    if (dsResult2.Tables["RSLTDT2"].Rows.Count > 0)
                    {
                        n["STATE"] = "MODI";
                        //n["BOM_QTY"] = pln_qty * dsResult2.Tables["RSLTDT2"].Rows[0]["BOM_QTY"].toInt();
                        n["BOM_QTY"] = pln_qty * dsResult2.Tables["RSLTDT2"].Rows[0]["BOM_QTY"].toDecimal();

                        if (n.HasChildren)
                            SetModichildnodeQty(n, n["BOM_QTY"].toInt());
                    }
                    else if (dsResult.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        n["STATE"] = "MODI";
                        n["BOM_QTY"] = pln_qty * dsResult.Tables["RSLTDT"].Rows[0]["BOM_QTY"].toDecimal();

                        if (n.HasChildren)
                            SetModichildnodeQty(n, n["BOM_QTY"].toDecimal());
                    }
                    else
                    {
                        n["STATE"] = "MODI";
                        n["BOM_QTY"] = pln_qty * n["ORI_BOM_QTY"].toDecimal();

                        if (n.HasChildren)
                            SetModichildnodeQty(n, pln_qty);

                    }
                    

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }

        void BomSeqIncrease(string parent_id, string bom_id, string old_bom_id, int bom_seq)
        {
            try
            {
                foreach (DataRow dr in acTreeList1.GetDataView().Table.Select("PARENT_ID = '" + parent_id + "' AND BOM_ID <> '" + parent_id + "'AND BOM_ID <> '" + bom_id + "' AND BOM_ID <> '" + old_bom_id + "'AND BOM_SEQ = " + bom_seq))
                {
                    int i = dr["BOM_SEQ"].isNullOrEmpty() ? 0 : dr["BOM_SEQ"].toInt();
                    dr["BOM_SEQ"] = i + 1;
                    //dr["STATE"] = "MODI";

                    BomSeqIncrease(parent_id, dr["BOM_ID"].ToString(), old_bom_id, dr["BOM_SEQ"].toInt());
                }
            }
            catch { }
        }


        void SetModichildnode(TreeListNode node, string proc_grp)
        {
            try
            {
                foreach (TreeListNode n in node.Nodes)
                {
                    n["STATE"] = "MODI";
                    n["PROC_GRP"] = proc_grp;

                    if (node.HasChildren)
                        SetModichildnode(n, proc_grp);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);

            }
        }
        private void AcLayoutControl2_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MAT_LTYPE":

                    acLookupEdit3.SetCode("M002", newValue);
                    break;
            }
        }
        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "PART_CODE":
                    layout.GetEditor("BM_CODE").Value = newValue;
                    break;
            }
        }

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchStdPart();

            
        }

        public override void DialogInit()
        {
            barItemRev.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl2.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M014");
            //SearchStdPart();

            //SearchBom();

            //완제품만 조회
            //acPart1._bProduct = true;

            base.DialogInit();
        }

        bool _dialogNew = false;

        public override void DialogNew()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //새로만들기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _masterRow["SCOMMENT"] = DBNull.Value;

            acLayoutControl1.DataBind(_masterRow, false);
            acLayoutControl1.GetEditor("REV_NO").Value = 0;

            SearchBom();
            _dialogNew = true;
        }

        public override void DialogOpen()
        {
            barItemRev.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind(_masterRow, false);
            setLock();
            SearchBom();
        }
        private string setLock()
        {

            acTreeList1.Enabled = true;
            acLayoutControl1.Enabled = true;
            acLayoutControl2.Enabled = true;
            barItemSave.Enabled = true;
            barItemSaveClose.Enabled = true;
            barItemRev.Enabled = true;
            barItemRev.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            string ret = "NOLOCK";
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BM_KEY", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BM_KEY"] = _masterRow["BM_KEY"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD50A_SER6", paramSet, "RQSTDT", "RSLTDT");

            if(dsResult.Tables["RSLTDT"].Rows.Count > 0)
            {
                _masterRow["LOCK_EMP"] = dsResult.Tables["RSLTDT"].Rows[0]["LOCK_EMP"];
                acEmp1.Value = dsResult.Tables["RSLTDT"].Rows[0]["LOCK_EMP"];
            }


            if (_masterRow["LOCK_EMP"].isNullOrEmpty())
            {
                acBarButtonItem1.Caption = "잠금";
                barItemSaveClose.Enabled = false;
                barItemSave.Enabled = false;
                barItemRev.Enabled = false;
                acTreeList1.Enabled = false;
                acLayoutControl1.Enabled = false;
                acLayoutControl2.Enabled = false;
            }
            else
            {
                acBarButtonItem1.Caption = "잠금 해제";
                if (_masterRow["LOCK_EMP"].ToString() == acInfo.UserID)
                {
                    acBarButtonItem1.Enabled = true;
                    ret = "LOCKUSER";
                }
                else
                {
                    acMessageBox.Show("현재 잠금 상태입니다.\n잠금 사용자를 확인하세요", "잠금", acMessageBox.emMessageBoxType.CONFIRM);
                    acTreeList1.Enabled = false;
                    barItemSaveClose.Enabled = false;
                    barItemSave.Enabled = false;
                    barItemRev.Enabled = false;
                    acLayoutControl1.Enabled = false;
                    acLayoutControl2.Enabled = false;
                    acBarButtonItem1.Enabled = false;
                    ret = "LOCK";
                }
            }

            return ret;

        }
        private void SearchStdPart()
        {
            try
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_LIKE", typeof(String)); //
                paramTable.Columns.Add("MAT_LTYPE", typeof(String)); //
                paramTable.Columns.Add("MAT_MTYPE", typeof(String)); //
                
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["MAT_LTYPE"] = layoutRow["MAT_LTYPE"];
                paramRow["MAT_MTYPE"] = layoutRow["MAT_MTYPE"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "STD02A_SER1", paramSet, "RQSTDT", "RSLTDT");
                
                acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void SearchBom()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BM_KEY", typeof(String)); //
                paramTable.Columns.Add("BM_CODE", typeof(String)); //
                paramTable.Columns.Add("PARENT_ID", typeof(String)); //
                

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = layoutRow["BM_KEY"];
                paramRow["BM_CODE"] = layoutRow["BM_CODE"];

                if (_parent_id != "")
                { 
                    paramRow["PARENT_ID"] = _parent_id;
                    
                }

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet dsResult ;

                if (_parent_id == "")
                    dsResult = BizRun.QBizRun.ExecuteService(this, "STD50A_SER2", paramSet, "RQSTDT", "RSLTDT");
                else
                    dsResult = BizRun.QBizRun.ExecuteService(this, "STD50A_SER4", paramSet, "RQSTDT", "RSLTDT");

                acTreeList1.DataSource = dsResult.Tables["RSLTDT"];

                //UpdateNodesPositions(acTreeList1.Nodes);

                //acTreeList1.ExpandToLevel(0);
                acTreeList1.ExpandAll();
                //acTreeList1.BestFitColumns();

                //acGridView2.GridControl.DataSource  = dsResult.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void UpdateNodesPositions(TreeListNodes nodes)
        {
            var ns = new List<TreeListNode>();
            foreach (TreeListNode n in nodes)
            {
                ns.Add(n);
            }
            foreach (TreeListNode n in ns)
            {
                UpdateNodesPositions(n.Nodes);
                n.TreeList.SetNodeIndex(n, Convert.ToInt32(n.GetValue("BOM_SEQ")));
            }
        }

        private void SaveNewRecordPosition(NodeEventArgs e)
        {

            var nodes = e.Node.ParentNode == null
                        ? e.Node.TreeList.Nodes
                        : e.Node.ParentNode.Nodes;

            for (var i = 0; i < nodes.Count; i++)
            {
                nodes[i].SetValue("BOM_SEQ", i);
                nodes[i].SetValue("STATE", "MODI");

            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {
                if (!acLayoutControl1.ValidCheck())
                {
                    return;
                }

                acTreeList1.EndEditor();

                string _setLock = setLock();
                string _lockEmp = "";
                if (_setLock == "LOCK")
                {
                    acMessageBox.Show("잠금 상태이므로 저장할 수 없습니다.", "잠금", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                else if (_setLock == "LOCKUSER")
                {
                    if (acMessageBox.Show("저장 후 잠금 해제하시겠습니까.", "잠금", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        _lockEmp = acInfo.UserID;
                    }
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT_M");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BM_KEY", typeof(String));
                paramTable.Columns.Add("BM_CODE", typeof(String));
                paramTable.Columns.Add("BOM_STATE", typeof(String));
                paramTable.Columns.Add("LOCK_EMP", typeof(String));
                paramTable.Columns.Add("SCOMMENT", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("REV_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = layoutRow["BM_KEY"];
                paramRow["BM_CODE"] = layoutRow["BM_CODE"];
                paramRow["BOM_STATE"] = layoutRow["BOM_STATE"];
                paramRow["LOCK_EMP"] = _lockEmp;
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["PART_CODE"] = layoutRow["BM_CODE"];
                paramRow["REV_NO"] = layoutRow["REV_NO"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = SaveData();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD50A_INS2", paramSet, "RQSTDT", "RSLTDT", QuickSaveClose, QuickException);
                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            if (ex.ErrNumber == BizActorException.ABORT)
            {
                acMessageBox.Show(ex.Message, "경 고", acMessageBox.emMessageBoxType.CONFIRM);
            }
            else
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private DataSet SaveData()
        {
            try
            {
                acTreeList1.EndEditor();

                DataTable paramTable2 = new DataTable("RQSTDT_ALL");
                paramTable2.Columns.Add("PLT_CODE", typeof(String));
                paramTable2.Columns.Add("BM_KEY", typeof(String));
                paramTable2.Columns.Add("BOM_ID", typeof(String));
                paramTable2.Columns.Add("PARENT_ID", typeof(String));
                paramTable2.Columns.Add("BM_CODE", typeof(String));
                paramTable2.Columns.Add("PART_CODE", typeof(String));
                //paramTable2.Columns.Add("PROC_GRP", typeof(String));
                //paramTable2.Columns.Add("PROC_CODE", typeof(String));
                paramTable2.Columns.Add("BOM_QTY", typeof(Decimal));
                paramTable2.Columns.Add("BOM_SEQ", typeof(Decimal));
                paramTable2.Columns.Add("ID", typeof(String));
                paramTable2.Columns.Add("P_ID", typeof(String));
                //paramTable2.Columns.Add("REV_NO", typeof(String));

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BM_KEY", typeof(String));
                paramTable.Columns.Add("BOM_ID", typeof(String));
                paramTable.Columns.Add("PARENT_ID", typeof(String));
                paramTable.Columns.Add("BM_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                //paramTable.Columns.Add("PROC_GRP", typeof(String));
                //paramTable.Columns.Add("PROC_CODE", typeof(String));
                paramTable.Columns.Add("BOM_QTY", typeof(Decimal));
                paramTable.Columns.Add("BOM_SEQ", typeof(Decimal));
                paramTable.Columns.Add("ID", typeof(String));
                paramTable.Columns.Add("P_ID", typeof(String));
                //paramTable.Columns.Add("BAN_REV", typeof(String));

                DataTable dtSource = acTreeList1.DataSource as DataTable;
                DataRow[] selected = dtSource.Select("STATE = 'MODI' OR STATE = 'ADD'");
                                
                foreach (DataRow dr in selected)
                {                    
                    if (dr["STATE"].ToString() == "MODI" || dr["STATE"].ToString() == "ADD")
                    {
                        DataRow newrow = paramTable.NewRow();
                        newrow["PLT_CODE"] = acInfo.PLT_CODE;
                        newrow["BM_KEY"] = dr["BM_KEY"];
                        newrow["BOM_ID"] = dr["BOM_ID"];
                        newrow["PARENT_ID"] = dr["PARENT_ID"];
                        newrow["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                        newrow["PART_CODE"] = dr["PART_CODE"];
                        //newrow["PROC_GRP"] = dr["PROC_GRP"];
                        //newrow["PROC_CODE"] = dr["PROC_CODE"];
                        newrow["BOM_QTY"] = dr["BOM_QTY"];
                        newrow["BOM_SEQ"] = dr["BOM_SEQ"];
                        newrow["ID"] = dr["BOM_ID"];
                        newrow["P_ID"] = dr["PARENT_ID"];
                        //newrow["BAN_REV"] = dr["REV_NO"];

                        paramTable.Rows.Add(newrow);
                    }

                }

                DataRow[] selected2 = dtSource.Select("");

                foreach (DataRow dr in selected2)
                {
                    DataRow newrow = paramTable2.NewRow();
                    newrow["PLT_CODE"] = acInfo.PLT_CODE;
                    newrow["BM_KEY"] = dr["BM_KEY"];
                    newrow["BOM_ID"] = dr["BOM_ID"];
                    newrow["PARENT_ID"] = dr["PARENT_ID"];
                    newrow["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                    newrow["PART_CODE"] = dr["PART_CODE"];
                    //newrow["PROC_GRP"] = dr["PROC_GRP"];
                    //newrow["PROC_CODE"] = dr["PROC_CODE"];
                    newrow["BOM_QTY"] = dr["BOM_QTY"];
                    newrow["BOM_SEQ"] = dr["BOM_SEQ"];
                    newrow["ID"] = dr["BOM_ID"];
                    newrow["P_ID"] = dr["PARENT_ID"];
                    //newrow["REV_NO"] = dr["REV_NO"];

                    paramTable2.Rows.Add(newrow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                paramSet.Tables.Add(dtDeleted.Copy());
                paramSet.Tables[2].TableName = "DEL_RQSTDT";

                return paramSet;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return null;
            }
        }

        private DataSet SaveDataALL()
        {
            try
            {
                acTreeList1.EndEditor();

                DataTable paramTable2 = new DataTable("RQSTDT_ALL");
                paramTable2.Columns.Add("PLT_CODE", typeof(String));
                paramTable2.Columns.Add("BM_KEY", typeof(String));
                paramTable2.Columns.Add("BOM_ID", typeof(String));
                paramTable2.Columns.Add("PARENT_ID", typeof(String));
                paramTable2.Columns.Add("BM_CODE", typeof(String));
                paramTable2.Columns.Add("PART_CODE", typeof(String));
                paramTable2.Columns.Add("PROC_GRP", typeof(String));
                paramTable2.Columns.Add("PROC_CODE", typeof(String));
                paramTable2.Columns.Add("BOM_QTY", typeof(Decimal));
                paramTable2.Columns.Add("BOM_SEQ", typeof(Decimal));
                paramTable2.Columns.Add("ID", typeof(String));
                paramTable2.Columns.Add("P_ID", typeof(String));

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BM_KEY", typeof(String));
                paramTable.Columns.Add("BOM_ID", typeof(String));
                paramTable.Columns.Add("PARENT_ID", typeof(String));
                paramTable.Columns.Add("BM_CODE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("PROC_GRP", typeof(String));
                paramTable.Columns.Add("BOM_QTY", typeof(Decimal));
                paramTable.Columns.Add("ID", typeof(String));
                paramTable.Columns.Add("P_ID", typeof(String));


                DataTable dtSource = acTreeList1.DataSource as DataTable;
                DataRow[] selected = dtSource.Select();

                foreach (DataRow dr in selected)
                {
                    DataRow newrow = paramTable.NewRow();
                    newrow["PLT_CODE"] = acInfo.PLT_CODE;
                    newrow["BM_KEY"] = dr["BM_KEY"];
                    newrow["BOM_ID"] = dr["BOM_ID"];
                    newrow["PARENT_ID"] = dr["PARENT_ID"];
                    newrow["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                    newrow["PART_CODE"] = dr["PART_CODE"];
                    newrow["PROC_GRP"] = dr["PROC_GRP"];
                    newrow["BOM_QTY"] = dr["BOM_QTY"];
                    newrow["ID"] = dr["BOM_ID"];
                    newrow["P_ID"] = dr["PARENT_ID"];

                    paramTable.Rows.Add(newrow);
                }

                DataRow[] selected2 = dtSource.Select("");

                foreach (DataRow dr in selected2)
                {
                    DataRow newrow = paramTable2.NewRow();
                    newrow["PLT_CODE"] = acInfo.PLT_CODE;
                    newrow["BM_KEY"] = dr["BM_KEY"];
                    newrow["BOM_ID"] = dr["BOM_ID"];
                    newrow["PARENT_ID"] = dr["PARENT_ID"];
                    newrow["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                    newrow["PART_CODE"] = dr["PART_CODE"];
                    newrow["PROC_GRP"] = dr["PROC_GRP"];
                    newrow["PROC_CODE"] = dr["PROC_CODE"];
                    newrow["BOM_QTY"] = dr["BOM_QTY"];
                    newrow["BOM_SEQ"] = dr["BOM_SEQ"];
                    newrow["ID"] = dr["BOM_ID"];
                    newrow["P_ID"] = dr["PARENT_ID"];

                    paramTable2.Rows.Add(newrow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(paramTable2);

                //paramSet.Tables.Add(dtDeleted.Copy());
                //paramSet.Tables[1].TableName = "DEL_RQSTDT";

                return paramSet;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
                return null;
            }
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!acLayoutControl1.ValidCheck()) return;
                
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT_M");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("BM_KEY", typeof(String));
                paramTable.Columns.Add("BM_CODE", typeof(String));
                paramTable.Columns.Add("BOM_STATE", typeof(String));
                paramTable.Columns.Add("LOCK_EMP", typeof(String));
                paramTable.Columns.Add("SCOMMENT", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("REV_NO", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = layoutRow["BM_KEY"];
                paramRow["BM_CODE"] = layoutRow["BM_CODE"];
                paramRow["BOM_STATE"] = layoutRow["BOM_STATE"];
                paramRow["LOCK_EMP"] = acInfo.UserID;
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["PART_CODE"] = layoutRow["BM_CODE"];
                paramRow["REV_NO"] = layoutRow["REV_NO"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = SaveData();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW, "STD50A_INS2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);

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
                //DataTable dt = acTreeList1.DataSource as DataTable;
            


                ////_linkTreeList.DataSource = acTreeList1.DataSource;

                //_linkTreeList.ExpandToLevel(0);

                //_linkTreeList.BestFitColumns();

                //this.DialogResult = DialogResult.OK;

                if (_dialogNew)
                {
                    //잠금 설정
                    DataTable result = e.result.Tables["RQSTDT_M"];

                    if (result.Rows.Count > 0)
                    {
                        DataRow resultrow = result.Rows[0];
                        DataTable paramTableL = new DataTable("RQSTDT");
                        paramTableL.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableL.Columns.Add("BM_KEY", typeof(String)); //
                        paramTableL.Columns.Add("LOCK_EMP", typeof(String)); //

                        DataRow paramRowL = paramTableL.NewRow();
                        paramRowL["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRowL["BM_KEY"] = resultrow["BM_KEY"];
                        paramRowL["LOCK_EMP"] = acInfo.UserID;

                        paramTableL.Rows.Add(paramRowL);

                        DataSet paramSetL = new DataSet();
                        paramSetL.Tables.Add(paramTableL);

                        BizRun.QBizRun.ExecuteService(this, "STD50A_UPD", paramSetL, "RQSTDT", "RSLTDT");


                    }

                    DataTable rslt_M = e.result.Tables["RQSTDT_M"];

                    _masterRow = rslt_M.Rows[0];
                    
                    acLayoutControl1.DataBind(_masterRow, false);
                    
                    setLock();

                    _dialogNew = false;
                }

                SearchBom();

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
                //_linkTreeList.DataSource = e.result.Tables["RSLTDT"];

                //_linkTreeList.ExpandToLevel(0);

                //_linkTreeList.BestFitColumns();

                //this.Close();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        #region Events
       

        private void InsertNode(TreeList list, TreeListNode pNode, DataRow dr, string parent, int iBomSeq)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow drNew = (acTreeList1.DataSource as DataTable).NewRow();

                drNew["BOM_ID"] = "";
                drNew["BM_KEY"] = layoutRow["BM_KEY"];
                drNew["BM_CODE"] = layoutRow["BM_CODE"];
                drNew["PARENT_ID"] = parent;
                drNew["PART_CODE"] = dr["PART_CODE"];
                drNew["PART_NAME"] = dr["PART_NAME"];
                drNew["PART_PRODTYPE"] = dr["PART_PRODTYPE"];
                drNew["MAT_LTYPE"] = dr["MAT_LTYPE"];
                drNew["MAT_MTYPE"] = dr["MAT_MTYPE"];
                drNew["MAT_UNIT"] = dr["MAT_UNIT"];
                //drNew["REV_NO"] = dr["REV_NO"];
                drNew["DRAW_NO"] = dr["DRAW_NO"];
                //drNew["UNIT_COST"] = dr["UNIT_COST"];
                //drNew["MVND_CODE"] = dr["MVND_CODE"];
                
                drNew["BOM_QTY"] = 1;
                drNew["ORI_BOM_QTY"] = 1;
                //drNew["PROC_GRP"] = DBNull.Value;
                //drNew["PROC_CODE"] = dr["PART_PROC"];
                drNew["STATE"] = "ADD";
                drNew["BOM_SEQ"] = iBomSeq;
                //drNew["CD_VALUE"] = dr["CD_VALUE"];

                TreeListNode AddedNode;

                if (pNode == null)
                {
                    AddedNode = list.Nodes.Add(drNew);
                    //list.ExpandToLevel(0);
                }
                else
                {
                    AddedNode = pNode.Nodes.Add(drNew);
                    AddedNode.ParentNode.Expanded = true;

                }

                AddedNode["BOM_ID"] = AddedNode.Id;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void InsertNode(TreeList list, TreeListNode pNode, TreeListNode node, string parent, int iBomSeq)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow drNew = (acTreeList1.DataSource as DataTable).NewRow();

                drNew["BOM_ID"] = "";
                drNew["BM_KEY"] = layoutRow["BM_KEY"];
                drNew["BM_CODE"] = layoutRow["BM_CODE"];
                drNew["PARENT_ID"] = parent;
                drNew["PART_CODE"] = node["PART_CODE"];
                drNew["PART_NAME"] = node["PART_NAME"];
                drNew["PART_PRODTYPE"] = node["PART_PRODTYPE"];
                drNew["MAT_LTYPE"] = node["MAT_LTYPE"];
                drNew["MAT_MTYPE"] = node["MAT_MTYPE"];
                drNew["REV_NO"] = node["REV_NO"];
                drNew["CUR_UNIT"] = node["CUR_UNIT"];

                drNew["BOM_QTY"] = node["BOM_QTY"];
                drNew["ORI_BOM_QTY"] = node["ORI_BOM_QTY"];
                drNew["PROC_GRP"] = DBNull.Value;
                drNew["PROC_CODE"] = node["PROC_CODE"];
                drNew["STATE"] = "ADD";
                if (node["BOM_ID"].ToString() == node["PARENT_ID"].ToString())
                {
                    drNew["BOM_SEQ"] = iBomSeq;
                    drNew["REV_NO"] = node["REV_NO"];
                }
                else
                {
                    drNew["BOM_SEQ"] = node["BOM_SEQ"];
                }

                TreeListNode AddedNode;

                if (pNode == null)
                {
                    AddedNode = list.Nodes.Add(drNew);
                    //list.ExpandToLevel(0);
                }
                else
                {
                    AddedNode = pNode.Nodes.Add(drNew);
                    AddedNode.ParentNode.Expanded = true;

                }

                AddedNode["BOM_ID"] = AddedNode.Id;
                parent = AddedNode["BOM_ID"].ToString();

                if (node.HasChildren)
                {
                    int chSeq = 0;
                    foreach (TreeListNode n in node.Nodes)
                    {
                        //InsertNode(list, AddedNode, n, parent, iBomSeq);
                        InsertNode(list, AddedNode, n, parent, chSeq);
                        ++chSeq;
                        
                    }
                        //InsertNode(list, AddedNode, n, parent, iBomSeq);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private DragDropEffects GetDragDropEffect(TreeList tl, TreeListNode dragNode)
        {
            TreeListNode targetNode;
            Point p = tl.PointToClient(MousePosition);
            targetNode = tl.CalcHitInfo(p).Node;

            if (dragNode != null && targetNode != null
                && dragNode != targetNode)
                //&& dragNode.ParentNode == targetNode.ParentNode)
                return DragDropEffects.Move;
            else
                return DragDropEffects.None;
        }


        void acTreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            try
            {
                TreeListNode node = e.Node;
                Brush backBrush = new SolidBrush(_clrAssy);
                Brush matBrush = new SolidBrush(_clrMat);
                Brush rootBrush = new SolidBrush(_clrRoot);
                
                if (e.Column.FieldName == "BOM_QTY")
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                    e.Appearance.ForeColor = Color.Black;
                }

                if (node.RootNode == node)
                {
                    e.Graphics.FillRectangle(rootBrush, e.Bounds);
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if (node.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch { }
        }


        TreeListHitInfo _dragStartHitInfo;
        Cursor _dragRowCursor;
        Cursor _griddragRowCursor;

        void acTreeList1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (_dragStartHitInfo != null)
            {
                e.UseDefaultCursors = false;
                //Cursor.Current = _dragRowCursor;
            }

            if (_MouseDownHitInfo != null)
            {
                e.UseDefaultCursors = false;
                //Cursor.Current = _griddragRowCursor;
            }
        }

        void acTreeList1_MouseMove(object sender, MouseEventArgs e)
        {
            acTreeList list = sender as acTreeList;

            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                _dragStartHitInfo != null )
                //&& _dragStartHitInfo.HitInfoType == HitInfoType.Cell)
            {
                Size dragSize = SystemInformation.DragSize;
                //Rectangle dragRect = new Rectangle(new Point(_dragStartHitInfo.MousePoint.X - dragSize.Width / 2, _dragStartHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);
                Rectangle dragRect = new Rectangle(new Point(_dragStartHitInfo.MousePoint.X , _dragStartHitInfo.MousePoint.Y), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    //_dragRowCursor = _imageHelper.GetDragCursor(_dragStartHitInfo, e.Location);
                    _dragRowCursor = acGraphics.CreateCursor(STD.Resource.edit_paste_redo_2x, 0, 0);
                    
                    TreeListMultiSelection dragObject = list.Selection as TreeListMultiSelection;

                    list.DoDragDrop(dragObject, DragDropEffects.Link);

                    _dragStartHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
            else
            {
              //  this.Cursor = _griddragRowCursor;
            }
        }

        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {

            //if (e.Button == System.Windows.Forms.MouseButtons.Left &&
            //    Control.ModifierKeys == Keys.None)
            //    _dragStartHitInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
            //else
            //    _dragStartHitInfo = null;

            //if (e.Button == MouseButtons.Right)
            //{
            //    popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));
            //}
            try
            {
                acTreeList view = sender as acTreeList;
                
                if (e.Button == MouseButtons.Right)
                {
                    TreeListHitInfo hitInfo = view.CalcHitInfo(e.Location);

                    if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                    {
                        if (hitInfo.Node != null)
                        {

                            popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));

                            //if (hitInfo.Node["PART_CAT1"].ToString() == "B")
                            //{
                            //    if (hitInfo.Node.ParentNode["PART_CAT1"].ToString() != "B")
                            //    {
                            //        popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));
                            //    }
                            //}
                            //if (hitInfo.Node["PART_CAT1"].ToString() != "B")
                            //{
                            //    if (hitInfo.Node.ParentNode["BOM_ID"].ToString() == hitInfo.Node.ParentNode["PARENT_ID"].ToString())
                            //    {
                            //        popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));
                            //    }
                            //}


                        }
                    }
                }
            }
            catch { }
        }

        int CalcDestNodeIndex(DragEventArgs e, TreeListNode destNode)
        {
            try
            {
                if (destNode == null)
                    return -1;
                //if (e.InsertType == InsertType.AsChild)
                //    return -1000;
                var nodes = destNode.ParentNode == null ? acTreeList1.Nodes : destNode.ParentNode.Nodes;
                int index = nodes.IndexOf(destNode);
                //if (e.InsertType == InsertType.After)
                //    return ++index;
                return index;
            }
            catch { return 0; }
            
        }

        void AcTreeList1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if(!acLayoutControl1.ValidCheck())
                {
                    return;
                }
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                
                TreeList list = sender as TreeList;
                Point p = list.PointToClient(new Point(e.X, e.Y));

                if (e.Effect == DragDropEffects.Move)
                {
                    //그리드에서 가져온 품목
                    TreeListNode focusedNode = list.CalcHitInfo(p).Node;

                    TreeListNode AddedNode;

                    string parent_id = string.Empty;

                    if (focusedNode == null && list.Nodes.Count == 0)
                    {
                        DataRow drNew = (acTreeList1.DataSource as DataTable).NewRow();

                        //첫 노드 추가
                        drNew["BOM_ID"] = "";
                        drNew["BM_KEY"] = "";
                        drNew["BM_CODE"] = layoutRow["BM_CODE"];
                        drNew["PART_CODE"] = layoutRow["BM_CODE"];
                        //drNew["CD_VALUE"] = "PRODUCT";
                        drNew["BOM_QTY"] = 1;
                        drNew["STATE"] = "ADD";
                        drNew["BOM_SEQ"] = 0;

                        AddedNode = acTreeList1.Nodes.Add(drNew);
                        parent_id = AddedNode.Id.ToString();
                        AddedNode["BOM_ID"] = parent_id;
                        focusedNode = AddedNode;
                    }


                    string parent_id_Sel = string.Empty;
                    if (focusedNode != null)
                    {
                        parent_id = focusedNode["BOM_ID"].ToString();
                        parent_id_Sel = parent_id;
                    }
                    else
                    {
                        if (list.Nodes.FirstNode != null)
                        {
                            focusedNode = list.Nodes.FirstNode;
                            parent_id_Sel = focusedNode["PARENT_ID"].ToString();
                        }
                    }

                    DataRow[] dropData = e.Data.GetData(typeof(DataRow[])) as DataRow[];

                    foreach (DataRow dr in dropData)
                    {
                        int iBomSeq = 0;
                        iBomSeq = NodeNextSeq(parent_id_Sel);

                        
                        if (acTreeList2.AllNodesCount > 1)
                        {
                            TreeListNode node = acTreeList2.FocusedNode;
                            InsertNode(list, focusedNode, node, parent_id, iBomSeq);

                        }
                        else
                        {
                            InsertNode(acTreeList1, focusedNode, dr, parent_id, iBomSeq);
                        }
                    }
                }
                else
                {
                    //이동 

                    if (list.SortedColumnCount > 0)
                    {
                        acMessageBox.Show("컬럼의 정렬을 제거하신 후 이동하세요. ", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    TreeListNode targetNode = list.CalcHitInfo(p).Node;

                    if (targetNode == null) return;

                    TreeListMultiSelection dropData = e.Data.GetData(typeof(TreeListMultiSelection)) as TreeListMultiSelection;

                    if (dropData == null)
                        dropData = list.Selection;

                    IEnumerator sel = dropData.GetEnumerator();

                    sel.Reset();

                    //if (_modifierKey == Keys.ShiftKey)
                    if (this._holdingshift)
                    {
                        DataTable dtSource = (acTreeList1.DataSource as DataTable).Copy();
                        list.BeginUpdate();

                        while (sel.MoveNext())
                        {
                            TreeListNode node = sel.Current as TreeListNode;

                            if (node["PARENT_ID"].ToString() == node["BOM_ID"].ToString()) return;
                            DataRow[] drSelected = dtSource.Select(string.Format("BOM_ID = '{0}'", node["BOM_ID"]));

                            if (drSelected.Length > 0)
                            {
                                if (node["BOM_ID"] != targetNode["BOM_ID"])
                                {
                                    drSelected[0]["PARENT_ID"] = targetNode["BOM_ID"];

                                    int index = CalcDestNodeIndex(e, targetNode);

                                    //iBomSeq = NodeNextSeq(drSelected[0]["PARENT_ID"].ToString());
                                    //drSelected[0]["BOM_SEQ"] = iBomSeq;
                                    drSelected[0]["STATE"] = "MODI";
                                    acTreeList1.MoveNode(node, targetNode, true, index);
                                    list.SetNodeIndex(node, list.GetNodeIndex(targetNode));
                                }

                            }

                        }

                        list.EndUpdate();
                        list.ClearSelection();

                        //DataTable dtSorted = dtSource.Select("", "BOM_SEQ").CopyToDataTable();
                        //list.DataSource = dtSorted;

                        //list.ExpandAll();
                        list.SelectNode(targetNode);

                        _modifierKey = Keys.None;
                        //targetNode.Selected = true;
                    }
                    else
                    {
                        list.BeginUpdate();


                        int index = CalcDestNodeIndex(e, targetNode);

                        while (sel.MoveNext())
                        {
                            TreeListNode dragnode = sel.Current as TreeListNode;

                            acTreeList1.MoveNode(dragnode, targetNode.ParentNode, true, index);

                            //dragnode["STATE"] = "MODI";
                        }

                        list.EndUpdate();

                    }
                }

                e.Effect = DragDropEffects.None;
                //this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        int NodeNextSeq(string parent_id)
        {
            int i = 1;

            if (acTreeList1.GetDataView().Table.Select("PARENT_ID = '" + parent_id + "'").Count() > 0)
            {
                i = acTreeList1.GetDataView().Table.Select("PARENT_ID = '" + parent_id + "'").Max(r => r["BOM_SEQ"].toInt()) + 1;
            }

            return i;
        }
        void acTreeList1_DragOver(object sender, DragEventArgs e)
        {

            bool bNode = e.Data.GetDataPresent(typeof(TreeListNode));
            
            bool bNodes = e.Data.GetDataPresent(typeof(TreeListMultiSelection));
            //gridview에서 drag
            bool bDatarow = e.Data.GetDataPresent(typeof(DataRow[]));
            
            if (bDatarow)
            {
                e.Effect = DragDropEffects.Move;
                //this.Cursor = _griddragRowCursor;
                
                //this.Cursor = acGraphics.CreateCursor(acGridView1.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                //this.Cursor = acGraphics.CreateCursor(Resource.address_book_new_2x, 0, 0);
            }

            if (bNode || bNodes)
            {
                e.Effect = DragDropEffects.Link;

                //this.Cursor = acGraphics.CreateCursor(bmp, 0, 0);

            }
        }

        private GridHitInfo _MouseDownHitInfo = null;

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            _MouseDownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

            if (Control.ModifierKeys != Keys.None) return;

            if (hitInfo.InRow && e.Button == MouseButtons.Left)
            {
                _MouseDownHitInfo = hitInfo;
            }
        }

        void acGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.Button == System.Windows.Forms.MouseButtons.Left && _MouseDownHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;

                Rectangle dragRect = new Rectangle(new Point(_MouseDownHitInfo.HitPoint.X - dragSize.Width / 2,
                    _MouseDownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow[] rows = view.GetSelectedDataRows();
                    //DataRow row = view.GetDataRow(_MouseDownHitInfo.RowHandle);

                    _griddragRowCursor = acGraphics.CreateCursor(acGridView1.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0);
                    //this.Cursor = acGraphics.CreateCursor(acGridView1.GetFocusRowImage(acGridView.emFocusRowImageType.MOVE), 0, 0); 

                    view.GridControl.DoDragDrop(rows, DragDropEffects.Move);

                    _MouseDownHitInfo = null;

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }

            }
        }

        #endregion
        Hashtable nodesForDeleting;

        private Hashtable GetNodesForDeleting()
        {
            nodesForDeleting = new Hashtable();

            IEnumerator sel = acTreeList1.Selection.GetEnumerator();
            sel.Reset();

            while(sel.MoveNext())
            {
                TreeListNode node = sel.Current as TreeListNode;

                nodesForDeleting.Add(node["BOM_ID"], node); 
            }

            return nodesForDeleting;
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Hashtable nodesForDelet = GetNodesForDeleting();

                foreach (DictionaryEntry de in nodesForDelet)
                {

                    DataRow drDel = dtDeleted.NewRow();
                    drDel["PLT_CODE"] = acInfo.PLT_CODE;
                    drDel["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                    drDel["BOM_ID"] = de.Key;

                    dtDeleted.Rows.Add(drDel);

                    TreeListNode pnode = de.Value as TreeListNode;

                    SearchDeletedNodes(pnode);

                    acTreeList1.DeleteNode(pnode);
                }
            }

            catch
            {

            }
        }

        private void SearchDeletedNodes(TreeListNode node)
        {
            if (node.HasChildren)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    TreeListNode n = node.Nodes[i];

                    DataRow drDel = dtDeleted.NewRow();
                    drDel["PLT_CODE"] = acInfo.PLT_CODE;
                    drDel["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                    drDel["BOM_ID"] = n["BOM_ID"];

                    dtDeleted.Rows.Add(drDel);

                    SearchDeletedNodes(n);

                }

            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //초기화
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //개정
            RevItem();
        }


        public void RevItem()
        {
            try
            {
                if (!acLayoutControl1.ValidCheck())
                {
                    return;
                }

                string _setLock = setLock();
                string _lockEmp = "";
                if (_setLock == "LOCK")
                {
                    acMessageBox.Show("잠금 상태이므로 저장할 수 없습니다.", "잠금", acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
                else if(_setLock == "LOCKUSER")
                {
                    if(acMessageBox.Show("저장 후 잠금 해제하시겠습니까?", "잠금", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        _lockEmp = acInfo.UserID;
                    }
                }
                
                DataRow MasterlayoutRow = acLayoutControl1.CreateParameterRow();

                STD50A_D3A frm = new STD50A_D3A(MasterlayoutRow);

                frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //저장
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    DataTable paramTable = new DataTable("RQSTDT_M");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("BM_KEY", typeof(String));
                    paramTable.Columns.Add("REV_NO", typeof(String));
                    paramTable.Columns.Add("BM_CODE", typeof(String));
                    paramTable.Columns.Add("BOM_STATE", typeof(String));
                    paramTable.Columns.Add("LOCK_EMP", typeof(String));
                    paramTable.Columns.Add("SCOMMENT", typeof(String));
                    paramTable.Columns.Add("PART_CODE", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["BM_KEY"] = layoutRow["BM_KEY"];
                    paramRow["REV_NO"] = layoutRow["REV_NO"];
                    paramRow["BM_CODE"] = layoutRow["BM_CODE"];
                    paramRow["BOM_STATE"] = layoutRow["BOM_STATE"];
                    paramRow["LOCK_EMP"] = _lockEmp;
                    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    paramRow["PART_CODE"] = layoutRow["BM_CODE"];
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = SaveDataALL();
                    paramSet.Tables.Add(paramTable);

                    DataRow selectedRow = (DataRow)frm.OutputData;

                    //개정이력 정보
                    DataTable dtParamRev = new DataTable("RQSTDT_REV");
                    dtParamRev.Columns.Add("PLT_CODE", typeof(String));
                    dtParamRev.Columns.Add("BM_KEY", typeof(String));
                    dtParamRev.Columns.Add("BM_CODE", typeof(String));
                    dtParamRev.Columns.Add("REV_NO", typeof(Int32));
                    dtParamRev.Columns.Add("REV_DATE", typeof(String));
                    dtParamRev.Columns.Add("REV_COMMENT", typeof(String));
                    dtParamRev.Columns.Add("PART_CODE", typeof(String));

                    DataRow drParamRev = dtParamRev.NewRow();
                    drParamRev["PLT_CODE"] = acInfo.PLT_CODE;
                    drParamRev["BM_KEY"] = MasterlayoutRow["BM_KEY"];
                    drParamRev["BM_CODE"] = MasterlayoutRow["BM_CODE"];
                    drParamRev["REV_NO"] = selectedRow["REV_NO"];
                    drParamRev["REV_DATE"] = selectedRow["REV_DATE"];
                    drParamRev["REV_COMMENT"] = selectedRow["REV_COMMENT"];
                    drParamRev["PART_CODE"] = selectedRow["PART_CODE"];
                    dtParamRev.Rows.Add(drParamRev);
                    
                    paramSet.Tables.Add(dtParamRev);

                    if (selectedRow["RECEIVER"].ToString() != "")
                    {
                        //팝업 게시판 알림
                        DataTable dtParamRevBoard = new DataTable("RQSTDT_BOARD");
                        dtParamRevBoard.Columns.Add("PLT_CODE", typeof(String)); //
                        dtParamRevBoard.Columns.Add("BOARD_ID", typeof(String)); //
                        dtParamRevBoard.Columns.Add("ACC_LEVEL", typeof(String)); //
                        dtParamRevBoard.Columns.Add("TITLE", typeof(String)); //
                        dtParamRevBoard.Columns.Add("CONTENTS", typeof(String)); //
                        dtParamRevBoard.Columns.Add("RECEIVER", typeof(String)); //
                        dtParamRevBoard.Columns.Add("REG_EMP", typeof(String)); //

                        DataRow drParamRevBoard = dtParamRevBoard.NewRow();
                        drParamRevBoard["PLT_CODE"] = acInfo.PLT_CODE;
                        //paramRow["BOARD_ID"] = linkRow["BOARD_ID"];
                        drParamRevBoard["ACC_LEVEL"] = "E";    //개인
                        drParamRevBoard["TITLE"] = string.Format("[{0}] - BOM 개정 ", MasterlayoutRow["PART_CODE"].ToString());
                        drParamRevBoard["CONTENTS"] = selectedRow["REV_COMMENT"];
                        drParamRevBoard["RECEIVER"] = selectedRow["RECEIVER"];
                        drParamRevBoard["REG_EMP"] = acInfo.UserID;
                        dtParamRevBoard.Rows.Add(drParamRevBoard);

                        DataSet dsReceiver = frm.Receiver;
                        DataTable dtReceiverList = dsReceiver.Tables["RQSTDT2"].Copy();
                        dtReceiverList.TableName = "RQSTDT_BOARD_LIST";


                        paramSet.Tables.Add(dtParamRevBoard);
                        paramSet.Tables.Add(dtReceiverList);
                    }

                    BizRun.QBizRun.ExecuteService(this, "STD50A_INS2", paramSet, "RQSTDT,RQSTDT_M", "RSLTDT");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string _lockState = setLock();

            if(_lockState == "NOLOCK")
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BM_KEY", typeof(String)); //
                paramTable.Columns.Add("LOCK_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = _masterRow["BM_KEY"];
                paramRow["LOCK_EMP"] = acInfo.UserID;

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD50A_UPD", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);


            }
            else if(_lockState == "LOCKUSER")
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BM_KEY", typeof(String)); //
                paramTable.Columns.Add("LOCK_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BM_KEY"] = _masterRow["BM_KEY"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "STD50A_UPD", paramSet, "RQSTDT", "RSLTDT", QuickSave2, QuickException);



            }

        }


        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                setLock();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            acTreeList1.ExpandAll();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            acTreeList1.CollapseAll();
        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            SearchStdPart();
        }


    }
}