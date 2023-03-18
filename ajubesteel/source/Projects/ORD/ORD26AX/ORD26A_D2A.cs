﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;

namespace ORD
{
    public sealed partial class ORD26A_D2A : BaseMenuDialog
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


        public ORD26A_D2A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

        }


        /// <summary>
        /// 공정임률
        /// </summary>
        private decimal _ProcWageRate = 0;


        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "PROC_CODE":

                    if (layout.IsBinding == false)
                    {
                        //공정임률 가져옴


                        DataRow wageRateRow = acWageRate.GetDataRow(acProc1.SelectedRow["CPROC_CODE"]);

                        if (wageRateRow != null)
                        {

                            this._ProcWageRate = wageRateRow["AVR"].toDecimal();


                        }
                        else
                        {
                            //공정임률 없음

                            this._ProcWageRate = 0;
                        }


                    }

                    break;

                case "PROC_TIME":

                    if (layout.IsBinding == false)
                    {
                        if (this._ProcWageRate != 0)
                        {
                            layout.GetEditor("PROC_COST").Value = this._ProcWageRate * (newValue.toDecimal() / 60);
                        }

                    }

                    break;
            }
        }





        public override void DialogInit()
        {


            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;




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


            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.DataBind((DataRow)_LinkData, true);


        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("PROC_CODE").FocusEdit();
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

                layoutRow.Table.Columns.Add("PROC_NAME", typeof(string));

                layoutRow.Table.Columns.Add("SEQ", typeof(int));

                layoutRow["PROC_NAME"] = this.acProc1.SelectedRow["PROC_NAME"];

                layoutRow["SEQ"] = this._LinkView.GetDataRowCount();


                this._LinkView.UpdateMapingRow(layoutRow, true);

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

                layoutRow.Table.Columns.Add("PROC_NAME", typeof(string));


                layoutRow.Table.Columns.Add("SEQ", typeof(int));


                layoutRow["PROC_NAME"] = this.acProc1.SelectedRow["PROC_NAME"];

                layoutRow["SEQ"] = linkRow["SEQ"];

                this._LinkView.UpdateMapingRow(layoutRow, true);


                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }






    }
}