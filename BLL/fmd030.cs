/**  版本信息模板在安装目录下，可自行修改。
* fmd030.cs
*
* 功 能： N/A
* 类 名： fmd030
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:51   N/A    初版
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
	/// fmd030
	/// </summary>
	public partial class fmd030
	{
		private readonly DAL.fmd030 dal=new DAL.fmd030();
		public fmd030()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string KHBH,string KHMC)
		{
			return dal.Exists(KHBH,KHMC);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd030 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.fmd030 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string KHBH,string KHMC)
		{
			
			return dal.Delete(KHBH,KHMC);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd030 GetModel(string KHBH,string KHMC)
		{
			
			return dal.GetModel(KHBH,KHMC);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd030 GetModelByCache(string KHBH,string KHMC)
        //{
			
        //    string CacheKey = "fmd030Model-" + KHBH+KHMC;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(KHBH,KHMC);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd030)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表c
        /// </summary>
        public DataSet GetListPc25(string strWhere)
        {
            return dal.GetListPc25(strWhere);
        }

        public DataSet GetRKZF(string sRQ, string eRQ, string HLPCLOTNO)
        {
            return dal.GetRKZF(sRQ, eRQ, HLPCLOTNO);
        }
        public string GetKHBH(string strKHMC)
        {
            return dal.GetKHBH(strKHMC);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd030> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd030> DataTableToList(DataTable dt)
		{
			List<Model.fmd030> modelList = new List<Model.fmd030>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd030 model;
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


        public DataTable getspread(Model.fmd030 model)
        {

            return dal.getspread(model);

        }

        public bool chkMCK_ZSMC(string GLBH, string MCKEY, string ZSMC)
        {
            return dal.chkMCK_ZSMC(GLBH, MCKEY, ZSMC);
        }
	}
}

