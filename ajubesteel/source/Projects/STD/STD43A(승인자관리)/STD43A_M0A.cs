using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;

using BizManager;

namespace STD
{
    public sealed partial class STD43A_M0A : BaseMenu
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

        public STD43A_M0A()
        {
            InitializeComponent();
        }

        //public override bool MenuDestory(object sender)
        //{

        //    return base.MenuDestory(sender);
        //}

        //public override void MenuGotFocus()
        //{
        //    base.MenuGotFocus();
        //}

        //public override void MenuLostFocus()
        //{

        //    base.MenuLostFocus();
        //}

        //public override void MenuInitComplete()
        //{
            
        //    base.MenuInitComplete();
        //}

        public override void MenuInit()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD43A_SER", paramSet, "RQSTDT", "RSLTDT");
            DataTable data = resultSet.Tables[1];

            foreach (DataRow dr in data.Rows)
            {
                switch (dr["APP_TYPE"].ToString())
                {
                    case "ATD":
                        acLayoutControl1.DataBind(dr, true);
                        break;
                    case "PRS":
                        acLayoutControl3.DataBind(dr, true);
                        break;
                    
                    case "HOL":
                        acLayoutControl5.DataBind(dr, true);
                        break;
                    case "OUT":
                        acLayoutControl6.DataBind(dr, true);
                        break;
                    //case "PUR":
                    //    acLayoutControl2.DataBind(dr, true);
                    //    break;
                    //case "AS":
                    //    acLayoutControl4.DataBind(dr, true);
                    //    break;
                }
            }

            DataRow[] pur_list = data.Select("APP_TYPE = 'PUR'", "APP_SEQ");
            
            if (pur_list.Length > 0) lcPUR1.DataBind(pur_list[0], true);
            if (pur_list.Length > 1) lcPUR2.DataBind(pur_list[1], true);
            if (pur_list.Length > 2) lcPUR3.DataBind(pur_list[2], true);

            DataRow[] as_list = data.Select("APP_TYPE = 'AS'", "APP_SEQ");

            if (as_list.Length > 0) lcAS1.DataBind(as_list[0], true);
            if (as_list.Length > 1) lcAS2.DataBind(as_list[1], true);
            if (as_list.Length > 2) lcAS3.DataBind(as_list[2], true);

            DataTable dtorg = resultSet.Tables["RSLTDT_ORG"];

            leAsOrg1.SetData("ORG_NAME", "ORG_CODE", dtorg);
            leAsOrg2.SetData("ORG_NAME", "ORG_CODE", dtorg);
            leAsOrg3.SetData("ORG_NAME", "ORG_CODE", dtorg);
            lePurOrg1.SetData("ORG_NAME", "ORG_CODE", dtorg);
            lePurOrg2.SetData("ORG_NAME", "ORG_CODE", dtorg);
            lePurOrg3.SetData("ORG_NAME", "ORG_CODE", dtorg);

            lcAS1.OnValueChanged += LcAS1_OnValueChanged;
            lcAS2.OnValueChanged += LcAS1_OnValueChanged;
            lcAS3.OnValueChanged += LcAS1_OnValueChanged;
            base.MenuInit();
        }

        private void LcAS1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "ORG_CODE":

                    (layout.GetEditor("APP_EMP1") as acEmp).ORG = newValue;
                    (layout.GetEditor("APP_EMP2") as acEmp).ORG = newValue;
                    (layout.GetEditor("APP_EMP3") as acEmp).ORG = newValue;
                    (layout.GetEditor("APP_EMP4") as acEmp).ORG = newValue;
                    break;
            }
        }

        void Search()
        {
            //갱신
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataTable data = BizRun.QBizRun.ExecuteService(this, "STD43A_SER", paramSet, "RQSTDT", "RSLTDT").Tables[1];

            foreach (DataRow dr in data.Rows)
            {
                switch (dr["APP_TYPE"].ToString())
                {
                    case "ATD":
                        acLayoutControl1.DataBind(dr, true);
                        break;
                    case "PUR":
                        //acLayoutControl2.DataBind(dr, true);
                        break;
                    case "PRS":
                        acLayoutControl3.DataBind(dr, true);
                        break;
                    case "AS":
                        //acLayoutControl4.DataBind(dr, true);
                        break;
                    case "HOL":
                        acLayoutControl5.DataBind(dr, true);
                        break;
                    case "OUT":
                        acLayoutControl6.DataBind(dr, true);
                        break;
                }
            }

            DataRow[] pur_list = data.Select("APP_TYPE = 'PUR'", "APP_SEQ");

            if (pur_list.Length > 0) lcPUR1.DataBind(pur_list[0], true);
            if (pur_list.Length > 1) lcPUR2.DataBind(pur_list[1], true);
            if (pur_list.Length > 2) lcPUR3.DataBind(pur_list[2], true);

            DataRow[] as_list = data.Select("APP_TYPE = 'AS'", "APP_SEQ");

            if (as_list.Length > 0) lcAS1.DataBind(as_list[0], true);
            if (as_list.Length > 1) lcAS2.DataBind(as_list[1], true);
            if (as_list.Length > 2) lcAS3.DataBind(as_list[2], true);

            base.SetLog(QBiz.emExecuteType.REFRESH);

        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {


            if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {

                this.DataRefresh(null);

            }
            else
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                if (acLayoutControl1.ValidCheck() == false
                || acLayoutControl3.ValidCheck() == false)
                {
                    return;
                }



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("APP_TYPE", typeof(String)); //
                paramTable.Columns.Add("APP_EMP1", typeof(String)); //
                paramTable.Columns.Add("APP_EMP2", typeof(String)); //
                paramTable.Columns.Add("APP_EMP3", typeof(String)); //
                paramTable.Columns.Add("APP_EMP4", typeof(String)); //

                paramTable.Columns.Add("ORG_CODE", typeof(String)); //
                paramTable.Columns.Add("APP_SEQ", typeof(int)); //

                //if (1 == 1)
                {
                    //근태 ATD (attandance)
                    DataRow layoutRow = acLayoutControl1.CreateParameterRow();
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["APP_TYPE"] = "ATD";
                    paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                    paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                    paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                    paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                    paramTable.Rows.Add(paramRow);
                }

                //if (1 == 1)
                {
                    //구매 PUR (purchase)
                    DataRow layoutRow = lcPUR1.CreateParameterRow();
                    //if (layoutRow["ORG_CODE"].ToString() != "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "PUR";
                        paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                        paramRow["APP_SEQ"] = 1;
                        paramTable.Rows.Add(paramRow);
                    }


                    DataRow layoutRow2 = lcPUR2.CreateParameterRow();
                    //if (layoutRow2["ORG_CODE"].ToString() != "")
                    {

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "PUR";
                        paramRow["ORG_CODE"] = layoutRow2["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow2["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow2["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow2["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow2["APP_EMP4"];
                        paramRow["APP_SEQ"] = 2;
                        paramTable.Rows.Add(paramRow);
                    }

                    DataRow layoutRow3 = lcPUR3.CreateParameterRow();
                    //if (layoutRow3["ORG_CODE"].ToString() != "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "PUR";
                        paramRow["ORG_CODE"] = layoutRow3["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow3["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow3["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow3["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow3["APP_EMP4"];
                        paramRow["APP_SEQ"] = 3;
                        paramTable.Rows.Add(paramRow);
                    }


                }

                //if (1 == 1)
                {
                    //제안 PRS (Propose)
                    DataRow layoutRow = acLayoutControl3.CreateParameterRow();
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["APP_TYPE"] = "PRS";
                    paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                    paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                    paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                    paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                    paramTable.Rows.Add(paramRow);
                }

                {
                    //A/S
                    DataRow layoutRow = lcAS1.CreateParameterRow();
                    if (layoutRow["ORG_CODE"].ToString() != "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "AS";
                        paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                        paramRow["APP_SEQ"] = 1;
                        paramTable.Rows.Add(paramRow);
                    }
                    

                    DataRow layoutRow2 = lcAS2.CreateParameterRow();
                    if (layoutRow2["ORG_CODE"].ToString() != "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "AS";
                        paramRow["ORG_CODE"] = layoutRow2["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow2["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow2["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow2["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow2["APP_EMP4"];
                        paramRow["APP_SEQ"] = 2;
                        paramTable.Rows.Add(paramRow);
                    }

                    DataRow layoutRow3 = lcAS3.CreateParameterRow();
                    if (layoutRow["ORG_CODE"].ToString() != "")
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["APP_TYPE"] = "AS";
                        paramRow["ORG_CODE"] = layoutRow3["ORG_CODE"];
                        paramRow["APP_EMP1"] = layoutRow3["APP_EMP1"];
                        paramRow["APP_EMP2"] = layoutRow3["APP_EMP2"];
                        paramRow["APP_EMP3"] = layoutRow3["APP_EMP3"];
                        paramRow["APP_EMP4"] = layoutRow3["APP_EMP4"];
                        paramRow["APP_SEQ"] = 3;
                        paramTable.Rows.Add(paramRow);
                    }
                    
                }

                {
                    //연차계획
                    DataRow layoutRow = acLayoutControl5.CreateParameterRow();
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["APP_TYPE"] = "HOL";
                    paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                    paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                    paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                    paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                    paramTable.Rows.Add(paramRow);
                }

                {
                    //외근
                    DataRow layoutRow = acLayoutControl6.CreateParameterRow();
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["APP_TYPE"] = "OUT";
                    paramRow["APP_EMP1"] = layoutRow["APP_EMP1"];
                    paramRow["APP_EMP2"] = layoutRow["APP_EMP2"];
                    paramRow["APP_EMP3"] = layoutRow["APP_EMP3"];
                    paramRow["APP_EMP4"] = layoutRow["APP_EMP4"];
                    paramTable.Rows.Add(paramRow);
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "STD43A_INS", paramSet, "RQSTDT", "RSLTDT",
                QuickSave,
                QuickException);

                base.SetLog(QBiz.emExecuteType.SAVE);

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
                acAlert.Show(this, "저장되었습니다.", acAlertForm.enmType.Success);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

    }
}

