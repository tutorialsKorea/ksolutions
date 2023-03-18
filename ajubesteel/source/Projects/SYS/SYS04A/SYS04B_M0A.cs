using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ControlManager;
using CodeHelperManager;
using BizManager;

namespace SYS
{
    public sealed partial class SYS04B_M0A : BaseMenu
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

        public SYS04B_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);
            acGridView2.ShowGridMenuEx +=new acGridView.ShowGridMenuExHandler(acGridView2_ShowGridMenuEx);



        }

        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }


                DataRow focusRow = acGridView1.GetFocusedDataRow();

                acGridView2.ClearColumns();

                if (focusRow["CTRL_CODE"].EqualsEx(acEmp.GetClassName()))
                {
                    acEmp.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acItem.GetClassName()))
                {
                    acItem.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acEst.GetClassName()))
                {
                    acEst.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acMachine.GetClassName()))
                {
                    acMachine.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acMaterial.GetClassName()))
                {
                    acMaterial.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acMenuList.GetClassName()))
                {
                    acMenuList.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acORG.GetClassName()))
                {
                    acORG.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acPart.GetClassName()))
                {
                    acPart.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acProdPartList.GetClassName()))
                {
                    acProdPartList.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acParentPart.GetClassName()))
                {
                    acParentPart.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acPlan.GetClassName()))
                {
                    acPlan.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acProject.GetClassName()))
                {
                    acProject.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acProc.GetClassName()))
                {
                    acProc.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acProd.GetClassName()))
                {
                    acProd.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acParentStdBopPart.GetClassName()))
                {
                    acParentStdBopPart.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acStdBop.GetClassName()))
                {
                    acStdBop.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acUserGroup.GetClassName()))
                {
                    acUserGroup.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acWageRate.GetClassName()))
                {
                    acWageRate.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acVendor.GetClassName()))
                {
                    acVendor.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acSimulation.GetClassName()))
                {
                    acSimulation.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acWorkOrder.GetClassName()))
                {
                    acWorkOrder.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acProcNg.GetClassName()))
                {
                    acProcNg.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acActual.GetClassName()))
                {
                    acActual.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acTool.GetClassName()))
                {
                    acTool.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acYpgo.GetClassName()))
                {
                    acYpgo.SetPopupGridView(acGridView2);
                }
                else if (focusRow["CTRL_CODE"].EqualsEx(acBillVendor.GetClassName()))
                {
                    acBillVendor.SetPopupGridView(acGridView2);
                }

                acLayoutControl1.GetEditor("SHOW_COLUMN").Value = acInfo.SysConfig.GetSysConfigByServer(focusRow["SHOW_COLUMN"].ToString());
                acLayoutControl1.GetEditor("AUTO_FIND").Value = acInfo.SysConfig.GetSysConfigByServer(focusRow["AUTO_FIND"].ToString());

                acGridView2.LoadUserConfig(this.Name, focusRow["CTRL_CODE"].toStringNull(), acInfo.DefaultConfigUser);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void acGridView2_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.Menu != null)
            {
                acMenuItem resetMenu = new acMenuItem(acInfo.Resource.GetString("초기화", "8NE7AZU0"));

                resetMenu.UserData = sender;

                resetMenu.Click += new EventHandler(resetMenu_Click);

                resetMenu.BeginGroup = true;

                e.Menu.Items.Add(resetMenu);

            }

        }

        void resetMenu_Click(object sender, EventArgs e)
        {
            acMenuItem item = sender as acMenuItem;

            acGridView view = item.UserData as acGridView;

            view.ResetUserConfig(this.Name, view.Tag.toStringNull(), acInfo.DefaultConfigUser);



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

            acGridView2.GridType = acGridView.emGridType.COMMON_CONTROL;

            acGridView1.GridType = acGridView.emGridType.LIST_SINGLE;

            acGridView1.AddHidden("CTRL_CODE", typeof(string));

            acGridView1.AddTextEdit("CTRL_NAME", "컨트롤", "S206OI4M", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            DataTable dt = new DataTable();

            dt.Columns.Add("CTRL_CODE", typeof(string));
            dt.Columns.Add("CTRL_NAME", typeof(string));
            dt.Columns.Add("SHOW_COLUMN", typeof(string));
            dt.Columns.Add("AUTO_FIND", typeof(string));

            DataRow row1 = dt.NewRow();
            row1["CTRL_CODE"] = acEmp.GetClassName();
            row1["CTRL_NAME"] = acInfo.Resource.GetString("사원 컨트롤", "HGETE9HZ");
            row1["SHOW_COLUMN"] = "CTRL_EMP_SHOW_COLUMN";
            row1["AUTO_FIND"] = "CTRL_EMP_AUTO_FIND";
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["CTRL_CODE"] = acItem.GetClassName();
            row2["CTRL_NAME"] = acInfo.Resource.GetString("수주 컨트롤", "CZ659EF0");
            row2["SHOW_COLUMN"] = "CTRL_ITEM_SHOW_COLUMN";
            row2["AUTO_FIND"] = "CTRL_ITEM_AUTO_FIND";
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["CTRL_CODE"] = acEst.GetClassName();
            row3["CTRL_NAME"] = acInfo.Resource.GetString("견적 컨트롤", "JBZ71VGA");
            row3["SHOW_COLUMN"] = "CTRL_EST_SHOW_COLUMN";
            row3["AUTO_FIND"] = "CTRL_EST_AUTO_FIND";
            dt.Rows.Add(row3);


            DataRow row4 = dt.NewRow();
            row4["CTRL_CODE"] = acMachine.GetClassName();
            row4["CTRL_NAME"] = acInfo.Resource.GetString("표준설비 컨트롤", "1HWSSFW4");
            row4["SHOW_COLUMN"] = "CTRL_MACHINE_SHOW_COLUMN";
            row4["AUTO_FIND"] = "CTRL_MACHINE_AUTO_FIND";
            dt.Rows.Add(row4);


            DataRow row5 = dt.NewRow();
            row5["CTRL_CODE"] = acMaterial.GetClassName();
            row5["CTRL_NAME"] = acInfo.Resource.GetString("표준재질 컨트롤", "LJ4YWAYO");
            row5["SHOW_COLUMN"] = "CTRL_MATERIAL_SHOW_COLUMN";
            row5["AUTO_FIND"] = "CTRL_MATERIAL_AUTO_FIND";
            dt.Rows.Add(row5);


            DataRow row6 = dt.NewRow();
            row6["CTRL_CODE"] = acMenuList.GetClassName();
            row6["CTRL_NAME"] = acInfo.Resource.GetString("메뉴 컨트롤", "I82G3CTG");
            row6["SHOW_COLUMN"] = "CTRL_MENU_SHOW_COLUMN";
            row6["AUTO_FIND"] = "CTRL_MENU_AUTO_FIND";
            dt.Rows.Add(row6);


            DataRow row7 = dt.NewRow();
            row7["CTRL_CODE"] = acORG.GetClassName();
            row7["CTRL_NAME"] = acInfo.Resource.GetString("부서 컨트롤", "HXWM2941");
            row7["SHOW_COLUMN"] = "CTRL_ORG_SHOW_COLUMN";
            row7["AUTO_FIND"] = "CTRL_ORG_AUTO_FIND";
            dt.Rows.Add(row7);


            DataRow row8 = dt.NewRow();
            row8["CTRL_CODE"] = acPart.GetClassName();
            row8["CTRL_NAME"] = acInfo.Resource.GetString("표준부품 컨트롤", "NLTHDAXH");
            row8["SHOW_COLUMN"] = "CTRL_PART_SHOW_COLUMN";
            row8["AUTO_FIND"] = "CTRL_PART_AUTO_FIND";
            dt.Rows.Add(row8);


            DataRow row9 = dt.NewRow();
            row9["CTRL_CODE"] = acProdPartList.GetClassName();
            row9["CTRL_NAME"] = acInfo.Resource.GetString("부품리스트 부품 컨트롤", "LDHGC0KO");
            row9["SHOW_COLUMN"] = "CTRL_PL_PART_SHOW_COLUMN";
            row9["AUTO_FIND"] = "CTRL_PL_PART_AUTO_FIND";
            dt.Rows.Add(row9);


            DataRow row10 = dt.NewRow();
            row10["CTRL_CODE"] = acParentPart.GetClassName();
            row10["CTRL_NAME"] = acInfo.Resource.GetString("부품리스트 모부품 컨트롤", "CZQCJYJV");
            row10["SHOW_COLUMN"] = "CTRL_PL_PPART_SHOW_COLUMN";
            row10["AUTO_FIND"] = "CTRL_PL_PPART_AUTO_FIND";
            dt.Rows.Add(row10);


            DataRow row11 = dt.NewRow();
            row11["CTRL_CODE"] = acPlan.GetClassName();
            row11["CTRL_NAME"] = acInfo.Resource.GetString("일정 컨트롤", "SAQH4MZ4");
            row11["SHOW_COLUMN"] = "CTRL_PLAN_SHOW_COLUMN";
            row11["AUTO_FIND"] = "CTRL_PLAN_AUTO_FIND";
            dt.Rows.Add(row11);



            DataRow row13 = dt.NewRow();
            row13["CTRL_CODE"] = acProject.GetClassName();
            row13["CTRL_NAME"] = acInfo.Resource.GetString("모델 컨트롤", "2MIML4HS");
            row13["SHOW_COLUMN"] = "CTRL_PRJ_SHOW_COLUMN";
            row13["AUTO_FIND"] = "CTRL_PRJ_AUTO_FIND";
            dt.Rows.Add(row13);


            DataRow row14 = dt.NewRow();
            row14["CTRL_CODE"] = acProc.GetClassName();
            row14["CTRL_NAME"] = acInfo.Resource.GetString("표준공정 컨트롤", "XIGUPEAI");
            row14["SHOW_COLUMN"] = "CTRL_PROC_SHOW_COLUMN";
            row14["AUTO_FIND"] = "CTRL_PROC_AUTO_FIND";
            dt.Rows.Add(row14);


            DataRow row15 = dt.NewRow();
            row15["CTRL_CODE"] = acProd.GetClassName();
            row15["CTRL_NAME"] = acInfo.Resource.GetString("금형 컨트롤", "QOM2KR8K");
            row15["SHOW_COLUMN"] = "CTRL_PROD_SHOW_COLUMN";
            row15["AUTO_FIND"] = "CTRL_PROD_AUTO_FIND";
            dt.Rows.Add(row15);



            DataRow row16 = dt.NewRow();
            row16["CTRL_CODE"] = acParentStdBopPart.GetClassName();
            row16["CTRL_NAME"] = acInfo.Resource.GetString("표준BOP 모부품 컨트롤", "0WEIB3XK");
            row16["SHOW_COLUMN"] = "CTRL_STDBOP_PPART_SHOW_COLUMN";
            row16["AUTO_FIND"] = "CTRL_STDBOP_PPART_AUTO_FIND";
            dt.Rows.Add(row16);



            DataRow row17 = dt.NewRow();
            row17["CTRL_CODE"] = acStdBop.GetClassName();
            row17["CTRL_NAME"] = acInfo.Resource.GetString("표준BOP 컨트롤", "IDN0LFH3");
            row17["SHOW_COLUMN"] = "CTRL_STDBOP_SHOW_COLUMN";
            row17["AUTO_FIND"] = "CTRL_STDBOP_AUTO_FIND";
            dt.Rows.Add(row17);



            DataRow row18 = dt.NewRow();
            row18["CTRL_CODE"] = acUserGroup.GetClassName();
            row18["CTRL_NAME"] = acInfo.Resource.GetString("사용자 그룹 컨트롤", "AUW727ON");
            row18["SHOW_COLUMN"] = "CTRL_USRGRP_SHOW_COLUMN";
            row18["AUTO_FIND"] = "CTRL_USRGRP_AUTO_FIND";
            dt.Rows.Add(row18);


            DataRow row19 = dt.NewRow();
            row19["CTRL_CODE"] = acWageRate.GetClassName();
            row19["CTRL_NAME"] = acInfo.Resource.GetString("임률 컨트롤", "U62QIRGO");
            row19["SHOW_COLUMN"] = "CTRL_UTC_SHOW_COLUMN";
            row19["AUTO_FIND"] = "CTRL_UTC_AUTO_FIND";
            dt.Rows.Add(row19);



            DataRow row20 = dt.NewRow();
            row20["CTRL_CODE"] = acVendor.GetClassName();
            row20["CTRL_NAME"] = acInfo.Resource.GetString("거래처 컨트롤", "HJAEDXSM");
            row20["SHOW_COLUMN"] = "CTRL_VENDOR_SHOW_COLUMN";
            row20["AUTO_FIND"] = "CTRL_VENDOR_AUTO_FIND";
            dt.Rows.Add(row20);



            DataRow row21 = dt.NewRow();
            row21["CTRL_CODE"] = acSimulation.GetClassName();
            row21["CTRL_NAME"] = acInfo.Resource.GetString("시뮬레이션 컨트롤", "S2GA5RHJ");
            row21["SHOW_COLUMN"] = "CTRL_SMLT_SHOW_COLUMN";
            row21["AUTO_FIND"] = "CTRL_SMLT_AUTO_FIND";
            dt.Rows.Add(row21);



            DataRow row22 = dt.NewRow();
            row22["CTRL_CODE"] = acWorkOrder.GetClassName();
            row22["CTRL_NAME"] = acInfo.Resource.GetString("작업지시 컨트롤", "N5QHJ6ZV");
            row22["SHOW_COLUMN"] = "CTRL_WO_SHOW_COLUMN";
            row22["AUTO_FIND"] = "CTRL_WO_AUTO_FIND";
            dt.Rows.Add(row22);

            DataRow row23 = dt.NewRow();
            row23["CTRL_CODE"] = acProcNg.GetClassName();
            row23["CTRL_NAME"] = acInfo.Resource.GetString("불량내역 컨트롤", "VG72BSAF");
            row23["SHOW_COLUMN"] = "CTRL_PROC_NG_SHOW_COLUMN";
            row23["AUTO_FIND"] = "CTRL_PROC_NG_AUTO_FIND";
            dt.Rows.Add(row23);


            DataRow row24 = dt.NewRow();
            row24["CTRL_CODE"] = acActual.GetClassName();
            row24["CTRL_NAME"] = acInfo.Resource.GetString("실적 컨트롤", "XHFRA0I9");
            row24["SHOW_COLUMN"] = "CTRL_ACTUAL_SHOW_COLUMN";
            row24["AUTO_FIND"] = "CTRL_ACTUAL_AUTO_FIND";
            dt.Rows.Add(row24);



            DataRow row25 = dt.NewRow();
            row25["CTRL_CODE"] = acTool.GetClassName();
            row25["CTRL_NAME"] = acInfo.Resource.GetString("표준공구 컨트롤", "KK3Z52DM");
            row25["SHOW_COLUMN"] = "CTRL_TOOL_SHOW_COLUMN";
            row25["AUTO_FIND"] = "CTRL_TOOL_AUTO_FIND";
            dt.Rows.Add(row25);


            DataRow row26 = dt.NewRow();
            row26["CTRL_CODE"] = acYpgo.GetClassName();
            row26["CTRL_NAME"] = acInfo.Resource.GetString("입고 컨트롤", "UZ6CQUL3");
            row26["SHOW_COLUMN"] = "CTRL_YPGO_SHOW_COLUMN";
            row26["AUTO_FIND"] = "CTRL_YPGO_AUTO_FIND";
            dt.Rows.Add(row26);

            DataRow row27 = dt.NewRow();
            row27["CTRL_CODE"] = acBillVendor.GetClassName();
            row27["CTRL_NAME"] = "마감처 컨트롤";
            row27["SHOW_COLUMN"] = "CTRL_BILL_VENDOR_SHOW_COLUMN";
            row27["AUTO_FIND"] = "CTRL_BILL_VENDOR_AUTO_FIND";
            dt.Rows.Add(row27);


            acGridView1.GridControl.DataSource = dt;



            base.MenuInit();
        }


        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장

            try
            {

                if (acGridView1.ValidFocusRowHandle() == false)
                {
                    return;
                }



                DataRow focusRow = acGridView1.GetFocusedDataRow();


                acInfo.SysConfig.SetSysConfigByServer(focusRow["SHOW_COLUMN"].ToString(), acLayoutControl1.GetEditor("SHOW_COLUMN").Value, "SYS");
                acInfo.SysConfig.SetSysConfigByServer(focusRow["AUTO_FIND"].ToString(), acLayoutControl1.GetEditor("AUTO_FIND").Value, "SYS");


                acGridView2.SaveDefaultUserConfig(acInfo.DefaultConfigUser, this.Name, focusRow["CTRL_CODE"].toStringNull(), acInfo.DefaultConfigName);


                base.SetLog(QBiz.emExecuteType.SAVE);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}

