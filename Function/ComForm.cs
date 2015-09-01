using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Windows;

using System.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Function
{
    public class ComForm
    {
        #region  ログイン情報
        /// <summary>
        /// ユーザ名
        /// </summary>
        public static string strUserName = string.Empty;
        public static string strSymc = string.Empty;

        #endregion
        public static void InsertErrLog(string errMsg, string errForm)
        {
            //PGNM,LOG_MSG,LRZBH,LRZIP
            string sql = "CALL InsertErrLog ('" + errForm.strReplace() + "',N'" + @errMsg.Replace("'", "''") + "'";
            sql += " ,'" + ComForm.strUserName + "' ";
            sql += " ,'" + System.Net.Dns.GetHostName() + "' )";
            DbHelperMySql.Query(sql);

        }

        /// <summary>
        /// 插入系统日志
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errForm"></param>
        public static void InsertInfoLog(string errMsg, string errForm)
        {
          

        }

        /// <summary>
        /// 绑定ComboBox（名称Master）
        /// </summary>
        /// <param name="combox">绑定的ComboBox控件</param>
        /// <param name="GLBH">管理编号</param>
        /// <param name="blnAddLine">是否添加一行空列：是，True；否，False</param>
        //public static void comboxBind(ComboBox combox, string GLBH, bool blnAddLine)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = GetFMD010MC_KEY(GLBH);
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (blnAddLine == true)
        //            {
        //                DataRow dr = dt.NewRow();
        //                object[] objs = { "", "-1" };
        //                dr.ItemArray = objs;
        //                dt.Rows.InsertAt(dr, 0);
        //            }
        //            //combox.DisplayMemberPath = "ZSMC";
        //            //combox.SelectedValuePath = "MCKEY";
        //            //combox.ItemsSource = dt.DefaultView;

        //            combox.DisplayMember = "ZSMC";
        //            combox.ValueMember = "MCKEY";
        //            combox.DataSource = dt.DefaultView;
        //        }
        //        else
        //        {
        //            DataRow dr = dt.NewRow();
        //            object[] objs = { "", "-1" };
        //            dr.ItemArray = objs;
        //            dt.Rows.InsertAt(dr, 0);
        //            combox.DisplayMember = "ZSMC";
        //            combox.ValueMember = "MCKEY";
        //            combox.DataSource = dt.DefaultView;

        //            //combox.DisplayMemberPath = "ZSMC";
        //            //combox.SelectedValuePath = "MCKEY";
        //            //combox.ItemsSource = dt.DefaultView;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ComForm.InsertErrLog(ex.ToString(), "comboxBind");
        //    }
        //}

        /// <summary>
        /// 根据管理编号 获取数据（绑定ComboBox）
        /// </summary>
        /// <param name="GLBH">管理编号</param>
        /// <returns>DataTable</returns>
        //public static DataTable GetFMD010MC_KEY(string GLBH)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string RQ_sql = "";
        //        RQ_sql = "select  DISTINCT ZSMC,MCKEY,SXMC from FMD010 WHERE GLBH='" + GLBH + "'  order by MCKEY ";
        //        dt = DbHelperMySql.Query(RQ_sql).Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ComForm.InsertErrLog(ex.ToString(), "GetFMD010MC_KEY(1)");
        //    }
        //    return dt;
        //}
        /// <summary>
        /// 添加千位符 :NFIAdd
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static string NFIAdd(string strNumber)
        {
            string strRet = strNumber;
            string strInt = string.Empty;
            string strDec = string.Empty;
            int intNum = 0;

            try
            {
                if (string.IsNullOrEmpty(strNumber) == true || strNumber == "0")
                {
                    strRet = "0.00";
                    return strRet;
                }

                //小数情况
                if (strNumber.IndexOf('.') != -1)
                {
                    strInt = strNumber.Split('.')[0];
                    strDec = strNumber.Split('.')[1].PadRight(2, '0');

                    intNum = int.Parse(strInt);
                    System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                    nfi.NumberDecimalDigits = 0;
                    strRet = intNum.ToString("N", nfi);
                    return strRet + "." + strDec;
                }
                else
                {
                    intNum = int.Parse(strNumber.Replace(",", ""));
                    System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                    nfi.NumberDecimalDigits = 0;
                    strRet = intNum.ToString("N", nfi);
                    strRet = strRet + ".00";
                    return strRet;
                }
            }
            catch
            {
                return strRet;
            }
        }


        /// <summary>
        /// 输入法名称
        /// </summary>
        public static string[] languageName = { "Microsoft Office IME 2007",
                                                "Microsoft IME Standard 2003", 
                                                "Microsoft IME Standard 2002", 
                                                "日本語 (MS-IME2002)", 
                                                "日本語",
                                                "日文",
                                                "日文输入系统(MS-IME2002)"};
        /// <summary>
        /// 输入法的切换
        /// </summary>
        /// <param name="languageName">语言</param>
        public static void SetInputLanguage(string strLanguageName)
        {
            for (int i = 0; i < languageName.Length; i++)
            {
                foreach (System.Windows.Forms.InputLanguage l in System.Windows.Forms.InputLanguage.InstalledInputLanguages)
                {
                    if (l.LayoutName.IndexOf(languageName[i].ToString()) >= 0)
                    {
                        System.Windows.Forms.InputLanguage.CurrentInputLanguage = l;
                        return;
                    }
                }
            }
        }



        ///// <summary>
        ///// 高歌
        ///// 判断日期类型 和有效性 
        ///// 返回 0   年月日有效
        ///// 返回 1   年无效
        ///// 返回 2   月无效
        ///// 返回 3   日无效
        ///// </summary>
        ///// <param name="y">年</param>
        ///// <param name="m">月</param>
        ///// <param name="d">日</param>
        ///// <returns>
        ///// 正确：0（全是空不验证）
        ///// 年错误：1
        ///// 月错误：2
        ///// 日错误：3
        ///// </returns>
        //public static string ChkDate(string y, string m, string d)
        //{
        //    string result = "0";
        //    if (y.IsNullOrEmpty() && m.IsNullOrEmpty() && d.IsNullOrEmpty())
        //    {
        //        result = "0";
        //        return result;
        //    }
        //    //判断年是否正确
        //    if (y.Length != 4 || y.StringToInt() == 0)
        //    {
        //        result = Const.YI;
        //        return result;
        //    }
        //    //判断月份是否正确
        //    if (m.StringToInt() > 12 || m.StringToInt() == 0)
        //    {
        //        result = Const.ER;
        //        return result;
        //    }
        //    string Date = y + "/" + m + "/" + d;
        //    //判断日期的日是否正确
        //    try
        //    {
        //        Convert.ToDateTime(Date);

        //    }
        //    catch
        //    {
        //        result = Const.SAN;
        //        return result;
        //    }
        //    return result;
        //}



        /// <summary>
        /// メッセージボックスを表示します。
        /// </summary>
        /// <param name="strMsgCD">メッセージコード</param>
        /// <param name="strItem">項目</param>
        /// <param name="inBtn">表示ボタン("0":"OK","1":"OKCancel","3":"YesNoCancel")</param>
        /// <returns>"0":"OK"</returns>
        /// <returns>"1":"Cancel"</returns>
        /// <returns>"2":"Yes"</returns>
        /// <returns>"3":"No"</returns>
        public static string DspMsg(string strMsgCD, string strItem)
        {
            //SQL文を作成。
            string strSql = "";
            strSql = strSql + "SELECT RTRIM(MSG) MSG ";
            strSql = strSql + "FROM MESSAGE ";
            strSql = strSql + "WHERE MSGCD = '" + strMsgCD + "'";

            DataTable dt = DbHelperMySql.Query(strSql).Tables[0];
            string strMsg = "";
            if (dt.Rows.Count > 0)
            {
                strMsg = dt.Rows[0]["MSG"].ToString();
            }

            //表示メッセージの編集

            string strDspMsg = strMsg;
            if (!string.IsNullOrEmpty(strItem))
            {
                strDspMsg = strDspMsg + "\n対象項目：" + strItem;
            }

            //メッセージコードによって表示アイコンの編集。
            //列挙型(enum)をInt型にキャスト。
            int intIcn = (int)MessageBoxIcon.Stop;
            switch (strMsgCD.Substring(0, 1))
            {
                //警告アイコン
                case "E":
                    intIcn = 16;
                    break;
                //問合せアイコン
                case "Q":
                    intIcn = 32;
                    break;
                //情報アイコン
                case "M":
                    intIcn = 64;
                    break;
                //注意アイコンW
                default:
                    intIcn = 48;
                    break;
            }
            MessageBoxIcon mbIcn = (MessageBoxIcon)intIcn;

            //表示ボタンの編集。
            //列挙型(enum)をInt型にキャスト。
            int intBtn = 0;
            switch (strMsgCD.Substring(0, 1))
            {
                //警告アイコン
                case "W":
                case "E":
                case "M":
                    intBtn = 0;
                    break;
                case "Q":
                    intBtn = 1;
                    break;
                default:
                    intIcn = 0;
                    break;
            }
            MessageBoxButtons mbBtn = (MessageBoxButtons)intBtn;


            //メッセージ表示。 
            DialogResult drBtn;
            //if (strMsgCD == "Q002")
            //    drBtn = MessageBox.Show(strDspMsg, Function.ComConst.MESSAGE_TITLE, mbBtn, mbIcn, MessageBoxDefaultButton.Button2);
            //else
            drBtn = MessageBox.Show(strDspMsg, Function.ComConst.MESSAGE_TITLE, mbBtn, mbIcn);

            //どのボタンか押下されたか判別。
            string strRet = "";
            switch (drBtn)
            {
                case DialogResult.OK:
                    //OKボタン
                    strRet = "0";
                    break;
                case DialogResult.Cancel:
                    //Cancelボタン
                    strRet = "1";
                    break;
                case DialogResult.Yes:
                    //Yesボタン
                    strRet = "2";
                    break;
                case DialogResult.No:
                    //Noボタン
                    strRet = "3";
                    break;
            }
            return strRet;
        }




        /// <summary>
        /// 1 key，0：value 下拉列表数据提值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="configAppSettingsName"></param>
        /// <param name="QF"></param>
        /// <returns></returns>
        public static string GetData_STR(string str, string configAppSettingsName, string QF)
        {
            string key = string.Empty;
            string Value = string.Empty;
            string[] arrData = System.Configuration.ConfigurationSettings.AppSettings[configAppSettingsName].Split('/');

            // 警告	56	“System.Configuration.ConfigurationSettings.AppSettings”
            // 已过时:“"This method is obsolete, it has been replaced by 
            // System.Configuration!System.Configuration.ConfigurationManager.AppSettings[];	
            //F:\2013work0325\Comm_Salary\Function\ComForm.cs	424	32	Function


            for (int i = 0; i < arrData.Length; i++)
            {
                string[] arrKey = arrData[i].Split('|');

                if (str.Equals(arrKey[0].ToString()))
                {
                    key = arrKey[1].ToString();
                }
                else if (str.Equals(arrKey[1].ToString()))
                {
                    Value = arrKey[0].ToString();
                }
            }


            if (QF.Equals("1"))
            {
                return key;
            }
            else
            {
                return Value;
            }
        }


        /// <summary>
        /// 半角英字・数字のみを入力可能とします。
        /// </summary>
        public static void IsAlphAndNum(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && !Regex.IsMatch(e.KeyChar.ToString(), "^[A-Z]") && !Regex.IsMatch(e.KeyChar.ToString(), "^[a-z]") && !Char.IsDigit(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), "^-") && !Regex.IsMatch(e.KeyChar.ToString(), "^×"))
            {
                e.Handled = true;
            }
        }

        ///<summary>
        ///数字のみを入力可能とします。
        ///<summary>
        public static void IsNum(System.Windows.Forms.KeyPressEventArgs e)
        {
            //if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) || Regex.IsMatch(e.KeyChar.ToString(), "[.]"))
            //{
            //    e.Handled = true;
            //}

            if (e.KeyChar == 8)
            {
                return;
            }
            //else if (e.KeyChar == 13)
            //{
            //    SendKeys.Send("{Tab}");
            //}
            else if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                e.Handled = true;
            }
        }

        //'\''、'’'、'‘'不可录入
        public static void IsWB(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar == '\'' || e.KeyChar == '’' || e.KeyChar == '‘')
            {
                e.Handled = true;
            }
        }

        ///<summary>
        ///数字、+、-
        ///<summary>
        public static void IsTel(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar > '9' || e.KeyChar < '0' && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 验证Email格式是否正确
        /// </summary>
        /// <param name="refEmail">需要验证的Email地址</param>
        /// <returns>正确:True;错误:False</returns>
        public static bool IsEmail(string refEmail)
        {
            bool blnResult = false;
            string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" + @"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            blnResult = Regex.IsMatch(refEmail, EmailPattern);
            return blnResult;
        }

        /// <summary>
        /// 判断文本框中的文本中的内容是否为纯数字
        /// </summary>
        /// <param name="textBox">需要验证的文本框控件</param>
        /// <returns>非纯数字：False</returns>
        public static bool IsNumberByTextBox(TextBox textBox)
        {
            bool blnResult = false;
            string NumberPattern = @"^\d+$";
            blnResult = Regex.IsMatch(textBox.Text, NumberPattern);
            return blnResult;
        }

        ///<summary>
        ///数字和小数点
        ///<summary>
        public static void IsNumOrPoint(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar > '9' || e.KeyChar < '0' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
      /// <summary>
        /// 判断 管理编号，区分 给出提示信息
        /// </summary>
        /// <param name="strGLBH">管理编号</param>
        /// <param name="strQF">区分</param>
        /// <returns></returns>
        public static bool checkSendMessage(string strGLBH, string strQF)
        {
            bool blnResult = false;
            string strErrMsgID = string.Empty;
            if ("9060".Equals(strGLBH))
            {
                switch (strQF)
                { 
                    case "":
                        break;
                }
            }
            else if ("9070".Equals(strGLBH))
            {
                switch (strQF)
                {
                    case "":
                        break;
                }
            }
            else if ("9160".Equals(strGLBH))
            {
                switch (strQF)
                {
                    case "":
                        break;
                }
            }
            //如果错误信息为空
            if (strErrMsgID.IsNullOrEmpty())
            {
                ComForm.DspMsg(strErrMsgID, "");
            }
            return blnResult;
        }

        /// <summary>
        /// Enterキー押下はTabキーと同様の処理とする。
        /// </summary>
        public static void EnterKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }
        public static void EnterKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            input = input.Replace("'", "");
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
    }
}
