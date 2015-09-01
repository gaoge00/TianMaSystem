using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;

namespace BSC_System
{
    public partial class PC30_sub : Form
    {
        public PC30_sub()
        {
            InitializeComponent();

            string cpsm = string.Empty;
            cpsm = cobKhmc.Text.Trim();
            cobKhmc.DataSource = _bllfmd030.GetList("").Tables[0];
            cobKhmc.DisplayMember = "KHMC";
            cobKhmc.Text = null;
        }

        public PC30_sub(string strKHBH, string strKHMC, string strPmgc, string strPhgc,
            string strClbhgc, string strPmhk, string strphkh, string strClbhkh)
        {
            InitializeComponent();

            string cpsm = string.Empty;
            cpsm = cobKhmc.Text.Trim();
            cobKhmc.DataSource = _bllfmd030.GetList("").Tables[0];
            cobKhmc.DisplayMember = "KHMC";
            cobKhmc.Text = null;



            cobKhmc.Text = strKHMC;
            txtPMGC.Text = strPmgc;
            txtPHGC.Text = strPhgc;
            txtClbhgc.Text = strClbhgc;

            txtPMKH.Text = strPmhk;
            txtPHKH.Text = strphkh;
            txtClbhkh.Text = strClbhkh;



            cobKhmc.Enabled = false;
            txtPMGC.ReadOnly = txtPHGC.ReadOnly = true;
            button1.Visible = false;

        }

        BLL.fmd100 _bllfmd100 = new BLL.fmd100();
        Model.fmd100 _modelfmd100 = new Model.fmd100();
        BLL.fmd030 _bllfmd030 = new BLL.fmd030();


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

        private void PC30_sub_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PC30_sub2 Pc30_sub2 = new PC30_sub2();

            Pc30_sub2._PMGC = txtPMGC.Text.Trim();
            Pc30_sub2._PHGC = txtPHGC.Text.Trim();
            Pc30_sub2._CLBH = txtClbhgc.Text.Trim();
        
            Pc30_sub2.ShowDialog();

            if (!string.IsNullOrEmpty(Pc30_sub2._PMGC.ToString()))
            {
                txtPMGC.Text = Pc30_sub2._PMGC;
                txtPHGC.Text = Pc30_sub2._PHGC;
                txtClbhgc.Text = Pc30_sub2._CLBH;
            }
            else
            {
                txtPMGC.Text =txtPHGC.Text = txtClbhgc.Text = "";
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(cobKhmc.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                cobKhmc.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPMGC.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                txtPMGC.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPHGC.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                txtPHGC.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtClbhgc.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                txtClbhgc.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPMKH.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                txtPMKH.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPHKH.Text.Trim()))
            {
                txtPHKH.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtClbhkh.Text.Trim()))
            {
                ComForm.DspMsg("W002", "");  //项目不能为空！
                txtClbhkh.Focus();
                return;
            }

            try
            {
                if ("0".Equals(ComForm.DspMsg("Q004", "")))   //是否要保存数据？
                {

                    DataTable dtkhbh = _bllfmd030.GetList("KHMC = '"+cobKhmc.Text.Trim()+"'").Tables[0];
                    if (dtkhbh.Rows.Count > 0)
                    {
                        _modelfmd100.KHBH = dtkhbh.Rows[0]["KHBH"].ToString();
                    }
                    _modelfmd100.PMGC = txtPMGC.Text.Trim().strReplace();
                    _modelfmd100.PHGC = txtPHGC.Text.Trim().strReplace();
                    _modelfmd100.CLBHGC = txtClbhgc.Text.Trim().strReplace();

                    _modelfmd100.PMKH = txtPMKH.Text.Trim().strReplace();
                    _modelfmd100.PHKH = txtPHKH.Text.Trim().strReplace();
                    _modelfmd100.CLBHKH = txtClbhkh.Text.Trim().strReplace();

                    ArrayList al = new ArrayList();
                    if (_bllfmd100.Exists(_modelfmd100.KHBH, _modelfmd100.PMGC, _modelfmd100.PHGC,_modelfmd100.CLBHGC))  //判断
                    {
                        _modelfmd100.GXZBH = ComForm.strUserName;
                        _modelfmd100.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                        _modelfmd100.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                        _modelfmd100.GXDMM = PublicFun.Get_SysDNBH();
                        al.Add(_bllfmd100.Update(_modelfmd100));//更新
                        DbHelperMySql.ExecuteSqlTran(al);
                        ComForm.DspMsg("M002", "");    //数据保存成功！

                    }
                    else
                    {
                        _modelfmd100.RLZBH = ComForm.strUserName;
                        _modelfmd100.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                        _modelfmd100.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                        _modelfmd100.RLDMM = PublicFun.Get_SysDNBH();
                        al.Add(_bllfmd100.Add(_modelfmd100));//插入
                        DbHelperMySql.ExecuteSqlTran(al);
                        ComForm.DspMsg("M002", "");    //数据保存成功！

                        txtPMGC.Text = txtPHGC.Text = txtClbhgc.Text = 
                        txtPMKH.Text = txtPHKH.Text = txtClbhkh.Text = "";

                    }
           

                    cobKhmc.Focus();
                }
                else
                {
                    cobKhmc.Focus();
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", ""); ex.ToString();   //系统出现问题，请与管理员联系！
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            {
                System.GC.Collect();
                this.Close();
            }
            else
            {
                cobKhmc.Focus();
            }
        }

        private void PC30_sub_KeyDown(object sender, KeyEventArgs e)
        {
            PublicFun.EnterSendTab(sender, e);
        }



    }
}
