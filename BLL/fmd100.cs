
using System;
using System.Data;
using System.Collections.Generic;
//using Common;
using Model;

namespace BLL
{
    	/// <summary>
	/// fed020
	/// </summary>
    public partial class fmd100
	{
		private readonly DAL.fmd100 dal=new DAL.fmd100();
		public fmd100()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string KHBH, string PMGC, string PHGC, string CLBHGC)
		{
            return dal.Exists(KHBH, PMGC, PHGC, CLBHGC);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(Model.fmd100 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public string Update(Model.fmd100 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public string Delete(string KHBH, string PMGC, string PHGC, string CLBHGC)
		{
			
			return dal.Delete(KHBH,PMGC,PHGC, CLBHGC);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd100 GetModel(string KHBH,string PMGC,string PHGC)
		{
			
			return dal.GetModel(KHBH,PMGC,PHGC);
		}



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
		public List<Model.fmd100> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.fmd100> DataTableToList(DataTable dt)
		{
			List<Model.fmd100> modelList = new List<Model.fmd100>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.fmd100 model;
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

        public DataTable GetSpread(string strWhere)
        {
            return dal.GetSpread(strWhere);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
