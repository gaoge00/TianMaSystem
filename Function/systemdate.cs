using System;
using System.Collections.Generic;
using System.Text;

namespace Function
{
    public class systemdate
    {       
        /// <summary>
        /// 系统日期      
        /// </summary>
        /// <returns></returns>
        public string Get_SysDate()
        {
            return PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_YMD);
        }
        /// <summary>
        /// 系统日期(addday:日期变更，例如去系统日期前一天则传值-1)
        /// </summary>
        /// <returns></returns>
        public string Get_SysDate(int addday)
        {
            return PublicFun.GetSystemDateTime(ComConst.Date, ComConst.dateStyle_YMD, addday);
        }
        /// <summary>
        /// 系统日期(addday:日期变更，例如去系统日期前一天则传值-1)
        /// </summary>
        /// <returns></returns>
        public string Get_SysDate(string dateStyle)
        {
            return PublicFun.GetSystemDateTime(ComConst.Date, dateStyle);
        }

        /// <summary>
        /// 系统时间
        /// </summary>
        /// <returns></returns>
        public  string Get_SysTime()
        {
            return PublicFun.GetSystemDateTime(ComConst.Time,ComConst.dateStyle_YMD);         
        }

        /// <summary>
        /// 计算机名
        /// </summary>
        /// <returns></returns>
        public   string Get_SysDNBH()
        {
            string SysDNBH = string.Empty;
            SysDNBH = System.Net.Dns.GetHostName();
            return SysDNBH;
        }

    }
}
