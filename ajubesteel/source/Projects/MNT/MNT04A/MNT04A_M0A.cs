/*
 * ������ 2�� ��ó��(2HT:P-13), ����(GR:P-13), ��ó��(��ó��:P-18)�� �����Ѵٰ� �Ͽ��� - 2020.11.13 ȫ�ǿ� �̻� Ȯ��
 * �԰�
 * ���� ���ֽ�  ��������  ����Ʈ�� ǥ�� 
 * �԰�Ϸ�� ���� ��ǰ�԰� üũ �Ϸ��  ���ǥ�� (�ش���� ��ü)  / ����Ʈ�� ���� 
 * �԰�Ϸ����ǰ  ����Ʈ ��ܿ� ǥ��
 * �������� ���۽�  ����Ʈ���� ���ŵ�
 * 
 * ���
 * �������� ����Ʈ��  ǥ��  ��  ����ǥ��   ������ / Ȯ��  (���� �۾���Ȳ�� ����) 
 * ��ǰ �����Ϸ��  ���ǥ�� (�ش� ������ü)/ ����Ʈ�� ����
 * �����Ϸ����ǰ ����Ʈ ��ܿ�ǥ��
 * ������������ ��ǰ ����Ʈ  �ι�°ǥ��
 * ���� ���ֽ� ����Ʈ���� ���ŵ� 
 * ����Ʈ�� �ʹ� ���� ��   Ȯ���� ǥ������ �ʴ� ���ù�ư   
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;
using PlexityHide.GTP;

namespace MNT
{
    public sealed partial class MNT04A_M0A : BaseMenu
    {

        Timer _SearchingTimer;
        int _Interval = 30;

        /// <summary>
        /// 0 : 2�� ��ó�� (P-12)
        /// 1 : ����  (P-13)
        /// 2 : ��ó�� (P-18)
        /// </summary>
        string[] _ProcCode = new string[]{"P-12","P-13","P-18"};

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

        Color _WAIT;
        Color _RUN;
        Color _PAUSE;
        Color _FINISH;
        
        public MNT04A_M0A()
        {
            InitializeComponent();
        }

        public override void MenuInit()
        {
            base.MenuInit();

            _WAIT = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_WAIT").toColor();
            _RUN = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_RUN").toColor();
            _PAUSE = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_PAUSE").toColor();
            _FINISH = acInfo.SysConfig.GetSysConfigByServer("MC_OPERATE_CLR_FINISH").toColor();

            #region 2�� ��ó��(2HT) - P-12
            {
                #region acGridView1 �԰�
                acGridView1.GridType = acGridView.emGridType.AUTO_COL;
                acGridView1.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView1.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView1.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView1.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView1.AddTextEdit("NEXT_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion

                #region acGridView2 ���
                acGridView2.GridType = acGridView.emGridType.AUTO_COL;
                acGridView2.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView2.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView2.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView2.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView2.AddTextEdit("PRE_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion
            }
            #endregion

            #region ����(GR) - P-13
            {
                #region acGridView3 �԰�
                acGridView3.GridType = acGridView.emGridType.AUTO_COL;
                acGridView3.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView3.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView3.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView3.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView3.AddTextEdit("NEXT_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion

                #region acGridView4 ���
                acGridView4.GridType = acGridView.emGridType.AUTO_COL;
                acGridView4.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView4.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView4.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView4.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView4.AddTextEdit("PRE_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion
            }
            #endregion

            #region ��ó�� - P-18
            {
                #region acGridView5 �԰�
                acGridView5.GridType = acGridView.emGridType.AUTO_COL;
                acGridView5.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView5.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView5.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView5.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView5.AddTextEdit("NEXT_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion

                #region acGridView6 ���
                acGridView6.GridType = acGridView.emGridType.AUTO_COL;
                acGridView6.AddTextEdit("SCOMMENT", "����\n����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView6.AddLookUpVendor("VEN_CODE", "����", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
                acGridView6.AddMemoEdit("PART_CODE_NAME", "ǰ��/ǰ��", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true, true, false);
                acGridView6.AddTextEdit("QTY_COMP_TOTAL", "�Ϸ����\n/�Ѽ���", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                acGridView6.AddDateEdit("PLN_END_TIME", "�Ϸ�\n������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE2);
                acGridView6.AddTextEdit("PRE_PROC_NAME", "��������", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                #endregion
            }
            #endregion

            acGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            acGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            acGridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            acGridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            acGridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            acGridView6.OptionsSelection.EnableAppearanceFocusedCell = false;

            acGridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView5.OptionsSelection.EnableAppearanceFocusedRow = false;
            acGridView6.OptionsSelection.EnableAppearanceFocusedRow = false;

            acGridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            acGridView2.OptionsSelection.EnableAppearanceHideSelection = false;
            acGridView3.OptionsSelection.EnableAppearanceHideSelection = false;
            acGridView4.OptionsSelection.EnableAppearanceHideSelection = false;
            acGridView5.OptionsSelection.EnableAppearanceHideSelection = false;
            acGridView6.OptionsSelection.EnableAppearanceHideSelection = false;

            acGridView1.OptionsView.EnableAppearanceEvenRow = false;
            acGridView2.OptionsView.EnableAppearanceEvenRow = false;
            acGridView3.OptionsView.EnableAppearanceEvenRow = false;
            acGridView4.OptionsView.EnableAppearanceEvenRow = false;
            acGridView5.OptionsView.EnableAppearanceEvenRow = false;
            acGridView6.OptionsView.EnableAppearanceEvenRow = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();

            //Search();

            _SearchingTimer = new Timer(this.components);
            _SearchingTimer.Interval = 1 * 1000;
            _SearchingTimer.Tick += _SearchingTimer_Tick;
            _SearchingTimer.Start();

            barEditItem1.EditValue = _Interval;

            barEditItem1.EditValueChanged += BarEditItem1_EditValueChanged;


            acGridView1.RowStyle += AcGridView_RowStyle;
            acGridView2.RowStyle += AcGridView_RowStyle;
            acGridView3.RowStyle += AcGridView_RowStyle;
            acGridView4.RowStyle += AcGridView_RowStyle;
            acGridView5.RowStyle += AcGridView_RowStyle;
            acGridView6.RowStyle += AcGridView_RowStyle;
        }

      
        private void BarEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            _Interval = barEditItem1.EditValue.toInt();
            _SearchingTimer.Interval = _Interval * 1000;

        }

        private void _SearchingTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("search");
            Search();

            _SearchingTimer.Interval = _Interval * 1000;
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

        private void AcGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (view == null) return;

            DataRow row = view.GetDataRow(e.RowHandle);

            if (row == null) return;

            e.Appearance.ForeColor = Color.Black;

            switch (row["WO_FLAG"].ToString())
            {
                //case "0":
                //    e.Appearance.BackColor = Color.LightGray;
                //    break;
                case "1":
                    e.Appearance.BackColor = _WAIT;
                    break;
                case "2":
                    e.Appearance.BackColor = _RUN;
                    break;
                case "3":
                    e.Appearance.BackColor = _PAUSE;
                    break;
                case "4":
                    e.Appearance.BackColor = _FINISH;
                    break;
            }
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȸ
            //Search();
        }

        private void acBarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��üȭ������ ����
            try
            {
                BaseFullScreenMenu frm = new BaseFullScreenMenu();

                frm.Text = e.Item.Caption;

                frm.ShowFullScreen(this, this.pnlScreenBase);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void Search()
        {
            try
            {
                DataSet paramSet = new DataSet();
                DataTable paramTable = paramSet.Tables.Add("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("PROC_CODE", typeof(String));

                DataRow paramRow1 = paramTable.NewRow();
                paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow1["PROC_CODE"] = _ProcCode[0]; //2�� ��ó��(2HT)
                paramTable.Rows.Add(paramRow1);

                DataRow paramRow2 = paramTable.NewRow();
                paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow2["PROC_CODE"] = _ProcCode[1]; //����(GR)
                paramTable.Rows.Add(paramRow2);

                DataRow paramRow3 = paramTable.NewRow();
                paramRow3["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow3["PROC_CODE"] = _ProcCode[2]; //��ó��(��ó��)
                paramTable.Rows.Add(paramRow3);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "MNT04A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);
            }
            catch(Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                bool isCheck = checkProcessComplete.Checked;


                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT_IN"]
                                                                   .AsEnumerable()
                                                                   .Where(w => w["PROC_CODE"].ToString() == _ProcCode[0]
                                                                             && (w["WO_FLAG"].ToString() == "4" ? w["NEXT_ACT_START_TIME"].isNullOrEmpty() : true)
                                                                             && (IsFlag(w, isCheck)))
                                                                   .OrderByDescending(o => o["WO_SEQ"])
                                                                   .CopyToDataTable();
                acGridView3.GridControl.DataSource = e.result.Tables["RSLTDT_IN"]
                                                                    .AsEnumerable()
                                                                    .Where(w => w["PROC_CODE"].ToString() == _ProcCode[1]
                                                                              && (w["WO_FLAG"].ToString() == "4" ? w["NEXT_ACT_START_TIME"].isNullOrEmpty() : true)
                                                                              && (IsFlag(w, isCheck)))
                                                                    .OrderByDescending(o => o["WO_SEQ"])
                                                                    .CopyToDataTable();
                acGridView5.GridControl.DataSource = e.result.Tables["RSLTDT_IN"]
                                                                    .AsEnumerable()
                                                                    .Where(w => w["PROC_CODE"].ToString() == _ProcCode[2]
                                                                              && (w["WO_FLAG"].ToString() == "4" ? w["NEXT_ACT_START_TIME"].isNullOrEmpty() : true)
                                                                              && (IsFlag(w, isCheck)))
                                                                    .OrderByDescending(o => o["WO_SEQ"])
                                                                    .CopyToDataTable();



                acGridView2.GridControl.DataSource = e.result.Tables["RSLTDT_OUT"]
                                                                    .AsEnumerable()
                                                                    .Where(w => w["PROC_CODE"].ToString() == _ProcCode[0]
                                                                              && (IsFlag(w, isCheck)))
                                                                    .OrderByDescending(o => o["WO_FLAG"])
                                                                    .AsDataView()
                                                                    .ToTable();
                acGridView4.GridControl.DataSource = e.result.Tables["RSLTDT_OUT"]
                                                                    .AsEnumerable()
                                                                    .Where(w => w["PROC_CODE"].ToString() == _ProcCode[1]
                                                                              && (IsFlag(w, isCheck)))
                                                                    .OrderByDescending(o => o["WO_FLAG"])
                                                                    .CopyToDataTable();
                acGridView6.GridControl.DataSource = e.result.Tables["RSLTDT_OUT"]
                                                                    .AsEnumerable()
                                                                    .Where(w => w["PROC_CODE"].ToString() == _ProcCode[2]
                                                                              && (IsFlag(w, isCheck)))
                                                                    .OrderByDescending(o => o["WO_FLAG"])
                                                                    .CopyToDataTable();

                acGridView1.BestFitColumns();
                acGridView2.BestFitColumns();
                acGridView3.BestFitColumns();
                acGridView4.BestFitColumns();
                acGridView5.BestFitColumns();
                acGridView6.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT_OUT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private static bool IsFlag(DataRow w, bool isCheck)
        {
            if (isCheck)
            {
                switch (w["WO_FLAG"].ToString())
                {
                    case "2":
                    case "3":
                    case "4":
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }
        }

        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
        }
    }
}


