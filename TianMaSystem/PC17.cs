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

namespace BSC_System
{
    public partial class PC17 : Form
    {
        public PC17()
        {
            InitializeComponent();
        }

        #region 公共变量
        BLL.fed030 B_FED030 = new BLL.fed030();
        Function.systemdate sysDate = new Function.systemdate();
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC17"].ToString();
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

                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["RKRQ"].ToString().Trim(), i, 0);         //入库日
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLBH"].ToString().Trim(), i, 1);        //原材料编号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLLX"].ToString().Trim(), i, 2);        //原材料类型
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["YCLRKLOTNO"].ToString().Trim(), i, 3);   //入库Lotno
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["DW"].ToString().Trim(), i, 4);         //在库数
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZKSL"].ToString().Trim(), i, 5);         //在库数
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SYQX"].ToString().Trim(), i, 6);         //使用期限
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["SYZT"].ToString().Trim(), i, 7);         //使用状态

                    if (dt.Rows[i]["SYZT"].ToString().Trim() == "过期待检")
                    {
                        Spd.ActiveSheet.Rows[i].ForeColor = Color.Red;
                    }

                }

            }
        }

        private DataTable GetDataTable()
        {
            StringBuilder strWhere = new StringBuilder();

            //组合查找
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
            string strYCLBH = txtYCLBH.Text.Trim();                              //原材料编号
            string strYCLLX = ((ListItem)cbbYCLLX.SelectedItem).ID;              //原材料类型
            string strSYZT = ((ListItem)cbbSYZT.SelectedItem).ID;                //使用期限

            strWhere.Append(" and b.RKRQ between '" + strStartRq + "' and '" + strEndRq + "' ");        //开始日 结束日

            if (!String.IsNullOrEmpty(strYCLBH))
            {
                strWhere.Append(" and a.YCLBH = '" + strYCLBH + "' ");  //原材料编号
            }
            if (!String.IsNullOrEmpty(strYCLLX))
            {
                strWhere.Append(" and b.YCLLX = '" + strYCLLX + "' ");  //原材料类型
            }
            if (!String.IsNullOrEmpty(strSYZT))
            {
                if (strSYZT == "0")
                {
                    strWhere.Append(" and  b.SYQX  > sysdate() ");  //使用期限  [正常]
                }
                else if (strSYZT == "1")
                {
                    strWhere.Append(" and  b.SYQX  <= sysdate() ");  //使用期限  [过期待检]
                }

            }

            DataTable dt = B_FED030.GetYCLCKYL(strWhere.ToString());

            return dt;

        }
       
        public void SetExcel(DataTable dt)
        {
            ExportBaseExcel Ebe = new ExportBaseExcel();
            try
            {

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


                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC17.xls");
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
        #endregion

        #region 窗体关闭按钮方法重写
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {

                //btnClose.PerformClick();
                btnClose();
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        private void PC17_Load(object sender, EventArgs e)
        {

            cbbYCLLX.Items.Add(new Function.ListItem("", ""));
            cbbYCLLX.Items.Add(new Function.ListItem("001", "主料"));
            cbbYCLLX.Items.Add(new Function.ListItem("002", "辅料"));
            cbbYCLLX.Items.Add(new Function.ListItem("003", "B练品"));
            cbbYCLLX.SelectedIndex = 0;

            cbbSYZT.Items.Add(new Function.ListItem("", ""));
            cbbSYZT.Items.Add(new Function.ListItem("0", "正常"));
            cbbSYZT.Items.Add(new Function.ListItem("1", "过期待检"));
            cbbSYZT.SelectedIndex = 0;

            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }


        private void btnJs_Click(object sender, EventArgs e)
        {

            DataTable dt = GetDataTable();

            SetSpd(dt);
            if (dt.Rows.Count > 0)
            {
                ComSpread.SpdSetFocus(Spd, 0, 1);
                ComSpread.SpdSetFocus(Spd, 0, 0);

            }
        }

        private void lbl_excel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
            DataTable dt = GetDataTable();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有要生成的数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SetSpd(dt);
                SetExcel(dt);
            }
        }

        private void PC17_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            //{
            //    e.Cancel = true;
            //}
        }


        //退出按钮
        private void btnClose()
        {
            if (ComConst.LING == ComForm.DspMsg("Q001", ""))
            {
                System.GC.Collect();
                this.Close();
            }
            else
            {
                //cboGlMc.Focus();
            }
        }

        private void PC17_KeyDown(object sender, KeyEventArgs e)
        {
            //回车 转成 “Tab”
            PublicFun.EnterSendTab(sender, e);
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

                    if ("过期待检".Equals(Spd.ActiveSheet.Cells[i, 7].Text))
                    {
                        Spd.ActiveSheet.Rows.Get(i).ForeColor = Color.Red;
                    }
                    else
                    {
                        Spd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                    }

                }

                this.Spd.ActiveSheet.Rows[eRow].BackColor = Color.Lavender;
            }
        }
        #endregion 


    }
}
