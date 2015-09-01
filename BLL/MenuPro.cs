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
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class MenuPro
    {
        private readonly DAL.MenuPro dal = new DAL.MenuPro();

        /// <summary>
        /// 取出 MenuPro 表中的M_NAME数据 手持端
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuPro_HT(string uid)
        {
            return dal.GetMenuPro("1", uid);
        }

   
    }
}
