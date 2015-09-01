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
    public partial class WinSubSYBH : Form
    {
        public WinSubSYBH()
        {
            InitializeComponent();
        }

        public WinSubSYBH(string BMBH)
        {
            this._conBMBH = BMBH;
            InitializeComponent();
        }
        public WinSubSYBH(string winQufen, string BM)
        {
            this._winqufen = winQufen;
            this._conBMBH = BM;
            InitializeComponent();
        }

        #region 变量定义
        public string _winqufen = String.Empty;
        public string _conSYBH = String.Empty;
        public string _conBMBH = String.Empty;
        public string _conKE = String.Empty;
        public string _conGWBH = String.Empty;
        public string _conZWBH = String.Empty;
        public string _strSYNAME = String.Empty;
        public string _strXI = String.Empty;
        public string _strXIAN = String.Empty;


        Model.fmd010 _modelFMD310 = new Model.fmd010();
        BLL.fmd010 _bllFMD310 = new BLL.fmd010();
        #endregion
        #region Load事件
        private void Window_Loaded(object sender, EventArgs e)  //DataGrid数据绑定
        {
            DataSet ds = new DataSet();
            _modelFMD310.SYBH = _conSYBH;

            ds = _bllFMD310.GetDaTaForPC05Spread("",_conSYBH );//(_modelFMD310, _strSYNAME);
            FillSpread(ds);
        }

        private void FillSpread(DataSet ds)
        {
            fpsSYDate.ActiveSheet.RowCount = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region SPD赋值
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    fpsSYDate.ActiveSheet.RowCount++;

                    fpsSYDate.ActiveSheet.Cells[i, 0].Text = ds.Tables[0].Rows[i]["SYBH"].ToString();
                    fpsSYDate.ActiveSheet.Cells[i, 1].Text = ds.Tables[0].Rows[i]["SYMC"].ToString();                  

                    
                }
                #endregion
                ComSpread.SpdLock(fpsSYDate, 0, 0, fpsSYDate.ActiveSheet.RowCount - 1, fpsSYDate.ActiveSheet.ColumnCount - 1);
                if (fpsSYDate.ActiveSheet.RowCount != 0)
                {
                    for (int i = 0; i < fpsSYDate.ActiveSheet.RowCount; i++)
                    {
                        this.fpsSYDate.Sheets[0].Cells[i, 0, i, fpsSYDate.ActiveSheet.ColumnCount - 1].BackColor = Color.LightYellow;
                    }
                    this.fpsSYDate.ActiveSheet.Cells[0, 0, 0, fpsSYDate.ActiveSheet.ColumnCount - 1].BackColor = Color.Lavender;
                }
            }
        }

        #endregion
        #region Spread事件
        private void fpsSYDate_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)//双击事件
        {
            if (e.ColumnHeader)
            {
                return;
            }
            int ActRow = fpsSYDate.ActiveSheet.ActiveRowIndex;
            _conSYBH = fpsSYDate.ActiveSheet.Cells[ActRow, 0].Text.ToString();
           
            _strSYNAME = fpsSYDate.ActiveSheet.Cells[ActRow,1].Text.ToString();
          

            this.Close();
        }

        private void fpsSYDate_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)//单击变色事件
        {
            if (fpsSYDate.ActiveSheet.RowCount > 0)
            {
                for (int i = 0; i < fpsSYDate.ActiveSheet.RowCount; i++)
                {
                    this.fpsSYDate.Sheets[0].Cells[i, 0, i, fpsSYDate.ActiveSheet.ColumnCount - 1].BackColor = Color.LightYellow;
                }
                this.fpsSYDate.ActiveSheet.Cells[e.Row, 0, e.Row, fpsSYDate.ActiveSheet.ColumnCount - 1].BackColor = Color.Lavender;
            }
        }
        #endregion
        #region 按钮事件
        private void btnYes_Click(object sender, EventArgs e) //确定按钮事件
        {
            if (fpsSYDate.ActiveSheet.RowCount > 0)
            {
                int ActRow = fpsSYDate.ActiveSheet.ActiveRowIndex;
                _conSYBH = fpsSYDate.ActiveSheet.Cells[ActRow, 0].Text.ToString();
              
                _strSYNAME = fpsSYDate.ActiveSheet.Cells[ActRow, 1].Text.ToString();
               


            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)//退出按钮事件
        {
            this.Close();
        }
        #endregion

        private void fpsSYDate_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < fpsSYDate.ActiveSheet.ColumnCount; i++)
                {
                    if (fpsSYDate.ActiveSheet.Columns.Get(i).Width <= 5
                        &&
                        fpsSYDate.ActiveSheet.Columns.Get(i).Resizable == true)
                    {
                        fpsSYDate.ActiveSheet.Columns.Get(i).Width = 30;
                    }
                }
            }
            catch (Exception ex)
            {
                ComForm.InsertErrLog(ex.ToString(), this.Name);
            }
        }
    }
}
