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
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using BSC_System;
//using FarPoint.Win.Spread.CellType.BarCode;
//using DBUtility;

namespace BSC_System
{
    public partial class PC33 : Form
    {
        BLL.fed030 _bllfed030 = new BLL.fed030();

        BLL.fed040 _bllfed040 = new BLL.fed040();
        Model.fed010 _modelFED030 = new Model.fed010();
        Model.fed040 _modelFED040 = new Model.fed040();

        BLL.ffd010 _bllFFD010 = new BLL.ffd010();
        BLL.ffd050 _bllFFD050 = new BLL.ffd050();
        BLL.fmd030 _bllFMD030 = new BLL.fmd030();
        Function.systemdate systemdate = new Function.systemdate();

        public PC33()
        {
            InitializeComponent();
        }
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
        private void WinFMD010_Load(object sender, EventArgs e)
        {
            try
            {
                //定义Spread 行数
                this.fspd.ActiveSheet.Rows.Count = 0;
                BindNAME();
                SetSpdFormat();
                dtJY = _bllFmd000.GetFMD030MC_KEY("08");
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

            dtJY = _bllFmd000.GetFMD030MC_KEY("08");
            //  PublicFun.comboxBind(cboJY, dtJY, 0);


            //  PublicFun.comboxBind(cboYCLLX, "ZT");


            string cpsm = string.Empty;
            cpsm = cobKh.Text.Trim();
            cobKh.DataSource = _bllFMD030.GetListPc25("").Tables[0];
            cobKh.DisplayMember = "KHMC";
            cobKh.ValueMember = "KHBH";
            cobKh.Text = null;




            cobTMLX.Items.Add(new Function.ListItem("0", "检查证(BSR)"));
            cobTMLX.Items.Add(new Function.ListItem("1", "合格证(ROHS)"));
            cobTMLX.Items.Add(new Function.ListItem("2", "箱单"));
            cobTMLX.Items.Add(new Function.ListItem("3", "其它"));
            cobTMLX.SelectedIndex = 0;
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
            public static int XDLOTNO = I++;

            public static int SPACE = I++;
            public static int YCLRKLOTNO = I++;
            public static int RKRQ = I++;
            public static int YCLBH = I++;
            public static int YCLLX = I++;
            public static int DW = I++;
            public static int ZKSL = I++;
            public static int SYQX = I++;
            public static int JY = I++;




            public static int SPACE1 = I++;
            public static int SPACE2 = I++;



            #endregion
        }
        #endregion

        #region Spread 列有意义化
        struct SpdDataSoureColName
        {
            public const string HGZBH = "HGZBH";
            public const string YCLRKLOTNO = "YCLRKLOTNO";
            public const string RKRQ = "RKRQ";
            public const string YCLBH = "YCLBH";
            public const string YCLLX = "YCLLX";
            public const string DW = "DW";
            public const string ZKSL = "ZKSL";
            public const string SYQX = "SYQX";
            public const string JY = "JY";

            public const string CLBH = "CLBH";


            //public const string YCLRKLOTNO = "YCLRKLOTNO";
            //public const string YCLBH = "YCLBH";
            //public const string RKRQ = "RKRQ";
            //public const string YCLLX = "YCLLX";
            //public const string CLBH = "CLBH";
            //public const string SYQX = "SYQX";
            //public const string DW = "DW";

            //public const string ZKSL = "ZKSL";
            //public const string RKSL = "RKSL";
            //public const string RKZ = "RKZ";
            //public const string BZ = "BZ";

        }
        #endregion
        #endregion
        #region spd 属性设置
        ///<summary>
        /// spd的初始.(回车跳格,清除split,锁定行高列宽.直接更改文本)
        ///</summary>
        ///
        DataTable dtJY = new DataTable();
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
                fspd.ActiveSheet.Columns.Get(SpdColNo.XDLOTNO, SpdColNo.YCLRKLOTNO).HorizontalAlignment = CellHorizontalAlignment.Left;
                fspd.ActiveSheet.Columns.Get(SpdColNo.ZKSL).HorizontalAlignment = CellHorizontalAlignment.Right;

                ////垂直方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.SPACE].VerticalAlignment = CellVerticalAlignment.Center;


                //fspd.ActiveSheet.Columns[SpdColNo.BZ, SpdColNo.BZ].HorizontalAlignment = CellHorizontalAlignment.Left;
                //////垂直方向
                //fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.SPACE].VerticalAlignment = CellVerticalAlignment.Center;


                #endregion

                #region   spd 列宽，单元格类型设定

                CheckBoxCellType checkBoxType;
                checkBoxType = new CheckBoxCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].CellType = checkBoxType;
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].Width = 20F;

                ComboBoxCellType combox;
                combox = new ComboBoxCellType();
                combox.Items = StaticFun.DataTableToArray(dtJY, 0);
                // combox.ItemData = StaticFun.DataTableToArray(dtJY, 1);
                fspd.ActiveSheet.Columns[SpdColNo.JY].CellType = combox;
                fspd.ActiveSheet.Columns[SpdColNo.JY].Width = 100F;

                TextCellType textCellType;
                //年月
                textCellType = new TextCellType();
                fspd.ActiveSheet.Columns[SpdColNo.XDLOTNO, SpdColNo.JY - 1].CellType = textCellType;

                //fspd.ActiveSheet.Columns[SpdColNo.HGZBH, SpdColNo.JY-1].Width = 108F;

                fspd.ActiveSheet.Columns.Get(SpdColNo.XDLOTNO).Width = 600F;//
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLRKLOTNO).Width = 145F;// 
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLBH).Width = 98F;// 
                fspd.ActiveSheet.Columns.Get(SpdColNo.RKRQ).Width = 78F;//   
                fspd.ActiveSheet.Columns.Get(SpdColNo.YCLLX).Width = 78F;//
                fspd.ActiveSheet.Columns.Get(SpdColNo.SYQX).Width = 78F;// 
                fspd.ActiveSheet.Columns.Get(SpdColNo.DW).Width = 53F;//
                fspd.ActiveSheet.Columns.Get(SpdColNo.ZKSL).Width = 98F;//
                fspd.ActiveSheet.Columns.Get(SpdColNo.JY).Width = 98F;//


                fspd.ActiveSheet.Columns.Get(SpdColNo.SPACE, SpdColNo.SPACE2).Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.SFZ, SpdColNo.EMAIL].Width = 110F;



                //NumberCellType NumberCellType = new NumberCellType();
                //NumberCellType.DecimalPlaces = 4;
                //NumberCellType.MaximumValue = 99999999.9999;
                //NumberCellType.MinimumValue = 0;
                //NumberCellType.Separator = ",";
                //NumberCellType.ShowSeparator = true;
                //fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].CellType = NumberCellType;
                //fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].Width = 80F;

                //fspd.ActiveSheet.Columns[SpdColNo.ZKSL, SpdColNo.SPSL].CellType = NumberCellType;


                //隐藏后面的信息    
                //fspd.ActiveSheet.Columns[SpdColNo.GW, SpdColNo.GW].Visible = false;//岗位 不显示20130702
                // fspd.ActiveSheet.Columns[SpdColNo.ZT, SpreadColCount - 1].Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.BJF_BZ].Visible = false; // 20130802 cpj 保健费改为 他加 项目 不显示保健费标准




                #endregion

                #region  锁定列宽和行高
                //  fspd.ActiveSheet.Columns.Get(0, SpreadColCount - 1).Resizable = true;

                //   fspd.ActiveSheet.Columns.Get(SpdColNo.HGZBH, SpdColNo.YCLRKLOTNO).Resizable = true ;   
                #endregion

                #region 锁定列
           
                fspd.ActiveSheet.Columns.Get(SpdColNo.XDLOTNO, SpdColNo.SPACE + 1).Locked = false;
                fspd.ActiveSheet.Columns.Get(SpdColNo.JY).Locked = false;
                fspd.ActiveSheet.Columns.Get(SpdColNo.CHECK).Locked = false;


                #endregion

                #region column LABEl



                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CHECK).Label = " ";// 
                if (cobTMLX.Text.Trim().Equals("箱单") == true)
                {
                    fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XDLOTNO).Label = "箱LOTNO";//
                }
                else if (cobTMLX.Text.Trim().Equals("检查证(BSR)") || cobTMLX.Text.Trim().Equals("合格证(ROHS)"))
                {
                    fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XDLOTNO).Label = "小袋LOTNO";//
                }
                else
                {
                    fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XDLOTNO).Label = "LOTNO";//
                }
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLRKLOTNO).Label = "入库单号";// 
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLBH).Label = "原材料编号";// 
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.RKRQ).Label = "入库日期";//   
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.YCLLX).Label = "原材料类型";// 

                //// fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CLBH).Label = "材料";// 

                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.SYQX).Label = "使用期限";// 
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.DW).Label = "单位";//

                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ZKSL).Label = "在库数";//
                // fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.JY).Label = "检验";//
                //   fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.RKSL).Label = "入库数";//
                //   fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.RKZ).Label = "入库者";//
                //   fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.BZ).Label = "备注";//

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
                    //fspd.ActiveSheet.Cells[i,SpdColNo.SPSL,i, SpdColNo.BZ].BackColor = Color.Empty;
                    //fspd.ActiveSheet.Cells[i, SpdColNo.SPSL, i, SpdColNo.BZ].BackColor = Color.White;  

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
                string field_LotNo="";

                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                if (cobTMLX.Text.Trim().Equals("箱单") == true)
                {
                    field_LotNo = "XLOTNO";
                }
                else
                {
                    field_LotNo = "SSXDLOTNO"; 
                }
                if (cobTMLX.Text.Trim().Equals("其它") == true)
                {
                    fspd.ActiveSheet.RowCount = 0;
                    fspd.ActiveSheet.RowCount = 500;
                }
                else
                {
                    dtspd = _bllfed030.GetDaTaForPC33Spread(strStartRq, strEndRq, txtHLPCLOTNO.Text.Trim().strReplace(), StaticFun.getValue(cobRKZF), field_LotNo);
                    fspd.ActiveSheet.DataSource = null;
                    fspd.ActiveSheet.RowCount = dtspd.Rows.Count;
                    SetSpdFormat();
                    //bool jjVisible = false;
                    this.fspd.ActiveSheet.ColumnHeader.Cells.Get(0, SpdColNo.CHECK).Text = false.ToString();
                    double KCS = 0;
                    int YXTS = 0;
                    for (int i = 0; i < dtspd.Rows.Count; i++)
                    {




                        fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text = "False";
                        fspd.ActiveSheet.Cells[i, SpdColNo.XDLOTNO].Text = dtspd.Rows[i][0].ToString();


                        // double.TryParse(dtspd.Rows[i][SpdDataSoureColName.RKSL].ToString(), out KCS);
                        // fspd.ActiveSheet.Cells[i, SpdColNo.RKSL].Text = KCS.ToString("N4");


                        // fspd.ActiveSheet.Cells[i, SpdColNo.RKZ].Text = dtspd.Rows[i][SpdDataSoureColName.RKZ].ToString();

                        //fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text = dtspd.Rows[i][SpdDataSoureColName.BZ].ToString();



                    }
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
            catch (Exception ex)
            {
                // Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        //删除按钮
        List<string> listHGZ = new List<string>();
        int getcheckHasTrue()//保存时 只要有选中的就可以 保存
        {
            int ischeckcount = 0;
            listHGZ = new List<string>();
            for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    ischeckcount++;
                    listHGZ.Add(fspd.ActiveSheet.Cells[i, SpdColNo.XDLOTNO].Text);
                    //i = fspd.ActiveSheet.RowCount;
                }
            }
            return ischeckcount;


        }

        List<Model.fed010> GetModel_fed010()
        {
            List<Model.fed010> listmodelfed030 = new List<Model.fed010>();
            Model.fed010 modelfmd010 = new Model.fed010();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.fed010();
                    modelfmd010 = fillModel_010(i);
                    listmodelfed030.Add(modelfmd010);
                }
            }
            return listmodelfed030;
        }
        List<Model.fed010> listmodelfed010 = new List<Model.fed010>();


        Model.fed010 fillModel_010(int i)
        {
            Model.fed010 modelfmd010 = new Model.fed010();
            //double SPSL = 0;
            #region model 赋值
            modelfmd010.YCLRKLOTNO = fspd.ActiveSheet.Cells[i, SpdColNo.YCLRKLOTNO].Text.Trim();
            modelfmd010.JY = _bllFmd000.GetFMD030MC_KEY("08", fspd.ActiveSheet.Cells[i, SpdColNo.JY].Value.ToString());


            //modelfmd030.YCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            //// modelfmd010.DW = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            //double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.SPSL].Text.Trim(), out SPSL);
            //modelfmd030.ZKSL = SPSL * 1000;
            //// modelfmd010.SYQX = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();
            //modelfmd030.ZXPDRQ = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //modelfmd030.CKQF = "1";

            //modelfmd030.GXZBH = ComForm.strUserName;
            //modelfmd030.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            //modelfmd030.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            //modelfmd030.GXDMM = PublicFun.Get_SysDNBH();



            #endregion
            return modelfmd010;
        }

        Model.fed040 fillModel_040(int i)
        {
            Model.fed040 modelfed040 = new Model.fed040();
            double SPSL = 0;
            // #region model 赋值

            //// if (string.IsNullOrEmpty(fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim()) == false)
            // //{
            //     modelfed040.PDRQ = fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim();
            //     //dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            // //}

            // modelfed040.YCLRKLOTNO = fspd.ActiveSheet.Cells[i, SpdColNo.YCLRKLOTNO].Text.Trim();
            // modelfed040.YCLBH = fspd.ActiveSheet.Cells[i, SpdColNo.YCLBH].Text.Trim();

            // modelfed040.DW = "001";


            //  modelfed040.SYQX =fspd.ActiveSheet.Cells[i, SpdColNo.SYQX].Text.Trim();

            // double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.SPSL].Text.Trim(), out SPSL);
            // modelfed040.ZKSL = SPSL*1000;

            // double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.ZKSL].Text.Trim(), out SPSL);
            // modelfed040.QHZKSL = SPSL*1000;
            // modelfed040.BZ = fspd.ActiveSheet.Cells[i, SpdColNo.BZ].Text.Trim();
            // modelfed040.PDRNO = ComForm.strUserName; 


            // modelfed040.GXZBH = ComForm.strUserName;
            // modelfed040.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            // modelfed040.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            // modelfed040.GXDMM = PublicFun.Get_SysDNBH();


            // modelfed040.RLZBH = ComForm.strUserName;
            // modelfed040.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
            // modelfed040.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
            // modelfed040.RLDMM = PublicFun.Get_SysDNBH();



            // #endregion
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



        private void btnDelete_Click(object sender, EventArgs e)  //删除按钮事件
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue() > 0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        //listmodelFMD100 = GetModel();//model赋值                       
                        //foreach (Model.fed040 modelFKD100 in listmodelFMD100)
                        //{

                        //   // sqlList.Add(_bllFMD010.Delete(modelFKD100.CLBH,modelFKD100.YCLBHBS));                               

                        //}
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
                            //al = new ArrayList();
                            //listmodelfed040 = GetModel_fed040();
                            //listmodelfed030 = GetModel_fed030();
                            //foreach (Model.fed040 modelfed040 in listmodelfed040)
                            //{
                            //    if (string.IsNullOrEmpty(modelfed040.PDRQ) == true)// 插入
                            //    {
                            //        modelfed040.PDRQ = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            //        al.Add(_bllfed040.Add_SQL(modelfed040));
                            //    }
                            //    else
                            //    {
                            //        al.Add(_bllfed040.UpdateSql(modelfed040));
                            //    }
                            //}

                            foreach (Model.fed010 modelfed010 in listmodelfed010)
                            {
                                al.Add(_bllfed030.UpdateSQLFed010(modelfed010));
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
        //双击列头 全选/全不选数据
        void SetCheck(bool Check)
        {
            if (Check == true)
            {
                for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
                {
                    fspd.ActiveSheet.Cells[i, 0].Text = "True";
                }
            }
            else
            {
                for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
                {
                    fspd.ActiveSheet.Cells[i, 0].Text = "False";
                }
            }
        }
        private void fspdMc_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //权限判断
              //  string rt = "";//cboGlMc.SelectedValue.ToString();
             //   string ty = rt.Substring(0, 1);

                if (e.Column == 0 && e.ColumnHeader)
                {
                    getcheckHasTrue();
                    if (listHGZ.Count == fspd.ActiveSheet.RowCount)
                    {
                        SetCheck(false);
                    }
                    else
                    {
                        SetCheck(true);
                    }
                }

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
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_SYSCOMMAND = 0x0112;
        //    const int SC_CLOSE = 0xF060;
        //    if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
        //    {

        //        //btnClose.PerformClick();
        //        btnClose();
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}
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

        }

        private void txtPDR_Validating(object sender, CancelEventArgs e)
        {



        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SetExcel();
        }

        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC16"].ToString();
        List<string> listPic = new List<string>();
        public void SetExcel()
        {
            try
            {


                #region
                al = new ArrayList();
                //listmodelfed040 = GetModel_fed040();
                listmodelfed010 = GetModel_fed010();


                #endregion


                DataTable dt = new DataTable();

                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                dt = _bllfed030.GetDaTaForPC16Spread(strStartRq, strEndRq, txtHLPCLOTNO.Text.Trim().strReplace(), StaticFun.getValue(cobTMLX));//, txtYCLBH.Text.Trim()
                int i_excel = 0;
                int indexofCLBH = 0;
                if (dt.Rows.Count > 0 && getcheckHasTrue() > 0)
                {
                    listPic = new List<string>();
                    if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                    {

                        foreach (Model.fed010 modelfed010 in listmodelfed010)
                        {
                            al.Add(_bllfed030.UpdateSQLFed010(modelfed010));
                        }
                        DbHelperMySql.ExecuteSqlTran(al);
                        dt = _bllfed030.GetDaTaForPC16Spread(strStartRq, strEndRq, txtHLPCLOTNO.Text.Trim().strReplace(), StaticFun.getValue(cobTMLX));//, txtYCLBH.Text.Trim()

                        Spd_Form_Load();
                        string path_HGZBH = "";
                        string path_CLBH = "";
                        string strCLBH = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (listHGZ.Contains(dt.Rows[i][SpdDataSoureColName.HGZBH].ToString()))
                            {
                                //Function.BarCode = new Function.BarCode();

                                Function.BarCode.Code128 _Code = new Function.BarCode.Code128();
                                _Code.ValueFont = new Font("SimSun", 10);
                                System.Drawing.Bitmap imgTemp;


                                imgTemp = Function.QrCodeHelper.GenQrCodeBitmap(dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), 60, 60);// _Code.GetCodeImage(dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), Function.BarCode.Code128.Encode.Code128B);
                                path_HGZBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeHGBH" + i.ToString() + ".gif";

                                listPic.Add(path_HGZBH);
                                WipeFile(path_HGZBH, 2);

                                //if (File.Exists(path_HGZBH))
                                //{
                                //    File.SetAttributes(path_HGZBH, FileAttributes.Normal);
                                //    File.Delete(path_HGZBH);                                
                                //}
                                imgTemp.Save(path_HGZBH, System.Drawing.Imaging.ImageFormat.Gif);
                                imgTemp.Dispose();


                                if (string.IsNullOrEmpty(dt.Rows[i][SpdDataSoureColName.CLBH].ToString()) == false)
                                {
                                    indexofCLBH = dt.Rows[i][SpdDataSoureColName.CLBH].ToString().LastIndexOf('-');
                                    if (indexofCLBH > 0)
                                    {
                                        strCLBH = dt.Rows[i][SpdDataSoureColName.CLBH].ToString().Substring(0, indexofCLBH).ToString();
                                    }
                                    imgTemp = Function.QrCodeHelper.GenQrCodeBitmap(strCLBH, 60, 60);// _Code.GetCodeImage(dt.Rows[i][SpdDataSoureColName.HGZBH].ToString().Replace("," + dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), "")
                                    //  , Function.BarCode.Code128.Encode.Code128B);
                                    path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeCLBH" + i.ToString() + ".gif";

                                    listPic.Add(path_CLBH);
                                    WipeFile(path_CLBH, 2);
                                    //if (File.Exists(path_CLBH))
                                    //{
                                    //    File.SetAttributes(path_CLBH, FileAttributes.Normal);
                                    //    File.Delete(path_CLBH);

                                    //}
                                    if (imgTemp != null)
                                    {
                                        imgTemp.Save(path_CLBH, System.Drawing.Imaging.ImageFormat.Gif);
                                    }
                                    imgTemp.Dispose();
                                }

                                if (dt.Rows[i][SpdDataSoureColName.YCLLX].ToString().Equals("B炼品"))
                                {
                                    imgTemp = Function.QrCodeHelper.GenQrCodeBitmap(dt.Rows[i][SpdDataSoureColName.YCLBH].ToString(), 60, 60);// _Code.GetCodeImage(dt.Rows[i][SpdDataSoureColName.HGZBH].ToString().Replace("," + dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), "")
                                    //  , Function.BarCode.Code128.Encode.Code128B);
                                    path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeCLBH" + i.ToString() + ".gif";

                                    listPic.Add(path_CLBH);
                                    WipeFile(path_CLBH, 2);
                                    //if (File.Exists(path_CLBH))
                                    //{
                                    //    File.SetAttributes(path_CLBH, FileAttributes.Normal);
                                    //    File.Delete(path_CLBH);

                                    //}
                                    imgTemp.Save(path_CLBH, System.Drawing.Imaging.ImageFormat.Gif);
                                    imgTemp.Dispose();
                                }



                            }


                        }


                        //int countexcel = 0;
                        beforeTime = DateTime.Now.TimeOfDay;
                        #region
                        //获取服务器时间
                        string strdm = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_Y_M_D)
                            + " " + PublicFun.GetSystemDateTime(ComConst.Time, ""))
                                        .ToString("yyyyMMddhhmmss", DateTimeFormatInfo.CurrentInfo);
                        #endregion

                        ExportBaseExcel Ebe = new ExportBaseExcel();
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC33.xls");

                        int rowstep = 8;
                        float intWidth = 0;//长度像素值
                        float intHeight = 0;

                        path_HGZBH = "";
                        path_CLBH = "";
                        Image pic;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (listHGZ.Contains(dt.Rows[i][SpdDataSoureColName.HGZBH].ToString()))
                            {
                                path_HGZBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeHGBH" + i.ToString() + ".gif";
                                path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeCLBH" + i.ToString() + ".gif";


                                // 格式刷
                                if (i_excel < listHGZ.Count - 1)
                                {
                                    Ebe.PasteSpecial(1,
                                        Ebe.GetCell(0, 0 + i_excel * rowstep),
                                        Ebe.GetCell(3, 7 + i_excel * rowstep),
                                        Ebe.GetCell(0, (i_excel + 1) * rowstep),
                                        Ebe.GetCell(3, 7 + (i_excel + 1) * rowstep), "ALL");

                                    for (int rows = 0; rows < 8; rows++)
                                    {
                                        Ebe.SetRowHeigh((i_excel + 1) * rowstep + rows, Ebe.GetRowHeigh(i_excel * rowstep + rows));
                                    }
                                }

                                #region  插入图片
                                pic = Image.FromFile(path_HGZBH);//strFilePath是该图片的绝对路径
                                intWidth = pic.Width;//长度像素值
                                intHeight = pic.Height;
                                Ebe.AddPic(3, 0 + i_excel * rowstep, path_HGZBH, intWidth, intHeight);
                                // WipeFile(path_HGZBH, 2); 
                                pic.Dispose();
                                if (string.IsNullOrEmpty(dt.Rows[i][SpdDataSoureColName.CLBH].ToString()) == false)
                                {
                                    pic = Image.FromFile(path_CLBH);//strFilePath是该图片的绝对路径
                                    intWidth = pic.Width;//长度像素值
                                    intHeight = pic.Height;

                                    Ebe.AddPic(3, 3 + i_excel * rowstep, path_CLBH, intWidth, intHeight);
                                    //WipeFile(path_CLBH, 2);
                                    pic.Dispose();
                                }
                                if (dt.Rows[i][SpdDataSoureColName.YCLLX].ToString().Equals("B炼品"))
                                {
                                    pic = Image.FromFile(path_CLBH);//strFilePath是该图片的绝对路径
                                    intWidth = pic.Width;//长度像素值
                                    intHeight = pic.Height;

                                    Ebe.AddPic(3, 3 + i_excel * rowstep, path_CLBH, intWidth, intHeight);
                                    //WipeFile(path_CLBH, 2);
                                    pic.Dispose();
                                }

                                #endregion




                                // Ebe.SetCellValue(0 + i * rowstep, 3, dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString());
                                //  Ebe.SetCellValue(2 + i * rowstep, 3, dt.Rows[i][SpdDataSoureColName.HGZBH].ToString().Replace("," + dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), ""));
                                Ebe.SetCellValue(6 + i_excel * rowstep, 1, dt.Rows[i][SpdDataSoureColName.SYQX].ToString());
                                Ebe.SetCellValue(6 + i_excel * rowstep, 3, dt.Rows[i][SpdDataSoureColName.YCLBH].ToString());

                                Ebe.SetCellValue(2 + i_excel * rowstep, 3, dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString());

                                indexofCLBH = dt.Rows[i][SpdDataSoureColName.CLBH].ToString().LastIndexOf('-');
                                if (indexofCLBH > 0)
                                {
                                    strCLBH = dt.Rows[i][SpdDataSoureColName.CLBH].ToString().Substring(0, indexofCLBH).ToString();
                                }
                                Ebe.SetCellValue(5 + i_excel * rowstep, 3, strCLBH);

                                if (dt.Rows[i][SpdDataSoureColName.YCLLX].ToString().Equals("B炼品"))
                                {
                                    Ebe.SetCellValue(5 + i_excel * rowstep, 3, dt.Rows[i][SpdDataSoureColName.YCLBH].ToString());

                                }


                                //dt.Rows[i][SpdDataSoureColName.HGZBH].ToString();
                                //   Ebe.SetCellValue(0 + i * rowstep, 0, "合格证");               

                                //  Ebe.SetCellValue(0 + i * rowstep, 2, "原材料LOTNO");

                                //  Ebe.SetCellValue(2+ i * rowstep, 2, "材料编号");

                                //  Ebe.SetCellValue(4+ i * rowstep, 0, "使用期限");

                                //  Ebe.SetCellValue(4+ i * rowstep, 2, "原材料编号");


                                if (dt.Rows[i][SpdDataSoureColName.JY].ToString().Equals("合格"))
                                {
                                    Ebe.SetBackColor(0 + i_excel * rowstep, 0, 0 + i_excel * rowstep, 0, 35);
                                }
                                i_excel++;
                            }

                        }
                        // 复制单元格 实现Ctrl+Home 组合键功能
                        Ebe.PasteSpecial(1,
                               Ebe.GetCell(3, 2),
                               Ebe.GetCell(3, 2),
                               Ebe.GetCell(3, 2),
                               Ebe.GetCell(3, 2), "ALL");



                        //path_HGZBH=System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "DEL2.JPG";
                        //pic = Image.FromFile(path_HGZBH);
                        //path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "DEL1.JPG";
                        //pic = Image.FromFile(path_CLBH);
                        //GC.Collect();

                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    path_HGZBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeHGBH" + i.ToString() + ".gif";
                        //    path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeCLBH" + i.ToString() + ".gif";
                        //    #region 删除图片
                        //    WipeFile(path_HGZBH, 4);
                        //    WipeFile(path_CLBH, 4);
                        //    #endregion
                        //}

                        //  Ebe.SetBorderValueSingle(4, 2, dt.Rows.Count + 3, dt.Columns.Count+1);


                        if (!System.IO.Directory.Exists(Save_Path))
                        {
                            System.IO.Directory.CreateDirectory(Save_Path);
                        }
                        string Save_Path1 = Save_Path + "\\" + strdm + ".xls";
                        Ebe.SaveAs(Save_Path1);
                        Ebe.ReleaseExcel();
                        Ebe.KillSpecialExcel();
                        GC.Collect();
                        ExportBaseExcel Ebe1 = new ExportBaseExcel("");
                        Ebe1.ViewFile(Save_Path1);
                        Application.DoEvents();
                        GC.Collect();
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    path_HGZBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeHGBH" + i.ToString() + ".gif";
                        //    path_CLBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeCLBH" + i.ToString() + ".gif";
                        //    #region 删除图片
                        //    WipeFile(path_HGZBH,5);
                        //    WipeFile(path_CLBH, 5);
                        //    #endregion
                        //}
                        GC.Collect();
                        Application.DoEvents();
                        deletePic();

                    }
                    else
                    {
                        KillExcelProcess();
                        return;
                    }
                }
                else
                {
                    ComForm.DspMsg("W064", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        void deletePic()
        {
            foreach (string picPath in listPic)
            {
                WipeFile(picPath, 4);
            }
        }

        public void WipeFile(string filename, int timesToWrite)
        {
            try
            {
                if (File.Exists(filename))
                {
                    //设置文件的属性为正常，这是为了防止文件是只读
                    File.SetAttributes(filename, FileAttributes.Normal);
                    //计算扇区数目
                    double sectors = Math.Ceiling(new FileInfo(filename).Length / 512.0);
                    // 创建一个同样大小的虚拟缓存
                    byte[] dummyBuffer = new byte[512];
                    // 创建一个加密随机数目生成器
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    // 打开这个文件的FileStream
                    FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
                    {
                        // 文件流位置
                        inputStream.Position = 0;
                        //循环所有的扇区
                        for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
                        {
                            //把垃圾数据填充到流中
                            rng.GetBytes(dummyBuffer);
                            // 写入文件流中
                            inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
                        }
                    }
                    // 清空文件
                    inputStream.SetLength(0);
                    // 关闭文件流
                    inputStream.Close();
                    // 清空原始日期需要
                    DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                    File.SetCreationTime(filename, dt);
                    File.SetLastAccessTime(filename, dt);
                    File.SetLastWriteTime(filename, dt);
                    // 删除文件
                    File.Delete(filename);
                }
            }
            catch (Exception)
            {
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

        private void txtHLPCLOTNO_Leave(object sender, EventArgs e)
        {

        }

        private void cobRKZF_Enter(object sender, EventArgs e)
        {
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日

            cobRKZF.DataSource = _bllFMD030.GetRKZF(strStartRq, strEndRq, txtHLPCLOTNO.Text.Trim().strReplace()).Tables[0];
            cobRKZF.DisplayMember = "KHMC";
            cobRKZF.ValueMember = "KHBH";
            //cobRKZF.Text = "";
        }

        WebDbSrv.WebDbSrv webdb = new WebDbSrv.WebDbSrv();

        //WebDbSrv.WebDbSrv webdb = new BSC_System_HT.WebDbSrv.WebDbSrv(PublicFun.GetWebSerivcesIp());       

        //WebDbSrv 

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cobKh.Text.Trim()) == true)
            {
                MessageBox.Show("请选择客户。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)48);

                cobKh.Focus();
                return;
            }
            if ((cobTMLX.Text.Trim().Equals("箱单") == true &&
                
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XDLOTNO).Label == "小袋LOTNO")
                ||
                (cobTMLX.Text.Trim().Equals("箱单") == false &&

                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XDLOTNO).Label == "箱LOTNO"))
            {
                MessageBox.Show("检索条件与数据不匹配，请重新检索！", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)48);

                btnSearch.Focus();
                return;
            }
           
            getcheckHasTrue();
            QrList = listHGZ;
            if (QrList != null || QrList.Count != 0)
            {
                listView1 = new ListView();
                //listView1.Items.Clear();
                foreach (string qrStr in QrList)
                {
                    listView1.Items.Add(new ListViewItem(qrStr));
                }

                DataTable mydt = new DataTable();
                DataTable XD_CL_PM_PH = new DataTable();
                string qrCode,
                strPrintBarCode = "";
                if (cobTMLX.Text.Trim().Equals("检查证(BSR)") == true)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        qrCode = listView1.Items[i].Text;
                        mydt = webdb.HT14_GetHgzBsrMX(qrCode.Trim(), cobKh.getValue()); //_bllFFD010.GetHgzBsrMX(qrCode.Trim(), cobKh.getValue());
                        List<string> lst = new List<string>();
                        for (int j = 0; j < mydt.Rows.Count; j++)
                        {
                            lst.Add(mydt.Rows[j][1].ToString());
                        }
                        PrintHelper.PrintHGZ(ComForm.strUserName, lst.ToArray(), 1, 1);
                    }
                }

                else if (cobTMLX.Text.Trim().Equals("合格证(ROHS)") == true)
                {

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        qrCode = listView1.Items[i].Text;
                        mydt = webdb.HT14_GetHgzRohsMX(qrCode, "", cobKh.getValue());
                        List<string> lst = new List<string>();
                        for (int j = 0; j < mydt.Rows.Count; j++)
                        {
                            lst.Add(mydt.Rows[j][1].ToString());
                        }
                        PrintHelper.PrintHGZ(ComForm.strUserName, lst.ToArray(), 1, 2);
                    }
                }
                else if (cobTMLX.Text.Trim().Equals("箱单") == true)
                {


                    string LHRQ = "";
                    int sumCount;
                    string[] listStr;
                    int iMinLHRQ;
                    int iMaxLHRQ;
                    List<string> lst = new List<string>();


                    string PH = "";
                    string PM = "";
                    string LOTNO = "";
                    string CLBH = "";
                    string SL = "";

                    listStr = getSaveDDLotNo(out sumCount);
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        strPrintBarCode = listView1.Items[i].Text;
                        sumCount = 0;


                        XD_CL_PM_PH = _bllfed030.GetDaTaForPC33_XD_CL_PM_PH(strPrintBarCode);
                        LHRQ = DateTime.Parse(LHRQ).ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        //  XD_CL_PM_PH.Rows[0]["LHRQ"].ToString().Trim();
                        iMinLHRQ = (LHRQ.Replace("/", "").Substring(1)).StringToInt();
                        iMaxLHRQ = (LHRQ.Replace("/", "").Substring(1)).StringToInt();
                        for (int j = 0; j < listStr.Length; j++)
                        {
                            string[] strArr = listStr[j].Split('_');
                            if (strArr.Length > 5)
                            {
                                if (iMaxLHRQ < strArr[4].StringToInt())
                                {
                                    iMaxLHRQ = strArr[4].StringToInt();
                                }
                            }
                        }

                        PH = XD_CL_PM_PH.Rows[0]["PH"].ToString().Trim();
                        PM = XD_CL_PM_PH.Rows[0]["PH"].ToString().Trim();
                        LOTNO = iMinLHRQ + "-" + iMaxLHRQ;
                        CLBH = XD_CL_PM_PH.Rows[0]["PH"].ToString().Trim();
                        if (CLBH.IndexOf("-") != -1)
                        {
                            CLBH = CLBH.Split('-')[0];
                        }
                        SL = strPrintBarCode.Substring(strPrintBarCode.IndexOf(",") + 1);

                        //listView1.Items[0].SubItems[1].Text = PH;
                        //listView1.Items[1].SubItems[1].Text = PM;
                        //listView1.Items[2].SubItems[1].Text = LOTNO;                       
                        //listView1.Items[3].SubItems[1].Text = CLBH;
                        //listView1.Items[4].SubItems[1].Text = SL;

                        lst.Add(PH);
                        lst.Add(PM);
                        lst.Add(LOTNO);
                        lst.Add(CLBH);
                        lst.Add(SL);

                        if (lst.Count > 0)
                        {
                            PrintHelper.PrintHGZ(ComForm.strUserName, lst.ToArray(), 1, 3);
                        }
                        else
                        {
                            //  MessageBox.Show("没有要打印的数据。");
                        }


                    }
                }
                else//打印其它二维码
                {
                    for (int i = 0; i < listHGZ.Count; i++)
                    {
                        qrCode = listHGZ[i].ToString();
                        PrintHelper.PrintQrCode(ComForm.strUserName, qrCode, 1);
                    }
 
                }


                //lblCount.Text = listView1.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("请选择要打印的数据。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)48);

            }



        }

        public string[] getSaveDDLotNo(out int sumCount)
        {
            string[] listStr = new string[listView1.Items.Count];
            int i = 0;
            sumCount = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                listStr[i] = item.SubItems[0].Text;
                sumCount += item.SubItems[1].Text.StringToInt();
                i++;
            }
            return listStr;
        }

        private List<string> _alQrList = new List<string>();
        public List<string> QrList
        {
            set { _alQrList = value; }
            get { return _alQrList; }
        }


        private System.Windows.Forms.ListView listView1;
    }
}
