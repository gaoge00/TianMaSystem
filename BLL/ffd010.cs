/**  版本信息模板在安装目录下，可自行修改。
* ffd010.cs
*
* 功 能： N/A
* 类 名： ffd010
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:46   N/A    初版
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
	/// ffd010
	/// </summary>
	public partial class ffd010
	{
		private readonly DAL.ffd010 dal=new DAL.ffd010();
		public ffd010()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string HLPCLOTNO)
		{
            return dal.Exists(HLPCLOTNO);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ffd010 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.ffd010 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string IDlist )
        //{
        //    return dal.DeleteList(Common.PageValidate.SafeLongFilter(IDlist,0) );
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.ffd010 GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.ffd010 GetModelByCache(long ID)
        //{
			
        //    string CacheKey = "ffd010Model-" + ID;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.ffd010)objModel;
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
		public List<Model.ffd010> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.ffd010> DataTableToList(DataTable dt)
		{
			List<Model.ffd010> modelList = new List<Model.ffd010>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.ffd010 model;
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
        /// 根据混炼LotNo取入库追番		
        /// </summary>		
        /// <param name="strHLPCLOTNO"></param>		
        /// <returns></returns>		
        public DataTable getRKZF(string strHLPCLOTNO)
        {
            return dal.getRKZF(strHLPCLOTNO);
        } 


        /// <summary>
        /// 获取已经存在的检品信息
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public DataSet getJPInfo(string ID, string RKQF)
        {
            return dal.getJPInfo(ID,RKQF);
        }

        /// <summary>		
        /// 根据混炼LotNo取入库追番		
        /// </summary>		
        /// <param name="strHLPCLOTNO"></param>		
        /// <returns></returns>		
        public DataTable getRKMaxZF(string LHRQ)
        {
            return dal.getRKMaxZF(LHRQ);
        }

       
		#endregion  ExtensionMethod

        public DataTable GetPc21Js(DateTime startDt, DateTime endDt)
        {
            return dal.GetPc21Js(startDt, endDt);
        }

        public DataTable GetPc25Js02(string strCkrq, string strkhbh, string strClbh, string strPm, string strPh)
        {
            return dal.GetPc25Js02(strCkrq, strkhbh, strClbh, strPm, strPh);
        }


        /// <summary>
        /// 得到合格证明细(BSR)
        /// </summary>
        /// <param name="qrCode">条形码</param>
        /// <param name="checkDt">检品日期</param>
        /// <param name="checkUser">检品人</param>
        /// <returns></returns>
        public DataTable GetHgzBsrMX(string qrCode, string strKHBH)
        {
            return dal.GetHgzBsrMX(qrCode, strKHBH);

        }

        /// <summary>
        /// 得到合格证明细(ROHS)
        /// </summary>
        /// <param name="qrCode">条形码</param>
        /// <param name="strBZ">备注</param>
        /// <returns></returns>
        public DataTable GetHgzRohsMX(string qrCode, string strBZ,string strKHBH)
        {

            return dal.GetHgzRohsMX(qrCode, strBZ,strKHBH);

        }



	}
}

