using BizManager;
using ControlManager;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Windows.Forms;

namespace MAT
{
    public partial class MAT06A_M0A : BaseMenu
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }
        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }
        public MAT06A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            try
            {
                acBandGridView1.GridType = acBandGridView.emGridType.SEARCH;
                acBandGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
                acBandGridView1.AddCheckEdit("SEL", "선택", "", false, true, true, acBandGridView.emCheckEditDataType._STRING);
                acBandGridView1.AddLookUpEdit("STOCK_LOC", "자재 창고", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M005");

                acBandGridView1.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                //acBandGridView1.AddLookUpOrg("STOCK_ORG", "재고 부서", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false);
                acBandGridView1.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                acBandGridView1.AddTextEdit("DETAIL_PART_NAME", "세부 자재명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);

                acBandGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acBandGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acBandGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");

                //acBandGridView1.AddTextEdit("STOCK_VEN", "업체코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                //acBandGridView1.AddTextEdit("STOCK_VEN_NAME", "업체명", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acBandGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, "S016");
                acBandGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");
                acBandGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("MAT_SPEC", "규격", "AD1YYZ7Z", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddLookUpEdit("MAT_UNIT", "관리 단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");

                acBandGridView1.AddTextEdit("TOT_YPGO_AMT", "재고 금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.MONEY);
                acBandGridView1.AddTextEdit("PART_QTY", "재고 수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acBandGridView.emTextEditMask.QTY);
                acBandGridView1.AddTextEdit("ADJ_QTY", "조정 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acBandGridView.emTextEditMask.QTY,"재고 조정");
                acBandGridView1.AddTextEdit("PART_AMT", "추가 재고단가", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acBandGridView.emTextEditMask.MONEY, "재고 조정");
                acBandGridView1.AddTextEdit("UPD_SCOMMENT", "재고조정 비고", "", false, DevExpress.Utils.HorzAlignment.Near, true, true, true, acBandGridView.emTextEditMask.NONE, "재고 조정");
                acBandGridView1.AddTextEdit("MV_QTY", "이동 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acBandGridView.emTextEditMask.QTY, "창고 이동");
                acBandGridView1.AddLookUpEdit("MV_LOC", "이동 창고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "M005", "창고 이동");
                acBandGridView1.AddTextEdit("DEL_QTY", "폐기 수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, true, acBandGridView.emTextEditMask.QTY);
                acBandGridView1.AddDateEdit("REG_DATE", "최초 등록일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.LONG_DATE);
                //acBandGridView1.AddLookUpEmp("REG_EMP", "최초 등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acBandGridView1.AddTextEdit("REG_EMP", "최초 등록인 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emDateMask.LONG_DATE);
                //acBandGridView1.AddLookUpEmp("MDFY_EMP", "최근 수정인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acBandGridView1.AddTextEdit("MDFY_EMP", "최근 수정인 코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acBandGridView.emTextEditMask.NONE);
                acBandGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정인", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acBandGridView.emTextEditMask.NONE);

                acBandGridView1.KeyColumn = new string[] { "PART_CODE", "STOCK_LOC" };

                acGridView2.GridType = acGridView.emGridType.SEARCH;
                acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
                //acGridView2.AddCheckEdit("SEL", "선택", "", false, true, true, acGridView.emCheckEditDataType._STRING);
                acGridView2.AddTextEdit("LOT_ID", "LOT코드", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_CODE", "품목코드", "40239", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddTextEdit("PART_NAME", "품목명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M014");
                acGridView2.AddLookUpEdit("MAT_MTYPE", "중분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M015");
                acGridView2.AddLookUpEdit("MAT_STYPE", "소분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M016");
                acGridView2.AddLookUpEdit("STOCK_FLAG", "상태", "41587", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S087");
                acGridView2.AddTextEdit("UNIT_COST", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
                acGridView2.AddTextEdit("REMAIN_QTY", "남은수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
                acGridView2.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
                acGridView2.AddDateEdit("REG_DATE", "재고 생성일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                //acGridView2.AddLookUpEmp("REG_EMP", "재고 생성자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                acGridView2.KeyColumn = new string[] { "PART_CODE", "STOCK_LOC" };

                acBandGridView1.FocusedRowChanged += acBandGridView1_FocusedRowChanged;
                acBandGridView1.CellValueChanged += acBandGridView1_CellValueChanged;
                acBandGridView1.OptionsSelection.MultiSelect = true;

                ((acLayoutControl1.GetEditor("STOCK_LOC").Editor) as acLookupEdit).SetCode("M005");
                ((acLayoutControl1.GetEditor("PART_PROD_LIKE").Editor) as acLookupEdit).SetCode("M007");

                acLayoutControl1.GetEditor("IS_MAIN").Value = "1";

                acLayoutControl1.OnValueKeyDown += acLayoutControl1_OnValueKeyDown;

                //if (acInfo.UserID == "active")
                //{
                //    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}

                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBandGridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {

                DataRowView row = e.Row as DataRowView;
                if (row["SEL"].toStringEmpty() == "1")
                {
                    if (row["ADJ_QTY"].isNullOrEmpty() || row["PART_AMT"].isNullOrEmpty())
                    {
                        e.Valid = false;
                    }
                    else
                    {
                        e.Valid = true;
                    }
                }
                else
                {
                    e.Valid = true;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBandGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GetDetail();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                this.Search();
        }

        void acGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //재고 이동 목록에서 제외
                acGridView view = sender as acGridView;

                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

                    if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                    {
                        DataRow focusRow = view.GetFocusedDataRow();

                        if (focusRow != null)
                        {
                            acBandGridView1.UpdateMapingRow(focusRow, true);

                            view.DeleteMappingRow(focusRow);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void ChildContainerInit(Control sender)
        {


            base.ChildContainerInit(sender);
        }



        DataTable _dtSearch;

        void Search()
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                if(_dtSearch!= null) _dtSearch.Clear();

                _dtSearch = new DataTable("RQSTDT");
                _dtSearch.Columns.Add("PLT_CODE", typeof(String));
                _dtSearch.Columns.Add("PART_LIKE", typeof(String));
                _dtSearch.Columns.Add("DRAW_LIKE", typeof(String));
                _dtSearch.Columns.Add("SPEC_LIKE", typeof(String));
                _dtSearch.Columns.Add("PART_PROD_LIKE", typeof(String));
                _dtSearch.Columns.Add("STK_LOC", typeof(String));
                _dtSearch.Columns.Add("ALL_LOC", typeof(String));
                _dtSearch.Columns.Add("IS_MAIN", typeof(String)); // 

                DataRow paramRow = _dtSearch.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];
                paramRow["DRAW_LIKE"] = layoutRow["DRAW_LIKE"];
                paramRow["SPEC_LIKE"] = layoutRow["SPEC_LIKE"];
                paramRow["PART_PROD_LIKE"] = layoutRow["PART_PROD_LIKE"];
                paramRow["STK_LOC"] = layoutRow["STOCK_LOC"];

                if (layoutRow["IS_MAIN"].ToString() == "1")
                {
                    paramRow["IS_MAIN"] = "1";
                }

                //if(paramRow["STK_LOC"].isNullOrEmpty())
                //    paramRow["ALL_LOC"] = "true";

                _dtSearch.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(_dtSearch);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MAT06A_SER", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void GetDetail()
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();
                if (focusRow == null) return;

                if(focusRow["STK_ID"].isNullOrEmpty())
                {
                    acGridView2.GridControl.DataSource = null;
                    return;
                }

                DataSet paramSet = new DataSet();

                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("STK_ID", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["STK_ID"] = focusRow["STK_ID"];
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "MAT06A_SER2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSearch2,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        void QuickSearch2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result != null)
                {
                    acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acBandGridView1.SetOldFocusRowHandle(false);
                    acBandGridView1.SelectRow(acBandGridView1.FocusedRowHandle);
            
                    acAlert.Show(this, "수량 조절 완료", acAlertForm.enmType.Success);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickMove(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result != null)
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acBandGridView1.UpdateMapingRow(row, true);
                    }

                    acBandGridView1.RaiseFocusedRowChanged();
                }

                acAlert.Show(this, "재고 이동 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
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



        /// <summary>
        /// 재고조정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>ㅁㅇ
        private void btnAdjustStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acBandGridView1.GetSelectedDataRows().Length == 0) return;

                if (acMessageBox.Show("선택한 품목(들)의 재고 수량을 조정하시겠습니까?", this.Caption, acMessageBox.emMessageBoxType.YESNO)
                        == DialogResult.Yes)
                {


                    acBandGridView1.EndEditor();

                   
                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("STK_ID", typeof(String));
                    dtParam.Columns.Add("TYPE", typeof(String));
                    dtParam.Columns.Add("PART_CODE", typeof(String));
                    dtParam.Columns.Add("STOCK_LOC", typeof(String));
                    dtParam.Columns.Add("PART_QTY", typeof(Int32));
                    dtParam.Columns.Add("DIFF_QTY", typeof(Int32));
                    dtParam.Columns.Add("PART_AMT", typeof(decimal));
                    dtParam.Columns.Add("DETAIL_PART_NAME", typeof(String));
                    dtParam.Columns.Add("SCOMMENT", typeof(String));

                    DataTable dtSource = acBandGridView1.GridControl.DataSource as DataTable;

                    foreach (DataRow dr in dtSource.Select("SEL = '1'"))
                    {
                        int diffQty = dr["ADJ_QTY"].toInt() - dr["PART_QTY"].toInt();
                        if (diffQty > 0 && acBandGridView1.ValidCheck("SEL = '1' AND STK_ID = '"+dr["STK_ID"]+"'") == false)
                        {
                            return;
                        }

                        DataRow drParam = dtParam.NewRow();

                        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                        drParam["STK_ID"] = dr["STK_ID"];
                        drParam["TYPE"] = "ADJ";
                        drParam["PART_CODE"] = dr["PART_CODE"];
                        drParam["STOCK_LOC"] = dr["STOCK_LOC"];
                        drParam["PART_QTY"] = dr["ADJ_QTY"];
                        drParam["DIFF_QTY"] = diffQty;
                        drParam["PART_AMT"] = dr["PART_AMT"];
                        drParam["DETAIL_PART_NAME"] = dr["DETAIL_PART_NAME"];
                        drParam["SCOMMENT"] = dr["UPD_SCOMMENT"];
                        dtParam.Rows.Add(drParam);

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtParam);
                    DataTable dtSer = _dtSearch.Copy();
                    dtSer.TableName = "RQSTDT_SER";
                    paramSet.Tables.Add(dtSer);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_UPD", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);


                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        /// <summary>
        /// 재고 창고 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotMoveLoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region
                //acGridView2.EndEditor();

                //DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                //if (selView.Count == 0) return;

                //MAT06A_D0A frm = new MAT06A_D0A();

                //frm.ParentControl = this;

                //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{

                //    DataTable dtParam = new DataTable("RQSTDT");
                //    dtParam.Columns.Add("PLT_CODE", typeof(String));
                //    dtParam.Columns.Add("TYPE", typeof(String));
                //    dtParam.Columns.Add("STK_ID", typeof(String));
                //    dtParam.Columns.Add("LOT_ID", typeof(String));
                //    dtParam.Columns.Add("PART_CODE", typeof(String));
                //    dtParam.Columns.Add("STOCK_LOC", typeof(String));
                //    dtParam.Columns.Add("MOVE_STOCK_LOC", typeof(String));
                //    dtParam.Columns.Add("DETAIL_PART_NAME", typeof(String));

                //    DataRow selectedRow = (DataRow)frm.OutputData;

                //    foreach (DataRowView dr in selView)
                //    {
                //        DataRow drParam = dtParam.NewRow();

                //        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                //        drParam["TYPE"] = "MOV";
                //        drParam["STK_ID"] = dr["STK_ID"];
                //        drParam["LOT_ID"] = dr["LOT_ID"];
                //        drParam["PART_CODE"] = dr["PART_CODE"];
                //        drParam["STOCK_LOC"] = dr["STOCK_LOC"];
                //        drParam["MOVE_STOCK_LOC"] = selectedRow["STOCK_LOC"];
                //        drParam["DETAIL_PART_NAME"] = dr["DETAIL_PART_NAME"];
                //        dtParam.Rows.Add(drParam);

                //    }

                //    DataSet paramSet = new DataSet();
                //    paramSet.Tables.Add(dtParam);
                //    DataTable dtSer = _dtSearch.Copy();
                //    dtSer.TableName = "RQSTDT_SER";
                //    paramSet.Tables.Add(dtSer);

                //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS2", paramSet, "RQSTDT", "RSLTDT",
                //                QuickMove,
                //                QuickException);

                //}
                #endregion
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        /// <summary>
        /// 재고 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotCreateStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MAT06A_D1A frm = new MAT06A_D1A();

                frm.ParentControl = this;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataRow selectedRow = (DataRow)frm.OutputData;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("STK_ID", typeof(String));
                    paramTable.Columns.Add("TYPE", typeof(String));
                    paramTable.Columns.Add("PART_CODE", typeof(String));
                    paramTable.Columns.Add("STOCK_LOC", typeof(String));
                    paramTable.Columns.Add("PART_QTY", typeof(String));
                    paramTable.Columns.Add("AMT", typeof(String));
                    paramTable.Columns.Add("YPGO_ID", typeof(String));
                    paramTable.Columns.Add("OUT_ID", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TYPE"] = "ADD";
                    paramRow["PART_CODE"] = selectedRow["PART_CODE"];
                    paramRow["STOCK_LOC"] = selectedRow["STOCK_LOC"];
                    paramRow["PART_QTY"] = selectedRow["PART_QTY"];
                    paramRow["AMT"] = selectedRow["YPGO_AMT"];
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    if (_dtSearch != null)
                    {
                        DataTable dtSer = _dtSearch.Copy();
                        dtSer.TableName = "RQSTDT_SER";
                        paramSet.Tables.Add(dtSer);
                    }
                    else
                    {
                        DataTable dtSer = new DataTable("RQSTDT_SER");
                        dtSer.Columns.Add("PLT_CODE", typeof(String));
                        dtSer.Columns.Add("PART_LIKE", typeof(String));

                        DataRow drSer = dtSer.NewRow();
                        drSer["PLT_CODE"] = acInfo.PLT_CODE;
                        drSer["PART_LIKE"] = selectedRow["PART_CODE"];
                        dtSer.Rows.Add(drSer);

                        paramSet.Tables.Add(dtSer);

                    }

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave,
                                QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        //재고 이동 목록에 넣기
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBandGridView1.EndEditor();

                DataView selectedView = acBandGridView1.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    //단일선택

                    DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                    if (focusRow != null)
                    {

                        DataRow row = focusRow.NewCopy();

                        row["SEL"] = "0";

                        acGridView2.UpdateMapingRow(row, true);

                        acBandGridView1.DeleteMappingRow(row);

                    }
                }
                else
                {
                    //다중선택

                    int cnt = selectedView.Count;

                    for (int i = 0; i < cnt; i++)
                    {

                        DataRow row = selectedView[0].Row.NewCopy();

                        row["SEL"] = "0";

                        acGridView2.UpdateMapingRow(row, true);

                        acBandGridView1.DeleteMappingRow(row);
                    }


                    //acGridView2.RaiseFocusedRowChanged();

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void acBandGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow row = acBandGridView1.GetDataRow(e.RowHandle);
            if (row == null) return;

            switch (e.Column.FieldName)
            {
                case "ADJ_QTY":
                    row["SEL"] = "1";
                    break;
                case "MV_QTY":
                    row["SEL"] = "1";
                    break;
                case "MV_LOC":
                    if(row["STOCK_LOC"].ToString() == row["MV_LOC"].ToString())
                    {
                        acAlert.Show(this, "자재창고과 이동창고가 동일합니다.", acAlertForm.enmType.Warning);
                    }
                    break;

            }
        }

        private void btnLotMoveStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region

                //acGridView2.EndEditor();

                //DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                //if (selView.Count == 0) return;

                //MAT06A_D2A frm = new MAT06A_D2A();

                //frm.ParentControl = this;

                //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{

                //    DataTable dtParam = new DataTable("RQSTDT");
                //    dtParam.Columns.Add("PLT_CODE", typeof(String));
                //    dtParam.Columns.Add("TYPE", typeof(String));
                //    dtParam.Columns.Add("STK_ID", typeof(String));
                //    dtParam.Columns.Add("LOT_ID", typeof(String));
                //    dtParam.Columns.Add("PART_CODE", typeof(String));
                //    dtParam.Columns.Add("STOCK_LOC", typeof(String));
                //    dtParam.Columns.Add("MOVE_STOCK_LOC", typeof(String));

                //    DataRow selectedRow = (DataRow)frm.OutputData;

                //    foreach (DataRowView dr in selView)
                //    {
                //        DataRow drParam = dtParam.NewRow();

                //        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                //        drParam["TYPE"] = "MOV";
                //        drParam["STK_ID"] = dr["STK_ID"];
                //        drParam["LOT_ID"] = dr["LOT_ID"];
                //        drParam["PART_CODE"] = selectedRow["PART_CODE"];
                //        drParam["STOCK_LOC"] = dr["STOCK_LOC"];
                //        drParam["MOVE_STOCK_LOC"] = selectedRow["STOCK_LOC"];
                //        dtParam.Rows.Add(drParam);

                //    }

                //    DataSet paramSet = new DataSet();
                //    paramSet.Tables.Add(dtParam);
                //    DataTable dtSer = _dtSearch.Copy();
                //    dtSer.TableName = "RQSTDT_SER";
                //    paramSet.Tables.Add(dtSer);

                //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS3", paramSet, "RQSTDT", "RSLTDT",
                //                QuickMove,
                //                QuickException);

                //}

                #endregion
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnLotDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region

                //acGridView2.EndEditor();

                //DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                //if (selView.Count == 0) return;


                //DataTable dtParam = new DataTable("RQSTDT");
                //dtParam.Columns.Add("PLT_CODE", typeof(String));
                //dtParam.Columns.Add("STK_ID", typeof(String));
                //dtParam.Columns.Add("LOT_ID", typeof(String));

                //foreach (DataRowView dr in selView)
                //{
                //    DataRow drParam = dtParam.NewRow();

                //    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                //    drParam["STK_ID"] = dr["STK_ID"];
                //    drParam["LOT_ID"] = dr["LOT_ID"];
                //    dtParam.Rows.Add(drParam);

                //}

                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(dtParam);
                //DataTable dtSer = _dtSearch.Copy();
                //dtSer.TableName = "RQSTDT_SER";
                //paramSet.Tables.Add(dtSer);

                //BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_UDE", paramSet, "RQSTDT", "RSLTDT",
                //            QuickMove,
                //            QuickException);

                #endregion                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnMdfyQtyStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                DataView selView = acGridView2.GetDataSourceView("SEL='1'");

                if (selView.Count == 0) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("STK_ID", typeof(String));
                dtParam.Columns.Add("ADJ_QTY", typeof(Decimal));

                foreach (DataRowView dr in selView)
                {
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["STK_ID"] = dr["STK_ID"];
                    drParam["ADJ_QTY"] = dr["ADJ_QTY"];
                    dtParam.Rows.Add(drParam);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);
                DataTable dtSer = _dtSearch.Copy();
                dtSer.TableName = "RQSTDT_SER";
                paramSet.Tables.Add(dtSer);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_UPD", paramSet, "RQSTDT", "RSLTDT",
                            QuickMove,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnMoveLoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBandGridView1.EndEditor();

                DataView selView = acBandGridView1.GetDataSourceView("SEL='1'");

                if (selView.Count == 0) return;

                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("TYPE", typeof(String));
                dtParam.Columns.Add("PART_CODE", typeof(String));
                dtParam.Columns.Add("STOCK_LOC", typeof(String));
                dtParam.Columns.Add("STK_ID", typeof(String));
                dtParam.Columns.Add("MV_QTY", typeof(Decimal));
                dtParam.Columns.Add("MOVE_STOCK_LOC", typeof(String));
                dtParam.Columns.Add("DETAIL_PART_NAME", typeof(String));

                foreach (DataRowView dr in selView)
                {
                    if (dr["PART_QTY"].toDecimal() < dr["MV_QTY"].toDecimal())
                    {
                        acMessageBox.Show(this, "현 재고 수량보다 많은 수량을 이동하실수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    if (dr["MV_LOC"].isNullOrEmpty())
                    {
                        acMessageBox.Show(this, "이동 창고를 선택해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["TYPE"] = "MV";
                    drParam["PART_CODE"] = dr["PART_CODE"];
                    drParam["STOCK_LOC"] = dr["STOCK_LOC"];
                    drParam["STK_ID"] = dr["STK_ID"];
                    drParam["MV_QTY"] = dr["MV_QTY"];
                    drParam["MOVE_STOCK_LOC"] = dr["MV_LOC"];
                    drParam["DETAIL_PART_NAME"] = dr["DETAIL_PART_NAME"];
                    dtParam.Rows.Add(drParam);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);
                DataTable dtSer = _dtSearch.Copy();
                dtSer.TableName = "RQSTDT_SER";
                paramSet.Tables.Add(dtSer);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS2_1", paramSet, "RQSTDT", "RSLTDT",
                            QuickMove,
                            QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnMoveStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBandGridView1.EndEditor();

                DataView selView = acBandGridView1.GetDataSourceView("SEL='1'");

                if (selView.Count == 0) return;

                MAT06A_D3A frm = new MAT06A_D3A();

                frm.ParentControl = this;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    DataTable dtParam = new DataTable("RQSTDT");
                    dtParam.Columns.Add("PLT_CODE", typeof(String));
                    dtParam.Columns.Add("TYPE", typeof(String));
                    dtParam.Columns.Add("STK_ID", typeof(String));
                    dtParam.Columns.Add("PART_CODE", typeof(String));
                    dtParam.Columns.Add("STOCK_LOC", typeof(String));
                    dtParam.Columns.Add("MOVE_STOCK_LOC", typeof(String));
                    dtParam.Columns.Add("MOVE_QTY", typeof(String));

                    DataRow frmRow = (DataRow)frm.OutputData;

                    foreach (DataRowView dr in selView)
                    {
                        DataRow drParam = dtParam.NewRow();

                        drParam["PLT_CODE"] = acInfo.PLT_CODE;
                        drParam["TYPE"] = "CH";
                        drParam["STK_ID"] = dr["STK_ID"];
                        drParam["PART_CODE"] = frmRow["PART_CODE"];
                        drParam["STOCK_LOC"] = dr["STOCK_LOC"];
                        drParam["MOVE_STOCK_LOC"] = frmRow["STOCK_LOC"];
                        drParam["MOVE_QTY"] = frmRow["MOVE_QTY"];
                        dtParam.Rows.Add(drParam);

                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(dtParam);
                    DataTable dtSer = _dtSearch.Copy();
                    dtSer.TableName = "RQSTDT_SER";
                    paramSet.Tables.Add(dtSer);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS4", paramSet, "RQSTDT", "RSLTDT",
                                QuickMove,
                                QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnPartsDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acBandGridView1.EndEditor();

                DataView selView = acBandGridView1.GetDataSourceView("SEL='1'");

                if (selView.Count == 0) return;


                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("STK_ID", typeof(String));
                dtParam.Columns.Add("DEL_QTY", typeof(Int32));

                foreach (DataRowView dr in selView)
                {
                    if (dr["DEL_QTY"].toInt() == 0)
                    {
                        acAlert.Show(this, "선택한 재고내역중 폐기 수량을 입력하지 않은것이 존재합니다.", acAlertForm.enmType.Warning);
                        return;
                    }

                    if (dr["PART_QTY"].toInt() < dr["DEL_QTY"].toInt())
                    {
                        acAlert.Show(this, "재고수량보다 많은 수량을 폐기할 수 없습니다.", acAlertForm.enmType.Warning);
                        return;
                    }
                    DataRow drParam = dtParam.NewRow();

                    drParam["PLT_CODE"] = acInfo.PLT_CODE;
                    drParam["STK_ID"] = dr["STK_ID"];
                    drParam["DEL_QTY"] = dr["DEL_QTY"];
                    dtParam.Rows.Add(drParam);

                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(dtParam);
                DataTable dtSer = _dtSearch.Copy();
                dtSer.TableName = "RQSTDT_SER";
                paramSet.Tables.Add(dtSer);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_UDE2", paramSet, "RQSTDT", "RSLTDT",
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
                if (e.result != null)
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        acBandGridView1.UpdateMapingRow(row, true);
                    }

                    acBandGridView1.RaiseFocusedRowChanged();
                }

                acAlert.Show(this, "재고 폐기 완료", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnPartsCreateStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acBandGridView1.GetFocusedDataRow();

                MAT06A_D1A frm = new MAT06A_D1A(focusRow);

                frm.ParentControl = this;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataRow selectedRow = (DataRow)frm.OutputData;

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    paramTable.Columns.Add("STK_ID", typeof(String));
                    paramTable.Columns.Add("TYPE", typeof(String));
                    paramTable.Columns.Add("PART_CODE", typeof(String));
                    paramTable.Columns.Add("STOCK_LOC", typeof(String));
                    paramTable.Columns.Add("PART_QTY", typeof(String));
                    paramTable.Columns.Add("AMT", typeof(String));
                    paramTable.Columns.Add("YPGO_ID", typeof(String));
                    paramTable.Columns.Add("OUT_ID", typeof(String));

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TYPE"] = "ADD";
                    paramRow["PART_CODE"] = selectedRow["PART_CODE"];
                    paramRow["STOCK_LOC"] = selectedRow["STOCK_LOC"];
                    paramRow["PART_QTY"] = selectedRow["PART_QTY"];
                    paramRow["AMT"] = selectedRow["YPGO_AMT"];
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    if (_dtSearch != null)
                    {
                        DataTable dtSer = _dtSearch.Copy();
                        dtSer.TableName = "RQSTDT_SER";
                        paramSet.Tables.Add(dtSer);
                    }
                    else
                    {
                        DataTable dtSer = new DataTable("RQSTDT_SER");
                        dtSer.Columns.Add("PLT_CODE", typeof(String));
                        dtSer.Columns.Add("PART_LIKE", typeof(String));

                        DataRow drSer = dtSer.NewRow();
                        drSer["PLT_CODE"] = acInfo.PLT_CODE;
                        drSer["PART_LIKE"] = selectedRow["PART_CODE"];
                        dtSer.Rows.Add(drSer);

                        paramSet.Tables.Add(dtSer);

                    }

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_INS", paramSet, "RQSTDT", "RSLTDT",
                                QuickSave2,
                                QuickException);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result != null)
                {
                    acBandGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                    acBandGridView1.SetOldFocusRowHandle(false);
                    acBandGridView1.SelectRow(acBandGridView1.FocusedRowHandle);

                    acAlert.Show(this, "재고 생성 완료", acAlertForm.enmType.Success);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS, "MAT06A_Create", paramSet, "RQSTDT", "RSLTDT",
                        QuickCreate,
                        QuickException);
        }

        void QuickCreate(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                _isCtrl = false;
                _isShift = false;
                _isF1 = false;

                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        bool _isCtrl = false;
        bool _isShift = false;
        bool _isF1 = false;

        private void acGridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.ControlKey)
            {
                _isCtrl = true;
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                _isShift = true;
            }

            if (e.KeyCode == Keys.F1)
            {
                _isF1 = true;
            }

            if (_isCtrl && _isShift && _isF1)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
    }
}
