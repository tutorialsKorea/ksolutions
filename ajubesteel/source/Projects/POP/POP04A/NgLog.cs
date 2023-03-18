using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Linq;
using BizManager;

namespace POP
{
    public sealed partial class NgLog : BaseMenuDialog
    {

       
        public override void BarCodeScanInput(string barcode)
        {


        }

        private DataRow _LinkData = null;

        public DataRow LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }

       
        public static string default_Font = acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT");

        public static int panel_fontSize = acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt();


        public NgLog(DataRow linkData)
        {
            InitializeComponent();


            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(default_Font, panel_fontSize + 10, FontStyle.Regular, GraphicsUnit.Point);
                }
            }


            _LinkData = linkData;


            acGridView1.AddHidden("NG_ID", typeof(string));

            acGridView1.AddTextEdit("WO_NO", "작업지시번호", "40556", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("LINK_KEY", "실적번호", "ZU7TGN7X", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
     
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "FYVPQ9JZ", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
           
            acGridView1.AddTextEdit("CVND_NAME", "수주처명", "42428", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40743", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("EMP_CODE", "등록자코드", "40551", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "등록자명", "40545", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddDateEdit("WORK_DATE", "불량발생일", "F1HO50M4", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddLookUpEdit("MASTER_CAUSE", "주원인", "V4X4CXSS", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C400");

            acGridView1.AddLookUpEdit("DETAIL_CAUSE", "상세원인", "MQ60JVR0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "C401");

            //acGridView1.AddLookUpEdit("NG_CAT", "분류", "MQ60JVR0", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q005");

            //acGridView1.AddTextEdit("NG_OCCUR", "발생처", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("NG_MEASURE_EMP_NAME", "작업자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("NG_OUT_COST", "외주비용", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.MONEY);
           
            //acGridView1.AddTextEdit("NG_PROC_COST", "사내비용", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.MONEY);
            
            //acGridView1.AddTextEdit("NG_COST", "비용 합계", "WDHSCE72", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddTextEdit("QUANTITY", "발생 불량수량", "UGW32N5B", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            //acGridView1.AddTextEdit("WK_NG_QTY", "확정 불량수량", "UGW32N5B", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddLookUpEdit("NG_STATE", "불량상태", "587SOBFY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "Q003");

            //acGridView1.AddLookUpEdit("NG_TYPE", "불량형태", "C1VMAHMU", true, DevExpress.Utils.HorzAlignment.Center, false, true, true, "Q004");

            //acGridView1.AddMemoEdit("NG_CONTENTS", "불량내용", "IGBK9DTD", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);

            //acGridView1.AddMemoEdit("NG_CAUSE", "불량원인", "J0Q7135N", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);

            //acGridView1.AddMemoEdit("NG_MEASURE", "불량대책", "30PLWWE1", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, false, false, false, false);

            //acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

            //acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            //acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "NG_ID" };

            acGridView1.FocusedRowChanged += acGridView1_FocusedRowChanged;

        }

        void layoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            switch (info.ColumnName)
            {

                case "PROD_CODE":

                    this.Search();

                    break;

            }
        }



        public override void DialogInit()
        {
            acGridView1.RowHeight = 45;

            acGridView1.ColumnPanelRowHeight = 70;

            SetPopGridFont(acGridView1);

            base.DialogInit();

        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();

            this.Search();
        }


        void Search()
        {

        
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_NAME", typeof(String)); //
          //paramTable.Columns.Add("WO_NO", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_NAME"] = _LinkData["PROD_NAME"];
          //paramRow["WO_NO"] = _LinkData["WO_NO"];

         // 테스트용 PROD_NAME: "D44-5482341"

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "QCT01A_SER", paramSet, "RQSTDT", "RSLTDT",
                        QuickSearch,
                        QuickException);


        }

        void QuickException(object sender, QBiz QBiz, BizManager.BizException ex)
        {
            acMessageBox.Show(this, ex);
         
        }


        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
             
                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];

                acGridView1.SetOldFocusRowHandle(true);

                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }



        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetail();
        }

        void GetDetail()
        {
            if (acGridView1.ValidFocusRowHandle() == true)
            {
                DataRow focusRow = acGridView1.GetFocusedDataRow();

                if (focusRow == null) return;

                this.acAttachFileControl1.LinkKey = focusRow["NG_ID"];
                this.acAttachFileControl1.ShowKey = new object[] { focusRow["NG_ID"] };

            }
            else
            {
                this.acAttachFileControl1.LinkKey = null;
                this.acAttachFileControl1.ShowKey = null;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static void SetPopGridFont(acGridView grid)
        {
            int fontSz = 3;

            if (grid != null)
            {
                grid.Appearance.Row.Font = new Font(default_Font, panel_fontSize + fontSz);
                grid.Appearance.FocusedRow.Font = new Font(default_Font, panel_fontSize + fontSz, FontStyle.Bold);
                grid.Appearance.HideSelectionRow.Font = new Font(default_Font, panel_fontSize + fontSz);
                grid.Appearance.HeaderPanel.Font = new Font(default_Font, panel_fontSize + fontSz);
                grid.Appearance.GroupRow.Font = new Font(default_Font, panel_fontSize + fontSz);
            }

        }


    }
}