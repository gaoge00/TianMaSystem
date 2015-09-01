using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace TianMaSystem
{
    public partial class WinLogin : Form
    {

        public WinLogin()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_CanDrap);
            //this.ShowInTaskbar = false;  // 系统托盘图标可见 
        }

        BLL.fmd020 _bllfmd020 = new BLL.fmd020();
        Model.fmd020 _modelfmd020 = new Model.fmd020();
        Function.systemdate systemdate = new Function.systemdate();

        #region 拖拽功能实现Dll
        [Description("使能拖拽功能.")]
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Window_CanDrap(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HT_CAPTION = 0x0002;
            ReleaseCapture();
            //传递左键按下事件
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //btn_Login.Text = "正在登录...";
            //Application.DoEvents();
            string UserName = Function.ComForm.strUserName = txtUserName.Text.Trim().ToLower().Replace("'", "");
            ComForm.strSymc = UserNameLab.Text.Trim();
            string PassWord = txtPass.Text.Trim().Replace("'", "");

            Function.Const.SYBH = ComForm.strUserName;
            if (UserName == string.Empty) 
            {
                ComForm.DspMsg("W001", "");
                this.txtUserName.Focus();
                return;
            }
            if (PassWord == string.Empty) 
            {
                ComForm.DspMsg("W005", "");
                this.txtPass.Focus();
                return;
            }
            if (CheckUserPass(UserName, PassWord))
            {

                // 管理员权限登录，打开FirstPage菜单
                WinMenuPro fr = (WinMenuPro)Application.OpenForms["WinMenuPro"];
                if (fr != null)
                {
                    fr.Close();
                    WinMenuPro Main = new WinMenuPro();
                    Main.Show();
                }
                else
                {
                    WinMenuPro Main = new WinMenuPro();
                    Main.Show();
                }
                this.txtUserName.Focus();
                this.Hide();
                //btn_Login.Text = "登  录";
                ClearItems();


            }
            else
            {
                ComForm.DspMsg("W101", "");
                this.txtPass.Focus();
                return;
            }


        }

        private void ClearItems() 
        {
            txtUserName.Text = "";
            txtPass.Text = "";
            UserNameLab.Text = "";
        }

        private void btn_Closed_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        // 验证用户名密码是否正确
        private bool CheckUserPass(string username, string password)
        {
                DataTable dt1 = new DataTable();
                dt1 = _bllfmd020.YongHuMima_GetYM(username, password);
                if (dt1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
        }

        // 验证用户名是否存在
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (btnFromClosed.Focused)
            {
                return;
            }
            if (txtUserName.Text.ToString().Trim() != string.Empty)
            {
                this.txtUserName.Text = txtUserName.Text.ToString().PadLeft(5, '0');
            }
            else
            {
                UserNameLab.Text = string.Empty;
                
            }

            string UserNameck = Function.ComForm.strUserName = txtUserName.Text.Trim().Replace("'", "");
            if (UserNameck != string.Empty)
            {
                DataTable dt = _bllfmd020.YongHuMima_GetCorN(ComForm.strUserName);
                if (dt.Rows.Count > 0)
                {
                    this.txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    this.UserNameLab.Text = dt.Rows[0]["XM"].ToString();
                }
                else 
                {
                    this.txtUserName.Text = UserNameLab.Text = string.Empty;
                    ComForm.DspMsg("W034","");
                    txtUserName.Focus();
                    return;
                }
                dt.Clear();
            }
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Function.ComForm.IsAlphAndNum(e);
        }

        private void txtUserName1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9 || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            ComForm.IsAlphAndNum(e);
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void btnFromClosed_Click(object sender, EventArgs e)
        {
            txtUserName.CausesValidation = false;
            txtPass.CausesValidation = false;
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.ffd050 bllffd050 = new BLL.ffd050();
            bllffd050.getLLCK("",0, 1, 3);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            BLL.ffd010 B_ffd010 = new BLL.ffd010();
            string strRetSQL = string.Empty;

            //DataTable dt=B_ffd010.getRKMaxZF("2015/01/29",out strRetSQL);
            //bool bt = B_ffd010.getRKMaxZF("2015/01/29", out strRetSQL);

        
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }


        


        private void button1_Click_2(object sender, EventArgs e)
        {

            MessageBox.Show(GetPrintStatus("192.168.231.57").ToString());
           // MessageBox.Show(PrintQrCode("192.168.231.57", "RK_1_BSA601_O11-05970_150330_390,500", 1));
        }

        #region 常量

        private string ESC = "\x1B";
        private string ENQ = "\x05";
        private string STX = "\x02";
        private string ETX = "\x03";
        private string CAN = "\x18";

        #endregion
        /// <summary>
        /// 判断打印机状态
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool GetPrintStatus(string ip)
        {
            using (Socket l_objSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp),
                            l_objRecSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {

                try
                {
                    /* 发送端Socket连接 */
                    l_objSendSocket.Connect(ip, 1024);
                    /* 接收端Socket连接 */
                    l_objRecSocket.Connect(ip, 1025);
                    /* 发送请求打印机状态数据包 */

                    l_objSendSocket.Send(Encoding.Default.GetBytes(ENQ));
                    l_objSendSocket.Close();// 关闭连接

                    /* 接收打印机状态数据包 */
                    byte[] l_byteReceive = new byte[100];
                    Int32 l_intReceiveNum = l_objRecSocket.Receive(l_byteReceive);
                    l_objRecSocket.Close();// 关闭连接

                    if ((char)l_byteReceive[8] == 'A' || (char)l_byteReceive[8] == 'B'
                        || (char)l_byteReceive[8] == 'C' || (char)l_byteReceive[8] == 'D')
                    {
                        return true;
                    }
                    else if ((char)l_byteReceive[8] == '0')
                    {
                        throw new Exception("打印机处于离线状态。");

                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
