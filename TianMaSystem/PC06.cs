/*----------------------------------------------------------------
            // Copyright (C) 2013 シャンデ―ル（大連事務所）
            //
            // ファイル名  ：PC06
            // ファイル内容：权限信息录入
            // 
            // 作成日：2014/03/03
            // 作成者：李庆林
            // 
            // 更新日：2014/03/03
            // 更新者：李庆林
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
using System.Collections;
using FarPoint.Win.Spread;
using Function;
using System.Text.RegularExpressions;

namespace BSC_System
{
    public partial class PC06 : Form
    {
        public PC06()
        {
            InitializeComponent();
        }

        #region 变量
        BLL.fmd020 _bllFmd020 = new BLL.fmd020();
        Model.fmd020 _modelFmd020 = new Model.fmd020();
        //时间的初始化
        Function.systemdate systemdate = new Function.systemdate();
        FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();
        //社员编号不存在提示2次限制
        int _CkShow = 0;
        string _GzlrQxGxlr = "WinFMD320";
        string _GzlrQxSylr = "WinFMD300";
        string _GzlrQxHz = "社员工资信息录入";
        // 保存用户信息
        ArrayList _insertUserInfo = new ArrayList();
        #endregion

        #region 窗体初始化加载模块
        private void WinFMD020_Load(object sender, EventArgs e)
        {
            SpdLoad(SpreadQX);
            SpreadQX.ActiveSheet.RowCount = 0;
            SpreadQX.Sheets[0].FrozenColumnCount = 4;
            spdFill();

        }
        #endregion

        #region spd的初始属性设置.(回车跳格,清除split,锁定行高列宽.直接更改文本)
        public static void SpdLoad(FpSpread ospd)
        {
            //回车进行到下一个单元格
            InputMap im;
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F1, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im = ospd.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F1, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            // 清除split按钮
            ospd.RowSplitBoxPolicy = SplitBoxPolicy.Never;
            ospd.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
            //锁定列宽和行高
            //ospd.ActiveSheet.Columns[0, ospd.ActiveSheet.ColumnCount - 1].Resizable = false;
            //ospd.ActiveSheet.Rows[0, ospd.ActiveSheet.RowCount - 1].Resizable = false;
            //单元格进入后文本全选.
            ospd.EditModePermanent = true;
            ospd.EditModeReplace = true;
        }
        #endregion

        #region spread数据填充
        private void spdFill()
        {
            try
            {
                //提取spd表头值
                DataTable DtTableHeader = new DataTable();
                DtTableHeader = _bllFmd020.GetProject_SelectQX(DMQF);
                //记录当前的行数
                int FlgRowNum = 0;
                SpreadQX.ActiveSheet.ColumnHeader.Columns.Count = 4;
                textCellType.TextOrientation = FarPoint.Win.TextOrientation.TextTopDown;
                FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);//Lowered
                FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);//Raised
                //FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
                FarPoint.Win.LineBorder compoundBorder1 = new FarPoint.Win.LineBorder(Color.DarkGray);
                this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, 0, 0, 3).Border = compoundBorder1;
                this.SpreadQX.ActiveSheet.Columns[3].BackColor = Color.LightGoldenrodYellow;
                for (int i = 4; i < DtTableHeader.Rows.Count + 4; i++)
                {


                    SpreadQX.ActiveSheet.ColumnHeader.Columns.Count++;

                    this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, i).Border = compoundBorder1;
                    SpreadQX.ActiveSheet.ColumnHeader.Cells[0, i].Text = DtTableHeader.Rows[FlgRowNum]["P_NAME"].ToString();
                    this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, i).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, i).VisualStyles = FarPoint.Win.VisualStyles.On;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, i).CellType = textCellType;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, i).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Rows.Get(0).Height = 140;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Columns.Get(i).Width = 26;
                    this.SpreadQX.ActiveSheet.ColumnHeader.Columns.Get(i).ForeColor = Color.Black;
                    this.SpreadQX.ActiveSheet.Columns[i].BackColor = Color.LightGoldenrodYellow;
                    FlgRowNum++;
                }

                //提取spd中用户名密码
                DataTable DtTable_LoginPass = new DataTable();
                DtTable_LoginPass = _bllFmd020.GetQuanxian_SpdGetXM(DMQF);
                SpreadQX.ActiveSheet.Rows.Count = 0;
                FarPoint.Win.Spread.CellType.CheckBoxCellType cb = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                for (int l = 0; l < DtTable_LoginPass.Rows.Count; l++)
                {
                    SpreadQX.ActiveSheet.Rows.Count++;

                    SpreadQX.Sheets[0].Rows[l].Resizable = false;
                    //绑定用户名密码
                    SpreadQX.ActiveSheet.Cells[l, 0].Text = DtTable_LoginPass.Rows[l]["USERNAME"].ToString();
                    SpreadQX.ActiveSheet.Cells[l, 1].Text = DtTable_LoginPass.Rows[l]["XM"].ToString();
                    SpreadQX.ActiveSheet.Cells[l, 2].Text = DtTable_LoginPass.Rows[l]["PASSWORD"].ToString();
                    _modelFmd020.USERNAME = DtTable_LoginPass.Rows[l]["USERNAME"].ToString();

                    _modelFmd020.DMQF = DMQF;



                    //获取此用户的权限
                    DataTable DtTable_YHQX = new DataTable();
                    DtTable_YHQX = _bllFmd020.GetQuanxian_YongHu(_modelFmd020);

                    //用户权限数据查找
                    for (int k = 0; k < DtTable_YHQX.Rows.Count; k++)
                    {

                        //用户权限与表头进行对比
                        for (int j = 4; j < SpreadQX.ActiveSheet.ColumnHeader.Columns.Count; j++)
                        {
                            //表头的字体竖着显示
                            this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, j).CellType = textCellType;
                            this.SpreadQX.ActiveSheet.ColumnHeader.Cells.Get(0, j).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            this.SpreadQX.ActiveSheet.Columns[0, j].Resizable = false;
                            this.SpreadQX.ActiveSheet.ColumnHeader.Rows.Get(0).Height = 140;
                            this.SpreadQX.ActiveSheet.ColumnHeader.Columns.Get(j).Width = 26;

                            //把表格变成checkbox
                            SpreadQX.ActiveSheet.Cells[l, j].CellType = cb;
                            this.SpreadQX.ActiveSheet.Cells.Get(l, j).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            if (DtTable_YHQX.Rows[k]["p_name"].ToString().Trim().Equals(SpreadQX.ActiveSheet.ColumnHeader.Cells[0, j].Text.ToString().Trim()))
                            {

                                SpreadQX.ActiveSheet.Cells[l, j].Value = true;
                            }

                        }
                    }

                    //离社人员变红
                    string IsLeave = DtTable_LoginPass.Rows[l]["TSQF"].ToString();
                    if (IsLeave.Equals("1") == false)
                    {
                        this.SpreadQX.ActiveSheet.Rows[l].ForeColor = Color.Red;
                    }
                }


                if (SpreadQX.ActiveSheet.Rows.Count > 0)
                {
                    SpreadQX.ActiveSheet.Cells[0, 3, SpreadQX.ActiveSheet.Rows.Count - 1, SpreadQX.ActiveSheet.ColumnCount - 1].Locked = true;
                }
                //隐藏列 设置当用户名密码为空时不保存
                SpreadQX.ActiveSheet.ColumnHeader.Columns.Count++;
                FarPoint.Win.Spread.CellType.TextCellType tx = new FarPoint.Win.Spread.CellType.TextCellType();
                SpreadQX.Sheets[0].Columns[SpreadQX.ActiveSheet.ColumnHeader.Columns.Count - 1].CellType = tx;
                this.SpreadQX.ActiveSheet.ColumnHeader.Columns.Get(SpreadQX.ActiveSheet.ColumnHeader.Columns.Count - 1).Width = 15;
                for (int ah = 0; ah < SpreadQX.ActiveSheet.RowCount; ah++)
                {
                    SpreadQX.ActiveSheet.Cells[ah, SpreadQX.ActiveSheet.ColumnHeader.Columns.Count - 1].Text = SpreadQX.ActiveSheet.Cells[ah, 0].Text.Trim().ToString();
                }
                SpreadQX.Sheets[0].SetColumnVisible(SpreadQX.ActiveSheet.ColumnHeader.Columns.Count - 1, false);
                setBackcolor(0);
                ComSpread.SpdSetFocus(SpreadQX, 0, 0);
                //查看是不是全选
                for (int q = 0; q < SpreadQX.ActiveSheet.RowCount; q++)
                {
                    if (Is_qx(q))
                    {
                        SpreadQX.ActiveSheet.Cells[q, 3].Value = true;
                    }
                }
                //表头名字要可以拖动的
                this.SpreadQX.ActiveSheet.Columns[0, 1].Resizable = true;
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
        #endregion

        #region 退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ComConst.LING == ComForm.DspMsg("Q001", ""))
            {
                System.GC.Collect();
                this.Close();
            }
        }
        #endregion

        #region 关闭按钮重写
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if (ComConst.LING == ComForm.DspMsg("Q001", ""))
                {
                    System.GC.Collect();
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

        #region 点击spread改变背景颜色
        private void SpreadQX_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                _CkShow = 0;
                for (int x = 0; x < SpreadQX.ActiveSheet.RowCount; x++)
                {
                    string chkuser = SpreadQX.ActiveSheet.Cells[x, 0].Text.ToString().Trim();
                    string chkname = SpreadQX.ActiveSheet.Cells[x, 1].Text.ToString().Trim();
                    string chkpass = SpreadQX.ActiveSheet.Cells[x, 2].Text.ToString().Trim();
                    string th = SpreadQX.ActiveSheet.Cells[x, SpreadQX.ActiveSheet.ColumnCount - 1].Text.ToString().Trim();


                    if (checkUP1(x) == false)
                    {
                        return;
                    }

                }

                if (e.Row < SpreadQX.ActiveSheet.RowCount)
                {
                    setBackcolor(e.Row);
                }
                #region
                if (e.Column >= 3
                           && e.Column < SpreadQX.ActiveSheet.ColumnCount)
                {
                    if (!e.ColumnHeader)
                    {

                        if (Convert.ToBoolean(SpreadQX.ActiveSheet.GetValue(e.Row, e.Column)) == false)
                        {
                            SpreadQX.ActiveSheet.Cells[e.Row, e.Column].Value = true;
                            if (Is_qx(e.Row))
                            {

                                SpreadQX.ActiveSheet.Cells[e.Row, 3].Value = true;
                            }

                        }
                        else
                        {
                            SpreadQX.ActiveSheet.Cells[e.Row, e.Column].Value = false;

                            SpreadQX.ActiveSheet.Cells[e.Row, 3].Value = false;
                        }
                        ComSpread.SpdSetFocus(SpreadQX, e.Row, e.Column);

                    }
                }


                if (e.Column == 1 && !e.ColumnHeader)
                {
                    ComSpread.SpdSetFocus(SpreadQX, e.Row, 0);
                }
                if (e.RowHeader)
                {
                    ComSpread.SpdSetFocus(SpreadQX, e.Row, 0);
                }


                //20100826 增加 全选
                if (e.Column == 3)
                {
                    if (!e.ColumnHeader)
                    {
                        string ccc = SpreadQX.ActiveSheet.GetValue(e.Row, e.Column).ToString();
                        if (Convert.ToBoolean(SpreadQX.ActiveSheet.GetValue(e.Row, e.Column)) == true)
                        {
                            SpreadQX.ActiveSheet.Cells[e.Row, e.Column].Value = true;
                            for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount - 1; i++)
                            {
                                SpreadQX.ActiveSheet.Cells[e.Row, i].Value = true;
                            }

                        }
                        else
                        {
                            SpreadQX.ActiveSheet.Cells[e.Row, e.Column].Value = false;
                            for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount - 1; i++)
                            {
                                SpreadQX.ActiveSheet.Cells[e.Row, i].Value = false;
                            }
                        }

                    }

                }

                #endregion 社员工资信息录入 社员信息录入
                //获取当前选中的列的标题
                string name = SpreadQX.ActiveSheet.ColumnHeader.Cells[0, SpreadQX.ActiveSheet.ActiveColumnIndex].Text.ToString().Trim();
                string selectTitle = GetTitle(name);
                if (_GzlrQxGxlr.Equals(selectTitle))
                {
                    //判断社员工资信息录入是否为选中状态
                    string zhuangtai = SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Text.Trim().ToString();
                    if (zhuangtai == "True")
                    {
                        for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount; i++)
                        {
                            //如果选中，则社员信息录入被选中
                            string name1 = SpreadQX.ActiveSheet.ColumnHeader.Cells[0, i].Text.ToString().Trim();
                            string selectTitle1 = GetTitle(name1);
                            if (_GzlrQxSylr.Equals(selectTitle1))
                            {
                                SpreadQX.ActiveSheet.Cells[e.Row, i].Value = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Comm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        //传入机能名字获取机能ID
        private string GetTitle(string name)
        {
            string getTitle = "";
            DataTable dtDou = new DataTable();
            dtDou = _bllFmd020.GetProject_TitleTF(name);
            for (int dou = 0; dou < dtDou.Rows.Count; dou++)
            {
                getTitle = dtDou.Rows[dou]["P_PorName"].ToString().Trim();
            }
            return getTitle;
        }

        #endregion

        #region 是不是全选
        private bool Is_qx(int erow)
        {
            int xz = 0;
            int userCount = 0;
            userCount = SpreadQX.ActiveSheet.ColumnCount - 1;
            for (int i = 4; i < userCount; i++)
            {
                if (Convert.ToBoolean(SpreadQX.ActiveSheet.GetValue(erow, i)) == true)
                {
                    xz++;
                }
            }

            if (xz == SpreadQX.ActiveSheet.ColumnCount - 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证所添加的是不是全为空（2012/11/02）
            if (CheckallGMisNull())
            {
                ComForm.DspMsg("W062", "");
                return;
            }
            //验证用户名是否存在
            if (XhPd())
            {
                if (SpreadQX.ActiveSheet.RowCount == 0)
                {
                    ComForm.DspMsg("W062", "");
                    return;
                }
                if (ComConst.LING == ComForm.DspMsg("Q004", ""))
                {

                    #region 提交数据
                    DbHelperMySql.ExecuteSqlTran(_insertUserInfo);
                    ComForm.DspMsg("M002", "");
                    #endregion
                    spdFill();

                }
            }

        }
        #endregion

        #region 判断如果画面所有选项都为空提示
        private bool CheckallGMisNull()
        {
            for (int i = 0; i < SpreadQX.ActiveSheet.RowCount; i++)
            {
                string isnull = SpreadQX.ActiveSheet.Cells[i, 0].Text.ToString().Trim();
                if (isnull != "")
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SpreadQX.ActiveSheet.RowCount == 0)
            {
                ComForm.DspMsg("W063", "");
                return;
            }
            if (ComConst.LING == ComForm.DspMsg("Q003", ""))
            {
                //获取当前选中列的用户名密码

                if (SpreadQX.ActiveSheet.RowCount > 0)
                {
                    _modelFmd020.USERNAME = SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 0].Text.ToString();
                    _modelFmd020.PASSWORD = SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 2].Text.ToString();
                    string th = SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ColumnCount - 1].Text.ToString().Trim();
                    if (th == "" || th == null)
                    {
                        SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 0].Text = "";
                        SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 1].Text = "";
                        SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 2].Text = "";
                        for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount - 1; i++)
                        {
                            SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, i].Value = false;
                        }
                        SpreadQX.ActiveSheet.Rows[SpreadQX.ActiveSheet.ActiveRowIndex].Remove();
                        setBackcolor(0);
                        ComSpread.SpdSetFocus(SpreadQX, 0, 0);
                    }
                    else
                    {
                        try
                        {
                            string DelUser = _bllFmd020.DeleteYongHuQX(th,DMQF);
                            DbHelperMySql.ExecuteSql(DelUser);
                            ComForm.DspMsg("M001", "");
                            spdFill();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }


                }
            }

        }
        #endregion

        #region 添加按钮
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.CellType.CheckBoxCellType cb = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            //获取当前行数和列数
            int hang = SpreadQX.ActiveSheet.Rows.Count;
            SpreadQX.ActiveSheet.Rows.Count++;
            int lie = SpreadQX.ActiveSheet.ColumnHeader.Columns.Count - 1;
            for (int co = 3; co < lie; co++)
            {
                this.SpreadQX.ActiveSheet.Cells.Get(hang, co).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                SpreadQX.ActiveSheet.Cells[hang, co].CellType = cb;
                SpreadQX.ActiveSheet.Cells[hang, co].Value = false;
                SpreadQX.ActiveSheet.Cells[hang, co].Locked = true;
                for (int i = 0; i < SpreadQX.ActiveSheet.RowCount; i++)
                {
                    this.SpreadQX.Sheets[0].Rows[i].BackColor = Color.Empty;
                }
                this.SpreadQX.ActiveSheet.Rows[hang].BackColor = Color.Lavender;
            }
            ComSpread.SpdSetFocus(SpreadQX, hang, 0);
        }
        #endregion

        #region 循环判断 yzm 是否重复
        private bool XhPd() //循环判断 yzm 是否重复 
        {   //判断用户名是否重复存在
            try
            {
                int szlen = SpreadQX.ActiveSheet.Rows.Count;
                string[] yzm = new string[szlen];
                for (int i = 0; i < szlen; i++)
                {
                    yzm[i] = SpreadQX.ActiveSheet.Cells[i, 0].Text.Trim();
                }
                int tc = 0;
                int tch = 0;
                for (int i = 0; i < szlen; i++)
                {
                    int xd = 0;
                    int erow;
                    for (int j = 0; j < szlen; j++)
                    {
                        if (SpreadQX.ActiveSheet.Cells[i, 0].Text.Trim().Equals(yzm[j].ToString())
                            && !String.IsNullOrEmpty(SpreadQX.ActiveSheet.Cells[i, 0].Text.Trim()))
                        {

                            xd++;
                            if (xd == 2)
                            {
                                erow = j;
                                tch = erow;
                                j = szlen + 1;
                            }
                        }
                    }
                    if (xd == 2)
                    {
                        i = szlen + 1;
                        tc = 2;
                    }
                }

                //如果用户名重复表明用户名已经存在
                if (tc == 2)
                {
                    ComForm.DspMsg("W035", "");
                    SetFoucs(tch, 0);

                    return false;
                }

                int colcount = SpreadQX.ActiveSheet.ColumnCount;
                //循环判断用户名密码是否为空
                for (int x = 0; x < SpreadQX.ActiveSheet.RowCount; x++)
                {
                    string chkuser = SpreadQX.ActiveSheet.Cells[x, 0].Text.ToString().Trim();
                    string chkname = SpreadQX.ActiveSheet.Cells[x, 1].Text.ToString().Trim();
                    string chkpass = SpreadQX.ActiveSheet.Cells[x, 2].Text.ToString().Trim();
                    string th = SpreadQX.ActiveSheet.Cells[x, SpreadQX.ActiveSheet.ColumnCount - 1].Text.ToString().Trim();


                    if (checkUP(x) == false)
                    {
                        x = colcount;
                        return false;
                    }


                    if (chkuser == "" && chkpass != "")
                    {

                        setBackcolor(x);
                        ComForm.DspMsg("W002", Function.ComConst.CST_YONGHUMIMA);
                        ComSpread.SpdSetFocus(SpreadQX, x, 0);
                        x = colcount;
                        return false;
                    }
                    else if (chkuser != "" && chkpass == "")
                    {

                        setBackcolor(x);
                        ComForm.DspMsg("W002", Function.ComConst.CST_YONGHUMIMA);
                        ComSpread.SpdSetFocus(SpreadQX, x, 2);
                        x = colcount;
                        return false;
                    }

                }

                //获取录入者的信息
                _modelFmd020.DMQF = DMQF;
                _modelFmd020.RLZBH = Function.ComForm.strUserName;
                _modelFmd020.RLR = systemdate.Get_SysDate();
                _modelFmd020.RLSJ = systemdate.Get_SysTime();
                _modelFmd020.RLDMM = systemdate.Get_SysDNBH();
                _modelFmd020.GXZBH = Function.ComForm.strUserName;
                _modelFmd020.GXR = systemdate.Get_SysDate();
                _modelFmd020.GXSJ = systemdate.Get_SysTime();
                _modelFmd020.GXDMM = systemdate.Get_SysDNBH();
                //获取当前社员信息后删除之前的权限
                _insertUserInfo = new ArrayList();
                _insertUserInfo.Add(_bllFmd020.DeleteUserInfo(DMQF));
                for (int x = 0; x < SpreadQX.ActiveSheet.RowCount; x++)
                {
                    //判断是新社员还是已经存在的社员
                    int Noselect = 0;
                    _modelFmd020.USERNAME = SpreadQX.ActiveSheet.Cells[x, 0].Text.ToString().Trim();
                    _modelFmd020.PASSWORD = SpreadQX.ActiveSheet.Cells[x, 2].Text.ToString().Trim().strReplace();
                    string th = SpreadQX.ActiveSheet.Cells[x, SpreadQX.ActiveSheet.ColumnCount - 1].Text.ToString().Trim();
                    //_insertUserInfo.Add(_bllFmd020.DeleteYongHuQX(th));
                    if (_modelFmd020.USERNAME == "" && _modelFmd020.PASSWORD == "" && th == "")
                    {
                        Noselect++;
                    }
                    else if (_modelFmd020.USERNAME == "" && _modelFmd020.PASSWORD == "" && th != "")
                    {
                        //如果是存在的社员，线删除用户名的权限
                        _modelFmd020.USERNAME = SpreadQX.ActiveSheet.Cells[x, SpreadQX.ActiveSheet.ColumnCount - 1].Text.ToString().Trim().PadLeft(5, '0');
                        _insertUserInfo.Add(_bllFmd020.DdeleteYongHu_KongYM(_modelFmd020));
                        Noselect++;
                    }
                    else
                    {
                        int xy = 4;

                        for (int y = 0; y < SpreadQX.ActiveSheet.ColumnCount - 5; y++)
                        {
                            //根据所选框，循环比较表头 找对应的msgid
                            string deleteqx = _modelFmd020.PGID = SpreadQX.ActiveSheet.Cells[x, xy].Text.ToString().Trim();
                            string name = SpreadQX.ActiveSheet.ColumnHeader.Cells[0, xy].Text.ToString().Trim();
                            xy++;
                            //保存到数据库
                            DataTable DtSaveInfo = new DataTable();
                            DtSaveInfo = _bllFmd020.GetProject_SelectQX(DMQF);
                            for (int i = 0; i < DtSaveInfo.Rows.Count; i++)
                            {
                                string HeadName = DtSaveInfo.Rows[i]["P_NAME"].ToString();
                                if (DMQF.Equals("0"))
                                {
                                    if (HeadName.Equals(name) && _modelFmd020.PGID == "True")
                                    {
                                        //插入到表中
                                        _modelFmd020.PGID = DtSaveInfo.Rows[i]["P_PorName"].ToString();
                                        _insertUserInfo.Add(_bllFmd020.InsertUserInfo(_modelFmd020));
                                        Noselect++;
                                    }
                                }
                                else
                                {
                                    //插入到表中
                                    if (HeadName.Equals(name) && _modelFmd020.PGID == "True")
                                    {
                                        _modelFmd020.PGID = DtSaveInfo.Rows[i]["M_ID"].ToString();
                                        _insertUserInfo.Add(_bllFmd020.InsertUserInfo(_modelFmd020));
                                        Noselect++;
                                    }
                                }

                            }

                        }

                    }
                    if (Noselect == 0)
                    {
                        ComForm.DspMsg("W006", "");
                        setBackcolor(x);
                        ComSpread.SpdSetFocus(SpreadQX, x, 0);
                        x = colcount;
                        return false;
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("1");
                ComForm.InsertErrLog(ex.ToString(), this.Name.ToString());
                return false;
            }
        }
        #endregion

        #region 单元格获取焦点
        private void SetFoucs(int erow, int ecolum)
        {
            try
            {
                setColor(erow);
                SpreadQX.Focus();
                SpreadQX.ActiveSheet.ActiveRowIndex = erow;
                SpreadQX.ActiveSheet.ActiveColumnIndex = ecolum;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("2");
                ComForm.InsertErrLog(ex.ToString(), this.Name.ToString());
            }
        }
        #endregion

        #region 变色
        private void setColor(int erow)
        {
            try
            {
                if (SpreadQX.ActiveSheet.RowCount > 0)
                {
                    #region 换行变色
                    for (int i = 0; i < SpreadQX.ActiveSheet.RowCount; i++)
                    {
                        SpreadQX.ActiveSheet.Rows[0, SpreadQX.ActiveSheet.Rows.Count - 1].BackColor = Color.Empty;
                    }


                    int ActRow = erow;
                    int count = SpreadQX.ActiveSheet.RowCount - 1;
                    if (ActRow <= count)
                    {
                        this.SpreadQX.ActiveSheet.Rows[ActRow].BackColor = Color.Lavender;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("3");
                ComForm.InsertErrLog(ex.ToString(), this.Name.ToString());
            }
        }
        #endregion

        #region 按下回车后=tab
        private void WinFMD020_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SpreadQX.Focused == false)
            {
                EnterKeyPress(e);
                //Function.ComForm.IsAlphAndNum(e);
            }
        }
        #endregion

        #region ENTER健转换成TAB健
        private void EnterKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
            if (SpreadQX.ActiveSheet.ActiveColumnIndex == 2)
            {
                if ((int)e.KeyChar == 13 || (int)e.KeyChar == 8 || e.KeyChar == '[' || e.KeyChar == ']')
                {
                    e.Handled = false;
                }
                else
                {
                    //[\u4e00-\u9fa5]  中文
                    //[\u3040-\u309F]  日文平假名
                    //[\u30A0-\u30FF]  日文片假名
                    //[\uFF00-\uFFFF]  全角字符

                    string s = e.KeyChar.ToString();
                    Regex reg = new Regex("^([\u4e00-\u9fa5]|[\u3040-\u309F]|[\u30A0-\u30FF])$");//[\uFF00-\uFFFF]|

                    bool flag = reg.Match(s).Success;
                    if (flag)
                    {
                        e.Handled = flag;
                        return;
                    }

                    //Regex reg2 = new Regex("[\u0000-\u00FF]");//[\uFF00-\uFFFF]|
                    //bool flag2 = reg.Match(s).Success;
                    //if (flag2)
                    //{
                    //    e.Handled = flag;
                    //    return;
                    //}

                    //屏蔽全角字符
                    if (Regex.IsMatch(e.KeyChar.ToString(), "[^\x00-\xff]|[\uFF00-\uFFFF]"))
                    {
                        e.Handled = true;
                        return;
                    }

                    //去掉全角空格
                    string s1 = e.KeyChar.ToString();
                    Regex reg1 = new Regex("[\u3000]");//[\uFF00-\uFFFF]|
                    bool flag1 = reg1.Match(s1).Success;
                    if (flag1)
                    {
                        e.Handled = flag1;
                        return;
                    }


                }
                return;
            }

            if (SpreadQX.ActiveSheet.ActiveColumnIndex == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }

        }
        #endregion

        #region 当spread获取焦点键盘按下
        private void SpreadQX_KeyPress(object sender, KeyPressEventArgs e)
        {

            int aa = SpreadQX.ActiveSheet.ActiveColumnIndex;
            if (SpreadQX.ActiveSheet.ActiveColumnIndex == 0)
            {
                if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9 || e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }



        }
        #endregion

        #region spread中单元格离开事件
        private void SpreadQX_LeaveCell(object sender, LeaveCellEventArgs e)
        {

            ComSpread.SpdLockCheck(SpreadQX, sender, e);


            if (checkUP(e.Row) == false)
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region LeaveCell中调用检查用户名密码是否存在
        public bool checkUP(int erow)
        {
            int ecol = 0;
            bool check_ok = true;
            string sybh1 = SpreadQX.ActiveSheet.Cells[erow, ecol].Text.ToString();
            if (sybh1 != "")
            {
                //查找社员编号是否存在
                string sybh = SpreadQX.ActiveSheet.Cells[erow, ecol].Text.ToString().PadLeft(5, '0');
                DataTable dt = new DataTable();
                dt = _bllFmd020.Select_SybhIsExit(sybh);
                if (dt.Rows.Count > 0)
                {
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].Text = dt.Rows[0]["xm"].ToString();
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Empty;
                    string istsrq = dt.Rows[0]["TSRQ"].ToString();
                    //退社日期如果有日期的背景颜色变红
                    if (istsrq.Equals("1")==false)              
                    {
                        SpreadQX.ActiveSheet.Rows[erow].ForeColor = Color.Red;
                    }
                    check_ok = true;
                    return check_ok;
                }
                else
                {
                    //社员不存在 背景颜色也变红
                    if (_CkShow == 0)
                    {
                        ComForm.DspMsg("W034", Function.ComConst.CST_SYBH);
                    }
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Red;
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].Text = "";
                    setBackcolor(erow);
                    ComSpread.SpdSetFocus(SpreadQX, erow, ecol);
                    check_ok = false;
                    _CkShow = 0;
                    return check_ok;
                }
            }
            else
            {
                SpreadQX.ActiveSheet.Cells[erow, 1].Text = "";
                SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Empty;
            }
            return check_ok;

        }
        #endregion

        #region click事件中调用检查用户名密码是否存在
        public bool checkUP1(int erow)
        {
            int ecol = 0;
            bool check_ok = true;
            string sybh1 = SpreadQX.ActiveSheet.Cells[erow, ecol].Text.ToString();
            if (sybh1 != "")
            {
                string sybh = SpreadQX.ActiveSheet.Cells[erow, ecol].Text.ToString().PadLeft(5, '0');
                DataTable dt = new DataTable();
                dt = _bllFmd020.Select_SybhIsExit(sybh);
                if (dt.Rows.Count > 0)
                {
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].Text = dt.Rows[0]["xm"].ToString();
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Empty;
                    check_ok = true;
                    return check_ok;
                }
                else
                {
                    if (_CkShow == 0)
                    {
                        ComForm.DspMsg("W034", Function.ComConst.CST_SYBH);
                        _CkShow = 1;
                    }
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Red;
                    SpreadQX.ActiveSheet.Cells[erow, ecol + 1].Text = "";
                    setBackcolor(erow);
                    ComSpread.SpdSetFocus(SpreadQX, erow, ecol);
                    check_ok = false;
                    return check_ok;
                }
            }
            else
            {
                SpreadQX.ActiveSheet.Cells[erow, 1].Text = "";
                SpreadQX.ActiveSheet.Cells[erow, ecol + 1].BackColor = Color.Empty;
            }
            return check_ok;

        }
        #endregion

        #region spread结束编辑模式
        private void SpreadQX_EditModeOff(object sender, EventArgs e)
        {
            if (SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 0].Text.ToString() != "")
            {
                string editmoff = SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 0].Text.ToString().Trim().PadLeft(5, '0');
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 0].Text = editmoff.ToString().Trim();
            }

        }
        #endregion

        #region spread按钮压下事件
        private void SpreadQX_KeyDown(object sender, KeyEventArgs e)
        {
            //2013、08、26修改 除了空格键，其他键状态不进行修改选中状态
            if (e.KeyData != Keys.Space) return;
            if (SpreadQX.ActiveSheet.RowCount == 0)
            {
                return;
            }
            string resulttf = ComSpread.SpdGetValue(SpreadQX, SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex);
            if (resulttf == "True")
            {
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Value = false;
            }
            else if (resulttf == "False")
            {
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Value = true;
            }
            else if (resulttf == "" && SpreadQX.ActiveSheet.ActiveColumnIndex == 3)
            {
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Value = true;
            }
            else
            {
                return;
            }

            if (SpreadQX.ActiveSheet.ActiveColumnIndex == 3)
            {

                if (Convert.ToBoolean(SpreadQX.ActiveSheet.GetValue(SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex)) == true)
                {
                    SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Value = true;
                    for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount; i++)
                    {
                        SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, i].Value = true;
                    }

                }
                else
                {
                    SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, SpreadQX.ActiveSheet.ActiveColumnIndex].Value = false;
                    for (int i = 4; i < SpreadQX.ActiveSheet.ColumnCount; i++)
                    {
                        SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, i].Value = false;
                    }
                }


            }

            //查看是否全选   2013/08/26 添加
            if (Is_qx(SpreadQX.ActiveSheet.ActiveRowIndex))
            {
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 3].Value = true;
            }
            else
            {
                SpreadQX.ActiveSheet.Cells[SpreadQX.ActiveSheet.ActiveRowIndex, 3].Value = false;
            }

        }
        #endregion

        #region spread单元格进入事件
        private void SpreadQX_EnterCell(object sender, EnterCellEventArgs e)
        {
            setBackcolor(e.Row);
        }
        #endregion

        #region 设置背景行颜色
        void setBackcolor(int erow)
        {
            if (SpreadQX.ActiveSheet.RowCount > 0)
            {
                for (int i = 0; i < SpreadQX.ActiveSheet.RowCount; i++)
                {
                    this.SpreadQX.ActiveSheet.Rows[erow].BackColor = Color.Empty;
                    if (erow < SpreadQX.ActiveSheet.RowCount)
                    {

                        SpreadQX.ActiveSheet.Rows[0, SpreadQX.ActiveSheet.Rows.Count - 1].BackColor = Color.Empty;
                        SpreadQX.ActiveSheet.Rows[erow].BackColor = Color.Lavender;
                    }
                }
            }
        }
        #endregion

        #region 清除按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (SpreadQX.ActiveSheet.RowCount == 0)
            {
                ComForm.DspMsg("W002", "");
                return;
            }
            if (ComConst.LING == ComForm.DspMsg("Q002", ""))
            {
                spdFill();
            }
        }
        #endregion

        #region 复制粘贴屏蔽
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
        #endregion

        /// <summary>
        /// 右键功能屏蔽
        /// </summary>
        public class RButtonMessageFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref System.Windows.Forms.Message m)
            {
                const int WM_RBUTTONDBLCLK = 0x206;
                const int WM_RBUTTONDOWN = 0x204;
                const int WM_RBUTTONUP = 0x205;

                switch (m.Msg)
                {
                    //过滤掉所有与右键有关的消息
                    case WM_RBUTTONDBLCLK:
                    case WM_RBUTTONDOWN:
                    case WM_RBUTTONUP:
                        {
                            return true;
                        }
                    default:
                        {
                            return false;
                        }
                        break;
                }
            }
        }

        #region 开始编辑状态
        private void SpreadQX_EditModeOn(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.CellType.GeneralEditor tx = this.SpreadQX.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;
            tx.Click += new EventHandler(tx_Click);
            tx.ContextMenu = new System.Windows.Forms.ContextMenu();
            tx.MouseDown += new MouseEventHandler(tx_MouseDown);
        }

        void tx_MouseDown(object sender, MouseEventArgs e)
        {

        }

        void tx_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 屏蔽Ctrl+C 和Ctrl+V
        private void WinFMD020_KeyDown(object sender, KeyEventArgs e)
        {
            //功能：屏蔽ctrl+v 与 delete
            //原因：在Spread 单元格内 捕获不到按键
            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyData == (Keys.Alt | Keys.N))
            {
                btnAddUser.Focus();
                btnAddUser.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.D))
            {
                btnDelete.Focus();
                btnDelete.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.C))
            {
                btnClear.Focus();
                btnClear.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.S))
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            if (e.KeyData == (Keys.Alt | Keys.Q))
            {
                btnExit.Focus();
                btnExit.PerformClick();
            }


            //回车 转成 “Tab”

            if (!SpreadQX.Focused)
                PublicFun.EnterSendTab(sender, e);
        }

        #endregion

        private void SpreadQX_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            for (int i = 0; i < this.SpreadQX.ActiveSheet.ColumnCount; i++)
            {
                if (SpreadQX.ActiveSheet.Columns[i].Width < 30)
                    SpreadQX.ActiveSheet.Columns[i].Width = 30;
            }
        }

        ////声明一些API函数   
        //[DllImport("imm32.dll")]   
        //public   static   extern   IntPtr   ImmGetContext(IntPtr   hwnd);   
        //[DllImport("imm32.dll")]   
        //public   static   extern   bool   ImmGetOpenStatus(IntPtr   himc);   
        //[DllImport("imm32.dll")]   
        //public   static   extern   bool   ImmSetOpenStatus(IntPtr   himc,   bool   b);   
        //[DllImport("imm32.dll")]   
        //public   static   extern   bool   ImmGetConversionStatus(IntPtr   himc,   ref   int   lpdw,   ref   int   lpdw2);   
        //[DllImport("imm32.dll")]   
        //public   static   extern   int   ImmSimulateHotKey(IntPtr   hwnd,   int   lngHotkey);   
        //private   const   int   IME_CMODE_FULLSHAPE   =   0x8;   
        //private   const   int   IME_CHOTKEY_SHAPE_TOGGLE   =   0x11;   
        //protected   override   void   OnActivated(EventArgs   e)   
        //{   
        //        base.OnActivated(e);   
        //        IntPtr   HIme   =   ImmGetContext(this.Handle);   
        //        if   (ImmGetOpenStatus(HIme))     //如果输入法处于打开状态   
        //        {   
        //                int   iMode   =   0;   
        //                int   iSentence   =   0;   
        //                bool   bSuccess   =   ImmGetConversionStatus(HIme,   ref   iMode,   ref   iSentence);     //检索输入法信息   
        //                if   (bSuccess)   
        //                {   
        //                        if   ((iMode   &   IME_CMODE_FULLSHAPE)   >   0)       //如果是全角   
        //                                ImmSimulateHotKey(this.Handle,   IME_CHOTKEY_SHAPE_TOGGLE);     //转换成半角   
        //                }   

        //        }   
        //}

        //private void WinFMD020_Activated(object sender, EventArgs e)
        //{
        //    OnActivated(e);
        //}          

        #region  屏蔽spread 里的F2-F4的功能键
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                    return false;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion 

        string DMQF = "0";

        // pc端
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                DMQF = "0";
                spdFill();
            }
        }
        // 手持单
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                DMQF = "1";
                spdFill();
            }

        }

    }
}
