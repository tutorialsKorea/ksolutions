using System;
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
    public sealed partial class ORD26A_D1A : BaseMenuDialog
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


        public ORD26A_D1A(acGridView linkView, object linkData)
        {
            InitializeComponent();


            _LinkData = linkData;

            _LinkView = linkView;


            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            acTextEdit1.Validated += new EventHandler(acTextEdit1_Validated);



        }

        void acTextEdit1_Validated(object sender, EventArgs e)
        {
            //소재 규격에 따른 중량계산

            if (acMaterial1.Value != null)
            {

                acLayoutControl1.GetEditor("WEIGHT_VOLUME").Value = acMaterial.GetMatWeight(acTextEdit1.EditValue, acMaterial1.SelectedRow["MQLTY_CODE"], acPart1.SelectedRow["SPEC_TYPE"]);

            }
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {


                case "PART_CODE":
                    {
                        if (layout.IsBinding == false)
                        {

                            layout.GetEditor("PART_QLTY").Value = acPart1.SelectedRow["MAT_QLTY"];

                            layout.GetEditor("UNIT_COST").Value = acPart1.SelectedRow["MAT_COST"];

                        }

                        if (acChecker.isNull(acPart1.SelectedRow["SPEC_TYPE"]) == false)
                        {

                            acTextEdit1.Enabled = true;

                            DataRow codeRow = acInfo.StdCodes.GetCodeRow("S062", acPart1.SelectedRow["SPEC_TYPE"]);

                            if (!codeRow["VALUE"].isNullOrEmpty())
                            {

                                acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                                acTextEdit1.Properties.Mask.EditMask = codeRow["VALUE"].toStringNull();

                                acTextEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;


                            }
                            else
                            {
                                acTextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                                acTextEdit1.Properties.Mask.EditMask = null;


                            }
                        }
                        else
                        {
                            acTextEdit1.Enabled = false;


                        }

                    }

                    break;

                case "PART_QLTY":

                    if (layout.IsBinding == false)
                    {

                        if (acMaterial1.IsSelected == true &&
                            acPart1.IsSelected == true)
                        {

                            layout.GetEditor("UNIT_COST").Value = acMaterial1.SelectedRow["MQLTY_UC"];


                            layout.GetEditor("WEIGHT_VOLUME").Value = acMaterial.GetMatWeight(layout.GetEditor("PART_SPEC").Value, acMaterial1.SelectedRow["MQLTY_CODE"], acPart1.SelectedRow["SPEC_TYPE"]);


                        }

                    }

                    break;

                case "WEIGHT_VOLUME":


                    if (layout.IsBinding == false)
                    {
                        //소재 재료비 계산

                        if (acPart1.IsSelected == true)
                        {


                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(acPart1.SelectedRow["MAT_TYPE"], newValue, layout.GetEditor("UNIT_COST").Value, layout.GetEditor("PART_QTY").Value);

                        }

                    }

                    break;


                case "PART_QTY":

                    if (layout.IsBinding == false)
                    {
                        //소재 재료비 계산
                        if (acPart1.IsSelected == true)
                        {

                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(acPart1.SelectedRow["MAT_TYPE"], layout.GetEditor("WEIGHT_VOLUME").Value, layout.GetEditor("UNIT_COST").Value, newValue);

                        }
                    }

                    break;


                case "UNIT_COST":


                    if (layout.IsBinding == false)
                    {
                        //소재 재료비 계산
                        if (acPart1.IsSelected == true)
                        {
                            layout.GetEditor("MAT_COST").Value = acMaterial.GetMatMoney(acPart1.SelectedRow["MAT_TYPE"], layout.GetEditor("WEIGHT_VOLUME").Value, newValue, layout.GetEditor("PART_QTY").Value);
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

                acLayoutControl1.GetEditor("PART_CODE").FocusEdit();
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

                layoutRow.Table.Columns.Add("PART_NAME", typeof(string));

                layoutRow.Table.Columns.Add("PART_QLTY_NAME", typeof(string));

                layoutRow.Table.Columns.Add("SEQ", typeof(int));

                layoutRow["PART_NAME"] = acPart1.SelectedRow["PART_NAME"];

                if (acMaterial1.IsSelected == true)
                {
                    layoutRow["PART_QLTY_NAME"] = acMaterial1.SelectedRow["MQLTY_NAME"];
                }

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

                layoutRow.Table.Columns.Add("PART_NAME", typeof(string));

                layoutRow.Table.Columns.Add("PART_QLTY_NAME", typeof(string));

                layoutRow.Table.Columns.Add("SEQ", typeof(int));


                layoutRow["PART_NAME"] = acPart1.SelectedRow["PART_NAME"];

                if (acMaterial1.IsSelected == true)
                {
                    layoutRow["PART_QLTY_NAME"] = acMaterial1.SelectedRow["MQLTY_NAME"];
                }

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