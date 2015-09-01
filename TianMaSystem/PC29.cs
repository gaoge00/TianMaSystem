using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Globalization;
using System.Diagnostics;
//using DBUtility;

namespace BSC_System
{
    public partial class PC29 : Form
    {
        BLL.fmd060 _bllFMD010 = new BLL.fmd060();

        BLL.fmd010 _bllFMD010_NAME = new BLL.fmd010();
        BLL.ffd090 _bllFFD090 = new BLL.ffd090();
        Model.fmd060 _modelFMD010 = new Model.fmd060();
        Function.systemdate systemdate = new Function.systemdate();

        public PC29()
        {
            InitializeComponent();
        }

        private void WinFMD010_Load(object sender, EventArgs e)
        {
            try
            {
                //定义Spread 行数
                this.fspd.ActiveSheet.Rows.Count = 0;

                dateStartRq.Value=
              dateEndRq.Value=  DateTime.Parse(PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D));

                BindNAME();
                SetSpdFormat();
                Spd_Form_Load();
                //combox绑定数据
               // comboxBind(cboGlMc, "GLMC");
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }
        }



        private void BindNAME()         //绑定社员姓名检索列表
        {
            #region 加载姓名文本框
            //DataTable dt = _bllFMD010.GetNameForList();
            //if (dt.Rows.Count > 0)
            //{
            //    var Com_info = dtToArr(dt, "XM");
            //    this.txtSYName.AutoCompleteCustomSource.Clear();
            //    this.txtSYName.AutoCompleteCustomSource.AddRange(Com_info);
            //}
            #endregion
        }

        public string[] dtToArr(DataTable dt, string strColName)  //将DataTable转换为数组
        {
            if (dt.Rows.Count > 0)
            {
                var sz = (
                          from name_list in dt.AsEnumerable()
                          select (name_list.Field<string>(strColName)).NullOrEmpty(String.Empty)
                          ).ToArray();
                return sz;
            }
            else
            {
                string[] StrEmpty = new string[1];
                StrEmpty[0] = "";
                return StrEmpty;
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

        #region ComboBox 点击事件
        private void cmbGLMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string rt = cboGlMc.SelectedValue.ToString();
            //if (rt != "")
            //{
            //    string ty = rt.Substring(0, 1);
            //    string arrData = "0";

            //    if (arrData == "0" && ty == "9")
            //    {
            //        this.txtMcKey.Enabled = false;
            //        this.txtZsMc.Enabled = false;
            //        this.txtSxMc.Enabled = false;

            //    }
            //    else
            //    {
            //        this.txtMcKey.Enabled = true;
            //        this.txtZsMc.Enabled = true;
            //        this.txtSxMc.Enabled = true;
            //    }
            //}
            //txtMcKey.Text = string.Empty;
            //txtZsMc.Text = string.Empty;
            //txtSxMc.Text = string.Empty;
            //Spread 绑定数据
            fillSPD();
        }
        #endregion

        #region Spread 绑定数据

        private void fillSPD()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }
        }


        #region
        #region Spread 列有意义化
        static class SpdColNo
        {
            private static int i = 0;

            public static int I
            {
                get { return i; }
                set { i = value; }
            }

            #region
            public static int CHECK = I++;
            public static int KHMC = I++;
            public static int FPRQ = I++;
            public static int PM = I++;//品名	
            public static int PH = I++;//品号	
            public static int CLBH = I++;//材料	

            public static int FPSL = I++;//计量单位	
            public static int FPZMC = I++;//最小库存		
            public static int BZ = I++;//最大库存	
            public static int KHBH = I++;//最大库存	

            #endregion 
        }
        #endregion

        #region Spread 列有意义化
        struct SpdDataSoureColName
        {
            public const string KHMC = "KHMC";
            public const string FPRQ = "FPRQ";
            public const string PM = "PM";       //社员编号
            public const string PH = "PH";            //社员名
            public const string CLBH = "CLBH";            //部門
            public const string FPSL = "FPSL";            //部門
            public const string FPZMC = "SYMC";            //职位
            public const string BZ = "BZ";            //职位

            public const string KHBH = "KHBH";

        }
        #endregion
        #endregion
        #region spd 属性设置
        ///<summary>
        /// spd的初始.(回车跳格,清除split,锁定行高列宽.直接更改文本)
        ///</summary>
        private void SetSpdFormat()
        {
            try
            {
                //fspd.ActiveSheet.RowHeader.Columns[0].Visible = false;

                #region column count
                Type ht = typeof(SpdColNo);
                System.Reflection.FieldInfo[] fields = ht.GetFields();//得到该类型中 的字段数组
                int SpreadColCount = fields.Count();//有几个字段 spd就有几列            
                fspd.ActiveSheet.ColumnCount = SpreadColCount;
                #endregion

                #region 对齐方式
                ////水平方向
                fspd.ActiveSheet.Columns[SpdColNo.FPRQ, SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Center;

                fspd.ActiveSheet.Columns[SpdColNo.KHMC, SpdColNo.KHMC].HorizontalAlignment = CellHorizontalAlignment.Left;
                fspd.ActiveSheet.Columns[SpdColNo.BZ, SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Left;
                 fspd.ActiveSheet.Columns[SpdColNo.FPSL, SpdColNo.FPSL].HorizontalAlignment = CellHorizontalAlignment.Right;
           
 
                ////垂直方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.BZ].VerticalAlignment = CellVerticalAlignment.Center;


              
                #endregion

                #region   spd 列宽，单元格类型设定

                CheckBoxCellType checkBoxType;
                checkBoxType = new CheckBoxCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].CellType = checkBoxType;
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].Width = 23F;

                TextCellType textCellType;
                //年月
                textCellType = new TextCellType();
                fspd.ActiveSheet.Columns[SpdColNo.PM, SpdColNo.BZ].CellType = textCellType;
                fspd.ActiveSheet.Columns[SpdColNo.PM, SpdColNo.BZ].Width = 126F;


                 fspd.ActiveSheet.Columns[SpdColNo.KHMC].Width = 126F;
                 fspd.ActiveSheet.Columns[SpdColNo.FPRQ].Width = 100F;
                 fspd.ActiveSheet.Columns[SpdColNo.PM].Width = 126F;
                 fspd.ActiveSheet.Columns[SpdColNo.PH].Width = 126F;
                 fspd.ActiveSheet.Columns[SpdColNo.CLBH].Width = 126F;
                 fspd.ActiveSheet.Columns[SpdColNo.FPSL].Width = 100F;
                 fspd.ActiveSheet.Columns[SpdColNo.FPZMC].Width = 90F;
                 fspd.ActiveSheet.Columns[SpdColNo.BZ].Width = 145F;                
        
                fspd.ActiveSheet.Columns[SpdColNo.KHBH].Visible = false;
                NumberCellType NumberCellType = new NumberCellType();
                NumberCellType.DecimalPlaces = 0;
                NumberCellType.MaximumValue = 99999999.9999;
                NumberCellType.MinimumValue = 0;
                NumberCellType.Separator = ",";
                NumberCellType.ShowSeparator = true;
                fspd.ActiveSheet.Columns[SpdColNo.FPSL, SpdColNo.FPSL].CellType = NumberCellType;



                //隐藏后面的信息    
                //fspd.ActiveSheet.Columns[SpdColNo.GW, SpdColNo.GW].Visible = false;//岗位 不显示20130702
               // fspd.ActiveSheet.Columns[SpdColNo.ZT, SpreadColCount - 1].Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.BJF_BZ].Visible = false; // 20130802 cpj 保健费改为 他加 项目 不显示保健费标准

               

              
                #endregion

                #region  锁定列宽和行高
                fspd.ActiveSheet.Columns[SpdColNo.KHBH].Resizable = false;
                fspd.ActiveSheet.Columns.Get(0, SpreadColCount - 1).Resizable = true;
                #endregion

                #region 锁定列
                fspd.ActiveSheet.Columns.Get(SpdColNo.PM, SpdColNo.BZ).Locked = true;
        
                fspd.ActiveSheet.Columns.Get(SpdColNo.CHECK).Locked = false;
                //fspd.ActiveSheet.Columns.Get(SpdColNo.ZZ, SpdColNo.EMAIL).Locked = false;
                #endregion

                #region column LABEl  
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CHECK).Label = " ";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.PM).Label = "品名";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.PH).Label = "品号";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CLBH).Label = "材料编号";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.JLDW).Label = "计量单位";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZXKC).Label = "最小库存";// 
                //fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZDKC).Label = "最大库存";// 
    
              
           
                #endregion


                this.fspd.ActiveSheet.ColumnHeader.Columns.Get(1).ForeColor = Color.Black;
        
                // 冻结列
                fspd.ActiveSheet.FrozenColumnCount = SpdColNo.CLBH + 1;
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
        #endregion          

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


        #region spd用方法
        private void SetspdColor(int eRow)
        {
            if (fspd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
                {
                    fspd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                    //fspd.ActiveSheet.Rows.Get(i).BackColor = Color.Empty;
                    fspd.ActiveSheet.Rows.Get(i).BackColor = Color.LightGoldenrodYellow;      
             
                }

                this.fspd.ActiveSheet.Rows[eRow].BackColor = Color.Lavender;
            }
        }
        #endregion 

        private void Spd_Form_Load() //绑定Spread的数据
        {
            try
            {
                DataTable dtspd = new DataTable();
                dtspd = _bllFFD090.GetDataSpread(dateStartRq.Value.ToString("yyyy/MM/dd"),dateEndRq.Value.ToString("yyyy/MM/dd"),
                    txtPM.Text.Trim(), txtPH.Text.Trim(), txtCLBH.Text.Trim(),txtKHBH.Text.Trim());
                fspd.ActiveSheet.DataSource = null;
                fspd.ActiveSheet.RowCount = dtspd.Rows.Count;
                SetSpdFormat();
                //bool jjVisible = false;
                this.fspd.ActiveSheet.ColumnHeader.Cells.Get(0, SpdColNo.CHECK).Text = false.ToString();
                int FPSL = 0;
                for (int i = 0; i < dtspd.Rows.Count; i++)
                {


                    fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text = "False";

                    fspd.ActiveSheet.Cells[i, SpdColNo.FPRQ].Text = dtspd.Rows[i][SpdDataSoureColName.FPRQ].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.PM].Text = dtspd.Rows[i][SpdDataSoureColName.PM].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.PH].Text = dtspd.Rows[i][SpdDataSoureColName.PH].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text = dtspd.Rows[i][SpdDataSoureColName.CLBH].ToString();
                   fspd.ActiveSheet.Cells[i, SpdColNo.KHMC].Text = dtspd.Rows[i][SpdDataSoureColName.KHMC].ToString();
 
                    int.TryParse(dtspd.Rows[i][SpdDataSoureColName.FPSL].ToString(), out FPSL);

                    fspd.ActiveSheet.Cells[i, SpdColNo.FPSL].Text = FPSL.ToString("N0");
                    fspd.ActiveSheet.Cells[i, SpdColNo.FPZMC].Text = dtspd.Rows[i][SpdDataSoureColName.FPZMC].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text = dtspd.Rows[i][SpdDataSoureColName.BZ].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.KHBH].Text = dtspd.Rows[i][SpdDataSoureColName.KHBH].ToString();
 

                 
                      }
               
                //设置格式
                SetSpdFormat();
                Application.DoEvents();
                if (fspd.ActiveSheet.RowCount > 0)
                {
                    SetspdColor(0);
                }              
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");   //数据加载失败！
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        #endregion

        #region 窗体关闭按钮方法重写
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {

                //btnClose.PerformClick();
                btnClose();
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        #region 名称key文本校验

        private void txtMcKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsWB(e);
        }

        #endregion

        #region 正式名称文本校验

        private void txtZsMc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IsNullOrEmpty())
            {
                e.Handled = true;
            }
        }

        #endregion

        #region 缩写名称文本校验
        private void txtSxMc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().IsNullOrEmpty())
            {
                e.Handled = true;
            }
        }

        #endregion

        #region 按钮单击事件

        //清空按钮
        private void btnADD_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    PC29_sub winPC08 = new PC29_sub();
            //    winPC08.ShowDialog();
            //  //  BindNAME();               //绑定社员姓名检索列表
            //    Spd_Form_Load();         //绑定Spread的数据                
            //}
            //catch(Exception ex)

            //{
            //   // Comm.InsertErrLog(ex.ToString(), this.Name);
            //    ComForm.InsertErrLog(ex.ToString(), this.Name);
            //}
        }

        //删除按钮

        int getcheckHasTrue()//保存时 只要有选中的就可以 保存
        {
            int ischeckcount = 0;
            for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    ischeckcount++;
                    //i = fspd.ActiveSheet.RowCount;
                }
            }
            return ischeckcount;


        }
        Model.ffd090 fillModel(int i)
        {
            Model.ffd090 modelfmd010 = new Model.ffd090();
            #region model 赋值
            modelfmd010.PM = fspd.ActiveSheet.Cells[i, SpdColNo.PM].Text.Trim();
            modelfmd010.PH = fspd.ActiveSheet.Cells[i, SpdColNo.PH].Text.Trim();
            modelfmd010.CLBH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
            modelfmd010.KHBH = fspd.ActiveSheet.Cells[i, SpdColNo.KHBH].Text.Trim();
            modelfmd010.FPRQ = fspd.ActiveSheet.Cells[i, SpdColNo.FPRQ].Text.Trim();
        
            #endregion
            return modelfmd010;
        }

        List<Model.ffd090> GetModel()
        {
            List<Model.ffd090> listmodelFKD100 = new List<Model.ffd090>();
            Model.ffd090 modelfmd010 = new Model.ffd090();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.ffd090();
                    modelfmd010 = fillModel(i);
                    listmodelFKD100.Add(modelfmd010);
                }
            }
            return listmodelFKD100;
        }
        //List<Model.fmd060> listmodelFMD100 = new List<Model.fmd060>();
        //private void btnDelete_Click(object sender, EventArgs e)  //删除按钮事件
        //{
        //    try
        //    {
        //        List<string> sqlList = new List<string>();
        //        if (getcheckHasTrue()>0)// 有选中的数据
        //        {
        //            if (ComForm.DspMsg("Q003", "") == "0")
        //            {

        //                listmodelFMD100 = GetModel();//model赋值                       
        //                foreach (Model.fmd060 modelFKD100 in listmodelFMD100)
        //                {

        //                    sqlList.Add(_bllFMD010.Delete(modelFKD100.PM,modelFKD100.PH,modelFKD100.CLBH));                               
                            
        //                }
        //                //删除成功
        //                if (DbHelperMySql.ExecuteSqlTran(sqlList).Equals(0))
        //                {
        //                    ComForm.DspMsg("M001", "");
        //                    DataTable dt = new DataTable();                           
        //                    Spd_Form_Load();//重新加载 spread
        //                }
        //                else
        //                {
        //                    ComForm.DspMsg("E012", "");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ComForm.DspMsg("W063", "");
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ComForm.DspMsg("E012", "");
        //        ComForm.InsertErrLog(ex.ToString(), "btnDel_Click @" + this.Name);
        //    }
        //}
        ////保存按钮
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (getcheckHasTrue() > 1)
        //            {
        //                ComForm.DspMsg("W004", "");   //数据加载失败！
        //                return;
        //            }
        //            else if (getcheckHasTrue() == 1)
        //            {
        //                string upPH= "",upPM= "",upCLBH = ""; 


        //                for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
        //                {
        //                    if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
        //                    {
        //                        upPH = fspd.ActiveSheet.Cells[i, SpdColNo.PH].Text.Trim();
        //                        upPM = fspd.ActiveSheet.Cells[i, SpdColNo.PM].Text.Trim();
        //                        upCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
        //                        i = fspd.ActiveSheet.Rows.Count;
        //                    }
        //                } 
                        
        //                PC29_sub winPC05 = new PC29_sub();
        //                winPC05._conPH = upPH;
        //                winPC05._conPM = upPM;
        //                winPC05._conCLBH = upCLBH;
        //                winPC05.ShowDialog();
        //                //  BindNAME();               //绑定社员姓名检索列表
                       
        //                Spd_Form_Load();         //绑定Spread的数据         
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Comm.InsertErrLog(ex.ToString(), this.Name);
        //            ComForm.InsertErrLog(ex.ToString(), this.Name);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ComForm.InsertErrLog(ex.ToString(), this.Name);
        //    }

        //}

        //退出按钮
        private void btnClose()
        {
            if (ComConst.LING == ComForm.DspMsg("Q001", ""))
            {
                System.GC.Collect();
                this.Close();
            }
            else
            {
                //cboGlMc.Focus();
            }
        }
        #endregion

        #region 名称KEY 自动补零

        private void txtMcKey_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if ("0".Equals(txtPM.Text) || "00".Equals(txtPM.Text) || "000".Equals(txtPM.Text))
                {
                    txtPM.Text = string.Empty;
                    return;
                }
                if (!txtPM.Text.IsNullOrEmpty())
                {
                    txtPM.Text = txtPM.Text.PadLeft(3, '0');
                }
                //if (cboGlMc.Text.IsNullOrEmpty())
                //    return;

            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }
        }

        #endregion

        #region 双击Spread为TextBox 赋值

        private void fspdMc_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //权限判断
                string rt = "";//cboGlMc.SelectedValue.ToString();
                string ty = rt.Substring(0, 1);
              
               

            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }

        }

        #endregion

        #region Spread 单击给整行单元格赋值颜色

        private void fspdMc_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //ComSpread.Spread_CellClickChangeBColor(fspd, e, Color.Lavender);

            SetspdColor(e.Row);
        }

        #endregion

        #region Spread 鼠标离开赋值颜色
        private void fspdMc_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
           // ComSpread.Spread_LeaveCellBColor(fspd, e, Color.Lavender);
        }

        #endregion

        #region 快捷键回车代替TAB键
        private void WinFMD010_KeyDown(object sender, KeyEventArgs e)
        {

            PublicFun.EnterSendTab(sender, e);
        }

        #endregion

        #region 设定spread 列宽最小值
        private void fspdMc_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            for (int i = 0; i < this.fspd.ActiveSheet.Columns.Count; i++)//循环spread 列
            {
                if (this.fspd.ActiveSheet.Columns.Get(i).Width < 30)//如果小于30
                {
                    this.fspd.ActiveSheet.Columns.Get(i).Width = 30;//设定最小值是30
                }

            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Spd_Form_Load();
        }
  
        string _strSYNAME = string.Empty;       

        private void txtSYName_Enter(object sender, EventArgs e)           //社员姓名文本框验证事件
        {
            _strSYNAME = txtPM.Text.Trim();
        }

        private void txtSYName_TextChanged(object sender, EventArgs e)     //社员姓名文本框改变事件
        {
            //if (!txtPM.Text.Trim().Equals(_strSYNAME))
            //{
            //    _strSYNAME = txtPM.Text.Trim();
            //    Spd_Form_Load();     //绑定Spread的数据
            //}
            //else
            //{
            //    return;
            //}
        }

        private void btnADD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                PC29_sub winPC08 = new PC29_sub();
                
                winPC08.ShowDialog();
                //  BindNAME();               //绑定社员姓名检索列表
                Spd_Form_Load();         //绑定Spread的数据                
            }
            catch (Exception ex)
            {
                // Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                try
                {
                    if (getcheckHasTrue() > 1)
                    {
                        ComForm.DspMsg("W004", "");   //数据加载失败！
                        return;
                    }
                    else if (getcheckHasTrue() == 1)
                    {
                        string upPH = "", upPM = "", upCLBH = "", upKHBH = "",upFPRQ="";


                        for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
                        {
                            if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                            {
                                upPH = fspd.ActiveSheet.Cells[i, SpdColNo.PH].Text.Trim();
                                upPM = fspd.ActiveSheet.Cells[i, SpdColNo.PM].Text.Trim();
                                upCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
                                upKHBH = fspd.ActiveSheet.Cells[i, SpdColNo.KHBH].Text.Trim();
                                upFPRQ = fspd.ActiveSheet.Cells[i, SpdColNo.FPRQ].Text.Trim();
                                i = fspd.ActiveSheet.Rows.Count;
                            }
                        }

                        PC29_sub winPC05 = new PC29_sub();
                        winPC05._conPH = upPH;
                        winPC05._conPM = upPM;
                        winPC05._conCLBH = upCLBH;
                        winPC05._conKHBH = upKHBH;
                        winPC05._conFPRQ = upFPRQ;
                        winPC05.ShowDialog();
                        //  BindNAME();               //绑定社员姓名检索列表

                        Spd_Form_Load();         //绑定Spread的数据         
                    }
                    else
                    {
                        MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    // Comm.InsertErrLog(ex.ToString(), this.Name);
                    ComForm.InsertErrLog(ex.ToString(), this.Name);
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        List<Model.ffd090> listmodelFMD100 = new List<Model.ffd090>();
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue() > 0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        listmodelFMD100 = GetModel();//model赋值                       
                        foreach (Model.ffd090 modelFKD100 in listmodelFMD100)
                        {

                            sqlList.Add(_bllFFD090.Delete(modelFKD100.FPRQ, modelFKD100.PM, modelFKD100.PH, modelFKD100.CLBH,modelFKD100.KHBH));

                        }
                        //删除成功
                        if (DbHelperMySql.ExecuteSqlTran(sqlList).Equals(0))
                        {
                            ComForm.DspMsg("M001", "");
                            DataTable dt = new DataTable();
                            Spd_Form_Load();//重新加载 spread
                        }
                        else
                        {
                            ComForm.DspMsg("E012", "");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E012", "");
                ComForm.InsertErrLog(ex.ToString(), "btnDel_Click @" + this.Name);
            }
        }

        private void txtPH_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetShow_SUB_Key_Value();
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
                    this.button1.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void txtKHBH_Validated(object sender, EventArgs e)
        {

        }

        private void txtKHBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);       
        }

        private void txtKHBH_Validating(object sender, CancelEventArgs e)
        {
            if (txtKHBH.Text.Trim().IsNullOrEmpty())
            {
                txtKHBH.Text = "";
                txtKHMC.Text = "";              
            }
            else
            {
                TextBox txt = (TextBox)(sender);
                if (txt.Text.Trim().IsNullOrEmpty())
                {
                  
                        txtKHMC.Text = "";                   
                }
                else
                {


                    txtKHMC.Text = _bllFMD010_NAME.GetData_Value("FMD030", txt.Text.Trim(), "");
                        if (txtKHMC.Text.IsNullOrEmpty() == true)
                        {
                            txt.Text = "";
                        }
                   
                }

            }
        }

        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetExcel();
        }

        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC29"].ToString();
        public void SetExcel()
        {
            try
            {



             
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日


                DataTable dt = new DataTable();
                dt = _bllFFD090.GetDataSpread(dateStartRq.Value.ToString("yyyy/MM/dd"), dateEndRq.Value.ToString("yyyy/MM/dd"),
                    txtPM.Text.Trim(), txtPH.Text.Trim(), txtCLBH.Text.Trim(), txtKHBH.Text.Trim());
             
                if (dt.Rows.Count > 0)
                {
                    if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                    {
                        //int countexcel = 0;
                        beforeTime = DateTime.Now.TimeOfDay;
                        #region
                        //获取服务器时间
                        string strdm = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_Y_M_D)
                            + " " + PublicFun.GetSystemDateTime(ComConst.Time, ""))
                                        .ToString("yyyyMMddhhmmss", DateTimeFormatInfo.CurrentInfo);
                        #endregion

                        ExportBaseExcel Ebe = new ExportBaseExcel();
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC29.xls");


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {



                            Ebe.SetCellValue(3 + i, 1, dt.Rows[i][SpdDataSoureColName.KHMC].ToString());
                            Ebe.SetCellValue(3 + i, 2, dt.Rows[i][SpdDataSoureColName.FPRQ].ToString());

                            Ebe.SetCellValue(3 + i, 3, dt.Rows[i][SpdDataSoureColName.PM].ToString());
                            Ebe.SetCellValue(3 + i, 4, dt.Rows[i][SpdDataSoureColName.PH].ToString());

                            Ebe.SetCellValue(3 + i, 5, dt.Rows[i][SpdDataSoureColName.CLBH].ToString());
                            Ebe.SetCellValue(3 + i, 6, dt.Rows[i][SpdDataSoureColName.FPSL].ToString());
                            Ebe.SetCellValue(3 + i, 7, dt.Rows[i][SpdDataSoureColName.FPZMC].ToString());                      
                            Ebe.SetCellValue(3 + i, 8, dt.Rows[i][SpdDataSoureColName.BZ].ToString());

                          


                        }

                        Ebe.SetBorderValueSingle(4, 2, dt.Rows.Count + 3, dt.Columns.Count-1);


                        if (!System.IO.Directory.Exists(Save_Path))
                        {
                            System.IO.Directory.CreateDirectory(Save_Path);
                        }
                        string Save_Path1 = Save_Path + "\\" + strdm + ".xls";
                        Ebe.SaveAs(Save_Path1);
                        Ebe.ReleaseExcel();
                        Ebe.KillSpecialExcel();
                        ExportBaseExcel Ebe1 = new ExportBaseExcel("");
                        Ebe1.ViewFile(Save_Path1);

                        Application.DoEvents();
                    }
                    else
                    {
                        KillExcelProcess();
                        return;
                    }
                }
                else
                {
                    ComForm.DspMsg("W061", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
        #region 杀Excel进程
        /// <summary>
        /// 杀EXCEL进程
        /// </summary>
        private void KillExcelProcess()
        {
            try
            {
                Process[] myProcesses;
                TimeSpan startTime;
                myProcesses = Process.GetProcessesByName("Excel");

                //得不到Excel进程ID，暂时只能判断进程启动时?
                foreach (Process myProcess in myProcesses)
                {
                    startTime = myProcess.StartTime.TimeOfDay;
                    myProcess.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion





    }
}
