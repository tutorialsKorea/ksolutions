using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;
namespace STD
{
    public sealed partial class STD13A_D0A : BaseMenuDialog
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

        private acTreeList _LinkTreeList = null;

        

        public STD13A_D0A(object parent, acTreeList linkTreeList, object linkData)
        {

            InitializeComponent();


            _LinkTreeList = linkTreeList;

            _LinkData = linkData;



        }
 


        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.KeyColumns = new string[] { "ORG_CODE" };

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


            acLayoutControl1.DataBind((DataRow)_LinkData,true);


        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {

                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "정말 삭제하시겠습니까?", "TB43FSY3", true, acInfo.Resource.GetString("삭제사유", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //
                paramTable.Columns.Add("OVERDEL", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramRow["OVERDEL"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.DEL,
                "STD13A_DEL", paramSet, "RQSTDT", "",
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
                    this._LinkTreeList.DeleteMappingRow(row);
                }



                this.Close();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_NAME", typeof(String)); //
                paramTable.Columns.Add("ORG_PARENT", typeof(String)); //
                paramTable.Columns.Add("ORG_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CLASS", typeof(Int32)); //
                paramTable.Columns.Add("ORG_LEADER", typeof(String)); //
                paramTable.Columns.Add("CC_EMP", typeof(String)); //
                paramTable.Columns.Add("IS_DEV", typeof(String)); //
                paramTable.Columns.Add("IS_SECRET", typeof(String)); //
                paramTable.Columns.Add("IS_ADMIN", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["ORG_NAME"] = layoutRow["ORG_NAME"];
                paramRow["ORG_PARENT"] = layoutRow["ORG_PARENT"];
                paramRow["ORG_SEQ"] = layoutRow["ORG_SEQ"];
                paramRow["ORG_CLASS"] = layoutRow["ORG_CLASS"];
                paramRow["ORG_LEADER"] = layoutRow["ORG_LEADER"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["IS_DEV"] = layoutRow["IS_DEV"];
                paramRow["IS_SECRET"] = layoutRow["IS_SECRET"];
                paramRow["IS_ADMIN"] = layoutRow["IS_ADMIN"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "1";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD13A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

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
                this._LinkTreeList.UpdateMapingRow(e.result.Tables["RSLTDT"].Rows[0], true);

                this.Close();
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
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();


                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_NAME", typeof(String)); //
                paramTable.Columns.Add("ORG_PARENT", typeof(String)); //
                paramTable.Columns.Add("ORG_SEQ", typeof(Int32)); //
                paramTable.Columns.Add("ORG_CLASS", typeof(Int32)); //
                paramTable.Columns.Add("ORG_LEADER", typeof(String)); //
                paramTable.Columns.Add("CC_EMP", typeof(String)); //
                paramTable.Columns.Add("IS_DEV", typeof(String)); //
                paramTable.Columns.Add("IS_SECRET", typeof(String)); //
                paramTable.Columns.Add("IS_ADMIN", typeof(String)); //
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                paramRow["ORG_NAME"] = layoutRow["ORG_NAME"];
                paramRow["ORG_PARENT"] = layoutRow["ORG_PARENT"];
                paramRow["ORG_SEQ"] = layoutRow["ORG_SEQ"];
                paramRow["ORG_CLASS"] = layoutRow["ORG_CLASS"];
                paramRow["ORG_LEADER"] = layoutRow["ORG_LEADER"];
                paramRow["CC_EMP"] = layoutRow["CC_EMP"];
                paramRow["IS_DEV"] = layoutRow["IS_DEV"];
                paramRow["IS_SECRET"] = layoutRow["IS_SECRET"];
                paramRow["IS_ADMIN"] = layoutRow["IS_ADMIN"];
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["OVERWRITE"] = "0";
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if (dsEmp != null)
                {
                    DataTable paramTable2 = dsEmp.Tables["RQSTDT2"].Copy();
                    paramSet.Tables.Add(paramTable2);
                }

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD13A_INS", paramSet, "RQSTDT", "RSLTDT",
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
                this._LinkTreeList.UpdateMapingRow(e.result.Tables["RSLTDT"].Rows[0], true);

                _LinkTreeList.EndEditor();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void QuickException(object sender, QBiz qBiz,  BizManager.BizException ex)
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
            else if (ex.ErrNumber == 200012)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERDEL"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }



        }

        private DataSet dsEmp = null;

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            //근태참조자 추가

            //참조자 추가
            if (!base.ChildFormContains("CC_NEW"))
            {

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("ORG_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                if(!paramRow["ORG_CODE"].isNullOrEmpty())
                {
                    dsEmp = BizRun.QBizRun.ExecuteService(this, "STD13A_SER5", paramSet, "RQSTDT", "RSLTDT");
                }


                STD13A_D3A frm = new STD13A_D3A(_LinkData, dsEmp);

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                base.ChildFormAdd("CC_NEW", frm);

                frm.ParentControl = this;

                //frm.Show(this);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dsEmp = frm.OutputData as DataSet;
                    acLayoutControl1.GetEditor("CC_EMP").Value = dsEmp.Tables["RQSTDT"].Rows[0]["CC_EMP"];
                }

            }
            else
            {

                base.ChildFormFocus("CC_NEW");

            }
        }
    }
}