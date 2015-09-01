using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Function
{
    public static class DBHelper
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static string Add(string _mTableName, object model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            Type t = model.GetType();
            foreach (var item in t.GetProperties())
            {
                object obj = item.GetValue(model, null);
                if ((!Object.Equals(obj, null)))
                {
                    if (!obj.ToString().IsNullOrEmpty())
                    {
                        strSql1.Append(item.Name + ",");
                        strSql2.Append("N'" + item.GetValue(model, null).ToString().Replace("'", "''") + "',"); 
                    }
                }
            }

            strSql.Append("insert into " + _mTableName + "(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static string Update(string _mTableName, object model, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + _mTableName + " set ");
            Type t = model.GetType();
            foreach (var item in t.GetProperties())
            {
                object obj = item.GetValue(model, null);

                if ((!Object.Equals(obj, null)))
                {
                    if (item.GetValue(model, null) != null)
                    {
                        strSql.Append(item.Name + "=N'" + item.GetValue(model, null).ToString().Replace("'", "''") + "',");
                    }
                    else
                    {
                        strSql.Append(item.Name + "= null ,");
                    }
                }
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);

            strSql.Append("where 1=1 "+strWhere);
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static string Del(string _mTableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("delete from " + _mTableName + " where 1=1 " + strWhere);

            return strSql.ToString();
        }
    }
}
