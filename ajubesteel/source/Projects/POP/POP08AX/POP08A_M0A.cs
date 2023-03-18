using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using BizManager;

namespace POP
{
    public sealed partial class POP08A_M0A : BaseMenu
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

        public POP08A_M0A()
        {
            InitializeComponent();

            acLayoutControl1.OnValueChanged+=new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }



        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInit()
        {

            mainGrid.AddField("QC_DATE", "검사일", "3DETEJ14", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            mainGrid.AddField("PROD_CODE", "제품코드", "40900", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid.AddField("MODEL", "모델명", "40901", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid.AddField("PART", "제품명", "40743", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid.AddField("MOLD_NO", "차수", "40743", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);

            //mainGrid.AddCodeField("NG_CODE", "불량 항목", "J0Q7135N", true, DevExpress.XtraPivotGrid.PivotArea.ColumnArea, DevExpress.Utils.HorzAlignment.Near, "C401");
            mainGrid.AddField("CD_NAME", "불량 항목", "J0Q7135N", true, DevExpress.XtraPivotGrid.PivotArea.ColumnArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            mainGrid.AddField("NG_QTY", "수량", "UGW32N5B", true, DevExpress.XtraPivotGrid.PivotArea.DataArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);

            mainGrid2.AddField("LOT_NO", "LOT 번호", "E8VJLLSA", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("PROD_CODE", "제품코드", "40900", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("MODEL", "모델명", "40901", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("PART", "제품명", "40743", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("MOLD_NO", "차수", "40743", false, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);

            
            mainGrid2.AddField("PROD_VND", "고객사", "1WZQHKCW", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("MAT_CODE", "원자재코드", "40239", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("EMP_CODE", "생산담당자", "OFW5ZVHR", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Near, acPivotGridControl.emPivotMask.NONE);
            mainGrid2.AddField("QC_DATE", "검사일", "3DETEJ14", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.SHORT_DATE);

            mainGrid2.AddField("PROD_QTY", "생산 수량", "40345", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);
            mainGrid2.AddField("QC_QTY", "검사 수량", "F4CJSPWC", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);
            mainGrid2.AddField("NG_QTY", "부적합수량", "UGW32N5B", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);
            mainGrid2.AddField("OK_QTY", "양품수량", "3078IJNF", true, DevExpress.XtraPivotGrid.PivotArea.RowArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);

            mainGrid2.AddField("CD_NAME", "불량 항목", "J0Q7135N", true, DevExpress.XtraPivotGrid.PivotArea.ColumnArea, DevExpress.Utils.HorzAlignment.Center, acPivotGridControl.emPivotMask.NONE);

            mainGrid2.AddField("D_NG_QTY", "수량", "UGW32N5B", true, DevExpress.XtraPivotGrid.PivotArea.DataArea, DevExpress.Utils.HorzAlignment.Far, acPivotGridControl.emPivotMask.QTY);


            acCheckedComboBoxEdit1.AddItem("검사일", true, "3DETEJ14", "QC_DATE", true, false);

            mainGrid.CustomDrawFieldValue += new DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventHandler(mainGrid_CustomDrawFieldValue);
            mainGrid.CustomAppearance += new DevExpress.XtraPivotGrid.PivotCustomAppearanceEventHandler(mainGrid_CustomAppearance);
            base.MenuInit();
        }

        void mainGrid_CustomAppearance(object sender, DevExpress.XtraPivotGrid.PivotCustomAppearanceEventArgs e)
        {
            //e.RowField.FieldName 
        }

        void mainGrid_CustomDrawFieldValue(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs e)
        {
            if (e.Field != null)
            {
                if (e.Area == DevExpress.XtraPivotGrid.PivotArea.DataArea)
                {
                    e.Appearance.BackColor = Color.Gray;
                }
            }
        }

        
        

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "QC_DATE";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;

            }

            base.ChildContainerInit(sender);
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    
                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

            }

        }


        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //
            paramTable.Columns.Add("S_QC_DATE", typeof(String)); //수주일 시작
            paramTable.Columns.Add("E_QC_DATE", typeof(String)); //수주일 종료
            paramTable.Columns.Add("MAT_CODE", typeof(String)); 
            paramTable.Columns.Add("EMP_CODE", typeof(String)); 

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = layoutRow["PROD_CODE"];
            paramRow["MAT_CODE"] = layoutRow["MAT_CODE"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "QC_DATE":

                        paramRow["S_QC_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_QC_DATE"] = layoutRow["E_DATE"];

                        break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            if (acTabControl1.SelectedTabPage == acTabPage1)
            {

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                        "POP08A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
            }
            else if (acTabControl1.SelectedTabPage == acTabPage2)
            {
                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                        "POP08A_SER2", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch2,
                        QuickException);
            }

        }
        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                mainGrid.DataSource = e.result.Tables["RSLTDT"];

                mainGrid.BestFit();

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickSearch2(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                mainGrid2.DataSource = e.result.Tables["RSLTDT"];

                mainGrid2.BestFit();

                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //조회
            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }




    }


}

