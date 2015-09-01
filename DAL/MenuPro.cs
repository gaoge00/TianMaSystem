/*----------------------------------------------------------------
// Copyright (C) 2010 シャンデ―ル（大連事務所）
//
// ファイル名  :MenuPro
// ファイル内容:总工程项目
// 
// 作成日：2010/05/12
// 作成者：何宝華
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class MenuPro
    {
        /// <summary>
        /// 取出 MenuPro 表中的M_NAME数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuPro(string DMQF, string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select M_ID,M_NAME from menupro where M_ID in (SELECT PGID FROM bscdb.fmd020 where USERNAME='" + uid + "' and DMQF='" + DMQF + "') order by  CAST(M_ORDER as SIGNED) asc  ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }
    }

}
