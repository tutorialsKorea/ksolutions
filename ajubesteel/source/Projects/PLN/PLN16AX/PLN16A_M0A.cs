using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
    public sealed partial class PLN16A_M0A : BaseMenu
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

        public PLN16A_M0A()
        {
            InitializeComponent();
                        
            acLayoutControl1.OnValueKeyDown += new acLayoutControl.ValueKeyDownEventHandler(acLayoutControl1_OnValueKeyDown);
            acLayoutControl1.OnValueChanged += new acLayoutControl.ValueChangedEventHandler(acLayoutControl1_OnValueChanged);
            
        }

        public override void MenuInit()
        {
            try
            {
                //부서별
                acGridView1.OptionsView.ShowIndicator = true;

                acGridView1.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("CVND_NAME", "수주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");

                acGridView1.AddLookUpEdit("MAT_TYPE", "구분", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

                acGridView1.AddTextEdit("PART_NAME", "품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PART_CODE", "품번", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PLN_QTY", "지시수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("DUMMY_PLN_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("TOTAL_OK_QTY", "누적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView1.AddTextEdit("MAT_WEIGHT1", "제품중량", "EEDBYY6C", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.WEIGHT);

                acGridView1.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                
                acGridView1.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("EMP_CODE", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ORG_NAME", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("G_ORG_NAME", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddTextEdit("ORG_SEQ", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("PRE_START_TIME", "준비시작시간", "RTWG2G0Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddDateEdit("PRE_END_TIME", "준비완료시간", "27CR70AY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView1.AddTextEdit("PROC_TIME", "사전공수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);
                acGridView1.AddTextEdit("ACT_TIME", "실공수", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("MAN_TIME", "가공시간", "6S5HF69R", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("PRE_TIME", "준비시간", "IVNZDKSG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("IDLE_TIME", "중단시간", "2TH2FBC0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("TOTAL_TIME", "총 시간", "PBAO1ZN0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView1.AddTextEdit("IDLE_CAUSE", "중단사유", "4V39O5RM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView1.Columns["ORG_NAME"].GroupIndex = 0;

                //설비별
                acGridView2.OptionsView.ShowIndicator = true;

                acGridView2.AddTextEdit("CVND_CODE", "수주처코드", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("CVND_NAME", "수주처명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("ITEM_CODE", "수주코드", "40377", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddLookUpEdit("PART_PRODTYPE", "형식", "40238", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "M007");

                acGridView2.AddLookUpEdit("MAT_TYPE", "구분", "41587", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S016");

                acGridView2.AddTextEdit("PART_NAME", "품명", "40234", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PART_CODE", "품번", "40239", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("DRAW_NO", "도면번호", "40145", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PLN_QTY", "계획수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("OK_QTY", "실적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("TOTAL_OK_QTY", "누적수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

                acGridView2.AddTextEdit("MAT_WEIGHT1", "제품중량", "EEDBYY6C", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.WEIGHT);

                acGridView2.AddTextEdit("PROC_CODE", "공정코드", "40920", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("PROC_NAME", "공정명", "40921", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("MC_CODE", "설비코드", "41162", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("G_MC_NAME", "설비명", "41202", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("EMP_CODE", "담당자코드", "42388", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("EMP_NAME", "담당자", "40127", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("ORG_CODE", "부서코드", "40225", true, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddTextEdit("ORG_NAME", "부서", "40221", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.AddDateEdit("ACT_START_TIME", "실적시작시간", "50319", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("ACT_END_TIME", "실적완료시간", "50320", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("PRE_START_TIME", "준비시작시간", "RTWG2G0Q", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddDateEdit("PRE_END_TIME", "준비완료시간", "27CR70AY", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.MEDIUM_DATE);

                acGridView2.AddTextEdit("MAN_TIME", "가공시간", "6S5HF69R", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("PRE_TIME", "준비시간", "IVNZDKSG", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("IDLE_TIME", "중단시간", "2TH2FBC0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("TOTAL_TIME", "총 시간", "PBAO1ZN0", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.TIME);

                acGridView2.AddTextEdit("IDLE_CAUSE", "중단사유", "4V39O5RM", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                acGridView2.Columns["G_MC_NAME"].GroupIndex = 0;

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

                layout.GetEditor("WORK_DATE").Value = DateTime.Now;
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
            paramTable.Columns.Add("WORK_DATE", typeof(String)); //
            paramTable.Columns.Add("MC_LIKE", typeof(String)); //
            paramTable.Columns.Add("ORG_LIKE", typeof(String)); //
            

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["WORK_DATE"] = layoutRow["WORK_DATE"];
            paramRow["MC_LIKE"] = layoutRow["MC_LIKE"];
            paramRow["ORG_LIKE"] = layoutRow["ORG_LIKE"];
            _dtNow = layoutRow["WORK_DATE"].toDateTime();

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.LOAD, "PLN16A_SER", paramSet, "RQSTDT", "RSLTDT",
              QuickSearch,
              QuickException);
        }

        void QuickSearch(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
             

                DataRow[] emp = e.result.Tables["RSLTDT"].Select("", "ORG_SEQ");
                if (emp.Length > 0)
                {
                    acGridView1.GridControl.DataSource = emp.CopyToDataTable();

                    acGridView1.ExpandAllGroups();

                }

                DataRow[] org = e.result.Tables["RSLTDT"].Select("", "ORG_SEQ, EMP_SEQ");
                if (org.Length > 0)
                {
                    acGridView2.GridControl.DataSource = org.CopyToDataTable();

                    acGridView2.ExpandAllGroups();
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

        private const string exeXls = ".xls";
        private const string exeXlsx = ".xlsx";

        private void ExportXls()
        {

            string strFullPathFile = acInfo.SysConfig.GetSysConfigByServer("XLS_PATH:" + this.Name).toStringNull();

            if (strFullPathFile == null) strFullPathFile = "";

            if (strFullPathFile == "")
            {
                OpenFileDialog fileDlg = new OpenFileDialog();

                fileDlg.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합 문서 (*.xls)|*.xls";
                fileDlg.Title = "저장할 위치를 선택하여 주십시오.";

                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    //1.지정된 경로에 있는 파일을 로컬로 copy, 
                    //2.grid data를 엑셀로 export.
                    //3. 2번의 sheet를 1번 workbook에 copy.
                    acInfo.SysConfig.SetSysConfigByServer("XLS_PATH:" + this.Name, fileDlg.FileName, "SYS");

                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko-KR");

                    //선택된 파일
                    strFullPathFile = fileDlg.FileName;
                }
            }
            //OpenFileDialog fileDlg = new OpenFileDialog();
            
            //fileDlg.Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx|Excel 97 - 2003 통합 문서 (*.xls)|*.xls";
            //fileDlg.Title = "저장할 위치를 선택하여 주십시오.";
            
            //if (fileDlg.ShowDialog() == DialogResult.OK)
            //{
                //1.지정된 경로에 있는 파일을 로컬로 copy, 
                //2.grid data를 엑셀로 export.
                //3. 2번의 sheet를 1번 workbook에 copy.
                //acInfo.SysConfig.SetSysConfigByServer("XLS_PATH:" + this.Name, fileDlg.FileName, "SYS");

                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko-KR");

                ////선택된 파일
                //String strFullPathFile = fileDlg.FileName;
                
                string[] arrFile = strFullPathFile.Split('.');
                string selectedFileExe = arrFile[arrFile.Length-1];
                string fileExe = exeXls;


                if (selectedFileExe == "xlsx")
                {
                    fileExe = exeXlsx;
                }

                bool exists = System.IO.Directory.Exists(acInfo.DefaultDirectory);

                if (!exists)
                    System.IO.Directory.CreateDirectory(acInfo.DefaultDirectory);
                

                string destxlsPath = System.IO.Path.Combine(acInfo.DefaultDirectory, this.Name + fileExe);
                string xlsPath = System.IO.Path.Combine(acInfo.DefaultDirectory, acGridView1.Name + fileExe);

                File.Copy(strFullPathFile, destxlsPath, true);

                #region Export gridToXls
                acGridView1.OptionsPrint.PrintHeader = true;

                acGridView1.OptionsPrint.AutoWidth = false;

                acGridView1.OptionsPrint.UsePrintStyles = true;

                Form panel = new Form();

                acGridControl gc = new acGridControl();

                acGridView gv = new acGridView(gc);

                panel.Controls.Add(gc);

                gc.Name = "tempGridControl";

                gc.Parent = panel;
                gc.Location = new Point(0, 0);
                gc.Size = new Size(0, 0);
                gc.Visible = false;
                gv.ParentControl = panel;

                gc.MainView = gv;

                gc.ViewCollection.Add(gv);

                gc.DataSource = acGridView1.GridControl.DataSource;

                MemoryStream layoutSt = new MemoryStream();

                acGridView1.SaveLayoutToStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                layoutSt.Seek(0, SeekOrigin.Begin);

                gv.RestoreLayoutFromStream(layoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                layoutSt.Close();

                DevExpress.XtraPrinting.XlsxExportOptions xlsxOpt = new DevExpress.XtraPrinting.XlsxExportOptions();
                DevExpress.XtraPrinting.XlsExportOptions xlsOpt = new DevExpress.XtraPrinting.XlsExportOptions();

                if (fileExe == exeXls)
                {
                    gv.ExportToXls(xlsPath, xlsOpt);
                }
                else
                {
                    gv.ExportToXlsx(xlsPath, xlsxOpt);
                }
                
                #endregion

                //파일을 열어서 현재 데이터를 xlsPath(Cubictek\) sheet1에 쓴다.
            
                object defaultArg = Type.Missing;

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel._Workbook sourcewb = null;

                Microsoft.Office.Interop.Excel._Workbook destWB = null;

                Microsoft.Office.Interop.Excel._Worksheet sourceWS = null;

                Microsoft.Office.Interop.Excel._Worksheet destWS = null;

                try
                {
                    
                    sourcewb = excel.Workbooks.Open(xlsPath, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg);

                    destWB = excel.Workbooks.Open(destxlsPath, defaultArg, false,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg,
                        defaultArg, defaultArg, defaultArg);

                    sourceWS = (Microsoft.Office.Interop.Excel._Worksheet)sourcewb.Sheets[1];

                    destWS = (Microsoft.Office.Interop.Excel._Worksheet)destWB.Sheets.Add(defaultArg,
                                 defaultArg,
                                 defaultArg,
                                 defaultArg);


                    sourceWS.UsedRange.Copy(defaultArg);
                    destWS.Paste(defaultArg, defaultArg);

                    //destWB.Save();
                    sourcewb.Save();
                }
                finally
                {
                    destWB.Close(defaultArg, defaultArg, defaultArg);
                    sourcewb.Close(defaultArg, defaultArg, defaultArg);

                    excel.Quit();
                }


                releaseObject(sourceWS);
                releaseObject(sourcewb);
                releaseObject(destWS);
                releaseObject(sourcewb);
                releaseObject(excel);

                System.Threading.Thread.Sleep(100);

                File.Copy(destxlsPath, strFullPathFile, true);

                if (File.Exists(destxlsPath))
                    File.Delete(destxlsPath);

                System.Threading.Thread.Sleep(100);

                if (acMessageBox.Show(this, "파일을 여시겠습니까?", "C5FDPXF8", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strFullPathFile);
                }
            //}
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            acGridView1.EndEditor();

            switch (acTabControl1.GetSelectedContainerName())
            {
                case "ORG":

                    DataView view = acGridView1.GetDataSourceView("");

                    if (view.Count != 0)
                    {
                        DataRow focusRow = acGridView1.GetFocusedDataRow();

                        DataSet dataSource = new DataSet();

                        DataTable master = new DataTable();
                        master.TableName = "M";
                        master.Columns.Add("DAY", typeof(DateTime));

                        DataRow rw = master.NewRow();
                        rw["DAY"] = _dtNow;
                        master.Rows.Add(rw);

                        DataTable detail = view.ToTable();
                        detail.TableName = "D";

                        dataSource.Tables.AddRange(new DataTable[] { master, detail });

                        //일일보고서
                        ReportManager.acReportView.ShowReportCategoryPreview(this, "ORG", dataSource);
                    }

                    break;

                case "MC":

                    DataView view2 = acGridView2.GetDataSourceView("");

                    if (view2.Count != 0)
                    {
                        DataRow focusRow2 = acGridView2.GetFocusedDataRow();

                        DataSet dataSource2 = new DataSet();

                        DataTable master2 = new DataTable();
                        master2.TableName = "M";
                        master2.Columns.Add("DAY", typeof(DateTime));

                        DataRow rw2 = master2.NewRow();
                        rw2["DAY"] = _dtNow;
                        master2.Rows.Add(rw2);

                        DataTable detail2 = view2.ToTable();
                        detail2.TableName = "D";

                        dataSource2.Tables.AddRange(new DataTable[] { master2, detail2 });

                        //일일보고서
                        ReportManager.acReportView.ShowReportCategoryPreview(this, "MC", dataSource2);
                    }

                    break;
            }

        }

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportXls();
        }
        
    }
}
