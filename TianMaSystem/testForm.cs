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
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();
        }

          public string refLHRQ { get; set; }
        public string refCLBH { get; set; }
        public string refRKZF { get; set; }
        public string refHLPCLOTNO { get; set; }
        public string refMaxRKZF { get; set; }
        public string refID { get; set; }
        public string refMaxXDZF { get; set; }
        public string PinDLotNO { get; set; }
        public string refRKQF { get; set; }
        public List<string> listPrintBarCode = new List<string>();
        BLL.ffd020 bllFFD020 = new BLL.ffd020();
        BLL.ffd010 bllFFD010 = new BLL.ffd010();
        
        public testForm(string LHRQ, string CLBH, string RKZF, string HLPCLOTNO, string MaxRKZF, string ID, string MaxXDZF, string strRKQF)
        {
            InitializeComponent();
            refLHRQ = LHRQ;
            refCLBH = CLBH;
            refRKZF = RKZF;
            refHLPCLOTNO = HLPCLOTNO;
            refMaxRKZF = string.IsNullOrEmpty(MaxRKZF)? "00" : MaxRKZF;
            refID = ID;
            refMaxXDZF = MaxXDZF;
            refRKQF = strRKQF;
        }

        private void btnBaoC_Click(object sender, EventArgs e)
        {

                DialogResult dr1 = MessageBox.Show("是否保存？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if ("OK".Equals(dr1.ToString()))
                {

                    if (SaveData())
                    {
                        DialogResult dr = MessageBox.Show("数据保存成功，是否打印条形码！", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if ("OK".Equals(dr.ToString()))
                        {
                            //PrintBarCode();
                            //refHT08.setLOTNOInfo();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据保存失败！", "");
                    }
                }
            



        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            bool resule = false;
            string SysDate = "20150128" ;
            string SysTime = "15:09:11";
            try
            {
                Model.ffd010 modelFFD010 = new Model.ffd010();
                modelFFD010.ID = refID.StringToInt();
                modelFFD010.LHRQ = txtLHRQ.Text;
                modelFFD010.HLPCLOTNO = refHLPCLOTNO;
                modelFFD010.JPRQ = dTimeJPRQ.Value.ToString("yyyy/MM/dd");
                modelFFD010.CLBH = txtCLBH.Text;
                modelFFD010.PM = txtPM.Text;
                modelFFD010.PH = txtPH.Text;
                modelFFD010.HGSL = txtHGSL.Text.StringToInt();
                modelFFD010.BLSL = txtBLPSL.Text.StringToInt();
                modelFFD010.XDSLBZ = txtMDSL.Text.StringToInt();
                modelFFD010.DMQF = "1";
                modelFFD010.MAXXDZF = refMaxXDZF.StringToInt() == 0 ? txtZDSL.Text.StringToInt() : (refMaxXDZF.StringToInt() + txtZDSL.Text.StringToInt());
                modelFFD010.RLZBH = "gaoge";
                modelFFD010.RLR = SysDate;
                modelFFD010.RLSJ = SysTime;
                modelFFD010.RLDMM = "W999";
                if (!string.IsNullOrEmpty(refRKZF))
                {
                    modelFFD010.RKZF = refRKZF;
                    modelFFD010.ID = refID.StringToInt();
                }
                else
                {
                    modelFFD010.RKZF = (refMaxRKZF.StringToInt()+ 1).ToString().PadLeft(2, '0');
                }
                //modelFFD010.RKQF = refRKQF;
                Model.ffd020 modelFFD020;
                List<Model.ffd020> listmodelFFD020 = new List<Model.ffd020>();
                int XiaoDMaxZF = refMaxXDZF.StringToInt();
                listPrintBarCode = new List<string>();
                for (int i = 0; i < txtZDSL.Text.StringToInt(); i++)
                {
                    modelFFD020 = new Model.ffd020();
                    XiaoDMaxZF++;
                    int ZSL = txtHGSL.Text.StringToInt();
                    int MDSL = txtMDSL.Text.StringToInt();
                    if (i != txtZDSL.Text.StringToInt() - 1 || ZSL % MDSL == 0)
                    {

                        //modelFFD020.ID = modelFFD010.ID;
                        modelFFD020.SL = txtMDSL.Text.StringToInt();
                        modelFFD020.XDLOTNO = SetBarCode(
                                                        "RK",
                                                        "1",
                                                        modelFFD010.CLBH,
                                                        modelFFD010.PH,
                                                        modelFFD010.LHRQ.Replace("/", ""),
                            //modelFFD010.RKZF,
                                                        XiaoDMaxZF,
                                                        modelFFD020.SL
                                                        );
                    }
                    else
                    {

                        modelFFD020.SL = ZSL % MDSL;
                        modelFFD020.XDLOTNO = SetBarCode(
                                                       "RK",
                                                        "1",
                                                       modelFFD010.CLBH,
                                                       modelFFD010.PH,
                                                       modelFFD010.LHRQ.Replace("/", ""),
                            //modelFFD010.RKZF,
                                                       XiaoDMaxZF,
                                                       modelFFD020.SL
                                                       );
                    }

                    listPrintBarCode.Add(modelFFD020.XDLOTNO);

                    modelFFD020.RKQF = refRKQF;
                    modelFFD020.XDINTZF = XiaoDMaxZF;
                    modelFFD020.JPRBH = "99992";
                    modelFFD020.SSXDLOTNO = string.IsNullOrEmpty(PinDLotNO) ? modelFFD020.XDLOTNO : PinDLotNO;
                    modelFFD020.RLZBH = "9992";
                    modelFFD020.RLR = SysDate;
                    modelFFD020.RLSJ = SysTime;
                    modelFFD020.RLDMM = "w999";
                    listmodelFFD020.Add(modelFFD020);
                }
                bool bResult = false;
                List<string> outStrArr=new List<string>();
                //string[] sssqwe = wd_CP.AddFFD020(modelFFD010, listmodelFFD020, out outStrArr);

                bResult = bllFFD020.AddByList(modelFFD010, listmodelFFD020, out outStrArr);

                //Console.WriteLine(str123);

                return bResult;
            }
            catch (Exception ex)
            {
                //DcsFunc.InsertErrLog(ex.Message, this.Name, "gaoge",
                //                     SysDate,
                //                     SysTime,
                //                     "w9999999"
                //         );
                return resule;
            }


            //return resule;
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="BarCodeQF">RK</param>
        /// <param name="DaiQF">1/2/3</param>
        /// <param name="strPH"></param>
        /// <param name="strRQ"></param>
        /// <param name="strZF"></param>
        /// <param name="strQFZF"></param>
        /// <param name="SL"></param>
        /// <returns></returns>
        public string SetBarCode(string BarCodeQF, string DaiQF, string strCLBH, string strPH, string strRQ, int? strQFZF, decimal? SL)
        {
            string resule = string.Empty;
            switch (BarCodeQF)
            {
                case "RK":
                    resule = BarCodeQF + "_" + DaiQF + "_" + strCLBH + "_" + strPH + "_" + strRQ.PadLeft(8, '0').Substring(2, 6) + "_" + strQFZF + "," + SL;
                    break;
                default:
                    break;
            }
            return resule;
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            this.Text = string.IsNullOrEmpty(refRKQF) ? "HT08_1-检品装小袋" : "HT08_1-返品装小袋";
            this.txtLHRQ.Text = refLHRQ;
            this.txtCLBH.Text = refCLBH;
            if (!string.IsNullOrEmpty(refID))
            {
                DataSet dsReturn = bllFFD010.getJPInfo(refID, refRKQF);
                DataTable dtJPInfo = dsReturn.Tables[0];
                DataTable dtBarCode = dsReturn.Tables[1];

                if (dtJPInfo.Rows.Count > 0)
                {
                    txtPM.Text = dtJPInfo.Rows[0]["PM"].ToString();
                    txtPH.Text = dtJPInfo.Rows[0]["PH"].ToString();
                    dTimeJPRQ.Value = Convert.ToDateTime(dtJPInfo.Rows[0]["JPRQ"].ToString());
                    txtHGSL.Text = dtJPInfo.Rows[0]["HGSL"].ToString();
                    txtBLPSL.Text = dtJPInfo.Rows[0]["BLSL"].ToString();
                    txtMDSL.Text = dtJPInfo.Rows[0]["XDSLBZ"].ToString();
                    JSDS();
                    txtJPR.Text = dtJPInfo.Rows[0]["JPR"].ToString();
                    listPrintBarCode.Clear();
                    listPrintBarCode = dtBarCode.ConvertTo<string>();
                }
            }

            //lbl_userID.Text = DcsConst.UserID;
            txtJPR.Text = "gaoge";
            txtPM.Focus();
        }


        public void JSDS()
        {
            int ZSL = txtHGSL.Text.StringToInt();
            int MDSL = txtMDSL.Text.StringToInt();
            if (MDSL == 0)
            {
                txtZDSL.Text = "0";
            }
            else
            {
                txtZDSL.Text = ((ZSL / MDSL) + (ZSL % MDSL > 0 ? 1 : 0)).ToString();
            }
        }
    
    }
}
