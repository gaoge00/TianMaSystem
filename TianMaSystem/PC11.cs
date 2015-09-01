using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;
using System.Collections;

namespace BSC_System
{
    public partial class PC11 : Form
    {
        public PC11()
        {
            InitializeComponent();
        }
        #region 公共变量
        Function.systemdate sysDate = new Function.systemdate();
        BLL.fmd010 B_FMD010 = new BLL.fmd010();
        BLL.fmd050 B_FMD050 = new BLL.fmd050();
        BLL.fmd070 B_FMD070 = new BLL.fmd070();
        BLL.fmd080 B_FMD080 = new BLL.fmd080();
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

        #endregion


        #region 公共方法

        private void FillSpd()
        {
            string strClbh = txtClbh.Text.Trim();
            string strPHB = txtPhb.Text.Trim();

            StringBuilder strWhere = new StringBuilder();
            if (!String.IsNullOrEmpty(strClbh))
            {
                strWhere.Append(" and CLBH like '" + strClbh + "%'");
            }

            if (!String.IsNullOrEmpty(strPHB))
            {
                strWhere.Append(" and PHBBH='" + strPHB + "'");
            }

            DataTable myDt = B_FMD070.GetListByPBH(strWhere.ToString(), "ZT desc,CLBH,PHBBH");

            //Spd.ActiveSheet.RowCount += 1;
            //Spd.ActiveSheet.RowCount = 0;

            Spd.ActiveSheet.RowCount = myDt.Rows.Count;
            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                //Spd.ActiveSheet.RowCount += 1;
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["CLBH"], i, 1);     //材料编号
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["PHBBH"], i, 2);    //配合表编号  
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["ZDRQ"], i, 3);     //制定日期
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["ZT"], i, 4);       //状态
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["BL"], i, 5);       //比例
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["ZZR"], i, 6);      //作成人NO
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["PZR"], i, 7);      //批准人NO
                ComSpread.SpdSetValue(Spd, myDt.Rows[i]["BZ"], i, 8);       //备考（用途）

                if ("已作废".Equals(Spd.ActiveSheet.Cells[i, 4].Text))
                {
                    Spd.ActiveSheet.Rows.Get(i).ForeColor = Color.Red;
                }
                else 
                {
                    Spd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                }
                    
            }

            ComSpread.SpdSetFocus(Spd, 0, 1);
            ComSpread.SpdSetFocus(Spd, 0, 0);
        }

        /// <summary>
        /// 得到选择的行ID
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCheckRowids()
        {
            ArrayList lstRowids = new ArrayList();
            if (Spd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    bool bHasChecked = Convert.ToBoolean(Spd.ActiveSheet.Cells[i, 0].Value);
                    if (bHasChecked)
                    {
                        string ckzlbh = ComSpread.SpdGetValue(Spd, i, 1);
                        if (!String.IsNullOrEmpty(ckzlbh))
                        {
                            lstRowids.Add(i);
                        }

                    }
                }
            }
            return lstRowids;
        }

        #endregion

        private void btnExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PC11_sub1 frm = new PC11_sub1();
            frm.ShowDialog();
            FillSpd();
           
        }

        private void PC11_Load(object sender, EventArgs e)
        {

        }

        private void btnJs_Click(object sender, EventArgs e)
        {
            FillSpd();
            //合并单元格
            //for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
            //{
            //    string zt = Spd.ActiveSheet.GetText(i, 4);
            //    if (zt == "正常")
            //    {
            //        string strCLBH = Spd.ActiveSheet.GetText(i, 1);
            //        if (i < Spd.ActiveSheet.RowCount - 1)
            //        {
            //            string strCLBH1 = Spd.ActiveSheet.GetText(i + 1, 1);
            //            if (strCLBH == strCLBH1)
            //            {
            //                //合并
            //                //    vaSpread1.AddCellSpan 3, 4, 2, 1'从第3列第4行起合并单元格，跨度为2列1行
            //                Spd.ActiveSheet.AddSpanCell(i, 1, 2, 1);
            //            }
            //        }
            //    }
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //修改
            ArrayList lstRowids = GetCheckRowids();
            if (lstRowids.Count == 1)
            {
                string strClbh = string.Empty;    //材料编号
                string strPbhbh = string.Empty;    //配合表编号
                int rowid = Convert.ToInt32(lstRowids[0]);

                strClbh = ComSpread.SpdGetValue(Spd, rowid, 1);
                strPbhbh = ComSpread.SpdGetValue(Spd, rowid, 2);
                PC11_sub1 frm = new PC11_sub1();
                frm.CLBH = strClbh;
                frm.PBHBH = strPbhbh;
                frm.ShowDialog();
                FillSpd();
            }
            else
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }



        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //删除
            ArrayList lstRowids = GetCheckRowids();
            if (lstRowids.Count == 0)
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            DialogResult dr = MessageBox.Show("是否删除选择的数据?", "是否删除?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //删除
                    ArrayList strSqls = new ArrayList();
                    if (lstRowids.Count == 0)
                    {
                        MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        string strYclbh = string.Empty;    //原材料编号
                        string strPbhbh = string.Empty;    //配合表编号

                        foreach (int irow in lstRowids)
                        {
                            strYclbh = ComSpread.SpdGetValue(Spd, irow, 1);
                            strPbhbh = ComSpread.SpdGetValue(Spd, irow, 2);

                            strSqls.Add(B_FMD070.Delete_SQL(strYclbh, strPbhbh));
                            strSqls.Add(B_FMD080.Delete_SQL(strPbhbh));
                        }

                        DbHelperMySql.ExecuteSqlTran(strSqls);
                        ComForm.DspMsg("M001", "");

                        FillSpd();
                    }
                }
                catch (Exception ex)
                {
                    ComForm.DspMsg("E012", "");
                    ComForm.InsertErrLog(ex.ToString(), "linkLabel2_LinkClicked @" + this.Name);
                }

            }
        }

        private void Spd_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                {
                    string strSavePath = System.IO.Path.GetTempPath() + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                    this.Spd_Sheet1.Columns.Get(0).Width = 0;
                    this.Spd_Sheet1.RowHeaderVisible = false;

                    bool b = Spd.SaveExcel(strSavePath, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly);
                    this.Spd_Sheet1.Columns.Get(0).Width = 19F;
                    this.Spd_Sheet1.RowHeaderVisible = true;
                    if (b)
                    {
                        System.Diagnostics.Process.Start(strSavePath, "");
                    }

                }


            }
            catch (Exception ex)
            {
 
            }
        }
    }
}
