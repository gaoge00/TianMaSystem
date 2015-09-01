using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Function;

namespace BSC_System
{
    public partial class PC11_sub2 : Form
    {
        #region 公共属性

        private Model.fmd080 _fmd080;
        /// <summary>
        /// 明细
        /// </summary>
        public Model.fmd080 M_FMD080
        {
            get { return _fmd080; }
            set { _fmd080 = value; }
        }

        private ArrayList _lstyclbh;
        /// <summary>
        /// 原材料集合
        /// </summary>
        public ArrayList listYclbh
        {
            get { return _lstyclbh; }
            set { _lstyclbh = value; }
        }

        #endregion

        #region 公共变量
        BLL.fmd040 B_FMD040 = new BLL.fmd040();
        #endregion

        #region 公共方法

        /// <summary>
        /// 生成公差
        /// 公差: 10000g以上 ± 100g ( > 10000 )
        ///       10000g以下 100g以上(10000~100) ± 1% (小数点 四舍五入)
        ///       100g 以下 ( < 10000) ±1g
        /// </summary>
        /// <param name="zl"></param>
        /// <returns></returns>
        public decimal GenerateGC(decimal zl)
        {
            return B_FMD040.GET_GC(zl);
        }
        #endregion

        public PC11_sub2()
        {
            InitializeComponent();
        }

        private void PC11_sub2_Load(object sender, EventArgs e)
        {
            if (M_FMD080 != null)
            {
                txtYCL.Text = M_FMD080.YCLBH;       //原材料
                nudSL.Value = M_FMD080.ZL.Value;    //重量
                nudGC.Value = M_FMD080.GC.Value;    //公差
                txtBZ.Text = M_FMD080.BZ;           //备注
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //Check窗体
            //判断原材料
            if (String.IsNullOrEmpty(txtYCL.Text.Trim()))
            {
                MessageBox.Show("原材料不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtYCL.Focus();
                return;
            }
            else
            {
                //原材料在库中不存在
                if (!B_FMD040.Exists(txtYCL.Text.Trim()))
                {
                    MessageBox.Show("原材料编号不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtYCL.Focus();
                    return;
                }
                //原材料已经添加到配合表
                if (M_FMD080 == null) 
                {
                    //添加
                    if (listYclbh.Contains(txtYCL.Text.Trim()))
                    {
                        MessageBox.Show("原材料已经添加到配合表！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtYCL.Focus();
                        return;
                    }
                }
                else
                {
                    //修改
                    listYclbh.Remove(M_FMD080.YCLBH);
                    if (listYclbh.Contains(txtYCL.Text.Trim()))
                    {
                        MessageBox.Show("原材料已经添加到配合表！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtYCL.Focus();
                        return;
                    }
                }

               
            }
            if (nudSL.Value == 0)
            {
                MessageBox.Show("重量不能为零！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                nudSL.Focus();
                return;
            }

            M_FMD080 = new Model.fmd080();
            M_FMD080.YCLBH = txtYCL.Text;       //原材料
            M_FMD080.ZL = nudSL.Value;    //重量
            M_FMD080.GC =nudGC.Value;    //公差
            M_FMD080.BZ = txtBZ.Text;           //备注
            this.Tag = "Save";
            this.DialogResult = DialogResult.OK;
        }

        private void nudSL_ValueChanged(object sender, EventArgs e)
        {
            nudGC.Value = GenerateGC(nudSL.Value);
        }

        private void txtYCL_Leave(object sender, EventArgs e)
        {
            //if (btnClose.Focus())
            //{
            //    return;
            //}
            //判断原材料是否存在
            if (!String.IsNullOrEmpty(txtYCL.Text.Trim()))
            {
                if (!B_FMD040.Exists(txtYCL.Text.Trim()))
                {
                    MessageBox.Show("原材料编号不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtYCL.Focus();
                    txtYCL.SelectAll();
                }
            }

        }

        private void PC11_sub2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtBZ.Focused)
            {
                ComForm.EnterKeyDown(e);
            }
        }

        private void PC11_sub2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Tag.ObjToString() != "Save")
            {
                //DialogResult dr = MessageBox.Show("当前画面数据没有保存，是否关闭当前画面?", "是否关闭?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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

        private void nudSL_Enter(object sender, EventArgs e)
        {
            nudSL.Select(0, nudSL.Text.Length);
        }

        private void nudGC_Enter(object sender, EventArgs e)
        {
            nudGC.Select(0, nudGC.Text.Length);
        }
    }
}
