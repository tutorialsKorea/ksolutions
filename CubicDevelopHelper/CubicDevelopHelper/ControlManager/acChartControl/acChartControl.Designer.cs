namespace ControlManager
{
    partial class acChartControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chartControl1 = new ChartControlEx();
            this.acBarManager1 = new ControlManager.acBarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.acBarButtonItem2 = new ControlManager.acBarButtonItem();
            this.acBarSubItem1 = new ControlManager.acBarSubItem();
            this.acBarButtonItem3 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem4 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem5 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem6 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem7 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem1 = new ControlManager.acBarButtonItem();
            this.acBarSubItem3 = new ControlManager.acBarSubItem();
            this.acBarButtonItem9 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem10 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem11 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem12 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem13 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem14 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem15 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem16 = new ControlManager.acBarButtonItem();
            this.acBarButtonItem8 = new ControlManager.acBarButtonItem();
            this.acBarSubItem4 = new ControlManager.acBarSubItem();
            this.acBarButtonItem17 = new ControlManager.acBarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(558, 397);
            this.toolTipController1.SetSuperTip(this.chartControl1, null);
            this.chartControl1.TabIndex = 0;
            // 
            // acBarManager1
            // 
            this.acBarManager1.AllowCustomization = false;
            this.acBarManager1.AllowQuickCustomization = false;
            this.acBarManager1.AllowShowToolbarsPopup = false;
            this.acBarManager1.CloseButtonAffectAllTabs = false;
            this.acBarManager1.DockControls.Add(this.barDockControlTop);
            this.acBarManager1.DockControls.Add(this.barDockControlBottom);
            this.acBarManager1.DockControls.Add(this.barDockControlLeft);
            this.acBarManager1.DockControls.Add(this.barDockControlRight);
            this.acBarManager1.Form = this;
            this.acBarManager1.IsLoadDefaultLayout = true;
            this.acBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.acBarButtonItem2,
            this.acBarSubItem1,
            this.acBarButtonItem3,
            this.acBarButtonItem4,
            this.acBarButtonItem5,
            this.acBarButtonItem6,
            this.acBarButtonItem7,
            this.acBarButtonItem1,
            this.acBarSubItem3,
            this.acBarButtonItem9,
            this.acBarButtonItem10,
            this.acBarButtonItem11,
            this.acBarButtonItem12,
            this.acBarButtonItem13,
            this.acBarButtonItem14,
            this.acBarButtonItem15,
            this.acBarButtonItem16,
            this.acBarButtonItem8,
            this.acBarSubItem4,
            this.acBarButtonItem17});
            this.acBarManager1.MaxItemId = 33;
            // 
            // barDockControlTop
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlTop, null);
            // 
            // barDockControlBottom
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlBottom, null);
            // 
            // barDockControlLeft
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlLeft, null);
            // 
            // barDockControlRight
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlRight, null);
            // 
            // acBarButtonItem2
            // 
            this.acBarButtonItem2.Caption = "스타일 상자";
            this.acBarButtonItem2.Glyph = global::ControlManager.Resource.applications_graphics;
            this.acBarButtonItem2.Id = 1;
            this.acBarButtonItem2.Name = "acBarButtonItem2";
            this.acBarButtonItem2.ResourceID = "6T0ZDDPE";
            this.acBarButtonItem2.ToolTipID = null;
            this.acBarButtonItem2.UseResourceID = true;
            this.acBarButtonItem2.UseToolTipID = false;
            this.acBarButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem2_ItemClick);
            // 
            // acBarSubItem1
            // 
            this.acBarSubItem1.Caption = "파일로 저장";
            this.acBarSubItem1.Glyph = global::ControlManager.Resource.document_save;
            this.acBarSubItem1.Id = 3;
            this.acBarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem7)});
            this.acBarSubItem1.Name = "acBarSubItem1";
            this.acBarSubItem1.ResourceID = "LVJVBFZF";
            this.acBarSubItem1.ToolTipID = null;
            this.acBarSubItem1.UseResourceID = true;
            this.acBarSubItem1.UseToolTipID = false;
            // 
            // acBarButtonItem3
            // 
            this.acBarButtonItem3.Caption = "웹문서 (html)";
            this.acBarButtonItem3.Glyph = global::ControlManager.Resource.html;
            this.acBarButtonItem3.Id = 4;
            this.acBarButtonItem3.Name = "acBarButtonItem3";
            this.acBarButtonItem3.ResourceID = "JD5SEGA7";
            this.acBarButtonItem3.ToolTipID = null;
            this.acBarButtonItem3.UseResourceID = true;
            this.acBarButtonItem3.UseToolTipID = false;
            this.acBarButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem3_ItemClick);
            // 
            // acBarButtonItem4
            // 
            this.acBarButtonItem4.Caption = "이미지";
            this.acBarButtonItem4.Glyph = global::ControlManager.Resource.thumbnail_x16;
            this.acBarButtonItem4.Id = 5;
            this.acBarButtonItem4.Name = "acBarButtonItem4";
            this.acBarButtonItem4.ResourceID = "E9NYS432";
            this.acBarButtonItem4.ToolTipID = null;
            this.acBarButtonItem4.UseResourceID = true;
            this.acBarButtonItem4.UseToolTipID = false;
            this.acBarButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem4_ItemClick);
            // 
            // acBarButtonItem5
            // 
            this.acBarButtonItem5.Caption = "웹페이지 보관파일 (mht)";
            this.acBarButtonItem5.Glyph = global::ControlManager.Resource.templates;
            this.acBarButtonItem5.Id = 6;
            this.acBarButtonItem5.Name = "acBarButtonItem5";
            this.acBarButtonItem5.ResourceID = "BWPMBX6C";
            this.acBarButtonItem5.ToolTipID = null;
            this.acBarButtonItem5.UseResourceID = true;
            this.acBarButtonItem5.UseToolTipID = false;
            this.acBarButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem5_ItemClick);
            // 
            // acBarButtonItem6
            // 
            this.acBarButtonItem6.Caption = "Adobe Acrobat PDF";
            this.acBarButtonItem6.Glyph = global::ControlManager.Resource.pdf;
            this.acBarButtonItem6.Id = 7;
            this.acBarButtonItem6.Name = "acBarButtonItem6";
            this.acBarButtonItem6.ResourceID = "FWSGOLL9";
            this.acBarButtonItem6.ToolTipID = null;
            this.acBarButtonItem6.UseResourceID = true;
            this.acBarButtonItem6.UseToolTipID = false;
            this.acBarButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem6_ItemClick);
            // 
            // acBarButtonItem7
            // 
            this.acBarButtonItem7.Caption = "Microsoft Excel";
            this.acBarButtonItem7.Glyph = global::ControlManager.Resource.doc_excel_table_x16;
            this.acBarButtonItem7.Id = 8;
            this.acBarButtonItem7.Name = "acBarButtonItem7";
            this.acBarButtonItem7.ResourceID = "GQ52W2AQ";
            this.acBarButtonItem7.ToolTipID = null;
            this.acBarButtonItem7.UseResourceID = true;
            this.acBarButtonItem7.UseToolTipID = false;
            this.acBarButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem7_ItemClick);
            // 
            // acBarButtonItem1
            // 
            this.acBarButtonItem1.Caption = "인쇄";
            this.acBarButtonItem1.Glyph = global::ControlManager.Resource.document_print_x16;
            this.acBarButtonItem1.Id = 11;
            this.acBarButtonItem1.Name = "acBarButtonItem1";
            this.acBarButtonItem1.ResourceID = "4HOA9EHQ";
            this.acBarButtonItem1.ToolTipID = null;
            this.acBarButtonItem1.UseResourceID = true;
            this.acBarButtonItem1.UseToolTipID = false;
            this.acBarButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem1_ItemClick);
            // 
            // acBarSubItem3
            // 
            this.acBarSubItem3.Caption = "사용자 UI";
            this.acBarSubItem3.Glyph = global::ControlManager.Resource.color_swatchx_16;
            this.acBarSubItem3.Id = 13;
            this.acBarSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem11),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem12),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem13),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem14),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem15)});
            this.acBarSubItem3.Name = "acBarSubItem3";
            this.acBarSubItem3.ResourceID = "MVDNG5SB";
            this.acBarSubItem3.ToolTipID = null;
            this.acBarSubItem3.UseResourceID = true;
            this.acBarSubItem3.UseToolTipID = false;
            // 
            // acBarButtonItem9
            // 
            this.acBarButtonItem9.Glyph = global::ControlManager.Resource.appointment;
            this.acBarButtonItem9.Id = 14;
            this.acBarButtonItem9.Name = "acBarButtonItem9";
            this.acBarButtonItem9.ResourceID = null;
            this.acBarButtonItem9.ToolTipID = null;
            this.acBarButtonItem9.UseResourceID = false;
            this.acBarButtonItem9.UseToolTipID = false;
            // 
            // acBarButtonItem10
            // 
            this.acBarButtonItem10.Caption = "불러오기";
            this.acBarButtonItem10.Glyph = global::ControlManager.Resource.document_open;
            this.acBarButtonItem10.Id = 15;
            this.acBarButtonItem10.Name = "acBarButtonItem10";
            this.acBarButtonItem10.ResourceID = "VO8OYFRA";
            this.acBarButtonItem10.ToolTipID = null;
            this.acBarButtonItem10.UseResourceID = true;
            this.acBarButtonItem10.UseToolTipID = false;
            this.acBarButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem10_ItemClick);
            // 
            // acBarButtonItem11
            // 
            this.acBarButtonItem11.Caption = "저장";
            this.acBarButtonItem11.Glyph = global::ControlManager.Resource.document_save;
            this.acBarButtonItem11.Id = 16;
            this.acBarButtonItem11.Name = "acBarButtonItem11";
            this.acBarButtonItem11.ResourceID = "7NKYXFU5";
            this.acBarButtonItem11.ToolTipID = null;
            this.acBarButtonItem11.UseResourceID = true;
            this.acBarButtonItem11.UseToolTipID = false;
            this.acBarButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem11_ItemClick);
            // 
            // acBarButtonItem12
            // 
            this.acBarButtonItem12.Caption = "다른이름으로 저장";
            this.acBarButtonItem12.Glyph = global::ControlManager.Resource.document_save_as;
            this.acBarButtonItem12.Id = 17;
            this.acBarButtonItem12.Name = "acBarButtonItem12";
            this.acBarButtonItem12.ResourceID = "Q8JXEI9K";
            this.acBarButtonItem12.ToolTipID = null;
            this.acBarButtonItem12.UseResourceID = true;
            this.acBarButtonItem12.UseToolTipID = false;
            this.acBarButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem12_ItemClick);
            // 
            // acBarButtonItem13
            // 
            this.acBarButtonItem13.Caption = "현재 사용자 UI을 기본으로 설정";
            this.acBarButtonItem13.Glyph = global::ControlManager.Resource.table_refresh_x16;
            this.acBarButtonItem13.Id = 18;
            this.acBarButtonItem13.Name = "acBarButtonItem13";
            this.acBarButtonItem13.ResourceID = "K913LULF";
            this.acBarButtonItem13.ToolTipID = null;
            this.acBarButtonItem13.UseResourceID = true;
            this.acBarButtonItem13.UseToolTipID = false;
            this.acBarButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem13_ItemClick);
            // 
            // acBarButtonItem14
            // 
            this.acBarButtonItem14.Caption = "시스템 UI으로 초기화";
            this.acBarButtonItem14.Glyph = global::ControlManager.Resource.layout_x16;
            this.acBarButtonItem14.Id = 19;
            this.acBarButtonItem14.Name = "acBarButtonItem14";
            this.acBarButtonItem14.ResourceID = "7Z7GBDQ6";
            this.acBarButtonItem14.ToolTipID = null;
            this.acBarButtonItem14.UseResourceID = true;
            this.acBarButtonItem14.UseToolTipID = false;
            this.acBarButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem14_ItemClick);
            // 
            // acBarButtonItem15
            // 
            this.acBarButtonItem15.Caption = "관리";
            this.acBarButtonItem15.Glyph = global::ControlManager.Resource.edit_find_replace_x16;
            this.acBarButtonItem15.Id = 20;
            this.acBarButtonItem15.Name = "acBarButtonItem15";
            this.acBarButtonItem15.ResourceID = "0FNNF1ZT";
            this.acBarButtonItem15.ToolTipID = null;
            this.acBarButtonItem15.UseResourceID = true;
            this.acBarButtonItem15.UseToolTipID = false;
            this.acBarButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem15_ItemClick);
            // 
            // acBarButtonItem16
            // 
            this.acBarButtonItem16.Caption = "도움말";
            this.acBarButtonItem16.Glyph = global::ControlManager.Resource.help_browser_x16;
            this.acBarButtonItem16.Id = 28;
            this.acBarButtonItem16.Name = "acBarButtonItem16";
            this.acBarButtonItem16.ResourceID = "TGFJ3JK4";
            this.acBarButtonItem16.ToolTipID = null;
            this.acBarButtonItem16.UseResourceID = true;
            this.acBarButtonItem16.UseToolTipID = false;
            this.acBarButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem16_ItemClick);
            // 
            // acBarButtonItem8
            // 
            this.acBarButtonItem8.Caption = "범례 편집기";
            this.acBarButtonItem8.Glyph = global::ControlManager.Resource.tooloptions;
            this.acBarButtonItem8.Id = 30;
            this.acBarButtonItem8.Name = "acBarButtonItem8";
            this.acBarButtonItem8.ResourceID = "Z2TF2L6A";
            this.acBarButtonItem8.ToolTipID = null;
            this.acBarButtonItem8.UseResourceID = true;
            this.acBarButtonItem8.UseToolTipID = false;
            this.acBarButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem8_ItemClick);
            // 
            // acBarSubItem4
            // 
            this.acBarSubItem4.Caption = "기능";
            this.acBarSubItem4.Glyph = global::ControlManager.Resource.wand_x16;
            this.acBarSubItem4.Id = 31;
            this.acBarSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem17)});
            this.acBarSubItem4.Name = "acBarSubItem4";
            this.acBarSubItem4.ResourceID = "QS1MTC9B";
            this.acBarSubItem4.ToolTipID = null;
            this.acBarSubItem4.UseResourceID = true;
            this.acBarSubItem4.UseToolTipID = false;
            // 
            // acBarButtonItem17
            // 
            this.acBarButtonItem17.Caption = "전체화면으로 보기";
            this.acBarButtonItem17.Glyph = global::ControlManager.Resource.screen_x16;
            this.acBarButtonItem17.Id = 32;
            this.acBarButtonItem17.Name = "acBarButtonItem17";
            this.acBarButtonItem17.ResourceID = "YDTQ9QA2";
            this.acBarButtonItem17.ToolTipID = null;
            this.acBarButtonItem17.UseResourceID = true;
            this.acBarButtonItem17.UseToolTipID = false;
            this.acBarButtonItem17.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.acBarButtonItem17_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.acBarButtonItem16, true)});
            this.popupMenu1.Manager = this.acBarManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // toolTipController1
            // 
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // acChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "acChartControl";
            this.Size = new System.Drawing.Size(558, 397);
            this.toolTipController1.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private acBarManager acBarManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private acBarButtonItem acBarButtonItem2;
        private acBarSubItem acBarSubItem1;
        private acBarButtonItem acBarButtonItem3;
        private acBarButtonItem acBarButtonItem4;
        private acBarButtonItem acBarButtonItem5;
        private acBarButtonItem acBarButtonItem6;
        private acBarButtonItem acBarButtonItem7;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private acBarButtonItem acBarButtonItem1;
        private acBarSubItem acBarSubItem3;
        private acBarButtonItem acBarButtonItem9;
        private acBarButtonItem acBarButtonItem10;
        private acBarButtonItem acBarButtonItem11;
        private acBarButtonItem acBarButtonItem12;
        private acBarButtonItem acBarButtonItem13;
        private acBarButtonItem acBarButtonItem14;
        private acBarButtonItem acBarButtonItem15;
        private acBarButtonItem acBarButtonItem16;
        private acBarButtonItem acBarButtonItem8;
        private acBarSubItem acBarSubItem4;
        private acBarButtonItem acBarButtonItem17;
        internal ChartControlEx chartControl1;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
