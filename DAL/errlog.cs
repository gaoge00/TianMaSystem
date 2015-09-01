/**  版本信息模板在安装目录下，可自行修改。
* errlog.cs
*
* 功 能： N/A
* 类 名： errlog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-23 13:52:10   N/A    初版
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
// //using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:errlog
	/// </summary>
	public partial class errlog
	{
		public errlog()
		{}  
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from errlog");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.errlog model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.LOG_MSG != null)
			{
				strSql1.Append("LOG_MSG,");
				strSql2.Append(""+model.LOG_MSG+",");
			}
			if (model.CXMC != null)
			{
				strSql1.Append("CXMC,");
				strSql2.Append("'"+model.CXMC+"',");
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
			strSql.Append("insert into errlog(");
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
		public bool Update(Model.errlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update errlog set ");
			if (model.LOG_MSG != null)
			{
				strSql.Append("LOG_MSG="+model.LOG_MSG+",");
			}
			else
			{
				strSql.Append("LOG_MSG= null ,");
			}
			if (model.CXMC != null)
			{
				strSql.Append("CXMC='"+model.CXMC+"',");
			}
			else
			{
				strSql.Append("CXMC= null ,");
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
			strSql.Append("delete from errlog ");
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
			strSql.Append("delete from errlog ");
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
		public Model.errlog GetModel(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,LOG_MSG,CXMC,RLZBH,RLR,RLSJ,RLDMM ");
			strSql.Append(" from errlog ");
			strSql.Append(" where ID="+ID+"" );
			Model.errlog model=new Model.errlog();
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
		public Model.errlog DataRowToModel(DataRow row)
		{
			Model.errlog model=new Model.errlog();
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
				if(row["CXMC"]!=null)
				{
					model.CXMC=row["CXMC"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,LOG_MSG,CXMC,RLZBH,RLR,RLSJ,RLDMM ");
			strSql.Append(" FROM errlog ");
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
			strSql.Append("select count(1) FROM errlog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySql.GetSingle(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from errlog T ");
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
        /// 插入错误日志
        /// </summary>
        /// <param name="ErrMsg">错误信息</param>
        /// <param name="PGID">程序ID</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="SysDate">系统日期</param>
        /// <param name="SysTime">系统时间</param>
        /// <param name="PCName">端末名称</param>
        public void InsertErrLog(string ErrMsg,string PGID,string UserID,string SysDate,string SysTime,string PCName)
        {
            string strSQL = " INSERT INTO ERRLOG VALUES ('" + ErrMsg + "','" + PGID + "','" + UserID + "','" + SysDate + "','" + SysTime + "','" + PCName + "');";
            DbHelperMySql.ExecuteSql(strSQL);
        }
		#endregion  MethodEx
	}
}

