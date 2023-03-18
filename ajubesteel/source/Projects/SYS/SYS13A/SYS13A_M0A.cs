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
    public sealed partial class SYS13A_M0A : BaseMenu
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

        private string[] _KeyColumn = new string[] { };

        public string[] KeyColumn
        {
            get { return _KeyColumn; }
            set { _KeyColumn = value; }
        }



        public SYS13A_M0A()
        {
            InitializeComponent();
        }


        void SYS13A_M0A_Load(object sender, EventArgs e)
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


        public override void MenuNotify(object data)
        {
            DataRow row = data as DataRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("UPD_ID", typeof(String)); //


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            if (row != null) paramRow["UPD_ID"] = row["SEARCH_KEY"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "SYS03A_SER", paramSet, "RQSTDT", "RSLTDT",
            //    QuickSearch,
            //    QuickException);


            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "SYS13A_SER", paramSet, "RQSTDT", "RSLTDT");

            DataTable titleDt = dsResult.Tables["RSLTDT"].Copy();
            contentsDt = dsResult.Tables["RSLTDT"].Copy();

            contentsDt.TableName = "D";

            DataSet plans = new DataSet();

            plans.Tables.Add(titleDt);
            plans.Tables.Add(contentsDt);

            DataColumn keyColumn = titleDt.Columns["UPD_ID"];
            DataColumn foreignKeyColumn = contentsDt.Columns["UPD_ID"];

            plans.Relations.Add("M", keyColumn, foreignKeyColumn);

            base.MenuNotify(data);
        }


        public override void MenuInit()
        {

            base.MenuInit();

            toggleSwitch1.IsOn = false;

            UpdateColors();

            //acGridView1.AddTextEdit("UPD_ID", "아이디", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("UPD_TITLE", "제목", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddMemoEdit("UPD_CONT", "업데이트 내역", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
            //acGridView1.AddTextEdit("UPD_VER", "Version 정보", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddDateEdit("UPD_DATE", "업데이트일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

            tileView1.ItemCustomize += TileView1_ItemCustomize;
            tileView1.FocusedRowChanged += TileView1_FocusedRowChanged;
            tileView1.MouseDown += TileView1_MouseDown;

            KeyColumn = new string[] { "UPD_ID" };

            acCheckedComboBoxEdit1.AddItem("등록일", true, "CZP2OQ22", "REG_DATE", true, false);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            this.Load += SYS13A_M0A_Load;
        }




        private void TileView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                TileViewHitInfo hitInfo = tileView1.CalcHitInfo(e.Location);


                if (hitInfo.HitTest == TileControlHitTest.Item) // item == Row
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                TileViewHitInfo hitInfo = tileView1.CalcHitInfo(e.Location);

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

                    popupMenu1.ShowPopup(tileView1.GridControl.PointToScreen(e.Location));

                }
            }
        }

        private void TileView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    string version = tileView1.GetFocusedRowCellDisplayText("UPD_VER");
                    string title = tileView1.GetFocusedRowCellValue("UPD_TITLE").toStringEmpty();
                    string contents = tileView1.GetFocusedRowCellValue("UPD_CONT").toStringEmpty();
                    string updId = tileView1.GetFocusedRowCellValue("UPD_ID").toStringEmpty();

                    update1.SetValues(title,version, contents);
                 
                }
               
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void TileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            try
            {
                e.Item["UPD_TITLE"].Appearance.Normal.ForeColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Primary, LookAndFeel);
            }catch{

            }
        }

        public override void MenuInitComplete()
        {
            
            base.MenuInitComplete();

           // AddLookUpEdit(tileView1.Columns["ACC_LEVEL"], "S010");
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

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VIEW_EMP", typeof(String)); //

            paramTable.Columns.Add("TITLE_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //

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
                        paramRow["S_REG_DATE"] = ((DateTime)layoutRow["S_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        paramRow["E_REG_DATE"] = ((DateTime)layoutRow["E_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet(); 
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "SYS13A_SER", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);
            
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

                DataTable titleDt = e.result.Tables["RSLTDT"].Copy();
              
                tileView1.GridControl.DataSource = titleDt;

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

                DataRow focusRow = tileView1.GetFocusedDataRow();


                if (focusRow == null)
                {
                    return;
                }

                if (!base.ChildFormContains(focusRow["UPD_ID"]))
                {

                    SYS13A_D0A frm = new SYS13A_D0A(tileView1, focusRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(focusRow["UPD_ID"], frm);


                    frm.Show(this);
                }
                else
                {

                    base.ChildFormFocus(focusRow["UPD_ID"]);

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
                paramTable.Columns.Add("UPD_ID", typeof(String)); //

                DataRow focusRow = tileView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["UPD_ID"] = focusRow["UPD_ID"];
                paramTable.Rows.Add(paramRow);

                #region SEL
                //DataView selectedView = acGridView1.GetDataSourceView("SEL ='1'");

                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("NOTICE_ID", typeof(String)); //

                //if (selectedView.Count == 0)
                //{
                //    //단일
                //    DataRow focusRow = acGridView1.GetFocusedDataRow();

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["DEL_EMP"] = acInfo.UserID;
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["NOTICE_ID"] = focusRow["NOTICE_ID"];
                //    paramTable.Rows.Add(paramRow);
                //}
                //else
                //{
                //    //다중
                //    for (int i = 0; selectedView.Count > i; i++)
                //    {
                //        DataRow paramRow = paramTable.NewRow();
                //        paramRow["DEL_EMP"] = acInfo.UserID;
                //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //        paramRow["NOTICE_ID"] = selectedView[i]["NOTICE_ID"];
                //        paramTable.Rows.Add(paramRow);
                //    }

                //}
                #endregion

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                        "SYS13A_DEL", paramSet, "RQSTDT", "",
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
                    this.DeleteMapingRow(tileView1, row, _KeyColumn);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

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



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }



        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            var contentText = tileView1.TileTemplate[3];
            if (toggleSwitch1.IsOn)
            {
                tileView1.TileRows[0].AutoHeight = true;
                tileView1.TileRows[1].AutoHeight = true;
                tileView1.TileRows[2].AutoHeight = true;
                contentText.Appearance.Normal.TextOptions.WordWrap = WordWrap.Wrap;
            }
            else
            {
                tileView1.TileRows[0].AutoHeight = false;
                tileView1.TileRows[1].AutoHeight = false;
                tileView1.TileRows[2].AutoHeight = false;
                contentText.Appearance.Normal.TextOptions.WordWrap = WordWrap.NoWrap;
            }
        }

        void UpdateColors()
        {
            Color UnreadTextColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Primary, LookAndFeel);
            this.tileView1.Appearance.GroupText.ForeColor = UnreadTextColor;
            this.tileView1.Appearance.ItemFocused.BackColor = Color.FromArgb(40, UnreadTextColor);
            this.tileView1.Appearance.ItemHovered.BackColor = Color.FromArgb(40, UnreadTextColor);
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //새로만들기 공지사항편집기
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    SYS13A_D0A frm = new SYS13A_D0A(tileView1, null);

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
    }
}
