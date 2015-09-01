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
    public partial class PC30 : Form
    {
        public PC30()
        {
            InitializeComponent();
        }


        BLL.fmd030 _bllfmd030 = new BLL.fmd030();
        BLL.fmd100 _bllfmd100 = new BLL.fmd100();

        private void PC30_Load(object sender, EventArgs e)
        {
            Cpsm();
        }


        private void Cpsm()
        {
            string cpsm = string.Empty;
            cpsm = cobKhmc.Text.Trim();
            cobKhmc.DataSource = _bllfmd030.GetList("").Tables[0];
            cobKhmc.DisplayMember = "KHMC";
            cobKhmc.Text = null;
        }


        private void cobKhmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spd_Form_Load();
        }

        public void Spd_Form_Load()
        {
            string strKhmc = cobKhmc.Text.Trim();

            try
            {
                DataTable dtspd = new DataTable();
                dtspd = _bllfmd100.GetSpread(strKhmc);
                fspd.ActiveSheet.DataSource = null;
                fspd.ActiveSheet.RowCount = dtspd.Rows.Count;


                for (int i = 0; i < dtspd.Rows.Count; i++)
                {
                    fspd.ActiveSheet.Cells[i, 1].Text = dtspd.Rows[i]["KHBH"].ToString();
                    fspd.ActiveSheet.Cells[i, 2].Text = dtspd.Rows[i]["KHMC"].ToString();
                    fspd.ActiveSheet.Cells[i, 3].Text = dtspd.Rows[i]["PMGC"].ToString();
                    fspd.ActiveSheet.Cells[i, 4].Text = dtspd.Rows[i]["PHGC"].ToString();
                    fspd.ActiveSheet.Cells[i, 5].Text = dtspd.Rows[i]["CLBHGC"].ToString();

                    fspd.ActiveSheet.Cells[i, 6].Text = dtspd.Rows[i]["PMKH"].ToString();
                    fspd.ActiveSheet.Cells[i, 7].Text = dtspd.Rows[i]["PHKH"].ToString();
                    fspd.ActiveSheet.Cells[i, 8].Text = dtspd.Rows[i]["CLBHKH"].ToString();
                }

            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E016", "");   //数据加载失败！
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void llaXz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                PC30_sub winPC30 = new PC30_sub();
                winPC30.ShowDialog(); // 新增
                Spd_Form_Load();                  
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                if (getcheckHasTrue() > 1)
                {
                    MessageBox.Show("请选择一条数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //ComForm.DspMsg("W004", "");   //数据加载失败！
                    return;
                }
                else if (getcheckHasTrue() == 1)
                {
                    string strKHBH = string.Empty;
                    string strKHMC = string.Empty;
                    string strPhgc = string.Empty;
                    string strPmgc = string.Empty;
                    string strClbhgc = string.Empty;
                    string strPmhk = string.Empty;
                    string strphkh = string.Empty;
                    string strClbhkh = string.Empty;

                    for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
                    {
                        if (fspd.ActiveSheet.Cells[i, 0].Text == "True")
                        {
                            strKHBH = fspd.ActiveSheet.Cells[i, 1].Text.Trim();
                            strKHMC = fspd.ActiveSheet.Cells[i, 2].Text.Trim();
                            strPhgc = fspd.ActiveSheet.Cells[i, 3].Text.Trim();
                            strPmgc = fspd.ActiveSheet.Cells[i, 4].Text.Trim();
                            strClbhgc = fspd.ActiveSheet.Cells[i, 5].Text.Trim();

                            strPmhk = fspd.ActiveSheet.Cells[i, 6].Text.Trim();
                            strphkh = fspd.ActiveSheet.Cells[i, 7].Text.Trim();
                            strClbhkh = fspd.ActiveSheet.Cells[i, 8].Text.Trim();

                            i = fspd.ActiveSheet.Rows.Count;
                        }
                    }


                    PC30_sub winPC30 = new PC30_sub(strKHBH, strKHMC, strPhgc, strPmgc,strClbhgc, strPmhk, strphkh,strClbhkh);
                    winPC30.ShowDialog(); // 修正
                    Spd_Form_Load();


                }
                else
                {
                    MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }


        #region spd用方法
        private void SetspdColor(int eRow)
        {
            if (fspd.ActiveSheet.RowCount != 0)
            {
                for (int i = 0; i < fspd.ActiveSheet.RowCount; i++)
                {
                    fspd.ActiveSheet.Rows.Get(i).ForeColor = Color.Black;
                    //fspd.ActiveSheet.Rows.Get(i).BackColor = Color.Empty;
                    fspd.ActiveSheet.Rows.Get(i).BackColor = Color.LightGoldenrodYellow;

                }

                this.fspd.ActiveSheet.Rows[eRow].BackColor = Color.Lavender;
            }
        }
        #endregion 



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


        List<Model.fmd100> GetModel()
        {
            List<Model.fmd100> listmodelFKD100 = new List<Model.fmd100>();
            Model.fmd100 modelfmd010 = new Model.fmd100();
            for (int i = 0; i < fspd.ActiveSheet.Rows.Count; i++)//循环spread model赋值
            {
                if (fspd.ActiveSheet.Cells[i, 0].Text == "True")
                {
                    modelfmd010 = new Model.fmd100();
                    modelfmd010 = fillModel(i);
                    listmodelFKD100.Add(modelfmd010);
                }
            }
            return listmodelFKD100;
        }

        Model.fmd100 fillModel(int i)
        {
            Model.fmd100 modelfmd010 = new Model.fmd100();
            #region model 赋值
            modelfmd010.KHBH = fspd.ActiveSheet.Cells[i, 1].Text.Trim();
            modelfmd010.PMGC = fspd.ActiveSheet.Cells[i, 3].Text.Trim();
            modelfmd010.PHGC = fspd.ActiveSheet.Cells[i, 4].Text.Trim();
            modelfmd010.CLBHGC = fspd.ActiveSheet.Cells[i, 5].Text.Trim();

            #endregion
            return modelfmd010;
        }

        List<Model.fmd100> listmodelFMD100 = new List<Model.fmd100>();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<string> sqlList = new List<string>();
                if (getcheckHasTrue() > 0)// 有选中的数据
                {
                    if (ComForm.DspMsg("Q003", "") == "0")
                    {

                        listmodelFMD100 = GetModel();//model赋值                       
                        foreach (Model.fmd100 modelFMD100 in listmodelFMD100)
                        {

                            sqlList.Add(_bllfmd100.Delete(modelFMD100.KHBH,modelFMD100.PMGC, modelFMD100.PHGC, modelFMD100.CLBHGC));

                        }
                        //删除成功
                        if (DbHelperMySql.ExecuteSqlTran(sqlList).Equals(0))
                        {
                            ComForm.DspMsg("M001", "");
                            DataTable dt = new DataTable();
                            Spd_Form_Load();//重新加载 spread
                        }
                        else
                        {
                            ComForm.DspMsg("E012", "");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E012", "");
                ComForm.InsertErrLog(ex.ToString(), "btnDel_Click @" + this.Name);
            }
        }

        private void fspd_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            SetspdColor(e.Row);
        }

    }
}
