using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace MAT
{
    public sealed partial class MAT03A_D0A : BaseMenuDialog
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

        private string _isShipFlag = "1";

        public MAT03A_D0A(string isShipFlag)
        {
            InitializeComponent();

            _isShipFlag = isShipFlag;

            #region 이벤트 설정
            //cmbORG.ButtonClick += cmbORG_ButtonClick;


            #endregion
        }

        void cmbORG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //if (cmbORG.SelectedRow != null)
                //    acEmp1.ORGCODE = cmbORG.SelectedRow["ORG_CODE"];
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

      

        public override void DialogInit()
        {
           

            acLayoutControl1.GetEditor("OUT_DATE").Value = DateTime.Now;
            acLayoutControl1.GetEditor("OUT_EMP").Value = acInfo.UserID;

            if (_isShipFlag == "1")
            {
                acLayoutControl1.GetEditor("IS_SHIP").Value = "1";
            }
            else
            {
                acLayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                acLayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; 
            }

            if (this.Parameter != null)
            {
                DataRow paramRow = this.Parameter as DataRow;

                //if (paramRow.Table.Columns.Contains("OUT_REQ_ORG"))
                    //acLayoutControl1.GetEditor("OUT_ORG").Value = paramRow["OUT_REQ_ORG"];
            }
            
            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                if (acEmp1.SelectedRow != null)
                {
                    acLayoutControl1.GetEditor("OUT_ORG").Value = acEmp1.SelectedRow["ORG_CODE"].toStringEmpty();
                }

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

