using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
//using System.Collections;

namespace BizExecute
{
    public sealed partial class BizExecute
    {
        private SqlDataAdapter myAdapter = null;
        private SqlConnection conn;
        //private SqlConnection conntran;
        private SqlTransaction transaction;

        private string connetionString = string.Empty;
        //private bool bConnOpen = false;

        public BizExecute(string serverip, string dbName)
        {
            try
            {
                

                //string connetionString = "Data Source=211.238.138.160,7860;Initial Catalog=active_haein;User ID=emes;Password=emes";
                connetionString = "Data Source=" + serverip + ";Initial Catalog=" + dbName + ";User ID=cubic;Password=Cubictek!18; Connection Timeout=5";    //192.168.10.200

                openConnection(connetionString);
                myAdapter = new SqlDataAdapter();

                

            }
            catch(SqlException ex)
            {
                throw UTIL.SetException(ex);
            }

        }

        ~BizExecute()
        {
            //if(frmProcess != null) frmProcess.ShowClose();
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        public SqlConnection openConnection(string connetionString)
        {
            try
            {
                int nSec = 0;
                //이전 연결이 남아 있으면 연결이 해제된후 진행

                //5초가 지나면 스킵
                while (nSec < 15)
                {
                    if (conn == null) break;
                    Thread.Sleep(200);
                    nSec++;
                }                
                if(conn == null) conn = new SqlConnection();
                //conn = new SqlConnection(connetionString);

                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.ConnectionString = connetionString;
                    conn.Open();
                }
                return conn;
            }
            catch(SqlException ex)
            {
                //throw new Exception("데이터베이스 연결에 실패 하였습니다.서버를 확인하여 주십시오.");
                throw UTIL.SetException("데이터베이스 연결에 실패 하였습니다.서버를 확인하여 주십시오.");
            }
        }

        private bool beginTransaction()
        {
            try
            {
                if(transaction == null) transaction = conn.BeginTransaction();
                return true;
            }
            catch(SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void commitClose()
        {
            try
            {
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        transaction.Commit();
                    }
                }
                closeConnection();
            }
            catch (SqlException ex)
            {
                throw UTIL.SetException(ex);
            }
        }


        public void rollbackClose()
        {
            try
            {
                if (transaction != null)
                {
                    //transaction.Connection.State == ConnectionState.
                    if (transaction.Connection != null)
                    {

                        if (transaction.Connection.State == ConnectionState.Open)
                            transaction.Rollback();
                    }
                }
                closeConnection();
            }
            catch (SqlException ex)
            {
                throw UTIL.SetException(ex);
            }
        }

        public bool IsConnected()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;   
            }
                
        }

        //public DataTable ThreadSelectQuery(string _query)
        //{            
        //    return null;
        //}
        

        /// <method>
        /// Select Query
        /// </method>        
        public DataTable executeSelectQuery(String _query)
        {

            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {

                //if (conn.State != ConnectionState.Open)
                //{
                //    openConnection(connetionString);
                //}                   
                          
                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                //myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();                
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                if(ds.Tables.Count > 0) dataTable = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }

            return dataTable;
        }

        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                //myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + ex.StackTrace.ToString());
                throw UTIL.SetException(ex,"",_query);
                //return false;
            }

            return true;
        }

        /// <summary>
        /// Bulk Insert
        /// 입력하는 컬럼명 및 구조가 DB TABLE과 같아야함
        /// </summary>
        /// <param name="_query"></param>
        /// <param name="_param"></param>
        /// <returns></returns>
        public bool executeBulkInsertQuery(DataTable _param, string _tableName)
        {
            try
            {
                beginTransaction();

                using (var bulk = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                {
                    bulk.DestinationTableName = _tableName;
                    bulk.WriteToServer(_param);
                }
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeBulkInsert-" + _tableName + " \nException: \n" + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "BulkInsert-" + _tableName);
            }

            return true;
        }


        /// <method>
        /// Select Query
        /// </method>        
        public DataTable executeSelectQuery(String _query, DataRow _param)
        {

            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    openConnection(connetionString);
                }
                //
                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;

                SetParameter(myCommand, _query, _param);

                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                if (ds.Tables.Count > 0) dataTable = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }

            return dataTable;
        }

        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query, DataRow _param)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                //myCommand.Parameters.AddRange(sqlParameter);

                SetParameter(myCommand, _query, _param);

                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }

            return true;
        }


        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query, DataRow _param)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;

                SetParameter(myCommand, _query, _param);

                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }
            return true;
        }

        public int executeUpdateQuery2(String _query, DataRow _param)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.CommandTimeout = 30;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;

                SetParameter(myCommand, _query, _param);

                myAdapter.UpdateCommand = myCommand;
                return myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }
        }

        /// <method>
        /// Update Query
        /// </method>
        public object executeScalarQuery(String _query, DataRow _param)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                //myCommand.Parameters.AddRange(sqlParameter);

                SetParameter(myCommand, _query, _param);

                myAdapter.InsertCommand = myCommand;
                return myCommand.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeScalarQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }
        }


        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query)//, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                //myCommand.Parameters.AddRange(sqlParameter);
                
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query); 
                //return false;
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                beginTransaction();

                myCommand.Connection = conn;
                myCommand.Transaction = transaction;
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + ex.StackTrace.ToString());
                throw UTIL.SetException(ex, "", _query);
                //return false;
            }
            return true;
        }

        public void closeConnection()
        {
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw UTIL.SetException(ex);   
            }
         }

        private void SetParameter(SqlCommand _cmd, string _query, DataRow _param)
        {
            StringBuilder sbParamName = new StringBuilder();
            //ArrayList list = new ArrayList();
            bool isParam = false;

            int i= 0;

            foreach (char chr in _query)
            {
                i++;

                if (chr == '@')
                {
                    sbParamName = new StringBuilder("@");
                    isParam = true;
                }
                else
                {
                    if (isParam)
                    {
                        if (UTIL.CheckParam(chr.ToString()))
                        {
                            sbParamName.Append(chr);
                            if(_query.Length ==  i)
                            {
                                string colname = sbParamName.Replace("@", "").ToString();

                                if (_param.Table.Columns.Contains(colname))
                                {
                                    if(!_cmd.Parameters.Contains(sbParamName.ToString()))
                                    {
                                        if (_param.Table.Columns[colname].DataType.Name == "Byte[]")
                                        {
                                            SqlParameter sp = new SqlParameter(sbParamName.ToString(), SqlDbType.Image);
                                            sp.Value = _param[colname];

                                            _cmd.Parameters.Add(sp);
                                        }
                                        else
                                        {
                                            SqlParameter sp = new SqlParameter(sbParamName.ToString(), SqlDbType.VarChar);
                                            sp.Value = _param[colname];

                                            _cmd.Parameters.Add(sp);
                                        }
                                    }
                                        //_cmd.Parameters.AddWithValue(sbParamName.ToString(), _param[colname]);
                                    
                                }
                                else
                                {
                                    //_query.Replace("@"+sbParamName.ToString(), " null ");
                                    _cmd.Parameters.AddWithValue(sbParamName.ToString(), null);
                                }

                            }
                        }
                        else
                        {
                            isParam = false;

                            string colname = sbParamName.Replace("@", "").ToString();

                            if (_param.Table.Columns.Contains(colname))
                            {
                                if (!_cmd.Parameters.Contains(sbParamName.ToString()))
                                { 
                                 //   _cmd.Parameters.AddWithValue(sbParamName.ToString(), _param[colname]);
                                    if (_param.Table.Columns[colname].DataType.Name == "Byte[]")
                                    {
                                        SqlParameter sp = new SqlParameter(sbParamName.ToString(), SqlDbType.Image);
                                        sp.Value = _param[colname];

                                        _cmd.Parameters.Add(sp);
                                    }
                                    else if (_param.Table.Columns[colname].DataType.Name == "DateTime")
                                    {
                                        SqlParameter sp = new SqlParameter(sbParamName.ToString(), SqlDbType.DateTime);
                                        sp.Value = _param[colname];

                                        _cmd.Parameters.Add(sp);
                                    }
                                    else
                                    {
                                        SqlParameter sp = new SqlParameter(sbParamName.ToString(), SqlDbType.VarChar);
                                        sp.Value = _param[colname];

                                        _cmd.Parameters.Add(sp);
                                    }
                                    
                                }
                            }
                            else
                            {
                                if (!_cmd.Parameters.Contains(sbParamName.ToString()))
                                {
                                    _cmd.Parameters.AddWithValue(sbParamName.ToString(),DBNull.Value);
                                    
                                }
                            }
                        }
                    }
                }                
            }

        }

    }
}
