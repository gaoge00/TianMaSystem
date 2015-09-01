using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
///高歌
///常用扩展方法
///
///
namespace Function
{
    public static class StaticFun
    {
        /// <summary>
        /// 作者：高歌
        /// 功能：判断字符串为 null 或 empty 返回 True 否则返回 False 
        /// </summary>
        /// <param name="refStr">判断的字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string refStr)
        {
            return string.IsNullOrEmpty(refStr) ? true : false;
        }

        /// <summary>
        /// 作者：高歌
        /// 功能：将null 或 empty 的字符串替换成 替代 字符串

        /// </summary>
        /// <param name="refStr">判断的字符串</param>
        /// <param name="returnStr">为null 或 empty 转换的字符串 </param>
        /// <returns></returns>
        public static string NullOrEmpty(this string refStr, string returnStr)
        {
            return string.IsNullOrEmpty(refStr) ? returnStr : refStr;
        }

        /// <summary>
        /// 作者：高歌
        /// 功能：对象为数字 返回String形式 否则返回NULL
        /// </summary>
        /// <param name="refStr">判断的对象</param>
        /// <returns>True/False</returns>
        public static string isNumberOrNull(this object refStr)
        {
            string result = string.Empty;
            if (refStr == null)
                return result;
            double i = 0;
            result = double.TryParse(refStr.ToString(), out i) ? refStr.ToString() : "NULL";
            return result;
        }

        /// <summary>
        /// 作者：高歌
        /// 功能：对象为空 返回String.Empty 否则返回对象.ToString()
        /// </summary>
        /// <param name="refStr">判断的对象</param>
        /// <returns>String类型</returns>
        public static string ObjToString(this object refStr)
        {
            if (refStr == null)
                return string.Empty;
            else
                return refStr.ToString();
        }

        /// <summary>
        /// 作者：高歌
        /// 功能：对象为数字字符串 返回Int形式 否则返回0
        /// </summary>
        /// <param name="refStr"></param>
        /// <returns></returns>
        public static int StringToInt(this string refStr) 
        {
            int result = 0;
            try
            {
                result=Convert.ToInt32(refStr.PadLeft(1,'0'));
            }
            catch {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 作者：高歌
        /// 按某项去除重复项.DistinctBy(p=>new { p.社员编号,p. 日期});
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) 
        { 
            HashSet<TKey> seenKeys = new HashSet<TKey>(); 
            foreach (TSource element in source) 
            { 
                if (seenKeys.Add(keySelector(element))) 
                { 
                    yield return element; 
                } 
            } 
        }
        /// <summary>
        /// 作者：高歌
        /// 功能：对象为数字字符串 返回Double形式 否则返回0
        /// </summary>
        /// <param name="refStr"></param>
        /// <returns></returns>
        public static double StringToDouble(this string refStr)
        {
            double result = 0;
            try
            {
                double.TryParse(refStr.ToString(), out result);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 将DataTable中的一列转换成string[] 一维数组

        /// </summary>
        /// <param name="refDt">需要转换的DataTable</param>
        /// <param name="Row">列号</param>
        /// <returns>string[]</returns>
        public static string[] DataTableToArray(this DataTable refDt, int Col)
        {
            int i = 0;
            string[] returnArray = { };
            if (refDt.Rows.Count > 0)
            {
                returnArray = new string[refDt.Rows.Count];
                DataRow foundRows = refDt.Rows[refDt.Rows.Count - 1];
                foreach (DataRow dr in refDt.Rows)
                {
                    returnArray[i] = dr[Col].ToString();
                    i++;
                }
            }
            return returnArray;
        }

        /// <summary>
        /// 功能：替换特殊字符（'\）

        /// </summary>
        public static string strReplace(this string Str)
        {
            return Str.Replace("'", "''").Replace(@"\", @"\\").Trim();
        }
        /// <summary>
        /// 作者：高歌
        /// 功能：获取Dictionary中的Value值

        /// </summary>
        /// <param name="dicStr">Dictionary</param>
        /// <param name="key">Key</param>
        /// <returns>string</returns>
        public static string getValve(this Dictionary<string,string> dicStr,string  key)
        {
            if (dicStr.ContainsKey(key))
                return dicStr[key].ToString();
            else
                return string.Empty;
        }


        /// <summary>
        /// 作者：高歌
        /// 功能：获取ComboBox中的Value值

        /// </summary>
        /// <param name="comboBox">ComboBox</param>
        /// <returns>string</returns>
        public static string getValue(this ComboBox comboBox)
        {
            if (comboBox.SelectedValue!=null)
                return "-1".Equals(comboBox.SelectedValue.ToString()) ? string.Empty : comboBox.SelectedValue.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// 作者：高歌
        /// 功能：判断对象是否为数字
        /// </summary>
        /// <param name="refStr">判断的对象</param>
        /// <returns>True/False</returns>
        public static bool isNumberRegex(this object refStr)
        {
            bool result = false;
            if (refStr == null)
                return result;
            result = Regex.IsMatch(refStr.ToString(), @"\d+$");
            return result;
        }


        /// <summary> 
        /// gaoge
        /// 将匿名集合反射成DataTable
        /// </summary>
        /// <typeparam name="T">匿名对象</typeparam>
        /// <param name="data">匿名对象</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> dataList_group)
        {
            var dt = new System.Data.DataTable();
            var ps = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));//反射 得到匿名对象的属性

            foreach (System.ComponentModel.PropertyDescriptor pd in ps)//属性的详细 描述（descriptor）

                dt.Columns.Add(pd.Name, pd.PropertyType);
            foreach (T datalist in dataList_group)
            {
                var dr = dt.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor pd in ps)
                    dr[pd.Name] = pd.GetValue(datalist);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static string strReaplace(string str)
        {
            return str.Replace("'", "");
        }

        #region DataTable to List
        public static List<T> ConvertTo<T>(this DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<T> lists = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                lists.Add((T)row[0]);
            }
            return lists;
        }



        #endregion DataTable to List


    }
}
