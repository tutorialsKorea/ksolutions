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

namespace PLN
{
    public sealed partial class PLN17A_M0A : BaseMenu
    {
        private Color _WAIT;
        private Color _RUN;
        private Color _PAUSE;
        private Color _FINISH;
        private DataTable _ProdPartProcTable;

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

        public PLN17A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

            acBandGridView1.CustomDrawCell += AcBandGridView1_CustomDrawCell;

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();
        }

        private void AcBandGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if(e.Column is acBandedGridColumn bCol)
                {
                    if(!bCol.OwnerBand.Caption.Equals(bCol.Caption))
                    {
                        DataRow thisRow = acBandGridView1.GetDataRow(e.RowHandle);

                        DataRow partProc = _ProdPartProcTable.Select("PROD_CODE='"+ thisRow["PROD_CODE"] 
                                                                + "' AND PART_CODE = '" + thisRow["PART_CODE"] 
                                                                + "' AND PROC_CODE = '"+bCol.FieldName+"'").FirstOrDefault();
                        
                        if (partProc == null)
                            return;

                        switch(partProc["WO_FLAG"])
                        {
                            case "0":
                                e.Appearance.BackColor = Color.LightGray;   // Color.YellowGreen;
                                break;
                            case "1":
                                e.Appearance.BackColor = _WAIT;//Color.LightGray;
                                break;
                            case "2":
                                e.Appearance.BackColor = _RUN;//Color.SkyBlue;
                                break;
                            case "3":
                                e.Appearance.BackColor = _PAUSE; //Color.Purple;
                                break;
                            case "4":
                                e.Appearance.BackColor = _FINISH;   //Color.Orange;
                                break;
                            case "03":
                                e.Appearance.BackColor = Color.LightGray;
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
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
                //acBandGridView1.GridType = acBandGridView.emGridType.SEARCH;
                acBandGridView1.AddTextEdit("ITEM_CODE", "수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("ITEM_NAME", "프로젝트", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("CVND_NAME", "수주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");
                acBandGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddLookUpEdit("PROD_STATE", "제품상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S025");
                acBandGridView1.AddDateEdit("ORD_DATE", "수주일", "40902", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE);
                acBandGridView1.AddDateEdit("DUE_DATE", "출하예정일", "40111", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE);
                acBandGridView1.AddDateEdit("SALECONFM_DATE", "매출 확정일", "50295", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.SHORT_DATE);
                acBandGridView1.AddTextEdit("MAT_SPEC1", "제품사양", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("PROD_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.TIME);
                acBandGridView1.AddLookUpEdit("MAT_UNIT", "단위", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acBandGridView1.AddTextEdit("PROGRESS", "진척률(%)", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.QTY);


                acBandGridView1.Columns["ITEM_CODE"].Group();

                acCheckedComboBoxEdit1.AddItem("수주일", true, "40902", "ORD_DATE", true, false);

                #region 조립공정

                DataSet paramDS = new DataSet();

                DataTable paramTable = paramDS.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramTable.Rows.Add(paramRow);


                if (BizRun.QBizRun.ExecuteService(this, "PLN17A_SER1", paramDS, "RQSTDT", "RSLTDT") is DataSet resultDS)
                {
                    foreach(DataRow row in resultDS.Tables["RSLTDT"].Rows)
                    {
                        string procName = "";
                        foreach (char procChar in row["PROC_NAME"].ToString())
                        {
                            procName += procChar + Environment.NewLine;
                        }
                        acBandGridView1.AddTextEdit(row["PROC_CODE"].ToString(), procName, "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE, row["PRG_NAME"].ToString());
                    }
                }

                #endregion

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
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

            //DataTable paramTable = new DataTable("RQSTDT");
            //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
            //paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
            //paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
            //paramTable.Columns.Add("PROD_STATE", typeof(String)); //

            //DataRow paramRow = paramTable.NewRow();
            //paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];
            ////paramRow["PROD_STATE"] = "WK,PG,SH";
            //paramRow["PROD_STATE"] = "WK,PG";

            //foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            //{
            //    switch (key)
            //    {
            //        case "ORD_DATE":
            //            //수주일

            //            paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
            //            paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];
            //            break;
            //    }
            //}

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //paramTable.Columns.Add("VEN_LIKE", typeof(String)); //
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //
            //paramTable.Columns.Add("PART_LIKE", typeof(String)); //
            paramTable.Columns.Add("SEARCH_CON", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["VEN_LIKE"] = layoutRow["VEN_LIKE"];
            //paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
            paramRow["SEARCH_CON"] = layoutRow["SEARCH_CON"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "ORD_DATE":
                        //수주일

                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"].toDateStringDBNull("yyyyMMdd");
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"].toDateStringDBNull("yyyyMMdd");
                        break;
                }
            }


            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN17A_SER2", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }


        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //DataTable tmp = e.result.Tables["RSLTDT_PROC"].AsEnumerable()
                //                            .GroupBy(g => new
                //                            {
                //                                PROD_CODE = g["PROD_CODE"],
                //                                PART_CODE = g["PART_CODE"],
                //                                PROC_CODE = g["PROC_CODE"]
                //                            })
                //                            .Select(r => new
                //                            {
                //                                PROD_CODE = r.Key.PROD_CODE,
                //                                PART_CODE = r.Key.PART_CODE,
                //                                PROC_CODE = r.Key.PROC_CODE,
                //                                //진행률
                //                                PROGRESS = r.Count(c => c["WO_FLAG"].ToString().Equals("4")) / r.Count(),
                //                                //실적 최고 날짜
                //                                MAX_ACT_END_TIME = r.Where(w=>!w["ACT_END"].isNull()).Max(m => m["ACT_END"]).toDateString("MM/dd"),
                //                                //확정 이상의 공정이 존재하면 0, 존재하지 않으면 1
                //                                IS_WAIT = r.Any(c => c["WO_FLAG"].toInt() > 1) ? 0 : 1,
                //                                //IS_WAIT 가 1일때만 사용할것
                //                                MAX_PLN_END_TIME = r.Where(w => !w["PLN_END"].isNull()).Max(m => m["PLN_END"]).toDateString("MM/dd"),
                //                            })
                //                            .LINQToDataTable();

                _ProdPartProcTable = e.result.Tables["RSLTDT_PROC"];

                e.result.Tables["RSLTDT"].Columns.Add("IS_SET",typeof(Int32));
                e.result.Tables["RSLTDT"].Columns.Add("PROGRESS", typeof(Int32));
                foreach (DataRow masterRow in e.result.Tables["RSLTDT"].Rows)
                {
                    foreach (var grpRow in _ProdPartProcTable.AsEnumerable()
                                                                    .Where(w => w["PROD_CODE"].Equals(masterRow["PROD_CODE"]) 
                                                                        && w["PART_CODE"].Equals(masterRow["PART_CODE"]))
                                                                    .GroupBy(g=>g["PRG_CODE"])
                                                                    .Select(r=>new { PRG_CODE = r.Key, IMPORTANCE = r.Max(m=>m["IMPORTANCE"].toDecimal()), PROC_List = r.ToList()}))
                    {
                        if(grpRow.PROC_List.Where(w=>w["WO_FLAG"].toInt() == 4).Count() == grpRow.PROC_List.Count)
                        {
                            masterRow["PROGRESS"] = masterRow["PROGRESS"].toInt() + grpRow.IMPORTANCE;
                        }
                        foreach (DataRow procRow in grpRow.PROC_List)
                        {
                            if (!e.result.Tables["RSLTDT"].Columns.Contains(procRow["PROC_CODE"].ToString()))
                            {
                                e.result.Tables["RSLTDT"].Columns.Add(procRow["PROC_CODE"].ToString());
                            }

                            switch (procRow["WO_FLAG"])
                            {
                                case "1":
                                    masterRow[procRow["PROC_CODE"].ToString()] = procRow["PLN_END"].toDateString("MM/dd");
                                    break;
                                case "2":
                                    masterRow[procRow["PROC_CODE"].ToString()] = (procRow["PART_QTY"].toInt() == 0 ?
                                                                                    "0%" : ((procRow["ACT_QTY"].toDecimal() / procRow["PART_QTY"].toDecimal()) * 100).toInt() + "%");
                                    break;
                                case "3":
                                    masterRow[procRow["PROC_CODE"].ToString()] = (procRow["PART_QTY"].toInt() == 0 ?
                                                                                    "0%" : ((procRow["ACT_QTY"].toDecimal() / procRow["PART_QTY"].toDecimal()) * 100).toInt() + "%");
                                    break;
                                case "4":
                                    masterRow[procRow["PROC_CODE"].ToString()] = procRow["ACT_END"].toDateString("MM/dd");
                                    break;
                            }

                            masterRow["IS_SET"] = 1;
                        }
                    }
                }

                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"].Select("IS_SET = 1").CopyToDataTable();
                acBandGridView1.ExpandAllGroups();

                //acBandGridView1.BestFitColumns();
                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        
        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
    }
}
