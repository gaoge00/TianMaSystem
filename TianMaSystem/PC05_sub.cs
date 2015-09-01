using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using Model;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace BSC_System
{
    public partial class PC05_sub : Form
    {
        public PC05_sub()
        {
            InitializeComponent();
        }

        #region 变量定义
        public string _currentPath = System.Threading.Thread.GetDomain().BaseDirectory;  //获取当前路径
        string _savePath = "D:\\JTEKT_Salary\\缓存图片\\";                                  //图片缓存路径
       // BLL.FMD020 _bllFMD020 = new BLL.FMD020();
        Model.fmd010 _modelFMD010 = new Model.fmd010();
        BLL.fmd000 _bllFmd000 =new BLL.fmd000();
        BLL.fmd010 _bllFMD010 = new BLL.fmd010();
       
        public string _wholePath = null;                 //最终路径
        public string _conSYBH = string.Empty;
        #endregion
        #region 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if ("0" == Function.ComForm.DspMsg("Q001", ""))
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        #region Load事件
        private void Window_Loaded(object sender, EventArgs e)
        {           
            BindcboXB();        //性别Combobox绑定
           
    
           
            BindcboBM();        //部门Combobox绑定
           
            BindcboZW();        //职务Combobox绑定
           
            
            
            if (!"".Equals(_conSYBH)) //如果社员编号有值，加载社员信息，否则清空控件
            {
                txtSYBH.Text = _conSYBH;
                LoadFormData(); //画面数据加载
                txtName.Focus();
            }
            else
            {
                ClearEmptyExceptSYBH();  //除社员编号以外的画面控件清空
                txtSYBH.Focus();
            }

      
        }

        #region ComboxBind
        private void BindcboBM()   //部门Combobox绑定
        {
            DataTable dt = new DataTable();
            dt = _bllFmd000.GetFMD030MC_KEY("01");
            PublicFun.comboxBind(cboBM, dt, 0);
        }

        private void BindcboZW()       //职务Combobox绑定
        {
            DataTable dt = new DataTable();
            dt = _bllFmd000.GetFMD030MC_KEY("02");
            PublicFun.comboxBind(cboZW, dt, 0);


            dt = new DataTable();
            dt = _bllFmd000.GetFMD030MC_KEY("12");
            PublicFun.comboxBind(cboIP, dt, 0);

            dt = new DataTable();
            dt = _bllFmd000.GetFMD030MC_KEY("13");
            PublicFun.comboxBind(cboDK, dt, 0);

        }
      

        private void BindcboXB()       //性别Combobox绑定
        {
            PublicFun.comboxBind(cboSex, "XB");
        }

       
        #endregion

        private void LoadFormData()  //画面数据加载
        {
            try
            {
                _modelFMD010.SYBH = txtSYBH.Text;
                DataSet ds = new DataSet();
                if (string.IsNullOrEmpty(_modelFMD010.SYBH) == false)
                {
                    ds = _bllFMD010.GetDaTaForPC05Spread("", _modelFMD010.SYBH);
                  
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if ("0".Equals(ds.Tables[0].Rows[0]["ZT"].ToString()))  //判断社员是否已删除
                        {
                            if (ComForm.DspMsg("Q006", "").Equals(Const.LING)) //数据已经被删除，是否要恢复？
                            {
                                DbHelperMySql.ExecuteSql(_bllFMD010.DeleteSybhRecover(_modelFMD010.SYBH));
                                LoadControlData(ds);      //画面控件数据加载
                                ComForm.DspMsg("M003", "");  //数据恢复成功！
                            }
                            else
                            {
                                ClearEmptyExceptSYBH();   //除社员编号以外的画面控件清空
                                txtSYBH.Text = string.Empty;
                                txtSYBH.Focus();
                            }

                        }
                        else
                        {
                            ClearEmptyExceptSYBH();     //除社员编号以外的画面控件清空
                            LoadControlData(ds);        //画面控件数据加载
                        }
                    }
                }
                else
                {
                    ClearEmptyExceptSYBH();         //除社员编号以外的画面控件清空
                }
                ds.Clear();
                System.GC.Collect();
            }
            catch (Exception e)
            {
                ComForm.DspMsg("E016", "");   //数据加载失败！
                ComForm.InsertErrLog(e.ToString(), this.Name);
            }
        }

        private void LoadControlData(DataSet ds)  //画面控件数据加载
        {
            try
            {
                #region 控件赋值
                //基本信息
                txtSYBH.Text = ds.Tables[0].Rows[0]["SYBH"].ToString();                            //社员编号
                txtName.Text = ds.Tables[0].Rows[0]["SYMC"].ToString();                              //姓名
                txtSFZH.Text = ds.Tables[0].Rows[0]["SFZ"].ToString();                            //身份证号
                cboSex.Text = ds.Tables[0].Rows[0]["XB"].ToString();                               //性别
                if (!ds.Tables[0].Rows[0]["SR"].ToString().IsNullOrEmpty())                      //生日
                {
                    txtCSRQ_Y.Text = ds.Tables[0].Rows[0]["SR"].ToString().Substring(0, 4);
                    txtCSRQ_M.Text = ds.Tables[0].Rows[0]["SR"].ToString().Substring(5, 2);
                    txtCSRQ_D.Text = ds.Tables[0].Rows[0]["SR"].ToString().Substring(8, 2);
                    txtAge.Text = AGE(ds.Tables[0].Rows[0]["SR"].ToString());
                }
                else
                {
                    txtAge.Text = string.Empty;                                                    //年龄
                }

                //联络方式
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();                          //Email
                txtSJ.Text = ds.Tables[0].Rows[0]["SJH"].ToString();                                //手机
                txtXDZ.Text = ds.Tables[0].Rows[0]["ZZ"].ToString();                              //现地址

                //公司信息
                cboBM.Text = ds.Tables[0].Rows[0]["BM"].ToString();                                //部门
                cboZW.Text = ds.Tables[0].Rows[0]["ZW"].ToString();                                //职务

                // ip 端口
                cboIP.Text = ds.Tables[0].Rows[0]["IP"].ToString();
                cboDK.Text = ds.Tables[0].Rows[0]["DK"].ToString();         

                txtName.Focus();
                #endregion
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

       

       

        private string AGE(string Birthday)  //计算年龄
        {
            string age = string.Empty;
            TimeSpan ts = DateTime.Now.Date - Convert.ToDateTime(Birthday);
            age = Math.Floor((Convert.ToInt32(ts.Days) / 365.25)).ToString();

            return age;
        }

        private int JDIGL(string RSRQ)  //计算当前工龄
        {
            int JDIGL = 0;
            JDIGL = DateTime.Now.Year - Convert.ToDateTime(RSRQ).Year;
            if (JDIGL != 0)
            {
                JDIGL = JDIGL * 12;
            }
            JDIGL = JDIGL + DateTime.Now.Month - 1 - Convert.ToDateTime(RSRQ).Month;
            if (JDIGL < 0)
            {
                JDIGL = 0;
            }

            return JDIGL;
        }

        private void ClearEmptyExceptSYBH()  //除社员编号以外的画面控件清空
        {
            #region 控件赋值
            //基本信息
            txtName.Text = string.Empty;     //姓名
             txtSFZH.Text = string.Empty;     //身份证号
            txtCSRQ_Y.Text = string.Empty;   //出生日期年
            txtCSRQ_M.Text = string.Empty;   //出生日期月
            txtCSRQ_D.Text = string.Empty;   //出生日期日
            txtAge.Text = string.Empty;      //年龄
            cboSex.Text = string.Empty;      //性别
         
            //联络方式
            txtEmail.Text = string.Empty;    //Email
             txtSJ.Text = string.Empty;       //手机
               txtXDZ.Text = string.Empty;      //现地址

            //公司信息
            cboBM.Text = string.Empty;         //部门
              cboZW.Text = string.Empty;         //职务

              cboIP.Text = cboDK.Text = string.Empty;
           
            #endregion          
        }

        public void ClearControl()  //清空所有控件
        {
            txtSYBH.Text = string.Empty;
            ClearEmptyExceptSYBH(); //除社员编号以外的画面控件清空
        }
        #endregion
        #region 验证事件
        #region 验证身份证
        public bool Validate(string cardid)
        {
            string[] Errors = { "验证通过!", "身份证号码位数不对!", "身份证号码出生日期超出范围或含有非法字符!", "身份证号码校验错误!", "身份证地区非法!" };
            string[] Area = { "11-北京", "12-天津", "13-河北", "14-山西", "15-内蒙古", "21-辽宁", "22-吉林", "23-黑龙江", "31-上海", "32-江苏", "33-浙江", "34-安徽", "35-福建", "36-江西", "37-山东", "41-河南", "42-湖北", "43-湖南", "44-广东", "45-广西", "46-海南", "50-重庆", "51-四川", "52-贵州", "53-云南", "54-西藏", "61-陕西", "62-甘肃", "63-青海", "64-宁夏", "65-新疆", "71-台湾", "81-香港", "82-澳门", "91-国外" };
            string regex = string.Empty;        //正则表达式
            string ErrorStr = string.Empty;
            //--------------------------------------------------------------------------------------------
            //11:"北京"12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江",
            //31:"上海",32:"江苏",33:"浙江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"河南",42:"湖北",
            //43:"湖南",44:"广东",45:"广西",46:"海南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏",
            //61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新疆",71:"台湾",81:"香港",82:"澳门",91:"国外"
            //--------------------------------------------------------------------------------------------
            string areaErr = "T";
            int Times = 0;

            //地区检验
            foreach (string area in Area)
            {
                Times++;
                if (cardid.Substring(0, 2) == area.Substring(0, 2))
                {
                    areaErr = "T";
                    break;
                }
                if (Times == Area.Length)
                {
                    areaErr = "F";
                }
            }
            if (!IsNumber(cardid.Substring(0, cardid.Length - 1)))
            {
                ErrorStr = Errors[2];
                return false;
            }
            if ("F".Equals(areaErr))
            {
                ErrorStr = Errors[4];
                return false;
            }
            else
            {
                switch (cardid.Length)
                {
                    case 15:
                        {
                            //平年闰年正则
                            if ((Int32.Parse(cardid.Substring(6, 2)) + 1900) % 4 == 0 || (Int32.Parse(cardid.Substring(6, 2)) + 1900) % 100 == 0 && (Int32.Parse(cardid.Substring(6, 2)) + 1900) % 4 == 0)
                            {
                                regex = "^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$";//测试出生日期的合法性
                            }
                            else
                            {
                                regex = "^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$";//测试出生日期的合法性
                            }
                            if (Regex.IsMatch(cardid, regex))
                            {
                                ErrorStr = Errors[0];
                            }
                            else
                            {
                                ErrorStr = Errors[2];
                            }
                            break;

                        }
                    case 18:
                        {
                            //18位身份号码检测
                            //出生日期的合法性检查 
                            //闰年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))
                            //平年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))
                            if ((Int32.Parse(cardid.Substring(6, 2)) + 1900) % 4 == 0 || (Int32.Parse(cardid.Substring(6, 2)) + 1900) % 100 == 0 && (Int32.Parse(cardid.Substring(6, 2)) + 1900) % 4 == 0)
                            {
                                regex = "^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$";//闰年出生日期的合法性正则表达式
                            }
                            else
                            {
                                regex = "^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$";//平年出生日期的合法性正则表达式
                            }
                            if (Regex.IsMatch(cardid, regex))
                            {
                                //测试出生日期的合法性
                                //计算校验位
                                int S = (Int32.Parse(cardid[0].ToString()) + Int32.Parse(cardid[10].ToString())) * 7
                                    + (Int32.Parse(cardid[1].ToString()) + Int32.Parse(cardid[11].ToString())) * 9
                                    + (Int32.Parse(cardid[2].ToString()) + Int32.Parse(cardid[12].ToString())) * 10
                                    + (Int32.Parse(cardid[3].ToString()) + Int32.Parse(cardid[13].ToString())) * 5
                                    + (Int32.Parse(cardid[4].ToString()) + Int32.Parse(cardid[14].ToString())) * 8
                                    + (Int32.Parse(cardid[5].ToString()) + Int32.Parse(cardid[15].ToString())) * 4
                                    + (Int32.Parse(cardid[6].ToString()) + Int32.Parse(cardid[16].ToString())) * 2
                                    + Int32.Parse(cardid[7].ToString()) * 1
                                    + Int32.Parse(cardid[8].ToString()) * 6
                                    + Int32.Parse(cardid[9].ToString()) * 3;
                                int Y = S % 11;
                                string M = "F";
                                string JYM = "10X98765432";
                                M = JYM.Substring(Y, 1);//判断校验位
                                if (M == cardid[17].ToString())
                                {
                                    ErrorStr = Errors[0]; ; //检测ID的校验位
                                }
                                else
                                {
                                    ErrorStr = Errors[3];
                                }
                            }
                            else
                            {
                                ErrorStr = Errors[2];
                            }
                            break;
                        }
                    default:
                        {
                            ErrorStr = Errors[1];
                            break;
                        }
                }
            }
            if (ErrorStr == Errors[0])
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        private bool isSexValid(string s)    //性别验证
        {
            return s == "000" ? false : true;
        }

        public static bool IsNumber(string str)  //是否数字验证
        {
            return Regex.IsMatch(str, @"\b\d+(\.\d+)?\b");
        }

        private bool IsSaveValid()  //保存前验证
        {//验证顺序：画面控件从左到右，从上到下依次验证
            bool IsCheck = true;
            #region 验证
            if (txtSYBH.Text.Trim().IsNullOrEmpty())
            {//打卡编号
                ComForm.DspMsg("W002", Const.CST_SYBHGLY);  //项目不能为空！
                txtSYBH.Focus();
                IsCheck = false;
                return IsCheck;
            }
           
            if (txtName.Text.Trim().IsNullOrEmpty())
            {//社员名
                ComForm.DspMsg("W002", Const.CST_XM);   //项目不能为空！
                txtName.Focus();
                IsCheck = false;
                return IsCheck;
            }

            if (cboSex.Text.Trim().IsNullOrEmpty())
            {//性别
                ComForm.DspMsg("W002", Const.CST_SEX);  //项目不能为空！
                cboSex.Focus();
                IsCheck = false;
                return IsCheck;
            }

            string SFZH = txtSFZH.Text.ToString().Trim();
            if (!txtSFZH.Text.ToString().Trim().IsNullOrEmpty())
            {//身份证号
                if (txtSFZH.Text.ToString().Length >= 15)
                {
                    if (!Validate(txtSFZH.Text.ToString().Trim()) == true)
                    {
                        ComForm.DspMsg("W014", Const.CST_SFID);  //对象项目入力不正确！
                        txtSFZH.Focus();
                        txtSFZH.SelectAll();
                        IsCheck = false;
                        return IsCheck;
                    }
                    else
                    {
                        if (SFZH.Length == 18)
                        {//18位身份证加载生日、性别、年龄
                            txtCSRQ_Y.Text = SFZH.Substring(6, 4);
                            txtCSRQ_M.Text = SFZH.Substring(10, 2);
                            txtCSRQ_D.Text = SFZH.Substring(12, 2);
                            string CSRQ = SFZH.Substring(6, 4) + "/" + SFZH.Substring(10, 2) + "/" + SFZH.Substring(12, 2);
                            txtAge.Text = AGE(CSRQ);
                            if (!isSexValid(SFZH.Substring(14, 3)))
                            {
                                ComForm.DspMsg("W014", Const.CST_SFID);  //对象项目入力不正确！
                                txtSFZH.Focus();
                                IsCheck = false;
                                return IsCheck;
                            }//验证性别

                            else { cboSex.Text = ((Convert.ToInt32(SFZH.Substring(14, 3)) % 2 == 0) ? "女" : "男"); }
                        }
                    }
                }
                else
                {
                    ComForm.DspMsg("W007", "");  //身份证号位数不足！
                    txtSFZH.Focus();
                    txtSFZH.SelectAll();
                    IsCheck = false;
                    return IsCheck;
                }
            }
            if (txtCSRQ_Y.Text.Trim().IsNullOrEmpty() || txtCSRQ_M.Text.Trim().IsNullOrEmpty() || txtCSRQ_D.Text.Trim().IsNullOrEmpty())
            {//出生年月
                ComForm.DspMsg("W002", Const.CST_CSNYR);  //项目不能为空！
                txtCSRQ_Y.Focus();
                IsCheck = false;
                return IsCheck;
            }
            else
            {//生日合法性验证
                string KSRQ = txtCSRQ_Y.Text.ToString().PadLeft(4, '0') + "/" + txtCSRQ_M.Text.ToString().PadLeft(2, '0')
                    + "/" + txtCSRQ_D.Text.ToString().PadLeft(2, '0');
                if (!"0".Equals(PublicFun.ChkDate(txtCSRQ_Y.Text.PadLeft(4, '0'), txtCSRQ_M.Text.PadLeft(2, '0'), txtCSRQ_D.Text.PadLeft(2, '0'))))
                {
                    ComForm.DspMsg("W015", "");  //日期入力不正确！
                    txtCSRQ_Y.Focus();
                    txtCSRQ_Y.SelectAll();
                    IsCheck = false;
                    return IsCheck;
                }
                TimeSpan RQ_YZ = DateTime.Now.Date - Convert.ToDateTime(KSRQ);
                if (RQ_YZ.ToString().Substring(0, 1).Equals("-"))
                {
                    ComForm.DspMsg("W022", "");   //日期不能入力将来日！
                    txtCSRQ_Y.Focus();
                    txtCSRQ_Y.SelectAll();
                    IsCheck = false;
                    return IsCheck;
                }
                txtAge.Text = AGE(KSRQ);
            }
            if (txtAge.Text.Trim().Length > 3)
            {//年龄合法性验证
                ComForm.DspMsg("W014", Const.CST_NL);   //对象项目入力不正确！
                txtAge.Focus();
                txtAge.SelectAll();
                IsCheck = false;
                return IsCheck;
            }
 
            if (!txtEmail.Text.Trim().IsNullOrEmpty())
            {//邮件格式验证
                if (!ComForm.IsEmail(txtEmail.Text.ToString().Trim()))
                {
                    ComForm.DspMsg("W009", txtEmail.Tag.ToString());   //非法的郵箱格式!
                    txtEmail.SelectAll();
                    txtEmail.Focus();
                    IsCheck = false;
                    return IsCheck;
                }
            }
          
           
           
           
          

            DataSet ds = _bllFMD010.GetSYBH(txtSYBH.Text.Trim().PadLeft(5, '0'), "0");
            if (ds.Tables[0].Rows.Count > 0)
            {//删除社员验证
                ComForm.DspMsg("W069", "");   //该社员已被删除！
                txtSYBH.Focus();
                IsCheck = false;
                return IsCheck;
            }
            return IsCheck;
            #endregion
        }

        private bool IsFutureDateValid(string KSRQ, string JSRQ)   //未来日期验证
        {
            bool YZ = false;
            TimeSpan RQ_YZ = Convert.ToDateTime(KSRQ) - Convert.ToDateTime(JSRQ);
            if (!"-".Equals(RQ_YZ.ToString().Substring(0, 1)))
            {
                YZ = true;
            }
            return YZ;
        }
        #endregion
        #region 按钮事件
        private void btnClear_Click(object sender, EventArgs e)  //清空按钮事件
        {
            if ("0".Equals(ComForm.DspMsg("Q002", "")))  //是否要清空数据？
            {
                ClearControl();       //清空所有控件
                txtSYBH.Focus();
            }
            else
            {
                txtSYBH.Focus();
            }
        }
       

        
        private void btnExit_Click(object sender, EventArgs e)  //退出按钮事件
        {
            if (ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            {
                System.GC.Collect();
                DelImage();//删除缓存图片
                this.Close();
            }
            else
            {
                txtSYBH.Focus();
            }
        }

        private void DelImage()    //删除缓存文件
        {
            //查询存储目录是否存在，不存在则创建
            if (!System.IO.Directory.Exists(_savePath))
            {
                System.IO.Directory.CreateDirectory(_savePath);
            }
            File.Delete(_savePath + ComForm.strUserName + ".jpg");
            File.Delete(_savePath + ComForm.strUserName + ".jpeg");
            File.Delete(_savePath + ComForm.strUserName + ".bmp");
            File.Delete(_savePath + ComForm.strUserName + ".png");
        }

        private void btnSave_Click(object sender, EventArgs e)  //保存按钮事件
        {
            if (!IsSaveValid())    //保存前验证是否通过
            {
                return;
            }
            try
            {
                if ("0".Equals(ComForm.DspMsg("Q004", "")))   //是否要保存数据？
                {
                    btnSaveOK();      //保存处理
                    ComForm.DspMsg("M002", "");    //数据保存成功！
                    txtSYBH.Focus();
                }
                else
                {
                    txtSYBH.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", ""); ex.ToString();   //系统出现问题，请与管理员联系！
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void btnSaveOK()    //保存处理
        {
            #region 局部变量定义
            //基本信息
            string strSYBH = string.Empty;                           //打卡编号
            string strSYBHGLY = string.Empty;                        //社员编号管理用
            string strXM = string.Empty;                             //姓名
            string strGB = string.Empty;                             //国别
            string strHZH = string.Empty;                            //护照号
            string strSFZH = string.Empty;                           //身份证号
            string strCSRQ = string.Empty;                           //出生日期
            string strXB = string.Empty;                             //性别
            string strHF = string.Empty;                             //婚否
            string strHKQF = string.Empty;                           //户口区分
            string strMZ = string.Empty;                             //民族
            string strXL = string.Empty;                             //学历
            string strZY = string.Empty;                             //专业
            string strBYXXZGZS = string.Empty;                       //毕业学校证书

            //联络方式
            string strEmail = string.Empty;                          //Email
            string strTEL = string.Empty;                            //电话
            string strSJ = string.Empty;                             //手机
            string strJJLLFS = string.Empty;                         //紧急联络方式
            string strJJLLR = string.Empty;                         //紧急联络人
            string strYBRGX = string.Empty;                         //与本人关系
            string strHJ = string.Empty;                             //户籍
            string strXDZ = string.Empty;                            //现地址

            //公司信息
            string strBMBH = string.Empty;                           //部门
            string strKE = string.Empty;                           //课
            string strXI = string.Empty;                             //系
            string strBanZ = string.Empty;                             //班组
            string strZW = string.Empty;                             //职务
            string strBMDM = string.Empty;                             //部门代码
            string strQWMC = string.Empty;                           //勤务名称
            string strZSTQQF = string.Empty;                         //住宿通勤区分
            string strYGXZ = string.Empty;                           //用工性质
            string strGZZFQF = string.Empty;                         //工资支付区分
            string strHTLB = string.Empty;                           //合同类别
            string strHTBH = string.Empty;                           //合同编号
            string strHTQX = string.Empty;                           //合同期限
            string strGZKH = string.Empty;                           //工资卡号
            string strDABH = string.Empty;                           //档案编号
            string strSBBH = string.Empty;                           //社保编号
            string strGJJBH = string.Empty;                          //公积金账号
            string strRSRQ = string.Empty;                           //入社日期
            string strSYQZ = string.Empty;                           //试用日期
            string strTSRQ = string.Empty;                           //退社日期
            string strTXRQ = string.Empty;                           //退休日期
            string strDSZNFZZRQ = string.Empty;                      //独生子女费终止日
            string strQZGL = string.Empty;                           //前职工龄
            string strBZ = string.Empty;                             //备注

            string strIP = string.Empty;
            string strDK = string.Empty;
            
            #endregion

            #region ComboBox To String
          
            strXB = StaticFun.getValue(cboSex);
           
      
           
            strBMBH = StaticFun.getValue(cboBM);
        
   
            strZW = StaticFun.getValue(cboZW);         
           
            #endregion

            #region Text To String
            strSYBH = txtSYBH.Text.ToString().Trim().PadLeft(5, '0');
           
            strXM = txtName.Text.ToString().Trim();
          
            strSFZH = txtSFZH.Text.ToString().Trim();
            strCSRQ = txtCSRQ_Y.Text.Trim().PadLeft(4, '0') + "/"
                + txtCSRQ_M.Text.Trim().PadLeft(2, '0') + "/"
                + txtCSRQ_D.Text.Trim().PadLeft(2, '0');
        
            strEmail = txtEmail.Text.ToString().Trim();
          
            strSJ = txtSJ.Text.ToString().Trim();
           
          
            strXDZ = txtXDZ.Text.ToString().Trim();



            strIP = StaticFun.getValue(cboIP);
            strDK = StaticFun.getValue(cboDK); 
           
            #endregion

            #region Model赋值
            _modelFMD010.SYBH = strSYBH;                          //打卡编号
            _modelFMD010.SYMC= strXM;                              //姓名
            _modelFMD010.SFZ = strSFZH;                          //身份证号
            _modelFMD010.SR = strCSRQ;                          //生年月日
            _modelFMD010.XB = strXB;                              //性别
         
            _modelFMD010.EMAIL = strEmail;                        //Email
            _modelFMD010.SJH = strSJ;                              //手机

            _modelFMD010.ZZ = strXDZ;                            //现地址

            _modelFMD010.BMBH = strBMBH;                          //部门
            _modelFMD010.ZWBH = strZW;                            //职务
            _modelFMD010.PORTID = strDK;
            _modelFMD010.PRINTERID = strIP;
            _modelFMD010.ZT = "1";
            #endregion
            SaveFMD310(_modelFMD010);  //保存到数据库
        }

        public void SaveFMD310(fmd010 model)  //保存到数据库
        {
            ArrayList al = new ArrayList();
            if (_bllFMD010.Exists(model.SYBH))  //判断社员编号是否存在
            {
                model.GXZBH = ComForm.strUserName;
                model.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                model.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                model.GXDMM = PublicFun.Get_SysDNBH();
                al.Add(_bllFMD010.UpdateSQL(_modelFMD010));//更新FMD310数据
            }
            else
            {
                model.RLZBH = ComForm.strUserName;
                model.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                model.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                model.RLDMM = PublicFun.Get_SysDNBH();
                al.Add(_bllFMD010.AddSQL(_modelFMD010));//插入FMD310数据
            }
            DbHelperMySql.ExecuteSqlTran(al);           
        }
        
        #endregion
        #region 文本框事件
        private void txt_KeyPress(object sender, KeyPressEventArgs e)  //文本框KeyPress事件
        {
            string sBtnName = ((TextBox)(sender)).Name.ToString();
            switch (sBtnName)
            {
                //打卡编号
                case "txtSYBH":
                //社员编号管理用    
                case "txtSYBHGLY":
                // 生日年
                case "txtCSRQ_Y":
                // 月
                case "txtCSRQ_M":
                // 日
                case "txtCSRQ_D":
                // 合同期限年
                case "txtHTQX_Y":
                // 合同期限月
                case "txtHTQX_M":
                // 合同期限日
                case "txtHTQX_D":
                //公积金编号
                case "txtGJJBH":
                //工资卡号
                case "txtGZKH":
                // 入社日期年
                case "txtRSRQ_Y":
                // 入社日期月
                case "txtRSRQ_M":
                // 入社日期日
                case "txtRSRQ_D":
                // 试用期年
                case "txtSYRQ_Y":
                // 试用期月
                case "txtSYRQ_M":
                // 试用期日
                case "txtSYRQ_D":
                // 退社日期年
                case "txtTSRQ_Y":
                // 退社日期月
                case "txtTSRQ_M":
                // 退社日期日
                case "txtTSRQ_D":
                // 退休日期年
                case "txtTXRQ_Y":
                // 退休日期月
                case "txtTXRQ_M":
                // 退休日期日
                case "txtTXRQ_D":
                // 独生子女终止年
                case "txtDSZN_Y":
                // 独生子女终止月
                case "txtDSZN_M":
                // 独生子女终止日
                case "txtDSZN_D":
                //前职工龄
                case "txtQZGL":
                //当前工龄
                case "txtDCGL":
                    // 只允许录入数字
                    ComForm.IsNum(e);
                    break;
                //电话
                case "txtTel":
                //手机
                case "txtSJ":
                //紧急联络方式
                case "txtJJLLFS":
                    //只能录入数字、+、-
                    ComForm.IsTel(e);
                    break;
                //姓名
                case "txtName":
                //Email
                case "txtEmail":
                //户籍
                case "txtHJ":
                //家庭地址
                case "txtXDZ":
                //合同编号
                case "txtHTBH":
                //档案编号
                case "txtDABH":
                //部门代码
                case "txtBMDM":
                //紧急联络人
                case "txtJJLLR":
                //与本人关系
                case "txtYBRGX":
                    //\、‘，’不可录入
                    ComForm.IsWB(e);
                    break;
                //身份证号
                case "txtSFZH":
                //护照号
                case "txtHZH":
                //社保编号
                case "txtSBBH":
                    // 半角英字・数字のみを入力可能とします。
                    ComForm.IsAlphAndNum(e);
                    break;
            }
        }

        private void WinFMD310_KeyDown(object sender, KeyEventArgs e)  //画面KeyDown事件
        {
            //if (e.KeyData == (Keys.Alt | Keys.D))
            //{
            //    btnDelete.Focus();
            //}
            //if (e.KeyData == (Keys.Alt | Keys.W))
            //{
            //    btnSalaryADD.Focus();
            //}
            if (e.KeyData == (Keys.Alt | Keys.C))
            {
                btnClear.Focus();
            }
            if (e.KeyData == (Keys.Alt | Keys.S))
            {
                btnSave.Focus();
            }
            if (e.KeyData == (Keys.Alt | Keys.Q))
            {
                btnExit.Focus();
            }
            //if (e.KeyData == (Keys.Alt | Keys.U))
            //{
            //    btnAppendImage.Focus();
            //}
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
        }

        /// <summary>
        /// 文本框 KeyPress 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Enter(object sender, EventArgs e)    //文本框Enter事件
        {
            ((TextBox)(sender)).SelectAll();
        }

        private void txtSYBH_TextChanged(object sender, EventArgs e)    //社员编号改变事件
        {
            //if (btnDelete.Focused)
            //{ return; }
            if (btnClear.Focused)
            { return; }
            if (btnExit.Focused)
            { return; }
            //if (btnAppendImage.Focused)
            //{ return; }
            LoadFormData();  //画面数据加载
        }

        private void txtSYBH_Validating(object sender, CancelEventArgs e)   //社员编号验证事件
        {
            //if (btnDelete.Focused)
            //{ return; }
            if (btnClear.Focused)
            { return; }
            if (btnExit.Focused)
            { return; }
            //if (btnAppendImage.Focused)
            //{ return; }
            if (this.txtSYBH.Text != "")
            {
                this.txtSYBH.Text = this.txtSYBH.Text.PadLeft(5, '0');
                //LoadFormData();  //画面数据加载
            }
        }

        private void txtName_Leave(object sender, EventArgs e)   //社员名称离开事件
        {
            if (this.txtName.Text != null)
            {
                string str = GetPYString(txtName.Text.Trim().Replace(" ", ""));
            }
        }

        public string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {
                    tempStr += c.ToString();
                }
                else
                {
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        public string GetPYChar(string c)
        {
            byte[] array = new byte[2];

            array = System.Text.Encoding.UTF8.GetBytes(c);

            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return "*";

            if (i < 0xB0C5) return "a";

            if (i < 0xB2C1) return "b";

            if (i < 0xB4EE) return "c";

            if (i < 0xB6EA) return "d";

            if (i < 0xB7A2) return "e";

            if (i < 0xB8C1) return "f";

            if (i < 0xB9FE) return "g";

            if (i < 0xBBF7) return "h";

            if (i < 0xBFA6) return "j";

            if (i < 0xC0AC) return "k";

            if (i < 0xC2E8) return "l";

            if (i < 0xC4C3) return "m";

            if (i < 0xC5B6) return "n";

            if (i < 0xC5BE) return "o";

            if (i < 0xC6DA) return "p";

            if (i < 0xC8BB) return "q";

            if (i < 0xC8F6) return "r";

            if (i < 0xCBFA) return "s";

            if (i < 0xCDDA) return "t";

            if (i < 0xCEF4) return "w";

            if (i < 0xD1B9) return "x";

            if (i < 0xD4D1) return "y";

            if (i < 0xD7FA) return "z";
            return "*";

        }

        private void txtSFZH_Validating(object sender, CancelEventArgs e)  //身份证号验证事件
        {
            string RQ = txtSFZH.Text.ToString().Trim();
         
            if (btnClear.Focused)
            { return; }
            if (btnExit.Focused)
            { return; }
            

            if (txtSFZH.Text.ToString().Trim() != "")
            {
                if (txtSFZH.Text.ToString().Length >= 15)
                {
                    if (!Validate(txtSFZH.Text.ToString().Trim()) == true)
                    {//验证不通过
                        ComForm.DspMsg("W014", ComConst.CST_SFID);  //对象项目入力不正确！
                        txtSFZH.Focus();
                        txtSFZH.SelectAll();
                    }
                    else
                    {
                        if (RQ.Length == 18)
                        {//验证通过后，给生日、年龄、性别、距离退休年限赋值
                            txtCSRQ_Y.Text = RQ.Substring(6, 4);
                            txtCSRQ_M.Text = RQ.Substring(10, 2);
                            txtCSRQ_D.Text = RQ.Substring(12, 2);
                            string CSRQ = RQ.Substring(6, 4) + "/" + RQ.Substring(10, 2) + "/" + RQ.Substring(12, 2);
                            txtAge.Text = AGE(CSRQ);
                            if (!isSexValid(RQ.Substring(14, 3)))
                            {
                                return;
                            }//验证性别
                            else
                            {
                                cboSex.Text = ((Convert.ToInt32(RQ.Substring(14, 3)) % 2 == 0) ? "女" : "男");
                            }
                        }
                    }
                }
                else
                {
                    ComForm.DspMsg("W007", "");  //身份证号位数不足！
                    txtSFZH.Focus();
                    txtSFZH.SelectAll();
                }
            }
        }

        private void Date_Validating(object sender, CancelEventArgs e)    //日期验证事件
        {
            
            if (btnClear.Focused)
            { return; }
            if (btnExit.Focused)
            { return; }
           
            string sBtnName = ((TextBox)(sender)).Name.ToString();
            string KSRQ = string.Empty;
          //  string JSRQ = txtRSRQ_Y.Text.Trim().PadLeft(4, '0') + "/" + txtRSRQ_M.Text.Trim().PadLeft(2, '0') + "/" + txtRSRQ_D.Text.Trim().PadLeft(2, '0');
            switch (sBtnName)
            {
                // 生日年
                case "txtCSRQ_Y":
                // 入社日期年
                case "txtRSRQ_Y":
                // 试用期年
                case "txtSYRQ_Y":
                // 退社日期年
                case "txtTSRQ_Y":
                // 合同期限年
                case "txtHTQX_Y":
                // 退休日期年
                case "txtTXRQ_Y":
                // 独生子女终止年
                case "txtDSZN_Y":
                    if (((TextBox)(sender)).Text == "")
                    {
                        return;
                    }
                    ((TextBox)(sender)).Text = ((TextBox)(sender)).Text.Trim().PadLeft(4, '0');
                    break;
                // 生日月
                case "txtCSRQ_M":
                // 入社日期月
                case "txtRSRQ_M":
                // 试用期月
                case "txtSYRQ_M":
                // 退社日期月
                case "txtTSRQ_M":
                // 合同期限月
                case "txtHTQX_M":
                // 退休日期月
                case "txtTXRQ_M":
                // 独生子女终止月
                case "txtDSZN_M":
                    if (((TextBox)(sender)).Text == "")
                    {
                        return;
                    }
                    ((TextBox)(sender)).Text = ((TextBox)(sender)).Text.Trim().PadLeft(2, '0');
                    break;
                // 生日日
                case "txtCSRQ_D":
                    if (txtCSRQ_Y.Text.Trim().IsNullOrEmpty() && txtCSRQ_M.Text.Trim().IsNullOrEmpty() && txtCSRQ_D.Text.Trim().IsNullOrEmpty())
                    {
                    }
                    else
                    {
                        ((TextBox)(sender)).Text = ((TextBox)(sender)).Text.Trim().PadLeft(2, '0');
                        KSRQ = txtCSRQ_Y.Text.ToString().PadLeft(4, '0') + "/" + txtCSRQ_M.Text.ToString().PadLeft(2, '0')
                        + "/" + txtCSRQ_D.Text.ToString().PadLeft(2, '0');
                        if (!"0".Equals(PublicFun.ChkDate(txtCSRQ_Y.Text.PadLeft(4, '0'), txtCSRQ_M.Text.PadLeft(2, '0'), txtCSRQ_D.Text.PadLeft(2, '0'))))
                        {
                            ComForm.DspMsg("W015", "");  //日期入力不正确！
                            txtCSRQ_Y.Focus();
                            txtCSRQ_Y.SelectAll();
                            return;
                        }
                        TimeSpan RQ_YZ = DateTime.Now.Date - Convert.ToDateTime(KSRQ);
                        if (RQ_YZ.ToString().Substring(0, 1).Equals("-"))
                        {
                            ComForm.DspMsg("W022", "");   //日期不能入力将来日！
                            txtCSRQ_Y.Focus();
                            txtCSRQ_Y.SelectAll();
                            return;
                        }
                        txtAge.Text = AGE(KSRQ);
                    }
                    break;               
                
            }
            if (btnClear.Focused || btnExit.Focused)
            {
                return;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)  //Email验证事件
        {
           
            if (btnClear.Focused)
            { return; }
            if (btnExit.Focused)
            { return; }
           
            if (!txtEmail.Text.Trim().IsNullOrEmpty())
            {
                if (!ComForm.IsEmail(txtEmail.Text.ToString().Trim()))
                {
                    ComForm.DspMsg("W009", txtEmail.Tag.ToString());   //非法的郵箱格式!
                    txtEmail.SelectAll();
                    txtEmail.Focus();
                    return;
                }
            }
        }
        #endregion

        private void cboBM_Validated(object sender, EventArgs e)
        {
            //if (cboBM.getValue().Equals("002"))
            //{
            //    cboIP.Text = _bllFmd000.getZSMC("12","001");


            //    cboDK.Text = _bllFmd000.getZSMC("13", "001");
            //}
            //else if (cboBM.getValue().Equals("003"))
            //{
            //    cboIP.Text = _bllFmd000.getZSMC("12", "002");


            //    cboDK.Text = _bllFmd000.getZSMC("13", "002");
            //}
            //else if (cboBM.getValue().Equals("004"))
            //{
            //    cboIP.Text = _bllFmd000.getZSMC("12", "003");


            //    cboDK.Text = _bllFmd000.getZSMC("13", "004");
            //}
            //else
            //{
            //    cboDK.Text = cboIP.Text = "";
            //}

        }

        private void cboBM_TextChanged(object sender, EventArgs e)
        {
            if (cboBM.getValue().Equals("002"))
            {
                cboIP.Text = _bllFmd000.getZSMC("12", "001");


                cboDK.Text = _bllFmd000.getZSMC("13", "001");
            }
            else if (cboBM.getValue().Equals("003"))
            {
                cboIP.Text = _bllFmd000.getZSMC("12", "002");


                cboDK.Text = _bllFmd000.getZSMC("13", "002");
            }
            else if (cboBM.getValue().Equals("004"))
            {
                cboIP.Text = _bllFmd000.getZSMC("12", "003");


                cboDK.Text = _bllFmd000.getZSMC("13", "004");
            }
            else
            {
                cboDK.Text = cboIP.Text = "";
            }
        }

       
    }
}
