using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Colors;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;


namespace SYS
{
    public sealed partial class SYS12B_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }




        public SYS12B_M0A()
        {
            InitializeComponent();
        }


        private string[] _KeyColumn = new string[] { };

        public string[] KeyColumn
        {
            get { return _KeyColumn; }
            set { _KeyColumn = value; }
        }



        void SYS12B_M0A_Load(object sender, EventArgs e)
        {
            this.Search();
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

            }

        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {


                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;


            }


            base.ChildContainerInit(sender);
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;



            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {

                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }

        //public override void MenuNotify(object data)
        //{
        //    DataRow row = data as DataRow;

        //    DataTable paramTable = new DataTable("RQSTDT");
        //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //    paramTable.Columns.Add("BOARD_ID", typeof(String)); //


        //    DataRow paramRow = paramTable.NewRow();
        //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //    if(row != null) paramRow["BOARD_ID"] = row["SEARCH_KEY"];

        //    paramTable.Rows.Add(paramRow);
        //    DataSet paramSet = new DataSet();
        //    paramSet.Tables.Add(paramTable);

        //    //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS12A_SER", paramSet, "RQSTDT", "RSLTDT",
        //    //    QuickSearch,
        //    //    QuickException);


        //    DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "SYS12A_SER", paramSet, "RQSTDT", "RSLTDT");

        //    DataTable titleDt = dsResult.Tables["RSLTDT"].Copy();
        //    contentsDt = dsResult.Tables["RSLTDT"].Copy();

        //    contentsDt.TableName = "D";

        //    DataSet plans = new DataSet();

        //    plans.Tables.Add(titleDt);
        //    plans.Tables.Add(contentsDt);

        //    DataColumn keyColumn = titleDt.Columns["BOARD_ID"];
        //    DataColumn foreignKeyColumn = contentsDt.Columns["BOARD_ID"];

        //    plans.Relations.Add("M", keyColumn, foreignKeyColumn);

        //    base.MenuNotify(data);
        //}



        public override void MenuInit()
        {

            base.MenuInit();

            toggleSwitch1.IsOn = false;

            UpdateColors();

            //acTileView1.AddLookUpEdit("ACC_LEVEL", "공개형태", "0S83T0JI", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S010");
            //acTileView1.AddTextEdit("TITLE", "제목", "W4WOVWG8", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acTileView.emTextEditMask.NONE);
            //acTileView1.AddTextEdit("REG_EMP", "등록자코드", "W91VQNT4", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acTileView.emTextEditMask.NONE);
            //acTileView1.AddTextEdit("REG_EMP_NAME", "등록자", "608I87JD", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acTileView.emTextEditMask.NONE);
            //acTileView1.AddDateEdit("REG_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acTileView.emDateMask.LONG_DATE);
            //acTileView1.AddHidden("BOARD_ID", typeof(String));

            TileView1.MouseDown += TileView1_MouseDown;
            TileView1.ColumnSet.GroupColumn = TileView1.Columns["REG_DATE"];
            TileView1.FocusedRowChanged += TileView1_FocusedRowChanged;
            TileView1.ItemCustomize += TileView1_ItemCustomize;


            KeyColumn = new string[] {"BOARD_ID"};

            acCheckedComboBoxEdit1.AddItem("등록일", true, "CZP2OQ22", "REG_DATE", true, false);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.Load += SYS12B_M0A_Load;
        }

     
        private void TileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            try
            {
                e.Item["TITLE"].Appearance.Normal.ForeColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Primary, LookAndFeel);
            }catch{

            }
        }

        private void TileView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    string accLevel = TileView1.GetFocusedRowCellDisplayText("ACC_LEVEL");
                    string title = TileView1.GetFocusedRowCellValue("TITLE").toStringEmpty();
                    string contents = TileView1.GetFocusedRowCellValue("CONTENTS").toStringEmpty();
                    string boardId = TileView1.GetFocusedRowCellValue("BOARD_ID").toStringEmpty();
                    board1.SetValues(boardId, accLevel, title, contents);

                }
               
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }



        public override void MenuInitComplete()
        {
            
            base.MenuInitComplete();
            
            AddLookUpEdit(TileView1.Columns["ACC_LEVEL"], "S011");
        }



        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VIEW_EMP", typeof(String)); //

            paramTable.Columns.Add("TITLE_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_DATE", typeof(String)); //
            paramTable.Columns.Add("E_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VIEW_EMP"] = acInfo.UserID;

            paramRow["TITLE_LIKE"] = layoutRow["TITLE_LIKE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":

                        //등록일
                        paramRow["S_DATE"] = ((DateTime)layoutRow["S_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        paramRow["E_DATE"] = ((DateTime)layoutRow["E_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet(); 
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS12A_SER", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);
            
        }


        private void TileView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                TileViewHitInfo hitInfo = TileView1.CalcHitInfo(e.Location);


                if (hitInfo.HitTest == TileControlHitTest.Item) // item == Row
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                TileViewHitInfo hitInfo = TileView1.CalcHitInfo(e.Location);

                if (hitInfo.RowHandle >= 0)
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                if (hitInfo.HitTest == TileControlHitTest.Item || hitInfo.HitTest == TileControlHitTest.Control)
                {

                    popupMenu1.ShowPopup(TileView1.GridControl.PointToScreen(e.Location));

                }
            }
        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

       
        private DataTable contentsDt = null;

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    e.result.Tables["RSLTDT_REPLY"].Columns.Add("REPLY", typeof(Bitmap));

                    for (int i = 0; i < e.result.Tables["RSLTDT_REPLY"].Rows.Count; i++)
                    {

                        e.result.Tables["RSLTDT_REPLY"].Rows[i]["REPLY"] = Resource.edit_redo2_1x;

                    }

                    DataTable titleDt = e.result.Tables["RSLTDT"].Copy();
                    contentsDt = e.result.Tables["RSLTDT_REPLY"].Copy();

                    contentsDt.TableName = "D";

                    DataSet plans = new DataSet();

                    plans.Tables.Add(titleDt);
                    plans.Tables.Add(contentsDt);

                    DataColumn keyColumn = titleDt.Columns["BOARD_ID"];
                    DataColumn foreignKeyColumn = contentsDt.Columns["LINK_ID"];

                    if (keyColumn != null && foreignKeyColumn != null)
                    {
                        plans.Relations.Add("M", keyColumn, foreignKeyColumn);
                    }

                    TileView1.GridControl.DataSource = plans.Tables[0];


                    // acGridView1.SetOldFocusRowHandle(false);
                }
                else
                {
                    acLayoutControl2.ClearValue();
                }


                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override bool MenuDestory(object sender)
        {
            return base.MenuDestory(sender);
        }

        public override void MenuGotFocus()
        {
            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {
            base.MenuLostFocus();
        }




        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 열기
            try
            {
                DataRow focusRow = TileView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["BOARD_ID"]))
                {

                    SYS12A_D0A frm = new SYS12A_D0A(TileView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["BOARD_ID"], frm);


                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["BOARD_ID"]);

                }
            }
                catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제

            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("BOARD_ID", typeof(String)); //

                DataRow focusRow = TileView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["BOARD_ID"] = focusRow["BOARD_ID"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS12A_DEL", paramSet, "RQSTDT", "",
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

                //링크된 자식창 삭제
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.DeleteMapingRow(TileView1, row, _KeyColumn);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 게시판 편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS12A_D0A frm = new SYS12A_D0A(TileView1, null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;

                    frm.ParentControl = this;

                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);

                }
                else
                {

                    base.ChildFormFocus("NEW");
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        public void AddLookUpEdit(GridColumn column, string catCode)
        {

            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();


            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();


            displayColumnInfo.FieldName = "CD_NAME";
            displayColumnInfo.Caption = "CD_NAME";

            valueColumnInfo.FieldName = "CD_CODE";
            valueColumnInfo.Caption = "CD_CODE";

            valueColumnInfo.Visible = false;

            lookupEdit.NullText = string.Empty;
            lookupEdit.ShowHeader = false;
            lookupEdit.ShowFooter = true;

            lookupEdit.Columns.Add(displayColumnInfo);
            lookupEdit.Columns.Add(valueColumnInfo);



            lookupEdit.DataSource = acInfo.StdCodes.GetCatTable(catCode);


            lookupEdit.DisplayMember = "CD_NAME";

            lookupEdit.ValueMember = "CD_CODE";

            lookupEdit.DataSource = acInfo.StdCodes.GetCatTable(catCode);

            column.ColumnEdit = lookupEdit;

        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            var contentText = TileView1.TileTemplate[3];
            if (toggleSwitch1.IsOn)
            {
                TileView1.TileRows[0].AutoHeight = true;
                TileView1.TileRows[1].AutoHeight = true;
                TileView1.TileRows[2].AutoHeight = true;
                contentText.Appearance.Normal.TextOptions.WordWrap = WordWrap.Wrap;
            }
            else
            {
                TileView1.TileRows[0].AutoHeight = false;
                TileView1.TileRows[1].AutoHeight = false;
                TileView1.TileRows[2].AutoHeight = false;
                contentText.Appearance.Normal.TextOptions.WordWrap = WordWrap.NoWrap;
            }
        }

        void UpdateColors()
        {
            Color UnreadTextColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Primary, LookAndFeel);
            this.TileView1.Appearance.GroupText.ForeColor = UnreadTextColor;
            this.TileView1.Appearance.ItemFocused.BackColor = Color.FromArgb(40, UnreadTextColor);
            this.TileView1.Appearance.ItemHovered.BackColor = Color.FromArgb(40, UnreadTextColor);
        }



        void DeleteMapingRow(TileView tw, DataRow row, string[] _KeyColumns)
        {
            try
            {
                DataTable dt = tw.GridControl.DataSource as DataTable;
                if (dt == null) { return; }

                bool isFindRow = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    foreach (string keyColumn in _KeyColumns)
                    {
                        if (row.Table.Columns.Contains(keyColumn))
                        {

                            if (dt.Rows[i][keyColumn].ToString() == row[keyColumn].ToString())
                            {
                                //키컬럼 일치시 제거

                                dt.Rows.RemoveAt(i);

                                isFindRow = true;

                            }
                        }
                    }
                }
                if (isFindRow == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //댓글달기 

            try
            {

                DataRow focusRow =TileView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["BOARD_ID"]))
                {

                    SYS12A_D1A frm = new SYS12A_D1A(TileView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["BOARD_ID"], frm);

                    //frm.Show(this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Search();
                    }

                }
                else
                {

                    base.ChildFormFocus(focusRow["BOARD_ID"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}
