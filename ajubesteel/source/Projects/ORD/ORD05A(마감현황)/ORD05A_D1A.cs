using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraEditors.Controls;
using BizManager;
using DevExpress.XtraEditors.Repository;

namespace ORD
{
    public sealed partial class ORD05A_D1A : BaseMenuDialog
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


        private string _type = "TAX";

        private string _prod_code = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">TRADE:거래명세표, TAX:세금계산서</param>
        public ORD05A_D1A(string type, string prod_code)
        {
            InitializeComponent();

            this._type = type;

            this._prod_code = prod_code;

            this.Text = "세금계산서 발행내역 수정 및 삭제";

            if(type == "TRADE")
                this.Text = "거래명세표 발행내역 수정 및 삭제";
            else if(type == "TAX")
                this.Text = "세금계산서 발행내역 수정 및 삭제";
            else if (type == "COL")
                this.Text = "수금내역 수정 및 삭제";

            if (type == "COL")
            {
                acGridView1.GridType = acGridView.emGridType.LIST;
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("BILL_DATE", "수금일자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpEmp("BILL_EMP", "수금자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddTextEdit("BILL_QTY", "수량", "40239", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("BILL_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView1.AddButtonEdit("BILL_DEL", "삭제", "40338", false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.HideTextEditor, true, true, false);
                acGridView1.AddHidden("BILL_NO", typeof(string));
            }
            else if (type == "TRADE")
            {
                acGridView1.GridType = acGridView.emGridType.LIST;
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("BILL_DATE", "발행일자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpEmp("BILL_EMP", "발행자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddTextEdit("BILL_QTY", "수량", "40239", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("BILL_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView1.AddButtonEdit("BILL_DEL", "삭제", "40338", false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.HideTextEditor, true, true, false);
                acGridView1.AddHidden("BILL_NO", typeof(string));
            }
            else if (type == "TAX")
            {
                acGridView1.GridType = acGridView.emGridType.LIST;
                acGridView1.AddTextEdit("PROD_CODE", "수주번호", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("BILL_DATE", "발행일자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddLookUpEmp("BILL_EMP", "발행자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddDateEdit("COL_PLAN_DATE", "수금예정일자", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);
                acGridView1.AddTextEdit("BILL_QTY", "수량", "40239", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddTextEdit("BILL_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
                acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, true, false, true, false);
                acGridView1.AddButtonEdit("BILL_DEL", "삭제", "40338", false, DevExpress.Utils.HorzAlignment.Center, TextEditStyles.HideTextEditor, true, true, false);
                acGridView1.AddHidden("BILL_NO", typeof(string));
            }



            acGridView1.KeyColumn = new string[] { "BILL_NO" };

            //acGridView1.Columns["BILL_DEL"].ColumnEdit.Click += BillDelete_Click;
            RepositoryItemButtonEdit riBtnEdit = acGridView1.Columns["BILL_DEL"].ColumnEdit as RepositoryItemButtonEdit;

            EditorButton button = new EditorButton(ButtonPredefines.Glyph, string.Empty, -1, true, true, false, ImageLocation.MiddleCenter, ChangeIconColor(global::ORD.Resource.remove_sign_1x, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor()));
            button.ToolTip = "삭제";

            riBtnEdit.Buttons.Clear();
            riBtnEdit.Buttons.Add(button);

            button.Click += BillDelete_Click;


        }


        private Bitmap ChangeIconColor(Image img, Color iconColor)
        {
            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    //if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }

        private void BillDelete_Click(object sender, EventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            dtBillDelete.ImportRow(focusRow);

            acGridView1.DeleteMappingRow(focusRow);
        }


        DataTable dtBillUpdate = null;
        DataTable dtBillDelete = null;

        public override void DialogInit()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BILL_TYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BILL_TYPE"] = this._type;
            paramRow["PROD_CODE"] = this._prod_code;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataTable dtBill = BizRun.QBizRun.ExecuteService(this, "ORD05A_SER2", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];


            dtBillUpdate = dtBill.Clone();
            dtBillDelete = dtBill.Clone();

            acGridView1.GridControl.DataSource = dtBill;


            base.DialogInit();

        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView1.EndEditor();

                DataSet dataSet = new DataSet();

                DataTable dtMdfy = acGridView1.GetAddModifyRows();

                foreach(DataRow row in dtMdfy.Rows)
                {
                    DataRow newRow = dtBillUpdate.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["BILL_NO"] = row["BILL_NO"];
                    newRow["BILL_TYPE"] = row["BILL_TYPE"];
                    newRow["PROD_CODE"] = row["PROD_CODE"];
                    newRow["BILL_EMP"] = row["BILL_EMP"];
                    newRow["BILL_DATE"] = row["BILL_DATE"].toDateString("yyyyMMdd");
                    newRow["SCOMMENT"] = row["SCOMMENT"];
                    newRow["BILL_QTY"] = row["BILL_QTY"];
                    newRow["BILL_AMT"] = row["BILL_AMT"];
                    newRow["COL_PLAN_DATE"] = row["COL_PLAN_DATE"].toDateString("yyyyMMdd");



                    dtBillUpdate.Rows.Add(newRow);
                }


                if (dtMdfy.Rows.Count == 0)
                {
                    DataRow newRow = dtBillUpdate.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["PROD_CODE"] = this._prod_code;

                    dtBillUpdate.Rows.Add(newRow);
                }


                dtBillUpdate.TableName = "RQSTDT";
                dtBillDelete.TableName = "RQSTDT_DEL";
               

                dataSet.Tables.Add(dtBillUpdate);
                dataSet.Tables.Add(dtBillDelete);

                this.OutputData = dataSet;

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}