﻿using System;
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
    public partial class PC29_sub : Form
    {
        public PC29_sub()
        {
            InitializeComponent();
        }

        #region 变量定义
        public string _currentPath = System.Threading.Thread.GetDomain().BaseDirectory;  //获取当前路径
        string _savePath = "D:\\JTEKT_Salary\\缓存图片\\";                                  //图片缓存路径
       // BLL.FMD020 _bllFMD020 = new BLL.FMD020();
        Model.ffd090 _modelFFD090 = new Model.ffd090();
        BLL.fmd000 _bllFmd000 =new BLL.fmd000();
        BLL.fmd060 _bllFMD010 = new BLL.fmd060();
        BLL.fmd010 _bllFMD010_NAME = new BLL.fmd010();
        BLL.ffd090 _bllFFD090 = new BLL.ffd090();
        public string _wholePath = null;                 //最终路径
        public string _conPM = string.Empty;
        public string _conPH = string.Empty;
        public string _conCLBH = string.Empty;
        public string _conFPRQ = string.Empty;
        public string _conKHBH = string.Empty;
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
           if (!"".Equals(_conPM)) //如果社员编号有值，加载社员信息，否则清空控件
            {
                txtPM.Text = _conPM;
                txtPH.Text = _conPH;
                txtCLBH.Text = _conCLBH;
                dateFPRq.Value = DateTime.Parse(_conFPRQ);
                txtKHBH.Text = _conKHBH;


                txtPM.ReadOnly =
                    txtPH.ReadOnly=
                    txtCLBH.ReadOnly=
                    txtKHBH.ReadOnly=
                    true;
                dateFPRq.Enabled = false;
                btnKHBH.Visible = false;
                LoadFormData(); //画面数据加载
                txtPH.Focus();
            }
            else
            {
                ClearEmptyExceptSYBH();  //除社员编号以外的画面控件清空
                txtPM.Focus();
            }

      
        }

        #region ComboxBind
        //private void BindcboXQF()   //部门Combobox绑定
        //{
        //    DataTable dt = new DataTable();
        //    dt = _bllFmd000.GetFMD030MC_KEY("10");
        //    PublicFun.comboxBind(cboXQF, dt, 0);
        //}

        //private void BindcboFLH()       //职务Combobox绑定
        //{
        //    DataTable dt = new DataTable();
        //    dt = _bllFmd000.GetFMD030MC_KEY("05");
        //    PublicFun.comboxBind(cboFLH, dt, 0);
        //}
      

        //private void BindcboJLDW()       //计量单位
        //{
        //    DataTable dt = new DataTable();
        //    dt = _bllFmd000.GetFMD030MC_KEY("06");
        //    PublicFun.comboxBind(cboJLDW, dt, 0);
        //}

       
        #endregion

        private void LoadFormData()  //画面数据加载
        {
            try
            {
                _modelFFD090=new ffd090();
                _modelFFD090.PM = txtPM.Text;
                _modelFFD090.PH = txtPH.Text;

                _modelFFD090.CLBH = txtCLBH.Text;
                _modelFFD090.FPRQ = dateFPRq.Value.ToString("yyyy/MM/dd");
                _modelFFD090.KHBH = txtKHBH.Text.Trim();

                DataTable ds = _bllFFD090.GetDataFrom(_modelFFD090.FPRQ,
                _modelFFD090.PM, _modelFFD090.PH, _modelFFD090.CLBH, _modelFFD090.KHBH);     
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

                //txtPM.Text = ds.Rows[0]["PM"].ToString();
                //txtPH.Text = ds.Rows[0]["PH"].ToString();
                //txtCLBH.Text = ds.Rows[0]["CLBH"].ToString();



                txtPM.Text = _conPM;
                txtPH.Text = _conPH;
                txtCLBH.Text = _conCLBH;
                dateFPRq.Value = DateTime.Parse(_conFPRQ);
                txtKHBH.Text = _conKHBH;

                txtFPZ.Text=ds.Rows[0]["FPZBH"].ToString();

                txtKHMC.Text=ds.Rows[0]["KHMC"].ToString();
                txtFPZMC.Text = ds.Rows[0]["SYMC"].ToString();


                txtFPSL.Text=ds.Rows[0]["FPSL"].ToString();
               

                txtBZ.Text = ds.Rows[0]["BZ"].ToString();



                txtFPSL.Focus();
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
            txtPH.Text = string.Empty;     //品号

            txtPM.Text = string.Empty;//品名
            txtCLBH.Text = string.Empty;//材料类别
           dateFPRq.Value = DateTime.Parse(PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D));

           txtKHBH.Text=
               txtKHMC.Text=
               txtFPZ.Text=
               txtFPZMC.Text=
               txtFPSL.Text=
               txtBZ.Text=
               string.Empty; //箱区分
           
            #endregion          
        }

        public void ClearControl()  //清空所有控件
        {
            txtPM.Text = string.Empty;
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
            if (txtPM.Text.Trim().IsNullOrEmpty())
            {//品名
                ComForm.DspMsg("W002", "品名");  //项目不能为空！
                txtPM.Focus();
                IsCheck = false;
                return IsCheck;
            }
           
            if (txtPH.Text.Trim().IsNullOrEmpty())
            {//品号
                ComForm.DspMsg("W002","品号");   //项目不能为空！
                txtPH.Focus();
                IsCheck = false;
                return IsCheck;
            }
           
          
           
            if (txtCLBH.Text.Trim().IsNullOrEmpty())
            {//材料编号
                ComForm.DspMsg("W002", "材料编号");  //项目不能为空！
                txtCLBH.Focus();
                IsCheck = false;
                return IsCheck;
            }
            if (txtKHMC.Text.Trim().IsNullOrEmpty())
            {//材料编号
                ComForm.DspMsg("W002", "客户编号");  //项目不能为空！
                btnKHBH.Focus();
                IsCheck = false;
                return IsCheck;
            }
            else
            {
 
            }
            //数据库中 不存在 录入的品名 品号 材料
            if (_bllFMD010.ExistsEVE(txtPM.Text.Trim(), txtPH.Text.Trim(), txtCLBH.Text.Trim())==false)
            {
                ComForm.DspMsg("W014", "品名、品号或材料录入不正确");  //项目不能为空！
                txtPM.Focus();
                IsCheck = false;
                return IsCheck;
            }
            //if (cboXQF.Text.Trim() == "小袋到箱")
            //{ 
            //    int a = 0;
            //    int.TryParse(txtDDSLBZ.Text,out a);
            //    if(txtDDSLBZ.Text.Trim() != "" &&  a > 0)
            //    {
            //        MessageBox.Show("当小袋到箱时，【每大袋装小袋数】必须为空值！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        txtDDSLBZ.Focus();
            //        IsCheck = false;
            //        return IsCheck; 
            //    }

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
                txtPM.Focus();
            }
            else
            {
                txtPM.Focus();
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
                txtPM.Focus();
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
                    ComForm.DspMsg("M002", "");    //数据保存成功！
                   // this.Close();
                    txtPM.Focus();
                }
                else
                {
                    txtPM.Focus();
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

            string FPRQ = string.Empty;
           string  PM =string.Empty;
           string PH = string.Empty;
           string CLBH = string.Empty;
           string JLDW = string.Empty;
           string FLH = string.Empty;
           int FPSL = 0;
           decimal ZDKC = 0;
           string CPMS = string.Empty;
           int XDSLBZ = 0;
           int DDSLBZ = 0;
           string XQF = string.Empty;
           int XSLBZ = 0;
           string ZXBZ = string.Empty;

           string KHBH = string.Empty;
           string FPZ = string.Empty;

            

            #region ComboBox To String 

            FPRQ=  dateFPRq.Value.ToString("yyyy/MM/dd");

            
            PM = txtPM.Text.ToString().Trim().strReplace();//.PadLeft(5, '0');

            PH = txtPH.Text.ToString().Trim().strReplace();

            CLBH = txtCLBH.Text.ToString().Trim();
   
            //JLDW= StaticFun.getValue(cboJLDW);  
  
            //FLH = StaticFun.getValue(cboFLH);
            KHBH = txtKHBH.Text;

            FPZ = string.IsNullOrEmpty(txtFPZMC.Text.Trim())? "" : txtFPZ.Text;
            #endregion

            #region Text To String           

            int.TryParse(txtFPSL.Text.ToString().Trim(), out FPSL);
          //  decimal.TryParse(txtZDKC.Text.ToString().Trim(), out ZDKC);



         //   CPMS = txtCPMS.Text.ToString().Trim();

            //int.TryParse(txtFPSL.Text.Trim(), out XDSLBZ);
            //int.TryParse(txtDDSLBZ.Text.Trim(), out DDSLBZ);

            //XQF = StaticFun.getValue(cboXQF);

            //int.TryParse(txtXSLBZ.Text.Trim(), out XSLBZ);

            //ZXBZ = txtZXBZ.Text.ToString();

            
            #endregion

            #region Model赋值




            _modelFFD090.PM = PM;
            _modelFFD090.PH = PH;
            _modelFFD090.CLBH = CLBH;
            _modelFFD090.FPRQ = FPRQ;
            _modelFFD090.KHBH = KHBH;
            _modelFFD090.FPSL = FPSL;
            _modelFFD090.FPZBH = FPZ;
            _modelFFD090.BZ = txtBZ.Text.Trim();     


           
            #endregion
            SaveFMD310(_modelFFD090);  //保存到数据库
        }

        public void SaveFMD310(ffd090 model)  //保存到数据库
        {
            ArrayList al = new ArrayList();
            if (_bllFFD090.Exists(model.FPRQ,model.PM, model.PH, model.CLBH,model.KHBH))  //判断社员编号是否存在
            {
                //model.GXZBH = ComForm.strUserName;
                //model.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                //model.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                //model.GXDMM = PublicFun.Get_SysDNBH();
                al.Add(_bllFFD090.Update(_modelFFD090));//更新FMD310数据
            }
            else
            {
                //model.RLZBH = ComForm.strUserName;
                //model.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                //model.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                //model.RLDMM = PublicFun.Get_SysDNBH();
                al.Add(_bllFFD090.Add(_modelFFD090));//插入FMD310数据
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

                    
                case "txtXDSLBZ":
                //社员编号管理用    
                case "txtDDSLBZ":

                case "txtZXKC":
                case "txtFPZ":
                case "txtKHBH":
               
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
                //case "txtPH":
                //社保编号
                //case "txtPM":
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
            if (this.txtPH.Text != null)
            {
              //  string str = GetPYString(txtPH.Text.Trim().Replace(" ", ""));
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
        //private void txtZDKC_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtZDKC.Text.Trim()) == false)
        //    {
        //        if (IsNumber(txtZDKC.Text.Trim()) == true)
        //        {

        //        }
        //        else
        //        {
        //            ComForm.DspMsg("W014", "");
        //            txtZDKC.Focus();
        //        }
        //    }
        //}

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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnKHBH_Click(object sender, EventArgs e)
        {
            GetShow_SUB_Key_Value();
        }

        private void btnFPZ_Click(object sender, EventArgs e)
        {
            GetShow_SUB_FORM();
        }
        public void GetShow_SUB_FORM()
        {
           
            try
            {
                WinSubSYBH _SUB_FORM = new WinSubSYBH();
                if (!string.IsNullOrEmpty(this.txtFPZ.Text))
                {
                    _SUB_FORM._conSYBH = this.txtFPZ.Text;
                }
                else
                {
                    _SUB_FORM._conSYBH = "";
                }

                _SUB_FORM.ShowDialog();
                if (!string.IsNullOrEmpty(_SUB_FORM._strSYNAME))
                {

                    this.txtFPZ.Text = _SUB_FORM._conSYBH;
                    this.txtFPZMC.Text = _SUB_FORM._strSYNAME;

                }
                else
                {
                    this.btnFPZ.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }


        public void GetShow_SUB_Key_Value()
        {

            try
            {
                WinSubKey_Value _SUB_FORM = new WinSubKey_Value();
                if (!string.IsNullOrEmpty(this.txtKHBH.Text))
                {
                    _SUB_FORM._conKEY = this.txtKHBH.Text;
                }
                else
                {
                    _SUB_FORM._conKEY = "";
                }

                _SUB_FORM.ShowDialog();
                if (!string.IsNullOrEmpty(_SUB_FORM._conValue))
                {

                    this.txtKHBH.Text = _SUB_FORM._conKEY;
                    this.txtKHMC.Text = _SUB_FORM._conValue;

                }
                else
                {
                    this.btnKHBH.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void txtFPZ_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFPZ_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)(sender);
            if (txt.Text.Trim().IsNullOrEmpty())
            {
                if (txt.Name.Equals("txtFPZ"))
                {
                    txtFPZMC.Text = "";
                }
                else
                {
                    txtKHMC.Text = "";
                }
            }
            else
            {
                if (txt.Name.Equals("txtFPZ"))
                {
                    txtFPZMC.Text = _bllFMD010_NAME.GetData_SYNAME(txt.Text.Trim(), "");
                    if (txtFPZMC.Text.IsNullOrEmpty() == true)
                    {
                        txt.Text = "";
                    }
                }
                else
                {
                    txtKHMC.Text = _bllFMD010_NAME.GetData_Value("FMD030",txt.Text.Trim(), "");
                    if (txtKHMC.Text.IsNullOrEmpty() == true)
                    {
                        txt.Text = "";
                    }
                }
            }
        }

        private void txtKHBH_Leave(object sender, EventArgs e)
        {

        }

        private void txtPH_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
