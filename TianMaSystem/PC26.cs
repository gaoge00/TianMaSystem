using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Permissions;
using Function;
using System.Globalization;
using System.Reflection;

namespace BSC_System
{
    public partial class PC26 : Form
    {
        public PC26()
        {
            
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC26"].ToString();
        BLL.ffd050 _bllffd050 = new BLL.ffd050();
        BLL.ffd010 _bllffd010 = new BLL.ffd010();
        BLL.ffd020 _bllffd020 = new BLL.ffd020();
        BLL.fmd010 _bllfmd010 = new BLL.fmd010();

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

        private void button1_Click(object sender, EventArgs e)
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SetExcel();
        }

        public void SetExcel()
        {
            try
            {
                string strLotno = txtLotno.Text.Trim();

                string strStartLhrq = txtStartLhrq.Text.Trim();
                string strEndLhrq = txtEndLhrq.Text.Trim();

                string strStartJprq = txtStartJprq.Text.Trim();
                string strEndJprq = txtEndJprq.Text.Trim();

                string strJpzmc = string.Empty;
                DataTable dtJpzmc = _bllfmd010.GetList("SYMC = '"+cobCpjcz.Text.Trim()+"'").Tables[0];
                if (dtJpzmc.Rows.Count > 0)
                {
                    strJpzmc = dtJpzmc.Rows[0]["SYBH"].ToString();
                }
                dtJpzmc.Clear();


                DataTable dt = _bllffd020.GetExcelPc26(strStartLhrq, strEndLhrq, strStartJprq, strEndJprq, strLotno, strJpzmc);
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


                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC26.xls");

                        DataTable dt_temp01 = dt.DefaultView.ToTable(true, "HLPCLOTNO");
                        dt_temp01.DefaultView.Sort = "HLPCLOTNO";
                        for (int a = 0; a < dt_temp01.Rows.Count; a++)
                        {


                            DataTable dt_temp02 = 
                                _bllffd020.GetExcelPc26(strStartLhrq, strEndLhrq, strStartJprq, strEndJprq, dt_temp01.Rows[a]["HLPCLOTNO"].ToString(), strJpzmc);

                            int temp02count = dt_temp02.Rows.Count;

                            Ebe.SetNewSheet(1);
                            Ebe.SetSheetName(dt_temp01.Rows[a]["HLPCLOTNO"].ToString());
                            Ebe.TableToExcel(4, 1, dt_temp02);
                            Ebe.SetBorderValueSingle(4, 1, dt_temp02.Rows.Count + 3, dt_temp02.Columns.Count);

                            if (temp02count > 1)
                            {
                                Ebe.SetCellValue(3,10, temp02count + 2, 10, dt_temp02.Rows[a]["HGSL"].ToString());
                                Ebe.SetCellValue(3, 11, temp02count + 2, 11, dt_temp02.Rows[a]["BLSL"].ToString());
                            }

                            Ebe.DeleteColumn(4);

                            //for (int i = 0; i < dt_temp02.Rows.Count; i++)
                            //{
                            
                           

                            if(dt_temp02.Rows.Count > 0)
                            {
                                string strPhbid = dt_temp02.Rows[0]["PHBID"].ToString();

                                DataTable dt_detail = _bllffd020.GetPc26ExcelDetail(strPhbid, "");
                                if (dt_detail.Rows.Count > 0)
                                {
                                    DataTable dt_Collect = dt_detail.DefaultView.ToTable(true, "PHBBH");
                                    dt_Collect.DefaultView.Sort = "PHBBH";

                                    if (dt_Collect.Rows.Count > 0)
                                    {
                                        int phbCount = 4;
                                        int row = 3;

                                        for (int j = 0; j < dt_Collect.Rows.Count; j++)
                                        {

                                            DataTable dt_1 = _bllffd020.GetPc26ExcelDetail(strPhbid, dt_Collect.Rows[j]["PHBBH"].ToString());

                                            if (dt_1.Rows.Count > 0)
                                            {

                                                Ebe.InsertColumn(phbCount);
                                                Ebe.SetCellValue(row-1, phbCount - 1,"配合表编号");
                                                //Ebe.SetCellValue(row, phbCount - 1, dt_1.Rows[j]["PHBBH"].ToString());
                                                Ebe.SetCellValue(row, phbCount - 1, row + temp02count -1, phbCount - 1, dt_1.Rows[j]["PHBBH"].ToString());
                                                Ebe.SetFontColor(row, phbCount - 1, row + temp02count - 1, phbCount - 1, 3);

                                                for (int k = 0; k < dt_1.Rows.Count; k++)
                                                {
                                                    phbCount = phbCount + 1;

                                                    Ebe.InsertColumn(phbCount);
                                                    if (k == 0)
                                                    {
                                                        Ebe.SetCellValue(row - 1, phbCount - 1, "主料");
                                                    }
                                                    else
                                                    {
                                                        Ebe.SetCellValue(row - 1, phbCount - 1, "辅料");
                                                    }
                                                    //Ebe.SetCellValue(row, phbCount-1 , dt_1.Rows[k]["YCLBH"].ToString());
                                                    Ebe.SetCellValue(row, phbCount - 1, row + temp02count -1, phbCount - 1, dt_1.Rows[k]["YCLBH"].ToString());
                                                    Ebe.SetBorderValueSingle(row, phbCount - 1, row + temp02count, phbCount - 1);
                                                    Ebe.SetFontColor(row, phbCount - 1, row + temp02count, phbCount - 1, 22);
                                                    phbCount = phbCount + 1;
                                                    

                                                    Ebe.InsertColumn(phbCount);
                                                    Ebe.SetCellValue(row - 1, phbCount - 1, "重量(g)");
                                                    //Ebe.SetCellValue(row, phbCount-1 , dt_1.Rows[k]["ZL"].ToString());
                                                    Ebe.SetCellValue(row, phbCount - 1, row + temp02count-1, phbCount - 1, dt_1.Rows[k]["ZL"].ToString());
                                                    Ebe.SetBorderValueSingle(row, phbCount - 1, row + temp02count, phbCount);
                                                    Ebe.SetFontColor(row, phbCount - 1, row + temp02count, phbCount - 1, 23);
                                                }
                                                phbCount = phbCount + 1;

                                                //int Count = Convert.ToInt32(dt_1.Compute("Count(YCLBH)", "YCLBH='" + dt_1.Rows[j]["YCLBH"].ToString() + "'").ToString());

                                                //Ebe.InsertColumn(Count * 2 + 1);
                                            }
                                        }
                                        Ebe.SetCellValue(1, 3, 1, phbCount - 2, "配合表工序");
                                        Ebe.SetBorderValueSingle(1, 3, 1, phbCount - 2);

                                        Ebe.setKD();
                                       // Ebe.SetCellValue(row - 2, 3, row - 3, phbCount - 2, "配合表工序");

                                    }

                                }

                            }


                        }

                        Ebe.SetModelSheetNoView(1);


                        

                        

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
                ComForm.DspMsg("E016", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void PC26_Load(object sender, EventArgs e)
        {
            Cpsm();
        }

        private void Cpsm()
        {
            string cpsm = string.Empty;
            cpsm = cobCpjcz.Text.Trim();
            cobCpjcz.DataSource = _bllfmd010.GetListPc26(" BMBH = '004' ").Tables[0];
            cobCpjcz.DisplayMember = "SYMC";
            cobCpjcz.Text = null;
        }

        private void txtStartLhrq_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (button1.Focused)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtStartLhrq.Text))
                {
                    return;
                }
                string hdr = txtStartLhrq.Text.Trim();
                if (hdr.Length == hdr.Replace("/", "").Length)
                {
                    if (txtStartLhrq.Text.Trim().Length == 6)
                    {
                        txtStartLhrq.Text = txtStartLhrq.Text.Trim().Substring(0, 4) + "/" + txtStartLhrq.Text.Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtStartLhrq.Text.Trim().Substring(5, 1).PadLeft(2, '0');
                    }
                    else if (txtStartLhrq.Text.Trim().Length == 8)
                    {
                        txtStartLhrq.Text = txtStartLhrq.Text.Trim().Substring(0, 4) + "/" + txtStartLhrq.Text.Trim().Substring(4, 2) + "/" + txtStartLhrq.Text.Trim().Substring(6, 2);
                    }
                }
                else
                {
                    string[] hdrSZ = hdr.Split('/');
                    if (hdrSZ.Length == 3)
                    {
                        txtStartLhrq.Text = hdrSZ[0] + "/" + hdrSZ[1].PadLeft(2, '0') + "/" + hdrSZ[2].PadLeft(2, '0');
                    }
                    if (hdrSZ.Length == 2)
                    {
                        if (txtStartLhrq.Text.Replace("/", "").Trim().Length == 6)
                        {
                            txtStartLhrq.Text = txtStartLhrq.Text.Replace("/", "").Trim().Substring(0, 4) + "/" + txtStartLhrq.Text.Replace("/", "").Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtStartLhrq.Text.Replace("/", "").Trim().Substring(5, 1).PadLeft(2, '0');
                        }
                        else if (txtStartLhrq.Text.Replace("/", "").Trim().Length == 8)
                        {
                            txtStartLhrq.Text = txtStartLhrq.Text.Trim().Replace("/", "").Substring(0, 4) + "/" + txtStartLhrq.Text.Replace("/", "").Trim().Substring(4, 2) + "/" + txtStartLhrq.Text.Replace("/", "").Trim().Substring(6, 2);
                        }
                    }
                }
                string yy = txtStartLhrq.Text.Trim().ToString().Split('/')[0];
                string MM = txtStartLhrq.Text.Trim().ToString().Split('/')[1];
                string dd = txtStartLhrq.Text.Trim().ToString().Split('/')[2];
                int i = Comm.IsDate(yy, MM, dd);
                if (i != 0)
                {
                    txtStartLhrq.Focus();
                    txtStartLhrq.SelectAll();
                    ComForm.DspMsg("W015", "");
                }
            }
            catch (Exception ex)
            {
                txtStartLhrq.Focus();
                txtStartLhrq.SelectAll();
                ComForm.DspMsg("W015", "");
            }
        }   

        private void txtEndLhrq_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (button1.Focused)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtEndLhrq.Text.Trim()))
                {
                    return;
                }

                string hdr = txtEndLhrq.Text.Trim();
                if (hdr.Length == hdr.Replace("/", "").Length)
                {
                    if (txtEndLhrq.Text.Trim().Length == 6)
                    {
                        txtEndLhrq.Text = txtEndLhrq.Text.Trim().Substring(0, 4) + "/" + txtEndLhrq.Text.Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtEndLhrq.Text.Trim().Substring(5, 1).PadLeft(2, '0');
                    }
                    else if (txtEndLhrq.Text.Trim().Length == 8)
                    {
                        txtEndLhrq.Text = txtEndLhrq.Text.Trim().Substring(0, 4) + "/" + txtEndLhrq.Text.Trim().Substring(4, 2) + "/" + txtEndLhrq.Text.Trim().Substring(6, 2);
                    }
                }
                else
                {
                    string[] hdrSZ = hdr.Split('/');
                    if (hdrSZ.Length == 3)
                    {
                        txtEndLhrq.Text = hdrSZ[0] + "/" + hdrSZ[1].PadLeft(2, '0') + "/" + hdrSZ[2].PadLeft(2, '0');
                    }
                    if (hdrSZ.Length == 2)
                    {
                        if (txtEndLhrq.Text.Replace("/", "").Trim().Length == 6)
                        {
                            txtEndLhrq.Text = txtEndLhrq.Text.Replace("/", "").Trim().Substring(0, 4) + "/" + txtEndLhrq.Text.Replace("/", "").Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtEndLhrq.Text.Replace("/", "").Trim().Substring(5, 1).PadLeft(2, '0');
                        }
                        else if (txtEndLhrq.Text.Replace("/", "").Trim().Length == 8)
                        {
                            txtEndLhrq.Text = txtEndLhrq.Text.Trim().Replace("/", "").Substring(0, 4) + "/" + txtEndLhrq.Text.Replace("/", "").Trim().Substring(4, 2) + "/" + txtEndLhrq.Text.Replace("/", "").Trim().Substring(6, 2);
                        }
                    }
                }
                string yy = txtEndLhrq.Text.Trim().ToString().Split('/')[0];
                string MM = txtEndLhrq.Text.Trim().ToString().Split('/')[1];
                string dd = txtEndLhrq.Text.Trim().ToString().Split('/')[2];
                int i = Comm.IsDate(yy, MM, dd);
                if (i != 0)
                {
                    txtEndLhrq.Focus();
                    txtEndLhrq.SelectAll();
                    ComForm.DspMsg("W015", "");
                }
            }
            catch (Exception ex)
            {
                txtEndLhrq.Focus();
                txtEndLhrq.SelectAll();
                ComForm.DspMsg("W015", "");
            }
        }

        private void txtStartJprq_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (button1.Focused)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtStartJprq.Text))
                {
                    return;
                }
                string hdr = txtStartJprq.Text.Trim();
                if (hdr.Length == hdr.Replace("/", "").Length)
                {
                    if (txtStartJprq.Text.Trim().Length == 6)
                    {
                        txtStartJprq.Text = txtStartJprq.Text.Trim().Substring(0, 4) + "/" + txtStartJprq.Text.Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtStartJprq.Text.Trim().Substring(5, 1).PadLeft(2, '0');
                    }
                    else if (txtStartJprq.Text.Trim().Length == 8)
                    {
                        txtStartJprq.Text = txtStartJprq.Text.Trim().Substring(0, 4) + "/" + txtStartJprq.Text.Trim().Substring(4, 2) + "/" + txtStartJprq.Text.Trim().Substring(6, 2);
                    }
                }
                else
                {
                    string[] hdrSZ = hdr.Split('/');
                    if (hdrSZ.Length == 3)
                    {
                        txtStartJprq.Text = hdrSZ[0] + "/" + hdrSZ[1].PadLeft(2, '0') + "/" + hdrSZ[2].PadLeft(2, '0');
                    }
                    if (hdrSZ.Length == 2)
                    {
                        if (txtStartJprq.Text.Replace("/", "").Trim().Length == 6)
                        {
                            txtStartJprq.Text = txtStartJprq.Text.Replace("/", "").Trim().Substring(0, 4) + "/" + txtStartJprq.Text.Replace("/", "").Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtStartJprq.Text.Replace("/", "").Trim().Substring(5, 1).PadLeft(2, '0');
                        }
                        else if (txtStartJprq.Text.Replace("/", "").Trim().Length == 8)
                        {
                            txtStartJprq.Text = txtStartJprq.Text.Trim().Replace("/", "").Substring(0, 4) + "/" + txtStartJprq.Text.Replace("/", "").Trim().Substring(4, 2) + "/" + txtStartJprq.Text.Replace("/", "").Trim().Substring(6, 2);
                        }
                    }
                }
                string yy = txtStartJprq.Text.Trim().ToString().Split('/')[0];
                string MM = txtStartJprq.Text.Trim().ToString().Split('/')[1];
                string dd = txtStartJprq.Text.Trim().ToString().Split('/')[2];
                int i = Comm.IsDate(yy, MM, dd);
                if (i != 0)
                {
                    txtStartJprq.Focus();
                    txtStartJprq.SelectAll();
                    ComForm.DspMsg("W015", "");
                }
            }
            catch (Exception ex)
            {
                txtStartJprq.Focus();
                txtStartJprq.SelectAll();
                ComForm.DspMsg("W015", "");
            }
        }

        private void txtEndJprq_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (button1.Focused)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtEndJprq.Text.Trim()))
                {
                    return;
                }

                string hdr = txtEndJprq.Text.Trim();
                if (hdr.Length == hdr.Replace("/", "").Length)
                {
                    if (txtEndJprq.Text.Trim().Length == 6)
                    {
                        txtEndJprq.Text = txtEndJprq.Text.Trim().Substring(0, 4) + "/" + txtEndJprq.Text.Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtEndJprq.Text.Trim().Substring(5, 1).PadLeft(2, '0');
                    }
                    else if (txtEndJprq.Text.Trim().Length == 8)
                    {
                        txtEndJprq.Text = txtEndJprq.Text.Trim().Substring(0, 4) + "/" + txtEndJprq.Text.Trim().Substring(4, 2) + "/" + txtEndJprq.Text.Trim().Substring(6, 2);
                    }
                }
                else
                {
                    string[] hdrSZ = hdr.Split('/');
                    if (hdrSZ.Length == 3)
                    {
                        txtEndJprq.Text = hdrSZ[0] + "/" + hdrSZ[1].PadLeft(2, '0') + "/" + hdrSZ[2].PadLeft(2, '0');
                    }
                    if (hdrSZ.Length == 2)
                    {
                        if (txtEndJprq.Text.Replace("/", "").Trim().Length == 6)
                        {
                            txtEndJprq.Text = txtEndJprq.Text.Replace("/", "").Trim().Substring(0, 4) + "/" + txtEndJprq.Text.Replace("/", "").Trim().Substring(4, 1).PadLeft(2, '0') + "/" + txtEndJprq.Text.Replace("/", "").Trim().Substring(5, 1).PadLeft(2, '0');
                        }
                        else if (txtEndJprq.Text.Replace("/", "").Trim().Length == 8)
                        {
                            txtEndJprq.Text = txtEndJprq.Text.Trim().Replace("/", "").Substring(0, 4) + "/" + txtEndJprq.Text.Replace("/", "").Trim().Substring(4, 2) + "/" + txtEndJprq.Text.Replace("/", "").Trim().Substring(6, 2);
                        }
                    }
                }
                string yy = txtEndJprq.Text.Trim().ToString().Split('/')[0];
                string MM = txtEndJprq.Text.Trim().ToString().Split('/')[1];
                string dd = txtEndJprq.Text.Trim().ToString().Split('/')[2];
                int i = Comm.IsDate(yy, MM, dd);
                if (i != 0)
                {
                    txtEndJprq.Focus();
                    txtEndJprq.SelectAll();
                    ComForm.DspMsg("W015", "");
                }
            }
            catch (Exception ex)
            {
                txtEndJprq.Focus();
                txtEndJprq.SelectAll();
                ComForm.DspMsg("W015", "");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComForm.IsNum(e);
        }

        private void PC26_KeyDown(object sender, KeyEventArgs e)
        {
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
        }

        private void txtEndLhrq_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
