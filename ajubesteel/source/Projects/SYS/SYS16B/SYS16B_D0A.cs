using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS16B_D0A : BaseMenuDialog
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

        private string ISSU_FILE_ID = string.Empty;
        private string SOL_FILE_ID = string.Empty;
        private string RPT_FILE_ID = string.Empty;


        public SYS16B_D0A(acGridView linkView, object linkData)
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

            base.DialogInit();

        }

       

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("PROPS_DATE").Value = DateTime.Now;

            }

            base.ChildContainerInit(sender);
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

            acAttachFileControl21.LinkKey = linkRow["ISSU_FILE_ID"];
            acAttachFileControl21.ShowKey = new object[] { linkRow["ISSU_FILE_ID"] };
            acAttachFileControl21.UploadFile();

            acAttachFileControl22.LinkKey = linkRow["SOL_FILE_ID"];
            acAttachFileControl22.ShowKey = new object[] { linkRow["SOL_FILE_ID"] };
            acAttachFileControl22.UploadFile();

            acAttachFileControl23.LinkKey = linkRow["RPT_FILE_ID"];
            acAttachFileControl23.ShowKey = new object[] { linkRow["RPT_FILE_ID"] };
            acAttachFileControl23.UploadFile();

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

                acLayoutControl1.GetEditor("PROPS_DATE").FocusEdit();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region 저장
            //try
            //{
            //    if (acLayoutControl1.ValidCheck() == false)
            //    {
            //        return;
            //    }

            //    DataRow layoutRow = acLayoutControl1.CreateParameterRow();


            //    DataTable paramTable = new DataTable("RQSTDT");
            //    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            //    paramTable.Columns.Add("PROPS_ID", typeof(String)); //
            //    paramTable.Columns.Add("PROPS_DATE", typeof(String)); //
            //    paramTable.Columns.Add("ORG_CODE", typeof(String)); //
            //    paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            //    paramTable.Columns.Add("PROC_NAME", typeof(String)); //
            //    paramTable.Columns.Add("TITLE", typeof(String)); //
            //    paramTable.Columns.Add("AS_IS", typeof(String)); //
            //    paramTable.Columns.Add("TO_BE", typeof(String)); //
            //    paramTable.Columns.Add("EXP_EFFECT", typeof(String)); //
            //    paramTable.Columns.Add("EXP_FINISH_DATE", typeof(String)); //
            //    paramTable.Columns.Add("FINISH_DATE", typeof(String)); //

            //    paramTable.Columns.Add("REWARD", typeof(Decimal)); //
            //    paramTable.Columns.Add("REWARD_DATE", typeof(String)); //
            //    paramTable.Columns.Add("GRADE", typeof(String)); //
            //    paramTable.Columns.Add("SCOMMNET", typeof(String)); //


            //    //파일첨부키
            //    paramTable.Columns.Add("ISSU_FILE_ID", typeof(String)); //
            //    paramTable.Columns.Add("SOL_FILE_ID", typeof(String)); //
            //    paramTable.Columns.Add("RPT_FILE_ID", typeof(String)); //

            //    paramTable.Columns.Add("REG_EMP", typeof(String)); //

            //    DataRow paramRow = paramTable.NewRow();
            //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //    paramRow["PROPS_ID"] = "";
            //    paramRow["PROPS_DATE"] = layoutRow["PROPS_DATE"].toDateString("yyyyMMdd");
            //    paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            //    paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            //    paramRow["PROC_NAME"] = layoutRow["PROC_NAME"];
            //    paramRow["TITLE"] = layoutRow["TITLE"];
            //    paramRow["AS_IS"] = layoutRow["AS_IS"];
            //    paramRow["TO_BE"] = layoutRow["TO_BE"];
            //    paramRow["EXP_EFFECT"] = layoutRow["EXP_EFFECT"];
            //    paramRow["EXP_FINISH_DATE"] = layoutRow["EXP_FINISH_DATE"].toDateString("yyyyMMdd");
            //    paramRow["FINISH_DATE"] = layoutRow["FINISH_DATE"].toDateString("yyyyMMdd");

            //    paramRow["REWARD"] = layoutRow["REWARD"];
            //    paramRow["REWARD_DATE"] = layoutRow["REWARD_DATE"].toDateString("yyyyMMdd");
            //    paramRow["GRADE"] = layoutRow["GRADE"];
            //    paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];


            //    //첨부파일 KEY 
            //    paramRow["ISSU_FILE_ID"] = "";
            //    paramRow["SOL_FILE_ID"] = "";
            //    paramRow["RPT_FILE_ID"] = "";

            //    paramRow["REG_EMP"] = acInfo.UserID;

            //    paramTable.Rows.Add(paramRow);
            //    DataSet paramSet = new DataSet();
            //    paramSet.Tables.Add(paramTable);


            //    BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
            //            "SYS16B_INS2", paramSet, "RQSTDT", "RSLTDT",
            //            QuickSave,
            //            QuickException);

            //}
            //catch (Exception ex)
            //{
            //    acMessageBox.Show(this, ex);
            //}
            #endregion;
        }


        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                // acAttachFileControl2는 파일키 생성 이후 파일이 업로드되는 방식 (기존방식: 파일키를 미리 만들어 컨트롤러에 매칭을 해두어야 했음)

                acAttachFileControl21.LinkKey = e.result.Tables["RSLTDT"].Rows[0]["ISSU_FILE_ID"];
                acAttachFileControl21.ShowKey = new object[] { e.result.Tables["RSLTDT"].Rows[0]["ISSU_FILE_ID"] };
                acAttachFileControl21.UploadFile();

                acAttachFileControl22.LinkKey = e.result.Tables["RSLTDT"].Rows[0]["SOL_FILE_ID"];
                acAttachFileControl22.ShowKey = new object[] { e.result.Tables["RSLTDT"].Rows[0]["SOL_FILE_ID"] };
                acAttachFileControl22.UploadFile();

                acAttachFileControl23.LinkKey = e.result.Tables["RSLTDT"].Rows[0]["RPT_FILE_ID"];
                acAttachFileControl23.ShowKey = new object[] { e.result.Tables["RSLTDT"].Rows[0]["RPT_FILE_ID"] };
                acAttachFileControl23.UploadFile();


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
                paramTable.Columns.Add("PROPS_ID", typeof(String)); //
                paramTable.Columns.Add("PROPS_DATE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                paramTable.Columns.Add("PROC_NAME", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("AS_IS", typeof(String)); //
                paramTable.Columns.Add("TO_BE", typeof(String)); //
                paramTable.Columns.Add("EXP_EFFECT", typeof(String)); //
                paramTable.Columns.Add("EXP_FINISH_DATE", typeof(String)); //
                paramTable.Columns.Add("FINISH_DATE", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //

                paramTable.Columns.Add("REWARD", typeof(Decimal)); //
                paramTable.Columns.Add("REWARD_DATE", typeof(String)); //
                paramTable.Columns.Add("GRADE", typeof(String)); //
                paramTable.Columns.Add("SCOMMENT", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROPS_ID"] = linkRow["PROPS_ID"];
                paramRow["PROPS_DATE"] = layoutRow["PROPS_DATE"].toDateString("yyyyMMdd");
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
                paramRow["PROC_NAME"] = layoutRow["PROC_NAME"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["AS_IS"] = layoutRow["AS_IS"];
                paramRow["TO_BE"] = layoutRow["TO_BE"];
                paramRow["EXP_EFFECT"] = layoutRow["EXP_EFFECT"];
                paramRow["EXP_FINISH_DATE"] = layoutRow["EXP_FINISH_DATE"].toDateString("yyyyMMdd");
                paramRow["FINISH_DATE"] = layoutRow["FINISH_DATE"].toDateString("yyyyMMdd");
                paramRow["MDFY_EMP"] = acInfo.UserID;

                paramRow["REWARD"] = layoutRow["REWARD"];
                paramRow["REWARD_DATE"] = layoutRow["REWARD_DATE"].toDateString("yyyyMMdd");
                paramRow["GRADE"] = layoutRow["GRADE"];
                paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS16B_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                acAttachFileControl21.UploadFile();
                acAttachFileControl22.UploadFile();
                acAttachFileControl23.UploadFile();

                //if(acAttachFileControl21.isComplete && acAttachFileControl22.isComplete && acAttachFileControl23.isComplete)
                //{
                //    this.Close();
                //}

                // this.Close();

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
                paramTable.Columns.Add("PROPS_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PROPS_ID"] = linkRow["PROPS_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                //BizRun.QBizRun.ExecuteService(
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS16B_DEL", paramSet, "RQSTDT", "",
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


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void acEmp1_EditValueChanged(object sender, EventArgs e)
        {
            //소속
            DataRow row = (acLayoutControl1.GetEditor("EMP_CODE").Editor as acEmp).SelectedRow;

            acLayoutControl1.GetEditor("ORG_CODE").Value = row["ORG_CODE"];
        }
    }
}