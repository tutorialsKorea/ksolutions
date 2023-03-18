using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ControlManager;
using DevExpress.XtraGrid.Views.Grid;

using BizManager;

namespace STD
{
    public sealed partial class STD04A_M0A : BaseMenu
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

        public STD04A_M0A()
        {

            InitializeComponent();
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

            // acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "����", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MC_CODE", "�����ڵ�", "41162", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "�����", "41202", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MC_GROUP", "����׷�", "40308", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C020");

            acGridView1.AddTextEdit("MC_MODEL", "�Ǹ𵨸�", "40400", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckEdit("MC_AUTOMATED", "���ΰ���", "40973", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MC_OS", "�ܺμ���", "40974", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MC_MGT_FLAG", "���� �������", "40065", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("IS_OPERATE_STATE", "������Ȳǥ��", "SR3IF2SN", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("IS_MULTI_START", "�����۾����� ��������", "MQBVM2AJ", true, false, false, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddCheckEdit("MULTI_START_DIV", "�����۾����� ��������� ��������", "HTHN5WFV", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddDateEdit("MC_OPEN_DATE", "��ȿ������", "40477", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddDateEdit("MC_CLOSE_DATE", "��ȿ������", "40478", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            //acGridView1.AddTextEdit("CPROC_CODE", "�ӷ��ڵ�", "0BXLGNK0", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("CPROC_NAME", "�ӷ���", "PQB42PSL", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_SEQ", "ǥ�ü���", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP", "������ڵ�", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_EMP_NAME", "�����", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_CODE", "�ŷ�ó �ڵ�", "40957", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("VEN_NAME", "�ŷ�ó��", "40956", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddCheckEdit("IS_SIGNAL", "��ȣ��濩��", "V4OOUWJC", true , false, true, acGridView.emCheckEditDataType._BYTE);

            //acGridView1.AddLookUpEdit("SIGNAL_TYPE", "��ȣ�������", "V919GCY1", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C022");

            //acGridView1.AddTextEdit("PLC_IP", "��ȣ����IP", "42557", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("PLC_PORT", "��ȣ���� ��Ʈ", "DDTXOCL0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MC_IP", "����IP", "42556", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.IP);

            //acGridView1.AddTextEdit("FTP_PORT", "FTP ��Ʈ", "881W45YM", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("FTP_DIR", "FTP ���丮", "EU47YV71", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("FTP_USER", "FTP ����", "X688UUTM", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("SCOMMENT", "���", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IF_MC_CODE", "IF �ڵ�", "K8GKZPXM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddDateEdit("REG_DATE", "���� �����", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("REG_EMP", "���� ������ڵ�", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("REG_EMP_NAME", "���� �����", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("MDFY_DATE", "�ֱ� ������", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            acGridView1.AddTextEdit("MDFY_EMP", "�ֱ� �������ڵ�", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MDFY_EMP_NAME", "�ֱ� ������", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddPictrue("MC_IMAGE", "���� �̹���", "E9NYS432", true, DevExpress.Utils.HorzAlignment.Near, false, false);

            acGridView1.KeyColumn = new string[] { "MC_CODE" };


            acGridView2.GridType = acGridView.emGridType.FIXED;

            //acGridView2.AddCheckEdit("SEL", "����", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView2.AddTextEdit("ORG_NAME", "�μ���", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_CODE", "����ڵ�", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView2.AddTextEdit("EMP_NAME", "�����", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.OptionsView.ShowIndicator = true;

            acGridView2.KeyColumn = new string[] { "EMP_CODE" };


            //�̺�Ʈ ����

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            //acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);    

            acLayoutControl1.OnValueKeyDown+=new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            base.MenuInit();
        }


        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
                this.GetAvailMc();
        }


        void acGridView1_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {




                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //�˾��޴� ����

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {

                this.Search();

            }

        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["MC_CODE"]);
            }
        }
        
        public override void MenuInitComplete()
        {


            base.MenuInitComplete();
        }


        public override bool MenuDestory(object sender)
        {

            return base.MenuDestory(sender);
        }


        public override void MenuGotFocus()
        {

            base.MenuGotFocus();
        }

        public override void MenuLostFocus()
        {

            base.MenuLostFocus();
        }



        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("MC_LIKE", typeof(String));
            paramTable.Columns.Add("MC_MODEL_LIKE", typeof(String));


            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            paramRow["MC_MODEL_LIKE"] = layoutRow["MC_MODEL_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD,
            "STD04A_SER", paramSet, "RQSTDT", "RSLTDT",
            QuickSearch,
            QuickException);
        }



        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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



        void QuickDel(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ

            try
            {
                this.Search();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //���θ���� 

            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    STD04A_D0A frm = new STD04A_D0A(acGridView1, null);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.NEW;


                    base.ChildFormAdd("NEW", frm);

                    frm.Show(this);


                }
                else
                {
                    base.ChildFormFocus("NEW");
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

            this.GetAvailMc();
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //����
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["MC_CODE"]))
                {

                    STD04A_D0A frm = new STD04A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["MC_CODE"], frm);


                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MC_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

            this.GetAvailMc();

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //����
            try
            {

                acGridView1.EndEditor();


                ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "���� �����Ͻðڽ��ϱ�?", "TB43FSY3", true, acInfo.Resource.GetString("��������", "A9DY9R6G"));


                if (msgResult.DialogResult == DialogResult.No)
                {
                    return;
                }



                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("DEL_EMP", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //����� �ڵ�
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    //���ϻ���

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["MC_CODE"] = focusRow["MC_CODE"];
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["DEL_REASON"] = msgResult.Parameter;

                    paramTable.Rows.Add(paramRow);


                }
                else
                {
                    //���� ����
                    for (int i = 0; i < selected.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["MC_CODE"] = selected[i]["MC_CODE"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }


                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.PROCESS,
                "STD04A_DEL", paramSet, "RQSTDT", "",
                QuickDel,
                QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //ǥ�ؼ��� ������ ����

                    this.acBarButtonItem1_ItemClick(null, null);
                }

            }
        }


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {




                if (e.MenuType == GridMenuType.User)
                {
                    acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {

                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //�˾��޴� ����

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }



        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //���� ������ �ҷ�����
            try
            {
                acBarButtonItem item = e.Item as acBarButtonItem;

                STD04A_D1A frm = new STD04A_D1A();

                frm.ParentControl = this;

                frm.Text = item.Caption;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Search();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        private void barItemHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ShowHelp();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }


        void GetAvailMc()
        {
            //�۾��� �ҷ�����
            //if (acGridView1.ValidFocusRowHandle() == true)
            //{
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MC_CODE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;


                paramRow["MC_CODE"] = focusRow["MC_CODE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD06A_SER2", paramSet, "RQSTDT", "RSLTDT");

            acGridView2.GridControl.DataSource = resultSet.Tables["RSLTDT"];
            //}
            //else
            //{
            //    acGridView2.ClearRow();
            //}


        }


    }
}

