using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;
using DevExpress.XtraEditors.Repository;
using BizManager;

namespace POP
{
    public sealed partial class ProdSpec : BaseMenuDialog
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


        public ProdSpec( DataRow linkData)
        {
            InitializeComponent();

            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down is acSimpleButton)
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("PANNEL_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }


            _LinkData = linkData;

        }


        public override void DialogInit()
        {

            acLayoutControl1.KeyColumns = new string[] { "PROD_CODE" };


            //공정명
            (acLayoutControl1.GetEditor("PROC_FLAG").Editor as acLookupEdit).SetCode("P005");
         

            //제품유형
            (acLayoutControl1.GetEditor("PROD_CATEGORY").Editor as acCheckedComboBoxEdit).AddItem("P009", 0, 1, CheckState.Unchecked);


            //제품분류
            (acLayoutControl1.GetEditor("PROD_TYPE").Editor as acLookupEdit).SetCode("P010");
            //프로브인
            (acLayoutControl1.GetEditor("PIN_TYPE").Editor as acCheckedComboBoxEdit).AddItem("P011", 0, 1, CheckState.Unchecked);
            //액츄에이터유무
            (acLayoutControl1.GetEditor("ACTUATOR_YN").Editor as acLookupEdit).SetCode("S101");
            //품목
            (acLayoutControl1.GetEditor("PART_CODE").Editor as acPart).Filter = "Actuator";


            //모듈타입
            (acLayoutControl1.GetEditor("MODULE_TYPE").Editor as acLookupEdit).SetCode("P018");
            //핀타입
            (acLayoutControl1.GetEditor("PIN_TYPE").Editor as acLookupEdit).SetCode("P019");
            //화상타입
            (acLayoutControl1.GetEditor("VISION_TYPE").Editor as acLookupEdit).SetCode("P020");
            //화상방향
            (acLayoutControl1.GetEditor("VISION_DIRECTION").Editor as acLookupEdit).SetCode("S102");


            //GND_PIN
            (acLayoutControl1.GetEditor("GND_PIN").Editor as acLookupEdit).SetCode("S100");
            //FIDUCIAL_MARK
            (acLayoutControl1.GetEditor("FIDUCIAL_MARK").Editor as acLookupEdit).SetCode("S100");
            //십자
            (acLayoutControl1.GetEditor("CROSS_MARKING").Editor as acLookupEdit).SetCode("S100");
            //vacuum
            (acLayoutControl1.GetEditor("VACUUM").Editor as acLookupEdit).SetCode("S100");


            //모듈 안착 타입
            (acLayoutControl1.GetEditor("MODULE_IN_TYPE").Editor as acLookupEdit).SetCode("P021");
            //모듈 안착 타입
            (acLayoutControl1.GetEditor("IF_PIN_BLOCK").Editor as acLookupEdit).SetCode("S100");
            //SOCKET_OPEN_방향
            (acLayoutControl1.GetEditor("SOCKET_OPEN_DIRECTION").Editor as acLookupEdit).SetCode("P022");


            //MSOP/DFM 작성
            (acLayoutControl1.GetEditor("MSOP_DFM").Editor as acCheckedComboBoxEdit).AddItem("P023", 0, 1, CheckState.Unchecked);
            //도면형식 
            (acLayoutControl1.GetEditor("DRAW_TYPE").Editor as acLookupEdit).SetCode("P024");



            Font font = acLayoutControl1.Font;
            
            font = new Font(font.Name, 13);
          
            acLayoutControl1.SetAllFont(font);

            //SetAllFont 에서 acMemoEdit는 처리가 안되어 따로 처리함
            acMemoEdit1.Properties.AppearanceReadOnly.Font = acTextEdit1.Properties.Appearance.Font;

            base.DialogInit();

        }

     


        public override void DialogNew()
        {
            //새로만들기

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_LIKE", typeof(String)); //수주코드/명 LIKE 검색
       
            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = _LinkData["PROD_CODE"];
           

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(
             this, QBiz.emExecuteType.LOAD,
             "ORD02A_SER", paramSet, "RQSTDT", "RSLTDT",
             QuickSearch,
             QuickException);

        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                DataRow Row = e.result.Tables["RSLTDT"].Rows[0];

                acLayoutControl1.DataBind(Row, true);
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



        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}