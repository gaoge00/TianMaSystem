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
    public partial class PC13_sub : Form
    {
        public PC13_sub()
        {
            InitializeComponent();
        }

        #region 变量定义
        public string _currentPath = System.Threading.Thread.GetDomain().BaseDirectory;  //获取当前路径
        string _savePath = "D:\\JTEKT_Salary\\缓存图片\\";                                  //图片缓存路径
       // BLL.FMD020 _bllFMD020 = new BLL.FMD020();
        Model.fmd050 _modelFMD040 = new Model.fmd050();
        BLL.fmd000 _bllFmd000 =new BLL.fmd000();
        BLL.fmd050 _bllFMD040 = new BLL.fmd050();
        BLL.fed010 _bllfed010 = new BLL.fed010();
        BLL.fed020 _bllfed020 = new BLL.fed020();
        BLL.fmd040 _bllFMD040_040 = new BLL.fmd040();
        public string _wholePath = null;                 //最终路径
        public string _conCLBH = string.Empty;
        public string _conYCLLX = string.Empty;
        public string _conZT = string.Empty;
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
            BindcboYCLLX();        //性别Combobox绑定           
            LoadFormData(); //画面数据加载

            if (!"".Equals(_conCLBH)) //如果社员编号有值，加载社员信息，否则清空控件
            {
                //txtCLBH.Text = _conPM;
                txtYCLBH.Text = _conCLBH;
                //txtYXQ.Text = _conCLBH;


               // txtCLBH.ReadOnly =
                    txtYCLBH.ReadOnly=
                 //   txtYXQ.ReadOnly=
                    
                    true;              
                txtYCLBH.Focus();
            }
            else
            {
                ClearEmptyExceptSYBH();  //除社员编号以外的画面控件清空
                txtYCLBH.Focus();
            }

      
        }

        #region ComboxBind
        private void BindcboYCLLX()   //部门Combobox绑定
        {

            DataTable dtJLDW = new DataTable();
            dtJLDW = _bllFmd000.GetFMD030MC_KEY("06");
            PublicFun.comboxBind(cboJLDW, dtJLDW, 0);
            if (dtJLDW.Rows.Count > 0)
            {
                cboJLDW.SelectedIndex = 1;
            }

            DataTable dt = new DataTable();// 原材料类型
            dt = _bllFmd000.GetFMD030MC_KEY("03");
            PublicFun.comboxBind(cboYCLLX, dt, 0);

            DataTable dtJY = new DataTable();// 检验
            dtJY = _bllFmd000.GetFMD030MC_KEY("08");
            PublicFun.comboxBind(cboJY, dtJY, 0);
            if (dtJY.Rows.Count > 0)
            {
                cboJY.SelectedIndex = 1;
            }
            
        }

    

       
        #endregion

        private void LoadFormData()  //画面数据加载
        {
            try
            {
               // _modelFMD040.YCLLX = _conCLBH;
                _modelFMD040.CLBH = _conCLBH;

                //_modelFMD040.ZT = "";

                DataTable ds = _bllFMD040.GetDaTaForPC08Spread("", _modelFMD040.CLBH, "");     
                if (ds.Rows.Count > 0)
                {
                   
                        ClearEmptyExceptSYBH();     //除社员编号以外的画面控件清空
                        LoadControlData(ds);        //画面控件数据加载                    
                }
                else
                {
                    ClearEmptyExceptSYBH();         //除社员编号以外的画面控件清空
                }
                ds.Clear();

                dateRKRQ.Text = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);

                dateStartRq.Text =DateTime.Parse(PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D)).AddMonths(1).ToString();
                System.GC.Collect();
            }
            catch (Exception e)
            {
                ComForm.DspMsg("E016", "");   //数据加载失败！
                ComForm.InsertErrLog(e.ToString(), this.Name);
            }
        }

        private void LoadControlData(DataTable ds)  //画面控件数据加载
        {
            try
            {
                #region 控件赋值

                //// txtCLBH.Text = ds.Rows[0]["YCLBHGHS"].ToString();                          
                //txtYCLBH.Text = ds.Rows[0]["CLBH"].ToString();
                ////cboCLBH.Text = ds.Rows[0]["CLBH"].ToString();

                ////cboYCLLX.Text = ds.Rows[0]["YCLLX"].ToString();             


                //txtZKSL.Text = ds.Rows[0]["ZXKC"].ToString();
                //txtZDKC.Text = ds.Rows[0]["ZDKC"].ToString();
                //txtBZ.Text = ds.Rows[0]["MS"].ToString();
                //txtYCLJJ.Text = ds.Rows[0]["JJ"].ToString();
                //txtYXQ.Text = ds.Rows[0]["YXTS"].ToString();
                //cboJLDW.Text = ds.Rows[0]["JLDW"].ToString();
                //cboYCLBH.Text = ds.Rows[0]["YCLBHBS"].ToString();
                //txtYCLBH.Focus();

       

                #endregion
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

       

       

 

     

        private void ClearEmptyExceptSYBH()  //除社员编号以外的画面控件清空
        {
            #region 控件赋值
            //基本信息
            txtYCLBH.Text = string.Empty;     //品号

            txtYCLBH.Text = string.Empty;//品名
          // // cboCLBH.Text =//材料类别
          ////  cboYCLLX.Text =//计量单位
          //      // cboFLH.Text =//分类号
          //  txtZKSL.Text =//最小库存
          //  txtZDKC.Text =//最大库存
          //  txtBZ.Text =//产品描述
          //  txtYXQ.Text = 
          //  txtYCLJJ.Text=
          //  cboYCLBH.Text=
          //  cboJLDW.Text=
           // txtXDSLBZ.Text =//小袋数量 标准
           // txtDDSLBZ.Text =// 大袋数量标准
           // txtXSLBZ.Text =//箱数量 标准
           // txtZXBZ.Text =//装箱备注
           // cboXQF.Text =
           //string.Empty; //箱区分
           
            #endregion          
        }

        public void ClearControl()  //清空所有控件
        {
            txtYCLBH.Text = string.Empty;
            ClearEmptyExceptSYBH(); //除社员编号以外的画面控件清空
        }
        #endregion
        #region 验证事件
        

     

        public static bool IsNumber(string str)  //是否数字验证
        {
            return Regex.IsMatch(str, @"\b\d+(\.\d+)?\b");
        }

        private bool IsSaveValid()  //保存前验证
        {//验证顺序：画面控件从左到右，从上到下依次验证
            bool IsCheck = true;
            #region 验证
            //if (txtCLBH.Text.Trim().IsNullOrEmpty())
            //{//品名
            //    ComForm.DspMsg("W002", "品名");  //项目不能为空！
            //    txtCLBH.Focus();
            //    IsCheck = false;
            //    return IsCheck;
            //}

            double dbzksl = 0;
            double.TryParse(txtZKSL.Text.Trim(), out dbzksl);

            if (txtZKSL.Text.Trim().IsNullOrEmpty()==true|| dbzksl==0)            
            {
                MessageBox.Show("此项目必须录入且不能为零！","", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                IsCheck = false;
                return IsCheck;
            }

            if (txtYCLRKLOTNO.Text.Trim().IsNullOrEmpty())
            {//品号
                ComForm.DspMsg("W002", "原材料入库单号");   //项目不能为空！
                txtYCLBH.Focus();
                IsCheck = false;
                return IsCheck;
            }
           
          
           
            //if (txtYXQ.Text.Trim().IsNullOrEmpty())
            //{//材料编号
            //    ComForm.DspMsg("W002", "有效期");  //项目不能为空！
            //    txtYXQ.Focus();
            //    IsCheck = false;
            //    return IsCheck;
            //}
          

            
            return IsCheck;
            #endregion
        }

      
        #endregion
        #region 按钮事件
        private void btnClear_Click(object sender, EventArgs e)  //清空按钮事件
        {
            if ("0".Equals(ComForm.DspMsg("Q002", "")))  //是否要清空数据？
            {
                ClearControl();       //清空所有控件
                txtYCLBH.Focus();
            }
            else
            {
                txtYCLBH.Focus();
            }
        }
       

        
        private void btnExit_Click(object sender, EventArgs e)  //退出按钮事件
        {
            if (ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            {
                System.GC.Collect();               
                this.Close();
            }
            else
            {
                txtYCLBH.Focus();
            }
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
                   // ComForm.DspMsg("M002", "");    //数据保存成功！
                    txtYCLBH.Focus();
                }
                else
                {
                    txtYCLBH.Focus();
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


            string YCLBH = string.Empty;
            string YCLRKLOTNO = string.Empty;          
            string SYQX = string.Empty;
            
            string BZ = string.Empty;
            
            double ZKSL = 0;

          

            #region Text To String           

            double.TryParse(txtZKSL.Text.ToString().Trim(), out ZKSL);
              //decimal.TryParse(txtZDKC.Text.ToString().Trim(), out ZDKC);

             //int.TryParse(txtYXQ.Text.ToString().Trim(), out YXTS);

            YCLBH= txtYCLBH.Text.Trim();
            YCLRKLOTNO = txtYCLRKLOTNO .Text.Trim();
            SYQX =  dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);           
            BZ= txtBZ.Text.Trim();
            #endregion

            #region Model赋值
            Model.fed030 modelfmd030 = new Model.fed030();
            
            modelfmd030.YCLRKLOTNO = YCLRKLOTNO;
            modelfmd030.YCLBH = YCLBH;
            modelfmd030.DW = cboJLDW.getValue();// "001";

            if (modelfmd030.DW == "001")
            {

                modelfmd030.ZKSL = ZKSL* 1000;
                modelfmd030.DW = "002";

            }
            else
            {
                modelfmd030.ZKSL = ZKSL;
            }
            modelfmd030.SYQX = SYQX;
            modelfmd030.ZXPDRQ = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D); 
            modelfmd030.CKQF = "1";

            modelfmd030.GXZBH = ComForm.strUserName;
            modelfmd030.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfmd030.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfmd030.GXDMM = PublicFun.Get_SysDNBH();


          
       

     
            Model.fed040 modelfed040 = new Model.fed040();
            double SPSL = 0;
            #region model 赋值

           // if (string.IsNullOrEmpty(fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim()) == false)
            //{
            modelfed040.PDRQ = modelfmd030.ZXPDRQ;
                //dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //}

            modelfed040.YCLRKLOTNO = YCLRKLOTNO;
            modelfed040.YCLBH =YCLBH;

            modelfed040.DW = modelfmd030.DW;         
             modelfed040.SYQX = SYQX;

          
            modelfed040.ZKSL = modelfmd030.ZKSL;
            
            
         
            modelfed040.BZ = BZ;
            modelfed040.PDRNO = ComForm.strUserName; 


            modelfed040.GXZBH = ComForm.strUserName;
            modelfed040.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed040.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed040.GXDMM = PublicFun.Get_SysDNBH();


            modelfed040.RLZBH = ComForm.strUserName;
            modelfed040.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed040.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed040.RLDMM = PublicFun.Get_SysDNBH();



            Model.fed010 modelfed010 = new Model.fed010();


            modelfed010.RKRQ = dateRKRQ.Value.ToString("yyyy/MM/dd");
            modelfed010.YCLBH = txtYCLBH.Text.Trim().strReplace();
            modelfed010.YCLRKLOTNO = txtYCLRKLOTNO.Text.Trim().strReplace();
            modelfed010.YCLLX = cboYCLLX.getValue();
            modelfed010.DW = modelfmd030.DW; 
            modelfed010.RKSL = modelfed040.ZKSL;
            modelfed010.SYQX = SYQX;
            modelfed010.JY = cboJY.getValue();
            //modelfed010.CCPM = "1";
            //modelfed010.CCLOTNO = "1";
            //modelfed010.CCGHS = "1";
            modelfed010.CCYXQ = SYQX;
            modelfed010.BZ = BZ;
            modelfed010.ZF = zf;
            modelfed010.DMQF = "2";



            modelfed010.GXZBH = ComForm.strUserName;
            modelfed010.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed010.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed010.GXDMM = PublicFun.Get_SysDNBH();
            modelfed010.RLZBH = ComForm.strUserName;
            modelfed010.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed010.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed010.RLDMM = PublicFun.Get_SysDNBH();


            
            Model.fed020 modelfed020 = new Model.fed020();


            modelfed020.YCLRKLOTNO = txtYCLRKLOTNO.Text.Trim().strReplace();
            modelfed020.YCLBH = txtYCLBH.Text.Trim().strReplace();
            modelfed020.XSQF = "1";
            modelfed020.DMQF = "2";
            modelfed020.GXZBH = ComForm.strUserName;
            modelfed020.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed020.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed020.GXDMM = PublicFun.Get_SysDNBH();
            modelfed020.RLZBH = ComForm.strUserName;
            modelfed020.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed020.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed020.RLDMM = PublicFun.Get_SysDNBH();
            #endregion
       
                 
            #endregion
            SaveFMD310(modelfed040,modelfmd030,modelfed010,modelfed020);  //保存到数据库
        }
        BLL.fed030 _bllfed030 = new BLL.fed030();

        BLL.fed040 _bllfed040 = new BLL.fed040();
        public void SaveFMD310(fed040 modelfed040 ,fed030 modelfed030,fed010 modelfed010,fed020 modelfed020)  //保存到数据库
        {
            try
            {
                ArrayList al = new ArrayList();

                al.Add(_bllfed040.Add_SQL(modelfed040));
                al.Add(_bllfed030.Add_SQL(modelfed030));
                al.Add(_bllfed020.Add_SQL(modelfed020));
                al.Add(_bllfed010.Add_SQL(modelfed010));
                DbHelperMySql.ExecuteSqlTran(al);
                ComForm.DspMsg("M002", "");
                this.Close();
            }
            catch (Exception ex)
            {
                 ComForm.DspMsg("E013", "");   
                 ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
        
        #endregion
        #region 文本框事件
        private void txt_KeyPress(object sender, KeyPressEventArgs e)  //文本框KeyPress事件
        {
            string sBtnName = ((TextBox)(sender)).Name.ToString();
            switch (sBtnName)
            {
                    
                //打卡编号


                case "txtYXQ":
                //社员编号管理用    
                case "txtDDSLBZ":

                case "txtZXKC":
                case "txtZDKC":
                case "txtXSLBZ":
               
                // 合同期限年
            
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
                    
                //产品描述
                case "txtCPMS":
                //装箱备注
                case "txtZXBZ":                    
                 
                    ComForm.IsWB(e);
                    break;
                    
                //材料编号
                case "txtCLBH":
                //护照号
                case "txtPH":
                //社保编号
                case "txtPM":
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
            //if (e.KeyData == (Keys.Alt | Keys.C))
            //{
            //    btnClear.Focus();
            //}
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
            //if (btnClear.Focused)
            //{ return; }
            if (btnExit.Focused)
            { return; }
            //if (btnAppendImage.Focused)
            //{ return; }
          //  LoadFormData();  //画面数据加载
        }

        private void txtSYBH_Validating(object sender, CancelEventArgs e)   //社员编号验证事件
        {
            //if (btnDelete.Focused)
            //{ return; }
            //if (btnClear.Focused)
            //{ return; }
            if (btnExit.Focused)
            { return; }
            //if (btnAppendImage.Focused)
            //{ return; }
            //if (this.txtPM.Text != "")
            //{
            //    this.txtPM.Text = this.txtPM.Text.PadLeft(5, '0');
            //    //LoadFormData();  //画面数据加载
            //}
        }

        private void txtName_Leave(object sender, EventArgs e)   //社员名称离开事件
        {
            if (this.txtYCLBH.Text != null)
            {
                string str = _bllFMD040_040.Get_YCLLX(txtYCLBH.Text.Trim().strReplace());
                if (str.IsNullOrEmpty() == false)
                {
                    cboYCLLX.Text = str;
                }
                else
                {
                    cboYCLLX.Text = "";
                }
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
          //  string RQ = txtZXKC.Text.ToString().Trim();


            //if( IsNumber(txtZXKC.Text.Trim())==true)
            //{

            //}
            //else
            //{
            //    ComForm.DspMsg("W014", "");
            //    txtZXKC.Focus();
            //}
         
            ////if (btnClear.Focused)
            ////{ return; }
            //if (btnExit.Focused)
            //{ return; }
            

            //if (txtZXKC.Text.ToString().Trim() != "")
            //{
            //    if (txtZXKC.Text.ToString().Length >= 15)
            //    {
                  
            //    }
            //    else
            //    {
            //        ComForm.DspMsg("W007", "");  //身份证号位数不足！
            //        txtZXKC.Focus();
            //        txtZXKC.SelectAll();
            //    }
            //}
        }
        private void txtZDKC_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtZKSL.Text.Trim()) == false)
            {
                if (IsNumber(txtZKSL.Text.Trim()) == true)
                {

                }
                else
                {
                    ComForm.DspMsg("W014", "");
                    txtZKSL.Focus();
                }
            }
        }

        private void Date_Validating(object sender, CancelEventArgs e)    //日期验证事件
        {
            
            //if (btnClear.Focused)
            //{ return; }
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
            }
            if (btnExit.Focused)
            {
                return;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)  //Email验证事件
        {
           
            //if (btnClear.Focused)
            //{ return; }
            if (btnExit.Focused)
            { return; }                      
        }
        #endregion
      
        string zf = string.Empty;
        private void btnRKDHZC_Click(object sender, EventArgs e)
        {
            if (txtYCLBH.Text.IsNullOrEmpty() == false && cboYCLLX.getValue().IsNullOrEmpty() == false)
            {            
                string str = _bllFMD040_040.Get_YCLLX(txtYCLBH.Text.Trim().strReplace());
                if (str.IsNullOrEmpty() == true)
                {
                    MessageBox.Show("原材料编号不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtYCLBH.Focus();
                }
                else
                {
                    string qz = string.Empty;   //前缀
                    switch (cboYCLLX.getValue())
                    {
                        case "001":
                            qz = "ZL_";
                            break;
                        case "002":
                            qz = "FL_";
                            break;
                        case "003":
                            qz = "BL_";
                            break;
                    }
                    zf = _bllfed010.GetMaxZF(dateRKRQ.Value.ToString("yyyy/MM/dd"), txtYCLBH.Text.Trim());
                    string YCLRKDH = qz + txtYCLBH.Text.Trim() + "_" + dateRKRQ.Value.ToString("yyMMdd") + "_" + zf;
                    txtYCLRKLOTNO.Text = YCLRKDH;
                }
            }
            else
            {

                txtYCLRKLOTNO.Text = string.Empty;
            }

        }

       
    }
}
