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
    public partial class PC30_sub2 : Form
    {
        public PC30_sub2()
        {
            InitializeComponent();
        }

        BLL.fmd100 _bllfmd100 = new BLL.fmd100();
        BLL.fmd060 _bllfmd060 = new BLL.fmd060();

        public string _PMGC = string.Empty;
        public string _PHGC = string.Empty;
        public string _CLBH = string.Empty;

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


        private void PC30_sub2_Load(object sender, EventArgs e)
        {
            Spd_Form_Load();
        }


        public void Spd_Form_Load()
        {
            try
            {
                DataTable dtspd = new DataTable();
                dtspd = _bllfmd060.GetList("").Tables[0];
                fspd.ActiveSheet.DataSource = null;
                fspd.ActiveSheet.RowCount = dtspd.Rows.Count;


                for (int i = 0; i < dtspd.Rows.Count; i++)
                {
                    
                    fspd.ActiveSheet.Cells[i, 1].Text = dtspd.Rows[i]["PM"].ToString();
                    fspd.ActiveSheet.Cells[i, 2].Text = dtspd.Rows[i]["PH"].ToString();
                    fspd.ActiveSheet.Cells[i, 3].Text = dtspd.Rows[i]["CLBH"].ToString();

                    if (fspd.ActiveSheet.Cells[i, 1].Text + fspd.ActiveSheet.Cells[i, 2].Text + fspd.ActiveSheet.Cells[i, 3].Text
                        == _PMGC + _PHGC + _CLBH)
                    {
                        fspd.ActiveSheet.Cells[i, 0].Text = "True";
                    }
                }

            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");   //数据加载失败！
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        int getcheckHasTrue()//保存时 只要有选中的就可以 保存
        {
            int ischeckcount = 0;
            for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
            {
                if (fspd.ActiveSheet.Cells[i, 0].Text == "True")
                {
                    ischeckcount++;
                }
            }
            return ischeckcount;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (getcheckHasTrue() == 0)
                {
                    _PMGC =_PHGC = _CLBH = "";
                    this.Close(); 
                }

                else if (getcheckHasTrue() > 1)
                {
                    MessageBox.Show("请选择一条数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //ComForm.DspMsg("W004", "");   //数据加载失败！
                    return;
                }
                else if (getcheckHasTrue() == 1)
                {
                  
                    for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
                    {
                        if (fspd.ActiveSheet.Cells[i, 0].Text == "True")
                        {
                            _PMGC = fspd.ActiveSheet.Cells[i, 1].Text.Trim();
                            _PHGC = fspd.ActiveSheet.Cells[i, 2].Text.Trim();
                            _CLBH = fspd.ActiveSheet.Cells[i, 3].Text.Trim();

                            i = fspd.ActiveSheet.Rows.Count;
                        }
                    }

                    this.Close();      
                }
                else
                {
                    MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                // Comm.InsertErrLog(ex.ToString(), this.Name);
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
  
        }
    }
}
