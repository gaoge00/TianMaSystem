using System;
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
    public partial class PC03 : Form
    {
        public PC03()
        {
            InitializeComponent();
        }

        private void PC03_Load(object sender, EventArgs e)
        {
            this.txtUserID .Text= ComForm.strUserName;
            this.labNAME.Text = ComForm.strSymc;
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
                return;
            }
        }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                //验证所添加的是不是全为空（2012/11/02）
                if ((string.IsNullOrEmpty(this.txtPass.Text.Trim()) == true
                    ||
                    string.IsNullOrEmpty(this.txtPass_YZ.Text.Trim()) == true
                     )
                    ||

                    this.txtPass_YZ.Text.Trim().Equals(this.txtPass.Text.Trim()) == false
                    )
                {
                    ComForm.DspMsg("W103", "");
                    return;
                }
                //验证用户名是否存在
                else
                {
                    BLL.fmd020 bllfmd020 = new BLL.fmd020();
                    bllfmd020.Update_Pass(txtPass.Text.Trim().Replace("'", ""), ComForm.strUserName);
                    ComForm.DspMsg("M002", "");
                }
            }
            catch (Exception ex)
            {
                Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.DspMsg("E013", "");
            }
        }

        private void PC03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

    }
}
