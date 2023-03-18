using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using BizManager;
using CodeHelperManager;

namespace STD
{
    public sealed partial class STD50A_D3A : BaseMenuDialog
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

        private DataRow _masterRow = null;

        private DataSet _dsEmp = new DataSet();

        public DataSet Receiver
        {
            get { return _dsEmp;  }
        }

        public STD50A_D3A(DataRow masterRow)
        {
            InitializeComponent();
            
            _masterRow = masterRow;

        }


        public override void DialogInit()
        {            
            barItemDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            acLayoutControl1.DataBind(_masterRow, false);
            acLayoutControl1.GetEditor("REV_DATE").Value = acDateEdit.GetNowDateFromServer();
            try
            {
                acLayoutControl1.GetEditor("REV_NO").Value = acLayoutControl1.GetEditor("REV_NO").Value.toInt() + 1;
            }
            catch { }


            base.DialogInit();
        }

  

        public override void DialogNew()
        {
            //새로만들기
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }


        public override void DialogOpen()
        {
            //열기
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
        }

        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //개정 이력 저장
            try
            {
                acLayoutControl1.GetEditor("REV_COMMENT").isRequired = true;

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void barItemClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("REV_NO").FocusEdit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void acSimpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!base.ChildFormContains("RECEIVER_NEW"))
                {

                    STD50A_D4A frm = new STD50A_D4A(null);

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd("RECEIVER_NEW", frm);

                    frm.ParentControl = this;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        _dsEmp = frm.OutputData as DataSet;
                        acLayoutControl1.GetEditor("RECEIVER").Value = _dsEmp.Tables["RQSTDT"].Rows[0]["RECEIVER"];
                    }

                }
                else
                {

                    base.ChildFormFocus("RECEIVER_NEW");

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        
    }
}