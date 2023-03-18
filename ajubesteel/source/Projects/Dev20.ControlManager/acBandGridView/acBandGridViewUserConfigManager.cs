using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BizManager;

namespace ControlManager
{
    public sealed partial class acBandGridViewUserConfigManager : BaseMenuDialog
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

        private acBandGridView _SourceView = null;


        public acBandGridViewUserConfigManager(acBandGridView view)
        {
            InitializeComponent();

            this._SourceView = view;

        }

        protected override void OnLoad(EventArgs e)
        {


            acGridView1.GridType = acGridView.emGridType.LIST;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("CONFIG_NAME", "사용자 UI명", "3P24JPW6", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "등록일", "CZP2OQ22", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);


            base.OnLoad(e);

        }

        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            this.Search();

        }


        void Search()
        {
            DataTable paramTable = new DataTable("RQSTDT");

            paramTable.Columns.Add("PLT_CODE");
            paramTable.Columns.Add("EMP_CODE");
            paramTable.Columns.Add("CLASS_NAME");
            paramTable.Columns.Add("CONTROL_NAME");

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = this._SourceView.ParentControl.Name;
            paramRow["CONTROL_NAME"] = this._SourceView.Name;


            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
     this._SourceView.ParentControl, QBiz.emExecuteType.LOAD,"CTRL",
    "GET_USERCONFIG_LIST", paramSet, "RQSTDT", "RSLTDT", QuickSearch, QuickException);

            //DataSet dsRsult = BizManager.acControls.GET_USERCONFIG_LIST(paramSet);
            //acGridView1.GridControl.DataSource = dsRsult.Tables["RSLTDT"];
        }
        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //삭제
            try
            {
                acGridView1.CloseEditor();

                acGridView1.UpdateCurrentRow();

                DataView view = acGridView1.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("EMP_CODE");
                paramTable.Columns.Add("CLASS_NAME");
                paramTable.Columns.Add("CONTROL_NAME");
                paramTable.Columns.Add("CONFIG_NAME");

                for (int i = 0; i < view.Count; i++)
                {
                    DataRowView rowView = view[i];

                    DataRow paramRow = paramTable.NewRow();

                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["EMP_CODE"] = acInfo.UserID;
                    paramRow["CLASS_NAME"] = rowView["CLASS_NAME"];
                    paramRow["CONTROL_NAME"] = rowView["CONTROL_NAME"];
                    paramRow["CONFIG_NAME"] = rowView["CONFIG_NAME"];

                    paramTable.Rows.Add(paramRow);

                }

                if (paramTable.Rows.Count != 0)
                {
                    if (acMessageBox.Show(this, "이 사용자 UI을 사용중일경우 모두 시스템 UI으로 재설정됩니다. 삭제하시겠습니까?", "42LF5FEI",
                        true, acMessageBox.emMessageBoxType.YESNO)
                        == DialogResult.Yes)
                    {


                        DataSet paramSet = new DataSet();

                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(
                         this._SourceView.ParentControl, QBiz.emExecuteType.SAVE, "CTRL",
                        "SET_USERCONFIG_DEL", paramSet, "RQSTDT", "", QuickSave, QuickException);

                        //BizManager.acControls.SET_USERCONFIG_DEL(paramSet);

                        //this.Search();

                    }
                }

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
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}