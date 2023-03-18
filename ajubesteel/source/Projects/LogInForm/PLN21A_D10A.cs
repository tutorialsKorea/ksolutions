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
using BizManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace LogInForm
{
    public sealed partial class PLN21A_D10A : BaseMenuDialog
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

       


        public PLN21A_D10A(object linkData)
        {

            InitializeComponent();

            _LinkData = linkData;

        }

        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            (acLayoutControl1.GetEditor("PROD_FLAG").Editor as acLookupEdit).SetCode("P006");
            (acLayoutControl1.GetEditor("PROD_TYPE").Editor as acLookupEdit).SetCode("P010");

            base.DialogInit();

        }

        public override void DialogNew()
        {
            //새로 만들기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            base.DialogNew();

        }

        public override void DialogOpen()
        {
            //열기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            DataRow linkRow = _LinkData as DataRow;

            acLayoutControl1.DataBind(linkRow, true);

            base.DialogOpen();

        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어

            try
            {
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //개발현황 이동
                if (ParentControl is MainForm pForm)
                {

                    pForm.MoveMenu2("PLN20A", _LinkData);
                }

                if (ParentControl is MainForm_V2 pForm2)
                {

                    pForm2.MoveMenu2("PLN20A", _LinkData);
                }

                if (ParentControl is MainForm_V3 pForm3)
                {

                    pForm3.MoveMenu2("PLN20A", _LinkData);
                }

                if (ParentControl is MainForm_V4 pForm4)
                {

                    pForm4.MoveMenu2("PLN20A", _LinkData);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}