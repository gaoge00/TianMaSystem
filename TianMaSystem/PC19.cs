using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Diagnostics;
using Function;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

namespace BSC_System
{
    public partial class PC19 : Form
    {
        public PC19()
        {
            InitializeComponent();
        }



        #region 定义变量
        TimeSpan beforeTime;            //Excel启动之前时间
        TimeSpan afterTime;             //Excel启动之后时间
        string Save_Path = System.Configuration.ConfigurationSettings.AppSettings["Path_PC19"].ToString();
        BLL.fed050 _bllfed050 = new BLL.fed050();
        BLL.fmd010 _bllfmd010 = new BLL.fmd010();
        BLL.ffd020 _bllffd020 = new BLL.ffd020();
        BLL.fed060 _bllfed060 = new BLL.fed060();
        #endregion

        private void PC19_Load(object sender, EventArgs e)
        {
            LoadFrom();
            dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
            dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
        }

        public void LoadFrom()
        {
            string cpsm = string.Empty;

            // 硫化结果
            cpsm = cobLhjg.Text.Trim();
            cobLhjg.DataSource = Comm.GetConDataHash("cobLhjg");
            cobLhjg.DisplayMember = "key";
            cobLhjg.ValueMember = "value";
            cobLhjg.Text = cpsm;

            // 计量实施者
            cpsm = cobJlssz.Text.Trim();
            cobJlssz.DataSource = _bllfed050.GetSymc(" ").Tables[0];
            cobJlssz.DisplayMember = "SYMC";
            cobJlssz.Text = null;
        }

        #region Buttons 事件处理
        /// <summary>
        /// Buttons
        /// Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttons_Click(object sender, EventArgs e)
        {
            string sBtnName = ((Button)(sender)).Name.ToString();
            switch (sBtnName)
            {
                case "btnClear":       // 清空
                    SetClea();
                    break;
                case "btnExcel":    // EXCEL
                    SetExcel();
                    break;
            }
        }
        #endregion


        public void SetClea()
        {
            if ("0" == Function.ComForm.DspMsg("Q002", ""))
            {
                dateStartRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
                dateEndRq.Value = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, "yyyy/MM/dd"));
                txtClbh.Text = string.Empty;
                cobLhjg.Text = "";
                cobJlssz.Text = "";
            
            }
            else
            {
                return;
            }
        }

        public void WipeFile(string filename, int timesToWrite)
        {
            try
            {
                if (File.Exists(filename))
                {
                    //设置文件的属性为正常，这是为了防止文件是只读
                    File.SetAttributes(filename, FileAttributes.Normal);
                    //计算扇区数目
                    double sectors = Math.Ceiling(new FileInfo(filename).Length / 512.0);
                    // 创建一个同样大小的虚拟缓存
                    byte[] dummyBuffer = new byte[512];
                    // 创建一个加密随机数目生成器
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    // 打开这个文件的FileStream
                    FileStream inputStream = new FileStream(filename, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
                    {
                        // 文件流位置
                        inputStream.Position = 0;
                        //循环所有的扇区
                        for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
                        {
                            //把垃圾数据填充到流中
                            rng.GetBytes(dummyBuffer);
                            // 写入文件流中
                            inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
                        }
                    }
                    // 清空文件
                    inputStream.SetLength(0);
                    // 关闭文件流
                    inputStream.Close();
                    // 清空原始日期需要
                    DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                    File.SetCreationTime(filename, dt);
                    File.SetLastAccessTime(filename, dt);
                    File.SetLastWriteTime(filename, dt);
                    // 删除文件
                    File.Delete(filename);
                }
            }
            catch (Exception)
            {
            }
        }

        public void SetExcel()
        {
            try
            {
                string strStartRq = dateStartRq.Value.ToString("yyyy/MM/dd");
                string strEndRq = dateEndRq.Value.ToString("yyyy/MM/dd");
                string strClbh = txtClbh.Text.Trim();
                string strLhqf = Comm.GetDataName1(cobLhjg.Text.Trim(), "cobLhjg");
                string strJlssz = string.Empty;
                DataTable dtsybh = _bllfmd010.GetList("symc = '" + cobJlssz.Text.Trim() + "' ").Tables[0];
                if (0 < dtsybh.Rows.Count)
                {
                    strJlssz = dtsybh.Rows[0]["SYBH"].ToString().Trim();
                }
                if (string.IsNullOrEmpty(strClbh))
                {
                    ComForm.DspMsg("W002", "材料编号");
                    txtClbh.Focus();
                    return;
                }
                DataTable dt = _bllfed050.GetPc19Excel(strStartRq, strEndRq, strClbh, strLhqf, strJlssz);
                if (dt.Rows.Count > 0)
                {
                    if (ComForm.DspMsg("Q012", "").Equals(ComConst.LING))
                    {
                        //int countexcel = 0;
                        beforeTime = DateTime.Now.TimeOfDay;
                        #region
                        //获取服务器时间
                        string strdm = Convert.ToDateTime(PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_Y_M_D)
                            + " " + PublicFun.GetSystemDateTime(ComConst.Time, ""))
                                        .ToString("yyyyMMddhhmmss", DateTimeFormatInfo.CurrentInfo);
                        #endregion

                        ExportBaseExcel Ebe = new ExportBaseExcel();
                        Ebe.OpenEFile(System.Windows.Forms.Application.StartupPath + "\\Model\\PC19.xls");

                        int frist = 0;
                        int row = 5;
                        int HardCon = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strId = dt.Rows[i]["Fed050Id"].ToString();
                            //string strPhbbh = dt.Rows[i]["PHBBH"].ToString();

                            Ebe.SetCellValue(5 + i, 0, dt.Rows[i]["PHRQ"].ToString());
                            Ebe.SetCellValue(5 + i, 1, dt.Rows[i]["CLBH"].ToString() + "-" + dt.Rows[i]["ZF"].ToString());
                            if (frist == 0)
                            {
                                Ebe.SetCellValue(5 + i, 3, dt.Rows[i]["LHQF"].ToString());
                                Ebe.SetCellValue(5 + i, 4, dt.Rows[i]["SYMC"].ToString());
                            }
                            else
                            {
                                Ebe.SetCellValue(5 + i, HardCon + 1, dt.Rows[i]["LHQF"].ToString());
                                Ebe.SetCellValue(5 + i, HardCon + 2, dt.Rows[i]["SYMC"].ToString());
                            }

                            //Ebe.SetBorderValueSingle(5 + i, 0, 5 + i, 4);

                            DataTable dt_detail = _bllfed050.GetPc19ExcelDetail(strId);

                            if (dt_detail.Rows.Count > 0)
                            {
                                DataTable dt_Collect = dt_detail.DefaultView.ToTable(true, "PHBBH");
                                dt_Collect.DefaultView.Sort = "PHBBH";

                                if (dt_Collect.Rows.Count > 0)
                                {

                                    int phbCount = 2;

                                    for (int j = 0; j < dt_Collect.Rows.Count; j++)
                                    {

                                        //DataTable dt_1 = _bllffd020.GetPc26ExcelDetail(strPhbid, dt_Collect.Rows[j]["PHBBH"].ToString());

                                        DataTable dt_1 = _bllffd020.GetPc26ExcelDetail(strId, dt_Collect.Rows[j]["PHBBH"].ToString());
                                        if (dt_1.Rows.Count > 0)
                                        {
                                            for (int k = 0; k < dt_1.Rows.Count; k++)
                                            {
                                                if (frist == 0)
                                                {
                                                    phbCount = phbCount + 1;
                                                    Ebe.InsertColumn(phbCount);

                                                    Ebe.SetCellValue(row - 2, phbCount - 1, dt_1.Rows[k]["YCLBH"].ToString());
                                                    Ebe.SetBackColor(row - 2, phbCount - 1, row - 2, phbCount - 1, 34);
                                                    Ebe.SetBorderValueSingle(row - 2, phbCount - 1, row - 2, phbCount - 1);
                                                    Ebe.SetFontBold(row - 2, phbCount - 1, row - 2, phbCount - 1);

                                                    Ebe.SetCellValue(row, phbCount - 1, dt_1.Rows[k]["ZL"].ToString());
                                                    Ebe.SetBorderValueSingle(row + 1, 1, row + 1, phbCount + 3);
                                                    Ebe.SetHorizontal(row, phbCount - 1, ExportBaseExcel.eHorizontal.eRight);
                                                    Ebe.SetCellValueLH4(row, phbCount - 1, row, phbCount - 1, dt_1.Rows[k]["ZL"].ToString());

                                                    Ebe.SetHorizontal(row - 1, phbCount - 1, ExportBaseExcel.eHorizontal.eRight);
                                                    Ebe.SetFontBold(row-1 , phbCount - 1, row - 1, phbCount - 1);

                                                    Ebe.SetRange_pc19(row - 1, 2, "= SUM(C6:C65500)", "#,##0.00;-#,##0.00");
                                                    Ebe.PasteSpecial(1, Ebe.GetCell(2, row - 1), Ebe.GetCell(2, row - 1), 
                                                        Ebe.GetCell(phbCount - 1, row - 1), Ebe.GetCell(phbCount -1, row - 1));

                                                    // Ebe.SetRange_pc19(row - 1, dt_1.Columns.Count+2, "", "");
                                                    // Ebe.PasteSpecial(1, Ebe.GetCell(2, row - 1), Ebe.GetCell(2, row - 1), Ebe.GetCell(phbCount - 1, row - 1), Ebe.GetCell(phbCount - 1, row - 1));

                                                    HardCon = phbCount;
                                                }
                                                else
                                                {
                                                    phbCount = phbCount + 1;

                                                    Ebe.SetCellValue(row, phbCount - 1, dt_1.Rows[k]["ZL"].ToString());
                                                    Ebe.SetBorderValueSingle(row + 1, 1, row + 1, phbCount + 3);
                                                    Ebe.SetHorizontal(row, phbCount - 1, ExportBaseExcel.eHorizontal.eRight);
                                                    Ebe.SetCellValueLH4(row, phbCount - 1, row, phbCount - 1, dt_1.Rows[k]["ZL"].ToString());
                                                }
                                            }
                                        }
                                    }
                                    Ebe.SetCellValue(2, 2, 2, phbCount - 2, "");

                                    Ebe.SetRange_pc19(row - 1, phbCount, "=SUM(C" + row + ":" + AlphaPlus(phbCount - 2) +""+ row+")", "#,##0.00;-#,##0.00");
                                    int a = row + 1;
                                    Ebe.SetRange_pc19(row, phbCount, "=SUM(C" + a + ":" + AlphaPlus(phbCount - 2) + "" + a + ")", "#,##0.00;-#,##0.00");

                                    // MessageBox.Show("=SUM(C" + row + ":" + AlphaPlus(phbCount - 2) + "" + row + ")");
                                }
                            }
                            row = row + 1;
                            frist = 1;
                        }
                        Ebe.SetCellValue(2, 2, "配合药品名称 / 必要量 / 真实用量 （单位g）");
                        Ebe.SetHorizontal(2, 2, ExportBaseExcel.eHorizontal.eLeft);
                        Ebe.SetCellValue(1, 3, 1, 4, "材料规格名：");
                        Ebe.SetCellValue(1, 5, 1, 5, strClbh);

                        Ebe.SetHorizontal(1, 3, ExportBaseExcel.eHorizontal.eLeft);
                        Ebe.SetFont(1, 3, 14);

                      
                        #region 插入 二维码
                        System.Drawing.Bitmap imgTemp;
                        imgTemp = Function.QrCodeHelper.GenQrCodeBitmap(txtClbh.Text.Trim(), 60, 60);// _Code.GetCodeImage(dt.Rows[i][SpdDataSoureColName.YCLRKLOTNO].ToString(), Function.BarCode.Code128.Encode.Code128B);
                        string path_HGZBH = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCodeHGBH.gif";
                        WipeFile(path_HGZBH, 2);
                        imgTemp.Save(path_HGZBH, System.Drawing.Imaging.ImageFormat.Gif);
                        imgTemp.Dispose();
                        int rowstep = 8;
                        float intWidth = 0;//长度像素值
                        float intHeight = 0;
                        Image pic;
                        pic = Image.FromFile(path_HGZBH);//strFilePath是该图片的绝对路径
                        intWidth = pic.Width;//长度像素值
                        intHeight = pic.Height;
                        Ebe.AddPic(6, 1, path_HGZBH, intWidth, intHeight);
                        pic.Dispose();
                        Ebe.SetHorizontal(1, 5, ExportBaseExcel.eHorizontal.eLeft);
                        #endregion

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

        /// <summary>
        /// 根据字母的间隔获得新的字母
        /// </summary>
        private string AlphaPlus(int offset)
        {
            if (offset <= 77 && offset >= 0)
            {
                string[] alphas ={"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T"
                            ,"U","V","W","X","Y","Z","AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK",
                            "AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ","BA",
                            "BB","BC","BD","BE","BF","BG","BH","BI","BK","BL","BM","BN","BO","BP","BQ","BR",
                            "BS","BT","BU","BV","BW","BX","BY","BZ","CA","CD","CE","CF","CG","CH","CI","VJ"};
                return alphas[offset + 1];
            }
            else return "0";
        }

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

        private void PC19_KeyDown(object sender, KeyEventArgs e)
        {
            PublicFun.EnterSendTab(sender, e);
        }

        private void txtTextChanged(object sender, EventArgs e)
        {
            ((TextBox)(sender)).Text = ((TextBox)(sender)).Text.ToUpper();
            ((TextBox)(sender)).Select(((TextBox)(sender)).Text.Length, 0);
        }
    }
}
