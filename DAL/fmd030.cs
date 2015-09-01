/**  版本信息模板在安装目录下，可自行修改。
* fmd030.cs
*
* 功 能： N/A
* 类 名： fmd030
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:51   N/A    初版
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
	/// 数据访问类:fmd030
	/// </summary>
	public partial class fmd030
	{
		public fmd030()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string KHBH,string KHMC)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd030");
			strSql.Append(" where KHBH='"+KHBH+"' "); //and KHMC='"+KHMC+"'
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd030 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.KHBH != null)
			{
				strSql1.Append("KHBH,");
				strSql2.Append("'"+model.KHBH+"',");
			}
			if (model.KHMC != null)
			{
				strSql1.Append("KHMC,");
				strSql2.Append("'"+model.KHMC+"',");
			}
			if (model.KHSXM != null)
			{
				strSql1.Append("KHSXM,");
				strSql2.Append("'"+model.KHSXM+"',");
			}
			if (model.ZT != null)
			{
				strSql1.Append("ZT,");
				strSql2.Append("'"+model.ZT+"',");
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
			strSql.Append("insert into fmd030(");
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
		public bool Update(Model.fmd030 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd030 set ");

            if (model.KHMC != null)
            {
                strSql.Append("KHMC='" + model.KHMC + "',");
            }
            else
            {
                strSql.Append("KHMC= null ,");
            }
			if (model.KHSXM != null)
			{
				strSql.Append("KHSXM='"+model.KHSXM+"',");
			}
			else
			{
				strSql.Append("KHSXM= null ,");
			}
			if (model.ZT != null)
			{
				strSql.Append("ZT='"+model.ZT+"',");
			}
			else
			{
				strSql.Append("ZT= null ,");
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
			strSql.Append(" where KHBH='"+ model.KHBH+"'  ");//and KHMC='"+ model.KHMC+"'
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
		public bool Delete(string KHBH,string KHMC)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd030 set ZT='0' ");
			strSql.Append(" where KHBH='"+KHBH+"'  " );
           // strSql.Append(" and   KHMC='" + KHMC + "'  ");
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
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd030 GetModel(string KHBH,string KHMC)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" KHBH,KHMC,KHSXM,ZT,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd030 ");
			strSql.Append(" where KHBH='"+KHBH+"'" );
			Model.fmd030 model=new Model.fmd030();
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
		public Model.fmd030 DataRowToModel(DataRow row)
		{
			Model.fmd030 model=new Model.fmd030();
			if (row != null)
			{
				if(row["KHBH"]!=null)
				{
					model.KHBH=row["KHBH"].ToString();
				}
				if(row["KHMC"]!=null)
				{
					model.KHMC=row["KHMC"].ToString();
				}
				if(row["KHSXM"]!=null)
				{
					model.KHSXM=row["KHSXM"].ToString();
				}
				if(row["ZT"]!=null)
				{
					model.ZT=row["ZT"].ToString();
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
			strSql.Append("select KHBH,KHMC,KHSXM,ZT,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd030 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySql.Query(strSql.ToString());
		}

        
		/// <summary>
		/// 获得数据列表c
		/// </summary>
		public DataSet GetListPc25(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("  select '' KHMC,'' KHBH union select KHMC,KHBH ");
			strSql.Append(" FROM fmd030 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySql.Query(strSql.ToString());
		}


        public DataSet GetRKZF(string sRQ,string eRQ,string HLPCLOTNO)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select '' KHMC,'' KHBH union select distinct RKZF KHMC, RKZF KHBH ");
            strSql.Append(" FROM ffd010 where 1=1 ");
            if (sRQ.Trim() != "")
            {
                strSql.Append(" and LHRQ between '" + sRQ + "' and '" + eRQ + "' ");
            }
            if (HLPCLOTNO.Trim() != "")
            {
                strSql.Append(" and HLPCLOTNO='"+HLPCLOTNO+"' ");
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        public string GetKHBH(string strKHMC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  select KHMC,KHBH ");
            strSql.Append(" FROM fmd030 where KHMC='"+strKHMC+"' ");
            string strKHBH = "";
                DataSet dt=  DbHelperMySql.Query(strSql.ToString());
            if(dt.Tables.Count>0)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    strKHBH = dt.Tables[0].Rows[0]["KHBH"].ToString();
                }
            }
            return strKHBH;
        }
        

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM fmd030 ");
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
				strSql.Append("order by T.KHMC desc");
			}
			strSql.Append(")AS Row, T.*  from fmd030 T ");
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

        #region
        public DataTable getspread(Model.fmd030 model)
        {
            string str = "";

            str = "select * from FMD030    where ZT='1' order by  KHBH ";
           
            if (model.KHBH != "")
            {
                str = " select * from FMD030 where KHBH='" + model.KHBH + "' and zt='1' order by  KHBH   ";
            }          
            return DbHelperMySql.Query(str).Tables[0];

        }
        #endregion 


        public bool chkMCK_ZSMC(string GLBH, string MCKEY, string ZSMC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM FMD030 WHERE  KHBH<>'" + MCKEY + "' AND KHMC='" + ZSMC + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }
    }
}

