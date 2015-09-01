using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace BSC_System
{
    public partial class PC31 : Form
    {
        public PC31()
        {
            InitializeComponent();
        }

        string strKHMC = string.Empty;
        string strRQ = string.Empty;
        string strCKDH = string.Empty;


        DataTable dt = new DataTable();
        public PC31(DataTable dt, string refKHMC, string refRQ, string refCKDH)
        {
            strKHMC = refKHMC;
            strRQ = refRQ;
            strCKDH = refCKDH;
           InitializeComponent();
            this.dt = dt;
            //this.strCS = strCS;
        }

        public CrystalReport1 oRpt1 = new CrystalReport1();

        //预览
        public void Report_YL()
        {
            try
            {
                System.GC.Collect();              
                oRpt1.SetDataSource(dt);

                TextObject TxtKHMC = (TextObject)oRpt1.Section2.ReportObjects["TxtKH"];
                TxtKHMC.Text = strKHMC;

                TextObject TxtRQ = (TextObject)oRpt1.Section2.ReportObjects["TxtRQ"];
                TxtRQ.Text = strRQ;

                TextObject TxtCKDH = (TextObject)oRpt1.Section2.ReportObjects["TxtCKDH"];
                TxtCKDH.Text = strCKDH;


                #region 设置 纸型
                PrintDocument doc = new PrintDocument();
                //string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
                ////System.Drawing.Printing.PrintDocument doc = new PrintDocument();
                ////doc.PrinterSettings.PrinterName = strDefaultPrinter;

                int rawKind = 1;
                bool hasgzt = false;
                for (int i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
                {
                    if (doc.PrinterSettings.PaperSizes[i].PaperName == "CKD")
                    {
                        rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
                        // oRpt1.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize) doc.PrinterSettings.PaperSizes[i];
                        i = doc.PrinterSettings.PaperSizes.Count;
                        hasgzt = true;
                    }
                }
                if (hasgzt)
                {
                    oRpt1.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                }
                else
                {
                    oRpt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;                
                }
                #endregion 
                //oRpt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldUS;

               // SetPrinterAndPaperSize("","CKD");
                crystalReportViewer1.ReportSource = oRpt1;
             //  
                crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
               // crystalReportViewer1.ShowPrintButton =
                    crystalReportViewer1.ShowCopyButton =
                    crystalReportViewer1.ShowGroupTreeButton=
                    crystalReportViewer1.ShowLogo=
                    crystalReportViewer1.ShowParameterPanelButton=
                    crystalReportViewer1.ShowTextSearchButton=
                    false;

                //crystalReportViewer1.DisplayGroupTree = false;//隐藏 左侧组树

                //PageMargins margin = oRpt1.PrintOptions.PageMargins;
                //margin.bottomMargin = 300;
                //margin.leftMargin = 20;
                //margin.rightMargin = 20;
                //margin.topMargin = 300;
                //oRpt1.PrintOptions.ApplyPageMargins(margin);
                //oRpt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
               // crystalReportViewer1.Zoom(1);

            }
            catch (Exception ex)
            {
                //ComForm.InsertErrLog(ex.ToString(), this.Name + "Report_YL");
            }

            #region  wpf 隐藏 水晶报表 组树
            //var sidepanel = crystalReportsViewer1.FindName("btnToggleSidePanel") as ToggleButton;
            //if (sidepanel != null)
            //{
            //    crystalReportsViewer1.ViewChange += (x, y) => sidepanel.IsChecked = false;
            //}           
            #endregion 

        }

        //打印
        public void Report_DY()
        {
            try
            {
                System.GC.Collect();
                oRpt1.SetDataSource(dt);

                TextObject TxtKHMC = (TextObject)oRpt1.Section2.ReportObjects["TxtKH"];
                TxtKHMC.Text = strKHMC;                

                TextObject TxtRQ = (TextObject)oRpt1.Section2.ReportObjects["TxtRQ"];
                TxtRQ.Text = strRQ;

                TextObject TxtCKDH = (TextObject)oRpt1.Section2.ReportObjects["TxtCKDH"];
                TxtCKDH.Text = strCKDH;
                //crystalReportViewer1.ReportSource = oRpt1;         
                //crystalReportViewer1.ReportSource = oRpt1;                
                //PageMargins margin = oRpt1.PrintOptions.PageMargins;
                //margin.bottomMargin = 300;
                //margin.leftMargin = 20;
                //margin.rightMargin =5;
                //margin.topMargin = 300;
                //oRpt1.PrintOptions.ApplyPageMargins(margin);
                //oRpt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                //oRpt1.PrintToPrinter(0, false, 0, 0);
                //this.Close();


                //    水晶报表自定义纸张大小打印 (CRYSTAL REPORT PRINT WITH CUSTOM PAPER SIZE)
                //PrintDocument prtdoc = new PrintDocument();
                //string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

                PrintDocument doc = new PrintDocument();

               // doc.PrinterSettings.PrinterName = strDefaultPrinter;
                  int rawKind = 1;
                bool hasgzt = false;
                for (int i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
                {
                    if (doc.PrinterSettings.PaperSizes[i].PaperName == "CKD")
                    {
                        rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
                        // oRpt1.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize) doc.PrinterSettings.PaperSizes[i];
                         i = doc.PrinterSettings.PaperSizes.Count;
                        hasgzt = true;                      
                    }
                }
                if (hasgzt)
                {
                    oRpt1.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                }
                else
                {
                   oRpt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                   //CrystalDecisions.Shared.PaperSize.PaperFanfoldUS;
                }
                    //(CrystalDecisions.Shared.PaperSize)rawKind;       

                //crystalReportViewer1.ReportSource = oRpt1;

                oRpt1.PrintToPrinter(1, true, 0, 0);
              //  this.Close();

            }
            catch (Exception ex) 
            {
              //  ComForm.InsertErrLog(ex.ToString(), this.Name + "Report_DY");
            }
        }

        private void PC31_Load(object sender, EventArgs e)
        {
          //  this.Location = new System.Drawing.Point(180, 78);
            //if (strCS == "YL")
            //{
            this.Report_YL();

           // Report_DY();
            //}
            //else
            //{
            //    this.Report_DY();
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        #region 设置打印机
        //void SetPrinterAndPaperSize(string printerName,string PaperSize)
        //{

        //    switch (PaperSize)//根據自已需求添加
        //            {
        //                case "A4":
        //                    if(!Printer.IsChange("A4",2100,2970))
        //                    {
        //                       Printer.PrinterData pd = new Printer.PrinterData();//
        //                        pd.Duplex = 0;//不設置是否雙面打印（不設置即按默認設置對待，以下類同）
        //                        pd.Orientation = 0;//不設置打印方向
        //                        pd.pFormName ="A4";//紙張名字
        //                        pd.pLength = 2970;//設置打印機的高度
        //                        pd.pWidth = 2100;//設置打印機的寬度               
        //                        pd.Size = Printer.PaperSize.DMPAPER_USER;//自定義紙張
        //                        Printer.ModifyPrintInfo3(printerName, ref pd);//更改打印機信息
        //                    }
        //                    break;
        //                case "CKD":
        //                    if(!Printer.IsChange("CKD",2100,930))
        //                    {
        //                        Printer.PrinterData pd = new Printer.PrinterData();//
        //                        pd.Duplex = 0;//不設置是否雙面打印（不設置即按默認設置對待，以下類同）
        //                        pd.Orientation = 0;//不設置打印方向
        //                        pd.pFormName = "CKD";//紙張名字8.5X5.5
        //                        pd.pLength = 930;//設置打印機的高度
        //                        pd.pWidth = 2100;//設置打印機的寬度               
        //                        pd.Size = Printer.PaperSize.DMPAPER_USER;//自定義紙張
        //                        Printer.ModifyPrintInfo3(printerName, ref pd);//更改打印機信息
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //  }
        #endregion 

        private void crystalReportViewer1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_DY();
        }



    }
}
