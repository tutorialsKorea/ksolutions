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
    public sealed partial class acGridViewUserCustomReportManager : BaseMenuDialog
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

        private acGridView _SourceView = null;


        public acGridViewUserCustomReportManager(acGridView view)
        {
            InitializeComponent();

            this._SourceView = view;

        }

        protected override void OnLoad(EventArgs e)
        {


            acGridView1.GridType = acGridView.emGridType.LIST;

            acGridView1.AddCheckEdit("SEL", "선택", string.Empty, false, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("EXPORT_TYPE", "구분", string.Empty, false , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("FILE_NAME", "제목", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "등록자", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "등록일", string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddHidden("CUS_ID", typeof(String));

            acGridView1.KeyColumn = new string[] { "CUS_ID" };

            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            this.Search();

        }


        void Search()
        {
            try
            {
                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("CLASS_NAME", typeof(String));
                paramTable.Columns.Add("CONTROL_NAME", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CLASS_NAME"] = this._SourceView.ParentControl.Name;
                paramRow["CONTROL_NAME"] = this._SourceView.Name;
                paramTable.Rows.Add(paramRow);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "GET_USE_CUSTOM_EXCEL"
                            , paramSet, "RQSTDT", "RSLTDT"
                            , QuickSearch, QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
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


        void QuickSave(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
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

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridViewCustomReport gcr = new acGridViewCustomReport(_SourceView,null);
                gcr.DialogMode = BaseMenuDialog.emDialogMode.NEW;
                gcr.ParentControl = _SourceView.ParentControl;
                if(gcr.ShowDialog(_SourceView.ParentControl) == DialogResult.OK)
                {
                    DataTable resultTable = gcr.OutputData as DataTable;
                    foreach (DataRow row in resultTable.Rows)
                    {
                        acGridView1.UpdateMapingRow(row, true);
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();
                if(focusRow == null)
                {
                    acMessageBox.Show(this, "선택된 행이 없습니다.", string.Empty, false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                acGridViewCustomReport gcr = new acGridViewCustomReport(_SourceView, focusRow);
                gcr.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                gcr.ParentControl = _SourceView.ParentControl;
                if(gcr.ShowDialog(_SourceView.ParentControl) == DialogResult.OK)
                {
                    DataTable resultTable = gcr.OutputData as DataTable;
                    foreach (DataRow row in resultTable.Rows)
                    {
                        acGridView1.UpdateMapingRow(row, true);
                    }
                }
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView1.EndEditor();

                DataRow selRow = null;

                DataView view = acGridView1.GetDataSourceView("SEL = '1'");
                if(view.Count == 0)
                {
                    selRow = acGridView1.GetFocusedDataRow();
                }
                else
                {
                    if(view.Count > 1 && acMessageBox.Show(this,"선택된 행 중 하나의 행만 적용됩니다. 진행하시겠습니까?",string.Empty,false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                    {
                        return;
                    }

                    selRow = view[0].Row;
                }

                if(selRow == null)
                {
                    acMessageBox.Show(this, "선택된 행이 없습니다.", string.Empty, false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("CUS_ID", typeof(String));
                paramTable.Columns.Add("EMP_CODE", typeof(String));
                paramTable.Columns.Add("FILE_NAME", typeof(String));
                paramTable.Columns.Add("CLASS_NAME", typeof(String));
                paramTable.Columns.Add("CONTROL_NAME", typeof(String));

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["CUS_ID"] = selRow["CUS_ID"];
                paramRow["EMP_CODE"] = acInfo.UserID;
                paramRow["FILE_NAME"] = selRow["FILE_NAME"];
                paramRow["CLASS_NAME"] = this._SourceView.ParentControl.Name;
                paramRow["CONTROL_NAME"] = this._SourceView.Name;
                paramTable.Rows.Add(paramRow);

                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "CTRL", "SET_CUSTOM_REPORT_TO_EXCEL"
                            , paramSet, "RQSTDT", "RSLTDT"
                            , QuickApply, QuickException);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
        void QuickApply(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.OutputData = e.result.Tables["RQSTDT"];
                this.DialogResult = DialogResult.OK;
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
                acGridView1.EndEditor();

                DataView view = acGridView1.GetDataSourceView("SEL = '1' AND EMP_CODE = '" + acInfo.UserID + "'");

                if (view.Count == 0)
                {
                    acMessageBox.Show(this, "다른 사용자가 입력한 양식을 삭제 하실 수 없습니다.", string.Empty,
                            false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE");
                paramTable.Columns.Add("CUS_ID");

                for (int i = 0; i < view.Count; i++)
                {
                    DataRowView rowView = view[i];

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["CUS_ID"] = rowView["CUS_ID"];
                    paramTable.Rows.Add(paramRow);
                }

                if (paramTable.Rows.Count != 0)
                {
                    if (acMessageBox.Show(this, "이 양식을 삭제할 경우 다른 사용중인 사용자가 이용할 수 없습니다. 삭제하시겠습니까?", string.Empty,
                        false, acMessageBox.emMessageBoxType.YESNO)
                        == DialogResult.Yes)
                    {


                        DataSet paramSet = new DataSet();

                        paramSet.Tables.Add(paramTable);

                        BizRun.QBizRun.ExecuteService(
                         this._SourceView.ParentControl, QBiz.emExecuteType.SAVE, "CTRL",
                        "DEL_CUSTOM_EXCEL", paramSet, "RQSTDT", "", QuickDel, QuickException);
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickDel(object sender, QBiz qBizActor, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.DeleteMappingRowLinq(e.result.Tables["RQSTDT"]);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}