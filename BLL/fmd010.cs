/**  版本信息模板在安装目录下，可自行修改。
* fmd010.cs
*
* 功 能： N/A
* 类 名： fmd010
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
	/// fmd010
	/// </summary>
	public partial class fmd010
	{
		private readonly DAL.fmd010 dal=new DAL.fmd010();
		public fmd010()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SYBH)
		{
			return dal.Exists(SYBH);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string  AddSQL(Model.fmd010 model)
		{
            return dal.AddSQL(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string  UpdateSQL(Model.fmd010 model)
		{
            return dal.UpdateSQL(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SYBH)
		{
			
			return dal.Delete(SYBH);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        //public bool DeleteList(string SYBHlist )
        //{
        //    return dal.DeleteList(Common.PageValidate.SafeLongFilter(SYBHlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd010 GetModel(string SYBH)
		{
			
			return dal.GetModel(SYBH);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.fmd010 GetModelByCache(string SYBH)
        //{
			
        //    string CacheKey = "fmd010Model-" + SYBH;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(SYBH);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.fmd010)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 得到打印机信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetPrinterInfo(string uid)
        {
            return dal.GetPrinterInfo(uid);

        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetListPc26(string strWhere)
		{
            return dal.GetListPc26(strWhere);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd010> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd010> DataTableToList(DataTable dt)
		{
			List<Model.fmd010> modelList = new List<Model.fmd010>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd010 model;
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
        public DataTable GetNameForList()//检索所有社员名
        {
            return dal.GetNameForList();
        }

        public DataSet GetDaTaForPC05Spread(string strSYNAME, string strSYBH)
        {
            return dal.GetDaTaForPC05Spread(strSYNAME,strSYBH);
        }
        public DataSet GetDaTaForWinSubKey_Value(string TB_NAME, string strKEY, string strVALUE)
        {
            return dal.GetDaTaForWinSubKey_Value(TB_NAME,strKEY,strVALUE);
        }

        public string GetData_Value(string TB_NAME, string strKEY, string strVALUE)
        {
            return dal.GetData_Value(TB_NAME,strKEY,strVALUE);
        }

           public string GetData_SYNAME( string strKEY, string strVALUE)
        {
            return dal.GetData_SYNAME(strKEY, strVALUE);
           }

        public string GetDelete(string SYBH)
        {
            return dal.GetDelete(SYBH);
        }


        public DataSet GetSYBH(string SYBH, string SCQF)
        {
            return dal.GetSYBH(SYBH, SCQF);
        }
        public string DeleteSybhRecover(string SYBH)
        {
            return dal.DeleteSybhRecover(SYBH);
        }

         /// <summary>
        /// 根据社员编号获取社员名称
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string getSYMCBySYBH(string SYBH)
        {
            return dal.getSYMCBySYBH(SYBH);
        }
       
		#endregion  ExtensionMethod
	}
}

