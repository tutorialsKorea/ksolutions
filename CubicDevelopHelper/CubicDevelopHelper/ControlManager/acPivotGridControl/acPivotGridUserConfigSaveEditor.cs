using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BizManager;


namespace ControlManager
{
    public sealed partial class acPivotGridUserConfigSaveEditor : BaseMenuDialog
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

        private acPivotGridControl _SourceGridView = null;

        public acPivotGridUserConfigSaveEditor(acPivotGridControl sourceGridView)
        {
            InitializeComponent();

            _SourceGridView = sourceGridView;


            #region 이벤트 설정

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            #endregion
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //사용자 UI 목록에서 더블클릭하면 기본입력

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                acLayoutControl1.GetEditor("CONFIG_NAME").Value = focusRow["CONFIG_NAME"];

            }
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
            paramRow["CLASS_NAME"] = this._SourceGridView.ParentControl.Name;
            paramRow["CONTROL_NAME"] = this._SourceGridView.Name;


            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();

            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
     this._SourceGridView.ParentControl, QBiz.emExecuteType.LOAD,"CTRL",
    "GET_USERCONFIG_LIST", paramSet, "RQSTDT", "RSLTDT", QuickSearch, QuickException);

            //DataSet dsResult = BizManager.acControls.GET_USERCONFIG_LIST(paramSet);

            //acGridView1.GridControl.DataSource = dsResult.Tables["RSLTDT"];

        }
        protected override void OnLoad(EventArgs e)
        {

            acGridView1.GridType = acGridView.emGridType.LIST;

            acGridView1.AddTextEdit("CONFIG_NAME", "사용자 UI명", "3P24JPW6", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "등록일", "CZP2OQ22", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            this.Search();
            base.OnLoad(e);

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


        void QuickException(object sender, QBiz qBiz,  BizException ex)
        {
            if (ex.ErrNumber == BizException.OVERWRITE ||
                ex.ErrNumber == BizException.OVERWRITE_HISTORY)
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
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                if (e.result.Tables["RSLTDT"].Rows.Count != 0)
                {
                    _SourceGridView._Config.ConfigName = (string)e.result.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                    _SourceGridView._Config.ConfigMaKer = (string)e.result.Tables["RSLTDT"].Rows[0]["EMP_CODE"];

                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                DataRow keyRow = acLayoutControl1.CreateParameterRow();

                byte[] layoutData = null;
                byte[] configData = null;


                _SourceGridView._Config.Save(out layoutData, out configData);


                DataTable paramTable = new DataTable("RQSTDT");

                paramTable.Columns.Add("PLT_CODE", typeof(string));
                paramTable.Columns.Add("EMP_CODE", typeof(string));
                paramTable.Columns.Add("CLASS_NAME", typeof(string));
                paramTable.Columns.Add("CONTROL_NAME", typeof(string));
                paramTable.Columns.Add("CONFIG_NAME", typeof(string));
                paramTable.Columns.Add("DEFAULT_USE", typeof(string));
                paramTable.Columns.Add("LAYOUT", typeof(byte[]));
                paramTable.Columns.Add("OBJECT", typeof(byte[]));
                paramTable.Columns.Add("OVERWRITE", typeof(string));


                DataRow paramRow = paramTable.NewRow();

                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["CLASS_NAME"] = _SourceGridView.ParentControl.Name;
                paramRow["CONTROL_NAME"] = _SourceGridView.Name;
                paramRow["CONFIG_NAME"] = keyRow["CONFIG_NAME"];
                paramRow["DEFAULT_USE"] = keyRow["DEFAULT_USE"];
                paramRow["LAYOUT"] = layoutData;
                paramRow["OBJECT"] = configData;
                paramRow["OVERWRITE"] = "0";

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();

                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                    _SourceGridView.ParentControl, QBiz.emExecuteType.SAVE,"CTRL",
                    "SET_USERCONFIG_SAVE2", paramSet, "RQSTDT", "RSLTDT", QuickSave, QuickException);

                //DataSet dsResult = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

                //if (dsResult.Tables["RSLTDT"].Rows.Count != 0)
                //{
                //    _SourceGridView._Config.ConfigName = (string)dsResult.Tables["RSLTDT"].Rows[0]["CONFIG_NAME"];
                //    _SourceGridView._Config.ConfigMaKer = (string)dsResult.Tables["RSLTDT"].Rows[0]["EMP_CODE"];

                //}
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }




    }
}