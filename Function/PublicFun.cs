using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Function
{
    public static class PublicFun
    {
        /// <summary>
        /// cpj 
        /// 传 日期时间区分 返回日期或者返回时间

        /// </summary>
        /// <param name="QF">取值： ComConst.Date 或者 ComConst.Time</param> 
        /// <returns></returns>
        public static string GetSystemDateTime(string QF, string dateStyle)
        {
            string strSystemDT = string.Empty;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CALL getsysDateTime()");

                DataTable dt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (QF.Equals(ComConst.Date))
                    {
                        if (dateStyle.Equals(ComConst.dateStyle_YMD))
                        {
                            strSystemDT = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("yyyy^MM^dd").Replace("^", "");
                        }
                        else if (dateStyle.Equals(ComConst.dateStyle_Y_M_D))
                        {
                            strSystemDT = DateTime.Parse(dt.Rows[0][0].ToString()).ToString("yyyy^MM^dd").Replace("^", "/");
                        }
                    }
                    else
                    {
                        strSystemDT = dt.Rows[0][1].ToString();
                    }
                    return strSystemDT;
                }
                else
                {
                    return strSystemDT;
                }
            }
            catch (Exception ex)
            {
                if (QF.Equals(ComConst.Date))
                {
                    strSystemDT = DateTime.Parse(System.DateTime.Now.ToShortDateString()).ToString(dateStyle);
                }
                else
                {
                    strSystemDT = System.DateTime.Now.ToShortTimeString();
                }
                ComForm.InsertErrLog(ex.ToString(), "GetSystemDateTime");
                return strSystemDT;
            }
        }



        /// <summary>
        /// cpj
        /// 绑定下拉列表框
        /// <param name="combox">要绑定的下拉列表框的名字</param>
        /// <param name="GLBH">名称master中的管理编号</param>
        /// <param name="ADDNULLqf">表示是否带第一行是空白行 qf等于0 表示包含空白行</param>        
        /// </summary>
        public static void comboxBind(ComboBox combox, DataTable dt, int AddNullQf)
        {
            try
            {
              
                if (dt.Rows.Count > 0)
                {
                    if (AddNullQf == 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = "";
                        dt.Rows.InsertAt(dr, 0);
                    }
                    combox.DisplayMember = "ZSMC";
                    combox.ValueMember = "MCKEY";
                    combox.DataSource = dt.DefaultView;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dt.Rows.InsertAt(dr, 0);
                    combox.DisplayMember = "ZSMC";
                    combox.ValueMember = "MCKEY";
                    combox.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                //ComForm.InsertErrLog(ex.ToString(), "comboxBind");
            }
        }



        #region ComboBox绑定数据
        public static void comboxBind(ComboBox combox, string configAppSettingsName)
        {
            if (configAppSettingsName.IsNullOrEmpty()) //configAppSettingsName=null;
            {
                combox = null;
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");
            dt.Columns.Add("KEY");
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');//获取管理名称+编号的数组

            dt.Rows.Add(dt.NewRow());

            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrString = arrData[i].Split('|');
                dt.Rows.Add(new string[] { arrString[0].ToString(), arrString[1].ToString() });
            }

            combox.DisplayMember = "VALUE";
            combox.ValueMember = "KEY";
            combox.DataSource = dt.DefaultView;
        }
        #endregion


        /// <summary>
        /// cpj 
        /// 传 日期时间区分 返回日期或者返回时间

        /// </summary>
        /// <param name="QF">取值： ComConst.Date 或者 ComConst.Time</param> 
        /// <param name="addday">日期变更，例如去系统日期前一天则传值-1</param> 
        /// <returns></returns>
        public static string GetSystemDateTime(string QF, string dateStyle, int addday)
        {
            string strSystemDT = string.Empty;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CALL getsysDateTime()");

                DataTable dt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (QF.Equals(ComConst.Date))
                    {
                        DateTime dtime = DateTime.Parse(dt.Rows[0][0].ToString());
                        if (addday != 0)
                        {
                            dtime = dtime.AddDays(addday);
                        }
                        if (dateStyle.Equals(ComConst.dateStyle_YMD))
                        {
                            strSystemDT = dtime.ToString("yyyy^MM^dd").Replace("^", "");
                        }
                        else if (dateStyle.Equals(ComConst.dateStyle_Y_M_D))
                        {
                            strSystemDT = dtime.ToString("yyyy^MM^dd").Replace("^", "/");
                        }
                    }
                    else
                    {
                        strSystemDT = dt.Rows[0][1].ToString();
                    }
                    return strSystemDT;
                }
                else
                {
                    return strSystemDT;
                }
            }
            catch (Exception ex)
            {
                if (QF.Equals(ComConst.Date))
                {
                    strSystemDT = DateTime.Parse(System.DateTime.Now.ToShortDateString()).ToString(dateStyle);
                }
                else
                {
                    strSystemDT = System.DateTime.Now.ToShortTimeString();
                }
                ComForm.InsertErrLog(ex.ToString(), "GetSystemDateTime");
                return strSystemDT;
            }
        }

        /// <summary>
        /// cpj
        /// 绑定下拉列表框

       
       

       

        /// <summary>
        /// 计算机名
        /// </summary>
        /// <returns></returns>
        public static string Get_SysDNBH()
        {
            string SysDNBH = string.Empty;
            SysDNBH = System.Net.Dns.GetHostName();
            return SysDNBH;
        }

        #region 日期验证函数
        /// <summary>
        /// CN
        /// 判断用户输入是否为日期

        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 可判断格式如下（其中-可替换为/，不影响验证)
        /// YYYY | YYYY-MM | YYYY-MM-DD | YYYY-MM-DD HH:MM:SS | YYYY-MM-DD HH:MM:SS.FFF
        /// YYYY | YYYYMM | YYYYMMDD | YYYYMMDD HH:MM:SS | YYYYMMDD HH:MM:SS.FFF
        /// </remarks>
        public static bool IsDateTime(string strValue)
        {
            if (null == strValue)
            {
                return false;
            }
            if (strValue.IndexOf("-") == -1 && strValue.IndexOf("/") == -1 && strValue.Length > 4)
            {
                if (strValue.Length == 6)
                {
                    strValue = strValue.Substring(0, 4) + "-" + strValue.Substring(4, 2);
                }
                if (strValue.Length == 8)
                {
                    strValue = strValue.Substring(0, 4) + "-" + strValue.Substring(4, 2) + "-" + strValue.Substring(6, 2);
                }
                if (strValue.Length == 17)
                {
                    strValue = strValue.Substring(0, 4) + "-" + strValue.Substring(4, 2) + "-" + strValue.Substring(6, 2) + strValue.Substring(8, 9);
                }
                if (strValue.Length == 21)
                {
                    strValue = strValue.Substring(0, 4) + "-" + strValue.Substring(4, 2) + "-" + strValue.Substring(6, 2) + strValue.Substring(8, 12);
                }
            }


            string regexDate = @"[1-9]{1}[0-9]{3}((-|\/){1}(([0]?[1-9]{1})|(1[0-2]{1}))((-|\/){1}((([0]?[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1})))( (([0-1]{1}[0-9]{1})|2[0-3]{1}):([0-5]{1}[0-9]{1}):([0-5]{1}[0-9]{1})(\.[0-9]{3})?)?)?)?$";

            if (Regex.IsMatch(strValue, regexDate))
            {
                //以下各月份日期验证，保证验证的完整性

                int _IndexY = -1;
                int _IndexM = -1;
                int _IndexD = -1;

                if (-1 != (_IndexY = strValue.IndexOf("-")))
                {
                    _IndexM = strValue.IndexOf("-", _IndexY + 1);
                    _IndexD = strValue.IndexOf(":");
                }
                else
                {
                    _IndexY = strValue.IndexOf("/");
                    _IndexM = strValue.IndexOf("/", _IndexY + 1);
                    _IndexD = strValue.IndexOf(":");
                }

                //不包含日期部分，直接返回true
                if (-1 == _IndexM)
                    return true;

                if (-1 == _IndexD)
                {
                    _IndexD = strValue.Length + 3;
                }

                int iYear = Convert.ToInt32(strValue.Substring(0, _IndexY));
                int iMonth = Convert.ToInt32(strValue.Substring(_IndexY + 1, _IndexM - _IndexY - 1));
                int iDate = Convert.ToInt32(strValue.Substring(_IndexM + 1, _IndexD - _IndexM - 4));

                //判断月份日期
                if ((iMonth < 8 && 1 == iMonth % 2) || (iMonth > 8 && 0 == iMonth % 2) || (iMonth == 8))
                {
                    if (iDate < 32)
                        return true;
                }
                else
                {
                    if (iMonth != 2)
                    {
                        if (iDate < 31)
                            return true;
                    }
                    else
                    {
                        //闰年
                        if ((0 == iYear % 400) || (0 == iYear % 4 && 0 < iYear % 100))
                        {
                            if (iDate < 30)
                                return true;
                        }
                        else
                        {
                            if (iDate < 29)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 高歌
        /// 判断日期类型 和有效性 
        /// 返回 0   年月日有效

        /// 返回 1   年无效

        /// 返回 2   月无效

        /// 返回 3   日无效

        /// </summary>
        /// <param name="y">年</param>
        /// <param name="m">月</param>
        /// <param name="d">日</param>
        /// <returns>0 or 1 or 2 or 3</returns>
        public static string ChkDate(string y, string m, string d)
        {
            string result = "0";
            if (y.IsNullOrEmpty() && m.IsNullOrEmpty() && d.IsNullOrEmpty())
            {
                result = "0";
                return result;
            }
            //判断年是否正确

            if (y.Length != 4 || y.StringToInt() == 0)
            {
                result = ComConst.YI;
                return result;
            }
            //判断月份是否正确
            if (m.StringToInt() > 12 || m.StringToInt() == 0)
            {
                result = ComConst.ER;
                return result;
            }
            string Date = y + "/" + m + "/" + d;
            //判断日期的日是否正确
            try
            {
                Convert.ToDateTime(Date);
            }
            catch
            {
                result = ComConst.SAN;
                return result;
            }

            return result;
        }
        #endregion

        /// <summary>
        /// 高歌
        /// 利用MySql 函数得到两时间内的小时数 
        /// </summary>
        /// <param name="startSJ"></param>
        /// <param name="endSJ"></param>
        /// <returns></returns>
        public static double getHours(string startSJ, string endSJ)
        {
            double result = 0;
            int kss;
            int ksf;
            int jss;
            int jsf;
            if (startSJ.Replace(":", "").IsNullOrEmpty() || endSJ.Replace(":", "").IsNullOrEmpty())
            {
                result = 0;
                return result;
            }
            if ("00:00".Equals(endSJ))
            {
                endSJ = "24:00";
            }
            string[] arrStart = startSJ.Split(':');
            string[] arrEnd = endSJ.Split(':');
            //开始时
            kss = arrStart[0].StringToInt();
            //开始分
            ksf = arrStart[1].StringToInt();
            //结束时

            jss = arrEnd[0].StringToInt();
            //结束分

            jsf = arrEnd[1].StringToInt();

            // 不足30分钟的开始分变为0
            if (ksf < 30 && ksf > 0)
            {
                ksf = 30;
            }
            // 大于30分钟的开始时间+1
            else if (ksf > 30)
            {
                ksf = 0;
                kss = kss + 1;
            }
            // 大于30分钟的结束分变为30
            if (jsf >= 30)
            {
                jsf = 30;
            }
            else
            {
                jsf = 0;
            }

            startSJ = kss.ToString().PadLeft(2, '0') + ":" + ksf.ToString().PadLeft(2, '0');
            endSJ = jss.ToString().PadLeft(2, '0') + ":" + jsf.ToString().PadLeft(2, '0');
            result = (jss - kss) + Math.Floor(Convert.ToDouble((jsf - ksf) / 30)) * 0.5;
            if (result < 0)
                result = 0;
            return result;
            //string strSQL = "select getHours('" + startSJ + "','" + endSJ + "');";
            //return DbHelperMySql.Query(strSQL).Tables[0].Rows[0][0].ToString().StringToDouble();
        }


        /// <summary>
        /// 高歌
        /// 利用MySql 函数得到两时间内的小时数 
        /// </summary>
        /// <param name="startSJ"></param>
        /// <param name="endSJ"></param>
        /// <returns></returns>
        public static double getHours_Test(string startSJ, string endSJ)
        {
            double result = 0;
            int kss;
            int ksf;
            int jss;
            int jsf;
            if (startSJ.Replace(":", "").IsNullOrEmpty() || endSJ.Replace(":", "").IsNullOrEmpty())
            {
                result = 0;
                return result;
            }
            string[] arrStart = startSJ.Split(':');
            string[] arrEnd = endSJ.Split(':');
            //开始时
            kss = arrStart[0].StringToInt();
            //开始分
            ksf = arrStart[1].StringToInt();
            //结束时
            jss = arrEnd[0].StringToInt();
            //结束分
            jsf = arrEnd[1].StringToInt();

            //李庆林20140405 最小单位0.25H
            result = Math.Floor(Convert.ToDouble((jss - kss) * 60 + jsf - ksf) / 15) * 0.25;
            //result = Math.Floor(Convert.ToDouble((jss - kss) * 60 + jsf - ksf) / 30) * 0.5;
            if (result < 0)
                result = 0;
            return result;
        }





        /// <summary>
        /// 高歌
        /// 利用MySql 函数得到两时间内的小时数 
        /// </summary>
        /// <param name="startSJ">开始时间</param>
        /// <param name="endSJ">结束时间</param>
        /// <param name="QianQF">前区分(是否补24小时)</param>
        /// <param name="HouQF">后区分(是否补24小时)</param>
        /// <returns></returns>
        public static double getHours(string startSJ, string endSJ, string QianQF, string HouQF, int intKSF, int intJSF)
        {
            double result = 0;
            int kss;
            int ksf;
            int jss;
            int jsf;
            if (startSJ.Replace(":", "").IsNullOrEmpty() || endSJ.Replace(":", "").IsNullOrEmpty())
            {
                result = 0;
                return result;
            }


            //if ("00:00".Equals(endSJ))
            //{
            //    endSJ = "24:00";
            //}
            string[] arrStart = startSJ.Split(':');
            string[] arrEnd = endSJ.Split(':');
            //开始时
            kss = arrStart[0].StringToInt();
            //开始分
            ksf = arrStart[1].StringToInt();
            //结束时

            jss = arrEnd[0].StringToInt();
            //结束分

            jsf = arrEnd[1].StringToInt();

            // 不足30分钟的开始分变为0
            //if (ksf < 30 && ksf > 0)
            //{
            //    ksf = 30;
            //}

            if (ksf < intJSF && ksf > intKSF)
            {
                ksf = intJSF;
            }
            // 大于30分钟的开始时间+1
            //else if (ksf > 30)
            //{
            //    ksf = 0;
            //    kss = kss + 1;
            //}
            else if (ksf > intJSF)
            {
                ksf = intKSF;
                kss = kss + 1;
            }
            // 大于30分钟的结束分变为30
            //if (jsf >= 30)
            //{
            //    jsf = 30;
            //}
            //else
            //{
            //    jsf = 0;
            //}

            if (jsf >= intJSF)
            {
                jsf = intJSF;
            }
            else
            {
                jsf = intKSF;
            }

            startSJ = kss.ToString().PadLeft(2, '0') + ":" + ksf.ToString().PadLeft(2, '0');
            endSJ = jss.ToString().PadLeft(2, '0') + ":" + jsf.ToString().PadLeft(2, '0');
            if (QianQF == "1")
                kss += 24;
            if (HouQF == "1")
                jss += 24;

            result = (jss - kss) + Math.Floor(Convert.ToDouble((jsf - ksf) / 30)) * 0.5;
            if (result < 0)
                result = 0;
            return result;
            //string strSQL = "select getHours('" + startSJ + "','" + endSJ + "');";
            //return DbHelperMySql.Query(strSQL).Tables[0].Rows[0][0].ToString().StringToDouble();
        }


        /// <summary>
        /// 高歌
        /// 利用MySql 函数得到两时间内的小时数 
        /// </summary>
        /// <param name="startSJ">开始时间</param>
        /// <param name="endSJ">结束时间</param>
        /// <param name="QianQF">前区分(是否补24小时)</param>
        /// <param name="HouQF">后区分(是否补24小时)</param>
        /// <returns></returns>
        public static double getMinute(string startSJ, string endSJ, string QianQF, string HouQF)
        {
            double result = 0;
            int kss;
            int ksf;
            int jss;
            int jsf;
            if (startSJ.Replace(":", "").IsNullOrEmpty() || endSJ.Replace(":", "").IsNullOrEmpty())
            {
                result = 0;
                return result;
            }
            string[] arrStart = startSJ.Split(':');
            string[] arrEnd = endSJ.Split(':');
            //开始时
            kss = arrStart[0].StringToInt();
            //开始分
            ksf = arrStart[1].StringToInt();
            if (ksf % 10 != 0)
            {
                ksf = (ksf / 10 + 1) * 10;
            }
            //结束时
            jss = arrEnd[0].StringToInt();
            //结束分
            jsf = arrEnd[1].StringToInt();

            if (QianQF == "1")
                kss += 24;
            if (HouQF == "1")
                jss += 24;


            if (jsf < 10)
            {
                jss = jss - 1;
                jsf = 60;
            }
            if (jsf % 10 != 0)
            {
                jsf = (jsf / 10) * 10;
            }

            //endSJ = jss.ToString().PadLeft(2, '0') + ":" + jsf.ToString().PadLeft(2, '0');

            result = (jss - kss) * 60 + Math.Floor(Convert.ToDouble((jsf - ksf)));
            if (result < 0)
                result = 0;
            return result;

        }


        /// <summary>
        /// 得到服务器的当前年
        /// </summary>
        /// <returns></returns>
        public static int GetServerYear()
        {
            return Convert.ToInt32(DbHelperMySql.GetSingle("select year(curdate())"));
        }

        /// <summary>
        /// 得到服务器的当前月
        /// </summary>
        /// <returns></returns>
        public static int GetServerMonth()
        {
            return Convert.ToInt32(DbHelperMySql.GetSingle("select month(curdate())"));
        }

        public static void SetValidation(Form winForm, bool blIsValidation)
        {
            string xx;
            Type type;
            PropertyInfo per;
            foreach (Control ctrl in winForm.Controls)
            {

                type = ctrl.GetType();//当前实例的确切运行时类型
                per = type.GetProperty("CausesValidation");
                if (per != null)//判断该类型是否具有某属性(此例中为取消验证属性)
                {
                    ctrl.CausesValidation = blIsValidation;
                }
                if (ctrl is GroupBox)
                {
                    GroupBox group = (GroupBox)(ctrl);
                    foreach (Control ctrls in group.Controls)
                    {
                        xx = ctrls.Name;
                        type = ctrls.GetType();
                        per = type.GetProperty("CausesValidation");
                        if (per != null)
                        {
                            ctrl.CausesValidation = blIsValidation;
                        }
                    }
                }
            }
        }

        public static void SetFocusByName(Form form, string controlName)
        {
            try
            {
                if (controlName.IsNullOrEmpty())
                    return;
                Control[] control;
                control = form.Controls.Find(controlName, true);
                if (control.Length == 1 && control[0] is TextBox)
                {
                    (control[0] as TextBox).Focus();
                }
                else if (control.Length == 1 && control[0] is ComboBox)
                {
                    (control[0] as ComboBox).Focus();
                }
                else if (control.Length == 1 && control[0] is MaskedTextBox)
                {
                    (control[0] as MaskedTextBox).Focus();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 回车Send     Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void EnterSendTab(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

    }
}

