using System.Net;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ControlManager
{

    //public delegate void FTPDownloadTotalSizeHandle(acFTP ftp);
    public delegate void FtpProgressEventHandler(object ftp, FtpProgressEventArgs e);

    public class acFTP
    {

        public event FtpProgressEventHandler Progress;

        public object LinkData = null;

        public string TransferKey = null;

        public string FileID = null;

        public string Server = null;
        public int ServerPort = 0;
        public string Username = null;
        public string Password = null;

        public FileType FileType = FileType.Ascii;
        public bool DoEvents = true;
        public bool Passive = true;
        public bool Restart = false;

        FtpFile ftpFile = new FtpFile();

        FtpProgressEventArgs e = new FtpProgressEventArgs();

        private bool bTransAbort = false;


        FtpWebRequest reqFTP = null;
        FileStream fs = null;
        Stream strm = null;
        StreamReader sr = null;
        public FtpWebResponse ftpResponse = null;
        WebResponse webResponse = null;

        public bool IsFileName(string fileName)
        {

            try
            {
                //this. ik = this.Invoke(16, fileName);

                return true;
            }
            catch
            {
                return false;
            }



        }

        public void Close()
        {
            if (reqFTP != null) reqFTP = null;
            if (fs != null) fs.Close();
            if (strm != null) strm.Close();
            if (sr != null) sr.Close();
            if (ftpResponse != null) ftpResponse.Close();
            if (webResponse != null) webResponse.Close();

        }

        public void AbortTransfer()
        {
            bTransAbort = true;
            //if (reqFTP != null) reqFTP = null;
            //if (fs != null) fs.Close();
            //if (strm != null) strm.Close();
            //if (sr != null) sr.Close();
            //if (ftpResponse != null) ftpResponse.Close();
            //if (webResponse != null) webResponse.Close();            
        }

        /// <summary>
        /// Method to upload the specified file to the specified FTP Server
        /// </summary>
        /// <param name="filename">file full name to be uploaded</param>
        //파일 업로드
        public FtpFile Put(string localFile, string remoteFile)
        {

            this.bTransAbort = false;

            this.ftpFile.LocalFileName = localFile;

            this.ftpFile.RemoteFileName = remoteFile;

            FileInfo fileInf = new FileInfo(localFile);

            string uri = string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, remoteFile);

            FTPDirectioryCheck(Path.GetDirectoryName(remoteFile));

            // Create FtpWebRequest object from the Uri provided
            reqFTP = GetRequest(uri);
            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;
            //return info
            this.ftpFile.Length = fileInf.Length;
            //event info
            this.e.Length = fileInf.Length;
            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            fs = fileInf.OpenRead();
            //Stream strm = null;
            try
            {
                this.ftpFile.Status = FtpFileStatus.TransferInProgress;

                // Stream to which the file to be upload is written
                strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                this.ftpFile.Position += contentLen;

                this.e.Position = this.ftpFile.Position;
                if (Progress != null) Progress(this, e);
                // Till Stream content ends
                while (contentLen != 0)
                {
                    if (bTransAbort)
                    {
                        this.Close();
                        this.ftpFile.Count = -1;
                        this.ftpFile.Status = FtpFileStatus.TransferAborted;
                        return this.ftpFile;
                    }

                    // Write Content from the file stream to the FTP Upload Stream                    
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                    this.ftpFile.Position += contentLen;
                    this.e.Position = this.ftpFile.Position;
                    if (Progress != null) Progress(this, e);
                }

                // Close the file stream and the Request Stream
                this.Close();

                this.ftpFile.Status = FtpFileStatus.TransferCompleted;

                return this.ftpFile;
            }

            catch (Exception ex)
            {
                //acMessageBox.Show("FTP 전송중 문제가 발생하였습니다.네트워크 상황 또는 접속정보를 살펴 보시기 바랍니다.","오류",acMessageBox.emMessageBoxType.CONFIRM);
                this.Close();

                this.ftpFile.Exception = ex;

                this.ftpFile.Status = FtpFileStatus.TransferFailed;

                return this.ftpFile;
            }
            //catch (Exception ex){MessageBox.Show(ex.Message, "Upload Error");}

        }

        //파일 삭제         
        public FtpFile Delete(string fileName)
        {
            try
            {
                this.ftpFile.Exception = null;
                string uri = string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, fileName);
                reqFTP = GetRequest(uri);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                string result = String.Empty;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                long size = ftpResponse.ContentLength;
                strm = ftpResponse.GetResponseStream();
                sr = new StreamReader(strm);
                result = sr.ReadToEnd();

                //this.Close();
                return this.ftpFile;
            }
            catch (Exception ex)
            {
                this.ftpFile.Exception = ex;
                //this.Close();
                return this.ftpFile;
            }
            //catch (Exception ex){MessageBox.Show(ex.Message, "FTP 2.0 Delete");}
        }


        public bool GetFilesInfo(string filename, ref DateTime dt)
        {
            try
            {
                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                dt = ftpResponse.LastModified;

                ftpResponse.Close();
                return true;

            }
            catch { ftpResponse.Close(); return false; }
            //catch (Exception ex){System.Windows.Forms.MessageBox.Show(ex.Message);return false;}
        }

        public List<string> GetFilesDetailList(string subFolder)
        {
            List<string> files = new List<string>();
            string line = null;


            try
            {
                //StringBuilder result = new StringBuilder();

                //FtpWebRequest ftp;
                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, subFolder));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                webResponse = reqFTP.GetResponse();
                sr = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.Default);

                while ((line = sr.ReadLine()) != null)
                {
                    files.Add(line);
                }

                sr.Close();
                webResponse.Close();
                return files;
                //MessageBox.Show(result.ToString().Split('\n'));
            }
            catch { return files; }
            //catch (Exception ex){System.Windows.Forms.MessageBox.Show(ex.Message);return files;}
        }

        public string[] GetFileList(string subFolder)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            //FtpWebRequest reqFTP;
            try
            {
                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, subFolder));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                webResponse = reqFTP.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = sr.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = sr.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                sr.Close();
                webResponse.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
            /*
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
            */
        }

        public FtpFile Get(string serverFullPathFile, string localFullPathFile)
        {

            try
            {
                this.bTransAbort = false;

                this.ftpFile.LocalFileName = localFullPathFile;

                this.ftpFile.RemoteFileName = serverFullPathFile;

                this.ftpFile.Length = GetFileSize(serverFullPathFile);

                this.e.Length = this.ftpFile.Length;

                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                checkDir(localFullPathFile);
                fs = new FileStream(localFullPathFile, FileMode.Create);

                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, serverFullPathFile));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                strm = ftpResponse.GetResponseStream();

                this.ftpFile.Status = FtpFileStatus.TransferInProgress;

                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = strm.Read(buffer, 0, bufferSize);

                this.ftpFile.Position += readCount;
                this.e.Position = this.ftpFile.Position;

                if (Progress != null) Progress(this, e);

                while (readCount > 0)
                {
                    if (bTransAbort)
                    {
                        this.ftpFile.Count = -1;
                        this.ftpFile.Status = FtpFileStatus.TransferAborted;
                        return this.ftpFile;
                    }

                    fs.Write(buffer, 0, readCount);
                    readCount = strm.Read(buffer, 0, bufferSize);
                    this.ftpFile.Position += readCount;
                    this.e.Position = this.ftpFile.Position;
                    if (Progress != null) Progress(this, e);

                }

                strm.Close();
                fs.Close();
                ftpResponse.Close();

                this.ftpFile.Status = FtpFileStatus.TransferCompleted;

                return this.ftpFile;
            }
            catch (Exception ex)
            {
                this.Close();

                this.ftpFile.Exception = ex;


                this.ftpFile.Status = FtpFileStatus.TransferFailed;

                return this.ftpFile;
            }

        }

        public Stream Get(string serverFullPathFile, bool isResponseClose = true)
        {

            try
            {
                Stream stream = null;

                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, serverFullPathFile));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                stream = ftpResponse.GetResponseStream();

                if (isResponseClose)
                {
                    ftpResponse.Close();
                }

                return stream;
            }
            catch (Exception ex)
            {
                this.Close();
                return null;
            }
        }

        public MemoryStream GetMemoryStream(string serverFullPathFile)
        {

            try
            {
                Stream stream = null;

                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, serverFullPathFile));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                stream = ftpResponse.GetResponseStream();

                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);

                ftpResponse.Close();

                return ms;
            }
            catch (Exception ex)
            {
                this.Close();
                return null;
            }

        }

        public bool checkDir(string localFullPathFile)
        {
            FileInfo fInfo = new FileInfo(localFullPathFile);

            if (!fInfo.Exists)
            {
                DirectoryInfo dInfo = new DirectoryInfo(fInfo.DirectoryName);
                if (!dInfo.Exists)
                {
                    dInfo.Create();
                }
                //dInfo.Delete();
            }

            //fInfo.Delete();
            return true;

        }

        private long GetFileSize(string filename)
        {
            //FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                strm = ftpResponse.GetResponseStream();

                fileSize = ftpResponse.ContentLength;

                strm.Close();
                ftpResponse.Close();

                return fileSize;
            }

            catch { return fileSize; }
            /*
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fileSize;
            */
        }

        public void Rename(string currentFilename, string newFilename)
        {
            //FtpWebRequest reqFTP;
            try
            {
                reqFTP = GetRequest(string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                ftpResponse = (FtpWebResponse)reqFTP.GetResponse();
                strm = ftpResponse.GetResponseStream();

                strm.Close();
                ftpResponse.Close();
            }

            catch { }
            /*
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }


        /// <summary>
        /// FTP 경로의 디렉토리를 점검하고 없으면 생성
        /// </summary>
        /// <param name="directoryPath">디렉터리 경로 입니다.</param>
        public void FTPDirectioryCheck(string directoryPath)
        {
            directoryPath = directoryPath.Replace("\\", "/");

            string[] directoryPaths = directoryPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            string currentDirectory = string.Empty;
            foreach (string directory in directoryPaths)
            {
                currentDirectory += string.Format("/{0}", directory);
                if (!IsExtistDirectory(currentDirectory))
                {
                    MakeDirectory(currentDirectory);
                }
            }
        }

        /// <summary>
        /// FTP에 해당 디렉터리가 있는지 알아온다.
        /// </summary>
        /// <param name="currentDirectory">디렉터리 명</param>
        /// <returns>있으면 참</returns>
        private bool IsExtistDirectory(string currentDirectory)
        {
            string uri = string.Format("ftp://{0}:{1}{2}", this.Server, this.ServerPort, GetParentDirectory(currentDirectory));
            reqFTP = GetRequest(uri);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            string data = string.Empty;
            try
            {
                ftpResponse = reqFTP.GetResponse() as FtpWebResponse;
                if (ftpResponse != null)
                {
                    sr = new StreamReader(ftpResponse.GetResponseStream(), Encoding.Default);

                    data = sr.ReadToEnd();
                }
            }
            finally
            {
                this.Close();
            }

            string[] directorys = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return (from directory in directorys
                    select directory.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    into directoryInfos
                    where directoryInfos[0][0] == 'd'
                    select directoryInfos[8]).Any(
                        name => name == (currentDirectory.Split('/')[currentDirectory.Split('/').Length - 1]).ToString());
        }

        /// <summary>
        /// 상위 디렉터리를 알아옵니다.
        /// </summary>
        /// <param name="currentDirectory"></param>
        /// <returns></returns>
        private string GetParentDirectory(string currentDirectory)
        {
            string[] directorys = currentDirectory.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string parentDirectory = string.Empty;
            for (int i = 0; i < directorys.Length - 1; i++)
            {
                parentDirectory += "/" + directorys[i];
            }

            return parentDirectory;
        }

        /// <summary>
        /// 인증을 가져옵니다.
        /// </summary>
        /// <returns>인증</returns>
        private ICredentials GetCredentials()
        {
            return new NetworkCredential(this.Username, this.Password);
        }

        private string GetStringResponse(FtpWebRequest ftp)
        {
            string result = "";
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    if (datastream != null)
                    {
                        using (StreamReader sr = new StreamReader(datastream))
                        {
                            result = sr.ReadToEnd();
                            sr.Close();
                        }

                        datastream.Close();
                    }
                }

                response.Close();
            }

            return result;
        }

        private FtpWebRequest GetRequest(string uri)
        {
            //string uri = string.Format("ftp://{0}:{1}/{2}",this.Server,this.ServerPort,uri);
            uri = uri.Replace("\\", "/");
            FtpWebRequest result = (FtpWebRequest)WebRequest.Create(uri);
            result.Credentials = GetCredentials();
            result.KeepAlive = false;
            result.UseBinary = true;
            result.UsePassive = Passive;
            result.Timeout = 10000;
            return result;
        }

        /// <summary>
        /// FTP에 해당 디렉터리를 만든다.
        /// </summary>
        /// <param name="dirpath"></param>
        public bool MakeDirectory(string dirpath)
        {
            string URI = string.Format("ftp://{0}:{1}/{2}", this.Server, this.ServerPort, dirpath);
            reqFTP = GetRequest(URI);
            reqFTP.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;

            try
            {
                string str = GetStringResponse(reqFTP);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 지정한 로컬 파일이 실제 존재하는지 확인합니다.
        /// </summary>
        /// <param name="localFileFullPath">로컬 파일의 전체 경로입니다.</param>
        private void LocalFileValidationCheck(string localFileFullPath)
        {
            if (!File.Exists(localFileFullPath))
            {
                throw new FileNotFoundException(string.Format("지정한 로컬 파일이 없습니다.\n경로 : {0}", localFileFullPath));
            }
        }


    }

    public enum FileType
    {
        Image = 0,
        Ascii = 1,
        Ebcdic = 2
    }

    public class FtpFile
    {
        public long Position { get; set; }
        public Exception Exception { get; set; }
        public string LocalFileName { get; set; }
        public string RemoteFileName { get; set; }
        public long Length { get; set; }
        public long Count { get; set; }
        public FtpFileStatus Status { get; set; }
    }

    public enum FtpFileStatus
    {
        TransferInProgress = 0,
        TransferCompleted = 1,
        TransferFailed = 2,
        TransferAborted = 3,
        DeleteCompleted = 4,
        DeleteFailed = 5,
        DeleteAborted = 6
    }

    public class FtpProgressEventArgs : EventArgs
    {
        public long CurrentFile { get; set; }
        public long TransferRate { get; set; }
        public long TotalFiles { get; set; }
        public string FileName { get; set; }
        public long Position { get; set; }
        public long Length { get; set; }
        public long Count { get; set; }
        public FtpFileStatus Status { get; set; }
    }
}
