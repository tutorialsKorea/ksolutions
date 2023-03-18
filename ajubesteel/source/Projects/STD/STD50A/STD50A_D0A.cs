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
    public sealed partial class STD50A_D0A : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);


        }
        protected override void OnClosing(CancelEventArgs e)
        {

            if (_changed)
            {
                if (acMessageBox.Show(this, "수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?", "AEIR4MG6", true, acMessageBox.emMessageBoxType.YESNO)
                    == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnClosing(e);

            this.DialogResult = DialogResult.OK;
        }

        private DataRow _masterRow = null;

        private acTreeList _linkTreeList = null;

        private object _LinkData = null;

        private bool _changed = false;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private string _parent_id = string.Empty;
        
        private DataTable dtDeleted = null;

        public STD50A_D0A(DataRow masterRow, acTreeList linkTreeList, bool EditParent)
        {
            InitializeComponent();

            _masterRow = masterRow;

            _linkTreeList = linkTreeList;
            
            dtDeleted = new DataTable("DEL_RQSTDT");
            dtDeleted.Columns.Add("PLT_CODE", typeof(String));
            dtDeleted.Columns.Add("BM_CODE", typeof(String));
            dtDeleted.Columns.Add("BOM_ID", typeof(String));

            if (EditParent)
            {
                _parent_id = linkTreeList.FocusedNode["BOM_ID"].ToString();                
            }

            #region Set Grid Columns
            //전체 품목 grid
            acGridView1.GridType = acGridView.emGridType.SEARCH;
            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
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
            acTreeList1.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER, true);
            acTreeList1.AddTextEdit("ORI_BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, false, ControlManager.acTreeList.emTextEditMask.F2);
            acTreeList1.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M003",true); 
            
            acTreeList1.AddTextEdit("BOM_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER);            
            //acTreeList1.AddLookUpVendor("MVND_CODE", "공급업체", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
            acTreeList1.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "BOM_ID";
            acTreeList1.ParentFieldName = "PARENT_ID";


            acTreeList2.AddTextEdit("BM_KEY", "BOM 마스터 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("BOM_ID", "BOM_ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE, true);
            acTreeList2.AddTextEdit("BM_CODE", "최상위부품", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PARENT_ID", "모품목ID", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PARENT_PART_CODE", "모품목 코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE, true);
            acTreeList2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddLookUpEdit("PART_PRODTYPE", "분류", "", false, DevExpress.Utils.HorzAlignment.Default, true, true, "M007", false);
            acTreeList2.AddLookUpEdit("MAT_LTYPE", "자재구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M001", true);
            acTreeList2.AddLookUpEdit("MAT_MTYPE", "자재유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M002", true);
            acTreeList2.AddTextEdit("BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER, true);
            acTreeList2.AddTextEdit("ORI_BOM_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, false, ControlManager.acTreeList.emTextEditMask.F2);
            acTreeList2.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, ControlManager.acTreeList.emTextEditMask.NONE);
            acTreeList2.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, "M003", true);

            acTreeList2.AddTextEdit("BOM_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Far, true, false, ControlManager.acTreeList.emTextEditMask.NUMBER);
            //acTreeList1.AddLookUpVendor("MVND_CODE", "공급업체", "", false, DevExpress.Utils.HorzAlignment.Default, false, true, false);
            acTreeList2.AddTextEdit("STATE", "상태", "", false, DevExpress.Utils.HorzAlignment.Default, false, false, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList2.KeyFieldName = "BOM_ID";
            acTreeList2.ParentFieldName = "PARENT_ID";

            #endregion


            acGridView1.FocusedRowChanged += AcGridView1_FocusedRowChanged;
            acGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;

            acTreeList1.OptionsView.ShowIndicator = true;
            acTreeList1.IndicatorWidth = 30;
            acTreeList1.OptionsBehavior.Editable = true;
            acTreeList1.OptionsSelection.UseIndicatorForSelection = false;
            acTreeList1.OptionsView.ShowIndentAsRowStyle = true;
            acTreeList1.OptionsSelection.MultiSelect = true;
            acTreeList1.OptionsDragAndDrop.CanCloneNodesOnDrop = false;
            acTreeList1.OptionsDragAndDrop.InsertNodesInSelectionOrder = true;
            acTreeList1.OptionsDragAndDrop.DragNodesMode = DragNodesMode.None;


            acTreeList1.MouseDown += acTreeList1_MouseDown;
            acTreeList1.CellValueChanged += acTreeList1_CellValueChanged;
            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

        
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
            //InitDragDrop();
        }

        //BehaviorManager _behaviorManager1;

        void InitDragDrop()
        {

            //_behaviorManager1 = new BehaviorManager(

            //_behaviorManager1.Attach<DragDropBehavior>(acGridView1, behavior =>
            //{
            //    behavior.Properties.AllowDrop = false;
            //    behavior.Properties.InsertIndicatorVisible = true;
            //    behavior.Properties.PreviewVisible = true;
            //});

            //_behaviorManager1.Attach<DragDropBehavior>(acTreeList1, behavior =>
            //{
            //    behavior.Properties.AllowDrop = true;
            //    behavior.Properties.InsertIndicatorVisible = true;
            //    behavior.Properties.PreviewVisible = true;
            //    behavior.DragOver += OnDragOver;
            //    behavior.DragDrop += OnDragDrop;
            //});

        }

        private void OnDragOver(object sender, DevExpress.Utils.DragDrop.DragOverEventArgs e)
        {
            try
            {
             
                e.Default();
                
                e.Handled = true;
                e.Cursor = Cursors.Default;

                if (e.Source.GetType() == typeof(acGridView))
                    e.Action = DragDropActions.Move;
                else if (e.Source.GetType() == typeof(acTreeList))
                    e.Action = DragDropActions.Move; //주의 : COPY로 하면 이동시 복사됨
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode)
        {
            try
            {
                if (destNode == null)
                    return 0;

                var nodes = destNode.ParentNode == null ? acTreeList1.Nodes : destNode.ParentNode.Nodes;

                //int index = nodes.IndexOf(destNode);
                int index = destNode["BOM_SEQ"].toInt();

                bool isPass = false;
                if (acTreeList1.IsRootNode(destNode))
                {
                    if (destNode.Nodes.Count > 0)
                    {
                        //index = destNode.LastNode["BOM_SEQ"].toInt() + 1;
                        index = destNode.Nodes.Max(m => m["BOM_SEQ"].toInt()) + 1;
                        isPass = true;
                    }
                    
                }


                if (isPass == false)
                {
                    switch (e.InsertType)
                    {
                        case InsertType.Before:
                            --index;
                            break;
                        case InsertType.AsChild:
                            index = acTreeList1.Nodes.IndexOf(destNode);
                            break;
                        case InsertType.After:
                            ++index;
                            break;
                    }
                }

                return index < 0 ? 0 : index;
            }
            catch { return 0;  }
         
        }
        //List 
        TreeListNode _sortNode;
        private void OnDragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {
            try
            {
             
                Point p = acTreeList1.PointToClient(new Point(e.Location.X, e.Location.Y));

                TreeListNode targetNode = acTreeList1.CalcHitInfo(p).Node;

                this._sortNode = targetNode;

                if (e.Action == DragDropActions.Move)
                {
                    if (e.Source is acGridView)
                    {
                        //그리드뷰로부터 복사
                        var indexs = e.GetData<IEnumerable<int>>();

                        if (indexs == null)
                            return;

                        DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                        TreeListNode AddedNode;

                        string parent_id = string.Empty;

                        //ROOT 품목 추가
                        if (targetNode == null && acTreeList1.Nodes.Count == 0)
                        {
                            DataRow drNew = (acTreeList1.DataSource as DataTable).NewRow();

                            //첫 노드 추가
                            drNew["BOM_ID"] = "";
                            drNew["BM_KEY"] = "";
                            drNew["BM_CODE"] = layoutRow["BM_CODE"];
                            drNew["PART_CODE"] = layoutRow["BM_CODE"];
                            drNew["BOM_QTY"] = 1;
                            drNew["STATE"] = "ADD";
                            drNew["BOM_SEQ"] = 0;
                            //drNew["PARENT_ID"] = "";

                            AddedNode = acTreeList1.Nodes.Add(drNew);
                            parent_id = AddedNode.Id.ToString();
                            AddedNode["BOM_ID"] = parent_id;
                            targetNode = AddedNode;
                        }

                        string parent_id_Sel = string.Empty;
                        if (targetNode != null)
                        {
                            parent_id = targetNode["BOM_ID"].ToString();
                            parent_id_Sel = parent_id;
                        }
                        else
                        {
                            //bom이 이미 한번 작성되었고, 두 번째 빈 곳에 dragging 할 때. 
                            if (acTreeList1.Nodes.FirstNode != null)
                            {
                                targetNode = acTreeList1.Nodes.FirstNode;
                                parent_id_Sel = targetNode["PARENT_ID"].ToString();
                            }
                        }

                        DataTable source = acGridView1.GridControl.DataSource as DataTable;
                        int destIndex = CalcDestNodeIndex(e, targetNode);

                        //SortBomList(acTreeList1, targetNode);

                        bool hasBom = false;

                        //if (_dtChildBom.Rows.Count > 0)
                        //{
                        //    DialogResult msgResult =
                        //        acMessageBox.Show("반제품 bom정보도 같이 가져오시겠습니까?", "BOM 등록", acMessageBox.emMessageBoxType.YESNO);

                        //    if (msgResult == DialogResult.Yes)
                        //    {
                        //        hasBom = true;
                        //    }
                        //}

                        acTreeList1.BeginUpdate();

                        List<TreeListNode> tNodes = new List<TreeListNode>();

                        foreach (int _index in indexs)
                        {

                            DataRow dr = source.Rows[_index];

                            if (hasBom)
                            {

                                DataRow[] drRoot = _dtChildBom.Select("PARENT_ID IS NULL");

                                if (drRoot[0]["PART_CODE"].ToString() == layoutRow["BM_CODE"].ToString())
                                {
                                    acMessageBox.Show("현재 편집하는 품목과 가져오려는 품목이 동일하면 가져올 수 없습니다.", "BOM 편집", acMessageBox.emMessageBoxType.CONFIRM);
                                    e.Handled = false;
                                    return;
                                }
                                tNodes.Add(InsertNode(acTreeList1, targetNode, drRoot[0], parent_id));

                            }
                            else
                            {
                                tNodes.Add(InsertNode(acTreeList1, targetNode, dr, parent_id, destIndex, e.InsertType));
                            }

                            destIndex++;
                        }

                        if (tNodes.Count > 0)
                        {
                            int minSeq = tNodes.Min(m => m["BOM_SEQ"].toInt());
                            int maxSeq = tNodes.Max(m => m["BOM_SEQ"].toInt());
                            SortBomList(acTreeList1, tNodes.Last(), minSeq, maxSeq, tNodes);
                        }

                        acTreeList1.EndUpdate();

                        targetNode.Expand();

                        barStaticItem1.Caption = string.Format("드래그하여 품목 [{0}]개 추가", indexs.Count().ToString());
                    }
                    else if (e.Source is acTreeList)
                    {
                        //트리 리스트 내 이동 
                        //if (acTreeList1.SortedColumnCount > 0)
                        //{
                        //    acMessageBox.Show("컬럼의 정렬을 제거하신 후 이동하세요. ", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                        //    return;
                        //}

                        if (targetNode == null)
                        {
                            this._sortNode = null;
                            e.Handled = false;
                            return;
                        }


                        if (targetNode.ParentNode == null)
                        {
                            this._sortNode = null;
                            e.Handled = true;
                            return;
                        }


                        List<TreeListNode> _items = e.Data as List<TreeListNode>;

                        //int index = CalcDestNodeIndex(e, targetNode);

                        acTreeList1.BeginUpdate();

                        switch (e.InsertType)
                        {
                            case InsertType.AsChild:
                                {
                                    //target은 부모 노드
                                    //자식 노드의 최대 SEQ 구한 후  그 이후부터 증가시키기
                                    int maxSeq = targetNode.Nodes.Max(m => m["BOM_SEQ"].toInt());//BOM_SEQ 최대값 가져오기
                                    int seq = maxSeq + 1;
                                    foreach (TreeListNode node in _items.OrderBy(o => o["BOM_SEQ"])) //BOM_SEQ 순으로 정렬하여 가져오기
                                    {
                                        node["BOM_SEQ"] = maxSeq;
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (targetNode.ParentNode != null)
                                    {
                                        //이동한 노드를 제외한 노드들 집합
                                        //BOM_SEQ 순으로 정렬
                                        List<TreeListNode> exceptNodes = targetNode.ParentNode.Nodes.Except(_items)
                                                                                                    .OrderBy(o => o["BOM_SEQ"])
                                                                                                    .ToList();
                                        int seq = 0;
                                        foreach (TreeListNode node in exceptNodes)
                                        {
                                            //대상노드일때
                                            if (node.Id == targetNode.Id)
                                            {
                                                //대상노드 이후로 이동일때
                                                if (e.InsertType == InsertType.After)
                                                {
                                                    node["BOM_SEQ"] = seq++;
                                                }

                                                foreach (TreeListNode item in _items.OrderBy(o => o["BOM_SEQ"]))
                                                {
                                                    item["BOM_SEQ"] = seq++;
                                                }

                                                //대상노드 이전으로 이동일때
                                                if (e.InsertType == InsertType.Before)
                                                {
                                                    node["BOM_SEQ"] = seq++;
                                                }
                                            }
                                            else
                                            {
                                                node["BOM_SEQ"] = seq++;
                                            }
                                        }

                                    }

                                    break;
                                }
                        }
                        acTreeList1.EndUpdate();
                    }
                }
                //else
                //{
                //    //트리 리스트 내 이동 
                //    //if (acTreeList1.SortedColumnCount > 0)
                //    //{
                //    //    acMessageBox.Show("컬럼의 정렬을 제거하신 후 이동하세요. ", this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
                //    //    return;
                //    //}

                //    if (targetNode == null)
                //    {
                //        this._sortNode = null;
                //        e.Handled = false;
                //        return;
                //    }


                //    if (targetNode.ParentNode == null)
                //    {
                //        this._sortNode = null;
                //        e.Handled = true;
                //        return;
                //    }


                //    List<TreeListNode> _items = e.Data as List<TreeListNode>;

                //    //int index = CalcDestNodeIndex(e, targetNode);

                //    acTreeList1.BeginUpdate();

                //    switch(e.InsertType)
                //    {
                //        case InsertType.AsChild:
                //            {
                //                //target은 부모 노드
                //                //자식 노드의 최대 SEQ 구한 후  그 이후부터 증가시키기
                //                int maxSeq = targetNode.Nodes.Max(m => m["BOM_SEQ"].toInt());//BOM_SEQ 최대값 가져오기
                //                int seq = maxSeq + 1;
                //                foreach(TreeListNode node in _items.OrderBy(o=>o["BOM_SEQ"])) //BOM_SEQ 순으로 정렬하여 가져오기
                //                {
                //                    node["BOM_SEQ"] = maxSeq;
                //                }
                //                break;
                //            }
                //        default:
                //            {
                //                if(targetNode.ParentNode != null)
                //                {
                //                    //이동한 노드를 제외한 노드들 집합
                //                    //BOM_SEQ 순으로 정렬
                //                    List<TreeListNode> exceptNodes = targetNode.ParentNode.Nodes.Except(_items)
                //                                                                                .OrderBy(o => o["BOM_SEQ"])
                //                                                                                .ToList();
                //                    int seq = 0;
                //                    foreach(TreeListNode node in exceptNodes)
                //                    {
                //                        //대상노드일때
                //                        if(node.Id == targetNode.Id)
                //                        {
                //                            //대상노드 이후로 이동일때
                //                            if (e.InsertType == InsertType.After)
                //                            {
                //                                node["BOM_SEQ"] = seq++;
                //                            }

                //                            foreach(TreeListNode item in _items.OrderBy(o=>o["BOM_SEQ"]))
                //                            {
                //                                item["BOM_SEQ"] = seq++;
                //                            }

                //                            //대상노드 이전으로 이동일때
                //                            if (e.InsertType == InsertType.Before)
                //                            {
                //                                node["BOM_SEQ"] = seq++;
                //                            }
                //                        }
                //                        else
                //                        {
                //                            node["BOM_SEQ"] = seq++;
                //                        }
                //                    }

                //                }

                //                break;
                //            }
                //    }
                //    //foreach (TreeListNode _item in _items)
                //    //{

                //    //    if (e.InsertType == InsertType.AsChild)
                //    //    {
                //    //        acTreeList1.MoveNode(_item, targetNode, true, index);
                //    //        parent_id = targetNode["BOM_ID"].ToString();

                //    //        _item["STATE"] = "MODI";
                //    //        _item["BOM_SEQ"] = index;
                //    //        _item["PARENT_ID"] = parent_id;
                //    //        index++;
                //    //        continue;
                //    //    }
                //    //    else if (e.InsertType == InsertType.Before)
                //    //    {
                //    //        if (targetNode.PrevNode != null)
                //    //        {
                //    //            if (index == targetNode.PrevNode["BOM_SEQ"].toInt()) ++index;
                //    //        }
                //    //    }
                //    //    else if (e.InsertType == InsertType.After)
                //    //    {
                //    //        if (targetNode.NextNode != null)
                //    //        {
                //    //            if (index == targetNode.NextNode["BOM_SEQ"].toInt()) --index;
                //    //        }
                //    //    }

                //    //    acTreeList1.MoveNode(_item, targetNode.ParentNode, true, index);
                //    //    parent_id = targetNode.ParentNode["BOM_ID"].ToString();

                //    //    _item["STATE"] = "MODI";
                //    //    _item["BOM_SEQ"] = index;
                //    //    _item["PARENT_ID"] = parent_id;
                //    //    index++;
                //    //}

                //    acTreeList1.EndUpdate();

                //}

                _changed = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void OnEndDragDrop(object sender, EndDragDropEventArgs e)
        {
            try
            {

                DragDropEvents doe = sender as DragDropEvents;


                //if (this._sortNode != null)
                //{
                //    TreeListNodes nodesSeq = _sortNode.ParentNode == null
                //                    ? _sortNode.TreeList.Nodes
                //                    : _sortNode.ParentNode.Nodes;

                //    //acTreeList1.

                //    int cnt = nodesSeq.Count;
                //    for (var i = 0; i < cnt; i++)
                //    {
                //        nodesSeq[i].SetValue("BOM_SEQ", i);
                //        nodesSeq[i].SetValue("STATE", "MODI");
                //        if (nodesSeq[i].IsSelected)
                //            nodesSeq[i].Visible = false;
                //    }
                //    //acTreeList1.EndUpdate();

                //    _sortNode.Expand();
                //}
                barStaticItem1.Caption = "이동 완료";
            }
            catch { }

        }

        DataTable _dtChildBom;
        private void AcGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                if (focusRow == null) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("BM_CODE", typeof(String));

                DataRow drParam = dtParam.NewRow();
                drParam["PLT_CODE"] = acInfo.PLT_CODE;
                drParam["BM_CODE"] = focusRow["PART_CODE"];

                dtParam.Rows.Add(drParam);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD50A_SER2", paramSet, "RQSTDT", "RSLTDT");

                acTreeList2.DataSource = resultSet.Tables["RSLTDT"];
                acTreeList2.ExpandAll();
                //_dtChildBom = resultSet.Tables["RSLTDT"];
                //DataRow[] sortedRows = resultTable.Select("", "BOM_SEQ");
            }
            catch { }

        }

        bool _isSoring = false;

        void acTreeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                acTreeList tlView = sender as acTreeList;
                if (tlView == null) return;

                //e.Node["STATE"] = "MODI";

                switch(e.Column.FieldName)
                {
                    case "BOM_QTY":
                        {
                            if (e.Node.HasChildren)
                            {
                                SetModichildnodeQty(e.Node, e.Node["BOM_QTY"].toInt());
                            }

                            //e.Node["UNIT_AMT"] = e.Node["BOM_QTY"].toDecimal() * e.Node["UNIT_COST"].toDecimal();
                            e.Node["STATE"] = "MODI";
                            break;
                        }
                    case "BOM_SEQ":
                        {
                            SortBomList(tlView, e.Node, e.Node["BOM_SEQ"].toInt(), e.Node["BOM_SEQ"].toInt(), new List<TreeListNode>() { e.Node });
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        /// <summary>
        /// 노드 순서 재입력
        /// </summary>
        /// <param name="tlView"></param>
        /// <param name="targetNode">기준노드</param>
        /// <param name="firstRangeSeq">입력 데이터의 시작 BOM_SEQ</param>
        /// <param name="lastRangeSeq">입력 데이터의 끝 BOM_SEQ</param>
        void SortBomList(acTreeList tlView, TreeListNode targetNode, int firstRangeSeq, int lastRangeSeq, List<TreeListNode> AddNodeList )
        {
            try
            {
                //이미 순서 변경중일때는 작동하지 않는다.
                if (_isSoring == false)
                {
                    if (tlView.IsRootNode(targetNode))
                    {
                        var destNodes = tlView.Nodes.Where(r => r["PARENT_ID"].ToString() == targetNode["PARENT_ID"].ToString()
                                                                        && r["PARENT_ID"].ToString() != r["BOM_ID"].ToString()
                                                                        && r["BOM_SEQ"].toInt() >= firstRangeSeq) //시작 BOM 순서 이상 검색
                                                                         .OrderBy(o => o["BOM_SEQ"].toInt());
                        if (destNodes.Count() == 0) return;
                        _isSoring = true;

                        int index = lastRangeSeq + 1; //BOM 순서 마지막 것보다 커야함
                        foreach (var row in destNodes)
                        {
                            if (AddNodeList.Where(r => r.Id == row.Id).Any()) continue;

                            row["BOM_SEQ"] = index++;
                        }
                    }
                    else
                    {
                        //DataView destView = tlView.GetDataView("PARENT_ID = '" + e.Node["PARENT_ID"] + "' AND PARENT_ID <> BOM_ID");
                        //if (destView.Count == 0) break;

                        var destNodes = targetNode.ParentNode.Nodes.Where(r => r["PARENT_ID"].ToString() == targetNode["PARENT_ID"].ToString()
                                                                        && r["PARENT_ID"].ToString() != r["BOM_ID"].ToString()
                                                                        && r["BOM_SEQ"].toInt() >= firstRangeSeq)    //시작 BOM 순서 이상 검색
                                                                         .OrderBy(o => o["BOM_SEQ"].toInt());
                        if (destNodes.Count() == 0) return;
                        _isSoring = true;

                        int index = lastRangeSeq + 1; //BOM 순서 마지막 것보다 커야함
                        foreach (var row in destNodes)
                        {
                            //리스트에 존재하면 건너띄기
                            if (AddNodeList.Where(r => r.Id == row.Id).Any()) continue;

                            row["BOM_SEQ"] = index++;
                        }

                    }
                    _isSoring = false;
                }
            } 
            catch (Exception ex)
            {

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

       

        //void SetModichildnode(TreeListNode node, string proc_grp)
        //{
        //    try
        //    {
        //        foreach (TreeListNode n in node.Nodes)
        //        {
        //            n["STATE"] = "MODI";
        //            n["PROC_GRP"] = proc_grp;

        //            if (node.HasChildren)
        //                SetModichildnode(n, proc_grp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);

        //    }
        //}
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

            (acLayoutControl2.GetEditor("MAT_LTYPE") as acLookupEdit).SetCode("M001");
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

                acTreeList1.ExpandAll();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        //private void UpdateNodesPositions(TreeListNodes nodes)
        //{
        //    var ns = new List<TreeListNode>();
        //    foreach (TreeListNode n in nodes)
        //    {
        //        ns.Add(n);
        //    }
        //    foreach (TreeListNode n in ns)
        //    {
        //        UpdateNodesPositions(n.Nodes);
        //        n.TreeList.SetNodeIndex(n, Convert.ToInt32(n.GetValue("BOM_SEQ")));
        //    }
        //}

        //private void SaveNewRecordPosition(EndDragDropEventArgs e)
        //{

        //    var nodes = e.Node.ParentNode == null
        //                ? e.Node.TreeList.Nodes
        //                : e.Node.ParentNode.Nodes;

        //    for (var i = 0; i < nodes.Count; i++)
        //    {
        //        nodes[i].SetValue("BOM_SEQ", i);
        //        nodes[i].SetValue("STATE", "MODI");

        //    }
        //}


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
                        newrow["BM_CODE"] = acLayoutControl1.GetEditor("BM_CODE").Value;
                        newrow["PART_CODE"] = dr["PART_CODE"];
                        //newrow["PROC_GRP"] = dr["PROC_GRP"];
                        //newrow["PROC_CODE"] = dr["PROC_CODE"];
                        newrow["BOM_QTY"] = dr["BOM_QTY"];
                        newrow["BOM_SEQ"] = dr["BOM_SEQ"];
                        newrow["ID"] = dr["BOM_ID"];

                        if (dr["BM_CODE"].ToString() != dr["PART_CODE"].ToString())
                        {
                            newrow["P_ID"] = dr["PARENT_ID"];
                            newrow["PARENT_ID"] = dr["PARENT_ID"];
                        }
                            
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
                    _changed = false;
                }

                acTreeList1.DataSource = e.result.Tables["RSLTDT_BOM"];
                acTreeList1.ExpandAll();

                barStaticItem1.Caption = string.Format("BOM 저장 완료" );

                //acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
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

        private TreeListNode InsertNode(TreeList list, TreeListNode pNode, DataRow dr, string parent, int iBomSeq, InsertType insertType)
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
                drNew["STATE"] = "ADD";
                drNew["BOM_SEQ"] = iBomSeq;

                TreeListNode AddedNode =null;

                if (pNode == null)
                {
                    AddedNode = list.Nodes.Add(drNew);
                    //list.ExpandToLevel(0);
                }
                else
                {
                    if (insertType == InsertType.Before || insertType == InsertType.After)
                    {
                        drNew["BOM_SEQ"] = iBomSeq;
                        if (list.IsRootNode(pNode))
                        {
                            AddedNode = pNode.Nodes.Add(drNew);
                        }
                        else
                        {
                            AddedNode = pNode.ParentNode.Nodes.Add(drNew);
                            acTreeList1.MoveNode(AddedNode, pNode.ParentNode, true, iBomSeq);
                        }

                        AddedNode["BOM_ID"] = AddedNode.Id;
                        AddedNode.Expand();
                    }
                    else if (insertType == InsertType.AsChild || insertType == InsertType.None)
                    {
                        AddedNode = pNode.Nodes.Add(drNew);
                        AddedNode["BOM_ID"] = AddedNode.Id;
                        AddedNode.Expand();
                    }

                    
                }
             
                return AddedNode;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            return null;
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
                        InsertNode(list, AddedNode, n, parent, chSeq);
                        ++chSeq;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private TreeListNode InsertNode(TreeList list, TreeListNode pNode, DataRow drData, string parent)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow drNew = (list.DataSource as DataTable).NewRow();


                drNew["BOM_ID"] = "";
                drNew["BM_KEY"] = layoutRow["BM_KEY"];
                drNew["BM_CODE"] = layoutRow["BM_CODE"];
                drNew["PARENT_ID"] = parent;
                drNew["PART_CODE"] = drData["PART_CODE"];
                drNew["PART_NAME"] = drData["PART_NAME"];
                drNew["PART_PRODTYPE"] = drData["PART_PRODTYPE"];
                drNew["MAT_LTYPE"] = drData["MAT_LTYPE"];
                drNew["MAT_MTYPE"] = drData["MAT_MTYPE"];
                drNew["MAT_UNIT"] = drData["MAT_UNIT"];
                drNew["DRAW_NO"] = drData["DRAW_NO"];
                drNew["BOM_QTY"] = drData["BOM_QTY"];
                drNew["ORI_BOM_QTY"] = drData["ORI_BOM_QTY"];
                drNew["BOM_SEQ"] = drData["BOM_SEQ"];
                drNew["STATE"] = "ADD";

                TreeListNode AddedNode = null;

                if (pNode == null)
                {
                    AddedNode = list.Nodes.Add(drNew);
                }
                else
                {
                    AddedNode = pNode.Nodes.Add(drNew);
                    AddedNode.ParentNode.Expanded = true;
                }

                AddedNode["BOM_ID"] = AddedNode.Id;
                parent = AddedNode["BOM_ID"].ToString();

                DataRow[] children = _dtChildBom.Select(string.Format("PARENT_ID = '{0}'", drData["BOM_ID"].ToString()));
                    
                foreach(DataRow drChild in children)
                {
                    InsertNode(acTreeList1, AddedNode, drChild, parent);
                }

                //pNode = AddedNode;
                return AddedNode;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            return null;
        }


        void acTreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            try
            {
                TreeListNode node = e.Node;
                //Brush backBrush = new SolidBrush(_clrAssy);
                //Brush matBrush = new SolidBrush(_clrMat);
                Brush rootBrush = new SolidBrush(Color.LightYellow);
                
                //if (e.Column.FieldName == "BOM_QTY")
                //{
                //    e.Graphics.FillRectangle(backBrush, e.Bounds);
                //    e.Appearance.ForeColor = Color.Black;
                //}

                if (node.RootNode == node)
                {
                    e.Graphics.FillRectangle(rootBrush, e.Bounds);
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if (node.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, e.Bounds);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch { }
        }


        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {

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

                        }
                    }
                }
            }
            catch { }
        }
        
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
                string ret = setLock();

                if (ret == "NOLOCK")
                    barStaticItem1.Caption = "잠금 해제되었습니다.";
                else if (ret == "LOCKUSER")
                    barStaticItem1.Caption = "현재 사용자에 의해 잠금 되었습니다."; //string.Format("사용자['{0}'] 에 의해 잠금", "");
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

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchBom();
        }
    }
}