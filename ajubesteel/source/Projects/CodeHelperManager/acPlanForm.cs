using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using ControlManager;
using BizManager;

namespace CodeHelperManager
{
    public sealed partial class acPlanForm : BaseMenuDialog
    {
        public acPlan.emMethodType ExecuteMethodType { get; set; }
        public acPlan.emShowPlanType ShowPlanType { get; set; }


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

        /// <summary>
        /// 입력 파라메터
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, object> InputParameters = new Dictionary<string, object>();

        public acPlanForm()
        {
            InitializeComponent();


            acTreeList1.KeyFieldName = "PRG_CODE";
            acTreeList1.ParentFieldName = "UP_CLASS";


            acTreeList1.AddTextEdit("PRG_CODE", "일정코드", "40962", true, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);

            acTreeList1.AddColorEdit("PRG_COLOR", "색상", "40281", true , DevExpress.Utils.HorzAlignment.Center, false, true);

            //acTreeList1.AddLookUpEdit("PRG_CLASS", "일정구분", "5PC6IAD6", true, DevExpress.Utils.HorzAlignment.Center, false, true, "S084", false);

            acTreeList1.AddTextEdit("PRG_NAME", "일정명", "40045", true, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);


            acTreeList1.MouseDown += new MouseEventHandler(acTreeList1_MouseDown);

        }


        protected override void OnShown(EventArgs e)
        {

            

            base.OnShown(e);

            if (this.ExecuteMethodType == acPlan.emMethodType.FIND)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("CTRL_PLAN_AUTO_FIND").toBoolean() == true)
                {
                    this.Search();

                }
            }


        }

        void Search()
        {
            acPlan parent = base.ParentControl as acPlan;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PRG_CLASS", typeof(Byte)); //
            paramTable.Columns.Add("MCLASS_FLAG", typeof(Byte)); //
            paramTable.Columns.Add("IS_OS", typeof(Byte)); //
            paramTable.Columns.Add("DATA_FLAG", typeof(Byte)); //


            //부모 파라메터 컬럼 생성

            if (base.ParentControl is acPlan)
            {

                acPlan ctrl = (acPlan)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }

            //창 파라메터 컬럼 생성

            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    if (!paramTable.Columns.Contains(parameter.Key))
                    {
                        paramTable.Columns.Add(parameter.Key, parameter.Value.GetType());
                    }

                }
            }

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            
            if(this.ShowPlanType == acPlan.emShowPlanType.L)
            {
                paramRow["PRG_CLASS"] = 1;
            }
            else if (this.ShowPlanType == acPlan.emShowPlanType.M)
            {
                paramRow["PRG_CLASS"] = 0;
            }
            else if (this.ShowPlanType == acPlan.emShowPlanType.MM)
            {
                paramRow["MCLASS_FLAG"] = 1;
                paramRow["PRG_CLASS"] = 0;

            }


            //부모 파라메터 입력

            if (base.ParentControl is acPlan)
            {

                acPlan ctrl = (acPlan)base.ParentControl;

                foreach (KeyValuePair<string, object> parameter in ctrl.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }

            }

            //창 파라메터 입력
            if (this.InputParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in this.InputParameters)
                {
                    paramRow[parameter.Key] = parameter.Value;
                }

            }


            paramRow["DATA_FLAG"] = 0;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet dsRslt = BizManager.BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "CONTROL_PLAN_SEARCH", paramSet, "RQSTDT", "RSLTDT");

            acTreeList1.DataSource = dsRslt.Tables["RSLTDT"];

            this.acTreeList1.ExpandAll();

        }



        void acTreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                TreeListHitInfo hitInfo = acTreeList1.CalcHitInfo(e.Location);

                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    this.acBarButtonItem2_ItemClick(null, null);
                }

            }
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acTreeList1.DataSource = e.result.Tables["RSLTDT"];


                this.acTreeList1.ExpandAll();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        public override string InstantLog
        {
            set
            {
                statusBarLog.Caption = value;
            }
        }


        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {

            acMessageBox.Show(this, ex);
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //선택
            try
            {
                if (acTreeList1.FocusedNode != null)
                {
                    DataRowView focusRowView = (DataRowView)acTreeList1.GetDataRecordByNode(acTreeList1.FocusedNode);

                    base.OutputData = focusRowView.Row.NewTable();

                    this.DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }
    }
}