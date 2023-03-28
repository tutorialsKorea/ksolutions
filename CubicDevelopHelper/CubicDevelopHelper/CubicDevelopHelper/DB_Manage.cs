using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Cubic_Query_Builder
{
    static class Conn_Info
    {
        public static string DB_IP = "";
        public static string DB_NAME = "";
        public static string DB_ID = "";
        public static string DB_PW = "";

    }

    class DB_Manage
    {
        string strConn = string.Empty;
        public DB_Manage(string db_ip, string db_name, string db_id, string db_pw)
        {
            Conn_Info.DB_IP = db_ip;
            Conn_Info.DB_NAME = db_name;
            Conn_Info.DB_ID = db_id;
            Conn_Info.DB_PW = db_pw;

            if (strConn == "")
            {
                try
                {
                    //string DirInfoPath = Application.StartupPath;
                    //string xmlFile = DirInfoPath + "\\info.xml";
                    //gXmlParsing gXmlp = new gXmlParsing(xmlFile);
                    //List<gGetResult> lData = gXmlp.GetXmlDB();

                    strConn = "server=" + Conn_Info.DB_IP + ";database=" + Conn_Info.DB_NAME + ";user id=" + Conn_Info.DB_ID + ";password=" + Conn_Info.DB_PW +
                                    ";Max Pool Size=100; Min Pool Size=5";
                }
                catch (Exception ex)
                {
                    //gCommon.SetErrLog(ex.Message);
                }
            }
        }

        SqlConnection conn = new SqlConnection();
        SqlTransaction transaction;

        public SqlCommand BeginTranConn()
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.ConnectionString = strConn;

            conn.Open();

            SqlCommand command = conn.CreateCommand();

            // Start a local transaction.
            transaction = conn.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command.Connection = conn;
            command.Transaction = transaction;

            return command;
        }

        public void CommitTranDisConn()
        {
            try
            {
                transaction.Commit();
                conn.Close();
            }
            catch
            {

            }
        }

        public void SetQueryToExecute(string strQuery)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = ConnCmd();
                cmd.CommandText = strQuery;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("SetQueryToExecute:" + ex);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();

            }
        }


        public void SetQueryToExecute(string strQuery, string Contents)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = ConnCmd();
                cmd.CommandText = strQuery;
                if (Contents != null)
                {
                    cmd.Parameters.AddWithValue("@Contents", Contents);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("SetQueryToExecute:" + ex);
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();

            }
        }



        public DataTable GetQueryToDataTable(string strQuery)
        {

            SqlCommand cmd = null;
            SqlDataAdapter sda = null;

            try
            {
                cmd = ConnCmd();
                cmd.CommandText = strQuery;
                sda = new SqlDataAdapter(cmd);
                DataTable dtTemp = new DataTable();
                sda.Fill(dtTemp);
                return dtTemp;

            }
            catch (Exception ex)
            {
                throw new Exception("GetQueryToDataTable:" + ex);
            }
            finally
            {
                if (sda != null)
                    sda.Dispose();
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public SqlCommand ConnCmd()
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.ConnectionString = strConn;

            conn.Open();

            SqlCommand command = conn.CreateCommand();

            command.Connection = conn;

            return command;
        }

        public void DisConn()
        {
            try
            {
                conn.Close();
            }
            catch
            {

            }
        }


        public void RollBackTranDisConn()
        {
            try
            {
                transaction.Rollback();
                conn.Close();
            }
            catch
            {

            }
        }
    }
}
