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
    public sealed partial class STD07A_M0A : BaseMenu
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

        public STD07A_M0A()
        {

            InitializeComponent();

            #region �׷� �� �̺�Ʈ

            acGridView1.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            acGridView1.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView1.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            #endregion

            #region Lot �� �̺�Ʈ

            //acGridView2.MouseDown += new MouseEventHandler(acGridView1_MouseDown);
            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView2.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(acGridView1_ShowGridMenuEx);
            //acGridView2.OnMapingRowChanged += new acGridView.MapingRowChangedEventHandler(acGridView1_OnMapingRowChanged);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);

            #endregion

            //xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
        }

        private void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == toolGroupTab)
            {
                btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        void acGridView1_OnMapingRowChanged(acGridView.emMappingRowChangedType type, DataRow row)
        {
            if (type == acGridView.emMappingRowChangedType.DELETE)
            {
                base.ChildFormRemove(row["TL_CODE"]);
            }
            
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

        }

        void acLayoutControl1_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            #region �׷� �� 

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddCheckEdit("SEL", "����", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("TL_CODE", "�����ڵ�", "836KV66Y", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_NAME", "������", "06LAUCR8", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddLookUpEdit("TL_TYPE", "��������", "LKGXVQFX", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView1.AddLookUpEdit("TL_LTYPE", "���� ��з�", "UD9RQ4VO", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView1.AddLookUpEdit("TL_MTYPE", "���� �ߺз�", "YEPCM8Q9", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView1.AddLookUpEdit("TL_STYPE", "���� �Һз�", "Q8YT0F8H", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView1.AddTextEdit("TL_SPEC", "�������", "43Q908E3", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("TL_SIZE", "ũ��", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("OVR_LENGTH", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SHANK", "��ũ", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("CUT_LENGTH", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("TL_MIN", "MIN", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TL_MAX", "MAX", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TL_DANGER_QTY", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("TL_QTY", "�����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("GIVE_QTY", "�������� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddTextEdit("TL_D_QTY", "��� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            //acGridView1.AddTextEdit("BAL_QTY", "���� �� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("STD_LIFE", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("TL_MAKER", "���ۻ�", "9HDUX97V", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("TL_UNITCOST", "�ܰ�", "40121", true , DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddLookUpEdit("TL_UNIT", "����", "40123", true , DevExpress.Utils.HorzAlignment.Center, false, true, false , "M003");
            acGridView1.AddTextEdit("SCOMMENT", "���", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("REG_DATE", "���� �����", "UL1O77MB", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "���� ������ڵ�", "P72K0SQJ", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "���� �����", "GPQHG8QQ", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "�ֱ� ������", "6RXQO0B2", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "�ֱ� �������ڵ�", "WDHSCE72", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "�ֱ� ������", "FHJDO4F0", true , DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "TL_CODE" };


            //���� ��з�
            (acLayoutControl1.GetEditor("TL_LTYPE").Editor as acLookupEdit).SetCode("T001");
            (acLayoutControl1.GetEditor("TL_MTYPE").Editor as acLookupEdit).SetCode("T002");
            (acLayoutControl1.GetEditor("TL_STYPE").Editor as acLookupEdit).SetCode("T003");
            

            #endregion


            #region Lot �� 

            acGridView2.GridType = acGridView.emGridType.SEARCH;

            acGridView2.AddCheckEdit("SEL", "����", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView2.AddTextEdit("TL_LOT", "LOT NO", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("TL_STAT", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T005");
            acGridView2.AddTextEdit("TL_LIFE", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_CODE", "�����ڵ�", "836KV66Y", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_NAME", "������", "06LAUCR8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddLookUpEdit("TL_TYPE", "��������", "LKGXVQFX", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T004");
            acGridView2.AddLookUpEdit("TL_LTYPE", "���� ��з�", "UD9RQ4VO", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T001");
            acGridView2.AddLookUpEdit("TL_MTYPE", "���� �ߺз�", "YEPCM8Q9", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T002");
            acGridView2.AddLookUpEdit("TL_STYPE", "���� �Һз�", "Q8YT0F8H", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "T003");
            acGridView2.AddTextEdit("TL_SPEC", "�������", "43Q908E3", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_SIZE", "ũ��", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("OVR_LENGTH", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("SHANK", "��ũ", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("CUT_LENGTH", "����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_MIN", "MIN", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("TL_MAX", "MAX", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("TL_DANGER_QTY", "���� ����", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("TL_MAKER", "���ۻ�", "9HDUX97V", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("TL_UNITCOST", "�ܰ�", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddLookUpEdit("TL_UNIT", "����", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M003");
            acGridView2.AddTextEdit("SCOMMENT", "���", "ARYZ726K", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("REG_DATE", "���� �����", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("REG_EMP", "���� ������ڵ�", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("REG_EMP_NAME", "���� �����", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddDateEdit("MDFY_DATE", "�ֱ� ������", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView2.AddTextEdit("MDFY_EMP", "�ֱ� �������ڵ�", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView2.AddTextEdit("MDFY_EMP_NAME", "�ֱ� ������", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView2.KeyColumn = new string[] { "TL_LOT" };

            #endregion

            base.MenuInit();
        }


        public override void ChildContainerInit(Control sender)
        {
            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;
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
            if (xtraTabControl1.SelectedTabPage == toolGroupTab)
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("TL_LTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_MTYPE", typeof(String)); //
                paramTable.Columns.Add("TL_STYPE", typeof(String)); //

                paramTable.Columns.Add("TL_LIKE", typeof(String)); //
                paramTable.Columns.Add("TL_SPEC_LIKE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                paramRow["TL_LTYPE"] = layoutRow["TL_LTYPE"];
                paramRow["TL_MTYPE"] = layoutRow["TL_MTYPE"];
                paramRow["TL_STYPE"] = layoutRow["TL_STYPE"];

                paramRow["TL_LIKE"] = layoutRow["TL_LIKE"];
                paramRow["TL_SPEC_LIKE"] = layoutRow["TL_SPEC_LIKE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "STD07A_SER", paramSet, "RQSTDT", "RSLTDT",
                QuickSearch,
                QuickException);
                
            }
            else if (xtraTabControl1.SelectedTabPage == toolLotTab)
            {
                DataRow layoutRow = acLayoutControl2.CreateParameterRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //

                paramTable.Columns.Add("TL_LIKE", typeof(String)); //
                paramTable.Columns.Add("TL_SPEC_LIKE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_LIKE"] = layoutRow["TL_LIKE"];
                paramRow["TL_SPEC_LIKE"] = layoutRow["TL_SPEC_LIKE"];

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.LOAD,
                "STD07A_SER2", paramSet, "RQSTDT", "RSLTDT",
                QuickSearchDetail,
                QuickException);
            }
            
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView1.RowCount, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearchDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView2.SetOldFocusRowHandle(false);

                base.SetLog(e.executeType, acGridView2.RowCount, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(ex.Message, this.Caption, acMessageBox.emMessageBoxType.CONFIRM);
        }



        void QuickDel(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                if (xtraTabControl1.SelectedTabPage == toolGroupTab)
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView1.DeleteMappingRow(row);

                    }
                }
                else
                {
                    foreach (DataRow row in e.result.Tables["RQSTDT"].Rows)
                    {
                        acGridView2.DeleteMappingRow(row);
                    }
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

        /// <summary>
        /// ���� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!base.ChildFormContains("NEW"))
                {

                    STD07A_D0A frm = new STD07A_D0A(acGridView1, null);
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

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null)
                {
                    return;
                }


                if (!base.ChildFormContains(focusRow["TL_CODE"]))
                {
                    STD07A_D0A frm = new STD07A_D0A(acGridView1, focusRow);
                    frm.ParentControl = this;
                    frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                    base.ChildFormAdd(focusRow["TL_CODE"], frm);
                    frm.Show(this);
                }
                else
                {
                    base.ChildFormFocus(focusRow["TL_CODE"]);
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (xtraTabControl1.SelectedTabPage == toolGroupTab)
                {
                    DelToolGroup();
                }
                else
                {
                    DelToolLot();
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void DelToolGroup()
        {
            acGridView1.EndEditor();

            ParameterYesNoDialogResult msgResult = acMessageBox.ShowParameterYesNo(this, "���� �����Ͻðڽ��ϱ�?", "TB43FSY3", true, acInfo.Resource.GetString("��������", "A9DY9R6G"));

            if (msgResult.DialogResult == DialogResult.No)
            {
                return;
            }



            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //����� �ڵ�
            paramTable.Columns.Add("TL_CODE", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //
            paramTable.Columns.Add("DEL_REASON", typeof(String)); //����� �ڵ�

            DataView selected = acGridView1.GetDataSourceView("SEL = '1'");

            if (selected.Count == 0)
            {
                //���ϻ���

                DataRow focusRow = acGridView1.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_CODE"] = focusRow["TL_CODE"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramRow["DEL_REASON"] = msgResult.Parameter;

                paramTable.Rows.Add(paramRow);


            }
            else
            {
                //���� ����
                for (int i = 0; i < selected.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TL_CODE"] = selected[i]["TL_CODE"];
                    paramRow["DEL_REASON"] = msgResult.Parameter;
                    paramRow["DEL_EMP"] = acInfo.UserID;


                    paramTable.Rows.Add(paramRow);
                }


            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.PROCESS,
            "STD07A_UPD", paramSet, "RQSTDT", "",
            QuickDel,
            QuickException);
        }

        private void DelToolLot()
        {
            acGridView2.EndEditor();

            if (acMessageBox.Show(this, "���� �����Ͻðڽ��ϱ�?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //����� �ڵ�
            paramTable.Columns.Add("TL_LOT", typeof(String)); //
            paramTable.Columns.Add("DEL_EMP", typeof(String)); //

            DataView selected = acGridView2.GetDataSourceView("SEL = '1'");

            if (selected.Count == 0)
            {
                //���ϻ���

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["TL_LOT"] = focusRow["TL_LOT"];
                paramRow["DEL_EMP"] = acInfo.UserID;
                paramTable.Rows.Add(paramRow);


            }
            else
            {
                //���� ����
                for (int i = 0; i < selected.Count; i++)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["TL_LOT"] = selected[i]["TL_LOT"];
                    paramRow["DEL_EMP"] = acInfo.UserID;


                    paramTable.Rows.Add(paramRow);
                }


            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.PROCESS,
            "STD07A_UPD3", paramSet, "RQSTDT", "",
            QuickDel,
            QuickException);
        }

        void acGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = acGridView1.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {
                    //ǥ�ذ��� ������ ����
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
                    acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else if (e.MenuType == GridMenuType.Row)
                {
                    if (e.HitInfo.RowHandle >= 0)
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        acBarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        acBarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                }


                //�˾��޴� ����

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        /// <summary>
        /// ��� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acBarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
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

        private void AcBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                return;
            }


            if (!base.ChildFormContains(focusRow["TL_CODE"]))
            {
                STD07A_D1A frm = new STD07A_D1A(acGridView1, acGridView2, focusRow);
                frm.ParentControl = this;
                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;
                base.ChildFormAdd(focusRow["TL_CODE"], frm);
                frm.Show(this);
            }
            else
            {
                base.ChildFormFocus(focusRow["TL_CODE"]);
            }
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                acGridView2.EndEditor();

                if (acMessageBox.Show(this, "���� �Ͻðڽ��ϱ�?", "", false, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //����� �ڵ�
                paramTable.Columns.Add("TL_LOT", typeof(String)); //
                paramTable.Columns.Add("TL_LIFE", typeof(decimal)); //

                if(acGridView2.GetAddModifyRows() is DataTable dt && dt.Rows.Count>0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["TL_LOT"] = row["TL_LOT"];
                        paramRow["TL_LIFE"] = row["TL_LIFE"];

                        paramTable.Rows.Add(paramRow);
                    }

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.PROCESS,
                    "STD07A_UPD2", paramSet, "RQSTDT", "RSLTDT",
                    QuickSave,
                    QuickException);
                }
                else
                {
                    acMessageBox.Show(this, "����� ���� �������� �ʽ��ϴ�.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                    return;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSave(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

    }
}

