using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using BizManager;

namespace POP
{
    public partial class SelProduct : BaseMenuDialog
    {
        public SelProduct()
        {
            InitializeComponent();

            Control[] con = POP20A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    if (down.Name != "btn")
                    {
                        ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 10,
                    FontStyle.Regular, GraphicsUnit.Point);
                    }
                    
                }
            }


            acGridView1.GridType = acGridView.emGridType.LIST_USERCONFIG2;

            acGridView1.AddTextEdit("PART_CODE", "부품코드", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_NAME", "부품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("STD_PT_NUM", "도면번호", "40743", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("MAT_LTYPE", "대분류", "40132", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M001");

            acGridView1.AddLookUpEdit("MAT_MTYPE", "중분류", "40630", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M002");

            acGridView1.AddLookUpEdit("MAT_STYPE", "소분류", "40338", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M008");

            acGridView1.AddTextEdit("PART_ENAME", "부품명(영문)", "40235", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);


            acGridView1.AddLookUpEdit("PART_PRODTYPE", "품목제작구분", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M007");


            acGridView1.AddLookUpEdit("MAT_UNIT", "단위", "40123", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M003");

            acGridView1.AddLookUpEdit("SPEC_TYPE", "규격입력형태", "42540", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S062");

            acGridView1.AddTextEdit("MAT_SPEC", "사양", "42544", false, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_SPEC1", "완성사양", "42545", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddCheckEdit("AUTO_CREATE", "자동생성", "9ICKPDNH", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("AUTO_MARGIN", "자동여유사양", "0DRK00FJ", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddCheckEdit("STK_MNG", "재고관리", "F0A4HGPZ", true, false, false, acGridView.emCheckEditDataType._BYTE);

            acGridView1.AddLookUpEdit("STK_LOCATION", "창고", "NO1T1YEG", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "M005");

            acGridView1.AddTextEdit("SAFE_STK_QTY", "안전재고수량", "SJVKEWA8", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.QTY);

            acGridView1.AddTextEdit("AUTO_MARGIN_SPEC", "여유사양", "1AW7AFGL", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("LOAD_FLAG", "BOP 부품", "M920A2XO", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S024");

            acGridView1.AddLookUpEdit("SCH_METHOD", "스케줄 방법", "42462", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S060");

            acGridView1.AddLookUpEdit("MAT_TYPE", "자재형태", "N05MMEKM", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S016");

            acGridView1.AddTextEdit("MAIN_VND", "기본 거래처코드", "Z8OA566Z", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAIN_VND_NAME", "기본 거래처명", "1NSUG8A3", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_QLTY", "재질코드", "QGD6SY0U", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("MAT_QLTY_NAME", "재질명", "40572", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddLookUpEdit("INS_FLAG", "입고검사여부", "42560", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "S063");


            acGridView1.AddTextEdit("MAT_COST", "단가", "40121", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.MONEY);

            acGridView1.AddLookUpEdit("ACT_CODE", "회계계정", "42569", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, "C600");


            acGridView1.AddTextEdit("PART_SEQ", "표시순서", "40723", true, DevExpress.Utils.HorzAlignment.Far, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.Columns["PART_PRODTYPE"].GroupIndex = 0;
            acGridView1.Columns["PART_PRODTYPE"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

            POP20A_M0A.SetPopGridFont(acGridView1, null);

            #region 이벤트 설정

            acTextEdit1.KeyDown += acTextEdit1_KeyDown;

            #endregion


        }

        void acTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Search();
            }
            
        }
        public override void DialogInit()
        {
            this.Search();
        }


        private void OK()
        {
            DataRow focus = acGridView1.GetFocusedDataRow();

            this.OutputData = focus;

            this.DialogResult = DialogResult.OK;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            this.acGridView1.FocusedRowHandle = this.acGridView1.FocusedRowHandle - 1;
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            this.acGridView1.FocusedRowHandle = this.acGridView1.FocusedRowHandle + 1;
        }

        void Search()
        {
            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PART_LIKE", typeof(String)); //PART_CODE,NAME LIKE 검색
            paramTable.Columns.Add("MAT_LTYPE_IN", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PART_LIKE"] = layoutRow["PART_LIKE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "POP20A_SER", paramSet, "RQSTDT", "RSLTDT");

            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            acGridView1.ExpandAllGroups();

            //acGridView1.BestFitColumnsThread();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        
        


    }
}

