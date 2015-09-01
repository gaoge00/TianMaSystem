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
    public partial class PC21 : Form
    {
        public PC21()
        {
            InitializeComponent();
        }


        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC21"].ToString();
        BLL.ffd010 _bllffd010 = new BLL.ffd010();

        #endregion


        private void PC21_Load(object sender, EventArgs e)
        {

            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd")).AddMonths(-1);
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));

            //txtYear.Text = PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd").Substring(0,4);
            //txtMonth.Text = PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd").Substring(5,2);
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
                    GetChecking("1");
                    break;
            }
        }
        #endregion


        public void GetChecking(string strQf)
        {
            if (strQf == "1")
            {
                SetSpd();
            }
            else
            {
                SetExcel();
            }

            //if (string.IsNullOrEmpty(txtYear.Text))
            //{
            //    ComForm.DspMsg("W002", "年");
            //    txtYear.Focus();
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtMonth.Text))
            //{
            //    ComForm.DspMsg("W002", "月");
            //    txtMonth.Focus();
            //    return;
            //}

            //switch (Comm.IsDate(txtYear.Text.Trim(), txtMonth.Text.Trim(), "01"))
            //{
            //    case 0:
            //        if (strQf == "1")
            //        {
            //            SetSpd(txtYear.Text.ToString() + "/" + txtMonth.Text.ToString());
            //        }
            //        else
            //        {
            //            SetExcel(txtYear.Text.ToString() + "/" + txtMonth.Text.ToString());
            //        }
            //        break;

            //    case 1:
            //        ComForm.DspMsg("W015", "年");
            //        txtYear.Focus();
            //        break;

            //    case 2:
            //        ComForm.DspMsg("W015", "月");
            //        txtMonth.Focus();
            //        break;

            //    case 4:
            //        ComForm.DspMsg("W015", "");
            //        txtYear.Focus();
            //        break;

            //}
        }

        public void SetSpd()
        {

            Spd.ActiveSheet.DataSource = null;
            //DataTable dt = _bllffd010.GetPc21Js(strLhrq);
            DataTable dt = _bllffd010.GetPc21Js(dateStartRq.Value, dateEndRq.Value);
            Spd.ActiveSheet.RowCount = dt.Rows.Count;

            if (dt.Rows.Count > 0)
            {
                //Spd.ActiveSheet.RowCount = 0;
                //Spd.ActiveSheet.Rows.Count = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 0);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 1);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZSCSL"].ToString().Trim(), i, 2);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["HGSL"].ToString().Trim(), i, 3);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["BLSL"].ToString().Trim(), i, 4);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["HGL"].ToString().Trim(), i, 5);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["FLH"].ToString().Trim(), i, 6);
                }
            }
            else
            {
                ComForm.DspMsg("W061", "");
                return;
            }
        }

        public void SetExcel()
        {
            try
            {
                DataTable dt = _bllffd010.GetPc21Js(dateStartRq.Value, dateEndRq.Value);
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


                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC21.xls");

                        //Ebe.SetNewSheet();
                        //Ebe.SetCellValue(1, 0, txtYear.Text.Trim() + "年" + txtMonth.Text.Trim() + "月");
                        Ebe.SetCellValue(1, 0, dateStartRq.Value.ToString("yyyy年MM月dd日") + "~" + dateEndRq.Value.ToString("yyyy年MM月dd日"));

                        Ebe.TableToExcel(4, 1, dt);
                        Ebe.SetBorderValueSingle(4, 1, dt.Rows.Count + 3, dt.Columns.Count);

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
                    ComForm.DspMsg("W061", "");
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E050", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
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

        private void PC21_KeyDown(object sender, KeyEventArgs e)
        {
            PublicFun.EnterSendTab(sender, e);
        }

        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetChecking("");
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

        private void txtMonth_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonth.Text.Trim()))
            {
                txtMonth.Text = txtMonth.Text.PadLeft(2, '0');
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);
        }
    }
}
