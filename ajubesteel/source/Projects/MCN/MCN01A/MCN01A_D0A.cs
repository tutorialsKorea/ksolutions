using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MCN
{
    public sealed partial class MCN01A_D0A : BaseMenuDialog
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

        public DataRow _linkRow = null;
        public acGridView _linkView = null;

        public MCN01A_D0A(acGridView linkView, DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;

            _linkView = linkView;
        }


        public override void DialogInit()
        {            
            base.DialogInit();

            this.acLayoutControl1.KeyColumns = new string[] { "MS_NO" };

            (this.acLayoutControl1.GetEditor("MS_TYPE") as acLookupEdit).SetCode("M030");
            (this.acLayoutControl1.GetEditor("MS_STATE") as acLookupEdit).SetCode("M031");
            (this.acLayoutControl1.GetEditor("MS_CAT") as acLookupEdit).SetCode("M032");
        }

        public override void DialogNew()
        {

            base.DialogNew();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();


            if(_linkRow is DataRow row)
            {
                this.acLayoutControl1.DataBind(row, true);

                DataTable paramTable = row.NewTable();
                paramTable.TableName = "RQSTDT";
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_SER1_2", paramSet, "RQSTDT", "RSLTDT",
                  QuickImage,
                  QuickException);
            }
        }

        void QuickImage(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    acLayoutControl1.DataBind(row, false);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));      //
            paramTable.Columns.Add("MS_NO", typeof(String));         //관리번호
            paramTable.Columns.Add("ASSET_NO", typeof(String));      //자산번호
            paramTable.Columns.Add("MS_TYPE", typeof(String));       //유형 그룹
            paramTable.Columns.Add("MS_STATE", typeof(String));      //상태 구분
            paramTable.Columns.Add("MS_CAT", typeof(String));        //계측기 분류
            paramTable.Columns.Add("MS_NAME", typeof(String));       //계측기명
            paramTable.Columns.Add("MS_SERIAL_NO", typeof(String));  //시리얼 넘버
            paramTable.Columns.Add("MS_SPEC", typeof(String));       //규격
            paramTable.Columns.Add("MS_MAKER", typeof(String));      //제조사
            paramTable.Columns.Add("MS_COST", typeof(decimal));       //가격
            paramTable.Columns.Add("MS_BUY_DATE", typeof(String));   //구입일자
            paramTable.Columns.Add("MS_PERIOD", typeof(String));     //교정주기
            paramTable.Columns.Add("MS_NEXT_DATE", typeof(String));  //차기 교정계획일자
            paramTable.Columns.Add("MS_IMAGE", typeof(Byte[]));      //계측기 이미지


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_NO"] = layoutRow["MS_NO"];
            paramRow["ASSET_NO"] = layoutRow["ASSET_NO"];
            paramRow["MS_TYPE"] = layoutRow["MS_TYPE"];
            paramRow["MS_STATE"] = layoutRow["MS_STATE"];
            paramRow["MS_CAT"] = layoutRow["MS_CAT"];
            paramRow["MS_NAME"] = layoutRow["MS_NAME"];
            paramRow["MS_SERIAL_NO"] = layoutRow["MS_SERIAL_NO"];
            paramRow["MS_SPEC"] = layoutRow["MS_SPEC"];
            paramRow["MS_MAKER"] = layoutRow["MS_MAKER"];
            paramRow["MS_COST"] = layoutRow["MS_COST"];
            paramRow["MS_BUY_DATE"] = layoutRow["MS_BUY_DATE"];
            paramRow["MS_PERIOD"] = layoutRow["MS_PERIOD"];
            paramRow["MS_NEXT_DATE"] = layoutRow["MS_NEXT_DATE"];
            paramRow["MS_IMAGE"] = layoutRow["MS_IMAGE"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_INS", paramSet, "RQSTDT", "RSLTDT,RSLTDT_PART",
              QuickSaveClose,
              QuickException);
        }

        void QuickSaveClose(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, true);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}

