using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using ControlManager;
using BizManager;
using DevExpress.Utils;

namespace POP
{
    public sealed partial class ToolLog : BaseMenuDialog
    {

        //public override acBarManager BarManager
        //{
        //    get
        //    {
        //        return acBarManager1;
        //    }
        //}

        public override void BarCodeScanInput(string barcode)
        {


        }

     
        private string _LinkData = null;

        public string LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        public static string _strPOPfontName = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");


        public ToolLog(string linkData)
        {

            InitializeComponent();

            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }


            _LinkData = linkData;

            // _LinkView = linkView;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            
            acGridView1.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("STD_LIFE", "표준사용시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("ACT_TOOL_TIME", "사용시간(분)", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("MNT_POS", "장착위치", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddLookUpEdit("MNT_POS", "장착위치", "", false, HorzAlignment.Center, true, true, false, "T006");


            acGridView1.AddButtonEdit("LIFE_CLEAR", "사용시간 초기화", "", false, DevExpress.Utils.HorzAlignment.Center, DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor, true, true, false, POP.Resource.edit_clear_2x, DevExpress.LookAndFeel.SkinStyle.TheAsphaltWorld);
            
            acGridView1.Columns["LIFE_CLEAR"].ColumnEdit.Click += Clear_EditClick;

        

            acGridView1.AddHidden("MOUNT_ID", typeof(string));

            acGridView1.KeyColumn = new string[] { "MOUNT_ID" };

            acGridView1.SortInfo.Add(acGridView1.Columns["MNT_POS"], DevExpress.Data.ColumnSortOrder.Ascending);

            // acGridView1.OptionsView.ShowIndicator = true;

            acGridView1.OptionsView.ColumnAutoWidth = true;

            acGridView1.CellValueChanged += AcGridView1_CellValueChanged;

        }



        private void AcGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // 장착위치 업데이트
            try
            {
                DataRow focusdRow = acGridView1.GetFocusedDataRow();

                switch (e.Column.FieldName)
                {
                    case "MNT_POS" :

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTable.Columns.Add("MOUNT_ID", typeof(String)); //
                        paramTable.Columns.Add("MNT_POS", typeof(int)); //
                        paramTable.Columns.Add("USED_LIFE", typeof(int)); //

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MOUNT_ID"] = focusdRow["MOUNT_ID"];
                        paramRow["MNT_POS"] = focusdRow["MNT_POS"];
                        //paramRow["USED_LIFE"] = focusdRow["USED_LIFE"];

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(this, "POP04A_UPD3", paramSet, "RQSTDT", "RSLTDT");

                    break;

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override void DialogInit()
        {
            //barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //(acLayoutControl1.GetEditor("PM_GUBUN").Editor as acLookupEdit).SetCode("H002"); 

            acGridView1.RowHeight = 45;

            acGridView1.ColumnPanelRowHeight = 70;

            SetPopGridFont(acGridView1);


            base.DialogInit();

        }

        public override void DialogNew()
        {
           
        }

        public override void DialogOpen()
        {
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MC_CODE"] = _LinkData;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_SER7", paramSet, "RQSTDT", "RSLTDT",
                                QuickSearch,
                                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

      

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }



        private void Clear_EditClick(object sender, EventArgs e)
        {
            // 사용시간 초기화

            acGridView1.EndEditor();

            if (acMessageBox.Show(this, "사용시간을 초기화하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataRow focuseRow = acGridView1.GetFocusedDataRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("MC_CODE", typeof(String)); //
            paramTable.Columns.Add("MOUNT_ID", typeof(String)); //
            paramTable.Columns.Add("MNT_POS", typeof(int)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_CODE"] = this._LinkData;
            paramRow["MOUNT_ID"] = focuseRow["MOUNT_ID"]; 
            paramRow["MNT_POS"] = focuseRow["MNT_POS"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_UPD3", paramSet, "RQSTDT", "RSLTDT",
            QuickUpdate,
            QuickException);
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acGridView1.BestFitColumns();
                }
               
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        void QuickUpdate(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.UpdateMapingRow(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
             
            acMessageBox.Show(this, ex);
     
        }

       

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            // 공구추가

            PopTools frm = new PopTools(acGridView1, _LinkData);

            frm.DialogMode = BaseMenuDialog.emDialogMode.NONE;

            frm.ParentControl = this;

            frm.Show(this);

        }

        private void acSimpleButton3_Click(object sender, EventArgs e)
        {
            // 공구삭제

            try
            {
                acGridView1.EndEditor();


                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MOUNT_ID", typeof(String)); //


                if (selected.Count == 0)
                {
                    //단일삭제

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MOUNT_ID"] = focusRow["MOUNT_ID"];
                    paramTable.Rows.Add(paramRow);


                }
                else
                {

                    //다중삭제
                    for (int i = 0; i < selected.Count; i++)
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MOUNT_ID"] = selected[i]["MOUNT_ID"];
                        paramTable.Rows.Add(paramRow);

                    }


                }

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "POP04A_DEL", paramSet, "RQSTDT", "RSLTDT",
                QuickDEL,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static void SetPopGridFont(acGridView grid)
        {
            int fontSz = 3;

            if (grid != null)
            {

                Font fontBold = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz, FontStyle.Bold);
                Font font = new Font(_strPOPfontName, acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + fontSz);

                //grid.Appearance.Row.Font = font;

                //grid.Appearance.FocusedRow.Font = fontBold;
                //grid.Appearance.HideSelectionRow.Font = font;
                //grid.Appearance.HeaderPanel.Font = font;
                //grid.Appearance.GroupRow.Font = font;
                
                grid.OptionsSelection.EnableAppearanceFocusedRow = false;
                grid.OptionsSelection.EnableAppearanceFocusedCell = false;


                foreach (AppearanceObject ap in grid.Appearance)
                {
                    ap.Font = font;
                }

                if (grid.FormatConditions.Count > 0)
                {
                    for (int i = 0; i < grid.FormatConditions.Count; i++)
                    {
                        grid.FormatConditions[i].Appearance.Font = new Font(font.FontFamily, font.Size, grid.FormatConditions[i].Appearance.Font.Style);
                    }
                }
            }

        }

    }
}