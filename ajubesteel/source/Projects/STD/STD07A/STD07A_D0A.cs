using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace STD
{
    public sealed partial class STD07A_D0A : BaseMenuDialog
    {
        DataSet _dtAllStatTool;
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

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;




        public STD07A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _dtAllStatTool = new DataSet();

            _LinkView = linkView;
            _LinkData = linkData;

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acGridView1.CustomDrawRowIndicator += AcGridView1_CustomDrawRowIndicator;
            //acGridView1.MouseDown += AcGridView1_MouseDown;
        }

        private void AcGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    try
                    {
                        //if (!base.ChildFormContains("NEW"))
                        //{
                        //    STD07A_D2A frm = new STD07A_D2A(hitInfo.Column.FieldName, _dtAllStatTool);
                        //    frm.Text = hitInfo.Column.Caption;
                        //    frm.ParentControl = this;
                        //    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                        //    base.ChildFormAdd("NEW", frm);
                        //    frm.Show(this);
                        //}
                        //else
                        //{
                        //    base.ChildFormFocus("NEW");
                        //}

                        SetGridViewData(hitInfo.Column.FieldName);
                    }
                    catch (Exception ex)
                    {
                        acMessageBox.Show(this, ex);
                    }
                }

            }
        }

        private void SetGridViewData(string mcCode)
        {
            //다 같은 공구
            var gRows = _dtAllStatTool.Tables["DT_GIVE"]
                                        .Select("GIVE_MC = '" + mcCode + "'");
            DataTable dtGive = gRows.Any() ? gRows.CopyToDataTable() : _dtAllStatTool.Tables["DT_GIVE"].Copy().Clone();

            var rRows = _dtAllStatTool.Tables["DT_RETURN"]
                                          .AsEnumerable()
                                          .Where(w => dtGive.Select("GIVE_NO='" + w.Field<string>("GIVE_NO") + "' AND GIVE_SEQ = " + w.Field<int>("GIVE_SEQ") + "").Any());
            DataTable dtReturn = rRows.Any() ? rRows.CopyToDataTable() : _dtAllStatTool.Tables["DT_RETURN"].Copy().Clone();

            var dRows = _dtAllStatTool.Tables["DT_DISUSE"]
                                          .AsEnumerable()
                                          .Where(w => dtGive.Select("TL_LOT = '" + w.Field<string>("TL_LOT") + "'").Any());
            DataTable dtDisuse = dRows.Any() ? dRows.CopyToDataTable() : _dtAllStatTool.Tables["DT_DISUSE"].Copy().Clone();

            var vGive = dtGive.AsEnumerable().GroupBy(g => new { GIVE_DATE = g.Field<string>("GIVE_DATE") })
                                            .Select(r => new { GIVE_DATE = r.Key.GIVE_DATE, GIVE_QTY = r.Count() });
            var vReturn = dtReturn.AsEnumerable().GroupBy(g => new { RTN_DATE = g.Field<string>("RTN_DATE") })
                                            .Select(r => new { RTN_DATE = r.Key.RTN_DATE, RTN_QTY = r.Count() });
            var vDisuse = dtDisuse.AsEnumerable().GroupBy(g => new { TDU_DATE = g.Field<string>("TDU_DATE") })
                                            .Select(r => new { TDU_DATE = r.Key.TDU_DATE, TDU_QTY = r.Count() });

            DataTable result = new DataTable();
            result.Columns.Add("GIVE_DATE", typeof(string));
            result.Columns.Add("GIVE_QTY", typeof(string));
            result.Columns.Add("RTN_DATE", typeof(string));
            result.Columns.Add("RTN_QTY", typeof(string));
            result.Columns.Add("TDU_DATE", typeof(string));
            result.Columns.Add("TDU_QTY", typeof(string));

            int index = 0;
            int cntGive = vGive.Count();
            int cntRtn = vReturn.Count();
            int cntTdu = vDisuse.Count();

            while ((result.Rows.Count < cntGive)
                    || (result.Rows.Count < cntRtn)
                    || (result.Rows.Count < cntTdu))
            {
                DataRow resultRow = result.NewRow();

                if (index < cntGive)
                {
                    resultRow["GIVE_DATE"] = vGive.ElementAt(index).GIVE_DATE;
                    resultRow["GIVE_QTY"] = vGive.ElementAt(index).GIVE_QTY;
                }

                if (index < cntRtn)
                {
                    resultRow["RTN_DATE"] = vReturn.ElementAt(index).RTN_DATE;
                    resultRow["RTN_QTY"] = vReturn.ElementAt(index).RTN_QTY;
                }

                if (index < cntTdu)
                {
                    resultRow["TDU_DATE"] = vDisuse.ElementAt(index).TDU_DATE;
                    resultRow["TDU_QTY"] = vDisuse.ElementAt(index).TDU_QTY;
                }
                result.Rows.Add(resultRow);

                index++;
            }

            acGridView2.GridControl.DataSource = result;
        }

        private void AcGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Info.DisplayText = "설비";
            }
            else
            {
                e.Info.DisplayText = "수량";
            }

            acGridView1.IndicatorWidth = 50;
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "TL_LTYPE":
                    //공구 중분류
                    (layout.GetEditor("TL_MTYPE").Editor as acLookupEdit).SetCode("T002", newValue);
                    break;
                case "TL_MTYPE":
                    //공구 소분류
                    (layout.GetEditor("TL_STYPE").Editor as acLookupEdit).SetCode("T003", newValue);
                    break;
            }
        }




        public override void DialogInit()
        {
            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddDateEdit("GIVE_DATE", "지급일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("GIVE_QTY", "지급수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddDateEdit("RTN_DATE", "반납일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("RTN_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddDateEdit("TDU_DATE", "폐기일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("TDU_QTY", "폐기수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            acLayoutControl1.KeyColumns = new string[] { "TL_CODE" };

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //공구형태
            (acLayoutControl1.GetEditor("TL_TYPE").Editor as acLookupEdit).SetCode("T004");

            //공구 대분류
            (acLayoutControl1.GetEditor("TL_LTYPE").Editor as acLookupEdit).SetCode("T001");

            //단위
            (acLayoutControl1.GetEditor("TL_UNIT").Editor as acLookupEdit).SetCode("M003");

            //보관위치
            (acLayoutControl1.GetEditor("TOOL_LOCATION").Editor as acLookupEdit).SetCode("M005");

            acGridView1.OptionsView.ShowIndicator = true;

            base.DialogInit();

        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();
        }


        public override void DialogNew()
        {
            //새로 만들기
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            //열기
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = (DataRow)_LinkData;
            acLayoutControl1.DataBind(linkRow, true);

            this.acAttachFileControl1.LinkKey = linkRow["PLT_CODE"].ToString()+ linkRow["TL_CODE"].ToString();
            this.acAttachFileControl1.ShowKey = new object[] { linkRow["PLT_CODE"].ToString() + linkRow["TL_CODE"].ToString() };

            this.GetQtyEachMC();

            base.DialogOpen();
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else if (ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {
                acMessageBoxGridYesNo frm = new acMessageBoxGridYesNo(this, "acMessageBoxGridYesNo1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, this.Caption, ex.ParameterData);
                frm.View.GridType = acGridView.emGridType.FIXED;
                frm.View.AddDateEdit("DEL_DATE", "삭제일", "EHRC2TC6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);
                frm.View.AddTextEdit("DEL_EMP", "삭제자코드", "58XXVB97", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                frm.View.AddMemoEdit("DEL_REASON", "삭제사유", "A9DY9R6G", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Top, false, false, true, false);

                if (frm.ShowDialog() == DialogResult.No)
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



        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //클리어
            try
            {
                acLayoutControl1.ClearValue();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                bool isOK = false;

                if (acMessageBox.Show(this, "품목정보에도 추가하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    isOK = true;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_NAME", typeof(String)); //
                paramTable.Columns.Add("TL_TYPE", typeof(String)); //

                paramTable.Columns.Add("TL_LTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_MTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_STYPE", typeof(String)); //

                paramTable.Columns.Add("TL_SIZE", typeof(Decimal)); //
                paramTable.Columns.Add("SHANK", typeof(Decimal)); //
                paramTable.Columns.Add("CUT_LENGTH", typeof(Decimal)); //
                paramTable.Columns.Add("OVR_LENGTH", typeof(Decimal)); //

                paramTable.Columns.Add("TL_SPEC", typeof(String)); //
                paramTable.Columns.Add("TL_MIN", typeof(Decimal));
                paramTable.Columns.Add("TL_MAX", typeof(Decimal));
                paramTable.Columns.Add("TL_DANGER_QTY", typeof(Decimal));

                paramTable.Columns.Add("TL_MAKER", typeof(String)); //
                paramTable.Columns.Add("TL_UNITCOST", typeof(Decimal)); //
                paramTable.Columns.Add("TL_UNIT", typeof(String)); //
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable.Columns.Add("HOLDER", typeof(String)); //
                paramTable.Columns.Add("TL_LENGTH", typeof(Decimal)); //
                paramTable.Columns.Add("TL_QTY", typeof(Decimal));
                paramTable.Columns.Add("TL_D_QTY", typeof(Decimal));

                paramTable.Columns.Add("STD_LIFE", typeof(Int32)); //

                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("TL_IMAGE", typeof(byte[])); //

                paramTable.Columns.Add("TOOL_LOCATION", typeof(String)); //
                paramTable.Columns.Add("TOOL_LOCATION_DETAIL", typeof(String)); //

                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = layoutRow["TL_CODE"];
                paramRow["TL_NAME"] = layoutRow["TL_NAME"];
                paramRow["TL_TYPE"] = layoutRow["TL_TYPE"];

                paramRow["TL_LTYPE"] = layoutRow["TL_LTYPE"];
                paramRow["TL_MTYPE"] = layoutRow["TL_MTYPE"];
                paramRow["TL_STYPE"] = layoutRow["TL_STYPE"];

                paramRow["TL_SIZE"] = layoutRow["TL_SIZE"];
                paramRow["SHANK"] = layoutRow["SHANK"];
                paramRow["CUT_LENGTH"] = layoutRow["CUT_LENGTH"];
                paramRow["OVR_LENGTH"] = layoutRow["OVR_LENGTH"];

                paramRow["TL_SPEC"] = layoutRow["TL_SPEC"];
                paramRow["TL_MIN"] = layoutRow["TL_MIN"];
                paramRow["TL_MAX"] = layoutRow["TL_MAX"];
                paramRow["TL_DANGER_QTY"] = layoutRow["TL_DANGER_QTY"];

                paramRow["TL_MAKER"] = layoutRow["TL_MAKER"];
                paramRow["TL_UNITCOST"] = layoutRow["TL_UNITCOST"];
                paramRow["TL_UNIT"] = layoutRow["TL_UNIT"];
                paramRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                paramRow["HOLDER"] = layoutRow["HOLDER"];
                paramRow["TL_LENGTH"] = layoutRow["TL_LENGTH"];

                paramRow["TL_QTY"] = layoutRow["TL_QTY"];
                paramRow["TL_D_QTY"] = layoutRow["TL_D_QTY"];

                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["TL_IMAGE"] = CreateImage(layoutRow["TL_IMAGE"].toImage());

                paramRow["STD_LIFE"] = layoutRow["STD_LIFE"];
                paramRow["TOOL_LOCATION"] = layoutRow["TOOL_LOCATION"];
                paramRow["TOOL_LOCATION_DETAIL"] = layoutRow["TOOL_LOCATION_DETAIL"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "0";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //품목정보에 정보 저장 NO
                if (!isOK)
                {
                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                   "STD07A_INS", paramSet, "RQSTDT", "RSLTDT",
                   QuickSave,
                   QuickException);
                }
                else
                {
                    DataTable itemTable = new DataTable("RQSTDT_ITEM");
                    itemTable.Columns.Add("PLT_CODE", typeof(String)); //
                    itemTable.Columns.Add("PART_CODE", typeof(String)); //
                    itemTable.Columns.Add("PART_NAME", typeof(String)); //
                    itemTable.Columns.Add("MAT_TYPE", typeof(String));
                    itemTable.Columns.Add("MAT_LTYPE", typeof(String));
                    itemTable.Columns.Add("SPEC_TYPE", typeof(String));
                    itemTable.Columns.Add("MAT_SPEC1", typeof(String));
                    itemTable.Columns.Add("DRAW_NO", typeof(String));
                    itemTable.Columns.Add("BAL_SPEC", typeof(String));
                    
                    itemTable.Columns.Add("MAT_UC", typeof(Decimal));
                    itemTable.Columns.Add("MAT_COST", typeof(Decimal));
                    itemTable.Columns.Add("MAIN_VND", typeof(String));
                    itemTable.Columns.Add("SAFE_STK_QTY", typeof(String));
                    itemTable.Columns.Add("STK_LOCATION", typeof(String)); //
                    itemTable.Columns.Add("STK_LOCATION_DETAIL", typeof(String)); //
                    itemTable.Columns.Add("SCOMMENT", typeof(String)); //
                    itemTable.Columns.Add("REG_EMP", typeof(String)); //

                    itemTable.Columns.Add("INS_FLAG", typeof(String)); //
                    itemTable.Columns.Add("AUTO_CREATE", typeof(Byte)); //
                    itemTable.Columns.Add("AUTO_MARGIN", typeof(Byte)); //
                    itemTable.Columns.Add("STK_MNG", typeof(Byte)); //
                    itemTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                    DataRow itemRow = itemTable.NewRow();
                    itemRow["PLT_CODE"] = acInfo.PLT_CODE;
                    itemRow["PART_CODE"] = layoutRow["TL_CODE"];
                    itemRow["PART_NAME"] = layoutRow["TL_NAME"];
                    itemRow["MAT_TYPE"] = acStdCodes.GetCodeByNameServer("S016", "구매품");
                    itemRow["MAT_LTYPE"] = acStdCodes.GetCodeByNameServer("M001", "공구");
                    itemRow["SPEC_TYPE"] = acStdCodes.GetCodeByNameServer("S062", "기타");
                    itemRow["MAT_SPEC1"] = layoutRow["TL_SPEC"];
                    itemRow["DRAW_NO"] = layoutRow["TL_SPEC"];
                    itemRow["BAL_SPEC"] = layoutRow["TL_SPEC"];

                    //itemRow["MAT_UNIT"] = layoutRow["TL_UNIT"];
                    itemRow["MAT_UC"] = layoutRow["TL_UNITCOST"];
                    itemRow["MAT_COST"] = layoutRow["TL_UNITCOST"];
                    itemRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                    itemRow["SAFE_STK_QTY"] = layoutRow["TL_DANGER_QTY"];
                    itemRow["STK_LOCATION"] = layoutRow["TOOL_LOCATION"];
                    itemRow["STK_LOCATION_DETAIL"] = layoutRow["TOOL_LOCATION_DETAIL"];
                    itemRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                    itemRow["REG_EMP"] = acInfo.UserID;
                    itemRow["INS_FLAG"] = 0;
                    itemRow["AUTO_CREATE"] = 0;
                    itemRow["AUTO_MARGIN"] = "0";
                    itemRow["STK_MNG"] = 0;
                    itemRow["OVERWRITE"] = "0";

                    itemTable.Rows.Add(itemRow);
                    paramSet.Tables.Add(itemTable);

                    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NEW,
                   "STD07A_INS3", paramSet, "RQSTDT,RQSTDT_ITEM", "RSLTDT",
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
        /// 저장 후 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //유효성 확인
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_NAME", typeof(String)); //
                paramTable.Columns.Add("TL_TYPE", typeof(String)); //

                paramTable.Columns.Add("TL_LTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_MTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_STYPE", typeof(String)); //

                paramTable.Columns.Add("TL_SIZE", typeof(Decimal)); //
                paramTable.Columns.Add("SHANK", typeof(Decimal)); //
                paramTable.Columns.Add("CUT_LENGTH", typeof(Decimal)); //
                paramTable.Columns.Add("OVR_LENGTH", typeof(Decimal)); //

                paramTable.Columns.Add("TL_SPEC", typeof(String)); //
                paramTable.Columns.Add("TL_MIN", typeof(Decimal));
                paramTable.Columns.Add("TL_MAX", typeof(Decimal));
                paramTable.Columns.Add("TL_DANGER_QTY", typeof(Decimal));
                paramTable.Columns.Add("TL_MAKER", typeof(String)); //

                paramTable.Columns.Add("TL_UNITCOST", typeof(Decimal)); //
                paramTable.Columns.Add("TL_UNIT", typeof(String)); //
                paramTable.Columns.Add("MAIN_VND", typeof(String)); //
                paramTable.Columns.Add("HOLDER", typeof(String)); //
                paramTable.Columns.Add("TL_LENGTH", typeof(Decimal)); //

                paramTable.Columns.Add("TL_QTY", typeof(Decimal));
                paramTable.Columns.Add("TL_D_QTY", typeof(Decimal));
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("TL_IMAGE", typeof(byte[])); //


                paramTable.Columns.Add("STD_LIFE", typeof(Int32)); //
                paramTable.Columns.Add("TOOL_LOCATION", typeof(String)); //
                paramTable.Columns.Add("TOOL_LOCATION_DETAIL", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = linkRow["TL_CODE"];
                paramRow["TL_NAME"] = layoutRow["TL_NAME"];
                paramRow["TL_TYPE"] = layoutRow["TL_TYPE"];

                paramRow["TL_LTYPE"] = layoutRow["TL_LTYPE"];
                paramRow["TL_MTYPE"] = layoutRow["TL_MTYPE"];
                paramRow["TL_STYPE"] = layoutRow["TL_STYPE"];

                paramRow["TL_SIZE"] = layoutRow["TL_SIZE"];
                paramRow["SHANK"] = layoutRow["SHANK"];
                paramRow["CUT_LENGTH"] = layoutRow["CUT_LENGTH"];
                paramRow["OVR_LENGTH"] = layoutRow["OVR_LENGTH"];

                paramRow["TL_SPEC"] = layoutRow["TL_SPEC"];
                paramRow["TL_MIN"] = layoutRow["TL_MIN"];
                paramRow["TL_MAX"] = layoutRow["TL_MAX"];
                paramRow["TL_DANGER_QTY"] = layoutRow["TL_DANGER_QTY"];

                paramRow["TL_MAKER"] = layoutRow["TL_MAKER"];
                paramRow["TL_UNITCOST"] = layoutRow["TL_UNITCOST"];
                paramRow["TL_UNIT"] = layoutRow["TL_UNIT"];
                paramRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                paramRow["HOLDER"] = layoutRow["HOLDER"];
                paramRow["TL_LENGTH"] = layoutRow["TL_LENGTH"];

                paramRow["TL_QTY"] = layoutRow["TL_QTY"];
                paramRow["TL_D_QTY"] = layoutRow["TL_D_QTY"];

                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["TL_IMAGE"] = layoutRow["TL_IMAGE"];
                paramRow["STD_LIFE"] = layoutRow["STD_LIFE"];
                paramRow["TOOL_LOCATION"] = layoutRow["TOOL_LOCATION"];
                paramRow["TOOL_LOCATION_DETAIL"] = layoutRow["TOOL_LOCATION_DETAIL"];

                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";

                paramTable.Rows.Add(paramRow);

                DataTable itemTable = new DataTable("RQSTDT_ITEM");
                itemTable.Columns.Add("PLT_CODE", typeof(String)); //
                itemTable.Columns.Add("PART_CODE", typeof(String)); //
                itemTable.Columns.Add("PART_NAME", typeof(String)); //
                itemTable.Columns.Add("MAT_TYPE", typeof(String));
                itemTable.Columns.Add("MAT_LTYPE", typeof(String));
                itemTable.Columns.Add("SPEC_TYPE", typeof(String));
                itemTable.Columns.Add("MAT_SPEC1", typeof(String));
                itemTable.Columns.Add("DRAW_NO", typeof(String));
                itemTable.Columns.Add("BAL_SPEC", typeof(String));

                //itemTable.Columns.Add("MAT_UNIT", typeof(String));
                itemTable.Columns.Add("MAT_UC", typeof(Decimal));
                itemTable.Columns.Add("MAT_COST", typeof(Decimal));
                itemTable.Columns.Add("MAIN_VND", typeof(String));
                itemTable.Columns.Add("SAFE_STK_QTY", typeof(String));
                itemTable.Columns.Add("STK_LOCATION", typeof(String)); //
                itemTable.Columns.Add("STK_LOCATION_DETAIL", typeof(String)); //
                itemTable.Columns.Add("SCOMMENT", typeof(String)); //
                itemTable.Columns.Add("REG_EMP", typeof(String)); //

                itemTable.Columns.Add("INS_FLAG", typeof(String)); //
                itemTable.Columns.Add("AUTO_CREATE", typeof(Byte)); //
                itemTable.Columns.Add("AUTO_MARGIN", typeof(Byte)); //
                itemTable.Columns.Add("STK_MNG", typeof(Byte)); //
                itemTable.Columns.Add("STK_LOCATION_IMG", typeof(Byte[])); //
                itemTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow itemRow = itemTable.NewRow();
                itemRow["PLT_CODE"] = acInfo.PLT_CODE;
                itemRow["PART_CODE"] = layoutRow["TL_CODE"];
                itemRow["PART_NAME"] = layoutRow["TL_NAME"];
                itemRow["MAT_TYPE"] = acStdCodes.GetCodeByNameServer("S016", "구매품");
                itemRow["MAT_LTYPE"] = acStdCodes.GetCodeByNameServer("M001", "공구");
                itemRow["SPEC_TYPE"] = acStdCodes.GetCodeByNameServer("S062", "기타");
                itemRow["MAT_SPEC1"] = layoutRow["TL_SPEC"];
                itemRow["DRAW_NO"] = layoutRow["TL_SPEC"];
                itemRow["BAL_SPEC"] = layoutRow["TL_SPEC"];

                //itemRow["MAT_UNIT"] = layoutRow["TL_UNIT"];
                itemRow["MAT_UC"] = layoutRow["TL_UNITCOST"];
                itemRow["MAT_COST"] = layoutRow["TL_UNITCOST"];
                itemRow["MAIN_VND"] = layoutRow["MAIN_VND"];
                itemRow["SAFE_STK_QTY"] = layoutRow["TL_DANGER_QTY"];
                itemRow["STK_LOCATION"] = layoutRow["TOOL_LOCATION"];
                itemRow["STK_LOCATION_DETAIL"] = layoutRow["TOOL_LOCATION_DETAIL"];
                itemRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                itemRow["REG_EMP"] = acInfo.UserID;
                itemRow["INS_FLAG"] = 0;
                itemRow["AUTO_CREATE"] = 0;
                itemRow["AUTO_MARGIN"] = "0";
                itemRow["STK_MNG"] = 0;
                itemRow["OVERWRITE"] = "1";
                itemTable.Rows.Add(itemRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                paramSet.Tables.Add(itemTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                   "STD07A_INS3", paramSet, "RQSTDT", "RSLTDT",
                   QuickSaveClose,
                   QuickException);

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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row,true);
                }

                //저장 완료 후 첨부파일 컨트롤 활성화(키 입력)
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acAttachFileControl1.LinkKey = row["PLT_CODE"].ToString() + row["TL_CODE"].ToString();
                    this.acAttachFileControl1.ShowKey = new object[] { row["PLT_CODE"].ToString() + row["TL_CODE"].ToString() };
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                this.Close();
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
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                if (acMessageBox.Show(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow linkRow = this._LinkData as DataRow;


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = linkRow["TL_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.DEL,
                 "STD07A_DEL", paramSet, "RQSTDT", "RSLTDT",
                 QuickDEL,
                 QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }


        byte[] CreateImage(Image sourceImg)
        {
            ImageConverter imgConv = new ImageConverter();
            return (byte[])imgConv.ConvertTo(GetResizingImg(sourceImg), typeof(byte[]));
        }
        Image GetResizingImg(Image sourceImg)
        {
            if (sourceImg == null)
                return null;

            int width = 100;
            int height = width * sourceImg.Size.Height / sourceImg.Size.Width;

            Image destImg = new Bitmap(width, height,
                         System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(destImg))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(sourceImg,
                    new RectangleF(0, 0, width, height),
                    new RectangleF(new PointF(0, 0), sourceImg.Size),
                    GraphicsUnit.Pixel);
            }

            return destImg;
        }

        void GetQtyEachMC()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("TL_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["TL_CODE"] = layoutRow["TL_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "STD07A_SER3", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable dtGive = e.result.Tables["DT_GIVE"];
                DataTable dtReturn = e.result.Tables["DT_RETURN"];
                DataTable dtDisuse = e.result.Tables["DT_DISUSE"];

                _dtAllStatTool.Tables.Add(dtGive.Copy());
                _dtAllStatTool.Tables.Add(dtReturn.Copy());
                _dtAllStatTool.Tables.Add(dtDisuse.Copy());

                string jigubCode = acStdCodes.GetCodeByNameServer("T005", "지급");

                var dtMcGiveTmp = dtGive.AsEnumerable()
                                              .Where(w=>w["GIVE_STATE"].toStringEmpty().Equals(jigubCode))
                                              .GroupBy(g => new { MC_CODE = g.Field<string>("MC_CODE"), MC_NAME = g.Field<string>("MC_NAME") })
                                              .Select(r => new { MC_CODE = r.Key.MC_CODE, MC_NAME = r.Key.MC_NAME, CNT = r.Count() })
                                              .OrderBy(o => o.MC_NAME);

                DataTable paramTable = new DataTable();
                foreach (var row in dtMcGiveTmp)
                {
                    acGridView1.AddPopupContainerEdit(row.MC_CODE, row.MC_NAME, "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, this.popupContainerControl1);
                    (acGridView1.Columns[row.MC_CODE].ColumnEdit as RepositoryItemPopupContainerEdit).QueryPopUp += STD07A_D0A_QueryPopUp;
                    paramTable.Columns.Add(row.MC_CODE, typeof(decimal));
                }

                DataRow paramRow = paramTable.NewRow();
                foreach (var row in dtMcGiveTmp)
                {
                    paramRow[row.MC_CODE] = row.CNT;
                }
                paramTable.Rows.Add(paramRow);

                acGridView1.GridControl.DataSource = paramTable;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void STD07A_D0A_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                (sender as PopupContainerEdit).Properties.PopupControl = popupContainerControl1;
                SetGridViewData(acGridView1.FocusedColumn.FieldName);
            }
            catch(Exception ex)
            { }
        }
    }
}