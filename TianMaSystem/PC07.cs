using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
//using DBUtility;

namespace TianMaSystem
{
    public partial class PC07 : Form
    {
        BLL.fmd030 _bllFMD030 = new BLL.fmd030();
        Model.fmd030 _modelFMD030 = new Model.fmd030();
        Function.systemdate systemdate = new Function.systemdate();
        public const string TableName = "FMD030";
        public PC07()
        {
            InitializeComponent();
        }

        private void WinFMD010_Load(object sender, EventArgs e)
        {
            try
            {
                //定义Spread 行数
                this.fspdMc.ActiveSheet.Rows.Count = 0;
                fillSPD();
                //combox绑定数据
               // comboxBind(cboGlMc, "GLMC");
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
            //string rt = cboGlMc.SelectedValue.ToString();
            //if (rt != "")
            //{
            //    string ty = rt.Substring(0, 1);
            //    string arrData = "0";

            //    if (arrData == "0" && ty == "9")
            //    {
            //        this.txtDZ.Enabled = false;
            //        this.txtZsMc.Enabled = false;
            //        this.txtSxMc.Enabled = false;

            //    }
            //    else
            //    {
            //        this.txtDZ.Enabled = true;
            //        this.txtZsMc.Enabled = true;
            //        this.txtSxMc.Enabled = true;
            //    }
            //}
            //txtDZ.Text = string.Empty;
            txtGYSMC.Text = string.Empty;
            txtGYSSLMC.Text = string.Empty;
            //Spread 绑定数据
            fillSPD();
        }
        #endregion

        #region Spread 绑定数据

        private void fillSPD()
        {
            try
            {
          
                //"" = cboGlMc.SelectedValue.ToString();
                //_modelFMD030.KHBH = txtDZ.Text.Trim();
                this.fspdMc.ActiveSheet.Rows.Count = 0;
                string strWhere=" and SCQF='0'";
                List<string> listFields=new List<string>();
                listFields.Add(" ID,GYSMC,GYSSLMC,DZ,DH,LXR");
                DataTable dtTable = DbHelperMySql.Query(DBHelper.getAllList(TableName, listFields, strWhere)).Tables[0];

                if (dtTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        this.fspdMc.ActiveSheet.Rows.Count++;
                        //往spread里填充数据
                        this.fspdMc.ActiveSheet.SetValue(i, 0, dtTable.Rows[i]["KHBH"].ToString());
                        this.fspdMc.ActiveSheet.SetValue(i, 1, dtTable.Rows[i]["KHMC"].ToString());
                        this.fspdMc.ActiveSheet.SetValue(i, 2, dtTable.Rows[i]["KHSXM"].ToString());
                       // this.fspdMc.ActiveSheet.SetValue(i, 3, dtTable.Rows[i]["sxmc"].ToString());
                    }

                    ComSpread.SpdSetFocus(fspdMc, 0, 0);
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

        private void txtDZ_KeyPress(object sender, KeyPressEventArgs e)
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
               // cboGlMc.Text = string.Empty;
                txtDZ.Text = string.Empty;
                txtGYSSLMC.Text = string.Empty;
                txtGYSMC.Text = string.Empty;
               // fspdMc.ActiveSheet.Rows.Count = 0;
               // cboGlMc.Focus();
                fillSPD();
            }
            else
            {
                //cboGlMc.Focus();
                txtDZ.Focus();
            }
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (cboGlMc.Text.strReplace().IsNullOrEmpty())
            //{
            //    ComForm.DspMsg("W002", "管理名称");
            //    cboGlMc.Focus();
            //    return;
            //}
            if (txtDZ.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "客户编号");
                txtDZ.Focus();
                return;
            }

            //判断名称KEY 是否存在
            bool chkMckey = false;
            for (int i = 0; i < fspdMc.ActiveSheet.Rows.Count; i++)
            {
                if (txtDZ.Text.Equals(ComSpread.SpdGetValue(fspdMc, i, 0)))
                {
                    chkMckey = true;
                    break;
                }
            }
            //判断名称KEY 是否存在，不存在不做删除操作
            //if (chkMckey == false)
            //{
            //    ComForm.DspMsg("W063", "客户编号");

            //    txtDZ.Focus();
            //    return;
            //}


            //chkMckey = false;
            //for (int i = 0; i < fspdMc.ActiveSheet.Rows.Count; i++)
            //{
            //    if (txtZsMc.Text.Equals(ComSpread.SpdGetValue(fspdMc, i, 1)))
            //    {
            //        chkMckey = true;                    
            //        break;
            //    }
            //}
            //判断名称KEY 是否存在，不存在不做删除操作
            if (chkMckey == false)
            {
                ComForm.DspMsg("W063", "客户名称");

                txtGYSMC.Focus();
                return;
            }

            if (Const.LING == ComForm.DspMsg("Q003", ""))
            {
                try
                {
                    //_modelFMD030.KHBH = txtDZ.Text.strReplace();
                    //_modelFMD030.KHMC = txtZsMc.Text.strReplace();
                    //_bllFMD030.Delete(_modelFMD030.KHBH, "");
                    ComForm.DspMsg("M001", "");
                    txtDZ.Focus();



                }
                catch (Exception ew)
                {
                    ComForm.DspMsg("E001", "");
                    return;
                }
                txtDZ.Text = string.Empty;
                txtGYSSLMC.Text = string.Empty;
                txtGYSMC.Text = string.Empty;
                fillSPD();
            }
        }

        //保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cboGlMc.Text.strReplace().IsNullOrEmpty())
            //{
            //    ComForm.DspMsg("W002", "管理名称");
            //    cboGlMc.Focus();
            //    return;
            //}
            if (txtDZ.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "客户编号");
                txtDZ.Focus();
                return;
            }
            if (txtGYSMC.Text.strReplace().IsNullOrEmpty())
            {
                ComForm.DspMsg("W002", "客户名称");
                txtGYSMC.Focus();
                return;

            }
            if (txtGYSSLMC.Text.strReplace().IsNullOrEmpty())
            {

                ComForm.DspMsg("W002", "缩写名称");
                txtGYSSLMC.Focus();
                return;
            }

            //if (_bllFMD030.chkMCK_ZSMC("", txtDZ.Text.strReplace(), txtZsMc.Text.strReplace()))
            //{
            //    ComForm.DspMsg("W068", "客户名称");
            //    txtZsMc.Focus();
            //    return;
            //}
            if (ComConst.LING == ComForm.DspMsg("Q004", ""))
            {

                try
                {
   
                    //_modelFMD030.KHBH = txtDZ.Text.strReplace();
                    //_modelFMD030.KHMC = txtZsMc.Text.strReplace();
                    //_modelFMD030.KHSXM = txtSxMc.Text.strReplace();
                    //_modelFMD030.ZT = "1";
                    if (DBHelper.Exists(TableName," and "))
                    {
                        //更新数据
                        //_modelFMD030.GXZBH = ComForm.strUserName;
                        //_modelFMD030.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_YMD);
                        //_modelFMD030.GXSJ = PublicFun.GetSystemDateTime(Const.Time, string.Empty);
                        //_modelFMD030.GXDMM = systemdate.Get_SysDNBH();
                        //_bllFMD030.Update(_modelFMD030);
                        ComForm.DspMsg("M002", "");
                        txtDZ.Focus();
                    }
                    else
                    {
                        //插入数据
                        //_modelFMD030.RLZBH = ComForm.strUserName;
                        //_modelFMD030.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_YMD);
                        //_modelFMD030.RLSJ = PublicFun.GetSystemDateTime(Const.Time, string.Empty);
                        //_modelFMD030.RLDMM = systemdate.Get_SysDNBH();
                        //_bllFMD030.Add(_modelFMD030);
                        ComForm.DspMsg("M002", "");
                        txtDZ.Focus();

                    }

                }
                catch (Exception ew)
                {
                    ComForm.DspMsg("E001", "");
                    ComForm.InsertErrLog(ew.ToString(), this.Name);
                    return;
                }
                txtDZ.Text = string.Empty;
                txtGYSMC.Text = string.Empty;
                txtGYSSLMC.Text = string.Empty;
                fillSPD();
                txtDZ.Focus();
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
                txtDZ.Focus();
            }
        }
        #endregion

        #region 名称KEY 自动补零

        private void txtDZ_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //if ("0".Equals(txtDZ.Text) || "00".Equals(txtDZ.Text) || "000".Equals(txtDZ.Text))
                //{
                //    txtDZ.Text = string.Empty;
                //    return;
                //}
                if (!txtDZ.Text.IsNullOrEmpty())
                {
                    txtDZ.Text = txtDZ.Text.PadLeft(6, '0');
                }
                if (DBHelper.Exists("FMD000", " and "))
                {
                    _modelFMD030 = new Model.fmd030();
                    //_modelFMD030 = _bllFMD030.GetModel(txtDZ.Text, "");
                    //txtZsMc.Text = _modelFMD030.KHMC;
                    //txtSxMc.Text = _modelFMD030.KHSXM;

                }
                else
                {
                    txtGYSMC.Text = "";
                    txtGYSSLMC.Text = "";

                }
                

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
               // string rt = cboGlMc.SelectedValue.ToString();
                //string ty = rt.Substring(0, 1);
                //string arrData = System.Configuration.ConfigurationSettings.AppSettings["QX"];

               
                txtDZ.Text = this.fspdMc.Sheets[0].Cells[e.Row, 0].Text.ToString().Trim();
                txtGYSMC.Text = this.fspdMc.Sheets[0].Cells[e.Row, 1].Text.ToString().Trim();
                txtGYSSLMC.Text = this.fspdMc.Sheets[0].Cells[e.Row, 2].Text.ToString().Trim();

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

        private void txtDZ_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDZ.Text) == false)
            //{
            //    txtDZ.Text = txtDZ.Text.PadLeft(6, '0');
            //}

        }
    }
}
