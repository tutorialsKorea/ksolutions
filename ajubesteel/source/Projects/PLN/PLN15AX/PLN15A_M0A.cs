using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ControlManager;
using BizManager;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace PLN
{
    public sealed partial class PLN15A_M0A : BaseMenu
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

        public PLN15A_M0A()
        {
            InitializeComponent();
                        
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
        }

        public override void MenuInit()
        {
            try
            {
                acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEmp("EMP_CODE", "담당자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);

                //acGridView1.AddTextEdit("EMP_CODE", "작업자 코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                //acGridView1.AddTextEdit("EMP_NAME", "작업자명", "40542", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PROD_CODE", "금형코드", "40900", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ITEM_NAME", "수주명", "41906", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView1.AddTextEdit("CVND_NAME", "수주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("PLN_START_TIME", "계획시작일", "42WRL98V", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView1.AddDateEdit("PLN_END_TIME", "계획완료일", "HN5UC86F", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

                acGridView1.AddTextEdit("PART_QTY", "계획", "40037", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);

                acGridView1.AddTextEdit("PLAN_QTY", "계획", "40037", true, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.NUMERIC);

                acGridView1.AddTextEdit("DAY_ACT_QTY", "당일 실적", "Y6BT3CUY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);
                
                acGridView1.AddTextEdit("TOTAL_ACT_QTY", "총실적", "4A2RBKAP", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NUMERIC);

                                
                base.MenuInit();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        

        public override void ChildContainerInit(Control sender)
        {

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("PLN_DATE").Value = DateTime.Now;
            }            

           
            base.ChildContainerInit(sender);
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

       
        private void barItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        DateTime _dtNow = DateTime.Now;
        void Search()
        {


            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PLN_DATE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PLN_DATE"] = layoutRow["PLN_DATE"];
            _dtNow = layoutRow["PLN_DATE"].toDateTime();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN15A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

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

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (acGridView1.FocusedRowHandle < 0)
            {
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "PLN15A_SER2", paramSet, "RQSTDT", "RSLTDT");


            acGridView1.EndEditor();

            DataView view = acGridView1.GetDataSourceView("");

            DataRow focusRow = acGridView1.GetFocusedDataRow();

            DataSet dataSource = new DataSet();

            DataTable master = resultSet.Tables["RSLTDT"].Copy();
            master.TableName = "M";
            master.Columns.Add("DAY", typeof(DateTime));

            if (master.Rows.Count != 0)
            {
                master.Rows[0]["DAY"] = _dtNow;
            }
            else
            {
                DataRow rw = master.NewRow();
                rw["DAY"] = _dtNow;
                master.Rows.Add(rw);
            }
                       

            DataTable detail = view.ToTable();
            detail.TableName = "D";

            dataSource.Tables.AddRange(new DataTable[] { master, detail });

            //매입 원장
            ReportManager.acReportView.ShowReportCategoryPreview(this, "DEFAULT", dataSource);
        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //인원현황 설정

            if (!base.ChildFormContains("SETTING"))
            {

                PLN15A_D0A frm = new PLN15A_D0A();

                frm.DialogMode = BaseMenuDialog.emDialogMode.OPEN;

                frm.ParentControl = this;

                base.ChildFormAdd("SETTING", frm);

                frm.Show(this);

            }
            else
            {

                base.ChildFormFocus("SETTING");

            }

        }
        
    }
}
