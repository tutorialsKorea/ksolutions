using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using ControlManager;
using BizManager;

namespace TOL
{
    public partial class TOL05A_M0A : BaseMenu
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

        public TOL05A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.GetEditor("SYEAR").Value = DateTime.Now;

            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acGridView1.CustomDrawCell += AcGridView1_CustomDrawCell;

            acGridView1.CellMerge += AcGridView1_CellMerge;
        }

        private void AcGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if(e.Column.FieldName.Contains("LOT"))
                {
                    e.Appearance.BackColor = Color.LightCyan;
                }
            }
            catch
            {

            }
        }

        private void AcGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                acGridView view = sender as acGridView;

                if (view == null) return;

                DataRow row1 = view.GetDataRow(e.RowHandle1);
                DataRow row2 = view.GetDataRow(e.RowHandle2);

                if (row1["TL_CODE"].ToString().Equals(row2["TL_CODE"])
                    && e.CellValue1.ToString().Equals(e.CellValue2.ToString()))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }

                e.Handled = true;
            }
            catch
            {

            }
        }

        public override void MenuInit()
        {
            base.MenuInit();

            acGridView1.AddTextEdit("TL_CODE", "공구코드", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_NAME", "공구명", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("EVENT_DATE", "일자", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("GIVE_LOT", "지급 LOT", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "지급 설비명", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("GCOMMENT", "지급 비고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("RETURN_LOT", "반납 LOT", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("RCOMMENT", "반납 비고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DISUSE_LOT", "폐기 LOT", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("DCOMMENT", "폐기 비고", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.OptionsView.AllowCellMerge = true;

            acGridView1.Columns["TL_CODE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["TL_NAME"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            acGridView1.Columns["EVENT_DATE"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
        }

        public override void ChildContainerInit(Control sender)
        {
            base.ChildContainerInit(sender);
        }

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
                return;

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("YEAR", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["YEAR"] = layoutRow["SYEAR"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "TOL05A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dsltM = e.result.Tables["RSLTDT_M"];
                DataTable dsltG = e.result.Tables["RSLTDT_GIVE"];
                DataTable dsltR = e.result.Tables["RSLTDT_RETURN"];
                DataTable dsltD = e.result.Tables["RSLTDT_DISUSE"];

                DataTable dtG = dsltM.AsEnumerable()
                                .Join(
                                    dsltG.AsEnumerable()
                                    , m => new { PLT_CODE = m["PLT_CODE"], TL_LOT = m["TL_CODE"], EVENT_TIME = m["EVENT_DATE"] }
                                    , g => new { PLT_CODE = g["PLT_CODE"], TL_LOT = g["TL_CODE"], EVENT_TIME = g["GIVE_DATE"] }
                                    , (m, g) => new { M = m, GIVE = g })
                                .Select(r => new
                                {
                                    PLT_CODE = r.M["PLT_CODE"],
                                    TL_CODE = r.M["TL_CODE"],
                                    TL_NAME = r.M["TL_NAME"],
                                    EVENT_DATE = r.M["EVENT_DATE"],
                                    MC_NAME = r.GIVE["MC_NAME"],
                                    GIVE_LOT = r.GIVE["TL_LOT"],
                                    GCOMMENT = r.GIVE["SCOMMENT"]
                                })
                                //.GroupJoin(
                                //    dsltR.AsEnumerable()
                                //    , m => new { PLT_CODE = m.PLT_CODE, TL_CODE = m.TL_CODE, EVENT_TIME = m.EVENT_DATE }
                                //    , re => new { PLT_CODE = re["PLT_CODE"], TL_CODE = re["TL_CODE"], EVENT_TIME = re["RTN_DATE"] }
                                //    , (m, re) => new { M = m, RE = re.DefaultIfEmpty() })
                                //.SelectMany(r => r.RE.Select(re => new
                                //{
                                //    PLT_CODE = r.M.PLT_CODE,
                                //    TL_CODE = r.M.TL_CODE,
                                //    TL_NAME = r.M.TL_NAME,
                                //    EVENT_DATE = r.M.EVENT_DATE,
                                //    GIVE_LOT = r.M.GIVE_LOT,
                                //    RETURN_LOT = re?["TL_LOT"]
                                //}))
                                //.GroupJoin(
                                //    dsltD.AsEnumerable()
                                //    , m => new { PLT_CODE = m.PLT_CODE, TL_CODE = m.TL_CODE, EVENT_TIME = m.EVENT_DATE }
                                //    , d => new { PLT_CODE = d["PLT_CODE"], TL_CODE = d["TL_CODE"], EVENT_TIME = d["TDU_DATE"] }
                                //    , (m, d) => new { M = m, DISUSE = d.DefaultIfEmpty() })
                                //.SelectMany(r => r.DISUSE.Select(d => new
                                //{
                                //    PLT_CODE = r.M.PLT_CODE,
                                //    TL_CODE = r.M.TL_CODE,
                                //    TL_NAME = r.M.TL_NAME,
                                //    EVENT_DATE = r.M.EVENT_DATE,
                                //    GIVE_LOT = r.M.GIVE_LOT,
                                //    RETURN_LOT = r.M.RETURN_LOT,
                                //    DISUSE_LOT = d?["TL_LOT"]
                                //}))
                                .OrderBy(o => o.TL_NAME)
                                .ThenBy(t => t.EVENT_DATE)
                                .LINQToDataTable();

                DataTable dtR = dsltM.AsEnumerable()
                                       .Join(
                                           dsltR.AsEnumerable()
                                           , m => new { PLT_CODE = m["PLT_CODE"], TL_LOT = m["TL_CODE"], EVENT_TIME = m["EVENT_DATE"] }
                                           , re => new { PLT_CODE = re["PLT_CODE"], TL_LOT = re["TL_CODE"], EVENT_TIME = re["RTN_DATE"] }
                                           , (m, re) => new { M = m, RE = re })
                                       .Select(r => new
                                       {
                                           PLT_CODE = r.M["PLT_CODE"],
                                           TL_CODE = r.M["TL_CODE"],
                                           TL_NAME = r.M["TL_NAME"],
                                           EVENT_DATE = r.M["EVENT_DATE"],
                                           RETURN_LOT = r.RE["TL_LOT"],
                                           RCOMMENT = r.RE["SCOMMENT"]
                                       })
                                       .OrderBy(o => o.TL_NAME)
                                       .ThenBy(t => t.EVENT_DATE)
                                       .LINQToDataTable();

                DataTable dtD = dsltM.AsEnumerable()
                                      .Join(
                                          dsltD.AsEnumerable()
                                          , m => new { PLT_CODE = m["PLT_CODE"], TL_LOT = m["TL_CODE"], EVENT_TIME = m["EVENT_DATE"] }
                                          , d => new { PLT_CODE = d["PLT_CODE"], TL_LOT = d["TL_CODE"], EVENT_TIME = d["TDU_DATE"] }
                                          , (m, d) => new { M = m, DISUSE = d })
                                      .Select(r => new
                                      {
                                          PLT_CODE = r.M["PLT_CODE"],
                                          TL_CODE = r.M["TL_CODE"],
                                          TL_NAME = r.M["TL_NAME"],
                                          EVENT_DATE = r.M["EVENT_DATE"],
                                          DISUSE_LOT = r.DISUSE["TL_LOT"],
                                          DCOMMENT = r.DISUSE["SCOMMENT"]
                                      })
                                      .OrderBy(o => o.TL_NAME)
                                      .ThenBy(t => t.EVENT_DATE)
                                      .LINQToDataTable();

                DataTable inputTable = acGridView1.NewTable();

                foreach(DataRow mRow in dsltM.Rows)
                {
                    int index = 0;
                    bool bCompleteG = false;
                    bool bCompleteR = false;
                    bool bCompleteD = false;

                    DataRow[] rowG = null;
                    if(dtG.Rows.Count > 0) rowG = dtG.Select("TL_CODE='" + mRow["TL_CODE"] + "' AND EVENT_DATE='" + mRow["EVENT_DATE"] + "'");
                    DataRow[] rowR = null;
                    if (dtR.Rows.Count > 0) rowR = dtR.Select("TL_CODE='" + mRow["TL_CODE"] + "' AND EVENT_DATE='" + mRow["EVENT_DATE"] + "'");
                    DataRow[] rowD = null;
                    if (dtD.Rows.Count > 0) rowD = dtD.Select("TL_CODE='" + mRow["TL_CODE"] + "' AND EVENT_DATE='" + mRow["EVENT_DATE"] + "'");

                    while (!bCompleteG || !bCompleteR || !bCompleteD)
                    {
                        DataRow inputRow = inputTable.NewRow();
                        inputRow["TL_CODE"] = mRow["TL_CODE"];
                        inputRow["TL_NAME"] = mRow["TL_NAME"];
                        inputRow["EVENT_DATE"] = mRow["EVENT_DATE"].toDateTime();

                        if(rowG != null && rowG.Length > index)
                        {
                            inputRow["GIVE_LOT"] = rowG[index]["GIVE_LOT"];
                            inputRow["MC_NAME"] = rowG[index]["MC_NAME"];
                            inputRow["GCOMMENT"] = rowG[index]["GCOMMENT"];
                        }
                        if (rowR != null && rowR.Length > index)
                        {
                            inputRow["RETURN_LOT"] = rowR[index]["RETURN_LOT"];
                            inputRow["RCOMMENT"] = rowR[index]["RCOMMENT"];
                        }
                        if (rowD != null && rowD.Length > index)
                        {
                            inputRow["DISUSE_LOT"] = rowD[index]["DISUSE_LOT"];
                            inputRow["DCOMMENT"] = rowD[index]["DCOMMENT"];
                        }

                        inputTable.Rows.Add(inputRow);

                        index++;

                        if (rowG == null || (rowG != null && rowG.Length<= index))
                        {
                            bCompleteG = true;
                        }
                        if (rowR == null || (rowR != null && rowR.Length <= index))
                        {
                            bCompleteR = true;
                        }
                        if (rowD == null || (rowD != null && rowD.Length <= index))
                        {
                            bCompleteD = true;
                        }
                    }
                }
                acGridView1.GridControl.DataSource = inputTable;
                base.SetLog(e.executeType, e.result.Tables["RSLTDT_M"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

    }
}
