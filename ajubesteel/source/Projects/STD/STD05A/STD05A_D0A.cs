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
using ControlManager;
using BizManager;


namespace STD
{
    public sealed partial class STD05A_D0A : BaseMenuDialog
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

        private string back_VenBizNo = string.Empty;

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        public STD05A_D0A(acGridView linkView, object linkData)
        {

            InitializeComponent();


            _LinkView = linkView;

            _LinkData = linkData;

            Initialize();
        }

        DataTable _dtDeleteCharge = null;

        private void Initialize()
        {
            acLayoutControl1.KeyColumns = new string[] { "VEN_CODE" };

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddHidden("VEN_CHARGE_ID", typeof(Int32));

            acGridView1.AddTextEdit("VEN_CODE", "거래처코드", "40957", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHARGE_EMP", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("CHARGE_GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, "C018");
            acGridView1.AddTextEdit("CHARGE_DEPT", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CHARGE_TEL", "담당자 전화번호", "WCO6Q0OP", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.TEL);
            acGridView1.AddTextEdit("CHARGE_HP", "담당자 휴대전화", "0SRN1JQ9", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.TEL);
            acGridView1.AddTextEdit("CHARGE_EMAIL", "E-MAIL", "40790", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, true, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "VEN_CHARGE_ID" };

            #region 수주 정보 Grid
            acGridView2.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ITEM_NAME", "수주명", "41906", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("ORD_DATE", "수주일", "40902", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddDateEdit("DUE_DATE", "출하예정일", "40111", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView2.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("DRAW_NO", "도면번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("CVND_CODE", "발주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("CVND_NAME", "발주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("PROD_QTY", "수량", "40345", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView2.AddTextEdit("MAT_SPEC1", "제품규격", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView2.AddTextEdit("PROD_COST", "수주가", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView2.AddTextEdit("ORD_AMT", "수주가", "40958", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView2.AddCheckEdit("ORD_VAT", "VAT포함", "SHXXZW1Z", true, false, true, acGridView.emCheckEditDataType._STRING);
            //acGridView2.AddTextEdit("BALJU_NUM", "발주번호", "40203", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("ITEM_SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "ITEM_CODE", "PART_CODE" };
            #endregion

            #region A/S 정보 Grid
            acGridView3.AddTextEdit("AS_NO", "A/S 접수코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("ITEM_CODE", "A/S 수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("PART_CODE", "A/S 품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddLookUpVendor("CVND_CODE", "발주처", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddTextEdit("AS_ITEM_CODE", "재작업 수주코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("SHIP_DATE", "출하일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddDateEdit("AS_DATE", "접수일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddLookUpEmp("AS_EMP", "접수자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView3.AddLookUpEdit("AS_STATE", "A/S 상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M041");
            acGridView3.AddLookUpEdit("AS_RESULT", "A/S 결과", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M040");
            acGridView3.AddDateEdit("AS_FINISH_DATE", "A/S 완료일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddLookUpEdit("AS_CAT", "A/S 유형", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M037");
            acGridView3.AddLookUpEdit("AS_GUBUN", "처리 구분", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M038");
            acGridView3.AddTextEdit("AS_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView3.AddTextEdit("AS_COST", "비용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView3.AddTextEdit("AS_CONTENTS", "접수 내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddTextEdit("AS_ACTION", "조치 내용", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView3.AddDateEdit("REG_DATE", "최초 작성일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView3.AddLookUpEmp("REG_EMP", "최초 작성자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView3.KeyColumn = new string[] { "AS_NO" };
            #endregion


            acGridView1.ShowGridMenuEx += acGridView1_ShowGridMenuEx;

            acGridView1.MouseDown += acGridView1_MouseDown;

            acGridView1.OnMapingRowChanged += acGridView1_OnMapingRowChanged;

            (acLayoutControl1.GetEditor("VEN_TYPE").Editor as acLookupEdit).SetCode("S019");

            (acLayoutControl1.GetEditor("VEN_CAT_CODE").Editor as acLookupEdit).SetCode("C015");

            (acLayoutControl1.GetEditor("VEN_COUNTRY").Editor as acLookupEdit).SetCode("S020");

            (acLayoutControl1.GetEditor("VEN_CREDIT").Editor as acLookupEdit).SetCode("C021");

            (acLayoutControl1.GetEditor("VEN_BANK").Editor as acLookupEdit).SetCode("C404");

            this._dtDeleteCharge = new DataTable("RQSTDT_CHARGE_DEL");

            this._dtDeleteCharge.Columns.Add("PLT_CODE", typeof(string));
            this._dtDeleteCharge.Columns.Add("VEN_CHARGE_ID", typeof(string));
        }

        public override void DialogInit()
        {

            base.DialogInit();
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["VEN_CODE"]);
            }
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

            }
        }

        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                }
                else
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow dRow = (DataRow)_LinkData;
            acLayoutControl1.DataBind(dRow, true);

            back_VenBizNo = dRow["VEN_BIZ_NO"].ToString();


            if (!dRow.isNull())
            {
                acAttachFileControl31.LinkKey = dRow["VEN_CODE"];
                acAttachFileControl31.ShowKey = new object[] { dRow["VEN_CODE"] };
            }

            DataSet paramSet = new DataSet();
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("VEN_CODE", typeof(String));
            paramTable.Columns.Add("CVND_CODE", typeof(String));
            
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["VEN_CODE"] = ((DataRow)_LinkData)["VEN_CODE"];
            paramRow["CVND_CODE"] = ((DataRow)_LinkData)["VEN_CODE"];
            paramTable.Rows.Add(paramRow);

            paramSet.Tables.Add(paramTable);


            DataSet result = BizRun.QBizRun.ExecuteService(this, "STD05A_SER2", paramSet,"RQSTDT", "RSLTDT");

            this.acGridView1.GridControl.DataSource = result.Tables["RSLTDT"];

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                this.acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_ITEM"];
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

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD05A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private DataSet SaveData(string overwrite)
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return null;
            }

            acGridView1.EndEditor();

            DataTable dtCharge = acGridView1.GetAddModifyRows();
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramCharge = new DataTable("RQSTDT_CHARGE");
            paramCharge.Columns.Add("PLT_CODE", typeof(String));
            paramCharge.Columns.Add("VEN_CODE", typeof(String));
            paramCharge.Columns.Add("CHARGE_EMP", typeof(String));
            paramCharge.Columns.Add("CHARGE_GUBUN", typeof(String));
            paramCharge.Columns.Add("CHARGE_TEL", typeof(String));
            paramCharge.Columns.Add("CHARGE_HP", typeof(String));
            paramCharge.Columns.Add("CHARGE_DEPT", typeof(String));
            paramCharge.Columns.Add("CHARGE_EMAIL", typeof(String));
            paramCharge.Columns.Add("SCOMMENT", typeof(String));
            paramCharge.Columns.Add("VEN_CHARGE_ID", typeof(int));

            foreach (DataRow dr in dtCharge.Rows)
            {
                DataRow paramChargeRow = paramCharge.NewRow();
                paramChargeRow["PLT_CODE"] = acInfo.PLT_CODE;

                if (!layoutRow["VEN_CODE"].isNullOrEmpty())
                    paramChargeRow["VEN_CODE"] = layoutRow["VEN_CODE"];

                paramChargeRow["CHARGE_EMP"] = dr["CHARGE_EMP"];
                paramChargeRow["CHARGE_GUBUN"] = dr["CHARGE_GUBUN"];
                paramChargeRow["CHARGE_TEL"] = dr["CHARGE_TEL"];
                paramChargeRow["CHARGE_HP"] = dr["CHARGE_HP"];
                paramChargeRow["CHARGE_DEPT"] = dr["CHARGE_DEPT"];
                paramChargeRow["CHARGE_EMAIL"] = dr["CHARGE_EMAIL"];
                paramChargeRow["SCOMMENT"] = dr["SCOMMENT"];
                paramChargeRow["VEN_CHARGE_ID"] = dr["VEN_CHARGE_ID"];

                paramCharge.Rows.Add(paramChargeRow);
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_NAME", typeof(String)); //
            paramTable.Columns.Add("VEN_TYPE", typeof(String)); //
            paramTable.Columns.Add("VEN_CAT_CODE", typeof(String)); //
            paramTable.Columns.Add("VEN_COUNTRY", typeof(String)); //
            paramTable.Columns.Add("VEN_ACCOUNT", typeof(String)); //
            paramTable.Columns.Add("VEN_CEO", typeof(String)); //
            paramTable.Columns.Add("VEN_BIZ_NO", typeof(String)); //
            paramTable.Columns.Add("VEN_ID_NO", typeof(String)); //
            paramTable.Columns.Add("VEN_START_DATE", typeof(String)); //
            paramTable.Columns.Add("VEN_BANK", typeof(String)); //
            paramTable.Columns.Add("VEN_BANK_NO", typeof(String)); //
            paramTable.Columns.Add("VEN_CREDIT", typeof(String)); //
            paramTable.Columns.Add("VEN_ZIP", typeof(String)); //
            paramTable.Columns.Add("VEN_ADDRESS", typeof(String)); //
            paramTable.Columns.Add("VEN_ZIP2", typeof(String)); //
            paramTable.Columns.Add("VEN_ADDRESS2", typeof(String)); //
            paramTable.Columns.Add("VEN_ZIP3", typeof(String)); //
            paramTable.Columns.Add("VEN_ADDRESS3", typeof(String)); //
            paramTable.Columns.Add("VEN_TEL", typeof(String)); //
            paramTable.Columns.Add("VEN_FAX", typeof(String)); //
            paramTable.Columns.Add("VEN_EMAIL", typeof(String)); //
            paramTable.Columns.Add("VEN_EMAIL_CC", typeof(String)); //
            paramTable.Columns.Add("VEN_PRODUCTS", typeof(String)); //
            paramTable.Columns.Add("VEN_CHARGE_EMP", typeof(String)); //
            paramTable.Columns.Add("VEN_CHARGE_TEL", typeof(String)); //
            paramTable.Columns.Add("VEN_CHARGE_HP", typeof(String)); //
            paramTable.Columns.Add("IF_VEN_CODE", typeof(String)); //

            paramTable.Columns.Add("ENG_VEN_NAME", typeof(String)); //
            paramTable.Columns.Add("ENG_VEN_ADDR", typeof(String)); //
            paramTable.Columns.Add("ENG_VEN_ADDR2", typeof(String)); //

            paramTable.Columns.Add("VEN_HOMEPAGE", typeof(String)); //
            paramTable.Columns.Add("VEN_PAYMENT", typeof(String)); //
            paramTable.Columns.Add("VEN_DEADLINE", typeof(String)); //
            paramTable.Columns.Add("VEN_TAX", typeof(String)); //

            paramTable.Columns.Add("SCOMMENT", typeof(String)); //
            paramTable.Columns.Add("IS_MYVENDOR", typeof(Byte)); //
            paramTable.Columns.Add("USE_GLOBAL", typeof(Byte)); //

            paramTable.Columns.Add("VEN_CONDITIONS", typeof(String));

            //20160517 김준구 - 수주번호 자동채번
            //paramTable.Columns.Add("ITEM_AUTO_CODE", typeof(String)); //

            paramTable.Columns.Add("REG_EMP", typeof(String)); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            if (!layoutRow["VEN_CODE"].isNullOrEmpty())
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];

            paramRow["VEN_NAME"] = layoutRow["VEN_NAME"];
            paramRow["VEN_TYPE"] = layoutRow["VEN_TYPE"];
            paramRow["VEN_CAT_CODE"] = layoutRow["VEN_CAT_CODE"];
            paramRow["VEN_COUNTRY"] = layoutRow["VEN_COUNTRY"];
            paramRow["VEN_ACCOUNT"] = layoutRow["VEN_ACCOUNT"];
            paramRow["VEN_CEO"] = layoutRow["VEN_CEO"];
            paramRow["VEN_BIZ_NO"] = layoutRow["VEN_BIZ_NO"];
            paramRow["VEN_ID_NO"] = layoutRow["VEN_ID_NO"];
            paramRow["VEN_START_DATE"] = layoutRow["VEN_START_DATE"];

            paramRow["VEN_HOMEPAGE"] = layoutRow["VEN_HOMEPAGE"];
            paramRow["VEN_PAYMENT"] = layoutRow["VEN_PAYMENT"];
            paramRow["VEN_DEADLINE"] = layoutRow["VEN_DEADLINE"];
            paramRow["VEN_TAX"] = layoutRow["VEN_TAX"];

            paramRow["VEN_BANK"] = layoutRow["VEN_BANK"];
            paramRow["VEN_BANK_NO"] = layoutRow["VEN_BANK_NO"];
            paramRow["VEN_CREDIT"] = layoutRow["VEN_CREDIT"];
            paramRow["VEN_ZIP"] = layoutRow["VEN_ZIP"];
            paramRow["VEN_ADDRESS"] = layoutRow["VEN_ADDRESS"];
            paramRow["VEN_ZIP2"] = layoutRow["VEN_ZIP2"];
            paramRow["VEN_ADDRESS2"] = layoutRow["VEN_ADDRESS2"];
            paramRow["VEN_ZIP3"] = layoutRow["VEN_ZIP3"];
            paramRow["VEN_ADDRESS3"] = layoutRow["VEN_ADDRESS3"];
            paramRow["VEN_TEL"] = layoutRow["VEN_TEL"];
            paramRow["VEN_FAX"] = layoutRow["VEN_FAX"];
            paramRow["VEN_EMAIL"] = layoutRow["VEN_EMAIL"];
            paramRow["VEN_EMAIL_CC"] = layoutRow["VEN_EMAIL_CC"];
            paramRow["VEN_PRODUCTS"] = layoutRow["VEN_PRODUCTS"];
            paramRow["VEN_CHARGE_EMP"] = layoutRow["VEN_CHARGE_EMP"];
            paramRow["VEN_CHARGE_TEL"] = layoutRow["VEN_CHARGE_TEL"];
            paramRow["VEN_CHARGE_HP"] = layoutRow["VEN_CHARGE_HP"];
            //paramRow["IF_VEN_CODE"] = layoutRow["IF_VEN_CODE"];
            paramRow["IS_MYVENDOR"] = layoutRow["IS_MYVENDOR"];
            paramRow["USE_GLOBAL"] = layoutRow["USE_GLOBAL"];

            paramRow["ENG_VEN_NAME"] = layoutRow["ENG_VEN_NAME"];
            paramRow["ENG_VEN_ADDR"] = layoutRow["ENG_VEN_ADDR"];
            paramRow["ENG_VEN_ADDR2"] = layoutRow["ENG_VEN_ADDR2"];

            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

            paramRow["VEN_CONDITIONS"] = layoutRow["VEN_CONDITIONS"];

            paramRow["REG_EMP"] = acInfo.UserID;
            //btnSave - 0
            //btnSaveClose - 1
            paramRow["OVERWRITE"] = overwrite;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);
            paramSet.Tables.Add(paramCharge);
            paramSet.Tables.Add(this._dtDeleteCharge.Copy());

            return paramSet;

        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {

                DataSet paramSet = SaveData("1");

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD05A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
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

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

                DataSet paramSet = SaveData("0");

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD05A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

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
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this.acLayoutControl1.DataBind(row, false);
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
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


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {


            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();


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


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acMessageBox.Show(this, "담당자 정보를 삭제하시겠습니까?", "TB43FSY3", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                //DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("VEN_CHARGE_ID", typeof(String)); //

                DataRow paramRow = this._dtDeleteCharge.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["VEN_CHARGE_ID"] = acGridView1.GetFocusedDataRow()["VEN_CHARGE_ID"];

                this._dtDeleteCharge.Rows.Add(paramRow);


                acGridView1.DeleteMappingRow(paramRow);
                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(
                //this, QBiz.emExecuteType.DEL,
                //"STD05A_DEL2", paramSet, "RQSTDT", "",
                //QuickDEL2,
                //QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDEL2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);
                }

                //this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acTextEdit5_EditValueChanged(object sender, EventArgs e)
        {
            // 사업자등록번호 중복검사
            try
            {
             
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                    if (layoutRow["VEN_BIZ_NO"].ToString().Length == 12) //사업자등록번호는 12자
                    {
                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("VEN_CODE", typeof(String)); 
                        paramTable.Columns.Add("VEN_BIZ_NO", typeof(String)); 

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                        paramRow["VEN_BIZ_NO"] = layoutRow["VEN_BIZ_NO"];

                        paramTable.Rows.Add(paramRow);
                        DataSet paramSet = new DataSet();
                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.DEL,
                        "STD05A_SER5", paramSet, "RQSTDT", "",
                        QuickSearch2,
                        QuickException);
                    }
                    else
                    {
                        return;
                    }
                
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
                if (e.result.Tables["RSLTDT"].Rows.Count > 0)
                {
                   
                    string RqVenCode = e.result.Tables["RQSTDT"].Rows[0]["VEN_CODE"].ToString();
                    string RqBizNo = e.result.Tables["RQSTDT"].Rows[0]["VEN_BIZ_NO"].ToString();
                    string RsVenCode = e.result.Tables["RSLTDT"].Rows[0]["VEN_CODE"].ToString(); 
                    string RsBizNo = e.result.Tables["RSLTDT"].Rows[0]["VEN_BIZ_NO"].ToString();

                    if (RqVenCode == RsVenCode && RqBizNo == RsBizNo)
                    {
                        // 현재 다이얼로그상 거래처코드와 사업자등록번호가 중복조회로 읽어온 결과 값과 
                        // 모두 일치하면 중복으로 보지 않음 
                        return;
                    }
                    else
                    {
                        if (acMessageBox.Show("동일한 사업자등록번호가 존재합니다.", "알림", acMessageBox.emMessageBoxType.CONFIRM) == DialogResult.OK)
                        {
                            if(this.DialogMode == emDialogMode.NEW)
                            {
                                acLayoutControl1.GetEditor("VEN_BIZ_NO").Clear();
                            }    
                            else
                            {
                                acLayoutControl1.GetEditor("VEN_BIZ_NO").Value = back_VenBizNo;
                            }
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}