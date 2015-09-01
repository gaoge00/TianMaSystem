using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.IO;


namespace TianMaSystem
{
    public partial class WinMenuPro : Form
    {
        #region 构造函数
        public WinMenuPro()
        {
            InitializeComponent();
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_CanDrap);
            
        }
        #endregion

        #region 重写关闭
        /// <summary>
        /// ウィンドウをクローズ
        /// </summary>
        /// <param name="m"></param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        protected override void WndProc(ref Message m)
        {
            if (Function.ComConst.WM_SYSCOMMAND == m.Msg && Function.ComConst.SC_CLOSE == (int)m.WParam)
            {
                if ("0" == Function.ComForm.DspMsg("Q001", ""))
                {
                    // 删除登录信息
                    //_setloginbll.Delete(ComForm.strUserName, ComForm.strBbh, ComForm.strKslf, ComForm.strZllf);
                    this.Close();
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }

            base.WndProc(ref m);
        }
        #endregion

        #region 初始化
        BLL.Project _projectbll = new BLL.Project();
        BLL.MenuPro _menuprobll = new BLL.MenuPro();
        Function.systemdate systemdate = new Function.systemdate();

        // 系统设置是否显示。0：显示，1：不显示
        string strXtsz ="0";// System.Configuration.ConfigurationSettings.AppSettings["Xtsz"].ToString();
        #endregion

        public IntPtr IntptrHandle = IntPtr.Zero; 
        /// <summary>
        /// 窗体改变时记录主窗体的句柄(用于动态显示分辨率)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            IntptrHandle = this.Handle;
        }

        /// <summary>
        /// 根据不同分辨率,不同主界面大小调整界面控件位置(默认分辨率1280*1024)
        /// </summary>
        public void AutoUI(Control.ControlCollection container)
        {
            //根据主界面的句柄得到主窗体的大小
            Form frmMenu = (Form)Form.FromHandle(IntptrHandle);

            int w = frmMenu.Bounds.Width;
            int h = frmMenu.Bounds.Height;
            ////先在1280*1024分辨率模式下制作窗口，添加控件，并设置好布局；
            ////然后在窗口的load事件里写入如下代码即可：

            foreach (Control c in container)
            {
                if (c != null)
                {
                    c.Size = new Size(c.Width * w / 1280, c.Height * h / 1024);
                    c.Location = new Point(c.Left * w / 1280, c.Top * h / 1024);
                    foreach (Control gc in c.Controls)
                    {
                        if (gc != null)
                        {
                            gc.Size = new Size(gc.Width * w / 1280, gc.Height * h / 1024);
                            gc.Location = new Point(gc.Left * w / 1280, gc.Top * h / 1024);
                            foreach (Control gd in gc.Controls)
                            {
                                if (gd != null)
                                {
                                    gd.Size = new Size(gd.Width * w / 1280, gd.Height * h / 1024);
                                    gd.Location = new Point(gd.Left * w / 1280, gd.Top * h / 1024);

                                    foreach (Control ge in gd.Controls)
                                    {
                                        if (ge != null)
                                        {
                                            ge.Size = new Size(ge.Width * w / 1280, ge.Height * h / 1024);
                                            ge.Location = new Point(ge.Left * w / 1280, ge.Top * h / 1024);

                                            foreach (Control gf in ge.Controls)
                                            {
                                                if (gf != null)
                                                {
                                                    gf.Size = new Size(gf.Width * w / 1280, gf.Height * h / 1024);
                                                    gf.Location = new Point(gf.Left * w / 1280, gf.Top * h / 1024);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }


        //private Size beforeResizeSize = Size.Empty;

        //protected override void OnResizeBegin(EventArgs e)
        //{
        //    base.OnResizeBegin(e);
        //    beforeResizeSize = this.Size;
        //}

        //protected override void OnResizeEnd(EventArgs e)
        //{
        //    base.OnResizeEnd(e);
        //    //窗口resize之后的大小
        //    Size endResizeSize = this.Size;
        //    //获得变化比例
        //    float percentWidth = (float)endResizeSize.Width / beforeResizeSize.Width;
        //    float percentHeight = (float)endResizeSize.Height / beforeResizeSize.Height;

        //    foreach (Control control in this.Controls)
        //    {
        //        if (control is DataGridView)
        //            continue;
        //        //按比例改变控件大小
        //        control.Width = (int)(control.Width * percentWidth);
        //        control.Height = (int)(control.Height * percentHeight);
        //        //为了不使控件之间覆盖 位置也要按比例变化
        //        control.Left = (int)(control.Left * percentWidth);
        //        control.Top = (int)(control.Top * percentHeight);
        //    }
        //}

        #region 窗体加载事件
        private void MENU_Load(object sender, EventArgs e)
        {
            //AutoUI(this.Controls);

            // 初始化设置
            SetLoad();
         
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        public void SetLoad()
        {
            try
            {
                ShowLRHM();
       
                DateLab.Text = PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd");

                //// 获取社员名字
                //DataTable dt = _menuprobll.GetSymc(Const.SYBH);
                //if (0 < dt.Rows.Count)
                //{
                //    LabSybh.Text = dt.Rows[0][0].ToString();
                //}
                //else
                //{
                //    LabSybh.Text = Const.SYBH;
                //}
                //dt.Clear();

                LabSybh.Text = "您好，" + ComForm.strSymc + "( " + Const.SYBH + " )";
                btn01.Focus();
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", "");
                //MessageBox.Show("系统出现问题，请与管理员联系！");
                return;
            }
        }

        #endregion

        #region 拖拽功能实现Dll
        [Description("使能拖拽功能.")]
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Laber 左键拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lab_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HT_CAPTION = 0x0002;
            ReleaseCapture();
            //传递左键按下事件
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        /// <summary>
        /// picBox 左键拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HT_CAPTION = 0x0002;
            ReleaseCapture();
            //传递左键按下事件
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        /// <summary>
        /// panel 左键拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HT_CAPTION = 0x0002;
            ReleaseCapture();
            //传递左键按下事件
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion

        #region 时间显示事件
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    this.TimeLab.Text = systemdate.Get_SysTime();
        //}
        #endregion

        #region 按钮加载函数
        //入力画面 【MENU】
        private void ShowLRHM()
        {
            lsv01.Dock = DockStyle.None;
            btn09.SendToBack();
            btn09.Dock = DockStyle.Top;
            //btn08.SendToBack();
            //btn08.Dock = DockStyle.Top;
            btn07.SendToBack();
            btn07.Dock = DockStyle.Top;
            btn06.SendToBack();
            btn06.Dock = DockStyle.Top;
            btn05.SendToBack();
            btn05.Dock = DockStyle.Top;
            btn04.SendToBack();
            btn04.Dock = DockStyle.Top;
            btn03.SendToBack();
            btn03.Dock = DockStyle.Top;
            btn02.SendToBack();
            btn02.Dock = DockStyle.Top;
            btn01.SendToBack();
            btn01.Dock = DockStyle.Top;

            lsv01.Dock = DockStyle.Bottom;
        }


        #endregion

        #region ListView Button 事件
        private void Menu1_Button(object sender, EventArgs e)
        {
            try
            {
                GetShowListView(sender);
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", "");
                //MessageBox.Show("系统出现问题，请与管理员联系！");
                return;
            }
        }

        public void GetShowListView(object sender)
        {
            Button btn = (Button)sender;

            //listView3.Clear();
            string strName = btn.Text.ToString().Trim();
            switch (strName)
            {
                case "原材料/材料管理":
                    lsv01.Dock = DockStyle.None;
                    btn01.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Bottom;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Bottom;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Bottom;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Bottom;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Bottom;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();


                    SetListView("M01", lsv01);
                    break;

                case "配合管理":
                    lsv01.Dock = DockStyle.None;

                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Bottom;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Bottom;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Bottom;

                    btn06.SendToBack(); 
                    btn06.Dock = DockStyle.Bottom;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;
        
                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M02",lsv01);
                    break;

                case "盘库管理":
                    lsv01.Dock = DockStyle.None;

                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Bottom;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Bottom;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Bottom;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M03",lsv01);
                    break;

                case "入库管理":
                    lsv01.Dock = DockStyle.None;

                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Bottom;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Bottom;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M04", lsv01);
                    break;

                case "领料管理":
                    lsv01.Dock = DockStyle.None;

                    btn05.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Bottom;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M05", lsv01);
                    break;

                case "成品入库管理":
                    lsv01.Dock = DockStyle.None;

                    btn06.Dock = DockStyle.Top;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Bottom;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M06", lsv01);
                    break;

                case "成品出库管理":
                    lsv01.Dock = DockStyle.None;

                    btn07.Dock = DockStyle.Top;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Top;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Bottom;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M07", lsv01);
                    break;

                case "成品返品管理":
                    lsv01.Dock = DockStyle.None;

                   // btn08.Dock = DockStyle.Top;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Top;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Top;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    btn09.SendToBack();
                    btn09.Dock = DockStyle.Bottom;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M08",lsv01);
                    break;

                case "基础配置":
                    lsv01.Dock = DockStyle.None;

                    btn09.Dock = DockStyle.Top;

                    //btn08.SendToBack();
                    //btn08.Dock = DockStyle.Top;

                    btn07.SendToBack();
                    btn07.Dock = DockStyle.Top;

                    btn06.SendToBack();
                    btn06.Dock = DockStyle.Top;

                    btn05.SendToBack();
                    btn05.Dock = DockStyle.Top;

                    btn04.SendToBack();
                    btn04.Dock = DockStyle.Top;

                    btn03.SendToBack();
                    btn03.Dock = DockStyle.Top;

                    btn02.SendToBack();
                    btn02.Dock = DockStyle.Top;

                    btn01.SendToBack();
                    btn01.Dock = DockStyle.Top;

                    lsv01.Dock = DockStyle.Bottom;
                    lsv01.BringToFront();

                    SetListView("M09", lsv01);
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region 设置 listView 行高
        public void SetListView(string strNO, ListView lv)
        {
            try
            {
                lv.Items.Clear();
                DataTable dt = _projectbll.GetProject_Name(strNO);//, ComForm.strUserName
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //   设置行高   20     
                        ImageList imgList = new ImageList();
                        imgList.ImageSize = new Size(20, 20);//分别是宽和高
                        lv.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大
                        lv.SmallImageList = imageList1;
                        lv.Items.Add(dt.Rows[i]["Name"].ToString(), 2);
                    }
                }
                dt.Clear();
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", "");
                //MessageBox.Show("系统出现问题，请与管理员联系！");
                return;
            }
        }
        #endregion

        #region listView1 双击事件
        private void lV_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in ((ListView)(sender)).SelectedItems)
            {
                if (!_projectbll.existProName(lvi.Text.Trim()))
                {
                    //  不是文档画面，显现窗体函数
                    ListViewSelect(lvi.Text.Trim());
                }
                else
                {
                    //  是文档画面，显现窗体函数，下载服务器上文档

                   // ListViewSelect(lvi.Text.Trim());


                   ListViewSelectWd(lvi.Text.Trim());
                }
            }
        }
        #endregion

        #region 是文档画面，显现窗体函数
        /// <summary>
        /// 显示文档函数：把帮助文档从服务器上下载到本地机器，在打开文档。 
        /// </summary>
        private void ListViewSelectWd(string FromName)
        {
            try
            {
                // 服务器路径
                string SourcePath = System.Configuration.ConfigurationSettings.AppSettings["SourcePath"].ToString();

                // 【考勤明细录入】文件名
                string strKaoQin = System.Configuration.ConfigurationSettings.AppSettings["KaoQin"].ToString();

                // 【工资】文件名
                string strGongZi = System.Configuration.ConfigurationSettings.AppSettings["GongZi"].ToString();

                // 【帮助】文件名
                string strHelp = System.Configuration.ConfigurationSettings.AppSettings["Help"].ToString();

                switch (FromName)
                {
                    case "考勤入力用例":
                        SourcePath = SourcePath + "\\" + strKaoQin;
                        // 打开服务器文件
                        System.Diagnostics.Process.Start(SourcePath);
                        break;

                    case "工资计算用例":
                        SourcePath = SourcePath + "\\" + strGongZi;
                        // 打开服务器文件
                        System.Diagnostics.Process.Start(SourcePath);
                        break;

                    case "使用说明书":
                        SourcePath = SourcePath + "\\" + strHelp;
                        // 目标路径
                        string TargetPath = System.Configuration.ConfigurationSettings.AppSettings["TargetPath"].ToString();

                        // 帮助文档是否覆盖，true覆盖，false不覆盖
                        bool Isrewrite = true;

                        if (!System.IO.File.Exists(TargetPath + strHelp))
                        {
                            if (!System.IO.Directory.Exists(TargetPath))
                            {
                                System.IO.Directory.CreateDirectory(TargetPath);
                            }

                            // 获取服务器文档的扩展名（Extension）如：.txt - .xls - .pdf等等
                            string strExten = Path.GetExtension(SourcePath);

                            // 从服务器拷贝到本地
                            System.IO.File.Copy(SourcePath, TargetPath + strHelp, Isrewrite);

                            //// 打开本地文件
                            System.Diagnostics.Process.Start(TargetPath + strHelp);
                        }
                        else
                        {
                            //// 打开本地文件
                            System.Diagnostics.Process.Start(TargetPath + strHelp);
                        }

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("W002", "");
                //ComForm.InsertErrLog(ex.ToString(), this.Name.ToString());
            }
        }
        #endregion

        #region 不是文档画面，显现窗体函数
        /// <summary>
        /// 显现窗体函数 listView1
        /// </summary>
        private void ListViewSelect(string FromName)
        {
            try
            {
                string strForm = string.Empty;
                Form showForm = null;

                // 获取程序名称（英文）
                DataTable dt = _projectbll.GetP_PorName(FromName.Trim());
                if (0 < dt.Rows.Count)
                {
                    string P_PorName = dt.Rows[0]["P_PorName"].ToString();
                    showForm = (Form)System.Reflection.Assembly.Load("TianMaSystem").CreateInstance("TianMaSystem." + P_PorName);

                }
                dt.Clear();

                strForm = showForm.Name;
                Form fr = Application.OpenForms[strForm];
                if (fr != null)
                {
                    fr.BringToFront();
                }
                else
                {
                    showForm.MdiParent = this;
                    showForm.StartPosition = FormStartPosition.Manual;
                    showForm.Show();
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("W002", ""); 
                //ComForm.InsertErrLog(ex.ToString(), this.Name.ToString());
            }
        }
        #endregion

        #region 按钮事件 [重新登录] [退出系统]
        private void but_Click(object sender, EventArgs e)
        {
            string sBtnName = ((Button)(sender)).Name.ToString();
            switch (sBtnName)
            {
                case "btnRelogin":      // 重新登录 
                    Relogin();
                    break;

                case "btnMin":          // 最小化 
                    this.WindowState = FormWindowState.Minimized;
                    break;

                case "btnFromClosed":   // 关闭窗体 
                case "btnClosed":       // 退出系统 
                    Closed();
                    break;
            }
        }
        #endregion

        #region [重新登录] [退出系统] 函数
        /// <summary>
        /// 重新登录
        /// </summary>
        public void Relogin()
        {
            //try
            //{
            //    if ("0" == Function.ComForm.DspMsg("Q017", ""))
            //    {
            //        this.Close();
            //        WinLogin fr = (WinLogin)Application.OpenForms["WinLogin"];
            //        fr.txtNewPass1.Text = fr.txtNewPass2.Text = string.Empty;
            //        fr.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ComForm.DspMsg("E001", "");
            //    //MessageBox.Show("系统出现问题，请与管理员联系！");
            //    return;
            //}
        }


        /// <summary>
        /// 退出系统
        /// </summary>
        public void Closed()
        {
            try
            {
                if ("0" == Function.ComForm.DspMsg("Q001", ""))
                {
                    // 删除登录信息
                    WinMenuPro fr = (WinMenuPro)Application.OpenForms["WinMenuPro"];
                    if (fr != null)
                    {
                        fr.Close();
                    }
                    this.Close();
                    Application.Exit();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", "");
                //MessageBox.Show("系统出现问题，请与管理员联系！");
                return;
            }
        }
        #endregion

        private void WinMenuPro_Resize(object sender, EventArgs e)
        {
            IntptrHandle = this.Handle;
        }


    }
}
