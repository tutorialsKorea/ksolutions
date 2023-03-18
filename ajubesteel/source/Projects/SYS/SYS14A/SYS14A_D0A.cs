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

namespace SYS
{
    public sealed partial class SYS14A_D0A : BaseMenuDialog
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

        private acBandGridView _LinkBandView = null;

        private string _workType = string.Empty;

        private string _copy = string.Empty;


        public SYS14A_D0A(acGridView linkView, acBandGridView linkBandView, object linkData, string workType, string copy = "non")
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;

            _LinkBandView = linkBandView;

            _workType = workType;

            _copy = copy;
        }

        public override void DialogInit()
        {

            (acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).SetCode("S095");
            (acLayoutControl1.GetEditor("DLOG_TYPE") as acLookupEdit).SetCode("S096");
            (acLayoutControl1.GetEditor("DLOG_PERIOD") as acLookupEdit).SetCode("S097");
            //(acLayoutControl1.GetEditor("DLOG_PLAN") as acLookupEdit).SetCode("S098");
            (acLayoutControl1.GetEditor("RELATED_PROD") as acLookupEdit).SetCode("S099");

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).Value = _workType;
            //(acLayoutControl1.GetEditor("DLOG_CAT") as acLookupEdit).isReadyOnly = true;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            base.DialogInit();

        }

        private void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            try
            {
                acLayoutControl layout = sender as acLayoutControl;

                switch (info.ColumnName)
                {
                    case "DLOG_PERIOD":

                        (layout.GetEditor("DLOG_PLAN").Editor as acLookupEdit).SetCode("S098", newValue);

                        break;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        public override void DialogNew()
        {
            //새로만들기

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("WORK_DATE").Value = acDateEdit.GetNowDateFromServer();

        }

        public override void DialogOpen()
        {
            //열기

            acLayoutControl1.DataBind((DataRow)_LinkData, true);

            if (_copy == "COPY")
            {
                barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                acLayoutControl1.GetEditor("WORK_DATE").Value = acDateEdit.GetNowDateFromServer();
            }
            else
            {
                barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                acAttachFileControl21.LinkKey = ((DataRow)_LinkData)["DLOG_ID"];
                acAttachFileControl21.ShowKey = new object[] { ((DataRow)_LinkData)["DLOG_ID"] };
            }

            
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("WORK_DATE").FocusEdit();

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
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("RELATED_EMP", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                paramTable.Columns.Add("DLOG_CAT", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("DLOG_PERIOD", typeof(String)); //
                paramTable.Columns.Add("DLOG_PLAN", typeof(String)); //
                paramTable.Columns.Add("DLOG_TIME", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("DLOG_ACT_FLAG", typeof(byte)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = "";
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["WORK_DATE"] = layoutRow["WORK_DATE"].toDateString("yyyyMMdd");
                paramRow["RELATED_EMP"] = layoutRow["RELATED_EMP"];
                paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramRow["DLOG_CAT"] = layoutRow["DLOG_CAT"];
                paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                paramRow["DLOG_PERIOD"] = layoutRow["DLOG_PERIOD"];
                paramRow["DLOG_PLAN"] = layoutRow["DLOG_PLAN"];
                paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["DLOG_ACT_FLAG"] = 1;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "SYS14A_INS2", paramSet, "RQSTDT", "RSLTDT",
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
                if (_workType == "A")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }
                else if (_workType == "P")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkBandView.UpdateMapingRow(row, true);
                    }
                }

                acAttachFileControl21.LinkKey = e.result.Tables["RQSTDT"].Rows[0]["DLOG_ID"];
                acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RQSTDT"].Rows[0]["DLOG_ID"] };
                acAttachFileControl21.UploadFile();

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
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //
                paramTable.Columns.Add("VEN_CODE", typeof(String)); //
                paramTable.Columns.Add("WORK_DATE", typeof(String)); //
                paramTable.Columns.Add("RELATED_EMP", typeof(String)); //
                paramTable.Columns.Add("RELATED_PROD", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //

                paramTable.Columns.Add("DLOG_CAT", typeof(String)); //
                paramTable.Columns.Add("DLOG_TYPE", typeof(String)); //
                paramTable.Columns.Add("DLOG_PERIOD", typeof(String)); //
                paramTable.Columns.Add("DLOG_PLAN", typeof(String)); //
                paramTable.Columns.Add("DLOG_TIME", typeof(decimal)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable.Columns.Add("DLOG_ACT_FLAG", typeof(byte)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = linkRow["DLOG_ID"];
                paramRow["VEN_CODE"] = layoutRow["VEN_CODE"];
                paramRow["WORK_DATE"] = layoutRow["WORK_DATE"].toDateString("yyyyMMdd");
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["RELATED_EMP"] = layoutRow["RELATED_EMP"];
                paramRow["RELATED_PROD"] = layoutRow["RELATED_PROD"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["REG_EMP"] = acInfo.UserID;

                paramRow["DLOG_CAT"] = layoutRow["DLOG_CAT"];
                paramRow["DLOG_TYPE"] = layoutRow["DLOG_TYPE"];
                paramRow["DLOG_PERIOD"] = layoutRow["DLOG_PERIOD"];
                paramRow["DLOG_PLAN"] = layoutRow["DLOG_PLAN"];
                paramRow["DLOG_TIME"] = layoutRow["DLOG_TIME"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramRow["DLOG_ACT_FLAG"] = 1;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS14A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                if (_workType == "A")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }
                else if (_workType == "P")
                {
                    foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                    {
                        this._LinkBandView.UpdateMapingRow(row, true);
                    }
                }

                acAttachFileControl21.UploadFileWaitThread(3);

               if (acAttachFileControl21.isComplete == true)
               {
                    this.Close();
               }


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


                DataRow linkRow = (DataRow)_LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("DLOG_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["DLOG_ID"] = linkRow["DLOG_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS14A_DEL", paramSet, "RQSTDT", "",
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
                if (_workType == "A")
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        this._LinkView.DeleteMappingRow(row);
                    }
                }
                else if (_workType == "P")
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        this._LinkBandView.DeleteMappingRow(row);
                    }
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


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
    }
}