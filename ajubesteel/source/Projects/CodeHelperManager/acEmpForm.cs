using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ControlManager;
using BizManager;
using DevExpress.XtraTreeList.Nodes;


namespace CodeHelperManager
{
    public sealed partial class acEmpForm : BaseMenuDialog
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

        public acEmp.emMethodType ExecuteMethodType { get; set; }

        public acEmpForm()
        {
            InitializeComponent();


            gvEmployee.GridType = acGridView.emGridType.SEARCH;

            gvEmployee.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvEmployee.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S021");
            gvEmployee.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C040");


            //이벤트 설정
           
            acTreeList1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(acTreeList1_FocusedNodeChanged);


            this.gvEmployee.MouseDown += new MouseEventHandler(gvEmployee_MouseDown);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
        }

        void acTreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (this._EmpSet != null)
            {
                if (acTreeList1.Selection[0].GetValue("ORG_CODE").isNull() == true)
                {

                    this._EmpSet.Tables["RSLTDT"].DefaultView.RowFilter = string.Empty;

                }
                else
                {

                    this._EmpSet.Tables["RSLTDT"].DefaultView.RowFilter = "ORG_CODE = '" + acTreeList1.Selection[0].GetValue("ORG_CODE").ToString() + "'";
                }
            }
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

        void gvEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                GridHitInfo hitInfo = gvEmployee.CalcHitInfo(e.Location);

                if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                {

                    this.acBarButtonItem1_ItemClick(null, null);

                }

            }
        }


        private DataSet _EmpSet = null;

        private DataSet _OrgSet = null;


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            //포커스
            acLayoutControl1.GetEditor("EMP_LIKE").FocusEdit();

            if (this.ExecuteMethodType == acEmp.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_EMP_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }

            }
            else if (this.ExecuteMethodType == acEmp.emMethodType.QUICK_FIND)
            {
                this.Search();
            }
            else
            {
                this.Search();
            }


        }

        public override void ChildContainerInit(Control sender)
        {
            acEmp ctrl = base.ParentControl as acEmp;

            if (sender == acLayoutControl1)
            {
                acLayoutControl layout = sender as acLayoutControl;


                if (this.ExecuteMethodType == acEmp.emMethodType.QUICK_FIND)
                {
                    //코드 검색부분에 입력후 조회

                    layout.GetEditor("EMP_LIKE").Value = this.Parameter;

                }


            }


            base.ChildContainerInit(sender);

        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("AVAILMC", typeof(String));
            paramTable.Columns.Add("EMP_LIKE", typeof(String));
            paramTable.Columns.Add("IS_ORG", typeof(String));
            paramTable.Columns.Add("ORG_TYPE_FLAG", typeof(String));
            paramTable.Columns.Add("IS_SYSTEM", typeof(Byte));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            if (base.ParentControl is acEmp)
            {
                paramRow["AVAILMC"] = ((acEmp)base.ParentControl).AVAILMC;

            }
            else
            {
                paramRow["ORG_TYPE_FLAG"] = "1";
            }
            
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            paramRow["IS_ORG"] = "1";
            paramRow["IS_SYSTEM"] = 0;
            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this,
           QBiz.emExecuteType.LOAD,"CTRL","CONTROL_EMP_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           QuickSearch,
           QuickException);

           // BizRun.QBizRun.ExecuteService(this,
           //ControlManager.QBiz.emExecuteType.LOAD, "CONTROL_EMP_SEARCH", paramSet, "RQSTDT", "RSLTDT",
           //QuickSearch,
           //QuickException);

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            if (base.ParentControl is acEmp)
            {
                (base.ParentControl as acEmp)._ConditionStorage = layoutRow.Table.NewDataSet();
            }
            

            base.OnClosing(e);
        }
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                this._EmpSet = e.result;

                gcEmployee.DataSource = e.result.Tables["RSLTDT"];

                if (((acEmp)base.ParentControl).ORG != null)
                {
                    TreeListNode node = acTreeList1.FindNodeByFieldValue("ORG_CODE", ((acEmp)base.ParentControl).ORG);
                    acTreeList1.FocusedNode = node;
                }
                    

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


        protected override void OnLoad(EventArgs e)
        {

            bool isDev = false;

            DataTable dtORGIn = new DataTable("RQSTDT");
            dtORGIn.Columns.Add("PLT_CODE");
            dtORGIn.Columns.Add("IS_DEV", typeof(Byte));


            DataRow drORGIn = dtORGIn.NewRow();
            drORGIn["PLT_CODE"] = acInfo.PLT_CODE;

            if (base.ParentControl is acEmp)
            {
                drORGIn["IS_DEV"] = ((acEmp)base.ParentControl).isDev.toByte();

                if (drORGIn["IS_DEV"].ToString() == "0")
                {
                    drORGIn["IS_DEV"] = DBNull.Value;
                }

                if (((acEmp)base.ParentControl).isDev.toStringEmpty() == "1")
                {
                    isDev = true;
                }
            }


            dtORGIn.Rows.Add(drORGIn);
            DataSet dsORGIn = new DataSet();
            dsORGIn.Tables.Add(dtORGIn);

            this._OrgSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_ORG_SEARCH", dsORGIn, "RQSTDT", "RSLTDT");

            if (!isDev)
            {
                DataRow dr = _OrgSet.Tables["RSLTDT"].NewRow();
                dr["ORG_CODE"] = DBNull.Value;
                dr["ORG_NAME"] = acInfo.Resource.GetString("전체", "40583");


                this._OrgSet.Tables["RSLTDT"].Rows.InsertAt(dr, 0);

                DataRow[] rows = this._OrgSet.Tables["RSLTDT"].Select("ORG_PARENT = '' OR ORG_PARENT IS NULL");

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["ORG_PARENT"] = DBNull.Value;
                }
            }



            acTreeList1.DataSource = this._OrgSet.Tables["RSLTDT"];
            acTreeList1.ExpandAll();

            base.OnLoad(e);
        }


        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택

            try
            {
                DataRow focusRow = gvEmployee.GetFocusedDataRow();

                if (focusRow != null)
                {
                    this.OutputData = focusRow.NewTable();

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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