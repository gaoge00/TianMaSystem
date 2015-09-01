/**  版本信息模板在安装目录下，可自行修改。
* fmd000.cs
*
* 功 能： N/A
* 类 名： fmd000
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:49   N/A    初版
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
	/// 数据访问类:fmd000
	/// </summary>
	public partial class fmd000
	{
		public fmd000()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd000");
			strSql.Append(" where GLBH='"+GLBH+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.fmd000 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.GLBH != null)
			{
				strSql1.Append("GLBH,");
				strSql2.Append("'"+model.GLBH+"',");
			}
			
			if (model.ZSMC != null)
			{
				strSql1.Append("ZSMC,");
				strSql2.Append("'"+model.ZSMC+"',");
			}
			if (model.BZ != null)
			{
				strSql1.Append("BZ,");
				strSql2.Append("'"+model.BZ+"',");
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
			strSql.Append("insert into fmd000(");
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
		public bool Update(Model.fmd000 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd000 set ");
			if (model.ZSMC != null)
			{
				strSql.Append("ZSMC='"+model.ZSMC+"',");
			}
			if (model.BZ != null)
			{
				strSql.Append("BZ='"+model.BZ+"',");
			}
			else
			{
				strSql.Append("BZ= null ,");
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
			strSql.Append(" where GLBH='"+ model.GLBH+"'  ");
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
        public string DeleteByGLBH(string GLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd000 ");
			strSql.Append(" where GLBH='"+GLBH+"' " );
			return strSql.ToString();
			
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string DeleteByID(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from fmd000 ");
            strSql.Append(" where ID=" + ID + " ");
            return strSql.ToString();

        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.fmd000 GetModel(string GLBH,string MCKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" GLBH,MCKEY,ZSMC,BZ,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd000 ");
			strSql.Append(" where GLBH='"+GLBH+"' and MCKEY='"+MCKEY+"' " );
			Model.fmd000 model=new Model.fmd000();
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
		public Model.fmd000 DataRowToModel(DataRow row)
		{
			Model.fmd000 model=new Model.fmd000();
			if (row != null)
			{
				if(row["GLBH"]!=null)
				{
					model.GLBH=row["GLBH"].ToString();
				}
			
				if(row["ZSMC"]!=null)
				{
					model.ZSMC=row["ZSMC"].ToString();
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
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
			strSql.Append("select GLBH,MCKEY,ZSMC,BZ,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd000 ");
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
			strSql.Append("select count(1) FROM fmd000 ");
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
				strSql.Append("order by T.MCKEY desc");
			}
			strSql.Append(")AS Row, T.*  from fmd000 T ");
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


        #region
        public DataTable getspread(Model.fmd000 model)
        {
            string str = "";
            if (model.GLBH != "")
            {
                str = "select * from FMD000 where glbh like '%" + model.GLBH + "'  order by glbh";
            }

            return DbHelperMySql.Query(str).Tables[0];

        }

        public bool chkMCK_ZSMC(string GLBH, string ZSMC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM FMD000 WHERE GLBH='" + GLBH + "' AND ZSMC='" + ZSMC + "' ");
            return DbHelperMySql.Exists(strSql.ToString());
        }

        /// <summary>
        /// 根据管理编号和名称Key取到正式名称
        /// </summary>
        /// <param name="GLBH"></param>
        /// <param name="MCKEY"></param>
        /// <returns></returns>
        public string getZSMC(string GLBH, string MCKEY)
        {
            string strResult = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ZSMC FROM FMD000 WHERE GLBH='" + GLBH + "' AND MCKEY='" + MCKEY + "' ");
            DataTable dTableZsmc = new DataTable();
            dTableZsmc = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            if (dTableZsmc.Rows.Count > 0)
            {
                strResult = dTableZsmc.Rows[0]["ZSMC"].ToString();
            }
            return strResult;
        }



        public  DataTable GetFMD030MC_KEY(string GLBH)
        {
            DataTable dt = new DataTable();
            try
            {

                string RQ_sql = "";
                RQ_sql = "select  DISTINCT ZSMC,MCKEY from FMD000 WHERE GLBH='" + GLBH + "'  order by MCKEY ";
                dt = DbHelperMySql.Query(RQ_sql).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();   
            }
            return dt;
        }



        public string GetFMD030MC_KEY(string GLBH,string ZSMC)
        {
            string dt = "";
            try
            {

                string RQ_sql = "";
                RQ_sql = "select  DISTINCT MCKEY from FMD000 WHERE GLBH='" + GLBH + "' and ZSMC='"+ZSMC+"'  order by MCKEY ";
                 dt=DbHelperMySql.Query(RQ_sql).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }




		#endregion  MethodEx
	}
}

