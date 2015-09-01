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
    public partial class PC24 : Form
    {
        public PC24()
        {
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC24"].ToString();
        BLL.ffd070 _bllffd070 = new BLL.ffd070();

        #endregion

        private void PC24_Load(object sender, EventArgs e)
        {
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

        public void SetExcel()
        {
            try
            {
                if (string.IsNullOrEmpty(txtClbh.Text.Trim()))
                {
                    ComForm.DspMsg("W002", "材料编号");
                    txtClbh.Focus();
                    return;
                }

                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
                string strClbh = txtClbh.Text.Trim();

                DataTable dt = _bllffd070.GetExcelPc24Ckrq(strStartRq, strEndRq, strClbh);
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


                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC24.xls");

                        for (int i = 0; i < dt.Rows.Count; i++)
                        { 
                            string strCkrq = dt.Rows[i]["CKRQ"].ToString();

                            DataTable dt_detail = _bllffd070.GetExcelPc24(strCkrq);
                            if (dt_detail.Rows.Count > 0)
                            {

                                Ebe.SetNewSheet(1);
                                Ebe.SetSheetName(strCkrq.Replace("/", ""));
                                Ebe.SetCellValue(1, 0, "出库日期：" + strCkrq);
                                Ebe.TableToExcel(4, 1, dt_detail);
                                Ebe.SetBorderValueSingle(4, 1, dt_detail.Rows.Count + 3, dt_detail.Columns.Count + 1);


                                DataTable dt_Collect = dt_detail.DefaultView.ToTable(true, "CLBH");
                                dt_Collect.DefaultView.Sort = "CLBH";
                                if (dt_Collect.Rows.Count > 0)
                                {
                                    int CellRow = 2;

                                    for (int j = 0; j < dt_Collect.Rows.Count; j++)
                                    {
                                        string Collet_CLBH = dt_Collect.Rows[j]["CLBH"].ToString();

                                        int Count = Convert.ToInt32(dt_detail.Compute("Count(CLBH)", "CLBH='" + Collet_CLBH + "'").ToString());

                                        string Sum = dt_detail.Compute("sum(JE)", "CLBH='" + Collet_CLBH + "'").ToString();

                                        Ebe.SetCellValue(CellRow + Count, 5, Sum);

                                        //if (Count > 1)
                                        //{
                                        //    Ebe.SetCellValue(CellRow+2, 0, CellRow+2 + Count, 0, "");
                                        //}

                                        CellRow = CellRow + Count;
                                    }
                                }

                                Ebe.RunMacro("Macro1");
                               // RunMacro(Ebe.ex, "Macro1");

                            }

                        }


                        Ebe.SetModelSheetNoView(1);
                        //Ebe.SetNewSheet();
                        //Ebe.SetCellValue(1, 0, txtYear.Text.Trim() + "年" + txtMonth.Text.Trim() + "月");



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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SetExcel();
        }

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

        private void PC24_KeyDown(object sender, KeyEventArgs e)
        {
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
        }

    }
}
