using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using System.Linq;
using BizManager;

namespace SYS
{
    public sealed partial class SYS33A_D0A : BaseMenuDialog
    {

        private class ResourceComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                if (x["RES_ID"].EqualsEx(y["RES_ID"]))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(DataRow obj)
            {
                return obj.ToString().GetHashCode();
            }
        }

        private class TooltipComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                if (x["TT_GUID"].EqualsEx(y["TT_GUID"]))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(DataRow obj)
            {
                return obj.ToString().GetHashCode();
            }
        }

        private class BizErrComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                if (x["NUMBER"].EqualsEx(y["NUMBER"]))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(DataRow obj)
            {
                return obj.ToString().GetHashCode();
            }
        }

        private class MenuListComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                if (x["MENU_CODE"].EqualsEx(y["MENU_CODE"]))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(DataRow obj)
            {
                return obj.ToString().GetHashCode();
            }
        }


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




        public SYS33A_D0A()
        {


            InitializeComponent();



        }



        public override void DialogInit()
        {


            //리소스


            acGridView1.AddTextEdit("RES_ID", "ID", "OYL0JR2M", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddMemoEdit("RES_CONTENTS", "내용", "O00RH4SM", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, false, true, false);

            acGridView1.KeyColumn = new string[] { "RES_ID" };


            //툴팁


            acGridView2.AddTextEdit("TT_GUID", "ID", "OYL0JR2M", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("TITLE", "머리글", "5XZYFT3U", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView2.AddMemoEdit("CONTENTS", "내용", "O00RH4SM", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, true, false, true, false);

            acGridView2.KeyColumn = new string[] { "TT_GUID" };


            //오류번호
   

            acGridView3.AddTextEdit("NUMBER", "오류번호", "5LI2L784", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.AddTextEdit("DESCRIPTION", "내용", "O00RH4SM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView3.KeyColumn = new string[] { "NUMBER" };

            
            //메뉴리스트

            acGridView4.AddPictrue("ICON", "아이콘", "XXQ7SLGS", true, DevExpress.Utils.HorzAlignment.Center, false, true);

            acGridView4.AddTextEdit("MENU_CODE", "메뉴코드", "C8PZLBQT", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("MENU_SEQ", "메뉴순번", "9PEZ7B4M", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("CLASSNAME", "클래스", "7BHPEKNS", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddTextEdit("ASSEMBLY", "어셈블리", "A6SPCCOM", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView4.AddCheckEdit("USE_FLAG", "사용여부", "UP426DTD", true, false, true, acGridView.emCheckEditDataType._BYTE);

            acGridView4.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            base.DialogInit();


        }

        public override void DialogInitComplete()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);



            BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "SYS33A_SER", paramSet, "RQSTDT", "RESOURCE,RESOURCE_UPDATE,TOOLTIP,TOOLTIP_UPDATE,BIZERR,BIZERR_UPDATE,MENULIST,MENULIST_UPDATE",
                QuickSearch,
                QuickException);

            base.DialogInitComplete();
        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                //리소스

                IEnumerable<DataRow> updateResource = e.result.Tables["RESOURCE_UPDATE"].AsEnumerable().Except(e.result.Tables["RESOURCE"].AsEnumerable(), new ResourceComparer());


                if (updateResource.Any())
                {
                    DataTable updateResourceDt = updateResource.CopyToDataTable();

                    acGridView1.GridControl.DataSource = updateResourceDt;
                }

                //툴팁
                IEnumerable<DataRow> updateTooltip = e.result.Tables["TOOLTIP_UPDATE"].AsEnumerable().Except(e.result.Tables["TOOLTIP"].AsEnumerable(), new TooltipComparer());

                if (updateTooltip.Any())
                {
                    DataTable updateTooltipDt = updateTooltip.CopyToDataTable();

                    acGridView2.GridControl.DataSource = updateTooltipDt;
                }


                //오류번호
                IEnumerable<DataRow> updateBizErr = e.result.Tables["BIZERR_UPDATE"].AsEnumerable().Except(e.result.Tables["BIZERR"].AsEnumerable(), new BizErrComparer());

                if (updateBizErr.Any())
                {
                    DataTable updateBizErrDt = updateBizErr.CopyToDataTable();

                    acGridView3.GridControl.DataSource = updateBizErrDt;
                }


                //메뉴리스트
                IEnumerable<DataRow> updateMenuList = e.result.Tables["MENULIST_UPDATE"].AsEnumerable().Except(e.result.Tables["MENULIST"].AsEnumerable(), new MenuListComparer());

                if (updateMenuList.Any())
                {
                    DataTable updateMenuListDt = updateMenuList.CopyToDataTable();

                    acGridView4.GridControl.DataSource = updateMenuListDt;
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);
        }


        private void barItemSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {

                DataTable resourceDt = new DataTable("RESOURCE");
                resourceDt.Columns.Add("PLT_CODE", typeof(String)); //
                resourceDt.Columns.Add("RES_ID", typeof(String)); //
                resourceDt.Columns.Add("RES_LANG", typeof(String)); //
                resourceDt.Columns.Add("RES_TYPE", typeof(Byte)); //
                resourceDt.Columns.Add("RES_CONTENTS", typeof(String)); //


                DataTable tooltipDt = new DataTable("TOOLTIP");
                tooltipDt.Columns.Add("PLT_CODE", typeof(String)); //
                tooltipDt.Columns.Add("TT_GUID", typeof(String)); //
                tooltipDt.Columns.Add("LANG", typeof(String)); //
                tooltipDt.Columns.Add("TITLE", typeof(String)); //
                tooltipDt.Columns.Add("CONTENTS", typeof(String)); //


                DataTable bizErrDt = new DataTable("BIZERR");
                bizErrDt.Columns.Add("PLT_CODE", typeof(String)); //
                bizErrDt.Columns.Add("NUMBER", typeof(Int32)); //
                bizErrDt.Columns.Add("LANG", typeof(String)); //
                bizErrDt.Columns.Add("DESCRIPTION", typeof(String)); //


                DataTable menuListDt = new DataTable("MENULIST");
                menuListDt.Columns.Add("PLT_CODE", typeof(String)); //
                menuListDt.Columns.Add("MENU_CODE", typeof(String)); //
                menuListDt.Columns.Add("MENU_PARENT", typeof(String)); //
                menuListDt.Columns.Add("MENU_SEQ", typeof(Int32)); //
                menuListDt.Columns.Add("SCOMMENT", typeof(String)); //
                menuListDt.Columns.Add("RES_ID", typeof(String)); //
                menuListDt.Columns.Add("CLASSNAME", typeof(String)); //
                menuListDt.Columns.Add("ASSEMBLY", typeof(String)); //
                menuListDt.Columns.Add("ICON", typeof(Byte[])); //
                menuListDt.Columns.Add("REG_EMP", typeof(String)); //
                menuListDt.Columns.Add("USE_FLAG", typeof(Byte)); //
                menuListDt.Columns.Add("IS_SYS_MENU", typeof(Byte)); //
                menuListDt.Columns.Add("IS_STD_MENU", typeof(Byte)); //
                menuListDt.Columns.Add("IS_PRO_MENU", typeof(Byte)); //
                //리소스 

                DataView resourceView = acGridView1.GetDataSourceView();

                for (int i = 0; i < resourceView.Count; i++)
                {

                    DataRow paramRow = resourceDt.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["RES_ID"] = resourceView[i]["RES_ID"];
                    paramRow["RES_LANG"] = acInfo.Lang;
                    paramRow["RES_TYPE"] = resourceView[i]["RES_TYPE"];
                    paramRow["RES_CONTENTS"] = resourceView[i]["RES_CONTENTS"];
                    resourceDt.Rows.Add(paramRow);

                }

                //툴팁

                DataView tooltipView = acGridView2.GetDataSourceView();

                for (int i = 0; i < tooltipView.Count; i++)
                {

                    DataRow paramRow = tooltipDt.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TT_GUID"] = tooltipView[i]["TT_GUID"];
                    paramRow["LANG"] = acInfo.Lang;
                    paramRow["TITLE"] = tooltipView[i]["TITLE"];
                    paramRow["CONTENTS"] = tooltipView[i]["CONTENTS"];
                    tooltipDt.Rows.Add(paramRow);

                }

                //오류번호

                DataView bizErrView = acGridView3.GetDataSourceView();

                for (int i = 0; i < bizErrView.Count; i++)
                {




                    DataRow paramRow = bizErrDt.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["NUMBER"] = bizErrView[i]["NUMBER"];
                    paramRow["LANG"] = acInfo.Lang;
                    paramRow["DESCRIPTION"] = bizErrView[i]["DESCRIPTION"];
                    bizErrDt.Rows.Add(paramRow);

                }

                //메뉴리스트

                DataView menuListView = acGridView4.GetDataSourceView();

                for (int i = 0; i < menuListView.Count; i++)
                {
                    DataRow paramRow = menuListDt.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["MENU_CODE"] = menuListView[i]["MENU_CODE"];
                    paramRow["MENU_PARENT"] = menuListView[i]["MENU_PARENT"];
                    paramRow["MENU_SEQ"] = menuListView[i]["MENU_SEQ"];
                    paramRow["SCOMMENT"] = menuListView[i]["SCOMMENT"];
                    paramRow["RES_ID"] = menuListView[i]["RES_ID"];
                    paramRow["CLASSNAME"] = menuListView[i]["CLASSNAME"];
                    paramRow["ASSEMBLY"] = menuListView[i]["ASSEMBLY"];
                    paramRow["ICON"] = menuListView[i]["ICON"];
                    paramRow["REG_EMP"] = menuListView[i]["REG_EMP"];
                    paramRow["USE_FLAG"] = menuListView[i]["USE_FLAG"];

                    paramRow["IS_SYS_MENU"] = menuListView[i]["IS_SYS_MENU"];
                    paramRow["IS_STD_MENU"] = menuListView[i]["IS_STD_MENU"];
                    paramRow["IS_PRO_MENU"] = menuListView[i]["IS_PRO_MENU"];

                    menuListDt.Rows.Add(paramRow);

                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(resourceDt);
                paramSet.Tables.Add(tooltipDt);
                paramSet.Tables.Add(bizErrDt);
                paramSet.Tables.Add(menuListDt);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.SAVE,
                "SYS33A_INS", paramSet, "RESOURCE,TOOLTIP,BIZERR,MENULIST", "",
                QuickSaveClose,
                QuickException);


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSaveClose(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


    }
}