namespace SYS
{
    partial class SYS77A_M0A
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acTreeList1 = new ControlManager.acTreeList();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.bar2 = new ControlManager.acBar();
            this.barItemSearch = new ControlManager.acBarButtonItem();
            this.barItemSave = new ControlManager.acBarButtonItem();
            this.bar3 = new ControlManager.acBar();
            this.statusBarLog = new ControlManager.acBarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemAddNode = new ControlManager.acBarButtonItem();
            this.barItemDelNode = new ControlManager.acBarButtonItem();
            this.barItemCutNode = new ControlManager.acBarButtonItem();
            this.barItemPasteNode = new ControlManager.acBarButtonItem();
            this.acBarSubItem1 = new ControlManager.acBarSubItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).BeginInit();
            this.pnlScreenBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScreenBase
            // 
            this.pnlScreenBase.Controls.Add(this.acTreeList1);
            this.pnlScreenBase.Location = new System.Drawing.Point(0, 36);
            this.pnlScreenBase.Size = new System.Drawing.Size(848, 527);
            // 
            // acTreeList1
            // 
            this.acTreeList1.ColumnPanelRowHeight = 30;
            this.acTreeList1.DataSource = null;
            this.acTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acTreeList1.Location = new System.Drawing.Point(0, 0);
            this.acTreeList1.Name = "acTreeList1";
            this.acTreeList1.OptionsSelection.MultiSelect = true;
            this.acTreeList1.OptionsView.AutoWidth = false;
            this.acTreeList1.ParentControl = this;
            this.acTreeList1.RowHeight = 30;
            this.acTreeList1.SaveFileName = null;
            this.acTreeList1.Size = new System.Drawing.Size(848, 527);
            this.acTreeList1.TabIndex = 4;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemSearch,
            this.barItemSave,
            this.statusBarLog,
            this.barItemAddNode,
            this.barItemDelNode,
            this.barItemCutNode,
            this.barItemPasteNode,
            this.acBarSubItem1,
            this.acBarButtonItem1});
            this.acBarManager1.MainMenu = this.bar2;
            this.acBarManager1.MaxItemId = 16;
            this.acBarManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarItemHorzIndent = 10;
            this.bar2.BarItemVertIndent = 5;
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(282, 119);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.ResourceID = "I7LE433K";
            this.bar2.Text = "도구상자";
            this.bar2.ToolTipID = null;
            this.bar2.UseResourceID = true;
            this.bar2.UseToolTipID = false;
            // 
            // barItemSearch
            // 
            this.barItemSearch.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SEARCH;
            this.barItemSearch.Caption = "조회";
            this.barItemSearch.Id = 0;
            this.barItemSearch.ImageOptions.Image = global::SYS.Resource.system_search_2x;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.ResourceID = null;
            this.barItemSearch.ToolTipID = "1UMVQFSB";
            this.barItemSearch.UseResourceID = false;
            this.barItemSearch.UseToolTipID = true;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemSave
            // 
            this.barItemSave.ButtonShortCutType = ControlManager.acBarManager.emBarShortCutType.SAVE;
            this.barItemSave.Caption = "저장";
            this.barItemSave.Id = 1;
            this.barItemSave.ImageOptions.Image = global::SYS.Resource.document_save_2x;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.ResourceID = null;
            this.barItemSave.ToolTipID = "4UY7EZBZ";
            this.barItemSave.UseResourceID = false;
            this.barItemSave.UseToolTipID = true;
            this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarItemHorzIndent = 10;
            this.bar3.BarItemVertIndent = 5;
            this.bar3.BarName = "Custom 3";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.statusBarLog, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.ResourceID = "11ZRFWQB";
            this.bar3.Text = "Custom 3";
            this.bar3.ToolTipID = null;
            this.bar3.UseResourceID = true;
            this.bar3.UseToolTipID = false;
            // 
            // statusBarLog
            // 
            this.statusBarLog.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusBarLog.Id = 4;
            this.statusBarLog.ImageOptions.Image = global::SYS.Resource.internet_group_chat_1x;
            this.statusBarLog.Name = "statusBarLog";
            this.statusBarLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarLog.ResourceID = null;
            this.statusBarLog.ToolTipID = "FMNREB3B";
            this.statusBarLog.UseResourceID = false;
            this.statusBarLog.UseToolTipID = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.acBarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(848, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 563);
            this.barDockControlBottom.Manager = this.acBarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(848, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Manager = this.acBarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 527);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(848, 36);
            this.barDockControlRight.Manager = this.acBarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 527);
            // 
            // barItemAddNode
            // 
            this.barItemAddNode.Caption = "자식노드";
            this.barItemAddNode.Id = 7;
            this.barItemAddNode.Name = "barItemAddNode";
            this.barItemAddNode.ResourceID = "4UEI07ZL";
            this.barItemAddNode.ToolTipID = null;
            this.barItemAddNode.UseResourceID = true;
            this.barItemAddNode.UseToolTipID = false;
            this.barItemAddNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAddNode_ItemClick);
            // 
            // barItemDelNode
            // 
            this.barItemDelNode.Caption = "삭제";
            this.barItemDelNode.Id = 8;
            this.barItemDelNode.ImageOptions.Image = global::SYS.Resource.edit_delete_2x;
            this.barItemDelNode.Name = "barItemDelNode";
            this.barItemDelNode.ResourceID = "Y1JCF012";
            this.barItemDelNode.ToolTipID = null;
            this.barItemDelNode.UseResourceID = true;
            this.barItemDelNode.UseToolTipID = false;
            this.barItemDelNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelNode_ItemClick);
            // 
            // barItemCutNode
            // 
            this.barItemCutNode.Caption = "잘라내기";
            this.barItemCutNode.Id = 9;
            this.barItemCutNode.ImageOptions.Image = global::SYS.Resource.edit_cut_1x;
            this.barItemCutNode.Name = "barItemCutNode";
            this.barItemCutNode.ResourceID = "ZNU5L4DG";
            this.barItemCutNode.ToolTipID = null;
            this.barItemCutNode.UseResourceID = true;
            this.barItemCutNode.UseToolTipID = false;
            this.barItemCutNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemCutNode_ItemClick);
            // 
            // barItemPasteNode
            // 
            this.barItemPasteNode.Caption = "붙여넣기";
            this.barItemPasteNode.Id = 10;
            this.barItemPasteNode.ImageOptions.Image = global::SYS.Resource.edit_paste_1x;
            this.barItemPasteNode.Name = "barItemPasteNode";
            this.barItemPasteNode.ResourceID = "AX9R0IV1";
            this.barItemPasteNode.ToolTipID = null;
            this.barItemPasteNode.UseResourceID = true;
            this.barItemPasteNode.UseToolTipID = false;
            this.barItemPasteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPasteNode_ItemClick);
            // 
            // acBarSubItem1
            // 
            this.acBarSubItem1.Caption = "추가";
            this.acBarSubItem1.Id = 13;
            this.acBarSubItem1.ImageOptions.Image = global::SYS.Resource.document_new_2x;
            this.acBarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemAddNode, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.acBarSubItem1.Name = "acBarSubItem1";
            this.acBarSubItem1.ResourceID = "JBPV296G";
            this.acBarSubItem1.ToolTipID = null;
            this.acBarSubItem1.UseResourceID = true;
            this.acBarSubItem1.UseToolTipID = false;
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "노드";
            this.acBarButtonItem1.Id = 14;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = "C0KRJOAZ";
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = true;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemCutNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPasteNode)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // SYS77A_M0A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SYS77A_M0A";
            this.Size = new System.Drawing.Size(848, 593);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlScreenBase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlScreenBase)).EndInit();
            this.pnlScreenBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlManager.acTreeList acTreeList1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private ControlManager.acBarManager acBarManager1;
        private ControlManager.acBar bar2;
        

        private ControlManager.acBarButtonItem barItemSearch;
        private ControlManager.acBarButtonItem barItemSave;
        private ControlManager.acBar bar3;
        private ControlManager.acBarStaticItem statusBarLog;
        

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private ControlManager.acBarButtonItem barItemAddNode;
        private ControlManager.acBarButtonItem barItemDelNode;
        private ControlManager.acBarButtonItem barItemCutNode;
        private ControlManager.acBarButtonItem barItemPasteNode;
        
        
        private ControlManager.acBarSubItem acBarSubItem1;
        private ControlManager.acBarButtonItem acBarButtonItem1;
    }
}
