using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Function;

namespace BSC_System
{
    public partial class PC22_Dialog : Form
    {
        public PC22_Dialog()
        {
            InitializeComponent();
        }

        #region 公共属性
        private string _ckzlbh = string.Empty;
        /// <summary>
        /// 出库指令编号
        /// </summary>
        public string CKZLBH
        {
            set { _ckzlbh = value; }
            get { return _ckzlbh; }
        }
        #endregion

        #region  公共变量
        BLL.ffd050 B_FFD050 = new BLL.ffd050();
        BLL.ffd020 B_FFD020 = new BLL.ffd020();
        BLL.fmd060 B_FMD060 = new BLL.fmd060();
        BLL.fmd030 B_FMD030 = new BLL.fmd030();
        Function.systemdate sysDate = new Function.systemdate();
        #endregion

        #region 公共方法

        /// <summary>
        /// 得到客户名称
        /// </summary>
        private void Cpsm()
        {
            string cpsm = string.Empty;
            cpsm = cobKh.Text.Trim();
            cobKh.DataSource = B_FMD030.GetListPc25("").Tables[0];
            cobKh.DisplayMember = "KHMC";
            cobKh.ValueMember = "KHBH";
            cobKh.Text = null;

            string PM, PH, CLBH;
            PM = PH = CLBH = "";

            PM = cobPM.Text.ToString();
            PH = cobPH.Text.ToString();
            CLBH = cobCL.Text.ToString();

            cobPM.DataSource = B_FMD060.get_DT(PM, PH, CLBH, "PM");
            cobPM.DisplayMember = "KHMC";
            cobPM.ValueMember = "KHBH";
            cobPM.Text = null;

            cobPH.DataSource = B_FMD060.get_DT(PM, PH, CLBH, "PH");
            cobPH.DisplayMember = "KHMC";
            cobPH.ValueMember = "KHBH";
            cobPH.Text = null;

            cobCL.DataSource = B_FMD060.get_DT(PM, PH, CLBH, "CLBH");
            cobCL.DisplayMember = "KHMC";
            cobCL.ValueMember = "KHBH";
            cobCL.Text = null;




        }

        /// <summary>
        /// 初始化Form窗体
        /// </summary>
        /// <returns></returns>
        private void InitForm()
        {
            this.Text = "新增";
            CKZLBH = string.Empty;

            dtp_rq.Value = Convert.ToDateTime(sysDate.Get_SysDate(ComConst.dateStyle_Y_M_D));        //出库日
            cobPM.Text = "";           //品名
            cobPH.Text = "";           //品号
            cobCL.Text = "";           //材料
            txt_ckzlbh.Text = "";       //出库指令编号
            cobKh.Text = "";           //客户
            txt_zksl.Text = "";         //在库数量
            nud_ckzssl.Value = 0;       //出库指示数量
            nud_dj.Value = 0;           //单价
            txt_je.Text = "";           //金额
            txt_bz.Text = "";           //备注
        }
        /// <summary>
        /// 验证Form窗体
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            //dtp_rq        //出库日
            //cobPM        //品名
            //cobPH        //品号
            //cobCL        //材料
            //txt_ckzlbh    //出库指令编号
            //txt_kh        //客户
            //txt_zksl      //在库数量
            //nud_ckzssl    //出库指示数量
            //nud_dj        //单价
            //txt_je        //金额
            //txt_bz        //备注

            if (String.IsNullOrEmpty(cobPM.Text.Trim()) || !B_FMD060.ExistsPM(cobPM.Text.Trim()))
            {
                MessageBox.Show("品名为空或品名不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cobPM.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cobPH.Text.Trim()) || !B_FMD060.ExistsPH(cobPM.Text.Trim(), cobPH.Text.Trim()))
            {
                MessageBox.Show("品号为空或品号不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cobPH.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cobCL.Text.Trim()) || !B_FMD060.ExistsCLBH(cobPM.Text.Trim(), cobPH.Text.Trim(), cobCL.Text.Trim()))
            {
                MessageBox.Show("材料为空或材料不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cobCL.Focus();
                return false;
            }


            if (String.IsNullOrEmpty(txt_ckzlbh.Text.Trim()))
            {
                MessageBox.Show("出库指令编号不能为空!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_ckzlbh.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(cobKh.Text.Trim()))
            {
                MessageBox.Show("客户不能为空!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cobKh.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txt_zksl.Text.Trim()) || Convert.ToInt32(txt_zksl.Text.Trim()) <=0 )
            {
                MessageBox.Show("在库数量小于0，不能出库!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                nud_ckzssl.Focus();
                return false;
            }
            
            if (nud_ckzssl.Value == 0)
            {
                MessageBox.Show("出库数量不能为“0”!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                nud_ckzssl.Focus();
                return false;
            }
            if (nud_ckzssl.Value > Convert.ToDecimal(txt_zksl.Text.Trim()))
            {
                MessageBox.Show("出库数量大于在库数量!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                nud_ckzssl.Focus();
                return false;
            }
            // 20150723 用户指示修正
            //if (nud_dj.Value == 0)
            //{
            //    MessageBox.Show("单价不能为0!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    nud_dj.Focus();
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 生成出库指示单号
        /// </summary>
        /// <returns></returns>
        private string GenerateCKZSBH()
        {
            string ckdh = string.Empty;
            string zf = GenerateZF();             //追番
            if (!String.IsNullOrEmpty(cobPM.Text.Trim()) &&
                !String.IsNullOrEmpty(cobPH.Text.Trim()) &&
                !String.IsNullOrEmpty(cobCL.Text.Trim()))
            {
                //dtp_rq
                ckdh = "CK_" + cobPH.Text.Trim() + "_" + cobCL.Text.Trim() + "_" + dtp_rq.Value.ToString("yyMMdd") + "_" + zf;
            }

            //得到在库数
            txt_zksl.Text = B_FFD020.GetZKSL(cobCL.Text.Trim(), cobPH.Text.Trim(),"").ToString();

            return ckdh;
        }

        /// <summary>
        /// 生成追番
        /// </summary>
        /// <returns></returns>
        public string GenerateZF()
        {
            Model.ffd050 M_FFD050 = new Model.ffd050();

            M_FFD050.CKZLRQ = dtp_rq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);    //出库日
            M_FFD050.PM = cobPM.Text.Trim();                       //品名
            M_FFD050.PH = cobPH.Text.Trim();                       //品号
            M_FFD050.CLBH = cobCL.Text.Trim();                     //材料

            return  B_FFD050.GetMaxZF(M_FFD050);
        }
        #endregion
        private void PC22_Dialog_Load(object sender, EventArgs e)
        {
            cbb_status.Items.Add(new Function.ListItem("0", "未出库"));
            cbb_status.Items.Add(new Function.ListItem("1", "已出库"));
            cbb_status.SelectedIndex = 0;

           
            //dtp_rq.MaxDate = Convert.ToDateTime(sysDate.Get_SysDate(ComConst.dateStyle_Y_M_D)); //设置最大日期
            dtp_rq.Value = Convert.ToDateTime(sysDate.Get_SysDate(ComConst.dateStyle_Y_M_D)); //设置最大日期
            Cpsm();
            if (String.IsNullOrEmpty(CKZLBH))
            {
                this.Text = "新增";
                //btn_save.Text = "添加";
                cobPM.Focus();
                cbb_status.Enabled = false;
            }
            else
            {
                this.Text = "修改";
                //btn_save.Text = "修改";
                cobKh.Focus();

                //幅值

                Model.ffd050 M_FFD050 = B_FFD050.GetModel(CKZLBH);
                if (M_FFD050 != null)
                {
                    dtp_rq.Value = Convert.ToDateTime(M_FFD050.CKZLRQ);                           //出库日
                    cobPM.Text = M_FFD050.PM ;                                                 //品名
                    cobPH.Text = M_FFD050.PH ;                                                 //品号
                    cobCL.Text = M_FFD050.CLBH;                                                //材料
                    txt_ckzlbh.Text = M_FFD050.CKZLBH;                                          //出库指令编号
                    cobKh.SelectedValue = M_FFD050.KHBH;
                    txtKHBH.Text = M_FFD050.KHBH; //客户
                    nud_ckzssl.Value= Convert.ToDecimal(M_FFD050.ZSSLHJ);                       //出库指示数量
                    nud_dj.Value = Convert.ToDecimal(M_FFD050.DJ);                              //单价
                    txt_bz.Text =  M_FFD050.BZ;                                                 //备注

                    if (M_FFD050.WCQF == "1")
                    {
                        cbb_status.Text = "已出库";
                    }
                    else
                    {
                        cbb_status.Text = "未出库";
                    }
                    
                    cbb_status.Text = "";
                    txt_zksl.Text = B_FFD020.GetZKSL(M_FFD050.CLBH, M_FFD050.PH, txt_ckzlbh.Text.Trim()).ToString();    //在库数量
                }
           


                //锁定
                dtp_rq.Enabled = false;
                cobPM.Enabled = false;
                cobPH.Enabled = false;
                cobCL.Enabled = false;
            }
        }   

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckForm())
                {
                    if (ComForm.DspMsg("Q004", "").Equals(ComConst.LING))
                    {
                        //Model.ffd050 M_FFD050 = new Model.ffd050();
                        Model.ffd050 M_FFD050 = B_FFD050.GetModel(CKZLBH);
                        if (M_FFD050 == null)
                        {
                            M_FFD050 = new Model.ffd050();
                        }
                        M_FFD050.CKZLRQ = dtp_rq.Value.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);    //出库日
                        M_FFD050.PM = cobPM.Text.Trim();                       //品名
                        M_FFD050.PH = cobPH.Text.Trim();                       //品号
                        M_FFD050.CLBH = cobCL.Text.Trim();                     //材料
                        M_FFD050.CKZLBH = txt_ckzlbh.Text.Trim();               //出库指令编号
                        M_FFD050.KHBH = cobKh.SelectedValue.ToString().Trim();                     //客户
                        M_FFD050.ZSSLHJ = Convert.ToInt32(nud_ckzssl.Value);    //出库指示数量
                        M_FFD050.DJ = nud_dj.Value;                             //单价
                        M_FFD050.BZ = txt_bz.Text.Replace("'", "''");                              //备注
                        M_FFD050.DMQF = "2";                                    //PC
                        M_FFD050.CKZLXDZ = ComForm.strUserName;                 //出库指令下达者
                        //M_FFD050.WCQF = "0";                                    //完成区分 0：未完成
                        M_FFD050.WCQF = ((ListItem)cbb_status.SelectedItem).ID;                                    //完成区分 0：未完成
                        string[] strs = txt_ckzlbh.Text.Trim().Split('_');      //
                        M_FFD050.ZF = strs[strs.Length - 1];                      //追番
                        // txt_zksl .Text.Trim();      //在库数量
                        //txt_je.Text.Trim();         //金额

                        if (String.IsNullOrEmpty(CKZLBH))
                        {
                            //添加
                            M_FFD050.CKWCS = 0;
                            M_FFD050.RLZBH = ComForm.strUserName;
                            M_FFD050.RLR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                            M_FFD050.RLSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                            M_FFD050.RLDMM = PublicFun.Get_SysDNBH();

                            B_FFD050.Add(M_FFD050);
                            //MessageBox.Show("新增成功!");
                            ComForm.DspMsg("M002", "");

                        }
                        else
                        {
                            //修改
                            M_FFD050.GXZBH = ComForm.strUserName;
                            M_FFD050.GXR = PublicFun.GetSystemDateTime(Const.Date, Const.dateStyle_Y_M_D);
                            M_FFD050.GXSJ = PublicFun.GetSystemDateTime(Const.Time, "");
                            M_FFD050.GXDMM = PublicFun.Get_SysDNBH();
                            B_FFD050.Update(M_FFD050);
                            //MessageBox.Show("修改成功!");
                            ComForm.DspMsg("M002", "");
                        }
                        this.Tag = "Save";
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("保存失败");
                ComForm.DspMsg("E013", "");
                ComForm.InsertErrLog(ex.ToString(), "btn_save_Click @" + this.Name);
            }

        }

        private void nud_ckzssl_ValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_zksl.Text.Trim()) && !String.IsNullOrEmpty(nud_ckzssl.Text.Trim()))
            {
                decimal ckslValue = Convert.ToDecimal(nud_ckzssl.Text.Trim());      //出库数
                decimal zkslValue = Convert.ToDecimal(txt_zksl.Text.Trim());        //在库数
                if (ckslValue > zkslValue)
                {
                    //出库数大于在库数
                    MessageBox.Show("出库数量不能大于在库数量,出库数量已经默认成最大在库数。");
                    //DialogResult dr = MessageBox.Show("出库数量大于在库数量，现有在库是否全部出库?", "是否出库?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    //if (dr == System.Windows.Forms.DialogResult.No)
                    //{
                    //    nud_ckzssl.Value = 0;
                    //}
                }
                else
                {
                    txt_je.Text = Math.Round((nud_ckzssl.Value * nud_dj.Value), 2, MidpointRounding.AwayFromZero).ToString();
                }
            }
            
        }

        private void nud_dj_ValueChanged(object sender, EventArgs e)
        {
            txt_je.Text = Math.Round((nud_ckzssl.Value * nud_dj.Value), 2, MidpointRounding.AwayFromZero).ToString();
        }

        private void dtp_rq_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CKZLBH))
            {
                txt_ckzlbh.Text = GenerateCKZSBH();
            }
           
        }

        private void txt_pm_Leave(object sender, EventArgs e)
        {
           
            TextBox txtBox = (TextBox)sender;
            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                txt_ckzlbh.Text = "";
                return;
            }

            if (B_FMD060.ExistsPM(txtBox.Text.Trim()))
            {
                if (String.IsNullOrEmpty(CKZLBH))
                {
                    txt_ckzlbh.Text = GenerateCKZSBH();
                }
            }
            else
            {
                txt_ckzlbh.Text = "";
                txtBox.Focus();
                txtBox.SelectAll();
                MessageBox.Show("品名不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }           
        }

        private void txt_ph_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                txt_ckzlbh.Text = "";
                return;
            }
            if (B_FMD060.ExistsPH(cobPM.Text.Trim(), txtBox.Text.Trim()))
            {
                if (String.IsNullOrEmpty(CKZLBH))
                {
                    txt_ckzlbh.Text = GenerateCKZSBH();
                }
            }
            else
            {
                txt_ckzlbh.Text = "";
                txtBox.Focus();
                txtBox.SelectAll();
                MessageBox.Show("品号不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }

        private void txt_cl_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                txt_ckzlbh.Text = "";
                return;
            }
            if (B_FMD060.ExistsCLBH(cobPM.Text.Trim(), cobPH.Text.Trim(), txtBox.Text.Trim()))
            {
                if (String.IsNullOrEmpty(CKZLBH))
                {
                    txt_ckzlbh.Text = GenerateCKZSBH();
                }
            }
            else
            {
                txt_ckzlbh.Text = "";
                txtBox.Focus();
                txtBox.SelectAll();
                MessageBox.Show("材料编号不存在!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void txt_cl_TextChanged(object sender, EventArgs e)
        {

        }

        private void nud_ckzssl_Enter(object sender, EventArgs e)
        {
            nud_ckzssl.Maximum = Convert.ToDecimal(txt_zksl.Text.Trim());
            nud_ckzssl.Select(0, nud_ckzssl.Text.Length);
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PC22_Dialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txt_bz.Focused)
            {
                ComForm.EnterKeyDown(e);
            }
            
        }

        private void PC22_Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Tag.ObjToString() != "Save")
            {
                //DialogResult dr = MessageBox.Show("当前画面数据没有保存，是否关闭当前画面?", "是否关闭?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //if (dr == DialogResult.No)
                //{
                //    e.Cancel = true;
                //}
                if (!ComForm.DspMsg("Q001", "").Equals(Const.LING))  //是否要退出？
                {
                    e.Cancel = true;
                }
            }

        }

        private void nud_dj_Enter(object sender, EventArgs e)
        {
            nud_dj.Select(0, nud_dj.Text.Length);
        }

        private void txt_pm_TextChanged(object sender, EventArgs e)
        {
            cobPH.Text = "";
            cobCL.Text = "";
            txt_ckzlbh.Text = "";
        }

        private void txt_ph_TextChanged(object sender, EventArgs e)
        {
            cobCL.Text = "";
            txt_ckzlbh.Text = "";
        }

        private void nud_ckzssl_Leave(object sender, EventArgs e)
        {



        }

        private void nud_ckzssl_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(txt_zksl.Text.Trim()) && !String.IsNullOrEmpty(nud_ckzssl.Text.Trim()))
            //{
            //    decimal ckslValue = Convert.ToDecimal(nud_ckzssl.Text.Trim());      //出库数
            //    decimal zkslValue = Convert.ToDecimal(txt_zksl.Text.Trim());        //在库数
            //    if (ckslValue > zkslValue)
            //    {
            //        //出库数大于在库数
            //        MessageBox.Show("出库数量不能大于在库数量!");
            //        //DialogResult dr = MessageBox.Show("出库数量大于在库数量，现有在库是否全部出库?", "是否出库?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //        //if (dr == System.Windows.Forms.DialogResult.No)
            //        //{
            //        //    nud_ckzssl.Value = 0;
            //        //}
            //    }
            //}
        }

        private void txtKHBH_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cobKh_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cobKh.Text.ToString().Trim()) == false)
            {
                txtKHBH.Text = B_FMD030.GetKHBH(cobKh.Text.ToString().Trim());

            }
            //else
            //{
            //    txtKHBH.Text = "";
            //}
        }

        private void txtKHBH_Leave(object sender, EventArgs e)
        {
            cobKh.SelectedValue = txtKHBH.Text.Trim();
        }

        private void cobPM_Leave(object sender, EventArgs e)
        {
            string PM, PH, CLBH;
            PM = PH = CLBH = "";

            PM = cobPM.Text.ToString();
           // PH = cobPH.Text.ToString();
            //CLBH = cobCL.Text.ToString();
            cobPH.DataSource = B_FMD060.get_DT(PM, PH, CLBH, "PH");
            cobPH.DisplayMember = "KHMC";
            cobPH.ValueMember = "KHBH";
            cobPH.Text = null;

          
        }

        private void cobPH_Leave(object sender, EventArgs e)
        {
            string PM, PH, CLBH;
            PM = PH = CLBH = "";

            PM = cobPM.Text.ToString();
            PH = cobPH.Text.ToString();
           // CLBH = cobCL.Text.ToString();
            cobCL.DataSource = B_FMD060.get_DT(PM, PH, CLBH, "CLBH");
            cobCL.DisplayMember = "KHMC";
            cobCL.ValueMember = "KHBH";
            cobCL.Text = null;
        }

        private void cobCL_Leave(object sender, EventArgs e)
        {
            txt_ckzlbh.Text = GenerateCKZSBH();
        }
    }
}
