using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;


namespace Function
{
    public static class Comm
    {

        /// <summary>
        /// 得到配置文件信息：返回ＤＢ编号对应的字符串值（向画面赋值时调用）
        /// </summary>
        /// <param name="dataNameBh">配置文件中appSettings部分的字符串值</param>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>编号对应的字符串值</returns>
        public static string GetDataName(string dataNameBH, string configAppSettingsName)
        {
            string dataName = string.Empty;
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');

                if (dataNameBH.Equals(arrKey[1].ToString()))
                {
                    dataName = arrKey[0].ToString();
                }
            }

            return dataName;
        }

        /// <summary>
        /// 得到配置文件信息：返回字符串对应的ＤＢ编号值（向画面赋值时调用）
        /// </summary>
        /// <param name="dataNameBh">配置文件中appSettings部分的字符串值</param>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>编号对应的字符串值</returns>
        public static string GetDataName1(string Name, string configAppSettingsName)
        {
            string dataName = string.Empty;
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');

                if (Name.Equals(arrKey[0].ToString()))
                {
                    dataName = arrKey[1].ToString();
                }
            }

            return dataName;

        }

        /// <summary>
        /// 得到配置文件信息：返回字符串对应的ＤＢ编号值（向画面赋值时调用）
        /// </summary>
        /// <param name="dataNameBh">配置文件中appSettings部分的字符串值</param>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>编号对应的字符串值</returns>
        public static string GetDataName2(string Name, string configAppSettingsName)
        {
            string dataName = string.Empty;
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');

                if (Name.Equals(arrKey[0].ToString()))
                {
                    dataName = arrKey[1].ToString();
                }
            }

            return dataName == String.Empty ? String.Empty : Name;

        }

        /// <summary>
        /// 得到配置文件信息
        /// </summary>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>返回配置文件信息(例：男|1  ；  女|2）</returns>
        public static List<string> GetConData(string configAppSettingsName)
        {
            List<string> listConData = new List<string>();
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            for (int i = 0; i < arrData.Length; i++)
            {
                listConData.Add(arrData[i].ToString());
            }

            return listConData;

        }

        /// <summary>
        /// 得到配置文件信息返回键值对 
        /// </summary>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>返回配置文件信息(例：男|1  ；  女|2）</returns>
        public static ArrayList GetConDataHash(string configAppSettingsName)
        {
            ArrayList listConData = new ArrayList();
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            listConData.Add(new DictionaryEntry(string.Empty, string.Empty));

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');
                listConData.Add(new DictionaryEntry(arrKey[0].ToString(), arrKey[1].ToString()));


            }
            return listConData;

        }

        /// <summary>
        /// 得到配置文件信息返回键值对 
        /// </summary>
        /// <param name="configAppSettingsName">配置文件中appSettings部分的key值</param>
        /// <returns>返回配置文件信息(例：男|1  ；  女|2）</returns>
        public static ArrayList GetConDataHashNoEmpty(string configAppSettingsName)
        {
            ArrayList listConData = new ArrayList();
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            //listConData.Add(new DictionaryEntry(string.Empty, string.Empty));

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');
                listConData.Add(new DictionaryEntry(arrKey[0].ToString(), arrKey[1].ToString()));


            }
            return listConData;

        }

        /// zxd读取CONFIG文件，返回数组
        public static string[] Get_zxd(string configAppSettingsName)
        {

            ArrayList listConData = new ArrayList();
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            listConData.Add(new DictionaryEntry(string.Empty, string.Empty));
            string[] arrKey = new string[arrData.Length + 1];
            arrKey[0] = "";
            for (int i = 1; i < arrData.Length + 1; i++)
            {
                arrKey[i] = arrData[i - 1].Split('|')[0];

            }
            return arrKey;

        }
        /// zxd读取CONFIG文件，返回数组
        public static string[] Get_zxd1(string configAppSettingsName)
        {

            ArrayList listConData = new ArrayList();
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            listConData.Add(new DictionaryEntry(string.Empty, string.Empty));
            string[] arrKey = new string[arrData.Length];
            arrKey[0] = "";
            for (int i = 0; i < arrData.Length; i++)
            {
                arrKey[i] = arrData[i].Split('|')[1];

            }
            return arrKey;

        }
        /// <summary>
        /// 得到数据库信息返回键值对 
        /// </summary>
        /// <param name="dt"></param>
        public static ArrayList GetDBHash(DataTable dt)
        {
            ArrayList listConData = new ArrayList();
            listConData.Add(new DictionaryEntry(string.Empty, string.Empty));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listConData.Add(new DictionaryEntry(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));

            }
            return listConData;

        }

        /// <summary>
        ///判断是否是数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>TURE：数字 ； FALSE：非数字／或为０</returns>
        public static bool IsNum(string str)
        {
            bool blResult = true;
            if (string.IsNullOrEmpty(str))
            {
                blResult = false;
            }
            else
            {
                foreach (char Char in str)
                {
                    if (!Char.IsNumber(Char))
                    {
                        blResult = false;
                        break;
                    }
                }
                if (blResult)
                    if (int.Parse(str) == 0)
                        blResult = false;
            }
            return blResult;
        }

        /// <summary>
        /// 返回字符串中的数字部分
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string IsNumRetrun(string str)
        {
            string blResult = String.Empty;
            if (string.IsNullOrEmpty(str))
            {
                blResult = String.Empty;
            }
            else
            {
                foreach (char Char in str)
                {
                    if (Char.IsNumber(Char))
                    {
                        blResult = blResult + Char;
                    }
                }
            }
            return blResult;
        }

        /// <summary>
        /// 四舍五入转换
        /// </summary>
        /// <param name="dNum">数字</param>
        /// <param name="digit">保留的位数（</param>
        /// <returns>四舍五入数字</returns>
        public static double Round(double dNum, int digit)
        {
            int i;
            long IValue = 1;
            double DValue = 1;

            for (i = 1; i <= digit; i++)
            {
                IValue = IValue * 10;
                DValue = DValue / 10;
            }
            long Int = (long)Decimal.Round(Convert.ToDecimal(dNum * IValue), 0);
            double Key = (double)(dNum / DValue) - Int;
            double Dou = (double)Int / IValue;

            if (Key >= 0.5)
            {
                Dou += DValue;
            }
            return Dou;
        }

        /// <summary>
        /// Email合法验证
        /// </summary>
        /// <param name="strIn">字符串</param>
        /// <returns>TURE：合法 ； FALSE：不合法</returns>
        public static bool IsValidEmail(string strIn)
        {
            //return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return true;
        }

        /// <summary>
        /// 日期合法验证
        /// </summary>
        /// <param name="year">年</param>
        /// <param1 name="month">月</param>
        /// <param1 name="day">日</param>
        /// <returns>0: 合法
        ///          1：年位数不合法
        ///          2：月位数不合法
        ///          3：日位数不合法
        ///          4：日期不是有效日期
        ///  </returns>
        public static int IsDate(string year, string month, string day)
        {
            int i = 0;
            if (year.Length != 4)
            {
                i = 1;
            }

            if (i == 0)
            {
                if (month.Length != 2)
                {
                    i = 2;
                }
                else
                {
                    if (int.Parse(month) <= 0 || int.Parse(month) >= 13)
                    {
                        i = 2;
                    }
                }
            }

            if (i == 0)
            {
                if (day.Length != 2)
                {
                    i = 3;
                }
                else
                {
                    if (int.Parse(day) <= 0 || int.Parse(day) >= 32)
                    {
                        i = 3;
                    }
                }
            }

            if (i == 0)
            {
                try
                {
                    string date = year + "-" + month + "-" + day;
                    DateTime.Parse(date);
                }
                catch
                {
                    i = 4;
                }
            }
            return i;
        }



        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(string str)
        {
            return Regex.IsMatch(str, @"\b\d+(\.\d+)?\b");
        }

        /// <summary>
        /// 返回日期 “YYYY/MM/DD”
        /// </summary>
        /// <param name="oldrq"></param>
        /// <returns></returns>
        public static string GetRQ(string oldrq)
        {
            string newrq = string.Empty;
            if (oldrq.Trim().Length == 8)
            {
                newrq = oldrq.Substring(0, 4) + "/" + oldrq.Substring(4, 2) + "/" + oldrq.Substring(6, 2);
            }
            return newrq;
        }


        /// <summary>
        /// 得到数据库服务器当前日期yyyyMM
        /// </summary>
        /// <returns>日期yyyyMM </returns>
        public static string GetSystemDate_yearmonth()
        {
            string strSystemDate = string.Empty;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("Select CONVERT(varchar(100), GETDATE(), 23)");
            strSql.Append("EXECUTE Alggetsysdate_yearmonth ");

            SqlDataReader odr = DbHelperSQL.ExecuteReader(strSql.ToString());
            if (odr.Read())
            {
                strSystemDate = odr[0].ToString();
            }

            odr.Close();
            //System.GC.Collect();
            return strSystemDate;
        }

        /// <summary>
        /// 得到数据库服务器当前日期yyyy/MM/dd 
        /// </summary>
        /// <returns>日期yyyy/MM/dd </returns>
        public static string GetSystemDate()
        {
            string strSystemDate = string.Empty;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("Select CONVERT(varchar(100), GETDATE(), 23)");
            strSql.Append("EXECUTE Alggetsysdate ");

            SqlDataReader odr = DbHelperSQL.ExecuteReader(strSql.ToString());
            if (odr.Read())
            {
                strSystemDate = odr[0].ToString();
            }

            odr.Close();
            //System.GC.Collect();
            return strSystemDate;
        }

        /// <summary>
        /// 得到数据库服务器当前时间hh:mi:SS 
        /// </summary>
        /// <returns>时间hh:mi:SS </returns>
        public static string GetSystemTime()
        {
            string strSystemTime = string.Empty;
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("Select CONVERT(varchar(100), GETDATE(), 24)");
            strSql.Append("EXECUTE Alggetsystime ");

            SqlDataReader odr = DbHelperSQL.ExecuteReader(strSql.ToString());
            if (odr.Read())
            {
                strSystemTime = odr[0].ToString();
            }

            odr.Close();
            //System.GC.Collect();
            return strSystemTime;
        }

        /// <summary>
        /// 获得主机名
        /// </summary>
        /// <returns>主机名</returns>
        public static string GetHostNM()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// 获得IP
        /// </summary>
        /// <returns>IP</returns>
        public static string GetHostIP()
        {
            IPHostEntry hostipspool = Dns.GetHostByName("");
            return hostipspool.AddressList[0].ToString();
        }

        /// <summary>
        /// 存储ERR信息
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        /// <param name="errForm">错误窗体</param>
        public static void InsertErrLog(string errMsg, string errForm)
        {
            //string sql = "INSERT INTO ERRLOG VALUES(CONVERT(varchar(100), GETDATE(), 20),'" + errMsg.Replace("'", "") + "','" + errForm.Replace("'", "") + "')";
            string sql = "EXECUTE InsertErrLog '" + errMsg.Replace("'", "") + "','" + errForm.Replace("'", "") + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["SQLServer"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }

        }

    }

}

