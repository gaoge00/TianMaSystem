using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using System.Globalization;
using System.Diagnostics;
using System.Security.Permissions;

namespace BSC_System
{
    public partial class PC23 : Form
    {
        public PC23()
        {
            InitializeComponent();
        }
        #region  公共变量
        BLL.ffd050 B_FFD050 = new BLL.ffd050();
        Function.systemdate sysDate = new Function.systemdate();
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC23"].ToString();

        #endregion

        #region 公共方法 
        
        public void SetSpd(DataTable dt)
        {
            Spd.ActiveSheet.RowCount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Spd.ActiveSheet.Rows.Count++;

                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["KHBH"].ToString().Trim(), i, 0);   //客户编号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKZLBH"].ToString().Trim(), i, 1);   //出库指示编号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKZLRQ"].ToString().Trim(), i, 2);     //出库日
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PM"].ToString().Trim(), i, 3);     //品名
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 4);    //品号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 5);    //材料
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZSSLHJ"].ToString().Trim(), i, 6);     //出库指示
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKWCS"].ToString().Trim() == "" ? "0" : dt.Rows[i]["CKWCS"].ToString().Trim() , i, 7);     //已出库数
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["DJ"].ToString().Trim(), i, 9);       //单价

                    string ckzt = dt.Rows[i]["WCQF"].ToString().Trim();                         //完成区分
                    ComSpread.SpdSetValue(Spd, ckzt == "0" ? "未出库" : "已出库", i, 11);       //单价

                }

            }
        }

        /// <summary>
        /// SpRead 转换成 DataTable
        /// </summary>
        /// <param name="spd"></param>
        /// <returns></returns>
        private DataTable Spread2DateTable(FarPoint.Win.Spread.FpSpread spd)
        {

            DataTable myDt = new DataTable();
            if (spd.ActiveSheet.RowCount != 0)
            {

                for (int iCol = 0; iCol < spd.ActiveSheet.ColumnCount; iCol++)
                {
                    myDt.Columns.Add(spd.ActiveSheet.Columns[iCol].Label);

                }

                for (int iRow = 0; iRow < spd.ActiveSheet.RowCount; iRow++)
                {
                    object[] objs = new object[spd.ActiveSheet.ColumnCount];
                    for (int iCol = 0; iCol < spd.ActiveSheet.ColumnCount; iCol++)
                    {
                        objs[iCol] = ComSpread.SpdGetValue(spd, iRow, iCol);

                    }

                    myDt.Rows.Add(objs);
                }
                                   
            }

            return myDt;
        }

        public void SetExcel()
        {
            ExportBaseExcel Ebe = new ExportBaseExcel();
            try
            {
                DataTable dt = Spread2DateTable(Spd);

                if (dt.Rows.Count > 0)
                {
                    if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                    {
                        //int countexcel = 0;
                        #region
                        ////获取服务器时间
                        string strdm = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_Y_M_D)
                            + " " + PublicFun.GetSystemDateTime(ComConst.Time, ""))
                                        .ToString("yyyyMMddhhmmss", DateTimeFormatInfo.CurrentInfo);
                        #endregion

                        
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC23.xls");
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
                    dt.Clear();
                }
            }
            catch (Exception ex)
            {
                Ebe.KillSpecialExcel();
                ComForm.DspMsg("E016", "");
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private DataTable GetDataTable()
        {

            StringBuilder strWhere = new StringBuilder();

            //组合查找
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
            string strKHBH = txt_khbh.Text.Trim();                              //品名
            string strPM = txt_pm.Text.Trim();                              //品名
            string strPH = txt_ph.Text.Trim();                              //品号
            string strCLBH = txt_clbh.Text.Trim();                              //材料编号

            strWhere.Append("  CKZLRQ between '" + strStartRq + "' and '" + strEndRq + "' ");        //开始日 结束日

            if (!String.IsNullOrEmpty(strKHBH))
            {
                strWhere.Append(" and KHBH = '" + strKHBH + "' ");  //客户
            }
            if (!String.IsNullOrEmpty(strPM))
            {
                strWhere.Append(" and PM = '" + strPM + "' ");  //品名
            }
            if (!String.IsNullOrEmpty(strPH))
            {
                strWhere.Append(" and PH = '" + strPH + "' ");  //品号
            }
            if (!String.IsNullOrEmpty(strCLBH))
            {
                strWhere.Append(" and CLBH = '" + strCLBH + "' ");  //品号
            }

            DataTable dt = B_FFD050.GetCPCKMX(strWhere.ToString()).Tables[0];

            return dt;
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
        private void PC23_Load(object sender, EventArgs e)
        {
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

        private void btnJs_Click(object sender, EventArgs e)
        {

            SetSpd(GetDataTable());

        }

        private void lbl_excel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetSpd(GetDataTable());
            if (Spd.ActiveSheet.RowCount == 0)
            {
                ComForm.DspMsg("W061", "");
            }
            else
            {
                SetExcel();
            }
           
        }

        private void txt_khbh_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_khbh.Text.Trim()))
            {
                txt_khbh.Text = txt_khbh.Text.Trim().PadLeft(6,'0');
            }
        }

        private void PC23_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            //{
            //    e.Cancel = true;
            //}
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

        private void txt_clbh_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_crystalreport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("A");
                dt.Columns.Add("B");
                dt.Columns.Add("Crorder");
                dt.Rows.Add(new string[] { "1", "2", "0" }); 
                dt.Rows.Add(new string[] { "2", "4" ,"0"});

                dt.Rows.Add(new string[] { "3", "2", "0" });
                dt.Rows.Add(new string[] { "4", "4", "0" });


                dt.Rows.Add(new string[] { "5", "2", "0" });
                dt.Rows.Add(new string[] { "6", "4", "0" });


                dt.Rows.Add(new string[] { "7", "2", "1" });
                dt.Rows.Add(new string[] { "8", "4", "1" });


                dt.Rows.Add(new string[] { "9", "2", "1" });
                dt.Rows.Add(new string[] { "10", "4", "1" });



                //if (dt.Rows.Count > 0)
                //{
                //    PC31 cryawbb = new PC31(dt);
                //    cryawbb.Show();
                //}
                //else
                //{
                //    ComForm.DspMsg("W061", "");


                //    return;
                //}
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name + "btnYLGZT_Click");
            }
        }

 
    }
}
