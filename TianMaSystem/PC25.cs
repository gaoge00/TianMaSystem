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
    public partial class PC25 : Form
    {
        public PC25()
        {
            InitializeComponent();
        }

        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC25"].ToString();
        BLL.ffd050 _bllffd050 = new BLL.ffd050();
        BLL.ffd010 _bllffd010 = new BLL.ffd010();
        BLL.fmd030 _bllfmd030 = new BLL.fmd030();

        #endregion

        private void PC25_Load(object sender, EventArgs e)
        {
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));

            Cpsm();

        }


        int getcheckHasTrue()//保存时 只要有选中的就可以 保存
        {
            int ischeckcount = 0;
            for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
            {
                if (Spd.ActiveSheet.Cells[i, 0].Text == "True")
                {
                    ischeckcount++;
                    //i = fspd.ActiveSheet.RowCount;
                }
            }
            return ischeckcount;


        }

        private void Cpsm()
        {
            string cpsm = string.Empty;
            cpsm = cobKh.Text.Trim();
            cobKh.DataSource = _bllfmd030.GetListPc25("").Tables[0];
            cobKh.DisplayMember = "KHMC";
            cobKh.Text = null;
        }
        

        private void btnJs_Click(object sender, EventArgs e)
        {
            GetJs();
        }

        public void GetJs()
        {
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");


            string strKhbh = string.Empty;
            DataTable dtkhbh = _bllfmd030.GetList(" KHMC = '" + cobKh.Text.Trim() + "'").Tables[0];
            if (dtkhbh.Rows.Count > 0)
            {
                strKhbh = dtkhbh.Rows[0]["KHBH"].ToString();
            }
            dtkhbh.Clear();

            DataTable dt = _bllffd050.GetPc25Js01(strStartRq, strEndRq, strKhbh);
            if (dt.Rows.Count > 0)
            {
                Spd.ActiveSheet.RowCount = 0;
                Spd.ActiveSheet.Rows.Count = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComSpread.SpdSetValue(Spd, false, i, 0);

                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKRQ"].ToString().Trim(), i, 1);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["KHMC"].ToString().Trim(), i, 2);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 3);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PM"].ToString().Trim(), i, 4);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 5);
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKSL"].ToString().Trim(), i, 6);
                    //ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKZLBH"].ToString().Trim(), i, 7);

                    string strHLPCLOTNO = string.Empty;
                    DataTable dt_mx = _bllffd010.GetPc25Js02(dt.Rows[i]["CKRQ"].ToString().Trim(), 
                        dt.Rows[i]["KHBH"].ToString().Trim(), dt.Rows[i]["CLBH"].ToString().Trim(),
                        dt.Rows[i]["PM"].ToString().Trim(),dt.Rows[i]["PH"].ToString().Trim());
                    if (dt_mx.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_mx.Rows.Count; j++)
                        {
                           strHLPCLOTNO = strHLPCLOTNO + "  "+ dt_mx.Rows[j]["HLPCLOTNO"].ToString();
                        }
                    }

                    ComSpread.SpdSetValue(Spd, strHLPCLOTNO, i, 7);
                   
                }
                ComSpread.SpdSetFocus(Spd, 0, 1);
            }
        }



        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (getcheckHasTrue() > 1)
                {
                    ComForm.DspMsg("W102", "");   //数据加载失败！
                    return;
                }

                DataTable dt = new DataTable("SpdTable");

                dt.Columns.Add("CKRQ", System.Type.GetType("System.String"));
                dt.Columns.Add("KHMC", System.Type.GetType("System.String"));
                dt.Columns.Add("CLBH", System.Type.GetType("System.String"));
                dt.Columns.Add("PM", System.Type.GetType("System.String"));
                dt.Columns.Add("PH", System.Type.GetType("System.String"));
                dt.Columns.Add("SL", System.Type.GetType("System.String"));
                dt.Columns.Add("HLPCLOTNO", System.Type.GetType("System.String"));

                DataRow dr = dt.NewRow();

                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(Spd.ActiveSheet.Cells[i, 0].Value))
                    {
                        dr["CKRQ"] = Spd.ActiveSheet.Cells[i, 1].Text.Trim();
                        dr["KHMC"] = Spd.ActiveSheet.Cells[i, 2].Text.Trim();
                        dr["CLBH"] = Spd.ActiveSheet.Cells[i, 3].Text.Trim();
                        dr["PM"] = Spd.ActiveSheet.Cells[i, 4].Text.Trim();
                        dr["PH"] = Spd.ActiveSheet.Cells[i, 5].Text.Trim();
                        dr["SL"] = Spd.ActiveSheet.Cells[i, 6].Text.Trim();
                        dr["HLPCLOTNO"] = Spd.ActiveSheet.Cells[i, 7].Text.Trim();

                        dt.Rows.Add(dr);
                    }
                }

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

                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC25.xls");



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
  
                            Ebe.SetNewSheet(1);
                            //Ebe.SetSheetName(dt.Rows[i]["KHMC"].ToString().Substring(0, 10));

                            Ebe.SetCellValue(0, 3, dt.Rows[i]["KHMC"].ToString());

                            Ebe.SetCellValue(2, 19, dt.Rows[i]["CKRQ"].ToString().Substring(0, 4));
                            Ebe.SetCellValue(2, 22, dt.Rows[i]["CKRQ"].ToString().Substring(5, 2));
                            Ebe.SetCellValue(2, 24, dt.Rows[i]["CKRQ"].ToString().Substring(8, 2));

                            Ebe.SetCellValue(4, 5, dt.Rows[i]["PM"].ToString());
                            Ebe.SetCellValue(5, 5, dt.Rows[i]["PH"].ToString());

                            Ebe.SetCellValue(4, 19, dt.Rows[i]["SL"].ToString());
                            Ebe.SetCellValue(5, 19, dt.Rows[i]["CLBH"].ToString());

                            Ebe.SetCellValue(7, 2, dt.Rows[i]["HLPCLOTNO"].ToString());



                            //Ebe.TableToExcel(4, 1, dt_detail);
                            //Ebe.SetBorderValueSingle(4, 1, dt_detail.Rows.Count + 3, dt_detail.Columns.Count + 1);
                            

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
            if (e.ColumnHeader == true)// 判断是否单击 列头
            {
                if (e.Column == 0)                    //是否是第一列
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

        private void PC25_KeyDown(object sender, KeyEventArgs e)
        {
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
        }

    }
}
