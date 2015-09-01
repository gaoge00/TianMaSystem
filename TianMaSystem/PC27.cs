using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Diagnostics;
using Function;
using System.Globalization;

namespace BSC_System
{
    public partial class PC27 : Form
    {
        public PC27()
        {
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC27"].ToString();
        BLL.ffd080 _bllffd080 = new BLL.ffd080();
        #endregion

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
                    GetJs();
                    break;
            }
        }
        #endregion


        public void GetJs()
        {
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
            string strPm = txtPm.Text.Trim();
            string strClbh = txtClbh.Text.Trim();
            string strPh = txtPh.Text.Trim();

            DataTable dt = _bllffd080.GetJsPc27 (strStartRq, strEndRq, strPm, strClbh, strPh);
            if (dt.Rows.Count > 0)
            {
                Spd.ActiveSheet.RowCount = 0;
                Spd.ActiveSheet.Rows.Count = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["QHLHRQ"].ToString().Trim(), i, 0);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["XZLHRQ"].ToString().Trim(), i, 1);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 2);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PM"].ToString().Trim(), i, 3);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 4);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SL"].ToString().Trim(), i, 5);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SYMC"].ToString().Trim(), i, 6);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["GZRQ"].ToString().Trim(), i, 7);

                }
            }
            else
            {
                Spd.ActiveSheet.RowCount = 0;
                ComForm.DspMsg("W061", "");
                return;
            }

        }

        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetExcel();
        }

        public void SetExcel()
        {
            try
            {
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
                string strPm = txtPm.Text.Trim();
                string strClbh = txtClbh.Text.Trim();
                string strPh = txtPh.Text.Trim();

                DataTable dt = _bllffd080.GetJsPc27(strStartRq, strEndRq, strPm, strClbh, strPh);
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
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC27.xls");
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

        private void PC27_Load(object sender, EventArgs e)
        {
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}

