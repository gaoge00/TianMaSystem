/**  版本信息模板在安装目录下，可自行修改。
* fmd080.cs
*
* 功 能： N/A
* 类 名： fmd080
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:54   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
//using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:fmd080
	/// </summary>
	public partial class fmd080
	{
		public fmd080()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PHBBH,string YCLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd080");
			strSql.Append(" where PHBBH='"+PHBBH+"' and YCLBH='"+YCLBH+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd080 model)
		{
            int rows = DbHelperMySql.ExecuteSql(Add_SQL(model));
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        public string Add_SQL(Model.fmd080 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.PHBBH != null)
            {
                strSql1.Append("PHBBH,");
                strSql2.Append("'" + model.PHBBH + "',");
            }
            if (model.YCLBH != null)
            {
                strSql1.Append("YCLBH,");
                strSql2.Append("'" + model.YCLBH + "',");
            }
            if (model.JLDW != null)
            {
                strSql1.Append("JLDW,");
                strSql2.Append("'" + model.JLDW + "',");
            }
            if (model.ZL != null)
            {
                strSql1.Append("ZL,");
                strSql2.Append("" + model.ZL + ",");
            }
            if (model.GC != null)
            {
                strSql1.Append("GC,");
                strSql2.Append("" + model.GC + ",");
            }
            if (model.XSS != null)
            {
                strSql1.Append("XSS,");
                strSql2.Append("" + model.XSS + ",");
            }
            if (model.BZ != null)
            {
                strSql1.Append("BZ,");
                strSql2.Append("'" + model.BZ + "',");
            }
            if (model.XS != null)
            {
                strSql1.Append("XS,");
                strSql2.Append("" + model.XS + ",");
            }
            if (model.RLZBH != null)
            {
                strSql1.Append("RLZBH,");
                strSql2.Append("'" + model.RLZBH + "',");
            }
            if (model.RLR != null)
            {
                strSql1.Append("RLR,");
                strSql2.Append("'" + model.RLR + "',");
            }
            if (model.RLSJ != null)
            {
                strSql1.Append("RLSJ,");
                strSql2.Append("'" + model.RLSJ + "',");
            }
            if (model.RLDMM != null)
            {
                strSql1.Append("RLDMM,");
                strSql2.Append("'" + model.RLDMM + "',");
            }
            if (model.GXZBH != null)
            {
                strSql1.Append("GXZBH,");
                strSql2.Append("'" + model.GXZBH + "',");
            }
            if (model.GXR != null)
            {
                strSql1.Append("GXR,");
                strSql2.Append("'" + model.GXR + "',");
            }
            if (model.GXSJ != null)
            {
                strSql1.Append("GXSJ,");
                strSql2.Append("'" + model.GXSJ + "',");
            }
            if (model.GXDMM != null)
            {
                strSql1.Append("GXDMM,");
                strSql2.Append("'" + model.GXDMM + "',");
            }
            strSql.Append("insert into fmd080(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");

            return strSql.ToString();
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.fmd080 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd080 set ");
			if (model.JLDW != null)
			{
				strSql.Append("JLDW='"+model.JLDW+"',");
			}
			else
			{
				strSql.Append("JLDW= null ,");
			}
			if (model.ZL != null)
			{
				strSql.Append("ZL="+model.ZL+",");
			}
			else
			{
				strSql.Append("ZL= null ,");
			}
			if (model.GC != null)
			{
				strSql.Append("GC="+model.GC+",");
			}
			else
			{
				strSql.Append("GC= null ,");
			}
			if (model.XSS != null)
			{
				strSql.Append("XSS="+model.XSS+",");
			}
			if (model.BZ != null)
			{
				strSql.Append("BZ='"+model.BZ+"',");
			}
			else
			{
				strSql.Append("BZ= null ,");
			}
			if (model.XS != null)
			{
				strSql.Append("XS="+model.XS+",");
			}
			if (model.RLZBH != null)
			{
				strSql.Append("RLZBH='"+model.RLZBH+"',");
			}
			else
			{
				strSql.Append("RLZBH= null ,");
			}
			if (model.RLR != null)
			{
				strSql.Append("RLR='"+model.RLR+"',");
			}
			else
			{
				strSql.Append("RLR= null ,");
			}
			if (model.RLSJ != null)
			{
				strSql.Append("RLSJ='"+model.RLSJ+"',");
			}
			else
			{
				strSql.Append("RLSJ= null ,");
			}
			if (model.RLDMM != null)
			{
				strSql.Append("RLDMM='"+model.RLDMM+"',");
			}
			else
			{
				strSql.Append("RLDMM= null ,");
			}
			if (model.GXZBH != null)
			{
				strSql.Append("GXZBH='"+model.GXZBH+"',");
			}
			else
			{
				strSql.Append("GXZBH= null ,");
			}
			if (model.GXR != null)
			{
				strSql.Append("GXR='"+model.GXR+"',");
			}
			else
			{
				strSql.Append("GXR= null ,");
			}
			if (model.GXSJ != null)
			{
				strSql.Append("GXSJ='"+model.GXSJ+"',");
			}
			else
			{
				strSql.Append("GXSJ= null ,");
			}
			if (model.GXDMM != null)
			{
				strSql.Append("GXDMM='"+model.GXDMM+"',");
			}
			else
			{
				strSql.Append("GXDMM= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PHBBH='"+ model.PHBBH+"' and YCLBH='"+ model.YCLBH+"' ");
			int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PHBBH)
		{

            int rowsAffected = DbHelperMySql.ExecuteSql(Delete_SQL(PHBBH));
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete_SQL(string PHBBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd080 ");
            strSql.Append(" where PHBBH='" + PHBBH + "' ");

            return strSql.ToString();
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd080 GetModel(string PHBBH,string YCLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" PHBBH,YCLBH,JLDW,ZL,GC,XSS,BZ,XS,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd080 ");
			strSql.Append(" where PHBBH='"+PHBBH+"' and YCLBH='"+YCLBH+"' " );
			Model.fmd080 model=new Model.fmd080();
			DataSet ds=DbHelperMySql.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd080 DataRowToModel(DataRow row)
		{
			Model.fmd080 model=new Model.fmd080();
			if (row != null)
			{
				if(row["PHBBH"]!=null)
				{
					model.PHBBH=row["PHBBH"].ToString();
				}
				if(row["YCLBH"]!=null)
				{
					model.YCLBH=row["YCLBH"].ToString();
				}
				if(row["JLDW"]!=null)
				{
					model.JLDW=row["JLDW"].ToString();
				}
				if(row["ZL"]!=null && row["ZL"].ToString()!="")
				{
					model.ZL=decimal.Parse(row["ZL"].ToString());
				}
				if(row["GC"]!=null && row["GC"].ToString()!="")
				{
					model.GC=decimal.Parse(row["GC"].ToString());
				}
				if(row["XSS"]!=null && row["XSS"].ToString()!="")
				{
					model.XSS=int.Parse(row["XSS"].ToString());
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
				}
                if (row["XS"] != null && row["XS"].ToString() != "")
                {
                    model.XS = double.Parse(row["XS"].ToString());
                }
					//model.XS=row["XS"].ToString();
				if(row["RLZBH"]!=null)
				{
					model.RLZBH=row["RLZBH"].ToString();
				}
				if(row["RLR"]!=null)
				{
					model.RLR=row["RLR"].ToString();
				}
				if(row["RLSJ"]!=null)
				{
					model.RLSJ=row["RLSJ"].ToString();
				}
				if(row["RLDMM"]!=null)
				{
					model.RLDMM=row["RLDMM"].ToString();
				}
				if(row["GXZBH"]!=null)
				{
					model.GXZBH=row["GXZBH"].ToString();
				}
				if(row["GXR"]!=null)
				{
					model.GXR=row["GXR"].ToString();
				}
				if(row["GXSJ"]!=null)
				{
					model.GXSJ=row["GXSJ"].ToString();
				}
				if(row["GXDMM"]!=null)
				{
					model.GXDMM=row["GXDMM"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PHBBH,YCLBH,JLDW,ZL,GC,XSS,BZ,XS,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd080 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by  XSS asc ");
			return DbHelperMySql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM fmd080 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.YCLBH desc");
			}
			strSql.Append(")AS Row, T.*  from fmd080 T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySql.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

