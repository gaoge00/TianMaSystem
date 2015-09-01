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

using System.Collections;
//using DBUtility;

namespace BSC_System
{
    public partial class PC13 : Form
    {
        BLL.fed030 _bllfed030 = new BLL.fed030();

        BLL.fed040 _bllfed040 = new BLL.fed040();
        Model.fed030 _modelFED030 = new Model.fed030();
        Model.fed040 _modelFED040 = new Model.fed040();
        Function.systemdate systemdate = new Function.systemdate();

        public PC13()
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
            PublicFun.comboxBind(cboYCLLX, dt, 0);
           


            //this.txtPDR.Text =ComForm.strUserName;
            //this.txtXM.Text = ComForm.strSymc;




          //  PublicFun.comboxBind(cboYCLLX, "ZT");
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


            public static int YCLBH = I++;
            public static int YCLLX = I++;
            public static int YCLRKLOTNO = I++;
            public static int DW = I++;
            public static int ZKSL = I++;
            public static int SPSL = I++;
            public static int BZ = I++;
            public static int SPACE = I++;
            public static int SYQX = I++;
            public static int CKQF = I++;
            public static int PDRQ = I++;


                                                    

            #endregion 
        }
        #endregion

        #region Spread 列有意义化
        struct SpdDataSoureColName
        {
            public const string YCLBH = "YCLBH";
            public const string YCLLX = "YCLLX";
            public const string YCLRKLOTNO = "YCLRKLOTNO";
            public const string DW = "DW";
            public const string ZKSL = "ZKSL";
            public const string SPSL = "SPSL";
            public const string BZ = "BZ";
            public const string CKQF = "CKQF";
            public const string PDRQ = "PDRQ";
            public const string SYQX = "SYQX";

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
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.SPACE].HorizontalAlignment = CellHorizontalAlignment.Center;

                fspd.ActiveSheet.Columns[SpdColNo.SPSL ].HorizontalAlignment = CellHorizontalAlignment.Right;
                fspd.ActiveSheet.Columns[SpdColNo.ZKSL].HorizontalAlignment = CellHorizontalAlignment.Right;

                ////垂直方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.SPACE].VerticalAlignment = CellVerticalAlignment.Center;


                fspd.ActiveSheet.Columns[SpdColNo.BZ, SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Left;
                //////垂直方向
                //fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.SPACE].VerticalAlignment = CellVerticalAlignment.Center;

              
                #endregion
                fspd.ActiveSheet.RowHeaderColumnCount = 1;
                fspd.ActiveSheet.RowHeader.Columns[0].Width = 35;
                #region   spd 列宽，单元格类型设定

                CheckBoxCellType checkBoxType;
                checkBoxType = new CheckBoxCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].CellType = checkBoxType;
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].Width = 23F;

                TextCellType textCellType;
                //年月
                textCellType = new TextCellType();
                fspd.ActiveSheet.Columns[SpdColNo.YCLBH, SpdColNo.ZKSL-1].CellType = textCellType;
               // fspd.ActiveSheet.Columns[SpdColNo.YCLBH, SpdColNo.ZKSL-1].Width = 108F;


                fspd.ActiveSheet.Columns[SpdColNo.SPSL + 1, SpdColNo.SPACE].CellType = textCellType;
                //fspd.ActiveSheet.Columns[SpdColNo.SPSL+1, SpdColNo.SPACE].Width = 108F;



                fspd.ActiveSheet.Columns[SpdColNo.YCLRKLOTNO].Width = 200F;



                //fspd.ActiveSheet.Columns.Get(SpdColNo.PDRQ).Width = 100F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLBH).Width = 145F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLLX).Width = 80F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.DW).Width = 90F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.SPSL).Width = 122F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.ZKSL).Width = 123F;
                fspd.ActiveSheet.Columns.Get(SpdColNo.BZ).Width = 175F; 


                fspd.ActiveSheet.Columns.Get(SpdColNo.SPACE, SpdColNo.SPACE +3).Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.SFZ, SpdColNo.EMAIL].Width = 110F;



                NumberCellType NumberCellType = new NumberCellType();
                NumberCellType.DecimalPlaces = 4;
                NumberCellType.MaximumValue = 99999999.9999;
                NumberCellType.MinimumValue = 0;
                NumberCellType.Separator = ",";
                NumberCellType.ShowSeparator = true;
                fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].CellType = NumberCellType;
               // fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].Width = 80F;

                fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].CellType = NumberCellType;
              

                //隐藏后面的信息    
                //fspd.ActiveSheet.Columns[SpdColNo.GW, SpdColNo.GW].Visible = false;//岗位 不显示20130702
               // fspd.ActiveSheet.Columns[SpdColNo.ZT, SpreadColCount - 1].Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.BJF_BZ].Visible = false; // 20130802 cpj 保健费改为 他加 项目 不显示保健费标准

               

              
                #endregion

                #region  锁定列宽和行高
               // fspd.ActiveSheet.Columns.Get(0, SpreadColCount - 1).Resizable = false;           
                #endregion

                #region 锁定列
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLBH, SpdColNo.SPACE + 1).Locked = true;
        
                fspd.ActiveSheet.Columns.Get(SpdColNo.SPSL).Locked = false;
                fspd.ActiveSheet.Columns.Get(SpdColNo.CHECK).Locked = false;
                fspd.ActiveSheet.Columns.Get(SpdColNo.BZ).Locked = false;
                //fspd.ActiveSheet.Columns.Get(SpdColNo.ZZ, SpdColNo.EMAIL).Locked = false;
                #endregion

                #region column LABEl 
           

                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CHECK).Label = " ";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLBH).Label = "原材料";// 
                
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLLX).Label = "原材料类型";// 
               // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLBHGHS).Label = "原材料(供货商)";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLRKLOTNO).Label = "原材料入库单号";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.DW).Label = "计量单位";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZKSL).Label = "在库数";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.SPSL).Label = "实盘数";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.BZ).Label = "备注";// 

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
                    fspd.ActiveSheet.Cells[i,SpdColNo.SPSL,i, SpdColNo.BZ].BackColor = Color.Empty;
                    fspd.ActiveSheet.Cells[i, SpdColNo.SPSL, i, SpdColNo.BZ].BackColor = Color.White;  
             
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

                dtspd = _bllfed030.GetDaTaForPC08Spread(strStartRq, txtYCLBH.Text.Trim(), StaticFun.getValue(cboYCLLX), txtPDR.Text.Trim().strReplace());
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
           
                    fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text = dtspd.Rows[i][SpdDataSoureColName.YCLBH].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.YCLLX].Text = dtspd.Rows[i][SpdDataSoureColName.YCLLX].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.YCLRKLOTNO].Text = dtspd.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString();             
                    fspd.ActiveSheet.Cells[i, SpdColNo.DW].Text = dtspd.Rows[i][SpdDataSoureColName.DW].ToString();                 

                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.ZKSL].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.ZKSL].Text = KCS.ToString("N4");
                    
                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.SPSL].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.SPSL].Text = KCS.ToString("N4");

                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.SYQX].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i,SpdColNo.SYQX].Text=KCS.ToString("N0");

                    
                    fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text = dtspd.Rows[i][SpdDataSoureColName.BZ].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text = dtspd.Rows[i][SpdDataSoureColName.PDRQ].ToString();

                    fspd.ActiveSheet.Cells[i, SpdColNo.CKQF].Text = dtspd.Rows[i][SpdDataSoureColName.CKQF].ToString();
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
            try
            {
                PC13_sub winPC09 = new PC13_sub();
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

        List<Model.fed030> GetModel_fed030()
        {
            List<Model.fed030> listmodelfed030 = new List<Model.fed030>();
            Model.fed030 modelfmd010 = new Model.fed030();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.fed030();
                    modelfmd010 = fillModel_030(i);
                    listmodelfed030.Add(modelfmd010);
                }
            }
            return listmodelfed030;
        }
        List<Model.fed030> listmodelfed030 = new List<Model.fed030>();


        Model.fed030 fillModel_030(int i)
        {
            Model.fed030 modelfmd030 = new Model.fed030();
            double SPSL = 0;
            #region model 赋值         
            modelfmd030.YCLRKLOTNO = fspd.ActiveSheet.Cells[i, SpdColNo.YCLRKLOTNO].Text.Trim();
            modelfmd030.YCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            modelfmd030.DW = "002";//fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.SPSL].Text.Trim(), out SPSL);
            modelfmd030.ZKSL = SPSL * 1000;
            // modelfmd010.SYQX = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            modelfmd030.ZXPDRQ = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            modelfmd030.CKQF = "1";

            modelfmd030.GXZBH = ComForm.strUserName;
            modelfmd030.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfmd030.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfmd030.GXDMM = PublicFun.Get_SysDNBH();


          
            #endregion
            return modelfmd030;
        }

        Model.fed040 fillModel_040(int i)
        {
            Model.fed040 modelfed040 = new Model.fed040();
            double SPSL = 0;
            #region model 赋值

            if (string.IsNullOrEmpty(fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim()) == false)
            {
                modelfed040.PDRQ =DateTime.Parse(fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim()).ToString("yyyy/MM/dd");
                //dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }

            modelfed040.YCLRKLOTNO = fspd.ActiveSheet.Cells[i, SpdColNo.YCLRKLOTNO].Text.Trim();
            modelfed040.YCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();

            modelfed040.DW = "002";

             
             modelfed040.SYQX =fspd.ActiveSheet.Cells[i, SpdColNo.SYQX].Text.Trim();

            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.SPSL].Text.Trim(), out SPSL);
            modelfed040.ZKSL = SPSL*1000;
            
            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.ZKSL].Text.Trim(), out SPSL);
            modelfed040.QHZKSL = SPSL*1000;
            modelfed040.BZ = fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text.Trim();
            modelfed040.PDRNO = ComForm.strUserName; 


            modelfed040.GXZBH = ComForm.strUserName;
            modelfed040.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed040.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed040.GXDMM = PublicFun.Get_SysDNBH();


            modelfed040.RLZBH = ComForm.strUserName;
            modelfed040.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            modelfed040.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            modelfed040.RLDMM = PublicFun.Get_SysDNBH();



            #endregion
            return modelfed040;
        }

        List<Model.fed040> GetModel_fed040()
        {
            List<Model.fed040> listmodelFKD100 = new List<Model.fed040>();
            Model.fed040 modelfmd010 = new Model.fed040();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.fed040();
                    modelfmd010 = fillModel_040(i);
                    listmodelFKD100.Add(modelfmd010);
                }
            }
            return listmodelFKD100;
        }
        List<Model.fed040> listmodelfed040 = new List<Model.fed040>();



        ArrayList al = new ArrayList();
        //保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (getcheckHasTrue() > 0)
                    {
                        if ("0".Equals(ComForm.DspMsg("Q004", "")))   //是否要保存数据？
                        {
                            al = new ArrayList();
                            listmodelfed040 = GetModel_fed040();
                            listmodelfed030 = GetModel_fed030();
                            foreach (Model.fed040 modelfed040 in listmodelfed040)
                            {
                                if (string.IsNullOrEmpty(modelfed040.PDRQ) == true)// 插入
                                {
                                    modelfed040.PDRQ = dateStartRq.Value.ToString("yyyy/MM/dd");//, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                    al.Add(_bllfed040.Add_SQL(modelfed040));
                                }
                                else
                                {
                                    modelfed040.PDRQ =DateTime.Parse(modelfed040.PDRQ).ToString("yyyy/MM/dd");//, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            
                                    al.Add(_bllfed040.UpdateSql(modelfed040));
                                }
                            }

                            foreach (Model.fed030 modelfed030 in listmodelfed030)
                            {
                                al.Add(_bllfed030.UpdateSQL(modelfed030));
                            }

                            DbHelperMySql.ExecuteSqlTran(al);

                            Spd_Form_Load(); //绑定Spread的数据    
                            ComForm.DspMsg("M002", "");    //数据保存成功！
                        }
                    }
                    else
                    {
                        ComForm.DspMsg("W062", "");    
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

        private void btnC_Click(object sender, EventArgs e)
        {
            btnClose();
        }

        private void btnSYBH_Click(object sender, EventArgs e)
        {
            GetShow_SBU_FORM();
        }


        public void GetShow_SBU_FORM()
        {
            txtPDR.Focus();
            try
            {
                WinSubSYBH _SUB_FORM = new WinSubSYBH();
                if (!string.IsNullOrEmpty(this.txtPDR.Text))
                {
                    _SUB_FORM._conSYBH = this.txtPDR.Text;
                }
                else
                {
                    _SUB_FORM._conSYBH = "";
                }

                _SUB_FORM.ShowDialog();
                if (!string.IsNullOrEmpty(_SUB_FORM._strSYNAME))
                {

                    this.txtPDR.Text = _SUB_FORM._conSYBH;
                    this.txtXM.Text = _SUB_FORM._strSYNAME;

                }
                else
                {
                    this.txtPDR.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void txtPDR_Validating(object sender, CancelEventArgs e)
        {
           
            
            if (txtPDR.Text.Trim().IsNullOrEmpty())
            {
                txtXM.Text = "";            
            }
            else
            {                
               
            }
        }

        private void txtXM_TextChanged(object sender, EventArgs e)
        {

        }                

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue() > 0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        listmodelfed040 = GetModel_fed040(); ;//model赋值                       
                        foreach (Model.fed040 modelfed040 in listmodelfed040)
                        {

                            sqlList.Add(_bllfed040.Delete(modelfed040.YCLRKLOTNO,modelfed040.YCLBH,modelfed040.PDRQ));                               

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

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                try
                {
                    if (getcheckHasTrue() > 0)
                    {
                        if ("0".Equals(ComForm.DspMsg("Q004", "")))   //是否要保存数据？
                        {
                            al = new ArrayList();
                            listmodelfed040 = GetModel_fed040();
                            listmodelfed030 = GetModel_fed030();
                            foreach (Model.fed040 modelfed040 in listmodelfed040)
                            {
                                if (string.IsNullOrEmpty(modelfed040.PDRQ) == true)// 插入
                                {
                                    modelfed040.PDRQ = dateStartRq.Value.ToString("yyyy/MM/dd");//, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                    al.Add(_bllfed040.Add_SQL(modelfed040));
                                }
                                else
                                {
                                    modelfed040.PDRQ = DateTime.Parse(modelfed040.PDRQ).ToString("yyyy/MM/dd");//, System.Globalization.DateTimeFormatInfo.InvariantInfo);

                                    al.Add(_bllfed040.UpdateSql(modelfed040));
                                }
                            }

                            foreach (Model.fed030 modelfed030 in listmodelfed030)
                            {
                                al.Add(_bllfed030.UpdateSQL(modelfed030));
                            }

                            DbHelperMySql.ExecuteSqlTran(al);

                            Spd_Form_Load(); //绑定Spread的数据    
                            ComForm.DspMsg("M002", "");    //数据保存成功！
                        }
                    }
                    else
                    {
                        ComForm.DspMsg("W062", "");
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                PC13_sub winPC09 = new PC13_sub();
                winPC09.ShowDialog();
                //  BindNAME();               //绑定社员姓名检索列表
                Spd_Form_Load();         //绑定Spread的数据                
            }
            catch (Exception ex)
            {
                // Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
    }
}
