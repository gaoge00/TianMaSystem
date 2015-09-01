/**  版本信息模板在安装目录下，可自行修改。
* fmd040.cs
*
* 功 能： N/A
* 类 名： fmd040
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
	/// fmd040
	/// </summary>
	public partial class fmd040
	{
		private readonly DAL.fmd040 dal=new DAL.fmd040();
		public fmd040()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string YCLBHBS)
		{
			return dal.Exists(YCLBHBS);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string AddSQL(Model.fmd040 model)
		{
            return dal.AddSQL(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string UpdateSQL(Model.fmd040 model)
		{
            return dal.UpdateSQL(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string  Delete(string YCLBHBS)
		{
			
			return dal.Delete(YCLBHBS);
		}

        public string Del(string YCLBHBS)
        {

            return dal.Del(YCLBHBS);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool DeleteList(string YCLBHBSlist )
        //{
        //    return dal.DeleteList(Common.PageValidate.SafeLongFilter(YCLBHBSlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd040 GetModel(string YCLBHBS)
		{
			
			return dal.GetModel(YCLBHBS);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd040 GetModelByCache(string YCLBHBS)
        //{
			
        //    string CacheKey = "fmd040Model-" + YCLBHBS;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(YCLBHBS);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd040)objModel;
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
		public List<Model.fmd040> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd040> DataTableToList(DataTable dt)
		{
			List<Model.fmd040> modelList = new List<Model.fmd040>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd040 model;
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
        public DataTable GetYCLBH()
        {
            return dal.GetYCLBH();
        }

        /// <summary>
        /// 得到原材料入库明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <param name="rkrq"></param>
        /// <param name="zf"></param>
        /// <returns></returns>
        public DataTable GetYCLRK(string YCLBH, string rkrq, string zf)
        {
            return dal.GetYCLRK(YCLBH, rkrq, zf);
        }

        /// <summary>
        /// 得到原材料明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <returns></returns>
        public DataTable GetYCLBH_MX(string YCLBH)
        {
            return dal.GetYCLBH_MX(YCLBH);
        }



        public DataTable GetDaTaForPC08Spread(string YCLLX, string YCLBH, string ZT,string strQF)
        {
            return dal.GetDaTaForPC08Spread(YCLLX, YCLBH, ZT,strQF);
        }

        /// <summary>
        /// 得到公差
        /// </summary>
        /// <param name="zl"></param>
        /// <returns></returns>
        public decimal GET_GC(decimal zl)
        {
            return dal.GET_GC(zl);
        }

        public string Get_YCLLX(string YCLBH)
        {
            return dal.Get_YCLLX(YCLBH);
        }
		#endregion  ExtensionMethod
	}
}

