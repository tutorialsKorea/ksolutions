using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BizManager;
using System.Linq;

namespace PLN
{
    public sealed partial class PLN_D0A : BaseMenuDialog
    {
        /// <summary>
        /// 등록된 외주 숫자
        /// </summary>
        int _addOs = 0;
        /// <summary>
        /// 등록된 비 외주 숫자
        /// </summary>
        int _addNotOs = 0;

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

        string _partCode = null;
        //Dictionary<int, string> _dicSeqOfMc = null;
        List<string> _mcList = null;

        //public PLN_D0A(string partCode, object linkData,Dictionary<int,string> dicSeqOfMc)
        public PLN_D0A(string partCode, object linkData, List<string> mcList)
        {
            InitializeComponent();

            this._LinkData = linkData;
            this._partCode = partCode;
            //this._dicSeqOfMc = dicSeqOfMc;
            this._mcList = mcList;

            acGridView1.GridType = ControlManager.acGridView.emGridType.SEARCH;

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddCheckEdit("MC_OS", "외주 설비", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView1.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            acGridView1.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "MC_CODE" };

            acGridView2.GridType = ControlManager.acGridView.emGridType.SEARCH;

            acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddCheckEdit("MC_OS", "외주 설비", "", false, false, true, acGridView.emCheckEditDataType._BYTE);
            acGridView2.AddLookUpEdit("MC_GROUP", "설비그룹", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");
            //acGridView2.AddTextEdit("MC_SEQ", "설비우선순위", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, true, acGridView.emTextEditMask.NUMERIC);
            acGridView2.AddTextEdit("MAIN_EMP", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MAIN_EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "MC_CODE" };

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acGridView2.MouseDown += AcGridView2_MouseDown;
            //acGridView2.OnMapingRowChanged += AcGridView2_OnMapingRowChanged;
            this.FormClosed += PLN_D0A_FormClosed;
  
        }

        private void AcGridView2_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            try
            {
                if (type == acGridView.emMappingRowChangedType.ADD)
                {
                    var tmp = row.Table.AsEnumerable().GroupBy(g => g.GetType()).Select(r => r.Max(m => m["MC_SEQ"].toInt()));
                    
                    int maxNum = tmp.FirstOrDefault();
                    row["MC_SEQ"] = maxNum + 1;
                }
            }
            catch { }
        }

        private void PLN_D0A_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            this.Search();
        }


        void Search()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); 
            paramTable.Columns.Add("PART_CODE", typeof(String));
            paramTable.Columns.Add("PROC_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_CODE"] = _partCode;
            paramRow["PROC_CODE"] = ((DataRow)_LinkData)["PROC_CODE"];


            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD, "PLN01A_SER7", paramSet, "RQSTDT", "RSLTDT_STD_MC,RSLTDT_APS_MC",
            QuickSearch,
            QuickException);


        }

        /// <summary>
        /// 설비목록에서 대상설비로 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    if(focusRow["MC_OS"].toInt() == 1)
                    {
                        _addOs++;
                    }
                    else
                    {
                        _addNotOs++;
                    }

                    if (_addOs > 0 && _addNotOs > 0)
                    {
                        acMessageBox.Show(this, "외주 설비와 사내 설비를 동시에 등록 하실수 없습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                        return;
                    }

                    acGridView2.UpdateMapingRow(focusRow, true);

                    acGridView1.DeleteMappingRow(focusRow);
                }

            }
        }

        /// <summary>
        /// 대상설비에서 설비목록으로 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView2.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    DataRow focusRow = acGridView2.GetFocusedDataRow();

                    if (focusRow["MC_OS"].toInt() == 1)
                    {
                        _addOs--;
                    }
                    else
                    {
                        _addNotOs--;
                    }

                    acGridView1.UpdateMapingRow(focusRow, true);

                    acGridView2.DeleteMappingRow(focusRow);
                }

            }
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataTable apsTable = acGridView2.NewTable();

                if (_mcList != null && _mcList.Count > 0)
                {
                    foreach (string mc in _mcList)
                    {
                        SetMcSeqList(apsTable, e.result.Tables["RSLTDT_STD_MC"], mc);
                    }
                }
                //else
                //{
                //    foreach (DataRow procMc in e.result.Tables["RSLTDT_APS_MC"].Rows)
                //    {
                //        SetMcSeqList(apsTable, e.result.Tables["RSLTDT_STD_MC"], procMc["MC_CODE"].ToString(), procMc["MC_SEQ"].toInt());
                //        //DataRow stdMC = e.result.Tables["RSLTDT_STD_MC"].Select("MC_CODE = '" + procMc["MC_CODE"].ToString() + "'").FirstOrDefault();
                //        //if (stdMC == null)
                //        //    continue;

                //        //DataRow newRow = apsTable.NewRow();
                //        //newRow["MC_CODE"] = procMc["MC_CODE"];
                //        //newRow["MC_NAME"] = stdMC["MC_NAME"];
                //        //newRow["MC_OS"] = stdMC["MC_OS"];
                //        //newRow["MC_GROUP"] = stdMC["MC_GROUP"];
                //        //newRow["MC_SEQ"] = procMc["MC_SEQ"];
                //        //newRow["MAIN_EMP"] = stdMC["MAIN_EMP"];
                //        //newRow["MAIN_EMP_NAME"] = stdMC["MAIN_EMP_NAME"];
                //        //newRow["SCOMMENT"] = stdMC["SCOMMENT"];
                //        //apsTable.Rows.Add(newRow);

                //        //if (stdMC["MC_OS"].toInt() == 1)
                //        //{
                //        //    _addOs++;
                //        //}
                //        //else
                //        //{
                //        //    _addNotOs++;
                //        //}

                //    }
                //}
                acGridView2.GridControl.DataSource = apsTable;
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_STD_MC"];

                base.SetLog(e.executeType, e.result.Tables["RSLTDT_STD_MC"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        //void SetMcSeqList(DataTable insertTable, DataTable stdMcTable, string mcCode,int mcSeq)
        void SetMcSeqList(DataTable insertTable, DataTable stdMcTable, string mcCode)
        {
            DataRow stdMC = stdMcTable.Select("MC_CODE = '" + mcCode + "'").FirstOrDefault();
            if (stdMC == null)
                return;

            DataRow newRow = insertTable.NewRow();
            newRow["MC_CODE"] = mcCode;
            newRow["MC_NAME"] = stdMC["MC_NAME"];
            newRow["MC_OS"] = stdMC["MC_OS"];
            newRow["MC_GROUP"] = stdMC["MC_GROUP"];
            //newRow["MC_SEQ"] = mcSeq;
            newRow["MAIN_EMP"] = stdMC["MAIN_EMP"];
            newRow["MAIN_EMP_NAME"] = stdMC["MAIN_EMP_NAME"];
            newRow["SCOMMENT"] = stdMC["SCOMMENT"];
            insertTable.Rows.Add(newRow);

            if (stdMC["MC_OS"].toInt() == 1)
            {
                _addOs++;
            }
            else
            {
                _addNotOs++;
            }

            stdMcTable.Rows.Remove(stdMC);
        }

        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                DataRow focusRow = acGridView2.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable paramTable = new DataTable("RQSTDT");
                //paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                //paramTable.Columns.Add("PART_CODE", typeof(String)); //
                //paramTable.Columns.Add("PROC_CODE", typeof(String)); //
                //paramTable.Columns.Add("MC_CODE", typeof(String)); //
                //paramTable.Columns.Add("MC_SEQ", typeof(Int32)); //
                //paramTable.Columns.Add("TACT_TIME", typeof(Int32)); //
                //paramTable.Columns.Add("PROC_TIME", typeof(Int32)); //


                //for (int i = 0; i < acGridView2.RowCount; i++)
                //{
                //    DataRow row = acGridView2.GetDataRow(i);

                //    DataRow paramRow = paramTable.NewRow();
                //    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                //    paramRow["PART_CODE"] = _partCode;
                //    paramRow["PROC_CODE"] = ((DataRow)LinkData)["PROC_CODE"];
                //    paramRow["MC_CODE"] = row["MC_CODE"];
                //    paramRow["MC_SEQ"] = row["MC_SEQ"];
                //    paramRow["TACT_TIME"] = ((DataRow)LinkData)["STD_TIME"];
                //    paramRow["PROC_TIME"] = ((DataRow)LinkData)["STD_TIME"];
                //    paramTable.Rows.Add(paramRow);
                //}

                //DataSet paramSet = new DataSet();
                //paramSet.Tables.Add(paramTable);

                //BizRun.QBizRun.ExecuteService(QBiz.emExecuteType.LOAD, "PLN01A_MC_SAVE", paramSet, "RQSTDT", "RSLTDT");

                acGridView2.EndEditor();

                //if(!acGridView2.ValidCheck())
                //{
                //    acMessageBox.Show(this, "우선순위 값을 입력해주세요.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                //    return;
                //}

                //Dictionary<int, string> mcPreset = new Dictionary<int, string>();
                
                //for (int i = 0; i < acGridView2.RowCount; i++)
                //{
                //    DataRow row = acGridView2.GetDataRow(i);

                //    //우선순위 중복 여부가 필요하므로 우선순위를 키로한다.
                //    if(mcPreset.ContainsKey(row["MC_SEQ"].toInt()))
                //    {
                //        acMessageBox.Show(this, "중복된 우선순위 값이 존재합니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                //        return;
                //    }
                //    mcPreset.Add(row["MC_SEQ"].toInt(), row["MC_CODE"].ToString());
                //}

                List<string> mcList = new List<string>();

                for (int i = 0; i < acGridView2.RowCount; i++)
                {
                    DataRow row = acGridView2.GetDataRow(i);
                    mcList.Add(row["MC_CODE"].ToString());
                }

                //전달해야할 값 : 설비목록, 우선순위, 외주여부(in 사내, out 외주)
                object[] sendData = new object[2];
                //sendData[0] = mcPreset;
                sendData[0] = mcList;
                sendData[1] = _addOs > 0 ? "OUT" : "IN";

                this.OutputData = sendData;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

            this.Close();
        }
    }
}