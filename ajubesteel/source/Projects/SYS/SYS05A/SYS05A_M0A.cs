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
using BizManager;

namespace SYS
{
    public sealed partial class SYS05A_M0A : BaseMenu
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

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }



        public SYS05A_M0A()
        {
            InitializeComponent();


        }


        public override void MenuInit()
        {


            acGridView1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);            

            acGridView1.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");

            acGridView1.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");

            acGridView1.KeyColumn = new string[] { "EMP_CODE" };


            //acGridView1.Columns["ORG_NAME"].GroupIndex = 0;
            //acGridView1.Columns["ORG_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


            acGridView2.GridType = acGridView.emGridType.SEARCH;


            acGridView2.AddDateEdit("LOGIN_TIME", "로그인 시간", "55D2IDHM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView2.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("RES_CONTENTS", "메뉴명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acCheckedComboBoxEdit1.AddItem("로그인 시간", true, "55D2IDHM", "LOGIN_TIME", true, false);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            base.MenuInit();
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetLoginLog();
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

        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "LOGIN_TIME";
                layout.GetEditor("S_DATE").Value = DateTime.Now.AddDays(-7);
                layout.GetEditor("E_DATE").Value = DateTime.Now;
            }



            base.ChildContainerInit(sender);
        }

        void Search()
        {
            if (acLayoutControl1.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            //모든 사원 불러오기
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            //paramTable.Columns.Add("S_LOGIN_TIME", typeof(String));
            //paramTable.Columns.Add("E_LOGIN_TIME", typeof(String));
            paramTable.Columns.Add("ORG_CODE", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ORG_CODE"] = layoutRow["ORG_CODE"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];

            //foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            //{
            //    switch (key)
            //    {
            //        case "LOGIN_TIME":
            //            //등록일
            //            paramRow["S_LOGIN_TIME"] = layoutRow["S_DATE"];
            //            paramRow["E_LOGIN_TIME"] = layoutRow["E_DATE"];

            //            break;
            //    }
            //}

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER3", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            //acGridView1.BestFitColumns();
            
        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        
        {
            //서치버튼 클릭
            try
            {
                this.Search();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        void GetLoginLog()
        {
            //사용자별 로그인 내역 불러오기
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("EMP_CODE", typeof(String)); //
                //paramTable.Columns.Add("LAN_ADDR_LIKE", typeof(String)); //
                //paramTable.Columns.Add("WAN_ADDR_LIKE", typeof(String)); //
                //paramTable.Columns.Add("MAC_ADDR", typeof(String)); //
                paramTable.Columns.Add("S_LOGIN_TIME", typeof(String)); //
                paramTable.Columns.Add("E_LOGIN_TIME", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["EMP_CODE"] = focusRow["EMP_CODE"];
                //paramRow["LAN_ADDR_LIKE"] = layoutRow["LAN_ADDR_LIKE"];
                //paramRow["WAN_ADDR_LIKE"] = layoutRow["WAN_ADDR_LIKE"];
                //paramRow["MAC_ADDR"] = layoutRow["MAC_ADDR"];



                foreach (string checkedKey in acCheckedComboBoxEdit1.GetKeyChecked())
                {
                    switch (checkedKey)
                    {

                        case "LOGIN_TIME":

                            paramRow["S_LOGIN_TIME"] = ((DateTime)layoutRow["S_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                            paramRow["E_LOGIN_TIME"] = ((DateTime)layoutRow["E_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");

                            //paramRow["S_CLASS_OPEN_TIME"] = layoutRow["S_DATE"];
                            //paramRow["E_CLASS_OPEN_TIME"] = layoutRow["E_DATE"];


                            break;

                    }

                }
                

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "SYS05A_SER", paramSet, "RQSTDT", "RSLTDT");

                acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];

                //acGridView2.BestFitColumns();
            }
            else
            {
                acGridView2.ClearRow();
            }


        }



    }
}
