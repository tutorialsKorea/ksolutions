using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using static ControlManager.acGridView;

namespace HIS
{
    public sealed partial class HIS04B_M0A : BaseMenu
    {
        DateTime _Now;

        Color _ActColor = Color.LightGray;
        Color _PlanColor = Color.Aqua;
        Color _BeforeSevenColor = Color.LightYellow;
        Color _TodayColor = Color.FromArgb(186, 132, 72);
        Color _DelayColor = Color.OrangeRed;

        HashSet<string> _DicStock;

        RepositoryItemDateEdit _Edit;
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

        public HIS04B_M0A()
        {
            InitializeComponent();

            DateTime now  = DateTime.Now;
            _Now = new DateTime(now.Year, now.Month, now.Day);

            _Edit = new RepositoryItemDateEdit();
            _Edit.ContextImage = Resource.sign_error_1x;
            _Edit.Mask.EditMask = "yyyy-MM-dd";

            _DicStock = new HashSet<string>();

            acGridView1.ClearColumns();

            acGridView1.OptionsView.ShowIndicator = false;
            acGridView1.ColumnPanelRowHeight = 45;
            acGridView1.Appearance.HeaderPanel.Font = new Font(acGridView1.Appearance.HeaderPanel.Font.FontFamily, 12F, FontStyle.Bold);

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;
            acGridView1.CustomRowCellEdit += AcGridView1_CustomRowCellEdit;
            acGridView1.RowCellClick += AcGridView1_RowCellClick;
        }

        private void AcGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    if (e.CellValue.isNullOrEmpty()) return;

                    acGridView view = sender as acGridView;
                    if (view == null) return;

                    DataRow selRow = view.GetDataRow(e.RowHandle);
                    if (selRow == null) return;

                    //날짜 컬럼
                    if(e.Column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
                    {
                        DataSet paramSet = new DataSet();

                        DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("MTN_CODE", typeof(String));
                        paramTable.Columns.Add("MC_CODE", typeof(String));
                        paramTable.Columns.Add("PLN_DATE", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["MTN_CODE"] = selRow["MTN_CODE"];
                        paramRow["MC_CODE"] = e.Column.FieldName;
                        paramRow["PLN_DATE"] = e.CellValue.toDateString("yyyyMMdd");
                        paramTable.Rows.Add(paramRow);

                        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS04A_SER3", paramSet, "RQSTDT", "RSLTDT", QuickSearchPlan, QuickException);
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchPlan(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                    DataRow row = e.result.Tables["RSLTDT"].Rows[0];

                    if (!base.ChildFormContains(row["MC_CODE"]))
                    {
                        HIS03A_D1A frm = new HIS03A_D1A(null, row);
                        frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                        frm.ParentControl = this;
                        base.ChildFormAdd(row["MC_CODE"], frm);
                        frm.ShowDialog(this);
                        
                        Search();
                    }
                    else
                    {
                        base.ChildFormFocus(row["MC_CODE"]);
                    }
                }
            }
            catch { 
            }
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                DataRow row = acGridView1.GetDataRow(e.RowHandle);

                if (row == null) return;

                if (e.CellValue.isNullOrEmpty()) return;

                string actColName = e.Column.FieldName + "_ACT";
                //실적 컬럼이 존재하면 계획 컬럼
                if (acGridView1.Columns.ColumnByFieldName(actColName) != null)
                {
                    if (row[actColName].isNullOrEmpty() == false)
                    {
                        //보전 실적 등록 완료
                        e.Appearance.BackColor = _ActColor;
                    }
                    else
                    {
                        DateTime cellDate = e.CellValue.toDateTime();
                        if (_Now.AddDays(7) >= cellDate
                            && _Now < cellDate)
                        {
                            //계획일 7일전
                            e.Appearance.BackColor = _BeforeSevenColor;
                        }
                        else if (_Now == cellDate)
                        {
                            //계획일 당일
                            e.Appearance.BackColor = _TodayColor;
                        }
                        else if (_Now > cellDate
                                    && row[actColName].isNullOrEmpty())
                        {
                            //계획일 < 현재일
                            //보전 실적이 없음
                            e.Appearance.BackColor = _DelayColor;
                        }
                        else if (_Now.AddDays(7) < cellDate)
                        {
                            e.Appearance.BackColor = _PlanColor;
                        }
                        else
                        {
                            e.Appearance.BackColor = _PlanColor;
                        }
                    }
                }

            }
            catch { }
        }

        private void AcGridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                DataRow row = acGridView1.GetDataRow(e.RowHandle);

                if (row != null)
                {
                    string key = e.Column.FieldName + ";" + row["MTN_CODE"].toStringEmpty();
                    if (_DicStock.Contains(key))
                    {
                        e.RepositoryItem = _Edit;
                    }
                }
            }
            catch { }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Search();
            }
        }

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;
            }

            base.ChildContainerInit(sender);
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

        public override void MenuInit()
        {
            try
            {

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();

            acGridView1.GridControl.RepositoryItems.Add(_Edit);

            acDateEdit1.EditValue = DateTime.Now;
            timer1.Interval = 60000;
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    acGridView1.ColumnPanelRowHeight = 50;
        //    acGridView1.Appearance.HeaderPanel.Font = new Font(acGridView1.Appearance.HeaderPanel.Font.FontFamily, 13F, FontStyle.Bold);
        //}

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
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["YEAR"];
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "HIS04A_SER2", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _DicStock = new HashSet<string>();

                #region 보전항목리스트 만들기
                acGridView1.ClearRow();
                acGridView1.ClearColumns();

                acGridView1.GridType = acGridView.emGridType.FIXED;
                acGridView1.AddTextEdit("MTN_CODE", "보전코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("MTN_NAME", "보전명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.Columns["MTN_NAME"].Width = 200;

                //타이틀바 생성
                foreach (DataRow title in e.result.Tables["RSLTDT_TITLE"].Rows)
                {
                    acGridView1.AddDateEdit(title["MC_CODE"].ToString(), title["MC_NAME"].ToString(), "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                    acGridView1.AddDateEdit(title["MC_CODE"].ToString()+"_ACT", title["MC_NAME"].ToString()+" 실적", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.SHORT_DATE2);
                    acGridView1.Columns[title["MC_CODE"].ToString()].Width = 150;
                }

                acGridView1.KeyColumn = new[] { "MTN_CODE" };
                #endregion

                DataTable linqTable = acGridView1.DefaultTable.Clone();

                var varPlns = e.result.Tables["RSLTDT"].AsEnumerable()
                                        .GroupBy(g => new
                                        {
                                            PLT_CODE = g["PLT_CODE"],
                                            MTN_CODE = g["MTN_CODE"],
                                            MTN_NAME = g["MTN_NAME"]
                                        })
                                        .Select(r => new
                                        {
                                            PLT_CODE = r.Key.PLT_CODE,
                                            MTN_CODE = r.Key.MTN_CODE,
                                            MTN_NAME = r.Key.MTN_NAME,
                                            PLN_DATE_LIST = r.ToList<DataRow>()
                                        });
                foreach (var varPln in varPlns)
                {
                    DataRow linqRow = linqTable.NewRow();
                    linqRow["MTN_CODE"] = varPln.MTN_CODE;
                    linqRow["MTN_NAME"] = varPln.MTN_NAME;
                    
                    foreach(DataRow rowPln in varPln.PLN_DATE_LIST)
                    {
                        string mcCode = rowPln["MC_CODE"].ToString();

                        if (mcCode.isNullOrEmpty())
                            continue;

                        linqRow[mcCode] = rowPln["PLN_DATE"].toDateTimeDBNull();
                        linqRow[mcCode + "_ACT"] = rowPln["ACT_DATE"].toDateTimeDBNull();

                        if(rowPln["IS_NOT_ENOUGH"].Equals(1) //재고 부족한것이 존재한다
                            &&_DicStock.Contains(mcCode + ";"+varPln.MTN_CODE) == false)
                        {
                            _DicStock.Add(mcCode + ";" + varPln.MTN_CODE);
                        }
                    }
                    linqTable.Rows.Add(linqRow);
                }
                acGridView1.GridControl.DataSource = linqTable;

                acGridView1.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            finally
            {
                if (timer1.Enabled == false)
                {
                    timer1.Start();
                }
            }
        }
        
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);


            if (timer1.Enabled == false)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkAuto.Checked)
            {
                this.timer1.Stop();
                this.Search();
            }
        }

        private void checkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAuto.Checked)
            {
                if (timer1.Enabled == false)
                {
                    timer1.Start();
                }
            }
        }
    }
}
