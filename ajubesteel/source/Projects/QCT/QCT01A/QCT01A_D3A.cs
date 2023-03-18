using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using BizManager;

namespace QCT
{
    public sealed partial class QCT01A_D3A : BaseMenuDialog
    {

        QCT01A_M0A _parentForm = null;

        private DataRow linkRow;
        public DataRow _LinkRow { get => linkRow; set => linkRow = value; }

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

        public QCT01A_D3A(QCT01A_M0A parentForm, DataRow linkRow)
        {
            InitializeComponent();

            this._parentForm = parentForm;
            this._LinkRow = linkRow;
        }

        public override void DialogInit()
        {
            base.DialogInit();

            //주원인
            (acLayoutControl1.GetEditor("MASTER_CAUSE").Editor as acLookupEdit).SetCode("C402");

            (acLayoutControl1.GetEditor("DETAIL_CAUSE").Editor as acLookupEdit).SetCode("C402");
            //불량형태
            (acLayoutControl1.GetEditor("NG_TYPE").Editor as acLookupEdit).SetCode("Q006");
            //불량비용항목
            //(acLayoutControl1.GetEditor("NG_COST_CODE").Editor as acLookupEdit).SetCode("M036","FCOST");
            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;
            //acLayoutControl1.DataBind(_LinkRow, true);
        }

        public override void DialogOpen()
        {
            base.DialogOpen();

            acLayoutControl1.DataBind(_LinkRow, true);

            acLayoutControl1.GetEditor("NG_MAT_COST").Value = _LinkRow["NG_QTY"].toInt() * _LinkRow["UNIT_COST"].toDouble();

        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();

            //DataTable paramTable = _LinkRow.NewTable();
            //DataSet paramSet = new DataSet();
            //paramSet.Tables.Add(paramTable);
            //paramTable.TableName = "RQSTDT";

            //BizRun.QBizRun.ExecuteService(this, "QCT01B_SER", paramSet, "RQSTDT", "RSLTDT");
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "MASTER_CAUSE":
                    //사내불량 상세원인 설정
                    (layout.GetEditor("DETAIL_CAUSE").Editor as acLookupEdit).SetCode("C401", newValue);
                    break;
                //case "NG_MAT_COST":
                //    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_OTHER_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_THIS_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PRE_COST").Value.toDecimal()
                //                                                + newValue.toDecimal();
                //    break;
                //case "NG_OTHER_OUT_COST":
                //    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_THIS_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PRE_COST").Value.toDecimal()
                //                                                + newValue.toDecimal();
                //    break;
                //case "NG_PROC_COST":
                //    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_OTHER_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_THIS_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PRE_COST").Value.toDecimal()
                //                                                + newValue.toDecimal();
                //    break;
                //case "NG_THIS_OUT_COST":
                //    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_OTHER_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PRE_COST").Value.toDecimal()
                //                                                + newValue.toDecimal();
                //    break;
                //case "NG_PRE_COST":
                //    acLayoutControl1.GetEditor("NG_COST").Value = acLayoutControl1.GetEditor("NG_MAT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_OTHER_OUT_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_PROC_COST").Value.toDecimal()
                //                                                + acLayoutControl1.GetEditor("NG_THIS_OUT_COST").Value.toDecimal()
                //                                                + newValue.toDecimal();
                //    break;
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void btnReItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (acTextEdit2.Text.isNullOrEmpty() == false)
                //{
                //    acMessageBox.Show(this, "이미 재생성된 수주코드가 존재합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                if (acMessageBox.Show(this, "현재 발주내역으로 재발주하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = _LinkRow as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("NG_ID", typeof(String)); //
                paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //
                paramTable.Columns.Add("BALJU_GUBUN", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["NG_ID"] = _LinkRow["NG_ID"];
                paramRow["BALJU_NUM"] = _LinkRow["BALJU_NUM"];
                paramRow["BALJU_SEQ"] = _LinkRow["BALJU_SEQ"];
                paramRow["BALJU_GUBUN"] = _LinkRow["BALJU_NUM"].ToString().StartsWith("MB") ? "MB":"OB";
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["WO_NO"] = _LinkRow["WO_NO"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);
                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_INS6", paramSet, "RQSTDT", "RSLTDT",
                    QuickRe,
                    QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickRe(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this.acLayoutControl1.DataBind(row, false);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                acMessageBox.Show(this, ex);

                if (this.DialogMode == emDialogMode.NEW)
                {
                    //클리어
                    //this.barItemClear_ItemClick(null, null);
                }
                else if (this.DialogMode == emDialogMode.OPEN)
                {
                    this.Close();
                    //갱신
                    ((BaseMenu)this.ParentControl).DataRefresh(null);
                }
            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnProcLink_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _parentForm.Menu_Link((DataRow)_LinkRow, "PLN01A");
        }
    }
}

