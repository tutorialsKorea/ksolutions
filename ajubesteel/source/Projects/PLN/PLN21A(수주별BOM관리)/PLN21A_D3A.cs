using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using BizManager;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;

namespace PLN
{
    public sealed partial class PLN21A_D3A : BaseMenuDialog
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

        private DataRow _linkRow = null;

        private DataTable dtDeleted = null;

        private string _prodCode = null;

        private DataTable _dtEdited;

        private bool _isNew = false;

        private string _prodType = "1";

        public PLN21A_D3A(string linkData, DataTable linkTable, bool isNew, DataRow linkRow)
        {
            InitializeComponent();

            _prodCode = linkData;

            _dtEdited = linkTable;
            //_linkRow = linkRow;

            _isNew = isNew;

            _linkRow = linkRow;

            if (_isNew)
            {
               acLayoutControl1.Visible = true;
            }
            else
            {
                acLayoutControl1.Visible = false;
            }


            if (_linkRow["PROD_TYPE"].toStringEmpty() != "")
            {
                DataRow prodRow = acInfo.StdCodes.GetCodeRow("P010", _linkRow["PROD_TYPE"]);

                if (prodRow != null)
                {
                    if (prodRow["CD_PARENT"].toStringEmpty() != "")
                    {
                        _prodType = prodRow["CD_PARENT"].toStringEmpty();
                    }
                }
            }

            acLayoutControl2.DataBind(_linkRow, false);

        }

  

        public override void DialogInit()
        {

            acTreeList1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", false);
            acTreeList1.AddTextEdit("DRAW_NO", "도면명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddCheckEdit("CHK_FLAG", "선택", "", false, true, true, acTreeList.emCheckEditDataType._STRING);
            acTreeList1.Columns["CHK_FLAG"].AppearanceCell.BackColor2 = Color.Red;

            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);
            acTreeList1.AddTextEdit("ORD_QTY", "개별 수주 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("SUM_QTY", "제작수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, acTreeList.emTextEditMask.QTY);

            acTreeList1.AddButtonEdit("DWG_OPEN", "DWG", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);

            if (acTreeList1.Columns.ColumnByFieldName("DWG_OPEN").ColumnEdit is RepositoryItemButtonEdit treeRib)
            {
                treeRib.ButtonClick += DWG_OPEN_ColumnEdit_Click;
            }


            acTreeList1.AddButtonEdit("PDF_OPEN", "PDF", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);

            if (acTreeList1.Columns.ColumnByFieldName("PDF_OPEN").ColumnEdit is RepositoryItemButtonEdit treeRib2)
            {
                treeRib2.ButtonClick += PDF_OPEN_ColumnEdit_Click;
            }

            acTreeList1.AddButtonEdit("JT_OPEN", "JT", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false);

            if (acTreeList1.Columns.ColumnByFieldName("JT_OPEN").ColumnEdit is RepositoryItemButtonEdit treeRib3)
            {
                treeRib3.ButtonClick += JT_OPEN_ColumnEdit_Click;
            }

            acTreeList1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            //acTreeList1.AddTextEdit("DATA_FLAG", "삭제여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "PT_ID";
            acTreeList1.ParentFieldName = "O_PT_ID";
            acTreeList1.OptionsView.AutoWidth = true;

            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            acTreeList1.CellValueChanging += AcTreeList1_CellValueChanging;

            acTreeList1.CellValueChanged += acTreeList1_CellValueChanged;

            acTreeList1.MouseDown += AcTreeList1_MouseDown;

            acTreeList1.CustomNodeCellEditForEditing += acTreeList1_CustomNodeCellEditForEditing;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();
        }

        private void acTreeList1_CustomNodeCellEditForEditing(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName == "SUM_QTY")
            {
                if (e.Node.HasChildren)
                {
                    e.RepositoryItem.ReadOnly = true;
                    e.RepositoryItem.Appearance.BackColor = Color.Red;
                }
                else
                {
                    e.RepositoryItem.ReadOnly = false;
                }
            }
        }
        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                acLayoutControl layout = sender as acLayoutControl;

                if (newValue.ToString() == "1")
                {
                    BomAllSearch();
                }
                else
                {
                    BomSearch();
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void SetChildChkFlag(TreeListNode node, string chkFlag)
        {
            node["CHK_FLAG"] = chkFlag;

            //자품목들 전체 체크 및 해제
            if (node.HasChildren)
            {
                foreach (TreeListNode n in node.Nodes)
                {
                    SetChildChkFlag(n, chkFlag);
                }
            }
        }

        void SetParentChkFlag(TreeListNode node, string chkFlag)
        {
            if (node.ParentNode != null)
            {
                bool isChk = true;

                //체크해제인 경우 각 레벨별 동일레벨에 체크가 있으면 그위로는 해제안함
                if (chkFlag == "0")
                {
                    foreach (TreeListNode n in node.ParentNode.Nodes)
                    {
                        if (n["CHK_FLAG"].ToString() == "1")
                        {
                            isChk = false;
                            break;
                        }
                    }
                }

                if (isChk)
                {
                    node.ParentNode["CHK_FLAG"] = chkFlag;

                    SetParentChkFlag(node.ParentNode, chkFlag);
                }
            }
        }

        private void DWG_OPEN_ColumnEdit_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRowView drView = acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode) as DataRowView;

                if (drView == null) return;

                DataRow dr = drView.Row;

                if (dr == null) return;

                CodeHelperManager.acOpenDrawFile.GetFile(this, dr, "DWG");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void PDF_OPEN_ColumnEdit_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRowView drView = acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode) as DataRowView;

                if (drView == null) return;

                DataRow dr = drView.Row;

                if (dr == null) return;

                CodeHelperManager.acOpenDrawFile.GetFile(this, dr, "PDF");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void JT_OPEN_ColumnEdit_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRowView drView = acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode) as DataRowView;

                if (drView == null) return;

                DataRow dr = drView.Row;

                if (dr == null) return;

                CodeHelperManager.acOpenDrawFile.GetFile(this, dr, "JT");
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcTreeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try 
            {
                if (e.Column.FieldName == "CHK_FLAG")
                {
                    acTreeList1.EndEditor();

                    DataRow tlRow = acTreeList1.GetFocusedDataRow();
                    if (tlRow.isNullOrEmpty()) { return; }

                    TreeListNode trNode = acTreeList1.FocusedNode;

                    String chk = e.Value.ToString();

                    SetChildChkFlag(trNode, chk);

                    SetParentChkFlag(trNode, chk);

                    #region 기존처리 주석
                    /*
                    TreeListNode node = trNode;

                    while (true)
                    {
                        if (node.LastNode == null)
                        {
                            break;
                        }

                        node = node.LastNode;
                    }

                    SetChkFlag(node, chk, trNode.Level);

                    */

                    /*
                    return;
                    

                    DataTable dtTree = acTreeList1.GetDataView().ToTable();                    

                    DataRow[] rootNode = dtTree.Select("[P_PART_CODE] IS NULL");

                    //string rootPart = rootNode[0]["PART_CODE"].ToString();
                    string rootPart = rootNode[0]["PT_ID"].ToString();

                    DataTable parentDT = dtTree.Clone();

                    //string parentCode = tlRow["P_PART_CODE"].ToString();
                    string parentCode = tlRow["O_PT_ID"].ToString();

                    int idx = 0;

                    while (true)
                    {
                        if (parentCode == rootPart)
                        {
                            break;
                        }

                        //DataRow[] parentRow = dtTree.Select("[PART_CODE] = '" + parentCode + "'");
                        DataRow[] parentRow = dtTree.Select("[PT_ID] = '" + parentCode + "'");

                        foreach (DataRow pRow in parentRow)
                        {
                            DataRow newRow = parentDT.NewRow();
                            newRow.ItemArray = pRow.ItemArray;
                            parentDT.Rows.Add(newRow);

                            //parentCode = pRow["P_PART_CODE"].ToString();
                            parentCode = pRow["O_PT_ID"].ToString();
                        }

                        if (idx > 10)
                        {
                            break;
                        }

                        idx++;

                    }

                    //DataTable childDT = dtTree.Clone();

                    //DataTable childs = new DataTable();
                    //childs.Columns.Add("PART_CODE", typeof(string));

                    //DataRow childsRow = childs.NewRow();
                    //childsRow["PART_CODE"] = tlRow["PART_CODE"];
                    //childs.Rows.Add(childsRow);

                    //DataTable tempChilds = childs.Clone();

                    //int idx2 = 0;

                    //while (true)
                    //{
                    //    foreach (DataRow rw in childs.Rows)
                    //    {
                    //        DataRow[] childRows = dtTree.Select("[P_PART_CODE] = '" + rw["PART_CODE"].ToString() + "'");

                    //        foreach (DataRow cRow in childRows)
                    //        {
                    //            DataRow newRow = childDT.NewRow();
                    //            newRow.ItemArray = cRow.ItemArray;
                    //            childDT.Rows.Add(newRow);

                    //            DataRow childNewRow = tempChilds.NewRow();
                    //            childNewRow["PART_CODE"] = cRow["PART_CODE"];
                    //            tempChilds.Rows.Add(childNewRow);
                    //        }

                    //    }

                    //    childs = tempChilds;


                    //    if (idx2 > 10)
                    //    {
                    //        break;
                    //    }

                    //    idx2++;
                    //}

                    //체크한 경우
                    if (e.Value.ToString() == "1")  
                    {
                        if (tlRow["P_PART_CODE"].isNullOrEmpty())  // 최상단 노드
                        {
                            foreach (DataRow row in dtTree.Rows)
                            {
                                row["CHK_FLAG"] = "1";
                                acTreeList1.UpdateMapingRow(row, true);
                            }
                        }
                        else
                        {
                            //if (tlRow["P_PART_CODE"].ToString() == rootPart) 
                            if (tlRow["O_PT_ID"].ToString() == rootPart)
                            {
                                // 최상위 노드가 해제된 경우
                                if (rootNode[0]["CHK_FLAG"].ToString() == "0")
                                {
                                    rootNode[0]["CHK_FLAG"] = "1";
                                    acTreeList1.UpdateMapingRow(rootNode[0], true);
                                }

                                // 자식노드가 없는 경우
                                //if (dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").Length == 0)
                                if (dtTree.Select("[O_PT_ID] = '" + tlRow["PT_ID"].ToString() + "'").Length == 0)
                                {
                                    tlRow["CHK_FLAG"] = "1";
                                    acTreeList1.UpdateMapingRow(tlRow, true);
                                    return;
                                }

                                //DataTable temp = dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").CopyToDataTable();
                                DataTable temp = dtTree.Select("[O_PT_ID] = '" + tlRow["PT_ID"].ToString() + "'").CopyToDataTable();
                                temp.ImportRow(tlRow);

                                foreach (DataRow row in temp.Rows)
                                {
                                    row["CHK_FLAG"] = "1";
                                    acTreeList1.UpdateMapingRow(row, true);
                                }
                            }
                        }

                        //if (parentRow.Length > 0)
                        if(parentDT.Rows.Count > 0)
                        {
                            if (parentDT.Rows[0]["CHK_FLAG"].ToString() == "0" || parentDT.Rows[0]["CHK_FLAG"].isNullOrEmpty())
                            {
                                DataTable temp = dtTree.NewRow().NewTable();
                                temp.Rows.Clear();
                                temp.ImportRow(rootNode[0]);
                                //temp.ImportRow(parentRow[0]);
                                foreach (DataRow row in parentDT.Rows)
                                {
                                    temp.ImportRow(row);
                                }

                                foreach (DataRow row in temp.Rows)
                                {
                                    row["CHK_FLAG"] = "1";
                                    acTreeList1.UpdateMapingRow(row, true);
                                }
                            }
                        }

                        tlRow["CHK_FLAG"] = "1";

                        acTreeList1.UpdateMapingRow(tlRow, true);

                    }
                    else //체크 해제한 경우
                    {
                        if (tlRow["P_PART_CODE"].isNullOrEmpty())
                        {
                            foreach (DataRow row in dtTree.Rows)
                            {
                                row["CHK_FLAG"] = 0;
                                acTreeList1.UpdateMapingRow(row, true);
                            }
                        }
                        else
                        {
                            //if (tlRow["P_PART_CODE"].ToString() == rootPart)
                            if (tlRow["O_PT_ID"].ToString() == rootPart)
                            {
                                //int midNodeCnt = dtTree.Select("[P_PART_CODE] = '" + rootPart + "'").Length;
                                //int unCheck_midCnt = dtTree.Select("[P_PART_CODE] = '" + rootPart + "'" + "AND [CHK_FLAG] = '0'").Length + 1;

                                int midNodeCnt = dtTree.Select("[O_PT_ID] = '" + rootPart + "'").Length;
                                int unCheck_midCnt = dtTree.Select("[O_PT_ID] = '" + rootPart + "'" + "AND [CHK_FLAG] = '0'").Length + 1;

                                if (midNodeCnt == unCheck_midCnt)
                                {
                                    rootNode[0]["CHK_FLAG"] = "0";
                                    acTreeList1.UpdateMapingRow(rootNode[0], true);
                                }

                                // 자식노드가 없는 경우
                                //if (dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").Length == 0)
                                if (dtTree.Select("[O_PT_ID] = '" + tlRow["PT_ID"].ToString() + "'").Length == 0)
                                {
                                    tlRow["CHK_FLAG"] = "0";
                                    acTreeList1.UpdateMapingRow(tlRow, true);
                                    return;
                                }

                                //DataTable temp = dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").CopyToDataTable();
                                DataTable temp = dtTree.Select("[O_PT_ID] = '" + tlRow["PT_ID"].ToString() + "'").CopyToDataTable();
                                temp.ImportRow(tlRow);

                                foreach (DataRow row in temp.Rows)
                                {
                                    row["CHK_FLAG"] = "0";
                                    acTreeList1.UpdateMapingRow(row, true);
                                }
                            }
                        }

                        // 특정 부모노드에 종속된 모든 자식노드가 UnChecked 상태인지 검사.
                        //int Child_NodeCount = dtTree.Select("[P_PART_CODE] = '" + tlRow["P_PART_CODE"].ToString() + "'").Length;
                        //int Child_UnCheck_NodeCount = dtTree.Select("[P_PART_CODE] = '" + tlRow["P_PART_CODE"].ToString() + "'" +
                        //     "AND [CHK_FLAG] = '0'").Length + 1;

                        int Child_NodeCount = dtTree.Select("[O_PT_ID] = '" + tlRow["O_PT_ID"].ToString() + "'").Length;
                        int Child_UnCheck_NodeCount = dtTree.Select("[O_PT_ID] = '" + tlRow["O_PT_ID"].ToString() + "'" +
                             "AND [CHK_FLAG] = '0'").Length + 1;

                        if (Child_NodeCount == Child_UnCheck_NodeCount)
                        {

                            foreach (DataRow row in parentDT.Rows)
                            {
                                row["CHK_FLAG"] = "0";
                                acTreeList1.UpdateMapingRow(row, true);
                            }

                            //parentRow[0]["CHK_FLAG"] = "0";
                            //acTreeList1.UpdateMapingRow(parentRow[0], true);
                        }

                        tlRow["CHK_FLAG"] = "0";

                        acTreeList1.UpdateMapingRow(tlRow, true);


                        // 전체 노드 검사 (Uncheck)
                        int AllNodeUnChkCount = acTreeList1.GetDataView().ToTable().Select("[CHK_FLAG] = '0'").Length;

                        if (AllNodeUnChkCount == (acTreeList1.AllNodesCount - 1))
                        {
                            rootNode[0]["CHK_FLAG"] = "0";
                            acTreeList1.UpdateMapingRow(rootNode[0], true);
                        }

                    }
                    */
                    #endregion
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acTreeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "PART_QTY"
                    || e.Column.FieldName == "ORD_QTY")
                {
                    DataRow tlRow = acTreeList1.GetFocusedDataRow();
                    if (tlRow.isNullOrEmpty()) { return; }

                    TreeListNode trNode = acTreeList1.FocusedNode;

                    SetChildQty(trNode);
                }
                else if (e.Column.FieldName == "SUM_QTY")
                {
                    DataRow tlRow = acTreeList1.GetFocusedDataRow();
                    if (tlRow.isNullOrEmpty()) { return; }

                    TreeListNode trNode = acTreeList1.FocusedNode;

                    SetSumChildQty(trNode);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void AcTreeList1_MouseDown(object sender, MouseEventArgs e)
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
                            //popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));
                        }
                    }
                }
            }
            catch { }
        }

        private void acTreeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {

            TreeListNode node = e.Node;

            if (e.Column.FieldName == "CHK_FLAG" || e.Column.FieldName == "PART_QTY") { return; }

            if (node["CHK_FLAG"].ToString() == "1")
            {
                e.Appearance.BackColor = Color.MediumAquamarine;
                e.Appearance.ForeColor = Color.Black;
            }

            if (node["DATA_FLAG"].ToString() == "2")
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }

        public override void DialogInitComplete()
        {

            if (!_dtEdited.isNullOrEmpty())
            {
                acTreeList1.DataSource = _dtEdited;

                acTreeList1.ExpandToLevel(1);
            }
            else
            {
                BomSearch();
            }

            base.DialogInitComplete();
        }


        void BomSearch()
        {

            if (_prodCode == null)
            {
                acTreeList1.ClearNodes();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("TYPE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = _prodCode;

            if (_isNew)
            {
                paramRow["TYPE"] = "1";
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "ORD02A_SER7", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);

        }

        void BomAllSearch()
        {

            if (_prodCode == null)
            {
                acTreeList1.ClearNodes();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = _prodCode;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "ORD02A_SER8", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);

        }


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                SetInitSumQty(e.result.Tables["RSLTDT_BOM"]);

                acTreeList1.DataSource = e.result.Tables["RSLTDT_BOM"];

                acTreeList1.ExpandToLevel(1);
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



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acTreeList1.isNullOrEmpty())
                {
                    return;
                }

                //DataView rsltView =  acTreeList1.GetDataView("[CHK_FLAG] = '1' ");

                acTreeList1.EndEditor();

                DataView rsltView = acTreeList1.GetDataView();

                base.OutputData = rsltView.ToTable(); ;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //노드삭제 
            //try
            //{
            //    DataRow tlRow = acTreeList1.GetFocusedDataRow();
                
            //    if (tlRow.isNullOrEmpty()) { return; }

            //    DataTable dtTree = acTreeList1.GetDataView().ToTable();
                
            //    DataRow[] rootNode = dtTree.Select("[P_PART_CODE] IS NULL");
            //    string rootPart = rootNode[0]["PART_CODE"].ToString();

            //    // 최상위 품목 삭제시
            //    if(tlRow["P_PART_CODE"].isNullOrEmpty()) 
            //    {
            //       foreach(DataRow row in dtTree.Rows)
            //       {
            //            row["DATA_FLAG"] = 2;
            //            acTreeList1.UpdateMapingRow(row, true);
            //       }
            //    }
            //    else
            //    {
            //        if(tlRow["P_PART_CODE"].ToString() == rootPart) 
            //        {
            //            // 자식노드가 없는 경우
            //            if (dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").Length == 0)
            //            {
            //                tlRow["DATA_FLAG"] = 2;
            //                acTreeList1.UpdateMapingRow(tlRow, true);
            //                return;
            //            }

            //            DataTable temp = dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").CopyToDataTable();
            //            temp.ImportRow(tlRow);

            //            foreach (DataRow row in temp.Rows)
            //            {
            //                row["DATA_FLAG"] = 2;
            //                acTreeList1.UpdateMapingRow(row, true);
            //            }
            //        }
            //    }

            //    tlRow["DATA_FLAG"] = 2;

            //    acTreeList1.UpdateMapingRow(tlRow, true);

            //}
            //catch(Exception ex)
            //{
            //    acMessageBox.Show(this, ex);
            //}
        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 노드복원 

            //try
            //{
            //    DataRow tlRow = acTreeList1.GetFocusedDataRow();

            //    if (tlRow.isNullOrEmpty()) { return; }

            //    DataTable dtTree = acTreeList1.GetDataView().ToTable();

            //    DataRow[] parentRow = dtTree.Select("[PART_CODE] = '" + tlRow["P_PART_CODE"].ToString() + "'");

            //    DataRow[] rootNode = dtTree.Select("[P_PART_CODE] IS NULL");
            //    string rootPart = rootNode[0]["PART_CODE"].ToString();

            //    // 최상위 품목 복원
            //    if (tlRow["P_PART_CODE"].isNullOrEmpty())
            //    {
            //        foreach (DataRow row in dtTree.Rows)
            //        {
            //            row["DATA_FLAG"] = 0;
            //            acTreeList1.UpdateMapingRow(row, true);
            //        }
            //    }
            //    else
            //    {
            //        if (tlRow["P_PART_CODE"].ToString() == rootPart)
            //        {
            //            if(rootNode[0]["DATA_FLAG"].ToString() == "2")
            //            {
            //                if (acMessageBox.Show("상위 품목이 삭제된 상태입니다. 복원하시겠습니까?", "BOM 편집기", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            //                { return;
            //                }
            //                else
            //                {
            //                    rootNode[0]["DATA_FLAG"] = 0;
            //                    acTreeList1.UpdateMapingRow(rootNode[0], true);

            //                }
            //            }

            //            // 자식노드가 없는 경우
            //            if (dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").Length == 0)
            //            {
            //                tlRow["DATA_FLAG"] = 0;
            //                acTreeList1.UpdateMapingRow(tlRow, true);
            //                return;
            //            }

            //            DataTable temp = dtTree.Select("[P_PART_CODE] = '" + tlRow["PART_CODE"].ToString() + "'").CopyToDataTable();
            //            temp.ImportRow(tlRow);

            //            foreach (DataRow row in temp.Rows)
            //            {
            //                row["DATA_FLAG"] = 0;
            //                acTreeList1.UpdateMapingRow(row, true);
            //            }
            //        }
            //    }

            //    if(parentRow.Length > 0)
            //    {
            //        if (parentRow[0]["DATA_FLAG"].ToString() == "2")
            //        {
            //            if (acMessageBox.Show("상위 품목이 삭제된 상태입니다. 복원하시겠습니까?", "BOM 편집기", acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            //            {
            //                return;
            //            }
            //            else
            //            {
            //                DataTable temp = dtTree.NewRow().NewTable();
            //                temp.Rows.Clear();
            //                temp.ImportRow(rootNode[0]);
            //                temp.ImportRow(parentRow[0]);

            //                foreach (DataRow row in temp.Rows)
            //                {
            //                    row["DATA_FLAG"] = 0;
            //                    acTreeList1.UpdateMapingRow(row, true);
            //                }
            //            }
            //        }
            //    }
               

            //    tlRow["DATA_FLAG"] = 0;

            //    acTreeList1.UpdateMapingRow(tlRow, true);

            //}
            //catch (Exception ex)
            //{
            //    acMessageBox.Show(this, ex);
            //}

        }


        void SetInitSumQty(DataTable dt)
        {

            /*
            _linkRow["PROD_QTY"] : 제작수량
            _prodType
              - 1 : 제품
              - 2 : 반제품
              - 3 : 파트
            */
            double prodQty = _linkRow["PROD_QTY"].toDouble();

            foreach (DataRow row in dt.Rows)
            {
                double partQty = row["PART_QTY"].toDouble();
                double o_qty = 1;
                double sum_o_qty = 1;

                double ordQty = 1;
                double sum_ordQty = 1;

                string find_o_ptid = "";
                string find_ptid = "";

                find_o_ptid = row["O_PT_ID"].ToString();
                find_ptid = row["PT_ID"].ToString();

                DataRow[] childRows = dt.Select("O_PT_ID = '" + find_ptid + "'");

                if (childRows.Length > 0)
                {
                    row["SUM_QTY"] = DBNull.Value;
                    continue;
                }

                int idx = 0;

                while (true)
                {
                    if (find_o_ptid == "")
                    {
                        break;
                    }

                    DataRow[] rows = dt.Select("PT_ID = '" + find_o_ptid + "'");

                    if (rows.Length > 0)
                    {
                        o_qty = rows[0]["PART_QTY"].toDouble();

                        ordQty = rows[0]["ORD_QTY"].toDouble();

                        if (ordQty > 0)
                        {
                            o_qty = o_qty * ordQty;
                        }

                        sum_o_qty = sum_o_qty * o_qty;

                        sum_ordQty = sum_ordQty * ordQty;

                        find_o_ptid = rows[0]["O_PT_ID"].ToString();

                    }

                    if (idx > 10)
                    {
                        break;
                    }

                    idx++;
                }


                if (_prodType == "2")
                {
                    sum_o_qty = 1;
                }
                else if (_prodType == "3")
                {
                    sum_o_qty = 1;
                    partQty = 1;
                }

                double newProdQty = prodQty;

                if (row["ORD_QTY"].toDouble() > 0)
                {
                    newProdQty = row["ORD_QTY"].toDouble();
                }

                row["SUM_QTY"] = (partQty * sum_o_qty * newProdQty).toInt();
                //dataRow["O_PART_QTY"] = sum_o_qty;
            }
        }


        void SetChildQty(TreeListNode node)
        {
            if (node.HasChildren)
            {
                foreach (TreeListNode n in node.Nodes)
                {
                    SetChildQty(n);
                }
            }
            else
            {
                SetSumQty(node);
            }
        }

        void SetSumQty(TreeListNode node)
        {
            double prodQty = _linkRow["PROD_QTY"].toDouble();

            double partQty = node["PART_QTY"].toDouble();

            int idx = 0;
            TreeListNode n = node.ParentNode;

            if (n != null)
            {
                double o_qty = 1;
                double sum_o_qty = 1;

                double ordQty = 1;

                while (true)
                {

                    o_qty = n["PART_QTY"].toDouble();
                    ordQty = n["ORD_QTY"].toDouble();

                    if (ordQty > 0)
                    {
                        o_qty = o_qty * ordQty;
                    }

                    sum_o_qty = sum_o_qty * o_qty;

                    if (n.ParentNode == null)
                    {
                        break;
                    }

                    n = n.ParentNode;


                    if (idx == 10)
                    {
                        break;
                    }

                    idx++;
                }

                if (_prodType == "2")
                {
                    sum_o_qty = 1;
                }
                else if (_prodType == "3")
                {
                    sum_o_qty = 1;
                    partQty = 1;
                }

                double newProdQty = prodQty;

                if (node["ORD_QTY"].toDouble() > 0)
                {
                    newProdQty = node["ORD_QTY"].toDouble();
                }

                node["SUM_QTY"] = (partQty * sum_o_qty * newProdQty).toInt();
            }
        }



        void SetSumChildQty(TreeListNode node)
        {
            if (node.HasChildren)
            {
                foreach (TreeListNode n in node.Nodes)
                {
                    SetSumChildQty(n);
                }
            }
            else
            {
                SetOrdQty(node);
            }
        }

        void SetOrdQty(TreeListNode node)
        {
            double prodQty = _linkRow["PROD_QTY"].toDouble();

            double partQty = node["PART_QTY"].toDouble();

            int idx = 0;
            TreeListNode n = node.ParentNode;

            if (n != null)
            {
                double o_qty = 1;
                double sum_o_qty = 1;

                double ordQty = 1;

                while (true)
                {

                    o_qty = n["PART_QTY"].toDouble();
                    ordQty = n["ORD_QTY"].toDouble();

                    if (ordQty > 0)
                    {
                        o_qty = o_qty * ordQty;
                    }

                    sum_o_qty = sum_o_qty * o_qty;

                    if (n.ParentNode == null)
                    {
                        break;
                    }

                    n = n.ParentNode;


                    if (idx == 10)
                    {
                        break;
                    }

                    idx++;
                }

                if (_prodType == "2")
                {
                    sum_o_qty = 1;
                }
                else if (_prodType == "3")
                {
                    sum_o_qty = 1;
                    partQty = 1;
                }

                double newProdQty = prodQty;

                //if (node["ORD_QTY"].toDouble() > 0)
                //{
                //    newProdQty = node["ORD_QTY"].toDouble();
                //}

                //node["SUM_QTY"] = (partQty * sum_o_qty * newProdQty).toInt();

                double tmpQty = node["SUM_QTY"].toDouble() / (partQty.toDouble() * sum_o_qty.toDouble()).toDouble();



                node["ORD_QTY"] = tmpQty;
            }
        }
    }
}

