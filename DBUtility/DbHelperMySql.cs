using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using MySql.Data.Types;
using System.Configuration;
using MySql.Data.MySqlClient;

    /// <summary>
    /// Copyright (C) 2007-2008 
    /// MySql 通用类库
    /// </summary>
    public abstract class DbHelperMySql
    {

        //在web.config中设置连接字符串  

        protected static string connectionString = ConfigurationSettings.AppSettings["strMysql"].ToString();


        //protected static string connectionString = "User Id=root;Password=;Host=192.168.231.210;Database=test";

        public DbHelperMySql()
        {

        }

        #region  执行简单的SQL语句
        /// <summary>
        /// 执行SQL语句，使用事务
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        public static int ExecuteSql(string SQLString)
        {
            // SQLString = SQLString.Replace("'", "''").Replace(@"\",@"\\");
            int result = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                MySqlTransaction tx = connection.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    cmd.CommandText = SQLString;
                    result = cmd.ExecuteNonQuery();
                    tx.Commit();
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    result = -1;
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
                return result;
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <returns>是否成功  （0成功）  （-1为失败）</returns>
        public static int ExecuteSqlTran(ArrayList SQLStringList)
        {
            int intIsOK = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                            GC.Collect();
                        }
                    }
                    tx.Commit();
                    intIsOK = 0;
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    tx.Rollback();
                    intIsOK = -1;
                    throw new Exception(E.Message + "\r\nSQL:" + cmd.CommandText);

                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return intIsOK;
        }

        /// <summary>
        ///  执行多条SQL语句，实现数据库事务
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <param name="times">超时时间</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(ArrayList SQLStringList, int times)
        {
            int intIsOK = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = times;
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                            GC.Collect();
                        }
                    }
                    tx.Commit();
                    intIsOK = 0;
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    tx.Rollback();
                    intIsOK = -1;
                    throw new Exception(E.Message);

                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return intIsOK;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <returns>是否成功  （0成功）  （-1为失败）</returns>
        public static int ExecuteSqlTran(List<string> SQLStringList)
        {
            int intIsOK = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                string strsql = string.Empty;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                            GC.Collect();
                        }
                    }
                    tx.Commit();
                    intIsOK = 0;
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    tx.Rollback();
                    intIsOK = -1;
                    throw new Exception(E.Message);

                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
            return intIsOK;
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(SQLString, connection);
                MySql.Data.MySqlClient.MySqlParameter myParameter = new MySql.Data.MySqlClient.MySqlParameter("@content", MySqlDbType.Int32);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if (trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;//cmdType;
                if (cmdParms != null)
                {


                    foreach (MySqlParameter parameter in cmdParms)
                    {
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }




        /// <summary>
        ///向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(strSQL, connection);
                MySql.Data.MySqlClient.MySqlParameter myParameter = new MySql.Data.MySqlClient.MySqlParameter("@fs", MySqlDbType.Blob);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果</returns>
        public static object GetSingle(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static MySqlDataReader ExecuteReader(string strSQL)
        {
            try
            {
                return MySqlHelper.ExecuteReader(connectionString, strSQL);

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    using (MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection))
                    {

                        command.Fill(ds, "ds");
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return ds;
            }
        }


        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="times">超时时间</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, int times)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = times;
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;

            }
        }

        public static bool Exists(string strSql)
        {
            object obj = DbHelperMySql.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int GetMaxID(string fieldName, string tableName)
        {
            int intMaxID = 0;
            string strSql = "SELECT MAX(" + fieldName + ") ID FROM " + tableName + "";
            DataTable dtMaxID = Query(strSql).Tables[0];
            if (dtMaxID.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtMaxID.Rows[0]["ID"].ToString()))
                {
                    intMaxID = Convert.ToInt32(dtMaxID.Rows[0]["ID"].ToString());
                }
                else
                {
                    intMaxID = 0;
                }

            }
            else
                intMaxID = 0;
            return intMaxID;
        }


        #endregion

    }


