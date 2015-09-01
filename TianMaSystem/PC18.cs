using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Function;
using System.Diagnostics;
using System.Globalization;
using System.Security.Permissions;

namespace BSC_System
{
    public partial class PC18 : Form
    {
        public PC18()
        {
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC18"].ToString();
        BLL.fed050 _bllfed050 = new BLL.fed050();
        BLL.fmd010 _bllfmd010 = new BLL.fmd010();
        #endregion

        /// <summary>  
        /// 添加一个继承自textbox的新类，重写WndProc方法，在重写的方法里重绘边框就可以了  
        /// </summary>  
        /// <param name="m"></param>  
        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    borderDrawer borderDrawer1 = new borderDrawer();
        //    borderDrawer1.DrawBorder(ref m, this.Width, this.Height);
        //}

        /// <summary>
        ///重画groupBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(groupBox1.BackColor);

            //e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.Blue, 10, 1);

            //e.Graphics.DrawLine(Pens.DarkGreen, 1, 7, 8, 7);

            //e.Graphics.DrawLine(Pens.DarkGreen, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);

            //e.Graphics.DrawLine(Pens.DarkGreen, 1, 7, 1, groupBox1.Height - 2);

            //e.Graphics.DrawLine(Pens.DarkGreen, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);

            //e.Graphics.DrawLine(Pens.DarkGreen, groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2);
        }


        private void PC18_Load(object sender, EventArgs e)
        {
            LoadFrom();

            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

        public void LoadFrom()
        {
            string cpsm = string.Empty;

            // 原材料类型
            cpsm = cobYcllx.Text.Trim();
            cobYcllx.DataSource = Comm.GetConDataHash("cobYcllx");
            cobYcllx.DisplayMember = "key";
            cobYcllx.ValueMember = "value";
            cobYcllx.Text = cpsm;

            // 硫化结果
            cpsm = cobLhjg.Text.Trim();
            cobLhjg.DataSource = Comm.GetConDataHash("cobLhjg");
            cobLhjg.DisplayMember = "key";
            cobLhjg.ValueMember = "value";
            cobLhjg.Text = cpsm;

            cpsm = cobJlssz.Text.Trim();
            cobJlssz.DataSource = _bllfed050.GetSymc(" ").Tables[0];
            cobJlssz.DisplayMember = "SYMC";
            cobJlssz.Text = null;
        }

        #region Buttons 事件处理
        /// <summary>
        /// Buttons
        /// Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttons_Click(object sender, EventArgs e)
        {
            string sBtnName = ((Button)(sender)).Name.ToString();
            switch (sBtnName)
            {
                case "btnJs":       // 检索
                    SetSpd();
                    break;
                case "btnExcel":    // EXCEL
                    SetExcel();
                    break;
            }
        }
        #endregion


        public void SetSpd()
        {
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string strHlpclotno = txtLotno.Text.Trim();
            string strClbh = txtClbh.Text.Trim();
            string strLhqf = Comm.GetDataName1(cobLhjg.Text.Trim(), "cobLhjg");
            string strYcllx = Comm.GetDataName1(cobYcllx.Text.Trim(), "cobYcllx");
            string strYclbh = txtYclbh.Text.Trim();

            string strJlssz = string.Empty;
            DataTable dtsybh = _bllfmd010.GetList("symc = '"+ cobJlssz.Text.Trim() +"' ").Tables[0];
            if (0 < dtsybh.Rows.Count)
            {
                strJlssz = dtsybh.Rows[0]["SYBH"].ToString().Trim();
            }
           
            DataTable dt = _bllfed050.SetSpd(strStartRq, strEndRq, strClbh, strLhqf, strJlssz, strHlpclotno, strYclbh, strYcllx);
            Spd.ActiveSheet.DataSource = null;
            Spd.ActiveSheet.RowCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                //Spd.ActiveSheet.RowCount = 0;
                //Spd.ActiveSheet.Rows.Count = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["HLPCLOTNO"].ToString().Trim(), i, 0);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PHRQ"].ToString().Trim(), i, 1);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 2);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLBH"].ToString().Trim(), i, 3);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLLX"].ToString().Trim(), i, 4);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PHBBH"].ToString().Trim(), i, 5);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["LHJG"].ToString().Trim(), i, 6);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZL"].ToString().Trim(), i, 7);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SYMC"].ToString().Trim(), i, 8);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLRKLOTNO"].ToString().Trim(), i, 9);
                }

            }
            else
            {
                return;
            }
        }


        public void SetExcel()
        {
            try
            {
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
                string strHlpclotno = txtLotno.Text.Trim();
                string strClbh = txtClbh.Text.Trim();
                string strLhqf = Comm.GetDataName1(cobLhjg.Text.Trim(), "cobLhjg");
                string strYcllx = Comm.GetDataName1(cobYcllx.Text.Trim(), "cobYcllx");
                string strYclbh = txtYclbh.Text.Trim();

                string strJlssz = string.Empty;
                DataTable dtsybh = _bllfmd010.GetList("symc = '" + cobJlssz.Text.Trim() + "' ").Tables[0];
                if (0 < dtsybh.Rows.Count)
                {
                    strJlssz = dtsybh.Rows[0]["SYBH"].ToString().Trim();
                }

                DataTable dt = _bllfed050.SetSpd(strStartRq, strEndRq, strClbh, strLhqf, strJlssz, strHlpclotno, strYclbh, strYcllx);
                if (dt.Rows.Count > 0)
                {
                    if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                    {
                        //int countexcel = 0;
                        beforeTime = DateTime.Now.TimeOfDay;
                        #region
                        ////获取服务器时间
                        string strdm = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_Y_M_D)
                            + " " + PublicFun.GetSystemDateTime(ComConst.Time, ""))
                                        .ToString("yyyyMMddhhmmss", DateTimeFormatInfo.CurrentInfo);
                        #endregion

                        ExportBaseExcel Ebe = new ExportBaseExcel();
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC18.xls");
                        Ebe.TableToExcel(3, 1, dt);
                        Ebe.SetBorderValueSingle(3, 1, dt.Rows.Count + 2, dt.Columns.Count);

                        if (!System.IO.Directory.Exists(Save_Path))
                        {
                            System.IO.Directory.CreateDirectory(Save_Path);
                        }
                        string Save_Path1 = Save_Path + "\\" + strdm + ".xls";
                        Ebe.SaveAs(Save_Path1);
                        Ebe.ReleaseExcel();
                        Ebe.KillSpecialExcel();
                        ExportBaseExcel Ebe1 = new ExportBaseExcel("");
                        Ebe1.ViewFile(Save_Path1);

                        Application.DoEvents();
                    }
                    else
                    {
                        KillExcelProcess();
                        return;
                    }
                    dt.Clear();
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }


        private void PC18_KeyDown(object sender, KeyEventArgs e)
        {
            PublicFun.EnterSendTab(sender, e);
        }

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
                    System.GC.Collect();
                    this.Close();
                    //Application.Exit();
                }
                else
                {
                    return;
                }
            }

            base.WndProc(ref m);
        }
        #endregion

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

        private void Spd_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            SetspdColor(e.Row);
        }

        #region spd用方法
        private void SetspdColor(int eRow)
        {
            if (Spd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    Spd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                    //fspd.ActiveSheet.Rows.Get(i).BackColor = Color.Empty;
                    Spd.ActiveSheet.Rows.Get(i).BackColor = Color.LightGoldenrodYellow;
                }

                this.Spd.ActiveSheet.Rows[eRow].BackColor = Color.Lavender;
            }
        }
        #endregion 

    }

    /// <summary>  
    /// 第二种方法  
    /// </summary>  
    class borderDrawer : System.Windows.Forms.TextBox
    {
        private Color borderColor = Color.Red;   // 设置默认的边框颜色  
        private static int WM_NCPAINT = 0x0085;    // WM_NCPAINT message  
        private static int WM_ERASEBKGND = 0x0014; // WM_ERASEBKGND message  
        private static int WM_PAINT = 0x000F;      // WM_PAINT message  
        [DllImport("user32.dll")]
        static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
        //释放DC  
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        /// <summary>  
        /// 重绘边框的方法  
        /// </summary>  
        /// <param name="message"></param>  
        /// <param name="width"></param>  
        /// <param name="height"></param>  
        public void DrawBorder(ref Message message, int width, int height)
        {
            if (message.Msg == WM_NCPAINT || message.Msg == WM_ERASEBKGND ||
                message.Msg == WM_PAINT)
            {
                IntPtr hdc = GetDCEx(message.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    Graphics graphics = Graphics.FromHdc(hdc);
                    Rectangle rectangle = new Rectangle(0, 0, width, height);
                    ControlPaint.DrawBorder(graphics, rectangle,
                                 borderColor, ButtonBorderStyle.Solid);

                    message.Result = (IntPtr)1;
                    ReleaseDC(message.HWnd, hdc);
                }
            }
        }
    }  
}
