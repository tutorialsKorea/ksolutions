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


namespace POP
{
    public sealed partial class ChangeEmp : BaseMenuDialog
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


        public ChangeEmp()
        {
            InitializeComponent();


            gvEmployee.GridType = acGridView.emGridType.LIST_USERCONFIG;

            gvEmployee.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            gvEmployee.AddTextEdit("EMP_CODE", "사원코드", "UV9LGK3D", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddTextEdit("EMP_NAME", "사원명", "40266", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            gvEmployee.AddLookUpEdit("EMP_TYPE", "사원형태", "U2V6VABY", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S021");
            gvEmployee.AddLookUpEdit("EMP_TITLE", "직책", "72MOO4VJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "C040");

            
            
            POP20A_M0A.SetPopGridFont(gvEmployee, null);


            //이벤트 설정
           
            acTreeList1.AddTextEdit("ORG_NAME", "부서명", "40223", true, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(acTreeList1_FocusedNodeChanged);

            POP20A_M0A.SetPopGridFont(null, acTreeList1);

            acLayoutControl2.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl2_OnValueKeyDown);


            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }
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

        void acLayoutControl2_OnValueKeyDown(object sender, IBaseEditControl info, KeyEventArgs e)
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



        private DataSet _EmpSet = null;

        private DataSet _OrgSet = null;


        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            this.Search();

            //포커스
            acLayoutControl2.GetEditor("EMP_LIKE").FocusEdit();

        }


        public override void ChildContainerInit(Control sender)
        {
        

            base.ChildContainerInit(sender);

        }

        void Search()
        {

            DataRow layoutRow = acLayoutControl2.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("AVAILMC", typeof(String));
            paramTable.Columns.Add("EMP_LIKE", typeof(String));
            paramTable.Columns.Add("IS_ORG", typeof(String));
            paramTable.Columns.Add("ORG_TYPE_FLAG", typeof(String));
            paramTable.Columns.Add("IS_SYSTEM", typeof(Byte));
            paramTable.Columns.Add("EMP_TYPE", typeof(String));
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_LIKE"] = layoutRow["EMP_LIKE"];
            paramRow["IS_ORG"] = "1";
            paramRow["IS_SYSTEM"] = 0;
            //paramRow["EMP_TYPE"] = "1";
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

            base.OnClosing(e);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                this._EmpSet = e.result;

                gcEmployee.DataSource = e.result.Tables["RSLTDT"];

                acTreeList1.FocusedNode = acTreeList1.FindNodeByFieldValue("ORG_CODE", acInfo.UserORG);

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

            DataTable dtORGIn = new DataTable("RQSTDT");
            dtORGIn.Columns.Add("PLT_CODE");


            DataRow drORGIn = dtORGIn.NewRow();
            drORGIn["PLT_CODE"] = acInfo.PLT_CODE;

            dtORGIn.Rows.Add(drORGIn);
            DataSet dsORGIn = new DataSet();
            dsORGIn.Tables.Add(dtORGIn);

            this._OrgSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "CONTROL_ORG_SEARCH", dsORGIn, "RQSTDT", "RSLTDT");


            DataRow dr = _OrgSet.Tables["RSLTDT"].NewRow();
            dr["ORG_CODE"] = DBNull.Value;
            dr["ORG_NAME"] = acInfo.Resource.GetString("전체", "40583");

            this._OrgSet.Tables["RSLTDT"].Rows.InsertAt(dr, 0);


            DataRow[] rows = this._OrgSet.Tables["RSLTDT"].Select("ORG_PARENT = '' OR ORG_PARENT IS NULL");

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i]["ORG_PARENT"] = DBNull.Value;
            }

            

            acTreeList1.DataSource = this._OrgSet.Tables["RSLTDT"];

            

            acTreeList1.ExpandAll();

            base.OnLoad(e);
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

        private void acSimpleButton1_Click(object sender, EventArgs e)
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

        private void acSimpleButton2_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }



    }


}