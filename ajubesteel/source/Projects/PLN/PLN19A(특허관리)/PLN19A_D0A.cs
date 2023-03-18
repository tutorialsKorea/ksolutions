using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;
using DevExpress.XtraEditors.Mask;
using System.Threading;

namespace PLN
{
    public sealed partial class PLN19A_D0A : BaseMenuDialog
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


        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

        private acGridView _LinkView = null;

        string _saveMode = "";
        public PLN19A_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;


        }

        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("NATION") as acLookupEdit).SetCode("S022");
            (acLayoutControl1.GetEditor("PATENT_STATE") as acLookupEdit).SetCode("S028");

            acLayoutControl1.GetEditor("NATION").Value = "KOR";
            acLayoutControl1.GetEditor("PATENTEE").Value = "디플러스(주)";
            acLayoutControl1.GetEditor("PATENT_STATE").Value = '0';
          
            // 출원번호 마스크 설정
            acTextEdit4.Properties.MaskSettings.Configure<MaskSettings.RegExp>(settings => {settings.MaskExpression = @"(\d{2}\-\d{4}\-\d{7})";});
            acTextEdit4.Properties.UseMaskAsDisplayFormat = true;

            // 등록번호 마스크 설정
            acTextEdit5.Properties.MaskSettings.Configure<MaskSettings.RegExp>(settings => { settings.MaskExpression = @"(\d{2}\-\d{7})"; });
            acTextEdit5.Properties.UseMaskAsDisplayFormat = true;

            base.DialogInit();

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

            acLayoutControl1.DataBind((DataRow)_LinkData, true);

            DataRow linkRow = this._LinkData as DataRow;

            acAttachFileControl21.LinkKey = linkRow["PATENT_CODE"];
            acAttachFileControl21.ShowKey = new object[] { linkRow["PATENT_CODE"] };
          
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                if (acMessageBox.Show(this, "초기화 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("TITLE").FocusEdit();

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
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PATENT_CODE", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("PATENT_NO", typeof(String)); //
                paramTable.Columns.Add("PATENT_DATE", typeof(String)); //
                paramTable.Columns.Add("PATENT_REG_NO", typeof(String)); //
                paramTable.Columns.Add("PATENT_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("PATENTEE", typeof(String)); //
                paramTable.Columns.Add("INVENTOR", typeof(String)); //
                paramTable.Columns.Add("PATENT_FIELD", typeof(String)); //
                paramTable.Columns.Add("PATENT_IMG", typeof(byte[])); //
                paramTable.Columns.Add("NATION", typeof(String)); //
                paramTable.Columns.Add("KOR_TITLE", typeof(String)); //
                paramTable.Columns.Add("ENG_TITLE", typeof(String)); //
                paramTable.Columns.Add("PATENT_STATE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //paramRow["PATENT_CODE"] = "";
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["PATENT_NO"] = layoutRow["PATENT_NO"];
                paramRow["PATENT_DATE"] = layoutRow["PATENT_DATE"].toDateString("yyyyMMdd");
                paramRow["PATENT_REG_NO"] = layoutRow["PATENT_REG_NO"];
                paramRow["PATENT_REG_DATE"] = layoutRow["PATENT_REG_DATE"].toDateString("yyyyMMdd");
                paramRow["PATENTEE"] = layoutRow["PATENTEE"];
                paramRow["INVENTOR"] = layoutRow["INVENTOR"];
                paramRow["PATENT_FIELD"] = layoutRow["PATENT_FIELD"];
                paramRow["PATENT_IMG"] = layoutRow["PATENT_IMG"];
                paramRow["NATION"] = layoutRow["NATION"];
                paramRow["KOR_TITLE"] = layoutRow["KOR_TITLE"];
                paramRow["ENG_TITLE"] = layoutRow["ENG_TITLE"];
                paramRow["NATION"] = layoutRow["NATION"];
                paramRow["PATENT_STATE"] = layoutRow["PATENT_STATE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "PLN19A_INS2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSave,
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
                    this._LinkView.UpdateMapingRow(row, true);
                }

                acAttachFileControl21.LinkKey = e.result.Tables["RSLTDT"].Rows[0]["PATENT_CODE"];
                acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RSLTDT"].Rows[0]["PATENT_CODE"] };
                acAttachFileControl21.UploadFile();

                this.ControlBox = false;
                _saveMode = "SaveClose";
                barItemSave.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장후 닫기
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PATENT_CODE", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("PATENT_NO", typeof(String)); //
                paramTable.Columns.Add("PATENT_DATE", typeof(String)); //
                paramTable.Columns.Add("PATENT_REG_NO", typeof(String)); //
                paramTable.Columns.Add("PATENT_REG_DATE", typeof(String)); //
                paramTable.Columns.Add("PATENTEE", typeof(String)); //
                paramTable.Columns.Add("INVENTOR", typeof(String)); //
                paramTable.Columns.Add("PATENT_FIELD", typeof(String)); //
                paramTable.Columns.Add("PATENT_IMG", typeof(byte[])); //
                paramTable.Columns.Add("NATION", typeof(String)); //
                paramTable.Columns.Add("KOR_TITLE", typeof(String)); //
                paramTable.Columns.Add("ENG_TITLE", typeof(String)); //
                paramTable.Columns.Add("PATENT_STATE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PATENT_CODE"] = linkRow["PATENT_CODE"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["PATENT_NO"] = layoutRow["PATENT_NO"];
                paramRow["PATENT_DATE"] = layoutRow["PATENT_DATE"].toDateString("yyyyMMdd");
                paramRow["PATENT_REG_NO"] = layoutRow["PATENT_REG_NO"];
                paramRow["PATENT_REG_DATE"] = layoutRow["PATENT_REG_DATE"].toDateString("yyyyMMdd");
                paramRow["PATENTEE"] = layoutRow["PATENTEE"];
                paramRow["INVENTOR"] = layoutRow["INVENTOR"];
                paramRow["PATENT_FIELD"] = layoutRow["PATENT_FIELD"];
                paramRow["PATENT_IMG"] = layoutRow["PATENT_IMG"];
                paramRow["NATION"] = layoutRow["NATION"];
                paramRow["KOR_TITLE"] = layoutRow["KOR_TITLE"];
                paramRow["ENG_TITLE"] = layoutRow["ENG_TITLE"];
                paramRow["PATENT_STATE"] = layoutRow["PATENT_STATE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["MDFY_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "PLN19A_INS2", paramSet, "RQSTDT", "RSLTDT",
                            QuickSaveClose,
                            QuickException);

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


                acAttachFileControl21.UploadFile();


                this.ControlBox = false;
                _saveMode = "SaveClose";
                barItemSaveClose.Enabled = false;
                barItemDelete.Enabled = false;
                System.Threading.Thread closeTh = new System.Threading.Thread(formClose);
                closeTh.Start();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void formClose()
        {
            while (true)
            {
                if (acAttachFileControl21.isComplete == true)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }

            if (acAttachFileControl21.isComplete == true)
            {
                this.Invoke(new MethodInvoker(end));
            }
        }

        void end()
        {
            if (_saveMode == "Save")
            {
                barItemSave.Enabled = true;
                this.ControlBox = true;
            }
            else if (_saveMode == "SaveClose")
            {
                _LinkView.RaiseFocusedRowChanged();
                this.Close();
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


                DataRow linkRow = (DataRow)_LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PATENT_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PATENT_CODE"] = linkRow["PATENT_CODE"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "PLN19A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkView.DeleteMappingRow(row);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);

        }


        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("PATENT_DATE").Value = DateTime.Now;
                layout.GetEditor("PATENT_REG_DATE").Value = DateTime.Now;
             
            }

            base.ChildContainerInit(sender);
        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
    }

}