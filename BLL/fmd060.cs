/**  版本信息模板在安装目录下，可自行修改。
* fmd060.cs
*
* 功 能： N/A
* 类 名： fmd060
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
	/// fmd060
	/// </summary>
	public partial class fmd060
	{
		private readonly DAL.fmd060 dal=new DAL.fmd060();
		public fmd060()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PM,string PH,string CLBH)
		{
			return dal.Exists(PM,PH,CLBH);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string AddSQL(Model.fmd060 model)
		{
			return dal.AddSql(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string UpdateSQL(Model.fmd060 model)
		{
            return dal.UpdateSql(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string Delete(string PM,string PH,string CLBH)
		{
			
			return dal.Delete(PM,PH,CLBH);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd060 GetModel(string PM,string PH,string CLBH)
		{
			
			return dal.GetModel(PM,PH,CLBH);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd060 GetModelByCache(string PM,string PH,string CLBH)
        //{
			
        //    string CacheKey = "fmd060Model-" + PM+PH+CLBH;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(PM,PH,CLBH);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd060)objModel;
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
		public List<Model.fmd060> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd060> DataTableToList(DataTable dt)
		{
			List<Model.fmd060> modelList = new List<Model.fmd060>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd060 model;
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
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsEVE(string PM, string PH, string CLBH)
        {
            return dal.ExistsEVE(PM, PH, CLBH);
        }

        /// <summary>
        /// 获取入库标准（小袋，大袋，箱标准）
        /// </summary>
        public DataTable getRKBiaoZhun(string PM, string PH, string CLBH)
        {
            return dal.getRKBiaoZhun(PM,PH,CLBH);
        }


        public DataTable GetDaTaForPC08Spread(string PM, string PH, string CLBH, string FLH,string ECLH)
        {
            return dal.GetDaTaForPC08Spread(PM, PH, CLBH, FLH, ECLH);
        }

        /// <summary>
        /// 是否存在该记录(品名)
        /// </summary>
        public bool ExistsPM(string PM)
        {
            return dal.ExistsPM(PM);
        }
        /// <summary>
        /// 是否存在该记录(品号)
        /// </summary>
        public bool ExistsPH(string PM, string PH)
        {
            return dal.ExistsPH(PM, PH);
        }

        /// <summary>
        /// 是否存在该记录(材料编号)
        /// </summary>
        public bool ExistsCLBH(string PM, string PH, string CLBH)
        {
            return dal.ExistsCLBH(PM, PH, CLBH);
        }
        public DataTable get_DT(string PM, string PH, string CLBH, string QF)
        {
            return dal.get_DT(PM,PH,CLBH,QF);
        }

         /// <summary>
        /// 根据材料编号获取品名 或者 品号的列表
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="QF">区分</param>
        /// <returns></returns>
        public DataTable getPM_PHByCLBH(string CLBH, string QF)
        {
            return dal.getPM_PHByCLBH(CLBH, QF);
        }
        /// <summary>
        /// 根据品名，品号，材料编号 获取此种产品是否需要二次硫化
        /// </summary>
        /// <param name="PM">品名</param>
        /// <param name="PH">品号</param>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public bool getERCLHByCLBH_PM_PH(string PM, string PH, string CLBH)
        {
            return dal.getERCLHByCLBH_PM_PH(PM, PH, CLBH);
        }


		#endregion  ExtensionMethod
	}
}

