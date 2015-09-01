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

namespace BSC_System
{
    public partial class PC11_sub1 : Form
    {
        public PC11_sub1()
        {
            InitializeComponent();
        }

        #region 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if ("0" == Function.ComForm.DspMsg("Q001", ""))
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion


        #region 公共属性
        private string _yclbh;
        private string _pbhbh;

        /// <summary>
        /// 材料编号
        /// </summary>
        public string CLBH
        {
            get { return _yclbh; }
            set { _yclbh = value; }
        }

        /// <summary>
        /// 配合表编号
        /// </summary>
        public string PBHBH
        {
            get { return _pbhbh; }
            set { _pbhbh = value; }
        }


        #endregion

        #region 公共变量
        Function.systemdate sysDate = new Function.systemdate();
        BLL.fmd010 B_FMD010 = new BLL.fmd010();
        BLL.fmd050 B_FMD050 = new BLL.fmd050();
        BLL.fmd070 B_FMD070 = new BLL.fmd070();
        BLL.fmd080 B_FMD080 = new BLL.fmd080();
        #endregion

        #region 公共方法

        private bool CheckForm()
        {
            bool b = true;
            if (String.IsNullOrEmpty(txtClbh.Text.Trim()))
            {
                MessageBox.Show("材料不能为空!");
                txtClbh.Focus();
                return false;
            }
            if (nudBL.Value <= 0)
            {
                MessageBox.Show("比例不能小于等于零!");
                nudBL.Focus();
                return false;
            }

            if (Spd.ActiveSheet.RowCount == 0)
            {
                MessageBox.Show("配合明细不能为空!");
                return false;
            }
            return b;
        }
     
        /// <summary>
        ///  加载Combox
        /// </summary>
        /// <param name="cb">Combox</param>
        /// <param name="dt">DataTable</param>
        /// <param name="col">ID字段</param>
        /// <param name="nameCol">name字段</param>
        private void LoadCombox(ComboBox cb, DataTable dt,string idCol,string nameCol)
        {
            cb.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb.Items.Add(new Function.ListItem(dt.Rows[i][idCol].ToString(), dt.Rows[i][nameCol].ToString()));
            }
            if (dt.Rows.Count > 0)
            {
                cb.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="m_fmd0800"></param>
        private void AddFpSpread(Model.fmd080 m_fmd0800)
        {
            Spd.ActiveSheet.RowCount += 1;
            int iRow = Spd.ActiveSheet.RowCount - 1;

            ComSpread.SpdSetText(Spd, m_fmd0800.YCLBH , iRow, 1);   //原材料编号
            ComSpread.SpdSetText(Spd, "克(g)", iRow, 2);   //计量单位
            ComSpread.SpdSetValue(Spd, m_fmd0800.ZL, iRow, 3);   //重量
            ComSpread.SpdSetValue(Spd, m_fmd0800.GC, iRow, 4);   //公差
            ComSpread.SpdSetText(Spd, m_fmd0800.BZ, iRow, 5);   //备注

        }

        /// <summary>
        /// 得到选择行
        /// </summary>
        /// <returns></returns>
        public int GetRowidByYclbh(string yclbh)
        {
            int row = -1 ;
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
                            //row = i;
                            return i;
                        }

                    }
                }
            }
            return row;
        }
      
        /// <summary>
        ///  修改一行数据
        /// </summary>
        /// <param name="m_fmd0800">数据</param>
        /// <param name="row">行</param>
        private void ModifyFpSpread(Model.fmd080 m_fmd0800,string yclbh)
        {
            int row = GetRowidByYclbh(yclbh);
            if (row != -1)
            {
                ComSpread.SpdSetText(Spd, m_fmd0800.YCLBH, row, 1);   //原材料编号
                ComSpread.SpdSetText(Spd, "克(g)", row, 2);   //计量单位
                ComSpread.SpdSetValue(Spd, m_fmd0800.ZL, row, 3);   //重量
                ComSpread.SpdSetValue(Spd, m_fmd0800.GC, row, 4);   //公差
                ComSpread.SpdSetText(Spd, m_fmd0800.BZ, row, 5);   //备注
            }


        }

        /// <summary>
        ///  得到一行数据
        /// </summary>
        /// <param name="m_fmd0800">数据</param>
        /// <param name="row">行</param>
        private Model.fmd080 GetFpSpread(int row)
        {
            Model.fmd080 _M_FMD080 = new Model.fmd080();
            _M_FMD080.YCLBH = ComSpread.SpdGetValue(Spd, row, 1);   //原材料编号
            _M_FMD080.ZL = Convert.ToDecimal(ComSpread.SpdGetValue(Spd, row, 3));   //重量
            _M_FMD080.GC = Convert.ToDecimal(ComSpread.SpdGetValue(Spd, row, 4));   //公差
            _M_FMD080.BZ = ComSpread.SpdGetValue(Spd, row, 5);   //备注

            return _M_FMD080;

        }
        /// <summary>
        /// 得到原材料集合
        /// </summary>
        /// <returns></returns>
        public ArrayList GetListYclbhCheck()
        {
            ArrayList lstYclbh = new ArrayList();
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
                            lstYclbh.Add(ckzlbh);
                        }

                    }
                }
            }
            return lstYclbh;
        }

        /// <summary>
        /// 得到原材料集合
        /// </summary>
        /// <returns></returns>
        public ArrayList GetListYclbh()
        {
            ArrayList lstYclbh = new ArrayList();
            if (Spd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                {
                    string ckzlbh = ComSpread.SpdGetValue(Spd, i, 1);
                    if (!String.IsNullOrEmpty(ckzlbh))
                    {
                        lstYclbh.Add(ckzlbh);
                    }
                }
            }
            return lstYclbh;
        }

        private void ClearForm()
        {
            txtPhb.Text = "";
            txtClbh.Text = "";
            nudBL.Value = 1;
            cbbZT.SelectedIndex = 1;
            cbbZZR.SelectedIndex = 0;
            cbbPZR.SelectedIndex = 0;
            txtBZ.Text = "";
            Spd.ActiveSheet.RowCount = 0;
            txtClbh.Focus();

            cbbZZR.Text = ComForm.strSymc;
            cbbPZR.Text = ComForm.strSymc;

            dtp_rq.Value = Convert.ToDateTime(sysDate.Get_SysDate(ComConst.dateStyle_Y_M_D));        //出库日
        }
        #endregion

        private void PC11_sub1_Load(object sender, EventArgs e)
        {
            //设置状态 0：正常； 1：已作废
            cbbZT.Items.Add(new Function.ListItem("1", "已作废"));
            cbbZT.Items.Add(new Function.ListItem("0", "正常"));
            cbbZT.SelectedIndex = 1;

            LoadCombox(cbbZZR, B_FMD010.GetNameForList(), "SYBH", "XM");
            LoadCombox(cbbPZR, B_FMD010.GetNameForList(), "SYBH", "XM");
            cbbZZR.Text = ComForm.strSymc;
            cbbPZR.Text = ComForm.strSymc;

            //LoadCombox(cbbZZR, B_FMD010.GetNameForList(), "SYBH", "SYBH");
            //LoadCombox(cbbPZR, B_FMD010.GetNameForList(), "SYBH", "SYBH");

            if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
            {
                //添加
                this.Text = "新增";

                dtp_rq.Value = Convert.ToDateTime(sysDate.Get_SysDate(ComConst.dateStyle_Y_M_D));        //出库日
                txtPhb.Focus();
            }
            else
            {
                //修改
                this.Text = "修改";
                txtPhb.ReadOnly = true;
                txtPhb.BackColor = Color.LightGoldenrodYellow;

                txtClbh.ReadOnly = true;
                txtClbh.BackColor = Color.LightGoldenrodYellow;

                DataTable dtFMD070 = new DataTable();
                string strWhere = "and CLBH='" + CLBH + "' and PHBBH='" + PBHBH + "'";
                dtFMD070 = B_FMD070.GetListByPBH(strWhere, "");
                if (dtFMD070.Rows.Count != 0)
                {

                    dtp_rq.Text = dtFMD070.Rows[0]["ZDRQ"].ToString();
                    txtPhb.Text = dtFMD070.Rows[0]["PHBBH"].ToString();
                    lblZF.Text = dtFMD070.Rows[0]["ZF"].ToString(); 
                    txtClbh.Text = dtFMD070.Rows[0]["CLBH"].ToString(); 
                    nudBL.Value = Convert.ToDecimal( dtFMD070.Rows[0]["BL"]);
                    cbbZT.Text = dtFMD070.Rows[0]["ZT"].ToString();
                    cbbZZR.Text = dtFMD070.Rows[0]["ZZR"].ToString(); 
                    cbbPZR.Text = dtFMD070.Rows[0]["PZR"].ToString(); 
                    txtBZ.Text = dtFMD070.Rows[0]["BZ"].ToString(); 



                    DataTable dtFMD080 = B_FMD080.GetList(" PHBBH = '" + PBHBH + "' ").Tables[0];
                    Spd.ActiveSheet.RowCount = 0;
                    for (int i = 0; i < dtFMD080.Rows.Count; i++)
                    {
                        Spd.ActiveSheet.RowCount += 1;
                        ComSpread.SpdSetValue(Spd, dtFMD080.Rows[i]["YCLBH"], i, 1);
                        ComSpread.SpdSetValue(Spd, "克(g)", i, 2);
                        ComSpread.SpdSetValue(Spd, dtFMD080.Rows[i]["ZL"], i, 3);
                        ComSpread.SpdSetValue(Spd, dtFMD080.Rows[i]["GC"], i, 4);
                        ComSpread.SpdSetValue(Spd, dtFMD080.Rows[i]["BZ"], i, 5);
                    }

                    if (dtFMD080.Rows.Count > 0)
                    {
                        ComSpread.SpdSetFocus(Spd, 0, 1);
                        ComSpread.SpdSetFocus(Spd, 0, 0);

                    }

                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //修改
            ArrayList lst = new ArrayList();
            lst = GetListYclbhCheck();
            if (lst.Count == 1)
            {
                PC11_sub2 frm = new PC11_sub2();
                frm.listYclbh = lst;
                frm.M_FMD080 = GetFpSpread(GetRowidByYclbh(lst[0].ToString()));
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //重新加载
                    Model.fmd080 M_FMD050 = frm.M_FMD080;
                    ModifyFpSpread(M_FMD050, frm.M_FMD080.YCLBH);
                    for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                    {
                        Spd.ActiveSheet.Cells[i, 0].Value = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PC11_sub2 frm = new PC11_sub2();
            frm.listYclbh = GetListYclbh();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //重新加载
                Model.fmd080 M_FMD050 = frm.M_FMD080;
                AddFpSpread(M_FMD050);
                
                ComSpread.SpdSetFocus(Spd, 0, 1);
                ComSpread.SpdSetFocus(Spd, 0, 0);

               
            }

        }

        private void dtp_rq_ValueChanged(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
            {
                if (!String.IsNullOrEmpty(txtClbh.Text.Trim()))
                {
                    //string year = dtp_rq.Value.ToString("yyyy");
                    lblZF.Text = txtClbh.Text.Trim().Split('-')[1];
                   // txtPhb.Text = year + lblZF.Text;
                }
            }

            
        }

        private void txtClbh_Leave(object sender, EventArgs e)
        {
            //判断材料是否存在
            if (!String.IsNullOrEmpty(txtClbh.Text.Trim()))
            {
                if (!B_FMD050.Exists(txtClbh.Text.Trim()))
                {
                    MessageBox.Show("材料编号不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtClbh.Focus();
                    txtClbh.SelectAll();

                    return;
                }

                if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
                {
                    //string year = dtp_rq.Value.ToString("yy");
                    //lblZF.Text = B_FMD070.GenerateZF(year);
                    //txtPhb.Text = year + "-" + lblZF.Text;
                }
            }
            else
            {
                txtClbh.Text = "";
                lblZF.Text = "";
            }
               
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
            {
                System.GC.Collect();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnSY_Click(object sender, EventArgs e)
        {
            //向上移动
            if (Spd.ActiveSheet.ActiveRowIndex != 0)
            {
                Spd.ActiveSheet.MoveRow(Spd.ActiveSheet.ActiveRowIndex, Spd.ActiveSheet.ActiveRowIndex - 1, true);
                Spd.ActiveSheet.ActiveRowIndex = Spd.ActiveSheet.ActiveRowIndex - 1;
            }
                
        }

        private void btnXY_Click(object sender, EventArgs e)
        {
            //向下移动
            if (Spd.ActiveSheet.ActiveRowIndex != Spd.ActiveSheet.RowCount - 1)
            {
                Spd.ActiveSheet.MoveRow(Spd.ActiveSheet.ActiveRowIndex, Spd.ActiveSheet.ActiveRowIndex + 1, true);
                Spd.ActiveSheet.ActiveRowIndex = Spd.ActiveSheet.ActiveRowIndex + 1;
            }
               

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (CheckForm())
            {
                if (ComForm.DspMsg("Q004", "").Equals(ComConst.LING))
                {
                    try
                    {
                        //保存
                        ArrayList lstSql = new ArrayList();
                        Model.fmd070 M_FMD070 = new Model.fmd070();

                        //FMD070

                        M_FMD070.CLBH = txtClbh.Text.Trim();    //材料编号
                        M_FMD070.PHBBH = txtPhb.Text.Trim();    //配合表编号
                        M_FMD070.ZDRQ = dtp_rq.Value.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo); //指定日
                        M_FMD070.ZT = ((Function.ListItem)cbbZT.SelectedItem).ID;   //状态
                        M_FMD070.BL = nudBL.Value.ToString();   //比例
                        M_FMD070.SYBH = ((Function.ListItem)cbbZZR.SelectedItem).ID;  //制作人
                        M_FMD070.PZRBH = ((Function.ListItem)cbbPZR.SelectedItem).ID;  //批准人
                        M_FMD070.BZ = txtBZ.Text.Replace("'", "''");           //备注
                        M_FMD070.PHBN = dtp_rq.Value.ToString("yy");    //配合表年
                        M_FMD070.ZF = lblZF.Text.Trim();        //追番


                        M_FMD070.RLZBH = ComForm.strUserName;
                        M_FMD070.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                        M_FMD070.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                        M_FMD070.RLDMM = PublicFun.Get_SysDNBH();

                        if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
                        {
                            //新增
                            lstSql.Add(B_FMD070.Add_SQL(M_FMD070));
                        }
                        else
                        {
                            //修改
                            lstSql.Add(B_FMD070.Update_SQL(M_FMD070));
                        }


                        //FMD080
                        //得到系数合计
                        double sumXS = 0;
                        for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                        {
                            sumXS += Convert.ToDouble(ComSpread.SpdGetValue(Spd, i, 3));
                        }
                        if (!String.IsNullOrEmpty(CLBH) && !String.IsNullOrEmpty(PBHBH))
                        {
                            //修改 先删除数据
                            lstSql.Add(B_FMD080.Delete_SQL(txtPhb.Text.Trim()));
                        }
                        for (int i = 0; i < Spd.ActiveSheet.RowCount; i++)
                        {
                            Model.fmd080 M_FMD080 = new Model.fmd080();
                            M_FMD080.PHBBH = txtPhb.Text.Trim();    //配合表编号
                            M_FMD080.YCLBH = ComSpread.SpdGetValue(Spd, i, 1);   //原材料编号
                            M_FMD080.ZL = Convert.ToDecimal(ComSpread.SpdGetValue(Spd, i, 3));   //重量
                            M_FMD080.GC = Convert.ToDecimal(ComSpread.SpdGetValue(Spd, i, 4));   //公差
                            M_FMD080.BZ = ComSpread.SpdGetValue(Spd, i, 5).Replace("'", "''");   //备注
                            M_FMD080.XSS = i + 1;               //显示顺
                            M_FMD080.JLDW = "002";          //计量单位
                            //系数
                            M_FMD080.XS = Convert.ToDouble(M_FMD080.ZL) / sumXS;   //系数

                            M_FMD080.RLZBH = ComForm.strUserName;
                            M_FMD080.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                            M_FMD080.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                            M_FMD080.RLDMM = PublicFun.Get_SysDNBH();



                            lstSql.Add(B_FMD080.Add_SQL(M_FMD080));
                        }

                        //更新FMD070 系数
                        //lstSql.Add(B_FMD070.UpdateXsByPHB(txtClbh.Text.Trim()));
                       // double sumBL = B_FMD070.GetSumBL(txtClbh.Text.Trim());
                        //新增条件下加上本身
                        //if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
                        //{
                        //    //新增
                        //    sumBL += double.Parse(M_FMD070.BL);
                        //}
                        //else
                        //{
                        //    //修改
                           
                        //}

                       // ArrayList lstPhb = B_FMD070.GetPhbs(txtClbh.Text.Trim());

                       //// lstSql.Add(B_FMD070.UpdateXsByPHB(txtPhb.Text.Trim(), sumBL));
                       // foreach (string phb in lstPhb)
                       // {
                       //     lstSql.Add(B_FMD070.UpdateXsByPHB(phb));
                       // }
                        
                        //if (lstPhb.Count == 0)
                        //{
                        //    lstSql.Add(B_FMD070.UpdateXsByPHB(txtPhb.Text.Trim(), sumBL));
                        //}
                        //else
                        //{
                        //    foreach (string phb in lstPhb)
                        //    {
                        //        lstSql.Add(B_FMD070.UpdateXsByPHB(phb, sumBL));
                        //    }
                        //}

                        //M_FMD070.XS = Convert.ToDouble(M_FMD070.BL) / sumBL;                        //系数

                        lstSql.Add(B_FMD070.UpdateXsByPHB(txtClbh.Text.Trim()));

                        DbHelperMySql.ExecuteSqlTran(lstSql);

                        ComForm.DspMsg("M002", "");

                        if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
                        {
                            //新增画面清空
                            ClearForm();
                        }
                       

                        this.Tag = "Save";
  
                        //this.Close();
                    }
                    catch (Exception ex)
                    {
                        ComForm.DspMsg("E013", "");
                        ComForm.InsertErrLog(ex.ToString(), "btnSave_Click @" + this.Name);
                    }
                }

               

            }
        }

        private void lbl_delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList lstCLBH = GetListYclbhCheck();    //得到选择的材料编号
            if (lstCLBH.Count == 0)
            {
                MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DialogResult dr = MessageBox.Show("是否要删除数据？", "是否删除?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {

                foreach (string str in lstCLBH)
                {
                    int iRow = GetRowidByYclbh(str);
                    if (iRow != -1)
                    {
                        Spd.ActiveSheet.RemoveRows(iRow, 1);
                    }

                }
            }

        }

        private void nudBL_Enter(object sender, EventArgs e)
        {
            nudBL.Select(0, nudBL.Text.Length);
        }

        private void PC11_sub1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtBZ.Focused)
            {
                ComForm.EnterKeyDown(e);
            }
        }

        private void txtPhb_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CLBH) && String.IsNullOrEmpty(PBHBH))
            {
                //New
                if (!String.IsNullOrEmpty(txtPhb.Text.Trim()))
                {
                    lblZF.Text = txtPhb.Text.Trim().Split('-')[1];
                }
            }
            else
            {
                //Modeify

            }
        }

    }
}
