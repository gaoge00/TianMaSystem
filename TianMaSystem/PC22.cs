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
using System.Globalization;
using System.Diagnostics;

namespace BSC_System
{
    public partial class PC22 : Form
    {
        public PC22()
        {
            InitializeComponent();
        }


        #region  公共变量
        BLL.ffd050 B_FFD050 = new BLL.ffd050();
        BLL.fmd030 B_FMD030 = new BLL.fmd030();
        Function.systemdate sysDate = new Function.systemdate();

        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC22"].ToString();
     
        #endregion

        #region 公共方法

        /// <summary>
        /// 得到出库指令集合
        /// </summary>
        /// <returns></returns>
        public ArrayList GetListCKZLBH()
        {
            ArrayList lstCKZLBH = new ArrayList();
            if (Spd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    bool bHasChecked = Convert.ToBoolean(Spd.ActiveSheet.Cells[i,0].Value);
                    if (bHasChecked)
                    {
                        string ckzlbh = ComSpread.SpdGetValue(Spd, i, 1);
                        if (!String.IsNullOrEmpty(ckzlbh))
                        {
                            lstCKZLBH.Add(ckzlbh);
                        }
                        
                    }
                }
            }
            return lstCKZLBH;
        }
        /// <summary>
        /// 出库指令自动完成
        /// </summary>
        private void AutoCompleteCKZL()
        {
            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
            DataTable myDt = B_FFD050.getAllCKZLBH_CBOX("","");
            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                strings.Add(myDt.Rows[i]["MCKEY"].ToString());//不区分大小写
            }
                
 
            txt_ckzlbh.AutoCompleteCustomSource = strings;
            txt_ckzlbh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_ckzlbh.AutoCompleteMode = AutoCompleteMode.Suggest;


            string cpsm = string.Empty;
            cpsm = cobKh.Text.Trim();
            cobKh.DataSource = B_FMD030.GetListPc25("").Tables[0];
            cobKh.DisplayMember = "KHMC";
            cobKh.ValueMember = "KHBH";
            cobKh.Text = null;
        }

        public void SetSpd(DataTable dt)
        {
            Spd.ActiveSheet.RowCount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Spd.ActiveSheet.Rows.Count++;
                   
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKZLBH"].ToString().Trim(), i, 1);   //出库指示编号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CKZLRQ"].ToString().Trim(), i, 2);     //出库日
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PM"].ToString().Trim(), i, 3);     //品名
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["PH"].ToString().Trim(), i, 4);    //品号
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["CLBH"].ToString().Trim(), i, 5);    //材料
                    //ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZKSL"].ToString().Trim(), i, 6);    //在库数
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["ZSSLHJ"].ToString().Trim(), i, 7);     //出库指示
                    ComSpread.SpdSetValue(Spd, dt.Rows[i]["DJ"].ToString().Trim(), i, 8);       //单价

                    string ckzt = dt.Rows[i]["WCQF"].ToString().Trim();                         //完成区分
                    ComSpread.SpdSetValue(Spd, ckzt == "0" ? "未出库" : "已出库" , i, 10);       //单价
                    if (ckzt == "1")
                    {
                        //Spd.ActiveSheet.Cells[i, 0].Locked = true;
                        //Spd.ActiveSheet.Rows[i].BackColor = Color.Red;
                    }
                    Spd.ActiveSheet.Rows.Get(i).BackColor = Color.LightGoldenrodYellow;
                }

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

        private void PC22_Load(object sender, EventArgs e)
        {
            AutoCompleteCKZL();

            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

        private void lbl_add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PC22_Dialog frm = new PC22_Dialog();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                btnJs_Click(btnJs,null);
            }
        }

        private void txt_ckzlbh_Leave(object sender, EventArgs e)
        {
            
        }

        private void txt_ckzlbh_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
            {
                dateStartRq.Enabled = true;
                dateEndRq.Enabled = true;
                txt_pm.Enabled = true;
                txt_ph.Enabled = true;
            }
            else
            {
                dateStartRq.Enabled = false;
                dateEndRq.Enabled = false;
                txt_pm.Enabled = false;
                txt_ph.Enabled = false;
            }
        }

        private void btnJs_Click(object sender, EventArgs e)
        {

            StringBuilder strWhere = new StringBuilder();

            //if (String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
            //{
                //组合查找
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
                string strPM = txt_pm.Text.Trim();                              //品名
                string strPH = txt_ph.Text.Trim();                              //品号

                strWhere.Append("  CKZLRQ between '" + strStartRq + "' and '" + strEndRq + "' ");        //开始日 结束日

                if (!String.IsNullOrEmpty(strPM))
                {
                    strWhere.Append(" and PM = '" + strPM + "' ");  //品名
                }
                if (!String.IsNullOrEmpty(strPH))
                {
                    strWhere.Append(" and PH = '" + strPH + "' ");  //品号
                }
            //}
            //else
            //{
                //按出库指令查找
            if (!String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
            {
                string clzlbh = txt_ckzlbh.Text.Trim(); //出库指令编号
                strWhere.Append("and  CKZLBH = '" + clzlbh + "' ");
            }

            if (!String.IsNullOrEmpty(cobKh.Text.Trim()))
            {
                string KHBH = cobKh.SelectedValue.ToString(); //出库指令编号
                strWhere.Append("and KHBH = '" + KHBH + "' ");
            }
                
            //}


            Spd.ActiveSheet.DataSource = null;
            DataTable dt = B_FFD050.GetCKZLMX(strWhere.ToString()).Tables[0];
            //Spd.ActiveSheet.RowCount = dt.Rows.Count;

            SetSpd(dt);
            if (dt.Rows.Count > 0)
            {
                ComSpread.SpdSetFocus(Spd, 0, 1);
                ComSpread.SpdSetFocus(Spd, 0, 0);

            }
        }

        private void lbl_modify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList lstCKZLBH = GetListCKZLBH();
            if (lstCKZLBH.Count == 1)
            {
                //修改
                PC22_Dialog frm = new PC22_Dialog();
                frm.CKZLBH = lstCKZLBH[0].ToString();
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    btnJs_Click(btnJs, null);
                }
            }
            else
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lbl_delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList lstCKZLBH = GetListCKZLBH();
            if (lstCKZLBH.Count > 0)
            {
                try
                {
                  

                    //删除
                    string strWhere = "";
                    foreach (string str in lstCKZLBH)
                    {
                        strWhere += "'" + str + "',";
                    }
                    //strWhere = strWhere.Substring(0, strWhere.Length - 2);
                    strWhere = strWhere.Remove(strWhere.Length - 1);

                    DialogResult dr = MessageBox.Show("是否删除出库指令【" + strWhere + "】?", "是否删除?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        //删除
                        B_FFD050.DeleteList(strWhere);
                        btnJs_Click(btnJs, null);
                        ComForm.DspMsg("M001", "");
                    }

                    
                }
                catch (Exception ex)
                {
                    ComForm.DspMsg("E012", "");
                    ComForm.InsertErrLog(ex.ToString(), "lbl_delete_LinkClicked @" + this.Name);
                }

            }
            else
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lbl_excel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                StringBuilder strWhere = new StringBuilder();

                //if (String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
                //{
                    //组合查找
                    string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                    string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
                    string strPM = txt_pm.Text.Trim();                              //品名
                    string strPH = txt_ph.Text.Trim();                              //品号

                    strWhere.Append("  CKZLRQ between '" + strStartRq + "' and '" + strEndRq + "' ");        //开始日 结束日

                    if (!String.IsNullOrEmpty(strPM))
                    {
                        strWhere.Append(" and PM = '" + strPM + "' ");  //品名
                    }
                    if (!String.IsNullOrEmpty(strPH))
                    {
                        strWhere.Append(" and PH = '" + strPH + "' ");  //品号
                    }
                    //按出库指令查找
                    if (!String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
                    {
                        string clzlbh = txt_ckzlbh.Text.Trim(); //出库指令编号
                        strWhere.Append("and  CKZLBH = '" + clzlbh + "' ");
                    }

                    if (!String.IsNullOrEmpty(cobKh.Text.Trim()))
                    {
                        string KHBH = cobKh.SelectedValue.ToString(); //出库指令编号
                        strWhere.Append("and KHBH = '" + KHBH + "' ");
                    }
                //}
                //else
                //{
                //    //按出库指令查找
                //    string clzlbh = txt_ckzlbh.Text.Trim(); //出库指令编号
                //    strWhere.Append(" CKZLBH = '" + clzlbh + "' ");

                //}


                DataTable dt = B_FFD050.GetCKZLMXEXCEL(strWhere.ToString()).Tables[0];
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

                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC22.xls");

                        //Ebe.SetNewSheet();
                        //Ebe.SetCellValue(1, 0, txtYear.Text.Trim() + "年" + txtMonth.Text.Trim() + "月");

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

        private void PC22_FormClosing(object sender, FormClosingEventArgs e)
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
        public  string CKDH = "";
        private void lbl_CKD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(cobKh.Text.ToString().Trim()) == true)
            {   
                MessageBox.Show("请选择客户。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)16);
                cobKh.Focus();
                return;
            }
            string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
            string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日

            if (strEndRq.Equals(strStartRq) == false)
            {
                MessageBox.Show("出库单数据不能跨日期，请重新选择出库日期。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)16);
                dateEndRq.Focus();
                return;
            }
            List<Model.ffd050> listmodelffd050 = new List<Model.ffd050>();
            listmodelffd050 = GetModel_fed010();
            if (listmodelffd050.Count > 0)
            {
                StringBuilder strWhere = new StringBuilder();

                //if (String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
                //{
                //组合查找
                strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);   //开始日
                strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //结束日
                string strPM = txt_pm.Text.Trim();                              //品名
                string strPH = txt_ph.Text.Trim();                              //品号

                strWhere.Append("  CKZLRQ between '" + strStartRq + "' and '" + strEndRq + "' ");        //开始日 结束日

                if (!String.IsNullOrEmpty(strPM))
                {
                    strWhere.Append(" and a.PM = '" + strPM + "' ");  //品名
                }
                if (!String.IsNullOrEmpty(strPH))
                {
                    strWhere.Append(" and a.PH = '" + strPH + "' ");  //品号
                }
                //按出库指令查找
                if (!String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
                {
                    string clzlbh = txt_ckzlbh.Text.Trim(); //出库指令编号
                    strWhere.Append("and  a.CKZLBH = '" + clzlbh + "' ");
                }

                if (!String.IsNullOrEmpty(cobKh.Text.Trim()))
                {
                    string KHBH = cobKh.SelectedValue.ToString(); //出库指令编号
                    strWhere.Append("and a.KHBH = '" + KHBH + "' ");
                }
                DataTable dt = B_FFD050.GetdtForCry(strWhere.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    getcheckHasTrue();
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (listHGZ.Contains(dt.Rows[i]["CKZLBH"].ToString().Trim()) == false)
                        {
                            dt.Rows.RemoveAt(i);
                        }
                    }
                    int j = 0;
                    dt.Columns.Add("XH");
                    dt.Columns.Add("Crorder");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["XH"] = i+1;
                        dt.Rows[i]["Crorder"] = j;
                        // 每页6行数据 需要更改行数在这里改动。水晶报表中的公式也需要相应的改动。
                        if ((i+1) % 6 == 0)
                        {
                            j++;
                        }
                    }


                    if (dt.Rows.Count > 0)
                    {
                       
                        PC32 pc32 = new PC32();
                        pc32.ShowDialog();

                        // if (string.IsNullOrEmpty(CKBH) == true)
                        // {
                        //   MessageBox.Show("请输入出库单号。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)16);

                        //}
                        DialogResult drBtn;
                        drBtn = MessageBox.Show("是否生成报表？", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)1, (MessageBoxIcon)32);
                        if (drBtn == DialogResult.OK)
                        {
                            try
                            {
                                PC31 cryawbb = new PC31(dt, cobKh.Text.ToString().Trim(), strStartRq,CKDH);
                                cryawbb.Show();
                            }
                            catch (Exception ex)
                            {
                                ComForm.InsertErrLog(ex.ToString(), this.Name + "lbl_CKD_LinkClicked");
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要打印数据。", Function.ComConst.MESSAGE_TITLE, (MessageBoxButtons)0, (MessageBoxIcon)16);
                
                return;
            }
        }

        //删除按钮
        List<string> listHGZ = new List<string>();
        int getcheckHasTrue()//保存时 只要有选中的就可以 保存
        {
            int ischeckcount = 0;
            listHGZ = new List<string>();
            for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
            {
                if (Spd.ActiveSheet.Cells[i, 0].Text == "True")
                {
                    ischeckcount++;
                    listHGZ.Add(Spd.ActiveSheet.Cells[i, 1].Text);
                    //i = fspd.ActiveSheet.RowCount;
                }
            }
            return ischeckcount;


        }
        //双击列头 全选/全不选数据
        void SetCheck(bool Check)
        {
            if (Check == true)
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    Spd.ActiveSheet.Cells[i, 0].Text = "True";
                }
            }
            else
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    Spd.ActiveSheet.Cells[i, 0].Text = "False";
                }
            }
        }

        List<Model.ffd050> GetModel_fed010()
        {
            List<Model.ffd050> listmodelffd050 = new List<Model.ffd050>();
            Model.ffd050 modelffd050 = new Model.ffd050();
            for (int i = 0; i < Spd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (Spd.ActiveSheet.Cells[i, 0].Text == "True")
                {
                    modelffd050 = new Model.ffd050();
                    modelffd050 = fillModelffd050(i);
                    listmodelffd050.Add(modelffd050);
                }
            }
            return listmodelffd050;
        }

        List<Model.ffd050> listmodelfed010 = new List<Model.ffd050>();


        Model.ffd050 fillModelffd050(int i)
        {
            Model.ffd050 modelffd050 = new Model.ffd050();     
            #region model 赋值
            modelffd050.CKZLBH = Spd.ActiveSheet.Cells[i, 0].Text.Trim();
            #endregion
            return modelffd050;
        }

        private void Spd_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void Spd_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
             if (e.Column == 0 && e.ColumnHeader)
                {
                    getcheckHasTrue();
                    if (listHGZ.Count == Spd.ActiveSheet.RowCount)
                    {
                        SetCheck(false);
                    }
                    else
                    {
                        SetCheck(true);
                    }
                }
        }
    }
}
