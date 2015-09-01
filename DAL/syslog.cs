/**  版本信息模板在安装目录下，可自行修改。
* syslog.cs
*
* 功 能： N/A
* 类 名： syslog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-23 13:52:23   N/A    初版
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
////using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:syslog
	/// </summary>
	public partial class syslog
	{
		public syslog()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from syslog");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.syslog model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.LOG_MSG != null)
			{
				strSql1.Append("LOG_MSG,");
				strSql2.Append(""+model.LOG_MSG+",");
			}
			if (model.CZZBH != null)
			{
				strSql1.Append("CZZBH,");
				strSql2.Append("'"+model.CZZBH+"',");
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
			strSql.Append("insert into syslog(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.syslog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update syslog set ");
			if (model.LOG_MSG != null)
			{
				strSql.Append("LOG_MSG="+model.LOG_MSG+",");
			}
			else
			{
				strSql.Append("LOG_MSG= null ,");
			}
			if (model.CZZBH != null)
			{
				strSql.Append("CZZBH='"+model.CZZBH+"',");
			}
			else
			{
				strSql.Append("CZZBH= null ,");
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
		public bool Delete(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from syslog ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from syslog ");
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
		public Model.syslog GetModel(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,LOG_MSG,CZZBH,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from syslog ");
			strSql.Append(" where ID="+ID+"" );
			Model.syslog model=new Model.syslog();
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
		public Model.syslog DataRowToModel(DataRow row)
		{
			Model.syslog model=new Model.syslog();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["LOG_MSG"]!=null)
				{
					model.LOG_MSG=row["LOG_MSG"].ToString();
				}
				if(row["CZZBH"]!=null)
				{
					model.CZZBH=row["CZZBH"].ToString();
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
			strSql.Append("select ID,LOG_MSG,CZZBH,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM syslog ");
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
			strSql.Append("select count(1) FROM syslog ");
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
			strSql.Append(")AS Row, T.*  from syslog T ");
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
        /// <summary>
        /// 获取系统日期时间
        /// </summary>
        /// <returns></returns>
        public DataTable getsysDateTime()
        {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CALL getsysDateTime();");
                DataTable dt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
                return dt;
         }


       



		#endregion  MethodEx
	}
}

