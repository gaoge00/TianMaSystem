/**  版本信息模板在安装目录下，可自行修改。
* fmd090.cs
*
* 功 能： N/A
* 类 名： fmd090
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-11-11 15:51:04   N/A    初版
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
// using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:fmd090
	/// </summary>
	public partial class fmd090
	{
		public fmd090()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySql.GetMaxID("ID", "fmd090"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd090");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(Model.fmd090 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SX != null)
			{
				strSql1.Append("SX,");
				strSql2.Append(""+model.SX+",");
			}
			if (model.XX != null)
			{
				strSql1.Append("XX,");
				strSql2.Append(""+model.XX+",");
			}
			if (model.GC != null)
			{
				strSql1.Append("GC,");
				strSql2.Append(""+model.GC+",");
			}
			if (model.JSQF != null)
			{
				strSql1.Append("JSQF,");
				strSql2.Append("'"+model.JSQF+"',");
			}
			if (model.RLZBH != null)
			{
				strSql1.Append("RLZBH,");
				strSql2.Append("'"+model.RLZBH+"',");
			}
			if (model.RLR != null)
			{
				strSql1.Append("RLR,");
				strSql2.Append("'"+model.RLR+"',");
			}
			if (model.RLSJ != null)
			{
				strSql1.Append("RLSJ,");
				strSql2.Append("'"+model.RLSJ+"',");
			}
			if (model.RLDMM != null)
			{
				strSql1.Append("RLDMM,");
				strSql2.Append("'"+model.RLDMM+"',");
			}
			if (model.GXZBH != null)
			{
				strSql1.Append("GXZBH,");
				strSql2.Append("'"+model.GXZBH+"',");
			}
			if (model.GXR != null)
			{
				strSql1.Append("GXR,");
				strSql2.Append("'"+model.GXR+"',");
			}
			if (model.GXSJ != null)
			{
				strSql1.Append("GXSJ,");
				strSql2.Append("'"+model.GXSJ+"',");
			}
			if (model.GXDMM != null)
			{
				strSql1.Append("GXDMM,");
				strSql2.Append("'"+model.GXDMM+"',");
			}
			strSql.Append("insert into fmd090(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
            return strSql.ToString();
            //int rows=DbHelperMySql.ExecuteSql(strSql.ToString());
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string UpdateSql(Model.fmd090 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd090 set ");
			if (model.SX != null)
			{
				strSql.Append("SX="+model.SX+",");
			}
			else
			{
				strSql.Append("SX= null ,");
			}
			if (model.XX != null)
			{
				strSql.Append("XX="+model.XX+",");
			}
			else
			{
				strSql.Append("XX= null ,");
			}
			if (model.GC != null)
			{
				strSql.Append("GC="+model.GC+",");
			}
			else
			{
				strSql.Append("GC= null ,");
			}
			if (model.JSQF != null)
			{
				strSql.Append("JSQF='"+model.JSQF+"',");
			}
			else
			{
				strSql.Append("JSQF= null ,");
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
			strSql.Append(" where ID="+ model.ID+"");
            return strSql.ToString();
            //int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd090 ");
			strSql.Append(" where ID="+ID+"" );
            return strSql.ToString();
            //int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd090 ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySql.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd090 GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,SX,XX,GC,JSQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd090 ");
			strSql.Append(" where ID="+ID+"" );
			Model.fmd090 model=new Model.fmd090();
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
		public Model.fmd090 DataRowToModel(DataRow row)
		{
			Model.fmd090 model=new Model.fmd090();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
					//model.SX=row["SX"].ToString();
					//model.XX=row["XX"].ToString();
					//model.GC=row["GC"].ToString();
				if(row["JSQF"]!=null)
				{
					model.JSQF=row["JSQF"].ToString();
				}
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
			strSql.Append("select ID,SX,XX,GC,JSQF,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd090 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySql.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM fmd090 ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from fmd090 T ");
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
