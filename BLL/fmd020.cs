/**  版本信息模板在安装目录下，可自行修改。
* fmd020.cs
*
* 功 能： N/A
* 类 名： fmd020
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:50   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
//using Common;
using Model;
namespace BLL
{
	/// <summary>
	/// fmd020
	/// </summary>
	public partial class fmd020
	{
		private readonly DAL.fmd020 dal=new DAL.fmd020();
		public fmd020()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string USERNAME,string PGID,string DMQF)
		{
			return dal.Exists(USERNAME,PGID,DMQF);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd020 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.fmd020 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string USERNAME,string PGID,string DMQF)
		{
			
			return dal.Delete(USERNAME,PGID,DMQF);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd020 GetModel(string USERNAME,string PGID,string DMQF)
		{
			
			return dal.GetModel(USERNAME,PGID,DMQF);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd020 GetModelByCache(string USERNAME,string PGID,string DMQF)
        //{
			
        //    string CacheKey = "fmd020Model-" + USERNAME+PGID+DMQF;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(USERNAME,PGID,DMQF);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd020)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd020> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd020> DataTableToList(DataTable dt)
		{
			List<Model.fmd020> modelList = new List<Model.fmd020>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd020 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

        /// <summary>
        /// Login 画面验证用户名密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable YongHuMima_GetYM(string username, string password)
        {
            return dal.YongHuMima_GetYM(username, password);
        }

        /// <summary>
        /// Login 画面验证用户名是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable YongHuMima_GetCorN(string username)
        {
            return dal.YongHuMima_GetCorN(username);
        }

        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="password"></param>
        /// <param name="dmqf"></param>
        /// <returns></returns>
        public bool CheckLogin(string uid, string password, string dmqf)
        {
            return dal.CheckLogin(uid, password, dmqf);
        }

        /// <summary>
        /// 权限查找对应权限(表头)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetProject_SelectQX(string DMQF)
        {

            return dal.GetProject_SelectQX(DMQF);
        }

        /// <summary>
        /// 权限 获取用户名密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetQuanxian_SpdGetXM(string DMQF)
        {

            return dal.GetQuanxian_SpdGetXM(DMQF);
        }


        public DataTable GetQuanxian_YongHu(Model.fmd020 model)
        {
            return dal.GetQuanxian_YongHu(model);
        }

        public DataTable GetProject_TitleTF(string P_NAME)
        {
            return dal.GetProject_TitleTF(P_NAME);
        }



        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string DeleteYongHuQX(string Username, string DMQF)
        {

            return dal.DeleteYongHuQX(Username, DMQF);
        }

        /// <summary>
        /// 用户名密码为空删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string DdeleteYongHu_KongYM(Model.fmd020 model)
        {

            return dal.DdeleteYongHu_KongYM(model);
        }

        /// <summary>
        /// 插入用户权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertUserInfo(Model.fmd020 model)
        {

            return dal.InsertUserInfo(model);
        }

        public string DeleteUserInfo(string DMQF)
        {
            return dal.DeleteUserInfo(DMQF);
        }


        public DataTable Select_SybhIsExit(string sybh)
        {
            return dal.Select_SybhIsExit(sybh);
        }

        public void Update_Pass(string strPass, string strUSERID)
        {
             dal.Update_Pass(strPass, strUSERID);
        }
	}
}

