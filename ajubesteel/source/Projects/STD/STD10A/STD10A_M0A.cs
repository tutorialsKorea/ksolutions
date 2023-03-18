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
    public sealed partial class STD10A_M0A : BaseMenu
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

        public STD10A_M0A()
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
            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddCheckEdit("SEL", "����", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

            acGridView1.AddTextEdit("MOLD_CODE", "�����ڵ�", "NZ2K4MWY", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MODEL", "Model", "KH7K1W1F", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MOLD_NAME", "ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            
            //acGridView1.AddTextEdit("MOLD_NUM", "ǰ��", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_CODE", "��ǰ�ڵ�", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROD_NAME", "�𵨸�", "40901", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PART", "��ǰ��", "40743", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MOLD_NO", "����", "N05MMEKM", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddTextEdit("CAVITY", "CAVITY", "C3O121LD", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MATERIAL", "�����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("SIZE", "������", "C3O121LD", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("WEIGHT", "�߷�", "C3O121LD", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TYPE", "����", "C3O121LD", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("GATE", "����Ʈ", "C3O121LD", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("CUST_DATE", "������", "40902", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEmp("MOLD_EMP", "������ڵ�", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false);

            acGridView1.AddTextEdit("PROD_VND", "����ó�ڵ�", "42385", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_VND_NAME", "����ó", "40840", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("PROD_DATE", "������", "50272", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("BALJU_VND", "����ó�ڵ�", "42503", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("BALJU_VND_NAME", "����ó", "42504", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("BALJU_DATE", "������", "40206", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddTextEdit("SCOMMENT", "���", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PLT_CODE", "���", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);


            //acGridView1.AddDateEdit("REG_DATE", "���� �����", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);

            //acGridView1.AddTextEdit("REG_EMP", "���� ������ڵ�", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("REG_EMP_NAME", "���� �����", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            //acGridView1.AddDateEdit("MDFY_DATE", "�ֱ� ������", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);


            //acGridView1.AddTextEdit("MDFY_EMP", "�ֱ� �������ڵ�", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "�ֱ� ������", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.KeyColumn = new string[] { "MOLD_CODE" };


            //�̺�Ʈ ����

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);

            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);

            acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);


            acLayoutControl1.OnValueKeyDown+=new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            base.MenuInit();
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
                base.ChildFormRemove(row["MOLD_CODE"]);
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
            paramTable.Columns.Add("PLT_CODE", typeof(string));
            paramTable.Columns.Add("MOLD_LIKE", typeof(string));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["MOLD_LIKE"] = layoutRow["MOLD_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD,
                    "STD10A_SER", paramSet, "RQSTDT", "RSLTDT",
                    QuickSearch,
                    QuickException);
        }



        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
                //base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
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



        void QuickDel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                {
                    acGridView1.DeleteMappingRow(row);

                }

                //base.SetLog(
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

        private void AddItem()
        {
            //���θ���� 
            try
            {
                if (!base.ChildFormContains("NEW"))
                {
                    STD10A_D0A frm = new STD10A_D0A(acGridView1, null);

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

        }

        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void EditItem()
        {
            //����
            try
            {

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["MOLD_CODE"]))
                {

                    STD10A_D0A frm = new STD10A_D0A(acGridView1, focusRow);

                    frm.ParentControl = this;

                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                    base.ChildFormAdd(focusRow["MOLD_CODE"], frm);


                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["MOLD_CODE"]);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            EditItem();
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
                paramTable.Columns.Add("MOLD_CODE", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //����� �ڵ�
                paramTable.Columns.Add("DEL_REASON", typeof(String)); //
                paramTable.Columns.Add("MOLD_LIKE", typeof(String)); //
                paramTable.Columns.Add("S_REG_DATE", typeof(String));
                paramTable.Columns.Add("E_REG_DATE", typeof(String));

                DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

                if (selected.Count == 0)
                {
                    //���ϻ���

                    DataRow focusRow = acGridView1.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["MOLD_CODE"] = focusRow["MOLD_CODE"];
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
                        paramRow["MOLD_CODE"] = selected[i]["MOLD_CODE"];
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["DEL_REASON"] = msgResult.Parameter;

                        paramTable.Rows.Add(paramRow);
                    }


                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.PROCESS,
                        "STD10A_DEL", paramSet, "RQSTDT", "",
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


        void acGridView1_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
                //acBarButtonItem item = e.Item as acBarButtonItem;

                //STD04A_D1A frm = new STD04A_D1A();

                //frm.ParentControl = this;

                //frm.Text = item.Caption;

                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    this.Search();
                //}
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

        private void barAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void barEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditItem();
        }


    }
}

