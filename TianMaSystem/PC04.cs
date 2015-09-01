using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;

namespace TianMaSystem
{
    public partial class PC04 : Form
    {
        BLL.fmd000 _bllFMD000 = new BLL.fmd000();
        Model.fmd000 _modelFMD000 = new Model.fmd000();
        Function.systemdate systemdate = new Function.systemdate();
        string TableName = "FMD000";
        public PC04()
        {
            InitializeComponent();
        }

        private void WinFMD010_Load(object sender, EventArgs e)
        {
            try
            {
                //定义Spread 行数
                this.fspdMc.ActiveSheet.Rows.Count = 0;
                //combox绑定数据
                comboxBind(cboGlMc, "GLMC");
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
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
            string rt = cboGlMc.SelectedValue.ToString();
            if (rt != "")
            {
                string ty = rt.Substring(0, 1);
                string arrData = "0";

                if (arrData == "0" && ty == "9")
                {
                    this.txtMcKey.Enabled = false;
                    this.txtZsMc.Enabled = false;
                    this.txtSxMc.Enabled = false;

                }
                else
                {
                    this.txtMcKey.Enabled = true;
                    this.txtZsMc.Enabled = true;
                    this.txtSxMc.Enabled = true;
                }
            }
            txtMcKey.Text = string.Empty;
            txtZsMc.Text = string.Empty;
            txtSxMc.Text = string.Empty;
            //Spread 绑定数据
            fillSPD();
        }
        #endregion

        #region Spread 绑定数据

        private void fillSPD()
        {
            try
            {
                if (cboGlMc.Text.ToString().IsNullOrEmpty())
                {
                    this.fspdMc.ActiveSheet.Rows.Count = 0;
                    return;
                }
                _modelFMD000.GLBH = cboGlMc.getValue();
                this.fspdMc.ActiveSheet.Rows.Count = 0;
                DataTable dtTable = _bllFMD000.getspread(_modelFMD000);

                if (dtTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        this.fspdMc.ActiveSheet.Rows.Count++;
                        //往spread里填充数据
                        this.fspdMc.ActiveSheet.SetValue(i, 0, dtTable.Rows[i]["glbh"].ToString());
                        this.fspdMc.ActiveSheet.SetValue(i, 1, dtTable.Rows[i]["zsmc"].ToString());
                        this.fspdMc.ActiveSheet.SetValue(i, 2, dtTable.Rows[i]["slmc"].ToString());
                        this.fspdMc.ActiveSheet.SetValue(i, 3, dtTable.Rows[i]["ID"].ToString());
                    }

                    //ComSpread.SpdSetFocus(fspdMc, 0, 0);
                    fspdMc.ActiveSheet.Rows[0].BackColor = Color.Lavender;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.Message, this.Text);
            }
        }

        #endregion

        #region 名称key文本校验

        private void txtMcKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (ComConst.LING == ComForm.DspMsg("Q002", ""))
            {
                cboGlMc.Text = string.Empty;
                txtMcKey.Text = string.Empty;
                txtSxMc.Text = string.Empty;
                txtZsMc.Text = string.Empty;
                fspdMc.ActiveSheet.Rows.Count = 0;
                cboGlMc.Focus();
            }
            else
            {
                cboGlMc.Focus();
            }
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboGlMc.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "管理名称");
                cboGlMc.Focus();
                return;
            }

            if (lblID.Text.IsNullOrEmpty())
            {
                ComForm.DspMsg("W063", "");
                cboGlMc.Focus();
                return;
            }

            if (Const.LING == ComForm.DspMsg("Q003", ""))
            {
                try
                {
                    _modelFMD000.ID = lblID.Text.StringToInt();
                    if (DbHelperMySql.ExecuteSql(DBHelper.Del(TableName, " and ID=" + _modelFMD000.ID + "")) != -1)
                    { ComForm.DspMsg("M001", "");
                    lblID.Text = string.Empty;
                    }
                    else
                        ComForm.DspMsg("E001", "");
                    cboGlMc.Focus();
                }
                catch (Exception ew)
                {
                    ComForm.DspMsg("E001", "");
                    return;
                }
                txtMcKey.Text = string.Empty;
                txtSxMc.Text = string.Empty;
                txtZsMc.Text = string.Empty;
                fillSPD();
            }
        }

        //保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboGlMc.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "管理名称");
                cboGlMc.Focus();
                return;
            }
            if (txtMcKey.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "名称KEY");
                txtMcKey.Focus();
                return;
            }
            if (txtZsMc.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "正式名称");
                txtZsMc.Focus();
                return;

            }
           
            if (ComConst.LING == ComForm.DspMsg("Q004", ""))
            {
                try
                {
                    List<string> lisSql = new List<string>();
                    _modelFMD000.GLBH = cboGlMc.getValue() + txtMcKey.Text.strReplace();
                    _modelFMD000.ZSMC = txtZsMc.Text.strReplace();
                    _modelFMD000.SLMC = txtSxMc.Text.strReplace();
                    if (_bllFMD000.Exists(_modelFMD000.GLBH))
                    {
                        lisSql.Add(DBHelper.Del(TableName, "and GLBH='"+_modelFMD000.GLBH+"'"));
                    }
                        //插入数据
                        _modelFMD000.RLZBH = ComForm.strUserName;
                        _modelFMD000.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_YMD);
                        _modelFMD000.RLSJ = PublicFun.GetSystemDateTime(Const.Time, string.Empty);
                        _modelFMD000.RLDMM = systemdate.Get_SysDNBH();
                        lisSql.Add(DBHelper.Add(TableName, _modelFMD000));
                        if (DbHelperMySql.ExecuteSqlTran(lisSql) != -1)
                        {
                            ComForm.DspMsg("M002", "");
                        }
                        else
                        {
                            ComForm.DspMsg("E001", "");
                            ComForm.InsertErrLog("数据插入失败！", this.Name);
                        }
                        cboGlMc.Focus();
                }
                catch (Exception ew)
                {
                    ComForm.DspMsg("E001", "");
                    ComForm.InsertErrLog(ew.ToString(), this.Name);
                    return;
                }
                txtMcKey.Text = string.Empty;
                txtZsMc.Text = string.Empty;
                txtSxMc.Text = string.Empty;
                fillSPD();
            }

        }

        //退出按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ComConst.LING == ComForm.DspMsg("Q001", ""))
            {
                System.GC.Collect();
                this.Close();
            }
            else
            {
                cboGlMc.Focus();
            }
        }
        #endregion

        #region 名称KEY 自动补零

        private void txtMcKey_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMcKey.Text.IsNullOrEmpty())
                {
                    txtMcKey.Text = string.Empty;
                    return;
                }
                if (!txtMcKey.Text.IsNullOrEmpty())
                {
                    txtMcKey.Text = txtMcKey.Text.PadLeft(2, '0');
                }
                if (cboGlMc.Text.IsNullOrEmpty())
                    return;
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
                string rt = cboGlMc.SelectedValue.ToString();
                string ty = rt.Substring(0, 1);
                string arrData = System.Configuration.ConfigurationSettings.AppSettings["QX"];

                if (arrData == "0" && ty == "9")
                {
                    this.txtMcKey.Enabled = false;
                    this.txtZsMc.Enabled = false;
                    this.txtSxMc.Enabled = false;
                    return;
                }
                if (this.fspdMc.ActiveSheet.Rows.Count == 0)
                {
                    return;
                }


                txtMcKey.Text = this.fspdMc.Sheets[0].Cells[e.Row, 0].Text.ToString().Trim().Substring(2);
                txtZsMc.Text = this.fspdMc.Sheets[0].Cells[e.Row, 1].Text.ToString().Trim();
                txtSxMc.Text = this.fspdMc.Sheets[0].Cells[e.Row, 2].Text.ToString().Trim();
                lblID.Text = this.fspdMc.Sheets[0].Cells[e.Row, 3].Text.ToString().Trim();
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
            ComSpread.Spread_CellClickChangeBColor(fspdMc, e, Color.Lavender);
        }

        #endregion

        #region Spread 鼠标离开赋值颜色
        private void fspdMc_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            ComSpread.Spread_LeaveCellBColor(fspdMc, e, Color.Lavender);
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

                btnClose.PerformClick();
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        #region 设定spread 列宽最小值
        private void fspdMc_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            for (int i = 0; i < this.fspdMc.ActiveSheet.Columns.Count; i++)//循环spread 列
            {
                if (this.fspdMc.ActiveSheet.Columns.Get(i).Width < 30)//如果小于30
                {
                    this.fspdMc.ActiveSheet.Columns.Get(i).Width = 30;//设定最小值是30
                }

            }
        }
        #endregion


    }
}
