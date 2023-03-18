using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ControlManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS77A_M0A : BaseMenu
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

        public SYS77A_M0A()
        {
            InitializeComponent();

            acTreeList1.MouseDown += new MouseEventHandler(acTreeList1_MouseDown);

            acTreeList1.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(acTreeList1_CustomDrawNodeCell);

            acTreeList1.CellValueChanging += new CellValueChangedEventHandler(acTreeList1_CellValueChanging);

            acTreeList1.ChangeDataSource += new acTreeList.ChangeDatasourceEvenHandler(acTreeList1_ChangeDataSource);

            acTreeList1.PopupMenuShowing += acTreeList1_PopupMenuShowing;

            this.Load += SYS77A_M0A_Load;

        }

        private void acTreeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        void SYS77A_M0A_Load(object sender, EventArgs e)
        {
            this.Search();
        }





        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        void acTreeList1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            this.SetMenuWorking();

        }

        void acTreeList1_ChangeDataSource()
        {
            this.SetMenuWorking();
        }


        /// <summary>
        /// 수정중 상태 변경
        /// </summary>
        private void SetMenuWorking()
        {
            base.MenuStatus = emMenuStatus.WORK;

        }

        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {

            TreeListHitInfo hitInfo = acTreeList1.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right)
            {

                if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.RowIndicator)
                {

                    popupMenu1.ShowPopup(acTreeList1.PointToScreen(e.Location));

                }

            }


        }

        public override void MenuInit()
        {

            #region 컨트롤 설정

            barItemPasteNode.Enabled = false;

            acTreeList1.KeyFieldName = "MENU_CODE";
            acTreeList1.ParentFieldName = "MENU_PARENT";

            acTreeList1.AddPictrue("ICON", "아이콘", "XXQ7SLGS", true, DevExpress.Utils.HorzAlignment.Center, true, true);

            acTreeList1.AddTextEdit("MENU_CODE", "메뉴코드", "C8PZLBQT", true, DevExpress.Utils.HorzAlignment.Center, true, true, ControlManager.acTreeList.emTextEditMask.CODE);

            acTreeList1.AddHidden("O_MENU_CODE", typeof(string));

            acTreeList1.AddHidden("MENU_PARENT", typeof(string));

            acTreeList1.AddTextEdit("MENU_NAME", "메뉴명", "D6UJPZ3J", true, DevExpress.Utils.HorzAlignment.Center, true, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("MENU_SEQ", "메뉴순번", "9PEZ7B4M", true, DevExpress.Utils.HorzAlignment.Center, true, true, ControlManager.acTreeList.emTextEditMask.NUMBER);

            acTreeList1.AddHidden("RES_ID", typeof(string));

            acTreeList1.AddTextEdit("CLASSNAME", "클래스", "7BHPEKNS", true, DevExpress.Utils.HorzAlignment.Near, true, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList1.AddTextEdit("ASSEMBLY", "어셈블리", "A6SPCCOM", true, DevExpress.Utils.HorzAlignment.Center, true, true, ControlManager.acTreeList.emTextEditMask.NONE);

            acTreeList1.AddColorEdit("HEADER_COLOR", "탭 색상정보", "", false, DevExpress.Utils.HorzAlignment.Center, true, true);

            acTreeList1.AddCheckEdit("USE_FLAG", "사용여부", "UP426DTD", true, true, true, acTreeList.emCheckEditDataType._BYTE);

            //acTreeList1.AddCheckEdit("IS_SYS_MENU", "시스템 메뉴", "Z0EJ0VMX", true, true, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddCheckEdit("IS_STD_MENU", "Standard Edition", "1REGZ5YN", true, true, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddCheckEdit("IS_PRO_MENU", "Professional Edition", "SUFEFV49", true, true, true, acTreeList.emCheckEditDataType._BYTE);

            acTreeList1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, ControlManager.acTreeList.emTextEditMask.NONE);
             
            #endregion


            base.MenuInit();

        }

        public override void MenuInitComplete()
        {
            //this.Search();

            base.MenuInitComplete();
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }

        public override bool MenuDestory(object sender)
        {

            if (base.MenuStatus == emMenuStatus.WORK)
            {
                //수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?

                if (acMessageBox.Show(this, "수정하거나 작업중인 항목이 존재합니다. 정말 닫으시겠습니까?", "AEIR4MG6", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        void Search()
        {
            //조회

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, 
                "SYS77A_SER", 
                paramSet,
                "RQSTDT", "", QuickSearch, QuickException);

            //BizRun.QBizRun.ExecuteService(
            //this, QBiz.emExecuteType.LOAD,
            //"SYS77A_SER", paramSet, "RQSTDT", "RSLTDT",
            //QuickSearch,
            //QuickException);
        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.OVERWRITE ||
                ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Parent.Text, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
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


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                base.MenuStatus = emMenuStatus.NONE;


                acTreeList1.DataSource = e.result.Tables["RSLTDT"];

                acTreeList1.SetOldFocusNode();

                acTreeList1.BestFitColumns(true);


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 잘라낸 노드 데이터
        /// </summary>
        private Dictionary<TreeListNode, DataRow> _CutNodesData = new Dictionary<TreeListNode, DataRow>();


        private void barItemDelNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //노드 삭제
            try
            {
                acTreeList1.DeleteSelectedNodes();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private TreeListMultiSelection _CutNodeCollection = null;


        void acTreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            //if (_CutNodeCollection != null)
            //{
            //    if (_CutNodeCollection.Contains(e.Node))
            //    {
            //        e.Appearance.BackColor = Color.Beige;
            //    }
            //}

            if (nodeList.Count > 0)
            {
                if (nodeList.Contains(e.Node))
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
            }

        }

        List<TreeListNode> nodeList = new List<TreeListNode>();
        private void barItemCutNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //노드 잘라내기
            try
            {
                //_CutNodeCollection = new TreeListMultiSelection(acTreeList1);

                //foreach (TreeListNode node in acTreeList1.Selection)
                //{
                //    _CutNodeCollection.Add(node);
                //}


                nodeList.Clear();

                foreach (TreeListNode node in acTreeList1.Selection)
                {
                    nodeList.Add(node);
                }


                barItemPasteNode.Enabled = true;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemPasteNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //노드 붙여넣기
            try
            {
                foreach (TreeListNode node in nodeList)
                {
                    acTreeList1.MoveNode(node, acTreeList1.FocusedNode, true);
                }

                nodeList.Clear();

                //foreach (TreeListNode node in _CutNodeCollection)
                //{
                //    acTreeList1.MoveNode(node, acTreeList1.FocusedNode, true);
                //}


                //_CutNodeCollection.Clear();

                barItemPasteNode.Enabled = false;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                acTreeList1.CloseEditor();
                acTreeList1.EndCurrentEdit();


                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable1.Columns.Add("LANG", typeof(String)); //언어
                paramTable1.Columns.Add("RES_ID", typeof(String)); //리소스 GUID
                paramTable1.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable1.Columns.Add("MENU_NAME", typeof(String)); //
                paramTable1.Columns.Add("MENU_PARENT", typeof(String)); //
                paramTable1.Columns.Add("MENU_SEQ", typeof(Int32)); //
                paramTable1.Columns.Add("HEADER_COLOR", typeof(Int32)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("CLASSNAME", typeof(String)); //
                paramTable1.Columns.Add("ASSEMBLY", typeof(String)); //
                paramTable1.Columns.Add("ICON", typeof(Byte[])); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //등록자
                paramTable1.Columns.Add("USE_FLAG", typeof(byte));
                paramTable1.Columns.Add("IS_SYS_MENU", typeof(byte));
                paramTable1.Columns.Add("IS_STD_MENU", typeof(byte));
                paramTable1.Columns.Add("IS_PRO_MENU", typeof(byte));
                paramTable1.Columns.Add("O_MENU_CODE", typeof(String)); //

                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //등록자

                DataTable addModifyTable = acTreeList1.GetAddModifyRows();

                foreach (DataRow row in addModifyTable.Rows)
                {

                    DataRow paramRow1 = paramTable1.NewRow();

                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["LANG"] = acInfo.Lang;
                    paramRow1["RES_ID"] = row["RES_ID"];
                    paramRow1["MENU_CODE"] = row["MENU_CODE"];
                    paramRow1["MENU_NAME"] = row["MENU_NAME"];
                    paramRow1["O_MENU_CODE"] = row["O_MENU_CODE"];

                    if (row["MENU_PARENT"].Equals("0"))
                    {
                        paramRow1["MENU_PARENT"] = DBNull.Value;
                    }     
                    else
                    {
                        paramRow1["MENU_PARENT"] = row["MENU_PARENT"];
                    }

                    paramRow1["MENU_SEQ"] = row["MENU_SEQ"];
                    paramRow1["HEADER_COLOR"] = row["HEADER_COLOR"];
                    paramRow1["SCOMMENT"] = row["SCOMMENT"];
                    paramRow1["CLASSNAME"] = row["CLASSNAME"];
                    paramRow1["ASSEMBLY"] = row["ASSEMBLY"];
                    paramRow1["ICON"] = row["ICON"];
                    paramRow1["USE_FLAG"] = row["USE_FLAG"];
                    paramRow1["REG_EMP"] = acInfo.UserID;


                    paramRow1["IS_SYS_MENU"] = row["IS_SYS_MENU"];
                    paramRow1["IS_STD_MENU"] = row["IS_STD_MENU"];
                    paramRow1["IS_PRO_MENU"] = row["IS_PRO_MENU"];

                    paramRow1["OVERWRITE"] = "0";

                    paramTable1.Rows.Add(paramRow1);

                }

                DataTable paramTable2 = new DataTable("RQSTDT2");
                paramTable2.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
                paramTable2.Columns.Add("RES_LANG", typeof(String)); //언어
                paramTable2.Columns.Add("MENU_CODE", typeof(String)); //메뉴코드
                paramTable2.Columns.Add("RES_ID", typeof(String)); //리소스 GUID
                paramTable2.Columns.Add("DEL_EMP", typeof(String)); //삭제자


                DataTable delTable = acTreeList1.GetDeleteRows();


                foreach (DataRow row in delTable.Rows)
                {
                    DataRow paramRow2 = paramTable2.NewRow();

                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["RES_LANG"] = acInfo.Lang;
                    paramRow2["MENU_CODE"] = row["MENU_CODE"];
                    paramRow2["RES_ID"] = row["RES_ID"];
                    paramRow2["DEL_EMP"] = acInfo.UserID;

                    paramTable2.Rows.Add(paramRow2);

                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);


                BizRun.QBizRun.ExecuteService(this, 
                    QBiz.emExecuteType.SAVE,
                    "SYS77A_SAVE",
                    paramSet,
                    "RQSTDT,RQSTDT2", "", QuickSave, QuickException);


                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.SAVE,
                //"SYS77A_SAVE", paramSet, "RQSTDT,RQSTDT2", "",
                //QuickSave,
                //QuickException);

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

                int totCnt = e.result.Tables["RQSTDT"].Rows.Count + e.result.Tables["RQSTDT2"].Rows.Count;


                if (totCnt != 0)
                {
                    acTreeList1.AcceptChanges();

                    base.SetLog(e.executeType, totCnt, e.executeTime);
                }


                base.MenuStatus = emMenuStatus.NONE;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //도움말
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void barItemAddNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //자식 노드 추가
            try
            {
                DataRowView rowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);

                if (rowView != null)
                {

                    if (acChecker.isNull(rowView["MENU_CODE"]) == true)
                    {
                        return;
                    }


                    DataRow row = rowView.Row.Table.NewRow();


                    row["USE_FLAG"] = 1;
                    row["IS_SYS_MENU"] = 0;
                    row["IS_STD_MENU"] = 1;
                    row["IS_PRO_MENU"] = 1;


                    TreeListNode appendNode = acTreeList1.AppendNode(row, acTreeList1.FocusedNode);

                    acTreeList1.FocusedNode = appendNode;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //동일 레벨 노드 추가
            try
            {
                if (acTreeList1.FocusedNode == null)
                {
                    return;
                }

                DataRowView rowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode.ParentNode);

                if (rowView == null)
                {

                    DataView view = new DataView((DataTable)acTreeList1.DataSource);

                    rowView = view.AddNew();
                }


                DataRow row = rowView.Row.Table.NewRow();


                row["USE_FLAG"] = 1;
                row["IS_SYS_MENU"] = 0;
                row["IS_STD_MENU"] = 1;
                row["IS_PRO_MENU"] = 1;

                TreeListNode appendNode = acTreeList1.AppendNode(row, acTreeList1.FocusedNode.ParentNode);


                acTreeList1.FocusedNode = appendNode;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}