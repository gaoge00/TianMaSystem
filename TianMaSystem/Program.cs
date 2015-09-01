using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Function;
using TianMaSystem;

namespace BSC_System
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new BllTest());
            //Application.Run(new WinLogin());


            try
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionEventHandler);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Process[] myProcesses = Process.GetProcessesByName(Application.ProductName);
                if (myProcesses.Length <= 1)
                {
                    //Application.Run(new testForm("2015/01/29", "BSC070", "","HL_BSC070_150128_01", "", "", "", ""));

                    Application.Run(new WinLogin());
                }
                else
                    ComForm.DspMsg("E002", "");
                    Application.Exit();
            }
            catch (Exception ex)
            {
                ComForm.DspMsg("E001", "");
                ComForm.InsertErrLog(ex.Message, "LOGIN");
            }


        }

        static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {

            try
            {
                ComForm.InsertErrLog("ExceptionObject" + e.ExceptionObject + "," + e.ToString(), "ERROR");
            }
            catch
            {

            }

        }


    }
}
