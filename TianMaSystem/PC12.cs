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
    public partial class PC12 : Form
    {
        BLL.fmd070 _bllFMD010 = new BLL.fmd070();
        Model.fmd070 _modelFMD010 = new Model.fmd070();
        Function.systemdate systemdate = new Function.systemdate();

        public PC12()
        {
            InitializeComponent();
        }

        private void WinFMD010_Load(object sender, EventArgs e)
        {
            try
            {
                //定义Spread 行数
                this.fspd.ActiveSheet.Rows.Count = 0;
                BindNAME();
                SetSpdFormat();
                //combox绑定数据
               // comboxBind(cboGlMc, "GLMC");
                dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
                dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }
        }

        BLL.fmd000 _bllFmd000 = new BLL.fmd000();

        private void BindNAME()         //绑定社员姓名检索列表
        {
            #region 加载姓名文本框
            DataTable dt = new DataTable();
            dt = _bllFmd000.GetFMD030MC_KEY("03");
           // PublicFun.comboxBind(cboYCLLX, dt, 0);


           // PublicFun.comboxBind(cboZT, "ZT");
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
           
           // public static int YCLBHGHS = I++;
           // public static int YCLBHBS = I++;
           // public static int YCLLX = I++;
           // public static int ZT = I++;
           // public static int YXTS = I++;
           //// public static int JJ = I++;
           //// public static int MS = I++;
           // public static int ZXKC = I++;
           // public static int ZDKC = I++;
           // public static int JLDW = I++;   

            public static int CLBH = I++;
            public static int PHBBH = I++;
            public static int ZDRQ = I++;
            public static int YCLBH = I++;
            public static int JLDW = I++;
            public static int ZL = I++;
            public static int GC = I++;
            public static int SYBH = I++;
            public static int PZRBH = I++;
            public static int ZT = I++;
            public static int BZ = I++;




            //public static int CLBH = I++;
            //public static int YXTS = I++;
            //public static int JLDW = I++;
            //public static int ZT = I++; 
            //public static int YCLBHBS = I++;
            ////public static int JJ = I++;
            ////public static int MS = I++;
            //public static int ZXKC = I++;
            //public static int ZDKC = I++;
           

                                                    

            #endregion 
        }
        #endregion

        #region Spread 列有意义化
        struct SpdDataSoureColName
        {
            //public const string PM = "PM";       //社员编号
            //public const string PH = "PH";            //社员名
            //public const string CLBH = "CLBH";            //部門
            //public const string JLDW = "JLDW";            //部門
            //public const string ZXKC = "ZXKC";            //职位
            //public const string ZDKC = "ZDKC";            //职位



            //public const string YCLBHBS = "YCLBHBS";
            //public const string YCLBHGHS = "YCLBHGHS";
            //public const string YCLLX = "YCLLX";
            //public const string ZT = "ZT";
            //public const string YXTS = "YXTS";
            //public const string JJ = "JJ";
            //public const string MS = "MS";
            //public const string ZXKC = "ZXKC";
            //public const string ZDKC = "ZDKC";
            //public const string JLDW = "JLDW";        



            public const string CLBH = "CLBH";
            public const string PHBBH = "PHBBH";
            public const string ZDRQ = "ZDRQ";
            public const string YCLBH = "YCLBH";
            public const string JLDW = "JLDW";
            public const string ZL = "ZL";
            public const string GC = "GC";
            public const string SYBH = "SYBH";
            public const string PZRBH = "PZRBH";
            public const string BZ = "BZ";
            public const string ZT = "ZT";
                       


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

                fspd.ActiveSheet.RowHeaderColumnCount = 1;
                fspd.ActiveSheet.RowHeader.Columns[0].Width = 35;
                System.Reflection.FieldInfo[] fields = ht.GetFields();//得到该类型中 的字段数组
                int SpreadColCount = fields.Count();//有几个字段 spd就有几列            
                fspd.ActiveSheet.ColumnCount = SpreadColCount;
                #endregion

                #region 对齐方式
                ////水平方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Center;

                fspd.ActiveSheet.Columns[SpdColNo.JLDW].HorizontalAlignment = CellHorizontalAlignment.Center;

                fspd.ActiveSheet.Columns[SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Left;               
               

                fspd.ActiveSheet.Columns[SpdColNo.GC].HorizontalAlignment = CellHorizontalAlignment.Right;
                fspd.ActiveSheet.Columns[SpdColNo.ZL].HorizontalAlignment = CellHorizontalAlignment.Right;


                ////垂直方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.BZ].VerticalAlignment = CellVerticalAlignment.Center;


              
                #endregion

                #region   spd 列宽，单元格类型设定

                CheckBoxCellType checkBoxType;
                checkBoxType = new CheckBoxCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].CellType = checkBoxType;
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].Visible =false;
              
                TextCellType textCellType;
                //年月
                textCellType = new TextCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CLBH, SpdColNo.BZ].CellType = textCellType;
               // fspd.ActiveSheet.Columns[SpdColNo.CLBH, SpdColNo.BZ].Width = 99F;


                fspd.ActiveSheet.Columns[SpdColNo.CLBH].Width = 69F;
                fspd.ActiveSheet.Columns[SpdColNo.PHBBH].Width = 79F;
                fspd.ActiveSheet.Columns[SpdColNo.ZDRQ].Width = 79F;
                fspd.ActiveSheet.Columns[SpdColNo.YCLBH].Width = 159F;
                fspd.ActiveSheet.Columns[SpdColNo.JLDW].Width = 69F;
                fspd.ActiveSheet.Columns[SpdColNo.ZL].Width = 94F;
                fspd.ActiveSheet.Columns[SpdColNo.GC].Width = 79F;
                fspd.ActiveSheet.Columns[SpdColNo.SYBH].Width = 94F;
                fspd.ActiveSheet.Columns[SpdColNo.PZRBH].Width = 94F;
                fspd.ActiveSheet.Columns[SpdColNo.BZ].Width =139F;

                fspd.ActiveSheet.Columns[SpdColNo.ZT].Visible = false;


                //fspd.ActiveSheet.Columns[SpdColNo.SFZ, SpdColNo.EMAIL].Width = 110F;





                //隐藏后面的信息    
                //fspd.ActiveSheet.Columns[SpdColNo.GW, SpdColNo.GW].Visible = false;//岗位 不显示20130702
               // fspd.ActiveSheet.Columns[SpdColNo.ZT, SpreadColCount - 1].Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.BJF_BZ].Visible = false; // 20130802 cpj 保健费改为 他加 项目 不显示保健费标准

               

              
                #endregion

                #region  锁定列宽和行高
                fspd.ActiveSheet.Columns.Get(0, SpreadColCount - 1).Resizable = true;           
                #endregion

                #region 锁定列
                fspd.ActiveSheet.Columns.Get(SpdColNo.CLBH, SpdColNo.BZ).Locked = true;
        
                fspd.ActiveSheet.Columns.Get(SpdColNo.CHECK).Locked = false;
                //fspd.ActiveSheet.Columns.Get(SpdColNo.ZZ, SpdColNo.EMAIL).Locked = false;
                #endregion

                #region column LABEl 
           

                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CHECK).Label = " ";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CLBH).Label = "材料编号";// 
                
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.PHBBH).Label = "配合表编号";// 
               // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLBHGHS).Label = "原材料(供货商)";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.JLDW).Label = "计量单位";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZDRQ).Label = "制定日期";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLBH).Label = "原材料编号";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZL).Label = "数量";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.GC).Label = "公差";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.SYBH).Label = "作成人";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.PZRBH).Label = "批准人";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.BZ).Label = "用途";// 



                for (int i = 0; i < SpreadColCount; i++)
                {
                    this.fspd.ActiveSheet.ColumnHeader.Columns.Get(i).ForeColor = Color.Empty;
                    this.fspd.ActiveSheet.ColumnHeader.Columns.Get(i).ForeColor = Color.Black;
                }
        
              
           
                #endregion
                // 冻结列
               // fspd.ActiveSheet.FrozenColumnCount = SpdColNo.CLBH + 1;
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

                    if ("1".Equals(fspd.ActiveSheet.Cells[i,SpdColNo.ZT].Text))
                    {
                        fspd.ActiveSheet.Rows.Get(i).ForeColor = Color.Red;
                    }
                    else
                    {
                        fspd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                    } 
             
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

                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
                

                dtspd = _bllFMD010.GetSpdData(strStartRq,strEndRq,txtCLBH.Text.Trim(),txtPHBBH.Text.Trim(),txtZCR.Text.Trim(),txtPZR.Text.Trim());
                fspd.ActiveSheet.DataSource = null;
                fspd.ActiveSheet.RowCount = dtspd.Rows.Count;
                SetSpdFormat();
                //bool jjVisible = false;
                this.fspd.ActiveSheet.ColumnHeader.Cells.Get(0, SpdColNo.CHECK).Text = false.ToString();
                double KCS = 0;
                int YXTS=0;
                for (int i = 0; i < dtspd.Rows.Count; i++)
                {


                    fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text = "False";

                    fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text = dtspd.Rows[i][SpdDataSoureColName.CLBH].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.PHBBH].Text = dtspd.Rows[i][SpdDataSoureColName.PHBBH].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.ZDRQ].Text = dtspd.Rows[i][SpdDataSoureColName.ZDRQ].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text = dtspd.Rows[i][SpdDataSoureColName.YCLBH].ToString();


                    fspd.ActiveSheet.Cells[i, SpdColNo.JLDW].Text = dtspd.Rows[i][SpdDataSoureColName.JLDW].ToString();

                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.ZL].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.ZL].Text = KCS.ToString("N2");
                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.GC].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.GC].Text = KCS.ToString("N1");

                    fspd.ActiveSheet.Cells[i, SpdColNo.SYBH].Text = dtspd.Rows[i][SpdDataSoureColName.SYBH].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.PZRBH].Text = dtspd.Rows[i][SpdDataSoureColName.PZRBH].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text = dtspd.Rows[i][SpdDataSoureColName.BZ].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.ZT].Text = dtspd.Rows[i][SpdDataSoureColName.ZT].ToString();

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

        #region 名称key文本校验

        private void txtMcKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsWB(e);
        }

        #endregion

        #region 正式名称文本校验

        private void txtZsMc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString().isNumberRegex() == false)
            //{
            //    e.Handled = true;
            //}
            //ComForm.IsNum(e);       
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
            try
            {
                PC10_sub winPC09 = new PC10_sub();
                winPC09.ShowDialog();
              //  BindNAME();               //绑定社员姓名检索列表
                Spd_Form_Load();         //绑定Spread的数据                
            }
            catch(Exception ex)

            {
               // Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
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
        Model.fmd070 fillModel(int i)
        {
            Model.fmd070 modelfmd010 = new Model.fmd070();
            #region model 赋值
            modelfmd010.CLBH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
        
        
            #endregion
            return modelfmd010;
        }

        List<Model.fmd070> GetModel()
        {
            List<Model.fmd070> listmodelFKD100 = new List<Model.fmd070>();
            Model.fmd070 modelfmd010 = new Model.fmd070();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.fmd070();
                    modelfmd010 = fillModel(i);
                    listmodelFKD100.Add(modelfmd010);
                }
            }
            return listmodelFKD100;
        }
        List<Model.fmd070> listmodelFMD100 = new List<Model.fmd070>();
        private void btnDelete_Click(object sender, EventArgs e)  //删除按钮事件
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue()>0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        listmodelFMD100 = GetModel();//model赋值                       
                        foreach (Model.fmd070 modelFKD100 in listmodelFMD100)
                        {

                           // sqlList.Add(_bllFMD010.Delete(modelFKD100.CLBH));                               
                            
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
                    ComForm.DspMsg("W063", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E012", "");
                ComForm.InsertErrLog(ex.ToString(), "btnDel_Click @" + this.Name);
            }
        }
        //保存按钮
        private void btnSave_Click(object sender, EventArgs e)
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
                        string upPH= "",upPM= "",upCLBH = ""; 


                        for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
                        {
                            if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                            {
                                upPH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
                                //upPM = fspd.ActiveSheet.Cells[i, SpdColNo.PM].Text.Trim();
                                //upCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.CLBH].Text.Trim();
                                i = fspd.ActiveSheet.Rows.Count;
                            }
                        } 
                        
                        PC10_sub winPC05 = new PC10_sub();
                        winPC05._conCLBH = upPH;
                        //winPC05._conPM = upPM;
                        //winPC05._conCLBH = upCLBH;
                        winPC05.ShowDialog();
                        //  BindNAME();               //绑定社员姓名检索列表
                       
                        Spd_Form_Load();         //绑定Spread的数据         
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
                //if ("0".Equals(txtPM.Text) || "00".Equals(txtPM.Text) || "000".Equals(txtPM.Text))
                //{
                //    txtPM.Text = string.Empty;
                //    return;
                //}
                //if (!txtPM.Text.IsNullOrEmpty())
                //{
                //    txtPM.Text = txtPM.Text.PadLeft(3, '0');
                //}
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
            _strSYNAME = "";// txtPM.Text.Trim();
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SetExcel();
        }

        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC12"].ToString();
        public void SetExcel()
        {
            try
            {



                DataTable dt = new DataTable();             

                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日


                dt = _bllFMD010.GetSpdData(strStartRq, strEndRq, txtCLBH.Text.Trim(), txtPHBBH.Text.Trim(), txtZCR.Text.Trim(), txtPZR.Text.Trim());
        
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
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC12.xls");


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                                                


                            Ebe.SetCellValue(3 + i, 1, dt.Rows[i][SpdDataSoureColName.CLBH].ToString());
                            Ebe.SetCellValue(3 + i, 2, dt.Rows[i][SpdDataSoureColName.PHBBH].ToString());
                          
                            Ebe.SetCellValue(3 + i, 3, dt.Rows[i][SpdDataSoureColName.ZDRQ].ToString());
                            Ebe.SetCellValue(3 + i, 4, dt.Rows[i][SpdDataSoureColName.YCLBH].ToString());

                            Ebe.SetCellValue(3 + i, 5, dt.Rows[i][SpdDataSoureColName.JLDW].ToString());
                            Ebe.SetCellValue(3 + i, 6, dt.Rows[i][SpdDataSoureColName.ZL].ToString());
                            Ebe.SetCellValue(3 + i, 7, dt.Rows[i][SpdDataSoureColName.GC].ToString());
                            Ebe.SetCellValue(3 + i, 8, dt.Rows[i][SpdDataSoureColName.SYBH].ToString());
                            Ebe.SetCellValue(3 + i, 9, dt.Rows[i][SpdDataSoureColName.PZRBH].ToString());
                            Ebe.SetCellValue(3 + i, 10, dt.Rows[i][SpdDataSoureColName.BZ].ToString());

                            if (dt.Rows[i][SpdDataSoureColName.ZT].ToString().Equals("1"))
                            {
                                Ebe.SetFontColor(3 + i, 1, 3 + i, 10, 3);
                            }

                           
                        }

                        Ebe.SetBorderValueSingle(4, 2, dt.Rows.Count + 3, dt.Columns.Count);


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

        private void btnSYBH_Click(object sender, EventArgs e)
        {
            GetShow_SBU_FORM();
        }

        public void GetShow_SBU_FORM()
        {
            txtPZR.Focus();
            try
            {
                WinSubSYBH _SUB_FORM = new WinSubSYBH();
                //if (!string.IsNullOrEmpty(this.txtPZR.Text))
                //{
                //    _SUB_FORM._conSYBH = this.txtPZR.Text;
                //}
                //else
                //{
                //    _SUB_FORM._conSYBH = "";
                //}

                _SUB_FORM.ShowDialog();
                if (!string.IsNullOrEmpty(_SUB_FORM._strSYNAME))
                {

                    this.txtPZR.Text = _SUB_FORM._conSYBH;
                    this.txtPZR_LAB.Text = _SUB_FORM._strSYNAME;

                }
                else
                {
                    this.txtPZR.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPZR.Focus();
            try
            {
                WinSubSYBH _SUB_FORM = new WinSubSYBH();
                //if (!string.IsNullOrEmpty(this.txtPZR.Text))
                //{
                //    _SUB_FORM._conSYBH = this.txtPZR.Text;
                //}
                //else
                //{
                //    _SUB_FORM._conSYBH = "";
                //}

                _SUB_FORM.ShowDialog();
                if (!string.IsNullOrEmpty(_SUB_FORM._strSYNAME))
                {

                    this.txtZCR.Text = _SUB_FORM._conSYBH;
                    this.txtZCR_LAB.Text = _SUB_FORM._strSYNAME;

                }
                else
                {
                    this.txtZCR.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }

        }

        private void txtPZR_Validating(object sender, CancelEventArgs e)
        {
            
            if (txtPZR.Text.Trim().IsNullOrEmpty())
            {
                txtPZR_LAB.Text = "";
            }
            else
            {

            }
        }

        private void txtZCR_Validating(object sender, CancelEventArgs e)
        {

            if (txtZCR.Text.Trim().IsNullOrEmpty())
            {
                txtZCR_LAB.Text = "";
            }
            else
            {

            }
        }
    }
}
