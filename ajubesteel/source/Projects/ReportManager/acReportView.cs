using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ControlManager;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using BizManager;

namespace ReportManager
{
    public class acReportView
    {
        public static string GetClassName()
        {
            return "acReportView";
        }

        public static string ExportToHtml(string className, object dataSource)
        {
            

                Assembly assemDLL = Assembly.Load(className);


                Type reportClassType = assemDLL.GetType("REPORT" + "." + className, true, true);


                if (reportClassType != null)
                {

                    Object[] objPrameters = new Object[1];

                    object rptObject = System.Activator.CreateInstance(reportClassType);


                    if (dataSource != null)
                    {

                        object dataProcessed = reportClassType.InvokeMember("DataSourceProcess", BindingFlags.InvokeMethod, null, rptObject, new object[] { dataSource });

                        reportClassType.InvokeMember("DataSource", BindingFlags.SetProperty, null, rptObject, new object[] { dataProcessed });
                    }


                    acReport rpt = (acReport)rptObject;

                    DevExpress.XtraPrinting.HtmlExportOptions opt = new DevExpress.XtraPrinting.HtmlExportOptions();

                    opt.ExportMode = DevExpress.XtraPrinting.HtmlExportMode.SingleFile;

                    MemoryStream st = new MemoryStream();

                    rpt.ExportToHtml(st, opt);

                    st.Position = 0;
                    
                    StreamReader sr = new StreamReader(st);
                    
                    string str = sr.ReadToEnd();

                    st.Close();

                    return str;

                }
                else
                {
                    return null;
                }


        }

        /// <summary>
        /// 출력양식을 보여준다.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="dataSource"></param>
        private static void ShowPreview(string className, object dataSource)
        {
            try
            {

                Assembly assemDLL = Assembly.Load(className);


                Type reportClassType = assemDLL.GetType("REPORT" + "." + className, true, true);


                if (reportClassType != null)
                {

                    Object[] objPrameters = new Object[1];

                    object rptObject = System.Activator.CreateInstance(reportClassType);



                    if (dataSource != null)
                    {

                        object dataProcessed = reportClassType.InvokeMember("DataSourceProcess", BindingFlags.InvokeMethod, null, rptObject, new object[] { dataSource });

                        reportClassType.InvokeMember("DataSource", BindingFlags.SetProperty, null, rptObject, new object[] { dataProcessed });
                    }




                    ReportPreview preview = new ReportPreview((acReport)rptObject);

                    preview.ParentControl = new Control("REPORT_PREVIEW");

                    preview.Show();

       
                }
                else
                {
                    //지정된 양식 찾을수 없음

                    throw new BizManager.BizException(100005);

                }
            }
            catch (FileNotFoundException)
            {
                throw new BizManager.BizException(100005);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 출력양식을 보여준다.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="dataSource"></param>
        private static void ShowPreview(string className, object dataSource, string assembly)
        {
            try
            {

                Assembly assemDLL = Assembly.Load(assembly);


                Type reportClassType = assemDLL.GetType("REPORT" + "." + className, true, true);


                if (reportClassType != null)
                {

                    Object[] objPrameters = new Object[1];

                    object rptObject = System.Activator.CreateInstance(reportClassType);



                    if (dataSource != null)
                    {

                        object dataProcessed = reportClassType.InvokeMember("DataSourceProcess", BindingFlags.InvokeMethod, null, rptObject, new object[] { dataSource });

                        reportClassType.InvokeMember("DataSource", BindingFlags.SetProperty, null, rptObject, new object[] { dataProcessed });
                    }




                    ReportPreview preview = new ReportPreview((acReport)rptObject);

                    preview.ParentControl = new Control("REPORT_PREVIEW");

                    preview.Show();



                }
                else
                {
                    //지정된 양식 찾을수 없음

                    throw new BizManager.BizException(100005);

                }
            }
            catch (FileNotFoundException)
            {
                throw new BizManager.BizException(100005);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 해당된 클래스 출력양식을 보여준다.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="dataSource"></param>
        public static void ShowReportClassPreview(string className)
        {

            ShowPreview(className, null);

        }

        public static void ShowImagePreview(Control parent, byte[] img)
        {

            ImagePage page = new ImagePage();

            page.DataSource = page.DataSourceProcess(img);

            ReportPreview preview = new ReportPreview(page);

            preview.ParentControl = parent;

            preview.Show();

        }


        /// <summary>
        /// 해당된 카테고리의 출력양식을 보여준다.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="dataSource"></param>
        public static void ShowReportCategoryPreview(Control parent, string categoryID, object dataSource)
        {

            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("MENU_CODE", typeof(String)); //
                paramTable.Columns.Add("RPT_CATEGORY_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;

                if (parent is IBase)
                {
                    IBase b = parent as IBase;

                    paramRow["MENU_CODE"] = b.MenuCode;
                }

                paramRow["RPT_CATEGORY_ID"] = categoryID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);


                DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "GET_REPORTLIST", paramSet, "RQSTDT", "RSLTDT");


                if (resultSet.Tables["RSLTDT"].Rows.Count == 1)
                {
                    //사용가능한 출력양식이 1개이면 기본으로 바로보여준다.

                    DataRow reportRow = resultSet.Tables["RSLTDT"].Rows[0];

                    ShowPreview(reportRow["RPT_CLASS"].ToString(), dataSource);

                    //if (!reportRow["RPT_CLASS"].EqualsEx(reportRow["RPT_ASSEMBLY"]))
                    //{
                    //    ShowPreview(reportRow["RPT_CLASS"].ToString(), dataSource, reportRow["RPT_ASSEMBLY"].ToString());
                    //}
                    //else
                    //{
                    //    ShowPreview(reportRow["RPT_CLASS"].ToString(), dataSource);
                    //}


                }
                else
                {

                    ReportSelector frm = new ReportSelector(resultSet.Tables["RSLTDT"]);

                    frm.ParentControl = parent;

                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DataRow selectedRow = (DataRow)frm.OutputData;

                        //ShowPreview(selectedRow["RPT_CLASS"].ToString(), dataSource);
                        ShowPreview(selectedRow["RPT_CLASS"].ToString(), dataSource, selectedRow["RPT_ASSEMBLY"].ToString());
                    }
                }


            }
            catch (Exception ex)
            {

                acMessageBox.Show(parent, ex);

            }
        }

    }
}
