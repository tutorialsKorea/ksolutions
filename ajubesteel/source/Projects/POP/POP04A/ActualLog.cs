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
    public sealed partial class ActualLog : BaseMenuDialog
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


        public ActualLog(DataRow linkData)
        {
            InitializeComponent();


            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(default_Font, panel_fontSize + 10, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
     


            _LinkData = linkData;

            #region 실적 그리드 
            acGridView1.GridType = acGridView.emGridType.SEARCH;
          //  acGridView1.AddLookUpEdit("INPUT_FLAG", "입력구분", "UYJGZO3N", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S039");
            acGridView1.AddDateEdit("WORK_DATE", "작업일", "40540", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("EMP_CODE", "작업자코드", "40551", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("EMP_NAME", "작업자", "40542", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
          //  acGridView1.AddLookUpEdit("MC_NM_CHECK", "유/무인", "NVJLZWWQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S033");
          //  acGridView1.AddLookUpEdit("PROC_STAT", "공정상태", "41055", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S038");
            acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
            acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
         // acGridView1.AddDateEdit("MAN_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
         // acGridView1.AddDateEdit("MAN_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
         // acGridView1.AddDateEdit("PRE_START_TIME", "준비시작시각", "RTWG2G0Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
         // acGridView1.AddDateEdit("PRE_END_TIME", "준비완료시각", "27CR70AY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);
         // acGridView1.AddTextEdit("MAN_TIME", "유인 실적공수", "CLLN0WCV", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
         // acGridView1.AddTextEdit("OT_TIME", "잔업 실적공수", "70NF0OEU", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
         // acGridView1.AddTextEdit("PRE_TIME", "준비 실적공수", "IVNZDKSG", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            //acGridView3.AddTextEdit("SELF_TIME", "무인 실적공수", "DWNYLR5F", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);
            //acGridView3.AddTextEdit("PAUSE_TIME", "작업중지시간", "42640", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.TIME);
         // acGridView1.AddTextEdit("WORK_TIME", "실적공수", "40402", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.TIME);
            acGridView1.AddTextEdit("WORK_QTY", "작업수량", "42643", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("OK_QTY", "양품수량", "42644", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddTextEdit("NG_QTY", "불량수량", "UGW32N5B", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddDateEdit("REG_DATE", "최초 등록일", "UL1O77MB", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("REG_EMP", "최초 등록자코드", "P72K0SQJ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("REG_EMP_NAME", "최초 등록자", "GPQHG8QQ", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("MDFY_DATE", "최근 수정일", "6RXQO0B2", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emDateMask.LONG_DATE);
            acGridView1.AddTextEdit("MDFY_EMP", "최근 수정자코드", "WDHSCE72", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("MDFY_EMP_NAME", "최근 수정자", "FHJDO4F0", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.KeyColumn = new string[] { "ACTUAL_ID" };
            #endregion

        }


        public override void DialogInit()
        {
            acGridView1.RowHeight = 45;

            acGridView1.ColumnPanelRowHeight = 70;

            SetPopGridFont(acGridView1);

            base.DialogInit();

        }

        public override void DialogNew()
        {
            
            try
            {
                acGridView1.ClearRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("WO_NO", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["WO_NO"] = _LinkData["WO_NO"];

                paramTable.Rows.Add(paramRow);

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "POP04A_SER4", paramSet, "RQSTDT", "RSLTDT",
                  QuickSearch,
                  QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

      
        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                acGridView1.GridControl.DataSource = e.result.Tables["RSLTDT"];
                acGridView1.BestFitColumns();

                base.SetLog(e.executeType, e.result.Tables["RSLTDT"].Rows.Count, e.executeTime);

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