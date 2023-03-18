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
using CodeHelperManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MCN
{
    public sealed partial class MCN01A_D1A : BaseMenuDialog
    {

        public enum emStatus
        {
            [Description("지급")]
            GIVE,
            [Description("반납")]
            RETURN,
            [Description("폐기")]
            DISUSE
        }

        private emStatus formStatus;

        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }

        public emStatus FormStatus { get => formStatus; set => formStatus = value; }

        public override void BarCodeScanInput(string barcode)
        {


        }

 
        public DataRow _linkRow = null;
        public acGridView _linkView = null;
        public acGridView _mainView = null;

        public MCN01A_D1A(acGridView mainView, acGridView linkView, DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;

            _linkView = linkView;
            _mainView = mainView;

            acLayoutControl1.GetEditor("HIS_DATE").Value = acDateEdit.GetNowDateFromServer();
        }


        public override void DialogInit()
        {

            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            switch (FormStatus)
            {
                case emStatus.GIVE:
                    {
                        this.Text = "계측기 지급";
                        acLayoutControlItem3.Text = "지급일";
                    }
                    break;
                case emStatus.RETURN:
                    {
                        this.Text = "계측기 반납";
                        acLayoutControlItem3.Text = "반납일";
                    }
                    break;
                case emStatus.DISUSE:
                    {
                        this.Text = "계측기 폐기";
                        acLayoutControlItem3.Text = "폐기일";
                    }
                    break;
            }


            base.DialogInit();
        }


        public override void DialogNew()
        {
            barItemClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            acLayoutControl1.GetEditor("MS_NO").Value = _linkRow["MS_NO"];
            acLayoutControl1.GetEditor("MS_NAME").Value = _linkRow["MS_NAME"];
            acLayoutControl1.GetEditor("HIS_EMP").Value = acInfo.UserID;

            base.DialogNew();
        }



        public override void DialogOpen()
        {

            barItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barItemSaveClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;


            this.acLayoutControl1.KeyColumns = new string[] { "MS_NO" };

            this.acLayoutControl1.DataBind(_linkRow, true);


            //switch (FormStatus)
            //{
            //    case emStatus.GIVE:
            //        {
            //            acLayoutControlItem3.Text = "지급일";
            //        }
            //        break;
            //    case emStatus.RETURN:
            //        {
            //            acLayoutControlItem3.Text = "반납일";
            //        }
            //        break;
            //    case emStatus.DISUSE:
            //        {
            //            acLayoutControlItem3.Text = "폐기일";
            //        }
            //        break;
            //}

            base.DialogOpen();
        }

       
        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 저장 후 닫기

            if(acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow empRow = (acLayoutControl1.GetEditor("HIS_EMP").Editor as acEmp).SelectedRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MS_HIS_ID", typeof(String));
            paramTable.Columns.Add("MS_NO", typeof(String));
            paramTable.Columns.Add("HIS_EMP", typeof(String));
            paramTable.Columns.Add("HIS_EMP_NAME", typeof(String));
            paramTable.Columns.Add("HIS_TYPE", typeof(String));
            paramTable.Columns.Add("HIS_DATE", typeof(String));
            paramTable.Columns.Add("SCOMMENT", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MS_HIS_ID"] = _linkRow["MS_HIS_ID"];
            paramRow["MS_NO"] = layoutRow["MS_NO"];
            paramRow["HIS_EMP"] = layoutRow["HIS_EMP"];
            paramRow["HIS_EMP_NAME"] = empRow["EMP_NAME"];
            paramRow["HIS_DATE"] = layoutRow["HIS_DATE"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            switch (FormStatus)
            {
                case emStatus.GIVE:
                    {
                        paramRow["HIS_TYPE"] = "GIVE";
                    }
                    break;
                case emStatus.RETURN:
                    {
                        paramRow["HIS_TYPE"] = "RETURN";
                    }
                    break;
                case emStatus.DISUSE:
                    {
                        paramRow["HIS_TYPE"] = "DISUSE";
                    }
                    break;
            }

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_INS2", paramSet, "RQSTDT", "RSLTDT",
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

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _mainView.UpdateMapingRow(row, true);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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



        private void acBarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //클리어
            try
            {
                if (acMessageBox.Show(this, "초기화 하시겠습니까?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                acLayoutControl1.ClearValue();

                acLayoutControl1.GetEditor("HIS_EMP").FocusEdit();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();
            DataRow empRow = (acLayoutControl1.GetEditor("HIS_EMP").Editor as acEmp).SelectedRow;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MS_HIS_ID", typeof(String));
            paramTable.Columns.Add("MS_NO", typeof(String));
            paramTable.Columns.Add("MS_NAME", typeof(String));
            paramTable.Columns.Add("HIS_EMP", typeof(String));
            paramTable.Columns.Add("HIS_EMP_NAME", typeof(String));
            paramTable.Columns.Add("HIS_TYPE", typeof(String));
            paramTable.Columns.Add("HIS_DATE", typeof(String));
            paramTable.Columns.Add("SCOMMENT", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            //paramRow["MS_HIS_ID"] = layoutRow["MS_HIS_ID"];
            paramRow["MS_NO"] = layoutRow["MS_NO"];
            paramRow["MS_NAME"] = layoutRow["MS_NAME"];
            paramRow["HIS_EMP"] = layoutRow["HIS_EMP"];
            paramRow["HIS_EMP_NAME"] = empRow["EMP_NAME"];
            paramRow["HIS_DATE"] = layoutRow["HIS_DATE"];
            paramRow["SCOMMENT"] = layoutRow["SCOMMENT"];

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            switch (FormStatus)
            {
                case emStatus.GIVE:
                    {
                        paramRow["HIS_TYPE"] = "GIVE";
                    }
                    break;
                case emStatus.RETURN:
                    {
                        paramRow["HIS_TYPE"] = "RETURN";
                    }
                    break;
                case emStatus.DISUSE:
                    {
                        paramRow["HIS_TYPE"] = "DISUSE";
                    }
                    break;
            }

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "MCN01A_INS2", paramSet, "RQSTDT", "RSLTDT",
              QuickSave,
              QuickException);
        }

        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    _linkView.UpdateMapingRow(row, true);
                }

                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    _mainView.UpdateMapingRow(row, true);
                }

              //  this.DialogResult = System.Windows.Forms.DialogResult.OK;
   
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}

