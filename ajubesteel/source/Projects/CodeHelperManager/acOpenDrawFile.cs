using BizManager;
using ControlManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeHelperManager
{
    public class acOpenDrawFile
    {
        public static void GetFile(Control parentControl, DataRow focusRow, string Type)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_TYPE", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["PART_CODE"] = focusRow["PART_CODE"];
                paramRow["FILE_TYPE"] = Type;

                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //도면 조회
                DataSet dsRslt = BizRun.QBizRun.ExecuteService("acOpenDrawFile", "POP02A_SER2", paramSet, "RQSTDT", "RSLTDT");

                if (dsRslt.Tables["RSLTDT"].Rows.Count == 0)
                {
                    DataTable paramTable2 = new DataTable("RQSTDT");
                    paramTable2.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable2.Columns.Add("PART_CODE", typeof(String)); //

                    DataRow paramRow2 = paramTable2.NewRow();
                    paramRow2["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow2["PART_CODE"] = focusRow["PART_CODE"];

                    paramTable2.Rows.Add(paramRow2);
                    DataSet paramSet2 = new DataSet();
                    paramSet2.Tables.Add(paramTable2);

                    if (focusRow["PART_CODE"].ToString().Substring(0, 1) == "A")
                    {
                        dsRslt = BizRun.QBizRun.ExecuteService("acOpenDrawFile", "POP02A_SER3", paramSet2, "RQSTDT", "RSLTDT");

                        if (dsRslt.Tables["RSLTDT"].Rows.Count > 0)
                        {
                            string p = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");
                            string i = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_ID");
                            string pas = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_PW");

                            IFModule iFModule = new IFModule(p, i, pas);

                            int ret = iFModule.NetWorkAccess();

                            string filePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_PATH"].ToString();

                            if (System.IO.Directory.Exists(filePath))
                            {
                                FileInfo fileInfo = new FileInfo(filePath + @"\" + focusRow["PART_CODE"].ToString() + "." + Type);

                                if (fileInfo.Exists)
                                {
                                    System.Diagnostics.Process.Start(filePath + @"\" + focusRow["PART_CODE"].ToString() + "." + Type);
                                }
                            }
                        }
                    }
                    else
                    {
                        acAlert.Show(parentControl, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
                        return;
                    }
                }
                else
                {
                    string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
                    string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
                    string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
                    string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");
                    string strFileFullPath = "";
                    string strFileFullName = "";

                    if (dsRslt.Tables["RSLTDT"].Columns.Contains("FILE_ID"))
                    {
                        string fileDir = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), dsRslt.Tables["RSLTDT"].Rows[0]["FILE_ID"]);

                        if (!Directory.Exists(fileDir))
                        {
                            Directory.CreateDirectory(fileDir);
                        }


                        acFTP acFtp1 = new acFTP();
                        acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                        acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                        acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                        acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                        acFtp1.FileType = FileType.Image;
                        acFtp1.DoEvents = true;
                        acFtp1.Passive = true;
                        acFtp1.Restart = false;

                        string dir = "";

                        string orginfilename = "";
                        string filename = "";
                        string fileID = "";
                        foreach (DataRow row in dsRslt.Tables["RSLTDT"].Rows)
                        {

                            string fileName = string.Format(@"{0}\{1}", fileDir, row["FILE_NAME"]);

                            dir = row["REG_DATE"].ToString().Substring(0, 10);

                            orginfilename = row["FILE_NAME"].ToString();
                            filename = row["FILE_ID"].ToString() + getExtName(dsRslt.Tables["RSLTDT"].Rows[0]["FILE_NAME"].ToString());
                            fileID = row["FILE_ID"].ToString();

                            FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileName);


                            System.Diagnostics.Process.Start(ftpResult.LocalFileName);
                        }

                        acFtp1.Close();
                        acFtp1 = null;
                    }
                    else
                    {
                        string containPath = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");

                        if (dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Contains(containPath))
                        {
                            strFileFullPath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_PATH"].ToString();
                            strFileFullName = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString();

                            path = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");
                            id = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_ID");
                            pass = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_PW");
                        }
                        else
                        {
                            int iSeq = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

                            string replacePath = dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Substring(iSeq, dsRslt.Tables["RSLTDT"].Rows[0]["PART_FILE_PATH"].ToString().Length - iSeq);

                            string fullPath = path + replacePath;


                            strFileFullPath = path;
                            strFileFullName = fullPath;
                        }


                        IFModule iFModule = new IFModule(path, id, pass);

                        int ret = iFModule.NetWorkAccess();

                        bool isExists = true;

                        if (System.IO.Directory.Exists(strFileFullPath))
                        {
                            FileInfo fileInfo = new FileInfo(strFileFullName);

                            if (fileInfo.Exists)
                            {
                                System.Diagnostics.Process.Start(strFileFullName);
                            }
                            else
                            {
                                isExists = false;
                            }
                        }
                        else
                        {
                            isExists = false;
                        }

                        if (!isExists)
                        {
                            acAlert.Show(parentControl, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(parentControl, ex);
            }
        }

        public static void GetDownLoadFile(Control parentControl, DataTable dt, string downDir)
        {
            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("PART_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_TYPE", typeof(String)); //

                foreach (DataRow row in dt.Rows)
                {
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["PART_CODE"] = row["PART_CODE"];
                    paramRow["FILE_TYPE"] = row["FILE_TYPE"];

                    paramTable.Rows.Add(paramRow);
                }


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //도면 조회
                DataSet dsRslt = BizRun.QBizRun.ExecuteService("acOpenDrawFile", "POP02A_SER2_2", paramSet, "RQSTDT", "RSLTDT");


                string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
                string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
                string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
                string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");
                string strFileFullPath = "";
                string strFileFullName = "";



                string fileDir = downDir;

                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }


                acFTP acFtp1 = new acFTP();
                acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                acFtp1.FileType = FileType.Image;
                acFtp1.DoEvents = true;
                acFtp1.Passive = true;
                acFtp1.Restart = false;

                string dir = "";

                string orginfilename = "";
                string filename = "";
                string fileID = "";
                foreach (DataRow row in dsRslt.Tables["RSLTDT2"].Rows)
                {

                    string fileName = string.Format(@"{0}\{1}", fileDir, row["FILE_NAME"]);

                    dir = row["REG_DATE"].ToString().Substring(0, 10);

                    orginfilename = row["FILE_NAME"].ToString();
                    filename = row["FILE_ID"].ToString() + getExtName(row["FILE_NAME"].ToString());
                    fileID = row["FILE_ID"].ToString();

                    FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileName);


                    //System.Diagnostics.Process.Start(ftpResult.LocalFileName);
                }

                acFtp1.Close();
                acFtp1 = null;

                string containPath = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");

                foreach (DataRow row in dsRslt.Tables["RSLTDT"].Rows)
                {
                    if (row["PART_FILE_PATH"].ToString().Contains(containPath))
                    {
                        strFileFullPath = row["PART_PATH"].ToString();
                        strFileFullName = row["PART_FILE_PATH"].ToString();

                        path = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR");
                        id = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_ID");
                        pass = acInfo.SysConfig.GetSysConfigByMemory("NEW_DRAW_FILE_DIR_PW");
                    }
                    else
                    {
                        int iSeq = row["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

                        string replacePath = row["PART_FILE_PATH"].ToString().Substring(iSeq, row["PART_FILE_PATH"].ToString().Length - iSeq);

                        string fullPath = path + replacePath;


                        strFileFullPath = path;
                        strFileFullName = fullPath;
                    }


                    IFModule iFModule = new IFModule(path, id, pass);

                    int ret = iFModule.NetWorkAccess();

                    bool isExists = true;

                    if (System.IO.Directory.Exists(strFileFullPath))
                    {
                        FileInfo fileInfo = new FileInfo(strFileFullName);

                        if (fileInfo.Exists)
                        {
                            //System.Diagnostics.Process.Start(strFileFullName);
                            //파일 생성

                            File.Copy(strFileFullName, downDir + @"\" + fileInfo.Name, true);

                        }
                        else
                        {
                            isExists = false;
                        }
                    }
                    else
                    {
                        isExists = false;
                    }

                    //if (!isExists)
                    //{
                    //    acAlert.Show(parentControl, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
                    //}
                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(parentControl, ex);
            }
        }

        static string getExtName(string filename)
        {

            string[] str = filename.Split('.');

            if (str.Length > 1)
            {
                string extname = str[str.Length - 1];
                return "." + extname;
            }
            else
            {
                return "";
            }
        }

        public static DataTable GetFileExists()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;

            paramTable.Rows.Add(paramRow);


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //도면 조회
            DataSet dsRslt = BizRun.QBizRun.ExecuteService("acOpenDrawFile", "POP02A_SER5", paramSet, "RQSTDT", "RSLTDT");

            return dsRslt.Tables["RSLTDT"];
        }

        public static DataTable GetFileExists(string assy_code)
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("ASSY_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["ASSY_CODE"] = assy_code;

            paramTable.Rows.Add(paramRow);


            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            //도면 조회
            DataSet dsRslt = BizRun.QBizRun.ExecuteService("acOpenDrawFile", "POP02A_SER6", paramSet, "RQSTDT", "RSLTDT");

            return dsRslt.Tables["RSLTDT"];
        }
    }
}
