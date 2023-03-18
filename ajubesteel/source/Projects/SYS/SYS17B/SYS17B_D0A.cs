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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Threading;

namespace SYS
{
    public sealed partial class SYS17B_D0A : BaseMenuDialog
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


        public SYS17B_D0A(acGridView linkView, object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "ACC_LEVEL":

                    if(newValue == null)
                    {
                        break;
                    }

                    if (newValue.ToString() == "E")
                    {
                        acSimpleButton1.Enabled = true;
                    }
                    else
                    {
                        acSimpleButton1.Enabled = false;
                        layout.GetEditor("RECEIVER").Clear();
                    }

                    break;
            }
        }


        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnReply.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            (acLayoutControl1.GetEditor("ACC_LEVEL").Editor as acLookupEdit).SetCode("S011");
            acTextEdit3.Value = acInfo.UserName + " (" + acInfo.UserID + ")"; //등록자 초기화
            //(acLayoutControl1.GetEditor("REG_EMP").Editor as acTextEdit).Value = acInfo.UserName + " (" + acInfo.UserID = ")";
            //REG_EMP

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

            if (_LinkView == null)
            {
                btnReply.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                (acLayoutControl1.GetEditor("ACC_LEVEL").Editor as acLookupEdit).isReadyOnly = true;
                (acLayoutControl1.GetEditor("TITLE").Editor as acTextEdit).isReadyOnly  = true;
                acRichEdit1.isReadyOnly = true;
            }
            else
            {
                barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            btnReply.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = this._LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);


        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
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
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //
                paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("RECEIVER", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("METTING_TYPE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MEETING_ID"] = null;
                paramRow["ACC_LEVEL"] = layoutRow["ACC_LEVEL"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["RECEIVER"] = layoutRow["RECEIVER"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["METTING_TYPE"] = "REPORT";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                // ACC_LEVEL (E: 개인, P: 전체) 개인이면서 데이터가 존재?
                if (layoutRow["ACC_LEVEL"].EqualsEx("E") && dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }
                else
                {
                    DataTable paramTable2 = new DataTable("RQSTDT2");
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                        "SYS17A_INS", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
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

                _LinkView.RaiseFocusedRowChanged();

                this.Close();
             
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
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //
                paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                paramTable.Columns.Add("TITLE", typeof(String)); //
                paramTable.Columns.Add("CONTENTS", typeof(String)); //
                paramTable.Columns.Add("RECEIVER", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("METTING_TYPE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MEETING_ID"] = linkRow["MEETING_ID"];
                paramRow["ACC_LEVEL"] = layoutRow["ACC_LEVEL"];
                paramRow["TITLE"] = layoutRow["TITLE"];
                paramRow["CONTENTS"] = layoutRow["CONTENTS"];
                paramRow["RECEIVER"] = layoutRow["RECEIVER"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["METTING_TYPE"] = "COMMON";

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (layoutRow["ACC_LEVEL"].EqualsEx("E") && dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }
                else
                {
                    DataTable paramTable2 = new DataTable("RQSTDT2");
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                            "SYS17A_INS", paramSet, "RQSTDT,RQSTDT2", "RSLTDT",
                            QuickSaveClose,
                            QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private delegate void FormCloseCallback();

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }

                _LinkView.RaiseFocusedRowChanged();

             
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


                DataRow linkRow = (DataRow)_LinkData;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MEETING_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MEETING_ID"] = linkRow["MEETING_ID"];
                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "SYS17A_DEL", paramSet, "RQSTDT", "",
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

            if(ex.ErrNumber == 200093)
            {
                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", "해당 회의록은 등록한 사용자만 수정하거나 삭제할 수 있습니다.", "", false, this.Caption, ex.ParameterData);

                frm.ShowDialog();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }
          
        }


        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private DataSet dsEmp = null;
        private void acSimpleButton1_Click(object sender, EventArgs e)
        {

            if (!base.ChildFormContains("RECEIVER_NEW"))
            {

                SYS17A_D3A frm = new SYS17A_D3A(_LinkData);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("RECEIVER_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsEmp = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("RECEIVER").Value = dsEmp.Tables["RQSTDT"].Rows[0]["RECEIVER"];
                }

            }
            else
            {

                base.ChildFormFocus("RECEIVER_NEW");

            }

        }

        private void barItemConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Close(); Onclik 이벤트 오류로 임시 주석처리
            this.Close();
        }

        private void btnReply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

            try
            {

                DataRow linkRow = this._LinkData as DataRow;

                if (!base.ChildFormContains(linkRow["MEETING_ID"]))
                {

                    //SYS12A_D1A frm = new SYS12A_D1A(null, linkRow);
                    //_LinkView
                    SYS17A_D1A frm = new SYS17A_D1A(_LinkView, linkRow);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    frm.ParentControl = this;

                    base.ChildFormAdd(linkRow["MEETING_ID"], frm);

                    //frm.Show(this);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        (this.ParentControl as SYS17A_M0A).Search();
                        this.Close();
                    }

                }
                else
                {

                    base.ChildFormFocus(linkRow["MEETING_ID"]);

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}