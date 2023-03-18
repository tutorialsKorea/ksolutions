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

namespace STD
{
    public sealed partial class STD23A_D2B : BaseMenuDialog
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
        private acGridView _LinkView = null;

        public STD23A_D2B(object linkData)
        {
            InitializeComponent();

            this._LinkData = linkData;
            

            #region 이벤트 설정


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueChanging += new acLayoutControl.ValueChangingEventHandler(acLayoutControl1_OnValueChanging);

            #endregion


        }

        public STD23A_D2B(object linkData, acGridView linkView)
        {
            InitializeComponent();

            this._LinkData = linkData;
            this._LinkView = linkView;

            #region 이벤트 설정


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueChanging += new acLayoutControl.ValueChangingEventHandler(acLayoutControl1_OnValueChanging);

            #endregion


        }

        void acLayoutControl1_OnValueChanging(object sender, IBaseEditControl info, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "CAPA":

                    if (trackBarControl1.Properties.Maximum < e.NewValue.toInt())
                    {
                        e.Cancel = true;
                    }

                    break;


              

            }
                                    

        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "CAPA":


                    trackBarControl1.Value = newValue;


                    break;

             

                case "FT1_TRB":

                    if (layout.IsBinding == false)
                    {
                        acLayoutControl1.GetEditor("CAPA").Value = newValue;
                    }

                    break;



            }

        }



        public override void DialogOpen()
        {

            acLayoutControl1.DataBind(this._LinkData as DataRow, true);

            base.DialogOpen();

        }
        public override void DialogInit()
        {

            DataRow linkRow = this._LinkData as DataRow;

           
            DateTime workDate = (DateTime)linkRow["WORK_DATE"];

            acLayoutControl1.GetEditor("CAPA").Value = 0;
           
            trackBarControl1.Properties.Maximum = 1440;


            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false) return;
                
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataRow linkRow = this._LinkData as DataRow;

                DataTable paramTable1 = new DataTable("RQSTDT");

                paramTable1.Columns.Add("PLT_CODE");
                paramTable1.Columns.Add("WORK_DATE");
                paramTable1.Columns.Add("MC_CODE");
                paramTable1.Columns.Add("CAPA");
                paramTable1.Columns.Add("SCOMMENT");

                DataRow paramRow1 = paramTable1.NewRow();

                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["WORK_DATE"] = linkRow["WORK_DATE"].toDateString("yyyyMMdd");
                paramRow1["MC_CODE"] = linkRow["MC_CODE"];
                paramRow1["CAPA"] = layoutRow["CAPA"];
                paramRow1["SCOMMENT"] = layoutRow["SCOMMENT"];
                paramTable1.Rows.Add(paramRow1);
                
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
               
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD23B_UPD4", paramSet, "RQSTDT,RQSTDT2", "",
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

                this.DialogResult = DialogResult.OK;

                foreach(DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this,ex);

        }

    }
}