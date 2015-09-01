/**  版本信息模板在安装目录下，可自行修改。
* fmd050.cs
*
* 功 能： N/A
* 类 名： fmd050
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:52   N/A    初版
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
	/// fmd050
	/// </summary>
	public partial class fmd050
	{
		private readonly DAL.fmd050 dal=new DAL.fmd050();
		public fmd050()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CLBH)
		{
			return dal.Exists(CLBH);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string  AddSQL(Model.fmd050 model)
		{
            return dal.AddSQL(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string  UpdateSQL(Model.fmd050 model)
		{
            return dal.UpdateSQL(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string Delete(string CLBH)
		{
			
			return dal.Delete(CLBH);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool DeleteList(string CLBHlist )
        //{
        //    return dal.DeleteList(Common.PageValidate.SafeLongFilter(CLBHlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd050 GetModel(string CLBH)
		{
			
			return dal.GetModel(CLBH);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd050 GetModelByCache(string CLBH)
        //{
			
        //    string CacheKey = "fmd050Model-" + CLBH;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(CLBH);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd050)objModel;
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
		public List<Model.fmd050> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd050> DataTableToList(DataTable dt)
		{
			List<Model.fmd050> modelList = new List<Model.fmd050>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd050 model;
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
        public DataTable GetCLBH_050(string strYCLBH)
        {
            return dal.GetCLBH_050(strYCLBH);
        }

        /// <summary>
        /// 得到材料过期日
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="HLRY">混炼日期</param>
        /// <returns></returns>
        public DateTime GetYXTS(string CLBH, string HLRY)
        {
            return dal.GetYXTS(CLBH, HLRY);
        }




        public DataTable GetDaTaForPC08Spread(string YCLLX, string CLBH, string ZT)
        {
            return dal.GetDaTaForPC08Spread(YCLLX, CLBH, ZT);
        }


        public DataTable GetYCLBH(string GLBH)
        {
            return dal.GetYCLBH();
        }

        public string Del(string CLBH)
        {
            return dal.Del(CLBH);
        }
		#endregion  ExtensionMethod
	}
}

