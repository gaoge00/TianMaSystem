/**  版本信息模板在安装目录下，可自行修改。
* fmd050.cs
*
* 功 能： N/A
* 类 名： fmd050
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-9-26 10:45:52   N/A    初版
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
	/// 数据访问类:fmd050
	/// </summary>
	public partial class fmd050
	{
		public fmd050()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fmd050");
			strSql.Append(" where CLBH='"+CLBH+"' ");
			return DbHelperMySql.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string AddSQL(Model.fmd050 model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.CLBH != null)
			{
				strSql1.Append("CLBH,");
				strSql2.Append("'"+model.CLBH+"',");
			}
			if (model.YXTS != null)
			{
				strSql1.Append("YXTS,");
				strSql2.Append(""+model.YXTS+",");
			}
			if (model.JLDW != null)
			{
				strSql1.Append("JLDW,");
				strSql2.Append("'"+model.JLDW+"',");
			}
			if (model.ZT != null)
			{
				strSql1.Append("ZT,");
				strSql2.Append("'"+model.ZT+"',");
			}
			if (model.JJ != null)
			{
				strSql1.Append("JJ,");
				strSql2.Append("'"+model.JJ+"',");
			}
			if (model.MS != null)
			{
				strSql1.Append("MS,");
				strSql2.Append("'"+model.MS+"',");
			}
			if (model.ZXKC != null)
			{
				strSql1.Append("ZXKC,");
				strSql2.Append(""+model.ZXKC+",");
			}
			if (model.ZDKC != null)
			{
				strSql1.Append("ZDKC,");
				strSql2.Append(""+model.ZDKC+",");
			}
			if (model.YCLBHBS != null)
			{
				strSql1.Append("YCLBHBS,");
				strSql2.Append("'"+model.YCLBHBS+"',");
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
			strSql.Append("insert into fmd050(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
            //int rows=DbHelperMySql.ExecuteSql(strSql.ToString());
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return strSql.ToString();
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public string UpdateSQL(Model.fmd050 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fmd050 set ");
			if (model.YXTS != null)
			{
				strSql.Append("YXTS="+model.YXTS+",");
			}
			else
			{
				strSql.Append("YXTS= null ,");
			}
			if (model.JLDW != null)
			{
				strSql.Append("JLDW='"+model.JLDW+"',");
			}
			else
			{
				strSql.Append("JLDW= null ,");
			}
			if (model.ZT != null)
			{
				strSql.Append("ZT='"+model.ZT+"',");
			}
			else
			{
				strSql.Append("ZT= null ,");
			}
			if (model.JJ != null)
			{
				strSql.Append("JJ='"+model.JJ+"',");
			}
			else
			{
				strSql.Append("JJ= null ,");
			}
			if (model.MS != null)
			{
				strSql.Append("MS='"+model.MS+"',");
			}
			else
			{
				strSql.Append("MS= null ,");
			}
			if (model.ZXKC != null)
			{
				strSql.Append("ZXKC="+model.ZXKC+",");
			}
			else
			{
				strSql.Append("ZXKC= null ,");
			}
			if (model.ZDKC != null)
			{
				strSql.Append("ZDKC="+model.ZDKC+",");
			}
			else
			{
				strSql.Append("ZDKC= null ,");
			}
			if (model.YCLBHBS != null)
			{
				strSql.Append("YCLBHBS='"+model.YCLBHBS+"',");
			}
			else
			{
				strSql.Append("YCLBHBS= null ,");
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
			strSql.Append(" where CLBH='"+ model.CLBH+"' ");
            //int rowsAffected=DbHelperMySql.ExecuteSql(strSql.ToString());
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return strSql.ToString();
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string Delete(string CLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update  fmd050 set ZT='1' ");
			strSql.Append(" where CLBH='"+CLBH+"' " );
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
                /// 
                /// 
                /// 
                /// 
                /// 
        public string Del(string CLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  fmd050  ");
            strSql.Append(" where CLBH='" + CLBH + "' ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CLBHlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fmd050 ");
			strSql.Append(" where CLBH in ("+CLBHlist + ")  ");
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
		public Model.fmd050 GetModel(string CLBH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" CLBH,YXTS,JLDW,ZT,JJ,MS,ZXKC,ZDKC,YCLBHBS,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" from fmd050 ");
			strSql.Append(" where CLBH='"+CLBH+"' " );
			Model.fmd050 model=new Model.fmd050();
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
		public Model.fmd050 DataRowToModel(DataRow row)
		{
			Model.fmd050 model=new Model.fmd050();
			if (row != null)
			{
				if(row["CLBH"]!=null)
				{
					model.CLBH=row["CLBH"].ToString();
				}
				if(row["YXTS"]!=null && row["YXTS"].ToString()!="")
				{
					model.YXTS=int.Parse(row["YXTS"].ToString());
				}
				if(row["JLDW"]!=null)
				{
					model.JLDW=row["JLDW"].ToString();
				}
				if(row["ZT"]!=null)
				{
					model.ZT=row["ZT"].ToString();
				}
				if(row["JJ"]!=null)
				{
					model.JJ=row["JJ"].ToString();
				}
				if(row["MS"]!=null)
				{
					model.MS=row["MS"].ToString();
				}
				if(row["ZXKC"]!=null && row["ZXKC"].ToString()!="")
				{
					model.ZXKC=decimal.Parse(row["ZXKC"].ToString());
				}
				if(row["ZDKC"]!=null && row["ZDKC"].ToString()!="")
				{
					model.ZDKC=decimal.Parse(row["ZDKC"].ToString());
				}
				if(row["YCLBHBS"]!=null)
				{
					model.YCLBHBS=row["YCLBHBS"].ToString();
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
			strSql.Append("select CLBH,YXTS,JLDW,ZT,JJ,MS,ZXKC,ZDKC,YCLBHBS,RLZBH,RLR,RLSJ,RLDMM,GXZBH,GXR,GXSJ,GXDMM ");
			strSql.Append(" FROM fmd050 ");
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
			strSql.Append("select count(1) FROM fmd050 ");
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
				strSql.Append("order by T.CLBH desc");
			}
			strSql.Append(")AS Row, T.*  from fmd050 T ");
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
        public DataTable GetCLBH_050(string strYCLBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DISTINCT CLBH ");
            strSql.Append(" FROM fmd050  WHERE YCLBHBS='" + strYCLBH + "' and ZT='0'");
            return DbHelperMySql.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到材料过期日
        /// </summary>
        /// <param name="CLBH">材料编号</param>
        /// <param name="HLRY">混炼日期</param>
        /// <returns></returns>
        public DateTime GetYXTS(string CLBH, string HLRY)
        {
            string strSql = "select DATE_ADD('" + HLRY + "',INTERVAL YXTS DAY) from fmd050 where CLBH='" + CLBH + "'";
            string YXTS = DbHelperMySql.GetSingle(strSql).ToString();

            return Convert.ToDateTime(YXTS);
        }




        /// <summary>
        /// 得到原材料明细
        /// </summary>
        /// <param name="YCLBH"></param>
        /// <returns></returns>
        public DataTable GetDaTaForPC08Spread(string YCLLX, string CLBH, string ZT)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select YCLBHBS,                                                                       ");
            //strSql.Append("YCLBHGHS,                                                                             ");
            //strSql.Append("YCLLX,                                                                                ");
            //strSql.Append("ZT,                                                                                   ");
            //strSql.Append("YXTS,                                                                                 ");
            //strSql.Append("JJ,                                                                                   ");
            //strSql.Append("MS,                                                                                   ");
            //strSql.Append("ZXKC,                                                                                 ");
            //strSql.Append("ZDKC,                                                                                 ");
            //strSql.Append("JLDW                                                                                  ");





            //strSql.Append("select YCLBHBS,                                                                       ");
            //strSql.Append("YCLBHGHS,                                                                             ");
            //strSql.Append("b.ZSMC YCLLX,                                                                         ");
            //strSql.Append("CASE ZT WHEN '0' THEN '正常' else '已作废' END ZT,                                         ");
            //strSql.Append("YXTS,                                                                                 ");
            //strSql.Append("JJ,                                                                                   ");
            //strSql.Append("MS,                                                                                   ");
            //strSql.Append("ZXKC,                                                                                 ");
            //strSql.Append("ZDKC,                                                                                 ");
            //strSql.Append("JLDW                                                                                  ");
            //strSql.Append("from fmd040 a                                                                         ");
            //strSql.Append("left join (select MCKEY,ZSMC from fmd000 where GLBH='03'  ) b  on (a.YCLLX=b.MCKEY)   ");

            strSql.Append(" select CLBH,");
            strSql.Append(" YXTS, ");
            strSql.Append(" b.ZSMC JLDW, ");
            strSql.Append(" CASE ZT WHEN '0' THEN '正常' else '已作废' END ZT, ");
            strSql.Append(" JJ,");
            strSql.Append(" MS,");
            strSql.Append(" ZXKC,");
            strSql.Append(" ZDKC,");
            strSql.Append(" YCLBHBS");
            strSql.Append(" from fmd050  a left JOIN (select ZSMC,MCKEY from fmd000 where GLBH='06') b on (a.JLDW=b.mckey)  ");


            strSql.Append("  where  1=1                                                                   ");
            if (string.IsNullOrEmpty(YCLLX) == false)
            {
                strSql.Append("and YCLLX ='" + YCLLX + "' ");
            }
            if (string.IsNullOrEmpty(CLBH) == false)
            {
                strSql.Append("and CLBH like '%" + CLBH + "%' ");
            }
            if (string.IsNullOrEmpty(ZT) == false)
            {
                strSql.Append("and ZT ='" + ZT + "' ");
            }

            strSql.Append(" order by ZT desc,CLBH ");

            DataTable myDt = DbHelperMySql.Query(strSql.ToString()).Tables[0];
            return myDt;
        }


        public DataTable GetYCLBH()
        {
            DataTable dt = new DataTable();
            try
            {

                string RQ_sql = "";
                RQ_sql = "select  DISTINCT YCLBHBS ZSMC, YCLBHBS MCKEY from FMD040 where zt='0' AND YCLLX in ('001','003')  order by YCLBHBS  ";
                dt = DbHelperMySql.Query(RQ_sql).Tables[0];
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

