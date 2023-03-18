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
using System.Linq;

namespace HIS
{
    public sealed partial class HIS03A_D1A : BaseMenuDialog
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

        


        public HIS03A_D1A(acGridView linkView, object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;

            _LinkView = linkView;

            #region 소요 예비품
            //acGridView1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.AddTextEdit("USE_QTY", "소요수량", "", false, DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.F1);
            //acGridView1.AddTextEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NONE);
            //acGridView1.KeyColumn = new string[] { "MTN_CODE", "MC_CODE", "PART_CODE" };
            #endregion
        }



        public override void DialogInit()
        {
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("PM_GUBUN").Editor as acLookupEdit).SetCode("H002");        //

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로만들기
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData,true);
            if (acLayoutControl1.GetEditor("PM_DATE").Value.isNullOrEmpty())
            {
                acLayoutControl1.GetEditor("PM_DATE").Value = DateTime.Now;
            }

          //  GetPart((DataRow)_LinkData);
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장 후 닫기

            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                "HIS03A_INS2", paramSet, "RQSTDT", "RSLTDT",
                QuickSaveClose,
                QuickException);

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

        private DataSet SaveData()
        {
            try
            {
                //acGridView1.EndEditor();

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return null;
                }


                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PM_ACT_CODE", typeof(String)); //
                paramTable.Columns.Add("MTN_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("PLN_DATE", typeof(String)); //
                paramTable.Columns.Add("PM_DATE", typeof(String)); //
                paramTable.Columns.Add("PM_TYPE", typeof(String)); //
                paramTable.Columns.Add("PM_GUBUN", typeof(String)); //
                paramTable.Columns.Add("PM_CONTENTS", typeof(String)); //
                paramTable.Columns.Add("PM_VND", typeof(String)); //
                paramTable.Columns.Add("PM_CHARGE", typeof(String)); //
                paramTable.Columns.Add("PART_SUPPLY", typeof(Decimal)); //
                paramTable.Columns.Add("PM_TIME", typeof(Decimal)); //
                paramTable.Columns.Add("PM_COST", typeof(Decimal)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["MTN_CODE"] = layoutRow["MTN_CODE"];
                paramRow["MC_CODE"] = layoutRow["MC_CODE"];
                paramRow["PLN_DATE"] = layoutRow["PLN_DATE"];
                paramRow["PM_DATE"] = layoutRow["PM_DATE"];
                paramRow["PM_GUBUN"] = layoutRow["PM_GUBUN"];
                paramRow["PM_TYPE"] = "B"; //'B' 계획
                paramRow["PART_SUPPLY"] = layoutRow["PART_SUPPLY"];
                paramRow["PM_TIME"] = layoutRow["PM_TIME"];
                paramRow["PM_CONTENTS"] = layoutRow["PM_CONTENTS"];
                paramRow["PM_COST"] = layoutRow["PM_COST"];
                paramRow["PM_VND"] = layoutRow["PM_VND"];
                paramRow["PM_CHARGE"] = layoutRow["PM_CHARGE"];
                paramTable.Rows.Add(paramRow);

                //DataTable paramTableParts = acGridView1.CopyNewTable();
                //paramTableParts.TableName = "RQSTDT_PARTS";
                //paramSet.Tables.Add(paramTableParts);

                return paramSet;
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

            return null;
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장


            try
            {
                DataSet paramSet = SaveData();

                if (paramSet == null) return;
                
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE,
                    "HIS03A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                if (_LinkView != null)
                {
                    DataTable resultDt = e.result.Tables["RQSTDT"].AsEnumerable()
                                                        .Join(e.result.Tables["RQSTDT_PARTS"].AsEnumerable()
                                                        , main => new { PLT_CODE = main["PLT_CODE"], MTN_CODE = main["MTN_CODE"], MC_CODE = main["MC_CODE"], PLN_DATE = main["PLN_DATE"] }
                                                        , parts => new { PLT_CODE = parts["PLT_CODE"], MTN_CODE = parts["MTN_CODE"], MC_CODE = parts["MC_CODE"], PLN_DATE = parts["PLAN_DATE"] }
                                                        , (main, parts) =>
                                                        new
                                                        {
                                                            PLT_CODE = main?["PLT_CODE"],
                                                            MTN_CODE = main?["MTN_CODE"],
                                                            MC_CODE = main?["MC_CODE"],
                                                            PLN_DATE = main?["PLN_DATE"],
                                                            PART_CODE = parts?["PART_CODE"],
                                                            PART_NAME = parts?["PART_NAME"],

                                                            PM_ACT_CODE = main?["PM_ACT_CODE"],
                                                            PM_DATE = main?["PM_DATE"],
                                                            PM_TYPE = main?["PM_TYPE"],
                                                            PM_GUBUN = main?["PM_GUBUN"],
                                                            PM_CONTENTS = main?["PM_CONTENTS"],
                                                            PM_VND = main?["PM_VND"],
                                                            PM_CHARGE = main?["PM_CHARGE"],
                                                            PART_SUPPLY = main?["PART_SUPPLY"],
                                                            PM_TIME = main?["PM_TIME"],
                                                            PM_COST = main?["PM_COST"],

                                                            USE_QTY = parts?["USE_QTY"],
                                                            SCOMMENT = parts?["SCOMMENT"]
                                                        })
                                                        .LINQToDataTable();

                    foreach (DataRow row in resultDt.Rows)
                    {
                        this._LinkView.UpdateMapingRow(row, true);
                    }
                }
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
                if (_LinkView != null)
                {
                    //if(e.result.Tables["RQSTDT_PARTS"].Rows.Count > 0)
                    //{
                    //    DataTable resultDt = e.result.Tables["RQSTDT"].AsEnumerable()
                    //                             .Join(e.result.Tables["RQSTDT_PARTS"].AsEnumerable()
                    //                             , main => new { PLT_CODE = main["PLT_CODE"], MTN_CODE = main["MTN_CODE"], MC_CODE = main["MC_CODE"], PLN_DATE = main["PLN_DATE"] }
                    //                             , parts => new { PLT_CODE = parts["PLT_CODE"], MTN_CODE = parts["MTN_CODE"], MC_CODE = parts["MC_CODE"], PLN_DATE = parts["PLAN_DATE"] }
                    //                             , (main, parts) =>
                    //                             new
                    //                             {
                    //                                 PLT_CODE = main?["PLT_CODE"],
                    //                                 MTN_CODE = main?["MTN_CODE"],
                    //                                 MC_CODE = main?["MC_CODE"],
                    //                                 PLN_DATE = main?["PLN_DATE"],
                    //                                 PART_CODE = parts?["PART_CODE"],
                    //                                 PART_NAME = parts?["PART_NAME"],

                    //                                 PM_ACT_CODE = main?["PM_ACT_CODE"],
                    //                                 PM_DATE = main?["PM_DATE"],
                    //                                 PM_TYPE = main?["PM_TYPE"],
                    //                                 PM_GUBUN = main?["PM_GUBUN"],
                    //                                 PM_CONTENTS = main?["PM_CONTENTS"],
                    //                                 PM_VND = main?["PM_VND"],
                    //                                 PM_CHARGE = main?["PM_CHARGE"],
                    //                                 PART_SUPPLY = main?["PART_SUPPLY"],
                    //                                 PM_TIME = main?["PM_TIME"],
                    //                                 PM_COST = main?["PM_COST"],

                    //                                 USE_QTY = parts?["USE_QTY"],
                    //                                 SCOMMENT = parts?["SCOMMENT"]
                    //                             })
                    //                             .LINQToDataTable();


                    //    foreach (DataRow row in resultDt.Rows)
                    //    {
                    //        this._LinkView.UpdateMapingRow(row, true);
                    //    }
                    //}
                    //else
                    //{
                        foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                        {
                            this._LinkView.UpdateMapingRow(row, true);
                        }

                    //}
                 
                    
                }
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz QBiz,  BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

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


                foreach (DataRow row in QBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                QBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }

        //void GetPart(DataRow linkRow)
        //{
        //    try
        //    {
        //        DataSet paramSet = new DataSet();
        //        DataTable paramTable = paramSet.Tables.Add("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String));
        //        paramTable.Columns.Add("MTN_CODE", typeof(String));
        //        paramTable.Columns.Add("MC_CODE", typeof(String));
        //        paramTable.Columns.Add("PLAN_DATE", typeof(String));

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["MTN_CODE"] = linkRow["MTN_CODE"];
        //        paramRow["MC_CODE"] = linkRow["MC_CODE"];
        //        paramRow["PLAN_DATE"] = linkRow["PLN_DATE"].toDateString("yyyyMMdd");
        //        paramTable.Rows.Add(paramRow);

        //        BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD_DETAIL, "HIS03A_SER3", paramSet, "RQSTDT", "RSLTDT", QuickSearchPart ,QuickException);
        //    }
        //    catch(Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }
        //}
        //void QuickSearchPart(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        //{
        //    try
        //    {
        //        acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
        //        acGridView1.BestFitColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(this, ex);
        //    }

        //}
    }
}
