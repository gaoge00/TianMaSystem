/*----------------------------------------------------------------
            // Copyright (C) 2014 シャンデ―ル（大連事務所）
            //
            // ファイル名  ：PC28
            // ファイル内容：个得税录入
            // 
            // 作成日：2014/03/03
            // 作成者：冯璐
            //
//---------------------------------------------------------------*/
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
using System.Collections;
using Model;
using FarPoint.Win.Spread.CellType;
//using DBUtility;

namespace BSC_System
{
    public partial class PC28 : Form
    {
        public PC28()
        {
            InitializeComponent();
        }

        #region 定义变量

        BLL.fmd090 _BLLfmd090 = new BLL.fmd090();//访问数据层
        Model.fmd090 _Modelfmd090 = new Model.fmd090();//定义model封装数据
        Function.systemdate _systemdate = new Function.systemdate();//系统时间
        string controlName = string.Empty;//控件名称

        #endregion 定义变量

        #region 初始载入

        private void WinFMD220_Load(object sender, EventArgs e)
        {
            Spd_Form_Load();
        }

        #endregion 初始载入

        #region 按钮事件

        //检索按钮
        private void btn_Search_Click(object sender, EventArgs e)
        {
            Spd_Form_Load();
        }

        //清空按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue() > 0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        al = new ArrayList();
                        listmodelfed040 = GetModel_fed040();

                        foreach (Model.fmd090 modelfed040 in listmodelfed040)
                        {

                             sqlList.Add(_BLLfmd090.Delete(modelfed040.ID));                               

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

        //退出按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        #endregion 按钮事件

        #region 窗体事件

        //spread事件
        private void Spd_EnterCell(object sender, EnterCellEventArgs e)
        {
            //设定spread行获得焦点后的颜色
            if (fspd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
                {
                    this.fspd.Sheets[0].Rows[i].BackColor = Color.Empty;
                }
                if (fspd.ActiveSheet.Cells[e.Row, 0].Text.Trim() +
                    fspd.ActiveSheet.Cells[e.Row, 1].Text.Trim() +
                    fspd.ActiveSheet.Cells[e.Row, 2].Text.Trim() +
                    fspd.ActiveSheet.Cells[e.Row, 3].Text.Trim() +
                    fspd.ActiveSheet.Cells[e.Row, 4].Text.Trim() != string.Empty)
                {
                    this.fspd.ActiveSheet.Rows[e.Row].BackColor = Color.Lavender;
                }

            }
        }

        private void LR_D010_KeyDown(object sender, KeyEventArgs e)
        {
            PublicFun.EnterSendTab(sender, e);

            //功能：屏蔽ctrl+v 与 delete
            //原因：在Spread 单元格内 捕获不到按键
            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyData == (Keys.Alt | Keys.R))
            {
               // btn_Search.Focus();
                //btn_Search.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.D))
            {
                btnDelete.Focus();
                //btnSearch.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.C))
            {
                btnClear.Focus();
                btnClear.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.S))
            {
                btnSave.Focus();
                //btnSave.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.Q))
            {
                btnClose.Focus();
                btnClose.PerformClick();
            }


            //回车 转成 “Tab”

            //if (!spd.Focused)
            //    PublicFun.EnterSendTab(sender, e);



        }

        private void AWMT110_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);
        }

        private void txt_Year_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                e.Handled = true;
            }
        }

        private void txt_Mon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                e.Handled = true;
            }
        }

        private void txt_Day_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                return;
            }
            else if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                e.Handled = true;
            }
        }

        private void txt_GDSJFJS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Function.ComForm.IsNum(e);
        }

     

        //日期离开验证
      

        #region 验证日期
        private bool chkXJRQ(string year, string month, string day)
        {

            bool blnResult = true;
            Control[] ctrolYear = this.Controls.Find(year, true);
            Control[] ctrolMonth = this.Controls.Find(month, true);
            Control[] ctrolDay = this.Controls.Find(day, true);
            if (
                (ctrolYear.Length > 0 && ctrolMonth.Length > 0 && ctrolDay.Length > 0) &&
                (
                    ctrolYear[0] is TextBox &&
                    ctrolMonth[0] is TextBox &&
                    ctrolDay[0] is TextBox
                )
                )
            {
                if (
                           !(ctrolYear[0] as TextBox).Text.IsNullOrEmpty() &&
                           !(ctrolMonth[0] as TextBox).Text.IsNullOrEmpty() &&
                           !(ctrolDay[0] as TextBox).Text.IsNullOrEmpty()
                           )
                {
                    //返回 0,1,2,3   
                    string result = PublicFun.ChkDate((ctrolYear[0] as TextBox).Text, (ctrolMonth[0] as TextBox).Text, (ctrolDay[0] as TextBox).Text);
                    //返回 1  年错误

                    if (ComConst.YI.Equals(result))
                    {
                        ComForm.DspMsg("W015", ComConst.YEAR);
                        (ctrolYear[0] as TextBox).Focus();
                        return false;
                    }
                    //返回 2  月错误

                    else if (ComConst.ER.Equals(result))
                    {
                        ComForm.DspMsg("W015", ComConst.MONTH);
                        (ctrolMonth[0] as TextBox).Focus();
                        return false;
                    }
                    //返回 3  日错误

                    else if (ComConst.SAN.Equals(result))
                    {
                        ComForm.DspMsg("W015", ComConst.DAY);
                        (ctrolDay[0] as TextBox).Focus();
                        return false;
                    }
                }
            }
            else
            {
                blnResult = true;
            }
            return blnResult;
        }
        #endregion

        public void spdSetFocus(FpSpread ospd, int orow, int ocol)
        {
            if (orow >= 0 && ocol >= 0)
            {
                ospd.Focus();
                ospd.ActiveSheet.ActiveRowIndex = orow;
                ospd.ActiveSheet.ActiveColumnIndex = ocol;
            }
        }

        #region 关闭事件
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            System.GC.Collect();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C) || keyData == (Keys.Control | Keys.V))
            {
                //MessageBox.Show("不能粘贴，复制");                     
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
            //return false;            
        }

        //spread屏蔽复制粘贴
        //private void Spd_EditModeOn(object sender, EventArgs e)
        //{
        //    //FarPoint.Win.Spread.CellType.GeneralEditor tx = this.fspd.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;
        //    //tx.Click += new EventHandler(tx_Click);
        //    //tx.ContextMenu = new System.Windows.Forms.ContextMenu();
        //    //tx.MouseDown += new MouseEventHandler(tx_MouseDown);
        //}

        void tx_MouseDown(object sender, MouseEventArgs e)
        {

        }

        void tx_Click(object sender, EventArgs e)
        {

        }

        #region 屏蔽双击出现计算器
        private void Spd_SubEditorOpening(object sender, FarPoint.Win.Spread.SubEditorOpeningEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        //spread列的宽度设置最小值
        private void Spd_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {

            for (int i = 0; i < this.fspd.ActiveSheet.Columns.Count; i++)
            {
                if (this.fspd.ActiveSheet.Columns.Get(i).Width < 30)
                {
                    this.fspd.ActiveSheet.Columns.Get(i).Width = 30;//循环设置最小值为30
                }

            }
        }

        private void txtYear_Enter(object sender, EventArgs e)
        {
            controlName = ((TextBox)sender).Name;
        }

        #endregion 窗体事件

        #region 自定义方法


        //清空方法
        private void ClearForm()
        {

            if ("0".Equals(Function.ComForm.DspMsg("Q002", "")))//是否清空
            {
              //  ClearTxt();
            }
            else
            {
                PublicFun.SetFocusByName(this, controlName);
                return;
            }

        }
        #endregion 

        #region 加载 spd

        private void Spd_Form_Load() //绑定Spread的数据
        {
            try
            {
                DataTable dtspd = new DataTable();          
                dtspd = _BLLfmd090.GetList("").Tables[0];
                fspd.ActiveSheet.DataSource = null;
                fspd.ActiveSheet.RowCount = 0;
                fspd.ActiveSheet.RowCount =15;
                SetSpdFormat();
                //bool jjVisible = false;
                this.fspd.ActiveSheet.ColumnHeader.Cells.Get(0, SpdColNo.CHECK).Text = false.ToString();
                double KCS = 0;
                int YXTS = 0;
                for (int i = 0; i < dtspd.Rows.Count; i++)
                {


                    fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text = "False";

                    fspd.ActiveSheet.Cells[i, SpdColNo.ID].Text = dtspd.Rows[i][SpdDataSoureColName.ID].ToString();
                    fspd.ActiveSheet.Cells[i, SpdColNo.JSQF].Text = dtspd.Rows[i][SpdDataSoureColName.JSQF].ToString();


                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.SX].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.SX].Text = KCS.ToString("N2");

                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.XX].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.XX].Text = KCS.ToString("N2");

                    double.TryParse(dtspd.Rows[i][SpdDataSoureColName.GC].ToString(), out KCS);
                    fspd.ActiveSheet.Cells[i, SpdColNo.GC].Text = KCS.ToString("N2");
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
                    fspd.ActiveSheet.Cells[i, 0, i, SpdColNo.JSQF].BackColor = Color.Empty;
                    fspd.ActiveSheet.Cells[i, 0, i, SpdColNo.JSQF].BackColor = Color.White;

                }

                this.fspd.ActiveSheet.Rows[eRow].BackColor = Color.Lavender;
            }
        }
        #endregion 

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

            public static int ID = I++;
            public static int SX = I++;
            public static int XX = I++;
            public static int GC = I++;
            public static int JSQF = I++;
            //public static int JJ = I++;
            //public static int MS = I++;
           // public static int ZXKC = I++;
            //public static int ZDKC = I++;




            #endregion
        }
        #endregion

        #region Spread 列有意义化
        struct SpdDataSoureColName
        {
            public const string ID = "ID";
            public const string SX = "SX";
            public const string XX = "XX";
            public const string GC = "GC";
            public const string JSQF = "JSQF";

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
                fspd.ActiveSheet.Columns[SpdColNo.CHECK ].HorizontalAlignment = CellHorizontalAlignment.Center;
                ////垂直方向
                fspd.ActiveSheet.Columns[SpdColNo.CHECK, SpdColNo.JSQF].VerticalAlignment = CellVerticalAlignment.Center;

                fspd.ActiveSheet.Columns[SpdColNo.SX,SpdColNo.GC].HorizontalAlignment = CellHorizontalAlignment.Right;
              

                #endregion

                #region   spd 列宽，单元格类型设定

                CheckBoxCellType checkBoxType;
                checkBoxType = new CheckBoxCellType();
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].CellType = checkBoxType;
                fspd.ActiveSheet.Columns[SpdColNo.CHECK].Width = 23F;

                TextCellType textCellType;
                //年月
                textCellType = new TextCellType();
                fspd.ActiveSheet.Columns[SpdColNo.ID].CellType = textCellType;
                fspd.ActiveSheet.Columns[SpdColNo.ID].Width = 45F;
                //fspd.ActiveSheet.Columns[SpdColNo.SFZ, SpdColNo.EMAIL].Width = 110F;




                NumberCellType NumberCellType = new NumberCellType();
                NumberCellType.DecimalPlaces = 2;
                NumberCellType.MaximumValue = 99999999.99;
                NumberCellType.MinimumValue = 0;
                NumberCellType.Separator = ",";
                NumberCellType.ShowSeparator = true;

                fspd.ActiveSheet.Columns[SpdColNo.SX, SpdColNo.GC].CellType = NumberCellType;
                fspd.ActiveSheet.Columns[SpdColNo.SX, SpdColNo.GC].Width = 130F;

                //隐藏后面的信息    
                //fspd.ActiveSheet.Columns[SpdColNo.GW, SpdColNo.GW].Visible = false;//岗位 不显示20130702
                // fspd.ActiveSheet.Columns[SpdColNo.ZT, SpreadColCount - 1].Visible = false;
                //fspd.ActiveSheet.Columns[SpdColNo.BJF_BZ].Visible = false; // 20130802 cpj 保健费改为 他加 项目 不显示保健费标准




                #endregion

                #region  锁定列宽和行高
                fspd.ActiveSheet.Columns.Get(0, SpreadColCount - 1).Resizable = false;
                #endregion

                #region 锁定列
                fspd.ActiveSheet.Columns.Get(SpdColNo.ID).Locked = true;

                fspd.ActiveSheet.Columns.Get(SpdColNo.CHECK).Locked = false;
                //fspd.ActiveSheet.Columns.Get(SpdColNo.ZZ, SpdColNo.EMAIL).Locked = false;
                #endregion

                #region column LABEl


                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.CHECK).Label = " ";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.ID).Label = "ID";// 
                  fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.SX).Label = "上限";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.XX).Label = "下限";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.GC).Label = "公差";// 
                fspd.ActiveSheet.ColumnHeader.Columns.Get(SpdColNo.JSQF).Label = "计算区分";// 
             

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



        List<Model.fmd090> GetModel_fed040()
        {
            List<Model.fmd090> listmodelFKD100 = new List<Model.fmd090>();
            Model.fmd090 modelfmd010 = new Model.fmd090();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, SpdColNo.CHECK].Text == "True")
                {
                    modelfmd010 = new Model.fmd090();
                    modelfmd010 = fillModel_040(i);
                    listmodelFKD100.Add(modelfmd010);
                }
            }
            return listmodelFKD100;
        }
        List<Model.fmd090> listmodelfed040 = new List<Model.fmd090>();
        Model.fmd090 fillModel_040(int i)
        {
            Model.fmd090 modelfed040 = new Model.fmd090();
            double SPSL = 0;          
            int ID = 0;
            #region model 赋值

            // if (string.IsNullOrEmpty(fspd.ActiveSheet.Cells[i, SpdColNo.PDRQ].Text.Trim()) == false)
            //{
            if (string.IsNullOrEmpty(fspd.ActiveSheet.Cells[i, SpdColNo.ID].Text.Trim()) == false)
            {
                modelfed040.ADD = false;
                int.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.ID].Text.Trim(), out ID);
                modelfed040.ID = ID;
            }
            else
            {
                modelfed040.ADD = true;
            }
            //dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //}

            modelfed040.JSQF = fspd.ActiveSheet.Cells[i, SpdColNo.JSQF].Text.Trim();
           


         
            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.SX].Text.Trim(), out SPSL);
            modelfed040.SX = SPSL;

            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.XX].Text.Trim(), out SPSL);
            modelfed040.XX = SPSL;

            double.TryParse(fspd.ActiveSheet.Cells[i, SpdColNo.GC].Text.Trim(), out SPSL);

            modelfed040.GC = SPSL;
           


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
        //保存方法
        //保存按钮

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

        ArrayList al = new ArrayList();
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
                           
                            foreach (Model.fmd090 modelfed040 in listmodelfed040)
                            {
                                if (modelfed040.ADD == true)// 插入
                                {
                                    al.Add(_BLLfmd090.Add_SQL(modelfed040));
                                }
                                else
                                {
                                    al.Add(_BLLfmd090.UpdateSql(modelfed040));
                                }
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

        //退出方法
        private void CloseForm()
        {
            if ("0".Equals(Function.ComForm.DspMsg("Q001", "")))
            {
                this.Close();
            }
            else
            {
                PublicFun.SetFocusByName(this, controlName);
                return;
            }
        }

        public int spdFullRow(FpSpread ospd)
        {
            return ospd.ActiveSheet.NonEmptyRowCount;
        }

        bool Validating_number(object sender)
        {
            bool numberok = true;
            TextBox txt = (TextBox)(sender);

            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (",".Equals(txt.Text.Substring(0, 1).ToString()))
                {
                    txt.Text = txt.Text.Substring(1, txt.Text.Length - 1);
                }
            }

            string strCST = string.Empty;
            double JE = 0;

            if (double.TryParse(txt.Text.Trim(), out JE) == true)
            {
                numberok = true;
            }
            else
            {
                if (!txt.Text.Trim().IsNullOrEmpty())
                {
                    ComForm.DspMsg("W014", strCST);
                    numberok = false;
                }
            }
            if (numberok == false)
            {
                txt.Focus();
            }
            txt.Text = NFIAdd(txt.Text);
            if ("0.00".Equals(txt.Text))
            {
                txt.Text = string.Empty;
            }
            return numberok;
        }

        public string NFIAdd(string strNumber)
        {
            string strRet = strNumber;
            string strInt = string.Empty;
            string strDec = string.Empty;
            int intNum = 0;

            try
            {
                if (string.IsNullOrEmpty(strNumber) == true || strNumber == "0")
                {
                    //strRet = "0.00";
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
                    //strRet = strRet + ".00";
                    return strRet;
                }
            }
            catch
            {
                return strRet;
            }
        }

        #endregion 自定义方法

        private void cboGb_Enter(object sender, EventArgs e)
        {
            controlName = ((ComboBox)sender).Name;
        }


    }
}
