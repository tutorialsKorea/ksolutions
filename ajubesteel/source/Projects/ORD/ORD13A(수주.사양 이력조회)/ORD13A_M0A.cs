using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using BizManager;
using DevExpress.XtraTreeList.Nodes;

namespace ORD
{
    public sealed partial class ORD13A_M0A : BaseMenu
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


        public ORD13A_M0A()
        {
            InitializeComponent();

            acGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView1_FocusedRowChanged);

            // acGridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(acGridView2_FocusedRowChanged);

            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);

            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);


           this.Load += ORD13A_M0A_Load;
        }



        void ORD13A_M0A_Load(object sender, EventArgs e)
        {
           // this.Search();
        }



    
        void acGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          this.GetDetail();
        }



        void GetDetail()
        {
            DataRow focusRow = acGridView1.GetFocusedDataRow();

            if (focusRow == null)
            {
                acTreeList1.ClearNodes();
                //acVerticalGrid1.ClearRows();
                return;
            }

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_CODE"] = focusRow["PROD_CODE"];

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(
            this, QBiz.emExecuteType.LOAD_DETAIL,
            "ORD13A_SER3", paramSet, "RQSTDT", "RSLTDT",
            QuickDetail,
            QuickException);

        }



        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            acLayoutControl layout = sender as acLayoutControl;

            switch (info.ColumnName)
            {
                case "DATE":

                    //날짜검색조건이 존재하면 날짜컨트롤을 필수로 바꾼다.

                    if (newValue.EqualsEx(string.Empty))
                    {

                        layout.GetEditor("S_DATE").isRequired = false;
                        layout.GetEditor("E_DATE").isRequired = false;

                    }
                    else
                    {
                        layout.GetEditor("S_DATE").isRequired = true;
                        layout.GetEditor("E_DATE").isRequired = true;
                    }

                    break;

            }

        }

        public override void ChildContainerInit(Control sender)
        {
            //기본값 설정

            if (sender == acLayoutControl1)
            {

                acLayoutControl layout = sender as acLayoutControl;

                layout.GetEditor("DATE").Value = "REG_DATE";
                layout.GetEditor("S_DATE").Value = acDateEdit.GetNowFirstDate();
                layout.GetEditor("E_DATE").Value = DateTime.Now;

            }

            base.ChildContainerInit(sender);
        }


        public override void MenuNotify(object data)
        {
            base.MenuNotify(data);
        }


        public override void MenuInit()
        {

            #region 수주
           
            acGridView1.GridType = acGridView.emGridType.AUTO_COL;

            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddTextEdit("PROD_NAME", "모델명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            
            acGridView1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, "P012");

            // acGridView1.Columns["PROD_CODE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            // acGridView1.OptionsCustomization.AllowSort = false;

            #endregion


            #region BOM

            acTreeList1.AddTextEdit("PART_CODE", "품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_NAME", "품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddLookUpEdit("MAT_LTYPE", "대분류", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, "M014", false);
            acTreeList1.AddTextEdit("MAT_SPEC", "사양", "", false, DevExpress.Utils.HorzAlignment.Near, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_CODE", "모품목코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("P_PART_NAME", "모품목명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, acTreeList.emTextEditMask.NONE);
            acTreeList1.AddTextEdit("PART_QTY", "수량", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, acTreeList.emTextEditMask.QTY);

            acTreeList1.AddTextEdit("DATA_FLAG", "삭제여부", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, acTreeList.emTextEditMask.NONE);

            acTreeList1.KeyFieldName = "PT_ID";
            acTreeList1.ParentFieldName = "O_PT_ID";
            acTreeList1.OptionsView.AutoWidth = false;

            acTreeList1.CustomDrawNodeCell += acTreeList1_CustomDrawNodeCell;

            #endregion


            DataSet dsRslt = BizRun.QBizRun.ExecuteService(this, "ORD02A_MODEL", "RQSTDT", "RSLTDT_T,RSLTDT_M");

            #region 수주/사양 정보

            acVerticalGrid1.AddTextEdit("REV_NO", "REV_NO", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NUMERIC);

            acVerticalGrid1.AddTextEdit("REV_ID", "리비전 ID", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, false, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("REV_NAME", "REV 생성자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("PROD_CODE", "수주번호", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddLookUpEdit("MODEL_TYPE", "대분류", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "MODEL_NAME","SCODE",dsRslt.Tables["RSLTDT_T"]);

            acVerticalGrid1.AddLookUpEdit("MODEL_CODE", "중분류", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "MODEL_NAME", "SCODE", dsRslt.Tables["RSLTDT_M"]);

            acVerticalGrid1.AddTextEdit("PROD_NAME", "모델명", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddLookUpEdit("PROC_TYPE", "공정구분", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P017");

            acVerticalGrid1.AddLookUpEdit("PROC_FLAG", "공정명", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P005");

            acVerticalGrid1.AddTextEdit("PROD_VERSION", "버전", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddLookUpEdit("PROD_KIND", "제품구분", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "C011");

            acVerticalGrid1.AddLookUpEdit("PROD_PRIORITY", "우선순위", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P028");

            // acVerticalGrid1.AddLookUpEdit("PROD_STATE", "수주상태", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P012");

            acVerticalGrid1.AddLookUpEdit("PROD_FLAG", "유형", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P006");

            acVerticalGrid1.AddLookUpEdit("ITEM_FLAG", "수주구분", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P027");

            acVerticalGrid1.AddLookUpEdit("PROD_CATEGORY", "제품유형", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P009");

            acVerticalGrid1.AddLookUpEdit("PROD_TYPE", "제품분류", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P010");

            acVerticalGrid1.AddLookUpEdit("MODULE_TYPE", "모듈타입", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P018");

            acVerticalGrid1.AddLookUpEdit("INS_YN", "성적서", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P007");

            acVerticalGrid1.AddTextEdit("CVND_NAME", "발주처", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("TVND_NAME", "계산서 발행처", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("CUSTOMER_EMP", "고객담당자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("CUSTDESIGN_EMP", "고객설계자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("BUSINESS_EMP_NAME", "영업담당자", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddTextEdit("PROD_QTY", "제작수량", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.QTY);

            acVerticalGrid1.AddTextEdit("PROD_COST", "공급단가", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.MONEY);

            acVerticalGrid1.AddTextEdit("PROD_AMT", "총금액", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.MONEY);

            acVerticalGrid1.AddCheckEdit("ORD_VAT", "VAT 별도", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emCheckEditDataType._STRING);

            acVerticalGrid1.AddLookUpEdit("CURR_UNIT", "화폐", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P008");

            acVerticalGrid1.AddDateEdit("ORD_DATE", "수주일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, true, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddDateEdit("DUE_DATE", "출하예정일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddDateEdit("CHG_DUE_DATE", "출하조정일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            //acVerticalGrid1.AddDateEdit("DELIVERY_DATE", "납품일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            //acVerticalGrid1.AddLookUpEdit("TRADE_YN", "거래명세표", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P007");

            //acVerticalGrid1.AddLookUpEdit("TAX_YN", "세금계산서", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P007");

            //acVerticalGrid1.AddLookUpEdit("BILL_YN", "수금등록", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P007");


            acVerticalGrid1.AddCategoryRow("수주 정보", "", false, new string[] {
                "REV_NO",
                "REV_ID",
                "REV_NAME",
                "PROD_CODE",
                "MODEL_TYPE",
                "MODEL_CODE",
                "PROD_NAME",
                "PROC_TYPE",
                "PROC_FLAG",
                "PROD_VERSION",
                "PROD_KIND",
                "PROD_PRIORITY",
                "PROD_FLAG",
                "ITEM_FLAG",
                "PROD_CATEGORY",
                "PROD_TYPE",
                "MODULE_TYPE",
                "INS_YN",
                "CVND_NAME",
                "TVND_NAME",
                "CUSTOMER_EMP",
                "CUSTDESIGN_EMP",
                "BUSINESS_EMP_NAME",
                "PROD_QTY",
                "PROD_COST",
                "PROD_AMT",
                "ORD_VAT",
                "CURR_UNIT",
                "ORD_DATE",
                "DUE_DATE",
                "CHG_DUE_DATE",
                //"DELIVERY_DATE",
                //"TRADE_YN",
                //"TAX_YN",
                //"BILL_YN"
             
            });


            acVerticalGrid1.AddLookUpEdit("PIN_TYPE", "Contact", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P011");

            acVerticalGrid1.AddLookUpEdit("VISION_TYPE", "안착기준", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P020");

            acVerticalGrid1.AddLookUpEdit("VISION_DIRECTION", "Connector 방향", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S102");

            acVerticalGrid1.AddLookUpEdit("DFM_YN", "DFM작성", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S105");

            acVerticalGrid1.AddDateEdit("DFM_DATE", "DFM 요청일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddLookUpEdit("MSOP_YN", "MSOP작성", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S105");

            acVerticalGrid1.AddDateEdit("MSOP_DATE", "MSOP 요청일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddLookUpEdit("IF_PIN_BLOCK", "Interface Pin Block", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S100");

            acVerticalGrid1.AddLookUpEdit("MODULE_IN_TYPE", "모듈 안착 타입", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P021");

            acVerticalGrid1.AddLookUpEdit("GND_PIN", "GND_PIN", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S100");

            acVerticalGrid1.AddLookUpEdit("FIDUCIAL_MARK", "FIDUCIAL_MARK", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S100");

            acVerticalGrid1.AddLookUpEdit("CROSS_MARKING", "십자마킹", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S100");

            acVerticalGrid1.AddLookUpEdit("VACUUM", "Vacuum", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S100");

            acVerticalGrid1.AddDateEdit("DRAW_DATE", "도면 요청일", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emDateMask.SHORT_DATE);

            acVerticalGrid1.AddLookUpEdit("DRAW_TYPE", "도면형식", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "P024");

            acVerticalGrid1.AddLookUpEdit("ACTUATOR_YN", "Actuator 제작 유무", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, "S101");

            acVerticalGrid1.AddTextEdit("PART_NAME", "품목", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, false, true, acVerticalGrid.emTextEditMask.NONE);

            acVerticalGrid1.AddMemoEdit("SOCKET_MARKING", "개발 전달사항", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true);

            acVerticalGrid1.AddMemoEdit("SCOMMENT", "전달사항", "", false, string.Empty, string.Empty, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, true);

            acVerticalGrid1.AddCategoryRow("사양 정보", "", false, new string[] {
                "PIN_TYPE",
                "VISION_TYPE",
                "VISION_DIRECTION",
                "DFM_YN",
                "DFM_DATE",
                "MSOP_YN",
                "MSOP_DATE",
                "IF_PIN_BLOCK",
                "MODULE_IN_TYPE",
                "GND_PIN",
                "FIDUCIAL_MARK",
                "CROSS_MARKING",
                "VACUUM",
                "DRAW_DATE",
                "DRAW_TYPE",
                "ACTUATOR_YN",
                "PART_NAME",
                "SOCKET_MARKING",
                "SCOMMENT"
            });


            acVerticalGrid1.CustomDrawRowValueCell += AcVerticalGrid1_CustomDrawRowValueCell;

            acVerticalGrid1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.MultiRecordView;

            acVerticalGrid1.Resize += AcVerticalGrid1_Resize;

            #endregion

            acCheckedComboBoxEdit1.AddItem("등록일", false, "", "REG_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("수주일", false, "", "ORD_DATE", true, false);
            acCheckedComboBoxEdit1.AddItem("출하예정일", false, "", "DUE_DATE", true, false);
            //acCheckedComboBoxEdit1.AddItem("납품일", false, "", "DELIVERY_DATE", true, false);

            base.MenuInit();

        }

        private void acTreeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {

            TreeListNode node = e.Node;

            if (node["DATA_FLAG"].ToString() == "2")
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }


        int _columnCnt = 0;
     
        private void AcVerticalGrid1_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {
            if (_columnCnt == 0 || _columnCnt == 1) { return; }

            acVerticalGrid vGrid = sender as acVerticalGrid;

            string[] arrStr = new string[_columnCnt];
            bool changed = false;
            int recordIndex = 0;

            if (e.Row.Name != "REV_NO")
            {
                for (int i = 0; i < _columnCnt; i++)
                {
                    if (vGrid.GetCellValue(e.Row.Name, (recordIndex + i)).isNullOrEmpty())
                    {
                        arrStr[i] = "";
                    }
                    else
                    {
                        arrStr[i] = vGrid.GetCellValue(e.Row.Name, (recordIndex + i)).ToString();
                    }
                }

                for (int idx = 1; idx < _columnCnt; idx++)
                {
                    if (arrStr[idx - 1] != arrStr[idx])
                    {
                        changed = true;
                        break;
                    }
                }

                if (changed)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                    changed = false;
                }
            }
        }

     

        private void AcVerticalGrid1_Resize(object sender, EventArgs e)
        {
            this.acVerticalGrid1.RecordWidth = 200;
        }

        public override void MenuInitComplete()
        {
            base.MenuInitComplete();

            //acVerticalGrid1.RecordWidth = 200;
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

        void Search()
        {
          
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); 
            paramTable.Columns.Add("PROD_LIKE", typeof(String));
            paramTable.Columns.Add("S_REG_DATE", typeof(String)); //등록 시작일
            paramTable.Columns.Add("E_REG_DATE", typeof(String)); //등록 종료일
            paramTable.Columns.Add("S_ORD_DATE", typeof(String)); //수주일 시작일
            paramTable.Columns.Add("E_ORD_DATE", typeof(String)); //수주일 종료일
            //paramTable.Columns.Add("S_DELIVERY_DATE", typeof(String)); //출하 시작일
            //paramTable.Columns.Add("E_DELIVERY_DATE", typeof(String)); //출하 종료일
            paramTable.Columns.Add("S_DUE_DATE", typeof(String)); //납기일 시작일
            paramTable.Columns.Add("E_DUE_DATE", typeof(String)); //납기일 종료일
           

            DataRow layoutRow = acLayoutControl1.CreateParameterRow();

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["PROD_LIKE"] = layoutRow["PROD_LIKE"];

            foreach (string key in acCheckedComboBoxEdit1.GetKeyChecked())
            {
                switch (key)
                {
                    case "REG_DATE":
                        //등록일
                        paramRow["S_REG_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_REG_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "ORD_DATE":
                        //수주일
                        paramRow["S_ORD_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_ORD_DATE"] = layoutRow["E_DATE"];

                        break;
                    case "DUE_DATE":
                        //납기일
                        paramRow["S_DUE_DATE"] = layoutRow["S_DATE"];
                        paramRow["E_DUE_DATE"] = layoutRow["E_DATE"];

                        break;
                    //case "DELIVERY_DATE":
                    //    //납품일
                    //    paramRow["S_DELIVERY_DATE"] = layoutRow["S_DATE"];
                    //    paramRow["E_DELIVERY_DATE"] = layoutRow["E_DATE"];

                    //    break;
                }
            }

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.NONE, "ORD13A_SER2", paramSet, "RQSTDT", "RSLTDT",
               QuickSearch,
               QuickException);

        }

        void QuickSearch(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
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


        void QuickDetail(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {


                acVerticalGrid1.DataSource = e.result.Tables["RSLTDT"];

                _columnCnt = acVerticalGrid1.RecordCount;

                // acVerticalGrid1.BestFit();

                acTreeList1.DataSource = e.result.Tables["RSLTDT_BOM"];

                acTreeList1.ExpandToLevel(0);
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

    }
}
