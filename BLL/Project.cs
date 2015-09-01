/*----------------------------------------------------------------
// Copyright (C) 2010 シャンデ―ル（大連事務所）
//
// ファイル名  :MenuPro
// ファイル内容:工程项目明细
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
    public  class Project
    {
        private readonly DAL.Project dal = new DAL.Project();

        /// <summary>
        /// 取出 Project 表中 MenuPro.M_ID = Project.P_ID 的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetProject_Single(Model.project model)
        {
            return dal.GetProject_Single(model);
        }

        /// <summary>
        /// 插入 Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Insert(Model.project model)
        {
            return dal.GetProject_Insert(model);
        }

        /// <summary>
        /// 删除 Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Delect(Model.project model)
        {
            return dal.GetProject_Delect(model);
        }

        /// <summary>
        /// 程序名称
        /// </summary>
        /// <param name="strNO"></param>
        /// <returns></returns>
        public DataTable GetProject_Name(string strNO)
        {
            return dal.GetProject_Name(strNO);
        }

        public DataTable GetP_PorName(string P_NAME)
        {
            return dal.GetP_PorName(P_NAME);
        }

        // written by LH 2010/06/22
         /// <summary>
        /// 判断项目名是否存在 存在为更新 
        /// </summary>
        /// <param name="strNO"></param>
        /// <returns></returns>
        public bool existProName(string proName)
        {
            return dal.existProName(proName);
        }

        
        /// <summary>
        /// update Project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetProject_Update(Model.project model)
        {
            return dal.GetProject_Update(model);
        }
    }
}
