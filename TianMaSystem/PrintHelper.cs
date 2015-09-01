using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSC_System
{
    public class PrintHelper
    {
        static WebDbSrv.WebDbSrv webDb = new WebDbSrv.WebDbSrv();

        //public static WebDbSrv.PrintSrvInfo GetPrintInfo(string uid)
        //{
        //    WebDbSrv.PrintSrvInfo pInfo = new BSC_System_HT.WebDbSrv.PrintSrvInfo();
        //    pInfo = webDb.GetPrintIpAndPort(uid);
        //    return pInfo;

        //}

        /// <summary>
        /// 打印合作证
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="lst">数据</param>
        /// <param name="prtCount">个数</param>
        /// <param name="qf"></param>
        public static string PrintHGZ(string uid,string[] lst, int prtCount,int qf)
        {
            try
            {
                string sStatus = webDb.PrintHgz(uid, lst, prtCount, qf);
                return sStatus;
                //WebDbSrv.PrintSrvInfo pInfo =GetPrintInfo(uid);

                //Connection SATOPrinter = new Connection();

                //SATOPrinter.Type = InterfaceType.TCPIP;
                //SATOPrinter.TCPIPAddress = pInfo.SrvAddress;
                //SATOPrinter.TCPIPPort = pInfo.SrvPort;

                //byte[] cmddata =webDb.GetHgzSBPL(lst,prtCount,qf);
                //SATOPrinter.AsyncSend(cmddata);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }


        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="lstprtText">数据</param>
        /// <param name="prtCount">个数</param>
        public static string PrintQrCode(string uid, string prtText, int prtCount)
        {
            try
            {
                string sStatus = webDb.PrintBarcode(uid, prtText, prtCount);
                return sStatus;

                //WebDbSrv.PrintSrvInfo pInfo = GetPrintInfo(uid);

                //Connection SATOPrinter = new Connection();

                //SATOPrinter.Type = InterfaceType.TCPIP;
                //SATOPrinter.TCPIPAddress = pInfo.SrvAddress;
                //SATOPrinter.TCPIPPort = pInfo.SrvPort;

                //byte[] cmddata = webDb.GetBarcodeSBPL(prtText, prtCount);
                //SATOPrinter.AsyncSend(cmddata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 打印二维码 多个
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="lstprtText">数据</param>
        /// <param name="prtCount">个数</param>
        public static string PrintQrCodeList(string uid, List<string> lst)
        {
            try
            {
                string sStatus = webDb.PrintBarcodeList(uid, lst.ToArray());
                return sStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
