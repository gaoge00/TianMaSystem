/*----------------------------------------------------------------
// Copyright (C) 2010 シャンデ―ル（大連事務所）
//
// ファイル名  :MenuPro
// ファイル内容:明细工程项目
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

namespace DAL
{
    public class Project
    {
        /// <summary>
        /// 取出 Project 表中 MenuPro.M_ID = Project.P_ID 的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetProject_Single(Model.project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_ID,P_NAME,P_PorName,P_MakerNO,M_P_ID,P_order from Project ");
            strSql.Append("where M_P_ID = '" + model.M_P_ID + "' order by P_order");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 插入 Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Insert(Model.project model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("insert into Project (P_NAME,P_PorName,P_MakerNO,M_P_ID,P_order,xsqf) ");
                strSql.Append("values ( ");
                strSql.Append("'" + model.P_NAME + "',");
                strSql.Append("'" + model.P_PorName + "',");
                strSql.Append("'" + model.P_MakerNO + "',");
                strSql.Append("'" + model.M_P_ID + "'");
               // strSql.Append(",'"+model.P_ORDER+"','1') ");
       
            return strSql.ToString();
        }

        /// <summary>
        /// 删除 Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Delect(Model.project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Project where ");
            strSql.Append("P_ID = '" + model.P_ID + "' and ");
            strSql.Append("P_NAME = '" + model.P_NAME + "'");
            return strSql.ToString();
        }

        /// <summary>
        /// 程序名称
        /// </summary>
        /// <param name="strNO"></param>
        /// <returns></returns>
        public DataTable GetProject_Name(string strNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.P_NAME Name,a.P_PorName PorName from MenuPro b ");
            strSql.Append("left join Project a on (a.M_P_ID = b.M_ID) ");

            strSql.Append("left join fmd020 c on (a.P_PorName = c.PGID) ");

            strSql.Append("where b.M_ID = '" + strNO + "' and XSQF = '1' ");

            if (!string.IsNullOrEmpty(Function.Const.SYBH))
            {
                strSql.Append("and c.UserName = '" + Function.Const.SYBH + "' ");
            }
            strSql.Append("order by a.P_order,a.M_P_ID");

            return DbHelperMySql.Query(strSql.ToString()).Tables[0];

        }



        /// <summary>
        /// 获取程序名称（英文）
        /// </summary>
        /// <param name="P_NAME"></param>
        /// <returns></returns>
        public DataTable GetP_PorName(string P_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P_PorName from Project ");
            strSql.Append("where P_NAME = '" + P_NAME + "' ");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 判断项目名是否存在 存在为更新  written by LH 2010/06/22
        /// </summary>
        /// <param name="strNO"></param>
        /// <returns></returns>
        public bool existProName(string proName)
        {
            //string strSql = " select COUNT(*) from Project where P_NAME=N'" + proName + "'";
            //string result = DbHelperMySql.GetSingle(strSql).ToString();
            //if (result == "0")
            //{
            //    return false;
            //}
            //else
            //    return true;



            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  Project  ");
            strSql.Append("WHERE M_P_ID = 'M10' and P_NAME = '" + proName + "'  ");
            return  DbHelperMySql.Exists(strSql.ToString());
          



        }

        /// <summary>
        /// update Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Update(Model.project model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update Project set P_NAME=N'"+model.P_NAME+"',");
            strSql.Append(" P_PorName=N'" + model.P_PorName + "',P_MakerNO='" + model.P_MakerNO + "',M_P_ID='" + model.M_P_ID + "'  ");//,P_order=N'"+model.P_ORDER+"'
            strSql.Append(" where P_NAME=N'" + model.P_NAME + "'");
            return strSql.ToString();
        }
    }
}
