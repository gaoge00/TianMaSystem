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
    public partial class PC20 : Form
    {
        public PC20()
        {
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC21"].ToString();
        BLL.ffd020 _bllffd020 = new BLL.ffd020();

        #endregion

        private void PC20_Load(object sender, EventArgs e)
        {
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            cobRkqf.Text = "检品入库";
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
                    GetJs();
                    break;
            }
        }
        #endregion


        public void GetJs()
        {
            string strRkqf = Comm.GetDataName1(cobRkqf.Text.Trim(), "cobRkqf");
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
            string strLotno = txtLotno.Text.Trim();
            string strClbh = txtClbh.Text.Trim();
            string strPh = txtPh.Text.Trim();

            Spd.ActiveSheet.DataSource = null;
            DataTable dt = _bllffd020.GetJs(strRkqf,strStartRq, strEndRq, strLotno, strClbh, strPh);
            Spd.ActiveSheet.RowCount = dt.Rows.Count;

            if (dt.Rows.Count > 0)
            {
                //Spd.ActiveSheet.RowCount = 0;
                //Spd.ActiveSheet.Rows.Count = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComSpread.SpdSetValue(Spd, false, i, 0);

                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["LHRQ"].ToString().Trim(), i, 1);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["JPRQ"].ToString().Trim(), i, 2);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["HLPCLOTNO"].ToString().Trim(), i, 3);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 4);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PM"].ToString().Trim(), i, 5);

                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 6);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["HGSL"].ToString().Trim(), i, 7);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["BLSL"].ToString().Trim(), i, 8);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SL"].ToString().Trim(), i, 9);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["JPRBH"].ToString().Trim(), i, 10);

                    ComSpread.SpdSetValue(Spd, Comm.GetDataName(dt.Rows[i]["RKQF"].ToString().Trim(), "cobRkqf"), i, 11);
                    //ComSpread.SpdSetValue(Spd, Comm.GetDataName(dt.Rows[i]["CKRQ"].ToString().Trim(), "cobCkqf"), i, 12);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKRQ"].ToString().Trim(), i, 12);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["XDLOTNO"].ToString().Trim(), i, 13);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["DDLOTNO"].ToString().Trim(), i, 14);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["XLOTNO"].ToString().Trim(), i, 15);
                }

            }

        }

        public void SetExcel()
        {
            try
            {
                string strRkqf = Comm.GetDataName1(cobRkqf.Text.Trim(), "cobRkqf");
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
                string strLotno = txtLotno.Text.Trim();
                string strClbh = txtClbh.Text.Trim();
                string strPh = txtPh.Text.Trim();

                DataTable dt = _bllffd020.GetExcel(strRkqf, strStartRq, strEndRq, strLotno, strClbh, strPh);
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
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC20.xls");
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


        private void Spd_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true)// 判断是否单击 列头
            {
                if ( e.Column == 0)                    //是否是第一列
                {
                    if (Spd.ActiveSheet.ColumnHeader.Cells[0, 0].Text.ToString() == " "
                         ||
                         Spd.ActiveSheet.ColumnHeader.Cells[0, 0].Text.ToString() == "False") // 未选中 
                    {
                        Spd.ActiveSheet.ColumnHeader.Cells[0, 0].Text = "true";// 赋值 true
                        for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                        {
                            Spd.ActiveSheet.Cells[i, 0].Text = "true";
                        }
                    }
                    else
                    {
                        Spd.ActiveSheet.ColumnHeader.Cells[0, 0].Text = "False";// 赋值 False
                        for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                        {
                            Spd.ActiveSheet.Cells[i, 0].Text = "False";
                        }

                    }
                }
            }

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
        


        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetExcel();
        }

        private void btnDyhgz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void PC20_KeyDown(object sender, KeyEventArgs e)
        {
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
        }



    }
}
