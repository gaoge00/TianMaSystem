/**  版本信息模板在安装目录下，可自行修改。
* fmd070.cs
*
* 功 能： N/A
* 类 名： fmd070
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:53   N/A    初版
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
using System.Collections;
namespace BLL
{
	/// <summary>
	/// fmd070
	/// </summary>
	public partial class fmd070
	{
		private readonly DAL.fmd070 dal=new DAL.fmd070();
		public fmd070()
		{}

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CLBH,string PHBBH)
		{
			return dal.Exists(CLBH,PHBBH);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd070 model)
		{
			return dal.Add(model);
		}

        public string Add_SQL(Model.fmd070 model)
        {
            return dal.Add_SQL(model);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.fmd070 model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update_SQL(Model.fmd070 model)
        {
            return dal.Update_SQL(model);
        }


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CLBH,string PHBBH)
		{
			
			return dal.Delete(CLBH,PHBBH);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete_SQL(string CLBH, string PHBBH)
        {

            return dal.Delete_SQL(CLBH, PHBBH);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd070 GetModel(string CLBH,string PHBBH)
		{
			
			return dal.GetModel(CLBH,PHBBH);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd070 GetModelByCache(string CLBH,string PHBBH)
        //{
			
        //    string CacheKey = "fmd070Model-" + CLBH+PHBBH;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(CLBH,PHBBH);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd070)objModel;
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
		public List<Model.fmd070> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd070> DataTableToList(DataTable dt)
		{
			List<Model.fmd070> modelList = new List<Model.fmd070>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd070 model;
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
        /// 获得配合表编号
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public DataTable GetPHBBH(string CLBH)
        {
            string strWhere = " CLBH='" + CLBH + "' and ZT='0' ";
            string strOrderBy = " PHBBH asc";
            DataTable myDt= dal.GetList(strWhere, strOrderBy).Tables[0];
            myDt.TableName = "PHBBH";
            return myDt;
        }

        /// <summary>
        /// 得到配合明细
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="PHBBH">配合表编号</param>
        /// <param name="SL">数量</param>
        /// <param name="HLPCLOTNO">混炼批次号</param>
        /// <returns></returns>
        public DataTable GetPHMX(string CLBH, string PHBBH, string SL, string HLPCLOTNO)
        {
            DataTable myDt = dal.GetPHMX(CLBH, PHBBH, SL, HLPCLOTNO);
            myDt.TableName = "PHBBH";

            return myDt;
        }
        public DataTable GetSpdData(string rqS, string rqE, string CLBH, string PHBBH, string ZCR, string PZR)
        {
            return dal.GetSpdData(rqS, rqE, CLBH, PHBBH, ZCR, PZR);
        }

        /// <summary>
        /// 生成追番
        /// </summary>
        /// <param name="PHBN">配合表年</param>
        /// <returns></returns>
        public string GenerateZF(string PHBN)
        {
            return dal.GenerateZF(PHBN);
        }

        /// <summary>
        /// 得到比例合计
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public double GetSumBL(string CLBH)
        {
            return dal.GetSumBL(CLBH);
        }

        /// <summary>
        /// 得到配合表
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <returns></returns>
        public ArrayList GetPhbs(string CLBH)
        {
            return dal.GetPhbs(CLBH);
        }


        /// <summary>
        /// 更新系数
        /// </summary>
        /// <param name="phbbh"></param>
        /// <param name="sumXS"></param>
        /// <returns></returns>
        public string UpdateXsByPHB(string CLBH)
        {
            return dal.UpdateXsByPHB(CLBH);
        }

        /// <summary>
        /// 得到配合表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public DataTable GetListByPBH(string strWhere, string orderby)
        {
            return dal.GetListByPBH(strWhere, orderby);
        }
		#endregion  ExtensionMethod
	}
}

